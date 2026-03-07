using System;

using System.Text;
using System.Text.RegularExpressions;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;

using HtmlHelp;
using HtmlHelp.Storage;
using System.Web.UI;
using System.IO;
using System.Web;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.HelpLibrary
{
    //[Serializable()]
    internal class CHMContent : IStaticGateway
    {
        private string[] marrBaseFolder;
        private string mstrBaseFolder = "";




        static CHMContent()
        {


        }

        public CHMContent()
        {

        }


        #region IStaticGateway Members

        public IStaticGatewayHandler GetGatewayHandler(IContext objContext)
        {
            objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            objContext.HostContext.Response.ExpiresAbsolute = DateTime.Now.AddMonths(6);

            try
            {
                if (this.Local.LastIndexOf("/") > -1)
                {
                    mstrBaseFolder = this.Local.Substring(0, this.Local.LastIndexOf("/")).Replace("\\", "/");
                    marrBaseFolder = mstrBaseFolder.Split('/');
                }
                else
                {
                    mstrBaseFolder = "";
                    marrBaseFolder = new string[] { };
                }

                this.Render(objContext.HostContext.Response);

            }
            catch (Exception objException)
            {
                objContext.HostContext.Response.Write("Error:" + objException.Message);
            }

            return null;

        }

        #endregion


        protected void Render(HostResponse objResponse)
        {
            // Define content
            string strContent = null;
            
            // If Controller is valid
            if (this.CHMController != null)
            {
                // Get the content from the help file
                strContent = this.CHMController.ReadFromFile(this.Local);
            }

            // If Content exists
            if (!string.IsNullOrEmpty(strContent))
            {
                // Get an IHelpRevisor Provider
                IHelpRevisor objHelpRevisor = CommonUtils.GetProvider<IHelpRevisor>(null, true, true);

                if (objHelpRevisor != null)
                {
                    // Execute IHelpRevisor.OnHelpRender to modify the content of the CHM file
                    objHelpRevisor.OnHelpRender(this.CHMController.FilePath, ref strContent);
                }

                try
                {
                    Regex objGeneralRegex = new Regex("(?<tag></?[?A-Za-z!][a-zA-Z0-9:]*[^<>]*[\\s]?>)|(?<text>[^<>]*)");
                    Regex objHrefRegex = new Regex("((?<=href[\\s]*=[\\s]*)[^\\n\"'\\s]*(?=[\\s>]))|((?<=href[\\s]*=[\\s]*[\"'])[^\\n\"']*(?=[\"']))", RegexOptions.IgnoreCase);
                    Regex objSrcRegex = new Regex("((?<=src[\\s]*=[\\s]*)[^\\n\"'\\s]*(?=[\\s>]))|((?<=src[\\s]*=[\\s]*[\"'])[^\\n\"']*(?=[\"']))", RegexOptions.IgnoreCase);

                    // Find general match of the content
                    Match objMatch = objGeneralRegex.Match(strContent);
                    
                    // While the match holds, format the value and move to next match 
                    while (objMatch.Success)
                    {
                        // Get value from match
                        string strMatch = objMatch.Value;

                        // Get value from match in lower case
                        string strLowerMatch = strMatch.ToLower();

                        // Define Tags regexes with Whitespaces
                        Regex objARegex = new Regex("<a[\\s]");
                        Regex objImgRegex = new Regex("<img[\\s]");
                        Regex objScriptRegex = new Regex("<script[\\s]");
                        Regex objLinkRegex = new Regex("<link[\\s]");

                        // If tag matchs 'a'
                        if (objARegex.Match(strLowerMatch).Success)
                        {
                            strMatch = objHrefRegex.Replace(strMatch, new MatchEvaluator(ReplaceLink));
                        }

                        // If tag matchs 'img'
                        else if (objImgRegex.Match(strLowerMatch).Success)
                        {
                            strMatch = objSrcRegex.Replace(strMatch, new MatchEvaluator(ReplaceResource));
                        }

                        // If tag matchs 'script'
                        else if (objScriptRegex.Match(strLowerMatch).Success)
                        {
                            strMatch = objSrcRegex.Replace(strMatch, new MatchEvaluator(ReplaceResource));
                        }

                        // If tag matchs 'link'
                        else if (objLinkRegex.Match(strLowerMatch).Success)
                        {
                            strMatch = objHrefRegex.Replace(strMatch, new MatchEvaluator(ReplaceResource));
                        }

                        // Write the formatted value
                        objResponse.Write(strMatch);

                        //Move to next match 
                        objMatch = objMatch.NextMatch();
                    }
                }
                catch (ArgumentException ex)
                {
                    objResponse.Write(ex.Message);
                }
            }

            // If Content does not exist, write empty HTML.
            else
            {
                objResponse.Write("<html></html>");
            }
        }

        private string ReplaceLink(Match objMatch)
        {
            string strValue = objMatch.Value;
            if (strValue.StartsWith("http:") || strValue.StartsWith("ftp:"))
            {
                return strValue;
            }
            string strPath = GetPath(objMatch.Value);

            //test if the path is not encoded
            if (!IsTheTextEncoded(strPath))
            {
                //encode the path
                strPath = HttpUtility.UrlEncode(strPath);
            }
            return string.Format(this.RedirectionTemplate, strPath.Replace("%2f", "/"));
        }

        private string ReplaceResource(Match objMatch)
        {
            string strValue = objMatch.Value;
            if (strValue.StartsWith("http:") || strValue.StartsWith("ftp:"))
            {
                return strValue;
            }
            string strPath = GetPath(objMatch.Value);

            //test if the path is not encoded
            if (!IsTheTextEncoded(strPath))
            {
                //encode the path
                strPath = HttpUtility.UrlEncode(strPath);
            }
            return string.Format(this.ResourceTemplate, strPath.Replace("%2f", "/"));

        }
        /// <summary>
        /// Determines whether the text is encoded.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <returns>
        /// 	<c>true</c> if the text is encoded ; otherwise, <c>false</c>.
        /// </returns>
        private bool IsTheTextEncoded(string strText)
        {
            //decode text
            string strDecodeText = HttpUtility.UrlDecode(strText);

            //test if the decoded text is the same
            return strDecodeText != strText;
        }
        private string GetPath(string strPath)
        {
            return GetPath(strPath, 0);
        }

        private string GetPath(string strPath, int intBack)
        {
            if (strPath.StartsWith("../"))
            {
                return GetPath(strPath.Substring(3), intBack + 1);
            }
            else if (intBack > 0)
            {
                if (marrBaseFolder.Length - intBack > 0)
                {
                    return Path.Combine(string.Join("/", marrBaseFolder, 0, marrBaseFolder.Length - intBack), strPath).Replace("\\", "/");
                }
                else
                {
                    return strPath.Replace("\\", "/");
                }
            }
            else
            {
                return Path.Combine(mstrBaseFolder, strPath).Replace("\\", "/");
            }
        }

        #region CHMController Property

        private CHMExplorerController mobjCHMExplorerController = null;


        private CHMExplorerController CHMController
        {
            get
            {
                if (mobjCHMExplorerController == null)
                {
                    mobjCHMExplorerController = CHMExplorerController.Get(this.CHMReference);
                }
                return mobjCHMExplorerController;
            }
        }

        private string CHMReference
        {
            get
            {
                return HostContext.Current.Request.QueryString["chm"];
            }
        }

        private string Local
        {
            get
            {
                return HostContext.Current.Request.QueryString["src"];
            }
        }



        private string mstrRedirectionTemplate = null;

        private string RedirectionTemplate
        {
            get
            {
                if (mstrRedirectionTemplate == null)
                {
                    mstrRedirectionTemplate = string.Format(CHMExplorerController.RedirectionTemplateRoot + "?chm={0}", this.CHMReference) + "&src={0}";
                }
                return mstrRedirectionTemplate;
            }
        }

        private string mstrResourceTemplate = null;

        private string ResourceTemplate
        {
            get
            {
                if (mstrResourceTemplate == null)
                {
                    mstrResourceTemplate = string.Format(CHMExplorerController.ResourceTemplateRoot + "?chm={0}", this.CHMReference) + "&src={0}";
                }
                return mstrResourceTemplate;
            }
        }


        #endregion


    }
}