using System;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides an implementation for google Polyline overlay
/// </summary>
[Serializable]
public class GoogleMapPolylineOverlay : GoogleMapShapeOverlay
{
	/// <summary>
	/// The Geodesic property registration.
	/// </summary>
	private static readonly SerializableProperty GeodesicProperty = SerializableProperty.Register("Geodesic", typeof(bool), typeof(GoogleMapPolylineOverlay));

	/// <summary>
	/// The Icons property registration.
	/// </summary>
	private static readonly SerializableProperty IconsProperty = SerializableProperty.Register("Icons", typeof(GoogleMapIconSequenceCollection), typeof(GoogleMapPolylineOverlay));

	/// <summary>
	/// The Path property registration.
	/// </summary>
	private static readonly SerializableProperty PathProperty = SerializableProperty.Register("Path", typeof(GoogleMapLocationCollection), typeof(GoogleMapPolylineOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			foreach (GoogleMapLocation item in Path)
			{
				if (!GoogleMapLocation.Empty.Equals(item))
				{
					overlayRepresentedByPoints.Add(item);
				}
			}
			return overlayRepresentedByPoints;
		}
	}

	/// <summary>
	/// The ordered sequence of coordinates of the Polyline
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GoogleMapLocationCollection Path
	{
		get
		{
			GoogleMapLocationCollection googleMapLocationCollection = GetValue<GoogleMapLocationCollection>(PathProperty);
			if (googleMapLocationCollection == null)
			{
				googleMapLocationCollection = new GoogleMapLocationCollection();
				SetValue(PathProperty, googleMapLocationCollection);
			}
			return googleMapLocationCollection;
		}
		set
		{
			SetValue(PathProperty, value);
		}
	}

	/// <summary>
	/// The icons to be rendered along the polyline.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GoogleMapIconSequenceCollection Icons
	{
		get
		{
			GoogleMapIconSequenceCollection googleMapIconSequenceCollection = GetValue<GoogleMapIconSequenceCollection>(IconsProperty);
			if (googleMapIconSequenceCollection == null)
			{
				googleMapIconSequenceCollection = new GoogleMapIconSequenceCollection();
				SetValue(IconsProperty, googleMapIconSequenceCollection);
			}
			return googleMapIconSequenceCollection;
		}
		set
		{
			SetValue(IconsProperty, value);
		}
	}

	/// <summary>
	/// When true, render each edge as a geodesic (a segment of a "great circle"). A geodesic is the shortest path between two points along the surface of the Earth. When false, render each edge as a straight line on screen
	/// </summary>
	[DefaultValue(false)]
	public bool Geodesic
	{
		get
		{
			return GetValue(GeodesicProperty, objDefault: false);
		}
		set
		{
			SetValue(GeodesicProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.PolylineOverlay;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapPolylineOverlay()
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
		objWriter.WriteAttributeString("Geodesic", Geodesic ? "1" : "0");
		if (Icons != null && Icons.Count > 0)
		{
			string text = string.Empty;
			foreach (GoogleMapIconSequence icon in Icons)
			{
				text += (string.IsNullOrEmpty(text) ? "" : "$");
				text = text + icon.Icon.Anchor.X.ToString(CultureInfo.InvariantCulture) + ";" + icon.Icon.Anchor.Y.ToString(CultureInfo.InvariantCulture) + ";" + GoogleMapObject.RgbaFromColor(icon.Icon.FillColor) + ";" + icon.Icon.FillOpacity.ToString(CultureInfo.InvariantCulture) + ";" + icon.Icon.Path.ToString() + ";" + icon.Icon.Rotation.ToString(CultureInfo.InvariantCulture) + ";" + icon.Icon.Scale.ToString(CultureInfo.InvariantCulture) + ";" + GoogleMapObject.RgbaFromColor(icon.Icon.StrokeColor) + ";" + icon.Icon.StrokeOpacity.ToString(CultureInfo.InvariantCulture) + ";" + icon.Icon.StrokeWeight.ToString(CultureInfo.InvariantCulture) + ";" + icon.Offset + ";" + icon.Repeat + ";";
			}
			objWriter.WriteAttributeString("Icons", text);
		}
		if (Path == null || Path.Count <= 0)
		{
			return;
		}
		string text2 = string.Empty;
		foreach (GoogleMapLocation item in Path)
		{
			text2 += (string.IsNullOrEmpty(text2) ? "" : "$");
			text2 = text2 + item.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.Longitude.ToString(CultureInfo.InvariantCulture);
		}
		objWriter.WriteAttributeString("Path", text2);
	}
}
