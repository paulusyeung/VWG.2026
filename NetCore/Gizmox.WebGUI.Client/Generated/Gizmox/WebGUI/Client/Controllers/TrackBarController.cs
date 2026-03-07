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
	public class TrackBarController : ControlController
	{
		private bool mblnOrientationInitialized = false;

		public Gizmox.WebGUI.Forms.TrackBar WebTrackBar => base.SourceObject as Gizmox.WebGUI.Forms.TrackBar;

		public System.Windows.Forms.TrackBar WinTrackBar => base.TargetObject as System.Windows.Forms.TrackBar;

		public TrackBarController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public TrackBarController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTrackBarMaximum();
			SetWinTrackBarMinimum();
			SetWinTrackBarValue();
			SetWinTrackBarOrientation();
			mblnOrientationInitialized = true;
			SetWinControlSize();
			SetWinTrackBarTickFrequency();
			SetWinTrackBarTickStyle();
		}

		protected override void SetWinControlSize()
		{
			if (mblnOrientationInitialized)
			{
				base.SetWinControlSize();
			}
		}

		protected virtual void SetWinTrackBarTickStyle()
		{
			WinTrackBar.TickStyle = (System.Windows.Forms.TickStyle)GetConvertedEnum(typeof(System.Windows.Forms.TickStyle), WebTrackBar.TickStyle);
		}

		protected virtual void SetWinTrackBarTickFrequency()
		{
			WinTrackBar.TickFrequency = WebTrackBar.TickFrequency;
		}

		protected virtual void SetWinTrackBarOrientation()
		{
			SetWinProperty("Orientation", (System.Windows.Forms.Orientation)GetConvertedEnum(typeof(System.Windows.Forms.Orientation), WebTrackBar.Orientation));
		}

		protected virtual void SetWinTrackBarMaximum()
		{
			WinTrackBar.Maximum = WebTrackBar.Maximum;
		}

		protected virtual void SetWinTrackBarMinimum()
		{
			WinTrackBar.Minimum = WebTrackBar.Minimum;
		}

		protected virtual void SetWinTrackBarValue()
		{
			WinTrackBar.Value = WebTrackBar.Value;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TrackBar();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (!base.DesignMode)
			{
				WinTrackBar.ValueChanged += WinTrackBar_ValueChanged;
			}
		}

		private void WinTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("VLB", WinTrackBar.Value.ToString());
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (!base.DesignMode)
			{
				WinTrackBar.ValueChanged -= WinTrackBar_ValueChanged;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Value":
				SetWinTrackBarValue();
				break;
			case "Minimum":
				SetWinTrackBarMinimum();
				break;
			case "Maximum":
				SetWinTrackBarMaximum();
				break;
			case "Orientation":
				SetWinTrackBarOrientation();
				break;
			case "TickFrequency":
				SetWinTrackBarTickFrequency();
				break;
			case "TickStyle":
				SetWinTrackBarTickStyle();
				break;
			}
		}
	}
}
