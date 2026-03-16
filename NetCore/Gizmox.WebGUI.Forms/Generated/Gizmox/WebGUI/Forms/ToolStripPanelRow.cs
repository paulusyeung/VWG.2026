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
/// Represents a row of a <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that can contain controls.</summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ToolStripPanelRow : Component, IComponent, IDisposable
	{
		private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register("mobjBounds", typeof(Rectangle), typeof(ToolStripPanelRow));

		private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register("mobjParent", typeof(ToolStripPanel), typeof(ToolStripPanelRow));

		private static readonly SerializableProperty mobjControlsProperty = SerializableProperty.Register("mobjControls", typeof(List<Control>), typeof(ToolStripPanelRow));

		private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register("mobjPadding", typeof(Padding), typeof(ToolStripPanelRow));

		private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register("mobjMargin", typeof(Padding), typeof(ToolStripPanelRow));

		private Rectangle mobjBounds
		{
			get
			{
				return GetValue(mobjBoundsProperty);
			}
			set
			{
				SetValue(mobjBoundsProperty, value);
			}
		}

		private ToolStripPanel mobjParent
		{
			get
			{
				return GetValue(mobjParentProperty);
			}
			set
			{
				SetValue(mobjParentProperty, value);
			}
		}

		private List<Control> mobjControls
		{
			get
			{
				return GetValue<List<Control>>(mobjControlsProperty, null);
			}
			set
			{
				SetValue(mobjControlsProperty, value);
			}
		}

		private Padding mobjPadding
		{
			get
			{
				return GetValue(mobjPaddingProperty);
			}
			set
			{
				SetValue(mobjPaddingProperty, value);
			}
		}

		private Padding mobjMargin
		{
			get
			{
				return GetValue(mobjMarginProperty);
			}
			set
			{
				SetValue(mobjMarginProperty, value);
			}
		}

		/// Gets the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>, including its nonclient elements, in pixels, relative to the parent control.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
		public Rectangle Bounds => mobjBounds;

		/// 
		/// Gets the controls internal.
		/// </summary>
		/// The controls internal.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ControlControlsDescr")]
		internal List<Control> ControlsInternal
		{
			get
			{
				if (mobjControls == null)
				{
					mobjControls = new List<Control>();
				}
				return mobjControls;
			}
		}

		/// Gets the controls in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
		/// An array of controls.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlControlsDescr")]
		[Browsable(false)]
		public Control[] Controls => ControlsInternal.ToArray();

		/// Gets the space, in pixels, that is specified by default between controls.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> that represents the default space between controls.</returns>
		protected virtual Padding DefaultMargin
		{
			get
			{
				Padding rowMargin = ToolStripPanel.RowMargin;
				if (Orientation == Orientation.Horizontal)
				{
					rowMargin.Left = 0;
					rowMargin.Right = 0;
					return rowMargin;
				}
				rowMargin.Top = 0;
				rowMargin.Bottom = 0;
				return rowMargin;
			}
		}

		/// Gets the internal spacing, in pixels, of the contents of a control.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> that represents the internal spacing of the contents of a control.</returns>
		protected virtual Padding DefaultPadding => Padding.Empty;

		/// Gets the display area of the control.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle DisplayRectangle => Rectangle.Empty;

		/// Gets an instance of the control's layout engine.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> for the control's contents.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public LayoutEngine LayoutEngine => null;

		/// Gets or sets the space between controls.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
		public Padding Margin
		{
			get
			{
				return mobjMargin;
			}
			set
			{
				if (Margin != value)
				{
					mobjMargin = value;
				}
			}
		}

		/// Gets the layout direction of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> relative to its containing <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
		public Orientation Orientation => ToolStripPanel.Orientation;

		/// Gets or sets padding within the control.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> representing the control's internal spacing characteristics.</returns>
		public virtual Padding Padding
		{
			get
			{
				return mobjPadding;
			}
			set
			{
				if (Padding != value)
				{
					mobjPadding = value;
				}
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</returns>
		public ToolStripPanel ToolStripPanel => mobjParent;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> class, specifying the containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>. </summary> 
		/// <param name="parent">The containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
		public ToolStripPanelRow(ToolStripPanel parent)
			: this(parent, visible: true)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow" /> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="visible">if set to true</c> [visible].</param>
		internal ToolStripPanelRow(ToolStripPanel parent, bool visible)
		{
			mobjBounds = Rectangle.Empty;
			mobjParent = parent;
			Margin = DefaultMargin;
		}

		/// Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> can be dragged and dropped into a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
		/// true if there is enough space in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to receive the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false. </returns> 
		/// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be dragged and dropped into the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CanMove(ToolStrip toolStripToDrag)
		{
			return false;
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property changes.</summary> 
		/// <param name="newBounds">The new value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param> 
		/// <param name="oldBounds">The original value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected void OnBoundsChanged(Rectangle oldBounds, Rectangle newBounds)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Layout"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnLayout(LayoutEventArgs e)
		{
		}
	}
}
