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
	public class CheckBoxController : ButtonBaseControler
	{
		public Gizmox.WebGUI.Forms.CheckBox WebCheckBox => base.SourceObject as Gizmox.WebGUI.Forms.CheckBox;

		public System.Windows.Forms.CheckBox WinCheckBox => base.TargetObject as System.Windows.Forms.CheckBox;

		public CheckBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public CheckBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinCheckBoxChecked();
			SetWinCheckBoxThreeState();
			SetWinCheckBoxCheckState();
			SetWinAppearance();
			SetWinCheckAlign();
		}

		protected virtual void SetWinCheckBoxChecked()
		{
			WinCheckBox.Checked = WebCheckBox.Checked;
		}

		protected virtual void SetWinCheckBoxThreeState()
		{
			WinCheckBox.ThreeState = WebCheckBox.ThreeState;
		}

		protected virtual void SetWinCheckBoxCheckState()
		{
			WinCheckBox.CheckState = (System.Windows.Forms.CheckState)GetConvertedEnum(typeof(System.Windows.Forms.CheckState), WebCheckBox.CheckState);
		}

		protected virtual void SetWinAppearance()
		{
			object convertedEnum = GetConvertedEnum(typeof(System.Windows.Forms.Appearance), WebCheckBox.Appearance);
			if (convertedEnum != null)
			{
				WinCheckBox.Appearance = (System.Windows.Forms.Appearance)convertedEnum;
			}
		}

		protected virtual void SetWinCheckAlign()
		{
			WinCheckBox.CheckAlign = WebCheckBox.CheckAlign;
		}

		protected virtual void SetWebCheckAlign()
		{
			WebCheckBox.CheckAlign = WinCheckBox.CheckAlign;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.CheckBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinCheckBox.Click += WinCheckBox_CheckedChanged;
		}

		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("Checked", WinCheckBox.Checked ? "1" : "0");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinCheckBox.Click -= WinCheckBox_CheckedChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Checked":
				SetWinCheckBoxChecked();
				break;
			case "ThreeState":
				SetWinCheckBoxThreeState();
				break;
			case "CheckState":
				SetWinCheckBoxCheckState();
				break;
			case "CheckAlign":
				SetWinCheckAlign();
				break;
			case "Appearance":
				SetWinAppearance();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "CheckAlign")
			{
				SetWebCheckAlign();
			}
		}
	}
}
