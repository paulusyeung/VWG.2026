using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Common.Resources;


namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationTree : TreeView
    {
        /// <summary>
        /// Loads the tree view with given nodes
        /// </summary>
        /// <param name="objRootSEOFolder"></param>
        /// <param name="blnFoldersOnly"></param>
        /// <param name="blnIncludeRoot"></param>
        public void Load(SEOFolder objRootSEOFolder, bool blnFoldersOnly, bool blnIncludeRoot)
        {
            // Clear previous nodes
            this.Nodes.Clear();

            // If there is a valid root folder
            if (objRootSEOFolder != null)
            {
                // If root node should be included
                if (blnIncludeRoot)
                {
                    // Get root node
                    this.Nodes.Add(new NavigationNode(objRootSEOFolder, blnFoldersOnly));
                }
                else
                {
                    // Get all root nodes
                    NavigationNode[] objNodes = NavigationNode.GetNodes(objRootSEOFolder, blnFoldersOnly);

                    // Loop all nodes
                    foreach (NavigationNode objNode in objNodes)
                    {
                        // Add nodes
                        this.Nodes.Add(objNode);
                    }
                }
            }
        }

		/// <summary>
		/// Retrieve the node with given objItem
		/// </summary>
		public NavigationNode GetNode(SEOItem objItem)
		{
            foreach (NavigationNode objNode in this.Nodes)
            {
				NavigationNode objSubNode = objNode.GetNode(objItem);
				if (objSubNode != null)
				{
					return objSubNode;
				}
            }
			return null;
		}

    }


    /// <summary>
    /// 
    /// </summary>
    public class NavigationNode : TreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly int mintSEOItem = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationNode"/> class.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        public NavigationNode(SEOItem objSEOItem, bool blnFoldersOnly)
        {
            // Save the SEO item id
            mintSEOItem = objSEOItem.ID;

            // Set the display name
            this.Text = objSEOItem.DisplayName;
            this.IsExpanded = false;

            // Get SEO folder if is folder
            SEOFolder objSEOFolder = objSEOItem as SEOFolder;
            if (objSEOFolder != null)
            {
                // Get folder nodes
                NavigationNode[] objNodes = NavigationNode.GetNodes(objSEOFolder, blnFoldersOnly);

                // Loop and attach all nodes
                foreach (NavigationNode objNode in objNodes)
                {
                    this.Nodes.Add(objNode);
                }

                // Set images
                this.Image = new IconResourceHandle("Folder.gif");
            }
            else
            {
                // Set images
                this.Image = new IconResourceHandle("Class.gif");
            }

			// Required for EnsureVisible
			if (!this.IsRegistered)
			{
				this.RegisterSelf();
			}
        }

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <param name="objSEOFolder">The SEO folder.</param>
        /// <param name="blnFoldersOnly">if set to <c>true</c> folders only.</param>
        /// <returns></returns>
        public static NavigationNode[] GetNodes(SEOFolder objSEOFolder, bool blnFoldersOnly)
        {
            List<NavigationNode> objNodes = new List<NavigationNode>();

            foreach (SEOFolder objSEOSubFolder in objSEOFolder.Folders)
            {
                objNodes.Add(new NavigationNode(objSEOSubFolder, blnFoldersOnly));
            }

            if (!blnFoldersOnly)
            {
                foreach (SEOItem objSEOSubPage in objSEOFolder.PlainItems)
                {
					if( objSEOSubPage != null )
						objNodes.Add(new NavigationNode(objSEOSubPage, false));
                }
            }
            return objNodes.ToArray();
        }

        /// <summary>
        /// Gets the item id.
        /// </summary>
        /// <value>The item id.</value>
        public int ItemID
        {
            get { return mintSEOItem; }
        }

		/// <summary>
		/// Retrieve the node by a SEOItem
		/// </summary>		
		public NavigationNode GetNode(SEOItem objItem)
		{
			if(this.ItemID == objItem.ID)
				return this;

			NavigationNode objSubNode = null;
            foreach (NavigationNode objNode in this.Nodes)
            {
				if(objNode.ItemID == objItem.ID)
					return objNode;
				
				objSubNode = objNode.GetNode(objItem);
				
				if (objSubNode != null)
					return objSubNode;
            }
			return null;
		}
    }
}
