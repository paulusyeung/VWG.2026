// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutSettings
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Collects the characteristics associated with table layouts.
  /// </summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [TypeConverter(typeof (TableLayoutSettingsTypeConverter))]
  [Serializable]
  public sealed class TableLayoutSettings : LayoutSettings, ISerializable, IObservableItem
  {
    private TableLayoutPanelCellBorderStyle menmBorderStyle;
    private TableLayoutSettings.TableLayoutSettingsStub mobjTableLayoutSettingsStub;
    private static int[] marrBorderStyleToOffset = new int[7]
    {
      0,
      1,
      2,
      3,
      2,
      3,
      3
    };

    internal TableLayoutSettings(
      SerializationInfo objSerializationInfo,
      StreamingContext objContext)
      : base((IArrangedElement) null)
    {
      this.mobjOwner = objSerializationInfo.GetValue("Owner", typeof (IArrangedElement)) as IArrangedElement;
      if (this.mobjOwner == null)
        this.mobjTableLayoutSettingsStub = new TableLayoutSettings.TableLayoutSettingsStub();
      TypeConverter converter = TypeDescriptor.GetConverter((object) this);
      string text = objSerializationInfo.GetString("SerializedString");
      if (CommonUtils.IsNullOrEmpty(text) || converter == null || !(converter.ConvertFromInvariantString(text) is TableLayoutSettings objSettings))
        return;
      this.ApplySettings(objSettings);
    }

    internal TableLayoutSettings(IArrangedElement objOwner)
      : base(objOwner)
    {
    }

    internal TableLayoutSettings()
      : base((IArrangedElement) null)
    {
      this.mobjTableLayoutSettingsStub = new TableLayoutSettings.TableLayoutSettingsStub();
    }

    [SRDescription("TableLayoutPanelCellBorderStyleDescr")]
    [DefaultValue(0)]
    [SRCategory("CatAppearance")]
    internal TableLayoutPanelCellBorderStyle CellBorderStyle
    {
      get => this.menmBorderStyle;
      set
      {
        this.menmBorderStyle = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 6) ? value : throw new ArgumentException(SR.GetString("InvalidArgument", (object) nameof (CellBorderStyle), (object) value.ToString()));
        this.FireObservableItemPropertyChanged(nameof (CellBorderStyle));
        TableLayout.GetContainerInfo(this.Owner).CellBorderWidth = TableLayoutSettings.marrBorderStyleToOffset[(int) value];
      }
    }

    [DefaultValue(0)]
    internal int CellBorderWidth => TableLayout.GetContainerInfo(this.Owner).CellBorderWidth;

    /// <summary>Gets or sets the column count.</summary>
    /// <value>The column count.</value>
    [DefaultValue(0)]
    [SRDescription("GridPanelColumnsDescr")]
    [SRCategory("CatLayout")]
    public int ColumnCount
    {
      get => TableLayout.GetContainerInfo(this.Owner).MaxColumns;
      set
      {
        if (value < 0)
        {
          object[] objArray = new object[3]
          {
            (object) nameof (ColumnCount),
            (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture),
            (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)
          };
          throw new ArgumentOutOfRangeException(nameof (ColumnCount), (object) value, SR.GetString("InvalidLowBoundArgumentEx", objArray));
        }
        TableLayout.GetContainerInfo(this.Owner).MaxColumns = value;
        this.FireObservableItemPropertyChanged(nameof (ColumnCount));
      }
    }

    /// <summary>Gets the column styles.</summary>
    /// <value>The column styles.</value>
    [SRCategory("CatLayout")]
    [SRDescription("GridPanelColumnStylesDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TableLayoutColumnStyleCollection ColumnStyles => this.IsStub ? this.mobjTableLayoutSettingsStub.ColumnStyles : TableLayout.GetContainerInfo(this.Owner).ColumnStyles;

    /// <summary>Gets or sets the grow style.</summary>
    /// <value>The grow style.</value>
    [SRDescription("TableLayoutPanelGrowStyleDescr")]
    [DefaultValue(1)]
    [SRCategory("CatLayout")]
    public TableLayoutPanelGrowStyle GrowStyle
    {
      get => TableLayout.GetContainerInfo(this.Owner).GrowStyle;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) nameof (GrowStyle), (object) value.ToString()));
        TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this.Owner);
        if (containerInfo.GrowStyle == value)
          return;
        containerInfo.GrowStyle = value;
        this.FireObservableItemPropertyChanged(nameof (GrowStyle));
      }
    }

    internal bool IsStub => this.mobjTableLayoutSettingsStub != null;

    /// <summary>Gets the layout engine.</summary>
    /// <value>The layout engine.</value>
    public override LayoutEngine LayoutEngine => (LayoutEngine) TableLayout.Instance;

    /// <summary>Gets or sets the row count.</summary>
    /// <value>The row count.</value>
    [SRDescription("GridPanelRowsDescr")]
    [DefaultValue(0)]
    [SRCategory("CatLayout")]
    public int RowCount
    {
      get => TableLayout.GetContainerInfo(this.Owner).MaxRows;
      set
      {
        if (value < 0)
        {
          object[] objArray = new object[3]
          {
            (object) nameof (RowCount),
            (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture),
            (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)
          };
          throw new ArgumentOutOfRangeException(nameof (RowCount), (object) value, SR.GetString("InvalidLowBoundArgumentEx", objArray));
        }
        TableLayout.GetContainerInfo(this.Owner).MaxRows = value;
        this.FireObservableItemPropertyChanged(nameof (RowCount));
      }
    }

    /// <summary>Gets the row styles.</summary>
    /// <value>The row styles.</value>
    [SRDescription("GridPanelRowStylesDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatLayout")]
    public TableLayoutRowStyleCollection RowStyles => this.IsStub ? this.mobjTableLayoutSettingsStub.RowStyles : TableLayout.GetContainerInfo(this.Owner).RowStyles;

    private TableLayout TableLayout => (TableLayout) this.LayoutEngine;

    /// <summary>
    /// Property change indicator for the observable item interface
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

    /// <summary>
    /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
    /// </summary>
    /// <param name="strProperty">The name of the property that has changed</param>
    protected void FireObservableItemPropertyChanged(string strProperty)
    {
      if (this.ObservableItemPropertyChanged == null)
        return;
      this.ObservableItemPropertyChanged((object) this, new ObservableItemPropertyChangedArgs(strProperty));
    }

    /// <summary>Gets the cell position.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [DefaultValue(-1)]
    [SRDescription("TableLayoutSettingsGetCellPositionDescr")]
    [SRCategory("CatLayout")]
    public TableLayoutPanelCellPosition GetCellPosition(object objControl) => objControl != null ? new TableLayoutPanelCellPosition(this.GetColumn(objControl), this.GetRow(objControl)) : throw new ArgumentNullException("control");

    /// <summary>Gets the column.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRCategory("CatLayout")]
    [SRDescription("GridPanelColumnDescr")]
    [DefaultValue(-1)]
    public int GetColumn(object objControl)
    {
      if (objControl == null)
        throw new ArgumentNullException("control");
      return this.IsStub ? this.mobjTableLayoutSettingsStub.GetColumn(objControl) : TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).ColumnPosition;
    }

    /// <summary>Gets the column span.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    public int GetColumnSpan(object objControl)
    {
      if (objControl == null)
        throw new ArgumentNullException("control");
      return this.IsStub ? this.mobjTableLayoutSettingsStub.GetColumnSpan(objControl) : TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).ColumnSpan;
    }

    /// <summary>Gets the row.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRDescription("GridPanelRowDescr")]
    [DefaultValue(-1)]
    [SRCategory("CatLayout")]
    public int GetRow(object objControl)
    {
      if (objControl == null)
        throw new ArgumentNullException("control");
      return this.IsStub ? this.mobjTableLayoutSettingsStub.GetRow(objControl) : TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).RowPosition;
    }

    /// <summary>Gets the row span.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    public int GetRowSpan(object objControl) => this.IsStub ? this.mobjTableLayoutSettingsStub.GetRowSpan(objControl) : TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).RowSpan;

    /// <summary>Sets the cell position.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="objCellPosition">The cell position.</param>
    [SRCategory("CatLayout")]
    [DefaultValue(-1)]
    [SRDescription("TableLayoutSettingsSetCellPositionDescr")]
    public void SetCellPosition(object objControl, TableLayoutPanelCellPosition objCellPosition)
    {
      if (objControl == null)
        throw new ArgumentNullException("control");
      this.SetCellPosition(objControl, objCellPosition.Row, objCellPosition.Column, true, true);
    }

    /// <summary>Sets the column.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intColumn">The column.</param>
    public void SetColumn(object objControl, int intColumn)
    {
      if (intColumn < -1)
        throw new ArgumentException(SR.GetString("InvalidArgument", (object) "Column", (object) intColumn.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (this.IsStub)
        this.mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
      else
        this.SetCellPosition(objControl, -1, intColumn, false, true);
    }

    /// <summary>Sets the column span.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intValue">The value.</param>
    public void SetColumnSpan(object objControl, int intValue)
    {
      if (intValue < 1)
        throw new ArgumentOutOfRangeException("ColumnSpan", SR.GetString("InvalidArgument", (object) "ColumnSpan", (object) intValue.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (this.IsStub)
      {
        this.mobjTableLayoutSettingsStub.SetColumnSpan(objControl, intValue);
      }
      else
      {
        IArrangedElement arrangedElement = this.LayoutEngine.CastToArrangedElement(objControl);
        if (this.GetElementContainer(arrangedElement) != null)
          TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(this.GetElementContainer(arrangedElement)));
        TableLayout.GetLayoutInfo(arrangedElement).ColumnSpan = intValue;
      }
    }

    /// <summary>Sets the row.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intRow">The row.</param>
    public void SetRow(object objControl, int intRow)
    {
      if (objControl == null)
        throw new ArgumentNullException("control");
      if (intRow < -1)
        throw new ArgumentOutOfRangeException("Row", SR.GetString("InvalidArgument", (object) "Row", (object) intRow.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.SetCellPosition(objControl, intRow, -1, true, false);
    }

    /// <summary>Sets the row span.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intValue">The value.</param>
    public void SetRowSpan(object objControl, int intValue)
    {
      if (intValue < 1)
        throw new ArgumentOutOfRangeException("RowSpan", SR.GetString("InvalidArgument", (object) "RowSpan", (object) intValue.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (objControl == null)
        throw new ArgumentNullException("control");
      if (this.IsStub)
      {
        this.mobjTableLayoutSettingsStub.SetRowSpan(objControl, intValue);
      }
      else
      {
        IArrangedElement arrangedElement = this.LayoutEngine.CastToArrangedElement(objControl);
        if (this.GetElementContainer(arrangedElement) != null)
          TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(this.GetElementContainer(arrangedElement)));
        TableLayout.GetLayoutInfo(arrangedElement).RowSpan = intValue;
      }
    }

    void ISerializable.GetObjectData(
      SerializationInfo objSerializationInfo,
      StreamingContext objContext)
    {
      string invariantString = TypeDescriptor.GetConverter((object) this)?.ConvertToInvariantString((object) this);
      if (!CommonUtils.IsNullOrEmpty(invariantString))
        objSerializationInfo.AddValue("SerializedString", (object) invariantString);
      objSerializationInfo.AddValue("Owner", (object) this.mobjOwner);
    }

    private void SetCellPosition(
      object objControl,
      int intRow,
      int intColumn,
      bool blnRowSpecified,
      bool blnColSpecified)
    {
      if (this.IsStub)
      {
        if (blnColSpecified)
          this.mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
        if (blnRowSpecified)
          this.mobjTableLayoutSettingsStub.SetRow(objControl, intRow);
      }
      else
      {
        IArrangedElement arrangedElement = this.LayoutEngine.CastToArrangedElement(objControl);
        if (this.GetElementContainer(arrangedElement) != null)
          TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(this.GetElementContainer(arrangedElement)));
        TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(arrangedElement);
        if (blnColSpecified)
          layoutInfo.ColumnPosition = intColumn;
        if (blnRowSpecified)
          layoutInfo.RowPosition = intRow;
      }
      this.FireObservableItemPropertyChanged(nameof (SetCellPosition));
    }

    internal void ApplySettings(TableLayoutSettings objSettings)
    {
      if (!objSettings.IsStub)
        return;
      if (!this.IsStub)
        objSettings.mobjTableLayoutSettingsStub.ApplySettings(this);
      else
        this.mobjTableLayoutSettingsStub = objSettings.mobjTableLayoutSettingsStub;
    }

    internal IArrangedElement GetControlFromPosition(int intColumn, int intRow) => this.TableLayout.GetControlFromPosition(this.Owner, intColumn, intRow);

    internal List<TableLayoutSettings.ControlInformation> GetControlsInformation()
    {
      if (this.IsStub)
        return this.mobjTableLayoutSettingsStub.GetControlsInformation();
      List<TableLayoutSettings.ControlInformation> controlsInformation = new List<TableLayoutSettings.ControlInformation>(this.Owner.Children.Count);
      foreach (IArrangedElement child in this.Owner.Children)
      {
        if (child is Control control)
        {
          TableLayoutSettings.ControlInformation controlInformation = new TableLayoutSettings.ControlInformation();
          PropertyDescriptor property = TypeDescriptor.GetProperties((object) control)["Name"];
          if (property != null && property.PropertyType == typeof (string))
            controlInformation.Name = property.GetValue((object) control);
          controlInformation.Row = this.GetRow((object) control);
          controlInformation.RowSpan = this.GetRowSpan((object) control);
          controlInformation.Column = this.GetColumn((object) control);
          controlInformation.ColumnSpan = this.GetColumnSpan((object) control);
          controlsInformation.Add(controlInformation);
        }
      }
      return controlsInformation;
    }

    internal IArrangedElement GetElementContainer(IArrangedElement objElement)
    {
      IArrangedElement elementContainer = (IArrangedElement) null;
      if (objElement != null && objElement is Control && ((ComponentBase) objElement).Container is IArrangedElement)
        elementContainer = ((ComponentBase) objElement).Container as IArrangedElement;
      return elementContainer;
    }

    internal TableLayoutPanelCellPosition GetPositionFromControl(IArrangedElement objElement) => this.TableLayout.GetPositionFromControl(this.Owner, objElement);

    [Serializable]
    public class StyleConverter : TypeConverter
    {
      public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

      /// <summary>
      /// 
      /// </summary>
      /// <remarks>
      /// The function essentially limited to work in Partially trusted environment.
      /// InstanceDescriptor c'tor is requiring Full trust (.NET 2.0 - 3.5)
      /// </remarks>
      public override object ConvertTo(
        ITypeDescriptorContext objContext,
        CultureInfo objCulture,
        object objValue,
        Type objDestinationType)
      {
        if (objDestinationType == (Type) null)
          throw new ArgumentNullException(nameof (objDestinationType));
        if (objDestinationType == typeof (InstanceDescriptor) && objValue is TableLayoutStyle)
        {
          object instanceDescriptor = this.ConvertToInstanceDescriptor(objContext, objValue);
          if (instanceDescriptor != null)
            return instanceDescriptor;
        }
        return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
      }

      /// <summary>Convert to InstanceDescriptor</summary>
      /// <remarks>
      /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
      /// </remarks>
      private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
      {
        TableLayoutStyle tableLayoutStyle = (TableLayoutStyle) objValue;
        switch (tableLayoutStyle.SizeType)
        {
          case SizeType.AutoSize:
            return (object) new InstanceDescriptor((MemberInfo) tableLayoutStyle.GetType().GetConstructor(new Type[0]), (ICollection) new object[0]);
          case SizeType.Absolute:
          case SizeType.Percent:
            return (object) new InstanceDescriptor((MemberInfo) tableLayoutStyle.GetType().GetConstructor(new Type[2]
            {
              typeof (SizeType),
              typeof (int)
            }), (ICollection) new object[2]
            {
              (object) tableLayoutStyle.SizeType,
              (object) tableLayoutStyle.Size
            });
          default:
            return (object) null;
        }
      }
    }

    [Serializable]
    private class TableLayoutSettingsStub
    {
      private TableLayoutColumnStyleCollection mobjColumnStyles;
      private Dictionary<object, TableLayoutSettings.ControlInformation> mobjControlsInfo;
      private static TableLayoutSettings.ControlInformation mobjDefaultControlInfo = new TableLayoutSettings.ControlInformation((object) null, -1, -1, 1, 1);
      private bool mblnIsValid = true;
      private TableLayoutRowStyleCollection mobjRowStyles;

      public TableLayoutColumnStyleCollection ColumnStyles
      {
        get
        {
          if (this.mobjColumnStyles == null)
            this.mobjColumnStyles = new TableLayoutColumnStyleCollection();
          return this.mobjColumnStyles;
        }
      }

      public bool IsValid => this.mblnIsValid;

      public TableLayoutRowStyleCollection RowStyles
      {
        get
        {
          if (this.mobjRowStyles == null)
            this.mobjRowStyles = new TableLayoutRowStyleCollection();
          return this.mobjRowStyles;
        }
      }

      public int GetColumn(object objControlName) => this.GetControlInformation(objControlName).Column;

      public int GetColumnSpan(object objControlName) => this.GetControlInformation(objControlName).ColumnSpan;

      public int GetRow(object objControlName) => this.GetControlInformation(objControlName).Row;

      public int GetRowSpan(object objControlName) => this.GetControlInformation(objControlName).RowSpan;

      public void SetColumn(object objControlName, int intColumn)
      {
        if (this.GetColumn(objControlName) == intColumn)
          return;
        TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName) with
        {
          Column = intColumn
        };
        this.SetControlInformation(objControlName, controlInformation);
      }

      public void SetColumnSpan(object objControlName, int intValue)
      {
        if (this.GetColumnSpan(objControlName) == intValue)
          return;
        TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName) with
        {
          ColumnSpan = intValue
        };
        this.SetControlInformation(objControlName, controlInformation);
      }

      public void SetRow(object objControlName, int intRow)
      {
        if (this.GetRow(objControlName) == intRow)
          return;
        TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName) with
        {
          Row = intRow
        };
        this.SetControlInformation(objControlName, controlInformation);
      }

      public void SetRowSpan(object objControlName, int intValue)
      {
        if (this.GetRowSpan(objControlName) == intValue)
          return;
        TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName) with
        {
          RowSpan = intValue
        };
        this.SetControlInformation(objControlName, controlInformation);
      }

      private TableLayoutSettings.ControlInformation GetControlInformation(object objControlName) => this.mobjControlsInfo == null || !this.mobjControlsInfo.ContainsKey(objControlName) ? TableLayoutSettings.TableLayoutSettingsStub.mobjDefaultControlInfo : this.mobjControlsInfo[objControlName];

      private void SetControlInformation(
        object objControlName,
        TableLayoutSettings.ControlInformation objControlInformation)
      {
        if (this.mobjControlsInfo == null)
          this.mobjControlsInfo = new Dictionary<object, TableLayoutSettings.ControlInformation>();
        this.mobjControlsInfo[objControlName] = objControlInformation;
      }

      internal void ApplySettings(TableLayoutSettings objSettings)
      {
        TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objSettings.Owner);
        if (containerInfo.Container is Control container && this.mobjControlsInfo != null)
        {
          foreach (object key in this.mobjControlsInfo.Keys)
          {
            TableLayoutSettings.ControlInformation controlInformation = this.mobjControlsInfo[key];
            foreach (Control control in (ArrangedElementCollection) container.Controls)
            {
              if (control != null)
              {
                string string1 = (string) null;
                PropertyDescriptor property = TypeDescriptor.GetProperties((object) control)["Name"];
                if (property != null && property.PropertyType == typeof (string))
                  string1 = property.GetValue((object) control) as string;
                if (ClientUtils.SafeCompareStrings(string1, key as string, false))
                {
                  objSettings.SetRow((object) control, controlInformation.Row);
                  objSettings.SetColumn((object) control, controlInformation.Column);
                  objSettings.SetRowSpan((object) control, controlInformation.RowSpan);
                  objSettings.SetColumnSpan((object) control, controlInformation.ColumnSpan);
                  break;
                }
              }
            }
          }
        }
        containerInfo.RowStyles = this.mobjRowStyles;
        containerInfo.ColumnStyles = this.mobjColumnStyles;
        this.mobjColumnStyles = (TableLayoutColumnStyleCollection) null;
        this.mobjRowStyles = (TableLayoutRowStyleCollection) null;
        this.mblnIsValid = false;
      }

      internal List<TableLayoutSettings.ControlInformation> GetControlsInformation()
      {
        if (this.mobjControlsInfo == null)
          return new List<TableLayoutSettings.ControlInformation>();
        List<TableLayoutSettings.ControlInformation> controlsInformation = new List<TableLayoutSettings.ControlInformation>(this.mobjControlsInfo.Count);
        foreach (object key in this.mobjControlsInfo.Keys)
        {
          TableLayoutSettings.ControlInformation controlInformation = this.mobjControlsInfo[key] with
          {
            Name = key
          };
          controlsInformation.Add(controlInformation);
        }
        return controlsInformation;
      }
    }

    [Serializable]
    internal struct ControlInformation
    {
      internal object Name;
      internal int Row;
      internal int Column;
      internal int RowSpan;
      internal int ColumnSpan;

      internal ControlInformation(
        object objName,
        int intRow,
        int intColumn,
        int intRowSpan,
        int intColumnSpan)
      {
        this.Name = objName;
        this.Row = intRow;
        this.Column = intColumn;
        this.RowSpan = intRowSpan;
        this.ColumnSpan = intColumnSpan;
      }
    }
  }
}
