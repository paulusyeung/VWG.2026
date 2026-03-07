using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Data;

using Gizmox.WebGUI.Forms;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Forms.Design
{

    /// <summary>
    /// 
    /// </summary>
    public class SplitContainerDesigner : ComponentDesigner

    {
        /// <summary>
        /// Prepares the designer to view, edit, and design the specified component.
        /// </summary>
        /// <param name="component">The component for this designer.</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            SplitContainer objSplitContainer = component as SplitContainer;
            if (objSplitContainer != null)
            {
                this.EnableSplitterPanelDesignMode(objSplitContainer.Site, objSplitContainer.Panel1, "Panel1");
                this.EnableSplitterPanelDesignMode(objSplitContainer.Site, objSplitContainer.Panel2, "Panel2");
            }
        }

        /// <summary>
        /// Enables the splitter panel design mode.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected void EnableSplitterPanelDesignMode(ISite objSite, Control objControl, string strName)
        {
            if (objSite != null && objControl != null)
            {
                INestedContainer objNestedContainer = objSite.GetService(typeof(INestedContainer)) as INestedContainer;
                if (objNestedContainer != null)
                {
                    bool blnControlExist = false;

                    for (int i = 0; i < objNestedContainer.Components.Count; i++)
                    {
                        if (objNestedContainer.Components[i].Equals(objControl))
                        {
                            blnControlExist = true;
                            break;
                        }
                    }

                    if (!blnControlExist)
                    {
                        objNestedContainer.Add(objControl, strName);
                    }
                }
            }
        }
    }
}

