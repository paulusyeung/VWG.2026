// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FolderBrowserDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Prompts the user to select a folder.
  /// This class can be inherited to provide default data source.
  /// </summary>
  /// <remarks>By default this dialog works on server side folders.</remarks>
  [DefaultEvent("HelpRequest")]
  [SRDescription("DescriptionFolderBrowserDialog")]
  [DefaultProperty("SelectedPath")]
  [ToolboxBitmap(typeof (FolderBrowserDialog), "FolderBrowserDialog_45.bmp")]
  [ToolboxItem(true)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FolderBrowserDialogSkin))]
  [Serializable]
  public class FolderBrowserDialog : CommonDialog
  {
    /// <summary>
    /// 
    /// </summary>
    private bool mblnSelectedPathNeedsCheck;
    /// <summary>
    /// 
    /// </summary>
    private Environment.SpecialFolder menmRootFolder;
    /// <summary>
    /// 
    /// </summary>
    private bool msblShowNewFolderButton;
    /// <summary>
    /// 
    /// </summary>
    private string mstrDescriptionText;
    /// <summary>
    /// 
    /// </summary>
    private string mstrSelectedPath;
    /// <summary>
    /// 
    /// </summary>
    private string mstrTitle;

    /// <summary>Occurs when the user clicks the Help button on the dialog box.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler HelpRequest;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:FolderBrowserDialog"></see> class.
    /// </summary>
    public FolderBrowserDialog() => this.Reset();

    /// <summary>Gets or sets the file dialog box title.</summary>
    /// <returns>The file dialog box title. The default value is an empty string ("").</returns>
    [DefaultValue("")]
    [Localizable(true)]
    [SRDescription("FDtitleDescr")]
    [SRCategory("CatAppearance")]
    public string Title
    {
      get => this.mstrTitle != null ? this.mstrTitle : string.Empty;
      set => this.mstrTitle = value;
    }

    /// <summary>
    /// Gets or sets the descriptive text displayed above the tree view control in the dialog box.
    /// </summary>
    /// <returns>
    /// The description to display. The default is an empty string ("").
    /// </returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    [SRCategory("CatFolderBrowsing")]
    [Browsable(true)]
    [Localizable(true)]
    [SRDescription("FolderBrowserDialogDescription")]
    public string Description
    {
      get => this.mstrDescriptionText;
      set => this.mstrDescriptionText = value == null ? string.Empty : value;
    }

    /// <summary>
    /// Gets or sets the root folder where the browsing starts from.
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:System.Environment.SpecialFolder"></see> values. The default is Desktop.
    /// </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
    /// The value assigned is not one of the <see cref="T:System.Environment.SpecialFolder"></see> values.
    /// </exception>
    [SRDescription("FolderBrowserDialogRootFolder")]
    [Browsable(true)]
    [DefaultValue(0)]
    [Localizable(false)]
    [SRCategory("CatFolderBrowsing")]
    public Environment.SpecialFolder RootFolder
    {
      get => this.menmRootFolder;
      set => this.menmRootFolder = Enum.IsDefined(typeof (Environment.SpecialFolder), (object) value) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (Environment.SpecialFolder));
    }

    /// <summary>Gets or sets the path selected by the user.</summary>
    /// <returns>
    /// The path of the folder first selected in the dialog box or the last folder selected by the user.
    /// The default is an empty string ("").
    /// </returns>
    [DefaultValue("")]
    [Browsable(true)]
    [SRCategory("CatFolderBrowsing")]
    [SRDescription("FolderBrowserDialogSelectedPath")]
    [Localizable(true)]
    public string SelectedPath
    {
      get => this.mstrSelectedPath;
      set => this.mstrSelectedPath = value == null ? string.Empty : value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the New Folder button
    /// appears in the folder browser dialog box.
    /// </summary>
    /// <returns>
    /// true if the New Folder button is shown in the dialog box;
    /// otherwise, false. The default is true.
    /// </returns>
    [DefaultValue(true)]
    [SRDescription("FolderBrowserDialogShowNewFolderButton")]
    [Localizable(false)]
    [SRCategory("CatFolderBrowsing")]
    [Browsable(true)]
    public bool ShowNewFolderButton
    {
      get => this.msblShowNewFolderButton;
      set => this.msblShowNewFolderButton = value;
    }

    /// <summary>Resets properties to their default values.</summary>
    public override void Reset()
    {
      this.menmRootFolder = Environment.SpecialFolder.Desktop;
      this.mstrDescriptionText = string.Empty;
      this.mstrSelectedPath = string.Empty;
      this.mblnSelectedPathNeedsCheck = false;
      this.msblShowNewFolderButton = true;
    }

    /// <summary>Create the folder browser dialog form</summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new FolderBrowserDialog.FolderBrowserDialogForm((CommonDialog) this);

    /// <summary>Gets the root folder.</summary>
    /// <returns></returns>
    protected virtual object GetRootFolder() => (object) new DirectoryInfo(Environment.GetFolderPath(this.menmRootFolder));

    /// <summary>Gets the folder icon.</summary>
    /// <param name="objFolder">The folder object.</param>
    /// <returns></returns>
    protected virtual ResourceHandle GetFolderIcon(object objFolder) => (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, "Folder.gif");

    /// <summary>Gets the folder label.</summary>
    /// <param name="objFolder">The folder object.</param>
    /// <returns></returns>
    protected virtual string GetFolderLabel(object objFolder) => objFolder is DirectoryInfo directoryInfo ? directoryInfo.Name : "Uknown";

    /// <summary>Gets the sub folders of the current folder.</summary>
    /// <param name="objFolder">The current folder.</param>
    /// <returns></returns>
    protected virtual ICollection GetSubFolders(object objFolder) => objFolder is DirectoryInfo directoryInfo ? (ICollection) directoryInfo.GetDirectories() : (ICollection) new object[0];

    /// <summary>
    /// Determines whether the specified folder has sub folders.
    /// </summary>
    /// <param name="objFolder">The obj folder.</param>
    /// <returns>
    /// 	<c>true</c> if specified folder has sub folders; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool HasSubFolders(object objFolder) => this.GetSubFolders(objFolder).Count > 0;

    /// <summary>Gets the folder path.</summary>
    /// <param name="objFolder">The folder to get its path.</param>
    /// <returns></returns>
    protected virtual string GetFolderPath(object objFolder) => objFolder is DirectoryInfo directoryInfo ? directoryInfo.FullName : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    protected class FolderBrowserDialogForm : CommonDialog.CommonDialogForm
    {
      private Button mobjButtonCancel;
      private Button mobjButtonCreate;
      private Button mobjButtonOK;
      private Label mobjLabelDescription;
      private TreeView mobjTreeFolders;
      /// <summary>Required designer variable.</summary>
      private IContainer objComponents;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FolderBrowserDialog.FolderBrowserDialogForm" /> class.
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public FolderBrowserDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.InitializeComponent();
      }

      /// <summary>Gets the folder browser dialog owner.</summary>
      /// <value>The folder browser dialog owner.</value>
      public FolderBrowserDialog FolderBrowserDialogOwner => (FolderBrowserDialog) this.CommonDialogOwner;

      private void FolderBrowserDialogForm_Load(object sender, EventArgs e)
      {
        this.mobjLabelDescription.Text = this.FolderBrowserDialogOwner.Description;
        this.mobjButtonCreate.Visible = this.FolderBrowserDialogOwner.ShowNewFolderButton;
        this.Text = this.FolderBrowserDialogOwner.Title;
        this.mobjTreeFolders.Nodes.Add(this.CreateFolderNode(this.FolderBrowserDialogOwner.GetRootFolder()));
        this.mobjTreeFolders.Nodes[0].Expand();
      }

      private TreeNode CreateFolderNode(object objFolder)
      {
        bool flag = this.FolderBrowserDialogOwner.HasSubFolders(objFolder);
        TreeNode folderNode = new TreeNode();
        folderNode.Text = this.FolderBrowserDialogOwner.GetFolderLabel(objFolder);
        folderNode.Image = this.FolderBrowserDialogOwner.GetFolderIcon(objFolder);
        folderNode.Loaded = !flag;
        folderNode.HasNodes = flag;
        folderNode.IsExpanded = !flag;
        folderNode.BeforeExpand += new TreeViewCancelEventHandler(this.objTreeNode_BeforeExpand);
        folderNode.Tag = objFolder;
        return folderNode;
      }

      private void CreateFolderNodes(TreeNode objTreeNode)
      {
        foreach (object subFolder in (IEnumerable) this.FolderBrowserDialogOwner.GetSubFolders(objTreeNode.Tag))
          objTreeNode.Nodes.Add(this.CreateFolderNode(subFolder));
      }

      private void objTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
      {
        if (objArgs.Node.Loaded)
          return;
        this.CreateFolderNodes(objArgs.Node);
        objArgs.Node.Loaded = true;
      }

      private void mobjTreeFolders_DoubleClick(object sender, EventArgs e) => this.DoOK();

      private void mobjTreeFolders_AfterSelect(object sender, TreeViewEventArgs e)
      {
      }

      private void mobjButtonCancel_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

      private void mobjButtonCreate_Click(object sender, EventArgs e)
      {
      }

      private void mobjButtonOK_Click(object sender, EventArgs e) => this.DoOK();

      private void DoOK()
      {
        if (this.mobjTreeFolders.SelectedNode == null)
          return;
        this.DialogResult = DialogResult.OK;
        this.FolderBrowserDialogOwner.SelectedPath = this.FolderBrowserDialogOwner.GetFolderPath(this.mobjTreeFolders.SelectedNode.Tag);
        this.Close();
      }

      /// <summary>Clean up any resources being used.</summary>
      /// <param name="blnDisposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool blnDisposing)
      {
        if (blnDisposing && this.objComponents != null)
          this.objComponents.Dispose();
        base.Dispose(blnDisposing);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjTreeFolders = new TreeView();
        this.mobjButtonCancel = new Button();
        this.mobjButtonOK = new Button();
        this.mobjButtonCreate = new Button();
        this.mobjLabelDescription = new Label();
        this.SuspendLayout();
        this.mobjTreeFolders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        this.mobjTreeFolders.Location = new Point(12, 61);
        this.mobjTreeFolders.Name = "mobjTreeFolders";
        this.mobjTreeFolders.Size = new Size(306, 230);
        this.mobjTreeFolders.TabIndex = 0;
        this.mobjTreeFolders.AfterSelect += new TreeViewEventHandler(this.mobjTreeFolders_AfterSelect);
        this.mobjTreeFolders.DoubleClick += new EventHandler(this.mobjTreeFolders_DoubleClick);
        this.mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjButtonCancel.Location = new Point(243, 302);
        this.mobjButtonCancel.Name = "mobjButtonCancel";
        this.mobjButtonCancel.Size = new Size(75, 23);
        this.mobjButtonCancel.TabIndex = 1;
        this.mobjButtonCancel.Text = WGLabels.Cancel;
        this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
        this.mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjButtonOK.Location = new Point(163, 302);
        this.mobjButtonOK.Name = "mobjButtonOK";
        this.mobjButtonOK.Size = new Size(75, 23);
        this.mobjButtonOK.TabIndex = 2;
        this.mobjButtonOK.Text = WGLabels.Ok;
        this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
        this.mobjButtonCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        this.mobjButtonCreate.Location = new Point(12, 302);
        this.mobjButtonCreate.Name = "mobjButtonCreate";
        this.mobjButtonCreate.Size = new Size(109, 23);
        this.mobjButtonCreate.TabIndex = 3;
        this.mobjButtonCreate.Text = WGLabels.MakeNewFolder;
        this.mobjButtonCreate.Click += new EventHandler(this.mobjButtonCreate_Click);
        this.mobjLabelDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        this.mobjLabelDescription.Location = new Point(13, 13);
        this.mobjLabelDescription.Name = "mobjLabelDescription";
        this.mobjLabelDescription.Size = new Size(305, 45);
        this.mobjLabelDescription.TabIndex = 4;
        this.mobjLabelDescription.Text = "Description";
        this.ClientSize = new Size(332, 337);
        this.Controls.Add((Control) this.mobjLabelDescription);
        this.Controls.Add((Control) this.mobjButtonCreate);
        this.Controls.Add((Control) this.mobjButtonOK);
        this.Controls.Add((Control) this.mobjButtonCancel);
        this.Controls.Add((Control) this.mobjTreeFolders);
        this.Load += new EventHandler(this.FolderBrowserDialogForm_Load);
        this.Name = "Form2";
        this.Text = nameof (FolderBrowserDialog);
        this.ResumeLayout(false);
      }
    }
  }
}
