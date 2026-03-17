using System;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Collection class for GoogleMapLocationCollection objects (Collection of collections)
/// </summary>
[Serializable]
public class GoogleMapLocationCollectionCollection : Collection<GoogleMapLocationCollection>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapLocationCollection" /> class.
	/// </summary>
	/// <param name="objOwner">The obj owner.</param>
	internal GoogleMapLocationCollectionCollection()
	{
	}

	/// <summary>
	/// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
	/// </summary>
	protected override void ClearItems()
	{
		base.ClearItems();
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
	protected override void SetItem(int index, GoogleMapLocationCollection item)
	{
		base.SetItem(index, item);
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
	protected override void InsertItem(int index, GoogleMapLocationCollection item)
	{
		base.InsertItem(index, item);
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
	}
}
