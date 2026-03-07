#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Text.RegularExpressions;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario
{
    public partial class ucPasswordStrengthChecker : UserControl
    {
        // Public property that is used for retrieving password entered
        public string Password 
        {
            // Get password TextBox text value
            get { return this.tbPassword.Text; }
        }

        public ucPasswordStrengthChecker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the the 'Check' button
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Check if password is entered
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                // Show warning message
                MessageBox.Show("Please enter the password!");
                return;
            }

            // Save the password entered into local variable
            string password = tbPassword.Text;
            // Create regular expression for strong password
            Regex strongPattern = new Regex(@"^(?=.*[a-z].*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*\W.*\W)[a-zA-Z0-9\S]{9,}$");
            // Create regular expression for good password
            Regex goodPattern = new Regex(@"^(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{7,30}$");

            // Check if password matches the strong password pattern
            if (strongPattern.Match(password).Success)
            {
                // Change backgtound color for label
                lblResult.BackColor = Color.LightGreen;
                // Change text for label
                lblResult.Text = "Strong password";
            }
            // Check if password matches the good password pattern
            else if (goodPattern.Match(password).Success)
            {
                // Change backgtound color for label
                lblResult.BackColor = Color.Yellow;
                // Change text for label
                lblResult.Text = "Good password";
            }
            else
            {
                // Change backgtound color for label
                lblResult.BackColor = Color.LightCoral;
                // Change text for label
                lblResult.Text = "Weak password";
            }

            // Show label
            lblResult.Visible = true;
            // Show 'Help' button
            btnHelp.Visible = true;
        }

        /// <summary>
        /// Handles Click event of the 'Help' button
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Set message text for help window
            string helpMessage = @"Strong password: requires at least two lowercase letters, 
two uppercase letters, two digits, and two special characters. 
There must be a minimum of 9 characters total, and no white space
characters are allowed.

Good password: requires at least 1 lower case, 1 upper case, 
1 numeric, 1 non-word. There must be a minimum of 7 characters 
total, and no white space characters are allowed.";

            // Show help window
            MessageBox.Show(helpMessage, "Help topic", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
        }
    }
}