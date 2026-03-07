#region Using

using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using System;
using System.Runtime.InteropServices;

using System.Drawing;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using Gizmox.WebGUI.Forms.Layout;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Globalization;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Extensibility;
using System.Text;
using System.Collections.Generic;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region ToolStripItem Class

    /// <summary>
    /// 
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("Click")]
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public abstract class ToolStripItem : Component, IDropTarget, IArrangedElement, IComponent, IDisposable, IRegisteredComponentMember, ISkinable
    {
        #region Members

        private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register("mobjParent", typeof(ToolStrip), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjOwnerProperty = SerializableProperty.Register("mobjOwner", typeof(ToolStrip), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjFontProperty = SerializableProperty.Register("mobjFont", typeof(Font), typeof(ToolStripItem));
        private static readonly SerializableProperty menmDisplayStyleProperty = SerializableProperty.Register("menmDisplayStyle", typeof(ToolStripItemDisplayStyle), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register("mobjBounds", typeof(Rectangle), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjTagProperty = SerializableProperty.Register("mobjTag", typeof(object), typeof(ToolStripItem));
        private static readonly SerializableProperty mstrTextProperty = SerializableProperty.Register("mstrText", typeof(string), typeof(ToolStripItem));
        private static readonly SerializableProperty menmRightToLeftProperty = SerializableProperty.Register("menmRightToLeft", typeof(RightToLeft), typeof(ToolStripItem));
        private static readonly SerializableProperty mblnEnabledProperty = SerializableProperty.Register("mblnEnabled", typeof(bool), typeof(ToolStripItem));
        private static readonly SerializableProperty mblnDoubleClickEnabledProperty = SerializableProperty.Register("mblnDoubleClickEnabled", typeof(bool), typeof(ToolStripItem));
        private static readonly SerializableProperty menmDockProperty = SerializableProperty.Register("menmDock", typeof(DockStyle), typeof(ToolStripItem));
        private static readonly SerializableProperty menmBackgroundImageLayoutProperty = SerializableProperty.Register("menmBackgroundImageLayout", typeof(ImageLayout), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjBackgroundImageProperty = SerializableProperty.Register("mobjBackgroundImage", typeof(ResourceHandle), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjBackColorProperty = SerializableProperty.Register("mobjBackColor", typeof(Color), typeof(ToolStripItem));
        private static readonly SerializableProperty menmAlignmentProperty = SerializableProperty.Register("menmAlignment", typeof(ToolStripItemAlignment), typeof(ToolStripItem));
        private static readonly SerializableProperty menmAnchorProperty = SerializableProperty.Register("menmAnchor", typeof(AnchorStyles), typeof(ToolStripItem));
        private static readonly SerializableProperty mblnAutoSizeProperty = SerializableProperty.Register("mblnAutoSize", typeof(bool), typeof(ToolStripItem));
        private static readonly SerializableProperty mblnAutoToolTipProperty = SerializableProperty.Register("mblnAutoToolTip", typeof(bool), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjForeColorProperty = SerializableProperty.Register("mobjForeColor", typeof(Color), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjImageProperty = SerializableProperty.Register("mobjImage", typeof(ResourceHandle), typeof(ToolStripItem));
        private static readonly SerializableProperty menmImageAlignProperty = SerializableProperty.Register("menmImageAlign", typeof(ContentAlignment), typeof(ToolStripItem));
        private static readonly SerializableProperty mintImageIndexProperty = SerializableProperty.Register("mintImageIndex", typeof(int), typeof(ToolStripItem),new SerializablePropertyMetadata(-1));
        private static readonly SerializableProperty mstrImageKeyProperty = SerializableProperty.Register("mstrImageKey", typeof(string), typeof(ToolStripItem), new SerializablePropertyMetadata(string.Empty));
        private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register("mobjMargin", typeof(Padding), typeof(ToolStripItem));
        private static readonly SerializableProperty menmMergeActionProperty = SerializableProperty.Register("menmMergeAction", typeof(MergeAction), typeof(ToolStripItem));
        private static readonly SerializableProperty mintMergeIndexProperty = SerializableProperty.Register("mintMergeIndex", typeof(int), typeof(ToolStripItem), new SerializablePropertyMetadata(-1));
        private static readonly SerializableProperty mstrNameProperty = SerializableProperty.Register("mstrName", typeof(string), typeof(ToolStripItem));
        private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register("mobjPadding", typeof(Padding), typeof(ToolStripItem));
        private static readonly SerializableProperty menmPlacementProperty = SerializableProperty.Register("menmPlacement", typeof(ToolStripItemPlacement), typeof(ToolStripItem));
        private static readonly SerializableProperty mblnRightToLeftAutoMirrorImageProperty = SerializableProperty.Register("mblnRightToLeftAutoMirrorImage", typeof(bool), typeof(ToolStripItem));
        private static readonly SerializableProperty menmTextAlignProperty = SerializableProperty.Register("menmTextAlign", typeof(ContentAlignment), typeof(ToolStripItem));
        private static readonly SerializableProperty menmTextDirectionProperty = SerializableProperty.Register("menmTextDirection", typeof(ToolStripTextDirection), typeof(ToolStripItem));
        private static readonly SerializableProperty menmTextImageRelationProperty = SerializableProperty.Register("menmTextImageRelation", typeof(TextImageRelation), typeof(ToolStripItem));
        private static readonly SerializableProperty memnImageScalingProperty = SerializableProperty.Register("memnImageScaling", typeof(ToolStripItemImageScaling), typeof(ToolStripItem));
        private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register("mstrToolTipText", typeof(string), typeof(ToolStripItem));
        private static readonly SerializableProperty mstrCustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(ToolStripItem), new SerializablePropertyMetadata(string.Empty));


        private static readonly SerializableEvent AvailableChangedEvent = SerializableEvent.Register("AvailableChanged", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent BackColorChangedEvent = SerializableEvent.Register("BackColorChanged", typeof(EventHandler), typeof(ToolStripItem));
        protected static readonly SerializableEvent ClickEvent = SerializableEvent.Register("ClickEvent", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent DisplayStyleChangedEvent = SerializableEvent.Register("DisplayStyleChanged", typeof(EventHandler), typeof(ToolStripItem));
        protected static readonly SerializableEvent DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent EnabledChangedEvent = SerializableEvent.Register("EnabledChanged", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent ForeColorChangedEvent = SerializableEvent.Register("ForeColorChanged", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent LocationChangedEvent = SerializableEvent.Register("LocationChanged", typeof(EventHandler), typeof(ToolStripItem));
        protected static readonly SerializableEvent MouseDownEvent = SerializableEvent.Register("MouseDown", typeof(EventHandler), typeof(ToolStripItem));
        protected static readonly SerializableEvent MouseUpEvent = SerializableEvent.Register("MouseUp", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent RightToLeftChangedEvent = SerializableEvent.Register("RightToLeftChanged", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent OwnerChangedEvent = SerializableEvent.Register("OwnerChanged", typeof(EventHandler), typeof(ToolStripItem));
        private static readonly SerializableEvent VisibleChangedEvent = SerializableEvent.Register("VisibleChanged", typeof(EventHandler), typeof(ToolStripItem));
        protected static readonly SerializableEvent TextChangedEvent = SerializableEvent.Register("TextChanged", typeof(EventHandler), typeof(ToolStripItem));
        
        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class.</summary>
        protected ToolStripItem()
        {
            this.mobjBounds = Rectangle.Empty;
            this.menmPlacement = ToolStripItemPlacement.None;
            this.menmImageAlign = ContentAlignment.MiddleCenter;
            this.menmTextAlign = ContentAlignment.MiddleCenter;
            this.menmTextImageRelation = TextImageRelation.ImageBeforeText;
            this.menmDisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            mblnAutoSize = true;
            mblnEnabled = true;
            mblnDoubleClickEnabled = false;

            this.SetState(ComponentState.Enabled | ComponentState.Visible, true);
            this.SetState(ComponentState.AllowDrop | ComponentState.Selected, false);

            this.mobjMargin = this.DefaultMargin;
            this.Size = this.DefaultSize;
            this.DisplayStyle = this.DefaultDisplayStyle;
            this.AutoToolTip = this.DefaultAutoToolTip;

            RegisterSelf();
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified name, image, and event handler.</summary> 
        ///<param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
        ///<param name="text">A <see cref="T:System.String"></see> representing the name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
        protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick) : this(text, image, onClick, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified display text, image, event handler, and name. </summary> 
        ///<param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
        ///<param name="image">The ResourceHandle to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
        protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick, string name)
            : this()
        {
            this.Text = text;
            this.Image = image;

            if (onClick != null)
            {
                this.Click += onClick;
            }

            this.Name = name;
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Begins a drag-and-drop operation.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see> values.</returns> 
        ///<param name="data">The object to be dragged. </param> 
        ///<param name="allowedEffects">The drag operations that can occur. </param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
        {
            return DragDropEffects.None;
        }

        ///<summary>Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        public ToolStrip GetCurrentParent()
        {
            return this.Parent;
        }

        ///<summary>Retrieves the size of a rectangular area into which a control can be fit.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.</returns> 
        ///<param name="objConstrainingSize">The custom-sized area for a control. </param> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public virtual Size GetPreferredSize(Size objConstrainingSize)
        {
            return objConstrainingSize;
        }

        /// <summary>
        /// Gets the preferred size with image.
        /// </summary>
        /// <param name="objSizeWithoutImage">The obj size without image.</param>
        /// <returns></returns>
        protected internal virtual Size GetPreferredSizeByImage(Size objSizeWithoutImage)
        {
            Size objFinalSize = objSizeWithoutImage;

            // Check if an image exists and should be rendered
            if (this.Image != null && (this.DisplayStyle == ToolStripItemDisplayStyle.Image || this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText))
            {
                int intImageHeight = 0;
                int intImageWidth = 0;

                switch (this.ImageScaling)
                {
                    case ToolStripItemImageScaling.None:
                        intImageHeight = this.Image.Height;
                        intImageWidth = this.Image.Width;
                        break;
                    case ToolStripItemImageScaling.SizeToFit:
                        ToolStrip objParentStrip = this.ParentInternal;
                        Size objParentImageScalingSize = Size.Empty;

                        if (this.ParentInternal != null)
                        {
                            objParentImageScalingSize = this.ParentInternal.ImageScalingSize;
                        }

                        // Get the image's dimentions - if parent doesn't exist take a default size
                        intImageHeight = objParentStrip != null ? objParentImageScalingSize.Height : ToolStripSkin.IMAGE_SCALING_SIZE;
                        intImageWidth = objParentStrip != null ? objParentImageScalingSize.Width : ToolStripSkin.IMAGE_SCALING_SIZE;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                // Get the correct Width/Height according to the image relation
                switch (this.TextImageRelation)
                {
                    case TextImageRelation.ImageAboveText:
                    case TextImageRelation.TextAboveImage:
                        objFinalSize.Width = Math.Max(objSizeWithoutImage.Width, intImageWidth);
                        objFinalSize.Height = objSizeWithoutImage.Height + intImageHeight;
                        break;
                    case TextImageRelation.ImageBeforeText:
                    case TextImageRelation.TextBeforeImage:
                        objFinalSize.Height = Math.Max(objSizeWithoutImage.Height, intImageHeight);
                        objFinalSize.Width = objSizeWithoutImage.Width + intImageWidth;
                        break;
                    case TextImageRelation.Overlay:
                        objFinalSize.Width = Math.Max(objSizeWithoutImage.Width, intImageWidth);
                        objFinalSize.Height = Math.Max(objSizeWithoutImage.Height, intImageHeight);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return objFinalSize;
        }

        /// <summary>
        /// Applies the size of the font to.
        /// </summary>
        /// <param name="objGivenSize">Size of the obj given.</param>
        /// <returns></returns>
        protected internal virtual Size GetPreferredeSizeByText()
        {
            // Check if item should even render text
            if (this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || this.DisplayStyle == ToolStripItemDisplayStyle.Text)
            {
                return GetTextSize(this.Text);
            }

            return Size.Empty;
        }

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <returns></returns>
        internal Size GetTextSize(string strText)
        {
            // Try getting the item's font
            Font objItemFont = this.Font;

            // If font doesn't exists try taknig the ToolStrip's font
            if (objItemFont == null && this.ParentInternal != null)
            {
                objItemFont = this.ParentInternal.Font;
            }

            // If font still doesn't exist take the skin's font
            if (objItemFont == null)
            {
                CommonSkin objSkin = SkinFactory.GetSkin(this) as CommonSkin;
                if (objSkin != null && objSkin.Font != null)
                {
                    objItemFont = objSkin.Font;
                }
                else
                {
                    throw new NullReferenceException("ToolStripItem.ApplyToolStripItemTextToSize: The item does not have a font '" + this.Name + "'.");
                }
            }

            // Measure the font
            return CommonUtils.GetStringMeasurements(strText, objItemFont);
        }

        /// <summary>
        /// Applies the size of the button skin to.
        /// </summary>
        /// <param name="objSkin">The obj skin.</param>
        /// <param name="objBaseSize">Size of the obj given.</param>
        /// <returns></returns>
        protected internal Size GetPreferredSizeByButtonSkin(ButtonSkin objSkin, Size objBaseSize)
        {
            // Take skin attributes
            if (objSkin != null && objBaseSize != null)
            {
                // Take the layout padding
                int intLayoutPadding = objSkin.ButtonImageTextGap;

                // Take the borders widths
                BorderWidth objBorderWidth = objSkin.BorderWidth;

                // Take the padding
                Padding objPadding = objSkin.Padding;

                // Sum up all sizes
                objBaseSize.Width += (objBorderWidth.Left + objBorderWidth.Right + intLayoutPadding + objPadding.Horizontal);
                objBaseSize.Height += (objBorderWidth.Top + objBorderWidth.Bottom + intLayoutPadding + objPadding.Vertical);
            }

            return objBaseSize;
        }

        ///<summary>Invalidates the entire surface of the control and causes the control to be redrawn.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Invalidate()
        {
            if (this.ParentInternal != null)
            {
                this.ParentInternal.Invalidate();
            }
        }

        ///<summary>Invalidates the specified region of the control by adding it to the control's update region, which is the area that will be repainted at the next paint operation, and causes a paint message to be sent to the control.</summary> 
        ///<param name="r">A <see cref="T:System.Drawing.Rectangle"></see> that represents the region to invalidate. </param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Invalidate(Rectangle r)
        {
            this.Invalidate();
        }

        /// <summary>Sets the size and location of the item.</summary>
        /// <param name="bounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:System.Windows.Forms.ToolStripItem"></see></param>
        protected internal virtual void SetBounds(Rectangle bounds)
        {
            Rectangle rectangle = this.mobjBounds;
            this.mobjBounds = bounds;
            if (this.mobjBounds != rectangle)
            {
                this.OnBoundsChanged();
            }
            if (this.mobjBounds.Location != rectangle.Location)
            {
                this.OnLocationChanged(EventArgs.Empty);
            }
        }

        internal void SetBounds(int x, int y, int width, int height)
        {
            this.SetBounds(new Rectangle(x, y, width, height));
        }

        ///<summary>Raises the AvailableChanged event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnAvailableChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.AvailableChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackColorChanged(EventArgs e)
        {
            this.Invalidate();

            EventHandler objEventHandler = this.BackColorChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.</summary>
        protected virtual void OnBoundsChanged()
        {
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(EventArgs objEventArgs)
        {
            // Create mouse event arguments.
            MouseEventArgs objMouseEventArgs = objEventArgs as MouseEventArgs;
            if (objMouseEventArgs == null)
            {
                objMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            }

            // Raise mouse down evnet.
            OnMouseDown(objMouseEventArgs);

            // Raise the click handler.
            EventHandler objEventHandler = this.ClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }

            // Raise mouse up evnet.
            OnMouseUp(objMouseEventArgs);

            // Get owner strip.
            ToolStrip objOwner = this.Owner;
            if (objOwner != null)
            {
                // Raise the itme clicked event.
                objOwner.OnItemClicked(new ToolStripItemClickedEventArgs(this));
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyleChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDisplayStyleChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.DisplayStyleChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDoubleClick(EventArgs e)
        {
            EventHandler objEventHandler = this.DoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragEnter"></see> event.</summary> 
        ///<param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnDragEnter(DragEventArgs dragEvent)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragLeave"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnDragLeave(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragOver"></see> event.</summary> 
        ///<param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnDragOver(DragEventArgs dragEvent)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        void IDropTarget.OnDragDrop(DragEventArgs dragEvent)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        void IDropTarget.OnDragEnter(DragEventArgs dragEvent)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        void IDropTarget.OnDragLeave(EventArgs e)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        void IDropTarget.OnDragOver(DragEventArgs dragEvent)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.EnabledChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.EnabledChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnFontChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Always)]
        protected virtual void OnForeColorChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.ForeColorChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.GiveFeedback"></see> event.</summary> 
        ///<param name="giveFeedbackEvent">A <see cref="T:Gizmox.WebGUI.Forms.GiveFeedbackEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnGiveFeedback(GiveFeedbackEventArgs giveFeedbackEvent)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.LocationChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnLocationChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.LocationChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseDown"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            MouseEventHandler objEventHandler = this.MouseDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseEnter"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMouseEnter(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseHover"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMouseHover(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseLeave"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMouseLeave(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseMove"></see> event.</summary> 
        ///<param name="mea">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMouseMove(MouseEventArgs mea)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseUp"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            MouseEventHandler objEventHandler = this.MouseUpHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.OwnerChanged"></see> event. </summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnOwnerChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.OwnerChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.Owner != null)
            {
                if ((menmRightToLeft == RightToLeft.Inherit) && (this.RightToLeft != this.DefaultRightToLeft))
                {
                    this.OnRightToLeftChanged(EventArgs.Empty);
                }
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Paint"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnPaint(PaintEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentBackColorChanged(EventArgs e)
        {
            if (mobjBackColor.IsEmpty)
            {
                this.OnBackColorChanged(e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary> 
        ///<param name="oldParent">The original parent of the item. </param> 
        ///<param name="newParent">The new parent of the item. </param>
        protected virtual void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentForeColorChanged(EventArgs e)
        {
            if (mobjForeColor.IsEmpty)
            {
                this.OnForeColorChanged(e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.QueryContinueDrag"></see> event.</summary> 
        ///<param name="queryContinueDragEvent">A <see cref="T:Gizmox.WebGUI.Forms.QueryContinueDragEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs queryContinueDragEvent)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeftChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnRightToLeftChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.RightToLeftChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ParentEnabledChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnParentEnabledChanged(EventArgs e)
        {
            this.OnEnabledChanged(EventArgs.Empty);
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.TextChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Always)]
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.TextChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.VisibleChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnVisibleChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.VisibleChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Activates the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> when it is clicked with the mouse.</summary>
        public void PerformClick()
        {
            this.OnClick(new EventArgs());
        }

        ///<summary>This method is not relevant to this class.</summary> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBackColor()
        {
            this.BackColor = Color.Empty;
        }

        ///<summary>This method is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetDisplayStyle()
        {
            this.DisplayStyle = this.DefaultDisplayStyle;
        }

        ///<summary>This method is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetFont()
        {
            this.Font = null;
        }

        /// <summary>
        /// Sets the owner.
        /// </summary>
        /// <param name="newOwner">The new owner.</param>
        internal void SetOwner(ToolStrip objNewOwner)
        {
            if (this.OwnerInternal != objNewOwner)
            {
                Font objFont = this.Font;

                this.ParentInternal = this.OwnerInternal = objNewOwner;

                this.OnOwnerChanged(EventArgs.Empty);

                if (objFont != this.Font)
                {
                    this.OnFontChanged(EventArgs.Empty);
                }
            }
        }

        ///<summary>This method is not relevant to this class.</summary> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetForeColor()
        {
            this.ForeColor = Color.Empty;
        }

        /// <summary>
        /// Gets the owner font.
        /// </summary>
        /// <returns></returns>
        private Font GetOwnerFont()
        {
            if (this.Owner != null)
            {
                return this.Owner.Font;
            }
            return null;
        }

        /// <summary>
        /// Gets the name of the client component.
        /// </summary>
        /// <returns></returns>
        protected override string GetClientComponentName()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets the client component ID.
        /// </summary>
        /// <returns></returns>
        protected override string GetClientComponentID()
        {
            if (this.Owner != null)
            {
                return string.Format("{0}_{1}", this.Owner.ID, this.MemberID);
            }

            return base.GetClientComponentID();
        }

        /// <summary>This method is not relevant to this class.</summary>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetImage()
        {
            this.Image = null;
        }

        ///<summary>This method is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetMargin()
        {
            this.mobjMargin = DefaultMargin;
        }

        ///<summary>This method is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetPadding()
        {
            this.mobjPadding = DefaultPadding;
        }

        ///<summary>This method is not relevant to this class.</summary> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetRightToLeft()
        {
            this.RightToLeft = RightToLeft.Inherit;
        }

        ///<summary>This method is not relevant to this class.</summary> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetTextDirection()
        {
            this.TextDirection = ToolStripTextDirection.Inherit;
        }

        ///<summary>Selects the item.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Select()
        {
            if (((this.CanSelect && ((this.Owner == null))) && ((this.ParentInternal == null))) && !this.Selected)
            {
                if ((this.IsOnDropDown && (this.OwnerItem != null)) && this.OwnerItem.IsOnDropDown)
                {
                    this.OwnerItem.Select();
                }
            }
        }

        /// <summary>Sets the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to the specified visible state. </summary>
        /// <param name="visible">true to make the <see cref="T:System.Windows.Forms.ToolStripItem"></see> visible; otherwise, false.</param>
        protected virtual void SetVisibleCore(bool visible)
        {
            if (this.GetState(ComponentState.Visible) != visible)
            {
                this.SetState(ComponentState.Visible, visible);

                this.OnAvailableChanged(EventArgs.Empty);
                this.OnVisibleChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sets the bounds.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="specified">The specified.</param>
        void IArrangedElement.SetBounds(Rectangle bounds, BoundsSpecified specified)
        {
            this.SetBounds(bounds);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <returns></returns>
        T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty)
        {
            return this.GetValue<T>(objSerializableProperty);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <param name="objValue">The obj value.</param>
        void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)
        {
            this.SetValue<T>(objSerializableProperty, objValue);
        }

        /// <summary>
        /// Disposes the specified component.
        /// </summary>
        /// <param name="blnDisposing"></param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                if (this.Owner != null)
                {
                    this.Owner.Items.Remove(this);
                }
            }
            base.Dispose(blnDisposing);
        }

        #region Render

        /// <summary>
        /// Fires the tool strip item event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void FireToolStripItemEvent(IEvent objEvent)
        {
            this.FireEvent(objEvent);
        }

        /// <summary>
        /// Pres the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal virtual void PreRenderToolStripItem(IContext objContext, long lngRequestID)
        {
        }

        /// <summary>
        /// Posts the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal virtual void PostRenderToolStripItem(IContext objContext, long lngRequestID)
        {
            // Reset  params.
            this.ResetParams();
        }

        /// <summary>
        /// Renders a tool strip item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal virtual void RenderToolStripItem(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Check if item is dirty.
            if (this.IsDirty(lngRequestID))
            {
                // write control element tags
                objWriter.WriteStartElement(WGConst.ControlsPrefix, WGTags.ToolStripItem, WGConst.ControlsNamespace);

                // Render the tool strip item's attributes.
                RenderToolStripItemAttributes(objContext, (IAttributeWriter)objWriter);

                // Render the tool strip item's controls.
                RenderToolStripItemControls(objContext, objWriter, lngRequestID);

                // close control element tag
                objWriter.WriteEndElement();
            }

            // Check if only item's params are dirty.
            else if (IsDirtyAttributes(lngRequestID))
            {
                // write control element tags
                objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);

                // Render item's updated attributes.
                RenderToolStripItemUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);

                // Check if item is visible.
                if (this.Visible)
                {
                    // Render the tool strip item's controls.
                    RenderToolStripItemControls(objContext, objWriter, lngRequestID);
                }

                // close control element tag
                objWriter.WriteEndElement();
            }

            // Check if item is visible.
            else if (this.Visible)
            {
                // Render the tool strip item's controls.
                RenderToolStripItemControls(objContext, objWriter, lngRequestID);

            }
        }

        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected virtual void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            // Render the Item's Member id and Owner id
            if(this.IsDirtyAttributes(lngRequestID))
            {
                RenderComponentID(objAttributeWriter);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the text align attribute.
                RenderTextAlignAttribute(objAttributeWriter);

                // Renders the image align attribute.
                RenderImageAlignAttribute(objAttributeWriter);

                // Renders the image attribute.
                RenderImageAttribute(objAttributeWriter, true);

				// Renders forecolor attribute.
                RenderForeColorAttribute(objAttributeWriter, true);

                // Renders the Text-Image relation attribute.
                RenderTextImageRelationAttribute(objAttributeWriter, true);

                // Renders the visible attribute.
                RenderVisibleAttribute(objAttributeWriter, true);

                // Renders the Alighment attribute
                RenderAlignmentAttribute(objAttributeWriter);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Renders the enabled attribute.
                RenderEnabledAttribute(objAttributeWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                // Renders the size attributes.
                RenderSizeAttributes(objAttributeWriter, true);

                // Renders the AutoSize attribute.
                RenderAutoSizeAttributes(objAttributeWriter, true);

                // Renders the ImageScaling attribute.
                RenderImageScalingAttribute(objAttributeWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
            {
                //Render the title attribute for tooltip support
                RenderToolTipAttribute(objAttributeWriter, false);
            }
        }


        /// <summary>
        /// Renders the tool strip item's controls.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected virtual void RenderToolStripItemControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            
        }

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected virtual void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            // Render component attributes
            RenderComponentAttributes(objContext, objAttributeWriter);

            // Check the tool strip item's type.
            int intToolStripItemType = this.ToolStripItemType;
            if (intToolStripItemType >= 0)
            {
                // Render the tool strip item's type.
                objAttributeWriter.WriteAttributeString(WGAttributes.Type, intToolStripItemType.ToString());
            }

            // Render the HideOnWrap attribute - if needed.
            if (this.HideOnWrap)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.HideOnWrap, "1");
            }

            //Renders the custom style attribute
            if (this.CustomStyle != "") objAttributeWriter.WriteAttributeString(WGAttributes.CustomStyle, CustomStyle);

            // Renders the size attributes.
            RenderSizeAttributes(objAttributeWriter, false);

            // Renders the AutoSize attributes.
            RenderAutoSizeAttributes(objAttributeWriter,false);

            // Renders the text align attribute.
            RenderTextAlignAttribute(objAttributeWriter);

            // Renders the image align attribute.
            RenderImageAlignAttribute(objAttributeWriter);

            // Renders the image attribute.
            RenderImageAttribute(objAttributeWriter, false);

            // Renders the enabled attribute.
            RenderEnabledAttribute(objAttributeWriter, false);

            // Renders the visible attribute.
            RenderVisibleAttribute(objAttributeWriter, false);

            // Renders the Alighment attribute
            RenderAlignmentAttribute(objAttributeWriter);

            // Renders Font attribute.
            RenderFontAttribute(objAttributeWriter, false);

			// Renders ForeColor attribute.
            RenderForeColorAttribute(objAttributeWriter, false);

            // Renders ForeColor attribute.
            RenderBackColorAttribute(objAttributeWriter, false);

            // Renders the Text-Image relation attribute.
            RenderTextImageRelationAttribute(objAttributeWriter, false);

            // Renders the ImageScaling attribute.
            RenderImageScalingAttribute(objAttributeWriter, false);

            //Render the title attribute for tooltip support
            RenderToolTipAttribute(objAttributeWriter, false);
        }

        /// <summary>
        /// Renders the tool tip attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderToolTipAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (blnForceRender || (!String.IsNullOrEmpty(this.ToolTipText)))
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Title, this.ToolTipText);
            }
        }

        /// <summary>
        /// Renders the font attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderFontAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (blnForceRender || this.ShouldRenderFont())
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(this.Font));
            }
        }

        /// <summary>
        /// Renders the fore color attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderForeColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (blnForceRender || this.ShouldRenderForeColor())
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(this.ForeColor));
            }
        }

        /// <summary>
        /// Renders the back color attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderBackColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (blnForceRender || ShouldSerializeBackColor())
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(this.BackColor));
            }
        }

        /// <summary>
        /// Renders the size attributes.
        /// </summary>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            Size objRenderingSize = Size.Empty;
            if (this.AutoSize)
            {
                objRenderingSize = this.GetPreferredSize(this.Size);
            }
            else
            {
                objRenderingSize.Width = this.Width;
                objRenderingSize.Height = this.Height;
            }

            // Get item's width.
            if (objRenderingSize.Width > 0 || blnForceRender)
            {
                // Render width.
                objAttributeWriter.WriteAttributeString(WGAttributes.Width, objRenderingSize.Width.ToString());
            }

            // Get item's height.
            if (objRenderingSize.Height > 0 || blnForceRender)
            {
                // Render width.
                objAttributeWriter.WriteAttributeString(WGAttributes.Height, objRenderingSize.Height.ToString());
            }
        }

        /// <summary>
        /// Renders the auto size attributes.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderAutoSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get item's AutoSize attribute.
            bool blnAutoSize = this.AutoSize;

            if (!blnAutoSize || blnForceRender)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.AutoSize, blnAutoSize ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the image attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderImageAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.ShouldRenderImage)
            {
                // Get image value.
                ResourceHandle objImage = this.Image;
                if (objImage != null || blnForceRender)
                {
                    // Render the image attribute.
                    objAttributeWriter.WriteAttributeString(WGAttributes.Image, objImage != null ? objImage.ToString() : string.Empty);
                }
            }
        }

        /// <summary>
        /// Renders the enabled attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderEnabledAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (!mblnEnabled || blnForceRender)
            {
                // Render the enabled attribute.
                objAttributeWriter.WriteAttributeString(WGAttributes.Enabled, mblnEnabled ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the Visible attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderVisibleAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get image value.
            bool blnVisibled = this.Visible;

            if (!blnVisibled || blnForceRender)
            {
                // Render the Visible attribute.
                objAttributeWriter.WriteAttributeString(WGAttributes.Visible, blnVisibled ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the Item align attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        private void RenderAlignmentAttribute(IAttributeWriter objAttributeWriter)
        {
            if (this.Alignment != ToolStripItemAlignment.Left)
            {
                // Render ImageAlign.
                objAttributeWriter.WriteAttributeString(WGAttributes.HorizontalAlignment, this.Alignment == ToolStripItemAlignment.Left ? "0" : "1");
            }
        }

        /// <summary>
        /// Renders the text align attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        protected virtual void RenderTextAlignAttribute(IAttributeWriter objAttributeWriter)
        {
            if (this.ShouldRenderText)
            {
                // Render TextAlign.
                objAttributeWriter.WriteAttributeString(WGAttributes.TextAlign, this.TextAlign.ToString());
            }
        }

        /// <summary>
        /// Renders the image align attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        private void RenderImageAlignAttribute(IAttributeWriter objAttributeWriter)
        {
            if (this.ShouldRenderImage)
            {
                // Render ImageAlign.
                objAttributeWriter.WriteAttributeString(WGAttributes.ImageAlign, this.ImageAlign.ToString());
            }
        }

        /// <summary>
        /// Renders the text image relation attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderTextImageRelationAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get the relation value.
            TextImageRelation enmTextImageRelation = this.TextImageRelation;

            // Check if the value attribute should be rendered.
            if ((TextImageRelation.ImageBeforeText != enmTextImageRelation) || blnForceRender)
            {
                // Render the relation state attribute.
                objAttributeWriter.WriteAttributeText(WGAttributes.TextImageRelation, ((int)enmTextImageRelation).ToString());
            }
        }
       
        /// <summary>
        /// Renders the text image relation attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderImageScalingAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get the relation value.
            ToolStripItemImageScaling enmToolStripItemImageScaling = this.ImageScaling;

            // Check if the value attribute should be rendered.
            if ((ToolStripItemImageScaling.SizeToFit != enmToolStripItemImageScaling) || blnForceRender)
            {
                // Render the relation state attribute.
                objAttributeWriter.WriteAttributeString(WGAttributes.ImageScaling, ((int)enmToolStripItemImageScaling).ToString());
            }
        }

        /// <summary>
        /// Renders the component's ID.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderComponentID(IAttributeWriter objWriter)
        {
            // Try getting a member id.
            long lngMemberID = this.MemberID;
            if (lngMemberID > 0)
            {
                // Render memeber id.
                objWriter.WriteAttributeString(WGAttributes.MemberID, lngMemberID.ToString());
            }

            // Try getting owner id.
            long lngOwnerID = this.OwnerID;
            if (lngOwnerID > 0)
            {
                // Render owner id.
                objWriter.WriteAttributeString(WGAttributes.OwnerID, lngOwnerID.ToString());
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            bool blnIsOwnerClickCritical = false;

            // Get owner strip.
            ToolStrip objOwner = this.Owner;
            if (objOwner != null)
            {
                // Check is the item clicked event is critical.
                blnIsOwnerClickCritical = objOwner.IsCriticalEvent(ToolStrip.ItemClickedEvent);
            }

            // Check if click should be critical.
            if (blnIsOwnerClickCritical || this.ClickHandler != null || this.MouseDownHandler != null || this.MouseUpHandler != null)
            {
                objEvents.Set(WGEvents.Click);
            }

            // Check if double click should be critical.
            if (this.DoubleClickHandler != null)
            {
                objEvents.Set(WGEvents.DoubleClick);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the mouse event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        protected internal MouseEventArgs GetMouseEventArgs(IEvent objEvent)
        {
            return new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
        }

        /// <summary>
        /// Does the on click from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected internal void DoOnClickFromEvent(IEvent objEvent)
        {
            OnClick(GetMouseEventArgs(objEvent));
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "Click":
                    DoOnClickFromEvent(objEvent);
                    break;
                case "DoubleClick":
                    OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    OnDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Indicates if to render font.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderFont()
        {
            if (this.Font != null)
            {
                return !this.Font.Equals(this.SkinFont);
            }

            return false;
        }

        /// <summary>
        /// Checks whether item should render the forecolor.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderForeColor()
        {
            // Compare ForeColor value with default value (from skin).
            return !this.ForeColor.Equals(this.SkinForeColor);
        }

        #region Should Serialize Methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeBackColor()
        {
            return this.ContainsValue<Color>(ToolStripItem.mobjBackColorProperty);            
        }

        private bool ShouldSerializeDisplayStyle()
        {
            return (this.DisplayStyle != this.DefaultDisplayStyle);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeFont()
        {
            return this.ContainsValue<Font>(ToolStripItem.mobjFontProperty);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeForeColor()
        {
            return this.ContainsValue<Color>(ToolStripItem.mobjForeColorProperty);            
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeImage()
        {
            return this.ContainsValue<ResourceHandle>(ToolStripItem.mobjImageProperty);            
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeImageIndex()
        {
            return this.ContainsValue<int>(ToolStripItem.mintImageIndexProperty);                        
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeImageKey()
        {
            return this.ContainsValue<string>(ToolStripItem.mstrImageKeyProperty);            
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeImageTransparentColor()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeMargin()
        {
            return (this.Margin != this.DefaultMargin);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializePadding()
        {
            return (this.Padding != this.DefaultPadding);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeRightToLeft()
        {
            return this.ContainsValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty);            
        }

        private bool ShouldSerializeTextDirection()
        {
            return this.ContainsValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty);                        
        }

        private bool ShouldSerializeToolTipText()
        {
            return this.ContainsValue<string>(ToolStripItem.mstrToolTipTextProperty);            
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeVisible()
        {
            return !this.GetState(ComponentState.Visible);
        }
       
        #endregion

        #endregion Methods

        #region Events

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Available"></see> property changes.</summary>
        public event EventHandler AvailableChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.AvailableChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.AvailableChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the available changed handler.
        /// </summary>
        /// <value>The available changed handler.</value>
        private EventHandler AvailableChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.AvailableChangedEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.BackColor"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler BackColorChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.BackColorChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.BackColorChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the back color changed handler.
        /// </summary>
        /// <value>The back color changed handler.</value>
        private EventHandler BackColorChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.BackColorChangedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.</summary> 
        ///<filterpriority>1</filterpriority>
        public virtual event EventHandler Click
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.ClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.ClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the click handler.
        /// </summary>
        /// <value>The click handler.</value>
        private EventHandler ClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.ClickEvent);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyle"></see> has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler DisplayStyleChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.DisplayStyleChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.DisplayStyleChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the DisplayStyleChanged handler.
        /// </summary>
        /// <value>The DisplayStyleChanged handler.</value>
        private EventHandler DisplayStyleChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.DisplayStyleChangedEvent);
            }
        }

        ///<summary>Occurs when the item is double-clicked with the mouse.</summary> 
        ///<filterpriority>1</filterpriority>
        public virtual event EventHandler DoubleClick
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.DoubleClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.DoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the DoubleClick handler.
        /// </summary>
        /// <value>The DoubleClick handler.</value>
        private EventHandler DoubleClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.DoubleClickEvent);
            }
        }

        ///<summary>Occurs when the user drags an item into the client area of this item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event DragEventHandler DragEnter
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the user drags an item and the mouse pointer is no longer over the client area of this item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DragLeave
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the user drags an item over the client area of this item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event DragEventHandler DragOver
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property value has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler EnabledChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.EnabledChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.EnabledChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the EnabledChanged handler.
        /// </summary>
        /// <value>The EnabledChanged handler.</value>
        private EventHandler EnabledChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.EnabledChangedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ForeColor"></see> property value changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler ForeColorChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.ForeColorChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.ForeColorChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the ForeColorChanged handler.
        /// </summary>
        /// <value>The ForeColorChanged handler.</value>
        private EventHandler ForeColorChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.ForeColorChangedEvent);
            }
        }

        ///<summary>Occurs during a drag operation.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event GiveFeedbackEventHandler GiveFeedback
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the location of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is updated.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler LocationChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.LocationChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.LocationChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the LocationChanged handler.
        /// </summary>
        /// <value>The LocationChanged handler.</value>
        private EventHandler LocationChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.LocationChangedEvent);
            }
        }

        ///<summary>Occurs when the mouse pointer is over the item and a mouse button is pressed.</summary> 
        ///<filterpriority>1</filterpriority>
        public virtual event MouseEventHandler MouseDown
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.MouseDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.MouseDownEvent, value);
            }
        }

        /// <summary>
        /// Gets the MouseDown handler.
        /// </summary>
        /// <value>The MouseDown handler.</value>
        private MouseEventHandler MouseDownHandler
        {
            get
            {
                return (MouseEventHandler)this.GetHandler(ToolStripItem.MouseDownEvent);
            }
        }

        ///<summary>Occurs when the mouse pointer enters the item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MouseEnter
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the mouse pointer hovers over the item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MouseHover
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the mouse pointer leaves the item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MouseLeave
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the mouse pointer is moved over the item.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event MouseEventHandler MouseMove
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the mouse pointer is over the item and a mouse button is released.</summary> 
        ///<filterpriority>1</filterpriority>
        public virtual event MouseEventHandler MouseUp
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.MouseUpEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.MouseUpEvent, value);
            }
        }

        /// <summary>
        /// Gets the MouseUp handler.
        /// </summary>
        /// <value>The MouseUp handler.</value>
        private MouseEventHandler MouseUpHandler
        {
            get
            {
                return (MouseEventHandler)this.GetHandler(ToolStripItem.MouseUpEvent);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Owner"></see> property changes. </summary>
        public event EventHandler OwnerChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.OwnerChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.OwnerChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the OwnerChanged handler.
        /// </summary>
        /// <value>The OwnerChanged handler.</value>
        private EventHandler OwnerChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.OwnerChangedEvent);
            }
        }

        ///<summary>Occurs when the item is redrawn.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event PaintEventHandler Paint
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs during a drag-and-drop operation and allows the drag source to determine whether the drag-and-drop operation should be canceled.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event QueryContinueDragEventHandler QueryContinueDrag
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property value changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler RightToLeftChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.RightToLeftChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.RightToLeftChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the RightToLeftChanged handler.
        /// </summary>
        /// <value>The RightToLeftChanged handler.</value>
        private EventHandler RightToLeftChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.RightToLeftChangedEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public virtual event EventHandler TextChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.TextChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.TextChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the TextChanged handler.
        /// </summary>
        /// <value>The TextChanged handler.</value>
        private EventHandler TextChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.TextChangedEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Visible"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler VisibleChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripItem.VisibleChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripItem.VisibleChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the VisibleChanged handler.
        /// </summary>
        /// <value>The VisibleChanged handler.</value>
        private EventHandler VisibleChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripItem.VisibleChangedEvent);
            }
        }

        #endregion Events

        #region Properties

        #region Proprety Store

        private ToolStrip mobjParent
        {
            get
            {
                return this.GetValue<ToolStrip>(ToolStripItem.mobjParentProperty, null);
            }
            set
            {
                this.SetValue<ToolStrip>(ToolStripItem.mobjParentProperty, value);
            }
        }

        private ToolStrip mobjOwner
        {
            get
            {
                return this.GetValue<ToolStrip>(ToolStripItem.mobjOwnerProperty, null);
            }
            set
            {
                this.SetValue<ToolStrip>(ToolStripItem.mobjOwnerProperty, value);
            }
        }

        private Font mobjFont
        {
            get
            {
                return this.GetValue<Font>(ToolStripItem.mobjFontProperty);
            }
            set
            {
                this.SetValue<Font>(ToolStripItem.mobjFontProperty, value);
            }
        }

        private ToolStripItemDisplayStyle menmDisplayStyle
        {
            get
            {
                return this.GetValue<ToolStripItemDisplayStyle>(ToolStripItem.menmDisplayStyleProperty);
            }
            set
            {
                this.SetValue<ToolStripItemDisplayStyle>(ToolStripItem.menmDisplayStyleProperty, value);
            }
        }

        private Rectangle mobjBounds
        {
            get
            {
                return this.GetValue<Rectangle>(ToolStripItem.mobjBoundsProperty);
            }
            set
            {
                this.SetValue<Rectangle>(ToolStripItem.mobjBoundsProperty, value);
            }
        }

        private object mobjTag
        {
            get
            {
                return this.GetValue<object>(ToolStripItem.mobjTagProperty, null);
            }
            set
            {
                this.SetValue<object>(ToolStripItem.mobjTagProperty, value);
            }
        }

        private string mstrText
        {
            get
            {
                return this.GetValue<string>(ToolStripItem.mstrTextProperty, string.Empty);
            }
            set
            {
                this.SetValue<string>(ToolStripItem.mstrTextProperty, value);
            }
        }

        private RightToLeft menmRightToLeft
        {
            get
            {
                return this.GetValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty);
            }
            set
            {
                this.SetValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty, value);
            }
        }

        internal bool mblnEnabled
        {
            get
            {
                return this.GetValue<bool>(ToolStripItem.mblnEnabledProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripItem.mblnEnabledProperty, value);
            }
        }

        private bool mblnDoubleClickEnabled
        {
            get
            {
                return this.GetValue<bool>(ToolStripItem.mblnDoubleClickEnabledProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripItem.mblnDoubleClickEnabledProperty, value);
            }
        }

        private DockStyle menmDock
        {
            get
            {
                return this.GetValue<DockStyle>(ToolStripItem.menmDockProperty);
            }
            set
            {
                this.SetValue<DockStyle>(ToolStripItem.menmDockProperty, value);
            }
        }

        private ImageLayout menmBackgroundImageLayout
        {
            get
            {
                return this.GetValue<ImageLayout>(ToolStripItem.menmBackgroundImageLayoutProperty, ImageLayout.Tile);
            }
            set
            {
                this.SetValue<ImageLayout>(ToolStripItem.menmBackgroundImageLayoutProperty, value);
            }
        }

        private ResourceHandle mobjBackgroundImage
        {
            get
            {
                return this.GetValue<ResourceHandle>(ToolStripItem.mobjBackgroundImageProperty, null);
            }
            set
            {
                this.SetValue<ResourceHandle>(ToolStripItem.mobjBackgroundImageProperty, value);
            }
        }

        private Color mobjBackColor
        {
            get
            {
                return this.GetValue<Color>(ToolStripItem.mobjBackColorProperty, Color.Empty);
            }
            set
            {
                this.SetValue<Color>(ToolStripItem.mobjBackColorProperty, value);
            }
        }

        private ToolStripItemAlignment menmAlignment
        {
            get
            {
                return this.GetValue<ToolStripItemAlignment>(ToolStripItem.menmAlignmentProperty);
            }
            set
            {
                this.SetValue<ToolStripItemAlignment>(ToolStripItem.menmAlignmentProperty, value);
            }
        }

        private AnchorStyles menmAnchor
        {
            get
            {
                return this.GetValue<AnchorStyles>(ToolStripItem.menmAnchorProperty, AnchorStyles.Left | AnchorStyles.Top);
            }
            set
            {
                this.SetValue<AnchorStyles>(ToolStripItem.menmAnchorProperty, value, AnchorStyles.Left | AnchorStyles.Top);
            }
        }

        private bool mblnAutoSize
        {
            get
            {
                return this.GetValue<bool>(ToolStripItem.mblnAutoSizeProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripItem.mblnAutoSizeProperty, value);
            }
        }

        private bool mblnAutoToolTip
        {
            get
            {
                return this.GetValue<bool>(ToolStripItem.mblnAutoToolTipProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripItem.mblnAutoToolTipProperty, value);
            }
        }

        private Color mobjForeColor
        {
            get
            {
                return this.GetValue<Color>(ToolStripItem.mobjForeColorProperty);
            }
            set
            {
                this.SetValue<Color>(ToolStripItem.mobjForeColorProperty, value);
            }
        }

        private ResourceHandle mobjImage
        {
            get
            {
                return this.GetValue<ResourceHandle>(ToolStripItem.mobjImageProperty, null);
            }
            set
            {
                this.SetValue<ResourceHandle>(ToolStripItem.mobjImageProperty, value);
            }
        }

        private ContentAlignment menmImageAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(ToolStripItem.menmImageAlignProperty);
            }
            set
            {
                this.SetValue<ContentAlignment>(ToolStripItem.menmImageAlignProperty, value);
            }
        }

        private int mintImageIndex
        {
            get
            {
                return this.GetValue<int>(ToolStripItem.mintImageIndexProperty, -1);
            }
            set
            {
                this.SetValue<int>(ToolStripItem.mintImageIndexProperty, value);
            }
        }

        private string mstrImageKey
        {
            get
            {
                return this.GetValue<string>(ToolStripItem.mstrImageKeyProperty, string.Empty);
            }
            set
            {
                this.SetValue<string>(ToolStripItem.mstrImageKeyProperty, value);
            }
        }

        private Padding mobjMargin
        {
            get
            {
                return this.GetValue<Padding>(ToolStripItem.mobjMarginProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStripItem.mobjMarginProperty, value);
            }
        }

        private MergeAction menmMergeAction
        {
            get
            {
                return this.GetValue<MergeAction>(ToolStripItem.menmMergeActionProperty, MergeAction.Append);
            }
            set
            {
                this.SetValue<MergeAction>(ToolStripItem.menmMergeActionProperty, value);
            }
        }

        private int mintMergeIndex
        {
            get
            {
                return this.GetValue<int>(ToolStripItem.mintMergeIndexProperty);
            }
            set
            {
                this.SetValue<int>(ToolStripItem.mintMergeIndexProperty, value);
            }
        }

        private string mstrName
        {
            get
            {
                return this.GetValue<string>(ToolStripItem.mstrNameProperty, string.Empty);
            }
            set
            {
                this.SetValue<string>(ToolStripItem.mstrNameProperty, value);
            }
        }

        private Padding mobjPadding
        {
            get
            {
                return this.GetValue<Padding>(ToolStripItem.mobjPaddingProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStripItem.mobjPaddingProperty, value);
            }
        }

        private ToolStripItemPlacement menmPlacement
        {
            get
            {
                return this.GetValue<ToolStripItemPlacement>(ToolStripItem.menmPlacementProperty);
            }
            set
            {
                this.SetValue<ToolStripItemPlacement>(ToolStripItem.menmPlacementProperty, value);
            }
        }

        private bool mblnRightToLeftAutoMirrorImage
        {
            get
            {
                return this.GetValue<bool>(ToolStripItem.mblnRightToLeftAutoMirrorImageProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripItem.mblnRightToLeftAutoMirrorImageProperty, value);
            }
        }

        private ContentAlignment menmTextAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(ToolStripItem.menmTextAlignProperty);
            }
            set
            {
                this.SetValue<ContentAlignment>(ToolStripItem.menmTextAlignProperty, value);
            }
        }

        private ToolStripTextDirection menmTextDirection
        {
            get
            {
                return this.GetValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty, ToolStripTextDirection.Inherit);
            }
            set
            {
                this.SetValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty, value);
            }
        }

        private TextImageRelation menmTextImageRelation
        {
            get
            {
                return this.GetValue<TextImageRelation>(ToolStripItem.menmTextImageRelationProperty);
            }
            set
            {
                this.SetValue<TextImageRelation>(ToolStripItem.menmTextImageRelationProperty, value);
            }
        }

		private string mstrToolTipText
        {
            get
            {
                return this.GetValue<string>(ToolStripItem.mstrToolTipTextProperty);
            }
            set
            {
                this.SetValue<string>(ToolStripItem.mstrToolTipTextProperty, value);
            }
        }

        #endregion

		private ToolStripItemImageScaling menmImageScaling
        {
            get
            {
                return this.GetValue<ToolStripItemImageScaling>(ToolStripItem.memnImageScalingProperty);
                
            }
            set
            {
                this.SetValue<ToolStripItemImageScaling>(ToolStripItem.memnImageScalingProperty, value);
            }
        }

        /// <summary>
        /// Gets the font from skin.
        /// </summary>
        /// <value>
        /// The color of the skin fore.
        /// </value>
        protected virtual Font SkinFont
        {
            get
            {
                // Init result to default.
                Font objFont = null;

                // Get skin.            
                CommonSkin objSkin = SkinFactory.GetSkin(this) as CommonSkin;
                if (objSkin != null)
                {
                    // Get forecolor value.
                    objFont = objSkin.Font;
                }

                return objFont;
            }
        }

		/// <summary>
        /// Gets the forecolor from skin.
        /// </summary>
        /// <value>
        /// The color of the skin fore.
        /// </value>
        protected virtual Color SkinForeColor
        {
            get
            {
                // Init result to default.
                Color objColor = Color.Empty;

                // Get skin.            
                CommonSkin objSkin = SkinFactory.GetSkin(this) as CommonSkin;
                if (objSkin != null)
                {
                    // Get forecolor value.
                    objColor = objSkin.ForeColor;
                }

                return objColor;
            }
        }


        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected virtual int ToolStripItemType
        {
            get
            {
                return -1;
            }
        }

        ///<summary>Gets or sets a value indicating whether the item aligns towards the beginning or end of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Left"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. </exception> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ToolStripItemAlignmentDescr"), DefaultValue(ToolStripItemAlignment.Left), SRCategory("CatLayout")]
        public ToolStripItemAlignment Alignment
        {
            get
            {
                return this.menmAlignment;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripItemAlignment));
                }
                if (this.menmAlignment != value)
                {
                    this.menmAlignment = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary> 
        ///<returns>true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.</returns> 
        ///<exception cref="T:System.ArgumentException"> 
        ///  <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool AllowDrop
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the edges of the container to which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is bound and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>  is resized with its parent.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</exception> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(AnchorStyles.Left | AnchorStyles.Top)]
        public AnchorStyles Anchor
        {
            get
            {
                return menmAnchor;
            }
            set
            {
                if (value != this.Anchor)
                {
                    menmAnchor = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the item is automatically sized.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically sized; otherwise, false. The default value is true.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ToolStripItemAutoSizeDescr"), SRCategory("CatBehavior"), DefaultValue(true), Localizable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), RefreshProperties(RefreshProperties.All)]
        public bool AutoSize
        {
            get
            {
                return mblnAutoSize;
            }
            set
            {
                if (mblnAutoSize != value)
                {
                    // Set the new value for AutoSize property
                    mblnAutoSize = value;

                    if (!this.DesignMode)
                    {
                        // Invalidates parent layout.
                        this.InvalidateParentLayout();
                    }
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> ToolTip. </summary> 
        ///<returns>true to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(false), SRDescription("ToolStripItemAutoToolTipDescr"), SRCategory("CatBehavior")]
        public bool AutoToolTip
        {
            get
            {
                return mblnAutoToolTip;
            }
            set
            {
                if (mblnAutoToolTip != value)
                {
                    mblnAutoToolTip = value;
                    this.UpdateParams(AttributeType.ToolTip);
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> should be placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false.</returns>
        [SRDescription("ToolStripItemAvailableDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Available
        {
            get
            {
                return this.GetState(ComponentState.Visible);
            }
            set
            {
                if (this.Available != value)
                {
                    this.SetVisibleCore(value);
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets the background color for the item.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripItemBackColorDescr")]
        public virtual Color BackColor
        {
            get
            {
                if (!mobjBackColor.IsEmpty)
                {
                    return mobjBackColor;
                }
                Control parentInternal = this.ParentInternal;
                if (parentInternal != null)
                {
                    return parentInternal.BackColor;
                }

                return Color.FromKnownColor(KnownColor.Control); // TODO: Get color from skin.
            }
            set
            {
                Color backColor = this.BackColor;
                if (!value.IsEmpty)
                {
                    this.mobjBackColor = value;
                }
                if (!backColor.Equals(this.BackColor))
                {
                    this.OnBackColorChanged(EventArgs.Empty);
                    // TODO: Update client
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>
        /// The background image.
        /// </value>
        [DefaultValue((string)null), SRDescription("ToolStripItemImageDescr"), Localizable(true), SRCategory("CatAppearance")]
        public virtual ResourceHandle BackgroundImage
        {
            get
            {
                return mobjBackgroundImage;
            }
            set
            {
                if (this.BackgroundImage != value)
                {
                    mobjBackgroundImage = value;

                    this.Invalidate();
                }
            }
        }

        ///<summary>Gets or sets the background image layout used for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), SRDescription("ControlBackgroundImageLayoutDescr"), DefaultValue(ImageLayout.Tile), Localizable(true)]
        public virtual ImageLayout BackgroundImageLayout
        {
            get
            {
                return menmBackgroundImageLayout;
            }
            set
            {
                if (this.BackgroundImageLayout != value)
                {
                    if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
                    {
                        throw new InvalidEnumArgumentException("value", (int)value, typeof(ImageLayout));
                    }
                    menmBackgroundImageLayout = value;

                    this.Invalidate();
                }
            }
        }

        ///<summary>Gets the size and location of the item.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual Rectangle Bounds
        {
            get
            {
                return this.mobjBounds;
            }
        }

        ///<summary>Gets a value indicating whether the item can be selected.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be selected; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual bool CanSelect
        {
            get
            {
                return true;
            }
        }

        ///<summary>Gets the area where content, such as text and icons, can be placed within a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> without overwriting background borders.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> containing four integers that represent the location and size of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> contents, excluding its border.</returns> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ContentRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }


        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue("")]
        [SRDescription("ControlCustomStyleDescr")]
        [SRCategory("CatAppearance")]
        public virtual string CustomStyle
        {
            get
            {
                return this.GetValue<string>(ToolStripItem.mstrCustomStyleProperty);
            }
            set
            {
                // Set the value and the value had changed update the control
                if (this.SetValue<string>(ToolStripItem.mstrCustomStyleProperty, value))
                {                    
                    this.Invalidate();
                }
            }
        }

        ///<summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary> 
        ///<returns>false in all cases.</returns>
        protected virtual bool DefaultAutoToolTip
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets the default margin of an item.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> representing the margin.</returns>
        protected internal virtual Padding DefaultMargin
        {
            get
            {
                if ((this.Owner != null) && (this.Owner is StatusStrip))
                {
                    return new Padding(0, 2, 0, 0);
                }
                return new Padding(0, 1, 0, 2);
            }
        }

        /// <summary>Gets the internal spacing characteristics of the item.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.Padding"></see> values.</returns>
        protected virtual Padding DefaultPadding
        {
            get
            {
                return Padding.Empty;
            }
        }

        ///<summary>Gets a value indicating what is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see>.</returns>
        protected virtual ToolStripItemDisplayStyle DefaultDisplayStyle
        {
            get
            {
                return ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        ///<summary>Gets the internal spacing characteristics of the item.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
        protected virtual Size DefaultSize
        {
            get
            {
                return new Size(0x17, 0x17);
            }
        }

        ///<summary>Gets or sets whether text and images are displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see> .</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemDisplayStyleDescr"), SRCategory("CatAppearance")]
        public virtual ToolStripItemDisplayStyle DisplayStyle
        {
            get
            {
                return this.menmDisplayStyle;
            }
            set
            {
                if (this.menmDisplayStyle != value)
                {
                    if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                    {
                        throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripItemDisplayStyle));
                    }
                    this.menmDisplayStyle = value;
                    this.OnDisplayStyleChanged(new EventArgs());

                    ToolStrip objOwner = this.Owner;
                    if (objOwner != null)
                    {
                        objOwner.Update();
                    }
                }
            }
        }

        ///<summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is resized with its parent.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.None"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values.</exception> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(DockStyle.None), Browsable(false)]
        public DockStyle Dock
        {
            get
            {
                return menmDock;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 5))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DockStyle));
                }
                if (value != this.Dock)
                {
                    menmDock = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse. </summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse; otherwise, false. The default is false.</returns>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("ToolStripItemDoubleClickedEnabledDescr")]
        public bool DoubleClickEnabled
        {
            get
            {
                return mblnDoubleClickEnabled;
            }
            set
            {
                if (mblnDoubleClickEnabled != value)
                {
                    mblnDoubleClickEnabled = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled. </summary> 
        ///<returns>true if the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemEnabledDescr"), Localizable(true), DefaultValue(true), SRCategory("CatBehavior")]
        public virtual bool Enabled
        {
            get
            {
                bool enabled = true;
                if (this.Owner != null)
                {
                    enabled = this.Owner.Enabled;
                }
                return (mblnEnabled && enabled);
            }
            set
            {
                if (mblnEnabled != value)
                {
                    mblnEnabled = value;
                    this.OnEnabledChanged(EventArgs.Empty);

                    // Update params.
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        ///<summary>Gets or sets the font of the text displayed by the item.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultFont"></see> property.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripItemFontDescr"), Localizable(true)]
        public virtual Font Font
        {
            get
            {
                if (mobjFont == null)
                {
                    Font objOwnerFont = this.GetOwnerFont();
                    if (objOwnerFont != null)
                    {
                        return objOwnerFont;
                    }
                }

                return mobjFont;
            }
            set
            {
                if (mobjFont != value)
                {
                    mobjFont = value;
                    this.OnFontChanged(EventArgs.Empty);
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets the foreground color of the item.</summary> 
        ///<returns>The foreground <see cref="T:System.Drawing.Color"></see> of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultForeColor"></see> property.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemForeColorDescr"), SRCategory("CatAppearance")]
        public virtual Color ForeColor
        {
            get
            {
                // Try to get current forecolor value.
                Color objColor = mobjForeColor;
                if (!objColor.IsEmpty)
                {
                    return objColor;
                }

                ToolStrip objOwner = this.Owner;
                if (objOwner != null)
                {
                    if (objOwner.HasForeColor)
                    {
                        Color objForeColor = objOwner.ForeColor;
                        if (!objForeColor.IsEmpty)
                        {
                            return objForeColor;
                        }
                    }
                }

                // Otherwise, get skin forecolor.
                return this.SkinForeColor;
            }
            set
            {
                Color foreColor = this.ForeColor;
                if (!value.IsEmpty)
                {
                    mobjForeColor = value;
                }

                if (!foreColor.Equals(this.ForeColor))
                {
                    this.OnForeColorChanged(EventArgs.Empty);

                    UpdateParams(AttributeType.Visual);
                    
                }
            }
        }
        ///<summary>Gets or sets the height, in pixels, of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the height, in pixels.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), SRCategory("CatLayout"), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Height
        {
            get
            {
                return this.Bounds.Height;
            }
            set
            {
                Rectangle bounds = this.Bounds;

                if (bounds.Height != value)
                {
                    this.SetBounds(bounds.X, bounds.Y, bounds.Width, value);

                    // Update params.
                    this.UpdateParams(AttributeType.Layout);
                }
            }
        }

        /// <summary>Gets or sets the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStrip"></see> that is the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        protected internal ToolStrip Parent
        {
            get
            {
                return this.ParentInternal;
            }
            set
            {
                this.ParentInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the context menu code.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ContextMenu ContextMenu
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
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
        /// </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ContextMenuStrip ContextMenuStrip
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

        ///<summary>Gets or sets the image that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripItemImageDescr"), Localizable(true)]
        public virtual ResourceHandle Image
        {
            get
            {
                ResourceHandle objImage = mobjImage;

                if(objImage == null && this.Owner != null && this.Owner.ImageList != null)
                {
                    int intImageIndex = this.ImageIndex;
                    if (intImageIndex >= 0)
                    {
                        if (intImageIndex < this.Owner.ImageList.Images.Count)
                        {
                            return mobjImage = objImage = this.Owner.ImageList.Images[intImageIndex];
                    }
                    }
                    else
                    {
                        string strImageKey = this.ImageKey;
                        if (!string.IsNullOrEmpty(strImageKey))
                        {
                            return mobjImage = objImage = this.Owner.ImageList.Images[strImageKey];
                        }
                    }

                    return null;
                }

                return objImage;
            }
            set
            {
                if (this.Image != value)
                {
                    if (value != null)
                    {
                        this.ImageIndex = -1;
                    }

                    mobjImage = value;

                    // Update params.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets the alignment of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DefaultValue(ContentAlignment.MiddleCenter), SRDescription("ToolStripItemImageAlignDescr"), Localizable(true), SRCategory("CatAppearance")]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.menmImageAlign;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                }
                if (this.menmImageAlign != value)
                {
                    this.menmImageAlign = value;

                    // Update params.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets the index value of the image that is displayed on the item.</summary> 
        ///<returns>The zero-based index of the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed for the item. The default is -1, signifying that the image list is empty.</returns> 
        ///<exception cref="T:System.ArgumentException">The value specified is less than -1. </exception> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemImageIndexDescr"), RelatedImageList("Owner.ImageList"), RefreshProperties(RefreshProperties.Repaint), Browsable(false), SRCategory("CatBehavior"), Localizable(true)]
        public int ImageIndex
        {
            get
            {
                if (((this.Owner != null) && (mintImageIndex != -1)) && ((this.Owner.ImageList != null) && (mintImageIndex >= this.Owner.ImageList.Images.Count)))
                {
                    return (this.Owner.ImageList.Images.Count - 1);
                }
                return mintImageIndex;
            }
            set
            {
                if (value < -1)
                {
                    object[] args = new object[] { "ImageIndex", value.ToString(CultureInfo.CurrentCulture), (-1).ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ImageIndex", SR.GetString("InvalidLowBoundArgumentEx", args));
                }

                if (mintImageIndex != value)
                {
                    mintImageIndex = value;

                    this.mobjImage = null;

                    mstrImageKey = string.Empty;
                }
            }
        }

        ///<summary>Gets or sets the key accessor for the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>A string representing the key of the image.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [RefreshProperties(RefreshProperties.Repaint), SRCategory("CatBehavior"), Browsable(false), SRDescription("ToolStripItemImageKeyDescr"), Localizable(true), RelatedImageList("Owner.ImageList")]
        public string ImageKey
        {
            get
            {
                return mstrImageKey;
            }
            set
            {
                if (mstrImageKey != value)
                {
                    mstrImageKey = value;

                    this.mobjImage = null;

                    mintImageIndex = -1;
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically resized to fit in a container.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageScaling"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemImageScaling.SizeToFit"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), Localizable(true), SRDescription("ToolStripItemImageScalingDescr"), DefaultValue(ToolStripItemImageScaling.SizeToFit)]
        public ToolStripItemImageScaling ImageScaling
        {
            get
            {
                return this.menmImageScaling;
            }
            set
            {
                if (value != this.ImageScaling)
                {
                    this.menmImageScaling = value;

                    if (!this.DesignMode)
                    {
                        // Invalidates parent layout.
                        InvalidateParentLayout();
                    }
                }
            }
        }

        /// <summary>
        /// Invalidates the parent layout.
        /// </summary>
        private void InvalidateParentLayout()
        {
            // Check if parent exists
            if (this.ParentInternal != null)
            {
                // Tell the parent toolstrip that it is no longer valid due to an item's size change
                this.ParentInternal.InvalidateLayout(new LayoutEventArgs(true, false, false));

                // Tell the parent toolstrip that it's layout attribute should be updated
                this.ParentInternal.UpdateStripAttributes(AttributeType.Layout);

                // Update this item's layout params
                this.UpdateParams(AttributeType.Layout);
            }
        }

        ///<summary>Gets or sets the color to treat as transparent in a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image.</summary> 
        ///<returns>One of the <see cref="T:System.Drawing.Color"></see> values.</returns> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ImageTransparentColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets a value indicating whether the object has been disposed of.</summary> 
        ///<returns>true if the control has been disposed of; otherwise, false.</returns> 
        ///<filterpriority>2</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDisposed
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>. </summary> 
        ///<returns>true if the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public bool IsOnDropDown
        {
            get
            {
                if (this.ParentInternal != null)
                {
                    return this.ParentInternal.IsDropDown;
                }
                return ((this.Owner != null) && this.Owner.IsDropDown);
            }
        }

        ///<summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>.</summary> 
        ///<returns>true if the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>; otherwise, false.</returns>
        [Browsable(false)]
        public bool IsOnOverflow
        {
            get
            {
                return (this.Placement == ToolStripItemPlacement.Overflow);
            }
        }

        ///<summary>Gets or sets the space between the item and adjacent items.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between the item and adjacent items.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ToolStripItemMarginDescr"), SRCategory("CatLayout")]
        public Padding Margin
        {
            get
            {
                return mobjMargin;
            }
            set
            {
                if (this.Margin != value)
                {
                    mobjMargin = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets how child menus are merged with parent menus. </summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.MergeAction.MatchOnly"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values.</exception> 
        ///<filterpriority>2</filterpriority>
        [SRCategory("CatLayout"), SRDescription("ToolStripMergeActionDescr"), DefaultValue(MergeAction.Append)]
        public MergeAction MergeAction
        {
            get
            {
                return menmMergeAction;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(MergeAction));
                }

                if (menmMergeAction != value)
                {
                    menmMergeAction = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets the position of a merged item within the current <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>An integer representing the index of the merged item, if a match is found, or -1 if a match is not found.</returns> 
        ///<filterpriority>2</filterpriority>
        [SRDescription("ToolStripMergeIndexDescr"), SRCategory("CatLayout"), DefaultValue(-1)]
        public int MergeIndex
        {
            get
            {
                return mintMergeIndex;
            }
            set
            {
                if (mintMergeIndex != value)
                {
                    mintMergeIndex = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets the name of the item.</summary> 
        ///<returns>A string representing the name. The default value is null.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue((string)null), Browsable(false)]
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(mstrName))
                {
                    string strName = string.Empty;
                    if (this.Site != null && this.Site.DesignMode)
                    {
                        strName = Site.Name;
                    }
                    if (strName==null)
                    {
                        strName = string.Empty;
                    }

                    return strName;
                }

                return mstrName;
            }
            set
            {
                if (mstrName != value)
                {
                    mstrName = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(ToolStripItemOverflow.AsNeeded), SRDescription("ToolStripItemOverflowDescr"), SRCategory("CatLayout")]
        public ToolStripItemOverflow Overflow
        {
            get
            {
                return ToolStripItemOverflow.AsNeeded;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the owner of this item.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that owns or is to own the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStrip Owner
        {
            get
            {
                return this.OwnerInternal;
            }
            set
            {
                ToolStrip objOldOwner = this.OwnerInternal;

                if (objOldOwner != value)
                {
                    this.OwnerInternal = value;

                    if (objOldOwner != null)
                    {
                        objOldOwner.Items.Remove(this);
                        objOldOwner.Update();
                    }

                    if (value != null)
                    {
                        value.Items.Add(this);
                        value.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the owner internal.
        /// </summary>
        /// <value>The owner internal.</value>
        private ToolStrip OwnerInternal
        {
            get
            {
                return mobjOwner;
            }
            set
            {
                mobjOwner = value;
            }
        }
        

        ///<summary>Gets the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>The parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem OwnerItem
        {
            get
            {
                ToolStripDropDown objParentInternal = null;
                if (this.ParentInternal != null)
                {
                    objParentInternal = this.ParentInternal as ToolStripDropDown;
                }
                else if (this.Owner != null)
                {
                    objParentInternal = this.Owner as ToolStripDropDown;
                }
                if (objParentInternal != null)
                {
                    return objParentInternal.OwnerItem;
                }
                return null;
            }
        }

        ///<summary>Gets or sets the internal spacing, in pixels, between the item's contents and its edges.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the item's internal spacing, in pixels.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatLayout"), SRDescription("ToolStripItemPaddingDescr")]
        public virtual Padding Padding
        {
            get
            {
                return mobjPadding;
            }
            set
            {
                if (this.Padding != value)
                {
                    mobjPadding = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets the current layout of the item.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemPlacement"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public ToolStripItemPlacement Placement
        {
            get
            {
                return this.menmPlacement;
            }
        }

        ///<summary>Gets a value indicating whether the state of the item is pressed. </summary> 
        ///<returns>true if the state of the item is pressed; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Pressed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the default right to left.
        /// </summary>
        /// <value>The default right to left.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        private RightToLeft DefaultRightToLeft
        {
            get
            {
                return RightToLeft.Inherit;
            }
        }

        ///<summary>Gets or sets a value indicating whether items are to be placed from right to left and text is to be written from right to left.</summary> 
        ///<returns>true if items are to be placed from right to left and text is to be written from right to left; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemRightToLeftDescr"), SRCategory("CatAppearance"), Localizable(true)]
        public virtual RightToLeft RightToLeft
        {
            get
            {
                RightToLeft enmRightToLeft = menmRightToLeft;

                if (enmRightToLeft == RightToLeft.Inherit)
                {
                    if (this.Owner != null)
                    {
                        enmRightToLeft = this.Owner.RightToLeft;
                    }
                    else if (this.ParentInternal != null)
                    {
                        enmRightToLeft = this.ParentInternal.RightToLeft;
                    }
                    else
                    {
                        enmRightToLeft = this.DefaultRightToLeft;
                    }
                }

                return (RightToLeft)enmRightToLeft;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("RightToLeft", (int)value, typeof(RightToLeft));
                }

                RightToLeft rightToLeft = this.RightToLeft;
                if (value != RightToLeft.Inherit)
                {
                    menmRightToLeft = value;
                }

                if (rightToLeft != this.RightToLeft)
                {
                    this.OnRightToLeftChanged(EventArgs.Empty);
                    // TODO: Update client
                }
            }
        }

        ///<summary>Mirrors automatically the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Yes"></see>.</summary> 
        ///<returns>true to automatically mirror the image; otherwise, false. The default is false.</returns>
        [DefaultValue(false), Localizable(true), SRDescription("ToolStripItemRightToLeftAutoMirrorImageDescr"), SRCategory("CatAppearance")]
        public bool RightToLeftAutoMirrorImage
        {
            get
            {
                return mblnRightToLeftAutoMirrorImage;
            }
            set
            {
                if (mblnRightToLeftAutoMirrorImage != value)
                {
                    mblnRightToLeftAutoMirrorImage = value;
                    this.Invalidate();
                }
            }
        }

        ///<summary>Gets a value indicating whether the item is selected.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is selected; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Selected
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets or sets the size of the item.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Size"></see>, representing the width and height of a rectangle.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemSizeDescr"), Localizable(true), SRCategory("CatLayout")]
        public virtual Size Size
        {
            get
            {
                return this.Bounds.Size;
            }
            set
            {
                Rectangle bounds = this.Bounds;

                if (bounds.Size != value)
                {
                    bounds.Size = value;
                    this.SetBounds(bounds);
                    
                    // Update params.
                    this.UpdateParams(AttributeType.Layout);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should render text].
        /// </summary>
        /// <value><c>true</c> if [should render text]; otherwise, <c>false</c>.</value>
        protected bool ShouldRenderText
        {
            get
            {
                ToolStripItemDisplayStyle enmToolStripItemDisplayStyle = this.DisplayStyle;
                return (enmToolStripItemDisplayStyle == ToolStripItemDisplayStyle.Text || enmToolStripItemDisplayStyle == ToolStripItemDisplayStyle.ImageAndText);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should render image].
        /// </summary>
        /// <value><c>true</c> if [should render image]; otherwise, <c>false</c>.</value>
        protected bool ShouldRenderImage
        {
            get
            {
                ToolStripItemDisplayStyle enmToolStripItemDisplayStyle = this.DisplayStyle;
                return (enmToolStripItemDisplayStyle == ToolStripItemDisplayStyle.Image || enmToolStripItemDisplayStyle == ToolStripItemDisplayStyle.ImageAndText);
            }
        }

        ///<summary>Gets or sets the object that contains data about the item.</summary> 
        ///<returns>An <see cref="T:System.Object"></see> that contains data about the control. The default is null.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatData"), DefaultValue((string)null), Bindable(true), SRDescription("ToolStripItemTagDescr"), TypeConverter(typeof(StringConverter)), Localizable(false)]
        public object Tag
        {
            get
            {
                return mobjTag;
            }
            set
            {
                if (mobjTag != value)
                {
                    mobjTag = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets or sets the text that is to be displayed on the item.</summary> 
        ///<returns>A string representing the item's text. The default value is the empty string ("").</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Localizable(true), SRDescription("ToolStripItemTextDescr"), SRCategory("CatAppearance"), DefaultValue("")]
        public virtual string Text
        {
            get
            {
                return mstrText;
            }
            set
            {
                if (value != this.Text)
                {
                    mstrText = value;
                    this.OnTextChanged(EventArgs.Empty);

                    // Update params. (Visual for text data, and Layout for the sizes)
                    UpdateParams(AttributeType.Visual | AttributeType.Layout);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether to hide item on strip wrapping.
        /// </summary>
        /// <value><c>true</c> if [hide on wrap]; otherwise, <c>false</c>.</value>
        protected virtual bool HideOnWrap
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the parent internal.
        /// </summary>
        /// <value>The parent internal.</value>
        internal ToolStrip ParentInternal
        {
            get
            {
                return mobjParent;
            }
            set
            {
                ToolStrip objOldParent = this.ParentInternal;

                if (mobjParent != value)
                {
                    mobjParent = value;

                    this.OnParentChanged(objOldParent, value);

                    if (objOldParent != null)
                    {
                        objOldParent.Update();
                    }

                    if (value != null)
                    {
                        value.Update();
                    }
                }
            }
        }

        ///<summary>Gets or sets the alignment of the text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
        ///<returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleRight"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemTextAlignDescr"), SRCategory("CatAppearance"), DefaultValue(ContentAlignment.MiddleCenter), Localizable(true)]
        public virtual ContentAlignment TextAlign
        {
            get
            {
                return this.menmTextAlign;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                }
                if (this.menmTextAlign != value)
                {
                    this.menmTextAlign = value;

                    // Update params.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets the orientation of text used on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripTextDirectionDescr")]
        public virtual ToolStripTextDirection TextDirection
        {
            get
            {
                if (menmTextDirection != ToolStripTextDirection.Inherit)
                {
                    return menmTextDirection;
                }

                if (this.ParentInternal != null)
                {
                    return this.ParentInternal.TextDirection;
                }

                return ((this.Owner == null) ? ToolStripTextDirection.Horizontal : this.Owner.TextDirection);
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripTextDirection));
                }

                menmTextDirection = value;
                // TODO: Update client
            }
        }

        ///<summary>Gets or sets the position of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text and image relative to each other.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText"></see>.</returns> 
        ///<filterpriority>2</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), DefaultValue(TextImageRelation.ImageBeforeText), Localizable(true), SRDescription("ToolStripItemTextImageRelationDescr")]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return this.menmTextImageRelation;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 8))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(TextImageRelation));
                }
                if (value != this.TextImageRelation)
                {
                    this.menmTextImageRelation = value;

                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets the text that appears as a <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> for a control.</summary> 
        ///<returns>A string representing the ToolTip text.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ToolStripItemToolTipTextDescr"), SRCategory("CatBehavior"), Localizable(true)]
        public string ToolTipText
        {
            get
            {
                if (!this.AutoToolTip || !string.IsNullOrEmpty(this.mstrToolTipText))
                {
                    return this.mstrToolTipText;
                }

                string text = this.Text;
                
                if (ClientUtils.ContainsMnemonic(text))
                {
                    text = string.Join("", text.Split(new char[] { '&' }));
                }

                return text;
            }
            set
            {
                if (this.mstrToolTipText != value)
                {
                    this.mstrToolTipText = value;
                    this.UpdateParams(AttributeType.ToolTip);
                }
            }
        }

        private void ResetToolTipText()
        {
            RemoveValue<string>(ToolStripItem.mstrToolTipTextProperty);
        }

        ///<summary>Gets or sets a value indicating whether the item is displayed.</summary> 
        ///<returns>true if the item is displayed; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ToolStripItemVisibleDescr"), SRCategory("CatBehavior"), Localizable(true), DefaultValue(true)]
        public bool Visible
        {
            get
            {
                return (((this.ParentInternal != null) && this.ParentInternal.Visible) && this.Available);
            }
            set
            {
                this.SetVisibleCore(value);
                this.UpdateParams(AttributeType.Visual);
                ToolStrip objOwner = this.Owner;
                if (objOwner != null)
                {
                    // If the ToolStrip is Autosized then its size needs to be changed
                    objOwner.InvalidateLayout(new LayoutEventArgs(false, false, false));
                    // Redraw toolstrip
                    objOwner.Update(true);
            }
        }
        }

        ///<summary>Gets or sets the width in pixels of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the width in pixels.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatLayout"), Browsable(false)]
        public int Width
        {
            get
            {
                return this.Bounds.Width;
            }
            set
            {
                Rectangle bounds = this.Bounds;

                if (bounds.Width != value)
                {
                    this.SetBounds(bounds.X, bounds.Y, value, bounds.Height);

                    // Update params.
                    this.UpdateParams(AttributeType.Layout);
                }
            } 
        }

        ArrangedElementCollection IArrangedElement.Children
        {
            get
            {
                return new ArrangedElementCollection();
            }
        }

        bool IArrangedElement.ParticipatesInLayout
        {
            get
            {
                return this.Visible;
            }
        }

        /// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatAccessibility"), DefaultValue(AccessibleRole.Default), SRDescription("ToolStripItemAccessibleRoleDescr")]
        public AccessibleRole AccessibleRole
        {
            get
            {
                return AccessibleRole.Default;
            }
            set
            {}
        }

        #region IRegisteredComponentMember Members


        /// <summary>
        /// Gets or sets the member ID.
        /// </summary>
        /// <value>The member ID.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long MemberID
        {
            get
            {
                // Try getting owning tool strip.
                ToolStrip objOwner = this.Owner;
                if (objOwner != null)
                {
                    // Check if owner contains this item.
                    if (objOwner.Items.Contains(this))
                    {
                        // Return a member id which is based on the index of this item whithin its owner.
                        return objOwner.Items.IndexOf(this) + 1;
                    }
                }

                return -1;
            }
            set
            {
                
            }
        }

        /// <summary>
        /// Gets the owner ID.
        /// </summary>
        /// <value>The owner ID.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public long OwnerID
        {
            get
            {
                // Try getting owner toolstrip drop down.
                ToolStripDropDown objOwner = this.Owner as ToolStripDropDown;
                if (objOwner != null)
                {
                    // Get drop down form.
                    Form objDropDownForm = objOwner.DropDownForm;
                    if (objDropDownForm != null)
                    {
                        // Retuen drop down form's id.
                        return objDropDownForm.GetProxyPropertyValue<long>("ID", objDropDownForm.ID);
                    }
                }

                // Get owner toolstrip drop down.
                ToolStrip objOwnerToolStrip = this.Owner;
                if (objOwnerToolStrip != null)
                {
                    // Retuen toolstrip's id.
                    return objOwnerToolStrip.GetProxyPropertyValue<long>("ID", objOwnerToolStrip.ID);
                }

                return 0;
            }
        }

        #endregion

        #region ISkinable Members

        /// <summary>
        /// Gets the theme.
        /// </summary>
        /// <value>The theme.</value>
        string ISkinable.Theme
        {
            get
            {
                if (this.Context != null)
                {
                    return this.Context.CurrentTheme;
                }
                return string.Empty;
            }
        }

        #endregion

        #endregion Properties
    }

    #endregion ToolStripItem Class

    #region ToolStripLabel Class

    /// <summary>Represents a nonselectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that renders text and images and can display hyperlinks.</summary>
    [Skin(typeof(ToolStripLabelSkin))]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripLabel : ToolStripItem
    {
        #region Members

        private static readonly SerializableProperty mblnIsLinkProperty = SerializableProperty.Register("mblnIsLink", typeof(bool), typeof(ToolStripLabel));
               
        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class.</summary>
        public ToolStripLabel()
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text to display.</summary> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(string text) : base(text, null, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the image to display.</summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(ResourceHandle image) : base(null, image, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display.</summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(string text, ResourceHandle image) : base(text, image, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display and whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link.</summary> 
        ///<param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(string text, ResourceHandle image, bool isLink) : this(text, image, isLink, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</summary> 
        ///<param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param> 
        ///<param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(string text, ResourceHandle image, bool isLink, EventHandler onClick) : this(text, image, isLink, default(EventHandler), null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler and name for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
        ///<param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
        ///<param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
        public ToolStripLabel(string text, ResourceHandle image, bool isLink, EventHandler onClick, string name) : base(text, image, default(EventHandler), default(string))
        {
            this.IsLink = isLink;
        }

        #endregion C'Tors

        #region Properties

        #region Property Store

        private bool mblnIsLink
        {
            get
            {
                return this.GetValue<bool>(ToolStripLabel.mblnIsLinkProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripLabel.mblnIsLinkProperty, value);
            }
        }        
        #endregion

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 1;
            }
        }

        ///<summary>Gets or sets the color used to display an active link.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the color to display an active link. The default color is specified by the system. Typically, this color is Color.Red.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ActiveLinkColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets a value indicating the selectable state of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
        ///<returns>false in all cases.</returns> 
        ///<filterpriority>1</filterpriority>
        public override bool CanSelect
        {
            get
            {
                if (!this.IsLink)
                {
                    return base.DesignMode;
                }
                return true;
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink. </summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink; otherwise, false. The default is false.</returns>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("ToolStripLabelIsLinkDescr")]
        public bool IsLink
        {
            get
            {
                return this.mblnIsLink;
            }
            set
            {
                if (this.mblnIsLink != value)
                {
                    this.mblnIsLink = value;

                    // Update params.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets a value that represents the behavior of a link.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.LinkBehavior"></see> values. The default is LinkBehavior.SystemDefault.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LinkBehavior LinkBehavior
        {
            get
            {
                return LinkBehavior.AlwaysUnderline;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the color used when displaying a normal link.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to displaying a normal link. The default color is specified by the system. Typically, this color is Color.Blue.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LinkColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a value indicating whether a link should be displayed as though it were visited.</summary> 
        ///<returns>true if links should display as though they were visited; otherwise, false. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LinkVisited
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the color used when displaying a link that that has been previously visited.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display links that have been visited. The default color is specified by the system. Typically, this color is Color.Purple.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color VisitedLinkColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        
        #endregion Properties

        #region Methods

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fit.
        /// </summary>
        /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   </PermissionSet>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            // Return preferred size with image consideration
            return base.GetPreferredSizeByImage(this.GetPreferredeSizeByText());
        }

        #region Render

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            base.RenderToolStripItemAttributes(objContext, objAttributeWriter);

            // Renders the text attributes.
            RenderTextAttributes(objAttributeWriter, false);

            // Renders the link state attribute.
            RenderLinkStateAttribute(objAttributeWriter, false);
        }

        
        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);

            // Check the visual attribute.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the text attributes.
                RenderTextAttributes(objAttributeWriter, true);

                // Renders the link state attribute.
                RenderLinkStateAttribute(objAttributeWriter, true);
            }
        }

        /// <summary>
        /// Renders the text attributes.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderTextAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.ShouldRenderText)
            {
                // Get the text value.
                string strText = this.Text;

                // Check if the value attribute should be rendered.
                if (!string.IsNullOrEmpty(strText) || blnForceRender)
                {
                    // Render a value attribute.
                    objAttributeWriter.WriteAttributeText(WGAttributes.Value, strText);

                    // Check if this is a link label.
                    if (this.IsLink)
                    {
                        // Render a text attribute.
                        objAttributeWriter.WriteAttributeText(WGAttributes.Text, strText);
                    }
                }
            }
        }

        /// <summary>
        /// Renders the link state attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderLinkStateAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get the is link value.
            bool blnIsLink = this.IsLink;

            // Check if the value attribute should be rendered.
            if (blnIsLink || blnForceRender)
            {
                // Render a link state attribute.
                objAttributeWriter.WriteAttributeText(WGAttributes.LinkState, blnIsLink ? "1" : "0");
            }
        }
                
        #endregion

        #region Should Serialize Methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeActiveLinkColor()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeLinkColor()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeVisitedLinkColor()
        {
            return false;
        }

        #endregion

        #endregion
    }

    #endregion ToolStripLabel Class

    #region ToolStripStatusLabel

    /// <summary>Represents a panel in a <see cref="T:System.Windows.Forms.StatusStrip"></see> control. </summary>
    [Serializable()]
    [Skin(typeof(ToolStripStatusLabelSkin))]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripStatusLabel : ToolStripLabel
    {
        #region Members

        private static readonly SerializableProperty menmBorderSidesProperty = SerializableProperty.Register("menmBorderSides", typeof(ToolStripStatusLabelBorderSides), typeof(ToolStripStatusLabel));
        private static readonly SerializableProperty mblnSpringProperty = SerializableProperty.Register("mblnSpring", typeof(bool), typeof(ToolStripStatusLabel));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class. </summary>
        public ToolStripStatusLabel() : base()
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified text.</summary> 
        ///<param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
        public ToolStripStatusLabel(string text) : base(text, null, default(bool), null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image. </summary> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
        public ToolStripStatusLabel(ResourceHandle image) : base(null, image, default(bool), null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text.</summary> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
        ///<param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
        public ToolStripStatusLabel(string text, ResourceHandle image) : base(text, image, default(bool), null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
        ///<param name="onClick">Specifies the action to carry out when the control is clicked.</param> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
        ///<param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
        public ToolStripStatusLabel(string text, ResourceHandle image, EventHandler onClick) : base(text, image, default(bool), onClick, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class with the specified name that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
        ///<param name="onClick">Specifies the action to carry out when the control is clicked.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
        ///<param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
        public ToolStripStatusLabel(string text, ResourceHandle image, EventHandler onClick, string name) : base(text, image, default(bool), onClick, default(string))
        {
        }

        #endregion C'Tors

        #region Properties

        #region Property Store

        private ToolStripStatusLabelBorderSides menmBorderSides
        {
            get
            {
                return this.GetValue<ToolStripStatusLabelBorderSides>(ToolStripStatusLabel.menmBorderSidesProperty);
            }
            set
            {
                this.SetValue<ToolStripStatusLabelBorderSides>(ToolStripStatusLabel.menmBorderSidesProperty, value);
            }
        }

        private bool mblnSpring
        {
            get
            {
                return this.GetValue<bool>(ToolStripStatusLabel.mblnSpringProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripStatusLabel.mblnSpringProperty, value);
            }
        }

        #endregion

        ///<summary>Gets or sets a value that determines where the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> is aligned on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public ToolStripItemAlignment Alignment
        {
            get
            {
                return base.Alignment;
            }
            set
            {
                base.Alignment = value;
            }
        }

        ///<summary>Gets or sets a value that indicates which sides of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> show borders.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides.None"></see>.</returns>
        [DefaultValue(ToolStripStatusLabelBorderSides.None), SRDescription("ToolStripStatusLabelBorderSidesDescr"), SRCategory("CatAppearance")]
        public ToolStripStatusLabelBorderSides BorderSides
        {
            get
            {
                return this.menmBorderSides;
            }
            set
            {
                if (this.menmBorderSides != value)
                {
                    this.menmBorderSides = value;
                    base.Invalidate();
                }
            }
        }

        ///<summary>Gets or sets the border style of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Border3DStyle.Flat"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStripStatusLabel.BorderStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Border3DStyle BorderStyle
        {
            get
            {
                return Border3DStyle.Flat;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 6;
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized. </summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized; otherwise, false. The default is false.</returns>
        [DefaultValue(false), SRDescription("ToolStripStatusLabelSpringDescr"), SRCategory("CatAppearance")]
        public bool Spring
        {
            get
            {
                return this.mblnSpring;
            }
            set
            {
                if (this.mblnSpring != value)
                {
                    this.mblnSpring = value;
                    // TODO: Update client
                }
            }
        }

        #endregion Properties
    } 

    #endregion

    #region ToolStripButton Class

    /// <summary>Represents a selectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that can contain text and images. </summary>
    [Skin(typeof(ToolStripButtonSkin))]
    [Serializable()]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripButton : ToolStripItem
    {
        #region Members

        private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register("menmCheckState", typeof(CheckState), typeof(ToolStripButton));
        private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register("mblnCheckOnClick", typeof(bool), typeof(ToolStripButton));

        private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(ToolStripButton));
        private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(ToolStripButton));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class.</summary>
        public ToolStripButton()
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text.</summary> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
        public ToolStripButton(string text) : base(text, null, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified image.</summary> 
        ///<param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
        public ToolStripButton(ResourceHandle image) : base(null, image, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image.</summary> 
        ///<param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
        public ToolStripButton(string text, ResourceHandle image) : base(text, image, null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary> 
        ///<param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
        ///<param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
        public ToolStripButton(string text, ResourceHandle image, EventHandler onClick) : base(text, image, onClick)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class with the specified name that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary> 
        ///<param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
        ///<param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
        ///<param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
        public ToolStripButton(string text, ResourceHandle image, EventHandler onClick, string name) : base(text, image, onClick, default(string))
        {
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fit.
        /// </summary>
        /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   </PermissionSet>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            // Get the item's text size
            Size objTotalSize = this.GetPreferredeSizeByText();

            // Apply image to size
            objTotalSize = base.GetPreferredSizeByImage(objTotalSize);

            // Get relevant skin attributes and apply them to the size
            return this.GetPreferredSizeByButtonSkin(SkinFactory.GetSkin(this) as ButtonSkin, objTotalSize);
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckedChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CheckedChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckStateChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CheckStateChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #region Render

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "CheckedChange":
                    bool blnChecked = false;

                    if (bool.TryParse(objEvent[WGAttributes.Checked], out blnChecked))
                    {
                        this.Checked = blnChecked;
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.CheckedChangedHandler != null)
            {
                objEvents.Set(WGEvents.CheckedChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            base.RenderToolStripItemAttributes(objContext, objAttributeWriter);

            // Renders the tool strip item text attribute.
            RenderToolStripItemTextAttribute(objAttributeWriter, false);

            // Renders the tool strip item checked attribute.
            RenderToolStripItemCheckedAttribute(objAttributeWriter, false);

            // Renders the tool strip item checked on click attribute.
            RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, false);
        }

        /// <summary>
        /// Renders the tool strip item checked on click attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderToolStripItemCheckedOnClickAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.mblnCheckOnClick || blnForceRender)
            {
                // Make the button checkable
                objAttributeWriter.WriteAttributeText(WGAttributes.CheckOnClick, this.mblnCheckOnClick ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the tool strip item text attribute.
                RenderToolStripItemTextAttribute(objAttributeWriter, true);

                // Renders the tool strip item checked attribute.
                RenderToolStripItemCheckedAttribute(objAttributeWriter, true);

                // Renders the tool strip item checked on click attribute.
                RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, true);
            }
        }

        /// <summary>
        /// Renders the tool strip item text attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderToolStripItemTextAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.ShouldRenderText)
            {
                // Get the text value.
                string strText = this.Text;

                // Check if the value attribute should be rendered.
                if (!string.IsNullOrEmpty(strText) || blnForceRender)
                {
                    // Render a text attribute.
                    objAttributeWriter.WriteAttributeText(WGAttributes.Text, strText);
                }
            }
        }

        /// <summary>
        /// Renders the tool strip item checked attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderToolStripItemCheckedAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            // Get the text value.
            bool blnChecked = this.Checked;

            // Check if the value attribute should be rendered.
            if (blnChecked || blnForceRender)
            {
                // Render a text attribute.
                objAttributeWriter.WriteAttributeText(WGAttributes.Checked, blnChecked ? "1" : "0");
            }
        }

        #endregion

        #endregion Methods

        #region Events

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.Checked"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler CheckedChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripButton.CheckedChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripButton.CheckedChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the CheckedChanged handler.
        /// </summary>
        /// <value>The available changed handler.</value>
        private EventHandler CheckedChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripButton.CheckedChangedEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.CheckState"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler CheckStateChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripButton.CheckStateChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripButton.CheckStateChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the CheckStateChanged handler.
        /// </summary>
        /// <value>The available changed handler.</value>
        private EventHandler CheckStateChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripButton.CheckStateChangedEvent);
            }
        }
        #endregion Events

        #region Properties

        #region Property Store

        private CheckState menmCheckState
        {
            get
            {
                return this.GetValue<CheckState>(ToolStripButton.menmCheckStateProperty);
            }
            set
            {
                this.SetValue<CheckState>(ToolStripButton.menmCheckStateProperty, value);
            }
        }

        private bool mblnCheckOnClick
        {
            get
            {
                return this.GetValue<bool>(ToolStripButton.mblnCheckOnClickProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripButton.mblnCheckOnClickProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 0;
            }
        }

        ///<summary>Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>. </summary> 
        ///<returns>true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
        [DefaultValue(true)]
        public bool AutoToolTip
        {
            get
            {
                return base.AutoToolTip;
            }
            set
            {
                base.AutoToolTip = value;
            }
        }

        ///<summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        public override bool CanSelect
        {
            get
            {
                return true;
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed or not pressed.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed in or not pressed in; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripButtonCheckedDescr"), DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return (this.menmCheckState != CheckState.Unchecked);
            }
            set
            {
                if (value != this.Checked)
                {
                    this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("ToolStripButtonCheckOnClickDescr"), DefaultValue(false)]
        public bool CheckOnClick
        {
            get
            {
                return this.mblnCheckOnClick;
            }
            set
            {
                if (this.mblnCheckOnClick != value)
                {
                    this.mblnCheckOnClick = value;
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is in the pressed or not pressed state by default, or is in an indeterminate state.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("CheckBoxCheckStateDescr"), DefaultValue(CheckState.Unchecked), SRCategory("CatAppearance")]
        public CheckState CheckState
        {
            get
            {
                return this.menmCheckState;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
                }
                if (value != this.menmCheckState)
                {
                    this.menmCheckState = value;
                    base.Invalidate();
                    this.OnCheckedChanged(EventArgs.Empty);
                    this.OnCheckStateChanged(EventArgs.Empty);

                    // Update parameters.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets a value indicating whether to display the ToolTip that is defined as the default. </summary> 
        ///<returns>true in all cases.</returns>
        protected override bool DefaultAutoToolTip
        {
            get
            {
                return true;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripButton Class

    #region ToolStripSeparator Class

    /// <summary>Represents a line used to group items of a <see cref="T:System.Windows.Forms.ToolStrip"></see> or the drop-down items of a <see cref="T:System.Windows.Forms.MenuStrip"></see> or <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> or other <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> control.</summary>
    [Skin(typeof(ToolStripSeparatorSkin))]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripSeparator : ToolStripItem
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> class. </summary>
        public ToolStripSeparator()
        {
            this.ForeColor = SystemColors.ControlDark;
        }

        #endregion C'Tors

        #region Events

        //// <summary>This event is not relevant to this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler DisplayStyleChanged
        {
            add
            {
                base.DisplayStyleChanged += value;
            }
            remove
            {
                base.DisplayStyleChanged -= value;
            }
        }

        /// <summary>This event is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler EnabledChanged
        {
            add
            {
                base.EnabledChanged += value;
            }
            remove
            {
                base.EnabledChanged -= value;
            }
        }

        /// <summary>This event is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        #endregion Events

        #region Properties

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>true if enabled; otherwise, false. </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoToolTip
        {
            get
            {
                return base.AutoToolTip;
            }
            set
            {
                base.AutoToolTip = value;
            }
        }

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 4;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ResourceHandle BackgroundImage
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

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        ///<summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> can be selected. </summary> 
        ///<returns>true if the component using the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is in design mode; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        public override bool CanSelect
        {
            get
            {
                return base.DesignMode;
            }
        }

        /// <summary>
        /// Gets the internal spacing characteristics of the item.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(6, 6);
            }
        }

        /// <summary>
        /// Gets a value indicating whether to hide item on strip wrapping.
        /// </summary>
        /// <value><c>true</c> if [hide on wrap]; otherwise, <c>false</c>.</value>
        protected override bool HideOnWrap
        {
            get
            {
                return true;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> value.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public ToolStripItemDisplayStyle DisplayStyle
        {
            get
            {
                return base.DisplayStyle;
            }
            set
            {
                base.DisplayStyle = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>true if enabled; otherwise, false. </returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public bool DoubleClickEnabled
        {
            get
            {
                return base.DoubleClickEnabled;
            }
            set
            {
                base.DoubleClickEnabled = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>true if enabled; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Font"></see> value.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ResourceHandle Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.VisualStyles.ContentAlignment"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return base.ImageAlign;
            }
            set
            {
                base.ImageAlign = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Int32"></see>.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), RefreshProperties(RefreshProperties.Repaint)]
        public int ImageIndex
        {
            get
            {
                return base.ImageIndex;
            }
            set
            {
                base.ImageIndex = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.String"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImageKey
        {
            get
            {
                return base.ImageKey;
            }
            set
            {
                base.ImageKey = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>true if enabled; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RightToLeftAutoMirrorImage
        {
            get
            {
                return base.RightToLeftAutoMirrorImage;
            }
            set
            {
                base.RightToLeftAutoMirrorImage = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.String"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.ContentAlignment"></see> value.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                base.TextAlign = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripTextDirection"></see> value.</returns>
        [DefaultValue(ToolStripTextDirection.Horizontal), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.TextImageRelation"></see> value.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return base.TextImageRelation;
            }
            set
            {
                base.TextImageRelation = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A string.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ToolTipText
        {
            get
            {
                return base.ToolTipText;
            }
            set
            {
                base.ToolTipText = value;
            }
        }

        #endregion Properties

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fit.
        /// </summary>
        /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   </PermissionSet>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            Size objTotalSize = this.Size;
            
            if (this.ParentInternal != null)
            {
                ToolStripSeparatorSkin objToolStripSeparatorSkin = SkinFactory.GetSkin(this) as ToolStripSeparatorSkin;
                if (objToolStripSeparatorSkin != null)
                {
                    // Check the parent's orientation.
                    switch (this.ParentInternal.Orientation)
                    {
                        case Orientation.Horizontal:
                            objTotalSize.Width = objToolStripSeparatorSkin.VerticalSeperatorWidth;
                            break;
                        case Orientation.Vertical:
                            objTotalSize.Height = objToolStripSeparatorSkin.HorizontalSeperatorHeight;
                            break;
                        default:
                            break;
                    }
                }
            }

            // Return preferred size with image consideration
            return objTotalSize;
        }
    }

    #endregion ToolStripSeparator Class

    #region ToolStripDropDownItem Class

    /// <summary>Provides basic functionality for controls that display a <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> when a <see cref="T:System.Windows.Forms.ToolStripDropDownButton"></see>, <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>, or <see cref="T:System.Windows.Forms.ToolStripSplitButton"></see> control is clicked.</summary>
    [Serializable()]
    [DefaultProperty("DropDownItems")]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public abstract class ToolStripDropDownItem : ToolStripItem
    {
        #region Members

        private static readonly SerializableProperty mobjDropDownProperty = SerializableProperty.Register("mobjDropDown", typeof(ToolStripDropDown), typeof(ToolStripDropDownItem));

        private static readonly SerializableEvent DropDownOpenedEvent = SerializableEvent.Register("DropDownOpened", typeof(EventHandler), typeof(ToolStripDropDownItem));
        private static readonly SerializableEvent DropDownOpeningEvent = SerializableEvent.Register("DropDownOpening", typeof(EventHandler), typeof(ToolStripDropDownItem));
        private static readonly SerializableEvent DropDownItemClickedEvent = SerializableEvent.Register("DropDownItemClicked", typeof(ToolStripItemClickedEventHandler), typeof(ToolStripDropDownItem));
        private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ToolStripDropDownItem));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class. </summary>
        protected ToolStripDropDownItem()
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and action to take when the drop-down control is clicked.</summary> 
        ///<param name="onClick">The action to take when the drop-down control is clicked.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
        ///<param name="text">The display text of the drop-down control.</param>
        protected ToolStripDropDownItem(string text, ResourceHandle image, EventHandler onClick) : base(text, image, onClick)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, action to take when the drop-down control is clicked, and control name.</summary> 
        ///<param name="onClick">The action to take when the drop-down control is clicked.</param> 
        ///<param name="name">The name of the control.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
        ///<param name="text">The display text of the drop-down control.</param>
        protected ToolStripDropDownItem(string text, ResourceHandle image, EventHandler onClick, string name) : base(text, image, onClick, default(string))
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</summary> 
        ///<param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
        ///<param name="text">The display text of the drop-down control.</param>
        protected ToolStripDropDownItem(string text, ResourceHandle image, ToolStripItem[] dropDownItems) : this(text, image, (EventHandler)null)
        {
            if (dropDownItems != null)
            {
                this.DropDownItems.AddRange(dropDownItems);
            }
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Pres the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
        {
            base.PreRenderToolStripItem(objContext, lngRequestID);

            this.DropDown.PreRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Posts the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
        {
            base.PostRenderToolStripItem(objContext, lngRequestID);

            this.DropDown.PostRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            if (mobjDropDown != null)
            {
                // Unregister drop down items
                UnRegisterBatch(mobjDropDown.Items);
            }
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();
            if (mobjDropDown != null)
            {
                // Unregister drop down items
                RegisterBatch(mobjDropDown.Items);
            }
        }
        
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="blnDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool blnDisposing)
        {
            if (mobjDropDown != null)
            {
                mobjDropDown.Opened -= new EventHandler(this.DropDown_Opened);
                mobjDropDown.Closed -= new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
                mobjDropDown.ItemClicked -= new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
                if (blnDisposing && mobjDropDown.IsAutoGenerated)
                {
                    mobjDropDown.Dispose();
                    mobjDropDown = null;
                }
            }
            base.Dispose(blnDisposing);
        }

        private void DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.OnDropDownClosed(EventArgs.Empty);
        }

        private void DropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.OnDropDownItemClicked(e);
        }

        private void DropDown_Opened(object sender, EventArgs e)
        {
            this.OnDropDownOpened(EventArgs.Empty);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownOpened"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected internal virtual void OnDropDownOpened(EventArgs e)
        {
            if (this.DropDown.OwnerItem == this)
            {
                EventHandler objEventHandler = this.DropDownOpenedHandler;
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownClosed"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected internal virtual void OnDropDownClosed(EventArgs e)
        {
            base.Invalidate();

            if (this.DropDown.OwnerItem == this)
            {
                EventHandler objEventHandler = this.DropDownClosedHandler;
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }

                if (!this.DropDown.IsAutoGenerated)
                {
                    this.DropDown.OwnerItem = null;
                }
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data.</param>
        protected internal virtual void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (this.DropDown.OwnerItem == this)
            {
                ToolStripItemClickedEventHandler objEventHandler = this.DropDownItemClickedHandler;
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }
            }
        }

        ///<summary>Creates a generic <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> for which events can be defined.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
        protected virtual ToolStripDropDown CreateDefaultDropDown()
        {
            return new ToolStripDropDown(this, true);
        }

        ///<summary>Makes a visible <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> hidden.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void HideDropDown()
        {
            this.OnDropDownHide(EventArgs.Empty);
        }

        ///<summary>Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.HideDropDown"></see> method.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDropDownHide(EventArgs e)
        {
        }

        ///<summary>Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.ShowDropDown"></see> method.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDropDownShow(EventArgs e)
        {
            EventHandler objEventHandler = this.DropDownOpeningHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Displays the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> control associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary> 
        ///<exception cref="T:System.InvalidOperationException">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is the same as the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void ShowDropDown()
        {
            if (this.mobjDropDown == null)
            {
                this.OnDropDownShow(EventArgs.Empty);
            }
            if ((this.mobjDropDown != null)  && (!this.mobjDropDown.IsAutoGenerated || (this.DropDownItems.Count > 0)))
            {
                if (this.DropDown == base.ParentInternal)
                {
                    throw new InvalidOperationException(SR.GetString("ToolStripShowDropDownInvalidOperation"));
                }
                this.mobjDropDown.ShowDropDown(this);
            }
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            if (strOffspringTypeName == "Gizmox.WebGUI.Forms.ToolStripDropDown")
            {
                List<ToolStripDropDown> objList = new List<ToolStripDropDown>();
                objList.Add(this.DropDown);
                return objList;
            }
            else
            {
                return base.GetComponentOffsprings(strOffspringTypeName);
            }
        }

        #region Render

        /// <summary>
        /// Renders the tool strip item's text attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected virtual void RenderToolStripDropDownItemTextAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.ShouldRenderText)
            {
                // Get the text value.
                string strText = this.Text;

                // Check if the value attribute should be rendered.
                if (!string.IsNullOrEmpty(strText) || blnForceRender)
                {
                    // Render a text attribute.
                    objAttributeWriter.WriteAttributeText(WGAttributes.Text, strText);
                }
            }
        }

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            base.RenderToolStripItemAttributes(objContext, objAttributeWriter);

            // Renders the tool strip item drop down attribute.
            RenderToolStripDropDownItemDropDownAttribute(objAttributeWriter);

            // Renders the tool strip item text attribute.
            RenderToolStripDropDownItemTextAttribute(objAttributeWriter, false);
        }

        /// <summary>
        /// Renders the tool strip item's drop down attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        protected virtual void RenderToolStripDropDownItemDropDownAttribute(IAttributeWriter objAttributeWriter)
        {
            // Render the drop down atribute.
            objAttributeWriter.WriteAttributeText(WGAttributes.DropDown, "1");
        }

        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the tool strip item text attribute.
                RenderToolStripDropDownItemTextAttribute(objAttributeWriter, true);
            }
        }

        #endregion 

        #endregion Methods

        #region Events

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> closes. </summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler DropDownClosed
        {
            add
            {
                if (!this.HasHandler(ToolStripDropDownItem.DropDownClosedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.Closed += new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
                    }
                }

                this.AddCriticalHandler(ToolStripDropDownItem.DropDownClosedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownClosedEvent, value);

                if (!this.HasHandler(ToolStripDropDownItem.DropDownClosedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.Closed -= new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the DropDownClosed handler.
        /// </summary>
        /// <value>The DropDownClosed handler.</value>
        private EventHandler DropDownClosedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripDropDownItem.DropDownClosedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is clicked.</summary> 
        ///<filterpriority>1</filterpriority>
        public event ToolStripItemClickedEventHandler DropDownItemClicked
        {
            add
            {
                if (!this.HasHandler(ToolStripDropDownItem.DropDownItemClickedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.ItemClicked += new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
                    }
                }

                this.AddCriticalHandler(ToolStripDropDownItem.DropDownItemClickedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownItemClickedEvent, value);

                if (!this.HasHandler(ToolStripDropDownItem.DropDownItemClickedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.ItemClicked -= new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the DropDownItemClicked handler.
        /// </summary>
        /// <value>The DropDownItemClicked handler.</value>
        private ToolStripItemClickedEventHandler DropDownItemClickedHandler
        {
            get
            {
                return (ToolStripItemClickedEventHandler)this.GetHandler(ToolStripDropDownItem.DropDownItemClickedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has opened.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler DropDownOpened
        {
            add
            {
                if (!this.HasHandler(ToolStripDropDownItem.DropDownOpenedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.Opened += new EventHandler(this.DropDown_Opened);
                    }
                }

                this.AddCriticalHandler(ToolStripDropDownItem.DropDownOpenedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownOpenedEvent, value);

                if (!this.HasHandler(ToolStripDropDownItem.DropDownOpenedEvent))
                {
                    if (this.mobjDropDown != null)
                    {
                        this.mobjDropDown.Opened -= new EventHandler(this.DropDown_Opened);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the DropDownOpened handler.
        /// </summary>
        /// <value>The DropDownOpened handler.</value>
        private EventHandler DropDownOpenedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripDropDownItem.DropDownOpenedEvent);
            }
        }
        ///<summary>Occurs as the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is opening.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler DropDownOpening
        {
            add
            {
                this.AddCriticalHandler(ToolStripDropDownItem.DropDownOpeningEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownOpeningEvent, value);
            }
        }

        /// <summary>
        /// Gets the DropDownOpening handler.
        /// </summary>
        /// <value>The DropDownOpening handler.</value>
        private EventHandler DropDownOpeningHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripDropDownItem.DropDownOpeningEvent);
            }
        }

        #endregion Events

        #region Properties

        #region Proprety Store

        private ToolStripDropDown mobjDropDown
        {
            get
            {
                return this.GetValue<ToolStripDropDown>(ToolStripDropDownItem.mobjDropDownProperty);
            }
            set
            {
                this.SetValue<ToolStripDropDown>(ToolStripDropDownItem.mobjDropDownProperty, value);
            }
        }

        #endregion

        ///<summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that will be displayed when this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is clicked.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [TypeConverter(typeof(ReferenceConverter)), SRCategory("CatData"), SRDescription("ToolStripDropDownDescr")]
        [System.ComponentModel.Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripDropDown DropDown
        {
            get
            {
                if (this.mobjDropDown == null)
                {
                    this.DropDown = this.CreateDefaultDropDown();
                    if (!(this is ToolStripOverflowButton))
                    {
                        this.mobjDropDown.SetAutoGeneratedInternal(true);
                    }
                }
                return this.mobjDropDown;
            }
            set
            {
                if (this.mobjDropDown != value)
                {
                    this.mobjDropDown = value;
                }
            }
        }

        ///<summary>Gets or sets a value indicating the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> emerges from its parent container.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property is set to a value that is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRCategory("CatBehavior"), Browsable(false), SRDescription("ToolStripDropDownItemDropDownDirectionDescr")]
        public ToolStripDropDownDirection DropDownDirection
        {
            get
            {
                return ToolStripDropDownDirection.Default;
            }
            set
            {
            }
        }

        ///<summary>Gets the collection of items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see> of controls.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatData"), SRDescription("ToolStripDropDownItemsDescr")]
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
        public ToolStripItemCollection DropDownItems
        {
            get
            {
                return this.DropDown.Items; 
            }
        }

        ///<summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls associated with it. </summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual bool HasDropDownItems
        {
            get
            {
                return ((this.mobjDropDown != null) && this.mobjDropDown.Items.Count > 0);
            }
        }

        #endregion Properties
    }

    #endregion ToolStripDropDownItem Class

    #region ToolStripDropDownButton Class

    /// <summary>Represents a control that when clicked displays an associated <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> from which the user can select a single item.</summary>
    [Skin(typeof(ToolStripDropDownButtonSkin))]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripDropDownButton : ToolStripDropDownItem
    {
        #region Members

        private static readonly SerializableProperty mblnShowDropDownArrowProperty = SerializableProperty.Register("mblnShowDropDownArrow", typeof(bool), typeof(ToolStripDropDownButton));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class. </summary>
        public ToolStripDropDownButton()
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text.</summary> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(string text)
            : base(text, null, (EventHandler)null)
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified image.</summary> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(ResourceHandle image)
            : base(null, image, (EventHandler)null)
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image.</summary> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(string text, ResourceHandle image)
            : base(text, image, (EventHandler)null)
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image and raises the Click event.</summary> 
        ///<param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(string text, ResourceHandle image, EventHandler onClick)
            : base(text, image, onClick)
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that has the specified name, displays the specified text and image, and raises the Click event.</summary> 
        ///<param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(string text, ResourceHandle image, EventHandler onClick, string name)
            : base(text, image, onClick, default(string))
        {
            this.mblnShowDropDownArrow = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class.</summary> 
        ///<param name="dropDownItems">An array of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> containing the items of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
        public ToolStripDropDownButton(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
            this.mblnShowDropDownArrow = true;
        }

        #endregion C'Tors

        #region Properties

        #region Property Store

        private bool mblnShowDropDownArrow
        {
            get
            {
                return this.GetValue<bool>(ToolStripDropDownButton.mblnShowDropDownArrowProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripDropDownButton.mblnShowDropDownArrowProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 3;
            }
        }

        ///<summary>Gets or sets a value indicating whether to use the Text property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> ToolTip.</summary> 
        ///<returns>true to use the <see cref="P:Gizmox.WebGUI.Forms.Control.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns>
        [DefaultValue(true)]
        public bool AutoToolTip
        {
            get
            {
                return base.AutoToolTip;
            }
            set
            {
                base.AutoToolTip = value;
            }
        }

        ///<summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary> 
        ///<returns>true in all cases.</returns>
        protected override bool DefaultAutoToolTip
        {
            get
            {
                return true;
            }
        }

        ///<summary>Gets or sets a value indicating whether an arrow is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>, which indicates that further options are available in a drop-down list.</summary> 
        ///<returns>true to show an arrow on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ToolStripDropDownButtonShowDropDownArrowDescr"), DefaultValue(true)]
        public bool ShowDropDownArrow
        {
            get
            {
                return this.mblnShowDropDownArrow;
            }
            set
            {
                if (this.mblnShowDropDownArrow != value)
                {
                    this.mblnShowDropDownArrow = value;
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripItem.MouseDown"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.ShowDropDown();

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objConstrainingSize">Size of the obj constraining.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            // Get the text size
            Size objTotalSize = this.GetPreferredeSizeByText();
            
            ButtonSkin objSkin = SkinFactory.GetSkin(this) as ButtonSkin;

            // Get the DropDownArrow's size if exists
            if (objSkin != null && this.ShowDropDownArrow)
            {
                objTotalSize.Width = objTotalSize.Width + objSkin.DropDownImageWidth;

                objTotalSize.Height = Math.Max(objTotalSize.Height, objSkin.DropDownImageHeight);
            }

            // Apply the image size
            objTotalSize = base.GetPreferredSizeByImage(objTotalSize);

            // Return preferred size with Skin consideration
            return this.GetPreferredSizeByButtonSkin(objSkin, objTotalSize);
        }

        #region Render

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            base.RenderToolStripItemAttributes(objContext, objAttributeWriter);

            // Renders the ShowDropDownArrow attribute.
            RenderShowDropDownArrowAttribute(objAttributeWriter, false);
        }

        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the ShowDropDownArrow attribute.
                RenderShowDropDownArrowAttribute(objAttributeWriter, true);
            }

        }

        /// <summary>
        /// Renders the show drop down arrow attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowDropDownArrowAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            bool blnShowDropDownArrow = this.ShowDropDownArrow;
            if ((!blnShowDropDownArrow) || blnForceRender)
            {
                // Render ShowDropDownArrow.
                objAttributeWriter.WriteAttributeString(WGAttributes.ShowDropDownArrow, blnShowDropDownArrow ? "1" : "0");
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.DropDownItems.Count > 0)
            {
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        } 

        #endregion

        #endregion
    }

    #endregion ToolStripDropDownButton Class

    #region ToolStripOverflowButton Class

    /// <summary>Hosts a <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> that displays items that overflow the <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.None)]
    public class ToolStripOverflowButton : ToolStripDropDownButton
    {
        #region Constructors

        internal ToolStripOverflowButton(ToolStrip objParentToolStrip)
        {
        } 

        #endregion

        #region Properties

        ///<summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> has items that overflow the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> has overflow items; otherwise, false. </returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool HasDropDownItems
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>Retrieves the size of a rectangular area into which a control can fit.</summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        /// <param name="objConstrainingSize">The custom-sized area for a control. </param>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            return Size.Empty;
        } 

        #endregion
    }

    #endregion ToolStripOverflowButton Class

    #region ToolStripMenuItem Class

    /// <summary>Represents a selectable option displayed on a <see cref="T:System.Windows.Forms.MenuStrip"></see> or <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. Although <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> replaces and adds functionality to the <see cref="T:System.Windows.Forms.MenuItem"></see> control of previous versions, <see cref="T:System.Windows.Forms.MenuItem"></see> is retained for both backward compatibility and future use if you choose.</summary>
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip)]
    [Skin(typeof(ToolStripMenuItemSkin))]
    public class ToolStripMenuItem : ToolStripDropDownItem
    {
        #region Members

		private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register("mblnCheckOnClick", typeof(bool), typeof(ToolStripMenuItem));
        private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register("menmCheckState", typeof(CheckState), typeof(ToolStripMenuItem));
        private static readonly SerializableProperty mobjMdiFormProperty = SerializableProperty.Register("mobjMdiForm", typeof(Form), typeof(ToolStripMenuItem));
        private static readonly SerializableProperty mstrShortcutKeyDisplayStringProperty = SerializableProperty.Register("mstrShortcutKeyDisplayString", typeof(string), typeof(ToolStripMenuItem));
        private static readonly SerializableProperty menmShortcutKeysProperty = SerializableProperty.Register("menmShortcutKeys", typeof(Keys), typeof(ToolStripMenuItem));
        private static readonly SerializableProperty mblnShowShortcutKeysProperty = SerializableProperty.Register("mblnShowShortcutKeys", typeof(bool), typeof(ToolStripMenuItem));

        private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(ToolStripMenuItem));
        private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(ToolStripMenuItem));

        [NonSerialized]
        private TypeConverter mobjTypeConverter = null;

	    #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class.</summary>
        public ToolStripMenuItem()
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text.</summary> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text)
            : base(text, null, (EventHandler)null)
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
        public ToolStripMenuItem(ResourceHandle image)
            : base(null, image, (EventHandler)null)
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image.</summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text, ResourceHandle image)
            : base(text, image, (EventHandler)null)
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary> 
        ///<param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick)
            : base(text, image, onClick)
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class with the specified name that displays the specified text and image that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary> 
        ///<param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
        ///<param name="name">The name of the menu item.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick, string name)
            : base(text, image, onClick, default(string))
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that contains the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection.</summary> 
        ///<param name="dropDownItems">The menu items to display when the control is clicked.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
            this.mblnShowShortcutKeys = true;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image, does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked, and displays the specified shortcut keys.</summary> 
        ///<param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
        ///<param name="shortcutKeys">One of the values of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> that represents the shortcut key for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
        ///<param name="text">The text to display on the menu item.</param>
        public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick, Keys shortcutKeys)
            : base(text, image, onClick)
        {
            this.mblnShowShortcutKeys = true;
            this.ShortcutKeys = shortcutKeys;
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Gets the preferred size with image.
        /// </summary>
        /// <param name="objSizeWithoutImage">The obj size without image.</param>
        /// <returns></returns>
        protected internal override Size GetPreferredSizeByImage(Size objSizeWithoutImage)
        {
            Size objPreferredSize = objSizeWithoutImage;

            objPreferredSize = base.GetPreferredSizeByImage(objSizeWithoutImage);

            return objPreferredSize;
        }

        /// <summary>
        /// Gets the preferred size by text.
        /// </summary>
        /// <returns></returns>
        protected internal override Size GetPreferredeSizeByText()
        {
            // Check if item should even render text
            if (this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || this.DisplayStyle == ToolStripItemDisplayStyle.Text)
            {
                if (!String.IsNullOrEmpty(this.Text))
                    return GetTextSize(this.Text);
            }
            return GetTextSize(" "); 
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fit.
        /// </summary>
        /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///   </PermissionSet>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            Size objPreferredSize = GetPreferredeSizeByText();

            objPreferredSize = GetPreferredSizeByImage(objPreferredSize);

            // Get the menu item's skin
            ToolStripMenuItemSkin objToolStripMenuItemSkin = SkinFactory.GetSkin(this) as ToolStripMenuItemSkin;

            if (objToolStripMenuItemSkin != null)
            {
                string strShortcutKeyDisplayString = this.GetShortcutKeyDisplayString();
                bool blnShowShortcutKeys = this.ShowShortcutKeys && !string.IsNullOrEmpty(strShortcutKeyDisplayString);

                BorderWidth objMenuItemBorderWidth = objToolStripMenuItemSkin.MenuItemStyle.Border.Style != BorderStyle.None ? objToolStripMenuItemSkin.MenuItemStyle.Border.Width : BorderWidth.Empty;

                // Calculate the borders and padding widths
                BorderWidth objBorderWidth = objToolStripMenuItemSkin.BorderStyle != BorderStyle.None ? objToolStripMenuItemSkin.BorderWidth : BorderWidth.Empty;
                objPreferredSize.Width += objToolStripMenuItemSkin.Padding.Horizontal + objBorderWidth.Left + objBorderWidth.Right + objMenuItemBorderWidth.Left + objMenuItemBorderWidth.Right;
                objPreferredSize.Height += objToolStripMenuItemSkin.Padding.Vertical + objBorderWidth.Top + objBorderWidth.Bottom + objMenuItemBorderWidth.Top + objMenuItemBorderWidth.Bottom;

                if (!IsTopLevel)
                {
                    if (blnShowShortcutKeys)
                    {
                        // Add gap between text and shortcut
                        objPreferredSize.Width += objToolStripMenuItemSkin.TextShortcutGapSize;
                        objPreferredSize.Width += objToolStripMenuItemSkin.ArrowEdgeGapSize;
                        objPreferredSize.Width += this.GetTextSize(this.GetShortcutKeyDisplayString()).Width;
                    }
                }
            }

            return objPreferredSize;
        }
        #region Render

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "Shortcut":
                    OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    break;

                case "CheckedChange":
                    bool blnChecked = false;

                    if (bool.TryParse(objEvent[WGAttributes.Checked], out blnChecked))
                    {
                        this.Checked = blnChecked;
                    }
                    break;
                case "Enter":
                    this.OnEnter();
                    break;
            }
        }

        /// <summary>
        /// Renders the tool strip item's drop down attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        protected override void RenderToolStripDropDownItemDropDownAttribute(IAttributeWriter objAttributeWriter)
        {
            // Prevent rendering of the drop down attribute.
        }

        /// <summary>
        /// Renders the tool strip item's attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
        {
            base.RenderToolStripItemAttributes(objContext, objAttributeWriter);

            // Renders the tool strip item checked attribute.
            this.RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, false);


            // Renders the tool strip item checked on click attribute.
            RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, false);

            // Renders the tool strip item has nodes attribute.
            this.RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, false);

            // Renders the toolstrip menu item short cut attribute.
            RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, false);
        }

        /// <summary>
        /// Renders the toolstrip menu item short cut attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForce">if set to <c>true</c> [BLN force].</param>
        private void RenderToolstripMenuItemShortCutAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForce)
        {
            // Get shortcut display string
            string strShortcutKeyDisplayString = GetShortcutKeyDisplayString();

            if (!string.IsNullOrEmpty(strShortcutKeyDisplayString))
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Shortcut, strShortcutKeyDisplayString);
                objAttributeWriter.WriteAttributeString(WGAttributes.ShortcutWidth, this.GetTextSize(strShortcutKeyDisplayString).Width.ToString());
            }
            else if (blnForce)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Shortcut, string.Empty);
                objAttributeWriter.WriteAttributeString(WGAttributes.ShortcutWidth, "");
            }
        }

        /// <summary>
        /// Renders the tool strip item checked on click attribute.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderToolStripItemCheckedOnClickAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            if (this.mblnCheckOnClick || blnForceRender)
            {
                // Make the button checkable
                objAttributeWriter.WriteAttributeText(WGAttributes.CheckOnClick, this.mblnCheckOnClick ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the tool strip item has nodes attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected virtual void RenderToolStripItemHasNodesAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            bool blnHasNodes = (this.DropDownItems.Count > 0);

            if (blnHasNodes || blnForceRender)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.HasNodes, blnHasNodes ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the tool strip item updated attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Renders the tool strip item checked attribute.
                this.RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the tool strip item checked on click attribute.
                RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, true);

                // Renders the toolstrip menu item short cut attribute.
                RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, false);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Extended))
            {
                // Renders the tool strip item has nodes attribute.
                this.RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, true);
            }
        }

        /// <summary>
        /// Renders the tool strip item checked attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected virtual void RenderToolStripItemCheckedAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForceRender)
        {
            CheckState enmCheckState = this.CheckState;

            if (enmCheckState != CheckState.Unchecked || blnForceRender)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Checked, Convert.ToInt32(enmCheckState).ToString());
            }
        }

        #endregion

        /// <summary>
        /// Handles the Enter event of the MenuItemControl control.
        /// </summary>
        private void OnEnter()
        {
            // Check if item has a drop down strip.
            ToolStripDropDown objToolStripDropDown = this.DropDown;
            if (objToolStripDropDown != null)
            {
                // Show drop down strip.
                objToolStripDropDown.Show();
            }
        }

        /// <summary>Retrieves a value indicating whether a defined shortcut key is valid.</summary>
        /// <returns>true if the shortcut key is valid; otherwise, false. </returns>
        /// <param name="shortcut">The shortcut key to test for validity.</param>
        private bool IsValidShortcut(Keys shortcut)
        {
            Keys keys = shortcut & Keys.KeyCode;
            Keys keys2 = shortcut & ~Keys.KeyCode;
            if (shortcut == Keys.None)
            {
                return false;
            }
            switch (keys)
            {
                case Keys.Delete:
                case Keys.Insert:
                    return true;
            }
            if ((keys < Keys.F1) || (keys > Keys.F24))
            {
                if ((keys == Keys.None) || (keys2 == Keys.None))
                {
                    return false;
                }
                switch (keys)
                {
                    case Keys.ShiftKey:
                    case Keys.ControlKey:
                    case Keys.Menu:
                        return false;
                }
                if (keys2 == Keys.Shift)
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckedChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CheckedChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckStateChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CheckStateChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Gets the shortcut string.
        /// </summary>
        /// <returns></returns>
        private string GetShortcutString(Keys enmShortcutKeys)
        {
            if (mobjTypeConverter == null)
            {
                mobjTypeConverter = TypeDescriptor.GetConverter(typeof(Keys));
            }

            return mobjTypeConverter.ConvertToString(enmShortcutKeys);
        }

        /// <summary>
        /// Attacheds to DOM.
        /// </summary>
        internal void AttachedToDOM()
        {
            this.RegisterShortcut();

            foreach(ToolStripItem objToolStripItem in this.DropDownItems)
            {
                ToolStripMenuItem objMenuItem = objToolStripItem as ToolStripMenuItem ;
                if (objMenuItem != null)
                {
                    objMenuItem.AttachedToDOM();
                }
            }
        }

        /// <summary>
        /// Removings from DOM.
        /// </summary>
        internal void RemovingFromDOM()
        {
            this.UnregisterShortcut(false);

            foreach (ToolStripItem objToolStripItem in this.DropDownItems)
            {
                ToolStripMenuItem objMenuItem = objToolStripItem as ToolStripMenuItem;
                if (objMenuItem != null)
                {
                    objMenuItem.RemovingFromDOM();
                }
            }
        }

        /// <summary>
        /// Unregisters the shortcut.
        /// </summary>
        /// <param name="blnForce">if set to <c>true</c> [BLN force].</param>
        private void UnregisterShortcut(bool blnForce)
        {
            Keys enmKeys = this.menmShortcutKeys;

            if (enmKeys != Keys.None || blnForce)
            {
                Form objParentForm = this.GetForm(this.Owner);
                if (objParentForm != null)
                {
                    objParentForm.Shortcuts.Remove(this);
                }
            }
        }

        /// <summary>
        /// Registers the shortcut.
        /// </summary>
        private void RegisterShortcut()
        {
            Keys enmKeys = this.menmShortcutKeys;
            if (enmKeys != Keys.None)
            {
                Form objParentForm = this.GetForm(this.Owner);
                if (objParentForm != null)
                {
                    objParentForm.Shortcuts.Add(KeyToShortcut(enmKeys), this);
                }
            }
        }

        /// <summary>
        /// Keys to shortcut.
        /// </summary>
        /// <param name="enmKeys">The enm keys.</param>
        /// <returns></returns>
        private string KeyToShortcut(Keys enmKeys)
        {
            StringBuilder objShortcut = new StringBuilder();

            if ((enmKeys & Keys.Control) == Keys.Control)
            {
                objShortcut.Append("Ctrl");
            }
            if ((enmKeys & Keys.Shift) == Keys.Shift)
            {
                objShortcut.Append("Shift");
            }
            if ((enmKeys & Keys.Alt) == Keys.Alt)
            {
                objShortcut.Append("Alt");
            }

            objShortcut.Append(this.GetShortcutString(enmKeys & Keys.KeyCode));

            return objShortcut.ToString();
        }

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <returns></returns>
        private Form GetForm(Component objComponent)
        {
            if (objComponent is ToolStripDropDown)
            {
                return GetForm(((ToolStripDropDown)objComponent).OwnerItem);
            }
            else if (objComponent is ToolStrip)
            {
                return objComponent.Form;
            }
            else if (objComponent is ToolStripItem)
            {
                return GetForm(((ToolStripItem)objComponent).Owner);
            }
            return null;
        }

        /// <summary>
        /// Gets the shortcut key display string.
        /// </summary>
        /// <returns></returns>
        private string GetShortcutKeyDisplayString()
        {
            // Get shortcut display string
            string strShortcutKeyDisplayString = string.Empty;

            // Check if we need to show shortcut
            if (this.ShowShortcutKeys)
            {
                strShortcutKeyDisplayString = this.ShortcutKeyDisplayString;

                if (string.IsNullOrEmpty(strShortcutKeyDisplayString))
                {
                    // Get shortcut value
                    Keys enmShortcutKeys = this.ShortcutKeys;

                    if (enmShortcutKeys != Keys.None)
                    {
                        strShortcutKeyDisplayString = this.GetShortcutString(enmShortcutKeys);
                    }
                }
            }

            return strShortcutKeyDisplayString;
        }        

        #endregion Methods

        #region Events

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.Checked"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler CheckedChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripMenuItem.CheckedChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripMenuItem.CheckedChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the CheckedChanged handler.
        /// </summary>
        /// <value>The CheckedChanged handler.</value>
        private EventHandler CheckedChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripMenuItem.CheckedChangedEvent);
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler CheckStateChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripMenuItem.CheckStateChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripMenuItem.CheckStateChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the CheckStateChanged handler.
        /// </summary>
        /// <value>The CheckStateChanged handler.</value>
        private EventHandler CheckStateChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripMenuItem.CheckStateChangedEvent);
            }
        }

        #endregion Events

        #region Properties

        #region Proprety Store

        private bool mblnCheckOnClick
        {
            get
            {
                return this.GetValue<bool>(ToolStripMenuItem.mblnCheckOnClickProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripMenuItem.mblnCheckOnClickProperty, value);
            }
        }

        private CheckState menmCheckState
        {
            get
            {
                return this.GetValue<CheckState>(ToolStripMenuItem.menmCheckStateProperty, CheckState.Unchecked);
            }
            set
            {
                this.SetValue<CheckState>(ToolStripMenuItem.menmCheckStateProperty, value);
            }
        }

        private Form mobjMdiForm
        {
            get
            {
                return this.GetValue<Form>(ToolStripMenuItem.mobjMdiFormProperty, null);
            }
            set
            {
                this.SetValue<Form>(ToolStripMenuItem.mobjMdiFormProperty, value);
            }
        }

        private string mstrShortcutKeyDisplayString
        {
            get
            {
                return this.GetValue<string>(ToolStripMenuItem.mstrShortcutKeyDisplayStringProperty);
            }
            set
            {
                this.SetValue<string>(ToolStripMenuItem.mstrShortcutKeyDisplayStringProperty, value);
            }
        }

        private Keys menmShortcutKeys
        {
            get
            {
                return this.GetValue<Keys>(ToolStripMenuItem.menmShortcutKeysProperty, Keys.None);
            }
            set
            {
                this.SetValue<Keys>(ToolStripMenuItem.menmShortcutKeysProperty, value);
            }
        }

        private bool mblnShowShortcutKeys
        {
            get
            {
                return this.GetValue<bool>(ToolStripMenuItem.mblnShowShortcutKeysProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripMenuItem.mblnShowShortcutKeysProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether this instance is top level.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is top level; otherwise, <c>false</c>.
        /// </value>
        internal bool IsTopLevel
        {
            get
            {
                return !(base.ParentInternal is ToolStripDropDown);
            }
        }

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 7;
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked or is in an indeterminate state; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DefaultValue(false), Bindable(true), RefreshProperties(RefreshProperties.All), SRDescription("CheckBoxCheckedDescr"), SRCategory("CatAppearance")]
        public bool Checked
        {
            get
            {
                return (this.CheckState != CheckState.Unchecked);
            }
            set
            {
                if (value != this.Checked)
                {
                    this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked and unchecked when clicked.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked when clicked; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("ToolStripButtonCheckOnClickDescr")]
        public bool CheckOnClick
        {
            get
            {
                return this.mblnCheckOnClick;
            }
            set
            {
                if(this.mblnCheckOnClick != value)
                {
                    this.mblnCheckOnClick = value;
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is in the checked, unchecked, or indeterminate state.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property is not set to one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception> 
        ///<filterpriority>1</filterpriority>
        [RefreshProperties(RefreshProperties.All), SRDescription("CheckBoxCheckStateDescr"), SRCategory("CatAppearance"), DefaultValue(CheckState.Unchecked), Bindable(true)]
        public CheckState CheckState
        {
            get
            {
                return menmCheckState;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
                }
                if (value != this.CheckState)
                {
                    menmCheckState = value;

                    this.OnCheckedChanged(EventArgs.Empty);
                    this.OnCheckStateChanged(EventArgs.Empty);

                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns>
        ///   
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRCategory("CatLayout"), DefaultValue(ToolStripItemOverflow.Never), SRDescription("ToolStripItemOverflowDescr")]
        public ToolStripItemOverflow Overflow
        {
            get
            {
                return ToolStripItemOverflow.Never;
            }
            set
            {
            }
        }

        ///<summary>Gets the internal spacing within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value representing the spacing.</returns>
        protected override Padding DefaultPadding
        {
            get
            {
                if (base.IsOnDropDown)
                {
                    return new Padding(0, 1, 0, 1);
                }
                return new Padding(4, 0, 4, 0);
            }
        }

        ///<summary>Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, measured in pixels. The default is 100 pixels horizontally.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(0x20, 0x13);
            }
        }

        ///<summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a multiple document interface (MDI) window list.</summary> 
        ///<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a MDI window list; otherwise, false.</returns>
        [Browsable(false)]
        public bool IsMdiWindowListEntry
        {
            get
            {
                return (this.MdiForm != null);
            }
        }

        /// <summary>
        /// Gets the MDI form.
        /// </summary>
        /// <value>The MDI form.</value>
        internal Form MdiForm
        {
            get
            {
                return mobjMdiForm;
            }
        }

        ///<summary>Gets or sets the shortcut key text.</summary> 
        ///<returns>A <see cref="T:System.String"></see> representing the shortcut key.</returns>
        [SRDescription("ToolStripMenuItemShortcutKeyDisplayStringDescr"), SRCategory("CatAppearance"), Localizable(true), DefaultValue((string)null)]
        public string ShortcutKeyDisplayString
        {
            get
            {
                return this.mstrShortcutKeyDisplayString;
            }
            set
            {
                if (this.mstrShortcutKeyDisplayString != value)
                {
                    this.mstrShortcutKeyDisplayString = value;

                    // Update params.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        ///<summary>Gets or sets the shortcut keys associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Keys.None"></see>.</returns> 
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property was not set to one of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values.</exception>
        [Localizable(true), DefaultValue(Keys.None), SRDescription("MenuItemShortCutDescr")]
        public Keys ShortcutKeys
        {
            get
            {
                return menmShortcutKeys;
            }
            set
            {
                if ((value != Keys.None) && !this.IsValidShortcut(value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(Keys));
                }
                Keys shortcutKeys = this.ShortcutKeys;
                if (shortcutKeys != value)
                {
                    menmShortcutKeys = value;
                    if (!this.DesignMode)
                    {
                        if (value == Keys.None)
                        {
                            this.UnregisterShortcut(true);
                        }
                        else
                        {
                            this.RegisterShortcut();
                        }

                        // Update params.
                        UpdateParams(AttributeType.Visual);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the forecolor from skin.
        /// </summary>
        /// <value>
        /// The color of the skin fore.
        /// </value>
        protected override Color SkinForeColor
        {
            get
            {
                // Init result to default.
                Color objColor = Color.Empty;

                // Get skin.            
                ToolStripMenuItemSkin objToolStripMenuItemSkin = SkinFactory.GetSkin(this) as ToolStripMenuItemSkin;
                if (objToolStripMenuItemSkin != null)
                {
                    // Get forecolor value.
                    objColor = objToolStripMenuItemSkin.MenuItemStyle.ForeColor;
                }

                return objColor;
            }
        }

        ///<summary>Gets or sets a value indicating whether the shortcut keys that are associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> are displayed next to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary> 
        ///<returns>true if the shortcut keys are shown; otherwise, false. The default is true.</returns>
        [Localizable(true), SRDescription("MenuItemShowShortCutDescr"), DefaultValue(true)]
        public bool ShowShortcutKeys
        {
            get
            {
                return this.mblnShowShortcutKeys;
            }
            set
            {
                if (value != this.mblnShowShortcutKeys)
                {
                    this.mblnShowShortcutKeys = value;
                    
                    // Update params.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        #endregion Properties
    }

    #endregion ToolStripMenuItem Class

    #region ToolStripSplitButton Class

    /// <summary>Represents a combination of a standard button on the left and a drop-down button on the right, or the other way around if the value of <see cref="T:System.Windows.Forms.RightToLeft"></see> is Yes.</summary>
    [DefaultEvent("ButtonClick")]
    [Skin(typeof(ToolStripSplitButtonSkin))]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripSplitButton : ToolStripDropDownItem
    {
        #region Members

        private static readonly SerializableEvent ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof(EventHandler), typeof(ToolStripSplitButton));
        private static readonly SerializableEvent ButtonDoubleClickEvent = SerializableEvent.Register("ButtonDoubleClick", typeof(EventHandler), typeof(ToolStripSplitButton));
        private static readonly SerializableEvent DefaultItemChangedEvent = SerializableEvent.Register("DefaultItemChanged", typeof(EventHandler), typeof(ToolStripSplitButton));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class.</summary>
        public ToolStripSplitButton()
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text. </summary> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(string text)
            : base(text, null, (EventHandler)null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified image. </summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(ResourceHandle image)
            : base(null, image, (EventHandler)null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text and image.</summary> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(string text, ResourceHandle image)
            : base(text, image, (EventHandler)null)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, and <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler.</summary> 
        ///<param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(string text, ResourceHandle image, EventHandler onClick)
            : base(text, image, onClick)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler, and name.</summary> 
        ///<param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(string text, ResourceHandle image, EventHandler onClick, string name)
            : base(text, image, onClick, default(string))
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array.</summary> 
        ///<param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array of controls.</param> 
        ///<param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
        ///<param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
        public ToolStripSplitButton(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objConstrainingSize">Size of the obj constraining.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            // Get the text size
            Size objTotalSize = this.GetPreferredeSizeByText();

            // Get the skin
            ToolStripSplitButtonSkin objSkin = SkinFactory.GetSkin(this) as ToolStripSplitButtonSkin;

            // Add the DropDOwnArrow image's width
            if (objSkin != null)
            {
                objTotalSize.Width = objTotalSize.Width + objSkin.DropDownImageWidth + objSkin.DropDownImageContainerStyle.Border.Width.Left + objSkin.DropDownImageContainerStyle.Border.Width.Right;
            }

            // Apply the image's size
            objTotalSize = base.GetPreferredSizeByImage(objTotalSize);

            // Return preferred size with skin consideration
            return this.GetPreferredSizeByButtonSkin(objSkin, objTotalSize);
        }

        #region Render

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.DropDownItems.Count > 0)
            {
                objEvents.Set(WGEvents.Expand);
            }

            return objEvents;
        }

        #endregion

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonClick"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnButtonClick(EventArgs e)
        {
            EventHandler objEventHandler = this.ButtonClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonDoubleClick"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public virtual void OnButtonDoubleClick(EventArgs e)
        {
            EventHandler objEventHandler = this.ButtonDoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItemChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDefaultItemChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.DefaultItemChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>If the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property is true, calls the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSplitButton.OnButtonClick(System.EventArgs)"></see> method.</summary>
        public void PerformButtonClick()
        {
            if (this.Enabled && base.Available)
            {
                base.PerformClick();
                this.OnButtonClick(EventArgs.Empty);
            }
        }

        ///<summary>This method is not relevant to this class.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual void ResetDropDownButtonWidth()
        {
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                // The Arrow was clicked
                case "DropDown":
                    MouseEventArgs objArgs = GetMouseEventArgs(objEvent);
                    if ((objArgs.Button == MouseButtons.Left))
                    {
                        base.ShowDropDown();
                    }

                    break;
                default:
                    break;
            }

            base.FireEvent(objEvent);
        }


        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            this.OnButtonDoubleClick(new EventArgs());
        }

        #endregion Methods

        #region Events

        ///<summary>Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is clicked.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler ButtonClick
        {
            add
            {
                this.AddCriticalHandler(ToolStripSplitButton.ButtonClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripSplitButton.ButtonClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the ButtonClick handler.
        /// </summary>
        /// <value>The ButtonClick handler.</value>
        private EventHandler ButtonClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripSplitButton.ButtonClickEvent);
            }
        }

        ///<summary>Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is double-clicked.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler ButtonDoubleClick
        {
            add
            {
                this.AddCriticalHandler(ToolStripSplitButton.ButtonDoubleClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripSplitButton.ButtonDoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the ButtonDoubleClick handler.
        /// </summary>
        /// <value>The ButtonDoubleClick handler.</value>
        private EventHandler ButtonDoubleClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripSplitButton.ButtonDoubleClickEvent);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItem"></see> has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler DefaultItemChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripSplitButton.DefaultItemChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripSplitButton.DefaultItemChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the DefaultItemChanged handler.
        /// </summary>
        /// <value>The DefaultItemChanged handler.</value>
        private EventHandler DefaultItemChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripSplitButton.DefaultItemChangedEvent);
            }
        }

        #endregion Events

        #region Properties

        ///<summary>Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<returns>true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
        [DefaultValue(true)]
        public bool AutoToolTip
        {
            get
            {
                return base.AutoToolTip;
            }
            set
            {
                base.AutoToolTip = value;
            }
        }

        ///<summary>Gets the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ButtonBounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets a value indicating whether the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary> 
        ///<returns>true if the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ButtonPressed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 2;
            }
        }

        ///<summary>Gets a value indicating whether the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> property is true.</summary> 
        ///<returns>true if the button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or whether <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> is true; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool ButtonSelected
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default. </summary> 
        ///<returns>true in all cases.</returns>
        protected override bool DefaultAutoToolTip
        {
            get
            {
                return true;
            }
        }

        ///<summary>Gets or sets the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when the control is first selected.</summary> 
        ///<returns>A Forms.ToolStripItem representing the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when first selected. The default value is null.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem DefaultItem
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets the size and location, in screen coordinates, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>, in screen coordinates.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Rectangle DropDownButtonBounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets a value indicating whether the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary> 
        ///<returns>true if the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool DropDownButtonPressed
        {
            get
            {
                return this.DropDown.Visible;
            }
        }

        ///<summary>Gets a value indicating whether the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected.</summary> 
        ///<returns>true if the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool DropDownButtonSelected
        {
            get
            {
                return false;
            }
        }

        ///<summary>The width, in pixels, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<returns>An <see cref="T:System.Int32"></see> representing the width in pixels.</returns> 
        ///<exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than zero (0). </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DropDownButtonWidth
        {
            get
            {
                return -1;
            }
            set
            {
            }
        }

        ///<summary>Gets the boundaries of the separator between the standard and drop-down button portions of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the separator.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Rectangle SplitterBounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripSplitButton Class

    #region ToolStripItemCollection Class

    /// <summary>Represents a collection of <see cref="T:System.Windows.Forms.ToolStripItem"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
    [Serializable()]
    public class ToolStripItemCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
    {
        #region Members

        private bool mblnIsReadOnly;
        private bool mblnItemsCollection;
        private int mintLastAccessedIndex;
        private ToolStrip mobjOwnerToolStrip;

        #endregion Members

        #region Constructors

        internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection, bool isReadOnly)
        {
            this.mintLastAccessedIndex = -1;
            this.mobjOwnerToolStrip = owner;
            this.mblnItemsCollection = itemsCollection;
            this.mblnIsReadOnly = isReadOnly;
        }

        internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection)
            : this(owner, itemsCollection, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> class with the specified container <see cref="T:System.Windows.Forms.ToolStrip"></see> and the specified array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls.</summary>
        /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStrip"></see> to which this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> belongs. </param>
        /// <param name="value">An array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> containing the initial controls for this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
        /// <exception cref="T:System.ArgumentNullException">The owner parameter is null.</exception>
        public ToolStripItemCollection(ToolStrip owner, ToolStripItem[] value)
        {
            this.mintLastAccessedIndex = -1;
            if (owner == null)
            {
                throw new ArgumentNullException("owner");
            }
            this.mobjOwnerToolStrip = owner;
            this.AddRange(value);
        }

		#endregion Constructors 

		#region Properties 

        bool IList.IsFixedSize
        {
            get
            {
                return base.InnerList.IsFixedSize;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return base.InnerList[index];
            }
            set
            {
                throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only; otherwise, false.</returns>
        public override bool IsReadOnly
        {
            get
            {
                return this.mblnIsReadOnly;
            }
        }

        /// <summary>Gets the item at the specified index.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> located at the specified position in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>.</returns>
        /// <param name="index">The zero-based index of the item to get.</param>
        /// <filterpriority>1</filterpriority>
        public virtual ToolStripItem this[int index]
        {
            get
            {
                return (ToolStripItem)base.InnerList[index];
            }
        }

        /// <summary>Gets the item with the specified name.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified name.</returns>
        /// <param name="key">The name of the item to get.</param>
        /// <filterpriority>1</filterpriority>
        public virtual ToolStripItem this[string key]
        {
            get
            {
                if ((key != null) && (key.Length != 0))
                {
                    int index = this.IndexOfKey(key);
                    if (this.IsValidIndex(index))
                    {
                        return (ToolStripItem)base.InnerList[index];
                    }
                }
                return null;
            }
        }

		#endregion Properties 

		#region Methods 

        /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image to the collection.</summary>
        /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        public ToolStripItem Add(ResourceHandle image)
        {
            return this.Add(null, image, null);
        }

        /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified text to the collection.</summary>
        /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        public ToolStripItem Add(string text)
        {
            return this.Add(text, null, null);
        }

        /// <summary>Adds the specified item to the end of the collection.</summary>
        /// <returns>An <see cref="T:System.Int32"></see> representing the zero-based index of the new item in the collection.</returns>
        /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to add to the end of the collection. </param>
        /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public int Add(ToolStripItem value)
        {
            this.CheckCanAddOrInsertItem(value);
            this.SetOwner(value);
            value.InternalParent = mobjOwnerToolStrip;
            int num = base.InnerList.Add(value);
            if (this.mblnItemsCollection && (this.mobjOwnerToolStrip != null))
            {
                this.mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
            }
            return num;

        }

        /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection.</summary>
        /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        public ToolStripItem Add(string text, ResourceHandle image)
        {
            return this.Add(text, image, null);
        }

        /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection and that raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</summary>
        /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        /// <param name="onClick">Raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</param>
        /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
        public ToolStripItem Add(string text, ResourceHandle image, EventHandler onClick)
        {
            ToolStripItem item = this.mobjOwnerToolStrip.CreateDefaultItem(text, image, onClick);
            this.Add(item);
            return item;
        }

        /// <summary>Adds an array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls to the collection.</summary>
        /// <param name="toolStripItems">An array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls. </param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void AddRange(ToolStripItem[] toolStripItems)
        {
            if (toolStripItems == null)
            {
                throw new ArgumentNullException("toolStripItems");
            }

            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }

            for (int i = 0; i < toolStripItems.Length; i++)
            {
                this.Add(toolStripItems[i]);
            }
        }

        /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to the current collection.</summary>
        /// <param name="toolStripItems">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to be added to the current collection. </param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void AddRange(ToolStripItemCollection toolStripItems)
        {
            if (toolStripItems == null)
            {
                throw new ArgumentNullException("toolStripItems");
            }

            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }

            int count = toolStripItems.Count;
            for (int i = 0; i < count; i++)
            {
                this.Add(toolStripItems[i]);
            }
        }

        /// <summary>Removes all items from the collection.</summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual void Clear()
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }
            if (this.Count != 0)
            {
                while (this.Count != 0)
                {
                    this.RemoveAt(this.Count - 1);
                }
            }
        }

        /// <summary>Determines whether the specified item is a member of the collection.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is a member of the current <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>; otherwise, false.</returns>
        /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(ToolStripItem value)
        {
            return base.InnerList.Contains(value);
        }

        /// <summary>Determines whether the collection contains an item with the specified key.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> contains a <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified key; otherwise, false.</returns>
        /// <param name="key">The key to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsKey(string key)
        {
            return this.IsValidIndex(this.IndexOfKey(key));
        }

        /// <summary>Copies the collection into the specified position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> array.</summary>
        /// <param name="array">The array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> to which to copy the collection. </param>
        /// <param name="index">The position in the <see cref="T:System.Windows.Forms.ToolStripItem"></see> array at which to paste the collection. </param>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(ToolStripItem[] array, int index)
        {
            base.InnerList.CopyTo(array, index);
        }

        /// <summary>Searches for items by their name and returns an array of all matching controls.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItem"></see> array of the search results.</returns>
        /// <param name="searchAllChildren">true to search child items of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter; otherwise, false. </param>
        /// <param name="key">The item name to search the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> for.</param>
        /// <exception cref="T:System.ArgumentNullException">The key parameter is null or empty.</exception>
        public ToolStripItem[] Find(string key, bool searchAllChildren)
        {
            if ((key == null) || (key.Length == 0))
            {
                throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
            }
            ArrayList list = this.FindInternal(key, searchAllChildren, this, new ArrayList());
            ToolStripItem[] array = new ToolStripItem[list.Count];
            list.CopyTo(array, 0);
            return array;
        }

        /// <summary>Retrieves the index of the specified item in the collection.</summary>
        /// <returns>A zero-based index value that represents the position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>, if found; otherwise, -1.</returns>
        /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(ToolStripItem value)
        {
            return base.InnerList.IndexOf(value);
        }

        /// <summary>Retrieves the index of the first occurrence of the specified item within the collection.</summary>
        /// <returns>A zero-based index value that represents the position of the first occurrence of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter, if found; otherwise, -1.</returns>
        /// <param name="key">The name of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for. </param>
        /// <filterpriority>1</filterpriority>
        public virtual int IndexOfKey(string key)
        {
            if ((key != null) && (key.Length != 0))
            {
                if (this.IsValidIndex(this.mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[this.mintLastAccessedIndex].Name, key, true))
                {
                    return this.mintLastAccessedIndex;
                }
                for (int i = 0; i < this.Count; i++)
                {
                    if (ClientUtils.SafeCompareStrings(this[i].Name, key, true))
                    {
                        this.mintLastAccessedIndex = i;
                        return i;
                    }
                }
                this.mintLastAccessedIndex = -1;
            }
            return -1;
        }

        /// <summary>Inserts the specified item into the collection at the specified index.</summary>
        /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to insert. </param>
        /// <param name="index">The location in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> at which to insert the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. </param>
        /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Insert(int index, ToolStripItem value)
        {
            this.CheckCanAddOrInsertItem(value);
            this.SetOwner(value);
            base.InnerList.Insert(index, value);
            if (this.mblnItemsCollection && (this.mobjOwnerToolStrip != null))
            {
                this.mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
            }

        }

        /// <summary>Removes the specified item from the collection.</summary>
        /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove from the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Remove(ToolStripItem value)
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }
            base.InnerList.Remove(value);
            this.OnAfterRemove(value);

            value.InternalParent = null;
        }

        /// <summary>Removes an item from the specified index in the collection.</summary>
        /// <param name="index">The index value of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void RemoveAt(int index)
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }
            ToolStripItem item = null;
            if ((index < this.Count) && (index >= 0))
            {
                item = (ToolStripItem)base.InnerList[index];
            }
            base.InnerList.RemoveAt(index);
            this.OnAfterRemove(item);

            if (item != null)
            {
                item.InternalParent = null;
            }
        }

        /// <summary>Removes the item that has the specified key.</summary>
        /// <param name="key">The key of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual void RemoveByKey(string key)
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }
            int index = this.IndexOfKey(key);
            if (this.IsValidIndex(index))
            {
                this.RemoveAt(index);
            }
        }


        private void CheckCanAddOrInsertItem(ToolStripItem value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
            }
            ToolStripDropDown owner = this.mobjOwnerToolStrip as ToolStripDropDown;
            if (owner != null)
            {
                if (owner.OwnerItem == value)
                {
                    throw new NotSupportedException(SR.GetString("ToolStripItemCircularReference"));
                }
            }
        }

        private ArrayList FindInternal(string key, bool searchAllChildren, ToolStripItemCollection itemsToLookIn, ArrayList foundItems)
        {
            if ((itemsToLookIn == null) || (foundItems == null))
            {
                return null;
            }
            try
            {
                for (int i = 0; i < itemsToLookIn.Count; i++)
                {
                    if ((itemsToLookIn[i] != null))
                    {
                        foundItems.Add(itemsToLookIn[i]);
                    }
                }
                if (!searchAllChildren)
                {
                    return foundItems;
                }
                for (int j = 0; j < itemsToLookIn.Count; j++)
                {
                    ToolStripDropDownItem item = itemsToLookIn[j] as ToolStripDropDownItem;
                    if ((item != null) && item.HasDropDownItems)
                    {
                        foundItems = this.FindInternal(key, searchAllChildren, item.DropDownItems, foundItems);
                    }
                }
            }
            catch (Exception exception)
            {
                if (ClientUtils.IsCriticalException(exception))
                {
                    throw;
                }
            }
            return foundItems;
        }

        int IList.Add(object objValue)
        {
            return this.Add(objValue as ToolStripItem);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object objValue)
        {
            return base.InnerList.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.IndexOf(objValue as ToolStripItem);
        }

        void IList.Insert(int index, object objValue)
        {
            this.Insert(index, objValue as ToolStripItem);
        }

        void IList.Remove(object objValue)
        {
            this.Remove(objValue as ToolStripItem);
        }

        void IList.RemoveAt(int intIndex)
        {
            this.RemoveAt(intIndex);
        }

        private bool IsValidIndex(int intIndex)
        {
            return ((intIndex >= 0) && (intIndex < this.Count));
        }

        private void OnAfterRemove(ToolStripItem objToolStripItem)
        {
            if (this.mblnItemsCollection)
            {
                if (objToolStripItem != null)
                {
                    objToolStripItem.SetOwner(null);
                }

                if (this.mobjOwnerToolStrip != null)
                {
                    this.mobjOwnerToolStrip.OnItemRemoved(new ToolStripItemEventArgs(objToolStripItem));
                }
            }
        }

        private void SetOwner(ToolStripItem objToolStripItem)
        {
            if (this.mblnItemsCollection && (objToolStripItem != null))
            {
                if (objToolStripItem.Owner != null)
                {
                    objToolStripItem.Owner.Items.Remove(objToolStripItem);
                }
                objToolStripItem.SetOwner(this.mobjOwnerToolStrip);
            }
        }


        internal void MoveItem(ToolStripItem objToolStripItem)
        {
            if (objToolStripItem.ParentInternal != null)
            {
                int index = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
                if (index >= 0)
                {
                    objToolStripItem.ParentInternal.Items.RemoveAt(index);
                }
            }
            this.Add(objToolStripItem);
        }

        internal void MoveItem(int index, ToolStripItem objToolStripItem)
        {
            if (index == this.Count)
            {
                this.MoveItem(objToolStripItem);
            }
            else
            {
                if (objToolStripItem.ParentInternal != null)
                {
                    int num = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
                    if (num >= 0)
                    {
                        objToolStripItem.ParentInternal.Items.RemoveAt(num);
                        if ((objToolStripItem.ParentInternal == this.mobjOwnerToolStrip) && (index > num))
                        {
                            index--;
                        }
                    }
                }
                this.Insert(index, objToolStripItem);
            }
        }


		#endregion Methods 

    }

    #endregion ToolStripItemCollection Class

    #region ToolStripControlHost Class

    /// <summary>Hosts custom controls or Windows Forms controls.</summary>
    [Skin(typeof(ToolStripControlHostSkin))]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ProxyComponent(typeof(ProxyToolStripControlHost))]
    public class ToolStripControlHost : ToolStripItem
    {
        #region Members

        private static readonly SerializableProperty mobjControlProperty = SerializableProperty.Register("mobjControl", typeof(Control), typeof(ToolStripControlHost));
        private static readonly SerializableProperty menmControlAlignProperty = SerializableProperty.Register("menmControlAlign", typeof(ContentAlignment), typeof(ToolStripControlHost));

        private static readonly SerializableEvent DisplayStyleChangedEvent = SerializableEvent.Register("DisplayStyleChanged", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent GotFocusEvent = SerializableEvent.Register("GotFocus", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent KeyDownEvent = SerializableEvent.Register("KeyDown", typeof(KeyEventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent KeyPressEvent = SerializableEvent.Register("KeyPress", typeof(KeyPressEventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent KeyUpEvent = SerializableEvent.Register("KeyUp", typeof(KeyEventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent LeaveEvent = SerializableEvent.Register("Leave", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent LostFocusEvent = SerializableEvent.Register("LostFocus", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent ValidatedEvent = SerializableEvent.Register("Validated", typeof(EventHandler), typeof(ToolStripControlHost));
        private static readonly SerializableEvent ValidatingEvent = SerializableEvent.Register("Validating", typeof(EventHandler), typeof(ToolStripControlHost));

        private int intSuspendSyncSizeCount;

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control.</summary> 
        ///<param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class. </param> 
        ///<exception cref="T:System.ArgumentNullException">The control referred to by the c parameter is null.</exception>
        public ToolStripControlHost(Control objControl)
        {
            this.menmControlAlign = ContentAlignment.MiddleCenter;
            if (objControl == null)
            {
                throw new ArgumentNullException("objControl", "ControlCannotBeNull");
            }
            this.mobjControl = objControl;
            this.SyncControlParent();
            objControl.Visible = true;
            this.SetBounds(objControl.Bounds);
            Rectangle bounds = this.Bounds;
            objControl.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            this.OnSubscribeControlEvents(objControl);
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control and that has the specified name.</summary> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see>.</param> 
        ///<param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class.</param>
        public ToolStripControlHost(Control objControl, string name) : this(objControl)
        {
            base.Name = name;
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Pres the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
        {
            base.PreRenderToolStripItem(objContext, lngRequestID);

            if (this.Control != null)
            {
                this.Control.PreRenderControl(objContext, lngRequestID);
            }
        }

        /// <summary>
        /// Posts the render tool strip item.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
        {
            base.PostRenderToolStripItem(objContext, lngRequestID);

            if (this.Control != null)
            {
                this.Control.PostRenderControl(objContext, lngRequestID);
            }
        }

        /// <summary>
        /// Gets the preferred size.
        /// </summary>
        /// <param name="objConstrainingSize"></param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objConstrainingSize)
        {
            if (this.Control != null)
            {
                // Get contained control's size.
                Size objControlSize = this.Control.Size;

                // Try getting the hosted control's size
                Size objPreferredSize = this.Control.GetPreferredSize(objControlSize);

                // Check if given size is empty
                if (objPreferredSize == Size.Empty)
                {
                    objPreferredSize = objControlSize;
                }

                // Check if given size is not empty
                if (objPreferredSize != Size.Empty)
                {
                    // Get the menu item's skin
                    ToolStripMenuItemSkin objToolStripMenuItemSkin = SkinFactory.GetSkin(this, typeof(ToolStripMenuItemSkin)) as ToolStripMenuItemSkin;

                    if (objToolStripMenuItemSkin != null)
                    {
                        // Get the menu item's border width.
                        BorderWidth objMenuItemBorderWidth = objToolStripMenuItemSkin.MenuItemStyle.Border.Style != BorderStyle.None ? objToolStripMenuItemSkin.MenuItemStyle.Border.Width : BorderWidth.Empty;

                        // Add the menu item's border width values to preferred size.
                        objPreferredSize.Width += objMenuItemBorderWidth.Left + objMenuItemBorderWidth.Right;
                        objPreferredSize.Height += objMenuItemBorderWidth.Top + objMenuItemBorderWidth.Bottom;
                    }
                    
                    return objPreferredSize;
                }
            }

            return this.DefaultSize;
        }

        #region Render

        /// <summary>
        /// Renders the tool strip item's controls.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected override void RenderToolStripItemControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            base.RenderToolStripItemControls(objContext, objWriter, lngRequestID);

            // Try getting hosted control.
            Control objControl = this.Control;
            if (objControl != null)
            {
                // Render hosted control.
                objControl.RenderControl(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.
        /// </summary>
        protected override void OnBoundsChanged()
        {
            if (this.Control == null)
            {
                return;
            }

            this.SuspendSizeSync();

            IArrangedElement arrangedElement = (IArrangedElement)this.Control;
            if (arrangedElement == null)
            {
                return;
            }

            Rectangle bounds1 = LayoutUtils.Align(LayoutUtils.DeflateRect(this.Bounds, this.Padding).Size, this.Bounds, this.ControlAlign);
            arrangedElement.SetBounds(bounds1, BoundsSpecified.None);
            if (bounds1 != this.Control.Bounds)
            {
                Rectangle bounds2 = LayoutUtils.Align(this.Control.Size, this.Bounds, this.ControlAlign);
                arrangedElement.SetBounds(bounds2, BoundsSpecified.None);
            }

            this.ResumeSizeSync();

            this.Control.Update();
        }


        /// <summary>
        /// Register a component.
        /// </summary>
        /// <param name="objComponent">Component.</param>
        protected override void RegisterComponent(IRegisteredComponent objComponent)
        {
            base.RegisterComponent(objComponent);

            // Check if registering self.
            if (objComponent == this)
            {
                // Try getting hosted control.
                Control objControl = this.Control;
                if (objControl != null)
                {
                    base.RegisterComponent(objControl);
                }
            }
        }

        /// <summary>
        /// Unregister a component.
        /// </summary>
        /// <param name="objComponent">Component.</param>
        protected override void UnRegisterComponent(IRegisteredComponent objComponent)
        {
            base.UnRegisterComponent(objComponent);

            // Check if registering self.
            if (objComponent == this)
            {
                // Try getting hosted control.
                Control objControl = this.Control;
                if (objControl != null)
                {
                    base.UnRegisterComponent(objControl);
                }
            }
        }

        #endregion

        private Control.ControlCollection GetControlCollection(ToolStrip objToolStrip)
        {
            return ((objToolStrip != null) ? (objToolStrip.Controls) : null);
        }

        private void SyncControlParent()
        {
            Control.ControlCollection objControlCollection = GetControlCollection(base.ParentInternal);
            if (objControlCollection != null)
            {
                objControlCollection.Add(this.Control);
            }
        }

        ///<summary>Gives the focus to a control.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void Focus()
        {
            this.Control.Focus();
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Enter"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnEnter(EventArgs e)
        {
            EventHandler objEventHandler = this.EnterHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.GotFocus"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnGotFocus(EventArgs e)
        {
            EventHandler objEventHandler = this.GotFocusHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Synchronizes the resizing of the control host with the resizing of the hosted control.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnHostedControlResize(EventArgs e)
        {
            this.Size = this.Control.Size;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyDown"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            KeyEventHandler objEventHandler = this.KeyDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyPress"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data.</param>
        protected virtual void OnKeyPress(KeyPressEventArgs e)
        {
            KeyPressEventHandler objEventHandler = this.KeyPressHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyUp"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected virtual void OnKeyUp(KeyEventArgs e)
        {
            KeyEventHandler objEventHandler = this.KeyUpHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Leave"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnLeave(EventArgs e)
        {
            EventHandler objEventHandler = this.LeaveHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.LostFocus"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnLostFocus(EventArgs e)
        {
            EventHandler objEventHandler = this.LostFocusHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        private void HandleClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void HandleBackColorChanged(object sender, EventArgs e)
        {
            this.OnBackColorChanged(e);
        }

        private void HandleDoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }

        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            this.OnDragDrop(e);
        }

        private void HandleEnabledChanged(object sender, EventArgs e)
        {
            this.OnEnabledChanged(e);
        }

        private void HandleForeColorChanged(object sender, EventArgs e)
        {
            this.OnForeColorChanged(e);
        }

        private void HandleGotFocus(object sender, EventArgs e)
        {
            this.OnGotFocus(e);
        }

        private void HandleLeave(object sender, EventArgs e)
        {
            this.OnLeave(e);
        }

        private void HandleEnter(object sender, EventArgs e)
        {
            this.OnEnter(e);
        }

        private void HandleLocationChanged(object sender, EventArgs e)
        {
            this.OnLocationChanged(e);
        }

        private void HandleLostFocus(object sender, EventArgs e)
        {
            this.OnLostFocus(e);
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void HandleResize(object sender, EventArgs e)
        {
            this.OnHostedControlResize(e);
        }

        private void HandleTextChanged(object sender, EventArgs e)
        {
            this.OnTextChanged(e);
        }

        private void HandleControlVisibleChanged(object sender, EventArgs e)
        {
            bool participatesInLayout = ((IArrangedElement)this.Control).ParticipatesInLayout;
            if (((IArrangedElement)this).ParticipatesInLayout != participatesInLayout)
            {
                base.Visible = this.Control.Visible;
            }
        }

        private void HandleValidated(object sender, EventArgs e)
        {
            this.OnValidated(e);
        }

        private void HandleValidating(object sender, CancelEventArgs e)
        {
            this.OnValidating(e);
        }

        ///<summary>Subscribes events from the hosted control.</summary> 
        ///<param name="objControl">The control from which to subscribe events.</param>
        protected virtual void OnSubscribeControlEvents(Control objControl)
        {
            if (objControl != null)
            {
                objControl.BackColorChanged += new EventHandler(this.HandleBackColorChanged);
                objControl.DragDrop += new DragEventHandler(this.HandleDragDrop);
                objControl.EnabledChanged += new EventHandler(this.HandleEnabledChanged);
                objControl.ForeColorChanged += new EventHandler(this.HandleForeColorChanged);
                objControl.LocationChanged += new EventHandler(this.HandleLocationChanged);
                objControl.Resize += new EventHandler(this.HandleResize);
                objControl.VisibleChanged += new EventHandler(this.HandleControlVisibleChanged);
            }
        }

        ///<summary>Unsubscribes events from the hosted control.</summary> 
        ///<param name="objControl">The control from which to unsubscribe events.</param>
        protected virtual void OnUnsubscribeControlEvents(Control objControl)
        {
            if (objControl != null)
            {
                objControl.BackColorChanged -= new EventHandler(this.HandleBackColorChanged);
                objControl.DragDrop -= new DragEventHandler(this.HandleDragDrop);
                objControl.EnabledChanged -= new EventHandler(this.HandleEnabledChanged);
                objControl.ForeColorChanged -= new EventHandler(this.HandleForeColorChanged);
                objControl.LocationChanged -= new EventHandler(this.HandleLocationChanged);
                objControl.Resize -= new EventHandler(this.HandleResize);
                objControl.VisibleChanged -= new EventHandler(this.HandleControlVisibleChanged);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validated"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnValidated(EventArgs e)
        {
            EventHandler objEventHandler = this.ValidatedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validating"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
        protected virtual void OnValidating(CancelEventArgs e)
        {
            EventHandler objEventHandler = this.ValidatingHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Suspends the size sync.
        /// </summary>
        private void SuspendSizeSync()
        {
            ++this.intSuspendSyncSizeCount;
        }

        /// <summary>
        /// Resumes the size sync.
        /// </summary>
        private void ResumeSizeSync()
        {
            --this.intSuspendSyncSizeCount;
        }

        /// <summary>
        /// Shoulds the color of the serialize back.
        /// </summary>
        /// <returns></returns>
        internal override bool ShouldSerializeBackColor()
        {
            return this.Control.ShouldSerializeBackColor();
        }

        /// <summary>
        /// Shoulds the color of the serialize fore.
        /// </summary>
        /// <returns></returns>
        internal override bool ShouldSerializeForeColor()
        {
            return this.Control.ShouldSerializeForeColor();
        }

        /// <summary>
        /// Shoulds the serialize right to left.
        /// </summary>
        /// <returns></returns>
        internal override bool ShouldSerializeRightToLeft()
        {
            return this.Control.ShouldSerializeRightToLeft();
        }

        /// <summary>
        /// Shoulds the serialize font.
        /// </summary>
        /// <returns></returns>
        internal override bool ShouldSerializeFont()
        {
            return this.Control.ShouldSerializeFont();
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            List<Control> objList = new List<Control>();
            objList.Add(this.Control);
            return objList;
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.
        /// </summary>
        /// <param name="oldParent">The original parent of the item.</param>
        /// <param name="newParent">The new parent of the item.</param>
        protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
        {
            if (oldParent != null && this.Owner == null && (newParent == null && this.Control != null))
            {
                Control.ControlCollection objControlCollection = GetControlCollection(this.Control.ParentInternal as ToolStrip);
                if (objControlCollection != null)
                {
                    objControlCollection.Remove(this.Control);
                }
            }
            else
            {
                this.SyncControlParent();
            }

            base.OnParentChanged(oldParent, newParent);
        }

        #endregion Methods

        #region Events



        ///<summary>This event is not relevant to this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler DisplayStyleChanged
        {
            add
            {
                this.AddCriticalHandler(ToolStripControlHost.DisplayStyleChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.DisplayStyleChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the DisplayStyleChanged handler.
        /// </summary>
        /// <value>The DisplayStyleChanged handler.</value>
        private EventHandler DisplayStyleChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.DisplayStyleChangedEvent);
            }
        }

        ///<summary>Occurs when the hosted control is entered.</summary>
        [SRDescription("ControlOnEnterDescr"), SRCategory("CatFocus")]
        public event EventHandler Enter
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.EnterEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Enter += new EventHandler(this.HandleEnter);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.EnterEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.EnterEvent, value);

                if (!this.HasHandler(ToolStripControlHost.EnterEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Enter -= new EventHandler(this.HandleEnter);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Enter handler.
        /// </summary>
        /// <value>The Enter handler.</value>
        private EventHandler EnterHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.EnterEvent);
            }
        }

        ///<summary>Occurs when the hosted control receives focus.</summary> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatFocus"), SRDescription("ToolStripItemOnGotFocusDescr"), EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event EventHandler GotFocus
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.GotFocusEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.GotFocus += new EventHandler(this.HandleGotFocus);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.GotFocusEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.GotFocusEvent, value);

                if (!this.HasHandler(ToolStripControlHost.GotFocusEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.GotFocus -= new EventHandler(this.HandleGotFocus);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the GotFocus handler.
        /// </summary>
        /// <value>The GotFocus handler.</value>
        private EventHandler GotFocusHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.GotFocusEvent);
            }
        }

        ///<summary>Occurs when a key is pressed and held down while the hosted control has focus.</summary> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ControlOnKeyDownDescr"), SRCategory("CatKey")]
        public event KeyEventHandler KeyDown
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.KeyDownEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyDown += new KeyEventHandler(this.HandleKeyDown);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.KeyDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.KeyDownEvent, value);

                if (!this.HasHandler(ToolStripControlHost.KeyDownEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyDown -= new KeyEventHandler(this.HandleKeyDown);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the KeyDown handler.
        /// </summary>
        /// <value>The KeyDown handler.</value>
        private KeyEventHandler KeyDownHandler
        {
            get
            {
                return this.GetHandler(ToolStripControlHost.KeyDownEvent) as KeyEventHandler;
            }
        }

        ///<summary>Occurs when a key is pressed while the hosted control has focus.</summary> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatKey"), SRDescription("ControlOnKeyPressDescr")]
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.KeyPressEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyPress += new KeyPressEventHandler(this.HandleKeyPress);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.KeyPressEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.KeyPressEvent, value);

                if (!this.HasHandler(ToolStripControlHost.KeyPressEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyPress -= new KeyPressEventHandler(this.HandleKeyPress);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the KeyPress handler.
        /// </summary>
        /// <value>The KeyPress handler.</value>
        private KeyPressEventHandler KeyPressHandler
        {
            get
            {
                return this.GetHandler(ToolStripControlHost.KeyPressEvent) as KeyPressEventHandler;
            }
        }

        /// <summary>
        /// Gets the key up handler.
        /// </summary>
        private KeyEventHandler KeyUpHandler
        {
            get
            {
                return this.GetHandler(ToolStripControlHost.KeyUpEvent) as KeyEventHandler;
            }
        }

        ///<summary>Occurs when a key is released while the hosted control has focus.</summary> 
        ///<filterpriority>1</filterpriority>
        [SRCategory("CatKey"), SRDescription("ControlOnKeyUpDescr")]
        public event KeyEventHandler KeyUp
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.KeyUpEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyUp += new KeyEventHandler(this.HandleKeyUp);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.KeyUpEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.KeyUpEvent, value);

                if (!this.HasHandler(ToolStripControlHost.KeyUpEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.KeyUp -= new KeyEventHandler(this.HandleKeyUp);
                    }
                }
            }
        }

        ///<summary>Occurs when the input focus leaves the hosted control.</summary>
        [SRCategory("CatFocus"), SRDescription("ControlOnLeaveDescr")]
        public event EventHandler Leave
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.LeaveEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Leave += new EventHandler(this.HandleLeave);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.LeaveEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.LeaveEvent, value);

                if (!this.HasHandler(ToolStripControlHost.LeaveEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Leave -= new EventHandler(this.HandleLeave);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Leave handler.
        /// </summary>
        /// <value>The Leave handler.</value>
        private EventHandler LeaveHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.LeaveEvent);
            }
        }

        ///<summary>Occurs when the hosted control loses focus.</summary> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ToolStripItemOnLostFocusDescr"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), SRCategory("CatFocus")]
        public event EventHandler LostFocus
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.LostFocusEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.LostFocus += new EventHandler(this.HandleLostFocus);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.LostFocusEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.LostFocusEvent, value);

                if (!this.HasHandler(ToolStripControlHost.LostFocusEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.LostFocus -= new EventHandler(this.HandleLostFocus);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the LostFocus handler.
        /// </summary>
        /// <value>The LostFocus handler.</value>
        private EventHandler LostFocusHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.LostFocusEvent);
            }
        }

        ///<summary>Occurs after the hosted control has been successfully validated.</summary>
        [SRDescription("ControlOnValidatedDescr"), SRCategory("CatFocus")]
        public event EventHandler Validated
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.ValidatedEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Validated += new EventHandler(this.HandleValidated);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.ValidatedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.ValidatedEvent, value);

                if (!this.HasHandler(ToolStripControlHost.ValidatedEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Validated -= new EventHandler(this.HandleValidated);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Validated handler.
        /// </summary>
        /// <value>The Validated handler.</value>
        private EventHandler ValidatedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.ValidatedEvent);
            }
        }

        ///<summary>Occurs while the hosted control is validating.</summary>
        [SRCategory("CatFocus"), SRDescription("ControlOnValidatingDescr")]
        public event CancelEventHandler Validating
        {
            add
            {
                if (!this.HasHandler(ToolStripControlHost.ValidatingEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Validating += new CancelEventHandler(this.HandleValidating);
                    }
                }

                this.AddCriticalHandler(ToolStripControlHost.ValidatingEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripControlHost.ValidatingEvent, value);

                if (!this.HasHandler(ToolStripControlHost.ValidatingEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Validating -= new CancelEventHandler(this.HandleValidating);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Validating handler.
        /// </summary>
        /// <value>The Validating handler.</value>
        private EventHandler ValidatingHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripControlHost.ValidatingEvent);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
        /// </summary>
        public override event EventHandler Click
        {
            add
            {
                if (!this.HasHandler(ToolStripItem.ClickEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Click += new EventHandler(this.HandleClick);
                    }
                }

                base.Click += value;
            }
            remove
            {
                base.Click -= value;

                if (!this.HasHandler(ToolStripItem.ClickEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.Click -= new EventHandler(this.HandleClick);
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when the item is double-clicked with the mouse.
        /// </summary>
        public override event EventHandler DoubleClick
        {
            add
            {
                if (!this.HasHandler(ToolStripItem.DoubleClickEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.DoubleClick += new EventHandler(this.HandleDoubleClick);
                    }
                }

                base.DoubleClick += value;
            }
            remove
            {
                base.DoubleClick -= value;

                if (!this.HasHandler(ToolStripItem.DoubleClickEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.DoubleClick -= new EventHandler(this.HandleDoubleClick);
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the item and a mouse button is pressed.
        /// </summary>
        public override event MouseEventHandler MouseDown
        {
            add
            {
                if (!this.HasHandler(ToolStripItem.MouseDownEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.MouseDown += new MouseEventHandler(this.HandleMouseDown);
                    }
                }

                base.MouseDown += value;

            }
            remove
            {
                base.MouseDown -= value;

                if (!this.HasHandler(ToolStripItem.MouseDownEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.MouseDown -= new MouseEventHandler(this.HandleMouseDown);
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the item and a mouse button is released.
        /// </summary>
        public override event MouseEventHandler MouseUp
        {
            add
            {
                if (!this.HasHandler(ToolStripItem.MouseUpEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.MouseUp += new MouseEventHandler(this.HandleMouseUp);
                    }
                }

                base.MouseUp += value;
            }
            remove
            {
                base.MouseUp -= value;

                if (!this.HasHandler(ToolStripItem.MouseUpEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.MouseUp -= new MouseEventHandler(this.HandleMouseUp);
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.
        /// </summary>
        public override event EventHandler TextChanged
        {
            add
            {
                if (!this.HasHandler(ToolStripItem.TextChangedEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.TextChanged += new EventHandler(this.HandleTextChanged);
                    }
                }

                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;

                if (!this.HasHandler(ToolStripItem.TextChangedEvent))
                {
                    Control objControl = this.Control;
                    if (objControl != null)
                    {
                        objControl.TextChanged -= new EventHandler(this.HandleTextChanged);
                    }
                }
            }
        }


        #endregion Events

        #region Properties

        #region Property Store

        private Control mobjControl
        {
            get
            {
                return this.GetValue<Control>(ToolStripControlHost.mobjControlProperty, null);
            }
            set
            {
                this.SetValue<Control>(ToolStripControlHost.mobjControlProperty, value);
            }
        }

        private ContentAlignment menmControlAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(ToolStripControlHost.menmControlAlignProperty);
            }
            set
            {
                this.SetValue<ContentAlignment>(ToolStripControlHost.menmControlAlignProperty, value);
            }
        }

        #endregion

        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override Color BackColor
        {
            get
            {
                return this.Control.BackColor;
            }
            set
            {
                this.Control.BackColor = value;
            }
        }

        /// <summary>Gets or sets the background image displayed in the control.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
        [SRCategory("CatAppearance"), DefaultValue((string)null), SRDescription("ToolStripItemImageDescr"), Localizable(true)]
        public override ResourceHandle BackgroundImage
        {
            get
            {
                return this.Control.BackgroundImage;
            }
            set
            {
                this.Control.BackgroundImage = value;
            }
        }

        /// <summary>Gets or sets the background image layout as defined in the ImageLayout enumeration.</summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.ImageLayout"></see>:<see cref="F:System.Windows.Forms.ImageLayout.Center"></see><see cref="F:System.Windows.Forms.ImageLayout.None"></see><see cref="F:System.Windows.Forms.ImageLayout.Stretch"></see><see cref="F:System.Windows.Forms.ImageLayout.Tile"></see> (default)<see cref="F:System.Windows.Forms.ImageLayout.Zoom"></see></returns>
        [SRDescription("ControlBackgroundImageLayoutDescr"), SRCategory("CatAppearance"), Localizable(true), DefaultValue(ImageLayout.Tile)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.Control.BackgroundImageLayout;
            }
            set
            {
                this.Control.BackgroundImageLayout = value;
            }
        }

        /// <summary>Gets a value indicating whether the control can be selected.</summary>
        /// <returns>true if the control can be selected; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public override bool CanSelect
        {
            get
            {
                if (this.mobjControl == null)
                {
                    return false;
                }
                if (!base.DesignMode)
                {
                    return this.Control.CanSelect;
                }
                return true;
            }
        }

        /// <summary>Gets or sets a value indicating whether the hosted control causes and raises validation events on other controls when the hosted control receives focus.</summary>
        /// <returns>true if the hosted control causes and raises validation events on other controls when the hosted control receives focus; otherwise, false. The default is true.</returns>
        [DefaultValue(true), SRDescription("ControlCausesValidationDescr"), SRCategory("CatFocus")]
        public bool CausesValidation
        {
            get
            {
                return this.Control.CausesValidation;
            }
            set
            {
                this.Control.CausesValidation = value;
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Control Control
        {
            get
            {
                return this.mobjControl;
            }
        }

        /// <summary>Gets or sets the alignment of the control on the form.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleCenter"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:System.Windows.Forms.ToolStripControlHost.ControlAlign"></see> property is set to a value that is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment ControlAlign
        {
            get
            {
                return this.menmControlAlign;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                }
                if (this.menmControlAlign != value)
                {
                    this.menmControlAlign = value;
                    this.OnBoundsChanged();
                }
            }
        }

        /// <summary>Gets the default size of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Size"></see> of the control.</returns>
        protected override Size DefaultSize
        {
            get
            {
                if (this.Control != null)
                {
                    return this.Control.Size;
                }
                return base.DefaultSize;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItemDisplayStyle"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public ToolStripItemDisplayStyle DisplayStyle
        {
            get
            {
                return base.DisplayStyle;
            }
            set
            {
                base.DisplayStyle = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if double clicking is enabled; otherwise, false. </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DefaultValue(false)]
        public bool DoubleClickEnabled
        {
            get
            {
                return base.DoubleClickEnabled;
            }
            set
            {
                base.DoubleClickEnabled = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled.</summary>
        /// <returns>true if the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override bool Enabled
        {
            get
            {
                return this.Control.Enabled;
            }
            set
            {
                mblnEnabled = this.Control.Enabled = value;
            }
        }

        /// <summary>Gets a value indicating whether the control has input focus.</summary>
        /// <returns>true if the control has input focus; otherwise, false. </returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)]
        public virtual bool Focused
        {
            get
            {
                return this.Control.Focused;
            }
        }

        /// <summary>Gets or sets the font to be used on the hosted control.</summary>
        /// <returns>The <see cref="T:System.Drawing.Font"></see> for the hosted control.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override Font Font
        {
            get
            {
                return this.Control.Font;
            }
            set
            {
                this.Control.Font = value;
            }
        }

        /// <summary>Gets or sets the foreground color of the hosted control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> representing the foreground color of the hosted control.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override Color ForeColor
        {
            get
            {
                return this.Control.ForeColor;
            }
            set
            {
                this.Control.ForeColor = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override ResourceHandle Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.ContentAlignment"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return base.ImageAlign;
            }
            set
            {
                base.ImageAlign = value;
            }
        }

        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override RightToLeft RightToLeft
        {
            get
            {
                if (this.mobjControl != null)
                {
                    return this.mobjControl.RightToLeft;
                }
                return base.RightToLeft;
            }
            set
            {
                if (this.mobjControl != null)
                {
                    this.mobjControl.RightToLeft = value;
                }
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if the image is mirrored; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool RightToLeftAutoMirrorImage
        {
            get
            {
                return base.RightToLeftAutoMirrorImage;
            }
            set
            {
                base.RightToLeftAutoMirrorImage = value;
            }
        }

        /// <summary>Gets or sets the size of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                if (this.mobjControl != null)
                {
                    // Update hosted cotrol size
                    this.mobjControl.Size = value;
                }

                // Update host cotrol size
                base.Size = value;
            }
        }

        /// <summary>Gets or sets the text to be displayed on the hosted control.</summary>
        /// <returns>A <see cref="T:System.String"></see> representing the text.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue("")]
        public override string Text
        {
            get
            {
                return this.Control.Text;
            }
            set
            {
                this.Control.Text = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.VisualStyles.ContentAlignment"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                base.TextAlign = value;
            }
        }

        /// <summary>
        /// Gets the type of the tool strip item.
        /// </summary>
        /// <value>The type of the tool strip item.</value>
        protected override int ToolStripItemType
        {
            get
            {
                return 5;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripTextDirection"></see>.</returns>
        [DefaultValue(ToolStripTextDirection.Horizontal), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.TextImageRelation"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return base.TextImageRelation;
            }
            set
            {
                base.TextImageRelation = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripControlHost Class

    #region ToolStripComboBox Class

    /// <summary>Represents a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see> that is properly rendered in a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
    [DefaultProperty("Items")]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripComboBox : ToolStripControlHost
    {
        #region ToolStripComboBoxControl Class

        /// <summary>
        /// 
        /// </summary>
        [System.ComponentModel.ToolboxItem(false)]
        [Serializable()]
        private class ToolStripComboBoxControl : ComboBox
        {
            /// <summary>
            /// Gets the default size.
            /// </summary>
            /// <value>The default size.</value>
            protected override Size DefaultSize
            {
                get
                {
                    return new Size(100, 0x16);
                }
            }
        } 

        #endregion

        #region Members

        private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ToolStripComboBox));

        /// <summary>
        /// The drop down event
        /// </summary>
        private static readonly SerializableEvent DropDownEvent = SerializableEvent.Register("DropDown", typeof(EventHandler), typeof(ToolStripComboBox));

        /// <summary>
        /// The drop down closed event
        /// </summary>
        private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ToolStripComboBox));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class.</summary>
        public ToolStripComboBox() : base(new ToolStripComboBoxControl())
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class with the specified name. </summary> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</param>
        public ToolStripComboBox(string name) : this()
        {
            base.Name = name;
            
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class derived from a base control.</summary> 
        ///<param name="c">The base control. </param> 
        ///<exception cref="T:System.NotSupportedException">The operation is not supported. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToolStripComboBox(Control objControl)
            : base(objControl)
        {
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();
            this.ComboBox.Update();
        }

        /// <summary>
        /// Handles the selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HandleSelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnSelectedIndexChanged(e);
        }

        ///<summary>Maintains performance when items are added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> one at a time.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void BeginUpdate()
        {
        }

        ///<summary>Resumes painting the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> control after painting is suspended by the <see cref="M:Gizmox.WebGUI.Forms.ToolStripComboBox.BeginUpdate"></see> method.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void EndUpdate()
        {
        }

        ///<summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that starts with the specified string.</summary> 
        ///<returns>The zero-based index of the first item found; returns -1 if no match is found.</returns> 
        ///<param name="s">The <see cref="T:System.String"></see> to search for.</param> 
        ///<filterpriority>1</filterpriority>
        public int FindString(string s)
        {
            return this.ComboBox.FindString(s);
        }

        ///<summary>Finds the first item after the given index which starts with the given string. </summary> 
        ///<returns>The zero-based index of the first item found; returns -1 if no match is found.</returns> 
        ///<param name="s">The <see cref="T:System.String"></see> to search for.</param> 
        ///<param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param> 
        ///<filterpriority>1</filterpriority>
        public int FindString(string s, int startIndex)
        {
            return this.ComboBox.FindString(s, startIndex);
        }

        ///<summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that exactly matches the specified string.</summary> 
        ///<returns>The zero-based index of the first item found; -1 if no match is found.</returns> 
        ///<param name="s">The <see cref="T:System.String"></see> to search for.</param> 
        ///<filterpriority>1</filterpriority>
        public int FindStringExact(string s)
        {
            return this.ComboBox.FindStringExact(s);
        }

        ///<summary>Finds the first item after the specified index that exactly matches the specified string.</summary> 
        ///<returns>The zero-based index of the first item found; returns -1 if no match is found.</returns> 
        ///<param name="s">The <see cref="T:System.String"></see> to search for.</param> 
        ///<param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param> 
        ///<filterpriority>1</filterpriority>
        public int FindStringExact(string s, int startIndex)
        {
            return this.ComboBox.FindStringExact(s, startIndex);
        }

        ///<summary>Returns the height, in pixels, of an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>The height, in pixels, of the item at the specified index.</returns> 
        ///<param name="index">The index of the item to return the height of.</param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int GetItemHeight(int index)
        {
            return 0;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDown"></see> event. </summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDropDown(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.DropDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownClosed"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDropDownClosed(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.DropDownClosedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyleChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnDropDownStyleChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndexChanged"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.SelectedIndexChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ComboBox.SelectionChangeCommitted"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnSelectionChangeCommitted(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.TextUpdate"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnTextUpdate(EventArgs e)
        {
        }

        ///<summary>Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<param name="start">The position of the first character in the current text selection within the text box.</param> 
        ///<param name="length">The number of characters to select.</param> 
        ///<exception cref="T:System.ArgumentException">The start is less than zero.-or- start minus length is less than zero. </exception> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void Select(int start, int length)
        {
            this.ComboBox.Select(start, length);            
        }

        ///<summary>Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        public void SelectAll()
        {
            this.ComboBox.SelectAll();
        }

        /// <summary>
        /// Handles the drop down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HandleDropDown(object sender, EventArgs e)
        {
            this.OnDropDown(e);
        }

        /// <summary>
        /// Handles the drop down closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HandleDropDownClosed(object sender, EventArgs e)
        {
            this.OnDropDownClosed(e);
        }

        ///<summary>Subscribes events from the hosted control.</summary> 
        ///<param name="objControl">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control objControl)
        {
            ComboBox objComboBox = objControl as ComboBox;
            if (objComboBox != null)
            {
                objComboBox.DropDown += new EventHandler(this.HandleDropDown);
                objComboBox.DropDownClosed += new EventHandler(this.HandleDropDownClosed);
            }
            base.OnSubscribeControlEvents(objControl);
        }

        ///<summary>Unsubscribes events from the hosted control.</summary> 
        ///<param name="objControl">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control objControl)
        {
            ComboBox objComboBox = objControl as ComboBox;
            if (objComboBox != null)
            {
                objComboBox.DropDown -= new EventHandler(this.HandleDropDown);
                objComboBox.DropDownClosed -= new EventHandler(this.HandleDropDownClosed);
            }
            base.OnUnsubscribeControlEvents(objControl);
        }

        #endregion Methods

        #region Events

        /// <summary>This event is not relevant to this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler DoubleClick
        {
            add
            {
                base.DoubleClick += value;
            }
            remove
            {
                base.DoubleClick -= value;
            }
        }

        ///<summary>Occurs when the drop-down portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> is shown.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DropDown
        {
            add
            {
                this.AddCriticalHandler(ToolStripComboBox.DropDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripComboBox.DropDownEvent, value);
            }
        }

        /// <summary>
        /// Gets the drop down handler.
        /// </summary>
        /// <value>
        /// The drop down handler.
        /// </value>
        private EventHandler DropDownHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripComboBox.DropDownEvent);
            }
        }

        ///<summary>Occurs when the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> has closed.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DropDownClosed
        {
            add
            {
                this.AddCriticalHandler(ToolStripComboBox.DropDownClosedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripComboBox.DropDownClosedEvent, value);
            }
        }

        /// <summary>
        /// Gets the drop down closed handler.
        /// </summary>
        /// <value>
        /// The drop down closed handler.
        /// </value>
        private EventHandler DropDownClosedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripComboBox.DropDownClosedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> property has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DropDownStyleChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndex"></see> property has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                if (!this.HasHandler(ToolStripComboBox.SelectedIndexChangedEvent))
                {
                    ComboBox objComboBox = this.Control as ComboBox;
                    if (objComboBox != null)
                    {
                        objComboBox.SelectedIndexChanged += new EventHandler(this.HandleSelectedIndexChanged);
                    }
                }

                this.AddCriticalHandler(ToolStripComboBox.SelectedIndexChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripComboBox.SelectedIndexChangedEvent, value);

                if (!this.HasHandler(ToolStripComboBox.SelectedIndexChangedEvent))
                {
                    ComboBox objComboBox = this.Control as ComboBox;
                    if (objComboBox != null)
                    {
                        objComboBox.SelectedIndexChanged -= new EventHandler(this.HandleSelectedIndexChanged);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the SelectedIndexChanged handler.
        /// </summary>
        /// <value>The SelectedIndexChanged handler.</value>
        private EventHandler SelectedIndexChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripComboBox.SelectedIndexChangedEvent);
            }
        }

        ///<summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> text has changed.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TextUpdate
        {
            add
            {
            }
            remove
            {
            }
        }

        #endregion Events

        #region Properties

        ///<summary>Gets or sets the custom string collection to use when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.AutoCompleteSource"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.CustomSource"></see>.</summary> 
        ///<returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteStringCollection"></see> that contains the strings.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a value that indicates the text completion behavior of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteMode.None"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(AutoCompleteMode.None), SRDescription("ComboBoxAutoCompleteModeDescr")]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return this.ComboBox.AutoCompleteMode;
            }
            set
            {
                this.ComboBox.AutoCompleteMode = value;
            }
        }

        ///<summary>Gets or sets the source of complete strings used for automatic completion.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteSource"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.None"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [SRDescription("ComboBoxAutoCompleteSourceDescr"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(AutoCompleteSource.None)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return this.ComboBox.AutoCompleteSource;
            }
            set
            {
                this.ComboBox.AutoCompleteSource = value;
            }
        }

        ///<summary>This property is not relevant to this class.</summary> 
        ///<returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ResourceHandle BackgroundImage
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>Gets a <see cref="T:System.Windows.Forms.ComboBox"></see> in which the user can enter text, along with a list from which the user can select.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ComboBox"></see> for a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ComboBox ComboBox
        {
            get
            {
                return (base.Control as ComboBox);
            }
        }

        ///<summary>Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>The default <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> in pixels. The default size is 100 x 20 pixels.</returns>
        protected virtual Size DefaultSize
        {
            get
            {
                return new Size(100, 0x16);
            }
        }

        ///<summary>Gets or sets the height, in pixels, of the drop-down portion box of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>The height, in pixels, of the drop-down box.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DropDownHeight
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value specifying the style of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ComboBoxStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ComboBoxStyle.DropDown"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ComboBoxStyleDescr"), SRCategory("CatAppearance"), DefaultValue(ComboBoxStyle.DropDown), RefreshProperties(RefreshProperties.Repaint)]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return this.ComboBox.DropDownStyle;
            }
            set
            {
                this.ComboBox.DropDownStyle = value;
            }
        }

        /// <summary>Gets or sets the width, in pixels, of the of the drop-down portion of a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
        /// <returns>The width, in pixels, of the drop-down box.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ComboBoxDropDownWidthDescr"), SRCategory("CatBehavior")]
        public int DropDownWidth
        {
            get
            {
                return this.ComboBox.DropDownWidth;
            }
            set
            {
                this.ComboBox.DropDownWidth = value;
            }
        }

        /// <summary>
        /// Resets the width of the drop down.
        /// </summary>
        private void ResetDropDownWidth()
        {
            this.ComboBox.ResetDropDownWidth();
        }


        /// <summary>
        /// Gets or sets a value indicating whether [dropped down].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [dropped down]; otherwise, <c>false</c>.
        /// </value>
        public bool DroppedDown
        {
            get
            {
                return this.ComboBox.DroppedDown;
            }
            set
            {
                this.ComboBox.DroppedDown = value;
            }
        }

        ///<summary>Gets or sets the appearance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see>. The options are <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>, and <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.System"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Flat;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> should resize to avoid showing partial items.</summary> 
        ///<returns>true if the list portion can contain only complete items; otherwise, false. The default is true.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IntegralHeight
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        ///<summary>Gets a collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>A collection of items.</returns> 
        ///<filterpriority>1</filterpriority>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(true), SRDescription("ComboBoxItemsDescr"), SRCategory("CatData")]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return this.ComboBox.Items;
            }
        }

        /// <summary>
        /// Gets or sets the max drop down items.
        /// </summary>
        /// <value>The max drop down items.</value>
        [DefaultValue(8), SRCategory("CatBehavior"), Localizable(true), SRDescription("ComboBoxMaxDropDownItemsDescr")]
        public int MaxDropDownItems
        {
            get
            {
                return this.ComboBox.MaxDropDownItems;
            }
            set
            {
                this.ComboBox.MaxDropDownItems = value;
            }
        }

        ///<summary>Gets or sets the maximum number of characters allowed in the editable portion of a combo box.</summary> 
        ///<returns>The maximum number of characters the user can enter. Values of less than zero are reset to zero, which is the default value.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MaxLength
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the index specifying the currently selected item.</summary> 
        ///<returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ComboBoxSelectedIndexDescr")]
        public int SelectedIndex
        {
            get
            {
                return this.ComboBox.SelectedIndex;
            }
            set
            {
                this.ComboBox.SelectedIndex = value;
            }
        }

        ///<summary>Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>The object that is the currently selected item or null if there is no currently selected item.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Browsable(false), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ComboBoxSelectedItemDescr")]
        public object SelectedItem
        {
            get
            {
                return this.ComboBox.SelectedItem;
            }
            set
            {
                this.ComboBox.SelectedItem = value;
            }
        }

        ///<summary>Gets or sets the text that is selected in the editable portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
        ///<returns>A string that represents the currently selected text in the combo box. If <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> is set to DropDownList, the return value is an empty string ("").</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("ComboBoxSelectedTextDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string SelectedText
        {
            get
            {
                return this.ComboBox.SelectedText;
            }
            set
            {
                this.ComboBox.SelectedText = value;
            }
        }

        /// <summary>Gets or sets the number of characters selected in the editable portion of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
        /// <returns>The number of characters selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRDescription("ComboBoxSelectionLengthDescr")]
        public int SelectionLength
        {
            get
            {
                return this.ComboBox.SelectionLength;
            }
            set
            {
                this.ComboBox.SelectionLength = value;
            }
        }

        /// <summary>Gets or sets the starting index of text selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
        /// <returns>The zero-based index of the first character in the string of the current text selection.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ComboBoxSelectionStartDescr")]
        public int SelectionStart
        {
            get
            {
                return this.ComboBox.SelectionStart;
            }
            set
            {
                this.ComboBox.SelectionStart = value;
            }
        }

        ///<summary>Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> are sorted.</summary> 
        ///<returns>true if the combo box is sorted; otherwise, false. The default is false.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("ComboBoxSortedDescr")]
        public bool Sorted
        {
            get
            {
                return this.ComboBox.Sorted;
            }
            set
            {
                this.ComboBox.Sorted = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripComboBox Class

    #region ToolStripTextBox Class

    /// <summary>Represents a text box in a <see cref="T:System.Windows.Forms.ToolStrip"></see> that allows the user to enter text.</summary>
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripTextBox : ToolStripControlHost
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class.</summary>
        public ToolStripTextBox() : base(new TextBox())
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class with the specified name. </summary> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>.</param>
        public ToolStripTextBox(string name) : this()
        {
            base.Name = name;
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class derived from a base control.</summary> 
        ///<param name="c">The control from which to derive the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToolStripTextBox(Control c) : base(c)
        {
            throw new NotSupportedException(SR.GetString("ToolStripMustSupplyItsOwnTextBox"));
        }

        #endregion C'Tors

        #region Methods

        /// <summary>Appends text to the current text of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
        /// <param name="text">The text to append to the current contents of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void AppendText(string text)
        {
            this.TextBox.AppendText(text);
        }

        /// <summary>Clears all text from the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Clear()
        {
            this.TextBox.Clear();
        }

        /// <summary>Clears information about the most recent operation from the undo buffer of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void ClearUndo()
        {
        }

        /// <summary>Copies the current selection in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> to the Clipboard.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Copy()
        {
            this.TextBox.Copy();
        }

        /// <summary>Moves the current selection in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> to the Clipboard.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Cut()
        {
            this.TextBox.Copy();
        }

        /// <summary>Specifies that the value of the <see cref="P:System.Windows.Forms.ToolStripTextBox.SelectionLength"></see> property is zero so that no characters are selected in the control.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DeselectAll()
        {
        }

        /// <summary>Retrieves the character that is closest to the specified location within the control.</summary>
        /// <returns>The character at the specified location.</returns>
        /// <param name="pt">The location from which to seek the nearest character.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char GetCharFromPosition(Point pt)
        {
            return char.MinValue;
        }

        /// <summary>Retrieves the index of the character nearest to the specified location.</summary>
        /// <returns>The zero-based character index at the specified location.</returns>
        /// <param name="pt">The location to search.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int GetCharIndexFromPosition(Point pt)
        {
            return 0;
        }

        /// <summary>Retrieves the index of the first character of a given line.</summary>
        /// <returns>The zero-based character index in the specified line.</returns>
        /// <param name="lineNumber">The line for which to get the index of its first character.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int GetFirstCharIndexFromLine(int lineNumber)
        {
            return 0;
        }

        /// <summary>Retrieves the index of the first character of the current line.</summary>
        /// <returns>The zero-based character index in the current line.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int GetFirstCharIndexOfCurrentLine()
        {
            return 0;
        }

        /// <summary>Retrieves the line number from the specified character position within the text of the control.</summary>
        /// <returns>The zero-based line number in which the character index is located.</returns>
        /// <param name="index">The character index position to search.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int GetLineFromCharIndex(int index)
        {
            return 0;
        }

        /// <summary>Retrieves the location within the control at the specified character index.</summary>
        /// <returns>The location of the specified character.</returns>
        /// <param name="index">The index of the character for which to retrieve the location.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point GetPositionFromCharIndex(int index)
        {
            return Point.Empty;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.AcceptsTabChanged"></see> event. </summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnAcceptsTabChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.BorderStyleChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnBorderStyleChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.HideSelectionChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnHideSelectionChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.ModifiedChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnModifiedChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.MultilineChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnMultilineChanged(EventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.ReadOnlyChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnReadOnlyChanged(EventArgs e)
        {
        }


        /// <summary>Replaces the current selection in the text box with the contents of the Clipboard.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Paste()
        {
            this.TextBox.Paste();
        }

        /// <summary>Scrolls the contents of the control to the current caret position.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void ScrollToCaret()
        {
            this.TextBox.ScrollToCaret();
        }

        /// <summary>Selects a range of text in the text box.</summary>
        /// <param name="start">The position of the first character in the current text selection within the text box.</param>
        /// <param name="length">The number of characters to select.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Select(int start, int length)
        {
            this.TextBox.Select(start, length);
        }

        /// <summary>Selects all text in the text box.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void SelectAll()
        {
            this.TextBox.SelectAll();
        }

        /// <summary>Undoes the last edit operation in the text box.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Undo()
        {
            this.TextBox.Undo();
        }

        #endregion Methods

        #region Events

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.AcceptsTab"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler AcceptsTabChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.BorderStyle"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler BorderStyleChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.HideSelection"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler HideSelectionChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.Modified"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler ModifiedChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>This event is not relevant to this class.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler MultilineChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.ReadOnly"></see> property changes.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler ReadOnlyChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.TextBoxTextAlign"></see> property changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TextBoxTextAlignChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        #endregion Events

        #region Properties

        /// <summary>Gets or sets a value indicating whether pressing ENTER in a multiline <see cref="T:System.Windows.Forms.TextBox"></see> control creates a new line of text in the control or activates the default button for the form.</summary>
        /// <returns>true if the ENTER key creates a new line of text in a multiline version of the control; false if the ENTER key activates the default button for the form. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("TextBoxAcceptsReturnDescr")]
        public bool AcceptsReturn
        {
            get
            {
                return this.TextBox.AcceptsReturn;
            }
            set
            {
                this.TextBox.AcceptsReturn = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.</summary>
        /// <returns>true if users can enter tabs in a multiline text box using the TAB key; false if pressing the TAB key moves the focus. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("TextBoxAcceptsTabDescr")]
        public bool AcceptsTab
        {
            get
            {
                return this.TextBox.AcceptsTab;
            }
            set
            {
                this.TextBox.AcceptsTab = value;
            }
        }

        /// <summary>Gets or sets a custom string collection to use when the <see cref="P:System.Windows.Forms.ToolStripTextBox.AutoCompleteSource"></see> property is set to CustomSource.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.AutoCompleteStringCollection"></see> to use with <see cref="P:System.Windows.Forms.TextBox.AutoCompleteSource"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets an option that controls how automatic completion works for the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.AutoCompleteMode"></see> values. The default is <see cref="F:System.Windows.Forms.AutoCompleteMode.None"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return AutoCompleteMode.None;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.AutoCompleteSource"></see> values. The default is <see cref="F:System.Windows.Forms.AutoCompleteSource.None"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return AutoCompleteSource.None;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ResourceHandle BackgroundImage
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>Gets or sets the border type of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.BorderStyle"></see> values. The default is <see cref="F:System.Windows.Forms.BorderStyle.FixedSingle"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), DefaultValue(BorderStyle.Fixed3D), DispId(-504), SRDescription("TextBoxBorderDescr")]
        public BorderStyle BorderStyle
        {
            get
            {
                return this.TextBox.BorderStyle;
            }
            set
            {
                this.TextBox.BorderStyle = value;
            }
        }

        /// <summary>Gets a value indicating whether the user can undo the previous operation in a <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
        /// <returns>true if the user can undo the previous operation performed in a text box control; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("TextBoxCanUndoDescr")]
        public bool CanUndo
        {
            get
            {
                return this.TextBox.CanUndo;
            }
        }

        /// <summary>Gets or sets whether the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control modifies the case of characters as they are typed.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.CharacterCasing"></see> values. The default is <see cref="F:System.Windows.Forms.CharacterCasing.Normal"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), DefaultValue(CharacterCasing.Normal), SRDescription("TextBoxCharacterCasingDescr")]
        public CharacterCasing CharacterCasing
        {
            get
            {
                return this.TextBox.CharacterCasing;
            }
            set
            {
                this.TextBox.CharacterCasing = value;
            }
        }

        ///<summary>Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>.</summary> 
        ///<returns>The default <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> in pixels. The default size is 100 pixels by 25 pixels.</returns>
        protected virtual Size DefaultSize
        {
            get
            {
                return new Size(100, 0x16);
            }
        }

        ///<summary>Gets or sets a value indicating whether the selected text in the text box control remains highlighted when the control loses focus.</summary> 
        ///<returns>true if the selected text does not appear highlighted when the text box control loses focus; false, if the selected text remains highlighted when the text box control loses focus. The default is true.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [SRDescription("TextBoxHideSelectionDescr"), DefaultValue(true), SRCategory("CatBehavior")]
        public bool HideSelection
        {
            get
            {
                return this.TextBox.HideSelection;
            }
            set
            {
                this.TextBox.HideSelection = value;
            }
        }

        /// <summary>Gets or sets the lines of text in a <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
        /// <returns>An array of strings that contains the text in a text box control.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), Localizable(true), SRDescription("TextBoxLinesDescr")]
        public string[] Lines
        {
            get
            {
                return this.TextBox.Lines;
            }
            set
            {
                this.TextBox.Lines = value;
            }
        }

        /// <summary>Gets or sets the maximum number of characters the user can type or paste into the text box control.</summary>
        /// <returns>The number of characters that can be entered into the control. The default is 32767 characters.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), DefaultValue(0x7fff), SRCategory("CatBehavior"), SRDescription("TextBoxMaxLengthDescr")]
        public int MaxLength
        {
            get
            {
                return this.TextBox.MaxLength;
            }
            set
            {
                this.TextBox.MaxLength = value;
            }
        }

        /// <summary>Gets or sets a value that indicates that the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control has been modified by the user since the control was created or its contents were last set.</summary>
        /// <returns>true if the control's contents have been modified; otherwise, false. </returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Modified
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(false), SRCategory("CatBehavior"), Localizable(true), SRDescription("TextBoxMultilineDescr"), RefreshProperties(RefreshProperties.All), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool Multiline
        {
            get
            {
                return this.TextBox.Multiline;
            }
            set
            {
                this.TextBox.Multiline = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether text in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> is read-only.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> is read-only; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("TextBoxReadOnlyDescr")]
        public bool ReadOnly
        {
            get
            {
                return this.TextBox.ReadOnly;
            }
            set
            {
                this.TextBox.ReadOnly = value;
            }
        }

        /// <summary>Gets or sets a value indicating the currently selected text in the control.</summary>
        /// <returns>A string that represents the currently selected text in the text box.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRCategory("CatAppearance"), SRDescription("TextBoxSelectedTextDescr")]
        public string SelectedText
        {
            get
            {
                return this.TextBox.SelectedText;
            }
            set
            {
                this.TextBox.SelectedText = value;
            }
        }

        /// <summary>Gets or sets the number of characters selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
        /// <returns>The number of characters selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("TextBoxSelectionLengthDescr")]
        public int SelectionLength
        {
            get
            {
                return this.TextBox.SelectionLength;
            }
            set
            {
                this.TextBox.SelectionLength = value;
            }
        }

        /// <summary>Gets or sets the starting point of text selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
        /// <returns>The starting position of text selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("TextBoxSelectionStartDescr"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance")]
        public int SelectionStart
        {
            get
            {
                return this.TextBox.SelectionStart;
            }
            set
            {
                this.TextBox.SelectionStart = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the defined shortcuts are enabled.</summary>
        /// <returns>true to enable the shortcuts; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShortcutsEnabled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>Gets the hosted <see cref="T:System.Windows.Forms.TextBox"></see> control.</summary>
        /// <returns>The hosted <see cref="T:System.Windows.Forms.TextBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox TextBox
        {
            get
            {
                return (base.Control as TextBox);
            }
        }

        /// <summary>Gets or sets how text is aligned in a <see cref="T:System.Windows.Forms.TextBox"></see> control.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.HorizontalAlignment"></see> enumeration values that specifies how text is aligned in the control. The default is <see cref="F:System.Windows.Forms.HorizontalAlignment.Left"></see>.</returns>
        [SRCategory("CatAppearance"), Localizable(true), DefaultValue(HorizontalAlignment.Left), SRDescription("TextBoxTextAlignDescr")]
        public HorizontalAlignment TextBoxTextAlign
        {
            get
            {
                return this.TextBox.TextAlign;
            }
            set
            {
                this.TextBox.TextAlign = value;
            }
        }

        /// <summary>Gets the length of text in the control.</summary>
        /// <returns>The number of characters contained in the text of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public int TextLength
        {
            get
            {
                return this.TextBox.TextLength;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRCategory("CatBehavior"), DefaultValue(true), SRDescription("TextBoxWordWrapDescr"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool WordWrap
        {
            get
            {
                return this.TextBox.WordWrap;
            }
            set
            {
                this.TextBox.WordWrap = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripTextBox Class

    #region ToolStripProgressBar Class

    /// <summary>Represents a Windows progress bar control contained in a <see cref="T:System.Windows.Forms.StatusStrip"></see>.</summary>
    [DefaultProperty("Value")]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripProgressBar : ToolStripControlHost
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class. </summary>
        public ToolStripProgressBar() : base(new ProgressBar()) 
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class with specified name. </summary> 
        ///<param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see>.</param>
        public ToolStripProgressBar(string name) : this()
        {
            base.Name = name;
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Advances the current position of the progress bar by the specified amount.</summary> 
        ///<param name="value">The amount by which to increment the progress bar's current position.</param>
        public void Increment(int value)
        {
            this.ProgressBar.Increment(value);
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ProgressBar.RightToLeftLayoutChanged"></see> event. </summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRightToLeftLayoutChanged(EventArgs e)
        {
        }

        ///<summary>Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.Step"></see> property.</summary>
        public void PerformStep()
        {
            this.ProgressBar.PerformStep();
        }

        #endregion Methods

        #region Events

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>This event is not relevant for this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler LocationChanged
        {
            add
            {
                base.LocationChanged += value;
            }
            remove
            {
                base.LocationChanged -= value;
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler OwnerChanged
        {
            add
            {
                base.OwnerChanged += value;
            }
            remove
            {
                base.OwnerChanged -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.RightToLeftLayout"></see> property changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler RightToLeftLayoutChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>This event is not relevant to this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        /// <summary>This event is not relevant to this class.</summary>
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ResourceHandle BackgroundImage
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

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        /// <summary>Gets the height and width of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> in pixels.</summary>
        /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the height and width.</returns>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 15);
            }
        }

        /// <summary>Gets or sets a value representing the delay between each <see cref="F:System.Windows.Forms.ProgressBarStyle.Marquee"></see> display update, in milliseconds.</summary>
        /// <returns>An integer representing the delay, in milliseconds.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MarqueeAnimationSpeed
        {
            get
            {
                return 100;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the upper bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
        /// <returns>An integer representing the upper bound of the range. The default is 100.</returns>
        [RefreshProperties(RefreshProperties.Repaint), SRDescription("ProgressBarMaximumDescr"), DefaultValue(100), SRCategory("CatBehavior")]
        public int Maximum
        {
            get
            {
                return this.ProgressBar.Maximum;
            }
            set
            {
                this.ProgressBar.Maximum = value;
            }
        }

        /// <summary>Gets or sets the lower bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
        /// <returns>An integer representing the lower bound of the range. The default is 0.</returns>
        [DefaultValue(0), SRCategory("CatBehavior"), SRDescription("ProgressBarMinimumDescr"), RefreshProperties(RefreshProperties.Repaint)]
        public int Minimum
        {
            get
            {
                return this.ProgressBar.Minimum;
            }
            set
            {
                this.ProgressBar.Minimum = value;
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.ProgressBar"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ProgressBar"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ProgressBar ProgressBar
        {
            get
            {
                return (base.Control as ProgressBar);
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> layout is right-to-left or left-to-right when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>. </summary>
        /// <returns>true to turn on mirroring and lay out control from right to left when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>; otherwise, false. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool RightToLeftLayout
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the amount by which to increment the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> when the <see cref="M:System.Windows.Forms.ToolStripProgressBar.PerformStep"></see> method is called.</summary>
        /// <returns>An integer representing the incremental amount. The default value is 10.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(10), SRCategory("CatBehavior"), SRDescription("ProgressBarStepDescr")]
        public int Step
        {
            get
            {
                return this.ProgressBar.Step;
            }
            set
            {
                this.ProgressBar.Step = value;
            }
        }

        /// <summary>Gets or sets the style of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ProgressBarStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.ProgressBarStyle.Blocks"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProgressBarStyle Style
        {
            get
            {
                return ProgressBarStyle.Blocks;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the text displayed on the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
        /// <returns>A <see cref="T:System.String"></see> representing the display text.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Control.Text;
            }
            set
            {
                base.Control.Text = value;
            }
        }

        /// <summary>Gets or sets the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
        /// <returns>An integer representing the current value.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("ProgressBarValueDescr"), Bindable(true), DefaultValue(0)]
        public int Value
        {
            get
            {
                return this.ProgressBar.Value;
            }
            set
            {
                this.ProgressBar.Value = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripProgressBar Class

    #region IDropTarget Interface

    public interface IDropTarget
    {

        #region Methods

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragDrop"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param> 
        ///<filterpriority>1</filterpriority>
        void OnDragDrop(DragEventArgs e);

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragEnter"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param> 
        ///<filterpriority>1</filterpriority>
        void OnDragEnter(DragEventArgs e);

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragLeave"></see> event.</summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param> 
        ///<filterpriority>1</filterpriority>
        void OnDragLeave(EventArgs e);

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragOver"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param> 
        ///<filterpriority>1</filterpriority>
        void OnDragOver(DragEventArgs e);

        #endregion Methods
    }

    #endregion
}
