using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(false)]
[Skin(typeof(RibbonBarStartMenuSkin))]
public class RibbonBarStartMenu : UserControl
{
	[NonSerialized]
	private IContainer components;

	private Panel mobjBottomPanel;

	private ToolStrip mobjBottomToolStrip;

	private StartMenuToolStrip mobjLeftToolStrip;

	private StartMenuToolStrip mobjRightToolStrip;

	internal ToolStrip LeftToolStrip => mobjLeftToolStrip;

	internal ToolStrip RightToolStrip => mobjRightToolStrip;

	internal ToolStrip BottomToolStrip => mobjBottomToolStrip;

	public RibbonBarStartMenu()
	{
		InitializeComponent();
		CustomStyle = "RibbonBarStartMenuSkin";
		base.Height = 400;
		base.Width = 400;
	}

	internal void ShowPopup(Component objComponent)
	{
		CreatePopupForm().ShowPopup(objComponent, DialogAlignment.Below);
	}

	internal Form CreatePopupForm()
	{
		return new Form
		{
			Controls = { (Control)this },
			Size = new Size(base.Width, base.Height)
		};
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		mobjBottomPanel = new Panel();
		mobjBottomToolStrip = new ToolStrip();
		mobjLeftToolStrip = new StartMenuToolStrip();
		mobjRightToolStrip = new StartMenuToolStrip();
		mobjBottomPanel.SuspendLayout();
		SuspendLayout();
		mobjBottomPanel.Controls.Add(mobjBottomToolStrip);
		mobjBottomPanel.Dock = DockStyle.Bottom;
		mobjBottomPanel.Location = new Point(0, 137);
		mobjBottomPanel.Name = "mobjBottomPanel";
		mobjBottomPanel.Size = new Size(164, 25);
		mobjBottomPanel.TabIndex = 0;
		mobjBottomToolStrip.GripStyle = ToolStripGripStyle.Hidden;
		mobjBottomToolStrip.Location = new Point(0, 0);
		mobjBottomToolStrip.Name = "mobjBottomToolStrip";
		mobjBottomToolStrip.Size = new Size(391, 25);
		mobjBottomToolStrip.TabIndex = 0;
		mobjBottomToolStrip.Text = "toolStrip1";
		mobjLeftToolStrip.Dock = DockStyle.Left;
		mobjLeftToolStrip.GripStyle = ToolStripGripStyle.Hidden;
		mobjLeftToolStrip.Location = new Point(168, 130);
		mobjLeftToolStrip.Name = "mobjLeftToolStrip";
		mobjLeftToolStrip.Size = new Size(42, 25);
		mobjLeftToolStrip.TabIndex = 0;
		mobjRightToolStrip.Dock = DockStyle.Fill;
		mobjRightToolStrip.GripStyle = ToolStripGripStyle.Hidden;
		mobjRightToolStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		mobjRightToolStrip.Location = new Point(120, 0);
		mobjRightToolStrip.Name = "mobjRightToolStrip";
		mobjRightToolStrip.Size = new Size(68, 25);
		mobjRightToolStrip.TabIndex = 2;
		base.Controls.Add(mobjRightToolStrip);
		base.Controls.Add(mobjLeftToolStrip);
		base.Controls.Add(mobjBottomPanel);
		mobjBottomPanel.ResumeLayout(blnPerformLayout: false);
		ResumeLayout(blnPerformLayout: false);
	}
}
