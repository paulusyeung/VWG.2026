using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Collection class for all types of GoogleMapOverlay objects
/// </summary>
[Serializable]
public class GoogleMapOverlayCollection : Collection<GoogleMapOverlay>
{
	/// <summary>
	/// The owning GoogleMap object. Only used during rendering, null at all other times
	/// </summary>
	private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjOwner;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapOverlayCollection" /> class.
	/// </summary>
	/// <param name="objOwner">The obj owner.</param>
	internal GoogleMapOverlayCollection(Gizmox.WebGUI.Forms.Professional.GoogleMap objOwner)
	{
		mobjOwner = objOwner;
	}

	/// <summary>
	/// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
	/// </summary>
	protected override void ClearItems()
	{
		base.ClearItems();
		mobjOwner.UpdateOverlays();
	}

	/// <summary>
	/// Replaces the element at the specified index.
	/// </summary>
	/// <param name="index">The zero-based index of the element to replace.</param>
	/// <param name="item">The new value for the element at the specified index. The value can be null for reference types.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 	<paramref name="index" /> is less than zero.
	/// -or-
	/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
	/// </exception>
	protected override void SetItem(int index, GoogleMapOverlay item)
	{
		base.SetItem(index, item);
		mobjOwner.UpdateOverlays();
	}

	/// <summary>
	/// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1" /> at the specified index.
	/// </summary>
	/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
	/// <param name="item">The object to insert. The value can be null for reference types.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 	<paramref name="index" /> is less than zero.
	/// -or-
	/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
	/// </exception>
	protected override void InsertItem(int index, GoogleMapOverlay item)
	{
		base.InsertItem(index, item);
		mobjOwner.UpdateOverlays();
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
		base.RemoveItem(index);
		mobjOwner.UpdateOverlays();
	}

	/// <summary>
	/// Remove the specified overlay if it exists in the collection
	/// </summary>
	/// <param name="objOverlay">The overlay to remove</param>
	public void RemoveItem(GoogleMapOverlay objOverlay)
	{
		int num = FindIndexByMemberId(objOverlay.MemberID);
		if (num >= 0)
		{
			RemoveItem(num);
		}
	}

	/// <summary>
	/// Addrange must be defined for designer to serialize code using AddRange
	/// </summary>
	/// <param name="objList"></param>
	public void AddRange(GoogleMapOverlay[] objList)
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
	/// Find index of member by MemberId
	/// </summary>
	/// <param name="intMemberId">The MemberId</param>
	/// <returns>The index or -1 if not found</returns>
	public int FindIndexByMemberId(long intMemberId)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i].MemberID == intMemberId)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// Find all overlays of given type and return as an array
	/// </summary>
	/// <param name="enmOverlayType">The overlay type to search for</param>
	/// <returns></returns>
	public GoogleMapOverlay[] OverlaysOfType(GoogleMapOverlayType enmOverlayType)
	{
		ArrayList arrayList = new ArrayList();
		using (IEnumerator<GoogleMapOverlay> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GoogleMapOverlay current = enumerator.Current;
				if (current.OverlayType == enmOverlayType)
				{
					arrayList.Add(current);
				}
			}
		}
		return (GoogleMapOverlay[])arrayList.ToArray(typeof(GoogleMapOverlay));
	}
}
