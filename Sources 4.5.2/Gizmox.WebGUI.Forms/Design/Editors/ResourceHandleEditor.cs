using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Text;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class ResourceHandleEditor : WebUITypeEditor
    {
        private WebUITypeEditorHandler mobjHandler = null;

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            ServerOpenFileDialog objServerOpenFileDialog = new ServerOpenFileDialog();
            objServerOpenFileDialog.Closed += objServerOpenFileDialog_Closed;

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDialog(objServerOpenFileDialog);
            }
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Handles the Closed event of the objServerOpenFileDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objServerOpenFileDialog_Closed(object sender, EventArgs e)
        {
            ServerOpenFileDialog objServerOpenFileDialog = sender as ServerOpenFileDialog;
            if (objServerOpenFileDialog != null)
            {
                if (objServerOpenFileDialog.DialogResult == DialogResult.OK)
                {
                    if (mobjHandler != null)
                    {
                        mobjHandler(this.GetPropertyValueFromEditorValue(GetResourceName(objServerOpenFileDialog.FileName)));
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <param name="strFileName">Name of the STR file.</param>
        /// <returns></returns>
        private ResourceHandle GetResourceName(string strFileName)
        {
            string strIconsFolder = Global.Context.Config.GetDirectory("Icons");
            string strImagesFolder = Global.Context.Config.GetDirectory("Images");

            if (strFileName.ToLower(CultureInfo.InvariantCulture).StartsWith(strIconsFolder.ToLower(CultureInfo.InvariantCulture)))
            {
                return new IconResourceHandle(strFileName.Remove(0, strIconsFolder.Length + 1).Replace("\\", "."));
            }
            else if (strFileName.ToLower(CultureInfo.InvariantCulture).StartsWith(strImagesFolder.ToLower(CultureInfo.InvariantCulture)))
            {
                return new ImageResourceHandle(strFileName.Remove(0, strImagesFolder.Length + 1).Replace("\\", "."));
            }

            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    internal class ServerOpenFileDialog : CommonDialog
    {

        #region Members

        private const string DEFAULT_FILTER = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";

        public event EventHandler FileOk;

        private string mstrFileName = string.Empty;

        private string mstrFilter = DEFAULT_FILTER;

        
        #endregion Members

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            return new ServerOpenFileDialogForm(this);
        }

        /// <summary>
        /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
        /// </summary>
        public override void Reset()
        {
            mstrFilter = DEFAULT_FILTER;
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // If files where uploaded
            if (this.DialogResult == DialogResult.OK)
            {
                // Raise file ok event
                OnFileOk(new EventArgs());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:FileOk" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnFileOk(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.FileOk;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        /// <exception cref="System.ArgumentException"></exception>
        public string Filter
        {
            get
            {
                return mstrFilter;
            }
            set
            {
                // Check if value is empty ot null
                if (!string.IsNullOrEmpty(value))
                {
                    string[] arrArray = value.Split('|');

                    if ((arrArray == null) || ((arrArray.Length % 2) != 0))
                    {
                        throw new ArgumentException(SR.GetString("FileDialogInvalidFilter"));
                    }
                }
                mstrFilter = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get
            {
                return mstrFileName;
            }
            internal set
            {
                mstrFileName = value;
            }
        }



        #region ServerOpenFileDialogForm Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        private partial class ServerOpenFileDialogForm : Gizmox.WebGUI.Forms.CommonDialog.CommonDialogForm
        {

            #region Members

            private string mstrIconsFolder = string.Empty;
            private string mstrImagesFolder = string.Empty;

            private System.ComponentModel.IContainer components = null;
            private Panel mobjPanelControls;
            private ComboBox mobjFilterComboBox;
            private TextBox mobjFileNameTextBox;
            private Label mobjFileNameLabel;
            private Panel mobjFoldersPanel;
            private TreeView mobjFoldersTreeView;
            private Splitter mobjSplitter;
            private Panel mobjFilesPanel;
            private ListView mobjFilesListView;
            private Button mobjOpenButton;
            private Button mobjCancelButton;
            private ColumnHeader mobjNameColumnHeader;
            private ColumnHeader mobjDateColumnHeader;
            private ColumnHeader mobjTypeColumnHeader;
            private ColumnHeader mobjSizeColumnHeader;
            private ContextMenuStrip mobjListViewContextMenuStrip;
            private ToolStripMenuItem mobjViewToolStripMenuItem;
            private ToolStripMenuItem objDetailsToolStripMenuItem;
            private ToolStripMenuItem mobjLargeIconToolStripMenuItem;
            private ToolStripMenuItem mobjListToolStripMenuItem;
            private ToolStripMenuItem mobjSmallIconToolStripMenuItem;


            #endregion Members

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerOpenFileDialogForm"/> class.
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public ServerOpenFileDialogForm(CommonDialog objCommonDialog)
                : base(objCommonDialog)
            {
                InitializeComponent();
                ResetAll();
            }

            #endregion C'Tor

            #region Visual WebGui Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.mobjPanelControls = new Gizmox.WebGUI.Forms.Panel();
                this.mobjOpenButton = new Gizmox.WebGUI.Forms.Button();
                this.mobjCancelButton = new Gizmox.WebGUI.Forms.Button();
                this.mobjFilterComboBox = new Gizmox.WebGUI.Forms.ComboBox();
                this.mobjFileNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
                this.mobjFileNameLabel = new Gizmox.WebGUI.Forms.Label();
                this.mobjFoldersPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjFoldersTreeView = new Gizmox.WebGUI.Forms.TreeView();
                this.mobjSplitter = new Gizmox.WebGUI.Forms.Splitter();
                this.mobjFilesPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjFilesListView = new Gizmox.WebGUI.Forms.ListView();
                this.mobjNameColumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
                this.mobjDateColumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
                this.mobjTypeColumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
                this.mobjSizeColumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
                this.mobjListViewContextMenuStrip = new Gizmox.WebGUI.Forms.ContextMenuStrip(this.components);
                this.mobjViewToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
                this.objDetailsToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
                this.mobjLargeIconToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
                this.mobjListToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
                this.mobjSmallIconToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
                this.mobjPanelControls.SuspendLayout();
                this.mobjFoldersPanel.SuspendLayout();
                this.mobjFilesPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // mobjPanelControls
                // 
                this.mobjPanelControls.Controls.Add(this.mobjOpenButton);
                this.mobjPanelControls.Controls.Add(this.mobjCancelButton);
                this.mobjPanelControls.Controls.Add(this.mobjFilterComboBox);
                this.mobjPanelControls.Controls.Add(this.mobjFileNameTextBox);
                this.mobjPanelControls.Controls.Add(this.mobjFileNameLabel);
                this.mobjPanelControls.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjPanelControls.Location = new System.Drawing.Point(0, 324);
                this.mobjPanelControls.Name = "mobjPanelControls";
                this.mobjPanelControls.Size = new System.Drawing.Size(600, 70);
                this.mobjPanelControls.TabIndex = 0;
                // 
                // mobjOpenButton
                // 
                this.mobjOpenButton.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjOpenButton.Location = new System.Drawing.Point(400, 37);
                this.mobjOpenButton.Name = "mobjOpenButton";
                this.mobjOpenButton.Size = new System.Drawing.Size(86, 23);
                this.mobjOpenButton.TabIndex = 4;
                this.mobjOpenButton.Text = "Open";
                this.mobjOpenButton.Enabled = false;
                this.mobjOpenButton.Click += new System.EventHandler(this.mobjOpenButton_Click);
                // 
                // mobjCancelButton
                // 
                this.mobjCancelButton.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjCancelButton.Location = new System.Drawing.Point(502, 37);
                this.mobjCancelButton.Name = "mobjCancelButton";
                this.mobjCancelButton.Size = new System.Drawing.Size(86, 23);
                this.mobjCancelButton.TabIndex = 3;
                this.mobjCancelButton.Text = "Cancel";
                this.mobjCancelButton.Click += new System.EventHandler(this.mobjCancelButton_Click);
                // 
                // mobjFilterComboBox
                // 
                this.mobjFilterComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjFilterComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
                this.mobjFilterComboBox.FormattingEnabled = true;
                this.mobjFilterComboBox.Location = new System.Drawing.Point(400, 9);
                this.mobjFilterComboBox.Name = "mobjFilterComboBox";
                this.mobjFilterComboBox.Size = new System.Drawing.Size(188, 21);
                this.mobjFilterComboBox.TabIndex = 2;
                this.mobjFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjFilterComboBox_SelectedIndexChanged);
                // 
                // mobjFileNameTextBox
                // 
                this.mobjFileNameTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjFileNameTextBox.Location = new System.Drawing.Point(142, 9);
                this.mobjFileNameTextBox.Name = "mobjFileNameTextBox";
                this.mobjFileNameTextBox.ReadOnly = true;
                this.mobjFileNameTextBox.Size = new System.Drawing.Size(243, 20);
                this.mobjFileNameTextBox.TabIndex = 1;
                // 
                // mobjFileNameLabel
                // 
                this.mobjFileNameLabel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
                this.mobjFileNameLabel.Location = new System.Drawing.Point(9, 9);
                this.mobjFileNameLabel.Name = "mobjFileNameLabel";
                this.mobjFileNameLabel.Size = new System.Drawing.Size(130, 60);
                this.mobjFileNameLabel.TabIndex = 0;
                this.mobjFileNameLabel.Text = "File name:";
                this.mobjFileNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
                // 
                // mobjFoldersPanel
                // 
                this.mobjFoldersPanel.Controls.Add(this.mobjFoldersTreeView);
                this.mobjFoldersPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
                this.mobjFoldersPanel.Location = new System.Drawing.Point(0, 0);
                this.mobjFoldersPanel.Name = "mobjFoldersPanel";
                this.mobjFoldersPanel.Size = new System.Drawing.Size(200, 330);
                this.mobjFoldersPanel.TabIndex = 1;
                // 
                // mobjFoldersTreeView
                // 
                this.mobjFoldersTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjFoldersTreeView.Location = new System.Drawing.Point(0, 0);
                this.mobjFoldersTreeView.Name = "mobjFoldersTreeView";
                this.mobjFoldersTreeView.Size = new System.Drawing.Size(200, 330);
                this.mobjFoldersTreeView.TabIndex = 0;
                // 
                // mobjSplitter
                // 
                this.mobjSplitter.Location = new System.Drawing.Point(200, 0);
                this.mobjSplitter.Name = "mobjSplitter";
                this.mobjSplitter.Size = new System.Drawing.Size(3, 330);
                this.mobjSplitter.TabIndex = 2;
                this.mobjSplitter.TabStop = false;
                // 
                // mobjFilesPanel
                // 
                this.mobjFilesPanel.Controls.Add(this.mobjFilesListView);
                this.mobjFilesPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjFilesPanel.Location = new System.Drawing.Point(203, 0);
                this.mobjFilesPanel.Name = "mobjFilesPanel";
                this.mobjFilesPanel.Size = new System.Drawing.Size(397, 330);
                this.mobjFilesPanel.TabIndex = 3;
                // 
                // mobjFilesListView
                // 
                this.mobjFilesListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjNameColumnHeader,
            this.mobjDateColumnHeader,
            this.mobjTypeColumnHeader,
            this.mobjSizeColumnHeader});
                this.mobjFilesListView.ContextMenuStrip = this.mobjListViewContextMenuStrip;
                this.mobjFilesListView.DataMember = null;
                this.mobjFilesListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjFilesListView.Location = new System.Drawing.Point(0, 0);
                this.mobjFilesListView.MultiSelect = false;
                this.mobjFilesListView.Name = "mobjFilesListView";
                this.mobjFilesListView.Size = new System.Drawing.Size(397, 330);
                this.mobjFilesListView.TabIndex = 0;
                this.mobjFilesListView.SelectedIndexChanged += mobjFilesListView_SelectedIndexChanged;
                // 
                // mobjNameColumnHeader
                // 
                this.mobjNameColumnHeader.Text = "Name";
                this.mobjNameColumnHeader.Width = 150;
                // 
                // mobjDateColumnHeader
                // 
                this.mobjDateColumnHeader.Text = "Date";
                this.mobjDateColumnHeader.Width = 150;
                // 
                // mobjTypeColumnHeader
                // 
                this.mobjTypeColumnHeader.Text = "Type";
                this.mobjTypeColumnHeader.Width = 150;
                // 
                // mobjSizeColumnHeader
                // 
                this.mobjSizeColumnHeader.Text = "Size";
                this.mobjSizeColumnHeader.Width = 150;
                // 
                // mobjListViewContextMenuStrip
                // 
                this.mobjListViewContextMenuStrip.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
                this.mobjListViewContextMenuStrip.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))));
                this.mobjListViewContextMenuStrip.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
                this.mobjListViewContextMenuStrip.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1);
                this.mobjListViewContextMenuStrip.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.mobjViewToolStripMenuItem});
                this.mobjListViewContextMenuStrip.Name = "mobjListViewContextMenuStrip";
                this.mobjListViewContextMenuStrip.Size = new System.Drawing.Size(100, 25);
                // 
                // mobjViewToolStripMenuItem
                // 
                this.mobjViewToolStripMenuItem.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.objDetailsToolStripMenuItem,
            this.mobjLargeIconToolStripMenuItem,
            this.mobjListToolStripMenuItem,
            this.mobjSmallIconToolStripMenuItem});
                this.mobjViewToolStripMenuItem.Name = "mobjViewToolStripMenuItem";
                this.mobjViewToolStripMenuItem.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
                this.mobjViewToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
                this.mobjViewToolStripMenuItem.Text = "View";
                // 
                // objDetailsToolStripMenuItem
                // 
                this.objDetailsToolStripMenuItem.Name = "objDetailsToolStripMenuItem";
                this.objDetailsToolStripMenuItem.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
                this.objDetailsToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
                this.objDetailsToolStripMenuItem.Tag = "Details";
                this.objDetailsToolStripMenuItem.Text = "Details";
                this.objDetailsToolStripMenuItem.Click += new System.EventHandler(this.ChangeView);
                // 
                // mobjLargeIconToolStripMenuItem
                // 
                this.mobjLargeIconToolStripMenuItem.Name = "mobjLargeIconToolStripMenuItem";
                this.mobjLargeIconToolStripMenuItem.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
                this.mobjLargeIconToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
                this.mobjLargeIconToolStripMenuItem.Tag = "LargeIcon";
                this.mobjLargeIconToolStripMenuItem.Text = "Large Icons";
                this.mobjLargeIconToolStripMenuItem.Click += new System.EventHandler(this.ChangeView);
                // 
                // mobjListToolStripMenuItem
                // 
                this.mobjListToolStripMenuItem.Name = "mobjListToolStripMenuItem";
                this.mobjListToolStripMenuItem.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
                this.mobjListToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
                this.mobjListToolStripMenuItem.Tag = "List";
                this.mobjListToolStripMenuItem.Text = "List";
                this.mobjListToolStripMenuItem.Click += new System.EventHandler(this.ChangeView);
                // 
                // mobjSmallIconToolStripMenuItem
                // 
                this.mobjSmallIconToolStripMenuItem.Name = "mobjSmallIconToolStripMenuItem";
                this.mobjSmallIconToolStripMenuItem.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
                this.mobjSmallIconToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
                this.mobjSmallIconToolStripMenuItem.Tag = "SmallIcon";
                this.mobjSmallIconToolStripMenuItem.Text = "Small Icons";
                this.mobjSmallIconToolStripMenuItem.Click += new System.EventHandler(this.ChangeView);
                // 
                // ServerOpenFileDialogForm
                // 
                this.AcceptButton = this.mobjOpenButton;
                this.CancelButton = this.mobjCancelButton;
                this.Controls.Add(this.mobjFilesPanel);
                this.Controls.Add(this.mobjSplitter);
                this.Controls.Add(this.mobjFoldersPanel);
                this.Controls.Add(this.mobjPanelControls);
                this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.SizableToolWindow;
                this.Size = new System.Drawing.Size(600, 400);
                this.Text = "Open";
                this.mobjPanelControls.ResumeLayout(false);
                this.mobjFoldersPanel.ResumeLayout(false);
                this.mobjFilesPanel.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the server open file dialog owner.
            /// </summary>
            /// <value>
            /// The server open file dialog owner.
            /// </value>
            private ServerOpenFileDialog ServerOpenFileDialogOwner
            {
                get
                {
                    return (ServerOpenFileDialog)this.CommonDialogOwner;
                }
            }

            /// <summary>
            /// Gets the filter.
            /// </summary>
            /// <value>
            /// The filter.
            /// </value>
            private string Filter
            {
                get
                {
                    return this.ServerOpenFileDialogOwner.Filter;
                }
            }


            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>
            /// The name of the file.
            /// </value>
            private string FileName
            {
                get
                {
                    return this.ServerOpenFileDialogOwner.FileName;
                }
                set
                {
                    this.ServerOpenFileDialogOwner.FileName = value;
                }
            }


            #endregion Properties

            #region Methods

            /// <summary>
            /// Resets all.
            /// </summary>
            private void ResetAll()
            {
                FillFilterCombo();

                UpdateSelectedFile(string.Empty);
                mobjFilesListView.Items.Clear();
                mobjFoldersTreeView.Nodes.Clear();

                mstrIconsFolder = this.Context.Config.GetDirectory("Icons").ToLower(CultureInfo.InvariantCulture);
                AddRootFolder(mstrIconsFolder);

                mstrImagesFolder = this.Context.Config.GetDirectory("Images").ToLower(CultureInfo.InvariantCulture);
                AddRootFolder(mstrImagesFolder);
            }

            /// <summary>
            /// Fills the filter combo.
            /// </summary>
            private void FillFilterCombo()
            {
                mobjFilterComboBox.Items.Clear();
                string strFilter = this.Filter;
                if (!string.IsNullOrEmpty(strFilter))
                {
                    string[] arrFilters = strFilter.Split('|');
                    for (int i = 0; i < arrFilters.Length; i = i + 2)
                    {
                        mobjFilterComboBox.Items.Add(new FilterComboItem(arrFilters[i], arrFilters[i + 1]));
                    }

                    if (mobjFilterComboBox.Items.Count > 0)
                    {
                        mobjFilterComboBox.SelectedIndex = 0;
                    }
                }
            }

            /// <summary>
            /// Adds the root folder.
            /// </summary>
            /// <param name="strFolder">The STR folder.</param>
            private void AddRootFolder(string strFolder)
            {
                if (System.IO.Directory.Exists(strFolder))
                {
                    DirectoryInfo objDir = new DirectoryInfo(strFolder);
                    CreateFolderNode(objDir, mobjFoldersTreeView.Nodes);
                }
            }

            /// <summary>
            /// Creates the folder node.
            /// </summary>
            /// <param name="objDir">The obj dir.</param>
            /// <param name="objParent">The obj parent.</param>
            /// <returns></returns>
            private TreeNode CreateFolderNode(DirectoryInfo objDir, TreeNodeCollection objParent)
            {
                TreeNode objTreeNode = new TreeNode(objDir.Name);
                objTreeNode.Text = objDir.Name;
                objTreeNode.Tag = objDir.FullName;
                objTreeNode.HasNodes = objDir.GetDirectories().Length > 0;
                objTreeNode.BeforeExpand += objFolder_BeforeExpand;
                objTreeNode.AfterSelect += objTreeNode_AfterSelect;
                objParent.Add(objTreeNode);

                return objTreeNode;
            }

            /// <summary>
            /// Handles the AfterSelect event of the objTreeNode control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
            private void objTreeNode_AfterSelect(object sender, TreeViewEventArgs e)
            {
                UpdateFileList();
            }

            /// <summary>
            /// Updates the file list.
            /// </summary>
            private void UpdateFileList()
            {
                string strFilter = string.Empty;

                mobjFilesListView.Items.Clear();

                UpdateSelectedFile(string.Empty);

                TreeNode objTreeNode = mobjFoldersTreeView.SelectedNode;
                if (objTreeNode != null)
                {
                    FilterComboItem objFilterItem = mobjFilterComboBox.SelectedItem as FilterComboItem;
                    if (objFilterItem != null)
                    {
                        strFilter = objFilterItem.Filter;
                    }

                    DirectoryInfo objDir = new DirectoryInfo(objTreeNode.Tag.ToString());

                    if (objDir != null)
                    {
                        foreach (FileInfo objFile in objDir.GetFiles())
                        {
                            if (ShouldAddFile(objFile.Name, strFilter))
                            {
                                string strFileName;
                                ListViewItem objItem = new ListViewItem(objFile.Name);
                                objItem.LargeImage = objItem.SmallImage = CreateResourceHandle(objFile, out strFileName);
                                objItem.SubItems.Add(objFile.Length.ToString());
                                objItem.SubItems.Add(objFile.Extension);
                                objItem.SubItems.Add(objFile.LastWriteTime.ToString());

                                objItem.Tag = objFile;

                                mobjFilesListView.Items.Add(objItem);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Shoulds the add file.
            /// </summary>
            /// <param name="strFileName">Name of the STR file.</param>
            /// <param name="strFilter">The STR filter.</param>
            /// <returns></returns>
            private bool ShouldAddFile(string strFileName, string strFilter)
            {
                foreach (string strOneFilter in strFilter.Split(';'))
                {
                    strFilter = strOneFilter.TrimStart('*').ToLower(CultureInfo.InvariantCulture);
                    if (strFileName.ToLower(CultureInfo.InvariantCulture).EndsWith(strFilter))
                    {
                        return true;
                    }
                }

                return false;

            }

            /// <summary>
            /// Creates the resource handle.
            /// </summary>
            /// <param name="objFile">The obj file.</param>
            /// <param name="strFileName">Name of the STR file.</param>
            /// <returns></returns>
            private ResourceHandle CreateResourceHandle(FileInfo objFile, out string strFileName)
            {
                strFileName = string.Empty;

                if (objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(mstrIconsFolder))
                {
                    strFileName = objFile.FullName.Remove(0, mstrIconsFolder.Length + 1).Replace("\\", ".");
                    return new IconResourceHandle(strFileName);
                }
                else if (objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(mstrImagesFolder))
                {
                    strFileName = objFile.FullName.Remove(0, mstrImagesFolder.Length + 1).Replace("\\", ".");
                    return new ImageResourceHandle(strFileName);
                }

                return null;
            }

            /// <summary>
            /// Handles the BeforeExpand event of the objFolder control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
            void objFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
            {
                TreeNode objTreeNode = e.Node;

                objTreeNode.Loaded = true;

                DirectoryInfo objDir = new DirectoryInfo(objTreeNode.Tag.ToString());
                foreach (DirectoryInfo objSubFolder in objDir.GetDirectories())
                {
                    CreateFolderNode(objSubFolder, objTreeNode.Nodes);
                }
            }

            /// <summary>
            /// Changes the view.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void ChangeView(object sender, EventArgs e)
            {
                ToolStripItem objToolStripItem = sender as ToolStripItem;
                if (objToolStripItem != null)
                {
                    string strView = objToolStripItem.Tag as string;
                    if (!string.IsNullOrEmpty(strView))
                    {
                        mobjFilesListView.View = (View)Enum.Parse(typeof(View), strView);
                    }
                }
            }

            /// <summary>
            /// Handles the SelectedIndexChanged event of the mobjFilesListView control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void mobjFilesListView_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                if (mobjFilesListView.SelectedItem != null)
                {
                    string strFIleName = string.Empty;
                    FileInfo objFileInfo = mobjFilesListView.SelectedItem.Tag as FileInfo;
                    if (objFileInfo != null)
                    {
                        strFIleName = objFileInfo.Name;
                    }
                    UpdateSelectedFile(strFIleName);
                }
            }

            /// <summary>
            /// Updates the selected file.
            /// </summary>
            /// <param name="strFileName">Name of the STR file.</param>
            private void UpdateSelectedFile(string strFileName)
            {
                mobjFileNameTextBox.Text = strFileName;
                if (string.IsNullOrEmpty(strFileName))
                {
                    mobjOpenButton.Enabled = false;
                }
                else
                {
                    mobjOpenButton.Enabled = true;
                }
            }

            /// <summary>
            /// Handles the Click event of the mobjOpenButton control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void mobjOpenButton_Click(object sender, EventArgs e)
            {
                // Set dialog result to OK 
                this.DialogResult = DialogResult.OK;

                FileInfo objFileInfo = mobjFilesListView.SelectedItem.Tag as FileInfo;
                if (objFileInfo != null)
                {
                    this.FileName = objFileInfo.FullName;
                }

                this.Close();
            }

            /// <summary>
            /// Handles the Click event of the mobjCancelButton control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void mobjCancelButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            /// <summary>
            /// Handles the SelectedIndexChanged event of the mobjFilterComboBox control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void mobjFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                UpdateFileList();
            }

            #endregion Methods


            #region FilterComboItem Class

            /// <summary>
            /// 
            /// </summary>
            [Serializable()]
            private class FilterComboItem
            {
                private string mstrDisplayName;
                private string mstrFilter;

                public FilterComboItem(string strDisplayName, string strFilter)
                {
                    mstrDisplayName = strDisplayName;
                    mstrFilter = strFilter;
                }

                /// <summary>
                /// Gets the filter.
                /// </summary>
                /// <value>
                /// The filter.
                /// </value>
                public string Filter
                {
                    get
                    {
                        return mstrFilter;
                    }
                }

                /// <summary>
                /// Returns a <see cref="System.String" /> that represents this instance.
                /// </summary>
                /// <returns>
                /// A <see cref="System.String" /> that represents this instance.
                /// </returns>
                public override string ToString()
                {
                    return mstrDisplayName;
                }
            }


            #endregion FilterComboItem Class
        }

        #endregion ServerOpenFileDialogForm Class
    }
}
