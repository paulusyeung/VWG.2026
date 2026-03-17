using System;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides an implementation for google map marker overlay
/// </summary>
[Serializable]
public class GoogleMapMarkerOverlay : GoogleMapOverlay
{
	/// <summary>
	/// The Address property registration.
	/// </summary>
	private static readonly SerializableProperty AddressProperty = SerializableProperty.Register("Address", typeof(string), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Location property registration.
	/// </summary>
	private static readonly SerializableProperty LocationProperty = SerializableProperty.Register("Location", typeof(GoogleMapLocation), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Title property registration.
	/// </summary>
	private static readonly SerializableProperty TitleProperty = SerializableProperty.Register("Title", typeof(string), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The WindowInfoContent property registration.
	/// </summary>
	private static readonly SerializableProperty WindowInfoContentProperty = SerializableProperty.Register("WindowInfoContent", typeof(string), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The AnimationType property registration.
	/// </summary>
	private static readonly SerializableProperty AnimationTypeProperty = SerializableProperty.Register("AnimationType", typeof(GoogleMapMarkerAnimationType), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Clickable property registration.
	/// </summary>
	private static readonly SerializableProperty ClickableProperty = SerializableProperty.Register("Clickable", typeof(bool), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Draggable property registration.
	/// </summary>
	private static readonly SerializableProperty DraggableProperty = SerializableProperty.Register("Draggable", typeof(bool), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Flat property registration.
	/// </summary>
	private static readonly SerializableProperty FlatProperty = SerializableProperty.Register("Flat", typeof(bool), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The RaiseOnDrag property registration.
	/// </summary>
	private static readonly SerializableProperty RaiseOnDragProperty = SerializableProperty.Register("RaiseOnDrag", typeof(bool), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Visible property registration.
	/// </summary>
	private static readonly SerializableProperty VisibleProperty = SerializableProperty.Register("Visible", typeof(bool), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The CursorType property registration.
	/// </summary>
	private static readonly SerializableProperty CursorTypeProperty = SerializableProperty.Register("CursorType", typeof(GoogleMapCursorType), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The Icon property registration.
	/// </summary>
	private static readonly SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(GoogleMapMarkerOverlay));

	/// <summary>
	/// The ShadowImage property registration.
	/// </summary>
	private static readonly SerializableProperty ShadowImageProperty = SerializableProperty.Register("ShadowImage", typeof(ResourceHandle), typeof(GoogleMapMarkerOverlay));

	internal override GoogleMapLocationCollection OverlayRepresentedByPoints
	{
		get
		{
			GoogleMapLocationCollection overlayRepresentedByPoints = base.OverlayRepresentedByPoints;
			if (!GoogleMapLocation.Empty.Equals(Location))
			{
				overlayRepresentedByPoints.Add(Location);
			}
			return overlayRepresentedByPoints;
		}
	}

	/// <summary>
	/// Gets or sets the location. If Location is set, Address property is set to empty.
	/// </summary>
	/// <value>The location.</value>
	public GoogleMapLocation Location
	{
		get
		{
			return GetValue(LocationProperty, DefaultLocation);
		}
		set
		{
			if (SetValue(LocationProperty, value))
			{
				SetValue(AddressProperty, string.Empty);
			}
		}
	}

	/// <summary>
	/// Gets or sets the overlay address. If Address is set, Location is set to empty.
	/// </summary>
	/// <value>The overlay address.</value>
	[DefaultValue("")]
	public string Address
	{
		get
		{
			return GetValue(AddressProperty, "");
		}
		set
		{
			if (SetValue(AddressProperty, value))
			{
				SetValue(LocationProperty, GoogleMapLocation.Empty);
			}
		}
	}

	/// <summary>
	/// Gets or sets the marker title.
	/// </summary>
	/// <value>The location.</value>
	[DefaultValue("")]
	public string Title
	{
		get
		{
			return GetValue(TitleProperty, "");
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	/// <summary>
	/// Gets the default map location, which is an empty location.
	/// </summary>
	/// <value>The default map location.</value>
	protected virtual GoogleMapLocation DefaultLocation => GoogleMapLocation.Empty;

	/// <summary>
	/// Gets or sets the content of the window info. Can be text or Html
	/// </summary>
	/// <value>The content of the window info.</value>
	[DefaultValue("")]
	public string WindowInfoContent
	{
		get
		{
			return GetValue(WindowInfoContentProperty, "");
		}
		set
		{
			SetValue(WindowInfoContentProperty, value);
		}
	}

	/// <summary>
	/// Animation style when marker is added to map.
	/// </summary>
	[DefaultValue(GoogleMapMarkerAnimationType.None)]
	public GoogleMapMarkerAnimationType Animation
	{
		get
		{
			return GetValue(AnimationTypeProperty, GoogleMapMarkerAnimationType.None);
		}
		set
		{
			SetValue(AnimationTypeProperty, value);
		}
	}

	/// <summary>
	/// Is Marker clickable or not
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
	/// Type of cursor
	/// </summary>
	[DefaultValue(GoogleMapCursorType.Default)]
	public GoogleMapCursorType CursorType
	{
		get
		{
			return GetValue(CursorTypeProperty, GoogleMapCursorType.Default);
		}
		set
		{
			SetValue(CursorTypeProperty, value);
		}
	}

	/// <summary>
	/// Is marker draggable
	/// </summary>
	[DefaultValue(false)]
	public bool Draggable
	{
		get
		{
			return GetValue(DraggableProperty, objDefault: false);
		}
		set
		{
			SetValue(DraggableProperty, value);
		}
	}

	/// <summary>
	/// Is marker flat (no shadows)
	/// </summary>
	[DefaultValue(false)]
	public bool Flat
	{
		get
		{
			return GetValue(FlatProperty, objDefault: false);
		}
		set
		{
			SetValue(FlatProperty, value);
		}
	}

	/// <summary>
	/// If false, disables raising and lowering the marker on drag
	/// </summary>
	[DefaultValue(true)]
	public bool RaiseOnDrag
	{
		get
		{
			return GetValue(RaiseOnDragProperty, objDefault: true);
		}
		set
		{
			SetValue(RaiseOnDragProperty, value, objDefaultValue: true);
		}
	}

	/// <summary>
	/// Marker visibility
	/// </summary>
	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			return GetValue(VisibleProperty, objDefault: true);
		}
		set
		{
			SetValue(VisibleProperty, value, objDefaultValue: true);
		}
	}

	/// <summary>
	/// Icon/Image for the marker
	/// </summary>
	public ResourceHandle Icon
	{
		get
		{
			return GetValue<ResourceHandle>(IconProperty, null);
		}
		set
		{
			SetValue(IconProperty, value);
		}
	}

	/// <summary>
	/// Image to show as shadow image for a marker
	/// </summary>
	public ResourceHandle ShadowImage
	{
		get
		{
			return GetValue<ResourceHandle>(ShadowImageProperty, null);
		}
		set
		{
			SetValue(ShadowImageProperty, value);
		}
	}

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public override GoogleMapOverlayType OverlayType => GoogleMapOverlayType.MarkerOverlay;

	/// <summary>
	/// Gets or sets the location. If Location is set, Address property is set to empty.
	/// </summary>
	/// <value>The location.</value>
	[Obsolete("Use Location")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public GoogleMapLocation MapLocation
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value;
		}
	}

	/// <summary>
	/// Gets or sets the overlay address. If Address is set, Location is set to empty.
	/// </summary>
	/// <value>The overlay address.</value>
	[Obsolete("Use Address")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public string MapAddress
	{
		get
		{
			return Address;
		}
		set
		{
			Address = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapMarkerOverlay()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	/// <param name="dblLatitude">The latitude.</param>
	/// <param name="dblLongitude">The longitude.</param>
	public GoogleMapMarkerOverlay(double dblLatitude, double dblLongitude)
	{
		Location = new GoogleMapLocation(dblLatitude, dblLongitude);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	/// <param name="dblLatitude">The latitude.</param>
	/// <param name="dblLongitude">The longitude.</param>
	/// <param name="strWindowInfoContent">The content of the marker window info.</param>
	public GoogleMapMarkerOverlay(double dblLatitude, double dblLongitude, string strWindowInfoContent)
	{
		Location = new GoogleMapLocation(dblLatitude, dblLongitude);
		WindowInfoContent = strWindowInfoContent;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	/// <param name="strAddress">The STR address.</param>
	public GoogleMapMarkerOverlay(string strAddress)
	{
		Address = strAddress;
	}

	/// <summary>
	/// Should designer serialize map location.
	/// </summary>
	/// <returns></returns>
	protected bool ShouldSerializeLocation()
	{
		return !Location.Equals(DefaultLocation);
	}

	/// <summary>
	/// Should designer serialize map address
	/// </summary>
	/// <returns></returns>
	protected bool ShouldSerializeAddress()
	{
		return !string.IsNullOrEmpty(Address);
	}

	/// <summary>
	/// Renders the overlay attributes.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		string address = Address;
		if (!string.IsNullOrEmpty(address))
		{
			objWriter.WriteAttributeString("MARS", address);
		}
		else
		{
			string text = Location.Latitude.ToString(CultureInfo.InvariantCulture);
			if (!string.IsNullOrEmpty(text))
			{
				objWriter.WriteAttributeString("LAT", text);
			}
			string text2 = Location.Longitude.ToString(CultureInfo.InvariantCulture);
			if (!string.IsNullOrEmpty(text2))
			{
				objWriter.WriteAttributeString("LNG", text2);
			}
		}
		objWriter.WriteAttributeString("TTL", Title);
		if (!string.IsNullOrEmpty(WindowInfoContent))
		{
			objWriter.WriteAttributeString("WIC", WindowInfoContent);
		}
		objWriter.WriteAttributeString("Animation", Animation.ToString());
		objWriter.WriteAttributeString("Clickable", Clickable ? "1" : "0");
		objWriter.WriteAttributeString("Draggable", Draggable ? "1" : "0");
		objWriter.WriteAttributeString("RaiseOnDrag", RaiseOnDrag ? "1" : "0");
		objWriter.WriteAttributeString("Visible", Visible ? "1" : "0");
		objWriter.WriteAttributeString("Flat", Flat ? "1" : "0");
		if (CursorType != GoogleMapCursorType.Default)
		{
			objWriter.WriteAttributeString("Cursor", CursorType.ToString().Replace("_", "-").ToLower());
		}
		if (Icon != null)
		{
			objWriter.WriteAttributeString("Icon", Icon.ToString());
		}
		if (ShadowImage != null)
		{
			objWriter.WriteAttributeString("ShadowImage", ShadowImage.ToString());
		}
	}
}
