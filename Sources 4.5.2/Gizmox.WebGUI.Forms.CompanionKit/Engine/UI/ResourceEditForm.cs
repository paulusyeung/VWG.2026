using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ResourceEditForm : Form
    {
        private SEOItemResource mobjResource = null;


        public ResourceEditForm() 
        {
            InitializeComponent();
        }

        public ResourceEditForm(SEOItemResource objResource)
        {
            InitializeComponent();
            
            mobjResource = objResource;

            InitializeForm();
        }
        
        protected void InitializeForm()
        {
            mobjTextName.Text	= DialogResource.Name;
            mobjTextID.Text		= DialogResource.ID.ToString();
            mobjTextFile.Text	= DialogResource.RelativePath;
            mobjCmbVisible.DataSource	= new bool[2]{true,false};
            mobjCmbVisible.SelectedItem = DialogResource.ResourceInfo.Visible;
            mobjCmbPageScript.DataSource = new bool[2] { true, false };
            mobjCmbPageScript.SelectedItem = DialogResource.ResourceInfo.PageScript;
            mobjCmbSiteMap.DataSource	= new bool[2]{true,false};
            mobjCmbSiteMap.SelectedItem = DialogResource.ResourceInfo.SiteMap;
            mobjOrderUpDown.Value		= DialogResource.Order;
			mobjTrackOrder.Value		= (int)mobjOrderUpDown.Value;

			mobjTextTitle.Text = DialogResource.ResourceInfo.Title.Length ==0 ? mobjTextName.Text :  DialogResource.ResourceInfo.Title;

			mobjCmbLanguage.DataSource = (LanguageType[])Enum.GetValues(typeof(LanguageType));
			mobjCmbType.DataSource = (ResourceType[])Enum.GetValues(typeof(ResourceType));
			mobjViewType.DataSource = (ResourceViewType[])Enum.GetValues(typeof(ResourceViewType));

			// resource type i.e. File/Artirle/Link could not be changed
			mobjCmbType.Enabled = false;
			// set resource type
			mobjCmbType.SelectedItem = DialogResource.ResourceInfo.Type;

			// set resource language, changeable
			mobjCmbLanguage.SelectedItem = DialogResource.ResourceInfo.Language;
			mobjCmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

			// set resource view type
			mobjViewType.DropDownStyle = ComboBoxStyle.DropDownList;
			mobjViewType.SelectedItem = DialogResource.ResourceInfo.ViewType;
        }
        
        protected void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected void mobjButtonOk_Click(object sender, EventArgs e)
        {
            DialogResource.ResourceInfo.Visible = (bool)mobjCmbVisible.SelectedItem;
            DialogResource.ResourceInfo.PageScript = (bool)mobjCmbPageScript.SelectedItem;
            DialogResource.ResourceInfo.SiteMap = (bool)mobjCmbSiteMap.SelectedItem;
            DialogResource.ResourceInfo.Order = (int)mobjOrderUpDown.Value;

			DialogResource.ResourceInfo.Title = mobjTextTitle.Text != mobjTextName.Text ? mobjTextTitle.Text : string.Empty;
			DialogResource.ResourceInfo.Language = (LanguageType)mobjCmbLanguage.SelectedValue;
			DialogResource.ResourceInfo.Type = (ResourceType)mobjCmbType.SelectedValue;
			DialogResource.ResourceInfo.ViewType = (ResourceViewType)mobjViewType.SelectedValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Gets the dialog field.
        /// </summary>
        /// <value>The dialog field.</value>
        public SEOItemResource DialogResource
        {
            get { return mobjResource; }
        }

		#region Bi-directional update of updown and Track of order
		
		private void mobjOrderUpDown_ValueChanged(object sender, EventArgs e)
		{
			mobjTrackOrder.Value = (int)mobjOrderUpDown.Value;
		}

		private void mobjTrackOrder_ValueChanged(object sender, EventArgs e)
		{
			mobjOrderUpDown.Value = mobjTrackOrder.Value;
		} 
		
		#endregion
    }
}
