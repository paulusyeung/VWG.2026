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
	/// Provides an empty control that can be used to create other controls.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[DesignerCategory("UserControl")]
	[DefaultEvent("Load")]
	[Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[MetadataTag("UC")]
	[Skin(typeof(UserControlSkin))]
	public class UserControl : ContainerControl, IUserControl, IWin32Window, IControl, IEventHandler, IRegisteredComponent
	{
		/// 
		/// The Load event registration.
		/// </summary>
		private static readonly SerializableEvent LoadEvent;

		/// 
		/// The current context object
		/// </summary>
		[NonSerialized]
		private IContext mobjContext = null;

		/// 
		/// Gets the hanlder for the Load event.
		/// </summary>
		private EventHandler LoadHandler => (EventHandler)GetHandler(Load);

		/// 
		/// This property is not relevant for this class.
		/// </summary>
		/// </value>
		/// true if enabled; otherwise, false.</returns>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// Indicates the automatic sizing behavior of the control.</summary>
		/// One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new virtual AutoSizeMode AutoSizeMode
		{
			get
			{
				return base.AutoSizeMode;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(AutoSizeMode));
				}
				base.AutoSizeMode = value;
			}
		}

		/// 
		/// Gets the context.
		/// </summary>
		/// </value>
		public override IContext Context
		{
			get
			{
				if (mobjContext != null)
				{
					return mobjContext;
				}
				return base.Context;
			}
		}

		/// 
		/// Occurs before the control becomes visible for the first time.
		/// </summary>
		[SRCategory("CatBehavior")]
		[SRDescription("UserControlOnLoadDescr")]
		public event EventHandler Load
		{
			add
			{
				AddHandler(LoadEvent, value);
			}
			remove
			{
				RemoveHandler(LoadEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UserControl"></see> class.
		/// </summary>
		public UserControl()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, blnValue: true);
		}

		/// 
		/// Renders the specified obj context.
		/// </summary>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderControls(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Raises the CreateControl event.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			OnLoad(EventArgs.Empty);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.UserControl.Load"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLoad(EventArgs e)
		{
			LoadHandler?.Invoke(this, e);
		}

		/// 
		/// Determines whether has focusable child.
		/// </summary>
		/// 
		/// 	true</c> if has focusable child; otherwise, false</c>.
		/// </returns>
		internal bool HasFocusableChild()
		{
			Control control = null;
			do
			{
				control = GetNextControl(control, blnForward: true);
			}
			while ((control == null || !control.CanSelect || !control.TabStop) && control != null);
			return control != null;
		}

		/// 
		/// Causes all of the child controls within a control that support validation to validate their data.
		/// </summary>
		/// <param name="validationConstraints">Tells <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren(System.Windows.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
		/// 
		/// true if all of the children validated successfully; otherwise, false.
		/// </returns>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override bool ValidateChildren(ValidationConstraints validationConstraints)
		{
			return base.ValidateChildren(validationConstraints);
		}

		/// 
		/// Sets the context.
		/// </summary>
		/// <param name="objContext">The context.</param>
		void IUserControl.SetContext(IContext objContext)
		{
			mobjContext = objContext;
		}

		static UserControl()
		{
			Load = SerializableEvent.Register("Load", typeof(EventHandler), typeof(UserControl));
		}
	}
}
