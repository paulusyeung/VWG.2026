using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Provides support for SEO pages
    /// </summary>
    public class SEOPage : SEOItem
    {
        /// <summary>
        /// The page type
        /// </summary>
        private string mstrPageType = "";

        /// <summary>
        /// 
        /// </summary>
        private SEOPageInspector mobjInspector = null;

        /// <summary>
        /// Initializes a new (not saved yet) instance of the <see cref="SEOPage"/> class.
        /// </summary>
        /// <param name="strFSOFile">The FSO file where the Item will be saved.</param>
        /// <param name="objSEOParent">The SEO parent to place item in the hierarchy</param>
        public SEOPage(string strFSOFile, SEOFolder objSEOParent)
            : base(strFSOFile, objSEOParent)
        {
            this.Type = SEOItemType.Page;
        }
        
        /// <summary>
        /// Initializes a new instance of page, loaded from existing data .seo file
        /// </summary>
        /// <param name="strFSOItem">path to the data file the item loaded from</param>
        /// <param name="objElement">element contains data to load</param>
        /// <param name="objSEOParent">The SEO parent to place item in the hierarchy</param>
        public SEOPage(string strFSOItem, XmlElement objElement, SEOFolder objSEOParent)
            : base(strFSOItem, objElement, objSEOParent)
        {
            this.Type = SEOItemType.Page;
        }

        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Load(XmlElement objSEOItemElement)
        {
            base.Load(objSEOItemElement);

            mstrPageType = SEOUtils.GetValue(objSEOItemElement, "PageType", null);
            mobjInspector = SEOUtils.GetInspectorValue(objSEOItemElement, "Inspector");
			this.UserControlHeight = SEOUtils.GetAttribute(objSEOItemElement, "Height", 0);
        }

        /// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Save(XmlElement objSEOItemElement)
        {
            base.Save(objSEOItemElement);

            SEOUtils.SetValue(objSEOItemElement, "PageType", mstrPageType);
            SEOUtils.SetInspectorValue(objSEOItemElement, "Inspector", mobjInspector);

			if (UserControlHeight > 0)
			{
				SEOUtils.SetAttribute(objSEOItemElement, "Height", this.UserControlHeight);
			}
        }


        /// <summary>
        /// Full qualified Type name (.NET) of user control of code snippet
        /// </summary>
        internal string PageType
        {
            get
            {
                return mstrPageType;
            }
            set
            {
                mstrPageType = value;
            }
        }

		private int mintUserControlHeight = 0;

		/// <summary>
		/// The height of user control displayed on the page.
		/// If differs from 0, than overrides settings of design time
		/// </summary>
		public int UserControlHeight
		{
			get { return mintUserControlHeight; }
			set { mintUserControlHeight = value; }
		}

        /// <summary>
        /// Gets or sets the inspector.
        /// </summary>
        /// <value>The inspector.</value>
        internal SEOPageInspector Inspector
        {
            get { return mobjInspector; }
            set { mobjInspector = value; }
        }

        #region Validate item

        /// <summary>
        /// Validates the page:
        /// 1. Loop all page resources and ensure that Files are available
		/// 2. Check that declared  User control .NET type valid and instantiatable
        /// </summary>
        public override void Validate(SEOSearchItems objFoundItems, int intMaxResults)
        {
			base.Validate(objFoundItems, intMaxResults);
            
			string	strReason	= string.Empty;
			bool	blnNonValid = false;

            if (objFoundItems != null && objFoundItems.Count < intMaxResults)
            {
				// Check that declared .NET User control type is instantiatable
				try
				{
					if (!String.IsNullOrEmpty(this.PageType))
					{
						// Get page type
						Type objType = System.Type.GetType(this.PageType, true);
						blnNonValid |= objType == null;
						if (objType != null)
						{
							// Create the page type and try to instantiate the control
							Control objControl = (Control)Activator.CreateInstance(objType);
							objControl.Dispose();
						}
					}
				}
				catch (Exception)
				{
					blnNonValid = true;
					strReason = string.Format("Unable to instantiate the snippet from: '{0}'", this.PageType);
				}

				// add the page if not passed the validation
                if (blnNonValid)
                {
                    objFoundItems.Add(new SEOSearchItem(this,strReason));
                }
            }
        }

        #endregion

		public override void GetReferencesTo(SEOItem objSEOItem, List<SEOItem> objReferences)
		{
		}

    }
}
