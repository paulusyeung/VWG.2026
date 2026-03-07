using System;
using System.Web;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Authentication;

namespace Gizmox.WebGUI.Forms.Access
{
	public partial class Logon : LogonForm
	{
		// Turn ON login - despite that we are running locally - to check logon
		private static bool mblnLogonLocally = false;

		public Logon()
		{
			InitializeComponent();

			// Avoid logon on local machines if not asked explicitly
			if (!mblnLogonLocally)
			{
				if (Context.HttpContext != null && Context.HttpContext.Request.IsLocal)
				{
					Context.Session.IsLoggedOn = true;
					this.Close();
				}
			}
		}

		private void Logon_Load(object sender, EventArgs e)
		{
            // If all the three cookies "Username", "Password" and "Lang" contain valid values.
            if (!String.IsNullOrEmpty(Context.Cookies["Username"]) &&
                !String.IsNullOrEmpty(Context.Cookies["Password"]) )
            {
                // Setting the values of the TextBoxes to the values in the cookies.
                mobjtxtUsername.Text = Context.Cookies["Username"];
                mobjtxtPassword.Text = Context.Cookies["Password"];

                // Setting the 'Save Password' CheckBox to be checked.
                mobjChkRemember.Checked = true;

				// Set focus on logon button to save tab moves
				mobjCmdLogon.Focus();
            }
		}

		/// <summary>
		/// Logon button pressed, try to logon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjCmdLogon_Click(object sender, EventArgs e)
		{
			if (ValidateInput())
			{
				User objUser = LogonController.Validate(mobjtxtUsername.Text, mobjtxtPassword.Text);
				if (objUser == null)
				{
					lblError.Text = "Authorization failed.";
					lblError.Visible =  true;
					mobjtxtPassword.Text = string.Empty;
					mobjtxtPassword.Focus();
				}
				else
				{
					Complete(true);
				}
			}
		}
		
		private void mobjCmdCancel_Click(object sender, EventArgs e)
		{
			Complete(false);
		}

		/// <summary>
		/// Completes with the specified status of authorization.
		/// </summary>
		private void Complete(bool blnAuthorized)
		{
			Context.Session.IsLoggedOn = blnAuthorized;
			
			// Goto to CK presentation page if cancelled the logon
			if (!blnAuthorized)
			{
				this.Context.Redirect("Main.wgx");
			}
            // If the 'Save Password' CheckBox is checked and both TextBoxes contain a valid value.
            else if (mobjChkRemember.Checked &&
                !String.IsNullOrEmpty(mobjtxtUsername.Text) &&
                !String.IsNullOrEmpty(mobjtxtPassword.Text))
            {
                // The values of the "Username" and "Password" cookies are set to the values of the relevant TextBoxes.
                HttpContext.Current.Response.Cookies["Username"].Value   = mobjtxtUsername.Text;
                HttpContext.Current.Response.Cookies["Username"].Expires = DateTime.Now.AddYears(1);

                HttpContext.Current.Response.Cookies["Password"].Value   = mobjtxtPassword.Text;
                HttpContext.Current.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                // The values of all the cookies are set to an empty string.
                Context.Cookies["Username"] = String.Empty;
                Context.Cookies["Password"] = String.Empty;
            }


			this.Close();
		}

		/// <summary>
		/// Validates the input username/password and displays error message
		/// </summary>
		/// <returns>True if successfully validated otherwise false</returns>
		private bool ValidateInput()
		{
			string strError = string.Empty;
			if (String.IsNullOrEmpty(mobjtxtUsername.Text))
			{
				strError = "The username can't be empty.";
				mobjtxtUsername.Focus();
			}
			else if (String.IsNullOrEmpty(mobjtxtPassword.Text))
			{
				strError = "The password can't be empty.";
				mobjtxtPassword.Focus();
			}
			
			lblError.Text = strError;
			lblError.Visible =  strError.Length >0;

			return strError.Length == 0;
		}

		// Password field enter pressed - try to logon
		private void mobjtxtPassword_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			mobjCmdLogon_Click(null, null);
		}
	}
}