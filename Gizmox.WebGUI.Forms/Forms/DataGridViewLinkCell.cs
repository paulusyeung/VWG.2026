// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewLinkCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a cell that contains a link. </summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewLinkCellSkin))]
  [Serializable]
  public class DataGridViewLinkCell : DataGridViewCell
  {
    private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginLeft = 1;
    private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginRight = 2;
    private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginBottom = 1;
    private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginTop = 1;
    private bool mblnClientMode;
    private bool mblnLinkVisited;
    private bool mblnLinkVisitedSet;
    private string mstrUrl = string.Empty;
    private LinkState menmLinkState;
    private Color mobjLinkVisitedLinkColor = Color.Empty;
    private int mintLinkTrackVisitedState;
    private Color mobjLinkColor = Color.Empty;
    private LinkBehavior menmLinkBehavior;
    private int mintLinkUseColumnTextForLinkValue;
    private Color mobjLinkActiveColor = Color.Empty;
    private static Type mobjCellType;
    private static Type mobjDefaultFormattedValueType = typeof (string);
    private static Type mobjDefaultValueType = typeof (object);

    static DataGridViewLinkCell() => DataGridViewLinkCell.mobjCellType = typeof (DataGridViewLinkCell);

    /// <summary>Indicates whether the row containing the cell will be unshared when a key is released and the cell has focus.</summary>
    /// <returns>true if the SPACE key was released, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.TrackVisitedState"></see> property is true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.LinkVisited"></see> property is false, and the CTRL, ALT, and SHIFT keys are not pressed; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains data about the key press.</param>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex) => false;

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (!this.ClientMode && !string.IsNullOrEmpty(this.Url) && !this.ReadOnly)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objEvent"></param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "LinkStateChange":
          this.LinkState = (LinkState) Enum.Parse(typeof (LinkState), objEvent["LS"]);
          break;
        case "Click":
          if (this.ReadOnly)
            break;
          this.OpenLink();
          break;
      }
    }

    /// <summary>Indicates whether the row containing the cell will be unshared when the mouse button is pressed while the pointer is over the cell.</summary>
    /// <returns>true if the mouse pointer is over the link; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
    protected override bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether the row containing the cell will be unshared when the mouse pointer leaves the cell.</summary>
    /// <returns>true if the link displayed by the cell is not in the normal state; otherwise, false.</returns>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    protected override bool MouseLeaveUnsharesRow(int intRowIndex) => false;

    /// <summary>Indicates whether the row containing the cell will be unshared when the mouse pointer moves over the cell.</summary>
    /// <returns>true if the mouse pointer is over the link and the link is has not yet changed color to reflect the hover state; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
    protected override bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether the row containing the cell will be unshared when the mouse button is released while the pointer is over the cell. </summary>
    /// <returns>true if the mouse pointer is over the link; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
    protected override bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Renders the cell text/value.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objFormatedValue">The formated value.</param>
    protected override void RenderCellValue(
      IContext objContext,
      IAttributeWriter objWriter,
      object objFormatedValue)
    {
      base.RenderCellValue(objContext, objWriter, objFormatedValue);
      if (objFormatedValue == null || !(objFormatedValue.ToString() != string.Empty))
        return;
      objWriter.WriteAttributeText("TX", objFormatedValue.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      if (this.InheritedLinkColor != LinkUtilities.IELinkColor)
        objWriter.WriteAttributeString("LC", CommonUtils.GetHtmlColor(this.InheritedLinkColor));
      if (this.InheritedActiveLinkColor != LinkUtilities.IEActiveLinkColor)
        objWriter.WriteAttributeString("ALC", CommonUtils.GetHtmlColor(this.InheritedActiveLinkColor));
      if (this.InheritedVisitedLinkColor != LinkUtilities.IEVisitedLinkColor)
        objWriter.WriteAttributeString("VLC", CommonUtils.GetHtmlColor(this.InheritedVisitedLinkColor));
      if (this.LinkState == LinkState.Visited)
        objWriter.WriteAttributeString("LS", Convert.ToInt32((object) this.LinkState).ToString());
      if (!this.ClientMode || string.IsNullOrEmpty(this.Url))
        return;
      objWriter.WriteAttributeString("VLB", this.Url);
    }

    /// <summary>Renders the cell style attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objCellStyle">The cell style.</param>
    protected override void RenderCellStyleAttributes(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objCellStyle)
    {
      base.RenderCellStyleAttributes(objWriter, objCellStyle);
      if (objCellStyle == null)
        return;
      objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewLinkCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewLinkCell objDataGridViewCell = !(type == DataGridViewLinkCell.mobjCellType) ? (DataGridViewLinkCell) Activator.CreateInstance(type) : new DataGridViewLinkCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      if (this.mobjLinkActiveColor != Color.Empty)
        objDataGridViewCell.ActiveLinkColorInternal = this.ActiveLinkColor;
      if (this.mintLinkUseColumnTextForLinkValue != 0)
        objDataGridViewCell.UseColumnTextForLinkValueInternal = this.UseColumnTextForLinkValue;
      if (this.menmLinkBehavior != LinkBehavior.SystemDefault)
        objDataGridViewCell.LinkBehaviorInternal = this.LinkBehavior;
      if (this.mobjLinkColor != Color.Empty)
        objDataGridViewCell.LinkColorInternal = this.LinkColor;
      if (this.mintLinkTrackVisitedState != 0)
        objDataGridViewCell.TrackVisitedStateInternal = this.TrackVisitedState;
      if (this.mobjLinkVisitedLinkColor != Color.Empty)
        objDataGridViewCell.VisitedLinkColorInternal = this.VisitedLinkColor;
      if (this.mblnLinkVisitedSet)
        objDataGridViewCell.LinkVisited = this.LinkVisited;
      if (this.Url != string.Empty)
        objDataGridViewCell.Url = this.Url;
      objDataGridViewCell.ClientMode = this.ClientMode;
      return (object) objDataGridViewCell;
    }

    /// <summary>Gets the value of the cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <returns>
    /// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
    protected override object GetValue(int intRowIndex) => this.UseColumnTextForLinkValue && this.DataGridView != null && this.DataGridView.NewRowIndex != intRowIndex && this.OwningColumn != null && this.OwningColumn is DataGridViewLinkColumn ? (object) ((DataGridViewLinkColumn) this.OwningColumn).Text : base.GetValue(intRowIndex);

    private bool LinkBoundsContainPoint(int intX, int intY, int intRowIndex) => false;

    /// <summary>Shoulds the color of the serialize active link.</summary>
    /// <returns></returns>
    private bool ShouldSerializeActiveLinkColor() => !this.ActiveLinkColor.Equals((object) LinkUtilities.IEActiveLinkColor);

    /// <summary>Shoulds the color of the serialize link.</summary>
    /// <returns></returns>
    private bool ShouldSerializeLinkColor() => !this.LinkColor.Equals((object) LinkUtilities.IELinkColor);

    /// <summary>Shoulds the color of the serialize visited link.</summary>
    /// <returns></returns>
    private bool ShouldSerializeVisitedLinkColor() => !this.VisitedLinkColor.Equals((object) LinkUtilities.IEVisitedLinkColor);

    /// <summary>Returns a string that describes the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => "DataGridViewLinkCell { ColumnIndex=" + this.ColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", RowIndex=" + this.RowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + " }";

    /// <summary>Open the Link in the URL in a new window</summary>
    protected void OpenLink()
    {
      if (this.ClientMode || string.IsNullOrEmpty(this.Url))
        return;
      LinkLabel.Link objLink = new LinkLabel.Link(this.Url);
      if (objLink == null)
        return;
      LinkLabel.Link.Open(objLink);
    }

    /// <summary>Gets or sets the color used to display an active link.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state. </returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    public Color ActiveLinkColor
    {
      get
      {
        Color mobjLinkActiveColor = this.mobjLinkActiveColor;
        return this.mobjLinkActiveColor;
      }
      set
      {
        if (value.Equals((object) this.ActiveLinkColor))
          return;
        this.mobjLinkActiveColor = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Sets the active link color internal.</summary>
    /// <value>The active link color internal.</value>
    internal Color ActiveLinkColorInternal
    {
      set
      {
        if (value.Equals((object) this.ActiveLinkColor))
          return;
        this.mobjLinkActiveColor = value;
      }
    }

    /// <summary>Gets or sets the URL.</summary>
    /// <value>The URL.</value>
    public string Url
    {
      get => this.mstrUrl;
      set
      {
        if (!(this.mstrUrl != value))
          return;
        this.mstrUrl = value;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [client mode].
    /// Setting a value to the cell does not change the ClientMode property of the containing column.
    /// </summary>
    /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
    [SRDescription("DataGridView_LinkCellClientModeDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool ClientMode
    {
      get => this.mblnClientMode;
      set
      {
        if (this.mblnClientMode == value)
          return;
        this.mblnClientMode = value;
        this.Update();
      }
    }

    /// <summary>Gets the type of the cell's hosted editing control.</summary>
    /// <returns>Always null. </returns>
    /// <filterpriority>1</filterpriority>
    public override Type EditType => (Type) null;

    /// <summary>Gets the display <see cref="T:System.Type"></see> of the cell value.</summary>
    /// <returns>Always <see cref="T:System.String"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type FormattedValueType => DataGridViewLinkCell.mobjDefaultFormattedValueType;

    /// <summary>Gets or sets a value that represents the behavior of a link.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.LinkBehavior"></see> values. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.LinkBehavior"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(0)]
    public LinkBehavior LinkBehavior
    {
      get => this.menmLinkBehavior;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (LinkBehavior));
        if (value == this.LinkBehavior)
          return;
        this.menmLinkBehavior = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Sets the link behavior internal.</summary>
    /// <value>The link behavior internal.</value>
    internal LinkBehavior LinkBehaviorInternal
    {
      set
      {
        if (value == this.LinkBehavior)
          return;
        this.menmLinkBehavior = value;
      }
    }

    /// <summary>Gets or sets the color used to display an inactive and unvisited link.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    public Color LinkColor
    {
      get
      {
        Color mobjLinkColor = this.mobjLinkColor;
        return this.mobjLinkColor;
      }
      set
      {
        if (value.Equals((object) this.LinkColor))
          return;
        this.mobjLinkColor = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Sets the link color internal.</summary>
    /// <value>The link color internal.</value>
    internal Color LinkColorInternal
    {
      set
      {
        if (value.Equals((object) this.LinkColor))
          return;
        this.mobjLinkColor = value;
      }
    }

    /// <summary>Gets or sets the state of the link.</summary>
    /// <value>The state of the link.</value>
    private LinkState LinkState
    {
      get => this.menmLinkState;
      set
      {
        if (this.LinkState == value)
          return;
        this.menmLinkState = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the link was visited.</summary>
    /// <returns>true if the link has been visited; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool LinkVisited
    {
      get => this.mblnLinkVisitedSet && this.mblnLinkVisited;
      set
      {
        this.mblnLinkVisitedSet = true;
        if (value == this.LinkVisited)
          return;
        this.mblnLinkVisited = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Gets or sets a value indicating whether the link changes color when it is visited.</summary>
    /// <returns>true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(true)]
    public bool TrackVisitedState
    {
      get => this.mintLinkTrackVisitedState != 0;
      set
      {
        if (value == this.TrackVisitedState)
          return;
        this.mintLinkTrackVisitedState = value ? 1 : 0;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>
    /// Sets a value indicating whether [track visited state internal].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [track visited state internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool TrackVisitedStateInternal
    {
      set
      {
        if (value == this.TrackVisitedState)
          return;
        this.mintLinkTrackVisitedState = value ? 1 : 0;
      }
    }

    /// <summary>Gets or sets a value indicating whether the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
    /// <returns>true if the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
    [DefaultValue(false)]
    public bool UseColumnTextForLinkValue
    {
      get => this.mintLinkUseColumnTextForLinkValue != 0;
      set
      {
        if (value == this.UseColumnTextForLinkValue)
          return;
        this.mintLinkUseColumnTextForLinkValue = value ? 1 : 0;
        this.OnCommonChange();
      }
    }

    /// <summary>
    /// Sets a value indicating whether [use column text for link value internal].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [use column text for link value internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool UseColumnTextForLinkValueInternal
    {
      set
      {
        if (value == this.UseColumnTextForLinkValue)
          return;
        this.mintLinkUseColumnTextForLinkValue = value ? 1 : 0;
      }
    }

    /// <summary>Gets or sets the data type of the values in the cell.</summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
    public override Type ValueType
    {
      get
      {
        Type valueType = base.ValueType;
        return valueType != (Type) null ? valueType : DataGridViewLinkCell.mobjDefaultValueType;
      }
    }

    /// <summary>Gets or sets the color used to display a link that has been previously visited.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    public Color VisitedLinkColor
    {
      get
      {
        Color visitedLinkColor = this.mobjLinkVisitedLinkColor;
        return this.mobjLinkVisitedLinkColor;
      }
      set
      {
        if (value.Equals((object) this.VisitedLinkColor))
          return;
        this.mobjLinkVisitedLinkColor = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Sets the visited link color internal.</summary>
    /// <value>The visited link color internal.</value>
    internal Color VisitedLinkColorInternal
    {
      set
      {
        if (value.Equals((object) this.VisitedLinkColor))
          return;
        this.mobjLinkVisitedLinkColor = value;
      }
    }

    /// <summary>Gets the color of the inherited link.</summary>
    /// <value>The color of the inherited link.</value>
    private Color InheritedLinkColor
    {
      get
      {
        Color linkColor = this.LinkColor;
        if (linkColor == LinkUtilities.IELinkColor && this.OwningColumn != null && this.OwningColumn is DataGridViewLinkColumn)
          linkColor = ((DataGridViewLinkColumn) this.OwningColumn).LinkColor;
        return linkColor;
      }
    }

    /// <summary>Gets the color of the inherited active link.</summary>
    /// <value>The color of the inherited active link.</value>
    private Color InheritedActiveLinkColor
    {
      get
      {
        Color activeLinkColor = this.ActiveLinkColor;
        if (activeLinkColor == LinkUtilities.IEActiveLinkColor && this.OwningColumn != null && this.OwningColumn is DataGridViewLinkColumn)
          activeLinkColor = ((DataGridViewLinkColumn) this.OwningColumn).ActiveLinkColor;
        return activeLinkColor;
      }
    }

    /// <summary>Gets the color of the inherited visited link.</summary>
    /// <value>The color of the inherited visited link.</value>
    private Color InheritedVisitedLinkColor
    {
      get
      {
        Color visitedLinkColor = this.VisitedLinkColor;
        if (visitedLinkColor == LinkUtilities.IEVisitedLinkColor && this.OwningColumn != null && this.OwningColumn is DataGridViewLinkColumn)
          visitedLinkColor = ((DataGridViewLinkColumn) this.OwningColumn).VisitedLinkColor;
        return visitedLinkColor;
      }
    }
  }
}
