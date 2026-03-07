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
	public class ToolStripItemCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.ToolStripItemCollection WebToolStripItems => base.WebObjects as Gizmox.WebGUI.Forms.ToolStripItemCollection;

		public Gizmox.WebGUI.Forms.ToolStrip WebToolStrip => base.SourceObject as Gizmox.WebGUI.Forms.ToolStrip;

		public System.Windows.Forms.ToolStrip WinToolStrip => base.TargetObject as System.Windows.Forms.ToolStrip;

		public ToolStripItemCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjectItems)
			: base(objContext, objWebObject, objWebObjects, objWinObject, objWinObjectItems)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(base.Context, objWebObject);
			}
			return new ToolStripItemController(base.Context, objWebObject);
		}

		protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			if (objTargetObject is System.Windows.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripControlHost)
			{
				return null;
			}
			if (objTargetObject is System.Windows.Forms.ToolStripDropDownItem)
			{
				return null;
			}
			if (objTargetObject is System.Windows.Forms.ToolStripItem)
			{
				return null;
			}
			return base.CreateObjectControlerByTargetObject(objTargetObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripButton)
			{
				return new System.Windows.Forms.ToolStripButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSplitButton)
			{
				return new System.Windows.Forms.ToolStripSplitButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownButton)
			{
				return new System.Windows.Forms.ToolStripDropDownButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripLabel)
			{
				return new System.Windows.Forms.ToolStripLabel();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripComboBox)
			{
				return new System.Windows.Forms.ToolStripComboBox();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripProgressBar)
			{
				return new System.Windows.Forms.ToolStripProgressBar();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripTextBox)
			{
				return new System.Windows.Forms.ToolStripTextBox();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripStatusLabel)
			{
				return new System.Windows.Forms.ToolStripStatusLabel();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripMenuItem)
			{
				return new System.Windows.Forms.ToolStripMenuItem();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripControlHost)
			{
				return null;
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownItem)
			{
				return null;
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripItem)
			{
				return null;
			}
			return base.CreateTargetObject(objWebObject);
		}

		protected override void ClearWinObjects()
		{
			ClearControllers();
			if (base.WinObjects != null)
			{
				if (base.DesignMode)
				{
					WinObjectsClear(blnIsInDesignMode: true);
				}
				else
				{
					base.WinObjects.Clear();
				}
			}
		}

		protected internal override void WinObjectsClear()
		{
			WinObjectsClear(blnIsInDesignMode: false);
		}

		private void WinObjectsClear(bool blnIsInDesignMode)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object winObject in base.WinObjects)
			{
				if (winObject.GetType().Name != "DesignerToolStripControlHost")
				{
					if (blnIsInDesignMode && winObject is IComponent objWinComponent)
					{
						base.DesignServices.UnregisterWinComponent(objWinComponent);
					}
					arrayList.Add(winObject);
				}
			}
			foreach (object item in arrayList)
			{
				base.WinObjects.Remove(item);
			}
		}
	}
}
