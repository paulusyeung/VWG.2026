using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap class for which map types to show on the Map control
/// </summary>
[Serializable]
[TypeConverter(typeof(GoogleMapTypesConverter))]
public class GoogleMapMapTypes
{
	private bool mblnRoadMap;

	private bool mblnHybrid;

	private bool mblnSatellite;

	private bool mblnTerrain;

	private bool mblnOpenStreatMap;

	internal Gizmox.WebGUI.Forms.Professional.GoogleMap mobjParentMap;

	/// <summary>
	/// Show RoadMap type on map control
	/// </summary>
	public bool RoadMap
	{
		get
		{
			return mblnRoadMap;
		}
		set
		{
			mblnRoadMap = value;
			if (mobjParentMap != null)
			{
				mobjParentMap.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Show Hybrid map on map control
	/// </summary>
	public bool Hybrid
	{
		get
		{
			return mblnHybrid;
		}
		set
		{
			mblnHybrid = value;
			if (mobjParentMap != null)
			{
				mobjParentMap.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Show Satellite map on map control
	/// </summary>
	public bool Satellite
	{
		get
		{
			return mblnSatellite;
		}
		set
		{
			mblnSatellite = value;
			if (mobjParentMap != null)
			{
				mobjParentMap.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Show Terrain map on map control
	/// </summary>
	public bool Terrain
	{
		get
		{
			return mblnTerrain;
		}
		set
		{
			mblnTerrain = value;
			if (mobjParentMap != null)
			{
				mobjParentMap.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Show OpenStreatMap map on map control
	/// </summary>
	public bool OpenStreatMap
	{
		get
		{
			return mblnOpenStreatMap;
		}
		set
		{
			mblnOpenStreatMap = value;
			if (mobjParentMap != null)
			{
				mobjParentMap.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
			}
		}
	}

	/// <summary>
	/// Initializes the object with default values, showing only RoadMap
	/// </summary>
	public GoogleMapMapTypes()
	{
		mblnRoadMap = true;
	}

	/// <summary>
	/// Initialize object from parameters
	/// </summary>
	/// <param name="blnRoadMap">Show RoadMap on control</param>
	/// <param name="blnHybrid">Show Hybrid map on control</param>
	/// <param name="blnSatellite">Show Satellite map on control</param>
	/// <param name="blnTerrain">Show Terrain map on control</param>
	/// <param name="blnTerrain">Show OpenStreatMap map on control</param>
	public GoogleMapMapTypes(bool blnRoadMap, bool blnHybrid, bool blnSatellite, bool blnTerrain, bool blnOpenStreatMap)
	{
		mblnRoadMap = blnRoadMap;
		mblnHybrid = blnHybrid;
		mblnSatellite = blnSatellite;
		mblnTerrain = blnTerrain;
		mblnOpenStreatMap = blnOpenStreatMap;
	}

	/// <summary>
	/// Initialize object from parameters
	/// </summary>
	/// <param name="blnRoadMap">Show RoadMap on control</param>
	/// <param name="blnHybrid">Show Hybrid map on control</param>
	/// <param name="blnSatellite">Show Satellite map on control</param>
	/// <param name="blnTerrain">Show Terrain map on control</param>
	public GoogleMapMapTypes(bool blnRoadMap, bool blnHybrid, bool blnSatellite, bool blnTerrain)
	{
		mblnRoadMap = blnRoadMap;
		mblnHybrid = blnHybrid;
		mblnSatellite = blnSatellite;
		mblnTerrain = blnTerrain;
		mblnOpenStreatMap = false;
	}

	public static GoogleMapMapTypes DefaultMapTypes()
	{
		return new GoogleMapMapTypes();
	}

	/// <summary>
	/// Are all map types at false
	/// </summary>
	/// <returns></returns>
	public bool isBlank()
	{
		if (!mblnRoadMap && !mblnHybrid && !mblnSatellite && !mblnTerrain)
		{
			return !mblnOpenStreatMap;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		GoogleMapMapTypes googleMapMapTypes = (GoogleMapMapTypes)obj;
		if (mblnHybrid == googleMapMapTypes.Hybrid && RoadMap == googleMapMapTypes.RoadMap && Satellite == googleMapMapTypes.Satellite && Terrain == googleMapMapTypes.Terrain)
		{
			return OpenStreatMap == googleMapMapTypes.OpenStreatMap;
		}
		return false;
	}
}
