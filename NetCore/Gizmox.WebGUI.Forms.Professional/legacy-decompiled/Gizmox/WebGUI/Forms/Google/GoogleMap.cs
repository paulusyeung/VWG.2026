using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap control, wrapper for GoogleMap API V3
/// </summary>
[Serializable]
[ToolboxItem(false)]
[Browsable(false)]
[Obsolete("This control is no longer supported, please use the \"Gizmox.WebGUI.Forms.Professional.GoogleMap\" instead.")]
public class GoogleMap : Gizmox.WebGUI.Forms.Professional.GoogleMap
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMap" /> class.
	/// </summary>
	public GoogleMap()
	{
	}
}
