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
	/// The basic proxy component
	/// </summary>
	[Serializable]
	public class ProxyComponent : Component, ICustomTypeDescriptor
	{
		/// 
		///
		/// </summary>
		private EventHandler mobjProxyClickEventHandler = null;

		/// 
		///
		/// </summary>
		private GettingPropertyValueEventHandler mobjGettingPropertyValueEventHandler = null;

		/// 
		///
		/// </summary>
		private SourceComponentFireEventHandler mobjSourceComponentFireEventHandler = null;

		/// 
		///
		/// </summary>
		private ProxyComponentChangingEventHandler mobjProxyComponentChangingEventHandler = null;

		/// 
		/// The filter properties event handler
		/// </summary>
		private FilterPropertiesEventHandler mobjFilterPropertiesEventHandler = null;

		/// 
		///
		/// </summary>
		private ProxySet mobjComponents = new ProxySet();

		/// 
		/// The property bag
		/// </summary>
		private ProxyPropertyBag mobjPropertyBag = new ProxyPropertyBag();

		/// 
		///
		/// </summary>
		[NonSerialized]
		private ProxyComponent mobjParent = null;

		/// 
		///
		/// </summary>
		[NonSerialized]
		protected Form mobjParentForm = null;

		/// 
		/// The unique ID
		/// </summary>
		private string mstrUniqueID = null;

		/// 
		/// The cached proxy compomnent (only valid for runtim mode)
		/// </summary>
		private Component mobjCachedSourceCompomnent = null;

		/// 
		/// The MSTR custom component type
		/// </summary>
		private string mstrNonStateComponentType;

		private bool mblnProxyInitialized = false;

		/// 
		/// Gets a value indicating whether [is custom].
		/// </summary>
		/// 
		///   true</c> if [is custom]; otherwise, false</c>.
		/// </value>
		public bool IsStateComponent => string.IsNullOrEmpty(mstrNonStateComponentType);

		/// 
		/// Gets the type of the custom component.
		/// </summary>
		/// 
		/// The type of the custom component.
		/// </value>
		public string NonStateComponentType
		{
			get
			{
				return mstrNonStateComponentType;
			}
			set
			{
				mstrNonStateComponentType = value;
			}
		}

		/// 
		/// Gets or sets the name of the component.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string Name
		{
			get
			{
				return ToString();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// 
		/// Gets the getting property value event handler.
		/// </summary>
		/// 
		/// The getting property value event handler.
		/// </value>
		internal GettingPropertyValueEventHandler GettingPropertyValueEventHandler => mobjGettingPropertyValueEventHandler;

		/// 
		/// Gets the filter properties event handler.
		/// </summary>
		/// 
		/// The filter properties event handler.
		/// </value>
		internal FilterPropertiesEventHandler FilterPropertiesEventHandler => mobjFilterPropertiesEventHandler;

		/// 
		/// Gets or sets the components.
		/// </summary>
		/// 
		/// The components.
		/// </value>
		public virtual ProxySet Components => mobjComponents;

		/// 
		/// Gets a value indicating whether proxy component is visible.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Visible => GetVisible();

		/// 
		/// Gets the owner form.
		/// </summary>
		public override Form Form
		{
			get
			{
				if (ParentForm != null)
				{
					return ParentForm;
				}
				return base.Form;
			}
		}

		/// 
		/// Gets a value indicating whether InitializeProxy already been called for this component.
		/// </summary>
		protected bool ProxyInitialized => mblnProxyInitialized;

		/// 
		/// Gets the unique ID.
		/// </summary>
		/// 
		/// The unique ID.
		/// </value>
		public string UniqueID
		{
			get
			{
				return mstrUniqueID;
			}
			set
			{
				mstrUniqueID = value;
			}
		}

		/// 
		///
		/// </summary>
		private bool ShouldGetSourceComponent
		{
			get
			{
				if (IsStateComponent)
				{
					return mobjCachedSourceCompomnent == null || !mobjCachedSourceCompomnent.IsRegistered;
				}
				return mobjCachedSourceCompomnent == null;
			}
		}

		/// 
		/// Gets or sets the source component.
		/// </summary>
		/// 
		/// The source component.
		/// </value>
		internal Component SourceComponent
		{
			get
			{
				if (ShouldGetSourceComponent)
				{
					mobjCachedSourceCompomnent = GetSourceComponent();
				}
				return mobjCachedSourceCompomnent;
			}
		}

		/// 
		/// Gets the cached source compomnent.
		/// </summary>
		/// 
		/// The cached source compomnent.
		/// </value>
		internal Component CachedSourceCompomnent => mobjCachedSourceCompomnent;

		/// 
		/// Gets the property bag.
		/// </summary>
		public ProxyPropertyBag PropertyBag => mobjPropertyBag;

		/// 
		/// Gets the parent.
		/// </summary>
		public virtual ProxyComponent Parent
		{
			get
			{
				return mobjParent;
			}
			set
			{
				mobjParent = value;
			}
		}

		/// 
		/// Gets or sets the parent form.
		/// </summary>
		/// 
		/// The parent form.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual Form ParentForm
		{
			get
			{
				if (mobjParentForm != null)
				{
					return mobjParentForm;
				}
				if (Parent != null)
				{
					return Parent.ParentForm;
				}
				return null;
			}
			set
			{
				mobjParentForm = value;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is emulation mode.
		/// </summary>
		/// 
		/// true</c> if this instance is emulation mode; otherwise, false</c>.
		/// </value>
		public bool IsEmulationMode
		{
			get
			{
				if (Context is IContextParams contextParams)
				{
					return contextParams.EmulatorForm != null;
				}
				return false;
			}
		}

		/// 
		/// Occurs when [getting property value].
		/// </summary>
		internal event GettingPropertyValueEventHandler GettingPropertyValue
		{
			add
			{
				mobjGettingPropertyValueEventHandler = (GettingPropertyValueEventHandler)Delegate.Combine(mobjGettingPropertyValueEventHandler, value);
			}
			remove
			{
				mobjGettingPropertyValueEventHandler = (GettingPropertyValueEventHandler)Delegate.Remove(mobjGettingPropertyValueEventHandler, value);
			}
		}

		/// 
		/// Occurs when [filter properties].
		/// </summary>
		internal event FilterPropertiesEventHandler FilterProperties
		{
			add
			{
				mobjFilterPropertiesEventHandler = (FilterPropertiesEventHandler)Delegate.Combine(mobjFilterPropertiesEventHandler, value);
			}
			remove
			{
				mobjFilterPropertiesEventHandler = (FilterPropertiesEventHandler)Delegate.Remove(mobjFilterPropertiesEventHandler, value);
			}
		}

		/// 
		/// Occurs when [source component fire event].
		/// </summary>
		internal event SourceComponentFireEventHandler SourceComponentFireEvent
		{
			add
			{
				mobjSourceComponentFireEventHandler = (SourceComponentFireEventHandler)Delegate.Combine(mobjSourceComponentFireEventHandler, value);
			}
			remove
			{
				mobjSourceComponentFireEventHandler = (SourceComponentFireEventHandler)Delegate.Remove(mobjSourceComponentFireEventHandler, value);
			}
		}

		/// 
		/// Occurs when [getting property value].
		/// </summary>
		internal event ProxyComponentChangingEventHandler ProxyComponentChanging
		{
			add
			{
				mobjProxyComponentChangingEventHandler = (ProxyComponentChangingEventHandler)Delegate.Combine(mobjProxyComponentChangingEventHandler, value);
			}
			remove
			{
				mobjProxyComponentChangingEventHandler = (ProxyComponentChangingEventHandler)Delegate.Remove(mobjProxyComponentChangingEventHandler, value);
			}
		}

		/// 
		/// Occurs when [UI property value changing].
		/// </summary>
		internal event EventHandler ProxyClick
		{
			add
			{
				mobjProxyClickEventHandler = (EventHandler)Delegate.Combine(mobjProxyClickEventHandler, value);
			}
			remove
			{
				mobjProxyClickEventHandler = (EventHandler)Delegate.Remove(mobjProxyClickEventHandler, value);
			}
		}

		/// 
		/// Unsubscribe to get  events of proxy control with children.
		/// </summary>
		protected void UnsubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
		{
			GettingPropertyValueEventHandler gettingPropertyValueEventHandler = GettingPropertyValueEventHandler;
			if (gettingPropertyValueEventHandler != null)
			{
				objProxyComponent.GettingPropertyValue -= gettingPropertyValueEventHandler;
			}
			FilterPropertiesEventHandler filterPropertiesEventHandler = FilterPropertiesEventHandler;
			if (filterPropertiesEventHandler != null)
			{
				objProxyComponent.FilterProperties -= filterPropertiesEventHandler;
			}
			foreach (ProxyComponent component in objProxyComponent.Components)
			{
				UnsubscribeGetEventsWithChildren(component);
			}
		}

		/// 
		/// Subscribe to get events of proxy control with children.
		/// </summary>
		protected void SubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
		{
			GettingPropertyValueEventHandler gettingPropertyValueEventHandler = GettingPropertyValueEventHandler;
			if (gettingPropertyValueEventHandler != null)
			{
				objProxyComponent.GettingPropertyValue += gettingPropertyValueEventHandler;
			}
			FilterPropertiesEventHandler filterPropertiesEventHandler = FilterPropertiesEventHandler;
			if (filterPropertiesEventHandler != null)
			{
				objProxyComponent.FilterProperties += filterPropertiesEventHandler;
			}
			foreach (ProxyComponent component in objProxyComponent.Components)
			{
				SubscribeGetEventsWithChildren(component);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyComponent" /> class.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objParent">The obj parent.</param>
		/// <param name="blnStateComponent">if set to true</c> [BLN state component].</param>
		public ProxyComponent(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
			: this()
		{
			Parent = objParent;
			if (blnStateComponent)
			{
				PreserveComponentUniqueID(objComponent);
			}
			else
			{
				UpdateNonStateComponentType(objComponent);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyComponent" /> class.
		/// </summary>
		public ProxyComponent()
		{
			PropertyBag.PropertyValueChanging += PropertyBag_PropertyValueChanging;
		}

		/// 
		/// Preserves the component unique ID.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void PreserveComponentUniqueID(Component objComponent)
		{
			UniqueID = GetComponentUniqueID(ParentForm, objComponent);
		}

		private void UpdateNonStateComponentType(Component objComponent)
		{
			mobjCachedSourceCompomnent = objComponent;
			mstrNonStateComponentType = objComponent.GetType().AssemblyQualifiedName;
		}

		/// 
		///
		/// </summary>
		/// </returns>
		protected virtual Component GetSourceComponent()
		{
			if (IsStateComponent)
			{
				return GetComponentByUniqueId(ParentForm, UniqueID);
			}
			Component component = Activator.CreateInstance(Type.GetType(NonStateComponentType)) as Component;
			if (component != null && Parent != null)
			{
				component.InternalParent = Parent.SourceComponent;
			}
			return component;
		}

		/// 
		/// Returns wether proxy component is visible.
		/// </summary>
		protected virtual bool GetVisible()
		{
			if (PropertyBag.ContainsKey("Visible") && !(bool)PropertyBag["Visible"])
			{
				return false;
			}
			if (SourceComponent is Control { Visible: false })
			{
				return false;
			}
			if (Parent == null)
			{
				return true;
			}
			return Parent.GetVisible();
		}

		/// 
		/// Initializes the emulation.
		/// </summary>
		internal virtual void InitializeProxy()
		{
			foreach (ProxyComponent component in Components)
			{
				component.InitializeProxy();
			}
			mblnProxyInitialized = true;
		}

		/// 
		/// Sign proxy as initialized.
		/// </summary>
		protected void SetProxyInitialized()
		{
			mblnProxyInitialized = true;
		}

		/// 
		/// Gets the child proxy component.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// </returns>
		internal ProxyComponent GetChildProxyComponent(Component objComponent)
		{
			foreach (ProxyComponent component in Components)
			{
				if (component.SourceComponent == objComponent)
				{
					return component;
				}
			}
			return null;
		}

		/// 
		/// Creates the proxy component from component.
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		/// <param name="objParentControl">The object parent control.</param>
		/// </returns>
		internal static ProxyComponent CreateProxyComponentFromComponent(Component objComponent, ProxyComponent objParentControl, bool blnStateComponent)
		{
			ProxyComponent result = null;
			object[] customAttributes = objComponent.GetType().GetCustomAttributes(typeof(ProxyComponentAttribute), inherit: true);
			if (customAttributes.Length == 1)
			{
				Type proxyComponentType = ((ProxyComponentAttribute)customAttributes[0]).ProxyComponentType;
				result = Activator.CreateInstance(proxyComponentType, objComponent, objParentControl, blnStateComponent) as ProxyComponent;
			}
			return result;
		}

		/// 
		/// Creates the proxy by component.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// </returns>
		protected ProxyComponent CreateProxyByComponent(Component objComponent)
		{
			return CreateProxyComponentFromComponent(objComponent, this, IsStateComponent);
		}

		/// 
		/// Raises the <see cref="E:GettingPropertyValue" /> event.
		/// </summary>
		/// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
		private void OnGettingPropertyValue(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
		{
			if (mobjGettingPropertyValueEventHandler != null)
			{
				mobjGettingPropertyValueEventHandler(this, objProxyPropertyValueEventArgs);
			}
		}

		/// 
		/// Raises the <see cref="E:FilterProperties" /> event.
		/// </summary>
		/// <param name="objProxyFilterPropertiesEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFilterPropertiesEventArgs" /> instance containing the event data.</param>
		private void OnFilterProperties(ProxyFilterPropertiesEventArgs objProxyFilterPropertiesEventArgs)
		{
			if (mobjFilterPropertiesEventHandler != null)
			{
				mobjFilterPropertiesEventHandler(this, objProxyFilterPropertiesEventArgs);
			}
		}

		/// 
		/// Raises the <see cref="E:SourceComponentFireEvent" /> event.
		/// </summary>
		/// <param name="objFireEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFireEventArgs" /> instance containing the event data.</param>
		internal virtual void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
		{
			if (mobjSourceComponentFireEventHandler != null)
			{
				mobjSourceComponentFireEventHandler(this, objFireEventArgs);
			}
		}

		/// 
		/// Handles the PropertyValueChanging event of the PropertyBag control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
		/// <exception cref="T:System.NotImplementedException"></exception>
		internal void PropertyBag_PropertyValueChanging(object sender, ProxyPropertyValueEventArgs e)
		{
			OnPropertyValueChanging(e);
		}

		/// 
		/// Raises the <see cref="E:PropertyValueChanging" /> event.
		/// </summary>
		/// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
		internal virtual void OnPropertyValueChanging(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
		{
			if (mobjProxyComponentChangingEventHandler != null)
			{
				mobjProxyComponentChangingEventHandler(this, objProxyPropertyValueEventArgs);
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (mobjProxyClickEventHandler != null)
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			if (objEvent.Type == "Click")
			{
				OnProxyClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
			}
			ProxyFireEventArgs e = new ProxyFireEventArgs(objEvent, blnAllowEvent: true);
			OnSourceComponentFireEvent(e);
			if (e.AllowEvent && SourceComponent != null)
			{
				SourceComponent.FireComponentEvent(objEvent);
			}
		}

		private void OnProxyClick(EventArgs objEventArgs)
		{
			if (mobjProxyClickEventHandler != null)
			{
				MouseEventArgs e = objEventArgs as MouseEventArgs;
				if (e == null)
				{
					e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
				}
				mobjProxyClickEventHandler(this, e);
			}
		}

		/// 
		/// Shoulds the type of the serialize custom component.
		/// </summary>
		/// </returns>
		public bool ShouldSerializeNonStateComponentType()
		{
			return NonStateComponentType != null;
		}

		/// 
		/// Shoulds the serialize unique identifier.
		/// </summary>
		/// </returns>
		public bool ShouldSerializeUniqueID()
		{
			return UniqueID != null;
		}

		/// 
		/// Gets the proxy property value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// <param name="objDefaultValue">The obj default value.</param>
		/// </returns>
		public new virtual T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
		{
			if (strPropertyName == "ID")
			{
				object obj = ID;
				return (T)obj;
			}
			T val = objDefaultValue;
			if (mobjPropertyBag.ContainsKey(strPropertyName))
			{
				object obj2 = mobjPropertyBag[strPropertyName];
				if (obj2 != null && obj2 is T)
				{
					val = (T)obj2;
				}
			}
			ProxyPropertyValueEventArgs e = new ProxyPropertyValueEventArgs(strPropertyName, val);
			OnGettingPropertyValue(e);
			return (T)e.Value;
		}

		/// 
		/// Determines whether [has proxy property value] [the specified STR property name].
		/// </summary>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// 
		///   true</c> if [has proxy property value] [the specified STR property name]; otherwise, false</c>.
		/// </returns>
		public new bool HasProxyPropertyValue(string strPropertyName)
		{
			return mobjPropertyBag.ContainsKey(strPropertyName);
		}

		/// 
		/// Gets the component by path.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="strPathPart">The STR path part.</param>
		/// </returns>
		private Component GetComponentByPath(Component objComponent, string strPathPart)
		{
			int num = 0;
			string text = strPathPart;
			int num2 = strPathPart.IndexOf('[');
			if (num2 != -1)
			{
				text = strPathPart.Substring(0, num2);
				int num3 = strPathPart.IndexOf(']');
				if (num3 != -1)
				{
					num = Convert.ToInt32(strPathPart.Substring(num2 + 1, num3 - num2 - 1));
				}
			}
			IList componentOffsprings = objComponent.GetComponentOffsprings(text);
			if (componentOffsprings != null && num < componentOffsprings.Count && componentOffsprings[num] is Component component && text == component.GetType().FullName)
			{
				return component;
			}
			return null;
		}

		/// 
		/// Gets the component by unique id.
		/// </summary>
		/// <param name="objSourceComponent">The obj source component.</param>
		/// <param name="strComponentPath">The STR component path.</param>
		/// </returns>
		internal Component GetComponentByUniqueId(Component objSourceComponent, string strComponentPath)
		{
			Component component = objSourceComponent;
			if (objSourceComponent != null && !string.IsNullOrEmpty(strComponentPath))
			{
				string[] array = strComponentPath.Split('/');
				if (array.Length >= 1)
				{
					component = GetComponentByPath(objSourceComponent, array[0]);
					if (array.Length > 1)
					{
						component = GetComponentByUniqueId(component, string.Join("/", array, 1, array.Length - 1));
					}
				}
			}
			return component;
		}

		/// 
		/// Renders the specified obj context.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		public virtual void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			Component sourceComponent = SourceComponent;
			if (sourceComponent != null && sourceComponent is IRenderableComponent renderableComponent)
			{
				sourceComponent.ProxyComponent = this;
				renderableComponent.RenderComponent(objContext, objWriter, lngRequestID);
				sourceComponent.ProxyComponent = null;
			}
		}

		/// 
		/// Renders the components.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		public virtual void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			Components.RenderSet(objContext, objWriter, lngRequestID);
		}

		/// 
		/// PreRenders the specified object.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		public virtual void PreRender(IContext objContext, long lngRequestID)
		{
		}

		/// 
		/// Pres the render components.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <exception cref="T:System.NotImplementedException"></exception>
		public virtual void PreRenderComponents(IContext objContext, long lngRequestID)
		{
			Components.PreRenderSet(objContext, lngRequestID);
		}

		/// 
		/// Posts the render.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="lngRequestID">The LNG request identifier.</param>
		public virtual void PostRender(IContext objContext, long lngRequestID)
		{
		}

		/// 
		/// Posts the render components.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="lngRequestID">The LNG request identifier.</param>
		public virtual void PostRenderComponents(IContext objContext, long lngRequestID)
		{
			Components.PostRenderSet(objContext, lngRequestID);
		}

		/// 
		/// Validates the source component.
		/// </summary>
		internal virtual void ValidateSourceComponent()
		{
			foreach (ProxyComponent component in Components)
			{
				component.ValidateSourceComponent();
			}
		}

		/// 
		/// Happens after the load of the component from XAML.
		/// </summary>
		public virtual void OnLoad()
		{
			foreach (ProxyComponent component in Components)
			{
				component?.OnLoad();
			}
		}

		System.ComponentModel.AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return GetCustomProperties(attributes);
		}

		/// 
		/// Gets the custom properties.
		/// </summary>
		/// <param name="arrAttributes">The attributes.</param>
		/// </returns>
		private PropertyDescriptorCollection GetCustomProperties(Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection proxyComponentProperties = GetProxyComponentProperties(arrAttributes);
			OnFilterProperties(new ProxyFilterPropertiesEventArgs(proxyComponentProperties));
			return proxyComponentProperties;
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// </returns>
		protected virtual object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			return SourceComponent;
		}

		/// 
		/// Gets the proxy component properties.
		/// </summary>
		/// <param name="arrAttributes">The arr attributes.</param>
		/// </returns>
		protected virtual PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
		{
			List<object> list = new List<object><object>();
			Component sourceComponent = SourceComponent;
			if (sourceComponent != null)
			{
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(sourceComponent, arrAttributes, noCustomTypeDesc: true);
				foreach (PropertyDescriptor item in properties)
				{
					if (item.Attributes[typeof(ProxyBrowsableAttribute)] is ProxyBrowsableAttribute { Browsable: not false } && !(item.Attributes[typeof(BrowsableAttribute)] is BrowsableAttribute { Browsable: false }))
					{
						list.Add(item);
					}
				}
			}
			return new PropertyDescriptorCollection(list.ToArray());
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return GetCustomProperties(null);
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			return GetProxyComponentPropertyOwner(objPropertyDescriptor);
		}
	}
}
