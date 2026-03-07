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
	/// Provides panels on each side of the form and a central panel that can hold one or more controls.</summary>
	[Serializable]
	[ComVisible(true)]
	[SRDescription("ToolStripContainerDesc")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[MetadataTag("TSC")]
	[Skin(typeof(ToolStripContainerSkin))]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ToolStripContainer), "ToolStripContainer_45.bmp")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripContainer : ContainerControl
	{
		internal class ToolStripContainerTypedControlCollection : ClientUtils.ReadOnlyControlCollection
		{
			private Type mobjContentPanelType;

			private ToolStripContainer mobjOwnerToolStripContainer;

			private Type mobjPanelType;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer.ToolStripContainerTypedControlCollection" /> class.
			/// </summary>
			/// <param name="c">The c.</param>
			/// <param name="isReadOnly">if set to true</c> [is read only].</param>
			public ToolStripContainerTypedControlCollection(Control c, bool isReadOnly)
				: base(c, isReadOnly)
			{
				mobjContentPanelType = typeof(ToolStripContentPanel);
				mobjPanelType = typeof(ToolStripPanel);
				mobjOwnerToolStripContainer = c as ToolStripContainer;
			}

			/// 
			/// Adds the specified value.
			/// </summary>
			/// <param name="value">The value.</param>
			public override void Add(Control value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ToolStripContainerUseContentPanel"));
				}
				Type type = value.GetType();
				if (!mobjContentPanelType.IsAssignableFrom(type) && !mobjPanelType.IsAssignableFrom(type))
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfTypes", mobjContentPanelType.Name, mobjPanelType.Name)), value.GetType().Name);
				}
				base.Add(value);
			}

			/// 
			/// Removes the specified value.
			/// </summary>
			/// <param name="value">The value.</param>
			public override void Remove(Control value)
			{
				if ((value is ToolStripPanel || value is ToolStripContentPanel) && !mobjOwnerToolStripContainer.DesignMode && IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				base.Remove(value);
			}

			/// 
			/// Sets the child index internal.
			/// </summary>
			/// <param name="child">The child.</param>
			/// <param name="newIndex">The new index.</param>
			internal override void SetChildIndexInternal(Control child, int newIndex)
			{
				if (child is ToolStripPanel || child is ToolStripContentPanel)
				{
					if (mobjOwnerToolStripContainer.DesignMode)
					{
						return;
					}
					if (IsReadOnly)
					{
						throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
					}
				}
				base.SetChildIndexInternal(child, newIndex);
			}
		}

		private static readonly SerializableProperty mobjBottomPanelProperty = SerializableProperty.Register("mobjBottomPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));

		private static readonly SerializableProperty mobjContentPanelProperty = SerializableProperty.Register("mobjContentPanel", typeof(ToolStripContentPanel), typeof(ToolStripContainer));

		private static readonly SerializableProperty mobjLeftPanelProperty = SerializableProperty.Register("mobjLeftPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));

		private static readonly SerializableProperty mobjRightPanelProperty = SerializableProperty.Register("mobjRightPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));

		private static readonly SerializableProperty mobjTopPanelProperty = SerializableProperty.Register("mobjTopPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));

		private ToolStripPanel mobjBottomPanel
		{
			get
			{
				return GetValue(mobjBottomPanelProperty);
			}
			set
			{
				SetValue(mobjBottomPanelProperty, value);
			}
		}

		private ToolStripContentPanel mobjContentPanel
		{
			get
			{
				return GetValue(mobjContentPanelProperty);
			}
			set
			{
				SetValue(mobjContentPanelProperty, value);
			}
		}

		private ToolStripPanel mobjLeftPanel
		{
			get
			{
				return GetValue(mobjLeftPanelProperty);
			}
			set
			{
				SetValue(mobjLeftPanelProperty, value);
			}
		}

		private ToolStripPanel mobjRightPanel
		{
			get
			{
				return GetValue(mobjRightPanelProperty);
			}
			set
			{
				SetValue(mobjRightPanelProperty, value);
			}
		}

		private ToolStripPanel mobjTopPanel
		{
			get
			{
				return GetValue(mobjTopPanelProperty);
			}
			set
			{
				SetValue(mobjTopPanelProperty, value);
			}
		}

		/// This property is not relevant for this class.</summary>
		/// true to enable automatic scrolling; otherwise, false. </returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// This property is not relevant for this class.</summary>
		/// An <see cref="T:System.Drawing.Image"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ResourceHandle BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// This property is not relevant for this class.</summary>
		/// An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// Gets the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripContainerBottomToolStripPanelDescr")]
		[Localizable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ToolStripPanel BottomToolStripPanel => mobjBottomPanel;

		/// Gets or sets a value indicating whether the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible. </summary>
		/// true if the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
		[SRDescription("ToolStripContainerBottomToolStripPanelVisibleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public bool BottomToolStripPanelVisible
		{
			get
			{
				return BottomToolStripPanel.Visible;
			}
			set
			{
				BottomToolStripPanel.Visible = value;
			}
		}

		/// This property is not relevant for this class.</summary>
		/// true if the control causes validation; otherwise, false. </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// Gets the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> representing the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("ToolStripContainerContentPanelDescr")]
		[Localizable(false)]
		[SRCategory("CatAppearance")]
		public ToolStripContentPanel ContentPanel => mobjContentPanel;

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return base.ContextMenuStrip;
			}
			set
			{
				base.ContextMenuStrip = value;
			}
		}

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Windows.Forms.Control.ControlCollection"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ControlCollection Controls => base.Controls;

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Cursor Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
				base.Cursor = value;
			}
		}

		/// Gets the default size of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> representing the horizontal and vertical dimensions of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</returns>
		protected override Size DefaultSize => new Size(150, 175);

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Drawing.Color"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// Gets the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripContainerLeftToolStripPanelDescr")]
		[Localizable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ToolStripPanel LeftToolStripPanel => mobjLeftPanel;

		/// Gets or sets a value indicating whether the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
		/// true if the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripContainerLeftToolStripPanelVisibleDescr")]
		[DefaultValue(true)]
		public bool LeftToolStripPanelVisible
		{
			get
			{
				return LeftToolStripPanel.Visible;
			}
			set
			{
				LeftToolStripPanel.Visible = value;
			}
		}

		/// Gets the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Localizable(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripContainerRightToolStripPanelDescr")]
		public ToolStripPanel RightToolStripPanel => mobjRightPanel;

		/// Gets or sets a value indicating whether the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
		/// true if the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		[SRDescription("ToolStripContainerRightToolStripPanelVisibleDescr")]
		public bool RightToolStripPanelVisible
		{
			get
			{
				return RightToolStripPanel.Visible;
			}
			set
			{
				RightToolStripPanel.Visible = value;
			}
		}

		/// Gets the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
		[SRCategory("CatAppearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("ToolStripContainerTopToolStripPanelDescr")]
		[Localizable(false)]
		public ToolStripPanel TopToolStripPanel => mobjTopPanel;

		/// Gets or sets a value indicating whether the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
		/// true if the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
		[SRDescription("ToolStripContainerTopToolStripPanelVisibleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public bool TopToolStripPanelVisible
		{
			get
			{
				return TopToolStripPanel.Visible;
			}
			set
			{
				TopToolStripPanel.Visible = value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler BackColorChanged
		{
			add
			{
				base.BackColorChanged += value;
			}
			remove
			{
				base.BackColorChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler BackgroundImageChanged
		{
			add
			{
				base.BackgroundImageChanged += value;
			}
			remove
			{
				base.BackgroundImageChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler BackgroundImageLayoutChanged
		{
			add
			{
				base.BackgroundImageLayoutChanged += value;
			}
			remove
			{
				base.BackgroundImageLayoutChanged += value;
			}
		}

		/// Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.CausesValidation"></see> property changes.</summary>
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

		/// Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.ContextMenuStrip"></see> property changes.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler ContextMenuStripChanged
		{
			add
			{
				base.ContextMenuStripChanged += value;
			}
			remove
			{
				base.ContextMenuStripChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler CursorChanged
		{
			add
			{
				base.CursorChanged += value;
			}
			remove
			{
				base.CursorChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler ForeColorChanged
		{
			add
			{
				base.ForeColorChanged += value;
			}
			remove
			{
				base.ForeColorChanged -= value;
			}
		}

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> class. </summary>
		public ToolStripContainer()
		{
			SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, blnValue: true);
			SuspendLayout();
			try
			{
				mobjTopPanel = new ToolStripPanel(this);
				mobjBottomPanel = new ToolStripPanel(this);
				mobjLeftPanel = new ToolStripPanel(this);
				mobjRightPanel = new ToolStripPanel(this);
				mobjContentPanel = new ToolStripContentPanel();
				mobjContentPanel.Dock = DockStyle.Fill;
				mobjTopPanel.Dock = DockStyle.Top;
				mobjBottomPanel.Dock = DockStyle.Bottom;
				mobjRightPanel.Dock = DockStyle.Right;
				mobjLeftPanel.Dock = DockStyle.Left;
				if (Controls is ToolStripContainerTypedControlCollection toolStripContainerTypedControlCollection)
				{
					toolStripContainerTypedControlCollection.AddInternal(mobjContentPanel);
					toolStripContainerTypedControlCollection.AddInternal(mobjLeftPanel);
					toolStripContainerTypedControlCollection.AddInternal(mobjRightPanel);
					toolStripContainerTypedControlCollection.AddInternal(mobjTopPanel);
					toolStripContainerTypedControlCollection.AddInternal(mobjBottomPanel);
				}
			}
			finally
			{
				ResumeLayout(blnPerformLayout: true);
			}
		}

		/// Creates and returns a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</summary>
		/// A read-only <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override ControlCollection CreateControlsInstance()
		{
			return new ToolStripContainerTypedControlCollection(this, isReadOnly: true);
		}
	}
}
