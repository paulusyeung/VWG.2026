using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    #region ButtonBase
    
    /// <summary>
    /// Implements the basic functionality common to button controls.
    /// </summary>
    [Serializable()]
    public abstract class ButtonBase : Control
    {

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to TextImageRelation property.
        /// </summary>
        private static SerializableProperty TextImageRelationProperty = SerializableProperty.Register("TextImageRelation", typeof(TextImageRelation), typeof(ButtonBase), new SerializablePropertyMetadata(TextImageRelation.Overlay));

        /// <summary>
        /// Provides a property reference to TextAlign property.
        /// </summary>
        private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ContentAlignment), typeof(ButtonBase), new SerializablePropertyMetadata(ContentAlignment.MiddleCenter));

        /// <summary>
        /// Provides a property reference to ImageAlign property.
        /// </summary>
        private static SerializableProperty ImageAlignProperty = SerializableProperty.Register("ImageAlign", typeof(ContentAlignment), typeof(ButtonBase), new SerializablePropertyMetadata(ContentAlignment.MiddleCenter));

        /// <summary>
        /// Provides a property reference to ImageListItem property.
        /// </summary>
        private static SerializableProperty ImageListItemProperty = SerializableProperty.Register("ImageListItem", typeof(ImageList), typeof(ButtonBase), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ButtonBase), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ImageIndex property.
        /// </summary>
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ButtonBase), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ButtonBase), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to FlatStyle property.
        /// </summary>
        private static SerializableProperty FlatStyleProperty = SerializableProperty.Register("FlatStyle", typeof(FlatStyle), typeof(ButtonBase), new SerializablePropertyMetadata(FlatStyle.Standard));

        /// <summary>
        /// The UseCompatibleTextRendering property registration.
        /// </summary>
        private static readonly SerializableProperty UseCompatibleTextRenderingProperty = SerializableProperty.Register("UseCompatibleTextRendering", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The UseVisualStyleBackColor property registration.
        /// </summary>
        private static readonly SerializableProperty UseVisualStyleBackColorProperty = SerializableProperty.Register("UseVisualStyleBackColor", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ImageSize property.
        /// </summary>
        private static SerializableProperty ImageSizeProperty = SerializableProperty.Register("ImageSize", typeof(Size), typeof(ButtonBase), new SerializablePropertyMetadata(new Size(16, 16)));

        /// <summary>
        /// Provides a property reference to UseMnemonic property.
        /// </summary>
        private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register("UseMnemonic", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(true));

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
        /// </see> property changes.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), SRDescription("ControlOnAutoSizeChangedDescr"), SRCategory("CatPropertyChanged")]
        public new event EventHandler AutoSizeChanged
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

        #endregion 

        #endregion

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ButtonBase"></see> 
        /// class.
        /// </summary>
        protected ButtonBase()
        {

        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // Call the base implementation
            base.RenderAttributes(objContext, objWriter);

            // add attributes to control element
            objWriter.WriteAttributeText(WGAttributes.Text, Text);

            // Set text align attribute
            objWriter.WriteAttributeString(WGAttributes.TextAlign, this.GetProxyPropertyValue<ContentAlignment>("TextAlign", this.TextAlign).ToString());

            // If auto ellipsis
            if (this.AutoEllipsis)
            {
                // Set text auto ellipsis
                objWriter.WriteAttributeString(WGAttributes.AutoEllipsis, "1");
            }

            // Get image.
            ResourceHandle objImage = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
            if (objImage != null)
            {
                // add attributes to control element
                objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
                objWriter.WriteAttributeString(WGAttributes.ImageAlign, this.GetProxyPropertyValue<ContentAlignment>("ImageAlign", this.GetProxyPropertyValue<ContentAlignment>("ImageAlign", this.ImageAlign)).ToString());
                objWriter.WriteAttributeString(WGAttributes.TextImageRelation, ((int)this.GetProxyPropertyValue<TextImageRelation>("TextImageRelation", this.GetProxyPropertyValue<TextImageRelation>("TextImageRelation", this.TextImageRelation))).ToString());
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.TextImageRelation, "0");
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

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeText(WGAttributes.Text, Text);
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
        /// Shoulds the size of the serialize image.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeImageSize()
        {
            return this.ContainsValue<Size>(ButtonBase.ImageSizeProperty);
        }

        /// <summary>
        /// Shoulds serialize the use visual style back color.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeUseVisualStyleBackColor()
        {
            return this.UseVisualStyleBackColor;
        }
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="objProposedSize">The custom-sized area for a control.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            //Get the base preferd size
            Size objPreferredSize = base.GetPreferredSize(objProposedSize);

            //If the control is set to auto size
            if (this.AutoSize)
            {
                //Get the text size
                objPreferredSize = this.GetStringMeasurements(this.Text, this.Font);
            }

            return objPreferredSize;
        }

        /// <summary>
        /// Gets the string measurements.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="objFont">The obj font.</param>
        /// <returns></returns>
        protected virtual Size GetStringMeasurements(string strText, Font objFont)
        {
            return CommonUtils.GetStringMeasurements(strText, objFont);
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new ButtonBaseRenderer(this);
        }

        #endregion

        #region Properties

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

        public override bool CanEditControl
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the image that is displayed on a button control.
        /// </summary>
        [SRDescription("ButtonImageDescr"), SRCategory("CatAppearance"), DefaultValue(null), ProxyBrowsable(true)]
        public ResourceHandle Image
        {
            get
            {
                return this.GetImage(Button.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                // Invalidates layout.
                this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                this.SetImage(Button.ImageProperty, value, this.ImageList);
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the image on the button control.
        /// </summary>
        [System.ComponentModel.DefaultValue(ContentAlignment.MiddleCenter), ProxyBrowsable(true)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(Button.ImageAlignProperty);
            }
            set
            {
                if (this.SetValue<ContentAlignment>(Button.ImageAlignProperty, value))
                {
                    this.Update();
                }                
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value></value>
        [DefaultValue(ContentAlignment.MiddleCenter), ProxyBrowsable(true)]
        public virtual ContentAlignment TextAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(Button.TextAlignProperty);
            }
            set
            {
                if (this.SetValue<ContentAlignment>(Button.TextAlignProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the position of text and image relative to each other.</summary>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.Overlay"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values.</exception>
        [Localizable(false), SRCategory("CatAppearance"), DefaultValue(TextImageRelation.Overlay), SRDescription("ButtonTextImageRelationDescr"), ProxyBrowsable(true)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return this.GetValue<TextImageRelation>(Button.TextImageRelationProperty);
            }
            set
            {
                if (this.SetValue<TextImageRelation>(Button.TextImageRelationProperty, value))
                {
                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
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
                return this.ImageIndexInternal;
            }
            set
            {
                if (this.ImageIndexInternal != value)
                {
                    // Remove ImageKey value.
                    this.ImageKeyInternal = string.Empty;

                    //update ImageIndex value
                    this.ImageIndexInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the image index internal.
        /// </summary>
        /// <value>The image index internal.</value>
        internal int ImageIndexInternal
        {
            get
            {
                return this.GetValue<int>(Button.ImageIndexProperty);
            }
            set
            {
                this.SetValue<int>(Button.ImageIndexProperty, value);
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
        /// <filterpriority>2</filterpriority>
        [SRDescription("ButtonImageListDescr"), SRCategory("CatAppearance"), RefreshProperties(RefreshProperties.Repaint), DefaultValue((string)null)]
        public ImageList ImageList
        {
            get
            {
                return this.GetValue<ImageList>(Button.ImageListItemProperty);
            }
            set
            {
                if (this.SetValue<ImageList>(Button.ImageListItemProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>
        /// The size of the image.
        /// </value>
        public Size ImageSize
        {
            get
            {
				//If we have an image list get the size from the list
                ImageList objImageList = this.ImageList;
                if (objImageList != null)
                {
                    return objImageList.ImageSize;
                }

				// get image from the image size property
                return this.GetValue<Size>(ButtonBase.ImageSizeProperty);
            }
            set
            {
                if (this.ImageList != null)
                {
                    throw new ArgumentException("Cannot set image size when an ImageList is assigned.", "ImageSize");
                }
                
                if (this.SetValue<Size>(ButtonBase.ImageSizeProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the size of the image.
        /// </summary>
        protected virtual void ResetImageSize()
        {
            this.RemoveValue<Size>(ButtonBase.ImageSizeProperty);
        }



        /// <summary>
        /// Gets a value indicating whether this instance has image size.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has image size; otherwise, <c>false</c>.
        /// </value>
        protected bool HasImageSize
        {
            get
            {
                return this.ImageList != null || this.ContainsValue<Size>(ButtonBase.ImageSizeProperty);
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
                return this.ImageKeyInternal;
            }
            set
            {
                if (this.ImageKeyInternal != value)
                {
                    // Remove ImageIndex value.
                    this.ImageIndexInternal = -1;
                    
                    //update ImageKey value
                    this.ImageKeyInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the image key internal.
        /// </summary>
        /// <value>The image key internal.</value>
        internal string ImageKeyInternal
        {
            get
            {
                return this.GetValue<string>(Button.ImageKeyProperty);
            }
            set
            {
                this.SetValue<string>(Button.ImageKeyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SettingsBindable(true)]
#else
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SettingsBindable(true)]
#endif
        public override string Text
        {
            get
            {
                if(this.UseMnemonic)
                {
                    return GetCommandText(base.Text);
                }

                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;

    	            // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the flat style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(FlatStyle.Standard)]
        public FlatStyle FlatStyle
        {
            get
            {
                return this.GetValue<FlatStyle>(ButtonBase.FlatStyleProperty);
            }
            set
            {
                if (this.SetValue<FlatStyle>(ButtonBase.FlatStyleProperty, value))
                {
                    // Check value against FlatStyle enumeration
                    switch (value)
                    {
                        case FlatStyle.Flat:
                            this.CustomStyle = "F";
                            break;
                        default:
                            this.CustomStyle = string.Empty;
                            break;
                    }

                    this.Update();
                } 
            }
        }

        /// <summary>Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the control, denoting that the control text extends beyond the specified length of the control.</summary>
        /// <returns>true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is true.</returns>
        [SRDescription("ButtonAutoEllipsisDescr"), SRCategory("CatBehavior"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(false)]
        public bool AutoEllipsis
        {
            get
            {
                return this.GetState(ComponentState.AutoEllipsis);
            }
            set
            {
                if (this.SetStateWithCheck(ComponentState.AutoEllipsis, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value that indicates whether the control resizes based on its contents.</summary>
        /// <returns>true if the control automatically resizes based on its contents; otherwise, false. The default is true.</returns>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (value)
                {
                    this.AutoEllipsis = false;
                }
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
                return new Size(0x4b, 0x17);
            }
        }

        /// <summary>Gets the appearance of the border and the colors used to indicate check state and mouse state.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatButtonAppearance"></see> values.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), SRDescription("ButtonFlatAppearance")]
        public FlatButtonAppearance FlatAppearance
        {
            get
            {
                return new FlatButtonAppearance(this);
            }
        }

        /// <summary>Gets or sets a value that determines whether to use the compatible text rendering engine (GDI+) or not (GDI).</summary>
        /// <returns>true if the compatible text rendering engine (GDI+) is used; otherwise, false.</returns>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("UseCompatibleTextRenderingDescr")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseCompatibleTextRendering
        {
            get
            {
                return this.GetValue<bool>(ButtonBase.UseCompatibleTextRenderingProperty);
            }
            set
            {
                this.SetValue<bool>(ButtonBase.UseCompatibleTextRenderingProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether an ampersand (&amp;) is included in the text of the control.</summary>
        /// <returns>true if an ampersand is shown; otherwise, false. The default is true.</returns>
        [DefaultValue(true), SRCategory("CatAppearance"), SRDescription("ButtonUseMnemonicDescr")]
        public bool UseMnemonic
        {
            get
            {
                return this.GetValue<bool>(ButtonBase.UseMnemonicProperty);
            }
            set
            {
                if (this.SetValue<bool>(ButtonBase.UseMnemonicProperty, value))
                {
                    // Update control.
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value that determines if the background is drawn using visual styles, if supported.</summary>
        /// <returns>true if the background is drawn using visual styles; otherwise, false.</returns>
        [SRDescription("ButtonUseVisualStyleBackColorDescr"), SRCategory("CatAppearance"), DefaultValue(false)]
        public bool UseVisualStyleBackColor
        {
            get
            {
                return this.GetValue<bool>(ButtonBase.UseVisualStyleBackColorProperty);
            }
            set
            {
                if (this.SetValue<bool>(ButtonBase.UseVisualStyleBackColorProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlBackColorDescr"), SRCategory("CatAppearance")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (base.DesignMode)
                {
                    if (value != Color.Empty)
                    {
                        this.UseVisualStyleBackColor = false;
                    }
                }
                else
                {
                    this.UseVisualStyleBackColor = false;
                }
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether raise click event on mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportsKeyNavigation
        {
            get
            {
                return false;
            }
        }

        #endregion
    } 
    #endregion

    #region FlatButtonAppearance
    
    /// <summary>Provides properties that specify the appearance of <see cref="T:Gizmox.WebGUI.Forms.Button"></see> controls whose <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>.</summary>
    [TypeConverter(typeof(FlatButtonAppearanceConverter))]
    public class FlatButtonAppearance
    {

        /// <summary>
        /// 
        /// </summary>
        private ButtonBase mobjOwner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatButtonAppearance"/> class.
        /// </summary>
        /// <param name="objOwner">The owner.</param>
        internal FlatButtonAppearance(ButtonBase objOwner)
        {
            this.mobjOwner = objOwner;
        }

        /// <summary>Gets or sets the color of the border around the button.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the border around the button.</returns>
        [DefaultValue(typeof(Color), ""), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), SRCategory("CatAppearance"), SRDescription("ButtonBorderColorDescr")]
        public Color BorderColor
        {
            get
            {
                return mobjOwner.BorderColor;
            }
            set
            {
                mobjOwner.BorderColor = value;
            }
        }

        /// <summary>Gets or sets a value that specifies the size, in pixels, of the border around the button.</summary>
        /// <returns>An <see cref="T:System.Int32"></see> representing the size, in pixels, of the border around the button.</returns>
        [Browsable(true), DefaultValue(1), NotifyParentProperty(true), SRCategory("CatAppearance"), SRDescription("ButtonBorderSizeDescr"), EditorBrowsable(EditorBrowsableState.Always)]
        public int BorderSize
        {
            get
            {
                return mobjOwner.BorderWidth;
            }
            set
            {
                mobjOwner.BorderWidth = value;
            }
        }

        /// <summary>Gets or sets the color of the client area of the button when the button is checked and the mouse pointer is outside the bounds of the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
        [EditorBrowsable(EditorBrowsableState.Always), DefaultValue(typeof(Color), ""), NotifyParentProperty(true), SRDescription("ButtonCheckedBackColorDescr"), Browsable(true), SRCategory("CatAppearance")]
        public Color CheckedBackColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {

            }
        }

        /// <summary>Gets or sets the color of the client area of the button when the mouse is pressed within the bounds of the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
        [SRCategory("CatAppearance"), DefaultValue(typeof(Color), ""), Browsable(true), NotifyParentProperty(true), SRDescription("ButtonMouseDownBackColorDescr"), EditorBrowsable(EditorBrowsableState.Always)]
        public Color MouseDownBackColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {

            }
        }

        /// <summary>Gets or sets the color of the client area of the button when the mouse pointer is within the bounds of the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
        [Browsable(true), SRCategory("CatAppearance"), SRDescription("ButtonMouseOverBackColorDescr"), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true), DefaultValue(typeof(Color), "")]
        public Color MouseOverBackColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {

            }
        }
    } 

    #endregion

    #region FlatButtonAppearanceConverter

    /// <summary>
    /// 
    /// </summary>
    public class FlatButtonAppearanceConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="objDestinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return "";
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Gets a collection of properties for the type of object specified by the value parameter.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"/> that specifies the type of object to get the properties for.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"/> that will be used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for the component, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            return TypeDescriptor.GetProperties(objValue);
        }
    }
    
    #endregion 

    #region ButtonBaseRenderer Class

    /// <summary>
    /// 
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ButtonBaseRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonBaseRenderer"/> class.
        /// </summary>
        /// <param name="objButtonBase">The obj ButtonBase.</param>
        internal ButtonBaseRenderer(ButtonBase objButtonBase)
            : base(objButtonBase)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current ButtonBase
            ButtonBase objButtonBase = this.Control as ButtonBase;
            if (objButtonBase != null)
            {
                RenderButtonContent(objContext, objGraphics, objButtonBase, GetContentRegion(objButtonBase));
            }


        }

        /// <summary>
        /// Renders the content of the button.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objButtonBase">The button base.</param>
        /// <param name="objRegion">The region.</param>
        protected virtual void RenderButtonContent(ControlRenderingContext objContext, Graphics objGraphics, ButtonBase objButtonBase, Rectangle objRegion)
        {

            // Position the ButtonBase image
            switch (objButtonBase.TextImageRelation)
            {
                case TextImageRelation.ImageAboveText:
                    objRegion = DockInRegion(objRegion, DockStyle.Top, RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, GetHorizontalAlignment(objButtonBase.ImageAlign, true)));                    
                    break;
                case TextImageRelation.ImageBeforeText:
                    objRegion = DockInRegion(objRegion, DockStyle.Left, RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, GetVerticalAlignment(objButtonBase.ImageAlign, true)));
                    break;
                case TextImageRelation.TextAboveImage:
                    objRegion = DockInRegion(objRegion, DockStyle.Bottom, RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, GetHorizontalAlignment(objButtonBase.ImageAlign, false)));
                    break;
                case TextImageRelation.TextBeforeImage:
                    objRegion = DockInRegion(objRegion, DockStyle.Right, RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, GetVerticalAlignment(objButtonBase.ImageAlign, false)));
                    break;
                case TextImageRelation.Overlay:
                    RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, objButtonBase.ImageAlign);
                    break;
            }
            
            // Write the ButtonBase text
            RenderText(objContext, objGraphics, objButtonBase.Text, objButtonBase.Font, objButtonBase.ForeColor, objRegion, objButtonBase.TextAlign, true);

        }




    }

    #endregion
}
