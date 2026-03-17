using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration of what type of control should be shown on GoogleMap to switch maptypes
/// </summary>
[Serializable]
public enum GoogleMapControlType
{
	/// <summary>
	/// No control
	/// </summary>
	/// [Obsolete("Obsoleted in GoogleMap v3 API. Use ShowMapTypeControl")]
	/// None,
	/// <summary>
	/// Uses the default map type control. The control which DEFAULT maps to will vary according to window size and other factors. It may change in future versions of the API.
	/// </summary>
	Default,
	/// <summary>
	/// A dropdown menu for the screen realestate conscious
	/// </summary>
	DropdownMenu,
	/// <summary>
	/// The standard horizontal radio buttons bar.
	/// </summary>
	HorizontalBar
}
