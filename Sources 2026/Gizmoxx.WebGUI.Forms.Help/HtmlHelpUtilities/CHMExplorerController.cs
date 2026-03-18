using System;
using System.IO;
using System.Web;
using System.Collections;

using HtmlHelp;
using HtmlHelp.Storage;
using HtmlHelp.ChmDecoding;
using System.Data;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.HelpLibrary
{
	/// <summary>
	/// Summary description for CHMExplorerController.
	/// </summary>
	
	internal class CHMExplorerController
	{

		/// <summary>
		/// The HtmlHelpSystem
		/// </summary>
		private HtmlHelpSystem mobjHtmlHelpSystem = null;

		/// <summary>
		/// Holds a hashtable of all items
		/// </summary>
		private Hashtable mobjCHMItemsHash = null;

		/// <summary>
		/// The CHM root
		/// </summary>
		private CHMExplorerNode mobjCHMRootNode = null;

		/// <summary>
		/// The CHM default node
		/// </summary>
		private CHMExplorerNode mobjCHMDefaultNode = null;

        /// <summary>
        /// The CHM default file
        /// </summary>
        private string mstrCHMDefaultLocal = null;

        /// <summary>
        /// The CHM file location
        /// </summary>
        private string mstrCHMFilePath = null;

        /// <summary>
        /// Content resource handle
        /// </summary>
        private static StaticGatewayResourceHandle mobjStaticGatewayContentHandle = null;

        /// <summary>
        /// Root template redirection directory
        /// </summary>
        private static string mstrRedirectionTemplateRoot = null;

        /// <summary>
        /// Resouce resource handle
        /// </summary>
        private static StaticGatewayResourceHandle mobjStaticGatewayResourceHandle = null;

        /// <summary>
        /// Root template resources directory
        /// </summary>
        private static string mstrResourceTemplateRoot = null;

        /// <summary>
        /// Initialize static members
        /// </summary>
        static CHMExplorerController()
        {
            mobjStaticGatewayContentHandle = new StaticGatewayResourceHandle("Gizmox.CHMContent", typeof(CHMContent));

            mstrRedirectionTemplateRoot = mobjStaticGatewayContentHandle.ToString();

            mobjStaticGatewayResourceHandle = new StaticGatewayResourceHandle("Gizmox.CHMResource", typeof(CHMResource));
            mstrResourceTemplateRoot = mobjStaticGatewayResourceHandle.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		public CHMExplorerController()
		{
			mobjCHMItemsHash = new Hashtable();
		}

       

		/// <summary>
		/// Load the CHM
		/// </summary>
		/// <param name="strPath"></param>
		public void Load(string strPath)
		{
			// Get HtmlHelpSystem
			mobjHtmlHelpSystem = new HtmlHelpSystem(strPath);

            // Store the CHM's file location
            mstrCHMFilePath = strPath;

			// Create new root chm node
			mobjCHMRootNode = new CHMExplorerNode(this,null);
			mobjCHMRootNode.Load(mobjHtmlHelpSystem.TableOfContents.TOC);
		}

		/// <summary>
		/// Registers a node
		/// </summary>
		/// <param name="objCHMExplorerNode"></param>
		public void Register(CHMExplorerNode objCHMExplorerNode)
		{
			mobjCHMItemsHash[objCHMExplorerNode.Local] = objCHMExplorerNode;
		}

		/// <summary>
		/// Get node by id
		/// </summary>
		/// <param name="objNodeId"></param>
		/// <returns></returns>
		public CHMExplorerNode GetNode(string strNodeId)
		{
			return mobjCHMItemsHash[strNodeId] as CHMExplorerNode;
		}

		/// <summary>
		/// Gets a safe name
		/// </summary>
		/// <param name="strName"></param>
		/// <returns></returns>
		private string GetSafeName(string strName)
		{
			return strName.Replace(" ","_");
		}

        /// <summary>
        /// Preforms search
        /// </summary>
        /// <param name="strWords"></param>
        /// <param name="intMaxResults"></param>
        /// <param name="blnPartialMatches"></param>
        /// <param name="blnTitleOnly"></param>
        /// <returns></returns>
        public DataTable PerformSearch(string strWords, int intMaxResults, bool blnPartialMatches, bool blnTitleOnly)
        {
            return mobjHtmlHelpSystem.PerformSearch(strWords, intMaxResults, blnPartialMatches, blnTitleOnly);
        }

        /// <summary>
		/// Searches the alinks- or klinks-index for a specific keyword/associative
		/// </summary>
		/// <param name="search">keyword/associative to search</param>
		/// <param name="typeOfIndex">type of index to search</param>
		/// <returns>Returns an ArrayList which contains IndexTopic items or null if nothing was found</returns>
        public IndexItem PerformSingleIndexSearch(string search)
        {
            if (this.HasKLinks || this.HasALinks)
            {
                IndexType typeOfIndex = this.HasKLinks?IndexType.KeywordLinks:IndexType.AssiciativeLinks;
                return mobjHtmlHelpSystem.Index.SearchIndex(search, typeOfIndex);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWildcard"></param>
        /// <param name="enmTypeOfIndex"></param>
        /// <returns></returns>
        public ArrayList PerformIndexSearch(string strWildcard,int intMaxResults)
        {
            ArrayList objIndexs = null;
           
            if(this.HasKLinks)
            {
                objIndexs = mobjHtmlHelpSystem.Index.KLinks;
            }
            else if (this.HasALinks)
            {
                objIndexs = mobjHtmlHelpSystem.Index.ALinks;
            }            

            ArrayList objResults = new ArrayList();

            if (objIndexs != null)
            {
                int intCount = 0;
                string strWildcardLowered = strWildcard.ToLower(System.Globalization.CultureInfo.InvariantCulture);
                foreach (IndexItem objIndexItem in objIndexs)
                {
                    string strKeyWordLowered = objIndexItem.KeyWord.ToLower(System.Globalization.CultureInfo.InvariantCulture);
                    if (strKeyWordLowered.StartsWith(strWildcardLowered))
                    {
                        objResults.Add(objIndexItem);
                        intCount++;
                    }
                    if (intMaxResults <= intCount)
                    {
                        break;
                    }
                }
            }

            return objResults;
        }


        private bool HasKLinks
        {
            get
            {
                return mobjHtmlHelpSystem.HasKLinks;
            }
        }

        private bool HasALinks
        {
            get
            {
                return mobjHtmlHelpSystem.HasALinks;
            }
        }


		/// <summary>
		/// 
		/// </summary>
		public CHMExplorerNode Root
		{
			get
			{
				return mobjCHMRootNode;
			}
		}

        /// <summary>
        /// Get help file location
        /// </summary>
        public string FilePath
        {
            get 
            { 
                return mstrCHMFilePath; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public CHMExplorerNode DefaultNode
		{
			get
			{
				if(mobjCHMDefaultNode==null && mobjHtmlHelpSystem!=null)
				{
					string strDefaultLocal = mobjHtmlHelpSystem.DefaultTopic;
					if(strDefaultLocal!=null && strDefaultLocal.IndexOf("::/")>-1)
					{
                        strDefaultLocal = strDefaultLocal.Substring(strDefaultLocal.IndexOf("::/") + 3).ToLower();
						mobjCHMDefaultNode = this.GetNode(strDefaultLocal);
					}
				}
				return mobjCHMDefaultNode;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public string DefaultLocal
        {
            get
            {
                if (mstrCHMDefaultLocal == null && mobjHtmlHelpSystem != null)
                {
                    string strDefaultLocal = mobjHtmlHelpSystem.DefaultTopic;
                    if (strDefaultLocal != null && strDefaultLocal.IndexOf("::/") > -1)
                    {
                        mstrCHMDefaultLocal = strDefaultLocal.Substring(strDefaultLocal.IndexOf("::/") + 3).ToLower();
                    }
                }
                return mstrCHMDefaultLocal;
            }
        }

		public void WriteResource(HostResponse objResponse,string strLocal)
		{
			mobjHtmlHelpSystem.WriteFile(objResponse,strLocal);
		}

		public string ReadFromFile(string strLocal)
		{
			if(mobjHtmlHelpSystem!=null)
			{
				return mobjHtmlHelpSystem.ReadFromFile(strLocal);
			}
			return null;
		}


        public static string ExtractLocal(string strUrl)
        {
            string strRes = strUrl;
            if (strUrl.IndexOf("::/") > -1)
            {
                strRes = strRes.Substring(strRes.IndexOf("::/") + 3).ToLower();
            }
            return strRes;
        }

        private string mstrWindowName = null;

        public string Title
        {
            get
            {
                if (mstrWindowName == null)
                {
                    if (mobjHtmlHelpSystem.FileList.Length > 0)
                    {
                        mstrWindowName = ((CHMFile)mobjHtmlHelpSystem.FileList[0]).HelpWindowTitle;
                    }
                }
                return mstrWindowName;
            }
        }

        /// <summary>
        /// Provides template for redirection
        /// </summary>
        public static string RedirectionTemplateRoot
        {
            get
            {
                return mstrRedirectionTemplateRoot;
            }
        }

        /// <summary>
        /// Provides template for resources
        /// </summary>
        public static string ResourceTemplateRoot
        {
            get
            {
                return mstrResourceTemplateRoot;
            }
        }

		#region Singleton

		/// <summary>
		/// Hashtable of CHM controllers
		/// </summary>
		private static Hashtable mobjControllers = new Hashtable();

        /// <summary>
        /// Hashtable of CHM controller hashes
        /// </summary>
        private static Hashtable mobjControllerHashes = new Hashtable();

        /// <summary>
        /// The current controller id
        /// </summary>
        private static int mintControllerId = 1;

		/// <summary>
		/// String element to define locking
		/// </summary>
		private static string mstrLock = "lock";


        public static string Create(string strPath,string strStaticHash)
        {
            // Normalize CHM path
            strPath = strPath.ToLower();

            string strHash = (string)mobjControllerHashes[strPath];

            // Get hash from path
            if (strHash == null)
            {
                // Lock controller
                lock (mstrLock)
                {
                    // Check hash is still null
                    strHash = (string)mobjControllerHashes[strPath];
                    if (strHash == null)
                    {
                        try
                        {
                            CHMExplorerController objController = new CHMExplorerController();

                            // Load CHM
                            objController.Load(strPath);

                            // If static hash is defined
                            if (CommonUtils.IsNullOrEmpty(strStaticHash))
                            {
                                // Create controller hash
                                mobjControllerHashes[strPath] = strHash = mintControllerId.ToString();

                                // Create controller and hash it
                                mobjControllers[strHash] = objController;

                                // Increment controller id
                                mintControllerId++;
                            }
                            else
                            {
                                // Create controller hash
                                mobjControllerHashes[strPath] = strStaticHash;

                                // Create controller and hash it
                                mobjControllers[strStaticHash] = objController;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
          
            // Return the controller
            return strHash;
        }
		/// <summary>
		/// 
		/// </summary>
        /// <param name="strHash">The hash of the CHM to explore</param>
		/// <returns>CHMExplorerController singleton instance</returns>
		public static CHMExplorerController Get(string strHash)
		{
            return mobjControllers[strHash] as CHMExplorerController;
		}


		#endregion Singleton

	}
}
