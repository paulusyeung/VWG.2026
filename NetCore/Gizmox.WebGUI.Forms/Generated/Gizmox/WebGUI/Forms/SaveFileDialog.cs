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
	/// SaveFileDialog class.
	/// </summary>
	[Serializable]
	[SRDescription("DescriptionSaveFileDialog")]
	[ToolboxBitmap(typeof(SaveFileDialog), "SaveFileDialog_45.bmp")]
	[ToolboxItem(true)]
	public class SaveFileDialog : FileDialog
	{
		/// 
		///
		/// </summary>
		[Serializable]
		protected sealed class SaveFileDialogForm : CommonDialogForm
		{
			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SaveFileDialog.SaveFileDialogForm" /> class.
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public SaveFileDialogForm(CommonDialog objCommonDialog)
				: base(objCommonDialog)
			{
				RegisterSelf();
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
				if (strAction == "download")
				{
					if (base.CommonDialogOwner is SaveFileDialog { File: { } file })
					{
						objHostContext.Response.ContentType = file.ContentType;
						objHostContext.Response.WriteFile(file.FileName);
					}
					return null;
				}
				return base.ProcessGatewayRequest(objHostContext, strAction);
			}
		}

		private SaveFileDialogForm mobjSaveFileDialogForm = null;

		/// 
		/// Gets or sets a value indicating whether [create prompt].
		/// </summary>
		/// true</c> if [create prompt]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CreatePrompt
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether [overwrite prompt].
		/// </summary>
		/// true</c> if [overwrite prompt]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool OverwritePrompt
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Opens a file.
		/// </summary>
		/// </returns>
		public Stream OpenFile()
		{
			if (base.File == null)
			{
				throw new ArgumentNullException();
			}
			return base.File.InputStream;
		}

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			FileHandle file = base.File;
			if (file != null)
			{
				if (mobjSaveFileDialogForm == null)
				{
					mobjSaveFileDialogForm = new SaveFileDialogForm(this);
				}
				Link.Download(new GatewayResourceHandle(mobjSaveFileDialogForm, "download"), file.FileName);
			}
			return null;
		}

		/// 
		/// Resets all properties to their default values.
		/// </summary>
		public override void Reset()
		{
			base.Reset();
			SetOption(2, blnValue: true);
		}
	}
}
