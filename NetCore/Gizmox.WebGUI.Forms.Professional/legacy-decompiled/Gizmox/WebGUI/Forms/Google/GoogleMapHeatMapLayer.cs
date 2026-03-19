using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Heat map
/// </summary>
[Serializable]
public class GoogleMapHeatMapLayer : GoogleMapLayer
{
	/// <summary>
	/// The DataPoints property registration.
	/// </summary>
	private static readonly SerializableProperty DataPointsProperty = SerializableProperty.Register("DataPoints", typeof(GoogleMapLocationCollection), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// The Dissipating property registration.
	/// </summary>
	private static readonly SerializableProperty DissipatingProperty = SerializableProperty.Register("Dissipating", typeof(bool), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// The Gradient property registration.
	/// </summary>
	private static readonly SerializableProperty GradientProperty = SerializableProperty.Register("Gradient", typeof(Collection<Color>), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// The MaxIntensity property registration.
	/// </summary>
	private static readonly SerializableProperty MaxIntensityProperty = SerializableProperty.Register("MaxIntensity", typeof(int), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// The Opacity property registration.
	/// </summary>
	private static readonly SerializableProperty OpacityProperty = SerializableProperty.Register("Opacity", typeof(double), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// The Radius property registration.
	/// </summary>
	private static readonly SerializableProperty RadiusProperty = SerializableProperty.Register("Radius", typeof(int), typeof(GoogleMapHeatMapLayer));

	/// <summary>
	/// Does layer type allow multiple instances of the same layer type on a single GoogleMap
	/// </summary>
	[SRDescription("Does layer type allow multiple instances of the same layer type on a single GoogleMap.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AllowMultipleInstances => true;

	/// <summary>
	/// The radius of influence for each data point, in pixels.
	/// </summary>
	[SRDescription("The radius of influence for each data point in pixels.")]
	[DefaultValue(0)]
	public int Radius
	{
		get
		{
			return GetValue(RadiusProperty, 0);
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Radius must be positive or 0");
			}
			SetValue(RadiusProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The opacity of the heatmap, expressed as a number between 0 and 1. Defaults to 0.6.
	/// </summary>
	[SRDescription("The opacity of the heatmap, expressed as a number between 0 and 1. Default to 0.6.")]
	[DefaultValue(0.6)]
	public double Opacity
	{
		get
		{
			return GetValue(OpacityProperty, 0.6);
		}
		set
		{
			if (Opacity != value)
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Opacity needs to be between 0 and 1");
				}
				SetValue(OpacityProperty, value);
				UpdateParentMap();
			}
		}
	}

	/// <summary>
	/// The maximum intensity of the heatmap. By default, heatmap colors are dynamically scaled according to the greatest concentration of points at any particular pixel on the map. This property allows you to specify a fixed maximum.
	/// </summary>
	[SRDescription("The maximum intensity of the heatmap. By default, heatmap colors are dynamically scaled according to the greatest concentration of points at any particular pixel on the map. This property allows you to specify a fixed maximum.")]
	[DefaultValue(0)]
	public int MaxIntensity
	{
		get
		{
			return GetValue(MaxIntensityProperty, 0);
		}
		set
		{
			SetValue(MaxIntensityProperty, value);
			UpdateParentMap();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Gradient as array of strings is obsolete. Use GradientColors instead.")]
	public string[] Gradient
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			foreach (Color gradientColor in GradientColors)
			{
				arrayList.Add(ColorTranslator.ToHtml(gradientColor));
			}
			return (string[])arrayList.ToArray();
		}
		set
		{
			GradientColors.Clear();
			if (value != null && value.Length != 0)
			{
				foreach (string htmlColor in value)
				{
					GradientColors.Add(ColorTranslator.FromHtml(htmlColor));
				}
			}
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The color gradient of the heatmap, specified as an array of Color values.
	/// </summary>
	[SRDescription("The color gradient of the heatmap, specified as an array of CSS colors. All CSS3 colors are supported except for extended named colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Collection<Color> GradientColors
	{
		get
		{
			Collection<Color> collection = GetValue<Collection<Color>>(GradientProperty);
			if (collection == null)
			{
				collection = new Collection<Color>();
				SetValue(GradientProperty, collection);
			}
			return collection;
		}
		set
		{
			SetValue(GradientProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The data points to display. Required.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("Gizmox.WebGUI.Forms.Google.GoogleLocationCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design", typeof(UITypeEditor))]
	[SRDescription("The data points to display. Required.")]
	public GoogleMapLocationCollection DataPoints
	{
		get
		{
			GoogleMapLocationCollection googleMapLocationCollection = GetValue<GoogleMapLocationCollection>(DataPointsProperty);
			if (googleMapLocationCollection == null)
			{
				googleMapLocationCollection = new GoogleMapLocationCollection();
				SetValue(DataPointsProperty, googleMapLocationCollection);
			}
			return googleMapLocationCollection;
		}
		private set
		{
			SetValue(DataPointsProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Specifies whether heatmaps dissipate on zoom. By default, the radius of influence of a data point is specified by the radius option only. When dissipating is disabled, the radius option is intepreted as a radius at zoom level 0.
	/// </summary>
	[SRDescription("Specifies whether heatmaps dissipate on zoom. By default, the radius of influence of a data point is specified by the radius option only. When dissipating is disabled, the radius option is intepreted as a radius at zoom level 0.")]
	[DefaultValue(false)]
	public bool Dissipating
	{
		get
		{
			return GetValue(DissipatingProperty, objDefault: false);
		}
		set
		{
			SetValue(DissipatingProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.HeatmapLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapHeatMapLayer()
	{
	}

	/// <summary>
	/// Initializes new object from parameters
	/// </summary>
	/// <param name="objDataPoints">The data points to display. Required.</param>
	/// <param name="blnDissipating">Specifies whether heatmaps dissipate on zoom. By default, the radius of influence of a data point is specified by the radius option only. When dissipating is disabled, the radius option is intepreted as a radius at zoom level 0.</param>
	/// <param name="arrGradient">The color gradient of the heatmap, specified as an array of CSS color strings. All CSS3 colors are supported except for extended named colors.</param>
	/// <param name="intMaxIntensity">The maximum intensity of the heatmap. By default, heatmap colors are dynamically scaled according to the greatest concentration of points at any particular pixel on the map. This property allows you to specify a fixed maximum.</param>
	/// <param name="dblOpaticy">The opacity of the heatmap, expressed as a number between 0 and 1. Defaults to 0.6.</param>
	/// <param name="intRadius">The radius of influence for each data point, in pixels.</param>
	public GoogleMapHeatMapLayer(GoogleMapLocationCollection objDataPoints, bool blnDissipating, int intMaxIntensity, double dblOpaticy, int intRadius)
	{
		DataPoints = objDataPoints;
		Dissipating = blnDissipating;
		MaxIntensity = intMaxIntensity;
		Opacity = dblOpaticy;
		Radius = intRadius;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		objWriter.WriteAttributeString("Dissipating", Dissipating ? "1" : "0");
		objWriter.WriteAttributeString("MaxIntensity", MaxIntensity);
		objWriter.WriteAttributeString("Opacity", Opacity);
		objWriter.WriteAttributeString("Radius", Radius);
		string text = "";
		if (DataPoints != null && DataPoints.Count != 0)
		{
			foreach (GoogleMapLocation dataPoint in DataPoints)
			{
				text += (string.IsNullOrEmpty(text) ? "" : "$");
				text = ((!(dataPoint is GoogleMapWeightedLocation)) ? (text + dataPoint.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + dataPoint.Longitude.ToString(CultureInfo.InvariantCulture)) : (text + dataPoint.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + dataPoint.Longitude.ToString(CultureInfo.InvariantCulture) + ";" + ((GoogleMapWeightedLocation)dataPoint).Weight.ToString(CultureInfo.InvariantCulture)));
			}
		}
		objWriter.WriteAttributeString("DataPoints", text);
		text = "";
		foreach (Color gradientColor in GradientColors)
		{
			text += (string.IsNullOrEmpty(text) ? "" : "$");
			text += GoogleMapObject.RgbaFromColor(gradientColor);
		}
		if (!string.IsNullOrEmpty(text))
		{
			objWriter.WriteAttributeString("Gradient", text);
		}
	}
}
