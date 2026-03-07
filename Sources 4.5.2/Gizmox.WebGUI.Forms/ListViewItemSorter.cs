#region Using

using System;
using System.Collections;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region ListViewItemSorter Class
	
	/// <summary>
    /// Gets or sets the sorting comparer for the control.
    /// </summary>
	///	<returns>An <see cref="T:System.Collections.IComparer"></see> that represents the sorting comparer for the control.</returns>

    [Serializable()]
    public class ListViewItemSorter : IComparer
	{
		#region Class Members
		
		private ListView		mobjListView		= null;
		

		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ListViewItemSorter"/> instance.
		/// </summary>
		/// <param name="objListView">list view.</param>
		public ListViewItemSorter(ListView objListView)
		{
			mobjListView = objListView;
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region IComparer Members
		
		/// <summary>
		/// Compares two ListView Items
		/// </summary>
		/// <param name="objObjectA">object A.</param>
		/// <param name="objObjectB">object B.</param>
		/// <returns></returns>
		public int Compare(object objObjectA, object objObjectB)
		{
			// Get list viewitems
			ListViewItem objItemA = objObjectA as ListViewItem;
			ListViewItem objItemB = objObjectB as ListViewItem;

            ICollection objSortingColumns = mobjListView.SortingColumns;

			// Check valid items
			if(objItemA!=null && objItemB!=null)
			{
				// Check that there are columns
                if (objSortingColumns.Count == 0)
				{
					return 0;
				}
				else
				{
					// Loop all sorting columns
                    foreach (ColumnHeader objColumn in objSortingColumns)
					{
						// Get sorting direction
						int intDirection = (objColumn.SortOrder == SortOrder.Ascending)?1:-1;
						
						// The comparison result
						int intResult = 0;
						intResult = objItemA.SubItems[objColumn.Index].Text.CompareTo(objItemB.SubItems[objColumn.Index].Text);
						if(intResult!=0) return intResult*intDirection;
					}
					
					return 0;
				}
			}
			else
			{
				return 0;
			}
		}
		
		
		#endregion IComparer Members
		

		
	}
	
	#endregion ListViewItemSorter Class
	
}
