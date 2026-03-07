using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents default logon mechanism.
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    public class DefaultAdministrationLogonControl : AdministrationLogonControlBase
    {
        #region Members

        private TableLayoutPanel tableLayoutPanel1;
        protected WatermarkTextBox mobjUserNameTextBox;
        protected WatermarkTextBox mobjPasswordTextBox;
        Label mobjPasswordLabel;
        Label mobjUserNameLabel;
        Button mobjLoginButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAdministrationLogonControl"/> class.
        /// </summary>
        public DefaultAdministrationLogonControl()
        {
            InitializeComponent();

            AutoLoginByQueryArguments();

        }

        /// <summary>
        /// Checks the querystring to see if there is a token for automatic login
        /// </summary>
        private void AutoLoginByQueryArguments()
        {
            //If there is no token, return
            if (Context.Arguments["token"] == null){
                return;
            }

            //Get the token from the querystring and decrypt it
            string strEncryptedToken = Context.Arguments["token"];
            if (string.IsNullOrEmpty(strEncryptedToken))
            {
                return;
            }

            AuthenticationToken objToken = new AuthenticationToken(strEncryptedToken);

            if (objToken.TimeStamp < DateTime.Now)
            {
                return;
            }

            if (objToken.AuthenticationType == AuthenticationType.Windows)
            {
                this.Context.IsLoggedOn = true;
                return;
            }

            if (objToken.AuthenticationType == AuthenticationType.Forms)
            {
                mobjUserNameTextBox.Text = objToken.Username;
                mobjPasswordTextBox.Text = objToken.Password;
                if (base.Logon() == false)
                {
                    mobjUserNameTextBox.Text = mobjPasswordTextBox.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.mobjLoginButton = new Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationButton();
            this.mobjUserNameTextBox = new AdministrationWatermarkTextBox();
            this.mobjPasswordTextBox = new AdministrationWatermarkTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mobjLoginButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.mobjUserNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mobjPasswordTextBox, 1, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(648, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mobjLoginButton
            // 
            this.mobjLoginButton.Dock = DockStyle.Fill;
            this.mobjLoginButton.Location = new System.Drawing.Point(258, 291);
            this.mobjLoginButton.Name = "mobjLoginButton";
            this.mobjLoginButton.Size = new System.Drawing.Size(132, 36);
            this.mobjLoginButton.TabIndex = 0;
            this.mobjLoginButton.Text = SR.GetString("LoginButtonText");
            this.mobjLoginButton.UseVisualStyleBackColor = true;
            this.mobjLoginButton.Click += new EventHandler(OnLoginButtonClick);
            // 
            // mobjUserNameTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.mobjUserNameTextBox, 3);
            this.mobjUserNameTextBox.Dock = DockStyle.Fill;
            this.mobjUserNameTextBox.Location = new System.Drawing.Point(144, 153);
            this.mobjUserNameTextBox.Name = "mobjUserNameTextBox";
            this.mobjUserNameTextBox.Size = new System.Drawing.Size(360, 20);
            this.mobjUserNameTextBox.TabIndex = 1;
            this.mobjUserNameTextBox.EnterKeyDown += TextBox_EnterKeyDown;
            this.mobjUserNameTextBox.Message = SR.GetString("UserNameLabelText");
            // 
            // mobjPasswordTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.mobjPasswordTextBox, 3);
            this.mobjPasswordTextBox.Dock = DockStyle.Fill;
            this.mobjPasswordTextBox.Location = new System.Drawing.Point(144, 205);
            this.mobjPasswordTextBox.Name = "mobjPasswordTextBox";
            this.mobjPasswordTextBox.Size = new System.Drawing.Size(360, 20);
            this.mobjPasswordTextBox.TabIndex = 2;
            this.mobjPasswordTextBox.PasswordChar = '*';
            this.mobjPasswordTextBox.EnterKeyDown += TextBox_EnterKeyDown;
            this.mobjPasswordTextBox.Message = SR.GetString("PasswordLabelText");
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(648, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        void TextBox_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            TextBox objTextBox = objSender as TextBox;
            
            if (objTextBox != null && !string.IsNullOrEmpty(objTextBox.Text))
            {
                if (!string.IsNullOrEmpty(mobjUserNameTextBox.Text) && !string.IsNullOrEmpty(mobjPasswordTextBox.Text))
                {
                    OnLoginButtonClick(null, EventArgs.Empty);
                }
                else if (objTextBox == mobjUserNameTextBox)
                {
                    mobjPasswordTextBox.Focus();
                }
                else
                {
                    mobjUserNameTextBox.Focus();
                }
            }
        }        

        /// <summary>
        /// Handles the Click event of the btn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnLoginButtonClick(object sender, EventArgs e)
        {
            if (!base.Logon())
            {
                MessageBox.Show(SR.GetString("InvalidUserNameOrPassword"), "VWG Administration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Determines whether valid logon data provided.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is valid login data]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValidLogonData()
        {
            AdministrationConfigurationInfo objInfo = Config.GetInstance().Administration;
            return mobjUserNameTextBox.Text.ToLowerInvariant() == objInfo.LogonUserName.ToLowerInvariant() && mobjPasswordTextBox.Text == objInfo.LogonPassword;
        }

        /// <summary>
        /// Gets the name of the current content.
        /// </summary>
        /// <returns></returns>
        public override string GetCurrentContentName()
        {
            return "Administration Login";
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns></returns>
        public override List<StatusData> GetStatus()
        {
            return null;
        }


        public class AuthenticationToken
        {
            private AuthenticationType mobjAuthenticationType;
            private string mstrUsername;
            private string mstrPassword;
            private DateTime mdtTimeStamp;
            private readonly string mstrEncryptionPasswordHash = "P@ssw0rd";
            private readonly string mstrEncryptionSaltKey = "h@$d5Ju8";
            private readonly string mstrEncryptionVIKey = "@h48sk37dER925G6";

            public AuthenticationToken()
            {

            }

            /// <summary>
            /// Constructor - gets a token string and parse its content
            /// </summary>
            /// <param name="strToken">the token string to be parsed</param>
            public AuthenticationToken(string strToken)
            {
                strToken = CommonUtils.Decrypt(strToken, mstrEncryptionSaltKey, mstrEncryptionVIKey, mstrEncryptionPasswordHash);

                string[] objTokenParams = strToken.Split('&');

                Dictionary<string, string> objTokenParamsDictionary = new Dictionary<string, string>();
                foreach (string strTokenParam in objTokenParams)
                {
                    string[] objTokenParamData = strTokenParam.Split('=');
                    if (objTokenParamData.Length == 2)
                    {
                        objTokenParamsDictionary.Add(objTokenParamData[0], objTokenParamData[1]);
                    }
                }

                if (objTokenParamsDictionary.ContainsKey("type"))
                {
                    AuthenticationType = objTokenParamsDictionary["type"].ToLower() == "windows" ? AuthenticationType.Windows : AuthenticationType.Forms;
                }
                if (objTokenParamsDictionary.ContainsKey("username"))
                {
                    Username = objTokenParamsDictionary["username"];
                }
                if (objTokenParamsDictionary.ContainsKey("password"))
                {
                    Password = objTokenParamsDictionary["password"];
                }
                if (objTokenParamsDictionary.ContainsKey("timestamp"))
                {
                    TimeStamp = new DateTime(long.Parse(objTokenParamsDictionary["timestamp"]));
                }
            }

            /// <summary>
            /// Gets an Encrypted representation of the Authetication Token
            /// </summary>
            /// <returns>Encrypted representation of the Authetication Token</returns>
            public string GetEncryptedString()
            {
                string strData = string.Format("type={0}&username={1}&password={2}&timestamp={3}", AuthenticationType.ToString().ToLower(), Username, Password, TimeStamp.Ticks);
                return CommonUtils.Encrypt(strData, mstrEncryptionSaltKey, mstrEncryptionVIKey, mstrEncryptionPasswordHash);
            }

            /// <summary>
            /// The authentication type
            /// </summary>
            public AuthenticationType AuthenticationType
            {
                get { return mobjAuthenticationType; }
                set { mobjAuthenticationType = value; }
            }

            /// <summary>
            /// The username
            /// </summary>
            public string Username
            {
                get { return mstrUsername; }
                set { mstrUsername = value; }
            }

            /// <summary>
            /// The password
            /// </summary>
            public string Password
            {
                get { return mstrPassword; }
                set { mstrPassword = value; }
            }

            /// <summary>
            /// The expiration time stamp
            /// </summary>
            public DateTime TimeStamp
            {
                get { return mdtTimeStamp; }
                set { mdtTimeStamp = value; }
            }


        }

        /// <summary>
        /// Authentication type
        /// </summary>
        public enum AuthenticationType
        {
            Windows = 1,
            Forms = 2,
        }
    }
}
