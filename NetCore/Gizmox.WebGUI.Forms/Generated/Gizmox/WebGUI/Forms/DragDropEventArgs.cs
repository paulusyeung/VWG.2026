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
	/// Contains Drag and drop event arguments.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	public class DragDropEventArgs : DragEventArgs
	{
		private Component mobjSource = null;

		private Component mobjTarget = null;

		private Component mobjExplicitTarget = null;

		private Point mobjRelativePosition;

		/// 
		/// Gets the position relative to the parent control.
		/// </summary>
		public Point RelativePosition => mobjRelativePosition;

		/// 
		/// Gets the source component.
		/// </summary>
		/// The source component.</value>
		public Component Source => mobjSource;

		/// 
		/// Gets the source component member.
		/// </summary>
		/// The source component member.</value>
		[Obsolete("Not supported - please use 'Source' property instead.")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Component SourceMember => null;

		/// 
		/// Gets the target component.
		/// </summary>
		/// The target component.</value>
		public Component Target => mobjTarget;

		/// 
		/// Gets the target component member.
		/// </summary>
		/// The target component member.</value>
		[Obsolete("Not supported - please use 'ExplicitTarget' property instead.")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Component TargetMember => null;

		/// 
		/// Gets the explicit target.
		/// </summary>
		public Component ExplicitTarget => mobjExplicitTarget;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
		/// </summary>
		/// <param name="objData">The data associated with this event.</param>
		/// <param name="intKeyState">The current state of the SHIFT, CTRL, and ALT keys.</param>
		/// <param name="intX">The x-coordinate of the mouse cursor in pixels.</param>
		/// <param name="intY">The y-coordinate of the mouse cursor in pixels.</param>
		/// <param name="enmAllowedEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
		/// <param name="enmEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
		public DragDropEventArgs(IDataObject objData, int intKeyState, int intX, int intY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
			: base(objData, intKeyState, intX, intY, enmAllowedEffect, enmEffect)
		{
			if (objData != null)
			{
				string[] formats = objData.GetFormats();
				if (formats != null && formats.Length != 0)
				{
					mobjSource = objData.GetData(formats[0]) as Component;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
		/// </summary>
		/// <param name="objSource">The source.</param>
		/// <param name="objSourceMember">The source member.</param>
		/// <param name="objTarget">The target.</param>
		/// <param name="objTargetMember">The target member.</param>
		/// <param name="intKeyState">State of the key.</param>
		/// <param name="intX">The x.</param>
		/// <param name="intY">The y.</param>
		/// <param name="enmAllowedEffect">The allowed effect.</param>
		/// <param name="enmEffect">The effect.</param>
		[Obsolete("Not supported - please use other constructors which exceptes 'ExplicitTarget'.")]
		[Browsable(false)]
		public DragDropEventArgs(Component objSource, Component objSourceMember, Component objTarget, Component objTargetMember, int intKeyState, int intX, int intY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
			: base(new DataObject(objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
		{
			mobjSource = objSource;
			mobjTarget = objTarget;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
		/// </summary>
		/// <param name="objSource">The obj source.</param>
		/// <param name="objTarget">The obj target.</param>
		/// <param name="intKeyState">State of the int key.</param>
		/// <param name="intX">The int X.</param>
		/// <param name="intY">The int Y.</param>
		/// <param name="enmAllowedEffect">The enm allowed effect.</param>
		/// <param name="enmEffect">The enm effect.</param>
		public DragDropEventArgs(Component objSource, Component objTarget, Component objExplicitTarget, int intKeyState, int intX, int intY, int intRelativeX, int intRelativeY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
			: base(new DataObject(objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
		{
			mobjSource = objSource;
			mobjTarget = objTarget;
			mobjExplicitTarget = objExplicitTarget;
			mobjRelativePosition = new Point(intRelativeX, intRelativeY);
		}
	}
}
