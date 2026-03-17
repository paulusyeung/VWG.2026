using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs class for clicks on reference points on weather layer
/// </summary>
[Serializable]
public class GoogleMapWeatherLayerClickEventArgs : GoogleMapLayerEventArgs
{
	private string mstrInfoWindowHtml;

	private string mstrLocation;

	private GoogleMapWeatherTemperatureUnitsType menumTemperatureUnit;

	private GoogleMapWeatherWindSpeedUnitsType menumWindSpeedUnit;

	private GoogleMapWeatherCondition mobjCurrent;

	private GoogleMapWeatherForecast[] marrForecast;

	/// <summary>
	/// Html Information for clicked reference
	/// </summary>
	public string InfoWindowHtml
	{
		get
		{
			return mstrInfoWindowHtml;
		}
		set
		{
			mstrInfoWindowHtml = value;
		}
	}

	/// <summary>
	/// The Address (Name) of the clicked reference
	/// </summary>
	public new string Location
	{
		get
		{
			return mstrLocation;
		}
		set
		{
			mstrLocation = value;
		}
	}

	/// <summary>
	/// The Temperature unit used
	/// </summary>
	public GoogleMapWeatherTemperatureUnitsType TemperatureUnit
	{
		get
		{
			return menumTemperatureUnit;
		}
		set
		{
			menumTemperatureUnit = value;
		}
	}

	/// <summary>
	/// The Wind speed unit used
	/// </summary>
	public GoogleMapWeatherWindSpeedUnitsType WindSpeedUnit
	{
		get
		{
			return menumWindSpeedUnit;
		}
		set
		{
			menumWindSpeedUnit = value;
		}
	}

	/// <summary>
	/// Current weather conditions
	/// </summary>
	public GoogleMapWeatherCondition Current
	{
		get
		{
			return mobjCurrent;
		}
		set
		{
			mobjCurrent = value;
		}
	}

	/// <summary>
	/// Forecast for the next four days
	/// </summary>
	public GoogleMapWeatherForecast[] Forecast
	{
		get
		{
			return marrForecast;
		}
		set
		{
			marrForecast = value;
		}
	}

	/// <summary>
	/// Initializes object from parameters
	/// </summary>
	/// <param name="objLayer">The Layer object</param>
	/// <param name="objLocation">The location clicked</param>
	public GoogleMapWeatherLayerClickEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation)
		: base(objLayer, objLocation)
	{
	}

	/// <summary>
	/// Initializes object from parameters
	/// </summary>
	/// <param name="objLayer">The Layer object</param>
	/// <param name="objLocation">The location clicked</param>
	/// <param name="strInfoWindowHtml">Html Information for clicked reference</param>
	/// <param name="strLocation">The Address (Name) of the clicked reference</param>
	/// <param name="enmTemperatureUnit">The Temperature unit used</param>
	/// <param name="enmWindSpeedUnit">The Wind speed unit used</param>
	/// <param name="objCurrent">Current weather conditions</param>
	/// <param name="arrWeatherForecast">Forecast for the next four days</param>
	public GoogleMapWeatherLayerClickEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation, string strInfoWindowHtml, string strLocation, GoogleMapWeatherTemperatureUnitsType enmTemperatureUnit, GoogleMapWeatherWindSpeedUnitsType enmWindSpeedUnit, GoogleMapWeatherCondition objCurrent, GoogleMapWeatherForecast[] arrWeatherForecast)
		: base(objLayer, objLocation)
	{
		mstrInfoWindowHtml = strInfoWindowHtml;
		mstrLocation = strLocation;
		menumTemperatureUnit = enmTemperatureUnit;
		menumWindSpeedUnit = enmWindSpeedUnit;
		mobjCurrent = objCurrent;
		marrForecast = arrWeatherForecast;
	}
}
