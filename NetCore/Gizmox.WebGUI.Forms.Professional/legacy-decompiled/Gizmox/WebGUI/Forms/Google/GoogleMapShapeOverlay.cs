using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides a base class for the Shape kind of overlays (Polyline, Polygon, Rectangle, Circle ...)
/// </summary>
[Serializable]
public abstract class GoogleMapShapeOverlay : GoogleMapOverlay
{
	/// <summary>
	/// The Visible property registration.
	/// </summary>
	private static readonly SerializableProperty VisibleProperty = SerializableProperty.Register("Visible", typeof(bool), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// The StrokeWeight property registration.
	/// </summary>
	private static readonly SerializableProperty StrokeWeightProperty = SerializableProperty.Register("StrokeWeight", typeof(double), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// The StrokeOpacity property registration.
	/// </summary>
	private static readonly SerializableProperty StrokeOpacityProperty = SerializableProperty.Register("StrokeOpacity", typeof(double), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// The StrokeColor property registration.
	/// </summary>
	private static readonly SerializableProperty StrokeColorProperty = SerializableProperty.Register("StrokeColor", typeof(Color), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// The Clickable property registration.
	/// </summary>
	private static readonly SerializableProperty ClickableProperty = SerializableProperty.Register("Clickable", typeof(bool), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// The Editable property registration.
	/// </summary>
	private static readonly SerializableProperty EditableProperty = SerializableProperty.Register("Editable", typeof(bool), typeof(GoogleMapShapeOverlay));

	/// <summary>
	/// Whether this polyline is visible on the map
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
	/// The stroke width in pixels.
	/// </summary>
	[DefaultValue(0)]
	public double StrokeWeight
	{
		get
		{
			return GetValue(StrokeWeightProperty, 0.0);
		}
		set
		{
			if (StrokeWeight != value)
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("StrokeWeight must be a positive number");
				}
				SetValue(StrokeWeightProperty, value);
			}
		}
	}

	/// <summary>
	/// The stroke opacity between 0.0 and 1.0
	/// </summary>
	[DefaultValue(0)]
	public double StrokeOpacity
	{
		get
		{
			return GetValue(StrokeOpacityProperty, 0.0);
		}
		set
		{
			if (StrokeOpacity != value)
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Opacity needs to be between 0 and 1");
				}
				SetValue(StrokeOpacityProperty, value);
			}
		}
	}

	/// <summary>
	/// The stroke color. All CSS3 colors are supported except for extended named colors.
	/// </summary>
	public Color StrokeColor
	{
		get
		{
			return GetValue<Color>(StrokeColorProperty);
		}
		set
		{
			SetValue(StrokeColorProperty, value);
		}
	}

	/// <summary>
	/// Not supported at this time: If set to true, the user can edit this shape by dragging the control points shown at the vertices and on each segment. Defaults to false.
	/// </summary>
	[DefaultValue(false)]
	internal bool Editable
	{
		get
		{
			return GetValue(EditableProperty, objDefault: false);
		}
		set
		{
			SetValue(EditableProperty, value);
		}
	}

	/// <summary>
	/// Indicates whether this Polyline handles mouse events.
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
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay" /> class.
	/// </summary>
	public GoogleMapShapeOverlay()
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
		objWriter.WriteAttributeString("Editable", Editable ? "1" : "0");
		objWriter.WriteAttributeString("StrokeColor", GoogleMapObject.RgbaFromColor(StrokeColor));
		objWriter.WriteAttributeString("StrokeOpacity", StrokeOpacity.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("StrokeWeight", StrokeWeight.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Visible", Visible ? "1" : "0");
	}
}
