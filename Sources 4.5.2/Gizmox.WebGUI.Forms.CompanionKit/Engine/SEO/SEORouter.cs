using System;
using System.IO;
using System.Web;
using System.Data;
using System.Configuration;

using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Access;



namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    public class SEORouter : Router
    {
        /// <summary>
        /// Creates the context.
        /// </summary>
        protected override Context CreateContext(HostContext objHostContext)
        {
            return new SEOContext(objHostContext);
        }
    
		protected override HostHttpHandler GetHttpHandler(HostContext objHostContext, Context objContext)
		{
		    // Get the translated path file name
		    string strFileName = Path.GetFileNameWithoutExtension(objHostContext.Request.Url.AbsoluteUri);

		    // If is a site map request
		    if ( strFileName.ToLower().StartsWith("sitemap") )
		    {
		        return new SEOSiteMap(strFileName);
		    }
			else if ( strFileName.ToLower() == "autocomplete" )
			{
				return new AutoComplete();
			}
		    else if (
		        strFileName.StartsWith("file.",StringComparison.InvariantCultureIgnoreCase) ||
		        strFileName.EndsWith(".zip",StringComparison.InvariantCultureIgnoreCase)
		        )
		    {
		        return new SEOResource();
		    }
		    else
		    {
		        return base.GetHttpHandler(objHostContext, objContext);
		    } 
			
		}

	}
}
