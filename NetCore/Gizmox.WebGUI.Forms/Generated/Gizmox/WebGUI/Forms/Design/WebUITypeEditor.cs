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

namespace Gizmox.WebGUI.Forms.Design
{
/// 
	/// Provides a base class that can be used to design value editors that 
	/// can provide a web user interface (Web UI) for representing and editing the 
	/// values of objects of the supported data types.
	/// </summary>
	[Serializable]
	public class WebUITypeEditor
	{
		private GridEntry mobjGridEntryOwner = null;

		/// Gets a value indicating whether drop-down editors should be resizable by the user.</summary>
		/// true if drop-down editors are resizable; otherwise, false. </returns>
		public virtual bool IsDropDownResizable => false;

		/// Gets a value indicating whether this editor value should support text editing.</summary>
		/// true if editor value should support text editing; otherwise, false. </returns>
		public virtual bool IsTextEditable => true;

		static WebUITypeEditor()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> class.</summary>
		public WebUITypeEditor()
		{
		}

		/// 
		/// Edits the value of the specified object using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="objValue">The object to edit.</param>
		/// <param name="objHandler">The obj handler.</param>
		public void EditValue(IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			EditValue(null, objProvider, objValue, objHandler);
		}

		/// 
		/// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="objValue">The object to edit.</param>
		/// <param name="objHandler">The obj handler.</param>
		public virtual void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			mobjGridEntryOwner = objContext as GridEntry;
		}

		/// 
		/// Raise error on value change
		/// </summary>
		/// <param name="objException"></param>
		protected void OnValueChangeError(Exception objException)
		{
			if (mobjGridEntryOwner != null)
			{
				mobjGridEntryOwner.OnValueChangeError(objException);
			}
		}

		/// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
		/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value that indicates the style of editor used by the current <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. By default, this method will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
		public UITypeEditorEditStyle GetEditStyle()
		{
			return GetEditStyle(null);
		}

		/// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
		/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
		public virtual UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
		{
			return UITypeEditorEditStyle.None;
		}

		/// 
		/// Gets the ditor value from the property value
		/// </summary>
		/// <param name="value"></param>
		/// </returns>
		internal object GetEditorValueFromPropertyValueInternal(object objValue)
		{
			return GetEditorValueFromPropertyValue(objValue);
		}

		/// 
		/// Validated property value
		/// </summary>
		/// <param name="value"></param>
		internal void ValidatePropertyValueInternal(object objValue)
		{
			ValidatePropertyValue(objValue);
		}

		/// 
		/// Validated property value
		/// </summary>
		/// <param name="value"></param>
		protected virtual void ValidatePropertyValue(object objValue)
		{
		}

		/// 
		/// Supplies a editor level mechanism to convert property values before editing
		/// </summary>
		/// <param name="value">The property value.</param>
		/// </returns>
		protected virtual object GetEditorValueFromPropertyValue(object objValue)
		{
			return objValue;
		}

		/// 
		/// Supplies a editor level mechanism to convert editor returned values before assigning to property
		/// </summary>
		/// <param name="value">The editor returned value.</param>
		/// </returns>
		protected virtual object GetPropertyValueFromEditorValue(object objValue)
		{
			return objValue;
		}

		/// 
		/// Gets an editor with the WebUITypeEditor base type for the specified component. 
		/// </summary>
		/// <param name="objComponent">The component to get the editor for. </param>
		/// </returns>
		public static WebUITypeEditor GetEditor(object objComponent)
		{
			if (objComponent != null)
			{
				return GetEditor(objComponent.GetType(), typeof(WebUITypeEditor));
			}
			return null;
		}

		/// 
		/// Gets an editor with the specified base type for the specified component. 
		/// </summary>
		/// <param name="objComponent">The component to get the editor for. </param>
		/// <param name="objBaseType">A Type that represents the base type of the editor you want to find.</param>
		/// </returns>
		public static WebUITypeEditor GetEditor(object objComponent, Type objBaseType)
		{
			if (objComponent != null)
			{
				return GetEditor(objComponent.GetType(), objBaseType);
			}
			return null;
		}

