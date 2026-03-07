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
	public class RadioButtonController : ButtonBaseControler
	{
		public Gizmox.WebGUI.Forms.RadioButton WebRadioButton => base.SourceObject as Gizmox.WebGUI.Forms.RadioButton;

		public System.Windows.Forms.RadioButton WinRadioButton => base.TargetObject as System.Windows.Forms.RadioButton;

		public RadioButtonController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public RadioButtonController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinRadioButtonChecked();
			SetWinCheckAlign();
			SetWinAppearance();
		}

		protected virtual void SetWinCheckAlign()
		{
			WinRadioButton.CheckAlign = WebRadioButton.CheckAlign;
		}

		protected virtual void SetWinAppearance()
		{
			WinRadioButton.Appearance = (System.Windows.Forms.Appearance)GetConvertedEnum(typeof(System.Windows.Forms.Appearance), WebRadioButton.Appearance);
		}

		protected virtual void SetWebCheckAlign()
		{
			WebRadioButton.CheckAlign = WinRadioButton.CheckAlign;
		}

		protected virtual void SetWinRadioButtonChecked()
		{
			WinRadioButton.Checked = WebRadioButton.Checked;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.RadioButton();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinRadioButton.CheckedChanged += WinCheckBox_CheckedChanged;
		}

		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinRadioButton.CheckedChanged -= WinCheckBox_CheckedChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Checked":
				SetWinRadioButtonChecked();
				break;
			case "CheckAlign":
				SetWinCheckAlign();
				break;
			case "Appearance":
				SetWinAppearance();
				break;
			}
		}
	}
}
