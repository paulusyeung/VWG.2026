// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewGroupingTreeNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class DataGridViewGroupingTreeNode : TreeNode
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingTreeNode" /> class.
    /// </summary>
    /// <param name="strColumnDataPropertyName">The data property name of column represented by node.</param>
    public DataGridViewGroupingTreeNode(string strColumnDataPropertyName)
      : base(strColumnDataPropertyName)
    {
    }

    /// <summary>Renders the node attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderNodeAttributes(IContext objContext, IResponseWriter objWriter)
    {
      base.RenderNodeAttributes(objContext, objWriter);
      if (this.Tag == null || string.IsNullOrEmpty(this.Tag.ToString()))
        return;
      objWriter.WriteAttributeString("N", this.Tag.ToString());
    }
  }
}
