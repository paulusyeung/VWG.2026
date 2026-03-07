// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.CommonSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides the highest level of shared resources</summary>
  [SkinDependency(typeof (LoadingSkin))]
  [SkinDependency(typeof (PopupsSkin))]
  [SkinDependency(typeof (TaskBarSkin))]
  [SkinDependency(typeof (ToolTipSkin))]
  [Serializable]
  public class CommonSkin : Skin
  {
    [NonSerialized]
    private Font mobjDefaultFont;
    [NonSerialized]
    private CommonSkin.ArrowsScrollerProperties mobjArrowsScrollerProperties;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin" /> class.
    /// </summary>
    public CommonSkin() => this.mobjArrowsScrollerProperties = new CommonSkin.ArrowsScrollerProperties(this);

    /// <summary>Filters the properties.</summary>
    /// <param name="objPropertyDescriptorCollection">The obj property descriptor collection.</param>
    /// <param name="attributes">The attributes.</param>
    public override PropertyDescriptorCollection FilterProperties(
      PropertyDescriptorCollection objPropertyDescriptorCollection,
      Attribute[] attributes)
    {
      PropertyDescriptorCollection descriptorCollection = base.FilterProperties(objPropertyDescriptorCollection, attributes);
      if (descriptorCollection != null && this.GetType() != typeof (CommonSkin))
      {
        List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
        foreach (PropertyDescriptor propertyDescriptor in descriptorCollection)
        {
          string name = propertyDescriptor.Name;
          if (!(name == "SelectedIndicatorStyle") && !(name == "SelectedIndicatorSize"))
            propertyDescriptorList.Add(propertyDescriptor);
        }
        descriptorCollection = new PropertyDescriptorCollection(propertyDescriptorList.ToArray());
      }
      return descriptorCollection;
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Fonts")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlFontDescr")]
    public virtual Font Font
    {
      get => this.GetAmbientValue<Font>(nameof (Font), this.DefaultFont);
      set => this.SetValue(nameof (Font), (object) value);
    }

    /// <summary>Gets the default font.</summary>
    /// <value>The default font.</value>
    private Font DefaultFont
    {
      get
      {
        if (this.mobjDefaultFont == null)
          this.mobjDefaultFont = new Font("Tahoma", 8.25f);
        return this.mobjDefaultFont;
      }
    }

    /// <summary>Gets the default color of the fore.</summary>
    /// <value>The default color of the fore.</value>
    protected virtual Color DefaultForeColor => Color.Black;

    /// <summary>Resets the font.</summary>
    private void ResetFont() => this.Reset("Font");

    /// <summary>Gets the foreground.</summary>
    /// <value>The foreground.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ForegroundValue Foreground => new ForegroundValue()
    {
      ForeColor = this.ForeColor
    };

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlForeColorDescr")]
    [Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public virtual Color ForeColor
    {
      get => this.GetAmbientValue<Color>(nameof (ForeColor), this.DefaultForeColor);
      set => this.SetValue(nameof (ForeColor), (object) value);
    }

    /// <summary>Gets the loading animation box.</summary>
    /// <value>The loading animation box.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue LoadingAnimationBox => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (LoadingSkin)) is LoadingSkin skin ? skin.LoadingAnimationStyle : (StyleValue) null;

    /// <summary>Gets the loading animation image.</summary>
    /// <value>The loading animation image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageResourceReference LoadingAnimationImage
    {
      get
      {
        if (this.Owner != null)
        {
          StyleValue loadingAnimationBox = this.LoadingAnimationBox;
          if (loadingAnimationBox != null)
            return loadingAnimationBox.BackgroundImage;
        }
        return (ImageResourceReference) null;
      }
    }

    /// <summary>Gets the box shadow popup offset.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string BoxShadowPopupOffset => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (PopupsSkin)) is PopupsSkin skin ? skin.BoxShadowPopupOffset : string.Empty;

    /// <summary>Resets the fore color.</summary>
    private void ResetForeColor() => this.Reset("ForeColor");

    /// <summary>Gets the loading template.</summary>
    /// <value>The loading template.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference LoadingTemplate => new TextResourceReference(typeof (LoadingSkin), "Loading.htm");

    /// <summary>Gets the loading animation.</summary>
    /// <value>The loading animation.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference LoadingAnimationHtml => new TextResourceReference(typeof (LoadingSkin), "LoadingAnimation.htm");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference TaskBarTemplate => new TextResourceReference(typeof (TaskBarSkin), "TaskBarTemplate.htm");

    /// <summary>Gets the web set style function.</summary>
    /// <value>The web set style function.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference WebSetStyleFunction => new TextResourceReference(typeof (CommonSkin), "Common.Web.SetStyle.js");

    /// <summary>Gets the task bar item content class.</summary>
    /// <value>The task bar item content class.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public CssClassMemberReference TaskBarItemContentClass => new CssClassMemberReference(typeof (TaskBarSkin), "TaskBar-ItemContent");

    /// <summary>Gets the task bar item image class.</summary>
    /// <value>The task bar item image class.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public CssClassMemberReference TaskBarItemImageClass => new CssClassMemberReference(typeof (TaskBarSkin), "TaskBar-ItemImage");

    /// <summary>Gets the task bar item label class.</summary>
    /// <value>The task bar item label class.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public CssClassMemberReference TaskBarItemLabelClass => new CssClassMemberReference(typeof (TaskBarSkin), "TaskBar-ItemLabel");

    /// <summary>Gets the modal window style.</summary>
    /// <value>The modal window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue WindowModalMaskStyle => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.WindowModalMaskStyle : (StyleValue) null;

    /// <summary>Gets the dialog window height offset.</summary>
    /// <value>The dialog window height offset.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowHeightOffset => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.TopDialogWindowFrameHeight + skin.BottomDialogWindowFrameHeight : 0;

    /// <summary>Gets the dialog window width offset.</summary>
    /// <value>The dialog window width offset.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowWidthOffset => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.LeftDialogWindowFrameWidth + skin.RightDialogWindowFrameWidth : 0;

    /// <summary>Gets the tool window height offset.</summary>
    /// <value>The tool window height offset.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int ToolWindowHeightOffset => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.TopToolWindowFrameHeight + skin.BottomToolWindowFrameHeight : 0;

    /// <summary>Gets the tool window width offset.</summary>
    /// <value>The tool window width offset.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int ToolWindowWidthOffset => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.LeftToolWindowFrameWidth + skin.RightToolWindowFrameWidth : 0;

    /// <summary>Gets the transparent modal window mask opacity.</summary>
    /// <value>The transparent modal window mask opacity.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpacityValue WindowModalTransparentMaskOpacity => new OpacityValue(1);

    /// <summary>Gets the modal window mask opacity.</summary>
    /// <value>The modal window mask opacity.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpacityValue WindowModalMaskOpacity => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.WindowModalMaskOpacity : (OpacityValue) null;

    /// <summary>Gets the width of the minimized MDI form.</summary>
    /// <value>The width of the minimized MDI form.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MinimizedMdiFormWidth => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.MinimizedMdiFormWidth : 0;

    /// <summary>Gets the height of the minimized MDI form.</summary>
    /// <value>The height of the minimized MDI form.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MinimizedMdiFormHeight => this.Owner != null && SkinFactory.GetSkin(this.Owner, typeof (FormSkin)) is FormSkin skin ? skin.MinimizedMdiFormHeight : 0;

    /// <summary>Gets or sets the layout padding.</summary>
    /// <value>The layout padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Gizmox.WebGUI.Forms.SRDescription("The default layout padding.")]
    public int ButtonImageTextGap
    {
      get => this.GetValue<int>(nameof (ButtonImageTextGap), 2);
      set => this.SetValue(nameof (ButtonImageTextGap), (object) value);
    }

    private void InitializeComponent()
    {
    }

    /// <summary>Gets the size of the image.</summary>
    /// <param name="objFrameStyleValue">The frame style value.</param>
    /// <param name="enmFrameEdge">The frame edge.</param>
    /// <returns></returns>
    protected internal int GetFrameEdgeSize(
      FrameStyleValue objFrameStyleValue,
      CommonSkin.FrameEdge enmFrameEdge)
    {
      int val1_1;
      int val1_2;
      int val2;
      switch (enmFrameEdge)
      {
        case CommonSkin.FrameEdge.Top:
          val1_1 = this.GetImageHeight(objFrameStyleValue.LeftTopStyle.BackgroundImage);
          val1_2 = this.GetImageHeight(objFrameStyleValue.TopStyle.BackgroundImage);
          val2 = this.GetImageHeight(objFrameStyleValue.RightTopStyle.BackgroundImage);
          break;
        case CommonSkin.FrameEdge.Right:
          val1_1 = this.GetImageWidth(objFrameStyleValue.RightTopStyle.BackgroundImage);
          val1_2 = this.GetImageWidth(objFrameStyleValue.RightStyle.BackgroundImage);
          val2 = this.GetImageWidth(objFrameStyleValue.RightBottomStyle.BackgroundImage);
          break;
        case CommonSkin.FrameEdge.Bottom:
          val1_1 = this.GetImageHeight(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
          val1_2 = this.GetImageHeight(objFrameStyleValue.BottomStyle.BackgroundImage);
          val2 = this.GetImageHeight(objFrameStyleValue.RightBottomStyle.BackgroundImage);
          break;
        case CommonSkin.FrameEdge.Left:
          val1_1 = this.GetImageWidth(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
          val1_2 = this.GetImageWidth(objFrameStyleValue.LeftStyle.BackgroundImage);
          val2 = this.GetImageWidth(objFrameStyleValue.LeftTopStyle.BackgroundImage);
          break;
        default:
          return 0;
      }
      return Math.Max(val1_1, Math.Max(val1_2, val2));
    }

    /// <summary>Gets the arrows scroll properties.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual CommonSkin.ArrowsScrollerProperties ArrowsScrollProperties => this.mobjArrowsScrollerProperties;

    /// <summary>Gets the arrow scroller left normal style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerLeftNormalStyle => new StyleValue(this, nameof (ArrowScrollerLeftNormalStyle));

    /// <summary>Gets the arrow scroller left hover style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerLeftHoverStyle => new StyleValue(this, nameof (ArrowScrollerLeftHoverStyle));

    /// <summary>Gets the arrow scroller left pressed style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerLeftPressedStyle => new StyleValue(this, nameof (ArrowScrollerLeftPressedStyle));

    /// <summary>Gets the arrow scroller left disabled style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerLeftDisabledStyle => new StyleValue(this, nameof (ArrowScrollerLeftDisabledStyle));

    /// <summary>Gets the arrow scroller top normal style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerTopNormalStyle => new StyleValue(this, nameof (ArrowScrollerTopNormalStyle));

    /// <summary>Gets the arrow scroller top hover style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerTopHoverStyle => new StyleValue(this, nameof (ArrowScrollerTopHoverStyle));

    /// <summary>Gets the arrow scroller top pressed style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerTopPressedStyle => new StyleValue(this, nameof (ArrowScrollerTopPressedStyle));

    /// <summary>Gets the arrow scroller top disabled style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerTopDisabledStyle => new StyleValue(this, nameof (ArrowScrollerTopDisabledStyle));

    /// <summary>Gets the arrow scroller right normal style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerRightNormalStyle => new StyleValue(this, nameof (ArrowScrollerRightNormalStyle));

    /// <summary>Gets the arrow scroller right hover style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerRightHoverStyle => new StyleValue(this, nameof (ArrowScrollerRightHoverStyle));

    /// <summary>Gets the arrow scroller right pressed style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerRightPressedStyle => new StyleValue(this, nameof (ArrowScrollerRightPressedStyle));

    /// <summary>Gets the arrow scroller right disabled style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerRightDisabledStyle => new StyleValue(this, nameof (ArrowScrollerRightDisabledStyle));

    /// <summary>Gets the arrow scroller bottom normal style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerBottomNormalStyle => new StyleValue(this, nameof (ArrowScrollerBottomNormalStyle));

    /// <summary>Gets the arrow scroller bottom hover style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerBottomHoverStyle => new StyleValue(this, nameof (ArrowScrollerBottomHoverStyle));

    /// <summary>Gets the arrow scroller bottom pressed style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerBottomPressedStyle => new StyleValue(this, nameof (ArrowScrollerBottomPressedStyle));

    /// <summary>Gets the arrow scroller bottom disabled style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ArrowScrollerBottomDisabledStyle => new StyleValue(this, nameof (ArrowScrollerBottomDisabledStyle));

    /// <summary>Gets or sets the horizontal hover speed.</summary>
    /// <value>The horizontal hover speed.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HorizontalHoverSpeed
    {
      get => this.GetValue<int>("ArrowsHorizontalHoverSpeed", 50);
      set => this.SetValue("ArrowsHorizontalHoverSpeed", (object) value);
    }

    /// <summary>Gets or sets the horizontal down speed.</summary>
    /// <value>The horizontal down speed.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HorizontalDownSpeed
    {
      get => this.GetValue<int>("ArrowsHorizontalDownSpeed", 20);
      set => this.SetValue("ArrowsHorizontalDownSpeed", (object) value);
    }

    /// <summary>Gets or sets the vertical hover speed.</summary>
    /// <value>The vertical hover speed.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VerticalHoverSpeed
    {
      get => this.GetValue<int>("ArrowsHorizontalHoverSpeed", 50);
      set => this.SetValue("ArrowsHorizontalHoverSpeed", (object) value);
    }

    /// <summary>Gets or sets the vertical down speed.</summary>
    /// <value>The vertical down speed.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VerticalDownSpeed
    {
      get => this.GetValue<int>("ArrowsHorizontalDownSpeed", 20);
      set => this.SetValue("ArrowsHorizontalDownSpeed", (object) value);
    }

    /// <summary>Gets the arrow style value.</summary>
    /// <param name="strSide">The STR side.</param>
    /// <param name="strStyle">The STR style.</param>
    /// <returns></returns>
    private StyleValue GetArrowStyleValue(string strSide, string strStyle) => new StyleValue(this, string.Format("ArrowScroller{0}{1}Style", (object) strSide, (object) strStyle));

    /// <summary>Gets the arrow thickness.</summary>
    /// <param name="mstrSide">The MSTR side.</param>
    /// <returns></returns>
    private int GetArrowThickness(string mstrSide) => this.GetValue<int>(string.Format("Arrow{0}Thickness", (object) mstrSide), mstrSide == "Left" || mstrSide == "Right" ? this.GetImageWidth(this.GetArrowStyleValue(mstrSide, "Normal").BackgroundImage) : this.GetImageHeight(this.GetArrowStyleValue(mstrSide, "Normal").BackgroundImage));

    /// <summary>Sets the arrow thickness.</summary>
    /// <param name="mstrSide">The MSTR side.</param>
    /// <param name="objValue">The obj value.</param>
    private void SetArrowThickness(string mstrSide, int objValue) => this.SetValue(string.Format("Arrow{0}Thickness", (object) mstrSide), (object) objValue);

    /// <summary>Gets the arrow top thickness.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ArrowTopThickness => this.GetArrowThickness("Top");

    /// <summary>Gets the arrow right thickness.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ArrowRightThickness => this.GetArrowThickness("Right");

    /// <summary>Gets the arrow bottom thickness.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ArrowBottomThickness => this.GetArrowThickness("Bottom");

    /// <summary>Gets the arrow left thickness.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ArrowLeftThickness => this.GetArrowThickness("Left");

    /// <summary>Gets the selected indicator style.</summary>
    /// <value>The selected indicator style.</value>
    [Category("States")]
    [Description("The selected indicator style.")]
    public SelectedIndicatorStyleValue SelectedIndicatorStyle => new SelectedIndicatorStyleValue(this.LeftBottomSelectedIndicatorStyle, this.LeftSelectedIndicatorStyle, this.LeftTopSelectedIndicatorStyle, this.TopSelectedIndicatorStyle, this.RightTopSelectedIndicatorStyle, this.RightSelectedIndicatorStyle, this.RightBottomSelectedIndicatorStyle, this.BottomSelectedIndicatorStyle);

    /// <summary>Gets the left bottom selected indicator style.</summary>
    /// <value>The left bottom selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue LeftBottomSelectedIndicatorStyle => new StyleValue(this, nameof (LeftBottomSelectedIndicatorStyle));

    /// <summary>Resets the left bottom selected indicator style.</summary>
    internal void ResetLeftBottomSelectedIndicatorStyle() => this.Reset("LeftBottomSelectedIndicatorStyle");

    /// <summary>Gets the left selected indicator style.</summary>
    /// <value>The left selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue LeftSelectedIndicatorStyle => new StyleValue(this, nameof (LeftSelectedIndicatorStyle));

    /// <summary>Resets the left selected indicator style.</summary>
    internal void ResetLeftSelectedIndicatorStyle() => this.Reset("LeftSelectedIndicatorStyle");

    /// <summary>Gets the left top selected indicator style.</summary>
    /// <value>The left top selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue LeftTopSelectedIndicatorStyle => new StyleValue(this, nameof (LeftTopSelectedIndicatorStyle));

    /// <summary>Resets the left top selected indicator style.</summary>
    internal void ResetLeftTopSelectedIndicatorStyle() => this.Reset("LeftTopSelectedIndicatorStyle");

    /// <summary>Gets the top selected indicator style.</summary>
    /// <value>The top selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue TopSelectedIndicatorStyle => new StyleValue(this, nameof (TopSelectedIndicatorStyle));

    /// <summary>Resets the top selected indicator style.</summary>
    internal void ResetTopSelectedIndicatorStyle() => this.Reset("TopSelectedIndicatorStyle");

    /// <summary>Gets the right top selected indicator style.</summary>
    /// <value>The right top selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue RightTopSelectedIndicatorStyle => new StyleValue(this, nameof (RightTopSelectedIndicatorStyle));

    /// <summary>Resets the right top selected indicator style.</summary>
    internal void ResetRightTopSelectedIndicatorStyle() => this.Reset("RightTopSelectedIndicatorStyle");

    /// <summary>Gets the right selected indicator style.</summary>
    /// <value>The right selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue RightSelectedIndicatorStyle => new StyleValue(this, nameof (RightSelectedIndicatorStyle));

    /// <summary>Resets the right selected indicator style.</summary>
    internal void ResetRightSelectedIndicatorStyle() => this.Reset("RightSelectedIndicatorStyle");

    /// <summary>Gets the right bottom selected indicator style.</summary>
    /// <value>The right bottom selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue RightBottomSelectedIndicatorStyle => new StyleValue(this, nameof (RightBottomSelectedIndicatorStyle));

    /// <summary>Resets the right bottom selected indicator style.</summary>
    internal void ResetRightBottomSelectedIndicatorStyle() => this.Reset(nameof (ResetRightBottomSelectedIndicatorStyle));

    /// <summary>Gets the bottom selected indicator style.</summary>
    /// <value>The bottom selected indicator style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue BottomSelectedIndicatorStyle => new StyleValue(this, nameof (BottomSelectedIndicatorStyle));

    /// <summary>Resets the bottom selected indicator style.</summary>
    internal void ResetBottomSelectedIndicatorStyle() => this.Reset("BottomSelectedIndicatorStyle");

    /// <summary>Gets the size of the selected indicator.</summary>
    /// <value>The size of the selected indicator.</value>
    [Category("Sizes")]
    [Description("The selected indicator style.")]
    public SelectedIndicatorSizeValue SelectedIndicatorSize => new SelectedIndicatorSizeValue(this);

    /// <summary>
    /// Gets or sets the size of the left bottom selected indicator.
    /// </summary>
    /// <value>The size of the left bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size LeftBottomSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (LeftBottomSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (LeftBottomSelectedIndicatorSize), (object) value);
    }

    /// <summary>
    /// Resets the size of the left bottom selected indicator.
    /// </summary>
    internal void ResetLeftBottomSelectedIndicatorSize() => this.Reset("LeftBottomSelectedIndicatorSize");

    /// <summary>Gets or sets the size of the left selected indicator.</summary>
    /// <value>The size of the left selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size LeftSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (LeftSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (LeftSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the left selected indicator.</summary>
    internal void ResetLeftSelectedIndicatorSize() => this.Reset("LeftSelectedIndicatorSize");

    /// <summary>
    /// Gets or sets the size of the left top selected indicator.
    /// </summary>
    /// <value>The size of the left top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size LeftTopSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (LeftTopSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (LeftTopSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the left top selected indicator.</summary>
    internal void ResetLeftTopSelectedIndicatorSize() => this.Reset("LeftTopSelectedIndicatorSize");

    /// <summary>Gets or sets the size of the top selected indicator.</summary>
    /// <value>The size of the top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size TopSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (TopSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (TopSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the top selected indicator.</summary>
    internal void ResetTopSelectedIndicatorSize() => this.Reset("TopSelectedIndicatorSize");

    /// <summary>
    /// Gets or sets the size of the right top selected indicator.
    /// </summary>
    /// <value>The size of the right top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size RightTopSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (RightTopSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (RightTopSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the right top selected indicator.</summary>
    internal void ResetRightTopSelectedIndicatorSize() => this.Reset("RightTopSelectedIndicatorSize");

    /// <summary>
    /// Gets or sets the size of the right selected indicator.
    /// </summary>
    /// <value>The size of the right selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size RightSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (RightSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (RightSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the right selected indicator.</summary>
    internal void ResetRightSelectedIndicatorSize() => this.Reset("RightSelectedIndicatorSize");

    /// <summary>
    /// Gets or sets the size of the right bottom selected indicator.
    /// </summary>
    /// <value>The size of the right bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size RightBottomSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (RightBottomSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (RightBottomSelectedIndicatorSize), (object) value);
    }

    /// <summary>
    /// Resets the size of the right bottom selected indicator.
    /// </summary>
    internal void ResetRightBottomSelectedIndicatorSize() => this.Reset("RightBottomSelectedIndicatorSize");

    /// <summary>
    /// Gets or sets the size of the bottom selected indicator.
    /// </summary>
    /// <value>The size of the bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size BottomSelectedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (BottomSelectedIndicatorSize), new Size(4, 4));
      set => this.SetValue(nameof (BottomSelectedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the bottom selected indicator.</summary>
    internal void ResetBottomSelectedIndicatorSize() => this.Reset("BottomSelectedIndicatorSize");

    /// <summary>
    /// Gets the height of the right bottom selected indicator.
    /// </summary>
    /// <value>The height of the right bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightBottomSelectedIndicatorHeight => this.RightBottomSelectedIndicatorSize.Height;

    /// <summary>
    /// Gets the width of the right bottom selected indicator.
    /// </summary>
    /// <value>The width of the right bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightBottomSelectedIndicatorWidth => this.RightBottomSelectedIndicatorSize.Width;

    /// <summary>
    /// Gets the height of the left bottom selected indicator.
    /// </summary>
    /// <value>The height of the left bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftBottomSelectedIndicatorHeight => this.LeftBottomSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the left bottom selected indicator.</summary>
    /// <value>The width of the left bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftBottomSelectedIndicatorWidth => this.LeftBottomSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the left top selected indicator.</summary>
    /// <value>The height of the left top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftTopSelectedIndicatorHeight => this.LeftTopSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the left top selected indicator.</summary>
    /// <value>The width of the left top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftTopSelectedIndicatorWidth => this.LeftTopSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the right top selected indicator.</summary>
    /// <value>The height of the right top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightTopSelectedIndicatorHeight => this.RightTopSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the right top selected indicator.</summary>
    /// <value>The width of the right top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightTopSelectedIndicatorWidth => this.RightTopSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the bottom selected indicator.</summary>
    /// <value>The height of the bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int BottomSelectedIndicatorHeight => this.BottomSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the bottom selected indicator.</summary>
    /// <value>The width of the bottom selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int BottomSelectedIndicatorWidth => this.BottomSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the left selected indicator.</summary>
    /// <value>The height of the left selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftSelectedIndicatorHeight => this.LeftSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the left selected indicator.</summary>
    /// <value>The width of the left selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftSelectedIndicatorWidth => this.LeftSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the top selected indicator.</summary>
    /// <value>The height of the top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopSelectedIndicatorHeight => this.TopSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the top selected indicator.</summary>
    /// <value>The width of the top selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopSelectedIndicatorWidth => this.TopSelectedIndicatorSize.Width;

    /// <summary>Gets the height of the right selected indicator.</summary>
    /// <value>The height of the right selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightSelectedIndicatorHeight => this.RightSelectedIndicatorSize.Height;

    /// <summary>Gets the width of the right selected indicator.</summary>
    /// <value>The width of the right selected indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightSelectedIndicatorWidth => this.RightSelectedIndicatorSize.Width;

    /// <summary>Gets the marked indicator style.</summary>
    /// <value>The marked indicator style.</value>
    public StyleValue MarkedIndicatorStyle => new StyleValue(this, nameof (MarkedIndicatorStyle));

    /// <summary>Resets the marked indicator style.</summary>
    internal void ResetMarkedIndicatorStyle() => this.Reset("MarkedIndicatorStyle");

    /// <summary>Gets the height of the marked indicator.</summary>
    /// <value>The height of the marked indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MarkedIndicatorHeight => this.MarkedIndicatorSize.Height;

    /// <summary>Gets the width of the marked indicator.</summary>
    /// <value>The width of the marked indicator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MarkedIndicatorWidth => this.MarkedIndicatorSize.Width;

    /// <summary>Gets or sets the size of the marked indicator.</summary>
    /// <value>The size of the marked indicator.</value>
    public Size MarkedIndicatorSize
    {
      get => this.GetValue<Size>(nameof (MarkedIndicatorSize), new Size(16, 16));
      set => this.SetValue(nameof (MarkedIndicatorSize), (object) value);
    }

    /// <summary>Resets the size of the marked indicator.</summary>
    internal void ResetMarkedIndicatorSize() => this.Reset("MarkedIndicatorSize");

    /// <summary>Specifies one of four Frame edges</summary>
    protected internal enum FrameEdge : byte
    {
      /// <summary>The control's frame Top edge.</summary>
      Top = 1,
      /// <summary>The control's frame Right edge.</summary>
      Right = 2,
      /// <summary>The control's frame Bottom edge.</summary>
      Bottom = 3,
      /// <summary>The control's frame Left edge.</summary>
      Left = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof (ExpandableObjectConverter))]
    public class ArrowsScrollerProperties
    {
      private CommonSkin.ArrowsScrollerProperties.ArrowSideProperties mobjTop;
      private CommonSkin.ArrowsScrollerProperties.ArrowSideProperties mobjRight;
      private CommonSkin.ArrowsScrollerProperties.ArrowSideProperties mobjBottom;
      private CommonSkin.ArrowsScrollerProperties.ArrowSideProperties mobjLeft;
      private CommonSkin mobjCommonSkin;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin.ArrowsScrollerProperties" /> class.
      /// </summary>
      /// <param name="objCommonSkin">The obj common skin.</param>
      public ArrowsScrollerProperties(CommonSkin objCommonSkin)
      {
        this.mobjCommonSkin = objCommonSkin != null ? objCommonSkin : throw new ArgumentNullException(nameof (objCommonSkin));
        this.mobjTop = new CommonSkin.ArrowsScrollerProperties.ArrowSideProperties(objCommonSkin, nameof (Top));
        this.mobjRight = new CommonSkin.ArrowsScrollerProperties.ArrowSideProperties(objCommonSkin, nameof (Right));
        this.mobjBottom = new CommonSkin.ArrowsScrollerProperties.ArrowSideProperties(objCommonSkin, nameof (Bottom));
        this.mobjLeft = new CommonSkin.ArrowsScrollerProperties.ArrowSideProperties(objCommonSkin, nameof (Left));
      }

      /// <summary>Gets the top.</summary>
      public CommonSkin.ArrowsScrollerProperties.ArrowSideProperties Top => this.mobjTop;

      /// <summary>Gets the right.</summary>
      public CommonSkin.ArrowsScrollerProperties.ArrowSideProperties Right => this.mobjRight;

      /// <summary>Gets the bottom.</summary>
      public CommonSkin.ArrowsScrollerProperties.ArrowSideProperties Bottom => this.mobjBottom;

      /// <summary>Gets the left.</summary>
      public CommonSkin.ArrowsScrollerProperties.ArrowSideProperties Left => this.mobjLeft;

      /// <summary>Gets or sets the horizontal hover speed.</summary>
      /// <value>The horizontal hover speed.</value>
      public int HorizontalHoverSpeed
      {
        get => this.mobjCommonSkin.HorizontalHoverSpeed;
        set => this.mobjCommonSkin.HorizontalHoverSpeed = value;
      }

      /// <summary>Gets or sets the horizontal down speed.</summary>
      /// <value>The horizontal down speed.</value>
      public int HorizontalDownSpeed
      {
        get => this.mobjCommonSkin.HorizontalDownSpeed;
        set => this.mobjCommonSkin.HorizontalDownSpeed = value;
      }

      /// <summary>Gets or sets the vertical hover speed.</summary>
      /// <value>The vertical hover speed.</value>
      public int VerticalHoverSpeed
      {
        get => this.mobjCommonSkin.VerticalHoverSpeed;
        set => this.mobjCommonSkin.VerticalHoverSpeed = value;
      }

      /// <summary>Gets or sets the vertical down speed.</summary>
      /// <value>The vertical down speed.</value>
      public int VerticalDownSpeed
      {
        get => this.mobjCommonSkin.VerticalDownSpeed;
        set => this.mobjCommonSkin.VerticalDownSpeed = value;
      }

      /// <summary>
      /// 
      /// </summary>
      [TypeConverter(typeof (ExpandableObjectConverter))]
      public class ArrowSideProperties
      {
        private CommonSkin mobjCommonSkin;
        private string mstrSide;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin.ArrowsScrollerProperties.ArrowSideProperties" /> class.
        /// </summary>
        /// <param name="objCommonSkin">The obj common skin.</param>
        /// <param name="strSide">The STR side.</param>
        public ArrowSideProperties(CommonSkin objCommonSkin, string strSide)
        {
          this.mstrSide = !string.IsNullOrEmpty(strSide) ? strSide : throw new ArgumentException(strSide);
          this.mobjCommonSkin = objCommonSkin;
        }

        /// <summary>Gets or sets the thickness.</summary>
        /// <value>The thickness.</value>
        public int Thickness
        {
          get => this.mobjCommonSkin.GetArrowThickness(this.mstrSide);
          set => this.mobjCommonSkin.SetArrowThickness(this.mstrSide, value);
        }

        /// <summary>Gets the normal style.</summary>
        public StyleValue NormalStyle => this.mobjCommonSkin.GetArrowStyleValue(this.mstrSide, "Normal");

        /// <summary>Gets the hover style.</summary>
        public StyleValue HoverStyle => this.mobjCommonSkin.GetArrowStyleValue(this.mstrSide, "Hover");

        /// <summary>Gets the pressed style.</summary>
        public StyleValue PressedStyle => this.mobjCommonSkin.GetArrowStyleValue(this.mstrSide, "Pressed");

        /// <summary>Gets the disabled style.</summary>
        public StyleValue DisabledStyle => this.mobjCommonSkin.GetArrowStyleValue(this.mstrSide, "Disabled");
      }
    }
  }
}
