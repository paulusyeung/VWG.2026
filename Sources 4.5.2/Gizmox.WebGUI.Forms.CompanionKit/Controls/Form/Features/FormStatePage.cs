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

namespace CompanionKit.Controls.Form.Features
{
    public partial class FormStatePage : UserControl
    {
        public FormStatePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fills up the ComboBox with window states.
        /// </summary>
        private void FormStatePage_Load(object sender, EventArgs e)
        {
            this.mobjComboBox.DataSource = Enum.GetValues(typeof(FormWindowState));
            this.mobjMaximizeBtnCheckBox.Checked = true;
            this.mobjMinimizeBtnCheckBox.Checked = true;
        }

        /// <summary>
        /// Opens the form with defined state and enable/disable maximize 
        /// and minimize boxes according to checked state of 'Maximize button' and
        /// 'Minimize button' CheckBoxes.
        /// </summary>
        private void mobjOpenFormWindowState_Click(object sender, EventArgs e)
        {
            WindowStateForm mobjForm = new WindowStateForm();
            mobjForm.MaximizeBox = this.mobjMaximizeBtnCheckBox.Checked;
            mobjForm.MinimizeBox = this.mobjMinimizeBtnCheckBox.Checked;
            mobjForm.WindowState = (FormWindowState)this.mobjComboBox.SelectedItem;
            mobjForm.ShowDialog();
        }
    }
}