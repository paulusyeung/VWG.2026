#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
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
	public static class DockedManagerHelper
	{
		/// 
		/// Creates a split container.
		/// </summary>
		/// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
		/// <param name="objManager">The obj manager.</param>
		/// </returns>
		private static DockedSplitContainer CreateSplitContainer(DockedObjectDescriptor objDockedObjectDescriptor, DockingManager objManager, Control objParentControl)
		{
			DockedSplitContainer dockedSplitContainer = new DockedSplitContainer(objManager);
			objParentControl?.Controls.Add(dockedSplitContainer);
			if (objDockedObjectDescriptor != null)
			{
				((IDescriptable)dockedSplitContainer).Load(objDockedObjectDescriptor);
			}
			return dockedSplitContainer;
		}

		/// 
		/// Creates the zone.
		/// </summary>
		/// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
		/// <param name="enmDockState">State of the dock.</param>
		/// <param name="objManager">The obj manager.</param>
		/// </returns>
		private static Zone CreateZone(DockedObjectDescriptor objDockedObjectDescriptor, DockState enmDockState, Control objParentControl, DockingManager objManager)
		{
			ZoneType zoneType = ZoneType.Root;
			Zone zone = new Zone(objManager, enmDockState switch
			{
				DockState.Float => ZoneType.Float, 
				DockState.Dock => ZoneType.Dock, 
				_ => throw new Exception($"DockState not supported ({enmDockState.ToString()}) for creating a new zone"), 
			});
			objParentControl?.Controls.Add(zone);
			if (objDockedObjectDescriptor != null)
			{
				((IDescriptable)zone).Load(objDockedObjectDescriptor);
			}
			return zone;
		}

		/// 
		/// Enters the root zone from trace.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objRootZone">The mobj root zone.</param>
		/// <param name="objDescriptorsTrace">The obj descriptors trace.</param>
		/// <param name="objDockedManager">The obj docked manager.</param>
		private static void EnterRootZoneFromTrace(Control objControl, Zone objRootZone,List<object> objDescriptorsTrace, DockingManager objDockedManager)
		{
			if (objDescriptorsTrace[0] is ZoneDescriptor)
			{
				objControl.Controls.Add(objRootZone);
			}
			else
			{
				EnterRootZoneFromTrace(GetControlForNextStep(objControl, objDescriptorsTrace, objDockedManager, DockState.Dock), objRootZone, objDescriptorsTrace, objDockedManager);
			}
		}

		/// 
		/// Gets the control for next step.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objDescriptorsList">The obj descriptors list.</param>
		/// <param name="objManager">The obj manager.</param>
		/// <param name="objState">State of the obj.</param>
		/// </returns>
		private static Control GetControlForNextStep(Control objControl,List<object> objDescriptorsList, DockingManager objManager, DockState objState)
		{
			Control control = null;
			if (objControl.Controls.Count == 0)
			{
				if (objDescriptorsList[0] is ZoneDescriptor)
				{
					control = CreateZone(objDescriptorsList[0], objState, objControl, objManager);
				}
				else
				{
					if (!(objDescriptorsList[0] is DockedSplitContainerDescriptor))
					{
						throw new Exception($"Only '{typeof(ZoneDescriptor).FullName}' or '{typeof(DockedSplitContainerDescriptor).FullName}' types are allowed inside an empty control. Given type was: '{objDescriptorsList[0].GetType().FullName}'");
					}
					int panelSide = GetPanelSide(objDescriptorsList[1]);
					DockedSplitContainer objDockedSplitContainer = CreateSplitContainer(objDescriptorsList[0], objManager, objControl);
					control = GetControlFromPanelSide(panelSide, objDockedSplitContainer);
				}
				objDescriptorsList.Remove(objDescriptorsList[0]);
			}
			else if (objDescriptorsList[0] is DockedFormDescriptor)
			{
				control = objManager.GetFormFromDescriptor(objDescriptorsList[0] as DockedFormDescriptor);
				objDescriptorsList.Remove(objDescriptorsList[0]);
			}
			else
			{
				int intControlIndex;
				Control descriptableControl = GetDescriptableControl(objControl, out intControlIndex);
				if (descriptableControl == null)
				{
					throw new Exception("Control must be descriptable");
				}
				if (descriptableControl is Zone)
				{
					control = GetControlForNextStepZone(descriptableControl as Zone, objDescriptorsList, objManager);
				}
				else if (descriptableControl is DockedSplitContainer)
				{
					control = GetControlForNextStepDockedSplitContainer(descriptableControl as DockedSplitContainer, objDescriptorsList, objManager);
				}
				else
				{
					if (!(descriptableControl is DockedTabControl))
					{
						throw new Exception("Type is: " + descriptableControl.GetType().FullName);
					}
					control = GetControlForNextStepDockedTabControl(descriptableControl as DockedTabControl, objDescriptorsList);
				}
			}
			return control;
		}

		/// 
		/// Gets the control for next step docked split container.
		/// </summary>
		/// <param name="objDockedSplitContainer">The obj docked split container.</param>
		/// <param name="objDescriptorsList">The obj descriptors list.</param>
		/// <param name="objManager">The obj manager.</param>
		/// </returns>
		private static Control GetControlForNextStepDockedSplitContainer(DockedSplitContainer objDockedSplitContainer,List<object> objDescriptorsList, DockingManager objManager)
		{
			int panelSide = GetPanelSide(objDescriptorsList[1]);
			Control result = null;
			if (objDescriptorsList[0] is ZoneDescriptor)
			{
				throw new Exception("Check why a zone descriptor reached a Split container");
			}
			if (objDescriptorsList[0] is DockedSplitContainerDescriptor)
			{
				if (objDockedSplitContainer.DockedSplitContainerDescriptorInternal == objDescriptorsList[0])
				{
					result = GetControlFromPanelSide(panelSide, objDockedSplitContainer);
				}
				else
				{
					DockedSplitContainer dockedSplitContainer = SplitControl(objDockedSplitContainer, null, Relation.Inside, objManager);
					((IDescriptable)dockedSplitContainer).Load(objDescriptorsList[0]);
					switch (panelSide)
					{
					case 1:
						dockedSplitContainer.Panel2.Controls.Add(objDockedSplitContainer);
						result = dockedSplitContainer.Panel1;
						break;
					case 2:
						dockedSplitContainer.Panel1.Controls.Add(objDockedSplitContainer);
						result = dockedSplitContainer.Panel2;
						break;
					}
				}
				objDescriptorsList.Remove(objDescriptorsList[0]);
				return result;
			}
			throw new Exception("Check why...");
		}

		/// 
		/// Gets the control for next step docked tab control.
		/// </summary>
		/// <param name="objDockedTabControl">The obj docked tab control.</param>
		/// <param name="objDescriptorsList">The obj descriptors list.</param>
		/// </returns>
		private static Control GetControlForNextStepDockedTabControl(DockedTabControl objDockedTabControl,List<object> objDescriptorsList)
		{
			if (objDescriptorsList[0] is DockedTabControlDescriptor)
			{
				((IDescriptable)objDockedTabControl).Load(objDescriptorsList[0]);
				objDescriptorsList.Remove(objDescriptorsList[0]);
				return objDockedTabControl;
			}
			throw new Exception("Must be a DockedTabControlDescriptor: " + objDescriptorsList[0].GetType().Name);
		}

		/// 
		/// Gets the control for next step zone.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		/// <param name="objDescriptorsList">The obj descriptors list.</param>
		/// <param name="objManager">The obj manager.</param>
		/// </returns>
		private static Control GetControlForNextStepZone(Zone objZone,List<object> objDescriptorsList, DockingManager objManager)
		{
			DockedObjectDescriptor dockedObjectDescriptor = null;
			DockedObjectDescriptor objDescriptor = null;
			if (objDescriptorsList.Count > 0)
			{
				dockedObjectDescriptor = objDescriptorsList[0];
				if (objDescriptorsList.Count > 1)
				{
					objDescriptor = objDescriptorsList[1];
				}
				objDescriptorsList.Remove(dockedObjectDescriptor);
			}
			if (dockedObjectDescriptor == null || dockedObjectDescriptor is DockedTabControlDescriptor)
			{
				return objZone.TabControl;
			}
			if (dockedObjectDescriptor is DockedSplitContainerDescriptor)
			{
				int panelSide = GetPanelSide(objDescriptor);
				DockedSplitContainer dockedSplitContainer = SplitControl(objZone, null, Relation.Inside, objManager);
				((IDescriptable)dockedSplitContainer).Load(dockedObjectDescriptor);
				switch (panelSide)
				{
				case 1:
					dockedSplitContainer.Panel2.Controls.Add(objZone);
					return dockedSplitContainer.Panel1;
				case 2:
					dockedSplitContainer.Panel1.Controls.Add(objZone);
					return dockedSplitContainer.Panel2;
				default:
					throw new Exception("Panel side must be defined");
				}
			}
			if (dockedObjectDescriptor is ZoneDescriptor)
			{
				return objZone;
			}
			throw new Exception();
		}

		/// 
		/// Gets the control from panel side.
		/// </summary>
		/// <param name="intSide">The int side.</param>
		/// <param name="objDockedSplitContainer">The obj docked split container.</param>
		/// </returns>
		private static SplitterPanel GetControlFromPanelSide(int intSide, DockedSplitContainer objDockedSplitContainer)
		{
			return intSide switch
			{
				1 => objDockedSplitContainer.Panel1, 
				2 => objDockedSplitContainer.Panel2, 
				_ => throw new Exception(), 
			};
		}

		/// 
		/// Gets the descriptable control.
		/// </summary>
		/// <param name="objContainingControl">The obj containing control.</param>
		/// <param name="intControlIndex">Index of the int control.</param>
		/// </returns>
		internal static Control GetDescriptableControl(Control objContainingControl, out int intControlIndex)
		{
			intControlIndex = -1;
			foreach (Control control in objContainingControl.Controls)
			{
				if (control is IDescriptable && !(control is DockedHiddenZonesPanel))
				{
					intControlIndex = objContainingControl.Controls.IndexOf(control);
					return control;
				}
			}
			return null;
		}

		/// 
		/// Gets the panel side.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		/// </returns>
		private static int GetPanelSide(DockedObjectDescriptor objDescriptor)
		{
			if (objDescriptor is ZoneDescriptor)
			{
				return (objDescriptor as ZoneDescriptor).PanelSide;
			}
			if (objDescriptor is DockedSplitContainerDescriptor)
			{
				return (objDescriptor as DockedSplitContainerDescriptor).PanelSide;
			}
			throw new Exception();
		}

		/// 
		/// Enters the root zone.
		/// </summary>
		/// <param name="objRootZone">The mobj root zone.</param>
		/// <param name="objDockedManager">The docked manager.</param>
		internal static void EnterRootZone(Zone objRootZone, DockingManager objDockedManager)
		{
			EnterRootZoneFromTrace(objDockedManager, objRootZone, GetDescriptorTrace(objDockedManager.DockedManagerDescriptorInternal.RootZoneDescriptor, blnWithCurrent: true), objDockedManager);
		}

		/// 
		/// Gets the descriptor trace.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		/// </returns>
		internal static List<object> GetDescriptorTrace(DockedObjectDescriptor objDescriptor, bool blnWithCurrent)
		{
			List<object> list = new List<object><object>();
			if (!blnWithCurrent)
			{
				objDescriptor = objDescriptor.ParentDescriptor;
			}
			while (objDescriptor != null && !(objDescriptor is DockedManagerDescriptor))
			{
				list.Add(objDescriptor);
				objDescriptor = objDescriptor.ParentDescriptor;
			}
			list.Reverse();
			return list;
		}

		/// 
		/// Gets the logical parent control.
		/// </summary>
		/// <param name="objDockedControl">The obj docked control.</param>
		/// </returns>
		internal static Control GetLogicalParentControl(Control objDockedControl)
		{
			if (objDockedControl.Parent is SplitterPanel)
			{
				return objDockedControl.Parent.Parent;
			}
			return objDockedControl.Parent;
		}

		/// 
		/// Loads a window from a descriptors trace.
		/// this function gets a Root-Control [objControl] and builds up the controls hierarchy according to the trace.
		/// finally adds the window to its rightful place
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objWindow">The obj window.</param>
		/// <param name="objDescriptorsList">The obj descriptors list.</param>
		/// <param name="objManager">The obj manager.</param>
		/// <param name="objState">State of the obj.</param>
		internal static void LoadWindowFromTrace(Control objControl, DockingWindow objWindow,List<object> objDescriptorsList, DockingManager objManager, DockState objState)
		{
			if (objControl is DockedTabControl && objDescriptorsList.Count == 0)
			{
				(objControl as DockedTabControl).AddWindow(objWindow);
				return;
			}
			Control controlForNextStep = GetControlForNextStep(objControl, objDescriptorsList, objManager, objState);
			LoadWindowFromTrace(controlForNextStep, objWindow, objDescriptorsList, objManager, objState);
		}

		/// 
		/// Splits the zone with a control.
		/// </summary>
		/// <param name="objOriginalControl">The obj original zone.</param>
		/// <param name="objNewControl">The obj new control.</param>
		/// <param name="enmSplitRelation">The enm split relation.</param>
		/// <param name="objManager">The obj manager.</param>
		internal static DockedSplitContainer SplitControl(Control objOriginalControl, Control objNewControl, Relation enmSplitRelation, DockingManager objManager)
		{
			DockedSplitContainer dockedSplitContainer = null;
			Control parent = objOriginalControl.Parent;
			Control logicalParentControl = GetLogicalParentControl(objOriginalControl);
			if (parent != null)
			{
				dockedSplitContainer = CreateSplitContainer(null, objManager, null);
				int childIndex = parent.Controls.GetChildIndex(objOriginalControl, blnThrowException: false);
				if (childIndex != -1)
				{
					if (logicalParentControl is IPreventExtraction)
					{
						(logicalParentControl as IPreventExtraction).DisableExtraction(blnDisable: true);
					}
					parent.Controls.Remove(objOriginalControl);
					if (objNewControl != null)
					{
						switch (enmSplitRelation)
						{
						case Relation.Above:
							dockedSplitContainer.Orientation = Orientation.Horizontal;
							dockedSplitContainer.Panel1.Controls.Add(objNewControl);
							dockedSplitContainer.Panel2.Controls.Add(objOriginalControl);
							break;
						case Relation.Below:
							dockedSplitContainer.Orientation = Orientation.Horizontal;
							dockedSplitContainer.Panel1.Controls.Add(objOriginalControl);
							dockedSplitContainer.Panel2.Controls.Add(objNewControl);
							break;
						case Relation.ToTheRight:
							dockedSplitContainer.Orientation = Orientation.Vertical;
							dockedSplitContainer.Panel1.Controls.Add(objOriginalControl);
							dockedSplitContainer.Panel2.Controls.Add(objNewControl);
							break;
						case Relation.ToTheLeft:
							dockedSplitContainer.Orientation = Orientation.Vertical;
							dockedSplitContainer.Panel1.Controls.Add(objNewControl);
							dockedSplitContainer.Panel2.Controls.Add(objOriginalControl);
							break;
						default:
							throw new Exception("DockedManagerHelper.SplitControlWithSplitter");
						}
					}
					parent.Controls.Add(dockedSplitContainer);
					parent.Controls.SetChildIndex(dockedSplitContainer, childIndex);
					if (logicalParentControl is IPreventExtraction)
					{
						(logicalParentControl as IPreventExtraction).DisableExtraction(blnDisable: false);
					}
				}
			}
			return dockedSplitContainer;
		}
	}
}
