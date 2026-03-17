using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(false)]
public class QuickAccessToolBar : UserControl
{
	private RibbonBar mobjOwnerRibbonBar;

	private static readonly SerializableEvent DropDownButtonClickEvent;

	[NonSerialized]
	private IContainer components;

	private PictureBox mobjLeftPictureBox;

	private QuickAccessDropDownButton mobjQuickAccessDropDownButton;

	private PictureBox mobjRightPictureBox;

	private QuickAccessToolStrip mobjQuickAccessToolStrip;

	private ContextMenuStrip mobjQuickAccessContextMenuStrip;

	private EventHandler DropDownButtonClickHandler => (EventHandler)GetHandler(DropDownButtonClickEvent);

	public ToolStripItemCollection Items => mobjQuickAccessToolStrip.Items;

	[DefaultValue(true)]
	public bool ShowContextMenuButton
	{
		get
		{
			return mobjQuickAccessDropDownButton.Visible;
		}
		set
		{
			mobjQuickAccessDropDownButton.Visible = value;
		}
	}

	public ContextMenuStrip QuickAccessContextMenuStrip => mobjQuickAccessContextMenuStrip;

	public event EventHandler DropDownButtonClick
	{
		add
		{
			AddCriticalHandler(DropDownButtonClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(DropDownButtonClickEvent, value);
		}
	}

	public QuickAccessToolBar(RibbonBar objOwnerRibbonBar)
	{
		mobjOwnerRibbonBar = objOwnerRibbonBar;
		InitializeComponent();
		InitPictures(blnFlatLeftPicture: false);
	}

	private void mobjQuickAccessDropDownButton_Click(object sender, EventArgs e)
	{
		if (DropDownButtonClickHandler != null)
		{
			DropDownButtonClickHandler(this, EventArgs.Empty);
		}
		mobjQuickAccessContextMenuStrip.Show(mobjQuickAccessDropDownButton, new Point(1, 1), ToolStripDropDownDirection.BelowLeft);
	}

	internal void InitPictures(bool blnFlatLeftPicture)
	{
		RibbonBarSkin ribbonBarSkin = SkinFactory.GetSkin(mobjOwnerRibbonBar) as RibbonBarSkin;
		ImageResourceReference imageResourceReference = null;
		if (ribbonBarSkin == null)
		{
			return;
		}
		if (blnFlatLeftPicture)
		{
			if (ribbonBarSkin.QuickAccessToolBarFlatPicture.GetObject(Context) is ImageResourceReference objSkinResource)
			{
				mobjLeftPictureBox.Width = (int)ribbonBarSkin.QuickAccessToolBarFlatPictureWidth.GetObject(Context);
				mobjLeftPictureBox.Image = ribbonBarSkin.GetResourceHandleFromReference(objSkinResource);
			}
			else
			{
				mobjLeftPictureBox.Image = null;
				mobjLeftPictureBox.Width = 0;
			}
		}
		else if (ribbonBarSkin.QuickAccessToolBarLeftPicture.GetObject(Context) is ImageResourceReference objSkinResource2)
		{
			ResourceHandle resourceHandleFromReference = ribbonBarSkin.GetResourceHandleFromReference(objSkinResource2);
			if (!resourceHandleFromReference.Equals(mobjLeftPictureBox.Image))
			{
				mobjLeftPictureBox.Width = (int)ribbonBarSkin.QuickAccessToolBarLeftPictureWidth.GetObject(Context);
				mobjLeftPictureBox.Image = resourceHandleFromReference;
			}
		}
		else
		{
			mobjLeftPictureBox.Image = null;
			mobjLeftPictureBox.Width = 0;
		}
		if (mobjRightPictureBox.Image != null)
		{
			return;
		}
		if (ribbonBarSkin.QuickAccessToolBarRightPicture.GetObject(Context) is ImageResourceReference objSkinResource3)
		{
			ResourceHandle resourceHandleFromReference2 = ribbonBarSkin.GetResourceHandleFromReference(objSkinResource3);
			if (!resourceHandleFromReference2.Equals(mobjRightPictureBox.Image))
			{
				mobjRightPictureBox.Width = (int)ribbonBarSkin.QuickAccessToolBarRightPictureWidth.GetObject(Context);
				mobjRightPictureBox.Image = resourceHandleFromReference2;
			}
		}
		else
		{
			mobjRightPictureBox.Width = 0;
		}
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
		components = new Container();
		mobjLeftPictureBox = new PictureBox();
		mobjQuickAccessDropDownButton = new QuickAccessDropDownButton();
		mobjRightPictureBox = new PictureBox();
		mobjQuickAccessToolStrip = new QuickAccessToolStrip();
		mobjQuickAccessContextMenuStrip = new ContextMenuStrip(components);
		((ISupportInitialize)mobjLeftPictureBox).BeginInit();
		((ISupportInitialize)mobjRightPictureBox).BeginInit();
		SuspendLayout();
		mobjLeftPictureBox.Dock = DockStyle.Left;
		mobjLeftPictureBox.Location = new Point(0, 0);
		mobjLeftPictureBox.Name = "mobjLeftPictureBox";
		mobjLeftPictureBox.Size = new Size(25, 25);
		mobjLeftPictureBox.TabIndex = 0;
		mobjLeftPictureBox.TabStop = false;
		mobjQuickAccessDropDownButton.Dock = DockStyle.Right;
		mobjQuickAccessDropDownButton.Location = new Point(81, 0);
		mobjQuickAccessDropDownButton.Name = "mobjQuickAccessDropDownButton";
		mobjQuickAccessDropDownButton.Size = new Size(15, 25);
		mobjQuickAccessDropDownButton.TabIndex = 1;
		mobjQuickAccessDropDownButton.Click += mobjQuickAccessDropDownButton_Click;
		mobjRightPictureBox.Dock = DockStyle.Right;
		mobjRightPictureBox.Location = new Point(56, 0);
		mobjRightPictureBox.Name = "mobjRightPictureBox";
		mobjRightPictureBox.Size = new Size(25, 25);
		mobjRightPictureBox.TabIndex = 2;
		mobjRightPictureBox.TabStop = false;
		mobjQuickAccessToolStrip.Location = new Point(34, 0);
		mobjQuickAccessToolStrip.Name = "mobjQuickAccessToolStrip";
		mobjQuickAccessToolStrip.Size = new Size(444, 25);
		mobjQuickAccessToolStrip.TabIndex = 3;
		mobjQuickAccessContextMenuStrip.Anchor = AnchorStyles.Left | AnchorStyles.Top;
		mobjQuickAccessContextMenuStrip.BorderWidth = new BorderWidth(1);
		mobjQuickAccessContextMenuStrip.DockPadding.Bottom = 2;
		mobjQuickAccessContextMenuStrip.DockPadding.Left = 1;
		mobjQuickAccessContextMenuStrip.DockPadding.Right = 1;
		mobjQuickAccessContextMenuStrip.DockPadding.Top = 2;
		mobjQuickAccessContextMenuStrip.Name = "mobjQuickAccessContextMenuStrip";
		mobjQuickAccessContextMenuStrip.Size = new Size(100, 25);
		base.Controls.Add(mobjQuickAccessToolStrip);
		base.Controls.Add(mobjRightPictureBox);
		base.Controls.Add(mobjQuickAccessDropDownButton);
		base.Controls.Add(mobjLeftPictureBox);
		base.Size = new Size(106, 25);
		((ISupportInitialize)mobjLeftPictureBox).EndInit();
		((ISupportInitialize)mobjRightPictureBox).EndInit();
		ResumeLayout(blnPerformLayout: false);
	}

	static QuickAccessToolBar()
	{
		DropDownButtonClickEvent = SerializableEvent.Register("DropDownButtonClickEvent", typeof(EventHandler), typeof(QuickAccessToolBar));
	}
}
