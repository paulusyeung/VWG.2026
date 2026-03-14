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
/// Represents the center panel of a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> control.</summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[InitializationEvent("Load")]
	[DefaultEvent("Load")]
	[ToolboxItem(false)]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripContentPanel : Panel
	{
		private static readonly SerializableEvent LoadEvent;

		/// 
		/// Gets the Load handler.
		/// </summary>
		/// The Load handler.</value>
		private EventHandler LoadHandler => (EventHandler)GetHandler(Load);

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Windows.Forms.AnchorStyles"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override AnchorStyles Anchor
		{
			get
			{
				return base.Anchor;
			}
			set
			{
				base.Anchor = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true to enable automatic scrolling; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool AutoScroll
		{
			get
			{
				return base.AutoScroll;
			}
			set
			{
				base.AutoScroll = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.Size"></see>.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMargin
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.Size"></see>.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMinSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true to enable automatic sizing; otherwise, false.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Windows.Forms.AutoSizeMode"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Localizable(false)]
		public override AutoSizeMode AutoSizeMode
		{
			get
			{
				return AutoSizeMode.GrowOnly;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if the control causes validation; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool CausesValidation
		{
			get
			{
				return base.CausesValidation;
			}
			set
			{
				base.CausesValidation = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Windows.Forms.DockStyle"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.Point"></see>.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Point Location
		{
			get
			{
				return base.Location;
			}
			set
			{
				base.Location = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.Size"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Size MaximumSize
		{
			get
			{
				return base.MaximumSize;
			}
			set
			{
				base.MaximumSize = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.Size"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Size MinimumSize
		{
			get
			{
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.String"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		/// Gets or sets a <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> that handles painting.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderer Renderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets the painting styles to be applied to the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ToolStripRenderMode"></see> values. </returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderMode RenderMode
		{
			get
			{
				return ToolStripRenderMode.Custom;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Int32"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> can be tabbed to; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler AutoSizeChanged
		{
			add
			{
				base.AutoSizeChanged += value;
			}
			remove
			{
				base.AutoSizeChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler CausesValidationChanged
		{
			add
			{
				base.CausesValidationChanged += value;
			}
			remove
			{
				base.CausesValidationChanged -= value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DockChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the content panel loads.</summary>
		[SRDescription("ToolStripContentPanelOnLoadDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler Load
		{
			add
			{
				AddCriticalHandler(LoadEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LoadEvent, value);
			}
		}

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler LocationChanged
		{
			add
			{
				base.LocationChanged += value;
			}
			remove
			{
				base.LocationChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripContentPanel.Renderer"></see> property changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler RendererChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabIndexChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabStopChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> class. </summary>
		public ToolStripContentPanel()
		{
			SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, blnValue: true);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLoad(EventArgs e)
		{
			LoadHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			OnLoad(EventArgs.Empty);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripContentPanel.RendererChanged"></see> event. </summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRendererChanged(EventArgs e)
		{
		}

		static ToolStripContentPanel()
		{
			Load = SerializableEvent.Register("Load", typeof(EventHandler), typeof(ToolStripContentPanel));
		}
	}
}
