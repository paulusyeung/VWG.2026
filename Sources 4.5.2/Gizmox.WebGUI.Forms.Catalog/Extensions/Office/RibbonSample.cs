#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using System.IO;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Office
{
    [Serializable()]
    public partial class RibbonSample : UserControl
    {
        #region Members

        protected int mintUserId = 0;
        protected string mstrUserName = string.Empty;

        #endregion

        #region C'tor
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteEmailForm"/> class.
        /// </summary>
        public RibbonSample()
        {
            InitializeComponent();
            InitializateRibbonBar();
        }
        #endregion

        #region Methods

        private void InitializateRibbonBar()
        {
            ISupportsRibbonBar objSupportsRibbonBar = mobjRichTextEditor as ISupportsRibbonBar;

            if (objSupportsRibbonBar != null)
            {
                objSupportsRibbonBar.ApplyGroup(mobjBasicTextRibbonBarGroup, "BasicText");
                objSupportsRibbonBar.ApplyGroup(mobjProffingRibbonBarGroup, "Proofing");
                objSupportsRibbonBar.ApplyGroup(mobjClipboardRibbonBarGroup, "Clipboard");
                objSupportsRibbonBar.ApplyGroup(mobjFonRibbonBarGroup, "Font");
                objSupportsRibbonBar.ApplyGroup(mobjParagraphRibbonBarGroup, "Paragraph");
                objSupportsRibbonBar.ApplyGroup(mobjZoomRibbonBarGroup, "Zoom");
            }
        }


        #endregion

        private void mobjStartMenuButton_Click(object sender, EventArgs e)
        {
            mobjMainRibbonBar.StartMenuProperties.RightToolStripProperties.Items.Clear();
            ToolStripButton objButton = sender as ToolStripButton;
            if(objButton!=null)
            {
                int y = int.Parse(objButton.Tag.ToString());
                for (int i=1; i <= 3; i++)
                {
                    ToolStripButton objNewButton = new ToolStripButton(string.Format("Sub Item {0}", (y-1)*3 + i));
                    objNewButton.TextAlign = ContentAlignment.MiddleLeft;
                    objNewButton.Click += new EventHandler(objNewButton_Click);
                    mobjMainRibbonBar.StartMenuProperties.RightToolStripProperties.Items.Add(objNewButton);
                }
            }
        }

        private void objNewButton_Click(object sender, EventArgs e)
        {
            ToolStripButton objButton = sender as ToolStripButton;
            if (objButton != null)
            {
                MessageBox.Show(objButton.Text + " was clicked","RibbonBar Sample",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void mobjQAButton1_Click(object sender, EventArgs e)
        {
            mobjGroupedRibbonBarPage1.Visible = true;
            mobjGroupedRibbonBarPage2.Visible = true;
            MessageBox.Show("Test1", "RibbonBar Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mobjQAButton2_Click(object sender, EventArgs e)
        {
            mobjGroupedRibbonBarPage1.Visible = false;
            mobjGroupedRibbonBarPage2.Visible = false;
            MessageBox.Show("Test2", "RibbonBar Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
