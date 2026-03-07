// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewLinkColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a column of cells that contain links in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewLinkColumn), "DataGridViewLinkColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewLinkColumn : DataGridViewColumn
  {
    private string mstrText;
    private static Type mobjColumnType = typeof (DataGridViewLinkColumn);

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see> class. </summary>
    public DataGridViewLinkColumn()
      : this(new DataGridViewLinkCell())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn" /> class.
    /// </summary>
    /// <param name="objCellTemplate">The obj cell template.</param>
    protected DataGridViewLinkColumn(DataGridViewLinkCell objCellTemplate)
      : base((DataGridViewCell) objCellTemplate)
    {
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "4";

    /// <summary>Creates an exact copy of this column.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null. </exception>
    public override object Clone() => base.Clone();

    private bool ShouldSerializeActiveLinkColor() => !this.ActiveLinkColor.Equals((object) LinkUtilities.IEActiveLinkColor);

    private bool ShouldSerializeLinkColor() => !this.LinkColor.Equals((object) LinkUtilities.IELinkColor);

    private bool ShouldSerializeVisitedLinkColor() => !this.VisitedLinkColor.Equals((object) LinkUtilities.IEVisitedLinkColor);

    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.Append("DataGridViewLinkColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets the color used to display an active link within cells in the column. </summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    [SRDescription("DataGridView_LinkColumnActiveLinkColorDescr")]
    [SRCategory("CatAppearance")]
    public Color ActiveLinkColor
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).ActiveLinkColor : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ActiveLinkColor.Equals((object) value))
          return;
        ((DataGridViewLinkCell) this.CellTemplate).ActiveLinkColorInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.ActiveLinkColorInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell" /> is URL.
    /// </summary>
    /// <value><c>true</c> if URL; otherwise, <c>false</c>.</value>
    [SRDescription("DataGridView_LinkColumnUrlDescr")]
    [SRCategory("CatData")]
    public string Url
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).Url : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (!(this.Url != value))
          return;
        if (this.CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        ((DataGridViewLinkCell) this.CellTemplate).Url = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.Url = value;
        }
      }
    }

    /// <summary>Gets or sets the template used to create new cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see> instance.</returns>
    /// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override DataGridViewCell CellTemplate
    {
      get => base.CellTemplate;
      set
      {
        switch (value)
        {
          case null:
          case DataGridViewLinkCell _:
            base.CellTemplate = value;
            break;
          default:
            throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
        }
      }
    }

    /// <summary>Gets or sets a value that represents the behavior of links within cells in the column.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.LinkBehavior"></see> value indicating the link behavior. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [DefaultValue(0)]
    [SRDescription("DataGridView_LinkColumnLinkBehaviorDescr")]
    public LinkBehavior LinkBehavior
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).LinkBehavior : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.LinkBehavior.Equals((object) value))
          return;
        ((DataGridViewLinkCell) this.CellTemplate).LinkBehavior = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.LinkBehaviorInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>
    /// Gets or sets the ClientMode value of it's cell template.
    /// Setter sets the value to it's cell template as well as to all cells in the column.
    /// </summary>
    /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
    [SRDescription("DataGridView_LinkColumnClientModeDescr")]
    [SRCategory("CatBehavior")]
    public bool ClientMode
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).ClientMode : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ClientMode == value)
          return;
        if (this.CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        ((DataGridViewLinkCell) this.CellTemplate).ClientMode = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.ClientMode = value;
        }
      }
    }

    /// <summary>Gets or sets the color used to display an unselected link within cells in the column.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color. </returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_LinkColumnLinkColorDescr")]
    public Color LinkColor
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).LinkColor : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.LinkColor.Equals((object) value))
          return;
        ((DataGridViewLinkCell) this.CellTemplate).LinkColorInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.LinkColorInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets the link text displayed in a column's cells if <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.UseColumnTextForLinkValue"></see> is true.</summary>
    /// <returns>A <see cref="T:System.String"></see> containing the link text.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_LinkColumnTextDescr")]
    [DefaultValue(null)]
    public string Text
    {
      get => this.mstrText;
      set
      {
        if (string.Equals(value, this.Text, StringComparison.Ordinal))
          return;
        this.mstrText = value;
        if (this.DataGridView == null)
          return;
        if (this.UseColumnTextForLinkValue)
        {
          this.DataGridView.OnColumnCommonChange(this.Index);
        }
        else
        {
          DataGridViewRowCollection rows = this.DataGridView.Rows;
          int count = rows.Count;
          for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
          {
            if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell && cell.UseColumnTextForLinkValue)
            {
              this.DataGridView.OnColumnCommonChange(this.Index);
              return;
            }
          }
          this.DataGridView.InvalidateColumn(this.Index);
        }
      }
    }

    /// <summary>Gets or sets a value indicating whether the link changes color if it has been visited.</summary>
    /// <returns>true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_LinkColumnTrackVisitedStateDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool TrackVisitedState
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).TrackVisitedState : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.TrackVisitedState == value)
          return;
        ((DataGridViewLinkCell) this.CellTemplate).TrackVisitedStateInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.TrackVisitedStateInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
    /// <returns>true if the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    [DefaultValue(false)]
    [SRDescription("DataGridView_LinkColumnUseColumnTextForLinkValueDescr")]
    [SRCategory("CatAppearance")]
    public bool UseColumnTextForLinkValue
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).UseColumnTextForLinkValue : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.UseColumnTextForLinkValue == value)
          return;
        ((DataGridViewLinkCell) this.CellTemplate).UseColumnTextForLinkValueInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.UseColumnTextForLinkValueInternal = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets the color used to display a link that has been previously visited.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color. </returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    [SRDescription("DataGridView_LinkColumnVisitedLinkColorDescr")]
    [SRCategory("CatAppearance")]
    public Color VisitedLinkColor
    {
      get => this.CellTemplate != null ? ((DataGridViewLinkCell) this.CellTemplate).VisitedLinkColor : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.VisitedLinkColor.Equals((object) value))
          return;
        ((DataGridViewLinkCell) this.CellTemplate).VisitedLinkColorInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewLinkCell cell)
            cell.VisitedLinkColorInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }
  }
}
