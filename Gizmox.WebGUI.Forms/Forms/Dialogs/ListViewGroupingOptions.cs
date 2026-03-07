// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Dialogs.ListViewGroupingOptions
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
  public class ListViewGroupingOptions : Form
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
    private Hashtable mobjChecked;
    private ColumnHeaderGroupingData mobjGroupedColumns;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Dialogs.ListViewGroupingOptions" /> instance.
    /// </summary>
    public ListViewGroupingOptions(ListView objListView)
    {
      this.mobjListView = objListView;
      this.InitializeComponent();
      this.mobjGroupedColumns = new ColumnHeaderGroupingData(this.mobjListView);
      this.mobjItemChooser.Items = this.mobjGroupedColumns.SortedColumns;
      this.mobjItemChooser.Checked = this.mobjGroupedColumns.GroupingColumns;
      this.mobjChecked = new Hashtable();
      this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
      this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
      this.mobjItemChooser.CheckLabel = WGLabels.Show;
      this.mobjItemChooser.UncheckLabel = WGLabels.Hide;
      this.mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
      this.mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;
      this.mobjButtonOK.Text = WGLabels.Ok;
      this.mobjButtonCancel.Text = WGLabels.Cancel;
      this.mobjLabelHelp.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesGroupingInstructions");
      this.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesGroupingOptions");
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
      this.mobjLabelHelp.Text = "Check the columns that you would like to group by. Use the Move  Up and Move Down buttons to reorder grouping order.";
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
      this.Name = nameof (ListViewGroupingOptions);
      this.Text = "Grouping Options";
      this.mobjPanelButtons.ResumeLayout(false);
      this.mobjPanelSortingDirection.ResumeLayout(false);
      this.ResumeLayout(false);
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
        columnHeader.GroupByPosition = 1000;
      int num = 0;
      foreach (ColumnHeader columnHeader in (IEnumerable) this.mobjItemChooser.Checked)
      {
        columnHeader.GroupBy = true;
        columnHeader.GroupByPosition = num;
        ++num;
      }
      foreach (ColumnHeader columnHeader in (IEnumerable) this.mobjItemChooser.Items)
      {
        if (columnHeader.GroupByPosition == 1000)
        {
          columnHeader.GroupBy = false;
          columnHeader.GroupByPosition = num;
        }
        ++num;
      }
      this.Close();
      this.mobjListView.FireGroup();
    }
  }
}
