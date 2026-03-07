// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
  /// <summary>Summary description for ContextualToolbarSkin</summary>
  [Serializable]
  public class ContextualToolbarSkin : FormSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the contextual toolbar font.</summary>
    /// <value>The contextual toolbar font.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image font button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarFont
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarFont), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarFont), (object) value);
    }

    /// <summary>
    /// Gets or sets the color of the contextual toolbar fore.
    /// </summary>
    /// <value>The color of the contextual toolbar fore.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarForeColor
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarForeColor), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarForeColor), (object) value);
    }

    /// <summary>
    /// Gets or sets the color of the contextual toolbar fore.
    /// </summary>
    /// <value>The color of the contextual toolbar fore.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image backcolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarBackColor
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarBackColor), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarBackColor), (object) value);
    }

    /// <summary>Gets or sets the contextual toolbar dock.</summary>
    /// <value>The contextual toolbar dock.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarDock
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarDock), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarDock), (object) value);
    }

    /// <summary>Gets or sets the contextual toolbar dock.</summary>
    /// <value>The contextual toolbar dock.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarDelete
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarDelete), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarDelete), (object) value);
    }

    /// <summary>Gets or sets the contextual toolbar action.</summary>
    /// <value>The contextual toolbar dock.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarActions
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarActions), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarActions), (object) value);
    }

    /// <summary>Gets or sets the contextual toolbar dock.</summary>
    /// <value>The contextual toolbar dock.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarAnchor
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarAnchor), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarAnchor), (object) value);
    }

    /// <summary>Gets or sets the contextual toolbar visual templates.</summary>
    /// <value>The contextual toolbar dock.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The contextual image forecolor button image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference ContextualToolbarVisualTemplates
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContextualToolbarVisualTemplates), (ImageResourceReference) null);
      set => this.SetValue(nameof (ContextualToolbarVisualTemplates), (object) value);
    }

    /// <summary>Gets or sets the size of the contextual toolbar.</summary>
    /// <value>The size of the contextual toolbar.</value>
    public virtual Size ContextualToolbarSize
    {
      get => this.GetValue<Size>(nameof (ContextualToolbarSize), new Size(150, 38));
      set => this.SetValue(nameof (ContextualToolbarSize), (object) value);
    }

    /// <summary>Gets the contextual toolbar container LTR style.</summary>
    /// <value>The contextual toolbar container LTR style.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets the buttons container style of the contextualtoolbar.")]
    public StyleValue ContextualToolbarContainerLTRStyle => new StyleValue((CommonSkin) this, nameof (ContextualToolbarContainerLTRStyle));

    /// <summary>Gets the contextual toolbar container RTL style.</summary>
    /// <value>The contextual toolbar container RTL style.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets the buttons container style of the contextualtoolbar.")]
    public StyleValue ContextualToolbarContainerRTLStyle => new StyleValue((CommonSkin) this, nameof (ContextualToolbarContainerRTLStyle));

    /// <summary>Gets the contextual toolbar container.</summary>
    /// <value>The contextual toolbar container.</value>
    public BidirectionalSkinValue<StyleValue> ContextualToolbarContainer => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ContextualToolbarContainerLTRStyle, this.ContextualToolbarContainerRTLStyle);

    /// <summary>Gets the contextual toolbar container style.</summary>
    /// <value>The contextual toolbar container.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets a single button style.")]
    public ContextualToolbarSkin.ContextualToolbarButtonSkinValue ContextualToolbarButton => new ContextualToolbarSkin.ContextualToolbarButtonSkinValue((CommonSkin) this, nameof (ContextualToolbarButton));

    /// <summary>Gets the contextual toolbar container style.</summary>
    /// <value>The contextual toolbar container.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets a single button LTR style.")]
    public ContextualToolbarSkin.ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstLTRStyle => new ContextualToolbarSkin.ContextualToolbarButtonSkinValue((CommonSkin) this, nameof (ContextualToolbarButtonFirstLTRStyle));

    /// <summary>Gets the contextual toolbar button first RTL style.</summary>
    /// <value>The contextual toolbar button first RTL style.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets a single button RTL style.")]
    public ContextualToolbarSkin.ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstRTLStyle => new ContextualToolbarSkin.ContextualToolbarButtonSkinValue((CommonSkin) this, nameof (ContextualToolbarButtonFirstRTLStyle));

    /// <summary>Gets the contextual toolbar button first.</summary>
    /// <value>The contextual toolbar button first.</value>
    public BidirectionalSkinValue<ContextualToolbarSkin.ContextualToolbarButtonSkinValue> ContextualToolbarButtonFirst => new BidirectionalSkinValue<ContextualToolbarSkin.ContextualToolbarButtonSkinValue>((Skin) this, this.ContextualToolbarButtonFirstLTRStyle, this.ContextualToolbarButtonFirstRTLStyle);

    /// <summary>Gets the contextual toolbar container style.</summary>
    /// <value>The contextual toolbar container.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets a single button style.")]
    public ContextualToolbarSkin.ContextualToolbarButtonSkinValue ContextualToolbarButtonHover => new ContextualToolbarSkin.ContextualToolbarButtonSkinValue((CommonSkin) this, nameof (ContextualToolbarButtonHover));

    /// <summary>Gets the width of the contextual toolbar button.</summary>
    /// <value>The width of the contextual toolbar button.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int ContextualToolbarButtonWidth => this.ContextualToolbarButton.ContextualToolbarButtonSize.Width;

    /// <summary>Gets the height of the contextual toolbar button.</summary>
    /// <value>The height of the contextual toolbar button.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int ContextualToolbarButtonHeight => this.ContextualToolbarButton.ContextualToolbarButtonSize.Height;

    /// <summary>Gets the width of the contextual toolbar button.</summary>
    /// <value>The width of the contextual toolbar button.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int ContextualToolbarButtonHoverWidth => this.ContextualToolbarButtonHover.ContextualToolbarButtonSize.Width;

    /// <summary>Gets the height of the contextual toolbar button.</summary>
    /// <value>The height of the contextual toolbar button.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int ContextualToolbarButtonHoverHeight => this.ContextualToolbarButtonHover.ContextualToolbarButtonSize.Height;

    /// <summary>
    /// Gets the height of the contextual toolbar button image.
    /// </summary>
    /// <value>The height of the contextual toolbar button image.</value>
    public int ContextualToolbarButtonImageHeight
    {
      get => this.GetValue<int>(nameof (ContextualToolbarButtonImageHeight), this.GetImageHeight(this.ContextualToolbarFont, this.DefaultContextualToolbarButtonImageHeight));
      set => this.SetValue(nameof (ContextualToolbarButtonImageHeight), (object) value);
    }

    /// <summary>
    /// Resets the height of the contextual toolbar button image.
    /// </summary>
    private void ResetContextualToolbarButtonImageHeight() => this.Reset("ContextualToolbarButtonImageHeight");

    /// <summary>
    /// Gets the default height of the contextual toolbar button image.
    /// </summary>
    /// <value>
    /// The default height of the contextual toolbar button image.
    /// </value>
    protected virtual int DefaultContextualToolbarButtonImageHeight => 30;

    /// <summary>
    /// Gets the width of the contextual toolbar button image.
    /// </summary>
    /// <value>The width of the contextual toolbar button image.</value>
    public int ContextualToolbarButtonImageWidth
    {
      get => this.GetValue<int>(nameof (ContextualToolbarButtonImageWidth), this.GetImageHeight(this.ContextualToolbarFont, this.DefaultContextualToolbarButtonImageWidth));
      set => this.SetValue(nameof (ContextualToolbarButtonImageWidth), (object) value);
    }

    /// <summary>
    /// Resets the width of the contextual toolbar button image.
    /// </summary>
    private void ResetContextualToolbarButtonImageWidth() => this.Reset("ContextualToolbarButtonImageWidth");

    /// <summary>
    /// Gets the default width of the contextual toolbar button image.
    /// </summary>
    /// <value>The default width of the contextual toolbar button image.</value>
    protected virtual int DefaultContextualToolbarButtonImageWidth => 30;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ContextualToolbarButtonSkinValue : StyleValue
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
      /// </summary>
      /// <param name="objPropertyOwner">The property owner.</param>
      /// <param name="strPropertyPrefix">The property prefix.</param>
      public ContextualToolbarButtonSkinValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
        : base(objPropertyOwner, strPropertyPrefix)
      {
      }

      /// <summary>Gets or sets the size of the contextual toolbar.</summary>
      /// <value>The size of the contextual toolbar.</value>
      public virtual Size ContextualToolbarButtonSize
      {
        get => this.GetValue<Size>(nameof (ContextualToolbarButtonSize), new Size(32, 32));
        set => this.SetValue(nameof (ContextualToolbarButtonSize), (object) value);
      }
    }
  }
}
