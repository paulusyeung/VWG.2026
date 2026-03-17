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
public class GoogleMapRectangleOverlay : GoogleMapShapeOverlay
{
	/// <summary>
	/// The FillColor property registration.
	/// </summary>
	private static readonly SerializableProperty FillColorProperty = SerializableProperty.Register("FillColor", typeof(Color), typeof(GoogleMapRectangleOverlay));

	/// <summary>
	/// The FillOpacity property registration.
	/// </summary>
	private static readonly SerializableProperty FillOpacityProperty = SerializableProperty.Register("FillOpacity", typeof(double), typeof(GoogleMapRectangleOverlay));

	/// <summary>
	/// The BoundsSouthWest property registration.
	/// </summary>
	private static readonly SerializableProperty BoundsSouthWestProperty = SerializableProperty.Register("BoundsSouthWest", typeof(GoogleMapLocation), typeof(GoogleMapRectangleOverlay));

	/// <summary>
	/// The BoundsNorthEast property registration.
	/// </summary>
	private static readonly SerializableProperty BoundsNorthEastProperty = SerializableProperty.Register("BoundsNorthEast", typeof(GoogleMapLocation), typeof(GoogleMapRectangleOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			if (!GoogleMapLocation.Empty.Equals(BoundsNorthEast))
			{
				overlayRepresentedByPoints.Add(BoundsNorthEast);
			}
			if (!GoogleMapLocation.Empty.Equals(BoundsSouthWest))
			{
				overlayRepresentedByPoints.Add(BoundsSouthWest);
			}
			return overlayRepresentedByPoints;
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
	/// South West Bounds of overlay
	/// </summary>
	public GoogleMapLocation BoundsSouthWest
	{
		get
		{
			GoogleMapLocation googleMapLocation = GetValue<GoogleMapLocation>(BoundsSouthWestProperty);
			if (googleMapLocation == null)
			{
				googleMapLocation = new GoogleMapLocation();
				SetValue(BoundsSouthWestProperty, googleMapLocation);
			}
			return googleMapLocation;
		}
		set
		{
			SetValue(BoundsSouthWestProperty, value);
		}
	}

	/// <summary>
	/// North East Bounds of overlay 
	/// </summary>
	public GoogleMapLocation BoundsNorthEast
	{
		get
		{
			GoogleMapLocation googleMapLocation = GetValue<GoogleMapLocation>(BoundsNorthEastProperty);
			if (googleMapLocation == null)
			{
				googleMapLocation = new GoogleMapLocation();
				SetValue(BoundsNorthEastProperty, googleMapLocation);
			}
			return googleMapLocation;
		}
		set
		{
			SetValue(BoundsNorthEastProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.RectangleOverlay;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapRectangleOverlay()
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
		objWriter.WriteAttributeString("Bounds", BoundsSouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + BoundsSouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + "$" + BoundsNorthEast.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + BoundsNorthEast.Longitude.ToString(CultureInfo.InvariantCulture));
	}
}
