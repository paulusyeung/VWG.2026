using System;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides an implementation for GoogleMap InfoWindow overlay
/// </summary>
[Serializable]
public class GoogleMapInfoWindowOverlay : GoogleMapOverlay
{
	/// <summary>
	/// The Content property registration.
	/// </summary>
	private static readonly SerializableProperty ContentProperty = SerializableProperty.Register("Content", typeof(string), typeof(GoogleMapInfoWindowOverlay));

	/// <summary>
	/// The DisableAutoPan property registration.
	/// </summary>
	private static readonly SerializableProperty DisableAutoPanProperty = SerializableProperty.Register("DisableAutoPan", typeof(bool), typeof(GoogleMapInfoWindowOverlay));

	/// <summary>
	/// The MaxWidth property registration.
	/// </summary>
	private static readonly SerializableProperty MaxWidthProperty = SerializableProperty.Register("MaxWidth", typeof(double), typeof(GoogleMapInfoWindowOverlay));

	/// <summary>
	/// The PixelOffsetWidth property registration.
	/// </summary>
	private static readonly SerializableProperty PixelOffsetWidthProperty = SerializableProperty.Register("PixelOffsetWidth", typeof(int), typeof(GoogleMapInfoWindowOverlay));

	/// <summary>
	/// The PixelOffsetHeight property registration.
	/// </summary>
	private static readonly SerializableProperty PixelOffsetHeightProperty = SerializableProperty.Register("PixelOffsetHeight", typeof(int), typeof(GoogleMapInfoWindowOverlay));

	/// <summary>
	/// The Position property registration.
	/// </summary>
	private static readonly SerializableProperty PositionProperty = SerializableProperty.Register("Position", typeof(GoogleMapLocation), typeof(GoogleMapInfoWindowOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			if (!GoogleMapLocation.Empty.Equals(Position))
			{
				overlayRepresentedByPoints.Add(Position);
			}
			return overlayRepresentedByPoints;
		}
	}

	/// <summary>
	/// The LatLng at which to display this InfoWindow
	/// </summary>
	public GoogleMapLocation Position
	{
		get
		{
			GoogleMapLocation googleMapLocation = GetValue<GoogleMapLocation>(PositionProperty);
			if (googleMapLocation == null)
			{
				googleMapLocation = new GoogleMapLocation();
				SetValue(PositionProperty, googleMapLocation);
			}
			return googleMapLocation;
		}
		set
		{
			SetValue(PositionProperty, value);
		}
	}

	/// <summary>
	/// The height offset, in pixels, of the tip of the info window from the point on the map at whose geographical coordinates the info window is anchored. If an InfoWindow is opened with an anchor, the pixelOffset will be calculated from the top-center of the anchor's bounds.
	/// </summary>
	[DefaultValue(0)]
	public int PixelOffsetHeight
	{
		get
		{
			return GetValue(PixelOffsetHeightProperty, 0);
		}
		set
		{
			if (PixelOffsetHeight != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("PixelOffsetHeight can not be negative");
				}
				SetValue(PixelOffsetHeightProperty, value);
			}
		}
	}

	/// <summary>
	/// The width offset, in pixels, of the tip of the info window from the point on the map at whose geographical coordinates the info window is anchored. If an InfoWindow is opened with an anchor, the pixelOffset will be calculated from the top-center of the anchor's bounds.
	/// </summary>
	[DefaultValue(0)]
	public int PixelOffsetWidth
	{
		get
		{
			return GetValue(PixelOffsetWidthProperty, 0);
		}
		set
		{
			if (PixelOffsetWidth != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("PixelOffsetWidth can not be negative");
				}
				SetValue(PixelOffsetWidthProperty, value);
			}
		}
	}

	/// <summary>
	/// Maximum width of the infowindow, regardless of content's width. This value is only considered if it is set before a call to open. To change the maximum width when changing content, call close, setOptions, and then open.
	/// </summary>
	[DefaultValue(0)]
	public double MaxWidth
	{
		get
		{
			return GetValue(MaxWidthProperty, 0.0);
		}
		set
		{
			if (MaxWidth != value)
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("MaxWidth must be greater than zero");
				}
				SetValue(MaxWidthProperty, value);
			}
		}
	}

	/// <summary>
	/// Disable auto-pan on open. By default, the info window will pan the map so that it is fully visible when it opens.
	/// </summary>
	[DefaultValue(false)]
	public bool DisableAutoPan
	{
		get
		{
			return GetValue(DisableAutoPanProperty, objDefault: false);
		}
		set
		{
			SetValue(DisableAutoPanProperty, value);
		}
	}

	/// <summary>
	/// Content to display in the InfoWindow. This can be an HTML element, a plain-text string, or a string containing HTML. The InfoWindow will be sized according to the content. To set an explicit size for the content, set content to be a HTML element with that size.
	/// </summary>
	[DefaultValue("")]
	public string Content
	{
		get
		{
			return GetValue(ContentProperty, "");
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.InfoWindowOverlay;

	/// <summary>
	/// Initialize object instance
	/// </summary>
	public GoogleMapInfoWindowOverlay()
	{
	}

	/// <summary>
	/// Renders the overlay attributes
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		objWriter.WriteAttributeString("Content", Content);
		objWriter.WriteAttributeString("DisableAutoPan", DisableAutoPan ? "1" : "0");
		objWriter.WriteAttributeString("MaxWidth", MaxWidth.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("PixelOffset", PixelOffsetWidth.ToString(CultureInfo.InvariantCulture) + ";" + PixelOffsetHeight.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Position", Position.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + Position.Longitude.ToString(CultureInfo.InvariantCulture));
	}
}
