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

namespace Gizmox.WebGUI.Client.Forms
{
	public class ClientStackPanel : System.Windows.Forms.Panel
	{
		private Dictionary<System.Windows.Forms.Control, Size> marrControlSizes = new Dictionary<System.Windows.Forms.Control, Size>();

		private System.Windows.Forms.Orientation menmOrientation = System.Windows.Forms.Orientation.Vertical;

		public System.Windows.Forms.Orientation Orientation
		{
			get
			{
				return menmOrientation;
			}
			set
			{
				if (menmOrientation == value)
				{
					return;
				}
				menmOrientation = value;
				foreach (System.Windows.Forms.Control control in base.Controls)
				{
					ApplyControlSize(control);
					ApplyControlDockStyle(control);
				}
			}
		}

		protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
		{
			base.OnControlAdded(e);
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				marrControlSizes.Add(control, control.Size);
				control.DockChanged += OnContainedControlDockChanged;
				ApplyControlDockStyle(control);
			}
		}

		private void OnContainedControlDockChanged(object sender, EventArgs e)
		{
			if (sender is System.Windows.Forms.Control objControl)
			{
				ApplyControlDockStyle(objControl);
			}
		}

		protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.DockChanged -= OnContainedControlDockChanged;
				if (marrControlSizes.ContainsKey(control))
				{
					marrControlSizes.Remove(control);
				}
			}
		}

		private void ApplyControlDockStyle(System.Windows.Forms.Control objControl)
		{
			if (objControl != null)
			{
				objControl.SuspendLayout();
				objControl.Dock = ((Orientation == System.Windows.Forms.Orientation.Vertical) ? System.Windows.Forms.DockStyle.Top : System.Windows.Forms.DockStyle.Left);
				objControl.ResumeLayout();
			}
		}

		private void ApplyControlSize(System.Windows.Forms.Control objControl)
		{
			if (objControl != null)
			{
				Size size = marrControlSizes[objControl];
				bool flag = true;
				objControl.SuspendLayout();
				switch (Orientation)
				{
				case System.Windows.Forms.Orientation.Horizontal:
					objControl.Width = size.Width;
					break;
				case System.Windows.Forms.Orientation.Vertical:
					objControl.Height = size.Height;
					break;
				}
				objControl.ResumeLayout();
			}
		}
	}
}
