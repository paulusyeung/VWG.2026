using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal abstract class WizardStep : UserControl
    {
        private WizardStep mobjPrevious;
        private WizardStep mobjNext;
        private WizardForm mobjWizardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardStep"/> class.
        /// </summary>
        public WizardStep()
        {

        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        public override DockStyle Dock
        {
            get
            {
                return DockStyle.Fill;
            }
            set
            { }
        }

        /// <summary>
        /// Gets the next page.
        /// </summary>
        /// <returns></returns>
        protected internal virtual WizardStep GetNextPage()
        {
            return mobjNext;
        }

        /// <summary>
        /// Gets the previous page.
        /// </summary>
        /// <returns></returns>
        protected internal virtual WizardStep GetPreviousPage()
        {
            return mobjPrevious;
        }

        /// <summary>
        /// Gets a value indicating whether this instance can navigate next.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can navigate next; otherwise, <c>false</c>.
        /// </value>
        protected internal virtual bool CanNavigateNext
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can navigate previous.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can navigate previous; otherwise, <c>false</c>.
        /// </value>
        protected internal virtual bool CanNavigatePrevious
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the next step.
        /// </summary>
        /// <param name="objCurrentStep">The obj current step.</param>
        internal void SetNextStep(WizardStep objCurrentStep)
        {
            mobjNext = objCurrentStep;
        }

        /// <summary>
        /// Sets the previous step.
        /// </summary>
        /// <param name="objPreviousStep">The obj previous step.</param>
        internal void SetPreviousStep(WizardStep objPreviousStep)
        {
            mobjPrevious = objPreviousStep;
        }

        /// <summary>
        /// Sets the wizard form.
        /// </summary>
        /// <param name="objWizardForm">The obj wizard form.</param>
        internal void SetWizardForm(WizardForm objWizardForm)
        {
            mobjWizardForm = objWizardForm;
        }

        /// <summary>
        /// Gets the caption.
        /// </summary>
        protected internal virtual string Caption 
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Updates the wizard.
        /// </summary>
        protected void UpdateWizard()
        {
            mobjWizardForm.UpdateWizard();
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="enmMessageType">Type of the enm message.</param>
        protected void SetMessage(string strMessage, MessageType enmMessageType)
        {
            mobjWizardForm.SetMessage(strMessage, enmMessageType);
        }

        /// <summary>
        /// Gets the previous page.
        /// </summary>
        protected internal virtual WizardStep PreviousPage 
        {
            get
            {
                return mobjPrevious;
            } 
        }

        /// <summary>
        /// Gets the next page.
        /// </summary>
        protected internal virtual WizardStep NextPage 
        {
            get 
            { 
                return mobjNext; 
            } 
        }

        /// <summary>
        /// Called when [next].
        /// </summary>
        /// <returns></returns>
        protected internal virtual bool OnNext()
        {
            return CanNavigateNext;
        }

        /// <summary>
        /// Called when [previous].
        /// </summary>
        /// <returns></returns>
        protected internal virtual bool OnPrevious()
        {
            return CanNavigatePrevious;            
        }

        /// <summary>
        /// Activates this instance.
        /// </summary>
        protected internal virtual void Activate()
        { }
    }
}
