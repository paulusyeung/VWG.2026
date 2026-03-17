using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
[SkinContainer(typeof(RibbonBarSkin))]
public class RibbonBarGroupBoxSkin : GroupBoxSkin
{
	[Category("Sizes")]
	[Description("The height of the text frame.")]
	public int TextFrameHeight => GetValue("TextFrameHeight", 15);

	public StyleValue TextFrame => new StyleValue(this, "TextFrame");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int RibbonGroupOpenImageWidth => GetImageWidth(RibbonGroupOpenImage, 0);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference RibbonGroupOpenImage => GetValue("RibbonGroupOpen", new ImageResourceReference(typeof(RibbonBarGroupBoxSkin), "RibbonGroupOpen.gif"));

	private void InitializeComponent()
	{
	}
}
