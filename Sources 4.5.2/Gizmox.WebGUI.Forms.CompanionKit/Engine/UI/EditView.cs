using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EditView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private int mintSEOItem = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditView"/> class.
        /// </summary>
        public EditView()
        {
            InitializeComponent();
            InitializeView();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditView"/> class.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        public EditView(SEOItem objSEOItem)
        {
            InitializeComponent();
            InitializeView();

            // Save the seo item
            mintSEOItem = objSEOItem.ID;

            OnLoad(objSEOItem);
        }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        private void InitializeView()
        {            
            mobjComboStatus.DataSource = Enum.GetValues(typeof(SEOItemStatus));
        }
        
        /// <summary>
        /// Called when load.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        protected virtual void OnLoad(SEOItem objSEOItem)
        {
            // If there is a valid seo item
            if (objSEOItem != null)
            {
                // Set the values
                mobjTextName.Text = objSEOItem.Name;
                mobjTextTitle.Text = objSEOItem.Title;
                mobjTextOrder.Text = objSEOItem.Order.ToString();
                mobjTextDisplayName.Text = objSEOItem.DisplayName;
                mobjComboParent.SelectedNode = objSEOItem.Parent;
                mobjComboStatus.SelectedItem = objSEOItem.Status;
                mobjTextDescription.Text = objSEOItem.Description;
                mobjTextComment.Text = objSEOItem.Comment;
                mobjTextKeywords.Text = string.Join("; ", objSEOItem.Keywords);
                
                // Set the the type parts
                mobjRadioFolder.Checked = objSEOItem.Type == SEOItemType.Folder;
                mobjRadioPage.Checked = objSEOItem.Type == SEOItemType.Page;
                mobjRadioLobby.Checked = objSEOItem.Type ==  SEOItemType.Lobby;
                mobjCheckBoxSiteMap.Checked = objSEOItem.SiteMap;
                mobjCheckBoxSiteMap.Visible = true;
                cmdSiteMapHelp.Visible = mobjCheckBoxSiteMap.Visible;
                
				mobjPanelType.Enabled = false;
            }
            else
            {
                // Set the default state of the type - Page
                mobjRadioFolder.Checked = false;
                mobjRadioPage.Checked = true;
                mobjRadioLobby.Checked = false;
                
                mobjPanelType.Enabled = true;
                mobjTextOrder.Text = "100";
                mobjCheckBoxSiteMap.Checked = true;
            }
        }

        /// <summary>
        /// Handles the save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mobjButtonSave_Click(object sender, EventArgs e)
        {
            // Get the current seo item
            SEOItem objSEOItem = GetSEOItem();

            // Validate the form
            if (ValidateBeforeSave(objSEOItem))
            {
                // If item needs to be created
                if (objSEOItem == null)
                {
                    SEOItemType enmItemType;
                    if (mobjRadioLobby.Checked)
                    {
                        enmItemType = SEOItemType.Lobby;
                    }
                    else if (mobjRadioPage.Checked)
                    {
                        enmItemType = SEOItemType.Page;
                    }
                    else
                    {
                        enmItemType = SEOItemType.Folder;
                    }
                    objSEOItem = CreateSEOItem(mobjTextName.Text ,mobjComboParent.SelectedNode as SEOFolder, enmItemType);
                }

                // If seo item is valid
                if (objSEOItem != null)
                {
                    // Save form elements
                    if (OnSave(objSEOItem))
                    {
                        // Save the SEO item
                        objSEOItem.Save();

                        // Get the owner view
                        NavigationView objOwnerView = GetOwnerView();
                        if (objOwnerView != null)
                        {
                            // Reload the page item
							objOwnerView.Redirect(objSEOItem);
                            objOwnerView.ReloadPageItem();
                        }
                    }
                }
            }
        }


        private void mobjButtonDelete_Click(object sender, EventArgs e)
        {
            // Get the current seo item
            SEOItem objSEOItem = GetSEOItem();

            List<SEOItem> objReferences = new List<SEOItem>();
            SEOSite.Root.GetReferencesTo(objSEOItem, objReferences);

            StringBuilder links = new StringBuilder();
            string strRefMessage = "The item is not referenced.";
            if (objReferences.Count > 0)
            {
                foreach (SEOItem objReference in objReferences)
                    links.AppendLine(objReference.FullName);
                strRefMessage = string.Format("The item referenced from:{0}{1}",
                    Environment.NewLine, links.ToString());
            }

            // Ask confirmation
            MessageBox.Show(
                // text
                string.Format("Please confirm the deletion of: {0}{1}{0}{2}",
                Environment.NewLine, objSEOItem.DisplayName, strRefMessage),
                // caption
                "Confirm delete", 
                // button
                MessageBoxButtons.OKCancel,
                // handler
                (EventHandler)(delegate(object objMessageBox, EventArgs objEvent)
                {
                    if (((Form)objMessageBox).DialogResult == DialogResult.OK)
                    {
                        // Delete the SEO item
                        objSEOItem.Delete();
                        // Get the owner view
                        NavigationView objOwnerView = GetOwnerView();
                        if (objOwnerView != null)
                        {
                            // Reload the page item
                            objOwnerView.ReloadAfterDelete(objSEOItem.Parent);
                        }
                    }
                }
                ));
        }

        /// <summary>
        /// Creates the SEO item.
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objSEOParent">The SEO parent.</param>
        /// <param name="blnIsFolder">if set to <c>true</c> is folder.</param>
        /// <returns></returns>
        protected virtual SEOItem CreateSEOItem(string strName, SEOFolder objSEOParent, SEOItemType enmSEOItemType)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Validates the form before save.
        /// </summary>
        /// <param name="objSEOItem">The SEO item.</param>
        /// <returns></returns>
        protected virtual bool ValidateBeforeSave(SEOItem objSEOItem)
        {
            // Accumulated validity
            bool blnValid = true;
			char[] arrInvalidChars = Path.GetInvalidFileNameChars();
			
			
			// skip check of Title, name, parent when root node edited,
			// The root node should not have a title to be not matched on search
			// parent node of root is itself
			bool blnIsRoot = objSEOItem == SEOSite.Root;

            // Check that the display name is valid
            if (string.IsNullOrEmpty(mobjTextDisplayName.Text) && !blnIsRoot)
            {
                this.Errors.SetError(mobjTextDisplayName, "Display name cannot be empty.");
                blnValid = false;
            }
			else
            {                
                this.Errors.SetError(mobjTextDisplayName, "");
            }

            // Check that the name is valid
            if (string.IsNullOrEmpty(mobjTextName.Text) && !blnIsRoot)
            {
                this.Errors.SetError(mobjTextName, "Name cannot be empty.");
                blnValid = false;
            }
			else if (mobjTextName.Text.IndexOfAny(arrInvalidChars) >0)
			{
                this.Errors.SetError(mobjTextName, 
					string.Format("{0}: {1}",				
					"The Name cannot include the symbols",new String(arrInvalidChars)));
                blnValid = false;
			}
            else
            {
                // If name had not changed
                if (objSEOItem != null && mobjTextName.Text == objSEOItem.Name)
                {
                    this.Errors.SetError(mobjTextName, "");
                }
                else
                {
                    // Check validity with in parent folder
                    SEOFolder objParentSEOFolder = mobjComboParent.SelectedNode as SEOFolder;
                    if (objParentSEOFolder != null)
                    {
                        // Check if name is free
                        if (IsFreeName(objParentSEOFolder, mobjTextName.Text))
                        {
                            this.Errors.SetError(mobjTextName, "");
                        }
                        else
                        {
                            this.Errors.SetError(mobjTextName, string.Format("The name '{0}' is taken.", mobjTextName.Text));
                            blnValid = false;
                        }
                    }
                    else
                    {
                        this.Errors.SetError(mobjTextName, string.Format("The name cannot be checked as there is no valid parent.", mobjTextName.Text));
                    }
                }
            }

            // If there is a valid title
            if (string.IsNullOrEmpty(mobjTextTitle.Text) && !blnIsRoot)
            {
                this.Errors.SetError(mobjTextTitle, "Title cannot be empty.");
                blnValid = false;
            }
            else
            {
                this.Errors.SetError(mobjTextTitle, "");
            }

            // If there is a valid order
            int intOrder = 0;
            if (!int.TryParse(mobjTextOrder.Text, out intOrder))
            {
                this.Errors.SetError(mobjTextOrder, "Order must be an integer.");
                blnValid = false;
            }
            else
            {
                this.Errors.SetError(mobjTextOrder, "");
            }

            // If there is a valid parent
            if (mobjComboParent.SelectedNode == null  && !blnIsRoot)
            {
                this.Errors.SetError(mobjComboParent, "Parent must be selected.");
                blnValid = false;
            }
            else
            {
                this.Errors.SetError(mobjComboParent, "");
            }

            return blnValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objSEOFolder"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        private bool IsFreeName(SEOFolder objSEOFolder, string strName)
        {
            if (objSEOFolder != null)
            {
                return objSEOFolder[strName] == null;
            }
            return false;
        }

        /// <summary>
        /// Called when item is save.
        /// </summary>
        protected virtual bool OnSave(SEOItem objSEOItem)
        {
            if (objSEOItem != null)
            {
                objSEOItem.Title = mobjTextTitle.Text;
                objSEOItem.Order = int.Parse(mobjTextOrder.Text);
                objSEOItem.DisplayName = mobjTextDisplayName.Text;
                objSEOItem.Status = (SEOItemStatus)mobjComboStatus.SelectedItem;
                objSEOItem.Description = mobjTextDescription.Text;
                objSEOItem.Keywords = GetKeywordsArray(mobjTextKeywords.Text);
                objSEOItem.Comment = mobjTextComment.Text;
                objSEOItem.SiteMap = mobjCheckBoxSiteMap.Checked;
            }
            return true;
        }

        private string[] GetKeywordsArray(string strKeywords)
        {
            string[] arrKeywords = strKeywords.Split(';');
            List<string> objKeywords = new List<string>();

            for (int intIndex = 0; intIndex < arrKeywords.Length; intIndex++)
            {
                string strKeyword = arrKeywords[intIndex].Trim();
                if (!string.IsNullOrEmpty(strKeyword))
                {
                    objKeywords.Add(strKeyword);
                }
            }
            return objKeywords.ToArray();
        }

        private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            OnCancel();
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        protected ErrorProvider Errors
        {
            get
            {
                return mobjErrors;
            }
        }

        /// <summary>
        /// Called when editing is canceled.
        /// </summary>
        protected virtual void OnCancel()
        {
            NavigationView objOwnerView = GetOwnerView();
            if (objOwnerView != null)
            {
                objOwnerView.ReloadPageItem();
            }
        }

        /// <summary>
        /// Gets the owner view.
        /// </summary>
        /// <value>The owner view.</value>
        protected NavigationView GetOwnerView()
        {
            Control objCurrent = this;

            // Loop while not null
            while (objCurrent != null)
            {
                // If found navigation view
                if (objCurrent is NavigationView)
                {
                    // Return the navigation view
                    return (NavigationView)objCurrent;
                }

                // Go to the next parent
                objCurrent = objCurrent.Parent;
            }

            return null;

        }

        /// <summary>
        /// Gets the SEO item.
        /// </summary>
        /// <value>The SEO item.</value>
        private SEOItem GetSEOItem()
        {
            if (mintSEOItem != -1)
            {
                return SEOSite.GetItemByID(mintSEOItem);
            }
            return null;
        }

        /// <summary>
        /// Displays general common explanation about properties
        /// </summary>
        /// <remarks>
        /// Exposed to inherited classes
        /// </remarks>
        protected virtual void cmdHelp_Click(object sender, EventArgs e)
        {
            Button objPressed = sender as Button;
            if (objPressed != null && null != (objPressed.Tag as string)) 
            {
                string strKey = objPressed.Tag as string;
                StringBuilder strMessage = new StringBuilder();
                switch (strKey.ToLower())
                {
                    case "name":
                        strMessage.AppendLine("- Provides the Name of UserControl for code snippet");
                        strMessage.AppendLine("- Follow limitations of programming language"); 
                        strMessage.AppendLine("- Don't use spaces and file system forbidden symbols: :/\\[]?^&");
                        strMessage.AppendLine("- Limit the name to 20 symbols to avoid truncating with ...");
                        strMessage.AppendLine("- The Name do not participate in the search");
                        break;
                    case "title":
                        strMessage.AppendLine("- Provides the title for code snippet");
                        strMessage.AppendLine("- The title should be short description of demonstrated issue"); 
                        strMessage.AppendLine("- Limit the title to 120 symbols"); 
                        strMessage.AppendLine("- Participates in the search");
                        break;
                    case "displayname":
                        strMessage.AppendLine("- Provides the short title for code snippet in the tree");
                        strMessage.AppendLine("- DisplayName will be used to order code snippet in the folder"); 
                        strMessage.AppendLine("- Participates in the search");
                        break;
                    case "description":
                        strMessage.AppendLine("- Provides the detailed description of demonstated functionality");
                        strMessage.AppendLine("- of code snippet. The description should be clear to describe and to explain"); 
                        strMessage.AppendLine("- how to work with the snippet and what are the purpose of demonstration"); 
                        strMessage.AppendLine("- Participates in the search");
                        break;
                    case "keywords":
                        strMessage.AppendLine("- Provide keywords separated by ';' like 'word1;word2;word3'");
                        strMessage.AppendLine("- The row will be split and each keyword will be trimmed "); 
                        strMessage.AppendLine("- Search engine matches whole word, case and culture insensitive");
                        strMessage.AppendLine("- Unnecessarily to add the words that are included in the description or title");
                        strMessage.AppendLine("- Best practice is adding of demonstrated property name");
                        strMessage.AppendLine("- Add possible synonyms like 'order', 'ordering' for 'sort' and 'sorting'");
                        break;
                    case "comment":
                        strMessage.AppendLine("- Provides additional information for code snippet author");
                        strMessage.AppendLine("- The comment is not exposed to the end user and not searched");
                        break;
                    case "status":
                        strMessage.AppendLine("- Provides status of readyness of code snippet");
                        strMessage.AppendLine("- Draft - visible only in Admin mode, including search");
                        strMessage.AppendLine("- Publish - production mode");
                        break;
                    case "order":
                        strMessage.AppendLine("- Provides the way to order the snippets in the folder");
                        strMessage.AppendLine("- The Order has most priority");
                        strMessage.AppendLine("- If the Order is same compared by DisplayName");
                        strMessage.AppendLine("- If the DisplayName is also the same then compared by Name");
                        strMessage.AppendLine("- If the DisplayName is empty then compared by Name");
                        break;
                    case "parent":
                        strMessage.AppendLine("- Reference to a folder to place the Item");
                        strMessage.AppendLine("- Could be set and changed ONLY for new Item");
                        break;
                    case "type":
                        strMessage.AppendLine("- The kind of Item defining the general functionality");
                        strMessage.AppendLine("- Could be set and changed only for a new Item");
                        strMessage.AppendLine("- Folder - container of other Items, only Item that could be a parent");
                        strMessage.AppendLine("- Lobby - a page for organizing links and general descriptions to code snippets");
                        strMessage.AppendLine(" includes two kind of elements: HTML and DEMO");
                        strMessage.AppendLine("- Page - a page with UserControl and resources (code pane)");
                        strMessage.AppendLine("- Article - a HTML page with content taken from external resource");
                        break;
                    case "sitemap":
                        strMessage.AppendLine("- Include the Item in sitemap.wgx, for further search engine indexing");
                        break;
                    case "articlecode":
						strMessage.AppendLine("The valid Article KB Code to load or create.");
						strMessage.AppendLine("You are able to change the code, by assigning a new value.");
                        break;
					case "user control height":
                        strMessage.AppendLine("Define the effective height of user control on the Page");
                        strMessage.AppendLine(" - supply positive value in pixels");
                        strMessage.AppendLine(" - leave 0 or empty to apply desing time value");
                        break;
                    default:
                        strMessage.AppendLine("Check the key, help is not provided.");
                        break;
                }
                MessageBox.Show(strMessage.ToString(), strKey, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
