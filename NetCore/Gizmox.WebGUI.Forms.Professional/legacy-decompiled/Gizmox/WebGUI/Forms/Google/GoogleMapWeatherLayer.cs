using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Weather layer
/// </summary>
[Serializable]
public class GoogleMapWeatherLayer : GoogleMapLayer
{
	/// <summary>
	/// The Clickable property registration.
	/// </summary>
	private static readonly SerializableProperty ClickableProperty = SerializableProperty.Register("Clickable", typeof(bool), typeof(GoogleMapWeatherLayer));

	/// <summary>
	/// The LabelColor property registration.
	/// </summary>
	private static readonly SerializableProperty LabelColorProperty = SerializableProperty.Register("LabelColor", typeof(GoogleMapWeatherLabelType), typeof(GoogleMapWeatherLayer));

	/// <summary>
	/// The SuppressInfoWindows property registration.
	/// </summary>
	private static readonly SerializableProperty SuppressInfoWindowsProperty = SerializableProperty.Register("SuppressInfoWindows", typeof(bool), typeof(GoogleMapWeatherLayer));

	/// <summary>
	/// The TemperatureUnits property registration.
	/// </summary>
	private static readonly SerializableProperty TemperatureUnitsProperty = SerializableProperty.Register("TemperatureUnits", typeof(GoogleMapWeatherTemperatureUnitsType), typeof(GoogleMapWeatherLayer));

	/// <summary>
	/// The WindSpeedUnits property registration.
	/// </summary>
	private static readonly SerializableProperty WindSpeedUnitsProperty = SerializableProperty.Register("WindSpeedUnits", typeof(GoogleMapWeatherWindSpeedUnitsType), typeof(GoogleMapWeatherLayer));

	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.WeatherLayer;

	/// <summary>
	/// Are the weather points clickable
	/// </summary>
	[SRDescription("Are the weather points clickable.")]
	[DefaultValue(true)]
	public bool Clickable
	{
		get
		{
			return GetValue(ClickableProperty, objDefault: true);
		}
		set
		{
			SetValue(ClickableProperty, value, objDefaultValue: true);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The color of labels for weather layer
	/// </summary>
	[SRDescription("The color of labels for weather layer.")]
	[DefaultValue(GoogleMapWeatherLabelType.Default)]
	public GoogleMapWeatherLabelType LabelColor
	{
		get
		{
			return GetValue(LabelColorProperty, GoogleMapWeatherLabelType.Default);
		}
		set
		{
			SetValue(LabelColorProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Let client handle info windows (true) or fire event to the server (false)
	/// </summary>
	[SRDescription("Skip showing client information window on click of a weather layer point.")]
	[DefaultValue(false)]
	public bool SuppressInfoWindows
	{
		get
		{
			return GetValue(SuppressInfoWindowsProperty, objDefault: false);
		}
		set
		{
			SetValue(SuppressInfoWindowsProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Unit for temperature values
	/// </summary>
	[SRDescription("Unit for temperature values.")]
	[DefaultValue(GoogleMapWeatherTemperatureUnitsType.Celsius)]
	public GoogleMapWeatherTemperatureUnitsType TemperatureUnits
	{
		get
		{
			return GetValue(TemperatureUnitsProperty, GoogleMapWeatherTemperatureUnitsType.Celsius);
		}
		set
		{
			SetValue(TemperatureUnitsProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Unit for wind speed values
	/// </summary>
	[SRDescription("Unit for wind speed values.")]
	[DefaultValue(GoogleMapWeatherWindSpeedUnitsType.MetersPerSecond)]
	public GoogleMapWeatherWindSpeedUnitsType WindSpeedUnits
	{
		get
		{
			return GetValue(WindSpeedUnitsProperty, GoogleMapWeatherWindSpeedUnitsType.MetersPerSecond);
		}
		set
		{
			SetValue(WindSpeedUnitsProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapWeatherLayer()
	{
	}

	/// <summary>
	/// Render the attributes of the layer
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		objWriter.WriteAttributeString("Clickable", Clickable ? "1" : "0");
		objWriter.WriteAttributeString("SuppressInfoWindows", SuppressInfoWindows ? "1" : "0");
		objWriter.WriteAttributeString("LabelColor", LabelColor.ToString());
		objWriter.WriteAttributeString("TempUnits", TemperatureUnits.ToString());
		objWriter.WriteAttributeString("WindUnits", WindSpeedUnits.ToString());
	}
}
