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
public class GoogleMapPolygonOverlay : GoogleMapShapeOverlay
{
	/// <summary>
	/// The Geodesic property registration.
	/// </summary>
	private static readonly SerializableProperty GeodesicProperty = SerializableProperty.Register("Geodesic", typeof(bool), typeof(GoogleMapPolygonOverlay));

	/// <summary>
	/// The FillColor property registration.
	/// </summary>
	private static readonly SerializableProperty FillColorProperty = SerializableProperty.Register("FillColor", typeof(Color), typeof(GoogleMapPolygonOverlay));

	/// <summary>
	/// The FillOpacity property registration.
	/// </summary>
	private static readonly SerializableProperty FillOpacityProperty = SerializableProperty.Register("FillOpacity", typeof(double), typeof(GoogleMapPolygonOverlay));

	/// <summary>
	/// The Paths property registration.
	/// </summary>
	private static readonly SerializableProperty PathsProperty = SerializableProperty.Register("Paths", typeof(GoogleMapLocationCollectionCollection), typeof(GoogleMapPolygonOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			foreach (GoogleMapLocationCollection path in Paths)
			{
				foreach (GoogleMapLocation item in path)
				{
					if (!GoogleMapLocation.Empty.Equals(item))
					{
						overlayRepresentedByPoints.Add(item);
					}
				}
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
	/// The ordered sequence of coordinates that designates a closed loop. Unlike polylines, a polygon may consist of one or more paths, so Paths is represented by a Collection of LocationCollections
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GoogleMapLocationCollectionCollection Paths
	{
		get
		{
			GoogleMapLocationCollectionCollection googleMapLocationCollectionCollection = GetValue<GoogleMapLocationCollectionCollection>(PathsProperty);
			if (googleMapLocationCollectionCollection == null)
			{
				googleMapLocationCollectionCollection = new GoogleMapLocationCollectionCollection();
				SetValue(PathsProperty, googleMapLocationCollectionCollection);
			}
			return googleMapLocationCollectionCollection;
		}
		set
		{
			SetValue(PathsProperty, value);
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
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.PolygonOverlay;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapPolygonOverlay()
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
		objWriter.WriteAttributeString("FillColor", GoogleMapObject.RgbaFromColor(FillColor));
		objWriter.WriteAttributeString("FillOpacity", FillOpacity.ToString(CultureInfo.InvariantCulture));
		if (Paths == null || Paths.Count <= 0)
		{
			return;
		}
		string text = string.Empty;
		foreach (GoogleMapLocationCollection path in Paths)
		{
			if (path.Count <= 0)
			{
				continue;
			}
			string text2 = string.Empty;
			foreach (GoogleMapLocation item in path)
			{
				text2 += (string.IsNullOrEmpty(text2) ? "" : "$");
				text2 = text2 + item.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.Longitude.ToString(CultureInfo.InvariantCulture);
			}
			text += (string.IsNullOrEmpty(text) ? "" : "$$");
			text += text2;
		}
		if (!string.IsNullOrEmpty(text))
		{
			objWriter.WriteAttributeString("Paths", text);
		}
	}
}
