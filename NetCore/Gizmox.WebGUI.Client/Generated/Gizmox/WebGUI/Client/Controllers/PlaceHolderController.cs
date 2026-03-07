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
	public class PlaceHolderController : ControlController
	{
		public PlaceHolderController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public PlaceHolderController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			System.Windows.Forms.Button button = new System.Windows.Forms.Button();
			button.BackColor = SystemColors.ButtonHighlight;
			button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			return button;
		}

		protected override void SetWebControlText()
		{
		}

		internal override void SetWebControlControls()
		{
		}

		protected override void SetWinControlText()
		{
			SetWinControlTextAndTooltip();
		}

		protected virtual void SetWinControlTextAndTooltip()
		{
			base.WinControl.Text = $"{base.WebControl.Name}\n({base.WebControl.GetType().Name})";
			System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
			toolTip.SetToolTip(base.WinControl, base.WebControl.GetType().FullName);
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Name")
			{
				SetWinControlTextAndTooltip();
			}
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}
	}
}
