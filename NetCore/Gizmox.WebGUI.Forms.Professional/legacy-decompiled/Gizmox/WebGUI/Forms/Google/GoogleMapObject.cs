using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Absract base class for Layers and Overlays
/// </summary>
[Serializable]
[DesignTimeVisible(false)]
public abstract class GoogleMapObject : SerializableObject
{
	/// <summary>
	/// Register the Tag property
	/// </summary>
	private static SerializableProperty TagProperty = SerializableProperty.Register("Tag", typeof(object), typeof(Component), new SerializablePropertyMetadata(null));

	/// <summary>
	/// Static counter for unique MemberID allocation
	/// </summary>
	private static long mlngLastID = 0L;

	private long mlngInternalID;

	[Localizable(false)]
	[Bindable(true)]
	[TypeConverter(typeof(StringConverter))]
	[SRCategory("CatData")]
	[SRDescription("ControlTagDescr")]
	[DefaultValue(null)]
	public object Tag
	{
		get
		{
			return GetValue<object>(TagProperty);
		}
		set
		{
			SetValue(TagProperty, value);
		}
	}

	/// <summary>
	/// MemberID for current instance
	/// </summary>
	internal long internalID => mlngInternalID;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapObject()
	{
		AllocateMemberID();
	}

	/// <summary>
	/// Renders the overlay.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	internal void Render(IContext objContext, IAttributeWriter objWriter)
	{
		RenderAttributes(objContext, objWriter);
	}

	/// <summary>
	/// Renders the overlay attributes.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
	}

	/// <summary>
	/// Allocate MemberID for current instance
	/// </summary>
	private void AllocateMemberID()
	{
		if (mlngInternalID <= 0)
		{
			mlngInternalID = mlngLastID++;
		}
	}

	/// <summary>
	/// Convert System.Drawing.Color to CSS3 compatible client value
	/// </summary>
	/// <param name="objColor"></param>
	/// <returns></returns>
	public static string RgbaFromColor(Color objColor)
	{
		return $"rgba({objColor.R},{objColor.G},{objColor.B},{objColor.A})";
	}
}
