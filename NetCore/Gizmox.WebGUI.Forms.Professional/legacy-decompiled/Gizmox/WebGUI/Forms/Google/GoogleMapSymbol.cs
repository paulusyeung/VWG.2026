using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap Symbol class
/// </summary>
[Serializable]
[TypeConverter(typeof(GoogleMapSymbolConverter))]
public class GoogleMapSymbol
{
	private Point mobjAnchor;

	private Color mobjFillColor;

	private double mdblFillOpacity;

	private GoogleMapSymbolPath menumPath;

	private double mdblRotation;

	private double mdblScale = 1.0;

	private Color mobjStrokeColor;

	private double mdblStrokeOpacity;

	private double mdblStrokeWeight;

	/// <summary>
	/// The symbol's stroke weight. Defaults to the scale of the symbol.
	/// </summary>
	public double StrokeWeight
	{
		get
		{
			return mdblStrokeWeight;
		}
		set
		{
			if (mdblStrokeWeight != value)
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("StrokeWeight must be a positive number");
				}
				mdblStrokeWeight = value;
			}
		}
	}

	/// <summary>
	/// The symbol's stroke opacity. For symbol markers, this defaults to 1. For symbols on a polyline, this defaults to the stroke opacity of the polyline.
	/// </summary>
	public double StrokeOpacity
	{
		get
		{
			return mdblStrokeOpacity;
		}
		set
		{
			if (mdblStrokeOpacity != value)
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Opacity needs to be between 0 and 1");
				}
				mdblStrokeOpacity = value;
			}
		}
	}

	/// <summary>
	/// The symbol's stroke color. All CSS3 colors are supported except for extended named colors. For symbol markers, this defaults to 'black'. For symbols on a polyline, this defaults to the stroke color of the polyline.
	/// </summary>
	public Color StrokeColor
	{
		get
		{
			return mobjStrokeColor;
		}
		set
		{
			mobjStrokeColor = value;
		}
	}

	/// <summary>
	/// The amount by which the symbol is scaled in size. For symbol markers, this defaults to 1; after scaling the symbol may be of any size. For symbols on a polyline, this defaults to the stroke weight of the polyline; after scaling, the symbol must lie inside a square 22 pixels in size centered at the symbol's anchor.
	/// </summary>
	public double Scale
	{
		get
		{
			return mdblScale;
		}
		set
		{
			mdblScale = value;
		}
	}

	/// <summary>
	/// The fixed angle by which to rotate the symbol, expressed clockwise in degrees. By default, a symbol marker has a rotation of 0, and a symbol on a polyline is rotated by the angle of the edge on which it lies.
	/// </summary>
	public double Rotation
	{
		get
		{
			return mdblRotation;
		}
		set
		{
			mdblRotation = value;
		}
	}

	/// <summary>
	/// The symbol's path, which is a built-in symbol path (custom paths not yet supported)
	/// </summary>
	public GoogleMapSymbolPath Path
	{
		get
		{
			return menumPath;
		}
		set
		{
			menumPath = value;
		}
	}

	/// <summary>
	/// The symbol's fill opacity. Defaults to 0.
	/// </summary>
	public double FillOpacity
	{
		get
		{
			return mdblFillOpacity;
		}
		set
		{
			if (mdblFillOpacity != value)
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Opacity needs to be between 0 and 1");
				}
				mdblFillOpacity = value;
			}
		}
	}

	/// <summary>
	/// The symbol's fill color. All CSS3 colors are supported except for extended named colors. For symbol markers, this defaults to 'black'. For symbols on polylines, this defaults to the stroke color of the corresponding polyline.
	/// </summary>
	public Color FillColor
	{
		get
		{
			return mobjFillColor;
		}
		set
		{
			mobjFillColor = value;
		}
	}

	/// <summary>
	/// The position of the symbol relative to the marker or polyline. The coordinates of the symbol's path are translated left and up by the anchor's x and y coordinates respectively. By default, a symbol is anchored at (0, 0). The position is expressed in the same coordinate system as the symbol's path.
	/// </summary>
	public Point Anchor
	{
		get
		{
			return mobjAnchor;
		}
		set
		{
			mobjAnchor = value;
		}
	}

	public GoogleMapSymbol()
	{
	}

	/// <summary>
	/// Initialize object form parameters
	/// </summary>
	/// <param name="objAnchor">The position of the symbol relative to the marker or polyline. The coordinates of the symbol's path are translated left and up by the anchor's x and y coordinates respectively. By default, a symbol is anchored at (0, 0). The position is expressed in the same coordinate system as the symbol's path.</param>
	/// <param name="objFillColor">The symbol's fill color. All CSS3 colors are supported except for extended named colors. For symbol markers, this defaults to 'black'. For symbols on polylines, this defaults to the stroke color of the corresponding polyline.</param>
	/// <param name="dblFillOpacity">The symbol's fill opacity. Defaults to 0.</param>
	/// <param name="enmPath">The symbol's path, which is a built-in symbol path (custom paths not yet supported)</param>
	/// <param name="dblRotation">The fixed angle by which to rotate the symbol, expressed clockwise in degrees. By default, a symbol marker has a rotation of 0, and a symbol on a polyline is rotated by the angle of the edge on which it lies.</param>
	/// <param name="dblScale">The amount by which the symbol is scaled in size. For symbol markers, this defaults to 1; after scaling the symbol may be of any size. For symbols on a polyline, this defaults to the stroke weight of the polyline; after scaling, the symbol must lie inside a square 22 pixels in size centered at the symbol's anchor.</param>
	/// <param name="objStrokeColor">The symbol's stroke color. All CSS3 colors are supported except for extended named colors. For symbol markers, this defaults to 'black'. For symbols on a polyline, this defaults to the stroke color of the polyline.</param>
	/// <param name="dblStrokeOpacity">The symbol's stroke opacity. For symbol markers, this defaults to 1. For symbols on a polyline, this defaults to the stroke opacity of the polyline.</param>
	/// <param name="dblStrokeWeight">The symbol's stroke weight. Defaults to the scale of the symbol.</param>
	public GoogleMapSymbol(Point objAnchor, Color objFillColor, double dblFillOpacity, GoogleMapSymbolPath enmPath, double dblRotation, double dblScale, Color objStrokeColor, double dblStrokeOpacity, double dblStrokeWeight)
	{
		mobjAnchor = objAnchor;
		mobjFillColor = objFillColor;
		mdblFillOpacity = dblFillOpacity;
		menumPath = enmPath;
		mdblRotation = dblRotation;
		mdblScale = dblScale;
		mobjStrokeColor = objStrokeColor;
		mdblStrokeOpacity = dblStrokeOpacity;
		mdblStrokeWeight = dblStrokeWeight;
	}
}
