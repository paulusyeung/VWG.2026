using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(false)]
[DesignTimeVisible(false)]
public abstract class RibbonBarItem : ComponentBase
{
	private object mobjOwner;

	private Control mobjControl;

	public override ISite Site
	{
		get
		{
			return base.Site;
		}
		set
		{
			base.Site = value;
			if (Control != null)
			{
				Control.Site = value;
			}
		}
	}

	[Browsable(false)]
	public Control Control => mobjControl;

	[DefaultValue(true)]
	public virtual bool Visible
	{
		get
		{
			return Control.Visible;
		}
		set
		{
			Control.Visible = value;
		}
	}

	[DefaultValue(true)]
	public virtual bool Enabled
	{
		get
		{
			return Control.Enabled;
		}
		set
		{
			Control.Enabled = value;
		}
	}

	[DefaultValue("")]
	[Localizable(true)]
	public virtual string ToolTip
	{
		get
		{
			if (RibbonBar != null)
			{
				return RibbonBar.ToolTipService.GetToolTip(Control);
			}
			return "";
		}
		set
		{
			if (RibbonBar != null)
			{
				RibbonBar.ToolTipService.SetToolTip(Control, value);
			}
		}
	}

	[DefaultValue(null)]
	[TypeConverter(typeof(StringConverter))]
	public virtual object Tag
	{
		get
		{
			return Control.Tag;
		}
		set
		{
			Control.Tag = value;
		}
	}

	[DefaultValue("")]
	[Localizable(true)]
	public virtual string Text
	{
		get
		{
			return Control.Text;
		}
		set
		{
			Control.Text = value;
		}
	}

	[Localizable(true)]
	[Description("ControlAutoSizeDescr")]
	[Category("CatLayout")]
	[DefaultValue(false)]
	public bool AutoSize
	{
		get
		{
			return Control.AutoSize;
		}
		set
		{
			Control.AutoSize = value;
		}
	}

	[Localizable(true)]
	[Description("ControlAutoSizeModeDescr")]
	[Category("CatLayout")]
	[DefaultValue(AutoSizeMode.GrowOnly)]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return Control.AutoSizeMode;
		}
		set
		{
			Control.AutoSizeMode = value;
		}
	}

	internal object Owner => mobjOwner;

	protected internal virtual RibbonBar RibbonBar
	{
		get
		{
			if (mobjOwner is RibbonBarItem ribbonBarItem)
			{
				return ribbonBarItem.RibbonBar;
			}
			return null;
		}
	}

	public RibbonBarItem()
	{
		mobjControl = CreateControl();
	}

	protected virtual Control CreateControl()
	{
		return null;
	}

	internal virtual void SetOwner(object objOwner)
	{
		mobjOwner = objOwner;
	}
}
