using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeNodeDesigner : MappedComponentDesigner
    {
        /// <summary>
        /// Gets the collection of components associated with the component managed by the designer.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The components that are associated with the component managed by the designer.
        /// </returns>
        public override ICollection AssociatedComponents
        {
            get
            {
                // Try casting local component to treenode.
                Gizmox.WebGUI.Forms.TreeNode objTreeNode = this.Component as Gizmox.WebGUI.Forms.TreeNode;
                if (objTreeNode != null)
                {
                    // Return node's nodes.
                    return objTreeNode.Nodes;
                }

                return base.AssociatedComponents;
            }
        }
    }
}
