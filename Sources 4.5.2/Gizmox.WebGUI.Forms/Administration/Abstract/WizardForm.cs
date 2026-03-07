using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal abstract class WizardForm : Form
    {
        private int mintCurrentStepIndex = -1;
        private WizardStep mobjCurrentStep;
        /// <summary>
        /// Initializes a new instance of the <see cref="WizardForm"/> class.
        /// </summary>
        public WizardForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeSteps();
        }

        /// <summary>
        /// Initializes the steps.
        /// </summary>
        private void InitializeSteps()
        {
            IList<WizardStep> objSteps = GetSteps();
            
            WizardStep objPreviousStep = null;

            for (int i = 0; i < objSteps.Count; i++)
            {
                WizardStep objCurrentStep = objSteps[i];
                objCurrentStep.SetPreviousStep(objPreviousStep);
                objCurrentStep.SetWizardForm(this);
                if(objPreviousStep != null)
                {
                    objPreviousStep.SetNextStep(objCurrentStep);
                }

                objPreviousStep = objCurrentStep;
            }

            NavigateToPage(objSteps[0]);
        }

        /// <summary>
        /// Navigates to page.
        /// </summary>
        /// <param name="objNextPage">The obj next page.</param>
        private void NavigateToPage(WizardStep objNextPage)
        {
            if (this.mobjCurrentStep != null)
            {
                mobjCurrentStep = null;
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

            if (this.mobjCurrentStep != null)
            {
                this.mobjContentSection.Controls.Add(mobjCurrentStep);
                this.mobjCurrentStep.Focus();
            }
        }

        /// <summary>
        /// Determines whether [is first step].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is first step]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFirstStep()
        {
            return mintCurrentStepIndex == 0;
        }

        /// <summary>
        /// Determines whether [is last step].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is last step]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsLastStep()
        {
            return mintCurrentStepIndex == mobjSteps.Count - 1;
        }

        /// <summary>
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
            //
            // mobjValidationMessage
            //
            mobjValidationMessage.Dock = DockStyle.Top;
            mobjValidationMessage.Height = 40;
            mobjValidationMessage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            //
            // mobjContentSection
            //
            mobjContentSection.Dock = DockStyle.Fill;
            //
            // mobjBackButton
            //
            mobjBackButton.Dock = DockStyle.Right;
            mobjBackButton.Click += new EventHandler(mobjBackButton_Click);
            mobjBackButton.Text = "< Back";
            //
            // mobjFinishButton
            //
            mobjFinishButton.Text = "Finish";
            mobjFinishButton.Dock = DockStyle.Right;
            mobjFinishButton.Click += new EventHandler(mobjFinishButton_Click);
            //
            // mobjCancelButton
            //
            mobjCancelButton.Dock = DockStyle.Right;
            mobjCancelButton.Text = "Cancel";
            mobjCancelButton.Click += new EventHandler(mobjCancelButton_Click);
            //
            // mobjBackButton
            //
            mobjNextButton.Dock = DockStyle.Right;
            mobjNextButton.Text = "Next >";
            mobjNextButton.Click += new EventHandler(mobjNextButton_Click);
            //
            // mobjButtonsSection
            //
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
            //
            // this
            //
            this.BorderStyle = Forms.BorderStyle.FixedSingle;
            this.MinimumSize = new Size(500, 400);
            this.Size = new Size(500, 400);
            this.Controls.Add(mobjContentSection);
            this.Controls.Add(mobjValidationMessage);
            this.Controls.Add(mobjButtonsSection);
        }

        /// <summary>
        /// Handles the Click event of the mobjFinishButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjFinishButton_Click(object sender, EventArgs e)
        {
            if (this.mobjCurrentStep.OnNext())
            {
                this.CompleteWizard();
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjNextButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjNextButton_Click(object sender, EventArgs e)
        {
            if (this.mobjCurrentStep.OnNext())
            {
                this.NavigateToPage(this.mobjCurrentStep.NextPage);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjCancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the mobjBackButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjBackButton_Click(object sender, EventArgs e)
        {
            if (this.mobjCurrentStep.OnPrevious())
            {
                this.NavigateToPage(this.mobjCurrentStep.PreviousPage);
            }
        }

        /// <summary>
        /// Gets the horizontal padding panel.
        /// </summary>
        /// <param name="enmDockStyle">The enm dock style.</param>
        /// <param name="intWidth">Width of the int.</param>
        /// <returns></returns>
        private static Panel GetHorizontalPaddingPanel(DockStyle enmDockStyle, int intWidth)
        {
            Panel objPanel = new Panel();
            objPanel.Width = intWidth;
            objPanel.Dock = enmDockStyle;
            return objPanel;
        }

        protected abstract IList<WizardStep> GetSteps();
        protected abstract void CompleteWizard();
        private Button mobjBackButton;
        private Button mobjCancelButton;
        private Button mobjFinishButton;
        private Button mobjNextButton;
        private Panel mobjButtonsSection;
        private Panel mobjContentSection;
        private Label mobjValidationMessage;
        private IList<WizardStep> mobjSteps;

        /// <summary>
        /// Updates the wizard.
        /// </summary>
        protected internal void UpdateWizard()
        {
            bool blnCanNavigateNext = false;

            if (this.mobjCurrentStep != null)
            {
                blnCanNavigateNext = this.mobjCurrentStep.CanNavigateNext;
                this.mobjNextButton.Enabled = blnCanNavigateNext && (this.mobjCurrentStep.NextPage != null);
                this.mobjBackButton.Enabled = this.mobjCurrentStep.CanNavigatePrevious && (this.mobjCurrentStep.PreviousPage != null);
            }

            this.mobjFinishButton.Enabled = blnCanNavigateNext && this.CanComplete;
            this.mobjCancelButton.Enabled = this.CanCancel;

            if (!this.mobjNextButton.Enabled && this.mobjFinishButton.Enabled)
            {
                base.AcceptButton = this.mobjFinishButton;
            }
            else
            {
                base.AcceptButton = this.mobjNextButton;
            }

            SetMessage("", MessageType.Error);
        }

        /// <summary>
        /// Gets the current step.
        /// </summary>
        protected WizardStep CurrentStep
        {
            get
            {
                return mobjCurrentStep;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can complete.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can complete; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool CanComplete 
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can cancel.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can cancel; otherwise, <c>false</c>.
        /// </value>
        public bool CanCancel 
        {
            get 
            { 
                return true; 
            }
        }

        /// <summary>
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
                    default:
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
