// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.PhysicalStorageNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using System.IO;

namespace Gizmox.WebGUI.Virtualization.Management
{
  internal class PhysicalStorageNode : ServerExplorerNode
  {
    internal PhysicalStorageNode(string strDirectory)
    {
      this.Tag = (object) strDirectory;
      this.Label = Path.GetFileName(strDirectory.Trim('/', '\\'));
      this.Image = (ResourceHandle) new IconResourceHandle("Folder.gif");
    }

    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 150, HorizontalAlignment.Left);
      objColumns.Add("Size", 150, HorizontalAlignment.Left);
      objColumns.Add("Type", 150, HorizontalAlignment.Left);
      objColumns.Add("Date Modified", 150, HorizontalAlignment.Left);
    }

    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      if (!Directory.Exists((string) this.Tag))
        return;
      foreach (FileInfo file in new DirectoryInfo((string) this.Tag).GetFiles())
      {
        ListViewItem listViewItem = objItems.Add(file.Name);
        listViewItem.SmallImage = (ResourceHandle) new IconResourceHandle("File.gif");
        listViewItem.Tag = (object) file.FullName;
        listViewItem.SubItems.Add(((int) (file.Length / 1024L)).ToString() + "Kb");
        listViewItem.SubItems.Add(file.Extension);
        listViewItem.SubItems.Add(file.LastWriteTime.ToShortDateString());
      }
    }

    protected override void LoadNodes()
    {
      if (!Directory.Exists((string) this.Tag))
        return;
      foreach (FileSystemInfo directory in new DirectoryInfo((string) this.Tag).GetDirectories())
        this.Nodes.Add((TreeNode) new PhysicalStorageNode(directory.FullName));
    }
  }
}
