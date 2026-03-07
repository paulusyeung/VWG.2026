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
	public class NumericUpDownController : UpDownBaseController
	{
		public Gizmox.WebGUI.Forms.NumericUpDown WebNumericUpDown => base.SourceObject as Gizmox.WebGUI.Forms.NumericUpDown;

		public System.Windows.Forms.NumericUpDown WinNumericUpDown => base.TargetObject as System.Windows.Forms.NumericUpDown;

		public NumericUpDownController(IContext objContext, object objWebUpDown)
			: base(objContext, objWebUpDown)
		{
		}

		public NumericUpDownController(IContext objContext, object objWebUpDown, object objWinUpDown)
			: base(objContext, objWebUpDown, objWinUpDown)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinNumericUpDownMinimum();
			SetWinNumericUpDownMaximum();
			SetWinNumericUpDownThousandsSeparator();
			SetWinNumericUpDownIncrement();
			SetWinNumericUpDownValue();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Minimum":
				SetWinNumericUpDownMinimum();
				break;
			case "Maximum":
				SetWinNumericUpDownMaximum();
				break;
			case "ThousandsSeparator":
				SetWinNumericUpDownThousandsSeparator();
				break;
			case "Increment":
				SetWinNumericUpDownIncrement();
				break;
			case "Value":
				SetWinNumericUpDownValue();
				break;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientNumericUpDown();
		}

		protected virtual void SetWinNumericUpDownMinimum()
		{
			WinNumericUpDown.Minimum = WebNumericUpDown.Minimum;
		}

		protected virtual void SetWinNumericUpDownMaximum()
		{
			WinNumericUpDown.Maximum = WebNumericUpDown.Maximum;
		}

		protected virtual void SetWinNumericUpDownIncrement()
		{
			WinNumericUpDown.Increment = WebNumericUpDown.Increment;
		}

		protected virtual void SetWinNumericUpDownThousandsSeparator()
		{
			WinNumericUpDown.ThousandsSeparator = WebNumericUpDown.ThousandsSeparator;
		}

		protected virtual void SetWinNumericUpDownValue()
		{
			WinNumericUpDown.Value = WebNumericUpDown.Value;
		}
	}
}
