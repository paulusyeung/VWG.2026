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
    /// UpDown Base Skin
    /// </summary>
    [ToolboxBitmap(typeof(DomainUpDown), "DomainUpDown.bmp"), Serializable()]
    public class UpDownBaseSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region Styles

        /// <summary>
        /// Gets the buttons' normal container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons normal container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerNormalStyleLTR, ButtonsContainerNormalStyleRTL);
            }
        }
        /// <summary>
        /// Gets the buttons container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerNormalStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerNormalStyleRTL 
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets The buttons hover container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons hover container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerHoverStyleLTR, ButtonsContainerHoverStyleRTL);
            }
        }
        /// <summary>
        /// Gets the buttons container hover style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerHoverStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container hover style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerHoverStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets The buttons pressed container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons pressed container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerPressedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerPressedStyleLTR, ButtonsContainerPressedStyleRTL);
            }
        }

        /// <summary>
        /// Gets the buttons container pressed style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerPressedStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerPressedStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container pressed style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerPressedStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerPressedStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets down normal style.
        /// </summary>
        /// <value>Down normal style.</value>
        [SRCategory("States"), SRDescription("Lower image Normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue DownNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DownNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets down over style.
        /// </summary>
        /// <value>Down over style.</value>
        [SRCategory("States"), SRDescription("Lower image Over style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue DownOverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DownOverStyle", this.DownNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets down down style.
        /// </summary>
        /// <value>Down down style.</value>
        [SRCategory("States"), SRDescription("Lower image Down style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue DownDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DownDownStyle", this.DownNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets up normal style.
        /// </summary>
        /// <value>Up normal style.</value>
        [SRCategory("States"), SRDescription("Upper image Normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue UpNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UpNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets up over style.
        /// </summary>
        /// <value>Up over style.</value>
        [SRCategory("States"), SRDescription("Upper image Over style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue UpOverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UpOverStyle", this.UpNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets up down style.
        /// </summary>
        /// <value>Up down style.</value>
        [SRCategory("States"), SRDescription("Upper image down style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue UpDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UpDownStyle", this.UpNormalStyle);
                return objStyle;
            }
        }


        #endregion
              
        #region Sizes

        /// <summary>
        /// Gets or sets the width of the image cell.
        /// </summary>
        /// <value>The width of the image cell.</value>
        [SRCategory("Sizes"), SRDescription("The image cell width.")]
        public int ImageCellWidth
        {
            get
            {
                return this.GetValue<int>("ImageCellWidth", 15);
            }
            set
            {
                this.SetValue("ImageCellWidth", value);
            }
        }

        #endregion                
    }
}
