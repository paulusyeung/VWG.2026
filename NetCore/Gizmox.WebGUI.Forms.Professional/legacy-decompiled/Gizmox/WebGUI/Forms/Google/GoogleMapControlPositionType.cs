using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Positioning enumeration for GoogleMap controls (Zoom, MapType ...)
/// </summary>
[Serializable]
public enum GoogleMapControlPositionType
{
	/// <summary>
	/// Elements are positioned in the center of the bottom row.
	/// </summary>
	BottomCenter = 1,
	/// <summary>
	/// Elements are positioned in the bottom left and flow towards the middle. Elements are positioned to the right of the Google logo.
	/// </summary>
	BottomLeft,
	/// <summary>
	/// Elements are positioned in the bottom right and flow towards the middle. Elements are positioned to the left of the copyrights.
	/// </summary>
	BottomRight,
	/// <summary>
	/// Elements are positioned on the left, above bottom-left elements, and flow upwards.
	/// </summary>
	LeftBottom,
	/// <summary>
	/// Elements are positioned in the center of the left side.
	/// </summary>
	LeftCenter,
	/// <summary>
	/// Elements are positioned on the left, below top-left elements, and flow downwards.
	/// </summary>
	LeftTop,
	/// <summary>
	/// Elements are positioned on the right, above bottom-right elements, and flow upwards.
	/// </summary>
	RightBottom,
	/// <summary>
	/// Elements are positioned in the center of the right side.
	/// </summary>
	RightCenter,
	/// <summary>
	/// Elements are positioned on the right, below top-right elements, and flow downwards.
	/// </summary>
	RightTop,
	/// <summary>
	/// Elements are positioned in the center of the top row.
	/// </summary>
	TopCenter,
	/// <summary>
	/// Elements are positioned in the top left and flow towards the middle.
	/// </summary>
	TopLeft,
	/// <summary>
	/// Elements are positioned in the top right and flow towards the middle.
	/// </summary>
	TopRight
}
