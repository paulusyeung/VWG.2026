using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Extensibility;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Provides panels on each side of the form and a central panel that can hold one or more controls.</summary>
    [ComVisible(true), SRDescription("ToolStripContainerDesc"), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [MetadataTag(WGTags.ToolStripContainer), Skin(typeof(ToolStripContainerSkin))]
    [Serializable()]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ToolStripContainer), "ToolStripContainer_45.bmp")]
#else
    [ToolboxBitmap(typeof(ToolStripContainer), "ToolStripContainer.bmp")]
#endif
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripContainer : ContainerControl
    {
        #region Members

        private static readonly SerializableProperty mobjBottomPanelProperty = SerializableProperty.Register("mobjBottomPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));
        private static readonly SerializableProperty mobjContentPanelProperty = SerializableProperty.Register("mobjContentPanel", typeof(ToolStripContentPanel), typeof(ToolStripContainer));
        private static readonly SerializableProperty mobjLeftPanelProperty = SerializableProperty.Register("mobjLeftPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));
        private static readonly SerializableProperty mobjRightPanelProperty = SerializableProperty.Register("mobjRightPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));
        private static readonly SerializableProperty mobjTopPanelProperty = SerializableProperty.Register("mobjTopPanel", typeof(ToolStripPanel), typeof(ToolStripContainer));

        #endregion Members

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> class. </summary>
        public ToolStripContainer()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
            base.SuspendLayout();
            try
            {
                this.mobjTopPanel = new ToolStripPanel(this);
                this.mobjBottomPanel = new ToolStripPanel(this);
                this.mobjLeftPanel = new ToolStripPanel(this);
                this.mobjRightPanel = new ToolStripPanel(this);
                this.mobjContentPanel = new ToolStripContentPanel();

                this.mobjContentPanel.Dock = DockStyle.Fill;
                this.mobjTopPanel.Dock = DockStyle.Top;
                this.mobjBottomPanel.Dock = DockStyle.Bottom;
                this.mobjRightPanel.Dock = DockStyle.Right;
                this.mobjLeftPanel.Dock = DockStyle.Left;

                ToolStripContainerTypedControlCollection arrControls = this.Controls as ToolStripContainerTypedControlCollection;
                if (arrControls != null)
                {
                    arrControls.AddInternal(this.mobjContentPanel);
                    arrControls.AddInternal(this.mobjLeftPanel);
                    arrControls.AddInternal(this.mobjRightPanel);
                    arrControls.AddInternal(this.mobjTopPanel);
                    arrControls.AddInternal(this.mobjBottomPanel);
                }
            }
            finally
            {
                base.ResumeLayout(true);
            }
        }

		#endregion Constructors 

		#region Properties

        #region Property Store

        private ToolStripPanel mobjBottomPanel
        {
            get
            {
                return this.GetValue<ToolStripPanel>(ToolStripContainer.mobjBottomPanelProperty);
            }
            set
            {
                this.SetValue<ToolStripPanel>(ToolStripContainer.mobjBottomPanelProperty, value);
            }
        }

        private ToolStripContentPanel mobjContentPanel
        {
            get
            {
                return this.GetValue<ToolStripContentPanel>(ToolStripContainer.mobjContentPanelProperty);
            }
            set
            {
                this.SetValue<ToolStripContentPanel>(ToolStripContainer.mobjContentPanelProperty, value);
            }
        }

        private ToolStripPanel mobjLeftPanel
        {
            get
            {
                return this.GetValue<ToolStripPanel>(ToolStripContainer.mobjLeftPanelProperty);
            }
            set
            {
                this.SetValue<ToolStripPanel>(ToolStripContainer.mobjLeftPanelProperty, value);
            }
        }

        private ToolStripPanel mobjRightPanel
        {
            get
            {
                return this.GetValue<ToolStripPanel>(ToolStripContainer.mobjRightPanelProperty);
            }
            set
            {
                this.SetValue<ToolStripPanel>(ToolStripContainer.mobjRightPanelProperty, value);
            }
        }

        private ToolStripPanel mobjTopPanel
        {
            get
            {
                return this.GetValue<ToolStripPanel>(ToolStripContainer.mobjTopPanelProperty);
            }
            set
            {
                this.SetValue<ToolStripPanel>(ToolStripContainer.mobjTopPanelProperty, value);
            }
        }

        #endregion

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>true to enable automatic scrolling; otherwise, false. </returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BackColor
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

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceHandle BackgroundImage
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

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>Gets the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
        [SRCategory("CatAppearance"), SRDescription("ToolStripContainerBottomToolStripPanelDescr"), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolStripPanel BottomToolStripPanel
        {
            get
            {
                return this.mobjBottomPanel;
            }
        }

        /// <summary>Gets or sets a value indicating whether the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible. </summary>
        /// <returns>true if the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
        [SRDescription("ToolStripContainerBottomToolStripPanelVisibleDescr"), SRCategory("CatAppearance"), DefaultValue(true)]
        public bool BottomToolStripPanelVisible
        {
            get
            {
                return this.BottomToolStripPanel.Visible;
            }
            set
            {
                this.BottomToolStripPanel.Visible = value;
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>true if the control causes validation; otherwise, false. </returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CausesValidation
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

        /// <summary>Gets the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> representing the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("ToolStripContainerContentPanelDescr"), Localizable(false), SRCategory("CatAppearance")]
        public ToolStripContentPanel ContentPanel
        {
            get
            {
                return this.mobjContentPanel;
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContextMenuStrip ContextMenuStrip
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

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Control.ControlCollection"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control.ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>Gets the default size of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> representing the horizontal and vertical dimensions of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(150, 0xaf);
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ForeColor
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

        /// <summary>Gets the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
        [SRCategory("CatAppearance"), SRDescription("ToolStripContainerLeftToolStripPanelDescr"), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolStripPanel LeftToolStripPanel
        {
            get
            {
                return this.mobjLeftPanel;
            }
        }

        /// <summary>Gets or sets a value indicating whether the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
        /// <returns>true if the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
        [SRCategory("CatAppearance"), SRDescription("ToolStripContainerLeftToolStripPanelVisibleDescr"), DefaultValue(true)]
        public bool LeftToolStripPanelVisible
        {
            get
            {
                return this.LeftToolStripPanel.Visible;
            }
            set
            {
                this.LeftToolStripPanel.Visible = value;
            }
        }

        /// <summary>Gets the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(false), SRCategory("CatAppearance"), SRDescription("ToolStripContainerRightToolStripPanelDescr")]
        public ToolStripPanel RightToolStripPanel
        {
            get
            {
                return this.mobjRightPanel;
            }
        }

        /// <summary>Gets or sets a value indicating whether the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
        /// <returns>true if the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
        [SRCategory("CatAppearance"), DefaultValue(true), SRDescription("ToolStripContainerRightToolStripPanelVisibleDescr")]
        public bool RightToolStripPanelVisible
        {
            get
            {
                return this.RightToolStripPanel.Visible;
            }
            set
            {
                this.RightToolStripPanel.Visible = value;
            }
        }

        /// <summary>Gets the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
        [SRCategory("CatAppearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("ToolStripContainerTopToolStripPanelDescr"), Localizable(false)]
        public ToolStripPanel TopToolStripPanel
        {
            get
            {
                return this.mobjTopPanel;
            }
        }

        /// <summary>Gets or sets a value indicating whether the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
        /// <returns>true if the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
        [SRDescription("ToolStripContainerTopToolStripPanelVisibleDescr"), SRCategory("CatAppearance"), DefaultValue(true)]
        public bool TopToolStripPanelVisible
        {
            get
            {
                return this.TopToolStripPanel.Visible;
            }
            set
            {
                this.TopToolStripPanel.Visible = value;
            }
        }

		#endregion Properties 

        #region Events

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler BackColorChanged
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

        /// <summary>This event is not relevant for this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler BackgroundImageChanged
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

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler BackgroundImageLayoutChanged
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

        /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.CausesValidation"></see> property changes.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler CausesValidationChanged
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

        /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.ContextMenuStrip"></see> property changes.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ContextMenuStripChanged
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

        /// <summary>This event is not relevant for this class.</summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler CursorChanged
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

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ForeColorChanged
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


        #endregion Events

        #region Methods

        /// <summary>Creates and returns a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</summary>
        /// <returns>A read-only <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ToolStripContainerTypedControlCollection(this, true);
        }


		#endregion Methods 

        #region ToolStripContainerTypedControlCollection Class

        internal class ToolStripContainerTypedControlCollection : ClientUtils.ReadOnlyControlCollection
        {
        #region Members

        private Type mobjContentPanelType;
        private ToolStripContainer mobjOwnerToolStripContainer;
        private Type mobjPanelType;

		#endregion Members 

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripContainerTypedControlCollection"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
            public ToolStripContainerTypedControlCollection(Control c, bool isReadOnly) : base(c, isReadOnly)
            {
                this.mobjContentPanelType = typeof(ToolStripContentPanel);
                this.mobjPanelType = typeof(ToolStripPanel);
                this.mobjOwnerToolStripContainer = c as ToolStripContainer;
            }

		#endregion Constructors 

		#region Methods

            /// <summary>
            /// Adds the specified value.
            /// </summary>
            /// <param name="value">The value.</param>
        public override void Add(Control value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripContainerUseContentPanel"));
            }
            Type c = value.GetType();
            if (!this.mobjContentPanelType.IsAssignableFrom(c) && !this.mobjPanelType.IsAssignableFrom(c))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfTypes", new object[] { this.mobjContentPanelType.Name, this.mobjPanelType.Name }), new object[0]), value.GetType().Name);
            }
            base.Add(value);
        }

        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public override void Remove(Control value)
        {
            if (((value is ToolStripPanel) || (value is ToolStripContentPanel)) && (!this.mobjOwnerToolStripContainer.DesignMode && this.IsReadOnly))
            {
                throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
            }
            base.Remove(value);
        }

        /// <summary>
        /// Sets the child index internal.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <param name="newIndex">The new index.</param>
        internal override void SetChildIndexInternal(Control child, int newIndex)
        {
            if ((child is ToolStripPanel) || (child is ToolStripContentPanel))
            {
                if (this.mobjOwnerToolStripContainer.DesignMode)
                {
                    return;
                }
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
            }
            base.SetChildIndexInternal(child, newIndex);
        }

		#endregion Methods 
        }

		#endregion
    }
}
