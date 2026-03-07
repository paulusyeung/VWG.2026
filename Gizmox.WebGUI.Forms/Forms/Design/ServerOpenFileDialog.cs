// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ServerOpenFileDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class ServerOpenFileDialog : CommonDialog
  {
    private const string DEFAULT_FILTER = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";
    private string mstrFileName = string.Empty;
    private string mstrFilter = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";

    public event EventHandler FileOk;

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new ServerOpenFileDialog.ServerOpenFileDialogForm((CommonDialog) this);

    /// <summary>
    /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
    /// </summary>
    public override void Reset() => this.mstrFilter = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data.</param>
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      if (this.DialogResult != DialogResult.OK)
        return;
      this.OnFileOk(new EventArgs());
    }

    /// <summary>
    /// Raises the <see cref="E:FileOk" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnFileOk(EventArgs e)
    {
      EventHandler fileOk = this.FileOk;
      if (fileOk == null)
        return;
      fileOk((object) this, e);
    }

    /// <summary>Gets or sets the filter.</summary>
    /// <value>The filter.</value>
    /// <exception cref="T:System.ArgumentException"></exception>
    public string Filter
    {
      get => this.mstrFilter;
      set
      {
        if (!string.IsNullOrEmpty(value))
        {
          string[] strArray = value.Split('|');
          if (strArray == null || strArray.Length % 2 != 0)
            throw new ArgumentException(Gizmox.WebGUI.Forms.SR.GetString("FileDialogInvalidFilter"));
        }
        this.mstrFilter = value;
      }
    }

    /// <summary>Gets or sets the name of the file.</summary>
    /// <value>The name of the file.</value>
    public string FileName
    {
      get => this.mstrFileName;
      internal set => this.mstrFileName = value;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class ServerOpenFileDialogForm : CommonDialog.CommonDialogForm
    {
      private string mstrIconsFolder = string.Empty;
      private string mstrImagesFolder = string.Empty;
      private IContainer components;
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

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.ServerOpenFileDialog.ServerOpenFileDialogForm" /> class.
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public ServerOpenFileDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.InitializeComponent();
        this.ResetAll();
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.components = (IContainer) new System.ComponentModel.Container();
        this.mobjPanelControls = new Panel();
        this.mobjOpenButton = new Button();
        this.mobjCancelButton = new Button();
        this.mobjFilterComboBox = new ComboBox();
        this.mobjFileNameTextBox = new TextBox();
        this.mobjFileNameLabel = new Label();
        this.mobjFoldersPanel = new Panel();
        this.mobjFoldersTreeView = new TreeView();
        this.mobjSplitter = new Splitter();
        this.mobjFilesPanel = new Panel();
        this.mobjFilesListView = new ListView();
        this.mobjNameColumnHeader = new ColumnHeader();
        this.mobjDateColumnHeader = new ColumnHeader();
        this.mobjTypeColumnHeader = new ColumnHeader();
        this.mobjSizeColumnHeader = new ColumnHeader();
        this.mobjListViewContextMenuStrip = new ContextMenuStrip(this.components);
        this.mobjViewToolStripMenuItem = new ToolStripMenuItem();
        this.objDetailsToolStripMenuItem = new ToolStripMenuItem();
        this.mobjLargeIconToolStripMenuItem = new ToolStripMenuItem();
        this.mobjListToolStripMenuItem = new ToolStripMenuItem();
        this.mobjSmallIconToolStripMenuItem = new ToolStripMenuItem();
        this.mobjPanelControls.SuspendLayout();
        this.mobjFoldersPanel.SuspendLayout();
        this.mobjFilesPanel.SuspendLayout();
        this.SuspendLayout();
        this.mobjPanelControls.Controls.Add((Control) this.mobjOpenButton);
        this.mobjPanelControls.Controls.Add((Control) this.mobjCancelButton);
        this.mobjPanelControls.Controls.Add((Control) this.mobjFilterComboBox);
        this.mobjPanelControls.Controls.Add((Control) this.mobjFileNameTextBox);
        this.mobjPanelControls.Controls.Add((Control) this.mobjFileNameLabel);
        this.mobjPanelControls.Dock = DockStyle.Bottom;
        this.mobjPanelControls.Location = new Point(0, 324);
        this.mobjPanelControls.Name = "mobjPanelControls";
        this.mobjPanelControls.Size = new Size(600, 70);
        this.mobjPanelControls.TabIndex = 0;
        this.mobjOpenButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjOpenButton.Location = new Point(400, 37);
        this.mobjOpenButton.Name = "mobjOpenButton";
        this.mobjOpenButton.Size = new Size(86, 23);
        this.mobjOpenButton.TabIndex = 4;
        this.mobjOpenButton.Text = "Open";
        this.mobjOpenButton.Enabled = false;
        this.mobjOpenButton.Click += new EventHandler(this.mobjOpenButton_Click);
        this.mobjCancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjCancelButton.Location = new Point(502, 37);
        this.mobjCancelButton.Name = "mobjCancelButton";
        this.mobjCancelButton.Size = new Size(86, 23);
        this.mobjCancelButton.TabIndex = 3;
        this.mobjCancelButton.Text = "Cancel";
        this.mobjCancelButton.Click += new EventHandler(this.mobjCancelButton_Click);
        this.mobjFilterComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.mobjFilterComboBox.FormattingEnabled = true;
        this.mobjFilterComboBox.Location = new Point(400, 9);
        this.mobjFilterComboBox.Name = "mobjFilterComboBox";
        this.mobjFilterComboBox.Size = new Size(188, 21);
        this.mobjFilterComboBox.TabIndex = 2;
        this.mobjFilterComboBox.SelectedIndexChanged += new EventHandler(this.mobjFilterComboBox_SelectedIndexChanged);
        this.mobjFileNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.mobjFileNameTextBox.Location = new Point(142, 9);
        this.mobjFileNameTextBox.Name = "mobjFileNameTextBox";
        this.mobjFileNameTextBox.ReadOnly = true;
        this.mobjFileNameTextBox.Size = new Size(243, 20);
        this.mobjFileNameTextBox.TabIndex = 1;
        this.mobjFileNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        this.mobjFileNameLabel.Location = new Point(9, 9);
        this.mobjFileNameLabel.Name = "mobjFileNameLabel";
        this.mobjFileNameLabel.Size = new Size(130, 60);
        this.mobjFileNameLabel.TabIndex = 0;
        this.mobjFileNameLabel.Text = "File name:";
        this.mobjFileNameLabel.TextAlign = ContentAlignment.TopRight;
        this.mobjFoldersPanel.Controls.Add((Control) this.mobjFoldersTreeView);
        this.mobjFoldersPanel.Dock = DockStyle.Left;
        this.mobjFoldersPanel.Location = new Point(0, 0);
        this.mobjFoldersPanel.Name = "mobjFoldersPanel";
        this.mobjFoldersPanel.Size = new Size(200, 330);
        this.mobjFoldersPanel.TabIndex = 1;
        this.mobjFoldersTreeView.Dock = DockStyle.Fill;
        this.mobjFoldersTreeView.Location = new Point(0, 0);
        this.mobjFoldersTreeView.Name = "mobjFoldersTreeView";
        this.mobjFoldersTreeView.Size = new Size(200, 330);
        this.mobjFoldersTreeView.TabIndex = 0;
        this.mobjSplitter.Location = new Point(200, 0);
        this.mobjSplitter.Name = "mobjSplitter";
        this.mobjSplitter.Size = new Size(3, 330);
        this.mobjSplitter.TabIndex = 2;
        this.mobjSplitter.TabStop = false;
        this.mobjFilesPanel.Controls.Add((Control) this.mobjFilesListView);
        this.mobjFilesPanel.Dock = DockStyle.Fill;
        this.mobjFilesPanel.Location = new Point(203, 0);
        this.mobjFilesPanel.Name = "mobjFilesPanel";
        this.mobjFilesPanel.Size = new Size(397, 330);
        this.mobjFilesPanel.TabIndex = 3;
        this.mobjFilesListView.Columns.AddRange(new ColumnHeader[4]
        {
          this.mobjNameColumnHeader,
          this.mobjDateColumnHeader,
          this.mobjTypeColumnHeader,
          this.mobjSizeColumnHeader
        });
        this.mobjFilesListView.ContextMenuStrip = this.mobjListViewContextMenuStrip;
        this.mobjFilesListView.DataMember = (string) null;
        this.mobjFilesListView.Dock = DockStyle.Fill;
        this.mobjFilesListView.Location = new Point(0, 0);
        this.mobjFilesListView.MultiSelect = false;
        this.mobjFilesListView.Name = "mobjFilesListView";
        this.mobjFilesListView.Size = new Size(397, 330);
        this.mobjFilesListView.TabIndex = 0;
        this.mobjFilesListView.SelectedIndexChanged += new EventHandler(this.mobjFilesListView_SelectedIndexChanged);
        this.mobjNameColumnHeader.Text = "Name";
        this.mobjNameColumnHeader.Width = 150;
        this.mobjDateColumnHeader.Text = "Date";
        this.mobjDateColumnHeader.Width = 150;
        this.mobjTypeColumnHeader.Text = "Type";
        this.mobjTypeColumnHeader.Width = 150;
        this.mobjSizeColumnHeader.Text = "Size";
        this.mobjSizeColumnHeader.Width = 150;
        this.mobjListViewContextMenuStrip.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        this.mobjListViewContextMenuStrip.BorderColor = new BorderColor(Color.FromArgb(101, 147, 207));
        this.mobjListViewContextMenuStrip.BorderStyle = BorderStyle.None;
        this.mobjListViewContextMenuStrip.BorderWidth = new BorderWidth(1);
        this.mobjListViewContextMenuStrip.Items.AddRange(new ToolStripItem[1]
        {
          (ToolStripItem) this.mobjViewToolStripMenuItem
        });
        this.mobjListViewContextMenuStrip.Name = "mobjListViewContextMenuStrip";
        this.mobjListViewContextMenuStrip.Size = new Size(100, 25);
        this.mobjViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
        {
          (ToolStripItem) this.objDetailsToolStripMenuItem,
          (ToolStripItem) this.mobjLargeIconToolStripMenuItem,
          (ToolStripItem) this.mobjListToolStripMenuItem,
          (ToolStripItem) this.mobjSmallIconToolStripMenuItem
        });
        this.mobjViewToolStripMenuItem.Name = "mobjViewToolStripMenuItem";
        this.mobjViewToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
        this.mobjViewToolStripMenuItem.Size = new Size(96, 20);
        this.mobjViewToolStripMenuItem.Text = "View";
        this.objDetailsToolStripMenuItem.Name = "objDetailsToolStripMenuItem";
        this.objDetailsToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
        this.objDetailsToolStripMenuItem.Size = new Size(106, 20);
        this.objDetailsToolStripMenuItem.Tag = (object) "Details";
        this.objDetailsToolStripMenuItem.Text = "Details";
        this.objDetailsToolStripMenuItem.Click += new EventHandler(this.ChangeView);
        this.mobjLargeIconToolStripMenuItem.Name = "mobjLargeIconToolStripMenuItem";
        this.mobjLargeIconToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
        this.mobjLargeIconToolStripMenuItem.Size = new Size(130, 20);
        this.mobjLargeIconToolStripMenuItem.Tag = (object) "LargeIcon";
        this.mobjLargeIconToolStripMenuItem.Text = "Large Icons";
        this.mobjLargeIconToolStripMenuItem.Click += new EventHandler(this.ChangeView);
        this.mobjListToolStripMenuItem.Name = "mobjListToolStripMenuItem";
        this.mobjListToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
        this.mobjListToolStripMenuItem.Size = new Size(130, 20);
        this.mobjListToolStripMenuItem.Tag = (object) "List";
        this.mobjListToolStripMenuItem.Text = "List";
        this.mobjListToolStripMenuItem.Click += new EventHandler(this.ChangeView);
        this.mobjSmallIconToolStripMenuItem.Name = "mobjSmallIconToolStripMenuItem";
        this.mobjSmallIconToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
        this.mobjSmallIconToolStripMenuItem.Size = new Size(130, 20);
        this.mobjSmallIconToolStripMenuItem.Tag = (object) "SmallIcon";
        this.mobjSmallIconToolStripMenuItem.Text = "Small Icons";
        this.mobjSmallIconToolStripMenuItem.Click += new EventHandler(this.ChangeView);
        this.AcceptButton = (IButtonControl) this.mobjOpenButton;
        this.CancelButton = (IButtonControl) this.mobjCancelButton;
        this.Controls.Add((Control) this.mobjFilesPanel);
        this.Controls.Add((Control) this.mobjSplitter);
        this.Controls.Add((Control) this.mobjFoldersPanel);
        this.Controls.Add((Control) this.mobjPanelControls);
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.Size = new Size(600, 400);
        this.Text = "Open";
        this.mobjPanelControls.ResumeLayout(false);
        this.mobjFoldersPanel.ResumeLayout(false);
        this.mobjFilesPanel.ResumeLayout(false);
        this.ResumeLayout(false);
      }

      /// <summary>Gets the server open file dialog owner.</summary>
      /// <value>The server open file dialog owner.</value>
      private ServerOpenFileDialog ServerOpenFileDialogOwner => (ServerOpenFileDialog) this.CommonDialogOwner;

      /// <summary>Gets the filter.</summary>
      /// <value>The filter.</value>
      private string Filter => this.ServerOpenFileDialogOwner.Filter;

      /// <summary>Gets or sets the name of the file.</summary>
      /// <value>The name of the file.</value>
      private string FileName
      {
        get => this.ServerOpenFileDialogOwner.FileName;
        set => this.ServerOpenFileDialogOwner.FileName = value;
      }

      /// <summary>Resets all.</summary>
      private void ResetAll()
      {
        this.FillFilterCombo();
        this.UpdateSelectedFile(string.Empty);
        this.mobjFilesListView.Items.Clear();
        this.mobjFoldersTreeView.Nodes.Clear();
        this.mstrIconsFolder = this.Context.Config.GetDirectory("Icons").ToLower(CultureInfo.InvariantCulture);
        this.AddRootFolder(this.mstrIconsFolder);
        this.mstrImagesFolder = this.Context.Config.GetDirectory("Images").ToLower(CultureInfo.InvariantCulture);
        this.AddRootFolder(this.mstrImagesFolder);
      }

      /// <summary>Fills the filter combo.</summary>
      private void FillFilterCombo()
      {
        this.mobjFilterComboBox.Items.Clear();
        string filter = this.Filter;
        if (string.IsNullOrEmpty(filter))
          return;
        string[] strArray = filter.Split('|');
        for (int index = 0; index < strArray.Length; index += 2)
          this.mobjFilterComboBox.Items.Add((object) new ServerOpenFileDialog.ServerOpenFileDialogForm.FilterComboItem(strArray[index], strArray[index + 1]));
        if (this.mobjFilterComboBox.Items.Count <= 0)
          return;
        this.mobjFilterComboBox.SelectedIndex = 0;
      }

      /// <summary>Adds the root folder.</summary>
      /// <param name="strFolder">The STR folder.</param>
      private void AddRootFolder(string strFolder)
      {
        if (!Directory.Exists(strFolder))
          return;
        this.CreateFolderNode(new DirectoryInfo(strFolder), this.mobjFoldersTreeView.Nodes);
      }

      /// <summary>Creates the folder node.</summary>
      /// <param name="objDir">The obj dir.</param>
      /// <param name="objParent">The obj parent.</param>
      /// <returns></returns>
      private TreeNode CreateFolderNode(DirectoryInfo objDir, TreeNodeCollection objParent)
      {
        TreeNode objTreeViewNode = new TreeNode(objDir.Name);
        objTreeViewNode.Text = objDir.Name;
        objTreeViewNode.Tag = (object) objDir.FullName;
        objTreeViewNode.HasNodes = objDir.GetDirectories().Length != 0;
        objTreeViewNode.BeforeExpand += new TreeViewCancelEventHandler(this.objFolder_BeforeExpand);
        objTreeViewNode.AfterSelect += new TreeViewEventHandler(this.objTreeNode_AfterSelect);
        objParent.Add(objTreeViewNode);
        return objTreeViewNode;
      }

      /// <summary>
      /// Handles the AfterSelect event of the objTreeNode control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
      private void objTreeNode_AfterSelect(object sender, TreeViewEventArgs e) => this.UpdateFileList();

      /// <summary>Updates the file list.</summary>
      private void UpdateFileList()
      {
        string strFilter = string.Empty;
        this.mobjFilesListView.Items.Clear();
        this.UpdateSelectedFile(string.Empty);
        TreeNode selectedNode = this.mobjFoldersTreeView.SelectedNode;
        if (selectedNode == null)
          return;
        if (this.mobjFilterComboBox.SelectedItem is ServerOpenFileDialog.ServerOpenFileDialogForm.FilterComboItem selectedItem)
          strFilter = selectedItem.Filter;
        DirectoryInfo directoryInfo = new DirectoryInfo(selectedNode.Tag.ToString());
        if (directoryInfo == null)
          return;
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
          if (this.ShouldAddFile(file.Name, strFilter))
          {
            ListViewItem objListViewItem = new ListViewItem(file.Name);
            ListViewItem listViewItem = objListViewItem;
            ResourceHandle resourceHandle1;
            ResourceHandle resourceHandle2 = resourceHandle1 = this.CreateResourceHandle(file, out string _);
            listViewItem.SmallImage = resourceHandle1;
            listViewItem.LargeImage = resourceHandle2;
            objListViewItem.SubItems.Add(file.Length.ToString());
            objListViewItem.SubItems.Add(file.Extension);
            objListViewItem.SubItems.Add(file.LastWriteTime.ToString());
            objListViewItem.Tag = (object) file;
            this.mobjFilesListView.Items.Add(objListViewItem);
          }
        }
      }

      /// <summary>Shoulds the add file.</summary>
      /// <param name="strFileName">Name of the STR file.</param>
      /// <param name="strFilter">The STR filter.</param>
      /// <returns></returns>
      private bool ShouldAddFile(string strFileName, string strFilter)
      {
        string str1 = strFilter;
        char[] chArray1 = new char[1]{ ';' };
        foreach (string str2 in str1.Split(chArray1))
        {
          char[] chArray2 = new char[1]{ '*' };
          strFilter = str2.TrimStart(chArray2).ToLower(CultureInfo.InvariantCulture);
          if (strFileName.ToLower(CultureInfo.InvariantCulture).EndsWith(strFilter))
            return true;
        }
        return false;
      }

      /// <summary>Creates the resource handle.</summary>
      /// <param name="objFile">The obj file.</param>
      /// <param name="strFileName">Name of the STR file.</param>
      /// <returns></returns>
      private ResourceHandle CreateResourceHandle(FileInfo objFile, out string strFileName)
      {
        strFileName = string.Empty;
        if (objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(this.mstrIconsFolder))
        {
          strFileName = objFile.FullName.Remove(0, this.mstrIconsFolder.Length + 1).Replace("\\", ".");
          return (ResourceHandle) new IconResourceHandle(strFileName);
        }
        if (!objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(this.mstrImagesFolder))
          return (ResourceHandle) null;
        strFileName = objFile.FullName.Remove(0, this.mstrImagesFolder.Length + 1).Replace("\\", ".");
        return (ResourceHandle) new ImageResourceHandle(strFileName);
      }

      /// <summary>
      /// Handles the BeforeExpand event of the objFolder control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
      private void objFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
      {
        TreeNode node = e.Node;
        node.Loaded = true;
        foreach (DirectoryInfo directory in new DirectoryInfo(node.Tag.ToString()).GetDirectories())
          this.CreateFolderNode(directory, node.Nodes);
      }

      /// <summary>Changes the view.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void ChangeView(object sender, EventArgs e)
      {
        if (!(sender is ToolStripItem toolStripItem))
          return;
        string tag = toolStripItem.Tag as string;
        if (string.IsNullOrEmpty(tag))
          return;
        this.mobjFilesListView.View = (View) Enum.Parse(typeof (View), tag);
      }

      /// <summary>
      /// Handles the SelectedIndexChanged event of the mobjFilesListView control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjFilesListView_SelectedIndexChanged(object sender, EventArgs e)
      {
        if (this.mobjFilesListView.SelectedItem == null)
          return;
        string strFileName = string.Empty;
        if (this.mobjFilesListView.SelectedItem.Tag is FileInfo tag)
          strFileName = tag.Name;
        this.UpdateSelectedFile(strFileName);
      }

      /// <summary>Updates the selected file.</summary>
      /// <param name="strFileName">Name of the STR file.</param>
      private void UpdateSelectedFile(string strFileName)
      {
        this.mobjFileNameTextBox.Text = strFileName;
        if (string.IsNullOrEmpty(strFileName))
          this.mobjOpenButton.Enabled = false;
        else
          this.mobjOpenButton.Enabled = true;
      }

      /// <summary>
      /// Handles the Click event of the mobjOpenButton control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjOpenButton_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.OK;
        if (this.mobjFilesListView.SelectedItem.Tag is FileInfo tag)
          this.FileName = tag.FullName;
        this.Close();
      }

      /// <summary>
      /// Handles the Click event of the mobjCancelButton control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjCancelButton_Click(object sender, EventArgs e) => this.Close();

      /// <summary>
      /// Handles the SelectedIndexChanged event of the mobjFilterComboBox control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjFilterComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateFileList();

      /// <summary>
      /// 
      /// </summary>
      [Serializable]
      private class FilterComboItem
      {
        private string mstrDisplayName;
        private string mstrFilter;

        public FilterComboItem(string strDisplayName, string strFilter)
        {
          this.mstrDisplayName = strDisplayName;
          this.mstrFilter = strFilter;
        }

        /// <summary>Gets the filter.</summary>
        /// <value>The filter.</value>
        public string Filter => this.mstrFilter;

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.mstrDisplayName;
      }
    }
  }
}
