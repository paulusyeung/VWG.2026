using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class StartMenuToolStripProperties
{
	private ToolStrip mobjToolStrip;

	public Size ImageScalingSize
	{
		get
		{
			return mobjToolStrip.ImageScalingSize;
		}
		set
		{
			mobjToolStrip.ImageScalingSize = value;
		}
	}

	[MergableProperty(false)]
	[Category("CatData")]
	[Description("ToolStripItemsDescr")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
	public ToolStripItemCollection Items => mobjToolStrip.Items;

	public StartMenuToolStripProperties(ToolStrip objToolStrip)
	{
		mobjToolStrip = objToolStrip;
	}

	internal bool ShouldSerializeImageScalingSize()
	{
		return ImageScalingSize != mobjToolStrip.SkinImageScalingSize;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
