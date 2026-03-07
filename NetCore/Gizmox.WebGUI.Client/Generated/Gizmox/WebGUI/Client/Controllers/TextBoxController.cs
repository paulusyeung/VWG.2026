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
	public class TextBoxController : TextBoxBaseController
	{
		public Gizmox.WebGUI.Forms.TextBox WebTextBox => base.SourceObject as Gizmox.WebGUI.Forms.TextBox;

		public System.Windows.Forms.TextBox WinTextBox => base.TargetObject as System.Windows.Forms.TextBox;

		public TextBoxController(IContext objContext, object objWebTextBox, object objWinTextBox)
			: base(objContext, objWebTextBox, objWinTextBox)
		{
		}

		public TextBoxController(IContext objContext, object objWebTextBox)
			: base(objContext, objWebTextBox)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTextBoxPasswordChar();
			SetWinTextBoxScrollbars();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "PasswordChar"))
			{
				if (property == "ScrollBars")
				{
					SetWinTextBoxScrollbars();
				}
			}
			else
			{
				SetWinTextBoxPasswordChar();
			}
		}

		protected virtual void SetWinTextBoxScrollbars()
		{
			WinTextBox.ScrollBars = (System.Windows.Forms.ScrollBars)GetConvertedEnum(typeof(System.Windows.Forms.ScrollBars), WebTextBox.ScrollBars, WinTextBox.ScrollBars);
		}

		protected virtual void SetWinTextBoxPasswordChar()
		{
			WinTextBox.PasswordChar = WebTextBox.PasswordChar;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TextBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTextBox.TextChanged += WinTextBox_TextChanged;
		}

		private void WinTextBox_TextChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("TX", WinTextBox.Text);
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTextBox.TextChanged -= WinTextBox_TextChanged;
		}
	}
}
