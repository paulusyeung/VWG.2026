#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Represents default logon mechanism.
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class DefaultAdministrationLogonControl : AdministrationLogonControlBase
	{
		public class AuthenticationToken
		{
			private AuthenticationType mobjAuthenticationType;

			private string mstrUsername;

			private string mstrPassword;

			private DateTime mdtTimeStamp;

			private readonly string mstrEncryptionPasswordHash = "P@ssw0rd";

			private readonly string mstrEncryptionSaltKey = "h@$d5Ju8";

			private readonly string mstrEncryptionVIKey = "@h48sk37dER925G6";

			/// 
			/// The authentication type
			/// </summary>
			public AuthenticationType AuthenticationType
			{
				get
				{
					return mobjAuthenticationType;
				}
				set
				{
					mobjAuthenticationType = value;
				}
			}

			/// 
			/// The username
			/// </summary>
			public string Username
			{
				get
				{
					return mstrUsername;
				}
				set
				{
					mstrUsername = value;
				}
			}

			/// 
			/// The password
			/// </summary>
			public string Password
			{
				get
				{
					return mstrPassword;
				}
				set
				{
					mstrPassword = value;
				}
			}

			/// 
			/// The expiration time stamp
			/// </summary>
			public DateTime TimeStamp
			{
				get
				{
					return mdtTimeStamp;
				}
				set
				{
					mdtTimeStamp = value;
				}
			}

			public AuthenticationToken()
			{
			}

			/// 
			/// Constructor - gets a token string and parse its content
			/// </summary>
			/// <param name="strToken">the token string to be parsed</param>
			public AuthenticationToken(string strToken)
			{
				strToken = CommonUtils.Decrypt(strToken, mstrEncryptionSaltKey, mstrEncryptionVIKey, mstrEncryptionPasswordHash);
				string[] array = strToken.Split('&');
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string[] array2 = array;
				foreach (string text in array2)
				{
					string[] array3 = text.Split('=');
					if (array3.Length == 2)
					{
						dictionary.Add(array3[0], array3[1]);
					}
				}
				if (dictionary.ContainsKey("type"))
				{
					AuthenticationType = ((dictionary["type"].ToLower() == "windows") ? AuthenticationType.Windows : AuthenticationType.Forms);
				}
				if (dictionary.ContainsKey("username"))
				{
					Username = dictionary["username"];
				}
				if (dictionary.ContainsKey("password"))
				{
					Password = dictionary["password"];
				}
				if (dictionary.ContainsKey("timestamp"))
				{
					TimeStamp = new DateTime(long.Parse(dictionary["timestamp"]));
				}
			}

			/// 
			/// Gets an Encrypted representation of the Authetication Token
			/// </summary>
			/// Encrypted representation of the Authetication Token</returns>
			public string GetEncryptedString()
			{
				string strPlainText = $"type={AuthenticationType.ToString().ToLower()}&username={Username}&password={Password}&timestamp={TimeStamp.Ticks}";
				return CommonUtils.Encrypt(strPlainText, mstrEncryptionSaltKey, mstrEncryptionVIKey, mstrEncryptionPasswordHash);
			}
		}

		/// 
		/// Authentication type
		/// </summary>
		public enum AuthenticationType
		{
			Windows = 1,
			Forms
		}

		private TableLayoutPanel tableLayoutPanel1;

		protected WatermarkTextBox mobjUserNameTextBox;

		protected WatermarkTextBox mobjPasswordTextBox;

		private Label mobjPasswordLabel;

		private Label mobjUserNameLabel;

		private Button mobjLoginButton;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DefaultAdministrationLogonControl" /> class.
		/// </summary>
		public DefaultAdministrationLogonControl()
		{
			InitializeComponent();
			AutoLoginByQueryArguments();
		}

		/// 
		/// Checks the querystring to see if there is a token for automatic login
		/// </summary>
		private void AutoLoginByQueryArguments()
		{
			if (Context.Arguments["token"] == null)
			{
				return;
			}
			string text = Context.Arguments["token"];
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			AuthenticationToken authenticationToken = new AuthenticationToken(text);
			if (authenticationToken.TimeStamp < DateTime.Now)
			{
				return;
			}
			if (authenticationToken.AuthenticationType == AuthenticationType.Windows)
			{
				Context.IsLoggedOn = true;
			}
			else if (authenticationToken.AuthenticationType == AuthenticationType.Forms)
			{
				mobjUserNameTextBox.Text = authenticationToken.Username;
				mobjPasswordTextBox.Text = authenticationToken.Password;
				if (!Logon())
				{
					WatermarkTextBox watermarkTextBox = mobjUserNameTextBox;
					string text2 = (mobjPasswordTextBox.Text = string.Empty);
					watermarkTextBox.Text = text2;
				}
			}
		}

		/// 
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel1 = new TableLayoutPanel();
			mobjLoginButton = new AdministrationButton();
			mobjUserNameTextBox = new AdministrationWatermarkTextBox();
			mobjPasswordTextBox = new AdministrationWatermarkTextBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			tableLayoutPanel1.ColumnCount = 5;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114f));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138f));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114f));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			tableLayoutPanel1.Controls.Add(mobjLoginButton, 2, 5);
			tableLayoutPanel1.Controls.Add(mobjUserNameTextBox, 1, 1);
			tableLayoutPanel1.Controls.Add(mobjPasswordTextBox, 1, 3);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			tableLayoutPanel1.Size = new Size(648, 577);
			tableLayoutPanel1.TabIndex = 0;
			mobjLoginButton.Dock = DockStyle.Fill;
			mobjLoginButton.Location = new Point(258, 291);
			mobjLoginButton.Name = "mobjLoginButton";
			mobjLoginButton.Size = new Size(132, 36);
			mobjLoginButton.TabIndex = 0;
			mobjLoginButton.Text = SR.GetString("LoginButtonText");
			mobjLoginButton.UseVisualStyleBackColor = true;
			mobjLoginButton.Click += OnLoginButtonClick;
			tableLayoutPanel1.SetColumnSpan(mobjUserNameTextBox, 3);
			mobjUserNameTextBox.Dock = DockStyle.Fill;
			mobjUserNameTextBox.Location = new Point(144, 153);
			mobjUserNameTextBox.Name = "mobjUserNameTextBox";
			mobjUserNameTextBox.Size = new Size(360, 20);
			mobjUserNameTextBox.TabIndex = 1;
			mobjUserNameTextBox.EnterKeyDown += TextBox_EnterKeyDown;
			mobjUserNameTextBox.Message = SR.GetString("UserNameLabelText");
			tableLayoutPanel1.SetColumnSpan(mobjPasswordTextBox, 3);
			mobjPasswordTextBox.Dock = DockStyle.Fill;
			mobjPasswordTextBox.Location = new Point(144, 205);
			mobjPasswordTextBox.Name = "mobjPasswordTextBox";
			mobjPasswordTextBox.Size = new Size(360, 20);
			mobjPasswordTextBox.TabIndex = 2;
			mobjPasswordTextBox.PasswordChar = '*';
			mobjPasswordTextBox.EnterKeyDown += TextBox_EnterKeyDown;
			mobjPasswordTextBox.Message = SR.GetString("PasswordLabelText");
			base.ClientSize = new Size(648, 577);
			base.Controls.Add(tableLayoutPanel1);
			base.Name = "Form1";
			Text = "Form1";
			tableLayoutPanel1.ResumeLayout(blnPerformLayout: false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(blnPerformLayout: false);
		}

		private void TextBox_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			if (objSender is TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
			{
				if (!string.IsNullOrEmpty(mobjUserNameTextBox.Text) && !string.IsNullOrEmpty(mobjPasswordTextBox.Text))
				{
					OnLoginButtonClick(null, EventArgs.Empty);
				}
				else if (textBox == mobjUserNameTextBox)
				{
					mobjPasswordTextBox.Focus();
				}
				else
				{
					mobjUserNameTextBox.Focus();
				}
			}
		}

		/// 
		/// Handles the Click event of the btn control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnLoginButtonClick(object sender, EventArgs e)
		{
			if (!Logon())
			{
				MessageBox.Show(SR.GetString("InvalidUserNameOrPassword"), "VWG Administration", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// 
		/// Determines whether valid logon data provided.
		/// </summary>
		/// 
		///   true</c> if [is valid login data]; otherwise, false</c>.
		/// </returns>
		public override bool IsValidLogonData()
		{
			AdministrationConfigurationInfo administration = Config.GetInstance().Administration;
			return mobjUserNameTextBox.Text.ToLowerInvariant() == administration.LogonUserName.ToLowerInvariant() && mobjPasswordTextBox.Text == administration.LogonPassword;
		}

		/// 
		/// Gets the name of the current content.
		/// </summary>
		/// </returns>
		public override string GetCurrentContentName()
		{
			return "Administration Login";
		}

		/// 
		/// Gets the status.
		/// </summary>
		/// </returns>
		public override List<object> GetStatus()
		{
			return null;
		}
	}
}
