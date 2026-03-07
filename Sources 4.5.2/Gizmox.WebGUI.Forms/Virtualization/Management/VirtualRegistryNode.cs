#region Using

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Virtualization.Win32;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Virtualization.Management
{
	#region VirtualRegistryNode Class
	
	/// <summary>
	///
	/// </summary>
    [Serializable()]
    internal class VirtualRegistryNode : ServerExplorerNode
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objKey"></param>
		internal VirtualRegistryNode(VirtualRegistryKey objKey)
		{			
            this.Label      = GetLabel(objKey);
			this.Tag		= objKey;
			this.Image		= new IconResourceHandle("Folder.gif");
		}
		
		#endregion C'Tor / D'Tor
		
		#region Methods

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="objKey">The registry key.</param>
        /// <returns></returns>
        private string GetLabel(VirtualRegistryKey objRegistryKey)
        {
            string[] arrName = objRegistryKey.Name.Split('\\');
            return arrName[arrName.Length - 1];
        }


        /// <summary>
        /// Loads the nodes.
        /// </summary>
		protected override void LoadNodes()
		{
            if (Tag is VirtualRegistryKey)
			{
				int intIndex=0;

                // Get the registry key from the tag
                VirtualRegistryKey objKey = this.Tag as VirtualRegistryKey;
				if(objKey!=null)
				{
                    // Get all the sub keys
                    VirtualRegistryKey[] arrSubKeys = objKey.GetSubKeys();

                    // Loop all sub keys
                    foreach (VirtualRegistryKey objSubKey in arrSubKeys)
					{
                        // Add current node
                        this.Nodes.Add(new VirtualRegistryNode(objSubKey));
						intIndex++;

                        // Limit to 100 nodes
						if(intIndex>100) break;
					}
				}
			}
		}


        /// <summary>
        /// Loads the columns.
        /// </summary>
        /// <param name="objColumns">The columns.</param>
		protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
		{
			objColumns.Add("Name",200,HorizontalAlignment.Left);
			objColumns.Add("Value",300,HorizontalAlignment.Left);
		}


        /// <summary>
        /// Loads the items.
        /// </summary>
        /// <param name="objItems">The items.</param>
		protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
		{
			VirtualRegistryKey objKey = Tag as VirtualRegistryKey;
			if(objKey!=null)
			{
				
				foreach(string strValueName in objKey.GetValueNames())
				{
					object objValue = objKey.GetValue(strValueName);
					string strName = strValueName;
					if(strName=="") strName = "default";

                    ListViewItem objListItem = objItems.Add(strName);
                    objListItem.Image = new IconResourceHandle("VirtualRegistryKey.gif");
					if(objValue!=null)
					{
                        objListItem.SubItems.Add(objValue.ToString());
					}
					else
					{
                        objListItem.SubItems.Add("null");
					}
				}
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion VirtualRegistryNode Class
	
}
