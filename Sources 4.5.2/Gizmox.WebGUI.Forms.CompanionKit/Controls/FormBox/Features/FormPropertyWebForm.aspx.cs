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
    public partial class FormPropertyWebForm : System.Web.UI.Page
    {
        /// <summary>
        /// Handles Load event for Page/Control
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if it is not post back call
            if (!IsPostBack)
            {
                // Set Form to load inside FormBox control
                FormBox1.Form = ddlForm.SelectedValue;
            }
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of ComboBox control
        /// </summary>
        protected void ddlForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set Form to load inside FormBox control
            // using selected value of ComboBox control
            FormBox1.Form = ddlForm.SelectedValue;
        }
    }
}
