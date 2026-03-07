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
    public partial class MDIFormPage : UserControl
    {
        private MDIParentForm _mdiForm;
        
        public MDIFormPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens MDI Parent Form.
        /// </summary>
        private void mobjOpenMDIFormBtn_Click(object sender, EventArgs e)
        {
            _mdiForm = new MDIParentForm();
            _mdiForm.Closed +=new EventHandler(_mdiForm_Closed);
            _mdiForm.Show();
        }

        /// <summary>
        /// Handles Closed event of the MDI Parent form. 
        /// Updates values property that represents shortcut on the MDI Parent Form.
        /// </summary>
        private void _mdiForm_Closed(object sender, EventArgs e)
        {
            _mdiForm = null;
        }

        /// <summary>
        /// Handles VisibleChanged event of the example user control.
        /// Closes MDI Parent Form after switch to an another example.
        /// </summary>
        private void MDIFormPage_VisibleChanged(object sender, EventArgs e)
        {
            if (_mdiForm != null)
            {
                _mdiForm.Close();
            }
        }
    }
}