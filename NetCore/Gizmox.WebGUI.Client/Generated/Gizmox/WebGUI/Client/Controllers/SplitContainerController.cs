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
	public class SplitContainerController : ControlController
	{
		private SplitterPanelController mobjSplitterPanel1Controller = null;

		private SplitterPanelController mobjSplitterPanel2Controller = null;

		public System.Windows.Forms.SplitContainer TargetSplitContainer => base.TargetObject as System.Windows.Forms.SplitContainer;

		public Gizmox.WebGUI.Forms.SplitContainer SourceSplitContainer => base.SourceObject as Gizmox.WebGUI.Forms.SplitContainer;

		public SplitContainerController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjSplitterPanel1Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel1, TargetSplitContainer.Panel1);
			mobjSplitterPanel2Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel2, TargetSplitContainer.Panel2);
		}

		public SplitContainerController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjSplitterPanel1Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel1, TargetSplitContainer.Panel1);
			mobjSplitterPanel2Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel2, TargetSplitContainer.Panel2);
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjSplitterPanel1Controller.Initialize();
			mobjSplitterPanel2Controller.Initialize();
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.SplitContainer();
		}

		internal override void SetWebControlControls()
		{
		}

		protected override void SetWinControlControls()
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void InitializeController()
		{
			SetTargetSplitContainerFixedPanel();
			base.InitializeController();
			if (base.DesignMode)
			{
				RegisterController(mobjSplitterPanel1Controller);
				RegisterController(mobjSplitterPanel2Controller);
			}
			SetTargetSplitContainerPanel1Collapsed();
			SetTargetSplitContainerPanel1MinSize();
			SetTargetSplitContainerPanel2Collapsed();
			SetTargetSplitContainerPanel2MinSize();
			SetTargetSplitContainerSplitterIncrement();
			SetTargetSplitContainerSplitterWidth();
			TargetSplitContainer.SuspendLayout();
			TargetSplitContainer.Panel1.SuspendLayout();
			TargetSplitContainer.Panel2.SuspendLayout();
			SetTargetSplitContainerOrientation();
			SetTargetSplitContainerSplitterDistance();
			TargetSplitContainer.Panel1.ResumeLayout(performLayout: false);
			TargetSplitContainer.Panel2.ResumeLayout(performLayout: false);
			TargetSplitContainer.ResumeLayout(performLayout: false);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjSplitterPanel1Controller != null)
			{
				mobjSplitterPanel1Controller.Terminate();
			}
			if (mobjSplitterPanel2Controller != null)
			{
				mobjSplitterPanel2Controller.Terminate();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "SplitterDistance":
				SetSourceSplitContainerSplitterDistance();
				break;
			case "Orientation":
				SetSourceSplitContainerOrientation();
				break;
			case "Panel1Collapsed":
				SetSourceSplitContainerPanel1Collapsed();
				break;
			case "Panel1MinSize":
				SetSourceSplitContainerPanel1MinSize();
				break;
			case "Panel2Collapsed":
				SetSourceSplitContainerPanel2Collapsed();
				break;
			case "Panel2MinSize":
				SetSourceSplitContainerPanel2MinSize();
				break;
			case "SplitterIncrement":
				SetSourceSplitContainerSplitterIncrement();
				break;
			case "SplitterWidth":
				SetSourceSplitContainerSplitterWidth();
				break;
			case "FixedPanel":
				SetSourceSplitContainerFixedPanel();
				break;
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "SplitterDistance":
				SetTargetSplitContainerSplitterDistance();
				break;
			case "Orientation":
				SetTargetSplitContainerOrientation();
				break;
			case "Panel1Collapsed":
				SetTargetSplitContainerPanel1Collapsed();
				break;
			case "Panel1MinSize":
				SetTargetSplitContainerPanel1MinSize();
				break;
			case "Panel2Collapsed":
				SetTargetSplitContainerPanel2Collapsed();
				break;
			case "Panel2MinSize":
				SetTargetSplitContainerPanel2MinSize();
				break;
			case "SplitterIncrement":
				SetTargetSplitContainerSplitterIncrement();
				break;
			case "SplitterWidth":
				SetTargetSplitContainerSplitterWidth();
				break;
			case "FixedPanel":
				SetTargetSplitContainerFixedPanel();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected virtual void SetTargetSplitContainerSplitterDistance()
		{
			TargetSplitContainer.SplitterDistance = SourceSplitContainer.SplitterDistance;
		}

		protected virtual void SetTargetSplitContainerOrientation()
		{
			TargetSplitContainer.Orientation = (System.Windows.Forms.Orientation)GetConvertedEnum(typeof(System.Windows.Forms.Orientation), SourceSplitContainer.Orientation);
		}

		protected virtual void SetTargetSplitContainerPanel1Collapsed()
		{
			TargetSplitContainer.Panel1Collapsed = SourceSplitContainer.Panel1Collapsed;
		}

		protected virtual void SetTargetSplitContainerPanel1MinSize()
		{
			TargetSplitContainer.Panel1MinSize = SourceSplitContainer.Panel1MinSize;
		}

		protected virtual void SetTargetSplitContainerPanel2Collapsed()
		{
			TargetSplitContainer.Panel2Collapsed = SourceSplitContainer.Panel2Collapsed;
		}

		protected virtual void SetTargetSplitContainerPanel2MinSize()
		{
			TargetSplitContainer.Panel2MinSize = SourceSplitContainer.Panel2MinSize;
		}

		protected virtual void SetTargetSplitContainerSplitterIncrement()
		{
			TargetSplitContainer.SplitterIncrement = SourceSplitContainer.SplitterIncrement;
		}

		protected virtual void SetTargetSplitContainerSplitterWidth()
		{
			TargetSplitContainer.SplitterWidth = SourceSplitContainer.SplitterWidth;
		}

		protected virtual void SetTargetSplitContainerFixedPanel()
		{
			TargetSplitContainer.FixedPanel = (System.Windows.Forms.FixedPanel)GetConvertedEnum(typeof(System.Windows.Forms.FixedPanel), SourceSplitContainer.FixedPanel);
		}

		private void SetSourceSplitContainerSplitterDistance()
		{
			SourceSplitContainer.SplitterDistance = TargetSplitContainer.SplitterDistance;
		}

		protected virtual void SetSourceSplitContainerOrientation()
		{
			SourceSplitContainer.Orientation = (Gizmox.WebGUI.Forms.Orientation)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.Orientation), TargetSplitContainer.Orientation);
		}

		protected virtual void SetSourceSplitContainerPanel1Collapsed()
		{
			SourceSplitContainer.Panel1Collapsed = TargetSplitContainer.Panel1Collapsed;
		}

		protected virtual void SetSourceSplitContainerPanel1MinSize()
		{
			SourceSplitContainer.Panel1MinSize = TargetSplitContainer.Panel1MinSize;
		}

		protected virtual void SetSourceSplitContainerPanel2Collapsed()
		{
			SourceSplitContainer.Panel2Collapsed = TargetSplitContainer.Panel2Collapsed;
		}

		protected virtual void SetSourceSplitContainerPanel2MinSize()
		{
			SourceSplitContainer.Panel2MinSize = TargetSplitContainer.Panel2MinSize;
		}

		protected virtual void SetSourceSplitContainerSplitterIncrement()
		{
			SourceSplitContainer.SplitterIncrement = TargetSplitContainer.SplitterIncrement;
		}

		protected virtual void SetSourceSplitContainerSplitterWidth()
		{
			SourceSplitContainer.SplitterWidth = TargetSplitContainer.SplitterWidth;
		}

		protected virtual void SetSourceSplitContainerFixedPanel()
		{
			SourceSplitContainer.FixedPanel = (Gizmox.WebGUI.Forms.FixedPanel)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.FixedPanel), TargetSplitContainer.FixedPanel);
		}
	}
}
