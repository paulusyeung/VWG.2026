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

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
/// 
	/// Summary description for ContextualToolbar
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[Skin(typeof(ContextualToolbarSkin))]
	internal class ContextualToolbar : Form, IServiceProvider, IWebUIEditorService
	{
		/// 
		/// Will contain information about a button data
		/// </summary>
		[Serializable]
		protected class ContextualToolbarButton : RegisteredComponent
		{
			private ContextualToolbar mobjOwnerContextualToolbar = null;

			private string mstrPropertyName;

			private ImageResourceReference mobjButtonImageResourceReference;

			private string mstrTooltip;

			/// 
			/// Gets the current application context.
			/// </summary>
			public override IContext Context
			{
				get
				{
					if (mobjOwnerContextualToolbar != null)
					{
						return mobjOwnerContextualToolbar.Context;
					}
					return VWGContext.Current;
				}
			}

			/// 
			/// Gets or sets the owner contextual toolbar.
			/// </summary>
			/// 
			/// The owner contextual toolbar.
			/// </value>
			public ContextualToolbar Owner
			{
				get
				{
					return mobjOwnerContextualToolbar;
				}
				set
				{
					mobjOwnerContextualToolbar = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton" /> class.
			/// </summary>
			/// <param name="strPropertyName">Name of the string property.</param>
			/// <param name="strCssClassName">Name of the string CSS class.</param>
			/// <param name="objButtonImageResourceReference">The object button image resource reference.</param>
			/// <param name="strTooltip">The string tooltip.</param>
			public ContextualToolbarButton(string strPropertyName, ImageResourceReference objButtonImageResourceReference, string strTooltip)
			{
				mstrPropertyName = strPropertyName;
				mobjButtonImageResourceReference = objButtonImageResourceReference;
				mstrTooltip = strTooltip;
			}

			/// 
			/// Renders the contextualtoolbar.
			/// </summary>
			/// <param name="objContext">The object context.</param>
			/// <param name="objWriter">The object writer.</param>
			/// <param name="lngRequestID">The LNG request identifier.</param>
			protected internal virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
			{
				objWriter.WriteStartElement(WGConst.ControlsPrefix, "CTBB", WGConst.ControlsNamespace);
				RenderAttributes(objContext, (IAttributeWriter)objWriter);
				objWriter.WriteEndElement();
			}

			/// 
			/// Renders the attributes.
			/// </summary>
			/// <param name="objContext">The object context.</param>
			/// <param name="attributeWriter">The attribute writer.</param>
			protected virtual void RenderAttributes(IContext objContext, IAttributeWriter attributeWriter)
			{
				if (!string.IsNullOrEmpty(mstrPropertyName))
				{
					attributeWriter.WriteAttributeString("N", mstrPropertyName);
				}
				if (mobjButtonImageResourceReference != null)
				{
					attributeWriter.WriteAttributeString("IM", mobjButtonImageResourceReference.GetValue(objContext));
				}
				if (!string.IsNullOrEmpty(mstrTooltip))
				{
					attributeWriter.WriteAttributeString("TT", mstrTooltip);
				}
			}
		}

		/// 
		/// The context of the contextual tool bar to be passed to editors.
		/// </summary>
		[Serializable]
		internal class ContextualToolbarContext : ITypeDescriptorContext, IServiceProvider
		{
			private Component mobjComponent;

			/// 
			/// Gets the container representing this <see cref="T:System.ComponentModel.TypeDescriptor" /> request.
			/// </summary>
			/// An <see cref="T:System.ComponentModel.IContainer" /> with the set of objects for this <see cref="T:System.ComponentModel.TypeDescriptor" />; otherwise, null if there is no container or if the <see cref="T:System.ComponentModel.TypeDescriptor" /> does not use outside objects.</returns>
			public IContainer Container => null;

			public object Instance => mobjComponent;

			public PropertyDescriptor PropertyDescriptor => null;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarContext" /> class.
			/// </summary>
			/// <param name="objComponent">The object component.</param>
			public ContextualToolbarContext(Component objComponent)
			{
				mobjComponent = objComponent;
			}

			public void OnComponentChanged()
			{
			}

			public bool OnComponentChanging()
			{
				return true;
			}

			public object GetService(Type serviceType)
			{
				return null;
			}
		}

		private PropertyInfo mobjControlProperty = null;

		private Component mobjComponent = null;

		private Point mobjEditorDialogLocation = Point.Empty;

		private ContextualToolbarPropertyValueChangedEventHandler mobjCustomPropertyValueChangeEvent = null;

		private List<object> mobjListOfButtons = new List<object>();

		/// 
		/// Gets or sets a value indicating whether [activate on pre render].
		/// </summary>
		/// 
		/// 	true</c> if [activate on pre render]; otherwise, false</c>.
		/// </value>
		protected override bool ActivateOnShow
		{
			get
			{
				return false;
			}
			set
			{
				base.ActivateOnShow = value;
			}
		}

		/// 
		/// Gets or sets the control property.
		/// </summary>
		/// 
		/// The control property.
		/// </value>
		private PropertyInfo ControlProperty
		{
			get
			{
				return mobjControlProperty;
			}
			set
			{
				mobjControlProperty = value;
			}
		}

		/// 
		/// Gets or sets the component.
		/// </summary>
		/// 
		/// The component.
		/// </value>
		private Component Component
		{
			get
			{
				return mobjComponent;
			}
			set
			{
				mobjComponent = value;
			}
		}

		/// 
		/// Gets or sets the editor dialog location.
		/// </summary>
		/// 
		/// The editor dialog location.
		/// </value>
		private Point EditorDialogLocation
		{
			get
			{
				return mobjEditorDialogLocation;
			}
			set
			{
				mobjEditorDialogLocation = value;
			}
		}

		/// 
		/// Gets or sets the custom property value change event.
		/// </summary>
		/// 
		/// The custom property value change event.
		/// </value>
		private ContextualToolbarPropertyValueChangedEventHandler CustomPropertyValueChangeEvent
		{
			get
			{
				return mobjCustomPropertyValueChangeEvent;
			}
			set
			{
				mobjCustomPropertyValueChangeEvent = value;
			}
		}

		/// 
		/// Gets the current.
		/// </summary>
		/// 
		/// The current.
		/// </value>
		private static ContextualToolbar CurrentContextualToolbar
		{
			get
			{
				if (VWGContext.Current is IContextParams contextParams)
				{
					if (contextParams.ContextualToolbar == null)
					{
						contextParams.ContextualToolbar = new ContextualToolbar();
					}
					return contextParams.ContextualToolbar as ContextualToolbar;
				}
				return null;
			}
			set
			{
				if (VWGContext.Current is IContextParams contextParams)
				{
					contextParams.ContextualToolbar = value;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar" /> class.
		/// </summary>
		public ContextualToolbar()
		{
			CustomStyle = "ContextualToolbar";
			InitContextualToolbarButtons();
		}

		/// 
		/// Initializes the base buttons buttons.
		/// </summary>
		protected virtual void InitContextualToolbarButtons()
		{
			ContextualToolbarSkin contextualToolbarSkin = base.Skin as ContextualToolbarSkin;
			AddChild(new ContextualToolbarButton("Font", contextualToolbarSkin.ContextualToolbarFont, "Change the font type and size."));
			AddChild(new ContextualToolbarButton("ForeColor", contextualToolbarSkin.ContextualToolbarForeColor, "Change the text color."));
			AddChild(new ContextualToolbarButton("BackColor", contextualToolbarSkin.ContextualToolbarBackColor, "Change the background color."));
			AddChild(new ContextualToolbarButton("Dock", contextualToolbarSkin.ContextualToolbarDock, "Change the docking type."));
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (ContextualToolbarButton mobjListOfButton in mobjListOfButtons)
			{
				mobjListOfButton.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// catched the event fired.
		/// </summary>
		/// <param name="objEvent">event.</param>
		internal static void FireEvent(Component objComponent, IEvent objEvent)
		{
			FireEvent(objComponent, objEvent, null);
		}

		/// 
		/// catched the event fired.
		/// </summary>
		/// <param name="objEvent">event.</param>
		internal static void FireEvent(Component objComponent, IEvent objEvent, ContextualToolbarPropertyValueChangedEventHandler objCustomPropertyValueChangedEvent)
		{
			string text = objEvent["ARG"];
			string text2 = objEvent["RPS"];
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Type type = objComponent.GetType();
			PropertyInfo property = type.GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
			object value = null;
			if (objComponent is Control)
			{
				if (property != null)
				{
					value = property.GetValue(objComponent, null);
				}
			}
			else
			{
				ProxyComponent proxyComponent = objComponent as ProxyComponent;
				if (property == null && proxyComponent != null)
				{
					proxyComponent.PropertyBag.TryGetValue(text, out value);
					type = proxyComponent.SourceComponent.GetType();
					property = type.GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
					if (value == null)
					{
						value = property.GetValue(proxyComponent.SourceComponent, null);
					}
				}
				else if (property != null && proxyComponent != null)
				{
					value = property.GetValue(proxyComponent, null);
				}
			}
			if (!(property != null))
			{
				return;
			}
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objComponent);
			PropertyDescriptor objPropertyInfo = properties[property.Name];
			WebUITypeEditor webUITypeEditor = WebUITypeEditor.GetPropertyEditor(objPropertyInfo, typeof(WebUITypeEditor));
			if (webUITypeEditor == null)
			{
				webUITypeEditor = WebUITypeEditor.GetEditor(property.PropertyType);
			}
			Point editorDialogLocation = Point.Empty;
			if (!string.IsNullOrEmpty(text2))
			{
				string[] array = text2.Split(',');
				if (int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
				{
					editorDialogLocation = new Point(result, result2);
				}
			}
			ContextualToolbar contextualToolbar = new ContextualToolbar();
			contextualToolbar.ControlProperty = property;
			contextualToolbar.Component = objComponent;
			contextualToolbar.EditorDialogLocation = editorDialogLocation;
			contextualToolbar.CustomPropertyValueChangeEvent = objCustomPropertyValueChangedEvent;
			webUITypeEditor.EditValue(new ContextualToolbarContext(objComponent), contextualToolbar, value, contextualToolbar.EditPropertyValue_Callback);
		}

		/// 
		/// Shows the contextual toolbar.
		/// </summary>
		/// <param name="proxyControl">The proxy control.</param>
		/// <param name="objOnEditorWindowOpen">The object on editor window open.</param>
		/// <param name="objOnEditorWindowClosed">The object on editor window closed.</param>
		internal static void ShowContextualToolbar(Component objComponent, EventHandler objOnEditorWindowOpen, EventHandler objOnEditorWindowClosed)
		{
			if (objComponent == null || Form.GetValidOwnerForm(objComponent.Form) == null)
			{
				return;
			}
			Type type = objComponent.GetType();
			if (CommonUtils.GetCustomAttribute(type, typeof(ContextualToolbarAttribute), blnInherit: true) is ContextualToolbarAttribute contextualToolbarAttribute && contextualToolbarAttribute.CotextualToolbarType != null && (contextualToolbarAttribute.CotextualToolbarType == typeof(ContextualToolbar) || contextualToolbarAttribute.CotextualToolbarType.IsSubclassOf(typeof(ContextualToolbar))) && Activator.CreateInstance(contextualToolbarAttribute.CotextualToolbarType) is ContextualToolbar contextualToolbar)
			{
				if (objOnEditorWindowClosed != null)
				{
					contextualToolbar.Closed += objOnEditorWindowClosed;
				}
				CurrentContextualToolbar = contextualToolbar;
				ContextualToolbarSkin contextualToolbarSkin = contextualToolbar.Skin as ContextualToolbarSkin;
				if (contextualToolbarSkin != null)
				{
					contextualToolbar.Size = contextualToolbarSkin.ContextualToolbarSize;
				}
				objOnEditorWindowOpen?.Invoke(contextualToolbarSkin, new EventArgs());
				contextualToolbar.ShowPopup(objComponent, DialogAlignment.Above);
			}
		}

		/// 
		/// Shows the contextual toolbar.
		/// </summary>
		/// <param name="lngId">The int identifier.</param>
		internal static void ShowContextualToolbar(Component objComponent)
		{
			ShowContextualToolbar(objComponent, null, null);
		}

		/// 
		/// Handle property editing callback response 
		/// </summary>
		/// <param name="objValue"></param>
		protected virtual void EditPropertyValue_Callback(object objValue)
		{
			try
			{
				if (mobjComponent != null && mobjControlProperty != null)
				{
					if (mobjCustomPropertyValueChangeEvent == null)
					{
						mobjControlProperty.SetValue(mobjComponent, objValue, null);
						return;
					}
					ContextualToolbarPropertyValueEventArgs e = new ContextualToolbarPropertyValueEventArgs(mobjControlProperty.Name, objValue);
					mobjCustomPropertyValueChangeEvent(mobjComponent, e);
				}
			}
			catch (Exception)
			{
			}
		}

		/// 
		/// Closes any previously opened drop down control area.
		/// </summary>
		void IWebUIEditorService.CloseDropDown()
		{
		}

		/// 
		/// Displays the specified control in a drop down area below a value field of the property grid that provides this service.
		/// </summary>
		/// <param name="objDialog">The dialog.</param>
		void IWebUIEditorService.ShowDropDown(Form objDialog)
		{
			objDialog?.ShowPopup(CurrentContextualToolbar, DialogAlignment.Below);
		}

		/// 
		/// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
		/// </summary>
		/// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
		void IWebUIEditorService.ShowDialog(Form objDialog)
		{
			((IWebUIEditorService)this).ShowDropDown(objDialog);
		}

		/// 
		/// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
		/// </summary>
		/// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
		void IWebUIEditorService.ShowDialog(CommonDialog objDialog)
		{
			objDialog?.ShowPopup(CurrentContextualToolbar, CurrentContextualToolbar, null, DialogAlignment.Below, mobjEditorDialogLocation);
		}

		/// 
		/// Gets the service object of the specified type.
		/// </summary>
		/// <param name="serviceType">An object that specifies the type of service object to get.</param>
		/// 
		/// A service object of type <paramref name="serviceType" />.-or- null if there is no service object of type <paramref name="serviceType" />.
		/// </returns>
		public new object GetService(Type serviceType)
		{
			if (serviceType == typeof(IWebUIEditorService))
			{
				return this;
			}
			return null;
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is ContextualToolbarButton contextualToolbarButton)
			{
				contextualToolbarButton.Owner = this;
				mobjListOfButtons.Add(contextualToolbarButton);
			}
		}
	}
}
