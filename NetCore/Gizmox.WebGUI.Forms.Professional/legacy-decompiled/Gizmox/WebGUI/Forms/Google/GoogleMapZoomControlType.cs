using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration of what kind of zoom control should be shown on the map
/// </summary>
[Serializable]
public enum GoogleMapZoomControlType
{
	/// <summary>
	/// Default Zoom control
	/// </summary>
	Default,
	/// <summary>
	/// Large Zoom control
	/// </summary>
	Large,
	/// <summary>
	/// Small Zoom control
	/// </summary>
	Small
}
