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

namespace CompanionKit.Controls.HtmlBox.Features
{
    public partial class DisplayRawHTMLPage : UserControl
    {
        public DisplayRawHTMLPage()
        {
            InitializeComponent();
            // Set raw HTML content for HTMLBox control
            this.mobjHtmlBox.Html = "<HTML><CENTER><IMG src=\"/Resources/Images/AboutVWGLogo.jpg\" WIDTH=\"382\" HEIGHT=\"100\" ALT=\"VWGLogo\" HSPACE=\"10\" ALIGN=\"middle\"></CENTER><BR><BR><BR>Visual WebGui is a platform for rapid development, simple deployment and easy migration of desktop applications & abilities to the web, enabling secure and responsive desktop-like RIAs (Rich Internet Applications).<BR></HTML>";
        }
    }
}