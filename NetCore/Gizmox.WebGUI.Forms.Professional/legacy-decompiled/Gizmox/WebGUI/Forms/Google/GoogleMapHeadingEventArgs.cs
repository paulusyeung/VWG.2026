using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs type for heading information.
/// </summary>
[Serializable]
public class GoogleMapHeadingEventArgs : EventArgs
{
	private double mdblHeading;

	/// <summary>
	/// The heading in degrees clockwise. 0 = True North.
	/// </summary>
	public double Heading => mdblHeading;

	/// <summary>
	/// Initializes a new instance with given heading
	/// </summary>
	/// <param name="intHeading"></param>
	public GoogleMapHeadingEventArgs(double dblHeading)
	{
		mdblHeading = dblHeading;
	}
}
