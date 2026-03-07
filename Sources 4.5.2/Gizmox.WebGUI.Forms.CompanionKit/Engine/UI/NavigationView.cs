using System;
using System.Web;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

using Gizmox.WebGUI.Forms.CompanionKit.Engine;


namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{

    /// <summary>
    /// The implementation of the Main view of CompanionKit
    /// </summary>
    [ToolboxItem(false)]
    [MetadataTag("GZNV")]
    [Skin(typeof(NavigationViewSkin))]
    public class NavigationView : ContainerControl
    {

        #region NavigationViewItemState Class

        /// <summary>
        /// State of Item: IsExpanded(default: false) and UpdatedOn(default: 0)
        /// </summary>
        private class NavigationViewItemState
        {
            /// <summary>
            /// 
            /// </summary>
            private long mlngUpdatedOn = 0;

            /// <summary>
            /// 
            /// </summary>
            private bool mblnIsExpanded = false;
            
            /// <summary>
            /// Gets or sets the updated on.
            /// </summary>
            public long UpdatedOn
            {
                get { return mlngUpdatedOn; }
                set { mlngUpdatedOn = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is expanded.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is expanded; otherwise, <c>false</c>.
            /// </value>
            public bool IsExpanded
            {
                get { return mblnIsExpanded; }
                set { mblnIsExpanded = value; }
            }

        }
        
        #endregion

        #region NavigationViewState Enum
        
        /// <summary>
        /// Lobby, Page, Edit, Search, Validation, Article
        /// </summary>
        private enum NavigationViewState
        {
            /// <summary>
            /// A Lobby - a page with HTML pieces of description summarizing
            /// specific funcitonality
            /// </summary>
            Lobby,

            /// <summary>
            /// A Page containing the functionality demo, properties inspector,
            /// code pane
            /// </summary>
            Page,

            /// <summary>
            /// A page containing the detailes like title, description, keywords
            /// elements, resources
            /// </summary>
            Edit,

            /// <summary>
            /// The page containing the results of the search
            /// </summary>
            Search,

            /// <summary>
            /// The state where we are running Validate() on all items
            /// The results will be rendered as search results
            /// </summary>
            /// <remarks>
            /// Implemented:
            ///     checking the links of SEOElements to other Items
            ///     checking all resource files available
			///     checking all UserControls are could be instanciated on the page (snippets)
			///		checking all lobby links between items
			/// See: DOC-6328
            /// </remarks>
            Validation,

            /// <summary>
            /// In general the Article item is a reference to the KB article
            /// </summary>
            Article,

            /// <summary>
            /// The state of editing the KB Article, required to distinguish
			/// between edit and view URL when opening the article
			/// </summary>
			ArticleContentEdit
        } 

        #endregion

        /// <summary>
        /// The current selected item ID
        /// </summary>
        private int mintCurrentItemID = 0;

        /// <summary>
        /// The current selected category
        /// </summary>
        private int mintCurrentCategoryID = 0;

        /// <summary>
        /// The panel container
        /// </summary>
        private Panel mobjContainer = null;

        /// <summary>
        /// The last update time of the container panel
        /// </summary>
        private long mintContainerUpdate = 0;

        /// <summary>
        /// The container title
        /// </summary>
        private string mstrContainerTitle = string.Empty;

        /// <summary>
        /// The container View state
        /// </summary>
        private NavigationViewState menmNavigationViewState = NavigationViewState.Page;

        /// <summary>
        /// The last update time of the categories container panel
        /// </summary>
        private long mintCategoriesUpdate = 0;

        /// <summary>
        /// The last update time of the nodes container panel
        /// </summary>
        private long mintNodesUpdate = 0;

        /// <summary>
        /// Is the view opened in Admin mode when the editing/adding/deleting enabled
        /// </summary>
        private bool mblnIsAdmin = false;

		private bool mblnIsPreview = false;
        
        /// <summary>
        /// The dictionary of states indexed by Item ID
        /// </summary>
        private Dictionary<int, NavigationViewItemState> mobjState = null;

        /// <summary>
        /// The search wildcard to use with SEOSite.Root.SearchItems()
        /// </summary>
        private string mstrSearchWildcard = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationView"/> class.
        /// </summary>
        public NavigationView(SEOItem objSelectedItem, bool blnIsAdmin)
        {
            // Get the current tick time
            long lngCurrentTick = DateTime.Now.Ticks;

			objSelectedItem = Redirect(objSelectedItem);

            // Set the current admin state
            mblnIsAdmin = blnIsAdmin;

            // Set the update time of the container to now
            mintCategoriesUpdate = mintNodesUpdate = mintContainerUpdate = lngCurrentTick;

            // Create a new state dictionary
            mobjState = new Dictionary<int, NavigationViewItemState>();

            // Show the item in the tree
            EnsureVisible(objSelectedItem);

            // Add the container panel
            mobjContainer = new Panel();
            mobjContainer.Dock = DockStyle.Top;
            mobjContainer.AutoSize = true;
            mobjContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(mobjContainer);

            // Attach bookmark naviagation
            Application.ThreadBookmarkNavigate += new ThreadBookmarkEventHandler(OnThreadBookmarkNavigate);

            // Set current item
            LoadItem(objSelectedItem, false);


			// SEOUtils.UpdateNamespace();
        }


		/// <summary>
		/// Redirects the current item to given one. Takes in account the Default item
		/// defined for lobby items and folders.
		/// </summary>
		/// <remarks>
		/// Public Required for Editing Views redirecting to newly created items
		/// </remarks>
		/// <param name="objSelectedItem"></param>
		/// <returns></returns>
		public SEOItem Redirect(SEOItem objSelectedItem)
		{
			SEOItem objToItem = GetTargetOfRedirect(objSelectedItem);

			if (objToItem != null)
			{
				// Set the current item id
				mintCurrentItemID = objToItem.ID;
				// Get the current category id
				mintCurrentCategoryID = GetCategoryID(objToItem);
			}

			return objToItem;
		}

		/// <summary>
		/// Gets the target SEOItem of redirect for given item.
		/// </summary>
		/// <param name="objSelectedItem">the item </param>
		/// <returns>objSelectedItem returned if redirect not defined</returns>
		public SEOItem GetTargetOfRedirect(SEOItem objSelectedItem)
		{
			SEOItem objToItem = objSelectedItem;

			if (objToItem != null)
			{
				if (objSelectedItem.Type == SEOItemType.Folder)
				{
					SEOFolder objFolder = (SEOFolder)objSelectedItem;
					if (!objFolder.HasLobby && objFolder.DefaultPage != null)
					{
						objToItem = objFolder.DefaultPage;
					}
				}
			}
			return objToItem;
		}

         /// <summary>
        /// Gets the category ID
        /// </summary>
        /// <returns>0 if not found</returns>
        private int GetCategoryID(SEOItem objSelectedItem)
        {
            // get the category
            SEOItem objCategory = objSelectedItem.GetCategory();
            return objCategory == null ? 0 : objCategory.ID;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // If is a create new item
            if (mblnIsAdmin && objEvent.Type == "Create")
            {
                LoadNewItem();
            }
            else
            {
                // If there is a member 
                if (!string.IsNullOrEmpty(objEvent.Member))
                {
                    // The member seo node id
                    int intSEONodeID = 0;

                    // If is a node event
                    if (objEvent.Member.StartsWith("N"))
                    {
                        // Get the SEO node id
                        intSEONodeID = int.Parse(objEvent.Member.Trim('N'));

                        // Get the SEO item
                        SEOItem objSEOItem = SEOSite.GetItemByID(intSEONodeID);
                        if (objSEOItem != null)
                        {
                            // If is admin and allow edit mode
                            if (mblnIsAdmin && objEvent.Type == "Edit")
                            {
                                // Load page item for editing
                                LoadPageItem(objSEOItem, true);
                            }
                            else if (objEvent.Type == "Collapsed" || objEvent.Type == "Expanded")
                            {
                                NavigationViewItemState objState= GetItemState(objSEOItem);
                                if (objState!=null)
                                {
                                    objState.IsExpanded = objEvent.Type == "Expanded";
                                    // don't touch UpdatedOn because not critical, client already updated
                                }
                            }
                            else
                            {
								objSEOItem = Redirect(objSEOItem);
								EnsureVisible(objSEOItem);
                                LoadItem(objSEOItem, false);
                            }
                        }
                    }
					// If is a category related event
					else if (objEvent.Member.StartsWith("C"))
                    {
                        bool bln = false;

                        // Get the SEO node id
                        bln = int.TryParse(objEvent.Member.Trim('C'), out intSEONodeID);

                        if (bln)
                        {
                            // Get the SEO item
                            SEOFolder objSEOItem = SEOSite.GetItemByID(intSEONodeID) as SEOFolder;
                            if (objSEOItem != null)
                            {
                                // If is admin and allow edit mode
                                if (mblnIsAdmin && objEvent.Type == "Edit")
                                {
                                    // Load page item for editing
                                    LoadPageItem(objSEOItem, true);
                                }
                                else
                                {
                                    // Load category items
                                    LoadCategoryItem(objSEOItem);
                                }
                            }
                        }
                    }
                }
                base.FireEvent(objEvent);

                // Search items
                if (objEvent.Type == "Search")
                {
                    SearchItems(objEvent["Wildcard"]);
                }
                else if (objEvent.Type == "Navigate")
                {
                    NavigateItem(objEvent["ItemID"]);
                }
                else if (objEvent.Type == "Validate")
                {
                    ValidateItems();
                }
                else if (objEvent.Type == "Browse")
                {
					// The client action related to showing the content of a resource file
                    BrowseItem(objEvent["Action"], objEvent["RelPath"], objEvent["Title"]);
                }
                else if (objEvent.Type == "Mode")
                {
					mblnIsPreview = !mblnIsPreview;
					long lngUpdate = DateTime.Now.Ticks;
					mintContainerUpdate = lngUpdate;

					SEOItem objSEOItem = SEOSite.GetItemByID(mintCurrentItemID);
					LoadItem(objSEOItem, false);
                }
				else if (objEvent.Type == "Links")
				{
					// Client action - press to get links to browse and download resources of current item
					SEOItem objItem = SEOSite.GetItemByID(mintCurrentItemID);
					if (objItem != null)
					{
						ItemLinks objForm = new ItemLinks(objItem);
						objForm.ShowDialog();
					}
				}
				else if (objEvent.Type == "OpenHP") //Open home page - root redirect
				{
					// Redirects to root default item
					SEOItem objPrevItem = SEOSite.GetItemByID(mintCurrentItemID);
					SEOItem objSEOItem = GetTargetOfRedirect(SEOSite.Root);
					if (objSEOItem != null)
					{
						mintContainerUpdate = DateTime.Now.Ticks;

						// ensure that highlighting dropped from previously selected item/and it's category
						if (objPrevItem != null)
						{
							GetItemState(objPrevItem).UpdatedOn = DateTime.Now.Ticks;
							SEOItem objPrevItemCat = objPrevItem.GetCategory();
							if (objPrevItemCat != null)
								GetItemState(objPrevItemCat).UpdatedOn = DateTime.Now.Ticks;
						}

						// Do nothing if same item - incorrect, because
						// if we were in search state, the prev. item will be the same
						// and we can't refresh the view, so: if (objPrevItem != objSEOItem){} incorrect.

						// load the target of redirection
						LoadItem(objSEOItem, false);

						// ensure the node is shown in tree
						EnsureVisible(objSEOItem);

						// call to client to reorder tree to show items properly
						string strParameters = string.Format("{0}_{1}", this.ID, GetItemID(objSEOItem, objSEOItem.IsCategory()));
						this.InvokeMethod("NavigationView_RaiseSubCategory", strParameters);
					}
				}
				else if (objEvent.Type == "ThemeSet")
				{
					// We've asked to change VWG theme
					string strTargetTheme = objEvent["Name"];
					string strCurrent = VWGContext.Current.CurrentTheme;
					if (strTargetTheme != strCurrent)
					{
						this.Context.CurrentTheme = strTargetTheme;
					}
				}
				else if (objEvent.Type == "EditLE")
				{
					// We've asked to edit Lobby elements

					// get currently designed lobby element
					SEOLobby item = SEOSite.GetItemByID(mintCurrentItemID) as SEOLobby;

					if (item != null)
					{
						string strSectionID = string.Empty;
						int intIndex = 0;

						// check where the clicked item is a PageElement
						if (objEvent["Type"] == "Element" && item.Elements.Count > 0)
						{
							strSectionID = objEvent["SectionID"];
							intIndex = 0;
							if (int.TryParse(objEvent["Index"], out intIndex))
							{
								// get elements associated with the section
								List<SEOPageElement> Elements = item.GetSectionElements(strSectionID);
								if (intIndex >= 0 && intIndex < Elements.Count)
								{
									SEOPageElement objElement = Elements[intIndex];

									// edit page element
									ElementEditForm objEditElementForm = new ElementEditForm(item, objElement, item.Sections);

									// handle close form
									objEditElementForm.FormClosed += delegate(object formsender, FormClosedEventArgs closeevent)
									{
										// save element if confirmed
										if (objEditElementForm.DialogResult == DialogResult.OK)
										{
											// if during editing new element was added, add and save it
											if (objEditElementForm.NewElement)
											{
												item.Elements.Add(objEditElementForm.EditedElement);
											}
											else if (objEditElementForm.DeleteElement)
											{
												item.Elements.Remove(objEditElementForm.EditedElement);
											}

											// save element if confirmed
											item.Save();

											// cause re-render item to client after save
											mintContainerUpdate = DateTime.Now.Ticks;
										}
									};

									objEditElementForm.ShowDialog();
								}
							}
						}
						// check where the clicked item is a Section
						else if (objEvent["Type"] == "Section" && item.Sections.Count > 0)
						{
							strSectionID = objEvent["SectionID"];

							LobbySections objEditForm = new LobbySections();

							objEditForm.EditedSections = item.Sections;
							objEditForm.SelectedSectionID = strSectionID;

							// deletion permitted only if no elements associated with the section
							objEditForm.ConfirmDelete += delegate(SEOLobby.Section objSection)
							{
								return item.GetSectionElements(objSection.ID).Count == 0;
							};

							// handle completion of section editing
							objEditForm.FormClosed += delegate(object form, FormClosedEventArgs closeevent)
							{
								// the user confirmed the changes
								if (((Form)form).DialogResult == DialogResult.OK)
								{
									// clear the collection
									item.Sections.Clear();
									// replaced with updated section objects
									foreach (SEOLobby.Section section in objEditForm.EditedSections)
										item.Sections.Add(section);
									// save element if confirmed
									item.Save();

									// cause re-render item to client after save
									mintContainerUpdate = DateTime.Now.Ticks;
								}
							};
							objEditForm.ShowDialog();
						}
					}

				}
				else if (objEvent.Type == "ReIndex")
				{
					// Recreate and optimize search index for all CompanionKit items.
					SEOSite.Search.UpdateIndex();
				}
			}
        }

        private void BrowseItem(string strAction, string strRelPath, string strTitle)
        {
			string strClientRelPath = strRelPath;
			strTitle = strTitle != null ? strTitle : "";

            // Open the download url
            LinkParameters objLinkParams = new LinkParameters();
            objLinkParams.Target = "_blank";
			objLinkParams.ShowLocationBar = true;
			objLinkParams.ShowMenuBar = true;

			// the link to an item is path including the web application folder path
			// when responed to the client, should be relative to current application folder
			// so the path should be stripped
			if (strRelPath.StartsWith(HostRuntime.AppDomainAppVirtualPath))
			{
				strRelPath = strRelPath.Substring(HostRuntime.AppDomainAppVirtualPath.Length);
			}
			
			CodeViewer viewer = new CodeViewer();
			viewer.Text = strTitle;
			viewer.WindowState = FormWindowState.Maximized;

            switch (strAction.ToLower())
            {
                case "open":
					viewer.Url = strClientRelPath.Split('?')[0] + "?action=viewWOLN";
					viewer.Show();
                    break;
                case "openln":
                case "browse":
					viewer.Url = strClientRelPath;
					viewer.Show();
                    break;
                case "download":
                    // to avoid blank popup window
                    objLinkParams.Target = "_self";
                    Link.Open(strRelPath + "?action=download", objLinkParams);
                    break;

                case "zipvb":
                case "zipcs":
                    // to avoid blank popup window
                    objLinkParams.Target = "_self";
                    SEOItem objSEOPageItem = SEOSite.GetItemByID(mintCurrentItemID);
                    if (objSEOPageItem != null)
                    {
                        Link.Open(objSEOPageItem.GetZipLink(strAction), objLinkParams);
                    }
                    break;

                default:
                    break;
            }
        }

        private void NavigateItem(string strItemID)
        {
            SEOItem objSEOItem = SEOSite.GetItem(strItemID);
            if (objSEOItem != null)
            {
                LoadPageItem(objSEOItem, false);
                ClientTreeUpdate(objSEOItem);
            }
        }

        /// <summary>
        /// Synchronize the clicked Item and position in the tree on the client side
        /// </summary>
        private void ClientTreeUpdate(SEOItem objSEOItem)
        {
            if (objSEOItem != null)
            {
                EnsureVisible(objSEOItem);
                string strParameters = 
                    string.Format("{0}_{1}", this.ID, GetItemID(objSEOItem, objSEOItem.IsCategory()));
                // Invoke client side to highlight the found page/category/sub-category
                this.InvokeMethod("NavigationView_Click", strParameters); 
            }
        }

		/// <summary>
		/// Invoke client side call to _trackPageview and
		/// call to update share toolbox.
		/// </summary>
		private void TrackPageView()
		{
			if (!mblnIsAdmin)
			{
				this.InvokeMethod("GA_TrackPageview"); 
			}
			this.InvokeMethod("RenderSharingToolbox");
		}

        /// <summary>
        /// Searches items in the tree
        /// </summary>
        /// <param name="strWildcard"></param>
        private void SearchItems(string strWildcard)
        {
            SearchItems(strWildcard, false);
        }

        /// <summary>
        /// Searches items in the tree
        /// </summary>
        /// <param name="strWildcard"></param>
        private void SearchItems(string strWildcard, bool blnIsBookmarkNavigation)
        {
            if (!blnIsBookmarkNavigation)
            {
                SetNavigationBookmark(strWildcard);
            }

            // Set the form title
            SetFormTitle(string.Format("Search: {0}", strWildcard));

            // Set the search state
            mstrSearchWildcard = strWildcard;
            menmNavigationViewState = NavigationViewState.Search;
            mintContainerUpdate = DateTime.Now.Ticks;
            mstrContainerTitle = string.Format("Search: {0}", strWildcard);
        }

        private void ValidateItems()
        {
            menmNavigationViewState = NavigationViewState.Validation;
            mintContainerUpdate = DateTime.Now.Ticks;
            mstrContainerTitle = "Search: Items that have not passed the validation.";
        }

        /// <summary>
        /// Loads the new item.
        /// </summary>
        private void LoadNewItem()
        {
            // Clear the container control
            this.ClearControlContainer();

            // Load the page item
            Control objControl = new CreateView(mintCurrentItemID);

            // Set the docking of the controls to top
            objControl.Dock = DockStyle.Top;

            // Add controls to container
            mobjContainer.Controls.Add(objControl);

            // Set container as not loby
            menmNavigationViewState = NavigationViewState.Edit;

            // Show the new control
            mintContainerUpdate = DateTime.Now.Ticks;
            mstrContainerTitle = "Create New";
        }

        /// <summary>
        /// Reloads the page item
        /// </summary>
		/// <remarks>
		/// After been changed and saved or editing was cancelled.
		/// </remarks>
        internal void ReloadPageItem()
        {
            SEOItem objSEOItem =  SEOSite.GetItemByID(mintCurrentItemID);
            if (objSEOItem != null)
            {
                NavigationViewItemState objSEOItemState = GetItemState(objSEOItem);
                if (objSEOItemState != null)
                {
                    objSEOItemState.UpdatedOn = DateTime.Now.Ticks;
                }

                SEOFolder objSEOParentItem = objSEOItem.Parent;
                if (objSEOParentItem != null)
                {
                    UpdateExpanded(objSEOParentItem);
                }
            }
			objSEOItem = Redirect(objSEOItem);
            LoadPageItem(objSEOItem, false);
        }

		/// <summary>
		/// Reloads the after delete.
		/// </summary>
		/// <param name="objSEOParentItem">The parent of deleted item.</param>
        internal void ReloadAfterDelete(SEOFolder objSEOParentItem)
        {
			mintContainerUpdate = DateTime.Now.Ticks;

            this.ClearControlContainer();

			Control objControl = new ErrorView("Item was deleted.");
			objControl.Dock = DockStyle.Top;
			mobjContainer.Controls.Add(objControl);

			// render all items of deleted Item's parent to ensure
			// correct view on the client
			UpdateExpanded(objSEOParentItem);
		}
		
		internal void EditArticleContent()
		{
            SEOItem objSEOItem =  SEOSite.GetItemByID(mintCurrentItemID);
			if (objSEOItem != null)
			{
				mstrContainerTitle = objSEOItem.Title;
			}
            menmNavigationViewState = NavigationViewState.ArticleContentEdit;
            mintContainerUpdate = DateTime.Now.Ticks;
		}
        
		/// <summary>
        /// Updates the expanded folders.
        /// </summary>
        /// <param name="objSEOFoder">The SEO foder.</param>
        private void UpdateExpanded(SEOFolder objSEOFoder)
        {            
            NavigationViewItemState objSEOFoderState = GetItemState(objSEOFoder);
            if (objSEOFoderState != null)
            {
                objSEOFoderState.UpdatedOn = DateTime.Now.Ticks;

                if (objSEOFoderState.IsExpanded)
                {
                    foreach (SEOFolder objSEOSubFolder in objSEOFoder.Folders)
                    {
                        UpdateExpanded(objSEOSubFolder);
                    }

                    foreach (SEOItem objSEOSubPage in objSEOFoder.PlainItems)
                    {
                        NavigationViewItemState objSEOPageState = GetItemState(objSEOSubPage);
                        if (objSEOPageState != null)
                        {
                            objSEOPageState.UpdatedOn = DateTime.Now.Ticks;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Ensures that given node will be shown in the tree node
        /// </summary>
        /// <remarks>
        /// To accomplish that, we need to go towards root node and expand
        /// each parent of given node. In addition  we need to "touch" all 
        /// folders and pages of parent to guarantee that these nodes will
        /// be rendered to client, to show correctly the structure of nodes.
        /// </remarks>
        private void EnsureVisible(SEOItem objItem)
        {
            NavigationViewItemState objSEOState = GetItemState(objItem);
            objSEOState.UpdatedOn = DateTime.Now.Ticks;
            
            // visit each parent from immediate one to root
            for (SEOFolder objParent = objItem.Parent; objParent != null; objParent = objParent.Parent)
            {
                objSEOState = GetItemState(objParent);
                if (objSEOState != null && !objSEOState.IsExpanded)
                {
                    objSEOState.IsExpanded = true;
                    objSEOState.UpdatedOn = DateTime.Now.Ticks;

                    foreach (SEOItem objSEOSubFolder in objParent.Items)
                    {
                        objSEOState = GetItemState(objSEOSubFolder);
                        objSEOState.UpdatedOn = DateTime.Now.Ticks;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the page item. In non bookmark navigation mode.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        /// <param name="blnEditMode">if set to <c>true</c> than in edit mode.</param>
        private void LoadPageItem(SEOItem objSEOItem, bool blnEditMode)
        {
            LoadPageItem(objSEOItem, blnEditMode, false);
        }

        /// <summary>
        /// Loads the page item.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        /// <param name="blnEditMode">if set to <c>true</c> than in edit mode.</param>
        private void LoadPageItem(SEOItem objSEOItem, bool blnEditMode, bool blnIsBookmarkNavigation)
        {
            if (!blnIsBookmarkNavigation)
            {
                SetNavigationBookmark(objSEOItem, blnEditMode);
            }

			// Check if updated since last time loaded
			objSEOItem.LoadUpdates();

            // Set the form title
            SetFormTitle(objSEOItem.Title);

            // Check that category correlates to the item, change it if not
            // relevant when we clicking the item found through the search
            SEOItem objCategory = objSEOItem.GetCategory();
            if ( objCategory != null && mintCurrentCategoryID != objCategory.ID)
	        {
                LoadCategoryItem(objCategory as SEOFolder);
	        }
            
			// Clear the container control, because category loads item too
            ClearControlContainer();

            // Set the current item id, should be after setting the category
            mintCurrentItemID = objSEOItem.ID;

            // If there is a valid control
            // Load the page item
            Control objControl = LoadPageItemControl(objSEOItem, blnEditMode);
            if (objControl != null)
            {
                // Set the docking of the controls to top
                objControl.Dock = DockStyle.Top;

                // If control is an edit view
                if (objControl is EditView)
                {
                    // Set container as edit view
                    menmNavigationViewState = NavigationViewState.Edit;

                    // Add controls to container
                    mobjContainer.Controls.Add(objControl);
                }
                else
                {
                    // Set container as page
                    menmNavigationViewState = NavigationViewState.Page;

                    // Try to get the seo page
                    SEOPage objSEOPage = objSEOItem as SEOPage;
                    if (objSEOPage != null && objSEOPage.Inspector != null)
                    {
						// override the height of user control if defined explicitly
						if (objSEOPage.UserControlHeight >0)
						{
							objControl.Height = objSEOPage.UserControlHeight;
						}

                        if (objSEOPage.Inspector.Docking == SEOPageInspectorDocking.Right)
                        {
                            // Add controls to container
                            mobjContainer.Controls.Add(objControl);
                        }

                        // If there is an inspector and the inspector is visible
                        if (objSEOPage.Inspector.IsVisible)
                        {
                            InspectorView objInspectorView = new InspectorView();
                            if (objSEOPage.Inspector.Docking == SEOPageInspectorDocking.Bottom)
                            {
                                objInspectorView.Dock = DockStyle.Top;
                            }
                            else
                            {
                                objInspectorView.Dock = DockStyle.Right;
                            }
                            objInspectorView.Initialize(objSEOPage.Inspector, objControl);
                            mobjContainer.Controls.Add(objInspectorView);
                        }

                        if (objSEOPage.Inspector.Docking == SEOPageInspectorDocking.Bottom)
                        {
                            // Add controls to container
                            mobjContainer.Controls.Add(objControl);
                        }
                    }
                    else
                    {
                        // Add controls to container
                        mobjContainer.Controls.Add(objControl);
                    }
                }
            }
            else
            {
                // Set container as a non-Page item
                switch (objSEOItem.Type)
                {
                    case SEOItemType.Folder:
                    case SEOItemType.Lobby:
                        menmNavigationViewState = NavigationViewState.Lobby;
                        break;
                    case SEOItemType.Article:
                        menmNavigationViewState = NavigationViewState.Article;
                        break;
                }
            }

            mintContainerUpdate = DateTime.Now.Ticks;
            mstrContainerTitle = objSEOItem.Title;
        }

        /// <summary>
        /// Clears the control container.
        /// </summary>
        private void ClearControlContainer()
        {
            // Validate that container has controls.
            if (mobjContainer.Controls.Count > 0)
            {
                // Loop all contained controls.
                foreach (Control objControl in mobjContainer.Controls)
                {
                    // Try getting an SEO page from current control's tag.
                    SEOPage objSEOPage = objControl.Tag as SEOPage;
                    if (objSEOPage != null)
                    {
                        // Unregister page's script resources.
                        this.UnRegisterPageScriptResources(objSEOPage);
                    }
                }
                
                mobjContainer.Controls.Clear();
            }
        }

        /// <summary>
        /// Sets the current naviagtion bookmark
        /// </summary>
        /// <param name="objSEOItem"></param>
        /// <param name="blnEditMode"></param>
        private void SetNavigationBookmark(SEOItem objSEOItem, bool blnEditMode)
        {
            Application.SetThreadBookmark(string.Format("i:{0}:{1}", objSEOItem.ID, blnEditMode ? 1 : 0), objSEOItem.Title);
        }

        /// <summary>
        /// Sets the current naviagtion bookmark
        /// </summary>
        /// <param name="strWildcard"></param>
        private void SetNavigationBookmark(string strWildcard)
        {
            Application.SetThreadBookmark(string.Format("s:{0}", strWildcard), string.Format(" Search: {0}",strWildcard));
        }

        /// <summary>
        ///  Sets the container form title
        /// </summary>
        /// <param name="strTitle"></param>
        private void SetFormTitle(string strTitle)
        {
            // Get the containing form
            Form objForm = this.Form;

            // If found form
            if (objForm != null)
            {
                // Set the forms title to the title
                objForm.Text = strTitle;
            }
        }

        /// <summary>
        /// Handles thread bookmark navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnThreadBookmarkNavigate(object sender, ThreadBookmarkEventArgs e)
        {
            string strData = e.Data as string;
            if (!string.IsNullOrEmpty(strData))
            {
                string[] arrData = strData.Split(':');
                if (arrData[0] == "i")
                {
                    int intItemID = int.Parse(arrData[1]);
                    bool blnEditMode = arrData[2] == "1";

                    SEOItem objSEOItem = SEOSite.GetItemByID(intItemID);
                    if (objSEOItem != null)
                    {
                        LoadPageItem(objSEOItem, blnEditMode, true);
                    }
                }
                if (arrData[0] == "s")
                {
                    SearchItems(arrData[1], true);
                }
            }
        }

       /// <summary>
        /// Loads the category item
        /// </summary>
        /// <param name="objSEOItem"></param>
        private void LoadCategoryItem(SEOFolder objSEOFolder)
        {
			SEOItem objToItem = Redirect(objSEOFolder);
			objSEOFolder = objToItem.GetCategory() as SEOFolder;

            // Update the nodes contaienr
            mintNodesUpdate = DateTime.Now.Ticks;

            ResetFolderState(objSEOFolder, true);

            // Load and expand the Item
			EnsureVisible(objToItem);
            LoadFolderItem(objToItem);
			LoadPageItem(objToItem, false);
        }

        /// <summary>
        /// Resets the state of the folder.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        /// <param name="blnRoot">if set to <c>true</c> item is root root.</param>
        private void ResetFolderState(SEOFolder objSEOItem, bool blnRoot)
        {
            foreach (SEOFolder objSEOSubFolder in objSEOItem.Folders)
            {
                NavigationViewItemState objSubFolderState = GetItemState(objSEOSubFolder);
                if (objSubFolderState != null)
                {
                    objSubFolderState.IsExpanded = false;

                    if (blnRoot)
                    {
                        objSubFolderState.UpdatedOn = DateTime.Now.Ticks;
                    }
                }
                ResetFolderState(objSEOSubFolder, false);
            }

            if (blnRoot)
            {
                foreach (SEOItem objSEOPage in objSEOItem.PlainItems)
                {
                    NavigationViewItemState objPageState = GetItemState(objSEOPage);
                    if (objPageState != null)
                    {
                        objPageState.UpdatedOn = DateTime.Now.Ticks;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the page item
        /// </summary>
        /// <param name="objSEOPage"></param>
        private Control LoadPageItemControl(SEOItem objSEOItem, bool blnEditMode)
        {
            try
            {
                // If in edit mode
                if (blnEditMode)
                {
                    Control objEditView = null;
                    switch (objSEOItem.Type)
                    {
                        case SEOItemType.Folder:
                            objEditView = new FolderEditView(objSEOItem as SEOFolder);
                            break;
                        case SEOItemType.Page:
                            objEditView = new PageEditView(objSEOItem as SEOPage);
                            break;
                        case SEOItemType.Lobby:
                            objEditView = new LobbyEditView(objSEOItem as SEOLobby);
                            break;
                        case SEOItemType.Article:
                            objEditView = new ArticleEditView(objSEOItem as SEOArticle);
                            break;
                        default:
							objEditView = new ErrorView("Unsupported SEO Item type.");
                            break;
                    }
                    return objEditView;
                }
                else
                {
                    // Demonstration mode
                    // If is page
                    SEOPage objSEOViewPage = objSEOItem as SEOPage;
                    if (objSEOViewPage != null)
                    {
                        // If is page
                        if (objSEOViewPage.Type == SEOItemType.Page)
                        {
                            // Get page type
                            Type objType = Type.GetType(objSEOViewPage.PageType, false);
                            if (objType != null)
                            {
                                // Creat the page type
                                Control objControl = Activator.CreateInstance(objType) as Control;
                                if (objControl != null)
                                {
                                    // Registers the page script resources.
                                    this.RegisterPageScriptResources(objSEOViewPage);

                                    objControl.Tag = objSEOViewPage;
                                }

                                return objControl;
                            }
                            else
                            {
                                //if page have type ChatPage or DynamicDataPage
                                if (objSEOViewPage.PageType == "CompanionKit.Concepts.WebSockets.Chat.ChatPage, Gizmox.WebGUI.Forms.CompanionKit"
                                    || objSEOViewPage.PageType == "CompanionKit.Concepts.WebSockets.DynamicData.DynamicDataPage, Gizmox.WebGUI.Forms.CompanionKit")
                                {
                                    return new ErrorView("WebSockets samples are not supported in this .NET Framework version.");
                                }
								//if page have type as one of C1 Pages
                                else if (objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1BarChart.C1BarChartPage, Gizmox.WebGUI.Forms.CompanionKit"
                                    || objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1LineChart.C1LineChartPage, Gizmox.WebGUI.Forms.CompanionKit"
									|| objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1ReportViewer.C1ReportViewerPage, Gizmox.WebGUI.Forms.CompanionKit"
									|| objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1EventsCalendar.C1EventsCalendarPage, Gizmox.WebGUI.Forms.CompanionKit"
									|| objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1TreeView.C1TreeViewPage, Gizmox.WebGUI.Forms.CompanionKit"
									|| objSEOViewPage.PageType == "CompanionKit.Concepts.AspNetWrappers.C1GridView.C1GridViewPage, Gizmox.WebGUI.Forms.CompanionKit")
                                {
                                    return new ErrorView("ComponentOne samples are not supported in this .NET Framework version.");
                                }
                                return new ErrorView("Page type is either invalid or type was not compiled yet.");
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception objException)
            {
                return new ErrorView(objException.ToString());
            }
        }

        /// <summary>
        /// Registers the page script resources.
        /// </summary>
        /// <param name="objSEOPage">The obj SEO view page.</param>
        private void RegisterPageScriptResources(SEOPage objSEOPage)
        {
            // Validate recieved page.
            if (objSEOPage != null)
            {
                // Validate current client context.
                if (VWGClientContext.Current != null)
                {
                    // Loop all page resources.
                    foreach (SEOItemResource objSEOItemResource in objSEOPage.Resources)
                    {
                        // Check if current resource is a page script.
                        if (objSEOItemResource.PageScript)
                        {
                            VWGClientContext.Current.Invoke("registerScript", objSEOItemResource.Name, objSEOItemResource.ViewURL);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Uns the register page script resources.
        /// </summary>
        /// <param name="objSEOPage">The obj SEO view page.</param>
        private void UnRegisterPageScriptResources(SEOPage objSEOPage)
        {
            // Validate recieved page.
            if (objSEOPage != null)
            {
                // Validate current client context.
                if (VWGClientContext.Current != null)
                {
                    // Loop all page resources.
                    foreach (SEOItemResource objSEOItemResource in objSEOPage.Resources)
                    {
                        // Check if current resource is a page script.
                        if (objSEOItemResource.PageScript)
                        {
                            VWGClientContext.Current.Invoke("unRegisterScript", objSEOItemResource.Name);
                        }
                    }
                }
            }
        }

        private void LoadItem(SEOItem objSEOItem, bool blnEditMode)
        {
            // If is folder
            if (objSEOItem is SEOFolder)
            {
                // Load folder And/Or collapse it
                LoadFolderItem(objSEOItem);
				LoadPageItem(objSEOItem, blnEditMode, true);
            }
            else
            {
                LoadPageItem(objSEOItem, blnEditMode, true);
            }
        }

        /// <summary>
        /// Loads the folder item
        /// </summary>
        /// <param name="objSEOItem">The obj SEO item.</param>
        /// <param name="blnCollapse">if set to <c>true</c> then show the item and collapse the node.</param>
        private void LoadFolderItem(SEOItem objSEOItem)
        {
            SEOFolder objSEOFolder = objSEOItem as SEOFolder;
            if (objSEOFolder != null)
            {
				// Check if updated since last time loaded
				objSEOItem.LoadUpdates();

                NavigationViewItemState objState = GetItemState(objSEOFolder);
                if (objState != null)
                {
                    // Get the current tick time
                    long lngUpdatedOn = DateTime.Now.Ticks;

                    if (!objState.IsExpanded)
                    {
                        objState.IsExpanded = true;
                        objState.UpdatedOn = lngUpdatedOn;
                        foreach (SEOItem objItem in objSEOFolder.Items)
                        {
                            NavigationViewItemState objSubPageState = GetItemState(objItem);
                            if (objSubPageState != null)
                            {
                                objSubPageState.UpdatedOn = lngUpdatedOn;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {            
            // Render categories
            RenderCategories(objContext, objWriter, lngRequestID);

            // Render nodes
            RenderNodes(objContext, objWriter, lngRequestID);

            // Render the content container
            RenderContainer(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Renders the content container
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        private void RenderContainer(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // If the control is dirty
            if (IsDirty(lngRequestID) || mintContainerUpdate > lngRequestID)
            {
                // Try to get the current item
                SEOItem objSEOItem = SEOSite.GetItemByID(mintCurrentItemID);
                
                // Write the node view node
                objWriter.WriteStartElement("GZMVIEW");
                objWriter.WriteAttributeString(WGAttributes.OwnerID, this.ID.ToString());
                objWriter.WriteAttributeString(WGAttributes.MemberID, "CTL");
                objWriter.WriteAttributeString(WGAttributes.Text, mstrContainerTitle);

				// Add an attribute with Link to the page, for better tracking with GA
				// For example: _ZipClick(...)
				if (objSEOItem != null)
				{
					objWriter.WriteAttributeString("Link", objSEOItem.HrefLink);
					objWriter.WriteAttributeString(WGAttributes.Title, objSEOItem.Title);
					objWriter.WriteAttributeString("Desc", objSEOItem.Description);
				}

                switch (menmNavigationViewState)
                {
                    case NavigationViewState.Lobby:
                        objWriter.WriteAttributeString(WGAttributes.Type, "L");
                        break;
                    case NavigationViewState.Page:
                        objWriter.WriteAttributeString(WGAttributes.Type, "P");
                        break;
                    case NavigationViewState.Edit:
                        objWriter.WriteAttributeString(WGAttributes.Type, "E");
                        break;
                    case NavigationViewState.Search:
                    case NavigationViewState.Validation:
                        objWriter.WriteAttributeString(WGAttributes.Type, "S");
                        break;
                    case NavigationViewState.Article:
                    case NavigationViewState.ArticleContentEdit:
                        objWriter.WriteAttributeString(WGAttributes.Type, "A");
                        break;
                    default:
                        throw new NotImplementedException(
							"Not supported view state, check RenderContainer(): " + menmNavigationViewState.ToString());
                }

                if (mblnIsAdmin)
                {
                    objWriter.WriteAttributeString(WGAttributes.LabelEdit, "1");
                }

				// Render flag of preview mode
                if (mblnIsPreview)
                {
                    objWriter.WriteAttributeString(WGAttributes.View, "1");
                }

                // If there are no controls in the container
                if (mobjContainer.Controls.Count == 0)
                {                    
                    objWriter.WriteAttributeString(WGAttributes.Height, "0");
                }
                else
                {
                    objWriter.WriteAttributeString(WGAttributes.Height, mobjContainer.GetPreferredSize(Size.Empty).Height.ToString());
                }

                // If is page view
                if ( menmNavigationViewState == NavigationViewState.Page || 
                     menmNavigationViewState == NavigationViewState.Edit )
                {
					// Print the page content tag and render the contained controls
                    objWriter.WriteStartElement("GZPAGE");
					
                    base.RenderControls(objContext, objWriter, lngRequestID);
                    
					objWriter.WriteEndElement();
                    
                    if (objSEOItem != null)
                    {
						// Wrap page resources with an element
						objWriter.WriteStartElement("GZRES");
                        
						// Loop all page resources
                        foreach (SEOItemResource objSEOItemResource in objSEOItem.Resources)
                        {
                            // If is a visible resource
                            if (objSEOItemResource.Visible)
                            {
								objWriter.WriteStartElement("GZPAGERES");                                
                                objWriter.WriteAttributeString(WGAttributes.Name, objSEOItemResource.Name);
                                objWriter.WriteAttributeString(WGAttributes.Source, objSEOItemResource.FormattedViewURL);
                                
								// The Title if not empty else Name
								objWriter.WriteAttributeString(WGAttributes.Title, 
									objSEOItemResource.ResourceInfo.Title.Length >0 ? objSEOItemResource.ResourceInfo.Title : objSEOItemResource.Name);
								
								// The resource type
								objWriter.WriteAttributeString(WGAttributes.Type, objSEOItemResource.ResourceInfo.Type.ToString());

								// Programming Language
								objWriter.WriteAttributeString("L", objSEOItemResource.ResourceInfo.Language.ToString());

								objWriter.WriteEndElement();
                            }
                        }
						
						objWriter.WriteEndElement();
                    
						// track item visit
						TrackPageView();
					}
                }
                // If is search view
                else if (menmNavigationViewState == NavigationViewState.Search)
                {
                    // Get all search items
                    SEOSearchItems objFoundItems = SEOSite.Search.SearchItems(mstrSearchWildcard, 200);

                    // Render search results items
                    RenderSearchResults(objContext, objWriter, lngRequestID, objFoundItems);
                }
                else if (menmNavigationViewState == NavigationViewState.Lobby)
                {
					// Try to get the current item
                    SEOLobby objSEOLobbyItem = objSEOItem as SEOLobby;
                    if (objSEOLobbyItem != null)
                    {
						RenderLobby(objContext, objWriter, lngRequestID, objSEOLobbyItem);
					}

					// track item visit
					TrackPageView();
                }
                // If links check state
                else if (menmNavigationViewState == NavigationViewState.Validation)
                {
                    // Get all problematic items
                    SEOSearchItems objItems = new SEOSearchItems();
                    SEOSite.Root.Validate(objItems, 200);

                    // Render search results items
                    RenderSearchResults(objContext, objWriter, lngRequestID, objItems);
                }
                objWriter.WriteEndElement();
            }
            else
            {
                // If is not a lobby container
                if ( menmNavigationViewState == NavigationViewState.Page || 
                     menmNavigationViewState == NavigationViewState.Edit )
                {
                    base.RenderControls(objContext, objWriter, lngRequestID);
                }
            }
        }


        /// <summary>
        /// Renders the page elements of a Lobby
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="objSEOPage"></param>
        private void RenderLobby(IContext objContext, IResponseWriter objWriter, long lngRequestID, SEOLobby objItem)
        {
			List<SEOPageElement>	objElements = objItem.Elements;
			List<SEOLobby.Section>	objSections = objItem.Sections;
			Dictionary<string, List<SEOPageElement>> objElementsByType = new Dictionary<string,List<SEOPageElement>>();

			// separate according to element's section
			foreach (SEOPageElement objElement in objElements)
			{
				if (!String.IsNullOrEmpty(objElement.SectionID))
				{
					// Add an items container for this type if is not
					if (!objElementsByType.ContainsKey(objElement.SectionID))
					{
						objElementsByType[objElement.SectionID] = new List<SEOPageElement>();
					}
					// Add to the list of elements
					objElementsByType[objElement.SectionID].Add(objElement);
				}
			}

			if (objElements.Count > 0)
			{
				// Write down settings and texts
				objWriter.WriteStartElement("GZSECTIONS");

				foreach (SEOLobby.Section objSection in objSections)
				{
					if (objElementsByType.ContainsKey(objSection.ID))
					{
						objWriter.WriteStartElement("Section");
						objWriter.WriteAttributeString(WGAttributes.Id, objSection.ID);
						objWriter.WriteAttributeString("name", objSection.StyleName);
						objWriter.WriteAttributeString("cols", objSection.Columns.ToString());
						objWriter.WriteAttributeString("pre", ToMultiline(objSection.PreText));
						objWriter.WriteAttributeString("tlt", ToMultiline(objSection.Title));
						
						// Write down settings styles
						objWriter.WriteStartElement("Style");
						objWriter.WriteAttributeString("tlcss", objSection.Style.TitleCSS);
						objWriter.WriteAttributeString("concss", objSection.Style.ContainerCSS);
						objWriter.WriteAttributeString("precss", objSection.Style.PreTextCSS);
						objWriter.WriteEndElement();

						// pack the elements for each type in rows accodring to number of columns
						int intCols = objSection.Columns;
						
						// Column counter in the row
						int intCur = 0;
						
						// Indicates where the row tag was closed
						bool closed = false;

						// Order elements of the section in rows
						// with predefined number of columns - 'intCols'
						foreach (SEOPageElement objElement in objElementsByType[objSection.ID])
						{
							if (intCur % intCols == 0)
							{
								objWriter.WriteStartElement("R"); // start a new row
								closed = false;
							}

							objWriter.WriteStartElement("GZPAGEELE");
							objWriter.WriteAttributeString(WGAttributes.Index, intCur.ToString());
							objWriter.WriteAttributeString(WGAttributes.Title, ToMultiline(objElement.Title));
							objWriter.WriteAttributeString(WGAttributes.Text, ToMultiline(objElement.Body));
							objWriter.WriteAttributeString(WGAttributes.Type, objElement.SectionID);
							objWriter.WriteAttributeString(WGAttributes.Code, objElement.Link);

							if (!String.IsNullOrEmpty(objElement.Image))
							{
								SEOItemResource objImage = objItem.GetResource(objElement.Image);
								if (objImage != null)
									objWriter.WriteAttributeString(WGAttributes.Image, objImage.ViewURL);
							}

							objWriter.WriteStartElement("Style");
							objWriter.WriteAttributeString("concss", objElement.Styling.ContainerCSS);
							objWriter.WriteAttributeString("tlcss", objElement.Styling.TitleCSS);
							objWriter.WriteAttributeString("bodycss", objElement.Styling.BodyCSS);
							objWriter.WriteAttributeString("sepcss", objElement.Styling.SeparatorCSS);
							objWriter.WriteAttributeString("imgcss", objElement.Styling.ImageCSS);
							objWriter.WriteAttributeString(WGAttributes.Anchoring, objElement.Styling.LinkType.ToString());
							objWriter.WriteAttributeString(WGAttributes.WindowState, objElement.Styling.OpenLinkInNewWindow.ToString());
							objWriter.WriteEndElement(); //Style

							objWriter.WriteEndElement(); //GZPAGEELE

							if (intCur % intCols == (intCols-1))
							{
								objWriter.WriteEndElement(); // "R"
								closed = true;
							}
							intCur++;
						}
						
						if(!closed)
							objWriter.WriteEndElement(); // "R"

						objWriter.WriteEndElement(); // "Section"
					}
				}

				objWriter.WriteEndElement(); // GZSECTIONS
			}
        }

		private string ToMultiline(string strRawText)
		{
			return strRawText.Replace(Environment.NewLine, @"<BR/>");
		}

        /// <summary>
        /// Renders the search results
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        private void RenderSearchResults(IContext objContext, IResponseWriter objWriter, long lngRequestID, SEOSearchItems objFoundItems)
        {
            // Loop all found items
            foreach (SEOSearchItem objItem in objFoundItems)
            {
				SEOItem objFoundItem = objItem.Item;

                // avoid from to show items in draft status if not in admin mode
                if (mblnIsAdmin ||  objFoundItem.Status == SEOItemStatus.Publish)
                {
                    // Add the result item 
                    objWriter.WriteStartElement("GZITEM");
                    // Id for further navigation
                    objWriter.WriteAttributeString(WGAttributes.Code, objFoundItem.ID.ToString());
                    // Title to present the found item
                    objWriter.WriteAttributeString(WGAttributes.Text, objFoundItem.Title);               
                    // 'DP' - 'D'escri'p'tion for better understanding
                    objWriter.WriteAttributeString("DP", objFoundItem.Description);
					// Status of item for further tracking
					objWriter.WriteAttributeString("ST", objFoundItem.Status.ToString());
					// A messgae associated with the item
					objWriter.WriteAttributeString("MSG", objItem.Message);

                    // Add all parents to implement breadcrumbs - "p"-arent-"s"
                    List<SEOItem> objParents = objFoundItem.GetParents(true);
                    objWriter.WriteStartElement("PS");
                    foreach(SEOItem objParent in objParents)
                    {
                        objWriter.WriteStartElement("P");
                        objWriter.WriteAttributeString(WGAttributes.Code, objParent.ID.ToString());
                        objWriter.WriteAttributeString(WGAttributes.Text, objParent.DisplayName);
                        objWriter.WriteEndElement();
                    }
                    objWriter.WriteEndElement();

                    // Add the keywords of found item
                    objWriter.WriteStartElement("KWS");
                    foreach(string strKeyword in objFoundItem.Keywords)
                    {
                        objWriter.WriteStartElement("KW"); 
                        objWriter.WriteAttributeString(WGAttributes.Text, strKeyword);
                        objWriter.WriteEndElement();
                    }
                    objWriter.WriteEndElement(); //KWS


                    objWriter.WriteEndElement(); //GZITEM
                }
            }
        }

        /// <summary>
        /// Renders the control nodes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        private void RenderNodes(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            SEOFolder objSEOCategory = SEOSite.GetItemByID(mintCurrentCategoryID) as SEOFolder;

            if (objSEOCategory != null)
            {
                // If the control is dirty
                if (IsDirty(lngRequestID) || mintNodesUpdate > lngRequestID)
                {
                    // Write the node view node
                    objWriter.WriteStartElement("GZNVIEW");
                    objWriter.WriteAttributeString(WGAttributes.OwnerID, this.ID.ToString());
                    objWriter.WriteAttributeString(WGAttributes.MemberID, "N0");
                    objWriter.WriteAttributeString(WGAttributes.Text, mstrSearchWildcard);

                    // Loop all root folders
                    RenderTreeFolderItems(objContext, objWriter, lngRequestID, objSEOCategory, false);

                    objWriter.WriteEndElement();
                }
                else
                {
                    // Loop all root folders
                    RenderTreeFolderItems(objContext, objWriter, lngRequestID, objSEOCategory, false);
                }
            }
        }

        /// <summary>
        /// Renders the categories
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        private void RenderCategories(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // If the control is dirty
            if (IsDirty(lngRequestID) || mintCategoriesUpdate > lngRequestID)
            {
                // Write the category view node
                objWriter.WriteStartElement("GZCVIEW");
                objWriter.WriteAttributeString(WGAttributes.OwnerID, this.ID.ToString());
                objWriter.WriteAttributeString(WGAttributes.MemberID, "V0");

                // Loop all root folders
                RenderTreeFolderItems(objContext, objWriter, lngRequestID, SEOSite.Root, true);

                objWriter.WriteEndElement();
            }
            else
            {
                // Loop all root folders
                RenderTreeFolderItems(objContext, objWriter, lngRequestID, SEOSite.Root, true);
            }
        }

        /// <summary>
        /// Render tree folder
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="objSEOFolder"></param>
        private void RenderTreeFolder(IContext objContext, IResponseWriter objWriter, long lngRequestID, SEOFolder objSEOFolder, bool blnCategories)
        {
            // Get the item state
            NavigationViewItemState objState = GetItemState(objSEOFolder);

            if (objState != null)
            {
                // If the node was updated 
                if (objState.UpdatedOn > lngRequestID)
                {
                    if (blnCategories )
                    {
                        // TODO: Avoid change state during the rendering
                        // Collapse sub-categories, except current one, 
                        // to avoid showing multiple expanded sub-categories
                        Collapse(objSEOFolder, lngRequestID);
                    }

                    objWriter.WriteStartElement(blnCategories ? "GZCT" : "GZND");
                    objWriter.WriteAttributeString(WGAttributes.OwnerID, this.ID.ToString());
                    objWriter.WriteAttributeString(WGAttributes.MemberID, GetItemID(objSEOFolder, blnCategories));
                    objWriter.WriteAttributeString(WGAttributes.Title, objSEOFolder.DisplayName);
                    objWriter.WriteAttributeString(WGAttributes.HasNodes, objSEOFolder.ItemCount > 0 ? "1" : "0");
                    objWriter.WriteAttributeString(WGAttributes.Expanded, objState.IsExpanded ? "1" : "0");
                    objWriter.WriteAttributeString(WGAttributes.Events, "0");
                    objWriter.WriteAttributeString(WGAttributes.ToolTip, objSEOFolder.Description);
                    
                    if (objSEOFolder.ID == mintCurrentItemID || objSEOFolder.ID == mintCurrentCategoryID)
                    {   
                        objWriter.WriteAttributeString(WGAttributes.CurrentPage,"1");
                    }

                    // Ensure that 'c'urrent 's'ub-'c'ategory will be tagged with appropriate tag: "CSC"
                    if (!blnCategories )
                    {   
                        SEOItem objCurrent = SEOSite.GetItemByID(mintCurrentItemID);
                        if (objCurrent != null && objCurrent.GetSubCategory() == objSEOFolder)
                        {
                            objWriter.WriteAttributeString("CSC", "1");
                        }
                    }

                    // Ensure that 'C'urrent 'C'ategory will be tagged with appropriate tag: "CC"
                    if (blnCategories && objSEOFolder.ID == mintCurrentCategoryID)
                    {
                        objWriter.WriteAttributeString("CC","1");
                    }

                    // Provide category, that folder belongs to
                    objWriter.WriteAttributeString("CT", objSEOFolder.GetCategory().ID.ToString());    

                    if (mblnIsAdmin)
                    {
                        objWriter.WriteAttributeString(WGAttributes.LabelEdit, "1");
                    }

                    // If is expanded and not categories view
                    if (objState.IsExpanded && !blnCategories)
                    {
                        // Render the folder content
                        RenderTreeFolderItems(objContext, objWriter, 0, objSEOFolder, blnCategories);
                    }
                    objWriter.WriteEndElement();
                }
                else
                {
                    // If is expanded and not categories view
                    if (objState.IsExpanded && !blnCategories)
                    {
                        // Render the folder content
                        RenderTreeFolderItems(objContext, objWriter, lngRequestID, objSEOFolder, blnCategories);
                    }
                }
            }
        }

        /// <summary>
        /// Render tree folders
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="objSEOFolder">The SEO category folder.</param>
        /// <param name="blnCategories">True if we render the categories else the tree items</param>
        private void RenderTreeFolderItems(IContext objContext, IResponseWriter objWriter, long lngRequestID, SEOFolder objSEOFolder, bool blnCategories)
        {
            // Loop all items in the category/folder
            foreach (SEOItem objSEOSubItem in objSEOFolder.Items)
            {
                if (objSEOSubItem.Status == SEOItemStatus.Publish || mblnIsAdmin)
                {
                    SEOFolder objSEOSubFolder = objSEOSubItem as SEOFolder;
                    if (objSEOSubFolder != null)
                    {
                        RenderTreeFolder(objContext, objWriter, lngRequestID, objSEOSubFolder, blnCategories);
                    }
                    else if (!blnCategories)
                    {
                        // If is not categories view
                        // If not a folder item
                        RenderTreePage(objContext, objWriter, lngRequestID, objSEOSubItem);
                    }
                }
            }
        }

        /// <summary>
        /// Collapses the given objSEOSubFolder, except the cases:
        ///  - it is not current item itself
        ///  - it is not an Item that is under a "common expanded parent" with current item
        ///  - it is not a category item
        /// </summary>
        /// <param name="objSEOSubFolder">Item to collapse</param>
        private void Collapse(SEOFolder objSEOSubFolder, long lngRequestID)
        {
            SEOItem objCurrentItem = SEOSite.GetItemByID(mintCurrentItemID);

            if (objCurrentItem != null && objSEOSubFolder != null && !objCurrentItem.IsCategory())
            {
                foreach (SEOFolder objSubCategory in objSEOSubFolder.Folders)
                {
                    NavigationViewItemState objState = GetItemState(objSubCategory);
                    if (objState.IsExpanded && !objCurrentItem.IsParent(objSubCategory))
                    {
                        if (objSubCategory.IsSubCategory())
                        {
                            objState.IsExpanded = false;
                            objState.UpdatedOn = lngRequestID + 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Render tree folder content items
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="objSEOItem">The SEO item - non folder type item.</param>
        private void RenderTreePage(IContext objContext, IResponseWriter objWriter, long lngRequestID, SEOItem objSEOItem)
        {
            // Get the item state
            NavigationViewItemState objState = GetItemState(objSEOItem);
            if (objState != null)
            {
                // If the node was updated 
                if (objState.UpdatedOn > lngRequestID)
                {
                    objWriter.WriteStartElement("GZND");
                    objWriter.WriteAttributeString(WGAttributes.OwnerID, this.ID.ToString());
                    objWriter.WriteAttributeString(WGAttributes.MemberID, GetItemID(objSEOItem, false));
                    objWriter.WriteAttributeString(WGAttributes.Title, objSEOItem.DisplayName);
                    objWriter.WriteAttributeString(WGAttributes.Events, "0");
                    objWriter.WriteAttributeString(WGAttributes.ToolTip, objSEOItem.Description);
                    // Indicates where the item is current page/category
                    if (objSEOItem.ID == mintCurrentItemID || objSEOItem.ID == mintCurrentCategoryID)
                    {   
                        objWriter.WriteAttributeString(WGAttributes.CurrentPage,"1");
                    }

                    // Provide category, that page belongs to
                    objWriter.WriteAttributeString("CT", objSEOItem.GetCategory().ID.ToString());    

                    if (mblnIsAdmin)
                    {
                        objWriter.WriteAttributeString(WGAttributes.LabelEdit, "1");
                    }
                    objWriter.WriteEndElement();
                }
            }
        }

        private string GetItemID(SEOItem objSEOItem, bool blnCategory)
        {
            return string.Format("{0}{1}",  blnCategory ? "C" : "N" , objSEOItem.ID);
        }


        /// <summary>
        /// Gets the item state
        /// </summary>
        private NavigationViewItemState GetItemState(SEOItem objSEOItem)
        {
            NavigationViewItemState objState = null;

            if (mobjState.ContainsKey(objSEOItem.ID))
            {
                objState = mobjState[objSEOItem.ID];
            }
            else
            {
                mobjState[objSEOItem.ID] = objState = new NavigationViewItemState();
            }

            return objState;
        }

    }//class
}//namespace
