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
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	internal abstract class WizardForm : Form
	{
		private int mintCurrentStepIndex = -1;

		private WizardStep mobjCurrentStep;

		private Button mobjBackButton;

		private Button mobjCancelButton;

		private Button mobjFinishButton;

		private Button mobjNextButton;

		private Panel mobjButtonsSection;

		private Panel mobjContentSection;

		private Label mobjValidationMessage;

		private IList mobjSteps;

		/// 
		/// Gets the current step.
		/// </summary>
		protected WizardStep CurrentStep => mobjCurrentStep;

		/// 
		/// Gets a value indicating whether this instance can complete.
		/// </summary>
		/// 
		/// 	true</c> if this instance can complete; otherwise, false</c>.
		/// </value>
		protected virtual bool CanComplete => false;

		/// 
		/// Gets a value indicating whether this instance can cancel.
		/// </summary>
		/// 
		/// 	true</c> if this instance can cancel; otherwise, false</c>.
		/// </value>
		public bool CanCancel => true;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WizardForm" /> class.
		/// </summary>
		public WizardForm()
		{
			InitializeComponent();
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			InitializeSteps();
		}

		/// 
		/// Initializes the steps.
		/// </summary>
		private void InitializeSteps()
		{
			IList steps = GetSteps();
			WizardStep wizardStep = null;
			for (int i = 0; i < steps.Count; i++)
			{
				WizardStep wizardStep2 = steps[i];
				wizardStep2.SetPreviousStep(wizardStep);
				wizardStep2.SetWizardForm(this);
				wizardStep?.SetNextStep(wizardStep2);
				wizardStep = wizardStep2;
			}
			NavigateToPage(steps[0]);
		}

		/// 
		/// Navigates to page.
		/// </summary>
		/// <param name="objNextPage">The obj next page.</param>
		private void NavigateToPage(WizardStep objNextPage)
		{
			if (mobjCurrentStep != null)
			{
				mobjCurrentStep = null;
				mobjContentSection.Controls.Clear();
			}
			if (objNextPage != null)
			{
				mobjCurrentStep = objNextPage;
				mobjCurrentStep.Visible = true;
				mobjCurrentStep.Activate();
				Text = mobjCurrentStep.Caption;
			}
			UpdateWizard();
			if (mobjCurrentStep != null)
			{
				mobjContentSection.Controls.Add(mobjCurrentStep);
				mobjCurrentStep.Focus();
			}
		}

		/// 
		/// Determines whether [is first step].
		/// </summary>
		/// 
		///   true</c> if [is first step]; otherwise, false</c>.
		/// </returns>
		private bool IsFirstStep()
		{
			return mintCurrentStepIndex == 0;
		}

		/// 
		/// Determines whether [is last step].
		/// </summary>
		/// 
		///   true</c> if [is last step]; otherwise, false</c>.
		/// </returns>
		private bool IsLastStep()
		{
			return mintCurrentStepIndex == mobjSteps.Count - 1;
		}

		/// 
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			mobjBackButton = new Button();
			mobjCancelButton = new Button();
			mobjFinishButton = new Button();
			mobjNextButton = new Button();
			mobjButtonsSection = new Panel();
			mobjContentSection = new Panel();
			mobjValidationMessage = new Label();
			mobjValidationMessage.Dock = DockStyle.Top;
			mobjValidationMessage.Height = 40;
			mobjValidationMessage.TextAlign = ContentAlignment.TopLeft;
			mobjContentSection.Dock = DockStyle.Fill;
			mobjBackButton.Dock = DockStyle.Right;
			mobjBackButton.Click += mobjBackButton_Click;
			mobjBackButton.Text = "< Back";
			mobjFinishButton.Text = "Finish";
			mobjFinishButton.Dock = DockStyle.Right;
			mobjFinishButton.Click += mobjFinishButton_Click;
			mobjCancelButton.Dock = DockStyle.Right;
			mobjCancelButton.Text = "Cancel";
			mobjCancelButton.Click += mobjCancelButton_Click;
			mobjNextButton.Dock = DockStyle.Right;
			mobjNextButton.Text = "Next >";
			mobjNextButton.Click += mobjNextButton_Click;
			mobjButtonsSection.Height = 40;
			mobjButtonsSection.DockPadding.Top = 10;
			mobjButtonsSection.DockPadding.Bottom = 10;
			mobjButtonsSection.Dock = DockStyle.Bottom;
			mobjButtonsSection.Controls.Add(mobjBackButton);
			mobjButtonsSection.Controls.Add(GetHorizontalPaddingPanel(DockStyle.Right, 10));
			mobjButtonsSection.Controls.Add(mobjNextButton);
			mobjButtonsSection.Controls.Add(GetHorizontalPaddingPanel(DockStyle.Right, 20));
			mobjButtonsSection.Controls.Add(mobjFinishButton);
			mobjButtonsSection.Controls.Add(GetHorizontalPaddingPanel(DockStyle.Right, 30));
			mobjButtonsSection.Controls.Add(mobjCancelButton);
			BorderStyle = BorderStyle.FixedSingle;
			MinimumSize = new Size(500, 400);
			base.Size = new Size(500, 400);
			base.Controls.Add(mobjContentSection);
			base.Controls.Add(mobjValidationMessage);
			base.Controls.Add(mobjButtonsSection);
		}

		/// 
		/// Handles the Click event of the mobjFinishButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjFinishButton_Click(object sender, EventArgs e)
		{
			if (mobjCurrentStep.OnNext())
			{
				CompleteWizard();
			}
		}

		/// 
		/// Handles the Click event of the mobjNextButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjNextButton_Click(object sender, EventArgs e)
		{
			if (mobjCurrentStep.OnNext())
			{
				NavigateToPage(mobjCurrentStep.NextPage);
			}
		}

		/// 
		/// Handles the Click event of the mobjCancelButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjCancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// 
		/// Handles the Click event of the mobjBackButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjBackButton_Click(object sender, EventArgs e)
		{
			if (mobjCurrentStep.OnPrevious())
			{
				NavigateToPage(mobjCurrentStep.PreviousPage);
			}
		}

		/// 
		/// Gets the horizontal padding panel.
		/// </summary>
		/// <param name="enmDockStyle">The enm dock style.</param>
		/// <param name="intWidth">Width of the int.</param>
		/// </returns>
		private static Panel GetHorizontalPaddingPanel(DockStyle enmDockStyle, int intWidth)
		{
			Panel panel = new Panel();
			panel.Width = intWidth;
			panel.Dock = enmDockStyle;
			return panel;
		}

		protected abstract IList GetSteps();

		protected abstract void CompleteWizard();

		/// 
		/// Updates the wizard.
		/// </summary>
		protected internal void UpdateWizard()
		{
			bool flag = false;
			if (mobjCurrentStep != null)
			{
				flag = mobjCurrentStep.CanNavigateNext;
				mobjNextButton.Enabled = flag && mobjCurrentStep.NextPage != null;
				mobjBackButton.Enabled = mobjCurrentStep.CanNavigatePrevious && mobjCurrentStep.PreviousPage != null;
			}
			mobjFinishButton.Enabled = flag && CanComplete;
			mobjCancelButton.Enabled = CanCancel;
			if (!mobjNextButton.Enabled && mobjFinishButton.Enabled)
			{
				base.AcceptButton = mobjFinishButton;
			}
			else
			{
				base.AcceptButton = mobjNextButton;
			}
			SetMessage("", MessageType.Error);
		}

		/// 
		/// Sets the message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="enmMessageType">Type of the enm message.</param>
		internal void SetMessage(string strMessage, MessageType enmMessageType)
		{
			if (!string.IsNullOrEmpty(strMessage))
			{
				mobjValidationMessage.Text = strMessage;
				switch (enmMessageType)
				{
				case MessageType.Information:
					mobjValidationMessage.ForeColor = Color.Green;
					break;
				case MessageType.Error:
					mobjValidationMessage.ForeColor = Color.Red;
					break;
				}
			}
			else
			{
				mobjValidationMessage.Text = string.Empty;
			}
		}
	}
}
