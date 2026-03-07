// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Layout
{
  /// <summary>Represents a collection of objects.</summary>
  [Serializable]
  public class ArrangedElementCollection : IList, ICollection, IEnumerable
  {
    private ArrayList mobjInnerList;
    internal static ArrangedElementCollection Empty = new ArrangedElementCollection(0);

    internal ArrangedElementCollection() => this.mobjInnerList = new ArrayList(4);

    internal ArrangedElementCollection(ArrayList innerList) => this.mobjInnerList = innerList;

    private ArrangedElementCollection(int intSize) => this.mobjInnerList = new ArrayList(intSize);

    private static void Copy(
      ArrangedElementCollection objSourceList,
      int intSourceIndex,
      ArrangedElementCollection objDestinationList,
      int intDestinationIndex,
      int intLength)
    {
      if (intSourceIndex < intDestinationIndex)
      {
        intSourceIndex += intLength;
        intDestinationIndex += intLength;
        for (; intLength > 0; --intLength)
          objDestinationList.InnerList[--intDestinationIndex] = objSourceList.InnerList[--intSourceIndex];
      }
      else
      {
        for (; intLength > 0; --intLength)
          objDestinationList.InnerList[intDestinationIndex++] = objSourceList.InnerList[intSourceIndex++];
      }
    }

    /// <summary>Copies the entire contents of this collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
    /// <param name="objArray">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from the current collection. The array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in array at which copying begins.</param>
    /// <exception cref="T:System.InvalidCastException">The type of the source element cannot be cast automatically to the type of array.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0.</exception>
    /// <exception cref="T:System.ArgumentException">One of the following conditions has occurred:array is multidimensional.index is equal to or greater than the length of array.The number of elements in the source collection is greater than the available space from index to the end of array.</exception>
    /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
    public void CopyTo(Array objArray, int index) => this.InnerList.CopyTo(objArray, index);

    /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> instances are equal.</summary>
    /// <returns>true if the specified <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> is equal to the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>; otherwise, false.</returns>
    /// <param name="obj">The <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> to compare with the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</param>
    public override bool Equals(object obj)
    {
      if (!(obj is ArrangedElementCollection elementCollection) || this.Count != elementCollection.Count)
        return false;
      for (int index = 0; index < this.Count; ++index)
      {
        if (this.InnerList[index] != elementCollection.InnerList[index])
          return false;
      }
      return true;
    }

    /// <summary>Returns an enumerator for the entire collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the entire collection.</returns>
    public virtual IEnumerator GetEnumerator() => this.InnerList.GetEnumerator();

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</returns>
    public override int GetHashCode() => base.GetHashCode();

    internal void MoveElement(IArrangedElement objElement, int intFromIndex, int intToIndex)
    {
      int intLength = intToIndex - intFromIndex;
      switch (intLength)
      {
        case -1:
        case 1:
          this.InnerList[intFromIndex] = this.InnerList[intToIndex];
          break;
        default:
          int intSourceIndex;
          int intDestinationIndex;
          if (intLength > 0)
          {
            intSourceIndex = intFromIndex + 1;
            intDestinationIndex = intFromIndex;
          }
          else
          {
            intSourceIndex = intToIndex;
            intDestinationIndex = intToIndex + 1;
            intLength = -intLength;
          }
          ArrangedElementCollection.Copy(this, intSourceIndex, this, intDestinationIndex, intLength);
          break;
      }
      this.InnerList[intToIndex] = (object) objElement;
    }

    int IList.Add(object objValue) => this.InnerList.Add(objValue);

    void IList.Clear() => this.InnerList.Clear();

    bool IList.Contains(object objValue) => this.InnerList.Contains(objValue);

    int IList.IndexOf(object objValue) => this.InnerList.IndexOf(objValue);

    void IList.Insert(int index, object objValue) => throw new NotSupportedException();

    void IList.Remove(object objValue) => this.InnerList.Remove(objValue);

    void IList.RemoveAt(int index) => this.InnerList.RemoveAt(index);

    /// <summary>Gets the number of elements in the collection.</summary>
    /// <returns>The number of elements currently contained in the collection.</returns>
    public virtual int Count => this.InnerList.Count;

    internal ArrayList InnerList => this.mobjInnerList;

    /// <summary>Gets a value indicating whether the collection is read-only.</summary>
    /// <returns>true if the collection is read-only; otherwise, false. The default is false.</returns>
    public virtual bool IsReadOnly => this.InnerList.IsReadOnly;

    internal virtual IArrangedElement this[int index] => (IArrangedElement) this.InnerList[index];

    bool ICollection.IsSynchronized => this.InnerList.IsSynchronized;

    object ICollection.SyncRoot => this.InnerList.SyncRoot;

    bool IList.IsFixedSize => this.InnerList.IsFixedSize;

    object IList.this[int index]
    {
      get => this.InnerList[index];
      set => throw new NotSupportedException();
    }
  }
}
