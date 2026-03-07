using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// DataGridViewHeaderFilterComboBox Skin
    /// </summary>
    [SkinContainer(typeof(DataGridViewSkin)), Serializable()]
    public class DataGridViewHeaderFilterComboBoxSkin : Gizmox.WebGUI.Forms.Skins.ComboBoxSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the filter normal image.
        /// </summary>
        [Category("Images"), Description("The Filter image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> FilterNormalImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "FilterNormalImageLTR", "FilterNormalImageRTL");
            }
        }

        /// <summary>
        /// Gets or sets the filter normal image LTR.
        /// </summary>
        /// <value>
        /// The filter normal image LTR.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterNormalImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterNormalImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "Filter.png"));
            }
            set
            {
                this.SetValue("FilterNormalImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the filter normal image RTL.
        /// </summary>
        /// <value>
        /// The filter normal image RTL.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterNormalImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterNormalImageRTL", this.FilterNormalImageLTR);
            }
            set
            {
                this.SetValue("FilterNormalImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the filter normal image.
        /// </summary>
        private void ResetFilterNormalImage()
        {
            this.Reset("FilterNormalImage");
        }

        /// <summary>
        /// Gets the filter hover image.
        /// </summary>
        [Category("Images"), Description("The filter image while mouse hover.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> FilterHoverImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "FilterHoverImageLTR", "FilterHoverImageRTL");
            }
        }

        /// <summary>
        /// Gets or sets the filter hover image LTR.
        /// </summary>
        /// <value>
        /// The filter hover image LTR.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterHoverImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterHoverImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "FilterHover.png"));
            }
            set
            {
                this.SetValue("FilterHoverImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the filter hover image RTL.
        /// </summary>
        /// <value>
        /// The filter hover image RTL.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterHoverImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterHoverImageRTL", this.FilterHoverImageLTR);
            }
            set
            {
                this.SetValue("FilterHoverImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the filter hover image.
        /// </summary>
        private void ResetFilterHoverImage()
        {
            this.Reset("FilterHoverImage");
        }

        /// <summary>
        /// Gets the filter normal image.
        /// </summary>
        [Category("Images"), Description("THe Filter image while mouse down.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> FilterDownImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "FilterDownImageLTR", "FilterDownImageRTL");
            }
        }

        /// <summary>
        /// Gets or sets the filter down image LTR.
        /// </summary>
        /// <value>
        /// The filter down image LTR.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterDownImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterDownImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "FilterDown.png"));
            }
            set
            {
                this.SetValue("FilterDownImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the filter down image RTL.
        /// </summary>
        /// <value>
        /// The filter down image RTL.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference FilterDownImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("FilterDownImageRTL", this.FilterDownImageLTR);
            }
            set
            {
                this.SetValue("FilterDownImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the filter normal image.
        /// </summary>
        private void ResetFilterDownImage()
        {
            this.Reset("FilterDownImage");
        }

        /// <summary>
        /// Gets the width of the filter normal image.
        /// </summary>
        /// <value>
        /// The width of the filter normal image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SkinValue FilterNormalImageWidth
        {
            get
            {
                return new BidirectionalSkinValue<int>(this, FilterNormalImageWidthLTR, FilterNormalImageWidthRTL);
            }
        }

        /// <summary>
        /// Gets the filter normal image width RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FilterNormalImageWidthRTL 
        {
            get
            {
                return this.GetImageWidth(this.FilterNormalImageRTL);
            }
        }

        /// <summary>
        /// Gets the filter normal image width LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FilterNormalImageWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.FilterNormalImageLTR);
            }
        }

        /// <summary>
        /// Gets the drop down width spaceer.
        /// </summary>
        [Category("Sizes"), SRDescription("This value will be added to the longest item width.")]
        public virtual int DropDownWidthSpacer
        {
            get
            {
                return this.GetValue<int>("DropDownWidthSpacer", 25);
            }
            set
            {
                this.SetValue("DropDownWidthSpacer", value);
            }
        }

        /// <summary>
        /// Resets the drop down width spacer.
        /// </summary>
        internal void ResetDropDownWidthSpacer()
        {
            this.Reset("DropDownWidthSpacer");
        }
    }
}
