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

namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    public partial class MaxSizePage : UserControl
    {

        public MaxSizePage()
        {
            InitializeComponent();
        }

        private void MaxSizePage_Load(object sender, EventArgs e)
        {
            this.mobjSetMaxSizeFontNumericUpDown.Minimum = this.mobjDemoFontDialog.MinSize;
            this.mobjSetMaxSizeFontNumericUpDown.Maximum = this.mobjDemoFontDialog.MaxSize;
            //Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(this.mobjMaxSizeFontLabel.Font);
        }

        private void mobjChangeFontButton_Click(object sender, EventArgs e)
        {
            //Set initial Font for FontDialog
            this.mobjDemoFontDialog.Font = this.mobjMaxSizeFontLabel.Font;
            //Set maximum size font taht user can select in FontDialog
            this.mobjDemoFontDialog.MaxSize = decimal.ToInt16(this.mobjSetMaxSizeFontNumericUpDown.CurrentValue);
            //Show FontDialog
            this.mobjDemoFontDialog.ShowDialog();
        }

        private void mobjDemoFontDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result of FontDialog
            if (this.mobjDemoFontDialog.DialogResult == DialogResult.OK)
            {
                this.mobjMaxSizeFontLabel.Font = this.mobjDemoFontDialog.Font;
                //Change text of represented Label to selected Font
                UpdateTestOfLabel(this.mobjMaxSizeFontLabel.Font);
            }
        }

        /// <summary>
        /// Updates text of represented label with name and size of selected Font.
        /// </summary>
        /// <param name="newFont">selected font in FontDialog</param>
        private void UpdateTestOfLabel(Font newFont)
        {
            this.mobjMaxSizeFontLabel.Text = string.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size);
        }
    }
}
