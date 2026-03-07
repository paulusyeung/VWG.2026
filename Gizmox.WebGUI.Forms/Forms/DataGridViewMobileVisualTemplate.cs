// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewMobileVisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [VisualTemplate(typeof (DataGridView), "Visually adjusts the DataGridView control to an appearance more suitable for the customized device.")]
  [Skin(typeof (DataGridViewMobileVisualTemplateSkin))]
  [Serializable]
  public class DataGridViewMobileVisualTemplate : VisualTemplate
  {
    private int mintNumberOfDisplayedColumns = 3;
    private string mstrNewColumnOrder;
    private int mintCaptionHeight;
    private int? mintCalculatedCaptionHeight;
    private int mintBottomMenuHeight;
    private int? mintCalculatedBottomMenuHeight;
    private List<string> mobjFilterOperators;

    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public override void Render(IContext objContext, IAttributeWriter objWriter)
    {
      base.Render(objContext, objWriter);
      objWriter.WriteAttributeString("VIS_DGV_NOC", this.mintNumberOfDisplayedColumns);
      if (!string.IsNullOrEmpty(this.mstrNewColumnOrder))
        objWriter.WriteAttributeString("VIS_LV_CO", this.mstrNewColumnOrder);
      if (this.mintCaptionHeight > 0)
        objWriter.WriteAttributeString("VIS_DGV_CH", this.mintCaptionHeight);
      else
        objWriter.WriteAttributeString("VIS_DGV_CH", this.GetCalculatedCaptionHeight());
      if (this.mintBottomMenuHeight > 0)
        objWriter.WriteAttributeString("VIS_DGV_BMH", this.mintBottomMenuHeight);
      else
        objWriter.WriteAttributeString("VIS_DGV_BMH", this.GetCalculatedBottomMenuHeight());
      if (this.mobjFilterOperators != null)
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string mobjFilterOperator in this.mobjFilterOperators)
          stringBuilder.Append(mobjFilterOperator);
        objWriter.WriteAttributeString("VIS_DGV_FO", stringBuilder.ToString().Trim('|'));
      }
      objWriter.WriteAttributeString("VIS_DGV_DORH", this.GetCalculatedBottomMenuHeight());
    }

    /// <summary>Gets the calculated height of the node.</summary>
    /// <returns></returns>
    private int GetCalculatedCaptionHeight()
    {
      if (!this.mintCalculatedCaptionHeight.HasValue)
        this.mintCalculatedCaptionHeight = new int?((SkinFactory.GetSkin((ISkinable) this) as DataGridViewMobileVisualTemplateSkin).CaptionHeight);
      return this.mintCalculatedCaptionHeight.Value;
    }

    /// <summary>Gets the calculated height of the node.</summary>
    /// <returns></returns>
    private int GetCalculatedBottomMenuHeight()
    {
      if (!this.mintCalculatedBottomMenuHeight.HasValue)
        this.mintCalculatedBottomMenuHeight = new int?((SkinFactory.GetSkin((ISkinable) this) as DataGridViewMobileVisualTemplateSkin).BottomMenuHeight);
      return this.mintCalculatedBottomMenuHeight.Value;
    }

    /// <summary>Gets or sets the new column order.</summary>
    /// <value>The new column order.</value>
    public string NewColumnOrder
    {
      get => this.mstrNewColumnOrder;
      set => this.mstrNewColumnOrder = value;
    }

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => "DataGridViewVisualTemplateForMobile";

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (TreeViewVisualTemplateSkin), "DataGridViewVisualTemplate_Mobile.png");

    /// <summary>Fires the event.</summary>
    /// <param name="objControl"></param>
    /// <param name="objEvent">The object event.</param>
    protected internal override void FireEvent(Control objControl, IEvent objEvent)
    {
      base.FireEvent(objControl, objEvent);
      if (!(objControl is DataGridView objOwningDataGridView))
        return;
      string str1 = objEvent["EventAction"];
      if (string.IsNullOrEmpty(str1))
        return;
      string member = objEvent.Member;
      Point memberPosition = objOwningDataGridView.GetMemberPosition(member);
      switch (str1)
      {
        case "ShowFilterOptions":
          if (memberPosition.X == -1 || !(objOwningDataGridView.FilterRow.Cells[memberPosition.X] is DataGridViewFilterCell cell1))
            break;
          List<FilterComparisonOperator> comparisonOperator1 = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(cell1.OwningColumn.ValueType);
          this.mobjFilterOperators = new List<string>();
          using (List<FilterComparisonOperator>.Enumerator enumerator = comparisonOperator1.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              FilterComparisonOperator current = enumerator.Current;
              this.mobjFilterOperators.Add(string.Format("{0}|{1}|", (object) SR.GetString(string.Format("FilterComparisionOperator_{0}", (object) current.ToString())), (object) DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(objOwningDataGridView, current)));
            }
            break;
          }
        case "SetFilterOption":
          if (memberPosition.X == -1)
            break;
          DataGridViewFilterCell cell2 = objOwningDataGridView.FilterRow.Cells[memberPosition.X] as DataGridViewFilterCell;
          List<FilterComparisonOperator> comparisonOperator2 = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(cell2.OwningColumn.ValueType);
          int result;
          if (!int.TryParse(objEvent["VLB"], out result) || result >= comparisonOperator2.Count)
            break;
          ResourceHandle comparisionOperatorImage = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(objOwningDataGridView, comparisonOperator2[result]);
          DataGridViewFilterCell.DataGridViewFilterControl filterControlObject = cell2.DataGridViewFilterControlObject;
          filterControlObject.SetOperator((object) comparisonOperator2[result], comparisionOperatorImage);
          filterControlObject.FireFilterChanged(false);
          break;
        case "AddGroup":
          string str2 = objEvent["N"];
          if (string.IsNullOrEmpty(str2))
            break;
          objOwningDataGridView.InsertGroupingColumn(string.Empty, str2);
          objOwningDataGridView.OnGroupingChanged(DataGridViewGroupingAction.Add, str2);
          break;
      }
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Mobile DataGridView";

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal override string ConvertToString() => string.Empty;

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal override void ConvertFromString(List<string> objVisualTemplateValues)
    {
    }

    /// <summary>Gets the constroctor arguments. (For TypeContevert)</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object[] GetConsturctorArguments() => new object[1];

    /// <summary>Gets the constroctor types. (For TypeContevert)</summary>
    public override Type[] GetConstructorTypes() => new Type[1];
  }
}
