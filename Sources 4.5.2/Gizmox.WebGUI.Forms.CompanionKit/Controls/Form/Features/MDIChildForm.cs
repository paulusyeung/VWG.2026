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
    public partial class MDIChildForm : Gizmox.WebGUI.Forms.Form
    {
        /// <summary>
        /// Represents the MDI Child Form
        /// </summary>
        private int formIndex;
       
        public MDIChildForm()
        {
            InitializeComponent();

            // Update form name and text of label with MDI child form index
            this.Text += idxChildForm;
            this.mobjLabel.Text += idxChildForm;
            formIndex = idxChildForm;
        }

        private void mobjButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "The button is clicked", "Button Click!");
        }

       
        /// <summary>
        /// Handles EnabledChanged event of the form
        /// </summary>
        private void MDIChildForm_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
            {
                mobjLabel.Text = "This is Enable MDI Child Form #" + formIndex;
            }
            else
            {
                mobjLabel.Text = "This is Disable MDI Child Form #" + formIndex;
            }
        }
    }
}