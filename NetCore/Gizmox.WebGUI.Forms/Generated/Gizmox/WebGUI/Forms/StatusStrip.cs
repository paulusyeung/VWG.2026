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
	[Serializable]
	[MetadataTag("SSP")]
	[Skin(typeof(StatusStripSkin))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[SRDescription("DescriptionStatusStrip")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(StatusStrip), "StatusStrip_45.bmp")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class StatusStrip : ToolStrip
	{
		/// 
		/// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
		/// </summary>
		/// </value>
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public override ToolStripItemCollection Items => base.Items;

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality.</summary>
		/// true if the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
		[Browsable(false)]
		[DefaultValue(false)]
		[SRDescription("ToolStripCanOverflowDescr")]
		[SRCategory("CatLayout")]
		public new bool CanOverflow
		{
			get
			{
				return base.CanOverflow;
			}
			set
			{
				base.CanOverflow = value;
			}
		}

		/// Gets which borders of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> are docked to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns>
		protected override DockStyle DefaultDock => DockStyle.Bottom;

		/// Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> from the edges of the form.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
		protected override Padding DefaultPadding
		{
			get
			{
				if (base.Skin is StatusStripSkin statusStripSkin)
				{
					if (base.Orientation == Orientation.Vertical)
					{
						Padding result = statusStripSkin.VerticalOrientationPadding;
						result.Bottom = DefaultSize.Height;
						return result;
					}
					return statusStripSkin.HorizontalOrientationPadding;
				}
				if (base.Orientation != Orientation.Horizontal)
				{
					return new Padding(1, 3, 1, DefaultSize.Height);
				}
				if (RightToLeft == RightToLeft.No)
				{
					return new Padding(1, 0, 14, 0);
				}
				return new Padding(14, 0, 1, 0);
			}
		}

		/// Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.StatusStrip"></see> by default.</summary>
		/// false in all cases.</returns>
		protected override bool DefaultShowItemToolTips => false;

		/// Gets the size, in pixels, of the <see cref="T:System.Windows.Forms.StatusStrip"></see> when it is first created.</summary>
		/// A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> constructor representing the size of the <see cref="T:System.Windows.Forms.StatusStrip"></see>, in pixels.</returns>
		protected override Size DefaultSize => new Size(200, 22);

		/// Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> is resized with its parent.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns> 
		/// 1</filterpriority>
		[DefaultValue(DockStyle.Top)]
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

		/// Gets or sets the visibility of the grip used to reposition the control.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
		[DefaultValue(ToolStripGripStyle.Hidden)]
		public new ToolStripGripStyle GripStyle
		{
			get
			{
				return base.GripStyle;
			}
			set
			{
				base.GripStyle = value;
			}
		}

		/// Gets or sets a value indicating how the <see cref="T:System.Windows.Forms.StatusStrip"></see> lays out the items collection.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripLayoutStyle.Table"></see>.</returns>
		[DefaultValue(ToolStripLayoutStyle.Table)]
		public new ToolStripLayoutStyle LayoutStyle
		{
			get
			{
				return base.LayoutStyle;
			}
			set
			{
				base.LayoutStyle = value;
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public new Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
		/// true if ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[SRDescription("ToolStripShowItemToolTipsDescr")]
		[SRCategory("CatBehavior")]
		public new bool ShowItemToolTips
		{
			get
			{
				return base.ShowItemToolTips;
			}
			set
			{
				base.ShowItemToolTips = value;
			}
		}

		/// Gets the boundaries of the sizing handle (grip) for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> representing the grip boundaries.</returns>
		[Browsable(false)]
		public Rectangle SizeGripBounds
		{
			get
			{
				if (!SizingGrip)
				{
					return Rectangle.Empty;
				}
				Size size = base.Size;
				int num = Math.Min(DefaultSize.Height, size.Height);
				if (RightToLeft == RightToLeft.Yes)
				{
					return new Rectangle(0, size.Height - num, 12, num);
				}
				return new Rectangle(size.Width - 12, size.Height - num, 12, num);
			}
		}

		/// Gets or sets a value indicating whether a sizing handle (grip) is displayed in the lower-right corner of the control.</summary> 
		/// true if a grip is displayed; otherwise, false. The default is true.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool SizingGrip
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its container.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is true.</returns>
		[SRCategory("CatLayout")]
		[SRDescription("ToolStripStretchDescr")]
		[DefaultValue(true)]
		public new bool Stretch
		{
			get
			{
				return base.Stretch;
			}
			set
			{
				base.Stretch = value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		public new event EventHandler PaddingChanged
		{
			add
			{
				base.PaddingChanged += value;
			}
			remove
			{
				base.PaddingChanged -= value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> class. </summary>
		public StatusStrip()
		{
			SuspendLayout();
			CanOverflow = false;
			LayoutStyle = ToolStripLayoutStyle.Table;
			GripStyle = ToolStripGripStyle.Hidden;
			SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
			Stretch = true;
			ResumeLayout(blnPerformLayout: true);
		}

		/// Provides custom table layout for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnSpringTableLayoutCore()
		{
		}

		/// 
		/// Creates the default item.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// <param name="objImage">The obj image.</param>
		/// <param name="objOnClick">The obj on click.</param>
		/// </returns>
		protected internal override ToolStripItem CreateDefaultItem(string strText, ResourceHandle objImage, EventHandler objOnClick)
		{
			return new ToolStripStatusLabel(strText, objImage, objOnClick);
		}
	}
}
