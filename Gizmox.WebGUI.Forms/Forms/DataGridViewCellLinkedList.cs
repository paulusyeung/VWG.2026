// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellLinkedList
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DataGridViewCellLinkedList : IEnumerable
  {
    private int mintCount;
    private DataGridViewCellLinkedListElement headElement;
    private DataGridViewCellLinkedListElement lastAccessedElement;
    private int mintLastAccessedIndex;

    public DataGridViewCellLinkedList() => this.mintLastAccessedIndex = -1;

    public void Add(DataGridViewCell objDataGridViewCell)
    {
      DataGridViewCellLinkedListElement linkedListElement = new DataGridViewCellLinkedListElement(objDataGridViewCell);
      if (this.headElement != null)
        linkedListElement.Next = this.headElement;
      this.headElement = linkedListElement;
      ++this.mintCount;
      this.lastAccessedElement = (DataGridViewCellLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
    }

    public void Clear()
    {
      this.lastAccessedElement = (DataGridViewCellLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
      this.headElement = (DataGridViewCellLinkedListElement) null;
      this.mintCount = 0;
    }

    public bool Contains(DataGridViewCell objDataGridViewCell)
    {
      int num = 0;
      DataGridViewCellLinkedListElement linkedListElement = this.headElement;
      while (linkedListElement != null)
      {
        if (linkedListElement.DataGridViewCell == objDataGridViewCell)
        {
          this.lastAccessedElement = linkedListElement;
          this.mintLastAccessedIndex = num;
          return true;
        }
        linkedListElement = linkedListElement.Next;
        ++num;
      }
      return false;
    }

    public bool Remove(DataGridViewCell objDataGridViewCell)
    {
      DataGridViewCellLinkedListElement linkedListElement1 = (DataGridViewCellLinkedListElement) null;
      DataGridViewCellLinkedListElement linkedListElement2;
      for (linkedListElement2 = this.headElement; linkedListElement2 != null && linkedListElement2.DataGridViewCell != objDataGridViewCell; linkedListElement2 = linkedListElement2.Next)
        linkedListElement1 = linkedListElement2;
      if (linkedListElement2.DataGridViewCell != objDataGridViewCell)
        return false;
      DataGridViewCellLinkedListElement next = linkedListElement2.Next;
      if (linkedListElement1 == null)
        this.headElement = next;
      else
        linkedListElement1.Next = next;
      --this.mintCount;
      this.lastAccessedElement = (DataGridViewCellLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
      return true;
    }

    public int RemoveAllCellsAtBand(bool blnColumn, int intBandIndex)
    {
      int num = 0;
      DataGridViewCellLinkedListElement linkedListElement1 = (DataGridViewCellLinkedListElement) null;
      DataGridViewCellLinkedListElement linkedListElement2 = this.headElement;
      while (linkedListElement2 != null)
      {
        if (blnColumn && linkedListElement2.DataGridViewCell.ColumnIndex == intBandIndex || !blnColumn && linkedListElement2.DataGridViewCell.RowIndex == intBandIndex)
        {
          DataGridViewCellLinkedListElement next = linkedListElement2.Next;
          if (linkedListElement1 == null)
            this.headElement = next;
          else
            linkedListElement1.Next = next;
          linkedListElement2 = next;
          --this.mintCount;
          this.lastAccessedElement = (DataGridViewCellLinkedListElement) null;
          this.mintLastAccessedIndex = -1;
          ++num;
        }
        else
        {
          linkedListElement1 = linkedListElement2;
          linkedListElement2 = linkedListElement2.Next;
        }
      }
      return num;
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new DataGridViewCellLinkedListEnumerator(this.headElement);

    public int Count => this.mintCount;

    public DataGridViewCell HeadCell => this.headElement.DataGridViewCell;

    public DataGridViewCell this[int index]
    {
      get
      {
        if (this.mintLastAccessedIndex == -1 || index < this.mintLastAccessedIndex)
        {
          DataGridViewCellLinkedListElement linkedListElement = this.headElement;
          for (int index1 = index; index1 > 0; --index1)
            linkedListElement = linkedListElement.Next;
          this.lastAccessedElement = linkedListElement;
          this.mintLastAccessedIndex = index;
          return linkedListElement.DataGridViewCell;
        }
        for (; this.mintLastAccessedIndex < index; ++this.mintLastAccessedIndex)
          this.lastAccessedElement = this.lastAccessedElement.Next;
        return this.lastAccessedElement.DataGridViewCell;
      }
    }
  }
}
