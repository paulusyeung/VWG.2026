#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
	[Serializable]
	internal class PropertyDescriptorGridEntry : GridEntry
	{
		[Serializable]
		public class ExceptionConverter : TypeConverter
		{
			public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
			{
				if (objDestinationType != typeof(string))
				{
					throw GetConvertToException(objValue, objDestinationType);
				}
				if (!(objValue is Exception))
				{
					return null;
				}
				Exception ex = (Exception)objValue;
				if (ex.InnerException != null)
				{
					ex = ex.InnerException;
				}
				return ex.Message;
			}
		}

		[Serializable]
		private class ExceptionEditor : WebUITypeEditor
		{
			public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
			{
				if (objValue is Exception { Message: var text } ex)
				{
					if (text == null || text.Length == 0)
					{
						text = ex.ToString();
					}
					MessageBox.Show(text, SR.GetString("PropertyGridExceptionInfo"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
				}
			}

			public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
			{
				return UITypeEditorEditStyle.Modal;
			}
		}

		private static IEventBindingService mobjTargetBindingService;

		private static IComponent mobjTargetComponent;

		private static EventDescriptor mobjTargetEventDescriptor;

		private const byte mParensAroundNameNo = 0;

		private const byte mParensAroundNameUnknown = byte.MaxValue;

		private const byte mParensAroundNameYes = 1;

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty mblnActiveXHideProperty = SerializableProperty.Register("mblnActiveXHide", typeof(bool), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The IEventBindingService property registration.
		/// </summary>
		private static readonly SerializableProperty mobjEventBindingsProperty = SerializableProperty.Register("mobjEventBindings", typeof(IEventBindingService), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The System.ComponentModel.TypeConverter property registration.
		/// </summary>
		private static readonly SerializableProperty mobjEexceptionConverterProperty = SerializableProperty.Register("mobjEexceptionConverter", typeof(TypeConverter), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
		/// </summary>
		private static readonly SerializableProperty mobjExceptionEditorProperty = SerializableProperty.Register("mobjExceptionEditor", typeof(WebUITypeEditor), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty mblnForceRenderReadOnlyProperty = SerializableProperty.Register("mblnForceRenderReadOnly", typeof(bool), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The string property registration.
		/// </summary>
		private static readonly SerializableProperty mstrHelpKeywordProperty = SerializableProperty.Register("mstrHelpKeyword", typeof(string), typeof(PropertyDescriptorGridEntry));

		private const int IMAGE_SIZE = 8;

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty mblnIsSerializeContentsPropProperty = SerializableProperty.Register("mblnIsSerializeContentsProp", typeof(bool), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The byte property registration.
		/// </summary>
		private static readonly SerializableProperty mParensAroundNameProperty = SerializableProperty.Register("mParensAroundName", typeof(byte), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The System.ComponentModel.PropertyDescriptor property registration.
		/// </summary>
		private static readonly SerializableProperty mobjPropertyInfoProperty = SerializableProperty.Register("mobjPropertyInfo", typeof(PropertyDescriptor), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The IPropertyValueUIService property registration.
		/// </summary>
		private static readonly SerializableProperty mobjPropertyValueUIServiceProperty = SerializableProperty.Register("mobjPropertyValueUIService", typeof(IPropertyValueUIService), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty mobjServiceCheckedProperty = SerializableProperty.Register("mobjServiceChecked", typeof(bool), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The PropertyValueUIItem{} property registration.
		/// </summary>
		private static readonly SerializableProperty marrPropertyValueUIItemsProperty = SerializableProperty.Register("marrPropertyValueUIItems", typeof(PropertyValueUIItem[]), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty mblnReadOnlyVerifiedProperty = SerializableProperty.Register("mblnReadOnlyVerified", typeof(bool), typeof(PropertyDescriptorGridEntry));

		/// 
		/// The string property registration.
		/// </summary>
		private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register("mstrToolTipText", typeof(string), typeof(PropertyDescriptorGridEntry));

		private bool mblnActiveXHide
		{
			get
			{
				return GetValue(mblnActiveXHideProperty);
			}
			set
			{
				SetValue(mblnActiveXHideProperty, value);
			}
		}

		protected IEventBindingService mobjEventBindings
		{
			get
			{
				return GetValue(mobjEventBindingsProperty);
			}
			set
			{
				SetValue(mobjEventBindingsProperty, value);
			}
		}

		private TypeConverter mobjEexceptionConverter
		{
			get
			{
				return GetValue(mobjEexceptionConverterProperty);
			}
			set
			{
				SetValue(mobjEexceptionConverterProperty, value);
			}
		}

		private WebUITypeEditor mobjExceptionEditor
		{
			get
			{
				return GetValue(mobjExceptionEditorProperty);
			}
			set
			{
				SetValue(mobjExceptionEditorProperty, value);
			}
		}

		private bool mblnForceRenderReadOnly
		{
			get
			{
				return GetValue(mblnForceRenderReadOnlyProperty);
			}
			set
			{
				SetValue(mblnForceRenderReadOnlyProperty, value);
			}
		}

		private string mstrHelpKeyword
		{
			get
			{
				return GetValue(mstrHelpKeywordProperty);
			}
			set
			{
				SetValue(mstrHelpKeywordProperty, value);
			}
		}

		private bool mblnIsSerializeContentsProp
		{
			get
			{
				return GetValue(mblnIsSerializeContentsPropProperty);
			}
			set
			{
				SetValue(mblnIsSerializeContentsPropProperty, value);
			}
		}

		private byte mParensAroundName
		{
			get
			{
				return GetValue(mParensAroundNameProperty);
			}
			set
			{
				SetValue(mParensAroundNameProperty, value);
			}
		}

		internal PropertyDescriptor mobjPropertyInfo
		{
			get
			{
				return GetValue(mobjPropertyInfoProperty);
			}
			set
			{
				SetValue(mobjPropertyInfoProperty, value);
			}
		}

		private IPropertyValueUIService mobjPropertyValueUIService
		{
			get
			{
				return GetValue(mobjPropertyValueUIServiceProperty);
			}
			set
			{
				SetValue(mobjPropertyValueUIServiceProperty, value);
			}
		}

		private bool mobjServiceChecked
		{
			get
			{
				return GetValue(mobjServiceCheckedProperty);
			}
			set
			{
				SetValue(mobjServiceCheckedProperty, value);
			}
		}

		private PropertyValueUIItem[] marrPropertyValueUIItems
		{
			get
			{
				return GetValue<PropertyValueUIItem[]>(marrPropertyValueUIItemsProperty);
			}
			set
			{
				SetValue(marrPropertyValueUIItemsProperty, value);
			}
		}

		private bool mblnReadOnlyVerified
		{
			get
			{
				return GetValue(mblnReadOnlyVerifiedProperty);
			}
			set
			{
				SetValue(mblnReadOnlyVerifiedProperty, value);
			}
		}

		private string mstrToolTipText
		{
			get
			{
				return GetValue(mstrToolTipTextProperty);
			}
			set
			{
				SetValue(mstrToolTipTextProperty, value);
			}
		}

		public override bool AllowMerge => ((MergablePropertyAttribute)mobjPropertyInfo.Attributes[typeof(MergablePropertyAttribute)])?.IsDefaultAttribute() ?? true;

		internal override System.ComponentModel.AttributeCollection Attributes => mobjPropertyInfo.Attributes;

		internal override bool Enumerable
		{
			get
			{
				if (base.Enumerable)
				{
					return !IsPropertyReadOnly;
				}
				return false;
			}
		}

		public override string HelpKeyword
		{
			get
			{
				if (mstrHelpKeyword == null)
				{
					object valueOwner = GetValueOwner();
					if (valueOwner == null)
					{
						return null;
					}
					HelpKeywordAttribute helpKeywordAttribute = (HelpKeywordAttribute)mobjPropertyInfo.Attributes[typeof(HelpKeywordAttribute)];
					if (helpKeywordAttribute != null && !helpKeywordAttribute.IsDefaultAttribute())
					{
						return helpKeywordAttribute.HelpKeyword;
					}
					if (this is ImmutablePropertyDescriptorGridEntry)
					{
						mstrHelpKeyword = PropertyName;
						GridEntry gridEntry = this;
						while (gridEntry.ParentGridEntry != null)
						{
							gridEntry = gridEntry.ParentGridEntry;
							if (gridEntry.PropertyValue == valueOwner || (valueOwner.GetType().IsValueType && valueOwner.GetType() == gridEntry.PropertyValue.GetType()))
							{
								mstrHelpKeyword = gridEntry.PropertyName + "." + mstrHelpKeyword;
								break;
							}
						}
					}
					else
					{
						string text = "";
						Type type = mobjPropertyInfo.ComponentType;
						if (type.IsCOMObject)
						{
							text = TypeDescriptor.GetClassName(valueOwner);
						}
						else
						{
							Type type2 = valueOwner.GetType();
							if (!type.IsPublic || !type.IsAssignableFrom(type2))
							{
								type = TypeDescriptor.GetProperties(type2)[PropertyName]?.ComponentType;
							}
							text = ((!(type == null)) ? type.FullName : TypeDescriptor.GetClassName(valueOwner));
						}
						mstrHelpKeyword = text + "." + mobjPropertyInfo.Name;
					}
				}
				return mstrHelpKeyword;
			}
		}

		internal override string HelpKeywordInternal => PropertyLabel;

		protected virtual bool IsPropertyReadOnly => mobjPropertyInfo.IsReadOnly;

		public override bool IsValueEditable
		{
			get
			{
				if (mobjEexceptionConverter == null && !IsPropertyReadOnly)
				{
					return base.IsValueEditable;
				}
				return false;
			}
		}

		public override bool NeedsDropDownButton
		{
			get
			{
				if (base.NeedsDropDownButton)
				{
					return !IsPropertyReadOnly;
				}
				return false;
			}
		}

		internal bool ParensAroundName
		{
			get
			{
				if (byte.MaxValue == mParensAroundName)
				{
					if (((ParenthesizePropertyNameAttribute)mobjPropertyInfo.Attributes[typeof(ParenthesizePropertyNameAttribute)]).NeedParenthesis)
					{
						mParensAroundName = 1;
					}
					else
					{
						mParensAroundName = 0;
					}
				}
				return mParensAroundName == 1;
			}
		}

		public override string PropertyCategory
		{
			get
			{
				string category = mobjPropertyInfo.Category;
				if (category != null && category.Length != 0)
				{
					return category;
				}
				return base.PropertyCategory;
			}
		}

		public override string PropertyDescription => mobjPropertyInfo.Description;

		public override PropertyDescriptor PropertyDescriptor => mobjPropertyInfo;

		public override string PropertyLabel
		{
			get
			{
				string text = mobjPropertyInfo.DisplayName;
				if (ParensAroundName)
				{
					text = "(" + text + ")";
				}
				return text;
			}
		}

		public override string PropertyName
		{
			get
			{
				if (mobjPropertyInfo != null)
				{
					return mobjPropertyInfo.Name;
				}
				return null;
			}
		}

		public override Type PropertyType => mobjPropertyInfo.PropertyType;

		public override object PropertyValue
		{
			get
			{
				try
				{
					object propertyValueCore = GetPropertyValueCore(GetValueOwner());
					if (mobjEexceptionConverter != null)
					{
						SetFlagsAndExceptionInfo(0, null, null);
					}
					return propertyValueCore;
				}
				catch (Exception result)
				{
					if (mobjEexceptionConverter == null)
					{
						SetFlagsAndExceptionInfo(0, new ExceptionConverter(), new ExceptionEditor());
					}
					return result;
				}
			}
			set
			{
				SetPropertyValue(GetValueOwner(), value, blnReset: false, null);
			}
		}

		private IPropertyValueUIService PropertyValueUIService
		{
			get
			{
				if (!mobjServiceChecked && mobjPropertyValueUIService == null)
				{
					mobjPropertyValueUIService = (IPropertyValueUIService)GetService(typeof(IPropertyValueUIService));
					mobjServiceChecked = true;
				}
				return mobjPropertyValueUIService;
			}
		}

		public override bool ShouldRenderReadOnly
		{
			get
			{
				if (base.ForceReadOnly || mblnForceRenderReadOnly)
				{
					return true;
				}
				if (mobjPropertyInfo.IsReadOnly && !mblnReadOnlyVerified && GetStateSet(128))
				{
					Type propertyType = PropertyType;
					if (propertyType != null && (propertyType.IsArray || propertyType.IsValueType || propertyType.IsPrimitive))
					{
						SetState(128, blnValue: false);
						SetState(256, blnValue: true);
						mblnForceRenderReadOnly = true;
					}
				}
				mblnReadOnlyVerified = true;
				if (base.ShouldRenderReadOnly && !mblnIsSerializeContentsProp && !base.NeedsCustomEditorButton)
				{
					return true;
				}
				return false;
			}
		}

		internal override TypeConverter TypeConverter
		{
			get
			{
				if (mobjEexceptionConverter != null)
				{
					return mobjEexceptionConverter;
				}
				if (base.mobjConverter == null)
				{
					base.mobjConverter = mobjPropertyInfo.Converter;
				}
				return base.TypeConverter;
			}
		}

		internal override WebUITypeEditor UITypeEditor
		{
			get
			{
				if (mobjExceptionEditor != null)
				{
					return mobjExceptionEditor;
				}
				base.mobjEditor = WebUITypeEditor.GetPropertyEditor(mobjPropertyInfo, typeof(WebUITypeEditor));
				if (base.mobjEditor != null)
				{
					return base.UITypeEditor;
				}
				return base.UITypeEditor;
			}
		}

		internal PropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, bool blnHide)
			: base(objOwnerGrid, objParentGridEntry)
		{
			mParensAroundName = byte.MaxValue;
			mblnActiveXHide = blnHide;
		}

		internal PropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, PropertyDescriptor objPropInfo, bool blnHide)
			: base(objOwnerGrid, objParentGridEntry)
		{
			mParensAroundName = byte.MaxValue;
			mblnActiveXHide = blnHide;
			Initialize(objPropInfo);
		}

		/// 
		/// Dispose recursivly
		/// Parent method must be overrided
		/// in order to preserve the member ids 
		/// of the children.
		/// </summary>
		public override void DisposeChildren()
		{
		}

		protected override void EditPropertyValue_Callback(object objValue)
		{
			base.EditPropertyValue_Callback(objValue);
			if (!IsValueEditable)
			{
				RefreshPropertiesAttribute refreshPropertiesAttribute = (RefreshPropertiesAttribute)mobjPropertyInfo.Attributes[typeof(RefreshPropertiesAttribute)];
				if (refreshPropertiesAttribute != null && !refreshPropertiesAttribute.RefreshProperties.Equals(RefreshProperties.None))
				{
					GridEntryHost.Refresh(refreshPropertiesAttribute?.Equals(RefreshPropertiesAttribute.All) ?? false);
				}
			}
		}

		/// 
		/// Get property value
		/// </summary>
		/// <param name="objTarget">The obj target.</param>
		/// </returns>
		protected object GetPropertyValueCore(object objTarget)
		{
			if (mobjPropertyInfo == null)
			{
				return null;
			}
			if (objTarget is ICustomTypeDescriptor)
			{
				objTarget = ((ICustomTypeDescriptor)objTarget).GetPropertyOwner(mobjPropertyInfo);
			}
			object propertyValue;
			try
			{
				propertyValue = OwnerGrid.GetPropertyValue(mobjPropertyInfo, objTarget);
			}
			catch
			{
				throw;
			}
			return propertyValue;
		}

		protected void Initialize(PropertyDescriptor objPropInfo)
		{
			mobjPropertyInfo = objPropInfo;
			mblnIsSerializeContentsProp = mobjPropertyInfo.SerializationVisibility == DesignerSerializationVisibility.Content;
			if (!mblnActiveXHide && IsPropertyReadOnly)
			{
				SetState(1, blnValue: false);
			}
			if (mblnIsSerializeContentsProp && TypeConverter.GetPropertiesSupported())
			{
				SetState(131072, blnValue: true);
			}
		}

		protected virtual void NotifyParentChange(GridEntry objGridEntry)
		{
			while (objGridEntry != null && objGridEntry is PropertyDescriptorGridEntry && ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo.Attributes.Contains(NotifyParentPropertyAttribute.Yes))
			{
				object valueOwner = objGridEntry.GetValueOwner();
				while (!(objGridEntry is PropertyDescriptorGridEntry) || valueOwner == objGridEntry.GetValueOwner())
				{
					objGridEntry = objGridEntry.ParentGridEntry;
					if (objGridEntry == null)
					{
						break;
					}
				}
				if (objGridEntry != null)
				{
					valueOwner = objGridEntry.GetValueOwner();
					IComponentChangeService componentChangeService = ComponentChangeService;
					if (componentChangeService != null)
					{
						componentChangeService.OnComponentChanging(valueOwner, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo);
						componentChangeService.OnComponentChanged(valueOwner, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo, null, null);
					}
					objGridEntry.ClearCachedValues(blnClearChildren: false);
				}
			}
		}

		internal override bool NotifyValueGivenParent(object objObject, int intType)
		{
			if (objObject is ICustomTypeDescriptor)
			{
				objObject = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(mobjPropertyInfo);
			}
			switch (intType)
			{
			case 1:
				SetPropertyValue(objObject, null, blnReset: true, SR.GetString("PropertyGridResetValue", PropertyName));
				if (marrPropertyValueUIItems != null)
				{
					for (int i = 0; i < marrPropertyValueUIItems.Length; i++)
					{
						marrPropertyValueUIItems[i].Reset();
					}
				}
				marrPropertyValueUIItems = null;
				return false;
			case 2:
				try
				{
					return mobjPropertyInfo.CanResetValue(objObject) || (marrPropertyValueUIItems != null && marrPropertyValueUIItems.Length != 0);
				}
				catch
				{
					if (mobjEexceptionConverter == null)
					{
						Flags = 0;
						mobjEexceptionConverter = new ExceptionConverter();
					}
					return false;
				}
			case 3:
			case 5:
				if (mobjEventBindings == null)
				{
					mobjEventBindings = (IEventBindingService)GetService(typeof(IEventBindingService));
				}
				if (mobjEventBindings != null && mobjEventBindings.GetEvent(mobjPropertyInfo) != null)
				{
					return ViewEvent(objObject, null, null, blnAlwaysNavigate: true);
				}
				return false;
			case 4:
				try
				{
					return mobjPropertyInfo.ShouldSerializeValue(objObject);
				}
				catch
				{
					if (mobjEexceptionConverter == null)
					{
						Flags = 0;
						mobjEexceptionConverter = new ExceptionConverter();
					}
					return false;
				}
			default:
				return false;
			}
		}

		public override void OnComponentChanged()
		{
			base.OnComponentChanged();
			NotifyParentChange(this);
		}

		private void SetFlagsAndExceptionInfo(int intFlags, ExceptionConverter objConverter, ExceptionEditor objEditor)
		{
			Flags = intFlags;
			mobjEexceptionConverter = objConverter;
		}

		/// 
		/// Sets the property value.
		/// </summary>
		/// <param name="objObect">The obj obect.</param>
		/// <param name="objValue">The obj value.</param>
		/// <param name="blnReset">if set to true</c> [BLN reset].</param>
		/// <param name="strUndoText">The STR undo text.</param>
		/// </returns>
		private object SetPropertyValue(object objObect, object objValue, bool blnReset, string strUndoText)
		{
			DesignerTransaction designerTransaction = null;
			try
			{
				object propertyValueCore = GetPropertyValueCore(objObect);
				if (objValue != null && objValue.Equals(propertyValueCore))
				{
					return objValue;
				}
				ClearCachedValues();
				IDesignerHost designerHost = DesignerHost;
				if (designerHost != null)
				{
					string description = ((strUndoText == null) ? SR.GetString("PropertyGridSetValue", mobjPropertyInfo.Name) : strUndoText);
					designerTransaction = designerHost.CreateTransaction(description);
				}
				bool flag = !(objObect is IComponent) || ((IComponent)objObect).Site == null;
				if (flag)
				{
					try
					{
						if (ComponentChangeService != null)
						{
							ComponentChangeService.OnComponentChanging(objObect, mobjPropertyInfo);
						}
					}
					catch (CheckoutException ex)
					{
						if (ex != CheckoutException.Canceled)
						{
							throw ex;
						}
						return propertyValueCore;
					}
				}
				bool internalExpanded = InternalExpanded;
				int intOldCount = -1;
				if (internalExpanded)
				{
					intOldCount = base.ChildCount;
				}
				RefreshPropertiesAttribute refreshPropertiesAttribute = (RefreshPropertiesAttribute)mobjPropertyInfo.Attributes[typeof(RefreshPropertiesAttribute)];
				bool flag2 = internalExpanded || (refreshPropertiesAttribute != null && !refreshPropertiesAttribute.RefreshProperties.Equals(RefreshProperties.None));
				if (flag2)
				{
					DisposeChildren();
				}
				EventDescriptor eventDescriptor = null;
				if (objObect != null && objValue is string)
				{
					if (mobjEventBindings == null)
					{
						mobjEventBindings = (IEventBindingService)GetService(typeof(IEventBindingService));
					}
					if (mobjEventBindings != null)
					{
						eventDescriptor = mobjEventBindings.GetEvent(mobjPropertyInfo);
					}
					if (eventDescriptor == null)
					{
						object component = objObect;
						if (mobjPropertyInfo is MergePropertyDescriptor && objObect is Array)
						{
							Array array = objObect as Array;
							if (array.Length > 0)
							{
								component = array.GetValue(0);
							}
						}
						eventDescriptor = TypeDescriptor.GetEvents(component)[mobjPropertyInfo.Name];
					}
				}
				bool flag3 = false;
				try
				{
					if (blnReset)
					{
						mobjPropertyInfo.ResetValue(objObect);
					}
					else if (eventDescriptor != null)
					{
						ViewEvent(objObect, (string)objValue, eventDescriptor, blnAlwaysNavigate: false);
					}
					else
					{
						SetPropertyValueCore(objObect, objValue, blnDoUndo: true);
					}
					flag3 = true;
					if (flag && ComponentChangeService != null)
					{
						ComponentChangeService.OnComponentChanged(objObect, mobjPropertyInfo, null, objValue);
					}
					NotifyParentChange(this);
					return objObect;
				}
				finally
				{
					if (flag2 && GridEntryHost != null)
					{
						RecreateChildren(intOldCount);
						if (flag3)
						{
							GridEntryHost.Refresh(refreshPropertiesAttribute?.Equals(RefreshPropertiesAttribute.All) ?? false);
						}
					}
				}
			}
			catch (CheckoutException ex2)
			{
				if (designerTransaction != null)
				{
					designerTransaction.Cancel();
					designerTransaction = null;
				}
				if (ex2 != CheckoutException.Canceled)
				{
					throw;
				}
				return null;
			}
			catch
			{
				if (designerTransaction != null)
				{
					designerTransaction.Cancel();
					designerTransaction = null;
				}
				throw;
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}

		private void SetPropertyValueCore(object objObject, object objValue, bool blnDoUndo)
		{
			if (mobjPropertyInfo == null)
			{
				return;
			}
			object obj = objObject;
			if (obj is ICustomTypeDescriptor)
			{
				obj = ((ICustomTypeDescriptor)obj).GetPropertyOwner(mobjPropertyInfo);
			}
			bool flag = false;
			if (ParentGridEntry != null)
			{
				Type propertyType = ParentGridEntry.PropertyType;
				flag = propertyType.IsValueType || propertyType.IsArray;
			}
			if (obj == null)
			{
				return;
			}
			OwnerGrid.SetPropertyValue(mobjPropertyInfo, obj, objValue);
			if (flag)
			{
				GridEntry parentGridEntry = ParentGridEntry;
				if (parentGridEntry != null && parentGridEntry.IsValueEditable)
				{
					parentGridEntry.PropertyValue = objObject;
				}
			}
		}

		protected bool ViewEvent(object objObject, string strNewHandler, EventDescriptor objEventdesc, bool blnAlwaysNavigate)
		{
			object propertyValueCore = GetPropertyValueCore(objObject);
			string text = propertyValueCore as string;
			if (text == null && propertyValueCore != null && TypeConverter != null && TypeConverter.CanConvertTo(typeof(string)))
			{
				text = TypeConverter.ConvertToString(propertyValueCore);
			}
			if (strNewHandler == null && !CommonUtils.IsNullOrEmpty(text))
			{
				strNewHandler = text;
			}
			else if (text == strNewHandler && !CommonUtils.IsNullOrEmpty(strNewHandler))
			{
				return true;
			}
			IComponent component = objObject as IComponent;
			if (component == null && mobjPropertyInfo is MergePropertyDescriptor && objObject is Array { Length: >0 } array)
			{
				component = array.GetValue(0) as IComponent;
			}
			if (component == null)
			{
				return false;
			}
			if (mobjPropertyInfo.IsReadOnly)
			{
				return false;
			}
			if (objEventdesc == null)
			{
				if (mobjEventBindings == null)
				{
					mobjEventBindings = (IEventBindingService)GetService(typeof(IEventBindingService));
				}
				if (mobjEventBindings != null)
				{
					objEventdesc = mobjEventBindings.GetEvent(mobjPropertyInfo);
				}
			}
			IDesignerHost designerHost = DesignerHost;
			DesignerTransaction designerTransaction = null;
			try
			{
				if (objEventdesc.EventType == null)
				{
					return false;
				}
				if (designerHost != null)
				{
					string text2 = ((component.Site != null) ? component.Site.Name : component.GetType().Name);
					designerTransaction = DesignerHost.CreateTransaction(SR.GetString("WindowsFormsSetEvent", text2 + "." + PropertyName));
				}
				if (mobjEventBindings == null)
				{
					ISite site = component.Site;
					if (site != null)
					{
						mobjEventBindings = (IEventBindingService)site.GetService(typeof(IEventBindingService));
					}
				}
				if (strNewHandler == null && mobjEventBindings != null)
				{
					strNewHandler = mobjEventBindings.CreateUniqueMethodName(component, objEventdesc);
				}
				if (strNewHandler != null)
				{
					if (mobjEventBindings != null)
					{
						bool flag = false;
						foreach (string compatibleMethod in mobjEventBindings.GetCompatibleMethods(objEventdesc))
						{
							if (strNewHandler == compatibleMethod)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							blnAlwaysNavigate = true;
						}
					}
					mobjPropertyInfo.SetValue(objObject, strNewHandler);
				}
				if (blnAlwaysNavigate && mobjEventBindings != null)
				{
					mobjTargetBindingService = mobjEventBindings;
					mobjTargetComponent = component;
					mobjTargetEventDescriptor = objEventdesc;
				}
			}
			catch
			{
				if (designerTransaction != null)
				{
					designerTransaction.Cancel();
					designerTransaction = null;
				}
				throw;
			}
			finally
			{
				designerTransaction?.Commit();
			}
			return true;
		}
	}
}
