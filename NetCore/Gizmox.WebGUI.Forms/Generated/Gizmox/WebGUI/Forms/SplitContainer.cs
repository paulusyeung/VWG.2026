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
	/// Represents a control consisting of a movable bar that divides a container's display area into two resizable panels.
	/// </summary>
	/// 
	/// You can add controls to the two resizable panels, and you can add other SplitContainer controls to existing SplitContainer panels to create many resizable display areas.
	/// Use the SplitContainer control to divide the display area of a container (such as a Form) and allow the user to resize controls that are added to the SplitContainer panels. When the user passes the mouse pointer over the splitter, the cursor changes to indicate that the controls inside the SplitContainer control can be resized.
	/// </remarks>
	[Serializable]
	[ToolboxItem(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[DefaultEvent("SplitterMoved")]
	[SRDescription("DescriptionSplitContainer")]
	[ComVisible(true)]
	[ToolboxBitmap(typeof(SplitContainer), "SplitContainer_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ToolboxItemCategory("Containers")]
	[MetadataTag("P")]
	[Skin(typeof(SplitContainerSkin))]
	public class SplitContainer : ContainerControl
	{
		/// 
		///
		/// </summary>
		[Serializable]
		[ToolboxItem(false)]
		private class ContainerSplitter : Splitter
		{
			private SplitContainer mobjSplitContainer;

			/// 
			/// Gets the critical events.
			/// </summary>
			/// </returns>
			protected override CriticalEventsData GetCriticalEventsData()
			{
				CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
				if (mobjSplitContainer != null)
				{
					if (mobjSplitContainer.IsSplitterMovedRegistered)
					{
						criticalEventsData.Set("PC");
					}
					if (mobjSplitContainer.IsCriticalEvent(Control.MouseClickEvent) || mobjSplitContainer.IsCriticalEvent(Control.MouseDownEvent) || mobjSplitContainer.IsCriticalEvent(Control.MouseUpEvent))
					{
						criticalEventsData.Set("CL");
					}
					if (mobjSplitContainer.IsCriticalEvent(Control.DoubleClickEvent))
					{
						criticalEventsData.Set("DCL");
					}
				}
				return criticalEventsData;
			}

			/// 
			/// Fires an event.
			/// </summary>
			/// <param name="objEvent">event.</param>
			protected override void FireEvent(IEvent objEvent)
			{
				base.FireEvent(objEvent);
				if (mobjSplitContainer == null)
				{
					return;
				}
				switch (objEvent.Type)
				{
				case "SplitterMoved":
				{
					SplitterPanel splitterPanel = ((mobjSplitContainer.FixedPanel == FixedPanel.Panel1) ? mobjSplitContainer.Panel1 : mobjSplitContainer.Panel2);
					if (splitterPanel == null)
					{
						break;
					}
					if (splitterPanel == mobjSplitContainer.Panel1)
					{
						if (mobjSplitContainer.Orientation == Orientation.Vertical)
						{
							mobjSplitContainer.SetSplitterDistanceDirectly(splitterPanel.Width);
						}
						else
						{
							mobjSplitContainer.SetSplitterDistanceDirectly(splitterPanel.Height);
						}
					}
					else if (mobjSplitContainer.Orientation == Orientation.Vertical)
					{
						mobjSplitContainer.SetSplitterDistanceDirectly(mobjSplitContainer.Width - (splitterPanel.Width + mobjSplitContainer.SplitterWidth));
					}
					else
					{
						mobjSplitContainer.SetSplitterDistanceDirectly(mobjSplitContainer.Height - (splitterPanel.Height + mobjSplitContainer.SplitterWidth));
					}
					break;
				}
				case "Click":
				case "DoubleClick":
					mobjSplitContainer.FireEvent(objEvent);
					break;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer.ContainerSplitter" /> class.
			/// </summary>
			internal ContainerSplitter()
			{
				base.Size = new Size(3, 3);
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer.ContainerSplitter" /> class.
			/// </summary>
			/// <param name="objSplitContainer">The SplitContainer.</param>
			internal ContainerSplitter(SplitContainer objSplitContainer)
				: this()
			{
				mobjSplitContainer = objSplitContainer;
			}

			/// 
			/// Gets the dock style.
			/// </summary>
			/// </returns>
			internal override DockStyle GetDockInternal()
			{
				if (base.Parent is SplitContainer splitContainer)
				{
					if (splitContainer.Orientation == Orientation.Vertical)
					{
						if (splitContainer.FixedPanel == FixedPanel.Panel2)
						{
							return DockStyle.Right;
						}
						return DockStyle.Left;
					}
					if (splitContainer.FixedPanel == FixedPanel.Panel2)
					{
						return DockStyle.Bottom;
					}
					return DockStyle.Top;
				}
				return base.GetDockInternal();
			}

			/// 
			/// Gets the anchor style.
			/// </summary>
			/// </returns>
			internal override AnchorStyles GetAnchorInternal()
			{
				return AnchorStyles.None;
			}
		}

		[Serializable]
		internal class SplitContainerTypedControlCollection : ClientUtils.TypedControlCollection
		{
			private SplitContainer mobjOwner;

			public SplitContainerTypedControlCollection(Control objControl, Type objType, bool blnIsReadOnly)
				: base(objControl, objType, blnIsReadOnly)
			{
				mobjOwner = objControl as SplitContainer;
			}

			public override void Remove(Control objValue)
			{
				if (objValue is SplitterPanel && !mobjOwner.DesignMode && IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				base.Remove(objValue);
			}

			internal override void SetChildIndexInternal(Control objChild, int intNewIndex)
			{
				if (objChild is SplitterPanel)
				{
					if (mobjOwner.DesignMode)
					{
						return;
					}
					if (IsReadOnly)
					{
						throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
					}
				}
				base.SetChildIndexInternal(objChild, intNewIndex);
			}
		}

		/// 
		/// Provides a property reference to TabStop property.
		/// </summary>
		private static SerializableProperty TabStopProperty = SerializableProperty.Register("TabStop", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to BorderStyle property.
		/// Default defined in the skin.
		/// </summary>
		private static SerializableProperty BorderStyleProperty = SerializableProperty.Register("BorderStyle", typeof(BorderStyle), typeof(SplitContainer));

		/// 
		/// Provides a property reference to AnchorPoint property.
		/// </summary>
		private static SerializableProperty AnchorPointProperty = SerializableProperty.Register("AnchorPoint", typeof(Point), typeof(SplitContainer), new SerializablePropertyMetadata(Point.Empty));

		/// 
		/// Provides a property reference to BorderSize property.
		/// </summary>
		private static SerializableProperty BorderSizeProperty = SerializableProperty.Register("BorderSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(0));

		private static readonly SerializableProperty SplitterDragProperty = SerializableProperty.Register("SplitterDrag", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitterFocusedProperty = SerializableProperty.Register("SplitterFocused", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitterWidthProperty = SerializableProperty.Register("SplitterWidth", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(4));

		private static readonly SerializableProperty Panel2MinSizeProperty = SerializableProperty.Register("Panel2MinSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(25));

		private static readonly SerializableProperty Panel1MinSizeProperty = SerializableProperty.Register("Panel1MinSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(25));

		private static readonly SerializableProperty Panel1Property = SerializableProperty.Register("Panel1", typeof(SplitterPanel), typeof(SplitContainer), new SerializablePropertyMetadata(null));

		private static readonly SerializableProperty Panel2Property = SerializableProperty.Register("Panel2", typeof(SplitterPanel), typeof(SplitContainer), new SerializablePropertyMetadata(null));

		private static readonly SerializableProperty SplitterIncrementProperty = SerializableProperty.Register("SplitterIncrement", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(1));

		private static readonly SerializableProperty SplitterRectangleInternalProperty = SerializableProperty.Register("SplitterRectangleInternal", typeof(Rectangle), typeof(SplitContainer), new SerializablePropertyMetadata(Rectangle.Empty));

		private static readonly SerializableProperty InitialSplitterRectangleProperty = SerializableProperty.Register("InitialSplitterRectangle", typeof(Rectangle), typeof(SplitContainer), new SerializablePropertyMetadata(default(Rectangle)));

		private static readonly SerializableProperty InitialSplitterDistanceProperty = SerializableProperty.Register("InitialSplitterDistance", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(0));

		private static readonly SerializableProperty FixedPanelProperty = SerializableProperty.Register("FixedPanel", typeof(FixedPanel), typeof(SplitContainer), new SerializablePropertyMetadata(FixedPanel.None));

		private static readonly SerializableProperty SplitterDistanceProperty = SerializableProperty.Register("SplitterDistance", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(50));

		private static readonly SerializableProperty SplitterDistanceInternalProperty = SerializableProperty.Register("SplitterDistanceInternal", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(50));

		private static readonly SerializableProperty SplitterClickProperty = SerializableProperty.Register("SplitterClick", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitterMoveProperty = SerializableProperty.Register("SplitMove", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitContainerScalingProperty = SerializableProperty.Register("SplitContainerScaling", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitBreakProperty = SerializableProperty.Register("SplitBreak", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SplitterBeginProperty = SerializableProperty.Register("SplitterBegin", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty SetSplitterDistanceProperty = SerializableProperty.Register("SetSplitterDistance", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty ResizeCalledProperty = SerializableProperty.Register("ResizeCalled", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty RatioWidthProperty = SerializableProperty.Register("RatioWidth", typeof(double), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty RatioHeightProperty = SerializableProperty.Register("RatioHeight", typeof(double), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty PanelSizeProperty = SerializableProperty.Register("PanelSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty OverrideCursorProperty = SerializableProperty.Register("OverrideCursor", typeof(Cursor), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty LastDrawSplitProperty = SerializableProperty.Register("LastDrawSplit", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(1));

		private static readonly SerializableProperty OrientationProperty = SerializableProperty.Register("Orientation", typeof(Orientation), typeof(SplitContainer), new SerializablePropertyMetadata(Orientation.Vertical));

		private static readonly SerializableProperty NextActiveControlProperty = SerializableProperty.Register("NextActiveControl", typeof(Control), typeof(SplitContainer), new SerializablePropertyMetadata(false));

		private static readonly SerializableProperty ContainerSplitterPrivateProperty = SerializableProperty.Register("ContainerSplitterPrivate", typeof(ContainerSplitter), typeof(SplitContainer), new SerializablePropertyMetadata(null));

		private static readonly SerializableEvent EVENT_MOVED = SerializableEvent.Register("Event", typeof(Delegate), typeof(SplitContainer));

		private static readonly SerializableEvent EVENT_MOVING = SerializableEvent.Register("Event", typeof(Delegate), typeof(SplitContainer));

		private const int DRAW_END = 3;

		private const int DRAW_MOVE = 2;

		private const int DRAW_START = 1;

		private const int mcntRightBorder = 5;

		private const int mcntLeftBorder = 2;

		/// 
		/// The Border size of the SplitContainer as int.
		/// Used to calculate movement and distances.
		/// </summary>
		private int BorderSize
		{
			get
			{
				return GetValue(BorderSizeProperty);
			}
			set
			{
				SetValue(BorderSizeProperty, value);
			}
		}

		/// 
		/// A boolean indicating whether in this instance the splitter has focus.
		/// Used to calculate movement and distances.
		/// </summary>
		/// 
		/// 	true</c> if in this instance the splitter is focused. otherwise, false</c>.
		/// </value>
		private bool SplitterFocused
		{
			get
			{
				return GetValue(SplitterFocusedProperty);
			}
			set
			{
				if (SplitterFocused != value)
				{
					SetValue(SplitterFocusedProperty, value);
				}
			}
		}

		/// 
		/// A boolean indicating whether this instance the splitter is dragged.
		/// Used in splitter movement.
		/// </summary>
		/// 
		/// 	true</c> if this instance the splitter is dragged. otherwise, false</c>.
		/// </value>
		private bool SplitterDrag
		{
			get
			{
				return GetValue(SplitterDragProperty);
			}
			set
			{
				SetValue(SplitterDragProperty, value);
			}
		}

		/// 
		/// Get/Set Boolean indicating whether safe to set the SplitterDistance.
		/// </summary>
		/// true</c> if safe to set the SplitterDistance, false</c> otherwise.</value>
		private bool SetSplitterDistance
		{
			get
			{
				return GetValue(SetSplitterDistanceProperty);
			}
			set
			{
				SetValue(SetSplitterDistanceProperty, value);
			}
		}

		/// 
		/// Get/Set An integer indicating the perpendicular length of the fixed panel 
		/// to the splitter. If Fixed. None, the value is the length of the bottom/right panel.
		/// </summary>
		private int PanelSize
		{
			get
			{
				return GetValue(PanelSizeProperty);
			}
			set
			{
				SetValue(PanelSizeProperty, value);
			}
		}

		/// 
		/// Get/Set The next active Control.
		/// </summary>
		private Control NextActiveControl
		{
			get
			{
				return GetValue(NextActiveControlProperty);
			}
			set
			{
				SetValue(NextActiveControlProperty, value);
			}
		}

		/// 
		/// A double value used to hold the ratio between the height of the base conrol and 
		/// another, e.g. splitter width, panel1 width etc.
		/// </summary>
		private double RatioHeight
		{
			get
			{
				return GetValue(RatioHeightProperty);
			}
			set
			{
				SetValue(RatioHeightProperty, value);
			}
		}

		/// 
		/// A double value used to hold the ratio between the width of the base conrol and 
		/// another, e.g. splitter width, panel1 width etc.
		/// </summary>
		private double RatioWidth
		{
			get
			{
				return GetValue(RatioWidthProperty);
			}
			set
			{
				SetValue(RatioWidthProperty, value);
			}
		}

		/// 
		/// Boolean indicating whether to begin actions on the splitter.
		/// </summary>
		/// true</c> if to begin actions on the splitter, false</c> otherwise.</value>
		private bool SplitterBegin
		{
			get
			{
				return GetValue(SplitterBeginProperty);
			}
			set
			{
				SetValue(SplitterBeginProperty, value);
			}
		}

		/// 
		/// Get\Set a boolean indicating whether resize on the control was called.
		/// Used to indicate for example whether to update the ratio width/height.
		/// </summary>
		/// true</c> if resize on the control was called, false</c> otherwise.</value>
		private bool ResizeCalled
		{
			get
			{
				return GetValue(ResizeCalledProperty);
			}
			set
			{
				SetValue(ResizeCalledProperty, value);
			}
		}

		/// 
		/// Boolean indicating whether to break actions on the splitter.
		/// </summary>
		/// true</c> if to break actions on the splitter, false</c> otherwise.</value>
		private bool SplitBreak
		{
			get
			{
				return GetValue(SplitBreakProperty);
			}
			set
			{
				SetValue(SplitBreakProperty, value);
			}
		}

		/// 
		/// Boolean indicating whether the splitContainer is in scaling process.
		/// </summary>
		/// true</c> if the splitter is in scaling process, false</c> otherwise.</value>
		private bool SplitContainerScaling
		{
			get
			{
				return GetValue(SplitContainerScalingProperty);
			}
			set
			{
				SetValue(SplitContainerScalingProperty, value);
			}
		}

		/// 
		/// Boolean indicating whether the splitter is in movement.
		/// </summary>
		/// true</c> if the splitter is in movement, false</c> otherwise.</value>
		private bool SplitterMove
		{
			get
			{
				return GetValue(SplitterMoveProperty);
			}
			set
			{
				SetValue(SplitterMoveProperty, value);
			}
		}

		/// 
		/// Boolean indicating whether the splitter is clicked.
		/// </summary>
		/// true</c> if the splitter is clicked, false</c> otherwise.</value>
		private bool SplitterClick
		{
			get
			{
				return GetValue(SplitterClickProperty);
			}
			set
			{
				SetValue(SplitterClickProperty, value);
			}
		}

		/// 
		/// The Anchor of the SplitContainer as Point object
		/// </summary>
		private Point AnchorPoint
		{
			get
			{
				return GetValue(AnchorPointProperty);
			}
			set
			{
				SetValue(AnchorPointProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether to reverse control rendering.
		/// </summary>
		/// 
		/// 	true</c> if to reverse control rendering; otherwise, false</c>.
		/// </value>
		protected override bool ReverseControls => FixedPanel == FixedPanel.Panel2;

		/// 
		/// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
		/// </summary>
		/// 
		/// true if the container enables auto-scrolling; otherwise, false. The default value is false.
		/// </value>
		[SRDescription("FormAutoScrollDescr")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[DefaultValue(false)]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		public override bool AutoScroll
		{
			get
			{
				return false;
			}
			set
			{
				base.AutoScroll = value;
			}
		}

		/// 
		/// This property is not relevant for this class.
		/// </summary>
		/// </value>
		/// true if enabled; otherwise, false.</returns>
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

		/// 
		/// Gets or sets the background image displayed in the control.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[ProxyBrowsable(true)]
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

		/// 
		/// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
		/// </summary>
		/// </value>
		/// One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		/// 
		/// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
		/// </summary>
		/// </value>
		/// The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
		[SRDescription("ContainerControlBindingContextDescr")]
		[Browsable(false)]
		public override BindingContext BindingContext
		{
			get
			{
				return base.BindingContextInternal;
			}
			set
			{
				base.BindingContextInternal = value;
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[DefaultValue(0)]
		[DispId(-504)]
		[SRDescription("SplitterBorderStyleDescr")]
		public new BorderStyle BorderStyle
		{
			get
			{
				return GetValue(BorderStyleProperty, base.Skin.BorderStyle);
			}
			set
			{
				if (!Enum.IsDefined(typeof(BorderStyle), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));
				}
				BorderStyle borderStyle = base.Skin.BorderStyle;
				if (SetValue(BorderStyleProperty, value, borderStyle) && borderStyle != value)
				{
					Invalidate();
					SetInnerMostBorder(this);
					Control control = ParentInternal as SplitterPanel;
					if (control != null)
					{
						SplitContainer owner = ((SplitterPanel)control).Owner;
						owner.SetInnerMostBorder(owner);
					}
				}
				switch (value)
				{
				case BorderStyle.None:
					BorderSize = 0;
					break;
				case BorderStyle.FixedSingle:
					BorderSize = 1;
					break;
				case BorderStyle.Fixed3D:
					BorderSize = 4;
					break;
				}
			}
		}

		private bool CollapsedMode
		{
			get
			{
				if (!Panel1Collapsed)
				{
					return Panel2Collapsed;
				}
				return true;
			}
		}

		/// 
		/// Gets the collection of controls contained within the control.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new ControlCollection Controls => base.Controls;

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(150, 100);

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		/// </value>
		public new DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
				if (ParentInternal != null && ParentInternal is SplitterPanel)
				{
					SplitContainer owner = ((SplitterPanel)ParentInternal).Owner;
					owner.SetInnerMostBorder(owner);
				}
				ResizeSplitContainer();
			}
		}

		/// 
		/// Gets or sets the initial size and location of the splitter relative to the SplitContainer.
		/// Used as preliminary in calculations of drawing the splitter.
		/// The default value is .net Deafult of type Rectangle.
		/// </summary>
		/// Rectangle, The default value is .net Deafult of type Rectangle.</value>
		[SRCategory("CatLayout")]
		[SRDescription("SplitContainerFixedPanelDescr")]
		[DefaultValue(0)]
		private Rectangle InitialSplitterRectangle
		{
			get
			{
				return GetValue(InitialSplitterRectangleProperty);
			}
			set
			{
				SetValue(InitialSplitterRectangleProperty, value);
			}
		}

		/// 
		/// Gets or sets the initial location of the splitter, in pixels, from the left or top 
		/// edge of the SplitContainer.
		/// Used as preliminary in calculations of drawing the splitter.
		/// The default value is 0.
		/// </summary>
		/// Integer, The default value is 0.</value>
		[SRCategory("CatLayout")]
		[SRDescription("SplitContainerFixedPanelDescr")]
		[DefaultValue(0)]
		private int InitialSplitterDistance
		{
			get
			{
				return GetValue(InitialSplitterDistanceProperty);
			}
			set
			{
				SetValue(InitialSplitterDistanceProperty, value);
			}
		}

		/// 
		/// Gets or sets which SplitContainer panel remains the same size when the container 
		/// is resized. 
		/// The value is one of the values of FixedPanel enum. 
		/// </summary>
		/// One of the values of FixedPanel enum. The default value is None. </value>
		[SRCategory("CatLayout")]
		[SRDescription("SplitContainerFixedPanelDescr")]
		[DefaultValue(0)]
		public FixedPanel FixedPanel
		{
			get
			{
				return GetValue(FixedPanelProperty);
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(FixedPanel));
				}
				if (!SetValue(FixedPanelProperty, value))
				{
					return;
				}
				if (value == FixedPanel.Panel2)
				{
					if (Orientation == Orientation.Vertical)
					{
						PanelSize = base.Width - SplitterDistanceInternal - SplitterWidthInternal;
					}
					else
					{
						PanelSize = base.Height - SplitterDistanceInternal - SplitterWidthInternal;
					}
				}
				else
				{
					PanelSize = SplitterDistanceInternal;
				}
				Update();
				FireObservableItemPropertyChanged("FixedPanel");
			}
		}

		internal override bool IsContainerControl => true;

		/// 
		/// Gets the critical events internal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is splitter moved registered; otherwise, false</c>.
		/// </value>
		/// </returns>
		internal bool IsSplitterMovedRegistered => this.SplitterMoved != null;

		/// 
		/// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
		/// </summary>
		/// 
		/// 	true</c> if this instance is splitter fixed. otherwise, false</c>.
		/// </value>
		[SRCategory("CatLayout")]
		[SRDescription("SplitContainerIsSplitterFixedDescr")]
		[DefaultValue(false)]
		[Localizable(true)]
		public bool IsSplitterFixed
		{
			get
			{
				return ContainerSplitterPrivate?.IsSplitterFixed ?? false;
			}
			set
			{
				ContainerSplitter containerSplitterPrivate = ContainerSplitterPrivate;
				if (containerSplitterPrivate != null)
				{
					containerSplitterPrivate.IsSplitterFixed = value;
				}
			}
		}

		private bool IsSplitterMovable
		{
			get
			{
				if (Orientation == Orientation.Vertical)
				{
					return base.Width >= Panel1MinSize + SplitterWidthInternal + Panel2MinSize;
				}
				return base.Height >= Panel1MinSize + SplitterWidthInternal + Panel2MinSize;
			}
		}

		/// 
		/// Gets or sets the orientation.
		/// </summary>
		/// The orientation.</value>
		[SRCategory("CatBehavior")]
		[SRDescription("SplitContainerOrientationDescr")]
		[DefaultValue(1)]
		[Localizable(true)]
		public Orientation Orientation
		{
			get
			{
				return GetValue(OrientationProperty);
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(Orientation));
				}
				if (SetValue(OrientationProperty, value))
				{
					SetSplitterDistanceDirectly(0);
					SplitterDistance = SplitterDistanceInternal;
					UpdateSplitter();
					FireObservableItemPropertyChanged("Orientation");
					Update();
				}
			}
		}

		/// 
		/// Get/Set a private instance of ContainerSplitter
		/// </summary>
		private ContainerSplitter ContainerSplitterPrivate
		{
			get
			{
				return GetValue(ContainerSplitterPrivateProperty);
			}
			set
			{
				SetValue(ContainerSplitterPrivateProperty, value);
			}
		}

		/// 
		/// Get/Set an integer holding the length of the splitBar (on move).
		/// </summary>
		private int LastDrawSplit
		{
			get
			{
				return GetValue(LastDrawSplitProperty);
			}
			set
			{
				SetValue(LastDrawSplitProperty, value);
			}
		}

		/// 
		/// Get/Set the cursur when set over the splitter (vertical/horizontal).
		/// </summary>
		private Cursor OverrideCursor
		{
			get
			{
				return GetValue(OverrideCursorProperty);
			}
			set
			{
				SetValue(OverrideCursorProperty, value);
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		/// 
		/// Gets the left or top panel of the SplitContainer, depending on Orientation. 
		/// </summary>
		/// The left or top panel of the SplitContainer, depending on Orientation, as SplitterPanel. </value>
		[SRCategory("CatAppearance")]
		[Localizable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("SplitContainerPanel1Descr")]
		public SplitterPanel Panel1
		{
			get
			{
				return GetValue(Panel1Property);
			}
			private set
			{
				SetValue(Panel1Property, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [panel1 collapsed].
		/// </summary>
		/// true</c> if [panel1 collapsed]; otherwise, false</c>.</value>
		[SRDescription("SplitContainerPanel1CollapsedDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(false)]
		public bool Panel1Collapsed
		{
			get
			{
				return Panel1.Collapsed;
			}
			set
			{
				SplitterPanel panel = Panel1;
				if (value != panel.Collapsed)
				{
					if (value && Panel2.Collapsed)
					{
						CollapsePanel(Panel2, blnCollapsing: false);
					}
					CollapsePanel(panel, value);
					FireObservableItemPropertyChanged("Panel1Collapsed");
				}
			}
		}

		/// 
		/// Gets or sets the minimum distance in pixels of the splitter from the left or top 
		/// edge of Panel1. 
		/// </summary>
		/// The minimum distance in pixels of the splitter from the left or top edge of 
		/// Panel1.</value>
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[DefaultValue(25)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("SplitContainerPanel1MinSizeDescr")]
		public int Panel1MinSize
		{
			get
			{
				return GetValue(Panel1MinSizeProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidLowBoundArgument", "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture), "0"));
				}
				if (Orientation == Orientation.Vertical)
				{
					if (base.DesignMode && base.Width != DefaultSize.Width && value + Panel2MinSize + SplitterWidth > base.Width)
					{
						throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidArgument", "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture)));
					}
				}
				else if (Orientation == Orientation.Horizontal && base.DesignMode && base.Height != DefaultSize.Height && value + Panel2MinSize + SplitterWidth > base.Height)
				{
					throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidArgument", "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(Panel1MinSizeProperty, value) && value > SplitterDistanceInternal)
				{
					SplitterDistance = value;
					FireObservableItemPropertyChanged("Panel1MinSize");
				}
			}
		}

		/// 
		/// Gets the right or bottom panel of the SplitContainer, depending on Orientation. 
		/// </summary>
		/// Gets the right or bottom panel of the SplitContainer, depending on Orientation. </value>
		[SRCategory("CatAppearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("SplitContainerPanel2Descr")]
		[Localizable(false)]
		public SplitterPanel Panel2
		{
			get
			{
				return GetValue(Panel2Property);
			}
			private set
			{
				SetValue(Panel2Property, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [panel2 collapsed].
		/// </summary>
		/// true</c> if [panel2 collapsed]; otherwise, false</c>.</value>
		[SRCategory("CatLayout")]
		[SRDescription("SplitContainerPanel2CollapsedDescr")]
		[DefaultValue(false)]
		public bool Panel2Collapsed
		{
			get
			{
				return Panel2.Collapsed;
			}
			set
			{
				SplitterPanel panel = Panel1;
				SplitterPanel panel2 = Panel2;
				if (value != panel2.Collapsed)
				{
					if (value && panel.Collapsed)
					{
						CollapsePanel(panel, blnCollapsing: false);
					}
					CollapsePanel(panel2, value);
					FireObservableItemPropertyChanged("Panel2Collapsed");
				}
			}
		}

		/// 
		/// Gets or sets the minimum distance in pixels of the splitter from the right or 
		/// bottom edge of Panel2. 
		/// </summary>
		/// The minimum distance in pixels of the splitter from the right or 
		/// bottom edge of Panel2.</value>
		[SRCategory("CatLayout")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(25)]
		[Localizable(true)]
		[SRDescription("SplitContainerPanel2MinSizeDescr")]
		public int Panel2MinSize
		{
			get
			{
				return GetValue(Panel2MinSizeProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidLowBoundArgument", "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture), "0"));
				}
				if (Orientation == Orientation.Vertical)
				{
					if (base.DesignMode && base.Width != DefaultSize.Width && value + Panel1MinSize + SplitterWidth > base.Width)
					{
						throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidArgument", "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture)));
					}
				}
				else if (Orientation == Orientation.Horizontal && base.DesignMode && base.Height != DefaultSize.Height && value + Panel1MinSize + SplitterWidth > base.Height)
				{
					throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidArgument", "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(Panel2MinSizeProperty, value))
				{
					if (value > Panel2.Width)
					{
						SplitterDistance = Panel2.Width + SplitterWidthInternal;
					}
					FireObservableItemPropertyChanged("Panel2MinSize");
				}
			}
		}

		/// 
		/// Gets or sets the location of the splitter, in pixels, from the left or top edge 
		/// of the SplitContainer. 
		/// </summary>
		/// The splitter distance.</value>
		[DefaultValue(50)]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		[SRDescription("SplitContainerSplitterDistanceDescr")]
		[SettingsBindable(true)]
		public int SplitterDistance
		{
			get
			{
				return GetValue(SplitterDistanceProperty);
			}
			set
			{
				if (value == SplitterDistance)
				{
					return;
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SplitterDistance", SR.GetString("InvalidLowBoundArgument", "SplitterDistance", value.ToString(CultureInfo.CurrentCulture), "0"));
				}
				try
				{
					SetSplitterDistance = true;
					if (Orientation == Orientation.Vertical)
					{
						if (value < Panel1MinSize)
						{
							value = Panel1MinSize;
						}
						if (value + SplitterWidthInternal > base.Width - Panel2MinSize)
						{
							value = base.Width - Panel2MinSize - SplitterWidthInternal;
						}
						if (value < 0)
						{
							throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
						}
						SetValue(SplitterDistanceProperty, value);
						SetValue(SplitterDistanceInternalProperty, value);
						Panel1.WidthInternal = value;
					}
					else
					{
						if (value < Panel1MinSize)
						{
							value = Panel1MinSize;
						}
						if (value + SplitterWidthInternal > base.Height - Panel2MinSize)
						{
							value = base.Height - Panel2MinSize - SplitterWidthInternal;
						}
						if (value < 0)
						{
							throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
						}
						SetValue(SplitterDistanceProperty, value);
						SetValue(SplitterDistanceInternalProperty, value);
						Panel1.HeightInternal = value;
					}
					switch (FixedPanel)
					{
					case FixedPanel.Panel1:
						PanelSize = value;
						break;
					case FixedPanel.Panel2:
						if (Orientation == Orientation.Vertical)
						{
							PanelSize = base.Width - value - SplitterWidthInternal;
						}
						else
						{
							PanelSize = base.Height - value - SplitterWidthInternal;
						}
						break;
					}
					UpdateSplitter();
				}
				finally
				{
					SetSplitterDistance = false;
				}
				OnSplitterMovedInternal();
				FireObservableItemPropertyChanged("SplitterDistance");
			}
		}

		/// 
		/// Gets or sets the location of the splitter, in pixels, from the left or top edge 
		/// of the SplitContainer. For private use. 
		/// </summary>
		/// The splitter distance.</value>
		private int SplitterDistanceInternal
		{
			get
			{
				return GetValue(SplitterDistanceInternalProperty);
			}
			set
			{
				SetValue(SplitterDistanceInternalProperty, value);
			}
		}

		/// 
		/// Gets or sets a value representing the increment of splitter movement in pixels. 
		/// Used for movement calculations mainly.
		/// </summary>
		/// The splitter increment as int, Default is 1.</value>
		[DefaultValue(1)]
		[SRDescription("SplitContainerSplitterIncrementDescr")]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		public int SplitterIncrement
		{
			get
			{
				return GetValue(SplitterIncrementProperty);
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("SplitterIncrement", SR.GetString("InvalidLowBoundArgumentEx", "SplitterIncrement", value.ToString(CultureInfo.CurrentCulture), "1"));
				}
				if (SetValue(SplitterIncrementProperty, value))
				{
					FireObservableItemPropertyChanged("SplitterIncrement");
				}
			}
		}

		/// 
		/// Gets the size and location of the splitter relative to the SplitContainer. 
		/// </summary>
		/// The splitter rectangle.</value>
		[Browsable(false)]
		[SRDescription("SplitContainerSplitterRectangleDescr")]
		[SRCategory("CatLayout")]
		public Rectangle SplitterRectangle
		{
			get
			{
				Rectangle splitterRectangleInternal = SplitterRectangleInternal;
				splitterRectangleInternal.X -= base.Left;
				splitterRectangleInternal.Y -= base.Top;
				return splitterRectangleInternal;
			}
		}

		/// 
		/// Gets or sets the size and location of the splitter relative to the SplitContainer
		/// for internal use. manipulated in the public property for outside use.
		/// Used as preliminary in calculations of drawing the splitter.
		/// The default value is .net Deafult of type Rectangle.
		/// </summary>
		/// Rectangle, The default value is .net Deafult of type Rectangle.</value>
		[Browsable(false)]
		[SRDescription("SplitContainerSplitterRectangleDescr")]
		[SRCategory("CatLayout")]
		private Rectangle SplitterRectangleInternal
		{
			get
			{
				return GetValue(SplitterRectangleInternalProperty);
			}
			set
			{
				SetValue(SplitterRectangleInternalProperty, value);
			}
		}

		/// 
		/// Gets or sets the width of the splitter. Default value is 4.
		/// </summary>
		/// The width of the splitter. Default value is 4.</value>
		[SRDescription("SplitContainerSplitterWidthDescr")]
		[Localizable(true)]
		[DefaultValue(4)]
		[SRCategory("CatLayout")]
		public int SplitterWidth
		{
			get
			{
				return GetValue(SplitterWidthProperty);
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidLowBoundArgumentEx", "SplitterWidth", value.ToString(CultureInfo.CurrentCulture), "1"));
				}
				if (Orientation == Orientation.Vertical)
				{
					if (base.DesignMode && value + Panel1MinSize + Panel2MinSize > base.Width)
					{
						throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidArgument", "SplitterWidth", value.ToString(CultureInfo.CurrentCulture)));
					}
				}
				else if (Orientation == Orientation.Horizontal && base.DesignMode && value + Panel1MinSize + Panel2MinSize > base.Height)
				{
					throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidArgument", "SplitterWidth", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(SplitterWidthProperty, value))
				{
					UpdateSplitter();
					FireObservableItemPropertyChanged("SplitterWidth");
				}
			}
		}

		private int SplitterWidthInternal
		{
			get
			{
				if (!CollapsedMode)
				{
					return SplitterWidth;
				}
				return 0;
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[SRDescription("ControlTabStopDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[DispId(-516)]
		public new bool TabStop
		{
			get
			{
				return GetValue(TabStopProperty);
			}
			set
			{
				SetValue(TabStopProperty, value);
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Bindable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// 
		/// Occurs when [auto size changed].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler AutoSizeChanged;

		/// 
		/// Occurs when the value of the BackgroundImage property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public new event EventHandler BackgroundImageChanged;

		/// 
		/// Occurs when the BackgroundImageLayout property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler BackgroundImageLayoutChanged;

		/// 
		/// Occurs when a new control is added to the ControlCollection.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event ControlEventHandler ControlAdded;

		/// 
		/// Occurs when a control is removed from the ControlCollection.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ControlEventHandler ControlRemoved;

		/// 
		/// Occurs when the PaddingChanged property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler PaddingChanged;

		/// 
		/// Occurs when [splitter moved].
		/// </summary>
		[SRDescription("SplitterSplitterMovedDescr")]
		[SRCategory("CatBehavior")]
		public event SplitterEventHandler SplitterMoved;

		/// 
		/// Occurs when [splitter moving].
		/// </summary>
		[SRDescription("SplitterSplitterMovingDescr")]
		[SRCategory("CatBehavior")]
		public event SplitterCancelEventHandler SplitterMoving;

		/// 
		/// Occurs when the Text property value changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler TextChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer" /> class.
		/// </summary>
		public SplitContainer()
		{
			Orientation = Orientation.Vertical;
			Panel1MinSize = 25;
			Panel2MinSize = 25;
			TabStop = true;
			SplitterIncrement = 1;
			SplitterDistanceInternal = 50;
			SplitterWidth = 4;
			SetSplitterDistanceDirectly(50);
			LastDrawSplit = 1;
			AnchorPoint = Point.Empty;
			Panel1 = new SplitterPanel(this);
			Panel1.TabIndex = 0;
			ContainerSplitterPrivate = new ContainerSplitter(this);
			ContainerSplitterPrivate.TabIndex = 1;
			Panel2 = new SplitterPanel(this);
			Panel2.TabIndex = 2;
			SplitterRectangleInternal = default(Rectangle);
			SetStyle(ControlStyles.SupportsTransparentBackColor, blnValue: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, blnValue: true);
			((ClientUtils.TypedControlCollection)Controls).AddInternal(Panel2);
			((ClientUtils.TypedControlCollection)Controls).AddInternal(ContainerSplitterPrivate);
			((ClientUtils.TypedControlCollection)Controls).AddInternal(Panel1);
			UpdateSplitter();
		}

		/// 
		/// Renders the panel type attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("TP", "Normal");
		}

		/// 
		/// Raise the splitter moved event.
		/// </summary>
		internal void OnSplitterMovedInternal()
		{
			Rectangle splitterRectangle = SplitterRectangle;
			bool flag = true;
			OnSplitterMoved(new SplitterEventArgs(splitterRectangle.X + splitterRectangle.Width / 2, splitterRectangle.Y + splitterRectangle.Height / 2, splitterRectangle.X, splitterRectangle.Y));
		}

		/// 
		/// Raises the <see cref="E:SplitterMoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
		public virtual void OnSplitterMoved(SplitterEventArgs e)
		{
			this.SplitterMoved?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:SplitterMoving" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterCancelEventArgs" /> instance containing the event data.</param>
		public void OnSplitterMoving(SplitterCancelEventArgs e)
		{
			((SplitterCancelEventHandler)GetHandler(EVENT_MOVING))?.Invoke(this, e);
		}

		/// 
		/// Creates the controls instance.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override ControlCollection CreateControlsInstance()
		{
			return new SplitContainerTypedControlCollection(this, typeof(SplitterPanel), blnIsReadOnly: true);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (!IsSplitterMovable || IsSplitterFixed)
			{
				return;
			}
			bool splitterFocused = SplitterFocused;
			if (e.KeyData == Keys.Escape && SplitterBegin)
			{
				SplitterBegin = false;
				SplitBreak = true;
			}
			else
			{
				if (e.KeyData != Keys.Right && e.KeyData != Keys.Down && e.KeyData != Keys.Left && !(e.KeyData == Keys.Up && splitterFocused))
				{
					return;
				}
				if (SplitterBegin)
				{
					SplitterMove = true;
				}
				int borderSize = BorderSize;
				if (e.KeyData == Keys.Left || (e.KeyData == Keys.Up && splitterFocused))
				{
					int splitterDistanceInternal = SplitterDistanceInternal;
					splitterDistanceInternal -= SplitterIncrement;
					SplitterDistanceInternal = ((splitterDistanceInternal < Panel1MinSize) ? (splitterDistanceInternal + SplitterIncrement) : Math.Max(splitterDistanceInternal, borderSize));
				}
				if (e.KeyData == Keys.Right || (e.KeyData == Keys.Down && splitterFocused))
				{
					int splitterDistanceInternal2 = SplitterDistanceInternal;
					splitterDistanceInternal2 += SplitterIncrement;
					if (Orientation == Orientation.Vertical)
					{
						SplitterDistanceInternal = ((splitterDistanceInternal2 + SplitterWidth > base.Width - Panel2MinSize - borderSize) ? (splitterDistanceInternal2 - SplitterIncrement) : splitterDistanceInternal2);
					}
					else
					{
						SplitterDistanceInternal = ((splitterDistanceInternal2 + SplitterWidth > base.Height - Panel2MinSize - borderSize) ? (splitterDistanceInternal2 - SplitterIncrement) : splitterDistanceInternal2);
					}
				}
				if (!SplitterBegin)
				{
					SplitterBegin = true;
				}
				if (SplitterBegin && !SplitterMove)
				{
					InitialSplitterDistance = SplitterDistanceInternal;
					DrawSplitBar(1);
					return;
				}
				DrawSplitBar(2);
				Rectangle rectangle = CalcSplitLine(SplitterDistanceInternal, 0);
				int x = rectangle.X;
				int y = rectangle.Y;
				Rectangle splitterRectangle = SplitterRectangle;
				SplitterCancelEventArgs e2 = new SplitterCancelEventArgs(base.Left + splitterRectangle.X + splitterRectangle.Width / 2, base.Top + splitterRectangle.Y + splitterRectangle.Height / 2, x, y);
				OnSplitterMoving(e2);
				if (e2.Cancel)
				{
					SplitEnd(blnAccept: false);
				}
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (SplitterBegin && IsSplitterMovable && (e.KeyData == Keys.Right || e.KeyData == Keys.Down || e.KeyData == Keys.Left || (e.KeyData == Keys.Up && SplitterFocused)))
			{
				DrawSplitBar(3);
				ApplySplitterDistance();
				SplitterBegin = false;
				SplitterMove = false;
			}
			if (SplitBreak)
			{
				SplitBreak = false;
				SplitEnd(blnAccept: false);
			}
		}

		/// 
		/// Raises the <see cref="E:Layout" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		protected override void OnLayout(LayoutEventArgs e)
		{
			SetInnerMostBorder(this);
			if (IsSplitterMovable && !SetSplitterDistance)
			{
				ResizeSplitContainer();
			}
		}

		/// 
		/// Raises the <see cref="E:LostFocus" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			Invalidate();
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
		/// Implemented by design as Click (Use Click instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!IsSplitterMovable || !SplitterRectangle.Contains(new Point(e.X, e.Y)) || !base.Enabled || e.Button != MouseButtons.Left || e.Clicks != 1 || IsSplitterFixed)
			{
				return;
			}
			SplitterFocused = true;
			IContainerControl containerControlInternal = ParentInternal.GetContainerControlInternal();
			if (containerControlInternal != null)
			{
				if (!(containerControlInternal is ContainerControl containerControl))
				{
					containerControlInternal.ActiveControl = this;
				}
				else
				{
					containerControl.SetActiveControlInternal(this);
				}
			}
			SetActiveControlInternal(null);
			NextActiveControl = Panel2;
			SplitBegin(e.X, e.Y);
			SplitterClick = true;
		}

		/// 
		/// Raises the <see cref="E:MouseLeave" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected void OnMouseLeave(EventArgs e)
		{
			if (base.Enabled)
			{
				OverrideCursor = null;
			}
		}

		/// 
		/// Raises the <see cref="E:MouseMove" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void OnMouseMove(MouseEventArgs e)
		{
			if (IsSplitterFixed || !IsSplitterMovable)
			{
				return;
			}
			if (Cursor == Cursors.Default && SplitterRectangle.Contains(new Point(e.X, e.Y)))
			{
				if (Orientation == Orientation.Vertical)
				{
					OverrideCursor = Cursors.VSplit;
				}
				else
				{
					OverrideCursor = Cursors.HSplit;
				}
			}
			else
			{
				OverrideCursor = null;
			}
			if (SplitterClick)
			{
				int x = e.X;
				int y = e.Y;
				SplitterDrag = true;
				SplitMove(x, y);
				if (Orientation == Orientation.Vertical)
				{
					x = Math.Max(Math.Min(x, base.Width - Panel2MinSize), Panel1MinSize);
					y = Math.Max(y, 0);
				}
				else
				{
					y = Math.Max(Math.Min(y, base.Height - Panel2MinSize), Panel1MinSize);
					x = Math.Max(x, 0);
				}
				Rectangle rectangle = CalcSplitLine(GetSplitterDistance(e.X, e.Y), 0);
				int x2 = rectangle.X;
				int y2 = rectangle.Y;
				SplitterCancelEventArgs e2 = new SplitterCancelEventArgs(x, y, x2, y2);
				OnSplitterMoving(e2);
				if (e2.Cancel)
				{
					SplitEnd(blnAccept: false);
				}
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
		/// Implemented by design as Click (Use Click instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (base.Enabled && !IsSplitterFixed && IsSplitterMovable && SplitterClick)
			{
				if (SplitterDrag)
				{
					CalcSplitLine(GetSplitterDistance(e.X, e.Y), 0);
					SplitEnd(blnAccept: true);
				}
				else
				{
					SplitEnd(blnAccept: false);
				}
				SplitterClick = false;
				SplitterDrag = false;
			}
		}

		/// 
		/// Raises the <see cref="E:RightToLeftChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void OnRightToLeftChanged(EventArgs e)
		{
			Panel1.RightToLeft = RightToLeft;
			Panel2.RightToLeft = RightToLeft;
			UpdateSplitter();
		}

		/// 
		/// Scales the control.
		/// </summary>
		/// <param name="objFactor">The factor.</param>
		/// <param name="enmSpecified">The specified.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified)
		{
			try
			{
				SplitContainerScaling = true;
				float num = ((Orientation != Orientation.Vertical) ? objFactor.Height : objFactor.Width);
				SplitterWidth = (int)Math.Round((float)SplitterWidth * num);
			}
			finally
			{
				SplitContainerScaling = false;
			}
		}

		/// 
		/// Sets the bounds core.
		/// </summary>
		/// <param name="intX">The x.</param>
		/// <param name="intY">The y.</param>
		/// <param name="intWidth">The width.</param>
		/// <param name="intHeight">The height.</param>
		/// <param name="enmSpecified">The specified.</param>
		protected new void SetBoundsCore(int intX, int intY, int intWidth, int intHeight, BoundsSpecified enmSpecified)
		{
			if ((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && Orientation == Orientation.Horizontal && intHeight < Panel1MinSize + SplitterWidthInternal + Panel2MinSize)
			{
				intHeight = Panel1MinSize + SplitterWidthInternal + Panel2MinSize;
			}
			if ((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None && Orientation == Orientation.Vertical && intWidth < Panel1MinSize + SplitterWidthInternal + Panel2MinSize)
			{
				intWidth = Panel1MinSize + SplitterWidthInternal + Panel2MinSize;
			}
			SetSplitterRect(Orientation == Orientation.Vertical);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			base.RenderControls(objContext, objWriter, lngRequestID);
		}

		/// 
		/// SplitterDistance - The location of the splitter, in pixels, from the left or top edge 
		/// of the SplitContainer. The public setter changes the value, this method changes the value
		/// without manipulation to it.
		/// </summary>
		private void SetSplitterDistanceDirectly(int value)
		{
			SplitterDistance = value;
		}

		private void ApplySplitterDistance()
		{
			SplitterDistance = SplitterDistanceInternal;
			if (BackColor == Color.Transparent)
			{
				Invalidate();
			}
			Rectangle splitterRectangleInternal = SplitterRectangleInternal;
			if (Orientation == Orientation.Vertical)
			{
				if (RightToLeft == RightToLeft.No)
				{
					splitterRectangleInternal.X = base.Location.X + SplitterDistanceInternal;
				}
				else
				{
					splitterRectangleInternal.X = base.LayoutRight - SplitterDistanceInternal - SplitterWidthInternal;
				}
			}
			else
			{
				splitterRectangleInternal.Y = base.Location.Y + SplitterDistanceInternal;
			}
			SplitterRectangleInternal = splitterRectangleInternal;
		}

		private Rectangle CalcSplitLine(int intSplitSize, int intMinWeight)
		{
			Rectangle result = default(Rectangle);
			switch (Orientation)
			{
			case Orientation.Horizontal:
				result.Width = base.Width;
				result.Height = SplitterWidthInternal;
				if (result.Width < intMinWeight)
				{
					result.Width = intMinWeight;
				}
				result.Y = Panel1.Location.Y + intSplitSize;
				return result;
			case Orientation.Vertical:
				result.Width = SplitterWidthInternal;
				result.Height = base.Height;
				if (result.Width < intMinWeight)
				{
					result.Width = intMinWeight;
				}
				if (RightToLeft == RightToLeft.No)
				{
					result.X = Panel1.Location.X + intSplitSize;
					return result;
				}
				result.X = base.Width - intSplitSize - SplitterWidthInternal;
				return result;
			default:
				return result;
			}
		}

		private void CollapsePanel(SplitterPanel objSplitterPanel, bool blnCollapsing)
		{
			objSplitterPanel.Collapsed = blnCollapsing;
			if (blnCollapsing)
			{
				objSplitterPanel.Visible = false;
			}
			else
			{
				objSplitterPanel.Visible = true;
			}
			ContainerSplitterPrivate.Visible = !blnCollapsing;
			UpdateSplitter();
		}

		private void DrawSplitBar(int intMode)
		{
			if (intMode != 1 && LastDrawSplit != -1)
			{
				DrawSplitHelper(LastDrawSplit);
				LastDrawSplit = -1;
			}
			else if (intMode != 1 && LastDrawSplit == -1)
			{
				return;
			}
			if (intMode != 3)
			{
				int splitterDistanceInternal = SplitterDistanceInternal;
				if (SplitterMove || SplitterBegin)
				{
					DrawSplitHelper(splitterDistanceInternal);
					LastDrawSplit = splitterDistanceInternal;
				}
				else
				{
					DrawSplitHelper(splitterDistanceInternal);
					LastDrawSplit = splitterDistanceInternal;
				}
			}
			else
			{
				if (LastDrawSplit != -1)
				{
					DrawSplitHelper(LastDrawSplit);
				}
				LastDrawSplit = -1;
			}
		}

		private void DrawSplitHelper(int intSplitSize)
		{
			Rectangle rectangle = CalcSplitLine(intSplitSize, 3);
			IntPtr handle = base.Handle;
		}

		private int GetSplitterDistance(int intX, int intY)
		{
			int num = ((Orientation != Orientation.Vertical) ? (intY - AnchorPoint.Y) : (intX - AnchorPoint.X));
			int val = 0;
			int borderSize = BorderSize;
			switch (Orientation)
			{
			case Orientation.Horizontal:
				val = Math.Max(Panel1.Height + num, borderSize);
				break;
			case Orientation.Vertical:
				val = ((RightToLeft == RightToLeft.No) ? Math.Max(Panel1.Width + num, borderSize) : Math.Max(Panel1.Width - num, borderSize));
				break;
			}
			if (Orientation == Orientation.Vertical)
			{
				return Math.Max(Math.Min(val, base.Width - Panel2MinSize), Panel1MinSize);
			}
			return Math.Max(Math.Min(val, base.Height - Panel2MinSize), Panel1MinSize);
		}

		private void RepaintSplitterRect()
		{
			if (base.IsHandleCreated)
			{
			}
		}

		private void ResizeSplitContainer()
		{
			if (SplitContainerScaling)
			{
				return;
			}
			SplitterPanel panel = Panel1;
			SplitterPanel panel2 = Panel2;
			panel.SuspendLayout();
			panel2.SuspendLayout();
			if (base.Width == 0)
			{
				panel.Size = new Size(0, panel.Height);
				panel2.Size = new Size(0, panel2.Height);
			}
			else if (base.Height == 0)
			{
				panel.Size = new Size(panel.Width, 0);
				panel2.Size = new Size(panel2.Width, 0);
			}
			else
			{
				if (Orientation == Orientation.Vertical)
				{
					if (!CollapsedMode)
					{
						if (FixedPanel == FixedPanel.Panel1)
						{
							int panelSize = PanelSize;
							panel.Size = new Size(panelSize, base.Height);
							panel2.Size = new Size(Math.Max(base.Width - panelSize - SplitterWidthInternal, Panel2MinSize), base.Height);
						}
						if (FixedPanel == FixedPanel.Panel2)
						{
							int panelSize2 = PanelSize;
							panel2.Size = new Size(panelSize2, base.Height);
							int widthInternal = (SplitterDistanceInternal = Math.Max(base.Width - panelSize2 - SplitterWidthInternal, Panel1MinSize));
							panel.WidthInternal = widthInternal;
							panel.HeightInternal = base.Height;
						}
						if (FixedPanel == FixedPanel.None)
						{
							double ratioWidth = RatioWidth;
							if (ratioWidth != 0.0)
							{
								SplitterDistanceInternal = Math.Max((int)Math.Floor((double)base.Width / ratioWidth), Panel1MinSize);
							}
							int num2 = (panel.WidthInternal = SplitterDistanceInternal);
							panel.HeightInternal = base.Height;
							panel2.Size = new Size(Math.Max(base.Width - num2 - SplitterWidthInternal, Panel2MinSize), base.Height);
						}
						if (RightToLeft == RightToLeft.No)
						{
							panel2.Location = new Point(panel.WidthInternal + SplitterWidthInternal, 0);
						}
						else
						{
							panel.Location = new Point(base.Width - panel.WidthInternal, 0);
						}
						RepaintSplitterRect();
						SetSplitterRect(blnVertical: true);
					}
					else if (Panel1Collapsed)
					{
						panel2.Size = base.Size;
						panel2.Location = new Point(0, 0);
					}
					else if (Panel2Collapsed)
					{
						panel.Size = base.Size;
						panel.Location = new Point(0, 0);
					}
				}
				else if (Orientation == Orientation.Horizontal)
				{
					if (!CollapsedMode)
					{
						if (FixedPanel == FixedPanel.Panel1)
						{
							int panelSize3 = PanelSize;
							panel.Size = new Size(base.Width, panelSize3);
							int num3 = panelSize3 + SplitterWidthInternal;
							panel2.Size = new Size(base.Width, Math.Max(base.Height - num3, Panel2MinSize));
							panel2.Location = new Point(0, num3);
						}
						if (FixedPanel == FixedPanel.Panel2)
						{
							panel2.Size = new Size(base.Width, PanelSize);
							int num4 = (panel.HeightInternal = (SplitterDistanceInternal = Math.Max(base.Height - Panel2.Height - SplitterWidthInternal, Panel1MinSize)));
							panel.WidthInternal = base.Width;
							int y = num4 + SplitterWidthInternal;
							panel2.Location = new Point(0, y);
						}
						if (FixedPanel == FixedPanel.None)
						{
							double ratioHeight = RatioHeight;
							if (ratioHeight != 0.0)
							{
								SplitterDistanceInternal = Math.Max((int)Math.Floor((double)base.Height / ratioHeight), Panel1MinSize);
							}
							int num7 = (panel.HeightInternal = SplitterDistanceInternal);
							panel.WidthInternal = base.Width;
							int num8 = num7 + SplitterWidthInternal;
							panel2.Size = new Size(base.Width, Math.Max(base.Height - num8, Panel2MinSize));
							panel2.Location = new Point(0, num8);
						}
						RepaintSplitterRect();
						SetSplitterRect(blnVertical: false);
					}
					else if (Panel1Collapsed)
					{
						panel2.Size = base.Size;
						panel2.Location = new Point(0, 0);
					}
					else if (Panel2Collapsed)
					{
						panel.Size = base.Size;
						panel.Location = new Point(0, 0);
					}
				}
				try
				{
					ResizeCalled = true;
					ApplySplitterDistance();
				}
				finally
				{
					ResizeCalled = false;
				}
			}
			panel.ResumeLayout();
			panel2.ResumeLayout();
		}

		private void SetInnerMostBorder(SplitContainer sc)
		{
			foreach (Control control3 in sc.Controls)
			{
				bool flag = false;
				if (!(control3 is SplitterPanel))
				{
					continue;
				}
				foreach (Control control4 in control3.Controls)
				{
					if (control4 is SplitContainer { Dock: DockStyle.Fill } splitContainer)
					{
						if (splitContainer.BorderStyle != BorderStyle)
						{
							break;
						}
						((SplitterPanel)control3).BorderStyle = BorderStyle.None;
						SetInnerMostBorder(splitContainer);
						flag = true;
					}
				}
				if (!flag)
				{
					((SplitterPanel)control3).BorderStyle = BorderStyle;
				}
			}
		}

		private void SetSplitterRect(bool blnVertical)
		{
			Rectangle splitterRectangleInternal = SplitterRectangleInternal;
			if (blnVertical)
			{
				int splitterDistanceInternal = SplitterDistanceInternal;
				splitterRectangleInternal.X = ((RightToLeft == RightToLeft.Yes) ? (base.Width - splitterDistanceInternal - SplitterWidthInternal) : (base.Location.X + splitterDistanceInternal));
				splitterRectangleInternal.Y = base.Location.Y;
				splitterRectangleInternal.Width = SplitterWidthInternal;
				splitterRectangleInternal.Height = base.Height;
			}
			else
			{
				splitterRectangleInternal.X = base.Location.X;
				splitterRectangleInternal.Y = base.Location.Y + SplitterDistanceInternal;
				splitterRectangleInternal.Width = base.Width;
				splitterRectangleInternal.Height = SplitterWidthInternal;
			}
			SplitterRectangleInternal = splitterRectangleInternal;
		}

		private void SplitBegin(int intX, int intY)
		{
			AnchorPoint = new Point(intX, intY);
			int initialSplitterDistance = (SplitterDistanceInternal = GetSplitterDistance(intX, intY));
			InitialSplitterDistance = initialSplitterDistance;
			InitialSplitterRectangle = SplitterRectangle;
			DrawSplitBar(1);
		}

		private void SplitEnd(bool blnAccept)
		{
			DrawSplitBar(3);
			int initialSplitterDistance = InitialSplitterDistance;
			if (blnAccept)
			{
				ApplySplitterDistance();
			}
			else if (SplitterDistanceInternal != initialSplitterDistance)
			{
				SplitterClick = false;
				SplitterDistance = initialSplitterDistance;
			}
			AnchorPoint = Point.Empty;
		}

		private void SplitMove(int intX, int intY)
		{
			int splitterDistance = GetSplitterDistance(intX, intY);
			int num = splitterDistance - InitialSplitterDistance;
			int num2 = num % SplitterIncrement;
			if (SplitterDistanceInternal != splitterDistance)
			{
				int borderSize = BorderSize;
				if (Orientation == Orientation.Vertical)
				{
					if (splitterDistance + SplitterWidthInternal <= base.Width - Panel2MinSize - borderSize)
					{
						SplitterDistanceInternal = splitterDistance - num2;
					}
				}
				else if (splitterDistance + SplitterWidthInternal <= base.Height - Panel2MinSize - borderSize)
				{
					SplitterDistanceInternal = splitterDistance - num2;
				}
			}
			DrawSplitBar(2);
		}

		private void UpdateSplitter()
		{
			if (SplitContainerScaling)
			{
				return;
			}
			SplitterPanel panel = Panel1;
			SplitterPanel panel2 = Panel2;
			if (Orientation == Orientation.Vertical)
			{
				bool flag = RightToLeft == RightToLeft.Yes;
				if (!CollapsedMode)
				{
					int splitterDistanceInternal = SplitterDistanceInternal;
					panel.HeightInternal = base.Height;
					panel.WidthInternal = splitterDistanceInternal;
					panel2.Size = new Size(base.Width - splitterDistanceInternal - SplitterWidthInternal, base.Height);
					if (!flag)
					{
						panel.Location = new Point(0, 0);
						panel2.Location = new Point(splitterDistanceInternal + SplitterWidthInternal, 0);
					}
					else
					{
						panel.Location = new Point(base.Width - splitterDistanceInternal, 0);
						panel2.Location = new Point(0, 0);
					}
					RepaintSplitterRect();
					SetSplitterRect(blnVertical: true);
					if (!ResizeCalled)
					{
						RatioWidth = (((double)base.Width / (double)panel.Width > 0.0) ? ((double)base.Width / (double)panel.Width) : RatioWidth);
					}
				}
				else
				{
					if (Panel1Collapsed)
					{
						panel2.Size = base.Size;
						panel2.Location = new Point(0, 0);
					}
					else if (Panel2Collapsed)
					{
						panel.Size = base.Size;
						panel.Location = new Point(0, 0);
					}
					if (!ResizeCalled)
					{
						int splitterDistanceInternal2 = SplitterDistanceInternal;
						RatioWidth = (((double)base.Width / (double)splitterDistanceInternal2 > 0.0) ? ((double)base.Width / (double)splitterDistanceInternal2) : RatioWidth);
					}
				}
			}
			else if (!CollapsedMode)
			{
				panel.Location = new Point(0, 0);
				panel.WidthInternal = base.Width;
				int num = (panel.HeightInternal = SplitterDistanceInternal);
				int num2 = num + SplitterWidthInternal;
				panel2.Size = new Size(base.Width, base.Height - num2);
				panel2.Location = new Point(0, num2);
				RepaintSplitterRect();
				SetSplitterRect(blnVertical: false);
				if (!ResizeCalled)
				{
					RatioHeight = (((double)base.Height / (double)panel.Height > 0.0) ? ((double)base.Height / (double)panel.Height) : RatioHeight);
				}
			}
			else
			{
				if (Panel1Collapsed)
				{
					panel2.Size = base.Size;
					panel2.Location = new Point(0, 0);
				}
				else if (Panel2Collapsed)
				{
					panel.Size = base.Size;
					panel.Location = new Point(0, 0);
				}
				if (!ResizeCalled)
				{
					int splitterDistanceInternal4 = SplitterDistanceInternal;
					RatioHeight = (((double)base.Height / (double)splitterDistanceInternal4 > 0.0) ? ((double)base.Height / (double)splitterDistanceInternal4) : RatioHeight);
				}
			}
			if (ContainerSplitterPrivate == null)
			{
				ContainerSplitterPrivate = new ContainerSplitter(this);
			}
			if (Orientation == Orientation.Vertical)
			{
				ContainerSplitterPrivate.Width = SplitterWidth;
			}
			else
			{
				ContainerSplitterPrivate.Height = SplitterWidth;
			}
		}

		internal new void AfterControlRemoved(Control objControl, Control objOldParent)
		{
			if (objControl is SplitContainer && objControl.Dock == DockStyle.Fill)
			{
				SetInnerMostBorder(this);
			}
		}
	}
}
