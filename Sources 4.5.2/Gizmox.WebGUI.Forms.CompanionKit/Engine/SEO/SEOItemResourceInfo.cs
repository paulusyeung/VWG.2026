using System;
using System.Xml; // XmlElement
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.SEO
{
	public enum LanguageType
	{
		CSharp,
		VBNET,
		All
	}

	/// <summary>
	/// The preview type - the way resource content shown in the code pane or not shown
	/// </summary>
	public enum ResourceViewType
	{
		[Description("Display message - no preview available")]
		NoView,   // also provide html with message and a link with download

		[Description("Write file content to response as is, Default")]
		Default   // backward compatability
	}

	public enum ResourceType
	{
		/// <summary>
		/// content/code file, that will be uploaded to page folder
		/// </summary>
		File,

		/// <summary>
		/// a KB article in storage
		/// </summary>
		Article,
		
		/// <summary>
		/// content/code file, that is only referenced, not uploaded, not deleted
		/// the responsibility to existance check is completely on user adding the file.
		/// </summary>
		/// <remarks>
		/// It's intended to add files that located outside of page's folder.
		/// It mimics the concept of VS adding existing item by link.
		/// </remarks>
		Link
	}
	
	/// <summary>
    /// Class describes SEOItemResource
    /// visible, included in the sitemap, resource name, order
    /// </summary>
    internal class SEOItemResourceInfo: IComparable<SEOItemResourceInfo>, IComparable
    {

        
		#region  Fields

        /// <summary>
        /// Default value of resource's order when shown to the user in code pane
        /// </summary>
		/// <remarks>
		/// The order is a vertical position of a File/Artilce resource in the code pane.
		/// As less as order then the item will be upper than other item with greater order.
		/// i.e. Item with order 99 will be uppper than Item with order 100.
		/// The order is always: [1-300]
		/// </remarks>
		public  const int   DEFAULT_ORDER       = 100;
		public  const bool  DEFAULT_SITEMAP     = true;
		public  const bool  DEFAULT_VISIBLE     = true;
		public  const string DEFAULT_TITLE       = "Code discussion";
		
        private bool        mblnSiteMap         = DEFAULT_SITEMAP;
		private bool        mblnVisible         = DEFAULT_VISIBLE;
		private int         mintOrder           = DEFAULT_ORDER;
		private string      mstrName            = string.Empty;
        private bool        mblnPageScript      = false;

		private LanguageType	menmLanguage	= LanguageType.All;
		private string			mstrTitle		= string.Empty;
		private ResourceType	menmType		= ResourceType.File;
		private ResourceViewType menmViewType	= ResourceViewType.Default;

		#endregion 

		#region  Constructors

		public SEOItemResourceInfo()
        {
        }

        public SEOItemResourceInfo(bool blnSiteMap, bool blnVisible, string strName, int intOrder, bool blnPageScript)
        {
            mblnSiteMap = blnSiteMap;
            mblnVisible = blnVisible;
            mstrName = strName;
            mintOrder = intOrder;
            mblnPageScript = blnPageScript;
        }
		
		#endregion 

		#region  Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is page sciprt.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is page sciprt; otherwise, <c>false</c>.
        /// </value>
        public bool PageScript
        {
            get
            {
                return mblnPageScript;
            }
            set
            {
                mblnPageScript = value;
            }
        }

		/// <summary>
        /// Gets the resource file name
        /// </summary>
        public string Name
        {
            get { return mstrName;}
        }
		
		/// <summary>
        /// Gets or sets the order of resource when rendered to XML.
        /// Used to cause to see the HTML resources with descriotion as first item loaded.
        /// </summary>
        public int Order
        {
            get { return mintOrder;}
            set { mintOrder = value;}
        }
		
		/// <summary>
        /// Gets or sets a value indicating whether resource will be included in sitemap.
        /// </summary>
        public bool SiteMap
        {
            get { return mblnSiteMap; }
            set { mblnSiteMap = value; }
        }
		
		/// <summary>
        /// Gets or sets a value indicating whether this <see cref="SEOItemResourceInfo"/> is visible.
        /// If not visible will not be shown in resources on the page
        /// </summary>
        public bool Visible
        {
            get { return mblnVisible; }
            set { mblnVisible = value; }
        }

		/// <summary>
		/// The kind of programming language this resource uses or written
		/// </summary>
		public LanguageType Language
		{
			get { return menmLanguage; }
			set { menmLanguage = value; }
		}


		/// <summary>
		/// Gets resource language determined by the name.
		/// Never returns Unknown, as a default returns All.
		/// </summary>
		/// <param name="strName">Name of a resource.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">thrown if strName is null or empty</exception>
		public static LanguageType GetLanguageByName(string strName)
		{

			if (String.IsNullOrEmpty(strName))
			{
				throw new ArgumentException("The resource name could not be empty or null","strName");
			}

			LanguageType enmLang = LanguageType.All;
			switch (System.IO.Path.GetExtension(strName).ToLower())
			{
				case ".vb":
					enmLang = LanguageType.VBNET;
					break;
				case ".cs":
					enmLang = LanguageType.CSharp;
					break;
				default:
					break;
			}
			return enmLang;
		}

		/// <summary>
		/// The text used to describe the resource content
		/// </summary>
		/// <remarks>
		/// The resource name is a default for the resource title. The resource Title should be
		/// used to explicitly change the way the resource presented to target user. For example
		/// description article could be "Code discussion" or "Description"
		/// </remarks>
		public string Title
		{
			get 
			{
				return mstrTitle; 
			}
			set 
			{ 
				mstrTitle = value; 
			}
		}


		/// <summary>
		/// A kind of the resource to determine how to display and open it
		/// </summary>
		public ResourceType Type
		{
			get { return menmType; }
			set { menmType = value; }
		}

		public ResourceViewType ViewType
		{
			get { return menmViewType; }
			set { menmViewType = value; }
		}


		
		#endregion 

		#region  Methods

		public void Load(XmlElement objResourceInfoElement)
        {
            mblnSiteMap = SEOUtils.GetAttribute(objResourceInfoElement, "SiteMap", mblnSiteMap);
            mblnVisible = SEOUtils.GetAttribute(objResourceInfoElement, "Visible", mblnVisible);
            mblnPageScript = SEOUtils.GetAttribute(objResourceInfoElement, "PageScript", mblnPageScript);
            mstrName    = SEOUtils.GetAttribute(objResourceInfoElement, "Name", mstrName);
            mintOrder   = SEOUtils.GetAttribute(objResourceInfoElement, "Order", mintOrder);

			menmLanguage = SEOUtils.GetAttribute<LanguageType>(objResourceInfoElement, "Lang", SEOItemResourceInfo.GetLanguageByName(mstrName));
			mstrTitle	= SEOUtils.GetAttribute(objResourceInfoElement, "Title", string.Empty);
			menmType = SEOUtils.GetAttribute<ResourceType>(objResourceInfoElement, "Type", ResourceType.File);

			menmViewType = SEOUtils.GetAttribute<ResourceViewType>(objResourceInfoElement, "ViewType", ResourceViewType.Default);
        }
		
		public void Save(XmlElement objResourceInfoElement)
        {
            SEOUtils.SetAttribute(objResourceInfoElement, "Visible", mblnVisible);
            SEOUtils.SetAttribute(objResourceInfoElement, "PageScript", mblnPageScript);
            SEOUtils.SetAttribute(objResourceInfoElement, "SiteMap", mblnSiteMap);
            SEOUtils.SetAttribute(objResourceInfoElement, "Name", mstrName);
            SEOUtils.SetAttribute(objResourceInfoElement, "Order", mintOrder);

			SEOUtils.SetAttribute(objResourceInfoElement, "Lang", this.Language.ToString());

			if (this.Title.Length >0)
				SEOUtils.SetAttribute(objResourceInfoElement, "Title", this.Title);
            
			SEOUtils.SetAttribute(objResourceInfoElement, "Type", this.Type.ToString());
			
			if( this.ViewType != ResourceViewType.Default)
				SEOUtils.SetAttribute(objResourceInfoElement, "ViewType", this.ViewType.ToString());
        }

		#endregion 

        #region IComparable<SEOItemResourceInfo> Members
        public int CompareTo(SEOItemResourceInfo objItem)
        {
            // compare by order
            int intCompare = 0;
            if (objItem != null)
            {
                intCompare = this.Order.CompareTo(objItem.Order);
                if (intCompare == 0)
                {
                    intCompare = this.Name.CompareTo(objItem.Name);
                }
            }
            return intCompare;
        }
        #endregion
        #region IComparable Members
        public int CompareTo(object objItem)
        {
            return ((IComparable<SEOItemResourceInfo>)this).CompareTo(objItem as SEOItemResourceInfo);
        }
        #endregion
    }

    /// <summary>
    /// Ordered list of SEOItemResourceInfo with an ability to
    /// retrieve and remove the item by SEOItemResourceInfo.Name
    /// </summary>
    internal class SEOItemResourceInfoCollection : List<SEOItemResourceInfo>
    {
        
		Dictionary<string, SEOItemResourceInfo> mobjResourceInfos = new Dictionary<string,SEOItemResourceInfo>();

		public SEOItemResourceInfo this[string strName]
        {
            get
            {
                return mobjResourceInfos[strName];
            }
        }
		
		public new void Add(SEOItemResourceInfo objInfo)
        {
            // add info object to the end
            base.Add(objInfo);
            // save info object under the key
            mobjResourceInfos[objInfo.Name] = objInfo;
        }
		
		public new void Clear()
        {
            this.Clear();
            mobjResourceInfos.Clear();
        }
		

		internal void RemoveByName(string strName)
        {
            SEOItemResourceInfo objDeleted = this[strName];
            if (objDeleted != null)
            {
                this.Remove(objDeleted); 
                mobjResourceInfos.Remove(strName);
            }

        }
		
    }
}
