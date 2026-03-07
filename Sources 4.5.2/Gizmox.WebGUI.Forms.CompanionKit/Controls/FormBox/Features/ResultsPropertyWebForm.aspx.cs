using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    public partial class ResultsPropertyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles Click event of the Button control
        /// </summary>
        protected void btnGetResults_Click(object sender, EventArgs e)
        {
            // Check if Result with key needed exists and 
            // set its value to apropriate TextBox

            if (FormBox.Results["Color"] != null)
                tbColor.Text = FormBox.Results["Color"];

            if (FormBox.Results["Size"] != null)
                tbSize.Text = FormBox.Results["Size"];
        }
    }
}
