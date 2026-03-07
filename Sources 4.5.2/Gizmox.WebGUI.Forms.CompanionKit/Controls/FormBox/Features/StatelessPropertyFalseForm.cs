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

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    public partial class StatelessPropertyFalseForm : Form
    {
        public StatelessPropertyFalseForm()
        {
            InitializeComponent();
            // Fill ComboBox with DayOfWeek enumerator values
            cmbDaysOfWeek.DataSource = Enum.GetValues(typeof(DayOfWeek));
        }

        /// <summary>
        /// Handles Click event of Button control
        /// </summary>
        private void btnSet_Click(object sender, EventArgs e)
        {
            // Set selected value of ComboBox as a text for a Label
            lblDayofWeek.Text = cmbDaysOfWeek.SelectedValue.ToString();
        }
    }
}