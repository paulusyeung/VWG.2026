using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
public class HeaderedPanelSkin : PanelSkin
{
	[Category("States")]
	[Description("The frame button style.")]
	public FrameStyleValue FrameStyle => new FrameStyleValue(LeftBottomFrameStyle, LeftFrameStyle, LeftTopFrameStyle, TopFrameStyle, RightTopFrameStyle, RightFrameStyle, RightBottomFrameStyle, BottomFrameStyle, CenterFrameStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public StyleValue CenterFrameStyle => new StyleValue(this, "CenterFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue LeftFrameStyle => new FramePartStyleValue(this, "LeftFrameStyle");

	[Category("States")]
	[Description("The style of the header.")]
	public StyleValue HeaderStyle => new StyleValue(this, "HeaderStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue TopFrameStyle => new FramePartStyleValue(this, "TopFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue BottomFrameStyle => new FramePartStyleValue(this, "BottomFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue RightFrameStyle => new FramePartStyleValue(this, "RightFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue RightTopFrameStyle => new FramePartStyleValue(this, "RightTopFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue LeftTopFrameStyle => new FramePartStyleValue(this, "LeftTopFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue LeftBottomFrameStyle => new FramePartStyleValue(this, "LeftBottomFrameStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FramePartStyleValue RightBottomFrameStyle => new FramePartStyleValue(this, "RightBottomFrameStyle");

	[Category("Sizes")]
	[Description("The width of the left frame.")]
	public int LeftFrameWidth
	{
		get
		{
			return GetValue("LeftFrameWidth", GetImageWidth(FrameStyle.LeftStyle.BackgroundImage, 0));
		}
		set
		{
			SetValue("LeftFrameWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The width of the right frame.")]
	public int RightFrameWidth
	{
		get
		{
			return GetValue("RightFrameWidth", GetImageWidth(FrameStyle.RightStyle.BackgroundImage, 0));
		}
		set
		{
			SetValue("RightFrameWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The height of the top frame.")]
	public int TopFrameHeight
	{
		get
		{
			return GetValue("TopFrameHeight", 25);
		}
		set
		{
			SetValue("TopFrameHeight", value);
		}
	}

	[Category("Sizes")]
	[Description("The height of the bottom frame.")]
	public int BottomFrameHeight
	{
		get
		{
			return GetValue("BottomFrameHeight", GetImageHeight(FrameStyle.BottomStyle.BackgroundImage, 0));
		}
		set
		{
			SetValue("BottomFrameHeight", value);
		}
	}

	internal void ResetLeftFrameWidth()
	{
		Reset("LeftFrameWidth");
	}

	internal void ResetRightFrameWidth()
	{
		Reset("RightFrameWidth");
	}

	internal void ResetTopFrameHeight()
	{
		Reset("TopFrameHeight");
	}

	internal void ResetBottomFrameHeight()
	{
		Reset("BottomFrameHeight");
	}

	private void InitializeComponent()
	{
	}
}
