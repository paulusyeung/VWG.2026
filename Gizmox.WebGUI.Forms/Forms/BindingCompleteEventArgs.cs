// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingCompleteEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
  /// <filterpriority>2</filterpriority>
  public class BindingCompleteEventArgs : CancelEventArgs
  {
    private Binding mobjBinding;
    private BindingCompleteContext menmContext;
    private string mstrErrorText;
    private Exception mobjException;
    private BindingCompleteState menmState;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state, and binding context.</summary>
    /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
    /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
    /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
    public BindingCompleteEventArgs(
      Binding objBinding,
      BindingCompleteState enmBindingCompleteState,
      BindingCompleteContext enmContext)
      : this(objBinding, enmBindingCompleteState, enmContext, string.Empty, (Exception) null, false)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, and binding context.</summary>
    /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
    /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
    /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
    /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
    public BindingCompleteEventArgs(
      Binding objBinding,
      BindingCompleteState enmBindingCompleteState,
      BindingCompleteContext enmContext,
      string strErrorText)
      : this(objBinding, enmBindingCompleteState, enmContext, strErrorText, (Exception) null, true)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, and exception.</summary>
    /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
    /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
    /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
    /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
    /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
    public BindingCompleteEventArgs(
      Binding objBinding,
      BindingCompleteState enmBindingCompleteState,
      BindingCompleteContext enmContext,
      string strErrorText,
      Exception objException)
      : this(objBinding, enmBindingCompleteState, enmContext, strErrorText, objException, true)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, exception, and whether the binding should be cancelled.</summary>
    /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
    /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
    /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
    /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
    /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
    /// <param name="blnCancel">true to cancel the binding and keep focus on the current control; false to allow focus to shift to another control.</param>
    public BindingCompleteEventArgs(
      Binding objBinding,
      BindingCompleteState enmBindingCompleteState,
      BindingCompleteContext enmContext,
      string strErrorText,
      Exception objException,
      bool blnCancel)
      : base(blnCancel)
    {
      this.mobjBinding = objBinding;
      this.menmState = enmBindingCompleteState;
      this.menmContext = enmContext;
      this.mstrErrorText = strErrorText == null ? string.Empty : strErrorText;
      this.mobjException = objException;
    }

    /// <summary>Gets the binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>.</returns>
    public Binding Binding => this.mobjBinding;

    /// <summary>Gets the direction of the binding operation.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </returns>
    public BindingCompleteContext BindingCompleteContext => this.menmContext;

    /// <summary>Gets the completion state of the binding operation.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</returns>
    public BindingCompleteState BindingCompleteState => this.menmState;

    /// <summary>Gets the text description of the error that occurred during the binding operation.</summary>
    /// <returns>The text description of the error that occurred during the binding operation.</returns>
    /// <filterpriority>1</filterpriority>
    public string ErrorText => this.mstrErrorText;

    /// <summary>Gets the exception that occurred during the binding operation.</summary>
    /// <returns>The <see cref="T:System.Exception"></see> that occurred during the binding operation.</returns>
    /// <filterpriority>1</filterpriority>
    public Exception Exception => this.mobjException;
  }
}
