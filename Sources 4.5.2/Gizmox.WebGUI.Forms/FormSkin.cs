using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Form Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(Form)), Serializable()]
    public class FormSkin : ContainerControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region DialogWindow Style

        /// <summary>
        /// Gets the dialog window modal style.
        /// </summary>
        /// <value>The dialog window modal style.</value>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("States"), SRDescription("WindowModalMaskOpacityDescr")]
        public virtual StyleValue WindowModalMaskStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "WindowModalMaskStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the back color opacity.
        /// </summary>
        /// <value>The back color opacity.</value>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Colors"), SRDescription("WindowModalMaskOpacityDescr")]
        public OpacityValue WindowModalMaskOpacity
        {
            get
            {
                return this.GetValue<OpacityValue>("WindowModalMaskOpacity", new OpacityValue(this.DefaultWindowModalMaskOpacity));
            }
            set
            {
                if (value.Opacity >= 0 && value.Opacity <= 100)
                {
                    this.SetValue("WindowModalMaskOpacity", value);
                }
                else
                {
                    throw new Exception("You must supply values between 1 and 100.");
                }
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetWindowModalMaskOpacity()
        {
            this.Reset("WindowModalMaskOpacity");
        }

        /// <summary>
        /// Gets the size of the default minimized MDI form.
        /// </summary>
        /// <value>The size of the default minimized MDI form.</value>
        protected virtual Size DefaultMinimizedMdiFormSize
        {
            get
            {
                return new Size(200, 60);
            }
        }
        
        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultWindowModalMaskOpacity
        {
            get
            {
                return 50;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left dialog window frame.
        /// </summary>
        /// <value>The width of the left dialog window frame.</value>
        [Category("Sizes"), Description("The width of the left dialog window frame.")]
        public virtual int LeftDialogWindowFrameWidth
        {
            get
            {
                return this.GetValue<int>("LeftDialogWindowFrameWidth", this.GetImageWidth(this.ActiveDialogWindowStyle.LeftStyle.BackgroundImage, this.DefaultLeftDialogWindowFrameWidth));
            }
            set
            {
                this.SetValue("LeftDialogWindowFrameWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the left dialog window frame.
        /// </summary>
        internal void ResetLeftDialogWindowFrameWidth()
        {
            this.Reset("LeftDialogWindowFrameWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultLeftDialogWindowFrameWidth
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets the width of the right dialog window frame.
        /// </summary>
        /// <value>The width of the right dialog window frame.</value>
        [Category("Sizes"), Description("The width of the right dialog window frame.")]
        public virtual int RightDialogWindowFrameWidth
        {
            get
            {
                return this.GetValue<int>("RightDialogWindowFrameWidth", this.GetImageWidth(this.ActiveDialogWindowStyle.RightStyle.BackgroundImage, this.DefaultRightDialogWindowFrameWidth));
            }
            set
            {
                this.SetValue("RightDialogWindowFrameWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the right dialog window frame.
        /// </summary>
        internal void ResetRightDialogWindowFrameWidth()
        {
            this.Reset("RightDialogWindowFrameWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultRightDialogWindowFrameWidth
        {
            get
            {
                return 4;
            }
        }


        /// <summary>
        /// Gets or sets the height of the top dialog window frame.
        /// </summary>
        /// <value>The height of the top dialog window frame.</value>
        [Category("Sizes"), Description("The height of the top dialog window frame.")]
        public virtual int TopDialogWindowFrameHeight
        {
            get
            {
                return this.GetValue<int>("TopDialogWindowFrameHeight", this.GetImageHeight(this.ActiveDialogWindowStyle.TopStyle.BackgroundImage, this.DefaultTopDialogWindowFrameHeight));
            }
            set
            {
                this.SetValue("TopDialogWindowFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the top dialog window frame.
        /// </summary>
        internal void ResetTopDialogWindowFrameHeight()
        {
            this.Reset("TopDialogWindowFrameHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultTopDialogWindowFrameHeight
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets the height of the bottom dialog window frame.
        /// </summary>
        /// <value>The height of the bottom dialog window frame.</value>
        [Category("Sizes"), Description("The height of the bottom dialog window frame.")]
        public virtual int BottomDialogWindowFrameHeight
        {
            get
            {
                return this.GetValue<int>("BottomDialogWindowFrameHeight", this.GetImageHeight(this.ActiveDialogWindowStyle.BottomStyle.BackgroundImage, this.DefaultBottomDialogWindowFrameHeight));
            }
            set
            {
                this.SetValue("BottomDialogWindowFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the bottom dialog window frame.
        /// </summary>
        internal void ResetBottomDialogWindowFrameHeight()
        {
            this.Reset("BottomDialogWindowFrameHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultBottomDialogWindowFrameHeight
        {
            get
            {
                return 4;
            }
        }


        #region ActiveDialogWindow Style



        /// <summary>
        /// Gets the normal active dialog style.
        /// </summary>
        /// <value>The normal active dialog style.</value>
        [Category("States"), Description("The normal active dialog style.")]
        public virtual OverlayedFrameStyleValue ActiveDialogWindowStyle
        {
            get
            {
                return new OverlayedFrameStyleValue(
                    this.LeftBottomActiveDialogWindowStyle,
                    this.LeftActiveDialogWindowStyle,
                    this.LeftTopActiveDialogWindowStyle,
                    this.TopActiveDialogWindowStyle,
                    this.RightTopActiveDialogWindowStyle,
                    this.RightActiveDialogWindowStyle,
                    this.RightBottomActiveDialogWindowStyle,
                    this.BottomActiveDialogWindowStyle,
                    this.CenterActiveDialogWindowStyle,
                    this.LeftOverlayActiveDialogWindowStyle,
                    this.RightOverlayActiveDialogWindowStyle);
            }
        }

        /// <summary>
        /// Gets the dialog window captions style.
        /// </summary>
        /// <value>The dialog window captions style.</value>
        [Category("States"), Description("The dialog window captions style.")]
        public virtual StyleValue DialogWindowCaptionStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCaptionStyle");

                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window buttons style.
        /// </summary>
        /// <value>The dialog window buttons style.</value>
        [Category("States"), Description("The dialog window buttons style.")]
        public virtual StyleValue DialogWindowButtonsStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowButtonsStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button normal style.
        /// </summary>
        /// <value>The dialog window close button normal style.</value>
        [Category("States"), SRDescription("The dialog window close button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowCloseButtonNormalStyleLTR, this.DialogWindowCloseButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window close button normal style LTR.
        /// </summary>
        /// <value>The dialog window close button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button normal style RTL.
        /// </summary>
        /// <value>The dialog window close button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button hover style.
        /// </summary>
        /// <value>The dialog window close button hover style.</value>
        [Category("States"), SRDescription("The dialog window hover close button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowCloseButtonHoverStyleLTR, this.DialogWindowCloseButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window close button hover style LTR.
        /// </summary>
        /// <value>The dialog window close button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonHoverStyleLTR", this.DialogWindowCloseButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button hover style RTL.
        /// </summary>
        /// <value>The dialog window close button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonHoverStyleRTL", this.DialogWindowCloseButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button disabled style.
        /// </summary>
        /// <value>The dialog window close button disabled style.</value>
        [Category("States"), SRDescription("The dialog window disabled close button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowCloseButtonDisabledStyleLTR, this.DialogWindowCloseButtonDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window close button disabled style RTL.
        /// </summary>
        /// <value>The dialog window close button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonDisabledStyleRTL", this.DialogWindowCloseButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window close button disabled style LTR.
        /// </summary>
        /// <value>The dialog window close button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowCloseButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowCloseButtonDisabledStyleLTR", this.DialogWindowCloseButtonNormalStyleLTR);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the size of the dialog window close button.
        /// </summary>
        /// <value>The size of the dialog window close button.</value>
        [Category("Sizes"), Description("The size of the dialog window close button.")]
        public virtual Size DialogWindowCloseButtonSize
        {
            get
            {
                return this.GetValue<Size>("DialogWindowCloseButtonSize",this.GetImageSize(this.DialogWindowCloseButtonNormalStyleLTR.BackgroundImage,new Size(6,6)));
            }
            set
            {
                this.SetValue("DialogWindowCloseButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetHeight()
        {
            this.Reset("DialogWindowCloseButtonSize");
        }


        /// <summary>
        /// Gets the width of the dialog window close button.
        /// </summary>
        /// <value>The width of the dialog window close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DialogWindowCloseButtonWidth
        {
            get
            {
                return this.DialogWindowCloseButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the dialog window close button.
        /// </summary>
        /// <value>The height of the dialog window close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DialogWindowButtonCloseHeight
        {
            get
            {
                return this.DialogWindowCloseButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button normal style.
        /// </summary>
        /// <value>The dialog window minimize button normal style.</value>
        [Category("States"), SRDescription("The dialog window minimize button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMinimizeButtonNormalStyleLTR, this.DialogWindowMinimizeButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button normal style LTR.
        /// </summary>
        /// <value>The dialog window minimize button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button normal style RTL.
        /// </summary>
        /// <value>The dialog window minimize button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button hover style.
        /// </summary>
        /// <value>The dialog window minimize button hover style.</value>
        [Category("States"), SRDescription("The dialog window hover minimize button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMinimizeButtonHoverStyleLTR, this.DialogWindowMinimizeButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button hover style LTR.
        /// </summary>
        /// <value>The dialog window minimize button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonHoverStyleLTR", this.DialogWindowMinimizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button hover style RTL.
        /// </summary>
        /// <value>The dialog window minimize button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonHoverStyleRTL", this.DialogWindowMinimizeButtonNormalStyleRTL);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the dialog window minimize button disabled style.
        /// </summary>
        /// <value>The dialog window minimize button disabled style.</value>
        [Category("States"), SRDescription("The dialog window disabled minimize button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMinimizeButtonDisabledStyleLTR, this.DialogWindowMinimizeButtonDisabledStyleRTL);
            }
        }


        /// <summary>
        /// Gets the dialog window minimize button disabled style LTR.
        /// </summary>
        /// <value>The dialog window minimize button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonDisabledStyleLTR", this.DialogWindowMinimizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window minimize button disabled style RTL.
        /// </summary>
        /// <value>The dialog window minimize button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMinimizeButtonDisabledStyleRTL", this.DialogWindowMinimizeButtonNormalStyleRTL);
                return objStyle;
            }
        }



        /// <summary>
        /// Gets or sets the size of the dialog window minimize button.
        /// </summary>
        /// <value>The size of the dialog window minimize button.</value>
        [Category("Sizes"), Description("The size of the dialog window minimize button.")]
        public virtual Size DialogWindowMinimizeButtonSize
        {
            get
            {
                return this.GetValue<Size>("DialogWindowMinimizeButtonSize",this.GetImageSize(this.DialogWindowMinimizeButtonNormalStyleLTR.BackgroundImage,new Size(6,6)));
            }
            set
            {
                this.SetValue("DialogWindowMinimizeButtonSize", value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the dialog window restore button.
        /// </summary>
        /// <value>The size of the dialog window restore button.</value>
        [Category("Sizes"), Description("The size of the dialog window restore button.")]
        public virtual Size DialogWindowRestoreButtonSize
        {
            get
            {
                return this.GetValue<Size>("DialogWindowRestoreButtonSize", this.GetImageSize(this.DialogWindowRestoreButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
            }
            set
            {
                this.SetValue("DialogWindowRestoreButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetDialogWindowMinimizeButtonSize()
        {
            this.Reset("DialogWindowMinimizeButtonSize");
        }

        /// <summary>
        /// Gets the width of the dialog window restore button.
        /// </summary>
        /// <value>The width of the dialog window restore button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowRestoreButtonWidth
        {
            get
            {
                return this.DialogWindowRestoreButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the dialog window restore button.
        /// </summary>
        /// <value>The height of the dialog window restore button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DialogWindowRestoreButtonHeight
        {
            get
            {
                return this.DialogWindowRestoreButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the dialog window minimize button.
        /// </summary>
        /// <value>The width of the dialog window minimize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowMinimizeButtonWidth
        {
            get
            {
                return this.DialogWindowMinimizeButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the dialog window minimize button.
        /// </summary>
        /// <value>The height of the dialog window minimize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DialogWindowMinimizeButtonHeight
        {
            get
            {
                return this.DialogWindowMinimizeButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the height of the dialog window close button.
        /// </summary>
        /// <value>The height of the dialog window close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowCloseButtonHeight
        {
            get
            {
                return this.DialogWindowCloseButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button normal style.
        /// </summary>
        /// <value>The dialog window restore button normal style.</value>
        [Category("States"), Description("The dialog window restore button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowRestoreButtonNormalStyleLTR, this.DialogWindowRestoreButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window restore button normal style LTR.
        /// </summary>
        /// <value>The dialog window restore button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button normal style RTL.
        /// </summary>
        /// <value>The dialog window restore button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button hover style.
        /// </summary>
        /// <value>The dialog window restore button hover style.</value>
        [Category("States"), Description("The dialog window hover restore button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowRestoreButtonHoverStyleLTR, this.DialogWindowRestoreButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window restore button hover style LTR.
        /// </summary>
        /// <value>The dialog window restore button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonHoverStyleLTR", this.DialogWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button hover style RTL.
        /// </summary>
        /// <value>The dialog window restore button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonHoverStyleRTL", this.DialogWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button disabled style.
        /// </summary>
        /// <value>The dialog window restore button disabled style.</value>
        [Category("States"), Description("The dialog window disabled restore button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowRestoreButtonDisabledStyleLTR, this.DialogWindowRestoreButtonDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window restore button disabled style LTR.
        /// </summary>
        /// <value>The dialog window restore button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonDisabledStyleLTR", this.DialogWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window restore button disabled style RTL.
        /// </summary>
        /// <value>The dialog window restore button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowRestoreButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowRestoreButtonDisabledStyleRTL", this.DialogWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button normal style.
        /// </summary>
        /// <value>The dialog window maximize button normal style.</value>
        [Category("States"), Description("The dialog window maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMaximizeButtonNormalStyleLTR, this.DialogWindowMaximizeButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button normal style LTR.
        /// </summary>
        /// <value>The dialog window maximize button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button normal style RTL.
        /// </summary>
        /// <value>The dialog window maximize button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button hover style.
        /// </summary>
        /// <value>The dialog window maximize button hover style.</value>
        [Category("States"), Description("The dialog window hover maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMaximizeButtonHoverStyleLTR, this.DialogWindowMaximizeButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button hover style LTR.
        /// </summary>
        /// <value>The dialog window maximize button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonHoverStyleLTR", this.DialogWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button hover style RTL.
        /// </summary>
        /// <value>The dialog window maximize button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonHoverStyleRTL", this.DialogWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button disabled style.
        /// </summary>
        /// <value>The dialog window maximize button disabled style.</value>
        [Category("States"), Description("The dialog window disabled maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.DialogWindowMaximizeButtonDisabledStyleLTR, this.DialogWindowMaximizeButtonDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button disabled style LTR.
        /// </summary>
        /// <value>The dialog window maximize button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonDisabledStyleLTR", this.DialogWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the dialog window maximize button disabled style RTL.
        /// </summary>
        /// <value>The dialog window maximize button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DialogWindowMaximizeButtonDisabledStyleRTL", this.DialogWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the size of the dialog window maximize button.
        /// </summary>
        /// <value>The size of the dialog window maximize button.</value>
        [Category("Sizes"), Description("The size of the dialog window maximize button.")]
        public virtual Size DialogWindowMaximizeButtonSize
        {
            get
            {
                return this.GetValue<Size>("DialogWindowMaximizeButtonSize",this.GetImageSize(this.DialogWindowMaximizeButtonNormalStyleLTR.BackgroundImage,new Size(6,6)));
            }
            set
            {
                this.SetValue("DialogWindowMaximizeButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetDialogWindowMaximizeButtonSize()
        {
            this.Reset("DialogWindowMaximizeButtonSize");
        }

        /// <summary>
        /// Gets the width of the dialog window maximize button.
        /// </summary>
        /// <value>The width of the dialog window maximize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DialogWindowMaximizeButtonWidth
        {
            get
            {
                return this.DialogWindowMaximizeButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the dialog window maximize button.
        /// </summary>
        /// <value>The height of the dialog window maximize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DialogWindowMaximizeButtonHeight
        {
            get
            {
                return this.DialogWindowMaximizeButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the center normal active dialog style.
        /// </summary>
        /// <value>The center normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterActiveDialogWindowStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left normal active dialog style.
        /// </summary>
        /// <value>The left normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top normal active dialog style.
        /// </summary>
        /// <value>The top normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom normal active dialog style.
        /// </summary>
        /// <value>The bottom normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right normal active dialog style.
        /// </summary>
        /// <value>The right normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top normal active dialog style.
        /// </summary>
        /// <value>The right top normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top normal active dialog style.
        /// </summary>
        /// <value>The left top normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopActiveDialogWindowStyle");
                return objStyle;
            }
        }



        /// <summary>
        /// Gets the left overlay active dialog window style.
        /// </summary>
        /// <value>The left overlay active dialog window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FrameOverlayStyleValue LeftOverlayActiveDialogWindowStyle
        {
            get
            {
                FrameOverlayStyleValue objStyle = new FrameOverlayStyleValue(this, "LeftOverlayActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right overlay active dialog window style.
        /// </summary>
        /// <value>The right overlay active dialog window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FrameOverlayStyleValue RightOverlayActiveDialogWindowStyle
        {
            get
            {
                FrameOverlayStyleValue objStyle = new FrameOverlayStyleValue(this, "RightOverlayActiveDialogWindowStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the left bottom normal active dialog style.
        /// </summary>
        /// <value>The left bottom normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomActiveDialogWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom normal active dialog style.
        /// </summary>
        /// <value>The right bottom normal active dialog style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomActiveDialogWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomActiveDialogWindowStyle");
                return objStyle;
            }
        }

        #endregion
        
        #endregion

        #region ToolWindow Style


        /// <summary>
        /// Gets or sets the width of the left tool window frame.
        /// </summary>
        /// <value>The width of the left tool window frame.</value>
        [Category("Sizes"), Description("The width of the left tool window frame.")]
        public virtual int LeftToolWindowFrameWidth
        {
            get
            {
                return this.GetValue<int>("LeftToolWindowFrameWidth", this.GetImageWidth(this.ActiveToolWindowStyle.LeftStyle.BackgroundImage, this.DefaultLeftToolWindowFrameWidth));
            }
            set
            {
                this.SetValue("LeftToolWindowFrameWidth", value);
            }
        }
        
        /// <summary>
        /// Resets the width of the left tool window frame.
        /// </summary>
        internal void ResetLeftToolWindowFrameWidth()
        {
            this.Reset("LeftToolWindowFrameWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultLeftToolWindowFrameWidth
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets the width of the right tool window frame.
        /// </summary>
        /// <value>The width of the right tool window frame.</value>
        [Category("Sizes"), Description("The width of the right tool window frame.")]
        public virtual int RightToolWindowFrameWidth
        {
            get
            {
                return this.GetValue<int>("RightToolWindowFrameWidth", this.GetImageWidth(this.ActiveToolWindowStyle.RightStyle.BackgroundImage, this.DefaultRightToolWindowFrameWidth));
            }
            set
            {
                this.SetValue("RightToolWindowFrameWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the right tool window frame.
        /// </summary>
        internal void ResetRightToolWindowFrameWidth()
        {
            this.Reset("RightToolWindowFrameWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultRightToolWindowFrameWidth
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets the height of the top tool window frame.
        /// </summary>
        /// <value>The height of the top tool window frame.</value>
        [Category("Sizes"), Description("The height of the top tool window frame.")]
        public virtual int TopToolWindowFrameHeight
        {
            get
            {
                return this.GetValue<int>("TopToolWindowFrameHeight", this.GetImageHeight(this.ActiveToolWindowStyle.TopStyle.BackgroundImage, this.DefaultTopToolWindowFrameHeight));
            }
            set
            {
                this.SetValue("TopToolWindowFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the top tool window frame.
        /// </summary>
        internal void ResetTopToolWindowFrameHeight()
        {
            this.Reset("TopToolWindowFrameHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultTopToolWindowFrameHeight
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets the height of the bottom tool window frame.
        /// </summary>
        /// <value>The height of the bottom tool window frame.</value>
        [Category("Sizes"), Description("The height of the bottom tool window frame.")]
        public virtual int BottomToolWindowFrameHeight
        {
            get
            {
                return this.GetValue<int>("BottomToolWindowFrameHeight", this.GetImageHeight(this.ActiveToolWindowStyle.BottomStyle.BackgroundImage, this.DefaultBottomToolWindowFrameHeight));
            }
            set
            {
                this.SetValue("BottomToolWindowFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the bottom tool window frame.
        /// </summary>
        internal void ResetBottomToolWindowFrameHeight()
        {
            this.Reset("BottomToolWindowFrameHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultBottomToolWindowFrameHeight
        {
            get
            {
                return 4;
            }
        }


        #region ActiveToolWindow Style



        /// <summary>
        /// Gets the normal active tool style.
        /// </summary>
        /// <value>The normal active tool style.</value>
        [Category("States"), Description("The normal active tool style.")]
        public virtual FrameStyleValue ActiveToolWindowStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomActiveToolWindowStyle,
                    this.LeftActiveToolWindowStyle,
                    this.LeftTopActiveToolWindowStyle,
                    this.TopActiveToolWindowStyle,
                    this.RightTopActiveToolWindowStyle,
                    this.RightActiveToolWindowStyle,
                    this.RightBottomActiveToolWindowStyle,
                    this.BottomActiveToolWindowStyle,
                    this.CenterActiveToolWindowStyle);
            }
        }

        /// <summary>
        /// Gets the tool window captions style.
        /// </summary>
        /// <value>The tool window captions style.</value>
        [Category("States"), Description("The tool window captions style.")]
        public virtual StyleValue ToolWindowCaptionStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCaptionStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window buttons style.
        /// </summary>
        /// <value>The tool window buttons style.</value>
        [Category("States"), Description("The tool window buttons style.")]
        public virtual StyleValue ToolWindowButtonsStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowButtonsStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the tool window close button normal style.
        /// </summary>
        /// <value>The tool window close button normal style.</value>
        [Category("States"), Description("The tool window close button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowCloseButtonNormalStyleLTR, this.ToolWindowCloseButtonNormalStyleRTL);
            }
        }


        /// <summary>
        /// Gets the tool window close button normal style LTR.
        /// </summary>
        /// <value>The tool window close button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window close button normal style RTL.
        /// </summary>
        /// <value>The tool window close button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window close button hover style.
        /// </summary>
        /// <value>The tool window close button hover style.</value>
        [Category("States"), Description("The tool window hover close button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowCloseButtonHoverStyleLTR, this.ToolWindowCloseButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window close button hover style LTR.
        /// </summary>
        /// <value>The tool window close button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonHoverStyleLTR", this.ToolWindowCloseButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window close button hover style RTL.
        /// </summary>
        /// <value>The tool window close button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonHoverStyleRTL", this.ToolWindowCloseButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window close button disabled style.
        /// </summary>
        /// <value>The tool window close button disabled style.</value>
        [Category("States"), Description("The tool window disabled close button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowCloseButtonDisabledStyleLTR, this.ToolWindowCloseButtonDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window close button disabled style LTR.
        /// </summary>
        /// <value>The tool window close button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonDisabledStyleLTR", this.ToolWindowCloseButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window close button disabled style RTL.
        /// </summary>
        /// <value>The tool window close button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowCloseButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowCloseButtonDisabledStyleRTL", this.ToolWindowCloseButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the size of the tool window close button.
        /// </summary>
        /// <value>The size of the tool window close button.</value>
        [Category("Sizes"), Description("The size of the tool window close button.")]
        public virtual Size ToolWindowCloseButtonSize
        {
            get
            {
                return this.GetValue<Size>("ToolWindowCloseButtonSize", this.GetImageSize(this.ToolWindowCloseButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
            }
            set
            {
                this.SetValue("ToolWindowCloseButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetToolWindowCloseButtonSize()
        {
            this.Reset("ToolWindowCloseButtonSize");
        }


        /// <summary>
        /// Gets the width of the tool window close button.
        /// </summary>
        /// <value>The width of the tool window close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowCloseButtonWidth
        {
            get
            {
                return this.ToolWindowCloseButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the tool window close button.
        /// </summary>
        /// <value>The height of the tool window close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowCloseButtonHeight
        {
            get
            {
                return this.ToolWindowCloseButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the tool window minimize button normal style.
        /// </summary>
        /// <value>The tool window minimize button normal style.</value>
        [Category("States"), Description("The tool window minimize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMinimizeButtonNormalStyleLTR, this.ToolWindowMinimizeButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window minimize button normal style LTR.
        /// </summary>
        /// <value>The tool window minimize button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window minimize button normal style RTL.
        /// </summary>
        /// <value>The tool window minimize button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window minimize button hover style.
        /// </summary>
        /// <value>The tool window minimize button hover style.</value>
        [Category("States"), Description("The tool window hover minimize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMinimizeButtonHoverStyleLTR, this.ToolWindowMinimizeButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window minimize button hover style LTR.
        /// </summary>
        /// <value>The tool window minimize button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonHoverStyleLTR", this.ToolWindowMinimizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window minimize button hover style RTL.
        /// </summary>
        /// <value>The tool window minimize button hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonHoverStyleRTL", this.ToolWindowMinimizeButtonNormalStyleRTL);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the tool window minimize button disabled style.
        /// </summary>
        /// <value>The tool window minimize button disabled style.</value>
        [Category("States"), Description("The tool window disabled minimize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMinimizeButtonDisabledStyleLTR, this.ToolWindowMinimizeButtonDisabledStyleRTL);
            }
        }


        /// <summary>
        /// Gets the tool window minimize button disabled style LTR.
        /// </summary>
        /// <value>The tool window minimize button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonDisabledStyleLTR", this.ToolWindowMinimizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window minimize button disabled style RTL.
        /// </summary>
        /// <value>The tool window minimize button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMinimizeButtonDisabledStyleRTL", this.ToolWindowMinimizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        
        /// <summary>
        /// Gets or sets the size of the tool window minimize button.
        /// </summary>
        /// <value>The size of the tool window minimize button.</value>
        [Category("Sizes"), Description("The size of the tool window minimize button.")]
        public virtual Size ToolWindowMinimizeButtonSize
        {
            get
            {
                return this.GetValue<Size>("ToolWindowMinimizeButtonSize", this.GetImageSize(this.ToolWindowMinimizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
            }
            set
            {
                this.SetValue("ToolWindowMinimizeButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetToolWindowMinimizeButtonSize()
        {
            this.Reset("ToolWindowMinimizeButtonSize");
        }

        /// <summary>
        /// Gets the width of the tool window minimize button.
        /// </summary>
        /// <value>The width of the tool window minimize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowMinimizeButtonWidth
        {
            get
            {
                return this.ToolWindowMinimizeButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the tool window minimize button.
        /// </summary>
        /// <value>The height of the tool window minimize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowMinimizeButtonHeight
        {
            get
            {
                return this.ToolWindowMinimizeButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button normal style.
        /// </summary>
        /// <value>The tool window maximize button normal style.</value>
        [Category("States"), Description("The tool window maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMaximizeButtonNormalStyleLTR, this.ToolWindowMaximizeButtonNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window maximize button normal style LTR.
        /// </summary>
        /// <value>The tool window maximize button normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMaximizeButtonNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button normal style RTL.
        /// </summary>
        /// <value>The tool window maximize button normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMaximizeButtonNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button hover style.
        /// </summary>
        /// <value>The tool window maximize button hover style.</value>
        [Category("States"), Description("The tool window hover maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMaximizeButtonHoverStyleLTR, this.ToolWindowMaximizeButtonHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window maximize button hover style LTR.
        /// </summary>
        /// <value>The tool window maximize button hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMaximizeButtonHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonHoverStyleLTR", this.ToolWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button hover style RTL.
        /// </summary>
        /// <value>The tool window maximize button hover style RTL.</value>
        public virtual StyleValue ToolWindowMaximizeButtonHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonHoverStyleRTL", this.ToolWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button disabled style.
        /// </summary>
        /// <value>The tool window maximize button disabled style.</value>
        [Category("States"), Description("The tool window disabled maximize button style.")]
        public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ToolWindowMaximizeButtonDisabledStyleLTR, this.ToolWindowMaximizeButtonDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the tool window maximize button disabled style LTR.
        /// </summary>
        /// <value>The tool window maximize button disabled style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonDisabledStyleLTR", this.ToolWindowMaximizeButtonNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tool window maximize button disabled style RTL.
        /// </summary>
        /// <value>The tool window maximize button disabled style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ToolWindowMaximizeButtonDisabledStyleRTL", this.ToolWindowMaximizeButtonNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the size of the tool window maximize button.
        /// </summary>
        /// <value>The size of the tool window maximize button.</value>
        [Category("Sizes"), Description("The size of the tool window maximize button.")]
        public virtual Size ToolWindowMaximizeButtonSize
        {
            get
            {
                return this.GetValue<Size>("ToolWindowMaximizeButtonSize", this.GetImageSize(this.ToolWindowMaximizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
            }
            set
            {
                this.SetValue("ToolWindowMaximizeButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetToolWindowMaximizeButtonSize()
        {
            this.Reset("ToolWindowMaximizeButtonSize");
        }

        /// <summary>
        /// Gets the width of the tool window maximize button.
        /// </summary>
        /// <value>The width of the tool window maximize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowMaximizeButtonWidth
        {
            get
            {
                return this.ToolWindowMaximizeButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the tool window maximize button.
        /// </summary>
        /// <value>The height of the tool window maximize button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ToolWindowMaximizeButtonHeight
        {
            get
            {
                return this.ToolWindowMaximizeButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the center normal active tool style.
        /// </summary>
        /// <value>The center normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterActiveToolWindowStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left normal active tool style.
        /// </summary>
        /// <value>The left normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top normal active tool style.
        /// </summary>
        /// <value>The top normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom normal active tool style.
        /// </summary>
        /// <value>The bottom normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right normal active tool style.
        /// </summary>
        /// <value>The right normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top normal active tool style.
        /// </summary>
        /// <value>The right top normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top normal active tool style.
        /// </summary>
        /// <value>The left top normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom normal active tool style.
        /// </summary>
        /// <value>The left bottom normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomActiveToolWindowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom normal active tool style.
        /// </summary>
        /// <value>The right bottom normal active tool style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomActiveToolWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomActiveToolWindowStyle");
                return objStyle;
            }
        }

        #endregion

        #endregion

        #region PopupWindow Style

        /// <summary>
        /// Gets or sets the width of the popup window offset.
        /// </summary>
        /// <value>The width of the popup window offset.</value>
        [Category("Sizes"), Description("The offset width for the popup window.")]
        public virtual int PopupWindowOffsetWidth
        {
            get
            {
                return this.GetValue<int>("PopupWindowOffsetWidth", this.DefaultPopupWindowOffsetWidth);
            }
            set
            {
                this.SetValue("PopupWindowOffsetWidth", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetPopupWindowOffsetWidth()
        {
            this.Reset("PopupWindowOffsetWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultPopupWindowOffsetWidth
        {
            get
            {
                return this.RightPopupWindowFrameWidth +  this.LeftPopupWindowFrameWidth;
            }
        }

        /// <summary>
        /// Gets or sets the height of the popup window offset.
        /// </summary>
        /// <value>The height of the popup window offset.</value>
        [Category("Sizes"), Description("The offset height for the popup window.")]
        public virtual int PopupWindowOffsetHeight
        {
            get
            {
                return this.GetValue<int>("PopupWindowOffsetHeight", this.DefaultPopupWindowOffsetHeight);
            }
            set
            {
                this.SetValue("PopupWindowOffsetHeight", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetPopupWindowOffsetHeight()
        {
            this.Reset("PopupWindowOffsetHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultPopupWindowOffsetHeight
        {
            get
            {
                return this.TopPopupWindowFrameHeight + this.BottomPopupWindowFrameHeight;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left popup window frame.
        /// </summary>
        /// <value>The width of the left popup window frame.</value>
        [Category("Sizes"), Description("The width of the left popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftPopupWindowFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Resets the width of the left popup window frame.
        /// </summary>
        internal void ResetLeftPopupWindowFrameWidth()
        {
            this.Reset("LeftPopupWindowFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right popup window frame.
        /// </summary>
        /// <value>The width of the right popup window frame.</value>
        [Category("Sizes"), Description("The width of the right popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightPopupWindowFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Right);
            }
        }

        /// <summary>
        /// Resets the width of the right popup window frame.
        /// </summary>
        internal void ResetRightPopupWindowFrameWidth()
        {
            this.Reset("RightPopupWindowFrameWidth");
        }

        /// <summary>
        /// Gets or sets the height of the top popup window frame.
        /// </summary>
        /// <value>The height of the top popup window frame.</value>
        [Category("Sizes"), Description("The height of the top popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int TopPopupWindowFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Resets the height of the top popup window frame.
        /// </summary>
        internal void ResetTopPopupWindowFrameHeight()
        {
            this.Reset("TopPopupWindowFrameHeight");
        }

        /// <summary>
        /// Gets or sets the height of the bottom popup window frame.
        /// </summary>
        /// <value>The height of the bottom popup window frame.</value>
        [Category("Sizes"), Description("The height of the bottom popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int BottomPopupWindowFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Resets the height of the bottom popup window frame.
        /// </summary>
        internal void ResetBottomPopupWindowFrameHeight()
        {
            this.Reset("BottomPopupWindowFrameHeight");
        }

        /// <summary>
        /// Gets the opup window style.
        /// </summary>
        /// <value>The opup window style.</value>
        [Category("States"), Description("The popup window style.")]
        public virtual FrameStyleValue PopupWindowStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomPopupWindowStyle,
                    this.LeftPopupWindowStyle,
                    this.LeftTopPopupWindowStyle,
                    this.TopPopupWindowStyle,
                    this.RightTopPopupWindowStyle,
                    this.RightPopupWindowStyle,
                    this.RightBottomPopupWindowStyle,
                    this.BottomPopupWindowStyle,
                    this.CenterPopupWindowStyle);
            }
        }


        /// <summary>
        /// Gets the center popup window style.
        /// </summary>
        /// <value>The center popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterPopupWindowStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterPopupWindowStyle", this.PopupSkin.CenterStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left popup window style.
        /// </summary>
        /// <value>The left popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftPopupWindowStyle", this.PopupSkin.LeftStyle, true);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the top popup window style.
        /// </summary>
        /// <value>The top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopPopupWindowStyle", this.PopupSkin.TopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom popup window style.
        /// </summary>
        /// <value>The bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomPopupWindowStyle", this.PopupSkin.BottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right popup window style.
        /// </summary>
        /// <value>The right popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightPopupWindowStyle", this.PopupSkin.RightStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top popup window style.
        /// </summary>
        /// <value>The right top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopPopupWindowStyle", this.PopupSkin.RightTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top popup window style.
        /// </summary>
        /// <value>The left top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopPopupWindowStyle", this.PopupSkin.LeftTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom popup window style.
        /// </summary>
        /// <value>The left bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomPopupWindowStyle", this.PopupSkin.LeftBottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom popup window style.
        /// </summary>
        /// <value>The right bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomPopupWindowStyle", this.PopupSkin.RightBottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popups skin.
        /// </summary>
        /// <value>The popups skin.</value>
        private PopupsSkin PopupSkin
        {
            get
            {
                return SkinFactory.GetSkin(this.Owner, typeof(PopupsSkin),true) as PopupsSkin;
            }
        }

        #endregion

        #region Misc

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        /// <remarks>Provides the default background color for design time.</remarks>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return this.DialogBackColor;
            }
            set
            {

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
                return this.MinimizedMdiFormSize.Width;
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
                return this.MinimizedMdiFormSize.Height;
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetBackColor()
        {
            this.Reset("BackColor");
        }

        /// <summary>
        /// Gets or sets the size of the minimized MDI form.
        /// </summary>
        /// <value>The size of the minimized MDI form.</value>
        [Category("Sizes"), Description("Gets or sets the size of a minimized MDI form.")]
        public Size MinimizedMdiFormSize
        {
            get
            {
                return this.GetValue<Size>("MinimizedMdiFormSize", this.DefaultMinimizedMdiFormSize);
            }
            set
            {
                this.SetValue("MinimizedMdiFormSize", value);
            }
        }

        /// <summary>
        /// Gets or sets the dialog background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), Description("Gets or sets the dialog background color.")]
        public virtual Color DialogBackColor
        {
            get
            {
                return this.GetValue<Color>("DialogBackColor", Color.FromArgb(240, 240, 240));
            }
            set
            {
                this.SetValue("DialogBackColor", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetDialogBackColor()
        {
            this.Reset("DialogBackColor");
        }


        /// <summary>
        /// Gets the dialog background.
        /// </summary>
        /// <value>The dialog background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue DialogBackground
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.DialogBackColor;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets or sets the window background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), Description("Gets or sets the window background color.")]
        public virtual Color WindowBackColor
        {
            get
            {
                return this.GetValue<Color>("WindowBackColor", Color.Empty);
            }
            set
            {
                this.SetValue("WindowBackColor", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetWindowBackColor()
        {
            this.Reset("WindowBackColor");
        }


        /// <summary>
        /// Gets the window background.
        /// </summary>
        /// <value>The window background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue WindowBackground
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.WindowBackColor;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets or sets the popup background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), Description("Gets or sets the popup background color.")]
        public virtual Color PopupBackColor
        {
            get
            {
                return this.GetValue<Color>("PopupBackColor", Color.FromArgb(240, 240, 240));
            }
            set
            {
                this.SetValue("PopupBackColor", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetPopupBackColor()
        {
            this.Reset("PopupBackColor");
        }


        /// <summary>
        /// Gets the popup background.
        /// </summary>
        /// <value>The popup background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue PopupBackground
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.PopupBackColor;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets the boxes bar footer style.
        /// </summary>
        /// <value>The boxes bar footer style.</value>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("States"), Description("Gets or sets the style of the boxes bar footer.")]
        public virtual StyleValue BoxesBarFooterStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "BoxesBarFooterStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the height of the boxes bar footer.
        /// </summary>
        /// <value>The height of the boxes bar footer.</value>
        [Category("Sizes"), Description("Gets or sets the height of the boxes bar footer.")]
        public virtual int BoxesBarFooterHeight
        {
            get
            {
                return this.GetValue<int>("BoxesBarFooterHeight", 4);
            }
            set
            {
                this.SetValue("BoxesBarFooterHeight", value);
            }
        }

        #endregion
    }
}
