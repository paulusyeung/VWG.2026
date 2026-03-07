using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using Gizmox.WebGUI.Common.Design;

namespace Gizmox.WebGUI.Forms.Design.Editors.Resources.Objects
{
    /// <summary>
    /// A ResourceDirectoryNode representing one of the root nodes,
    /// i.e., "Images", "Icons", etc.
    /// </summary>
    internal class ResourceDirectoryRootNode : ResourceDirectoryNode
    {
        internal ResourceDirectoryRootNode(DirectoryInfo objDirectory, string strName)
            : base(objDirectory, strName)
        {

        }
    }
}
