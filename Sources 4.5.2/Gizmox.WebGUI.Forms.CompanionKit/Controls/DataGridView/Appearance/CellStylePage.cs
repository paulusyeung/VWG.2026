#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.DataGridView.Appearance
{
    public partial class CellStylePage : UserControl
    {
        private List<CellStyleColorProperty> _cellStyleColors;
        private Font _cellStyleFont;
       
        public CellStylePage()
        {
            InitializeComponent();
            
            //Fill up colors Combobox
            _cellStyleColors = new List<CellStyleColorProperty>();
            _cellStyleColors.Add(new CellStyleColorProperty(CellStyleTypes.BackColor, this.mobjDataGridView.DefaultCellStyle.BackColor));
            _cellStyleColors.Add(new CellStyleColorProperty(CellStyleTypes.ForeColor, this.mobjDataGridView.DefaultCellStyle.ForeColor));
            _cellStyleColors.Add(new CellStyleColorProperty(CellStyleTypes.SelectionBackColor, this.mobjDataGridView.DefaultCellStyle.SelectionBackColor));
            _cellStyleColors.Add(new CellStyleColorProperty(CellStyleTypes.SelectionForeColor, this.mobjDataGridView.DefaultCellStyle.SelectionForeColor));

            this.mobjColorComboBox.DataSource = _cellStyleColors;
            this.mobjColorComboBox.ColorMember = "CellColor";
            this.mobjColorComboBox.DisplayMember = "CellStyleColorType";
            this.mobjColorComboBox.SelectedIndex = 0;

            //Fill up Alignment ComboBox
            this.mobjAlignComboBox.DataSource = Enum.GetValues(typeof(DataGridViewContentAlignment));
            this.mobjAlignComboBox.SelectedItem = this.mobjDataGridView.DefaultCellStyle.Alignment;

            _cellStyleFont = this.mobjDataGridView.DefaultCellStyle.Font;
            UpdateFontLabel(_cellStyleFont);

            this.mobjWrapModeComboBox.DataSource = Enum.GetValues(typeof(DataGridViewTriState));
            this.mobjWrapModeComboBox.SelectedItem = this.mobjDataGridView.DefaultCellStyle.WrapMode;

            //Get ResourceHandle for photo of customer.
            global::Gizmox.WebGUI.Common.Resources.ResourceHandle photoResource = new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("Photo.jpg");
            //Set objects collection as DataSource for ComboBox.
            this.mobjDataGridView.DataSource = global::Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomersWithImage(photoResource);
           
        }

        private void mobjColorButton_Click(object sender, EventArgs e)
        {
            CellStyleColorProperty mobjCellStyleColor = this.mobjColorComboBox.SelectedItem as CellStyleColorProperty;
            this.mobjColorDialog.Color = mobjCellStyleColor.CellColor;
            this.mobjColorDialog.ShowDialog();
        }

        private void mobjColorDialog_Closed(object sender, EventArgs e)
        {
            CellStyleColorProperty mobjCellStyleColor = this.mobjColorComboBox.SelectedItem as CellStyleColorProperty;
            Color mobjNewColor = this.mobjColorDialog.Color;
            //Update selected color in the cell property that it is selected in color property ComboBox
            UpdateCellStyle(mobjCellStyleColor.CellStyleColorType, mobjNewColor);
            
            //Update selected color in color ComboBox
            foreach(CellStyleColorProperty mobjCurrentCellStyleColor in _cellStyleColors) 
            {
                if (mobjCurrentCellStyleColor.CellStyleColorType == mobjCellStyleColor.CellStyleColorType)
                {
                    mobjCurrentCellStyleColor.CellColor = mobjNewColor;
                    break;
                }
            }
            // TODO: check after Beta 2 released, VWG-6520, remove call to Update()
            this.mobjColorComboBox.Update();
        }

       
        private void mobjAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewContentAlignment mobjAlignment = (DataGridViewContentAlignment)this.mobjAlignComboBox.SelectedItem;
            
            //Update text alignment in cell style
            UpdateCellStyle(CellStyleTypes.Alignment, mobjAlignment);  
        }

        private void mobjFontChangeButton_Click(object sender, EventArgs e)
        {
            this.mobjFontDialog.Font = _cellStyleFont;
            this.mobjFontDialog.ShowDialog();
        }

        private void mobjFontDialog_Closed(object sender, EventArgs e)
        {
            UpdateFontForCell(this.mobjFontDialog.Font);
        }

        private void mobjFontDialog_Apply(object sender, EventArgs e)
        {
            UpdateFontForCell(this.mobjFontDialog.Font);
        }

        private void mobjDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.mobjDataGridView.SelectedCells.Count > 0)
            {
                DataGridViewCell mobjFirstCell = this.mobjDataGridView.SelectedCells[0];
                
                //Update colors ComboBox

                //Enable color ComboBox and change color Burtton only when DataGridView cell has selected and before anything cells were not selected.
                if (!this.mobjColorComboBox.Enabled)
                {
                    this.mobjColorComboBox.Enabled = true;
                }
                if (!this.mobjColorButton.Enabled)
                {
                    this.mobjColorButton.Enabled = true;
                }
                
                foreach (CellStyleColorProperty mobjCurrentCellStyleColor in _cellStyleColors)
                {
                    switch (mobjCurrentCellStyleColor.CellStyleColorType)
                    {
                        case CellStyleTypes.ForeColor:
                            mobjCurrentCellStyleColor.CellColor = !mobjFirstCell.Style.ForeColor.IsEmpty ? mobjFirstCell.Style.ForeColor : this.mobjDataGridView.DefaultCellStyle.ForeColor;
                            break;
                        case CellStyleTypes.BackColor:
                            mobjCurrentCellStyleColor.CellColor = !mobjFirstCell.Style.BackColor.IsEmpty ? mobjFirstCell.Style.BackColor : this.mobjDataGridView.DefaultCellStyle.BackColor;
                            break;
                        case CellStyleTypes.SelectionForeColor:
                            mobjCurrentCellStyleColor.CellColor = !mobjFirstCell.Style.SelectionForeColor.IsEmpty ? mobjFirstCell.Style.SelectionForeColor : this.mobjDataGridView.DefaultCellStyle.SelectionForeColor;
                            break;
                        case CellStyleTypes.SelectionBackColor:
                            mobjCurrentCellStyleColor.CellColor = !mobjFirstCell.Style.SelectionBackColor.IsEmpty ? mobjFirstCell.Style.SelectionBackColor : this.mobjDataGridView.DefaultCellStyle.SelectionBackColor;
                            break;
                    }
                }
                // TODO: check after Beta 2 released, VWG-6520, remove call to Update()
                this.mobjColorComboBox.Update();

                //Enable cell text alignment ComboBox only when DataGridView cell has selected and before anything cells were not selected.
                if (!this.mobjAlignComboBox.Enabled)
                {
                    this.mobjAlignComboBox.Enabled = true;
                }
                this.mobjAlignComboBox.SelectedItem = mobjFirstCell.Style.Alignment != DataGridViewContentAlignment.NotSet ? mobjFirstCell.Style.Alignment : this.mobjDataGridView.DefaultCellStyle.Alignment;

                //Enable font change Button only when DataGridView cell has selected and before anything cells were not selected.
                if (!this.mobjFontChangeButton.Enabled)
                {
                    this.mobjFontChangeButton.Enabled = true;
                }
                Font mobjCurrentCellFont = mobjFirstCell.Style.Font != null ? mobjFirstCell.Style.Font : this.mobjDataGridView.DefaultCellStyle.Font;
                //UpdateFontLabel(currentCellFont);
                _cellStyleFont = mobjCurrentCellFont;

                //Update WrapMode ComboBox
                //Enable WrapMode ComboBox only when DataGridView cell has selected and before anything cells were not selected.
                if (!this.mobjWrapModeComboBox.Enabled)
                {
                    this.mobjWrapModeComboBox.Enabled = true;
                }
                this.mobjWrapModeComboBox.SelectedItem = mobjFirstCell.Style.WrapMode != DataGridViewTriState.NotSet ? mobjFirstCell.Style.WrapMode : this.mobjDataGridView.DefaultCellStyle.WrapMode;
            }
            else
            {
                this.mobjFontChangeButton.Enabled = false;
                this.mobjAlignComboBox.Enabled = false;
                this.mobjColorComboBox.Enabled = false;
                this.mobjColorButton.Enabled = false;
                this.mobjWrapModeComboBox.Enabled = false;
            }
        }

        private void mobjWrapModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataGridViewTriState mobjNewWrapMode = (DataGridViewTriState)this.mobjWrapModeComboBox.SelectedItem;
            UpdateCellStyle(CellStyleTypes.WrapMode, mobjNewWrapMode);
        }

        private void UpdateFontLabel(Font newFont)
        {
            if (newFont != null)
            {
                this.mobjFontLabel.Text = string.Format("Font: {0}, {1}pt", newFont.Name, newFont.Size);
            }
        }

        private void UpdateFontForCell(Font newFont)
        {
            if (newFont == null)
            {
                return;
            }

            UpdateFontLabel(newFont);
            UpdateCellStyle(CellStyleTypes.Font, newFont);
        }
        /// <summary>
        /// Updates specified property of cell style to new <code>value</code>
        /// </summary>
        /// <param name="cellStyleType">Type of cell style property</param>
        /// <param name="value">New value</param>
        private void UpdateCellStyle(CellStyleTypes cellStyleType, object value)
        {
            for (int i = 0; i < this.mobjDataGridView.SelectedCells.Count; ++i)
            {
                DataGridViewCell cell = this.mobjDataGridView.SelectedCells[i];
                switch (cellStyleType)
                {
                    case CellStyleTypes.ForeColor:
                        cell.Style.ForeColor = (Color)value ;
                        break;
                    case CellStyleTypes.BackColor:
                        cell.Style.BackColor = (Color)value;
                        break;
                    case CellStyleTypes.SelectionForeColor:
                        cell.Style.SelectionForeColor = (Color)value;
                        break;
                    case CellStyleTypes.SelectionBackColor:
                        cell.Style.SelectionBackColor = (Color)value;
                        break;
                    case CellStyleTypes.Font:
                        cell.Style.Font = (Font)value;
                        break;
                    case CellStyleTypes.Alignment:
                        cell.Style.Alignment = (DataGridViewContentAlignment)value;
                        break;
                    case CellStyleTypes.WrapMode:
                        cell.Style.WrapMode = (DataGridViewTriState)value;
                        break;
                }

            }
        }
        /// <summary>
        /// Enum represents name of style property.
        /// </summary>
        enum CellStyleTypes 
        {
            ForeColor, 
            BackColor, 
            SelectionForeColor, 
            SelectionBackColor, 
            Alignment, 
            WrapMode, 
            Font
        };

        /// <summary>
        /// Class represents cell style color property.
        /// </summary>
        private class CellStyleColorProperty
        {
            private CellStyleTypes _cellStyleColorType = CellStyleTypes.BackColor;
            private Color _cellColor;

            public CellStyleColorProperty(CellStyleTypes cellStyleColorType, Color cellColor)
            {
                CellStyleColorType = cellStyleColorType;
                CellColor = cellColor;
            }
            /// <summary>
            /// Represents name color property.
            /// </summary>
            public CellStyleTypes CellStyleColorType
            {
                get
                {
                    return _cellStyleColorType;
                }
                set
                {
                    _cellStyleColorType = value;
                }
            }

            /// <summary>
            /// Gets or sets selected cell color.
            /// </summary>
            public Color CellColor
            {
                get
                {
                    return _cellColor;
                }
                set
                {
                    _cellColor = value;
                }
            }
        }
       
    }
}