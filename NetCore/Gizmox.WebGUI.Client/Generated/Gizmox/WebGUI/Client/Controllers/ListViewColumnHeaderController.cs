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
	public class ListViewColumnHeaderController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ColumnHeader WebColumnHeader => base.SourceObject as Gizmox.WebGUI.Forms.ColumnHeader;

		public System.Windows.Forms.ColumnHeader WinColumnHeader => base.TargetObject as System.Windows.Forms.ColumnHeader;

		public ListViewColumnHeaderController(IContext objContext, object objWebListView, object objWinListView)
			: base(objContext, objWebListView, objWinListView)
		{
		}

		public ListViewColumnHeaderController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnHeaderText();
			SetWinColumnHeaderWidth();
			SetWinColumnHeaderImageKey();
			SetWinColumnHeaderImageIndex();
		}

		private void SetWinColumnHeaderImageIndex()
		{
			EnsureWinListViewImageList();
			WinColumnHeader.ImageIndex = GetWinImageIndex(WinColumnHeader.ImageList, WebColumnHeader.Image);
		}

		private void EnsureWinListViewImageList()
		{
			if (WebColumnHeader.Image != null && WinColumnHeader.ListView != null && WinColumnHeader.ListView.SmallImageList == null)
			{
				WinColumnHeader.ListView.SmallImageList = new System.Windows.Forms.ImageList();
			}
		}

		private void SetWinColumnHeaderImageKey()
		{
			EnsureWinListViewImageList();
			if (GetWinImageIndex(WinColumnHeader.ImageList, WebColumnHeader.Image, WebColumnHeader.ImageKey) > -1)
			{
				WinColumnHeader.ImageKey = WebColumnHeader.ImageKey;
			}
			else
			{
				WinColumnHeader.ImageKey = string.Empty;
			}
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinColumnHeaderText();
				break;
			case "Width":
				SetWinColumnHeaderWidth();
				break;
			case "ImageKey":
				SetWinColumnHeaderImageKey();
				break;
			case "ImageIndex":
				SetWinColumnHeaderImageIndex();
				break;
			}
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetWebColumnHeaderWidth();
			}
		}

		protected virtual void SetWinColumnHeaderText()
		{
			WinColumnHeader.Text = WebColumnHeader.Text;
		}

		protected virtual void SetWinColumnHeaderWidth()
		{
			WinColumnHeader.Width = Convert.ToInt32((float)WebColumnHeader.Width * base.TargetHorizontalScaleFactor);
		}

		protected virtual void SetWebColumnHeaderWidth()
		{
			SetWebProperty("Width", Convert.ToInt32((float)WinColumnHeader.Width / base.TargetHorizontalScaleFactor));
		}
	}
}
