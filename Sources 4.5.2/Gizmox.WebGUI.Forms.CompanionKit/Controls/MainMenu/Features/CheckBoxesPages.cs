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

namespace CompanionKit.Controls.MainMenu.Features
{
    public partial class CheckBoxesPages : UserControl
    {
        public CheckBoxesPages()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the openFormWithMainMenuButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openFormWithMainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenuForm form = new MainMenuForm(MainMenuForm.MainMenuSampleTypes.CheckBox);
            form.ShowDialog();
        }
    }
}