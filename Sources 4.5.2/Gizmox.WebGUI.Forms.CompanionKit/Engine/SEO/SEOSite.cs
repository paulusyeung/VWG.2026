using System;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.Data;
using System.Configuration;
using Gizmox.WebGUI.Forms.CompanionKit.Engine.Search;


namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Represents the entire site
    /// </summary>
    public class SEOSite
    {
        private static SEOFolder mobjRoot = null;

        private static object mobjRootLock = new object();

        private static int mintCurrentID = 0;

        private static object mobjCurrentIDLock = new object();

		private static CKSearchEngine mobjSearch = new CKSearchEngine();

        private SEOSite()
        {
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public static SEOFolder Root
        {
            get 
            {
                if (mobjRoot == null)
                {
                    lock (mobjRootLock)
                    {
                        if (mobjRoot == null)
                        {
                            mobjRoot = (SEOFolder)SEOItem.LoadItem(
											null, HttpContext.Current.Server.MapPath("~/") + "folder.seo");

							// To avoid from matching the root Item in the searches
                            mobjRoot.DisplayName = string.Empty;
							mobjRoot.Title = string.Empty;
							mobjRoot.Keywords = new string[]{};
                        }
                    }
                }

                return mobjRoot;
            }
        }

        /// <summary>
        /// Gets the next ID.
        /// </summary>
        /// <returns></returns>
        internal static int GetNextID()
        {
            // The next id reference
            int intNextID = 0;

            // Look ID generating
            lock (mobjCurrentIDLock)
            {
                // Increment the id
                mintCurrentID++;

                // Get the current id
                intNextID = mintCurrentID;
            }

            // Return the id
            return intNextID;
        }

		/// <summary>
		/// Gets the item by ID.
		/// </summary>
		/// <param name="intSEONodeID">The SEO node ID. If 0 returned root node.</param>
		/// <returns></returns>
        internal static SEOItem GetItemByID(int intSEONodeID)
        {
            return GetItemByID(SEOSite.Root, intSEONodeID);
        }

        internal static SEOItemResource GetItemResourceByID(int intSEONodeID, int intSEOResourceID)
        {
            SEOItem objSEOItem = GetItemByID(intSEONodeID);
            if (objSEOItem != null)
            {
                // Loop all resources
                foreach (SEOItemResource objResource in objSEOItem.Resources)
                {
                    // If found resource
                    if (objResource.ID == intSEOResourceID)
                    {
                        return objResource;
                    }
                }   
            }
            return null;
        }

		/// <summary>
		/// Gets the item by ID.
		/// </summary>
		/// <param name="objSEOFolder">The SEO folder where to start recusive search</param>
		/// <param name="intSEONodeID">The SEO node ID.</param>
		/// <returns></returns>
        private static SEOItem GetItemByID(SEOFolder objSEOFolder, int intSEONodeID)
        {
			if (intSEONodeID == 0)
			{
				return SEOSite.Root;
			}

            if (objSEOFolder.ID == intSEONodeID)
            {
                return objSEOFolder;
            }

            foreach (SEOItem objSEOPage in objSEOFolder.PlainItems)
            {
                if (objSEOPage.ID == intSEONodeID)
                {
                    return objSEOPage;
                }
            }

            foreach (SEOFolder objSEOSubFolder in objSEOFolder.Folders)
            {
                SEOItem objSEOItem = GetItemByID(objSEOSubFolder, intSEONodeID);
                if (objSEOItem != null)
                {
                    return objSEOItem;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the item by relative name to <paramref name="objParentFolder"/>
		/// Also supported notation where the <paramref name="strRelativeName"/> is full name started with 'item:'
        /// </summary>
        /// <example>
        /// 1) For: http://localhost:3883/Controls/CheckBox/Appearance/CheckAlignPage.wgx
        /// Input: Controls~CheckBox~Appearance~CheckAlignPage
        /// Result: the SEOPage object related
        /// 2) For: http://localhost:3883/Controls/CheckBox/Appearance.wgx
        /// Input: Controls~CheckBox~Appearance
        /// Result: the SEOFolder object
        /// </example>
        /// <param name="objParentFolder">The parent folder.</param>
        /// <param name="strRelativeName">name of the item in one of notations</param>
        /// <returns></returns>
        internal static SEOItem GetItemByRelativeName(SEOFolder objParentFolder, string strRelativeName)
        {
            if(!String.IsNullOrEmpty(strRelativeName))
            {
				const string strPrefix = "item:";
				strRelativeName = strRelativeName.ToLower();

				// check if the item is absolute link to Item
				if (strRelativeName.StartsWith(strPrefix + SEOUtils.CK_NAMESPACE_PREFIX.ToLower()))
				{
					objParentFolder = SEOSite.Root;
					// If is item name prefix specified with namespace beginning, adding +1 for including '.'
					strRelativeName = strRelativeName.Substring(strPrefix.Length + SEOUtils.CK_NAMESPACE_PREFIX.Length +1);
				}
				else if (strRelativeName.StartsWith(strPrefix))
				{
					objParentFolder = SEOSite.Root;
					strRelativeName = strRelativeName.Substring(strPrefix.Length);
				}
				
				string[] arrPath = strRelativeName.Split('.', '~');

				// Get the root folder
				SEOFolder objCurrentFolder = objParentFolder;

				// Loop all folders
				for (int intIndex = 0; intIndex < arrPath.Length - 1; intIndex++)
				{
					// Get the next folder
					objCurrentFolder = objCurrentFolder[arrPath[intIndex]] as SEOFolder;

					// If could not find folder
					if (objCurrentFolder == null)
					{
						return null;
					}
				}

				// If there is a current folder
				if (objCurrentFolder != null)
				{
					// Return the item from the current folder if available
					return objCurrentFolder[arrPath[arrPath.Length - 1]];
				}

            }
            return null;
        }

		/// <summary>
		/// Gets the item by one of notation, where the strItemID is one of:
		///	1.	"item: ..."
		/// 2.   ID - is assigned in runtime
		/// </summary>
		/// <returns>SEOItem or null if not found</returns>
		internal static SEOItem GetItem(string strItemID)
		{
            SEOItem objSEOItem = null;
			
			if (!string.IsNullOrEmpty(strItemID))
			{
				if (strItemID.StartsWith("item:"))
				{
					// If is item name prefix specified
					objSEOItem = SEOSite.GetItemByFullName(strItemID);
				}
				else
				{
					// if is Id specified
					int intItemID = -1;
					if (int.TryParse(strItemID, out intItemID))
					{
						objSEOItem = SEOSite.GetItemByID(intItemID);
					}
				}
			}

			return objSEOItem;
		}

        internal static SEOItem GetItemByFullName(string strFullName)
        {
            return GetItemByRelativeName(SEOSite.Root, strFullName);
        }

		/// <summary>
		/// Gets the SearchEngine
		/// </summary>
		/// <value>The search.</value>
		internal static CKSearchEngine Search
		{
			get
			{
				return mobjSearch;
			}
		}
    }
}
