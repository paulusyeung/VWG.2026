// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HierarchicDataGridView
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [ToolboxItem(false)]
  [Serializable]
  public class HierarchicDataGridView : DataGridView
  {
    private DataGridViewRow objContainingRow;

    /// <summary>
    /// Updates the columns visibility according to the column chooser.
    /// </summary>
    /// <param name="objDialog">The obj dialog.</param>
    internal override void UpdateColumnsVisibility(ColumnChooserDialog objDialog)
    {
      this.UpdateSingleHierarchyColumnsVisibility(this.ContainingRow.RelatedHierarchyInfo, objDialog.ChosenRootColumns);
      this.UpdateChildGridColumnsVisibility(objDialog);
    }

    /// <summary>Gets or sets the containing row.</summary>
    /// <value>The containing row.</value>
    public DataGridViewRow ContainingRow
    {
      get => this.objContainingRow;
      internal set => this.objContainingRow = value;
    }

    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      Padding proxyPropertyValue = this.GetProxyPropertyValue<Padding>("Margin", this.Margin);
      if (!(proxyPropertyValue != this.DefaultMargin))
        return;
      if (proxyPropertyValue.IsAll)
      {
        if (proxyPropertyValue.All == 0)
          return;
        objWriter.WriteAttributeString("MA", proxyPropertyValue.All.ToString());
      }
      else
      {
        objWriter.WriteAttributeString("MT", proxyPropertyValue.Top.ToString());
        int num;
        if (proxyPropertyValue.Right != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          num = proxyPropertyValue.Right;
          string strValue = num.ToString();
          attributeWriter.WriteAttributeString("MR", strValue);
        }
        if (proxyPropertyValue.Bottom != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          num = proxyPropertyValue.Bottom;
          string strValue = num.ToString();
          attributeWriter.WriteAttributeString("MB", strValue);
        }
        if (proxyPropertyValue.Left == 0)
          return;
        IAttributeWriter attributeWriter1 = objWriter;
        num = proxyPropertyValue.Left;
        string strValue1 = num.ToString();
        attributeWriter1.WriteAttributeString("ML", strValue1);
      }
    }
  }
}
