using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Absract base class for Layers
/// </summary>
[Serializable]
[DesignTimeVisible(false)]
[TypeConverter(typeof(GoogleMapLayerConverter))]
public abstract class GoogleMapLayer : GoogleMapObject
{
	/// <summary>
	/// Storage for reference to parent map.
	/// </summary>
	private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjParentMap;

	/// <summary>
	/// Abstract (must override) type of the Layer
	/// </summary>
	[SRDescription("The type of layer.")]
	public abstract GoogleMapLayerType LayerType { get; }

	/// <summary>
	/// Does layer type allow multiple instances of the same layer type on a single GoogleMap
	/// </summary>
	[SRDescription("Does layer type allow multiple instances of the same layer type on a single GoogleMap.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool AllowMultipleInstances => false;

	/// <summary>
	/// MemberID for current instance
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public long LayerID => base.internalID;

	/// <summary>
	/// Reference to parent map to support cascaded updates
	/// </summary>
	internal Gizmox.WebGUI.Forms.Professional.GoogleMap ParentMap
	{
		get
		{
			return mobjParentMap;
		}
		set
		{
			mobjParentMap = value;
		}
	}

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapLayer()
	{
	}

	/// <summary>
	/// Renders the Layer attributes.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		objWriter.WriteAttributeString("LayerID", LayerID);
		objWriter.WriteAttributeString("LayerType", LayerType.ToString());
	}

	internal void UpdateParentMap()
	{
		if (ParentMap != null)
		{
			ParentMap.UpdateLayers();
		}
	}
}
