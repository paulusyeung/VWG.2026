// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellLinkedListEnumerator
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DataGridViewCellLinkedListEnumerator : IEnumerator
  {
    private DataGridViewCellLinkedListElement current;
    private DataGridViewCellLinkedListElement headElement;
    private bool mblnReset;

    public DataGridViewCellLinkedListEnumerator(DataGridViewCellLinkedListElement headElement)
    {
      this.headElement = headElement;
      this.mblnReset = true;
    }

    bool IEnumerator.MoveNext()
    {
      if (this.mblnReset)
      {
        this.current = this.headElement;
        this.mblnReset = false;
      }
      else
        this.current = this.current.Next;
      return this.current != null;
    }

    void IEnumerator.Reset()
    {
      this.mblnReset = true;
      this.current = (DataGridViewCellLinkedListElement) null;
    }

    object IEnumerator.Current => (object) this.current.DataGridViewCell;
  }
}
