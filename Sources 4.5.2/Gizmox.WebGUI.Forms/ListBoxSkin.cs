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
    /// ListBox Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ListBox), "ListBox.bmp"), Serializable()]
    public class ListBoxSkin : ControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region Sizes

        /// <summary>
        /// Gets the height of the selection icon image.
        /// </summary>
        /// <value>The height of the selection icon image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int SelectionIconHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultSelectionIconHeight, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");
            }
        }

        /// <summary>
        /// Resets the height of the selection icon.
        /// </summary>
        private void ResetSelectionIconHeight()
        {
            this.Reset("SelectionIconHeight");
        }

        /// <summary>
        /// Gets the default height of the selection icon.
        /// </summary>
        /// <value>The default height of the selection icon.</value>
        protected virtual int DefaultSelectionIconHeight
        {
            get
            {
                return 13;
            }
        }

        /// <summary>
        /// Gets the width of the selection icon image.
        /// </summary>
        /// <value>The width of the selection icon image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int SelectionIconWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultSelectionIconWidth, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");
            }
        }

        /// <summary>
        /// Resets the width of the selection icon.
        /// </summary>
        private void ResetSelectionIconWidth()
        {
            this.Reset("SelectionIconWidth");
        }

        /// <summary>
        /// Gets the default width of the selection icon.
        /// </summary>
        /// <value>The default width of the selection icon.</value>
        protected virtual int DefaultSelectionIconWidth
        {
            get
            {
                return 13;
            }
        }

        /// <summary>
        /// Gets or sets the width of the check box cell.
        /// </summary>
        /// <value>The width of the check box cell.</value>
        [SRCategory("Sizes"), SRDescription("The check box cell width.")]
        public virtual int CheckBoxCellWidth
        {
            get
            {
                return this.GetValue<int>("CheckBoxCellWidth", this.DefaultCheckBoxCellWidth);
            }
            set
            {
                this.SetValue("CheckBoxCellWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the check box cell.
        /// </summary>
        internal void ResetCheckBoxCellWidth()
        {
            this.Reset("CheckBoxCellWidth");
        }

        /// <summary>
        /// Gets the default width of the check box cell.
        /// </summary>
        /// <value>The default width of the check box cell.</value>
        protected virtual int DefaultCheckBoxCellWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the list box color cell.
        /// </summary>
        /// <value>The width of the list box color cell.</value>
        [SRCategory("Sizes"), SRDescription("The ListBox color cell width.")]
        public virtual int ListBoxColorCellWidth
        {
            get
            {
                return this.GetValue<int>("ListBoxColorCellWidth", this.DefaultListBoxColorCellWidth);
            }
            set
            {
                this.SetValue("ListBoxColorCellWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the color list box color cell.
        /// </summary>
        internal void ResetListBoxColorCellWidth()
        {
            this.Reset("ListBoxColorCellWidth");
        }

        /// <summary>
        /// Gets the default width of the color list box color cell.
        /// </summary>
        /// <value>The default width of the color list box color cell.</value>
        protected virtual int DefaultListBoxColorCellWidth
        {
            get
            {
                return 30;
            }
        }

        /// <summary>
        /// Gets or sets the Height of the list box image cell.
        /// </summary>
        /// <value>The Height of the list box image cell.</value>
        [SRCategory("Sizes"), SRDescription("The ListBox Image Cell Height.")]
        public virtual int ListBoxColorBoxHeight
        {
            get
            {
                return this.GetValue<int>("ListBoxColorBoxHeight", this.DefaultListBoxColorBoxHeight);
            }
            set
            {
                this.SetValue("ListBoxColorBoxHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the selection icon.
        /// </summary>
        private void ResetListBoxColorBoxHeight()
        {
            this.Reset("ListBoxColorBoxHeight");
        }

        /// <summary>
        /// Gets the default height of the selection icon.
        /// </summary>
        /// <value>The default height of the selection icon.</value>
        protected virtual int DefaultListBoxColorBoxHeight
        {
            get
            {
                return 14;
            }
        }


        /// <summary>
        /// Gets or sets the width of the list box image cell.
        /// </summary>
        /// <value>The width of the list box image cell.</value>
        [SRCategory("Sizes"), SRDescription("The ListBox Image Cell Width.")]
        public virtual int ListBoxImageCellWidth
        {
            get
            {
                return this.GetValue<int>("ListBoxImageCellWidth", this.DefaultListBoxImageCellWidth);
            }
            set
            {
                this.SetValue("ListBoxImageCellWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the list box image cell.
        /// </summary>
        internal void ResetListBoxImageCellWidth()
        {
            this.Reset("ListBoxImageCellWidth");
        }

        /// <summary>
        /// Gets the default width of the color list box color cell.
        /// </summary>
        /// <value>The default width of the color list box color cell.</value>
        protected virtual int DefaultListBoxImageCellWidth
        {
            get
            {
                return 16;
            }
        }



        /// <summary>
        /// Gets or sets the height of the list box image cell.
        /// </summary>
        /// <value>The height of the list box image cell.</value>
        [SRCategory("Sizes"), SRDescription("The ListBox Image Cell Height.")]
        public virtual int ListBoxImageCellHeight
        {
            get
            {
                return this.GetValue<int>("ListBoxImageCellHeight", this.DefaultListBoxImageCellHeight);
            }
            set
            {
                this.SetValue("ListBoxImageCellHeight", value);
            }
        }


        /// <summary>
        /// Resets the height of the list box image cell.
        /// </summary>
        internal void ResetListBoxImageCellHeight()
        {
            this.Reset("ListBoxImageCellHeight");
        }

        /// <summary>
        /// Gets the default height of the list box image cell.
        /// </summary>
        /// <value>The default height of the list box image cell.</value>
        protected virtual int DefaultListBoxImageCellHeight
        {
            get
            {
                return 16;
            }
        }


        /// <summary>
        /// Gets the width of the preferd image box.
        /// </summary>
        /// <value>The width of the preferd image box.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreferdImageBoxWidth
        {
            get
            {
                //Return the image box width as set by the user + the horizontal padding
                return this.ListBoxImageCellWidth + this.CellStyle.Padding.Horizontal;
            }
        }

        /// <summary>
        /// Gets the width of the preferd color box.
        /// </summary>
        /// <value>The width of the preferd color box.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreferdColorBoxWidth
        {
            get
            {
                //Return the color box width as set by the user + the horizontal padding
                return this.ListBoxColorCellWidth + this.CellStyle.Padding.Horizontal;
            }
        }

        #endregion

        #region Styles


        /// <summary>
        /// Gets the focused list box selected row style.
        /// </summary>
        /// <value>The focused list box selected row style.</value>
        [Category("States"), SRDescription("The focused listbox selected row style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue FocusedListBoxSelectedRowStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FocusedListBoxSelectedRowStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the selected cell style.
        /// </summary>
        /// <value>The selected cell style.</value>
        [Category("States"), SRDescription("The selected cell style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SelectedCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedCellStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the color list box color box style.
        /// </summary>
        /// <value>The color list box color box style.</value>
        [Category("States"), SRDescription("The color listbox color box style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ColorBoxStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ColorBoxStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the cell style.
        /// </summary>
        /// <value>The cell style.</value>
        public virtual StyleValue CellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellStyle");
                return objStyle;
            }
        }

        #endregion

        #region Icons


        /// <summary>
        /// Gets or sets the checked radio button image.
        /// </summary>
        /// <value>The checked radio button image.</value>
        [SRDescription("The CheckedRadioButtonImage.")]
        [SRCategory("Images")]
        public ImageResourceReference CheckedRadioButtonImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CheckedRadioButtonImage", new ImageResourceReference(typeof(ListBoxSkin), "Radio1.gif"));
            }
            set
            {
                this.SetValue("CheckedRadioButtonImage", value);
            }
        }

        internal void ResetCheckedRadioButtonImage()
        {
            this.Reset("CheckedRadioButtonImage");
        }


        /// <summary>
        /// Gets or sets the unchecked radio button image.
        /// </summary>
        /// <value>The unchecked radio button image.</value>
        [SRDescription("The UncheckedRadioButtonImage.")]
        [SRCategory("Images")]
        public ImageResourceReference UncheckedRadioButtonImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UncheckedRadioButtonImage", new ImageResourceReference(typeof(ListBoxSkin), "Radio0.gif"));
            }
            set
            {
                this.SetValue("UncheckedRadioButtonImage", value);
            }
        }

        internal void ResetUncheckedRadioButtonImage()
        {
            this.Reset("UncheckedRadioButtonImage");
        }


        /// <summary>
        /// Gets or sets the checked check box image.
        /// </summary>
        /// <value>The checked check box image.</value>
        [SRDescription("The CheckedCheckBoxImage.")]
        [SRCategory("Images")]
        public ImageResourceReference CheckedCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CheckedCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox1.gif"));
            }
            set
            {
                this.SetValue("CheckedCheckBoxImage", value);
            }
        }

        internal void ResetCheckedCheckBoxImage()
        {
            this.Reset("CheckedCheckBoxImage");
        }


        /// <summary>
        /// Gets or sets the unchecked check box image.
        /// </summary>
        /// <value>The unchecked check box image.</value>
        [SRDescription("The UncheckedCheckBoxImage.")]
        [SRCategory("Images")]
        public ImageResourceReference UncheckedCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UncheckedCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox0.gif"));
            }
            set
            {
                this.SetValue("UncheckedCheckBoxImage", value);
            }
        }

        internal void ResetUncheckedCheckBoxImage()
        {
            this.Reset("UncheckedCheckBoxImage");
        }

        /// <summary>
        /// Gets or sets the indeterminate check box image.
        /// </summary>
        /// <value>The indeterminate check box image.</value>
        [SRDescription("The Indeterminate checkbox image.")]
        [SRCategory("Images")]
        public ImageResourceReference IndeterminateCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("IndeterminateCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox2.gif"));
            }
            set
            {
                this.SetValue("IndeterminateCheckBoxImage", value);
            }
        }

        internal void ResetIndeterminateCheckBoxImage()
        {
            this.Reset("IndeterminateCheckBoxImage");
        }

        #endregion
    }
}
