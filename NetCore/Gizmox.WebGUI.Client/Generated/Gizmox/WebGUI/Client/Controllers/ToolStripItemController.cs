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
	public class ToolStripItemController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ToolStripItem WebToolStripItem => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripItem;

		public System.Windows.Forms.ToolStripItem WinToolStripItem => base.TargetObject as System.Windows.Forms.ToolStripItem;

		public ToolStripItemController(IContext objContext, object objWebToolStripItem, object objWinToolStripItem)
			: base(objContext, objWebToolStripItem, objWinToolStripItem)
		{
		}

		public ToolStripItemController(IContext objContext, object objWebToolStripItem)
			: base(objContext, objWebToolStripItem)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return null;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinToolStripItemAutoSize();
				break;
			case "Alignment":
				SetWinToolStripItemAlignment();
				break;
			case "Anchor":
				SetWinToolStripItemAnchor();
				break;
			case "Available":
				SetWinToolStripItemAvailable();
				break;
			case "BackColor":
				SetWinToolStripItemBackColor();
				break;
			case "BackgroundImage":
				SetWinToolStripItemBackgroundImage();
				break;
			case "BackgroundImageLayout":
				SetWinToolStripItemBackgroundImageLayout();
				break;
			case "DisplayStyle":
				SetWinToolStripItemDisplayStyle();
				break;
			case "Dock":
				SetWinToolStripItemDock();
				break;
			case "Enabled":
				SetWinToolStripItemEnabled();
				break;
			case "Font":
				SetWinToolStripItemFont();
				break;
			case "ForeColor":
				SetWinToolStripItemForeColor();
				break;
			case "Height":
				SetWinToolStripItemHeight();
				break;
			case "Image":
				SetWinToolStripItemImage();
				break;
			case "ImageAlign":
				SetWinToolStripItemImageAlign();
				break;
			case "ImageIndex":
				SetWinToolStripItemImageIndex();
				break;
			case "ImageKey":
				SetWinToolStripItemImageKey();
				break;
			case "ImageScaling":
				SetWinToolStripItemImageScaling();
				break;
			case "MergeAction":
				SetWinToolStripItemMergeAction();
				break;
			case "MergeIndex":
				SetWinToolStripItemMergeIndex();
				break;
			case "Name":
				SetWinToolStripItemName();
				break;
			case "Padding":
				SetWinToolStripItemPadding();
				break;
			case "RightToLeft":
				SetWinToolStripItemRightToLeft();
				break;
			case "RightToLeftAutoMirrorImage":
				SetWinToolStripItemRightToLeftAutoMirrorImage();
				break;
			case "Size":
				SetWinToolStripItemSize();
				break;
			case "Text":
				SetWinToolStripItemText();
				break;
			case "TextAlign":
				SetWinToolStripItemTextAlign();
				break;
			case "TextDirection":
				SetWinToolStripItemTextDirection();
				break;
			case "TextImageRelation":
				SetWinToolStripItemTextImageRelation();
				break;
			case "ToolTipText":
				SetWinToolStripItemToolTipText();
				break;
			case "Width":
				SetWinToolStripItemWidth();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebToolStripItemText();
			}
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWebToolStripItemName();
		}

		private void SetWebToolStripItemText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WebToolStripItem.Text = WinToolStripItem.Text;
			}
		}

		private void SetWebToolStripItemName()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WebToolStripItem.Name = WinToolStripItem.Name;
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripItemAutoSize();
			SetWinToolStripItemAlignment();
			SetWinToolStripItemAnchor();
			SetWinToolStripItemAvailable();
			SetWinToolStripItemBackColor();
			SetWinToolStripItemBackgroundImage();
			SetWinToolStripItemBackgroundImageLayout();
			SetWinToolStripItemDisplayStyle();
			SetWinToolStripItemDock();
			SetWinToolStripItemEnabled();
			SetWinToolStripItemFont();
			SetWinToolStripItemForeColor();
			SetWinToolStripItemImageAlign();
			SetWinToolStripItemImageIndex();
			SetWinToolStripItemImageKey();
			SetWinToolStripItemImageScaling();
			SetWinToolStripItemImage();
			SetWinToolStripItemMergeAction();
			SetWinToolStripItemMergeIndex();
			SetWinToolStripItemName();
			SetWinToolStripItemPadding();
			SetWinToolStripItemRightToLeft();
			SetWinToolStripItemRightToLeftAutoMirrorImage();
			SetWinToolStripItemSize();
			SetWinToolStripItemText();
			SetWinToolStripItemTextAlign();
			SetWinToolStripItemTextDirection();
			SetWinToolStripItemTextImageRelation();
			SetWinToolStripItemToolTipText();
			InitializeWinToolStripItemVisiblity();
		}

		protected virtual void SetWinToolStripItemAutoSize()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.AutoSize = WebToolStripItem.AutoSize;
			}
		}

		protected virtual void SetWinToolStripItemAlignment()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Alignment = (System.Windows.Forms.ToolStripItemAlignment)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemAlignment), WebToolStripItem.Alignment);
			}
		}

		protected virtual void SetWinToolStripItemAnchor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Anchor = (System.Windows.Forms.AnchorStyles)GetConvertedEnum(typeof(System.Windows.Forms.AnchorStyles), WebToolStripItem.Anchor);
			}
		}

		protected virtual void SetWinToolStripItemAvailable()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Available = WebToolStripItem.Available;
			}
		}

		protected virtual void SetWinToolStripItemBackColor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WebToolStripItem.BackColor != Color.Transparent)
			{
				WinToolStripItem.BackColor = WebToolStripItem.BackColor;
			}
		}

		protected virtual void SetWinToolStripItemBackgroundImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.BackgroundImage = GetWinImageFromResourceHandle(WebToolStripItem.BackgroundImage);
			}
		}

		protected virtual void SetWinToolStripItemBackgroundImageLayout()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.BackgroundImageLayout = (System.Windows.Forms.ImageLayout)GetConvertedEnum(typeof(System.Windows.Forms.ImageLayout), WebToolStripItem.BackgroundImageLayout);
			}
		}

		protected virtual void SetWinToolStripItemDisplayStyle()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.DisplayStyle = (System.Windows.Forms.ToolStripItemDisplayStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemDisplayStyle), WebToolStripItem.DisplayStyle);
			}
		}

		protected virtual void SetWinToolStripItemDock()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Dock = (System.Windows.Forms.DockStyle)GetConvertedEnum(typeof(System.Windows.Forms.DockStyle), WebToolStripItem.Dock);
			}
		}

		protected virtual void SetWinToolStripItemEnabled()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Enabled = WebToolStripItem.Enabled;
			}
		}

		protected virtual void SetWinToolStripItemFont()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				if (WebToolStripItem.Font == null)
				{
					WinToolStripItem.Font = null;
				}
				else
				{
					WinToolStripItem.Font = new Font(WebToolStripItem.Font.FontFamily, WebToolStripItem.Font.Size * base.TargetVerticalScaleFactor);
				}
			}
		}

		protected virtual void SetWinToolStripItemForeColor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ForeColor = WebToolStripItem.ForeColor;
			}
		}

		protected virtual void SetWinToolStripItemHeight()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Height = Convert.ToInt32((float)WebToolStripItem.Height * base.TargetVerticalScaleFactor);
			}
		}

		protected virtual void SetWinToolStripItemImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Image = GetWinImageFromResourceHandle(WebToolStripItem.Image);
			}
		}

		protected virtual void SetWinToolStripItemImageAlign()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageAlign = WebToolStripItem.ImageAlign;
			}
		}

		protected virtual void SetWinToolStripItemImageIndex()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageIndex = WebToolStripItem.ImageIndex;
			}
		}

		protected virtual void SetWinToolStripItemImageKey()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageKey = WebToolStripItem.ImageKey;
			}
		}

		protected virtual void SetWinToolStripItemImageScaling()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageScaling = (System.Windows.Forms.ToolStripItemImageScaling)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemImageScaling), WebToolStripItem.ImageScaling);
			}
		}

		protected virtual void SetWinToolStripItemMergeAction()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.MergeAction = (System.Windows.Forms.MergeAction)GetConvertedEnum(typeof(System.Windows.Forms.MergeAction), WebToolStripItem.MergeAction);
			}
		}

		protected virtual void SetWinToolStripItemMergeIndex()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.MergeIndex = WebToolStripItem.MergeIndex;
			}
		}

		protected virtual void SetWinToolStripItemName()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Name = WebToolStripItem.Name;
			}
		}

		protected virtual void SetWinToolStripItemPadding()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				Gizmox.WebGUI.Forms.Padding padding = WebToolStripItem.Padding;
				bool flag = true;
				WinToolStripItem.Padding = new System.Windows.Forms.Padding(padding.Left, padding.Top, padding.Right, padding.Bottom);
			}
		}

		protected virtual void SetWinToolStripItemRightToLeft()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.RightToLeft = (System.Windows.Forms.RightToLeft)GetConvertedEnum(typeof(System.Windows.Forms.RightToLeft), WebToolStripItem.RightToLeft);
			}
		}

		protected virtual void SetWinToolStripItemRightToLeftAutoMirrorImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.RightToLeftAutoMirrorImage = WebToolStripItem.RightToLeftAutoMirrorImage;
			}
		}

		protected virtual void SetWinToolStripItemSize()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				Size size = WebToolStripItem.Size;
				WinToolStripItem.Size = new Size(Convert.ToInt32((float)size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)size.Height * base.TargetVerticalScaleFactor));
			}
		}

		protected virtual void SetWinToolStripItemText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WinToolStripItem.Text != WebToolStripItem.Text)
			{
				WinToolStripItem.Text = WebToolStripItem.Text;
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinToolStripItem.TextChanged += WinToolStripItem_TextChanged;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinToolStripItem.TextChanged -= WinToolStripItem_TextChanged;
		}

		private void WinToolStripItem_TextChanged(object sender, EventArgs e)
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WinToolStripItem.AutoSize)
			{
				Size preferredSize = WinToolStripItem.GetPreferredSize(WinToolStripItem.Size);
				WebToolStripItem.Size = new Size(Convert.ToInt32((float)preferredSize.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)preferredSize.Height / base.TargetVerticalScaleFactor));
			}
		}

		protected virtual void SetWinToolStripItemTextAlign()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextAlign = WebToolStripItem.TextAlign;
			}
		}

		protected virtual void SetWinToolStripItemTextDirection()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextDirection = (System.Windows.Forms.ToolStripTextDirection)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripTextDirection), WebToolStripItem.TextDirection);
			}
		}

		protected virtual void SetWinToolStripItemTextImageRelation()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextImageRelation = (System.Windows.Forms.TextImageRelation)GetConvertedEnum(typeof(System.Windows.Forms.TextImageRelation), WebToolStripItem.TextImageRelation);
			}
		}

		protected virtual void SetWinToolStripItemToolTipText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ToolTipText = WebToolStripItem.ToolTipText;
			}
		}

		protected virtual void InitializeWinToolStripItemVisiblity()
		{
			if (WinToolStripItem != null)
			{
				WinToolStripItem.Visible = true;
			}
		}

		protected virtual void SetWinToolStripItemWidth()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Width = Convert.ToInt32((float)WebToolStripItem.Width * base.TargetHorizontalScaleFactor);
			}
		}
	}
}
