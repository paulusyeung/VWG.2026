// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewFilterCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewFilterCell : DataGridViewCell
  {
    private DataGridViewColumn mobjOwningColumn;
    private DataGridViewFilterCell.DataGridViewFilterControl mobjDataGridViewFilterControl;
    private DataGridView mobjOwningDataGridView;
    /// <summary>Filter cell type identificator.</summary>
    protected const string FilterTypeName = "8";

    /// <summary>Occurs when [filter changed].</summary>
    public event EventHandler FilterChanged;

    /// <summary>Gets TypeName of FilterCell</summary>
    internal override string TypeName => "8";

    /// <summary>Gets the render mask.</summary>
    internal override int RenderMask => base.RenderMask | 1 | 4 | 2;

    /// <summary>Gets the prerender mask.</summary>
    internal override int PreRenderMask => base.PreRenderMask | 1;

    /// <summary>Gets the comparision operator.</summary>
    internal FilterComparisonOperator ComparisonOperator => this.mobjDataGridViewFilterControl != null ? this.mobjDataGridViewFilterControl.ComparisionOperator : FilterComparisonOperator.None;

    /// <summary>Gets the comparision value.</summary>
    internal string ComparisionValue => this.mobjDataGridViewFilterControl != null ? this.mobjDataGridViewFilterControl.ComparisionValue : string.Empty;

    /// <summary>Gets the comparision item.</summary>
    internal object ComparisionItem => this.mobjDataGridViewFilterControl != null ? this.mobjDataGridViewFilterControl.ComparisionItem : (object) null;

    /// <summary>Gets the name of the data property.</summary>
    /// <value>The name of the data property.</value>
    internal string DataPropertyName => this.mobjOwningColumn != null ? this.mobjOwningColumn.DataPropertyName : string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether [allow row filtering].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allow row filtering]; otherwise, <c>false</c>.
    /// </value>
    internal bool AllowRowFiltering
    {
      get => this.mobjOwningColumn == null || this.mobjOwningColumn.AllowRowFiltering;
      set
      {
        if (this.mobjOwningColumn == null)
          return;
        this.mobjOwningColumn.AllowRowFiltering = value;
      }
    }

    /// <summary>Gets or sets the data type of the values in the cell.</summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
    internal new Type ValueType => this.mobjOwningColumn != null ? this.mobjOwningColumn.ValueType : (Type) null;

    /// <summary>Gets the data grid view filter control.</summary>
    /// <value>The data grid view filter control.</value>
    internal DataGridViewFilterCell.DataGridViewFilterControl DataGridViewFilterControlObject => this.mobjDataGridViewFilterControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterCell" /> class.
    /// </summary>
    public DataGridViewFilterCell(
      DataGridView objOwningDataGridView,
      DataGridViewColumn objOwningColumn,
      bool blnFilteringEnabled)
    {
      this.InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);
      this.Panel.Controls.Add((Control) this.mobjDataGridViewFilterControl);
      this.Colspan = 1;
      this.Rowspan = 1;
    }

    /// <summary>Clears the filter.</summary>
    /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
    public void ClearFilter(bool blnClearHeaderFilter) => this.mobjDataGridViewFilterControl.ClearFilter(blnClearHeaderFilter);

    /// <summary>Initializes the data grid view filter cell.</summary>
    /// <param name="objOwningDataGridView">The obj owning data grid view.</param>
    /// <param name="objOwningColumn">The obj owning column.</param>
    /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
    private void InitializeDataGridViewFilterCell(
      DataGridView objOwningDataGridView,
      DataGridViewColumn objOwningColumn,
      bool blnFilteringEnabled)
    {
      this.mobjOwningColumn = objOwningColumn;
      this.mobjOwningDataGridView = objOwningDataGridView;
      if (this.mobjDataGridViewFilterControl == null)
      {
        this.mobjDataGridViewFilterControl = new DataGridViewFilterCell.DataGridViewFilterControl(objOwningDataGridView, objOwningColumn, this, blnFilteringEnabled);
      }
      else
      {
        objOwningDataGridView.mblnSuspendFilterInitialization = true;
        this.mobjDataGridViewFilterControl.RefreshFilterComboBox();
        objOwningDataGridView.mblnSuspendFilterInitialization = false;
      }
      if (blnFilteringEnabled)
      {
        this.mobjDataGridViewFilterControl.FilterChanged += new EventHandler(this.OnDataGridViewFilterControlFilterChanged);
        this.mobjOwningColumn.AllowRowFilteringChanged += new EventHandler(this.OnAllowRowFilteringChanged);
      }
      this.AllowRowFiltering = this.mobjOwningColumn.AllowRowFiltering & blnFilteringEnabled;
      this.InitializeCellPanelAvailablity();
      this.DataGridViewInternal = objOwningDataGridView;
      this.OwningColumnInternal = objOwningColumn;
    }

    /// <summary>Refreshes the filter cell.</summary>
    internal void RefreshFilterCell() => this.RefreshFilterCell(this.mobjOwningDataGridView, this.mobjOwningColumn, this.AllowRowFiltering);

    /// <summary>Refreshes the filter cell.</summary>
    /// <param name="objOwningDataGridView">The owning data grid view.</param>
    /// <param name="objOwningColumn">The obj owning column.</param>
    /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
    private void RefreshFilterCell(
      DataGridView objOwningDataGridView,
      DataGridViewColumn objOwningColumn,
      bool blnFilteringEnabled)
    {
      this.InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);
    }

    /// <summary>Called when [allow row filtering changed].</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnAllowRowFilteringChanged(object sender, EventArgs e) => this.InitializeCellPanelAvailablity();

    /// <summary>Initializes the cell panel availablity.</summary>
    private void InitializeCellPanelAvailablity() => this.Panel.Enabled = this.AllowRowFiltering;

    /// <summary>Updates the filter combo box.</summary>
    internal void UpdateFilterComboBox()
    {
      if (this.mobjDataGridViewFilterControl.mobjValuesComboBox == null)
        return;
      this.mobjDataGridViewFilterControl.mobjValuesComboBox.Update();
    }

    /// <summary>
    /// Called when [data grid view filter control filter changed].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnDataGridViewFilterControlFilterChanged(object sender, EventArgs e)
    {
      if (this.FilterChanged == null)
        return;
      this.FilterChanged((object) this, e);
    }

    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Serializable]
    internal class DataGridViewFilterControl : UserControl
    {
      private DataGridViewColumn mobjOwningColumn;
      private DataGridView mobjOwningDataGridView;
      private Gizmox.WebGUI.Forms.Panel mobjLeftPanel;
      private DataGridViewFilterButton mobjOperatorsButton;
      private Gizmox.WebGUI.Forms.Panel mobjRightPanel;
      private DataGridViewFilterButton mobjClearButton;
      internal DataGridViewFilterComboBox mobjValuesComboBox;
      private ContextMenu mobjOperatorsContextMenu;
      private DataGridViewFilterCell mobjOwningCell;

      /// <summary>Occurs when [filter changed].</summary>
      public event EventHandler FilterChanged;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl" /> class.
      /// </summary>
      /// <param name="objOwningDataGridView">The obj owning data grid view.</param>
      /// <param name="objOwningColumn">The obj owning column.</param>
      /// <param name="objOwningCell">The obj owning cell.</param>
      /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
      public DataGridViewFilterControl(
        DataGridView objOwningDataGridView,
        DataGridViewColumn objOwningColumn,
        DataGridViewFilterCell objOwningCell,
        bool blnFilteringEnabled)
      {
        objOwningDataGridView.mblnSuspendFilterInitialization = true;
        this.mobjOwningCell = objOwningCell;
        this.InitializeComponent();
        if (blnFilteringEnabled)
        {
          this.mobjOwningDataGridView = objOwningDataGridView;
          this.mobjOwningColumn = objOwningColumn;
          this.InitializeValuesComboBox();
          this.InitializeOperatorsContextMenu();
          this.InitializeOperatorsButton();
          this.InitializeClearButton();
        }
        objOwningDataGridView.mblnSuspendFilterInitialization = false;
      }

      /// <summary>Initializes the operators button.</summary>
      private void InitializeOperatorsButton()
      {
        if (this.mobjOwningDataGridView == null || !(this.mobjOwningDataGridView.Skin is DataGridViewSkin skin))
          return;
        this.mobjOperatorsButton.Image = skin.GetResourceHandleFromReference((SkinResourceReference) skin.InitialOperatorImage);
      }

      /// <summary>Handles context menu click.</summary>
      /// <param name="objSource">The obj source.</param>
      /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> instance containing the event data.</param>
      private void OperatorsContextMenuClick(object objSource, MenuItemEventArgs objArgs)
      {
        MenuItem menuItem = objArgs.MenuItem;
        if (menuItem == null)
          return;
        this.SetOperator(menuItem.Tag, menuItem.Icon);
        this.FireFilterChanged(false);
      }

      /// <summary>Occurs when the values combobox's text changed.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void ValuesComboBoxTextChanged(object sender, EventArgs e)
      {
        if (this.mobjValuesComboBox.SelectedItem is DataGridViewSystemFilterOption selectedItem && selectedItem.Option == SystemFilterOptions.Custom)
        {
          if (this.mobjOwningColumn.ShowHeaderFilter && this.mobjOwningColumn.HeaderCell != null)
          {
            this.mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
            this.mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
          }
          this.mobjOwningDataGridView.OpenCustomFilterDialog((DataGridViewCell) this.mobjOwningCell);
        }
        else
        {
          if (!this.mobjValuesComboBox.IsValidValue())
          {
            this.mobjValuesComboBox.TextChanged -= new EventHandler(this.ValuesComboBoxTextChanged);
            this.mobjValuesComboBox.Text = string.Empty;
            this.mobjValuesComboBox.TextChanged += new EventHandler(this.ValuesComboBoxTextChanged);
            int num = (int) MessageBox.Show(SR.GetString("InvalidFilterMessage"), string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          this.FireFilterChanged(false);
        }
      }

      /// <summary>Fire filter changed event.</summary>
      internal void FireFilterChanged(bool blnForceFilterChanged)
      {
        EventHandler filterChanged = this.FilterChanged;
        if (filterChanged == null || this.mobjOwningDataGridView.mblnSuspendFilterInitialization || ((!this.InValidFilterCriteria() ? 1 : (this.IsSystemFilter() ? 1 : 0)) | (blnForceFilterChanged ? 1 : 0)) == 0)
          return;
        this.mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
        if (this.mobjOwningColumn.ShowHeaderFilter && this.mobjOwningColumn.HasHeaderCell)
        {
          this.mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
          this.mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
        }
        this.mobjOwningColumn.mstrCustomFilterExpression = string.Empty;
        filterChanged((object) this, EventArgs.Empty);
        this.mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
      }

      /// <summary>Determines whether [is system filter].</summary>
      /// <returns>
      ///   <c>true</c> if [is system filter]; otherwise, <c>false</c>.
      /// </returns>
      private bool IsSystemFilter() => this.mobjValuesComboBox.SelectedItem is DataGridViewSystemFilterOption;

      /// <summary>
      /// Determines whether the filter is being created: either only an operator, or only value presents.
      /// </summary>
      /// <returns></returns>
      private bool InValidFilterCriteria()
      {
        if ((this.mobjValuesComboBox.SelectedItem != null || !string.IsNullOrEmpty(this.mobjValuesComboBox.Text)) && this.ComparisionOperator == FilterComparisonOperator.None)
          return true;
        return this.mobjValuesComboBox.SelectedItem == null && string.IsNullOrEmpty(this.mobjValuesComboBox.Text) && this.ComparisionOperator != 0;
      }

      /// <summary>Clears the filter.</summary>
      /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
      internal void ClearFilter(bool blnClearHeaderFilter) => this.ClearCriteria(blnClearHeaderFilter);

      /// <summary>Clears the criteria.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void ClearCriteria(object sender, EventArgs e) => this.ClearCriteria(true);

      /// <summary>Clears criteria.</summary>
      /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
      private void ClearCriteria(bool blnClearHeaderFilter)
      {
        bool filterInitialization = this.mobjOwningDataGridView.mblnSuspendFilterInitialization;
        string text1 = this.mobjValuesComboBox.Text;
        object tag = this.mobjOperatorsButton.Tag;
        string filterExpression = this.mobjOwningColumn.mstrCustomFilterExpression;
        bool flag = false;
        this.mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
        this.SetOperator((object) null, (ResourceHandle) null);
        this.mobjOwningColumn.mstrCustomFilterExpression = string.Empty;
        if (blnClearHeaderFilter && this.mobjOwningColumn.ShowHeaderFilter && this.mobjOwningColumn.HeaderCell != null && this.mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex != -1)
        {
          flag = true;
          this.mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
          this.mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
        }
        this.mobjValuesComboBox.SelectedIndex = -1;
        this.mobjValuesComboBox.Text = string.Empty;
        this.InitializeOperatorsButton();
        this.mobjOwningDataGridView.mblnSuspendFilterInitialization = filterInitialization;
        string text2 = this.mobjValuesComboBox.Text;
        if (((!(text1 != text2) ? 0 : (tag != this.mobjOperatorsButton.Tag ? 1 : 0)) | (flag ? 1 : 0)) == 0 && !(filterExpression != this.mobjOwningColumn.mstrCustomFilterExpression))
          return;
        this.FireFilterChanged(true);
      }

      /// <summary>Sets the operator.</summary>
      /// <param name="objOperator">The operator.</param>
      /// <param name="objResourceHandle">The resource handle.</param>
      internal void SetOperator(object objOperator, ResourceHandle objResourceHandle)
      {
        this.mobjOperatorsButton.Tag = objOperator;
        this.mobjOperatorsButton.Image = objResourceHandle;
      }

      /// <summary>Initializes the clear button.</summary>
      private void InitializeClearButton()
      {
        if (this.mobjOwningDataGridView == null || !(this.mobjOwningDataGridView.Skin is DataGridViewSkin skin))
          return;
        this.mobjClearButton.Image = skin.GetResourceHandleFromReference((SkinResourceReference) skin.FilterCellClearButtonImage);
      }

      /// <summary>Initializes the operators context menu.</summary>
      private void InitializeOperatorsContextMenu()
      {
        BindingSource dataSource = this.mobjOwningDataGridView.DataSource as BindingSource;
        if (this.mobjOwningColumn == null || dataSource == null)
          return;
        foreach (FilterComparisonOperator enmFilterComparisionOperator in DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(this.mobjOwningColumn.ValueType))
        {
          MenuItem objMenuItem = new MenuItem(SR.GetString(string.Format("FilterComparisionOperator_{0}", (object) enmFilterComparisionOperator.ToString())));
          objMenuItem.Tag = (object) enmFilterComparisionOperator;
          objMenuItem.Icon = this.GetFilterComparisionOperatorImage(enmFilterComparisionOperator);
          this.mobjOperatorsContextMenu.MenuItems.Add(objMenuItem);
        }
      }

      /// <summary>Refreshes this instance.</summary>
      internal void RefreshFilterComboBox()
      {
        object tag = this.mobjOperatorsButton.Tag;
        ResourceHandle image = this.mobjOperatorsButton.Image;
        string text = this.mobjValuesComboBox.Text;
        this.InitializeValuesComboBox();
        this.SetOperator(tag, image);
        this.mobjValuesComboBox.Text = text;
      }

      /// <summary>Gets the filter comparision operator image.</summary>
      /// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
      /// <returns></returns>
      private ResourceHandle GetFilterComparisionOperatorImage(
        FilterComparisonOperator enmFilterComparisionOperator)
      {
        return DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(this.mobjOwningDataGridView, enmFilterComparisionOperator);
      }

      /// <summary>Gets the filter comparision operator image.</summary>
      /// <param name="mobjOwningDataGridView">The mobj owning data grid view.</param>
      /// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
      /// <returns></returns>
      internal static ResourceHandle GetFilterComparisionOperatorImage(
        DataGridView objOwningDataGridView,
        FilterComparisonOperator enmFilterComparisionOperator)
      {
        ResourceHandle comparisionOperatorImage = (ResourceHandle) null;
        if (objOwningDataGridView != null && objOwningDataGridView.Skin is DataGridViewSkin skin)
        {
          switch (enmFilterComparisionOperator)
          {
            case FilterComparisonOperator.Equals:
              DataGridViewSkin dataGridViewSkin1 = skin;
              comparisionOperatorImage = dataGridViewSkin1.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin1.EqualsComparisionOperator);
              break;
            case FilterComparisonOperator.NotEquals:
              DataGridViewSkin dataGridViewSkin2 = skin;
              comparisionOperatorImage = dataGridViewSkin2.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin2.NotEqualsComparisionOperator);
              break;
            case FilterComparisonOperator.LessThan:
              DataGridViewSkin dataGridViewSkin3 = skin;
              comparisionOperatorImage = dataGridViewSkin3.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin3.LessThanComparisionOperator);
              break;
            case FilterComparisonOperator.LessThanOrEqualTo:
              DataGridViewSkin dataGridViewSkin4 = skin;
              comparisionOperatorImage = dataGridViewSkin4.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin4.LessThanOrEqualToComparisionOperator);
              break;
            case FilterComparisonOperator.GreaterThan:
              DataGridViewSkin dataGridViewSkin5 = skin;
              comparisionOperatorImage = dataGridViewSkin5.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin5.GreaterThanComparisionOperator);
              break;
            case FilterComparisonOperator.GreaterThanOrEqualTo:
              DataGridViewSkin dataGridViewSkin6 = skin;
              comparisionOperatorImage = dataGridViewSkin6.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin6.GreaterThanOrEqualToComparisionOperator);
              break;
            case FilterComparisonOperator.Like:
              DataGridViewSkin dataGridViewSkin7 = skin;
              comparisionOperatorImage = dataGridViewSkin7.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin7.LikeComparisionOperator);
              break;
            case FilterComparisonOperator.Match:
              DataGridViewSkin dataGridViewSkin8 = skin;
              comparisionOperatorImage = dataGridViewSkin8.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin8.MatchComparisionOperator);
              break;
            case FilterComparisonOperator.NotLike:
              DataGridViewSkin dataGridViewSkin9 = skin;
              comparisionOperatorImage = dataGridViewSkin9.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin9.NotLikeComparisionOperator);
              break;
            case FilterComparisonOperator.DoesNotMatch:
              DataGridViewSkin dataGridViewSkin10 = skin;
              comparisionOperatorImage = dataGridViewSkin10.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin10.DoesNotMatchComparisionOperator);
              break;
            case FilterComparisonOperator.StartsWith:
              DataGridViewSkin dataGridViewSkin11 = skin;
              comparisionOperatorImage = dataGridViewSkin11.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin11.StartsWithComparisionOperator);
              break;
            case FilterComparisonOperator.DoesNotStartWith:
              DataGridViewSkin dataGridViewSkin12 = skin;
              comparisionOperatorImage = dataGridViewSkin12.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin12.DoesNotStartWithComparisionOperator);
              break;
            case FilterComparisonOperator.EndsWith:
              DataGridViewSkin dataGridViewSkin13 = skin;
              comparisionOperatorImage = dataGridViewSkin13.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin13.EndsWithComparisionOperator);
              break;
            case FilterComparisonOperator.DoesNotEndWith:
              DataGridViewSkin dataGridViewSkin14 = skin;
              comparisionOperatorImage = dataGridViewSkin14.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin14.DoesNotEndWithComparisionOperator);
              break;
            case FilterComparisonOperator.Contains:
              DataGridViewSkin dataGridViewSkin15 = skin;
              comparisionOperatorImage = dataGridViewSkin15.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin15.ContainsComparisionOperator);
              break;
            case FilterComparisonOperator.DoesNotContain:
              DataGridViewSkin dataGridViewSkin16 = skin;
              comparisionOperatorImage = dataGridViewSkin16.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin16.DoesNotContainComparisionOperator);
              break;
            case FilterComparisonOperator.Custom:
              DataGridViewSkin dataGridViewSkin17 = skin;
              comparisionOperatorImage = dataGridViewSkin17.GetResourceHandleFromReference((SkinResourceReference) dataGridViewSkin17.CustomComparisionOperator);
              break;
          }
        }
        return comparisionOperatorImage;
      }

      /// <summary>Gets the filter comparison operator.</summary>
      /// <param name="objColumnType">Type of the column.</param>
      /// <returns></returns>
      internal static List<FilterComparisonOperator> GetFilterComparisonOperator(Type objColumnType)
      {
        List<FilterComparisonOperator> comparisonOperator = new List<FilterComparisonOperator>();
        comparisonOperator.Add(FilterComparisonOperator.Equals);
        comparisonOperator.Add(FilterComparisonOperator.NotEquals);
        if (objColumnType != typeof (bool))
        {
          comparisonOperator.Add(FilterComparisonOperator.LessThan);
          comparisonOperator.Add(FilterComparisonOperator.LessThanOrEqualTo);
          comparisonOperator.Add(FilterComparisonOperator.GreaterThan);
          comparisonOperator.Add(FilterComparisonOperator.GreaterThanOrEqualTo);
        }
        if (objColumnType != typeof (sbyte) && objColumnType != typeof (short) && objColumnType != typeof (int) && objColumnType != typeof (long) && objColumnType != typeof (byte) && objColumnType != typeof (ushort) && objColumnType != typeof (uint) && objColumnType != typeof (long) && objColumnType != typeof (float) && objColumnType != typeof (double) && objColumnType != typeof (bool) && objColumnType != typeof (char) && objColumnType != typeof (Decimal))
        {
          comparisonOperator.Add(FilterComparisonOperator.Like);
          comparisonOperator.Add(FilterComparisonOperator.StartsWith);
          comparisonOperator.Add(FilterComparisonOperator.Contains);
          comparisonOperator.Add(FilterComparisonOperator.EndsWith);
          comparisonOperator.Add(FilterComparisonOperator.DoesNotStartWith);
          comparisonOperator.Add(FilterComparisonOperator.DoesNotEndWith);
          comparisonOperator.Add(FilterComparisonOperator.DoesNotContain);
          comparisonOperator.Add(FilterComparisonOperator.NotLike);
        }
        return comparisonOperator;
      }

      /// <summary>Initializes the values combo box.</summary>
      private void InitializeValuesComboBox()
      {
        if (!string.IsNullOrEmpty(this.mobjValuesComboBox.Text) || this.mobjOperatorsButton.Tag != null)
          return;
        this.mobjValuesComboBox.OwningColumn = this.mobjOwningColumn;
        this.mobjValuesComboBox.OwningDataGridView = this.mobjOwningDataGridView;
        this.mobjValuesComboBox.InitializeFilterValues(true, false, false);
      }

      /// <summary>Initializes the component.</summary>
      private void InitializeComponent()
      {
        this.mobjLeftPanel = new Gizmox.WebGUI.Forms.Panel();
        this.mobjOperatorsButton = new DataGridViewFilterButton();
        this.mobjRightPanel = new Gizmox.WebGUI.Forms.Panel();
        this.mobjClearButton = new DataGridViewFilterButton();
        this.mobjValuesComboBox = new DataGridViewFilterComboBox(this.mobjOwningDataGridView, this.mobjOwningColumn, (DataGridViewCell) this.mobjOwningCell);
        this.mobjOperatorsContextMenu = new ContextMenu();
        this.mobjLeftPanel.SuspendLayout();
        this.mobjRightPanel.SuspendLayout();
        this.SuspendLayout();
        this.mobjLeftPanel.Controls.Add((Control) this.mobjOperatorsButton);
        this.mobjLeftPanel.Dock = DockStyle.Left;
        this.mobjLeftPanel.Location = new Point(0, 0);
        this.mobjLeftPanel.Name = "mobjLeftPanel";
        this.mobjLeftPanel.Size = new Size(26, 24);
        this.mobjLeftPanel.TabIndex = 0;
        this.mobjLeftPanel.BackColor = Color.Transparent;
        this.mobjOperatorsButton.Anchor = AnchorStyles.None;
        this.mobjOperatorsButton.DropDownMenu = (Menu) this.mobjOperatorsContextMenu;
        this.mobjOperatorsButton.Location = new Point(1, 0);
        this.mobjOperatorsButton.Name = "mobjOperatorsButton";
        this.mobjOperatorsButton.Size = new Size(24, 24);
        this.mobjOperatorsButton.TabIndex = 1;
        this.mobjOperatorsButton.MenuClick += new MenuEventHandler(this.OperatorsContextMenuClick);
        this.mobjOperatorsButton.ToolTip = SR.GetString("SelectFilterOperation");
        this.mobjRightPanel.Controls.Add((Control) this.mobjClearButton);
        this.mobjRightPanel.Dock = DockStyle.Right;
        this.mobjRightPanel.Location = new Point(269, 0);
        this.mobjRightPanel.Name = "mobjRightPanel";
        this.mobjRightPanel.Size = new Size(26, 24);
        this.mobjRightPanel.TabIndex = 0;
        this.mobjRightPanel.BackColor = Color.Transparent;
        this.mobjClearButton.Anchor = AnchorStyles.None;
        this.mobjClearButton.Location = new Point(1, 0);
        this.mobjClearButton.Name = "mobjClearButton";
        this.mobjClearButton.Size = new Size(24, 24);
        this.mobjClearButton.TabIndex = 0;
        this.mobjClearButton.Click += new EventHandler(this.ClearCriteria);
        this.mobjClearButton.ToolTip = SR.GetString("ClearFilterExpression");
        this.mobjValuesComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.mobjValuesComboBox.BorderStyle = BorderStyle.Fixed3D;
        this.mobjValuesComboBox.FormattingEnabled = true;
        this.mobjValuesComboBox.Location = new Point(25, 2);
        this.mobjValuesComboBox.Name = "mobjValuesComboBox";
        this.mobjValuesComboBox.Size = new Size(237, 21);
        this.mobjValuesComboBox.TabIndex = 1;
        this.mobjValuesComboBox.TextChanged += new EventHandler(this.ValuesComboBoxTextChanged);
        this.BackColor = Color.Transparent;
        this.Dock = DockStyle.Fill;
        this.Controls.Add((Control) this.mobjValuesComboBox);
        this.Controls.Add((Control) this.mobjRightPanel);
        this.Controls.Add((Control) this.mobjLeftPanel);
        this.Size = new Size(287, 24);
        this.mobjLeftPanel.ResumeLayout(false);
        this.mobjRightPanel.ResumeLayout(false);
        this.ResumeLayout(false);
      }

      /// <summary>Gets the comparision operator.</summary>
      public FilterComparisonOperator ComparisionOperator => this.mobjOperatorsButton != null && this.mobjOperatorsButton.Tag != null ? (FilterComparisonOperator) this.mobjOperatorsButton.Tag : FilterComparisonOperator.None;

      /// <summary>Gets the comparision value.</summary>
      public string ComparisionValue => this.mobjValuesComboBox != null ? this.mobjValuesComboBox.Text : string.Empty;

      /// <summary>Gets the comparision Item.</summary>
      public object ComparisionItem => this.mobjValuesComboBox != null ? this.mobjValuesComboBox.SelectedItem : (object) null;
    }
  }
}
