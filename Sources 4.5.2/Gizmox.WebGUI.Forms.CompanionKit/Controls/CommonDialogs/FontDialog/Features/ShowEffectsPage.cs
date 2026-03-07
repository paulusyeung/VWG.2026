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
    public partial class ShowEffectsPage : UserControl
    {
        public ShowEffectsPage()
        {
            InitializeComponent();
        }

        private void mobjDemoFontDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result of FontDialog
            if (this.mobjDemoFontDialog.DialogResult == DialogResult.OK)
            {
                //Change text of represented Label to selected Font
                this.mobjShowEffectsLabel.Font = this.mobjDemoFontDialog.Font;
                UpdateTestOfLabel(this.mobjShowEffectsLabel.Font);
            }
        }

        private void mobjShowEffectsButton_Click(object sender, EventArgs e)
        {
            //Set initial Font for FontDialog
            this.mobjDemoFontDialog.Font = this.mobjShowEffectsLabel.Font;
            //Set FontDialog ShowEffects property value according to checked state of CheckBox
            this.mobjDemoFontDialog.ShowEffects = this.mobjAllowShowEffectsCheckBox.Checked;
            //Show FontDialog
            this.mobjDemoFontDialog.ShowDialog();
        }

        /// <summary>
        /// Updates text of represented label with name and size of selected Font.
        /// </summary>
        /// <param name="newFont">selected font in FontDialog</param>
        private void UpdateTestOfLabel(Font newFont)
        {
            this.mobjShowEffectsLabel.Text = string.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size);
        }

        private void ShowEffectsPage_Load(object sender, EventArgs e)
        {
            //Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(this.mobjShowEffectsLabel.Font);
        }
    }
}
