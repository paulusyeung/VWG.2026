#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.CustomControls
{
    /// <summary>
    /// A ListView control
    /// </summary>
    [Skin(typeof(FileManagerFoldersListViewSkin))]
    [Serializable()]
    public class FileManagerFoldersListView : ListView
    {
        public FileManagerFoldersListView()
        {
            this.CustomStyle = "FileManagerFoldersListViewSkin";
        }
    }
}
