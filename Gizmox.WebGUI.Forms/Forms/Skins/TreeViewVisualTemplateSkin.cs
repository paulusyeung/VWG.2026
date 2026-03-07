// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TreeViewVisualTemplateSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class TreeViewVisualTemplateSkin : TreeViewSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the TreeView row style.</summary>
    /// <value>The TreeView row style.</value>
    public virtual StyleValue TreeViewRowStyle => new StyleValue((CommonSkin) this, nameof (TreeViewRowStyle), (StyleValue) null);

    /// <summary>
    /// Gets the TreeView visual template back container style.
    /// </summary>
    /// <value>The TreeView visual template back container style.</value>
    public virtual StyleValue TreeViewVisualTemplateBackContainerStyle => new StyleValue((CommonSkin) this, nameof (TreeViewVisualTemplateBackContainerStyle), (StyleValue) null);

    /// <summary>Gets the TreeView visual template back button style.</summary>
    /// <value>The TreeView visual template back button style.</value>
    public virtual StyleValue TreeViewVisualTemplateBackButtonStyle => new StyleValue((CommonSkin) this, nameof (TreeViewVisualTemplateBackButtonStyle), (StyleValue) null);

    /// <summary>Gets the TreeView visual template back button style.</summary>
    /// <value>The TreeView visual template back button style.</value>
    public virtual StyleValue TreeViewVisualTemplateBackButtonDisabledStyle => new StyleValue((CommonSkin) this, "TreeViewVisualTemplateBackButtonStyle", (StyleValue) null);

    /// <summary>Gets the TreeView visual template back button style.</summary>
    /// <value>The TreeView visual template back button style.</value>
    public virtual Size TreeViewVisualTemplateBackButtonSize
    {
      get => this.GetValue<Size>(nameof (TreeViewVisualTemplateBackButtonSize), new Size(90, this.DefaultTreeViewNodeHeight));
      set => this.SetValue(nameof (TreeViewVisualTemplateBackButtonSize), (object) value);
    }

    /// <summary>
    /// Gets the width of the TreeView visual template back button.
    /// </summary>
    /// <value>The width of the TreeView visual template back button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TreeViewVisualTemplateBackButtonWidth => this.TreeViewVisualTemplateBackButtonSize.Width;

    /// <summary>Gets the TreeView visual tempalte button text.</summary>
    /// <value>The TreeView visual tempalte button text.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference TreeViewVisualTempalteButtonImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeViewVisualTempalteButtonImageRTL), (ImageResourceReference) null);
      set => this.SetValue(nameof (TreeViewVisualTempalteButtonImageRTL), (object) value);
    }

    /// <summary>
    /// Gets or sets the TreeView visual tempalte button image LTR.
    /// </summary>
    /// <value>The TreeView visual tempalte button image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference TreeViewVisualTempalteButtonImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeViewVisualTempalteButtonImageLTR), (ImageResourceReference) null);
      set => this.SetValue(nameof (TreeViewVisualTempalteButtonImageLTR), (object) value);
    }

    /// <summary>Gets the TreeView visual tempalte button image.</summary>
    /// <value>The TreeView visual tempalte button image.</value>
    public BidirectionalSkinProperty<ImageResourceReference> TreeViewVisualTempalteButtonImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "TreeViewVisualTempalteButtonImageLTR", "TreeViewVisualTempalteButtonImageRTL");

    /// <summary>
    /// Gets the height of the TreeView visual template back button.
    /// </summary>
    /// <value>The height of the TreeView visual template back button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TreeViewVisualTemplateBackButtonHeight => this.TreeViewVisualTemplateBackButtonSize.Height;

    /// <summary>Gets or sets the TreeView visual template next LTR.</summary>
    /// <value>The TreeView visual template next LTR.</value>
    public virtual ImageResourceReference TreeViewVisualTemplateNextLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeViewVisualTemplateNextLTR), (ImageResourceReference) null);
      set => this.SetValue(nameof (TreeViewVisualTemplateNextLTR), (object) value);
    }

    /// <summary>Gets or sets the TreeView visual template next RTL.</summary>
    /// <value>The TreeView visual template next RTL.</value>
    public virtual ImageResourceReference TreeViewVisualTemplateNextRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeViewVisualTemplateNextRTL), (ImageResourceReference) null);
      set => this.SetValue(nameof (TreeViewVisualTemplateNextRTL), (object) value);
    }

    /// <summary>Gets the TreeView visual template next.</summary>
    /// <value>The TreeView visual template next.</value>
    public BidirectionalSkinProperty<ImageResourceReference> TreeViewVisualTemplateNext => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "TreeViewVisualTemplateNextLTR", "TreeViewVisualTemplateNextRTL");

    /// <summary>Gets or sets the TreeView visual template next witdh.</summary>
    /// <value>The TreeView visual template next witdh.</value>
    public virtual int TreeViewVisualTemplateNextWidth
    {
      get => this.GetValue<int>(nameof (TreeViewVisualTemplateNextWidth), this.GetImageWidth(this.TreeViewVisualTemplateNextLTR, this.DefaultTreeViewNodeNextWidth));
      set => this.SetValue(nameof (TreeViewVisualTemplateNextWidth), (object) value);
    }

    /// <summary>
    /// Resets the width of the TreeView visual template next.
    /// </summary>
    private void ResetTreeViewVisualTemplateNextWidth() => this.Reset("TreeViewVisualTemplateNextWidth");

    /// <summary>Gets the default width of the TreeView node next.</summary>
    /// <value>The default width of the TreeView node next.</value>
    public int DefaultTreeViewNodeNextWidth => 19;

    /// <summary>Gets or sets the height of the TreeView node.</summary>
    /// <value>The height of the TreeView node.</value>
    public virtual int TreeViewNodeHeight
    {
      get => this.GetValue<int>(nameof (TreeViewNodeHeight), this.DefaultTreeViewNodeHeight);
      set => this.SetValue(nameof (TreeViewNodeHeight), (object) value);
    }

    /// <summary>Gets the default height of the TreeView node.</summary>
    /// <value>The default height of the TreeView node.</value>
    protected internal virtual int DefaultTreeViewNodeHeight => 32;

    /// <summary>Resets the height of the TreeView node.</summary>
    private void ResetTreeViewNodeHeight() => this.Reset("TreeViewNodeHeight");
  }
}
