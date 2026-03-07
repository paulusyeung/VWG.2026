using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Provides the highest level of shared resources 
    /// </summary>
    [Serializable()]
    [SkinDependency(typeof(LoadingSkin))]
    [SkinDependency(typeof(PopupsSkin))]
    [SkinDependency(typeof(TaskBarSkin))]
    [SkinDependency(typeof(ToolTipSkin))]
    public class CommonSkin : Skin
    {
        #region Members

        [NonSerialized()]
        private Font mobjDefaultFont = null;
        [NonSerialized()]
        private ArrowsScrollerProperties mobjArrowsScrollerProperties;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonSkin"/> class.
        /// </summary>
        public CommonSkin()
        {
            mobjArrowsScrollerProperties = new ArrowsScrollerProperties(this);
        }

        /// <summary>
        /// Filters the properties.
        /// </summary>
        /// <param name="objPropertyDescriptorCollection">The obj property descriptor collection.</param>
        /// <param name="attributes">The attributes.</param>
        public override PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection objPropertyDescriptorCollection, Attribute[] attributes)
        {
            // Filter SelectedIndicatorStyle and SelectedIndicatorSize (in the property grid)  from all inherited skins

            PropertyDescriptorCollection objFillteredCollection = base.FilterProperties(objPropertyDescriptorCollection, attributes);

            if (objFillteredCollection != null)
            {
                if (this.GetType() != typeof(CommonSkin))
                {
                    List<PropertyDescriptor> objFiltredDescriptors = new List<PropertyDescriptor>();

                    foreach (PropertyDescriptor objPropertyDescriptor in objFillteredCollection)
                    {
                        switch (objPropertyDescriptor.Name)
                        {
                            case "SelectedIndicatorStyle":
                            case "SelectedIndicatorSize":
                                break;
                            default:
                                objFiltredDescriptors.Add(objPropertyDescriptor);
                                break;
                        }
                    }

                    objFillteredCollection = new PropertyDescriptorCollection(objFiltredDescriptors.ToArray());
                }
            }

            return objFillteredCollection;
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Fonts"), SRDescription("ControlFontDescr")]
        public virtual Font Font
        {
            get
            {
                return this.GetAmbientValue<Font>("Font", this.DefaultFont);
            }
            set
            {
                this.SetValue("Font", value);
            }
        }

        /// <summary>
        /// Gets the default font.
        /// </summary>
        /// <value>The default font.</value>
        private Font DefaultFont
        {
            get
            {
                if (mobjDefaultFont == null)
                {
                    mobjDefaultFont = new Font("Tahoma", 8.25f);
                }

                return mobjDefaultFont;
            }
        }

        /// <summary>
        /// Gets the default color of the fore.
        /// </summary>
        /// <value>The default color of the fore.</value>
        protected virtual Color DefaultForeColor
        {
            get
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        private void ResetFont()
        {
            this.Reset("Font");
        }

        /// <summary>
        /// Gets the foreground.
        /// </summary>
        /// <value>The foreground.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ForegroundValue Foreground
        {
            get
            {
                ForegroundValue objForegroundValue = new ForegroundValue();
                objForegroundValue.ForeColor = this.ForeColor;
                return objForegroundValue;
            }
        }

        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
        /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Colors"), SRDescription("ControlForeColorDescr")]
#if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        public virtual Color ForeColor
        {
            get
            {
                return this.GetAmbientValue<Color>("ForeColor", this.DefaultForeColor);
            }
            set
            {
                this.SetValue("ForeColor", value);
            }
        }

        /// <summary>
        /// Gets the loading animation box.
        /// </summary>
        /// <value>The loading animation box.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue LoadingAnimationBox
        {
            get
            {
                if (this.Owner != null)
                {
                    LoadingSkin objLoadingSkin = SkinFactory.GetSkin(this.Owner, typeof(LoadingSkin)) as LoadingSkin;
                    if (objLoadingSkin != null)
                    {
                        return objLoadingSkin.LoadingAnimationStyle;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the loading animation image.
        /// </summary>
        /// <value>
        /// The loading animation image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageResourceReference LoadingAnimationImage
        {
            get
            {
                if (this.Owner != null)
                {
                    StyleValue objLoadingSkinStyle = this.LoadingAnimationBox;
                    if (objLoadingSkinStyle != null)
                    {
                        return objLoadingSkinStyle.BackgroundImage;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the box shadow popup offset.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BoxShadowPopupOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    PopupsSkin objPopupsSkin = SkinFactory.GetSkin(this.Owner, typeof(PopupsSkin)) as PopupsSkin;
                    if (objPopupsSkin != null)
                    {
                        return objPopupsSkin.BoxShadowPopupOffset;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Resets the fore color.
        /// </summary>
        private void ResetForeColor()
        {
            this.Reset("ForeColor");
        }

        /// <summary>
        /// Gets the loading template.
        /// </summary>
        /// <value>The loading template.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference LoadingTemplate
        {
            get
            {
                return new TextResourceReference(typeof(LoadingSkin), "Loading.htm");
            }
        }


        /// <summary>
        /// Gets the loading animation.
        /// </summary>
        /// <value>
        /// The loading animation.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference LoadingAnimationHtml
        {
            get
            {
                return new TextResourceReference(typeof(LoadingSkin), "LoadingAnimation.htm");
            }
        }

        /// Gets the task bar frame.
        /// </summary>
        /// <value>The task bar template.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference TaskBarTemplate
        {
            get
            {
                return new TextResourceReference(typeof(TaskBarSkin), "TaskBarTemplate.htm");
            }
        }

        /// <summary>
        /// Gets the web set style function.
        /// </summary>
        /// <value>The web set style function.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference WebSetStyleFunction
        {
            get
            {
                return new TextResourceReference(typeof(CommonSkin), "Common.Web.SetStyle.js");
            }
        }



        /// <summary>
        /// Gets the task bar item content class.
        /// </summary>
        /// <value>The task bar item content class.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public CssClassMemberReference TaskBarItemContentClass
        {
            get
            {
                return new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemContent");
            }
        }

        /// <summary>
        /// Gets the task bar item image class.
        /// </summary>
        /// <value>The task bar item image class.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public CssClassMemberReference TaskBarItemImageClass
        {
            get
            {
                return new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemImage");
            }
        }

        /// <summary>
        /// Gets the task bar item label class.
        /// </summary>
        /// <value>The task bar item label class.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public CssClassMemberReference TaskBarItemLabelClass
        {
            get
            {
                return new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemLabel");
            }
        }


        /// <summary>
        /// Gets the modal window style.
        /// </summary>
        /// <value>The modal window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue WindowModalMaskStyle
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return objFormSkin.WindowModalMaskStyle;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the dialog window height offset.
        /// </summary>
        /// <value>The dialog window height offset.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowHeightOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return (objFormSkin.TopDialogWindowFrameHeight + objFormSkin.BottomDialogWindowFrameHeight);
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the dialog window width offset.
        /// </summary>
        /// <value>The dialog window width offset.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowWidthOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return (objFormSkin.LeftDialogWindowFrameWidth + objFormSkin.RightDialogWindowFrameWidth);
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the tool window height offset.
        /// </summary>
        /// <value>The tool window height offset.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ToolWindowHeightOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return (objFormSkin.TopToolWindowFrameHeight + objFormSkin.BottomToolWindowFrameHeight);
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the tool window width offset.
        /// </summary>
        /// <value>The tool window width offset.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ToolWindowWidthOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return (objFormSkin.LeftToolWindowFrameWidth + objFormSkin.RightToolWindowFrameWidth);
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the transparent modal window mask opacity.
        /// </summary>
        /// <value>The transparent modal window mask opacity.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OpacityValue WindowModalTransparentMaskOpacity
        {
            get
            {
                return new OpacityValue(1);
            }
        }


        /// <summary>
        /// Gets the modal window mask opacity.
        /// </summary>
        /// <value>The modal window mask opacity.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OpacityValue WindowModalMaskOpacity
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;

                    if (objFormSkin != null)
                    {
                        return objFormSkin.WindowModalMaskOpacity;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the width of the minimized MDI form.
        /// </summary>
        /// <value>The width of the minimized MDI form.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinimizedMdiFormWidth
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return objFormSkin.MinimizedMdiFormWidth;
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets the height of the minimized MDI form.
        /// </summary>
        /// <value>The height of the minimized MDI form.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinimizedMdiFormHeight
        {
            get
            {
                if (this.Owner != null)
                {
                    FormSkin objFormSkin = SkinFactory.GetSkin(this.Owner, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        return objFormSkin.MinimizedMdiFormHeight;
                    }
                }
                return 0;
            }
        }


        /// <summary>
        /// Gets or sets the layout padding.
        /// </summary>
        /// <value>
        /// The layout padding.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SRDescription("The default layout padding.")]
        public int ButtonImageTextGap
        {
            get
            {
                return this.GetValue<int>("ButtonImageTextGap", 2);
            }
            set
            {
                this.SetValue("ButtonImageTextGap", value);
            }
        }




        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <param name="objFrameStyleValue">The frame style value.</param>
        /// <param name="enmFrameEdge">The frame edge.</param>
        /// <returns></returns>
        protected internal int GetFrameEdgeSize(FrameStyleValue objFrameStyleValue, FrameEdge enmFrameEdge)
        {
            int int1;
            int int2;
            int int3;

            // If Bottom edge
            if (enmFrameEdge == FrameEdge.Bottom)
            {
                int1 = this.GetImageHeight(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
                int2 = this.GetImageHeight(objFrameStyleValue.BottomStyle.BackgroundImage);
                int3 = this.GetImageHeight(objFrameStyleValue.RightBottomStyle.BackgroundImage);
            }

            // If Left edge
            else if (enmFrameEdge == FrameEdge.Left)
            {
                int1 = this.GetImageWidth(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
                int2 = this.GetImageWidth(objFrameStyleValue.LeftStyle.BackgroundImage);
                int3 = this.GetImageWidth(objFrameStyleValue.LeftTopStyle.BackgroundImage);
            }

            // If Right edge
            else if (enmFrameEdge == FrameEdge.Right)
            {
                int1 = this.GetImageWidth(objFrameStyleValue.RightTopStyle.BackgroundImage);
                int2 = this.GetImageWidth(objFrameStyleValue.RightStyle.BackgroundImage);
                int3 = this.GetImageWidth(objFrameStyleValue.RightBottomStyle.BackgroundImage);
            }

            // If Top edge
            else if (enmFrameEdge == FrameEdge.Top)
            {
                int1 = this.GetImageHeight(objFrameStyleValue.LeftTopStyle.BackgroundImage);
                int2 = this.GetImageHeight(objFrameStyleValue.TopStyle.BackgroundImage);
                int3 = this.GetImageHeight(objFrameStyleValue.RightTopStyle.BackgroundImage);
            }
            else
            {
                return 0;
            }

            // Return the max of the three images sizes
            return Math.Max(int1, Math.Max(int2, int3));
        }

        /// <summary>
        /// Specifies one of four Frame edges
        /// </summary>
        protected internal enum FrameEdge : byte
        {

            /// <summary>
            /// The control's frame Top edge. 
            /// </summary>
            Top = 1,
            /// <summary>
            /// The control's frame Right edge.
            /// </summary>
            Right = 2,
            /// <summary>
            /// The control's frame Bottom edge.
            /// </summary>
            Bottom = 3,
            /// <summary>
            /// The control's frame Left edge.
            /// </summary>
            Left = 4
        }

        #region Arrow scrollers

        /// <summary>
        /// Gets the arrows scroll properties.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ArrowsScrollerProperties ArrowsScrollProperties
        {
            get { return mobjArrowsScrollerProperties; }
        }

        /// <summary>
        /// Gets the arrow scroller left normal style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerLeftNormalStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerLeftNormalStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller left hover style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerLeftHoverStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerLeftHoverStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller left pressed style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerLeftPressedStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerLeftPressedStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller left disabled style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerLeftDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerLeftDisabledStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller top normal style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerTopNormalStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerTopNormalStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller top hover style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerTopHoverStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerTopHoverStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller top pressed style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerTopPressedStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerTopPressedStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller top disabled style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerTopDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerTopDisabledStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller right normal style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerRightNormalStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerRightNormalStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller right hover style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerRightHoverStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerRightHoverStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller right pressed style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerRightPressedStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerRightPressedStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller right disabled style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerRightDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerRightDisabledStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller bottom normal style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerBottomNormalStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerBottomNormalStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller bottom hover style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerBottomHoverStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerBottomHoverStyle");
            }
        }
        /// <summary>
        /// Gets the arrow scroller bottom pressed style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerBottomPressedStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerBottomPressedStyle");
            }
        }

        /// <summary>
        /// Gets the arrow scroller bottom disabled style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ArrowScrollerBottomDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ArrowScrollerBottomDisabledStyle");
            }
        }

        /// <summary>
        /// Gets or sets the horizontal hover speed.
        /// </summary>
        /// <value>
        /// The horizontal hover speed.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HorizontalHoverSpeed
        {
            get
            {
                return GetValue<int>("ArrowsHorizontalHoverSpeed", 50);
            }
            set
            {
                this.SetValue("ArrowsHorizontalHoverSpeed", value);
            }
        }

        /// <summary>
        /// Gets or sets the horizontal down speed.
        /// </summary>
        /// <value>
        /// The horizontal down speed.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HorizontalDownSpeed
        {
            get
            {
                return GetValue<int>("ArrowsHorizontalDownSpeed", 20);
            }
            set
            {
                this.SetValue("ArrowsHorizontalDownSpeed", value);
            }
        }

        /// <summary>
        /// Gets or sets the vertical hover speed.
        /// </summary>
        /// <value>
        /// The vertical hover speed.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VerticalHoverSpeed
        {
            get
            {
                return GetValue<int>("ArrowsHorizontalHoverSpeed", 50);
            }
            set
            {
                this.SetValue("ArrowsHorizontalHoverSpeed", value);
            }
        }

        /// <summary>
        /// Gets or sets the vertical down speed.
        /// </summary>
        /// <value>
        /// The vertical down speed.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VerticalDownSpeed
        {
            get
            {
                return GetValue<int>("ArrowsHorizontalDownSpeed", 20);
            }
            set
            {
                this.SetValue("ArrowsHorizontalDownSpeed", value);
            }
        }

        /// <summary>
        /// Gets the arrow style value.
        /// </summary>
        /// <param name="strSide">The STR side.</param>
        /// <param name="strStyle">The STR style.</param>
        /// <returns></returns>
        private StyleValue GetArrowStyleValue(string strSide, string strStyle)
        {
            return new StyleValue(this, string.Format("ArrowScroller{0}{1}Style", strSide, strStyle));
        }

        /// <summary>
        /// Gets the arrow thickness.
        /// </summary>
        /// <param name="mstrSide">The MSTR side.</param>
        /// <returns></returns>
        private int GetArrowThickness(string mstrSide)
        {
            return this.GetValue<int>(string.Format("Arrow{0}Thickness", mstrSide), mstrSide == "Left" || mstrSide == "Right" ? GetImageWidth(GetArrowStyleValue(mstrSide, "Normal").BackgroundImage) : GetImageHeight(GetArrowStyleValue(mstrSide, "Normal").BackgroundImage));
        }

        /// <summary>
        /// Sets the arrow thickness.
        /// </summary>
        /// <param name="mstrSide">The MSTR side.</param>
        /// <param name="objValue">The obj value.</param>
        private void SetArrowThickness(string mstrSide, int objValue)
        {
            this.SetValue(string.Format("Arrow{0}Thickness", mstrSide), objValue);
        }

        /// <summary>
        /// Gets the arrow top thickness.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ArrowTopThickness
        {
            get
            {
                return GetArrowThickness("Top");
            }
        }
        /// <summary>
        /// Gets the arrow right thickness.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ArrowRightThickness
        {
            get
            {
                return GetArrowThickness("Right");
            }
        }
        /// <summary>
        /// Gets the arrow bottom thickness.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ArrowBottomThickness
        {
            get
            {
                return GetArrowThickness("Bottom");
            }
        }

        /// <summary>
        /// Gets the arrow left thickness.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ArrowLeftThickness
        {
            get
            {
                return GetArrowThickness("Left");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public class ArrowsScrollerProperties
        {
            private ArrowSideProperties mobjTop;
            private ArrowSideProperties mobjRight;
            private ArrowSideProperties mobjBottom;
            private ArrowSideProperties mobjLeft;
            private CommonSkin mobjCommonSkin;


            /// <summary>
            /// Initializes a new instance of the <see cref="ArrowsScrollerProperties"/> class.
            /// </summary>
            /// <param name="objCommonSkin">The obj common skin.</param>
            public ArrowsScrollerProperties(CommonSkin objCommonSkin)
            {
                if (objCommonSkin == null)
                {
                    throw new ArgumentNullException("objCommonSkin");
                }

                this.mobjCommonSkin = objCommonSkin;
                mobjTop = new ArrowSideProperties(objCommonSkin, "Top");
                mobjRight = new ArrowSideProperties(objCommonSkin, "Right");
                mobjBottom = new ArrowSideProperties(objCommonSkin, "Bottom");
                mobjLeft = new ArrowSideProperties(objCommonSkin, "Left");
            }

            /// <summary>
            /// Gets the top.
            /// </summary>
            public ArrowSideProperties Top
            {
                get { return mobjTop; }
            }

            /// <summary>
            /// Gets the right.
            /// </summary>
            public ArrowSideProperties Right
            {
                get { return mobjRight; }
            }

            /// <summary>
            /// Gets the bottom.
            /// </summary>
            public ArrowSideProperties Bottom
            {
                get { return mobjBottom; }
            }

            /// <summary>
            /// Gets the left.
            /// </summary>
            public ArrowSideProperties Left
            {
                get { return mobjLeft; }
            }

            /// <summary>
            /// Gets or sets the horizontal hover speed.
            /// </summary>
            /// <value>
            /// The horizontal hover speed.
            /// </value>
            public int HorizontalHoverSpeed
            {
                get
                {
                    return mobjCommonSkin.HorizontalHoverSpeed;
                }
                set
                {
                    mobjCommonSkin.HorizontalHoverSpeed = value;
                }
            }

            /// <summary>
            /// Gets or sets the horizontal down speed.
            /// </summary>
            /// <value>
            /// The horizontal down speed.
            /// </value>
            public int HorizontalDownSpeed
            {
                get
                {
                    return mobjCommonSkin.HorizontalDownSpeed;
                }
                set
                {
                    mobjCommonSkin.HorizontalDownSpeed = value;
                }
            }

            /// <summary>
            /// Gets or sets the vertical hover speed.
            /// </summary>
            /// <value>
            /// The vertical hover speed.
            /// </value>
            public int VerticalHoverSpeed
            {
                get
                {
                    return mobjCommonSkin.VerticalHoverSpeed;
                }
                set
                {
                    mobjCommonSkin.VerticalHoverSpeed = value;
                }
            }

            /// <summary>
            /// Gets or sets the vertical down speed.
            /// </summary>
            /// <value>
            /// The vertical down speed.
            /// </value>
            public int VerticalDownSpeed
            {
                get
                {
                    return mobjCommonSkin.VerticalDownSpeed;
                }
                set
                {
                    mobjCommonSkin.VerticalDownSpeed = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
            public class ArrowSideProperties
            {
                private CommonSkin mobjCommonSkin;
                private string mstrSide;

                /// <summary>
                /// Initializes a new instance of the <see cref="ArrowSideProperties"/> class.
                /// </summary>
                /// <param name="objCommonSkin">The obj common skin.</param>
                /// <param name="strSide">The STR side.</param>
                public ArrowSideProperties(CommonSkin objCommonSkin, string strSide)
                {
                    if (string.IsNullOrEmpty(strSide))
                    {
                        throw new ArgumentException(strSide);
                    }

                    this.mstrSide = strSide;
                    this.mobjCommonSkin = objCommonSkin;
                }

                /// <summary>
                /// Gets or sets the thickness.
                /// </summary>
                /// <value>
                /// The thickness.
                /// </value>
                public int Thickness
                {
                    get
                    {
                        return mobjCommonSkin.GetArrowThickness(mstrSide);
                    }
                    set
                    {
                        mobjCommonSkin.SetArrowThickness(mstrSide, value);
                    }
                }

                /// <summary>
                /// Gets the normal style.
                /// </summary>
                public StyleValue NormalStyle
                {
                    get
                    {
                        return mobjCommonSkin.GetArrowStyleValue(mstrSide, "Normal");
                    }
                }

                /// <summary>
                /// Gets the hover style.
                /// </summary>
                public StyleValue HoverStyle
                {
                    get
                    {
                        return mobjCommonSkin.GetArrowStyleValue(mstrSide, "Hover");
                    }
                }

                /// <summary>
                /// Gets the pressed style.
                /// </summary>
                public StyleValue PressedStyle
                {
                    get
                    {
                        return mobjCommonSkin.GetArrowStyleValue(mstrSide, "Pressed");
                    }
                }

                /// <summary>
                /// Gets the disabled style.
                /// </summary>
                public StyleValue DisabledStyle
                {
                    get
                    {
                        return mobjCommonSkin.GetArrowStyleValue(mstrSide, "Disabled");
                    }
                }
            }
        }

        #endregion

        #region SelectedIndicator


        /// <summary>
        /// Gets the selected indicator style.
        /// </summary>
        /// <value>
        /// The selected indicator style.
        /// </value>
        [Category("States"), Description("The selected indicator style.")]
        public SelectedIndicatorStyleValue SelectedIndicatorStyle
        {
            get
            {
                return new SelectedIndicatorStyleValue(
                    this.LeftBottomSelectedIndicatorStyle,
                    this.LeftSelectedIndicatorStyle,
                    this.LeftTopSelectedIndicatorStyle,
                    this.TopSelectedIndicatorStyle,
                    this.RightTopSelectedIndicatorStyle,
                    this.RightSelectedIndicatorStyle,
                    this.RightBottomSelectedIndicatorStyle,
                    this.BottomSelectedIndicatorStyle);
            }
        }

        /// <summary>
        /// Gets the left bottom selected indicator style.
        /// </summary>
        /// <value>
        /// The left bottom selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue LeftBottomSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "LeftBottomSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the left bottom selected indicator style.
        /// </summary>
        internal void ResetLeftBottomSelectedIndicatorStyle()
        {
            this.Reset("LeftBottomSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the left selected indicator style.
        /// </summary>
        /// <value>
        /// The left selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue LeftSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "LeftSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the left selected indicator style.
        /// </summary>
        internal void ResetLeftSelectedIndicatorStyle()
        {
            this.Reset("LeftSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the left top selected indicator style.
        /// </summary>
        /// <value>
        /// The left top selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue LeftTopSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "LeftTopSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the left top selected indicator style.
        /// </summary>
        internal void ResetLeftTopSelectedIndicatorStyle()
        {
            this.Reset("LeftTopSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the top selected indicator style.
        /// </summary>
        /// <value>
        /// The top selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue TopSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "TopSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the top selected indicator style.
        /// </summary>
        internal void ResetTopSelectedIndicatorStyle()
        {
            this.Reset("TopSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the right top selected indicator style.
        /// </summary>
        /// <value>
        /// The right top selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue RightTopSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "RightTopSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the right top selected indicator style.
        /// </summary>
        internal void ResetRightTopSelectedIndicatorStyle()
        {
            this.Reset("RightTopSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the right selected indicator style.
        /// </summary>
        /// <value>
        /// The right selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue RightSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "RightSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the right selected indicator style.
        /// </summary>
        internal void ResetRightSelectedIndicatorStyle()
        {
            this.Reset("RightSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the right bottom selected indicator style.
        /// </summary>
        /// <value>
        /// The right bottom selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue RightBottomSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "RightBottomSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the right bottom selected indicator style.
        /// </summary>
        internal void ResetRightBottomSelectedIndicatorStyle()
        {
            this.Reset("ResetRightBottomSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the bottom selected indicator style.
        /// </summary>
        /// <value>
        /// The bottom selected indicator style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue BottomSelectedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "BottomSelectedIndicatorStyle");
            }
        }

        /// <summary>
        /// Resets the bottom selected indicator style.
        /// </summary>
        internal void ResetBottomSelectedIndicatorStyle()
        {
            this.Reset("BottomSelectedIndicatorStyle");
        }

        /// <summary>
        /// Gets the size of the selected indicator.
        /// </summary>
        /// <value>
        /// The size of the selected indicator.
        /// </value>
        [Category("Sizes"), Description("The selected indicator style.")]
        public SelectedIndicatorSizeValue SelectedIndicatorSize
        {
            get
            {
                return new SelectedIndicatorSizeValue(this);
            }
        }

        /// <summary>
        /// Gets or sets the size of the left bottom selected indicator.
        /// </summary>
        /// <value>
        /// The size of the left bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size LeftBottomSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("LeftBottomSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("LeftBottomSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the left bottom selected indicator.
        /// </summary>
        internal void ResetLeftBottomSelectedIndicatorSize()
        {
            this.Reset("LeftBottomSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the left selected indicator.
        /// </summary>
        /// <value>
        /// The size of the left selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size LeftSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("LeftSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("LeftSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the left selected indicator.
        /// </summary>
        internal void ResetLeftSelectedIndicatorSize()
        {
            this.Reset("LeftSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the left top selected indicator.
        /// </summary>
        /// <value>
        /// The size of the left top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size LeftTopSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("LeftTopSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("LeftTopSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the left top selected indicator.
        /// </summary>
        internal void ResetLeftTopSelectedIndicatorSize()
        {
            this.Reset("LeftTopSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the top selected indicator.
        /// </summary>
        /// <value>
        /// The size of the top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size TopSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("TopSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("TopSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the top selected indicator.
        /// </summary>
        internal void ResetTopSelectedIndicatorSize()
        {
            this.Reset("TopSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the right top selected indicator.
        /// </summary>
        /// <value>
        /// The size of the right top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size RightTopSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("RightTopSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("RightTopSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the right top selected indicator.
        /// </summary>
        internal void ResetRightTopSelectedIndicatorSize()
        {
            this.Reset("RightTopSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the right selected indicator.
        /// </summary>
        /// <value>
        /// The size of the right selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size RightSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("RightSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("RightSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the right selected indicator.
        /// </summary>
        internal void ResetRightSelectedIndicatorSize()
        {
            this.Reset("RightSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the right bottom selected indicator.
        /// </summary>
        /// <value>
        /// The size of the right bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size RightBottomSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("RightBottomSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("RightBottomSelectedIndicatorSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the right bottom selected indicator.
        /// </summary>
        internal void ResetRightBottomSelectedIndicatorSize()
        {
            this.Reset("RightBottomSelectedIndicatorSize");
        }

        /// <summary>
        /// Gets or sets the size of the bottom selected indicator.
        /// </summary>
        /// <value>
        /// The size of the bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size BottomSelectedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("BottomSelectedIndicatorSize", new Size(4, 4));
            }
            set
            {
                this.SetValue("BottomSelectedIndicatorSize", value);
            }
        }


        /// <summary>
        /// Resets the size of the bottom selected indicator.
        /// </summary>
        internal void ResetBottomSelectedIndicatorSize()
        {
            this.Reset("BottomSelectedIndicatorSize");
        }


        /// <summary>
        /// Gets the height of the right bottom selected indicator.
        /// </summary>
        /// <value>
        /// The height of the right bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightBottomSelectedIndicatorHeight
        {
            get
            {
                return this.RightBottomSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the right bottom selected indicator.
        /// </summary>
        /// <value>
        /// The width of the right bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightBottomSelectedIndicatorWidth
        {
            get
            {
                return this.RightBottomSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the left bottom selected indicator.
        /// </summary>
        /// <value>
        /// The height of the left bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftBottomSelectedIndicatorHeight
        {
            get
            {
                return this.LeftBottomSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the left bottom selected indicator.
        /// </summary>
        /// <value>
        /// The width of the left bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftBottomSelectedIndicatorWidth
        {
            get
            {
                return this.LeftBottomSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the left top selected indicator.
        /// </summary>
        /// <value>
        /// The height of the left top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftTopSelectedIndicatorHeight
        {
            get
            {
                return this.LeftTopSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the left top selected indicator.
        /// </summary>
        /// <value>
        /// The width of the left top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftTopSelectedIndicatorWidth
        {
            get
            {
                return this.LeftTopSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the right top selected indicator.
        /// </summary>
        /// <value>
        /// The height of the right top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightTopSelectedIndicatorHeight
        {
            get
            {
                return this.RightTopSelectedIndicatorSize.Height;
            }
        }


        /// <summary>
        /// Gets the width of the right top selected indicator.
        /// </summary>
        /// <value>
        /// The width of the right top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightTopSelectedIndicatorWidth
        {
            get
            {
                return this.RightTopSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the bottom selected indicator.
        /// </summary>
        /// <value>
        /// The height of the bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomSelectedIndicatorHeight
        {
            get
            {
                return this.BottomSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the bottom selected indicator.
        /// </summary>
        /// <value>
        /// The width of the bottom selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomSelectedIndicatorWidth
        {
            get
            {
                return this.BottomSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the left selected indicator.
        /// </summary>
        /// <value>
        /// The height of the left selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftSelectedIndicatorHeight
        {
            get
            {
                return this.LeftSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the left selected indicator.
        /// </summary>
        /// <value>
        /// The width of the left selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftSelectedIndicatorWidth
        {
            get
            {
                return this.LeftSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the top selected indicator.
        /// </summary>
        /// <value>
        /// The height of the top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopSelectedIndicatorHeight
        {
            get
            {
                return this.TopSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the top selected indicator.
        /// </summary>
        /// <value>
        /// The width of the top selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopSelectedIndicatorWidth
        {
            get
            {
                return this.TopSelectedIndicatorSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the right selected indicator.
        /// </summary>
        /// <value>
        /// The height of the right selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightSelectedIndicatorHeight
        {
            get
            {
                return this.RightSelectedIndicatorSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the right selected indicator.
        /// </summary>
        /// <value>
        /// The width of the right selected indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightSelectedIndicatorWidth
        {
            get
            {
                return this.RightSelectedIndicatorSize.Width;
            }
        }

        #endregion SelectedIndicator

        #region MarkedIndication


        /// <summary>
        /// Gets the marked indicator style.
        /// </summary>
        /// <value>
        /// The marked indicator style.
        /// </value>
        public StyleValue MarkedIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "MarkedIndicatorStyle");
            }
        }


        /// <summary>
        /// Resets the marked indicator style.
        /// </summary>
        internal void ResetMarkedIndicatorStyle()
        {
            this.Reset("MarkedIndicatorStyle");
        }


        /// <summary>
        /// Gets the height of the marked indicator.
        /// </summary>
        /// <value>
        /// The height of the marked indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MarkedIndicatorHeight
        {
            get
            {
                return this.MarkedIndicatorSize.Height;
            }
        }


        /// <summary>
        /// Gets the width of the marked indicator.
        /// </summary>
        /// <value>
        /// The width of the marked indicator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MarkedIndicatorWidth
        {
            get
            {
                return this.MarkedIndicatorSize.Width;
            }
        }


        /// <summary>
        /// Gets or sets the size of the marked indicator.
        /// </summary>
        /// <value>
        /// The size of the marked indicator.
        /// </value>
        public Size MarkedIndicatorSize
        {
            get
            {
                return this.GetValue<Size>("MarkedIndicatorSize", new Size(16, 16));
            }
            set
            {
                this.SetValue("MarkedIndicatorSize", value);
            }
        }


        /// <summary>
        /// Resets the size of the marked indicator.
        /// </summary>
        internal void ResetMarkedIndicatorSize()
        {
            this.Reset("MarkedIndicatorSize");
        }

        #endregion
    }
}