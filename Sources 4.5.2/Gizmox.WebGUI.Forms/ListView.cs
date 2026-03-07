#region Using

using System;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Dialogs;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing.Design;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    /// <summary>
    /// A list item event handler delegate
    /// </summary>
    public delegate void ListViewItemEventHandler(object objSource, ListViewItemEventArgs objArgs);

    #endregion Delegates

    #region Enums

    /// <summary>
    /// The list display mode
    /// </summary>
    public enum View
    {
        /// <summary>
        /// Details
        /// </summary>
        Details,
        /// <summary>
        /// LargeIcon
        /// </summary>
        LargeIcon,
        /// <summary>
        /// List
        /// </summary>
        List,
        /// <summary>
        /// SmallIcon
        /// </summary>
        SmallIcon,

        /// <summary>
        /// <summary>Each item appears as a full-sized icon with the item label and subitem information to the right of it. The subitem information that appears is specified by the application. This view is available only on Windows XP and the Windows Server 2003 family. On earlier operating systems, this value is ignored and the <see cref="T:System.Windows.Forms.ListView"></see> control displays in the <see cref="F:System.Windows.Forms.View.LargeIcon"></see> view.</summary>
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        Tile
    }

    /// <summary>
    /// ListViewColumn Types
    /// </summary>
    public enum ListViewColumnType
    {
        /// <summary>
        /// Text
        /// </summary>
        Text = 0,
        /// <summary>
        /// Number
        /// </summary>
        Number = 1,
        /// <summary>
        /// Date
        /// </summary>
        Date = 2,
        /// <summary>
        /// Icon
        /// </summary>
        Icon = 3,
        /// <summary>
        /// Control
        /// </summary>
        Control = 4
    }

    /// <summary>
    /// ItemActivation 
    /// </summary>
    public enum ItemActivation
    {
        // Fields
        /// <summary>
        /// OneClick
        /// </summary>
        OneClick = 1,
        /// <summary>
        /// Standard
        /// </summary>
        Standard = 0,
        /// <summary>
        /// TwoClick
        /// </summary>
        TwoClick = 2
    }

    /// <summary>Provides a directional hint of where to search for a <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see>.</summary>
    public enum SearchDirectionHint
    {
        /// <summary>Below the current item.</summary>
        Down = 40,
        /// <summary>To the left of the current item</summary>
        Left = 0x25,
        /// <summary>To the right of the current item.</summary>
        Right = 0x27,
        /// <summary>Above the current item.</summary>
        Up = 0x26
    }

    #endregion Enums

    #region ListView Class

    /// <summary>
    /// A ListView control.
    /// </summary>
    /// <remarks>
    /// The list view control is used to display a list of items.
    /// </remarks>
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DefaultEvent("SelectedIndexChanged")]
    [ToolboxItemCategory("Common Controls")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ListView), "ListView_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ListView), "ListView.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif
    [MetadataTag(WGTags.ListView)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.ListViewSkin)), Serializable()]
    [ProxyComponent(typeof(ProxyListView))]
    public class ListView : Control, IComparer
    {

        #region Classes

        #region ListViewNativeItemCollection Class

        /// <summary>
        /// Provides an implementation for internal list of items for listview control
        /// </summary>
        [Serializable]
        internal class ListViewNativeItemCollection : ListView.ListViewItemCollection.IInnerList
        {
            /// <summary>
            /// The internal array list
            /// </summary>
            private ArrayList mobjList;

            /// <summary>
            /// The owning listview
            /// </summary>
            private ListView mobjListView;

            /// <summary>
            /// Gets the list.
            /// </summary>
            /// <value>The list.</value>
            private ArrayList List
            {
                get
                {
                    if (mobjList == null)
                    {
                        mobjList = new ArrayList();
                    }
                    return mobjList;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ListViewNativeItemCollection"/> class.
            /// </summary>
            /// <param name="objListView">The owner list view.</param>
            public ListViewNativeItemCollection(ListView objListView)
            {
                mobjListView = objListView;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ListViewNativeItemCollection"/> class.
            /// </summary>
            /// <param name="objListView">The owner list view.</param>
            /// <param name="arrItems">The arr items.</param>
            internal ListViewNativeItemCollection(ListView objListView, object[] arrItems)
            {
                mobjListView = objListView;
                mobjList = new ArrayList(arrItems);
            }

            /// <summary>
            /// Adds the specified item.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns></returns>
            public ListViewItem Add(ListViewItem value)
            {
                this.List.Add(value);
                value.InternalListView = mobjListView;
                mobjListView.Update();
                return value;
            }

            /// <summary>
            /// Adds the range.
            /// </summary>
            /// <param name="arrItems">The items.</param>
            public void AddRange(ListViewItem[] arrItems)
            {
                this.List.AddRange(arrItems);
            }

            /// <summary>
            /// Clears the items.
            /// </summary>
            public void Clear()
            {
                // unregister all list components
                mobjListView.UnRegisterBatch(this.List);
                mobjListView.SelectedIndex = -1;

                // We should clear the paging only if using internal paging
                if (mobjListView.UseInternalPaging)
                {
                    mobjListView.ClearPaging();
                }
                mobjListView.Update();

                // Clear items from internal list
                this.List.Clear();
            }

            /// <summary>
            /// Determines whether [contains] [the specified item].
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns>
            /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
            /// </returns>
            public bool Contains(ListViewItem objItem)
            {
                return this.List.Contains(objItem);
            }

            /// <summary>
            /// Copies to.
            /// </summary>
            /// <param name="objDestinationArray">The dest.</param>
            /// <param name="index">The index.</param>
            public void CopyTo(Array objDestinationArray, int index)
            {
                this.List.CopyTo(objDestinationArray, index);
            }

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                return this.List.GetEnumerator();
            }

            /// <summary>
            /// Indexes the of.
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public int IndexOf(ListViewItem objItem)
            {
                return this.List.IndexOf(objItem);
            }

            /// <summary>
            /// Inserts the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public ListViewItem Insert(int index, ListViewItem objItem)
            {
                this.List.Insert(index, objItem);

                objItem.InternalListView = mobjListView;
                mobjListView.Update();

                return objItem;
            }

            /// <summary>
            /// Removes the specified obj list view item.
            /// </summary>
            /// <param name="objListViewItem">The obj list view item.</param>
            public void Remove(ListViewItem objListViewItem)
            {
                Boolean blnItemWasSelected = objListViewItem.Selected;

                // Clear parent if needed
                if (objListViewItem.InternalParent == mobjListView)
                {
                    objListViewItem.InternalUnRegisterSelf();
                    objListViewItem.InternalParent = null;
                }


                this.List.Remove(objListViewItem);

                if (mobjListView != null)
                {
                    // unregister item
                    mobjListView.UnRegisterComponent(objListViewItem);

                    if (blnItemWasSelected)
                    {
                        mobjListView.OnSelectedIndexChanged(EventArgs.Empty);
                    }

                    // Check if cuurent page exceeding total pages.
                    if (mobjListView.CurrentPage > mobjListView.TotalPages)
                    {
                        // Set current page to lasrt page.
                        mobjListView.CurrentPage = mobjListView.TotalPages;
                    }

                    // Update listview item
                    mobjListView.Update();
                }
            }

            /// <summary>
            /// Removes at.
            /// </summary>
            /// <param name="index">The index.</param>
            public void RemoveAt(int index)
            {
                this.List.RemoveAt(index);

                if (mobjListView != null)
                {
                    // Check if cuurent page exceeding total pages.
                    if (mobjListView.CurrentPage > mobjListView.TotalPages)
                    {
                        // Set current page to lasrt page.
                        mobjListView.CurrentPage = mobjListView.TotalPages;

                        // Update listview item
                        mobjListView.Update();
                    }
                }
            }


            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value>The count.</value>
            public int Count
            {
                get
                {
                    return this.List.Count;
                }
            }

            /// <summary>
            /// Gets the list view.
            /// </summary>
            /// <value>The list view.</value>
            public ListView ListView
            {
                get
                {
                    return mobjListView;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.ListViewItem"/> with the specified display index.
            /// </summary>
            /// <value></value>
            public ListViewItem this[int intDisplayIndex]
            {
                get
                {
                    return (ListViewItem)this.List[intDisplayIndex];
                }
                set
                {
                    this.List[intDisplayIndex] = value;
                }
            }

            #region IInnerList Members


            public void Sort()
            {
                if (mobjListView.ListViewItemSorterInternal != null)
                {
                    mobjListView.ResetSortingColumns();
                    this.List.Sort(mobjListView.ListViewItemSorterInternal);
                    mobjListView.Update();
                }
            }

            #endregion
        }

        #endregion

        #region ListViewGroupItemCollection Class

        /// <summary>
        /// Provides a collection of items that are mapped to this group
        /// </summary>
        [Serializable]
        internal class ListViewGroupItemCollection : ListView.ListViewItemCollection.IInnerList
        {
            /// <summary>
            /// The owning listview group
            /// </summary>
            private ListViewGroup mobjListViewGroup = null;

            /// <summary>
            /// The inner items collection
            /// </summary>
            private ArrayList mobjItems = new ArrayList();

            /// <summary>
            /// Initializes a new instance of the <see cref="ListViewGroupItemCollection"/> class.
            /// </summary>
            /// <param name="objListViewGroup">The list view group.</param>
            internal ListViewGroupItemCollection(ListViewGroup objListViewGroup)
            {
                mobjListViewGroup = objListViewGroup;
            }

            #region IInnerList Members

            /// <summary>
            /// Adds the specified item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public ListViewItem Add(ListViewItem objItem)
            {
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }

                // If item had a previous group 
                if (objItem.Group != null)
                {
                    // Remove previous group from item
                    objItem.Group.Items.Remove(objItem);
                }

                // Add item to group
                mobjItems.Add(objItem);

                // Set group to item
                objItem.MoveToGroup(mobjListViewGroup);

                return objItem;
            }

            /// <summary>
            /// Adds the range.
            /// </summary>
            /// <param name="arrItems">The items.</param>
            public void AddRange(ListViewItem[] arrItems)
            {
                // Loop all items and add them
                foreach (ListViewItem objItem in arrItems)
                {
                    this.Add(objItem);
                }
            }

            /// <summary>
            /// Clears this instance.
            /// </summary>
            public void Clear()
            {
                // Loop all items and add them
                foreach (ListViewItem objItem in mobjItems)
                {
                    objItem.MoveToGroup(null);
                }

                mobjItems.Clear();
            }

            /// <summary>
            /// Determines whether [contains] [the specified item].
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns>
            /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
            /// </returns>
            public bool Contains(ListViewItem objItem)
            {
                return mobjItems.Contains(objItem);
            }

            /// <summary>
            /// Copies to.
            /// </summary>
            /// <param name="objDestinationArray">The dest.</param>
            /// <param name="index">The index.</param>
            public void CopyTo(Array objDestinationArray, int index)
            {
                mobjItems.CopyTo(objDestinationArray, index);
            }

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                return mobjItems.GetEnumerator();
            }

            /// <summary>
            /// Indexes the of.
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public int IndexOf(ListViewItem objItem)
            {
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }

                return mobjItems.IndexOf(objItem);
            }

            /// <summary>
            /// Inserts the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public ListViewItem Insert(int index, ListViewItem objItem)
            {
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }

                // If item had a previous group 
                if (objItem.Group != null)
                {
                    // Remove previous group from item
                    objItem.Group.Items.Remove(objItem);
                }

                // Set group to item
                objItem.MoveToGroup(mobjListViewGroup);

                return objItem;
            }

            /// <summary>
            /// Removes the specified item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            public void Remove(ListViewItem objItem)
            {
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }

                if (objItem.Group == mobjListViewGroup)
                {
                    mobjItems.Remove(objItem);

                    objItem.MoveToGroup(null);
                }
            }

            /// <summary>
            /// Removes at.
            /// </summary>
            /// <param name="index">The index.</param>
            public void RemoveAt(int index)
            {
                mobjItems.Remove(mobjItems[index]);
            }

            /// <summary>
            /// Sorts this instance.
            /// </summary>
            public void Sort()
            {

            }

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value>The count.</value>
            public int Count
            {
                get
                {
                    return mobjItems.Count;
                }
            }

            /// <summary>
            /// Gets the list view.
            /// </summary>
            /// <value>The list view.</value>
            public ListView ListView
            {
                get
                {
                    return null;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.ListViewItem"/> at the specified index.
            /// </summary>
            /// <value></value>
            public ListViewItem this[int index]
            {
                get
                {
                    return (ListViewItem)mobjItems[index];
                }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }

                    // If item had a previous group 
                    if (value.Group != null)
                    {
                        // Remove previous group from item
                        value.Group.Items.Remove(value);
                    }

                    // Set group to item
                    value.MoveToGroup(mobjListViewGroup);

                    mobjItems[index] = value;
                }
            }

            #endregion
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        internal class ListViewOrederedItems : ListView.ListViewItemCollection.IInnerList
        {
            /// <summary>
            /// 
            /// </summary>
            private ListView mobjListView = null;


            /// <summary>
            /// 
            /// </summary>
            private bool mblnShowGroups = false;

            /// <summary>
            /// 
            /// </summary>
            private List<ListViewItem> mobjGroupedItems = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="ListViewOrederedItems"/> class.
            /// </summary>
            /// <param name="objListView">The list view.</param>
            public ListViewOrederedItems(ListView objListView)
            {
                mobjListView = objListView;

                if (mobjListView != null)
                {
                    mblnShowGroups = mobjListView.ShowGroups;
                }
            }


            #region IInnerList Members

            /// <summary>
            /// Adds the specified item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public ListViewItem Add(ListViewItem objItem)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Adds the range.
            /// </summary>
            /// <param name="arrItems">The items.</param>
            public void AddRange(ListViewItem[] arrItems)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Clears this instance.
            /// </summary>
            public void Clear()
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="objItem"></param>
            /// <returns></returns>
            public bool Contains(ListViewItem objItem)
            {
                return mobjListView.Items.Contains(objItem);
            }

            /// <summary>
            /// Copies to.
            /// </summary>
            /// <param name="objDestinationArray">The dest.</param>
            /// <param name="index">The index.</param>
            public void CopyTo(Array objDestinationArray, int index)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Get item index
            /// </summary>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public int IndexOf(ListViewItem objItem)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Inserts the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="objItem">The item.</param>
            /// <returns></returns>
            public ListViewItem Insert(int index, ListViewItem objItem)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Removes the specified item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            public void Remove(ListViewItem objItem)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Removes at.
            /// </summary>
            /// <param name="index">The index.</param>
            public void RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Sorts this instance.
            /// </summary>
            public void Sort()
            {
                throw new NotSupportedException();
            }

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value>The count.</value>
            public int Count
            {
                get
                {
                    return mobjListView.Items.Count;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.ListViewItem"/> at the specified index.
            /// </summary>
            /// <value></value>
            public ListViewItem this[int index]
            {
                get
                {
                    // Check if list has groups.
                    if (this.mblnShowGroups)
                    {
                        // Ensures grouped items.
                        EnsureGroupedItems();

                        return mobjGroupedItems[index];
                    }
                    else
                    {
                        // Return item normaly
                        return mobjListView.Items[index];
                    }
                }
                set
                {
                    throw new NotSupportedException();
                }
            }

            /// <summary>
            /// Ensures grouped items.
            /// </summary>
            private void EnsureGroupedItems()
            {
                // Check that no grouped items cached before.
                if (mobjGroupedItems == null)
                {
                    // Create the grouped items
                    mobjGroupedItems = new List<ListViewItem>();

                    // Create the actual group list
                    List<ListViewGroup> objGroups = new List<ListViewGroup>();

                    // Adds the default group
                    objGroups.Add(null);

                    if (this.ListView != null)
                    {
                        // Loop all groups
                        foreach (ListViewGroup objGroup in this.ListView.Groups)
                        {
                            // Add the phisical group
                            objGroups.Add(objGroup);
                        }

                        // Loop all groups
                        foreach (ListViewGroup objGroup in objGroups)
                        {
                            // Loop all items in listview.
                            foreach (ListViewItem objListViewItem in this.ListView.Items)
                            {
                                // Check if current item's group is null.
                                if (objListViewItem.Group == objGroup)
                                {
                                    mobjGroupedItems.Add(objListViewItem);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Gets the list view.
            /// </summary>
            /// <value>The list view.</value>
            public ListView ListView
            {
                get
                {
                    return mobjListView;
                }
            }

            #endregion
        }

        #region ListViewItemCollection


        /// <summary>
        /// Represents the collection of items in a ListView control.
        /// </summary>
#if WG_NET46
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always), Serializable()]
        public class ListViewItemCollection : ICollection, IEnumerable, IList, IObservableList
        {

            #region IInnerList Interface

            /// <summary>
            /// Provides a way to expose group items and list view items using the same
            /// class.
            /// </summary>
            internal interface IInnerList
            {
                ListViewItem Add(ListViewItem objItem);
                void AddRange(ListViewItem[] arrItems);
                void Clear();
                bool Contains(ListViewItem objItem);
                void CopyTo(Array objDestinationArray, int index);
                IEnumerator GetEnumerator();
                int IndexOf(ListViewItem objItem);
                ListViewItem Insert(int index, ListViewItem objItem);
                void Remove(ListViewItem objItem);
                void RemoveAt(int index);
                void Sort();
                int Count { get; }
                ListViewItem this[int index] { get; set; }

                ListView ListView
                {
                    get;
                }
            }
            #endregion

            #region Class Members

            private IInnerList mobjList;

            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ListViewItemCollection"/> instance.
            /// </summary>
            /// <param name="objListView">The obj list view.</param>
            public ListViewItemCollection(ListView objListView)
            {
                mobjList = new ListViewNativeItemCollection(objListView);
            }

            /// <summary>
            /// Creates a new <see cref="ListViewItemCollection"/> instance.
            /// </summary>
            /// <param name="objListView">The obj list view.</param>
            /// <param name="arrItems">The arr items.</param>
            internal ListViewItemCollection(ListView objListView, object[] arrItems)
            {
                mobjList = new ListViewNativeItemCollection(objListView, arrItems);
            }

            internal ListViewItemCollection(ListViewGroup objListViewGroup)
            {
                mobjList = new ListViewGroupItemCollection(objListViewGroup);
            }


            #endregion C'Tor\D'Tor

            #region Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="strText">The first sub item text.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(string strText)
            {
                return this.Add((Control)null, strText, -1);
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="objPanel">The panel to use in for the list view item.</param>
            /// <param name="strText">The first sub item text.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(Control objPanel, string strText)
            {
                return this.Add(objPanel, strText, -1);
            }

            /// <summary>
            /// Adds the specified obj list view item.
            /// </summary>
            /// <param name="objListViewItem">Obj list view item.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(ListViewItem objListViewItem)
            {
                // Add list view item to list
                this.mobjList.Add(objListViewItem);


                // Handle common item added actions
                OnItemAdded(objListViewItem);

                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objListViewItem));
                }
                return objListViewItem;
            }

            /// <summary>
            /// Adds the specified text.
            /// </summary>
            /// <param name="strText">Text.</param>
            /// <param name="intImageIndex">Image index.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(string strText, int intImageIndex)
            {
                return this.Add((Control)null, strText, intImageIndex);
            }

            /// <summary>
            /// Adds the specified text.
            /// </summary>
            /// <param name="strText">The text.</param>
            /// <param name="strImageKey">The image key.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(string strText, string strImageKey)
            {
                ListViewItem objListViewItem = new ListViewItem(strText, strImageKey);
                this.Add(objListViewItem);
                return objListViewItem;
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="strKey">The key.</param>
            /// <param name="strText">The text.</param>
            /// <param name="intImageIndex">Index of the image.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(string strKey, string strText, int intImageIndex)
            {
                ListViewItem objItem = new ListViewItem(strText, intImageIndex);
                objItem.Name = strKey;

                this.Add(objItem);
                return objItem;
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="strKey">The STR key.</param>
            /// <param name="strText">The text.</param>
            /// <param name="strImageKey">The STR image key.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(string strKey, string strText, string strImageKey)
            {
                ListViewItem objItem = new ListViewItem(strText, strImageKey);
                objItem.Name = strKey;

                this.Add(objItem);
                return objItem;
            }

            /// <summary>
            /// Adds the specified text.
            /// </summary>
            /// <param name="objPanel">The obj panel.</param>
            /// <param name="strText">Text.</param>
            /// <param name="intImageIndex">Image index.</param>
            /// <returns></returns>
            public virtual ListViewItem Add(Control objPanel, string strText, int intImageIndex)
            {
                ListViewItem objListViewItem = null;

                // If no panel was defined for item
                if (objPanel == null)
                {
                    // Create a listview item
                    objListViewItem = new ListViewItem(strText, intImageIndex);
                }
                else
                {
                    // Create a listview item with a panel
                    objListViewItem = new ListViewPanelItem(objPanel, strText, intImageIndex);
                }

                // Add list view item to list
                this.mobjList.Add(objListViewItem);

                // Handle common on add action
                OnItemAdded(objListViewItem);

                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objListViewItem));
                }
                return objListViewItem;
            }

            /// <summary>Adds an array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to the collection.</summary>
            /// <param name="arrListViewItems">An array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to add to the collection. </param>
            /// <exception cref="T:System.ArgumentNullException">items is null.</exception>
            public void AddRange(ListViewItem[] arrListViewItems)
            {
                foreach (ListViewItem objListViewItem in arrListViewItems)
                {
                    this.Add(objListViewItem);
                }
            }

            /// <summary>
            /// Removes the specified list view item.
            /// </summary>
            /// <param name="objListViewItem">list view item.</param>
            public void Remove(ListViewItem objListViewItem)
            {
                // Remove item from list
                this.mobjList.Remove(objListViewItem);

                // Get list view item's group.
                ListViewGroup objGroup = objListViewItem.Group;
                if (objGroup != null)
                {
                    // Remove item from group.
                    objGroup.Items.Remove(objListViewItem);
                }

                // Handle common on item remove action
                OnItemRemoved(objListViewItem);

                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(objListViewItem));
                }
            }

            /// <summary>
            /// Called when item was removed.
            /// </summary>
            /// <param name="objListViewItem">The list view item removed.</param>
            private void OnItemRemoved(ListViewItem objListViewItem)
            {
                // If there is a valid list view control
                ListView objListView = mobjList.ListView;
                if (objListView != null)
                {

                    // Try to get the panel item
                    ListViewPanelItem objPanelItem = objListViewItem as ListViewPanelItem;

                    // If there is a valid panel item
                    if (objPanelItem != null)
                    {
                        // Remove panel to the list view controls
                        objListView.Controls.Remove(objPanelItem.Panel);
                    }

                    // Loop all sub items
                    foreach (ListViewItem.ListViewSubItem objSubItem in objListViewItem.SubItems)
                    {
                        // Get the sub item control item if possible
                        ListViewItem.ListViewSubControlItem objControlSubItem = objSubItem as ListViewItem.ListViewSubControlItem;
                        if (objControlSubItem != null)
                        {
                            // Get the sub item control
                            Control objSubItemControl = objControlSubItem.Control;

                            // If there is a valid sub item control
                            if (objSubItemControl != null)
                            {
                                // Remove sub item control from controls
                                objListView.Controls.Remove(objSubItemControl);
                            }

                        }
                    }
                }
            }

            /// <summary>
            /// Get the index the of the specified list view item.
            /// </summary>
            /// <param name="objListViewItem">Obj list view item.</param>
            /// <returns></returns>
            public int IndexOf(ListViewItem objListViewItem)
            {
                return this.mobjList.IndexOf(objListViewItem);
            }

            /// <summary>
            /// Clears this list items.
            /// </summary>
            public void Clear()
            {
                // Copy items into an array that can be iterated
                ListViewItem[] arrItems = new ListViewItem[this.mobjList.Count];
                this.mobjList.CopyTo(arrItems, 0);

                // Clear all items
                this.mobjList.Clear();

                bool blnRunTime = !this.mobjList.ListView.DesignMode;

                // Loop all removed list view items
                foreach (ListViewItem objListViewItem in arrItems)
                {
                    if (blnRunTime)
                    {
                        // Get list view item's group.
                        ListViewGroup objGroup = objListViewItem.Group;
                        if (objGroup != null)
                        {
                            // Remove item from group.
                            objGroup.Items.Remove(objListViewItem);
                        }
                    }

                    // Call the common remove action
                    OnItemRemoved(objListViewItem);
                }

                if (ObservableListCleared != null)
                {
                    ObservableListCleared(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Copies to an array.
            /// </summary>
            /// <param name="objArray">The obj array.</param>
            /// <param name="intIndex">Index of the int.</param>
            public void CopyTo(Array objArray, int intIndex)
            {
                this.mobjList.CopyTo(objArray, intIndex);
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                return this.mobjList.GetEnumerator();
            }

            /// <summary>
            /// Sorts this instance.
            /// </summary>
            internal void Sort()
            {
                this.mobjList.Sort();
            }


            #endregion Methods

            #region Properties


            /// <summary>
            /// Gets the <see cref="ListViewItem"/> at the specified int index.
            /// </summary>
            /// <value></value>
            public ListViewItem this[int intIndex]
            {
                get
                {
                    return (ListViewItem)this.mobjList[intIndex];
                }
                set
                {
                    if ((intIndex < 0) || (intIndex >= this.mobjList.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", intIndex.ToString(CultureInfo.CurrentCulture) }));
                    }
                    this.mobjList[intIndex] = value;
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is synchronized.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
            /// </value>
            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value></value>
            public int Count
            {
                get
                {
                    return this.mobjList.Count;
                }
            }

            /// <summary>
            /// Gets the sync root.
            /// </summary>
            /// <value></value>
            public object SyncRoot
            {
                get
                {
                    return null;
                }
            }


            #endregion Properties

            #region IList Members

            /// <summary>
            ///
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Return object (ListViewItem) at the specified index.
            /// </summary>
            object System.Collections.IList.this[int index]
            {
                get
                {
                    return this.mobjList[index];
                }
                set
                {
                    // Get the typed list view item
                    ListViewItem objItem = (ListViewItem)value;
                    if (objItem != null)
                    {
                        this.mobjList[index] = objItem;

                        OnItemAdded(objItem);
                    }

                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            public void RemoveAt(int index)
            {
                if (index > -1 && index < mobjList.Count)
                {
                    ListViewItem objListViewItem = mobjList[index] as ListViewItem;
                    if (objListViewItem != null)
                    {
                        this.Remove(objListViewItem);
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            /// <summary>Creates a new item and inserts it into the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
            /// <param name="index">The zero-based index location where the item is inserted. </param>
            /// <param name="strText">The text to display for the item. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public ListViewItem Insert(int index, string strText)
            {
                return this.Insert(index, new ListViewItem(strText));
            }

            /// <summary>Inserts an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> into the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
            /// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that represents the item to insert. </param>
            /// <param name="index">The zero-based index location where the item is inserted. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public ListViewItem Insert(int index, ListViewItem objItem)
            {
                // Inser the list item
                this.mobjList.Insert(index, objItem);

                // Do common item added actions
                OnItemAdded(objItem);

                // If there is an observable listener
                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objItem));
                }

                return objItem;
            }

            /// <summary>
            /// Called when item was added.
            /// </summary>
            /// <param name="objListViewItem">The list view item added.</param>
            private void OnItemAdded(ListViewItem objListViewItem)
            {
                // If there is a valid list view control
                ListView objListView = mobjList.ListView;
                if (objListView != null)
                {
                    // Try to get the panel item
                    ListViewPanelItem objPanelItem = objListViewItem as ListViewPanelItem;

                    // If there is a valid panel item
                    if (objPanelItem != null)
                    {
                        // Add panel to the list view controls
                        objListView.Controls.Add(objPanelItem.Panel);
                    }

                    // Loop all sub items
                    foreach (ListViewItem.ListViewSubItem objSubItem in objListViewItem.SubItems)
                    {
                        // Get the sub item control item if possible
                        ListViewItem.ListViewSubControlItem objControlSubItem = objSubItem as ListViewItem.ListViewSubControlItem;
                        if (objControlSubItem != null)
                        {
                            // Get the sub item control
                            Control objSubItemControl = objControlSubItem.Control;

                            // If there is a valid sub item control
                            if (objSubItemControl != null)
                            {
                                // Add sub item control to controls
                                objListView.Controls.Add(objSubItemControl);
                            }
                        }
                    }
                }
            }

            /// <summary>Creates a new item with the specified image index and inserts it into the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
            /// <param name="intImageIndex">The index of the image to display for the item. </param>
            /// <param name="index">The zero-based index location where the item is inserted. </param>
            /// <param name="strText">The text to display for the item. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public ListViewItem Insert(int index, string strText, int intImageIndex)
            {
                return this.Insert(index, new ListViewItem(strText, intImageIndex));
            }

            /// <summary>Creates a new item with the specified text and image and inserts it in the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
            /// <param name="strImageKey">The key of the image to display for the item.</param>
            /// <param name="index">The zero-based index location where the item is inserted. </param>
            /// <param name="strText">The text of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public ListViewItem Insert(int index, string strText, string strImageKey)
            {
                return this.Insert(index, new ListViewItem(strText));
            }

            /// <summary>Creates a new item with the specified key, text, and image, and inserts it in the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
            /// <param name="intImageIndex">The index of the image to display for the item.</param>
            /// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item.</param>
            /// <param name="intIndex">The zero-based index location where the item is inserted</param>
            /// <param name="strText">The text of the item.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public virtual ListViewItem Insert(int intIndex, string strKey, string strText, int intImageIndex)
            {
                ListViewItem objItem = new ListViewItem(strText, intImageIndex);
                objItem.Name = strKey;
                return this.Insert(intIndex, objItem);
            }

            /// <summary>Creates a new item with the specified key, text, and image, and adds it to the collection at the specified index.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
            /// <param name="strImageKey">The key of the image to display for the item.</param>
            /// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item. </param>
            /// <param name="intIndex">The zero-based index location where the item is inserted.</param>
            /// <param name="strText">The text of the item.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
            public virtual ListViewItem Insert(int intIndex, string strKey, string strText, string strImageKey)
            {
                ListViewItem objItem = new ListViewItem(strText, strImageKey);
                objItem.Name = strKey;
                return this.Insert(intIndex, objItem);
            }


            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            /// <param name="objValue"></param>
            void System.Collections.IList.Insert(int index, object objValue)
            {
                this.mobjList.Insert(index, (ListViewItem)objValue);

                OnItemAdded((ListViewItem)objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            void System.Collections.IList.Remove(object objValue)
            {
                ListViewItem objListViewItem = objValue as ListViewItem;
                if (objListViewItem != null)
                {
                    Remove(objListViewItem);
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            public bool Contains(object objValue)
            {
                return this.mobjList.Contains((ListViewItem)objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            public int IndexOf(object objValue)
            {
                return this.mobjList.IndexOf((ListViewItem)objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.Add(object objValue)
            {
                ListViewItem objListViewItem = objValue as ListViewItem;
                if (objListViewItem != null)
                {
                    this.Add(objListViewItem);

                    OnItemAdded(objListViewItem);
                }
                return this.IndexOf(objValue);
            }

            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
            /// </summary>
            /// <value></value>
            /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.
            /// </returns>
            public bool IsFixedSize
            {
                get
                {
                    return false;
                }
            }


            #endregion IList Members

            #region IObservableList Members

            /// <summary>
            /// Occurs when [observable item inserted].
            /// </summary>
            public event ObservableListEventHandler ObservableItemInserted;

            /// <summary>
            /// Occurs when [observable item added].
            /// </summary>
            public event ObservableListEventHandler ObservableItemAdded;

            /// <summary>
            /// Occurs when [observable list cleared].
            /// </summary>
            public event EventHandler ObservableListCleared;

            /// <summary>
            /// Occurs when [observable item removed].
            /// </summary>
            public event ObservableListEventHandler ObservableItemRemoved;

            #endregion
        }

        #endregion ListViewItemCollection

        #region ColumnHeaderCollection

        /// <summary>
        /// Represents the collection of column headers in a ListView control.
        /// </summary>
        [Serializable()]
        public class ColumnHeaderCollection : ICollection, IList, IEnumerable, IObservableList
        {
            #region Class Members

            private ListView mobjListView;

            private ArrayList mobjList;

            private ArrayList mobjSortedColumns;


            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ColumnHeaderCollection"/> instance.
            /// </summary>
            public ColumnHeaderCollection(ListView objListView)
            {
                mobjListView = objListView;
                mobjList = new ArrayList();
            }

            /// <summary>
            /// Creates a new <see cref="ColumnHeaderCollection"/> instance.
            /// </summary>
            internal ColumnHeaderCollection(ListView objListView, object[] arrColumns)
            {
                mobjListView = objListView;
                mobjList = new ArrayList(arrColumns);
            }


            #endregion C'Tor\D'Tor

            #region Methods

            #region ICollection Methods

            /// <summary>
            /// Adds the specified list view column.
            /// </summary>
            /// <param name="objListViewColumn">Obj list view column.</param>
            /// <returns></returns>
            public int Add(ColumnHeader objListViewColumn)
            {
                objListViewColumn.InternalParent = mobjListView;
                objListViewColumn.InternalIndex = mobjList.Add(objListViewColumn);
                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objListViewColumn));
                }

                if (mobjListView != null)
                {
                    mobjListView.Update();
                }

                //Clear Sorted Columns list
                this.ClearSortedColumns();

                objListViewColumn.DisplayIndexInternal = objListViewColumn.Index;

                return objListViewColumn.Index;
            }

            /// <summary>
            /// Adds the range.
            /// </summary>
            /// <param name="arrColumnHeaders">column headers array.</param>
            public virtual void AddRange(ColumnHeader[] arrColumnHeaders)
            {
                foreach (ColumnHeader objColumnHeader in arrColumnHeaders)
                {
                    this.Add(objColumnHeader);
                }
            }

            /// <summary>
            /// Creates and adds a new list view column.
            /// </summary>
            /// <param name="strLabel">Label.</param>
            /// <param name="intWidth">Width.</param>
            /// <param name="enmTextAlign">Text align.</param>
            /// <returns></returns>
            public ColumnHeader Add(string strLabel, int intWidth, HorizontalAlignment enmTextAlign)
            {
                ColumnHeader objColumn = new ColumnHeader(strLabel, strLabel, intWidth);
                objColumn.TextAlign = enmTextAlign;
                this.Add(objColumn);
                return objColumn;
            }

            /// <summary>
            /// Removes the specified list view column.
            /// </summary>
            /// <param name="objListViewColumn">list view column.</param>
            public void Remove(ColumnHeader objListViewColumn)
            {

                int intDisplayIndex = objListViewColumn.DisplayIndex;

                // Clear the list item panel
                if (objListViewColumn.InternalParent == mobjListView)
                {
                    objListViewColumn.InternalParent = null;
                }

                // Remove current column
                mobjList.Remove(objListViewColumn);

                if (mobjListView != null)
                {
                    mobjListView.Update();
                }
                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(objListViewColumn));
                }

                // Update columns index
                UpdateColumnsIndex();

                UpdateDisplayIndex(intDisplayIndex, false);
            }

            /// <summary>
            /// Updates the display index.
            /// </summary>
            /// <param name="intDisplayIndex">Display index of the int.</param>
            /// <param name="blnAdd">if set to <c>true</c> [BLN add].</param>
            private void UpdateDisplayIndex(int intDisplayIndex, bool blnAdd)
            {
                foreach (ColumnHeader objColumnHeader in mobjList)
                {
                    if (objColumnHeader.DisplayIndex > intDisplayIndex)
                    {
                        objColumnHeader.DisplayIndexInternal += blnAdd ? 1 : -1;
                    }
                }

                //Clear Sorted Columns list
                this.ClearSortedColumns();
            }

            /// <summary>
            /// Updates the columns index.
            /// </summary>
            private void UpdateColumnsIndex()
            {
                int intIndex = 0;
                foreach (ColumnHeader objColumnHeader in mobjList)
                {
                    objColumnHeader.InternalIndex = intIndex;
                    intIndex++;
                }
            }

            /// <summary>
            /// Clears this instance.
            /// </summary>
            public void Clear()
            {
                // unregister all column components
                mobjListView.UnRegisterBatch(this);
                mobjSortedColumns = null;
                mobjList.Clear();

            }

            /// <summary>
            /// Clears the sorted columns array list.
            /// </summary>
            internal void ClearSortedColumns()
            {
                mobjSortedColumns = null;
            }

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                return mobjList.GetEnumerator();
            }

            /// <summary>
            /// Copies to.
            /// </summary>
            /// <param name="objArray">Array.</param>
            /// <param name="index">Index.</param>
            public void CopyTo(Array objArray, int index)
            {
                mobjList.CopyTo(objArray, index);
            }


            #endregion ICollection Methods

            #region Column Updating

            /// <summary>
            /// Updates the listview columns.
            /// </summary>
            public void UpdateColumns()
            {
                // Validation flag
                bool blnValid = true;

                // Loop all columns
                foreach (ColumnHeader objColumnHeader in mobjList)
                {
                    // If not valid combination
                    if (objColumnHeader.Visible && !objColumnHeader.Loaded)
                    {
                        blnValid = false;
                        break;
                    }
                }

                // Clear sorted array
                mobjSortedColumns = null;

                // Fire update commands
                mobjListView.FireUpdateColumns(blnValid);

                mobjListView.Update(true);


            }


            #endregion Column Updating

            #endregion Methods

            #region Properties

            #region ICollection

            /// <summary>
            /// Gets a value indicating whether this instance is synchronized.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
            /// </value>
            public bool IsSynchronized
            {
                get
                {
                    return mobjList.IsSynchronized;
                }
            }

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value></value>
            public int Count
            {
                get
                {
                    return mobjList.Count;
                }
            }

            /// <summary>
            /// Gets the sync root.
            /// </summary>
            /// <value></value>
            public object SyncRoot
            {
                get
                {
                    return mobjList.SyncRoot;
                }
            }


            #endregion ICollection

            #region Ordering

            /// <summary>
            /// Gets the visible columns.
            /// </summary>
            /// <value></value>
            public ICollection VisibleColumns
            {
                get
                {
                    // Create column array
                    ArrayList objVisibleColumns = new ArrayList();

                    // Loop all colums
                    foreach (ColumnHeader objColumnHeader in mobjList)
                    {
                        // Is is visible column
                        if (objColumnHeader.Visible)
                        {
                            objVisibleColumns.Add(objColumnHeader);
                        }
                    }

                    // Return the visible columns
                    return objVisibleColumns;
                }
            }

            /// <summary>
            /// Gets the position sorted column list.
            /// </summary>
            /// <value></value>
            public ICollection SortedColumns
            {
                get
                {
                    // If sorted column list is not valid
                    if (mobjSortedColumns == null)
                    {
                        mobjSortedColumns = new ArrayList(mobjList);
                        mobjSortedColumns.Sort();
                    }

                    return mobjSortedColumns;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColumnHeader"/> with the specified int index.
            /// </summary>
            /// <value></value>
            public ColumnHeader this[int intIndex]
            {
                get
                {
                    return (ColumnHeader)mobjList[intIndex];
                }
            }


            #endregion Ordering

            #endregion Properties

            #region IList Members

            /// <summary>
            ///
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    // TODO:  Add ColumnHeaderCollection.IsReadOnly getter implementation
                    return false;
                }
            }

            /// <summary>
            ///
            /// </summary>
            object System.Collections.IList.this[int index]
            {
                get
                {
                    // TODO:  Add ColumnHeaderCollection.System.Collections.IList.this getter implementation
                    return mobjList[index];
                }
                set
                {
                    if (mobjListView != null)
                    {
                        this.mobjListView.Update();
                    }
                    mobjList[index] = value;
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            public void RemoveAt(int index)
            {
                ColumnHeader objColumn = mobjList[index] as ColumnHeader;

                if (objColumn != null)
                {
                    this.Remove(objColumn);
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            /// <param name="objValue"></param>
            public void Insert(int index, object objValue)
            {
                // check boundary values
                if (index >= 0 && objValue != null)
                {
                    // cast value as ColumnHeader
                    ColumnHeader objColumnHeader = objValue as ColumnHeader;

                    if (objColumnHeader != null)
                    {
                        // set InternalParent
                        objColumnHeader.InternalParent = mobjListView;

                        objColumnHeader.DisplayIndex = index;

                        // insert ColumnHeader into ArrayList mobjList 
                        mobjList.Insert(index, objColumnHeader);

                        // reset ColumnHeader indexes
                        foreach (ColumnHeader objColumn in mobjList)
                        {
                            objColumn.InternalIndex = mobjList.IndexOf(objColumn);
                        }

                        UpdateDisplayIndex(index, true);

                        // fire ObservableItemAdded event
                        if (ObservableItemAdded != null)
                        {
                            ObservableItemAdded(this, new ObservableListEventArgs(objColumnHeader));
                        }

                        // update ListView
                        if (mobjListView != null)
                        {
                            mobjListView.Update();
                        }
                    }
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            void System.Collections.IList.Remove(object objValue)
            {
                if (mobjListView != null)
                {
                    this.mobjListView.Update();
                }
                mobjList.Remove(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            public bool Contains(object objValue)
            {
                return mobjList.Contains(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            public int IndexOf(object objValue)
            {
                if (mobjListView != null)
                {
                    this.mobjListView.Update();
                }
                // TODO:  Add ColumnHeaderCollection.IndexOf implementation
                return mobjList.IndexOf(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.Add(object objValue)
            {
                if (!(objValue is ColumnHeader))
                {
                    throw new ArgumentException(SR.GetString("ColumnHeaderCollectionInvalidArgument"));
                }
                return this.Add((ColumnHeader)objValue);

            }

            /// <summary>
            ///
            /// </summary>
            public bool IsFixedSize
            {
                get
                {
                    // TODO:  Add ColumnHeaderCollection.IsFixedSize getter implementation
                    return false;
                }
            }


            #endregion IList Members

            #region IObservableList Members

            /// <summary>
            /// Occurs when [observable item inserted].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemInserted;

            /// <summary>
            /// Occurs when [observable item added].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemAdded;

            /// <summary>
            /// Occurs when [observable list cleared].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event EventHandler ObservableListCleared;

            /// <summary>
            /// Occurs when [observable item removed].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemRemoved;

            #endregion
        }

        #endregion ColumnHeaderCollection

        #region SelectedListViewItemCollection Class

        /// <summary>
        ///
        /// </summary>
        [Serializable()]
        public class SelectedListViewItemCollection : ICollection, IList
        {
            #region ICollection Members

            /// <summary>
            ///
            /// </summary>
            bool ICollection.IsSynchronized
            {
                get
                {
                    return mobjItems.IsSynchronized;
                }
            }

            /// <summary>
            ///
            /// </summary>
            public int Count
            {
                get
                {
                    return mobjItems.Count;
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objArray"></param>
            /// <param name="index"></param>
            public void CopyTo(Array objArray, int index)
            {
                mobjItems.CopyTo(objArray, index);
            }

            /// <summary>
            ///
            /// </summary>
            object ICollection.SyncRoot
            {
                get
                {
                    return mobjItems.SyncRoot;
                }
            }


            #endregion ICollection Members

            #region IEnumerable Members

            /// <summary>
            ///
            /// </summary>
            public IEnumerator GetEnumerator()
            {
                return mobjItems.GetEnumerator();
            }


            #endregion IEnumerable Members

            #region IList Members

            /// <summary>
            ///
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            ///
            /// </summary>
            public ListViewItem this[int index]
            {
                get
                {
                    return (ListViewItem)mobjItems[index];
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objListViewItem"></param>
            public bool Contains(ListViewItem objListViewItem)
            {
                return mobjItems.Contains(objListViewItem); ;
            }

            /// <summary>
            ///
            /// </summary>
            void System.Collections.IList.Clear()
            {
                this.Clear();
            }

            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
            public void Clear()
            {
                if (mobjItems != null)
                {
                    foreach (ListViewItem objListViewItem in mobjItems)
                    {
                        objListViewItem.Selected = false;
                    }

                    mobjItems.Clear();

                    if (mobjListView != null)
                    {
                        mobjListView.Update();
                    }
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objListViewItem"></param>
            public int IndexOf(ListViewItem objListViewItem)
            {
                return mobjItems.IndexOf(objListViewItem);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.Add(object objValue)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            ///
            /// </summary>
            bool System.Collections.IList.IsFixedSize
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            ///
            /// </summary>
            object System.Collections.IList.this[int index]
            {
                get
                {
                    return mobjItems[index];
                }
                set
                {
                    throw new NotSupportedException();
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            void System.Collections.IList.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            /// <param name="objValue"></param>
            void System.Collections.IList.Insert(int index, object objValue)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            void System.Collections.IList.Remove(object objValue)
            {
                throw new NotSupportedException();
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            bool System.Collections.IList.Contains(object objValue)
            {
                return mobjItems.Contains(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.IndexOf(object objValue)
            {
                return mobjItems.IndexOf(objValue);
            }


            #endregion IList Members

            #region Class Members

            private ArrayList mobjItems;

            private ListView mobjListView;


            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            ///
            /// </summary>
            /// <param name="objListView"></param>
            public SelectedListViewItemCollection(ListView objListView)
            {
                mobjListView = objListView;

                mobjItems = new ArrayList();

                foreach (ListViewItem objListViewItem in objListView.Items)
                {
                    if (objListViewItem.Selected)
                    {
                        mobjItems.Add(objListViewItem);
                    }
                }
            }


            #endregion C'Tor / D'Tor

        }

        #endregion

        #region ItemProcessor Class

        /// <summary>
        /// Provides item processing base implementation
        /// </summary>
        internal abstract class ItemProcessor
        {
            /// <summary>
            /// Processes the item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            internal abstract void ProcessItem(ListViewItem objItem);

            /// <summary>
            /// Processes the group.
            /// </summary>
            /// <param name="objGroup">The group.</param>
            internal abstract void ProcessGroup(ListViewGroup objGroup);

            /// <summary>
            /// Gets a value indicating whether processing is still needed.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if processing is still needed; otherwise, <c>false</c>.
            /// </value>
            internal virtual bool IsProcessingStillNeeded
            {
                get
                {
                    return true;
                }
            }
        }

        #endregion

        #region ItemRenderingProcessor Class

        /// <summary>
        /// Provides support for rendering items
        /// </summary>
        internal class ItemRenderingProcessor : ItemProcessor
        {
            /// <summary>
            /// The owner listview
            /// </summary>
            private readonly ListView mobjListView;

            /// <summary>
            /// The current context
            /// </summary>
            private readonly IContext mobjContext;

            /// <summary>
            /// The current response writer
            /// </summary>
            private readonly IResponseWriter mobjWriter;

            /// <summary>
            /// The current request ID.
            /// </summary>
            private readonly long mlngRequestID;

            /// <summary>
            /// 
            /// </summary>
            private readonly View menmView;

            /// <summary>
            /// 
            /// </summary>
            private readonly bool mblnShowItemToolTips;

            /// <summary>
            /// 
            /// </summary>
            private readonly ICollection mobjSortedColumns;

            /// <summary>
            /// 
            /// </summary>
            private readonly bool mblnFullListRedraw;






            /// <summary>
            /// Initializes a new instance of the <see cref="ItemRenderingProcessor"/> class.
            /// </summary>
            /// <param name="objListView">The list view.</param>
            /// <param name="objContext">The context.</param>
            /// <param name="objWriter">The writer.</param>
            /// <param name="lngRequestID">The request ID.</param>
            public ItemRenderingProcessor(ListView objListView, IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullListRedraw)
            {
                mobjListView = objListView;
                mobjContext = objContext;
                mobjWriter = objWriter;
                mlngRequestID = lngRequestID;
                menmView = objListView.View;
                mblnShowItemToolTips = objListView.ShowItemToolTips;
                mobjSortedColumns = objListView.Columns.SortedColumns;
                mblnFullListRedraw = blnFullListRedraw;
            }

            /// <summary>
            /// Processes the item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            internal override void ProcessItem(ListViewItem objItem)
            {
                objItem.RenderItem(mobjContext, mobjWriter, mlngRequestID, this);
            }

            /// <summary>
            /// Processes the group.
            /// </summary>
            /// <param name="objGroup">The group.</param>
            internal override void ProcessGroup(ListViewGroup objGroup)
            {
                mobjListView.RenderGroup(mobjContext, mobjWriter, objGroup, this);
            }


            /// <summary>
            /// Gets a value indicating whether in full list redraw.
            /// </summary>
            /// <value><c>true</c> if in full list redraw; otherwise, <c>false</c>.</value>
            public bool FullListRedraw
            {
                get { return mblnFullListRedraw; }
            }

            /// <summary>
            /// Gets the list view.
            /// </summary>
            /// <value>The list view.</value>
            public ListView ListView
            {
                get { return mobjListView; }
            }

            /// <summary>
            /// Gets the view.
            /// </summary>
            /// <value>The view.</value>
            public View View
            {
                get { return menmView; }
            }


            /// <summary>
            /// Gets a value indicating whether to show item tooltips.
            /// </summary>
            /// <value><c>true</c> if to show item tool tips; otherwise, <c>false</c>.</value>
            public bool ShowItemToolTips
            {
                get { return mblnShowItemToolTips; }
            }

            /// <summary>
            /// Gets the sorted columns.
            /// </summary>
            /// <value>The sorted columns.</value>
            public ICollection SortedColumns
            {
                get { return mobjSortedColumns; }
            }


            /// <summary>
            /// Called when item is formatted.
            /// </summary>
            /// <param name="intItemIndex">The item index.</param>
            /// <param name="intColumnIndex">The column index.</param>
            /// <param name="objSubItem">The sub item.</param>
            internal void OnItemFormatting(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
            {
                mobjListView.OnItemFormatting(intItemIndex, intColumnIndex, objSubItem);
            }
        }

        #endregion

        #region ItemLayoutProcessor Class

        /// <summary>
        /// Provides support for get layout information on the current listview status
        /// </summary>
        internal class ItemLayoutProcessor : ItemProcessor
        {

            #region Class Members

            /// <summary>
            /// 
            /// </summary>
            private Point mobjItemLocation = Point.Empty;

            /// <summary>
            /// 
            /// </summary>
            private ListViewItem mobjItem = null;


            /// <summary>
            /// 
            /// </summary>
            private ListViewSkin mobjOwnerSkin = null;

            /// <summary>
            /// 
            /// </summary>
            private Size mobjOwnerSize = Size.Empty;

            /// <summary>
            /// 
            /// </summary>
            private ListView mobjListView = null;

            /// <summary>
            /// 
            /// </summary>
            private Point mobjCurrentPosition = Point.Empty;


            /// <summary>
            /// 
            /// </summary>
            private bool mblnIsProcessingStillNeeded = true;

            /// <summary>
            /// 
            /// </summary>
            private int mintLastLineHeight = 0;

            /// <summary>
            /// 
            /// </summary>
            private enum SearchType
            {
                /// <summary>
                /// 
                /// </summary>
                ItemFromLocation,

                /// <summary>
                /// 
                /// </summary>
                LocationFromItem
            }


            /// <summary>
            /// 
            /// </summary>
            private readonly SearchType menmSearchType = SearchType.ItemFromLocation;




            #endregion

            #region C'Tors

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemLayoutProcessor"/> class.
            /// </summary>
            /// <param name="objListView">The list view.</param>
            /// <param name="objItem">The list view item.</param>
            /// <param name="objSize">The list view size.</param>
            internal ItemLayoutProcessor(ListView objListView, ListViewItem objItem)
            {
                mobjItem = objItem;
                mobjOwnerSize = objListView.Size;
                mobjOwnerSkin = (ListViewSkin)objListView.Skin;
                mobjListView = objListView;
                menmSearchType = SearchType.LocationFromItem;
                ProcessHeader();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemLayoutProcessor"/> class.
            /// </summary>
            /// <param name="objListView">The list view.</param>
            /// <param name="objLocation">The mouse location.</param>
            /// <param name="objSize">The list view size.</param>
            internal ItemLayoutProcessor(ListView objListView, Point objLocation)
            {
                mobjItemLocation = objLocation;
                mobjOwnerSkin = (ListViewSkin)objListView.Skin;
                mobjOwnerSize = objListView.Size;
                mobjListView = objListView;
                menmSearchType = SearchType.ItemFromLocation;

                ProcessHeader();
            }

            #endregion

            #region Methods


            /// <summary>
            /// Processes the header.
            /// </summary>
            private void ProcessHeader()
            {
                // If header is visible
                if (this.IsHeaderVisible)
                {
                    // Get the header rectangle
                    Rectangle objHeaderRectangle = new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, mobjListView.GetPreferdItemFontHeight(true)));

                    // Add the header rectangle to position
                    AddItemRectangleToPosition(objHeaderRectangle);

                    // If we are searching the item
                    if (this.IsItemFromLocationSearch)
                    {
                        // If the location is in the header range
                        if (objHeaderRectangle.Contains(this.ItemLocation))
                        {
                            // We did not find any item in location
                            SetFoundItemAndStopProcessing(null);
                        }
                    }
                }
            }


            /// <summary>
            /// Processes the item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            internal override void ProcessItem(ListViewItem objItem)
            {
                // Create the item rectangle
                Rectangle objItemRectangle = Rectangle.Empty;

                // Switch view type
                switch (this.CurrentView)
                {
                    case View.Details:
                        objItemRectangle = new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, mobjListView.GetPreferdItemFontHeight(false)));
                        break;
                    case View.LargeIcon:
                        objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.LargeIcon));
                        break;
                    case View.SmallIcon:
                        objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.SmallIcon));
                        break;
                    case View.List:
                        objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.List));
                        break;

                }

                // If there is a valid rectangle
                if (objItemRectangle != Rectangle.Empty)
                {
                    // If is item from location search
                    if (this.IsItemFromLocationSearch)
                    {
                        // If item rectangle contains the item location
                        if (objItemRectangle.Contains(this.ItemLocation))
                        {
                            // Set the found item
                            SetFoundItemAndStopProcessing(objItem);
                        }
                    }
                    // If is location from item search
                    else if (this.IsLocationFromItemSearch)
                    {
                        // If we found the item we are searching for
                        if (IsItemSearchTarget(objItem))
                        {
                            this.SetFoundItemLocationAndStopProcessing(objItemRectangle.Location);
                        }
                    }

                    // Add the item rectangle to position
                    AddItemRectangleToPosition(objItemRectangle);
                }


            }


            /// <summary>
            /// Processes the group.
            /// </summary>
            /// <param name="objGroup">The group.</param>
            internal override void ProcessGroup(ListViewGroup objGroup)
            {
                // Add the group rectangle 
                AddItemRectangleToPosition(new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, mobjListView.GetPreferdItemFontHeight(false))));
            }

            /// <summary>
            /// Stops the processing.
            /// </summary>
            private void StopProcessing()
            {
                mblnIsProcessingStillNeeded = false;
            }


            /// <summary>
            /// Sets the found item and stop processing.
            /// </summary>
            /// <param name="objItem">The found item.</param>
            private void SetFoundItemAndStopProcessing(ListViewItem objItem)
            {
                // Set the item
                this.Item = objItem;


                // Stop the processing
                StopProcessing();
            }

            /// <summary>
            /// Sets the found item location and stop processing.
            /// </summary>
            /// <param name="objItemLocation">The found item location.</param>
            private void SetFoundItemLocationAndStopProcessing(Point objItemLocation)
            {
                // Set the item location
                this.ItemLocation = objItemLocation;

                // Stop the processing
                StopProcessing();
            }

            /// <summary>
            /// Indicates if this is the item we are searching for
            /// </summary>
            /// <param name="objItem"></param>
            /// <returns></returns>
            private bool IsItemSearchTarget(ListViewItem objItem)
            {
                return this.Item == objItem;
            }

            #region Position Related


            /// <summary>
            /// Adds the item rectangle to position.
            /// </summary>
            /// <param name="objItemRectangle">The item rectangle.</param>
            private void AddItemRectangleToPosition(Rectangle objItemRectangle)
            {
                // If the item is overflowing then we need to open a new line
                if (this.OwnerWidth < this.CurrentPosition.X + objItemRectangle.Width)
                {
                    // Add the item rectangle height
                    this.AddToYPosition(mintLastLineHeight);

                    // Reset the line height
                    mintLastLineHeight = 0;

                    // Open a new line
                    this.ResetXPosition();
                }

                // If is full row item
                if (this.OwnerWidth <= objItemRectangle.Width)
                {
                    // Add the item rectangle height
                    this.AddToYPosition(objItemRectangle.Height);

                    // Reset the line height
                    mintLastLineHeight = 0;

                    // Open a new line
                    this.ResetXPosition();
                }
                else
                {
                    // Set the current line height
                    mintLastLineHeight = Math.Max(mintLastLineHeight, objItemRectangle.Height);

                    // Add the current item position
                    this.AddToXPosition(objItemRectangle.Width);
                }

            }


            /// <summary>
            /// Resets the X position.
            /// </summary>
            private void ResetXPosition()
            {
                mobjCurrentPosition = new Point(0, this.CurrentPosition.Y);
            }

            /// <summary>
            /// Adds to Y position.
            /// </summary>
            /// <param name="intOffsetY">The offset Y.</param>
            private void AddToYPosition(int intOffsetY)
            {
                mobjCurrentPosition = new Point(this.CurrentPosition.X, this.CurrentPosition.Y + intOffsetY);
            }

            /// <summary>
            /// Adds to X position.
            /// </summary>
            /// <param name="intOffsetX">The offset X.</param>
            private void AddToXPosition(int intOffsetX)
            {
                mobjCurrentPosition = new Point(this.CurrentPosition.X + intOffsetX, this.CurrentPosition.Y);

            }

            /// <summary>
            /// Adds to XY position.
            /// </summary>
            /// <param name="intOffsetX">The offset X.</param>
            /// <param name="intOffsetY">The offset Y.</param>
            private void AddToXYPosition(int intOffsetX, int intOffsetY)
            {
                mobjCurrentPosition = new Point(this.CurrentPosition.X + intOffsetX, this.CurrentPosition.Y + intOffsetY);
            }

            /// <summary>
            /// If the location y is with in the y position range
            /// </summary>
            /// <param name="objLocation"></param>
            /// <returns></returns>
            private bool IsYInPositionRange(Point objLocation)
            {
                return mobjCurrentPosition.Y >= objLocation.Y;
            }

            /// <summary>
            /// If the location x is with in the x position range
            /// </summary>
            /// <param name="objLocation"></param>
            /// <returns></returns>
            private bool IsXInPositionRange(Point objLocation)
            {
                return mobjCurrentPosition.X >= objLocation.X;
            }

            /// <summary>
            /// If the location xy is with in the xy position range
            /// </summary>
            /// <param name="objLocation"></param>
            /// <returns></returns>
            private bool IsXYInPositionRange(Point objLocation)
            {
                return IsXInPositionRange(objLocation) && IsYInPositionRange(objLocation);
            }

            #endregion


            #endregion

            #region Properties

            /// <summary>
            /// Gets a value indicating whether this instance is item from location search.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is item from location search; otherwise, <c>false</c>.
            /// </value>
            private bool IsItemFromLocationSearch
            {
                get
                {
                    return menmSearchType == SearchType.ItemFromLocation;
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is location from item search.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is location from item search; otherwise, <c>false</c>.
            /// </value>
            private bool IsLocationFromItemSearch
            {
                get
                {
                    return menmSearchType == SearchType.LocationFromItem;
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is header visible.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is header visible; otherwise, <c>false</c>.
            /// </value>
            private bool IsHeaderVisible
            {
                get
                {
                    // If is in details view
                    if (this.CurrentView == View.Details)
                    {
                        // If there is a header
                        return mobjListView.HeaderStyle != ColumnHeaderStyle.None;
                    }
                    return false;
                }
            }

            /// <summary>
            /// Gets the current view.
            /// </summary>
            /// <value>The current view.</value>
            private View CurrentView
            {
                get
                {
                    return mobjListView.View;
                }
            }


            /// <summary>
            /// Gets the current position.
            /// </summary>
            /// <value>The current position.</value>
            private Point CurrentPosition
            {
                get { return mobjCurrentPosition; }
            }

            /// <summary>
            /// Gets a value indicating whether processing is still needed.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if processing is still needed; otherwise, <c>false</c>.
            /// </value>
            internal override bool IsProcessingStillNeeded
            {
                get
                {
                    return mblnIsProcessingStillNeeded;
                }
            }

            /// <summary>
            /// Gets the item.
            /// </summary>
            /// <value>The item.</value>
            public ListViewItem Item
            {
                get
                {
                    return mobjItem;
                }
                private set
                {
                    mobjItem = value;
                }
            }

            /// <summary>
            /// Gets the location.
            /// </summary>
            /// <value>The location.</value>
            public Point ItemLocation
            {
                get
                {
                    return mobjItemLocation;
                }
                private set
                {
                    mobjItemLocation = value;
                }
            }


            /// <summary>
            /// Gets the owner skin.
            /// </summary>
            /// <value>The owner skin.</value>
            private ListViewSkin OwnerSkin
            {
                get { return mobjOwnerSkin; }
            }


            /// <summary>
            /// Gets the size of the owner.
            /// </summary>
            /// <value>The size of the owner.</value>
            private Size OwnerSize
            {
                get { return mobjOwnerSize; }
            }

            /// <summary>
            /// Gets the height of the owner.
            /// </summary>
            /// <value>The height of the owner.</value>
            private int OwnerHeight
            {
                get
                {
                    return this.OwnerSize.Height;
                }
            }

            /// <summary>
            /// Gets the width of the owner.
            /// </summary>
            /// <value>The width of the owner.</value>
            private int OwnerWidth
            {
                get
                {
                    return this.OwnerSize.Width;
                }
            }

            #endregion
        }

        #endregion

        #region PreItemProcessor Class

        /// <summary>
        /// 
        /// </summary>
        internal class ItemPreRenderingProcessor : ItemProcessor
        {
            /// <summary>
            /// The owner listview
            /// </summary>
            private readonly ListView mobjListView;

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemPreRenderingProcessor"/> class.
            /// </summary>
            /// <param name="objListView">The obj list view.</param>
            internal ItemPreRenderingProcessor(ListView objListView)
            {
                mobjListView = objListView;
            }

            /// <summary>
            /// Processes the item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            internal override void ProcessItem(ListViewItem objItem)
            {
                if (mobjListView != null)
                {
                    // If we are in details view
                    if (mobjListView.View == View.Details)
                    {
                        ListViewItem.ListViewSubItemCollection objSubItems = objItem.SubItems;

                        // If there is a valid subitem collection
                        if (objSubItems != null)
                        {
                            // Loop all columns
                            foreach (ColumnHeader objColumn in mobjListView.Columns)
                            {
                                // If the column is a valid column
                                if (objColumn.IsValidColumn)
                                {
                                    // If the column index is in range
                                    if (objSubItems.Count > objColumn.Index)
                                    {
                                        // Get the current sub item
                                        ListViewItem.ListViewSubItem objSubItem = objSubItems[objColumn.Index];

                                        // Print subitem style if needed always render column 0 style
                                        if (!objItem.UseItemStyleForSubItems || objColumn.Index == 0)
                                        {
                                            // Format item if possible
                                            mobjListView.OnItemFormatting(objItem.Index, objColumn.Index, objSubItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // If there are valid items
                        if (objItem.SubItems.Count > 0)
                        {
                            // Format item if possible
                            mobjListView.OnItemFormatting(objItem.Index, 0, objItem.SubItems[0]);
                        }
                    }
                }
            }

            /// <summary>
            /// Processes the group.
            /// </summary>
            /// <param name="objGroup">The group.</param>
            internal override void ProcessGroup(ListViewGroup objGroup)
            {
                // This function enables pre-rendering logic for a list view group.
            }

        }

        #endregion PreItemProcessor Class

        #endregion Classes

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to WrapColumnHeaders property.
        /// </summary>
        private static SerializableProperty WrapColumnHeadersProperty = SerializableProperty.Register("WrapColumnHeaders", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ColumnHeadersHeight property.
        /// </summary>
        private static SerializableProperty ColumnHeadersHeightProperty = SerializableProperty.Register("ColumnHeadersHeight", typeof(int), typeof(ListView), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to DataMember property.
        /// </summary>
        private static SerializableProperty DataMemberProperty = SerializableProperty.Register("DataMember", typeof(string), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to DataSource property.
        /// </summary>
        private static SerializableProperty DataSourceProperty = SerializableProperty.Register("DataSource", typeof(object), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to AutoGenerateColumns property.
        /// </summary>
        private static SerializableProperty AutoGenerateColumnsProperty = SerializableProperty.Register("AutoGenerateColumns", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to TotalPages property.
        /// </summary>
        private static SerializableProperty TotalPagesProperty = SerializableProperty.Register("TotalPages", typeof(int), typeof(ListView), new SerializablePropertyMetadata(1));

        /// <summary>
        /// Provides a property reference to ItemsPerPage property.
        /// </summary>
        private static SerializableProperty ItemsPerPageProperty = SerializableProperty.Register("ItemsPerPage", typeof(int), typeof(ListView), new SerializablePropertyMetadata(20));

        /// <summary>
        /// Provides a property reference to CurrentPage property.
        /// </summary>
        private static SerializableProperty CurrentPageProperty = SerializableProperty.Register("CurrentPage", typeof(int), typeof(ListView), new SerializablePropertyMetadata(1));

        /// <summary>
        /// Provides a property reference to UseInternalPaging property.
        /// </summary>
        private static SerializableProperty UseInternalPagingProperty = SerializableProperty.Register("UseInternalPaging", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to InUpdate property.
        /// </summary>
        private static SerializableProperty InUpdateProperty = SerializableProperty.Register("InUpdate", typeof(int), typeof(ListView), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to TotalItems property.
        /// </summary>
        private static SerializableProperty TotalItemsProperty = SerializableProperty.Register("TotalItems", typeof(int), typeof(ListView), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to SortingColumns property.
        /// </summary>
        private static SerializableProperty SortingColumnsProperty = SerializableProperty.Register("SortingColumns", typeof(ICollection), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to MultiSelect property.
        /// </summary>
        private static SerializableProperty MultiSelectProperty = SerializableProperty.Register("MultiSelect", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to CheckBoxes property. 
        /// </summary>
        private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to CheckOnDoubleClick property. 
        /// </summary>
        private static SerializableProperty CheckOnDoubleClickProperty = SerializableProperty.Register("CheckOnDoubleClick", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to StateImageList property.
        /// </summary>
        private static SerializableProperty StateImageListProperty = SerializableProperty.Register("StateImageList", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ImageListSmall property.
        /// </summary>
        private static SerializableProperty ImageListSmallProperty = SerializableProperty.Register("ImageListSmall", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to LargeImageList property.
        /// </summary>
        private static SerializableProperty LargeImageListProperty = SerializableProperty.Register("LargeImageList", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to Columns property.
        /// </summary>
        private static SerializableProperty ColumnsProperty = SerializableProperty.Register("Columns", typeof(ColumnHeaderCollection), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to View property.
        /// </summary>
        private static SerializableProperty ViewProperty = SerializableProperty.Register("View", typeof(View), typeof(ListView), new SerializablePropertyMetadata(View.Details));

        /// <summary>
        /// Provides a property reference to SelectOnRightClick property.
        /// </summary>
        private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to FullRowSelect property.
        /// </summary>
        private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register("FullRowSelect", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to GridLines property.
        /// </summary>
        private static SerializableProperty GridLinesProperty = SerializableProperty.Register("GridLines", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ShowItemToolTips property.
        /// </summary>
        private static SerializableProperty ShowItemToolTipsProperty = SerializableProperty.Register("ShowItemToolTips", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ShowGroups property.
        /// </summary>
        private static SerializableProperty ShowGroupsProperty = SerializableProperty.Register("ShowGroups", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// The item sorter of this list
        /// </summary>
        private static readonly SerializableProperty ListViewItemSorterProperty = SerializableProperty.Register("ListViewItemSorter", typeof(IComparer), typeof(ListView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The header style
        /// </summary>
        private static readonly SerializableProperty ColumnHeaderStyleProperty = SerializableProperty.Register("ColumnHeaderStyle", typeof(ColumnHeaderStyle), typeof(ListView), new SerializablePropertyMetadata(ColumnHeaderStyle.Clickable));

        /// <summary>
        /// Allow Column Reorder
        /// </summary>
        private static readonly SerializableProperty AllowColumnReorderProperty = SerializableProperty.Register("AllowColumnReorder", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

        #endregion Serializable Properties

        #region Serializable Events
        /// <summary>
        /// The list view data binding complete Serializable Event
        /// </summary>
        internal static readonly SerializableEvent EVENT_LISTVIEWDATABINDINGCOMPLETE = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

        /// <summary>
        /// The list view data member changed Serializable Event
        /// </summary>
        internal static readonly SerializableEvent EVENT_LISTVIEWDATAMEMBERCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

        /// <summary>
        /// The list view data source changed Serializable Event
        /// </summary>
        internal static readonly SerializableEvent EVENT_LISTVIEWDATASOURCECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

        /// <summary>
        /// The list view Column Reordered Serializable Event
        /// </summary>
        private static readonly SerializableEvent EventColumnReordered = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

        #endregion Serializable Events

        #region Events

        /// <summary>
        /// Gets the hanlder for the SelectedIndexChanged event.
        /// </summary>
        private EventHandler SelectedIndexChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListView.SelectedIndexChangedEvent);
            }
        }

        /// <summary>
        /// The SelectedIndexChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ListView));

        /// <summary>
        /// Occurs when the SelectedIndex property has changed.
        /// </summary>
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                this.AddCriticalHandler(ListView.SelectedIndexChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ListView.SelectedIndexChangedEvent, value);
            }
        }

        /// <summary>
        /// Columns where updated by the user
        /// </summary>
        public event EventHandler ColumnUpdate;

        /// <summary>
        /// Gets the hanlder for the ItemCheck event.
        /// </summary>
        private ItemCheckHandler ItemCheckHandler
        {
            get
            {
                return (ItemCheckHandler)this.GetHandler(ListView.ItemCheckEvent);
            }
        }

        /// <summary>
        /// The ItemCheck event registration.
        /// </summary>
        private static readonly SerializableEvent ItemCheckEvent = SerializableEvent.Register("ItemCheck", typeof(ItemCheckHandler), typeof(ListView));

        /// <summary>
        /// Occurs when the checked state of an item changes.
        /// </summary>
        public event ItemCheckHandler ItemCheck
        {
            add
            {
                this.AddCriticalHandler(ListView.ItemCheckEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ListView.ItemCheckEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client paging changed].
        /// </summary>
        [SRDescription("Occurs when control navigated to another page in client mode."), Category("Client")]
        public event ClientEventHandler ClientPagingChanged
        {
            add
            {
                this.AddClientHandler("Navigate", value);
            }
            remove
            {
                this.RemoveClientHandler("Navigate", value);
            }
        }

        /// <summary>
        /// Occurs when [client selected index changed].
        /// </summary>
        [SRDescription("Occurs when control's selection changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientSelectedIndexChanged
        {
            add
            {
                this.AddClientHandler("SelectionChange", value);
            }
            remove
            {
                this.RemoveClientHandler("SelectionChange", value);
            }
        }

        /// <summary>
        /// Occurs when [client item check].
        /// </summary>
        [SRDescription("Occurs when control's item checked state changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientItemCheck
        {
            add
            {
                this.AddClientHandler("CheckedChange", value);
            }
            remove
            {
                this.RemoveClientHandler("CheckedChange", value);
            }
        }

        /// <summary>
        /// Occurs when [client column reordered].
        /// </summary>
        [SRDescription("Occurs when control's columns reordered in client mode."), Category("Client")]
        public event ClientEventHandler ClientColumnReordered
        {
            add
            {
                this.AddClientHandler("ColumnsReorder", value);
            }
            remove
            {
                this.RemoveClientHandler("ColumnsReorder", value);
            }
        }

        /// <summary>
        /// Occurs when [client column reordered].
        /// </summary>
        [SRDescription("Occurs when control's column width changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientColumnWidthChanged
        {
            add
            {
                this.AddClientHandler("ChangeColumnWidth", value);
            }
            remove
            {
                this.RemoveClientHandler("ChangeColumnWidth", value);
            }
        }

        /// <summary>
        /// Occurs when an item is activated.
        /// </summary>
        public event EventHandler ItemActivate;

        /// <summary>
        /// Occurs when the paging params have changed.
        /// </summary>
        public event EventHandler PagingChanged;

        /// <summary>
        ///
        /// </summary>
        public event ColumnClickEventHandler ColumnClick;

        /// <summary>
        /// Gets the hanlder for the ColumnWidthChanged event.
        /// </summary>
        private ColumnWidthChangedEventHandler ColumnWidthChangedHandler
        {
            get
            {
                return (ColumnWidthChangedEventHandler)this.GetHandler(ListView.ColumnWidthChangedEvent);
            }
        }

        /// <summary>
        /// The ColumnWidthChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ColumnWidthChangedEvent = SerializableEvent.Register("ColumnWidthChanged", typeof(ColumnWidthChangedEventHandler), typeof(ListView));

        /// <summary>
        /// Occurs when the column width has changed.
        /// /// </summary>
        public event ColumnWidthChangedEventHandler ColumnWidthChanged
        {
            add
            {
                this.AddCriticalHandler(ListView.ColumnWidthChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ListView.ColumnWidthChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [column width changing].
        /// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
        /// </summary>
        [Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
        public event ColumnWidthChangedEventHandler ColumnWidthChanging;

        /// <summary>
        /// Occurs when the item is formatting.
        /// will not occurs on sub items when UseItemStyleForSubItems is true
        /// </summary>
        [SRDescription("ListView_ItemFormattingDescr"), SRCategory("CatDisplay")]
        public event ListViewItemFormattingEventHandler ItemFormatting;

        /// <summary>
        /// Occurs when [item binding].
        /// </summary>
        [SRDescription("ListView_ItemBindingDescr"), SRCategory("CatDisplay")]
        public event ListViewItemBindingEventHandler ItemBinding;

        /// <summary>
        /// Occurs when [data binding complete].
        /// </summary>
        [SRDescription("ListView_DataBindingCompleteDescr"), SRCategory("CatData")]
        public event ListViewBindingCompleteEventHandler DataBindingComplete;

        /// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataMember"></see> property changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ListViewDataMemberChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler DataMemberChanged;

        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataSource"></see> property changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ListViewDataSourceChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler DataSourceChanged;

        /// <summary>
        /// Occurs when [column reordered].
        /// </summary>
        [SRDescription("ListViewColumnReorderedDscr"), SRCategory("CatPropertyChanged")]
        public event ColumnReorderedEventHandler ColumnReordered
        {
            add
            {
                this.AddHandler(EventColumnReordered, value);
            }
            remove
            {
                this.RemoveHandler(EventColumnReordered, value);
            }
        }

        /// <summary>Occurs after the list item label text is edited.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("ListViewAfterLabelEditDescr")]
        public event LabelEditEventHandler AfterLabelEdit
        {
            add
            {
                this.AddCriticalHandler(ListView.AfterLabelEditEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ListView.AfterLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterLabelEdit event.
        /// </summary>
        private LabelEditEventHandler AfterLabelEditHandler
        {
            get
            {
                return (LabelEditEventHandler)this.GetHandler(ListView.AfterLabelEditEvent);
            }
        }

        /// <summary>
        /// The AfterLabelEdit event registration.
        /// </summary>
        internal static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(LabelEditEventHandler), typeof(ListView));

        /// <summary>Occurs before the tree node label text is edited.</summary>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event LabelEditEventHandler BeforeLabelEdit
        {
            add
            {
                this.AddHandler(ListView.BeforeLabelEditEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListView.BeforeLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeLabelEdit event.
        /// </summary>
        private LabelEditEventHandler BeforeLabelEditHandler
        {
            get
            {
                return (LabelEditEventHandler)this.GetHandler(ListView.BeforeLabelEditEvent);
            }
        }

        /// <summary>
        /// The BeforeLabelEdit event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof(LabelEditEventHandler), typeof(ListView));

        #endregion Events

        /// <summary>
        /// The listview items collection
        /// </summary>
        [NonSerialized]
        private ListViewItemCollection mobjItems = null;

        /// <summary>
        /// The listview columns collection
        /// </summary>
        [NonSerialized]
        private ColumnHeaderCollection mobjColumns = null;

        /// <summary>
        /// the original item sorting
        /// </summary>
        [NonSerialized]
        private List<ListViewItem> mobjOriginalItemSorting;

        /// <summary>
        /// The group collection
        /// </summary>
        [NonSerialized]
        private ListViewGroupCollection mobjGroups = null;

        #endregion Class Members

        #region C'Tors

        /// <summary>
        /// Creates a new <see cref="ListView"/> instance.
        /// </summary>
        public ListView()
        {
            // Set the control style
            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.StandardClick, false);
            base.SetStyle(ControlStyles.UseTextForAccessibility, false);

            // Set the default control state
            this.SetState(ControlState.AutoScroll, true);

            // create column collection
            mobjColumns = new ColumnHeaderCollection(this);

            // Create item collection
            mobjItems = new ListViewItemCollection(this);

            // Create sorting array
            mobjOriginalItemSorting = new List<ListViewItem>();
        }

        #endregion C'Tor

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow column reorder].
        /// </summary>
        /// <value><c>true</c> if [allow column reorder]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), SRDescription("ListViewAllowColumnReorderDescr"), SRCategory("CatBehavior")]
        public bool AllowColumnReorder
        {
            get
            {
                return this.GetValue<bool>(ListView.AllowColumnReorderProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.AllowColumnReorderProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether a scroll bar is added to the control when there is not enough room to display all items.</summary>
        /// <returns>true if scroll bars are added to the control when necessary to allow the user to see all the items; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(true), SRDescription("ListViewScrollableDescr"), SRCategory("CatBehavior")]
        public bool Scrollable
        {
            get
            {
                return this.GetState(ControlState.AutoScroll);
            }
            set
            {
                // If the scroll value has changed then update the control and raise events
                if (this.SetStateWithCheck(ControlState.AutoScroll, value))
                {
                    this.Update();
                    FireObservableItemPropertyChanged("Scrollable");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ToolTips are shown for the ListViewItem objects contained in the ListView. 
        /// </summary>
        /// <remarks>ShowItemToolTips property must be set true for tooltips to appear.</remarks>
        [DefaultValue(false)]
        public bool ShowItemToolTips
        {
            get
            {
                return this.GetValue<bool>(ListView.ShowItemToolTipsProperty);
            }
            set
            {
                this.SetValue<bool>(ListView.ShowItemToolTipsProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether items are displayed in groups.</summary>
        /// <returns>true to display items in groups; otherwise, false. The default value is true.</returns>
        [SRCategory("CatBehavior"), DefaultValue(true), SRDescription("ListViewShowGroupsDescr")]
        public bool ShowGroups
        {
            get
            {
                return this.GetValue<bool>(ListView.ShowGroupsProperty);
            }
            set
            {
                // If show groups has changed
                if (this.SetValue<bool>(ListView.ShowGroupsProperty, value))
                {
                    // Update listview to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        [SRCategory("CatBehavior"), DefaultValue(SortOrder.None), SRDescription("ListViewSortingDescr")]
        public SortOrder Sorting
        {
            get
            {
                if (this.Columns.Count > 0)
                {
                    return this.Columns[0].SortOrder;
                }

                return SortOrder.None;
            }
            set
            {
                // Validate value.
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(SortOrder));
                }

                // Check that list has enough columns.
                if (this.Columns.Count > 0)
                {
                    // Get first column.
                    ColumnHeader objColumnHeader = this.Columns[0];
                    if (objColumnHeader != null)
                    {
                        // Check that sort order was changed.
                        if (objColumnHeader.SortOrder != value)
                        {
                            // Change first column's sort order.
                            objColumnHeader.SortOrder = value;

                            // Perform listview sorting.
                            if (value != SortOrder.None)
                            {
                                this.Sort();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets the item in the control that currently has focus.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item that has focus, or null if no item has the focus in the <see cref="T:Gizmox.WebGui.Forms.ListView"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ListViewFocusedItemDescr"), SRCategory("CatAppearance")]
        public ListViewItem FocusedItem
        {
            get
            {
                return null;
            }
            set { }
        }

        /// <summary>
        /// Set/Gets the activation type (Not implemented).
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ItemActivation.Standard)]
        public ItemActivation Activation
        {
            get
            {
                return ItemActivation.Standard;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether grid lines exists.
        /// </summary>
        /// <value><c>true</c> if has grid lines; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Browsable(true)]
        [SRDescription("ListViewGridLinesDescr"), SRCategory("CatAppearance"), DefaultValue(false)]
        public bool GridLines
        {
            get
            {
                // A flag indicating if forecolor proerty was found
                bool blnFound;

                // Try to get GridLines from property store
                bool blnGridLines = this.GetValue<bool>(ListView.GridLinesProperty, out blnFound);

                // If forecolor was not found get GridLines from skin
                if (!blnFound)
                {
                    return ((ListViewSkin)this.Skin).ShowGridLines;
                }

                return blnGridLines;
            }
            set
            {
                if (this.SetValue<bool>(ListView.GridLinesProperty, value))
                {
                    UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hide selection].
        /// </summary>
        /// <value><c>true</c> if [hide selection]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(false)]
        public bool HideSelection
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the list view item sorter internal value.
        /// </summary>
        /// <value>The list view item sorter internal value.</value>
        private IComparer ListViewItemSorterInternal
        {
            get
            {
                // Try to get list view item sorter defined by the user
                IComparer objComparer = this.ListViewItemSorter;
                if (objComparer == null)
                {
                    // If listview is bounded
                    if (this.DataSource != null)
                    {
                        // Return the listview comparer which is optimized for bound data
                        return this;
                    }
                    else
                    {
                        // Return the generic listview item sorter
                        return new ListViewItemSorter(this);
                    }
                }
                return objComparer;
            }
        }

        /// <summary>
        /// Gets or sets the list view item sorter.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public IComparer ListViewItemSorter
        {
            get
            {
                return this.GetValue<IComparer>(ListView.ListViewItemSorterProperty);
            }
            set
            {
                this.SetValue<IComparer>(ListView.ListViewItemSorterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether full row select is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if full row select is enabled; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(false)]
        public bool FullRowSelect
        {
            get
            {
                return this.GetValue<bool>(ListView.FullRowSelectProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.FullRowSelectProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the list view mode.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(View.Details)]
        public View View
        {
            get
            {
                return this.GetValue<View>(ListView.ViewProperty);
            }
            set
            {
                if (this.SetValue<View>(ListView.ViewProperty, value))
                {
                    this.Update();
                    FireObservableItemPropertyChanged("View");
                }
            }
        }

        /// <summary>
        /// Gets the list of tags that client events are propogated to.
        /// </summary>
        /// <value>
        /// The client event propogated tags.
        /// </value>
        protected override string ClientEventsPropogationTags
        {
            get
            {
                return string.Format("{0},{1}", WGTags.Row, WGTags.Column);
            }
        }

        /// <summary>
        ///  Gets the collection of columns contained within the listview.
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        public ColumnHeaderCollection Columns
        {
            get
            {
                return mobjColumns;
            }
        }

        /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatBehavior"), Localizable(true), SRDescription("ListViewGroupsDescr")]
        [WebEditor(typeof(ListViewGroupCollectionEditor), typeof(WebUITypeEditor))]
        public ListViewGroupCollection Groups
        {
            get
            {
                // Try to get existing groups collection                
                if (mobjGroups == null)
                {
                    // Create new groups collection
                    mobjGroups = new ListViewGroupCollection(this);

                }

                // Return the groups collection
                return mobjGroups;
            }
        }

        /// <summary>
        ///  Gets the collection of items contained within the listview.
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ListView.ListViewItemCollection Items
        {
            get
            {
                return mobjItems;
            }
        }

        /// <summary>
        /// Gets or sets the header style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(ColumnHeaderStyle.Clickable)]
        public ColumnHeaderStyle HeaderStyle
        {
            get
            {
                return this.GetValue<ColumnHeaderStyle>(ListView.ColumnHeaderStyleProperty);
            }
            set
            {
                if (this.SetValue<ColumnHeaderStyle>(ListView.ColumnHeaderStyleProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as large icons in the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.LargeIcon"></see>. The default is null.</returns>
        /// <filterpriority>2</filterpriority>
        [DefaultValue((string)null), SRDescription("ListViewLargeImageListDescr"), SRCategory("CatBehavior")]
        public ImageList LargeImageList
        {
            get
            {
                return this.GetValue<ImageList>(ListView.LargeImageListProperty);
            }
            set
            {
                if (this.SetValue<ImageList>(ListView.LargeImageListProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
        /// <filterpriority>2</filterpriority>
        [SRDescription("ListViewSmallImageListDescr"), SRCategory("CatBehavior"), DefaultValue((string)null)]
        public ImageList SmallImageList
        {
            get
            {
                return this.GetValue<ImageList>(ListView.ImageListSmallProperty);
            }
            set
            {
                if (this.SetValue<ImageList>(ListView.ImageListSmallProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> associated with application-defined states in the control.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains a set of state images that can be used to indicate an application-defined state of an item. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ListViewStateImageListDescr"), SRCategory("CatBehavior"), DefaultValue((string)null)]
        public ImageList StateImageList
        {
            get
            {
                return this.GetValue<ImageList>(ListView.StateImageListProperty);
            }
            set
            {
                if (this.SetValue<ImageList>(ListView.StateImageListProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a check box appears next to each item in the control.
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(false)]
        public bool CheckBoxes
        {
            get
            {
                return this.GetValue<bool>(ListView.CheckBoxesProperty);
            }
            set
            {
                // Update control if changed
                if (this.SetValue<bool>(ListView.CheckBoxesProperty, value))
                {
                    Update();
                }

                FireObservableItemPropertyChanged("CheckBoxes");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to check CheckBoxes on double click.
        /// </summary>
        /// <value>
        /// <c>true</c> if check CheckBoxes on double click; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        public bool CheckOnDoubleClick
        {
            get
            {
                return this.GetValue<bool>(ListView.CheckOnDoubleClickProperty);
            }
            set
            {
                // Update control if changed
                if (this.SetValue<bool>(ListView.CheckOnDoubleClickProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether multiple items can be selected.
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        public bool MultiSelect
        {
            get
            {
                return this.GetValue<bool>(ListView.MultiSelectProperty);
            }
            set
            {
                // Update control if changed
                if (this.SetValue<bool>(ListView.MultiSelectProperty, value))
                {
                    Update();
                }
            }
        }

        /// <summary>
        /// Resets the current sorting columns collection to enforce recreation of the collection
        /// </summary>
        internal void ResetSortingColumns()
        {
            this.SortingColumnsInternal = null;
        }

        /// <summary>
        /// A collection of columns participating in sorting
        /// </summary>
        internal ICollection SortingColumnsInternal
        {
            get
            {
                return this.GetValue<ICollection>(ListView.SortingColumnsProperty);
            }
            set
            {
                this.SetValue<ICollection>(ListView.SortingColumnsProperty, value);
            }
        }

        /// <summary>
        /// A collection of columns participating in sorting
        /// </summary>
        internal ICollection SortingColumns
        {
            get
            {
                if (this.SortingColumnsInternal == null)
                {
                    ColumnHeaderSortingData objSortData = new ColumnHeaderSortingData(this);
                    this.SortingColumnsInternal = objSortData.SortingColumns;
                    objSortData = null;
                }
                return this.SortingColumnsInternal;
            }
        }

        private CurrencyManager CurrencyManagerInternal
        {
            get
            {
                object objDataSource = this.DataSource;
                string strDataMember = this.DataMember;

                if (objDataSource != null)
                {
                    if (!string.IsNullOrEmpty(strDataMember))
                    {
                        return this.BindingContext[objDataSource, strDataMember] as CurrencyManager;
                    }
                    else
                    {
                        return this.BindingContext[objDataSource] as CurrencyManager;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the currently selected item index.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                ListViewItemCollection objItems = this.Items;
                int intIndex = 0;
                foreach (ListViewItem objListViewItem in objItems)
                {
                    if (objListViewItem.Selected)
                    {
                        return intIndex;
                    }
                    intIndex++;
                }

                return -1;
            }
            set
            {
                Boolean blnIsSelectedIndexDirty = false;
                int intIndex = 0;
                foreach (ListViewItem objListViewItem in this.Items)
                {
                    if (value == intIndex)
                    {
                        if (objListViewItem.InternalSelected != true)
                        {
                            objListViewItem.InternalSelected = true;
                            blnIsSelectedIndexDirty = true;
                            objListViewItem.Update();
                        }
                    }
                    else
                    {
                        if (objListViewItem.InternalSelected != false)
                        {
                            objListViewItem.InternalSelected = false;
                            blnIsSelectedIndexDirty = true;
                            objListViewItem.Update();
                        }
                    }
                    intIndex++;
                }
                if (blnIsSelectedIndexDirty && SelectedIndexChangedHandler != null)
                {
                    OnSelectedIndexChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the selected indices.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ArrayList SelectedIndices
        {
            get
            {
                ArrayList objSelected = new ArrayList();
                int intIndex = 0;
                foreach (ListViewItem objListViewItem in this.Items)
                {
                    if (objListViewItem.Selected) objSelected.Add(intIndex);
                    intIndex++;
                }

                return objSelected;
            }
        }

        /// <summary>
        /// Gets the currently selected item index.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                int intSelectedIndex = SelectedIndex;
                if (intSelectedIndex != -1)
                {
                    return this.Items[intSelectedIndex];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                int intIndex = this.Items.IndexOf(value);
                SelectedIndex = intIndex;
            }
        }

        /// <summary>
        /// Gets or sets the height of the column headers.
        /// </summary>
        /// <value>The height of the column headers.</value>
        [Localizable(false), DefaultValue(-1), SRCategory("CatAppearance"), SRDescription("ListView_ColumnHeadersHeightDescr")]
        public int ColumnHeadersHeight
        {
            get
            {
                return this.GetValue<int>(ListView.ColumnHeadersHeightProperty);
            }
            set
            {
                if (this.SetValue<int>(ListView.ColumnHeadersHeightProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [wrap column headers].
        /// </summary>
        /// <value><c>true</c> if [wrap column headers]; otherwise, <c>false</c>.</value>
        [Localizable(false), DefaultValue(false), SRCategory("CatAppearance"), SRDescription("ListView_WrapColumnHeadersDescr")]
        public bool WrapColumnHeaders
        {
            get
            {
                return this.GetValue<bool>(ListView.WrapColumnHeadersProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.WrapColumnHeadersProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get
            {
                return new ListView.SelectedListViewItemCollection(this);
            }
        }

        /// <summary>
        /// Gets the checked indices.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ArrayList CheckedIndices
        {
            get
            {
                ArrayList objCheched = new ArrayList();
                int intIndex = 0;
                foreach (ListViewItem objListViewItem in this.Items)
                {
                    if (objListViewItem.Checked) objCheched.Add(intIndex);
                    intIndex++;
                }

                return objCheched;
            }
        }

        /// <summary>
        /// Gets the checked items.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ArrayList CheckedItems
        {
            get
            {
                ArrayList objCheched = new ArrayList();
                foreach (ListViewItem objListViewItem in this.Items)
                {
                    if (objListViewItem.Checked) objCheched.Add(objListViewItem);
                }

                return objCheched;
            }
        }

        /// <summary>
        /// Indicates whether the list view is in update mode.
        /// </summary>
        internal int InUpadte
        {
            get
            {
                return this.GetValue<int>(ListView.InUpdateProperty);
            }
            private set
            {
                this.SetValue<int>(ListView.InUpdateProperty, value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override bool IsDelayedDrawing
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// Uses internal paging algorithem
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool UseInternalPaging
        {
            get
            {
                return this.GetValue<bool>(ListView.UseInternalPagingProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.UseInternalPagingProperty, value))
                {
                    this.Update();
                }
            }
        }

        private int CurrentPageInternal
        {
            get
            {
                return this.GetValue<int>(ListView.CurrentPageProperty);
            }
            set
            {
                this.SetValue<int>(ListView.CurrentPageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value></value>
        [DefaultValue(1)]
        public int CurrentPage
        {
            get
            {
                return this.CurrentPageInternal;
            }
            set
            {
                // Check valid range
                if (value > -1 && TotalPages >= value)
                {
                    // If is diffrent
                    if (CurrentPageInternal != value)
                    {
                        // Set current page
                        this.CurrentPageInternal = value;

                        if (this.UseInternalPaging)
                        {
                            //When changing pages we want 
                            //to see the first item in the page.
                            //This setting also fix some bug in the EnsureVisible algorithm
                            this.ScrollTop = 0;

                            // Update control
                            Update();
                        }
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("CurrentPage");
                }
            }
        }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        /// <value>The items per page.</value>
        [DefaultValue(20)]
        public int ItemsPerPage
        {
            get
            {
                return this.GetValue<int>(ListView.ItemsPerPageProperty);
            }
            set
            {
                if (this.SetValue<int>(ListView.ItemsPerPageProperty, value))
                {
                    this.ClearPaging();
                    this.Update();
                }
            }
        }

        private int TotalPagesInternal
        {
            get
            {
                return this.GetValue<int>(ListView.TotalPagesProperty);
            }
            set
            {
                this.SetValue<int>(ListView.TotalPagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [select on right click].
        /// </summary>
        /// <value><c>true</c> if [select on right click]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool SelectOnRightClick
        {
            get
            {
                return this.GetValue<bool>(ListView.SelectOnRightClickProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.SelectOnRightClickProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(1)]
        public int TotalPages
        {
            get
            {
                // If is using internal paging
                if (!this.UseInternalPaging)
                {
                    return TotalPagesInternal;
                }
                else
                {
                    int intTotalPages = (int)Math.Ceiling((double)this.TotalItems / (double)this.ItemsPerPage);
                    if (intTotalPages < 1) intTotalPages = 1;
                    return intTotalPages;
                }
            }
            set
            {
                // If is using internal paging
                if (!this.UseInternalPaging)
                {
                    // If is in valid range
                    if (value > -1)
                    {
                        // If is diffrent
                        if (TotalPagesInternal != value)
                        {
                            // Set total page count
                            TotalPagesInternal = value;

                            // Update control
                            Update();
                        }
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("TotalPages");
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(0)]
        public int TotalItems
        {
            get
            {
                // If is using internal paging
                if (!this.UseInternalPaging)
                {
                    return this.GetValue<int>(ListView.TotalItemsProperty);
                }
                else
                {
                    return this.Items.Count;
                }
            }
            set
            {
                // If is in valid range
                if (value >= 0)
                {
                    if (this.SetValue<int>(ListView.TotalItemsProperty, value))
                    {
                        // Update control
                        Update();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("TotalItems");
                }
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(true)]
        public bool UseCompatibleStateImageBehavior
        {
            get
            {
                return true;
            }
            set
            { }
        }



        /// <summary>Gets or sets the size of the tiles shown in tile view.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that contains the new tile size.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ListViewTileSizeDescr"), SRCategory("CatAppearance")]
        public Size TileSize
        {
            get
            {
                return Size.Empty;
            }
            set
            { }
        }

        /// <summary>Gets or sets the alignment of items in the control.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. The default is <see cref="F:Gizmox.WebGui.Forms.ListViewAlignment.Top"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is not one of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Localizable(true), SRDescription("ListViewAlignmentDescr"), DefaultValue(ListViewAlignment.Top), SRCategory("CatBehavior")]
        public ListViewAlignment Alignment
        {
            get
            {
                return ListViewAlignment.Top;
            }
            set
            { }
        }

        /// <summary>Gets or sets a value indicating whether the label text of the list items can be edited.</summary>
        /// <returns>true if the label text of the list items can be edited; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ListViewLabelEditDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool LabelEdit
        {
            get
            {
                // If treeview is not in readonly state
                return this.GetState(ComponentState.ReadOnly);
            }
            set
            {
                // Set the treeview readonly state
                if (this.SetStateWithCheck(ComponentState.ReadOnly, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ListViewWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as ListViewWinFormsCompatibility;
            }
        }

        #endregion Properties

        #region Methods

        #region Render

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {

            RegisterComponent(this);
            RegisterBatch(Columns);
            RegisterBatch(Items);


            // add attributes to control element
            objWriter.WriteAttributeString(WGAttributes.View, View.ToString());
            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);

            if (!this.Scrollable)
            {
                objWriter.WriteAttributeString(WGAttributes.Scrollbars, "0");
            }

            if (this.FullRowSelect)
            {
                objWriter.WriteAttributeString(WGAttributes.FullRowSelect, "1");
            }

            ImageList objLargeImageList = this.LargeImageList;
            ImageList objSmallImageList = this.SmallImageList;

            if (objLargeImageList != null && this.View == View.LargeIcon)
            {
                objWriter.WriteAttributeString(WGAttributes.LargeImageWidth, objLargeImageList.ImageSize.Width.ToString());
                objWriter.WriteAttributeString(WGAttributes.LargeImageHeight, objLargeImageList.ImageSize.Height.ToString());
            }
            else if (objSmallImageList != null && this.View == View.SmallIcon)
            {
                objWriter.WriteAttributeString(WGAttributes.ImageWidth, objSmallImageList.ImageSize.Width.ToString());
                objWriter.WriteAttributeString(WGAttributes.ImageHeight, objSmallImageList.ImageSize.Height.ToString());
            }

            objWriter.WriteAttributeString(WGAttributes.CurrentPage, this.CurrentPage.ToString());
            objWriter.WriteAttributeString(WGAttributes.TotalPages, this.TotalPages.ToString());


            // Render the HeaderStyle attributes.
            objWriter.WriteAttributeString(WGAttributes.HeaderStyle, Convert.ToInt32(this.HeaderStyle).ToString());

            // add optional attributes
            if (CheckBoxes) objWriter.WriteAttributeString(WGAttributes.CheckBoxes, "1");
            if (CheckOnDoubleClick) objWriter.WriteAttributeString(WGAttributes.CheckOnDoubleClick, "1");
            if (MultiSelect) objWriter.WriteAttributeString(WGAttributes.Multiple, "1");
            if (GridLines) objWriter.WriteAttributeString(WGAttributes.GridLines, "1");

            RenderControls(objContext, objWriter, 0);

        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render the Allow User To Order Columns attribute.
            RenderAllowColumnReorder(objWriter, false);

            // Render the SelectOnRightClick attribute.
            RenderSelectOnRightClick(objWriter, false);

            // Render the LabelEdit attribute.
            RenderEditingInformation(objWriter, false);
            
            objWriter.WriteAttributeString(WGAttributes.ItemHeight, GetPreferdControlItemHeight().ToString());

            objWriter.WriteAttributeString(WGAttributes.ListViewShowGridLinesOnEmptyRows,this.WinFormsCompatibility.ShowGridLinesOnEmptyRows ? "1" : "0");

            if (this.View == View.Details)
            {
                // Try get column's headers height.
                int intPreferedHeaderHeight = GetColumnHeaderHeight();

                objWriter.WriteAttributeString(WGAttributes.HeaderHeight, intPreferedHeaderHeight.ToString());                

                // Check if column headers should be wrapped.
                if (this.WrapColumnHeaders)
                {
                    objWriter.WriteAttributeString(WGAttributes.WrapContents, "1");
                }
            }           
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
        {
            RenderContent(objContext, objWriter, lngRequestID, blnFullRedraw);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            RenderContent(objContext, objWriter, lngRequestID, true);
        }

        /// <summary>
        /// Pre-render control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            // Process the visible items 
            ProcessVisibleItemsAndGroups(new ItemPreRenderingProcessor(this), false);

            base.PreRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnFullRedraw">if set to <c>true</c> full redraw.</param>
        private void RenderContent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
        {
            // Render columns
            foreach (ColumnHeader objColumn in Columns.SortedColumns)
            {
                objColumn.RenderColumn(objContext, objWriter, lngRequestID);
            }

            // Get the list of items to render
            ProcessVisibleItemsAndGroups(new ItemRenderingProcessor(this, objContext, objWriter, lngRequestID, blnFullRedraw), this.IsDirty(lngRequestID));
        }

        /// <summary>
        /// Processes the visible items and groups.
        /// </summary>
        /// <param name="blnGroupdShouldBeRendered">
        /// A flag indicating if current group should be rendered
        /// this value is by default true only if is in dirty mode
        /// otherwise we do not need to render groups
        /// </param>
        /// <returns></returns>
        private void ProcessVisibleItemsAndGroups(ItemProcessor objProcessor, bool blnGroupsShouldBeRendered)
        {
            // If processing is still needed
            if (objProcessor.IsProcessingStillNeeded)
            {
                // Get the nuber of items to display per page
                int intItemsPerPage = this.ItemsPerPage;

                // the item index
                int intIndex = 0;

                // The index 'from' and 'to' that needs to be displayed 
                int intIndexFrom = (this.CurrentPageInternal - 1) * intItemsPerPage;
                int intIndexTo = intIndexFrom + intItemsPerPage;

                // Get the listview groups to render
                ListViewGroupCollection objGroupsToRender = GetGroupsToRender();

                // If there are no groups to render
                if (objGroupsToRender == null)
                {
                    // Render list view items
                    foreach (ListViewItem objListViewItem in this.Items)
                    {
                        // If processing is done
                        if (!objProcessor.IsProcessingStillNeeded)
                        {
                            return;
                        }

                        // If internal paging is to be used
                        if (this.UseInternalPaging)
                        {
                            // If index is more the the lower bound
                            if (intIndex >= intIndexFrom)
                            {
                                // If index is less than the upper bound
                                if (intIndex < intIndexTo)
                                {
                                    // Process item                                
                                    objProcessor.ProcessItem(objListViewItem);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Process item
                            objProcessor.ProcessItem(objListViewItem);
                        }

                        intIndex++;
                    }
                }
                else
                {
                    bool blnRenderGroup = blnGroupsShouldBeRendered;

                    // Loop all groupless items and add to default groupd if needed
                    foreach (ListViewItem objListViewItem in this.Items)
                    {
                        // If processing is done
                        if (!objProcessor.IsProcessingStillNeeded)
                        {
                            return;
                        }

                        // If group was not assigned
                        if (objListViewItem.Group == null || !this.Groups.Contains(objListViewItem.Group))
                        {
                            // If internal paging is to be used
                            if (this.UseInternalPaging)
                            {
                                // If index is more the the lower bound
                                if (intIndex >= intIndexFrom)
                                {
                                    // If index is less than the upper bound
                                    if (intIndex < intIndexTo)
                                    {
                                        // If groupd should be rendered
                                        if (blnRenderGroup)
                                        {
                                            // Process the default group
                                            objProcessor.ProcessGroup(null);

                                            // Indicate group was rendered
                                            blnRenderGroup = false;
                                        }

                                        // Process the current item
                                        objProcessor.ProcessItem(objListViewItem);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // If groupd should be rendered
                                if (blnRenderGroup)
                                {
                                    // Process the default group
                                    objProcessor.ProcessGroup(null);

                                    // Indicate group was rendered
                                    blnRenderGroup = false;
                                }

                                // Process the current item
                                objProcessor.ProcessItem(objListViewItem);
                            }

                            // This is the current index of the item and we should increment index
                            // counting for paging
                            intIndex++;
                        }
                    }

                    // Loop all groups with in list view
                    foreach (ListViewGroup objListViewGroup in objGroupsToRender)
                    {
                        blnRenderGroup = blnGroupsShouldBeRendered;

                        // Loop all groupless items and add to current group items if needed
                        foreach (ListViewItem objListViewItem in this.Items)
                        {
                            // If item was assigned to current group
                            if (objListViewItem.Group == objListViewGroup)
                            {
                                // If internal paging is to be used
                                if (this.UseInternalPaging)
                                {
                                    // If index is more the the lower bound
                                    if (intIndex >= intIndexFrom)
                                    {
                                        // If index is less than the upper bound
                                        if (intIndex < intIndexTo)
                                        {
                                            // If should render group
                                            if (blnRenderGroup)
                                            {
                                                // Process the current group                                            
                                                objProcessor.ProcessGroup(objListViewItem.Group);

                                                // Clear should render group value
                                                blnRenderGroup = false;
                                            }

                                            // Process the current item
                                            objProcessor.ProcessItem(objListViewItem);

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // If should render group
                                    if (blnRenderGroup)
                                    {
                                        // Process the current group
                                        objProcessor.ProcessGroup(objListViewGroup);

                                        // Clear should render group value
                                        blnRenderGroup = false;
                                    }

                                    // Process the current item
                                    objProcessor.ProcessItem(objListViewItem);

                                }

                                // This is the current index of the item and we should increment index
                                // counting for paging
                                intIndex++;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Renders the group.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objListViewGroup">The list view group.</param>
        private void RenderGroup(IContext objContext, IResponseWriter objWriter, ListViewGroup objListViewGroup, ListView.ItemRenderingProcessor objProcessor)
        {
            // Write start group row
            objWriter.WriteStartElement(WGTags.Group);

            // If not default row
            if (objListViewGroup != null)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, objListViewGroup.Header, TextFilter.CarriageReturn | TextFilter.NewLine);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.Text, "Default");
            }
            objWriter.WriteEndElement();
        }

        /// <summary>
        /// Gets a collection of groups if should render groups.
        /// </summary>
        /// <returns></returns>
        private ListViewGroupCollection GetGroupsToRender()
        {
            // If should show groups
            if (this.ShowGroups)
            {
                // Get the current groups collection
                if (mobjGroups != null)
                {
                    // If there are groups to render
                    if (mobjGroups.Count > 0)
                    {
                        // Return the groups collection to be rendered
                        return mobjGroups;
                    }
                }
            }

            // Return a null to prevent group rendering
            return null;
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {

            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            // add optional attributes
            objWriter.WriteAttributeString(WGAttributes.CheckBoxes, this.CheckBoxes ? "1" : "0");
            objWriter.WriteAttributeString(WGAttributes.CheckOnDoubleClick, this.CheckOnDoubleClick ? "1" : "0");
            objWriter.WriteAttributeString(WGAttributes.Multiple, this.MultiSelect ? "1" : "0");
            objWriter.WriteAttributeString(WGAttributes.GridLines, this.GridLines ? "1" : "0");
            
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderEditingInformation(objWriter, true);
                RenderAllowColumnReorder(objWriter, true);
                RenderSelectOnRightClick(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the editing information.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [force render].</param>
        protected void RenderEditingInformation(IAttributeWriter objWriter, bool blnForceRender)
        {
            if ((this.LabelEdit) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.LabelEdit, this.LabelEdit ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the select on right click.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.SelectOnRightClick)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "0");
            }
        }

        /// <summary>
        /// Renders the allow column reorder.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> force render.</param>
        private void RenderAllowColumnReorder(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Render the Allow User To Order Columns attribute.
            if (this.AllowColumnReorder)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowUserToOrderColumns, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowUserToOrderColumns, "0");
            }
        }


        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objProposedSize">The proposed size.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            return objProposedSize;
        }

        /// <summary>
        /// Layout the internal controls to reflect parent changes
        /// </summary>
        /// <param name="objEventArgs">The layout arguments.</param>
        /// <param name="objNewSize">The new parent size.</param>
        /// <param name="objOldSize">The old parent size.</param>
        protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
        {
            // We have a diffrent layout schema here
        }

        /// <summary>
        /// Gets the height of the preferd item font.
        /// </summary>
        /// <returns></returns>
        internal int GetPreferdItemFontHeight(bool blnIsHeader)
        {
            //Get the current skin
            ListViewSkin objListViewSkin = this.Skin as ListViewSkin;

            //If the skin exists
            if (objListViewSkin != null)
            {
                // Get the arrow icon padding value
                PaddingValue objPaddingValue = null;

                if (blnIsHeader)
                {
                    objPaddingValue = (((ListViewSkin)objListViewSkin).HeaderNormalStyle).Padding as PaddingValue;
                }
                else
                {
                    objPaddingValue = (((ListViewSkin)objListViewSkin).CellNormalStyle).Padding as PaddingValue;
                }

                //Set the default padding
                int intPaddingOffset = 0;

                //If we go an objPaddingValue sum the offset height of the item
                if (objPaddingValue != null)
                {
                    intPaddingOffset = objPaddingValue.Vertical + (blnIsHeader ? 7 : 0);
                }
                
                return Math.Max(objListViewSkin.CheckBoxButtonHeight, CommonUtils.GetFontHeight(this.GetProxyPropertyValue<Font>("Font", this.Font))) + intPaddingOffset;
            }
            return 0;
        }

        #endregion Render

        #region Events

        /// <summary>
        /// Raises the <see cref="E:ItemFormatting"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"/> instance containing the event data.</param>
        protected virtual void OnItemFormatting(ListViewItemFormattingEventArgs e)
        {
            // Get Handler
            ListViewItemFormattingEventHandler objEventHandler = this.ItemFormatting;

            //Check if the event is registered
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ItemBinding"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs"/> instance containing the event data.</param>
        private void OnItemBinding(ListViewItemBindingEventArgs e)
        {
            // Get Handler.
            ListViewItemBindingEventHandler objEventHandler = this.ItemBinding;
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        internal void OnItemFormatting(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
        {
            ListViewItemFormattingEventArgs args = new ListViewItemFormattingEventArgs(intItemIndex, intColumnIndex, objSubItem);
            this.OnItemFormatting(args);
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="blnValid"></param>
        internal void FireUpdateColumns(bool blnValid)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ColumnUpdate;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Fires the selected index changed.
        /// </summary>
        /// <param name="objListViewItem">The obj list view item.</param>
        internal void FireSelectedIndexChanged(ListViewItem objListViewItem)
        {
            OnSelectedIndexChanged(new ListViewItemEventArgs(objListViewItem));
        }

        /// <summary>
        /// Raises the <see cref="E:SelectedIndexChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnSelectedIndexChanged(System.EventArgs e)
        {
            CurrencyManager objCurrencyManager = this.CurrencyManagerInternal;

            // Get Handler
            EventHandler objEventHandler = this.SelectedIndexChangedHandler;

            // Raise event if needed
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }

            if (objCurrencyManager != null &&
                mobjOriginalItemSorting != null &&
                this.SelectedItem != null)
            {
                objCurrencyManager.Position = mobjOriginalItemSorting.IndexOf(this.SelectedItem);
            }
        }

        /// <summary>
        /// Internals the column width changed.
        /// </summary>
        /// <param name="ColumnIndex">Index of the column.</param>
        internal void InternalColumnWidthChanged(int ColumnIndex)
        {
            ColumnWidthChangedEventArgs e = new ColumnWidthChangedEventArgs(ColumnIndex);
            OnColumnWidthChanging(e);
            OnColumnWidthChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:ColumnWidthChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            // Get Handler
            ColumnWidthChangedEventHandler objEventHandler = this.ColumnWidthChangedHandler;
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs"/> instance containing the event data.</param>
        [Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
        protected virtual void OnColumnWidthChanging(ColumnWidthChangedEventArgs e)
        {
            // Get Handler
            ColumnWidthChangedEventHandler objEventHandler = this.ColumnWidthChanging;

            // Raise event if needed
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            ColumnHeaderCollection objColumns = this.Columns;
            ListViewItemCollection objItems = this.Items;

            // Register the Columns
            if (objColumns != null)
            {
                RegisterBatch(objColumns);
            }

            // Register the Items
            if (objItems != null)
            {
                RegisterBatch(objItems);
            }
        }
        
        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            ColumnHeaderCollection objColumns = this.Columns;
            ListViewItemCollection objItems = this.Items;

            // Unregister the Columns
            if (objColumns != null)
            {
                UnRegisterBatch(objColumns);
            }

            // Unregister the Items
            if (objItems != null)
            {
                UnRegisterBatch(objItems);
            }
        }

        #endregion Events

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            Type objOffspringType = Type.GetType(strOffspringTypeName);
            if (objOffspringType != null)
            {
                if (CommonUtils.IsTypeOrSubType(objOffspringType, typeof(ListViewItem)))
                {
                    return this.Items;
                }
                else if (CommonUtils.IsTypeOrSubType(objOffspringType, typeof(ColumnHeader)))
                {
                    return this.Columns;
                }
            }

            return base.GetComponentOffsprings(strOffspringTypeName);
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new ListViewRenderer(this);
        }


        /// <summary>
        /// Fires the item check.
        /// </summary>
        /// <param name="objListViewItem">The obj list view item.</param>
        /// <param name="blnChecked">if set to <c>true</c> [BLN checked].</param>
        internal void FireItemCheck(ListViewItem objListViewItem, bool blnChecked)
        {
            // If there is an event hanlder for the ItemCheck event
            if (ItemCheckHandler != null)
            {
                ListViewItemCollection objItems = this.Items;

                if (blnChecked)
                {
                    // Raise unchecked item
                    ItemCheckHandler(this, new ItemCheckEventArgs(objItems.IndexOf(objListViewItem), CheckState.Checked, CheckState.Unchecked));
                }
                else
                {
                    // Raise unchecked item
                    ItemCheckHandler(this, new ItemCheckEventArgs(objItems.IndexOf(objListViewItem), CheckState.Unchecked, CheckState.Checked));
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal protected virtual void OnItemDoubleClick(ListViewItem objListViewItem, MouseEventArgs objMouseEventArgs)
        {
            this.OnDoubleClick(objMouseEventArgs);
        }

        /// <summary>
        ///
        /// </summary>
        internal protected virtual void OnItemClick(ListViewItem objListViewItem, MouseEventArgs objMouseEventArgs)
        {
            this.OnClick(objMouseEventArgs);
        }

        /// <summary>
        /// Fires the swipe.
        /// </summary>
        /// <param name="enmSwipeDirection">The swipe direction.</param>
        internal protected virtual void OnItemSwipe(ListViewItem objListViewItem, SwipeDirection enmSwipeDirection)
        {
            this.OnSwipe(enmSwipeDirection);
        }

        /// <summary>
        /// Gets the relative XY from item.
        /// </summary>
        /// <param name="objItem">The list view item.</param>
        /// <param name="intX">The X position.</param>
        /// <param name="intY">The Y position</param>
        /// <returns></returns>
        internal void GetRelativeXYFromItem(ListViewItem objItem, ref int intX, ref int intY)
        {
            // Create an item layout processor
            ItemLayoutProcessor objProcessor = new ItemLayoutProcessor(this, objItem);

            // Process the visible items and groups
            ProcessVisibleItemsAndGroups(objProcessor, true);

            // Return the xy relative to the item location
            intX = objProcessor.ItemLocation.X + intX;
            intY = objProcessor.ItemLocation.Y + intY;
        }

        /// <summary>
        /// Gets the item from relative XY.
        /// </summary>
        /// <param name="intX">The X position.</param>
        /// <param name="intY">The Y position</param>
        /// <returns></returns>
        private ListViewItem GetItemFromRelativeXY(int intX, int intY)
        {
            // Create an item layout processor
            ItemLayoutProcessor objProcessor = new ItemLayoutProcessor(this, new Point(intX, intY));

            // Process the visible items and groups
            ProcessVisibleItemsAndGroups(objProcessor, true);

            // Return the item if managed to find one
            return objProcessor.Item;
        }

        /// <summary>Retrieves the item at the specified location.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item at the specified position. If there is no item at the specified location, the method returns null.</returns>
        /// <param name="intY">The y-coordinate of the location to search for an item (expressed in client coordinates). </param>
        /// <param name="intX">The x-coordinate of the location to search for an item (expressed in client coordinates). </param>
        /// <filterpriority>1</filterpriority>
        public ListViewItem GetItemAt(int intX, int intY)
        {
            return GetItemFromRelativeXY(intX, intY);
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {

            bool blnUpdate = false;

            // Select event type
            switch (objEvent.Type)
            {

                case "SelectionChange":
                    SelectIndexes(objEvent["Indexes"] as string, objEvent["Incremental"] == "1");
                    break;
                case "CheckedChange":
                    CheckIndexes(objEvent["Indexes"] as string);
                    break;
                case "Navigate":
                        string strTo = objEvent["To"];
                        switch (strTo)
                    {
                        case "End":
                            CurrentPage = TotalPages;
                            break;
                        case "Home":
                            CurrentPage = 1;
                            break;
                        case "Next":
                            if (CurrentPage < TotalPages) CurrentPage = CurrentPage + 1;
                            break;
                        case "Back":
                            if (CurrentPage > 1) CurrentPage = CurrentPage - 1;
                            break;
                        default:
                            int intPage;
                            if (int.TryParse(strTo, out intPage) && intPage > 0 && intPage <= this.TotalPages)
                            {
                                this.CurrentPage = intPage;
                            }
                            break;
                    }

                    // Fires when requested to navigate to a different page.
                    if (PagingChanged != null)
                    {
                        PagingChanged(this, new EventArgs());
                    }

                    break;
                case "SelectNone":
                    foreach (ListViewItem objItem in this.Items)
                    {
                        if (objItem.Selected)
                        {
                            objItem.Selected = false;
                            blnUpdate = true;
                        }
                    }
                    break;
                case "SelectAll":
                    foreach (ListViewItem objItem in this.Items)
                    {
                        if (!objItem.Selected)
                        {
                            objItem.Selected = true;
                            blnUpdate = true;
                        }
                    }
                    break;
                case "CheckAll":
                    foreach (ListViewItem objItem in this.Items)
                    {
                        if (!objItem.Checked)
                        {
                            objItem.Checked = true;
                            blnUpdate = true;
                        }
                    }
                    break;
                case "CheckNone":
                    foreach (ListViewItem objItem in this.Items)
                    {
                        if (objItem.Checked)
                        {
                            objItem.Checked = false;
                            blnUpdate = true;
                        }
                    }
                    break;

                #region ColumnsReorder

                case "ColumnsReorder":
                    if (objEvent.Contains(WGAttributes.DraggedColumn) && objEvent.Contains(WGAttributes.TargetColumn))
                    {
                        // Get dragged and target columns indexes.
                        int intDraggedId = Convert.ToInt32(objEvent[WGAttributes.DraggedColumn]);
                        int intTargetID = Convert.ToInt32(objEvent[WGAttributes.TargetColumn]);
                        int intDraggedColumnIndex = -1;
                        int intTargetColumnIndex = -1;

                        foreach (ColumnHeader objCol in this.Columns)
                        {
                            if (objCol.ID == intDraggedId)
                            {
                                intDraggedColumnIndex = objCol.Index;
                            }
                            else if (objCol.ID == intTargetID)
                            {
                                intTargetColumnIndex = objCol.Index;
                            }
                        }

                        // Validate columns indexes.
                        if (intDraggedColumnIndex >= 0 && intDraggedColumnIndex < this.Columns.Count &&
                            intTargetColumnIndex >= 0 && intTargetColumnIndex < this.Columns.Count)
                        {
                            // Get target column display index.
                            int intNewDisplayIndex = this.Columns[intTargetColumnIndex].DisplayIndex;

                            int intOldDisplayIndex = this.Columns[intDraggedColumnIndex].DisplayIndex;

                            // In case that dragged column display index is bigger the the target column display index -
                            // increase the target column display index by one.
                            if (intOldDisplayIndex > intNewDisplayIndex)
                            {
                                // Update dragged column's display index.
                                intNewDisplayIndex += 1;
                            }

                            //check that the indexes changed
                            if (intOldDisplayIndex != intNewDisplayIndex)
                            {
                                //raise event
                                ColumnReorderedEventArgs objArgs = new ColumnReorderedEventArgs(intOldDisplayIndex, intNewDisplayIndex, this.Columns[intDraggedColumnIndex]);
                                ColumnReorderedEventHandler objHandler = (ColumnReorderedEventHandler)this.GetHandler(EventColumnReordered);

                                if (objHandler != null)
                                {
                                    objHandler(this, objArgs);
                                }

                                if (!objArgs.Cancel)
                                {
                                    // Update dragged column's display index.                                 
                                    this.Columns[intDraggedColumnIndex].DisplayIndex = intNewDisplayIndex;

                                    //Clear Sorted Columns list
                                    this.Columns.ClearSortedColumns();

                                    // Update the whole grid.
                                    blnUpdate = true;
                                }
                            }
                        }
                    }
                    break;

                #endregion

            }

            base.FireEvent(objEvent);

            if (blnUpdate)
            {
                this.Update();
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (SelectedIndexChangedHandler != null || this.DataSourceHasBindings)
            {
                objEvents.Set(WGEvents.SelectionChange);
            }

            if (ItemCheckHandler != null)
            {
                objEvents.Set(WGEvents.CheckedChange);
            }

            if (ColumnWidthChangedHandler != null)
            {
                objEvents.Set(WGEvents.ChangeColumnWidth);
            }

            if (AfterLabelEditHandler != null)
            {
                objEvents.Set(WGEvents.AfterLabelEdit);
            }
            

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("SelectionChange"))
            {
                objEvents.Set(WGEvents.SelectionChange);
            }

            if (this.HasClientHandler("CheckedChange"))
            {
                objEvents.Set(WGEvents.CheckedChange);
            }

            if (this.HasClientHandler("ChangeColumnWidth"))
            {
                objEvents.Set(WGEvents.ChangeColumnWidth);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical events internal.
        /// </summary>
        /// <returns></returns>
        internal CriticalEventsData GetCriticalEventsDataInternal()
        {
            return this.GetCriticalEventsData();
        }

        /// <summary>Ensures that the specified item is visible within the control, scrolling the contents of the control if necessary.</summary>
        /// <param name="index">The zero-based index of the item to scroll into view. </param>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void EnsureVisible(int index)
        {
            if ((index < 0) || (index >= this.Items.Count))
            {
                throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
            }
            this.Items[index].EnsureVisible();
        }

        /// <summary>
        /// Removes all items and columns from the control.
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
            this.Columns.Clear();
        }

        /// <summary>
        /// Selects the indexes.
        /// </summary>
        /// <param name="strIndexes">STR indexes.</param>
        /// <param name="blnIncremental">if set to <c>true</c> [BLN incremental].</param>
        private void SelectIndexes(string strIndexes, bool blnIncremental)
        {
            bool blnIsSelectedIndexDirty = false;

            // Get ordered items
            ListViewOrederedItems objItems = new ListViewOrederedItems(this);

            // Indexes offset
            int intIndexFrom = 0;
            int intIndexTo = objItems.Count - 1;
            int intItemsPerPage = this.ItemsPerPage;

            // Calculate offset
            if (this.UseInternalPaging)
            {
                intIndexFrom = (this.CurrentPageInternal - 1) * intItemsPerPage;
                intIndexTo = intIndexFrom + intItemsPerPage - 1;

                if (intIndexTo > objItems.Count - 1) intIndexTo = objItems.Count - 1;
            }

            if (!blnIncremental)
            {
                for (int intIndex = 0; intIndex < objItems.Count; intIndex++)
                {
                    if (objItems[intIndex].InternalSelected != false)
                    {
                        objItems[intIndex].InternalSelected = false;
                        blnIsSelectedIndexDirty = true;
                    }
                }
            }
            else
            {
                for (int intIndex = intIndexFrom; intIndex <= intIndexTo; intIndex++)
                {
                    if (objItems[intIndex].InternalSelected != false)
                    {
                        objItems[intIndex].InternalSelected = false;
                        blnIsSelectedIndexDirty = true;
                    }

                }
            }


            //
            if (strIndexes != string.Empty)
            {
                // Get index string array
                string[] arrIndexes = strIndexes.Split(',');

                // Loop all indexes
                foreach (string strIndex in arrIndexes)
                {
                    // Get index
                    int intIndex = int.Parse(strIndex);

                    if (objItems[intIndex + intIndexFrom].InternalSelected != true)
                    {
                        objItems[intIndex + intIndexFrom].InternalSelected = true;
                        blnIsSelectedIndexDirty = true;
                    }
                }
            }

            // Raise event if needed
            if (blnIsSelectedIndexDirty)
            {
                OnSelectedIndexChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Checks the indexes.
        /// </summary>
        /// <param name="strIndexes">indexes.</param>
        private void CheckIndexes(string strIndexes)
        {
            // Get checked arrat list
            ArrayList objChecked = new ArrayList(strIndexes.Split(','));

            // Get ordered items
            ListViewOrederedItems objItems = new ListViewOrederedItems(this);

            // Indexes offset
            int intIndexFrom = 0;
            int intIndexTo = objItems.Count - 1;

            // Calculate offset
            if (this.UseInternalPaging)
            {
                int intItemsPerPage = this.ItemsPerPage;
                intIndexFrom = (this.CurrentPageInternal - 1) * intItemsPerPage;
                intIndexTo = intIndexFrom + intItemsPerPage - 1;

                if (intIndexTo > objItems.Count - 1) intIndexTo = objItems.Count - 1;
            }

            // Create image of current items check state
            List<bool> arrItemsCheck = new List<bool>(intIndexTo + 1 - intIndexFrom);

            // Loop all items
            for (int intIndex = intIndexFrom; intIndex <= intIndexTo; intIndex++)
            {
                // Get current check state
                arrItemsCheck.Add(objItems[intIndex].InternalChecked);
            }

            // Loop all items
            for (int intIndex = intIndexFrom; intIndex <= intIndexTo; intIndex++)
            {
                // If the item is checked
                if (objChecked.Contains(((int)(intIndex - intIndexFrom)).ToString()))
                {
                    // If the item was not checed
                    if (!arrItemsCheck[intIndex-intIndexFrom])
                    {
                        // Check item
                        objItems[intIndex].InternalChecked = true;

                        if (ItemCheckHandler != null)
                        {
                            // Raise checked changed
                            ItemCheckHandler(this, new ItemCheckEventArgs(Items.IndexOf(objItems[intIndex]), CheckState.Checked, CheckState.Unchecked));
                        }
                    }
                }
                else
                {
                    // If item was checked
                    if (arrItemsCheck[intIndex - intIndexFrom])
                    {
                        // Set unchecked item
                        objItems[intIndex].InternalChecked = false;

                        if (ItemCheckHandler != null)
                        {
                            // Raise unchecked item
                            ItemCheckHandler(this, new ItemCheckEventArgs(Items.IndexOf(objItems[intIndex]), CheckState.Unchecked, CheckState.Checked));
                        }
                    }
                }
            }
        }

        #region General

        /// <summary>
        /// Gets the height of the column header.
        /// </summary>
        /// <returns></returns>
        private int GetColumnHeaderHeight()
        {
            int intPreferedHeaderHeight = this.ColumnHeadersHeight;
            if (intPreferedHeaderHeight == -1)
            {
                intPreferedHeaderHeight = ((ListViewSkin)this.Skin).HeaderHeight;
                if (intPreferedHeaderHeight == -1)
                {
                    // Get preferd item font height.
                    intPreferedHeaderHeight = this.GetPreferdItemFontHeight(true);
                }
            }
            return intPreferedHeaderHeight;
        }

        /// <summary>
        /// Gets the preferd height of the control item.
        /// </summary>
        /// <param name="intPreferedItemHeight">The preferd height of the item.</param>
        /// <returns></returns>
        private int GetPreferdControlItemHeight()
        {
            int intPreferedItemHeight = this.GetPreferdItemFontHeight(false);

            int intMaxHeight = 0;

            foreach (ColumnHeader objColumn in this.Columns)
            {
                if (objColumn.Type == ListViewColumnType.Control)
                {
                    intMaxHeight = Math.Max(intMaxHeight, objColumn.PreferedItemHeight);
                }
            }
            return Math.Max(intPreferedItemHeight, intMaxHeight);
        }

        /// <summary>
        /// Flags that the listview is currently going through updates.
        /// </summary>
        public void BeginUpdate()
        {
            this.InUpadte = this.InUpadte + 1;
        }

        /// <summary>
        /// Finish batch updates and flags that the listview has finished updates.
        /// </summary>
        public void EndUpdate()
        {
            if (this.InUpadte > 0)
            {
                this.InUpadte = this.InUpadte - 1;

                if (this.InUpadte == 0)
                {
                    foreach (ColumnHeader objColumnHeader in this.Columns)
                    {
                        objColumnHeader.Width = objColumnHeader.InternalWidth;
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal void ClearPaging()
        {
            this.CurrentPageInternal = 1;
            this.TotalPagesInternal = 1;
        }

        /// <summary>
        /// Sort the list view by this column
        /// </summary>
        /// <param name="objColumn"></param>
        internal void SortBy(ColumnHeader objColumn)
        {
            foreach (ColumnHeader objColumnHeader in Columns)
            {
                if (objColumnHeader == objColumn)
                {
                    if (objColumnHeader.SortOrder == SortOrder.Ascending)
                    {
                        objColumnHeader.SortOrder = SortOrder.Descending;
                    }
                    else
                    {
                        objColumnHeader.SortOrder = SortOrder.Ascending;
                    }

                    objColumnHeader.SortPosition = 0;
                }
                else
                {
                    objColumnHeader.SortOrder = SortOrder.None;
                    objColumnHeader.SortPosition = 1000;
                }
            }

            if (ColumnClick != null)
            {
                OnColumnClick(new ColumnClickEventArgs(objColumn.Index));
            }
            else
            {
                Sort();
            }
        }

        /// <summary>
        /// Sorts this list items.
        /// </summary>
        public virtual void Sort()
        {
            this.Items.Sort();
        }

        /// <summary>
        ///
        /// </summary>
        internal void FireGroup()
        {
            ApplyGrouping();
        }

        /// <summary>
        /// Apply grouping
        /// </summary>
        protected virtual void ApplyGrouping()
        {

        }

        /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</summary>
        /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
        /// <param name="strText">The text to search for.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string strText)
        {
            if (this.Items.Count == 0)
            {
                return null;
            }
            return this.FindItemWithText(strText, true, 0, true);
        }

        /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
        /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
        /// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
        /// <param name="intStartIndex">The index of the item at which to start the search.</param>
        /// <param name="strText">The text to search for.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string strText, bool blnIncludeSubItemsInSearch, int intStartIndex)
        {
            return this.FindItemWithText(strText, blnIncludeSubItemsInSearch, intStartIndex, true);
        }

        /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
        /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
        /// <param name="blnIsPrefixSearch">true to return match the text to the text prefix of an item; otherwise, false. </param>
        /// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
        /// <param name="intStartIndex">The index of the item at which to start the search.</param>
        /// <param name="strText">The text to search for.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string strText, bool blnIncludeSubItemsInSearch, int intStartIndex, bool blnIsPrefixSearch)
        {
            if ((intStartIndex < 0) || (intStartIndex >= this.Items.Count))
            {
                throw new ArgumentOutOfRangeException("startIndex", SR.GetString("InvalidArgument", new object[] { "startIndex", intStartIndex.ToString(CultureInfo.CurrentCulture) }));
            }
            return this.FindItem(true, strText, blnIsPrefixSearch, new Point(0, 0), SearchDirectionHint.Down, intStartIndex, blnIncludeSubItemsInSearch);
        }

        /// <summary>
        /// Finds the item.
        /// </summary>
        /// <param name="blnIsTextSearch">if set to <c>true</c> is text search.</param>
        /// <param name="strText">The text to search for.</param>
        /// <param name="blnIsPrefixSearch">if set to <c>true</c> return match the text to the text prefix of an item.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmSearchDirectionHint">The enm search direction hint.</param>
        /// <param name="intStartIndex">The index of the item at which to start the search.</param>
        /// <param name="blnIncludeSubItemsInSearch">if set to <c>true</c> include subitems in the search.</param>
        /// <returns></returns>
        private ListViewItem FindItem(bool blnIsTextSearch, string strText, bool blnIsPrefixSearch, Point objPoint, SearchDirectionHint enmSearchDirectionHint, int intStartIndex, bool blnIncludeSubItemsInSearch)
        {
            //If the list view has items
            if (this.Items.Count != 0)
            {
                int intSubItemsCount = 0;

                if (!base.IsHandleCreated)
                {
                    return null;
                }

                //Text search
                if (blnIsTextSearch)
                {
                    //Run over all of the list view items
                    for (int i = intStartIndex; i < this.Items.Count; i++)
                    {
                        ListViewItem objListViewItem = this.Items[i];

                        //If we want to search the sub items
                        if (blnIncludeSubItemsInSearch)
                        {
                            //Get the sub items count
                            intSubItemsCount = objListViewItem.SubItems.Count;
                        }
                        else
                        {
                            //The sub items count is 1 - means that we will search only the first column(ListView items)
                            intSubItemsCount = 1;
                        }

                        //Search the sub items count
                        for (int j = 0; j < intSubItemsCount; j++)
                        {
                            //Get the selected cell(sub item)
                            ListViewItem.ListViewSubItem objListViewSubItem = objListViewItem.SubItems[j];

                            //Check for text equality (ListView sub item text and strText)
                            if (string.Equals(strText, objListViewSubItem.Text, StringComparison.OrdinalIgnoreCase))
                            {
                                return objListViewItem;
                            }

                            //Check if strText contained in the ListView sub item text.
                            if (blnIsPrefixSearch && CultureInfo.CurrentCulture.CompareInfo.IsPrefix(objListViewSubItem.Text, strText, CompareOptions.IgnoreCase))
                            {
                                return objListViewItem;
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
        /// <param name="intColumnIndex">The zero-based index of the column to resize.</param>
        /// <param name="enmHeaderAutoResize">One of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> values.</param>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">headerAutoResize is not a member of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> enumeration.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is greater than 0 when <see cref="P:Gizmox.WebGUI.Forms.ListView.Columns"></see> is null-or-columnIndex is less than 0 or greater than the number of columns set.</exception>
        public void AutoResizeColumn(int intColumnIndex, ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
        {
            this.SetColumnWidth(intColumnIndex, enmHeaderAutoResize);
        }

        internal int GetColumnFixedWidth(int intColumnIndex, int intInternalWidth, bool blnIsAutoResizeStyle)
        {
            // Variables declerations.
            int intFixedWidth = 0;
            string strMaximalText = string.Empty;
            int intMaximalColumnContentWidth = 1;
            int intColumnHeaderContentWidth = 1;
            ColumnHeader objColumnHeader = null;
            bool blnCalculateMaximalColumnContentWidth = false;
            bool blnCalculateColumnHeaderContentWidth = false;


            ColumnHeaderCollection objColumns = this.Columns;

            // Checks that the received column index is valid.
            if (((intColumnIndex < 0) || ((intColumnIndex >= 0) && (objColumns == null))) || (intColumnIndex >= objColumns.Count))
            {
                throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", new object[] { "columnIndex", intColumnIndex.ToString(CultureInfo.CurrentCulture) }));
            }

            // Get ythe indexed column header.
            objColumnHeader = objColumns[intColumnIndex];

            if (objColumnHeader != null && objColumnHeader.Type != ListViewColumnType.Icon)
            {
                // Initialize calculations mode.
                if (blnIsAutoResizeStyle)
                {
                    blnCalculateColumnHeaderContentWidth = ((ColumnHeaderAutoResizeStyle)intInternalWidth == ColumnHeaderAutoResizeStyle.HeaderSize);

                    blnCalculateMaximalColumnContentWidth = blnCalculateColumnHeaderContentWidth || ((ColumnHeaderAutoResizeStyle)intInternalWidth == ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else if (intInternalWidth < 0)
                {
                    blnCalculateMaximalColumnContentWidth = true;
                    blnCalculateColumnHeaderContentWidth = (intInternalWidth == -2);
                }

                // Calculate maximal column content size.
                if (blnCalculateMaximalColumnContentWidth)
                {
                    foreach (ListViewItem objItem in this.Items)
                    {
                        // Get sub item
                        ListViewItem.ListViewSubItem objSubItem = objItem.SubItems[objColumnHeader.Index];

                        if (objSubItem != null &&
                            objSubItem.Text != null)
                        {
                            // Get sub item text
                            string strText = objSubItem.Text;

                            // Measure text width
                            int intTextWidth = CommonUtils.GetStringMeasurements(strText, objSubItem.Font).Width;

                            // Check if sub item text width is bigger then maximal
                            if (intTextWidth > intMaximalColumnContentWidth)
                            {
                                intMaximalColumnContentWidth = intTextWidth;
                            }
                        }
                    }
                }

                // Calculate column's header content size.
                if (blnCalculateColumnHeaderContentWidth)
                {
                    intColumnHeaderContentWidth = CommonUtils.GetStringMeasurements(objColumnHeader.Text, this.Font).Width;
                }

                // Set the fixed width as for calculations mode.
                if (blnCalculateColumnHeaderContentWidth &&
                    blnCalculateMaximalColumnContentWidth)
                {
                    intFixedWidth = Math.Max(intColumnHeaderContentWidth, intMaximalColumnContentWidth);
                }
                else if (!blnCalculateColumnHeaderContentWidth &&
                        blnCalculateMaximalColumnContentWidth)
                {
                    intFixedWidth = intMaximalColumnContentWidth;
                }
                else if (blnCalculateColumnHeaderContentWidth &&
                        !blnCalculateMaximalColumnContentWidth)
                {
                    intFixedWidth = intColumnHeaderContentWidth;
                }
            }

            return intFixedWidth;
        }

        internal void SetColumnWidth(int intColumnIndex, ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
        {
            ColumnHeader objColumnHeader = null;
            ColumnHeaderCollection objColumns = this.Columns;

            if (((intColumnIndex < 0) || ((intColumnIndex >= 0) && (objColumns == null))) || (intColumnIndex >= objColumns.Count))
            {
                throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", new object[] { "columnIndex", intColumnIndex.ToString(CultureInfo.CurrentCulture) }));
            }

            objColumnHeader = this.Columns[intColumnIndex];

            if (objColumnHeader != null && objColumnHeader.Type != ListViewColumnType.Icon)
            {
                objColumnHeader.Width = GetColumnFixedWidth(intColumnIndex, (int)enmHeaderAutoResize, true);
            }
        }

        /// <summary>
        /// Gets the current item display index
        /// </summary>
        /// <param name="objListViewItem"></param>
        /// <returns></returns>
        internal int GetDisplayIndex(ListViewItem objListViewItem)
        {
            ListViewItemCollection objItems = this.Items;

            if (objItems != null)
            {
                return objItems.IndexOf(objListViewItem);
            }
            return -1;
        }

        #endregion General


        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            if (objValue is ColumnHeader)
            {
                this.Columns.Add((ColumnHeader)objValue);
            }
            else if (objValue is ListViewItem)
            {
                this.Items.Add((ListViewItem)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ColumnClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
        protected virtual void OnColumnClick(ColumnClickEventArgs e)
        {
            if (this.ColumnClick != null)
            {
                this.ColumnClick(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.AfterLabelEdit"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data.</param>
        protected virtual void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            // Raise event if needed
            LabelEditEventHandler objEventHandler = this.AfterLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.BeforeLabelEdit"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeLabelEdit(LabelEditEventArgs e)
        {
            // Raise event if needed
            LabelEditEventHandler objEventHandler = this.BeforeLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AfterLabelEditInternal"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs"/> instance containing the event data.</param>
        internal void OnAfterLabelEditInternal(LabelEditEventArgs e)
        {
            OnAfterLabelEdit(e);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new ListViewWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.ListViewShowGridLinesOnEmptyRows)
            {
                //Update
                this.Update();
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }


        #endregion Methods

        #region Default Member Values


        /// <summary>
        /// Gets the default row back color
        /// </summary>
        internal Color DefaultRowBackColor
        {
            get
            {
                return ((ListViewSkin)this.Skin).RowBackColor;
            }
        }

        /// <summary>
        /// Gets the default row back color
        /// </summary>
        internal Color DefaultRowForeColor
        {
            get
            {
                return ((ListViewSkin)this.Skin).RowForeColor;
            }
        }

        /// <summary>
        /// Gets the default row font.
        /// </summary>
        /// <value>The default row font.</value>
        internal Font DefaultRowFont
        {
            get
            {
                return ((ListViewSkin)this.Skin).RowFont;
            }
        }

        #endregion Default Member Values

        #region Data Binding

        #region Data Binding Members

        /// <summary>
        /// The column headers resizing mide
        /// </summary>
        private static readonly SerializableProperty HeaderAutoResizeStyleProperty = SerializableProperty.Register("HeaderAutoResizeStyle", typeof(ColumnHeaderAutoResizeStyle), typeof(ListView), new SerializablePropertyMetadata(ColumnHeaderAutoResizeStyle.None));

        #endregion

        #region Data Binding Properties

        /// <summary>
        /// Gets or sets if auto column generation is active when using data binding
        /// </summary>
        [Obsolete("Please use the 'AutoGenerateColumns' property instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoColumnGeneration
        {
            get
            {
                return this.AutoGenerateColumns;
            }
            set
            {
                this.AutoGenerateColumns = value;
            }
        }

        /// <summary>
        /// Gets or sets if auto column generation is active when using data binding
        /// </summary>
        [Browsable(true),DefaultValue(true)]
        [SRCategory("CatData")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool AutoGenerateColumns
        {
            get
            {
                return this.GetValue<bool>(ListView.AutoGenerateColumnsProperty);
            }
            set
            {
                if (this.SetValue<bool>(ListView.AutoGenerateColumnsProperty, value))
                {
                    this.Bind();
                }
            }
        }

        /// <summary>
        /// Gets or sets if column auto resizing mode
        /// </summary>
        [DefaultValue(ColumnHeaderAutoResizeStyle.None)]
        [SRCategory("CatData")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ColumnHeaderAutoResizeStyle ColumnResizeStyle
        {
            get
            {
                return this.GetValue<ColumnHeaderAutoResizeStyle>(ListView.HeaderAutoResizeStyleProperty);
            }
            set
            {
                // If value is diffrent
                if (this.SetValue<ColumnHeaderAutoResizeStyle>(ListView.HeaderAutoResizeStyleProperty, value))
                {
                    // Auto resize columns
                    OnAutoResizeColumns();
                }
            }
        }

        /// <summary>
        /// The listview data source
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
        [SRCategory("CatData")]
        [DefaultValue((string)null)]
        public object DataSource
        {
            get
            {
                return this.GetValue<object>(ListView.DataSourceProperty, null);
            }
            set
            {
                if (this.SetValue<object>(ListView.DataSourceProperty, value))
                {
                    this.OnDataSourceChanged(EventArgs.Empty);
                    Bind();
                }
            }
        }

        /// <summary>
        /// The listview data memeber
        /// </summary>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue("")]
#else
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue("")]
#endif
        [SRCategory("CatData")]
        public string DataMember
        {
            get
            {
                return this.GetValue<string>(ListView.DataMemberProperty);
            }
            set
            {
                if (this.SetValue<string>(ListView.DataMemberProperty, value))
                {
                    this.OnDataMemberChanged(EventArgs.Empty);
                    Bind();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this listview is binded.
        /// </summary>
        /// <value><c>true</c> if this listview is binded; otherwise, <c>false</c>.</value>
        private bool IsBinded
        {
            get
            {
                return this.DataSource != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [data source has bindings].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [data source has bindings]; otherwise, <c>false</c>.
        /// </value>
        private bool DataSourceHasBindings
        {
            get
            {
                // Try casting the local data source to a binding source.
                BindingSource objBindingSource = this.DataSource as BindingSource;

                if (objBindingSource != null && objBindingSource.CurrencyManager != null)
                {
                    return objBindingSource.CurrencyManager.BindingsCount > 0;
                }

                return false;
            }
        }

        #endregion

        #region Data Binding Methods

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BindingContextChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnBindingContextChanged(EventArgs e)
        {
            if (this.IsBinded)
            {
                this.Bind();
            }
        }

        private void Bind()
        {
            this.Bind(null);
        }

        private bool ShoudRegenerateColumns(ListChangedEventArgs objBindArgs)
        {
            if (objBindArgs != null)
            {
                return objBindArgs.ListChangedType == ListChangedType.Reset;
            }
            return true;
        }

        private bool ShouldRegenerateItems(ListChangedEventArgs objBindArgs)
        {
            if (objBindArgs != null)
            {
                return objBindArgs.ListChangedType == ListChangedType.Reset;
            }
            return true;
        }

        /// <summary>
        /// Gets the property descriptor.
        /// </summary>
        /// <param name="strPropertyName">Name of the property.</param>
        /// <returns></returns>
        private PropertyDescriptor GetPropertyDescriptor(string strPropertyName)
        {
            PropertyDescriptor objPropertyDescriptor = null;

            // Validate property name.
            if (!string.IsNullOrEmpty(strPropertyName))
            {
                object objDataSource = this.DataSource;
                if (objDataSource != null)
                {
                    // Gets the data source list.
                    IList objList = GetDataSourceList(objDataSource);

                    // If is a valid list
                    if (objList != null && !(objList is DataViewManager))
                    {
                        // Get properties collection.
                        PropertyDescriptorCollection objProperties = ListBindingHelper.GetListItemProperties(objList);
                        if (objProperties != null)
                        {
                            // Get requeted property by name.
                            objPropertyDescriptor = objProperties[strPropertyName];
                        }
                    }
                }
            }

            return objPropertyDescriptor;
        }

        /// <summary>
        /// Bind listview to data
        /// </summary>        
        private void Bind(ListChangedEventArgs objBindArgs)
        {
            if (this.BindingContext != null)
            {
                // 
                bool blnRegenerateColumns = ShoudRegenerateColumns(objBindArgs);

                //
                bool blnRegenerateItems = ShouldRegenerateItems(objBindArgs);

                // Clear current list context
                if (this.AutoGenerateColumns && blnRegenerateColumns)
                {
                    // If in design mode unregister columns
                    if (this.DesignMode)
                    {
                        // Loop all columns and unregister them
                        foreach (ColumnHeader objColumnHeader in this.Columns)
                        {
                            UnregisterInDesignMode(objColumnHeader);
                        }
                    }

                    // Clear columns
                    this.Columns.Clear();
                }

                if (blnRegenerateItems)
                {
                    // Clear items
                    this.Items.Clear();


                    // Clear original sorting array
                    this.mobjOriginalItemSorting.Clear();
                }

                // Get data source.
                object objDataSource = this.DataSource;
                if (objDataSource != null)
                {
                    // Gets the data source list.
                    IList objList = GetDataSourceList(objDataSource);

                    // If not change in binding
                    if (objBindArgs == null)
                    {
                        this.OnUnWireCurrencyEvents();
                        this.OnWireCurrencyEvents();
                    }

                    // If is a valid list
                    if (objList != null && !(objList is DataViewManager))
                    {
                        // Get properties from list
                        PropertyDescriptorCollection objProperties = ListBindingHelper.GetListItemProperties(objList);
                        if (objProperties != null)
                        {
                            // Loop all properties
                            foreach (PropertyDescriptor objProperty in objProperties)
                            {
                                // If auto generation of columns is required
                                if (this.AutoGenerateColumns && blnRegenerateColumns)
                                {
                                    // Get column 
                                    ColumnHeader objColumn = OnGetColumn(objProperty);
                                    if (objColumn != null)
                                    {
                                        // Set column mapping
                                        objColumn.Tag = objProperty.Name;

                                        // Register column if needed
                                        this.RegisterInDesignMode(objColumn, objProperty.Name);

                                        // Add column
                                        this.Columns.Add(objColumn);
                                    }
                                }
                            }

                            // If items regeneration is required
                            if (blnRegenerateItems)
                            {
                                // Loop all rows in list
                                for (int intItemIndex = 0; intItemIndex < objList.Count; intItemIndex++)
                                {
                                    // Get current item as for index.
                                    object objItem = objList[intItemIndex];
                                    if (objItem != null)
                                    {
                                        CreateOrUpdateBindableItem(objItem, intItemIndex, null);
                                    }
                                }

                                // Resize columns
                                OnAutoResizeColumns();
                            }
                            else
                            {
                                if (objBindArgs != null)
                                {
                                    switch (objBindArgs.ListChangedType)
                                    {
                                        case ListChangedType.ItemAdded:
                                            CreateOrUpdateBindableItem(objList[objBindArgs.NewIndex], objBindArgs.NewIndex, null);
                                            break;
                                        case ListChangedType.ItemDeleted:
                                            this.Items.RemoveAt(objBindArgs.NewIndex);
                                            break;
                                        case ListChangedType.ItemChanged:
                                            // Get mapped bindable item.
                                            object objBindableItem = objList[objBindArgs.NewIndex];
                                            if (objBindableItem != null)
                                            {
                                                // Get mapped list view item.
                                                ListViewItem objListViewItem = this.Items[objBindArgs.NewIndex];
                                                if (objListViewItem != null)
                                                {
                                                    if (!int.Equals(objListViewItem.DataItemIndex, objBindArgs.NewIndex))
                                                    {
                                                        objListViewItem = this.GetListViewItemByBindableItemIndex(objBindArgs.NewIndex);
                                                    }
                                                }

                                                if (objListViewItem != null)
                                                {
                                                    // Create a bindable item.
                                                    CreateOrUpdateBindableItem(objBindableItem, objBindArgs.NewIndex, objListViewItem);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }

                            CurrencyManager objCurrencyManager = this.CurrencyManagerInternal;

                            if (objCurrencyManager != null)
                            {
                                if (this.SelectedIndex != objCurrencyManager.Position)
                                {
                                    this.SelectedIndex = objCurrencyManager.Position;
                                    if (this.SelectedItem != null)
                                    {
                                        this.SelectedItem.EnsureVisible();
                                    }
                                }
                            }
                        }
                        this.OnDataBindingComplete(ListChangedType.Reset);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the data source list.
        /// </summary>
        /// <param name="objDataSource">The data source.</param>
        /// <returns></returns>
        private IList GetDataSourceList(object objDataSource)
        {
            IList objList = null;

            // Try to get list
            if (this.DataMember == null)
            {
                // Get list from datasource
                objList = ListBindingHelper.GetList(objDataSource) as IList;
            }
            else
            {
                // Get list from datasource and datamember
                objList = ListBindingHelper.GetList(objDataSource, this.DataMember) as IList;
            }
            return objList;
        }

        /// <summary>
        /// Get the matched list view item by bindable item
        /// </summary>
        /// <param name="intBindableItemIndex">Index of the int bindable item.</param>
        /// <returns></returns>
        private ListViewItem GetListViewItemByBindableItemIndex(int intBindableItemIndex)
        {
            ListViewItem objBindedListViewItem = null;

            // Loop all listview items.
            foreach (ListViewItem objListViewItem in this.Items)
            {
                // Check if current listview item matched the recieved bindable item index.
                if (int.Equals(objListViewItem.DataItemIndex, intBindableItemIndex))
                {
                    // Get a refference to current list view item.
                    objBindedListViewItem = objListViewItem;

                    // Break loop.
                    break;
                }
            }

            return objBindedListViewItem;
        }

        private void CreateOrUpdateBindableItem(object objItem, int intItemIndex, ListViewItem objExistingListViewItem)
        {
            int intPosition = 0;

            ListViewItem objListViewItem = objExistingListViewItem;

            // Loop all coluns
            foreach (ColumnHeader objColumnHeader in this.Columns)
            {
                PropertyDescriptor objProperty = null;

                if (objColumnHeader.Tag != null)
                {
                    // Get new property
                    objProperty = this.GetPropertyDescriptor(Convert.ToString(objColumnHeader.Tag));
                }

                // The current value
                string strValue = "";

                // If property found
                if (objProperty != null)
                {
                    strValue = OnGetCellValue(objItem, objProperty);
                }

                // If not created listviewitem for row
                if (intPosition == 0)
                {
                    if (objListViewItem == null)
                    {
                        // Create listvieitem
                        objListViewItem = this.Items.Add(strValue);

                        // Store row index for sorting
                        objListViewItem.DataItemIndex = intItemIndex;

                        // Add current item
                        this.mobjOriginalItemSorting.Add(objListViewItem);
                    }
                    else
                    {
                        objListViewItem.Text = strValue;
                    }

                }
                else
                {
                    if (objExistingListViewItem == null)
                    {
                        // Add sub item
                        objListViewItem.SubItems.Add(strValue);
                    }
                    else
                    {
                        if (objListViewItem.SubItems.Count > intPosition)
                        {
                            objListViewItem.SubItems[intPosition].Text = strValue;
                        }
                    }
                }

                intPosition++;
            }

            // Enable row formating.
            this.OnRowFormating(objItem, objListViewItem);

            // Enable item binding.
            this.OnItemBinding(new ListViewItemBindingEventArgs(objItem, objListViewItem));
        }


        /// <summary>
        /// Called when [row formating].
        /// </summary>
        /// <param name="objRow">The row.</param>
        /// <param name="objListViewItem">The list view item.</param>
        protected virtual void OnRowFormating(object objRow, ListViewItem objListViewItem)
        {

        }

        /// <summary>
        /// Do column resizing
        /// </summary>
        private void OnAutoResizeColumns()
        {
            if (this.IsBinded)
            {
                // If auto column sizing is required
                if (this.ColumnResizeStyle != ColumnHeaderAutoResizeStyle.None)
                {
                    // Loop all columns
                    for (int intIndex = 0; intIndex < this.Columns.Count; intIndex++)
                    {
                        // Resize column
                        this.AutoResizeColumn(intIndex, this.ColumnResizeStyle);
                    }
                }
            }
        }

        /// <summary>
        /// Unwire currency manager event
        /// </summary>
        private void OnUnWireCurrencyEvents()
        {
            CurrencyManager objCurrencyManager = this.CurrencyManagerInternal;
            if (objCurrencyManager != null)
            {
                objCurrencyManager.PositionChanged -= new EventHandler(this.OnCurrencyManagerPositionChanged);
                objCurrencyManager.ListChanged -= new ListChangedEventHandler(this.OnCurrencyManagerListChanged);
            }
        }

        /// <summary>
        /// Wire currency manager events
        /// </summary>
        private void OnWireCurrencyEvents()
        {
            CurrencyManager objCurrencyManager = this.CurrencyManagerInternal;
            if (objCurrencyManager != null)
            {
                objCurrencyManager.PositionChanged += new EventHandler(this.OnCurrencyManagerPositionChanged);
                objCurrencyManager.ListChanged += new ListChangedEventHandler(this.OnCurrencyManagerListChanged);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCurrencyManagerPositionChanged(object sender, EventArgs e)
        {
            CurrencyManager objCurrencyManager = this.CurrencyManagerInternal;

            // If valid position
            if (objCurrencyManager.Position < mobjOriginalItemSorting.Count)
            {
                // If valid position.
                // When the CurrencyManagerInternal Position property gets a position of -1(Set by the programmer) 
                // it(the Currency Manager) replace it with 0
                // So we check if the mobjOriginalItemSorting position > -1 also.
                if (objCurrencyManager.Position > -1 && objCurrencyManager.Position < mobjOriginalItemSorting.Count
                    && mobjOriginalItemSorting.IndexOf(this.SelectedItem) > -1)
                {
                    // Get position listviewitem
                    ListViewItem objItem = mobjOriginalItemSorting[objCurrencyManager.Position] as ListViewItem;

                    // If selected index needs to be updated
                    if (this.SelectedItem != objItem)
                    {
                        // Update selected item and list
                        this.SelectedItem = objItem;
                        this.Update();
                    }
                }
                else
                {
                    // Clear selection
                    this.SelectedIndex = -1;
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Handle list change events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCurrencyManagerListChanged(object sender, ListChangedEventArgs e)
        {
            this.Bind(e);
        }

        /// <summary>
        /// Get column from property
        /// </summary>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        protected virtual ColumnHeader OnGetColumn(PropertyDescriptor objProperty)
        {
            bool blnCreateColumn = false;

            TypeConverter objConverter = objProperty.Converter;
            if (objConverter != null)
            {
                if (objConverter.CanConvertTo(typeof(string)))
                {
                    blnCreateColumn = true;
                }
            }

            // If should create column
            if (blnCreateColumn)
            {
                return OnCreateColumn(objProperty);
            }

            return null;

        }

        /// <summary>
        /// Creates the column
        /// </summary>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        protected virtual ColumnHeader OnCreateColumn(PropertyDescriptor objProperty)
        {
            ColumnHeader objColumn = new ColumnHeader();
            objColumn.Label = objProperty.DisplayName;
            objColumn.Width = 100;
            return objColumn;
        }

        /// <summary>
        /// Register column header in design mode
        /// </summary>
        /// <param name="objColumn"></param>
        /// <param name="strName"></param>
        private void RegisterInDesignMode(ColumnHeader objColumn, string strName)
        {
            if (this.DesignMode)
            {
                if (this.Site != null && this.Site.Container != null)
                {
                    if (objColumn.Site == null)
                    {
                        this.Site.Container.Add(objColumn, GetSafeName(strName, this.Site.Container));
                    }
                }
            }
        }

        /// <summary>
        /// Get safe name for column header
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objContainer"></param>
        /// <returns></returns>
        private string GetSafeName(string strName, IContainer objContainer)
        {
            Regex objRegex = new Regex("[^a-zA-Z0-9]", RegexOptions.CultureInvariant);
            string strSafeName = "column" + objRegex.Replace(strName, "_");
            if (objContainer.Components[strSafeName] == null)
            {
                return strSafeName;
            }
            int intIndex = 1;
            while (objContainer.Components[strSafeName + intIndex.ToString()] != null)
            {
                intIndex++;
            }
            return strSafeName + intIndex.ToString();
        }

        /// <summary>
        /// Unregister column header in design mode
        /// </summary>
        /// <param name="objColumn"></param>
        private void UnregisterInDesignMode(ColumnHeader objColumn)
        {
            if (this.DesignMode)
            {
                if (this.Site != null && this.Site.Container != null)
                {
                    if (objColumn.Site != null)
                    {
                        this.Site.Container.Remove(objColumn);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the row item value
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        protected virtual object OnGetCellValueAsObject(object objRow, PropertyDescriptor objProperty)
        {
            if (objProperty != null && objRow != null)
            {
                return objProperty.GetValue(objRow);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the row item value
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="objProperty"></param>
        /// <returns></returns>
        protected virtual string OnGetCellValue(object objRow, PropertyDescriptor objProperty)
        {
            object objValue = OnGetCellValueAsObject(objRow, objProperty);
            string strValue = "";
            if (objValue != null)
            {
                TypeConverter objConverter = objProperty.Converter;
                if (objConverter != null)
                {
                    strValue = (string)objProperty.Converter.ConvertTo(objValue, typeof(string));
                }
                else
                {
                    strValue = objValue.ToString();
                }
            }

            return strValue;
        }

        /// <summary>
        /// Called when [data binding complete].
        /// </summary>
        /// <param name="enmListChangedType">Type of the list changed.</param>
        internal void OnDataBindingComplete(ListChangedType enmListChangedType)
        {
            this.OnDataBindingComplete(new ListViewBindingCompleteEventArgs(enmListChangedType));
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
        protected virtual void OnDataBindingComplete(ListViewBindingCompleteEventArgs e)
        {
            // Get Handler
            ListViewBindingCompleteEventHandler objEventHandler = this.DataBindingComplete;

            // Raise event if needed
            if (objEventHandler != null && !base.IsDisposed)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataMemberChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDataMemberChanged(EventArgs e)
        {
            // Get Handler
            EventHandler objEventHandler = this.DataMemberChanged;

            // Raise event if needed
            if (objEventHandler != null && !base.IsDisposed)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataSourceChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            // Get Handler
            EventHandler objEventHandler = this.DataSourceChanged;

            // Raise event if needed
            if (objEventHandler != null && !base.IsDisposed)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        #endregion

        #region IComparer Members

        /// <summary>
        /// Compares two ListView Items
        /// </summary>
        /// <param name="objObjectA">object A.</param>
        /// <param name="objObjectB">object B.</param>
        /// <returns></returns>
        int IComparer.Compare(object objObjectA, object objObjectB)
        {
            // Get list view items
            ListViewItem objItemA = objObjectA as ListViewItem;
            ListViewItem objItemB = objObjectB as ListViewItem;

            // Get sorting columns.
            ICollection objSortingColumns = this.SortingColumns;

            // Validate items, properties ad columns
            if (objItemA != null && objItemB != null)
            {
                // Get rows indexes.
                int intRowAIndex = objItemA.DataItemIndex;
                int intRowBIndex = objItemB.DataItemIndex;

                // Validate rows indexes.
                if (intRowAIndex >= 0 && intRowBIndex >= 0)
                {
                    // Get data source.
                    object objDataSource = this.DataSource;
                    if (objDataSource != null)
                    {
                        // Gets the data source list.
                        IList objList = GetDataSourceList(objDataSource);
                        if (objList != null)
                        {
                            // Get rows.
                            object objRowA = objList[intRowAIndex];
                            object objRowB = objList[intRowBIndex];

                            // Check that there are columns
                            if (objSortingColumns.Count > 0)
                            {
                                // Loop all sorting columns
                                foreach (ColumnHeader objColumn in objSortingColumns)
                                {
                                    PropertyDescriptor objPropertyDescriptor = this.GetPropertyDescriptor(Convert.ToString(objColumn.Tag));
                                    if (objPropertyDescriptor != null)
                                    {
                                        object objValueA = OnGetCellValueAsObject(objRowA, objPropertyDescriptor);
                                        object objValueB = OnGetCellValueAsObject(objRowB, objPropertyDescriptor);

                                        // Check if values are not equals.
                                        if (!object.Equals(objValueA, objValueB))
                                        {
                                            if (objValueA != null && objValueB != null && objValueA != DBNull.Value && objValueB != DBNull.Value)
                                            {
                                                // Cast valueA to a compareable object.
                                                IComparable objComparerA = objValueA as IComparable;
                                                if (objComparerA != null)
                                                {
                                                    // Get comparison result.
                                                    int intResult = objComparerA.CompareTo(objValueB);
                                                    if (intResult != 0)
                                                    {
                                                        return intResult * (objColumn.SortOrder == SortOrder.Ascending ? 1 : -1);
                                                    }
                                                }
                                            }
                                            else if ((objValueA == null || objValueA == DBNull.Value) && objValueB != null && objValueB != DBNull.Value)
                                            {
                                                return -1;
                                            }
                                            else if (objValueA != null && objValueA != DBNull.Value && (objValueB == null || objValueB == DBNull.Value))
                                            {
                                                return 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        #endregion IComparer Members

        #endregion

        #region Optimized Serialization Implementation

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                int intSerializableDataInitialSize = base.SerializableDataInitialSize;

                // Add the columns array and the array length
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjColumns);

                // Add the items array and the array length
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjItems);

                // Add the original item sorting array and the array length
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjOriginalItemSorting);

                // Add the groups array and the array length
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjGroups);

                return intSerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the columns array
            mobjColumns = new ColumnHeaderCollection(this, objReader.ReadArray());

            // Read the items array
            mobjItems = new ListViewItemCollection(this, objReader.ReadArray());

            // Read the groups array
            mobjGroups = new ListViewGroupCollection(this, objReader.ReadArray());

            // Read the item sorting array
            mobjOriginalItemSorting = new List<ListViewItem>(objReader.ReadArray<ListViewItem>());
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the columns array
            objWriter.WriteArray(mobjColumns);

            // Write the items array
            objWriter.WriteArray(mobjItems);

            // Write the groups array
            objWriter.WriteArray(mobjGroups);

            // Write the original item sorting array
            objWriter.WriteArray(mobjOriginalItemSorting);
        }

        #endregion


        /// <summary>
        /// Gets the sub item rect.
        /// </summary>
        /// <param name="intItemIndex">Index of the int item.</param>
        /// <param name="intSubItemIndex">Index of the int sub item.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// intItemIndex
        /// or
        /// intSubItemIndex
        /// </exception>
        internal Rectangle GetSubItemRect(int intItemIndex, int intSubItemIndex)
        {
            if (this.View != View.Details)
            {
                return Rectangle.Empty;
            }
            if (intItemIndex < 0 || intItemIndex >= this.Items.Count)
            {
                throw new ArgumentOutOfRangeException("intItemIndex", Gizmox.WebGUI.Forms.SR.GetString("InvalidArgument", (object)"intItemIndex", (object)intItemIndex.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
            }
            else
            {
                int count = this.Items[intItemIndex].SubItems.Count;
                if (intSubItemIndex < 0 || intSubItemIndex >= count)
                {
                    throw new ArgumentOutOfRangeException("intSubItemIndex", Gizmox.WebGUI.Forms.SR.GetString("InvalidArgument", (object)"intSubItemIndex", (object)intSubItemIndex.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
                }
                else
                {
                    int intItemHeight = GetPreferdControlItemHeight();

                    int intLeft = 0;
                    int intTop = this.GetColumnHeaderHeight();

                    int intFirstItemWidth = this.Columns[0].Width;
                    if (this.CheckBoxes)
                    {
                        ListViewSkin objSkin = this.Skin as ListViewSkin;
                        intFirstItemWidth += (22 + objSkin.HeaderSeperatorWidth);
                    }

                    for (int i = 0; i < intSubItemIndex; i++)
                    {
                        intLeft += i == 0 ? intFirstItemWidth :  this.Columns[i].Width;
                        
                    }

                    for (int j = 0; j < intItemIndex; j++)
                    {
                        intTop += intItemHeight;
                    }
                    intTop = intTop - this.ScrollTop;
                    intLeft = intLeft - this.ScrollLeft;
                    
                    return Rectangle.FromLTRB(intLeft, intTop, intLeft +  (intSubItemIndex == 0 ? intFirstItemWidth : this.Columns[intSubItemIndex].Width), intTop + intItemHeight);
                }
            }
        }

        /// <summary>
        /// Gets the item rect.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
        public Rectangle GetItemRect(int index)
        {
            if (index < 0 || index >= this.Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", Gizmox.WebGUI.Forms.SR.GetString("InvalidArgument", (object)"index", (object)index.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
            }
            else
            {
                int intItemHeight = GetPreferdControlItemHeight();

                int intLeft = 0;
                int intWidth = 0;
                int intTop = this.GetColumnHeaderHeight();

                for (int i = 0; i < this.Columns.Count; i++)
                {
                    intWidth += this.Columns[i].Width;
                }

                for (int j = 0; j < index; j++)
                {
                    intTop += intItemHeight;
                }
                intTop = intTop - this.ScrollTop;
                intLeft = intLeft - this.ScrollLeft;

                return Rectangle.FromLTRB(intLeft, intTop, intLeft + intWidth, intTop + intItemHeight);
            }
        }
    }

    #endregion ListView Class

    #region ListViewItem Class

    /// <summary>
    /// Implementation of ListViewItem class.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignTimeVisible(false), System.ComponentModel.TypeConverter(typeof(ListViewItemConverter))]
    [System.ComponentModel.ToolboxItem(false)]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ListViewItem : Component
    {

        #region Classes

        #region ListViewSubItem

        /// <summary>
        /// Represents a subitem of a ListViewItem .
        /// </summary>
#if WG_NET46
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
        [System.ComponentModel.DesignTimeVisible(false), System.ComponentModel.TypeConverter(typeof(ListViewSubItemConverter))]
        [Serializable()]
        public class ListViewSubItem
        {
            #region Class Members

            /// <summary>
            /// The subitem style
            /// </summary>
            private SubItemStyle mobjStyle = null;


            /// <summary>
            /// The sub item listviewitem owner
            /// </summary>
            private ListViewItem mobjListViewItem = null;

            /// <summary>
            /// Name property
            /// </summary>
            private string mstrName = string.Empty;

            /// <summary>
            /// 
            /// </summary>
            private object mobjUserData = null;


            /// <summary>
            /// Gets or sets the text internal.
            /// </summary>
            /// <value>The text internal.</value>
            internal string mstrText = string.Empty;

            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ListViewSubItem"/> instance.
            /// </summary>
            public ListViewSubItem()
            {
            }

            /// <summary>
            /// Creates a new <see cref="ListViewSubItem"/> instance.
            /// </summary>
            /// <param name="objListViewItem">The owner list view item.</param>
            protected ListViewSubItem(ListViewItem objListViewItem)
            {
                mobjListViewItem = objListViewItem;
            }

            /// <summary>
            /// Creates a new <see cref="ListViewSubItem"/> instance.
            /// </summary>
            /// <param name="objListViewItem">The owner list view.</param>
            /// <param name="strText">The sub item text.</param>
            public ListViewSubItem(ListViewItem objListViewItem, string strText)
            {
                // Set local variables
                mobjListViewItem = objListViewItem;
                mstrText = strText;
            }

            /// <summary>
            /// Creates a new <see cref="ListViewSubItem"/> instance.
            /// </summary>
            /// <param name="objListViewItem">The owner list view.</param>
            /// <param name="strText">The sub item text.</param>
            /// <param name="objForeColor">The sub item fore color.</param>
            /// <param name="objBackColor">The sub item back color.</param>
            /// <param name="objFont">The sub item font.</param>
            public ListViewSubItem(ListViewItem objListViewItem, string strText, Color objForeColor, Color objBackColor, Font objFont)
            {
                // Set local variables
                mobjListViewItem = objListViewItem;
                mstrText = strText;

                SubItemStyle objSubItemStyle = new SubItemStyle();
                objSubItemStyle.ForeColor = objForeColor;
                objSubItemStyle.BackColor = objBackColor;
                objSubItemStyle.Font = objFont;
                mobjStyle = objSubItemStyle;
            }

            #endregion C'Tor\D'Tor

            #region Methods

            /// <summary>
            /// Renders the style.
            /// </summary>
            /// <param name="objWriter">The obj writer.</param>
            /// <param name="strAttribute">The STR attribute.</param>
            /// <param name="objBackColor">Color of the obj back.</param>
            /// <param name="objForeColor">Color of the obj fore.</param>
            /// <param name="objFont">The obj font.</param>
            internal void RenderStyle(IResponseWriter objWriter, string strAttribute, Color objBackColor, Color objForeColor, Font objFont)
            {
                StringBuilder objStyle = new StringBuilder();

                if (objBackColor != this.DefaultBackColor)
                {
                    objStyle.AppendFormat("background-color:{0};", CommonUtils.GetHtmlColor(objBackColor));
                }

                if (objForeColor != this.DefaultForeColor)
                {
                    objStyle.AppendFormat("color:{0};", CommonUtils.GetHtmlColor(objForeColor));
                }

                Font objDefaultFont = this.ListViewItem.DefaultFont;
                if (objFont != null && !objFont.Equals(objDefaultFont))
                {
                    objStyle.AppendFormat("font:{0};", ClientUtils.GetWebFont(objFont));
                }

                if (objStyle.Length > 0)
                {
                    objWriter.WriteAttributeString(strAttribute, objStyle.ToString());
                }
            }

            /// <summary>
            /// Resets the Style.
            /// </summary>
            public void ResetStyle()
            {
                if (this.Style != null)
                {
                    this.Style = null;
                    if (this.ListViewItem != null)
                    {
                        this.ListViewItem.UpdateParams(AttributeType.Visual);
                    }
                }
            }

            /// <summary>
            /// Returns the sub item text value.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Text;
            }

            #endregion Methods

            #region Properties

            [Browsable(false)]
            public Rectangle Bounds
            {
                get
                {
                    if (this.mobjListViewItem != null && this.mobjListViewItem.ListView != null)
                    {
                        return this.mobjListViewItem.ListView.GetSubItemRect(this.mobjListViewItem.Index, this.mobjListViewItem.SubItems.IndexOf(this));
                    }
                    else
                    {
                        return Rectangle.Empty;
                    }
                }
            }

            /// <summary>
            /// Gets the default color of the back.
            /// </summary>
            /// <value>The default color of the back.</value>
            private Color DefaultBackColor
            {
                get
                {
                    ListViewItem objListViewItem = this.ListViewItem;
                    if (objListViewItem != null)
                    {
                        return objListViewItem.DefaultBackColor;
                    }
                    return (Color)SystemColors.Window;
                }
            }

            /// <summary>
            /// Gets the default color of the fore.
            /// </summary>
            /// <value>The default color of the fore.</value>
            private Color DefaultForeColor
            {
                get
                {
                    ListViewItem objListViewItem = this.ListViewItem;
                    if (objListViewItem != null)
                    {
                        return objListViewItem.DefaultForeColor;
                    }

                    return Color.Black;

                }
            }

            /// <summary>
            /// Gets or sets the color of the back.
            /// </summary>
            /// <value></value>
            public virtual Color BackColor
            {
                get
                {
                    if ((this.Style != null) && (this.Style.BackColor != Color.Empty))
                    {
                        return this.Style.BackColor;
                    }
                    if ((this.ListViewItem != null) && (this.ListViewItem.ListView != null) && (this.ListViewItem.ListView.HasBackColor || this.ListViewItem.ListView.HasProxyPropertyValue("BackColor")))
                    {
                        return this.ListViewItem.ListView.GetProxyPropertyValue<Color>("BackColor",  this.ListViewItem.ListView.BackColor);
                    }
                    return DefaultBackColor;
                }
                set
                {
                    if (this.Style == null)
                    {
                        this.Style = new SubItemStyle();
                    }
                    if (this.Style.BackColor != value)
                    {
                        this.Style.BackColor = value;
                        if (this.ListViewItem != null)
                        {
                            this.ListViewItem.UpdateParams(AttributeType.Visual);
                        }

                    }
                }
            }

            /// <summary>
            /// Gets or sets the font.
            /// </summary>
            /// <value></value>
            public virtual Font Font
            {
                get
                {
                    if ((this.Style != null) && (this.Style.Font != null))
                    {
                        return this.Style.Font;
                    }
                    if ((this.ListViewItem != null) && (this.ListViewItem.ListView != null))
                    {
                        return this.ListViewItem.ListView.GetProxyPropertyValue<Font>("Font", this.ListViewItem.ListView.Font);
                    }

                    if (this.ListViewItem != null)
                    {
                        return this.ListViewItem.DefaultFont;
                    }
                    return Control.DefaultFont;

                }
                set
                {
                    if (this.Style == null)
                    {
                        this.Style = new SubItemStyle();
                    }
                    if (this.Style.Font != value)
                    {
                        this.Style.Font = value;
                        if (this.ListViewItem != null)
                        {
                            this.ListViewItem.UpdateParams(AttributeType.Visual);
                        }

                    }
                }
            }

            /// <summary>
            /// Gets or sets the color of the fore.
            /// </summary>
            /// <value></value>
            public virtual Color ForeColor
            {
                get
                {
                    if ((this.Style != null) && (this.Style.ForeColor != Color.Empty))
                    {
                        return this.Style.ForeColor;
                    }
                    if ((this.ListViewItem != null) && (this.ListViewItem.ListView != null) && (this.ListViewItem.ListView.HasForeColor || this.ListViewItem.ListView.HasProxyPropertyValue("ForeColor")))
                    {
                        return this.ListViewItem.ListView.GetProxyPropertyValue<Color>("ForeColor", this.ListViewItem.ListView.ForeColor);
                    }
                    return DefaultForeColor;
                }
                set
                {
                    if (this.Style == null)
                    {
                        this.Style = new SubItemStyle();
                    }
                    if (this.Style.ForeColor != value)
                    {
                        this.Style.ForeColor = value;
                        if (this.ListViewItem != null)
                        {
                            this.ListViewItem.UpdateParams(AttributeType.Visual);
                        }

                    }
                }
            }


            /// <summary>
            /// Gets or sets the name associated with this control.  
            /// </summary>
            /// <value></value>
            [Localizable(true)]
            public string Name
            {
                get
                {
                    if (this.mstrName != null)
                    {
                        return this.mstrName;
                    }
                    return "";
                }
                set
                {
                    this.mstrName = value;

                }
            }

            /// <summary>
            /// Gets or sets the tag with this item.
            /// </summary>
            /// <value></value>
            [TypeConverter(typeof(StringConverter)), SRCategory("CatData"), Localizable(false), Bindable(true), DefaultValue((string)null), SRDescription("ControlTagDescr")]
            public object Tag
            {
                get
                {
                    return this.mobjUserData;
                }
                set
                {
                    this.mobjUserData = value;
                }
            }

            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value></value>
            public virtual string Text
            {
                get
                {
                    return this.mstrText;
                }
                set
                {
                    if (this.mstrText != value)
                    {
                        this.mstrText = value;
                        if (this.ListViewItem != null)
                        {
                            this.ListViewItem.UpdateParams(AttributeType.Visual);
                        }
                    }


                }
            }



            /// <summary>
            /// Gets or sets the list view.
            /// </summary>
            /// <value></value>
            internal ListViewItem ListViewItem
            {
                get
                {
                    return mobjListViewItem;
                }
                set
                {
                    mobjListViewItem = value;
                }
            }


            /// <summary>
            /// Gets or sets the Style.
            /// </summary>
            /// <value></value>
            internal SubItemStyle Style
            {
                get
                {
                    return mobjStyle;
                }
                set
                {
                    mobjStyle = value;

                }
            }

            #endregion Properties

            [Serializable]
            internal class SubItemStyle
            {
                /// <summary>
                /// The backcolor style of the sub item
                /// </summary>
                private Color mobjBackColor = Color.Empty;

                /// <summary>
                /// The font of the sub item
                /// </summary>
                private SerializableFont mobjFont = null;


                /// <summary>
                /// The forecolor style of the sub item
                /// </summary>
                private Color mobjForeColor = Color.Empty;

                /// <summary>
                /// Initializes a new instance of the <see cref="SubItemStyle"/> class.
                /// </summary>
                public SubItemStyle()
                {

                }

                /// <summary>
                /// Gets or sets the color of the back.
                /// </summary>
                /// <value></value>
                public Color BackColor
                {
                    get
                    {
                        return mobjBackColor;
                    }
                    set
                    {
                        mobjBackColor = value;
                    }
                }

                /// <summary>
                /// Gets or sets the font.
                /// </summary>
                /// <value></value>
                public Font Font
                {

                    get
                    {
                        return mobjFont;
                    }
                    set
                    {
                        mobjFont = (SerializableFont)value;
                    }
                }

                /// <summary>
                /// Gets or sets the color of the fore.
                /// </summary>
                /// <value></value>
                public Color ForeColor
                {
                    get
                    {
                        return mobjForeColor;
                    }
                    set
                    {
                        mobjForeColor = value;
                    }
                }
            }

        }

        #endregion ListViewSubItem

        #region ListViewSubItemCollection

        /// <summary>
        /// Represents a collection of ListViewSubItem objects stored in a ListViewItem .
        /// </summary>

#if WG_NET46
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
        [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
        [Serializable()]
        public class ListViewSubItemCollection : ICollection, IList
        {
            #region Class Members

            /// <summary>
            /// 
            /// </summary>
            private ListViewItem mobjListViewItem = null;

            /// <summary>
            /// 
            /// </summary>
            private ArrayList mobjSubItems = null;

            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ListViewSubItemCollection"/> instance.
            /// </summary>
            /// <param name="objListViewItem">Owner list view item.</param>
            public ListViewSubItemCollection(ListViewItem objListViewItem)
            {
                mobjListViewItem = objListViewItem;
                mobjSubItems = new ArrayList();
            }

            /// <summary>
            /// Creates a new <see cref="ListViewSubItemCollection"/> instance.
            /// </summary>
            /// <param name="objListViewItem">Owner list view item.</param>
            /// <param name="arrSubItems">The arr sub items.</param>
            internal ListViewSubItemCollection(ListViewItem objListViewItem, object[] arrSubItems)
            {
                mobjListViewItem = objListViewItem;
                mobjSubItems = new ArrayList(arrSubItems);
            }

            #endregion C'Tor\D'Tor

            #region Methods

            /// <summary>
            /// Adds the specified sub item.
            /// </summary>
            /// <param name="objSubItem">Sub item.</param>
            /// <returns></returns>
            public ListViewItem.ListViewSubItem Add(ListViewItem.ListViewSubItem objSubItem)
            {
                // Set the current list view item
                objSubItem.ListViewItem = mobjListViewItem;

                // Add the sub item to the collection of sub item
                mobjSubItems.Add(objSubItem);

                // Handle sub item added
                OnSubItemAdded(objSubItem);

                return objSubItem;
            }

            /// <summary>
            /// Handle sub item added
            /// </summary>
            /// <param name="objSubItem"></param>
            private void OnSubItemAdded(ListViewSubItem objSubItem)
            {
                // If the sub item is a control sub item
                ListViewSubControlItem objSubControlItem = objSubItem as ListViewSubControlItem;
                if (objSubControlItem != null)
                {
                    // Get the listview if the item is connected
                    ListView objListView = mobjListViewItem.ListView;
                    if (objListView != null)
                    {
                        // Get the sub item control
                        Control objSubControl = objSubControlItem.Control;
                        if (objSubControl != null)
                        {
                            // Add the sub item control
                            objListView.Controls.Add(objSubControl);
                        }
                    }
                }
            }


            /// <summary>
            /// Handle sub item removed
            /// </summary>
            /// <param name="objSubItem"></param>
            private void OnSubItemRemoved(ListViewSubItem objSubItem)
            {
                // If the sub item is a control sub item
                ListViewSubControlItem objSubControlItem = objSubItem as ListViewSubControlItem;
                if (objSubControlItem != null)
                {
                    // Get the listview if the item is connected
                    ListView objListView = mobjListViewItem.ListView;
                    if (objListView != null)
                    {
                        // Get the sub item control
                        Control objSubControl = objSubControlItem.Control;
                        if (objSubControl != null)
                        {
                            // Add the sub item control
                            objListView.Controls.Remove(objSubControl);
                        }
                    }
                }
            }

            /// <summary>
            ///
            /// </summary>
            public bool IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Adds a new sub item.
            /// </summary>
            /// <param name="strText">STR text.</param>
            /// <returns></returns>
            public ListViewItem.ListViewSubItem Add(string strText)
            {
                ListViewSubItem objSubItem = new ListViewSubItem(mobjListViewItem, strText);
                mobjSubItems.Add(objSubItem);
                return objSubItem;
            }

            /// <summary>
            /// Adds the specified obj control.
            /// </summary>
            /// <param name="objControl">The obj control.</param>
            /// <returns></returns>
            public ListViewItem.ListViewSubControlItem Add(Control objControl)
            {
                // Add control sub item
                ListViewSubControlItem objSubItem = new ListViewSubControlItem(mobjListViewItem, objControl);

                // Add control sub item to list
                mobjSubItems.Add(objSubItem);

                // Handle sub item added
                OnSubItemAdded(objSubItem);

                return objSubItem;
            }

            /// <summary>
            /// Adds the a sub item with styles.
            /// </summary>
            /// <param name="strText">The sub item text.</param>
            /// <param name="objForeColor">The sub item fore color.</param>
            /// <param name="objBackColor">The sub item back color.</param>
            /// <param name="objFont">The sub item font.</param>
            /// <returns></returns>
            public ListViewItem.ListViewSubItem Add(string strText, Color objForeColor, Color objBackColor, Font objFont)
            {
                ListViewSubItem objSubItem = new ListViewSubItem(mobjListViewItem, strText, objForeColor, objBackColor, objFont);
                mobjSubItems.Add(objSubItem);
                return objSubItem;
            }

            /// <summary>
            /// Adds a range of sub items.
            /// </summary>
            /// <param name="arrItems">Sub items array.</param>
            public void AddRange(ListViewItem.ListViewSubItem[] arrItems)
            {
                foreach (ListViewItem.ListViewSubItem objItem in arrItems)
                {
                    this.Add(objItem);
                }
            }

            /// <summary>
            /// Adds a range of items.
            /// </summary>
            /// <param name="arrItems">Range of items.</param>
            public void AddRange(string[] arrItems)
            {
                foreach (string strItem in arrItems)
                {
                    this.Add(strItem);
                }
            }

            /// <summary>
            /// Adds a range of sub items with styles.
            /// </summary>
            /// <param name="arrItems">The sub items text array.</param>
            /// <param name="objForeColor">The sub item fore color.</param>
            /// <param name="objBackColor">The sub item back color.</param>
            /// <param name="objFont">The sub item font.</param>
            public void AddRange(string[] arrItems, Color objForeColor, Color objBackColor, Font objFont)
            {
                foreach (string strItem in arrItems)
                {
                    this.Add(strItem, objForeColor, objBackColor, objFont);
                }
            }

            /// <summary>
            /// Clears the sub items.
            /// </summary>
            public void Clear()
            {
                mobjSubItems.Clear();
            }

            /// <summary>
            /// Checks if a sub item is contained.
            /// </summary>
            /// <param name="objSubItem">A sub item.</param>
            /// <returns></returns>
            public bool Contains(ListViewItem.ListViewSubItem objSubItem)
            {
                return mobjSubItems.Contains(objSubItem);
            }

            /// <summary>
            /// Ensures the sub item space (Not implemented).
            /// </summary>
            /// <param name="intSize">Size.</param>
            /// <param name="intIndex">Index.</param>
            private void EnsureSubItemSpace(int intSize, int intIndex)
            {
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns></returns>
            public IEnumerator GetEnumerator()
            {
                return mobjSubItems.GetEnumerator();
            }

            /// <summary>
            /// returns the indexes of a given sub item.
            /// </summary>
            /// <param name="objSubItem">A sub item.</param>
            /// <returns></returns>
            public int IndexOf(ListViewItem.ListViewSubItem objSubItem)
            {
                return mobjSubItems.IndexOf(objSubItem);
            }

            /// <summary>
            /// Inserts a sub item at a specified index.
            /// </summary>
            /// <param name="intIndex">Index.</param>
            /// <param name="objSubItem">The sub item.</param>
            public void Insert(int intIndex, ListViewItem.ListViewSubItem objSubItem)
            {
                mobjSubItems.Insert(intIndex, objSubItem);
            }

            /// <summary>
            /// Removes the specified sub item.
            /// </summary>
            /// <param name="objSubItem">Obj sub item.</param>
            public void Remove(ListViewItem.ListViewSubItem objSubItem)
            {
                // Remove item from sub items
                mobjSubItems.Remove(objSubItem);

                // Handle sub item removindg
                OnSubItemRemoved(objSubItem);
            }

            /// <summary>
            /// Removes a sub item at a specified index.
            /// </summary>
            /// <param name="intIndex">Index.</param>
            public void RemoveAt(int intIndex)
            {
                // Try to get the sub item at the given position
                ListViewSubItem objSubItem = mobjSubItems[intIndex] as ListViewSubItem;

                // If there is a valid sub item
                if (objSubItem != null)
                {
                    // Remove sub item
                    this.Remove(objSubItem);
                }
            }

            /// <summary>
            /// Copies to an array.
            /// </summary>
            /// <param name="objArrayDest">Arr dest.</param>
            /// <param name="intIndex">Int index.</param>
            public void CopyTo(Array objArrayDest, int intIndex)
            {
                mobjSubItems.CopyTo(objArrayDest, intIndex);
            }

            #endregion Methods

            #region Properties

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value></value>
            public int Count
            {
                get
                {
                    return mobjSubItems.Count;
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is read only.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
            /// </value>
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="ListViewSubItem"/> at the specified index.
            /// </summary>
            /// <value></value>
            public ListViewItem.ListViewSubItem this[int index]
            {
                get
                {
                    if (mobjSubItems.Count <= index)
                    {
                        //return an empty sub item
                        return new ListViewSubItem();
                    }
                    else
                    {
                        return (ListViewItem.ListViewSubItem)mobjSubItems[index];
                    }

                }
                set
                {
                    if (mobjSubItems == null)
                    {
                        mobjSubItems = new ArrayList();
                    }

                    // Execute a removal of the exist sub item.
                    this.OnSubItemRemoved(mobjSubItems[index] as ListViewItem.ListViewSubItem);

                    mobjSubItems[index] = value;

                    // Execute an addition of the new sub item.
                    this.OnSubItemAdded(value);
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is synchronized.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
            /// </value>
            public bool IsSynchronized
            {
                get
                {
                    return mobjSubItems.IsSynchronized;
                }
            }

            /// <summary>
            /// Gets the sync root.
            /// </summary>
            /// <value></value>
            public object SyncRoot
            {
                get
                {
                    return mobjSubItems.SyncRoot;
                }
            }

            #endregion Properties

            #region IList Members

            /// <summary>
            ///
            /// </summary>
            object System.Collections.IList.this[int index]
            {
                get
                {
                    return mobjSubItems[index];
                }
                set
                {

                    mobjSubItems[index] = value;
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="index"></param>
            /// <param name="objValue"></param>
            void System.Collections.IList.Insert(int index, object objValue)
            {
                mobjSubItems.Insert(index, objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            void System.Collections.IList.Remove(object objValue)
            {
                mobjSubItems.Remove(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            bool System.Collections.IList.Contains(object objValue)
            {
                return mobjSubItems.Contains(objValue); ;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.IndexOf(object objValue)
            {
                return mobjSubItems.IndexOf(objValue);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objValue"></param>
            int System.Collections.IList.Add(object objValue)
            {
                return mobjSubItems.Add(objValue);
            }

            #endregion IList Members

        }

        #endregion ListViewSubItemCollection

        #region ListViewSubControlItem

        [Serializable()]
        public class ListViewSubControlItem : ListViewSubItem
        {
            /// <summary>
            /// The hosted control
            /// </summary>
            private Control mobjControl = null;

            /// <summary>
            /// Creates a new <see cref="ListViewSubControlItem"/> instance.
            /// </summary>
            public ListViewSubControlItem(Control objControl)
                : base()
            {
                if (objControl == null)
                {
                    throw new ArgumentNullException("objControl");
                }

                // Set the control
                SetSubItemControl(objControl);
            }

            /// <summary>
            /// Creates a new <see crefListViewSubControlItemListViewSubItem"/> instance.
            /// </summary>
            /// <param name="objListViewItem">The owner list view.</param>
            /// <param name="objControl">The sub item text.</param>
            public ListViewSubControlItem(ListViewItem objListViewItem, Control objControl)
                : base(objListViewItem)
            {
                if (objControl == null)
                {
                    throw new ArgumentNullException("objControl");
                }

                // Set the control
                SetSubItemControl(objControl);
            }

            /// <summary>
            /// Sets the sub item control.
            /// </summary>
            /// <param name="objControl">The sub item control.</param>
            private void SetSubItemControl(Control objControl)
            {
                // Set the control and the docking mode
                mobjControl = objControl;
                mobjControl.Dock = DockStyle.Fill;
                mobjControl.TabIndex = 1;
            }

            /// <summary>
            /// Gets or sets the control.
            /// </summary>
            /// <value>The control.</value>
            public Control Control
            {
                get
                {
                    return mobjControl;
                }
            }

            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value></value>
            public override string Text
            {
                get
                {
                    return this.Control.Text;
                }
                set
                {
                    this.Control.Text = value;
                }
            }
        }

        #endregion ListViewSubControlItem

        #endregion Classes

        #region Client Members

        /// <summary>
        /// Occurs when [client after label edit].
        /// </summary>
        [SRDescription("Occurs when control's label edited in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterLabelEdit
        {
            add
            {
                this.AddClientHandler("AfterLabelEdit", value);
            }
            remove
            {
                this.RemoveClientHandler("AfterLabelEdit", value);
            }
        }

        #endregion

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to LargeImage property.
        /// </summary>
        private static readonly SerializableProperty LargeImageProperty = SerializableProperty.Register("LargeImage", typeof(ResourceHandle), typeof(ListViewItem));

        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static readonly SerializableProperty SmallImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ListViewItem));

        /// <summary>
        /// The mintImageIndex property registration.
        /// </summary>
        private static readonly SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// The DataItemIndex property registration.
        /// </summary>
        private static readonly SerializableProperty DataItemIndexProperty = SerializableProperty.Register("DataItemIndex", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(-1));

        /// The ToolTip property registration.
        /// </summary>
        private static readonly SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(ListViewItem), new SerializablePropertyMetadata(String.Empty));

        /// The mstrImageKey property registration.
        /// </summary>
        private static readonly SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ListViewItem), new SerializablePropertyMetadata(String.Empty));

        /// <summary>
        /// The mintIndentCount property registration.
        /// </summary> 
        private static readonly SerializableProperty IndentCountProperty = SerializableProperty.Register("IndentCount", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(0));

        /// <summary>
        /// The group property registration.
        /// </summary>
        private static readonly SerializableProperty GroupProperty = SerializableProperty.Register("Group", typeof(ListViewGroup), typeof(ListViewItem), new SerializablePropertyMetadata(null));

        #endregion Serializable Properties

        /// <summary>
        /// The collection of subitems
        /// </summary>
        [NonSerialized]
        private ListViewSubItemCollection mobjSubItems = null;

        /// <summary>
        /// Use item
        /// </summary>
        [NonSerialized]
        private bool mblnUseItemStyleForSubItems = true;

        
        /// <summary>Occurs after the list item label text is edited.</summary>
        [Browsable(false), SRDescription("ListViewItemAfterEditDescr")]
        protected event LabelEditEventHandler AfterLabelEdit
        {
            add
            {
                this.AddHandler(ListViewItem.AfterLabelEditEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListViewItem.AfterLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterLabelEdit event.
        /// </summary>
        private LabelEditEventHandler AfterLabelEditHandler
        {
            get
            {
                return (LabelEditEventHandler)this.GetHandler(ListViewItem.AfterLabelEditEvent);
            }
        }

        /// <summary>
        /// The AfterLabelEdit event registration.
        /// </summary>
        private static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(LabelEditEventHandler), typeof(ListViewItem));


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public ListViewItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItem"/> class.
        /// </summary>
        /// <param name="strText">The text of the first sub item.</param>
        public ListViewItem(string strText)
        {
            this.SubItems.Add(strText);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItem"/> class.
        /// </summary>
        /// <param name="arrItems">The sub items.</param>
        public ListViewItem(string[] arrItems)
        {
            if (arrItems.Length > 0)
            {
                this.SubItems.AddRange(arrItems);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItem"/> class.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="intImageIndex">Index of the int image.</param>
        public ListViewItem(string strText, int intImageIndex)
            : this(strText)
        {

            this.ImageIndex = intImageIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItem"/> class.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="strImageKey">The STR image key.</param>
        public ListViewItem(string strText, string strImageKey)
            : this(strText)
        {

            this.ImageKey = strImageKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItem"/> class.
        /// </summary>
        /// <param name="arrItems">The sub items.</param>
        /// <param name="intImageIndex">The index of the image in the image list.</param>
        public ListViewItem(string[] arrItems, int intImageIndex)
        {
            SubItems.AddRange(arrItems);

            this.ImageIndex = intImageIndex;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arrSubItems"></param>
        /// <param name="intImageIndex"></param>
        public ListViewItem(ListViewSubItem[] arrSubItems, int intImageIndex)
        {
            if (arrSubItems.Length > 0)
            {
                SubItems.AddRange(arrSubItems);
                this.Text = arrSubItems[0].Text;

                this.ImageIndex = intImageIndex;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arrItems"></param>
        /// <param name="intImageIndex"></param>
        /// <param name="objForeColor"></param>
        /// <param name="objBackColor"></param>
        /// <param name="objFont"></param>
        public ListViewItem(string[] arrItems, int intImageIndex, Color objForeColor, Color objBackColor, Font objFont)
        {
            SubItems.AddRange(arrItems);
            this.ImageIndex = intImageIndex;
            this.ForeColor = objForeColor;
            this.BackColor = objBackColor;
            this.Font = objFont;
        }

        #endregion C'Tor/D'Tor

        #region Methods

        #region Serialization Methods

        /// <summary>
        /// The amount of fields we are serializing
        /// </summary>
        private const int mcntSerializableFieldCount = 1;

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                int intSerializableDataInitialSize = base.SerializableDataInitialSize + mcntSerializableFieldCount;

                // Add the sub items array
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjSubItems);

                return intSerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when [swipe].
        /// </summary>
        /// <param name="enmSwipeDirection">The swipe direction.</param>
        protected override void OnSwipe(SwipeDirection enmSwipeDirection)
        {
            base.OnSwipe(enmSwipeDirection);

            // Get parent list view.
            ListView objListView = this.ListView;
            if (objListView != null)
            {
                // Fire swipe on list view.
                objListView.OnItemSwipe(this, enmSwipeDirection);
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the use item style for sub items flag
            mblnUseItemStyleForSubItems = objReader.ReadBoolean();

            // Get the sub items array
            object[] arrSubItems = objReader.ReadArray();

            // If there are sub items
            if (arrSubItems.Length > 0)
            {
                // re-create the sub item collection
                mobjSubItems = new ListViewSubItemCollection(this, arrSubItems);
            }
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write use item style for sub items flag
            objWriter.WriteBoolean(mblnUseItemStyleForSubItems);

            // Store the sub item collection
            objWriter.WriteArray(mobjSubItems);
        }

        #endregion

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            ListView objListView = this.ListView;
            if (objListView != null)
            {
                CriticalEventsData objParentEvents = objListView.GetCriticalEventsDataInternal();

                if (objParentEvents.HasEvent(WGEvents.Click))
                {
                    objEvents.Set(WGEvents.Click);
                }

                if (objParentEvents.HasEvent(WGEvents.DoubleClick))
                {
                    objEvents.Set(WGEvents.DoubleClick);
                }

                if (objParentEvents.HasEvent(WGEvents.Click) || this.ContextMenu != null ||
                    (objListView != null && objListView.ContextMenu != null))
                {
                    objEvents.Set(WGEvents.RightClick);
                }

                if (objParentEvents.HasEvent(WGEvents.Swipe))
                {
                    objEvents.Set(WGEvents.Swipe);
                }

                if (objParentEvents.HasEvent(WGEvents.AfterLabelEdit))
                {
                    objEvents.Set(WGEvents.AfterLabelEdit);
                }
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("AfterLabelEdit"))
            {
                objEvents.Set(WGEvents.AfterLabelEdit);
            }

            return objEvents;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // Select event type
            switch (objEvent.Type)
            {
                case "KeyDown":
                    if (this.ListView != null)
                    {
                        this.ListView.FireKeyDown(objEvent);
                    }
                    break;
                case "DoubleClick":
                    if (this.ListView != null)
                    {
                        this.ListView.OnItemClick(this, this.CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                        this.ListView.OnItemDoubleClick(this, this.CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    }
                    break;
                case "Click":
                    if (this.ListView != null)
                    {
                        MouseEventArgs objMouseEventArgs = this.CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
                        ListView.OnItemClick(this, objMouseEventArgs);
                    }
                    break;
                case "RightClick":
                    if (ListView != null)
                    {
                        MouseEventArgs objMouseEventArgs = this.CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Right), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
                        ListView.OnItemClick(this, objMouseEventArgs);
                    }
                    break;
                case "AfterLabelEdit":

                    string strText = CommonUtils.DecodeText(objEvent["Text"]);

                    //create event arg
                    LabelEditEventArgs objArgs = new LabelEditEventArgs(this.Index, strText);

                    // Raise AfterLabelEdit
                    OnAfterLabelEdit(objArgs);

                    //check if user cancel edit
                    if (!objArgs.CancelEdit)
                    {
                        //update node label value
                        this.TextInternal = strText;
                    }
                    else
                    {
                        //render old text
                        this.UpdateParams(AttributeType.Control);
                    }

                    break;
            }

            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Creates a mouse event arguments object.
        /// </summary>
        /// <param name="enmMouseButtons">The mouse buttons.</param>
        /// <param name="intClicks">The int clicks.</param>
        /// <param name="intX">The int X.</param>
        /// <param name="intY">The int Y.</param>
        /// <param name="intDelta">The int delta.</param>
        /// <returns></returns>
        private MouseEventArgs CreateMouseEventArgs(MouseButtons enmMouseButtons, int intClicks, int intX, int intY, int intDelta)
        {
            // Get the owner list view
            ListView objListView = this.ListView;
            if (objListView != null)
            {
                // Get the listview relative X and Y values
                objListView.GetRelativeXYFromItem(this, ref intX, ref intY);
            }

            // Return the event arguments
            return new MouseEventArgs(enmMouseButtons, intClicks, intX, intY, intDelta);
        }

        /// <summary>
        /// Renders the node.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        internal virtual void RenderItem(IContext objContext, IResponseWriter objWriter, long lngRequestID, ListView.ItemRenderingProcessor objProcessor)
        {
            // If the item is dirty 
            if (IsDirty(lngRequestID))
            {
                // Render the dirty item
                RenderDirtyItem(objContext, objWriter, objProcessor, 0);
            }
            else if (IsDirtyAttributes(lngRequestID))
            {
                RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);
            }
            else
            {
                // Render item components
                RenderNonDirtyItem(objContext, objWriter, lngRequestID, objProcessor);
            }
        }




        /// <summary>
        /// Renders the dirty item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objProcessor">The processor.</param>
        internal virtual void RenderDirtyItem(IContext objContext, IResponseWriter objWriter, ListView.ItemRenderingProcessor objProcessor, long lngRequestID)
        {
            // List of sub controls
            List<Control> objSubControlsToRender = null;

            // Get the use item style for sub items value
            bool blnUseItemStyleForSubItems = this.UseItemStyleForSubItems;

            if (lngRequestID == 0 || objProcessor.View == View.Details)
            {
                // Render the row tag
                objWriter.WriteStartElement(WGTags.Row);
            }
            else
            {
                objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);
            }

            // Render the item id
            objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());

            // Renders the is dirty attributes.
            RenderIsDirtyAttributes(objContext, (IAttributeWriter)objWriter);

            // Render control
            this.RenderUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);

            // Render the component events attributes
            this.RenderComponentEventAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID != 0);

            // Render DragAndDrop attributes.
            base.RenderDragAndDropAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID != 0);

            // Render Extended Component Attributes
            base.RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);

            // Render visual effects attributes
            base.RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter)objWriter);

            // Renders the item image
            this.RenderItemImage(objWriter, objProcessor.View);

            // Render the selected attribute if needed
            if (this.Selected)
            {
                objWriter.WriteAttributeString(WGAttributes.Selected, "1");
            }

            // Render the checked attribute if needed
            if (this.Checked)
            {
                objWriter.WriteAttributeString(WGAttributes.Checked, "1");
            }

            // If should use item style for sub items
            if (blnUseItemStyleForSubItems)
            {
                objWriter.WriteAttributeString(WGAttributes.UseItemStyleForSubItems, "1");
            }

            // If should show item tool tips
            if (objProcessor.ShowItemToolTips)
            {
                // Get the tooltip text
                string strToolTip = this.ToolTipText;

                // If there a valid tooltip
                if (!string.IsNullOrEmpty(strToolTip))
                {
                    objWriter.WriteAttributeText(WGAttributes.ToolTip, strToolTip);
                }
            }

            // If we are in details view
            if (objProcessor.View == View.Details)
            {
                // If there is a valid subitem collection
                if (mobjSubItems != null)
                {
                    // Loop all columns
                    foreach (ColumnHeader objColumn in objProcessor.SortedColumns)
                    {
                        // If the column is a valid column
                        if (objColumn.IsValidColumn)
                        {
                            // Write start of sub item
                            objWriter.WriteStartElement("SI");

                            // Write column index
                            objWriter.WriteAttributeString("COL", objColumn.Index.ToString());

                            // If the column index is in range
                            if (mobjSubItems.Count > objColumn.Index)
                            {
                                // Get the current sub item
                                ListViewItem.ListViewSubItem objSubItem = mobjSubItems[objColumn.Index];

                                // Print subitem style if needed always render column 0 style
                                if (!blnUseItemStyleForSubItems || objColumn.Index == 0)
                                {
                                    // Render sub item style
                                    objSubItem.RenderStyle(objWriter, "s" , objSubItem.BackColor, objSubItem.ForeColor, objSubItem.Font);
                                }

                                // Get the current sub control item if possible
                                ListViewItem.ListViewSubControlItem objSubControlItem = objSubItem as ListViewSubControlItem;

                                // If there is a sub control item
                                if (objSubControlItem != null)
                                {
                                    // render sub control
                                    objWriter.WriteAttributeString("c" , objSubControlItem.Control.GetProxyPropertyValue<long>("ID", objSubControlItem.Control.ID).ToString());

                                    // If we need to create collection
                                    if (objSubControlsToRender == null)
                                    {
                                        objSubControlsToRender = new List<Control>();
                                    }

                                    // Add control to be rendered
                                    objSubControlsToRender.Add(objSubControlItem.Control);
                                }
                                else
                                {
                                    // Print the subitem value
                                    objWriter.WriteAttributeText("c" , objSubItem.Text);
                                }
                            }
                            else
                            {
                                // Render the column value
                                objWriter.WriteAttributeString("c" , string.Empty);
                            }

                            // Write end of sub element
                            objWriter.WriteEndElement();
                        }
                    }
                }

                // Get the listview indent count
                int intIndentCount = this.IndentCount;

                // If indent count is greater than 0
                if (intIndentCount != 0)
                {
                    // Write the indent count
                    objWriter.WriteAttributeString(WGAttributes.IdentCount, intIndentCount.ToString());
                }
            }
            else
            {
                // If there are valid items
                if (this.HasSubItems)
                {
                    // Write start of sub item
                    objWriter.WriteStartElement("SI");

                    // Write column index
                    objWriter.WriteAttributeString("COL", "0");

                    // Get the current sub item
                    ListViewItem.ListViewSubItem objSubItem = mobjSubItems[0];

                    // Print the subitem value
                    objWriter.WriteAttributeText("c", objSubItem.Text);

                    // Write the item style
                    objSubItem.RenderStyle(objWriter, "s", objSubItem.BackColor, objSubItem.ForeColor, objSubItem.Font);

                    // Write end of sub element
                    objWriter.WriteEndElement();
                }
            }

            // If there are control to render
            if (objSubControlsToRender != null)
            {
                // Loop all controls and render them
                foreach (Control objControl in objSubControlsToRender)
                {
                    // Render the control 
                    ((IRenderableComponent)objControl).RenderComponent(objContext, objWriter, lngRequestID);
                }
            }

            // Write the end element
            objWriter.WriteEndElement();
        }

        /// <summary>
        /// Renders the update attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        private void RenderUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.Text, TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Renders the item image.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderItemImage(IResponseWriter objWriter, View enmView)
        {
            if (enmView == View.LargeIcon)
            {
                // Get large images.
                ResourceHandle objLargeImage = this.LargeImage;

                // If there is a valid large image
                if (objLargeImage != null)
                {
                    // add attributes to control element
                    objWriter.WriteAttributeString(WGAttributes.LargeImage, objLargeImage.ToString());
                }
            }
            else
            {
                // Get small image.
                ResourceHandle objSmallImage = this.SmallImage;

                // If there is a valid small image
                if (objSmallImage != null)
                {
                    // add attributes to control element
                    objWriter.WriteAttributeString(WGAttributes.Image, objSmallImage.ToString());
                }
            }
        }

        /// <summary>
        /// Renders non dirty item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request id.</param>
        private void RenderNonDirtyItem(IContext objContext, IResponseWriter objWriter, long lngRequestID, ListView.ItemRenderingProcessor objProcessor)
        {
            // If we are in details view
            if (objProcessor.View == View.Details)
            {
                // If there are sub items
                if (mobjSubItems != null)
                {
                    // Loop all columns
                    foreach (ColumnHeader objColumn in objProcessor.SortedColumns)
                    {
                        // Check that column is valid
                        if (objColumn.IsValidColumn)
                        {
                            // Check valid coloumn index
                            if (mobjSubItems.Count > objColumn.Index)
                            {
                                // Get the current sub control item if possible
                                ListViewItem.ListViewSubControlItem objSubControlItem = mobjSubItems[objColumn.Index] as ListViewSubControlItem;

                                // If there is a sub item control
                                if (objSubControlItem != null)
                                {
                                    // Render the sub item control
                                    ((IRenderableComponent)objSubControlItem.Control).RenderComponent(objContext, objWriter, lngRequestID);
                                }
                            }
                        }
                    }
                }

                // Try to get the panel item
                ListViewPanelItem objPanelItem = this as ListViewPanelItem;

                // If there is a valid panel item
                if (objPanelItem != null)
                {
                    // Render the panel
                    ((IRenderableComponent)objPanelItem.Panel).RenderComponent(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal void InternalUnRegisterSelf()
        {
            this.UnRegisterSelf();
        }

        /// <summary>
        ///
        /// </summary>
        public void Remove()
        {
            if (this.ListView != null)
            {
                this.UnRegisterSelf();
                this.ListView.Items.Remove(this);
            }
        }

        /// <summary>Ensures that the item is visible within the control, scrolling the contents of the control, if necessary.</summary>
        public virtual void EnsureVisible()
        {
            if (this.ListView.UseInternalPaging)
            {
                int intPageNumber = GetItemPage();

                if (this.ListView.CurrentPage != intPageNumber)
                {
                    this.ListView.CurrentPage = intPageNumber;
                }
            }

            this.InvokeMethodWithId("Controls_ScrollIntoView", this.ListView.ID, 1);
        }

        /// <summary>
        /// Gets the item page.
        /// </summary>
        /// <returns></returns>
        private int GetItemPage()
        {
            int intPageNumber = 1;

            //calculate the page only if using internal paging
            if (this.ListView.UseInternalPaging)
            {
                if (this.ListView.TotalPages > 1)
                {
                    //search our item in the items collection
                    int intItemNumber = 0;
                    foreach (ListViewItem objListViewItem in this.ListView.Items)
                    {
                        intItemNumber++;
                        if (objListViewItem == this)
                        {
                            break;
                        }
                    }
                    intPageNumber = (int)Math.Ceiling((double)intItemNumber / (double)this.ListView.ItemsPerPage);
                }
            }

            return intPageNumber;
        }

        /// <summary>
        /// Raises the <see cref="E:AfterLabelEdit"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            // Raise event if needed
            LabelEditEventHandler objEventHandler = this.AfterLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.ListView != null)
            {
                this.ListView.OnAfterLabelEditInternal(e);
            }
        }

        /// <summary>Initiates the editing of the item label.</summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void BeginEdit()
        {
            if (this.ListView != null && this.ListView.LabelEdit && this.ListView.Focused)
            {
                this.InvokeMethodWithId("LabelEditor_Show");
            }
        }

        /// <summary>Ends the editing of the tree node label.</summary>
        /// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void EndEdit(bool blnCancel)
        {
        }


        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            List<Control> objList = new List<Control>();

            foreach (ListViewSubItem objSubItem in this.SubItems)
            {
                ListViewSubControlItem objSubControlItem = objSubItem as ListViewSubControlItem;
                if (objSubControlItem != null)
                {
                    objList.Add(objSubControlItem.Control);
                }
            }

            return objList;
        }

        #endregion Methods

        #region Properties



        /// <summary>
        /// Gets or sets the name associated with this control.  
        /// </summary>
        /// <value></value>
        [Localizable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string Name
        {
            get
            {
                if (this.SubItems.Count == 0)
                {
                    return string.Empty;
                }
                return this.SubItems[0].Name;
            }
            set
            {
                this.SubItems[0].Name = value;
            }
        }





        /// <summary>Gets or sets the group to which the item is assigned.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
        [Localizable(true), DefaultValue((string)null), SRCategory("CatBehavior")]
        public ListViewGroup Group
        {
            get
            {
                return this.GetValue<ListViewGroup>(ListViewItem.GroupProperty);
            }
            set
            {
                // Get current group
                ListViewGroup objGroup = this.Group;

                // If group has changed
                if (objGroup != value)
                {
                    // If value is not null
                    if (value != null)
                    {
                        // Add to new group
                        value.Items.Add(this);
                    }
                    else
                    {
                        // If groupd is valid
                        if (objGroup != null)
                        {
                            // Remove from group
                            objGroup.Items.Remove(this);
                        }
                    }
                    // Update item's Listview
                    if (this.ListView != null)
                    {
                        this.ListView.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Moves to group.
        /// </summary>
        /// <param name="objNewGroup">The new group.</param>
        internal void MoveToGroup(ListViewGroup objNewGroup)
        {
            this.SetValue<ListViewGroup>(ListViewItem.GroupProperty, objNewGroup);
        }

        /// <summary>
        /// Should the serialize large image.
        /// </summary>
        protected bool ShouldSerializeSmallImage()
        {
            return this.SmallImageList == null && this.ContainsValue<ResourceHandle>(ListViewItem.SmallImageProperty);
        }

        /// <summary>Gets or sets the small image that is displayed for the item.</summary>
        /// <returns>The small image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
        /// <remarks>This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
        public ResourceHandle SmallImage
        {
            get
            {
                return this.GetImage(ListViewItem.SmallImageProperty, SmallImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(ListViewItem.SmallImageProperty, value, this.ImageList);
            }
        }

        /// <summary>
        /// Backwards compatibility Image property (use SmallImage instead)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Obsolete("Please use the 'SmallImage' property instead.")]
        public ResourceHandle Image
        {
            get
            {
                return this.SmallImage;
            }
            set
            {
                this.SmallImage = value;
            }
        }

        /// <summary>Gets the zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
        /// <returns>The zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control, or -1 if the item is not associated with a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
        [Browsable(false)]
        public int Index
        {
            get
            {
                if (this.ListView == null)
                {
                    return -1;
                }
                return this.ListView.GetDisplayIndex(this);
            }
        }

        /// <summary>Gets or sets the number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
        /// <returns>The number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
        [DefaultValue(0), SRDescription("ListViewItemIndentCountDescr"), SRCategory("CatDisplay")]
        public int IndentCount
        {
            get
            {
                return this.GetValue<int>(ListViewItem.IndentCountProperty);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("IndentCount", SR.GetString("ListViewIndentCountCantBeNegative"));
                }

                // If value has changed
                if (this.SetValue<int>(ListViewItem.IndentCountProperty, value))
                {
                    // Update the control.
                    Update();
                }
            }
        }

        /// <summary>
        /// Provides a way to define a large image for this list view item.
        /// </summary>
        /// <remarks>This property will throw an error if the owning list view has a large imagelist set to it.</remarks>
        public ResourceHandle LargeImage
        {
            get
            {
                return this.GetImage(ListViewItem.LargeImageProperty, LargeImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(ListViewItem.LargeImageProperty, value, this.ImageList);
            }
        }

        /// <summary>Gets or sets the text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
        /// <returns>The text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(""), SRCategory("CatAppearance")]
        public string ToolTipText
        {
            get
            {
                return this.GetValue<string>(ListViewItem.ToolTipTextProperty);
            }
            set
            {
                this.SetValue<string>(ListViewItem.ToolTipTextProperty, value);
            }
        }

        /// <summary>
        /// Shows the serialize large image.
        /// </summary>
        protected bool ShouldSerializeLargeImage()
        {
            return this.LargeImageList == null && this.ContainsValue<ResourceHandle>(ListViewItem.LargeImageProperty);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListViewItem"/> is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool Selected
        {
            get
            {
                return this.GetState(ComponentState.Selected);
            }
            set
            {
                // Set selected value and update control if value had changed
                if (this.SetStateWithCheck(ComponentState.Selected, value))
                {
                    // Update the control to reflect changes
                    this.Update();

                    // If listviewitem is connected raise selected index changed
                    if (this.ListView != null)
                    {
                        this.ListView.FireSelectedIndexChanged(this);
                    }
                }

            }
        }

        /// <summary>
        ///
        /// </summary>
        internal bool InternalSelected
        {
            get
            {
                return this.GetState(ComponentState.Selected);
            }
            set
            {
                this.SetState(ComponentState.Selected, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListViewItem"/> is checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return this.GetState(ComponentState.Checked);
            }
            set
            {
                // set the checked value and update control if value had changed
                if (this.SetStateWithCheck(ComponentState.Checked, value))
                {
                    // If listviewitem is connected
                    if (this.ListView != null)
                    {
                        // Fire item check on parent list
                        this.ListView.FireItemCheck(this, value);
                    }

                    // Update the current listview item
                    this.Update();
                }
            }

        }

        /// <summary>
        ///
        /// </summary>
        internal bool InternalChecked
        {
            get
            {
                return this.GetState(ComponentState.Checked);
            }
            set
            {
                this.SetState(ComponentState.Checked, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(null)]
        public Font Font
        {
            get
            {
                if (this.SubItems != null)
                {
                    if (this.HasSubItems)
                    {
                        if (this.SubItems[0].Font != null)
                        {
                            return this.SubItems[0].Font;
                        }
                    }
                }
                if (this.ListView != null)
                {
                    return this.ListView.Font;
                }
                return this.DefaultFont;
            }
            set
            {
                this.SubItems[0].Font = value;
            }
        }

        /// <summary>Gets or sets the background color of the item's text.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item's text.</returns>
        [SRCategory("CatAppearance")]
        public Color BackColor
        {
            get
            {
                if (this.HasSubItems)
                {
                    return this.SubItems[0].BackColor;
                }
                if (this.ListView != null)
                {
                    return this.ListView.BackColor;
                }
                return DefaultBackColor;
            }
            set
            {
                this.SubItems[0].BackColor = value;
            }
        }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        [Browsable(false)]
        public Rectangle Bounds
        {
            get
            {
                if (this.ListView != null)
                {
                    return this.ListView.GetItemRect(this.Index);
                }
                else
                {
                    return new Rectangle();
                }
            }
        }

        /// <summary>
        /// Gets the default color of the back.
        /// </summary>
        /// <value>The default color of the back.</value>
        private Color DefaultBackColor
        {
            get
            {
                ListView objListView = this.ListView;
                if (objListView != null)
                {
                    return objListView.DefaultRowBackColor;
                }
                return (Color)SystemColors.Window;
            }
        }

        /// <summary>
        /// Gets the default color of the fore.
        /// </summary>
        /// <value>The default color of the fore.</value>
        private Color DefaultForeColor
        {
            get
            {
                //Get the default value from the skin 
                ListView objListView = this.ListView;
                if (objListView != null)
                {
                    return objListView.DefaultRowForeColor;
                }

                return Color.Black;
            }
        }

        /// <summary>
        /// Gets the default font.
        /// </summary>
        /// <value>The default font.</value>
        private Font DefaultFont
        {
            get
            {
                //Get the default value from the skin 
                ListView objListView = this.ListView;
                if (objListView != null)
                {
                    return objListView.DefaultRowFont;
                }
                return null;
            }
        }

        /// <summary>Gets or sets the foreground color of the item's text.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of the item's text.</returns>
        [SRCategory("CatAppearance")]
        public Color ForeColor
        {
            get
            {
                if (this.HasSubItems)
                {
                    return this.SubItems[0].ForeColor;
                }
                if (this.ListView != null)
                {
                    return this.ListView.ForeColor;
                }
                return DefaultForeColor;
            }
            set
            {
                this.SubItems[0].ForeColor = value;
            }
        }

        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("ListViewItemImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                return this.GetValue<int>(ListViewItem.ImageIndexProperty);
            }
            set
            {
                // If image index is diffrent the current value
                if (this.SetValue<int>(ListViewItem.ImageIndexProperty, value))
                {
                    // reset the image key property
                    this.RemoveValue<string>(ListViewItem.ImageKeyProperty);

                    // Update the listviewitem
                    this.Update();
                }
            }
        }
        /// <summary>
        /// Gets or sets the index of the data item.
        /// </summary>
        /// <value>The index of the data item.</value>
        [DefaultValue(-1), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRDescription("ListViewItemDataItemIndexDescr"), SRCategory("CatData")]
        public int DataItemIndex
        {
            get
            {
                return this.GetValue<int>(ListViewItem.DataItemIndexProperty);
            }
            internal set
            {
                this.SetValue<int>(ListViewItem.DataItemIndexProperty, value);
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue("")]
        public string ImageKey
        {
            get
            {
                return this.GetValue<string>(ListViewItem.ImageKeyProperty);
            }
            set
            {
                // If image key is diffrent
                if (this.SetValue<string>(ListViewItem.ImageKeyProperty, value))
                {
                    // Remove image index property to revert to default
                    this.RemoveValue<int>(ListViewItem.ImageIndexProperty);

                    // Update the list view item
                    this.Update();
                }
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the image displayed with the item.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used by the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains the image displayed with the item.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public ImageList ImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.ListView != null)
                {
                    // Get the list view image based on listview view state
                    switch (this.ListView.View)
                    {
                        case View.LargeIcon:
                            //case View.Tile:
                            return this.ListView.LargeImageList;

                        case View.Details:
                        case View.SmallIcon:
                        case View.List:
                            return this.ListView.SmallImageList;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the large image list.
        /// </summary>
        /// <value>The large image list.</value>
        private ImageList LargeImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.ListView != null)
                {
                    return this.ListView.LargeImageList;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the small image list.
        /// </summary>
        /// <value>The small image list.</value>
        private ImageList SmallImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.ListView != null)
                {
                    return this.ListView.SmallImageList;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the list view.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ListView ListView
        {
            get
            {
                return this.InternalParent as ListView;
            }
        }

        /// <summary>
        /// Gets or sets the internal list view.
        /// </summary>
        /// <value></value>
        internal ListView InternalListView
        {
            get
            {
                return this.InternalParent as ListView;
            }
            set
            {
                this.InternalParent = value;
            }
        }

        /// <summary>
        /// Gets the sub items.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [SRDescription("ListViewItemSubItemsDescr")]
        [SRCategory("CatData")]
        public ListViewSubItemCollection SubItems
        {
            get
            {
                // Create subitems collection if not created yet               
                if (mobjSubItems == null)
                {
                    mobjSubItems = new ListViewSubItemCollection(this); ;
                }
                return mobjSubItems;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this listviewitem has sub items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this listviewitem has sub items; otherwise, <c>false</c>.
        /// </value>
        private bool HasSubItems
        {
            get
            {
                // If there is a sub items collection
                if (mobjSubItems != null)
                {
                    // If there are sub items in collection
                    return mobjSubItems.Count > 0;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the list view item text.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue("")]
        public string Text
        {
            get
            {
                return TextInternal;
            }
            set
            {
                if (this.HasSubItems)
                {
                    if (this.TextInternal != value)
                    {
                        this.TextInternal = value;
                        UpdateParams(AttributeType.Control);
                    }
                }
                else
                {
                    this.TextInternal = value;
                    if (value != string.Empty)
                    {
                        UpdateParams(AttributeType.Control);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the text internal.
        /// </summary>
        /// <value>The text internal.</value>
        internal string TextInternal
        {
            get
            {
                if (this.HasSubItems)
                {
                    return SubItems[0].Text;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (this.HasSubItems)
                {
                    SubItems[0].Text = value;
                }
                else
                {
                    this.SubItems.Add(value);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override void Update()
        {
            base.Update();
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Font"></see>, <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.ForeColor"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.BackColor"></see> properties for the item are used for all its subitems.</summary>
        /// <returns>true if all subitems use the font, foreground color, and background color settings of the item; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), DefaultValue(true)]
        public bool UseItemStyleForSubItems
        {
            get
            {
                return mblnUseItemStyleForSubItems;
            }
            set
            {
                // If the value is diffrent from the current
                if (mblnUseItemStyleForSubItems != value)
                {
                    // Set the new value
                    mblnUseItemStyleForSubItems = value;

                    // Update the item 
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }



        /// <summary>
        /// Gets item relative position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Point Position
        {
            get
            {
                ListView objListView = this.ListView;
                if ((objListView != null) && objListView.IsHandleCreated)
                {
                    int intX = 0;
                    int intY = 0;
                    objListView.GetRelativeXYFromItem(this, ref intX,ref intY);

                    return new Point(intX, intY);
                }
                return Point.Empty;
            }
            set
            {

            }
        }

        #endregion Properties
    }

    #endregion ListViewItem Class

    #region ListViewPanelItem Class

    /// <summary>
    /// Represents a list view item that can have a panel
    /// </summary>
    [Serializable()]
    [System.ComponentModel.ToolboxItem(false)]
    public class ListViewPanelItem : ListViewItem
    {
        #region Members

        /// <summary>
        /// The panel control
        /// </summary>
        private Control mobjPanel = null;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets the panel.
        /// </summary>
        /// <value>The panel.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Panel
        {
            get
            {
                return mobjPanel;
            }
        }

        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        public ListViewPanelItem(Control objPanel)
            : base()
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        /// <param name="strText">The text of the first sub item.</param>
        public ListViewPanelItem(Control objPanel, string strText)
            : base(strText)
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        /// <param name="arrItems">The sub items.</param>
        public ListViewPanelItem(Control objPanel, string[] arrItems)
            : base(arrItems)
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        /// <param name="strText">The text of the first sub item.</param>
        /// <param name="intImageIndex">The index of the image in the image list.</param>
        public ListViewPanelItem(Control objPanel, string strText, int intImageIndex)
            : base(strText, intImageIndex)
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        /// <param name="arrItems">The sub items.</param>
        /// <param name="intImageIndex">The index of the image in the image list.</param>
        public ListViewPanelItem(Control objPanel, string[] arrItems, int intImageIndex)
            : base(arrItems, intImageIndex)
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel control.</param>
        /// <param name="arrSubItems">The sub items.</param>
        /// <param name="intImageIndex">The index of the image in the image list.</param>
        public ListViewPanelItem(Control objPanel, ListViewSubItem[] arrSubItems, int intImageIndex)
            : base(arrSubItems, intImageIndex)
        {
            SetItemPanel(objPanel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPanelItem"/> class.
        /// </summary>
        /// <param name="objPanel">The panel.</param>
        /// <param name="arrItems">The items.</param>
        /// <param name="intImageIndex">Index of the int image.</param>
        /// <param name="objForeColor">Color of the obj fore.</param>
        /// <param name="objBackColor">Color of the obj back.</param>
        /// <param name="objFont">The obj font.</param>
        public ListViewPanelItem(Control objPanel, string[] arrItems, int intImageIndex, Color objForeColor, Color objBackColor, Font objFont)
            : base(arrItems, intImageIndex, objForeColor, objBackColor, objFont)
        {
            SetItemPanel(objPanel);
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Set the item panel
        /// </summary>
        /// <param name="objPanel"></param>
        private void SetItemPanel(Control objPanel)
        {
            // Validate panel is valid
            if (objPanel == null)
            {
                throw new ArgumentException("ListViewItem panel cannot be null.", "objPanel");
            }

            // Set the panel to top docking
            objPanel.Dock = DockStyle.Top;

            // Set the tab index to prevent automatic assignment
            objPanel.TabIndex = 1;

            // Set the item panel for this item
            mobjPanel = objPanel;
        }

        /// <summary>
        /// Renders the dirty item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objProcessor">The processor.</param>
        /// <param name="lngRequestID">The request id.</param>
        internal override void RenderDirtyItem(IContext objContext, IResponseWriter objWriter, ListView.ItemRenderingProcessor objProcessor, long lngRequestID)
        {
            base.RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);

            // If we are in details view
            if (objProcessor.View == View.Details)
            {
                // If is full list redraw
                if (objProcessor.FullListRedraw)
                {
                    // Write the listview panel
                    objWriter.WriteStartElement(WGTags.ListViewPanel);

                    // Get the list view panel
                    ((IRenderableComponent)this.Panel).RenderComponent(objContext, objWriter, lngRequestID);

                    // Write the listview panel end
                    objWriter.WriteEndElement();
                }
                else
                {
                    // Render the list panel if needed
                    ((IRenderableComponent)this.Panel).RenderComponent(objContext, objWriter, lngRequestID);
                }
            }

        }

        #endregion Methods
    }
    #endregion

    #region ListViewItemEventArgs Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ListViewItemEventArgs : EventArgs
    {
        #region Class Members

        /// <summary>
        /// A ListViewItem
        /// </summary>
        public readonly ListViewItem Item;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Creates a new <see cref="ListViewItemEventArgs"/> instance.
        /// </summary>
        /// <param name="objListViewItem">Item.</param>
        public ListViewItemEventArgs(ListViewItem objListViewItem)
        {
            Item = objListViewItem;
        }

        #endregion C'Tor / D'Tor
    }

    #endregion ListViewItemEventArgs Class

    #region ColumnClickEventArgs Class

    /// <summary>
    /// 
    /// </summary>
    public delegate void ColumnClickEventHandler(object sender, ColumnClickEventArgs e);

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ColumnClickEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="intColumn"></param>
        public ColumnClickEventArgs(int intColumn)
        {
            this.mintColumn = intColumn;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public int Column
        {
            get
            {
                return this.mintColumn;
            }
        }

        #endregion Properties

        #region Class Members

        private readonly int mintColumn;

        #endregion Class Members

    }

    #endregion ColumnClickEventArgs Class

    #region ColumnWidthChangedEventArgs Class

    /// <summary>
    /// 
    /// </summary>
    public delegate void ColumnWidthChangedEventHandler(object sender, ColumnWidthChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListView.ColumnWidthChanged"></see> event. </summary>
    [Serializable()]
    public class ColumnWidthChangedEventArgs : EventArgs
    {
        private readonly int mintColumnIndex;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The index of the column whose width is being changed.</param>
        public ColumnWidthChangedEventArgs(int intColumnIndex)
        {
            this.mintColumnIndex = intColumnIndex;
        }

        /// <summary>Gets the column index for the column whose width is being changed.</summary>
        /// <returns>The index of the column whose width is being changed.</returns>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }
    }

    #endregion

    #region ListViewGroup Class

    /// <summary>Represents a group of items displayed within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable, DefaultProperty("Header"), DesignTimeVisible(false), TypeConverter(typeof(ListViewGroupConverter)), ToolboxItem(false)]
    public sealed class ListViewGroup : SerializableObject
    {
        #region Memebers

        private string mstrHeader;
        private HorizontalAlignment menmHeaderAlignment;
        private ListView.ListViewItemCollection mobjItems;
        private ListView listView;
        private string mstrName;
        private static int mintNextHeader = 1;
        private object mobjUserData;

        #endregion Memebers

        #region Serializable Properties

        /// <summary>
        /// The group property registration.
        /// </summary>
        private static readonly SerializableProperty GroupProperty = SerializableProperty.Register("Group", typeof(ListViewGroup), typeof(ListViewGroup), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The groups collection
        /// </summary>
        private static readonly SerializableProperty GroupsProperty = SerializableProperty.Register("Groups", typeof(ListViewGroupCollection), typeof(ListViewGroup), new SerializablePropertyMetadata(null));

        #endregion Serializable Properties

        #region Properties

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return this.Header;
        }

        /// <summary>Gets or sets the header text for the group.</summary>
        /// <returns>The text to display for the group header. The default is "ListViewGroup".</returns>
        [SRCategory("CatAppearance")]
        public string Header
        {
            get
            {
                if (this.mstrHeader != null)
                {
                    return this.mstrHeader;
                }
                return "";
            }
            set
            {
                if (this.mstrHeader != value)
                {
                    this.mstrHeader = value;
                }
            }
        }

        /// <summary>Gets or sets the alignment of the group header text.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. The default is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), DefaultValue(0)]
        public HorizontalAlignment HeaderAlignment
        {
            get
            {
                return this.menmHeaderAlignment;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(HorizontalAlignment));
                }
                if (this.menmHeaderAlignment != value)
                {
                    this.menmHeaderAlignment = value;
                    this.UpdateListView();
                }
            }
        }

        /// <summary>Gets or sets the group to which the item is assigned.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
        [Localizable(true), DefaultValue((string)null), SRCategory("CatBehavior")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListViewGroup Group
        {
            get
            {
                return this.GetValue<ListViewGroup>(ListViewGroup.GroupProperty);
            }
            set
            {
                // Get current group
                ListViewGroup objGroup = this.Group;

                // If group has changed
                if (objGroup != value)
                {
                    // If value is not null
                    if (value != null)
                    {
                        // Add to new group
                        value.Groups.Add(this);
                    }
                    else
                    {
                        // If groupd is valid
                        if (objGroup != null)
                        {
                            // Remove from group
                            objGroup.Groups.Remove(this);
                        }
                    }
                }

            }
        }

        /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
        [MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatBehavior"), Localizable(true), SRDescription("ListViewGroupsDescr")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListViewGroupCollection Groups
        {
            get
            {
                // Try to get existing groups collection
                ListViewGroupCollection objGroups = this.GetValue<ListViewGroupCollection>(ListViewGroup.GroupsProperty);
                if (objGroups == null)
                {
                    // Create new groups collection
                    objGroups = new ListViewGroupCollection(this);

                    // Set the new groupd collection
                    this.SetValue<ListViewGroupCollection>(ListViewGroup.GroupsProperty, objGroups);
                }

                // Return the groups collection
                return objGroups;
            }
        }

        /// <summary>Gets a collection containing all items associated with this group.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> that contains all the items in the group. If there are no items in the group, an empty <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> object is returned.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public ListView.ListViewItemCollection Items
        {
            get
            {
                if (this.mobjItems == null)
                {
                    this.mobjItems = new ListView.ListViewItemCollection(this);
                }
                return this.mobjItems;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ListView ListView
        {
            get
            {
                return this.listView;
            }
        }

        internal ListView ListViewInternal
        {
            get
            {
                return this.listView;
            }
            set
            {
                if (this.listView != value)
                {
                    this.listView = value;
                }
            }
        }

        /// <summary>Gets or sets the name of the group.</summary>
        /// <returns>The name of the group.</returns>
        [SRCategory("CatBehavior"), Browsable(true), DefaultValue(""), SRDescription("ListViewGroupNameDescr")]
        public string Name
        {
            get
            {
                return this.mstrName;
            }
            set
            {
                this.mstrName = value;
            }
        }

        /// <summary>Gets or sets the object that contains data about the group.</summary>
        /// <returns>An <see cref="T:System.Object"></see> for storing the additional data. </returns>
        /// <filterpriority>1</filterpriority>
        [Localizable(false), DefaultValue((string)null), TypeConverter(typeof(StringConverter)), SRCategory("CatData"), SRDescription("ControlTagDescr"), Bindable(true)]
        public object Tag
        {
            get
            {
                return this.mobjUserData;
            }
            set
            {
                this.mobjUserData = value;
            }
        }

        #endregion Properties

        #region Methods

        private void UpdateListView()
        {
        }

        #endregion Methods

        #region C'tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the default header text of "ListViewGroup" and the default left header alignment.</summary>
        public ListViewGroup()
            : this(SR.GetString("ListViewGroupDefaultHeader", new object[] { mintNextHeader++ }))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified value to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property and using the default left header alignment.</summary>
        /// <param name="strHeader">The text to display for the group header. </param>
        public ListViewGroup(string strHeader)
        {
            this.mstrHeader = strHeader;
        }


        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties. </summary>
        /// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property.</param>
        /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property.</param>
        public ListViewGroup(string strKey, string strHeaderText)
            : this()
        {
            this.mstrName = strKey;
            this.mstrHeader = strHeaderText;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified header text and the specified header alignment.</summary>
        /// <param name="strHeader">The text to display for the group header. </param>
        /// <param name="enmHeaderAlignment">One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. </param>
        public ListViewGroup(string strHeader, HorizontalAlignment enmHeaderAlignment)
            : this(strHeader)
        {
            this.menmHeaderAlignment = enmHeaderAlignment;
        }

        #endregion C'tors
    }

    #endregion

    #region ListViewGroupCollection Class

    /// <summary>Represents the collection of groups within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
    [ListBindable(false)]
    [Serializable]
    public class ListViewGroupCollection : IList, ICollection, IEnumerable
    {
        #region Members

        /// <summary>
        /// 
        /// </summary>
        private ArrayList mobjGroups;

        /// <summary>
        /// 
        /// </summary>
        private object mobjOwner;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        private ArrayList List
        {
            get
            {
                if (this.mobjGroups == null)
                {
                    this.mobjGroups = new ArrayList();
                }
                return this.mobjGroups;
            }
        }

        /// <summary>Gets the number of groups in the collection.</summary>
        /// <returns>The number of groups in the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public int Count
        {
            get
            {
                return this.List.Count;
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</returns>
        /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to get or set. </param>
        /// <filterpriority>1</filterpriority>
        public ListViewGroup this[int index]
        {
            get
            {
                return (ListViewGroup)this.List[index];
            }
            set
            {
                if (!this.List.Contains(value))
                {
                    this.List[index] = value;
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property value. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified name.</returns>
        /// <param name="strKey">The name of the group to get or set.</param>
        public ListViewGroup this[string strKey]
        {
            get
            {
                if (this.mobjGroups != null)
                {
                    for (int i = 0; i < this.mobjGroups.Count; i++)
                    {
                        if (string.Compare(strKey, this[i].Name, false, CultureInfo.CurrentCulture) == 0)
                        {
                            return this[i];
                        }
                    }
                }
                return null;
            }
            set
            {
                int num = -1;
                if (this.mobjGroups != null)
                {
                    for (int i = 0; i < this.mobjGroups.Count; i++)
                    {
                        if (string.Compare(strKey, this[i].Name, false, CultureInfo.CurrentCulture) == 0)
                        {
                            num = i;
                            break;
                        }
                    }
                    if (num != -1)
                    {
                        this.mobjGroups[num] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.</returns>
        bool ICollection.IsSynchronized
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</returns>
        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.</returns>
        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (value is ListViewGroup)
                {
                    this[index] = (ListViewGroup)value;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection.</summary>
        /// <returns>The index of the group within the collection, or -1 if the group is already present in the collection.</returns>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to add to the collection. </param>
        /// <exception cref="T:System.ArgumentException">group contains at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
        public int Add(ListViewGroup objGroup)
        {
            if (this.Contains(objGroup))
            {
                return -1;
            }
            objGroup.ListViewInternal = this.GetOwnerListView();
            return this.List.Add(objGroup);

        }

        /// <summary>Adds a new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties </summary>
        /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see>.</returns>
        /// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property for the new group.</param>
        /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property for the new group.</param>
        public ListViewGroup Add(string strKey, string strHeaderText)
        {
            ListViewGroup objGroup = new ListViewGroup(strKey, strHeaderText);
            this.Add(objGroup);
            return objGroup;
        }

        /// <summary>Adds an array of groups to the collection.</summary>
        /// <param name="arrGroups">An array of type <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> that specifies the groups to add to the collection. </param>
        /// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
        public void AddRange(ListViewGroup[] arrGroups)
        {
            for (int intIndex = 0; intIndex < arrGroups.Length; intIndex++)
            {
                this.Add(arrGroups[intIndex]);
            }
        }

        /// <summary>Adds the groups in an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> to the collection.</summary>
        /// <param name="objGroups">A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> containing the groups to add to the collection. </param>
        /// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
        public void AddRange(ListViewGroupCollection objGroups)
        {
            for (int intIndex = 0; intIndex < objGroups.Count; intIndex++)
            {
                this.Add(objGroups[intIndex]);
            }
        }

        /// <summary>Removes all groups from the collection.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Clear()
        {
            for (int i = this.List.Count - 1; i >= 0; i--)
            {
                this.Remove(this[i]);
            }
        }

        /// <summary>
        /// Clears the internal.
        /// </summary>
        internal void ClearInternal()
        {
            // loop on all group and remove them without passing the ClearGroup function
            for (int i = this.List.Count - 1; i >= 0; i--)
            {
                this.List.Remove(this[i]);
            }
        }

        /// <summary>Determines whether the specified group is located in the collection.</summary>
        /// <returns>true if the group is in the collection; otherwise, false.</returns>
        /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(ListViewGroup value)
        {
            return this.List.Contains(value);
        }

        /// <summary>Copies the groups in the collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
        /// <param name="objArray">The <see cref="T:System.Array"></see> to which the groups are copied. </param>
        /// <param name="index">The first index within the array to which the groups are copied. </param>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(Array objArray, int index)
        {
            this.List.CopyTo(objArray, index);
        }

        /// <summary>Returns an enumerator used to iterate through the collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        /// <summary>Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> within the collection.</summary>
        /// <returns>The zero-based index of the group within the collection, or -1 if the group is not in the collection.</returns>
        /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(ListViewGroup value)
        {
            return this.List.IndexOf(value);
        }

        /// <summary>Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> into the collection at the specified index.</summary>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to insert into the collection. </param>
        /// <param name="index">The index within the collection at which to insert the group. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Insert(int index, ListViewGroup objGroup)
        {
            if (!this.Contains(objGroup))
            {
                objGroup.ListViewInternal = this.GetOwnerListView();
                this.List.Insert(index, objGroup);
            }
        }

        /// <summary>
        /// Gets the owner list view.
        /// </summary>
        /// <returns></returns>
        private ListView GetOwnerListView()
        {
            // Get the owner as listview
            ListView objOwner = mobjOwner as ListView;

            // If valid owner
            if (objOwner != null)
            {
                return objOwner;
            }
            else
            {
                // Get the owner as group
                ListViewGroup objGroup = mobjOwner as ListViewGroup;
                if (objGroup != null)
                {
                    // Get the group list view
                    return objGroup.ListView;
                }
            }

            return null;
        }

        /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> from the collection.</summary>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove from the collection. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Remove(ListViewGroup objGroup)
        {
            this.ClearGroup(objGroup);
            this.List.Remove(objGroup);

        }

        /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
        /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to add to the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The position into which the new element was inserted.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        int IList.Add(object objValue)
        {
            if (!(objValue is ListViewGroup))
            {
                throw new ArgumentException("value");
            }
            return this.Add((ListViewGroup)objValue);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
        /// </returns>
        bool IList.Contains(object objValue)
        {
            return ((objValue is ListViewGroup) && this.Contains((ListViewGroup)objValue));
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
        /// </returns>
        int IList.IndexOf(object objValue)
        {
            if (objValue is ListViewGroup)
            {
                return this.IndexOf((ListViewGroup)objValue);
            }
            return -1;
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to insert into the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        /// <exception cref="T:System.NullReferenceException">
        /// 	<paramref name="value"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
        void IList.Insert(int index, object objValue)
        {
            if (objValue is ListViewGroup)
            {
                this.Insert(index, (ListViewGroup)objValue);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to remove from the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.Remove(object objValue)
        {
            if (objValue is ListViewGroup)
            {
                this.Remove((ListViewGroup)objValue);
            }
        }

        /// <summary>
        /// Clears the group.
        /// </summary>
        /// <param name="objGroup">The group.</param>
        private void ClearGroup(ListViewGroup objGroup)
        {
            if (objGroup != null)
            {
                //Check if we need to clear sub groups
                if (objGroup.Groups.Count > 0)
                {
                    objGroup.Groups.Clear();
                }

                // Check if the group have items
                if (objGroup.Items.Count > 0)
                {
                    // Clear items grop reference
                    for (int i = objGroup.Items.Count - 1; i >= 0; i--)
                    {
                        ListViewItem objItem = objGroup.Items[i];
                        if (objItem != null)
                        {
                            objItem.Group = null;
                        }
                    }
                    if (objGroup.ListViewInternal != null)
                    {
                        // Update ListView
                        objGroup.ListViewInternal.Update();
                    }
                }

                // Clear group's listview reference
                objGroup.ListViewInternal = null;
            }
        }

        #endregion Methods

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewGroupCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The owner list view.</param>
        internal ListViewGroupCollection(ListView objOwner)
        {
            this.mobjOwner = objOwner;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewGroupCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The owner list view.</param>
        /// <param name="arrGroups">The arr groups.</param>
        internal ListViewGroupCollection(ListView objOwner, object[] arrGroups)
        {
            this.mobjOwner = objOwner;
            this.mobjGroups = new ArrayList(arrGroups);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewGroupCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The owner list view group.</param>
        internal ListViewGroupCollection(ListViewGroup objOwner)
        {
            this.mobjOwner = objOwner;
        }

        #endregion C'tors
    }

    #endregion ListViewGroupCollection Class

    #region ListViewGroupConverter Class

    /// <summary>
    /// Provides a convertion for the listviewgroup class
    /// </summary>
    /// <remarks>This converter causes the group the appear as a list selector of groups in the designer.</remarks>
    public class ListViewGroupConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objSourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            return ((((objSourceType == typeof(string)) && (objContext != null)) && (objContext.Instance is ListViewItem)) || base.CanConvertFrom(objContext, objSourceType));
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            return ((objDestinationType == typeof(InstanceDescriptor)) || ((((objDestinationType == typeof(string)) && (objContext != null)) && (objContext.Instance is ListViewItem)) || base.CanConvertTo(objContext, objDestinationType)));
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string str = ((string)objValue).Trim();
                if ((objContext != null) && (objContext.Instance != null))
                {
                    ListViewItem instance = objContext.Instance as ListViewItem;
                    if ((instance != null) && (instance.ListView != null))
                    {
                        foreach (ListViewGroup objGroup in instance.ListView.Groups)
                        {
                            if (objGroup.Header == str)
                            {
                                return objGroup;
                            }
                        }
                    }
                }
            }
            if ((objValue != null) && !objValue.Equals(SR.GetString("toStringNone")))
            {
                return base.ConvertFrom(objContext, objCulture, objValue);
            }
            return null;
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is ListViewGroup))
            {
                object objResult = ConvertToInstanceDescriptor(objContext, objValue);
                if (objResult != null)
                    return objResult;
            }
            if ((objDestinationType == typeof(string)) && (objValue == null))
            {
                return SR.GetString("toStringNone");
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
        {
            ListViewGroup objGroup = (ListViewGroup)objValue;
            ConstructorInfo constructor = typeof(ListViewGroup).GetConstructor(new Type[] { typeof(string), typeof(HorizontalAlignment) });
            if (constructor != null)
            {
                return new InstanceDescriptor(constructor, new object[] { objGroup.Header, objGroup.HeaderAlignment }, false);
            }
            return null;
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
        /// </returns>
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
        {
            if ((objContext != null) && (objContext.Instance != null))
            {
                ListViewItem instance = objContext.Instance as ListViewItem;
                if ((instance != null) && (instance.ListView != null))
                {
                    ArrayList values = new ArrayList();
                    foreach (ListViewGroup objGroup in instance.ListView.Groups)
                    {
                        values.Add(objGroup);
                    }
                    values.Add(null);
                    return new TypeConverter.StandardValuesCollection(values);
                }
            }
            return null;
        }

        /// <summary>
        /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; false if other values are possible.
        /// </returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
        /// </returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }
    }

    #endregion

    #region ListViewItemBindingEvent

    /// <summary>
    /// 
    /// </summary>
    public delegate void ListViewItemBindingEventHandler(object sender, ListViewItemBindingEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class ListViewItemBindingEventArgs : EventArgs
    {
        #region Memebers

        private ListViewItem mobjListViewItem = null;
        private object mobjDataRow = null;

        #endregion

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItemBindingEventArgs"/> class.
        /// </summary>
        /// <param name="objDataRow">The data row.</param>
        /// <param name="objListViewItem">The list view item.</param>
        public ListViewItemBindingEventArgs(object objDataRow, ListViewItem objListViewItem)
        {
            mobjListViewItem = objListViewItem;
            mobjDataRow = objDataRow;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the list view item.
        /// </summary>
        /// <value>The list view item.</value>
        public ListViewItem ListViewItem
        {
            get
            {
                return mobjListViewItem;
            }
            set
            {
                mobjListViewItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the data row.
        /// </summary>
        /// <value>The data row.</value>
        public object DataRow
        {
            get
            {
                return mobjDataRow;
            }
            set
            {
                mobjDataRow = value;
            }
        }

        #endregion
    }

    #endregion

    #region ListViewItemFormattingEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.ListView.ItemFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ListViewItemFormattingEventHandler(object sender, ListViewItemFormattingEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListView.ItemFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class ListViewItemFormattingEventArgs : EventArgs
    {
        #region Memebers

        /// <summary>
        /// 
        /// </summary>
        private readonly int mintIndex;

        /// <summary>
        /// 
        /// </summary>
        private readonly int mintSubItemIndex;

        /// <summary>
        /// 
        /// </summary>
        private readonly ListViewItem.ListViewSubItem mobjSubItem = null;

        #endregion Memebers

        #region C'tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"></see> class.</summary>
        /// <param name="intItemIndex">The item index of the Item that caused the event.</param>
        /// <param name="intColumnIndex">The column index of the Item that caused the event.</param>
        /// <param name="objSubItem">The sub item.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1-or-rowIndex is less than -1.</exception>
        internal ListViewItemFormattingEventArgs(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
        {
            this.mintIndex = intItemIndex;
            this.mintSubItemIndex = intColumnIndex;
            this.mobjSubItem = objSubItem;
        }

        #endregion C'tors

        #region Properties

        /// <summary>
        /// Gets the list item index.
        /// </summary>
        /// <value>The index.</value>
        public int Index
        {
            get
            {
                return this.mintIndex;
            }
        }

        /// <summary>
        /// Gets the index of the sub item.
        /// </summary>
        /// <value>The index of the sub item.</value>
        public int SubItemIndex
        {
            get
            {
                return mintSubItemIndex;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                return mobjSubItem.Text;
            }
            set
            {
                mobjSubItem.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.
        /// </summary>
        /// <value>The color of the back.</value>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        public Color BackColor
        {
            get
            {
                return mobjSubItem.BackColor;
            }
            set
            {
                mobjSubItem.BackColor = value;
            }
        }

        /// <summary>Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
        /// <returns>The <see cref="T:System.Drawing.Font"></see> applied to the item text. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        public Font Font
        {
            get
            {
                return mobjSubItem.Font;
            }
            set
            {
                mobjSubItem.Font = value;
            }
        }

        /// <summary>Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public Color ForeColor
        {
            get
            {
                return mobjSubItem.ForeColor;
            }
            set
            {
                mobjSubItem.ForeColor = value;
            }
        }

        #endregion Properties
    }
    #endregion

    #region ListViewBindingCompleteEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataBindingComplete"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ListViewBindingCompleteEventHandler(object sender, ListViewBindingCompleteEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataBindingComplete"></see> event.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class ListViewBindingCompleteEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewBindingCompleteEventArgs"></see> class.</summary>
        /// <param name="enmListChangedType">One of the <see cref="T:System.ComponentModel.ListChangedType"></see> values.</param>
        public ListViewBindingCompleteEventArgs(ListChangedType enmListChangedType)
        {
            this.menmListChangedType = enmListChangedType;
        }


        /// <summary>Gets a value specifying how the list changed.</summary>
        /// <returns>One of the <see cref="T:System.ComponentModel.ListChangedType"></see> values.</returns>
        /// <filterpriority>1</filterpriority>
        public System.ComponentModel.ListChangedType ListChangedType
        {
            get
            {
                return this.menmListChangedType;
            }
        }


        private ListChangedType menmListChangedType;
    }

    #endregion

    #region ColumnReorderedEventArgs Class

    /// <summary>
    /// Column Reordered delegate
    /// </summary>
    public delegate void ColumnReorderedEventHandler(object sender, ColumnReorderedEventArgs e);

    /// <summary>
    /// Column Reordered Event Args
    /// </summary>
    public class ColumnReorderedEventArgs : CancelEventArgs
    {
        #region Class Members

        private ColumnHeader mobjHeader;
        private int mintNewDisplayIndex;
        private int mintOldDisplayIndex;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnReorderedEventArgs"/> class.
        /// </summary>
        /// <param name="intOldDisplayIndex">Old Display index of the column.</param>
        /// <param name="intNewDisplayIndex">New Display index of the column.</param>
        /// <param name="objHeader">The column header.</param>
        public ColumnReorderedEventArgs(int intOldDisplayIndex, int intNewDisplayIndex, ColumnHeader objHeader)
        {
            mintOldDisplayIndex = intOldDisplayIndex;
            mintNewDisplayIndex = intNewDisplayIndex;
            mobjHeader = objHeader;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <value>The header.</value>
        public ColumnHeader Header
        {
            get
            {
                return mobjHeader;
            }
        }

        /// <summary>
        /// Gets the new index of the display.
        /// </summary>
        /// <value>The new index of the display.</value>
        public int NewDisplayIndex
        {
            get
            {
                return mintNewDisplayIndex;
            }
        }

        /// <summary>
        /// Gets the old index of the display.
        /// </summary>
        /// <value>The old index of the display.</value>
        public int OldDisplayIndex
        {
            get
            {
                return mintOldDisplayIndex;
            }
        }

        #endregion Properties
    }

    #endregion ColumnReorderedEventArgs Class

    #region ListViewRenderer Class

    /// <summary>
    /// Provides support for rendering a ListView control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ListViewRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewRenderer"/> class.
        /// </summary>
        /// <param name="objListView">The ListView control.</param>
        public ListViewRenderer(ListView objListView)
            : base(objListView)
        {
        }



        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            ListView objListView = this.Control as ListView;
            if (objListView != null)
            {
                switch (objListView.View)
                {
                    case View.Details:
                        RenderDetailsViewContent(objContext, objGraphics, objListView);
                        break;
                }
            }
        }

        /// <summary>
        /// Renders the content of the details view.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        private void RenderDetailsViewContent(ControlRenderingContext objContext, Graphics objGraphics, ListView objListView)
        {
            // Get the list view content region
            Rectangle objContentRegion = GetContentRegion(objListView);

            // Get the list view skin
            ListViewSkin objListViewSkin = objListView.Skin as ListViewSkin;

            // If there is a valid skin
            if (objListViewSkin != null)
            {
                // Get the listview columns
                ListView.ColumnHeaderCollection objColumns = objListView.Columns;

                // If there is a valid column collection
                if (objColumns != null)
                {

                    // If we need to generate the listview headers
                    if (objListView.HeaderStyle != ColumnHeaderStyle.None)
                    {
                        // Draw the headers and get the new content region
                        objContentRegion = DockInRegion(objContentRegion, DockStyle.Top, RenderHeaders(objContext, objGraphics, objListViewSkin, objListView, objColumns, objContentRegion));

                        // If there is no visible content region
                        if (!IsVisibleRegion(objContentRegion))
                        {
                            return;
                        }
                    }

                    // Loop all listview items
                    foreach (ListViewItem objListViewItem in objListView.Items)
                    {
                        // Draw the current item and get the new content region
                        objContentRegion = DockInRegion(objContentRegion, DockStyle.Top, RenderDetailsItem(objContext, objGraphics, objListViewSkin, objListView, objListViewItem, objColumns, objContentRegion));

                        // If there is no visible content region
                        if (!IsVisibleRegion(objContentRegion))
                        {
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Renders the details item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objListViewSkin">The list view skin.</param>
        /// <param name="objListView">The list view.</param>
        /// <param name="objListViewItem">The list view item.</param>
        /// <param name="objColumns">The columns.</param>
        /// <param name="objContentRegion">The content region.</param>
        /// <returns></returns>
        private Rectangle RenderDetailsItem(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ListViewItem objListViewItem, ListView.ColumnHeaderCollection objColumns, Rectangle objContentRegion)
        {
            int intItemHeight = 20; // TODO: get from skin or control

            // Create the item region
            Rectangle objItemRegion = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, intItemHeight));


            int intColumnIndex = 0;

            // Loop all sub items
            foreach (ListViewItem.ListViewSubItem objSubItem in objListViewItem.SubItems)
            {
                // If there is a valid column index
                if (objColumns.Count > intColumnIndex)
                {
                    objItemRegion = DockInRegion(objItemRegion, DockStyle.Left, RenderDetailsSubItem(objContext, objGraphics, objListViewSkin, objListView, objColumns[intColumnIndex], objSubItem, objItemRegion));
                }

                intColumnIndex++;
            }

            return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, intItemHeight));
        }

        /// <summary>
        /// Renders the details sub item.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objListViewSkin">The list view skin.</param>
        /// <param name="objListView">The list view.</param>
        /// <param name="objColumnHeader">The column header.</param>
        /// <param name="objSubItem">The sub item.</param>
        /// <param name="objItemsRegion">The items region.</param>
        /// <returns></returns>
        private Rectangle RenderDetailsSubItem(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ColumnHeader objColumnHeader, ListViewItem.ListViewSubItem objSubItem, Rectangle objItemsRegion)
        {
            Rectangle objItemRegion = new Rectangle(objItemsRegion.Location, new Size(objColumnHeader.Width, objItemsRegion.Height));

            StyleValue objCellNormalStyle = objListViewSkin.CellNormalStyle;

            RenderStyle(objContext, objGraphics, objListViewSkin, objCellNormalStyle, objItemRegion);

            if (objColumnHeader.Type == ListViewColumnType.Text)
            {
                RenderText(objContext, objGraphics, objSubItem.Text, objCellNormalStyle.Font, objCellNormalStyle.ForeColor, objItemRegion, ContentAlignment.MiddleLeft, false);
            }

            return objItemRegion;
        }

        /// <summary>
        /// Renders the headers.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objListViewSkin">The list view skin.</param>
        /// <param name="objListView">The list view.</param>
        /// <param name="objColumns">The columns.</param>
        /// <param name="objContentRegion">The content region.</param>
        /// <returns></returns>
        private Rectangle RenderHeaders(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ListView.ColumnHeaderCollection objColumns, Rectangle objContentRegion)
        {
            int intHeadersHeight = objListViewSkin.HeaderHeight; // TODO: get from skin or control

            // Create the item region
            Rectangle objHeadersRegion = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, intHeadersHeight));

            // Loop all columns
            foreach (ColumnHeader objColumnHeader in objColumns)
            {
                objHeadersRegion = DockInRegion(objHeadersRegion, DockStyle.Left, RenderHeader(objContext, objGraphics, objListViewSkin, objListView, objColumnHeader, objHeadersRegion));
            }

            return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, intHeadersHeight));
        }

        /// <summary>
        /// Renders the headers.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objListViewSkin">The list view skin.</param>
        /// <param name="objListView">The list view.</param>
        /// <param name="objColumnHeader">The column header.</param>
        /// <returns></returns>
        private Rectangle RenderHeader(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ColumnHeader objColumnHeader, Rectangle objHeadersRegion)
        {
            Rectangle objHeaderRegion = new Rectangle(objHeadersRegion.Location, new Size(objColumnHeader.Width, objHeadersRegion.Height));

            StyleValue objHeaderNormalStyle = objListViewSkin.HeaderNormalStyle;

            RenderStyle(objContext, objGraphics, objListViewSkin, objHeaderNormalStyle, objHeaderRegion);

            RenderText(objContext, objGraphics, objColumnHeader.Text, objHeaderNormalStyle.Font, objHeaderNormalStyle.ForeColor, objHeaderRegion, ContentAlignment.MiddleCenter, false);

            return objHeaderRegion;
        }


    }

    #endregion

    #region ListViewItemLabelEditEventArgs

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class LabelEditEventArgs : EventArgs
    {
        // Fields
        private bool cancelEdit;
        private readonly int item;
        private readonly string label;

        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objListItem"></param>
        public LabelEditEventArgs(int intItem)
        {
            this.mblnCancelEdit = false;
            this.mintItem = intItem;
            this.mstrLabel = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelEditEventArgs"/> class.
        /// </summary>
        /// <param name="intItem">The int item.</param>
        /// <param name="strLabel">The STR label.</param>
        public LabelEditEventArgs(int intItem, string strLabel)
        {
            this.mblnCancelEdit = false;
            this.mintItem = intItem;
            this.mstrLabel = strLabel;
        }


        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public bool CancelEdit
        {
            get
            {
                return this.mblnCancelEdit;
            }
            set
            {
                this.mblnCancelEdit = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string Label
        {
            get
            {
                return this.mstrLabel;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Item
        {
            get
            {
                return this.mintItem;
            }
        }


        #endregion Properties

        #region Class Members

        private bool mblnCancelEdit;

        private readonly string mstrLabel;

        private readonly int mintItem;


        #endregion Class Members
    }

    /// <summary>
    ///     Identifies the method that will handle the <see cref="ListView.AfterLabelEdit">AfterLabelEdit</see> event
    ///     of a <see cref="ListView">ListView</see> control.
    /// </summary>
    public delegate void LabelEditEventHandler(object sender, LabelEditEventArgs e);

    #endregion ItemLabelEditEventArgs

}
