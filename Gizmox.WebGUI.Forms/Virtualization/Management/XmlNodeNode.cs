// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.XmlNodeNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using System;
using System.Xml;

namespace Gizmox.WebGUI.Virtualization.Management
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class XmlNodeNode : ServerExplorerNode
  {
    private XmlNode mobjNode;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objNode"></param>
    internal XmlNodeNode(XmlNode objNode)
    {
      this.mobjNode = objNode;
      this.Label = objNode.Name;
      this.HasNodes = objNode.ChildNodes.Count > 0;
      this.Image = (ResourceHandle) new IconResourceHandle("file.gif");
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void LoadNodes()
    {
      foreach (XmlNode childNode in this.mobjNode.ChildNodes)
      {
        if (childNode.NodeType == XmlNodeType.Element)
          this.Nodes.Add((TreeNode) new XmlNodeNode(childNode));
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objColumns"></param>
    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 200, HorizontalAlignment.Left);
      objColumns.Add("Value", 300, HorizontalAlignment.Left);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objItems"></param>
    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) this.mobjNode.Attributes)
        objItems.Add(attribute.Name).SubItems.Add(attribute.Value);
    }
  }
}
