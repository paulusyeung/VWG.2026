// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyValueChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyValueChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [Serializable]
  public class PropertyValueChangedEventArgs : EventArgs
  {
    private readonly GridItem mobjChangedItem;
    private object mobjOldValue;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyValueChangedEventArgs"></see> class.</summary>
    /// <param name="objOldValue">The old property value. </param>
    /// <param name="objChangedItem">The item in the grid that changed. </param>
    public PropertyValueChangedEventArgs(GridItem objChangedItem, object objOldValue)
    {
      this.mobjChangedItem = objChangedItem;
      this.mobjOldValue = objOldValue;
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> that was changed.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public GridItem ChangedItem => this.mobjChangedItem;

    /// <summary>The value of the grid item before it was changed.</summary>
    /// <returns>A object representing the old value of the property.</returns>
    /// <filterpriority>1</filterpriority>
    public object OldValue => this.mobjOldValue;
  }
}
