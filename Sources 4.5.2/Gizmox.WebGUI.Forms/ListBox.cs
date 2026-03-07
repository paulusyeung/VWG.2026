#region Using

using System;
using System.Xml;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region ListBox Class

    /// <summary>
    /// Implementation of ListBox class.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ListBox), "ListBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ListBox), "ListBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [MetadataTag(WGTags.ListBox)]
    [Skin(typeof(ListBoxSkin))]
    [Serializable()]
    public class ListBox : ListControl
    {

        /// <summary>
        /// Provides a property reference to RadioBoxes property.
        /// </summary>
        private static SerializableProperty RadioBoxesProperty = SerializableProperty.Register("RadioBoxes", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to CheckBoxes property.
        /// </summary>
        private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to Mode property.
        /// </summary>
        private static SerializableProperty ModeProperty = SerializableProperty.Register("Mode", typeof(SelectionMode), typeof(ListBox), new SerializablePropertyMetadata(SelectionMode.One));

        /// <summary>
        /// Provides a property reference to Sorted property.
        /// </summary>
        private static SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to MultiColumn property.
        /// </summary>
        private static SerializableProperty MultiColumnProperty = SerializableProperty.Register("MultiColumn", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ColumnWidth property.
        /// </summary>
        private static SerializableProperty ColumnWidthProperty = SerializableProperty.Register("ColumnWidth", typeof(int), typeof(ListBox), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to IntegralHeight property.
        /// </summary>
        private static SerializableProperty IntegralHeightProperty = SerializableProperty.Register("IntegralHeight", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to TopIndex property.
        /// </summary>
        private static SerializableProperty TopIndexProperty = SerializableProperty.Register("TopIndex", typeof(int), typeof(ListBox));

        /// <summary>
        /// Provides a property reference to SelectedIndices property.
        /// </summary>
        [NonSerialized()]
        private SelectedIndexCollection mobjSelectedIndexCollection = null;

        /// <summary>
        /// Provides a property reference to SelectedItemd property.
        /// </summary>
        [NonSerialized()]
        private SelectedObjectCollection mobjSelectedObjectCollection = null;

        #region Classes

        /// <summary>
        /// 
        /// </summary>
        internal class ListBoxItem
        {
            /// <summary>
            /// The list state
            /// </summary>
            [NonSerialized]
            private int mintState = 0;

            /// <summary>
            /// 
            /// </summary>
            [NonSerialized]
            private object mobjItem;

            /// <summary>
            /// 
            /// </summary>
            [NonSerialized]
            private CheckState menmCheckState = CheckState.Unchecked;

            /// <summary>
            /// The listbox item state
            /// </summary>
            [Flags]
            internal enum ItemState : int
            {
                /// <summary>
                /// The list state enum 
                /// </summary>
                Selected = 1
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ListBoxItem"/> class.
            /// </summary>
            /// <param name="objItem">The item.</param>
            public ListBoxItem(object objItem)
            {
                //Set the item object
                mobjItem = objItem;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ListBoxItem"/> class.
            /// </summary>
            /// <param name="objItem">The item.</param>
            public ListBoxItem(object objItem, int intState)
            {
                //Set the item object
                mobjItem = objItem;

                // Set the item state
                mintState = intState;
            }

            /// <summary>
            /// Sets the state.
            /// </summary>
            /// <param name="enmState">The flag to set.</param>
            /// <param name="blnValue">The flag value to set.</param>
            internal void SetState(ItemState enmState, bool blnValue)
            {
                this.mintState = blnValue ? (this.mintState | ((int)enmState)) : (this.mintState & ~((int)enmState));
            }

            /// <summary>
            /// Gets the state.
            /// </summary>
            /// <param name="enmState">The state to get.</param>
            /// <returns></returns>
            internal bool GetState(ItemState enmState)
            {
                return ((this.mintState & ((int)enmState)) != 0);
            }



            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public object Item
            {
                get
                {
                    return mobjItem;
                }
                set
                {
                    mobjItem = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="ListBoxItem"/> is selected.
            /// </summary>
            /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
            public bool Selected
            {
                get
                {
                    return GetState(ItemState.Selected);
                }
                set
                {
                    SetState(ItemState.Selected, value);
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="ListBoxItem"/> is checked.
            /// </summary>
            /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
            public CheckState CheckState
            {
                get
                {
                    return menmCheckState;
                }
                set
                {
                    menmCheckState = value;
                }
            }

            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            internal int State
            {
                get { return mintState; }
                set { mintState = value; }
            }
        }

        /// <summary>
        /// The list box object collection
        /// </summary>
        public class ObjectCollection : ICollection, IList
        {
            #region ObjectCollectionComparer Class

            [Serializable()]
            internal class ObjectCollectionComparer : IComparer<ListBoxItem>
            {
                private ListBox mobjListControl = null;

                internal ObjectCollectionComparer(ListBox objListControl)
                {
                    mobjListControl = objListControl;
                }

                #region IComparer<ListBoxItem> Members

                int IComparer<ListBoxItem>.Compare(ListBoxItem objFirstListBoxItem, ListBoxItem objSecondListBoxItem)
                {

                    if (objFirstListBoxItem == null)
                    {
                        if (objSecondListBoxItem == null)
                        {
                            //If both of the ListBox items are null
                            return 0;
                        }
                        //If objFirstListBoxItem is null
                        return -1;
                    }
                    if (objSecondListBoxItem == null)
                    {
                        //If objSecondListBoxItem is null
                        return 1;
                    }

                    //Get the item object
                    object objFirstItem = objFirstListBoxItem.Item;
                    object objSecondItem = objSecondListBoxItem.Item;

                    if (objFirstItem == null)
                    {
                        if (objSecondItem == null)
                        {
                            return 0;
                        }
                        return -1;
                    }
                    if (objSecondItem == null)
                    {
                        return 1;
                    }

                    //Get the compared items text value
                    string strFirstItemText = this.mobjListControl.GetItemText(objFirstItem);
                    string strSecondItemText = this.mobjListControl.GetItemText(objSecondItem);

                    return Application.CurrentCulture.CompareInfo.Compare(strFirstItemText, strSecondItemText, CompareOptions.StringSort);
                }

                #endregion
            }

            #endregion

            #region Class Members

            /// <summary>
            /// The owner tab control
            /// </summary>
            internal List<ListBoxItem> mobjList = null;

            /// <summary>
            /// The object collection parent control
            /// </summary>
            private ListBox mobjParent = null;


            #endregion Class Members

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.
            /// </summary>
            /// <param name="objParent">The <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that owns the collection. </param>
            internal ObjectCollection(ListBox objParent)
            {
                // Initialize list
                mobjList = new List<ListBoxItem>();

                // Set parent
                mobjParent = objParent;
            }


            #endregion C'Tor

            #region Members

            /// <summary>
            /// Sorts the items using an internal comparer which compares by text
            /// </summary>
            internal void InternalSort()
            {
                this.mobjList.Sort(new ObjectCollectionComparer(mobjParent));
            }


            /// <summary>
            /// Gets a value indicating whether access to the collection is synchronized (thread safe).
            /// </summary>
            /// <returns>false in all cases.</returns>
            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets the number of items in the collection.
            /// </summary>
            /// <returns>The number of items in the collection </returns>
            public int Count
            {
                get
                {
                    return mobjList.Count;
                }
            }

            /// <summary>
            /// Copies the entire collection into an existing array of objects at a specified location within the array.
            /// </summary>
            /// <param name="intArrayIndex">The location within the destination array to copy the items from the collection to. </param>
            /// <param name="objDestinationArray">The object array in which the items from the collection are copied to. </param>
            public void CopyTo(Array objDestinationArray, int intArrayIndex)
            {
                //loop through the items collection 
                for (int i = intArrayIndex; i < mobjList.Count; i++)
                {
                    //set the destination array
                    objDestinationArray.SetValue(mobjList[i].Item, i);
                }
            }

            /// <summary>
            /// Gets the sync root.
            /// </summary>
            /// <returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.</returns>
            public object SyncRoot
            {
                get
                {
                    //Them syncronized object
                    return mobjList;
                }
            }

            /// <summary>
            /// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
            /// </summary>
            /// <returns>The zero-based index of the item in the collection, or -1 if <see cref="M:Gizmox.WebGUI.Forms.ListBox.BeginUpdate"></see> has been called.</returns>
            /// <param name="objObject">An object representing the item to add to the collection. </param>
            /// <exception cref="T:System.SystemException">There is insufficient space available to add the new item to the list. </exception>
            public int Add(object objObject)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                int intIndex = -1;

                // Check for valid item
                if (IsItemValid(objObject))
                {
                    intIndex = AddInternal(objObject);
                }
                else
                {
                    throw new ArgumentException(GetItemInvalidMessage(objObject));
                }
                mobjParent.Update();
                return intIndex;

            }

            /// <summary>
            /// Add to internal list with or with out sorting
            /// </summary>
            /// <param name="objItem">The obj item.</param>
            /// <returns></returns>
            private int AddInternal(object objItem)
            {
                // Check valid items
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }

                // Add a new list box item.
                return AddInternal(new ListBoxItem(objItem));
            }

            /// <summary>
            /// Adds the internal.
            /// </summary>
            /// <param name="objListBoxItem">The obj list box item.</param>
            /// <returns></returns>
            internal int AddInternal(ListBoxItem objListBoxItem)
            {
                // Added object index
                int intIndex = -1;

                // If not sorted control
                if (!this.mobjParent.Sorted)
                {
                    // Add to list and get index
                    this.mobjList.Add(objListBoxItem);

                    //Get the new index
                    intIndex = this.mobjList.IndexOf(objListBoxItem);
                }
                else
                {
                    // If there are items
                    if (this.Count > 0)
                    {
                        // Get the binaric position 
                        intIndex = this.mobjList.BinarySearch(objListBoxItem, new ObjectCollectionComparer(mobjParent));
                        if (intIndex < 0)
                        {
                            intIndex = ~intIndex;
                        }
                    }
                    else
                    {
                        intIndex = 0;
                    }

                    // Insert the item in the specified position
                    this.mobjList.Insert(intIndex, objListBoxItem);
                }

                // Return the added item indexs
                return intIndex;
            }

            /// <summary>
            /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
            /// </summary>
            /// <param name="arrObjects">The obj objects.</param>
            internal void AddRangeInternal(Object[] arrObjects)
            {
                foreach (object objObject in arrObjects)
                {
                    if (IsItemValid(objObject))
                    {
                        AddInternal(objObject);
                    }
                    else
                    {
                        throw new ArgumentException(GetItemInvalidMessage(objObject));
                    }
                }

                mobjParent.Update();
            }

            /// <summary>
            /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
            /// </summary>
            /// <param name="arrObjects">An array of objects to add to the list. </param>
            public void AddRange(Object[] arrObjects)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                this.AddRangeInternal(arrObjects);
            }

            /// <summary>
            /// Determines whether item is valid.
            /// </summary>
            /// <param name="objItem">The item to check validite.</param>
            /// <returns>
            /// 	<c>true</c> if valid item; otherwise, <c>false</c>.
            /// </returns>
            protected virtual bool IsItemValid(object objItem)
            {
                return true;
            }

            /// <summary>
            /// Gets the item invalid message.
            /// </summary>
            /// <param name="objItem">The item to check validite.</param>
            /// <returns></returns>
            protected virtual string GetItemInvalidMessage(object objItem)
            {
                return "";
            }

            /// <summary>
            /// Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
            /// </summary>
            /// <param name="objObjects">A <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to load into this collection. </param>
            public void AddRange(ICollection objObjects)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                AddRangeInternal(objObjects);
            }

            /// <summary>
            /// Adds the range internal.
            /// </summary>
            /// <param name="objObjects">The obj objects.</param>
            internal void AddRangeInternal(ICollection objObjects)
            {
                foreach (object objObject in objObjects)
                {
                    if (IsItemValid(objObject))
                    {
                        AddInternal(objObject);
                    }
                    else
                    {
                        throw new ArgumentException(GetItemInvalidMessage(objObject));
                    }
                }

                mobjParent.Update();
            }

            /// <summary>
            /// Sets the item with a new value
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="objValue">The value.</param>
            internal void SetItemInternal(int index, object objValue)
            {
                if (objValue == null)
                {
                    throw new ArgumentNullException("value");
                }
                if ((index < 0) || (index >= this.mobjList.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString() }));
                }

                //Set the selected list item with a new value set from the binding manager
                this.mobjList[index].Item = objValue;

                //update the list box
                mobjParent.Update();
            }


            internal int GetRequiredSerializationCapacity()
            {
                //The coolection Length*2(one for Item and one for State)
                //The +1: for the Count param state  
                return mobjList.Count * 2 + 1;
            }

            /// <summary>
            /// Called when listbox is serializing].
            /// </summary>
            /// <param name="objWriter">The serialization writer.</param>
            internal void OnSerializableObjectSerializing(SerializationWriter objWriter)
            {
                // Add item length
                objWriter.WriteInt32(mobjList.Count);

                // Loop all items
                for (int intIndex = 0; intIndex < mobjList.Count; intIndex++)
                {
                    // Get the listbox item
                    ListBoxItem objListBoxItem = mobjList[intIndex];

                    // If the slot is empty for some unknown reason
                    if (objListBoxItem != null)
                    {
                        objWriter.WriteObject(objListBoxItem.Item);
                        objWriter.WriteInt32(objListBoxItem.State);
                        objWriter.WriteInt32((int)objListBoxItem.CheckState);
                    }
                    else
                    {
                        objWriter.WriteObject(null);
                        objWriter.WriteInt32(0);
                        objWriter.WriteInt32((int)CheckState.Unchecked);
                    }

                }
            }

            /// <summary>
            /// Called when listbox is deserializing.
            /// </summary>
            /// <param name="objReader">The serialization reader.</param>
            internal void OnSerializableObjectDeserializing(SerializationReader objReader)
            {
                // Create a new list box item list
                mobjList = new List<ListBoxItem>();

                // Get the array length
                int intCount = objReader.ReadInt32();

                // Loop all items and add them
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    ListBoxItem objItem = new ListBoxItem(objReader.ReadObject(), objReader.ReadInt32());
                    objItem.CheckState = (CheckState)objReader.ReadInt32();
                    mobjList.Add(objItem );
                }
            }

            /// <summary>
            /// Clears the selected items.
            /// </summary>
            internal void ClearSelectedItems()
            {
                // Get all selected items.
                List<ListBoxItem> arrListBoxItems = mobjList.FindAll(delegate(ListBoxItem objListBoxItem) { return objListBoxItem.Selected; });
                if (arrListBoxItems != null)
                {
                    // Loop all selected items.
                    foreach (ListBoxItem objListBoxItem in arrListBoxItems)
                    {
                        // In case of selected item - un select it.
                        if (objListBoxItem.Selected)
                        {
                            objListBoxItem.Selected = false;
                        }
                    }
                }
            }

            /// <summary>
            /// Removes the specified object from the collection.
            /// </summary>
            /// <param name="objItem">An object representing the item to remove from the collection. </param>
            public virtual void Remove(object objItem)
            {
                //Find the ListBoxItem to remove 
                ListBoxItem objFoundListBoxItem = GetListBoxItemByItem(objItem);

                //If exist
                if (objFoundListBoxItem != null)
                {
                    // Get item index
                    int intIndex = mobjList.IndexOf(objFoundListBoxItem);

                    // Check that the index is valid
                    if (intIndex != -1)
                    {
                        this.RemoveAt(intIndex);
                    }
                }
            }

            /// <summary>
            /// Gets the list box item by item.
            /// </summary>
            /// <param name="objItem">The obj item.</param>
            /// <returns></returns>
            internal ListBoxItem GetListBoxItemByItem(object objItem)
            {
                //Look for the Item in the ListBoxItem collection
                return mobjList.Find(delegate(ListBoxItem objListBoxItem)
                {
                    //if both are null
                    if (objListBoxItem.Item == null && objItem == null)
                    {
                        //items are equal
                        return true;
                    }
                    //if one item is null and the other not
                    else if ((objListBoxItem.Item == null && objItem != null) || (objListBoxItem.Item != null && objItem == null))
                    {
                        //items are not equal
                        return false;
                    }
                    //check if the items are equal
                    return objListBoxItem.Item.Equals(objItem);
                }
                );
            }


            /// <summary>
            /// Returns an enumerator to use to iterate through the item collection.
            /// </summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
            public IEnumerator GetEnumerator()
            {
                //Create the new array
                object[] arrItems = new object[mobjList.Count];

                //loop through the ListBoxItems collection 
                for (int i = 0; i < mobjList.Count; i++)
                {
                    //set the item
                    arrItems[i] = mobjList[i].Item;
                }

                return arrItems.GetEnumerator();
            }

            /// <summary>
            /// Clears the internal.
            /// </summary>
            internal void ClearInternal()
            {
                InternalClear();

                if (InternalListBox != null)
                {
                    InternalListBox.ResetSelection();
                }
                mobjParent.Update();
            }

            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.IList"></see>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
            public virtual void Clear()
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                this.ClearInternal();
            }

            /// <summary>
            /// Internal Clear method.
            /// </summary>
            internal void InternalClear()
            {
                mobjList.Clear();
            }


            /// <summary>
            /// Returns the index within the collection of the specified item.
            /// </summary>
            /// <returns>The zero-based index where the item is located within the collection; otherwise, negative one (-1).</returns>
            /// <param name="objItem">An item representing the item to locate in the collection. </param>
            /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
            /// <returns></returns>
            public int IndexOf(object objItem)
            {
                //Find the ListBoxItem to remove 
                ListBoxItem objFoundListBoxItem = GetListBoxItemByItem(objItem);

                //If exist
                if (objFoundListBoxItem != null)
                {
                    //return the index of the ListBoxItem
                    return mobjList.IndexOf(objFoundListBoxItem);
                }

                //Not found
                return -1;
            }

            /// <summary>
            /// Gets the selected.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <returns>
            /// 	<c>true</c> if the specified obj item is selected; otherwise, <c>false</c>.
            /// </returns>
            internal bool GetSelected(int intIndex)
            {
                //Return the selected state
                return mobjList[intIndex].Selected;
            }

            /// <summary>
            /// Sets the selected.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <param name="blnSelected">if set to <c>true</c> [BLN selected].</param>
            /// <returns></returns>
            internal bool SetSelected(int intIndex, bool blnSelected)
            {
                bool blnValueChanged = false;

                //if the value has been changed
                if (mobjList[intIndex].Selected != blnSelected)
                {
                    blnValueChanged = true;

                    //Set the new value(state)
                    mobjList[intIndex].Selected = blnSelected;

                }

                return blnValueChanged;
            }

            /// <summary>
            /// Gets or sets the item at the specified index within the collection.
            /// </summary>
            /// <returns>An object representing the item located at the specified index within the collection.</returns>
            /// <param name="intIndex">The index of the item in the collection to get or set. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
            public object this[int intIndex]
            {
                get
                {
                    return mobjList[intIndex].Item;
                }
                set
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();

                    if (mobjList[intIndex].Item != value)
                    {
                        mobjList[intIndex].Item = value;

                        if (this.mobjParent != null)
                        {
                            this.mobjParent.Update();
                        }
                    }
                }
            }

            /// <summary>
            /// Gets the parent listbox
            /// </summary>
            private ListBox InternalListBox
            {
                get
                {
                    return mobjParent as ListBox;
                }
            }

            #endregion Members

            #region IList Members

            /// <summary>
            /// Gets a value indicating whether the collection is read-only.
            /// </summary>
            /// <returns>true if this collection is read-only; otherwise, false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Removes the item at the specified index within the collection.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
            public void RemoveAt(int index)
            {
                if (mobjParent != null)
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();

                    // Check that the index is in range
                    if ((index < 0) || (index >= this.mobjList.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
                    }

                    bool blnIsRemovedItemSelected = false;

                    // Get removed item.
                    ListBoxItem objItem = mobjList[index];
                    if (objItem != null)
                    {
                        // Check if removed item is selected.
                        blnIsRemovedItemSelected = objItem.Selected;
                    }

                    bool blnSelectedIndicesChanged = SelectedIndicesChanged(index);

                    // Remove the item at the given index
                    mobjList.RemoveAt(index);

                    // Check if removed item is selected.
                    if (blnIsRemovedItemSelected || blnSelectedIndicesChanged)
                    {
                        // Refresh cache.
                        mobjParent.InvalidateSelectionCache();
                    }

                    // Update listbox
                    mobjParent.Update();

                    if (blnIsRemovedItemSelected || blnSelectedIndicesChanged)
                    {
                        mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
                    }
                }
            }

            /// <summary>
            /// Checks if selected indices should be updated.
            /// </summary>
            /// <param name="index">The index of removed/inserted item.</param>
            /// <returns>true if selected indices should be updated; otherwise, false</returns>
            private bool SelectedIndicesChanged(int index)
            {
                foreach (int intSelectedIndex in mobjParent.SelectedIndices)
                {
                    if (intSelectedIndex >= index)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>Inserts an item into the list box at the specified index.
            /// </summary>
            /// <param name="objValue">An object representing the item to insert. </param>
            /// <param name="index">The zero-based index location where the item is inserted. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
            public void Insert(int index, object objValue)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                //check whether indices should be updated
                bool blnSelectedIndicesChanged = SelectedIndicesChanged(index);

                //insert the ListBoxItem at the given index
                mobjList.Insert(index, new ListBoxItem(objValue));

                if (blnSelectedIndicesChanged)
                {
                    // Refresh cache.
                    mobjParent.InvalidateSelectionCache();
                }

                // Update the parent listbox control
                mobjParent.Update();

                if (blnSelectedIndicesChanged)
                {
                    mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
                }
            }

            /// <summary>
            /// Determines whether the specified item is located within the collection.
            /// </summary>
            /// <returns>true if the item is located within the collection; otherwise, false.</returns>
            /// <param name="value">An object representing the item to locate in the collection. </param>
            public bool Contains(object objItem)
            {
                //Look for the ListBoxItem by item.
                return GetListBoxItemByItem(objItem) != null;
            }

            /// <summary>
            /// Gets a value indicating whether the collection has a fixed size.
            /// </summary>
            /// <returns>true in all cases.</returns>
            public bool IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Swaps the items.
            /// </summary>
            /// <param name="intIndexA">The int index A.</param>
            /// <param name="intIndexB">The int index B.</param>
            internal void SwapItems(int intIndexA, int intIndexB)
            {
                //Save the first item
                ListBoxItem objFirstItem = mobjList[intIndexA];

                //set the second item inti the first item
                mobjList[intIndexA] = mobjList[intIndexB];

                //set the saved item
                mobjList[intIndexB] = objFirstItem;
            }

            #endregion IList Members
        }

        /// <summary>
        /// This is the selected index collection
        /// </summary>
        [Serializable()]
        public class SelectedIndexCollection : IList, ICollection, IEnumerable
        {
            private ListBox mobjOwner;

            /// <summary>
            /// Initializes a new instance of the <see cref="SelectedIndexCollection"/> class.
            /// </summary>
            /// <param name="objOwner">The owner.</param>
            public SelectedIndexCollection(ListBox objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>
            /// Adds the specified index.
            /// </summary>
            /// <param name="intIndex">The index.</param>
            public void Add(int intIndex)
            {
                if (((this.mobjOwner != null) && (this.mobjOwner.Items != null)) && ((intIndex != -1) && !this.Contains(intIndex)))
                {
                    this.mobjOwner.SetSelected(intIndex, true);
                }
            }

            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
            public void Clear()
            {
                if (this.mobjOwner != null)
                {
                    this.mobjOwner.ClearSelected();
                }
            }

            /// <summary>
            /// Determines whether [contains] [the specified selected index].
            /// </summary>
            /// <param name="intSelectedIndex">Index of the selected.</param>
            /// <returns>
            ///   <c>true</c> if [contains] [the specified selected index]; otherwise, <c>false</c>.
            /// </returns>
            public bool Contains(int intSelectedIndex)
            {
                return (this.IndexOf(intSelectedIndex) != -1);
            }

            /// <summary>
            /// Copies to.
            /// </summary>
            /// <param name="objDestination">The destination.</param>
            /// <param name="intIndex">The index.</param>
            public void CopyTo(Array objDestination, int intIndex)
            {
                int count = this.Count;
                for (int i = 0; i < count; i++)
                {
                    objDestination.SetValue(this[i], (int)(i + intIndex));
                }
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
            /// </returns>
            public IEnumerator GetEnumerator()
            {
                return new SelectedIndexEnumerator(this);
            }

            /// <summary>
            /// Indexes the of.
            /// </summary>
            /// <param name="intSelectedIndex">Index of the selected.</param>
            /// <returns></returns>
            public int IndexOf(int intSelectedIndex)
            {
                if (this.mobjOwner != null && (intSelectedIndex >= 0) && (intSelectedIndex < this.InnerArray.Count))
                {
                    return this.mobjOwner.SelectedIndexesInternal.IndexOf(intSelectedIndex);
                }
                return -1;
            }

            /// <summary>
            /// Removes the specified index.
            /// </summary>
            /// <param name="intIndex">The index.</param>
            public void Remove(int intIndex)
            {
                if (((this.mobjOwner != null) && (this.mobjOwner.Items != null)) && ((intIndex != -1) && this.Contains(intIndex)))
                {
                    this.mobjOwner.SetSelected(intIndex, false);
                }
            }

            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <param name="value">The object to add to the <see cref="T:System.Collections.IList"/>.</param>
            /// <returns>
            /// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection,
            /// </returns>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
            int IList.Add(object value)
            {
                throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
            void IList.Clear()
            {
                throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
            }

            /// <summary>
            /// Determines whether [contains] [the specified selected index].
            /// </summary>
            /// <param name="objSelectedIndex">Index of the selected.</param>
            /// <returns>
            ///   <c>true</c> if [contains] [the specified selected index]; otherwise, <c>false</c>.
            /// </returns>
            bool IList.Contains(object objSelectedIndex)
            {
                return ((objSelectedIndex is int) && this.Contains((int)objSelectedIndex));
            }

            /// <summary>
            /// Indexes the of.
            /// </summary>
            /// <param name="objSelectedIndex">Index of the selected.</param>
            /// <returns></returns>
            int IList.IndexOf(object objSelectedIndex)
            {
                if (objSelectedIndex is int)
                {
                    return this.IndexOf((int)objSelectedIndex);
                }
                return -1;
            }

            /// <summary>
            /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
            /// </summary>
            /// <param name="intIndex">The zero-based index at which <paramref name="objValue"/> should be inserted.</param>
            /// <param name="objValue">The object to insert into the <see cref="T:System.Collections.IList"/>.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="intIndex"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
            ///   
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
            ///   
            /// <exception cref="T:System.NullReferenceException">
            ///   <paramref name="objValue"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
            void IList.Insert(int intIndex, object objValue)
            {
                throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <param name="objValue">The object to remove from the <see cref="T:System.Collections.IList"/>.</param>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
            void IList.Remove(object objValue)
            {
                throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes the <see cref="T:System.Collections.IList"/> item at the specified index.
            /// </summary>
            /// <param name="intIndex">The zero-based index of the item to remove.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="intIndex"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
            ///   
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
            void IList.RemoveAt(int intIndex)
            {
                throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.mobjOwner.SelectedItems.Count;
                }
            }

            /// <summary>
            /// Gets the inner array.
            /// </summary>
            private ObjectCollection InnerArray
            {
                get
                {
                    return this.mobjOwner.Items;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
            /// </summary>
            /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// Gets or sets the element at the specified index.
            /// </summary>
            /// <returns>The element at the specified index.</returns>
            ///   
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="intIndex"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
            ///   
            /// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList"/> is read-only. </exception>
            public int this[int intIndex]
            {
                get
                {
                    return this.mobjOwner.SelectedIndexesInternal[intIndex];
                }
            }

            /// <summary>
            /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
            /// </summary>
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
            /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.</returns>
            bool IList.IsFixedSize
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// Gets or sets the element at the specified index.
            /// </summary>
            /// <returns>The element at the specified index.</returns>
            ///   
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="intIndex"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
            ///   
            /// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList"/> is read-only. </exception>
            object IList.this[int intIndex]
            {
                get
                {
                    return this[intIndex];
                }
                set
                {
                    throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            [Serializable()]
            private class SelectedIndexEnumerator : IEnumerator
            {
                private int mintCurrent;
                private ListBox.SelectedIndexCollection mobjItems;

                /// <summary>
                /// Initializes a new instance of the <see cref="SelectedIndexEnumerator"/> class.
                /// </summary>
                /// <param name="objItems">The items.</param>
                public SelectedIndexEnumerator(ListBox.SelectedIndexCollection objItems)
                {
                    this.mobjItems = objItems;
                    this.mintCurrent = -1;
                }

                /// <summary>
                /// Advances the enumerator to the next element of the collection.
                /// </summary>
                /// <returns>
                /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
                /// </returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                bool IEnumerator.MoveNext()
                {
                    if (this.mintCurrent < (this.mobjItems.Count - 1))
                    {
                        this.mintCurrent++;
                        return true;
                    }
                    this.mintCurrent = this.mobjItems.Count;
                    return false;
                }

                /// <summary>
                /// Sets the enumerator to its initial position, which is before the first element in the collection.
                /// </summary>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                void IEnumerator.Reset()
                {
                    this.mintCurrent = -1;
                }

                /// <summary>
                /// Gets the current element in the collection.
                /// </summary>
                /// <returns>The current element in the collection.</returns>
                ///   
                /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
                object IEnumerator.Current
                {
                    get
                    {
                        if ((this.mintCurrent == -1) || (this.mintCurrent == this.mobjItems.Count))
                        {
                            throw new InvalidOperationException(SR.GetString("ListEnumCurrentOutOfRange"));
                        }
                        return this.mobjItems[this.mintCurrent];
                    }
                }
            }
        }



        /// <summary>
        /// Represents the collection of selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        [Serializable()]
        public class SelectedObjectCollection : IList, ICollection, IEnumerable
        {

            #region Class Members

            private ListBox mobjOwner;

            #endregion

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class.
            /// </summary>
            /// <param name="objOwner">A <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> representing the mobjOwner of the collection. </param>
            public SelectedObjectCollection(ListBox objOwner)
            {
                this.mobjOwner = objOwner;

            }
            #endregion

            #region Methods

            /// <summary>
            /// Adds an item to the list of selected items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
            /// </summary>
            /// <param name="objValue">An object representing the item to add to the collection of selected items.</param>
            public void Add(object objValue)
            {
                if (this.mobjOwner != null)
                {
                    ListBox.ObjectCollection objCollection = this.mobjOwner.Items;
                    if ((objCollection != null) && (objValue != null))
                    {
                        int intIndex = objCollection.IndexOf(objValue);
                        if ((intIndex != -1) && !this.GetSelected(intIndex))
                        {
                            this.mobjOwner.SelectedIndex = intIndex;
                        }
                    }
                }
            }

            /// <summary>
            /// Removes all items from the collection of selected items.
            /// </summary>
            public void Clear()
            {
                if (this.mobjOwner != null)
                {
                    this.mobjOwner.ClearSelected();
                }
            }

            /// <summary>
            /// Determines whether the specified item is located within the collection.
            /// </summary>
            /// <returns>true if the specified item is located in the collection; otherwise, false.</returns>
            /// <param name="selectedObject">An object representing the item to locate in the collection. </param>
            public bool Contains(object selectedObject)
            {
                return (mobjOwner.SelectedItemsInternal.IndexOf(selectedObject) != -1);
            }

            /// <summary>
            /// Copies the entire collection into an existing array at a specified location within the array.
            /// </summary>
            /// <param name="objDestinationArray">An <see cref="T:System.Array"></see> representing the array to copy the contents of the collection to. </param>
            /// <param name="index">The location within the destination array to copy the items from the collection to. </param>
            public void CopyTo(Array objDestinationArray, int index)
            {
                mobjOwner.SelectedItemsInternal.CopyTo(objDestinationArray, index);
            }


            /// <summary>
            /// Returns an enumerator that can be used to iterate through the selected item collection.
            /// </summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
            public IEnumerator GetEnumerator()
            {
                return this.mobjOwner.SelectedItemsInternal.GetEnumerator();
            }

            internal object GetObjectAt(int index)
            {
                return this.mobjOwner.SelectedItemsInternal[index];
            }

            /// <summary>
            /// Gets the selected.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns></returns>
            internal bool GetSelected(int index)
            {
                return this.mobjOwner.SelectedItemsInternal.Contains(this.mobjOwner.Items[index]);
            }

            /// <summary>
            /// Returns the index within the collection of the specified item.
            /// </summary>
            /// <returns>The zero-based index of the item in the collection; otherwise, -1.</returns>
            /// <param name="selectedObject">An object representing the item to locate in the collection. </param>
            public int IndexOf(object selectedObject)
            {
                return this.mobjOwner.SelectedItemsInternal.IndexOf(selectedObject);
            }


            /// <summary>
            /// Removes the specified object from the collection of selected items.
            /// </summary>
            /// <param name="objValue">An object representing the item to remove from the collection.</param>
            public void Remove(object objValue)
            {
                if (this.mobjOwner != null)
                {
                    ListBox.ObjectCollection objCollection = this.mobjOwner.Items;
                    if ((objCollection != null) & (objValue != null))
                    {
                        int intIndex = objCollection.IndexOf(objValue);
                        if ((intIndex != -1) && this.GetSelected(intIndex))
                        {
                            this.mobjOwner.SetSelected(intIndex, false);
                        }
                    }
                }
            }



            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.IList"></see>.
            /// </summary>
            /// <param name="objValue">The <see cref="T:System.Object"></see> to add to the <see cref="T:System.Collections.IList"></see>.</param>
            /// <returns>
            /// The position into which the new element was inserted.
            /// </returns>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
            int IList.Add(object objValue)
            {
                throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.IList"></see>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
            void IList.Clear()
            {
                throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
            }

            /// <summary>
            /// Inserts an item to the <see cref="T:System.Collections.IList"></see> at the specified index.
            /// </summary>
            /// <param name="index"></param>
            /// <param name="objValue">The <see cref="T:System.Object"></see> to insert into the <see cref="T:System.Collections.IList"></see>.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
            /// <exception cref="T:System.NullReferenceException">value is null reference in the <see cref="T:System.Collections.IList"></see>.</exception>
            void IList.Insert(int index, object objValue)
            {
                throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"></see>.
            /// </summary>
            /// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the <see cref="T:System.Collections.IList"></see>.</param>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
            void IList.Remove(object objValue)
            {
                throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
            }

            /// <summary>
            /// Removes the <see cref="T:System.Collections.IList"></see> item at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
            void IList.RemoveAt(int index)
            {
                throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
            }


            #endregion

            #region Properties

            /// <summary>Gets the number of items in the collection.</summary>
            /// <returns>The number of items in the collection.</returns>
            public int Count
            {
                get
                {
                    return this.mobjOwner.SelectedItemsInternal.Count;
                }
            }



            /// <summary>Gets a value indicating whether the collection is read-only.</summary>
            /// <returns>true if the collection is read-only; otherwise, false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            /// <summary>Gets the item at the specified index within the collection.</summary>
            /// <returns>An object representing the item located at the specified index within the collection.</returns>
            /// <param name="index">The index of the item in the collection to retrieve. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class. </exception>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
            public object this[int index]
            {
                get
                {
                    return this.mobjOwner.SelectedItemsInternal[index];
                }
                set
                {
                    throw new NotSupportedException(Gizmox.WebGUI.Forms.SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return true;
                }
            }
            #endregion
        }

        #endregion Classes

        #region Class Members

        /// <summary>
        /// Occurs when the SelectedIndex property has changed.
        /// </summary>
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                this.AddCriticalHandler(ListBox.SelectedIndexChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ListBox.SelectedIndexChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ListBox"></see> value has changed.
        /// </summary>
        [SRDescription("selectedIndexChangedEventDescr"), Category("Client")]
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
        /// Gets the hanlder for the SelectedIndexChanged event.
        /// </summary>
        private EventHandler SelectedIndexChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListBox.SelectedIndexChangedEvent);
            }
        }

        /// <summary>
        /// The SelectedIndexChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ListBox));

        /// <summary>
        /// The cached Selected Items
        /// </summary>
        [NonSerialized]
        private ArrayList mobjCachedSelectedItems = null;

        /// <summary>
        /// The cached Selected indexes
        /// </summary>
        [NonSerialized]
        private List<int> mobjCachedSelectedIndexes = null;

        /// <summary>
        /// The list box items
        /// </summary>
        [NonSerialized]
        private ObjectCollection mobjItems = null;

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> class.
        /// </summary>
        public ListBox()
        {
            // initialize collections
            mobjItems = CreateItemCollection();

            // Set the list box style
            base.SetStyle(ControlStyles.UseTextForAccessibility | ControlStyles.StandardClick | ControlStyles.UserPaint, false);
        }


        #endregion C'Tor/D'Tor

        #region Methods


        #region Serialization Methods

        /// <summary>
        /// The amount of fields the listbox needs to serialize
        /// </summary>
        private const int mintSerializableFieldCount = 0;

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
                // Get the base requirements and add the form fields
                int intSerializableDataInitialSize = base.SerializableDataInitialSize + mintSerializableFieldCount;

                // Add the items collection required serialization capacity
                intSerializableDataInitialSize += mobjItems.GetRequiredSerializationCapacity();

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

            // Create the items collection
            mobjItems = this.CreateItemCollection();
            mobjItems.OnSerializableObjectDeserializing(objReader);


        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Serialize the items
            mobjItems.OnSerializableObjectSerializing(objWriter);
        }

        #endregion

        #region Render

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Get image use parameters
            bool blnShouldRenderItemImage = this.ShouldRenderImage();

            // Get color use parameters
            bool blnShouldRenderItemColor = this.ShouldRenderColor();

            // Render the selection mode attribute.
            if (this.SelectionMode != SelectionMode.One)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectionMode, Convert.ToInt32(this.SelectionMode).ToString());
            }

            if (this.MetadataTag == WGTags.ListBox)
            {
                // Render the CheckBoxes and RadioBoxes attributes.
                if (this.CheckBoxes)
                {
                    objWriter.WriteAttributeString(WGAttributes.CheckBoxes, "1");
                }
                else if (this.RadioBoxes)
                {
                    objWriter.WriteAttributeString(WGAttributes.RadioButtons, "1");
                }
            }

            ObjectCollection objItems = this.Items;

            for (int intIndex = 0; intIndex < objItems.Count; intIndex++)
            {
                objWriter.WriteStartElement(WGTags.Option);
                RenderItemAttributes(objWriter, objItems[intIndex], intIndex, blnShouldRenderItemImage, blnShouldRenderItemColor);
                objWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            //If we should render Color
            if (this.ShouldRenderColor())
            {
                //Render color
                objWriter.WriteAttributeString(WGAttributes.ShowColor, "1");
            }

            //If we should render image
            if (this.ShouldRenderImage())
            {
                //Render image
                objWriter.WriteAttributeString(WGAttributes.ShowImage, "1");
            }

            objWriter.WriteAttributeString(WGAttributes.ItemHeight, this.GetPreferdItemHeight().ToString());

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWriter"></param>
        /// <param name="objItem"></param>
        /// <param name="intIndex"></param>
        internal protected virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor)
        {
            objWriter.WriteAttributeString("Idx", intIndex.ToString());

            // Render the item id attribute
            RenderItemIdAttribute(objWriter, objItem);

            //Check by index if the item is selected
            if (this.Items.GetSelected(intIndex))
            {
                objWriter.WriteAttributeString(WGAttributes.Selected, "1");
            }

            if (objItem == null)
            {
                objWriter.WriteAttributeString(WGAttributes.Text, "");
            }
            else
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.GetItemText(objItem), TextFilter.CarriageReturn | TextFilter.NewLine);

                RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, objItem);
            }

        }

        /// <summary>
        /// Renders the item attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objItem">The obj item.</param>
        /// <param name="intIndex">Index of the int.</param>
        internal protected virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
        {
            RenderItemAttributes(objWriter, objItem, intIndex, false, false);
        }
        #endregion Render

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {

            // Select event type
            switch (objEvent.Type)
            {
                case "SelectionChange":
                    SelectIndexes(objEvent["Indexes"] as string);
                    break;
            }

            base.FireEvent(objEvent);

        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (base.SelectedValueChangedHandler != null || SelectedIndexChangedHandler != null || this.IsPostBackRequired) objEvents.Set(WGEvents.SelectionChange);
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

            return objEvents;
        }


        /// <summary>
        /// Unselects all items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        public void ClearSelected()
        {
            //Clear the selected items collection
            ClearSelectedItems();

            this.Update();
        }

        /// <summary>
        /// Clears the selected items.
        /// </summary>
        private void ClearSelectedItems()
        {
            // Clear selected items.
            this.Items.ClearSelectedItems();

            //Update the selected items array
            this.InvalidateSelectionCache();
        }

        /// <summary>
        /// Selects the indexes.
        /// </summary>
        /// <param name="strIndexes">STR indexes.</param>
        private void SelectIndexes(string strIndexes)
        {
            bool blnHasChanged = false;

            // Get indexes string list
            List<string> arrIndexes = new List<string>(strIndexes.Split(','));

            //Get the items object
            ObjectCollection objItems = this.Items;

            //Get the items count
            int intItemsCount = objItems.Count;

            //loop through the items collection  
            for (int i = 0; i < intItemsCount; i++)
            {
                //if the item is in the selected Indexes array
                if (arrIndexes.Contains(i.ToString()))
                {
                    //If the item is not checked at the moment
                    if (!objItems.GetSelected(i))
                    {
                        // Flag that selection changed.
                        blnHasChanged = true;

                        // Select it and raise an event
                        this.Items.SetSelected(i, true);
                    }
                }
                else if (objItems.GetSelected(i))
                {
                    // Flag that selection changed.
                    blnHasChanged = true;

                    // Unselect it and raise an event
                    this.Items.SetSelected(i, false);
                }
            }

            //If the selected items has been modifyed
            if (blnHasChanged || this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick)
            {
                //Update the selected items array
                this.InvalidateSelectionCache();
                OnSelectedIndexChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            CurrencyManager objCurrencyManager = base.DataManager;
            if (((objCurrencyManager != null) && (objCurrencyManager.Position != this.SelectedIndex)) && (!base.FormattingEnabled || (this.SelectedIndex != -1)))
            {
                objCurrencyManager.Position = this.SelectedIndex;
            }

            // Raise event if needed
            EventHandler objEventHandler = this.SelectedIndexChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion Events

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            if (base.DataSource == null)
            {
                //this.BeginUpdate();
                this.SelectedIndex = -1;
                this.Items.ClearInternal();
                //this.EndUpdate();
            }
            base.OnDataSourceChanged(e);
            this.RefreshItems();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDisplayMemberChanged(EventArgs e)
        {
            base.OnDisplayMemberChanged(e);
            this.RefreshItems();
            if ((this.SelectionMode != SelectionMode.None) && (base.DataManager != null))
            {
                this.SelectedIndex = base.DataManager.Position;
            }
        }

        /// <summary>
        /// Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> items and retrieves new strings for them.
        /// </summary>
        protected override void RefreshItems()
        {
            // Preserve previous object collection.
            ListBox.ObjectCollection objCollectionOld = mobjItems;

            // Create a new object collection.
            ListBox.ObjectCollection objCollectionNew = mobjItems = CreateItemCollection();

            // Clear selected items.
            ClearSelectedItems();

            // Check if data manager exists.
            if ((base.DataManager != null) && (base.DataManager.Count != -1))
            {
                // Create an object array.
                object[] arrObjects1 = new object[base.DataManager.Count];

                // Loop all of the data manager's items.
                for (int intIndex = 0; intIndex < arrObjects1.Length; intIndex++)
                {
                    // Add current item to temp
                    arrObjects1[intIndex] = base.DataManager[intIndex];
                }
                objCollectionNew.AddRangeInternal(arrObjects1);
            }
            else if (objCollectionOld != null)
            {
                // Loop previous object collection 
                foreach (object objItem in objCollectionOld)
                {
                    // Get listbox item as for current item.
                    ListBoxItem objListBoxItem = objCollectionOld.GetListBoxItemByItem(objItem);
                    if (objListBoxItem != null)
                    {
                        // Add listbox item to new object collection.
                        objCollectionNew.AddInternal(objListBoxItem);
                    }
                }

                // Redraw listbox.
                this.Update();
            }

            if (this.SelectionMode != SelectionMode.None)
            {
                if (base.DataManager != null)
                {
                    this.SelectedIndex = base.DataManager.Position;
                }
            }
        }

        /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
        /// <param name="index">The zero-based index of the item whose data to refresh. </param>
        protected override void RefreshItem(int index)
        {
            this.Update();
        }

        /// <summary>When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
        /// <param name="objItems">An array of items.</param>
        protected override void SetItemsCore(IList objItems)
        {
            this.Items.ClearInternal();
            this.Items.AddRangeInternal(objItems);
        }

        /// <summary>
        /// When overridden in a derived class, sets the object with the specified index in the derived class.
        /// </summary>
        /// <param name="index">The array index of the object.</param>
        /// <param name="objValue">The object.</param>
        protected override void SetItemCore(int index, object objValue)
        {
            this.Items.SetItemInternal(index, objValue);
        }

        /// <summary>
        /// Clears the current selection 
        /// </summary>
        internal void ResetSelection()
        {
            //Clear the selected items collection
            ClearSelectedItems();
        }

        /// <summary>
        /// Clears the selection from object if selected
        /// </summary>
        /// <param name="intIndex">Index of the int.</param>
        internal void RemoveSelection(int intIndex)
        {
            // Set the item as Un selected
            if (this.Items.SetSelected(intIndex, false))
            {
                //Update the selected items array
                this.InvalidateSelectionCache();
            }
        }

        /// <summary>Selects or clears the selection for the specified item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</summary>
        /// <param name="blnValue">true to select the specified item; otherwise, false. </param>
        /// <param name="intIndex">The zero-based index of the item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> to select or clear the selection for. </param>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property was set to None.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified index was outside the range of valid values. </exception>
        /// <filterpriority>1</filterpriority>
        public void SetSelected(int intIndex, bool blnValue)
        {
            ObjectCollection objItems = this.Items;
            int intCount = (objItems == null) ? 0 : objItems.Count;
            if ((intIndex < 0) || (intIndex >= intCount))
            {
                throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", intIndex.ToString() }));
            }
            if (this.SelectionMode == SelectionMode.None)
            {
                throw new InvalidOperationException(SR.GetString("ListBoxInvalidSelectionMode"));
            }

            //If the selected state has been changed           
            if (this.Items.SetSelected(intIndex, blnValue))
            {
                //Update the selected items array
                this.InvalidateSelectionCache();
                this.Update();
            }

            this.OnSelectedIndexChanged(EventArgs.Empty);
        }




        /// <summary>
        /// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string.
        /// </summary>
        ///	<returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
        ///	<param name="strValue">The text to search for. </param>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The value of the s parameter is less than -1 or greater than or equal to the item count.</exception>
        public int FindString(string strValue)
        {
            return FindString(strValue, 0);
        }

        /// <summary>
        /// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string. The search starts at a specific starting index.
        /// </summary>
        ///	<returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
        ///	<param name="strValue">The text to search for. </param>
        ///	<param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
        public int FindString(string strValue, int intStartIndex)
        {
            ObjectCollection objItems = this.Items;

            for (int intIndex = intStartIndex; intIndex < objItems.Count; intIndex++)
            {
                if (objItems[intIndex] != null)
                {
                    string strLabel = GetItemText(objItems[intIndex]);
                    if (strLabel.StartsWith(strValue))
                    {
                        return intIndex;
                    }
                }
            }

            return -1;
        }

        /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string.</summary>
        /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
        /// <param name="strValue">The text to search for. </param>
        /// <filterpriority>1</filterpriority>
        public int FindStringExact(string strValue)
        {
            return this.FindStringExact(strValue, -1);
        }


        /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string. The search starts at a specific starting index.</summary>
        /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
        /// <param name="strValue">The text to search for. </param>
        /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
        /// <filterpriority>1</filterpriority>
        public int FindStringExact(string strValue, int intStartIndex)
        {
            if (strValue == null)
            {
                return -1;
            }
            int intIndex = (this.Items == null) ? 0 : this.Items.Count;
            if (intIndex == 0)
            {
                return -1;
            }
            if ((intStartIndex < -1) || (intStartIndex >= intIndex))
            {
                throw new ArgumentOutOfRangeException("intStartIndex");
            }
            return base.FindStringInternal(strValue, this.Items, intStartIndex, true);
        }


        /// <summary>
        /// Swaps the items.
        /// </summary>
        /// <param name="intIndexA">The int index A.</param>
        /// <param name="intIndexB">The int index B.</param>
        public virtual void SwapItems(int intIndexA, int intIndexB)
        {
            //Swap in the object collection
            mobjItems.SwapItems(intIndexA, intIndexB);

            // Clear selected index array
            this.InvalidateSelectionCache();

            this.Update();
        }

        /// <summary>
        /// Creates the item collection.
        /// </summary>
        protected virtual ListBox.ObjectCollection CreateItemCollection()
        {
            return new ListBox.ObjectCollection(this);
        }

        /// <summary>
        /// Validates that there is no data source
        /// </summary>
        private void CheckNoDataSource()
        {
            // If data source is not empte
            if (base.DataSource != null)
            {
                throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
            }
        }


        /// <summary>
        /// Sorts the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        protected virtual void Sort()
        {
            ObjectCollection objItems = this.Items;

            // Validate no data source
            this.CheckNoDataSource();

            // Get selected items
            SelectedObjectCollection objSelectedItems = this.SelectedItems;

            // Is is sorted and there are items
            if (this.Sorted && (objItems != null))
            {
                // Sorts internaly the items
                objItems.InternalSort();
            }
        }

        /// <summary>
        /// Gets the height of the preferd item font.        
        /// </summary>
        /// <returns></returns>
        internal int GetPreferdItemHeight()
        {
            //Get the current skin
            ListBoxSkin objListBoxSkin = this.Skin as ListBoxSkin;

            //If skin exists
            if (objListBoxSkin != null)
            {
                int intVerticalBorder = 0;

                // Get the arrow icon padding value
                PaddingValue objPaddingValue = (objListBoxSkin.CellStyle).Padding as PaddingValue;
                
                BorderValue objBorderValue = (objListBoxSkin.CellStyle).Border as BorderValue;
                if (objBorderValue != null)
                {
                    if (objBorderValue.Style != Forms.BorderStyle.None)
                    {
                        intVerticalBorder = objBorderValue.Width.Bottom + objBorderValue.Width.Top;
                    }
                }

                //The default Color box height
                int intColorBoxHeight = 0;

                //If we need to get the color height
                if (this.ShouldRenderColor())
                {
                    //Get Color Box Height
                    intColorBoxHeight = objListBoxSkin.ListBoxColorBoxHeight;
                }

                //The default image box height
                int intImageBoxHeight = 0;

                //If we need to get the Image height
                if (this.ShouldRenderImage())
                {
                    intImageBoxHeight = objListBoxSkin.ListBoxImageCellHeight;
                }

                //Set the default padding
                int intPaddingOffset = 0;

                //If we go an objPaddingValue sum the offset height of the item
                if (objPaddingValue != null)
                {
                    intPaddingOffset = objPaddingValue.Top + objPaddingValue.Bottom;
                }

                // Get the bigger value between the Font.Height anf the color box height
                int intBaseHeight = Math.Max(CommonUtils.GetFontHeight(this.Font), intColorBoxHeight);

                // Get the bigger value between the Base Height anf the image box height
                intBaseHeight = Math.Max(intImageBoxHeight, intBaseHeight);

                //Return the calculated max height
                return intBaseHeight + intPaddingOffset + intVerticalBorder;
            }
            return 0;
        }
        #endregion Methods

        #region Should Serialze Methods


        /// <summary>
        /// Should serialize selection mode.
        /// </summary>
        protected virtual bool ShouldSerializeSelectionMode()
        {
            return SelectionMode != SelectionMode.MultiSimple;
        }


        #endregion Should Serialze Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance is delayed drawing.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is delayed drawing; otherwise, <c>false</c>.
        /// </value>
        protected override bool IsDelayedDrawing
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> are sorted alphabetically.
        /// </summary>
        ///	<returns>true if items in the control are sorted; otherwise, false. The default is false.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ListBoxSortedDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool Sorted
        {
            get
            {
                // Getting the value
                return this.GetValue<bool>(ListBox.SortedProperty);
            }
            set
            {
                // If the value has changed
                if (this.SetValue<bool>(ListBox.SortedProperty, value))
                {
                    // If there are items and new value was added
                    ObjectCollection objObjectCollection = this.Items;
                    if ((value && (objObjectCollection != null)) && (objObjectCollection.Count >= 1))
                    {
                        // Sort items
                        this.Sort();
                    }

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the method in which items are selected in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values. The default is SelectionMode.One.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), DefaultValue(SelectionMode.One), SRDescription("ListBoxSelectionModeDescr")]
        public SelectionMode SelectionMode
        {
            get
            {
                // Get the value
                return this.GetValue<SelectionMode>(ListBox.ModeProperty);
            }
            set
            {
                // Get exist selection mode.
                SelectionMode enmSelectionMode = this.SelectionMode;

                // If the value has changed
                if (this.SetValue<SelectionMode>(ListBox.ModeProperty, value))
                {
                    // In None selection mode - clear all selected objects.                    
                    if (value == SelectionMode.None)
                    {
                        ResetSelection();
                    }
                    // Check if current selection mode is single and previous selection mode was multiple.
                    else if (value == SelectionMode.One &&
                            (enmSelectionMode == SelectionMode.MultiExtended || enmSelectionMode == SelectionMode.MultiSimple))
                    {
                        // Applies a single selection mode.
                        ApplySingleSelectionMode();
                    }

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Applies a single selection mode.
        /// </summary>
        private void ApplySingleSelectionMode()
        {
            // Gets items.
            ObjectCollection objItems = this.Items;
            if (objItems != null)
            {
                // Create an indexes array list.
                ArrayList arrSelectedIndexes = new ArrayList();

                // Loop through the items collection 
                for (int i = 0; i < objItems.Count; i++)
                {
                    // Check if current item is selected.
                    if (objItems.GetSelected(i))
                    {
                        // Add selected index to the array.
                        arrSelectedIndexes.Add(i);
                    }
                }

                // Loop through all selected indexes beside the last. 
                for (int i = 0; i < arrSelectedIndexes.Count - 1; i++)
                {
                    // Unselect current index.
                    objItems.SetSelected(Convert.ToInt32(arrSelectedIndexes[i]), false);
                }
            }
        }

        private bool CheckBoxesInternal
        {
            get
            {
                return this.GetValue<bool>(ListBox.CheckBoxesProperty);
            }
            set
            {
                this.SetValue<bool>(ListBox.CheckBoxesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [check boxes].
        /// </summary>
        /// <value><c>true</c> if [check boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public virtual bool CheckBoxes
        {
            get
            {
                // Getting the value
                return CheckBoxesInternal;
            }
            set
            {
                // If value has changed
                if (this.CheckBoxesInternal != value)
                {
                    this.CheckBoxesInternal = value;

                    if (value)
                    {
                        this.RadioBoxesInternal = false;
                    }


                    this.Update();
                }
            }
        }

        private bool RadioBoxesInternal
        {
            get
            {
                return this.GetValue<bool>(ListBox.RadioBoxesProperty);
            }
            set
            {
                this.SetValue<bool>(ListBox.RadioBoxesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [radio boxes].
        /// </summary>
        /// <value><c>true</c> if [radio boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public virtual bool RadioBoxes
        {
            get
            {
                return RadioBoxesInternal;
            }
            set
            {
                if (this.RadioBoxesInternal != value)
                {
                    RadioBoxesInternal = value;
                    this.Update();

                    if (value)
                    {
                        this.CheckBoxesInternal = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>An <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</returns>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        [SRCategory("CatData"), SRDescription("ListBoxItemsDescr"), Localizable(true)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        /// <summary>
        /// The list box item collection
        /// </summary>
        public ObjectCollection Items
        {
            get
            {
                // Get the value
                return mobjItems;
            }
        }

        /// <summary>
        /// Gets or sets the zero-based index of the currently selected item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
        ///	<exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property is set to None.</exception>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than -1 or greater than or equal to the item count.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), Bindable(true), SRDescription("ListBoxSelectedIndexDescr")]
        public override int SelectedIndex
        {
            get
            {
                // Esure selection caching is valid
                this.EnsureSelectionCache();

                if (mobjCachedSelectedIndexes.Count > 0)
                {
                    return mobjCachedSelectedIndexes[0];
                }

                return -1;
            }
            set
            {
                // If new index value is inside the range
                if (this.Items.Count > value)
                {
                    // If the value is valid (not -1)
                    if (value >= 0)
                    {
                        switch (this.SelectionMode)
                        {
                            case SelectionMode.None:
                                throw new ArgumentException(SR.GetString("ListBoxInvalidSelectionMode"), "SelectedIndex");
                                break;

                            case SelectionMode.One:
                                // Select only new value
                                SelectIndexes(value.ToString());
                                break;

                            default: //Multi
                                // Set selected to requested index
                                this.SetSelected(value, true);
                                break;
                        }

                        this.Update();
                        this.InvokeMethod("ListBox_ScrollIntoView", this.ID.ToString(), value.ToString());
                    }
                    else if (value == -1 && this.SelectedItems.Count > 0)
                    {
                        // Remove all selection
                        this.SelectedItems.Clear();

                        this.Update();
                        this.InvokeMethod("ListBox_ScrollIntoView", this.ID.ToString(), value.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Gets a collection that contains the zero-based indexes of all currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> containing the indexes of the currently selected items in the control. If no items are currently selected, an empty <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> is returned.</returns>
        [SRDescription("ListBoxSelectedIndicesDescr"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SelectedIndexCollection SelectedIndices
        {
            get
            {
                // Esure selection caching is valid
                this.EnsureSelectionCache();

                if (this.mobjSelectedIndexCollection == null)
                {
                    this.mobjSelectedIndexCollection = new ListBox.SelectedIndexCollection(this);
                }
                return this.mobjSelectedIndexCollection;
            }
        }

        /// <summary>
        /// Gets the internal selected array list
        /// </summary>
        internal List<int> SelectedIndexesInternal
        {
            get
            {
                // Esure selection caching is valid
                this.EnsureSelectionCache();

                return mobjCachedSelectedIndexes;
            }
        }

        /// <summary>
        /// Gets or sets the currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>An object that represents the current selection in the control.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), Browsable(false), Bindable(true)]
        public object SelectedItem
        {
            get
            {
                // Esure selection caching is valid
                this.EnsureSelectionCache();

                if (mobjCachedSelectedItems.Count > 0)
                {
                    return mobjCachedSelectedItems[0];
                }

                return null;
            }
            set
            {
                this.SelectedIndex = this.Items.IndexOf(value);
            }
        }



        /// <summary>
        /// Gets a collection containing the currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> containing the currently selected items in the control.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ListBoxSelectedItemsDescr"), Browsable(false)]
        public ListBox.SelectedObjectCollection SelectedItems
        {
            get
            {
                if (this.mobjSelectedObjectCollection == null)
                {
                    this.mobjSelectedObjectCollection = new ListBox.SelectedObjectCollection(this);
                }
                return this.mobjSelectedObjectCollection;
            }
        }


        /// <summary>
        /// Gets the internal selected array list
        /// </summary>
        internal ArrayList SelectedItemsInternal
        {
            get
            {
                // Esure selection caching is valid
                this.EnsureSelectionCache();

                return mobjCachedSelectedItems;
            }
        }

        /// <summary>
        /// Invalidates the selected items.
        /// </summary>
        private void EnsureSelectionCache()
        {
            // If either items or indexs cache is null
            if (mobjCachedSelectedItems == null || mobjCachedSelectedIndexes == null)
            {
                //Init the collection
                mobjCachedSelectedItems = new ArrayList();

                //Init the collection
                mobjCachedSelectedIndexes = new List<int>();

                //Get the items
                ObjectCollection objItems = this.Items;

                //loop through the items collection 
                for (int i = 0; i < objItems.Count; i++)
                {
                    //Get the selected status of the current item(index)
                    if (objItems.GetSelected(i))
                    {
                        //Add to the array the selected index
                        mobjCachedSelectedIndexes.Add(i);

                        //Add to the array the selected item
                        mobjCachedSelectedItems.Add(objItems[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Invalidates the selection cache
        /// </summary>
        private void InvalidateSelectionCache()
        {
            mobjCachedSelectedItems = null;
            mobjCachedSelectedIndexes = null;
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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


        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public override string Text
        {
            get
            {
                if ((this.SelectionMode == SelectionMode.None) || (this.SelectedItem == null))
                {
                    return base.Text;
                }
                if (base.FormattingEnabled)
                {
                    return base.GetItemText(this.SelectedItem);
                }
                return base.FilterItemOnProperty(this.SelectedItem).ToString();
            }
            set
            {
                // Set base text
                base.Text = value;

                // Check that selection mode is not none and value is not null
                if (((this.SelectionMode != SelectionMode.None) && (value != null)) &&
                    // Check that there is no selected item and if there is a selected item that it's text is not equals to the new value
                    ((this.SelectedItem == null) || !value.Equals(base.GetItemText(this.SelectedItem))))
                {
                    // Get items count
                    int count = this.Items.Count;

                    // Loop on all items and look for item with same text as in the new value
                    for (int i = 0; i < count; i++)
                    {
                        if (string.Compare(value, base.GetItemText(this.Items[i]), true, CultureInfo.InvariantCulture) == 0)
                        {
                            // Select the index of the item with the same text value
                            this.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [multi column].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [multi column]; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MultiColumn
        {
            get
            {
                return this.GetValue<bool>(ListBox.MultiColumnProperty);
            }
            set
            {
                this.SetValue<bool>(ListBox.MultiColumnProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the column width.
        /// </summary>
        /// <value>
        ///   The width of the columns
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), SRDescription("ListBoxColumnWidthDescr"), Localizable(true), DefaultValue(0)]
        public int ColumnWidth
        {
            get
            {
                return this.GetValue<int>(ListBox.ColumnWidthProperty);
            }
            set
            {
                this.SetValue<int>(ListBox.ColumnWidthProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [integral height].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [integral height]; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IntegralHeight
        {
            get
            {
                return this.GetValue<bool>(ListBox.IntegralHeightProperty);
            }
            set
            {
                this.SetValue<bool>(ListBox.IntegralHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the index of the top.
        /// </summary>
        /// <value>
        /// The index of the top.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int TopIndex
        {
            get
            {
                return this.GetValue<int>(ListBox.TopIndexProperty);
            }
            set
            {
                this.SetValue<int>(ListBox.TopIndexProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the vertical scroll bar is shown at all times.</summary>
        /// <returns>true if the vertical scroll bar should always be displayed; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), SRDescription("ListBoxScrollIsVisibleDescr"), DefaultValue(false), Localizable(true)]
        public bool ScrollAlwaysVisible
        {
            get
            {
                return false;
            }
            set
            { }
        }


        /// <summary>Gets or sets a value indicating whether a horizontal scroll bar is displayed in the control.</summary>
        /// <returns>true to display a horizontal scroll bar in the control; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ListBoxHorizontalScrollbarDescr"), SRCategory("CatBehavior"), DefaultValue(false), Localizable(true)]
        public bool HorizontalScrollbar
        {
            get
            {
                return false;
            }
            set
            { }
        }


        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>
        /// The height of the item.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Obsolete("Setter not implemented. Added for migration compatibility")]
        public int ItemHeight
        {
            get
            {
                return this.GetPreferdItemHeight();
            }
            set
            {
            }
        }


        #endregion Properties
    }

    #endregion ListBox Class

}
