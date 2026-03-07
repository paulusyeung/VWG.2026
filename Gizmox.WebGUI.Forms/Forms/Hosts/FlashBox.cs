// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.FlashBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Gateways;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// Flash box control can host Flash movies and embed them in a Visual WebGui
  /// application.
  /// </summary>
  /// <example>
  /// 	<code lang="CS">
  /// 		<![CDATA[
  /// FlashBox objFlashBox = new FlashBox();
  /// objFlashBox.Movie = "../../../../../Resources/Flash/FC_2_3_Column3D.swf";
  /// objFlashBox.AddParameter("FlashVars","&dataURL=../../../../../Resources/Flash/FC_2_3_Column3D.xml");
  /// objFlashBox.AddParameter("quality", "high");
  /// objFlashBox.Dock = DockStyle.Fill;
  /// this.Controls.Add(objFlashBox);]]>
  /// 	</code>
  /// 	<code lang="VB">
  /// 		<![CDATA[
  /// Dim objFlashBox As New FlashBox()
  /// objFlashBox.Movie = "../../../../../Resources/Flash/FC_2_3_Column3D.swf"
  /// objFlashBox.AddParameter("FlashVars", "&dataURL=../../../../../Resources/Flash/FC_2_3_Column3D.xml")
  /// objFlashBox.AddParameter("quality", "high")
  /// objFlashBox.Dock = DockStyle.Fill
  /// Me.Controls.Add(objFlashBox)]]>
  /// 	</code>
  /// </example>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (FlashBox), "FlashBox_45.png")]
  [Serializable]
  public class FlashBox : FlashBoxBase
  {
    /// <summary>Adds the parameter.</summary>
    public new void AddParameter(string strName, string strValue) => this.Parameters[strName] = (object) strValue;

    /// <summary>Adds the parameter.</summary>
    public new void AddParameter(string strName, GatewayHandler objHandler) => this.Parameters[strName] = (object) objHandler;

    /// <summary>Gets the parameter.</summary>
    public new string GetParameter(string strName) => this.Parameters[strName] as string;

    /// <summary>Removes the parameter.</summary>
    public new void RemoveParameter(string strName)
    {
      if (!this.Parameters.Contains(strName))
        return;
      this.Parameters.Remove(strName);
    }

    /// <summary>Clears the parameters.</summary>
    public new void ClearParameters() => this.Parameters.Clear();

    /// <summary>Gets or sets the code.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue("")]
    public string Movie
    {
      get => this.InternalMovie;
      set => this.InternalMovie = value;
    }

    /// <summary>Gets or sets the code base.</summary>
    /// <value>The code base.</value>
    [DefaultValue("")]
    public string CodeBase
    {
      get => this.ObjectCodeBase;
      set => this.ObjectCodeBase = value;
    }
  }
}
