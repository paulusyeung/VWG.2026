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
	public class DateTimePickerController : ControlController
	{
		public Gizmox.WebGUI.Forms.DateTimePicker WebDateTimePicker => base.SourceObject as Gizmox.WebGUI.Forms.DateTimePicker;

		public System.Windows.Forms.DateTimePicker WinDateTimePicker => base.TargetObject as System.Windows.Forms.DateTimePicker;

		public DateTimePickerController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public DateTimePickerController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDateTimePickerCustomFormat();
			SetWinDateTimePickerFormat();
			SetWinDateTimePickerShowCheckBox();
			SetWinDateTimePickerShowUpDown();
			SetWinDateTimePickerChecked();
		}

		protected override void SetWebControlText()
		{
		}

		protected override void SetWinControlText()
		{
		}

		protected virtual void SetWinDateTimePickerShowCheckBox()
		{
			if (WinDateTimePicker.ShowCheckBox != WebDateTimePicker.ShowCheckBox)
			{
				WinDateTimePicker.ShowCheckBox = WebDateTimePicker.ShowCheckBox;
			}
		}

		protected virtual void SetWinDateTimePickerShowUpDown()
		{
			if (WinDateTimePicker.ShowUpDown != WebDateTimePicker.ShowUpDown)
			{
				WinDateTimePicker.ShowUpDown = WebDateTimePicker.ShowUpDown;
			}
		}

		protected virtual void SetWinDateTimePickerChecked()
		{
			if (WinDateTimePicker.Checked != WebDateTimePicker.Checked)
			{
				WinDateTimePicker.Checked = WebDateTimePicker.Checked;
			}
		}

		protected virtual void SetWinDateTimePickerCustomFormat()
		{
			if (WebDateTimePicker.Format == Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom)
			{
				WinDateTimePicker.CustomFormat = WebDateTimePicker.CustomFormat;
			}
		}

		protected virtual void SetWinDateTimePickerFormat()
		{
			WinDateTimePicker.Format = (System.Windows.Forms.DateTimePickerFormat)GetConvertedEnum(typeof(System.Windows.Forms.DateTimePickerFormat), WebDateTimePicker.Format);
		}

		protected virtual void SetWinDateTimePickerValue()
		{
			WinDateTimePicker.Value = WebDateTimePicker.Value;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DateTimePicker();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ShowUpDown":
				SetWinDateTimePickerShowUpDown();
				break;
			case "Checked":
				SetWinDateTimePickerChecked();
				break;
			case "ShowCheckBox":
				SetWinDateTimePickerShowCheckBox();
				break;
			case "CustomFormat":
				SetWinDateTimePickerCustomFormat();
				break;
			case "Format":
				SetWinDateTimePickerFormat();
				break;
			case "Value":
				SetWinDateTimePickerValue();
				break;
			}
		}
	}
}
