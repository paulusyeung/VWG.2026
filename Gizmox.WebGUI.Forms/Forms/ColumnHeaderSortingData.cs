// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnHeaderSortingData
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ColumnHeaderSortingData : IComparer
  {
    /// <summary>
    /// 
    /// </summary>
    private ListView mobjListView;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderSortingData" /> instance.
    /// </summary>
    /// <param name="objListView">list view.</param>
    public ColumnHeaderSortingData(ListView objListView) => this.mobjListView = objListView;

    /// <summary>Compares the specified column headers</summary>
    /// <param name="objObjectA">Column A.</param>
    /// <param name="objObjectB">Column B.</param>
    /// <returns></returns>
    public int Compare(object objObjectA, object objObjectB)
    {
      ColumnHeader columnHeader1 = objObjectA as ColumnHeader;
      ColumnHeader columnHeader2 = objObjectB as ColumnHeader;
      if (columnHeader1.SortPosition > columnHeader2.SortPosition)
        return 1;
      return columnHeader1.SortPosition < columnHeader2.SortPosition ? -1 : 0;
    }

    /// <summary>
    /// Gets the columns in the order there are used in the sorting.
    /// </summary>
    /// <value></value>
    public ICollection SortedColumns
    {
      get
      {
        ArrayList sortedColumns = new ArrayList((ICollection) this.mobjListView.Columns);
        sortedColumns.Sort((IComparer) this);
        return (ICollection) sortedColumns;
      }
    }

    /// <summary>Gets the sorting participating columns.</summary>
    /// <value></value>
    public ICollection SortingColumns
    {
      get
      {
        ArrayList sortingColumns = new ArrayList();
        foreach (ColumnHeader sortedColumn in (IEnumerable) this.SortedColumns)
        {
          if (sortedColumn.SortOrder != SortOrder.None)
            sortingColumns.Add((object) sortedColumn);
        }
        return (ICollection) sortingColumns;
      }
    }
  }
}
