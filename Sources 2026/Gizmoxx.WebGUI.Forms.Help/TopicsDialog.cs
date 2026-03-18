#region Using

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.HelpLibrary;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region TopicsDialog Class

    /// <summary>
    /// Summary description for TopicsDialog.
	/// </summary>
    
	public class TopicsDialog : Form
    {
    
        private Label mobjLabelInstructions;
        private Panel mobjPanelButtons;
        private Button mobjButtonDisplay;
        private Button mobjButtonCancel;
        private ListView mobjListTopics;
        private ColumnHeader mobjColumnTitle;
        private ColumnHeader mobjBolumnLocation;

        private bool mblnIsCompleted = false;

        private HtmlHelp.IndexTopic mobjSelectedItem = null;

        public TopicsDialog()
        {
            InitializeComponent();
        }

        public TopicsDialog(ArrayList objTopics)
        {
            InitializeComponent();

            foreach (HtmlHelp.IndexTopic objIndexTopic in objTopics)
            {
                ListViewItem objListViewItem = mobjListTopics.Items.Add(objIndexTopic.Title);
                objListViewItem.Tag = objIndexTopic;                
            }
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjLabelInstructions = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanelButtons = new Gizmox.WebGUI.Forms.Panel();
            this.mobjListTopics = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnTitle = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjBolumnLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonDisplay = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjLabelInstructions
            // 
            this.mobjLabelInstructions.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelInstructions.ClientSize = new System.Drawing.Size(448, 23);
            this.mobjLabelInstructions.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelInstructions.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelInstructions.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelInstructions.Location = new System.Drawing.Point(10, 10);
            this.mobjLabelInstructions.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelInstructions.Name = "mobjLabelInstructions";
            this.mobjLabelInstructions.Size = new System.Drawing.Size(448, 23);
            this.mobjLabelInstructions.TabIndex = 0;
            this.mobjLabelInstructions.Text = "Click a topic, then click display.";
            this.mobjLabelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjPanelButtons
            // 
            this.mobjPanelButtons.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelButtons.ClientSize = new System.Drawing.Size(448, 38);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonDisplay);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonCancel);
            this.mobjPanelButtons.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelButtons.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPanelButtons.Location = new System.Drawing.Point(10, 194);
            this.mobjPanelButtons.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelButtons.Name = "mobjPanelButtons";
            this.mobjPanelButtons.Size = new System.Drawing.Size(448, 38);
            this.mobjPanelButtons.TabIndex = 0;
            // 
            // mobjListTopics
            // 
            this.mobjListTopics.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjListTopics.ClientSize = new System.Drawing.Size(448, 387);
            this.mobjListTopics.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnTitle,
            this.mobjBolumnLocation});
            this.mobjListTopics.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjListTopics.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListTopics.ItemsPerPage = 20;
            this.mobjListTopics.Location = new System.Drawing.Point(10, 33);
            this.mobjListTopics.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjListTopics.MultiSelect = false;
            this.mobjListTopics.Name = "mobjListTopics";
            this.mobjListTopics.Size = new System.Drawing.Size(448, 387);
            this.mobjListTopics.TabIndex = 0;
            this.mobjListTopics.SelectedIndexChanged += new EventHandler(mobjListTopics_SelectedIndexChanged);
            this.mobjListTopics.DoubleClick += new EventHandler(mobjListTopics_DoubleClick);
            // 
            // mobjColumnTitle
            // 
            this.mobjColumnTitle.Image = null;
            this.mobjColumnTitle.Text = "Title";
            this.mobjColumnTitle.Width = 230;
            // 
            // mobjBolumnLocation
            // 
            this.mobjBolumnLocation.Image = null;
            this.mobjBolumnLocation.Text = "Location";
            this.mobjBolumnLocation.Width = 180;
            // 
            // mobjButtonCancel
            // 
            this.mobjButtonCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonCancel.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonCancel.ClientSize = new System.Drawing.Size(75, 23);
            this.mobjButtonCancel.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonCancel.Location = new System.Drawing.Point(373, 15);
            this.mobjButtonCancel.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonCancel.Name = "mobjButtonCancel";
            this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonCancel.TabIndex = 0;
            this.mobjButtonCancel.Text = "Cancel";
            this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
            // 
            // mobjButtonDisplay
            // 
            this.mobjButtonDisplay.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonDisplay.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonDisplay.ClientSize = new System.Drawing.Size(75, 23);
            this.mobjButtonDisplay.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonDisplay.Location = new System.Drawing.Point(292, 15);
            this.mobjButtonDisplay.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonDisplay.Name = "mobjButtonDisplay";
            this.mobjButtonDisplay.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonDisplay.TabIndex = 0;
            this.mobjButtonDisplay.Text = "Display";
            this.mobjButtonDisplay.Click += new System.EventHandler(this.mobjButtonDisplay_Click);
            this.mobjButtonDisplay.Enabled = false;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(468, 242);
            this.Controls.Add(this.mobjListTopics);
            this.Controls.Add(this.mobjPanelButtons);
            this.Controls.Add(this.mobjLabelInstructions);
            this.DockPadding.All = 10;
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(468, 242);
            this.Text = "Topics";
            this.ResumeLayout(false);

        }

        private void mobjListTopics_DoubleClick(object sender, EventArgs e)
        {
            if (mobjListTopics.SelectedItem != null)
            {
                mobjSelectedItem = (HtmlHelp.IndexTopic)this.mobjListTopics.SelectedItem.Tag;
                mblnIsCompleted = true;
                this.Close();
            }
        }

        void mobjListTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjListTopics.SelectedItem != null)
            {
                mobjSelectedItem = (HtmlHelp.IndexTopic)this.mobjListTopics.SelectedItem.Tag;
                mobjButtonDisplay.Enabled = true;
            }
            else
            {
                mobjButtonDisplay.Enabled = false;
            }
        }

        #endregion

        private void mobjButtonDisplay_Click(object sender, EventArgs e)
        {
            if (mobjListTopics.SelectedItem != null)
            {
                mobjSelectedItem = (HtmlHelp.IndexTopic)this.mobjListTopics.SelectedItem.Tag;
                this.mblnIsCompleted = true;
                this.Close();
            }
            else
            {
                mobjButtonDisplay.Enabled = false;
            }            
        }

        private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public HtmlHelp.IndexTopic SelectedItem
        {
            get
            {
                return mobjSelectedItem;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return mblnIsCompleted;
            }
        }

    }
    #endregion TopicsDialog Class
}
