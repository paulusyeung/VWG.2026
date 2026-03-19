using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Google;
using Gizmox.WebGUI.Forms.Google.Design.Editors;
using Gizmox.WebGUI.Forms.Google.Skins;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Professional;

/// <summary>
/// GoogleMap control, wrapper for GoogleMap API V3
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(GoogleMap), "Google.GoogleMap_45.png")]
[MetadataTag("GoogleMap")]
[Skin(typeof(GoogleMapSkin))]
public class GoogleMap : Control, IRequiresRegistration
{
	/// <summary>
	/// The MapType property registration.
	/// </summary>
	private static readonly SerializableProperty MapTypeProperty = SerializableProperty.Register("MapType", typeof(GoogleMapType), typeof(GoogleMap));

	/// <summary>
	/// The MapUsingSensor property registration.
	/// </summary>
	private static readonly SerializableProperty MapUsingSensorProperty = SerializableProperty.Register("UsingSensor", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The MapUsingClusterer property registration.
	/// </summary>
	private static readonly SerializableProperty MapUsingClustererProperty = SerializableProperty.Register("UsingClusterer", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The DisableDoubleClickZoom property registration.
	/// </summary>
	private static readonly SerializableProperty MapDoubleClickZoomsProperty = SerializableProperty.Register("DoubleClickZooms", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapTypeControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapTypeControlProperty = SerializableProperty.Register("ShowMapTypeControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The MapControlType property registration.
	/// </summary>
	private static readonly SerializableProperty MapControlTypeProperty = SerializableProperty.Register("MapControlType", typeof(GoogleMapControlType), typeof(GoogleMap));

	/// <summary>
	/// The MapControlMaps property registration.
	/// </summary>
	private static readonly SerializableProperty MapControlMapsProperty = SerializableProperty.Register("MapControlMaps", typeof(GoogleMapMapTypes), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Type Control
	/// </summary>
	private static readonly SerializableProperty MapControlPositionProperty = SerializableProperty.Register("MapControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapZoomControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapZoomControlProperty = SerializableProperty.Register("ShowMapZoomControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The MapZoomControlType property registration.
	/// </summary>
	private static readonly SerializableProperty MapZoomControlTypeProperty = SerializableProperty.Register("MapZoomControlType", typeof(GoogleMapZoomControlType), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Zoom Control
	/// </summary>
	private static readonly SerializableProperty MapZoomControlPositionProperty = SerializableProperty.Register("MapZoomControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapStreetviewControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapStreetviewControlProperty = SerializableProperty.Register("ShowMapStreetviewControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Streetview Control
	/// </summary>
	private static readonly SerializableProperty MapStreetviewControlPositionProperty = SerializableProperty.Register("MapStreetviewControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapPanControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapPanControlProperty = SerializableProperty.Register("ShowMapPanControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Pan Control
	/// </summary>
	private static readonly SerializableProperty MapPanControlPositionProperty = SerializableProperty.Register("MapPanControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapPanControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapRotateControlProperty = SerializableProperty.Register("ShowMapRotateControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Pan Control
	/// </summary>
	private static readonly SerializableProperty MapRotateControlPositionProperty = SerializableProperty.Register("MapRotateControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The ShowMapPanControl property registration.
	/// </summary>
	private static readonly SerializableProperty ShowMapScaleControlProperty = SerializableProperty.Register("ShowMapScaleControl", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The Position of the Map Pan Control
	/// </summary>
	private static readonly SerializableProperty MapScaleControlPositionProperty = SerializableProperty.Register("MapScaleControlPosition", typeof(GoogleMapControlPositionType), typeof(GoogleMap));

	/// <summary>
	/// The DraggingEnabled property registration.
	/// </summary>
	private static readonly SerializableProperty MapDraggingEnabledProperty = SerializableProperty.Register("MapDraggingEnabled", typeof(bool), typeof(GoogleMap));

	/// <summary>
	/// The MapsAPIKey property registration.
	/// </summary>
	private static readonly SerializableProperty MapAPIKeyProperty = SerializableProperty.Register("MapAPIKey", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The MapLanguage property registration.
	/// </summary>
	private static readonly SerializableProperty MapLanguageProperty = SerializableProperty.Register("MapLanguage", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The MapSpecificAPIVersion property registration.
	/// </summary>
	private static readonly SerializableProperty MapSpecificAPIVersionProperty = SerializableProperty.Register("SpecificAPIVersion", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The Overlayes property registration.
	/// </summary>
	private static readonly SerializableProperty MapOverlaysProperty = SerializableProperty.Register("MapOverlays", typeof(GoogleMapOverlayCollection), typeof(GoogleMap));

	/// <summary>
	/// The Layers property registration.
	/// </summary>
	private static readonly SerializableProperty MapLayersProperty = SerializableProperty.Register("MapLayers", typeof(GoogleMapLayerCollection), typeof(GoogleMap));

	/// <summary>
	/// The current LatLngBounds property registration
	/// </summary>
	private static readonly SerializableProperty MapBoundsProperty = SerializableProperty.Register("MapBounds", typeof(GoogleMapLatLngBounds), typeof(GoogleMap));

	/// <summary>
	/// The current Heading property registration
	/// </summary>
	private static readonly SerializableProperty MapHeadingProperty = SerializableProperty.Register("MapHeading", typeof(double), typeof(GoogleMap));

	/// <summary>
	/// The Location property registration.
	/// </summary>
	private static readonly SerializableProperty MapLocationProperty = SerializableProperty.Register("MapLocation", typeof(GoogleMapLocation), typeof(GoogleMap));

	/// <summary>
	/// The MapAddress property registration.
	/// </summary>
	private static readonly SerializableProperty MapAddressProperty = SerializableProperty.Register("MapAddress", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The Map Zoom level property registration
	/// </summary>
	private static readonly SerializableProperty MapZoomLevelProperty = SerializableProperty.Register("MapZoomLevel", typeof(int), typeof(GoogleMap));

	/// <summary>
	/// The display name for OpenStreatMap map type
	/// </summary>
	private static readonly SerializableProperty MapOpenStreatMapNameProperty = SerializableProperty.Register("MapOpenStreatMapName", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The base url for OpenStreatMap map type tiles
	/// </summary>
	private static readonly SerializableProperty MapOpenStreatMapUrlProperty = SerializableProperty.Register("MapOpenStreatMapUrl", typeof(string), typeof(GoogleMap));

	/// <summary>
	/// The MapRightClick event registration.
	/// </summary>
	private static readonly SerializableEvent MapRightClickEvent;

	/// <summary>
	/// The MapDoubleClick event registration.
	/// </summary>
	private static readonly SerializableEvent MapDoubleClickEvent;

	/// <summary>
	/// The MapClick event registration.
	/// </summary>
	private static readonly SerializableEvent MapClickEvent;

	/// <summary>
	/// The BoundsChanged event registration
	/// </summary>
	private static readonly SerializableEvent MapBoundsChangedEvent;

	/// <summary>
	/// The HeadingChanged event registration
	/// </summary>
	private static readonly SerializableEvent MapHeadingChangedEvent;

	/// <summary>
	/// The LocationChanged event registration.
	/// </summary>
	private static readonly SerializableEvent MapLocationChangedEvent;

	/// <summary>
	/// The MapAddressChanged event registration.
	/// </summary>
	private static readonly SerializableEvent MapAddressChangedEvent;

	/// <summary>
	/// The MapAddressGEOsearched event registration.
	/// </summary>
	private static readonly SerializableEvent MapAddressGEOSearchedEvent;

	/// <summary>
	/// The MapZoomLevelChanged event registration
	/// </summary>
	private static readonly SerializableEvent MapZoomLevelChangedEvent;

	/// <summary>
	/// The MapTypeChanged event registration
	/// </summary>
	private static readonly SerializableEvent MapTypeChangedEvent;

	/// <summary>
	/// Fires when Map overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapOverlayClickEvent;

	/// <summary>
	/// Fires when map overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when map overlay has been dragged and has a new position
	/// </summary>
	private static readonly SerializableEvent MapOverlayLocationChangedEvent;

	/// <summary>
	/// Fires when map overlay is right clicked
	/// </summary>
	private static readonly SerializableEvent MapOverlayRightClickEvent;

	/// <summary>
	/// Fires when Map overlay InfoWindow is opened
	/// </summary>
	private static readonly SerializableEvent MapOverlayInfoOpenedEvent;

	/// <summary>
	/// Fires when Map overlay InfoWindow is closed
	/// </summary>
	private static readonly SerializableEvent MapOverlayInfoClosedEvent;

	/// <summary>
	/// Fires when a reference point is clicked on Kml Layer
	/// </summary>
	private static readonly SerializableEvent MapKmlLayerClickEvent;

	/// <summary>
	/// Fires when a reference point is clicked on Weather Layer
	/// </summary>
	private static readonly SerializableEvent MapWeatherLayerClickEvent;

	/// <summary>
	/// Fires when a path of a Polyline overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapPolylineOverlayClickEvent;

	/// <summary>
	/// Fires when a path of a Polyline overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapPolylineOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when a path of a Polylien overlay is right clicked
	/// </summary>
	private static readonly SerializableEvent MapPolylineOverlayRightClickEvent;

	/// <summary>
	/// Fires when a Polygon overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapPolygonOverlayClickEvent;

	/// <summary>
	/// Fires whena Polygon overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapPolygonOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when a Polygon overlay is right clicked
	/// </summary>
	private static readonly SerializableEvent MapPolygonOverlayRightClickEvent;

	/// <summary>
	/// Fires when a Rectangle overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapRectangleOverlayClickEvent;

	/// <summary>
	/// Fires whena Rectangle overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapRectangleOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when a Rectangle overlay is right clicked
	/// </summary>
	private static readonly SerializableEvent MapRectangleOverlayRightClickEvent;

	/// <summary>
	/// Fires when a Circle overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapCircleOverlayClickEvent;

	/// <summary>
	/// Fires whena Circle overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapCircleOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when a Circle overlay is right clicked
	/// </summary>
	private static readonly SerializableEvent MapCircleOverlayRightClickEvent;

	/// <summary>
	/// Fires when a Ground overlay is clicked
	/// </summary>
	private static readonly SerializableEvent MapGroundOverlayClickEvent;

	/// <summary>
	/// Fires whena Ground overlay is double clicked
	/// </summary>
	private static readonly SerializableEvent MapGroundOverlayDoubleClickEvent;

	/// <summary>
	/// Fires when an InfoWindow overlay is closed 
	/// </summary>
	private static readonly SerializableEvent MapInfoWindowClosedEvent;

	/// <summary>
	/// Array storing queued FitBounds or PanToBounds commands pending next update of attributes.
	/// </summary>
	private ArrayList marrMapLatLngBoundsQueue = new ArrayList();

	/// <summary>
	/// Flag to indicate to rendering attributes if Location/Address should be rendered when Bounds are changing too
	/// </summary>
	private bool mblnLocationHasChanged;

	/// <summary>
	/// Gets the handler for MapOverlayClick
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayClickEvent);

	/// <summary>
	/// Gets the handler for marker overlay double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayDoubleClickEvent);

	/// <summary>
	/// Gets the handler for marker overlay location changed
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayLocationChangedHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayLocationChangedEvent);

	/// <summary>
	/// Gets the handler for marker overlay right click
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayRightClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayRightClickEvent);

	/// <summary>
	/// Gets the handler for MapOverlayInfoOpened
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayInfoOpenedHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayInfoOpenedEvent);

	/// <summary>
	/// Gets the handler for MapOverlayInfoClosed
	/// </summary>
	private GoogleMapOverlayEventHandler MapOverlayInfoClosedHandler => (GoogleMapOverlayEventHandler)GetHandler(MapOverlayInfoClosedEvent);

	/// <summary>
	/// Get the handler for polyline click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolylineClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolylineOverlayClickEvent);

	/// <summary>
	/// Get the handler for polyline double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolylineDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolylineOverlayDoubleClickEvent);

	/// <summary>
	/// Get the handler for Polyline right click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolylineRightClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolylineOverlayRightClickEvent);

	/// <summary>
	/// Get the handler for Polygon click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolygonClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolygonOverlayClickEvent);

	/// <summary>
	/// Get the handler for polygon double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolygonDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolygonOverlayDoubleClickEvent);

	/// <summary>
	/// Get the handler for Polygon right click
	/// </summary>
	private GoogleMapOverlayEventHandler MapPolygonRightClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapPolygonOverlayRightClickEvent);

	/// <summary>
	/// Get the handler for Rectangle click
	/// </summary>
	private GoogleMapOverlayEventHandler MapRectangleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapRectangleOverlayClickEvent);

	/// <summary>
	/// Get the handler for Rectangle double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapRectangleDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapRectangleOverlayDoubleClickEvent);

	/// <summary>
	/// Get the handler for Rectangle right click
	/// </summary>
	private GoogleMapOverlayEventHandler MapRectangleRightClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapRectangleOverlayRightClickEvent);

	/// <summary>
	/// Get the handler for Circle click
	/// </summary>
	private GoogleMapOverlayEventHandler MapCircleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapCircleOverlayClickEvent);

	/// <summary>
	/// Get the handler for Circle double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapCircleDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapCircleOverlayDoubleClickEvent);

	/// <summary>
	/// Get the handler for Circle right click
	/// </summary>
	private GoogleMapOverlayEventHandler MapCircleRightClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapCircleOverlayRightClickEvent);

	/// <summary>
	/// Get the handler for Ground click
	/// </summary>
	private GoogleMapOverlayEventHandler MapGroundClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapGroundOverlayClickEvent);

	/// <summary>
	/// Get the handler for Ground double click
	/// </summary>
	private GoogleMapOverlayEventHandler MapGroundDoubleClickHandler => (GoogleMapOverlayEventHandler)GetHandler(MapGroundOverlayDoubleClickEvent);

	/// <summary>
	/// Get the handler for Info Window Closed
	/// </summary>
	private GoogleMapOverlayEventHandler MapInfoWindowClosedHandler => (GoogleMapOverlayEventHandler)GetHandler(MapInfoWindowClosedEvent);

	/// <summary>
	/// Gets the handler for map Kml Click
	/// </summary>
	private GoogleMapLayerEventHandler MapKmlLayerClickHandler => (GoogleMapLayerEventHandler)GetHandler(MapKmlLayerClickEvent);

	/// <summary>
	/// Get the handler for map Weather layer click
	/// </summary>
	private GoogleMapLayerEventHandler MapWeatherLayerClickHandler => (GoogleMapLayerEventHandler)GetHandler(MapWeatherLayerClickEvent);

	/// <summary>
	/// Gets the handler for the map click event
	/// </summary>
	private GoogleMapEventHandler MapClickHandler => (GoogleMapEventHandler)GetHandler(MapClickEvent);

	/// <summary>
	/// Gets the handler for the map double click handler
	/// </summary>
	private GoogleMapEventHandler MapDoubleClickHandler => (GoogleMapEventHandler)GetHandler(MapDoubleClickEvent);

	/// <summary>
	/// Gets the handler for the map right click handler
	/// </summary>
	private GoogleMapEventHandler MapRightClickHandler => (GoogleMapEventHandler)GetHandler(MapRightClickEvent);

	/// <summary>
	/// Gets the handler for the map bounds changed event
	/// </summary>
	private EventHandler MapBoundsChangedHandler => (EventHandler)GetHandler(MapBoundsChangedEvent);

	/// <summary>
	/// Gets the handler for the map heading changed event
	/// </summary>
	private EventHandler MapHeadingChangedHandler => (EventHandler)GetHandler(MapHeadingChangedEvent);

	/// <summary>
	/// Gets the handler for the map location changed event.
	/// </summary>
	private EventHandler MapLocationChangedHandler => (EventHandler)GetHandler(MapLocationChangedEvent);

	/// <summary>
	/// Gets the handler for the MapAddressGEOsearched event.
	/// </summary>
	private EventHandler MapAddressGEOSearchedHandler => (EventHandler)GetHandler(MapAddressGEOSearchedEvent);

	/// <summary>
	/// Gets the handler for the MapAddressChanged event.
	/// </summary>
	private EventHandler MapAddressChangedHandler => (EventHandler)GetHandler(MapAddressChangedEvent);

	/// <summary>
	/// Gets the handler for the MapZoomLevelChanged event
	/// </summary>
	private EventHandler MapZoomLevelChangedHandler => (EventHandler)GetHandler(MapZoomLevelChangedEvent);

	/// <summary>
	/// Gets the handler for the MapTypeChanged event
	/// </summary>
	private EventHandler MapTypeChangedHandler => (EventHandler)GetHandler(MapTypeChangedEvent);

	protected override string ClientUpdateHandler => "GoogleMap_UpdateParameters";

	/// <summary>
	/// GoogleMap needs update after Docking change
	/// </summary>
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
			if (base.Dock != value)
			{
				base.Dock = value;
				base.Update(blnRedrawOnly: true, blnUseClientUpdateHandler: false);
			}
		}
	}

	/// <summary>
	/// Gets the overlays.
	/// </summary>
	/// <value>The overlays.</value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("Gizmox.WebGUI.Forms.Google.GoogleOverlayCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design", typeof(UITypeEditor))]
	[SRCategory("GoogleMap")]
	[SRDescription("Overlays active on the map.")]
	[WebEditor(typeof(GoogleMapOverlayCollectionWebEditor), typeof(WebUITypeEditor))]
	public GoogleMapOverlayCollection MapOverlays
	{
		get
		{
			GoogleMapOverlayCollection googleMapOverlayCollection = GetValue<GoogleMapOverlayCollection>(MapOverlaysProperty, null);
			if (googleMapOverlayCollection == null)
			{
				SetValue(MapOverlaysProperty, googleMapOverlayCollection = new GoogleMapOverlayCollection(this));
			}
			return googleMapOverlayCollection;
		}
	}

	/// <summary>
	/// Gets the layers.
	/// </summary>
	/// <value>The layers.</value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("Gizmox.WebGUI.Forms.Google.GoogleLayerCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design", typeof(UITypeEditor))]
	[SRCategory("GoogleMap")]
	[SRDescription("Layers active on the map.")]
	[WebEditor(typeof(GoogleMapLayerCollectionWebEditor), typeof(WebUITypeEditor))]
	public GoogleMapLayerCollection MapLayers
	{
		get
		{
			GoogleMapLayerCollection googleMapLayerCollection = GetValue<GoogleMapLayerCollection>(MapLayersProperty, null);
			if (googleMapLayerCollection == null)
			{
				SetValue(MapLayersProperty, googleMapLayerCollection = new GoogleMapLayerCollection(this));
			}
			return googleMapLayerCollection;
		}
	}

	/// <summary>
	/// Gets or sets the type of the map.
	/// </summary>
	/// <value>The type of the map.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The current map type.")]
	[DefaultValue(GoogleMapType.RoadMap)]
	public GoogleMapType MapType
	{
		get
		{
			return GetValue(MapTypeProperty, GoogleMapType.RoadMap);
		}
		set
		{
			if (MapType != value)
			{
				SetValue(MapTypeProperty, value);
				OnMapTypeChanged(EventArgs.Empty);
				Update();
			}
		}
	}

	/// <summary>
	/// Is a GPS sensor being used 
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Is GPS sensor device being used.")]
	[DefaultValue(false)]
	public bool MapUsingSensor
	{
		get
		{
			return GetValue(MapUsingSensorProperty, objDefault: false);
		}
		set
		{
			if (MapUsingSensor != value)
			{
				SetValue(MapUsingSensorProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Is a markerClusterer being used for marker overlays
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Is a markerClusterer being used for marker overlays.")]
	[DefaultValue(false)]
	public bool MapUsingClusterer
	{
		get
		{
			return GetValue(MapUsingClustererProperty, objDefault: false);
		}
		set
		{
			if (MapUsingClusterer != value)
			{
				SetValue(MapUsingClustererProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Gets or sets the GoogleMap language, blank for default.
	/// </summary>
	/// <value>The GoogleMap language or blank for default</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The GoogleMap language used or blank for default.")]
	[DefaultValue("")]
	public string MapLanguage
	{
		get
		{
			return GetValue(MapLanguageProperty, "");
		}
		set
		{
			if (MapLanguage != value)
			{
				SetValue(MapLanguageProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Gets or sets the specific GoogleMap API Version to use, blank for default (most recent version).
	/// </summary>
	/// <value>The specific GoogleMap API Version to use, blank for default (most recent version)</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The specific GoogleMap API Version to use, blank for default (most recent version).")]
	[DefaultValue("")]
	public string MapSpecificAPIVersion
	{
		get
		{
			return GetValue(MapSpecificAPIVersionProperty, "");
		}
		set
		{
			if (MapSpecificAPIVersion != value)
			{
				SetValue(MapSpecificAPIVersionProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating wheather double clicking the map changes the zoom
	/// </summary>
	/// <value><c>true</c> if double clicking the map zooms the map, otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should double clicking the map zoom the map.")]
	[DefaultValue(true)]
	public bool MapDoubleClickZooms
	{
		get
		{
			return GetValue(MapDoubleClickZoomsProperty, objDefault: true);
		}
		set
		{
			if (MapDoubleClickZooms != value)
			{
				SetValue(MapDoubleClickZoomsProperty, value, objDefaultValue: true);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Map Heading in degrees, 0 being true North
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Map Heading in degrees, 0 being true North.")]
	[DefaultValue(0)]
	public double MapHeading
	{
		get
		{
			return GetValue(MapHeadingProperty, 0.0);
		}
		set
		{
			if (MapHeading != value)
			{
				SetValue(MapHeadingProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map type selection control.
	/// </summary>
	/// <value><c>true</c> if to show the map type control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Map Type control be shown on the map.")]
	[DefaultValue(true)]
	public bool ShowMapTypeControl
	{
		get
		{
			return GetValue(ShowMapTypeControlProperty, objDefault: true);
		}
		set
		{
			if (ShowMapTypeControl != value)
			{
				SetValue(ShowMapTypeControlProperty, value, objDefaultValue: true);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map zoom control.
	/// </summary>
	/// <value><c>true</c> if to show the map zoom control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Zoom control be shown on the map.")]
	[DefaultValue(true)]
	public bool ShowMapZoomControl
	{
		get
		{
			return GetValue(ShowMapZoomControlProperty, objDefault: true);
		}
		set
		{
			if (ShowMapZoomControl != value)
			{
				SetValue(ShowMapZoomControlProperty, value, objDefaultValue: true);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map Streetview control.
	/// </summary>
	/// <value><c>true</c> if to show the map Streetview control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Streetview control be shown on the map.")]
	[DefaultValue(true)]
	public bool ShowMapStreetviewControl
	{
		get
		{
			return GetValue(ShowMapStreetviewControlProperty, objDefault: true);
		}
		set
		{
			if (ShowMapStreetviewControl != value)
			{
				SetValue(ShowMapStreetviewControlProperty, value, objDefaultValue: true);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map Pan control.
	/// </summary>
	/// <value><c>true</c> if to show the map Pan control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Pan control be shown on the map.")]
	[DefaultValue(false)]
	public bool ShowMapPanControl
	{
		get
		{
			return GetValue(ShowMapPanControlProperty, objDefault: false);
		}
		set
		{
			if (ShowMapPanControl != value)
			{
				SetValue(ShowMapPanControlProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map Rotate control.
	/// </summary>
	/// <value><c>true</c> if to show the map Rotate control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Rotate control be shown on the map.")]
	[DefaultValue(false)]
	public bool ShowMapRotateControl
	{
		get
		{
			return GetValue(ShowMapRotateControlProperty, objDefault: false);
		}
		set
		{
			if (ShowMapRotateControl != value)
			{
				SetValue(ShowMapRotateControlProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to show the map Scale control.
	/// </summary>
	/// <value><c>true</c> if to show the map Scale control; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the Scale control be shown on the map.")]
	[DefaultValue(false)]
	public bool ShowMapScaleControl
	{
		get
		{
			return GetValue(ShowMapScaleControlProperty, objDefault: false);
		}
		set
		{
			if (ShowMapScaleControl != value)
			{
				SetValue(ShowMapScaleControlProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the API key.
	/// </summary>
	/// <value>The API key.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The GoogleMap API Key, if being used.")]
	[DefaultValue("")]
	public string MapAPIKey
	{
		get
		{
			return GetValue(MapAPIKeyProperty, "");
		}
		set
		{
			if (MapAPIKey != value)
			{
				SetValue(MapAPIKeyProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether draging markers is enabled.
	/// </summary>
	/// <value><c>true</c> if draging markers enabled; otherwise, <c>false</c>.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("Should the user be allowed to drag marker overlays around.")]
	[DefaultValue(true)]
	public bool MapDraggingEnabled
	{
		get
		{
			return GetValue(MapDraggingEnabledProperty, objDefault: true);
		}
		set
		{
			if (MapDraggingEnabled != value)
			{
				SetValue(MapDraggingEnabledProperty, value, objDefaultValue: true);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the type of the map type selection control.
	/// </summary>
	/// <value>The type of the map control.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The type of Map type selector control to show on the map.")]
	[DefaultValue(GoogleMapControlType.Default)]
	public GoogleMapControlType MapControlType
	{
		get
		{
			return GetValue(MapControlTypeProperty, GoogleMapControlType.Default);
		}
		set
		{
			if (MapControlType != value)
			{
				SetValue(MapControlTypeProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the types of Map to show on the Map type selection Control
	/// </summary>
	/// <value>The types of maps to show in the Map control</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The types of maps to show in the Map control.")]
	public GoogleMapMapTypes MapControlMaps
	{
		get
		{
			GoogleMapMapTypes googleMapMapTypes = GetValue<GoogleMapMapTypes>(MapControlMapsProperty);
			if (googleMapMapTypes == null)
			{
				googleMapMapTypes = GoogleMapMapTypes.DefaultMapTypes();
				googleMapMapTypes.mobjParentMap = this;
				SetValue(MapControlMapsProperty, googleMapMapTypes);
			}
			return googleMapMapTypes;
		}
		set
		{
			if (MapControlMaps != value)
			{
				MapControlMaps.mobjParentMap = null;
				value.mobjParentMap = this;
				SetValue(MapControlMapsProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map type selecton control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Map type selector controls should be located.")]
	[DefaultValue(GoogleMapControlPositionType.TopRight)]
	public GoogleMapControlPositionType MapControlPosition
	{
		get
		{
			return GetValue(MapControlPositionProperty, GoogleMapControlPositionType.TopRight);
		}
		set
		{
			if (MapControlPosition != value)
			{
				SetValue(MapControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the type of the map zoom control.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("The type of Zoom control to show on the map.")]
	[DefaultValue(GoogleMapZoomControlType.Default)]
	public GoogleMapZoomControlType MapZoomControlType
	{
		get
		{
			return GetValue(MapZoomControlTypeProperty, GoogleMapZoomControlType.Default);
		}
		set
		{
			if (MapZoomControlType != value)
			{
				SetValue(MapZoomControlTypeProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map zoom control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Zoom control should be shown.")]
	[DefaultValue(GoogleMapControlPositionType.TopLeft)]
	public GoogleMapControlPositionType MapZoomControlPosition
	{
		get
		{
			return GetValue(MapZoomControlPositionProperty, GoogleMapControlPositionType.TopLeft);
		}
		set
		{
			if (MapZoomControlPosition != value)
			{
				SetValue(MapZoomControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map Streetview control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Streetview control should be shown.")]
	[DefaultValue(GoogleMapControlPositionType.TopLeft)]
	public GoogleMapControlPositionType MapStreetviewControlPosition
	{
		get
		{
			return GetValue(MapStreetviewControlPositionProperty, GoogleMapControlPositionType.TopLeft);
		}
		set
		{
			if (MapStreetviewControlPosition != value)
			{
				SetValue(MapStreetviewControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map Pan control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Pan control should be shown.")]
	[DefaultValue(GoogleMapControlPositionType.TopLeft)]
	public GoogleMapControlPositionType MapPanControlPosition
	{
		get
		{
			return GetValue(MapPanControlPositionProperty, GoogleMapControlPositionType.TopLeft);
		}
		set
		{
			if (MapPanControlPosition != value)
			{
				SetValue(MapPanControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map Rotate control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Rotate control should be shown.")]
	[DefaultValue(GoogleMapControlPositionType.TopLeft)]
	public GoogleMapControlPositionType MapRotateControlPosition
	{
		get
		{
			return GetValue(MapRotateControlPositionProperty, GoogleMapControlPositionType.TopLeft);
		}
		set
		{
			if (MapRotateControlPosition != value)
			{
				SetValue(MapRotateControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the position of the map Scale control
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Where on the map the Scale control should be shown.")]
	[DefaultValue(GoogleMapControlPositionType.TopLeft)]
	public GoogleMapControlPositionType MapScaleControlPosition
	{
		get
		{
			return GetValue(MapScaleControlPositionProperty, GoogleMapControlPositionType.TopLeft);
		}
		set
		{
			if (MapScaleControlPosition != value)
			{
				SetValue(MapScaleControlPositionProperty, value);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Gets or sets the location for the center of the viewport. If Location is set, Address will be empty
	/// </summary>
	/// <value>The location.</value>   
	[SRCategory("GoogleMap")]
	[SRDescription("The current location (center) of the map.")]
	public GoogleMapLocation MapLocation
	{
		get
		{
			return GetValue(MapLocationProperty, DefaultMapLocation);
		}
		set
		{
			if (SetValue(MapLocationProperty, value))
			{
				mblnLocationHasChanged = true;
				SetValue(MapAddressProperty, string.Empty);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
				OnMapLocationChanged(new GoogleMapLocationEventArgs(value));
			}
		}
	}

	/// <summary>
	/// Gets or sets the map address. If Address is set, Location will be empty
	/// </summary>
	/// <value>The map address.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The current location (center) of the map, expressed as an address. Will update to Location once address has been looked up.")]
	[DefaultValue("")]
	public string MapAddress
	{
		get
		{
			return GetValue(MapAddressProperty, "");
		}
		set
		{
			if (SetValue(MapAddressProperty, value))
			{
				mblnLocationHasChanged = true;
				SetValue(MapLocationProperty, GoogleMapLocation.Empty);
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
				OnMapAddressChanged(new GoogleMapLocationEventArgs(value));
			}
		}
	}

	/// <summary>
	/// Gets or sets the map zoom level
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("The current Zoom level of the map.")]
	[DefaultValue(6)]
	public int MapZoomLevel
	{
		get
		{
			return GetValue(MapZoomLevelProperty, 6);
		}
		set
		{
			if (SetValue(MapZoomLevelProperty, value))
			{
				Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
				OnMapZoomLevelChanged(EventArgs.Empty);
			}
		}
	}

	/// <summary>
	/// Gets or sets the display name for OpenStreatMap. If blank, default name is used
	/// </summary>
	/// <value>The display name.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The display name for OpenStreatMap map type.")]
	[DefaultValue("OpenStreatMap")]
	public string MapOpenStreatMapName
	{
		get
		{
			return GetValue(MapOpenStreatMapNameProperty, "OpenStreatMap");
		}
		set
		{
			if (SetValue(MapOpenStreatMapNameProperty, value))
			{
				Update();
			}
		}
	}

	/// <summary>
	/// Gets or sets the base url for OpenStreatMap tiles server
	/// </summary>
	/// <value>The base url.</value>
	[SRCategory("GoogleMap")]
	[SRDescription("The base Url for OpenStreatMap tiles server for OpenStreatMap custom map type.")]
	[DefaultValue("http://tile.openstreetmap.org/")]
	public string MapOpenStreatMapUrl
	{
		get
		{
			return GetValue(MapOpenStreatMapUrlProperty, "http://tile.openstreetmap.org/");
		}
		set
		{
			if (SetValue(MapOpenStreatMapUrlProperty, value))
			{
				Update();
			}
		}
	}

	/// <summary>
	/// Gets the default map location.
	/// </summary>
	/// <value>The default map location.</value>
	protected virtual GoogleMapLocation DefaultMapLocation => GoogleMapLocation.Empty;

	/// <summary>
	/// Gets or sets the current LatLngBounds of the viewport. For internal use only. 
	/// Use MapFitToBounds/MapPanToBounds/MapGetBounds for setting/getting current bounds for the map.
	/// </summary>
	/// <value>The location.</value>   
	[SRCategory("GoogleMap")]
	[SRDescription("The LatLng bounds of the map.")]
	private GoogleMapLatLngBounds MapLatLngBounds
	{
		get
		{
			return GetValue(MapBoundsProperty, GoogleMapLatLngBounds.Empty);
		}
		set
		{
			SetValue(MapBoundsProperty, value);
		}
	}

	/// <summary>
	/// Obsolete - Gets or sets the API key.
	/// </summary>
	/// <value>The API key.</value>
	[Obsolete("Use MapAPIKey")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public string APIKey
	{
		get
		{
			return MapAPIKey;
		}
		set
		{
			MapAPIKey = value;
		}
	}

	/// <summary>
	/// Obsolete - Gets the overlays.
	/// </summary>
	/// <value>The overlays.</value>
	[Obsolete("Use MapOverlays")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public GoogleMapOverlayCollection Overlays => MapOverlays;

	/// <summary>
	/// Obsolete - Gets or sets a value indicating whether draging markers is enabled.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use MapDraggingEnabled")]
	public bool DragingEnabled
	{
		get
		{
			return MapDraggingEnabled;
		}
		set
		{
			MapDraggingEnabled = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new RightToLeft RightToLeft => RightToLeft.Inherit;

	/// <summary>
	/// Fires when marker overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapOverlayClick
	{
		add
		{
			AddCriticalHandler(MapOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when marker overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapOverlayDoubleClick
	{
		add
		{
			AddCriticalHandler(MapOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when marker overlay is dragged and location for the overlay has changed. New position already updated.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay is dragged and location for the overlay has changed. New location already updated.")]
	public event GoogleMapOverlayEventHandler MapOverlayLocationChanged
	{
		add
		{
			AddCriticalHandler(MapOverlayLocationChangedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayLocationChangedEvent, value);
		}
	}

	/// <summary>
	/// Fires when marker overlay is right clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay is right clicked.")]
	public event GoogleMapOverlayEventHandler MapOverlayRightClick
	{
		add
		{
			AddCriticalHandler(MapOverlayRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayRightClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when marker overlay InfoWindow is opened
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay InfoWindow is opened.")]
	public event GoogleMapOverlayEventHandler MapOverlayInfoOpened
	{
		add
		{
			AddCriticalHandler(MapOverlayInfoOpenedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayInfoOpenedEvent, value);
		}
	}

	/// <summary>
	/// Fires when marker overlay InfoWindow is closed
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when marker overlay InfoWindow is closed.")]
	public event GoogleMapOverlayEventHandler MapOverlayInfoClosed
	{
		add
		{
			AddCriticalHandler(MapOverlayInfoClosedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapOverlayInfoClosedEvent, value);
		}
	}

	/// <summary>
	/// Fires when Polyline overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when Polyline overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapPolylineClick
	{
		add
		{
			AddCriticalHandler(MapPolylineOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolylineOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a Polyline overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Polyline overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapPolylineDoubleClick
	{
		add
		{
			AddCriticalHandler(MapPolylineOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolylineOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a Polyline overlay is right clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Polyline overlay is right clicked.")]
	public event GoogleMapOverlayEventHandler MapPolylineRightClick
	{
		add
		{
			AddCriticalHandler(MapPolylineOverlayRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolylineOverlayRightClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Polygon overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapPolygonClick
	{
		add
		{
			AddCriticalHandler(MapPolygonOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolygonOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Polygon overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapPolygonDoubleClick
	{
		add
		{
			AddCriticalHandler(MapPolygonOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolygonOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is right clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Polygon overlay is right clicked.")]
	public event GoogleMapOverlayEventHandler MapPolygonRightClick
	{
		add
		{
			AddCriticalHandler(MapPolygonOverlayRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapPolygonOverlayRightClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Rectangle overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapRectangleClick
	{
		add
		{
			AddCriticalHandler(MapRectangleOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapRectangleOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Rectangle overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapRectangleDoubleClick
	{
		add
		{
			AddCriticalHandler(MapRectangleOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapRectangleOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is right clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Rectangle overlay is right clicked.")]
	public event GoogleMapOverlayEventHandler MapRectangleRightClick
	{
		add
		{
			AddCriticalHandler(MapRectangleOverlayRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapRectangleOverlayRightClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Circle overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapCircleClick
	{
		add
		{
			AddCriticalHandler(MapCircleOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapCircleOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Circle overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapCircleDoubleClick
	{
		add
		{
			AddCriticalHandler(MapCircleOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapCircleOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is right clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Circle overlay is right clicked.")]
	public event GoogleMapOverlayEventHandler MapCircleRightClick
	{
		add
		{
			AddCriticalHandler(MapCircleOverlayRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapCircleOverlayRightClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Ground overlay is clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Ground overlay is clicked.")]
	public event GoogleMapOverlayEventHandler MapGroundClick
	{
		add
		{
			AddCriticalHandler(MapGroundOverlayClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapGroundOverlayClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Ground overlay is double clicked
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a Ground overlay is double clicked.")]
	public event GoogleMapOverlayEventHandler MapGroundDoubleClick
	{
		add
		{
			AddCriticalHandler(MapGroundOverlayDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapGroundOverlayDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when Info Window overlay is closed
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when Info Window overlay is closed.")]
	public event GoogleMapOverlayEventHandler MapInfoWindowClosed
	{
		add
		{
			AddCriticalHandler(MapInfoWindowClosedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapInfoWindowClosedEvent, value);
		}
	}

	/// <summary>
	/// Fires when a reference point is clicked on Kml layer
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a reference point is clicked on Kml layer.")]
	public event GoogleMapLayerEventHandler MapKmlLayerClick
	{
		add
		{
			AddCriticalHandler(MapKmlLayerClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapKmlLayerClickEvent, value);
		}
	}

	/// <summary>
	/// Fires when a reference point is clicked on Weather layer
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when a reference point is clicked on Weather layer.")]
	public event GoogleMapLayerEventHandler MapWeatherLayerClick
	{
		add
		{
			AddCriticalHandler(MapWeatherLayerClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapWeatherLayerClickEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map is clicked.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the main map is clicked.")]
	public event GoogleMapEventHandler MapClick
	{
		add
		{
			AddCriticalHandler(MapClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapClickEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map is double-clicked.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the main map is double clicked.")]
	public event GoogleMapEventHandler MapDoubleClick
	{
		add
		{
			AddCriticalHandler(MapDoubleClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapDoubleClickEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map is right-clicked.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the main map area is right clicked.")]
	public event GoogleMapEventHandler MapRightClick
	{
		add
		{
			AddCriticalHandler(MapRightClickEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapRightClickEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map LatLngBounds changed.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the Map LatLngBounds change.")]
	public event EventHandler MapBoundsChanged
	{
		add
		{
			AddCriticalHandler(MapBoundsChangedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapBoundsChangedEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map Heading changed.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the Map Heading changes.")]
	public event EventHandler MapHeadingChanged
	{
		add
		{
			AddCriticalHandler(MapHeadingChangedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapHeadingChangedEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map location changed.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the position of the center changes.")]
	public event EventHandler MapLocationChanged
	{
		add
		{
			AddCriticalHandler(MapLocationChangedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(MapLocationChangedEvent, value);
		}
	}

	/// <summary>
	/// Occurs after a GEO search has been performed, both after setting MapAddress and when searched seperately
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires after a GEO search has been performed, both after setting MapAddress and when searched seperately. EventArgs isLocation is true and Address contains GEO search formatted address, if GEO search succeeds")]
	public event EventHandler MapAddressGEOSearched
	{
		add
		{
			AddHandler(MapAddressGEOSearchedEvent, value);
		}
		remove
		{
			RemoveHandler(MapAddressGEOSearchedEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map address has changed.
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when the address changes.")]
	public event EventHandler MapAddressChanged
	{
		add
		{
			AddHandler(MapAddressChangedEvent, value);
		}
		remove
		{
			RemoveHandler(MapAddressChangedEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map zoom level has changed
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when zoom level changes.")]
	public event EventHandler MapZoomLevelChanged
	{
		add
		{
			AddHandler(MapZoomLevelChangedEvent, value);
		}
		remove
		{
			RemoveHandler(MapZoomLevelChangedEvent, value);
		}
	}

	/// <summary>
	/// Occurs when map type has changed
	/// </summary>
	[SRCategory("GoogleMap")]
	[SRDescription("Fires when Map type changes.")]
	public event EventHandler MapTypeChanged
	{
		add
		{
			AddHandler(MapTypeChangedEvent, value);
		}
		remove
		{
			RemoveHandler(MapTypeChangedEvent, value);
		}
	}

	/// <summary>
	/// Fires when an overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when an overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayClick
	{
		add
		{
			AddClientHandler("OverlayClick", value);
		}
		remove
		{
			RemoveClientHandler("OverlayClick", value);
		}
	}

	/// <summary>
	/// Fires when map overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when map overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayDoubleClick
	{
		add
		{
			AddClientHandler("OverlayDblClick", value);
		}
		remove
		{
			RemoveClientHandler("OverlayDblClick", value);
		}
	}

	/// <summary>
	/// Fires when a map overlay is dragged and location for the overlay has changed in client mode. New location already updated.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a map overlay is dragged and position for the overlay has changed. New position already updated.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayLocationChanged
	{
		add
		{
			AddClientHandler("OverlayLocationChanged", value);
		}
		remove
		{
			RemoveClientHandler("OverlayLocationChanged", value);
		}
	}

	/// <summary>
	/// Fires when a map overlay is right clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a map overlay is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayRightClick
	{
		add
		{
			AddClientHandler("OverlayRightClick", value);
		}
		remove
		{
			RemoveClientHandler("OverlayRightClick", value);
		}
	}

	/// <summary>
	/// Fires when an overlay InfoWindow is opened in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when an overlay InfoWindow is opened")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayInfoOpened
	{
		add
		{
			AddClientHandler("OverlayInfoOpened", value);
		}
		remove
		{
			RemoveClientHandler("OverlayInfoOpened", value);
		}
	}

	/// <summary>
	/// Fires when an overlay InfoWindow is closed in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when an overlay InfoWindow is closed")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapOverlayInfoClosed
	{
		add
		{
			AddClientHandler("OverlayInfoClosed", value);
		}
		remove
		{
			RemoveClientHandler("OverlayInfoClosed", value);
		}
	}

	/// <summary>
	/// Fires when Polyline overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when Polyline overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolylineClick
	{
		add
		{
			AddClientHandler("PolylineClick", value);
		}
		remove
		{
			RemoveClientHandler("PolylineClick", value);
		}
	}

	/// <summary>
	/// Fires when a Polyline overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Polyline overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolylineDoubleClick
	{
		add
		{
			AddClientHandler("PolylineDoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("PolylineDoubleClick", value);
		}
	}

	/// <summary>
	/// Fires when a Polyline overlay is right clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Polyline overlay is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolylineRightClick
	{
		add
		{
			AddClientHandler("PolylineRightClick", value);
		}
		remove
		{
			RemoveClientHandler("PolylineRightClick", value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Polygon overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolygonClick
	{
		add
		{
			AddClientHandler("PolygonClick", value);
		}
		remove
		{
			RemoveClientHandler("PolygonClick", value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Polygon overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolygonDoubleClick
	{
		add
		{
			AddClientHandler("PolygonDoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("PolygonDoubleClick", value);
		}
	}

	/// <summary>
	/// Fires when a Polygon overlay is right clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Polygon overlay is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapPolygonRightClick
	{
		add
		{
			AddClientHandler("PolygonRightClick", value);
		}
		remove
		{
			RemoveClientHandler("PolygonRightClick", value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Rectangle overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapRectangleClick
	{
		add
		{
			AddClientHandler("RectangleClick", value);
		}
		remove
		{
			RemoveClientHandler("RectangleClick", value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Rectangle overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapRectangleDoubleClick
	{
		add
		{
			AddClientHandler("RectangleDoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("RectangleDoubleClick", value);
		}
	}

	/// <summary>
	/// Fires when Rectangle overlay is right clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Rectangle overlay is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapRectangleRightClick
	{
		add
		{
			AddClientHandler("RectangleRightClick", value);
		}
		remove
		{
			RemoveClientHandler("RectangleRightClick", value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Circle overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapCircleClick
	{
		add
		{
			AddClientHandler("CircleClick", value);
		}
		remove
		{
			RemoveClientHandler("CircleClick", value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Circle overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapCircleDoubleClick
	{
		add
		{
			AddClientHandler("CircleDoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("CircleDoubleClick", value);
		}
	}

	/// <summary>
	/// Fires when Circle overlay is right clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Circle overlay is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapCircleRightClick
	{
		add
		{
			AddClientHandler("CircleRightClick", value);
		}
		remove
		{
			RemoveClientHandler("CircleRightClick", value);
		}
	}

	/// <summary>
	/// Fires when Ground overlay is clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Ground overlay is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapGroundClick
	{
		add
		{
			AddClientHandler("GroundClick", value);
		}
		remove
		{
			RemoveClientHandler("GroundClick", value);
		}
	}

	/// <summary>
	/// Fires when Ground overlay is double clicked in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a Ground overlay is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapGroundDoubleClick
	{
		add
		{
			AddClientHandler("GroundDoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("GroundDoubleClick", value);
		}
	}

	/// <summary>
	/// Fires when Info Window overlay is closed in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when Info Window overlay is closed")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapInfoWindowClosed
	{
		add
		{
			AddClientHandler("InfoWindowClosed", value);
		}
		remove
		{
			RemoveClientHandler("InfoWindowClosed", value);
		}
	}

	/// <summary>
	/// Fires when a reference point is clicked on Kml layer in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a reference point is clicked on Kml layer")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapKmlLayerClick
	{
		add
		{
			AddClientHandler("KmlClick", value);
		}
		remove
		{
			RemoveClientHandler("KmlClick", value);
		}
	}

	/// <summary>
	/// Fires when a reference point is clicked on Weather layer in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when a reference point is clicked on Weather layer")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapWeatherLayerClick
	{
		add
		{
			AddClientHandler("WeatherClick", value);
		}
		remove
		{
			RemoveClientHandler("WeatherClick", value);
		}
	}

	/// <summary>
	/// Occurs when map is clicked in client mode.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when the main map is clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapClick
	{
		add
		{
			AddClientHandler("MapClick", value);
		}
		remove
		{
			RemoveClientHandler("MapClick", value);
		}
	}

	/// <summary>
	/// Occurs when map is double-clicked in client mode.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when the main map is double clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapDoubleClick
	{
		add
		{
			AddClientHandler("MapDblClick", value);
		}
		remove
		{
			RemoveClientHandler("MapDblClick", value);
		}
	}

	/// <summary>
	/// Occurs when map is right-clicked in client mode.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when the main map area is right clicked")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapRightClick
	{
		add
		{
			AddClientHandler("MapRightClick", value);
		}
		remove
		{
			RemoveClientHandler("MapRightClick", value);
		}
	}

	/// <summary>
	/// Occurs when map location changed in client mode.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when the position of the center changes")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapLocationChanged
	{
		add
		{
			AddClientHandler("LocationChanged", value);
		}
		remove
		{
			RemoveClientHandler("LocationChanged", value);
		}
	}

	/// <summary>
	/// Occurs when map location changed in client mode.
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires after a GEO search has been performed, both after setting MapAddress and when searched seperately")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapAddressGEOSearched
	{
		add
		{
			AddClientHandler("AddressGEOSearched", value);
		}
		remove
		{
			RemoveClientHandler("AddressGEOSearched", value);
		}
	}

	/// <summary>
	/// Occurs when map zoom level has changed in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when zoom level changes")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapZoomLevelChanged
	{
		add
		{
			AddClientHandler("ZoomChanged", value);
		}
		remove
		{
			RemoveClientHandler("ZoomChanged", value);
		}
	}

	/// <summary>
	/// Occurs when map type has changed in client mode
	/// </summary>
	[Category("GoogleMapClient")]
	[Description("Fires in client mode when Map type changes")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientMapTypeChanged
	{
		add
		{
			AddClientHandler("MapTypeChanged", value);
		}
		remove
		{
			RemoveClientHandler("MapTypeChanged", value);
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Professional.GoogleMap" /> class.
	/// </summary>
	public GoogleMap()
	{
	}

	/// <summary>
	/// Extend current bounds to contain objLocation and then fit extended bounds
	/// </summary>
	/// <param name="objLocation"></param>
	public void MapFitBounds(GoogleMapLocation objLocation)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objLocation, null, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.FitLocation));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Set the Map viewport to contain the given bounds
	/// </summary>
	/// <param name="objSouthWest">SouthWest corner of Bounds</param>
	/// <param name="objNorthEast">NorthEast corner of Bounds</param>
	public void MapFitBounds(GoogleMapLocation objSouthWest, GoogleMapLocation objNorthEast)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objSouthWest, objNorthEast, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Fit));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Set the Map viewport to contain the given bounds
	/// </summary>
	/// <param name="objBounds">The Bounds to be set for the viewport</param>
	public void MapFitBounds(GoogleMapLatLngBounds objBounds)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objBounds.SouthWest, objBounds.NorthEast, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Fit));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Set the Map viewport to contain the bounds of all given locations
	/// </summary>
	/// <param name="objLocations"></param>
	public void MapFitBounds(GoogleMapLocationCollection objLocations)
	{
		foreach (GoogleMapLocation objLocation in objLocations)
		{
			MapFitBounds(objLocation);
		}
	}

	/// <summary>
	/// Set the Map viewport to contain the bounds of all given locations
	/// </summary>
	/// <param name="objLocations"></param>
	public void MapFitBounds(GoogleMapLocation[] objLocations)
	{
		foreach (GoogleMapLocation objLocation in objLocations)
		{
			MapFitBounds(objLocation);
		}
	}

	/// <summary>
	/// Set the Map viewport to contain the bounds of given Overlay
	/// </summary>
	/// <param name="objOverlay"></param>
	public void MapFitBounds(GoogleMapOverlay objOverlay)
	{
		MapFitBounds(objOverlay.OverlayRepresentedByPoints);
	}

	/// <summary>
	/// Set the Map viewport to contain the bounds of all given Overlays
	/// </summary>
	/// <param name="objOverlays"></param>
	public void MapFitBounds(GoogleMapOverlayCollection objOverlays)
	{
		foreach (GoogleMapOverlay objOverlay in objOverlays)
		{
			MapFitBounds(objOverlay);
		}
	}

	/// <summary>
	/// Set the Map viewport to contain the bounds of all given Overlays
	/// </summary>
	/// <param name="objOverlays"></param>
	public void MapFitBounds(GoogleMapOverlay[] objOverlays)
	{
		foreach (GoogleMapOverlay objOverlay in objOverlays)
		{
			MapFitBounds(objOverlay);
		}
	}

	/// <summary>
	/// Extend bounds to contain objLocation and pan to extended bounds
	/// </summary>
	/// <param name="objLocation"></param>
	public void MapPanToBounds(GoogleMapLocation objLocation)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objLocation, null, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.PanLocation));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain the given bounds.
	/// </summary>
	/// <param name="objSouthWest">SouthWest corner of Bounds</param>
	/// <param name="objNorthEast">NorthEast corner of Bounds</param>
	public void MapPanToBounds(GoogleMapLocation objSouthWest, GoogleMapLocation objNorthEast)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objSouthWest, objNorthEast, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Pan));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain the given bounds
	/// </summary>
	/// <param name="objBounds">The Bounds to be set for the viewport</param>
	public void MapPanToBounds(GoogleMapLatLngBounds objBounds)
	{
		marrMapLatLngBoundsQueue.Add(new GoogleMapLatLngBoundsQueueElement(objBounds.SouthWest, objBounds.NorthEast, GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Pan));
		Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain the given locations
	/// </summary>
	/// <param name="objLocations"></param>
	public void MapPanToBounds(GoogleMapLocationCollection objLocations)
	{
		foreach (GoogleMapLocation objLocation in objLocations)
		{
			MapPanToBounds(objLocation);
		}
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain the given locations
	/// </summary>
	/// <param name="objLocations"></param>
	public void MapPanToBounds(GoogleMapLocation[] objLocations)
	{
		foreach (GoogleMapLocation objLocation in objLocations)
		{
			MapPanToBounds(objLocation);
		}
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain the given overlay
	/// </summary>
	/// <param name="objOverlay"></param>
	public void MapPanToBounds(GoogleMapOverlay objOverlay)
	{
		MapPanToBounds(objOverlay.OverlayRepresentedByPoints);
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain all the given overlays
	/// </summary>
	/// <param name="objOverlays"></param>
	public void MapPanToBounds(GoogleMapOverlayCollection objOverlays)
	{
		foreach (GoogleMapOverlay objOverlay in objOverlays)
		{
			MapPanToBounds(objOverlay);
		}
	}

	/// <summary>
	/// Pan the viewport of the Map by the minimum amount necessary to contain all the given overlays
	/// </summary>
	/// <param name="objOverlays"></param>
	public void MapPanToBounds(GoogleMapOverlay[] objOverlays)
	{
		foreach (GoogleMapOverlay objOverlay in objOverlays)
		{
			MapPanToBounds(objOverlay);
		}
	}

	/// <summary>
	/// Performs a GEO search for an address's location, firing MapAddressGEOSearched when done
	/// </summary>
	/// <param name="strAddress">Performs a GEO search for an address's location, firing MapAddressGEOSearched when done.</param>
	public void MapFindAddressLocation(string strAddress)
	{
		if (VWGClientContext.Current != null)
		{
			VWGClientContext.Current.Invoke(this, "GoogleMap_FindAddressLocation", ID, strAddress);
		}
	}

	/// <summary>
	/// Return the current Bounds of the viewport
	/// </summary>
	/// <returns></returns>
	public GoogleMapLatLngBounds MapGetBounds()
	{
		return new GoogleMapLatLngBounds(MapLatLngBounds.SouthWest, MapLatLngBounds.NorthEast);
	}

	/// <summary>
	/// Fires an event.
	/// </summary>
	/// <param name="objEvent">event.</param>
	protected override void FireEvent(IEvent objEvent)
	{
		base.FireEvent(objEvent);
		switch (objEvent.Type)
		{
		case "BoundsChanged":
			parseClientBounds(objEvent["NELatitude"], objEvent["NELongitude"], objEvent["SWLatitude"], objEvent["SWLongitude"], MapLatLngBounds);
			OnMapBoundsChanged(new GoogleMapLatLngBoundsEventArgs(MapLatLngBounds));
			break;
		case "HeadingChanged":
		{
			double num2 = double.Parse(objEvent["Heading"], CultureInfo.InvariantCulture);
			SetValue(MapHeadingProperty, num2);
			OnMapHeadingChanged(new GoogleMapHeadingEventArgs(num2));
			break;
		}
		case "LocationChanged":
		{
			SetValue(MapAddressProperty, string.Empty);
			GoogleMapLocation mapLocation = MapLocation;
			parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"], mapLocation);
			SetValue(MapLocationProperty, mapLocation);
			OnMapLocationChanged(new GoogleMapLocationEventArgs(mapLocation));
			break;
		}
		case "GEOSearched":
		{
			string strAddress = objEvent["Address"];
			if (objEvent["Found"].ToString() == "1")
			{
				GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
				OnMapAddressGEOSearched(new GoogleMapLocationEventArgs(strAddress, position, blnIsValidAddress: true));
			}
			else
			{
				OnMapAddressGEOSearched(new GoogleMapLocationEventArgs(strAddress, GoogleMapLocation.Empty, blnIsValidAddress: false));
			}
			break;
		}
		case "MapClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			OnMapClick(new GoogleMapLocationEventArgs(position));
			break;
		}
		case "MapDblClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			OnMapDoubleClick(new GoogleMapLocationEventArgs(position));
			break;
		}
		case "MapRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			OnMapRightClick(new GoogleMapLocationEventArgs(position));
			break;
		}
		case "ZoomChanged":
			SetValue(MapZoomLevelProperty, int.Parse(objEvent["Zoom"]));
			OnMapZoomLevelChanged(EventArgs.Empty);
			break;
		case "MapTypeChanged":
			SetValue(MapTypeProperty, (GoogleMapType)Enum.Parse(typeof(GoogleMapType), objEvent["MapType"]));
			OnMapTypeChanged(EventArgs.Empty);
			break;
		case "OverlayClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapOverlayClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "OverlayRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapOverlayRightClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "OverlayDblClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapOverlayDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "OverlayLocationChanged":
		{
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				GoogleMapOverlay googleMapOverlay = MapOverlays[num];
				parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"], ((GoogleMapMarkerOverlay)googleMapOverlay).Location);
				OnMapOverlayLocationChanged(new GoogleMapOverlayEventArgs(MapOverlays[num], ((GoogleMapMarkerOverlay)googleMapOverlay).Location));
			}
			break;
		}
		case "OverlayInfoOpened":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapOverlayInfoOpened(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "OverlayInfoClosed":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapOverlayInfoClosed(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "KmlClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["LayerID"]);
			int num = MapLayers.FindIndexByLayerId(intMemberId);
			if (num >= 0)
			{
				if (!string.IsNullOrEmpty(objEvent["Author_name"]))
				{
					OnMapKmlLayerClick(new GoogleMapKmlLayerClickEventArgs(MapLayers[num], position, objEvent["Author_name"], objEvent["Author_email"], objEvent["Author_uri"], objEvent["Description"], objEvent["Id"], objEvent["InfoWindowHtml"], objEvent["Name"], objEvent["Snippet"]));
				}
				else
				{
					OnMapKmlLayerClick(new GoogleMapKmlLayerClickEventArgs(MapLayers[num], position, objEvent["Description"], objEvent["Id"], objEvent["InfoWindowHtml"], objEvent["Name"], objEvent["Snippet"]));
				}
			}
			break;
		}
		case "WeatherClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["LayerID"]);
			int num = MapLayers.FindIndexByLayerId(intMemberId);
			if (num >= 0)
			{
				GoogleMapWeatherCondition objCurrent = new GoogleMapWeatherCondition(objEvent["Current_Day"], objEvent["Current_Description"], parseDouble(objEvent["Current_High"]), parseDouble(objEvent["Current_Humidity"]), parseDouble(objEvent["Current_Low"]), objEvent["Current_ShortDay"], parseDouble(objEvent["Current_Temperature"]), objEvent["Current_WindDirection"], parseDouble(objEvent["Current_WindSpeed"]));
				GoogleMapWeatherForecast[] arrWeatherForecast = new GoogleMapWeatherForecast[4]
				{
					new GoogleMapWeatherForecast(objEvent["Forecast1_Day"], objEvent["Forecast1_Description"], parseDouble(objEvent["Forecast1_High"]), parseDouble(objEvent["Forecast1_Low"]), objEvent["Forecast1_ShortDay"]),
					new GoogleMapWeatherForecast(objEvent["Forecast2_Day"], objEvent["Forecast2_Description"], parseDouble(objEvent["Forecast2_High"]), parseDouble(objEvent["Forecast2_Low"]), objEvent["Forecast2_ShortDay"]),
					new GoogleMapWeatherForecast(objEvent["Forecast3_Day"], objEvent["Forecast3_Description"], parseDouble(objEvent["Forecast3_High"]), parseDouble(objEvent["Forecast3_Low"]), objEvent["Forecast3_ShortDay"]),
					new GoogleMapWeatherForecast(objEvent["Forecast4_Day"], objEvent["Forecast4_Description"], parseDouble(objEvent["Forecast4_High"]), parseDouble(objEvent["Forecast4_Low"]), objEvent["Forecast4_ShortDay"])
				};
				OnMapWeatherLayerClick(new GoogleMapWeatherLayerClickEventArgs(MapLayers[num], position, objEvent["InfoWindowHtml"], objEvent["Location"], (GoogleMapWeatherTemperatureUnitsType)Enum.Parse(typeof(GoogleMapWeatherTemperatureUnitsType), objEvent["TemperatureUnit"]), (GoogleMapWeatherWindSpeedUnitsType)Enum.Parse(typeof(GoogleMapWeatherWindSpeedUnitsType), objEvent["WindSpeedUnit"]), objCurrent, arrWeatherForecast));
			}
			break;
		}
		case "PolylineClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolylineClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "PolylineDoubleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolylineDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "PolylineRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolylineRightClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "PolygonClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolygonClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "PolygonDoubleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolygonDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "PolygonRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapPolygonRightClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "RectangleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapRectangleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "RectangleDoubleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapRectangleDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "RectangleRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapRectangleRightClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "CircleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapCircleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "CircleDoubleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapCircleDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "CircleRightClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapCircleRightClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "GroundClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapGroundClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "GroundDoubleClick":
		{
			GoogleMapLocation position = parseClientLatLng(objEvent["Latitude"], objEvent["Longitude"]);
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				OnMapGroundDoubleClick(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
			}
			break;
		}
		case "InfoWindowClosed":
		{
			long intMemberId = long.Parse(objEvent["MemberID"]);
			int num = MapOverlays.FindIndexByMemberId(intMemberId);
			if (num >= 0)
			{
				GoogleMapLocation position = ((GoogleMapInfoWindowOverlay)MapOverlays[num]).Position;
				OnMapInfoWindowClosed(new GoogleMapOverlayEventArgs(MapOverlays[num], position));
				num = MapOverlays.FindIndexByMemberId(intMemberId);
				if (num >= 0)
				{
					MapOverlays.RemoveAt(num);
				}
			}
			break;
		}
		}
	}

	/// <summary>
	/// Parse Client bounds and update objDestinationBounds with results
	/// </summary>
	/// <param name="strNELatitude"></param>
	/// <param name="strNELongitude"></param>
	/// <param name="strSWLatitude"></param>
	/// <param name="strSWLongitude"></param>
	/// <param name="objDestinationBounds"></param>
	private void parseClientBounds(string strNELatitude, string strNELongitude, string strSWLatitude, string strSWLongitude, GoogleMapLatLngBounds objDestinationBounds)
	{
		GoogleMapLocation googleMapLocation = parseClientLatLng(strNELatitude, strNELongitude);
		GoogleMapLocation googleMapLocation2 = parseClientLatLng(strSWLatitude, strSWLongitude);
		objDestinationBounds.NorthEast.Latitude = googleMapLocation.Latitude;
		objDestinationBounds.NorthEast.Longitude = googleMapLocation.Longitude;
		objDestinationBounds.SouthWest.Latitude = googleMapLocation2.Latitude;
		objDestinationBounds.SouthWest.Longitude = googleMapLocation2.Longitude;
	}

	/// <summary>
	/// Parse client side string values for latitude and Longitude and update objDestinationLocation
	/// </summary>
	/// <param name="strLatitude"></param>
	/// <param name="strLongitude"></param>
	/// <returns></returns>
	private void parseClientLatLng(string strLatitude, string strLongitude, GoogleMapLocation objDestinationLocation)
	{
		float num = float.Parse(strLatitude, NumberStyles.Any, CultureInfo.InvariantCulture);
		float num2 = float.Parse(strLongitude, NumberStyles.Any, CultureInfo.InvariantCulture);
		objDestinationLocation.Latitude = num;
		objDestinationLocation.Longitude = num2;
	}

	/// <summary>
	/// Parse client side string values for latitude and Longitude to a GoogleMapLocation
	/// </summary>
	/// <param name="strLatitude"></param>
	/// <param name="strLongitude"></param>
	/// <returns></returns>
	private GoogleMapLocation parseClientLatLng(string strLatitude, string strLongitude)
	{
		float num = float.Parse(strLatitude, NumberStyles.Any, CultureInfo.InvariantCulture);
		float num2 = float.Parse(strLongitude, NumberStyles.Any, CultureInfo.InvariantCulture);
		return new GoogleMapLocation(num, num2);
	}

	/// <summary>
	/// Parse a string to a double number
	/// </summary>
	/// <param name="strDouble"></param>
	/// <returns></returns>
	private double parseDouble(string strDouble)
	{
		return double.Parse(strDouble, NumberStyles.Any, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Raises the <see cref="E:MapClick" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapClick(GoogleMapLocationEventArgs objArgs)
	{
		if (MapClickHandler != null)
		{
			MapClickHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:MapRightClick" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapRightClick(GoogleMapLocationEventArgs objArgs)
	{
		if (MapRightClickHandler != null)
		{
			MapRightClickHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:MapDoubleClick" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapDoubleClick(GoogleMapLocationEventArgs objArgs)
	{
		if (MapDoubleClickHandler != null)
		{
			MapDoubleClickHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:LocationChanged" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapLocationChanged(GoogleMapLocationEventArgs objArgs)
	{
		if (MapLocationChangedHandler != null)
		{
			MapLocationChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:MapAddressGEOsearched" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapAddressGEOSearched(GoogleMapLocationEventArgs objArgs)
	{
		if (MapAddressGEOSearchedHandler != null)
		{
			MapAddressGEOSearchedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:BoundsChanged" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapBoundsChanged(GoogleMapLatLngBoundsEventArgs objArgs)
	{
		if (MapBoundsChangedHandler != null)
		{
			MapBoundsChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:HeadingChanged" /> event.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapHeadingChanged(GoogleMapHeadingEventArgs objArgs)
	{
		if (MapHeadingChangedHandler != null)
		{
			MapHeadingChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Called when map address had changed.
	/// </summary>
	/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnMapAddressChanged(GoogleMapLocationEventArgs objArgs)
	{
		if (MapAddressChangedHandler != null)
		{
			MapAddressChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Called when map zoom level has changed
	/// </summary>
	/// <param name="objArgs"></param>
	protected virtual void OnMapZoomLevelChanged(EventArgs objArgs)
	{
		if (MapZoomLevelChangedHandler != null)
		{
			MapZoomLevelChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Called when map Type has changed
	/// </summary>
	/// <param name="objArgs"></param>
	protected virtual void OnMapTypeChanged(EventArgs objArgs)
	{
		if (MapTypeChangedHandler != null)
		{
			MapTypeChangedHandler(this, objArgs);
		}
	}

	/// <summary>
	/// Called when an overlay marker is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayClickHandler != null)
		{
			MapOverlayClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a reference point on Kml layer is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapKmlLayerClick(GoogleMapKmlLayerClickEventArgs objEventArgs)
	{
		if (MapKmlLayerClickHandler != null)
		{
			MapKmlLayerClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a reference point on Weather layer is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapWeatherLayerClick(GoogleMapWeatherLayerClickEventArgs objEventArgs)
	{
		if (MapWeatherLayerClickHandler != null)
		{
			MapWeatherLayerClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an overlay marker is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayDoubleClickHandler != null)
		{
			MapOverlayDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an overlay marker is right clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayRightClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayRightClickHandler != null)
		{
			MapOverlayRightClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an overlay marker has been dragged. New position already updated on EventArgs Overlay
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayLocationChanged(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayLocationChangedHandler != null)
		{
			MapOverlayLocationChangedHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an InfoWindow is opened for an Overlay
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayInfoOpened(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayInfoOpenedHandler != null)
		{
			MapOverlayInfoOpenedHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an InfoWindow is closed for an Overlay
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapOverlayInfoClosed(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapOverlayInfoClosedHandler != null)
		{
			MapOverlayInfoClosedHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polyline overlay is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolylineClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolylineClickHandler != null)
		{
			MapPolylineClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polyline overlay is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolylineDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolylineDoubleClickHandler != null)
		{
			MapPolylineDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polyline overlay is right clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolylineRightClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolylineRightClickHandler != null)
		{
			MapPolylineRightClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polygon overlay is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolygonClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolygonClickHandler != null)
		{
			MapPolygonClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polygon overlay is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolygonDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolygonDoubleClickHandler != null)
		{
			MapPolygonDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Polygon overlay is right clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapPolygonRightClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapPolygonRightClickHandler != null)
		{
			MapPolygonRightClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Rectangle overlay is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapRectangleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapRectangleClickHandler != null)
		{
			MapRectangleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called whena Rectangle overlay is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapRectangleDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapRectangleDoubleClickHandler != null)
		{
			MapRectangleDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Rectangle overlay is right clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapRectangleRightClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapRectangleRightClickHandler != null)
		{
			MapRectangleRightClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Circle overlay is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapCircleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapCircleClickHandler != null)
		{
			MapCircleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called whena Circle overlay is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapCircleDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapCircleDoubleClickHandler != null)
		{
			MapCircleDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Circle overlay is right clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapCircleRightClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapCircleRightClickHandler != null)
		{
			MapCircleRightClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when a Ground overlay is clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapGroundClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapGroundClickHandler != null)
		{
			MapGroundClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called whena Ground overlay is double clicked
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapGroundDoubleClick(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapGroundDoubleClickHandler != null)
		{
			MapGroundDoubleClickHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Called when an Info Window is closed
	/// </summary>
	/// <param name="objEventArgs"></param>
	public virtual void OnMapInfoWindowClosed(GoogleMapOverlayEventArgs objEventArgs)
	{
		if (MapInfoWindowClosedHandler != null)
		{
			MapInfoWindowClosedHandler(this, objEventArgs);
		}
	}

	/// <summary>
	/// Gets the critical client events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalClientEventsData()
	{
		CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
		if (HasClientHandler("MapClick"))
		{
			criticalClientEventsData.Set("GC");
		}
		if (HasClientHandler("MapDblClick"))
		{
			criticalClientEventsData.Set("GDC");
		}
		if (HasClientHandler("MapRightClick"))
		{
			criticalClientEventsData.Set("GRC");
		}
		if (HasClientHandler("LocationChanged"))
		{
			criticalClientEventsData.Set("GLC");
		}
		if (HasClientHandler("AddressGEOSearched"))
		{
			criticalClientEventsData.Set("GGEO");
		}
		if (HasClientHandler("BoundsChanged"))
		{
			criticalClientEventsData.Set("GBC");
		}
		if (HasClientHandler("HeadingChanged"))
		{
			criticalClientEventsData.Set("GHC");
		}
		if (HasClientHandler("ZoomChanged"))
		{
			criticalClientEventsData.Set("GZC");
		}
		if (HasClientHandler("MapTypeChanged"))
		{
			criticalClientEventsData.Set("GMT");
		}
		if (HasClientHandler("OverlayClick"))
		{
			criticalClientEventsData.Set("GOC");
		}
		if (HasClientHandler("OverlayDblClick"))
		{
			criticalClientEventsData.Set("GOD");
		}
		if (HasClientHandler("OverlayRightClick"))
		{
			criticalClientEventsData.Set("GOR");
		}
		if (HasClientHandler("OverlayLocationChanged"))
		{
			criticalClientEventsData.Set("GOL");
		}
		if (HasClientHandler("OverlayInfoOpened"))
		{
			criticalClientEventsData.Set("GOI");
		}
		if (HasClientHandler("OverlayInfoClosed"))
		{
			criticalClientEventsData.Set("GOV");
		}
		if (HasClientHandler("KmlClick"))
		{
			criticalClientEventsData.Set("GKC");
		}
		if (HasClientHandler("WeatherClick"))
		{
			criticalClientEventsData.Set("GWC");
		}
		if (HasClientHandler("PolylineClick"))
		{
			criticalClientEventsData.Set("GPC");
		}
		if (HasClientHandler("PolylineDoubleClick"))
		{
			criticalClientEventsData.Set("GPD");
		}
		if (HasClientHandler("PolylineRightClick"))
		{
			criticalClientEventsData.Set("GPR");
		}
		if (HasClientHandler("PolygonClick"))
		{
			criticalClientEventsData.Set("GLL");
		}
		if (HasClientHandler("PolygonDoubleClick"))
		{
			criticalClientEventsData.Set("GLD");
		}
		if (HasClientHandler("PolygonRightClick"))
		{
			criticalClientEventsData.Set("GLG");
		}
		if (HasClientHandler("RectangleClick"))
		{
			criticalClientEventsData.Set("GRE");
		}
		if (HasClientHandler("RectangleDoubleClick"))
		{
			criticalClientEventsData.Set("GRD");
		}
		if (HasClientHandler("RectangleRightClick"))
		{
			criticalClientEventsData.Set("GRR");
		}
		if (HasClientHandler("CircleClick"))
		{
			criticalClientEventsData.Set("GCC");
		}
		if (HasClientHandler("CircleDoubleClick"))
		{
			criticalClientEventsData.Set("GCD");
		}
		if (HasClientHandler("CircleRightClick"))
		{
			criticalClientEventsData.Set("GCR");
		}
		if (HasClientHandler("GroundClick"))
		{
			criticalClientEventsData.Set("GGC");
		}
		if (HasClientHandler("GroundDoubleClick"))
		{
			criticalClientEventsData.Set("GGD");
		}
		if (HasClientHandler("InfoWindowClosed"))
		{
			criticalClientEventsData.Set("GIW");
		}
		return criticalClientEventsData;
	}

	/// <summary>
	/// Gets the critical events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (MapClickHandler != null)
		{
			criticalEventsData.Set("GC");
		}
		if (MapDoubleClickHandler != null)
		{
			criticalEventsData.Set("GDC");
		}
		if (MapRightClickHandler != null)
		{
			criticalEventsData.Set("GRC");
		}
		if (MapLocationChangedHandler != null)
		{
			criticalEventsData.Set("GLC");
		}
		if (MapAddressGEOSearchedHandler != null)
		{
			criticalEventsData.Set("GGEO");
		}
		if (MapBoundsChangedHandler != null)
		{
			criticalEventsData.Set("GBC");
		}
		if (MapHeadingChangedHandler != null)
		{
			criticalEventsData.Set("GHC");
		}
		if (MapZoomLevelChangedHandler != null)
		{
			criticalEventsData.Set("GZC");
		}
		if (MapTypeChangedHandler != null)
		{
			criticalEventsData.Set("GMT");
		}
		if (MapOverlayClickHandler != null)
		{
			criticalEventsData.Set("GOC");
		}
		if (MapOverlayDoubleClickHandler != null)
		{
			criticalEventsData.Set("GOD");
		}
		if (MapOverlayRightClickHandler != null)
		{
			criticalEventsData.Set("GOR");
		}
		if (MapOverlayLocationChangedHandler != null)
		{
			criticalEventsData.Set("GOL");
		}
		if (MapOverlayInfoOpenedHandler != null)
		{
			criticalEventsData.Set("GOI");
		}
		if (MapOverlayInfoClosedHandler != null)
		{
			criticalEventsData.Set("GOV");
		}
		if (MapKmlLayerClickHandler != null)
		{
			criticalEventsData.Set("GKC");
		}
		if (MapWeatherLayerClickHandler != null)
		{
			criticalEventsData.Set("GWC");
		}
		if (MapPolylineClickHandler != null)
		{
			criticalEventsData.Set("GPC");
		}
		if (MapPolylineDoubleClickHandler != null)
		{
			criticalEventsData.Set("GPD");
		}
		if (MapPolylineRightClickHandler != null)
		{
			criticalEventsData.Set("GPR");
		}
		if (MapPolygonClickHandler != null)
		{
			criticalEventsData.Set("GLL");
		}
		if (MapPolygonDoubleClickHandler != null)
		{
			criticalEventsData.Set("GLD");
		}
		if (MapPolygonRightClickHandler != null)
		{
			criticalEventsData.Set("GLG");
		}
		if (MapRectangleClickHandler != null)
		{
			criticalEventsData.Set("GRE");
		}
		if (MapRectangleDoubleClickHandler != null)
		{
			criticalEventsData.Set("GRD");
		}
		if (MapRectangleRightClickHandler != null)
		{
			criticalEventsData.Set("GRR");
		}
		if (MapCircleClickHandler != null)
		{
			criticalEventsData.Set("GCC");
		}
		if (MapCircleDoubleClickHandler != null)
		{
			criticalEventsData.Set("GCD");
		}
		if (MapCircleRightClickHandler != null)
		{
			criticalEventsData.Set("GCR");
		}
		if (MapGroundClickHandler != null)
		{
			criticalEventsData.Set("GGC");
		}
		if (MapGroundDoubleClickHandler != null)
		{
			criticalEventsData.Set("GGD");
		}
		if (MapInfoWindowClosedHandler != null)
		{
			criticalEventsData.Set("GIW");
		}
		return criticalEventsData;
	}

	/// <summary>
	/// Renders the controls meta attributes
	/// </summary>
	/// <param name="objContext">The obj context.</param>
	/// <param name="objWriter">The obj writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		if (!string.IsNullOrEmpty(MapAPIKey))
		{
			objWriter.WriteAttributeString("MapAPIKey", MapAPIKey);
		}
		objWriter.WriteAttributeString("MapType", MapType.ToString());
		objWriter.WriteAttributeString("UsingSensor", MapUsingSensor ? "1" : "0");
		objWriter.WriteAttributeString("Language", MapLanguage);
		objWriter.WriteAttributeString("Version", MapSpecificAPIVersion);
		RenderStandardAttributes(objContext, objWriter);
	}

	/// <summary>
	/// Render attributes on control updates
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		RenderStandardAttributes(objContext, objWriter);
	}

	/// <summary>
	/// Render all the control's attributes, either for update or full rendering
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected virtual void RenderStandardAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		objWriter.WriteAttributeString("Clusterer", MapUsingClusterer ? "1" : "0");
		objWriter.WriteAttributeString("ShowMapZoom", (ShowMapZoomControl ? "1" : "0") + ";" + MapZoomControlType.ToString() + ";" + MapZoomControlPosition);
		objWriter.WriteAttributeString("Zoom", MapZoomLevel.ToString());
		objWriter.WriteAttributeString("DoubleClickZoom", MapDoubleClickZooms ? "1" : "0");
		objWriter.WriteAttributeString("ShowMapStreetview", (ShowMapStreetviewControl ? "1" : "0") + ";" + MapStreetviewControlPosition);
		objWriter.WriteAttributeString("ShowMapPan", (ShowMapPanControl ? "1" : "0") + ";" + MapPanControlPosition);
		objWriter.WriteAttributeString("ShowMapRotate", (ShowMapRotateControl ? "1" : "0") + ";" + MapRotateControlPosition);
		objWriter.WriteAttributeString("ShowMapScale", (ShowMapScaleControl ? "1" : "0") + ";" + MapScaleControlPosition);
		objWriter.WriteAttributeString("EnableDragging", MapDraggingEnabled ? "1" : "0");
		string empty = string.Empty;
		empty = empty + (ShowMapTypeControl ? "1" : "0") + ";";
		switch (MapControlType)
		{
		case GoogleMapControlType.Default:
		case GoogleMapControlType.DropdownMenu:
		case GoogleMapControlType.HorizontalBar:
			empty = empty + MapControlType.ToString() + ";";
			break;
		default:
			empty += "Default;";
			break;
		}
		empty = empty + MapControlPosition.ToString() + ";";
		if (MapControlMaps == null || MapControlMaps.isBlank())
		{
			empty += GoogleMapType.RoadMap;
		}
		else
		{
			string text = string.Empty;
			if (MapControlMaps.RoadMap)
			{
				text = text + (string.IsNullOrEmpty(text) ? "" : ", ") + GoogleMapType.RoadMap;
			}
			if (MapControlMaps.Hybrid)
			{
				text = text + (string.IsNullOrEmpty(text) ? "" : ", ") + GoogleMapType.Hybrid;
			}
			if (MapControlMaps.Satellite)
			{
				text = text + (string.IsNullOrEmpty(text) ? "" : ", ") + GoogleMapType.Satellite;
			}
			if (MapControlMaps.Terrain)
			{
				text = text + (string.IsNullOrEmpty(text) ? "" : ", ") + GoogleMapType.Terrain;
			}
			if (MapControlMaps.OpenStreatMap)
			{
				text = text + (string.IsNullOrEmpty(text) ? "" : ", ") + GoogleMapType.OpenStreatMap;
			}
			empty += text;
		}
		objWriter.WriteAttributeString("ShowMapTypes", empty);
		string text2 = string.Empty;
		foreach (GoogleMapLatLngBoundsQueueElement item in marrMapLatLngBoundsQueue)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				text2 += ";";
			}
			if (item.menmBoundsUpdateType == GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Fit)
			{
				text2 = text2 + "Fit;" + item.SouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.SouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + ";" + item.NorthEast.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.NorthEast.Longitude.ToString(CultureInfo.InvariantCulture);
			}
			else if (item.menmBoundsUpdateType == GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.Pan)
			{
				text2 = text2 + "Pan;" + item.SouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.SouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + ";" + item.NorthEast.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.NorthEast.Longitude.ToString(CultureInfo.InvariantCulture);
			}
			else if (item.menmBoundsUpdateType == GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.FitLocation)
			{
				text2 = text2 + "FitLoc;" + item.SouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.SouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + ";0;0";
			}
			else if (item.menmBoundsUpdateType == GoogleMapLatLngBoundsQueueElement.BoundsUpdateType.PanLocation)
			{
				text2 = text2 + "PanLoc;" + item.SouthWest.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + item.SouthWest.Longitude.ToString(CultureInfo.InvariantCulture) + ";0;0";
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			objWriter.WriteAttributeString("Bounds", text2);
		}
		if (marrMapLatLngBoundsQueue.Count > 0)
		{
			marrMapLatLngBoundsQueue.Clear();
		}
		if (string.IsNullOrEmpty(text2) || mblnLocationHasChanged)
		{
			objWriter.WriteAttributeString("Location", MapLocation.Latitude.ToString(CultureInfo.InvariantCulture) + ";" + MapLocation.Longitude.ToString(CultureInfo.InvariantCulture));
			objWriter.WriteAttributeString("Address", MapAddress);
		}
		mblnLocationHasChanged = false;
		objWriter.WriteAttributeString("Heading", MapHeading.ToString(CultureInfo.InvariantCulture));
		if (!string.IsNullOrEmpty(MapOpenStreatMapName))
		{
			objWriter.WriteAttributeString("OSMName", MapOpenStreatMapName);
		}
		if (!string.IsNullOrEmpty(MapOpenStreatMapUrl))
		{
			objWriter.WriteAttributeString("OSMUrl", MapOpenStreatMapUrl);
		}
	}

	/// <summary>
	/// Render the overlays - There can be multiple instances of each overlay type
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	internal void RenderOverlays(IContext objContext, IResponseWriter objWriter)
	{
		GoogleMapOverlayCollection value = GetValue<GoogleMapOverlayCollection>(MapOverlaysProperty, null);
		if (value == null)
		{
			return;
		}
		objWriter.WriteStartElement("Overlays");
		foreach (GoogleMapOverlay item in value)
		{
			objWriter.WriteStartElement("Overlay");
			item.Render(objContext, (IAttributeWriter)objWriter);
			objWriter.WriteEndElement();
		}
		objWriter.WriteEndElement();
	}

	/// <summary>
	/// Render the layers - Only one instance of each layer type is supported
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	internal void RenderLayers(IContext objContext, IResponseWriter objWriter)
	{
		GoogleMapLayerCollection value = GetValue<GoogleMapLayerCollection>(MapLayersProperty, null);
		if (value == null)
		{
			return;
		}
		objWriter.WriteStartElement("Layers");
		foreach (GoogleMapLayer item in value)
		{
			objWriter.WriteStartElement("Layer");
			item.Render(objContext, (IAttributeWriter)objWriter);
			objWriter.WriteEndElement();
		}
		objWriter.WriteEndElement();
	}

	/// <summary>
	/// Renders the controls sub tree
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
	{
		RenderOverlays(objContext, objWriter);
		RenderLayers(objContext, objWriter);
	}

	/// <summary>
	/// Call when an overlay is added/deleted/updated
	/// </summary>
	public void UpdateOverlays()
	{
		base.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// Call when a layer has been added/deleted/updated
	/// </summary>
	public void UpdateLayers()
	{
		foreach (GoogleMapLayer mapLayer in MapLayers)
		{
			if (mapLayer.ParentMap != this)
			{
				mapLayer.ParentMap = this;
			}
		}
		base.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
	}

	/// <summary>
	/// GoogleMap needs update after change of Bounds (Location, Size, ...)
	/// </summary>
	/// <param name="intLeft"></param>
	/// <param name="intTop"></param>
	/// <param name="intWidth"></param>
	/// <param name="intHeight"></param>
	/// <param name="enmSpecified"></param>
	/// <returns></returns>
	protected override bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
	{
		if (base.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified))
		{
			base.Update(blnRedrawOnly: true, blnUseClientUpdateHandler: false);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Shoulds the serialize map location.
	/// </summary>
	/// <returns></returns>
	private bool ShouldSerializeMapLocation()
	{
		return !MapLocation.Equals(DefaultMapLocation);
	}

	/// <summary>
	/// Resets the MapControlMaps
	/// </summary>
	private void ResetMapControlMaps()
	{
		MapControlMaps = GoogleMapMapTypes.DefaultMapTypes();
	}

	/// <summary>
	/// Resets the MapLocation
	/// </summary>
	private void ResetMapLocation()
	{
		MapLocation = DefaultMapLocation;
	}

	static GoogleMap()
	{
		MapRightClickEvent = SerializableEvent.Register("MapRightClick", typeof(GoogleMapEventHandler), typeof(GoogleMap));
		MapDoubleClickEvent = SerializableEvent.Register("MapDoubleClick", typeof(GoogleMapEventHandler), typeof(GoogleMap));
		MapClickEvent = SerializableEvent.Register("MapClick", typeof(GoogleMapEventHandler), typeof(GoogleMap));
		MapBoundsChangedEvent = SerializableEvent.Register("MapBoundsChanged", typeof(EventHandler), typeof(GoogleMap));
		MapHeadingChangedEvent = SerializableEvent.Register("MapHeadingChanged", typeof(EventHandler), typeof(GoogleMap));
		MapLocationChangedEvent = SerializableEvent.Register("MapLocationChanged", typeof(EventHandler), typeof(GoogleMap));
		MapAddressChangedEvent = SerializableEvent.Register("MapAddressChanged", typeof(EventHandler), typeof(GoogleMap));
		MapAddressGEOSearchedEvent = SerializableEvent.Register("MapAddressGEOSearched", typeof(EventHandler), typeof(GoogleMap));
		MapZoomLevelChangedEvent = SerializableEvent.Register("MapZoomLevelChanged", typeof(EventHandler), typeof(GoogleMap));
		MapTypeChangedEvent = SerializableEvent.Register("MapTypeChanged", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayClickEvent = SerializableEvent.Register("MapOverlayClick", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayDoubleClickEvent = SerializableEvent.Register("MapOverlayDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayLocationChangedEvent = SerializableEvent.Register("MapOverlayLocationChanged", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayRightClickEvent = SerializableEvent.Register("MapOverlayRightClick", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayInfoOpenedEvent = SerializableEvent.Register("MapOverlayInfoOpened", typeof(EventHandler), typeof(GoogleMap));
		MapOverlayInfoClosedEvent = SerializableEvent.Register("MapOverlayInfoClosed", typeof(EventHandler), typeof(GoogleMap));
		MapKmlLayerClickEvent = SerializableEvent.Register("MapKmlLayerClick", typeof(EventHandler), typeof(GoogleMap));
		MapWeatherLayerClickEvent = SerializableEvent.Register("MapWeatherLayerClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolylineOverlayClickEvent = SerializableEvent.Register("MapPolylineClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolylineOverlayDoubleClickEvent = SerializableEvent.Register("MapPolylineDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolylineOverlayRightClickEvent = SerializableEvent.Register("MapPolylineRightClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolygonOverlayClickEvent = SerializableEvent.Register("MapPolygonClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolygonOverlayDoubleClickEvent = SerializableEvent.Register("MapPolygonDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapPolygonOverlayRightClickEvent = SerializableEvent.Register("MapPolygonRightClick", typeof(EventHandler), typeof(GoogleMap));
		MapRectangleOverlayClickEvent = SerializableEvent.Register("MapRectangleClick", typeof(EventHandler), typeof(GoogleMap));
		MapRectangleOverlayDoubleClickEvent = SerializableEvent.Register("MapRectangleDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapRectangleOverlayRightClickEvent = SerializableEvent.Register("MapRectangleRightClick", typeof(EventHandler), typeof(GoogleMap));
		MapCircleOverlayClickEvent = SerializableEvent.Register("MapCircleClick", typeof(EventHandler), typeof(GoogleMap));
		MapCircleOverlayDoubleClickEvent = SerializableEvent.Register("MapCircleDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapCircleOverlayRightClickEvent = SerializableEvent.Register("MapCircleRightClick", typeof(EventHandler), typeof(GoogleMap));
		MapGroundOverlayClickEvent = SerializableEvent.Register("MapGroundClick", typeof(EventHandler), typeof(GoogleMap));
		MapGroundOverlayDoubleClickEvent = SerializableEvent.Register("MapGroundDoubleClick", typeof(EventHandler), typeof(GoogleMap));
		MapInfoWindowClosedEvent = SerializableEvent.Register("MapInfoWindowClosed", typeof(EventHandler), typeof(GoogleMap));
	}
}
