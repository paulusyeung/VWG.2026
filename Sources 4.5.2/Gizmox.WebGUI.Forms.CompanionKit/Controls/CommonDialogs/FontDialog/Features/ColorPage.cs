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
    public partial class ColorPage : UserControl
    {


        public ColorPage()
        {
            InitializeComponent();

            UpdateFontLabel(this.mobjColorFontLabel.Font);
        }

        private void mobjChangeForeColorButton_Click(object sender, EventArgs e)
        {
            //Set initial Color for FontDialog
            this.mobjDemoFontDialog.Color = this.mobjColorFontLabel.ForeColor;
            //Set initial Font for FontDialog
            this.mobjDemoFontDialog.Font = this.mobjColorFontLabel.Font;
            //Show FontDialog
            this.mobjDemoFontDialog.ShowDialog();
        }

        private void mobjDemoFontDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result of FontDialog
            if (mobjDemoFontDialog.DialogResult == DialogResult.OK)
            {
                //Change Font of represented Label to selected Font
                this.mobjColorFontLabel.ForeColor = this.mobjDemoFontDialog.Color;
                this.mobjColorFontLabel.Font = this.mobjDemoFontDialog.Font;
                UpdateFontLabel(this.mobjDemoFontDialog.Font);
            }
        }

        private void UpdateFontLabel(Font newFont)
        {
            if (newFont != null)
            {
                this.mobjColorFontLabel.Text = string.Format("Font selected in the dialog: {0}, {1}pt", newFont.Name, newFont.Size);
            }
        }
    }
}
