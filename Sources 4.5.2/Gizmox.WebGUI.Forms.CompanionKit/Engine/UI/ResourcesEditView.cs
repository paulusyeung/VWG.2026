#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;
using System.IO;
using Gizmox.WebGUI.Common.Resources;
using System.Collections;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ResourcesEditView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private int mintSEOItem = -1;

        private string mstrSEOItemName = null;

        public ResourcesEditView()
        {
            InitializeComponent();
        }
		
		#region Adding a resource

		private void OnAddResource(object sender, EventArgs e)
		{
			mobjUploadDialog.ShowDialog();
		}

		/// <summary>
		/// Handles adding of uploaded resources
		/// </summary>
		private void OnResourceAdded(object sender, CancelEventArgs e)
		{
			// Get all file keys
			string[] arrKeys = mobjUploadDialog.Files.AllKeys;

			// Loop all keys
			foreach (string strKey in arrKeys)
			{
				// Get current file handler
				FileHandle objFileHandler = mobjUploadDialog.Files[strKey];
				if (objFileHandler != null)
				{
					string strFile = objFileHandler.FileName;
					
					string strName = GetValidResourceName(GetResourceName(objFileHandler));
					
					ListViewItem objItem = new ListViewItem(strName);
					objItem.SubItems.Add(SEOItemResourceInfo.DEFAULT_SITEMAP.ToString());
					objItem.SubItems.Add(SEOItemResourceInfo.DEFAULT_VISIBLE.ToString());
					objItem.SubItems.Add(SEOUtils.GetResourceOrder(strName).ToString());
					objItem.SubItems.Add(ResourceType.File.ToString());
					objItem.SubItems.Add(SEOItemResourceInfo.GetLanguageByName(strName).ToString());
					
					// view type - empty as default
					objItem.SubItems.Add(string.Empty);

					// title not shown - because the default to be as a name of the resource
					objItem.SubItems.Add(string.Empty);
					// save the path to file
					objItem.Tag = strFile;
					objItem.ContextMenu = mobjListMenu;
					
					// add to listview items
					mobjListResources.Items.Add(objItem);

					// select
					mobjListResources.SelectedItem = objItem;
				}
			}
		}

		#endregion

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <param name="objFileHandle">The file handle.</param>
        /// <returns></returns>
        private string GetResourceName(FileHandle objFileHandle)
        {
            // Keep the file with it native name
            return ((HttpPostedFileHandle)objFileHandle).PostedFileName;
        }

        /// <summary>
        /// Gets a valid resource name.
        /// </summary>
        /// <param name="strResourceName">The resource name.</param>
        /// <returns></returns>
        private string GetValidResourceName(string strResourceName)
        {
            // Name exists flag
            bool blnExists = false;

            // Resource instance 
            int intResourceInstance = -1;


            // The resource name to return
            string strValidResourceName = strResourceName;

            do
            {
                // Increment resource instance
                intResourceInstance++;

                // If is a instance
                if (intResourceInstance > 0)
                {
                    strValidResourceName = string.Format("{0}{1}{2}", 
                        Path.GetFileNameWithoutExtension(strResourceName), 
                        intResourceInstance, 
                        Path.GetExtension(strResourceName));
                }

                // Start that 
                blnExists = false;

                // Loop all items
                foreach (ListViewItem objItem in this.mobjListResources.Items)
                {
                    // Check name
                    if(objItem.Text.Equals(strValidResourceName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Found existing resource
                        blnExists = true;
                        break;
                    }
                }

                
            }
            while (blnExists);

            // Return the resource
            return strValidResourceName;
        }

		#region Delete
		/// <summary>
		/// Handler resource delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteResource(object sender, EventArgs e)
		{
			MessageBox.Show("Delete selected resources?", "Confirm delete", MessageBoxButtons.OKCancel, new EventHandler(OnDeleteResource_Confirmed));
		}

		/// <summary>
		/// Complete deletion of selected resources if confirmed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="objEventArgs"></param>
		private void OnDeleteResource_Confirmed(object sender, EventArgs objEventArgs)
		{
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				ArrayList objItemsToDelete = new ArrayList(mobjListResources.SelectedItems);
				foreach (ListViewItem objItemToDelete in objItemsToDelete)
				{
					mobjListResources.Items.Remove(objItemToDelete);
				}
			}
		}
		
		#endregion

		#region View Download
		/// <summary>
		/// Handle resource viewing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnViewResource(object sender, EventArgs e)
		{
			OpenForDownloadOrView(false);
		}

		/// <summary>
		/// Handler resource downloading
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDownloadResource(object sender, EventArgs e)
		{
			OpenForDownloadOrView(true);
		}

		/// <summary>
		/// Opens for download or view.
		/// </summary>
		/// <param name="blnDownload">if set to <c>true</c> [BLN download].</param>
		private void OpenForDownloadOrView(bool blnDownload)
		{
			// Get selected resource
			IEnumerable<SEOItemResource> objSelectedResources = GetSelectedResources();

			// Loop all selected resources
			foreach (SEOItemResource objResource in objSelectedResources)
			{
				// Open the download url
				LinkParameters objLinkParams = new LinkParameters();
				objLinkParams.Target = "_blank";
				Link.Open(blnDownload ? objResource.DownloadURL : objResource.ViewURL, objLinkParams);

			}
		}

		#endregion

        /// <summary>
        /// Converts all listview items to enumarable collection of resources
        /// </summary>
        private IEnumerable<SEOItemResource> SaveEditedResources(SEOItem objSEOItem)
        {
            return GetItemResources(this.EditedItem, false);
        }

        /// <summary>
        /// Converts selected listview items to enumarable collection of resources
        /// </summary>
        private IEnumerable<SEOItemResource> GetSelectedResources()
        {
            return GetItemResources(this.EditedItem, true);
        }

		private IEnumerable<SEOItemResource> GetItemResources(SEOItem objSEOItem, bool blnSelectedOnly)
		{
            List<SEOItemResource> objResources = new List<SEOItemResource>();

            // Get edited SEO item
            if (objSEOItem != null)
            {
				IEnumerable colItems = !blnSelectedOnly ? (IEnumerable)mobjListResources.Items : (IEnumerable)mobjListResources.SelectedItems;

                // Loop all selected items
                foreach (ListViewItem objListItem in colItems)
                {
                    SEOItemResource objSEOItemResource = null;
                    objSEOItemResource = GetResourceFromItem(objSEOItem, objListItem, objSEOItemResource);
                    if (objSEOItemResource != null)
                    {
                        objResources.Add(objSEOItemResource);
                    }
                }
            }

            return objResources.ToArray();
		}


        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        /// <value>The root.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SEOItem EditedItem
        {
            get
            {
                if (mintSEOItem != -1)
                {
                    return SEOSite.GetItemByID(mintSEOItem);
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    mintSEOItem = value.ID;
                    mstrSEOItemName = value.Name;
                }
                else
                {
                    mintSEOItem = -1;
                    mstrSEOItemName = null;
                }

                Bind(value);
            }
        }

        /// <summary>
        /// Saves if needed.
        /// </summary>
        internal void SaveIfNeeded(SEOItem objSEOItem)
        {
            // Get the current resources
            SEOItemResource[] objCurrentResources = objSEOItem.Resources;

            // Get the edited resources
            IEnumerable<SEOItemResource> objEditedResources = SaveEditedResources(objSEOItem);

            // Algoritem lists
            List<SEOItemResource> objDeletedResources = new List<SEOItemResource>();
            List<SEOItemResource> objCreatedResources = new List<SEOItemResource>();

            // Loop all current resources
            foreach (SEOItemResource objCurrentItem in objCurrentResources)
            {
                // A found in edited flag
                bool blnFound = false;

                // Loop all edited resources to find the item 
                foreach (SEOItemResource objEditedItem in objEditedResources)
                {
                    // If found item
                    if (objCurrentItem.ID == objEditedItem.ID)
                    {
                        // Set the found flag and exit loop
                        blnFound = true;
                        break;
                    }
                }

                // If not found add to deleted list
                if (!blnFound)
                {
                    objDeletedResources.Add(objCurrentItem);
                }
            }

            // Loop to find the NEW items
            foreach (SEOItemResource objEditedItem in objEditedResources)
            {
                // If is a new item
                if (objEditedItem.IsNew)
                {
                    // Add the resource
                    objSEOItem.AddResource(objEditedItem);
                }
            }

            // Loop all deleted resources
            foreach (SEOItemResource objDeletedResource in objDeletedResources)
            {
                // Remove resource
                objSEOItem.RemoveResource(objDeletedResource);
            }

        }

        private void Bind(SEOItem objSEOItem)
        {
            // Clear items
            mobjListResources.Items.Clear();

            if (objSEOItem != null)
            {
                SEOItemResource[] objResources = objSEOItem.Resources;
                if (objResources != null)
                {
                    foreach (SEOItemResource objResource in objResources)
                    {
                        ListViewItem objItem = new ListViewItem(objResource.Name);
                        objItem.SubItems.Add(objResource.SiteMap.ToString());
                        objItem.SubItems.Add(objResource.Visible.ToString());
                        objItem.SubItems.Add(objResource.Order.ToString());
                        objItem.SubItems.Add(objResource.ResourceInfo.Type.ToString());
						// set language
						objItem.SubItems.Add(objResource.ResourceInfo.Language.ToString());

                        // set PageScript
                        objItem.SubItems.Add(objResource.ResourceInfo.PageScript.ToString());

						// view type
						if (objResource.ResourceInfo.ViewType == ResourceViewType.Default)
							objItem.SubItems.Add(string.Empty);
						else
							objItem.SubItems.Add(objResource.ResourceInfo.ViewType.ToString());

						objItem.SubItems.Add(objResource.ResourceInfo.Title.ToString());

                        objItem.Tag = objResource.ID;
                        objItem.ContextMenu = mobjListMenu;
                        mobjListResources.Items.Add(objItem);
                    }
                }
            }
        }

        private void OnResourcesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjListResources.SelectedItems.Count > 0)
            {
                mobjButtonDelete.Enabled = true;
                mobjButtonView.Enabled = true;
                mobjButtonDownload.Enabled = true;
                mobjButtonEdit.Enabled = true;
            }
        }


        /// <summary>
        /// Gets the resource from item.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        /// <param name="objListItem">The list item.</param>
        /// <param name="objSEOItemResource">The SEO item resource.</param>
        /// <returns></returns>
        private SEOItemResource GetResourceFromItem(SEOItem objSEOItem, ListViewItem objListItem, SEOItemResource objSEOItemResource)
        {
            // if the list item tag is an int
            if (objListItem.Tag is int)
            {
                // Get the current selected item id
                int intResourceID = (int)objListItem.Tag;

                // Loop all resources
                foreach (SEOItemResource objResource in objSEOItem.Resources)
                {
                    // If found resource
                    if (objResource.ID == intResourceID)
                    {
                        objSEOItemResource = objResource;
                        break;
                    }
                }
            }
            else
            {
                // Add a new item which will be added
                objSEOItemResource = new SEOItemResource(objSEOItem, (string)objListItem.Tag, objListItem.Text);
            }
            
			// Ensure the changes that is reflected only in listview will be applied to the resource
			objSEOItemResource.ResourceInfo.SiteMap = (objListItem.SubItems[1].Text.ToLower() == "true");
            objSEOItemResource.ResourceInfo.Visible = (objListItem.SubItems[2].Text.ToLower() == "true");
            objSEOItemResource.ResourceInfo.Order = int.Parse((objListItem.SubItems[3].Text));
			objSEOItemResource.ResourceInfo.Type = 
				(ResourceType)Enum.Parse(typeof(ResourceType),(objListItem.SubItems[4].Text));
			objSEOItemResource.ResourceInfo.Language = 
				(LanguageType)Enum.Parse(typeof(LanguageType),(objListItem.SubItems[5].Text));
			objSEOItemResource.ResourceInfo.ViewType = ResourceViewType.Default;
			if (objListItem.SubItems[7].Text != string.Empty)
			{
				objSEOItemResource.ResourceInfo.ViewType = 
					(ResourceViewType)Enum.Parse(typeof(ResourceViewType),(objListItem.SubItems[7].Text));
			}
			objSEOItemResource.ResourceInfo.Title = objListItem.SubItems[8].Text;
            
			return objSEOItemResource;
        }

		#region ContextMenu Right Click Handlers

        private void OnExcludeFromSiteMap(object sender, EventArgs e)
        {
            // Loop all selected items
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[1].Text = "False";
            }
        }

        private void OnIncludeInSiteMap(object sender, EventArgs e)
        {
            // Loop all selected items
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[1].Text = "True";
            }
        }

        private void OnSetInvisible(object sender, EventArgs e)
        {
            // Loop all selected items
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[2].Text = "False";
            }
        }

        private void OnSetVisible(object sender, EventArgs e)
        {
            // Loop all selected items
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[2].Text = "True";
            }
        }
		
		private void menuItem8_Click(object sender, EventArgs e)
		{
			// order uppper [3]
			OnOrderChange(1);
		}
		private void menuItem9_Click(object sender, EventArgs e)
		{
			// order lower [3]
			OnOrderChange(-1);
		}
		private void menuItem15_Click(object sender, EventArgs e)
		{
			// order default [3]
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[3].Text = SEOItemResourceInfo.DEFAULT_ORDER.ToString();
            }		
		}
		
		private void OnOrderChange(int offset)
		{
            int intOrder = 100;
			foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
				if (!int.TryParse(objSelectedItem.SubItems[3].Text, out intOrder))
				{
					objSelectedItem.SubItems[3].Text = SEOItemResourceInfo.DEFAULT_ORDER.ToString();
				}
				else
				{
					// and validate boundaries
					int result = intOrder + offset;
					result = result >=300 ? 300 : (result <= 0 ? 1: result );
					// update 
					objSelectedItem.SubItems[3].Text = result.ToString();
				}
            }
		}

		// Language change
		private void menuItem11_Click(object sender, EventArgs e)
		{
			// lang c# [5]
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[5].Text = LanguageType.CSharp.ToString();
            }
		}
		private void menuItem12_Click(object sender, EventArgs e)
		{
			// lang VB [5]
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[5].Text = LanguageType.VBNET.ToString();
            }		
		}
		private void menuItem13_Click(object sender, EventArgs e)
		{
			// lang All [5]
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[5].Text = LanguageType.All.ToString();
            }
		}
		private void menuItem14_Click(object sender, EventArgs e)
		{
			// from name [5]
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[5].Text = SEOItemResourceInfo.GetLanguageByName(objSelectedItem.Text).ToString();
            }
		}

		private void menuItem19_Click(object sender, EventArgs e)
		{
			//default
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[7].Text = string.Empty;
            }		
		}

		private void menuItem20_Click(object sender, EventArgs e)
		{
			//noview
            foreach (ListViewItem objSelectedItem in mobjListResources.SelectedItems)
            {
                objSelectedItem.SubItems[7].Text = ResourceViewType.NoView.ToString();
            }			
		}

		#endregion

		#region Edit Resource
		private void mobjButtonEdit_Click(object sender, EventArgs e)
		{
			EditResource();
		}

		/// <summary>
		/// Edit double-clicked resource item
		/// </summary>
		private void mobjListFields_DoubleClick(object sender, EventArgs e)
		{
			EditResource();
		}

		/// <summary>
		/// Edits the resource.
		/// </summary>
		private void EditResource()
		{
			ListViewItem objItem = mobjListResources.SelectedItem;
			if (objItem != null)
			{
				SEOItemResource objResource = null;

				// Loop resources to find the item 
				foreach (SEOItemResource objEditedItem in this.EditedItem.Resources)
				{
					// The tag property will be integer if it's not a new resource info item
					if (objItem.Tag is int)
					{
						if (objEditedItem.ID == (int)objItem.Tag)
						{
							objResource = objEditedItem;
							// Avoid possible data corrupt
							bool blnOk = true;
							int intOk = 0;
							objItem.SubItems[1].Text = Boolean.TryParse(objItem.SubItems[1].Text, out blnOk) ? objItem.SubItems[1].Text : SEOItemResourceInfo.DEFAULT_SITEMAP.ToString();
							objItem.SubItems[2].Text = Boolean.TryParse(objItem.SubItems[2].Text, out blnOk) ? objItem.SubItems[2].Text : SEOItemResourceInfo.DEFAULT_VISIBLE.ToString();
							objItem.SubItems[3].Text = int.TryParse(objItem.SubItems[3].Text, out intOk) ? objItem.SubItems[3].Text : SEOItemResourceInfo.DEFAULT_ORDER.ToString();

							// Create a pseudo item to reflect last changes that could be made with context menu
							objResource = new SEOItemResource(
								this.EditedItem, objResource.ID, new SEOItemResourceInfo(
									// sitemap
									Boolean.Parse(objItem.SubItems[1].Text),
									// visible
									Boolean.Parse(objItem.SubItems[2].Text),
									// Name
									objItem.Text,
									// order
									int.Parse(objItem.SubItems[3].Text),
                                    // Script page
                                    bool.Parse(objItem.SubItems[6].Text))
								);

							objResource.ResourceInfo.Type = (ResourceType)Enum.Parse(typeof(ResourceType),(objItem.SubItems[4].Text));
							objResource.ResourceInfo.Language = (LanguageType)Enum.Parse(typeof(LanguageType),(objItem.SubItems[5].Text));
							
							// set value if not empty-default
							if (objItem.SubItems[7].Text != string.Empty)
								objResource.ResourceInfo.ViewType = (ResourceViewType)Enum.Parse(typeof(ResourceViewType),(objItem.SubItems[7].Text));

							// title
							objResource.ResourceInfo.Title = objItem.SubItems[8].Text;

							break;
						}
					}
				}
				ResourceEditForm objEditForm = null;

				// Item not found, means new and not saved yet and only stored in listview
				// So: Create new - pseudo item to enable editing
				if (objResource == null)
				{
					objResource = new SEOItemResource(
						this.EditedItem, 0, new SEOItemResourceInfo(
							// sitemap
							Boolean.Parse(objItem.SubItems[1].Text),
							// visible
							Boolean.Parse(objItem.SubItems[2].Text),
							// Name
							objItem.Text,
							// Order
							int.Parse(objItem.SubItems[3].Text),
                            // Script page
                            bool.Parse(objItem.SubItems[6].Text))
						);
					objResource.ResourceInfo.Type = (ResourceType)Enum.Parse(typeof(ResourceType),(objItem.SubItems[4].Text));
					objResource.ResourceInfo.Language = (LanguageType)Enum.Parse(typeof(LanguageType),(objItem.SubItems[5].Text));
					
					// set value if not empty-default
					if (objItem.SubItems[7].Text != string.Empty)
						objResource.ResourceInfo.ViewType = (ResourceViewType)Enum.Parse(typeof(ResourceViewType),(objItem.SubItems[7].Text));
					
					objResource.ResourceInfo.Title = objItem.SubItems[8].Text;
				}

				objEditForm = new ResourceEditForm(objResource);
				objEditForm.FormClosed +=
					(Form.FormClosedEventHandler)delegate(object sender, FormClosedEventArgs e)
					{
						if (((Form)sender).DialogResult == DialogResult.OK)
						{
							//the item changes should be applied
							objItem.SubItems[1].Text = objEditForm.DialogResource.SiteMap.ToString();
							objItem.SubItems[2].Text = objEditForm.DialogResource.Visible.ToString();
							objItem.SubItems[3].Text = objEditForm.DialogResource.Order.ToString();
							objItem.SubItems[4].Text = objEditForm.DialogResource.ResourceInfo.Type.ToString();
                            objItem.SubItems[5].Text = objEditForm.DialogResource.ResourceInfo.Language.ToString();
                            objItem.SubItems[6].Text = objEditForm.DialogResource.ResourceInfo.PageScript.ToString();

							if (objEditForm.DialogResource.ResourceInfo.ViewType == ResourceViewType.Default)
								objItem.SubItems[7].Text = "";
							else
								objItem.SubItems[7].Text = objEditForm.DialogResource.ResourceInfo.ViewType.ToString();
							
							objItem.SubItems[8].Text = objEditForm.DialogResource.ResourceInfo.Title;
						}
					};

				objEditForm.ShowDialog();
			}
		}

		#endregion

		private void LinkResource_Click(object sender, EventArgs e)
		{
			ResourceLinkForm objForm = new ResourceLinkForm();
			objForm.FormClosed += delegate (object objSender, FormClosedEventArgs objEvent)
			{
				if (objForm.DialogResult == DialogResult.OK)
				{
					List<SEOItemResource> colResources = objForm.SelectedResources;

					foreach (SEOItemResource resource in colResources)
					{
						string NamedLink = resource.NamedLink;
						ListViewItem objItem = new ListViewItem(NamedLink); //critical for correct saving

						objItem.SubItems.Add(resource.ResourceInfo.SiteMap.ToString());
						objItem.SubItems.Add(SEOItemResourceInfo.DEFAULT_VISIBLE.ToString());
						objItem.SubItems.Add(SEOUtils.GetResourceOrder(resource.FileName).ToString());
						objItem.SubItems.Add(ResourceType.Link.ToString());
						objItem.SubItems.Add(resource.ResourceInfo.Language.ToString());

						// View type - empty as default
						objItem.SubItems.Add(string.Empty);

						// Get title 
						// - for link item it's FileName
						objItem.SubItems.Add(resource.FileName);
						
						// save the path to file
						objItem.Tag = NamedLink;
						objItem.ContextMenu = mobjListMenu;
						
						// add to listview items
						mobjListResources.Items.Add(objItem);

						// select
						mobjListResources.SelectedItem = objItem;
					}
				}
			};
			objForm.ShowDialog();
		}

    }
}
