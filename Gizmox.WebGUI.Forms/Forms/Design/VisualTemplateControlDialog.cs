// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>The dialog for the visual templates.</summary>
  [Serializable]
  public class VisualTemplateControlDialog : CommonDialog
  {
    private VisualTemplate mobjCurrentControlVisualTemplate;
    private Type mobjControlType;
    private Gizmox.WebGUI.Forms.Component mobjComponent;
    private string mstrDeviceId;
    private VisualTemplateService mobjVisualTemplateService = new VisualTemplateService();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog" /> class.
    /// </summary>
    /// <param name="objControlType">Type of the object control.</param>
    /// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
    /// <param name="objComponent">The object component.</param>
    public VisualTemplateControlDialog(
      Type objControlType,
      VisualTemplate objCurrentControlVisualTemplate,
      Gizmox.WebGUI.Forms.Component objComponent)
    {
      this.mobjControlType = objControlType;
      this.mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
      this.mstrDeviceId = (string) null;
      this.mobjComponent = objComponent;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog" /> class.
    /// </summary>
    /// <param name="objControlType">Type of the object control.</param>
    /// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
    /// <param name="objComponent">The object component.</param>
    /// <param name="strDeviceId">The string device unique identifier.</param>
    public VisualTemplateControlDialog(
      Type objControlType,
      VisualTemplate objCurrentControlVisualTemplate,
      Gizmox.WebGUI.Forms.Component objComponent,
      string strDeviceId)
    {
      this.mobjControlType = objControlType;
      this.mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
      this.mstrDeviceId = strDeviceId;
      this.mobjComponent = objComponent;
    }

    /// <summary>
    /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
    /// </summary>
    public override void Reset()
    {
    }

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new VisualTemplateControlDialog.VisualTemplateControlForm(this);

    /// <summary>Gets or sets the visual template.</summary>
    /// <value>The visual template.</value>
    public VisualTemplate VisualTemplate
    {
      get => this.mobjCurrentControlVisualTemplate;
      set => this.mobjCurrentControlVisualTemplate = value;
    }

    /// <summary>Gets the control visual template types.</summary>
    /// <returns></returns>
    private List<Type> GetControlVisualTemplateTypes() => this.mobjVisualTemplateService.GetVisualTemplates(this.mobjControlType);

    /// <summary>Gets the visual template description.</summary>
    /// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
    /// <returns></returns>
    private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate)
    {
      string templateDescription = string.Empty;
      if (Attribute.GetCustomAttribute((MemberInfo) objTypeOfVisualTemplate, typeof (VisualTemplateAttribute), true) is VisualTemplateAttribute customAttribute)
        templateDescription = customAttribute.Description;
      return templateDescription;
    }

    [Serializable]
    protected class VisualTemplateControlForm : CommonDialog.CommonDialogForm
    {
      /// <summary>Required designer variable.</summary>
      private IContainer components;
      private Panel mobjLeftPanel;
      private Splitter mobjSplitter;
      private Splitter mobjSplitter2;
      private Panel mobjRightPanel;
      private Button mbtnOkAction;
      private Button mbtnCancelAction;
      private PropertyGrid mobjPropertyGrid;
      private Panel mobjActionsPanel;
      private Panel mobjDescriptionPanel;
      private Label mobjDescriptionLabel;
      private ListView mobjListOfVisualTemplates;
      private ColumnHeader mobjColumnAppearanceName;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog.VisualTemplateControlForm" /> class.
      /// </summary>
      /// <param name="objVisualizerControlDialog">The object visualizer control dialog.</param>
      public VisualTemplateControlForm(
        VisualTemplateControlDialog objVisualizerControlDialog)
        : base((CommonDialog) objVisualizerControlDialog)
      {
        this.InitializeComponent();
        this.AcceptButton = (IButtonControl) this.mbtnOkAction;
        this.CancelButton = (IButtonControl) this.mbtnCancelAction;
        this.InitializeData();
      }

      /// <summary>Initializes the data.</summary>
      private void InitializeData()
      {
        VisualTemplateControlDialog commonDialogOwner = this.CommonDialogOwner as VisualTemplateControlDialog;
        this.mobjPropertyGrid.Tag = (object) commonDialogOwner.mobjComponent;
        if (commonDialogOwner == null)
          return;
        List<Type> visualTemplateTypes = commonDialogOwner.GetControlVisualTemplateTypes();
        VisualTemplate visualTemplate1 = commonDialogOwner.VisualTemplate;
        ImageList imageList = new ImageList();
        ListViewItem objListViewItem1 = new ListViewItem();
        imageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
        objListViewItem1.ImageIndex = 0;
        objListViewItem1.SubItems.Add("None");
        objListViewItem1.SubItems.Add(string.Empty);
        if (visualTemplate1 == null)
          objListViewItem1.Selected = true;
        this.mobjListOfVisualTemplates.Items.Add(objListViewItem1);
        if (visualTemplateTypes != null)
        {
          foreach (Type type in visualTemplateTypes)
          {
            ListViewItem objListViewItem2 = new ListViewItem();
            VisualTemplate visualTemplate2 = Activator.CreateInstance(type) as VisualTemplate;
            if (visualTemplate2 != null && commonDialogOwner.mobjComponent is Control mobjComponent)
            {
              VisualTemplate visualTemplate3 = visualTemplate2.GetDefault(mobjComponent);
              if (visualTemplate3 != null && visualTemplate3.GetType() == visualTemplate2.GetType())
                visualTemplate2 = visualTemplate3;
            }
            if (visualTemplate1 != null && visualTemplate1.GetType() == type)
            {
              visualTemplate2 = visualTemplate1;
              objListViewItem2.Selected = true;
              this.mobjPropertyGrid.SelectedObject = (object) visualTemplate1;
            }
            objListViewItem2.Tag = (object) visualTemplate2;
            objListViewItem2.SubItems.Add(visualTemplate2.ToString());
            objListViewItem2.SubItems.Add(this.GetVisualTemplateDescription(type));
            ResourceHandle visualizerImage = visualTemplate2.VisualizerImage;
            if (visualizerImage != null)
              imageList.Images.Add(visualizerImage);
            else
              imageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
            objListViewItem2.ImageIndex = imageList.Images.Count - 1;
            this.mobjListOfVisualTemplates.Items.Add(objListViewItem2);
          }
        }
        this.mobjListOfVisualTemplates.LargeImageList = imageList;
        imageList.ImageSize = new Size(200, 150);
        this.mobjListOfVisualTemplates.Font = new Font("Arial", 16f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
        this.Text = "Visual templates available for " + commonDialogOwner.mobjControlType.Name;
        this.UpdateScreen();
      }

      /// <summary>Gets the visual template description.</summary>
      /// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
      /// <returns></returns>
      private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate) => (this.CommonDialogOwner as VisualTemplateControlDialog).GetVisualTemplateDescription(objTypeOfVisualTemplate);

      /// <summary>Clean up any resources being used.</summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
        if (disposing && this.components != null)
          this.components.Dispose();
        base.Dispose(disposing);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjLeftPanel = new Panel();
        this.mobjSplitter = new Splitter();
        this.mobjSplitter2 = new Splitter();
        this.mobjRightPanel = new Panel();
        this.mbtnCancelAction = new Button();
        this.mbtnOkAction = new Button();
        this.mobjPropertyGrid = new PropertyGrid();
        this.mobjActionsPanel = new Panel();
        this.mobjListOfVisualTemplates = new ListView();
        this.mobjDescriptionPanel = new Panel();
        this.mobjDescriptionLabel = new Label();
        this.mobjColumnAppearanceName = new ColumnHeader();
        this.mobjRightPanel.SuspendLayout();
        this.mobjActionsPanel.SuspendLayout();
        this.SuspendLayout();
        this.mobjLeftPanel.Controls.Add((Control) this.mobjListOfVisualTemplates);
        this.mobjLeftPanel.Controls.Add((Control) this.mobjSplitter2);
        this.mobjLeftPanel.Controls.Add((Control) this.mobjDescriptionPanel);
        this.mobjLeftPanel.Dock = DockStyle.Fill;
        this.mobjLeftPanel.Location = new Point(0, 0);
        this.mobjLeftPanel.Name = "panel1";
        this.mobjLeftPanel.Size = new Size(518, 470);
        this.mobjLeftPanel.TabIndex = 0;
        this.mobjSplitter.Location = new Point(518, 0);
        this.mobjSplitter.Dock = DockStyle.Right;
        this.mobjSplitter.Name = "splitter1";
        this.mobjSplitter.Size = new Size(3, 470);
        this.mobjSplitter.TabIndex = 1;
        this.mobjSplitter.TabStop = false;
        this.mobjSplitter2.Location = new Point(518, 0);
        this.mobjSplitter2.Dock = DockStyle.Bottom;
        this.mobjSplitter2.Name = "mobjSplitter2";
        this.mobjSplitter2.Size = new Size(470, 3);
        this.mobjSplitter2.TabIndex = 1;
        this.mobjSplitter2.TabStop = false;
        this.mobjRightPanel.Controls.Add((Control) this.mobjPropertyGrid);
        this.mobjRightPanel.Controls.Add((Control) this.mobjActionsPanel);
        this.mobjRightPanel.Dock = DockStyle.Right;
        this.mobjRightPanel.Location = new Point(521, 0);
        this.mobjRightPanel.Name = "panel2";
        this.mobjRightPanel.Size = new Size(231, 470);
        this.mobjRightPanel.TabIndex = 2;
        this.mbtnCancelAction.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mbtnCancelAction.Location = new Point(157, 11);
        this.mbtnCancelAction.Name = "mbtnCancelAction";
        this.mbtnCancelAction.Size = new Size(75, 23);
        this.mbtnCancelAction.TabIndex = 0;
        this.mbtnCancelAction.Text = "Cancel";
        this.mbtnCancelAction.Click += new EventHandler(this.mbtnCancelAction_Click);
        this.mbtnOkAction.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mbtnOkAction.Location = new Point(72, 11);
        this.mbtnOkAction.Name = "mbtnOkAction";
        this.mbtnOkAction.Size = new Size(75, 23);
        this.mbtnOkAction.TabIndex = 1;
        this.mbtnOkAction.Text = "Ok";
        this.mbtnOkAction.Click += new EventHandler(this.mbtnOkAction_Click);
        this.mobjPropertyGrid.AutoValidate = AutoValidate.EnablePreventFocusChange;
        this.mobjPropertyGrid.CategoryForeColor = Color.Empty;
        this.mobjPropertyGrid.CommandsVisibleIfAvailable = false;
        this.mobjPropertyGrid.Dock = DockStyle.Fill;
        this.mobjPropertyGrid.HelpForeColor = Color.Black;
        this.mobjPropertyGrid.LineColor = Color.Empty;
        this.mobjPropertyGrid.Location = new Point(0, 0);
        this.mobjPropertyGrid.Name = "propertyGrid1";
        this.mobjPropertyGrid.Size = new Size(231, 425);
        this.mobjPropertyGrid.TabIndex = 2;
        this.mobjPropertyGrid.ViewBackColor = Color.White;
        this.mobjPropertyGrid.ViewForeColor = Color.Black;
        this.mobjActionsPanel.Controls.Add((Control) this.mbtnOkAction);
        this.mobjActionsPanel.Controls.Add((Control) this.mbtnCancelAction);
        this.mobjActionsPanel.Dock = DockStyle.Bottom;
        this.mobjActionsPanel.Location = new Point(0, 425);
        this.mobjActionsPanel.Name = "panel3";
        this.mobjActionsPanel.Size = new Size(231, 45);
        this.mobjActionsPanel.TabIndex = 3;
        this.mobjDescriptionPanel.Controls.Add((Control) this.mobjDescriptionLabel);
        this.mobjDescriptionPanel.Dock = DockStyle.Bottom;
        this.mobjDescriptionPanel.Location = new Point(0, 425);
        this.mobjDescriptionPanel.Name = "mobjDescriptionPanel";
        this.mobjDescriptionPanel.Size = new Size(231, 80);
        this.mobjDescriptionPanel.TabIndex = 3;
        this.mobjDescriptionLabel.Dock = DockStyle.Fill;
        this.mobjDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
        this.mobjDescriptionLabel.Text = "";
        this.mobjListOfVisualTemplates.DataMember = (string) null;
        this.mobjListOfVisualTemplates.Columns.AddRange(new ColumnHeader[1]
        {
          this.mobjColumnAppearanceName
        });
        this.mobjListOfVisualTemplates.Dock = DockStyle.Fill;
        this.mobjListOfVisualTemplates.Location = new Point(0, 0);
        this.mobjListOfVisualTemplates.Name = "listView1";
        this.mobjListOfVisualTemplates.Size = new Size(518, 470);
        this.mobjListOfVisualTemplates.MultiSelect = false;
        this.mobjListOfVisualTemplates.TabIndex = 0;
        this.mobjListOfVisualTemplates.SelectedIndexChanged += new EventHandler(this.mobjListOfVisualTemplates_SelectedIndexChanged);
        this.mobjListOfVisualTemplates.View = View.LargeIcon;
        this.Controls.Add((Control) this.mobjLeftPanel);
        this.Controls.Add((Control) this.mobjSplitter);
        this.Controls.Add((Control) this.mobjRightPanel);
        this.Size = new Size(752, 470);
        this.Text = "VisualizerControl";
        this.mobjRightPanel.ResumeLayout(false);
        this.mobjActionsPanel.ResumeLayout(false);
        this.ResumeLayout(false);
      }

      /// <summary>
      /// Handles the SelectedIndexChanged event of the mobjListOfVisualTemplates control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjListOfVisualTemplates_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateScreen();

      /// <summary>Updates the screen.</summary>
      private void UpdateScreen()
      {
        string str = string.Empty;
        ListViewItem selectedItem = this.mobjListOfVisualTemplates.SelectedItem;
        if (selectedItem != null)
        {
          this.mobjPropertyGrid.SelectedObject = selectedItem.Tag;
          if (this.CommonDialogOwner is VisualTemplateControlDialog commonDialogOwner)
            commonDialogOwner.VisualTemplate = selectedItem.Tag as VisualTemplate;
          str = selectedItem.SubItems[1].Text;
        }
        this.mobjDescriptionLabel.Text = str;
      }

      /// <summary>
      /// Handles the Click event of the mbtnCacnelAction control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mbtnCancelAction_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

      /// <summary>Handles the Click event of the mbtnOkAction control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mbtnOkAction_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}
