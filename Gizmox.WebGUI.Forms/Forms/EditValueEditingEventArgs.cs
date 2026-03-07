// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.EditValueEditingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public class EditValueEditingEventArgs : CancelEventArgs
  {
    private bool mblnExitEditMode;
    private IEvent mobjParameters;
    private object mobjFormattedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.EditValueEditingEventArgs" /> class.
    /// </summary>
    /// <param name="objParameters">The object parameters.</param>
    internal EditValueEditingEventArgs(IEvent objParameters)
    {
      this.mobjParameters = objParameters;
      this.mblnExitEditMode = true;
      this.mobjFormattedValue = (object) objParameters["value"];
    }

    /// <summary>Gets or sets the parameters.</summary>
    /// <value>The parameters.</value>
    public IEvent Parameters
    {
      get => this.mobjParameters;
      set => this.mobjParameters = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [exit edit mode].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [exit edit mode]; otherwise, <c>false</c>.
    /// </value>
    public bool ExitEditMode
    {
      get => this.mblnExitEditMode;
      set => this.mblnExitEditMode = value;
    }

    /// <summary>Gets or sets the formatted value.</summary>
    /// <value>The formatted value.</value>
    public object FormattedValue
    {
      get => this.mobjFormattedValue;
      set => this.mobjFormattedValue = value;
    }
  }
}
