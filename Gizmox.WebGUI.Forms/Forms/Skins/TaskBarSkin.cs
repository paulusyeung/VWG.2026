// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TaskBarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides loading customization capabilities</summary>
  [ToolboxBitmap(typeof (ProgressBar))]
  public class TaskBarSkin : CommonSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the task bar item frame.</summary>
    /// <value>The task bar item frame.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference ItemTemplate => new TextResourceReference(typeof (TaskBarSkin), "TaskBarItemTemplate.htm");

    /// <summary>Gets the task bar item style.</summary>
    /// <value>The task bar item style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The taskbar item style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ItemStyle => new StyleValue((CommonSkin) this, nameof (ItemStyle));

    /// <summary>Gets the task bar item content style.</summary>
    /// <value>The task bar item content style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The taskbar item content style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ItemContentStyle => new StyleValue((CommonSkin) this, nameof (ItemContentStyle));

    /// <summary>Gets the task bar item label style.</summary>
    /// <value>The task bar item label style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The taskbar item label style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ItemLabelStyle => new StyleValue((CommonSkin) this, nameof (ItemLabelStyle));

    /// <summary>Gets the task bar item image style.</summary>
    /// <value>The task bar item image style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The taskbar item image style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ItemImageStyle => new StyleValue((CommonSkin) this, nameof (ItemImageStyle));

    /// <summary>Gets the width of the item content.</summary>
    /// <value>The width of the item content.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int ItemContentWidth => this.ItemWidth - (this.ItemContentStyle.Margin.Right + this.ItemContentStyle.Margin.Left);

    /// <summary>Gets or sets the width of the task bar item image.</summary>
    /// <value>The width of the task bar item image.</value>
    [Category("Sizes")]
    [Description("Task bar item height.")]
    public int ItemImageWidth
    {
      get => this.GetValue<int>(nameof (ItemImageWidth), 16);
      set => this.SetValue(nameof (ItemImageWidth), (object) value);
    }

    /// <summary>Gets or sets the height of the task bar item image.</summary>
    /// <value>The height of the task bar item image.</value>
    [Category("Sizes")]
    [Description("Task bar item height.")]
    public int ItemImageHeight
    {
      get => this.GetValue<int>(nameof (ItemImageHeight), 16);
      set => this.SetValue(nameof (ItemImageHeight), (object) value);
    }

    /// <summary>Gets or sets the height of the task bar item.</summary>
    /// <value>The height of the task bar item.</value>
    [Category("Sizes")]
    [Description("Task bar item height.")]
    public int ItemHeight
    {
      get => this.GetValue<int>(nameof (ItemHeight), 28);
      set => this.SetValue(nameof (ItemHeight), (object) value);
    }

    /// <summary>Gets or sets the width of the task bar item.</summary>
    /// <value>The width of the task bar item.</value>
    [Category("Sizes")]
    [Description("Task bar item width.")]
    public int ItemWidth
    {
      get => this.GetValue<int>(nameof (ItemWidth), 158);
      set => this.SetValue(nameof (ItemWidth), (object) value);
    }

    /// <summary>Gets the frame style.</summary>
    /// <value>The frame style.</value>
    [Category("States")]
    [Description("The taskbar frame style.")]
    public FrameStyleValue FrameStyle => new FrameStyleValue(this.LeftBottomFrameStyle, this.LeftFrameStyle, this.LeftTopFrameStyle, this.TopFrameStyle, this.RightTopFrameStyle, this.RightFrameStyle, this.RightBottomFrameStyle, this.BottomFrameStyle, this.CenterFrameStyle);

    /// <summary>Gets the task bar item frame style.</summary>
    /// <value>The task bar item frame style.</value>
    [Category("States")]
    [Description("The taskbar item frame style.")]
    public TripleCellFrameStyleValue ItemFrameNormalStyle => new TripleCellFrameStyleValue(this.ItemLeftFrameNormalStyle, this.ItemRightFrameNormalStyle, this.ItemCenterFrameNormalStyle);

    /// <summary>Gets the task bar item frame style.</summary>
    /// <value>The task bar item frame style.</value>
    [Category("States")]
    [Description("The taskbar item frame style.")]
    public TripleCellFrameStyleValue ItemFrameOverStyle => new TripleCellFrameStyleValue(this.ItemLeftFrameOverStyle, this.ItemRightFrameOverStyle, this.ItemCenterFrameOverStyle);

    /// <summary>Gets the task bar item frame style.</summary>
    /// <value>The task bar item frame style.</value>
    [Category("States")]
    [Description("The taskbar item frame style.")]
    public TripleCellFrameStyleValue ItemFrameDownStyle => new TripleCellFrameStyleValue(this.ItemLeftFrameDownStyle, this.ItemRightFrameDownStyle, this.ItemCenterFrameDownStyle);

    /// <summary>Gets the default width of the left frame.</summary>
    /// <value>The default width of the left frame.</value>
    protected virtual int DefaultLeftFrameWidth => 0;

    /// <summary>Gets the default height of the bottom frame.</summary>
    /// <value>The default height of the bottom frame.</value>
    protected virtual int DefaultBottomFrameHeight => 0;

    /// <summary>Gets the default width of the right frame.</summary>
    /// <value>The default width of the right frame.</value>
    protected virtual int DefaultRightFrameWidth => 0;

    /// <summary>Gets the default height of the top frame.</summary>
    /// <value>The default height of the top frame.</value>
    protected virtual int DefaultTopFrameHeight => 0;

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightFrameWidth => this.GetImageWidth(this.FrameStyle.RightStyle.BackgroundImage, this.DefaultRightFrameWidth);

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TopFrameHeight => this.GetImageHeight(this.FrameStyle.TopStyle.BackgroundImage, this.DefaultTopFrameHeight);

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int BottomFrameHeight => this.GetImageHeight(this.FrameStyle.BottomStyle.BackgroundImage, this.DefaultBottomFrameHeight);

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftFrameWidth => this.GetImageWidth(this.FrameStyle.LeftStyle.BackgroundImage, this.DefaultLeftFrameWidth);

    /// <summary>Gets the center frame style.</summary>
    /// <value>The center frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterFrameStyle => new StyleValue((CommonSkin) this, nameof (CenterFrameStyle));

    /// <summary>Gets the left frame style.</summary>
    /// <value>The left frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftFrameStyle));

    /// <summary>Gets the top frame style.</summary>
    /// <value>The top frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopFrameStyle));

    /// <summary>Gets the bottom frame style.</summary>
    /// <value>The bottom frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomFrameStyle));

    /// <summary>Gets the right frame style.</summary>
    /// <value>The right frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightFrameStyle));

    /// <summary>Gets the right top frame style.</summary>
    /// <value>The right top frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopFrameStyle));

    /// <summary>Gets the left top frame style.</summary>
    /// <value>The left top frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopFrameStyle));

    /// <summary>Gets the left bottom frame style.</summary>
    /// <value>The left bottom frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomFrameStyle));

    /// <summary>Gets the right bottom frame style.</summary>
    /// <value>The right bottom frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomFrameStyle));

    /// <summary>Gets the default width of the item left frame.</summary>
    /// <value>The default width of the item left frame.</value>
    protected virtual int DefaultItemLeftFrameWidth => 0;

    /// <summary>Gets the default width of the item right frame.</summary>
    /// <value>The default width of the item right frame.</value>
    protected virtual int DefaultItemRightFrameWidth => 0;

    /// <summary>Gets or sets the width of the item right frame.</summary>
    /// <value>The width of the item right frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ItemRightFrameWidth => this.GetImageWidth(this.ItemFrameNormalStyle.RightStyle.BackgroundImage, this.DefaultItemRightFrameWidth);

    /// <summary>Gets or sets the width of the item left frame.</summary>
    /// <value>The width of the item left frame.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ItemLeftFrameWidth => this.GetImageWidth(this.ItemFrameNormalStyle.LeftStyle.BackgroundImage, this.DefaultItemLeftFrameWidth);

    /// <summary>Gets the item center frame normal style.</summary>
    /// <value>The item center frame normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemCenterFrameNormalStyle => new StyleValue((CommonSkin) this, nameof (ItemCenterFrameNormalStyle));

    /// <summary>Gets the item center frame over style.</summary>
    /// <value>The item center frame over style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemCenterFrameOverStyle => new StyleValue((CommonSkin) this, nameof (ItemCenterFrameOverStyle));

    /// <summary>Gets the item center frame down style.</summary>
    /// <value>The item center frame down style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemCenterFrameDownStyle => new StyleValue((CommonSkin) this, nameof (ItemCenterFrameDownStyle));

    /// <summary>Gets the item left frame normal style.</summary>
    /// <value>The item left frame normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemLeftFrameNormalStyle => new StyleValue((CommonSkin) this, nameof (ItemLeftFrameNormalStyle));

    /// <summary>Gets the item left frame over style.</summary>
    /// <value>The item left frame over style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemLeftFrameOverStyle => new StyleValue((CommonSkin) this, nameof (ItemLeftFrameOverStyle));

    /// <summary>Gets the item left frame down style.</summary>
    /// <value>The item left frame down style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemLeftFrameDownStyle => new StyleValue((CommonSkin) this, nameof (ItemLeftFrameDownStyle));

    /// <summary>Gets the item right frame normal style.</summary>
    /// <value>The item right frame normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemRightFrameNormalStyle => new StyleValue((CommonSkin) this, nameof (ItemRightFrameNormalStyle));

    /// <summary>Gets the item right frame over style.</summary>
    /// <value>The item right frame over style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemRightFrameOverStyle => new StyleValue((CommonSkin) this, nameof (ItemRightFrameOverStyle));

    /// <summary>Gets the item right frame down style.</summary>
    /// <value>The item right frame down style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue ItemRightFrameDownStyle => new StyleValue((CommonSkin) this, nameof (ItemRightFrameDownStyle));

    /// <summary>Gets the bottom frame display style.</summary>
    /// <value>The bottom frame display style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string BottomFrameDisplayStyle => this.BottomFrameHeight != 0 ? "" : "display:none;";
  }
}
