// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewComboBoxCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays a combo box in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewComboBoxCellSkin))]
  [Serializable]
  public class DataGridViewComboBoxCell : DataGridViewCell
  {
    private byte mobjFlags = 8;
    private static Type mobjDefaultEditType;
    private static Type mobjDefaultFormattedValueType;
    private static Type mobjDefaultValueType;
    private static Type mobjCellType = typeof (DataGridViewComboBoxCell);
    [NonSerialized]
    private PropertyDescriptor mobjValueMember;
    private object mobjInternalValueMember;
    private int mintMaxDropDownItems = 8;
    private DataGridViewComboBoxCell.ObjectCollection mobjItems;
    private FlatStyle menmFlatStyle = FlatStyle.Standard;
    private int mintDropDownWidth = 1;
    private int mintDisplayStyleForCurrentCellOnly = -1;
    private object mobjInternalDisplayMember;
    [NonSerialized]
    private PropertyDescriptor mobjDisplayMember;
    private object mobjDataSource;
    private object mobjDataManager;
    private DataGridViewComboBoxEditingControl menmComboBoxCellEditingComboBox;
    private DataGridViewComboBoxColumn mobjTemplateComboBoxColumn;
    private ComboBoxStyle menmDropDownStyle = ComboBoxStyle.DropDownList;
    private static bool mblnMouseInDropDownButtonBounds = false;
    private static int mintCachedDropDownWidth = -1;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_autoComplete = 8;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_createItemsFromDataSource = 4;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_dataSourceInitializedHookedUp = 16;
    internal const int DATAGRIDVIEWCOMBOBOXCELL_defaultMaxDropDownItems = 8;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_dropDownHookedUp = 32;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_horizontalTextMarginLeft = 0;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_ignoreNextMouseClick = 1;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_margin = 3;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleHeight = 4;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleWidth = 7;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_sorted = 2;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithoutWrapping = 1;
    private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithWrapping = 0;

    /// <summary>
    /// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell" /> class.
    /// </summary>
    static DataGridViewComboBoxCell()
    {
      DataGridViewComboBoxCell.mobjDefaultFormattedValueType = typeof (string);
      DataGridViewComboBoxCell.mobjDefaultEditType = typeof (DataGridViewComboBoxEditingControl);
      DataGridViewComboBoxCell.mobjDefaultValueType = typeof (object);
      DataGridViewComboBoxCell.mobjCellType = typeof (DataGridViewComboBoxCell);
      DataGridViewComboBoxCell.mblnMouseInDropDownButtonBounds = false;
      DataGridViewComboBoxCell.mintCachedDropDownWidth = -1;
    }

    /// <summary>Called when the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
    /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the value of either the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property or the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.ValueMember"></see> property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
    protected override void OnDataGridViewChanged()
    {
      if (this.DataGridView != null)
      {
        this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
        this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
      }
      base.OnDataGridViewChanged();
    }

    /// <summary>Called when the focus moves to a cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
    protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
    {
      if (this.DataGridView == null || !blnThroughMouseClick || this.DataGridView.EditMode == DataGridViewEditMode.EditOnEnter)
        return;
      this.Flags |= (byte) 1;
    }

    /// <summary>Called when [items collection changed].</summary>
    private void OnItemsCollectionChanged()
    {
      if (this.TemplateComboBoxColumn != null)
        this.TemplateComboBoxColumn.OnItemsCollectionChanged();
      DataGridViewComboBoxCell.mintCachedDropDownWidth = -1;
      if (this.OwnsEditingComboBox(this.RowIndex))
        this.InitializeComboBoxText();
      else
        this.OnCommonChange();
    }

    /// <summary>Called when the focus moves from a cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
    protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
    {
      if (this.DataGridView == null)
        return;
      this.Flags &= (byte) 254;
    }

    /// <summary>Determines if edit mode should be started based on the given key.</summary>
    /// <returns>true if edit mode should be started; otherwise, false. </returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
    /// <filterpriority>1</filterpriority>
    public override bool KeyEntersEditMode(KeyEventArgs e) => false;

    /// <summary>
    /// Called when the user clicks a mouse button while the pointer is on a cell.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Called when the mouse pointer moves over a cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    protected override void OnMouseEnter(int intRowIndex)
    {
      if (this.DataGridView == null)
        return;
      if (this.DisplayStyle == DataGridViewComboBoxDisplayStyle.ComboBox && this.FlatStyle == FlatStyle.Popup)
        this.DataGridView.InvalidateCell(this.ColumnIndex, intRowIndex);
      base.OnMouseEnter(intRowIndex);
    }

    /// <summary>Called when the mouse pointer leaves the cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    protected override void OnMouseLeave(int intRowIndex)
    {
    }

    /// <summary>Called when the mouse pointer moves within a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
    protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Ownses the editing combo box.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    private bool OwnsEditingComboBox(int intRowIndex) => false;

    /// <summary>Handles the DropDown event of the ComboBox control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void ComboBox_DropDown(object sender, EventArgs e)
    {
    }

    /// <summary>Handles the Disposed event of the DataSource control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DataSource_Disposed(object sender, EventArgs e) => this.DataSource = (object) null;

    /// <summary>
    /// Handles the Initialized event of the DataSource control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DataSource_Initialized(object sender, EventArgs e)
    {
      if (this.DataSource is ISupportInitializeNotification dataSource)
        dataSource.Initialized -= new EventHandler(this.DataSource_Initialized);
      this.Flags &= (byte) 239;
      this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
      this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
    }

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "ValueChange":
          if (!objEvent.Contains("VLB"))
            break;
          int int32 = Convert.ToInt32(objEvent["VLB"]);
          if (int32 < 0 || int32 >= this.Items.Count)
            break;
          this.SetValue((object) this.GetItemDisplayText(this.Items[int32]), true);
          break;
        case "TextChange":
          if (!objEvent.Contains("VLB"))
            break;
          string objValue = CommonUtils.DecodeText(objEvent["VLB"]);
          if (string.IsNullOrEmpty(objValue))
            break;
          this.SetValue((object) objValue, true);
          break;
        case "DropDownWindow":
          Form customDropDown = this.GetCustomDropDown();
          if (customDropDown == null)
            break;
          int num = (int) customDropDown.ShowPopup((Component) this.DataGridView, (IIdentifiedComponent) this, DialogAlignment.Below);
          break;
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => base.GetKeyEventCaptures() | KeyCaptures.UpKeyCapture | KeyCaptures.DownKeyCapture | KeyCaptures.LeftKeyCapture | KeyCaptures.RightKeyCapture | KeyCaptures.EndKeyCapture | KeyCaptures.HomeKeyCapture | KeyCaptures.PageDownKeyCapture | KeyCaptures.PageUpKeyCapture | KeyCaptures.EnterKeyCapture;

    /// <summary>Renders the animation.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderAnimationAttributes(IAttributeWriter objWriter)
    {
      if (this.DataGridView == null || !this.DataGridView.DefaultAnimationEnabled)
        return;
      objWriter.WriteAttributeString("AN", "1");
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
      object objValue = this.Value;
      if (objValue == null || !(objValue.ToString() != string.Empty))
        return;
      object comboBoxItem = this.GetComboBoxItem(objValue);
      if (comboBoxItem == null)
        return;
      int num = this.Items.IndexOf(comboBoxItem);
      objWriter.WriteAttributeString("VLB", num.ToString());
      objWriter.WriteAttributeString("FT", objFormatedValue.ToString());
    }

    /// <summary>Render the control Attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      objWriter.WriteAttributeString("CSD", "1");
      objWriter.WriteAttributeString("SKA", "0");
      objWriter.WriteAttributeString("MAX", Math.Min(this.MaxDropDownItems, this.Items.Count).ToString());
      int num;
      if (this.DropDownWidth != 1)
      {
        IAttributeWriter attributeWriter = objWriter;
        num = this.DropDownWidth;
        string strValue = num.ToString();
        attributeWriter.WriteAttributeString("DDW", strValue);
      }
      objWriter.WriteAttributeString("ACM", this.AutoComplete ? "S" : "N");
      objWriter.WriteAttributeString("IAC", this.AutoComplete ? "1" : "0");
      if (this.IsCustomDropDown)
      {
        objWriter.WriteAttributeString("CDD", "1");
        this.RenderCustomComboboxTextValue(objWriter);
      }
      switch (this.DropDownStyle)
      {
        case ComboBoxStyle.Simple:
          objWriter.WriteAttributeString("S", "S");
          break;
        case ComboBoxStyle.DropDown:
          objWriter.WriteAttributeString("S", "DD");
          break;
        case ComboBoxStyle.DropDownList:
          objWriter.WriteAttributeString("S", "DDL");
          break;
      }
      objWriter.WriteAttributeString("Id", string.Format("{0}_{1}", (object) this.DataGridView.GetProxyPropertyValue<long>("ID", this.DataGridView.ID).ToString(), (object) this.MemberID));
      if (!this.SholudRenderComboboxItems && this.OwningColumnHasItems)
        objWriter.WriteAttributeString("OC", string.Format("{0}_{1}", (object) this.DataGridView.GetProxyPropertyValue<long>("ID", this.DataGridView.ID).ToString(), (object) this.DataGridView.Columns[this.ColumnIndex].MemberIDInternal));
      IAttributeWriter attributeWriter1 = objWriter;
      num = this.GetPreferdItemHeight();
      string strValue1 = num.ToString();
      attributeWriter1.WriteAttributeString("IMH", strValue1);
      this.RenderAnimationAttributes(objWriter);
    }

    /// <summary>Renders the custom combobox text value.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderCustomComboboxTextValue(IAttributeWriter objWriter)
    {
      if (this.Value == null)
        return;
      objWriter.WriteAttributeText("TX", this.Value.ToString());
    }

    /// <summary>Gets the text from value.</summary>
    /// <param name="objValue">The obj value.</param>
    /// <returns></returns>
    protected virtual string GetRenderedTextFromValue(object objValue) => this.Value.ToString();

    /// <summary>Renders the combobox items.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    public void RenderComboboxItems(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      if (!this.IsDirty(lngRequestID) || !this.SholudRenderComboboxItems)
        return;
      DataGridViewComboBoxCell.ObjectCollection items = this.Items;
      if (items == null && this.TemplateComboBoxColumn != null)
        items = this.GetItems(this.TemplateComboBoxColumn.DataGridView);
      objWriter.WriteStartElement("OS");
      objWriter.WriteAttributeString("IDD", "0");
      for (int index = 0; index < items.Count; ++index)
      {
        objWriter.WriteStartElement("O");
        objWriter.WriteAttributeString("IX", index.ToString());
        string itemDisplayText = this.GetItemDisplayText(items[index]);
        objWriter.WriteAttributeText("TX", itemDisplayText, TextFilter.NewLine | TextFilter.CarriageReturn);
        objWriter.WriteEndElement();
      }
      objWriter.WriteEndElement();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
      this.RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Gets the custom form to display as drop down</summary>
    /// <returns></returns>
    protected virtual Form GetCustomDropDown() => (Form) null;

    /// <summary>Checks the drop down list.</summary>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    private void CheckDropDownList(int intX, int intY, int intRowIndex)
    {
    }

    /// <summary>Checks the no data source.</summary>
    private void CheckNoDataSource()
    {
      if (this.DataSource != null)
        throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
    }

    /// <summary>Gets the height of the preferd item font.</summary>
    /// <returns></returns>
    internal int GetPreferdItemHeight()
    {
      if (!(this.Skin is ComboBoxSkin skin))
        return 0;
      PaddingValue padding = skin.PopupItemStyle.Padding;
      int num = 0;
      if (padding != null)
        num = padding.Top + padding.Bottom;
      Font objFont = skin.Font;
      if (this.FormattedCellStyle != null)
      {
        Font font = this.FormattedCellStyle.Font;
        if (font != null)
          objFont = font;
      }
      return CommonUtils.GetFontHeight(objFont) + num;
    }

    /// <summary>
    /// Determines whether [is collections equals] [the specified obj collection1].
    /// </summary>
    /// <param name="objCollection1">The obj collection1.</param>
    /// <param name="objCollection2">The obj collection2.</param>
    /// <returns>
    /// 	<c>true</c> if [is collections equals] [the specified obj collection1]; otherwise, <c>false</c>.
    /// </returns>
    protected bool CollectionsEquals(
      DataGridViewComboBoxCell.ObjectCollection objCollection1,
      DataGridViewComboBoxCell.ObjectCollection objCollection2)
    {
      bool flag = objCollection1 == null && objCollection2 == null || objCollection1 != null && objCollection2 != null;
      if (flag && objCollection1 != null)
      {
        flag = objCollection1.Count == objCollection2.Count;
        if (flag)
        {
          foreach (object objValue in objCollection1)
          {
            if (!objCollection2.Contains(objValue))
            {
              flag = false;
              break;
            }
          }
        }
      }
      return flag;
    }

    /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
    /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell.</param>
    protected override Size GetPreferredSize(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex,
      Size objConstraintSize)
    {
      string strText = Convert.ToString(this.GetValue(intRowIndex));
      try
      {
        if (this.Value != null)
          strText = this.GetFormattedValue(this.Value, this.RowIndex, ref objCellStyle, (TypeConverter) null, (TypeConverter) null, (DataGridViewDataErrorContexts) 0).ToString();
      }
      catch (Exception ex)
      {
      }
      if (string.IsNullOrEmpty(strText))
        strText = " ";
      Size preferredSize = this.GetPreferredSize(strText, objCellStyle);
      return new Size(Math.Max(preferredSize.Width, 16), preferredSize.Height);
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewComboBoxCell objDataGridViewCell = !(type == DataGridViewComboBoxCell.mobjCellType) ? (DataGridViewComboBoxCell) Activator.CreateInstance(type) : new DataGridViewComboBoxCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.DropDownWidth = this.DropDownWidth;
      objDataGridViewCell.DropDownStyle = this.DropDownStyle;
      objDataGridViewCell.MaxDropDownItems = this.MaxDropDownItems;
      objDataGridViewCell.CreateItemsFromDataSource = false;
      objDataGridViewCell.DataSource = this.DataSource;
      objDataGridViewCell.DisplayMember = this.DisplayMember;
      objDataGridViewCell.ValueMember = this.ValueMember;
      if (this.HasItems && this.DataSource == null && this.Items.Count > 0)
        objDataGridViewCell.Items.AddRangeInternal((ICollection) this.Items.InnerArray.ToArray());
      objDataGridViewCell.AutoComplete = this.AutoComplete;
      objDataGridViewCell.Sorted = this.Sorted;
      objDataGridViewCell.FlatStyleInternal = this.FlatStyle;
      objDataGridViewCell.DisplayStyleInternal = this.DisplayStyle;
      objDataGridViewCell.DisplayStyleForCurrentCellOnlyInternal = this.DisplayStyleForCurrentCellOnly;
      return (object) objDataGridViewCell;
    }

    /// <summary>
    /// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
    /// </summary>
    /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
    public override void DetachEditingControl()
    {
    }

    private CurrencyManager GetDataManager(DataGridView objDataGridView)
    {
      CurrencyManager mobjDataManager = (CurrencyManager) this.mobjDataManager;
      if (mobjDataManager == null && this.DataSource != null && objDataGridView != null && objDataGridView.BindingContext != null && this.DataSource != Convert.DBNull)
      {
        if (this.DataSource is ISupportInitializeNotification dataSource && !dataSource.IsInitialized)
        {
          if (((int) this.Flags & 16) == 0)
          {
            dataSource.Initialized += new EventHandler(this.DataSource_Initialized);
            this.Flags |= (byte) 16;
          }
          return mobjDataManager;
        }
        mobjDataManager = (CurrencyManager) objDataGridView.BindingContext[this.DataSource];
        this.DataManager = mobjDataManager;
      }
      return mobjDataManager;
    }

    /// <summary>Gets the height of the drop down button.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <returns></returns>
    private int GetDropDownButtonHeight(Graphics objGraphics, DataGridViewCellStyle objCellStyle) => -1;

    /// <summary>Gets the formatted value of the cell's data.</summary>
    /// <param name="objValue">The value to be formatted.</param>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
    /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
    /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
    /// <returns>
    /// The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
    /// </returns>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see> for type conversion errors or to type <see cref="T:System.ArgumentException"></see> if value cannot be found in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.Items"></see> collection. </exception>
    protected override object GetFormattedValue(
      object objValue,
      int intRowIndex,
      ref DataGridViewCellStyle objCellStyle,
      TypeConverter objValueTypeConverter,
      TypeConverter objFormattedValueTypeConverter,
      DataGridViewDataErrorContexts enmContext)
    {
      if (objValueTypeConverter == null)
      {
        if (this.ValueMemberProperty != null)
          objValueTypeConverter = this.ValueMemberProperty.Converter;
        else if (this.DisplayMemberProperty != null)
          objValueTypeConverter = this.DisplayMemberProperty.Converter;
      }
      if (objValue == null || this.ValueType != (Type) null && !this.ValueType.IsAssignableFrom(objValue.GetType()) && objValue != DBNull.Value)
      {
        if (objValue == null)
          return base.GetFormattedValue((object) null, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
        if (this.DataGridView != null)
        {
          DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs((Exception) new FormatException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), this.ColumnIndex, intRowIndex, enmContext);
          this.RaiseDataError(e);
          if (e.ThrowException)
            throw e.Exception;
        }
        return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
      }
      string str = objValue as string;
      if (this.DataManager != null && (this.ValueMemberProperty != null || this.DisplayMemberProperty != null) || !string.IsNullOrEmpty(this.ValueMember) || !string.IsNullOrEmpty(this.DisplayMember))
      {
        object objDisplayValue;
        if (!this.LookupDisplayValue(intRowIndex, objValue, out objDisplayValue))
        {
          if (objValue == DBNull.Value)
            objDisplayValue = (object) DBNull.Value;
          else if (str != null && string.IsNullOrEmpty(str) && this.DisplayType == typeof (string))
            objDisplayValue = (object) string.Empty;
          else if (this.DataGridView != null)
          {
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs((Exception) new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), this.ColumnIndex, intRowIndex, enmContext);
            this.RaiseDataError(e);
            if (e.ThrowException)
              throw e.Exception;
            if (this.OwnsEditingComboBox(intRowIndex))
              this.DataGridView.NotifyCurrentCellDirty(true);
          }
        }
        return base.GetFormattedValue(objDisplayValue, intRowIndex, ref objCellStyle, this.DisplayTypeConverter, objFormattedValueTypeConverter, enmContext);
      }
      if (!this.Items.Contains(objValue) && objValue != DBNull.Value && (!(objValue is string) || !string.IsNullOrEmpty(str)) && !this.IsCustomDropDown)
      {
        if (this.DataGridView != null)
        {
          DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs((Exception) new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), this.ColumnIndex, intRowIndex, enmContext);
          this.RaiseDataError(e);
          if (e.ThrowException)
            throw e.Exception;
        }
        objValue = this.Items.Count <= 0 ? (object) string.Empty : this.Items[0];
      }
      return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
    }

    /// <summary>Lookups the display value.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objValue">The value.</param>
    /// <param name="objDisplayValue">The display value.</param>
    /// <returns></returns>
    private bool LookupDisplayValue(int intRowIndex, object objValue, out object objDisplayValue)
    {
      object objItem = this.DisplayMemberProperty != null || this.ValueMemberProperty != null ? this.ItemFromComboBoxDataSource(this.ValueMemberProperty != null ? this.ValueMemberProperty : this.DisplayMemberProperty, objValue) : this.ItemFromComboBoxItems(intRowIndex, string.IsNullOrEmpty(this.ValueMember) ? this.DisplayMember : this.ValueMember, objValue);
      if (objItem == null)
      {
        objDisplayValue = (object) null;
        return false;
      }
      objDisplayValue = this.GetItemDisplayValue(objItem);
      return true;
    }

    /// <summary>Gets the item display text.</summary>
    /// <param name="objItem">The item.</param>
    /// <returns></returns>
    internal string GetItemDisplayText(object objItem)
    {
      object itemDisplayValue = this.GetItemDisplayValue(objItem);
      return itemDisplayValue == null ? string.Empty : Convert.ToString(itemDisplayValue, (IFormatProvider) CultureInfo.CurrentCulture);
    }

    /// <summary>Gets the item display value.</summary>
    /// <param name="objItem">The item.</param>
    /// <returns></returns>
    internal object GetItemDisplayValue(object objItem)
    {
      bool flag = false;
      object itemDisplayValue = (object) null;
      if (this.DisplayMemberProperty != null)
      {
        itemDisplayValue = this.DisplayMemberProperty.GetValue(objItem);
        flag = true;
      }
      else if (this.ValueMemberProperty != null)
      {
        itemDisplayValue = this.ValueMemberProperty.GetValue(objItem);
        flag = true;
      }
      else if (!CommonUtils.IsNullOrEmpty(this.DisplayMember))
      {
        PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.DisplayMember, true);
        if (propertyDescriptor != null)
        {
          itemDisplayValue = propertyDescriptor.GetValue(objItem);
          flag = true;
        }
      }
      else if (!CommonUtils.IsNullOrEmpty(this.ValueMember))
      {
        PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.ValueMember, true);
        if (propertyDescriptor != null)
        {
          itemDisplayValue = propertyDescriptor.GetValue(objItem);
          flag = true;
        }
      }
      if (!flag)
        itemDisplayValue = objItem;
      return itemDisplayValue;
    }

    /// <summary>Gets the items.</summary>
    /// <param name="objDataGridView">The data grid view.</param>
    /// <returns></returns>
    internal DataGridViewComboBoxCell.ObjectCollection GetItems(DataGridView objDataGridView)
    {
      DataGridViewComboBoxCell.ObjectCollection items = this.LocalItems;
      if (items == null)
      {
        items = this.CreateObjectCollection();
        this.LocalItems = items;
      }
      if (this.CreateItemsFromDataSource)
      {
        items.ClearInternal();
        CurrencyManager dataManager = this.GetDataManager(objDataGridView);
        if (dataManager != null && dataManager.Count != -1)
        {
          object[] objItems = new object[dataManager.Count];
          for (int index = 0; index < objItems.Length; ++index)
            objItems[index] = dataManager[index];
          items.AddRangeInternal((ICollection) objItems);
        }
        if (dataManager == null && ((int) this.Flags & 16) != 0)
          return items;
        this.CreateItemsFromDataSource = false;
      }
      return items;
    }

    /// <summary>Creates the object collection.</summary>
    /// <returns></returns>
    protected virtual DataGridViewComboBoxCell.ObjectCollection CreateObjectCollection() => new DataGridViewComboBoxCell.ObjectCollection(this);

    /// <summary>Gets the combo box item.</summary>
    /// <param name="objValue">The obj value.</param>
    /// <returns></returns>
    private object GetComboBoxItem(object objValue)
    {
      object comboBoxItem = (object) null;
      if (this.ValueMemberProperty != null)
        comboBoxItem = this.ItemFromComboBoxDataSource(this.ValueMemberProperty, objValue);
      else if (this.DisplayMemberProperty != null)
      {
        comboBoxItem = this.ItemFromComboBoxDataSource(this.DisplayMemberProperty, objValue);
      }
      else
      {
        if (!string.IsNullOrEmpty(this.ValueMember))
          comboBoxItem = this.ItemFromComboBoxItems(this.RowIndex, this.ValueMember, objValue);
        if (comboBoxItem == null)
          comboBoxItem = this.ItemFromComboBoxItems(this.RowIndex, this.DisplayMember, objValue);
      }
      return comboBoxItem;
    }

    /// <summary>Gets the item value.</summary>
    /// <param name="objItem">The item.</param>
    /// <returns></returns>
    internal object GetItemValue(object objItem)
    {
      bool flag = false;
      object itemValue = (object) null;
      if (this.ValueMemberProperty != null)
      {
        itemValue = this.ValueMemberProperty.GetValue(objItem);
        flag = true;
      }
      else if (this.DisplayMemberProperty != null)
      {
        itemValue = this.DisplayMemberProperty.GetValue(objItem);
        flag = true;
      }
      else if (!CommonUtils.IsNullOrEmpty(this.ValueMember))
      {
        PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.ValueMember, true);
        if (propertyDescriptor != null)
        {
          itemValue = propertyDescriptor.GetValue(objItem);
          flag = true;
        }
      }
      if (!flag)
      {
        if (!CommonUtils.IsNullOrEmpty(this.DisplayMember))
        {
          PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.DisplayMember, true);
          if (propertyDescriptor != null)
          {
            itemValue = propertyDescriptor.GetValue(objItem);
            flag = true;
          }
        }
      }
      if (!flag)
        itemValue = objItem;
      return itemValue;
    }

    /// <summary>Initializes the combo box text.</summary>
    private void InitializeComboBoxText()
    {
    }

    /// <summary>Initializes the display member property descriptor.</summary>
    /// <param name="strDisplayMember">The display member.</param>
    private void InitializeDisplayMemberPropertyDescriptor(string strDisplayMember)
    {
      if (this.DataManager == null)
        return;
      if (CommonUtils.IsNullOrEmpty(strDisplayMember))
      {
        this.DisplayMemberProperty = (PropertyDescriptor) null;
      }
      else
      {
        if (this.DataGridView == null)
          return;
        BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(strDisplayMember);
        this.DataManager = this.DataGridView.BindingContext[this.DataSource, bindingMemberInfo.BindingPath] as CurrencyManager;
        this.DisplayMemberProperty = this.DataManager.GetItemProperties().Find(bindingMemberInfo.BindingField, true) ?? throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", (object) strDisplayMember));
      }
    }

    /// <summary>Attaches and initializes the hosted editing control.</summary>
    /// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that determines the appearance of the hosted control.</param>
    /// <filterpriority>1</filterpriority>
    public override void InitializeEditingControl(
      int intRowIndex,
      object objInitialFormattedValue,
      DataGridViewCellStyle objDataGridViewCellStyle)
    {
    }

    /// <summary>Initializes the value member property descriptor.</summary>
    /// <param name="strValueMember">The value member.</param>
    private void InitializeValueMemberPropertyDescriptor(string strValueMember)
    {
      if (this.DataManager == null)
        return;
      if (CommonUtils.IsNullOrEmpty(strValueMember))
      {
        this.ValueMemberProperty = (PropertyDescriptor) null;
      }
      else
      {
        if (this.DataGridView == null)
          return;
        BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(strValueMember);
        this.DataManager = this.DataGridView.BindingContext[this.DataSource, bindingMemberInfo.BindingPath] as CurrencyManager;
        this.ValueMemberProperty = this.DataManager.GetItemProperties().Find(bindingMemberInfo.BindingField, true) ?? throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", (object) strValueMember));
      }
    }

    /// <summary>Items from combo box data source.</summary>
    /// <param name="objPropertyDescriptor">The property.</param>
    /// <param name="objKey">The key.</param>
    /// <returns></returns>
    private object ItemFromComboBoxDataSource(
      PropertyDescriptor objPropertyDescriptor,
      object objKey)
    {
      if (objKey == null)
        throw new ArgumentNullException("key");
      object obj1 = (object) null;
      if (this.DataManager.List is IBindingList && ((IBindingList) this.DataManager.List).SupportsSearching)
      {
        int index = ((IBindingList) this.DataManager.List).Find(objPropertyDescriptor, objKey);
        if (index != -1)
          obj1 = this.DataManager.List[index];
        return obj1;
      }
      for (int index = 0; index < this.DataManager.List.Count; ++index)
      {
        object component = this.DataManager.List[index];
        object obj2 = objPropertyDescriptor.GetValue(component);
        if (objKey.Equals(obj2))
          return component;
      }
      return obj1;
    }

    /// <summary>Items from combo box items.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="strField">The field.</param>
    /// <param name="objKey">The key.</param>
    /// <returns></returns>
    private object ItemFromComboBoxItems(int intRowIndex, string strField, object objKey)
    {
      object component1 = (object) null;
      if (this.OwnsEditingComboBox(intRowIndex))
      {
        component1 = this.EditingComboBox.SelectedItem;
        object obj = (object) null;
        PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(component1).Find(strField, true);
        if (propertyDescriptor != null)
          obj = propertyDescriptor.GetValue(component1);
        if (obj == null || !obj.Equals(objKey))
          component1 = (object) null;
      }
      if (component1 == null)
      {
        foreach (object component2 in this.Items)
        {
          object obj = (object) null;
          PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(component2).Find(strField, true);
          if (propertyDescriptor != null)
            obj = propertyDescriptor.GetValue(component2);
          if (obj != null && obj.Equals(objKey))
          {
            component1 = component2;
            break;
          }
        }
      }
      if (component1 == null)
      {
        if (this.OwnsEditingComboBox(intRowIndex))
        {
          component1 = this.EditingComboBox.SelectedItem;
          if (component1 == null || !component1.Equals(objKey))
            component1 = (object) null;
        }
        if (component1 == null && this.Items.Contains(objKey))
          component1 = objKey;
      }
      return component1;
    }

    /// <summary>Lookups the value.</summary>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="objValue">The value.</param>
    /// <returns></returns>
    private bool LookupValue(object objFormattedValue, out object objValue)
    {
      if (objFormattedValue == null)
      {
        objValue = (object) null;
        return true;
      }
      object objItem = this.DisplayMemberProperty != null || this.ValueMemberProperty != null ? this.ItemFromComboBoxDataSource(this.DisplayMemberProperty != null ? this.DisplayMemberProperty : this.ValueMemberProperty, objFormattedValue) : this.ItemFromComboBoxItems(this.RowIndex, string.IsNullOrEmpty(this.DisplayMember) ? this.ValueMember : this.DisplayMember, objFormattedValue);
      if (objItem == null)
      {
        objValue = (object) null;
        return false;
      }
      objValue = this.GetItemValue(objItem);
      return true;
    }

    /// <summary>
    /// Converts a value formatted for display to an actual cell value.
    /// </summary>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
    /// <param name="objValueTypeConverter">The value type converter.</param>
    /// <returns></returns>
    public override object ParseFormattedValue(
      object objFormattedValue,
      DataGridViewCellStyle objCellStyle,
      TypeConverter objFormattedValueTypeConverter,
      TypeConverter objValueTypeConverter)
    {
      if (objValueTypeConverter == null)
      {
        if (this.ValueMemberProperty != null)
          objValueTypeConverter = this.ValueMemberProperty.Converter;
        else if (this.DisplayMemberProperty != null)
          objValueTypeConverter = this.DisplayMemberProperty.Converter;
      }
      if (this.DataManager == null || this.DisplayMemberProperty == null && this.ValueMemberProperty == null)
      {
        if (CommonUtils.IsNullOrEmpty(this.DisplayMember))
        {
          if (CommonUtils.IsNullOrEmpty(this.ValueMember))
            return this.ParseFormattedValueInternal(this.ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
        }
      }
      object objValue = this.ParseFormattedValueInternal(this.DisplayType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, this.DisplayTypeConverter);
      object objFormattedValue1 = objValue;
      if (this.LookupValue(objFormattedValue1, out objValue))
        return objValue;
      return objFormattedValue1 == DBNull.Value ? (object) DBNull.Value : throw new FormatException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, SR.GetString("Formatter_CantConvert"), objValue, (object) this.DisplayType));
    }

    /// <summary>Returns a string that describes the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => "DataGridViewComboBoxCell { ColumnIndex=" + this.ColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", RowIndex=" + this.RowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + " }";

    /// <summary>Unwires the data source.</summary>
    private void UnwireDataSource()
    {
      if (this.DataSource is IComponent dataSource1)
        dataSource1.Disposed -= new EventHandler(this.DataSource_Disposed);
      if (!(this.DataSource is ISupportInitializeNotification dataSource2) || ((int) this.Flags & 16) == 0)
        return;
      dataSource2.Initialized -= new EventHandler(this.DataSource_Initialized);
      this.Flags &= (byte) 239;
    }

    /// <summary>Wires the data source.</summary>
    /// <param name="objDataSource">The data source.</param>
    private void WireDataSource(object objDataSource)
    {
      if (!(objDataSource is IComponent component))
        return;
      component.Disposed += new EventHandler(this.DataSource_Disposed);
    }

    /// <summary>Gets or sets the drop down style.</summary>
    /// <value></value>
    [DefaultValue(ComboBoxStyle.DropDownList)]
    public virtual ComboBoxStyle DropDownStyle
    {
      get
      {
        ComboBoxStyle dropDownStyle = this.menmDropDownStyle;
        if (dropDownStyle == ComboBoxStyle.DropDownList && this.DataGridView != null && this.ColumnIndex < this.DataGridView.Columns.Count && this.ColumnIndex >= 0 && this.DataGridView.Columns[this.ColumnIndex].CellTemplate != null)
          dropDownStyle = ((DataGridViewComboBoxCell) this.DataGridView.Columns[this.ColumnIndex].CellTemplate).DropDownStyle;
        return dropDownStyle;
      }
      set
      {
        if (this.menmDropDownStyle == value)
          return;
        this.menmDropDownStyle = value;
        this.Update();
      }
    }

    /// <summary>Gets a value indicating whether [support edit mode].</summary>
    /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
    protected override bool SupportEditMode => true;

    /// <summary>Gets or sets the editing combo box.</summary>
    /// <value>The editing combo box.</value>
    private DataGridViewComboBoxEditingControl EditingComboBox
    {
      get => this.menmComboBoxCellEditingComboBox;
      set
      {
        if (value == null && this.menmComboBoxCellEditingComboBox == null)
          return;
        this.menmComboBoxCellEditingComboBox = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell will match the characters being entered in the cell with a selection from the drop-down list. </summary>
    /// <returns>true if automatic completion is activated; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(true)]
    public virtual bool AutoComplete
    {
      get => ((uint) this.Flags & 8U) > 0U;
      set
      {
        if (value == this.AutoComplete)
          return;
        if (value)
          this.Flags |= (byte) 8;
        else
          this.Flags &= (byte) 247;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [create items from data source].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [create items from data source]; otherwise, <c>false</c>.
    /// </value>
    private bool CreateItemsFromDataSource
    {
      get => ((uint) this.Flags & 4U) > 0U;
      set
      {
        if (value)
          this.Flags |= (byte) 4;
        else
          this.Flags &= (byte) 251;
      }
    }

    /// <summary>Gets or sets the data manager.</summary>
    /// <value>The data manager.</value>
    private CurrencyManager DataManager
    {
      get => this.GetDataManager(this.DataGridView);
      set
      {
        if (value == null && this.mobjDataManager == null)
          return;
        this.mobjDataManager = (object) value;
      }
    }

    /// <summary>Gets or sets the data source whose data contains the possible selections shown in the drop-down list.</summary>
    /// <returns>An <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> that contains a collection of values used to supply data to the drop-down list. The default value is null.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not null and is not of type <see cref="T:System.Collections.IList"></see> nor <see cref="T:System.ComponentModel.IListSource"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual object DataSource
    {
      get => this.mobjDataSource;
      set
      {
        switch (value)
        {
          case null:
          case IList _:
          case IListSource _:
            if (this.DataSource == value)
              break;
            this.DataManager = (CurrencyManager) null;
            this.UnwireDataSource();
            this.mobjDataSource = value;
            this.WireDataSource(value);
            this.CreateItemsFromDataSource = true;
            DataGridViewComboBoxCell.mintCachedDropDownWidth = -1;
            try
            {
              this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
            }
            catch (Exception ex)
            {
              if (ClientUtils.IsCriticalException(ex))
                throw;
              else
                this.DisplayMemberInternal = (string) null;
            }
            try
            {
              this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
            }
            catch (Exception ex)
            {
              if (ClientUtils.IsCriticalException(ex))
                throw;
              else
                this.ValueMemberInternal = (string) null;
            }
            if (value == null)
            {
              this.DisplayMemberInternal = (string) null;
              this.ValueMemberInternal = (string) null;
            }
            if (this.OwnsEditingComboBox(this.RowIndex))
            {
              this.InitializeComboBoxText();
              break;
            }
            this.OnCommonChange();
            break;
          default:
            throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
        }
      }
    }

    /// <summary>Gets or sets a string that specifies where to gather selections to display in the drop-down list.</summary>
    /// <returns>A string specifying the name of a property or column in the data source specified in the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property. The default value is <see cref="F:System.String.Empty"></see>, which indicates that the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property will not be used.</returns>
    /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue("")]
    public virtual string DisplayMember
    {
      get => this.mobjInternalDisplayMember == null ? string.Empty : (string) this.mobjInternalDisplayMember;
      set
      {
        this.DisplayMemberInternal = value;
        if (this.OwnsEditingComboBox(this.RowIndex))
          this.InitializeComboBoxText();
        else
          this.OnCommonChange();
      }
    }

    /// <summary>Gets or sets the flags.</summary>
    /// <value>The flags.</value>
    private byte Flags
    {
      get => this.mobjFlags;
      set => this.mobjFlags = value;
    }

    /// <summary>Sets the display member internal.</summary>
    /// <value>The display member internal.</value>
    private string DisplayMemberInternal
    {
      set
      {
        this.InitializeDisplayMemberPropertyDescriptor(value);
        if ((value == null || value.Length <= 0) && this.mobjInternalDisplayMember == null)
          return;
        this.mobjInternalDisplayMember = (object) value;
      }
    }

    /// <summary>Gets or sets the display member property.</summary>
    /// <value>The display member property.</value>
    private PropertyDescriptor DisplayMemberProperty
    {
      get
      {
        if (this.mobjDisplayMember == null)
          this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
        return this.mobjDisplayMember;
      }
      set
      {
        if (value == null && this.mobjDisplayMember == null)
          return;
        this.mobjDisplayMember = value;
      }
    }

    /// <summary>Gets or sets a value that determines how the combo box is displayed when it is not in edit mode.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> values. The default is <see cref="F:System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> value.</exception>
    [DefaultValue(1)]
    public DataGridViewComboBoxDisplayStyle DisplayStyle
    {
      get => this.mintDisplayStyleForCurrentCellOnly >= 0 ? (DataGridViewComboBoxDisplayStyle) this.mintDisplayStyleForCurrentCellOnly : DataGridViewComboBoxDisplayStyle.DropDownButton;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewComboBoxDisplayStyle));
        if (value == this.DisplayStyle)
          return;
        this.mintDisplayStyleForCurrentCellOnly = (int) value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>Gets or sets a value that determines if the display style only applies to the current cell.</summary>
    /// <returns>true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
    [DefaultValue(false)]
    public bool DisplayStyleForCurrentCellOnly
    {
      get => this.mintDisplayStyleForCurrentCellOnly != 0;
      set
      {
        if (value == this.DisplayStyleForCurrentCellOnly)
          return;
        this.mintDisplayStyleForCurrentCellOnly = value ? 1 : 0;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    /// <summary>
    /// Sets a value indicating whether [display style for current cell only internal].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [display style for current cell only internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool DisplayStyleForCurrentCellOnlyInternal
    {
      set
      {
        if (value == this.DisplayStyleForCurrentCellOnly)
          return;
        this.mintDisplayStyleForCurrentCellOnly = value ? 1 : 0;
      }
    }

    /// <summary>Sets the display style internal.</summary>
    /// <value>The display style internal.</value>
    internal DataGridViewComboBoxDisplayStyle DisplayStyleInternal
    {
      set
      {
        if (value == this.DisplayStyle)
          return;
        this.mintDisplayStyleForCurrentCellOnly = (int) value;
      }
    }

    /// <summary>Gets the display type.</summary>
    /// <value>The display type.</value>
    private Type DisplayType
    {
      get
      {
        if (this.DisplayMemberProperty != null)
          return this.DisplayMemberProperty.PropertyType;
        return this.ValueMemberProperty != null ? this.ValueMemberProperty.PropertyType : DataGridViewComboBoxCell.mobjDefaultFormattedValueType;
      }
    }

    /// <summary>Gets the display type converter.</summary>
    /// <value>The display type converter.</value>
    private TypeConverter DisplayTypeConverter => this.DataGridView != null ? this.DataGridView.GetCachedTypeConverter(this.DisplayType) : TypeDescriptor.GetConverter(this.DisplayType);

    /// <summary>Gets or sets the width of the of the drop-down list portion of a combo box.</summary>
    /// <returns>The width, in pixels, of the drop-down list. The default is 1.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than one.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(1)]
    public virtual int DropDownWidth
    {
      get => this.mintDropDownWidth;
      set
      {
        if (value < 1)
        {
          object[] objArray = new object[1]
          {
            (object) 1.ToString((IFormatProvider) CultureInfo.CurrentCulture)
          };
          throw new ArgumentOutOfRangeException(nameof (DropDownWidth), (object) value, SR.GetString("DataGridViewComboBoxCell_DropDownWidthOutOfRange", objArray));
        }
        this.mintDropDownWidth = value;
      }
    }

    /// <summary>Gets the type of the cell's hosted editing control.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control. This property always returns <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type EditType => DataGridViewComboBoxCell.mobjDefaultEditType;

    /// <summary>Gets or sets the flat style appearance of the cell.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.FlatStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.FlatStyle.Standard"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not a valid <see cref="T:System.Windows.Forms.FlatStyle"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(2)]
    public FlatStyle FlatStyle
    {
      get => this.menmFlatStyle;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (FlatStyle));
        if (value == this.FlatStyle)
          return;
        this.menmFlatStyle = value;
        this.OnCommonChange();
      }
    }

    /// <summary>Sets the flat style internal.</summary>
    /// <value>The flat style internal.</value>
    internal FlatStyle FlatStyleInternal
    {
      set
      {
        if (value == this.FlatStyle)
          return;
        this.menmFlatStyle = value;
      }
    }

    /// <summary>Gets the class type of the formatted value associated with the cell.</summary>
    /// <returns>The type of the cell's formatted value. This property always returns <see cref="T:System.String"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type FormattedValueType => DataGridViewComboBoxCell.mobjDefaultFormattedValueType;

    /// <summary>
    /// Gets a value indicating whether this instance has items.
    /// </summary>
    /// <value><c>true</c> if this instance has items; otherwise, <c>false</c>.</value>
    internal bool HasItems => this.LocalItems != null;

    /// <summary>Gets the objects that represent the selection displayed in the drop-down list. </summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> containing the selection. </returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual DataGridViewComboBoxCell.ObjectCollection Items => this.GetItems(this.DataGridView);

    /// <summary>Gets or sets the local items.</summary>
    /// <value>The local items.</value>
    private DataGridViewComboBoxCell.ObjectCollection LocalItems
    {
      get => this.mobjItems;
      set => this.mobjItems = value;
    }

    /// <summary>Gets or sets the maximum number of items shown in the drop-down list.</summary>
    /// <returns>The number of drop-down list items to allow. The minimum is 1 and the maximum is 100; the default is 8.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 1 or greater than 100 when setting this property.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(8)]
    public virtual int MaxDropDownItems
    {
      get
      {
        int maxDropDownItems = this.mintMaxDropDownItems;
        if (maxDropDownItems == -1)
        {
          if (this.DataGridView != null && this.ColumnIndex < this.DataGridView.Columns.Count && this.ColumnIndex >= 0 && this.DataGridView.Columns[this.ColumnIndex].CellTemplate != null)
          {
            maxDropDownItems = ((DataGridViewComboBoxCell) this.DataGridView.Columns[this.ColumnIndex].CellTemplate).MaxDropDownItems;
            this.mintMaxDropDownItems = maxDropDownItems;
          }
          if (maxDropDownItems == -1)
          {
            maxDropDownItems = 8;
            this.mintMaxDropDownItems = maxDropDownItems;
          }
        }
        return maxDropDownItems;
      }
      set
      {
        if (value < 1 || value > 100)
        {
          object[] objArray1 = new object[2];
          int num = 1;
          objArray1[0] = (object) num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
          num = 100;
          objArray1[1] = (object) num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
          object[] objArray2 = objArray1;
          throw new ArgumentOutOfRangeException(nameof (MaxDropDownItems), (object) value, SR.GetString("DataGridViewComboBoxCell_MaxDropDownItemsOutOfRange", objArray2));
        }
        this.mintMaxDropDownItems = value;
      }
    }

    /// <summary>Gets a value indicating whether [paint XP themes].</summary>
    /// <value><c>true</c> if [paint XP themes]; otherwise, <c>false</c>.</value>
    private bool PaintXPThemes => this.FlatStyle != FlatStyle.Flat && this.FlatStyle != FlatStyle.Popup;

    /// <summary>Gets or sets a value indicating whether the items in the combo box are automatically sorted.</summary>
    /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.ArgumentException">An attempt was made to sort a cell that is attached to a data source.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public virtual bool Sorted
    {
      get => ((uint) this.Flags & 2U) > 0U;
      set
      {
        if (value == this.Sorted)
          return;
        if (value)
        {
          if (this.DataSource != null)
            throw new ArgumentException(SR.GetString("ComboBoxSortWithDataSource"));
          this.Items.SortInternal();
          this.Flags |= (byte) 2;
        }
        else
          this.Flags &= (byte) 253;
      }
    }

    /// <summary>Gets or sets the template combo box column.</summary>
    /// <value>The template combo box column.</value>
    internal DataGridViewComboBoxColumn TemplateComboBoxColumn
    {
      get => this.mobjTemplateComboBoxColumn;
      set => this.mobjTemplateComboBoxColumn = value;
    }

    /// <summary>Gets or sets a string that specifies where to gather the underlying values used in the drop-down list.</summary>
    /// <returns>A string specifying the name of a property or column. The default value is <see cref="F:System.String.Empty"></see>, which indicates that this property is ignored.</returns>
    /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue("")]
    public virtual string ValueMember
    {
      get => this.mobjInternalValueMember == null ? string.Empty : this.mobjInternalValueMember as string;
      set
      {
        this.ValueMemberInternal = value;
        if (this.OwnsEditingComboBox(this.RowIndex))
          this.InitializeComboBoxText();
        else
          this.OnCommonChange();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has a custom drop down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool IsCustomDropDown => false;

    /// <summary>
    /// Gets a value indicating whether [owning column has items].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [owning column has items]; otherwise, <c>false</c>.
    /// </value>
    private bool OwningColumnHasItems => this.ColumnIndex != -1 && this.DataGridView != null && this.DataGridView.Columns[this.ColumnIndex] != null && this.DataGridView.Columns[this.ColumnIndex] is DataGridViewComboBoxColumn && ((DataGridViewComboBoxColumn) this.DataGridView.Columns[this.ColumnIndex]).Items.Count > 0;

    /// <summary>
    /// Gets a value indicating whether [sholud render combobox items].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [sholud render combobox items]; otherwise, <c>false</c>.
    /// </value>
    private bool SholudRenderComboboxItems
    {
      get
      {
        DataGridViewComboBoxCell.ObjectCollection objCollection1 = this.LocalItems;
        bool flag = objCollection1 != null && objCollection1.Count > 0;
        if (!flag && this.TemplateComboBoxColumn != null)
        {
          objCollection1 = this.GetItems(this.TemplateComboBoxColumn.DataGridView);
          flag = objCollection1 != null && objCollection1.Count > 0;
        }
        return flag && (this.ColumnIndex == -1 || !this.CollectionsEquals(objCollection1, ((DataGridViewComboBoxColumn) this.DataGridView.Columns[this.ColumnIndex]).Items)) && !this.IsCustomDropDown;
      }
    }

    /// <summary>Sets the value member internal.</summary>
    /// <value>The value member internal.</value>
    private string ValueMemberInternal
    {
      set
      {
        this.InitializeValueMemberPropertyDescriptor(value);
        if ((value == null || value.Length <= 0) && this.mobjInternalValueMember == null)
          return;
        this.mobjInternalValueMember = (object) value;
      }
    }

    /// <summary>Gets or sets the value member property.</summary>
    /// <value>The value member property.</value>
    private PropertyDescriptor ValueMemberProperty
    {
      get
      {
        if (this.mobjValueMember == null)
          this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
        return this.mobjValueMember;
      }
      set
      {
        if (value == null && this.mobjValueMember == null)
          return;
        this.mobjValueMember = value;
      }
    }

    /// <summary>Gets or sets the data type of the values in the cell.</summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
    public override Type ValueType
    {
      get
      {
        if (this.ValueMemberProperty != null)
          return this.ValueMemberProperty.PropertyType;
        if (this.DisplayMemberProperty != null)
          return this.DisplayMemberProperty.PropertyType;
        Type valueType = base.ValueType;
        return valueType != (Type) null ? valueType : DataGridViewComboBoxCell.mobjDefaultValueType;
      }
    }

    [Serializable]
    private sealed class ItemComparer : IComparer
    {
      private DataGridViewComboBoxCell dataGridViewComboBoxCell;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ItemComparer" /> class.
      /// </summary>
      /// <param name="objDataGridViewComboBoxCell">The data grid view combo box cell.</param>
      public ItemComparer(
        DataGridViewComboBoxCell objDataGridViewComboBoxCell)
      {
        this.dataGridViewComboBoxCell = objDataGridViewComboBoxCell;
      }

      public int Compare(object objItem1, object objItem2) => objItem1 == null ? (objItem2 == null ? 0 : -1) : (objItem2 == null ? 1 : Application.CurrentCulture.CompareInfo.Compare(this.dataGridViewComboBoxCell.GetItemDisplayText(objItem1), this.dataGridViewComboBoxCell.GetItemDisplayText(objItem2), CompareOptions.StringSort));
    }

    /// <summary>Represents the collection of selection choices in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
    [ListBindable(false)]
    [Serializable]
    public class ObjectCollection : IList, ICollection, IEnumerable
    {
      private IComparer mobjComparer;
      private ArrayList mobjItems;
      private DataGridViewComboBoxCell mobjOwner;

      /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
      /// <param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> that owns the collection.</param>
      public ObjectCollection(DataGridViewComboBoxCell objOwner) => this.mobjOwner = objOwner;

      /// <summary>Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
      /// <returns>The position into which the new element was inserted.</returns>
      /// <param name="objItem">An object representing the item to add to the collection.</param>
      /// <exception cref="T:System.ArgumentNullException">item is null.</exception>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      public virtual int Add(object objItem)
      {
        this.mobjOwner.CheckNoDataSource();
        int num = objItem != null ? this.InnerArray.Add(objItem) : throw new ArgumentNullException("item");
        bool flag = false;
        if (this.mobjOwner.Sorted)
        {
          try
          {
            this.InnerArray.Sort(this.Comparer);
            num = this.InnerArray.IndexOf(objItem);
            flag = true;
          }
          finally
          {
            if (!flag)
              this.InnerArray.Remove(objItem);
          }
        }
        this.mobjOwner.OnItemsCollectionChanged();
        return num;
      }

      /// <summary>Adds one or more items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
      /// <param name="arrItems">One or more objects that represent items for the drop-down list.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
      /// <exception cref="T:System.InvalidOperationException">One or more of the items in the items array is null.</exception>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      /// <exception cref="T:System.ArgumentNullException">items is null.</exception>
      public virtual void AddRange(params object[] arrItems)
      {
        this.mobjOwner.CheckNoDataSource();
        this.AddRangeInternal((ICollection) arrItems);
        this.mobjOwner.OnItemsCollectionChanged();
      }

      /// <summary>Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
      /// <param name="objValues">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to load into this collection.</param>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.InvalidOperationException">One or more of the items in the value collection is null.</exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public void AddRange(
        DataGridViewComboBoxCell.ObjectCollection objValues)
      {
        this.mobjOwner.CheckNoDataSource();
        this.AddRangeInternal((ICollection) objValues);
        this.mobjOwner.OnItemsCollectionChanged();
      }

      internal void AddRangeInternal(ICollection objItems)
      {
        if (objItems == null)
          throw new ArgumentNullException("items");
        foreach (object objItem in (IEnumerable) objItems)
        {
          if (objItem == null)
            throw new InvalidOperationException(SR.GetString("InvalidNullItemInCollection"));
        }
        this.InnerArray.AddRange(objItems);
        if (!this.mobjOwner.Sorted)
          return;
        this.InnerArray.Sort(this.Comparer);
      }

      /// <summary>Clears all items from the collection.</summary>
      /// <exception cref="T:System.InvalidOperationException">The collection contains at least one item and the cell is in a shared row.</exception>
      /// <exception cref="T:System.ArgumentException">The collection contains at least one item and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      public void Clear()
      {
        if (this.InnerArray.Count <= 0)
          return;
        this.mobjOwner.CheckNoDataSource();
        this.InnerArray.Clear();
        this.mobjOwner.OnItemsCollectionChanged();
      }

      internal void ClearInternal() => this.InnerArray.Clear();

      /// <summary>Determines whether the specified item is contained in the collection.</summary>
      /// <returns>true if the item is in the collection; otherwise, false.</returns>
      /// <param name="objValue">An object representing the item to locate in the collection.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public bool Contains(object objValue) => this.IndexOf(objValue) != -1;

      /// <summary>Copies the entire collection into an existing array of objects at a specified location within the array.</summary>
      /// <param name="intArrayIndex">The index of the element in dest at which to start copying.</param>
      /// <param name="arrDestination">The destination array to which the contents will be copied.</param>
      /// <exception cref="T:System.ArgumentNullException">destination is null.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0 or equal to or greater than the length of destination.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> is greater than the available space from arrayIndex to the end of destination.</exception>
      /// <exception cref="T:System.ArgumentException">destination is multidimensional.</exception>
      public void CopyTo(object[] arrDestination, int intArrayIndex)
      {
        int count = this.InnerArray.Count;
        for (int index = 0; index < count; ++index)
          arrDestination[index + intArrayIndex] = this.InnerArray[index];
      }

      /// <summary>Returns an enumerator that can iterate through a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see>.</summary>
      /// <returns>An enumerator of type <see cref="T:System.Collections.IEnumerator"></see>.</returns>
      public IEnumerator GetEnumerator() => this.InnerArray.GetEnumerator();

      /// <summary>Returns the index of the specified item in the collection.</summary>
      /// <returns>The zero-based index of the value parameter if it is found in the collection; otherwise, -1.</returns>
      /// <param name="objValue">An object representing the item to locate in the collection.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public int IndexOf(object objValue) => objValue != null ? this.InnerArray.IndexOf(objValue) : throw new ArgumentNullException("value");

      /// <summary>Inserts an item into the collection at the specified index. </summary>
      /// <param name="objItem">An object representing the item to insert.</param>
      /// <param name="index">The zero-based index at which to place item within an unsorted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</param>
      /// <exception cref="T:System.ArgumentNullException">item is null.</exception>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection. </exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      public void Insert(int index, object objItem)
      {
        this.mobjOwner.CheckNoDataSource();
        if (objItem == null)
          throw new ArgumentNullException("item");
        if (index < 0 || index > this.InnerArray.Count)
          throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.mobjOwner.Sorted)
        {
          this.Add(objItem);
        }
        else
        {
          this.InnerArray.Insert(index, objItem);
          this.mobjOwner.OnItemsCollectionChanged();
        }
      }

      /// <summary>Removes the specified object from the collection.</summary>
      /// <param name="objValue">An object representing the item to remove from the collection.</param>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      public void Remove(object objValue)
      {
        int index = this.InnerArray.IndexOf(objValue);
        if (index == -1)
          return;
        this.RemoveAt(index);
      }

      /// <summary>Removes the object at the specified index.</summary>
      /// <param name="index">The zero-based index of the object to be removed.</param>
      /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
      public void RemoveAt(int index)
      {
        this.mobjOwner.CheckNoDataSource();
        if (index < 0 || index >= this.InnerArray.Count)
          throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        this.InnerArray.RemoveAt(index);
        this.mobjOwner.OnItemsCollectionChanged();
      }

      internal void SortInternal() => this.InnerArray.Sort(this.Comparer);

      void ICollection.CopyTo(Array objDestinationArray, int index)
      {
        int count = this.InnerArray.Count;
        for (int index1 = 0; index1 < count; ++index1)
          objDestinationArray.SetValue(this.InnerArray[index1], index1 + index);
      }

      int IList.Add(object objItem)
      {
        this.mobjOwner.CheckNoDataSource();
        int num = objItem != null ? this.InnerArray.Add(objItem) : throw new ArgumentNullException("item");
        bool flag = false;
        if (this.mobjOwner.Sorted)
        {
          try
          {
            this.InnerArray.Sort(this.Comparer);
            num = this.InnerArray.IndexOf(objItem);
            flag = true;
          }
          finally
          {
            if (!flag)
              this.InnerArray.Remove(objItem);
          }
        }
        this.mobjOwner.OnItemsCollectionChanged();
        return num;
      }

      private IComparer Comparer
      {
        get
        {
          if (this.mobjComparer == null)
            this.mobjComparer = (IComparer) new DataGridViewComboBoxCell.ItemComparer(this.mobjOwner);
          return this.mobjComparer;
        }
      }

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of items in the collection.</returns>
      public int Count => this.InnerArray.Count;

      internal ArrayList InnerArray
      {
        get
        {
          if (this.mobjItems == null)
            this.mobjItems = new ArrayList();
          return this.mobjItems;
        }
      }

      /// <summary>Gets a value indicating whether the collection is read-only.</summary>
      /// <returns>true if the collection is read-only; otherwise, false.</returns>
      public bool IsReadOnly => false;

      /// <summary>Gets or sets the item at the current index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
      /// <returns>The <see cref="T:System.Object"></see> stored at the given index.</returns>
      /// <param name="index">The zero-based index of the element to get or set.</param>
      /// <exception cref="T:System.ArgumentException">When setting this property, the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
      /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
      /// <exception cref="T:System.InvalidOperationException">When setting this property, the cell is in a shared row.</exception>
      public virtual object this[int index]
      {
        get
        {
          if (index < 0 || index >= this.InnerArray.Count)
            throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
          return this.InnerArray[index];
        }
        set
        {
          this.mobjOwner.CheckNoDataSource();
          if (value == null)
            throw new ArgumentNullException(nameof (value));
          if (index < 0 || index >= this.InnerArray.Count)
            throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
          this.InnerArray[index] = value;
          this.mobjOwner.OnItemsCollectionChanged();
        }
      }

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => (object) this;

      bool IList.IsFixedSize => false;
    }
  }
}
