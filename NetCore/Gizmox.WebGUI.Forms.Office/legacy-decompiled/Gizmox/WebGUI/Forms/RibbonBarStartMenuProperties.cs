using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class RibbonBarStartMenuProperties
{
	private RibbonBarStartMenu mobjRibbonBarStartMenu;

	private StartMenuToolStripProperties mobjLeftToolStripProperties;

	private StartMenuToolStripProperties mobjRightToolStripProperties;

	private StartMenuToolStripProperties mobjBottomToolStripProperties;

	public Size StartMenuSize
	{
		get
		{
			return mobjRibbonBarStartMenu.Size;
		}
		set
		{
			mobjRibbonBarStartMenu.Size = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StartMenuToolStripProperties LeftToolStripProperties => mobjLeftToolStripProperties;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StartMenuToolStripProperties RightToolStripProperties => mobjRightToolStripProperties;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StartMenuToolStripProperties BottomToolStripProperties => mobjBottomToolStripProperties;

	public RibbonBarStartMenuProperties(RibbonBarStartMenu objRibbonBarStartMenu)
	{
		mobjRibbonBarStartMenu = objRibbonBarStartMenu;
		mobjLeftToolStripProperties = new StartMenuToolStripProperties(objRibbonBarStartMenu.LeftToolStrip);
		mobjRightToolStripProperties = new StartMenuToolStripProperties(objRibbonBarStartMenu.RightToolStrip);
		mobjBottomToolStripProperties = new StartMenuToolStripProperties(objRibbonBarStartMenu.BottomToolStrip);
	}

	public override string ToString()
	{
		return string.Empty;
	}

	private bool ShouldSerializeStartMenuSize()
	{
		Size size = mobjRibbonBarStartMenu.Size;
		if (size.Height != 400 || size.Width != 400)
		{
			return true;
		}
		return false;
	}
}
