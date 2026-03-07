using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationCombo : ComboBox
    {
		private NavigationComboForm mobjNavigationForm;

        /// <summary>
        /// 
        /// </summary>
        protected class NavigationComboForm : Form
        {
            /// <summary>
            /// 
            /// </summary>
            private NavigationCombo mobjCombo = null;
			private NavigationTree mobjTree = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="NavigationComboForm"/> class.
            /// </summary>
            /// <param name="objCombo">The combo.</param>
            public NavigationComboForm(NavigationCombo objCombo)
            {
                mobjCombo = objCombo;
				
				//relate the form to the combo
				objCombo.NavigationForm = this;

                // Add a tree
                NavigationTree objTree = new NavigationTree();                
                objTree.Dock = DockStyle.Fill;
                objTree.AfterSelect += new TreeViewEventHandler(OnAfterSelect);
                objTree.BorderStyle = BorderStyle.None;
                mobjTree = objTree;
                this.Controls.Add(objTree);

                // Set the initial form size
                this.Size = new Size(objCombo.Width, 250);

                // Load tree
                objTree.Load(objCombo.Root, objCombo.FoldersOnly, objCombo.IncludeRoot);

				// Ensure visibility of selected node
				if (objCombo.SelectedNode != null)
				{
					NavigationNode objNodeItem = objTree.GetNode(objCombo.SelectedNode);
					if (objNodeItem != null)
					{
						objTree.SelectedNode = objNodeItem;
						objNodeItem.EnsureVisible();
					}
				}
            }

			/// <summary>
			/// tree node selection handler
			/// </summary>
            private void OnAfterSelect(object sender, TreeViewEventArgs e)
            {
                NavigationNode objNode = e.Node as NavigationNode;
                if (objNode != null)
                {
                    SEOItem objItem = SEOSite.GetItemByID(objNode.ItemID);
                    if (objItem != null)
                    {
                        mobjCombo.SelectedNode = objItem;
                    }
                }

                this.Close();
            }

			/// <summary>
			/// Gets the tree.
			/// </summary>
			/// <value>The tree.</value>
			[Browsable(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			public NavigationTree Tree
			{
				get { return mobjTree; }
			}	
        }

        /// <summary>
        /// 
        /// </summary>
        private bool mblnFoldersOnly;

        /// <summary>
        /// 
        /// </summary>
        private int mintSEOFolder = -1;

        /// <summary>
        /// 
        /// </summary>
        private int mintSEOSelectedNode = -1;

        /// <summary>
        /// 
        /// </summary>
        private bool mblnIncludeRoot;

        /// <summary>
        /// Gets a value indicating whether this instance has a custom drop down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
        /// </value>
        protected override bool IsCustomDropDown
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the custom form to display as drop down
        /// </summary>
        /// <returns></returns>
        protected override Form GetCustomDropDown()
        {
            return new NavigationComboForm(this);
        }

        
        /// <summary>
        /// Gets or sets a value indicating whether [folders only].
        /// </summary>
        /// <value><c>true</c> if [folders only]; otherwise, <c>false</c>.</value>
        public bool FoldersOnly
        {
            get { return mblnFoldersOnly; }
            set { mblnFoldersOnly = value; }
        }
        

        /// <summary>
        /// Gets or sets a value indicating whether [include root].
        /// </summary>
        /// <value><c>true</c> if [include root]; otherwise, <c>false</c>.</value>
        public bool IncludeRoot
        {
            get { return mblnIncludeRoot; }
            set { mblnIncludeRoot = value; }
        }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        /// <value>The root.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SEOFolder Root
        {
            get
            {
                if (mintSEOFolder != -1)
                {
                    return SEOSite.GetItemByID(mintSEOFolder) as SEOFolder;
                }
                return SEOSite.Root;
            }
            set
            {
                if (value != null)
                {
                    mintSEOFolder = value.ID;
                }
                else
                {
                    mintSEOFolder = -1;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected SEO item.
        /// </summary>
        /// <value>The selected SEO item.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SEOItem SelectedNode
        {
            get
            {
                if (mintSEOSelectedNode != -1)
                {
                    return SEOSite.GetItemByID(mintSEOSelectedNode);
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    mintSEOSelectedNode = value.ID;
                    this.Text = value.DisplayName;
                }
                else
                {
                    mintSEOSelectedNode = -1;
                    this.Text = "";
                }
            }
        }

		/// <summary>
		/// Gets or sets the navigation form.
		/// </summary>
		/// <value>The navigation form.</value>
		protected NavigationComboForm NavigationForm
		{
			get { return mobjNavigationForm; }
			set { mobjNavigationForm = value; }
		}
    }
}
