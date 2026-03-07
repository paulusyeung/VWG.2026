// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ItemChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ItemChangedEventArgs : EventArgs
  {
    private int index;

    internal ItemChangedEventArgs(int index) => this.index = index;

    /// <summary>Indicates the position of the item being changed within the list.</summary>
    /// <returns>The zero-based index to the item being changed.</returns>
    /// <filterpriority>1</filterpriority>
    public int Index => this.index;
  }
}
