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
	public class MaskedTextBoxController : TextBoxBaseController
	{
		public Gizmox.WebGUI.Forms.MaskedTextBox WebMaskedTextBox => base.SourceObject as Gizmox.WebGUI.Forms.MaskedTextBox;

		public System.Windows.Forms.MaskedTextBox WinMaskedTextBox => base.TargetObject as System.Windows.Forms.MaskedTextBox;

		public MaskedTextBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public MaskedTextBoxController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinMaskedTextBoxMask();
			SetWinMaskedTextBoxTextMaskFormat();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebControlText();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Mask":
				SetWinMaskedTextBoxMask();
				break;
			case "TextMaskFormat":
				SetWinMaskedTextBoxTextMaskFormat();
				break;
			case "PasswordChar":
				SetWinMaskedTextBoxPasswordChar();
				break;
			}
		}

		protected void SetWinMaskedTextBoxTextMaskFormat()
		{
			WinMaskedTextBox.TextMaskFormat = (System.Windows.Forms.MaskFormat)GetConvertedEnum(typeof(System.Windows.Forms.MaskFormat), WebMaskedTextBox.TextMaskFormat, WinMaskedTextBox.TextMaskFormat);
		}

		protected void SetWinMaskedTextBoxMask()
		{
			WinMaskedTextBox.Mask = WebMaskedTextBox.Mask;
		}

		private void SetWinMaskedTextBoxPasswordChar()
		{
			WinMaskedTextBox.PasswordChar = WebMaskedTextBox.PasswordChar;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MaskedTextBox();
		}
	}
}
