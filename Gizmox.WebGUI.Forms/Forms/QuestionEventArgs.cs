// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.QuestionEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for events that need a true or false answer to a question.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class QuestionEventArgs : EventArgs
  {
    private bool mblnResponse;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> class using a default <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property value of false.</summary>
    public QuestionEventArgs() => this.mblnResponse = false;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> class using the specified default value for the <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property.</summary>
    /// <param name="blnResponse">The default value of the <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property.</param>
    public QuestionEventArgs(bool blnResponse) => this.mblnResponse = blnResponse;

    /// <summary>Gets or sets a value indicating the response to a question represented by the event.</summary>
    /// <returns>true for an affirmative response; otherwise, false. </returns>
    /// <filterpriority>1</filterpriority>
    public bool Response
    {
      get => this.mblnResponse;
      set => this.mblnResponse = value;
    }
  }
}
