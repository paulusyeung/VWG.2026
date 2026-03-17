using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(SearchTextBox), "Office.SearchTextBox_45.png")]
[Skin(typeof(SearchTextBoxSkin))]
public class SearchTextBox : TextBox, IRequiresRegistration
{
	private string mstrWatermarkText = string.Empty;

	private Menu mobjDropDown;

	private bool mblnIsSearchActive;

	[DefaultValue("")]
	public string WatermarkText
	{
		get
		{
			return mstrWatermarkText;
		}
		set
		{
			if (mstrWatermarkText != value)
			{
				mstrWatermarkText = value;
				Update();
			}
		}
	}

	[DefaultValue(false)]
	public bool IsSearchActive
	{
		get
		{
			return mblnIsSearchActive;
		}
		set
		{
			if (mblnIsSearchActive != value)
			{
				mblnIsSearchActive = value;
				Update();
			}
		}
	}

	[DefaultValue(null)]
	public Menu DropDownMenu
	{
		get
		{
			return mobjDropDown;
		}
		set
		{
			if (mobjDropDown != value)
			{
				Update();
			}
			mobjDropDown = value;
			if (mobjDropDown != null && mobjDropDown.InternalParent == null)
			{
				mobjDropDown.InternalParent = this;
			}
		}
	}

	public event EventHandler Search;

	[Description("Occurs when Search applied in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientSearch
	{
		add
		{
			AddClientHandler("Search", value);
		}
		remove
		{
			RemoveClientHandler("Search", value);
		}
	}

	[Description("Occurs when control cleared in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientClear
	{
		add
		{
			AddClientHandler("Clear", value);
		}
		remove
		{
			RemoveClientHandler("Clear", value);
		}
	}

	[Description("Occurs when control's DropDown menu dispayed in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientDropDown
	{
		add
		{
			AddClientHandler("DropDown", value);
		}
		remove
		{
			RemoveClientHandler("DropDown", value);
		}
	}

	public new event EventHandler Clear;

	public SearchTextBox()
	{
		CustomStyle = "STB";
	}

	protected override void RenderAttributes(IContext context, IAttributeWriter writer)
	{
		base.RenderAttributes(context, writer);
		writer.WriteAttributeText("WatermarkText", WatermarkText, (TextFilter)5);
		writer.WriteAttributeString("Search", mblnIsSearchActive ? "1" : "0");
		if (mobjDropDown != null)
		{
			writer.WriteAttributeString("DD", "1");
		}
	}

	protected override void FireEvent(IEvent objEvent)
	{
		switch (objEvent.Type)
		{
		case "Search":
			mblnIsSearchActive = true;
			if (this.Search != null)
			{
				this.Search(this, EventArgs.Empty);
			}
			break;
		case "Clear":
			mblnIsSearchActive = false;
			if (this.Clear != null)
			{
				this.Clear(this, EventArgs.Empty);
			}
			break;
		case "DropDown":
			if (DropDownMenu != null)
			{
				DropDownMenu.Show(this, Point.Empty, DialogAlignment.Below);
			}
			break;
		}
		base.FireEvent(objEvent);
	}
}
