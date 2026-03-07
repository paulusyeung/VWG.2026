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

namespace CompanionKit.Controls.StatusBar.Layouts
{
    public partial class Docking : UserControl
    {
        public Docking()
        {
            InitializeComponent();
        }

        private void Docking_Load(object sender, EventArgs e)
        {
            // Fill up the ComboBox with enable docking styles.
            DockStyle mobjDefaultDockStatusBar = this.mobjTestStatusBar.Dock;
            this.mobjDockComboBox.DataSource = Enum.GetValues(typeof(DockStyle));
            this.mobjDockComboBox.SelectedItem = mobjDefaultDockStatusBar;
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox.
        /// Changes docking style for the StatusBar.
        /// </summary>
        private void mobjDockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change docking style of the StatusBar.
            this.mobjTestStatusBar.Dock = (DockStyle)this.mobjDockComboBox.SelectedItem;
        }
    }
}