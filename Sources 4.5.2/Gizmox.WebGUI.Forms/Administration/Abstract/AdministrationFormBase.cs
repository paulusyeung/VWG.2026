using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal abstract partial class AdministrationFormBase : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationFormBase"/> class.
        /// </summary>
        public AdministrationFormBase()
        {
            ContentChangeNotifierUserControl objContent = GetContent();

            if (objContent != null)
            {
                objContent.Dock = DockStyle.Fill;
                this.Controls.Add(objContent);

                InitializeComponent();

                objContent.ContentChanged += objContent_ContentChanged;
                objContent.Load += objContent_Load;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Handles the Load event of the objContent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void objContent_Load(object sender, EventArgs e)
        {
            UpdateContent(sender as ContentChangeNotifierUserControl);

            //If there is a "hosted" parameter in the querystring and it is equals to "1", than hide the header and footer panels (good for when application is hosted in an iframe)
            if (Context.Arguments["hosted"] != null && Context.Arguments["hosted"] == "1")
            {
                HidePanels();
            }
        }

        /// <summary>
        /// Hide the header and footer panels
        /// </summary>
        protected void HidePanels()
        {
            mobjFooterPanel.Visible = false;
            mobjTopPanel.Visible = false;
        }


        /// <summary>
        /// Objects the content_ content changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void objContent_ContentChanged(object sender, EventArgs e)
        {
            UpdateContent(sender as ContentChangeNotifierUserControl);
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="objControl">The object control.</param>
        private void UpdateContent(ContentChangeNotifierUserControl objControl)
        {
            string strHeaderText = string.Empty;
            List<StatusData> objStatus = null;

            if (objControl != null)
            {
                strHeaderText = objControl.GetCurrentContentName();

                objStatus = objControl.GetStatus();
            }

            this.mobjHeaderLabel.Text = strHeaderText;

            mobjFooterPanelTop.SetLabels(objStatus);
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns></returns>
        public abstract ContentChangeNotifierUserControl GetContent();
    }
}
