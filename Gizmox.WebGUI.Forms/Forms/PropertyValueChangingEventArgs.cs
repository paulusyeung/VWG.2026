// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyValueChangingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyValueChanging"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [Serializable]
  public class PropertyValueChangingEventArgs : EventArgs
  {
    private readonly GridItem mobjChangingItem;
    private object mobjNewValue;
    private bool mblnCancel;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyValueChangingEventArgs"></see> class.</summary>
    /// <param name="objNewValue">The new property value. </param>
    /// <param name="objChangingItem">The item in the grid that is changing. </param>
    public PropertyValueChangingEventArgs(GridItem objChangingItem, object objNewValue)
    {
      this.mobjChangingItem = objChangingItem;
      this.mobjNewValue = objNewValue;
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> that is changing.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public GridItem ChangingItem => this.mobjChangingItem;

    /// <summary>The value that the grid item will be changed to.</summary>
    /// <returns>A object representing the new value of the property.</returns>
    /// <filterpriority>1</filterpriority>
    public object NewValue
    {
      get => this.mobjNewValue;
      set => this.mobjNewValue = value;
    }

    /// <summary>Used to select whether the property change action should be cancelled.</summary>
    /// <returns>True if the change action will be cancelled, otherwise false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool Cancel
    {
      get => this.mblnCancel;
      set => this.mblnCancel = value;
    }
  }
}
