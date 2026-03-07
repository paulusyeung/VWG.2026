// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SelectedGridItemChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.SelectedGridItemChanged"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class SelectedGridItemChangedEventArgs : EventArgs
  {
    private GridItem newSelection;
    private GridItem oldSelection;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SelectedGridItemChangedEventArgs"></see> class.</summary>
    /// <param name="objOldSel">The previously selected grid item. </param>
    /// <param name="objNewSel">The newly selected grid item. </param>
    public SelectedGridItemChangedEventArgs(GridItem objOldSel, GridItem objNewSel)
    {
      this.oldSelection = objOldSel;
      this.newSelection = objNewSel;
    }

    /// <summary>Gets the newly selected <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</summary>
    /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public GridItem NewSelection => this.newSelection;

    /// <summary>Gets the previously selected <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</summary>
    /// <returns>The old <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>. This can be null.</returns>
    /// <filterpriority>1</filterpriority>
    public GridItem OldSelection => this.oldSelection;
  }
}
