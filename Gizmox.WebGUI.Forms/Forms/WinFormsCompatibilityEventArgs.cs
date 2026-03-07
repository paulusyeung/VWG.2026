// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WinFormsCompatibilityEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>WinFormsCompatibility event arguments.</summary>
  [Serializable]
  public class WinFormsCompatibilityEventArgs : EventArgs
  {
    /// <summary>The changed option name</summary>
    private string mstrChangedOptionName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WinFormsCompatibilityEventArgs" /> class.
    /// </summary>
    /// <param name="strChangedOptionName">Name of the changed option.</param>
    public WinFormsCompatibilityEventArgs(string strChangedOptionName) => this.mstrChangedOptionName = strChangedOptionName;

    /// <summary>Gets or sets the name of the changed option.</summary>
    /// <value>The name of the changed option.</value>
    public string ChangedOptionName
    {
      get => this.mstrChangedOptionName;
      set => this.mstrChangedOptionName = value;
    }
  }
}
