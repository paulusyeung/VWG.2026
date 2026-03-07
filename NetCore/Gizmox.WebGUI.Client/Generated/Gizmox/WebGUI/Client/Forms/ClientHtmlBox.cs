using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client.Forms
{
	public class ClientHtmlBox : WebBrowser
	{
		private string mstrHtml = "";

		private string mstrTempDir = null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.Cursor Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
			}
		}

		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
			}
		}

		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
			}
		}

		public string Html
		{
			get
			{
				return mstrHtml;
			}
			set
			{
				if (mstrHtml != value)
				{
					mstrHtml = value;
					File.WriteAllText(TempFile, mstrHtml);
					base.Url = new Uri($"file://{TempFile}");
				}
			}
		}

		private string TempDirectory
		{
			get
			{
				if (mstrTempDir == null)
				{
					mstrTempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
					Directory.CreateDirectory(mstrTempDir);
				}
				return mstrTempDir;
			}
		}

		private string TempFile => Path.Combine(TempDirectory, "Index.htm");

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			try
			{
				if (mstrTempDir != null && Directory.Exists(mstrTempDir))
				{
					Directory.Delete(mstrTempDir, recursive: true);
					mstrTempDir = null;
				}
			}
			catch (Exception)
			{
			}
			base.Dispose(disposing);
		}
	}
}
