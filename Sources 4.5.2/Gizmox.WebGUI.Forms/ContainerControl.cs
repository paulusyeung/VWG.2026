using System;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common;
using System.Collections.Specialized;
using System.Security;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System.Drawing;
using Gizmox.WebGUI.Forms.Serialization;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Specifies the different types of automatic scaling modes supported by Windows Forms.</summary>
    [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
    public enum AutoScaleMode
    {
        None,
        Font,
        Dpi,
        Inherit
    }

    /// <summary>
    /// Provides focus management functionality for controls that can function as a container for other controls.
    /// </summary>
    [ToolboxItem(false)]
    [Skin(typeof(ContainerControlSkin))]
    [Serializable()]
    public class ContainerControl : ScrollableControl, IContainerControl
    {

        #region Class Fields

        #region Static

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to AutoValidate property.
        /// </summary>
        private static SerializableProperty AutoValidateProperty = SerializableProperty.Register("AutoValidate", typeof(AutoValidate), typeof(ContainerControl), new SerializablePropertyMetadata(AutoValidate.Inherit));

        /// <summary>
        /// Provides a property reference to UnvalidatedControl property.
        /// </summary>
        private static SerializableProperty UnvalidatedControlProperty = SerializableProperty.Register("UnvalidatedControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to FocusedControl property.
        /// </summary>
        private static SerializableProperty FocusedControlProperty = SerializableProperty.Register("FocusedControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ActiveControl property.
        /// </summary>
        private static SerializableProperty ActiveControlProperty = SerializableProperty.Register("ActiveControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

        #endregion Serializable Properties

        #region Serializable Events

        /// <summary>
        /// The AutoValidateChanged event registration.
        /// </summary>
        private static readonly SerializableEvent AutoValidateChangedEvent = SerializableEvent.Register("AutoValidateChanged", typeof(EventHandler), typeof(ContainerControl));

        #endregion Serializable Events

        #region Events

        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ContainerControl.AutoValidate"></see> property changes.</summary>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), SRDescription("ContainerControlOnAutoValidateChangedDescr"), EditorBrowsable(EditorBrowsableState.Never), SRCategory("CatPropertyChanged")]
        public event EventHandler AutoValidateChanged
        {
            add
            {
                this.AddHandler(ContainerControl.AutoValidateChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ContainerControl.AutoValidateChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AutoValidateChanged event.
        /// </summary>
        private EventHandler AutoValidateChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ContainerControl.AutoValidateChangedEvent);
            }
        }

        #endregion

        private static readonly int mintStateParentChanged = SerializableBitVector32.CreateMask(mintStateScalingChild);
        private static readonly int mintStateProcessingMnemonic = SerializableBitVector32.CreateMask(mintStateValidating);
        private static readonly int mintStateScalingChild = SerializableBitVector32.CreateMask(mintStateProcessingMnemonic);
        private static readonly int mintStateScalingNeededOnLayout = SerializableBitVector32.CreateMask();
        private static readonly int mintStateValidating = SerializableBitVector32.CreateMask(mintStateScalingNeededOnLayout);

        #endregion Static

        /// <summary>
        /// Gets the state of the validation.
        /// </summary>
        /// <value>The state of the validation.</value>
        private SerializableBitVector32 mobjValidationState = new SerializableBitVector32();

        #endregion

        #region IContainerControl Members

        #region Methods

        #region Events

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ContainerControl.AutoValidateChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnAutoValidateChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.AutoValidateChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnBindingContextChanged(EventArgs.Empty);
        }

        #endregion Events

        /// <summary>
        /// Handles validation on enter.
        /// </summary>
        /// <param name="objEnterControl">The enter control.</param>
        private void EnterValidation(Control objEnterControl)
        {
            // Get the current unvalidated control 
            Control objUnvalidatedControl = this.UnvalidatedControlInternal;

            // If there is a valid enter control
            if (objEnterControl != null)
            {
                // If enter control should cause validation and there is an unvalidated control
                if (objEnterControl.CausesValidation && objUnvalidatedControl != null)
                {
                    AutoValidate autoValidateForControl = Control.GetAutoValidateForControl(objUnvalidatedControl);
                    if (autoValidateForControl != AutoValidate.Disable)
                    {
                        Control objAncestorControl = objEnterControl;
                        while ((objAncestorControl != null) && !objAncestorControl.IsDescendant(objUnvalidatedControl))
                        {
                            objAncestorControl = objAncestorControl.ParentInternal;
                        }
                        bool blnPreventFocusChangeOnError = autoValidateForControl == AutoValidate.EnablePreventFocusChange;
                        this.ValidateThroughAncestor(objAncestorControl, blnPreventFocusChangeOnError);
                    }
                }
            }
        }

        /// <summary>
        /// Resets the validation flag.
        /// </summary>
        private void ResetValidationFlag()
        {
            Control.ControlCollection objControls = base.Controls;
            int intCount = objControls.Count;
            for (int i = 0; i < intCount; i++)
            {
                objControls[i].ValidationCancelled = false;
            }
        }

        /// <summary>
        /// Resets the active and focused controls recursive.
        /// </summary>
        internal void ResetActiveAndFocusedControlsRecursive()
        {
            // Get Active control
            Control objControl = this.ActiveControlInternal;

            // If is a container, recursively reset it's active and focused controls
            if (objControl is ContainerControl && objControl != this)
            {
                ((ContainerControl)objControl).ResetActiveAndFocusedControlsRecursive();
            }

            //Reset control properties
            this.ActiveControlInternal = null;
            this.FocusedControlInternal = null;
        }

        /// <summary>
        /// Ensures the unvalidated control.
        /// </summary>
        /// <param name="objCandidate">The candidate.</param>
        private void EnsureUnvalidatedControl(Control objCandidate)
        {
            // Check that parameter is valid and that the control state supports the following actions
            if (((!this.mobjValidationState[mintStateValidating] && (this.UnvalidatedControlInternal == null)) && (objCandidate != null)) && objCandidate.ShouldAutoValidate)
            {
                // Set the internal unvalidated control property to the parameter control
                this.UnvalidatedControlInternal = objCandidate;
            }
        }

        /// <summary>Causes all of the child controls within a control that support validation to validate their data. </summary>
        /// <returns>true if all of the children validated successfully; otherwise, false. </returns>
        /// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGUI.Forms.ContainerControl.ValidateChildren(Gizmox.WebGUI.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public virtual bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            if ((validationConstraints < ValidationConstraints.None) || (validationConstraints > (ValidationConstraints.ImmediateChildren | ValidationConstraints.TabStop | ValidationConstraints.Visible | ValidationConstraints.Enabled | ValidationConstraints.Selectable)))
            {
                throw new InvalidEnumArgumentException("validationConstraints", (int)validationConstraints, typeof(ValidationConstraints));
            }
            return !base.PerformContainerValidation(validationConstraints);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return this.Validate(false);
        }

        /// <summary>
        /// Validates the specified check auto validate.
        /// </summary>
        /// <param name="blnCheckAutoValidate">if set to <c>true</c> [check auto validate].</param>
        /// <returns></returns>
        public bool Validate(bool blnCheckAutoValidate)
        {
            bool blnFlag;
            return this.ValidateInternal(blnCheckAutoValidate, out blnFlag);
        }

        /// <summary>Causes all of the child controls within a control that support validation to validate their data. </summary>
        /// <returns>true if all of the children validated successfully; otherwise, false. </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool ValidateChildren()
        {
            return this.ValidateChildren(ValidationConstraints.Selectable);
        }

        /// <summary>
        /// Validates the internal.
        /// </summary>
        /// <param name="blnCheckAutoValidate">if set to <c>true</c> [check auto validate].</param>
        /// <param name="blnValidatedControlAllowsFocusChange">if set to <c>true</c> [validated control allows focus change].</param>
        /// <returns></returns>
        internal bool ValidateInternal(bool blnCheckAutoValidate, out bool blnValidatedControlAllowsFocusChange)
        {
            blnValidatedControlAllowsFocusChange = false;
            if ((this.AutoValidate != AutoValidate.EnablePreventFocusChange) && ((this.ActiveControlInternal == null) || !this.ActiveControlInternal.CausesValidation))
            {
                return true;
            }
            if (this.UnvalidatedControlInternal == null)
            {
                if ((this.FocusedControlInternal is ContainerControl) && this.FocusedControlInternal.CausesValidation)
                {
                    ContainerControl objFocusedControl = (ContainerControl)this.FocusedControlInternal;
                    if (!objFocusedControl.ValidateInternal(blnCheckAutoValidate, out blnValidatedControlAllowsFocusChange))
                    {
                        return false;
                    }
                }
                else
                {
                    this.UnvalidatedControlInternal = this.FocusedControlInternal;
                }
            }
            bool blnPreventFocusChangeOnError = true;
            Control objControl2 = (this.UnvalidatedControlInternal != null) ? this.UnvalidatedControlInternal : this.FocusedControlInternal;
            if (objControl2 != null)
            {
                AutoValidate autoValidateForControl = Control.GetAutoValidateForControl(objControl2);
                if (blnCheckAutoValidate && (autoValidateForControl == AutoValidate.Disable))
                {
                    return true;
                }
                blnPreventFocusChangeOnError = autoValidateForControl == AutoValidate.EnablePreventFocusChange;
                blnValidatedControlAllowsFocusChange = autoValidateForControl == AutoValidate.EnableAllowFocusChange;
            }
            return this.ValidateThroughAncestor(null, blnPreventFocusChangeOnError);
        }

        /// <summary>
        /// Validates the through ancestor.
        /// </summary>
        /// <param name="objAncestorControl">The ancestor control.</param>
        /// <param name="blnPreventFocusChangeOnError">if set to <c>true</c> [prevent focus change on error].</param>
        /// <returns></returns>
        private bool ValidateThroughAncestor(Control objAncestorControl, bool blnPreventFocusChangeOnError)
        {
            if (objAncestorControl == null)
            {
                objAncestorControl = this;
            }
            if (this.mobjValidationState[mintStateValidating])
            {
                return false;
            }
            if (this.UnvalidatedControlInternal == null)
            {
                this.UnvalidatedControlInternal = this.FocusedControlInternal;
            }
            if (this.UnvalidatedControlInternal == null)
            {
                return true;
            }
            if (!objAncestorControl.IsDescendant(this.UnvalidatedControlInternal))
            {
                return false;
            }
            this.mobjValidationState[mintStateValidating] = true;
            bool blnFlag = false;
            Control objActiveControl = this.ActiveControlInternal;
            Control objUnvalidatedControl = this.UnvalidatedControlInternal;
            if (objActiveControl != null)
            {
                objActiveControl.ValidationCancelled = false;
                if (objActiveControl is ContainerControl)
                {
                    (objActiveControl as ContainerControl).ResetValidationFlag();
                }
            }
            try
            {
                while ((objUnvalidatedControl != null) && (objUnvalidatedControl != objAncestorControl))
                {
                    try
                    {
                        blnFlag = objUnvalidatedControl.PerformControlValidation(false);
                    }
                    catch
                    {
                        blnFlag = true;
                        throw;
                    }
                    if (blnFlag)
                    {
                        break;
                    }
                    objUnvalidatedControl = objUnvalidatedControl.ParentInternal;
                }
                if (blnFlag && blnPreventFocusChangeOnError)
                {
                    if (((this.UnvalidatedControlInternal == null) && (objUnvalidatedControl != null)) && objAncestorControl.IsDescendant(objUnvalidatedControl))
                    {
                        this.UnvalidatedControlInternal = objUnvalidatedControl;
                    }
                    if ((objActiveControl == this.ActiveControlInternal) && (objActiveControl != null))
                    {
                        CancelEventArgs objEventArgs = new CancelEventArgs();
                        objEventArgs.Cancel = true;
                        objActiveControl.NotifyValidationResult(objUnvalidatedControl, objEventArgs);
                        if (objActiveControl is ContainerControl)
                        {
                            ContainerControl objControl4 = objActiveControl as ContainerControl;
                            if (objControl4.FocusedControlInternal != null)
                            {
                                objControl4.FocusedControlInternal.ValidationCancelled = true;
                            }
                            objControl4.ResetActiveAndFocusedControlsRecursive();
                        }
                    }
                    this.SetActiveControlInternal(this.UnvalidatedControlInternal);
                }
            }
            finally
            {
                this.UnvalidatedControlInternal = null;
                this.mobjValidationState[mintStateValidating] = false;
            }
            return !blnFlag;
        }

        /// <summary>
        /// Updates the focused control state
        /// </summary>
        internal virtual void UpdateFocusedControl()
        {
            this.EnsureUnvalidatedControl(this.FocusedControlInternal);
            Control objFocusedControl = this.FocusedControlInternal;
            while (this.ActiveControlInternal != objFocusedControl)
            {
                if ((objFocusedControl == null) || objFocusedControl.IsDescendant(this.ActiveControlInternal))
                {
                    Control objActiveControl = this.ActiveControlInternal;
                    while (true)
                    {
                        Control objParentInternal = objActiveControl.ParentInternal;
                        if ((objParentInternal == this) || (objParentInternal == objFocusedControl))
                        {
                            break;
                        }
                        objActiveControl = objActiveControl.ParentInternal;
                    }
                    Control objControl4 = this.FocusedControlInternal = objFocusedControl;
                    this.EnterValidation(objActiveControl);
                    if (this.FocusedControlInternal != objControl4)
                    {
                        objFocusedControl = this.FocusedControlInternal;
                    }
                    else
                    {
                        objFocusedControl = objActiveControl;
                        objFocusedControl.NotifyEnter();
                    }
                    continue;
                }
                ContainerControl objInnerMostFocusedContainerControl = this.InnerMostFocusedContainerControl;
                Control objControl6 = null;
                if (objInnerMostFocusedContainerControl.FocusedControlInternal != null)
                {
                    objFocusedControl = objInnerMostFocusedContainerControl.FocusedControlInternal;
                    objControl6 = objInnerMostFocusedContainerControl;
                    if (objInnerMostFocusedContainerControl != this)
                    {
                        objInnerMostFocusedContainerControl.FocusedControlInternal = null;
                        if ((objInnerMostFocusedContainerControl.ParentInternal == null) || !(objInnerMostFocusedContainerControl.ParentInternal is MdiClient))
                        {
                            objInnerMostFocusedContainerControl.ActiveControlInternal = null;
                        }
                    }
                }
                else
                {
                    objFocusedControl = objInnerMostFocusedContainerControl;
                    if (objInnerMostFocusedContainerControl.ParentInternal != null)
                    {
                        ContainerControl objContainerControlInternal = objInnerMostFocusedContainerControl.ParentInternal.GetContainerControlInternal() as ContainerControl;
                        objControl6 = objContainerControlInternal;
                        if ((objContainerControlInternal != null) && (objContainerControlInternal != this))
                        {
                            objContainerControlInternal.FocusedControlInternal = null;
                            objContainerControlInternal.ActiveControlInternal = null;
                        }
                    }
                }
                do
                {
                    Control objControl8 = objFocusedControl;
                    if (objFocusedControl != null)
                    {
                        objFocusedControl = objFocusedControl.ParentInternal;
                    }
                    if (objFocusedControl == this)
                    {
                        objFocusedControl = null;
                    }
                    if (objControl8 != null)
                    {
                        objControl8.NotifyLeave();
                    }
                }
                while (((objFocusedControl != null) && (objFocusedControl != objControl6)) && !objFocusedControl.IsDescendant(this.ActiveControlInternal));
            }
            this.FocusedControlInternal = this.ActiveControlInternal;
            if (this.ActiveControl != null)
            {
                this.EnterValidation(this.ActiveControlInternal);
            }
        }

        /// <summary>When overridden by a derived class, updates which button is the default button.</summary>
        protected virtual void UpdateDefaultButton()
        {
        }

        /// <summary>
        /// Assigns the current active control
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns></returns>
        private bool AssignActiveControlInternal(Control objControl)
        {
            if (this.ActiveControlInternal != objControl)
            {
                try
                {
                    if (objControl != null)
                    {
                        objControl.BecomingActiveControl = true;
                    }
                    this.ActiveControlInternal = objControl;
                    this.UpdateFocusedControl();
                }
                finally
                {
                    if (objControl != null)
                    {
                        objControl.BecomingActiveControl = false;
                    }
                }
                if (this.ActiveControlInternal == objControl)
                {
                    Form objForm = base.FindFormInternal();
                    if (objForm != null)
                    {
                        objForm.UpdateDefaultButton();
                    }
                }
            }
            else
            {
                this.FocusedControlInternal = this.ActiveControlInternal;
            }
            return (this.ActiveControlInternal == objControl);
        }

        /// <summary>
        /// Sets control active
        /// </summary>
        /// <param name="objControl"></param>
        protected void SetActiveControl(Control objControl)
        {
            this.SetActiveControlInternal(objControl);
        }

        /// <summary>
        /// Sets the current active control
        /// </summary>
        /// <param name="objValue">The obj value.</param>
        internal void SetActiveControlInternal(Control objValue)
        {
            // If not active, not null and not focused
            if ((this.ActiveControlInternal != objValue) || ((objValue != null) && !objValue.Focused))
            {
                bool blnActivated;

                // If not is contained control 
                if ((objValue != null) && !base.Contains(objValue))
                {
                    throw new ArgumentException(SR.GetString("CannotActivateControl"));
                }

                // The parent control container
                ContainerControl objContainerControl = this;

                // If control has parent and not null
                if ((objValue != null) && (objValue.ParentInternal != null))
                {
                    // Get control container
                    objContainerControl = objValue.ParentInternal.GetContainerControlInternal() as ContainerControl;
                }

                // If parent control container is not null
                if (objContainerControl != null)
                {
                    // If has control container                                            
                    blnActivated = objContainerControl.ActivateControlInternal(objValue, false);
                }
                else
                {
                    // If there is no parent control container use this container
                    blnActivated = this.AssignActiveControlInternal(objValue);
                }

                // If activated and has parent control container
                if ((objContainerControl != null) && blnActivated)
                {
                    ContainerControl objTopControl = this;

                    // Get the top element
                    while ((objTopControl.ParentInternal != null) && (objTopControl.ParentInternal.GetContainerControlInternal() is ContainerControl))
                    {
                        objTopControl = objTopControl.ParentInternal.GetContainerControlInternal() as ContainerControl;
                    }

                    // Set focus to active control
                    if (objTopControl.ContainsFocus && (((objValue == null) || !(objValue is UserControl)) || ((objValue is UserControl) && !((UserControl)objValue).HasFocusableChild())))
                    {
                        objContainerControl.FocusActiveControlInternal();
                    }
                }
            }
        }

        /// <summary>
        /// Assigns focus to the activeControl. If there is no activeControl then
        /// focus is given to the form. 
        /// package scope for Form
        /// </summary>
        internal void FocusActiveControlInternal()
        {
            Control objActiveControlInternal = this.ActiveControlInternal;

            if (objActiveControlInternal != null && objActiveControlInternal.Visible)
            {
                // Set focus.
                IApplicationContext objApplicationContext = VWGContext.Current as IApplicationContext;
                if (objApplicationContext != null)
                {
                    // Check that current focused control is different from active control.
                    if (objApplicationContext.GetFocused() != objActiveControlInternal)
                    {
                        // Set focus.
                        objApplicationContext.SetFocused(objActiveControlInternal, true);

                        // Raise the on got focus event
                        objActiveControlInternal.OnGotFocus(EventArgs.Empty);
                    }
                }
            }
            else
            {
                // Determine and focus closest visible parent
                ContainerControl objContainerControl = this;
                while (objContainerControl != null && !objContainerControl.Visible)
                {
                    Control objParent = objContainerControl.ParentInternal;
                    if (objParent != null)
                    {
                        objContainerControl = objParent.GetContainerControlInternal() as ContainerControl;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objContainerControl != null && objContainerControl.Visible)
                {
                    // Set focus.
                    IApplicationContext objApplicationContext = this.Context as IApplicationContext;
                    if (objApplicationContext != null)
                    {
                        // Check that current focused control is different from container control.
                        if (objApplicationContext.GetFocused() != objContainerControl)
                        {
                            // Set focus.
                            objApplicationContext.SetFocused(objContainerControl, true);

                            // Raise the on got focus event
                            objContainerControl.OnGotFocus(EventArgs.Empty);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Activates a control with in the container
        /// </summary>
        /// <param name="objControl">The control to be activated.</param>
        /// <returns></returns>
        bool IContainerControl.ActivateControl(Control objControl)
        {
            return ActivateControlInternal(objControl, true);
        }

        /// <summary>
        /// Afters the control removed.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objOldParent">The obj old parent.</param>
        internal virtual void AfterControlRemoved(Control objControl, Control objOldParent)
        {
            ContainerControl objContainerControlInternal;
            if ((objControl == this.ActiveControlInternal) || objControl.Contains(this.ActiveControlInternal))
            {
                bool blnFocusActiveControl = base.SelectNextControl(objControl, true, true, true, true);
                if (blnFocusActiveControl)
                {
                    this.FocusActiveControlInternal();
                }
                else
                {
                    this.SetActiveControlInternal(null);
                }
            }
            else if ((this.ActiveControlInternal == null) && (this.ParentInternal != null))
            {
                objContainerControlInternal = this.ParentInternal.GetContainerControlInternal() as ContainerControl;
                if ((objContainerControlInternal != null) && (objContainerControlInternal.ActiveControl == this))
                {
                    Form objForm = base.FindFormInternal();
                    if (objForm != null)
                    {
                        objForm.SelectNextControl(this, true, true, true, true);
                    }
                }
            }
            objContainerControlInternal = this;
            while (objContainerControlInternal != null)
            {
                Control objParentInternal = objContainerControlInternal.ParentInternal;
                if (objParentInternal == null)
                {
                    break;
                }
                objContainerControlInternal = objParentInternal.GetContainerControlInternal() as ContainerControl;
                if (((objContainerControlInternal != null) && (objContainerControlInternal.UnvalidatedControlInternal != null)) && ((objContainerControlInternal.UnvalidatedControlInternal == objControl) || objControl.Contains(objContainerControlInternal.UnvalidatedControlInternal)))
                {
                    objContainerControlInternal.UnvalidatedControlInternal = objOldParent;
                }
            }
            if ((objControl == this.UnvalidatedControlInternal) || objControl.Contains(this.UnvalidatedControlInternal))
            {
                this.UnvalidatedControlInternal = null;
            }
        }

        /// <summary>
        /// Activates the control internal.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        internal bool ActivateControlInternal(Control objControl)
        {
            return this.ActivateControlInternal(objControl, true);
        }

        /// <summary>
        /// Activates a control with in the container
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="blnOriginator">if set to <c>true</c> [BLN originator].</param>
        /// <returns></returns>
        internal bool ActivateControlInternal(Control objControl, bool blnOriginator)
        {
            // Status flag
            bool blnActivationDone = true;
            bool blnActivationRequired = false;

            ContainerControl objContainerControl = null;

            // Get the current controls parent
            Control objCurrentControl = this.Parent;
            if (objCurrentControl != null)
            {
                // Get the controls parent container
                objContainerControl = objCurrentControl.GetContainerControlInternal() as ContainerControl;
                if (objContainerControl != null)
                {
                    // If not already activated
                    blnActivationRequired = objContainerControl.ActiveControl != this;
                }
            }

            // If not already activated and activation is required
            if ((objControl != this.ActiveControlInternal) || blnActivationRequired)
            {
                // If activation failed
                if (blnActivationRequired && !objContainerControl.ActivateControlInternal(this, false))
                {
                    return false;
                }

                // Set active control
                blnActivationDone = this.AssignActiveControlInternal(objControl);
            }

            // If scoll into view is required
            if (blnOriginator)
            {
                this.ScrollActiveControlIntoView();
            }

            // Return activation status
            return blnActivationDone;
        }

        /// <summary>
        /// Scrolls the parent scollable control to make the control visible
        /// </summary>
        private void ScrollActiveControlIntoView()
        {
            // Get the current active control
            Control objCurrentControl = this.ActiveControlInternal;
            if (objCurrentControl != null)
            {
                // Scroll all parent controls to include the active control in the view
                for (ScrollableControl objScrollableControl = this.FindScrollableParent(objCurrentControl); objScrollableControl != null; objScrollableControl = this.FindScrollableParent(objScrollableControl))
                {
                    // Scroll current control into view
                    objScrollableControl.ScrollControlIntoView(this.ActiveControlInternal);

                    // Set current control
                    objCurrentControl = objScrollableControl;
                }
            }
        }

        /// <summary>
        /// Finds the parent scrollable control
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns></returns>
        private ScrollableControl FindScrollableParent(Control objControl)
        {
            // Initalize control cursor
            Control objCurrentControl = objControl.ParentInternal;

            // Loop parents until scrollable control is found
            while ((objCurrentControl != null) && !(objCurrentControl is ScrollableControl))
            {
                // Go to parent control
                objCurrentControl = objCurrentControl.ParentInternal;
            }

            // Return the scrollable control or null
            return objCurrentControl as ScrollableControl;

        }

        /// <summary>
        /// Selects the specified directed.
        /// </summary>
        /// <param name="blnDirected">if set to <c>true</c> [directed].</param>
        /// <param name="blnForward">if set to <c>true</c> [forward].</param>
        protected override void Select(bool blnDirected, bool blnForward)
        {
            bool blnNextControl = true;
            if (this.ParentInternal != null)
            {
                IContainerControl objContainerControlInternal = this.ParentInternal.GetContainerControlInternal();
                if (objContainerControlInternal != null)
                {
                    objContainerControlInternal.ActiveControl = this;
                    blnNextControl = objContainerControlInternal.ActiveControl == this;
                }
            }
            if (blnDirected && blnNextControl)
            {
                base.SelectNextControl(null, blnForward, true, true, false);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the inner most focused container control.
        /// </summary>
        /// <value>The inner most focused container control.</value>
        internal ContainerControl InnerMostFocusedContainerControl
        {
            get
            {
                ContainerControl objContainerControl = this;

                while (objContainerControl != objContainerControl.FocusedControlInternal &&
                        objContainerControl.FocusedControlInternal is ContainerControl)
                {
                    objContainerControl = (ContainerControl)objContainerControl.FocusedControlInternal;
                }

                return objContainerControl;
            }
        }

        /// <summary>Gets or sets the active control on the container control.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that is currently active on the <see cref="T:Gizmox.WebGUI.Forms.ContainerControl"></see>.</returns>
        /// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> assigned could not be activated. </exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ContainerControlActiveControlDescr"), Browsable(false), SRCategory("CatBehavior")]
        public Control ActiveControl
        {
            get
            {
                return this.ActiveControlInternal;
            }
            set
            {
                this.SetActiveControl(value);
            }
        }

        #endregion Properties

        #endregion

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="ContainerControl"/> instance.
        /// </summary>
        public ContainerControl()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the dimensions that the control was designed to.</summary>
        /// <returns>A <see cref="T:System.Drawing.SizeF"></see> containing the dots per inch (DPI) or <see cref="T:System.Drawing.Font"></see> size that the control was designed to.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The width or height of the <see cref="T:System.Drawing.SizeF"></see> value is less than 0 when setting this value.</exception>
        [Obsolete("Not implemented by design.")]
        [EditorBrowsable(EditorBrowsableState.Advanced), Localizable(true), SRCategory("CatLayout"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SizeF AutoScaleDimensions
        {
            get
            {
                return SizeF.Empty;
            }
            set
            { }
        }

        /// <summary>Gets or sets the automatic scaling mode of the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> that represents the current scaling mode. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoScaleMode.None"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> value that is not valid was used to set this property.</exception>
        [Obsolete("Not implemented by design.")]
        [SRCategory("CatLayout"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), SRDescription("ContainerControlAutoScaleModeDescr")]
        public AutoScaleMode AutoScaleMode
        {
            get
            {
                return AutoScaleMode.None;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets the active control reference.
        /// </summary>
        /// <value>The active control reference.</value>
        private Control ActiveControlInternal
        {
            get
            {
                return this.GetValue<Control>(ContainerControl.ActiveControlProperty);
            }
            set
            {
                this.SetValue<Control>(ContainerControl.ActiveControlProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the focused control reference.
        /// </summary>
        /// <value>The focused control reference.</value>
        private Control FocusedControlInternal
        {
            get
            {
                return this.GetValue<Control>(ContainerControl.FocusedControlProperty);
            }
            set
            {
                this.SetValue<Control>(ContainerControl.FocusedControlProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the unvalidated control reference.
        /// </summary>
        /// <value>The unvalidated control reference.</value>
        private Control UnvalidatedControlInternal
        {
            get
            {
                return this.GetValue<Control>(ContainerControl.UnvalidatedControlProperty);
            }
            set
            {
                this.SetValue<Control>(ContainerControl.UnvalidatedControlProperty, value);
            }
        }

        /// <summary>Gets or sets a value that indicates whether controls in this container will be automatically validated when the focus changes.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> enumerated value that indicates whether contained controls are implicitly validated on focus change. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoValidate.Inherit"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> value that is not valid was used to set this property.</exception>
        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), SRDescription("ContainerControlAutoValidate"), SRCategory("CatBehavior"), AmbientValue(-1)]
        public virtual AutoValidate AutoValidate
        {
            get
            {
                // Get the current autovalidate valie
                AutoValidate enmAutoValidate = GetValue<AutoValidate>(ContainerControl.AutoValidateProperty);

                // If is inherit get inherited value
                if (enmAutoValidate == AutoValidate.Inherit)
                {
                    return Control.GetAutoValidateForControl(this);
                }

                // Return local value
                return enmAutoValidate;
            }
            set
            {
                switch (value)
                {
                    case AutoValidate.Inherit:
                    case AutoValidate.Disable:
                    case AutoValidate.EnablePreventFocusChange:
                    case AutoValidate.EnableAllowFocusChange:

                        // Set the auto validate value and raise events if value had changed
                        if (this.SetValue<AutoValidate>(ContainerControl.AutoValidateProperty, value))
                        {
                            this.OnAutoValidateChanged(EventArgs.Empty);
                        }
                        return;
                }
                throw new InvalidEnumArgumentException("AutoValidate", (int)value, typeof(AutoValidate));
            }
        }

        /// <summary>
        /// Gets the inner most active container control.
        /// </summary>
        /// <value>The inner most active container control.</value>
        internal ContainerControl InnerMostActiveContainerControl
        {
            get
            {
                ContainerControl objReturnValue = this;

                while (objReturnValue != objReturnValue.ActiveControl &&
                        objReturnValue.ActiveControl is ContainerControl)
                {
                    objReturnValue = (ContainerControl)objReturnValue.ActiveControl;
                }

                return objReturnValue;
            }
        }

        /// <summary>
        /// Gets the parent form.
        /// </summary>
        /// <value>The parent form.</value>
        [SRCategory("CatAppearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ContainerControlParentFormDescr"), Browsable(false)]
        public Form ParentForm
        {
            get
            {
                return this.ParentFormInternal;
            }
        }

        /// <summary>
        /// Gets the parent form internal.
        /// </summary>
        /// <value>The parent form internal.</value>
        internal Form ParentFormInternal
        {
            get
            {
                if (ParentInternal != null)
                {
                    return ParentInternal.FindFormInternal();
                }
                else
                {
                    if (this is Form)
                    {
                        return null;
                    }

                    return FindFormInternal();
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
        [SRDescription("ContainerControlBindingContextDescr"), Browsable(false)]
        public override BindingContext BindingContext
        {
            get
            {
                // Try to get the binding context
                BindingContext objBindingContext = base.BindingContext;
                if (objBindingContext == null)
                {
                    // Create new binding context
                    objBindingContext = new BindingContext();
                    this.BindingContext = objBindingContext;
                }

                // Return the current binding context
                return objBindingContext;
            }
            set
            {
                base.BindingContext = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support focus events].
        /// </summary>
        /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
        protected internal override bool SupportsFocusEvents
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

    }



}