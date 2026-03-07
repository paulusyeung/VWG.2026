// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TreeViewSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>TreeView Skin</summary>
  [ToolboxBitmap(typeof (TreeView), "TreeView.bmp")]
  [Serializable]
  public class TreeViewSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
    /// <returns>true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
    [Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
    [Gizmox.WebGUI.Forms.SRDescription("TreeViewFullRowSelectDescr")]
    [Browsable(false)]
    public virtual bool FullRowSelect
    {
      get => this.GetValue<bool>(nameof (FullRowSelect), this.DefaultFullRowSelect);
      set => this.SetValue(nameof (FullRowSelect), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetFullRowSelect() => this.Reset("FullRowSelect");

    /// <summary>Gets default value</summary>
    protected virtual bool DefaultFullRowSelect => false;

    /// <summary>Gets the tree node normal style.</summary>
    /// <value>The tree node normal style.</value>
    [Category("States")]
    [Description("The tree node normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TreeNodeNormalStyle => new StyleValue((CommonSkin) this, nameof (TreeNodeNormalStyle));

    /// <summary>Gets the tree node selected style.</summary>
    /// <value>The tree node selected style.</value>
    [Category("States")]
    [Description("The tree node selected style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TreeNodeSelectedStyle => new StyleValue((CommonSkin) this, nameof (TreeNodeSelectedStyle), this.TreeNodeNormalStyle);

    /// <summary>Gets the height of the check box image.</summary>
    /// <value>The height of the check box image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxImageHeight => this.GetMaxImageHeight(this.DefaultCheckBoxImageHeight, "CheckBox0.gif", "CheckBox1.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetCheckBoxImageHeight() => this.Reset("CheckBoxImageHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultCheckBoxImageHeight => 13;

    /// <summary>Gets the width of the check box image.</summary>
    /// <value>The width of the check box image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxImageWidth => this.GetMaxImageWidth(this.DefaultCheckBoxImageWidth, "CheckBox0.gif", "CheckBox1.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetCheckBoxImageWidth() => this.Reset("CheckBoxImageWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultCheckBoxImageWidth => 13;
  }
}
