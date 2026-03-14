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

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Represents a small rectangular pop-up window that displays a brief description of a control's purpose when the user rests the pointer on the control.
	/// </summary>
	[Serializable]
	[ProvideProperty("ToolTip", typeof(Control))]
	[SRDescription("DescriptionToolTip")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ToolTip), "ToolTip_45.bmp")]
	[TypeDescriptionProvider(typeof(ToolTipTypeDescriptionProvider))]
	[Skin(typeof(ToolTipSkin))]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	public class ToolTip : ComponentBase, IExtenderProvider, ISkinable
	{
		/// 
		///
		/// </summary>
		private class ToolTipTypeDescriptionProvider : TypeDescriptionProvider
		{
			/// 
			///
			/// </summary>
			private class ToolTipTypeDelegator : TypeDelegator
			{
				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip.ToolTipTypeDescriptionProvider.ToolTipTypeDelegator" /> class.
				/// </summary>
				/// <param name="objDelegatingType">Type of the obj delegating.</param>
				public ToolTipTypeDelegator(Type objDelegatingType)
					: base(objDelegatingType)
				{
				}

				/// 
				/// Gets the attributes assigned to the TypeDelegator.
				/// </summary>
				/// 
				/// A TypeAttributes object representing the implementation attribute flags.
				/// </returns>
				protected override TypeAttributes GetAttributeFlagsImpl()
				{
					return base.GetAttributeFlagsImpl() & ~TypeAttributes.Serializable;
				}
			}

			/// 
			///  Static that holds a default type provider of a component base.
			/// </summary>
			private static TypeDescriptionProvider mobjDefaultTypeProvider = TypeDescriptor.GetProvider(typeof(ComponentBase));

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip.ToolTipTypeDescriptionProvider" /> class.
			/// </summary>
			public ToolTipTypeDescriptionProvider()
				: base(mobjDefaultTypeProvider)
			{
			}

			/// 
			/// Gets the type of the reflection.
			/// </summary>
			/// <param name="objObjectType">Type of the obj object.</param>
			/// <param name="objInstance">The obj instance.</param>
			/// </returns>
			public override Type GetReflectionType(Type objObjectType, object objInstance)
			{
				if (objInstance is ComponentBase { Site: not null } componentBase && componentBase.Site.DesignMode)
				{
					return new ToolTipTypeDelegator(objObjectType);
				}
				return base.GetReflectionType(objObjectType, objInstance);
			}
		}

		/// 
		/// The Active property registration.
		/// </summary>
		private static SerializableProperty ActiveProperty = SerializableProperty.Register("Active", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

		/// 
		/// The IsBalloon property registration.
		/// </summary>
		private static SerializableProperty IsBalloonProperty = SerializableProperty.Register("IsBalloon", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

		/// 
		/// The AutoPopDelay property registration.
		/// </summary>
		private static SerializableProperty AutoPopDelayProperty = SerializableProperty.Register("AutoPopDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(5000));

		/// 
		/// The InitialDelay property registration.
		/// </summary>
		private static SerializableProperty InitialDelayProperty = SerializableProperty.Register("InitialDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(0));

		/// 
		/// The ReshowDelay property registration.
		/// </summary>
		private static SerializableProperty ReshowDelayProperty = SerializableProperty.Register("ReshowDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(0));

		/// 
		/// The ToolTipTitle property registration.
		/// </summary>
		private static SerializableProperty ToolTipTitleProperty = SerializableProperty.Register("ToolTipTitle", typeof(string), typeof(ToolTip), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// The ToolTipIcon property registration.
		/// </summary>
		private static SerializableProperty ToolTipIconProperty = SerializableProperty.Register("ToolTipIcon", typeof(ToolTipIcon), typeof(ToolTip), new SerializablePropertyMetadata(ToolTipIcon.None));

		/// 
		/// The AutomaticDelay property registration.
		/// </summary>
		private static SerializableProperty AutomaticDelayProperty = SerializableProperty.Register("AutomaticDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(500));

		/// 
		/// The ShowAlways property registration.
		/// </summary>
		private static SerializableProperty ShowAlwaysProperty = SerializableProperty.Register("ShowAlways", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolTip" /> is active.
		/// </summary>
		/// 
		///   true</c> if active; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Active
		{
			get
			{
				return GetValue(ActiveProperty);
			}
			set
			{
				SetValue(ActiveProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is balloon.
		/// </summary>
		/// 
		/// 	true</c> if this instance is balloon; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		[SRDescription("ToolTipIsBalloonDescr")]
		public bool IsBalloon
		{
			get
			{
				return GetValue(IsBalloonProperty);
			}
			set
			{
				SetValue(IsBalloonProperty, value);
			}
		}

		/// 
		/// Gets or sets the period of time the ToolTip remains visible if the pointer is stationary on a control with specified ToolTip text
		/// </summary>
		/// 
		/// The period of time, in milliseconds, that the ToolTip remains visible when the pointer is stationary on a control. The default value is 5000.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("ToolTipAutoPopDelayDescr")]
		public int AutoPopDelay
		{
			get
			{
				return GetValue(AutoPopDelayProperty);
			}
			set
			{
				SetValue(AutoPopDelayProperty, value);
			}
		}

		/// 
		/// Gets or sets the time that passes before the ToolTip appears.
		/// </summary>
		/// 
		/// The period of time, in milliseconds, that the pointer must remain stationary on a control before the ToolTip window is displayed.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ToolTipInitialDelayDescr")]
		[RefreshProperties(RefreshProperties.All)]
		public int InitialDelay
		{
			get
			{
				return GetValue(InitialDelayProperty);
			}
			set
			{
				SetValue(InitialDelayProperty, value);
			}
		}

		/// 
		/// Gets or sets the length of time that must transpire before subsequent ToolTip windows appear as the pointer moves from one control to another.
		/// </summary>
		/// 
		/// The length of time, in milliseconds, that it takes subsequent ToolTip windows to appear.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ToolTipReshowDelayDescr")]
		[RefreshProperties(RefreshProperties.All)]
		public int ReshowDelay
		{
			get
			{
				return GetValue(ReshowDelayProperty);
			}
			set
			{
				SetValue(ReshowDelayProperty, value);
			}
		}

		/// 
		/// Gets or sets a title for the ToolTip window.
		/// </summary>
		/// 
		/// A String containing the window title.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue("")]
		[SRDescription("ToolTipTitleDescr")]
		public string ToolTipTitle
		{
			get
			{
				return GetValue(ToolTipTitleProperty);
			}
			set
			{
				SetValue(ToolTipTitleProperty, value);
			}
		}

		/// 
		///             Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text.
		/// </summary>
		/// 
		/// One of the Gizmox.WebGUI.Forms.ToolTipIcon enumerated values.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(0)]
		[SRDescription("ToolTipToolTipIconDescr")]
		public ToolTipIcon ToolTipIcon
		{
			get
			{
				return GetValue(ToolTipIconProperty);
			}
			set
			{
				SetValue(ToolTipIconProperty, value);
			}
		}

		/// 
		/// Gets or sets the automatic delay for the ToolTip.
		/// </summary>
		/// 
		/// The automatic delay, in milliseconds. The default is 500.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("ToolTipAutomaticDelayDescr")]
		[DefaultValue(500)]
		public int AutomaticDelay
		{
			get
			{
				return GetValue(AutomaticDelayProperty);
			}
			set
			{
				SetValue(AutomaticDelayProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether a ToolTip window is displayed, even when its parent control is not active.
		/// </summary>
		/// 
		///   true if the ToolTip is always displayed; otherwise, false. The default is false.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ToolTipShowAlwaysDescr")]
		[DefaultValue(false)]
		public bool ShowAlways
		{
			get
			{
				return GetValue(ShowAlwaysProperty);
			}
			set
			{
				SetValue(ShowAlwaysProperty, value);
			}
		}

		string ISkinable.Theme => VWGContext.Current.CurrentTheme;

		/// 
		/// Gets the tool tip key. Identifies tooltip on client.
		/// </summary>
		protected virtual string ToolTipKey => string.Empty;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> without a specified container.
		/// </summary>
		public ToolTip()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> class with a specified container.
		/// </summary>
		/// <param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see>. </param>
		public ToolTip(IContainer objContainer)
		{
			objContainer.Add(this);
		}

		/// 
		/// Associates ToolTip text with the specified control.
		/// </summary>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to associate the ToolTip text with. </param>
		/// <param name="strCaption">The ToolTip text to display when the pointer is on the control. </param>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetToolTip(Control objControl, string strCaption)
		{
			if (objControl != null)
			{
				objControl.ToolTip = strCaption;
			}
		}

		/// Retrieves the ToolTip text associated with the specified control.</summary>
		/// A <see cref="T:System.String"></see> containing the ToolTip text for the specified control.</returns>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text. </param>
		/// 1</filterpriority>
		[DefaultValue("")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Localizable(true)]
		[SRDescription("ToolTipToolTipDescr")]
		public string GetToolTip(Control objControl)
		{
			return (objControl != null) ? objControl.ToolTip : "";
		}

		/// 
		/// Returns true if the ToolTip can offer an extender property to the specified target component.
		/// </summary>
		/// <param name="objTarget">The target.</param>
		/// 
		/// 	true</c> if this instance can extend the specified target; otherwise, false</c>.
		/// </returns>
		public bool CanExtend(object objTarget)
		{
			return objTarget is Control && !(objTarget is ToolTip);
		}

		/// 
		/// Gets the name of the extended tool tip template.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// </returns>
		protected string GetExtendedToolTipTemplateName(Control objControl)
		{
			if (objControl != null)
			{
				string toolTipKey = ToolTipKey;
				ToolTipDescriptor extendedToolTipDescriptor = objControl.ExtendedToolTipDescriptor;
				if (extendedToolTipDescriptor != null && extendedToolTipDescriptor.ToolTipKey == toolTipKey)
				{
					return extendedToolTipDescriptor.ToolTipTemplateName;
				}
			}
			return string.Empty;
		}

		/// 
		/// Sets the name of the extended tool tip template.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="strValue">The STR value.</param>
		protected void SetExtendedToolTipTemplateName(Control objControl, string strValue)
		{
			if (objControl != null)
			{
				string toolTipKey = ToolTipKey;
				ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor;
				if (toolTipDescriptor == null)
				{
					toolTipDescriptor = new ToolTipDescriptor(toolTipKey);
				}
				Dictionary<string, string> extendedProperties = toolTipDescriptor.ExtendedProperties;
				if (toolTipDescriptor.ToolTipKey != toolTipKey)
				{
					extendedProperties.Clear();
					toolTipDescriptor.ToolTipKey = toolTipKey;
				}
				toolTipDescriptor.ToolTipTemplateName = strValue;
				objControl.ExtendedToolTipDescriptor = toolTipDescriptor;
				objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
			}
		}

		/// 
		/// Gets the extended tool tip property.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// </returns>
		protected string GetExtendedToolTipProperty(Control objControl, string strPropertyName)
		{
			if (objControl != null)
			{
				string toolTipKey = ToolTipKey;
				ToolTipDescriptor extendedToolTipDescriptor = objControl.ExtendedToolTipDescriptor;
				if (extendedToolTipDescriptor != null && extendedToolTipDescriptor.ToolTipKey == toolTipKey)
				{
					Dictionary<string, string> extendedProperties = extendedToolTipDescriptor.ExtendedProperties;
					if (extendedProperties.ContainsKey(strPropertyName))
					{
						return extendedProperties[strPropertyName];
					}
				}
			}
			return string.Empty;
		}

		/// 
		/// Sets the extended tool tip property.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="strPropertyName">The STR key.</param>
		/// <param name="strValue">The STR value.</param>
		protected void SetExtendedToolTipProperty(Control objControl, string strPropertyName, string strValue)
		{
			if (objControl != null)
			{
				string toolTipKey = ToolTipKey;
				ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor;
				if (toolTipDescriptor == null)
				{
					toolTipDescriptor = new ToolTipDescriptor(toolTipKey);
				}
				Dictionary<string, string> extendedProperties = toolTipDescriptor.ExtendedProperties;
				if (toolTipDescriptor.ToolTipKey != toolTipKey)
				{
					extendedProperties.Clear();
					toolTipDescriptor.ToolTipKey = toolTipKey;
				}
				if (extendedProperties.ContainsKey(strPropertyName))
				{
					extendedProperties[strPropertyName] = strValue;
				}
				else
				{
					extendedProperties.Add(strPropertyName, strValue);
				}
				objControl.ExtendedToolTipDescriptor = toolTipDescriptor;
				objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
			}
		}
	}
}
