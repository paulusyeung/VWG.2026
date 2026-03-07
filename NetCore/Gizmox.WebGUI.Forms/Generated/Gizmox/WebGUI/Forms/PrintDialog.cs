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
	[SRDescription("DescriptionPrintDialog")]
	[DefaultProperty("Document")]
	[ToolboxBitmap(typeof(PrintDialog), "PrintDialog_45.bmp")]
	[ToolboxItem(true)]
	public sealed class PrintDialog : CommonDialog
	{
		/// 
		///
		/// </summary>
		[Serializable]
		protected sealed class PrintDialogForm : CommonDialogForm
		{
			/// 
			/// Initializes a new instance of the <see cref="!:SaveFileDialogForm" /> class.
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public PrintDialogForm(CommonDialog objCommonDialog)
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
				if (base.CommonDialogOwner is PrintDialog { Document: var document })
				{
					if (document != null)
					{
						List<object> bitmapsList = document.BitmapsList;
						if (bitmapsList != null && bitmapsList.Count > 0)
						{
							if (strAction == "print")
							{
								ProcessPrintRequest(objHostContext, document, bitmapsList);
							}
							else if (strAction.StartsWith("page"))
							{
								ProcessPageRequest(objHostContext, strAction, bitmapsList);
							}
						}
					}
					return null;
				}
				return base.ProcessGatewayRequest(objHostContext, strAction);
			}

			/// 
			/// Processes the page request.
			/// </summary>
			/// <param name="objHostContext">The obj host context.</param>
			/// <param name="strAction">The STR action.</param>
			/// <param name="objBitmapsList">The obj bitmaps list.</param>
			private static void ProcessPageRequest(HostContext objHostContext, string strAction, List<object> objBitmapsList)
			{
				int result = -1;
				if (int.TryParse(strAction.Substring(4), out result) && result < objBitmapsList.Count)
				{
					Bitmap bitmap = objBitmapsList[result];
					if (bitmap != null)
					{
						objHostContext.Response.ContentType = CommonUtils.GetMimeType(ImageFormat.Png);
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Png);
						memoryStream.WriteTo(objHostContext.Response.OutputStream);
					}
				}
			}

			/// 
			/// Processes the print request.
			/// </summary>
			/// <param name="objHostContext">The obj host context.</param>
			/// <param name="objPrintDocument">The obj print document.</param>
			/// <param name="objBitmapsList">The obj bitmaps list.</param>
			private static void ProcessPrintRequest(HostContext objHostContext, PrintDocument objPrintDocument, List<object> objBitmapsList)
			{
				objHostContext.Response.ContentType = "text/html";
				objHostContext.Response.Expires = -1;
				HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objHostContext.Response.OutputStream, Encoding.UTF8));
				if (htmlTextWriter == null)
				{
					return;
				}
				htmlTextWriter.WriteLine("<!DOCTYPE html>");
				htmlTextWriter.WriteFullBeginTag("html");
				htmlTextWriter.WriteFullBeginTag("head");
				htmlTextWriter.WriteFullBeginTag("title");
				htmlTextWriter.Write(objPrintDocument.DocumentName);
				htmlTextWriter.WriteEndTag("title");
				htmlTextWriter.WriteEndTag("head");
				htmlTextWriter.WriteBeginTag("body");
				htmlTextWriter.WriteAttribute("onload", "window.print(); window.close();");
				htmlTextWriter.WriteFullBeginTag("table");
				string text = objHostContext.Request.Url.LocalPath.TrimStart('/');
				foreach (Bitmap objBitmaps in objBitmapsList)
				{
					htmlTextWriter.WriteFullBeginTag("tr");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.WriteBeginTag("img");
					htmlTextWriter.WriteAttribute("src", text.Replace(".print.", $".page{objBitmapsList.IndexOf(objBitmaps).ToString()}."));
					htmlTextWriter.WriteEndTag("img");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteEndTag("tr");
				}
				htmlTextWriter.WriteEndTag("table");
				htmlTextWriter.WriteEndTag("body");
				htmlTextWriter.WriteEndTag("html");
				htmlTextWriter.Flush();
			}
		}

		private PrintDialogForm mobjPrintDialogForm = null;

		private PrintDocument mobjPrintDocument = null;

		private bool mblnPrintToFile = false;

		/// 
		/// Gets or sets a value indicating whether [allow current page].
		/// </summary>
		/// true</c> if [allow current page]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowCurrentPage
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
		/// Gets or sets a value indicating whether [allow print to file].
		/// </summary>
		/// true</c> if [allow print to file]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowPrintToFile
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
		/// Gets or sets a value indicating whether [allow selection].
		/// </summary>
		/// true</c> if [allow selection]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowSelection
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
		/// Gets or sets a value indicating whether [allow some pages].
		/// </summary>
		/// true</c> if [allow some pages]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowSomePages
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
		/// Gets or sets the document.
		/// </summary>
		/// The document.</value>
		[DefaultValue(null)]
		[SRDescription("PDdocumentDescr")]
		[SRCategory("CatData")]
		public PrintDocument Document
		{
			get
			{
				return mobjPrintDocument;
			}
			set
			{
				mobjPrintDocument = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [print to file].
		/// </summary>
		/// true</c> if [print to file]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		[SRDescription("PDprintToFileDescr")]
		[SRCategory("CatBehavior")]
		public bool PrintToFile
		{
			get
			{
				return mblnPrintToFile;
			}
			set
			{
				mblnPrintToFile = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show help].
		/// </summary>
		/// true</c> if [show help]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowHelp
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
		/// Gets or sets a value indicating whether [show network].
		/// </summary>
		/// true</c> if [show network]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowNetwork
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
		/// Gets or sets a value indicating whether [use EX dialog].
		/// </summary>
		/// true</c> if [use EX dialog]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool UseEXDialog
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
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PrintDialog" /> class.
		/// </summary>
		public PrintDialog()
		{
			Reset();
		}

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			PrintDocument document = Document;
			if (document != null)
			{
				if (mobjPrintDialogForm == null)
				{
					mobjPrintDialogForm = new PrintDialogForm(this);
				}
				LinkParameters linkParameters = new LinkParameters(LinkWindowStyle.Normal, new Size(50, 50));
				linkParameters.Target = "_blank";
				Link.Open(new GatewayReference(mobjPrintDialogForm, "print"), linkParameters);
			}
			return null;
		}

		/// 
		/// When overridden in a derived class, resets the properties of a common dialog box to their default values.
		/// </summary>
		public override void Reset()
		{
			mobjPrintDocument = null;
			mblnPrintToFile = false;
		}
	}
}
