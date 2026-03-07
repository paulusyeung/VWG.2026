// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.VirtualRegistryNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Virtualization.Win32;
using System;

namespace Gizmox.WebGUI.Virtualization.Management
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class VirtualRegistryNode : ServerExplorerNode
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objKey"></param>
    internal VirtualRegistryNode(VirtualRegistryKey objKey)
    {
      this.Label = this.GetLabel(objKey);
      this.Tag = (object) objKey;
      this.Image = (ResourceHandle) new IconResourceHandle("Folder.gif");
    }

    /// <summary>Gets the label.</summary>
    /// <param name="objKey">The registry key.</param>
    /// <returns></returns>
    private string GetLabel(VirtualRegistryKey objRegistryKey)
    {
      string[] strArray = objRegistryKey.Name.Split('\\');
      return strArray[strArray.Length - 1];
    }

    /// <summary>Loads the nodes.</summary>
    protected override void LoadNodes()
    {
      if (!(this.Tag is VirtualRegistryKey))
        return;
      int num = 0;
      if (!(this.Tag is VirtualRegistryKey tag))
        return;
      foreach (VirtualRegistryKey subKey in tag.GetSubKeys())
      {
        this.Nodes.Add((TreeNode) new VirtualRegistryNode(subKey));
        ++num;
        if (num > 100)
          break;
      }
    }

    /// <summary>Loads the columns.</summary>
    /// <param name="objColumns">The columns.</param>
    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 200, HorizontalAlignment.Left);
      objColumns.Add("Value", 300, HorizontalAlignment.Left);
    }

    /// <summary>Loads the items.</summary>
    /// <param name="objItems">The items.</param>
    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      if (!(this.Tag is VirtualRegistryKey tag))
        return;
      foreach (string valueName in tag.GetValueNames())
      {
        object obj = tag.GetValue(valueName);
        string strText = valueName;
        if (strText == "")
          strText = "default";
        ListViewItem listViewItem = objItems.Add(strText);
        listViewItem.Image = (ResourceHandle) new IconResourceHandle("VirtualRegistryKey.gif");
        if (obj != null)
          listViewItem.SubItems.Add(obj.ToString());
        else
          listViewItem.SubItems.Add("null");
      }
    }
  }
}
