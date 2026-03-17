using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Summary description for ExpandableGroupBoxSkin
/// </summary>   
public class ExpandableGroupBoxSkin : GroupBoxSkin
{
	/// <summary>
	/// Gets the header drop-down image focused style.
	/// </summary>
	[Category("Appearance")]
	[Description("Header drop-down image focused style.")]
	public virtual StyleValue HeaderDropDownImageFocusedStyle => new StyleValue(this, "HeaderDropDownImageFocusedStyle");

	/// <summary>
	/// Gets the header drop-down expanded image style.
	/// </summary>
	[Category("Appearance")]
	[Description("Header drop-down expanded image style.")]
	public virtual StyleValue HeaderDropDownImageStyle => new StyleValue(this, "HeaderDropDownImageStyle");

	/// <summary>
	/// Gets the width of the header drop-downd image.
	/// </summary>
	/// <value>
	/// The width of the drop-down image.
	/// </value>
	[Category("Sizes")]
	[Description("The width of the header drop-down image.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual int DropDownImageWidth => GetImageWidth(HeaderDropDownImageStyle.BackgroundImage) + HeaderDropDownImageStyle.Padding.Horizontal;

	/// <summary>
	/// Gets or sets the text-image padding.
	/// </summary>
	/// <value>
	/// The text-image padding.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual int TextImagePadding => HeaderDropDownImageFocusedStyle.Padding.Left;

	/// <summary>
	/// Gets the height of the header.
	/// </summary>
	/// <value>
	/// The height of the header.
	/// </value>
	[Category("Sizes")]
	[Description("The height of the header.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual int HeaderHeight => TopFrameHeight;

	/// <summary>
	/// Gets or sets the expanded drop-down image.
	/// </summary>
	/// <value>
	/// The expanded drop-down image.
	/// </value>
	[Description("The drop-down image image in Expanded state.")]
	[Category("Images")]
	public ImageResourceReference ExpandedDropDownImage
	{
		get
		{
			return GetValue("ExpandedDropDownImage", new ImageResourceReference(typeof(ExpandableGroupBoxSkin), "DropDown0.gif"));
		}
		set
		{
			SetValue("ExpandedDropDownImage", value);
		}
	}

	/// <summary>
	/// Gets or sets the collapsed drop-down image.
	/// </summary>
	/// <value>
	/// The collapsed drop-down image.
	/// </value>
	[Description("The drop-down image image in Collapsed state.")]
	[Category("Images")]
	public ImageResourceReference CollapsedDropDownImage
	{
		get
		{
			return GetValue("CollapsedDropDownImage", new ImageResourceReference(typeof(ExpandableGroupBoxSkin), "DropDown1.gif"));
		}
		set
		{
			SetValue("CollapsedDropDownImage", value);
		}
	}

	/// <summary>
	/// Gets the hover groupbox style.
	/// </summary>
	/// <value>The hover groupbox style.</value>
	[Category("States")]
	[Description("The hover groupbox style.")]
	public virtual HeaderedFrameStyleValue HoverStyle => new HeaderedFrameStyleValue(LeftBottomHoverStyle, LeftHoverStyle, LeftTopHoverStyle, TopHoverStyle, RightTopHoverStyle, RightHoverStyle, RightBottomHoverStyle, BottomHoverStyle, CenterHoverStyle, HeaderLeftHoverStyle, HeaderCenterHoverStyle, HeaderRightHoverStyle);

	/// <summary>
	/// Gets the left bottom hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftBottomHoverStyle => new FramePartStyleValue(this, "LeftBottomHoverStyle", base.NormalStyle.LeftBottomStyle);

	/// <summary>
	/// Gets the left hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftHoverStyle => new FramePartStyleValue(this, "LeftHoverStyle", base.NormalStyle.LeftStyle);

	/// <summary>
	/// Gets the left top hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftTopHoverStyle => new FramePartStyleValue(this, "LeftTopHoverStyle", base.NormalStyle.LeftTopStyle);

	/// <summary>
	/// Gets the top hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue TopHoverStyle => new FramePartStyleValue(this, "TopHoverStyle", base.NormalStyle.TopStyle);

	/// <summary>
	/// Gets the right top hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightTopHoverStyle => new FramePartStyleValue(this, "RightTopHoverStyle", base.NormalStyle.RightTopStyle);

	/// <summary>
	/// Gets the right hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightHoverStyle => new FramePartStyleValue(this, "RightHoverStyle", base.NormalStyle.RightStyle);

	/// <summary>
	/// Gets the right bottom hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightBottomHoverStyle => new FramePartStyleValue(this, "RightBottomHoverStyle", base.NormalStyle.RightBottomStyle);

	/// <summary>
	/// Gets the bottom hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue BottomHoverStyle => new FramePartStyleValue(this, "BottomHoverStyle", base.NormalStyle.BottomStyle);

	/// <summary>
	/// Gets the center hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterHoverStyle => new StyleValue(this, "CenterHoverStyle", base.NormalStyle.CenterStyle);

	/// <summary>
	/// Gets the header left hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderLeftHoverStyle => new StyleValue(this, "HeaderLeftHoverStyle", base.NormalStyle.HeaderLeftStyle);

	/// <summary>
	/// Gets the header center hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderCenterHoverStyle => new StyleValue(this, "HeaderCenterHoverStyle", base.NormalStyle.HeaderCenterStyle);

	/// <summary>
	/// Gets the header right hover style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderRightHoverStyle => new StyleValue(this, "HeaderRightHoverStyle", base.NormalStyle.HeaderRightStyle);

	/// <summary>
	/// Gets the pressed groupbox style.
	/// </summary>
	/// <value>The pressed groupbox style.</value>
	[Category("States")]
	[Description("The pressed groupbox style.")]
	public virtual HeaderedFrameStyleValue PressedStyle => new HeaderedFrameStyleValue(LeftBottomPressedStyle, LeftPressedStyle, LeftTopPressedStyle, TopPressedStyle, RightTopPressedStyle, RightPressedStyle, RightBottomPressedStyle, BottomPressedStyle, CenterPressedStyle, HeaderLeftPressedStyle, HeaderCenterPressedStyle, HeaderRightPressedStyle);

	/// <summary>
	/// Gets the left bottom pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftBottomPressedStyle => new FramePartStyleValue(this, "LeftBottomPressedStyle", base.NormalStyle.LeftBottomStyle);

	/// <summary>
	/// Gets the left pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftPressedStyle => new FramePartStyleValue(this, "LeftPressedStyle", base.NormalStyle.LeftStyle);

	/// <summary>
	/// Gets the left top pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftTopPressedStyle => new FramePartStyleValue(this, "LeftTopPressedStyle", base.NormalStyle.LeftTopStyle);

	/// <summary>
	/// Gets the top pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue TopPressedStyle => new FramePartStyleValue(this, "TopPressedStyle", base.NormalStyle.TopStyle);

	/// <summary>
	/// Gets the right top pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightTopPressedStyle => new FramePartStyleValue(this, "RightTopPressedStyle", base.NormalStyle.RightTopStyle);

	/// <summary>
	/// Gets the right pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightPressedStyle => new FramePartStyleValue(this, "RightPressedStyle", base.NormalStyle.RightStyle);

	/// <summary>
	/// Gets the right bottom pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightBottomPressedStyle => new FramePartStyleValue(this, "RightBottomPressedStyle", base.NormalStyle.RightBottomStyle);

	/// <summary>
	/// Gets the bottom pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue BottomPressedStyle => new FramePartStyleValue(this, "BottomPressedStyle", base.NormalStyle.BottomStyle);

	/// <summary>
	/// Gets the center pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterPressedStyle => new StyleValue(this, "CenterPressedStyle", base.NormalStyle.CenterStyle);

	/// <summary>
	/// Gets the header left pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderLeftPressedStyle => new StyleValue(this, "HeaderLeftPressedStyle", base.NormalStyle.HeaderLeftStyle);

	/// <summary>
	/// Gets the header center pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderCenterPressedStyle => new StyleValue(this, "HeaderCenterPressedStyle", base.NormalStyle.HeaderCenterStyle);

	/// <summary>
	/// Gets the header right pressed style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderRightPressedStyle => new StyleValue(this, "HeaderRightPressedStyle", base.NormalStyle.HeaderRightStyle);

	/// <summary>
	/// Gets the focused groupbox style.
	/// </summary>
	/// <value>The focused groupbox style.</value>
	[Category("States")]
	[Description("The focused groupbox style.")]
	public virtual HeaderedFrameStyleValue FocusedStyle => new HeaderedFrameStyleValue(LeftBottomFocusedStyle, LeftFocusedStyle, LeftTopFocusedStyle, TopFocusedStyle, RightTopFocusedStyle, RightFocusedStyle, RightBottomFocusedStyle, BottomFocusedStyle, CenterFocusedStyle, HeaderLeftFocusedStyle, HeaderCenterFocusedStyle, HeaderRightFocusedStyle);

	/// <summary>
	/// Gets the left bottom focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftBottomFocusedStyle => new FramePartStyleValue(this, "LeftBottomFocusedStyle", base.NormalStyle.LeftBottomStyle);

	/// <summary>
	/// Gets the left focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftFocusedStyle => new FramePartStyleValue(this, "LeftFocusedStyle", base.NormalStyle.LeftStyle);

	/// <summary>
	/// Gets the left top focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue LeftTopFocusedStyle => new FramePartStyleValue(this, "LeftTopFocusedStyle", base.NormalStyle.LeftTopStyle);

	/// <summary>
	/// Gets the top focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue TopFocusedStyle => new FramePartStyleValue(this, "TopFocusedStyle", base.NormalStyle.TopStyle);

	/// <summary>
	/// Gets the right top focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightTopFocusedStyle => new FramePartStyleValue(this, "RightTopFocusedStyle", base.NormalStyle.RightTopStyle);

	/// <summary>
	/// Gets the right focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightFocusedStyle => new FramePartStyleValue(this, "RightFocusedStyle", base.NormalStyle.RightStyle);

	/// <summary>
	/// Gets the right bottom focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue RightBottomFocusedStyle => new FramePartStyleValue(this, "RightBottomFocusedStyle", base.NormalStyle.RightBottomStyle);

	/// <summary>
	/// Gets the bottom focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual FramePartStyleValue BottomFocusedStyle => new FramePartStyleValue(this, "BottomFocusedStyle", base.NormalStyle.BottomStyle);

	/// <summary>
	/// Gets the center focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue CenterFocusedStyle => new StyleValue(this, "CenterFocusedStyle", base.NormalStyle.CenterStyle);

	/// <summary>
	/// Gets the header left focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderLeftFocusedStyle => new StyleValue(this, "HeaderLeftFocusedStyle", base.NormalStyle.HeaderLeftStyle);

	/// <summary>
	/// Gets the header center focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderCenterFocusedStyle => new StyleValue(this, "HeaderCenterFocusedStyle", base.NormalStyle.HeaderCenterStyle);

	/// <summary>
	/// Gets the header right focused style.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual StyleValue HeaderRightFocusedStyle => new StyleValue(this, "HeaderRightFocusedStyle", base.NormalStyle.HeaderRightStyle);

	/// <summary>
	/// Gets the forecolor of the header content in hover state.
	/// </summary>
	/// <value>
	/// The forecolor of the header content in hover state.
	/// </value>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual ForegroundValue HeaderContentHoverForeColor => new ForegroundValue(HeaderCenterHoverStyle.ForeColor);

	/// <summary>
	/// Gets the forecolor of the header content in pressed state.
	/// </summary>
	/// <value>
	/// The forecolor of the header content in pressed state.
	/// </value>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual ForegroundValue HeaderContentPressedForeColor => new ForegroundValue(HeaderCenterPressedStyle.ForeColor);

	/// <summary>
	/// Gets the forecolor of the header content in normal state.
	/// </summary>
	/// <value>
	/// The forecolor of the header content in normal state.
	/// </value>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual ForegroundValue HeaderContentNormalForeColor => new ForegroundValue(HeaderCenterNormalStyle.ForeColor);

	/// <summary>
	/// Gets the forecolor of the header content in focused state.
	/// </summary>
	/// <value>
	/// The forecolor of the header content in focused state.
	/// </value>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual ForegroundValue HeaderContentFocusedForeColor => new ForegroundValue(HeaderCenterFocusedStyle.ForeColor);

	/// <summary>
	/// Gets the header content normal font.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Font HeaderContentNormalFont => HeaderCenterNormalStyle.Font;

	/// <summary>
	/// Gets the header content Hover font.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Font HeaderContentHoverFont => HeaderCenterHoverStyle.Font;

	/// <summary>
	/// Gets the header content Pressed font.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Font HeaderContentPressedFont => HeaderCenterPressedStyle.Font;

	/// <summary>
	/// Gets the header content Focused font.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Font HeaderContentFocusedFont => HeaderCenterFocusedStyle.Font;

	private void InitializeComponent()
	{
	}

	/// <summary>
	/// Resets the expanded drop down image.
	/// </summary>
	private void ResetExpandedDropDownImage()
	{
		Reset("ExpandedDropDownImage");
	}

	/// <summary>
	/// Resets the collapsed drop down image.
	/// </summary>
	private void ResetCollapsedDropDownImage()
	{
		Reset("CollapsedDropDownImage");
	}
}
