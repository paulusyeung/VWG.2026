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

namespace CompanionKit.Controls.Form.Programming
{
    public partial class ActivateHandlingPage : UserControl
    {
        /// <summary>
        /// Represents list of the opened Modeless Forms.
        /// </summary>
        List<Gizmox.WebGUI.Forms.Form> _openedForms = new List<Gizmox.WebGUI.Forms.Form>();
        
        public ActivateHandlingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens modeless form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            ActivatingForm form = new ActivatingForm();
            _openedForms.Add(form);
            form.Closed += new EventHandler(form_Closed);
            form.Show();
        }

        /// <summary>
        /// Handles Closed event of the modeless form.
        /// Removes the Modeless form from list.
        /// </summary>
        private void form_Closed(object sender, EventArgs e)
        {
            _openedForms.Remove(sender as Gizmox.WebGUI.Forms.Form);
        }

        /// <summary>
        /// Handles VisibleChanged event of the example user control.
        /// Closes all modeless Form after switch to an another example.
        /// </summary>
        private void ActivateHandlingPage_VisibleChanged(object sender, EventArgs e)
        {
            foreach (global::Gizmox.WebGUI.Forms.Form form in (Gizmox.WebGUI.Forms.Form[])_openedForms.ToArray().Clone())
            {
                form.Close();
            }
        }
    }
}