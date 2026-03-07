using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using Gizmox.WebGUI.Common.Interfaces;
using System.Xml.Xsl;
using Gizmox.WebGUI.Forms.Skins;
using ICSharpCode.SharpZipLib.Zip;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;
using Gizmox.WebGUI.Forms.CompanionKit.Engine.Search;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Provide support for SEO items 
    /// </summary>
    public abstract class SEOItem : SEOSiteMapItem, IComparable<SEOItem>, IComparable
    {

        /// <summary>
        /// The SEO item name.
        /// The Filename of item's data file.
        /// </summary>
        protected string mstrName = null;
       
        /// <summary>
        /// The SEO display name
        /// </summary>
        private string mstrDisplayName = null;

        /// <summary>
        /// 
        /// </summary>
        private SEOItemResource[] mobjResources = null;

        /// <summary>
        /// 
        /// </summary>
		private List<SEOItemResource> mobjRemovedResources = null;

        /// <summary>
        /// 
        /// </summary>
        private object mobjResourcesLock = new object();

        /// <summary>
        /// The SEO parent folder
        /// </summary>
        private SEOFolder mobjSEOParent = null;

        /// <summary>
        /// The SEO keywords
        /// </summary>
        private string[] marrKeywords = new string[] { };

        /// <summary>
        /// The full qualified path to data file
        /// </summary>
        private readonly string mstrFSOItem = null;

        /// <summary>
        /// 
        /// </summary>
        private NameValueCollection mobjProperties = null;

        /// <summary>
        /// 
        /// </summary>
        private DateTime mobjLastModified = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        private readonly int mintItemID = 0;

        /// <summary>
        /// 
        /// </summary>
        private string mstrTitle = null;

        /// <summary>
        /// 
        /// </summary>
        private SEOItemStatus menmStatus = SEOItemStatus.Publish;

        /// <summary>
        /// 
        /// </summary>
        private SEOItemType menmType = SEOItemType.Page;

        /// <summary>
        /// The seo item order
        /// </summary>
        private int mintOrder = 0;

        /// <summary>
        /// Indicates if the item is new - not saved yet
        /// </summary>
        private bool mblnIsNew = false;

        /// <summary>
        /// Indecates if the seo item is deleted
        /// </summary>
        private bool mblnIsDeleted = false;

        /// <summary>
        /// 
        /// </summary>
        private string mstrDescription;


        /// <summary>
        /// Indicates if a project update is needed
        /// </summary>
        private bool mblnIsProjectUpdateNeeded = false;

        /// <summary>
        /// 
        /// </summary>
        private SEOItemResourceInfoCollection mobjResourceInfos = new SEOItemResourceInfoCollection();

        /// <summary>
        /// 
        /// </summary>
        private static string MetaTagTemplage = "<meta name=\"{0}\" content=\"{1}\" />";

        /// <summary>
        /// 
        /// </summary>
        private string mstrComment;



        /// <summary>
        /// Initializes a new instance of the <see cref="SEOItem"/> class.
        /// </summary>
        /// <param name="strFSOItem">The FSO item.</param>
        /// <param name="objSEOParent">The SEO parent.</param>
        /// <param name="blnIsNew">True - don't try to loaded from <paramref name="strFSOItem"/>, the item just created</param>
        protected SEOItem(string strFSOItem, SEOFolder objSEOParent, bool blnIsNew)
        {
            // Save new state
            mblnIsNew = blnIsNew;

            if (strFSOItem.EndsWith("folder.seo"))
            {
                mstrName = Path.GetFileName(Path.GetDirectoryName(strFSOItem));
            }
            else if(strFSOItem.EndsWith(".seo"))
            {
                // Get the file system name
                mstrName = Path.GetFileName(strFSOItem);
                mstrName = mstrName.Substring(0, mstrName.Length - 4);
            }

            // Set the item id 
            mintItemID = SEOSite.GetNextID();

            // Set the parent folder
            mobjSEOParent = objSEOParent;
            
            // Set the fso item
            mstrFSOItem = strFSOItem;
            
            // If is not a new item
            if (blnIsNew)
            {
                // Resource collection
                mobjResources = new SEOItemResource[] { };
                mobjProperties = new NameValueCollection();
            }

        }

        protected SEOItem(string strFSOItem, SEOFolder objSEOParent)
            : this(strFSOItem, objSEOParent, true)
        {
        }

        protected SEOItem(string strFSOItem, XmlElement objElement, SEOFolder objSEOParent)
            : this(strFSOItem, objSEOParent, false)
        {
            Load(objElement);
        }

        /// <summary>
        /// Gets the physical path to Item's data file.
        /// </summary>
        /// <value>Full qialified path to the directory w/o file name.</value>
		/// <example>
		/// d:\My Work\Net2.0\Public\Core\Gizmox.WebGUI.Forms.CompanionKit\Controls\Button\Functionality
		/// </example>
        internal virtual string DataPath
        {
            get
            {
                if (mstrFSOItem.EndsWith(".seo"))
                {
                    return Path.GetDirectoryName(mstrFSOItem);
                }
                return mstrFSOItem;
            }
        }

        /// <summary>
        /// Gets the data file.
        /// </summary>
        /// <value>The data file.</value>
		/// <example>
		/// d:\My Work\Net2.0\Public\Core\Gizmox.WebGUI.Forms.CompanionKit\Controls\Button\Functionality\ClickOncePage.seo
		/// </example>
        internal virtual string DataFile
        {
            get
            {
                return mstrFSOItem;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            Save(this.DataFile);

            // If item is marked as new
            if (mblnIsNew)
            {
                // Mark as not new
                mblnIsNew = false;

                // If parent is not null
                if (this.Parent != null)
                {
                    this.Parent.AttachNewItem(this);
                }

                // Update the project file 
                SEOUtils.UpdateProject(this);
            }
            else
            {
                // If project update is needed
                if (mblnIsProjectUpdateNeeded)
                {
                    // Update the project file after saving the seo item
                    SEOUtils.UpdateProject(this);
                }
            }

			// The item saved and index information probably updated
			AutoComplete.Collect();

			// Updated search index information related to the item
			SEOSite.Search.ReplaceEntity(this);

			// cause to re-sort the resources, to handle the case of sort order update
			mobjResources = null;
        }

        /// <summary>
        /// Save the item to the SEO item document
        /// </summary>
        /// <param name="strFSOItem"></param>
        protected virtual void Save(string strFSOItem)
        {
            SaveToFile(strFSOItem);
        }

        /// <summary>
        /// Save the item to the SEO item document
        /// </summary>
        /// <param name="strFSOItem"></param>
        protected virtual void SaveToFile(string strFSOItem)
        {
            // Get the data file
            strFSOItem = mstrFSOItem;

            if (mblnIsNew)
            {
                // Get directory from file name
                string strDirectory = Path.GetDirectoryName(strFSOItem);

                // Check if directory exists 
                if (!Directory.Exists(strDirectory))
                {
                    // Create directory
                    Directory.CreateDirectory(strDirectory);
                }
            }

            // Get the seo item document
            XmlDocument objDocument = new XmlDocument();
            objDocument.LoadXml("<Item/>");
            Save(objDocument.DocumentElement);
            objDocument.Save(strFSOItem);

            // Get the last modified date
            mobjLastModified = File.GetLastWriteTime(strFSOItem);
            
        }

        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Load(XmlElement objSEOItemElement)
        {
            base.Load(objSEOItemElement);
            mstrTitle = SEOUtils.GetValue(objSEOItemElement, "Title");
            mstrDisplayName = SEOUtils.GetValue(objSEOItemElement, "DisplayName", this.Name);
            mstrDescription = SEOUtils.GetValue(objSEOItemElement, "Description", mstrDescription);
            mintOrder = SEOUtils.GetAttribute(objSEOItemElement, "Order", mintOrder);
            menmStatus = SEOUtils.GetAttribute<SEOItemStatus>(objSEOItemElement, "Status", menmStatus);
            menmType = SEOUtils.GetAttribute<SEOItemType>(objSEOItemElement, "Type", menmType);
            marrKeywords = SEOUtils.GetArrayValue(objSEOItemElement, "Keywords", "Keyword");
            mstrComment = SEOUtils.GetValue(objSEOItemElement, "Comment", mstrComment);

            // Load the node properties
            mobjProperties = SEOUtils.GetProperties(objSEOItemElement, "Properties/Property");
            mobjResourceInfos = SEOUtils.GetResourceInfos(objSEOItemElement, "Resources", "Resource");
        }

        /// <summary>
        /// Loads the SEOItem from the strFSOItem data file
        /// </summary>
        internal static SEOItem LoadItem(SEOFolder objParent, string strFSOItem)
        {
            SEOItem objItem = null;
            
            try
            {
                // If found item file
                if (File.Exists(strFSOItem))
                {
                    // Get the last modified date
                    DateTime objLastModified = File.GetLastWriteTime(strFSOItem);

                    // Get the seo item document
                    XmlDocument objDocument = new XmlDocument();
                    objDocument.Load(strFSOItem);

                    XmlAttribute objTypeAttribute = (XmlAttribute)objDocument.SelectSingleNode("Item/@Type");
                    SEOItemType enmItemType = SEOItemType.Page;

                    if (objTypeAttribute != null)
                    {
                        enmItemType = (SEOItemType)Enum.Parse(typeof(SEOItemType), objTypeAttribute.Value);
                        switch (enmItemType)
                        {
                            case SEOItemType.Folder:
                                objItem = new SEOFolder(strFSOItem, objDocument.DocumentElement, objParent);
                                break;
                            case SEOItemType.Lobby:
                                objItem = new SEOLobby(strFSOItem, objDocument.DocumentElement, objParent);
                                break;
                            case SEOItemType.Page:
                                objItem = new SEOPage(strFSOItem, objDocument.DocumentElement, objParent);
                                break;
                            case SEOItemType.Article:
                                objItem = new SEOArticle(strFSOItem, objDocument.DocumentElement, objParent);
                                break;
                        }
                        objItem.LastModified = objLastModified;
                    }
                }
                else
                {
                    throw new SEOException("Could not find item file.", null);
                }
            }
            catch (Exception objException)
            {
                throw new SEOException(
                    string.Format("Item initialization falied at '{0}'", "Loading from file"),
                        objException);
            }
            return objItem;
        }

        /// <summary>
        /// Creates new SEOItem in according to type
        /// </summary>
        internal static SEOItem CreateItem(SEOFolder objParent, SEOItemType enmItemType, string strFSOItem)
        {
            SEOItem objItem = null;
            switch (enmItemType)
            {
                case SEOItemType.Folder:
                    objItem = new SEOFolder(strFSOItem, objParent);
                    break;
                case SEOItemType.Lobby:
                    objItem = new SEOLobby(strFSOItem, objParent);
                    break;
                case SEOItemType.Page:
                    objItem = new SEOPage(strFSOItem, objParent);
                    break;
                case SEOItemType.Article:
                    objItem = new SEOArticle(strFSOItem, objParent);
                    break;
            }
            return objItem;
        }

        /// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Save(XmlElement objSEOItemElement)
        {
			base.Save(objSEOItemElement);
            SEOUtils.SetValue(objSEOItemElement, "Title", mstrTitle);
            SEOUtils.SetAttribute(objSEOItemElement, "Order", mintOrder);
            SEOUtils.SetProperties(objSEOItemElement, "Properties", mobjProperties);
            SEOUtils.SetValue(objSEOItemElement, "DisplayName", mstrDisplayName);
            SEOUtils.SetValue(objSEOItemElement, "Description", mstrDescription);            
            SEOUtils.SetResourceInfos(objSEOItemElement, "Resources", "Resource", mobjResourceInfos);
            SEOUtils.SetAttribute(objSEOItemElement, "Status", menmStatus);
            SEOUtils.SetAttribute(objSEOItemElement, "Type", menmType);
            SEOUtils.SetArrayValue(objSEOItemElement, "Keywords", "Keyword", marrKeywords);
            SEOUtils.SetValue(objSEOItemElement, "Comment", mstrComment);
        }

        /// <summary>
        /// Gets the seo item ID.
        /// </summary>
        /// <value>The seo item ID.</value>
        public int ID
        {
            get { return mintItemID; }
        } 

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public SEOItemType Type
        {
            get
            {
                return menmType;
            }
            internal set
            {
                menmType = value;
            }
        }

        /// <summary>
        /// Gets the SEO item name.
        /// </summary>
        /// <value>The SEO item name.</value>
        public string Name
        {
            get
            {
                return mstrName;
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        internal string Comment
        {
            get { return mstrComment; }
            set { mstrComment = value; }
        }
	
        /// <summary>
        /// Gets the non script content.
        /// </summary>
        /// <value>The non script content.</value>
        internal string NonScriptContent
        {
            get
            {
                return this.Title;
            }
        }
        
        /// <summary>
        /// Gets the content of the meta tags.
        /// </summary>
        /// <value>The content of the meta tags.</value>
        internal string MetaTagsContent
        {
            get
            {
                StringBuilder objTagContent = new StringBuilder();
                objTagContent.AppendFormat(MetaTagTemplage, "keywords", string.Join(", ", this.Keywords));
                objTagContent.AppendFormat(MetaTagTemplage, "description", this.Description);
                return objTagContent.ToString();
            }
        }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        /// <value>The namespace.</value>
        public string Namespace
        {
            get
            {
                return SEOUtils.GetItemNamespace(this, true);
            }
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                return string.Format("{0}.{1}", SEOUtils.GetItemNamespace(this, false), this.Name);
            }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public virtual string DisplayName
        {
            get { return mstrDisplayName; }
            set { mstrDisplayName = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return mstrDescription; }
            set { mstrDescription = value; }
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order
        {
            get { return mintOrder; }
            internal set
            {
                mintOrder = value;
            }
        }

        /// <summary>
        /// Gets the SEO item title.
        /// </summary>
        /// <value>The SEO item title.</value>
        public string Title
        {
            get
            {
                return mstrTitle;
            }
            internal set
            {
                mstrTitle = value;
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        protected virtual string FileName
        {
            get
            {
                return string.Format("{0}{1}", this.Name, this.Extension);
            }
        }

        /// <summary>
        /// Gets the path to the item's directory
        /// </summary>
		/// <example>
		///[item]: \Controls\Button\Functionality\ClickOncePage.seo
		/// [out]: \Controls\Button\Functionality\
		/// </example>
        public virtual string RelativePath
        {
            get
            {
                if (this.Parent == null)
                {
                    return "";
                }
                else if (this.Parent.Parent == null)
                {
                    // the root
                    return "/";
                }
                else
                {
                    return string.Format("{0}{1}/", this.Parent.RelativePath, this.Parent.Name);
                }
            }
        }

        /// <summary>
        /// Gets the relative file.
        /// </summary>
        /// <value>The relative file.</value>
        public virtual string RelativeDataFile
        {
            get
            {
                return Path.Combine(this.RelativePath, string.Format("{0}.seo",this.Name));
            }
        }
        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public NameValueCollection Properties
        {
            get
            {

                if (mobjProperties == null)
                {
                    mobjProperties = new NameValueCollection();
                }
                return mobjProperties;
            }
        }

        /// <summary>
        /// Gets the item link, without domain, leaded by '/'.
        /// </summary>
        /// <value>The item link.</value>
		/// <example>
		/// /Controls/ListView/Features/ItemPanel.wgx
		/// </example>
        public string Link
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", 
					SEOUtils.GetApplicationPath(), this.RelativePath, this.FileName, this.QueryString); 
            }
        }

		/// <summary>
		/// Full qualified HREF link to the item
		/// </summary>
		/// <example>
		/// http://localhost:4196/Controls/ListView/Features/ItemPanel.wgx
		/// </example>
		public string HrefLink
		{
			get
			{
				return string.Format("{0}{1}", 
					SEOUtils.GetDomainValue(HostContext.Current.Request.Url), 
					this.Link);
			}
		}

        /// <summary>
        /// Gets the query string.
        /// </summary>
        /// <value>The query string.</value>
        private string QueryString
        {
            get
            {
                // If there are valid arguments
                if (this.Arguments != null)
                {
                    // If there are arguments
                    if (this.Arguments.Count > 0)
                    {
                        // Querystring collector
                        StringBuilder objQuery = new StringBuilder();

                        // Loop all keys
                        foreach (string strKey in this.Arguments.AllKeys)
                        {
                            // If it is the first key
                            if (objQuery.Length == 0)
                            {
                                objQuery.Append("?");
                            }
                            else
                            {
                                objQuery.Append("&");
                            }

                            // Add the current key and value
                            objQuery.AppendFormat("{0}={1}", HttpUtility.UrlEncode(strKey), HttpUtility.UrlEncode(this.Arguments[strKey]));
                        }
                        return objQuery.ToString();
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the page instance arguments.
        /// </summary>
        /// <value>The page instance arguments.</value>
        protected virtual NameValueCollection Arguments
        {
            get
            {
                return null;
            }
        }
        

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        protected string Extension
        {
            get
            {
                return ".wgx";
            }
        }


        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public SEOFolder Parent
        {
            get
            {
                return mobjSEOParent;
            }
        }


        /// <summary>
        /// Gets the last modified date.
        /// </summary>
        /// <value>The last modified date.</value>
        public DateTime LastModified
        {
            get
            {
                return mobjLastModified;
            }
            internal set
            {
                mobjLastModified = value;
            }
        }

        /// <summary>
        /// Gets the removed resources.
        /// </summary>
        /// <value>The removed resources.</value>
        internal List<SEOItemResource> RemovedResources
        {
            get
            {
				if (mobjRemovedResources == null)
				{
					mobjRemovedResources = new List<SEOItemResource>();
				}
				return mobjRemovedResources;
            }
        }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <value>The resources.</value>
        public SEOItemResource[] Resources
        {
            get 
            {
                // If resources was yet to be loaded
                if (mobjResources == null)
                {
                    // Lock resources creation
                    lock (mobjResourcesLock)
                    {
                        // If resources is still null
                        if (mobjResources == null)
                        {
                            // Load resources
                            List<SEOItemResource> objResources = new List<SEOItemResource>();

                            // The resource id
                            int intResourceID = 1;

                            SEOItemResourceInfo[] objInfos = mobjResourceInfos.ToArray();
                            Array.Sort(objInfos);


                            // Loop all resources
                            foreach(SEOItemResourceInfo objItemResourceInfo in objInfos)
                            {
                                // Add new resoruce
                                objResources.Add(new SEOItemResource(this, intResourceID, objItemResourceInfo));

                                // Increment resource id
                                intResourceID++;
                            }

                            // Create the resources array
                            mobjResources = objResources.ToArray();
                        }
                    }
                }
                return mobjResources; 
            }
        }

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance is less than <paramref name="obj"/>.
        /// Zero
        /// This instance is equal to <paramref name="obj"/>.
        /// Greater than zero
        /// This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="objItem"/> is not the same type as this instance.
        /// </exception>
        int IComparable.CompareTo(object objItem)
        {
            return ((IComparable<SEOItem>)this).CompareTo(objItem as SEOItem);
        }

        #endregion

        #region IComparable<SEOItem> Members

        /// <summary>
        /// Compares the current instance with another object of the same type and returns 
        /// an integer that indicates whether the current instance precedes, follows, 
        /// or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="objOtherItem">The other item.</param>
        /// <returns></returns>
        /// <remarks>
        /// From most to less imporatant:
        ///   Order of Item
        ///   DisplayName
        ///   Name
        /// </remarks>
        int IComparable<SEOItem>.CompareTo(SEOItem objOtherItem)
        {
            // If there is a valid item
            if (objOtherItem != null)
            {
                int intCompare = this.Order.CompareTo(objOtherItem.Order);

                // If order is the same, compare by DisplayName and Name
                if (intCompare == 0)
                {                    
                    string strThisName = this.DisplayName.Trim().Length == 0 ? this.Name : this.DisplayName; 
                    string strOtherName = objOtherItem.DisplayName.Trim().Length == 0 ? objOtherItem.Name : objOtherItem.DisplayName;                     
                    
                    // Sort by DisplayName and if not specified then by Name
                    intCompare = strThisName.CompareTo(strOtherName);
                }
                return intCompare;
            }
            return 0;
        }

        #endregion

        /// <summary>
        /// Removes the resource.
        /// </summary>
        /// <param name="objResource">The resource.</param>
        internal void RemoveResource(SEOItemResource objResource)
        {            
            if (mobjResources != null)
            {
                // Indicate project update is needed if is a File resource
                mblnIsProjectUpdateNeeded = (objResource.ResourceInfo.Type == ResourceType.File);

                // Remove resource and update resources after adding to the removed collection
                List<SEOItemResource> objResources = new List<SEOItemResource>(mobjResources);
                objResources.Remove(objResource);

				// Add to the removed collection
				this.RemovedResources.Add(objResource);
                
				objResource.Delete();
                mobjResources = objResources.ToArray();

                // If we should remove the resource info
                mobjResourceInfos.RemoveByName(objResource.Name);
            }
        }

        /// <summary>
        /// Adds the resource.
        /// </summary>
        /// <param name="objResource">The resource.</param>
        internal void AddResource(SEOItemResource objResource)
        {
            if (mobjResources != null)
            {
                // Indicate project update is needed if File resource had been added
                mblnIsProjectUpdateNeeded = (objResource.ResourceInfo.Type == ResourceType.File);

                List<SEOItemResource> objResources = new List<SEOItemResource>(mobjResources);
                objResource.CreateAndAdd(objResources);
                mobjResourceInfos.Add(objResource.ResourceInfo);
                mobjResources = objResources.ToArray();
            }
        }

        internal virtual void Delete()
        {
            mblnIsDeleted = true;

            if (this.Parent != null)
            {
                this.Parent.RemovedItem(this);
            }

            SEOUtils.UpdateProject(this);
            SEOUtils.DeleteResources(this);
            SEOUtils.DeleteSEOFile(this);

			// Exclude the item's index information
			AutoComplete.Collect();
			SEOSite.Search.DeleteEntity(this);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        internal bool IsDeleted
        {
            get { return mblnIsDeleted; }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        internal SEOItemStatus Status
        {
            get { return menmStatus; }
            set { menmStatus = value; }
        }

        /// <summary>
        /// Searches the items.
        /// </summary>
        /// <param name="strWildcard">The wildcard.</param>
        /// <param name="objFoundItems">The found items.</param>
        internal virtual void SearchItems(string strWildcard, SEOSearchItems objFoundItems, int intMaxResults)
        {
            if (IsSearchItem(strWildcard))
            {
                objFoundItems.Add(new SEOSearchItem(this));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWildcard"></param>
        /// <returns></returns>
        protected virtual bool IsSearchItem(string strSearch)
        {
			IEnumerable<string> arrWildCards = SEOUtils.SplitToWildcards(strSearch);
			foreach (string strWildcard in arrWildCards)
			{
				if (!string.IsNullOrEmpty(strWildcard))
				{
					if (marrKeywords != null)
					{
						foreach (string strKeyword in marrKeywords)
						{
							if (!string.IsNullOrEmpty(strKeyword))
							{
								if (strKeyword.Equals(strWildcard, StringComparison.InvariantCultureIgnoreCase))
								{
									return true;
								}
							}
						}
					}

					if (!string.IsNullOrEmpty(mstrTitle))
					{
						if (mstrTitle.IndexOf(strWildcard, StringComparison.InvariantCultureIgnoreCase) > -1)
						{
							return true;
						}
					}

					if (!string.IsNullOrEmpty(mstrDisplayName))
					{
						if (mstrDisplayName.IndexOf(strWildcard, StringComparison.InvariantCultureIgnoreCase) > -1)
						{
							return true;
						}
					}

					if (!string.IsNullOrEmpty(mstrDescription))
					{
						if (mstrDescription.IndexOf(strWildcard, StringComparison.InvariantCultureIgnoreCase) > -1)
						{
							return true;
						}
					}
				}
			}

            return false;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        public override string ToString()
        {
            return string.Concat("{", this.GetType().Name, ":", this.Namespace, ".", this.Name,":",this.DisplayName, "}");
        }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        public string[] Keywords
        {
            get
            {
                return marrKeywords;
            }
            internal set
            {
                if (value != null)
                {
                    marrKeywords = value;
                }
                else
                {
                    marrKeywords = new string[]{};
                }
            }
        }

        /// <summary>
        /// Determine where the objSEOItem is a parent of this item, including itself
        /// and all parents of this item: immediate one or a recursive one.
        /// </summary>
        /// <param name="objSEOItem">The item to check.</param>
        /// <returns>
        /// 	<c>true</c> if the specified objSEOItem is parent; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsParent(SEOItem objSEOItem)
        {
            bool blnResult = false;

            // I am parent of my self
            if (this.ID == objSEOItem.ID)
            {
                blnResult = true;
            }
            else if( this.Parent != null)
            {
                blnResult = this.Parent.IsParent(objSEOItem);
            }

            return blnResult;
        }

        /// <summary>
        /// Determine the sub-category for this Item, where the definition of sub-category is:
        /// child(sub-category) -> child(category)->root
        /// </summary>
        internal SEOItem GetSubCategory()
        {
            SEOItem objSubCategory = null;
            if (this.IsSubCategory())
            {
                objSubCategory = this;
            }
            else
            {
                // follow parents from immediate to previous one
                for (SEOItem objParent = this.Parent; objParent != null; objParent = objParent.Parent)
                {
                    // the only for subcategory - the parent is root
                    if (objParent.Parent != null && objParent.Parent.Parent != null && objParent.Parent.Parent.ID == SEOSite.Root.ID)
                    {
                        objSubCategory = objParent;
                    }
                }
            }
            return objSubCategory;
        }

        /// <summary>
        /// Determine the category for this Item, where the definition of category is:
        /// 1) parent-of(sub-category)
        /// 2) child-of(root)
        /// </summary>
        internal SEOItem GetCategory()
        {
            SEOItem objCategory = null;

            // cover the case where I am category
            if (IsCategory())
            {
                objCategory = this;
            }
            else
            {
                //all other cases
                SEOItem objSubCategory = this.GetSubCategory();
                if (objSubCategory != null)
                {
                    objCategory = objSubCategory.Parent;
                }
            }
            return objCategory;
        }

        /// <summary>
        /// Determine where the item is "Sub-Category" - child of child of root
        /// </summary>       
        internal bool IsSubCategory()
        {
            return this.Parent != null && this.Parent.Parent != null && this.Parent.Parent.ID == SEOSite.Root.ID;
        }
        
        /// <summary>
        /// Determine where the item is "Category" - child of root
        /// </summary>
        internal bool IsCategory()
        {
            return this.Parent != null && this.Parent.ID == SEOSite.Root.ID;
        }
    
        /// <summary>
        /// Get all SEOItems that are referencing the <paramref name="objSEOItem"/> in terms
        /// of relationship consistency. For example the consistency could be hit if 
        /// <paramref name="objSEOItem"/> deleted and this item has a kind of link to it.
        /// </summary>
        /// <param name="objSEOItem"></param>
        /// <param name="objReferences"></param>
        abstract public void GetReferencesTo(SEOItem objSEOItem, List<SEOItem> objReferences);

        #region Render Item to support SEO - (non-script) browsing ( and search engines )

        internal string RenderNonScriptContent()
        {
            // objSaveDocument.Save(string.Format(@"c:\{0}.{1}.html", this.ID, this.FullName));

            // Get template for SEOItem
            string strTemplate
                = Gizmox.WebGUI.Forms.CompanionKit.Engine.Properties.Resources.SEOItemTemplate;

            // Create resulting Item's SEO HTML
            strTemplate = strTemplate.Replace("[%Title%]", this.Title);
            strTemplate = strTemplate.Replace("[%Description%]", this.Description);
            strTemplate = strTemplate.Replace("[%CAT%]", SEORenderCategories());
            strTemplate = strTemplate.Replace("[%SCAT%]", SEORenderSubCategories());
            strTemplate = strTemplate.Replace("[%Path%]", SEORenderItemLocation());
            strTemplate = strTemplate.Replace("[%Elements%]", SEORenderItemElements());
            strTemplate = strTemplate.Replace("[%Resources%]", SEORenderItemResources());

            return strTemplate;

        }

		/// <summary>
		/// Render elements of a lobby items: SEOLobby and SEOFolder if has lobby
		/// </summary>
        private string SEORenderItemElements()
        {
            StringBuilder					strSubTemplate= new StringBuilder();
			IEnumerable<SEOPageElement>		objElements = null;
			SEOLobby						objLobby = null;

			// Get elements for further rendering
            if (this.Type == SEOItemType.Lobby || 
				(this.Type == SEOItemType.Folder && ((SEOFolder)this).HasLobby))
	        {
				objLobby = this as SEOLobby;
				objElements = objLobby.Elements;
	        }

			// Render elements
			if (objElements != null)
			{
				// render elements in each section
				foreach (SEOLobby.Section objSection in objLobby.Sections)
				{
					// Title
					strSubTemplate.AppendFormat("<H3>{0}</H3>", objSection.Title.Replace(Environment.NewLine,"<BR/>"));
					// Pre-Body-Text
					strSubTemplate.AppendFormat("<H4>{0}</H4>", objSection.PreText.Replace(Environment.NewLine,"<BR/>"));
					
					// section elements
					foreach (SEOPageElement objElement in objLobby.GetSectionElements(objSection.ID))
					{
						strSubTemplate.AppendLine("<div style='margin-bottom: 10px'>");
						
						// element's title - is a link to Item/none/hyperlink
						strSubTemplate.AppendLine("<div>");
						string strTitle = objElement.Title;
						switch (objElement.Styling.LinkType)
						{
							case SEOPageElement.Style.ItemLinkType.InnerItem:
								SEOItem objLinked = objElement.GetLinkedItem();
								if (objLinked != null)
								{
									strTitle = string.Format("<a class='seobc' href='{0}'>{1}</a>", objLinked.Link, objElement.Title);
								}
								break;
							case SEOPageElement.Style.ItemLinkType.HyperLink:
								strTitle = string.Format("<a class='seobc' href='{0}'>{1}</a>", objElement.Link, objElement.Title);
								break;
							case SEOPageElement.Style.ItemLinkType.NoLink:
								break;
							default:
								break;
						}						
						strSubTemplate.AppendFormat("<b>{0}</b>", strTitle);
						strSubTemplate.AppendLine("</div>");
	                    
						// element's body
						strSubTemplate.AppendLine("<div style='margin-bottom: 10px'>");
						strSubTemplate.AppendLine(objElement.Body);
						strSubTemplate.AppendLine("</div>");

						strSubTemplate.AppendLine("</div>");	            
					}// element
				}// section
			}

            return strSubTemplate.ToString();
        }

        private string SEORenderItemResources()
        {
            StringBuilder strSubTemplate= new StringBuilder();

            if (this.Type == SEOItemType.Page && this.Status == SEOItemStatus.Publish && this.Resources.Length > 0)
            {
				
				strSubTemplate.AppendLine("<table>");
				strSubTemplate.AppendLine("<colgroup>");
				strSubTemplate.AppendLine("<col width='500'/>");
				strSubTemplate.AppendLine("<col/>");
				strSubTemplate.AppendLine("</colgroup>");
				strSubTemplate.AppendLine("<tbody>");
				
				strSubTemplate.AppendLine("<tr>");
				strSubTemplate.AppendLine("<td>Zip package for C#</td>");
				strSubTemplate.AppendFormat("<td><a class='seobc' href='{0}'>download file</a></td>", this.GetZipLink(LanguageType.CSharp));
				strSubTemplate.AppendLine("</tr>");

				strSubTemplate.AppendLine("<tr>");
				strSubTemplate.AppendLine("<td>Zip package for VB.NET</td>");
				strSubTemplate.AppendFormat("<td><a class='seobc' href='{0}'>download file</a></td>", this.GetZipLink(LanguageType.VBNET));
				strSubTemplate.AppendLine("</tr>");

				foreach (SEOItemResource objResource in this.Resources)
				{
					if (objResource.Visible)
					{
						if (objResource.Visible)
						{
							strSubTemplate.AppendLine("<tr>");
							strSubTemplate.AppendFormat("<td>File name: {0}</td>", objResource.Name);
							strSubTemplate.AppendFormat("<td><a class='seobc' href='{0}'>download file</a></td>", objResource.DownloadURL);
							strSubTemplate.AppendLine("</tr>");
						}
					}
				}
				strSubTemplate.AppendLine("</tbody>");
				strSubTemplate.AppendLine("</table>");

                foreach (SEOItemResource objResource in this.Resources)
                {
                    if (objResource.Visible)
                    {
                        strSubTemplate.AppendLine("<div style='border-style:solid;border-width:1px;'>");
                        strSubTemplate.AppendFormat("<iframe class='ResourceFrame' src='{0}' frameborder='0'>", objResource.ViewURL);
                        strSubTemplate.AppendLine("<p>Download the file by clicking the link above.</p>");
                        strSubTemplate.AppendLine("</iframe>");
                        strSubTemplate.AppendLine("</div>");
                    }
                }
            }
            return strSubTemplate.ToString();
        }

        /// <summary>
        /// Render the categories where the item belongs
        /// </summary>
        /// <param name="objWriter"></param>
        internal virtual string SEORenderCategories()
        {
            StringBuilder strSubTemplate= new StringBuilder();
            strSubTemplate.AppendLine("<ul>");
            foreach (SEOFolder objCategory in SEOSite.Root.Folders)
            {
                if (objCategory.Status == SEOItemStatus.Publish)
                {
                    strSubTemplate.AppendLine("<li>");
                    strSubTemplate.AppendFormat("<a class='seobc' href='{0}'>{1}</a>", objCategory.Link, objCategory.DisplayName);
                    strSubTemplate.AppendLine("</li>");
                }
            }
            strSubTemplate.AppendLine("</ul>");
            return strSubTemplate.ToString();
        }

        internal virtual string SEORenderSubCategories()
        {
            SEOFolder objTheCategory    = this.GetCategory()    as SEOFolder;
            SEOFolder objTheSubCategory = this.GetSubCategory() as SEOFolder;

            StringBuilder strSubTemplate= new StringBuilder();
            StringBuilder objThisCategory = new StringBuilder();
            
            foreach (SEOFolder objSubCategory in objTheCategory.Folders)
            {
                if (objSubCategory.Status == SEOItemStatus.Publish)
                {
                    if (objSubCategory != objTheSubCategory)
                    {
                        strSubTemplate.AppendFormat("<div><a class='seobc' href='{0}'>{1}</a></div>", objSubCategory.Link, objSubCategory.DisplayName);
                    }
                    else
                    {
                        objThisCategory.AppendFormat("<div><a class='seobc' href='{0}'>{1}</a>", objSubCategory.Link, objSubCategory.DisplayName);
                        SEORenderFolder(objThisCategory, objSubCategory as SEOFolder);    
                        objThisCategory.Append("</div>");
                    }
                }
            }
            
            return String.Concat(objThisCategory, strSubTemplate);
        }
        
        internal virtual void SEORenderFolder(StringBuilder strSubTemplate, SEOFolder objFolder)
        {
            if (objFolder != null)
            {
                foreach (SEOItem objItem in objFolder.Items)
                {
                    if (objItem.Status == SEOItemStatus.Publish)
                    {
                        if (!(objItem is SEOFolder))
                        {
                            strSubTemplate.AppendFormat("<div class='indent'><a class='seobc' href='{0}'>{1}</a></div>", objItem.Link, objItem.DisplayName);
                        }
                        else
                        {
                            strSubTemplate.Append("<div class='indent'>");
                            strSubTemplate.AppendFormat("<a class='seobc' href='{0}'>{1}</a>", objItem.Link, objItem.DisplayName);
                            SEORenderFolder(strSubTemplate, objItem as SEOFolder);
                            strSubTemplate.Append("</div>");
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Render the parents of the Item
        /// </summary>
        /// <param name="objWriter"></param>
        internal virtual string SEORenderItemLocation()
        {
            StringBuilder strSubTemplate= new StringBuilder();

            List<SEOItem> objParents = this.GetParents(false);
            
            strSubTemplate.Append("<div  style='padding-bottom:20px'>");
            // Render in reverse order: from Category to the Item's parent
            for (int iIndex = objParents.Count - 1; iIndex >= 0; iIndex--)
            {
                strSubTemplate.AppendLine("<span style='margin-right:10px'>");
                strSubTemplate.AppendFormat("<a class='seobc' href='{0}'>{1}</a>", objParents[iIndex].Link, objParents[iIndex].DisplayName);
                strSubTemplate.AppendLine("</span>");
            }
            strSubTemplate.Append("</div>");
            return strSubTemplate.ToString();
        }

		public virtual string GetHtmlTitleTagContent()
		{
			string Title = "";

			// For example:
			// RowSpan/ColSpan - TableLayoutPanel - Controls | CompanionKit

			SEOItem objCategory = this.GetCategory();
			SEOItem objSubCategory = this.GetSubCategory();

			if (objSubCategory != null && objCategory != null && this != objSubCategory)
			{
				Title = string.Format("{0} - {1} - {2} | CompanionKit", 
					this.DisplayName, 
					objSubCategory.DisplayName, 
					objCategory.DisplayName);
			}
			else if(objCategory != null)
			{
				Title = string.Format("{0} - {1} | CompanionKit", 
					this.DisplayName, 
					objCategory.DisplayName);
			}

			return Title;
		}


        /// <summary>
        /// Collects all parents of the Item excluding the item itself and Root item
        /// Exception: includes itself if no parent available - for root only
        /// </summary>
        /// <param name="blnTopDownDir">
        /// If true - get parents in order from top most(ancient) parent to most closest one. 
        /// From Category to the Item's parent.</param>
        public List<SEOItem> GetParents(bool blnTopDownDir)
        {
            List<SEOItem> objParents = new List<SEOItem>();
            SEOItem parent = this.Parent;
            while (parent != null && parent != SEOSite.Root)
            {
                objParents.Add(parent);
                parent = parent.Parent;
            }
            if (blnTopDownDir)
            {
                objParents.Reverse();
            }
            if (objParents.Count == 0)
            {
                objParents.Add(this);
            }
            return objParents;
        }

        #endregion

        /// <summary>
        /// Writes ZIP package of Item resources to the response
        /// in according to kind of <paramref name="strAction"/>.
        /// </summary>
        /// <param name="objResponse">The response.</param>
        /// <param name="strAction">The action - filter to resources to write.</param>
        internal void Write(HostResponse objResponse, string strAction)
        {
            List<SEOItemResource> objZipped = new List<SEOItemResource>();

            string strLang = string.Empty;

            try
            {
				LanguageType enmType = LanguageType.All;

                switch (strAction.ToLower())
                {
                    case "zipcs":
						enmType = LanguageType.CSharp;
                        strLang = ".csharp";
                        break;
                    case "zipvb":
						enmType = LanguageType.VBNET;
                        strLang = ".vbnet";
                        break;
                }

                    // Loop all resources and filter by action
                    foreach (SEOItemResource objResource in this.Resources)
                    {
						if (	objResource.ResourceInfo.Language == enmType || 
								objResource.ResourceInfo.Language == LanguageType.All)
						{
							objZipped.Add(objResource);
						}
                    }
                    
                    // pick up the files and ZIP to one solid package
                    if (objZipped.Count >0)
                    {
                        MemoryStream objStream = new MemoryStream();
                        ZipOutputStream zipOut  = new ZipOutputStream(objStream);

                        // Loop filtered resources and compress to the stream
                        foreach (SEOItemResource objResource in objZipped)
                        {
                            // if file could not be found, we will ignore it
                            // the Administrator have to run Validation check
                            if (	objResource.Visible &&
									File.Exists(objResource.ResourcePath))
                            {
                                try
                                {
                                    ZipEntry entry = new ZipEntry(objResource.FileName);
                                    FileInfo fi  = new FileInfo(objResource.ResourcePath);
                                    FileStream sReader = File.OpenRead(objResource.ResourcePath);
                                    byte[] buff = new byte[Convert.ToInt32(sReader.Length)];
                                    sReader.Read(buff, 0, (int) sReader.Length);
                                    entry.DateTime = fi.LastWriteTime;
                                    entry.Size = sReader.Length;
                                    sReader.Close();
                                    
                                    zipOut.PutNextEntry(entry);
                                    zipOut.Write(buff, 0, buff.Length);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        zipOut.Finish();
                        
                        // set headers to show download dialog correctly
                        objResponse.ContentType = "application/octet-stream";
                        objResponse.AddHeader("Content-Disposition",
                            string.Format("attachment; filename= {0}", string.Concat(this.Name, strLang, ".zip")));
                        objResponse.AddHeader("Content-Length", objStream.Length.ToString());
                        
                        // write package toresponse stream
                        objStream.Position = 0;
                        objStream.WriteTo(objResponse.OutputStream);

                        // close and dispose allocated resources
                        objStream.Close();
                        objStream.Dispose();
                    }
            }
            catch (Exception)
            {
                throw new HttpException(500,"Unable to process ZIP package.");
            }
        }

		public string GetZipLink(LanguageType enmLanguage)
		{
			return string.Format("{0}{1}.zip.wgx?action={2}", 
					this.RelativePath, this.Name, 
					enmLanguage == LanguageType.CSharp ? "zipcs" : "zipvb");
		}

		public string GetZipLink(string action)
		{
			LanguageType enmLanguage =  action.ToLower() == "zipcs" ? LanguageType.CSharp : LanguageType.VBNET;
			return GetZipLink(enmLanguage);
		}


		/// <summary>
		/// Checks and re-loads the item details considering changes from data file
		/// by checking the last modified time.
		/// </summary>
		internal virtual void LoadUpdates()
		{
			DateTime objLastModified = File.GetLastWriteTime(this.DataFile);

			if (objLastModified > this.LastModified)
			{
				// Get the seo item document
                XmlDocument objDocument = new XmlDocument();
                objDocument.Load(this.DataFile);
				
				// Load updated details
				Load(objDocument.DocumentElement);

				// Cause to reload resources
				lock (mobjResourcesLock)
				{
					mobjResources = null;
				}

				// Update time stamp to avoid loading on-next check
				LastModified = objLastModified;
			}
		}

        /// <summary>
        /// Validates and adding the SEOItem to <paramref name="objFoundItems"/>
        /// in case of the item does not pass, but no more than <paramref name="intMaxResults"/> items.
        /// </summary>
        /// <param name="objFoundItems">The non-valid items already found.</param>
        /// <param name="intMaxResults">The number of maximum results allowed.</param>
		public virtual void Validate(SEOSearchItems objFoundItems, int intMaxResults)
		{
			bool blnNonValid = false;
			string strReason = string.Empty;
			if (objFoundItems != null && objFoundItems.Count < intMaxResults)
			{
				// Loop  all page resources and ensure that Files are available
				foreach (SEOItemResource objSEOItemResource in this.Resources)
				{
					strReason = string.Empty;

					// If is already saved resource
					if (!objSEOItemResource.IsNew)
					{
						switch (objSEOItemResource.ResourceInfo.Type)
						{
							case ResourceType.File:
							case ResourceType.Link:

								blnNonValid |= !File.Exists(objSEOItemResource.ResourcePath);
								strReason = string.Format("Resource file: '{0}' not found.", objSEOItemResource.ResourcePath);
								break;

							default:
								throw new ArgumentException("Unknown resource type that can not be validated.");
						}

						// leave on first non-valid
						if (blnNonValid)
							break;
					}
				}

				// Check that title is not too long
				if (!blnNonValid && this.Title.Length > 76)
				{
					blnNonValid = true;
					strReason = string.Format("Item's title too long, should be less than 76 symbols: '{0}'.", this.Title.Length);
				}

				// check where the keyword contain a non valid symbols
				if (!blnNonValid && string.Concat(this.Keywords).IndexOfAny(new char[] { '.', ',', ';' }) > -1)
				{
					blnNonValid = true;
					strReason = "A keyword contains unallowed symbols: . or , or ;";
				}

			}

			// add the page if not passed the validation
            if (blnNonValid)
            {
                objFoundItems.Add(new SEOSearchItem(this,strReason));
            }
		}

		/// <summary>
		/// Searches for the resource by name [case insensitive]. 0(n).
		/// </summary>
		/// <param name="strResourceName">case insensitive name of the resource</param>
		/// <returns>resource element or Null if not found</returns>
		internal SEOItemResource GetResource(string strResourceName)
		{
			SEOItemResource objResult = null;

            // Loop all resources
            foreach (SEOItemResource objResource in Resources)
            {
                // Check resource matching
                if (objResource.Name.Equals(strResourceName, StringComparison.InvariantCultureIgnoreCase))
                {
                    // Indicate resource was found
                    objResult = objResource;
                    break;
                }
            }
			return objResult;
		}

		public string GetInnerLink()
        {
			return string.Format("item:{0}", this.FullName);
        }
	}
}
