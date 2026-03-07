#region Using

using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System;

using System.Drawing;
using Gizmox.WebGUI.Forms.Layout;
using System.Globalization;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System.Text;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Client;
using System.Collections;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region ToolStrip Class

    /// <summary>
    /// <summary>Provides a container for Windows toolbar objects. </summary>
    /// </summary>
    [Skin(typeof(ToolStripSkin))]
    [MetadataTag(WGTags.ToolStrip)]
    [DefaultEvent("ItemClicked")]
    [SRDescription("DescriptionToolStrip")]
    [ComVisible(true)]
    [DefaultProperty("Items")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Serializable()]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ToolStrip), "ToolStrip_45.bmp")]
#else
    [ToolboxBitmap(typeof(ToolStrip), "ToolStrip.bmp")]
#endif
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ProxyComponent(typeof(ProxyToolStrip))]
    public class ToolStrip : ScrollableControl, IComponent, IDisposable
    {
        #region Members

        private static readonly SerializableProperty mobjToolStripItemCollectionProperty = SerializableProperty.Register("mobjToolStripItemCollection", typeof(ToolStripItemCollection), typeof(ToolStrip));
        private static readonly SerializableProperty mobjImageScalingSizeProperty = SerializableProperty.Register("mobjImageScalingSize", typeof(Size), typeof(ToolStrip), new SerializablePropertyMetadata());
        private static readonly SerializableProperty mobjImageListProperty = SerializableProperty.Register("mobjImageList", typeof(ImageList), typeof(ToolStrip));
        private static readonly SerializableProperty menmToolStripGripStyleProperty = SerializableProperty.Register("menmToolStripGripStyle", typeof(ToolStripGripStyle), typeof(ToolStrip), new SerializablePropertyMetadata(ToolStripGripStyle.Visible));
        private static readonly SerializableProperty mobjGripMarginProperty = SerializableProperty.Register("mobjGripMargin", typeof(Padding), typeof(ToolStrip));
        private static readonly SerializableProperty menmLayoutStyleProperty = SerializableProperty.Register("menmLayoutStyle", typeof(ToolStripLayoutStyle), typeof(ToolStrip), new SerializablePropertyMetadata(ToolStripLayoutStyle.StackWithOverflow));
        private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register("menmOrientation", typeof(Orientation), typeof(ToolStrip));
        private static readonly SerializableProperty mblnAllowMergeProperty = SerializableProperty.Register("mblnAllowMerge", typeof(bool), typeof(ToolStrip), new SerializablePropertyMetadata(true));
        private static readonly SerializableProperty mblnAllowItemReorderProperty = SerializableProperty.Register("mblnAllowItemReorder", typeof(bool), typeof(ToolStrip));
        private static readonly SerializableProperty mblnShowItemToolTipsProperty = SerializableProperty.Register("mblnShowItemToolTips", typeof(bool), typeof(ToolStrip));
        private static readonly SerializableProperty mblnStretchProperty = SerializableProperty.Register("mblnStretch", typeof(bool), typeof(ToolStrip));
        private static readonly SerializableProperty menmToolStripTextDirectionProperty = SerializableProperty.Register("menmToolStripTextDirection", typeof(ToolStripTextDirection), typeof(ToolStrip));
        private static readonly SerializableProperty mblnCanOverflowProperty = SerializableProperty.Register("mblnCanOverflow", typeof(bool), typeof(ToolStrip));

        internal static readonly SerializableEvent ItemClickedEvent = SerializableEvent.Register("ItemClicked", typeof(ToolStripItemClickedEventHandler), typeof(ToolStrip));
        private static readonly SerializableEvent LayoutStyleChangedEvent = SerializableEvent.Register("LayoutStyleChanged", typeof(EventHandler), typeof(ToolStrip));
        private static readonly SerializableEvent ItemAddedEvent = SerializableEvent.Register("ItemAdded", typeof(ToolStripItemEventHandler), typeof(ToolStrip));
        private static readonly SerializableEvent ItemRemovedEvent = SerializableEvent.Register("ItemRemoved", typeof(ToolStripItemEventHandler), typeof(ToolStrip));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary>
        public ToolStrip()
        {
            base.SuspendLayout();
            this.CanOverflow = true;
            this.TabStop = false;
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.Selectable, false);
            this.Dock = this.DefaultDock;
            this.AutoSize = true;
            this.CausesValidation = false;
            Size defaultSize = this.DefaultSize;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ShowItemToolTips = this.DefaultShowItemToolTips;
            this.ImageScalingSize = this.SkinImageScalingSize;
            base.ResumeLayout(true);
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class with the specified array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>s.</summary> 
        ///<param name="items">An array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> objects.</param>
        public ToolStrip(ToolStripItem[] items)
            : this()
        {
            this.Items.AddRange(items);
        }

        #endregion C'Tors

        #region Methods

        #region Should Serialize Methods

        private bool ShouldSerializeDefaultDropDownDirection()
        {
            return false;
        }

        private bool ShouldSerializeGripMargin()
        {
            return this.ContainsValue<Padding>(ToolStrip.mobjGripMarginProperty);
        }

        private bool ShouldSerializeLayoutStyle()
        {
            return this.ContainsValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty);
        }

        private bool ShouldSerializeRenderMode()
        {
            return false;
        }

        #endregion

        ///<summary>Specifies the visual arrangement for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is null.</returns> 
        ///<param name="layoutStyle">The visual arrangement to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual LayoutSettings CreateLayoutSettings(ToolStripLayoutStyle layoutStyle)
        {
            return null;
        }

        ///<summary>This method is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns> 
        ///<param name="point">A <see cref="T:System.Drawing.Point"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control GetChildAtPoint(Point point)
        {
            return null;
        }

        ///<summary>This method is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns> 
        ///<param name="skipValue">A <see cref="T:Gizmox.WebGUI.Forms.GetChildAtPointSkip"></see>  value.</param> 
        ///<param name="pt">A <see cref="T:System.Drawing.Point"></see> value.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue)
        {
            return null;
        }

        ///<summary>Returns the item located at the specified x- and y-coordinates of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> client area.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> located at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns> 
        ///<param name="y">The vertical coordinate, in pixels, from the top edge of the client area. </param> 
        ///<param name="x">The horizontal coordinate, in pixels, from the left edge of the client area. </param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem GetItemAt(int x, int y)
        {
            return null;
        }

        ///<summary>Returns the item located at the specified point in the client area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns> 
        ///<param name="point">The <see cref="T:System.Drawing.Point"></see> at which to search for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. </param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem GetItemAt(Point point)
        {
            return null;
        }

        ///<summary>Retrieves the next <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> from the specified reference point and moving in the specified direction.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is specified by the start parameter and is next in the order as specified by the direction parameter.</returns> 
        ///<param name="direction">One of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> that specifies the direction to move.</param> 
        ///<param name="start">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the reference point from which to begin the retrieval of the next item.</param> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value of the direction parameter is not one of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see>.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ToolStripItem GetNextItem(ToolStripItem start, ArrowDirection direction)
        {
            return null;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.BeginDrag"></see> event. </summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnBeginDrag(EventArgs e)
        {
        }

        /// <summary>
        /// Updates the strip attributes externally.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        internal void UpdateStripAttributes(AttributeType attributeType)
        {
            this.UpdateParams(attributeType);
        }

        /// <summary>
        /// Updates the orientation.
        /// </summary>
        /// <param name="objNewOrientation">The  new orientation.</param>
        private void UpdateOrientation(Orientation objNewOrientation)
        {
            if (objNewOrientation != this.Orientation)
            {
                this.menmOrientation = objNewOrientation;

                this.UpdateParams(AttributeType.Layout);
            }
        }

        /// <summary>
        /// Updates the layout style.
        /// </summary>
        /// <param name="enmNewDock">The new dock value.</param>
        private void UpdateLayoutStyle(DockStyle enmNewDock)
        {
            if (this.menmLayoutStyle != ToolStripLayoutStyle.HorizontalStackWithOverflow && this.menmLayoutStyle != ToolStripLayoutStyle.VerticalStackWithOverflow)
            {

                if ((enmNewDock == DockStyle.Left) || (enmNewDock == DockStyle.Right))
                {
                    this.UpdateOrientation(Orientation.Vertical);
                }
                else
                {
                    this.UpdateOrientation(Orientation.Horizontal);
                }

                this.OnLayoutStyleChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objProposedSize">Size of the obj proposed.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            Size objPreferredSize = objProposedSize;

            //Get tool strip's skin
            ToolStripSkin objToolStripSkin = this.Skin as ToolStripSkin;

            if (objToolStripSkin != null)
            {
                // Get tool strip's image scaling size.
                Size objImageScalingSize = this.ImageScalingSize;

                if (objImageScalingSize != null)
                {
                    // Get tool strip's dock style.
                    DockStyle enmDockStyle = this.Dock;
                    if (enmDockStyle != DockStyle.None)
                    {
                        // Get the preferred size with consideration to the ToolsStripItems
                        Size objPreferredHeightAndWidth = GetPreferredSize(objToolStripSkin, objProposedSize);

                        // Adjust sizes for different docking style
                        if (this.IsVerticalDocked(enmDockStyle))
                        {
                            // Adjust Height for vertical docking
                            objPreferredSize.Height = objPreferredHeightAndWidth.Height;
                        }
                        else if (this.IsHorizontalDocked(enmDockStyle))
                        {
                            // Adjust Width for Horizontal docking
                            objPreferredSize.Width = objPreferredHeightAndWidth.Width;
                        }
                        else if (this.Dock == DockStyle.Fill)
                        {
                            // Adjust Width and height
                            objPreferredSize = objPreferredHeightAndWidth;
                        }
                    }
                    else
                    {
                        // Get the preferred size with consideration to the ToolsStripItems
                        objPreferredSize = GetPreferredSize(objToolStripSkin, objProposedSize);

                        // Add grip width if necessary
                        if (this.GripStyle == ToolStripGripStyle.Visible)
                        {
                            objPreferredSize.Width += objToolStripSkin.HorizontalGripWidth;
                        }
                    }
                }
            }

            return objPreferredSize;
        }

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objImageScalingSize">Size of the obj image scaling.</param>
        /// <param name="objToolStripSkin">The obj tool strip skin.</param>
        /// <param name="objProposedSize">The obj size set as default or from designer.</param>
        /// <returns></returns>
        private Size GetPreferredSize(ToolStripSkin objToolStripSkin, Size objProposedSize)
        {
            Size objMaxWidthHeight = Size.Empty;

            //if there are no items, will return the default Height from the toolstripskin/users design
            if (this.Items.Count == 0)
            {
                if (this.Orientation == Forms.Orientation.Vertical)
                {
                    objMaxWidthHeight.Width = objProposedSize.Width;
                }
                else
                {
                    objMaxWidthHeight.Height = objProposedSize.Height;
                }
            }
            else
            {
                // Get the height of the heighest item
                foreach (ToolStripItem objToolStripItem in this.Items)
                {
                    if (objToolStripItem.Visible)
                    {
                        Size objSuggestedSize = Size.Empty;

                        if (!objToolStripItem.AutoSize)
                        {
                            // If item is not AUtoSize then take its given height
                            objSuggestedSize.Height = objToolStripItem.Height;
                            objSuggestedSize.Width = objToolStripItem.Width;
                        }
                        else
                        {
                            // Otherwise take its preferred size
                            objSuggestedSize = objToolStripItem.GetPreferredSize(objToolStripItem.Size);
                        }

                        if (this.Orientation == Forms.Orientation.Horizontal)
                        {
                            //Check if suggested height if higher than the current maximum height
                            if (objSuggestedSize.Height > objMaxWidthHeight.Height)
                            {
                                objMaxWidthHeight.Height = objSuggestedSize.Height;
                            }

                            // For Dock Fill and Dock none we accumelate the items widths
                            objMaxWidthHeight.Width += objSuggestedSize.Width;
                        }
                        else
                        {
                            //Check if suggested Width if higher than the current maximum Width
                            if (objSuggestedSize.Width > objMaxWidthHeight.Width)
                            {
                                objMaxWidthHeight.Width = objSuggestedSize.Width;
                            }

                            // For Dock Fill and Dock none we accumelate the items heights
                            objMaxWidthHeight.Height += objSuggestedSize.Height;
                        }
                    }
                }

                objMaxWidthHeight.Height += (objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Top) + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Bottom));
                objMaxWidthHeight.Width += (objToolStripSkin.Padding.Horizontal + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Left) + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Right));
            }

            return objMaxWidthHeight + this.Padding.Size;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.EndDrag"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnEndDrag(EventArgs e)
        {
        }

        /// <summary>Creates a default <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.ToolStrip"></see> instance.</summary>
        /// <returns>A <see cref="M:System.Windows.Forms.ToolStripButton.#ctor(System.String,Gizmox.WebGUI.Common.Resources.ResourceHandle,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
        /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is clicked.</param>
        /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        /// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
        protected internal virtual ToolStripItem CreateDefaultItem(string text, ResourceHandle image, EventHandler onClick)
        {
            if (text == "-")
            {
                return new ToolStripSeparator();
            }
            return new ToolStripButton(text, image, onClick);
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.ItemClicked"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data. </param>
        protected internal virtual void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            // Raise event if needed
            ToolStripItemClickedEventHandler objEventHandler = this.ItemClickedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
        protected internal virtual void OnItemAdded(ToolStripItemEventArgs e)
        {
            // Raise event if needed
            ToolStripItemEventHandler objEventHandler = this.ItemAddedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemRemoved"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
        protected internal virtual void OnItemRemoved(ToolStripItemEventArgs e)
        {
            // Raise event if needed
            ToolStripItemEventHandler objEventHandler = this.ItemRemovedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutCompleted"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnLayoutCompleted(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyleChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnLayoutStyleChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.LayoutStyleChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.RendererChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRendererChanged(EventArgs e)
        {
        }

        /// <summary>
        /// This method is not relevant for this class.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void ResetMinimumSize()
        {
        }

        ///<summary>Controls the return location of the focus.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void RestoreFocus()
        {
        }

        ///<summary>This method is not relevant for this class.</summary> 
        ///<param name="y">An <see cref="T:System.Int32"></see>.</param> 
        ///<param name="x">An <see cref="T:System.Int32"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void SetAutoScrollMargin(int x, int y)
        {
        }

        /// <summary>
        /// Resets the collection of displayed and overflow items after a layout is done.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void SetDisplayedItems()
        {
        }

        ///<summary>Enables you to change the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> whose <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property is to be changed. </param> 
        ///<param name="parent">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the parent of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> referred to by the item parameter. </param>
        protected static void SetItemParent(ToolStripItem item, ToolStrip parent)
        {
            item.ParentInternal = parent;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
        /// </returns>
        public override string ToString()
        {
            StringBuilder objStringBuilder = new StringBuilder(base.ToString());
            objStringBuilder.Append(", Name: ");
            objStringBuilder.Append(base.Name);
            objStringBuilder.Append(", Items: ").Append(this.Items.Count);
            return objStringBuilder.ToString();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                try
                {
                    base.SuspendLayout();
                    if (!this.Items.IsReadOnly)
                    {
                        for (int i = this.Items.Count - 1; i >= 0; i--)
                        {
                            this.Items[i].Dispose();
                        }
                        this.Items.Clear();
                    }
                }
                finally
                {
                    base.ResumeLayout(false);
                }
            }
            base.Dispose(blnDisposing);
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            if (mobjToolStripItemCollection != null)
            {
                // Unregister control children
                UnRegisterBatch(mobjToolStripItemCollection);
            }
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();
            if (mobjToolStripItemCollection != null)
            {
                // Unregister control children
                RegisterBatch(mobjToolStripItemCollection);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            for (int intIndex = 0; intIndex < this.Items.Count; ++intIndex)
            {
                if (this.Items[intIndex] != null && this.Items[intIndex].ParentInternal == this)
                    this.Items[intIndex].OnParentEnabledChanged(e);
            }
        }

        #region Render

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // Define an empty item.
            ToolStripItem objToolStripItem = null;

            // Get memebr id.
            string strMember = objEvent.Member;

            // Validate memebr id.
            if (!string.IsNullOrEmpty(strMember))
            {
                // Try parse an index out of member id.
                int intIndex = -1;
                if (int.TryParse(strMember, out intIndex))
                {
                    // Try getting too strip item from collection.
                    objToolStripItem = this.Items[intIndex - 1];
                }
            }

            // Check if an item has been found.
            if (objToolStripItem != null)
            {
                // Fire item's event.
                objToolStripItem.FireToolStripItemEvent(objEvent);
            }
            else
            {
                // Fire strip's event.
                base.FireEvent(objEvent);
            }
        }

        /// <summary>
        /// Gets the list of tags that client events are propogated to.
        /// </summary>
        /// <value>
        /// The client event propogated tags.
        /// </value>
        protected override string ClientEventsPropogationTags
        {
            get
            {
                return string.Format("WC:{0},WC:{1},WC:{2},WC:{3}", WGTags.ComboBox, WGTags.TextBox, WGTags.ToolStripItem, WGTags.ProgressBar);
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Loops all tool strip items.
            foreach (ToolStripItem objToolStripItem in this.Items)
            {
                // Render current tool strip item.
                objToolStripItem.RenderToolStripItem(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Pre-render control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            // Loops all tool strip items.
            foreach (ToolStripItem objToolStripItem in this.Items)
            {
                // PreRender current tool strip item.
                objToolStripItem.PreRenderToolStripItem(objContext, lngRequestID);
            }

            base.PreRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Posts the render control.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal override void PostRenderControl(IContext objContext, long lngRequestID)
        {
            base.PostRenderControl(objContext, lngRequestID);

            // Loops all tool strip items.
            foreach (ToolStripItem objToolStripItem in this.Items)
            {
                // PostRender current tool strip item.
                objToolStripItem.PostRenderToolStripItem(objContext, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render share focus attribute.
            objWriter.WriteAttributeString(WGAttributes.ShareFocus, "1");

            // Renders the wrap contents attribute.
            RenderWrapContentsAttribute(objWriter, false);

            // Renders the show grip attribute.
            RenderShowGripAttribute(objWriter, false);

            // Renders the image size attributes.
            RenderImageSizeAttributes(objWriter, false);

            // Renders the orientation attribute.
            RenderOrientationAttribute(objWriter);

            // Check if strip supports menu stickiness.
            if (this.SupportMenuStickiness)
            {
                objWriter.WriteAttributeString(WGAttributes.SupportMenuStickiness, "1");
            }
        }

        /// <summary>
        /// Renders the show grip attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowGripAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Get current grip style.
            ToolStripGripStyle enmToolStripGripStyle = this.GripStyle;

            // Check if show grip attribute should be rendered.
            if (enmToolStripGripStyle == ToolStripGripStyle.Hidden || blnForceRender)
            {
                // Redner the show grip attribute.
                objWriter.WriteAttributeString(WGAttributes.ShowGrip, enmToolStripGripStyle == ToolStripGripStyle.Hidden ? "0" : "1");
            }
        }

        /// <summary>
        /// Renders the image size attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderImageSizeAttributes(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Get current image scaling size.
            Size objImageScalingSize = this.ImageScalingSize;

            // Redner image size attributes.
            objWriter.WriteAttributeString(WGAttributes.ImageHeight, objImageScalingSize.Height.ToString(CultureInfo.InvariantCulture));
            objWriter.WriteAttributeString(WGAttributes.ImageWidth, objImageScalingSize.Width.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Renders the orientation attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderOrientationAttribute(IAttributeWriter objWriter)
        {
            // Redner Orientation attribute.
            objWriter.WriteAttributeString(WGAttributes.Orientation, Convert.ToInt32(this.Orientation).ToString());
        }

        /// <summary>
        /// Gets the size of the skin image scaling.
        /// </summary>
        /// <value>
        /// The size of the skin image scaling.
        /// </value>
        internal Size SkinImageScalingSize
        {
            get
            {
                ToolStripSkin objToolStripSkin = SkinFactory.GetSkin(this) as ToolStripSkin;
                if (objToolStripSkin != null)
                {
                    return objToolStripSkin.ImageScalingSize;
                }

                return Size.Empty;
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
                // Renders the wrap contents attribute.
                RenderWrapContentsAttribute(objWriter, true);

                // Renders the show grip attribute.
                RenderShowGripAttribute(objWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                // Renders the image size attributes.
                RenderImageSizeAttributes(objWriter, true);

                // Renders the orientation attribute.
                RenderOrientationAttribute(objWriter);
            }
        }

        /// <summary>
        /// Renders the wrap contents attribute.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderWrapContentsAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Check the can overflow attribute.
            bool blnCanOverflow = this.CanOverflow;

            // Check if the wrap contents attribute should be rendered.
            if (blnForceRender || !blnCanOverflow)
            {
                // Render the wrap contents attribute.
                objWriter.WriteAttributeString(WGAttributes.WrapContents, blnCanOverflow ? "1" : "0");
            }
        }

        #endregion

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            Type objOffspringType = Type.GetType(strOffspringTypeName);
            if (objOffspringType != null)
            {
                if (CommonUtils.IsTypeOrSubType(objOffspringType, typeof(ToolStripItem)))
                {
                    return this.Items;
                }
            }

            return base.GetComponentOffsprings(strOffspringTypeName);
        }

        #endregion Methods

        #region Events

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AutoSize"></see> property has changed.</summary>
        [EditorBrowsable(EditorBrowsableState.Always), SRCategory("CatPropertyChanged"), Browsable(true), SRDescription("ControlOnAutoSizeChangedDescr")]
        public event EventHandler AutoSizeChanged
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

        /// <summary>
        /// Occurs when the user begins to drag the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler BeginDrag;

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.CausesValidation"></see> property changes.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler CausesValidationChanged;

        /// <summary>
        /// This event is not relevant for this class.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event ControlEventHandler ControlAdded
        {
            add
            {
                base.ControlAdded += value;
            }
            remove
            {
                base.ControlAdded -= value;
            }
        }

        /// <summary>
        /// This event is not relevant for this class.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event ControlEventHandler ControlRemoved
        {
            add
            {
                base.ControlRemoved += value;
            }
            remove
            {
                base.ControlRemoved -= value;
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> property changes.
        /// </summary>
        [Browsable(false)]
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

        /// <summary>
        /// Occurs when the user stops dragging the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler EndDrag;

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ForeColor"></see> property changes.
        /// </summary>
        [Browsable(false)]
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

        /// <summary>
        /// Occurs when a new <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
        /// </summary>
        [SRDescription("ToolStripItemAddedDescr"), SRCategory("CatAppearance")]
        public event ToolStripItemEventHandler ItemAdded
        {
            add
            {
                this.AddHandler(ToolStrip.ItemAddedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStrip.ItemAddedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ItemAdded event.
        /// </summary>
        private ToolStripItemEventHandler ItemAddedHandler
        {
            get
            {
                return (ToolStripItemEventHandler)this.GetHandler(ToolStrip.ItemAddedEvent);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
        /// </summary>
        [SRDescription("ToolStripItemOnClickDescr"), SRCategory("CatAction")]
        public event ToolStripItemClickedEventHandler ItemClicked
        {
            add
            {
                this.AddHandler(ToolStrip.ItemClickedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStrip.ItemClickedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ItemClicked event.
        /// </summary>
        private ToolStripItemClickedEventHandler ItemClickedHandler
        {
            get
            {
                return (ToolStripItemClickedEventHandler)this.GetHandler(ToolStrip.ItemClickedEvent);
            }
        }


        /// <summary>
        /// Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is removed from the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
        /// </summary>
        [SRCategory("CatAppearance"), SRDescription("ToolStripItemRemovedDescr")]
        public event ToolStripItemEventHandler ItemRemoved
        {
            add
            {
                this.AddHandler(ToolStrip.ItemRemovedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStrip.ItemRemovedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ItemRemoved event.
        /// </summary>
        private ToolStripItemEventHandler ItemRemovedHandler
        {
            get
            {
                return (ToolStripItemEventHandler)this.GetHandler(ToolStrip.ItemRemovedEvent);
            }
        }

        ///<summary>Occurs when the layout of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is complete.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler LayoutCompleted;

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> property changes.
        /// </summary>
        [SRCategory("CatAppearance"), SRDescription("ToolStripLayoutStyleChangedDescr")]
        public event EventHandler LayoutStyleChanged
        {
            add
            {
                this.AddHandler(ToolStrip.LayoutStyleChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStrip.LayoutStyleChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the LayoutStyleChanged event.
        /// </summary>
        private EventHandler LayoutStyleChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStrip.LayoutStyleChangedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is painted.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event PaintEventHandler PaintGrip;

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property changes.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler RendererChanged;

        #endregion Events

        #region Properties

        #region Property Store

        private ToolStripItemCollection mobjToolStripItemCollection
        {
            get
            {
                return this.GetValue<ToolStripItemCollection>(ToolStrip.mobjToolStripItemCollectionProperty, null);
            }
            set
            {
                this.SetValue<ToolStripItemCollection>(ToolStrip.mobjToolStripItemCollectionProperty, value);
            }
        }

        private Size mobjImageScalingSize
        {
            get
            {
                return this.GetValue<Size>(ToolStrip.mobjImageScalingSizeProperty, SkinImageScalingSize);
            }
            set
            {
                this.SetValue<Size>(ToolStrip.mobjImageScalingSizeProperty, value);
            }
        }

        private ImageList mobjImageList
        {
            get
            {
                return this.GetValue<ImageList>(ToolStrip.mobjImageListProperty);
            }
            set
            {
                this.SetValue<ImageList>(ToolStrip.mobjImageListProperty, value);
            }
        }
        private bool mblnCanOverflow
        {
            get
            {
                return this.GetValue<bool>(ToolStrip.mblnCanOverflowProperty, false);
            }
            set
            {
                this.SetValue<bool>(ToolStrip.mblnCanOverflowProperty, value);
            }
        }

        private ToolStripTextDirection menmToolStripTextDirection
        {
            get
            {
                return this.GetValue<ToolStripTextDirection>(ToolStrip.menmToolStripTextDirectionProperty, ToolStripTextDirection.Inherit);
            }
            set
            {
                this.SetValue<ToolStripTextDirection>(ToolStrip.menmToolStripTextDirectionProperty, value);
            }
        }

        private bool mblnStretch
        {
            get
            {
                return this.GetValue<bool>(ToolStrip.mblnStretchProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStrip.mblnStretchProperty, value);
            }
        }

        private bool mblnShowItemToolTips
        {
            get
            {
                return this.GetValue<bool>(ToolStrip.mblnShowItemToolTipsProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStrip.mblnShowItemToolTipsProperty, value);
            }
        }

        private bool mblnAllowItemReorder
        {
            get
            {
                return this.GetValue<bool>(ToolStrip.mblnAllowItemReorderProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStrip.mblnAllowItemReorderProperty, value);
            }
        }


        private bool mblnAllowMerge
        {
            get
            {
                return this.GetValue<bool>(ToolStrip.mblnAllowMergeProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStrip.mblnAllowMergeProperty, value);
            }
        }

        private Orientation menmOrientation
        {
            get
            {
                return this.GetValue<Orientation>(ToolStrip.menmOrientationProperty);
            }
            set
            {
                this.SetValue<Orientation>(ToolStrip.menmOrientationProperty, value);
            }
        }

        private ToolStripLayoutStyle menmLayoutStyle
        {
            get
            {
                return this.GetValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty);
            }
            set
            {
                this.SetValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty, value);
            }
        }

        private Padding mobjGripMargin
        {
            get
            {
                return this.GetValue<Padding>(ToolStrip.mobjGripMarginProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStrip.mobjGripMarginProperty, value);
            }
        }

        private ToolStripGripStyle menmToolStripGripStyle
        {
            get
            {
                return this.GetValue<ToolStripGripStyle>(ToolStrip.menmToolStripGripStyleProperty);
            }
            set
            {
                this.SetValue<ToolStripGripStyle>(ToolStrip.menmToolStripGripStyleProperty, value);
            }
        }

        #endregion

        ///<summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary> 
        ///<returns>true to control drag-and-drop and item reordering through events that you implement; otherwise, false.</returns> 
        ///<exception cref="T:System.ArgumentException"> 
        ///  <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                if (value && this.AllowItemReorder)
                {
                    throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
                }
                base.AllowDrop = value;
            }
        }

        ///<summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled privately by the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary> 
        ///<returns>true to cause the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class to handle drag-and-drop and item reordering automatically; otherwise, false. The default value is false.</returns> 
        ///<exception cref="T:System.ArgumentException"> 
        ///  <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DefaultValue(false), SRDescription("ToolStripAllowItemReorderDescr"), SRCategory("CatBehavior")]
        public bool AllowItemReorder
        {
            get
            {
                return mblnAllowItemReorder;
            }
            set
            {
                if (mblnAllowItemReorder != value)
                {
                    if (this.AllowDrop && value)
                    {
                        throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
                    }
                    mblnAllowItemReorder = value;
                    // TODO: Update client 
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether multiple <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, and other types can be combined. </summary> 
        ///<returns>true if combining of types is allowed; otherwise, false. The default is false.</returns> 
        ///<filterpriority>2</filterpriority>
        [SRDescription("ToolStripAllowMergeDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool AllowMerge
        {
            get
            {
                return mblnAllowMerge;
            }
            set
            {
                if (mblnAllowMerge != value)
                {
                    mblnAllowMerge = value;
                    // TODO: Update client 
                }
            }
        }

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>true to automatically scroll; otherwise, false.</returns> 
        ///<exception cref="T:System.NotSupportedException">Automatic scrolling is not supported by <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> controls.</exception>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                throw new NotSupportedException(SR.GetString("ToolStripDoesntSupportAutoScroll"));
            }
        }

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Size"></see> value.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Size"></see> value.</returns>
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

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Point"></see> value.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point AutoScrollPosition
        {
            get
            {
                return Point.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a value indicating whether the control is automatically resized to display its entire contents.</summary> 
        ///<returns>true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        ///<summary>Gets or sets the background color for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripBackColorDescr")]
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

        /// <summary>Gets or sets a value indicating whether items in the <see cref="T:System.Windows.Forms.ToolStrip"></see> can be sent to an overflow menu.</summary>
        /// <returns>true to send <see cref="T:System.Windows.Forms.ToolStrip"></see> items to an overflow menu; otherwise, false. The default value is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ToolStripCanOverflowDescr"), SRCategory("CatLayout"), DefaultValue(true)]
        public bool CanOverflow
        {
            get
            {
                return mblnCanOverflow;
            }
            set
            {
                if (mblnCanOverflow != value)
                {
                    mblnCanOverflow = value;

                    // Update visual params.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> causes validation to be performed on any controls that require validation when it receives focus.</summary> 
        ///<returns>false in all cases.</returns>
        [Browsable(false), DefaultValue(false)]
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

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> representing the collection of controls contained within the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control.ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        ///<summary>Gets or sets the cursor that is displayed when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets the docking location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, indicating which borders are docked to the container.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns>
        protected virtual DockStyle DefaultDock
        {
            get
            {
                return DockStyle.Top;
            }
        }

        ///<summary>Gets or sets a value representing the default direction in which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is displayed relative to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
        [SRCategory("CatBehavior"), Browsable(false), SRDescription("ToolStripDefaultDropDownDirectionDescr")]
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ToolStripDropDownDirection DefaultDropDownDirection
        {
            get
            {
                return ToolStripDropDownDirection.Default;
            }
            set
            {
            }
        }

        ///<summary>Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns> 
        ///  <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
        protected virtual Padding DefaultGripMargin
        {
            get
            {
                return new Padding(2);
            }
        }


        ///<summary>Gets the internal spacing, in pixels, of the contents of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value of (0, 0, 1, 0).</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 0x19);
            }
        }

        ///<summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> by default.</summary> 
        ///<returns>true in all cases.</returns>
        protected virtual bool DefaultShowItemToolTips
        {
            get
            {
                return true;
            }
        }

        ///<summary>Retrieves the current display rectangle.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> area for item layout.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Rectangle DisplayRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is resized with its parent.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(DockStyle.Top)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                // Get current docking.
                DockStyle enmCurrentDock = this.Dock;

                if (value != enmCurrentDock)
                {
                    // Get current bounds.
                    Rectangle objBounds = this.Bounds;

                    // Update new docking value.
                    base.Dock = value;

                    // Check if change in docking reflects different orientation.
                    if ((this.IsHorizontalDocked(enmCurrentDock) && this.IsVerticalDocked(value)) ||
                        (this.IsHorizontalDocked(value) && this.IsVerticalDocked(enmCurrentDock)))
                    {
                        // Flip size.
                        this.Size = new Size(objBounds.Height, objBounds.Width);
                    }

                    this.UpdateLayoutStyle(value);

                    // Update strip.
                    this.Update();
                }
            }
        }

        ///<summary>Gets or sets the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> representing the foreground color.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false)]
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

        ///<summary>Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values. Possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Horizontal"></see> and <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Vertical"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public ToolStripGripDisplayStyle GripDisplayStyle
        {
            get
            {
                if (this.LayoutStyle != ToolStripLayoutStyle.HorizontalStackWithOverflow)
                {
                    return ToolStripGripDisplayStyle.Horizontal;
                }
                return ToolStripGripDisplayStyle.Vertical;
            }
        }

        ///<summary>Gets or sets the space around the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>, which represents the spacing.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripGripDisplayStyleDescr"), SRCategory("CatLayout")]
        public Padding GripMargin
        {
            get
            {
                return mobjGripMargin;
            }
            set
            {
                if (mobjGripMargin != value)
                {
                    mobjGripMargin = value;
                    // TODO: Update client 
                }
            }
        }

        /// <summary>
        /// Resets the grip margin.
        /// </summary>
        private void ResetGripMargin()
        {
            RemoveValue<Padding>(ToolStrip.mobjGripMarginProperty);
        }

        ///<summary>Gets the boundaries of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
        ///<returns>An object of type <see cref="T:System.Drawing.Rectangle"></see>, representing the move handle boundaries. If the boundaries are not visible, the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.GripRectangle"></see> property returns <see cref="F:System.Drawing.Rectangle.Empty"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle GripRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets or sets whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is visible or hidden.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripStyle.Visible"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DefaultValue(ToolStripGripStyle.Visible), SRDescription("ToolStripGripStyleDescr"), SRCategory("CatAppearance")]
        public ToolStripGripStyle GripStyle
        {
            get
            {
                return this.menmToolStripGripStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripGripStyle));
                }
                if (this.menmToolStripGripStyle != value)
                {
                    this.menmToolStripGripStyle = value;

                    // Update visual params.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStrip"></see> has children; otherwise, false. </returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasChildren
        {
            get
            {
                return base.HasChildren;
            }
        }

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>An instance of the <see cref="T:Gizmox.WebGUI.Forms.HScrollProperties"></see> class, which provides basic properties for an <see cref="T:Gizmox.WebGUI.Forms.HScrollBar"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HScrollProperties HorizontalScroll
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets or sets the image list that contains the image displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> item.</summary> 
        ///<returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripImageListDescr"), Browsable(false), SRCategory("CatAppearance"), DefaultValue((string)null)]
        public ImageList ImageList
        {
            get
            {
                return mobjImageList;
            }
            set
            {
                if (mobjImageList != value)
                {
                    mobjImageList = value;
                    // TODO: Update client
                }
            }
        }

        internal bool ShouldSerializeImageScalingSize()
        {
            return this.ImageScalingSize != this.SkinImageScalingSize;
        }

        /// <summary>Gets or sets the size, in pixels, of an image used on a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> value representing the size of the image, in pixels. The default is 16 x 16 pixels.</returns>
        [SRCategory("CatAppearance"), SRDescription("ToolStripImageScalingSizeDescr")]
        public Size ImageScalingSize
        {
            get
            {
                return mobjImageScalingSize;
            }
            set
            {
                if (mobjImageScalingSize != value)
                {
                    mobjImageScalingSize = value;

                    // Invalidates layout.
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the image size.
        /// </summary>
        private void ResetImageScalingSize()
        {
            this.ImageScalingSize = this.SkinImageScalingSize;
        }

        ///<summary>Gets a value indicating whether the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another. </summary> 
        ///<returns>true if the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another; otherwise, false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCurrentlyDragging
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public bool IsDropDown
        {
            get
            {
                return (this is ToolStripDropDown);
            }
        }

        ///<summary>Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [MergableProperty(false), SRCategory("CatData"), SRDescription("ToolStripItemsDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public virtual ToolStripItemCollection Items
        {
            get
            {
                if (this.mobjToolStripItemCollection == null)
                {
                    this.mobjToolStripItemCollection = CreateItemCollection();
                }

                return this.mobjToolStripItemCollection;
            }
        }

        /// <summary>
        /// Creates the item collection.
        /// </summary>
        /// <returns></returns>
        protected virtual ToolStripItemCollection CreateItemCollection()
        {
            return new ToolStripItemCollection(this, true);
        }

        ///<summary>Passes a reference to the cached <see cref="P:Gizmox.WebGUI.Forms.Control.LayoutEngine"></see> returned by the layout engine interface.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> that represents the cached layout engine returned by the layout engine interface.</returns> 
        ///<filterpriority>2</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual LayoutEngine LayoutEngine
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets or sets layout scheme characteristics.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.LayoutSettings"></see> representing the layout scheme characteristics.</returns> 
        ///<filterpriority>2</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutSettings LayoutSettings
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a value indicating how the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> lays out the items collection.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Table"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.StackWithOverflow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow"></see>, and <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values.</exception> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatLayout"), AmbientValue(0), SRDescription("ToolStripLayoutStyle")]
        public ToolStripLayoutStyle LayoutStyle
        {
            get
            {
                if (this.menmLayoutStyle == ToolStripLayoutStyle.StackWithOverflow)
                {
                    switch (this.Orientation)
                    {
                        case Orientation.Horizontal:
                            return ToolStripLayoutStyle.HorizontalStackWithOverflow;

                        case Orientation.Vertical:
                            return ToolStripLayoutStyle.VerticalStackWithOverflow;
                    }
                }
                return this.menmLayoutStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripLayoutStyle));
                }
                if (this.menmLayoutStyle != value)
                {
                    this.menmLayoutStyle = value;

                    switch (value)
                    {
                        case ToolStripLayoutStyle.Flow:
                            this.UpdateOrientation(Orientation.Horizontal);
                            break;
                        case ToolStripLayoutStyle.Table:
                            this.UpdateOrientation(Orientation.Horizontal);
                            break;
                        default:
                            if (value != ToolStripLayoutStyle.StackWithOverflow)
                            {
                                this.UpdateOrientation((value == ToolStripLayoutStyle.VerticalStackWithOverflow) ? Orientation.Vertical : Orientation.Horizontal);
                            }
                            else
                            {
                                this.UpdateLayoutStyle(this.Dock);
                            }
                            break;
                    }

                    this.OnLayoutStyleChanged(EventArgs.Empty);

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        ///<summary>Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>.</returns>
        [Browsable(false)]
        public Orientation Orientation
        {
            get
            {
                return this.menmOrientation;
            }
        }

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the overflow button for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> with overflow enabled.</summary> 
        ///<returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> with its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> and its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> value set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.Never"></see>.</returns> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripOverflowButton OverflowButton
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.ManagerRenderMode"></see>.</returns> 
        ///<exception cref="T:System.NotSupportedException"> 
        ///  <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.Custom"></see> without the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property being assigned to a new instance of <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see>.</exception> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value being set is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets or sets a value indicating whether ToolTips are to be displayed on <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> items. </summary> 
        ///<returns>true if ToolTips are to be displayed; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("ToolStripShowItemToolTipsDescr"), DefaultValue(true)]
        public bool ShowItemToolTips
        {
            get
            {
                return this.mblnShowItemToolTips;
            }
            set
            {
                if (this.mblnShowItemToolTips != value)
                {
                    this.mblnShowItemToolTips = value;
                    // TODO: Update client 
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is false.</returns>
        [SRCategory("CatLayout"), DefaultValue(false), SRDescription("ToolStripStretchDescr")]
        public virtual bool Stretch
        {
            get
            {
                return mblnStretch;
            }
            set
            {
                if (mblnStretch != value)
                {
                    mblnStretch = value;
                    // TODO: Update client 
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key.</summary> 
        ///<returns>true if the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("ControlTabStopDescr"), DefaultValue(false), DispId(-516)]
        public bool TabStop
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
        /// Gets a value indicating whether strip supports menu stickiness.
        /// </summary>
        /// <value><c>true</c> if [supports stickiness]; otherwise, <c>false</c>.</value>
        protected virtual bool SupportMenuStickiness
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets or sets the direction in which to draw text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripTextDirection.Horizontal"></see>. </returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripTextDirectionDescr"), DefaultValue(ToolStripTextDirection.Horizontal), SRCategory("CatAppearance")]
        public virtual ToolStripTextDirection TextDirection
        {
            get
            {
                ToolStripTextDirection inherit = menmToolStripTextDirection;
                if (inherit == ToolStripTextDirection.Inherit)
                {
                    inherit = ToolStripTextDirection.Horizontal;
                }
                return inherit;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripTextDirection));
                }
                menmToolStripTextDirection = value;
                // TODO: Update client 
            }
        }

        ///<summary>This property is not relevant for this class.</summary> 
        ///<returns>An instance of the <see cref="T:Gizmox.WebGUI.Forms.VScrollProperties"></see> class, which provides basic properties for a <see cref="T:Gizmox.WebGUI.Forms.VScrollBar"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VScrollProperties VerticalScroll
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the parent of this component.
        /// </summary>
        public override Component InternalParent
        {
            get
            {
                return base.InternalParent;
            }
            set
            {
                Component objInternalParent = base.InternalParent;
                if (objInternalParent != value)
                {
                    if (objInternalParent != null)
                    {
                        // Remove from DOM
                        foreach (ToolStripItem objItem in this.Items)
                        {
                            ToolStripMenuItem objMenuItem = objItem as ToolStripMenuItem;
                            if (objMenuItem != null)
                            {
                                objMenuItem.RemovingFromDOM();
                            }
                            else
                            {
                                ToolStripDropDownItem objToolStripDropDownItem = objItem as ToolStripDropDownItem;
                                if (objToolStripDropDownItem != null)
                                {
                                    foreach (ToolStripItem objDropDownMenuItem in objToolStripDropDownItem.DropDownItems)
                                    {
                                        objMenuItem = objDropDownMenuItem as ToolStripMenuItem;
                                        if (objMenuItem != null)
                                        {
                                            objMenuItem.RemovingFromDOM();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Update parent
                    base.InternalParent = value;

                    if (value != null)
                    {
                        // Attached To DOM
                        foreach (ToolStripItem objItem in this.Items)
                        {
                            ToolStripMenuItem objMenuItem = objItem as ToolStripMenuItem;
                            if (objMenuItem != null)
                            {
                                objMenuItem.AttachedToDOM();
                            }
                            else
                            {
                                ToolStripDropDownItem objToolStripDropDownItem = objItem as ToolStripDropDownItem;
                                if (objToolStripDropDownItem != null)
                                {
                                    foreach (ToolStripItem objDropDownMenuItem in objToolStripDropDownItem.DropDownItems)
                                    {
                                        objMenuItem = objDropDownMenuItem as ToolStripMenuItem;
                                        if (objMenuItem != null)
                                        {
                                            objMenuItem.AttachedToDOM();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Resizable indication is disabled for ContextMenuStrip
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ResizableOptions Resizable
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        #endregion Properties
    }

    #endregion ToolStrip Class

    #region StatusStrip

    [MetadataTag(WGTags.StatusStrip)]
    [Skin(typeof(StatusStripSkin))]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [SRDescription("DescriptionStatusStrip")]
    [Serializable()]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(StatusStrip), "StatusStrip_45.bmp")]
#else
    [ToolboxBitmap(typeof(StatusStrip), "StatusStrip.bmp")]
#endif
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class StatusStrip : ToolStrip
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> class. </summary>
        public StatusStrip() : base()
        {
            base.SuspendLayout();
            this.CanOverflow = false;
            this.LayoutStyle = ToolStripLayoutStyle.Table;
            this.GripStyle = ToolStripGripStyle.Hidden;
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Stretch = true;
            base.ResumeLayout(true);
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Provides custom table layout for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnSpringTableLayoutCore()
        {
        }

        /// <summary>
        /// Creates the default item.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="objImage">The obj image.</param>
        /// <param name="objOnClick">The obj on click.</param>
        /// <returns></returns>
        protected internal override ToolStripItem CreateDefaultItem(string strText, ResourceHandle objImage, EventHandler objOnClick)
        {
            return new ToolStripStatusLabel(strText, objImage, objOnClick);
        }

        #endregion Methods

        #region Events

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false)]
        public event EventHandler PaddingChanged
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

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public override ToolStripItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
        [Browsable(false), DefaultValue(false), SRDescription("ToolStripCanOverflowDescr"), SRCategory("CatLayout")]
        public bool CanOverflow
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

        ///<summary>Gets which borders of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> are docked to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns>
        protected override DockStyle DefaultDock
        {
            get
            {
                return DockStyle.Bottom;
            }
        }

        ///<summary>Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> from the edges of the form.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
        protected override Padding DefaultPadding
        {
            get
            {
                StatusStripSkin objSkin = this.Skin as StatusStripSkin;
                if (objSkin != null)
                {
                    if (base.Orientation == Orientation.Vertical)
                    {
                        Padding objPadding = objSkin.VerticalOrientationPadding;
                        objPadding.Bottom = this.DefaultSize.Height;
                        return objPadding;
                    }
                    else
                    {
                        return objSkin.HorizontalOrientationPadding;
                    }
                }

                if (base.Orientation != Orientation.Horizontal)
                {
                    return new Padding(1, 3, 1, this.DefaultSize.Height);
                }
                if (this.RightToLeft == RightToLeft.No)
                {
                    return new Padding(1, 0, 14, 0);
                }
                return new Padding(14, 0, 1, 0);
            }
        }

        /// <summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.StatusStrip"></see> by default.</summary>
        /// <returns>false in all cases.</returns>
        protected override bool DefaultShowItemToolTips
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets the size, in pixels, of the <see cref="T:System.Windows.Forms.StatusStrip"></see> when it is first created.</summary>
        /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> constructor representing the size of the <see cref="T:System.Windows.Forms.StatusStrip"></see>, in pixels.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 0x16);
            }
        }

        ///<summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> is resized with its parent.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
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

        /// <summary>Gets or sets the visibility of the grip used to reposition the control.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
        [DefaultValue(ToolStripGripStyle.Hidden)]
        public ToolStripGripStyle GripStyle
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

        /// <summary>Gets or sets a value indicating how the <see cref="T:System.Windows.Forms.StatusStrip"></see> lays out the items collection.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripLayoutStyle.Table"></see>.</returns>
        [DefaultValue(ToolStripLayoutStyle.Table)]
        public ToolStripLayoutStyle LayoutStyle
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

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        public Padding Padding
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

        ///<summary>Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
        ///<returns>true if ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>; otherwise, false. The default is false.</returns>
        [DefaultValue(false), SRDescription("ToolStripShowItemToolTipsDescr"), SRCategory("CatBehavior")]
        public bool ShowItemToolTips
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

        ///<summary>Gets the boundaries of the sizing handle (grip) for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the grip boundaries.</returns>
        [Browsable(false)]
        public Rectangle SizeGripBounds
        {
            get
            {
                if (!this.SizingGrip)
                {
                    return Rectangle.Empty;
                }
                Size size = base.Size;
                int height = Math.Min(this.DefaultSize.Height, size.Height);
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    return new Rectangle(0, size.Height - height, 12, height);
                }
                return new Rectangle(size.Width - 12, size.Height - height, 12, height);
            }
        }

        ///<summary>Gets or sets a value indicating whether a sizing handle (grip) is displayed in the lower-right corner of the control.</summary> 
        ///<returns>true if a grip is displayed; otherwise, false. The default is true.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its container.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is true.</returns>
        [SRCategory("CatLayout"), SRDescription("ToolStripStretchDescr"), DefaultValue(true)]
        public bool Stretch
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

        #endregion Properties
    }

    #endregion

    #region ToolStripDropDown Class

    /// <summary>
    /// 	<summary>Represents a control that allows the user to select a single item from a list that is displayed when the user clicks a <see cref="T:System.Windows.Forms.ToolStripDropDownButton"></see>. Although <see cref="T:System.Windows.Forms.ToolStripDropDownMenu"></see> and <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> replace and add functionality to the <see cref="T:System.Windows.Forms.Menu"></see> control of previous versions, <see cref="T:System.Windows.Forms.Menu"></see> is retained for both backward compatibility and future use if you choose.</summary>
    /// </summary>
    [ComVisible(true)]
    [Serializable()]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ToolboxItem(false)]
    [Skin(typeof(ToolStripDropDownSkin))]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripDropDown : ToolStrip
    {
        #region Classes

        #region ToolStripDropDownHeaderPanel Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        [ToolboxItem(false)]
        public class ToolStripDropDownHeaderPanel : Panel
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ToolStripDropDownHeaderPanel"/> class.
            /// </summary>
            public ToolStripDropDownHeaderPanel()
            {
                this.Size = Size.Empty;
                this.Dock = DockStyle.Left;
            }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// Gets/Sets the controls docking style
            /// </summary>
            public override DockStyle Dock
            {
                get
                {
                    return base.Dock;
                }
                set
                {
                    // Validate value and throw an exception if needed.
                    if (value != DockStyle.None && value != DockStyle.Fill)
                    {
                        base.Dock = value;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Invalid docking value '{0}' for a tool strip drop down header panel."));
                    }
                }
            }

            #endregion Properties
        }

        #endregion

        #region ToolStripDropDownContentPanel Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        [ToolboxItem(false)]
        private class ToolStripDropDownContentPanel : Panel
        {
            #region Fields

            private ToolStripDropDown mobjOwnerToolStripDropDown = null;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ToolStripDropDownContentPanel"/> class.
            /// </summary>
            /// <param name="objOwnerToolStripDropDown">The obj owner tool strip drop down.</param>
            public ToolStripDropDownContentPanel()
            {
                this.AutoScroll = true;
                this.ScrollerType = Forms.ScrollerType.Arrows;
                this.VScroll = true;

            }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// Gets or sets the control custom style.
            /// </summary>
            public override string CustomStyle
            {
                get
                {
                    return "ToolStripDropDownContentPanel";
                }
                set
                {
                    base.CustomStyle = value;
                }
            }

            /// <summary>
            /// Gets or sets the owner tool strip drop down.
            /// </summary>
            /// <value>
            /// The owner tool strip drop down.
            /// </value>
            internal ToolStripDropDown OwnerToolStripDropDown
            {
                get { return mobjOwnerToolStripDropDown; }
                set { mobjOwnerToolStripDropDown = value; }
            }

            #endregion Properties

            #region Methods

            /// <summary>
            /// Renders the controls sub tree
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            /// <param name="lngRequestID"></param>
            protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
            {
                // Check if have a valid owner tool strip drop down.
                if (mobjOwnerToolStripDropDown != null)
                {
                    // Get owner tool strip drop down's items.
                    ToolStripItemCollection objItems = mobjOwnerToolStripDropDown.Items;
                    if (objItems != null)
                    {
                        // Loop all owner tool strip drop down's items.
                        foreach (ToolStripItem objToolStripItem in objItems)
                        {
                            // Check if item is visible.
                            if (objToolStripItem.Visible)
                            {
                                // Render current item.
                                objToolStripItem.RenderToolStripItem(objContext, objWriter, lngRequestID);
                            }
                        }
                    }
                }
            }

           /// <summary>
            /// Get maximum width of image over all items
            /// </summary>
            /// <returns></returns>
            internal int GetContentImageMaxWidth()
            {
                // Define an integer that will hold items maximal image width.
                int intItemsMaxImageWidth = 0;

                // Check if have a valid owner tool strip drop down.
                if (mobjOwnerToolStripDropDown != null)
                {
                    // max image width default to ImageScaling of parent ToolStrip
                    intItemsMaxImageWidth = mobjOwnerToolStripDropDown.ImageScalingSize.Width;

                    // Get owner tool strip drop down's items.
                    ToolStripItemCollection objItems = mobjOwnerToolStripDropDown.Items;
                    if (objItems != null)
                    {
                        // Start from zero max width if there are items.
                        intItemsMaxImageWidth = 0;

                        // Loop all owner tool strip drop down's items.
                        foreach (ToolStripItem objToolStripItem in objItems)
                        {
                            // Check if current item is visible.
                            if (objToolStripItem.Visible)
                            {

                                // Get item's prefered size.
                                int intToolStripItemImageWidth = objToolStripItem.AutoSize ? objToolStripItem.GetPreferredSizeByImage(Size.Empty).Width : mobjOwnerToolStripDropDown.ImageScalingSize.Width;

                                // Check if current item's preffered width is bigger then the biggest one found until now.
                                if (intToolStripItemImageWidth > intItemsMaxImageWidth)
                                {
                                    // Preserve current item's preffered width.
                                    intItemsMaxImageWidth = intToolStripItemImageWidth;
                                }
                            }
                        }
                    }
                }

                return intItemsMaxImageWidth;
            }

            /// <summary>
            /// Gets the size of the content preffered.
            /// </summary>
            /// <returns></returns>
            internal Size GetContentPrefferedSize()
            {
                // Define initialized size.
                int intPrefferedWidth = 0;
                int intPrefferedHeight = 0;

                // Get the menu item's skin
                ToolStripMenuItemSkin objToolStripMenuItemSkin = SkinFactory.GetSkin(this, typeof(ToolStripMenuItemSkin)) as ToolStripMenuItemSkin;

                // Check if have a valid owner tool strip drop down.
                if (mobjOwnerToolStripDropDown != null)
                {
                    // Get owner tool strip drop down's items.
                    ToolStripItemCollection objItems = mobjOwnerToolStripDropDown.Items;
                    if (objItems != null)
                    {

                        // Define an integer that will hold items maximal width.
                        int intItemsMaxWidth = 0;

                        // Loop all owner tool strip drop down's items.
                        foreach (ToolStripItem objToolStripItem in objItems)
                        {
                            // Check if current item is visible.
                            if (objToolStripItem.Visible)
                            {

                                // Get item's prefered size.
                                Size objToolStripItemSize = objToolStripItem.AutoSize ? objToolStripItem.GetPreferredSize(Size.Empty) : objToolStripItem.Size;

                                // Check if current item's preffered width is bigger then the biggest one found until now.
                                if (objToolStripItemSize.Width > intItemsMaxWidth)
                                {
                                    // Preserve current item's preffered width.
                                    intItemsMaxWidth = objToolStripItemSize.Width;
                                }

                                // Sum current item's preffered height.
                                intPrefferedHeight += objToolStripItemSize.Height;
                            }
                        }

                        // Add items maximal width to preffered width.
                        intPrefferedWidth += intItemsMaxWidth;

                        if (objToolStripMenuItemSkin != null)
                        {
                            // Check direction
                            bool blnRightToLeft = this.Context == null ? false : this.Context.RightToLeft;

                            // Get image width according to the correct direction
                            if (blnRightToLeft)
                            {
                                intPrefferedWidth += objToolStripMenuItemSkin.MenuItemImageWidthRTL;
                            }
                            else
                            {
                                intPrefferedWidth += objToolStripMenuItemSkin.MenuItemImageWidthLTR;
                            }


                            // Increase preffered size by text image gap size.
                            intPrefferedWidth += objToolStripMenuItemSkin.TextImageGapSize;

                            intPrefferedWidth += objToolStripMenuItemSkin.TextArrowGapSize;

                            // Get arrow image width according to the correct direction
                            if (blnRightToLeft)
                            {
                                intPrefferedWidth += objToolStripMenuItemSkin.MenuItemArrowImageWidthRTL;
                            }
                            else
                            {
                                intPrefferedWidth += objToolStripMenuItemSkin.MenuItemArrowImageWidthLTR;
                            }
                        }
                    }
                }

                // Add extra pixels to calculated max width of image to account for browser 'quirks' during alignment.
                if (objToolStripMenuItemSkin != null)
                {
                    intPrefferedWidth += objToolStripMenuItemSkin.MenuItemImageExtraWidth;
                }

                return new Size(intPrefferedWidth, intPrefferedHeight);
            }

            #endregion Methods
        }

        #endregion

        #region ToolStripDropDownForm Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        protected internal class ToolStripDropDownForm : Form
        {
            #region Properties

            /// <summary>
            /// Gets the owner tool strip item.
            /// </summary>
            /// <value>The owner tool strip item.</value>
            private ToolStripItem OwnerToolStripItem
            {
                get
                {
                    // Check if the cached owner tool strip not allready assigned.
                    if (mobjOwnerToolStripItem == null)
                    {
                        if (mobjOwnerToolStripDropDown != null)
                        {
                            // Get owner item.
                            mobjOwnerToolStripItem = mobjOwnerToolStripDropDown.OwnerItem;
                        }
                    }

                    return mobjOwnerToolStripItem;
                }
            }

            #endregion

            #region Members

            private static readonly SerializableProperty mobjOwnerToolStripDropDownProperty = SerializableProperty.Register("mobjOwnerToolStripDropDown", typeof(ToolStripDropDown), typeof(ToolStripDropDownForm));
            private static readonly SerializableProperty mobjOwnerToolStripItemProperty = SerializableProperty.Register("mobjOwnerToolStripItem", typeof(ToolStripItem), typeof(ToolStripDropDownForm));

            private ToolStripDropDownContentPanel mobjToolStripDropDownContentPanel;

            #endregion

            #region C'tors

            /// <summary>
            /// Initializes a new instance of the <see cref="ToolStripDropDownForm"/> class.
            /// </summary>
            /// <param name="objOwnerToolStripDropDown">The obj owner tool strip drop down.</param>
            public ToolStripDropDownForm(ToolStripDropDown objOwnerToolStripDropDown)
            {
                this.InitializeComponent();

                // Preserve owner tool strip drop down both locally and in content panel.
                mobjToolStripDropDownContentPanel.OwnerToolStripDropDown = this.mobjOwnerToolStripDropDown = objOwnerToolStripDropDown;

                if (mobjOwnerToolStripDropDown != null)
                {
                    // Add the header panel from the owner tool strip drop to local controls collection.
                    this.Controls.Add(mobjOwnerToolStripDropDown.HeaderPanel);

                    // Register owner ToolStripDropDown ItemAdded + ItemRemoved event to update preferred size.
                    this.mobjOwnerToolStripDropDown.ItemAdded += new ToolStripItemEventHandler(OnOwnerDropDownItemCollectionChanged);
                    this.mobjOwnerToolStripDropDown.ItemRemoved += new ToolStripItemEventHandler(OnOwnerDropDownItemCollectionChanged);

                    // Copy toolstrip drop down properties to the form that will be open
                    this.Font = objOwnerToolStripDropDown.Font;
                    this.BackColor = objOwnerToolStripDropDown.BackColor;
                    this.ForeColor = objOwnerToolStripDropDown.ForeColor;
                }

                // The dropdown form inherits multi-Theme from the parent toolstrip
                if (this.OwnerToolStripItem != null && this.OwnerToolStripItem.Parent != null)
                    this.Theme = this.OwnerToolStripItem.Parent.Theme;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjToolStripDropDownContentPanel = new ToolStripDropDownContentPanel();
                this.SuspendLayout();
                // 
                // mobjToolStripDropDownContentPanel
                // 
                this.mobjToolStripDropDownContentPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjToolStripDropDownContentPanel.Location = new System.Drawing.Point(100, 0);
                this.mobjToolStripDropDownContentPanel.Name = "mobjToolStripDropDownContentPanel";
                this.mobjToolStripDropDownContentPanel.Size = new System.Drawing.Size(577, 506);
                this.mobjToolStripDropDownContentPanel.TabIndex = 1;
                // 
                // Form1
                // 
                this.Controls.Add(this.mobjToolStripDropDownContentPanel);
                this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
                this.Size = new System.Drawing.Size(677, 506);
                this.CustomStyle = "ToolStripDropDown";
                this.MinimumSize = new Size(80, 0);
                this.Text = "Form1";
                this.ResumeLayout(false);

            }

            /// <summary>
            /// Called when [owner drop down item collection changed].
            /// </summary>
            /// <param name="objSender">The obj sender.</param>
            /// <param name="objArgs">The <see cref="ToolStripItemEventArgs"/> instance containing the event data.</param>
            void OnOwnerDropDownItemCollectionChanged(object objSender, ToolStripItemEventArgs objArgs)
            {
                this.InitializePrefferedSize();
            }



            /// <summary>
            /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
            /// </summary>
            /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                // Initializes a preffered size.
                InitializePrefferedSize();
            }

            /// <summary>
            /// Initializes a preffered size.
            /// </summary>
            private void InitializePrefferedSize()
            {
                // Define initialized size.
                int intPrefferedWidth = 0;
                int intPrefferedHeight = 0;

                // Get toolstrip drop-down skin
                ToolStripDropDownSkin objSkin = SkinFactory.GetSkin(this, typeof(ToolStripDropDownSkin)) as ToolStripDropDownSkin;

                if (objSkin != null)
                {
                    //Add popup offset to toolstrip drop-down's size
                    intPrefferedHeight += objSkin.DropDownOffsetHeight;
                    intPrefferedWidth += objSkin.DropDownOffsetWidth;
                }

                // If content drop-down panel exists..
                if (this.mobjToolStripDropDownContentPanel != null)
                {
                    // Consider its preferred size. 
                    Size objContentPrefferedSize = mobjToolStripDropDownContentPanel.GetContentPrefferedSize();
                    if (objContentPrefferedSize != null)
                    {
                        intPrefferedWidth += objContentPrefferedSize.Width;
                        intPrefferedHeight += objContentPrefferedSize.Height;
                    }
                }

                // Consider parent toolstrip docking
                if (this.mobjOwnerToolStripDropDown != null && this.mobjOwnerToolStripDropDown.HeaderPanel != null)
                {
                    // Consider parent toolstrip docking
                    switch (this.mobjOwnerToolStripDropDown.HeaderPanel.Dock)
                    {
                        case DockStyle.Bottom:
                        case DockStyle.Top:
                            intPrefferedHeight += this.mobjOwnerToolStripDropDown.HeaderPanel.Height;
                            break;
                        case DockStyle.Left:
                        case DockStyle.Right:
                            intPrefferedWidth += this.mobjOwnerToolStripDropDown.HeaderPanel.Width;
                            break;
                    }
                }

                // Check if a proper size may be assigned.
                if (intPrefferedHeight > 0 && intPrefferedWidth > 0)
                {
                    this.Size = new Size(intPrefferedWidth, intPrefferedHeight);
                }
            }

            #region Render

            /// <summary>
            /// Renders the image size attributes.
            /// </summary>
            /// <param name="objWriter">The writer.</param>
            /// /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
            private void RenderImageSizeAttributes(IAttributeWriter objWriter)
            {
                //setting image default size from the owner skin
                if (this.mobjOwnerToolStripDropDown != null)
                {
                    // Get current image scaling size.
                    Size objImageScalingSize = this.mobjOwnerToolStripDropDown.ImageScalingSize;

                    // Render image size attributes.
                    objWriter.WriteAttributeString(WGAttributes.ImageHeight, objImageScalingSize.Height.ToString(CultureInfo.InvariantCulture));
                    objWriter.WriteAttributeString(WGAttributes.ImageWidth, objImageScalingSize.Width.ToString(CultureInfo.InvariantCulture));

                    // Render image max width attribute
                    objWriter.WriteAttributeString(WGAttributes.MenuItemImageMaxWidth, this.mobjToolStripDropDownContentPanel.GetContentImageMaxWidth().ToString(CultureInfo.InvariantCulture));
                    
                }
            }

            /// <summary>
            /// Renders the forms attribute
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                base.RenderAttributes(objContext, objWriter);

                //Render default image size
                RenderImageSizeAttributes(objWriter);

                // Get owner tool strip item.
                ToolStripItem objOwnerToolStripItem = this.OwnerToolStripItem;
                if (objOwnerToolStripItem != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.OwnerID, string.Format("{0}_{1}", objOwnerToolStripItem.OwnerID.ToString(), objOwnerToolStripItem.MemberID.ToString()));

                    // Check if owner tool strip item's owner strip is a tool strip drop down. 
                    if (objOwnerToolStripItem.Owner is ToolStripDropDown)
                    {
                        // Check if owner tool strip item is tool strip drop down item.
                        ToolStripDropDownItem objToolStripDropDownItem = objOwnerToolStripItem as ToolStripDropDownItem;
                        if (objToolStripDropDownItem != null)
                        {
                            // Check if owner tool strip drop down item has drop down items.
                            if (objToolStripDropDownItem.DropDown.Items.Count > 0)
                            {
                                // Render share focus attribute.
                                objWriter.WriteAttributeString(WGAttributes.ShareFocus, "1");
                            }
                        }
                    }
                }

                //Rendering indication for toolstrip menu.
                objWriter.WriteAttributeString(WGAttributes.ToolStripDropDown, "1");

                // Render owner drop down AutoClose attribute if it is false.
                if (!this.mobjOwnerToolStripDropDown.AutoClose)
                {
                    objWriter.WriteAttributeString(WGAttributes.AutoClose, "0");
                }
            }

            /// <summary>
            /// Fires an event.
            /// </summary>
            /// <param name="objEvent">event.</param>
            protected override void FireEvent(IEvent objEvent)
            {
                // Define an empty item.
                ToolStripItem objToolStripItem = null;

                // Validate owner tool  strip drop down.
                if (mobjOwnerToolStripDropDown != null)
                {
                    // Get memebr id.
                    string strMember = objEvent.Member;

                    // Validate memebr id.
                    if (!string.IsNullOrEmpty(strMember))
                    {
                        // Try parse an index out of member id.
                        int intIndex = -1;
                        if (int.TryParse(strMember, out intIndex))
                        {
                            // Try getting tool strip item out of owner tool  strip drop down.
                            objToolStripItem = mobjOwnerToolStripDropDown.Items[intIndex - 1];
                        }
                    }
                }

                // Check if an item has been found.
                if (objToolStripItem != null)
                {
                    // Fire item's event.
                    objToolStripItem.FireToolStripItemEvent(objEvent);
                }
                else
                {
                    // Fire strip's event.
                    base.FireEvent(objEvent);
                }
            }

            #endregion

            #endregion

            #region Property Store

            private ToolStripDropDown mobjOwnerToolStripDropDown
            {
                get
                {
                    return this.GetValue<ToolStripDropDown>(ToolStripDropDownForm.mobjOwnerToolStripDropDownProperty, null);
                }
                set
                {
                    this.SetValue<ToolStripDropDown>(ToolStripDropDownForm.mobjOwnerToolStripDropDownProperty, value);
                }
            }

            private ToolStripItem mobjOwnerToolStripItem
            {
                get
                {
                    return this.GetValue<ToolStripItem>(ToolStripDropDownForm.mobjOwnerToolStripItemProperty, null);
                }
                set
                {
                    this.SetValue<ToolStripItem>(ToolStripDropDownForm.mobjOwnerToolStripItemProperty, value);
                }
            }

            #endregion
        }

        #endregion

        #endregion

        #region C'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> class.
        /// </summary>
        public ToolStripDropDown()
        {
            this.mblnAutoClose = true;
            this.mblnAutoSize = true;
            base.SuspendLayout();
            this.Initialize();
            base.ResumeLayout(false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDown"/> class.
        /// </summary>
        /// <param name="objOwnerItem">The owner item.</param>
        internal ToolStripDropDown(ToolStripItem objOwnerItem) : this()
        {
            this.mobjOwnerItem = objOwnerItem;

            // ImageScalingSize is inherited from parent
            if (objOwnerItem != null)
            {
                ToolStrip objParent = objOwnerItem.Parent as ToolStrip;
                if (objParent != null)
                    this.ImageScalingSize = objParent.ImageScalingSize;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDown"/> class.
        /// </summary>
        /// <param name="objOwnerItem">The owner item.</param>
        /// <param name="blnIsAutoGenerated">if set to <c>true</c> [is auto generated].</param>
        internal ToolStripDropDown(ToolStripItem objOwnerItem, bool blnIsAutoGenerated) : this(objOwnerItem)
        {
            this.mblnIsAutoGenerated = blnIsAutoGenerated;
        }

        #endregion C'Tors

        #region Members

        private static readonly SerializableProperty mblnAutoCloseProperty = SerializableProperty.Register("mblnAutoClose", typeof(bool), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mblnAutoSizeProperty = SerializableProperty.Register("mblnAutoSize", typeof(bool), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mblnIsAutoGeneratedProperty = SerializableProperty.Register("mblnIsAutoGenerated", typeof(bool), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mobjOwnerItemProperty = SerializableProperty.Register("mobjOwnerItem", typeof(ToolStripItem), typeof(ToolStripDropDown));
        private static readonly SerializableProperty menmCloseReasonProperty = SerializableProperty.Register("menmCloseReason", typeof(ToolStripDropDownCloseReason), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mobjSourceComponentProperty = SerializableProperty.Register("mobjSourceComponent", typeof(Component), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mobjSourceMemberComponentProperty = SerializableProperty.Register("mobjSourceMemberComponent", typeof(IIdentifiedComponent), typeof(ToolStripDropDown));
        private static readonly SerializableProperty mobjToolStripDropDownFormProperty = SerializableProperty.Register("mobjToolStripDropDownForm", typeof(ToolStripDropDownForm), typeof(ToolStripDropDown));
        private static readonly SerializableProperty HeaderPanelProperty = SerializableProperty.Register("HeaderPanel", typeof(ToolStripDropDownHeaderPanel), typeof(ToolStripDropDown), new SerializablePropertyMetadata(null));

        private static readonly SerializableEvent ClosedEvent = SerializableEvent.Register("Closed", typeof(ToolStripDropDownClosedEventHandler), typeof(ToolStripDropDown));
        private static readonly SerializableEvent OpenedEvent = SerializableEvent.Register("Opened", typeof(EventHandler), typeof(ToolStripDropDown));
        private static readonly SerializableEvent OpeningEvent = SerializableEvent.Register("Opening", typeof(CancelEventHandler), typeof(ToolStripDropDown));

        #endregion

        #region Methods

        /// <summary>
        /// Sets the auto generated internal.
        /// </summary>
        /// <param name="autoGenerated">if set to <c>true</c> [auto generated].</param>
        internal void SetAutoGeneratedInternal(bool autoGenerated)
        {
            this.mblnIsAutoGenerated = autoGenerated;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal virtual void Initialize()
        {
            base.SetTopLevelInternal(true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.GripStyle = ToolStripGripStyle.Hidden;
            base.LayoutStyle = ToolStripLayoutStyle.Flow;
            this.AutoSize = true;
        }

        /// <summary>
        /// Sets the close reason.
        /// </summary>
        /// <param name="reason">The reason.</param>
        internal void SetCloseReason(ToolStripDropDownCloseReason enmCloseReason)
        {
            this.menmCloseReason = enmCloseReason;
        }

        /// <summary>
        /// Closes the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control.
        /// </summary>
        public void Close()
        {
            this.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        /// <summary>
        /// Closes the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control for the specified reason.
        /// </summary>
        /// <param name="enmReason">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</param>
        public void Close(ToolStripDropDownCloseReason enmReason)
        {
            this.SetCloseReason(enmReason);
            this.mobjToolStripDropDownForm.Close();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Closed"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosedEventArgs"></see> that contains the event data.</param>
        protected virtual void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            // Raise event if needed
            ToolStripDropDownClosedEventHandler objEventHandler = this.ClosedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Closing"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosingEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnClosing(ToolStripDropDownClosingEventArgs e)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Opened"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnOpened(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.OpenedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Opening"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
        protected virtual void OnOpening(CancelEventArgs e)
        {
            // Raise event if needed
            CancelEventHandler objEventHandler = this.OpeningHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Displays the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control in its default position.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void Show()
        {
            this.ShowCore(ToolStripDropDownDirection.Default);
        }

        /// <summary>
        /// Shows the specified control.
        /// </summary>
        /// <param name="objComponent">The control.</param>
        /// <param name="objPosition">The position.</param>
        public void Show(Component objComponent, Point objPosition)
        {
            this.Show(objComponent, objPosition, ToolStripDropDownDirection.Default);
        }


        /// <summary>
        /// Shows the core.
        /// </summary>
        /// <param name="objDirection">The direction.</param>
        private void ShowCore(ToolStripDropDownDirection objDirection)
        {
            // Check if drop down has no source component and owner item and set default source component if it hasn't.
            if (this.SourceComponentInternal == null && this.OwnerItem == null)
            {
                this.SourceComponentInternal = VWGContext.Current.MainForm as Form;
            }

            // Default dialog alignment
            DialogAlignment objDialogAlignment = DialogAlignment.Custom;

            // Create a new cancel event arguments.
            CancelEventArgs objCancelEventArgs = new CancelEventArgs(this.Items.Count == 0);

            // Raise on opening event.
            this.OnOpening(objCancelEventArgs);

            // Check if opening was not canceled.
            if (!objCancelEventArgs.Cancel)
            {
                // Check after the opening event if the tool strip drop down has any items.
                if (this.Items.Count > 0)
                {
                    // Creates a local tool strip drop down form.
                    mobjToolStripDropDownForm = CreateToolStripDropDownForm();

                    // Validate the local tool strip drop down form.
                    if (mobjToolStripDropDownForm != null)
                    {
                        if (objDirection != ToolStripDropDownDirection.Default)
                        {
                            switch (objDirection)
                            {
                                case ToolStripDropDownDirection.Left:
                                    objDialogAlignment = DialogAlignment.Left;
                                    break;
                                case ToolStripDropDownDirection.Right:
                                    objDialogAlignment = DialogAlignment.Right;
                                    break;
                                case ToolStripDropDownDirection.AboveLeft:
                                case ToolStripDropDownDirection.AboveRight:
                                    objDialogAlignment = DialogAlignment.Above;
                                    break;
                                case ToolStripDropDownDirection.BelowLeft:
                                case ToolStripDropDownDirection.BelowRight:
                                    objDialogAlignment = DialogAlignment.Below;
                                    break;
                            }
                        }

                        // Try getting a source component.
                        Component objSourceComponent = this.SourceComponentInternal;
                        if (objSourceComponent != null)
                        {
                            // Update drop down form location.
                            mobjToolStripDropDownForm.Location = this.Location;

                            // Show the local tool strip drop down form as popup.
                            mobjToolStripDropDownForm.ShowPopup(objSourceComponent, this.SourceMemberComponentInternal, objDialogAlignment);
                        }
                        else
                        {
                            // Get owner item.
                            ToolStripItem objOwnerToolStripItem = this.OwnerItem;
                            if (objOwnerToolStripItem != null)
                            {
                                // Get owner tool strip.
                                ToolStrip objOwnerToolStrip = objOwnerToolStripItem.Owner;
                                if (objOwnerToolStrip != null)
                                {
                                    // Check if owner strip is a drop down strip.
                                    ToolStripDropDown objOwnerToolStripDropDown = objOwnerToolStrip as ToolStripDropDown;
                                    if (objOwnerToolStripDropDown != null)
                                    {
                                        //If owner doesn't contain form or not visible, show only inner popup
                                        Form objOwnerForm = objOwnerToolStripDropDown.DropDownForm;
                                        if ((objOwnerForm == null) || (!objOwnerForm.Visible))
                                        {
                                            objOwnerForm = this.Context.ActiveForm as Form;

                                            // Show the local tool strip drop down form as popup (no component for alignment relation is required)
                                            mobjToolStripDropDownForm.ShowPopup(objOwnerForm);

                                        }
                                        else //If owner has visible popup, show it.
                                        {
                                            // Show the local tool strip drop down's owner form as popup.
                                            mobjToolStripDropDownForm.ShowPopup(objOwnerForm, (IRegisteredComponentMember)objOwnerToolStripItem, this.Context.RightToLeft ? DialogAlignment.Left : DialogAlignment.Right);
                                        }

                                    }
                                    else
                                    {
                                        // Get owner form.
                                        Form objOwnerForm = objOwnerToolStrip.TopLevelControl as Form;
                                        if (objOwnerForm != null)
                                        {
                                            // Show the local tool strip drop down form as popup.
                                            mobjToolStripDropDownForm.ShowPopup(objOwnerForm, (IRegisteredComponentMember)objOwnerToolStripItem, DialogAlignment.Below);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates the tool strip drop down form.
        /// </summary>
        /// <returns></returns>
        private ToolStripDropDownForm CreateToolStripDropDownForm()
        {
            ToolStripDropDownForm objToolStripDropDownForm = CreateToolStripDropDownFormInstance();

            // Set a manual start position.
            objToolStripDropDownForm.StartPosition = FormStartPosition.Manual;

            // Register the close handler - if needed.
            if (this.ClosedHandler != null)
            {
                objToolStripDropDownForm.Closed += new EventHandler(OnToolStripDropDownFormClosed);
            }

            // Register the open handler - if needed.
            if (this.OpenedHandler != null)
            {
                objToolStripDropDownForm.Load += new EventHandler(OnToolStripDropDownFormLoaded);
            }

            return objToolStripDropDownForm;
        }

        /// <summary>
        /// Creates the tool strip drop down form instance.
        /// </summary>
        /// <returns></returns>
        protected virtual ToolStripDropDownForm CreateToolStripDropDownFormInstance()
        {
            // Create a new drop down form.
            ToolStripDropDownForm objToolStripDropDownForm = new ToolStripDropDownForm(this);
            return objToolStripDropDownForm;
        }

        /// <summary>
        /// Called when [tool strip drop down form loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnToolStripDropDownFormLoaded(object sender, EventArgs e)
        {
            this.OnOpened(EventArgs.Empty);
        }

        /// <summary>
        /// Handles the Closed event of the objToolStripDropDownForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnToolStripDropDownFormClosed(object sender, EventArgs e)
        {
            this.OnClosed(new ToolStripDropDownClosedEventArgs(ToolStripDropDownCloseReason.AppFocusChange));
        }

        /// <summary>
        /// Shows the specified control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="objPosition">The position.</param>
        /// <param name="enmDirection">The direction.</param>
        public void Show(Component objComponent, Point objPosition, ToolStripDropDownDirection enmDirection)
        {
            if (objComponent == null)
            {
                throw new ArgumentNullException("objComponent");
            }

            // Set source component.
            this.SourceComponentInternal = objComponent;

            // Clear member component.
            this.SourceMemberComponentInternal = null;

            // Show by position.
            this.Show(objPosition, enmDirection);

        }

        /// <summary>
        /// Shows the specified control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="objMemberComponent">The member component.</param>
        /// <param name="objPoint">The point.</param>
        public void Show(Component objComponent, IIdentifiedComponent objMemberComponent, Point objPoint)
        {
            if (objComponent == null)
            {
                throw new ArgumentNullException("objComponent");
            }

            // Set source component.
            this.SourceComponentInternal = objComponent;

            // Set member component.
            this.SourceMemberComponentInternal = objMemberComponent;

            // Show by position.
            this.Show(objPoint);
        }

        /// <summary>
        /// Shows the specified control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intX">The X.</param>
        /// <param name="intY">The Y.</param>
        public void Show(Control objControl, int intX, int intY)
        {
            this.Show(objControl, new Point(intX, intY));
        }

        /// <summary>
        /// Shows the drop down.
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <param name="intX">The X.</param>
        /// <param name="intY">The Y.</param>
        internal void ShowDropDown(Component objComponent, int intX, int intY)
        {
            if (objComponent == null)
            {
                throw new ArgumentNullException("objComponent");
            }

            // Set source component.
            this.SourceComponentInternal = objComponent;

            // Clear member component.
            this.SourceMemberComponentInternal = null;

            // Show by position.
            this.Show(new Point(intX, intY));
        }

        /// <summary>
        /// Shows the drop down.
        /// </summary>
        /// <param name="objOwnerItem">The obj owner item.</param>
        internal void ShowDropDown(ToolStripDropDownItem objOwnerItem)
        {
            // Preserve owner item.
            this.OwnerItem = objOwnerItem;

            // Initialize source component and location.
            this.SourceComponentInternal = null;
            this.Location = Point.Empty;

            this.ShowCore(ToolStripDropDownDirection.Default);
        }

        ///<summary>Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified screen location.</summary> 
        ///<param name="screenLocation">The horizontal and vertical location of the screen's upper-left corner, in pixels.</param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Show(Point screenLocation)
        {
            this.Show(screenLocation, ToolStripDropDownDirection.Default);
        }

        ///<summary>Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified control location and with the specified direction relative to the parent control.</summary> 
        ///<param name="direction">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</param> 
        ///<param name="position">The horizontal and vertical location of the reference control's upper-left corner, in pixels.</param>
        public void Show(Point position, ToolStripDropDownDirection direction)
        {
            this.Location = position;
            this.ShowCore(direction);
        }

        ///<summary>Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified screen coordinates.</summary> 
        ///<param name="y">The vertical screen coordinate, in pixels.</param> 
        ///<param name="x">The horizontal screen coordinate, in pixels.</param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Show(int x, int y)
        {
            this.Show(new Point(x, y));
        }

        /// <summary>
        /// Sets the control to the specified visible state.
        /// </summary>
        /// <param name="blnValue">true to make the control visible; otherwise, false.</param>
        protected override void SetVisibleCore(bool blnValue)
        {
            // Close only when visible is set to false and auto closing is enabled like in WinForms.
            if (!blnValue && this.AutoClose && this.mobjToolStripDropDownForm != null)
            {
                this.mobjToolStripDropDownForm.Close();
            }
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
        protected internal override void OnItemAdded(ToolStripItemEventArgs e)
        {
            base.OnItemAdded(e);
            if (mobjOwnerItem != null)
            {
                mobjOwnerItem.UpdateParams(AttributeType.Extended);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemRemoved"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
        protected internal override void OnItemRemoved(ToolStripItemEventArgs e)
        {
            base.OnItemRemoved(e);
            if (mobjOwnerItem != null)
            {
                mobjOwnerItem.UpdateParams(AttributeType.Extended);
            }
        }

        #endregion Methods

        #region Events

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.BackgroundImage"></see> property changes.</summary>
        [Browsable(false)]
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

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.BackgroundImage"></see> property changes.</summary>
        [Browsable(false)]
        public event EventHandler BackgroundImageLayoutChanged
        {
            add
            {
                base.BackgroundImageLayoutChanged += value;
            }
            remove
            {
                base.BackgroundImageLayoutChanged -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.BindingContext"></see> property changes.</summary>
        [Browsable(false)]
        public event EventHandler BindingContextChanged
        {
            add
            {
                base.BindingContextChanged += value;
            }
            remove
            {
                base.BindingContextChanged -= value;
            }
        }

        ///<summary>Occurs when the focus or keyboard user interface (UI) cues change.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event UICuesEventHandler ChangeUICues;


        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is closed.</summary> 
        ///<filterpriority>1</filterpriority>
        public event ToolStripDropDownClosedEventHandler Closed
        {
            add
            {
                this.AddHandler(ToolStripDropDown.ClosedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStripDropDown.ClosedEvent, value);
            }
        }

        /// <summary>
        /// Gets the closed handler.
        /// </summary>
        /// <value>The closed handler.</value>
        private ToolStripDropDownClosedEventHandler ClosedHandler
        {
            get
            {
                return (ToolStripDropDownClosedEventHandler)this.GetHandler(ToolStripDropDown.ClosedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is about to close.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripDropDownClosingEventHandler Closing;

        ///<summary>This event is not relevant to this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler ContextMenuChanged;

        ///<summary>This event is not relevant to this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
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

        ///<summary>This event is not relevant to this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DockChanged;

        ///<summary>Occurs when the focus enters the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler Enter
        {
            add
            {
                base.Enter += value;
            }
            remove
            {
                base.Enter -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Font"></see> property changes.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler FontChanged
        {
            add
            {
                base.FontChanged += value;
            }
            remove
            {
                base.FontChanged -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ForeColor"></see> property changes.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        ///<summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event GiveFeedbackEventHandler GiveFeedback;

        ///<summary>Occurs when the user requests help for a control.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event HelpEventHandler HelpRequested;

        ///<summary>Occurs when the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.ImeModeChanged"></see> property has changed.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler ImeModeChanged;

        ///<summary>Occurs when a key is pressed and held down while the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has focus.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event KeyEventHandler KeyDown
        {
            add
            {
                base.KeyDown += value;
            }
            remove
            {
                base.KeyDown -= value;
            }
        }

        ///<summary>Occurs when a key is pressed while the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has focus.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                base.KeyPress += value;
            }
            remove
            {
                base.KeyPress -= value;
            }
        }

        ///<summary>Occurs when a key is released while the control has focus.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event KeyEventHandler KeyUp
        {
            add
            {
                base.KeyUp += value;
            }
            remove
            {
                base.KeyUp -= value;
            }
        }

        /// <summary>
        /// Occurs when the input focus leaves the control.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler Leave
        {
            add
            {
                base.Leave += value;
            }
            remove
            {
                base.Leave -= value;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is opened.
        /// </summary>
        public event EventHandler Opened
        {
            add
            {
                this.AddHandler(ToolStripDropDown.OpenedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStripDropDown.OpenedEvent, value);
            }
        }

        /// <summary>
        /// Gets the opened handler.
        /// </summary>
        /// <value>The opened handler.</value>
        private EventHandler OpenedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripDropDown.OpenedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is opening.</summary>
        [SRCategory("CatAction"), SRDescription("ToolStripDropDownOpeningDescr")]
        public event CancelEventHandler Opening
        {
            add
            {
                this.AddHandler(ToolStripDropDown.OpeningEvent, value);
            }
            remove
            {
                this.RemoveHandler(ToolStripDropDown.OpeningEvent, value);
            }
        }

        /// <summary>
        /// Gets the opening handler.
        /// </summary>
        /// <value>The opening handler.</value>
        private CancelEventHandler OpeningHandler
        {
            get
            {
                return (CancelEventHandler)this.GetHandler(ToolStripDropDown.OpeningEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Region"></see> property changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler RegionChanged;

        ///<summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ScrollEventHandler Scroll;

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> style changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler StyleChanged;

        ///<summary>This event is not relevant to this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabIndexChanged;

        ///<summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabStopChanged;

        ///<summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        ///<summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Validated
        {
            add
            {
                base.Validated += value;
            }
            remove
            {
                base.Validated -= value;
            }
        }

        ///<summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event CancelEventHandler Validating
        {
            add
            {
                base.Validating += value;
            }
            remove
            {
                base.Validating -= value;
            }
        }

        #endregion Events

        #region Properties

        #region Property Store

        private bool mblnAutoClose
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDown.mblnAutoCloseProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDown.mblnAutoCloseProperty, value);
            }
        }

        private bool mblnAutoSize
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDown.mblnAutoSizeProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDown.mblnAutoSizeProperty, value);
            }
        }

        private bool mblnIsAutoGenerated
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDown.mblnIsAutoGeneratedProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDown.mblnIsAutoGeneratedProperty, value);
            }
        }

        private ToolStripItem mobjOwnerItem
        {
            get
            {
                return this.GetValue<ToolStripItem>(ToolStripDropDown.mobjOwnerItemProperty);
            }
            set
            {
                this.SetValue<ToolStripItem>(ToolStripDropDown.mobjOwnerItemProperty, value);
            }
        }

        private ToolStripDropDownCloseReason menmCloseReason
        {
            get
            {
                return this.GetValue<ToolStripDropDownCloseReason>(ToolStripDropDown.menmCloseReasonProperty);
            }
            set
            {
                this.SetValue<ToolStripDropDownCloseReason>(ToolStripDropDown.menmCloseReasonProperty, value);
            }
        }

        private Component mobjSourceComponent
        {
            get
            {
                return this.GetValue<Component>(ToolStripDropDown.mobjSourceComponentProperty, null);
            }
            set
            {
                this.SetValue<Component>(ToolStripDropDown.mobjSourceComponentProperty, value);
            }
        }

        private IIdentifiedComponent mobjSourceMemberComponent
        {
            get
            {
                return this.GetValue<IIdentifiedComponent>(ToolStripDropDown.mobjSourceMemberComponentProperty, null);
            }
            set
            {
                this.SetValue<IIdentifiedComponent>(ToolStripDropDown.mobjSourceMemberComponentProperty, value);
            }
        }

        private ToolStripDropDownForm mobjToolStripDropDownForm
        {
            get
            {
                return this.GetValue<ToolStripDropDownForm>(ToolStripDropDown.mobjToolStripDropDownFormProperty, null);
            }
            set
            {
                this.SetValue<ToolStripDropDownForm>(ToolStripDropDown.mobjToolStripDropDownFormProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>true to enable item reordering; otherwise, false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowItemReorder
        {
            get
            {
                return base.AllowItemReorder;
            }
            set
            {
                base.AllowItemReorder = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Opacity"></see> of the form can be adjusted.
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Opacity"></see> of the form can be adjusted; otherwise, false. </returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowTransparency
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control should automatically close when it has lost activation.
        /// </summary>
        /// <value><c>true</c> if [auto close]; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control automatically closes; otherwise, false. The default is true.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [DefaultValue(true), SRDescription("ToolStripDropDownAutoCloseDescr"), SRCategory("CatBehavior")]
        public bool AutoClose
        {
            get
            {
                return this.mblnAutoClose;
            }
            set
            {
                if (this.mblnAutoClose != value)
                {
                    this.mblnAutoClose = value;
                    
                    // TODO: Update client
                    if (this.mobjToolStripDropDownForm != null)
                    {
                        this.mobjToolStripDropDownForm.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> automatically adjusts its size when the form is resized.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control automatically resizes; otherwise, false. The default is true.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [DefaultValue(true)]
        public override bool AutoSize
        {
            get
            {
                return this.mblnAutoSize;
            }
            set
            {
                if (this.mblnAutoSize != value)
                {
                    this.mblnAutoSize = value;
                    this.OnAutoSizeChanged(EventArgs.Empty);
                    // TODO: Update client 
                }
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenu"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public ContextMenu ContextMenu
        {
            get
            {
                return base.ContextMenu;
            }
            set
            {
                base.ContextMenu = value;
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        protected override DockStyle DefaultDock
        {
            get
            {
                return DockStyle.None;
            }
        }

        protected override bool DefaultShowItemToolTips
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values.</returns>
        [DefaultValue(DockStyle.None), EditorBrowsable(EditorBrowsableState.Always), Browsable(false)]
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

        /// <summary>
        /// Gets or sets a value indicating whether a three-dimensional shadow effect appears when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed.
        /// </summary>
        /// <value><c>true</c> if [drop shadow enabled]; otherwise, <c>false</c>.</value>
        /// <returns>true to enable the shadow effect; otherwise, false.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DropShadowEnabled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control.</returns>
        public override Font Font
        {
            get
            {
                if (this.IsAutoGenerated && (this.OwnerItem != null))
                {
                    return this.OwnerItem.Font;
                }
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>One of <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> the values.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public ToolStripGripDisplayStyle GripDisplayStyle
        {
            get
            {
                return base.GripDisplayStyle;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Padding GripMargin
        {
            get
            {
                return base.GripMargin;
            }
            set
            {
                base.GripMargin = value;
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never), DefaultValue(ToolStripGripStyle.Hidden), Browsable(false)]
        public ToolStripGripStyle GripStyle
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

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> was automatically generated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is auto generated; otherwise, <c>false</c>.
        /// </value>
        /// <returns>true if this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is generated automatically; otherwise, false.</returns>
        [Browsable(false)]
        public bool IsAutoGenerated
        {
            get
            {
                return this.mblnIsAutoGenerated;
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Drawing.Point"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public Point Location
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
        /// Determines the opacity of the form.
        /// </summary>
        /// <value>The opacity.</value>
        /// <returns>The level of opacity for the form. The default is 1.00.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Opacity
        {
            get
            {
                return 1.0;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the owner of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
        /// </summary>
        /// <value>The owner item.</value>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the owner of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>. The default value is null.</returns>
        [Browsable(false), DefaultValue((string)null)]
        public ToolStripItem OwnerItem
        {
            get
            {
                return this.mobjOwnerItem;
            }
            set
            {
                if (this.mobjOwnerItem != value)
                {
                    Font font = this.Font;
                    RightToLeft rightToLeft = this.RightToLeft;
                    this.mobjOwnerItem = value;
                }
            }
        }

        /// <summary>
        /// Gets the parent of this component.
        /// </summary>
        public override Component InternalParent
        {
            get
            {
                Component objComponent = base.InternalParent;
                if (objComponent == null)
                {
                    return mobjOwnerItem;
                }

                return objComponent;
            }
            set
            {
                base.InternalParent = value;
            }
        }

        /// <summary>
        /// Gets or sets the source component internal.
        /// </summary>
        /// <value>The source component internal.</value>
        internal Component SourceComponentInternal
        {
            get
            {
                return mobjSourceComponent;
            }
            set
            {
                if (value != mobjSourceComponent)
                {
                    mobjSourceComponent = value;
                }
            }
        }

        internal IIdentifiedComponent SourceMemberComponentInternal
        {
            get
            {
                return mobjSourceMemberComponent;
            }
            set
            {
                if (value != mobjSourceMemberComponent)
                {
                    mobjSourceMemberComponent = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the window region associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
        /// </summary>
        /// <value>The region.</value>
        /// <returns>The window <see cref="T:System.Drawing.Region"></see> associated with the control.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Region Region
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets a value indicating whether [right to left inherited].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [right to left inherited]; otherwise, <c>false</c>.
        /// </value>
        private bool RightToLeftInherited
        {
            get
            {
                return !this.ShouldSerializeRightToLeft();
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [SRCategory("CatAppearance"), Localizable(true), AmbientValue(2), SRDescription("ControlRightToLeftDescr")]
        public override RightToLeft RightToLeft
        {
            get
            {
                if (this.RightToLeftInherited)
                {
                    if (this.OwnerItem != null)
                    {
                        return this.OwnerItem.RightToLeft;
                    }
                }
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        /// <summary>
        /// Gets the drop down form.
        /// </summary>
        /// <value>The drop down form.</value>
        internal Form DropDownForm
        {
            get
            {
                return mobjToolStripDropDownForm;
            }
        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>true to enable stretching; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool Stretch
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

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.Int32"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TabIndex
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
        /// Specifies the direction in which to draw the text on the item.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripTextDirection.Horizontal"></see>.</returns>
        [DefaultValue(ToolStripTextDirection.Horizontal), SRCategory("CatAppearance"), Browsable(false), SRDescription("ToolStripTextDirectionDescr")]
        public override ToolStripTextDirection TextDirection
        {
            get
            {
                return base.TextDirection;
            }
            set
            {
                base.TextDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is a top-level control.
        /// </summary>
        /// <value><c>true</c> if [top level]; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is a top-level control; otherwise, false.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool TopLevel
        {
            get
            {
                return base.GetTopLevel();
            }
            set
            {
                if (value != base.GetTopLevel())
                {
                    base.SetTopLevelInternal(value);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the overflow button for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> with overflow enabled.
        /// </summary>
        /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> with its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> and its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> value set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.Never"></see>.</returns>
        ///   
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public ToolStripOverflowButton OverflowButton
        {
            get
            {
                return base.OverflowButton;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the form should be displayed as a topmost form.
        /// </summary>
        /// <value><c>true</c> if [top most]; otherwise, <c>false</c>.</value>
        /// <returns>true in all cases.</returns>
        protected virtual bool TopMost
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is visible or hidden.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is visible; otherwise, false. The default is false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Visible
        {
            get
            {
                // In opposed to WinForms, our dropdown's visibility is determined by its wrapping form (which does not exist in winforms)
                return DropDownForm != null && DropDownForm.Visible;
            }
        }

        /// <summary>
        /// Gets the header panel.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRDescription("ToolStripDropDownHeaderPanelDescr"), SRCategory("CatAppearance")]
        public ToolStripDropDownHeaderPanel HeaderPanel
        {
            get
            {
                ToolStripDropDownHeaderPanel objToolStripDropDownHeaderPanel = this.GetValue<ToolStripDropDownHeaderPanel>(ToolStripDropDown.HeaderPanelProperty);
                if (objToolStripDropDownHeaderPanel == null)
                {
                    objToolStripDropDownHeaderPanel = new ToolStripDropDownHeaderPanel();
                    this.SetValue<ToolStripDropDownHeaderPanel>(ToolStripDropDown.HeaderPanelProperty, objToolStripDropDownHeaderPanel);
                }

                return objToolStripDropDownHeaderPanel;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripDropDown Class

    #region ToolStripDropDownMenu Class

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Serializable()]
    [ToolboxItem(false)]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripDropDownMenu : ToolStripDropDown
    {
        #region Members

        private static readonly SerializableProperty mblnShowCheckMarginProperty = SerializableProperty.Register("mblnShowCheckMargin", typeof(bool), typeof(ToolStripDropDownMenu));
        private static readonly SerializableProperty mblnShowImageMarginProperty = SerializableProperty.Register("mblnShowImageMargin", typeof(bool), typeof(ToolStripDropDownMenu), new SerializablePropertyMetadata(true));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> class. </summary>
        public ToolStripDropDownMenu()
        {
        }

        #endregion C'Tors

        #region Properties

        #region Property Store

        private bool mblnShowCheckMargin
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDownMenu.mblnShowCheckMarginProperty, false);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDownMenu.mblnShowCheckMarginProperty, value);
            }
        }

        private bool mblnShowImageMargin
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDownMenu.mblnShowImageMarginProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDownMenu.mblnShowImageMarginProperty, value);
            }
        }

        #endregion

        ///<summary>Gets or sets a value indicating how the items of <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> are displayed.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>.</returns>
        [DefaultValue(ToolStripLayoutStyle.Flow)]
        public ToolStripLayoutStyle LayoutStyle
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

        ///<summary>Gets or sets a value indicating whether space for a check mark is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary> 
        ///<returns>true if the check margin is shown; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(false), SRDescription("ToolStripDropDownMenuShowCheckMarginDescr"), SRCategory("CatAppearance")]
        public bool ShowCheckMargin
        {
            get
            {
                return mblnShowCheckMargin;
            }
            set
            {
                if (mblnShowCheckMargin != value)
                {
                    mblnShowCheckMargin = value;
                    // TODO: Update client 
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether space for an image is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
        ///<returns>true if the image margin is shown; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), DefaultValue(true), SRDescription("ToolStripDropDownMenuShowImageMarginDescr")]
        public bool ShowImageMargin
        {
            get
            {
                return mblnShowImageMargin;
            }
            set
            {
                if (mblnShowImageMargin != value)
                {
                    mblnShowImageMargin = value;
                    // TODO: Update client 
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates the default item.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="objImage">The obj image.</param>
        /// <param name="objOnClick">The obj on click.</param>
        /// <returns></returns>
        protected internal override ToolStripItem CreateDefaultItem(string strText, ResourceHandle objImage, EventHandler objOnClick)
        {
            if (strText == "-")
            {
                return new ToolStripSeparator();
            }
            return new ToolStripMenuItem(strText, objImage, objOnClick);
        }

        #endregion
    }

    #endregion ToolStripDropDownMenu Class

    #region CreateParams Class

    /// <summary>Encapsulates the information needed when creating a control.</summary>
    [Serializable()]
    public class CreateParams : SerializableObject
    {
        #region Members

        private static readonly SerializableProperty mstrCaptionProperty = SerializableProperty.Register("mstrCaption", typeof(string), typeof(CreateParams));
        private static readonly SerializableProperty mstrClassNameProperty = SerializableProperty.Register("mstrClassName", typeof(string), typeof(CreateParams));
        private static readonly SerializableProperty mstrClassStyleProperty = SerializableProperty.Register("mstrClassStyle", typeof(int), typeof(CreateParams));
        private static readonly SerializableProperty mintHeightProperty = SerializableProperty.Register("mintHeight", typeof(int), typeof(CreateParams));
        private static readonly SerializableProperty mobjParamProperty = SerializableProperty.Register("mobjParam", typeof(object), typeof(CreateParams));
        private static readonly SerializableProperty mintWidthProperty = SerializableProperty.Register("mintWidth", typeof(int), typeof(CreateParams));
        private static readonly SerializableProperty mintXProperty = SerializableProperty.Register("mintX", typeof(int), typeof(CreateParams));
        private static readonly SerializableProperty mintYProperty = SerializableProperty.Register("mintY", typeof(int), typeof(CreateParams));

        #endregion Members

        #region Properties

        #region Property Store

        private string mstrCaption
        {
            get
            {
                return this.GetValue<string>(CreateParams.mstrCaptionProperty);
            }
            set
            {
                this.SetValue<string>(CreateParams.mstrCaptionProperty, value);
            }
        }

        private string mstrClassName
        {
            get
            {
                return this.GetValue<string>(CreateParams.mstrClassNameProperty);
            }
            set
            {
                this.SetValue<string>(CreateParams.mstrClassNameProperty, value);
            }
        }

        private int mstrClassStyle
        {
            get
            {
                return this.GetValue<int>(CreateParams.mstrClassStyleProperty);
            }
            set
            {
                this.SetValue<int>(CreateParams.mstrClassStyleProperty, value);
            }
        }

        private int mintHeight
        {
            get
            {
                return this.GetValue<int>(CreateParams.mintHeightProperty);
            }
            set
            {
                this.SetValue<int>(CreateParams.mintHeightProperty, value);
            }
        }

        private object mobjParam
        {
            get
            {
                return this.GetValue<object>(CreateParams.mobjParamProperty);
            }
            set
            {
                this.SetValue<object>(CreateParams.mobjParamProperty, value);
            }
        }

        private int mintWidth
        {
            get
            {
                return this.GetValue<int>(CreateParams.mintWidthProperty);
            }
            set
            {
                this.SetValue<int>(CreateParams.mintWidthProperty, value);
            }
        }

        private int mintX
        {
            get
            {
                return this.GetValue<int>(CreateParams.mintXProperty);
            }
            set
            {
                this.SetValue<int>(CreateParams.mintXProperty, value);
            }
        }

        private int mintY
        {
            get
            {
                return this.GetValue<int>(CreateParams.mintYProperty);
            }
            set
            {
                this.SetValue<int>(CreateParams.mintYProperty, value);
            }
        }

        #endregion

        /// <summary>Gets or sets the control's initial text.</summary>
        /// <returns>The control's initial text.</returns>
        /// <filterpriority>1</filterpriority>
        public string Caption
        {
            get
            {
                return this.mstrCaption;
            }
            set
            {
                this.mstrCaption = value;
            }
        }

        /// <summary>Gets or sets the name of the Windows class to derive the control from.</summary>
        /// <returns>The name of the Windows class to derive the control from.</returns>
        /// <filterpriority>1</filterpriority>
        public string ClassName
        {
            get
            {
                return this.mstrClassName;
            }
            set
            {
                this.mstrClassName = value;
            }
        }

        /// <summary>Gets or sets a bitwise combination of class style values.</summary>
        /// <returns>A bitwise combination of the class style values.</returns>
        /// <filterpriority>1</filterpriority>
        public int ClassStyle
        {
            get
            {
                return this.mstrClassStyle;
            }
            set
            {
                this.mstrClassStyle = value;
            }
        }

        /// <summary>Gets or sets a bitwise combination of extended window style values.</summary>
        /// <returns>A bitwise combination of the extended window style values.</returns>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ExStyle
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the initial height of the control.</summary>
        /// <returns>The numeric value that represents the initial height of the control.</returns>
        /// <filterpriority>1</filterpriority>
        public int Height
        {
            get
            {
                return this.mintHeight;
            }
            set
            {
                this.mintHeight = value;
            }
        }

        /// <summary>Gets or sets additional parameter information needed to create the control.</summary>
        /// <returns>The <see cref="T:System.Object"></see> that holds additional parameter information needed to create the control.</returns>
        /// <filterpriority>1</filterpriority>
        public object Param
        {
            get
            {
                return this.mobjParam;
            }
            set
            {
                this.mobjParam = value;
            }
        }

        ///<summary>Gets or sets the control's parent.</summary> 
        ///<returns>An <see cref="T:System.IntPtr"></see> that contains the window handle of the control's parent.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr Parent
        {
            get
            {
                return IntPtr.Zero;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a bitwise combination of window style values.</summary> 
        ///<returns>A bitwise combination of the window style values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Style
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the initial width of the control.</summary>
        /// <returns>The numeric value that represents the initial width of the control.</returns>
        /// <filterpriority>1</filterpriority>
        public int Width
        {
            get
            {
                return this.mintWidth;
            }
            set
            {
                this.mintWidth = value;
            }
        }

        /// <summary>Gets or sets the initial left position of the control.</summary>
        /// <returns>The numeric value that represents the initial left position of the control.</returns>
        /// <filterpriority>1</filterpriority>
        public int X
        {
            get
            {
                return this.mintX;
            }
            set
            {
                this.mintX = value;
            }
        }

        /// <summary>Gets or sets the top position of the initial location of the control.</summary>
        /// <returns>The numeric value that represents the top position of the initial location of the control.</returns>
        /// <filterpriority>1</filterpriority>
        public int Y
        {
            get
            {
                return this.mintY;
            }
            set
            {
                this.mintY = value;
            }
        }

        #endregion Properties
    }

    #endregion

    #region ContextMenuStrip Class

    /// <summary>Represents a shortcut menu. </summary>
    [DefaultEvent("Opening")]
    [ComVisible(true)]
    [SRDescription("DescriptionContextMenuStrip")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Serializable()]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ContextMenuStrip), "ContextMenuStrip_45.bmp")]
#else
    [ToolboxBitmap(typeof(ContextMenuStrip), "ContextMenuStrip.bmp")]
#endif
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ContextMenuStrip : ToolStripDropDownMenu
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> class and associates it with the specified container.</summary> 
        ///<param name="container">A component that implements <see cref="T:System.ComponentModel.IContainer"></see> that is the container of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see>.</param>
        public ContextMenuStrip(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            container.Add(this);
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> class. </summary>
        public ContextMenuStrip()
        {
        }

        #endregion C'Tors

        #region Properties

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override BorderColor BorderColor
        {
            get
            {
                return base.BorderColor;
            }
            set
            {
                base.BorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override BorderStyle BorderStyle
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

        /// <summary>
        /// Gets or sets the thickness of the border.
        /// </summary>
        /// <value>
        /// Gets or sets a border thickness.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override BorderWidth BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }
            set
            {
                base.BorderWidth = value;
            }
        }

        /// <summary>
        /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public override ToolStripItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        ///<summary>Gets the last control that caused this <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> to be displayed.</summary> 
        ///<returns>The control that caused this <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> to be displayed.</returns>
        [SRDescription("ContextMenuStripSourceControlDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Control SourceControl
        {
            get
            {
                Control objControl = null;

                // Get source component
                Component objSourceComponent = base.SourceComponentInternal;

                // Climb up till finding a control parent
                while (objSourceComponent != null)
                {
                    // Check if source component is control
                    objControl = objSourceComponent as Control;
                    if (objControl != null)
                    {
                        break;
                    }
                    else
                    {
                        // Climb to parent
                        objSourceComponent = objSourceComponent.InternalParent;
                    }
                }

                return objControl;
            }
        }

        /// <summary>
        /// Draggable indication is disabled for ContextMenuStrip
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override DraggableOptions Draggable
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        #endregion Properties
    }

    #endregion

    #region ScrollProperties Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public abstract class ScrollProperties
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollProperties"></see> class. </summary> 
        ///<param name="container">The <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> whose scrolling properties this object describes.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        protected ScrollProperties(ScrollableControl container)
        {
        }

        #endregion C'Tors

        #region Properties

        ///<summary>Gets or sets whether the scroll bar can be used on the container.</summary> 
        ///<returns>true if the scroll bar can be used; otherwise, false. </returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Enabled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the distance to move a scroll bar in response to a large scroll command. </summary> 
        ///<returns>An <see cref="T:System.Int32"></see> describing how far, in pixels, to move the scroll bar in response to a large change.</returns> 
        ///<exception cref="T:System.ArgumentOutOfRangeException"> 
        ///  <see cref="P:Gizmox.WebGUI.Forms.ScrollProperties.LargeChange"></see> cannot be less than zero. </exception> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LargeChange
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the upper limit of the scrollable range. </summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the maximum range of the scroll bar.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Maximum
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the lower limit of the scrollable range. </summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the lower range of the scroll bar.</returns> 
        ///<exception cref="T:System.ArgumentOutOfRangeException"> 
        ///  <see cref="P:Gizmox.WebGUI.Forms.ScrollProperties.LargeChange"></see> cannot be less than zero. </exception> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Minimum
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets the control to which this scroll information applies.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected ScrollableControl ParentControl
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets or sets the distance to move a scroll bar in response to a small scroll command. </summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing how far, in pixels, to move the scroll bar.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SmallChange
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a numeric value that represents the current position of the scroll bar box.</summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the position of the scroll bar box, in pixels. </returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Value
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets whether the scroll bar can be seen by the user.</summary> 
        ///<returns>true if it can be seen; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Visible
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion Properties
    }

    #endregion ScrollProperties Class

    #region HScrollProperties Class

    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class HScrollProperties : ScrollProperties
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HScrollProperties"></see> class. </summary> 
        ///<param name="container">A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> that contains the scroll bar.</param>
        public HScrollProperties(ScrollableControl container) : base(container)
        {
        }

        #endregion C'Tors
    }

    #endregion HScrollProperties Class

    #region VScrollProperties Class

    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class VScrollProperties : ScrollProperties
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.VScrollProperties"></see> class. </summary> 
        ///<param name="container">A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> that contains the scroll bar.</param>
        public VScrollProperties(ScrollableControl container) : base(container)
        {
        }

        #endregion C'Tors
    }

    #endregion VScrollProperties Class

    #region MenuStrip Class

    /// <summary>Provides a menu system for a form.</summary>
    /// <filterpriority>1</filterpriority>
    [MetadataTag(WGTags.MenuStrip)]
    [Skin(typeof(MenuStripSkin))]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [SRDescription("DescriptionMenuStrip")]
    [Serializable()]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(StatusStrip), "MenuStrip_45.bmp")]
#else
    [ToolboxBitmap(typeof(StatusStrip), "MenuStrip.bmp")]
#endif
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class MenuStrip : ToolStrip
    {
        #region Members

        /// <summary>
        /// 
        /// </summary>
        private static readonly SerializableProperty mblnShowDropDownItemsOnEnterProperty = SerializableProperty.Register("mblnShowDropDownItemsOnEnter", typeof(bool), typeof(MenuStrip), new SerializablePropertyMetadata(false));

        #endregion

        #region C'Tors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.MenuStrip"></see> class. </summary>
        public MenuStrip()
        {
            this.CanOverflow = false;
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.Stretch = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public override ToolStripItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality. </summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), SRDescription("ToolStripCanOverflowDescr"), SRCategory("CatLayout"), DefaultValue(false)]
        public bool CanOverflow
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

        /// <summary>Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
        /// <returns><see cref="T:System.Windows.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
        protected override Padding DefaultGripMargin
        {
            get
            {
                return new Padding(2, 2, 0, 2);
            }
        }

        /// <summary>Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see> from the edges of the form.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
        protected override Padding DefaultPadding
        {
            get
            {
                MenuStripSkin objSkin = this.Skin as MenuStripSkin;
                if (objSkin != null)
                {
                    if (this.GripStyle == ToolStripGripStyle.Visible)
                    {
                        return objSkin.PaddingWithGrip;
                    }
                    else
                    {
                        return objSkin.PaddingWithOutGrip;
                    }
                }

                if (this.GripStyle == ToolStripGripStyle.Visible)
                {
                    return new Padding(3, 2, 0, 2);
                }
                return new Padding(6, 2, 0, 2);
            }
        }

        /// <summary>
        /// Gets a value indicating whether strip supports menu stickiness.
        /// </summary>
        /// <value><c>true</c> if [supports stickiness]; otherwise, <c>false</c>.</value>
        protected override bool SupportMenuStickiness
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show items drop down on enter].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show items drop down on enter]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool ShowDropDownItemsOnEnter
        {
            get
            {
                return mblnShowDropDownItemsOnEnter;
            }
            set
            {
                if (mblnShowDropDownItemsOnEnter != value)
                {
                    mblnShowDropDownItemsOnEnter = value;

                    this.UpdateParams(AttributeType.Extended);
                }
            }
        }

        /// <summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see> by default.</summary>
        /// <returns>false in all cases.</returns>
        protected override bool DefaultShowItemToolTips
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets the horizontal and vertical dimensions, in pixels, of the <see cref="T:System.Windows.Forms.MenuStrip"></see> when it is first created.</summary>
        /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the <see cref="T:System.Windows.Forms.MenuStrip"></see> horizontal and vertical dimensions, in pixels. The default is 200 x 21 pixels.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 0x18);
            }
        }

        /// <summary>Gets or sets the visibility of the grip used to reposition the control.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(ToolStripGripStyle.Hidden)]
        public ToolStripGripStyle GripStyle
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


        /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that is used to display a list of Multiple-document interface (MDI) child forms.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that represents the menu item displaying a list of MDI child forms that are open in the application.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripMenuItem MdiWindowListItem
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>. </summary>
        /// <returns>true if ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>; otherwise, false. The default is false.</returns>
        [SRDescription("ToolStripShowItemToolTipsDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool ShowItemToolTips
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

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container. </summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container; otherwise, false. The default is true.</returns>
        [SRDescription("ToolStripStretchDescr"), DefaultValue(true), SRCategory("CatLayout")]
        public bool Stretch
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

        #region Property Store

        /// <summary>
        /// Gets or sets a value indicating whether [MBLN show items drop down on enter].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [MBLN show items drop down on enter]; otherwise, <c>false</c>.
        /// </value>
        private bool mblnShowDropDownItemsOnEnter
        {
            get
            {
                return this.GetValue<bool>(MenuStrip.mblnShowDropDownItemsOnEnterProperty);
            }
            set
            {
                this.SetValue<bool>(MenuStrip.mblnShowDropDownItemsOnEnterProperty, value);
            }
        }

        #endregion

        #endregion Properties

        #region Delegates and Events

        /// <summary>Occurs when the user accesses the menu with the keyboard or mouse. </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MenuActivate;

        /// <summary>Occurs when the <see cref="T:System.Windows.Forms.MenuStrip"></see> is deactivated.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MenuDeactivate;

        #endregion Delegates and Events

        #region Methods

        /// <summary>Creates a <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
        /// <returns>A <see cref="M:System.Windows.Forms.ToolStripMenuItem.#ctor(System.String,System.Drawing.Image,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
        /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> is clicked.</param>
        /// <param name="image">The <see cref="T:System.Drawing.Image"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>.</param>
        /// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
        protected internal override ToolStripItem CreateDefaultItem(string text, ResourceHandle image, EventHandler onClick)
        {
            if (text == "-")
            {
                return new ToolStripSeparator();
            }
            return new ToolStripMenuItem(text, image, onClick);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuActivate"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMenuActivate(EventArgs e)
        {
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuDeactivate"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMenuDeactivate(EventArgs e)
        {
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Renders the show items drop down on enter attribute.
            RenderShowDropDownItemsOnEnterAttribute(objWriter, false);
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

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Extended))
            {
                // Renders the show items drop down on enter attribute.
                RenderShowDropDownItemsOnEnterAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the show items drop down on enter attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowDropDownItemsOnEnterAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnShowDropDownItemsOnEnter = this.ShowDropDownItemsOnEnter;

            // Check if render.
            if (blnShowDropDownItemsOnEnter || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ShowDropDownItemsOnEnter, blnShowDropDownItemsOnEnter ? "1" : "0");
            }
        }

        #endregion Methods
    }

    #endregion
}
