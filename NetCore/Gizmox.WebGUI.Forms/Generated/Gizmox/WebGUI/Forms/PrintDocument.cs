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
	[DefaultProperty("DocumentName")]
	[SRDescription("PrintDocumentDesc")]
	[DefaultEvent("PrintPage")]
	public class PrintDocument : Component
	{
		private string mstrDocumentName = "this";

		private PageSettings mobjDefaultPageSettings = null;

		private PrinterSettings mobjPrinterSettings = null;

		private List<Bitmap> mobjBitmapsList = null;

		private Dictionary<PrintPageEventArgs, Graphics> mobjGraphicsDictionary = null;

		private bool mblnUserSetPageSettings;

		private static readonly SerializableEvent BeginPrintEvent;

		private static readonly SerializableEvent EndPrintEvent;

		private static readonly SerializableEvent PrintPageEvent;

		private static readonly SerializableEvent QueryPageSettingsEvent;

		/// 
		/// Gets the bitmaps list.
		/// </summary>
		/// The bitmaps list.</value>
		internal List<Bitmap> BitmapsList
		{
			get
			{
				if (mobjBitmapsList == null)
				{
					mobjBitmapsList = new List<Bitmap>();
				}
				return mobjBitmapsList;
			}
		}

		/// 
		/// Gets the graphics dictionary.
		/// </summary>
		/// The graphics dictionary.</value>
		private Dictionary<PrintPageEventArgs, Graphics> GraphicsDictionary
		{
			get
			{
				if (mobjGraphicsDictionary == null)
				{
					mobjGraphicsDictionary = new Dictionary<PrintPageEventArgs, Graphics>();
				}
				return mobjGraphicsDictionary;
			}
		}

		/// 
		/// Gets the begin print handler.
		/// </summary>
		/// The begin print handler.</value>
		private PrintEventHandler BeginPrintHandler => (PrintEventHandler)GetHandler(BeginPrintEvent);

		/// 
		/// Gets or sets the default page settings.
		/// </summary>
		/// The default page settings.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("PDOCdocumentPageSettingsDescr")]
		[Browsable(false)]
		public PageSettings DefaultPageSettings
		{
			get
			{
				return mobjDefaultPageSettings;
			}
			set
			{
				if (value == null)
				{
					value = new PageSettings();
				}
				mobjDefaultPageSettings = value;
				mblnUserSetPageSettings = true;
			}
		}

		/// 
		/// Gets or sets the name of the this.
		/// </summary>
		/// The name of the this.</value>
		[SRDescription("PDOCdocumentNameDescr")]
		[DefaultValue("this")]
		public string DocumentName
		{
			get
			{
				return mstrDocumentName;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				mstrDocumentName = value;
			}
		}

		/// 
		/// Gets the end print handler.
		/// </summary>
		/// The end print handler.</value>
		private PrintEventHandler EndPrintHandler => (PrintEventHandler)GetHandler(EndPrintEvent);

		/// 
		/// Gets or sets a value indicating whether [origin at margins].
		/// </summary>
		/// true</c> if [origin at margins]; otherwise, false</c>.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool OriginAtMargins
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
		/// Gets or sets the print controller.
		/// </summary>
		/// The print controller.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintController PrintController
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the printer settings.
		/// </summary>
		/// The printer settings.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrinterSettings PrinterSettings
		{
			get
			{
				return mobjPrinterSettings;
			}
			set
			{
				if (value == null)
				{
					value = new PrinterSettings();
				}
				mobjPrinterSettings = value;
				if (!mblnUserSetPageSettings)
				{
					mobjDefaultPageSettings = mobjPrinterSettings.DefaultPageSettings;
				}
			}
		}

		/// 
		/// Gets the print page handler.
		/// </summary>
		/// The print page handler.</value>
		private PrintPageEventHandler PrintPageHandler => (PrintPageEventHandler)GetHandler(PrintPageEvent);

		/// 
		/// Gets the begin print handler.
		/// </summary>
		/// The begin print handler.</value>
		private QueryPageSettingsEventHandler QueryPageSettingsHandler => (QueryPageSettingsEventHandler)GetHandler(QueryPageSettingsEvent);

		/// 
		/// Occurs when [begin print].
		/// </summary>
		[SRDescription("PDOCbeginPrintDescr")]
		public event PrintEventHandler BeginPrint
		{
			add
			{
				AddCriticalHandler(BeginPrintEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(BeginPrintEvent, value);
			}
		}

		/// 
		/// Occurs when [end print].
		/// </summary>
		[SRDescription("PDOCendPrintDescr")]
		public event PrintEventHandler EndPrint
		{
			add
			{
				AddCriticalHandler(EndPrintEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(EndPrintEvent, value);
			}
		}

		/// 
		/// Occurs when [print page].
		/// </summary>
		[SRDescription("PDOCprintPageDescr")]
		public event PrintPageEventHandler PrintPage
		{
			add
			{
				AddCriticalHandler(PrintPageEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(PrintPageEvent, value);
			}
		}

		/// 
		/// Occurs when [query page settings].
		/// </summary>
		[SRDescription("PDOCqueryPageSettingsDescr")]
		public event QueryPageSettingsEventHandler QueryPageSettings
		{
			add
			{
				AddCriticalHandler(QueryPageSettingsEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(QueryPageSettingsEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PrintDocument" /> class.
		/// </summary>
		public PrintDocument()
		{
			mstrDocumentName = "document";
			mobjPrinterSettings = new PrinterSettings();
			mobjDefaultPageSettings = new PageSettings(mobjPrinterSettings);
		}

		/// 
		/// Prints this instance.
		/// </summary>
		public void Print()
		{
			ClearLists();
			PrintEventArgs e = new PrintEventArgs();
			OnBeginPrint(e);
			if (e.Cancel)
			{
				OnEndPrint(e);
				return;
			}
			bool flag = true;
			try
			{
				flag = PrintLoop();
			}
			finally
			{
				OnEndPrint(e);
				e.Cancel = flag | e.Cancel;
			}
		}

		/// 
		/// Clears the lists.
		/// </summary>
		private void ClearLists()
		{
			if (mobjBitmapsList != null)
			{
				mobjBitmapsList.Clear();
			}
			if (mobjGraphicsDictionary != null)
			{
				mobjGraphicsDictionary.Clear();
			}
		}

		/// 
		/// Creates the print page event.
		/// </summary>
		/// <param name="objPageSettings">The obj page settings.</param>
		/// </returns>
		private PrintPageEventArgs CreatePrintPageEvent(PageSettings objPageSettings)
		{
			Rectangle pageBounds = Rectangle.Empty;
			if (VWGContext.Current is IContextParams contextParams)
			{
				pageBounds = new Rectangle(Point.Empty, new Size(contextParams.ScreenAvailableWidth, contextParams.ScreenAvailableHeight));
			}
			Bitmap bitmap = new Bitmap(pageBounds.Width, pageBounds.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			PrintPageEventArgs e = new PrintPageEventArgs(graphics, new Rectangle(0, 0, pageBounds.Width, pageBounds.Height), pageBounds, objPageSettings);
			BitmapsList.Add(bitmap);
			GraphicsDictionary.Add(e, graphics);
			return e;
		}

		/// 
		/// Prints in loop all pages.
		/// </summary>
		/// </returns>
		private bool PrintLoop()
		{
			PrintPageEventArgs e = null;
			QueryPageSettingsEventArgs e2 = new QueryPageSettingsEventArgs(DefaultPageSettings.Clone() as PageSettings);
			do
			{
				OnQueryPageSettings(e2);
				if (e2.Cancel)
				{
					return true;
				}
				e = CreatePrintPageEvent(e2.PageSettings);
				try
				{
					OnPrintPage(e);
				}
				finally
				{
					if (GraphicsDictionary.ContainsKey(e))
					{
						GraphicsDictionary[e]?.Dispose();
						GraphicsDictionary.Remove(e);
					}
				}
				if (e.Cancel)
				{
					return true;
				}
			}
			while (e.HasMorePages);
			return false;
		}

		/// 
		/// Toes the string.
		/// </summary>
		/// </returns>
		public override string ToString()
		{
			return "[PrintDocument " + DocumentName + "]";
		}

		/// 
		/// Raises the <see cref="E:BeginPrint" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Drawing.Printing.PrintEventArgs" /> instance containing the event data.</param>
		protected virtual void OnBeginPrint(PrintEventArgs e)
		{
			BeginPrintHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:EndPrint" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Drawing.Printing.PrintEventArgs" /> instance containing the event data.</param>
		protected virtual void OnEndPrint(PrintEventArgs e)
		{
			EndPrintHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:PrintPage" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Drawing.Printing.PrintPageEventArgs" /> instance containing the event data.</param>
		protected virtual void OnPrintPage(PrintPageEventArgs e)
		{
			PrintPageHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:QueryPageSettings" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Drawing.Printing.QueryPageSettingsEventArgs" /> instance containing the event data.</param>
		protected virtual void OnQueryPageSettings(QueryPageSettingsEventArgs e)
		{
			QueryPageSettingsHandler?.Invoke(this, e);
		}

		static PrintDocument()
		{
			BeginPrintEvent = SerializableEvent.Register("BeginPrint", typeof(PrintEventHandler), typeof(PrintDocument));
			EndPrintEvent = SerializableEvent.Register("EndPrint", typeof(PrintEventHandler), typeof(PrintDocument));
			PrintPageEvent = SerializableEvent.Register("PrintPage", typeof(PrintPageEventHandler), typeof(PrintDocument));
			QueryPageSettingsEvent = SerializableEvent.Register("QueryPageSettings", typeof(QueryPageSettingsEventHandler), typeof(PrintDocument));
		}
	}
}
