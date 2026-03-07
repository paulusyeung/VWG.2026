#region Using

using System;
using System.Xml;
using System.ComponentModel;

using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Defines a base class for controls that support auto-scrolling behavior.  
    /// </summary>
    [Serializable()]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.ScrollableControlSkin))]
    public class ScrollableControl : Control
    {

        #region Class Members

        /// <summary>
        /// Provides a property reference to DockPadding property.
        /// </summary>
        private static SerializableProperty DockPaddingProperty = SerializableProperty.Register("DockPadding", typeof(DockPaddingEdges), typeof(ScrollableControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The client minimum height of the control.
        /// </summary>
        /// <value>The client minimum height of the control.</value>
        [NonSerialized]
        private int mintMinimumClientHeight = -1;

        /// <summary>
        /// The render client minimum of the control.
        /// </summary>
        /// <value>The client minimum width of the control.</value>
        [NonSerialized]
        private int mintMinimumClientWidth = -1;

        private ScrollerType menmScrollerType;

        #endregion

        #region Classes

        /// <summary>
        /// Determines the border padding for docked controls.
        /// </summary>
        [TypeConverter(typeof(ScrollableControl.DockPaddingEdgesConverter))]
        [Serializable()]
        public class DockPaddingEdges
        {

            private ScrollableControl mobjOwner = null;

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="DockPaddingEdges"/> class.
            /// </summary>
            /// <param name="objOwner">The owner.</param>
            internal DockPaddingEdges(ScrollableControl objOwner)
            {
                mobjOwner = objOwner;
            }

            #endregion

            #region Properties


            internal bool IsAll
            {
                get
                {
                    return mobjOwner.Padding.All != -1;
                }
            }

            /// <summary>
            /// Gets or sets the padding width for all edges of a docked control.
            /// </summary>
            /// <value>The padding width, in pixels.</value>
            [SRDescription("PaddingAllDescr"), RefreshProperties(RefreshProperties.All)]
            public int All
            {
                get
                {
                    return mobjOwner.Padding.All;
                }
                set
                {
                    Padding mobjPadding = mobjOwner.Padding;
                    mobjPadding.All = value;
                    mobjOwner.Padding = mobjPadding;
                }
            }

            /// <summary>
            /// Gets or sets the padding width for the bottom edge of a docked control.
            /// </summary>
            /// <value>The padding width, in pixels.</value>
            [SRDescription("PaddingBottomDescr"), RefreshProperties(RefreshProperties.All)]
            public int Bottom
            {
                get
                {
                    return mobjOwner.Padding.Bottom;
                }
                set
                {
                    Padding mobjPadding = mobjOwner.Padding;
                    mobjPadding.Bottom = value;
                    mobjOwner.Padding = mobjPadding;
                }
            }

            /// <summary>
            /// Gets or sets the padding width for the top edge of a docked control.
            /// </summary>
            /// <value>The padding width, in pixels.</value>
            [SRDescription("PaddingTopDescr"), RefreshProperties(RefreshProperties.All)]
            public int Top
            {
                get
                {
                    return mobjOwner.Padding.Top;
                }
                set
                {
                    Padding mobjPadding = mobjOwner.Padding;
                    mobjPadding.Top = value;
                    mobjOwner.Padding = mobjPadding;
                }
            }

            /// <summary>
            /// Gets or sets the padding width for the right edge of a docked control.
            /// </summary>
            /// <value>The padding width, in pixels.</value>
            [RefreshProperties(RefreshProperties.All), SRDescription("PaddingRightDescr")]
            public int Right
            {
                get
                {
                    return mobjOwner.Padding.Right;
                }
                set
                {
                    Padding mobjPadding = mobjOwner.Padding;
                    mobjPadding.Right = value;
                    mobjOwner.Padding = mobjPadding;
                }
            }

            /// <summary>
            /// Gets or sets the padding width for the left edge of a docked control.
            /// </summary>
            /// <value>The padding width, in pixels.</value>
            [RefreshProperties(RefreshProperties.All), SRDescription("PaddingLeftDescr")]
            public int Left
            {
                get
                {
                    return mobjOwner.Padding.Left;
                }
                set
                {
                    Padding mobjPadding = mobjOwner.Padding;
                    mobjPadding.Left = value;
                    mobjOwner.Padding = mobjPadding;
                }
            }

            #endregion

            private bool ShouldSerializeAll()
            {
                return IsAll && (this.All != 0);
            }

            private bool ShouldSerializeBottom()
            {
                return !IsAll && (this.Bottom != 0);
            }

            private bool ShouldSerializeLeft()
            {
                return !IsAll && (this.Left != 0);
            }

            private bool ShouldSerializeRight()
            {
                return !IsAll && (this.Right != 0);
            }

            private bool ShouldSerializeTop()
            {
                return !IsAll && (this.Top != 0);
            }

            /// <summary>
            /// Returns an empty string.
            /// </summary>
            /// <returns>An empty string.</returns>
            public override string ToString()
            {
                return "";
            }

        }

        /// <summary>
        /// DockPaddingEdgesConverter class.
        /// </summary>
        [Serializable()]
        public class DockPaddingEdgesConverter : TypeConverter
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DockPaddingEdgesConverter"/> class.
            /// </summary>
            public DockPaddingEdgesConverter()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            /// <summary>
            /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
            /// </summary>
            /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
            /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
            /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
            /// </returns>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
            {
                PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(ScrollableControl.DockPaddingEdges), arrAttributes);
                string[] arrTextArray = new string[] { "All", "Left", "Top", "Right", "Bottom" };
                return objCollection.Sort(arrTextArray);
            }

            /// <summary>
            /// Returns whether this object supports properties, using the specified context.
            /// </summary>
            /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
            /// <returns>
            /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
            /// </returns>
            public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
            {
                return true;
            }


        }

        #endregion

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> class.
        /// </summary>
        public ScrollableControl()
        {
            // Set the default control style
            base.SetStyle(ControlStyles.ContainerControl, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, false);

            // Set the default state
            base.SetState(ControlState.HScroll | ControlState.VScroll, true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            mintMinimumClientHeight = objReader.ReadInt32();
            mintMinimumClientWidth = objReader.ReadInt32();
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            objWriter.WriteInt32(mintMinimumClientHeight);
            objWriter.WriteInt32(mintMinimumClientWidth);
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // render the base control attributes
            base.RenderAttributes(objContext, objWriter);

            // Renders minimum client size attributes.
            RenderMinimumClientSize(objContext, (IAttributeWriter)objWriter, false);

            RenderScrollBars(objWriter, false);
        }

        /// <summary>
        /// Renders the scroll bars.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderScrollBars(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.GetProxyPropertyValue<bool>("AutoScroll", this.AutoScroll))
            {
                bool blnVScroll = VScroll;
                bool blnHScroll = HScroll;

                if (blnHScroll && blnVScroll)
                {
                    objWriter.WriteAttributeString(WGAttributes.Scrollbars, "B");
                }
                else if (blnHScroll)
                {
                    objWriter.WriteAttributeString(WGAttributes.Scrollbars, "H");
                }
                else if (blnVScroll)
                {
                    objWriter.WriteAttributeString(WGAttributes.Scrollbars, "V");
                }
                
                if (this.ScrollerType != Forms.ScrollerType.Default || blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.ScrollerType, ((int)this.ScrollerType).ToString());
                }
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Scrollbars, string.Empty);
            }
        }

        /// <summary>
        /// Renders the preferred size.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRedraw">if set to <c>true</c> force redraw.</param>
        private void RenderMinimumClientSize(IContext objContext, IAttributeWriter objWriter, bool blnForceRedraw)
        {
            // If should use client minimum height
            if (this.ShouldRenderMinimumClientHeight())
            {
                // If client minimum height was set
                if (mintMinimumClientHeight > 0 && this.VScroll)
                {
                    objWriter.WriteAttributeString(WGAttributes.MinimumClientHeight, mintMinimumClientHeight.ToString());
                }
                else if (blnForceRedraw)
                {
                    objWriter.WriteAttributeString(WGAttributes.MinimumClientHeight, "0");
                }
            }

            // If should use client minimum width
            if (this.ShouldRenderMinimumClientWidth())
            {
                // If client minimum width was set
                if (mintMinimumClientWidth > 0 && this.HScroll)
                {
                    objWriter.WriteAttributeString(WGAttributes.MinimumClientWidth, mintMinimumClientWidth.ToString());
                }
                else if (blnForceRedraw)
                {
                    objWriter.WriteAttributeString(WGAttributes.MinimumClientWidth, "0");
                }
            }
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderScrollBars(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                // Renders client minimum size attributes.
                this.RenderMinimumClientSize(objContext, objWriter, true);
            }
        }

        /// <summary>
        /// Scrolls the specified child control into view on an auto-scroll enabled control.
        /// </summary>
        ///	<param name="objActiveControl">The child control to scroll into view. </param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void ScrollControlIntoView(Control objActiveControl)
        {
            if (((base.IsDescendant(objActiveControl) && this.AutoScroll) && (this.HScroll || this.VScroll)) && (((objActiveControl != null))))
            {
                this.InvokeMethod("Controls_ScrollIntoView", objActiveControl.ID, this.ID, "0", true);
            }
        }

        /// <summary>
        /// Sets the minimum size of the client.
        /// </summary>
        /// <param name="objProposedSize">Proposed size.</param>
        protected override void SetMinimumClientSize(Size objProposedSize)
        {
            if (this.AutoScroll)
            {
                // Get the client minimum size
                Size objMinimumClientSize = GetPreferredSize(objProposedSize, true);

                // Set the client minimum size
                mintMinimumClientWidth = objMinimumClientSize.Width;
                mintMinimumClientHeight = objMinimumClientSize.Height;
            }
            else
            {
                mintMinimumClientWidth = -1;
                mintMinimumClientHeight = -1;
            }
        }

        /// <summary>Sets the size of the auto-scroll margins.</summary>
        /// <param name="y">The <see cref="P:System.Drawing.Size.Height"></see> value. </param>
        /// <param name="x">The <see cref="P:System.Drawing.Size.Width"></see> value. </param>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void SetAutoScrollMargin(int x, int y)
        {
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new ScrollableControlRenderer(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the size of the auto scroll min.
        /// </summary>
        /// <value>
        /// The size of the auto scroll min.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size AutoScrollMinSize
        {
            get
            {
                return Size.Empty;
            }
            set
            {
            }
        }

        /// <summary>
        /// Indicates if to render padding attribute
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
        {
            return PaddingValue.Empty != objPadding;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the vertical scroll bar is visible.
        /// </summary>
        /// <value>true if the vertical scroll bar is visible; otherwise, false.</value>
        [System.ComponentModel.DefaultValue(true)]
        protected bool VScroll
        {
            get
            {
                return this.GetState(ControlState.VScroll);
            }
            set
            {
                // Set the new control state and update the control if value has changed
                if (this.SetStateWithCheck(ControlState.VScroll, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }

        }

        /// <summary>
        /// Gets or sets a value indicating whether the horizontal scroll bar is visible.
        /// </summary>
        /// <value>true if the horizontal scroll bar is visible; otherwise, false.</value>
        [System.ComponentModel.DefaultValue(true)]
        protected bool HScroll
        {
            get
            {
                return this.GetState(ControlState.HScroll);
            }
            set
            {
                // Set the new control state and update the control if value has changed
                if (this.SetStateWithCheck(ControlState.HScroll, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value>true if the container enables auto-scrolling; otherwise, false. The default value is false.</value>
        [SRCategory("CatLayout"), SRDescription("FormAutoScrollDescr"), DefaultValue(false), Localizable(true), ProxyBrowsable(true)]
        public virtual bool AutoScroll
        {
            get
            {
                return this.GetState(ControlState.AutoScroll);
            }
            set
            {
                // Set the auto scroll value and update control if value changed
                if (this.SetStateWithCheck(ControlState.AutoScroll, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.UpdateParams(AttributeType.Visual);
                }
            }

        }



        /// <summary>
        /// Gets or sets the type of the scroller.
        /// </summary>
        /// <value>
        /// The type of the scroller.
        /// </value>
        [SRCategory("CatLayout"), SRDescription("FormScrollerTypeDescr"), DefaultValue(ScrollerType.Default), Localizable(true), ProxyBrowsable(true)]
        public ScrollerType ScrollerType
        {
            get
            {
                return menmScrollerType;
            }
            set
            {
                if (menmScrollerType != value)
                {
                    menmScrollerType = value;

                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should render minimum client size].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [should render minimum client size]; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual bool ShouldRenderMinimumClientSize
        {
            get
            {
                // Should render width or height.
                return this.ShouldRenderMinimumClientWidth() || this.ShouldRenderMinimumClientHeight();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should render minimum client Width].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [should render minimum client Width]; otherwise, <c>false</c>.
        /// </value>        
        private bool ShouldRenderMinimumClientWidth()
        {
            // Render if not docked vertically or fill or if autoscroll.
            return (this.Dock != DockStyle.Fill && this.Dock != DockStyle.Top && this.Dock != DockStyle.Bottom) || this.AutoScroll;
        }

        /// <summary>
        /// Gets a value indicating whether [should render minimum client height].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [should render minimum client height]; otherwise, <c>false</c>.
        /// </value>        
        private bool ShouldRenderMinimumClientHeight()
        {
            // Render if not docked vertically or fill or if autoscroll.
            return (this.Dock != DockStyle.Fill && this.Dock != DockStyle.Left && this.Dock != DockStyle.Right) || this.AutoScroll;
        }

        /// <summary>
        /// Gets the dock padding settings for all edges of the control.
        /// </summary>
        /// <value>A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges"/> that represents the padding for all the edges of a docked control.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DockPaddingEdges DockPadding
        {
            get
            {
                DockPaddingEdges objDockPadding = this.GetValue<DockPaddingEdges>(ScrollableControl.DockPaddingProperty);

                // create a instance of padding data if needed
                if (objDockPadding == null)
                {
                    objDockPadding = new DockPaddingEdges(this);
                    this.SetValue<DockPaddingEdges>(ScrollableControl.DockPaddingProperty, objDockPadding);
                }
                return objDockPadding;
            }
        }

        /// <summary>
        /// Prevent serializing DockPadding if not required
        /// </summary>
        /// <returns>whether the store value differs form the default skin value.</returns>
        private bool ShouldSerializeDockPadding()
        {
            // Get value from property store.
            DockPaddingEdges objDockPadding = this.GetValue<DockPaddingEdges>(ScrollableControl.DockPaddingProperty);
            if (objDockPadding != null)
            {
                // Convert to padding value.
                Padding objPadding = new Padding(objDockPadding.Left, objDockPadding.Top, objDockPadding.Right, objDockPadding.Bottom);

                // Return whether the store value differs form the default skin value.
                return !this.Skin.Padding.Value.Equals(objPadding);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the horizontal padding.
        /// </summary>
        /// <value>The horizontal padding.</value>
        internal int HorizontalPadding
        {
            get
            {
                DockPaddingEdges objDockPadding = this.DockPadding;
                return objDockPadding.Left + objDockPadding.Right;
            }
        }

        /// <summary>
        /// Gets the vertical padding.
        /// </summary>
        /// <value>The vertical padding.</value>
        internal int VerticalPadding
        {
            get
            {
                DockPaddingEdges objDockPadding = this.DockPadding;
                return objDockPadding.Top + objDockPadding.Bottom;
            }
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        /// <value></value>
        protected override Size DisplaySize
        {
            get
            {
                // In case of auto scroll.
                if (this.AutoScroll)
                {
                    // Get preferred size.
                    return this.PreferredSize;
                }
                else
                {
                    return base.DisplaySize;
                }
            }
        }


        /// <summary>Gets or sets the size of the auto-scroll margin.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the height and width of the auto-scroll margin in pixels.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The <see cref="P:System.Drawing.Size.Height"></see> or <see cref="P:System.Drawing.Size.Width"></see> value assigned is less than 0. </exception>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatLayout"), Localizable(true), SRDescription("FormAutoScrollMarginDescr")]
        public Size AutoScrollMargin
        {
            get
            {
                return Size.Empty;
            }
            set
            {
            }
        }




        #endregion
    }


    #region ScrollableControlRenderer Class

    /// <summary>
    /// Provides support for rendering a scrollable control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollableControlRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollableControlRenderer"/> class.
        /// </summary>
        /// <param name="objScrollableControl">The scrollable control.</param>
        public ScrollableControlRenderer(ScrollableControl objScrollableControl)
            : base(objScrollableControl)
        {
        }



        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderControls(objContext, objGraphics);
        }


    }

    #endregion
}
