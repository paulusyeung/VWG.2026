using System;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(ExtendedToolTipSkin))]
[ProvideProperty("ToolTipTemplateName", typeof(Control))]
[ProvideProperty("Header", typeof(Control))]
[ProvideProperty("Content", typeof(Control))]
public class ExtendedToolTip : ToolTip
{
	/// <summary>
	/// Gets the tool tip key.
	/// </summary>
	protected override string ToolTipKey => "ExtendedToolTip";

	/// <summary>
	/// Gets the header.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	[DefaultValue("")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string GetHeader(Control objControl)
	{
		return GetExtendedToolTipProperty(objControl, "Header");
	}

	/// <summary>
	/// Sets the header.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	public void SetHeader(Control objControl, string strValue)
	{
		SetExtendedToolTipProperty(objControl, "Header", strValue);
	}

	/// <summary>
	/// Determines whether to serialize the header.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	private bool ShouldSerializeHeader(Control objControl)
	{
		return !string.IsNullOrEmpty(GetExtendedToolTipProperty(objControl, "Header"));
	}

	/// <summary>
	/// Resets the header.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	private void ResetHeader(Control objControl)
	{
		SetExtendedToolTipProperty(objControl, "Header", string.Empty);
	}

	/// <summary>
	/// Gets the content.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	[DefaultValue("")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string GetContent(Control objControl)
	{
		return GetExtendedToolTipProperty(objControl, "Content");
	}

	/// <summary>
	/// Sets the content.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <param name="strValue">The STR value.</param>
	public void SetContent(Control objControl, string strValue)
	{
		SetExtendedToolTipProperty(objControl, "Content", strValue);
	}

	/// <summary>
	/// Determines whether to serialize the content.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	private bool ShouldSerializeContent(Control objControl)
	{
		return !string.IsNullOrEmpty(GetExtendedToolTipProperty(objControl, "Content"));
	}

	/// <summary>
	/// Resets the content.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	private void ResetContent(Control objControl)
	{
		SetExtendedToolTipProperty(objControl, "Content", string.Empty);
	}

	/// <summary>
	/// Gets the name of the tool tip template.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	[DefaultValue("")]
	public string GetToolTipTemplateName(Control objControl)
	{
		return GetExtendedToolTipTemplateName(objControl);
	}

	/// <summary>
	/// Sets the name of the tool tip template.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <param name="strValue">The STR value.</param>
	public void SetToolTipTemplateName(Control objControl, string strValue)
	{
		SetExtendedToolTipTemplateName(objControl, strValue);
	}

	/// <summary>
	/// Determines whether to serialize the tooltip template name.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	/// <returns></returns>
	private bool ShouldSerializeToolTipTemplateName(Control objControl)
	{
		return !string.IsNullOrEmpty(GetExtendedToolTipTemplateName(objControl));
	}

	/// <summary>
	/// Resets the tooltip template name.
	/// </summary>
	/// <param name="objControl">The obj control.</param>
	private void ResetToolTipTemplateName(Control objControl)
	{
		SetExtendedToolTipTemplateName(objControl, string.Empty);
	}
}
