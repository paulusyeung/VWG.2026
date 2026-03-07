// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownMenu
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ToolboxItem(false)]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ToolStripDropDownMenu : ToolStripDropDown
  {
    private static readonly SerializableProperty mblnShowCheckMarginProperty = SerializableProperty.Register(nameof (mblnShowCheckMargin), typeof (bool), typeof (ToolStripDropDownMenu));
    private static readonly SerializableProperty mblnShowImageMarginProperty = SerializableProperty.Register(nameof (mblnShowImageMargin), typeof (bool), typeof (ToolStripDropDownMenu), new SerializablePropertyMetadata((object) true));

    private bool mblnShowCheckMargin
    {
      get => this.GetValue<bool>(ToolStripDropDownMenu.mblnShowCheckMarginProperty, false);
      set => this.SetValue<bool>(ToolStripDropDownMenu.mblnShowCheckMarginProperty, value);
    }

    private bool mblnShowImageMargin
    {
      get => this.GetValue<bool>(ToolStripDropDownMenu.mblnShowImageMarginProperty);
      set => this.SetValue<bool>(ToolStripDropDownMenu.mblnShowImageMarginProperty, value);
    }

    /// <summary>Gets or sets a value indicating how the items of <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> are displayed.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>.</returns>
    [DefaultValue(ToolStripLayoutStyle.Flow)]
    public new ToolStripLayoutStyle LayoutStyle
    {
      get => base.LayoutStyle;
      set => base.LayoutStyle = value;
    }

    /// <summary>Gets or sets a value indicating whether space for a check mark is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary>
    /// <returns>true if the check margin is shown; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRDescription("ToolStripDropDownMenuShowCheckMarginDescr")]
    [SRCategory("CatAppearance")]
    public bool ShowCheckMargin
    {
      get => this.mblnShowCheckMargin;
      set
      {
        if (this.mblnShowCheckMargin == value)
          return;
        this.mblnShowCheckMargin = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether space for an image is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>true if the image margin is shown; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    [SRDescription("ToolStripDropDownMenuShowImageMarginDescr")]
    public bool ShowImageMargin
    {
      get => this.mblnShowImageMargin;
      set
      {
        if (this.mblnShowImageMargin == value)
          return;
        this.mblnShowImageMargin = value;
      }
    }

    /// <summary>Creates the default item.</summary>
    /// <param name="strText">The STR text.</param>
    /// <param name="objImage">The obj image.</param>
    /// <param name="objOnClick">The obj on click.</param>
    /// <returns></returns>
    protected internal override ToolStripItem CreateDefaultItem(
      string strText,
      ResourceHandle objImage,
      EventHandler objOnClick)
    {
      return strText == "-" ? (ToolStripItem) new ToolStripSeparator() : (ToolStripItem) new ToolStripMenuItem(strText, objImage, objOnClick);
    }
  }
}
