using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Virtualization.Management
{
    internal class PhysicalStorageNode : ServerExplorerNode
    {
        
        internal PhysicalStorageNode(string strDirectory)
        {
            this.Tag = strDirectory;
            this.Label = Path.GetFileName(strDirectory.Trim('/','\\'));
            this.Image = new IconResourceHandle("Folder.gif");
        }

        protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
        {
            objColumns.Add("Name", 150, HorizontalAlignment.Left);
            objColumns.Add("Size", 150, HorizontalAlignment.Left);
            objColumns.Add("Type", 150, HorizontalAlignment.Left);
            objColumns.Add("Date Modified", 150, HorizontalAlignment.Left);
        }

        protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
        {
            if (Directory.Exists((string)this.Tag))
            {
                DirectoryInfo objDirectory = new DirectoryInfo((string)this.Tag);

                foreach(FileInfo objFileInfo in objDirectory.GetFiles())
                {
                    ListViewItem objListItem = objItems.Add(objFileInfo.Name);
                    objListItem.SmallImage = new IconResourceHandle("File.gif");
                    objListItem.Tag = objFileInfo.FullName;
                    objListItem.SubItems.Add(((int)(objFileInfo.Length / 1024)).ToString() + "Kb");
                    objListItem.SubItems.Add(objFileInfo.Extension);
                    objListItem.SubItems.Add(objFileInfo.LastWriteTime.ToShortDateString());

                }
            }
        }

        protected override void LoadNodes()
        {
            if (Directory.Exists((string)this.Tag))
            {
                DirectoryInfo objDirectory = new DirectoryInfo((string)this.Tag);

                foreach(DirectoryInfo objDirectoryInfo in objDirectory.GetDirectories())
                {
                    this.Nodes.Add(new PhysicalStorageNode(objDirectoryInfo.FullName));
                }
            }
        }
    }
}
