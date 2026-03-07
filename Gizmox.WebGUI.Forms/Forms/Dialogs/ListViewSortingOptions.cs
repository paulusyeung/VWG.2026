// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Dialogs.ListViewSortingOptions
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Controls;
using System;
using System.Collections;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Dialogs
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ListViewSortingOptions : Form
  {
    private Label mobjLabelHelp;
    private Panel mobjPanelButtons;
    private Button mobjButtonCancel;
    private Button mobjButtonOK;
    private Panel mobjPanelSortingDirection;
    private ItemChooser mobjItemChooser;
    private RadioButton mobjRadioAscending;
    private RadioButton mobjRadioDecsending;
    private ListView mobjListView;
    private ColumnHeaderSortingData mobjSortedColumns;
    private Hashtable mobjChecked;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Dialogs.ListViewSortingOptions" /> instance.
    /// </summary>
    public ListViewSortingOptions(ListView objListView)
    {
      this.mobjListView = objListView;
      this.InitializeComponent();
      this.mobjSortedColumns = new ColumnHeaderSortingData(this.mobjListView);
      this.mobjItemChooser.Items = this.mobjSortedColumns.SortedColumns;
      this.mobjItemChooser.Checked = this.mobjSortedColumns.SortingColumns;
      this.mobjPanelSortingDirection.Enabled = false;
      this.mobjChecked = new Hashtable();
      this.mobjItemChooser.ItemSelected += new EventHandler(this.mobjItemChooser_ItemSelected);
      this.mobjRadioAscending.CheckedChanged += new EventHandler(this.mobjRadioAscending_CheckedChanged);
      this.mobjRadioDecsending.CheckedChanged += new EventHandler(this.mobjRadioDecsending_CheckedChanged);
      this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
      this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
      this.mobjItemChooser.CheckLabel = WGLabels.Show;
      this.mobjItemChooser.UncheckLabel = WGLabels.Hide;
      this.mobjButtonOK.Text = WGLabels.Ok;
      this.mobjButtonCancel.Text = WGLabels.Cancel;
      this.mobjButtonOK.Text = WGLabels.Ok;
      this.mobjButtonCancel.Text = WGLabels.Cancel;
      this.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesSortingOptions");
      this.mobjLabelHelp.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesSortingInstructions");
      this.mobjRadioAscending.Text = WGLabels.Ascending;
      this.mobjRadioDecsending.Text = WGLabels.Decsending;
      if (this.mobjItemChooser.SelectedItem == null)
        return;
      this.mobjItemChooser_ItemSelected((object) this.mobjItemChooser, EventArgs.Empty);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjLabelHelp = new Label();
      this.mobjPanelButtons = new Panel();
      this.mobjButtonOK = new Button();
      this.mobjButtonCancel = new Button();
      this.mobjPanelSortingDirection = new Panel();
      this.mobjRadioDecsending = new RadioButton();
      this.mobjRadioAscending = new RadioButton();
      this.mobjItemChooser = new ItemChooser();
      this.mobjPanelButtons.SuspendLayout();
      this.mobjPanelSortingDirection.SuspendLayout();
      this.SuspendLayout();
      this.mobjLabelHelp.Dock = DockStyle.Top;
      this.mobjLabelHelp.Location = new Point(15, 15);
      this.mobjLabelHelp.Name = "mobjLabelHelp";
      this.mobjLabelHelp.Size = new Size(312, 49);
      this.mobjLabelHelp.TabIndex = 0;
      this.mobjLabelHelp.Text = "Check the columns that you would like to sort by. Use the Move  Up and Move Down buttons to reorder sorting.";
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonOK);
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonCancel);
      this.mobjPanelButtons.Dock = DockStyle.Bottom;
      this.mobjPanelButtons.Location = new Point(15, 300);
      this.mobjPanelButtons.Name = "mobjPanelButtons";
      this.mobjPanelButtons.Size = new Size(312, 35);
      this.mobjPanelButtons.TabIndex = 1;
      this.mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.mobjButtonOK.Location = new Point(156, 11);
      this.mobjButtonOK.Name = "mobjButtonOK";
      this.mobjButtonOK.TabIndex = 1;
      this.mobjButtonOK.Text = "OK";
      this.mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.mobjButtonCancel.Location = new Point(236, 11);
      this.mobjButtonCancel.Name = "mobjButtonCancel";
      this.mobjButtonCancel.TabIndex = 0;
      this.mobjButtonCancel.Text = "Cancel";
      this.mobjPanelSortingDirection.Controls.Add((Control) this.mobjRadioDecsending);
      this.mobjPanelSortingDirection.Controls.Add((Control) this.mobjRadioAscending);
      this.mobjPanelSortingDirection.Dock = DockStyle.Bottom;
      this.mobjPanelSortingDirection.Location = new Point(15, (int) byte.MaxValue);
      this.mobjPanelSortingDirection.Name = "mobjPanelSortingDirection";
      this.mobjPanelSortingDirection.Size = new Size(312, 45);
      this.mobjPanelSortingDirection.TabIndex = 2;
      this.mobjRadioDecsending.Location = new Point(104, 10);
      this.mobjRadioDecsending.Name = "mobjRadioDecsending";
      this.mobjRadioDecsending.Size = new Size(104, 24);
      this.mobjRadioDecsending.TabIndex = 1;
      this.mobjRadioDecsending.Text = "Decsending";
      this.mobjRadioAscending.Location = new Point(0, 10);
      this.mobjRadioAscending.Name = "mobjRadioAscending";
      this.mobjRadioAscending.Size = new Size(104, 24);
      this.mobjRadioAscending.TabIndex = 0;
      this.mobjRadioAscending.Text = "Acsending";
      this.mobjItemChooser.Dock = DockStyle.Fill;
      this.mobjItemChooser.Location = new Point(15, 64);
      this.mobjItemChooser.Name = "mobjItemChooser";
      this.mobjItemChooser.Size = new Size(320, 191);
      this.mobjItemChooser.TabIndex = 3;
      this.ClientSize = new Size(342, 350);
      this.Controls.Add((Control) this.mobjItemChooser);
      this.Controls.Add((Control) this.mobjPanelSortingDirection);
      this.Controls.Add((Control) this.mobjPanelButtons);
      this.Controls.Add((Control) this.mobjLabelHelp);
      this.DockPadding.All = 15;
      this.Name = nameof (ListViewSortingOptions);
      this.Text = "Sorting Options";
      this.mobjPanelButtons.ResumeLayout(false);
      this.mobjPanelSortingDirection.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjItemChooser_ItemSelected(object sender, EventArgs e)
    {
      if (!(this.mobjItemChooser.SelectedItem is ColumnHeader selectedItem))
        return;
      this.mobjPanelSortingDirection.Enabled = true;
      SortOrder sortOrder = this.mobjChecked[(object) selectedItem] != null ? (SortOrder) this.mobjChecked[(object) selectedItem] : selectedItem.SortOrder;
      if (sortOrder == SortOrder.None)
        sortOrder = SortOrder.Ascending;
      this.mobjRadioAscending.Checked = sortOrder == SortOrder.Ascending;
      this.mobjRadioDecsending.Checked = sortOrder == SortOrder.Descending;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjRadioAscending_CheckedChanged(object sender, EventArgs e)
    {
      if (!(this.mobjItemChooser.SelectedItem is ColumnHeader selectedItem) || !this.mobjRadioAscending.Checked)
        return;
      this.mobjChecked[(object) selectedItem] = (object) SortOrder.Ascending;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjRadioDecsending_CheckedChanged(object sender, EventArgs e)
    {
      if (!(this.mobjItemChooser.SelectedItem is ColumnHeader selectedItem) || !this.mobjRadioDecsending.Checked)
        return;
      this.mobjChecked[(object) selectedItem] = (object) SortOrder.Descending;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonCancel_Click(object sender, EventArgs e) => this.Close();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonOK_Click(object sender, EventArgs e)
    {
      foreach (ColumnHeader columnHeader in (IEnumerable) this.mobjItemChooser.Items)
        columnHeader.SortPosition = 1000;
      int num = 0;
      foreach (ColumnHeader key in (IEnumerable) this.mobjItemChooser.Checked)
      {
        if (this.mobjChecked[(object) key] != null)
          key.SortOrder = (SortOrder) this.mobjChecked[(object) key];
        if (key.SortOrder == SortOrder.None)
          key.SortOrder = SortOrder.Ascending;
        key.SortPosition = num;
        ++num;
      }
      foreach (ColumnHeader columnHeader in (IEnumerable) this.mobjItemChooser.Items)
      {
        if (columnHeader.SortPosition == 1000)
        {
          columnHeader.SortOrder = SortOrder.None;
          columnHeader.SortPosition = num;
        }
        ++num;
      }
      this.Close();
      this.mobjListView.Sort();
    }
  }
}
