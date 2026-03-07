// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ShowingTypeEditorEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The data class for the EventArgs</summary>
  [Serializable]
  public class ShowingTypeEditorEventArgs : EventArgs
  {
    private GridItem mobjCurrentGridItem;
    private bool mblnIsCancelled;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ShowingTypeEditorEventArgs" /> class.
    /// </summary>
    /// <param name="objCurrentItem">The obj current item.</param>
    public ShowingTypeEditorEventArgs(GridItem objCurrentItem) => this.mobjCurrentGridItem = objCurrentItem;

    /// <summary>Gets the current grid item.</summary>
    /// <value>The current grid item.</value>
    public GridItem CurrentGridItem => this.mobjCurrentGridItem;

    /// <summary>
    /// Gets a value indicating whether this instance is cancelled.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is cancelled; otherwise, <c>false</c>.
    /// </value>
    public bool IsCancelled => this.mblnIsCancelled;
  }
}
