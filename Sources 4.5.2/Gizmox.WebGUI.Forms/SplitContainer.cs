#region Using

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security.Permissions;
using System.Drawing;
using System.Globalization;
using System.Drawing.Drawing2D;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    [Serializable()]
    /// <summary>
    /// 
    /// </summary>
    public enum FixedPanel
    {
        /// <summary>
        /// Specifies that neither SplitContainer.Panel1, SplitContainer.Panel2 is fixed. A Control.Resize event affects both panels.
        /// </summary>
        None,
        /// <summary>
        /// Specifies that SplitContainer.Panel1 is fixed. A Control.Resize event affects only SplitContainer.Panel2.
        /// </summary>
        Panel1,
        /// <summary>
        /// Specifies that SplitContainer.Panel2 is fixed. A Control.Resize event affects only SplitContainer.Panel1.
        /// </summary>
        Panel2
    }

    #endregion

    #region Delegates

    /// <summary>
    /// Represents the method that will handle the SplitterMoving and SplitterMoved events of a Splitter.
    /// </summary>
    public delegate void SplitterEventHandler(object sender, SplitterEventArgs e);

    /// <summary>
    /// Represents the method that will handle the SplitterMoving event of a Splitter.
    /// </summary>
    public delegate void SplitterCancelEventHandler(object sender, SplitterCancelEventArgs e);


    #endregion

    #region SplitContainer Class

    /// <summary>
    /// Represents a control consisting of a movable bar that divides a container's display area into two resizable panels.
    /// </summary>
    /// <remarks>
    /// You can add controls to the two resizable panels, and you can add other SplitContainer controls to existing SplitContainer panels to create many resizable display areas.
    /// Use the SplitContainer control to divide the display area of a container (such as a Form) and allow the user to resize controls that are added to the SplitContainer panels. When the user passes the mouse pointer over the splitter, the cursor changes to indicate that the controls inside the SplitContainer control can be resized.
    /// </remarks>
    [System.ComponentModel.ToolboxItem(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch), DefaultEvent("SplitterMoved"), SRDescription("DescriptionSplitContainer"), ComVisible(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(SplitContainer), "SplitContainer_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(SplitContainer), "SplitContainer.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    [ToolboxItemCategory("Containers")]
    [MetadataTag(WGTags.Panel), Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.SplitContainerSkin))]
    public class SplitContainer : ContainerControl
    {
        #region Class Members

        #region Serializable Properties / events

        /// <summary>
        /// Provides a property reference to TabStop property.
        /// </summary>
        private static SerializableProperty TabStopProperty = SerializableProperty.Register("TabStop", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to BorderStyle property.
        /// Default defined in the skin.
        /// </summary>
        private static SerializableProperty BorderStyleProperty = SerializableProperty.Register("BorderStyle", typeof(BorderStyle), typeof(SplitContainer));

        /// <summary>
        /// Provides a property reference to AnchorPoint property.
        /// </summary>
        private static SerializableProperty AnchorPointProperty = SerializableProperty.Register("AnchorPoint", typeof(Point), typeof(SplitContainer), new SerializablePropertyMetadata(Point.Empty));

        /// <summary>
        /// Provides a property reference to BorderSize property.
        /// </summary>
        private static SerializableProperty BorderSizeProperty = SerializableProperty.Register("BorderSize", typeof(Int32), typeof(SplitContainer), new SerializablePropertyMetadata(0));

        private static readonly SerializableProperty SplitterDragProperty = SerializableProperty.Register("SplitterDrag", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));
        private static readonly SerializableProperty SplitterFocusedProperty = SerializableProperty.Register("SplitterFocused", typeof(bool), typeof(SplitContainer), new SerializablePropertyMetadata(false));
        private static readonly SerializableProperty SplitterWidthProperty = SerializableProperty.Register("SplitterWidth", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(4));
        private static readonly SerializableProperty Panel2MinSizeProperty = SerializableProperty.Register("Panel2MinSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(0x19));
        private static readonly SerializableProperty Panel1MinSizeProperty = SerializableProperty.Register("Panel1MinSize", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(0x19));
        private static readonly SerializableProperty Panel1Property = SerializableProperty.Register("Panel1", typeof(SplitterPanel), typeof(SplitContainer), new SerializablePropertyMetadata(null));
        private static readonly SerializableProperty Panel2Property = SerializableProperty.Register("Panel2", typeof(SplitterPanel), typeof(SplitContainer), new SerializablePropertyMetadata(null));
        private static readonly SerializableProperty SplitterIncrementProperty = SerializableProperty.Register("SplitterIncrement", typeof(int), typeof(SplitContainer), new SerializablePropertyMetadata(1));
        private static readonly SerializableProperty SplitterRectangleInternalProperty = SerializableProperty.Register("SplitterRectangleInternal", typeof(Rectangle), typeof(SplitContainer), new SerializablePropertyMetadata(Rectangle.Empty));
        private static readonly SerializableProperty InitialSplitterRectangleProperty = SerializableProperty.Register("InitialSplitterRectangle", typeof(Rectangle), typeof(SplitContainer), new SerializablePropertyMetadata(new Rectangle()));
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

        #endregion

        private const int DRAW_END = 3;
        private const int DRAW_MOVE = 2;
        private const int DRAW_START = 1;
        private const int mcntRightBorder = 5;
        private const int mcntLeftBorder = 2;

        /// <summary>
        /// Occurs when [auto size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AutoSizeChanged;

        /// <summary>
        /// Occurs when the value of the BackgroundImage property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        new public event EventHandler BackgroundImageChanged;

        /// <summary>
        /// Occurs when the BackgroundImageLayout property changes.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public event EventHandler BackgroundImageLayoutChanged;

        /// <summary>
        /// Occurs when a new control is added to the ControlCollection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        new public event ControlEventHandler ControlAdded;

        /// <summary>
        /// Occurs when a control is removed from the ControlCollection.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public event ControlEventHandler ControlRemoved;

        /// <summary>
        /// Occurs when the PaddingChanged property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        new public event EventHandler PaddingChanged;

        /// <summary>
        /// Occurs when [splitter moved].
        /// </summary>
        [SRDescription("SplitterSplitterMovedDescr"), SRCategory("CatBehavior")]
        public event SplitterEventHandler SplitterMoved;

        /// <summary>
        /// Occurs when [splitter moving].
        /// </summary>
        [SRDescription("SplitterSplitterMovingDescr"), SRCategory("CatBehavior")]
        public event SplitterCancelEventHandler SplitterMoving;

        /// <summary>
        /// Occurs when the Text property value changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        new public event EventHandler TextChanged;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitContainer"/> class.
        /// </summary>
        public SplitContainer()
        {

            this.Orientation = Orientation.Vertical;
            this.Panel1MinSize = 0x19;
            this.Panel2MinSize = 0x19;
            this.TabStop = true;
            this.SplitterIncrement = 1;
            this.SplitterDistanceInternal = 50;
            this.SplitterWidth = 4;
            this.SetSplitterDistanceDirectly(50);
            this.LastDrawSplit = 1;
            this.AnchorPoint = Point.Empty;
            this.Panel1 = new SplitterPanel(this);
            this.Panel1.TabIndex = 0;
            this.ContainerSplitterPrivate = new ContainerSplitter(this);
            this.ContainerSplitterPrivate.TabIndex = 1;
            this.Panel2 = new SplitterPanel(this);
            this.Panel2.TabIndex = 2;
            this.SplitterRectangleInternal = new Rectangle();
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            ((ClientUtils.TypedControlCollection)this.Controls).AddInternal(this.Panel2);
            ((ClientUtils.TypedControlCollection)this.Controls).AddInternal(this.ContainerSplitterPrivate);
            ((ClientUtils.TypedControlCollection)this.Controls).AddInternal(this.Panel1);

            this.UpdateSplitter();
        }

        /// <summary>
        /// Renders the panel type attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render panel type
            objWriter.WriteAttributeString(WGAttributes.Type, "Normal");
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Border size of the SplitContainer as int.
        /// Used to calculate movement and distances.
        /// </summary>
        private int BorderSize
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.BorderSizeProperty);
            }
            set
            {
                this.SetValue<int>(SplitContainer.BorderSizeProperty, value);
            }
        }

        /// <summary>
        /// A boolean indicating whether in this instance the splitter has focus.
        /// Used to calculate movement and distances.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if in this instance the splitter is focused. otherwise, <c>false</c>.
        /// </value>
        private bool SplitterFocused
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitterFocusedProperty);
            }
            set
            {
                // If value different from current value
                if (this.SplitterFocused != value)
                {
                    this.SetValue<bool>(SplitContainer.SplitterFocusedProperty, value);
                }

            }
        }

        /// <summary>
        /// A boolean indicating whether this instance the splitter is dragged.
        /// Used in splitter movement.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance the splitter is dragged. otherwise, <c>false</c>.
        /// </value>
        private bool SplitterDrag
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitterDragProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitterDragProperty, value);
            }
        }
        /// <summary>
        /// Get/Set Boolean indicating whether safe to set the SplitterDistance.
        /// </summary>
        /// <value><c>true</c> if safe to set the SplitterDistance, <c>false</c> otherwise.</value>
        private bool SetSplitterDistance
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SetSplitterDistanceProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SetSplitterDistanceProperty, value);
            }
        }

        /// <summary>
        /// Get/Set An integer indicating the perpendicular length of the fixed panel 
        /// to the splitter. If Fixed. None, the value is the length of the bottom/right panel.
        /// </summary>
        private int PanelSize
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<int>(SplitContainer.PanelSizeProperty);
            }
            set
            {
                this.SetValue<int>(SplitContainer.PanelSizeProperty, value);
            }
        }

        /// <summary>
        /// Get/Set The next active Control.
        /// </summary>
        private Control NextActiveControl
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<Control>(SplitContainer.NextActiveControlProperty);
            }
            set
            {
                this.SetValue<Control>(SplitContainer.NextActiveControlProperty, value);
            }
        }

        /// <summary>
        /// A double value used to hold the ratio between the height of the base conrol and 
        /// another, e.g. splitter width, panel1 width etc.
        /// </summary>
        private double RatioHeight
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<double>(SplitContainer.RatioHeightProperty);
            }
            set
            {
                this.SetValue<double>(SplitContainer.RatioHeightProperty, value);
            }
        }

        /// <summary>
        /// A double value used to hold the ratio between the width of the base conrol and 
        /// another, e.g. splitter width, panel1 width etc.
        /// </summary>
        private double RatioWidth
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<double>(SplitContainer.RatioWidthProperty);
            }
            set
            {
                this.SetValue<double>(SplitContainer.RatioWidthProperty, value);
            }
        }

        /// <summary>
        /// Boolean indicating whether to begin actions on the splitter.
        /// </summary>
        /// <value><c>true</c> if to begin actions on the splitter, <c>false</c> otherwise.</value>
        private bool SplitterBegin
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitterBeginProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitterBeginProperty, value);
            }
        }

        /// <summary>
        /// Get\Set a boolean indicating whether resize on the control was called.
        /// Used to indicate for example whether to update the ratio width/height.
        /// </summary>
        /// <value><c>true</c> if resize on the control was called, <c>false</c> otherwise.</value>
        private bool ResizeCalled
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.ResizeCalledProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.ResizeCalledProperty, value);
            }
        }

        /// <summary>
        /// Boolean indicating whether to break actions on the splitter.
        /// </summary>
        /// <value><c>true</c> if to break actions on the splitter, <c>false</c> otherwise.</value>
        private bool SplitBreak
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitBreakProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitBreakProperty, value);
            }
        }

        /// <summary>
        /// Boolean indicating whether the splitContainer is in scaling process.
        /// </summary>
        /// <value><c>true</c> if the splitter is in scaling process, <c>false</c> otherwise.</value>
        private bool SplitContainerScaling
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitContainerScalingProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitContainerScalingProperty, value);
            }
        }

        /// <summary>
        /// Boolean indicating whether the splitter is in movement.
        /// </summary>
        /// <value><c>true</c> if the splitter is in movement, <c>false</c> otherwise.</value>
        private bool SplitterMove
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitterMoveProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitterMoveProperty, value);
            }
        }

        /// <summary>
        /// Boolean indicating whether the splitter is clicked.
        /// </summary>
        /// <value><c>true</c> if the splitter is clicked, <c>false</c> otherwise.</value>
        private bool SplitterClick
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<bool>(SplitContainer.SplitterClickProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.SplitterClickProperty, value);
            }
        }

        /// <summary>
        /// The Anchor of the SplitContainer as Point object
        /// </summary>
        private Point AnchorPoint
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<Point>(SplitContainer.AnchorPointProperty);
            }
            set
            {
                this.SetValue<Point>(SplitContainer.AnchorPointProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether to reverse control rendering.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
        /// </value>
        protected override bool ReverseControls
        {
            get
            {
                // In case of a fixed panel2 reverese controls rendering in order to force panel2 to be rendered before the splitter.
                return (this.FixedPanel == FixedPanel.Panel2);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value>
        /// true if the container enables auto-scrolling; otherwise, false. The default value is false.
        /// </value>
        [SRDescription("FormAutoScrollDescr"), EditorBrowsable(EditorBrowsableState.Never), Localizable(true), DefaultValue(false), SRCategory("CatLayout"), Browsable(false)]
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

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), ProxyBrowsable(true)]
        new public ResourceHandle BackgroundImage
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

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
        /// </summary>
        /// <value></value>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>
        /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
        [SRDescription("ContainerControlBindingContextDescr"), Browsable(false)]
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

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance"), DefaultValue(0), DispId(-504), SRDescription("SplitterBorderStyleDescr")]
        public new BorderStyle BorderStyle
        {
            get
            {
                return this.GetValue<BorderStyle>(SplitContainer.BorderStyleProperty, this.Skin.BorderStyle);
            }
            set
            {
                //Here we deviate from winforms as our enum is larger.
                //This condition replaces ClientUtils.IsEnumValid
                if (!Enum.IsDefined(typeof(BorderStyle), value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));
                }

                // Get the default BorderStyle from the skin
                BorderStyle enmBorderStyle = this.Skin.BorderStyle;

                // If value different from current value
                if (this.SetValue<BorderStyle>(SplitContainer.BorderStyleProperty, value, enmBorderStyle))
                {
                    // If value is not default (the style of the skin), set it in Serializable Property
                    if (enmBorderStyle != value)
                    {
                        base.Invalidate();
                        this.SetInnerMostBorder(this);

                        // Get the parent as a SplitterPanel
                        Control objParent = this.ParentInternal as SplitterPanel;

                        // If parent exists and is a SplitterPanel
                        if (objParent != null)
                        {
                            SplitContainer objOwner = ((SplitterPanel)objParent).Owner;
                            objOwner.SetInnerMostBorder(objOwner);
                        }
                    }
                }

                switch (value)
                {
                    case BorderStyle.None:
                        this.BorderSize = 0;
                        return;

                    case BorderStyle.FixedSingle:
                        this.BorderSize = 1;
                        return;

                    case BorderStyle.Fixed3D:
                        this.BorderSize = 4;
                        return;
                }
            }
        }

        private bool CollapsedMode
        {
            get
            {
                if (!this.Panel1Collapsed)
                {
                    return this.Panel2Collapsed;
                }
                return true;
            }
        }

        /// <summary>
        /// Gets the collection of controls contained within the control.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        new public Control.ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(150, 100);
            }
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        /// <value></value>
        new public DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
                if ((this.ParentInternal != null) && (this.ParentInternal is SplitterPanel))
                {
                    SplitContainer objOwner = ((SplitterPanel)this.ParentInternal).Owner;
                    objOwner.SetInnerMostBorder(objOwner);
                }
                this.ResizeSplitContainer();
            }
        }

        /// <summary>
        /// Gets or sets the initial size and location of the splitter relative to the SplitContainer.
        /// Used as preliminary in calculations of drawing the splitter.
        /// The default value is .net Deafult of type Rectangle.
        /// </summary>
        /// <value>Rectangle, The default value is .net Deafult of type Rectangle.</value>
        [SRCategory("CatLayout"), SRDescription("SplitContainerFixedPanelDescr"), DefaultValue(0)]
        private Rectangle InitialSplitterRectangle
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<Rectangle>(SplitContainer.InitialSplitterRectangleProperty);
            }
            set
            {
                this.SetValue<Rectangle>(SplitContainer.InitialSplitterRectangleProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the initial location of the splitter, in pixels, from the left or top 
        /// edge of the SplitContainer.
        /// Used as preliminary in calculations of drawing the splitter.
        /// The default value is 0.
        /// </summary>
        /// <value>Integer, The default value is 0.</value>
        [SRCategory("CatLayout"), SRDescription("SplitContainerFixedPanelDescr"), DefaultValue(0)]
        private int InitialSplitterDistance
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.InitialSplitterDistanceProperty);
            }
            set
            {
                this.SetValue<int>(SplitContainer.InitialSplitterDistanceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets which SplitContainer panel remains the same size when the container 
        /// is resized. 
        /// The value is one of the values of FixedPanel enum. 
        /// </summary>
        /// <value>One of the values of FixedPanel enum. The default value is None. </value>
        [SRCategory("CatLayout"), SRDescription("SplitContainerFixedPanelDescr"), DefaultValue(0)]
        public FixedPanel FixedPanel
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<FixedPanel>(SplitContainer.FixedPanelProperty);
            }
            set
            {
                //check InvalidEnumArgumentException - values should be between 0-2
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(FixedPanel));
                }

                // If value different from current value
                if (this.SetValue<FixedPanel>(SplitContainer.FixedPanelProperty, value))
                {
                    // If the fixed panel in Panel2
                    if (value == FixedPanel.Panel2)
                    {
                        if (this.Orientation == Orientation.Vertical)
                        {
                            this.PanelSize = (base.Width - this.SplitterDistanceInternal) - this.SplitterWidthInternal;
                        }
                        else
                        {
                            this.PanelSize = (base.Height - this.SplitterDistanceInternal) - this.SplitterWidthInternal;
                        }
                    }
                    else
                    {
                        this.PanelSize = this.SplitterDistanceInternal;
                    }

                    // UPdate the control
                    this.Update();

                    // Fire the event
                    FireObservableItemPropertyChanged("FixedPanel");

                }
            }
        }

        internal override bool IsContainerControl
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the critical events internal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is splitter moved registered; otherwise, <c>false</c>.
        /// </value>
        /// <returns></returns>
        internal bool IsSplitterMovedRegistered
        {
            get
            {
                return (this.SplitterMoved != null);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is splitter fixed. otherwise, <c>false</c>.
        /// </value>
        [SRCategory("CatLayout"), SRDescription("SplitContainerIsSplitterFixedDescr"), DefaultValue(false), Localizable(true)]
        public bool IsSplitterFixed
        {
            get
            {
                ContainerSplitter objContainerSplitter = this.ContainerSplitterPrivate;
                if (objContainerSplitter != null)
                {
                    // Get the value From Serializable Property
                    return objContainerSplitter.IsSplitterFixed;
                }

                return false;
            }
            set
            {
                ContainerSplitter objContainerSplitter = this.ContainerSplitterPrivate;
                if (objContainerSplitter != null)
                {
                    // If value different from current value 
                    objContainerSplitter.IsSplitterFixed = value;
                }
            }
        }

        private bool IsSplitterMovable
        {
            get
            {
                if (this.Orientation == Orientation.Vertical)
                {
                    return (base.Width >= ((this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize));
                }
                return (base.Height >= ((this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize));
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [SRCategory("CatBehavior"), SRDescription("SplitContainerOrientationDescr"), DefaultValue(1), Localizable(true)]
        public Orientation Orientation
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<Orientation>(SplitContainer.OrientationProperty);
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(Orientation));
                }

                // If value different from current value
                if (this.SetValue<Orientation>(SplitContainer.OrientationProperty, value))
                {
                    this.SetSplitterDistanceDirectly(0);
                    this.SplitterDistance = this.SplitterDistanceInternal;
                    this.UpdateSplitter();

                    FireObservableItemPropertyChanged("Orientation");

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Get/Set a private instance of ContainerSplitter
        /// </summary>
        private ContainerSplitter ContainerSplitterPrivate
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<ContainerSplitter>(SplitContainer.ContainerSplitterPrivateProperty);
            }
            set
            {
                this.SetValue<ContainerSplitter>(SplitContainer.ContainerSplitterPrivateProperty, value);
            }
        }
        /// <summary>
        /// Get/Set an integer holding the length of the splitBar (on move).
        /// </summary>
        private int LastDrawSplit
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.LastDrawSplitProperty);
            }
            set
            {
                this.SetValue<int>(SplitContainer.LastDrawSplitProperty, value);
            }
        }

        /// <summary>
        /// Get/Set the cursur when set over the splitter (vertical/horizontal).
        /// </summary>
        private Cursor OverrideCursor
        {
            get
            {
                // Get the value From Serializable Property 
                return this.GetValue<Cursor>(SplitContainer.OverrideCursorProperty);
            }
            set
            {
                this.SetValue<Cursor>(SplitContainer.OverrideCursorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        new public Padding Padding
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

        /// <summary>
        /// Gets the left or top panel of the SplitContainer, depending on Orientation. 
        /// </summary>
        /// <value>The left or top panel of the SplitContainer, depending on Orientation, as SplitterPanel. </value>
        [SRCategory("CatAppearance"), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("SplitContainerPanel1Descr")]
        public SplitterPanel Panel1
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<SplitterPanel>(SplitContainer.Panel1Property);
            }
            private set
            {
                this.SetValue<SplitterPanel>(SplitContainer.Panel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [panel1 collapsed].
        /// </summary>
        /// <value><c>true</c> if [panel1 collapsed]; otherwise, <c>false</c>.</value>
        [SRDescription("SplitContainerPanel1CollapsedDescr"), SRCategory("CatLayout"), DefaultValue(false)]
        public bool Panel1Collapsed
        {
            get
            {
                return this.Panel1.Collapsed;
            }
            set
            {
                //Assignment in order to save trips to Serializable Property.
                SplitterPanel objPanel1 = this.Panel1;
                //SplitterPanel objPanel2 = this.Panel2;
                if (value != objPanel1.Collapsed)
                {
                    if (value && this.Panel2.Collapsed)
                    {
                        this.CollapsePanel(this.Panel2, false);
                    }
                    this.CollapsePanel(objPanel1, value);

                    FireObservableItemPropertyChanged("Panel1Collapsed");
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum distance in pixels of the splitter from the left or top 
        /// edge of Panel1. 
        /// </summary>
        /// <value>The minimum distance in pixels of the splitter from the left or top edge of 
        /// Panel1.</value>
        [Localizable(true), SRCategory("CatLayout"), DefaultValue(0x19), RefreshProperties(RefreshProperties.All), SRDescription("SplitContainerPanel1MinSizeDescr")]
        public int Panel1MinSize
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.Panel1MinSizeProperty);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidLowBoundArgument", new object[] { "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture), "0" }));
                }
                if (this.Orientation == Orientation.Vertical)
                {
                    if ((base.DesignMode && (base.Width != this.DefaultSize.Width)) && (((value + this.Panel2MinSize) + this.SplitterWidth) > base.Width))
                    {
                        throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidArgument", new object[] { "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture) }));
                    }
                }
                else if (((this.Orientation == Orientation.Horizontal) && base.DesignMode) && ((base.Height != this.DefaultSize.Height) && (((value + this.Panel2MinSize) + this.SplitterWidth) > base.Height)))
                {
                    throw new ArgumentOutOfRangeException("Panel1MinSize", SR.GetString("InvalidArgument", new object[] { "Panel1MinSize", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // If value different from current value
                if (this.SetValue<int>(SplitContainer.Panel1MinSizeProperty, value))
                {
                    if (value > this.SplitterDistanceInternal)
                    {
                        this.SplitterDistance = value;

                        FireObservableItemPropertyChanged("Panel1MinSize");
                    }
                }
            }
        }

        /// <summary>
        /// Gets the right or bottom panel of the SplitContainer, depending on Orientation. 
        /// </summary>
        /// <value>Gets the right or bottom panel of the SplitContainer, depending on Orientation. </value>
        [SRCategory("CatAppearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("SplitContainerPanel2Descr"), Localizable(false)]
        public SplitterPanel Panel2
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<SplitterPanel>(SplitContainer.Panel2Property);
            }
            private set
            {
                this.SetValue<SplitterPanel>(SplitContainer.Panel2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [panel2 collapsed].
        /// </summary>
        /// <value><c>true</c> if [panel2 collapsed]; otherwise, <c>false</c>.</value>
        [SRCategory("CatLayout"), SRDescription("SplitContainerPanel2CollapsedDescr"), DefaultValue(false)]
        public bool Panel2Collapsed
        {
            get
            {
                return this.Panel2.Collapsed;
            }
            set
            {
                //Assignment in order to save trips to Serializable Property.
                SplitterPanel objPanel1 = this.Panel1;
                SplitterPanel objPanel2 = this.Panel2;
                if (value != objPanel2.Collapsed)
                {
                    if (value && objPanel1.Collapsed)
                    {
                        this.CollapsePanel(objPanel1, false);
                    }
                    this.CollapsePanel(objPanel2, value);

                    FireObservableItemPropertyChanged("Panel2Collapsed");
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum distance in pixels of the splitter from the right or 
        /// bottom edge of Panel2. 
        /// </summary>
        /// <value>The minimum distance in pixels of the splitter from the right or 
        /// bottom edge of Panel2.</value>
        [SRCategory("CatLayout"), RefreshProperties(RefreshProperties.All), DefaultValue(0x19), Localizable(true), SRDescription("SplitContainerPanel2MinSizeDescr")]
        public int Panel2MinSize
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.Panel2MinSizeProperty);
            }
            set
            {
                // if value is invalid, smaller than 0.
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidLowBoundArgument", new object[] { "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture), "0" }));
                }
                if (this.Orientation == Orientation.Vertical)
                {
                    if ((base.DesignMode && (base.Width != this.DefaultSize.Width)) && (((value + this.Panel1MinSize) + this.SplitterWidth) > base.Width))
                    {
                        throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidArgument", new object[] { "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture) }));
                    }
                }
                else if (((this.Orientation == Orientation.Horizontal) && base.DesignMode) && ((base.Height != this.DefaultSize.Height) && (((value + this.Panel1MinSize) + this.SplitterWidth) > base.Height)))
                {
                    throw new ArgumentOutOfRangeException("Panel2MinSize", SR.GetString("InvalidArgument", new object[] { "Panel2MinSize", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // If value different from current value
                if (this.SetValue<int>(SplitContainer.Panel2MinSizeProperty, value))
                {
                    if (value > this.Panel2.Width)
                    {
                        this.SplitterDistance = this.Panel2.Width + this.SplitterWidthInternal;
                    }

                    FireObservableItemPropertyChanged("Panel2MinSize");
                }
            }
        }

        /// <summary>
        /// Gets or sets the location of the splitter, in pixels, from the left or top edge 
        /// of the SplitContainer. 
        /// </summary>
        /// <value>The splitter distance.</value>
        [DefaultValue(50), SRCategory("CatLayout"), Localizable(true), SRDescription("SplitContainerSplitterDistanceDescr")]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [SettingsBindable(true)]
#endif
        //In order to set a value directly without manipulation - use private
        // method - SetSplitterDistanceDirectly.
        public int SplitterDistance
        {
            get
            {
                return this.GetValue<int>(SplitContainer.SplitterDistanceProperty);
            }
            set
            {
                // If value is different
                if (value != this.SplitterDistance)
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("SplitterDistance", SR.GetString("InvalidLowBoundArgument", new object[] { "SplitterDistance", value.ToString(CultureInfo.CurrentCulture), "0" }));
                    }
                    try
                    {
                        this.SetSplitterDistance = true;
                        if (this.Orientation == Orientation.Vertical)
                        {
                            // If value is smaller from min distance defined of the splitter from the left,
                            // assign the distance to value
                            if (value < this.Panel1MinSize)
                            {
                                value = this.Panel1MinSize;
                            }
                            // If value minus width of splitter (0 if collapsed) is greater than control.Width minus min distance 
                            // defined of the splitter from the right, assign the latter minus splitter width to value.
                            if ((value + this.SplitterWidthInternal) > (base.Width - this.Panel2MinSize))
                            {
                                value = (base.Width - this.Panel2MinSize) - this.SplitterWidthInternal;
                            }
                            //After the above changes check for validity
                            if (value < 0)
                            {
                                throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
                            }

                            this.SetValue<int>(SplitContainer.SplitterDistanceProperty, value);
                            this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);

                            this.Panel1.WidthInternal = value;
                        }
                        //Horizontal
                        else
                        {
                            //value smaller from min distance defined of the splitter from the top,
                            // assign the distance to value
                            if (value < this.Panel1MinSize)
                            {
                                value = this.Panel1MinSize;
                            }
                            // If value plus width of splitter (0 if collapsed) is greater than control.Height minus min 
                            // distance defined of the splitter from the bottom, assign the latter minus splitter width to value.
                            if ((value + this.SplitterWidthInternal) > (base.Height - this.Panel2MinSize))
                            {
                                value = (base.Height - this.Panel2MinSize) - this.SplitterWidthInternal;
                            }
                            //After the above changes check for validity
                            if (value < 0)
                            {
                                throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
                            }

                            this.SetValue<int>(SplitContainer.SplitterDistanceProperty, value);
                            this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);

                            this.Panel1.HeightInternal = value;
                        }
                        switch (this.FixedPanel)
                        {
                            case FixedPanel.Panel1:
                                this.PanelSize = value;
                                goto Label_01A6;

                            case FixedPanel.Panel2:
                                if (this.Orientation != Orientation.Vertical)
                                {
                                    break;
                                }
                                this.PanelSize = (base.Width - value) - this.SplitterWidthInternal;
                                goto Label_01A6;

                            default:
                                goto Label_01A6;
                        }
                        this.PanelSize = (base.Height - value) - this.SplitterWidthInternal;
                    Label_01A6:
                        this.UpdateSplitter();
                    }
                    finally
                    {
                        this.SetSplitterDistance = false;
                    }

                    // Raise the splitter moved event.
                    OnSplitterMovedInternal();

                    this.FireObservableItemPropertyChanged("SplitterDistance");
                }
            }
        }

        /// <summary>
        /// Raise the splitter moved event.
        /// </summary>
        internal void OnSplitterMovedInternal()
        {
            // Get the split container's rectangle.
            Rectangle objSplitterRect = this.SplitterRectangle;
            if (objSplitterRect != null)
            {
                // Raise the splitter moved event.
                this.OnSplitterMoved(new SplitterEventArgs(objSplitterRect.X + (objSplitterRect.Width / 2), objSplitterRect.Y + (objSplitterRect.Height / 2), objSplitterRect.X, objSplitterRect.Y));
            }
        }

        /// <summary>
        /// Gets or sets the location of the splitter, in pixels, from the left or top edge 
        /// of the SplitContainer. For private use. 
        /// </summary>
        /// <value>The splitter distance.</value>
        private int SplitterDistanceInternal
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.SplitterDistanceInternalProperty);
            }
            set
            {
                this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value representing the increment of splitter movement in pixels. 
        /// Used for movement calculations mainly.
        /// </summary>
        /// <value>The splitter increment as int, Default is 1.</value>
        [DefaultValue(1), SRDescription("SplitContainerSplitterIncrementDescr"), SRCategory("CatLayout"), Localizable(true)]
        public int SplitterIncrement
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.SplitterIncrementProperty);
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("SplitterIncrement", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SplitterIncrement", value.ToString(CultureInfo.CurrentCulture), "1" }));
                }

                // If value different from current value
                if (this.SetValue<int>(SplitContainer.SplitterIncrementProperty, value))
                {
                    FireObservableItemPropertyChanged("SplitterIncrement");
                }
            }
        }

        /// <summary>
        /// Gets the size and location of the splitter relative to the SplitContainer. 
        /// </summary>
        /// <value>The splitter rectangle.</value>
        [Browsable(false), SRDescription("SplitContainerSplitterRectangleDescr"), SRCategory("CatLayout")]
        public Rectangle SplitterRectangle
        {
            get
            {
                Rectangle objSplitterRect = this.SplitterRectangleInternal;
                objSplitterRect.X = objSplitterRect.X - base.Left;
                objSplitterRect.Y = objSplitterRect.Y - base.Top;
                return objSplitterRect;
            }

        }

        /// <summary>
        /// Gets or sets the size and location of the splitter relative to the SplitContainer
        /// for internal use. manipulated in the public property for outside use.
        /// Used as preliminary in calculations of drawing the splitter.
        /// The default value is .net Deafult of type Rectangle.
        /// </summary>
        /// <value>Rectangle, The default value is .net Deafult of type Rectangle.</value>
        [Browsable(false), SRDescription("SplitContainerSplitterRectangleDescr"), SRCategory("CatLayout")]
        private Rectangle SplitterRectangleInternal
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<Rectangle>(SplitContainer.SplitterRectangleInternalProperty);
            }
            set
            {
                this.SetValue<Rectangle>(SplitContainer.SplitterRectangleInternalProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the splitter. Default value is 4.
        /// </summary>
        /// <value>The width of the splitter. Default value is 4.</value>
        [SRDescription("SplitContainerSplitterWidthDescr"), Localizable(true), DefaultValue(4), SRCategory("CatLayout")]
        public int SplitterWidth
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<int>(SplitContainer.SplitterWidthProperty);
            }
            set
            {
                //value under width limit (1)
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SplitterWidth", value.ToString(CultureInfo.CurrentCulture), "1" }));
                }

                //value too wide exception
                if (this.Orientation == Orientation.Vertical)
                {
                    if (base.DesignMode && (((value + this.Panel1MinSize) + this.Panel2MinSize) > base.Width))
                    {
                        throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidArgument", new object[] { "SplitterWidth", value.ToString(CultureInfo.CurrentCulture) }));
                    }
                }

                //value too wide exception
                else if (((this.Orientation == Orientation.Horizontal) && base.DesignMode) && (((value + this.Panel1MinSize) + this.Panel2MinSize) > base.Height))
                {
                    throw new ArgumentOutOfRangeException("SplitterWidth", SR.GetString("InvalidArgument", new object[] { "SplitterWidth", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // If value different from current value
                if (this.SetValue<int>(SplitContainer.SplitterWidthProperty, value))
                {
                    this.UpdateSplitter();
                    FireObservableItemPropertyChanged("SplitterWidth");
                }
            }
        }

        private int SplitterWidthInternal
        {
            get
            {
                if (!this.CollapsedMode)
                {
                    return this.SplitterWidth;
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [SRDescription("ControlTabStopDescr"), SRCategory("CatBehavior"), DefaultValue(true), DispId(-516)]
        public new bool TabStop
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<bool>(SplitContainer.TabStopProperty);
            }
            set
            {
                this.SetValue<bool>(SplitContainer.TabStopProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
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

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Raises the <see cref="E:SplitterMoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.SplitterEventArgs"/> instance containing the event data.</param>
        public virtual void OnSplitterMoved(SplitterEventArgs e)
        {
            // Raise event if needed
            SplitterEventHandler objEventHandler = this.SplitterMoved;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:SplitterMoving"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.SplitterCancelEventArgs"/> instance containing the event data.</param>
        public void OnSplitterMoving(SplitterCancelEventArgs e)
        {
            // Raise event if needed
            SplitterCancelEventHandler objEventHandler = (SplitterCancelEventHandler)this.GetHandler(EVENT_MOVING);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the controls instance.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new SplitContainerTypedControlCollection(this, typeof(SplitterPanel), true);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
        [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.IsSplitterMovable && !this.IsSplitterFixed)
            {
                //Assignment in order to save trips to Serializable Property.
                bool blnSplitterFocused = this.SplitterFocused;
                if ((e.KeyData == Keys.Escape) && this.SplitterBegin)
                {
                    this.SplitterBegin = false;
                    this.SplitBreak = true;
                }
                else if (((e.KeyData == Keys.Right) || (e.KeyData == Keys.Down)) || ((e.KeyData == Keys.Left) || ((e.KeyData == Keys.Up) && blnSplitterFocused)))
                {
                    if (this.SplitterBegin)
                    {
                        this.SplitterMove = true;
                    }
                    //Holds the border Size
                    int intBorderSize = this.BorderSize;
                    if ((e.KeyData == Keys.Left) || ((e.KeyData == Keys.Up) && blnSplitterFocused))
                    {
                        //Assignment in order to save trips to Serializable Property.
                        int intSplitterDistance = this.SplitterDistanceInternal;
                        intSplitterDistance -= this.SplitterIncrement;
                        this.SplitterDistanceInternal = (intSplitterDistance < this.Panel1MinSize) ? (intSplitterDistance + this.SplitterIncrement) : Math.Max(intSplitterDistance, intBorderSize);
                    }
                    if ((e.KeyData == Keys.Right) || ((e.KeyData == Keys.Down) && blnSplitterFocused))
                    {
                        //Assignment in order to save trips to Serializable Property.
                        int intSplitterDistance = this.SplitterDistanceInternal;
                        intSplitterDistance += this.SplitterIncrement;
                        if (this.Orientation == Orientation.Vertical)
                        {
                            this.SplitterDistanceInternal = ((intSplitterDistance + this.SplitterWidth) > ((base.Width - this.Panel2MinSize) - intBorderSize)) ? (intSplitterDistance - this.SplitterIncrement) : intSplitterDistance;
                        }
                        else
                        {
                            this.SplitterDistanceInternal = ((intSplitterDistance + this.SplitterWidth) > ((base.Height - this.Panel2MinSize) - intBorderSize)) ? (intSplitterDistance - this.SplitterIncrement) : intSplitterDistance;
                        }
                    }
                    if (!this.SplitterBegin)
                    {
                        this.SplitterBegin = true;
                    }
                    if (this.SplitterBegin && !this.SplitterMove)
                    {
                        this.InitialSplitterDistance = this.SplitterDistanceInternal;
                        this.DrawSplitBar(1);
                    }
                    else
                    {
                        this.DrawSplitBar(2);
                        Rectangle objRectangle = this.CalcSplitLine(this.SplitterDistanceInternal, 0);
                        int intX = objRectangle.X;
                        int intY = objRectangle.Y;
                        //Assignment in order to save trips to Serializable Property.
                        Rectangle objSplitterRect = this.SplitterRectangle;
                        SplitterCancelEventArgs args = new SplitterCancelEventArgs((base.Left + objSplitterRect.X) + (objSplitterRect.Width / 2), (base.Top + objSplitterRect.Y) + (objSplitterRect.Height / 2), intX, intY);
                        this.OnSplitterMoving(args);
                        if (args.Cancel)
                        {
                            this.SplitEnd(false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
        [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if ((this.SplitterBegin && this.IsSplitterMovable) && (((e.KeyData == Keys.Right) || (e.KeyData == Keys.Down)) || ((e.KeyData == Keys.Left) || ((e.KeyData == Keys.Up) && this.SplitterFocused))))
            {
                this.DrawSplitBar(3);
                this.ApplySplitterDistance();
                this.SplitterBegin = false;
                this.SplitterMove = false;
            }
            if (this.SplitBreak)
            {
                this.SplitBreak = false;
                this.SplitEnd(false);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Layout"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            this.SetInnerMostBorder(this);
            if (this.IsSplitterMovable && !this.SetSplitterDistance)
            {
                this.ResizeSplitContainer();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
        /// Implemented by design as Click (Use Click instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (((this.IsSplitterMovable && this.SplitterRectangle.Contains(new Point(e.X, e.Y))) && base.Enabled) && (((e.Button == MouseButtons.Left) && (e.Clicks == 1)) && !this.IsSplitterFixed))
            {
                this.SplitterFocused = true;
                IContainerControl objContainerControlInternal = this.ParentInternal.GetContainerControlInternal();
                if (objContainerControlInternal != null)
                {
                    ContainerControl objControl2 = objContainerControlInternal as ContainerControl;
                    if (objControl2 == null)
                    {
                        objContainerControlInternal.ActiveControl = this;
                    }
                    else
                    {
                        objControl2.SetActiveControlInternal(this);
                    }
                }
                base.SetActiveControlInternal(null);
                this.NextActiveControl = this.Panel2;
                this.SplitBegin(e.X, e.Y);
                this.SplitterClick = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void OnMouseLeave(EventArgs e)
        {
            if (base.Enabled)
            {
                this.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.MouseEventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void OnMouseMove(MouseEventArgs e)
        {
            if (!this.IsSplitterFixed && this.IsSplitterMovable)
            {
                if ((this.Cursor == Cursors.Default) && this.SplitterRectangle.Contains(new Point(e.X, e.Y)))
                {
                    if (this.Orientation == Orientation.Vertical)
                    {
                        this.OverrideCursor = Cursors.VSplit;
                    }
                    else
                    {
                        this.OverrideCursor = Cursors.HSplit;
                    }
                }
                else
                {
                    this.OverrideCursor = null;
                }
                if (this.SplitterClick)
                {
                    int intX = e.X;
                    int intY = e.Y;
                    this.SplitterDrag = true;
                    this.SplitMove(intX, intY);
                    if (this.Orientation == Orientation.Vertical)
                    {
                        intX = Math.Max(Math.Min(intX, base.Width - this.Panel2MinSize), this.Panel1MinSize);
                        intY = Math.Max(intY, 0);
                    }
                    else
                    {
                        intY = Math.Max(Math.Min(intY, base.Height - this.Panel2MinSize), this.Panel1MinSize);
                        intX = Math.Max(intX, 0);
                    }
                    Rectangle objRectangle = this.CalcSplitLine(this.GetSplitterDistance(e.X, e.Y), 0);
                    int intSplitX = objRectangle.X;
                    int intSplitY = objRectangle.Y;
                    SplitterCancelEventArgs args = new SplitterCancelEventArgs(intX, intY, intSplitX, intSplitY);
                    this.OnSplitterMoving(args);
                    if (args.Cancel)
                    {
                        this.SplitEnd(false);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
        /// Implemented by design as Click (Use Click instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (base.Enabled && ((!this.IsSplitterFixed && this.IsSplitterMovable) && this.SplitterClick))
            {
                if (this.SplitterDrag)
                {
                    this.CalcSplitLine(this.GetSplitterDistance(e.X, e.Y), 0);
                    this.SplitEnd(true);
                }
                else
                {
                    this.SplitEnd(false);
                }
                this.SplitterClick = false;
                this.SplitterDrag = false;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:RightToLeftChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void OnRightToLeftChanged(EventArgs e)
        {
            this.Panel1.RightToLeft = this.RightToLeft;
            this.Panel2.RightToLeft = this.RightToLeft;
            this.UpdateSplitter();
        }

        /// <summary>
        /// Scales the control.
        /// </summary>
        /// <param name="objFactor">The factor.</param>
        /// <param name="enmSpecified">The specified.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified)
        {
            try
            {
                float fltWidth;
                this.SplitContainerScaling = true;
                if (this.Orientation == Orientation.Vertical)
                {
                    fltWidth = objFactor.Width;
                }
                else
                {
                    fltWidth = objFactor.Height;
                }
                this.SplitterWidth = (int)Math.Round((double)(this.SplitterWidth * fltWidth));
            }
            finally
            {
                this.SplitContainerScaling = false;
            }
        }

        /// <summary>
        /// Sets the bounds core.
        /// </summary>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="intWidth">The width.</param>
        /// <param name="intHeight">The height.</param>
        /// <param name="enmSpecified">The specified.</param>
        new protected void SetBoundsCore(int intX, int intY, int intWidth, int intHeight, BoundsSpecified enmSpecified)
        {
            if ((((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None) && (this.Orientation == Orientation.Horizontal)) && (intHeight < ((this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize)))
            {
                intHeight = (this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize;
            }
            if ((((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None) && (this.Orientation == Orientation.Vertical)) && (intWidth < ((this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize)))
            {
                intWidth = (this.Panel1MinSize + this.SplitterWidthInternal) + this.Panel2MinSize;
            }
            this.SetSplitterRect(this.Orientation == Orientation.Vertical);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IResponseWriter objWriter, long lngRequestID)
        {
            base.RenderControls(objContext, objWriter, lngRequestID);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// SplitterDistance - The location of the splitter, in pixels, from the left or top edge 
        /// of the SplitContainer. The public setter changes the value, this method changes the value
        /// without manipulation to it.
        /// </summary>
        private void SetSplitterDistanceDirectly(int value)
        {
            this.SplitterDistance = value;
        }

        private void ApplySplitterDistance()
        {
            this.SplitterDistance = this.SplitterDistanceInternal;

            if (this.BackColor == Color.Transparent)
            {
                base.Invalidate();
            }
            //Assigned the rectangle in order to be able to access it's members.
            Rectangle objSplitterRect = this.SplitterRectangleInternal;
            if (this.Orientation == Orientation.Vertical)
            {
                if (this.RightToLeft == RightToLeft.No)
                {
                    objSplitterRect.X = base.Location.X + this.SplitterDistanceInternal;
                }
                else
                {
                    objSplitterRect.X = (base.LayoutRight - this.SplitterDistanceInternal) - this.SplitterWidthInternal;
                }
            }
            else
            {
                objSplitterRect.Y = base.Location.Y + this.SplitterDistanceInternal;
            }
            this.SplitterRectangleInternal = objSplitterRect;
        }

        private Rectangle CalcSplitLine(int intSplitSize, int intMinWeight)
        {
            Rectangle objRectangle = new Rectangle();
            switch (this.Orientation)
            {
                case Orientation.Horizontal:
                    objRectangle.Width = base.Width;
                    objRectangle.Height = this.SplitterWidthInternal;
                    if (objRectangle.Width < intMinWeight)
                    {
                        objRectangle.Width = intMinWeight;
                    }
                    objRectangle.Y = this.Panel1.Location.Y + intSplitSize;
                    return objRectangle;

                case Orientation.Vertical:
                    objRectangle.Width = this.SplitterWidthInternal;
                    objRectangle.Height = base.Height;
                    if (objRectangle.Width < intMinWeight)
                    {
                        objRectangle.Width = intMinWeight;
                    }
                    if (this.RightToLeft == RightToLeft.No)
                    {
                        objRectangle.X = this.Panel1.Location.X + intSplitSize;
                        return objRectangle;
                    }
                    objRectangle.X = (base.Width - intSplitSize) - this.SplitterWidthInternal;
                    return objRectangle;
            }
            return objRectangle;
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

            this.ContainerSplitterPrivate.Visible = !blnCollapsing;

            this.UpdateSplitter();
        }

        private void DrawSplitBar(int intMode)
        {
            if ((intMode != 1) && (this.LastDrawSplit != -1))
            {
                this.DrawSplitHelper(this.LastDrawSplit);
                this.LastDrawSplit = -1;
            }
            else if ((intMode != 1) && (this.LastDrawSplit == -1))
            {
                return;
            }
            if (intMode != 3)
            {
                //Assignment in order to save trips to Serializable Property.
                int intSplitterDistance = this.SplitterDistanceInternal;
                if (this.SplitterMove || this.SplitterBegin)
                {
                    this.DrawSplitHelper(intSplitterDistance);
                    this.LastDrawSplit = intSplitterDistance;
                }
                else
                {
                    this.DrawSplitHelper(intSplitterDistance);
                    this.LastDrawSplit = intSplitterDistance;
                }
            }
            else
            {
                if (this.LastDrawSplit != -1)
                {
                    this.DrawSplitHelper(this.LastDrawSplit);
                }
                this.LastDrawSplit = -1;
            }
        }

        private void DrawSplitHelper(int intSplitSize)
        {
            Rectangle objRectangle = this.CalcSplitLine(intSplitSize, 3);
            IntPtr handle = base.Handle;
        }

        //Returns the distance of the control from a given point.
        //Used to calculate movement
        private int GetSplitterDistance(int intX, int intY)
        {
            int num;
            if (this.Orientation == Orientation.Vertical)
            {
                num = intX - this.AnchorPoint.X;
            }
            else
            {
                num = intY - this.AnchorPoint.Y;
            }
            int num2 = 0;
            //The border size of the control
            int intBorderSize = this.BorderSize;
            switch (this.Orientation)
            {
                case Orientation.Horizontal:
                    num2 = Math.Max(this.Panel1.Height + num, intBorderSize);
                    break;

                case Orientation.Vertical:
                    if (this.RightToLeft != RightToLeft.No)
                    {
                        num2 = Math.Max(this.Panel1.Width - num, intBorderSize);
                        break;
                    }
                    num2 = Math.Max(this.Panel1.Width + num, intBorderSize);
                    break;
            }
            if (this.Orientation == Orientation.Vertical)
            {
                return Math.Max(Math.Min(num2, base.Width - this.Panel2MinSize), this.Panel1MinSize);
            }
            return Math.Max(Math.Min(num2, base.Height - this.Panel2MinSize), this.Panel1MinSize);
        }

        private void RepaintSplitterRect()
        {
            if (!base.IsHandleCreated)
            {
                return;
            }
        }

        private void ResizeSplitContainer()
        {
            if (!this.SplitContainerScaling)
            {
                //Assignment in order to save trips to Serializable Property.
                SplitterPanel objPanel1 = this.Panel1;
                SplitterPanel objPanel2 = this.Panel2;
                objPanel1.SuspendLayout();
                objPanel2.SuspendLayout();
                if (base.Width == 0)
                {
                    objPanel1.Size = new Size(0, objPanel1.Height);
                    objPanel2.Size = new Size(0, objPanel2.Height);
                }
                else if (base.Height == 0)
                {
                    objPanel1.Size = new Size(objPanel1.Width, 0);
                    objPanel2.Size = new Size(objPanel2.Width, 0);
                }
                else
                {
                    if (this.Orientation == Orientation.Vertical)
                    {
                        if (!this.CollapsedMode)
                        {
                            if (this.FixedPanel == FixedPanel.Panel1)
                            {
                                //Assignment in order to save trips to Serializable Property.
                                int intPanelSize = this.PanelSize;
                                objPanel1.Size = new Size(intPanelSize, base.Height);
                                objPanel2.Size = new Size(Math.Max((base.Width - intPanelSize) - this.SplitterWidthInternal, this.Panel2MinSize), base.Height);
                            }
                            if (this.FixedPanel == FixedPanel.Panel2)
                            {
                                //Assignment in order to save trips to Serializable Property.
                                int intPanelSize = this.PanelSize;
                                objPanel2.Size = new Size(intPanelSize, base.Height);
                                //Assignment in order to save trips to Serializable Property.
                                int intSplitterDistance = Math.Max((base.Width - intPanelSize) - this.SplitterWidthInternal, this.Panel1MinSize);
                                this.SplitterDistanceInternal = intSplitterDistance;
                                objPanel1.WidthInternal = intSplitterDistance;
                                objPanel1.HeightInternal = base.Height;
                            }
                            if (this.FixedPanel == FixedPanel.None)
                            {
                                //Assignment in order to save trips to Serializable Property.
                                double ratioWidth = this.RatioWidth;
                                if (ratioWidth != 0)
                                {
                                    this.SplitterDistanceInternal = Math.Max((int)Math.Floor((double)(((double)base.Width) / ratioWidth)), this.Panel1MinSize);
                                }
                                //Assignment in order to save trips to Serializable Property.
                                int intSplitterDistance = this.SplitterDistanceInternal;
                                objPanel1.WidthInternal = intSplitterDistance;
                                objPanel1.HeightInternal = base.Height;
                                objPanel2.Size = new Size(Math.Max((base.Width - intSplitterDistance) - this.SplitterWidthInternal, this.Panel2MinSize), base.Height);
                            }
                            if (this.RightToLeft == RightToLeft.No)
                            {
                                objPanel2.Location = new Point(objPanel1.WidthInternal + this.SplitterWidthInternal, 0);
                            }
                            else
                            {
                                objPanel1.Location = new Point(base.Width - objPanel1.WidthInternal, 0);
                            }
                            this.RepaintSplitterRect();
                            this.SetSplitterRect(true);
                        }
                        else if (this.Panel1Collapsed)
                        {
                            objPanel2.Size = base.Size;
                            objPanel2.Location = new Point(0, 0);
                        }
                        else if (this.Panel2Collapsed)
                        {
                            objPanel1.Size = base.Size;
                            objPanel1.Location = new Point(0, 0);
                        }
                    }
                    else if (this.Orientation == Orientation.Horizontal)
                    {
                        if (!this.CollapsedMode)
                        {
                            if (this.FixedPanel == FixedPanel.Panel1)
                            {
                                //Assignment in order to save trips to Serializable Property.
                                int intPanelSize = this.PanelSize;
                                objPanel1.Size = new Size(base.Width, intPanelSize);
                                int intY = intPanelSize + this.SplitterWidthInternal;
                                objPanel2.Size = new Size(base.Width, Math.Max(base.Height - intY, this.Panel2MinSize));
                                objPanel2.Location = new Point(0, intY);
                            }
                            if (this.FixedPanel == FixedPanel.Panel2)
                            {
                                objPanel2.Size = new Size(base.Width, this.PanelSize);
                                //Assignment in order to save trips to Serializable Property.
                                int intSplitterDistance = Math.Max((base.Height - this.Panel2.Height) - this.SplitterWidthInternal, this.Panel1MinSize);
                                this.SplitterDistanceInternal = intSplitterDistance;
                                objPanel1.HeightInternal = intSplitterDistance;
                                objPanel1.WidthInternal = base.Width;
                                int num2 = intSplitterDistance + this.SplitterWidthInternal;
                                objPanel2.Location = new Point(0, num2);
                            }
                            if (this.FixedPanel == FixedPanel.None)
                            {
                                //Assignment in order to save trips to Serializable Property.
                                double ratioHeight = this.RatioHeight;
                                if (ratioHeight != 0)
                                {
                                    this.SplitterDistanceInternal = Math.Max((int)Math.Floor((double)(((double)base.Height) / ratioHeight)), this.Panel1MinSize);
                                }
                                //Assignment in order to save trips to Serializable Property.
                                int intSplitterDistance = this.SplitterDistanceInternal;
                                objPanel1.HeightInternal = intSplitterDistance;
                                objPanel1.WidthInternal = base.Width;
                                int num3 = intSplitterDistance + this.SplitterWidthInternal;
                                objPanel2.Size = new Size(base.Width, Math.Max(base.Height - num3, this.Panel2MinSize));
                                objPanel2.Location = new Point(0, num3);
                            }
                            this.RepaintSplitterRect();
                            this.SetSplitterRect(false);
                        }
                        else if (this.Panel1Collapsed)
                        {
                            objPanel2.Size = base.Size;
                            objPanel2.Location = new Point(0, 0);
                        }
                        else if (this.Panel2Collapsed)
                        {
                            objPanel1.Size = base.Size;
                            objPanel1.Location = new Point(0, 0);
                        }
                    }
                    try
                    {
                        this.ResizeCalled = true;
                        this.ApplySplitterDistance();
                    }
                    finally
                    {
                        this.ResizeCalled = false;
                    }
                }
                objPanel1.ResumeLayout();
                objPanel2.ResumeLayout();
            }
        }

        private void SetInnerMostBorder(SplitContainer sc)
        {
            foreach (Control objControl in sc.Controls)
            {
                bool blnFlag = false;
                if (objControl is SplitterPanel)
                {
                    foreach (Control objControl2 in objControl.Controls)
                    {
                        SplitContainer container = objControl2 as SplitContainer;
                        if ((container != null) && (container.Dock == DockStyle.Fill))
                        {
                            if (container.BorderStyle != this.BorderStyle)
                            {
                                break;
                            }
                            ((SplitterPanel)objControl).BorderStyle = BorderStyle.None;
                            this.SetInnerMostBorder(container);
                            blnFlag = true;
                        }
                    }
                    if (!blnFlag)
                    {
                        ((SplitterPanel)objControl).BorderStyle = this.BorderStyle;
                    }
                }
            }
        }

        private void SetSplitterRect(bool blnVertical)
        {
            //Assignment in order to save trips to Serializable Property.
            Rectangle objSplitterRect = this.SplitterRectangleInternal;

            if (blnVertical)
            {
                //Assignment in order to save trips to Serializable Property.
                int intSplitterDistance = this.SplitterDistanceInternal;

                objSplitterRect.X = (this.RightToLeft == RightToLeft.Yes) ? ((base.Width - intSplitterDistance) - this.SplitterWidthInternal) : (base.Location.X + intSplitterDistance);
                objSplitterRect.Y = base.Location.Y;
                objSplitterRect.Width = this.SplitterWidthInternal;
                objSplitterRect.Height = base.Height;
            }
            else
            {
                objSplitterRect.X = base.Location.X;
                objSplitterRect.Y = base.Location.Y + this.SplitterDistanceInternal;
                objSplitterRect.Width = base.Width;
                objSplitterRect.Height = this.SplitterWidthInternal;
            }
            this.SplitterRectangleInternal = objSplitterRect;
        }

        private void SplitBegin(int intX, int intY)
        {
            this.AnchorPoint = new Point(intX, intY);
            //Assignment in order to save trips to Serializable Property.
            int intSplitterDistance = this.GetSplitterDistance(intX, intY);
            this.SplitterDistanceInternal = intSplitterDistance;
            this.InitialSplitterDistance = intSplitterDistance;
            this.InitialSplitterRectangle = this.SplitterRectangle;

            this.DrawSplitBar(1);
        }

        private void SplitEnd(bool blnAccept)
        {
            this.DrawSplitBar(3);
            //assign this.InitialSplitterDistance for multiple uses.
            int initialSplitterDistance = this.InitialSplitterDistance;

            if (blnAccept)
            {
                this.ApplySplitterDistance();
            }
            else if (this.SplitterDistanceInternal != initialSplitterDistance)
            {
                this.SplitterClick = false;
                this.SplitterDistance = initialSplitterDistance;
            }
            this.AnchorPoint = Point.Empty;
        }

        private void SplitMove(int intX, int intY)
        {
            int intSplitterDistance = this.GetSplitterDistance(intX, intY);
            int num2 = intSplitterDistance - this.InitialSplitterDistance;
            int num3 = num2 % this.SplitterIncrement;
            if (this.SplitterDistanceInternal != intSplitterDistance)
            {
                //The border size of the control
                int intBorderSize = this.BorderSize;
                if (this.Orientation == Orientation.Vertical)
                {
                    if ((intSplitterDistance + this.SplitterWidthInternal) <= ((base.Width - this.Panel2MinSize) - intBorderSize))
                    {
                        this.SplitterDistanceInternal = intSplitterDistance - num3;
                    }
                }
                else if ((intSplitterDistance + this.SplitterWidthInternal) <= ((base.Height - this.Panel2MinSize) - intBorderSize))
                {
                    this.SplitterDistanceInternal = intSplitterDistance - num3;
                }
            }
            this.DrawSplitBar(2);
        }

        private void UpdateSplitter()
        {
            if (!this.SplitContainerScaling)
            {
                //Assignment in order to save trips to Serializable Property.
                SplitterPanel objPanel1 = this.Panel1;
                SplitterPanel objPanel2 = this.Panel2;

                if (this.Orientation == Orientation.Vertical)
                {
                    bool blnFlag = this.RightToLeft == RightToLeft.Yes;
                    if (!this.CollapsedMode)
                    {
                        //Assignment in order to save trips to Serializable Property.
                        int intSplitterDistance = this.SplitterDistanceInternal;
                        objPanel1.HeightInternal = base.Height;
                        objPanel1.WidthInternal = intSplitterDistance;
                        objPanel2.Size = new Size((base.Width - intSplitterDistance) - this.SplitterWidthInternal, base.Height);
                        if (!blnFlag)
                        {
                            objPanel1.Location = new Point(0, 0);
                            objPanel2.Location = new Point(intSplitterDistance + this.SplitterWidthInternal, 0);
                        }
                        else
                        {
                            objPanel1.Location = new Point(base.Width - intSplitterDistance, 0);
                            objPanel2.Location = new Point(0, 0);
                        }
                        this.RepaintSplitterRect();
                        this.SetSplitterRect(true);
                        if (!this.ResizeCalled)
                        {
                            this.RatioWidth = ((((double)base.Width) / ((double)objPanel1.Width)) > 0) ? (((double)base.Width) / ((double)objPanel1.Width)) : this.RatioWidth;
                        }
                    }
                    else
                    {
                        if (this.Panel1Collapsed)
                        {
                            objPanel2.Size = base.Size;
                            objPanel2.Location = new Point(0, 0);
                        }
                        else if (this.Panel2Collapsed)
                        {
                            objPanel1.Size = base.Size;
                            objPanel1.Location = new Point(0, 0);
                        }
                        if (!this.ResizeCalled)
                        {
                            //Assignment in order to save trips to Serializable Property.
                            int intSplitterDistance = this.SplitterDistanceInternal;
                            this.RatioWidth = ((((double)base.Width) / ((double)intSplitterDistance)) > 0) ? (((double)base.Width) / ((double)intSplitterDistance)) : this.RatioWidth;
                        }
                    }
                }
                else if (!this.CollapsedMode)
                {
                    objPanel1.Location = new Point(0, 0);
                    objPanel1.WidthInternal = base.Width;
                    //Assignment in order to save trips to Serializable Property.
                    int intSplitterDistance = this.SplitterDistanceInternal;
                    objPanel1.HeightInternal = intSplitterDistance;
                    int intY = intSplitterDistance + this.SplitterWidthInternal;
                    objPanel2.Size = new Size(base.Width, base.Height - intY);
                    objPanel2.Location = new Point(0, intY);
                    this.RepaintSplitterRect();
                    this.SetSplitterRect(false);
                    if (!this.ResizeCalled)
                    {
                        this.RatioHeight = ((((double)base.Height) / ((double)objPanel1.Height)) > 0) ? (((double)base.Height) / ((double)objPanel1.Height)) : this.RatioHeight;
                    }
                }
                else
                {
                    if (this.Panel1Collapsed)
                    {
                        objPanel2.Size = base.Size;
                        objPanel2.Location = new Point(0, 0);
                    }
                    else if (this.Panel2Collapsed)
                    {
                        objPanel1.Size = base.Size;
                        objPanel1.Location = new Point(0, 0);
                    }
                    if (!this.ResizeCalled)
                    {
                        //Assignment in order to save trips to Serializable Property.
                        int intSplitterDistance = this.SplitterDistanceInternal;
                        this.RatioHeight = ((((double)base.Height) / ((double)intSplitterDistance)) > 0) ? (((double)base.Height) / ((double)intSplitterDistance)) : this.RatioHeight;
                    }
                }

                // Initialize splitter.
                if (this.ContainerSplitterPrivate == null)
                {
                    this.ContainerSplitterPrivate = new ContainerSplitter(this);
                }

                if (this.Orientation == Orientation.Vertical)
                {
                    this.ContainerSplitterPrivate.Width = this.SplitterWidth;
                }
                else
                {
                    this.ContainerSplitterPrivate.Height = this.SplitterWidth;
                }
            }
        }

        #endregion

        #region Internal Methods

        new internal void AfterControlRemoved(Control objControl, Control objOldParent)
        {
            if ((objControl is SplitContainer) && (objControl.Dock == DockStyle.Fill))
            {
                this.SetInnerMostBorder(this);
            }
        }

        #endregion

        #endregion

        #region Classes

        #region ContainerSplitter Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        [ToolboxItem(false)]
        private class ContainerSplitter : Splitter
        {
            private SplitContainer mobjSplitContainer;

            /// <summary>
            /// Gets the critical events.
            /// </summary>
            /// <returns></returns>
            protected override CriticalEventsData GetCriticalEventsData()
            {
                CriticalEventsData objEvents = base.GetCriticalEventsData();

                // Check if containing split container registered the splitter moved event.
                if (this.mobjSplitContainer != null)
                {
                    if (this.mobjSplitContainer.IsSplitterMovedRegistered)
                    {
                        objEvents.Set(WGEvents.PositionChanged);
                    }
                    if (this.mobjSplitContainer.IsCriticalEvent(Control.MouseClickEvent) ||
                        this.mobjSplitContainer.IsCriticalEvent(Control.MouseDownEvent) ||
                        this.mobjSplitContainer.IsCriticalEvent(Control.MouseUpEvent))
                    {
                        objEvents.Set(WGEvents.Click);
                    }
                    if (this.mobjSplitContainer.IsCriticalEvent(Control.DoubleClickEvent))
                    {
                        objEvents.Set(WGEvents.DoubleClick);
                    }
                }

                return objEvents;
            }

            /// <summary>
            /// Fires an event.
            /// </summary>
            /// <param name="objEvent">event.</param>
            protected override void FireEvent(IEvent objEvent)
            {
                base.FireEvent(objEvent);

                // Check that container splitter has a valid split container.
                if (this.mobjSplitContainer != null)
                {
                    switch (objEvent.Type)
                    {
                        case "SplitterMoved":
                            // Get fixed panel.
                            SplitterPanel objFixedPanel = (this.mobjSplitContainer.FixedPanel == FixedPanel.Panel1 ? this.mobjSplitContainer.Panel1 : this.mobjSplitContainer.Panel2);
                            if (objFixedPanel != null)
                            {
                                // If FixedPanel is panel1, splitter distance is directly panel1's dimensions
                                if (objFixedPanel == this.mobjSplitContainer.Panel1)
                                {
                                    // Check split container's orientation.
                                    if (this.mobjSplitContainer.Orientation == Orientation.Vertical)
                                    {
                                        // Calculate splitter distance.
                                        this.mobjSplitContainer.SetSplitterDistanceDirectly(objFixedPanel.Width);
                                    }
                                    else
                                    {
                                        // Calculate splitter distance.
                                        this.mobjSplitContainer.SetSplitterDistanceDirectly(objFixedPanel.Height);
                                    }
                                }
                                else  // splitter distance is parent's dimension, minus FixedPanel's dimension, minus splitter sidth
                                {
                                    // Check split container's orientation.
                                    if (this.mobjSplitContainer.Orientation == Orientation.Vertical)
                                    {
                                        // Calculate splitter distance.
                                        this.mobjSplitContainer.SetSplitterDistanceDirectly(this.mobjSplitContainer.Width - (objFixedPanel.Width + this.mobjSplitContainer.SplitterWidth));
                                    }
                                    else
                                    {
                                        // Calculate splitter distance.
                                        this.mobjSplitContainer.SetSplitterDistanceDirectly(this.mobjSplitContainer.Height - (objFixedPanel.Height + this.mobjSplitContainer.SplitterWidth));
                                    }
                                }
                            }
                            break;

                        case "Click":
                        case "DoubleClick":
                            this.mobjSplitContainer.FireEvent(objEvent);
                            break;
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ContainerSplitter"/> class.
            /// </summary>
            internal ContainerSplitter()
                : base()
            {
                this.Size = new Size(3, 3);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ContainerSplitter"/> class.
            /// </summary>
            /// <param name="objSplitContainer">The SplitContainer.</param>
            internal ContainerSplitter(SplitContainer objSplitContainer)
                : this()
            {
                this.mobjSplitContainer = objSplitContainer;
            }

            /// <summary>
            /// Gets the dock style.
            /// </summary>
            /// <returns></returns>
            internal override DockStyle GetDockInternal()
            {
                // Get parent split container.
                SplitContainer objSplitContainer = this.Parent as SplitContainer;

                if (objSplitContainer != null)
                {
                    // Handle vertical orientation.
                    if (objSplitContainer.Orientation == Orientation.Vertical)
                    {
                        if (objSplitContainer.FixedPanel == FixedPanel.Panel2)
                        {
                            return DockStyle.Right;
                        }
                        else
                        {
                            return DockStyle.Left;
                        }
                    }
                    // Handle horizontal orientation.
                    else
                    {
                        if (objSplitContainer.FixedPanel == FixedPanel.Panel2)
                        {
                            return DockStyle.Bottom;
                        }
                        else
                        {
                            return DockStyle.Top;
                        }
                    }
                }
                else
                {
                    return base.GetDockInternal();
                }
            }

            /// <summary>
            /// Gets the anchor style.
            /// </summary>
            /// <returns></returns>
            internal override AnchorStyles GetAnchorInternal()
            {
                return AnchorStyles.None;
            }
        }

        #endregion

        #region SplitContainerTypedControlCollection Class

        [Serializable()]
        internal class SplitContainerTypedControlCollection : ClientUtils.TypedControlCollection
        {
            private SplitContainer mobjOwner;

            public SplitContainerTypedControlCollection(Control objControl, Type objType, bool blnIsReadOnly)
                : base(objControl, objType, blnIsReadOnly)
            {
                this.mobjOwner = objControl as SplitContainer;
            }

            public override void Remove(Control objValue)
            {
                if (((objValue is SplitterPanel) && !this.mobjOwner.DesignMode) && this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
                base.Remove(objValue);
            }

            internal override void SetChildIndexInternal(Control objChild, int intNewIndex)
            {
                if (objChild is SplitterPanel)
                {
                    if (this.mobjOwner.DesignMode)
                    {
                        return;
                    }
                    if (this.IsReadOnly)
                    {
                        throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                    }
                }
                base.SetChildIndexInternal(objChild, intNewIndex);
            }
        }

        #endregion SplitContainerTypedControlCollection Class

        #endregion
    }

    #endregion

    #region SplitterEventArgs Class

    /// <summary>
    /// Provides data for SplitterMoving and the SplitterMoved events.
    /// </summary>
    [ComVisible(true), Serializable()]
    public class SplitterEventArgs : EventArgs
    {
        #region Class Members

        private int mintSplitX;
        private int mintSplitY;
        private readonly int mintX;
        private readonly int mintY;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitterEventArgs"/> class.
        /// </summary>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="intSplitX">The split X.</param>
        /// <param name="intSplitY">The split Y.</param>
        public SplitterEventArgs(int intX, int intY, int intSplitX, int intSplitY)
        {
            this.mintX = intX;
            this.mintY = intY;
            this.mintSplitX = intSplitX;
            this.mintSplitY = intSplitY;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the Splitter (in client coordinates).
        /// </summary>
        /// <value>The split X.</value>
        public int SplitX
        {
            get
            {
                return this.mintSplitX;
            }
            set
            {
                this.mintSplitX = value;
            }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the Splitter (in client coordinates).
        /// </summary>
        /// <value>The split Y.</value>
        public int SplitY
        {
            get
            {
                return this.mintSplitY;
            }
            set
            {
                this.mintSplitY = value;
            }
        }

        /// <summary>
        /// Gets the x-coordinate of the mouse pointer (in client coordinates).
        /// </summary>
        /// <value>The X.</value>
        public int X
        {
            get
            {
                return this.mintX;
            }
        }

        /// <summary>
        /// Gets the y-coordinate of the mouse pointer (in client coordinates).
        /// </summary>
        /// <value>The Y.</value>
        public int Y
        {
            get
            {
                return this.mintY;
            }
        }

        #endregion
    }

    #endregion

    #region SplitterCancelEventArgs Class

    /// <summary>
    /// Provides data for splitter events.
    /// </summary>
    [Serializable()]
    public class SplitterCancelEventArgs : CancelEventArgs
    {
        #region Class Members

        private readonly int mintMouseCursorX;
        private readonly int mintMouseCursorY;
        private int mintSplitX;
        private int mintSplitY;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitterCancelEventArgs"/> class.
        /// </summary>
        /// <param name="intMouseCursorX">The mouse cursor X.</param>
        /// <param name="intMouseCursorY">The mouse cursor Y.</param>
        /// <param name="intSplitX">The split X.</param>
        /// <param name="intSplitY">The split Y.</param>
        public SplitterCancelEventArgs(int intMouseCursorX, int intMouseCursorY, int intSplitX, int intSplitY)
            : base(false)
        {
            this.mintMouseCursorX = intMouseCursorX;
            this.mintMouseCursorY = intMouseCursorY;
            this.mintSplitX = intSplitX;
            this.mintSplitY = intSplitY;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the X coordinate of the mouse pointer in client coordinates.
        /// </summary>
        /// <value>The mouse cursor X.</value>
        public int MouseCursorX
        {
            get
            {
                return this.mintMouseCursorX;
            }
        }

        /// <summary>
        /// Gets the Y coordinate of the mouse pointer in client coordinates.
        /// </summary>
        /// <value>The mouse cursor Y.</value>
        public int MouseCursorY
        {
            get
            {
                return this.mintMouseCursorY;
            }
        }

        /// <summary>
        /// Gets or sets the X coordinate of the upper left corner of the SplitContainer in client coordinates.
        /// </summary>
        /// <value>The split X.</value>
        public int SplitX
        {
            get
            {
                return this.mintSplitX;
            }
            set
            {
                this.mintSplitX = value;
            }
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the upper left corner of the SplitContainer in client coordinates.
        /// </summary>
        /// <value>The split Y.</value>
        public int SplitY
        {
            get
            {
                return this.mintSplitY;
            }
            set
            {
                this.mintSplitY = value;
            }
        }

        #endregion
    }
    #endregion
}
