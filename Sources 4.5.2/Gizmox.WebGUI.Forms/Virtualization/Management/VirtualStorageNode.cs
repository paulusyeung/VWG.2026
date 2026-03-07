using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Virtualization.Management
{
    internal class VirtualStorageNode : ServerExplorerNode
    {
        private string mstrSelectedFile = "";

        internal VirtualStorageNode(string strDirectory) : this(strDirectory, "")
        {

        }

        internal VirtualStorageNode(string strDirectory, string strLabel)
        {
            this.Tag = strDirectory;
            if (strLabel != "")
            {
                this.Label = strLabel;
            }
            else
            {
                string[] arrDirectoryName = strDirectory.Split('\\');
                if (arrDirectoryName.Length > 0)
                {
                    this.Label = arrDirectoryName[arrDirectoryName.Length - 1];
                }
                else
                {
                    this.Label = "N/A";
                }
            }
            if (strDirectory != "")
            {
                this.Image = new IconResourceHandle("Folder.gif");
            }
            else
            {
                this.Image = new IconResourceHandle("Storage.gif");
            }
        }

        /// <summary>
        /// Loads the columns.
        /// </summary>
        /// <param name="objColumns">The columns.</param>
        protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
        {
            objColumns.Add("Name", 150, HorizontalAlignment.Left);
            objColumns.Add("Size", 100, HorizontalAlignment.Left);
            objColumns.Add("Type", 100, HorizontalAlignment.Left);
            objColumns.Add("Date Modified", 100, HorizontalAlignment.Left);
            objColumns.Add("Date Created", 100, HorizontalAlignment.Left);
        }

        /// <summary>
        /// Loads the items.
        /// </summary>
        /// <param name="objItems">The items.</param>
        protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
        {
            string strDirectory = (string)this.Tag;
            if (strDirectory != "")
            {
                if (VirtualDirectory.Exists(strDirectory))
                {
                    VirtualDirectoryInfo objDirectory = new VirtualDirectoryInfo(strDirectory);

                    foreach (VirtualFileInfo objFileInfo in objDirectory.GetFiles())
                    {
                        ListViewItem objListItem = objItems.Add(objFileInfo.Name);
                        objListItem.Tag = objFileInfo.FullName;
                        objListItem.SmallImage = new IconResourceHandle("File.gif");
                        objListItem.SubItems.Add(GetFileLength(objFileInfo.Length));
                        objListItem.SubItems.Add(objFileInfo.Extension);
                        objListItem.SubItems.Add(objFileInfo.LastWriteTime.ToShortDateString());
                        objListItem.SubItems.Add(objFileInfo.CreationTime.ToShortDateString());

                    }
                }
            }
        }

        protected internal override void OnItemDoubleClick(ListViewItem listViewItem)
        {
            mstrSelectedFile =  (string)listViewItem.Tag;
            MessageBox.Show(mstrSelectedFile);
            //LinkParameters objParams = new LinkParameters();
            //objParams.Target = "_self";
            //objParams.WindowStyle = LinkWindowStyle.Normal;
            //Link.Open(new GatewayReference(this,"Download"),objParams);
        }

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
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
        protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
        {
            //if(strAction == "Download")
            //{
            //    byte[] arrContent = VirtualFile.ReadAllBytes(mstrSelectedFile);
            //}
 	        return null;
        }

        /// <summary>
        /// Gets the length of the file.
        /// </summary>
        /// <param name="lngFileLength">Length of the file.</param>
        /// <returns></returns>
        private string GetFileLength(long lngFileLength)
        {
            if (lngFileLength < 1024 && lngFileLength > 0)
            {
                return "1Kb";
            }
            else if (lngFileLength > 1024)
            {
                return ((int)(lngFileLength / 1024)).ToString() + "Kb";
            }
            else
            {
                return "0Kb";
            }
        }

        /// <summary>
        /// Loads the nodes.
        /// </summary>
        protected override void LoadNodes()
        {
            string strDirectory = (string)this.Tag;
            if (strDirectory == "")
            {
                foreach (VirtualDriveInfo objDriveInfo in VirtualDriveInfo.GetDrives())
                {
                    this.Nodes.Add(new VirtualStorageNode(objDriveInfo.Name));
                }
            }
            else
            {
                if (VirtualDirectory.Exists(strDirectory))
                {
                    VirtualDirectoryInfo objDirectory = new VirtualDirectoryInfo(strDirectory);

                    foreach (VirtualDirectoryInfo objDirectoryInfo in objDirectory.GetDirectories())
                    {
                        this.Nodes.Add(new VirtualStorageNode(objDirectoryInfo.FullName));
                    }
                }
            }
        }
    }
}
