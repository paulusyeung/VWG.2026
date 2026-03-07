using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Virtualization.Management
{
    #region SessionNode Class


    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    internal class SessionNode : ServerExplorerNode
    {
        internal SessionNode()
        {
            Label = "Registery";
            Tag = "Registery";
            Image = new IconResourceHandle("file.gif");
        }

        protected override void LoadNodes()
        {

        }

        private void LoadControl()
        {

        }

        protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
        {
            objColumns.Add("Name", 200, HorizontalAlignment.Left);
            objColumns.Add("Value", 300, HorizontalAlignment.Left);
        }

        protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
        {
            ISessionRegistry objSessionRegistry = Gizmox.WebGUI.Common.Global.Context.Session as ISessionRegistry;
            foreach (DictionaryEntry objDictionaryEntry in objSessionRegistry)
            {
                IRegisteredComponent objRegisteredComponent = objDictionaryEntry.Value as IRegisteredComponent;
                if (objRegisteredComponent != null)
                {
                    ListViewItem objItem = objItems.Add(objRegisteredComponent.ID.ToString());
                    objItem.SubItems.Add(objRegisteredComponent.GetType().ToString());
                }
            }
        }


    }


    #endregion 
}
