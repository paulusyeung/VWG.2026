// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NodeLabelEditEventArgs
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
  public class NodeLabelEditEventArgs : EventArgs
  {
    private bool mblnCancelEdit;
    private readonly string mstrLabel;
    private readonly TreeNode mobjTreeNode;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTreeNode"></param>
    public NodeLabelEditEventArgs(TreeNode objTreeNode)
    {
      this.mblnCancelEdit = false;
      this.mobjTreeNode = objTreeNode;
      this.mstrLabel = (string) null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTreeNode"></param>
    /// <param name="strLabel"></param>
    public NodeLabelEditEventArgs(TreeNode objTreeNode, string strLabel)
    {
      this.mblnCancelEdit = false;
      this.mobjTreeNode = objTreeNode;
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
    public TreeNode Node => this.mobjTreeNode;
  }
}
