using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Kml layer
/// </summary>
[Serializable]
public class GoogleMapKmlLayer : GoogleMapLayer
{
	/// <summary>
	/// The Clickable property registration.
	/// </summary>
	private static readonly SerializableProperty ClickableProperty = SerializableProperty.Register("Clickable", typeof(bool), typeof(GoogleMapKmlLayer));

	/// <summary>
	/// The PreserveViewPort property registration.
	/// </summary>
	private static readonly SerializableProperty PreserveViewPortProperty = SerializableProperty.Register("PreserveViewPort", typeof(bool), typeof(GoogleMapKmlLayer));

	/// <summary>
	/// The SuppressInfoWindows property registration.
	/// </summary>
	private static readonly SerializableProperty SuppressInfoWindowsProperty = SerializableProperty.Register("SuppressInfoWindows", typeof(bool), typeof(GoogleMapKmlLayer));

	/// <summary>
	/// The KmlReferenceUrl property registration.
	/// </summary>
	private static readonly SerializableProperty KmlReferenceUrlProperty = SerializableProperty.Register("KmlReferenceUrl", typeof(string), typeof(GoogleMapKmlLayer));

	/// <summary>
	/// Does layer type allow multiple instances of the same layer type on a single GoogleMap
	/// </summary>
	[SRDescription("Does layer type allow multiple instances of the same layer type on a single GoogleMap.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AllowMultipleInstances => true;

	/// <summary>
	/// Are the KML layer reference points clickable
	/// </summary>
	[SRDescription("Are the KML layer reference points clickable.")]
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
	/// Preserve current viewport when layer is added. False means viewport is changed to be inside the bounding box of the layer
	/// </summary>
	[SRDescription("Preserve current viewport when layer is added. False means viewport is changed to be inside the bounding box of the layer.")]
	[DefaultValue(false)]
	public bool PreserveViewPort
	{
		get
		{
			return GetValue(PreserveViewPortProperty, objDefault: false);
		}
		set
		{
			SetValue(PreserveViewPortProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// Let client handle info windows (true) or fire event to the server (false)
	/// </summary>
	[SRDescription("Let client handle info windows (true) or fire event to the server (false).")]
	[DefaultValue(true)]
	public bool SuppressInfoWindows
	{
		get
		{
			return GetValue(SuppressInfoWindowsProperty, objDefault: true);
		}
		set
		{
			SetValue(SuppressInfoWindowsProperty, value, objDefaultValue: true);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// An Url for the KML or KMZ reference points
	/// </summary>
	[SRDescription("An Url for the KML or KMZ reference points.")]
	[DefaultValue("")]
	public string KmlReferenceUrl
	{
		get
		{
			return GetValue(KmlReferenceUrlProperty, "");
		}
		set
		{
			SetValue(KmlReferenceUrlProperty, value);
			UpdateParentMap();
		}
	}

	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.KmlLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapKmlLayer()
	{
	}

	/// <summary>
	/// Render the attributes for the layer
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		objWriter.WriteAttributeString("Clickable", Clickable ? "1" : "0");
		objWriter.WriteAttributeString("PreserveViewport", PreserveViewPort ? "1" : "0");
		objWriter.WriteAttributeString("SuppressInfoWindows", SuppressInfoWindows ? "1" : "0");
		objWriter.WriteAttributeString("ReferenceUrl", KmlReferenceUrl);
	}
}
