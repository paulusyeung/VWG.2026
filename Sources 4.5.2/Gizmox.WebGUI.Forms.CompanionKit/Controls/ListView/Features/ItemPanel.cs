using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.Controls.ListView.Features
{
    [Serializable()]
    public partial class ItemPanel : UserControl
    {


		private RandomData mobjRandomData = null;

		public ItemPanel()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            // Set icon images for ListView column headers
            this.mobjColumnImportant.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Important.gif");
            this.mobjColumnOpened.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Opened.gif");
            this.mobjColumnAttached.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Attachment.gif");

			mobjRandomData = new RandomData();

            // Fill up ListView
			for(int i=0;i<60;i++)
			{
				AddItem();
			}

            // Set enable automatically resize for ListView columns by column content
            foreach (ColumnHeader objCol in this.mobjListView.Columns)
            {
                if (objCol.Type != ListViewColumnType.Control)
                {
                    objCol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
		}

        /// <summary>
        /// Adds row to ListView
        /// </summary>
		private void AddItem()
		{
			ListViewItem objItem = null;

            ListViewControlPanel objPanel = new ListViewControlPanel();
            objPanel.Visible = false;

			if(mobjRandomData.GetBoolean())
			{
                objItem = this.mobjListView.Items.Add(objPanel, GetIcon("ImportantMail.gif"));
			}
			else
			{
                objItem = this.mobjListView.Items.Add(objPanel, "");
			}

			if(mobjRandomData.GetBoolean())
			{
				objItem.SubItems.Add(GetIcon("OpenedMail.gif"));                
                objPanel.Read = true;
			}
			else
			{
				objItem.SubItems.Add(GetIcon("ClosedMail.gif"));
                objPanel.Read = false;
			}
			if(mobjRandomData.GetBoolean())
			{
				objItem.SubItems.Add(GetIcon("AttachedMail.gif"));
                objPanel.Attachemnts = true;
			}
			else
			{
				objItem.SubItems.Add("");
                objPanel.Attachemnts = false;
			}
			objItem.SubItems.Add(objPanel.Subject = "This is a test message.");
            objItem.SubItems.Add(objPanel.From = "test@visualwebgui.com");
			
			objItem.SubItems.Add(mobjRandomData.GetDate().ToString());
            objItem.SubItems.Add(objPanel.MailSize = mobjRandomData.GetSize());

            Gizmox.WebGUI.Forms.Button objButton = new Gizmox.WebGUI.Forms.Button();
            objButton.Click += new EventHandler(OnEditButtonClick);
            objButton.Tag = objItem;
            objButton.Text = "Edit";
            objItem.SubItems.Add(objButton);


            if (mobjRandomData.GetBoolean())
            {
                objItem.UseItemStyleForSubItems = false;
                objItem.SubItems[2].BackColor = Color.Yellow;
            }

            if (mobjRandomData.GetBoolean())
            {
                objItem.UseItemStyleForSubItems = false;
                objItem.SubItems[4].BackColor = Color.LightGreen;
            }

		}

        /// <summary>
        /// Handles click event of the Button that is in action column in ListView.
        /// The method opens panel for editing row data and after editting save changed data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditButtonClick(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Button objButton = sender as Gizmox.WebGUI.Forms.Button;
            if (objButton != null)
            {
                ListViewPanelItem objPanelItem = objButton.Tag as ListViewPanelItem;
                if (objPanelItem != null)
                {
                    if (objPanelItem.Panel.Visible = !objPanelItem.Panel.Visible)
                    {
                        objButton.Text = "Commit";
                    }
                    else
                    {
                        objButton.Text = "Edit";

                        ListViewControlPanel objPanel = objPanelItem.Panel as ListViewControlPanel;
                        if (objPanel != null)
                        {
                            if (objPanel.Important)
                            {
                                objPanelItem.SubItems[0].Text = GetIcon("ImportantMail.gif");
                            }
                            else
                            {
                                objPanelItem.SubItems[0].Text = "";
                            }

                            if (objPanel.Read)
                            {
                                objPanelItem.SubItems[1].Text = GetIcon("OpenedMail.gif");
                            }
                            else
                            {
                                objPanelItem.SubItems[1].Text = GetIcon("ClosedMail.gif");
                            }

                            if (objPanel.Attachemnts)
                            {
                                objPanelItem.SubItems[2].Text = GetIcon("AttachedMail.gif");
                            }
                            else
                            {
                                objPanelItem.SubItems[2].Text = "";
                            }

                            objPanelItem.SubItems[3].Text = objPanel.Subject;
                            objPanelItem.SubItems[4].Text = objPanel.From;
                            objPanelItem.SubItems[6].Text = objPanel.MailSize;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets resource string for specified icon name
        /// </summary>
        /// <param name="strName">icon name</param>
        /// <returns></returns>
		private string GetIcon(string strName)
		{
			return (new IconResourceHandle(strName)).ToString();
		}

        [Serializable()]
        public class RandomData
        {
            private Random mobjRandom;

            public RandomData()
            {
                mobjRandom = new Random(0);
            }

            public bool GetBoolean()
            {
                return mobjRandom.NextDouble() > 0.5;
            }

            public string GetSize()
            {
                return mobjRandom.Next(1, 2000).ToString() + "kb";
            }

            public DateTime GetDate()
            {
                return DateTime.Now.AddDays((double)mobjRandom.Next(-100, 100));
            }
        }
    }
}