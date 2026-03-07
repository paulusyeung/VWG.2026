// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event. </summary>
  public class BindingManagerDataErrorEventArgs : EventArgs
  {
    /// <summary>The internal exception</summary>
    private Exception mobjException;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs"></see> class. </summary>
    /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred in the binding process that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised.</param>
    public BindingManagerDataErrorEventArgs(Exception objException) => this.mobjException = objException;

    /// <summary>Gets the <see cref="T:System.Exception"></see> caught in the binding process that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised.</summary>
    /// <returns>The <see cref="T:System.Exception"></see> that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised. </returns>
    public Exception Exception => this.mobjException;
  }
}
