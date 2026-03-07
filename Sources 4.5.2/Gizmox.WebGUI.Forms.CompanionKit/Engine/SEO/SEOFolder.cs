using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Represents a SEO folder
    /// </summary>
    public class SEOFolder : SEOLobby
    {
        /// <summary>
        /// All items that belongs to this folder, keyed by Item.Name.ToLower() property
        /// </summary>
        private Dictionary<string, SEOItem> mobjByNameItems = new Dictionary<string, SEOItem>();

        /// <summary>
        /// The items collection sorted by Item.Type(primary) and IComparable order (secondary) 
        /// for further iteration with type oriented iterators
        /// </summary>
        private List<SEOItem> mobjSortedItems = null;
        /// <summary>
        /// The items colleciton sorted by IComparable order
        /// </summary>
        private List<SEOItem> mobjOrderedItems = null;

        /// <summary>
        /// The sorted items creation lock
        /// </summary>
        private object mobjSortedItemsLock = new object();
        /// <summary>
        /// The ordered items creation lock
        /// </summary>        
        private object mobjOrderedItemsLock = new object();

        /// <summary>
        /// The relative full Item name of "default" Item that should be open when
		/// the Folder shown
        /// </summary>
        private string mstrDefaultPage = null;

		/// <summary>
		/// The folder will be presented with demo/feature presentation elements
		/// </summary>
		protected bool mblnHasLobby = true;	

        /// <summary>
        /// Initializes a new (not from a data file) instance of the <see cref="SEOFolder"/> class.
        /// </summary>
        public SEOFolder(string strFSOFolder, SEOFolder objSEOParent)
            : base(strFSOFolder, objSEOParent)
        {
            this.Type = SEOItemType.Folder;
        }

        /// <summary>
        /// C'tor for loading a saved instance of Folder from data file under the specific parent
        /// </summary>
        public SEOFolder(string strFSOItem, XmlElement objElement, SEOFolder objSEOParent)
            : base(strFSOItem, objElement, objSEOParent)
        {
            this.Load(this.DataFile);
            this.Type = SEOItemType.Folder;
		}

        /// <summary>
        /// Loading the sub-Folder Items (recursively) and plain Items.
        /// </summary>
        /// <param name="strFSOItem"></param>
        protected virtual void Load(string strFSOItem)
        {
            // Get sub folders
            string[] arrFolders = Directory.GetDirectories(Path.GetDirectoryName(strFSOItem));

            // Loop all folders
            foreach (string strFolder in arrFolders)
            {
                // Get the folder seo file
                string strFolderSEOFile = Path.Combine(strFolder, "folder.seo");

                // If the is a directory named the same
                if (File.Exists(strFolderSEOFile))
                {
                    // Get folder name
                    string strName = Path.GetFileName(strFolder);

                    // Create a folder
                    mobjByNameItems[strName.ToLower()] = SEOItem.LoadItem(this, strFolderSEOFile);
                }
            }

            // Loop all folder files
            string[] arrFiles = Directory.GetFiles(Path.GetDirectoryName(strFSOItem), "*.seo");

            foreach (string strFile in arrFiles)
            {
                // Get the name
                string strName = Path.GetFileNameWithoutExtension(strFile);

                // If is not a folder seo file
                if (strName != "folder")
                {
                    // If the items is not already filled with a folder with this name
                    if (!mobjByNameItems.ContainsKey(strName))
                    {
                        // Create a file
                        mobjByNameItems[strName.ToLower()] = SEOItem.LoadItem(this, strFile);
                    }
                }

            }
        }

        #region SEOElement implementation
        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Load(XmlElement objSEOItemElement)
        {
            base.Load(objSEOItemElement);

            mblnHasLobby = SEOUtils.GetAttribute(objSEOItemElement, "HasLobby", true);
            mstrDefaultPage = SEOUtils.GetValue(objSEOItemElement, "DefaultPage");
        }

        /// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Save(XmlElement objSEOItemElement)
        {
            base.Save(objSEOItemElement);

			SEOUtils.SetAttribute(objSEOItemElement, "HasLobby", mblnHasLobby);
            SEOUtils.SetValue(objSEOItemElement, "DefaultPage", mstrDefaultPage);
        } 
        #endregion

        /// <summary>
        /// Gets the contained folders.
        /// </summary>
        /// <value>The contained folders.</value>
        public IEnumerable<SEOFolder> Folders
        {
            get
            {
                return new SEOFolderCollection(this.SortedItems);
            }
        }

		/// <summary>
		/// Iterates all folder items recursively(DFS). Excluding itself.
		/// </summary>
		public IEnumerable<SEOFolder> FoldersRecursively
		{
            get
            {
				foreach (SEOFolder objFolder in this.Folders)
				{
					yield return objFolder;
					
					foreach (SEOFolder objSubFolder in objFolder.FoldersRecursively)
						yield return objSubFolder;
				}
			}
		}

        /// <summary>
        /// Gets the contained pages.
        /// </summary>
        /// <value>The contained pages.</value>
        public IEnumerable<SEOPage> Pages
        {
            get
            {
                return new SEOPageCollection(this.SortedItems);
            }
        }

        /// <summary>
        /// Gets the contained non-folder Items.
        /// </summary>
        public IEnumerable<SEOItem> PlainItems
        {
            get
            {
                return new SEOPlainCollection(this.SortedItems);
            }
        }

		/// <summary>
		/// Iterates all plain(non-folder items) recursively(DFS).
		/// </summary>
		public IEnumerable<SEOItem> PlainItemsRecursively
		{
            get
            {
				foreach (SEOItem objItem in this.PlainItems)
					yield return objItem;

				foreach (SEOFolder objFolder in this.FoldersRecursively)
						foreach (SEOItem objItem in objFolder.PlainItems)
							yield return objItem;
			}
		}

        /// <summary>
        /// Gets all (folder and plain) contained Items. In native IComparable order
        /// </summary>
        public IEnumerable<SEOItem> Items
        {
            get
            {
                return new SEOItemCollection(this.OrderedItems);
            }
        }

        /// <summary>
        /// Gets all (folder and plain) contained Items. Un-ordered.
        /// </summary>
        private IEnumerable<SEOItem> RawItems
        {
            get
            {
                return mobjByNameItems.Values;
            }
        }
        /// <summary>
        /// Gets the items sorted by Type (primary sort) and Item's native sort(secondary).
        /// </summary>
        private IEnumerable<SEOItem> SortedItems
        {
            get
            {
                if (mobjSortedItems == null)
                {
                    lock (mobjSortedItemsLock)
                    {
                        if (mobjSortedItems == null)
                        {
                            mobjSortedItems = new List<SEOItem>(this.RawItems);
                            
                            // To gurantee correct work of enumerators with different items in same collection 
							// or list we need to sort the items according to the Type of the Item as primary
							// sort and if equal then by native Item sort as secondary
                            mobjSortedItems.Sort(
                                (Comparison<SEOItem>)(delegate(SEOItem a, SEOItem b)
                                {
                                    int intCompare = a.Type.CompareTo(b.Type);
                                    if (intCompare == 0)
                                    {
                                        // the items of same type, compare regullary
                                        intCompare = ((IComparable<SEOItem>)a).CompareTo(b);
                                    }
                                    return intCompare;
                                }
                            ));
                        }
                    }
                }

                return mobjSortedItems;
                
            }
        }

        /// <summary>
        /// Gets the items sorted by item's native sort order.
        /// </summary>
        private IEnumerable<SEOItem> OrderedItems
        {
            get
            {
                if (mobjOrderedItems == null)
                {
                    lock (mobjOrderedItemsLock)
                    {
                        if (mobjOrderedItems == null)
                        {
                            mobjOrderedItems = new List<SEOItem>(this.RawItems);
                            mobjOrderedItems.Sort();
                        }
                    }
                }

                return mobjOrderedItems;
                
            }
        }

        /// <summary>
        /// Gets the relative file.
        /// </summary>
        /// <value>The relative file.</value>
        public override string RelativeDataFile
        {
            get
            {
                return Path.Combine(this.RelativePath, Path.Combine(this.Name, "folder.seo"));
            }
        }

        /// <summary>
        /// Gets the default page.
        /// </summary>
        public SEOItem DefaultPage
        {
            get
            {
                return SEOSite.GetItemByRelativeName(this, mstrDefaultPage) as SEOItem;
            }
			set
			{
				mstrDefaultPage = value == null ? null : value.GetInnerLink();
			}
        }

        /// <summary>
        /// Determine where the default page defined
        /// </summary>
        public bool HasDefaultPage
        {
            get
            {
                return !String.IsNullOrEmpty(mstrDefaultPage);
            }
        }

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public int ItemCount
        {
            get
            {
                return mobjByNameItems.Count;
            }
        }

        /// <summary>
        /// Gets the <see cref="Gizmox.WebGUI.Forms.SEO.SEOItem"/> with the specified name.
        /// </summary>
        /// <value></value>
        public virtual SEOItem this[string strName]
        {
            get
            {
                if(!String.IsNullOrEmpty(strName) && mobjByNameItems.ContainsKey(strName.ToLower()))
                {
                    try
                    {
                        return mobjByNameItems[strName.ToLower()];
                    }
                    catch (KeyNotFoundException)
                    {
                    }
                }
                return null;
            }
        }


        /// <summary>
        /// Deletes this instance.
        /// </summary>
        internal override void Delete()
        {
            // Delete the current direcotry
            base.Delete();

            // Get temp collection to loop and delete from
            List<SEOItem> objToBeDeleted = new List<SEOItem>(this.RawItems);

            // Loop all sub items to delete
            foreach (SEOItem objSubItem in objToBeDeleted)
            {
                objSubItem.Delete();
            }
        }


        /// <summary>
        /// Attaches new items
        /// </summary>
        /// <param name="objSEOItem"></param>
        internal void AttachNewItem(SEOItem objSEOItem)
        {
            if (objSEOItem != null)
            {
                if (objSEOItem.Parent == this)
                {
                    mobjByNameItems[objSEOItem.Name.ToLower()] = objSEOItem;
                    mobjSortedItems = null;
                    mobjOrderedItems = null;
                }
            }
        }

        /// <summary>
        /// Remove contained item
        /// </summary>
        /// <param name="objSEOItem"></param>
        internal void RemovedItem(SEOItem objSEOItem)
        {
            if (mobjByNameItems != null)
            {
                if (mobjByNameItems.ContainsKey(objSEOItem.Name.ToLower()))
                {
                    mobjByNameItems.Remove(objSEOItem.Name.ToLower());
                    mobjSortedItems = null;
                    mobjOrderedItems = null;
                }
            }
        }



        /// <summary>
        /// Searches the items.
        /// </summary>
        /// <param name="strWildcard">The wildcard.</param>
		/// <remarks>Deprecated. Use CKSearchEngine.Search() functionality.</remarks>
        /// <returns></returns>
        public SEOSearchItems SearchItems(string strWildcard, int intMaxResults)
        {
            SEOSearchItems objFoundItems = new SEOSearchItems();
            if (!string.IsNullOrEmpty(strWildcard))
            {                
                this.SearchItems(strWildcard.ToLowerInvariant(), objFoundItems, intMaxResults);
            }
            return objFoundItems;
        }


        /// <summary>
        /// Searches the items.
        /// </summary>
        /// <param name="strWildcard">The wildcard.</param>
		/// <remarks>Deprecated. Use CKSearchEngine.Search() functionality.</remarks>
        /// <param name="objFoundItems">The found items.</param>
        internal override void SearchItems(string strWildcard, SEOSearchItems objFoundItems, int intMaxResults)
        {
            // Loop all sub items and add results
            if (this.IsSearchItem(strWildcard))
            {
                objFoundItems.Add(new SEOSearchItem(this));
            }
            foreach (SEOItem objSubItem in this.RawItems)
            {
                // If not past max items
                if (objFoundItems.Count >= intMaxResults)
                {
                    break;
                }
                else
                {   
                    objSubItem.SearchItems(strWildcard, objFoundItems, intMaxResults);
                }
            }
        }

        #region Validate item

        public override void Validate(SEOSearchItems objFoundItems, int intMaxResults)
        {
			string strReason = string.Empty;

			base.Validate(objFoundItems, intMaxResults);

			if (objFoundItems.Count < intMaxResults)
			{
				if (!this.HasLobby)
				{
					// check that default item is correct
					if (mstrDefaultPage != null && mstrDefaultPage.Trim().Length > 0 && this.DefaultPage == null)
					{
						strReason = string.Format("Default item: '{0}', unavailable.", mstrDefaultPage);
						objFoundItems.Add(new SEOSearchItem(this,strReason));
					}
				}

				// check that all inner Items are OK
				foreach (SEOItem objSubItem in this.RawItems)
				{
					objSubItem.Validate(objFoundItems, intMaxResults);
				}           
			}

        }

        #endregion

        /// <summary>
        /// Get all SEOItems that are referencing to the <paramref name="objSEOItem"/> in terms
        /// of relationship consistency. For example the consistency could be hit if
        /// <paramref name="objSEOItem"/> deleted and this item has a kind of link to it.
        /// </summary>
        public override void GetReferencesTo(SEOItem objSEOItem, List<SEOItem> objReferences)
        {
			base.GetReferencesTo(objSEOItem, objReferences);

			// check that if set to redirect to default item
			// than the default item referenced
			if (!this.HasLobby)
			{
				// add this folder to mean that it has reference to default item
				// to warn before deleting of default item
				if (this.DefaultPage == objSEOItem)
				{
					objReferences.Add(this);
				}
			}

            foreach (SEOItem objSubItem in this.RawItems)
            {
                objSubItem.GetReferencesTo(objSEOItem, objReferences);
            }            
        }

		/// <summary>
		/// Where the folder will be presented with sections of elements
		/// </summary>
		public bool HasLobby
		{
			get { return mblnHasLobby; }
			set { mblnHasLobby = value; }
		}
    }
}
