// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WizardStep
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  internal abstract class WizardStep : UserControl
  {
    private WizardStep mobjPrevious;
    private WizardStep mobjNext;
    private WizardForm mobjWizardForm;

    /// <summary>Gets/Sets the controls docking style</summary>
    public override DockStyle Dock
    {
      get => DockStyle.Fill;
      set
      {
      }
    }

    /// <summary>Gets the next page.</summary>
    /// <returns></returns>
    protected internal virtual WizardStep GetNextPage() => this.mobjNext;

    /// <summary>Gets the previous page.</summary>
    /// <returns></returns>
    protected internal virtual WizardStep GetPreviousPage() => this.mobjPrevious;

    /// <summary>
    /// Gets a value indicating whether this instance can navigate next.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can navigate next; otherwise, <c>false</c>.
    /// </value>
    protected internal virtual bool CanNavigateNext => true;

    /// <summary>
    /// Gets a value indicating whether this instance can navigate previous.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can navigate previous; otherwise, <c>false</c>.
    /// </value>
    protected internal virtual bool CanNavigatePrevious => false;

    /// <summary>Sets the next step.</summary>
    /// <param name="objCurrentStep">The obj current step.</param>
    internal void SetNextStep(WizardStep objCurrentStep) => this.mobjNext = objCurrentStep;

    /// <summary>Sets the previous step.</summary>
    /// <param name="objPreviousStep">The obj previous step.</param>
    internal void SetPreviousStep(WizardStep objPreviousStep) => this.mobjPrevious = objPreviousStep;

    /// <summary>Sets the wizard form.</summary>
    /// <param name="objWizardForm">The obj wizard form.</param>
    internal void SetWizardForm(WizardForm objWizardForm) => this.mobjWizardForm = objWizardForm;

    /// <summary>Gets the caption.</summary>
    protected internal virtual string Caption => string.Empty;

    /// <summary>Updates the wizard.</summary>
    protected void UpdateWizard() => this.mobjWizardForm.UpdateWizard();

    /// <summary>Sets the message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="enmMessageType">Type of the enm message.</param>
    protected void SetMessage(string strMessage, MessageType enmMessageType) => this.mobjWizardForm.SetMessage(strMessage, enmMessageType);

    /// <summary>Gets the previous page.</summary>
    protected internal virtual WizardStep PreviousPage => this.mobjPrevious;

    /// <summary>Gets the next page.</summary>
    protected internal virtual WizardStep NextPage => this.mobjNext;

    /// <summary>Called when [next].</summary>
    /// <returns></returns>
    protected internal virtual bool OnNext() => this.CanNavigateNext;

    /// <summary>Called when [previous].</summary>
    /// <returns></returns>
    protected internal virtual bool OnPrevious() => this.CanNavigatePrevious;

    /// <summary>Activates this instance.</summary>
    protected internal virtual void Activate()
    {
    }
  }
}
