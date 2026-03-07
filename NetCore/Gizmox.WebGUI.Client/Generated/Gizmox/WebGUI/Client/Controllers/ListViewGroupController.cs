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
	public class ListViewGroupController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ListViewGroup WebListViewGroup => base.SourceObject as Gizmox.WebGUI.Forms.ListViewGroup;

		public System.Windows.Forms.ListViewGroup WinListViewGroup => base.TargetObject as System.Windows.Forms.ListViewGroup;

		public ListViewGroupController(IContext objContext, object objWebListViewGroup, object objWinListViewGroup)
			: base(objContext, objWebListViewGroup, objWinListViewGroup)
		{
		}

		public ListViewGroupController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewGroupHeader();
			SetWinHeaderAlignment();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewGroupHeader();
			SetWinHeaderAlignment();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Header"))
			{
				if (property == "HeaderAlignment")
				{
					SetWinHeaderAlignment();
				}
			}
			else
			{
				SetWinListViewGroupHeader();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Header")
			{
				SetWebListViewGroupHeader();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewGroupHeader();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewGroup();
		}

		protected virtual void SetWinListViewGroupHeader()
		{
			WinListViewGroup.Header = WebListViewGroup.Header;
		}

		protected virtual void SetWebListViewGroupHeader()
		{
			WebListViewGroup.Header = WinListViewGroup.Header;
		}

		protected virtual void SetWinHeaderAlignment()
		{
			WinListViewGroup.HeaderAlignment = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebListViewGroup.HeaderAlignment);
		}
	}
}
