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
using Gizmox.WebGUI.Forms.CompanionKit.UI;

#endregion

namespace Gizmox.WebGUI.Forms.SEO
{
    public partial class SEOMainForm : Form
    {

        public SEOMainForm()
        {
            InitializeComponent();
        }

        public SEOMainForm(SEOItem objItem, bool blnIsAdmin)
        {            
            InitializeComponent();
			
			// set title of the main form
			this.Text = "Visual WebGui Developer CompanionKit";

			NavigationView objNavigationView = new NavigationView(objItem, blnIsAdmin);
            objNavigationView.Dock = DockStyle.Fill;
            this.Controls.Add(objNavigationView);
        }
    }
}