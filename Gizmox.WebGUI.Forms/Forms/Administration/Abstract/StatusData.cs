// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.Abstract.StatusData
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Drawing;

namespace Gizmox.WebGUI.Forms.Administration.Abstract
{
  /// <summary>
  /// 
  /// </summary>
  public class StatusData
  {
    private string mstrStatusText;
    private Font mobjFont;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.Abstract.StatusData" /> class.
    /// </summary>
    /// <param name="strText">The string text.</param>
    /// <param name="objFont">The object font.</param>
    public StatusData(string strText, Font objFont)
    {
      this.mstrStatusText = strText;
      this.mobjFont = objFont;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.Abstract.StatusData" /> class.
    /// </summary>
    /// <param name="strText">The string text.</param>
    public StatusData(string strText)
      : this(strText, (Font) null)
    {
    }

    /// <summary>Sets the status text.</summary>
    /// <value>The status text.</value>
    public string StatusText
    {
      set => this.mstrStatusText = value;
    }

    /// <summary>Gets the text.</summary>
    /// <value>The text.</value>
    public string Text => this.mstrStatusText;

    /// <summary>Gets or sets the font.</summary>
    /// <value>The font.</value>
    public Font Font
    {
      get => this.mobjFont;
      set => this.mobjFont = value;
    }
  }
}
