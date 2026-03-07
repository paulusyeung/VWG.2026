// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewVisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The visual appearnce object of the ListView</summary>
  [VisualTemplate(typeof (ListView), "Visually adjusts the ListView control to an appearance more suitable for the customized device.")]
  [Skin(typeof (ListViewVisualTemplateSkin))]
  [Serializable]
  public class ListViewVisualTemplate : VisualTemplate
  {
    private ListViewVisualTemplateGroupingStyleEnum menmListViewVisualTemplateGroupingStyleEnum = ListViewVisualTemplateGroupingStyleEnum.Original;
    private ListViewVisualTemplateRowTemplateEnum menmListViewVisualTemplateRowTemplateEnum;
    private string mstrColumnNumberNewOrder;
    private string mstrListViewVisualTemplateRowCustomStyleName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewVisualTemplate" /> class.
    /// </summary>
    public ListViewVisualTemplate()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewVisualTemplate" /> class.
    /// </summary>
    /// <param name="enmProxyListViewGroupsVisualizerStyle">The enm proxy ListView groups visualizer style.</param>
    /// <param name="strColumnNumberNewOrder">The string column number new order.</param>
    public ListViewVisualTemplate(
      ListViewVisualTemplateGroupingStyleEnum enmProxyListViewGroupsVisualizerStyle,
      ListViewVisualTemplateRowTemplateEnum enmListViewVisualTemplateRowTemplateEnum,
      string strColumnNumberNewOrder,
      string strListViewVisualTemplateRowCustomStyleName)
    {
      this.menmListViewVisualTemplateGroupingStyleEnum = enmProxyListViewGroupsVisualizerStyle;
      this.menmListViewVisualTemplateRowTemplateEnum = enmListViewVisualTemplateRowTemplateEnum;
      this.mstrColumnNumberNewOrder = strColumnNumberNewOrder;
      this.mstrListViewVisualTemplateRowCustomStyleName = strListViewVisualTemplateRowCustomStyleName;
    }

    /// <summary>Gets the constroctor arguments. (For TypeContevert)</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object[] GetConsturctorArguments() => new object[4]
    {
      (object) this.menmListViewVisualTemplateGroupingStyleEnum,
      (object) this.menmListViewVisualTemplateRowTemplateEnum,
      (object) this.mstrColumnNumberNewOrder,
      (object) this.mstrListViewVisualTemplateRowCustomStyleName
    };

    /// <summary>Gets the constroctor types. (For TypeContevert)</summary>
    public override Type[] GetConstructorTypes() => new Type[4]
    {
      typeof (ListViewVisualTemplateGroupingStyleEnum),
      typeof (ListViewVisualTemplateRowTemplateEnum),
      typeof (string),
      typeof (string)
    };

    /// <summary>
    /// Gets or sets the proxy ListView groups visualizer style.
    /// </summary>
    /// <value>The proxy ListView groups visualizer style.</value>
    [DisplayName("Grouping style")]
    [Description("The grouping option of the ListViewItems.")]
    public ListViewVisualTemplateGroupingStyleEnum ListViewVisualTemplateGroupingStyle
    {
      get => this.menmListViewVisualTemplateGroupingStyleEnum;
      set => this.menmListViewVisualTemplateGroupingStyleEnum = value;
    }

    /// <summary>
    /// Gets or sets the proxy ListView groups visualizer style.
    /// </summary>
    /// <value>The proxy ListView groups visualizer style.</value>
    [DisplayName("Row template")]
    [Description("The template of a row in the ListView. To insert a custom template, choose \"Custom\".")]
    public ListViewVisualTemplateRowTemplateEnum ListViewVisualTemplateRowTemplate
    {
      get => this.menmListViewVisualTemplateRowTemplateEnum;
      set => this.menmListViewVisualTemplateRowTemplateEnum = value;
    }

    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public override void Render(IContext objContext, IAttributeWriter objWriter)
    {
      base.Render(objContext, objWriter);
      objWriter.WriteAttributeString("VIS_LV_GR", this.menmListViewVisualTemplateGroupingStyleEnum.ToString());
      if (!string.IsNullOrEmpty(this.mstrColumnNumberNewOrder))
        objWriter.WriteAttributeString("VIS_LV_CO", this.mstrColumnNumberNewOrder);
      if (this.menmListViewVisualTemplateRowTemplateEnum == ListViewVisualTemplateRowTemplateEnum.Custom)
        objWriter.WriteAttributeString("VIS_LVI_TPL", this.ListViewVisualTemplateRowCustomStyleName);
      else
        objWriter.WriteAttributeString("VIS_LVI_TPL", this.menmListViewVisualTemplateRowTemplateEnum.ToString());
    }

    /// <summary>Gets or sets the column number new order.</summary>
    /// <value>The column number new order.</value>
    [WebEditor(typeof (VisualTemplateListViewColumnOrderEditor), typeof (WebUITypeEditor))]
    [Editor(typeof (VisualTemplateListViewColumnOrderEditor), typeof (WebUITypeEditor))]
    [Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DisplayName("Columns order")]
    [Description("The order of the columns. Used together with row templates to determine the items position.")]
    public string ColumnNumberNewOrder
    {
      get => this.mstrColumnNumberNewOrder;
      set => this.mstrColumnNumberNewOrder = value;
    }

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => nameof (ListViewVisualTemplate);

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (ListViewVisualTemplateSkin), "ContactListWithGrouping.png");

    /// <summary>
    /// Gets or sets the name of the ListView visual template row custom style.
    /// </summary>
    /// <value>
    /// The name of the ListView visual template row custom style.
    /// </value>
    [DisplayName("Custom template")]
    [Description("The name of a custom row template. To insert a custom template, choose \"Custom\" under \"Row template\". Don't forget to set the columns order as well.")]
    public virtual string ListViewVisualTemplateRowCustomStyleName
    {
      get => this.mstrListViewVisualTemplateRowCustomStyleName;
      set => this.mstrListViewVisualTemplateRowCustomStyleName = value;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Customizable Display";

    /// <summary>Gets the default visual template for a given control.</summary>
    /// <param name="objControl">The object control.</param>
    /// <returns></returns>
    public override VisualTemplate GetDefault(Control objControl)
    {
      if (!(objControl is ListView listView))
        return (VisualTemplate) null;
      ListViewVisualTemplate viewVisualTemplate = new ListViewVisualTemplate();
      viewVisualTemplate.ListViewVisualTemplateGroupingStyle = ListViewVisualTemplateGroupingStyleEnum.AlphabetGrouping;
      StringBuilder stringBuilder = new StringBuilder();
      List<ColumnHeader> columnHeaderList = new List<ColumnHeader>();
      foreach (ColumnHeader sortingColumn in (IEnumerable) listView.SortingColumns)
      {
        if (sortingColumn.Type == ListViewColumnType.Number || sortingColumn.Type == ListViewColumnType.Text || sortingColumn.Type == ListViewColumnType.Date)
        {
          stringBuilder.Append(string.Format("{0}|", (object) sortingColumn.Index));
          columnHeaderList.Add(sortingColumn);
        }
      }
      foreach (ColumnHeader column in listView.Columns)
      {
        if (!columnHeaderList.Contains(column) && (column.Type == ListViewColumnType.Number || column.Type == ListViewColumnType.Text || column.Type == ListViewColumnType.Date))
          stringBuilder.Append(string.Format("{0}|", (object) column.Index));
      }
      viewVisualTemplate.ColumnNumberNewOrder = stringBuilder.ToString().Trim('|');
      viewVisualTemplate.ListViewVisualTemplateRowTemplate = ListViewVisualTemplateRowTemplateEnum.ContactList;
      return (VisualTemplate) viewVisualTemplate;
    }

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal override string ConvertToString()
    {
      string str1 = this.mstrColumnNumberNewOrder == null ? string.Empty : this.mstrColumnNumberNewOrder.Replace('|', '~');
      string str2 = this.mstrListViewVisualTemplateRowCustomStyleName == null ? string.Empty : this.mstrListViewVisualTemplateRowCustomStyleName;
      return string.Format("{0}|{1}|{2}|{3}|{4}", (object) base.ConvertToString(), (object) (int) this.menmListViewVisualTemplateGroupingStyleEnum, (object) (int) this.menmListViewVisualTemplateRowTemplateEnum, (object) str2, (object) str1);
    }

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal override void ConvertFromString(List<string> objVisualTemplateValues)
    {
      int result1 = 0;
      int result2 = 0;
      if (objVisualTemplateValues.Count != 4 || !int.TryParse(objVisualTemplateValues[0], out result1) || !int.TryParse(objVisualTemplateValues[1], out result2))
        return;
      if (Enum.IsDefined(typeof (ListViewVisualTemplateGroupingStyleEnum), (object) result1))
        this.menmListViewVisualTemplateGroupingStyleEnum = (ListViewVisualTemplateGroupingStyleEnum) result1;
      if (Enum.IsDefined(typeof (ListViewVisualTemplateRowTemplateEnum), (object) result2))
        this.menmListViewVisualTemplateRowTemplateEnum = (ListViewVisualTemplateRowTemplateEnum) result2;
      this.mstrListViewVisualTemplateRowCustomStyleName = string.IsNullOrEmpty(objVisualTemplateValues[2]) ? string.Empty : objVisualTemplateValues[2];
      if (!string.IsNullOrEmpty(objVisualTemplateValues[3]))
        this.mstrColumnNumberNewOrder = objVisualTemplateValues[3].Replace('~', '|');
      else
        this.mstrColumnNumberNewOrder = string.Empty;
    }
  }
}
