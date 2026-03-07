// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeViewEventArgs
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
  public class TreeViewEventArgs : EventArgs
  {
    private TreeViewAction menmAction;
    private TreeNode mobjTreeNode;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTreeNode"></param>
    public TreeViewEventArgs(TreeNode objTreeNode)
      : this(objTreeNode, TreeViewAction.Unknown)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTreeNode"></param>
    /// <param name="enmAction"></param>
    public TreeViewEventArgs(TreeNode objTreeNode, TreeViewAction enmAction)
    {
      this.menmAction = enmAction;
      this.mobjTreeNode = objTreeNode;
      this.menmAction = enmAction;
    }

    /// <summary>
    /// 
    /// </summary>
    public TreeViewAction Action => this.menmAction;

    /// <summary>
    /// 
    /// </summary>
    public TreeNode Node => this.mobjTreeNode;
  }
}
