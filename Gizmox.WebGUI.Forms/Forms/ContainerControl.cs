// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContainerControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides focus management functionality for controls that can function as a container for other controls.
  /// </summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ContainerControlSkin))]
  [Serializable]
  public class ContainerControl : ScrollableControl, IContainerControl
  {
    /// <summary>
    /// Provides a property reference to AutoValidate property.
    /// </summary>
    private static SerializableProperty AutoValidateProperty = SerializableProperty.Register(nameof (AutoValidate), typeof (AutoValidate), typeof (ContainerControl), new SerializablePropertyMetadata((object) AutoValidate.Inherit));
    /// <summary>
    /// Provides a property reference to UnvalidatedControl property.
    /// </summary>
    private static SerializableProperty UnvalidatedControlProperty = SerializableProperty.Register("UnvalidatedControl", typeof (Control), typeof (ContainerControl), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to FocusedControl property.
    /// </summary>
    private static SerializableProperty FocusedControlProperty = SerializableProperty.Register("FocusedControl", typeof (Control), typeof (ContainerControl), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ActiveControl property.
    /// </summary>
    private static SerializableProperty ActiveControlProperty = SerializableProperty.Register(nameof (ActiveControl), typeof (Control), typeof (ContainerControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The AutoValidateChanged event registration.</summary>
    private static readonly SerializableEvent AutoValidateChangedEvent = SerializableEvent.Register("AutoValidateChanged", typeof (EventHandler), typeof (ContainerControl));
    private static readonly int mintStateParentChanged = SerializableBitVector32.CreateMask(ContainerControl.mintStateScalingChild);
    private static readonly int mintStateProcessingMnemonic = SerializableBitVector32.CreateMask(ContainerControl.mintStateValidating);
    private static readonly int mintStateScalingChild = SerializableBitVector32.CreateMask(ContainerControl.mintStateProcessingMnemonic);
    private static readonly int mintStateScalingNeededOnLayout = SerializableBitVector32.CreateMask();
    private static readonly int mintStateValidating = SerializableBitVector32.CreateMask(ContainerControl.mintStateScalingNeededOnLayout);
    /// <summary>Gets the state of the validation.</summary>
    /// <value>The state of the validation.</value>
    private SerializableBitVector32 mobjValidationState;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ContainerControl.AutoValidate"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [SRDescription("ContainerControlOnAutoValidateChangedDescr")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AutoValidateChanged
    {
      add => this.AddHandler(ContainerControl.AutoValidateChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ContainerControl.AutoValidateChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AutoValidateChanged event.</summary>
    private EventHandler AutoValidateChangedHandler => (EventHandler) this.GetHandler(ContainerControl.AutoValidateChangedEvent);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ContainerControl.AutoValidateChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnAutoValidateChanged(EventArgs e)
    {
      EventHandler validateChangedHandler = this.AutoValidateChangedHandler;
      if (validateChangedHandler == null)
        return;
      validateChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.OnBindingContextChanged(EventArgs.Empty);
    }

    /// <summary>Handles validation on enter.</summary>
    /// <param name="objEnterControl">The enter control.</param>
    private void EnterValidation(Control objEnterControl)
    {
      Control unvalidatedControlInternal = this.UnvalidatedControlInternal;
      if (objEnterControl == null || !objEnterControl.CausesValidation || unvalidatedControlInternal == null)
        return;
      AutoValidate validateForControl = Control.GetAutoValidateForControl(unvalidatedControlInternal);
      if (validateForControl == AutoValidate.Disable)
        return;
      Control objAncestorControl = objEnterControl;
      while (objAncestorControl != null && !objAncestorControl.IsDescendant(unvalidatedControlInternal))
        objAncestorControl = objAncestorControl.ParentInternal;
      bool blnPreventFocusChangeOnError = validateForControl == AutoValidate.EnablePreventFocusChange;
      this.ValidateThroughAncestor(objAncestorControl, blnPreventFocusChangeOnError);
    }

    /// <summary>Resets the validation flag.</summary>
    private void ResetValidationFlag()
    {
      Control.ControlCollection controls = this.Controls;
      int count = controls.Count;
      for (int index = 0; index < count; ++index)
        controls[index].ValidationCancelled = false;
    }

    /// <summary>Resets the active and focused controls recursive.</summary>
    internal void ResetActiveAndFocusedControlsRecursive()
    {
      Control activeControlInternal = this.ActiveControlInternal;
      if (activeControlInternal is ContainerControl && activeControlInternal != this)
        ((ContainerControl) activeControlInternal).ResetActiveAndFocusedControlsRecursive();
      this.ActiveControlInternal = (Control) null;
      this.FocusedControlInternal = (Control) null;
    }

    /// <summary>Ensures the unvalidated control.</summary>
    /// <param name="objCandidate">The candidate.</param>
    private void EnsureUnvalidatedControl(Control objCandidate)
    {
      if (this.mobjValidationState[ContainerControl.mintStateValidating] || this.UnvalidatedControlInternal != null || objCandidate == null || !objCandidate.ShouldAutoValidate)
        return;
      this.UnvalidatedControlInternal = objCandidate;
    }

    /// <summary>Causes all of the child controls within a control that support validation to validate their data. </summary>
    /// <returns>true if all of the children validated successfully; otherwise, false. </returns>
    /// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGUI.Forms.ContainerControl.ValidateChildren(Gizmox.WebGUI.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual bool ValidateChildren(ValidationConstraints validationConstraints)
    {
      if (validationConstraints < ValidationConstraints.None || validationConstraints > (ValidationConstraints.Enabled | ValidationConstraints.ImmediateChildren | ValidationConstraints.Selectable | ValidationConstraints.TabStop | ValidationConstraints.Visible))
        throw new InvalidEnumArgumentException(nameof (validationConstraints), (int) validationConstraints, typeof (ValidationConstraints));
      return !this.PerformContainerValidation(validationConstraints);
    }

    /// <summary>Validates this instance.</summary>
    /// <returns></returns>
    public bool Validate() => this.Validate(false);

    /// <summary>Validates the specified check auto validate.</summary>
    /// <param name="blnCheckAutoValidate">if set to <c>true</c> [check auto validate].</param>
    /// <returns></returns>
    public bool Validate(bool blnCheckAutoValidate) => this.ValidateInternal(blnCheckAutoValidate, out bool _);

    /// <summary>Causes all of the child controls within a control that support validation to validate their data. </summary>
    /// <returns>true if all of the children validated successfully; otherwise, false. </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool ValidateChildren() => this.ValidateChildren(ValidationConstraints.Selectable);

    /// <summary>Validates the internal.</summary>
    /// <param name="blnCheckAutoValidate">if set to <c>true</c> [check auto validate].</param>
    /// <param name="blnValidatedControlAllowsFocusChange">if set to <c>true</c> [validated control allows focus change].</param>
    /// <returns></returns>
    internal bool ValidateInternal(
      bool blnCheckAutoValidate,
      out bool blnValidatedControlAllowsFocusChange)
    {
      blnValidatedControlAllowsFocusChange = false;
      if (this.AutoValidate != AutoValidate.EnablePreventFocusChange && (this.ActiveControlInternal == null || !this.ActiveControlInternal.CausesValidation))
        return true;
      if (this.UnvalidatedControlInternal == null)
      {
        if (this.FocusedControlInternal is ContainerControl && this.FocusedControlInternal.CausesValidation)
        {
          if (!((ContainerControl) this.FocusedControlInternal).ValidateInternal(blnCheckAutoValidate, out blnValidatedControlAllowsFocusChange))
            return false;
        }
        else
          this.UnvalidatedControlInternal = this.FocusedControlInternal;
      }
      bool blnPreventFocusChangeOnError = true;
      Control objControl = this.UnvalidatedControlInternal != null ? this.UnvalidatedControlInternal : this.FocusedControlInternal;
      if (objControl != null)
      {
        AutoValidate validateForControl = Control.GetAutoValidateForControl(objControl);
        if (blnCheckAutoValidate && validateForControl == AutoValidate.Disable)
          return true;
        blnPreventFocusChangeOnError = validateForControl == AutoValidate.EnablePreventFocusChange;
        blnValidatedControlAllowsFocusChange = validateForControl == AutoValidate.EnableAllowFocusChange;
      }
      return this.ValidateThroughAncestor((Control) null, blnPreventFocusChangeOnError);
    }

    /// <summary>Validates the through ancestor.</summary>
    /// <param name="objAncestorControl">The ancestor control.</param>
    /// <param name="blnPreventFocusChangeOnError">if set to <c>true</c> [prevent focus change on error].</param>
    /// <returns></returns>
    private bool ValidateThroughAncestor(
      Control objAncestorControl,
      bool blnPreventFocusChangeOnError)
    {
      if (objAncestorControl == null)
        objAncestorControl = (Control) this;
      if (this.mobjValidationState[ContainerControl.mintStateValidating])
        return false;
      if (this.UnvalidatedControlInternal == null)
        this.UnvalidatedControlInternal = this.FocusedControlInternal;
      if (this.UnvalidatedControlInternal == null)
        return true;
      if (!objAncestorControl.IsDescendant(this.UnvalidatedControlInternal))
        return false;
      this.mobjValidationState[ContainerControl.mintStateValidating] = true;
      bool flag = false;
      Control activeControlInternal = this.ActiveControlInternal;
      Control control = this.UnvalidatedControlInternal;
      if (activeControlInternal != null)
      {
        activeControlInternal.ValidationCancelled = false;
        if (activeControlInternal is ContainerControl)
          (activeControlInternal as ContainerControl).ResetValidationFlag();
      }
      try
      {
        for (; control != null; control = control.ParentInternal)
        {
          if (control != objAncestorControl)
          {
            try
            {
              flag = control.PerformControlValidation(false);
            }
            catch
            {
              flag = true;
              throw;
            }
            if (flag)
              break;
          }
          else
            break;
        }
        if (flag & blnPreventFocusChangeOnError)
        {
          if (this.UnvalidatedControlInternal == null && control != null && objAncestorControl.IsDescendant(control))
            this.UnvalidatedControlInternal = control;
          if (activeControlInternal == this.ActiveControlInternal && activeControlInternal != null)
          {
            activeControlInternal.NotifyValidationResult((object) control, new CancelEventArgs()
            {
              Cancel = true
            });
            if (activeControlInternal is ContainerControl)
            {
              ContainerControl containerControl = activeControlInternal as ContainerControl;
              if (containerControl.FocusedControlInternal != null)
                containerControl.FocusedControlInternal.ValidationCancelled = true;
              containerControl.ResetActiveAndFocusedControlsRecursive();
            }
          }
          this.SetActiveControlInternal(this.UnvalidatedControlInternal);
        }
      }
      finally
      {
        this.UnvalidatedControlInternal = (Control) null;
        this.mobjValidationState[ContainerControl.mintStateValidating] = false;
      }
      return !flag;
    }

    /// <summary>Updates the focused control state</summary>
    internal virtual void UpdateFocusedControl()
    {
      this.EnsureUnvalidatedControl(this.FocusedControlInternal);
      Control control1 = this.FocusedControlInternal;
      while (this.ActiveControlInternal != control1)
      {
        if (control1 == null || control1.IsDescendant(this.ActiveControlInternal))
        {
          Control objEnterControl = this.ActiveControlInternal;
          while (true)
          {
            Control parentInternal = objEnterControl.ParentInternal;
            if (parentInternal != this && parentInternal != control1)
              objEnterControl = objEnterControl.ParentInternal;
            else
              break;
          }
          Control control2 = this.FocusedControlInternal = control1;
          this.EnterValidation(objEnterControl);
          if (this.FocusedControlInternal != control2)
          {
            control1 = this.FocusedControlInternal;
          }
          else
          {
            control1 = objEnterControl;
            control1.NotifyEnter();
          }
        }
        else
        {
          ContainerControl containerControl = this.InnerMostFocusedContainerControl;
          Control control3 = (Control) null;
          if (containerControl.FocusedControlInternal != null)
          {
            control1 = containerControl.FocusedControlInternal;
            control3 = (Control) containerControl;
            if (containerControl != this)
            {
              containerControl.FocusedControlInternal = (Control) null;
              if (containerControl.ParentInternal == null || !(containerControl.ParentInternal is MdiClient))
                containerControl.ActiveControlInternal = (Control) null;
            }
          }
          else
          {
            control1 = (Control) containerControl;
            if (containerControl.ParentInternal != null)
            {
              ContainerControl containerControlInternal = containerControl.ParentInternal.GetContainerControlInternal() as ContainerControl;
              control3 = (Control) containerControlInternal;
              if (containerControlInternal != null && containerControlInternal != this)
              {
                containerControlInternal.FocusedControlInternal = (Control) null;
                containerControlInternal.ActiveControlInternal = (Control) null;
              }
            }
          }
          do
          {
            Control control4 = control1;
            if (control1 != null)
              control1 = control1.ParentInternal;
            if (control1 == this)
              control1 = (Control) null;
            control4?.NotifyLeave();
          }
          while (control1 != null && control1 != control3 && !control1.IsDescendant(this.ActiveControlInternal));
        }
      }
      this.FocusedControlInternal = this.ActiveControlInternal;
      if (this.ActiveControl == null)
        return;
      this.EnterValidation(this.ActiveControlInternal);
    }

    /// <summary>When overridden by a derived class, updates which button is the default button.</summary>
    protected virtual void UpdateDefaultButton()
    {
    }

    /// <summary>Assigns the current active control</summary>
    /// <param name="objControl">The obj control.</param>
    /// <returns></returns>
    private bool AssignActiveControlInternal(Control objControl)
    {
      if (this.ActiveControlInternal != objControl)
      {
        try
        {
          if (objControl != null)
            objControl.BecomingActiveControl = true;
          this.ActiveControlInternal = objControl;
          this.UpdateFocusedControl();
        }
        finally
        {
          if (objControl != null)
            objControl.BecomingActiveControl = false;
        }
        if (this.ActiveControlInternal == objControl)
          this.FindFormInternal()?.UpdateDefaultButton();
      }
      else
        this.FocusedControlInternal = this.ActiveControlInternal;
      return this.ActiveControlInternal == objControl;
    }

    /// <summary>Sets control active</summary>
    /// <param name="objControl"></param>
    protected void SetActiveControl(Control objControl) => this.SetActiveControlInternal(objControl);

    /// <summary>Sets the current active control</summary>
    /// <param name="objValue">The obj value.</param>
    internal void SetActiveControlInternal(Control objValue)
    {
      if (this.ActiveControlInternal == objValue && (objValue == null || objValue.Focused))
        return;
      if (objValue != null && !this.Contains(objValue))
        throw new ArgumentException(SR.GetString("CannotActivateControl"));
      ContainerControl containerControl1 = this;
      if (objValue != null && objValue.ParentInternal != null)
        containerControl1 = objValue.ParentInternal.GetContainerControlInternal() as ContainerControl;
      bool flag = containerControl1 == null ? this.AssignActiveControlInternal(objValue) : containerControl1.ActivateControlInternal(objValue, false);
      if (!(containerControl1 != null & flag))
        return;
      ContainerControl containerControl2 = this;
      while (containerControl2.ParentInternal != null && containerControl2.ParentInternal.GetContainerControlInternal() is ContainerControl)
        containerControl2 = containerControl2.ParentInternal.GetContainerControlInternal() as ContainerControl;
      if (!containerControl2.ContainsFocus || objValue != null && objValue is UserControl && (!(objValue is UserControl) || ((UserControl) objValue).HasFocusableChild()))
        return;
      containerControl1.FocusActiveControlInternal();
    }

    /// <summary>
    /// Assigns focus to the activeControl. If there is no activeControl then
    /// focus is given to the form.
    /// package scope for Form
    /// </summary>
    internal void FocusActiveControlInternal()
    {
      Control activeControlInternal = this.ActiveControlInternal;
      if (activeControlInternal != null && activeControlInternal.Visible)
      {
        if (!(VWGContext.Current is IApplicationContext current) || current.GetFocused() == activeControlInternal)
          return;
        current.SetFocused((IControl) activeControlInternal, true);
        activeControlInternal.OnGotFocus(EventArgs.Empty);
      }
      else
      {
        ContainerControl objControl;
        Control parentInternal;
        for (objControl = this; objControl != null && !objControl.Visible; objControl = parentInternal.GetContainerControlInternal() as ContainerControl)
        {
          parentInternal = objControl.ParentInternal;
          if (parentInternal == null)
            break;
        }
        if (objControl == null || !objControl.Visible || !(this.Context is IApplicationContext context) || context.GetFocused() == objControl)
          return;
        context.SetFocused((IControl) objControl, true);
        objControl.OnGotFocus(EventArgs.Empty);
      }
    }

    /// <summary>Activates a control with in the container</summary>
    /// <param name="objControl">The control to be activated.</param>
    /// <returns></returns>
    bool IContainerControl.ActivateControl(Control objControl) => this.ActivateControlInternal(objControl, true);

    /// <summary>Afters the control removed.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objOldParent">The obj old parent.</param>
    internal virtual void AfterControlRemoved(Control objControl, Control objOldParent)
    {
      if (objControl == this.ActiveControlInternal || objControl.Contains(this.ActiveControlInternal))
      {
        if (this.SelectNextControl(objControl, true, true, true, true))
          this.FocusActiveControlInternal();
        else
          this.SetActiveControlInternal((Control) null);
      }
      else if (this.ActiveControlInternal == null && this.ParentInternal != null && this.ParentInternal.GetContainerControlInternal() is ContainerControl containerControlInternal && containerControlInternal.ActiveControl == this)
        this.FindFormInternal()?.SelectNextControl((Control) this, true, true, true, true);
      containerControl = this;
      while (containerControl != null)
      {
        Control parentInternal = containerControl.ParentInternal;
        if (parentInternal != null)
        {
          if (parentInternal.GetContainerControlInternal() is ContainerControl containerControl && containerControl.UnvalidatedControlInternal != null && (containerControl.UnvalidatedControlInternal == objControl || objControl.Contains(containerControl.UnvalidatedControlInternal)))
            containerControl.UnvalidatedControlInternal = objOldParent;
        }
        else
          break;
      }
      if (objControl != this.UnvalidatedControlInternal && !objControl.Contains(this.UnvalidatedControlInternal))
        return;
      this.UnvalidatedControlInternal = (Control) null;
    }

    /// <summary>Activates the control internal.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    internal bool ActivateControlInternal(Control objControl) => this.ActivateControlInternal(objControl, true);

    /// <summary>Activates a control with in the container</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="blnOriginator">if set to <c>true</c> [BLN originator].</param>
    /// <returns></returns>
    internal bool ActivateControlInternal(Control objControl, bool blnOriginator)
    {
      bool flag1 = true;
      bool flag2 = false;
      containerControl = (ContainerControl) null;
      Control parent = this.Parent;
      if (parent != null && parent.GetContainerControlInternal() is ContainerControl containerControl)
        flag2 = containerControl.ActiveControl != this;
      if (objControl != this.ActiveControlInternal | flag2)
      {
        if (flag2 && !containerControl.ActivateControlInternal((Control) this, false))
          return false;
        flag1 = this.AssignActiveControlInternal(objControl);
      }
      if (blnOriginator)
        this.ScrollActiveControlIntoView();
      return flag1;
    }

    /// <summary>
    /// Scrolls the parent scollable control to make the control visible
    /// </summary>
    private void ScrollActiveControlIntoView()
    {
      Control activeControlInternal = this.ActiveControlInternal;
      if (activeControlInternal == null)
        return;
      for (ScrollableControl scrollableParent = this.FindScrollableParent(activeControlInternal); scrollableParent != null; scrollableParent = this.FindScrollableParent((Control) scrollableParent))
        scrollableParent.ScrollControlIntoView(this.ActiveControlInternal);
    }

    /// <summary>Finds the parent scrollable control</summary>
    /// <param name="objControl">The obj control.</param>
    /// <returns></returns>
    private ScrollableControl FindScrollableParent(Control objControl)
    {
      Control parentInternal = objControl.ParentInternal;
      while (true)
      {
        switch (parentInternal)
        {
          case null:
          case ScrollableControl _:
            goto label_3;
          default:
            parentInternal = parentInternal.ParentInternal;
            continue;
        }
      }
label_3:
      return parentInternal as ScrollableControl;
    }

    /// <summary>Selects the specified directed.</summary>
    /// <param name="blnDirected">if set to <c>true</c> [directed].</param>
    /// <param name="blnForward">if set to <c>true</c> [forward].</param>
    protected override void Select(bool blnDirected, bool blnForward)
    {
      bool flag = true;
      if (this.ParentInternal != null)
      {
        IContainerControl containerControlInternal = this.ParentInternal.GetContainerControlInternal();
        if (containerControlInternal != null)
        {
          containerControlInternal.ActiveControl = (Control) this;
          flag = containerControlInternal.ActiveControl == this;
        }
      }
      if (!(blnDirected & flag))
        return;
      this.SelectNextControl((Control) null, blnForward, true, true, false);
    }

    /// <summary>Gets the inner most focused container control.</summary>
    /// <value>The inner most focused container control.</value>
    internal ContainerControl InnerMostFocusedContainerControl
    {
      get
      {
        ContainerControl containerControl = this;
        while (containerControl != containerControl.FocusedControlInternal && containerControl.FocusedControlInternal is ContainerControl)
          containerControl = (ContainerControl) containerControl.FocusedControlInternal;
        return containerControl;
      }
    }

    /// <summary>Gets or sets the active control on the container control.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that is currently active on the <see cref="T:Gizmox.WebGUI.Forms.ContainerControl"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> assigned could not be activated. </exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ContainerControlActiveControlDescr")]
    [Browsable(false)]
    [SRCategory("CatBehavior")]
    public Control ActiveControl
    {
      get => this.ActiveControlInternal;
      set => this.SetActiveControl(value);
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ContainerControl" /> instance.
    /// </summary>
    public ContainerControl() => this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);

    /// <summary>Gets or sets the dimensions that the control was designed to.</summary>
    /// <returns>A <see cref="T:System.Drawing.SizeF"></see> containing the dots per inch (DPI) or <see cref="T:System.Drawing.Font"></see> size that the control was designed to.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The width or height of the <see cref="T:System.Drawing.SizeF"></see> value is less than 0 when setting this value.</exception>
    [Obsolete("Not implemented by design.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SizeF AutoScaleDimensions
    {
      get => SizeF.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the automatic scaling mode of the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> that represents the current scaling mode. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoScaleMode.None"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> value that is not valid was used to set this property.</exception>
    [Obsolete("Not implemented by design.")]
    [SRCategory("CatLayout")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [SRDescription("ContainerControlAutoScaleModeDescr")]
    public AutoScaleMode AutoScaleMode
    {
      get => AutoScaleMode.None;
      set
      {
      }
    }

    /// <summary>Gets or sets the active control reference.</summary>
    /// <value>The active control reference.</value>
    private Control ActiveControlInternal
    {
      get => this.GetValue<Control>(ContainerControl.ActiveControlProperty);
      set => this.SetValue<Control>(ContainerControl.ActiveControlProperty, value);
    }

    /// <summary>Gets or sets the focused control reference.</summary>
    /// <value>The focused control reference.</value>
    private Control FocusedControlInternal
    {
      get => this.GetValue<Control>(ContainerControl.FocusedControlProperty);
      set => this.SetValue<Control>(ContainerControl.FocusedControlProperty, value);
    }

    /// <summary>Gets or sets the unvalidated control reference.</summary>
    /// <value>The unvalidated control reference.</value>
    private Control UnvalidatedControlInternal
    {
      get => this.GetValue<Control>(ContainerControl.UnvalidatedControlProperty);
      set => this.SetValue<Control>(ContainerControl.UnvalidatedControlProperty, value);
    }

    /// <summary>Gets or sets a value that indicates whether controls in this container will be automatically validated when the focus changes.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> enumerated value that indicates whether contained controls are implicitly validated on focus change. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoValidate.Inherit"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> value that is not valid was used to set this property.</exception>
    /// <filterpriority>2</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [SRDescription("ContainerControlAutoValidate")]
    [SRCategory("CatBehavior")]
    [AmbientValue(-1)]
    public virtual AutoValidate AutoValidate
    {
      get
      {
        AutoValidate autoValidate = this.GetValue<AutoValidate>(ContainerControl.AutoValidateProperty);
        return autoValidate == AutoValidate.Inherit ? Control.GetAutoValidateForControl((Control) this) : autoValidate;
      }
      set
      {
        switch (value)
        {
          case AutoValidate.Inherit:
          case AutoValidate.Disable:
          case AutoValidate.EnablePreventFocusChange:
          case AutoValidate.EnableAllowFocusChange:
            if (!this.SetValue<AutoValidate>(ContainerControl.AutoValidateProperty, value))
              break;
            this.OnAutoValidateChanged(EventArgs.Empty);
            break;
          default:
            throw new InvalidEnumArgumentException(nameof (AutoValidate), (int) value, typeof (AutoValidate));
        }
      }
    }

    /// <summary>Gets the inner most active container control.</summary>
    /// <value>The inner most active container control.</value>
    internal ContainerControl InnerMostActiveContainerControl
    {
      get
      {
        ContainerControl containerControl = this;
        while (containerControl != containerControl.ActiveControl && containerControl.ActiveControl is ContainerControl)
          containerControl = (ContainerControl) containerControl.ActiveControl;
        return containerControl;
      }
    }

    /// <summary>Gets the parent form.</summary>
    /// <value>The parent form.</value>
    [SRCategory("CatAppearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ContainerControlParentFormDescr")]
    [Browsable(false)]
    public Form ParentForm => this.ParentFormInternal;

    /// <summary>Gets the parent form internal.</summary>
    /// <value>The parent form internal.</value>
    internal Form ParentFormInternal
    {
      get
      {
        if (this.ParentInternal != null)
          return this.ParentInternal.FindFormInternal();
        return this is Form ? (Form) null : this.FindFormInternal();
      }
    }

    /// <summary>
    /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    [SRDescription("ContainerControlBindingContextDescr")]
    [Browsable(false)]
    public override BindingContext BindingContext
    {
      get
      {
        BindingContext bindingContext = base.BindingContext;
        if (bindingContext == null)
        {
          bindingContext = new BindingContext();
          this.BindingContext = bindingContext;
        }
        return bindingContext;
      }
      set => base.BindingContext = value;
    }

    /// <summary>
    /// Gets a value indicating whether [support focus events].
    /// </summary>
    /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
    protected internal override bool SupportsFocusEvents => false;
  }
}
