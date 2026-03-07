using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens;

using Manoli.Utils.CSharpFormat;

using Gizmox.WebGUI.Forms.CompanionKit.Engine;
using Gizmox.WebGUI.Forms.KB.Engine.Data;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.SEO
{
    public class SEOItemResource
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly SEOItem mobjOwner;


        /// <summary>
        /// 
        /// </summary>
        private int mintID = -1;

        /// <summary>
        /// The path to the newly uploaded file
        /// </summary>
        private string mstrFile = null;

        /// <summary>
        /// The resource info
        /// </summary>
        private readonly SEOItemResourceInfo mobjResourceInfo = null;





        /// <summary>
        /// Initializes a new instance of the <see cref="SEOItemResource"/> class.
        /// </summary>
        /// <param name="objOwner">The owner.</param>
        /// <param name="intID">The ID.</param>
        /// <param name="strName">The name.</param>
        internal SEOItemResource(SEOItem objOwner, int intID, SEOItemResourceInfo objResourceInfo)
        {
            mobjOwner = objOwner;
            mintID = intID;
            mobjResourceInfo = objResourceInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOItemResource"/> class.
        /// </summary>
        /// <param name="objOwner">The owner.</param>
        /// <param name="strFile">The file.</param>
        /// <param name="strName">The resource name.</param>
        internal SEOItemResource(SEOItem objOwner, string strFile, string strName)
        {
            mobjOwner = objOwner;
            mstrFile = strFile;
            mobjResourceInfo = new SEOItemResourceInfo(	SEOItemResourceInfo.DEFAULT_SITEMAP, 
														SEOItemResourceInfo.DEFAULT_VISIBLE, 
														strName, 
														SEOItemResourceInfo.DEFAULT_ORDER,
                                                        false);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        public override string ToString()
        {
            return this.FileName;
        }

        /// <summary>
        /// Gets the ID.
        /// </summary>
        public int ID
        {
            get { return mintID; }
        }

        /// <summary>
        /// Gets the owner ID.
        /// </summary>
        private int OwnerID
        {
            get
            {
                if (mobjOwner != null)
                {
                    return mobjOwner.ID;
                }
                return -1;
            }
        }

        /// <summary>
        /// Gets the owner relative path.
        /// </summary>
        private string OwnerRelativePath
        {
            get
            {
                if (mobjOwner != null)
                {
                    return mobjOwner.RelativePath;
                }
                return "";
            }
        }

        /// <summary>
        /// Gets the name of the owner.
        /// </summary>
        private string OwnerName
        {
            get
            {
                if (mobjOwner != null)
                {
                    return mobjOwner.Name;
                }
                return "";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        internal bool IsNew
        {
            get
            {
                return mintID == -1;
            }
        }

        /// <summary>
        /// Gets the resource info.
        /// </summary>
        internal SEOItemResourceInfo ResourceInfo
        {
            get { return mobjResourceInfo; }
        } 

        /// <summary>
        /// Gets the owner.
        /// </summary>
        public SEOItem Owner
        {
            get { return mobjOwner; }
        }


        /// <summary>
        /// Gets the resource file name
        /// </summary>
        public string Name
        {
            get { return mobjResourceInfo.Name; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether resource will be included in sitemap.
        /// </summary>
        public bool SiteMap
        {
            get
            {
                return mobjResourceInfo.SiteMap;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="SEOItemResource"/> is visible.
        /// </summary>
        public bool Visible
        {
            get
            {
                return mobjResourceInfo.Visible;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="SEOItemResource"/> is order.
        /// </summary>
        public int Order
        {
            get
            {
                return mobjResourceInfo.Order;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [page sciprt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [page sciprt]; otherwise, <c>false</c>.
        /// </value>
        public bool PageScript
        {
            get
            {
                return mobjResourceInfo.PageScript;
            }
        }

        /// <summary>
        /// Gets the download URL.
        /// </summary>
        public string DownloadURL
        {
            get
            {
                return GetResoruceUrl("download");
            }
        }

        /// <summary>
        /// Gets the view URL.
        /// </summary>
        public string ViewURL
        {
            get
            {
                return GetResoruceUrl("view");
            }
        }

        /// <summary>
        /// Gets the formatted view URL.
        /// </summary>
        public string FormattedViewURL
        {
            get
            {
                return GetResoruceUrl("formattedview");
            }
        }

		public string FileName
		{
			get
			{
				string strFilename = this.Name;

				switch (this.ResourceInfo.Type)
				{
					case ResourceType.File:
					case ResourceType.Article:
						break;

					case ResourceType.Link:
						// Get the file name out of relative path to file
						// For example [in]:  Controls\HtmlBox\Features\DisplayRawHTMLPage\DisplayRawHTMLPage.cs
						//            [out]:  DisplayRawHTMLPage.cs
						int intLastSlash = strFilename.LastIndexOf("\\");
						if (intLastSlash > -1)
						{
							strFilename = strFilename.Substring(intLastSlash +1);
						}
						break;
				}

				return strFilename;
			}
		}

		/// <summary>
		/// Gets the string representing Link resource identified by Owner SEOItem and resource name.
		/// If the resource is a Link, then returns this.Name (that is a full qualified link(string) to a resource).
		/// </summary>
		/// <example>
		/// [In, Item]: Controls\HtmlBox\Features\DisplayRawHTMLPage.seo
		/// [In, Resource(this)]: Name="DisplayRawHTMLPage.cs"
		/// [Return]: Controls\HtmlBox\Features\DisplayRawHTMLPage\DisplayRawHTMLPage.cs
		/// </example>
		public string NamedLink
		{
			get
			{
				string strLink = string.Empty;

				switch (this.mobjResourceInfo.Type)
				{
					case ResourceType.File:
					case ResourceType.Article:
						strLink = string.Format("{0}{1}/{2}",
								this.OwnerRelativePath,
								this.OwnerName,
								this.FileName).Replace("/", @"\").TrimStart(new char[]{'\\'});
						break;
					
					case ResourceType.Link:
						// avoid link to link
						strLink = this.Name;
						break;

					default:
						throw new NotImplementedException("Unknown type!");
				}

				return strLink;
			}
		}


        /// <summary>
        /// Gets the resoruce URL including the application folder path
        /// </summary>
        /// <param name="strAction">The action.</param>
		private string GetResoruceUrl(string strAction)
		{
			string strUrl = string.Empty;

			switch (this.ResourceInfo.Type)
			{
				case ResourceType.File:
					
					strUrl = string.Format("{0}{1}{2}/File.{3}.wgx", SEOUtils.GetApplicationPath(), this.OwnerRelativePath, this.OwnerName, this.FileName);

					if (strAction != "view")
					{
						strUrl  = string.Format("{0}?action={1}", strUrl, strAction);
					}
					break;
				
				case ResourceType.Link:

					// Get the path to the file
					// [in]:  Controls\DataGridView\Appearance\AlternatingStylePage\UserDS.Designer.cs
					// [out]:  Controls\DataGridView\Appearance\AlternatingStylePage\File.UserDS.Designer.cs.wgx
					SEOItemResource objLinkedResource = this.GetLinkedResource();
					strUrl = objLinkedResource.GetResoruceUrl(strAction);
					break;
				
				default:
					break;
			}

			return strUrl;
		}

        /// <summary>
		/// Full qualified path to the resource file.
        /// </summary>
		/// <example>
		/// 
		/// File:
		///   in:   '\Controls\Button\Functionality\ClickOncePage.seo' has a resource file 'Description'
		///  out:	d:\My Work\Net2.0\Public\Core\Gizmox.WebGUI.Forms.CompanionKit\Controls\Button\Functionality\Description
		/// 
		/// Link:
		///  in: Controls\DataGridView\Appearance\AlternatingStylePage\UserDS.Designer.cs
		/// out: d:\My Work\Net2.0\Public\Core\Gizmox.WebGUI.Forms.CompanionKit\Controls\DataGridView\Appearance\UserDS.Designer.cs
		/// </example>
        public string ResourcePath
        {
            get
            {
				string strPath = Path.Combine(this.Owner.DataPath, this.Name);

				switch (this.ResourceInfo.Type)
				{
					case ResourceType.File:
					case ResourceType.Article:
						break;
					
					case ResourceType.Link:

						// get SEOItem where the resource resides
						SEOItem objItem = GetLinkedItem();
						if (objItem != null)
							strPath = Path.Combine( objItem.DataPath, this.FileName);

						break;
				}

                return strPath;
            }
        }

		/// <summary>
		/// Gets SEOItem where the resource resides.
		/// Handles the case of Linked resource. 
		/// For linked resource returns the SEOItem where the resource resides.
		/// For non-linked resource returns this.Owner.
		/// </summary>
		public SEOItem GetLinkedItem()
		{
			SEOItem objLinkedItem = null;

			switch (this.ResourceInfo.Type)
			{
				case ResourceType.File:
				case ResourceType.Article:
					objLinkedItem = this.Owner;
					break;

				case ResourceType.Link:

					// the Name of link is Relative path to a file, 
					// but with leading SEOPage or SEOFolder name
					int intLastSlash = this.Name.LastIndexOf('\\');
					if (intLastSlash > -1)
					{
						string strItemName = this.Name.Substring(0, intLastSlash);
						
						// get SEOItem where the resource resides
						objLinkedItem = SEOSite.GetItemByFullName(strItemName.Replace('\\','.').Replace('/','.'));
					}
					break;

				default:
					throw new NotImplementedException("Unsupported resource type");
			}

			return objLinkedItem;
		}

		/// <summary>
		/// Gets the linked resource.
		/// For non-linked resource returns this.
		/// </summary>
		public SEOItemResource GetLinkedResource()
		{
			SEOItemResource objLinkedResource = null;

			switch (this.ResourceInfo.Type)
			{
				case ResourceType.File:
				case ResourceType.Article:
					objLinkedResource = this;
					break;

				case ResourceType.Link:

					SEOItem objItem = GetLinkedItem();
					if (objItem != null)
					{
						string strName = this.FileName;
						foreach (SEOItemResource objResource in objItem.Resources)
						{
							if (string.Compare(objResource.FileName, strName, true) == 0)
							{
								objLinkedResource = objResource;
								break;
							}
						}
					}
					break;

				default:
					throw new NotImplementedException("Unsupported resource type");
			}

			return objLinkedResource;
		}

		/// <summary>
		/// Gets the type of the linked resource.
		/// </summary>
		/// <returns></returns>
		public ResourceType GetLinkedResourceType()
		{
			ResourceType enmType = this.ResourceInfo.Type;
			
			SEOItemResource objResource = GetLinkedResource();
			
			if (objResource != null)
				enmType = objResource.ResourceInfo.Type;

			return enmType;
		}


        /// <summary>
		/// Relative to the root path to the resource file.
        /// </summary>
		/// <example>
		/// 
		/// File:
		///   in:   '\Controls\Button\Functionality\ClickOncePage.seo' has a resource file 'Description'
		///  out:	Controls\Button\Functionality\Description
		/// 
		/// Link:
		///  in: Controls\DataGridView\Appearance\AlternatingStylePage\UserDS.Designer.cs
		/// out: Controls\DataGridView\Appearance\UserDS.Designer.cs
		/// </example>
		public string RelativePath
        {
            get
            {
                if (this.Owner != null)
                {
					string strPath = this.Name;

					if (this.Owner.Type == SEOItemType.Folder)
					{
						// folder resources located in folder itself
						strPath = Path.Combine(Path.Combine(this.Owner.RelativePath, this.Owner.Name), this.Name);
					}
					else if (this.ResourceInfo.Type == ResourceType.Link)
					{
						// linked resources located in other location, so path recalculated
						strPath = this.ResourcePath.Substring( SEOSite.Root.DataPath.Length );
					}
					else
					{
						strPath = Path.Combine(this.Owner.RelativePath, this.Name);
					}
					return strPath;
                }
                else
                {
                    throw new NullReferenceException("Resource owner cannot be null.");
                }
            }
        }


        /// <summary>
        /// Write resource to the response stream
        /// </summary>
        /// <param name="objResponse"></param>
        /// <param name="strFormat"></param>
        internal void Write(HostResponse objResponse, string strFormat, string strHighlightedLines)
        {
             // make it bullet proof :-)
			strFormat = strFormat == null ? "" : strFormat.ToLower();

            // Get highlighted line numbers.
            List<int> arrHighLightedLines = GetHighlightedLines(strHighlightedLines);
			
			if (strFormat != "download" &&
				this.ResourceInfo.ViewType == ResourceViewType.NoView)
			{
				SEOUtils.WriteNoViewer(objResponse, this);
			}
            else if (File.Exists(this.ResourcePath))
            {
                switch (strFormat)
                {                                   
                    case "download":
                        WriteDownload(objResponse);
                        break;

					// view w-ith-o-ut l-ine n-umbers
                    case "viewwoln":
                        WriteView(objResponse, false, true, arrHighLightedLines);
                        break;

                    case "formattedview":
                        WriteView(objResponse, true, true, arrHighLightedLines);
                        break;
                    
                    default:
                        WriteView(objResponse, true, false, arrHighLightedLines);
                        break;
                }
            }
            else
            {
                // There is no additional actions taken, we need always to check the content 
                // with Validate functionality to ensure that files are present
                objResponse.ContentType = "text/html";
                objResponse.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN""><HTML><HEAD><BODY>File not found.</BODY></HTML>");
            }
        }

        /// <summary>
        /// Gets the highlighted lines.
        /// </summary>
        /// <param name="strHighlightedLines">The STR highlighted lines.</param>
        /// <returns></returns>
        private static List<int> GetHighlightedLines(string strHighlightedLines)
        {
            List<int> arrHighlightedLines = null;
            
            if (!string.IsNullOrEmpty(strHighlightedLines))
            {
                // Remove whitespaces
                strHighlightedLines = strHighlightedLines.Replace(" ", "");

                // Split ranges by ,
                string[] arrSplittedRanges = strHighlightedLines.Split(',');

                arrHighlightedLines = new List<int>();

                // Check range
                foreach (string strRange in arrSplittedRanges)
                {
                    int intRangeStart;

                    // If this is actual range
                    if (strRange.Contains("-"))
                    {
                        string strStart, strEnd;
                        int intRangeEnd;

                        // Split it by -
                        string[] arrRangeBoundaries = strRange.Split('-');
                        strStart = arrRangeBoundaries[0];
                        strEnd = arrRangeBoundaries[1];

                        // If valid range boundaries
                        if (!string.IsNullOrEmpty(strStart) && !string.IsNullOrEmpty(strEnd) &&
                            int.TryParse(strStart, out intRangeStart) && int.TryParse(strEnd, out intRangeEnd) &&
                            intRangeStart < intRangeEnd)
                        {
                            // Add range lines to result
                            for (int i = intRangeStart; i <= intRangeEnd; i++)
                            {
                                arrHighlightedLines.Add(i);
                            }
                        }
                    }

                    // If this is a single number
                    else
                    {
                        if (!string.IsNullOrEmpty(strRange) && int.TryParse(strRange, out intRangeStart))
                        {
                            // Add it if valid
                            arrHighlightedLines.Add(intRangeStart);
                        }
                    }
                }
            }
            return arrHighlightedLines;
        }

        /// <summary>
        /// Write resource to response as download.
        /// </summary>
        /// <param name="objResponse">The response.</param>
        private void WriteDownload(HostResponse objResponse)
        {
            objResponse.ContentType = "application/octet-stream";
            objResponse.AddHeader("Content-Disposition",string.Format("attachment; filename= {0}", Path.GetFileName(this.ResourcePath)));
            objResponse.AddHeader("Content-Length", new FileInfo(this.ResourcePath).Length.ToString());
            objResponse.WriteFile(this.ResourcePath);
        }

        /// <summary>
        /// Write resource to response as view.
        /// </summary>
        /// <param name="objResponse">The response.</param>
        private void WriteView(HostResponse objResponse, bool blnWithLineNumbers, bool blnFormatedView, List<int> arrHighlightedLines)
        {
            string strExtension = Path.GetExtension(this.Name);

            if (blnFormatedView)
            {
                SourceFormat objFormatter = null;

                switch (strExtension)
                {
                    case ".vb":
                        objFormatter = new VisualBasicFormat();
                        break;
                    case ".cs":
                    case ".c":
                    case ".cpp":
                    case ".c++":
                    case ".js":
                    case ".css":
                        objFormatter = new CSharpFormat();
                        break;

                    case ".xml":
                    case ".xaml":
                    case ".resx":
                    case ".csproj":
                    case ".vbproj":
                    case ".config":
                    case ".xsl":
                    case ".xslt":
                    case ".aspx":
                    case ".asp":
                    case ".htm":
                    case ".html":
                        objFormatter = new HtmlFormat();
                        break;
                }

                if (objFormatter != null)
                {
                    objFormatter.LineNumbers = blnWithLineNumbers;
                    objFormatter.Alternate = true;
                    objFormatter.EmbedStyleSheet = true;
                    objFormatter.HighlightedLines = arrHighlightedLines;

                    WriteColorizedSyntax(objResponse, objFormatter);
                }
            }
            else
            {
                switch (strExtension)
                {
                    case ".js":
                        objResponse.ContentType = "text/javascript";
                        break;
                   
                    case ".zip":
                        objResponse.ContentType = "application/zip";
                        break;

                    case ".pdf":
                        objResponse.ContentType = "application/pdf";
                        break;

                    case ".gif":
                        objResponse.ContentType = "image/gif";
                        break;

                    case ".png":
                        objResponse.ContentType = "image/png";
                        break;

                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                        objResponse.ContentType = "image/jpeg";
                        break;

                    case ".tiff":
                    case ".tif":
                        objResponse.ContentType = "text/html";
                        break;

                    case ".bmp":
                        objResponse.ContentType = "image/x-ms-bmp";
                        break;

                    case ".rtf":
                        objResponse.ContentType = "application/rtf";
                        break;
                    case ".doc":
                        objResponse.ContentType = "application/msword";
                        break;

                    case ".css":
                        objResponse.ContentType = "text/css";
                        break;

                    case ".txt":
                    case ".pl":
                        objResponse.ContentType = "text/plain";
                        break;
                }

                objResponse.WriteFile(this.ResourcePath);
            }
        }

        private void WriteColorizedSyntax(HostResponse objResponse, SourceFormat objFormatter)
        {
            objResponse.ContentType = "text/html";

            FileStream objCodeStream = null;

            try
            {
                objCodeStream = File.OpenRead(this.ResourcePath);

                string strTemplate = global::Gizmox.WebGUI.Forms.CompanionKit.Engine.Properties.Resources.SEOItemResourceTemplate;
                strTemplate = strTemplate.Replace("[%Body%]",objFormatter.FormatCode(objCodeStream));
                objResponse.Write(strTemplate);
            }
            catch (Exception objException)
            {
                // How to provide custom page to avoid ugly exception
                throw new SEO.SEOException("Unable to display the resource file.", objException);
            }
            finally
            {
                if (objCodeStream != null)
                {
                    objCodeStream.Close();
                }
            }
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        internal void Delete()
        {
            // If not file is new and not a link to other resource
            if (!this.IsNew && 
					this.ResourceInfo.Type != ResourceType.Link &&
					this.ResourceInfo.Type != ResourceType.Article)
            {
                // Get the resource path
                string strResourcePath = this.ResourcePath;
                if (strResourcePath != null)
                {
                    // If file exists delete it
                    if (File.Exists(strResourcePath))
                    {
                        File.Delete(strResourcePath);
                    }
                }
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        internal void CreateAndAdd(List<SEOItemResource> objExistingItems)
        {
            if (this.IsNew)
            {
				if (this.ResourceInfo.Type == ResourceType.File)
				{
					// Copy the file to the resource path                
					File.WriteAllBytes(this.ResourcePath, File.ReadAllBytes(mstrFile));
					// Clear the temp file
					mstrFile = null;
				}

                // New id reference
                int intNewID = 1;

                // Flag indicating if ID is taken
                bool blnFound = false;

                do
                {
                    blnFound = false;

                    // Loop all existing resources
                    foreach (SEOItemResource objExistingItem in objExistingItems)
                    {
                        // If found the id
                        if (intNewID == objExistingItem.ID)
                        {
                            // Increment the id
                            intNewID++;

                            // Mark id as taken
                            blnFound = true;
                            break;
                        }
                    }
                }
                while (blnFound);

                // Set the new id
                mintID = intNewID;

                // Add to existing items
                objExistingItems.Add(this);
            }
        }

        
    }


}
