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
    public partial class ShowHelpPage : UserControl
    {


        public ShowHelpPage()
        {
            InitializeComponent();
        }

        private void mobjDemoFontDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result of FontDialog
            if (this.mobjDemoFontDialog.DialogResult == DialogResult.OK)
            {
                //Change text of represented Label to selected Font
                this.mobjShowHelpLabel.Font = this.mobjDemoFontDialog.Font;
                UpdateTestOfLabel(this.mobjShowHelpLabel.Font);
            }
        }

        private void mobjShowHelpButton_Click(object sender, EventArgs e)
        {
            //Set initial Font for FontDialog
            this.mobjDemoFontDialog.Font = this.mobjShowHelpLabel.Font;
            //Set FontDialog ShowHelp property value according to checked state of CheckBox
            this.mobjDemoFontDialog.ShowHelp = this.mobjAllowShowHelpCheckBox.Checked;
            //Show FontDialog
            this.mobjDemoFontDialog.ShowDialog();
        }

        private void ShowHelpPage_Load(object sender, EventArgs e)
        {
            //Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(this.mobjShowHelpLabel.Font);
        }

        /// <summary>
        /// Updates text of represented label with name and size of selected Font.
        /// </summary>
        /// <param name="newFont">selected font in FontDialog</param>
        private void UpdateTestOfLabel(Font newFont)
        {
            this.mobjShowHelpLabel.Text = string.Format("Font selected in the dialog:: {0}, {1} pt.", newFont.Name, newFont.Size);
        }
    }
}
