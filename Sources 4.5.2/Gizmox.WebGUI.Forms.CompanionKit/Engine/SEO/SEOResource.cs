using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    public class SEOResource : HostHttpHandler
    {
        #region IHttpHandler Members

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
        /// </returns>
        public override bool IsReusable
        {
            get 
            {
                
                return true;
            }
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="objContext">The context.</param>
        public override void ProcessRequest(HostContext objContext)
        {

            // If resource was found
            bool blnResourceFound = false;

            // Get the url parts
            string[] arrUrlParts = GetCurrentUrlParts(objContext);

            // Get the virtual directoy path
            string[] arrVirtualDirPath = GetVirtualPathParts();

            // Get the site root
            SEOItem  objCurrentItem = SEOSite.Root;

            // Loop all url parts excluding the virtual directory path
            for (int intIndex = arrVirtualDirPath.Length; intIndex < arrUrlParts.Length; intIndex++ )
            {
                // Get the name of an Page/Folder/Resource/Zip
                string strItemName = arrUrlParts[intIndex];

                // If current item is a folder
                SEOFolder objCurrentFolder = objCurrentItem as SEOFolder;
                if (objCurrentFolder != null)
                {
                    // Get sub item
                    objCurrentItem = objCurrentFolder[strItemName];
                }
                else if (objCurrentItem != null)
                {
                    // Indicates that the resource was found in a Page
                    blnResourceFound = WriteResource(objContext, objCurrentItem, strItemName);
                }

                // We were unable to retrieve the Item
                if ( objCurrentItem == null && objCurrentFolder != null)
                {
                    // it could be a request for the resource of the Folder
					blnResourceFound = WriteResource(objContext, objCurrentFolder, strItemName);

					// it could be request for ZIP of CS/VB resources
                    string strZipSuffix = ".zip.wgx";
					if (!blnResourceFound && strItemName.ToLower().EndsWith(strZipSuffix))
					{
                        // Get sub item, by removing the suffix
                        if (strItemName.Length > strZipSuffix.Length)
                        {
                            // Get the name before the suffix
                            strItemName = strItemName.Substring(0, strItemName.Length - strZipSuffix.Length);
                            
                            // Try to get Item by name from Last found folder
                            objCurrentItem = objCurrentFolder[strItemName];
                            if (objCurrentItem != null)
                            {
                                // Item's resources found
                                blnResourceFound = true;
                                // Write ZIP of resources to response
                                objCurrentItem.Write(objContext.Response,objContext.Request["action"]);
                            }
                        }
                    }
                }
            }


            // If did not find resource
            if (!blnResourceFound)
            {
                throw new HttpException(404, "Resource cannot be found.");
            }
            
        }

		/// <summary>
		/// Writes the resource.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objCurrentItem">The current item.</param>
		/// <param name="strItemName">Name of the resource.</param>
		/// <returns></returns>
		private bool WriteResource(HostContext objContext, SEOItem objCurrentItem, string strItemName)
		{
			bool blnResourceFound = false;
            
			// If valid file name
            if (strItemName.StartsWith("file.") && strItemName.EndsWith(".wgx"))
            {
                // Get the resource name
                string strResourceName = strItemName.Substring(5,strItemName.Length - 5 - 4);

				SEOItemResource objResource = objCurrentItem.GetResource(strResourceName);
				blnResourceFound = objResource != null;
				if (blnResourceFound)
				{
                    HostRequest objRequest = objContext.Request;
                    objResource.Write(objContext.Response, objRequest["action"], objRequest["lines"]);
				}
            }

			return blnResourceFound;
		}

        /// <summary>
        /// Gets the virtual path parts.
        /// </summary>
        /// <returns></returns>
        private static string[] GetVirtualPathParts()
        {
            string strVirtualDir = HostRuntime.AppDomainAppVirtualPath.Trim('/');
            if (strVirtualDir == "")
            {
                return new string[] { };
            }
            return strVirtualDir.Split('/', '\\');
            
        }

        /// <summary>
        /// Gets the current URL parts.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <returns></returns>
        private static string[] GetCurrentUrlParts(HostContext objContext)
        {
            string strUrl = objContext.Request.RawUrl.ToString().ToLowerInvariant().Trim('/');
            return strUrl.Split('?')[0].Split('/', '\\');
        }

        #endregion
    }
}
