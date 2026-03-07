// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabPageEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for events of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control.
  /// </summary>
  [Serializable]
  public class TabPageEventArgs : EventArgs
  {
    /// <summary>
    /// Represents the <see cref="T:Gizmox.WebGUI.Forms.TabPage" />
    /// </summary>
    public readonly TabPage TabPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPageEventArgs" /> class.
    /// </summary>
    /// <param name="objTabPage">The tab page.</param>
    public TabPageEventArgs(TabPage objTabPage) => this.TabPage = objTabPage;
  }
}
