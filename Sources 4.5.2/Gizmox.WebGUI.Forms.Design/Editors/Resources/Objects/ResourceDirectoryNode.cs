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
    /// A TreeView TreeNode subclass, representing one of the folders in 
    /// the Resources directories
    /// </summary>
    internal class ResourceDirectoryNode : System.Windows.Forms.TreeNode
    {
        #region Members

        /// <summary>
        /// The DirectoryInfo object for the directory which the ResourceHandleEditorDialog 
        /// TreeView node represents
        /// </summary>
        private DirectoryInfo mobjDirectory = null;
        #endregion

        #region C'tor

        internal ResourceDirectoryNode(DirectoryInfo objDirectory)
            : this(objDirectory, objDirectory.Name)
        {
        }

        internal ResourceDirectoryNode(DirectoryInfo objDirectory, string strName)
        {
            mobjDirectory = objDirectory;
            this.Text = strName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the files contained in the directory,
        /// filtered by the strSearchPattern
        /// </summary>
        /// <param name="strSearchPattern">Definition of search pattern, 
        ///     for example: *.*,*.gif,*.jpeg
        /// </param>
        /// <returns>An array of FileInfo objects</returns>
        internal FileInfo[] GetItems(string strSearchPattern)
        {
            return mobjDirectory.GetFiles(strSearchPattern);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The DirectoryInfo object for the directory that this node represents
        /// </summary>
        internal DirectoryInfo Directory
        {
            get 
            { 
                return mobjDirectory; 
            }
        }

        /// <summary>
        /// An array containing DirectoryInfo objects for the subdirectories
        /// of the directory that this node represents
        /// </summary>
        internal DirectoryInfo[] SubDirectories
        {
            get 
            {
                return mobjDirectory.GetDirectories();
            }
        }

        /// <summary>
        /// An array containing FileInfo objects for the files contained in
        /// the directory that this node represents
        /// </summary>
        internal FileInfo[] Files
        {
            get
            {
                return mobjDirectory.GetFiles();
            }
        }
        #endregion
    }
}
