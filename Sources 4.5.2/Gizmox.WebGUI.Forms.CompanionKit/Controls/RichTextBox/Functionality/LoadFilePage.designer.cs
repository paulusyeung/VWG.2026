namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class LoadFilePage
    {
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.listViewItem1 = new Gizmox.WebGUI.Forms.ListViewItem("Sample.rtf");
            this.listViewItem2 = new Gizmox.WebGUI.Forms.ListViewItem("Scenario.rtf");
            this.listViewItem3 = new Gizmox.WebGUI.Forms.ListViewItem("List.rtf");
            this.mobjLoadButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 70);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Select file name and click button to load it to RichTextBox:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjRichTextBox
            // 
            this.mobjTLP.SetColumnSpan(this.mobjRichTextBox, 2);
            this.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRichTextBox.Location = new System.Drawing.Point(10, 185);
            this.mobjRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjRichTextBox.Name = "mobjRichTextBox";
            this.mobjRichTextBox.Size = new System.Drawing.Size(300, 155);
            this.mobjRichTextBox.TabIndex = 2;
            // 
            // mobjListView
            // 
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Items.AddRange(new Gizmox.WebGUI.Forms.ListViewItem[] {
            this.listViewItem1,
            this.listViewItem2,
            this.listViewItem3});
            this.mobjListView.Location = new System.Drawing.Point(0, 70);
            this.mobjListView.MultiSelect = false;
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(160, 105);
            this.mobjListView.TabIndex = 3;
            this.mobjListView.View = Gizmox.WebGUI.Forms.View.List;
            // 
            // listViewItem1
            // 
            this.listViewItem1.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem1.Text = "Sample.rtf";
            // 
            // listViewItem2
            // 
            this.listViewItem2.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem2.Text = "Scenario.rtf";
            // 
            // listViewItem3
            // 
            this.listViewItem3.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem3.Text = "List.rtf";
            // 
            // mobjLoadButton
            // 
            this.mobjLoadButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLoadButton.Location = new System.Drawing.Point(170, 80);
            this.mobjLoadButton.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLoadButton.MaximumSize = new System.Drawing.Size(0, 80);
            this.mobjLoadButton.Name = "mobjLoadButton";
            this.mobjLoadButton.Size = new System.Drawing.Size(140, 80);
            this.mobjLoadButton.TabIndex = 4;
            this.mobjLoadButton.Text = "Load";
            this.mobjLoadButton.Click += new System.EventHandler(this.mobjLoadButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjLoadButton, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjRichTextBox, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 5;
            // 
            // LoadFilePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "LoadFilePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.RichTextBox mobjRichTextBox;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem2;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem3;
        private Gizmox.WebGUI.Forms.Button mobjLoadButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}