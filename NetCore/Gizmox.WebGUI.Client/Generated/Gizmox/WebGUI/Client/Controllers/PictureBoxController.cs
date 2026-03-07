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

namespace Gizmox.WebGUI.Client.Controllers
{
	public class PictureBoxController : ControlController
	{
		public Gizmox.WebGUI.Forms.PictureBox WebPictureBox => base.SourceObject as Gizmox.WebGUI.Forms.PictureBox;

		public System.Windows.Forms.PictureBox WinPictureBox => base.TargetObject as System.Windows.Forms.PictureBox;

		public PictureBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public PictureBoxController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPictureBoxImage();
			SetWinPictureBoxSizeMode();
		}

		protected virtual void SetWinPictureBoxImage()
		{
			if (WebPictureBox.Image != null)
			{
				WinPictureBox.Image = GetWinImageFromResourceHandle(WebPictureBox.Image);
			}
			else
			{
				WinPictureBox.Image = null;
			}
		}

		protected virtual void SetWinPictureBoxSizeMode()
		{
			WinPictureBox.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.PictureBoxSizeMode), WebPictureBox.SizeMode, WebPictureBox.SizeMode);
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinPictureBox.SizeModeChanged -= WinPictureBox_SizeModeChanged;
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinPictureBox.SizeModeChanged += WinPictureBox_SizeModeChanged;
		}

		private void WinPictureBox_SizeModeChanged(object sender, EventArgs e)
		{
			if (WinPictureBox.SizeMode == System.Windows.Forms.PictureBoxSizeMode.AutoSize)
			{
				SetWebControlSize();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.PictureBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Image"))
			{
				if (property == "SizeMode")
				{
					SetWinPictureBoxSizeMode();
				}
			}
			else
			{
				SetWinPictureBoxImage();
			}
		}
	}
}
