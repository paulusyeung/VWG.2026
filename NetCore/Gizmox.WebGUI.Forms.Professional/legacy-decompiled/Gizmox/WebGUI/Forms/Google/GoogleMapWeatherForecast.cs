using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Describes a single day's weather forecast for Weather Layer
/// </summary>
[Serializable]
public class GoogleMapWeatherForecast
{
	private string mstrDay;

	private string mstrDescription;

	private double mdblHigh;

	private double mdblLow;

	private string mstrShortDay;

	/// <summary>
	/// The day of the week in long form, e.g. "Monday".
	/// </summary>
	public string Day
	{
		get
		{
			return mstrDay;
		}
		set
		{
			mstrDay = value;
		}
	}

	/// <summary>
	/// A description of the conditions, e.g. "Partly Cloudy".
	/// </summary>
	public string Description
	{
		get
		{
			return mstrDescription;
		}
		set
		{
			mstrDescription = value;
		}
	}

	/// <summary>
	/// The highest temperature reached during the day.
	/// </summary>
	public double High
	{
		get
		{
			return mdblHigh;
		}
		set
		{
			mdblHigh = value;
		}
	}

	/// <summary>
	/// The lowest temperature reached during the day.
	/// </summary>
	public double Low
	{
		get
		{
			return mdblLow;
		}
		set
		{
			mdblLow = value;
		}
	}

	/// <summary>
	/// The day of the week in short form, e.g. "M".
	/// </summary>
	public string ShortDay
	{
		get
		{
			return mstrShortDay;
		}
		set
		{
			mstrShortDay = value;
		}
	}

	/// <summary>
	/// Initializes instance from parameters
	/// </summary>
	/// <param name="strDay">The day of the week in long form, e.g. "Monday".</param>
	/// <param name="strDescription">A description of the conditions, e.g. "Partly Cloudy".</param>
	/// <param name="dblHigh">The highest temperature reached during the day.</param>
	/// <param name="dblLow">The lowest temperature reached during the day.</param>
	/// <param name="strShortDay">The day of the week in short form, e.g. "M".</param>
	public GoogleMapWeatherForecast(string strDay, string strDescription, double dblHigh, double dblLow, string strShortDay)
	{
		mstrDay = strDay;
		mstrDescription = strDescription;
		mdblHigh = dblHigh;
		mdblLow = dblLow;
		mstrShortDay = strShortDay;
	}
}
