using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RibbonBar.Appearance
{
    public partial class AddingGroupsPage : UserControl
    {
        public AddingGroupsPage()
        {
            InitializeComponent();

			demoRibbonBar.SelectedIndex = 0;
			SelectedIndexChanged(demoRibbonBar, new EventArgs());
        }

		/// <summary>
		/// Handle click on "advanced" anchor
		/// </summary>
		private void AdvancedClicked(object sender, RibbonBarGroupArgs e)
		{
			if (e != null && e.Group != null)
			{
				lblAdvanced.Visible = true;
				lblAdvanced.Text = string.Format("The advanced anchor: {0}", e.Group.Text);
			}
		}

		/// <summary>
		/// Handle RibbonBarPage activation
		/// </summary>
		private void SelectedIndexChanged(object sender, EventArgs e)
		{
			if (demoRibbonBar.SelectedIndex > -1)
			{
				RibbonBarPage objPage = demoRibbonBar.Pages[demoRibbonBar.SelectedIndex];
				if (objPage != null)
				{
					lblStatus.Text = string.Format("The active page: {0}", objPage.Text);
				}
			}
		}
    }
}