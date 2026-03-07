// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DefaultAdministrationLogonControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents default logon mechanism.</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DefaultAdministrationLogonControl : AdministrationLogonControlBase
  {
    private TableLayoutPanel tableLayoutPanel1;
    protected WatermarkTextBox mobjUserNameTextBox;
    protected WatermarkTextBox mobjPasswordTextBox;
    private Label mobjPasswordLabel;
    private Label mobjUserNameLabel;
    private Button mobjLoginButton;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DefaultAdministrationLogonControl" /> class.
    /// </summary>
    public DefaultAdministrationLogonControl()
    {
      this.InitializeComponent();
      this.AutoLoginByQueryArguments();
    }

    /// <summary>
    /// Checks the querystring to see if there is a token for automatic login
    /// </summary>
    private void AutoLoginByQueryArguments()
    {
      if (this.Context.Arguments["token"] == null)
        return;
      string strToken = this.Context.Arguments["token"];
      if (string.IsNullOrEmpty(strToken))
        return;
      DefaultAdministrationLogonControl.AuthenticationToken authenticationToken = new DefaultAdministrationLogonControl.AuthenticationToken(strToken);
      if (authenticationToken.TimeStamp < DateTime.Now)
        return;
      if (authenticationToken.AuthenticationType == DefaultAdministrationLogonControl.AuthenticationType.Windows)
      {
        this.Context.IsLoggedOn = true;
      }
      else
      {
        if (authenticationToken.AuthenticationType != DefaultAdministrationLogonControl.AuthenticationType.Forms)
          return;
        this.mobjUserNameTextBox.Text = authenticationToken.Username;
        this.mobjPasswordTextBox.Text = authenticationToken.Password;
        if (this.Logon())
          return;
        this.mobjUserNameTextBox.Text = this.mobjPasswordTextBox.Text = string.Empty;
      }
    }

    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.mobjLoginButton = (Button) new AdministrationButton();
      this.mobjUserNameTextBox = (WatermarkTextBox) new AdministrationWatermarkTextBox();
      this.mobjPasswordTextBox = (WatermarkTextBox) new AdministrationWatermarkTextBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.mobjLoginButton, 2, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.mobjUserNameTextBox, 1, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.mobjPasswordTextBox, 1, 3);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 7;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(648, 577);
      this.tableLayoutPanel1.TabIndex = 0;
      this.mobjLoginButton.Dock = DockStyle.Fill;
      this.mobjLoginButton.Location = new Point(258, 291);
      this.mobjLoginButton.Name = "mobjLoginButton";
      this.mobjLoginButton.Size = new Size(132, 36);
      this.mobjLoginButton.TabIndex = 0;
      this.mobjLoginButton.Text = SR.GetString("LoginButtonText");
      this.mobjLoginButton.UseVisualStyleBackColor = true;
      this.mobjLoginButton.Click += new EventHandler(this.OnLoginButtonClick);
      this.tableLayoutPanel1.SetColumnSpan((Control) this.mobjUserNameTextBox, 3);
      this.mobjUserNameTextBox.Dock = DockStyle.Fill;
      this.mobjUserNameTextBox.Location = new Point(144, 153);
      this.mobjUserNameTextBox.Name = "mobjUserNameTextBox";
      this.mobjUserNameTextBox.Size = new Size(360, 20);
      this.mobjUserNameTextBox.TabIndex = 1;
      this.mobjUserNameTextBox.EnterKeyDown += new KeyEventHandler(this.TextBox_EnterKeyDown);
      this.mobjUserNameTextBox.Message = SR.GetString("UserNameLabelText");
      this.tableLayoutPanel1.SetColumnSpan((Control) this.mobjPasswordTextBox, 3);
      this.mobjPasswordTextBox.Dock = DockStyle.Fill;
      this.mobjPasswordTextBox.Location = new Point(144, 205);
      this.mobjPasswordTextBox.Name = "mobjPasswordTextBox";
      this.mobjPasswordTextBox.Size = new Size(360, 20);
      this.mobjPasswordTextBox.TabIndex = 2;
      this.mobjPasswordTextBox.PasswordChar = '*';
      this.mobjPasswordTextBox.EnterKeyDown += new KeyEventHandler(this.TextBox_EnterKeyDown);
      this.mobjPasswordTextBox.Message = SR.GetString("PasswordLabelText");
      this.ClientSize = new Size(648, 577);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
    }

    private void TextBox_EnterKeyDown(object objSender, KeyEventArgs objArgs)
    {
      if (!(objSender is TextBox textBox) || string.IsNullOrEmpty(textBox.Text))
        return;
      if (!string.IsNullOrEmpty(this.mobjUserNameTextBox.Text) && !string.IsNullOrEmpty(this.mobjPasswordTextBox.Text))
        this.OnLoginButtonClick((object) null, EventArgs.Empty);
      else if (textBox == this.mobjUserNameTextBox)
        this.mobjPasswordTextBox.Focus();
      else
        this.mobjUserNameTextBox.Focus();
    }

    /// <summary>Handles the Click event of the btn control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnLoginButtonClick(object sender, EventArgs e)
    {
      if (this.Logon())
        return;
      int num = (int) MessageBox.Show(SR.GetString("InvalidUserNameOrPassword"), "VWG Administration", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>Determines whether valid logon data provided.</summary>
    /// <returns>
    ///   <c>true</c> if [is valid login data]; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsValidLogonData()
    {
      AdministrationConfigurationInfo administration = Config.GetInstance().Administration;
      return this.mobjUserNameTextBox.Text.ToLowerInvariant() == administration.LogonUserName.ToLowerInvariant() && this.mobjPasswordTextBox.Text == administration.LogonPassword;
    }

    /// <summary>Gets the name of the current content.</summary>
    /// <returns></returns>
    public override string GetCurrentContentName() => "Administration Login";

    /// <summary>Gets the status.</summary>
    /// <returns></returns>
    public override List<StatusData> GetStatus() => (List<StatusData>) null;

    public class AuthenticationToken
    {
      private DefaultAdministrationLogonControl.AuthenticationType mobjAuthenticationType;
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
        strToken = CommonUtils.Decrypt(strToken, this.mstrEncryptionSaltKey, this.mstrEncryptionVIKey, this.mstrEncryptionPasswordHash);
        string[] strArray1 = strToken.Split('&');
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string str in strArray1)
        {
          char[] chArray = new char[1]{ '=' };
          string[] strArray2 = str.Split(chArray);
          if (strArray2.Length == 2)
            dictionary.Add(strArray2[0], strArray2[1]);
        }
        if (dictionary.ContainsKey("type"))
          this.AuthenticationType = dictionary["type"].ToLower() == "windows" ? DefaultAdministrationLogonControl.AuthenticationType.Windows : DefaultAdministrationLogonControl.AuthenticationType.Forms;
        if (dictionary.ContainsKey("username"))
          this.Username = dictionary["username"];
        if (dictionary.ContainsKey("password"))
          this.Password = dictionary["password"];
        if (!dictionary.ContainsKey("timestamp"))
          return;
        this.TimeStamp = new DateTime(long.Parse(dictionary["timestamp"]));
      }

      /// <summary>
      /// Gets an Encrypted representation of the Authetication Token
      /// </summary>
      /// <returns>Encrypted representation of the Authetication Token</returns>
      public string GetEncryptedString() => CommonUtils.Encrypt(string.Format("type={0}&username={1}&password={2}&timestamp={3}", (object) this.AuthenticationType.ToString().ToLower(), (object) this.Username, (object) this.Password, (object) this.TimeStamp.Ticks), this.mstrEncryptionSaltKey, this.mstrEncryptionVIKey, this.mstrEncryptionPasswordHash);

      /// <summary>The authentication type</summary>
      public DefaultAdministrationLogonControl.AuthenticationType AuthenticationType
      {
        get => this.mobjAuthenticationType;
        set => this.mobjAuthenticationType = value;
      }

      /// <summary>The username</summary>
      public string Username
      {
        get => this.mstrUsername;
        set => this.mstrUsername = value;
      }

      /// <summary>The password</summary>
      public string Password
      {
        get => this.mstrPassword;
        set => this.mstrPassword = value;
      }

      /// <summary>The expiration time stamp</summary>
      public DateTime TimeStamp
      {
        get => this.mdtTimeStamp;
        set => this.mdtTimeStamp = value;
      }
    }

    /// <summary>Authentication type</summary>
    public enum AuthenticationType
    {
      Windows = 1,
      Forms = 2,
    }
  }
}
