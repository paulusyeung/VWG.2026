using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.XamlBox.Programming
{
    public partial class ProvideParametersPage : UserControl
    {
        public ProvideParametersPage()
        {
            InitializeComponent();
        }

        private void ProvideParametersPage_Load(object sender, EventArgs e)
        {
            this.demoXamlBox.Url = "Resources/Xaml/Sample.xaml";

        }
    }
}