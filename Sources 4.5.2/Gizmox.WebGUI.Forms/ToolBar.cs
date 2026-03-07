#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Toolbar button stylr
    /// </summary>
    [Serializable()]
    public enum ToolBarButtonStyle
    {
        /// <summary>
        /// DropDownButton 
        /// </summary>
        DropDownButton = 4,

        /// <summary> 
        /// PushButton 
        /// </summary>
        PushButton = 1,

        /// <summary>
        /// Separator 
        /// </summary>
        Separator = 3,

        /// <summary>
        /// ToggleButton 
        /// </summary>
        ToggleButton = 2
    }

    /// <summary>
    /// Toolbar appeatance style
    /// </summary>
    [Serializable()]
    public enum ToolBarAppearance
    {
        /// <summary>
        /// Flat
        /// </summary>
        Flat = 1,

        /// <summary>
        /// Normal
        /// </summary>
        Normal = 0
    }

    /// <summary>
    /// Toolbar buttons text alignment
    /// </summary>
    [Serializable()]
    public enum ToolBarTextAlign
    {
        /// <summary>
        /// Underneath
        /// </summary>
        Underneath,

        /// <summary>
        /// Right
        /// </summary>
        Right
    }

    #endregion Enums

    #region ToolBar Class

    /// <summary>
    /// ToolBar control.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ToolBar), "ToolBar_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ToolBar), "ToolBar.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [ToolboxItemCategory("Menus & Toolbars")]
    [Serializable()]
    [MetadataTag(WGTags.ToolBarControl), DefaultEvent("ButtonClick")]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.ToolBarSkin))]
    [ProxyComponent(typeof(ProxyToolBar))]
    public class ToolBar : Control
    {
        #region Class Members

        /// <summary>
        /// Provides a property reference to MenuHandle property.
        /// </summary>
        private static SerializableProperty MenuHandleProperty = SerializableProperty.Register("MenuHandle", typeof(bool), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to DragHandle property.
        /// </summary>
        private static SerializableProperty DragHandleProperty = SerializableProperty.Register("DragHandle", typeof(bool), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to TextAlign property.
        /// </summary>
        private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ToolBarTextAlign), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to Appearance property.
        /// </summary>
        private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(ToolBarAppearance), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to RightToLeft property.
        /// </summary>
        private static SerializableProperty RightToLeftProperty = SerializableProperty.Register("RightToLeft", typeof(bool), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to ButtonSize property.
        /// </summary>
        private static SerializableProperty ButtonSizeProperty = SerializableProperty.Register("ButtonSize", typeof(Size), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to ImageSize property.
        /// </summary>
        private static SerializableProperty ImageSizeProperty = SerializableProperty.Register("ImageSize", typeof(Size), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to ImageList property.
        /// </summary>
        private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to ButtonsSizeAttribute property.
        /// </summary>
        private static SerializableProperty ButtonsSizeAttributeProperty = SerializableProperty.Register("ButtonsSizeAttribute", typeof(string), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to ButtonsDock property.
        /// </summary>
        private static SerializableProperty ButtonsDockProperty = SerializableProperty.Register("ButtonsDock", typeof(string), typeof(ToolBar));

        /// <summary>
        /// Provides a property reference to Buttons property.
        /// </summary>
        private static SerializableProperty ButtonsProperty = SerializableProperty.Register("Buttons", typeof(ToolBarItemCollection), typeof(ToolBar));

        /// <summary>
        /// Occurs when a user clicks on a button
        /// </summary>
        public event ToolBarButtonClickEventHandler ButtonClick
        {
            add
            {
                this.AddCriticalHandler(ToolBar.ButtonClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolBar.ButtonClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ButtonClick event.
        /// </summary>
        internal ToolBarButtonClickEventHandler ButtonClickHandler
        {
            get
            {
                return (ToolBarButtonClickEventHandler)this.GetHandler(ToolBar.ButtonClickEvent);
            }
        }

        /// <summary>
        /// The ButtonClick event registration.
        /// </summary>
        private static readonly SerializableEvent ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof(ToolBarButtonClickEventHandler), typeof(ToolBar));

        #endregion Class Members

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="ToolBar"/> instance.
        /// </summary>
        public ToolBar()
        {
            // create toolbar items collection
            this.SetValue<ToolBarItemCollection>(ToolBar.ButtonsProperty, CreateButtonCollection());

            // set default properties
            this.Dock = DockStyle.Top;
            this.AutoSize = true;

            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.FixedHeight, this.AutoSize);
            base.SetStyle(ControlStyles.FixedWidth, false);

            this.TabStop = false;
        }

        #endregion C'Tor

        #region Events

        /// <summary>
        /// Fires an contained event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        /// <param name="objButton">The obj button.</param>
        internal void FireEvent(IEvent objEvent, ToolBarButton objButton)
        {
            switch (objEvent.Type)
            {
                case "Click":
                    if (objButton != null)
                    {
                        OnButtonClick(new ToolBarButtonClickEventArgs(objButton));
                    }

                    this.OnClick(EventArgs.Empty);
                    break;
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
                return string.Format("WC:{0}", WGTags.ToolBarButton);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolBar.ButtonClick"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolBarButtonClickEventArgs"></see> that contains the event data. </param>
        protected virtual void OnButtonClick(ToolBarButtonClickEventArgs e)
        {
            // Raise event if needed
            ToolBarButtonClickEventHandler objEventHandler = this.ButtonClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets the tool bar button skin.
        /// </summary>
        /// <value>The tool bar button skin.</value>
        private ToolBarButtonSkin ToolBarButtonSkin
        {
            get
            {
                ToolBarButtonSkin objButtonSkin = null;
                if (this.Buttons.Count > 0)
                {
                    objButtonSkin = SkinFactory.GetSkin(this.Buttons[0], typeof(ToolBarButtonSkin)) as ToolBarButtonSkin;
                }

                return objButtonSkin;
            }
        }

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.</returns>
        [SRDescription("ToolBarAutoSizeDescr"), Localizable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), SRCategory("CatBehavior"), DefaultValue(true)]
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
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color BackColor
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

        /// <summary>
        ///
        /// </summary>
        internal string ButtonsDock
        {
            get
            {
                return GetValue<string>(ToolBar.ButtonsDockProperty, "L");
            }
            private set
            {
                if (this.ButtonsDock != value)
                {
                    if (value != "L")
                    {
                        this.SetValue<string>(ToolBar.ButtonsDockProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBar.ButtonsDockProperty);
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal string ButtonsSizeAttribute
        {
            get
            {
                return this.GetValue<string>(ToolBar.ButtonsSizeAttributeProperty, "W");
            }
            private set
            {
                if (this.ButtonsSizeAttribute != value)
                {
                    if (value != "W")
                    {
                        this.SetValue<string>(ToolBar.ButtonsSizeAttributeProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBar.ButtonsSizeAttributeProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the toolbar image list.
        /// </summary>
        /// <value></value>
        [DefaultValue(null)]
        public ImageList ImageList
        {
            get
            {
                return this.GetValue<ImageList>(ToolBar.ImageListProperty, null);
            }
            set
            {
                if (this.ImageList != value)
                {
                    Update();

                    if (value != null)
                    {
                        this.SetValue<ImageList>(ToolBar.ImageListProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ImageList>(ToolBar.ImageListProperty);
                    }
                }
            }
        }

        /// <summary>Gets the size of the images in the image list assigned to the toolbar.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the size of the images (in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>) assigned to the <see cref="T:Gizmox.WebGUI.Forms.ToolBar"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ToolBarImageSizeDescr"), SRCategory("CatBehavior"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Size ImageSize
        {
            get
            {
                if (this.ImageList != null)
                {
                    return this.ImageList.ImageSize;
                }

                Size objImageSize = this.GetValue<Size>(ToolBar.ImageSizeProperty, Size.Empty);
                if (objImageSize != Size.Empty)
                {
                    return objImageSize;
                }
                return new Size(16, 16);
            }
            set
            {
                if (this.ImageList != null)
                {
                    throw new ArgumentException("Cannot set image size when an ImageList is assigned.", "ImageSize");
                }
                if (this.GetValue<Size>(ToolBar.ImageSizeProperty, Size.Empty) != value)
                {
                    if (value != Size.Empty)
                    {
                        this.SetValue<Size>(ToolBar.ImageSizeProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<Size>(ToolBar.ImageSizeProperty);
                    }

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Determines if image size serialization is required.
        /// </summary>
        private bool ShouldSerializeImageSize()
        {
            return this.ImageList == null && this.ImageSize != Size.Empty;
        }

        /// <summary>
        /// Resets the size of the image.
        /// </summary>
        private void ResetImageSize()
        {
            if (this.ImageList != null)
            {
                this.ImageSize = this.ImageList.ImageSize;
            }
            else
            {
                this.ImageSize = Size.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the size of the buttons.
        /// </summary>
        /// <value></value>
        public Size ButtonSize
        {
            get
            {
                Size objButtonSize = this.ButtonSizeInternal;
                if (!objButtonSize.IsEmpty)
                {
                    return objButtonSize;
                }
                if (this.Buttons != null && this.Buttons.Count > 0)
                {
                    return CalculateSize();
                }
                if (this.TextAlign == ToolBarTextAlign.Underneath)
                {
                    return new Size(39, 36);
                }
                return new Size(23, 22);
            }
            set
            {
                Size objButtonSize = this.ButtonSizeInternal;
                if (objButtonSize != value)
                {
                    this.ButtonSizeInternal = value;

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    Update();
                }
            }
        }

        internal Size ButtonSizeInternal
        {
            get
            {
                return this.GetValue<Size>(ToolBar.ButtonSizeProperty, Size.Empty);
            }
            set
            {
                if (value != Size.Empty)
                {
                    this.SetValue<Size>(ToolBar.ButtonSizeProperty, value);
                }
                else
                {
                    this.RemoveValue<Size>(ToolBar.ButtonSizeProperty);
                }
            }
        }

        /// <summary>
        /// Gets the toolbar button collecction
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public virtual ToolBarItemCollection Buttons
        {
            get
            {
                return this.GetValue<ToolBarItemCollection>(ToolBar.ButtonsProperty, null);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the toolbar appearance.
        /// </summary>
        /// <value></value>
        [DefaultValue(ToolBarAppearance.Normal)]
        public ToolBarAppearance Appearance
        {
            get
            {
                return this.GetValue<ToolBarAppearance>(ToolBar.AppearanceProperty, ToolBarAppearance.Normal);
            }
            set
            {
                if (this.Appearance != value)
                {
                    Update();

                    if (value != ToolBarAppearance.Normal)
                    {
                        this.SetValue<ToolBarAppearance>(ToolBar.AppearanceProperty, value);
                    }
                    else
                    {
                        RemoveValue<ToolBarAppearance>(ToolBar.AppearanceProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show tooltips.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to show tooltips; otherwise, <c>false</c>.
        /// </value>
        public bool ShowToolTips
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display dropdown arrows.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to display dropdown arrows; otherwise, <c>false</c>.
        /// </value>
        public bool DropDownArrows
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
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
        /// Gets the default text align.
        /// </summary>
        /// <value>The default text align.</value>
        protected virtual ToolBarTextAlign DefaultTextAlign
        {
            get
            {
                return ToolBarTextAlign.Underneath;
            }
        }        

        /// <summary>Specifies the alignment of text on the toolbar button control.</summary>
        /// <value></value>        
        public ToolBarTextAlign TextAlign
        {
            get
            {
                return this.GetValue<ToolBarTextAlign>(ToolBar.TextAlignProperty, this.DefaultTextAlign);
            }
            set
            {
                if (this.TextAlign != value)
                {
                    if (value != this.DefaultTextAlign)
                    {
                        this.SetValue<ToolBarTextAlign>(ToolBar.TextAlignProperty, value, this.DefaultTextAlign);
                    }
                    else
                    {
                        this.RemoveValue<ToolBarTextAlign>(ToolBar.TextAlignProperty);
                    }

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the text align.
        /// </summary>
        private void ResetTextAlign()
        {
            this.TextAlign = this.DefaultTextAlign;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is horizontal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is horizontal; otherwise, <c>false</c>.
        /// </value>
        internal bool IsHorizontalDocked(DockStyle enmDock)
        {
            return (!this.IsLeftDocked(enmDock) && !this.IsRightDocked(enmDock));
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display drag handle.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to display drag handle; otherwise, <c>false</c>.
        /// </value>
        public bool DragHandle
        {
            get
            {
                return this.GetValue<bool>(ToolBar.DragHandleProperty, true);
            }
            set
            {
                if (this.DragHandle != value)
                {
                    Update();

                    if (value != true)
                    {
                        this.SetValue<bool>(ToolBar.DragHandleProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(ToolBar.DragHandleProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display menu handle.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to display menu handle; otherwise, <c>false</c>.
        /// </value>
        public bool MenuHandle
        {
            get
            {
                return this.GetValue<bool>(ToolBar.MenuHandleProperty, true);
            }
            set
            {
                if (this.MenuHandle != value)
                {
                    Update();

                    if (value != true)
                    {
                        this.SetValue<bool>(ToolBar.MenuHandleProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(ToolBar.MenuHandleProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the height of the tool bar.
        /// </summary>
        /// <value>The height of the tool bar.</value>
        internal int ToolBarHeight
        {
            get
            {
                ToolBarSkin objToolBarSkin = this.Skin as ToolBarSkin;
                if (objToolBarSkin != null)
                {
                    return objToolBarSkin.Height;
                }
                return 25;
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false)]
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

        /// <summary>
        /// Indicates if to render padding attribute
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
        {
            return PaddingValue.Empty != objPadding;
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(DockStyle.Top)]
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
        /// Gets the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 0x16);
            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ToolBarWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as ToolBarWinFormsCompatibility;
            }
        }

        /// <summary>
        /// Resets the size of the button.
        /// </summary>
        private void ResetButtonSize()
        {
            this.ButtonSize = Size.Empty;
        }

        #endregion Properties

        #region Methods

        #region Render

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Call base behavior
            base.RenderControl(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// ToolBar render implementation
        /// </summary>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Register all toolbar items
            RegisterBatch(Buttons);

            // If flat mode
            ToolBarAppearance enmToolBarAppearance = Appearance;

            // If is a flat toolbar
            if (this.Appearance == ToolBarAppearance.Flat)
            {
                objWriter.WriteAttributeString(WGAttributes.Style, "F");
            }

            objWriter.WriteAttributeString(WGAttributes.ImageHeight, this.ImageSize.Height.ToString());
            objWriter.WriteAttributeString(WGAttributes.ImageWidth, this.ImageSize.Width.ToString());

            // if text should go underneath
            if (this.TextAlign == ToolBarTextAlign.Underneath)
            {
                objWriter.WriteAttributeString(WGAttributes.TextImageRelation, ((int)TextImageRelation.ImageAboveText).ToString());
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.TextImageRelation, ((int)TextImageRelation.ImageBeforeText).ToString());
            }

            // Render buttons
            RenderControls(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Render buttons
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // render all toolbar items
            foreach (ToolBarButton objButton in Buttons)
            {
                objButton.RenderButton(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render the ToolBarItemAutoSizePreservedPlaceholders attribute.
            objWriter.WriteAttributeString(WGAttributes.ToolBarItemAutoSizePreservedPlaceholders, this.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
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

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Render the ToolBarItemAutoSizePreservedPlaceholders attribute.
                objWriter.WriteAttributeString(WGAttributes.ToolBarItemAutoSizePreservedPlaceholders, this.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
            }
        }

        #endregion Render

        /// <summary>
        /// Creates the button collection.
        /// </summary>
        /// <returns></returns>
        [Browsable(false)]
        protected virtual ToolBarItemCollection CreateButtonCollection()
        {
            return new ToolBarItemCollection(this);
        }

        /// <summary>
        /// Gets the preferred size.
        /// </summary>
        /// <param name="objProposedSize">Size of the proposed.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            //Get the base preferd size
            Size objPreferredSize = objProposedSize;

            if (this.Buttons == null || this.Buttons.Count == 0)
            {
                objPreferredSize = this.ButtonSize;
            }
            else if (this.AutoSize)
            {
                //init value 
                objPreferredSize = this.CalculateSize();
            }

            return objPreferredSize;
        }

        /// <summary>
        /// Layout the internal controls to reflect parent changes
        /// </summary>
        /// <param name="objEventArgs">The layout arguments.</param>
        /// <param name="objNewSize">The new parent size.</param>
        /// <param name="objOldSize">The old parent size.</param>
        protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
        {
            // We have a diffrent layout schema for the toolbar
        }

        /// <summary>
        /// Calculates the size.
        /// </summary>
        /// <returns></returns>
        private Size CalculateSize()
        {
            Size objCalculateSize = Size.Empty;

            //Get image size
            Size objImageSize = new Size(this.ImageSize.Width, this.ImageSize.Height);

            ToolBarButtonSkin objButtonSkin = this.ToolBarButtonSkin;

            //get toolbar skin
            ToolBarSkin objSkin = this.Skin as ToolBarSkin;
            if (objSkin != null)
            {
                bool blnHasText = false;
                int intMaxTextWidth = 0;
                int intMaxFontHeight = 0;

                // Go over all buttons and search buttons that have text/image/both text and image
                foreach (ToolBarButton objButton in this.Buttons)
                {
                    int intTextWidth = 0;
                    int intFontHeight = 0;
                    if (objButton.Text != string.Empty)
                    {
                        blnHasText = true;
                        intTextWidth = CommonUtils.GetStringMeasurements(objButton.Text, objButton.Font).Width;
                        if (intTextWidth > intMaxTextWidth)
                        {
                            intMaxTextWidth = intTextWidth;
                        }

                        intFontHeight = CommonUtils.GetFontHeight(objButton.Font);
                        if (intFontHeight > intMaxFontHeight)
                        {
                            intMaxFontHeight = intFontHeight;
                        }
                    }
                }

                if (this.TextAlign == ToolBarTextAlign.Underneath)
                {
                    objCalculateSize.Height = objImageSize.Height;
                    if (blnHasText)
                    {
                        objCalculateSize.Height += intMaxFontHeight;
                    }
                    objCalculateSize.Width = Math.Max(intMaxTextWidth, objImageSize.Width);
                }
                else
                {
                    objCalculateSize.Height = Math.Max(CommonUtils.GetFontHeight(objSkin.Font), objImageSize.Height);
                    objCalculateSize.Width = intMaxTextWidth + objImageSize.Width;
                }

                // Add toolbar skin padding
                objCalculateSize.Height += objSkin.Padding.Vertical;
                objCalculateSize.Width += objSkin.Padding.Horizontal;

                // Add toolbar frame size.
                objCalculateSize.Height += objSkin.TopFrameHeight + objSkin.BottomFrameHeight;
                objCalculateSize.Width += objSkin.LeftFrameWidth + objSkin.RightFrameWidth;

                if (objButtonSkin != null)
                {
                    // Get dock style.
                    DockStyle enmDockStyle = this.Dock;

                    // Add frame size according to dock style.
                    if (enmDockStyle == DockStyle.Top || enmDockStyle == DockStyle.Bottom || enmDockStyle == DockStyle.Fill)
                    {
                        // Add frame size according to dock style.
                        objCalculateSize.Height += objButtonSkin.TopFrameHeight + objButtonSkin.BottomFrameHeight;

                        // Add toolbar button skin padding and margins.
                        objCalculateSize.Height += objButtonSkin.Padding.Vertical + objButtonSkin.Margin.Vertical;
                    }
                    else if (enmDockStyle == DockStyle.Right || enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Fill)
                    {
                        // Add frame size according to dock style.
                        objCalculateSize.Width += objButtonSkin.LeftFrameWidth + objButtonSkin.RightFrameWidth;

                        // Add toolbar button skin padding and margins.
                        objCalculateSize.Width += objButtonSkin.Padding.Horizontal + objButtonSkin.Margin.Horizontal;
                    }
                }
            }

            return objCalculateSize;
        }

        internal void InternalRemove(ToolBarButton objToolBarButton)
        {
            this.UnRegisterComponent(objToolBarButton);
        }

        internal void InternalClear(ICollection objToolBarButtons)
        {
            this.UnRegisterBatch(objToolBarButtons);
            // Invalidates layout.
            this.InvalidateLayout(new LayoutEventArgs(false, true, true));

            this.Update();
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            ToolBarItemCollection objButtons = this.Buttons;

            // register the Buttons
            if (objButtons != null)
            {
                RegisterBatch(objButtons);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            ToolBarItemCollection objButtons = this.Buttons;

            // Unregister the Buttons
            if (objButtons != null)
            {
                UnRegisterBatch(objButtons);
            }
        }

        /// <summary>
        /// Do not serialize the size on docked mode
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldSerializeClientSize()
        {
            return this.Dock == DockStyle.None;
        }

        /// <summary>
        /// Do not serialize the button size if is empty
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeButtonSize()
        {
            return !this.ButtonSizeInternal.IsEmpty;
        }

        /// <summary>
        /// Shoulds the text align serialize.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeTextAlign()
        {
            return this.TextAlign != this.DefaultTextAlign;
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.Buttons;
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new ToolBarWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.ToolBarItemAutoSizePreservedPlaceholders)
            {
                // We need to update the whole control to make all its items updated.
                this.Update();
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion Methods
    }

    #endregion ToolBar Class

    #region ToolBarCollection Class

    /// <summary>
    /// ToolBar collection.
    /// </summary>
    [Serializable()]
    public class ToolBarCollection : System.Collections.CollectionBase
    {
        #region Class Members

        private Control mobjParent = null;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objParent"></param>
        public ToolBarCollection(Control objParent)
        {
            mobjParent = objParent;
        }

        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="objToolBar"></param>
        public int Add(ToolBar objToolBar)
        {
            objToolBar.InternalParent = mobjParent;
            return List.Add(objToolBar);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objToolBar"></param>
        public void Remove(ToolBar objToolBar)
        {
            if (objToolBar.InternalParent == mobjParent)
            {
                objToolBar.InternalParent = null;
            }

            List.Remove(objToolBar);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="ToolBar"/> with the specified int index.
        /// </summary>
        /// <value></value>
        public ToolBar this[int intIndex]
        {
            get
            {
                return (ToolBar)List[intIndex];
            }
            set
            {
                List[intIndex] = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolBarCollection Class

    #region ToolBarButton Class

    /// <summary>
    /// Summary description for ToolBarButton.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.DesignTimeVisible(false)]
    [System.ComponentModel.DefaultEvent("Click")]
    [Serializable()]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.ToolBarButtonSkin))]
    public class ToolBarButton : Component, ISkinable
    {
        #region Class Members

        private static SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(ToolBarButton));
        private static SerializableProperty LabelProperty = SerializableProperty.Register("Label", typeof(string), typeof(ToolBarButton));
        private static SerializableProperty FontProperty = SerializableProperty.Register("Font", typeof(Font), typeof(ToolBarButton));
        private static SerializableProperty ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(ToolBarButton));
        private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(ToolBarButton));
        private static SerializableProperty SizeProperty = SerializableProperty.Register("Size", typeof(int), typeof(ToolBarButton));
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ToolBarButton));
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ToolBarButton));
        private static SerializableProperty StyleProperty = SerializableProperty.Register("Style", typeof(ToolBarButtonStyle), typeof(ToolBarButton));
        private static SerializableProperty DropDownProperty = SerializableProperty.Register("DropDown", typeof(ContextMenu), typeof(ToolBarButton));
        private static SerializableProperty CustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(ToolBarButton));

        /// <summary>
        /// 
        /// </summary>
        public static readonly SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ToolBarButton));

        /// <summary>
        /// The Click event registration.
        /// </summary>
        private static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof(EventHandler), typeof(ToolBarButton));

        /// <summary>
        /// Occurs on clicking the button.
        /// </summary>
        public event EventHandler Click
        {
            add
            {
                this.AddCriticalHandler(ToolBarButton.ClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolBarButton.ClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Click event.
        /// </summary>
        private EventHandler ClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolBarButton.ClickEvent);
            }
        }

        /// <summary>
        /// The parent toolbar
        /// </summary>
        private ToolBar mobjToolBar = null;

        #endregion Class Members

        #region C'Tor

        /// <summary>
        ///
        /// </summary>
        public ToolBarButton()
        {
            // Initialize the toolbar button
            InitializeButton();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        public ToolBarButton(string strName, string strLabel)
        {
            Name = strName;
            this.SetValue<string>(ToolBarButton.LabelProperty, strLabel);

            // Initialize the toolbar button
            InitializeButton();
        }

        /// <summary>
        /// Initializes the button.
        /// </summary>
        private void InitializeButton()
        {
            // Set the toolbar initialize state
            this.SetState(ComponentState.Visible | ComponentState.Enabled, true);
        }

        /// <summary>
        /// Invalidates the tool bar layout.
        /// </summary>
        private void InvalidateToolBarLayout()
        {
            ToolBar objParentToolBar = this.ToolBar;
            if (objParentToolBar != null)
            {
                objParentToolBar.InvalidateLayout(new LayoutEventArgs(false, true, true));
            }
        }

        #endregion C'Tor

        #region Events

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                if (!this.Enabled || !this.Visible)
                {
                    return false;
                }
                else
                {
                    return base.IsEventsEnabled;
                }
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // Call base implementation
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "Click":
                    //Get mouse event args from the objevent
                    MouseEventArgs objMouseEventArgs = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);

                    //If Mouse event args where found test if this is a right click event
                    if (objMouseEventArgs.Button != MouseButtons.Right)
                    {
                        ToolBarButton objToolBarButton = this;

                        // Show drop down - if one has been declared.
                        if (this.DropDownMenu != null)
                        {
                            this.DropDownMenu.Show(this, Point.Empty, DialogAlignment.Below);

                            objToolBarButton = null;
                        }
                        else
                        {
                            OnClick();
                        }

                        // Raise click event for the parent toolbar.
                        if (this.ToolBar != null)
                        {
                            ToolBar.FireEvent(objEvent, objToolBarButton);
                        }

                    }
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnClick()
        {
            // Raise click event.
            if (ClickHandler != null)
            {
                ClickHandler(this, new EventArgs());
            }
        }

        #endregion Events

        #region Properties

        /// <summary>
        ///Gets or sets the text that appears as a ToolTip for the button.
        /// </summary>
        [Localizable(true), SRDescription("ToolBarButtonToolTipTextDescr")]
        public string ToolTipText
        {
            get
            {
                return this.GetValue<string>(ToolBarButton.ToolTipTextProperty, string.Empty);
            }
            set
            {
                if (this.ToolTipText != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(ToolBarButton.ToolTipTextProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBarButton.ToolTipTextProperty);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ToolBarButtonStyle.PushButton)]
        public ToolBarButtonStyle Style
        {
            get
            {
                return this.GetValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty, ToolBarButtonStyle.PushButton);
            }
            set
            {
                ToolBarButtonStyle enmStyle = this.Style;
                if (enmStyle != value)
                {
                    if (enmStyle == ToolBarButtonStyle.ToggleButton)
                    {
                        Click -= new EventHandler(PushButton_Click);
                    }


                    if (value != ToolBarButtonStyle.PushButton)
                    {
                        this.SetValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty);
                    }

                    enmStyle = value;

                    if (enmStyle == ToolBarButtonStyle.ToggleButton)
                    {
                        Click += new EventHandler(PushButton_Click);
                    }

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Sets the current button fore color
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return this.GetValue<Color>(ToolBarButton.ForeColorProperty, Color.Empty);
            }
            set
            {
                if (this.ForeColor != value)
                {
                    if (value != Color.Empty)
                    {
                        this.SetValue<Color>(ToolBarButton.ForeColorProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<Color>(ToolBarButton.ForeColorProperty);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Shoulds the color of the serialize fore.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeForeColor()
        {
            return ForeColor != Color.Empty;
        }

        /// <summary>
        /// Sets the current toolbar button font
        /// </summary>
        [DefaultValue(null)]
        public Font Font
        {
            get
            {
                Font objFont = this.GetValue<Font>(ToolBarButton.FontProperty, null);

                if (objFont != null)
                {
                    return objFont;
                }

                Font ownerFont = this.GetOwnerFont();

                return ownerFont;
            }
            set
            {
                if (this.Font != value)
                {
                    if (value != null)
                    {
                        this.SetValue<Font>(ToolBarButton.FontProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<Font>(ToolBarButton.FontProperty);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the owner font.
        /// </summary>
        /// <returns></returns>
        private Font GetOwnerFont()
        {
            if (this.ToolBar != null)
            {
                return this.ToolBar.Font;
            }
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        public virtual string CustomStyle
        {
            get
            {
                return this.GetValue<string>(ToolBarButton.CustomStyleProperty, string.Empty);
            }
            set
            {
                if (this.CustomStyle != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(ToolBarButton.CustomStyleProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBarButton.CustomStyleProperty);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ToolBar.ImageList"), SRDescription("ToolBarButtonImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                return this.GetValue<int>(ToolBarButton.ImageIndexProperty, -1);
            }
            set
            {
                if (this.ImageIndex != value)
                {
                    this.SetValue<int>(ToolBarButton.ImageIndexProperty, value, -1);

                    this.RemoveValue<string>(ToolBarButton.ImageKeyProperty);

                    // Invalidate toolbar's layout.
                    this.InvalidateToolBarLayout();

                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(""), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ToolBar.ImageList"), SRDescription("ToolBarButtonImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public string ImageKey
        {
            get
            {
                return this.GetValue<string>(ToolBarButton.ImageKeyProperty, string.Empty);
            }
            set
            {
                if (this.ImageKey != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(ToolBarButton.ImageKeyProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBarButton.ImageKeyProperty);
                    }

                    this.RemoveValue<int>(ToolBarButton.ImageIndexProperty);

                    // Invalidate toolbar's layout.
                    this.InvalidateToolBarLayout();

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the toolbar.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public ToolBar ToolBar
        {
            get
            {
                return mobjToolBar;
            }
            set
            {
                mobjToolBar = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DefaultValue("")]
        public string Name
        {
            get
            {
                if (Site != null)
                {
                    return Site.Name;
                }
                else
                {
                    return this.GetValue<string>(ToolBarButton.NameProperty, string.Empty);
                }
            }
            set
            {
                if (this.Name != value)
                {
                    this.Update();

                    if (value != string.Empty)
                    {
                        this.SetValue<string>(ToolBarButton.NameProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBarButton.NameProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [System.ComponentModel.DefaultValue(30)]
        public int Size
        {
            get
            {
                return this.GetValue<int>(ToolBarButton.SizeProperty, 24);
            }
            set
            {
                if (this.Size != value)
                {
                    if (value != 24)
                    {
                        this.SetValue<int>(ToolBarButton.SizeProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<int>(ToolBarButton.SizeProperty);
                    }
                    this.Update();
                }
            }
        }

        private ImageList ImageList
        {
            get
            {
                if (this.ToolBar != null && this.ToolBar.ImageList != null)
                {
                    return this.ToolBar.ImageList;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is a seperator.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is a seperator; otherwise, <c>false</c>.
        /// </value>
        private bool IsSeperator
        {
            get
            {
                return this.Style == ToolBarButtonStyle.Separator;
            }
        }

        /// <summary>Gets or sets the small image that is displayed for the item.</summary>
        /// <returns>The small image that is displayed for the <see cref="T:System.Windows.Forms.ListViewItem"></see>.</returns>
        /// <remarks>This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
        public ResourceHandle Image
        {
            get
            {
                return this.GetImage(ToolBarButton.ImageProperty, ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(ToolBarButton.ImageProperty, value, this.ImageList);
            }
        }

        /// <summary>
        /// Shoulds the serialize image.
        /// </summary>
        /// <returns></returns>
        protected bool ShouldSerializeImage()
        {
            if (this.ToolBar != null && this.ToolBar.ImageList != null)
            {
                return false;
            }
            else
            {
                return (this.GetValue<ResourceHandle>(ToolBarButton.ImageProperty, null) != null);
            }
        }

        /// <summary>
        ///
        /// </summary>
        [DefaultValue(""), SRDescription("ToolBarButtonTextDescr"), Localizable(true)]
        public string Text
        {
            get
            {
                return this.GetValue<string>(ToolBarButton.LabelProperty, string.Empty);
            }
            set
            {
                if (this.Text != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(ToolBarButton.LabelProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(ToolBarButton.LabelProperty);
                    }

                    if (value == "-")
                    {
                        this.Style = ToolBarButtonStyle.Separator;
                    }

                    // Invalidate toolbar's layout.
                    this.InvalidateToolBarLayout();

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToolBarButton"/> is pushed.
        /// </summary>
        /// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool Pushed
        {
            get
            {
                return this.GetState(ComponentState.Selected);
            }
            set
            {
                // Set the selected state and update the control if value had changed
                if (this.SetStateWithCheck(ComponentState.Selected, value))
                {
                    this.Update();
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool Visible
        {
            get
            {
                return this.GetState(ComponentState.Visible);
            }
            set
            {
                // Set the visible state and update the control if value changes
                if (this.SetStateWithCheck(ComponentState.Visible, value))
                {
                    //Repaint the all toolbar cause the buttons move to the empty(invisible) place.
                    if (this.ToolBar != null)
                    {
                        this.ToolBar.Update();
                    }
                    else
                    {
                        this.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MenuItem"/> is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                return this.GetState(ComponentState.Enabled);
            }
            set
            {
                // Set the enabled state and update the control if value had changed
                if (this.SetStateWithCheck(ComponentState.Enabled, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the drop down menu.
        /// </summary>
        /// <value>The drop down menu.</value>
        [System.ComponentModel.DefaultValue(null)]
        public ContextMenu DropDownMenu
        {
            get
            {
                return this.GetValue<ContextMenu>(ToolBarButton.DropDownProperty, null);
            }
            set
            {
                ContextMenu objDropDownMenu = this.DropDownMenu;
                if (objDropDownMenu != value)
                {
                    if (value != null)
                    {
                        objDropDownMenu = value;
                        this.SetValue<ContextMenu>(ToolBarButton.DropDownProperty, objDropDownMenu);
                    }
                    else
                    {
                        this.RemoveValue<ContextMenu>(ToolBarButton.DropDownProperty);
                    }
                    this.Update();
                }

                if (objDropDownMenu != null && objDropDownMenu.InternalParent == null)
                {
                    objDropDownMenu.InternalParent = this;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushButton_Click(object sender, EventArgs e)
        {
            this.Pushed = !this.Pushed;
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            ContextMenu objDropDown = this.DropDownMenu;
            if (objDropDown != null)
            {
                RegisterComponent(objDropDown);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            ContextMenu objDropDown = this.DropDownMenu;
            if (objDropDown != null)
            {
                UnRegisterComponent(objDropDown);
            }
        }

        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        internal void RenderButton(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (IsDirty(lngRequestID))
            {
                // Get owner toolbar
                ToolBar objToolbar = this.ToolBar;
                if (objToolbar != null)
                {
                    objWriter.WriteStartElement(WGConst.ControlsPrefix, WGTags.ToolBarButton, WGConst.ControlsNamespace);
                    RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);

                    // Get toolbar button calculated size.
                    Size objSize = GetSize();

                    // Render position
                    if (objToolbar.IsHorizontalDocked(objToolbar.Dock))
                    {
                        objWriter.WriteAttributeString(WGAttributes.Docking, GetHorizontalDocking(objContext, objToolbar));
                        objWriter.WriteAttributeString(WGAttributes.Width, objSize.Width.ToString());
                    }
                    else
                    {
                        objWriter.WriteAttributeString(WGAttributes.Docking, "T");
                        objWriter.WriteAttributeString(WGAttributes.Height, objSize.Height.ToString());
                    }
                    if (!this.Visible)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Visible, "0");
                    }

                    if (!this.Enabled)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Enabled, "0");
                    }


                    string strCustomStyle = this.CustomStyle;
                    if (strCustomStyle != string.Empty)
                    {
                        objWriter.WriteAttributeString(WGAttributes.CustomStyle, strCustomStyle);
                    }

                    string strToolTipText = ToolTipText;
                    if (strToolTipText != String.Empty)
                    {
                        objWriter.WriteAttributeText(WGAttributes.ToolTip, strToolTipText);
                    }

                    ToolBarButtonStyle enmStyle = this.Style;
                    if (enmStyle != ToolBarButtonStyle.PushButton)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Style, ((int)enmStyle).ToString());
                    }

                    if (enmStyle == ToolBarButtonStyle.ToggleButton)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Pushed, Pushed ? "1" : "0");
                    }

                    Color objColor = ForeColor;
                    if (objColor != Color.Empty)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objColor));
                    }

                    objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(Font));

                    ResourceHandle objImage = this.Image;

                    if (objImage == null && this.CustomStyle != "Label" && this.ToolBar != null && this.ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders)
                    {
                        objImage = EmptyGif;
                    }

                    if (objImage != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
                    }

                    if (this.Text != String.Empty)
                    {
                        objWriter.WriteAttributeText(WGAttributes.Text, this.Text);
                    }

                    if (this.DropDownMenu != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.DropDown, "1");
                        objWriter.WriteStartElement(WGTags.Button);
                        objWriter.WriteAttributeString(WGAttributes.MemberID, "1");
                        objWriter.WriteEndElement();
                    }

                    objWriter.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Gets the width of the seperator.
        /// </summary>
        /// <value>The width of the seperator.</value>
        private int SeperatorWidth
        {
            get
            {
                ToolBarButtonSkin objToolBarButtonSkin = SkinFactory.GetSkin(this) as ToolBarButtonSkin;
                if (objToolBarButtonSkin != null)
                {
                    return objToolBarButtonSkin.SeperatorWidth + objToolBarButtonSkin.SeperatorStyle.Padding.Horizontal;
                }
                return 3;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns></returns>
        protected virtual Size GetSize()
        {
            //get the skin
            ToolBarButtonSkin mobjSkin = (ToolBarButtonSkin)SkinFactory.GetSkin(this);

            // Define a calculated size.
            Size objCalculatedSize = new Size();

            //If we have a skin
            if (mobjSkin != null)
            {
                //If this is a seperator
                if (this.IsSeperator)
                {
                    //Get the seperator width
                    objCalculatedSize.Width = this.SeperatorWidth;
                }
                else
                {
                    // Get the button image size
                    Size objImageSize = this.ToolBar.ImageSize;

                    // Add image size to Calculated height
                    objCalculatedSize.Height = Math.Max(this.CustomStyle != "Label" || this.Image != null ? objImageSize.Height : 0, objCalculatedSize.Height);

                    // Add image size to Calculated width.
                    if ((this.CustomStyle != "Label" && this.ToolBar != null && this.ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders) || this.Image != null)
                    {
                        objCalculatedSize.Width += objImageSize.Width;
                    }

                    // Define empty size.
                    Size objTextSize = System.Drawing.Size.Empty;

                    //If the button does not have text and on image
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        objTextSize = new Size(0, CommonUtils.GetFontHeight(this.Font));
                    }
                    else
                    {
                        //Calc the text size
                        objTextSize = CommonUtils.GetStringMeasurements(this.Text, this.Font, true);
                    }

                    if (this.ToolBar.TextAlign == ToolBarTextAlign.Right)
                    {
                        //Get the value that is higher
                        objCalculatedSize.Height = Math.Max(objCalculatedSize.Height, objTextSize.Height);

                        //Add the text width
                        objCalculatedSize.Width += objTextSize.Width;
                    }
                    else
                    {
                        //Get the value that is higher
                        objCalculatedSize.Width = Math.Max(objCalculatedSize.Width, objTextSize.Width);

                        //Add the text Height
                        objCalculatedSize.Height += objTextSize.Height;
                    }

                    //If the button has a Dropdown menu add the image size to the calculation 
                    if (this.DropDownMenu != null)
                    {
                        Size objDropDownImageSize = mobjSkin.DropDownImageSize;
                        if (objDropDownImageSize != null)
                        {
                            objCalculatedSize.Width += objDropDownImageSize.Width;
                            objCalculatedSize.Height += objDropDownImageSize.Height;
                        }
                    }

                    //Get the margin
                    MarginValue objMarginValue = mobjSkin.Margin;

                    //Get the padding
                    PaddingValue objPaddingValue = mobjSkin.Padding;

                    //Add the margin and the padding vertical
                    objCalculatedSize.Height += objPaddingValue.Vertical + objMarginValue.Vertical;
                    objCalculatedSize.Height += mobjSkin.TopFrameHeight + mobjSkin.BottomFrameHeight;

                    //Add the margin and the padding Horizontal
                    objCalculatedSize.Width += objPaddingValue.Horizontal + objMarginValue.Horizontal;
                    objCalculatedSize.Width += mobjSkin.LeftFrameWidth + mobjSkin.RightFrameWidth;
                }
            }
            else
            {
                //No skin found
                objCalculatedSize.Width = this.ToolBar.ToolBarHeight;
                objCalculatedSize.Height = this.ToolBar.ToolBarHeight;
            }

            return objCalculatedSize;
        }

        /// <summary>
        /// Gets the button docking.
        /// </summary>
        /// <param name="strDocking">The STR docking.</param>
        /// <returns></returns>
        protected virtual string GetButtonDocking(string strDocking)
        {
            return strDocking;
        }

        /// <summary>
        ///
        /// </summary>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (ClickHandler != null || this.DropDownMenu != null ||
                (this.ToolBar != null && this.ToolBar.ButtonClickHandler != null))
            {
                objEvents.Set(WGEvents.Click);
            }
            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("Click"))
            {
                objEvents.Set(WGEvents.Click);
            }
            return objEvents;
        }

        /// <summary>
        /// Gets the horizontal docking.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objToolbar">The obj toolbar.</param>
        /// <returns></returns>
        private string GetHorizontalDocking(IContext objContext, ToolBar objToolbar)
        {
            string strDock = "L"; //Default value is Dock left

            //check if we have value in property
            if (objToolbar.HasRightToLeft)
            {
                if (this.ToolBar.RightToLeft == RightToLeft.Yes)
                {
                    //set the value to right
                    strDock = "R";
                }
            }
            else if (objContext.RightToLeft)
            {
                //if the context is RTL the toolbar should also be RTL
                strDock = "R";
            }

            return this.GetButtonDocking(strDock);
        }

        #endregion Methods

        #region ISkinable Members

        string ISkinable.Theme
        {
            get
            {
                ISkinable objToolBar = this.ToolBar as ISkinable;
                if (objToolBar != null)
                {
                    return objToolBar.Theme;
                }
                return string.Empty;
            }
        }

        #endregion
    }

    #endregion ToolBarButton Class

    #region ToolBarItemCollection Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ToolBarItemCollection : ICollection, IList, IEnumerable, IObservableList
    {
        private ArrayList mobjButtons = null;

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="ToolBarItemCollection"/> instance.
        /// </summary>
        /// <param name="objToolBar">The obj tool bar.</param>
        public ToolBarItemCollection(ToolBar objToolBar)
        {
            mobjToolBar = objToolBar;
            mobjButtons = new ArrayList();
        }

        #endregion C'Tor

        #region Class Members

        private ToolBar mobjToolBar;

        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="objToolBarButton"></param>
        /// <returns></returns>
        public int Add(ToolBarButton objToolBarButton)
        {
            int intIndex = -1;

            if (objToolBarButton != null)
            {
                objToolBarButton.ToolBar = mobjToolBar;
                objToolBarButton.InternalParent = mobjToolBar;

                intIndex = List.Add(objToolBarButton);

                mobjToolBar.InvalidateLayout(new LayoutEventArgs(false, true, true));

                mobjToolBar.Update();

                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objToolBarButton));
                }
            }

            return intIndex;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arrToolBarButtons"></param>
        public void AddRange(ToolBarButton[] arrToolBarButtons)
        {
            foreach (ToolBarButton objToolBarButton in arrToolBarButtons)
            {
                Add(objToolBarButton);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objToolBarButton"></param>
        public void Remove(ToolBarButton objToolBarButton)
        {
            if (objToolBarButton != null)
            {
                if (objToolBarButton.ToolBar == mobjToolBar)
                {
                    objToolBarButton.ToolBar = null;
                }

                mobjToolBar.InternalRemove(objToolBarButton);

                List.Remove(objToolBarButton);

                mobjToolBar.InvalidateLayout(new LayoutEventArgs(false, true, true));

                mobjToolBar.Update();

                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(objToolBarButton));
                }
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IList"/> is read-only.
        /// </exception>
        public void Clear()
        {
            mobjToolBar.InternalClear(List);
            mobjButtons.Clear();
            if (ObservableListCleared != null)
            {
                ObservableListCleared(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Return the index of objToolBarButton in the Buttons collection
        /// </summary>
        /// <param name="objToolBarButton"></param>
        public int IndexOf(ToolBarButton objToolBarButton)
        {
            return this.mobjButtons.IndexOf(objToolBarButton);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        protected virtual ArrayList List
        {
            get
            {
                return mobjButtons;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ToolBarButton"/> with the specified int index.
        /// </summary>
        /// <value></value>
        public ToolBarButton this[int intIndex]
        {
            get
            {
                return (ToolBarButton)List[intIndex];
            }
            set
            {
                value.InternalParent = mobjToolBar;
                List[intIndex] = value;
            }
        }

        #endregion Properties

        #region IList Members

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (ToolBarButton)value;
            }
        }

        void IList.RemoveAt(int index)
        {
            this.Remove((ToolBarButton)this[index]);
        }

        void IList.Insert(int index, object objValue)
        {
        }

        void IList.Remove(object objValue)
        {
            this.Remove((ToolBarButton)objValue);
        }

        bool IList.Contains(object objValue)
        {

            return this.mobjButtons.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjButtons.IndexOf(objValue);
        }

        int IList.Add(object objValue)
        {
            return this.Add((ToolBarButton)objValue);
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region ICollection Members

        bool ICollection.IsSynchronized
        {
            get
            {

                return mobjButtons.IsSynchronized;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public int Count
        {
            get
            {
                return mobjButtons.Count;
            }
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.List.CopyTo(objArray, index);
        }

        object ICollection.SyncRoot
        {
            get
            {
                return mobjButtons.SyncRoot;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mobjButtons.GetEnumerator();
        }

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        public event System.EventHandler ObservableListCleared;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemRemoved;

        #endregion
    }

    #endregion ToolBarItemCollection Class

    #region ToolBarButtonClickEventArgs Class

    /// <summary>
    /// 
    /// </summary>
    public delegate void ToolBarButtonClickEventHandler(object sender, ToolBarButtonClickEventArgs e);

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ToolBarButtonClickEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objButton"></param>
        public ToolBarButtonClickEventArgs(ToolBarButton objButton)
        {
            this.button = objButton;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public ToolBarButton Button
        {
            get
            {
                return this.button;
            }
            set
            {
                this.button = value;
            }
        }

        /// <summary>
        /// Gets or sets the tool bar button.
        /// </summary>
        /// <value>The tool bar button.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ToolBarButtonClickEventArgs.Button instead.")]
        public ToolBarButton ToolBarButton
        {
            get
            {
                return this.button;
            }
            set
            {
                this.button = value;
            }
        }

        #endregion Properties

        #region Class Members

        private ToolBarButton button;

        #endregion Class Members
    }

    #endregion ToolBarButtonClickEventArgs Class
}
