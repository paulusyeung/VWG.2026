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
    /// 
    /// </summary>
    [ToolboxBitmapAttribute(typeof(TrackBar), "TrackBar.bmp"), Serializable()]
    public class TrackBarSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        /// <summary>
        /// Gets the horizontal tail both style.
        /// </summary>
        /// <value>
        /// The horizontal tail both style.
        /// </value>
        public StyleValue HorizontalTailBothStyle
        {
            get
            {
                return new StyleValue(this, "HorizontalTailBothStyle");
            }
        }

        /// <summary>
        /// Gets the horizontal tail top style.
        /// </summary>
        /// <value>
        /// The horizontal tail top style.
        /// </value>
        public StyleValue HorizontalTailTopStyle
        {
            get
            {
                return new StyleValue(this, "HorizontalTailTopStyle");
            }
        }

        /// <summary>
        /// Gets the horizontal tail bottom style.
        /// </summary>
        /// <value>
        /// The horizontal tail bottom style.
        /// </value>
        public StyleValue HorizontalTailBottomStyle
        {
            get
            {
                return new StyleValue(this, "HorizontalTailBottomStyle");
            }
        }

        /// <summary>
        /// Gets the horizontal tail none style.
        /// </summary>
        /// <value>
        /// The horizontal tail none style.
        /// </value>
        public StyleValue HorizontalTailNoneStyle
        {
            get
            {
                return new StyleValue(this, "HorizontalTailNoneStyle");
            }
        }

        /// <summary>
        /// Gets the vertical tail both style.
        /// </summary>
        /// <value>
        /// The vertical tail both style.
        /// </value>
        public StyleValue VerticalTailBothStyle
        {
            get
            {
                return new StyleValue(this, "VerticalTailBothStyle");
            }
        }

        /// <summary>
        /// Gets the vertical tail top style.
        /// </summary>
        /// <value>
        /// The vertical tail top style.
        /// </value>
        public StyleValue VerticalTailTopStyle
        {
            get
            {
                return new StyleValue(this, "VerticalTailTopStyle");
            }
        }

        /// <summary>
        /// Gets the vertical tail bottom style.
        /// </summary>
        /// <value>
        /// The vertical tail bottom style.
        /// </value>
        public StyleValue VerticalTailBottomStyle
        {
            get
            {
                return new StyleValue(this, "VerticalTailBottomStyle");
            }
        }

        /// <summary>
        /// Gets the vertical tail none style.
        /// </summary>
        /// <value>
        /// The vertical tail none style.
        /// </value>
        public StyleValue VerticalTailNoneStyle
        {
            get
            {
                return new StyleValue(this, "VerticalTailNoneStyle");
            }
        }

        #region Images

        #region Horizontal Slider Images

        /// <summary>
        /// Gets or sets the slider top image.
        /// </summary>
        /// <value>The slider top image.</value>
        [Description("Slider top image")]
        [Category("Images")]
        public ImageResourceReference SliderTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDU.gif"));
            }
            set
            {
                this.SetValue("SliderTopImage", value);
            }
        }

        /// <summary>
        /// Resets the slider top image.
        /// </summary>
        private void ResetSliderTop()
        {
            this.Reset("SliderTopImage");
        }

        /// <summary>
        /// Gets or sets the slider bottom image.
        /// </summary>
        /// <value>The slider bottom image.</value>
        [Description("Slider bottom image")]
        [Category("Images")]
        public ImageResourceReference SliderBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUD.gif"));
            }
            set
            {
                this.SetValue("SliderBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the slider bottom image.
        /// </summary>
        private void ResetSliderBottom()
        {
            this.Reset("SliderBottomImage");
        }

        /// <summary>
        /// Gets or sets the slider horizontal both image.
        /// </summary>
        /// <value>The slider horizontal both image.</value>
        [Description("Slider horizontal both image")]
        [Category("Images")]
        public ImageResourceReference SliderHorizontalBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderHorizontalBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERT.gif"));
            }
            set
            {
                this.SetValue("SliderHorizontalBothImage", value);
            }
        }

        /// <summary>
        /// Resets the slider horizontal both image.
        /// </summary>
        private void ResetSliderHorizontalBoth()
        {
            this.Reset("SliderHorizontalBothImage");
        }

        #endregion Horizontal Slider Images
        
        #region Vertical Slider Images

        /// <summary>
        /// Gets or sets the slider left image.
        /// </summary>
        /// <value>The slider left image.</value>
        [Description("Slider left image")]
        [Category("Images")]
        public ImageResourceReference SliderLeft
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRL.gif"));
            }
            set
            {
                this.SetValue("SliderLeftImage", value);
            }
        }


        /// <summary>
        /// Resets the slider left image.
        /// </summary>
        private void ResetSliderLeft()
        {
            this.Reset("SliderLeftImage");
        }

        /// <summary>
        /// Gets or sets the slider right image.
        /// </summary>
        /// <value>The slider right image.</value>
        [Description("Slider right image")]
        [Category("Images")]
        public ImageResourceReference SliderRight
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLR.gif"));
            }
            set
            {
                this.SetValue("SliderRightImage", value);
            }
        }

        /// <summary>
        /// Resets the slider right image.
        /// </summary>
        private void ResetSliderRight()
        {
            this.Reset("SliderRightImage");
        }


        /// <summary>
        /// Gets or sets the slider vertical both image.
        /// </summary>
        /// <value>The slider vertical both image.</value>
        [Description("Slider vertical both image")]
        [Category("Images")]
        public ImageResourceReference SliderVerticalBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SliderVerticalBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZ.gif"));
            }
            set
            {
                this.SetValue("SliderVerticalBothImage", value);
            }
        }

        /// <summary>
        /// Resets the slider vertical both image.
        /// </summary>
        private void ResetSliderVerticalBoth()
        {
            this.Reset("SliderVerticalBothImage");
        }

        #endregion Vertical Slider Images

        #region Horizontal left most position image

        /// <summary>
        /// Gets or sets the horizontal start tick top image.
        /// </summary>
        /// <value>The horizontal start tick top image.</value>
        [Description("Horizontal start tick top image")]
        [Category("Images")]
        public ImageResourceReference HorizontalStartTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalStartTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickL.gif"));
            }
            set
            {
                this.SetValue("HorizontalStartTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal start tick top image.
        /// </summary>
        private void ResetHorizontalStartTickTop()
        {
            this.Reset("HorizontalStartTickTopImage");
        }

        /// <summary>
        /// Gets or sets the horizontal start tick bottom image.
        /// </summary>
        /// <value>The horizontal start tick bottom image.</value>
        [Description("Horizontal start tick bottom image")]
        [Category("Images")]
        public ImageResourceReference HorizontalStartTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalStartTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickL.gif"));
            }
            set
            {
                this.SetValue("HorizontalStartTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal start tick bottom image.
        /// </summary>
        private void ResetHorizontalStartTickBottom()
        {
            this.Reset("HorizontalStartTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the horizontal start tick both image.
        /// </summary>
        /// <value>The horizontal start tick both image.</value>
        [Description("Horizontal start tick both image")]
        [Category("Images")]
        public ImageResourceReference HorizontalStartTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalStartTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickL.gif"));
            }
            set
            {
                this.SetValue("HorizontalStartTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal start tick both image.
        /// </summary>
        private void ResetHorizontalStartTickBoth()
        {
            this.Reset("HorizontalStartTickBothImage");
        }


        /// <summary>
        /// Gets or sets the horizontal start tick none image.
        /// </summary>
        /// <value>The horizontal start tick none image.</value>
        [Description("Horizontal start tick none image")]
        [Category("Images")]
        public ImageResourceReference HorizontalStartTickNone
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalStartTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickL.gif"));
            }
            set
            {
                this.SetValue("HorizontalStartTickNoneImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal start tick None image.
        /// </summary>
        private void ResetHorizontalStartTickNone()
        {
            this.Reset("HorizontalStartTickNoneImage");
        }

        #endregion Horizontal left most position image

        #region Horizontal right most position image

        /// <summary>
        /// Gets or sets the horizontal end tick top image.
        /// </summary>
        /// <value>The horizontal end tick top image.</value>
        [Description("Horizontal end tick top image")]
        [Category("Images")]
        public ImageResourceReference HorizontalEndTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalEndTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickR.gif"));
            }
            set
            {
                this.SetValue("HorizontalEndTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal end tick top image.
        /// </summary>
        private void ResetHorizontalEndTickTop()
        {
            this.Reset("HorizontalEndTickTopImage");
        }

        /// <summary>
        /// Gets or sets the horizontal end tick bottom image.
        /// </summary>
        /// <value>The horizontal end tick bottom image.</value>
        [Description("Horizontal end tick bottom image")]
        [Category("Images")]
        public ImageResourceReference HorizontalEndTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalEndTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickR.gif"));
            }
            set
            {
                this.SetValue("HorizontalEndTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal end tick bottom image.
        /// </summary>
        private void ResetHorizontalEndTickBottom()
        {
            this.Reset("HorizontalEndTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the horizontal end tick both image.
        /// </summary>
        /// <value>The horizontal end tick both image.</value>
        [Description("Horizontal end tick both image")]
        [Category("Images")]
        public ImageResourceReference HorizontalEndTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalEndTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickR.gif"));
            }
            set
            {
                this.SetValue("HorizontalEndTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal end tick both image.
        /// </summary>
        private void ResetHorizontalEndTickBoth()
        {
            this.Reset("HorizontalEndTickBothImage");
        }



        /// <summary>
        /// Gets or sets the horizontal end tick none image.
        /// </summary>
        /// <value>The horizontal end tick none image.</value>
        [Description("Horizontal end tick none image")]
        [Category("Images")]
        public ImageResourceReference HorizontalEndTickNone
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalEndTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickR.gif"));
            }
            set
            {
                this.SetValue("HorizontalEndTickNoneImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal end tick none image.
        /// </summary>
        private void ResetHorizontalEndTickNone()
        {
            this.Reset("HorizontalEndTickNoneImage");
        }

        #endregion Horizontal right most position image

        #region Horizontal middle tick image

        /// <summary>
        /// Gets or sets the horizontal middle tick top image.
        /// </summary>
        /// <value>The horizontal middle tick top image.</value>
        [Description("Horizontal middle tick top image")]
        [Category("Images")]
        public ImageResourceReference HorizontalMiddleTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalMiddleTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickM.gif"));
            }
            set
            {
                this.SetValue("HorizontalMiddleTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal middle tick top image.
        /// </summary>
        private void ResetHorizontalMiddleTickTop()
        {
            this.Reset("HorizontalMiddleTickTopImage");
        }

        /// <summary>
        /// Gets or sets the horizontal middle tick bottom image.
        /// </summary>
        /// <value>The horizontal middle tick bottom image.</value>
        [Description("Horizontal middle tick bottom image")]
        [Category("Images")]
        public ImageResourceReference HorizontalMiddleTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalMiddleTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickM.gif"));
            }
            set
            {
                this.SetValue("HorizontalMiddleTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal middle tick bottom image.
        /// </summary>
        private void ResetHorizontalMiddleTickBottom()
        {
            this.Reset("HorizontalMiddleTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the horizontal middle tick both image.
        /// </summary>
        /// <value>The horizontal middle tick both image.</value>
        [Description("Horizontal middle tick both image")]
        [Category("Images")]
        public ImageResourceReference HorizontalMiddleTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalMiddleTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickM.gif"));
            }
            set
            {
                this.SetValue("HorizontalMiddleTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal middle tick both image.
        /// </summary>
        private void ResetHorizontalMiddleTickBoth()
        {
            this.Reset("HorizontalMiddleTickBothImage");
        }

        #endregion Horizontal middle tick image

        #region Horizontal space tick image

        /// <summary>
        /// Gets or sets the horizontal space tick top image.
        /// </summary>
        /// <value>The horizontal space tick top image.</value>
        [Description("Horizontal space tick top image")]
        [Category("Images")]
        public ImageResourceReference HorizontalSpaceTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalSpaceTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUSpace.gif"));
            }
            set
            {
                this.SetValue("HorizontalSpaceTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal space tick top image.
        /// </summary>
        private void ResetHorizontalSpaceTickTop()
        {
            this.Reset("HorizontalSpaceTickTopImage");
        }

        /// <summary>
        /// Gets or sets the horizontal space tick bottom image.
        /// </summary>
        /// <value>The horizontal space tick bottom image.</value>
        [Description("Horizontal space tick bottom image")]
        [Category("Images")]
        public ImageResourceReference HorizontalSpaceTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalSpaceTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDSpace.gif"));
            }
            set
            {
                this.SetValue("HorizontalSpaceTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal space tick bottom image.
        /// </summary>
        private void ResetHorizontalSpaceTickBottom()
        {
            this.Reset("HorizontalSpaceTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the horizontal space tick both image.
        /// </summary>
        /// <value>The horizontal space tick both image.</value>
        [Description("Horizontal space tick both image")]
        [Category("Images")]
        public ImageResourceReference HorizontalSpaceTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("HorizontalSpaceTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTSpace.gif"));
            }
            set
            {
                this.SetValue("HorizontalSpaceTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the horizontal space tick both image.
        /// </summary>
        private void ResetHorizontalSpaceTickBoth()
        {
            this.Reset("HorizontalSpaceTickBothImage");
        }

        #endregion Horizontal space tick image

        #region Vertical top most position image

        /// <summary>
        /// Gets or sets the vertical start tick top image.
        /// </summary>
        /// <value>The vertical start tick top image.</value>
        [Description("Vertical start tick top image")]
        [Category("Images")]
        public ImageResourceReference VerticalStartTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalStartTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickU.gif"));
            }
            set
            {
                this.SetValue("VerticalStartTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical start tick top image.
        /// </summary>
        private void ResetVerticalStartTickTop()
        {
            this.Reset("VerticalStartTickTopImage");
        }

        /// <summary>
        /// Gets or sets the vertical start tick bottom image.
        /// </summary>
        /// <value>The vertical start tick bottom image.</value>
        [Description("Vertical start tick bottom image")]
        [Category("Images")]
        public ImageResourceReference VerticalStartTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalStartTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickU.gif"));
            }
            set
            {
                this.SetValue("VerticalStartTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical start tick bottom image.
        /// </summary>
        private void ResetVerticalStartTickBottom()
        {
            this.Reset("VerticalStartTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the vertical start tick both image.
        /// </summary>
        /// <value>The vertical start tick both image.</value>
        [Description("Vertical start tick both image")]
        [Category("Images")]
        public ImageResourceReference VerticalStartTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalStartTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickU.gif"));
            }
            set
            {
                this.SetValue("VerticalStartTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical start tick both image.
        /// </summary>
        private void ResetVerticalStartTickBoth()
        {
            this.Reset("VerticalStartTickBothImage");
        }


        /// <summary>
        /// Gets or sets the vertical start tick none image.
        /// </summary>
        /// <value>The vertical start tick none image.</value>
        [Description("Vertical start tick none image")]
        [Category("Images")]
        public ImageResourceReference VerticalStartTickNone
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalStartTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickU.gif"));
            }
            set
            {
                this.SetValue("VerticalStartTickNoneImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical start tick none image.
        /// </summary>
        private void ResetVerticalStartTickNone()
        {
            this.Reset("VerticalStartTickNoneImage");
        }



        #endregion Vertical top most position image

        #region Vertical bottom most position image

        /// <summary>
        /// Gets or sets the vertical end tick top image.
        /// </summary>
        /// <value>The vertical end tick top image.</value>
        [Description("Vertical end tick top image")]
        [Category("Images")]
        public ImageResourceReference VerticalEndTickTop
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalEndTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickD.gif"));
            }
            set
            {
                this.SetValue("VerticalEndTickTopImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical end tick top image.
        /// </summary>
        private void ResetVerticalEndTickTop()
        {
            this.Reset("VerticalEndTickTopImage");
        }

        /// <summary>
        /// Gets or sets the vertical end tick bottom image.
        /// </summary>
        /// <value>The vertical end tick bottom image.</value>
        [Description("Vertical end tick bottom image")]
        [Category("Images")]
        public ImageResourceReference VerticalEndTickBottom
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalEndTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickD.gif"));
            }
            set
            {
                this.SetValue("VerticalEndTickBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical end tick bottom image.
        /// </summary>
        private void ResetVerticalEndTickBottom()
        {
            this.Reset("VerticalEndTickBottomImage");
        }


        /// <summary>
        /// Gets or sets the vertical end tick both image.
        /// </summary>
        /// <value>The vertical end tick both image.</value>
        [Description("Vertical end tick both image")]
        [Category("Images")]
        public ImageResourceReference VerticalEndTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalEndTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickD.gif"));
            }
            set
            {
                this.SetValue("VerticalEndTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical end tick both image.
        /// </summary>
        private void ResetVerticalEndTickBoth()
        {
            this.Reset("VerticalEndTickBothImage");
        }



        /// <summary>
        /// Gets or sets the vertical end tick none image.
        /// </summary>
        /// <value>The vertical end tick none image.</value>
        [Description("Vertical end tick none image")]
        [Category("Images")]
        public ImageResourceReference VerticalEndTickNone
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalEndTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickD.gif"));
            }
            set
            {
                this.SetValue("VerticalEndTickNoneImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical end tick none image.
        /// </summary>
        private void ResetVerticalEndTickNone()
        {
            this.Reset("VerticalEndTickNoneImage");
        }

        #endregion Vertical bottom most position image





        #region Vertical middle tick image

        /// <summary>
        /// Gets or sets the vertical middle tick right image.
        /// </summary>
        /// <value>The vertical middle tick right image.</value>
        [Description("Vertical middle tick right image")]
        [Category("Images")]
        public ImageResourceReference VerticalMiddleTickRight
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalMiddleTickRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickM.gif"));
            }
            set
            {
                this.SetValue("VerticalMiddleTickRightImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical middle tick right image.
        /// </summary>
        private void ResetVerticalMiddleTickRight()
        {
            this.Reset("VerticalMiddleTickRightImage");
        }

        /// <summary>
        /// Gets or sets the vertical middle tick left image.
        /// </summary>
        /// <value>The vertical middle tick left image.</value>
        [Description("Vertical middle tick left image")]
        [Category("Images")]
        public ImageResourceReference VerticalMiddleTickLeft
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalMiddleTickLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickM.gif"));
            }
            set
            {
                this.SetValue("VerticalMiddleTickLeftImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical middle tick left image.
        /// </summary>
        private void ResetVerticalMiddleTickLeft()
        {
            this.Reset("VerticalMiddleTickLeftImage");
        }


        /// <summary>
        /// Gets or sets the vertical middle tick both image.
        /// </summary>
        /// <value>The vertical middle tick both image.</value>
        [Description("Vertical middle tick both image")]
        [Category("Images")]
        public ImageResourceReference VerticalMiddleTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalMiddleTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickM.gif"));
            }
            set
            {
                this.SetValue("VerticalMiddleTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical middle tick both image.
        /// </summary>
        private void ResetVerticalMiddleTickBoth()
        {
            this.Reset("VerticalMiddleTickBothImage");
        }

        #endregion Vertical middle tick image

        #region Vertical space tick image

        /// <summary>
        /// Gets or sets the vertical space tick left image.
        /// </summary>
        /// <value>The vertical space tick left image.</value>
        [Description("Vertical space tick left image")]
        [Category("Images")]
        public ImageResourceReference VerticalSpaceTickLeft
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalSpaceTickLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLSpace.gif"));
            }
            set
            {
                this.SetValue("VerticalSpaceTickLeftImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical space tick left image.
        /// </summary>
        private void ResetVerticalSpaceTickLeft()
        {
            this.Reset("VerticalSpaceTickLeftImage");
        }

        /// <summary>
        /// Gets or sets the vertical space tick right image.
        /// </summary>
        /// <value>The vertical space tick right image.</value>
        [Description("Vertical space tick right image")]
        [Category("Images")]
        public ImageResourceReference VerticalSpaceTickRight
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalSpaceTickRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRSpace.gif"));
            }
            set
            {
                this.SetValue("VerticalSpaceTickRightImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical space tick right image.
        /// </summary>
        private void ResetVerticalSpaceTickRight()
        {
            this.Reset("VerticalSpaceTickRightImage");
        }


        /// <summary>
        /// Gets or sets the vertical space tick both image.
        /// </summary>
        /// <value>The vertical space tick both image.</value>
        [Description("Vertical space tick both image")]
        [Category("Images")]
        public ImageResourceReference VerticalSpaceTickBoth
        {
            get
            {
                return this.GetValue<ImageResourceReference>("VerticalSpaceTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZSpace.gif"));
            }
            set
            {
                this.SetValue("VerticalSpaceTickBothImage", value);
            }
        }

        /// <summary>
        /// Resets the vertical space tick both image.
        /// </summary>
        private void ResetVerticalSpaceTickBoth()
        {
            this.Reset("VerticalSpaceTickBothImage");
        }

        #endregion Horizontal space tick image

        #endregion Images

        #region Sizes

        #region Horizontal right most tick image width

        /// <summary>
        /// Gets or sets the width of the horizontal end tick top image.
        /// </summary>
        /// <value>The width of the horizontal end tick top image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalEndTickTopWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalEndTickTopImageWidth",this.GetImageWidth(this.HorizontalEndTickTop, this.DefaultHorizontalEndTickTopImageWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal end tick top image.
        /// </summary>
        /// <value>The default width of the horizontal end tick top image.</value>
        protected virtual int DefaultHorizontalEndTickTopImageWidth
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal end tick bottom image.
        /// </summary>
        /// <value>The width of the horizontal end tick bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalEndTickBottomWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalEndTickBottomImageWidth", this.GetImageWidth(this.HorizontalEndTickBottom, this.DefaultHorizontalEndTickBottomWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal end tick bottom image.
        /// </summary>
        /// <value>The default width of the horizontal end tick bottom image.</value>
        protected virtual int DefaultHorizontalEndTickBottomWidth
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal end tick both image.
        /// </summary>
        /// <value>The width of the horizontal end tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalEndTickBothWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalEndTickBothImageWidth", this.GetImageWidth(this.HorizontalEndTickBoth, this.DefaultHorizontalEndTickBothWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal end tick both image.
        /// </summary>
        /// <value>The default width of the horizontal end tick both image.</value>
        protected virtual int DefaultHorizontalEndTickBothWidth
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal end tick none image.
        /// </summary>
        /// <value>The width of the horizontal end tick none image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalEndTickNoneWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalEndTickNoneImageWidth", this.GetImageWidth(this.HorizontalEndTickNone, this.DefaultHorizontalEndTickNoneWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal end tick none image.
        /// </summary>
        /// <value>The default width of the horizontal end tick none image.</value>
        protected virtual int DefaultHorizontalEndTickNoneWidth
        {
            get
            {
                return 6;
            }
        }

        #endregion Horizontal right most tick image width

        #region Horizontal left most tick image width

        /// <summary>
        /// Gets or sets the width of the horizontal start tick top image.
        /// </summary>
        /// <value>The width of the horizontal start tick top image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalStartTickTopWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalStartTickTopImageWidth", this.GetImageWidth(this.HorizontalStartTickTop, this.DefaultHorizontalStartTickTopWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal start tick top image.
        /// </summary>
        /// <value>The default width of the horizontal start tick top image.</value>
        protected virtual int DefaultHorizontalStartTickTopWidth
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal start tick bottom image.
        /// </summary>
        /// <value>The width of the horizontal start tick bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalStartTickBottomWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalStartTickBottomImageWidth", this.GetImageWidth(this.HorizontalStartTickBottom, this.DefaultHorizontalStartTickBottomWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal start tick bottom image.
        /// </summary>
        /// <value>The default width of the horizontal start tick bottom image.</value>
        protected virtual int DefaultHorizontalStartTickBottomWidth
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal start tick both image.
        /// </summary>
        /// <value>The width of the horizontal start tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalStartTickBothWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalStartTickBothImageWidth", this.GetImageWidth(this.HorizontalStartTickBoth, this.DefaultHorizontalStartTickBothWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal start tick both image.
        /// </summary>
        /// <value>The default width of the horizontal start tick both image.</value>
        protected virtual int DefaultHorizontalStartTickBothWidth
        {
            get
            {
                return 6;
            }
        }


        /// <summary>
        /// Gets or sets the width of the horizontal start tick none image.
        /// </summary>
        /// <value>The width of the horizontal start tick none image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalStartTickNoneWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalStartTickNoneImageWidth", this.GetImageWidth(this.HorizontalStartTickNone, this.DefaultHorizontalStartTickNoneWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal start tick none image.
        /// </summary>
        /// <value>The default width of the horizontal start tick none image.</value>
        protected virtual int DefaultHorizontalStartTickNoneWidth
        {
            get
            {
                return 6;
            }
        }


        #endregion Horizontal left most tick image width

        #region Horizontal middle tick image width

        /// <summary>
        /// Gets or sets the width of the horizontal middle tick top image.
        /// </summary>
        /// <value>The width of the horizontal middle tick top image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalMiddleTickTopWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalMiddleTickTopImageWidth", this.GetImageWidth(this.HorizontalMiddleTickTop, this.DefaultHorizontalMiddleTickTopWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal middle tick top image.
        /// </summary>
        /// <value>The default width of the horizontal middle tick top image.</value>
        protected virtual int DefaultHorizontalMiddleTickTopWidth
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal middle tick bottom image.
        /// </summary>
        /// <value>The width of the horizontal middle tick bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalMiddleTickBottomWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalMiddleTickBottomImageWidth", this.GetImageWidth(this.HorizontalMiddleTickBottom, this.DefaultHorizontalMiddleTickBottomWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal middle tick bottom image.
        /// </summary>
        /// <value>The default width of the horizontal middle tick bottom image.</value>
        protected virtual int DefaultHorizontalMiddleTickBottomWidth
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets or sets the width of the horizontal middle tick both image.
        /// </summary>
        /// <value>The width of the horizontal middle tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalMiddleTickBothWidth
        {
            get
            {
                return (int)this.GetValue<int>("HorizontalMiddleTickBothImageWidth", this.GetImageWidth(this.HorizontalMiddleTickBoth, this.DefaultHorizontalMiddleTickBothWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the horizontal middle tick both image.
        /// </summary>
        /// <value>The default width of the horizontal middle tick both image.</value>
        protected virtual int DefaultHorizontalMiddleTickBothWidth
        {
            get
            {
                return 1;
            }
        }

        #endregion Horizontal middle tick image width

        #region Vertical start tick image height

        /// <summary>
        /// Gets the height of the vertical start tick top image.
        /// </summary>
        /// <value>The height of the vertical start tick top.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalStartTickTopHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalStartTickTopImageHeight", this.GetImageHeight(this.VerticalStartTickTop, this.DefaultVerticalStartTickTopHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical start tick top image.
        /// </summary>
        /// <value>The default height of the vertical start tick top image.</value>
        protected virtual int DefaultVerticalStartTickTopHeight
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the height of the vertical start tick bottom image.
        /// </summary>
        /// <value>The height of the vertical start tick bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalStartTickBottomHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalStartTickBottomImageHeight", this.GetImageHeight(this.VerticalStartTickBottom, this.DefaultVerticalStartTickBottomHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical start tick bottom image.
        /// </summary>
        /// <value>The default height of the vertical start tick bottom image.</value>
        protected virtual int DefaultVerticalStartTickBottomHeight
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the height of the vertical start tick both image.
        /// </summary>
        /// <value>The height of the vertical start tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalStartTickBothHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalStartTickBothImageHeight", this.GetImageHeight(this.VerticalStartTickBoth, this.DefaultVerticalStartTickBothHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical start tick both image.
        /// </summary>
        /// <value>The default height of the vertical start tick both image.</value>
        protected virtual int DefaultVerticalStartTickBothHeight
        {
            get
            {
                return 6;
            }
        }







        /// <summary>
        /// Gets or sets the height of the vertical start tick none image.
        /// </summary>
        /// <value>The height of the vertical start tick none image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalStartTickNoneHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalStartTickNoneImageHeight", this.GetImageHeight(this.VerticalStartTickNone, this.DefaultVerticalStartTickNoneHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical start tick none image.
        /// </summary>
        /// <value>The default height of the vertical start tick bottom image.</value>
        protected virtual int DefaultVerticalStartTickNoneHeight
        {
            get
            {
                return 6;
            }
        }


        #endregion Vertical start tick image height

        #region Vertical end tick image height

        /// <summary>
        /// Gets or sets the height of the vertical end tick top image.
        /// </summary>
        /// <value>The height of the vertical end tick top image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalEndTickTopHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalEndTickTopImageHeight", this.GetImageHeight(this.VerticalEndTickTop, this.DefaultVerticalEndTickTopHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical end tick top image.
        /// </summary>
        /// <value>The default height of the vertical end tick top image.</value>
        protected virtual int DefaultVerticalEndTickTopHeight
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the height of the vertical end tick bottom image.
        /// </summary>
        /// <value>The height of the vertical end tick bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalEndTickBottomHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalEndTickBottomImageHeight", this.GetImageHeight(this.VerticalEndTickBottom, this.DefaultVerticalEndTickBottomHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical end tick bottom image.
        /// </summary>
        /// <value>The default height of the vertical end tick bottom image.</value>
        protected virtual int DefaultVerticalEndTickBottomHeight
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets or sets the height of the vertical end tick both image.
        /// </summary>
        /// <value>The height of the vertical end tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalEndTickBothHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalEndTickBothImageHeight", this.GetImageHeight(this.VerticalEndTickBoth, this.DefaultVerticalEndTickBothHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical end tick both image.
        /// </summary>
        /// <value>The default height of the vertical end tick both image.</value>
        protected virtual int DefaultVerticalEndTickBothHeight
        {
            get
            {
                return 6;
            }
        }



        /// <summary>
        /// Gets or sets the height of the vertical end tick none image.
        /// </summary>
        /// <value>The height of the vertical end tick none image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalEndTickNoneHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalEndTickNoneImageHeight", this.GetImageHeight(this.VerticalEndTickNone, this.DefaultVerticalEndTickNoneHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical end tick none image.
        /// </summary>
        /// <value>The default height of the vertical end tick none image.</value>
        protected virtual int DefaultVerticalEndTickNoneHeight
        {
            get
            {
                return 6;
            }
        }



        #endregion Vertical end tick image height

        #region Vertical middle tick image height

        /// <summary>
        /// Gets or sets the height of the vertical middle tick left image.
        /// </summary>
        /// <value>The height of the vertical middle tick left image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalMiddleTickLeftHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalMiddleTickLeftImageHeight", this.GetImageHeight(this.VerticalMiddleTickLeft, this.DefaultVerticalMiddleTickLeftHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the vertical middle tick left image.
        /// </summary>
        /// <value>The default height of the vertical middle tick left image.</value>
        protected virtual int DefaultVerticalMiddleTickLeftHeight
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets the height of the vertical middle tick right image.
        /// </summary>
        /// <value>The height of the vertical middle tick right.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalMiddleTickRightHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalMiddleTickRightImageHeight", this.GetImageHeight(this.VerticalMiddleTickRight, this.DefaultVerticalMiddleTickRightHeight));
            }            
        }

        /// <summary>
        /// Gets the default height of the vertical middle tick right image.
        /// </summary>
        /// <value>The default height of the vertical middle tick right image.</value>
        protected virtual int DefaultVerticalMiddleTickRightHeight
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets or sets the height of the vertical middle tick both image.
        /// </summary>
        /// <value>The height of the vertical middle tick both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalMiddleTickBothHeight
        {
            get
            {
                return (int)this.GetValue<int>("VerticalMiddleTickBothImageHeight", this.GetImageHeight(this.VerticalMiddleTickBoth, this.DefaultVerticalMiddleTickBothHeight));
            }            
        }

        /// <summary>
        /// Gets the default height of the vertical middle tick both image.
        /// </summary>
        /// <value>The default height of the vertical middle tick both image.</value>
        protected virtual int DefaultVerticalMiddleTickBothHeight
        {
            get
            {
                return 1;
            }
        }

        #endregion Vertical end tick image height

        #region Slider image size


        /// <summary>
        /// Gets the width of the slider top image.
        /// </summary>
        /// <value>The width of the slider top image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderTopWidth
        {
            get
            {
                return (int)this.GetValue<int>("SliderTopWidth", this.GetImageWidth(this.SliderTop, this.DefaultSliderTopWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the slider top image.
        /// </summary>
        /// <value>The default width of the slider top image.</value>
        protected int DefaultSliderTopWidth
        {
            get
            {
                return 12;
            }
        }


        /// <summary>
        /// Gets the width of the slider bottom image.
        /// </summary>
        /// <value>The width of the slider bottom image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderBottomWidth
        {
            get
            {
                return (int)this.GetValue<int>("SliderBottomWidth", this.GetImageWidth(this.SliderBottom, this.DefaultSliderBottomWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the slider bottom image.
        /// </summary>
        /// <value>The default width of the slider bottom image.</value>
        protected int DefaultSliderBottomWidth
        {
            get
            {
                return 12;
            }
        }


        /// <summary>
        /// Gets the width of the slider horizontal both image.
        /// </summary>
        /// <value>The width of the slider horizontal both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderHorizontalBothWidth
        {
            get
            {
                return (int)this.GetValue<int>("SliderHorizontalBothWidth", this.GetImageWidth(this.SliderHorizontalBoth, this.DefaultSliderHorizontalBothWidth));
            }
        }

        /// <summary>
        /// Gets the default width of the slider horizontal both image.
        /// </summary>
        /// <value>The default width of the slider horizontal both image.</value>
        protected int DefaultSliderHorizontalBothWidth
        {
            get
            {
                return 12;
            }
        }     


        /// <summary>
        /// Gets the height of the slider left image.
        /// </summary>
        /// <value>The height of the slider left image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderLeftHeight
        {
            get
            {
                return (int)this.GetValue<int>("SliderLeftHeight", this.GetImageHeight(this.SliderLeft, this.DefaultSliderLeftHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the slider left image.
        /// </summary>
        /// <value>The default height of the slider left image.</value>
        protected int DefaultSliderLeftHeight
        {
            get
            {
                return 12;
            }
        }


        /// <summary>
        /// Gets the height of the slider right image.
        /// </summary>
        /// <value>The height of the slider right image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderRightHeight
        {
            get
            {
                return (int)this.GetValue<int>("SliderRightHeight", this.GetImageHeight(this.SliderRight, this.DefaultSliderRightHeight));
            }
        }

        /// <summary>
        /// Gets the default height of the slider right image.
        /// </summary>
        /// <value>The default height of the slider right image.</value>
        protected int DefaultSliderRightHeight
        {
            get
            {
                return 12;
            }
        }


        /// <summary>
        /// Gets the height of the slider horizontal both image.
        /// </summary>
        /// <value>The height of the slider horizontal both image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SliderHorizontalBothHeight
        {
            get
            {
                return (int)this.GetValue<int>("SliderHorizontalBothHeight", this.GetImageHeight(this.SliderVerticalBoth, this.DefaultSliderHorizontalBothHeight));
            }            
        }

        /// <summary>
        /// Gets the default height of the slider horizontal both image.
        /// </summary>
        /// <value>The default height of the slider horizontal both image.</value>
        protected int DefaultSliderHorizontalBothHeight
        {
            get
            {
                return 12;
            }
        }

        #endregion Slider image size

        #endregion Sizes
    }
}
