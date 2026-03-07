using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Creates a panel that is associated with a SplitContainer.
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch), ComVisible(true), ToolboxItem(false)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.SplitterPanelSkin))]

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif
    [Serializable]
    public sealed class SplitterPanel : Panel
    {
        
		#region  Class Members (8)

		private bool mblnCollapsed;
		private SplitContainer mobjOwner;
        /// <summary>
        /// Occurs when [auto size changed].
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler AutoSizeChanged;

        /// <summary>
        /// Occurs when the value of the Dock property changes. 
        /// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#endif
        public event EventHandler DockChanged;

        /// <summary>
        /// Occurs when the Location property value has changed.
        /// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#endif
        new public event EventHandler LocationChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="TabIndex"> TabIndex </see> property changes.
        /// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#endif
		public event EventHandler TabIndexChanged;

        /// <summary>
        /// Occurs when the value of the TabStop property changes.
        /// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#endif
		public event EventHandler TabStopChanged;

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.
        /// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#endif
        new public event EventHandler VisibleChanged
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
		
		#endregion 

		#region  C'Tors \ D'Tors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitterPanel"/> class.
        /// </summary>
        /// <param name="objOwner">The owner.</param>
		public SplitterPanel(SplitContainer objOwner) : base()
        {
            this.mobjOwner = objOwner;
            base.SetStyle(ControlStyles.ResizeRedraw, true);
        }
		
		#endregion 

		#region  Properties (22)

        /// <summary>
        /// Gets or sets the anchoring style.
        /// </summary>
        /// <value></value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public AnchorStyles Anchor
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

        /// <summary>
        /// Enables the SplitterPanel to shrink when AutoSize is true. 
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.</returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public bool AutoSize
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
        /// Indicates the automatic sizing behavior of the control.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
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

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public BorderStyle BorderStyle
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
                return this.mblnCollapsed;
            }
            set
            {
                this.mblnCollapsed = value;
            }
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public DockStyle Dock
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

        /// <summary>
        /// Gets the dock padding settings for all edges of the control.
        /// </summary>
        /// <value>
        /// A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges"/> that represents the padding for all the edges of a docked control.
        /// </value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public ScrollableControl.DockPaddingEdges DockPadding
        {
            get
            {
                return base.DockPadding;
            }
        }

        /// <summary>
        /// Gets/Sets the height position
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Always), SRCategory("CatLayout"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlHeightDescr")]
        new public int Height
        {
            get
            {
                if (this.Collapsed)
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

        /// <summary>
        /// Gets or sets the control location.
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        new public Point Location
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

        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
        /// </summary>
        /// <value></value>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		[EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
        /// </summary>
        /// <value></value>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MinimumSize
        {
            get
            {
                if (this.Owner != null)
                {
                    // Get the panel's minimum size.
                    int intMinSize = this.Owner.Panel1MinSize;

                    if (this == this.Owner.Panel2)
                    {
                        intMinSize = this.Owner.Panel2MinSize;
                    }

                    // Check owner orientation.
                    if (this.Owner.Orientation == Orientation.Horizontal)
                    {
                        return new Size(this.DefaultMinimumSize.Width, intMinSize);
                    }
                    else
                    {
                        return new Size(intMinSize, this.DefaultMinimumSize.Height);
                    }
                }

                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the name associated with this control.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string Name
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

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
		internal SplitContainer Owner
        {
            get
            {
                return this.mobjOwner;
            }
        }

        /// <summary>
        /// Gets or sets the parent container of this control.
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public Control Parent
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

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public Size Size
        {
            get
            {
                if (this.Collapsed)
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

        /// <summary>
        /// Gets or sets the tab index.
        /// </summary>
        /// <value></value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        new public int TabIndex
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

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public bool TabStop
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

        /// <summary>
        /// Gets or sets the control visability.
        /// </summary>
        /// <value></value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        new public bool Visible
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

        /// <summary>
        /// Gets/Sets the width position
        /// </summary>
        /// <value></value>
		[EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatLayout"), Browsable(false), SRDescription("ControlWidthDescr")]
        new public int Width
        {
            get
            {
                if (this.Collapsed)
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
		
		#endregion 

        /// <summary>
        /// Applies the pre release dock fill compatibility.
        /// </summary>
        protected internal override void ApplyPreReleaseDockFillCompatibility()
        {
            // Prevent PreReleaseDockFillCompatibility in order to prevent setting child index on a read only control collection.            
        }

        internal override AnchorStyles GetAnchorInternal()
        {
            SplitContainer objSplitContainer = this.Parent as SplitContainer;
            
            // Checks if parent container has site which will indicate on design time.
            if (objSplitContainer != null && ((RegisteredComponent)objSplitContainer).Site == null)
            {
                // Runtime
                return AnchorStyles.None;
            }
            else
            {
                // Designtime
                return base.GetAnchorInternal();
            }
        }

        internal override DockStyle GetDockInternal()
        {   
            // Define a none docking enum.
            DockStyle enmDockStyle = DockStyle.None;

            // Get the parent split container.
            SplitContainer objSplitContainer = this.Parent as SplitContainer;

            // Checks if parent container has site which will indicate on design time.
            if (objSplitContainer != null && ((RegisteredComponent)objSplitContainer).Site == null)
            {
                if((this == objSplitContainer.Panel1 && !objSplitContainer.Panel1Collapsed && objSplitContainer.Panel2Collapsed) ||
                    (this == objSplitContainer.Panel2 && !objSplitContainer.Panel2Collapsed && objSplitContainer.Panel1Collapsed))
                {
                    return DockStyle.Fill;
                }
                // Runtime
                bool blnFixedPanel = (objSplitContainer.Panel1 == this);

                if (objSplitContainer.FixedPanel != FixedPanel.None)
                {
                    // In case of a specific FixedPanel - check if this instance is the one.
                    blnFixedPanel = (objSplitContainer.Panel1 == this && objSplitContainer.FixedPanel == FixedPanel.Panel1) ||
                                    (objSplitContainer.Panel2 == this && objSplitContainer.FixedPanel == FixedPanel.Panel2);
                }
                
                // In case that this instance is fixed panel.
                if (blnFixedPanel)
                {
                    // Handle vertical orientation.
                    if (objSplitContainer.Orientation == Orientation.Vertical)
                    {
                            if (this == objSplitContainer.Panel1)
                            {
                                enmDockStyle = DockStyle.Left;
                            }
                            else
                            {
                                enmDockStyle = DockStyle.Right;
                            }
                    }
                    // Handle horizontal orientation.
                    else
                    {
                        if (this == objSplitContainer.Panel1)
                        {
                            enmDockStyle = DockStyle.Top;
                        }
                        else
                        {
                            enmDockStyle = DockStyle.Bottom;
                        }
                    }
                }
                else
                {
                    // None fixed panel sholud get fill dock style.
                    enmDockStyle = DockStyle.Fill;
                }
            }
            else
            {
                // Gets base call for design time.
                enmDockStyle = base.GetDockInternal();
            }

            return enmDockStyle;
        }
    }
}
