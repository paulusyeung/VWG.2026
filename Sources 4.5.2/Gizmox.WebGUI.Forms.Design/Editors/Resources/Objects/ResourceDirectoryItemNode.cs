using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;

namespace Gizmox.WebGUI.Forms.Design.Editors.Resources.Objects
{
    internal class ResourceDirectoryItem : System.Windows.Forms.ListViewItem
    {
        /// <summary>
        /// The ResourceHandleEditorDialog TreeView node for the 
        /// directory containing the file represented by this
        /// ResourceDirectoryItem
        /// </summary>
        ResourceDirectoryNode mobjParentNode;

        StringBuilder objStringBuilder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objParentNode">containing folder TreeView node</param>
        /// <param name="strFileName"></param>
        internal ResourceDirectoryItem(ResourceDirectoryNode objParentNode, string strFileName)
            : base(strFileName)
        {
            mobjParentNode = objParentNode;
            this.ImageIndex = 0;
        }



        /// <summary>
        /// Returns the ResourceHandle 'path'
        /// for example 'Images.Dir.SubDir.img.gif'
        /// </summary>
        internal string Handle
        {
            get
            {
                objStringBuilder = new StringBuilder();
                ClimbTreeView(mobjParentNode);
                // append file name
                return objStringBuilder.Append(this.Text).ToString();
            }
        }
        /// <summary>
        /// Recursive function to build Handle
        /// </summary>
        /// <param name="objDir"></param>
        private void ClimbTreeView(ResourceDirectoryNode objDir)
        {
            // don't do anything if this is not a ResourceDirectoryNode, i.e. the top 'Directories' node
            if (objDir != null && objDir is ResourceDirectoryNode)
            {
                // climb tree recursively until reaching the ResourceDirectoryRootNode ("Images","Icons",etc.)
                // appending the name after the call to the recursive function causes the string to be 
                // built from the root directory level to the containing directory level
                if (!(objDir is ResourceDirectoryRootNode))
                {
                    if (objDir.Parent != null)
                    {
                        ResourceDirectoryNode objResourceDirectoryNode = objDir.Parent as ResourceDirectoryNode;
                        if (objResourceDirectoryNode != null)
                        {
                            ClimbTreeView(objResourceDirectoryNode);
                        }
                    }
                }
                // append the directory name to the string builder
                objStringBuilder.Append(objDir.Text).Append(".");
            }
        }
    }
}