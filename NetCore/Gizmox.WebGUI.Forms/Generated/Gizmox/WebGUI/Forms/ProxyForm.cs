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
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ProxyForm : ProxyControl, IProxyForm
	{
		private string mstrMasterPageId = null;

		private IEmulatorForm mobjEmulatorForm;

		private ProxyControl mobjNavigationControl;

		internal IEmulatorForm EmulatorForm
		{
			get
			{
				if (mobjEmulatorForm == null)
				{
					if (!(Context is IContextParams contextParams))
					{
						return null;
					}
					mobjEmulatorForm = contextParams.EmulatorForm;
				}
				return mobjEmulatorForm;
			}
		}

		/// 
		/// Gets or sets the application master page.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string MasterPageId
		{
			get
			{
				return mstrMasterPageId;
			}
			set
			{
				mstrMasterPageId = value;
			}
		}

		/// 
		/// Gets or sets the application master page.
		/// </summary>
		[Category("Emulation")]
		[Description("The default master page name for the form.")]
		[DefaultValue("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
		public string MasterPage
		{
			get
			{
				IProxyMasterPage masterPageById = EmulatorForm.GetMasterPageById(MasterPageId);
				if (masterPageById == null)
				{
					return EmulatorForm.MasterPageInheritName;
				}
				return EmulatorForm.GetMasterPageDisplayName(masterPageById);
			}
			set
			{
				MasterPageId = value;
			}
		}

		/// 
		/// Gets or sets the navigation control.
		/// </summary>
		/// 
		/// The navigation control.
		/// </value>
		[WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
		[TypeConverter(typeof(EmptyExpandableObjectConverter))]
		public ProxyControl NavigationControl
		{
			get
			{
				return mobjNavigationControl;
			}
			set
			{
				mobjNavigationControl = value;
			}
		}

		/// 
		/// Gets or sets the parent form.
		/// </summary>
		/// 
		/// The parent form.
		/// </value>
		IForm IProxyForm.ParentForm
		{
			get
			{
				return ParentForm;
			}
			set
			{
				ParentForm = value as Form;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyForm" /> class.
		/// </summary>
		public ProxyForm()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyForm" /> class.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objParent">The obj parent.</param>
		/// <param name="blnStateComponent">if set to true</c> [BLN state component].</param>
		public ProxyForm(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
			: base(objComponent, objParent, blnStateComponent)
		{
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			if (ParentForm != null)
			{
				ParentForm.Update();
			}
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="blnRedrawOnly"></param>
		public override void Update(bool blnRedrawOnly)
		{
			base.Update(blnRedrawOnly);
			if (ParentForm != null)
			{
				ParentForm.Update(blnRedrawOnly);
			}
		}

		public override void Update(bool blnRedrawOnly, bool blnUseClientUpdateHandler)
		{
			base.Update(blnRedrawOnly, blnUseClientUpdateHandler);
			if (ParentForm != null)
			{
				ParentForm.Update(blnRedrawOnly, blnUseClientUpdateHandler);
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
				if (IsProxyProperty(item))
				{
					proxyComponentProperties.Add(item);
				}
			}
			return proxyComponentProperties;
		}

		/// 
		/// Determines whether [is proxy property] [the specified obj property descriptor].
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		/// 
		///   true</c> if [is proxy property] [the specified obj property descriptor]; otherwise, false</c>.
		/// </returns>
		private bool IsProxyProperty(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null)
			{
				switch (objPropertyDescriptor.Name)
				{
				case "FullScreenMode":
					if (EmulatorForm != null)
					{
						return base.SourceComponent == EmulatorForm.MainForm;
					}
					break;
				case "MasterPage":
					return true;
				case "NavigationControl":
					return true;
				}
			}
			return false;
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// <param name="objPropertyDescriptor"></param>
		/// </returns>
		protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			if (IsProxyProperty(objPropertyDescriptor))
			{
				return this;
			}
			return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
		}

		/// 
		/// Validates the source component.
		/// </summary>
		internal override void ValidateSourceComponent()
		{
			foreach (ProxyComponent component in Components)
			{
				if (component is ProxyControl proxyControl)
				{
					proxyControl.ValidateSourceComponent();
				}
			}
		}
	}
}
