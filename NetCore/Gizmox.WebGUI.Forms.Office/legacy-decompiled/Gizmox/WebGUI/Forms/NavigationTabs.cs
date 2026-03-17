using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxBitmap(typeof(NavigationTabs), "Office.NavigationTabs_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.NavigationTabsController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.NavigationTabsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[Skin(typeof(NavigationTabsSkin))]
public class NavigationTabs : TabControl, IRequiresRegistration
{
	protected override TabAlignment DefaultAlignment => TabAlignment.Bottom;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override TabAlignment Alignment
	{
		get
		{
			return base.Alignment;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[MergableProperty(false)]
	public new NavigationTabCollection TabPages => (NavigationTabCollection)base.TabPages;

	protected override string ClientUpdateHandler
	{
		get
		{
			if (ClientBehavior != TabControlClientBehavior.DrawingOptimized)
			{
				return string.Empty;
			}
			return "NavigationTabs_UpdateHandler";
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public override TabAppearance Appearance
	{
		get
		{
			return TabAppearance.Navigation;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool ShowCloseButton
	{
		get
		{
			return base.ShowCloseButton;
		}
		set
		{
			base.ShowCloseButton = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Multiline
	{
		get
		{
			return base.Multiline;
		}
		set
		{
			base.Multiline = value;
		}
	}

	protected override PaddingValue ContainedAreaOffset
	{
		get
		{
			if (SkinFactory.GetSkin(this) is NavigationTabsSkin navigationTabsSkin)
			{
				Padding padding = new Padding
				{
					Bottom = navigationTabsSkin.BottomFrameHeight,
					Top = navigationTabsSkin.TopFrameHeight,
					Left = navigationTabsSkin.LeftFrameWidth,
					Right = navigationTabsSkin.RightFrameWidth
				};
				int num = 1;
				foreach (NavigationTab tabPage in TabPages)
				{
					if (tabPage.Visible && !tabPage.Extra)
					{
						num++;
					}
				}
				padding.Bottom += navigationTabsSkin.SeperatorFrameHeight + num * navigationTabsSkin.TabHeight;
				return new PaddingValue(padding + base.ContainedAreaOffset);
			}
			return base.ContainedAreaOffset;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override ContextualTabGroupCollection ContextualTabGroups => new ContextualTabGroupCollection(this);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override bool ShowExpandButton
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override bool IsExpanded
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override int MaxTabPageHeaders
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Not supported")]
	public override event EventHandler CloseClick
	{
		add
		{
		}
		remove
		{
		}
	}

	protected override void AddChild(object objValue)
	{
		if (objValue is NavigationTab)
		{
			TabPages.Add((NavigationTab)objValue);
		}
		else
		{
			base.AddChild(objValue);
		}
	}

	protected override int GetTabLayoutId(TabAlignment enmTabAlignment)
	{
		return 4;
	}

	protected override TabPageCollection CreateTabPageCollection()
	{
		return new NavigationTabCollection(this);
	}
}
