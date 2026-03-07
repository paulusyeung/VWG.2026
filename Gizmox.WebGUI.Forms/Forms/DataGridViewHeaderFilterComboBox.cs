// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewHeaderFilterComboBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A DataGridViewHeaderFilterComboBox control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewHeaderFilterComboBoxSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewHeaderFilterComboBox : DataGridViewFilterComboBoxBase
  {
    private bool mblnIsCustomFilter;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderFilterComboBox" /> class.
    /// </summary>
    /// <param name="objOwnerCell">The obj owner cell.</param>
    public DataGridViewHeaderFilterComboBox(DataGridViewColumnHeaderCell objOwnerCell)
      : base(objOwnerCell.DataGridView, objOwnerCell.OwningColumn, (DataGridViewCell) objOwnerCell)
    {
      this.CustomStyle = "DataGridViewHeaderFilterComboBoxSkin";
      this.DropDownWidth = this.OwningColumn.Width;
    }

    /// <summary>
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderIsCustomFilterAttribute(objWriter);
    }

    /// <summary>Renders the options.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnUseCode">if set to <c>true</c> [BLN use code].</param>
    /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
    /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
    /// <param name="blnUseIndexCode">if set to <c>true</c> [BLN use index code].</param>
    /// <param name="objUseCodeProp">The obj use code prop.</param>
    protected override void RenderOptions(
      IResponseWriter objWriter,
      bool blnUseCode,
      bool blnShouldRenderItemImage,
      bool blnShouldRenderItemColor,
      bool blnUseIndexCode,
      PropertyInfo objUseCodeProp)
    {
      if (this.mblnIsCustomFilter)
        return;
      base.RenderOptions(objWriter, blnUseCode, blnShouldRenderItemImage, blnShouldRenderItemColor, blnUseIndexCode, objUseCodeProp);
    }

    /// <summary>Renders the is custom filter attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderIsCustomFilterAttribute(IAttributeWriter objWriter)
    {
      if (!this.IsCustomFilter)
        return;
      objWriter.WriteAttributeString("ICF", "1");
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
    /// event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnClick(EventArgs objEventArgs)
    {
      base.OnClick(objEventArgs);
      this.OnCustomHeaderFilterClicked();
    }

    /// <summary>Called when [custom header filter clicked].</summary>
    private void OnCustomHeaderFilterClicked()
    {
      if (!this.mblnIsCustomFilter)
        return;
      this.OwningDataGridView.OnCustomHeaderFilterClicked(new CustomFilterApplyingEventArgs(this.OwningColumn));
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.mblnIsCustomFilter)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>Initializes the filter values.</summary>
    /// <param name="blnAddSystemFilterOptions">if set to <c>true</c> [BLN add system filter options].</param>
    /// <param name="blnCalculateDropDownWidth">if set to <c>true</c> [BLN set drop down width].</param>
    /// <param name="blnClearBindingSourceFilter">if set to <c>true</c> [BLN clear binding source filter].</param>
    public override void InitializeFilterValues(
      bool blnAddSystemFilterOptions,
      bool blnCalculateDropDownWidth,
      bool blnClearBindingSourceFilter)
    {
      base.InitializeFilterValues(blnAddSystemFilterOptions, blnCalculateDropDownWidth && !this.IsCustomFilter, blnClearBindingSourceFilter);
    }

    /// <summary>Updates the width of the drop down.</summary>
    /// <param name="intMaxWidth">Width of the int max.</param>
    protected override void UpdateDropDownWidth(int intMaxWidth)
    {
      if (this.Skin is DataGridViewHeaderFilterComboBoxSkin skin)
        intMaxWidth += skin.DropDownWidthSpacer;
      base.UpdateDropDownWidth(intMaxWidth);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is custom filter.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is custom filter; otherwise, <c>false</c>.
    /// </value>
    public bool IsCustomFilter
    {
      get => this.mblnIsCustomFilter;
      set
      {
        if (this.mblnIsCustomFilter == value)
          return;
        this.mblnIsCustomFilter = value;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
    /// </summary>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    public override BindingContext BindingContext
    {
      get
      {
        if (this.OwningCell is DataGridViewColumnHeaderCell owningCell)
        {
          DataGridView dataGridView = owningCell.DataGridView;
          if (dataGridView != null)
          {
            DataGridView rootGrid = dataGridView.RootGrid;
            return rootGrid != null ? rootGrid.BindingContext : dataGridView.BindingContext;
          }
        }
        return base.BindingContext;
      }
      set
      {
      }
    }

    /// <summary>Gets the owner form.</summary>
    public override Form Form => this.OwningDataGridView != null ? this.OwningDataGridView.Form : base.Form;
  }
}
