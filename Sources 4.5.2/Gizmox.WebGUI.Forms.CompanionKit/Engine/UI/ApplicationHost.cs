using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.CompanionKit.Engine.UI
{
    public class ApplicationHost : UserControl
    {
        private HtmlBox mobjHtmlBox;        

        public ApplicationHost(string strURL)
        {
            mobjHtmlBox = new HtmlBox();
            mobjHtmlBox.Url = strURL;
            mobjHtmlBox.Dock = DockStyle.Fill;

            this.Height = 666;
            this.Controls.Add(mobjHtmlBox);
        }
    }
}
