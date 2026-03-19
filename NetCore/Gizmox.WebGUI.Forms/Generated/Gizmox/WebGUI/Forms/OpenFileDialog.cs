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
/// Prompts the user to open a file. This class cannot be inherited.</summary>
	/// 2</filterpriority>
	[Serializable]
	[SRDescription("DescriptionOpenFileDialog")]
	[ToolboxBitmap(typeof(OpenFileDialog), "OpenFileDialog_45.bmp")]
	[ToolboxItem(true)]
	[Skin(typeof(OpenFileDialogSkin))]
	public sealed class OpenFileDialog : FileDialog
	{
		/// 
		/// Summary description for OpenFileDialog.
		/// </summary>
		[Serializable]
		private sealed class OpenFileDialogForm : CommonDialogForm
		{
			/// 
			/// Provides a property reference to HtmlBoxHost property.
			/// </summary>
			private static SerializableProperty HtmlBoxHostProperty = SerializableProperty.Register("HtmlBoxHost", typeof(HtmlBoxHost), typeof(OpenFileDialogForm));

			/// 
			/// Provides a property reference to IsFirstFile property.
			/// </summary>
			private static SerializableProperty IsFirstFileProperty = SerializableProperty.Register("IsFirstFile", typeof(bool), typeof(OpenFileDialogForm), new SerializablePropertyMetadata(true));

			private const string mstrDefaultFilter = "All files(*.*)|*.*";

			private Control mobjProgressPanel;

			private HtmlBoxHost mobjHtmlBoxHost;

			/// 
			/// Gets a flag indiacating if to use flash uploading
			/// </summary>
			private string DynamicExtension => Context.Config.DynamicExtension;

			/// 
			/// Gets a flag indiacating if to use flash uploading
			/// </summary>
			private bool UseFlash => Context.Config.IsFeatureEnabled("UseFlashForUpload", true);

			/// 
			/// Gets the dialog title
			/// </summary>
			private string Title => OpenFileDialogOwner.Title;

			/// 
			/// Gets the dialog filter
			/// </summary>
			private string Filter => OpenFileDialogOwner.Filter;

			/// 
			/// Gets a flag indicating if multiselet is valid
			/// </summary>
			private bool Multiselect => OpenFileDialogOwner.Multiselect;

			/// 
			/// Gets the current session id
			/// </summary>
			private string SessionId => Context.HostContext.Session.SessionID;

			/// 
			/// Gets the max file size
			/// </summary>
			private int MaxFileSize => OpenFileDialogOwner.MaxFileSize;

			/// 
			/// Gest the file handle
			/// </summary>
			private FileHandle File => OpenFileDialogOwner.File;

			/// 
			/// Gets the file collection
			/// </summary>
			private FileHandleCollection Files => OpenFileDialogOwner.Files;

			/// 
			/// Returns the open file dialog owner
			/// </summary>
			private OpenFileDialog OpenFileDialogOwner => (OpenFileDialog)base.CommonDialogOwner;

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialog" /> instance.
			/// </summary>
			public OpenFileDialogForm(CommonDialog objCommonDialog)
				: base(objCommonDialog)
			{
				InitializeComponent();
			}

			private void InitializeComponent()
			{
				mobjHtmlBoxHost = new HtmlBoxHost();
				mobjProgressPanel = new OpenFileDialogProgressPanel(this);
				SuspendLayout();
				mobjProgressPanel.Size = new Size(0, 0);
				mobjHtmlBoxHost.Dock = DockStyle.Fill;
				SetValue(HtmlBoxHostProperty, mobjHtmlBoxHost);
				base.Controls.Add(mobjHtmlBoxHost);
				base.Controls.Add(mobjProgressPanel);
				base.ClientSize = new Size(350, 215);
				ResumeLayout(blnPerformLayout: false);
			}

			protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
			{
				base.PreRenderControl(objContext, lngRequestID);
				mobjProgressPanel.ClientId = "VWGOpenFileDialogPanel" + ID;
			}

			/// 
			/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
			/// </summary>
			/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				HtmlBoxHost value = GetValue(HtmlBoxHostProperty);
				value.Url = $"Resources.Gizmox.WebGUI.Forms.Skins.OpenFileDialogSkin.OpenFileDialog.htm{DynamicExtension}";
				Text = Title;
				value.SetProperty("UseFlash", UseFlash ? "1" : "0");
				value.SetProperty("MaxFileSize", MaxFileSize.ToString());
				value.SetProperty("Filter", Filter);
				value.SetProperty("SessionId", SessionId);
				value.SetProperty("Multiselect", Multiselect ? "1" : "0");
				value.SetProperty("GatewayId", ID.ToString());
				if (UseFlash && !CommonUtils.IsNullOrEmpty(Filter))
				{
					string[] array = Filter.Split('|');
					value.SetProperty("AllowedFileTypesDescription", array[0]);
					value.SetProperty("AllowedFileTypes", array[1]);
				}
			}

			/// 
			/// Renders the forms attribute
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
			{
				base.RenderAttributes(objContext, objWriter);
				objWriter.WriteAttributeString("IsOpenFileDialog", "1");
			}

			/// 
			/// Provides a way to handle gateway requests.
			/// </summary>
			/// <param name="objHostContext">The gateway request HOST context.</param>
			/// <param name="strAction">The gateway request action.</param>
			/// 
			/// By default this method returns a instance of a class which implements the IGatewayHandler and
			/// throws a non implemented HttpException.
			/// </returns>
			/// 
			/// This method is called from the implementation of IGatewayComponent which replaces the
			/// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
			/// RegisteredComponent class which is the base class of most of the Visual WebGui
			/// components.
			/// Referencing a RegisterComponent that overrides this method is done the same way that
			/// a control implementing IGatewayControl, which is by using the GatewayReference class.
			/// </remarks>
			protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
			{
				if (GetValue(IsFirstFileProperty, objDefault: true))
				{
					Files.Clear();
					base.DialogResult = DialogResult.OK;
					SetValue(IsFirstFileProperty, objValue: false);
				}
				try
				{
					for (int i = 0; i < objHostContext.Request.Files.Count; i++)
					{
						HttpPostedFileHandle httpPostedFileHandle = HttpPostedFileHandle.Create(objHostContext.Request.Files[i]);
						if (httpPostedFileHandle.ContentLength > 0 && !string.IsNullOrEmpty(httpPostedFileHandle.FileName))
						{
							Files.Add(httpPostedFileHandle.FileName, httpPostedFileHandle);
						}
					}
					if (strAction != "UploadFlash")
					{
						string arg = "Upload_CloseWindow";
						if (Context != null && Context is IContextMethodInvoker)
						{
							arg = ((IContextMethodInvoker)Context).GetMethodName(base.CommonDialogOwner, "Upload_CloseWindow");
						}
						objHostContext.Response.Write($"<SCRIPT language='javascript'>parent.{arg}();</SCRIPT></HTML>");
					}
					else
					{
						objHostContext.Response.Write("</HTML>");
					}
				}
				catch (Exception ex)
				{
					string arg2 = "Upload_DisplayError";
					if (Context != null && Context is IContextMethodInvoker)
					{
						arg2 = ((IContextMethodInvoker)Context).GetMethodName(base.CommonDialogOwner, "Upload_DisplayError");
					}
					objHostContext.Response.Write(string.Format("<BODY onload=\"parent.{0}(document.body.innerText);\">" + global::System.Net.WebUtility.HtmlEncode(ex.Message) + "</BODY></HTML>", arg2));
				}
				return null;
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist. </summary>
		/// true if the dialog box displays a warning when the user specifies a file name that does not exist; otherwise, false. The default value is true.</returns>
		[DefaultValue(true)]
		[SRDescription("OFDcheckFileExistsDescr")]
		public override bool CheckFileExists
		{
			get
			{
				return base.CheckFileExists;
			}
			set
			{
				base.CheckFileExists = value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box allows multiple files to be selected. </summary>
		/// true if the dialog box allows multiple files to be selected together or concurrently; otherwise, false. The default value is false.</returns>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("OFDmultiSelectDescr")]
		public bool Multiselect
		{
			get
			{
				return GetOption(512);
			}
			set
			{
				SetOption(512, value);
			}
		}

		/// Gets or sets a value indicating whether the read-only check box is selected. </summary>
		/// true if the read-only check box is selected; otherwise, false. The default value is false.</returns>
		[SRCategory("CatBehavior")]
		[SRDescription("OFDreadOnlyCheckedDescr")]
		[DefaultValue(false)]
		public bool ReadOnlyChecked
		{
			get
			{
				return GetOption(1);
			}
			set
			{
				SetOption(1, value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box contains a read-only check box. </summary>
		/// true if the dialog box contains a read-only check box; otherwise, false. The default value is false.</returns>
		[SRDescription("OFDshowReadOnlyDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool ShowReadOnly
		{
			get
			{
				return !GetOption(4);
			}
			set
			{
				SetOption(4, !value);
			}
		}

		/// Initializes an instance of the <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialog"></see> class.</summary>
		public OpenFileDialog()
		{
		}

		/// Opens the file selected by the user, with read-only permission. The file is specified by the <see cref="P:Gizmox.WebGUI.Forms.FileDialog.FileName"></see> property. </summary>
		/// A <see cref="T:System.IO.Stream"></see> that specifies the read-only file selected by the user.</returns>
		/// <exception cref="T:System.ArgumentNullException">The file name is null. </exception>
		/// 1</filterpriority>
		public Stream OpenFile()
		{
			if (base.File == null)
			{
				throw new ArgumentNullException();
			}
			return base.File.InputStream;
		}

		/// Resets all properties to their default values. </summary>
		public override void Reset()
		{
			base.Reset();
			SetOption(4096, blnValue: true);
		}

		/// 
		/// Create the open file dialog form
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new OpenFileDialogForm(this);
		}
	}
}
