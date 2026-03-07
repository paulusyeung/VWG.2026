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
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    public partial class ArgumentsPropertyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles Click event of Button control
        /// </summary>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            // Create collection that will contain argument values
            NameValueCollection argumentCollection = new NameValueCollection();

            // Add argument values to collection
            argumentCollection.Add("Color", ddlColor.SelectedValue);
            argumentCollection.Add("Size", ddlSize.SelectedValue);

            // Clear collection from all keys and values
            FormBox.Arguments.Clear();
            // Add collection with argument values to pass
            FormBox.Arguments.Add(argumentCollection);

            // Reset Form value of FormBox to reload the form
            FormBox.Form = "ArgumentsPropertyForm";
        }
    }
}
