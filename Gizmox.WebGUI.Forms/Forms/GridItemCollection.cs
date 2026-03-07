// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GridItemCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> objects.
  /// </summary>
  [Serializable]
  public class GridItemCollection : ICollection, IEnumerable
  {
    /// <summary>
    /// Specifies that the <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see> has no entries.
    /// </summary>
    public static GridItemCollection Empty = new GridItemCollection(new GridItem[0]);
    internal GridItem[] marrEntries;

    internal GridItemCollection(GridItem[] arrEntries)
    {
      if (arrEntries == null)
        this.marrEntries = new GridItem[0];
      else
        this.marrEntries = arrEntries;
    }

    /// <summary>
    /// Returns an enumeration of all the grid items in the collection.
    /// </summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see>.</returns>
    public IEnumerator GetEnumerator() => this.marrEntries.GetEnumerator();

    /// <summary>
    /// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
    /// </summary>
    /// <param name="objDestinationArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    void ICollection.CopyTo(Array objDestinationArray, int index)
    {
      if (this.marrEntries.Length == 0)
        return;
      Array.Copy((Array) this.marrEntries, 0, objDestinationArray, index, this.marrEntries.Length);
    }

    /// <summary>Gets the number of grid items in the collection.</summary>
    /// <returns>The number of grid items in the collection.</returns>
    public int Count => this.marrEntries.Length;

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> at the specified index.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> at the specified index.</returns>
    /// <param name="index">The index of the grid item to return. </param>
    public GridItem this[int index] => this.marrEntries[index];

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> with the matching label.
    /// </summary>
    /// <returns>The grid item whose label matches the label parameter.</returns>
    /// <param name="strLabel">A string value to match to a grid item label </param>
    public GridItem this[string strLabel]
    {
      get
      {
        foreach (GridItem marrEntry in this.marrEntries)
        {
          if (marrEntry.Label == strLabel)
            return marrEntry;
        }
        return (GridItem) null;
      }
    }

    /// <summary>
    /// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
    /// </summary>
    bool ICollection.IsSynchronized => false;

    /// <summary>
    /// For a description of this member, see <see cref="P:System.Collections.ICollection.SyncRoot"></see>.
    /// </summary>
    object ICollection.SyncRoot => (object) this;
  }
}
