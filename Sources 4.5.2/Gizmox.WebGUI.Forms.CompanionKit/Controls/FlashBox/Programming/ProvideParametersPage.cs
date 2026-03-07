using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.IO;
using System.Web;

namespace CompanionKit.Controls.FlashBox.Programming
{
    public partial class ProvideParametersPage : UserControl
    {
        public ProvideParametersPage()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void ProvideParametersPage_Load(object sender, EventArgs e)
        {
            // Set url to flash movie 
            this.demoFlashBox.Movie = "../../../../../../../../../Resources/Flash/FC_2_3_Column3D.swf";

            // Set parameters for FlashBox
            this.demoFlashBox.AddParameter("FlashVars", "&dataURL=../../../../../../../../../Resources/Flash/FC_2_3_DATA.xml");
            this.demoFlashBox.AddParameter("quality", "high");
        }
    }
}