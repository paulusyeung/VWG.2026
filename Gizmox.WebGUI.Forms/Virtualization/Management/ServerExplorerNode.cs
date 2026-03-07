// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.ServerExplorerNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms;
using System;

namespace Gizmox.WebGUI.Virtualization.Management
{
  [Serializable]
  internal class ServerExplorerNode : TreeNode
  {
    public ServerExplorerNode()
    {
      this.Loaded = false;
      this.IsExpanded = false;
      this.HasNodes = true;
      this.BeforeExpand += new TreeViewCancelEventHandler(this.TraceTreeNode_BeforeExpand);
      this.BeforeSelect += new TreeViewCancelEventHandler(this.TraceTreeNode_BeforeSelect);
    }

    private void TraceTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
    {
      if (this.Loaded)
        return;
      this.LoadNodes();
      this.Loaded = true;
      this.IsExpanded = true;
      this.HasNodes = this.Nodes.Count > 0;
    }

    protected virtual void LoadNodes()
    {
    }

    private void TraceTreeNode_BeforeSelect(object objSource, TreeViewCancelEventArgs objArgs)
    {
      ListView list = this.List;
      if (list == null)
        return;
      list.Columns.Clear();
      list.Items.Clear();
      list.Update();
      this.LoadColumns(list.Columns);
      this.LoadItems(list.Items);
    }

    protected virtual void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
    }

    protected virtual void LoadItems(ListView.ListViewItemCollection objItems)
    {
    }

    /// <summary>Gets the explorer.</summary>
    /// <value>The explorer.</value>
    protected ServerExplorer Explorer => this.Form as ServerExplorer;

    internal ListView List => this.TreeView is ServerExplorerTree ? ((ServerExplorerTree) this.TreeView).List : (ListView) null;

    protected internal virtual void OnItemDoubleClick(ListViewItem listViewItem)
    {
    }
  }
}
