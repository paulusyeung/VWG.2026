using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides an implementation for google map marker overlay
/// </summary>
[Serializable]
public class GoogleMapCircleOverlay : GoogleMapShapeOverlay
{
	/// <summary>
	/// The FillColor property registration.
	/// </summary>
	private static readonly SerializableProperty FillColorProperty = SerializableProperty.Register("FillColor", typeof(Color), typeof(GoogleMapCircleOverlay));

	/// <summary>
	/// The FillOpacity property registration.
	/// </summary>
	private static readonly SerializableProperty FillOpacityProperty = SerializableProperty.Register("FillOpacity", typeof(double), typeof(GoogleMapCircleOverlay));

	/// <summary>
	/// The Center property registration.
	/// </summary>
	private static readonly SerializableProperty CenterProperty = SerializableProperty.Register("Center", typeof(GoogleMapLocation), typeof(GoogleMapCircleOverlay));

	/// <summary>
	/// The Radius property registration.
	/// </summary>
	private static readonly SerializableProperty RadiusProperty = SerializableProperty.Register("Radius", typeof(double), typeof(GoogleMapCircleOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			if (!GoogleMapLocation.Empty.Equals(Center))
			{
				overlayRepresentedByPoints.Add(Center);
			}
			return overlayRepresentedByPoints;
		}
	}

	/// <summary>
	/// The radius in meters on the Earth's surface
	/// </summary>
	[DefaultValue(1)]
	public double Radius
	{
		get
		{
			return GetValue(RadiusProperty, 1.0);
		}
		set
		{
			SetValue(RadiusProperty, value);
		}
	}

	/// <summary>
	/// The fill color. All CSS3 colors are supported except for extended named colors.
	/// </summary>
	public Color FillColor
	{
		get
		{
			return GetValue<Color>(FillColorProperty);
		}
		set
		{
			SetValue(FillColorProperty, value);
		}
	}

	/// <summary>
	/// The fill opacity between 0.0 and 1.0
	/// </summary>
	[DefaultValue(0)]
	public double FillOpacity
	{
		get
		{
			return GetValue(FillOpacityProperty, 0.0);
		}
		set
		{
			if (FillOpacity != value)
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Opacity needs to be between 0 and 1");
				}
				SetValue(FillOpacityProperty, value);
			}
		}
	}

	/// <summary>
	/// The center
	/// </summary>
	public GoogleMapLocation Center
	{
		get
		{
			GoogleMapLocation googleMapLocation = GetValue<GoogleMapLocation>(CenterProperty);
			if (googleMapLocation == null)
			{
				googleMapLocation = new GoogleMapLocation();
				SetValue(CenterProperty, googleMapLocation);
			}
			return googleMapLocation;
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.CircleOverlay;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapCircleOverlay()
	{
	}

	/// <summary>
	/// Renders the overlay attributes.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		objWriter.WriteAttributeString("FillColor", GoogleMapObject.RgbaFromColor(FillColor));
		objWriter.WriteAttributeString("FillOpacity", FillOpacity.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Center", Center.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + Center.Longitude.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Radius", Radius.ToString(CultureInfo.InvariantCulture));
	}
}
