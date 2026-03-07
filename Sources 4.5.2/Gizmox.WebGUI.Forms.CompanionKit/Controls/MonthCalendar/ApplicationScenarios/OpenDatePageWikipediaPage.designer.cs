namespace CompanionKit.Controls.MonthCalendar.ApplicationScenarios
{
    partial class OpenDatePageWikipediaPage
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
            this.mobjWikiPageHtmlBox = new Gizmox.WebGUI.Forms.HtmlBox();
            this.mobjDemoMonthCalendar = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.mobjDateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjHTMLPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjHTMLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWikiPageHtmlBox
            // 
            this.mobjWikiPageHtmlBox.ContentType = "text/html";
            this.mobjWikiPageHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWikiPageHtmlBox.Html = "";
            this.mobjWikiPageHtmlBox.Location = new System.Drawing.Point(0, 0);
            this.mobjWikiPageHtmlBox.Name = "mobjWikiPageHtmlBox";
            this.mobjWikiPageHtmlBox.Size = new System.Drawing.Size(496, 329);
            this.mobjWikiPageHtmlBox.TabIndex = 0;
            this.mobjWikiPageHtmlBox.Url = "http://en.wikipedia.org/wiki/December_12";
            // 
            // mobjDemoMonthCalendar
            // 
            this.mobjDemoMonthCalendar.Location = new System.Drawing.Point(62, 70);
            this.mobjDemoMonthCalendar.Name = "mobjDemoMonthCalendar";
            this.mobjDemoMonthCalendar.SelectionEnd = new System.DateTime(2010, 5, 7, 16, 45, 46, 84);
            this.mobjDemoMonthCalendar.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2010, 5, 7, 0, 0, 0, 0), new System.DateTime(2010, 5, 7, 0, 0, 0, 0));
            this.mobjDemoMonthCalendar.SelectionStart = new System.DateTime(2010, 5, 7, 16, 45, 46, 84);
            this.mobjDemoMonthCalendar.Size = new System.Drawing.Size(227, 162);
            this.mobjDemoMonthCalendar.TabIndex = 1;
            this.mobjDemoMonthCalendar.Value = new System.DateTime(2010, 5, 7, 16, 45, 46, 84);
            this.mobjDemoMonthCalendar.ValueChanged += new System.EventHandler(this.mobjDemoMonthCalendar_ValueChanged);
            // 
            // mobjDateLabel
            // 
            this.mobjDateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDateLabel.Name = "mobjDateLabel";
            this.mobjDateLabel.Size = new System.Drawing.Size(805, 30);
            this.mobjDateLabel.TabIndex = 2;
            this.mobjDateLabel.Text = "Select a date from the calendar to see Wikipedia related page";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 227F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoMonthCalendar, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjHTMLPanel, 3, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 162F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(867, 421);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // mobjPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPanel, 4);
            this.mobjPanel.Controls.Add(this.mobjDateLabel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(62, 20);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(805, 30);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjHTMLPanel
            // 
            this.mobjHTMLPanel.Controls.Add(this.mobjWikiPageHtmlBox);
            this.mobjHTMLPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHTMLPanel.Location = new System.Drawing.Point(309, 70);
            this.mobjHTMLPanel.Name = "mobjHTMLPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjHTMLPanel, 2);
            this.mobjHTMLPanel.Size = new System.Drawing.Size(496, 329);
            this.mobjHTMLPanel.TabIndex = 0;
            // 
            // OpenDatePageWikipediaPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(867, 421);
            this.Text = "OpenDatePageWikipediaPage";
            this.Load += new System.EventHandler(this.OpenDatePageWikipediaPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjHTMLPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.HtmlBox mobjWikiPageHtmlBox;
        private Gizmox.WebGUI.Forms.MonthCalendar mobjDemoMonthCalendar;
        private Gizmox.WebGUI.Forms.Label mobjDateLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjHTMLPanel;



    }
}
