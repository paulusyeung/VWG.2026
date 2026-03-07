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
	public class ButtonBaseControler : ControlController
	{
		public Gizmox.WebGUI.Forms.ButtonBase WebButtonBase => base.SourceObject as Gizmox.WebGUI.Forms.ButtonBase;

		public System.Windows.Forms.ButtonBase WinButtonBase => base.TargetObject as System.Windows.Forms.ButtonBase;

		public ButtonBaseControler(IContext objContext, object objWebButtonBase, object objWinButtonBase)
			: base(objContext, objWebButtonBase, objWinButtonBase)
		{
		}

		public ButtonBaseControler(IContext objContext, object objWebButtonBase)
			: base(objContext, objWebButtonBase)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinButtonBaseTextImageRelation();
			SetWinButtonBaseImage();
			SetWinButtonBaseImageIndex();
			SetWinButtonBaseImageKey();
			SetWinButtonBaseImageAlign();
			SetWinButtonBaseUseVisualStyleBackColor();
			SetWinButtonBaseTextAlign();
		}

		private void SetWinButtonBaseTextAlign()
		{
			WinButtonBase.TextAlign = WebButtonBase.TextAlign;
		}

		private void SetWebButtonBaseUseVisualStyleBackColor()
		{
			WebButtonBase.UseVisualStyleBackColor = WinButtonBase.UseVisualStyleBackColor;
		}

		private void SetWinButtonBaseUseVisualStyleBackColor()
		{
			WinButtonBase.UseVisualStyleBackColor = WebButtonBase.UseVisualStyleBackColor;
		}

		protected virtual void SetWinButtonBaseTextImageRelation()
		{
			WinButtonBase.TextImageRelation = (System.Windows.Forms.TextImageRelation)GetConvertedEnum(typeof(System.Windows.Forms.TextImageRelation), WebButtonBase.TextImageRelation);
		}

		protected virtual void SetWinButtonBaseImageAlign()
		{
			WinButtonBase.ImageAlign = (ContentAlignment)GetConvertedEnum(typeof(ContentAlignment), WebButtonBase.ImageAlign);
		}

		protected virtual void SetWinButtonBaseImageIndex()
		{
			if (WebButtonBase.ImageIndex != -1)
			{
				if (WinButtonBase.ImageList == null)
				{
					WinButtonBase.ImageList = new System.Windows.Forms.ImageList();
				}
				WinButtonBase.ImageIndex = GetWinImageIndex(WinButtonBase.ImageList, WebButtonBase.Image);
			}
			else if (WinButtonBase.ImageIndex != -1)
			{
				WinButtonBase.ImageIndex = -1;
			}
		}

		protected virtual void SetWinButtonBaseImageKey()
		{
			if (WebButtonBase.ImageKey != string.Empty)
			{
				if (WinButtonBase.ImageList == null)
				{
					WinButtonBase.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(WinButtonBase.ImageList, WebButtonBase.Image, WebButtonBase.ImageKey) > -1)
				{
					WinButtonBase.ImageKey = WebButtonBase.ImageKey;
				}
			}
			else if (WinButtonBase.ImageKey != string.Empty)
			{
				WinButtonBase.ImageKey = string.Empty;
			}
		}

		protected virtual void SetWinButtonBaseImage()
		{
			if (WebButtonBase.Image != null)
			{
				WinButtonBase.Image = GetWinImageFromResourceHandle(WebButtonBase.Image);
			}
			else if (WinButtonBase.Image != null)
			{
				WinButtonBase.Image = null;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Image":
				SetWinButtonBaseImage();
				break;
			case "ImageIndex":
				SetWinButtonBaseImageIndex();
				break;
			case "ImageKey":
				SetWinButtonBaseImageKey();
				break;
			case "TextImageRelation":
				SetWinButtonBaseTextImageRelation();
				break;
			case "ImageAlign":
				SetWinButtonBaseImageAlign();
				break;
			case "UseVisualStyleBackColor":
				SetWinButtonBaseUseVisualStyleBackColor();
				break;
			case "TextAlign":
				SetWinButtonBaseTextAlign();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "UseVisualStyleBackColor")
			{
				SetWebButtonBaseUseVisualStyleBackColor();
			}
		}
	}
}
