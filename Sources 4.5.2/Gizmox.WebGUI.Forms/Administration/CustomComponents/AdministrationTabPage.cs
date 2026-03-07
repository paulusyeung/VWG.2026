using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class AdministrationTabPage : TabPage
    {
        AdministrationContent mobjContent;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationTabPage"/> class.
        /// </summary>
        /// <param name="objContent">Content of the object.</param>
        public AdministrationTabPage(AdministrationContent objContent)
        {
            InitializeTabPage();
            objContent.Dock = DockStyle.Fill;
            this.Text = objContent.ContentProperties.ContentName;
            this.Name = objContent.Name;
            mobjContent = objContent;
            this.Controls.Add(objContent);
        }

        /// <summary>
        /// Initializes the tab page.
        /// </summary>
        private void InitializeTabPage()
        {
            //
            // this
            //
            this.SetFullScrean(false);
            this.ControlAdded += AdministrationTabPage_ControlAdded;
        }

        public void SetFullScrean(bool blnEnabled)
        {
            if (blnEnabled)
            {
                this.DockPadding.Top = 0;
                this.DockPadding.Left = 0;
                this.DockPadding.Right = 0;
            }
            else
            {
                this.DockPadding.Top = 50;
                this.DockPadding.Left = 50;
                this.DockPadding.Right = 50;
            }
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public AdministrationContent Content
        {
            get { return mobjContent; }
        }

        /// <summary>
        /// Handles the ControlAdded event of the AdministrationTabPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        void AdministrationTabPage_ControlAdded(object sender, ControlEventArgs e)
        {
            AdministrationContent objContent = e.Control as AdministrationContent;
            if (objContent == null)
            {
                this.Controls.Remove(objContent);
            }
        }
    }
}
