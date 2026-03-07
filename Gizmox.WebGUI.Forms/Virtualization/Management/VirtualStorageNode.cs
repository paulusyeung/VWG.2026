// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.VirtualStorageNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;

namespace Gizmox.WebGUI.Virtualization.Management
{
  internal class VirtualStorageNode : ServerExplorerNode
  {
    private string mstrSelectedFile = "";

    internal VirtualStorageNode(string strDirectory)
      : this(strDirectory, "")
    {
    }

    internal VirtualStorageNode(string strDirectory, string strLabel)
    {
      this.Tag = (object) strDirectory;
      if (strLabel != "")
      {
        this.Label = strLabel;
      }
      else
      {
        string[] strArray1 = strDirectory.Split('\\');
        if (strArray1.Length != 0)
        {
          string[] strArray2 = strArray1;
          this.Label = strArray2[strArray2.Length - 1];
        }
        else
          this.Label = "N/A";
      }
      if (strDirectory != "")
        this.Image = (ResourceHandle) new IconResourceHandle("Folder.gif");
      else
        this.Image = (ResourceHandle) new IconResourceHandle("Storage.gif");
    }

    /// <summary>Loads the columns.</summary>
    /// <param name="objColumns">The columns.</param>
    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 150, HorizontalAlignment.Left);
      objColumns.Add("Size", 100, HorizontalAlignment.Left);
      objColumns.Add("Type", 100, HorizontalAlignment.Left);
      objColumns.Add("Date Modified", 100, HorizontalAlignment.Left);
      objColumns.Add("Date Created", 100, HorizontalAlignment.Left);
    }

    /// <summary>Loads the items.</summary>
    /// <param name="objItems">The items.</param>
    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      string tag = (string) this.Tag;
      if (!(tag != "") || !VirtualDirectory.Exists(tag))
        return;
      foreach (VirtualFileInfo file in new VirtualDirectoryInfo(tag).GetFiles())
      {
        ListViewItem listViewItem = objItems.Add(file.Name);
        listViewItem.Tag = (object) file.FullName;
        listViewItem.SmallImage = (ResourceHandle) new IconResourceHandle("File.gif");
        listViewItem.SubItems.Add(this.GetFileLength(file.Length));
        listViewItem.SubItems.Add(file.Extension);
        listViewItem.SubItems.Add(file.LastWriteTime.ToShortDateString());
        listViewItem.SubItems.Add(file.CreationTime.ToShortDateString());
      }
    }

    protected internal override void OnItemDoubleClick(ListViewItem listViewItem)
    {
      this.mstrSelectedFile = (string) listViewItem.Tag;
      int num = (int) MessageBox.Show(this.mstrSelectedFile);
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
    /// <param name="objHostContext">The gateway request HOST context.</param>
    /// <param name="strAction">The gateway request action.</param>
    /// <returns>
    /// By default this method returns a instance of a class which implements the IGatewayHandler and
    /// throws a non implemented HttpException.
    /// </returns>
    /// <remarks>
    /// This method is called from the implementation of IGatewayComponent which replaces the
    /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
    /// RegisteredComponent class which is the base class of most of the Visual WebGui
    /// components.
    /// Referencing a RegisterComponent that overrides this method is done the same way that
    /// a control implementing IGatewayControl, which is by using the GatewayReference class.
    /// </remarks>
    protected override IGatewayHandler ProcessGatewayRequest(
      HostContext objHostContext,
      string strAction)
    {
      return (IGatewayHandler) null;
    }

    /// <summary>Gets the length of the file.</summary>
    /// <param name="lngFileLength">Length of the file.</param>
    /// <returns></returns>
    private string GetFileLength(long lngFileLength)
    {
      if (lngFileLength < 1024L && lngFileLength > 0L)
        return "1Kb";
      return lngFileLength > 1024L ? ((int) (lngFileLength / 1024L)).ToString() + "Kb" : "0Kb";
    }

    /// <summary>Loads the nodes.</summary>
    protected override void LoadNodes()
    {
      string tag = (string) this.Tag;
      if (tag == "")
      {
        foreach (VirtualDriveInfo drive in VirtualDriveInfo.GetDrives())
          this.Nodes.Add((TreeNode) new VirtualStorageNode(drive.Name));
      }
      else
      {
        if (!VirtualDirectory.Exists(tag))
          return;
        foreach (VirtualFileSystemInfo directory in new VirtualDirectoryInfo(tag).GetDirectories())
          this.Nodes.Add((TreeNode) new VirtualStorageNode(directory.FullName));
      }
    }
  }
}
