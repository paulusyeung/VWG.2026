// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCustomFilterDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DataGridViewCustomFilterDialog : Form
  {
    private Label mobjLabelFilterMessage;
    private ComboBox mobjComboBoxOperatorA;
    private DataGridViewFilterComboBoxBase mobjComboBoxValueA;
    private RadioButton mobjRadioButtonAnd;
    private RadioButton mobjRadioButtonOr;
    private ComboBox mobjComboBoxOperatorB;
    private DataGridViewFilterComboBoxBase mobjComboBoxValueB;
    private Button mobjButtonCancel;
    private Button mobjButtonOK;
    private DataGridViewColumn mobjDataGridViewColumn;
    private DataGridViewCell mobjDataGridViewCell;
    private DataGridView mobjDataGridView;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCustomFilterDialog" /> class.
    /// </summary>
    public DataGridViewCustomFilterDialog(DataGridViewCell objDataGridViewCell)
    {
      this.mobjDataGridViewCell = objDataGridViewCell != null ? objDataGridViewCell : throw new ArgumentNullException(nameof (objDataGridViewCell));
      this.mobjDataGridViewColumn = objDataGridViewCell.OwningColumn;
      this.mobjDataGridView = this.mobjDataGridViewColumn.DataGridView;
      this.InitializeComponent();
      this.mobjLabelFilterMessage.Text = SR.GetString("FilterMessage", (object) this.mobjDataGridViewColumn.HeaderText);
      this.Text = SR.GetString("CustomFilterColon");
      this.mobjButtonCancel.Text = WGLabels.Cancel;
      this.mobjButtonOK.Text = WGLabels.Ok;
      this.mobjRadioButtonAnd.Text = SR.GetString("And");
      this.mobjRadioButtonOr.Text = SR.GetString("Or");
      this.mobjComboBoxValueA.InitializeFilterValues(false, false, true);
      this.mobjComboBoxValueB.InitializeFilterValues(false, false, true);
      this.mobjComboBoxOperatorB.Items.Add((object) "");
      foreach (FilterComparisonOperator enmFilterComparisionOperator in DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(this.mobjDataGridViewColumn.ValueType))
      {
        string strText = SR.GetString(string.Format("FilterComparisionOperator_{0}", (object) enmFilterComparisionOperator.ToString()));
        this.mobjComboBoxOperatorA.Items.Add((object) new DataGridViewCustomFilterDialog.FilterOperatorItem(enmFilterComparisionOperator, strText));
        this.mobjComboBoxOperatorB.Items.Add((object) new DataGridViewCustomFilterDialog.FilterOperatorItem(enmFilterComparisionOperator, strText));
      }
      if (this.mobjComboBoxOperatorA.Items.Count <= 0)
        return;
      this.mobjComboBoxOperatorA.SelectedIndex = 0;
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjLabelFilterMessage = new Label();
      this.mobjComboBoxOperatorA = new ComboBox();
      this.mobjComboBoxValueA = new DataGridViewFilterComboBoxBase(this.mobjDataGridView, this.mobjDataGridViewColumn, this.mobjDataGridViewCell);
      this.mobjRadioButtonAnd = new RadioButton();
      this.mobjRadioButtonOr = new RadioButton();
      this.mobjComboBoxOperatorB = new ComboBox();
      this.mobjComboBoxValueB = new DataGridViewFilterComboBoxBase(this.mobjDataGridView, this.mobjDataGridViewColumn, this.mobjDataGridViewCell);
      this.mobjButtonCancel = new Button();
      this.mobjButtonOK = new Button();
      this.SuspendLayout();
      this.mobjLabelFilterMessage.AutoSize = true;
      this.mobjLabelFilterMessage.Location = new Point(6, 8);
      this.mobjLabelFilterMessage.Name = "mobjLabelFilterMessage";
      this.mobjLabelFilterMessage.Size = new Size(35, 13);
      this.mobjLabelFilterMessage.TabIndex = 0;
      this.mobjLabelFilterMessage.Text = "Show rows where '{0}' :";
      this.mobjComboBoxOperatorA.DropDownStyle = ComboBoxStyle.DropDownList;
      this.mobjComboBoxOperatorA.FormattingEnabled = true;
      this.mobjComboBoxOperatorA.Location = new Point(9, 34);
      this.mobjComboBoxOperatorA.Name = "mobjComboBoxOperatorA";
      this.mobjComboBoxOperatorA.Size = new Size(153, 21);
      this.mobjComboBoxOperatorA.TabIndex = 1;
      this.mobjComboBoxValueA.FormattingEnabled = true;
      this.mobjComboBoxValueA.Location = new Point(208, 34);
      this.mobjComboBoxValueA.Name = "mobjComboBoxValueA";
      this.mobjComboBoxValueA.Size = new Size(153, 21);
      this.mobjComboBoxValueA.TabIndex = 2;
      this.mobjRadioButtonAnd.AutoSize = true;
      this.mobjRadioButtonAnd.Location = new Point(9, 67);
      this.mobjRadioButtonAnd.Name = "mobjRadioButtonAnd";
      this.mobjRadioButtonAnd.Size = new Size(44, 17);
      this.mobjRadioButtonAnd.TabIndex = 3;
      this.mobjRadioButtonAnd.Checked = true;
      this.mobjRadioButtonAnd.Text = "And";
      this.mobjRadioButtonOr.AutoSize = true;
      this.mobjRadioButtonOr.Location = new Point(91, 67);
      this.mobjRadioButtonOr.Name = "mobjRadioButtonOr";
      this.mobjRadioButtonOr.Size = new Size(37, 17);
      this.mobjRadioButtonOr.TabIndex = 4;
      this.mobjRadioButtonOr.Text = "Or";
      this.mobjComboBoxOperatorB.DropDownStyle = ComboBoxStyle.DropDownList;
      this.mobjComboBoxOperatorB.FormattingEnabled = true;
      this.mobjComboBoxOperatorB.Location = new Point(9, 96);
      this.mobjComboBoxOperatorB.Name = "mobjComboBoxOperatorB";
      this.mobjComboBoxOperatorB.Size = new Size(153, 21);
      this.mobjComboBoxOperatorB.TabIndex = 5;
      this.mobjComboBoxValueB.FormattingEnabled = true;
      this.mobjComboBoxValueB.Location = new Point(208, 96);
      this.mobjComboBoxValueB.Name = "mobjComboBoxValueB";
      this.mobjComboBoxValueB.Size = new Size(153, 21);
      this.mobjComboBoxValueB.TabIndex = 6;
      this.mobjButtonCancel.DialogResult = DialogResult.Cancel;
      this.mobjButtonCancel.Location = new Point(286, 143);
      this.mobjButtonCancel.Name = "mobjButtonCancel";
      this.mobjButtonCancel.Size = new Size(75, 23);
      this.mobjButtonCancel.TabIndex = 7;
      this.mobjButtonCancel.Text = "Cancel";
      this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
      this.mobjButtonOK.Location = new Point(186, 143);
      this.mobjButtonOK.Name = "mobjButtonOK";
      this.mobjButtonOK.Size = new Size(75, 23);
      this.mobjButtonOK.TabIndex = 8;
      this.mobjButtonOK.Text = "OK";
      this.mobjButtonOK.Click += new EventHandler(this.mobjButtonOK_Click);
      this.AcceptButton = (IButtonControl) this.mobjButtonOK;
      this.CancelButton = (IButtonControl) this.mobjButtonCancel;
      this.Controls.Add((Control) this.mobjButtonOK);
      this.Controls.Add((Control) this.mobjButtonCancel);
      this.Controls.Add((Control) this.mobjComboBoxValueB);
      this.Controls.Add((Control) this.mobjComboBoxOperatorB);
      this.Controls.Add((Control) this.mobjRadioButtonAnd);
      this.Controls.Add((Control) this.mobjRadioButtonOr);
      this.Controls.Add((Control) this.mobjComboBoxValueA);
      this.Controls.Add((Control) this.mobjComboBoxOperatorA);
      this.Controls.Add((Control) this.mobjLabelFilterMessage);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Size = new Size(376, 176);
      this.Text = "Custom Filter:";
      this.ResumeLayout(false);
    }

    /// <summary>
    /// Handles the Click event of the mobjButtonCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjButtonCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    /// <summary>Handles the Click event of the mobjButtonOK control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjButtonOK_Click(object sender, EventArgs e)
    {
      if (this.ValidateValues())
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else
      {
        int num = (int) MessageBox.Show(SR.GetString("InvalidFilterMessage"), SR.GetString("CustomFilter"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    /// <summary>Validates the values.</summary>
    /// <returns></returns>
    private bool ValidateValues() => this.mobjComboBoxOperatorA.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.mobjComboBoxValueA.Text) && (this.mobjComboBoxOperatorB.SelectedIndex <= 0 || !string.IsNullOrEmpty(this.mobjComboBoxValueB.Text)) && this.mobjComboBoxValueA.IsValidValue() && (this.mobjComboBoxOperatorB.SelectedIndex <= 0 || this.mobjComboBoxValueB.IsValidValue());

    /// <summary>Gets the column.</summary>
    internal DataGridViewColumn Column => this.mobjDataGridViewColumn;

    /// <summary>Gets the cell.</summary>
    internal DataGridViewCell Cell => this.mobjDataGridViewCell;

    /// <summary>Gets the value A.</summary>
    internal string ValueA => this.mobjComboBoxValueA.Text;

    /// <summary>Gets the value B.</summary>
    internal string ValueB => this.mobjComboBoxValueB.Text;

    /// <summary>Gets the operator A.</summary>
    internal FilterComparisonOperator OperatorA => this.mobjComboBoxOperatorA.SelectedItem is DataGridViewCustomFilterDialog.FilterOperatorItem selectedItem ? selectedItem.Operator : FilterComparisonOperator.None;

    /// <summary>Gets the operator B.</summary>
    internal FilterComparisonOperator OperatorB => this.mobjComboBoxOperatorB.SelectedItem is DataGridViewCustomFilterDialog.FilterOperatorItem selectedItem ? selectedItem.Operator : FilterComparisonOperator.None;

    /// <summary>Gets the filters relation.</summary>
    internal string FiltersRelation => this.mobjRadioButtonAnd.Checked ? "AND" : "OR";

    [Serializable]
    private class FilterOperatorItem
    {
      private string mstrText = string.Empty;
      private FilterComparisonOperator menmFilterComparisionOperator;

      public FilterOperatorItem(
        FilterComparisonOperator enmFilterComparisionOperator,
        string strText)
      {
        this.menmFilterComparisionOperator = enmFilterComparisionOperator;
        this.mstrText = strText;
      }

      /// <summary>Gets the text.</summary>
      public string Text => this.mstrText;

      /// <summary>Gets the operator.</summary>
      public FilterComparisonOperator Operator => this.menmFilterComparisionOperator;

      /// <summary>
      /// Returns a <see cref="T:System.String" /> that represents this instance.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String" /> that represents this instance.
      /// </returns>
      public override string ToString() => this.mstrText;
    }
  }
}
