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
	public class TextBoxBaseController : ControlController
	{
		public Gizmox.WebGUI.Forms.TextBoxBase WebTextBoxBase => base.SourceObject as Gizmox.WebGUI.Forms.TextBoxBase;

		public System.Windows.Forms.TextBoxBase WinTextBoxBase => base.TargetObject as System.Windows.Forms.TextBoxBase;

		public TextBoxBaseController(IContext objContext, object objWebTextBoxBase, object objWinTextBoxBase)
			: base(objContext, objWebTextBoxBase, objWinTextBoxBase)
		{
		}

		public TextBoxBaseController(IContext objContext, object objWebTextBoxBase)
			: base(objContext, objWebTextBoxBase)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTextBoxBaseMultiline();
			SetWinTextBoxBaseReadOnly();
			SetWinControlBorderStyle();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Multiline":
				SetWinTextBoxBaseMultiline();
				break;
			case "ReadOnly":
				SetWinTextBoxBaseReadOnly();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			case "Lines":
				SetWinTextBoxBaseLines();
				break;
			}
		}

		protected virtual void SetWinTextBoxBaseLines()
		{
			WinTextBoxBase.Lines = WebTextBoxBase.Lines;
		}

		protected override void SetWinControlBorderStyle()
		{
			WinTextBoxBase.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebTextBoxBase.BorderStyle, WinTextBoxBase.BorderStyle);
		}

		protected virtual void SetWinTextBoxBaseMultiline()
		{
			if (WinTextBoxBase.Multiline != WebTextBoxBase.Multiline)
			{
				WinTextBoxBase.Multiline = WebTextBoxBase.Multiline;
			}
		}

		protected virtual void SetWinTextBoxBaseReadOnly()
		{
			WinTextBoxBase.ReadOnly = WebTextBoxBase.ReadOnly;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTextBoxBase.KeyUp -= WinTextBoxBase_KeyUp;
			WinTextBoxBase.MultilineChanged -= WinTextBoxBase_MultilineChanged;
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTextBoxBase.KeyUp += WinTextBoxBase_KeyUp;
			WinTextBoxBase.MultilineChanged += WinTextBoxBase_MultilineChanged;
		}

		private void WinTextBoxBase_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Return)
			{
				Event obj = CreateWebEvent("EnterKeyDown");
				obj.Fire();
			}
		}

		private void WinTextBoxBase_MultilineChanged(object sender, EventArgs e)
		{
			if (WinTextBoxBase.Multiline)
			{
				SetWebControlSize();
			}
		}
	}
}
