// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabControlCancelEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.TabControl.Selecting"></see> and <see cref="E:Gizmox.WebGUI.Forms.TabControl.Deselecting"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control.
  /// </summary>
  [Serializable]
  public class TabControlCancelEventArgs : CancelEventArgs
  {
    private TabPage mobjTabPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControlCancelEventArgs"></see> class.
    /// </summary>
    /// <param name="blnCancel">true to cancel the tab change by default; otherwise, false.</param>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.</param>
    public TabControlCancelEventArgs(TabPage objTabPage, bool blnCancel)
      : base(blnCancel)
    {
      this.mobjTabPage = objTabPage;
    }

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.</returns>
    public TabPage TabPage => this.mobjTabPage;
  }
}
