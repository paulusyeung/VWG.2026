using System;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(false)]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarPageController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarPageController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[DesignTimeVisible(false)]
public class RibbonBarPage : ComponentBase
{
	private RibbonBarTabPage mobjTabPage;

	private RibbonBarPageCollection mobjOwner;

	private RibbonBarGroupCollection mobjGroups;

	public virtual bool Visible
	{
		get
		{
			return mobjTabPage.Visible;
		}
		set
		{
			mobjTabPage.Visible = value;
		}
	}

	[Localizable(true)]
	public string Text
	{
		get
		{
			return mobjTabPage.Text;
		}
		set
		{
			mobjTabPage.Text = value;
		}
	}

	public virtual bool AutoScroll
	{
		get
		{
			return mobjTabPage.AutoScroll;
		}
		set
		{
			mobjTabPage.AutoScroll = value;
		}
	}

	public ScrollerType ScrollerType
	{
		get
		{
			return mobjTabPage.ScrollerType;
		}
		set
		{
			mobjTabPage.ScrollerType = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonBarGroupCollection Groups
	{
		get
		{
			if (mobjGroups == null)
			{
				mobjGroups = CreateRibbonBarGroupCollection();
			}
			return mobjGroups;
		}
	}

	internal RibbonBarTabPage TabPage => mobjTabPage;

	internal RibbonBar RibbonBar => mobjOwner.RibbonBar;

	[Editor("Gizmox.WebGUI.Forms.Office.Design.Editors.RibbonBarPageContextualTabGroupEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	[DefaultValue(null)]
	[MergableProperty(false)]
	public ContextualTabGroup ContextualTabGroup
	{
		get
		{
			return mobjTabPage.ContextualTabGroup;
		}
		set
		{
			mobjTabPage.ContextualTabGroup = value;
		}
	}

	public RibbonBarPage()
		: this("")
	{
	}

	public RibbonBarPage(string strText)
	{
		mobjTabPage = new RibbonBarTabPage();
		mobjTabPage.Text = strText;
		mobjTabPage.Padding = new Padding(0, 1, 0, 1);
	}

	internal void SetOwner(RibbonBarPageCollection objOwner)
	{
		mobjOwner = objOwner;
	}

	protected virtual RibbonBarGroupCollection CreateRibbonBarGroupCollection()
	{
		return new RibbonBarGroupCollection(this);
	}

	public override string ToString()
	{
		return Text;
	}

	protected override void Dispose(bool blnDisposing)
	{
		base.Dispose(blnDisposing);
		if (!blnDisposing)
		{
			return;
		}
		foreach (RibbonBarGroup group in Groups)
		{
			group.Dispose();
		}
	}
}
