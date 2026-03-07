using System;
using System.IO;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections.Specialized;

using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Encapsulates all SEO related information about the current request
    /// </summary>
    public class SEOContext : Context
    {
        /// <summary>
        /// 
        /// </summary>
        private SEOItem mobjCurrentSEOItem = null;

        /// <summary>
        /// 
        /// </summary>
        private bool mblnCurrentSEOItemLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOContext"/> class.
        /// </summary>
        /// <param name="objHttpContext">The Host context.</param>
        public SEOContext(HostContext objHostContext)
            : base(objHostContext)
        {
        }

        /// <summary>
		/// Renders the static content to support SEO and unknown browsers,
		/// to non script tag.
        /// </summary>
        /// <returns></returns>
        protected override string GetApplicationNonScriptContent()
        {
            // Get an Item when started in browser without Javascript
            SEOItem objDefaultItem = this.CurrentSEOItem != null ? this.CurrentSEOItem : SEOSite.Root.DefaultPage;
            
            if (objDefaultItem != null)
            {
                return objDefaultItem.RenderNonScriptContent();
            }
            else
            {
                return base.GetApplicationNonScriptContent();
            }
        }

		/// <summary>
		/// Renders the static content to support SEO and unknown browsers
		/// </summary>
		public override bool RenderStaticSEOContent(HostContext objHostContext)
		{
			objHostContext.Response.Write(GetApplicationNonScriptContent());
			return true;
		}

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <returns></returns>
        protected override string GetApplicationTitle()
        {
            if (this.CurrentSEOItem != null)
            {
                return this.CurrentSEOItem.GetHtmlTitleTagContent();
            }

            return base.GetApplicationTitle();
        }

        /// <summary>
        /// Gets the application metadata tags for a given page.
        /// </summary>
        /// <param name="strPageName">The current page name.</param>
        /// <returns></returns>
        protected override string GetApplicationMetadataTags()
        {
            string strApplicationMetadataTags = base.GetApplicationMetadataTags();

            if (this.CurrentSEOItem != null)
            {
                strApplicationMetadataTags = string.Format(strApplicationMetadataTags, this.CurrentSEOItem.MetaTagsContent);
            }

            return strApplicationMetadataTags;
        }

        /// <summary>
        /// Gets the current SEO item.
        /// </summary>
        /// <value>The current SEO item.</value>
        protected SEOItem CurrentSEOItem
        {
            get 
            {
                // If current seo item was not yet loaded
                if (!mblnCurrentSEOItemLoaded)
                {
                    // Get current seo item
                    mobjCurrentSEOItem = SEOSite.GetItemByFullName(this.CurrentPage);

                    // Mark seo item loaded
                    mblnCurrentSEOItemLoaded = true;
                }

                // Return the seo item if found
                return mobjCurrentSEOItem; 
            }
        }


		/// <summary>
		/// Theme changing related, to ensure the current theme context variable delivered
		/// </summary>
		public override string GetContextVariable(string strVariableName)
		{
			string strContextVariable = base.GetContextVariable(strVariableName);
			if (string.IsNullOrEmpty(strContextVariable))
			{
				switch (strVariableName)
				{
					case "CurrentTheme":
						strContextVariable = this.CurrentTheme;
						break;
				}
			}

			return strContextVariable;
		}
        
    }
}
