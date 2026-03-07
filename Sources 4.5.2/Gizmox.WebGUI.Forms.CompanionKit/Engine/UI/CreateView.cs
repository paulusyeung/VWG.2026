#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;
using System.IO;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class CreateView : EditView
    {
        public CreateView()
        {
            InitializeComponent();

            // Call the empty loading
            OnLoad(null);
        }

        public CreateView(int intCurrentItem)
        {
            InitializeComponent();

            // Call the empty loading
            OnLoad(null);

            SEOItem objCurrentItem = SEOSite.GetItemByID(intCurrentItem);
            SEOFolder objCurrentFolder = objCurrentItem as SEOFolder;

            if (objCurrentFolder != null)
            {
                objCurrentFolder = objCurrentItem as SEOFolder;
            }
            else
            {
                objCurrentFolder = objCurrentItem.Parent;
            }

            // If there is a current selected folder
            if (objCurrentFolder != null)
            {
                // Set the current selected node
                mobjComboParent.SelectedNode = objCurrentFolder;
            }
            
        }

        protected override bool OnSave(SEOItem objSEOItem)
        {
            return base.OnSave(objSEOItem);
        }

        /// <summary>
        /// Creates the SEO item.
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objSEOParent">The SEO parent.</param>
        /// <param name="strSEOItemType"></param>
        /// <returns></returns>
        protected override SEOItem CreateSEOItem(string strName, SEOFolder objSEOParent, SEOItemType enmSEOItemType)
        {
            // Get the seo file name
            string strFileName = string.Format("{0}.seo", strName);

			if (enmSEOItemType == SEOItemType.Folder)
			{
				strFileName = string.Format("{0}\\{1}.seo", strName, "folder");
			}

            // Generate the seo file path
            string strItemPath = Path.Combine(objSEOParent.DataPath, strFileName);

            // Reference to the created item
            SEOItem objCreatedItem = null;

            // Create the seo item
            objCreatedItem = SEOItem.CreateItem(objSEOParent, enmSEOItemType, strItemPath);

            if (enmSEOItemType == SEOItemType.Page)
            {
                SEOPage objSEOPage = objCreatedItem as SEOPage;
                SEOUtils.CreateCodePageResources(objSEOPage);
            }

            return objCreatedItem;
        }
    }
}