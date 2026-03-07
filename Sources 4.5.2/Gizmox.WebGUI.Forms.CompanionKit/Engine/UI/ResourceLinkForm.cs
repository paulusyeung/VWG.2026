using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.CompanionKit.UI;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	public partial class ResourceLinkForm : Form
	{
		public ResourceLinkForm()
		{
			InitializeComponent();
            
			this.Text = "Link Resource from an Item";

			mobjItemsTree.AfterSelect += new TreeViewEventHandler(OnAfterSelect);
            // Load tree
            mobjItemsTree.Load(SEOSite.Root, false, false);
		}

		/// <summary>
		/// Helper class to wrap a resource when added to checked listbox
		/// </summary>
		private class ResourceItem
		{
			public SEOItemResource resource = null;
			
			public ResourceItem(SEOItemResource objResource)
			{
				this.resource = objResource;
			}

			public override string ToString()
			{
				if (resource != null)
				{
					return string.Format("{0} - [{1}]",resource.Name, resource.ResourceInfo.Type);
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// Return the SEOItem selected to link resource
		/// </summary>
		public SEOItem SelectedItem
		{
			get
			{ 
				NavigationNode objNode = mobjItemsTree.SelectedNode as NavigationNode;
				SEOItem objItem = null;
				if (objNode != null)
				{
					objItem = SEOSite.GetItemByID(objNode.ItemID);
				}
				return objItem; 
			}
		}

		/// <summary>
		/// List of resources selected to be linked
		/// </summary>
		public List<SEOItemResource> SelectedResources
		{
			get
			{
				List<SEOItemResource> items = new List<SEOItemResource>();
				
				foreach (ResourceItem item in mobjResources.CheckedItems)
					items.Add(item.resource);

				return items;
			}
		}

		/// <summary>
		/// Process the node selected in the tree
		/// </summary>
		private void OnAfterSelect(object sender, TreeViewEventArgs e)
		{
			NavigationNode objNode = e.Node as NavigationNode;

			SEOItem objItem = SEOSite.GetItemByID(objNode.ItemID);

			// Expand if folder and not expanded
			if (objItem.Type == SEOItemType.Folder && objNode.Nodes.Count >0 && !objNode.IsExpanded)
			{
				objNode.Expand();
			}

			// Clear and load resources of clicked item
			mobjResources.Items.Clear();
			if (objItem != null)
			{
				foreach (SEOItemResource resource in objItem.Resources)
				{
					// Exclude resources that are links, to avoid link to link
					if (resource.ResourceInfo.Type != ResourceType.Link)
					{
						mobjResources.Items.Add(
							new ResourceItem(resource),
							false);
					}
				}
			}
		}

		private void BtnOKCancel_Click(object sender, EventArgs e)
		{
			if (mobjBtnCancel == sender)
			{
				this.DialogResult = DialogResult.Cancel;
			}
			else if(mobjBtnLink == sender)
			{
				this.DialogResult = DialogResult.OK;
			}
			this.Close();
		}
	}
}