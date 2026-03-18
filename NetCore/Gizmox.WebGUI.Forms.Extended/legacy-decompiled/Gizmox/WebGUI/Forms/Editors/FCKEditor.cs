using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Extended;

namespace Gizmox.WebGUI.Forms.Editors;

/// <summary>
/// Summary description for FCKEditor
/// </summary>
[Serializable]
[ToolboxItem(false)]
[Browsable(false)]
[Obsolete("This control is no longer supported, please use the \"Gizmox.WebGUI.Forms.Extended.FCKEditor\" instead.")]
public class FCKEditor : Gizmox.WebGUI.Forms.Extended.FCKEditor
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Editors.FCKEditor" /> class.
	/// </summary>
	public FCKEditor()
	{
	}
}
