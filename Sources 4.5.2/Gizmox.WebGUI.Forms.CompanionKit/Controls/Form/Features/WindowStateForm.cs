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
    public partial class WindowStateForm : Gizmox.WebGUI.Forms.Form
    {
        /// <summary>
        /// Represents current form sate.
        /// </summary>
        private FormWindowState _lastFormState = FormWindowState.Normal;
        
        public WindowStateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles load evemt of the Form.
        /// Sets initial state for the form.
        /// </summary>
        private void WindowStateForm_Load(object sender, EventArgs e)
        {
            FormWindowState defaultFormState = this.WindowState;
            this.mobjComboBox.DataSource = Enum.GetValues(typeof(FormWindowState));
            this.mobjComboBox.SelectedItem = defaultFormState;
            this.mobjMaximizeCheckBox.Checked = this.MaximizeBox;
            this.mobjMinimizeCheckBox.Checked = this.MinimizeBox;
            _lastFormState = this.WindowState;
        }

        /// <summary>
        /// Handles Click event for 'Close' button.
        /// Closes the demonstrated Form.
        /// </summary>
        private void mobjCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles SelectedIndexChanged of the ComboBox with form window state.
        /// Updates the Form Window states.
        /// </summary>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WindowState = (FormWindowState)this.mobjComboBox.SelectedItem;
            this._lastFormState = this.WindowState;
        }

        /// <summary>
        /// Handles CheckedChanged event of the 'Maximize button' CheckBox.
        /// Enables/Disables MaximizeBox of the Form.
        /// </summary>
        private void mobjMaximizeBtnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MaximizeBox = this.mobjMaximizeCheckBox.Checked;
        }

        /// <summary>
        /// Handles CheckedChanged event of the 'Minimize button' CheckBox.
        /// Enables/Disables MinimizeBox of the Form.
        /// </summary>
        private void mobjMinimizeBtnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MinimizeBox = this.mobjMinimizeCheckBox.Checked;
        }

        /// <summary>
        /// Handles Resize event of the Form.
        /// Updates the form window state in ComboBox.
        /// </summary>
        private void WindowStateForm_Resize(object sender, EventArgs e)
        {
            if (this._lastFormState != this.WindowState)
            {
                this.mobjComboBox.SelectedItem = this.WindowState;
                this._lastFormState = this.WindowState;
            }
        }
        

    }
}