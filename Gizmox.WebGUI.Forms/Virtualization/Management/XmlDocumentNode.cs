// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.XmlDocumentNode
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
  internal class XmlDocumentNode : ServerExplorerNode
  {
    private XmlDocument mobjDocument;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strLabel"></param>
    /// <param name="strPath"></param>
    internal XmlDocumentNode(string strLabel, string strPath)
    {
      this.mobjDocument = new XmlDocument();
      this.mobjDocument.Load(strPath);
      this.Label = strLabel;
      this.Tag = (object) strPath;
      this.Image = (ResourceHandle) new IconResourceHandle("Folder.gif");
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void LoadNodes()
    {
      foreach (XmlNode childNode in this.mobjDocument.DocumentElement.ChildNodes)
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
    }
  }
}
