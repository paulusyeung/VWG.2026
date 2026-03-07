// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewIntLinkedList
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DataGridViewIntLinkedList : IEnumerable
  {
    private int mintCount;
    private DataGridViewIntLinkedListElement headElement;
    private DataGridViewIntLinkedListElement lastAccessedElement;
    private int mintLastAccessedIndex;

    public DataGridViewIntLinkedList() => this.mintLastAccessedIndex = -1;

    public DataGridViewIntLinkedList(DataGridViewIntLinkedList source)
    {
      int count = source.Count;
      for (int index = 0; index < count; ++index)
        this.Add(source[index]);
    }

    public void Add(int integer)
    {
      DataGridViewIntLinkedListElement linkedListElement = new DataGridViewIntLinkedListElement(integer);
      if (this.headElement != null)
        linkedListElement.Next = this.headElement;
      this.headElement = linkedListElement;
      ++this.mintCount;
      this.lastAccessedElement = (DataGridViewIntLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
    }

    public void Clear()
    {
      this.lastAccessedElement = (DataGridViewIntLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
      this.headElement = (DataGridViewIntLinkedListElement) null;
      this.mintCount = 0;
    }

    public bool Contains(int integer)
    {
      int num = 0;
      DataGridViewIntLinkedListElement linkedListElement = this.headElement;
      while (linkedListElement != null)
      {
        if (linkedListElement.Int == integer)
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

    public int IndexOf(int integer) => this.Contains(integer) ? this.mintLastAccessedIndex : -1;

    public bool Remove(int integer)
    {
      DataGridViewIntLinkedListElement linkedListElement1 = (DataGridViewIntLinkedListElement) null;
      DataGridViewIntLinkedListElement linkedListElement2;
      for (linkedListElement2 = this.headElement; linkedListElement2 != null && linkedListElement2.Int != integer; linkedListElement2 = linkedListElement2.Next)
        linkedListElement1 = linkedListElement2;
      if (linkedListElement2.Int != integer)
        return false;
      DataGridViewIntLinkedListElement next = linkedListElement2.Next;
      if (linkedListElement1 == null)
        this.headElement = next;
      else
        linkedListElement1.Next = next;
      --this.mintCount;
      this.lastAccessedElement = (DataGridViewIntLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
      return true;
    }

    public void RemoveAt(int index)
    {
      DataGridViewIntLinkedListElement linkedListElement1 = (DataGridViewIntLinkedListElement) null;
      DataGridViewIntLinkedListElement linkedListElement2 = this.headElement;
      for (; index > 0; --index)
      {
        linkedListElement1 = linkedListElement2;
        linkedListElement2 = linkedListElement2.Next;
      }
      DataGridViewIntLinkedListElement next = linkedListElement2.Next;
      if (linkedListElement1 == null)
        this.headElement = next;
      else
        linkedListElement1.Next = next;
      --this.mintCount;
      this.lastAccessedElement = (DataGridViewIntLinkedListElement) null;
      this.mintLastAccessedIndex = -1;
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new DataGridViewIntLinkedListEnumerator(this.headElement);

    public int Count => this.mintCount;

    public int HeadInt => this.headElement.Int;

    public int this[int index]
    {
      get
      {
        if (this.mintLastAccessedIndex == -1 || index < this.mintLastAccessedIndex)
        {
          DataGridViewIntLinkedListElement linkedListElement = this.headElement;
          for (int index1 = index; index1 > 0; --index1)
            linkedListElement = linkedListElement.Next;
          this.lastAccessedElement = linkedListElement;
          this.mintLastAccessedIndex = index;
          return linkedListElement.Int;
        }
        for (; this.mintLastAccessedIndex < index; ++this.mintLastAccessedIndex)
          this.lastAccessedElement = this.lastAccessedElement.Next;
        return this.lastAccessedElement.Int;
      }
      set
      {
        if (index != this.mintLastAccessedIndex)
        {
          int num = this[index];
        }
        this.lastAccessedElement.Int = value;
      }
    }
  }
}
