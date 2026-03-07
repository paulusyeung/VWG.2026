using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ActiveXBox.ApplicationScenario
{
    public partial class ExampleApplicationPage : UserControl
    {
        public ExampleApplicationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl
        /// Set parameters for the demonstrated ActiveXBox
        /// </summary>
        private void ExampleApplicationPage_Load(object sender, EventArgs e)
        {
            // Set parameters for the AciveXBox             
            this.demoActiveXBox.AddParameter("autoStart", "False");
            this.demoActiveXBox.AddParameter("URL", "../../../../../../../Resources/video/Example.wpl");
            this.demoActiveXBox.AddParameter("enabled", "True");
            this.demoActiveXBox.AddParameter("balance", "0");
            this.demoActiveXBox.AddParameter("currentPosition", "0");
            this.demoActiveXBox.AddParameter("enableContextMenu", "True");
            this.demoActiveXBox.AddParameter("fullScreen", "False");
            this.demoActiveXBox.AddParameter("mute", "False");
            this.demoActiveXBox.AddParameter("rate", "1");
            this.demoActiveXBox.AddParameter("stretchToFit", "False");
            this.demoActiveXBox.AddParameter("uiMode", "full");
        }
    }
}