// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WizardForm
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
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
    private IList<WizardStep> mobjSteps;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WizardForm" /> class.
    /// </summary>
    public WizardForm() => this.InitializeComponent();

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.InitializeSteps();
    }

    /// <summary>Initializes the steps.</summary>
    private void InitializeSteps()
    {
      IList<WizardStep> steps = this.GetSteps();
      WizardStep objPreviousStep = (WizardStep) null;
      for (int index = 0; index < steps.Count; ++index)
      {
        WizardStep objCurrentStep = steps[index];
        objCurrentStep.SetPreviousStep(objPreviousStep);
        objCurrentStep.SetWizardForm(this);
        objPreviousStep?.SetNextStep(objCurrentStep);
        objPreviousStep = objCurrentStep;
      }
      this.NavigateToPage(steps[0]);
    }

    /// <summary>Navigates to page.</summary>
    /// <param name="objNextPage">The obj next page.</param>
    private void NavigateToPage(WizardStep objNextPage)
    {
      if (this.mobjCurrentStep != null)
      {
        this.mobjCurrentStep = (WizardStep) null;
        this.mobjContentSection.Controls.Clear();
      }
      if (objNextPage != null)
      {
        this.mobjCurrentStep = objNextPage;
        this.mobjCurrentStep.Visible = true;
        this.mobjCurrentStep.Activate();
        this.Text = this.mobjCurrentStep.Caption;
      }
      this.UpdateWizard();
      if (this.mobjCurrentStep == null)
        return;
      this.mobjContentSection.Controls.Add((Control) this.mobjCurrentStep);
      this.mobjCurrentStep.Focus();
    }

    /// <summary>Determines whether [is first step].</summary>
    /// <returns>
    ///   <c>true</c> if [is first step]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsFirstStep() => this.mintCurrentStepIndex == 0;

    /// <summary>Determines whether [is last step].</summary>
    /// <returns>
    ///   <c>true</c> if [is last step]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsLastStep() => this.mintCurrentStepIndex == this.mobjSteps.Count - 1;

    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
      this.mobjBackButton = new Button();
      this.mobjCancelButton = new Button();
      this.mobjFinishButton = new Button();
      this.mobjNextButton = new Button();
      this.mobjButtonsSection = new Panel();
      this.mobjContentSection = new Panel();
      this.mobjValidationMessage = new Label();
      this.mobjValidationMessage.Dock = DockStyle.Top;
      this.mobjValidationMessage.Height = 40;
      this.mobjValidationMessage.TextAlign = ContentAlignment.TopLeft;
      this.mobjContentSection.Dock = DockStyle.Fill;
      this.mobjBackButton.Dock = DockStyle.Right;
      this.mobjBackButton.Click += new EventHandler(this.mobjBackButton_Click);
      this.mobjBackButton.Text = "< Back";
      this.mobjFinishButton.Text = "Finish";
      this.mobjFinishButton.Dock = DockStyle.Right;
      this.mobjFinishButton.Click += new EventHandler(this.mobjFinishButton_Click);
      this.mobjCancelButton.Dock = DockStyle.Right;
      this.mobjCancelButton.Text = "Cancel";
      this.mobjCancelButton.Click += new EventHandler(this.mobjCancelButton_Click);
      this.mobjNextButton.Dock = DockStyle.Right;
      this.mobjNextButton.Text = "Next >";
      this.mobjNextButton.Click += new EventHandler(this.mobjNextButton_Click);
      this.mobjButtonsSection.Height = 40;
      this.mobjButtonsSection.DockPadding.Top = 10;
      this.mobjButtonsSection.DockPadding.Bottom = 10;
      this.mobjButtonsSection.Dock = DockStyle.Bottom;
      this.mobjButtonsSection.Controls.Add((Control) this.mobjBackButton);
      this.mobjButtonsSection.Controls.Add((Control) WizardForm.GetHorizontalPaddingPanel(DockStyle.Right, 10));
      this.mobjButtonsSection.Controls.Add((Control) this.mobjNextButton);
      this.mobjButtonsSection.Controls.Add((Control) WizardForm.GetHorizontalPaddingPanel(DockStyle.Right, 20));
      this.mobjButtonsSection.Controls.Add((Control) this.mobjFinishButton);
      this.mobjButtonsSection.Controls.Add((Control) WizardForm.GetHorizontalPaddingPanel(DockStyle.Right, 30));
      this.mobjButtonsSection.Controls.Add((Control) this.mobjCancelButton);
      this.BorderStyle = BorderStyle.FixedSingle;
      this.MinimumSize = new Size(500, 400);
      this.Size = new Size(500, 400);
      this.Controls.Add((Control) this.mobjContentSection);
      this.Controls.Add((Control) this.mobjValidationMessage);
      this.Controls.Add((Control) this.mobjButtonsSection);
    }

    /// <summary>
    /// Handles the Click event of the mobjFinishButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjFinishButton_Click(object sender, EventArgs e)
    {
      if (!this.mobjCurrentStep.OnNext())
        return;
      this.CompleteWizard();
    }

    /// <summary>
    /// Handles the Click event of the mobjNextButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjNextButton_Click(object sender, EventArgs e)
    {
      if (!this.mobjCurrentStep.OnNext())
        return;
      this.NavigateToPage(this.mobjCurrentStep.NextPage);
    }

    /// <summary>
    /// Handles the Click event of the mobjCancelButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjCancelButton_Click(object sender, EventArgs e) => this.Close();

    /// <summary>
    /// Handles the Click event of the mobjBackButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjBackButton_Click(object sender, EventArgs e)
    {
      if (!this.mobjCurrentStep.OnPrevious())
        return;
      this.NavigateToPage(this.mobjCurrentStep.PreviousPage);
    }

    /// <summary>Gets the horizontal padding panel.</summary>
    /// <param name="enmDockStyle">The enm dock style.</param>
    /// <param name="intWidth">Width of the int.</param>
    /// <returns></returns>
    private static Panel GetHorizontalPaddingPanel(DockStyle enmDockStyle, int intWidth)
    {
      Panel horizontalPaddingPanel = new Panel();
      horizontalPaddingPanel.Width = intWidth;
      horizontalPaddingPanel.Dock = enmDockStyle;
      return horizontalPaddingPanel;
    }

    protected abstract IList<WizardStep> GetSteps();

    protected abstract void CompleteWizard();

    /// <summary>Updates the wizard.</summary>
    protected internal void UpdateWizard()
    {
      bool flag = false;
      if (this.mobjCurrentStep != null)
      {
        flag = this.mobjCurrentStep.CanNavigateNext;
        this.mobjNextButton.Enabled = flag && this.mobjCurrentStep.NextPage != null;
        this.mobjBackButton.Enabled = this.mobjCurrentStep.CanNavigatePrevious && this.mobjCurrentStep.PreviousPage != null;
      }
      this.mobjFinishButton.Enabled = flag && this.CanComplete;
      this.mobjCancelButton.Enabled = this.CanCancel;
      if (!this.mobjNextButton.Enabled && this.mobjFinishButton.Enabled)
        this.AcceptButton = (IButtonControl) this.mobjFinishButton;
      else
        this.AcceptButton = (IButtonControl) this.mobjNextButton;
      this.SetMessage("", MessageType.Error);
    }

    /// <summary>Gets the current step.</summary>
    protected WizardStep CurrentStep => this.mobjCurrentStep;

    /// <summary>
    /// Gets a value indicating whether this instance can complete.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can complete; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool CanComplete => false;

    /// <summary>
    /// Gets a value indicating whether this instance can cancel.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can cancel; otherwise, <c>false</c>.
    /// </value>
    public bool CanCancel => true;

    /// <summary>Sets the message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="enmMessageType">Type of the enm message.</param>
    internal void SetMessage(string strMessage, MessageType enmMessageType)
    {
      if (!string.IsNullOrEmpty(strMessage))
      {
        this.mobjValidationMessage.Text = strMessage;
        if (enmMessageType != MessageType.Information)
        {
          if (enmMessageType != MessageType.Error)
            return;
          this.mobjValidationMessage.ForeColor = Color.Red;
        }
        else
          this.mobjValidationMessage.ForeColor = Color.Green;
      }
      else
        this.mobjValidationMessage.Text = string.Empty;
    }
  }
}
