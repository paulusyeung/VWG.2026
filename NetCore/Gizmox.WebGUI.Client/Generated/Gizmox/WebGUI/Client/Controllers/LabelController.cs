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
	public class LabelController : ControlController
	{
		public Gizmox.WebGUI.Forms.Label WebLabel => base.SourceObject as Gizmox.WebGUI.Forms.Label;

		public System.Windows.Forms.Label WinLabel => base.TargetObject as System.Windows.Forms.Label;

		public LabelController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public LabelController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void SetWinControlBorderStyle()
		{
			if (Enum.GetName(typeof(System.Windows.Forms.BorderStyle), WebLabel.BorderStyle) != null)
			{
				WinLabel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebLabel.BorderStyle, WinLabel.BorderStyle);
			}
		}

		protected virtual void SetWinLabelImage()
		{
			if (WebLabel.Image != null)
			{
				WinLabel.Image = GetWinImageFromResourceHandle(WebLabel.Image);
			}
			else
			{
				WinLabel.Image = null;
			}
		}

		protected virtual void SetWinLabelImageIndex()
		{
			if (WebLabel.Image != null)
			{
				if (WinLabel.ImageList == null)
				{
					WinLabel.ImageList = new System.Windows.Forms.ImageList();
				}
				WinLabel.ImageIndex = GetWinImageIndex(WinLabel.ImageList, WebLabel.Image);
			}
			else
			{
				WinLabel.ImageIndex = -1;
			}
		}

		protected virtual void SetWinLabelImageKey()
		{
			if (WebLabel.Image != null)
			{
				if (WinLabel.ImageList == null)
				{
					WinLabel.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(WinLabel.ImageList, WebLabel.Image, WebLabel.ImageKey) > -1)
				{
					WinLabel.ImageKey = WebLabel.ImageKey;
				}
			}
			else
			{
				WinLabel.ImageKey = string.Empty;
			}
		}

		private void SetWinLabelImageAlign()
		{
			WinLabel.ImageAlign = (ContentAlignment)GetConvertedEnum(typeof(ContentAlignment), WebLabel.ImageAlign);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinLabelTextAlign();
			SetWinLabelImage();
			SetWinLabelImageIndex();
			SetWinLabelImageKey();
			SetWinLabelImageAlign();
		}

		protected virtual void SetWinLabelTextAlign()
		{
			WinLabel.TextAlign = WebLabel.TextAlign;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.Label();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "TextAlign":
				SetWinLabelTextAlign();
				break;
			case "Image":
				SetWinLabelImage();
				break;
			case "ImageIndex":
				SetWinLabelImageIndex();
				break;
			case "ImageKey":
				SetWinLabelImageKey();
				break;
			case "ImageAlign":
				SetWinLabelImageAlign();
				break;
			}
		}
	}
}
