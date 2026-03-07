using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.CompanionKit.UI;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.SEO
{
    #region SEODeviceMainForm Class

    /// <summary>
    /// 
    /// </summary>
    public class SEODeviceMainForm : Form
    {
        #region Fields

        private DeviceNavigationUpButton mobjUpButton;
        private Panel mobjHeaderPanel;
        private HtmlBox mobjMainHtmlBox;
        private MainDeviceListView mobjMainListView;
        private Panel mobjMainPanel;
        private Panel mobjNavigationPanel;
        private ColumnHeader mobjTextCcolumnHeader;
        private StatusStrip mobjMainStatusStrip;
        private Panel mobjBottomPanel;
        private ThemesButton mobjThemesButton;
        private PictureBox mobjLogoPictureBox;
        private ThemesBrowser mobjThemesBrowser;
        private Panel mobjLayoutPanel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SEODeviceMainForm"/> class.
        /// </summary>
        /// <param name="objItem">The obj item.</param>
        /// <param name="blnIsAdmin">if set to <c>true</c> [BLN is admin].</param>
        public SEODeviceMainForm(SEOItem objItem, bool blnIsAdmin)
        {
            Context.FullScreenMode = true;

            InitializeComponent();

            this.InitializeSEOItem(objItem);

            this.mobjThemesBrowser.Init();  
        }

        /// <summary>   
        /// Initializes a new instance of the <see cref="SEODeviceMainForm"/> class.
        /// </summary>
        public SEODeviceMainForm()
        {
            Context.FullScreenMode = true;


            InitializeComponent();

            this.InitializeSEOItem();

            this.mobjThemesBrowser.Init();            
        }
        
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEODeviceMainForm));
            Gizmox.WebGUI.Forms.ColumnHeader mobjIconCcolumnHeader;
            this.mobjHeaderPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLogoPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjNavigationPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjMainPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjMainStatusStrip = new Gizmox.WebGUI.Forms.StatusStrip();
            this.mobjThemesButton = new ThemesButton();
            this.mobjMainHtmlBox = new Gizmox.WebGUI.Forms.HtmlBox();
            this.mobjThemesBrowser = new Gizmox.WebGUI.Forms.CompanionKit.UI.ThemesBrowser(this);
            this.mobjMainListView = new Gizmox.WebGUI.Forms.CompanionKit.UI.MainDeviceListView();
            this.mobjTextCcolumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjUpButton = new Gizmox.WebGUI.Forms.CompanionKit.UI.DeviceNavigationUpButton();
            this.mobjLayoutPanel = new Panel();
            mobjIconCcolumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLogoPictureBox)).BeginInit();
            this.mobjNavigationPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjHeaderPanel
            // 
            this.mobjHeaderPanel.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjHeaderPanel.BackgroundImage"));
            this.mobjHeaderPanel.Controls.Add(this.mobjLogoPictureBox);
            this.mobjHeaderPanel.Controls.Add(this.mobjNavigationPanel);
            this.mobjHeaderPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjHeaderPanel.Name = "mobjHeaderPanel";
            this.mobjHeaderPanel.Size = new System.Drawing.Size(784, 59);
            this.mobjHeaderPanel.TabIndex = 1;
            // 
            // mobjLogoPictureBox
            // 
            this.mobjLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.mobjLogoPictureBox.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjLogoPictureBox.BackgroundImage"));
            this.mobjLogoPictureBox.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.mobjLogoPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjLogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mobjLogoPictureBox.Name = "pictureBox1";
            this.mobjLogoPictureBox.Size = new System.Drawing.Size(171, 59);
            this.mobjLogoPictureBox.TabIndex = 3;
            this.mobjLogoPictureBox.TabStop = false;
            // 
            // mobjNavigationPanel
            // 
            this.mobjNavigationPanel.Controls.Add(this.mobjUpButton);
            this.mobjNavigationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNavigationPanel.Location = new System.Drawing.Point(228, 0);
            this.mobjNavigationPanel.Name = "mobjNavigationPanel";
            this.mobjNavigationPanel.Size = new System.Drawing.Size(784, 59);
            this.mobjNavigationPanel.TabIndex = 2;
            this.mobjNavigationPanel.BackColor = Color.Transparent;
            // 
            // mobjMainPanel
            // 
            this.mobjMainPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMainPanel.Location = new System.Drawing.Point(0, 59);
            this.mobjMainPanel.Name = "mobjMainPanel";
            this.mobjMainPanel.Size = new System.Drawing.Size(784, 397);
            this.mobjMainPanel.TabIndex = 2;
            this.mobjMainPanel.Visible = false;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjBottomPanel.BackgroundImage"));
            this.mobjBottomPanel.Controls.Add(this.mobjMainStatusStrip);
            this.mobjBottomPanel.Controls.Add(this.mobjThemesButton);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 364);
            this.mobjBottomPanel.Name = "panel1";
            this.mobjBottomPanel.Size = new System.Drawing.Size(784, 42);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // mobjMainStatusStrip
            // 
            this.mobjMainStatusStrip.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjMainStatusStrip.BackgroundImage"));
            this.mobjMainStatusStrip.CanOverflow = true;
            this.mobjMainStatusStrip.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMainStatusStrip.DockPadding.Left = 1;
            this.mobjMainStatusStrip.DockPadding.Right = 14;
            this.mobjMainStatusStrip.Location = new System.Drawing.Point(0, 10);
            this.mobjMainStatusStrip.Name = "mobjMainStatusStrip";
            this.mobjMainStatusStrip.Size = new System.Drawing.Size(48, 22);
            this.mobjMainStatusStrip.TabIndex = 3;
            this.mobjMainStatusStrip.Text = "statusStrip1";
            this.mobjMainStatusStrip.BackColor = Color.Transparent;
            // 
            // mobjThemesButton
            //             
            this.mobjThemesButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjThemesButton.BackColor = Color.Transparent;
            this.mobjThemesButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjThemesButton.Image"));
            this.mobjThemesButton.Location = new System.Drawing.Point(709, 0);
            this.mobjThemesButton.Name = "button1";
            this.mobjThemesButton.Size = new System.Drawing.Size(75, 42);
            this.mobjThemesButton.TabIndex = 4;
            this.mobjThemesButton.Click += new System.EventHandler(this.mobjThemesButton_Click);
            // 
            // mobjMainHtmlBox
            // 
            this.mobjMainHtmlBox.ContentType = "text/html";
            this.mobjMainHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMainHtmlBox.Expires = -1;
            this.mobjMainHtmlBox.Html = "<HTML>No content.</HTML>";
            this.mobjMainHtmlBox.Location = new System.Drawing.Point(0, 0);
            this.mobjMainHtmlBox.Name = "mobjMainHtmlBox";
            this.mobjMainHtmlBox.Size = new System.Drawing.Size(784, 456);
            this.mobjMainHtmlBox.TabIndex = 3;
            this.mobjMainHtmlBox.Visible = false;
            // 
            // mobjThemesBrowser
            //                         
            this.mobjThemesBrowser.Name = "mobjThemesBrowser";            
            this.mobjThemesBrowser.TabIndex = 0;
            this.mobjThemesBrowser.Text = "Select a Theme";
            this.mobjThemesBrowser.Dock = DockStyle.Fill;
            this.mobjThemesBrowser.Visible = false;
            // 
            // mobjMainListView
            // 
            this.mobjMainListView.AutoGenerateColumns = false;
            this.mobjMainListView.ColumnHeadersHeight = 0;
            this.mobjMainListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            mobjIconCcolumnHeader,
            this.mobjTextCcolumnHeader});
            this.mobjMainListView.CustomStyle = "MainDeviceListViewSkin";
            this.mobjMainListView.DataMember = null;
            this.mobjMainListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMainListView.FullRowSelect = true;
            this.mobjMainListView.ItemsPerPage = 20;
            this.mobjMainListView.Location = new System.Drawing.Point(0, 59);
            this.mobjMainListView.Name = "mobjMainListView";
            this.mobjMainListView.ShowGroups = false;
            this.mobjMainListView.ShowItemToolTips = false;
            this.mobjMainListView.Size = new System.Drawing.Size(784, 397);
            this.mobjMainListView.TabIndex = 0;
            this.mobjMainListView.ItemClick += new System.EventHandler(this.mobjMainListView_Click);
            this.mobjMainListView.ItemBinding += new Gizmox.WebGUI.Forms.ListViewItemBindingEventHandler(this.mobjMainListView_ItemBinding);
            // 
            // mobjIconCcolumnHeader
            // 
            mobjIconCcolumnHeader.Text = "";
            mobjIconCcolumnHeader.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            mobjIconCcolumnHeader.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            mobjIconCcolumnHeader.Width = 50;
            // 
            // mobjTextCcolumnHeader
            // 
            this.mobjTextCcolumnHeader.Tag = "DisplayName";
            this.mobjTextCcolumnHeader.Text = "";
            this.mobjTextCcolumnHeader.Width = 300;
            // 
            // mobjUpButton
            // 
            this.mobjUpButton.CustomStyle = "DeviceNavigationUpButtonSkin";            
            this.mobjUpButton.Location = new System.Drawing.Point(9, 6);
            this.mobjUpButton.Name = "mobjBackButton";
            this.mobjUpButton.Size = new System.Drawing.Size(75, 46);
            this.mobjUpButton.TabIndex = 0;
            this.mobjUpButton.Click += new System.EventHandler(this.mobjBackButton_Click);

            this.mobjLayoutPanel.Dock = DockStyle.Fill;            
            // 
            // SEODeviceMainForm
            //            
            this.mobjLayoutPanel.Controls.Add(this.mobjMainPanel);
            this.mobjLayoutPanel.Controls.Add(this.mobjMainListView);
            this.mobjLayoutPanel.Controls.Add(this.mobjHeaderPanel);
            this.mobjLayoutPanel.Controls.Add(this.mobjMainHtmlBox);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjThemesBrowser);
            this.Controls.Add(mobjLayoutPanel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(784, 456);
            this.mobjHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjLogoPictureBox)).EndInit();
            this.mobjNavigationPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void mobjThemesButton_Click(object sender, EventArgs e)
        {
            this.mobjThemesBrowser.SetVisible(true);
        }

        /// <summary>
        /// Initializes the SEO item.
        /// </summary>
        private void InitializeSEOItem()
        {
            this.InitializeSEOItem(SEOSite.Root.Parent);
        }

        /// <summary>
        /// Registers the page script resources.
        /// </summary>
        /// <param name="objSEOPage">The obj SEO view page.</param>
        private void RegisterPageScriptResources(SEOPage objSEOPage)
        {
            // Validate recieved page.
            if (objSEOPage != null)
            {
                // Validate current client context.
                if (VWGClientContext.Current != null)
                {
                    // Loop all page resources.
                    foreach (SEOItemResource objSEOItemResource in objSEOPage.Resources)
                    {
                        // Check if current resource is a page script.
                        if (objSEOItemResource.PageScript)
                        {
                            VWGClientContext.Current.Invoke("registerScript", objSEOItemResource.Name, objSEOItemResource.ViewURL);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Uns the register page script resources.
        /// </summary>
        /// <param name="objSEOPage">The obj SEO view page.</param>
        private void UnRegisterPageScriptResources(SEOPage objSEOPage)
        {
            // Validate recieved page.
            if (objSEOPage != null)
            {
                // Validate current client context.
                if (VWGClientContext.Current != null)
                {
                    // Loop all page resources.
                    foreach (SEOItemResource objSEOItemResource in objSEOPage.Resources)
                    {
                        // Check if current resource is a page script.
                        if (objSEOItemResource.PageScript)
                        {
                            VWGClientContext.Current.Invoke("unRegisterScript", objSEOItemResource.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears the main panel.
        /// </summary>
        private void ClearMainPanel()
        {
            // Validate that container has controls.
            if (mobjMainPanel.Controls.Count > 0)
            {
                // Loop all contained controls.
                foreach (Control objControl in mobjMainPanel.Controls)
                {
                    // Try getting an SEO page from current control's tag.
                    SEOPage objSEOPage = objControl.Tag as SEOPage;
                    if (objSEOPage != null)
                    {
                        // Unregister page's script resources.
                        this.UnRegisterPageScriptResources(objSEOPage);
                    }
                }

                mobjMainPanel.Controls.Clear();
            }
        }

        /// <summary>
        /// Initializes the SEO item.
        /// </summary>
        /// <param name="objItem">The obj item.</param>
        private void InitializeSEOItem(SEOItem objItem)
        {
            if (!this.DesignMode)
            {
                if (objItem != null)
                {
                    this.ClearMainPanel();

                    mobjMainStatusStrip.Items.Clear();

                    SEOItem objCurrentItem = objItem;

                    while (objCurrentItem != null)
                    {
                        string strLabel = string.IsNullOrEmpty(objCurrentItem.DisplayName) ? "Root" : objCurrentItem.DisplayName;

                        if (objCurrentItem != objItem)
                        {
                            strLabel += " »";
                        }

                        ToolStripStatusLabel objToolStripStatusLabel = new ToolStripStatusLabel(strLabel);
                        objToolStripStatusLabel.ForeColor = Color.White;
                        objToolStripStatusLabel.Font = new System.Drawing.Font("Arial", 20f, GraphicsUnit.Pixel);

                        objToolStripStatusLabel.IsLink = true;
                        objToolStripStatusLabel.Tag = objCurrentItem;
                        objToolStripStatusLabel.Click += new EventHandler(objToolStripStatusLabel_Click);

                        mobjMainStatusStrip.Items.Insert(0, objToolStripStatusLabel);

                        objCurrentItem = objCurrentItem.Parent;
                    }

                    SEOFolder objSEOFolder = objItem as SEOFolder;
                    if (objSEOFolder != null)
                    {
                        mobjMainListView.DataSource = new List<SEOItem>(objSEOFolder.Items).FindAll(delegate(SEOItem objSEOItem) { return !(objSEOItem is SEOArticle) && objSEOItem.Status == SEOItemStatus.Publish; });

                        mobjMainListView.Visible = true;
                        mobjMainHtmlBox.Visible = mobjMainPanel.Visible = false;
                    }
                    else
                    {
                        // If is page
                        SEOPage objSEOViewPage = objItem as SEOPage;
                        if (objSEOViewPage != null)
                        {
                            // If is page
                            if (objSEOViewPage.Type == SEOItemType.Page)
                            {
                                // Get page type
                                Type objType = Type.GetType(objSEOViewPage.PageType, false);
                                if (objType != null)
                                {
                                    // Creat the page type
                                    Control objControl = Activator.CreateInstance(objType) as Control;
                                    if (objControl != null)
                                    {
                                        // Registers the page script resources.
                                        this.RegisterPageScriptResources(objSEOViewPage);

                                        objControl.Tag = objSEOViewPage;

                                        mobjMainPanel.Controls.Add(objControl);

                                        objControl.Dock = DockStyle.Fill;
                                    }
                                }

                                mobjMainPanel.Visible = true;
                                mobjMainHtmlBox.Visible = mobjMainListView.Visible = false;
                            }
                        }
                        else
                        {
                            SEOLobby objSEOLobby = objItem as SEOLobby;
                            if (objSEOLobby != null)
                            {
                                StringBuilder objStringBuilder = new StringBuilder();

                                foreach (SEOLobby.Section objSection in objSEOLobby.Sections)
                                {
                                    objStringBuilder.AppendLine(objSection.PreText);
                                }

                                if (objStringBuilder.Length > 0)
                                {
                                    mobjMainHtmlBox.Html = objStringBuilder.ToString();
                                }

                                mobjMainHtmlBox.Visible = true;
                                mobjMainPanel.Visible = mobjMainListView.Visible = false;
                            }
                        }
                    }

                    mobjUpButton.Visible = objItem.Parent != null;
                }
                else
                {
                    mobjMainListView.DataSource = null;
                    mobjUpButton.Visible = false;
                }

                mobjMainListView.Tag = objItem;
            }
        }

        /// <summary>
        /// Handles the Click event of the objToolStripStatusLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void objToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel objToolStripStatusLabel = sender as ToolStripStatusLabel;
            if (objToolStripStatusLabel != null)
            {
                SEOItem objSEOItem = objToolStripStatusLabel.Tag as SEOItem;
                if (objSEOItem != null)
                {
                    this.InitializeSEOItem(objSEOItem);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjBackButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjBackButton_Click(object sender, EventArgs e)
        {
            SEOItem objItem = mobjMainListView.Tag as SEOItem;
            if (objItem != null)
            {
                this.InitializeSEOItem(objItem.Parent);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjMainListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjMainListView_Click(object sender, EventArgs e)
        {
            ListViewItem objListViewItem = sender as ListViewItem;

            if (objListViewItem != null)
            {
                SEOItem objItem = objListViewItem.Tag as SEOItem;
                if (objItem != null)
                {
                    this.InitializeSEOItem(objItem);
                }
            }
        }

        /// <summary>
        /// Handles the ItemBinding event of the mobjMainListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs"/> instance containing the event data.</param>
        private void mobjMainListView_ItemBinding(object sender, ListViewItemBindingEventArgs e)
        {
            if (e.ListViewItem != null)
            {
                e.ListViewItem.Tag = e.DataRow;

                if (e.ListViewItem.Tag is SEOFolder)
                {
                    e.ListViewItem.SubItems[0].Text = new ImageResourceHandle("32x32.Folder.png").ToString();
                }
                else if (e.ListViewItem.Tag is SEOPage)
                {
                    e.ListViewItem.SubItems[0].Text = new ImageResourceHandle("32x32.Document.png").ToString();
                }
                else if (e.ListViewItem.Tag is SEOLobby)
                {
                    e.ListViewItem.SubItems[0].Text = new ImageResourceHandle("32x32.Question.png").ToString();
                }
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the layout panel.
        /// </summary>
        /// <value>
        /// The layout panel.
        /// </value>
        internal Panel LayoutPanel
        {
            get { return mobjLayoutPanel; }
        } 

        #endregion Properties
    }

    #endregion
}
