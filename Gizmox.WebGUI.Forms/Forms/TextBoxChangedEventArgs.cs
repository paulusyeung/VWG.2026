// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextBoxChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class TextBoxChangedEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    public readonly TextBox mobjTextBox;
    /// <summary>
    /// 
    /// </summary>
    public readonly string mstrOldValue;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTextBox"></param>
    /// <param name="strOldValue"></param>
    public TextBoxChangedEventArgs(TextBox objTextBox, string strOldValue)
    {
      this.mobjTextBox = objTextBox;
      this.mstrOldValue = strOldValue;
    }
  }
}
