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
	public class FlowLayoutPanelController : PanelController
	{
		public Gizmox.WebGUI.Forms.FlowLayoutPanel WebFlowLayoutPanel => base.SourceObject as Gizmox.WebGUI.Forms.FlowLayoutPanel;

		public System.Windows.Forms.FlowLayoutPanel WinFlowLayoutPanel => base.TargetObject as System.Windows.Forms.FlowLayoutPanel;

		public FlowLayoutPanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public FlowLayoutPanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinFlowLayoutPanelFlowDirection();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (!(property == "FlowDirection"))
			{
				if (property == "WrapContents")
				{
					SetWinFlowLayoutPanelWrapContents();
				}
				else
				{
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				}
			}
			else
			{
				SetWinFlowLayoutPanelFlowDirection();
			}
		}

		private void SetWinFlowLayoutPanelWrapContents()
		{
			WinFlowLayoutPanel.WrapContents = WebFlowLayoutPanel.WrapContents;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "FlowDirection")
			{
				SetWebFlowLayoutPanelFlowDirection();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetWinFlowLayoutPanelFlowDirection()
		{
			System.Windows.Forms.FlowDirection flowDirection = (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.RightToLeft) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? System.Windows.Forms.FlowDirection.RightToLeft : (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.LeftToRight) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.BottomUp) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? System.Windows.Forms.FlowDirection.TopDown : System.Windows.Forms.FlowDirection.BottomUp) : System.Windows.Forms.FlowDirection.LeftToRight));
			WinFlowLayoutPanel.FlowDirection = flowDirection;
		}

		protected virtual void SetWebFlowLayoutPanelFlowDirection()
		{
			Gizmox.WebGUI.Forms.FlowDirection flowDirection = (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.TopDown) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.RightToLeft : (((WebFlowLayoutPanel.FlowDirection & (Gizmox.WebGUI.Forms.FlowDirection)0) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.LeftToRight : (((WebFlowLayoutPanel.FlowDirection & (Gizmox.WebGUI.Forms.FlowDirection)3) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.TopDown : Gizmox.WebGUI.Forms.FlowDirection.BottomUp)));
			WebFlowLayoutPanel.FlowDirection = flowDirection;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.FlowLayoutPanel();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}
	}
}
