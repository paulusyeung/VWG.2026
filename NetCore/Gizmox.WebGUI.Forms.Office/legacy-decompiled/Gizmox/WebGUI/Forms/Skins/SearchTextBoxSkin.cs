using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
public class SearchTextBoxSkin : TextBoxSkin
{
	[Category("Styles")]
	[Description("The search textbox watermark style.")]
	public virtual StyleValue WatermarkStyle => new StyleValue(this, "WatermarkStyle");

	[Category("Styles")]
	[Description("The search textbox buttons style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual BidirectionalSkinValue<StyleValue> SearchButtonStyle => new BidirectionalSkinValue<StyleValue>(this, SearchButtonStyleLTR, SearchButtonStyleRTL);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual StyleValue SearchButtonStyleLTR => new StyleValue(this, "SearchButtonStyleLTR");

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual StyleValue SearchButtonStyleRTL => new StyleValue(this, "SearchButtonStyle");

	[Category("Images")]
	[Description("The Search Button Image.")]
	public ImageResourceReference SearchButtonImage
	{
		get
		{
			return GetValue("SearchButtonImage", new ImageResourceReference(typeof(SearchTextBoxSkin), "Search.gif"));
		}
		set
		{
			SetValue("SearchButtonImage", value);
		}
	}

	[Category("Images")]
	[Description("The Clear Button Image.")]
	public ImageResourceReference ClearButtonImage
	{
		get
		{
			return GetValue("ClearButtonImage", new ImageResourceReference(typeof(SearchTextBoxSkin), "Clear.gif"));
		}
		set
		{
			SetValue("ClearButtonImage", value);
		}
	}

	[Category("Images")]
	[Description("The Arrow Down Button Image.")]
	public ImageResourceReference ArrowDownButtonImage
	{
		get
		{
			return GetValue("ArrowDownButtonImage", new ImageResourceReference(typeof(SearchTextBoxSkin), "ArrowDown.gif"));
		}
		set
		{
			SetValue("ArrowDownButtonImage", value);
		}
	}

	[Category("Sizes")]
	[Description("The width of the search image cell.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual int SearchImageCellWidth
	{
		get
		{
			return GetValue("SearchImageCellWidth", GetImageWidth(SearchButtonImage));
		}
		set
		{
			SetValue("SearchImageCellWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The width of the arrow down image cell.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual int ArrowDownCellWidth
	{
		get
		{
			return GetValue("ArrowDownCellWidth", GetImageWidth(ArrowDownButtonImage));
		}
		set
		{
			SetValue("ArrowDownCellWidth", value);
		}
	}

	internal void ResetSearchButtonImage()
	{
		Reset("SearchButtonImage");
	}

	internal void ResetClearButtonImage()
	{
		Reset("ClearButtonImage");
	}

	internal void ResetArrowDownButtonImage()
	{
		Reset("ArrowDownButtonImage");
	}

	internal void ResetSearchImageCellWidth()
	{
		Reset("SearchImageCellWidth");
	}

	internal void ResetArrowDownCellWidth()
	{
		Reset("ArrowDownCellWidth");
	}

	private void InitializeComponent()
	{
	}
}
