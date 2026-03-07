// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LabelEditEventArgs
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
  public class LabelEditEventArgs : EventArgs
  {
    private bool cancelEdit;
    private readonly int item;
    private readonly string label;
    private bool mblnCancelEdit;
    private readonly string mstrLabel;
    private readonly int mintItem;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objListItem"></param>
    public LabelEditEventArgs(int intItem)
    {
      this.mblnCancelEdit = false;
      this.mintItem = intItem;
      this.mstrLabel = (string) null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs" /> class.
    /// </summary>
    /// <param name="intItem">The int item.</param>
    /// <param name="strLabel">The STR label.</param>
    public LabelEditEventArgs(int intItem, string strLabel)
    {
      this.mblnCancelEdit = false;
      this.mintItem = intItem;
      this.mstrLabel = strLabel;
    }

    /// <summary>
    /// 
    /// </summary>
    public bool CancelEdit
    {
      get => this.mblnCancelEdit;
      set => this.mblnCancelEdit = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Label => this.mstrLabel;

    /// <summary>
    /// 
    /// </summary>
    public int Item => this.mintItem;
  }
}
