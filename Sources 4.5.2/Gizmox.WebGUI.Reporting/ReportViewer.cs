using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Gizmox.WebGUI.Reporting
{
	/// <summary>
    /// Provides a Visual WebGui callable wrapper for Microsoft.Reporting.WebForms.ReportViewer.
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ReportViewer), "ReportViewer_45.png")]
#else
    [ToolboxBitmap(typeof(ReportViewer), "ReportViewer.png")]
#endif
    public partial class ReportViewer : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
	{
		public ReportViewer()
		{
			InitializeComponent();
		}

#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        // 
        /// <summary>
        /// Creates the host page form control. 
        /// Adding a ScriptManager as Required by ReportViewer 10.0.0.0.
        /// </summary>
        /// <returns></returns>
        protected override HtmlForm CreateHostPageForm()
        {
            // Get Form from base
            HtmlForm objForm = base.CreateHostPageForm();

            // Add the ScriptManager as Required by ReportViewer 10.0.0.0.
            objForm.Controls.Add(new System.Web.UI.ScriptManager());

            objForm.Style.Add(HtmlTextWriterStyle.Width, "100%");
            objForm.Style.Add(HtmlTextWriterStyle.Height, "100%");

            // Return the Form
            return objForm;
        }
#endif

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnHostedPagePreRender(object sender, EventArgs e)
        {
            base.OnHostedPagePreRender(sender, e);

            //Fix issue 5460 - ReportViewer In FF 3.5.3 - does not resize to container size when Dock = Fill
            HtmlHead objHeader = ((System.Web.UI.Page)sender).Header;
            if (objHeader != null)
            {
                ReportViewerTableStyle objStyle = new ReportViewerTableStyle();
                objHeader.StyleSheet.CreateStyleRule(objStyle, null, "table#" + this.HostedControl.ClientID);
            }            
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value>
        /// true if the container enables auto-scrolling; otherwise, false. The default value is true.
        /// </value>
        public override bool AutoScroll
        {
            get
            {
                return false;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class ReportViewerTableStyle : Style
        {
            internal ReportViewerTableStyle()
            {
            }

            /// <summary>
            /// Adds the specified object's style properties to a <see cref="T:System.Web.UI.CssStyleCollection"/> object.
            /// </summary>
            /// <param name="attributes">The <see cref="T:System.Web.UI.CssStyleCollection"/> object to which to add the style properties.</param>
            /// <param name="urlResolver">A <see cref="T:System.Web.UI.IUrlResolutionService"/> -implemented object that contains the context information for the current location (URL).</param>
            protected override void FillStyleAttributes(CssStyleCollection attributes, IUrlResolutionService urlResolver)
            {
                base.FillStyleAttributes(attributes, urlResolver);

                attributes[HtmlTextWriterStyle.Display] = "table !important";
            }
        }
	}
}
