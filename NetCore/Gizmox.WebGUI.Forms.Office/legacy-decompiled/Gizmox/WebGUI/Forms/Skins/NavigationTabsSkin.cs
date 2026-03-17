using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
[SkinDependency(typeof(NavigationTabSkin))]
public class NavigationTabsSkin : TabControlSkin
{
	[Category("Sizes")]
	[Description("The initial start point of the tabs.")]
	[Browsable(false)]
	public override int HeadersOffset
	{
		get
		{
			return base.HeadersOffset;
		}
		set
		{
			base.HeadersOffset = value;
		}
	}

	[Category("States")]
	[Description("The header style.")]
	public StyleValue HeaderStyle => new StyleValue(this, "HeaderStyle");

	public BidirectionalSkinValue<TripleCellFrameStyleValue> ExtraTabButtonNormalStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, ExtraTabButtonNormalLTRStyle, ExtraTabButtonNormalRTLStyle);

	[Category("States")]
	[Description("The Extra Tab Button normal LTR style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonNormalLTRStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonNormalLTRStyle, RightExtraTabButtonNormalLTRStyle, CenterExtraTabButtonNormalLTRStyle);

	[Category("States")]
	[Description("The Extra Tab Button normal RTL style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonNormalRTLStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonNormalRTLStyle, RightExtraTabButtonNormalRTLStyle, CenterExtraTabButtonNormalRTLStyle);

	public BidirectionalSkinValue<TripleCellFrameStyleValue> ExtraTabButtonSelectedStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, ExtraTabButtonSelectedLTRStyle, ExtraTabButtonSelectedRTLStyle);

	[Category("States")]
	[Description("The Extra Tab Button selected style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonSelectedLTRStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonSelectedLTRStyle, RightExtraTabButtonSelectedLTRStyle, CenterExtraTabButtonSelectedLTRStyle);

	[Category("States")]
	[Description("The Extra Tab Button selected style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonSelectedRTLStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonSelectedRTLStyle, RightExtraTabButtonSelectedRTLStyle, CenterExtraTabButtonSelectedRTLStyle);

	public BidirectionalSkinValue<TripleCellFrameStyleValue> ExtraTabButtonHoverStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, ExtraTabButtonHoverLTRStyle, ExtraTabButtonHoverRTLStyle);

	[Category("States")]
	[Description("The Extra Tab Button hover style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonHoverLTRStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonHoverLTRStyle, RightExtraTabButtonHoverLTRStyle, CenterExtraTabButtonHoverLTRStyle);

	[Category("States")]
	[Description("The Extra Tab Button hover style.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual TripleCellFrameStyleValue ExtraTabButtonHoverRTLStyle => new TripleCellFrameStyleValue(LeftExtraTabButtonHoverRTLStyle, RightExtraTabButtonHoverRTLStyle, CenterExtraTabButtonHoverRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonNormalLTRStyle => new StyleValue(this, "RightExtraTabButtonNormalLTRStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonNormalRTLStyle => new StyleValue(this, "RightExtraTabButtonNormalRTLStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> RightExtraTabButtonNormalStyle => new BidirectionalSkinValue<StyleValue>(this, RightExtraTabButtonNormalLTRStyle, RightExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonSelectedLTRStyle => new StyleValue(this, "RightExtraTabButtonSelectedLTRStyle", RightExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonSelectedRTLStyle => new StyleValue(this, "RightExtraTabButtonSelectedRTLStyle", RightExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> RightExtraTabButtonSelectedStyle => new BidirectionalSkinValue<StyleValue>(this, RightExtraTabButtonSelectedLTRStyle, RightExtraTabButtonSelectedRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonHoverLTRStyle => new StyleValue(this, "RightExtraTabButtonHoverLTRStyle", RightExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue RightExtraTabButtonHoverRTLStyle => new StyleValue(this, "RightExtraTabButtonHoverRTLStyle", RightExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> RightExtraTabButtonHoverStyle => new BidirectionalSkinValue<StyleValue>(this, RightExtraTabButtonHoverLTRStyle, RightExtraTabButtonHoverRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonNormalLTRStyle => new StyleValue(this, "LeftExtraTabButtonNormalLTRStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonNormalRTLStyle => new StyleValue(this, "LeftExtraTabButtonNormalRTLStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> LeftExtraTabButtonNormalStyle => new BidirectionalSkinValue<StyleValue>(this, LeftExtraTabButtonNormalLTRStyle, LeftExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonSelectedLTRStyle => new StyleValue(this, "LeftExtraTabButtonSelectedLTRStyle", LeftExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonSelectedRTLStyle => new StyleValue(this, "LeftExtraTabButtonSelectedRTLStyle", LeftExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> LeftExtraTabButtonSelectedStyle => new BidirectionalSkinValue<StyleValue>(this, LeftExtraTabButtonSelectedLTRStyle, LeftExtraTabButtonSelectedLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonHoverLTRStyle => new StyleValue(this, "LeftExtraTabButtonHoverLTRStyle", LeftExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue LeftExtraTabButtonHoverRTLStyle => new StyleValue(this, "LeftExtraTabButtonHoverLTRStyle", LeftExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> LeftExtraTabButtonHoverStyle => new BidirectionalSkinValue<StyleValue>(this, LeftExtraTabButtonHoverLTRStyle, LeftExtraTabButtonHoverRTLStyle);

	[Category("Sizes")]
	[Description("The width of the left tab top in LTR.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int LeftExtraTabButtonWidthLTR
	{
		get
		{
			return GetValue("LeftExtraTabButtonWidthLTR", GetImageWidth(LeftExtraTabButtonNormalLTRStyle.BackgroundImage, DefaultLeftExtraTabButtonWidthRTL));
		}
		set
		{
			SetValue("LeftExtraTabButtonWidthLTR", value);
		}
	}

	protected virtual int DefaultExtraTabButtonTabWidthLTR => 0;

	[Category("Sizes")]
	[Description("The width of the left tab top in RTL.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int LeftExtraTabButtonWidthRTL
	{
		get
		{
			return GetValue("LeftExtraTabButtonWidthRTL", GetImageWidth(LeftExtraTabButtonNormalRTLStyle.BackgroundImage, DefaultLeftExtraTabButtonWidthRTL));
		}
		set
		{
			SetValue("LeftExtraTabButtonWidthRTL", value);
		}
	}

	protected virtual int DefaultLeftExtraTabButtonWidthRTL => 0;

	public BidirectionalSkinProperty<int> LeftExtraTabButtonWidth => new BidirectionalSkinProperty<int>(this, "LeftExtraTabButtonWidthLTR", "LeftExtraTabButtonWidthRTL");

	[Category("Sizes")]
	[Description("The width of the right tab top in LTR.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int RightExtraTabButtonWidthLTR
	{
		get
		{
			return GetValue("RightExtraTabButtonWidthLTR", GetImageWidth(RightExtraTabButtonNormalLTRStyle.BackgroundImage, DefaultRightExtraTabButtonWidthLTR));
		}
		set
		{
			SetValue("RightExtraTabButtonWidthLTR", value);
		}
	}

	protected virtual int DefaultRightExtraTabButtonWidthLTR => 0;

	public BidirectionalSkinProperty<int> RightExtraTabButtonWidth => new BidirectionalSkinProperty<int>(this, "RightExtraTabButtonWidthLTR", "RightExtraTabButtonWidthRTL");

	[Category("Sizes")]
	[Description("The width of the right tab top in RTL.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int RightExtraTabButtonWidthRTL
	{
		get
		{
			return GetValue("RightExtraTabButtonWidthRTL", GetImageWidth(RightExtraTabButtonNormalRTLStyle.BackgroundImage, DefaultRightExtraTabButtonWidthRTL));
		}
		set
		{
			SetValue("RightExtraTabButtonWidthRTL", value);
		}
	}

	protected virtual int DefaultRightExtraTabButtonWidthRTL => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonNormalLTRStyle => new StyleValue(this, "CenterExtraTabButtonNormalLTRStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonNormalRTLStyle => new StyleValue(this, "CenterExtraTabButtonNormalRTLStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> CenterExtraTabButtonNormalStyle => new BidirectionalSkinValue<StyleValue>(this, CenterExtraTabButtonNormalLTRStyle, CenterExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonSelectedLTRStyle => new StyleValue(this, "CenterExtraTabButtonSelectedLTRStyle", CenterExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonSelectedRTLStyle => new StyleValue(this, "CenterExtraTabButtonSelectedRTLStyle", CenterExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> CenterExtraTabButtonSelectedStyle => new BidirectionalSkinValue<StyleValue>(this, CenterExtraTabButtonSelectedLTRStyle, CenterExtraTabButtonSelectedRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonHoverLTRStyle => new StyleValue(this, "CenterExtraTabButtonHoverLTRStyle", CenterExtraTabButtonNormalLTRStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterExtraTabButtonHoverRTLStyle => new StyleValue(this, "CenterExtraTabButtonHoverRTLStyle", CenterExtraTabButtonNormalRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> CenterExtraTabButtonHoverStyle => new BidirectionalSkinValue<StyleValue>(this, CenterExtraTabButtonHoverLTRStyle, CenterExtraTabButtonHoverRTLStyle);

	public BidirectionalSkinProperty<int> CenterExtraTabButtonWidth => new BidirectionalSkinProperty<int>(this, "CenterExtraTabButtonWidthLTR", "CenterExtraTabButtonWidthRTL");

	[Category("Sizes")]
	[Description("The width of the left tab top in LTR.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int CenterExtraTabButtonWidthLTR
	{
		get
		{
			return GetValue("CenterExtraTabButtonWidthLTR", CenterExtraTabButtonNormalLTRStyle.Padding.Horizontal);
		}
		set
		{
			SetValue("CenterExtraTabButtonWidthLTR", value);
		}
	}

	[Category("Sizes")]
	[Description("The width of the left tab top in RTL.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int CenterExtraTabButtonWidthRTL
	{
		get
		{
			return GetValue("CenterExtraTabButtonWidthRTL", CenterExtraTabButtonNormalRTLStyle.Padding.Horizontal);
		}
		set
		{
			SetValue("CenterExtraTabButtonWidthRTL", value);
		}
	}

	private void InitializeComponent()
	{
	}

	internal void ResetLeftExtraTabButtonWidthLTR()
	{
		Reset("LeftExtraTabButtonWidthLTR");
	}

	internal void ResetLeftExtraTabButtonWidthRTL()
	{
		Reset("LeftExtraTabButtonWidthRTL");
	}

	internal void ResetRightExtraTabButtonWidthLTR()
	{
		Reset("RightExtraTabButtonWidthLTR");
	}

	internal void ResetRightExtraTabButtonWidthRTL()
	{
		Reset("RightExtraTabButtonWidthRTL");
	}

	internal void ResetCenterExtraTabButtonWidthLTR()
	{
		Reset("CenterExtraTabButtonWidthLTR");
	}

	internal void ResetCenterExtraTabButtonWidthRTL()
	{
		Reset("CenterExtraTabButtonWidthRTL");
	}
}
