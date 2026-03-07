// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewDataErrorEventArgs : DataGridViewCellCancelEventArgs
  {
    private DataGridViewDataErrorContexts menmContext;
    private Exception mobjException;
    private bool mblnThrowException;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> class.</summary>
    /// <param name="objException">The exception that occurred.</param>
    /// <param name="intColumnIndex">The column index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values indicating the context in which the error occurred. </param>
    /// <param name="intRowIndex">The row index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
    public DataGridViewDataErrorEventArgs(
      Exception objException,
      int intColumnIndex,
      int intRowIndex,
      DataGridViewDataErrorContexts enmContext)
      : base(intColumnIndex, intRowIndex)
    {
      this.mobjException = objException;
      this.menmContext = enmContext;
    }

    /// <summary>Gets details about the state of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the error occurred.</summary>
    /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the error occurred.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewDataErrorContexts Context => this.menmContext;

    /// <summary>Gets the exception that represents the error.</summary>
    /// <returns>An <see cref="T:System.Exception"></see> that represents the error.</returns>
    /// <filterpriority>1</filterpriority>
    public Exception Exception => this.mobjException;

    /// <summary>Gets or sets a value indicating whether to throw the exception after the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler"></see> delegate is finished with it.</summary>
    /// <returns>true if the exception should be thrown; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.ArgumentException">When setting this property to true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.Exception"></see> property value is null.</exception>
    /// <filterpriority>1</filterpriority>
    public bool ThrowException
    {
      get => this.mblnThrowException;
      set => this.mblnThrowException = !value || this.mobjException != null ? value : throw new ArgumentException(SR.GetString("DataGridView_CannotThrowNullException"));
    }
  }
}
