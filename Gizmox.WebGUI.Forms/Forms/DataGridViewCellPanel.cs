// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewCellPanelSkin))]
  [Serializable]
  public class DataGridViewCellPanel : Panel
  {
    private int mintColspan;
    private int mintRowspan;
    private DataGridViewCell mobjOwnerCell;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellPanel" /> class.
    /// </summary>
    /// <param name="objOwner">The obj owner.</param>
    public DataGridViewCellPanel(DataGridViewCell objOwner) => this.mobjOwnerCell = objOwner;

    /// <summary>Gets or sets the control custom style.</summary>
    /// <value>The custom style.</value>
    /// <remarks></remarks>
    public override string CustomStyle
    {
      get => nameof (DataGridViewCellPanel);
      set => base.CustomStyle = value;
    }

    /// <summary>
    /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
    /// </summary>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    public override BindingContext BindingContext
    {
      get
      {
        DataGridViewCell ownerCell = this.OwnerCell;
        if (ownerCell != null)
        {
          DataGridView dataGridView = ownerCell.DataGridView;
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
    /// <value></value>
    public override Form Form
    {
      get
      {
        DataGridViewCell ownerCell = this.OwnerCell;
        if (ownerCell != null)
        {
          DataGridView dataGridView = ownerCell.DataGridView;
          if (dataGridView != null)
            return dataGridView.Form;
        }
        return base.Form;
      }
    }

    /// <summary>Gets or sets the coll span.</summary>
    /// <value>The coll span.</value>
    internal int Colspan
    {
      get => this.mintColspan;
      set
      {
        if (this.mintColspan == value)
          return;
        this.mintColspan = value;
        this.UpdateDataGridView();
      }
    }

    /// <summary>Gets or sets the owner.</summary>
    /// <value>The owner.</value>
    public DataGridViewCell OwnerCell => this.mobjOwnerCell;

    /// <summary>Gets or sets the row span.</summary>
    /// <value>The row span.</value>
    internal int Rowspan
    {
      get => this.mintRowspan;
      set
      {
        if (this.mintRowspan == value)
          return;
        this.mintRowspan = value;
        this.UpdateDataGridView();
      }
    }

    /// <summary>Updates the data grid view.</summary>
    private void UpdateDataGridView()
    {
      DataGridViewCell ownerCell = this.OwnerCell;
      if (ownerCell == null)
        return;
      this.ValidatePanelLayout(ownerCell);
      ownerCell.DataGridView?.Update();
    }

    /// <summary>Validates the panel layout.</summary>
    /// <param name="objOwnerCell">The owner cell.</param>
    private void ValidatePanelLayout(DataGridViewCell objOwnerCell)
    {
      if (objOwnerCell == null)
        return;
      DataGridView dataGridView = objOwnerCell.DataGridView;
      if (dataGridView == null)
        return;
      int rowspan = this.Rowspan;
      if (rowspan > 1)
      {
        DataGridViewRow owningRow = objOwnerCell.OwningRow;
        if (owningRow != null)
        {
          bool frozen = owningRow.Frozen;
          int num = owningRow.Index;
          bool useInternalPaging = dataGridView.UseInternalPaging;
          IList list = (IList) null;
          for (; num >= 0 && rowspan > 1; --rowspan)
          {
            num = dataGridView.Rows.GetNextRow(num, DataGridViewElementStates.Visible);
            if (num >= 0)
            {
              DataGridViewRow row = dataGridView.Rows[num];
              if (row == null)
                throw new ArgumentOutOfRangeException("Rowspan");
              if (useInternalPaging)
              {
                if (list == null)
                  list = dataGridView.PageRows;
                if (!list.Contains((object) row))
                  throw new InvalidOperationException("Cell's panel cannot be spread over several pages.");
              }
              if (row.Frozen != frozen)
                throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
            }
          }
        }
      }
      int colspan = this.Colspan;
      if (colspan <= 1)
        return;
      DataGridViewColumn owningColumn = objOwnerCell.OwningColumn;
      if (owningColumn == null)
        return;
      bool frozen1 = owningColumn.Frozen;
      for (DataGridViewColumn objDataGridViewColumnStart = owningColumn; objDataGridViewColumnStart != null && colspan > 1; --colspan)
      {
        objDataGridViewColumnStart = dataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
        if (objDataGridViewColumnStart == null)
          throw new ArgumentOutOfRangeException("Colpan");
        if (objDataGridViewColumnStart.Frozen != frozen1)
          throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
      }
    }

    /// <summary>An abstract control method rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.ValidatePanelLayout(this.OwnerCell);
      base.Render(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the docking.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="enmDockStyle">The dock style.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected override void RenderDocking(
      IContext objContext,
      IAttributeWriter objWriter,
      DockStyle enmDockStyle,
      bool blnForceRender)
    {
      objWriter.WriteAttributeString("D", "F");
    }

    /// <summary>Renders the anchoring.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="enmAnchorStyle">The anchor style.</param>
    /// <param name="blnForceEmptyRender">if set to <c>true</c> [BLN force empty render].</param>
    protected override void RenderAnchoring(
      IContext objContext,
      IAttributeWriter objWriter,
      AnchorStyles enmAnchorStyle,
      bool blnForceEmptyRender)
    {
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      int colspan = this.Colspan;
      if (colspan > 0)
        objWriter.WriteAttributeString("CSP", colspan.ToString());
      int rowspan = this.Rowspan;
      if (rowspan <= 0)
        return;
      objWriter.WriteAttributeString("RSP", rowspan.ToString());
    }

    /// <summary>
    /// Gets the key event captures for DataGridViewCellPanel.
    /// The DataGridViewCellPanel is a "stopper" for all key events to prevent the DataGrid from handling these events
    /// </summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => KeyCaptures.All;

    /// <summary>Prerender component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    internal void PreRenderComponent(IContext objContext, long lngRequestID) => this.PreRenderControl(objContext, lngRequestID);
  }
}
