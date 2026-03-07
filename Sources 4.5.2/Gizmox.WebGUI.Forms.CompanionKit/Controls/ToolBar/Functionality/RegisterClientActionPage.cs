#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.ToolBar.Functionality
{
    public partial class RegisterClientActionPage : UserControl
    {
        public RegisterClientActionPage()
        {
            InitializeComponent();
            // Register opening action for each ToolBar buttons
            this.toolBarButton1.RegisterClientAction("open", "http://www.visualwebgui.com");
            this.toolBarButton2.RegisterClientAction("open", "http://www.google.com");
            this.toolBarButton3.RegisterClientAction("open", "http://www.microsoft.com");
        }
    }
}