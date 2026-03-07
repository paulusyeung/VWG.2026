// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs
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
  public class ListViewItemBindingEventArgs : EventArgs
  {
    private ListViewItem mobjListViewItem;
    private object mobjDataRow;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs" /> class.
    /// </summary>
    /// <param name="objDataRow">The data row.</param>
    /// <param name="objListViewItem">The list view item.</param>
    public ListViewItemBindingEventArgs(object objDataRow, ListViewItem objListViewItem)
    {
      this.mobjListViewItem = objListViewItem;
      this.mobjDataRow = objDataRow;
    }

    /// <summary>Gets or sets the list view item.</summary>
    /// <value>The list view item.</value>
    public ListViewItem ListViewItem
    {
      get => this.mobjListViewItem;
      set => this.mobjListViewItem = value;
    }

    /// <summary>Gets or sets the data row.</summary>
    /// <value>The data row.</value>
    public object DataRow
    {
      get => this.mobjDataRow;
      set => this.mobjDataRow = value;
    }
  }
}
