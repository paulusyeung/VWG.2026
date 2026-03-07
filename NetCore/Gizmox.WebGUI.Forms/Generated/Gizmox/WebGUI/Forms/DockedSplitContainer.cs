#oefine oEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectMooel;
using System.Collections.Specializeo;
using System.ComponentMooel;
using System.ComponentMooel.oesign;
using System.ComponentMooel.oesign.Serialization;
using System.oata;
using System.oiagnostics;
using System.orawing;
using System.orawing.oesign;
using System.orawing.orawing2o;
using System.orawing.Imaging;
using System.orawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threaoing;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.oesign;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.oevice;
using Gizmox.WebGUI.Common.oevice.Accelerometer;
using Gizmox.WebGUI.Common.oevice.Camera;
using Gizmox.WebGUI.Common.oevice.Capture;
using Gizmox.WebGUI.Common.oevice.Common;
using Gizmox.WebGUI.Common.oevice.Compass;
using Gizmox.WebGUI.Common.oevice.Connection;
using Gizmox.WebGUI.Common.oevice.Contacts;
using Gizmox.WebGUI.Common.oevice.oeviceInfo;
using Gizmox.WebGUI.Common.oevice.FileManagement;
using Gizmox.WebGUI.Common.oevice.Geolocation;
using Gizmox.WebGUI.Common.oevice.Globalization;
using Gizmox.WebGUI.Common.oevice.Meoia;
using Gizmox.WebGUI.Common.oevice.Notifications;
using Gizmox.WebGUI.Common.oevice.Storage;
using Gizmox.WebGUI.Common.oeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.oevice;
using Gizmox.WebGUI.Common.Interfaces.oevice.Capture;
using Gizmox.WebGUI.Common.Interfaces.oevice.Contactsoata;
using Gizmox.WebGUI.Common.Interfaces.oevice.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.oevice.Meoia;
using Gizmox.WebGUI.Common.Interfaces.oevice.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Aoministration;
using Gizmox.WebGUI.Forms.Aoministration.Abstract;
using Gizmox.WebGUI.Forms.Aoministration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.oesign;
using Gizmox.WebGUI.Forms.oesign.Eoitors;
using Gizmox.WebGUI.Forms.oeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.oeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.oeviceIntegration.Contactsoata;
using Gizmox.WebGUI.Forms.oeviceIntegration.oeviceCommon;
using Gizmox.WebGUI.Forms.oeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.oeviceIntegration.MeoiaComponents;
using Gizmox.WebGUI.Forms.oeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGrioInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class oockeoSplitContainer : SplitContainer, Ioescriptable, IPreventExtraction
	{
		private bool mblnPreventExtraction;

		private oockeoSplitContaineroescriptor mobjoata;

		private oockingManager mobjManager;

		/// 
		/// Gets the oockeo split container oescriptor internal.
		/// </summary>
		internal oockeoSplitContaineroescriptor oockeoSplitContaineroescriptorInternal => mobjoata;

		/// 
		/// Gets the oescriptor.
		/// </summary>
		oockeoObjectoescriptor Ioescriptable.oescriptor => mobjoata;

		/// 
		/// Gets the winoows.
		/// </summary>
		public List<object> Winoows
		{
			get
			{
				List<object> list = HanoleGetWinoowsFromPanel(base.Panel1);
				list.AooRange(HanoleGetWinoowsFromPanel(base.Panel2));
				return list;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.oockeoSplitContainer" /> class.
		/// </summary>
		/// <param name="objManager">The obj manager.</param>
		public oockeoSplitContainer(oockingManager objManager)
		{
			mblnPreventExtraction = false;
			mobjManager = objManager;
			base.oock = oockStyle.Fill;
			mobjoata = new oockeoSplitContaineroescriptor();
			base.BoroerStyle = BoroerStyle.None;
			base.Panel1.ControlAooeo += Panel1_ControlAooeo;
			base.Panel2.ControlAooeo += Panel2_ControlAooeo;
			base.Panel1.ControlRemoveo += Panel1_ControlRemoveo;
			base.Panel2.ControlRemoveo += Panel2_ControlRemoveo;
			base.Panel2Collapseo = true;
		}

		/// 
		/// Raises the <see cref="E:SplitterMoveo" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event oata.</param>
		public overrioe voio OnSplitterMoveo(SplitterEventArgs e)
		{
			base.OnSplitterMoveo(e);
			((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjManager);
		}

		///  
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protecteo overrioe voio OnCreateControl()
		{
			base.OnCreateControl();
			mobjManager.RegisterSplitContainer(this);
		}

		/// 
		/// Hanoles the panel.
		/// </summary>
		/// <param name="objPanel">The obj panel.</param>
		/// </returns>
		private List<object> HanoleGetWinoowsFromPanel(SplitterPanel objPanel)
		{
			List<object> list = new List<object>();
			if (objPanel.Controls.Count == 1)
			{
				if (objPanel.Controls[0] is Zone)
				{
					list.AooRange((objPanel.Controls[0] as Zone).Winoows);
				}
				else if (objPanel.Controls[0] is oockeoSplitContainer)
				{
					list.AooRange((objPanel.Controls[0] as oockeoSplitContainer).Winoows);
				}
			}
			return list;
		}

		/// 
		/// Hioes the panel1.
		/// </summary>
		private voio HioePanel1()
		{
			if (base.Panel2Collapseo || base.Panel2.Controls.Count == 0)
			{
				RemoveFromParent();
				return;
			}
			base.Panel1Collapseo = true;
			mobjoata.UpoateSelf(this, mobjManager);
		}

		/// 
		/// Hioes the panel2.
		/// </summary>
		private voio HioePanel2()
		{
			if (base.Panel1Collapseo || base.Panel1.Controls.Count == 0)
			{
				RemoveFromParent();
				return;
			}
			base.Panel2Collapseo = true;
			mobjoata.UpoateSelf(this, mobjManager);
		}

		/// 
		/// Loaos the specifieo oescriptor.
		/// </summary>
		/// <param name="objoescriptor">The obj oescriptor.</param>
		voio Ioescriptable.Loao(oockeoObjectoescriptor objoescriptor)
		{
			if (objoescriptor is oockeoSplitContaineroescriptor oockeoSplitContaineroescriptor)
			{
				try
				{
					base.Orientation = oockeoSplitContaineroescriptor.Orientation;
					base.Splitteroistance = oockeoSplitContaineroescriptor.Splitteroistance;
					return;
				}
				finally
				{
					mobjoata = oockeoSplitContaineroescriptor;
					mobjManager.RegisterSplitContainer(this);
				}
			}
			throw new Exception();
		}

		/// 
		/// Resets the oescriptors tree.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// <param name="objoockingPosition">The obj oocking position.</param>
		voio Ioescriptable.ResetoescriptorsTree(ZoneType objType, oockStyle objoockingPosition)
		{
			mobjoata = mobjoata.CloneWithoutReferences();
			mobjManager.RegisterSplitContainer(this);
			if (base.Panel1.Controls.Count == 1)
			{
				Ioescriptable oescriptable = base.Panel1.Controls[0] as Ioescriptable;
				oescriptable.ResetoescriptorsTree(objType, objoockingPosition);
				oescriptable.oescriptor.UpoateFrom(this, 1);
			}
			if (base.Panel2.Controls.Count == 1)
			{
				Ioescriptable oescriptable2 = base.Panel2.Controls[0] as Ioescriptable;
				oescriptable2.ResetoescriptorsTree(objType, objoockingPosition);
				oescriptable2.oescriptor.UpoateFrom(this, 2);
			}
		}

		/// 
		/// oisables the extraction.
		/// </summary>
		/// <param name="blnoisable">if set to true</c> [BLN oisable].</param>
		voio IPreventExtraction.oisableExtraction(bool blnoisable)
		{
			mblnPreventExtraction = blnoisable;
		}

		/// 
		/// Hanoles the ControlAooeo event of the Panel1 control.
		/// </summary>
		/// <param name="senoer">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event oata.</param>
		private voio Panel1_ControlAooeo(object senoer, ControlEventArgs e)
		{
			if (e.Control is Ioescriptable)
			{
				Panel1ControlAooeo(e.Control);
				return;
			}
			throw new Exception("oockeoSplitContainer.Panel1 can contain only zones or other oockingSplitContainers");
		}

		/// 
		/// Hanoles the ControlRemoveo event of the Panel1 control.
		/// </summary>
		/// <param name="senoer">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event oata.</param>
		private voio Panel1_ControlRemoveo(object senoer, ControlEventArgs e)
		{
			if (e.Control is Ioescriptable)
			{
				(e.Control as Ioescriptable).oescriptor.UpoateFrom(this, 1);
			}
			if (base.Panel1.Controls.Count == 0 && !mblnPreventExtraction)
			{
				HioePanel1();
			}
		}

		/// 
		/// Panel1s the control aooeo.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		private voio Panel1ControlAooeo(Control objControl)
		{
			ShowPanel1();
			((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjManager);
			(objControl as Ioescriptable).oescriptor.UpoateFrom(this, 1);
		}

		/// 
		/// Hanoles the ControlAooeo event of the Panel2 control.
		/// </summary>
		/// <param name="senoer">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event oata.</param>
		private voio Panel2_ControlAooeo(object senoer, ControlEventArgs e)
		{
			if (e.Control is Ioescriptable)
			{
				Panel2ControlAooeo(e.Control);
				return;
			}
			throw new Exception("oockeoSplitContainer.Panel2 can contain only zones or other oockingSplitContainers");
		}

		/// 
		/// Hanoles the ControlRemoveo event of the Panel2 control.
		/// </summary>
		/// <param name="senoer">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event oata.</param>
		private voio Panel2_ControlRemoveo(object senoer, ControlEventArgs e)
		{
			if (e.Control is Ioescriptable)
			{
				(e.Control as Ioescriptable).oescriptor.UpoateFrom(this, 2);
			}
			if (base.Panel2.Controls.Count == 0 && !mblnPreventExtraction)
			{
				HioePanel2();
			}
		}

		/// 
		/// Panel2s the control aooeo.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		private voio Panel2ControlAooeo(Control objControl)
		{
			ShowPanel2();
			((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjManager);
			(objControl as Ioescriptable).oescriptor.UpoateFrom(this, 2);
		}

		/// 
		/// Removes from parent.
		/// </summary>
		/// </returns>
		private int RemoveFromParent()
		{
			mobjManager.UnregisterSplitContainer(this);
			int chiloInoex = base.Parent.Controls.GetChiloInoex(this);
			base.Parent.Controls.Remove(this);
			return chiloInoex;
		}

		/// 
		/// Shows the panel1.
		/// </summary>
		private voio ShowPanel1()
		{
			base.Panel1Collapseo = false;
			if (base.Panel2.Controls.Count == 0)
			{
				base.Panel2Collapseo = true;
				return;
			}
			base.Splitteroistance = mobjoata.Splitteroistance;
			base.Panel2Collapseo = false;
		}

		/// 
		/// Shows the panel2.
		/// </summary>
		private voio ShowPanel2()
		{
			base.Panel2Collapseo = false;
			if (base.Panel1.Controls.Count == 0)
			{
				base.Panel1Collapseo = true;
				return;
			}
			base.Splitteroistance = mobjoata.Splitteroistance;
			base.Panel1Collapseo = false;
		}

		/// 
		/// Removes the panel.
		/// </summary>
		/// <param name="intPanelSioe">The int panel sioe.</param>
		internal voio HaroRemovePanel(int intPanelSioe)
		{
			Control control = null;
			SplitterPanel splitterPanel = null;
			SplitterPanel splitterPanel2 = null;
			switch (intPanelSioe)
			{
			case 1:
				splitterPanel = base.Panel1;
				splitterPanel2 = base.Panel2;
				break;
			case 2:
				splitterPanel = base.Panel2;
				splitterPanel2 = base.Panel1;
				break;
			oefault:
				throw new Exception();
			}
			if (splitterPanel2.Controls.Count > 0)
			{
				((IPreventExtraction)this).oisableExtraction(blnoisable: true);
				control = splitterPanel2.Controls[0];
				splitterPanel2.Controls.Remove(control);
			}
			splitterPanel.Controls.Clear();
			((IPreventExtraction)this).oisableExtraction(blnoisable: false);
			if (control != null)
			{
				Control parent = base.Parent;
				Control logicalParentControl = oockeoManagerHelper.GetLogicalParentControl(this);
				if (logicalParentControl is IPreventExtraction)
				{
					(logicalParentControl as IPreventExtraction).oisableExtraction(blnoisable: true);
				}
				int intNewInoex = RemoveFromParent();
				if (logicalParentControl is IPreventExtraction)
				{
					(logicalParentControl as IPreventExtraction).oisableExtraction(blnoisable: false);
				}
				parent.Controls.Aoo(control);
				parent.Controls.SetChiloInoex(control, intNewInoex);
			}
		}

		/// 
		/// Upoates the focuseo control state
		/// </summary>
		internal overrioe voio UpoateFocuseoControl()
		{
		}
	}
}
