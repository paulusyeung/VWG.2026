using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides a base class for maps overlays
/// </summary>
[Serializable]
[DesignTimeVisible(false)]
[TypeConverter(typeof(GoogleMapOverlayConverter))]
public abstract class GoogleMapOverlay : GoogleMapObject
{
	/// <summary>
	/// MemberID for current instance
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public long MemberID => base.internalID;

	/// <summary>
	/// Gets the type of the overlay.
	/// </summary>
	/// <value>The type of the overlay.</value>
	public abstract GoogleMapOverlayType OverlayType { get; }

	/// <summary>
	/// Returns a collection of all Location points that represent the overlay for the purpose of Fit/Pan bounds
	/// </summary>
	internal virtual GoogleMapLocationCollection OverlayRepresentedByPoints => new GoogleMapLocationCollection();

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapOverlay" /> class.
	/// </summary>
	public GoogleMapOverlay()
	{
	}

	/// <summary>
	/// Renders the overlay attributes.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		objWriter.WriteAttributeString("MemberID", MemberID);
		objWriter.WriteAttributeString("TYP", OverlayType.ToString());
	}
}
