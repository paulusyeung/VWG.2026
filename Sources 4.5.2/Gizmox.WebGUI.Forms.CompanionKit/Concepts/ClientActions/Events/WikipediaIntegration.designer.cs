using System;
using System.Collections.Generic;
using System.Web;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;

namespace CompanionKit.Concepts.ClientActions.Events
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WikipediaIntegration : UserControl
    {
		#region Fields 

        private TextBox mobjQueryTextBox;
        private HtmlBox mobjResultHtmlBox;
        private Button mobjSearchButton;

		#endregion Fields 

		#region Methods 

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjResultHtmlBox = new Gizmox.WebGUI.Forms.HtmlBox();
            this.mobjQueryTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSearchButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjResultHtmlBox
            // 
            this.mobjResultHtmlBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjResultHtmlBox.BackColor = System.Drawing.Color.White;
            this.mobjResultHtmlBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjResultHtmlBox.ContentType = "text/html";
            this.mobjResultHtmlBox.Expires = -1;
            this.mobjResultHtmlBox.Html = "<HTML></HTML>";
            this.mobjResultHtmlBox.IsWindowless = true;
            this.mobjResultHtmlBox.Location = new System.Drawing.Point(13, 48);
            this.mobjResultHtmlBox.Name = "mobjResultHtmlBox";
            this.mobjResultHtmlBox.Size = new System.Drawing.Size(580, 375);
            this.mobjResultHtmlBox.TabIndex = 2;
            // 
            // mobjQueryTextBox
            // 
            this.mobjQueryTextBox.AllowDrag = false;
            this.mobjQueryTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjQueryTextBox.Location = new System.Drawing.Point(165, 11);
            this.mobjQueryTextBox.Name = "mobjQueryTextBox";
            this.mobjQueryTextBox.Size = new System.Drawing.Size(428, 20);
            this.mobjQueryTextBox.TabIndex = 1;
            this.mobjQueryTextBox.ClientEnterKeyDown += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjQueryTextBox_ClientEnterKeyDown);
            // 
            // mobjSearchButton
            // 
            this.mobjSearchButton.Location = new System.Drawing.Point(13, 9);
            this.mobjSearchButton.Name = "mobjSearchButton";
            this.mobjSearchButton.Size = new System.Drawing.Size(133, 23);
            this.mobjSearchButton.TabIndex = 0;
            this.mobjSearchButton.Text = "Search in Wikipedia";
            this.mobjSearchButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjSearchButton_ClientClick);
            // 
            // ClientWikipediaIntegration
            // 
            this.Controls.Add(this.mobjSearchButton);
            this.Controls.Add(this.mobjQueryTextBox);
            this.Controls.Add(this.mobjResultHtmlBox);
            this.Size = new System.Drawing.Size(602, 441);
            this.ResumeLayout(false);

        }

		#endregion Methods 
    }
}