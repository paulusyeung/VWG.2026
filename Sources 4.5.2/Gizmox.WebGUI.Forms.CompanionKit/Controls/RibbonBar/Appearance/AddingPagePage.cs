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
    public partial class AddingPagePage : UserControl
    {
        public AddingPagePage()
        {
            InitializeComponent();

			demoRibbonBar.SelectedIndex = 0;
			SelectedIndexChanged(demoRibbonBar, new EventArgs());
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