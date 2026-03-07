// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewFilterComboBoxBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewFilterComboBoxBase : ComboBox
  {
    private DataGridView mobjOwningDataGridView;
    private DataGridViewColumn mobjOwningColumn;
    private DataGridViewCell mobjOwningCell;
    [NonSerialized]
    private TypeConverter mobjTypeConverter;

    /// <summary>Gets or sets the owning cell.</summary>
    /// <value>The owning cell.</value>
    public DataGridViewCell OwningCell
    {
      get => this.mobjOwningCell;
      set => this.mobjOwningCell = value;
    }

    /// <summary>Gets or sets the owning column.</summary>
    /// <value>The owning column.</value>
    public DataGridViewColumn OwningColumn
    {
      get => this.mobjOwningColumn;
      set => this.mobjOwningColumn = value;
    }

    /// <summary>Gets or sets the owning data grid view.</summary>
    /// <value>The owning data grid view.</value>
    public DataGridView OwningDataGridView
    {
      get => this.mobjOwningDataGridView;
      set => this.mobjOwningDataGridView = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterComboBoxBase" /> class.
    /// </summary>
    /// <param name="objDataGridView">The obj data grid view.</param>
    /// <param name="objColumn">The obj column.</param>
    /// <param name="objFilterCell">The obj filter cell.</param>
    public DataGridViewFilterComboBoxBase(
      DataGridView objDataGridView,
      DataGridViewColumn objColumn,
      DataGridViewCell objFilterCell)
    {
      this.mobjOwningDataGridView = objDataGridView;
      this.mobjOwningColumn = objColumn;
      this.mobjOwningCell = objFilterCell;
    }

    /// <summary>Initializes the filter values.</summary>
    /// <param name="blnAddSystemFilterOptions">if set to <c>true</c> [BLN add system filter options].</param>
    /// <param name="blnCalculateDropDownWidth">if set to <c>true</c> [BLN set drop down width].</param>
    /// <param name="blnClearBindingSourceFilter">if set to <c>true</c> [BLN clear binding source filter].</param>
    public virtual void InitializeFilterValues(
      bool blnAddSystemFilterOptions,
      bool blnCalculateDropDownWidth,
      bool blnClearBindingSourceFilter)
    {
      if (this.mobjOwningDataGridView == null || this.mobjOwningColumn == null)
        return;
      this.mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
      this.Items.Clear();
      if (this.mobjOwningDataGridView.DataSource is BindingSource bindingSource)
      {
        if (blnClearBindingSourceFilter && !string.IsNullOrEmpty(bindingSource.Filter))
        {
          bindingSource = (BindingSource) bindingSource.Clone();
          bindingSource.RemoveFilter();
        }
        string dataPropertyName = this.mobjOwningColumn.DataPropertyName;
        Font font = this.Font;
        int num = 0;
        int intMaxWidth = 0;
        CurrencyManager currencyManager = bindingSource.CurrencyManager;
        foreach (object objItem in (IEnumerable) bindingSource.List)
        {
          object obj = ListControl.FilterItemOnProperty(currencyManager, objItem, dataPropertyName);
          if (obj != null)
          {
            string str = obj.ToString();
            if (!string.IsNullOrEmpty(str) && !this.Items.Contains((object) str))
            {
              this.Items.Add((object) str);
              ++num;
              if (blnCalculateDropDownWidth)
              {
                Size stringMeasurements = CommonUtils.GetStringMeasurements(str, font);
                if (intMaxWidth < stringMeasurements.Width)
                  intMaxWidth = stringMeasurements.Width;
              }
              if (this.mobjOwningDataGridView.MaxFilterOptions > 0)
              {
                if (num == this.mobjOwningDataGridView.MaxFilterOptions)
                  break;
              }
            }
          }
        }
        if (blnAddSystemFilterOptions)
        {
          int intIndex = 0;
          foreach (SystemFilterOptions enmOption in Enum.GetValues(typeof (SystemFilterOptions)))
          {
            DataGridViewSystemFilterOption objItem = new DataGridViewSystemFilterOption(enmOption);
            this.Items.Insert(intIndex, (object) objItem);
            if (blnCalculateDropDownWidth)
            {
              Size stringMeasurements = CommonUtils.GetStringMeasurements(objItem.ToString(), font);
              if (intMaxWidth < stringMeasurements.Width)
                intMaxWidth = stringMeasurements.Width;
            }
            ++intIndex;
          }
        }
        if (blnCalculateDropDownWidth)
          this.UpdateDropDownWidth(intMaxWidth);
        this.mobjOwningDataGridView.FilterValuesInitializing((ComboBox) this, this.mobjOwningColumn);
      }
      this.mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
    }

    /// <summary>Updates the width of the drop down.</summary>
    /// <param name="intMaxWidth">Width of the int max.</param>
    protected virtual void UpdateDropDownWidth(int intMaxWidth) => this.DropDownWidth = intMaxWidth;

    /// <summary>Determines whether [value is valid ].</summary>
    /// <returns>
    ///   <c>true</c> if [is valid value]; otherwise, <c>false</c>.
    /// </returns>
    protected internal virtual bool IsValidValue()
    {
      string text = this.Text;
      if (!string.IsNullOrEmpty(text) && this.FindStringIgnoreCase(text) == -1)
      {
        if (this.mobjTypeConverter == null && this.mobjOwningColumn != null)
          this.mobjTypeConverter = TypeDescriptor.GetConverter(this.mobjOwningColumn.ValueType);
        if (this.mobjTypeConverter != null && !this.mobjTypeConverter.IsValid((object) text))
          return false;
      }
      return true;
    }
  }
}
