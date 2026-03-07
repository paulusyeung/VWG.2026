using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class ListViewDesigner : ControlDesigner
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
                // Try casting local component to a listview.
                Gizmox.WebGUI.Forms.ListView objListView = this.Component as Gizmox.WebGUI.Forms.ListView;
                if (objListView != null)
                {
                    ArrayList objAssociatedComponents = new ArrayList();

                    // Return listview's items.
                    objAssociatedComponents.AddRange(objListView.Items);

                    // Return listview's columns.
                    objAssociatedComponents.AddRange(objListView.Columns);

                    return objAssociatedComponents;
                }

                return base.AssociatedComponents;
            }
        }
    }
}
