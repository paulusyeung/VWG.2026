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
	/// Creates a panel that is associated with a SplitContainer.
	/// </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	[ToolboxItem(false)]
	[Skin(typeof(SplitterPanelSkin))]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	public sealed class SplitterPanel : Panel
	{
		private bool mblnCollapsed;

		private SplitContainer mobjOwner;

		/// 
		/// Gets or sets the anchoring style.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new AnchorStyles Anchor
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

		/// 
		/// Enables the SplitterPanel to shrink when AutoSize is true. 
		/// This property is not relevant for this class.
		/// </summary>
		/// </value>
		/// true if enabled; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool AutoSize
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

		/// 
		/// Indicates the automatic sizing behavior of the control.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
			}
		}

		internal bool Collapsed
		{
			get
			{
				return mblnCollapsed;
			}
			set
			{
				mblnCollapsed = value;
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DockStyle Dock
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

		/// 
		/// Gets the dock padding settings for all edges of the control.
		/// </summary>
		/// 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> that represents the padding for all the edges of a docked control.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DockPaddingEdges DockPadding => base.DockPadding;

		/// 
		/// Gets/Sets the height position
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlHeightDescr")]
		public new int Height
		{
			get
			{
				if (Collapsed)
				{
					return 0;
				}
				return base.Height;
			}
			set
			{
				throw new NotSupportedException(SR.GetString("SplitContainerPanelHeight"));
			}
		}

		internal int HeightInternal
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// 
		/// Gets or sets the control location.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
		/// </summary>
		/// </value>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
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

		/// 
		/// Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
		/// </summary>
		/// </value>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Size MinimumSize
		{
			get
			{
				if (Owner != null)
				{
					int num = Owner.Panel1MinSize;
					if (this == Owner.Panel2)
					{
						num = Owner.Panel2MinSize;
					}
					if (Owner.Orientation == Orientation.Horizontal)
					{
						return new Size(DefaultMinimumSize.Width, num);
					}
					return new Size(num, DefaultMinimumSize.Height);
				}
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = value;
			}
		}

		/// 
		/// Gets or sets the name associated with this control.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets the owner.
		/// </summary>
		/// The owner.</value>
		internal SplitContainer Owner => mobjOwner;

		/// 
		/// Gets or sets the parent container of this control.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Control Parent
		{
			get
			{
				return base.Parent;
			}
			set
			{
				base.Parent = value;
			}
		}

		/// 
		/// Gets or sets the size.
		/// </summary>
		/// The size.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size Size
		{
			get
			{
				if (Collapsed)
				{
					return Size.Empty;
				}
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		/// 
		/// Gets or sets the tab index.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
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

		/// 
		/// Gets or sets the control visability.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		/// 
		/// Gets/Sets the width position
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[SRDescription("ControlWidthDescr")]
		public new int Width
		{
			get
			{
				if (Collapsed)
				{
					return 0;
				}
				return base.Width;
			}
			set
			{
				throw new NotSupportedException(SR.GetString("SplitContainerPanelWidth"));
			}
		}

		internal int WidthInternal
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// 
		/// Occurs when [auto size changed].
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler AutoSizeChanged;

		/// 
		/// Occurs when the value of the Dock property changes. 
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DockChanged;

		/// 
		/// Occurs when the Location property value has changed.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler LocationChanged;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.SplitterPanel.TabIndex"> TabIndex </see> property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabIndexChanged;

		/// 
		/// Occurs when the value of the TabStop property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabStopChanged;

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler VisibleChanged
		{
			add
			{
				base.VisibleChanged += value;
			}
			remove
			{
				base.VisibleChanged -= value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitterPanel" /> class.
		/// </summary>
		/// <param name="objOwner">The owner.</param>
		public SplitterPanel(SplitContainer objOwner)
		{
			mobjOwner = objOwner;
			SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
		}

		/// 
		/// Applies the pre release dock fill compatibility.
		/// </summary>
		protected internal override void ApplyPreReleaseDockFillCompatibility()
		{
		}

		internal override AnchorStyles GetAnchorInternal()
		{
			if (Parent is SplitContainer { Site: null })
			{
				return AnchorStyles.None;
			}
			return base.GetAnchorInternal();
		}

		internal override DockStyle GetDockInternal()
		{
			DockStyle dockStyle = DockStyle.None;
			if (Parent is SplitContainer { Site: null } splitContainer)
			{
				if ((this == splitContainer.Panel1 && !splitContainer.Panel1Collapsed && splitContainer.Panel2Collapsed) || (this == splitContainer.Panel2 && !splitContainer.Panel2Collapsed && splitContainer.Panel1Collapsed))
				{
					return DockStyle.Fill;
				}
				bool flag = splitContainer.Panel1 == this;
				if (splitContainer.FixedPanel != FixedPanel.None)
				{
					flag = (splitContainer.Panel1 == this && splitContainer.FixedPanel == FixedPanel.Panel1) || (splitContainer.Panel2 == this && splitContainer.FixedPanel == FixedPanel.Panel2);
				}
				dockStyle = ((!flag) ? DockStyle.Fill : ((splitContainer.Orientation == Orientation.Vertical) ? ((this != splitContainer.Panel1) ? DockStyle.Right : DockStyle.Left) : ((this != splitContainer.Panel1) ? DockStyle.Bottom : DockStyle.Top)));
			}
			else
			{
				dockStyle = base.GetDockInternal();
			}
			return dockStyle;
		}
	}
}
