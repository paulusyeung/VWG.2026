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
	public class HtmlBoxController : PlaceHolderController
	{
		protected HtmlBox WebHtmlBox => base.WebComponent as HtmlBox;

		protected ClientHtmlBox WinHtmlBox => base.WinComponent as ClientHtmlBox;

		public HtmlBoxController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public HtmlBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinHtmlBoxContent();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientHtmlBox();
		}

		protected override void SetWinControlTextAndTooltip()
		{
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Content")
			{
				SetWinHtmlBoxContent();
			}
		}

		protected virtual void SetWinHtmlBoxContent()
		{
			switch (WebHtmlBox.Type)
			{
			case HtmlBoxType.HTML:
				WinHtmlBox.Html = WebHtmlBox.Html;
				break;
			case HtmlBoxType.URL:
				break;
			case HtmlBoxType.UNC:
				break;
			case HtmlBoxType.RESOURCE:
				break;
			}
		}

		protected override void SetWinControlText()
		{
		}
	}
}
