// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellLinkedListElement
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DataGridViewCellLinkedListElement
  {
    private DataGridViewCell mobjDataGridViewCell;
    private DataGridViewCellLinkedListElement mobjNext;

    public DataGridViewCellLinkedListElement(DataGridViewCell objDataGridViewCell) => this.mobjDataGridViewCell = objDataGridViewCell;

    public DataGridViewCell DataGridViewCell => this.mobjDataGridViewCell;

    public DataGridViewCellLinkedListElement Next
    {
      get => this.mobjNext;
      set => this.mobjNext = value;
    }
  }
}
