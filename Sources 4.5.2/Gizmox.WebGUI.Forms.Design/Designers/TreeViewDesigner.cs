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
    public class TreeViewDesigner : ControlDesigner
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
                // Try casting local component to a treeview.
                Gizmox.WebGUI.Forms.TreeView objTreeView = this.Component as Gizmox.WebGUI.Forms.TreeView;
                if (objTreeView != null)
                {
                    // Return treeview's nodes.
                    return objTreeView.Nodes;
                }

                return base.AssociatedComponents;
            }
        }
    }
}
