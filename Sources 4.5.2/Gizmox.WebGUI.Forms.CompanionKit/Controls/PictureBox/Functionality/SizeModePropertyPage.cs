using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.PictureBox.Functionality
{
    public partial class SizeModePropertyPage : UserControl
    {
        public SizeModePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SizeModePropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SizeModePropertyPage_Load(object sender, EventArgs e)
        {
            PictureBoxSizeMode defaultSizeMode = this.mobjPictureBox.SizeMode;
            this.mobjSizeModeComboBox.DataSource = Enum.GetValues(typeof(PictureBoxSizeMode));
            this.mobjSizeModeComboBox.SelectedItem = defaultSizeMode;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjSizeModeComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSizeModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mobjPictureBox.SizeMode = (PictureBoxSizeMode)this.mobjSizeModeComboBox.SelectedItem;

            //this.demoPictureBox.SizeMode = (PictureBoxSizeMode)this.demoPictureBox.SizeMode;
            //this.demoPictureBox.Update();
        }
    }
}