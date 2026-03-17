using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarButtonItem : RibbonBarItem
{
	public RegisteredClientAction ClientAction
	{
		get
		{
			return Button.ClientAction;
		}
		set
		{
			Button.ClientAction = value;
		}
	}

	private Button Button => base.Control as Button;

	[DefaultValue(null)]
	public virtual ResourceHandle Image
	{
		get
		{
			return Button.Image;
		}
		set
		{
			Button.Image = value;
		}
	}

	public event EventHandler Click;

	public event MenuEventHandler MenuClick;

	protected override Control CreateControl()
	{
		Button button = CreateButton();
		if (button != null)
		{
			button.TextImageRelation = TextImageRelation.ImageAboveText;
			button.Click += OnButtonClick;
			button.MenuClick += objButton_MenuClick;
		}
		return button;
	}

	private void objButton_MenuClick(object objSource, MenuItemEventArgs objArgs)
	{
		if (this.MenuClick != null)
		{
			this.MenuClick(this, objArgs);
		}
		if (RibbonBar != null)
		{
			RibbonBar.OnButtonMenuClick(this, objArgs.MenuItem);
		}
	}

	protected virtual Button CreateButton()
	{
		return new RibbonBar.RibbonBarButton("RibbonBarBig");
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
		this.Click?.Invoke(this, EventArgs.Empty);
		if (RibbonBar != null)
		{
			RibbonBar.OnButtonClick(this);
		}
	}
}
