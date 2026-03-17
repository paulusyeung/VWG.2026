using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Color for labels on Weather map layer
/// </summary>
[Serializable]
public enum GoogleMapWeatherLabelType
{
	/// <summary>
	/// Color is chosen automatically based on Map type
	/// </summary>
	Default,
	/// <summary>
	/// Black Labels
	/// </summary>
	Black,
	/// <summary>
	/// White labels
	/// </summary>
	White
}
