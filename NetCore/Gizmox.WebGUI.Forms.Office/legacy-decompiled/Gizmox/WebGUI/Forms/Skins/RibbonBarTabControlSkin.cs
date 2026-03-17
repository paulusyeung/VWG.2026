using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
[SkinContainer(typeof(RibbonBarSkin))]
public class RibbonBarTabControlSkin : TabControlSkin
{
	protected override int DefaultTabHeight => 23;

	protected override int DefaultLeftFrameWidth => 3;

	protected override int DefaultRightFrameWidth => 3;

	[Category("Styles")]
	[Description("The top tab container style.")]
	public StyleValue TabsHeadersContainerLTRStyle => new StyleValue(this, "TabsHeadersContainerLTRStyle");

	[Category("Styles")]
	[Description("The top tab container style.")]
	public StyleValue TabsHeadersContainerRTLStyle => new StyleValue(this, "TabsHeadersContainerRTLStyle");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BidirectionalSkinValue<StyleValue> TabsHeadersContainerStyle => new BidirectionalSkinValue<StyleValue>(this, TabsHeadersContainerLTRStyle, TabsHeadersContainerRTLStyle);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int PaddingTop => Padding.Top;

	private void InitializeComponent()
	{
	}
}
