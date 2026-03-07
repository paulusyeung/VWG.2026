using System;
using System.Data;
using System.Configuration;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Access;

namespace Gizmox.WebGUI.Forms.SEO
{
    public class SEOFormFactory : IFormFactory
    {
        #region IFormFactory Members

        /// <summary>
        /// Creates the application main form.
        /// </summary>
        /// <param name="strCurrentItem">The current Page code or Folder related page (folder.wgx)</param>
        /// <param name="arrArguments">The application arguments.</param>
        /// <returns>
        /// A form object that will be the main form of the application.
        /// </returns>
        public IForm CreateForm(string strCurrentItem, params object[] arrArguments)
        {
            // Try to get the SEO page related to this page/folder
            SEOItem objSEOItem = SEOSite.GetItemByFullName(strCurrentItem);
            if (objSEOItem == null)
            {
                // Get the site default page
                objSEOItem = SEOSite.Root.DefaultPage;
            }

            IContext objContext = VWGContext.Current;
            if (objContext != null)
            {
                if (objSEOItem != null)
                {
                    bool blnAdmin = String.Compare(strCurrentItem, "Admin", true) == 0;
                    return objContext.CreateForm<SEOMainForm>(objSEOItem, blnAdmin);
                }
                else
                {
                    return objContext.CreateForm<SEOMainForm>();
                }
            }

            return null;
        }


        #endregion
    }
}
