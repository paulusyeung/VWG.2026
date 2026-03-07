using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RibbonBar.ApplicationScenario
{
    public partial class TextEditingApplicationPage : UserControl
    {
        protected int mintUserId = 0;
        protected string mstrUserName = string.Empty;

        public TextEditingApplicationPage()
        {
            InitializeComponent();
            InitializateRibbonBar();
        }

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