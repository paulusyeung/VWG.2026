using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
[ToolboxBitmap(typeof(ToolBar))]
[SkinDependency(typeof(RibbonBarButtonSkin))]
[SkinDependency(typeof(RibbonBarGroupBoxSkin))]
[SkinDependency(typeof(RibbonBarTabControlSkin))]
[SkinDependency(typeof(RibbonBarCheckBoxSkin))]
[SkinDependency(typeof(RibbonBarComboBoxSkin))]
[SkinDependency(typeof(RibbonBarToolBarButtonSkin))]
[SkinDependency(typeof(RibbonBarTextBoxSkin))]
[SkinDependency(typeof(RibbonBarPageSkin))]
[SkinDependency(typeof(RibbonBarFlowSkin))]
[SkinDependency(typeof(RibbonBarDropDownButtonSkin))]
[SkinDependency(typeof(QuickAccessDropDownButtonSkin))]
[SkinDependency(typeof(QuickAccessToolStripSkin))]
[SkinDependency(typeof(RibbonBarStartButtonSkin))]
[SkinDependency(typeof(RibbonBarStartMenuSkin))]
[SkinDependency(typeof(StartMenuToolStripSkin))]
[SkinDependency(typeof(RibbonBarTabPageSkin))]
public class RibbonBarSkin : UserControlSkin
{
	public BidirectionalSkinValue<ImageResourceReference> QuickAccessToolBarLeftPicture => new BidirectionalSkinValue<ImageResourceReference>(this, QuickAccessToolBarLeftPictureLTR, QuickAccessToolBarLeftPictureRTL);

	public BidirectionalSkinValue<ImageResourceReference> QuickAccessToolBarRightPicture => new BidirectionalSkinValue<ImageResourceReference>(this, QuickAccessToolBarRightPictureLTR, QuickAccessToolBarRightPictureRTL);

	public BidirectionalSkinValue<ImageResourceReference> QuickAccessToolBarFlatPicture => new BidirectionalSkinValue<ImageResourceReference>(this, QuickAccessToolBarFlatPictureLTR, QuickAccessToolBarFlatPictureRTL);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public BidirectionalSkinValue<int> QuickAccessToolBarLeftPictureWidth => new BidirectionalSkinValue<int>(this, QuickAccessToolBarLeftPictureLTRWidth, QuickAccessToolBarLeftPictureRTLWidth);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public BidirectionalSkinValue<int> QuickAccessToolBarRightPictureWidth => new BidirectionalSkinValue<int>(this, QuickAccessToolBarRightPictureLTRWidth, QuickAccessToolBarRightPictureRTLWidth);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public BidirectionalSkinValue<int> QuickAccessToolBarFlatPictureWidth => new BidirectionalSkinValue<int>(this, QuickAccessToolBarFlatPictureLTRWidth, QuickAccessToolBarFlatPictureRTLWidth);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarLeftPictureRTL
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarLeftPictureRTL", null);
		}
		set
		{
			SetValue("QuickAccessToolBarLeftPictureRTL", value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarRightPictureRTL
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarRightPictureRTL", null);
		}
		set
		{
			SetValue("QuickAccessToolBarRightPictureRTL", value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarLeftPictureLTR
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarLeftPictureLTR", null);
		}
		set
		{
			SetValue("QuickAccessToolBarLeftPictureLTR", value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarRightPictureLTR
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarRightPictureLTR", null);
		}
		set
		{
			SetValue("QuickAccessToolBarRightPictureLTR", value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarLeftPictureLTRWidth => GetImageWidth(QuickAccessToolBarLeftPictureLTR, 0);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarLeftPictureRTLWidth => GetImageWidth(QuickAccessToolBarLeftPictureRTL, 0);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarRightPictureLTRWidth => GetImageWidth(QuickAccessToolBarRightPictureLTR, 0);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarRightPictureRTLWidth => GetImageWidth(QuickAccessToolBarRightPictureRTL, 0);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarFlatPictureLTR
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarFlatPictureLTR", null);
		}
		set
		{
			SetValue("QuickAccessToolBarFlatPictureLTR", value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageResourceReference QuickAccessToolBarFlatPictureRTL
	{
		get
		{
			return GetValue<ImageResourceReference>("QuickAccessToolBarFlatPictureRTL", null);
		}
		set
		{
			SetValue("QuickAccessToolBarFlatPictureRTL", value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarFlatPictureLTRWidth => GetImageWidth(QuickAccessToolBarFlatPictureLTR, 0);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int QuickAccessToolBarFlatPictureRTLWidth => GetImageWidth(QuickAccessToolBarFlatPictureRTL, 0);

	private void InitializeComponent()
	{
	}
}
