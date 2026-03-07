// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewGroupingTreeView
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for GroupingTreeView</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewGroupingTreeViewSkin))]
  [ToolboxItem(false)]
  [Serializable]
  internal class DataGridViewGroupingTreeView : TreeView
  {
    private DataGridView mobjOwningDataGridView;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingTreeView" /> class.
    /// </summary>
    internal DataGridViewGroupingTreeView(DataGridView objOwningDataGridView)
    {
      this.mobjOwningDataGridView = objOwningDataGridView;
      this.CustomStyle = "GroupingTreeView";
      this.Dock = DockStyle.Fill;
      this.AllowDrop = true;
      this.Scrollable = true;
      this.InitializeGroupingNodes();
    }

    /// <summary>Initializes the grouping nodes.</summary>
    internal void InitializeGroupingNodes()
    {
      if (this.mobjOwningDataGridView == null)
        return;
      this.Nodes.Clear();
      this.AttachChildNode(0, (DataGridViewGroupingTreeNode) null);
      this.ExpandAll();
      this.Update();
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "CloseGroup")
      {
        string strColumnDataPropertyName = objEvent["N"];
        if (!string.IsNullOrEmpty(strColumnDataPropertyName))
        {
          this.mobjOwningDataGridView.GroupingColumns.Remove(strColumnDataPropertyName);
          this.mobjOwningDataGridView.OnGroupingChanged(DataGridViewGroupingAction.Remove, strColumnDataPropertyName);
        }
      }
      base.FireEvent(objEvent);
    }

    /// <summary>
    /// Attaches the child node to the parent -- builds treeview nodes hierearchy recursively.
    /// </summary>
    /// <param name="intGroupingColumnIndex">Index of the int grouping column.</param>
    /// <param name="objParentNode">The obj parent node.</param>
    private void AttachChildNode(
      int intGroupingColumnIndex,
      DataGridViewGroupingTreeNode objParentNode)
    {
      if (this.mobjOwningDataGridView.GroupingColumns.Count <= 0)
        return;
      string groupingColumn = this.mobjOwningDataGridView.GroupingColumns[intGroupingColumnIndex];
      string forProposedMember = this.mobjOwningDataGridView.Columns.GetRealDataMemberForProposedMember(groupingColumn);
      string strColumnDataPropertyName = (string) null;
      if (this.mobjOwningDataGridView.Columns[forProposedMember] != null)
        strColumnDataPropertyName = this.mobjOwningDataGridView.Columns[forProposedMember].HeaderText;
      if (string.IsNullOrEmpty(forProposedMember) || string.IsNullOrEmpty(strColumnDataPropertyName))
        return;
      DataGridViewGroupingTreeNode groupingTreeNode = new DataGridViewGroupingTreeNode(strColumnDataPropertyName);
      groupingTreeNode.Tag = (object) groupingColumn;
      if (objParentNode != null)
        objParentNode.Nodes.Add((TreeNode) groupingTreeNode);
      else
        this.Nodes.Add((TreeNode) groupingTreeNode);
      if (intGroupingColumnIndex + 1 >= this.mobjOwningDataGridView.GroupingColumns.Count)
        return;
      this.AttachChildNode(intGroupingColumnIndex + 1, groupingTreeNode);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (TreeNode node in (BaseCollection) this.Nodes)
        node.RenderNode(objContext, objWriter, lngRequestID, this.CheckBoxes ? CheckBoxVisibility.True : CheckBoxVisibility.False);
    }
  }
}
