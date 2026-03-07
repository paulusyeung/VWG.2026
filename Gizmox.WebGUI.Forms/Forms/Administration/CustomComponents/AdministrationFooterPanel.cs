// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationFooterPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Browsable(false)]
  [Serializable]
  public class AdministrationFooterPanel : Panel
  {
    /// <summary>The mobj labels</summary>
    private List<Label> mobjLabels;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationFooterPanel" /> class.
    /// </summary>
    public AdministrationFooterPanel() => this.mobjLabels = new List<Label>();

    /// <summary>Sets the labels.</summary>
    /// <param name="objDatas">The object datas.</param>
    public void SetLabels(List<StatusData> objDatas)
    {
      if (objDatas != null)
      {
        while (objDatas.Count > this.mobjLabels.Count)
        {
          Label objValue = (Label) new AdministrationFooterPanel.StatusLabel();
          this.mobjLabels.Insert(0, objValue);
          this.Controls.Add((Control) objValue);
        }
        int index1 = 0;
        foreach (StatusData objData in objDatas)
        {
          this.UpdateLabel(objData, this.mobjLabels[index1]);
          ++index1;
        }
        for (int index2 = index1; index2 < this.mobjLabels.Count; ++index2)
          this.mobjLabels[index2].Visible = false;
      }
      else
      {
        foreach (Control mobjLabel in this.mobjLabels)
          mobjLabel.Visible = false;
      }
    }

    /// <summary>Updates the label.</summary>
    /// <param name="objData">The object data.</param>
    /// <param name="objLabel">The label.</param>
    private void UpdateLabel(StatusData objData, Label objLabel)
    {
      objLabel.Visible = true;
      objLabel.Text = objData.Text;
      Font font = objData.Font;
      if (font != null)
        objLabel.Font = font;
      else
        objLabel.Font = this.DefaultControlFont;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class StatusLabel : Label
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationFooterPanel.StatusLabel" /> class.
      /// </summary>
      public StatusLabel()
      {
        this.AutoSize = true;
        this.TextAlign = ContentAlignment.MiddleCenter;
        this.Dock = DockStyle.Left;
      }
    }
  }
}
