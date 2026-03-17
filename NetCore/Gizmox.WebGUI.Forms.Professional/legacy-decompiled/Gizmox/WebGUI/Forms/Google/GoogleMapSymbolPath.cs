using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Types of symbols in overlays like PolyLine etc.
/// </summary>
[Serializable]
public enum GoogleMapSymbolPath
{
	/// <summary>
	/// A backward-pointing closed arrow.
	/// </summary>
	BackwardClosedArrow,
	/// <summary>
	/// A backward-pointing open arrow.
	/// </summary>
	BackwardOpenArrow,
	/// <summary>
	/// A circle.
	/// </summary>
	Circle,
	/// <summary>
	/// A forward-pointing closed arrow.
	/// </summary>
	ForwardClosedArrow,
	/// <summary>
	/// A forward-pointing open arrow.
	/// </summary>
	ForwardOpenArrow
}
