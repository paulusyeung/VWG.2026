// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewBand
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a linear collection of elements in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewBand : DataGridViewElement, ICloneable, IDisposable
  {
    private int mintMinimumThickness;
    private int mintBandIndex;
    private int mintThickness;
    private int mintCachedThickness;
    private bool mblnBandIsRow;
    private DataGridViewCellStyle mobjDefaultCellStyle;
    private object mobjTag;
    private DataGridViewHeaderCell mobjHeaderCell;
    private Type mobjDefaultHeaderCellType;
    private ContextMenu mobjContextMenu;
    private ContextMenuStrip mobjContextMenuStrip;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand" /> class.
    /// </summary>
    internal DataGridViewBand() => this.IndexInternal = -1;

    /// <summary>Called when the band is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    protected override void OnDataGridViewChanged()
    {
      if (this.HasDefaultCellStyle)
      {
        bool isRow = this.IsRow;
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView == null)
          this.DefaultCellStyle.RemoveScope(isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
        else
          this.DefaultCellStyle.AddScope(dataGridView, isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
      }
      base.OnDataGridViewChanged();
    }

    /// <summary>Called when [state changed].</summary>
    /// <param name="elementState">State of the element.</param>
    internal void OnStateChanged(DataGridViewElementStates elementState)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return;
      if (this.IsRow)
      {
        DataGridViewRowCollection rows = dataGridView.Rows;
        rows.InvalidateCachedRowCount(elementState);
        rows.InvalidateCachedRowsHeight(elementState);
        if (this.Index == -1)
          return;
        dataGridView.OnDataGridViewElementStateChanged((DataGridViewElement) this, -1, elementState);
      }
      else
      {
        DataGridViewColumnCollection columns = dataGridView.Columns;
        columns.InvalidateCachedColumnCount(elementState);
        columns.InvalidateCachedColumnsWidth(elementState);
        dataGridView.OnDataGridViewElementStateChanged((DataGridViewElement) this, -1, elementState);
      }
    }

    /// <summary>Called when [state changing].</summary>
    /// <param name="elementState">State of the element.</param>
    private void OnStateChanging(DataGridViewElementStates elementState)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return;
      if (this.IsRow)
      {
        if (this.Index == -1)
          return;
        dataGridView.OnDataGridViewElementStateChanging((DataGridViewElement) this, -1, elementState);
      }
      else
        dataGridView.OnDataGridViewElementStateChanging((DataGridViewElement) this, -1, elementState);
    }

    /// <summary>
    /// Raises the <see cref="E:RightClick" /> event.
    /// </summary>
    /// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    internal void OnRightClick(MouseEventArgs objMouseEventArgs)
    {
      ContextMenu contextMenu = this.ContextMenu;
      if (this is DataGridViewRow)
        contextMenu = ((DataGridViewRow) this).HeaderCell.GetInheritedContextMenu(this.Index);
      else if (this is DataGridViewColumn)
        contextMenu = ((DataGridViewColumn) this).HeaderCell.GetInheritedContextMenu(this.Index);
      contextMenu?.Show((Component) this.DataGridView, (IIdentifiedComponent) this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      if (!(objEvent.Type == "Click"))
        return;
      int eventValue1 = this.GetEventValue(objEvent, "X", 0);
      int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
      MouseEventArgs objMouseEventArgs = new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0);
      if (objMouseEventArgs == null || objMouseEventArgs.Button != MouseButtons.Right)
        return;
      this.OnRightClick(objMouseEventArgs);
    }

    /// <summary>Renders the band attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      if (this.Index >= 0 && this.Frozen)
        objWriter.WriteAttributeString("FZ", "1");
      if (DataGridViewElement.ShouldRender(this.RenderMask, DataGridViewElement.Renderable.ContextMenuAttribute))
      {
        ContextMenu contextMenu = this.ContextMenu;
        if (this is DataGridViewRow)
          contextMenu = ((DataGridViewRow) this).HeaderCell.ContextMenu;
        else if (this is DataGridViewColumn)
          contextMenu = ((DataGridViewColumn) this).HeaderCell.ContextMenu;
        if (contextMenu != null)
          objWriter.WriteAttributeString("M", contextMenu.ID.ToString());
      }
      if (this.ElementReadOnly != DataGridViewElement.ElementReadOnlyType.True)
        return;
      objWriter.WriteAttributeString("RO", "1");
    }

    /// <summary>Gets the height info.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="intHeight">The height.</param>
    /// <param name="intMinimumHeight">The minimum height.</param>
    internal void GetHeightInfo(int intRowIndex, out int intHeight, out int intMinimumHeight)
    {
      intHeight = this.mintThickness;
      intMinimumHeight = this.mintMinimumThickness;
    }

    /// <summary>Detaches the context menu.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenu(object sender, EventArgs e) => this.ContextMenuInternal = (ContextMenu) null;

    /// <summary>Detaches the context menu strip.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenuStrip(object sender, EventArgs e) => this.ContextMenuStripInternal = (ContextMenuStrip) null;

    /// <summary>Clones the internal.</summary>
    /// <param name="objDataGridViewBand">The data grid view band.</param>
    internal void CloneInternal(DataGridViewBand objDataGridViewBand)
    {
      objDataGridViewBand.IndexInternal = -1;
      bool isRow = this.IsRow;
      objDataGridViewBand.BandIsRow = isRow;
      if (!isRow || this.Index >= 0 || this.DataGridView == null)
        objDataGridViewBand.StateInternal = this.State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
      objDataGridViewBand.Thickness = this.Thickness;
      objDataGridViewBand.MinimumThickness = this.MinimumThickness;
      objDataGridViewBand.CachedThickness = this.CachedThickness;
      objDataGridViewBand.Tag = this.Tag;
      objDataGridViewBand.LastModified = this.LastModified;
      objDataGridViewBand.LastModifiedParams = this.LastModifiedParams;
      if (this.HasDefaultCellStyle)
        objDataGridViewBand.DefaultCellStyle = new DataGridViewCellStyle(this.DefaultCellStyle);
      if (!this.HasDefaultHeaderCellType)
        return;
      objDataGridViewBand.DefaultHeaderCellType = this.DefaultHeaderCellType;
    }

    /// <summary>Creates an exact copy of this band.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual object Clone()
    {
      DataGridViewBand instance = (DataGridViewBand) Activator.CreateInstance(this.GetType());
      if (instance != null)
        this.CloneInternal(instance);
      return (object) instance;
    }

    /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.  </summary>
    /// <filterpriority>1</filterpriority>
    public void Dispose()
    {
    }

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> and optionally releases the managed resources.  </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool blnDisposing)
    {
    }

    /// <summary>Returns a string that represents the current band.</summary>
    /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(36);
      stringBuilder.Append("DataGridViewBand { Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Shoulds serialize DefaultHeaderCellType value.</summary>
    /// <returns></returns>
    private bool ShouldSerializeDefaultHeaderCellType() => this.mobjDefaultHeaderCellType != (Type) null;

    /// <summary>Shoulds serialize resizable value.</summary>
    /// <returns></returns>
    internal bool ShouldSerializeResizable() => this.StateIncludes(DataGridViewElementStates.ResizableSet);

    /// <summary>Gets or sets the default cell style of the band.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual DataGridViewCellStyle DefaultCellStyle
    {
      get
      {
        if (this.mobjDefaultCellStyle == null)
        {
          this.mobjDefaultCellStyle = new DataGridViewCellStyle();
          this.mobjDefaultCellStyle.AddScope(this.DataGridView, this.IsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
        }
        return this.mobjDefaultCellStyle;
      }
      set
      {
        DataGridViewCellStyle gridViewCellStyle = (DataGridViewCellStyle) null;
        bool isRow = this.IsRow;
        if (this.HasDefaultCellStyle)
        {
          gridViewCellStyle = this.DefaultCellStyle;
          gridViewCellStyle.RemoveScope(isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
        }
        DataGridView dataGridView = this.DataGridView;
        if (value != null || this.mobjDefaultCellStyle != null)
        {
          value?.AddScope(dataGridView, isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
          this.mobjDefaultCellStyle = value;
        }
        if ((gridViewCellStyle == null || value != null) && (gridViewCellStyle != null || value == null) && (gridViewCellStyle == null || value == null || gridViewCellStyle.Equals((object) this.DefaultCellStyle)) || dataGridView == null)
          return;
        dataGridView.OnBandDefaultCellStyleChanged(this);
      }
    }

    /// <summary>
    /// Gets or sets the run-time type of the default header cell.
    /// </summary>
    /// <value>The type of the default header cell.</value>
    /// <returns>A <see cref="T:System.Type"></see> that describes the run-time class of the object used as the default header cell.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:System.Type"></see> representing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> or a derived type. </exception>
    [Browsable(false)]
    public Type DefaultHeaderCellType
    {
      get
      {
        Type defaultHeaderCellType = this.mobjDefaultHeaderCellType;
        if (defaultHeaderCellType != (Type) null)
          return defaultHeaderCellType;
        return this.IsRow ? typeof (DataGridViewRowHeaderCell) : typeof (DataGridViewColumnHeaderCell);
      }
      set
      {
        if (!(value != (Type) null) && !(this.mobjDefaultHeaderCellType != (Type) null))
          return;
        this.mobjDefaultHeaderCellType = Type.GetType("Gizmox.WebGUI.Forms.DataGridViewHeaderCell").IsAssignableFrom(value) ? value : throw new ArgumentException(SR.GetString("DataGridView_WrongType", (object) nameof (DefaultHeaderCellType), (object) "Gizmox.WebGUI.Forms.DataGridViewHeaderCell"));
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has header cell.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has header cell; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool HasHeaderCell => this.mobjHeaderCell != null;

    /// <summary>Gets or sets the cached thickness.</summary>
    /// <value>The cached thickness.</value>
    internal int CachedThickness
    {
      get => this.mintCachedThickness;
      set => this.mintCachedThickness = value;
    }

    /// <summary>Gets a value indicating whether the band is currently displayed onscreen. </summary>
    /// <returns>true if the band is currently onscreen; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Displayed => (this.State & DataGridViewElementStates.Displayed) != 0;

    /// <summary>Gets or sets a value indicating whether the band will move when a user scrolls through the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>true if the band cannot be scrolled from view; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public virtual bool Frozen
    {
      get => (this.State & DataGridViewElementStates.Frozen) != 0;
      set
      {
        if ((this.State & DataGridViewElementStates.Frozen) != 0 == value)
          return;
        this.OnStateChanging(DataGridViewElementStates.Frozen);
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.Frozen;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.Frozen;
        this.OnStateChanged(DataGridViewElementStates.Frozen);
      }
    }

    /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set. </summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool HasDefaultCellStyle => this.mobjDefaultCellStyle != null;

    /// <summary>Gets or sets the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> representing the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.-or-The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    protected DataGridViewHeaderCell HeaderCellCore
    {
      get
      {
        DataGridViewHeaderCell headerCellCore = this.mobjHeaderCell;
        if (headerCellCore == null)
        {
          DataGridView dataGridView = this.DataGridView;
          headerCellCore = (DataGridViewHeaderCell) Activator.CreateInstance(this.DefaultHeaderCellType);
          headerCellCore.DataGridViewInternal = dataGridView;
          if (this.IsRow)
          {
            headerCellCore.OwningRowInternal = (DataGridViewRow) this;
            this.mobjHeaderCell = headerCellCore;
            return headerCellCore;
          }
          DataGridViewColumn dataGridViewColumn = this as DataGridViewColumn;
          headerCellCore.OwningColumnInternal = dataGridViewColumn;
          this.mobjHeaderCell = headerCellCore;
          if (dataGridView != null && dataGridView.SortedColumn == dataGridViewColumn)
            (headerCellCore as DataGridViewColumnHeaderCell).SortGlyphDirection = dataGridView.SortOrder;
        }
        return headerCellCore;
      }
      set
      {
        DataGridView dataGridView = this.DataGridView;
        DataGridViewHeaderCell mobjHeaderCell = this.mobjHeaderCell;
        bool isRow = this.IsRow;
        if (value != null || mobjHeaderCell != null)
        {
          if (mobjHeaderCell != null)
          {
            mobjHeaderCell.DataGridViewInternal = (DataGridView) null;
            if (isRow)
            {
              mobjHeaderCell.OwningRowInternal = (DataGridViewRow) null;
            }
            else
            {
              mobjHeaderCell.OwningColumnInternal = (DataGridViewColumn) null;
              ((DataGridViewColumnHeaderCell) mobjHeaderCell).SortGlyphDirectionInternal = SortOrder.None;
            }
          }
          if (value != null)
          {
            if (isRow)
            {
              if (!(value is DataGridViewRowHeaderCell))
                throw new ArgumentException(SR.GetString("DataGridView_WrongType", (object) "HeaderCell", (object) "Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"));
              if (value.OwningRow != null)
                value.OwningRow.HeaderCell = (DataGridViewRowHeaderCell) null;
              value.OwningRowInternal = (DataGridViewRow) this;
            }
            else
            {
              if (!(value is DataGridViewColumnHeaderCell))
                throw new ArgumentException(SR.GetString("DataGridView_WrongType", (object) "HeaderCell", (object) "Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"));
              if (value.OwningColumn != null)
                value.OwningColumn.HeaderCell = (DataGridViewColumnHeaderCell) null;
              value.OwningColumnInternal = (DataGridViewColumn) this;
            }
            value.DataGridViewInternal = dataGridView;
          }
          this.mobjHeaderCell = value;
        }
        if ((value != null || mobjHeaderCell == null) && (value == null || mobjHeaderCell != null) && (value == null || mobjHeaderCell == null || mobjHeaderCell.Equals((object) value)) || dataGridView == null)
          return;
        dataGridView.OnBandHeaderCellChanged(this);
      }
    }

    /// <summary>Gets the relative position of the band within the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <returns>The zero-based position of the band in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> or <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> that it is contained within. The default is -1, indicating that there is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public int Index => this.mintBandIndex;

    /// <summary>Sets the index internal.</summary>
    /// <value>The index internal.</value>
    internal int IndexInternal
    {
      set => this.mintBandIndex = value;
    }

    /// <summary>Sets a value indicating whether [displayed internal].</summary>
    /// <value><c>true</c> if [displayed internal]; otherwise, <c>false</c>.</value>
    internal bool DisplayedInternal
    {
      set
      {
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.Displayed;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.Displayed;
        if (this.DataGridView == null)
          return;
        this.OnStateChanged(DataGridViewElementStates.Displayed);
      }
    }

    /// <summary>Sets a value indicating whether [read only internal].</summary>
    /// <value><c>true</c> if [read only internal]; otherwise, <c>false</c>.</value>
    internal bool ReadOnlyInternal
    {
      set
      {
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.ReadOnly;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.ReadOnly;
        this.OnStateChanged(DataGridViewElementStates.ReadOnly);
      }
    }

    /// <summary>Sets a value indicating whether [selected internal].</summary>
    /// <value><c>true</c> if [selected internal]; otherwise, <c>false</c>.</value>
    internal bool SelectedInternal
    {
      set
      {
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.Selected;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.Selected;
        if (this.DataGridView == null)
          return;
        this.OnStateChanged(DataGridViewElementStates.Selected);
      }
    }

    /// <summary>Gets the cell style in effect for the current band, taking into account style inheritance.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>. The default is null.</returns>
    [Browsable(false)]
    public virtual DataGridViewCellStyle InheritedStyle => (DataGridViewCellStyle) null;

    /// <summary>Gets a value indicating whether the band represents a row.</summary>
    /// <returns>true if the band represents a <see cref="T:System.Windows.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
    protected bool IsRow => this.BandIsRow;

    /// <summary>Gets a value indicating whether the band represents a row.</summary>
    /// <returns>true if the band represents a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
    protected bool BandIsRow
    {
      get => this.mblnBandIsRow;
      set => this.mblnBandIsRow = value;
    }

    /// <summary>Gets or sets the thickness internal.</summary>
    /// <value>The thickness internal.</value>
    internal int ThicknessInternal
    {
      get => this.mintThickness;
      set
      {
        this.mintThickness = value;
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView == null)
          return;
        this.UpdateParams(AttributeType.Layout);
        dataGridView.Update(true);
        dataGridView.OnBandThicknessChanged(this);
      }
    }

    /// <summary>
    /// Sets the thickness internally without invoking the OnRowHeightChanged event.
    /// </summary>
    /// <param name="value">The value.</param>
    internal void SetThicknessInternal(int value) => this.mintThickness = value;

    /// <summary>Gets or sets the thickness.</summary>
    /// <value>The thickness.</value>
    internal int Thickness
    {
      get
      {
        int index = this.Index;
        if (!this.IsRow || index <= -1)
          return this.mintThickness;
        int intHeight;
        this.GetHeightInfo(index, out intHeight, out int _);
        return intHeight;
      }
      set
      {
        DataGridView dataGridView = this.DataGridView;
        int minimumThickness = this.MinimumThickness;
        bool isRow = this.IsRow;
        if (value < minimumThickness)
          value = minimumThickness;
        if (value > 65536)
        {
          if (isRow)
            throw new ArgumentOutOfRangeException("Height", SR.GetString("InvalidHighBoundArgumentEx", (object) "Height", (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 65536.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
          throw new ArgumentOutOfRangeException("Width", SR.GetString("InvalidHighBoundArgumentEx", (object) "Width", (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 65536.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        }
        bool flag = true;
        if (isRow)
        {
          if (dataGridView != null && dataGridView.AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
          {
            this.CachedThickness = value;
            flag = false;
          }
        }
        else
        {
          DataGridViewColumn objDataGridViewColumn = (DataGridViewColumn) this;
          DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = objDataGridViewColumn.InheritedAutoSizeMode;
          switch (inheritedAutoSizeMode)
          {
            case DataGridViewAutoSizeColumnMode.NotSet:
            case DataGridViewAutoSizeColumnMode.None:
            case DataGridViewAutoSizeColumnMode.Fill:
              if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && dataGridView != null && objDataGridViewColumn.Visible)
              {
                IntPtr handle = dataGridView.Handle;
                dataGridView.AdjustFillingColumn(objDataGridViewColumn, value);
                flag = false;
                break;
              }
              break;
            default:
              this.CachedThickness = value;
              flag = false;
              break;
          }
        }
        if (!flag || this.mintThickness == value)
          return;
        dataGridView?.OnBandThicknessChanging();
        this.ThicknessInternal = value;
      }
    }

    /// <summary>Gets or sets the minimum thickness.</summary>
    /// <value>The minimum thickness.</value>
    internal int MinimumThickness
    {
      get
      {
        int index = this.Index;
        if (!this.IsRow || index <= -1)
          return this.mintMinimumThickness;
        int intMinimumHeight;
        this.GetHeightInfo(index, out int _, out intMinimumHeight);
        return intMinimumHeight;
      }
      set
      {
        if (this.mintMinimumThickness == value)
          return;
        DataGridView dataGridView = this.DataGridView;
        bool isRow = this.IsRow;
        if (value < 2)
        {
          if (isRow)
          {
            object[] objArray = new object[1]
            {
              (object) 2.ToString((IFormatProvider) CultureInfo.CurrentCulture)
            };
            throw new ArgumentOutOfRangeException("MinimumHeight", (object) value, SR.GetString("DataGridViewBand_MinimumHeightSmallerThanOne", objArray));
          }
          object[] objArray1 = new object[1]
          {
            (object) 2.ToString((IFormatProvider) CultureInfo.CurrentCulture)
          };
          throw new ArgumentOutOfRangeException("MinimumWidth", (object) value, SR.GetString("DataGridViewBand_MinimumWidthSmallerThanOne", objArray1));
        }
        if (this.Thickness < value)
        {
          if (dataGridView != null && !isRow)
            dataGridView.OnColumnMinimumWidthChanging((DataGridViewColumn) this, value);
          this.Thickness = value;
        }
        this.mintMinimumThickness = value;
        dataGridView?.OnBandMinimumThicknessChanged(this);
      }
    }

    /// <summary>Gets or sets a value indicating whether the user can edit the band's cells.</summary>
    /// <returns>true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public virtual bool ReadOnly
    {
      get
      {
        DataGridView dataGridView = this.DataGridView;
        if ((this.State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
          return true;
        return dataGridView != null && dataGridView.ReadOnly;
      }
      set
      {
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView != null)
        {
          if (dataGridView.ReadOnly)
            return;
          if (this.BandIsRow)
          {
            if (this.Index == -1)
              throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (ReadOnly)));
            this.OnStateChanging(DataGridViewElementStates.ReadOnly);
            dataGridView.SetReadOnlyRowCore(this.Index, value);
          }
          else
          {
            this.OnStateChanging(DataGridViewElementStates.ReadOnly);
            dataGridView.SetReadOnlyColumnCore(this.Index, value);
          }
        }
        else if ((this.State & DataGridViewElementStates.ReadOnly) != 0 != value)
        {
          if (value)
          {
            if (this.BandIsRow)
            {
              foreach (DataGridViewCell cell in (BaseCollection) ((DataGridViewRow) this).Cells)
              {
                if (cell.ReadOnly)
                  cell.ReadOnlyInternal = false;
              }
            }
            this.StateInternal = this.State | DataGridViewElementStates.ReadOnly;
          }
          else
            this.StateInternal = this.State & ~DataGridViewElementStates.ReadOnly;
        }
        this.ElementReadOnly = value ? DataGridViewElement.ElementReadOnlyType.True : DataGridViewElement.ElementReadOnlyType.False;
      }
    }

    /// <summary>Gets or sets the element read only.</summary>
    /// <value>The element read only.</value>
    protected internal override DataGridViewElement.ElementReadOnlyType ElementReadOnly
    {
      get => base.ElementReadOnly;
      set
      {
        base.ElementReadOnly = value;
        if (this.BandIsRow)
        {
          foreach (DataGridViewElement cell in (BaseCollection) ((DataGridViewRow) this).Cells)
            cell.ClearElementReadOnly();
        }
        else
        {
          DataGridView dataGridView = this.DataGridView;
          if (dataGridView == null)
            return;
          int index = this.Index;
          if (index < 0 || index >= dataGridView.Columns.Count)
            return;
          foreach (DataGridViewRow row in (IEnumerable) dataGridView.Rows)
            row.Cells[index].ClearElementReadOnly();
        }
      }
    }

    /// <summary>Gets or sets a value indicating whether the band can be resized in the user interface (UI).</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(true)]
    public virtual DataGridViewTriState Resizable
    {
      get
      {
        if ((this.State & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
          return (this.State & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None ? DataGridViewTriState.False : DataGridViewTriState.True;
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView == null)
          return DataGridViewTriState.NotSet;
        return !dataGridView.AllowUserToResizeColumns ? DataGridViewTriState.False : DataGridViewTriState.True;
      }
      set
      {
        int resizable1 = (int) this.Resizable;
        if (value == DataGridViewTriState.NotSet)
        {
          this.StateInternal = this.State & ~DataGridViewElementStates.ResizableSet;
        }
        else
        {
          this.StateInternal = this.State | DataGridViewElementStates.ResizableSet;
          if ((this.State & DataGridViewElementStates.Resizable) != 0 != (value == DataGridViewTriState.True))
          {
            if (value == DataGridViewTriState.True)
              this.StateInternal = this.State | DataGridViewElementStates.Resizable;
            else
              this.StateInternal = this.State & ~DataGridViewElementStates.Resizable;
          }
        }
        int resizable2 = (int) this.Resizable;
        if (resizable1 == resizable2)
          return;
        this.OnStateChanged(DataGridViewElementStates.Resizable);
      }
    }

    /// <summary>Gets or sets a value indicating whether the band is in a selected user interface (UI) state.</summary>
    /// <returns>true if the band is selected; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is true, but the band has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. -or-This property is being set on a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual bool Selected
    {
      get => (this.State & DataGridViewElementStates.Selected) != 0;
      set
      {
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView != null)
        {
          int index = this.Index;
          if (!this.IsRow)
          {
            if (dataGridView.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
              return;
            dataGridView.SetSelectedColumnCoreInternal(index, value);
          }
          else
          {
            if (index == -1)
              throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (Selected)));
            if (dataGridView.SelectionMode != DataGridViewSelectionMode.FullRowSelect && dataGridView.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
              return;
            dataGridView.SetSelectedRowCoreInternal(index, value);
          }
        }
        else if (value)
          throw new InvalidOperationException(SR.GetString("DataGridViewBand_CannotSelect"));
      }
    }

    /// <summary>Gets or sets the object that contains data to associate with the band.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains information associated with the band. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object Tag
    {
      get => this.mobjTag;
      set => this.mobjTag = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the band is visible to the user.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    /// <returns>true if the band is visible; otherwise, false. The default is true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and the band is the row for new records.</exception>
    [DefaultValue(true)]
    public virtual bool Visible
    {
      get => (this.State & DataGridViewElementStates.Visible) != 0;
      set
      {
        if ((this.State & DataGridViewElementStates.Visible) != 0 == value)
          return;
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView != null && this.IsRow && dataGridView.NewRowIndex != -1 && dataGridView.NewRowIndex == this.Index && !value)
          throw new InvalidOperationException(SR.GetString("DataGridViewBand_NewRowCannotBeInvisible"));
        this.OnStateChanging(DataGridViewElementStates.Visible);
        this.SetVisibleInternal(value);
        this.OnStateChanged(DataGridViewElementStates.Visible);
      }
    }

    /// <summary>Sets the visible internal.</summary>
    /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
    internal void SetVisibleInternal(bool blnValue)
    {
      if (blnValue)
        this.StateInternal = this.State | DataGridViewElementStates.Visible;
      else
        this.StateInternal = this.State & ~DataGridViewElementStates.Visible;
    }

    /// <summary>
    /// Gets a value indicating whether this instance has default header cell type.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has default header cell type; otherwise, <c>false</c>.
    /// </value>
    internal bool HasDefaultHeaderCellType => this.mobjDefaultHeaderCellType != (Type) null;

    /// <summary>Gets or sets the context menu code.</summary>
    [Browsable(true)]
    [DefaultValue(null)]
    public virtual ContextMenu ContextMenu
    {
      get => this.IsRow ? ((DataGridViewRow) this).GetContextMenu(this.Index) : this.ContextMenuInternal;
      set => this.ContextMenuInternal = value;
    }

    /// <summary>Gets or sets the context menu strip.</summary>
    /// <value>The context menu strip.</value>
    [DefaultValue(null)]
    public virtual ContextMenuStrip ContextMenuStrip
    {
      get => this.BandIsRow ? ((DataGridViewRow) this).GetContextMenuStrip(this.Index) : this.ContextMenuStripInternal;
      set => this.ContextMenuStripInternal = value;
    }

    /// <summary>Gets or sets the context menu internal.</summary>
    /// <value>The context menu internal.</value>
    internal ContextMenu ContextMenuInternal
    {
      get => this.mobjContextMenu;
      set
      {
        ContextMenu mobjContextMenu = this.mobjContextMenu;
        if (mobjContextMenu == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenu);
        if (mobjContextMenu != null)
          mobjContextMenu.Disposed -= eventHandler;
        this.mobjContextMenu = value;
        if (value != null)
          value.Disposed += eventHandler;
        this.DataGridView?.OnBandContextMenuChanged(this);
      }
    }

    /// <summary>Gets or sets the context menu strip internal.</summary>
    /// <value>The context menu strip internal.</value>
    internal ContextMenuStrip ContextMenuStripInternal
    {
      get => this.mobjContextMenuStrip;
      set
      {
        ContextMenuStrip contextMenuStrip = this.mobjContextMenuStrip;
        if (contextMenuStrip == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenuStrip);
        if (contextMenuStrip != null)
          contextMenuStrip.Disposed -= eventHandler;
        this.mobjContextMenuStrip = value;
        if (value != null)
          value.Disposed += eventHandler;
        this.DataGridView?.OnBandContextMenuStripChanged(this);
      }
    }
  }
}
