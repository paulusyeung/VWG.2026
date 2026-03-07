// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Dialogs.ListViewColumnOptions
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
  /// <summary>The columens options dialog</summary>
  [Serializable]
  public class ListViewColumnOptions : Form
  {
    private Label mobjLabelHelp;
    private Button mobjButtonCancel;
    private Button mobjButtonOK;
    private Panel mobjPanelButtons;
    private Panel mobjPanelColumnWidth;
    private Button mobjButtonMoveUp;
    private Button mobjButtonMoveDown;
    private Button mobjButtonShow;
    private Button mobjButtonHide;
    private Label mobjLabelWidth1;
    private TextBox mobjTextColumnWidth;
    private Label mobjLabelWidth2;
    private ItemChooser mobjItemChooser;
    private ListView.ColumnHeaderCollection mobjColumns;
    private ListView mobjListView;
    private Hashtable mobjColumnWidth;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Dialogs.ListViewColumnOptions" /> instance.
    /// </summary>
    /// <param name="objListView">List view.</param>
    public ListViewColumnOptions(ListView objListView)
    {
      this.mobjListView = objListView;
      this.InitializeComponent();
      this.mobjListView = objListView;
      this.mobjColumns = objListView.Columns;
      this.mobjColumnWidth = new Hashtable();
      this.mobjItemChooser.Items = this.mobjColumns.SortedColumns;
      this.mobjItemChooser.Checked = this.mobjColumns.VisibleColumns;
      try
      {
        this.mobjTextColumnWidth.Text = this.GetColumnWidth((ColumnHeader) this.mobjItemChooser.SelectedItem);
      }
      catch (Exception ex)
      {
      }
      this.mobjItemChooser.ItemSelected += new EventHandler(this.mobjItemChooser_ItemSelected);
      this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
      this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
      this.mobjItemChooser.CheckLabel = WGLabels.Show;
      this.mobjItemChooser.UncheckLabel = WGLabels.Hide;
      this.mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
      this.mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;
      this.mobjButtonOK.Text = WGLabels.Ok;
      this.mobjButtonCancel.Text = WGLabels.Cancel;
      this.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnOptions");
      this.mobjLabelHelp.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnsInstructions");
      this.mobjLabelWidth1.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnsStringA");
      this.mobjLabelWidth2.Text = Gizmox.WebGUI.Forms.SR.GetString(this.Context.CurrentUICulture, "WGLablesColumnsStringB");
      this.mobjTextColumnWidth.TextChanged += new EventHandler(this.mobjTextColumnWidth_TextChanged);
    }

    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
      this.mobjLabelHelp = new Label();
      this.mobjPanelButtons = new Panel();
      this.mobjButtonCancel = new Button();
      this.mobjButtonOK = new Button();
      this.mobjPanelColumnWidth = new Panel();
      this.mobjLabelWidth1 = new Label();
      this.mobjTextColumnWidth = new TextBox();
      this.mobjLabelWidth2 = new Label();
      this.mobjItemChooser = new ItemChooser();
      this.mobjPanelColumnWidth.SuspendLayout();
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
      this.mobjPanelColumnWidth.Controls.Add((Control) this.mobjLabelWidth2);
      this.mobjPanelColumnWidth.Controls.Add((Control) this.mobjTextColumnWidth);
      this.mobjPanelColumnWidth.Controls.Add((Control) this.mobjLabelWidth1);
      this.mobjPanelColumnWidth.Dock = DockStyle.Bottom;
      this.mobjPanelColumnWidth.Location = new Point(15, (int) byte.MaxValue);
      this.mobjPanelColumnWidth.Name = "mobjPanelColumnWidth";
      this.mobjPanelColumnWidth.Size = new Size(312, 45);
      this.mobjPanelColumnWidth.TabIndex = 2;
      this.mobjItemChooser.Dock = DockStyle.Fill;
      this.mobjItemChooser.Location = new Point(15, 64);
      this.mobjItemChooser.Name = "mobjItemChooser";
      this.mobjItemChooser.Size = new Size(320, 191);
      this.mobjItemChooser.TabIndex = 3;
      this.mobjLabelWidth1.Location = new Point(8, 16);
      this.mobjLabelWidth1.Name = "mobjLabelWidth1";
      this.mobjLabelWidth1.Size = new Size(168, 16);
      this.mobjLabelWidth1.TabIndex = 0;
      this.mobjLabelWidth1.Text = "The selected column should be";
      this.mobjTextColumnWidth.Location = new Point(166, 13);
      this.mobjTextColumnWidth.Name = "mobjTextColumnWidth";
      this.mobjTextColumnWidth.Size = new Size(32, 20);
      this.mobjTextColumnWidth.TabIndex = 1;
      this.mobjTextColumnWidth.Text = "";
      this.mobjLabelWidth2.Location = new Point(208, 16);
      this.mobjLabelWidth2.Name = "mobjLabelWidth2";
      this.mobjLabelWidth2.Size = new Size(100, 16);
      this.mobjLabelWidth2.TabIndex = 2;
      this.mobjLabelWidth2.Text = "pixels wide.";
      this.ClientSize = new Size(342, 350);
      this.Controls.Add((Control) this.mobjItemChooser);
      this.Controls.Add((Control) this.mobjPanelColumnWidth);
      this.Controls.Add((Control) this.mobjPanelButtons);
      this.Controls.Add((Control) this.mobjLabelHelp);
      this.DockPadding.All = 15;
      this.Name = nameof (ListViewColumnOptions);
      this.Text = nameof (ListViewColumnOptions);
      this.mobjPanelButtons.ResumeLayout(false);
      this.mobjPanelColumnWidth.ResumeLayout(false);
      this.mobjPanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonCancel_Click(object sender, EventArgs e) => this.Close();

    /// <summary>Handle OK button click</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonOK_Click(object sender, EventArgs e)
    {
      int num = 0;
      ArrayList arrayList = new ArrayList(this.mobjItemChooser.Checked);
      foreach (ColumnHeader key in (IEnumerable) this.mobjItemChooser.Items)
      {
        if (this.mobjColumnWidth[(object) key] != null)
          key.Width = int.Parse((string) this.mobjColumnWidth[(object) key]);
        key.Visible = arrayList.Contains((object) key);
        key.DisplayIndexInternal = num;
        ++num;
      }
      this.mobjColumns.UpdateColumns();
      this.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjItemChooser_ItemSelected(object sender, EventArgs e) => this.mobjTextColumnWidth.Text = this.GetColumnWidth((ColumnHeader) this.mobjItemChooser.SelectedItem);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjTextColumnWidth_TextChanged(object sender, EventArgs e)
    {
      ColumnHeader selectedItem = (ColumnHeader) this.mobjItemChooser.SelectedItem;
      string text = this.mobjTextColumnWidth.Text;
      try
      {
        int num = int.Parse(text);
        this.mobjColumnWidth[(object) selectedItem] = (object) num.ToString();
      }
      catch (Exception ex)
      {
        this.mobjTextColumnWidth.Text = this.GetColumnWidth(selectedItem);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objColumnHeader"></param>
    private string GetColumnWidth(ColumnHeader objColumnHeader) => this.mobjColumnWidth[(object) objColumnHeader] != null ? (string) this.mobjColumnWidth[(object) objColumnHeader] : objColumnHeader.Width.ToString();
  }
}
