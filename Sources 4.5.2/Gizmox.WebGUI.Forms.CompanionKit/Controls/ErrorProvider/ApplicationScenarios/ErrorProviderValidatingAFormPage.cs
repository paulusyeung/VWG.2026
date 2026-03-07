using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Text.RegularExpressions;

namespace CompanionKit.Controls.ErrorProvider.ApplicationScenarios
{
    public partial class ErrorProviderValidatingAFormPage : UserControl
    {
        public ErrorProviderValidatingAFormPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ErrorProviderValidatingAFormPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ErrorProviderValidatingAFormPage_Load(object sender, EventArgs e)
        {
            // Add items to 'Gender' ComboBox
            mobjGenderCB.Items.Add("Male");
            mobjGenderCB.Items.Add("Female");
        }

        /// <summary>
        /// Handles the Click event of the mobjRegisterButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRegisterButton_Click(object sender, EventArgs e)
        {
            // Check if all data entered is valid
            if (this.IsValid())
                // Show success message
                MessageBox.Show("You have successfully registered!");
        }

        /// <summary>
        /// Performs entered data validation
        /// </summary>
        private bool IsValid()
        {
            // Declare variable to return
            bool _isValid = true;
            // Validate First Name entered
            if (mobjFirstNameTextBox.Text == string.Empty)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjFirstNameTextBox, "Please enter First Name");
                _isValid = false;
            }
            else
            {
                // Set success and message on the control
                mobjErrorProviderSuccess.SetError(mobjFirstNameTextBox, "OK");
            }
            // Validate Last Name entered
            if (mobjLastNameTextBox.Text == string.Empty)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjLastNameTextBox, "Please enter Last Name");
                _isValid = false;
            }
            else
            {
                // Set success and message on the control
                mobjErrorProviderSuccess.SetError(mobjLastNameTextBox, "OK");
            }
            // Validate Username entered
            if (mobjUsernameTextBox.Text == string.Empty)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjUsernameTextBox, "Please enter Username");
                _isValid = false;
            }
            else
            {
                // Set success and message on the control
                mobjErrorProviderSuccess.SetError(mobjUsernameTextBox, "OK");
            }
            // Validate Password entered
            if (mobjPasswordTextBox.Text == string.Empty)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjPasswordTextBox, "Please enter Password");
                _isValid = false;
            }
            else
            {
                // Set success and message on the control
                mobjErrorProviderSuccess.SetError(mobjPasswordTextBox, "OK");
            }
            // Validate Gender selected
            if (mobjGenderCB.SelectedItem == null)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjGenderCB, "Please select Gender");
                _isValid = false;
            }
            else
            {
                // Set success and message on the control
                mobjErrorProviderSuccess.SetError(mobjGenderCB, "OK");
            }
            // Validate Email entered
            if (mobjEmailTextBox.Text == string.Empty)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjEmailTextBox, "Please enter Email");
                _isValid = false;
            }
            else
            {
                // Set pattern for Email
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                // Check if Email is valid
                if (!regex.Match(mobjEmailTextBox.Text).Success)
                {
                    // Set error with message on the control
                    mobjErrorProviderFailed.SetError(mobjEmailTextBox, "Please enter correct Email");
                    _isValid = false;
                }
                else
                {
                    // Set success and message on the control
                    mobjErrorProviderSuccess.SetError(mobjEmailTextBox, "OK");
                }
            }
            // Check if terms are agreed
            if (!mobjAgreeTermsCheck.Checked)
            {
                // Set error with message on the control
                mobjErrorProviderFailed.SetError(mobjAgreeTermsCheck, "You have to agree to the terms");
                _isValid = false;
            }
            else
            {
                // Remove error and message from the control
                mobjErrorProviderFailed.SetError(mobjAgreeTermsCheck, "");
            }

            return _isValid;
        }        
    }
}