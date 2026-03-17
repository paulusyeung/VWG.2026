using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Collection of all types of GoogleMapLayer objects
/// </summary>
[Serializable]
public class GoogleMapLayerCollection : Collection<GoogleMapLayer>
{
	/// <summary>
	/// The owning GoogleMap object. 
	/// </summary>
	private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjOwner;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapOverlayCollection" /> class.
	/// </summary>
	/// <param name="objOwner">The obj owner.</param>
	internal GoogleMapLayerCollection(Gizmox.WebGUI.Forms.Professional.GoogleMap objOwner)
	{
		mobjOwner = objOwner;
	}

	/// <summary>
	/// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
	/// </summary>
	protected override void ClearItems()
	{
		using (IEnumerator<GoogleMapLayer> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.ParentMap = null;
			}
		}
		base.ClearItems();
		mobjOwner.UpdateLayers();
	}

	/// <summary>
	/// Replaces the element at the specified index. Only one layer of each type is allowed, unless Layer.AllowMultipleInstances is true
	/// </summary>
	/// <param name="index">The zero-based index of the element to replace.</param>
	/// <param name="item">The new value for the element at the specified index. The value can be null for reference types.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 	<paramref name="index" /> is less than zero.
	/// -or-
	/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
	/// </exception>
	protected override void SetItem(int index, GoogleMapLayer item)
	{
		if (!item.AllowMultipleInstances)
		{
			int num = FindIndexByLayerType(item.LayerType);
			if (num >= 0 && num != index)
			{
				throw new NotSupportedException("Collection can contain only one instance of each layer type");
			}
		}
		base[index].ParentMap = null;
		item.ParentMap = mobjOwner;
		base.SetItem(index, item);
		mobjOwner.UpdateLayers();
	}

	/// <summary>
	/// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1" /> at the specified index. Only one layer of each type is allowed, unless Layer.AllowMultipleInstances is true.
	/// </summary>
	/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
	/// <param name="item">The object to insert. The value can be null for reference types.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 	<paramref name="index" /> is less than zero.
	/// -or-
	/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
	/// </exception>
	protected override void InsertItem(int index, GoogleMapLayer item)
	{
		if (!item.AllowMultipleInstances && FindIndexByLayerType(item.LayerType) >= 0)
		{
			throw new NotSupportedException("Collection can contain only one instance of each layer type");
		}
		item.ParentMap = mobjOwner;
		base.InsertItem(index, item);
		mobjOwner.UpdateLayers();
	}

	/// <summary>
	/// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
	/// </summary>
	/// <param name="index">The zero-based index of the element to remove.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 	<paramref name="index" /> is less than zero.
	/// -or-
	/// <paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
	/// </exception>
	protected override void RemoveItem(int index)
	{
		base[index].ParentMap = null;
		base.RemoveItem(index);
		mobjOwner.UpdateLayers();
	}

	/// <summary>
	/// Remove all instances of layer type from map.
	/// </summary>
	/// <param name="LayerType">The layer type to remove</param>
	public void RemoveItemByLayerType(GoogleMapLayerType LayerType)
	{
		for (int num = FindIndexByLayerType(LayerType); num >= 0; num = FindIndexByLayerType(LayerType))
		{
			RemoveItem(num);
		}
	}

	/// <summary>
	/// Addrange must be defined for designer to serialize code using AddRange
	/// </summary>
	/// <param name="objList"></param>
	public void AddRange(GoogleMapLayer[] objList)
	{
		if (objList != null)
		{
			for (int i = 0; i < objList.Length; i++)
			{
				Add(objList[i]);
			}
		}
	}

	/// <summary>
	/// Find index of member by LayerId
	/// </summary>
	/// <param name="intLayerId">The LayerId</param>
	/// <returns>The index or -1 if not found</returns>
	public int FindIndexByLayerId(long intLayerId)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i].LayerID == intLayerId)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// Find index of member by LayerType. For layer types that AllowMultipleInstances, first index of layer type is returned.
	/// </summary>
	/// <param name="LayerType"></param>
	/// <returns></returns>
	public int FindIndexByLayerType(GoogleMapLayerType LayerType)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i].LayerType == LayerType)
			{
				return i;
			}
		}
		return -1;
	}
}
