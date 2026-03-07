// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.Editors.VisualTemplateListViewColumnControlDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Controls;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
  /// <summary>The dialog form for column ordter.</summary>
  [Serializable]
  public class VisualTemplateListViewColumnControlDialog : CommonDialog
  {
    private ListView mobjListView;
    private string mstrCurrentColumnOrderAppearance;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.Editors.VisualTemplateListViewColumnControlDialog" /> class.
    /// </summary>
    /// <param name="objListView">The object ListView.</param>
    /// <param name="strCurrentColumnOrderAppearance">The string current column order appearance.</param>
    public VisualTemplateListViewColumnControlDialog(
      ListView objListView,
      string strCurrentColumnOrderAppearance)
    {
      this.mobjListView = objListView;
      this.mstrCurrentColumnOrderAppearance = strCurrentColumnOrderAppearance;
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
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new VisualTemplateListViewColumnControlDialog.VisualTemplateListViewColumnControlForm(this);

    /// <summary>Gets or sets the ListView column order.</summary>
    /// <value>The ListView column order.</value>
    public string ListViewColumnOrder
    {
      get => this.mstrCurrentColumnOrderAppearance;
      set => this.mstrCurrentColumnOrderAppearance = value;
    }

    [Serializable]
    protected class VisualTemplateListViewColumnControlForm : CommonDialog.CommonDialogForm
    {
      private Label mobjLabelHelp;
      private Button mobjButtonCancel;
      private Button mobjButtonOK;
      private Panel mobjPanelButtons;
      private ItemChooser mobjItemChooser;
      private ListView.ColumnHeaderCollection mobjColumns;
      private ListView mobjListView;
      private string mstrColumnOrder;

      /// <summary>
      /// Creates a new <see cref="!:ListViewColumnOptions" /> instance.
      /// </summary>
      /// <param name="objListView">List view.</param>
      public VisualTemplateListViewColumnControlForm(
        VisualTemplateListViewColumnControlDialog objVisualizerControlDialog)
        : base((CommonDialog) objVisualizerControlDialog)
      {
        this.mobjListView = objVisualizerControlDialog.mobjListView;
        this.mstrColumnOrder = objVisualizerControlDialog.mstrCurrentColumnOrderAppearance;
        this.InitializeComponent();
        this.AcceptButton = (IButtonControl) this.mobjButtonOK;
        this.CancelButton = (IButtonControl) this.mobjButtonCancel;
        if (this.mobjListView != null)
        {
          this.mobjColumns = this.mobjListView.Columns;
          ArrayList c = new ArrayList();
          if (this.mstrColumnOrder != null)
          {
            string mstrColumnOrder = this.mstrColumnOrder;
            char[] chArray = new char[1]{ '|' };
            foreach (string s in mstrColumnOrder.Split(chArray))
            {
              int result;
              if (int.TryParse(s, out result))
                c.Add((object) this.mobjColumns[result]);
            }
          }
          ArrayList arrayList = new ArrayList((ICollection) c);
          foreach (ColumnHeader mobjColumn in this.mobjColumns)
          {
            if (!arrayList.Contains((object) mobjColumn))
              arrayList.Add((object) mobjColumn);
          }
          this.mobjItemChooser.Items = (ICollection) arrayList;
          this.mobjItemChooser.Checked = (ICollection) c;
        }
        this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
        this.mobjItemChooser.CheckLabel = WGLabels.Show;
        this.mobjItemChooser.UncheckLabel = WGLabels.Hide;
        this.mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
        this.mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;
        this.mobjButtonOK.Text = WGLabels.Ok;
        this.mobjButtonCancel.Text = WGLabels.Cancel;
        this.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnOptions");
        this.mobjLabelHelp.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnsInstructions");
      }

      /// <summary>Initializes the component.</summary>
      private void InitializeComponent()
      {
        this.mobjLabelHelp = new Label();
        this.mobjPanelButtons = new Panel();
        this.mobjButtonCancel = new Button();
        this.mobjButtonOK = new Button();
        this.mobjItemChooser = new ItemChooser();
        this.mobjPanelButtons.SuspendLayout();
        this.SuspendLayout();
        this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonOK);
        this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonCancel);
        this.mobjPanelButtons.Dock = DockStyle.Bottom;
        this.mobjPanelButtons.Location = new Point(15, 300);
        this.mobjPanelButtons.Name = "mobjPanelButtons";
        this.mobjPanelButtons.Size = new Size(312, 35);
        this.mobjPanelButtons.TabIndex = 1;
        this.mobjLabelHelp.Dock = DockStyle.Top;
        this.mobjLabelHelp.Location = new Point(15, 15);
        this.mobjLabelHelp.Name = "mobjLabelHelp";
        this.mobjLabelHelp.Size = new Size(312, 49);
        this.mobjLabelHelp.TabIndex = 0;
        this.mobjLabelHelp.Text = "Check the columns that you would like to make visible. Use the Move  Up and Move Down buttons to reorder the columns.";
        this.mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjButtonCancel.Location = new Point(236, 11);
        this.mobjButtonCancel.Name = "mobjButtonCancel";
        this.mobjButtonCancel.TabIndex = 0;
        this.mobjButtonCancel.Text = "Cancel";
        this.mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.mobjButtonOK.Location = new Point(156, 11);
        this.mobjButtonOK.Name = "mobjButtonOK";
        this.mobjButtonOK.TabIndex = 1;
        this.mobjButtonOK.Text = "OK";
        this.mobjItemChooser.Dock = DockStyle.Fill;
        this.mobjItemChooser.Location = new Point(15, 64);
        this.mobjItemChooser.Name = "mobjItemChooser";
        this.mobjItemChooser.Size = new Size(320, 191);
        this.mobjItemChooser.TabIndex = 3;
        this.ClientSize = new Size(342, 350);
        this.Controls.Add((Control) this.mobjItemChooser);
        this.Controls.Add((Control) this.mobjPanelButtons);
        this.Controls.Add((Control) this.mobjLabelHelp);
        this.DockPadding.All = 15;
        this.Name = "ListViewColumnOptions";
        this.Text = "ListViewColumnOptions";
        this.mobjPanelButtons.ResumeLayout(false);
        this.mobjPanelButtons.ResumeLayout(false);
        this.ResumeLayout(false);
      }

      /// <summary>Handle OK button click</summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void mobjButtonOK_Click(object sender, EventArgs e)
      {
        ArrayList arrayList = new ArrayList(this.mobjItemChooser.Checked);
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ColumnHeader columnHeader in (IEnumerable) this.mobjItemChooser.Items)
        {
          if (arrayList.Contains((object) columnHeader))
            stringBuilder.Append(string.Format("{0}|", (object) columnHeader.Index));
        }
        ((VisualTemplateListViewColumnControlDialog) this.CommonDialogOwner).mstrCurrentColumnOrderAppearance = stringBuilder.ToString().Trim('|');
        this.DialogResult = DialogResult.OK;
      }
    }
  }
}
