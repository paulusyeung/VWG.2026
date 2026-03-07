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
	/// The proxy control
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[ContextualToolbar(typeof(ProxyControlContextualToolbar))]
	public class ProxyControl : ProxyComponent
	{
		/// 
		///
		/// </summary>
		private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangedEventHandler = null;

		/// 
		///
		/// </summary>
		private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangingEventHandler = null;

		/// 
		///
		/// </summary>
		private List<object> mobjProxyActions;

		private string mstrName;

		/// 
		/// Gets a value indicating whether [can edit cotnrol].
		/// </summary>
		/// 
		///   true</c> if [can edit cotnrol]; otherwise, false</c>.
		/// </value>
		public bool CanEditCotnrol
		{
			get
			{
				bool result = false;
				if (base.SourceComponent is Control control)
				{
					result = control.CanEditControl;
				}
				return result;
			}
		}

		/// 
		/// Gets or sets the name of the control.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Name
		{
			get
			{
				if (base.SourceComponent is Control control)
				{
					return $"{control.Name} ({control.GetType().Name})";
				}
				return base.Name;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// 
		/// Gets or sets the actions.
		/// </summary>
		/// 
		/// The actions.
		/// </value>
		[WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
		[MergableProperty(false)]
		public List<object> Actions
		{
			get
			{
				if (mobjProxyActions == null)
				{
					mobjProxyActions = new List<object>();
				}
				return mobjProxyActions;
			}
			set
			{
				mobjProxyActions = value;
			}
		}

		/// 
		/// Occurs when [getting property value].
		/// </summary>
		internal event UiPropertyValueChangedEventHandler UiPropertyValueChanged
		{
			add
			{
				mobjUiPropertyValueChangedEventHandler = (UiPropertyValueChangedEventHandler)Delegate.Combine(mobjUiPropertyValueChangedEventHandler, value);
			}
			remove
			{
				mobjUiPropertyValueChangedEventHandler = (UiPropertyValueChangedEventHandler)Delegate.Remove(mobjUiPropertyValueChangedEventHandler, value);
			}
		}

		/// 
		/// Occurs when [UI property value changing].
		/// </summary>
		internal event UiPropertyValueChangedEventHandler UiPropertyValueChanging
		{
			add
			{
				mobjUiPropertyValueChangingEventHandler = (UiPropertyValueChangedEventHandler)Delegate.Combine(mobjUiPropertyValueChangingEventHandler, value);
			}
			remove
			{
				mobjUiPropertyValueChangingEventHandler = (UiPropertyValueChangedEventHandler)Delegate.Remove(mobjUiPropertyValueChangingEventHandler, value);
			}
		}

		/// 
		/// Occurs when [UI property key down].
		/// </summary>
		internal event ClientEventHandler ProxyClientKeyDown
		{
			add
			{
				AddClientHandler("KeyDown", value);
			}
			remove
			{
				RemoveClientHandler("KeyDown", value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyControl" /> class.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objParent">The obj parent.</param>
		/// <param name="blnStateComponent">if set to true</c> [BLN state component].</param>
		public ProxyControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
			: base(objComponent, objParent, blnStateComponent)
		{
			AddContainedControls(objComponent);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyControl" /> class.
		/// </summary>
		public ProxyControl()
		{
		}

		/// 
		/// Adds the contained controls.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void AddContainedControls(Component objComponent)
		{
			if (!(objComponent is Control control))
			{
				return;
			}
			foreach (Control control2 in control.Controls)
			{
				ProxyComponent proxyComponent = CreateProxyByComponent(control2);
				if (proxyComponent != null)
				{
					Components.Add(proxyComponent);
				}
			}
		}

		/// 
		/// Raises the <see cref="E:UiPropertyValueChanged" /> event.
		/// </summary>
		/// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
		private void OnUiPropertyValueChanged(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
		{
			if (mobjUiPropertyValueChangedEventHandler != null)
			{
				mobjUiPropertyValueChangedEventHandler(this, objProxyPropertyValueEventArgs);
			}
		}

		/// 
		/// Raises the <see cref="E:UiPropertyValueChanging" /> event.
		/// </summary>
		/// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
		private void OnUiPropertyValueChanging(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
		{
			if (mobjUiPropertyValueChangingEventHandler != null)
			{
				mobjUiPropertyValueChangingEventHandler(this, objProxyPropertyValueEventArgs);
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (!(type == "Resize"))
			{
				if (type == "Move")
				{
					double dblValue = -1.0;
					double dblValue2 = -1.0;
					if (CommonUtils.TryParse(objEvent["Left"], out dblValue) && CommonUtils.TryParse(objEvent["Top"], out dblValue2))
					{
						SetUiPropertyValue("Location", new Point(Convert.ToInt32(dblValue), Convert.ToInt32(dblValue2)));
					}
				}
			}
			else
			{
				double value = Convert.ToDouble(objEvent["Width"], CultureInfo.InvariantCulture);
				double value2 = Convert.ToDouble(objEvent["Height"], CultureInfo.InvariantCulture);
				SetUiPropertyValue("Size", new Size(Convert.ToInt32(value), Convert.ToInt32(value2)));
			}
			base.FireEvent(objEvent);
		}

		public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
		{
			if (HasClientHandler("KeyDown"))
			{
				if (strPropertyName == "ShouldRenderClientEvents")
				{
					object obj = true;
					return (T)obj;
				}
				if (strPropertyName == "ClientEvents")
				{
					object events = ((IClientComponent)this).Events;
					return (T)events;
				}
			}
			return base.GetProxyPropertyValue(strPropertyName, objDefaultValue);
		}

		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("KeyDown"))
			{
				criticalClientEventsData.Set("KD");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (HasRightClickSupport())
			{
				criticalEventsData.Set("RC");
			}
			return criticalEventsData;
		}

		/// 
		/// Determines whether element has right click support for the context menu.
		/// </summary>
		/// 
		///   true</c> if [has right click support]; otherwise, false</c>.
		/// </returns>
		protected virtual bool HasRightClickSupport()
		{
			return true;
		}

		/// 
		/// Sets the UI property value.
		/// </summary>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// <param name="objValue">The obj value.</param>
		internal void SetUiPropertyValue(string strPropertyName, object objValue)
		{
			bool flag = false;
			ProxyPropertyValueEventArgs e = new ProxyPropertyValueEventArgs(strPropertyName, objValue);
			OnUiPropertyValueChanging(e);
			objValue = e.Value;
			if (base.PropertyBag.ContainsKey(strPropertyName))
			{
				if (base.PropertyBag[strPropertyName] != objValue)
				{
					base.PropertyBag[strPropertyName] = objValue;
					flag = true;
				}
			}
			else
			{
				base.PropertyBag.Add(strPropertyName, objValue);
				flag = true;
			}
			if (flag)
			{
				OnUiPropertyValueChanged(new ProxyPropertyValueEventArgs(strPropertyName, objValue));
			}
		}

		/// 
		/// Validates the source component.
		/// </summary>
		internal override void ValidateSourceComponent()
		{
			Component cachedSourceCompomnent = base.CachedSourceCompomnent;
			Component sourceComponent = base.SourceComponent;
			if (cachedSourceCompomnent != sourceComponent)
			{
				Parent?.SourceComponent?.Update();
			}
			else
			{
				base.ValidateSourceComponent();
			}
		}

		/// 
		/// Gets the proxy component properties.
		/// </summary>
		/// <param name="arrAttributes">The arr attributes.</param>
		/// </returns>
		protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection proxyComponentProperties = base.GetProxyComponentProperties(arrAttributes);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, arrAttributes, noCustomTypeDesc: true);
			foreach (PropertyDescriptor item in properties)
			{
				if (item.Name == "Actions")
				{
					proxyComponentProperties.Add(item);
				}
			}
			return proxyComponentProperties;
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// <param name="objPropertyDescriptor"></param>
		/// </returns>
		protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "Actions")
			{
				return this;
			}
			return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
		}

		/// 
		/// Shoulds the serialize actions.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeActions()
		{
			return mobjProxyActions != null && mobjProxyActions.Count > 0;
		}

		/// 
		/// PreRenders the specified object.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		public override void PreRender(IContext objContext, long lngRequestID)
		{
			if (base.SourceComponent is Control control)
			{
				control.ProxyComponent = this;
				control.PreRenderControl(objContext, lngRequestID);
				control.ProxyComponent = null;
			}
		}

		/// 
		/// Happenes after the render.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="lngRequestID">The LNG request identifier.</param>
		public override void PostRender(IContext objContext, long lngRequestID)
		{
			if (base.SourceComponent is Control control)
			{
				control.ProxyComponent = this;
				control.PostRenderControl(objContext, lngRequestID);
				control.ProxyComponent = null;
			}
		}

		/// 
		/// Registers the actions events.
		/// </summary>
		internal void RegisterActionsEvents()
		{
			if (mobjProxyActions == null || mobjProxyActions.Count <= 0 || !(base.SourceComponent is Control control))
			{
				return;
			}
			Type type = control.GetType();
			object[] customAttributes = type.GetCustomAttributes(typeof(DefaultEventAttribute), inherit: true);
			if (customAttributes.Length == 0 || !(customAttributes[0] is DefaultEventAttribute defaultEventAttribute))
			{
				return;
			}
			EventInfo eventInfo = type.GetEvent(defaultEventAttribute.Name);
			if (eventInfo != null)
			{
				MethodInfo method = GetType().GetMethod("ExecuteProxyAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method != null)
				{
					Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, method);
					eventInfo.RemoveEventHandler(control, handler);
					eventInfo.AddEventHandler(control, handler);
				}
			}
		}

		/// 
		/// Executes the proxy action.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected void ExecuteProxyAction(object sender, EventArgs e)
		{
			if (mobjProxyActions == null || mobjProxyActions.Count <= 0)
			{
				return;
			}
			foreach (ProxyAction mobjProxyAction in mobjProxyActions)
			{
				mobjProxyAction.Execute();
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		protected override Component GetSourceComponent()
		{
			if (!base.IsStateComponent)
			{
				ProxyComponent parent = Parent;
				if (parent != null && !parent.IsStateComponent && parent.SourceComponent is Control control)
				{
					int num = parent.Components.IndexOf(this);
					if (num >= 0 && num < control.Controls.Count)
					{
						return control.Controls[num];
					}
				}
			}
			return base.GetSourceComponent();
		}

		/// 
		/// Shows the contextual toolbar.
		/// </summary>
		public void ShowContextualToolbar(EventHandler objOnEditorWindowOpen, EventHandler objOnEditorWindowClosed)
		{
			Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ShowContextualToolbar(this, objOnEditorWindowOpen, objOnEditorWindowClosed);
		}
	}
}
