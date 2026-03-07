// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewItemSorter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Gets or sets the sorting comparer for the control.</summary>
  /// <returns>An <see cref="T:System.Collections.IComparer"></see> that represents the sorting comparer for the control.</returns>
  [Serializable]
  public class ListViewItemSorter : IComparer
  {
    private ListView mobjListView;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItemSorter" /> instance.
    /// </summary>
    /// <param name="objListView">list view.</param>
    public ListViewItemSorter(ListView objListView) => this.mobjListView = objListView;

    /// <summary>Compares two ListView Items</summary>
    /// <param name="objObjectA">object A.</param>
    /// <param name="objObjectB">object B.</param>
    /// <returns></returns>
    public int Compare(object objObjectA, object objObjectB)
    {
      ListViewItem listViewItem1 = objObjectA as ListViewItem;
      ListViewItem listViewItem2 = objObjectB as ListViewItem;
      ICollection sortingColumns = this.mobjListView.SortingColumns;
      if (listViewItem1 == null || listViewItem2 == null || sortingColumns.Count == 0)
        return 0;
      foreach (ColumnHeader columnHeader in (IEnumerable) sortingColumns)
      {
        int num1 = columnHeader.SortOrder == SortOrder.Ascending ? 1 : -1;
        int num2 = listViewItem1.SubItems[columnHeader.Index].Text.CompareTo(listViewItem2.SubItems[columnHeader.Index].Text);
        if (num2 != 0)
          return num2 * num1;
      }
      return 0;
    }
  }
}
