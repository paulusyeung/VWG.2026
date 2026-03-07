using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

using Gizmox.WebGUI.Forms.CompanionKit.Engine.Properties;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Common.Resources;


using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.CompanionKit.UI;
using System.Collections;
using System.Text.RegularExpressions;


namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    public class SEOUtils
    {
		/// <summary>
		/// The prefix for example code Namespace
		/// </summary>
		public const string CK_NAMESPACE_PREFIX = "CompanionKit";
        
		private static string[] marrCodeExtensions = new string[] {".vb",".cs" };

        private static string mstrAssemblyName = String.Concat("Gizmox.WebGUI.Forms." + CK_NAMESPACE_PREFIX);

		private static string mstrUpdateLock = string.Empty;

        public static string GetValue(XmlElement objElement, string strElement)
        {
            return GetValue(objElement, strElement, string.Empty);
        }

        public static Type GetTypeValue(XmlElement objElement, string strElement)
        {
            string strType = GetValue(objElement, strElement, string.Empty);
            if (!string.IsNullOrEmpty(strType))
            {
                return Type.GetType(strType, false);
            }
            return null;
        }

        public static string GetRawValue(XmlElement objElement, string strElement)
        {
            XmlElement objXmlElement = objElement.SelectSingleNode(strElement) as XmlElement;
            if (objXmlElement != null)
            {
                return objXmlElement.InnerXml;
            }
            return null;
        }

        public static void SetRawValue(XmlElement objElement, string strElement, string strRawValue)
        {
            XmlElement obSubjElement = CreateOrGetElement(objElement, strElement);
            if (obSubjElement != null)
            {
                obSubjElement.InnerXml = strRawValue;
            }
        }

        public static string GetValue(XmlElement objElement, string strElement, string strDefault)
        {
            XmlElement objValueElement = objElement.SelectSingleNode(strElement) as XmlElement;
            if (objValueElement != null)
            {
                return objValueElement.InnerText;
            }
            return strDefault;
        }

        public static string GetAttribute(XmlElement objElement, string strAttribute)
        {
            string strValue = objElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValue))
            {
                return strValue;
            }
            return string.Empty;
        }


        /// <summary>
        /// Gets the attribute string value from objElement. If attribute not exists returns strDefault.
        /// </summary>
        public static string GetAttribute(XmlElement objElement, string strAttribute, string strDefault)
        {
            string strValue = objElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValue))
            {
                return strValue;
            }
            return strDefault;
        }


        /// <summary>
        /// Gets the attribute boolean value from objElement. If attribute not exists returns blnDefault.
        /// </summary>
        public static bool GetAttribute(XmlElement objElement, string strAttribute, bool blnDefault)
        {
            string strValue = objElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValue))
            {
                bool blnValue = false;

                if (bool.TryParse(strValue, out blnValue))
                {
                    return blnValue;
                }
            }
            return blnDefault;
        }

        /// <summary>
        /// Gets the attribute int value from objElement. If attribute not exists returns intDefault.
        /// </summary>
        public static int GetAttribute(XmlElement objElement, string strAttribute, int intDefault)
        {
            string strValue = objElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValue))
            {
                int intValue = 0;

                if (int.TryParse(strValue, out intValue))
                {
                    return intValue;
                }
            }
            return intDefault;
        }

		internal static T GetAttribute<T>(XmlElement objElement, string strAttribute, T enmDefault)
		{
            string strValue = objElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValue))
            {
				return (T)Enum.Parse(typeof(T), strValue);
            }
            return enmDefault;
		}

        internal static SEOProperties GetProperties(XmlElement objElement, string strElement)
        {            
            return new SEOProperties(objElement.SelectNodes(string.Format("{0}", strElement)));
        }

        internal static void SetProperties(XmlElement objElement, string strElement, NameValueCollection objProperties)
        {
            // Get owner document
            XmlDocument objDoccument = objElement.OwnerDocument;
            if (objDoccument != null)
            {
                XmlElement objPropertiesElement = CreateOrGetElement(objElement, strElement);
                if (objPropertiesElement != null && objProperties != null)
                {
                    foreach (string strKey in objProperties.Keys)
                    {
                        XmlElement objPropertyElement = CreateElement(objPropertiesElement, "Property");
                        if (objPropertyElement != null)
                        {
                            SetAttribute(objPropertyElement, "name", strKey);
                            SetAttribute(objPropertyElement, "value", objProperties[strKey]);
                        }
                    }
                }
            }
        }

        internal static XmlElement CreateOrGetElement(XmlElement objParentElement, string strElement)
        {
            XmlElement objElement = objParentElement.SelectSingleNode(strElement) as XmlElement;
            if (objElement == null)
            {
                XmlDocument objDoccument = objParentElement.OwnerDocument;
                if (objDoccument != null)
                {
                    objElement = CreateElement(objParentElement, strElement);
                }
            }
            return objElement;
        }

        private static XmlElement CreateElement(XmlElement objParentElement, string strElement)
        {
            XmlElement objElement = objParentElement.OwnerDocument.CreateElement(strElement);
            objParentElement.AppendChild(objElement);
            return objElement;
        }

        internal static void SetAttribute(XmlElement objElement, string strAttribute, int intValue)
        {
            objElement.SetAttribute(strAttribute, intValue.ToString());
        }

        internal static void SetValue(XmlElement objElement, string strElement, string strValue)
        {
            XmlElement obSubjElement = CreateOrGetElement(objElement, strElement);
            if (obSubjElement != null)
            {
                obSubjElement.InnerText = strValue;
            }
        }

        public static void SetTypeValue(XmlElement objElement, string strElement, Type objType)
        {
            string strType = "";
            if (objType != null)
            {
                strType = objType.FullName;
            }
            SetValue(objElement, strElement, strType);
        }

        public static void SetAttribute(XmlElement objElement, string strAttribute, bool blnSiteMap)
        {
            objElement.SetAttribute(strAttribute, blnSiteMap.ToString());
        }

        public static void SetAttribute(XmlElement objElement, string strAttribute, string strValue)
        {
            objElement.SetAttribute(strAttribute, strValue);
        }

        public static void SetAttribute(XmlElement objElement, string strAttribute, SEOItemStatus enmStatus)
        {
            objElement.SetAttribute(strAttribute, enmStatus.ToString());
        }

        internal static void SetAttribute(XmlElement objElement, string strAttribute, SEOPageInspectorDocking enmDocking)
        {
            objElement.SetAttribute(strAttribute, enmDocking.ToString());
        }


        internal static void SetAttribute(XmlElement objElement, string strAttribute, SEOPageInspectorFieldType enmType)
        {
            objElement.SetAttribute(strAttribute, enmType.ToString());
        }

        public static void SetAttribute(XmlElement objElement, string strAttribute, SEOItemType enmType)
        {
            objElement.SetAttribute(strAttribute, enmType.ToString());
        }
        
		/// <summary>
		/// Delete resources of the Item
		/// </summary>
        internal static void DeleteResources(SEOItem objSEOItem)
        {
			foreach (SEOItemResource objResource in objSEOItem.Resources)
            {
				objResource.Delete();
            }
        }

        internal static void UpdateProject(SEOItem objSEOItem)
        {
			lock (mstrUpdateLock)
			{
				// update all target frameworks project files
				UpdateProject(objSEOItem, "2.0");
				UpdateProject(objSEOItem, "3.5");
				UpdateProject(objSEOItem, "4.0");
			}
        }

		/// <summary>
		/// Updates the project.
		/// </summary>
		internal static void UpdateProject(SEOItem objSEOItem, string strTarget)
		{
			XmlDocument objCSProj = null;
			XmlDocument objVBProj = null;

            string strRootPath = null;
            string strCSProjectPath = null;
            string strVBProjectPath = null;
            
            strRootPath = SEOSite.Root.DataPath;
            strCSProjectPath = Path.Combine(strRootPath, string.Concat("Gizmox.WebGUI.Forms.CompanionKitCS.",strTarget,".csproj"));
            strVBProjectPath = Path.Combine(strRootPath, string.Concat("Gizmox.WebGUI.Forms.CompanionKitVB.",strTarget,".vbproj"));


            objCSProj = new XmlDocument();
            objCSProj.Load(strCSProjectPath);

			objVBProj = new XmlDocument();
            objVBProj.Load(strVBProjectPath);

            UpdateProject(objCSProj, strCSProjectPath, objSEOItem, ".cs");
            UpdateProject(objVBProj, strVBProjectPath,  objSEOItem, ".vb");
		}

        /// <summary>
        /// Updates a given project
        /// </summary>
        /// <param name="strProjectPath"></param>
        /// <param name="objSEOItem"></param>
        /// <param name="strExtension"></param>
        internal static void UpdateProject(XmlDocument objProjectDocument, string strProjectPath, SEOItem objSEOItem, string strExtension)
        {
            XmlNamespaceManager objNSManager = new XmlNamespaceManager(new NameTable());
            objNSManager.AddNamespace("x", objProjectDocument.DocumentElement.NamespaceURI);
            UpdateProject(objProjectDocument, objSEOItem, strExtension, objNSManager);
            objProjectDocument.Save(strProjectPath);
        }

        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="objProjectDocument"></param>
        /// <param name="objSEOItem"></param>
        /// <param name="strExtension"></param>
        /// <param name="objNSManager"></param>
        private static void UpdateProject(XmlDocument objProjectDocument, SEOItem objSEOItem, string strExtension, XmlNamespaceManager objNSManager)
        {
            // If item is deleted
            if (objSEOItem.IsDeleted)
            {
                // Loop and remove all resources
                foreach (SEOItemResource objResource in objSEOItem.Resources)
                {
					// The linked nor Article is not physical files, so should not be
					// inlcuded / excluded from project files
					if (objResource.ResourceInfo.Type != ResourceType.Link &&
						objResource.ResourceInfo.Type != ResourceType.Article)
					{
						XmlElement objProjectItem = GetProjectItem(objProjectDocument, GetProjectItemPath(objResource.RelativePath), objNSManager);
						if (objProjectItem != null)
						{
							objProjectItem.ParentNode.RemoveChild(objProjectItem);
						}
					}
                }

                // Remove seo item
                XmlElement objProjectSEOItem = GetProjectItem(objProjectDocument, GetProjectItemPath(objSEOItem.RelativeDataFile), objNSManager);
                if (objProjectSEOItem != null)
                {
                    objProjectSEOItem.ParentNode.RemoveChild(objProjectSEOItem);
                }
            }
            else
            {
                Dictionary<string, XmlElement> objProjectItems = new Dictionary<string, XmlElement>();

                string strCodeName = string.Format("{0}{1}", objSEOItem.Name, strExtension);
                string strSEOName = string.Empty;

				// in case when resources belong to a Folder, the datafile is folder.seo
				if (objSEOItem.Type == SEOItemType.Folder)
					strSEOName = "folder.seo";
				else
					strSEOName = string.Format("{0}.seo", objSEOItem.Name);

                // Loop all removed resources
                foreach (SEOItemResource objResource in objSEOItem.RemovedResources)
                {
					// The linked nor Article is not physical files, so should not be
					// inlcuded / excluded from project files
					if (objResource.ResourceInfo.Type != ResourceType.Link &&
						objResource.ResourceInfo.Type != ResourceType.Article)
					{
						XmlElement objProjectItem = GetProjectItem(objProjectDocument, GetProjectItemPath(objResource.RelativePath), objNSManager);
						if (objProjectItem != null)
						{
							objProjectItem.ParentNode.RemoveChild(objProjectItem);
						}
					}
                }

				// Empty collection of processed removed resources
				objSEOItem.RemovedResources.Clear();

                // Loop all resources
                foreach (SEOItemResource objResource in objSEOItem.Resources)
                {
					// The linked nor Article is not physical files, so should not be
					// inlcuded / excluded from project files
					if (objResource.ResourceInfo.Type != ResourceType.Link &&
						objResource.ResourceInfo.Type != ResourceType.Article)
					{

						if (IsProjectRelatedResource(objResource, strExtension))
						{
							// Get project item
							XmlElement objProjectItem = GetOrCreateProjectItem(objProjectDocument, GetProjectItemPath(objResource.RelativePath), objNSManager);
							if (objProjectItem != null)
							{
								objProjectItems[objResource.Name] = objProjectItem;
							}
						}
					}
                }

                // Get seo project item
                XmlElement objSEOProjectItem = GetOrCreateProjectItem(objProjectDocument, GetProjectItemPath(objSEOItem.RelativeDataFile), objNSManager);
                if (objSEOProjectItem != null)
                {
                    objProjectItems[strSEOName] = objSEOProjectItem;
                }

                if (objProjectItems.ContainsKey(strCodeName))
                {
                    foreach (KeyValuePair<string, XmlElement> objEntry in objProjectItems)
                    {
                        if (objEntry.Key != strCodeName)
                        {
                            objEntry.Value.InnerXml = string.Format("<DependentUpon>{0}</DependentUpon>", strCodeName);
                        }
                    }
                }
                else if (objProjectItems.ContainsKey(strSEOName))
                {
                    foreach (KeyValuePair<string, XmlElement> objEntry in objProjectItems)
                    {
                        if (objEntry.Key != strSEOName)
                        {
                            objEntry.Value.InnerXml = string.Format("<DependentUpon>{0}</DependentUpon>", strSEOName);
                        }
                    }
                }
            }
        }

        private static bool IsProjectRelatedResource(SEOItemResource objResource, string strExtension)
        {
            bool blnIsCode = false;

            foreach (string strCodeExtension in marrCodeExtensions)
            {
                if (objResource.Name.EndsWith(strCodeExtension))
                {
                    blnIsCode = true;
                    break;
                }
            }

            if (blnIsCode)
            {
                return objResource.Name.EndsWith(strExtension);
            }
            else
            {
                return true;
            }
             
        }

        private static string GetProjectItemPath(string strItemPath)
        {
            if (strItemPath != null)
            {
                strItemPath = strItemPath.Trim('/', '\\').Replace('/', '\\');
            }
            return strItemPath;
        }

        private static XmlElement GetOrCreateProjectItem(XmlDocument objProjectDocument, string strPath, XmlNamespaceManager objNSManager)
        {
            XmlElement objProjectItem = GetProjectItem(objProjectDocument, strPath, objNSManager);
            if (objProjectItem == null)
            {
                string strType = "Content";

                if (strPath.EndsWith(".resx"))
                {
                    strType = "EmbeddedResource";
                }
                else if (strPath.EndsWith(".cs") || strPath.EndsWith(".vb"))
                {
                    strType = "Compile";
                }
                objProjectItem = CreateProjectItem(objProjectDocument, strPath, strType, objNSManager);
            }
            return objProjectItem;
        }

        private static XmlElement CreateProjectItem(XmlDocument objProjectDocument, string strPath, string strType, XmlNamespaceManager objNSManager)
        {
            XmlElement objProjectItem = objProjectDocument.CreateElement(strType, objProjectDocument.DocumentElement.NamespaceURI);
            if (objProjectItem != null)
            {
                
                objProjectItem.SetAttribute("Include", strPath);

                XmlElement objItemGroup = GetProjectItemGroup(objProjectDocument, objNSManager);
                if (objItemGroup != null)
                {
                    objItemGroup.AppendChild(objProjectItem);
                }
            }

            return objProjectItem;
        }

        private static XmlElement GetProjectItem(XmlDocument objProjectDocument, string strPath, XmlNamespaceManager objNSManager)
        {
            return objProjectDocument.SelectSingleNode(string.Format("x:Project/x:ItemGroup/x:*[@Include='{0}']", strPath), objNSManager) as XmlElement;
        }

        private static XmlElement GetProjectItemGroup(XmlDocument objProjectDocument, XmlNamespaceManager objNSManager)
        {
            return objProjectDocument.SelectSingleNode("x:Project/x:ItemGroup", objNSManager) as XmlElement;
        }

        internal static SEOItemResourceInfoCollection GetResourceInfos(XmlElement objElement, string strElement, string strSubElement)
        {
            SEOItemResourceInfoCollection objResourceInfos = new SEOItemResourceInfoCollection();

            foreach(XmlNode objResourceInfoNode in objElement.SelectNodes(string.Format("{0}/{1}", strElement, strSubElement)))
            {
                XmlElement objResourceInfoElement = objResourceInfoNode as XmlElement;
                if(objResourceInfoElement!=null)
                {
                    string strName = objResourceInfoElement.GetAttribute("Name");
                    if(!string.IsNullOrEmpty(strName))
                    {
                        SEOItemResourceInfo objItemResourceInfo = new SEOItemResourceInfo();
                        objItemResourceInfo.Load(objResourceInfoElement);
                        objResourceInfos.Add(objItemResourceInfo);
                    }
                }
            }

            return objResourceInfos;
        }

        /// <summary>
        /// Sets the resource info
        /// </summary>
        /// <param name="objElement"></param>
        /// <param name="strElement"></param>
        /// <param name="objResourceInfos"></param>
        internal static void SetResourceInfos(XmlElement objElement, string strElement, string strSubElement, SEOItemResourceInfoCollection objResourceInfos)
        {
             // Get owner document
            XmlDocument objDoccument = objElement.OwnerDocument;
            if (objDoccument != null)
            {
                // Get the resources element
                XmlElement objResourcesElement = CreateOrGetElement(objElement, strElement);
                if (objResourcesElement != null)
                {
                    // If there are resource infos
                    if (objResourceInfos != null)
                    {
                        // Loop all resources
                        foreach(SEOItemResourceInfo objItemResourceInfo in objResourceInfos)
                        {
                            // Create and add the node with the resource info
                            XmlElement objResourceInfoElement = CreateElement(objResourcesElement, strSubElement);
                            objItemResourceInfo.Save(objResourceInfoElement);
                        }
                    }
                }
            }
        }

        internal static void CreateCodePageResources(SEOPage objSEOPage)
        {
            // Get temporary directory
            string strTempDiretory = Path.Combine(HttpRuntime.CodegenDir, Guid.NewGuid().ToString("D"));

            // Create temporary directory
            Directory.CreateDirectory(strTempDiretory);

            string strNamespace = GetItemNamespace(objSEOPage, false);
            string strClass = objSEOPage.Name;

            if (strNamespace != null)
            {
                // Create page resources 
                CreateCodePageResource(objSEOPage, strTempDiretory, "cs", strNamespace, strClass);
                CreateCodePageResource(objSEOPage, strTempDiretory, "designer.cs", strNamespace, strClass);
                CreateCodePageResource(objSEOPage, strTempDiretory, "vb", strNamespace, strClass);
                CreateCodePageResource(objSEOPage, strTempDiretory, "designer.vb", strNamespace, strClass);
                CreateCodePageResource(objSEOPage, strTempDiretory, "resx", strNamespace, strClass);
            }

            objSEOPage.PageType = string.Format("{0}.{1}, {2}", strNamespace, strClass, mstrAssemblyName);
            
        }

		/// <summary>
		/// Determine the visual order of a resource file in according to the extension
		/// </summary>
		/// <param name="strFileName">File name with extension</param>
		/// <returns>The visual order interger</returns>
		public static int GetResourceOrder(string strFileName)
		{
            string strType = Path.GetExtension(strFileName);
			int intOrder = SEOItemResourceInfo.DEFAULT_ORDER;

            switch (strType)
            {

                case ".cs":
                    intOrder = SEOItemResourceInfo.DEFAULT_ORDER;
					if (strFileName.EndsWith(".designer.cs"))
					{
						intOrder += 1;
					}
                    break;

                case ".vb":
                    intOrder = SEOItemResourceInfo.DEFAULT_ORDER;
					if (strFileName.EndsWith(".designer.vb"))
					{
						intOrder += 1;
					}
                    break;

                case ".resx":
                    intOrder = SEOItemResourceInfo.DEFAULT_ORDER +2;
                    break;

				default:

					intOrder = SEOItemResourceInfo.DEFAULT_ORDER +3;
					break;

			}

			return intOrder;
		}
        
		private static void CreateCodePageResource(SEOPage objSEOPage,string strDirectory,  string strType, string strNamespace, string strClass)
        {
            string strContent = null;
            string strFileExtension = null;

            switch (strType)
            {
                case "cs":
                    strContent = Resources.UserControlCSTemplate;
                    strFileExtension = ".cs";
                    break;
                case "designer.cs":
                    strContent = Resources.UserControlCSDesignerTemplate;
                    strFileExtension = ".designer.cs";
                    break;
                case "resx":
                    strContent = Resources.UserControlResxTemplate;
                    strFileExtension = ".resx";
                    break;
                case "vb":
                    strContent = Resources.UserControlVBTemplate;
                    strFileExtension = ".vb";
                    break;
                case "designer.vb":
                    strContent = Resources.UserControlVBDesignerTemplate;
                    strFileExtension = ".designer.vb";
                    break;
            }

            if (strContent != null)
            {
                string strFileName = string.Format("{0}{1}", strClass, strFileExtension);
                string strFilePath = Path.Combine(strDirectory, strFileName);
                CreateCodePageResource(strFilePath, strContent, strNamespace, strClass);
                SEOItemResource objResource = new SEOItemResource(objSEOPage, strFilePath, strFileName);

				// Set default properties best according to practices as possible
				objResource.ResourceInfo.Order = SEOUtils.GetResourceOrder(strFilePath);
				objResource.ResourceInfo.Language = SEOItemResourceInfo.GetLanguageByName(objResource.Name);
				objResource.ResourceInfo.SiteMap = false;

				objSEOPage.AddResource(objResource);

            }
        }

        private static void CreateCodePageResource(string strFile, string strContent, string strNamespace, string strClass)
        {
            strContent = strContent.Replace("[%class%]", strClass);
            strContent = strContent.Replace("[%namespace%]", strNamespace);

            File.WriteAllText(strFile, strContent);
        }

        /// <summary>
        /// Creates namespace for <paramref name="objSEOItem"/> from the all parent folders.
        /// </summary>
        /// <param name="blnWithAssemblyName">Adds assembly name as prefix.</param>
        /// <returns>
		/// 1. Value newer ends with '.'
		/// </returns>
		public static string GetItemNamespace(SEOItem objSEOItem, bool blnWithAssemblyName)
        {
            string strNamespace = null;

            SEOFolder objFolder = objSEOItem.Parent;

            // While valid folder and not root
            while (objFolder != null && objFolder.Parent!=null)
            {
                if (strNamespace != null)
                {
					strNamespace = string.Format("{0}.{1}", objFolder.Name, strNamespace);
                }
                else
                {
                    strNamespace = objFolder.Name;
                }

                objFolder = objFolder.Parent;
            }

			// add prefix before to ensure uniqueness and avoid conflicts.
            if (strNamespace != null)
            {
				strNamespace = string.Format("{0}.{1}",CK_NAMESPACE_PREFIX, strNamespace);
            }
            else
            {
                strNamespace = CK_NAMESPACE_PREFIX;
            }

			// add assembly name if asked
			if (blnWithAssemblyName)
            {
                strNamespace = string.Format("{0}.{1}", mstrAssemblyName, strNamespace);
            }

            return strNamespace;
        }

        internal static void DeleteSEOFile(SEOItem objSEOItem)
        {
            if (File.Exists(objSEOItem.DataFile))
            {
                File.Delete(objSEOItem.DataFile);
            }
        }

        internal static string[] GetArrayValue(XmlElement objSEOItemElement, string strArrayElement, string strItemElement)
        {
            List<string> objArrayItems = new List<string>();

            XmlNodeList objNodes = objSEOItemElement.SelectNodes(string.Format("{0}/{1}", strArrayElement, strItemElement));   

            foreach(XmlNode objNode in objNodes)
            {
                objArrayItems.Add(objNode.InnerText);
            }

            return objArrayItems.ToArray();
        }

        internal static void SetArrayValue(XmlElement objSEOItemElement, string strArrayElement, string strItemElement, string[] arrValues)
        {
            XmlElement objArrayElement = CreateElement(objSEOItemElement, strArrayElement);
            if (objArrayElement != null)
            {
                foreach (string strValue in arrValues)
                {
                    XmlElement objItemElement = CreateElement(objArrayElement, strItemElement);
                    if (objItemElement != null)
                    {
                        objItemElement.InnerText = strValue;
                    }
                }
            }
        }

        internal static SEOPageInspector GetInspectorValue(XmlElement objSEOItemElement, string strInspectorElement)
        {
            SEOPageInspector objSEOPageInspector = null;

            XmlElement objInspectorElement = objSEOItemElement.SelectSingleNode(strInspectorElement) as XmlElement;
            if (objInspectorElement != null)
            {
                objSEOPageInspector = new SEOPageInspector(objInspectorElement);
            }

            return objSEOPageInspector;
        }

        internal static void SetInspectorValue(XmlElement objSEOItemElement, string strInspectorElement, SEOPageInspector mobjInspector)
        {
            if (mobjInspector != null)
            {
                XmlElement objInspectorElement = CreateElement(objSEOItemElement, strInspectorElement);
                mobjInspector.Save(objInspectorElement);
            }
        }



        internal static SEOPageInspectorField[] GetFields(XmlElement objSEOElement, string strFieldsElement, string strFieldElement)
        {
            List<SEOPageInspectorField> objFields = new List<SEOPageInspectorField>();

            XmlNodeList objFieldNodes = objSEOElement.SelectNodes(string.Format("{0}/{1}", strFieldsElement, strFieldElement));

            foreach (XmlNode objFieldNode in objFieldNodes)
            {
                XmlElement objFieldElement = objFieldNode as XmlElement;
                if (objFieldElement != null)
                {
                    SEOPageInspectorField objField = new SEOPageInspectorField(objFieldElement);
                    objFields.Add(objField);
                }
            }

            return objFields.ToArray();
        }

        internal static void SetFields(XmlElement objSEOElement, string strFieldsElement, string strFieldElement, SEOPageInspectorField[] objFields)
        {
            XmlElement objFieldsElement = CreateElement(objSEOElement, strFieldsElement);
            if (objFieldsElement != null)
            {
                foreach (SEOPageInspectorField objField in objFields)
                {
                    XmlElement objFieldElement = CreateElement(objFieldsElement, strFieldElement);
                    if (objFieldElement != null)
                    {
                        objField.Save(objFieldElement);
                    }
                }
            }
        }

        internal static void SetArrayAttribute(XmlElement objInspectorElement, string strAttribute, int[] arrValues)
        {
            List<string> objStringValues = new List<string>();
            foreach (int objValue in arrValues)
            {
                objStringValues.Add(Convert.ToString(objValue));
            }
            objInspectorElement.SetAttribute(strAttribute, string.Join(",", objStringValues.ToArray()));
        }

        internal static int[] GetArrayAttribute(XmlElement objInspectorElement, string strAttribute, int[] arrDefaultValues)
        {
            string strValues = objInspectorElement.GetAttribute(strAttribute);
            if (!string.IsNullOrEmpty(strValues))
            {
                string[] arrValues = strValues.Split(',');

                List<int> objValues = new List<int>();
                foreach (string strValue in arrValues)
                {
                    int intValue = Convert.ToInt16(strValue);
                    objValues.Add(intValue);
                }

                return objValues.ToArray();
            }
            return arrDefaultValues;
        }

		/// <summary>
		/// Gets the application path.
		/// </summary>
		/// <returns></returns>
		/// <example>
		/// [In]: http://localhost:3883/Main.wgx -> "/"
		/// [In]: http://localhost:3883/CompanionKit/Main.wgx -> "/CompanionKit"
		/// </example>
		public static string GetApplicationPath()
		{
			return HostRuntime.AppDomainAppVirtualPath == "/" ? "" : HttpRuntime.AppDomainAppVirtualPath;
		}

		//internal static void UpdateResources()
		//{
		//    //SEOUtils.UpdateResources();
		//    UpdateResources(SEOSite.Root);
		//}
		//internal static void UpdateResources(SEOFolder folder)
		//{
		//    foreach (SEOFolder subfolder in folder.Folders)
		//    {
		//        UpdateResources(subfolder);
		//    }
		//    foreach (SEOPage page in folder.Pages)
		//    {
		//        foreach (SEOItemResource resource in page.Resources)
		//        {
		//            if (resource.ResourceInfo.Type != ResourceType.Article)
		//            {
		//                resource.ResourceInfo.SiteMap = false;
		//            }
		//            if (resource.ResourceInfo.Type == ResourceType.Article)
		//            {
		//                resource.ResourceInfo.SiteMap = true;
		//            }
		//        }
		//        page.Save();
		//    }
		//}

		/// <summary>
		/// Formats the message of 'No viewer available and writes to response'
		/// </summary>
		internal static void WriteNoViewer(HostResponse objResponse, SEOItemResource objResource)
		{
			string message = Resources.CannotBePreviewed;
			
			message = message.Replace("[%image%]",
				SkinFactory.GetSkinResourcePath(typeof(NavigationViewSkin), "messagebox_info.png"));
			
			message = message.Replace("[%download%]", objResource.DownloadURL);
			
			objResponse.ContentType = "text/html";
			objResponse.Write(message);
		}

		/// <summary>
		/// Gets the unique section ID.
		/// </summary>
		/// <param name="objSections">The sections checked to avoid collision.</param>
		public static string GetUniqueSectionID(List<SEOLobby.Section> objSections)
		{
			SEOLobby.Section	found = null;
			string				strID = string.Empty;
			int					iCounter = 1;

			do
			{
				strID = string.Format("Section-{0:00}", iCounter++);
				found = objSections.Find(delegate(SEOLobby.Section check)
					{
						return check.ID == strID;
					});
			}while(found != null);
			
			return strID;
		}
	
        public static string GetDomainValue(Uri objUrl)
        {
            return string.Format("{0}://{1}{2}", 
				objUrl.Scheme, 
				objUrl.Host, 
				objUrl.Port == 80 ? "" : string.Format(":{0}", objUrl.Port)).Trim('/');
        }

		/// <summary>
		/// Splits the given string to sub-string delimeting by ',' ';' and ' ',
		/// but if the contains a string surrounded with "", then will be taken as one part
		/// </summary>
		/// <param name="strSearch"></param>
		/// <returns></returns>
		public static IEnumerable<string> SplitToWildcards(string strSearch)
		{
			char[]			splitters	= new char[]{',',';',' '};
			Regex			objQuoteEx	= new Regex("\".*?\"");
			List<string>	fragments	= new List<string>();

			// iterate over the string and extract "xxxxx" strings
			do{
				
				Match Phraze = objQuoteEx.Match(strSearch);
				if (!Phraze.Success)
					break;

				fragments.Add(Phraze.Value.TrimStart(new char[]{'"'}).TrimEnd(new char[]{'"'}));

				if (Phraze.Index > 0)
				{
					strSearch =	strSearch.Substring(0, Phraze.Index - 1) +
					            strSearch.Substring(Phraze.Index + Phraze.Length);
				}
				else
				{
					strSearch = strSearch.Substring(Phraze.Length);
				}

			}while(strSearch.Length >0);

			// split rest of the string to frahments
			fragments.AddRange(strSearch.Split(splitters));

			return fragments;
		}
	}
}
