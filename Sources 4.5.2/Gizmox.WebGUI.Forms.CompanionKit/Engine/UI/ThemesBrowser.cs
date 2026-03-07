#region Using

using System;
using System.Collections.Generic;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ThemesBrowser : UserControl
    {
        private Dictionary<string, ListViewItem> mobjItemsIndexByThemeName;
        private SEODeviceMainForm mobjMainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemesBrowser"/> class.
        /// </summary>
        public ThemesBrowser(SEODeviceMainForm objMainForm)
        {
            this.mobjMainForm = objMainForm;
            this.mobjItemsIndexByThemeName = new Dictionary<string, ListViewItem>();
            InitializeComponent();
            mobjThemesSelectionList.SelectedIndexChanged += mobjThemesSelectionPanel_SelectedIndexChanged;
            mobjThemesSelectionList.ItemClick += mobjThemesSelectionList_ItemClick;
            this.BackColor = this.mobjTitleLabel.BackColor = this.mobjThemesSelectionList.BackColor;
        }

        /// <summary>
        /// Handles the ItemClick event of the mobjThemesSelectionList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjThemesSelectionList_ItemClick(object sender, EventArgs e)
        {
            this.SetVisible(false);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjThemesSelectionPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjThemesSelectionPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjThemesSelectionList.SelectedItem != null)
            {
                ListViewItem selectedItem = mobjThemesSelectionList.SelectedItem;
                VWGContext.Current["CurrentdeviceTheme"] = VWGContext.Current.CurrentTheme = selectedItem.Tag as string;
                SetSelectedThemeButton();
            }

            this.SetVisible(false);
        }

        /// <summary>
        /// Toggles the visibility.
        /// </summary>
        /// <param name="blnVisible">if set to <c>true</c> [BLN visible].</param>
        /// <param name="arrBackgroundControls">The arr background controls.</param>
        public void SetVisible(bool blnVisible)
        {
            this.Visible = blnVisible;
            this.mobjMainForm.LayoutPanel.Visible = !blnVisible;
        }

        /// <summary>
        /// Fills the items.
        /// </summary>
        private void FillItems()
        {
            VWGContext.Current["CurrentdeviceTheme"] = VWGContext.Current.CurrentTheme;
            mobjThemesSelectionList.Items.Clear();

            // Generate button for each device theme
            foreach (string strConfiguredTheme in VWGContext.Current.Config.Themes)
            {
                if (strConfiguredTheme.StartsWith("Device"))
                {
                    string strDisplayName = VWGContext.Current.Config.GetFeatureValue(strConfiguredTheme, strConfiguredTheme);
                    string strImageResourceHandlePath = VWGContext.Current.Config.GetFeatureValue(strConfiguredTheme + "-img", null);

                    if (!string.IsNullOrEmpty(strImageResourceHandlePath) && !string.IsNullOrEmpty(strDisplayName))
                    {
                        ListViewItem objListViewItem = new ListViewItem();
                        objListViewItem.Text = strDisplayName;
                        objListViewItem.Tag = strConfiguredTheme;
                        mobjThemesSelectionList.LargeImageList.Images.Add(new ImageResourceHandle(strImageResourceHandlePath));
                        objListViewItem.ImageIndex = mobjThemesSelectionList.LargeImageList.Images.Count - 1;
                        mobjItemsIndexByThemeName.Add(strConfiguredTheme, objListViewItem);
                        mobjThemesSelectionList.Items.Add(objListViewItem);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the selected theme button.
        /// </summary>
        private void SetSelectedThemeButton()
        {
            string strSelectedTheme = VWGContext.Current["CurrentdeviceTheme"] as string;
            Color objSelectionColor = Color.Transparent;
            ListViewSkin objSkin = SkinFactory.GetSkin(this.mobjThemesSelectionList) as ListViewSkin;
            if (objSkin != null)
            {
                objSelectionColor = objSkin.CellSelectedStyle.BackColor;
            }
            else
            {
                objSelectionColor = Color.FromArgb(188, 196, 196);
            }
            if (!string.IsNullOrEmpty(strSelectedTheme))
            {
                foreach (ListViewItem objButton in mobjItemsIndexByThemeName.Values)
                {
                    bool blnIsSelected = objButton.Tag.ToString() == strSelectedTheme;
                    objButton.BackColor = blnIsSelected ? objSelectionColor : Color.Transparent;
                }
            }
            this.BackColor = this.mobjTitleLabel.BackColor = this.mobjThemesSelectionList.BackColor;
        }

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public void Init()
        {
            FillItems();
            SetSelectedThemeButton();
        }
    }
}