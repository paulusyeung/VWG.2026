using System;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides an implementation for google map Ground overlay
/// </summary>
[Serializable]
public class GoogleMapGroundOverlay : GoogleMapOverlay
{
	/// <summary>
	/// The Clickable property registration.
	/// </summary>
	private static readonly SerializableProperty ClickableProperty = SerializableProperty.Register("Clickable", typeof(bool), typeof(GoogleMapGroundOverlay));

	/// <summary>
	/// The Opacity property registration.
	/// </summary>
	private static readonly SerializableProperty OpacityProperty = SerializableProperty.Register("Opacity", typeof(double), typeof(GoogleMapGroundOverlay));

	/// <summary>
	/// The Url property registration.
	/// </summary>
	private static readonly SerializableProperty UrlProperty = SerializableProperty.Register("Url", typeof(string), typeof(GoogleMapGroundOverlay));

	/// <summary>
	/// The BoundsSouthWest property registration.
	/// </summary>
	private static readonly SerializableProperty BoundsSouthWestProperty = SerializableProperty.Register("BoundsSouthWest", typeof(GoogleMapLocation), typeof(GoogleMapGroundOverlay));

	/// <summary>
	/// The BoundsNorthEast property registration.
	/// </summary>
	private static readonly SerializableProperty BoundsNorthEastProperty = SerializableProperty.Register("BoundsNorthEast", typeof(GoogleMapLocation), typeof(GoogleMapGroundOverlay));

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
	/// The opacity of the overlay, expressed as a number between 0 and 1. Optional. Defaults to 1.
	/// </summary>
	[DefaultValue(0)]
	public double Opacity
	{
		get
		{
			return GetValue(OpacityProperty, 0.0);
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
			}
		}
	}

	/// <summary>
	/// If true, the ground overlay can receive mouse events.
	/// </summary>
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
		}
	}

	/// <summary>
	/// South West bounds of the overlay
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
	/// North East bounds of the overlay
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
	/// The Url to the image used for the overlay
	/// </summary>
	[DefaultValue("")]
	public string Url
	{
		get
		{
			return GetValue(UrlProperty, "");
		}
		set
		{
			SetValue(UrlProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.GroundOverlay;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapGroundOverlay" /> class.
	/// </summary>
	public GoogleMapGroundOverlay()
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
		objWriter.WriteAttributeString("Clickable", Clickable ? "1" : "0");
		objWriter.WriteAttributeString("Opacity", Opacity.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Url", Url);
		objWriter.WriteAttributeString("Bounds", BoundsSouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + BoundsSouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + "$" + BoundsNorthEast.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + BoundsNorthEast.Longitude.ToString(CultureInfo.InvariantCulture));
	}
}
