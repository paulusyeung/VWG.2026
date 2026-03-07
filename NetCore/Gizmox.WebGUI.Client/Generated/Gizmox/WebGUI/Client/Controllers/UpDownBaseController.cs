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
	public class UpDownBaseController : ControlController
	{
		public Gizmox.WebGUI.Forms.UpDownBase WebUpDownBase => base.SourceObject as Gizmox.WebGUI.Forms.UpDownBase;

		public System.Windows.Forms.UpDownBase WinUpDownBase => base.TargetObject as System.Windows.Forms.UpDownBase;

		public UpDownBaseController(IContext objContext, object objWebUpDown)
			: base(objContext, objWebUpDown)
		{
		}

		public UpDownBaseController(IContext objContext, object objWebUpDown, object objWinUpDown)
			: base(objContext, objWebUpDown, objWinUpDown)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinControlReadOnly();
			SetWinControlTextAlign();
			SetWinControlUpDownAlign();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ReadOnly":
				SetWinControlReadOnly();
				break;
			case "TextAlign":
				SetWinControlTextAlign();
				break;
			case "UpDownAlign":
				SetWinControlUpDownAlign();
				break;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return base.CreateTargetObject(objWebObject);
		}

		protected virtual void SetWinControlReadOnly()
		{
			WinUpDownBase.ReadOnly = WebUpDownBase.ReadOnly;
		}

		protected virtual void SetWinControlTextAlign()
		{
			WinUpDownBase.TextAlign = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebUpDownBase.TextAlign);
		}

		protected virtual void SetWinControlUpDownAlign()
		{
			WinUpDownBase.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)GetConvertedEnum(typeof(System.Windows.Forms.LeftRightAlignment), WebUpDownBase.UpDownAlign);
		}
	}
}