		/// 
		/// Returns an editor with the WebUITypeEditor base type for the specified type. 
		/// </summary>
		/// <param name="objType">The Type of the target component.</param>
		/// </returns>
		public static WebUITypeEditor GetEditor(Type objType)
		{
			return GetEditor(objType, typeof(WebUITypeEditor));
		}

		/// 
		/// Gets an editor from the property attributes
		/// </summary>
		/// <param name="objPropertyInfo"></param>
		/// </returns>
		public static WebUITypeEditor GetPropertyEditor(PropertyDescriptor objPropertyInfo)
		{
			return GetPropertyEditor(objPropertyInfo, typeof(WebUITypeEditor));
		}

		/// 
		/// Gets a typed inherited editor from property attributes
		/// </summary>
		/// <param name="objPropertyInfo"></param>
		/// <param name="objBaseType"></param>
		/// </returns>
		public static WebUITypeEditor GetPropertyEditor(PropertyDescriptor objPropertyInfo, Type objBaseType)
		{
			foreach (Attribute attribute in objPropertyInfo.Attributes)
			{
				if (!(attribute is WebEditorAttribute webEditorAttribute))
				{
					continue;
				}
				Type type = Type.GetType(webEditorAttribute.EditorTypeName, throwOnError: false, ignoreCase: true);
				if (!(type != null))
				{
					continue;
				}
				WebUITypeEditor webUITypeEditor = null;
				bool flag = false;
				try
				{
					ConstructorInfo[] constructors = type.GetConstructors(~BindingFlags.Static);
					ConstructorInfo[] array = constructors;
					foreach (ConstructorInfo constructorInfo in array)
					{
						if (constructorInfo.GetParameters().Length == 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						webUITypeEditor = Activator.CreateInstance(type) as WebUITypeEditor;
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (webUITypeEditor == null)
					{
						webUITypeEditor = Activator.CreateInstance(type, objPropertyInfo.PropertyType) as WebUITypeEditor;
					}
				}
				catch (Exception)
				{
				}
				if (webUITypeEditor != null)
				{
					return webUITypeEditor;
				}
			}
			return null;
		}

		/// 
		/// Returns an editor with the specified base type for the specified type. 
		/// </summary>
		/// <param name="objType">The Type of the target component.</param>
		/// <param name="objBaseType">A Type that represents the base type of the editor you are trying to find.</param>
		/// </returns>
		public static WebUITypeEditor GetEditor(Type objType, Type objBaseType)
		{
			System.ComponentModel.AttributeCollection attributes = TypeDescriptor.GetAttributes(objType);
			foreach (Attribute item in attributes)
			{
				if (!(item is WebEditorAttribute webEditorAttribute))
				{
					continue;
				}
				Type type = Type.GetType(webEditorAttribute.EditorTypeName, throwOnError: false, ignoreCase: true);
				if (!(type != null))
				{
					continue;
				}
				WebUITypeEditor webUITypeEditor = null;
				try
				{
					webUITypeEditor = Activator.CreateInstance(type) as WebUITypeEditor;
				}
				catch (Exception)
				{
					try
					{
						webUITypeEditor = Activator.CreateInstance(type, objType) as WebUITypeEditor;
					}
					catch (Exception)
					{
						webUITypeEditor = null;
					}
				}
				if (webUITypeEditor != null)
				{
					return webUITypeEditor;
				}
			}
			if (objType == typeof(Font))
			{
				return new FontEditor();
			}
			if (objType == typeof(Color))
			{
				return new ColorEditor();
			}
			if (objType == typeof(DateTime))
			{
				return new DateTimeEditor();
			}
			if (objType == typeof(DockStyle))
			{
				return new DockEditor();
			}
			if (objType == typeof(Keys))
			{
				return new ShortcutKeysEditor();
			}
			if (objType == typeof(AnchorStyles))
			{
				return new AnchorEditor();
			}
			if (objType.GetInterface("IList") != null)
			{
				return new CollectionEditor(objType);
			}
			if (objType.GetInterface("ICollection") != null)
			{
				return new CollectionEditor(objType);
			}
			if (CommonUtils.IsTypeOrSubType(objType, typeof(ResourceHandle)))
			{
				return new ResourceHandleEditor();
			}
			return null;
		}
	}
}
