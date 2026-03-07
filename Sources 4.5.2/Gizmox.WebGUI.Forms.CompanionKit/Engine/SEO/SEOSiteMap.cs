using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Gateways;

namespace Gizmox.WebGUI.Forms.SEO
{
    public class SEOSiteMap : HostHttpHandler
    {

        /// <summary>
        /// 
        /// </summary>
        private const string SiteMapNS = "http://www.sitemaps.org/schemas/sitemap/0.9";

		/// <summary>
		/// 
		/// </summary>
		private string mstrFileName  = string.Empty;

		public SEOSiteMap()
		{
		}

		public SEOSiteMap(string strFilename)
		{
			mstrFileName = strFilename;
		}

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
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        public override void ProcessRequest(HostContext objHostContext)
        {
            objHostContext.Response.ContentType = "text/xml";

			if (mstrFileName.ToLower() == "sitemap.xsl")
			{
				objHostContext.Response.Write(
					Gizmox.WebGUI.Forms.CompanionKit.Engine.Properties.Resources.gss );
			}
			else
			{
				string strDomain = SEOUtils.GetDomainValue(objHostContext.Request.Url);
				XmlTextWriter objXmlWriter = new XmlTextWriter(objHostContext.Response.OutputStream, Encoding.UTF8);
				objXmlWriter.Namespaces = true;
				objXmlWriter.WriteProcessingInstruction("xml","version=\"1.0\" encoding=\"UTF-8\"");
				objXmlWriter.WriteProcessingInstruction("xml-stylesheet", @"href=""sitemap.xsl.wgx"" type=""text/xsl""");

				objXmlWriter.WriteStartElement("urlset", SiteMapNS);
	            
				ProcessMapRequest(objXmlWriter, SEOSite.Root, strDomain);
	            
				objXmlWriter.WriteEndElement();
				objXmlWriter.Flush();
			}

            objHostContext.Response.End();
        }

        /// <summary>
        /// Processes the map request.
        /// </summary>
        /// <param name="objXmlWriter">The XML writer.</param>
        /// <param name="objFolder">The folder.</param>
        private void ProcessMapRequest(XmlTextWriter objXmlWriter, SEOFolder objFolder, string strDomain)
        {
            // Loop all pages
            foreach (SEOItem objSubPage in objFolder.PlainItems)
            {
                // Process page 
                ProcessMapRequest(objXmlWriter, objSubPage, strDomain);
            }

            // Loop all sub folders and process them
            foreach (SEOFolder objSubFolder in objFolder.Folders)
            {
                ProcessMapRequest(objXmlWriter, objSubFolder, strDomain);
            }
        }

        /// <summary>
        /// Processes the map request.
        /// </summary>
        /// <param name="objXmlWriter">The XML writer.</param>
        /// <param name="objPage">The page.</param>
        private void ProcessMapRequest(XmlTextWriter objXmlWriter, SEOItem objPage, string strDomain)
        {
            // If page should be in site map and in appropriate status
            if (objPage.SiteMap && objPage.Status == SEOItemStatus.Publish)
            {
                objXmlWriter.WriteStartElement("url", SiteMapNS);
                objXmlWriter.WriteElementString("loc", SiteMapNS, string.Format("{0}{1}", strDomain, objPage.Link));
                objXmlWriter.WriteElementString("lastmod", SiteMapNS, GetFormatedValue(objPage.LastModified));
                objXmlWriter.WriteElementString("changefreq", SiteMapNS, GetFormatedValue(objPage.ChangeFrequency));
                objXmlWriter.WriteElementString("priority", SiteMapNS, GetFormatedValue(objPage.Priority));
                objXmlWriter.WriteEndElement();

                // Loop all resources
                foreach (SEOItemResource objSEOItemResource in objPage.Resources)
                {
                    if (objSEOItemResource.SiteMap)
                    {
                        objXmlWriter.WriteStartElement("url", SiteMapNS);
                        objXmlWriter.WriteElementString("loc", SiteMapNS, string.Format("{0}{1}", strDomain, objSEOItemResource.ViewURL));
                        objXmlWriter.WriteElementString("lastmod", SiteMapNS, GetFormatedValue(objPage.LastModified));
                        objXmlWriter.WriteElementString("changefreq", SiteMapNS, GetFormatedValue(objPage.ChangeFrequency));
                        objXmlWriter.WriteElementString("priority", SiteMapNS, GetFormatedValue(objPage.Priority));
                        objXmlWriter.WriteEndElement();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the formated value.
        /// </summary>
        /// <param name="sEOPagePriority">The seo page priority.</param>
        /// <returns></returns>
        private string GetFormatedValue(SEOPagePriority enmPagePriority)
        {
            switch (enmPagePriority)
            {
                case SEOPagePriority.High:
                    return "1";
                case SEOPagePriority.Low:
                    return "0";
                default:
                    return "0.5";
            }
        }

        /// <summary>
        /// Gets the formated value.
        /// </summary>
        /// <param name="enmChangeFrequency">The change frequency.</param>
        /// <returns></returns>
        private string GetFormatedValue(SEOPageChangeFrequency enmChangeFrequency)
        {
            return enmChangeFrequency.ToString().ToLowerInvariant();
        }

        /// <summary>
        /// Gets the formated value.
        /// </summary>
        /// <param name="objDateTime">The date time.</param>
        /// <returns></returns>
        private string GetFormatedValue(DateTime objDateTime)
        {
            return objDateTime.ToString("yyyy-MM-dd");
        }

        #endregion
    }
}
