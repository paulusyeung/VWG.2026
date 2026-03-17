using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration for cursor types for GoogleMap objects as default CSS cursor type values
/// </summary>
[Serializable]
public enum GoogleMapCursorType
{
	/// <summary>
	/// The default cursor
	/// </summary>
	Default,
	/// <summary>
	/// The cursor render as a crosshair
	/// </summary>
	Crosshair,
	/// <summary>
	/// The cursor render as a pointer
	/// </summary>
	Pointer,
	/// <summary>
	/// The cursor indicates something that should be moved
	/// </summary>
	Move,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved right (east)
	/// </summary>
	E_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved up and right (north/east)
	/// </summary>
	NE_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved up and left (north/west)
	/// </summary>
	NW_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved up (north)
	/// </summary>
	N_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved down and right (south/east)
	/// </summary>
	SE_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved down and left (south/west)
	/// </summary>
	SW_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved down (south)
	/// </summary>
	S_resize,
	/// <summary>
	/// The cursor indicates that an edge of a box is to be moved left (west)
	/// </summary>
	W_resize,
	/// <summary>
	/// The cursor indicates that the program is busy
	/// </summary>
	Wait,
	/// <summary>
	/// The cursor indicates that the program is busy (in progress)
	/// </summary>
	Progress,
	/// <summary>
	/// The cursor indicates that help is available
	/// </summary>
	Help
}
