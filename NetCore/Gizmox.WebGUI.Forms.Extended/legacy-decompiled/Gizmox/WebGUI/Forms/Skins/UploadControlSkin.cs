using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins;

/// <summary>
/// Summary description for UploadControlSkin
/// </summary>   
[Serializable]
public class UploadControlSkin : ControlSkin
{
	/// <summary>
	/// Gets or sets Cursor for the upload control
	/// </summary>
	/// <value></value>
	[Category("UploadControl")]
	[Description("Cursor for the Upload Control")]
	public virtual Cursor Cursor
	{
		get
		{
			return GetValue("Cursor", Cursors.No);
		}
		set
		{
			SetValue("Cursor", value);
		}
	}

	/// <summary>
	/// Gets or sets Cursor for the upload control
	/// </summary>
	/// <value></value>
	[Category("UploadButton")]
	[Description("Cursor for the Upload Button")]
	public virtual Cursor UploadButtonCursor
	{
		get
		{
			return GetValue("UploadButtonCursor", Cursors.No);
		}
		set
		{
			SetValue("UploadButtonCursor", value);
		}
	}

	/// <summary>
	/// Gets or sets the width of the upload button in pixels
	/// </summary>
	/// <value></value>
	[Category("UploadButton")]
	[Description("Width of upload button in pixels")]
	public virtual int UploadButtonWidth
	{
		get
		{
			return GetValue("UploadButtonWidth", 0);
		}
		set
		{
			SetValue("UploadButtonWidth", value);
		}
	}

	/// <summary>
	/// Gets or sets Style of the upload button
	/// </summary>
	/// <value></value>
	[Category("UploadButton")]
	[Description("Style of the Upload button")]
	public StyleValue UploadButtonStyle => new StyleValue(this, "UploadButtonStyle");

	/// <summary>
	/// Gets or sets the height of progress bar in pixels
	/// </summary>
	/// <value></value>
	[Category("UploadBar")]
	[Description("Height of progress bar in pixels")]
	public virtual int UploadBarHeight
	{
		get
		{
			return GetValue("UploadBarHeight", 0);
		}
		set
		{
			SetValue("UploadBarHeight", value);
		}
	}

	/// <summary>
	/// Gets or sets Style of the not completed area area of the progress bar bar
	/// </summary>
	/// <value></value>
	[Category("UploadBar")]
	[Description("Style of the not completed area area of the progress bar")]
	public StyleValue UploadBarStyle => new StyleValue(this, "UploadBarStyle");

	/// <summary>
	/// Gets or sets Style of completed area of the progress bar
	/// </summary>
	/// <value></value>
	[Category("UploadBar")]
	[Description("Style of completed area of the progress bar")]
	public StyleValue UploadBarCompletedStyle => new StyleValue(this, "UploadBarCompletedStyle");

	private void InitializeComponent()
	{
	}

	internal void ResetUploadButtonStyle()
	{
		Reset("UploadButtonStyle");
	}

	internal void ResetUploadBarStyle()
	{
		Reset("UploadBarStyle");
	}

	internal void ResetUploadBarCompletedStyle()
	{
		Reset("UploadBarCompletedStyle");
	}
}
