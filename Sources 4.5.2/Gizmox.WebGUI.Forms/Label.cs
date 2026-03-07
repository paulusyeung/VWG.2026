#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Label Class

    /// <summary>
    /// Represents a standard Gizmox.WebGUI label.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(Label), "Label_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(Label), "Label.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]    
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [SRDescription("DescriptionLabel"), DefaultProperty("Text")]
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.Label)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.LabelSkin))]
    public class Label : Control
    {
        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(Label));

        /// <summary>
        /// Provides a property reference to ImageList property.
        /// </summary>
        private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(Label));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(Label));

        /// <summary>
        /// Provides a property reference to ImageIndex property.
        /// </summary>
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(Label), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ImageAlign property.
        /// </summary>
        private static SerializableProperty ImageAlignProperty = SerializableProperty.Register("ImageAlign", typeof(ContentAlignment), typeof(Label));

        /// <summary>
        /// Provides a property reference to TextAlign property.
        /// </summary>
        private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ContentAlignment), typeof(Label));


        /// <summary>
        /// Provides a property reference to UseMnemonic property.
        /// </summary>
        private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register("UseMnemonic", typeof(bool), typeof(Label), new SerializablePropertyMetadata(true));
        
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
        /// </summary>
        public Label()
        {
            this.SetState(ControlState.TabStop, false);

            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, this.IsOwnerDraw());
            base.SetStyle(ControlStyles.Selectable | ControlStyles.FixedHeight, false);
            base.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
        /// </summary>
        /// <param name="strText">The label text.</param>
        public Label(string strText)
            : this()
        {
            Text = strText;
        }

        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Determines whether is owner draw.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if is owner draw; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsOwnerDraw()
        {
            return (this.FlatStyle != FlatStyle.System);
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="objProposedSize">The custom-sized area for a control.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            Size objPreferredSize = base.GetPreferredSize(objProposedSize);

            if (this.AutoSize)
            {
                // Get padding value.
                Padding objPadding = this.Padding;

                int intMaximumWidth = -1;
                Size objMaximumSize = this.MaximumSize;
                if (!objMaximumSize.IsEmpty)
                {
                    intMaximumWidth = objMaximumSize.Width - objPadding.Horizontal;
                }

                objPreferredSize = CommonUtils.GetStringMeasurements(this.Text, this.Font, intMaximumWidth);

                if (this.AutoSizeMode == AutoSizeMode.GrowOnly)
                {
                    objPreferredSize.Width = Math.Max(objPreferredSize.Width, objProposedSize.Width);
                    objPreferredSize.Height = Math.Max(objPreferredSize.Height, objProposedSize.Height);
                }

                // Add padding values to prefered size.
                objPreferredSize.Width += objPadding.Horizontal;
                objPreferredSize.Height += objPadding.Vertical;
            }

            return objPreferredSize;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // Call the base attribute rendering
            base.RenderAttributes(objContext, objWriter);

            // Add control attributes
            objWriter.WriteAttributeText(WGAttributes.Text, this.Text);
            objWriter.WriteAttributeString(WGAttributes.TextAlign, this.GetProxyPropertyValue<ContentAlignment>("TextAlign", this.TextAlign).ToString());
            if (this.AutoSize)
            {
                objWriter.WriteAttributeString(WGAttributes.AutoSize, "1");
            }

            // Get image.
            ResourceHandle objImage = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
            if (objImage != null)
            {
                // add attributes to control element
                objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
                objWriter.WriteAttributeString(WGAttributes.ImageAlign, this.ImageAlign.ToString());
            }
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new LabelRenderer(this);
        }

        /// <summary>
        /// Commits the value editing.
        /// </summary>
        /// <param name="objFormattedValue">The object formatted value.</param>
        protected override void CommitValueEditing(object objFormattedValue)
        {
            if (objFormattedValue != null && objFormattedValue is string)
            {
                this.Text = objFormattedValue.ToString();
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [can edit control].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit control]; otherwise, <c>false</c>.
        /// </value>
        public override bool CanEditControl
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        public override Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                // If value is different from current padding
                if (base.Padding != value)
                {
                    // Assign the new value
                    base.Padding = value;

                    // If Label is AutoSize, re-calculate it's size
                    if (this.AutoSize)
                    {
                        this.PerformLayout(true);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the alignment of text in the label.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.TopLeft"></see>.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception>
        [SRCategory("CatAppearance"), System.ComponentModel.DefaultValue(ContentAlignment.TopLeft), SRDescription("LabelTextAlignDescr"), Localizable(true), ProxyBrowsable(true)]
        public ContentAlignment TextAlign
        {

            get
            {
                return this.GetValue<ContentAlignment>(Label.TextAlignProperty, ContentAlignment.TopLeft);
            }
            set
            {
                if (this.TextAlign != value)
                {
                    this.Update();

                    if (value != ContentAlignment.TopLeft)
                    {
                        this.SetValue<ContentAlignment>(Label.TextAlignProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ContentAlignment>(Label.TextAlignProperty);
                    }
                    FireObservableItemPropertyChanged("TextAlign");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
        /// </summary>
        /// <returns>true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns>
        [DefaultValue(false), EditorBrowsable(EditorBrowsableState.Always), SRDescription("LabelAutoSizeDescr"), SRCategory("CatLayout"), RefreshProperties(RefreshProperties.All), Localizable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
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

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [EditorBrowsable(EditorBrowsableState.Never), DefaultValue(false), Browsable(false)]
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
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <returns>The text associated with this control.</returns>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET2 || WG_NET35
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        [SettingsBindable(true)]
        public override string Text
        {
            get
            {
                if (this.UseMnemonic)
                {
                    return GetCommandText(base.Text);
                }

                return base.Text;
            }
            set
            {
                string strValue = value == null ? "" : value;
                if (base.Text != strValue)
                {
                    base.Text = strValue;

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false), SRDescription("LabelBackgroundImageDescr"), SRCategory("CatAppearance")]
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

        ///<summary>
        /// Gets or sets the flat style appearance of the label control.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default value is Standard.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. </exception>
        [SRCategory("CatAppearance"), DefaultValue(FlatStyle.Standard), SRDescription("ButtonFlatStyleDescr")]
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Standard;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the image on the button control.
        /// </summary>
        [System.ComponentModel.DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(Label.ImageAlignProperty, ContentAlignment.MiddleCenter);
            }
            set
            {
                if (this.ImageAlign != value)
                {
                    this.Update();

                    if (value != ContentAlignment.MiddleCenter)
                    {
                        this.SetValue<ContentAlignment>(Label.ImageAlignProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ContentAlignment>(Label.ImageAlignProperty);
                    }
                }
            }

        }

        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("ListViewItemImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                return this.GetValue<int>(Label.ImageIndexProperty, -1);
            }
            set
            {
                if (this.ImageIndex != value)
                {
                    if (value != -1)
                    {
                        this.SetValue<int>(Label.ImageIndexProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<int>(Label.ImageIndexProperty);
                    }

                    this.RemoveValue<string>(Label.ImageKeyProperty);
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
        /// <filterpriority>2</filterpriority>
        [SRDescription("ListViewSmallImageListDescr"), SRCategory("CatBehavior"), DefaultValue((string)null)]
        public ImageList ImageList
        {

            get
            {
                return this.GetValue<ImageList>(Label.ImageListProperty, null);
            }
            set
            {
                if (this.ImageList != value)
                {
                    if (value != null)
                    {
                        this.SetValue<ImageList>(Label.ImageListProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ImageList>(Label.ImageListProperty);
                    }

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
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue("")]
        public string ImageKey
        {
            get
            {
                return this.GetValue<string>(Label.ImageKeyProperty, string.Empty);
            }
            set
            {
                if (this.ImageKey != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(Label.ImageKeyProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(Label.ImageKeyProperty);
                    }

                    this.RemoveValue<int>(Label.ImageIndexProperty);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Shoulds the serialize image.
        /// </summary>
        /// <returns></returns>
        protected bool ShouldSerializeImage()
        {
            return (this.Image != null);
        }

        /// <summary>
        /// Gets or sets the image that is displayed on a button control.
        /// </summary>
        [SRCategory("CatAppearance"), SRDescription("ButtonImageDescr"), ProxyBrowsable(true)]
        public ResourceHandle Image
        {
            get
            {
                return this.GetImage(Label.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(Label.ImageProperty, value, this.ImageList);
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
                return new Size(100, 23);

            }
        }

        /// <summary>
        /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AutoSizeMode AutoSizeMode
        {
            get
            {
                return AutoSizeMode.GrowAndShrink;
            }
        }

        /// <summary>Gets or sets a value indicating whether the control interprets an ampersand character (&amp;) in the control's <see cref="P:System.Windows.Forms.Control.Text"></see> property to be an access key prefix character.</summary>
        /// <returns>true if the label doesn't display the ampersand character and underlines the character after the ampersand in its displayed text and treats the underlined character as an access key; otherwise, false if the ampersand character is displayed in the text of the control. The default is true.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), DefaultValue(true), SRDescription("LabelUseMnemonicDescr")]
        public bool UseMnemonic
        {
            get
            {
                return this.GetValue<bool>(Label.UseMnemonicProperty);
            }
            set
            {
                if (this.SetValue<bool>(Label.UseMnemonicProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    // Update control.
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value that specifies whether text rendering should be compatible with previous releases of Windows Forms.</summary>
        /// <returns>true if text rendering should be compatible with previous releases of Windows Forms; otherwise, false. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("UseCompatibleTextRenderingDescr")]
        public bool UseCompatibleTextRendering
        {
            get
            {
                return false;
            }
            set
            {}
        }


        /// <summary>Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the <see cref="T:System.Windows.Forms.Label"></see>, denoting that the <see cref="T:System.Windows.Forms.Label"></see> text extends beyond the specified length of the <see cref="T:System.Windows.Forms.Label"></see>.</summary>
        /// <returns>true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("LabelAutoEllipsisDescr"), DefaultValue(false), SRCategory("CatBehavior")]
        public bool AutoEllipsis
        {
            get
            {
                return false;
            }
            set
            {}
        }
 

 



        #endregion Properties
    }

    #endregion Label Class

    #region LabelRenderer Class

    /// <summary>
    /// 
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class LabelRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRenderer"/> class.
        /// </summary>
        /// <param name="objLabel">The obj label.</param>
        internal LabelRenderer(Label objLabel)
            : base(objLabel)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current label
            Label objLabel = this.Control as Label;
            if (objLabel != null)
            {
                //Write the label text
                RenderText(objContext, objGraphics, objLabel.Text, objLabel.Font, objLabel.ForeColor, objLabel.Size, objLabel.TextAlign, true);
            }
        }
    } 

    #endregion
}
