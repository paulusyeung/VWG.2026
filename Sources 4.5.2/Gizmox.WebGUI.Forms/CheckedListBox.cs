#region Using

using System;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums



    #endregion Enums

    #region CheckedListBox Class

    /// <summary>
    /// The item check delgate
    /// </summary>
    public delegate void ItemCheckHandler(object objSender, ItemCheckEventArgs objArgs);

    /// <summary>
    /// Summary description for CheckedListBox.
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxItemCategory("Common Controls")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(CheckedListBox), "CheckedListBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(CheckedListBox), "CheckedListBox.bmp")]
#endif

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [MetadataTag(WGTags.CheckedListBox)]
    [Skin(typeof(CheckedListBoxSkin))]
    [Serializable()]
    public class CheckedListBox : ListBox
    {

        #region Classes

        #region CheckedItemCollection Class

        /// <summary>
        /// Encapsulates the collection of checked items, including items in 
        /// an indeterminate state, in a <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox">
        /// </see> control.
        /// </summary>
        [Serializable()]
        public class CheckedItemCollection : IList, ICollection, IEnumerable
        {

            private CheckedListBox mobjCheckedListBox;


            internal CheckedItemCollection(CheckedListBox objCheckedListBox)
            {
                mobjCheckedListBox = objCheckedListBox;
            }

            private ArrayList InternalCheckedObjects
            {
                get
                {
                    return mobjCheckedListBox.InternalCheckedObjects;
                }
            }

            /// <summary>Determines whether the specified item is located in the collection.</summary>
            /// <returns>true if item is in the collection; otherwise, false.</returns>
            /// <param name="objItem">An object from the items collection. </param>
            public bool Contains(object objItem)
            {
                return this.InternalCheckedObjects.Contains(objItem);
            }

            /// <summary>Copies the entire collection into an existing array at a specified location within the array.</summary>
            /// <param name="objDestinationArray">The destination array. </param>
            /// <param name="index">The zero-based relative index in dest at which copying begins. </param>
            /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
            /// <exception cref="T:System.RankException">array is multidimensional. </exception>
            /// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
            /// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
            public void CopyTo(Array objDestinationArray, int index)
            {
                this.InternalCheckedObjects.CopyTo(objDestinationArray, index);
            }


            /// <summary>Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItems"></see> collection.</summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
            public IEnumerator GetEnumerator()
            {
                return this.InternalCheckedObjects.GetEnumerator();
            }

            /// <summary>Returns an index into the collection of checked items.</summary>
            /// <returns>The index of the object in the checked item collection or -1 if the object is not in the collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
            /// <param name="objItem">The object whose index you want to retrieve. This object must belong to the checked items collection. </param>
            public int IndexOf(object objItem)
            {
                return this.InternalCheckedObjects.IndexOf(objItem);
            }



            int IList.Add(object objValue)
            {
                return -1;
            }

            void IList.Clear()
            {

            }

            void IList.Insert(int index, object objValue)
            {
            }

            void IList.Remove(object objValue)
            {
            }

            void IList.RemoveAt(int index)
            {
            }


            /// <summary>Gets the number of items in the collection.</summary>
            /// <returns>The number of items in the collection.</returns>
            public int Count
            {
                get
                {
                    return this.InternalCheckedObjects.Count;
                }
            }

            /// <summary>Gets a value indicating if the collection is read-only.</summary>
            /// <returns>Always true.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            /// <summary>Gets an object in the checked items collection.</summary>
            /// <returns>The object at the specified index. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
            /// <param name="index">An index into the collection of checked items. This collection index corresponds to the index of the checked item. </param>
            /// <exception cref="T:System.NotSupportedException">The object cannot be set.</exception>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
            public object this[int index]
            {
                get
                {
                    return this.InternalCheckedObjects[index];
                }
                set
                {
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
                    return this.InternalCheckedObjects.SyncRoot;
                }
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }
        }

        #endregion

        #region CheckedIndexCollection Class

        /// <summary>
        /// Encapsulates the collection of indexes of checked items 
        /// (including items in an indeterminate state) in a 
        /// <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
        /// </summary>
        [Serializable()]
        public class CheckedIndexCollection : IList, ICollection, IEnumerable
        {
            private CheckedListBox mobjCheckedListBox;

            internal CheckedIndexCollection(CheckedListBox objCheckedListBox)
            {
                mobjCheckedListBox = objCheckedListBox;

            }

            private ArrayList InternalCheckedIndexes
            {
                get
                {
                    return mobjCheckedListBox.InternalCheckedIndexes;
                }
            }

            /// <summary>Determines whether the specified index is located in the collection.</summary>
            /// <returns>true if the specified index from the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> is an item in this collection; otherwise, false.</returns>
            /// <param name="index">The index to locate in the collection. </param>
            public bool Contains(int index)
            {
                return this.InternalCheckedIndexes.Contains(index);
            }

            /// <summary>Copies the entire collection into an existing array at a specified location within the array.</summary>
            /// <param name="objDestinationArray">The destination array. </param>
            /// <param name="index">The zero-based relative index in dest at which copying begins. </param>
            /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
            /// <exception cref="T:System.RankException">array is multidimensional. </exception>
            /// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
            /// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
            public void CopyTo(Array objDestinationArray, int index)
            {
                this.InternalCheckedIndexes.CopyTo(objDestinationArray, index);
            }

            /// <summary>Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndices"></see> collection.</summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
            public IEnumerator GetEnumerator()
            {
                return this.InternalCheckedIndexes.GetEnumerator();
            }

            /// <summary>Returns an index into the collection of checked indexes.</summary>
            /// <returns>The index that specifies the index of the checked item or -1 if the index parameter is not in the checked indexes collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
            /// <param name="index">The index of the checked item. </param>
            public int IndexOf(int index)
            {
                return this.InternalCheckedIndexes.IndexOf(index);
            }

            int IList.Add(object objValue)
            {
                return -1;
            }

            void IList.Clear()
            {
            }

            bool IList.Contains(object objIndex)
            {
                return false;
            }

            int IList.IndexOf(object objIndex)
            {
                return -1;
            }

            void IList.Insert(int index, object objValue)
            {
            }

            void IList.Remove(object objValue)
            {
            }

            void IList.RemoveAt(int index)
            {
            }


            /// <summary>Gets the number of checked items.</summary>
            /// <returns>The number of indexes in the collection.</returns>
            public int Count
            {
                get
                {
                    return this.InternalCheckedIndexes.Count;
                }
            }

            /// <summary>Gets a value indicating whether the collection is read-only.</summary>
            /// <returns>true in all cases.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            /// <summary>Gets the index of a checked item in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see> control.</summary>
            /// <returns>The index of the checked item. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
            /// <param name="index">An index into the checked indexes collection. This index specifies the index of the checked item you want to retrieve. </param>
            /// <exception cref="T:System.ArgumentException">The index is less than zero.-or- The index is not in the collection. </exception>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
            public int this[int index]
            {
                get
                {
                    return (int)this.InternalCheckedIndexes[index];
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
                    return this.InternalCheckedIndexes.SyncRoot;
                }
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return this.InternalCheckedIndexes[index];
                }
                set
                {
                }
            }



        }


        #endregion

        #endregion

        #region Class Members

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private ArrayList mobjCachedCheckedIndexes = null;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private ArrayList mobjCachedCheckedObjects = null;

        /// <summary>
        /// The CheckOnClickProperty property registration.
        /// </summary>
        private static readonly SerializableProperty CheckOnClickProperty = SerializableProperty.Register("CheckOnClick", typeof(bool), typeof(CheckedListBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The ItemCheck event registration.
        /// </summary>
        private static readonly SerializableEvent ItemCheckEvent = SerializableEvent.Register("ItemCheck", typeof(ItemCheckHandler), typeof(CheckedListBox));

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private CheckedIndexCollection mobjCheckedIndexCollection = null;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private CheckedItemCollection mobjCheckedItemCollection = null;

        /// <summary>
        /// Occurs when the checked state of an item changes.
        /// </summary>
        public event ItemCheckHandler ItemCheck
        {
            add
            {
                this.AddCriticalHandler(CheckedListBox.ItemCheckEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(CheckedListBox.ItemCheckEvent, value);
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
        /// Gets the hanlder for the ItemCheck event.
        /// </summary>
        private ItemCheckHandler ItemCheckHandler
        {
            get
            {
                return (ItemCheckHandler)this.GetHandler(CheckedListBox.ItemCheckEvent);
            }
        }

        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="CheckedListBox"/> instance.
        /// </summary>
        public CheckedListBox()
        {
            // Set default selection mode
            this.SelectionMode = SelectionMode.One;

            // Set the control style
            base.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion C'Tor\D'Tor

        #region Methods

        #region Render

        /// <summary>
        /// Renders the item attributes.
        /// </summary>
        /// <param name="objWriter">Writer.</param>
        /// <param name="objItem">Item.</param>
        /// <param name="intIndex">Item index.</param>
        internal protected override void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
        {
            RenderItemAttributes(objWriter, objItem, intIndex, false, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="objWriter"></param>
        /// <param name="objItem"></param>
        /// <param name="intIndex"></param>
        /// <param name="blnShouldRenderItemImage"></param>
        /// <param name="blnShouldRenderItemColor"></param>
        protected internal override void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor)
        {
            base.RenderItemAttributes(objWriter, objItem, intIndex, blnShouldRenderItemImage, blnShouldRenderItemColor);

            CheckState enmCheckState = this.Items.GetCheckedState(intIndex);

            // Write checked/indeterminate.
            if (enmCheckState != CheckState.Unchecked)
            {
                objWriter.WriteAttributeString(WGAttributes.Checked, Convert.ToInt32(enmCheckState).ToString());
            }
        }

        /// <summary>
        /// Renders the controls attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderCheckOnClick(objContext, objWriter, false);
        }

        /// <summary>
        /// Renders the check on click.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnUpdateParams">if set to <c>true</c> update params.</param>
        private void RenderCheckOnClick(IContext objContext, IAttributeWriter objWriter, bool blnUpdateParams)
        {
            //If the control is set to check on click 
            if (this.CheckOnClick)
            {
                //write check on clikc attribute
                objWriter.WriteAttributeString(WGAttributes.CheckOnClick, "1");
            }
            else if (blnUpdateParams)
            {
                //write check on clikc attribute
                objWriter.WriteAttributeString(WGAttributes.CheckOnClick, "0");
            }
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
                case "CheckedChange":
                    CheckIndexes(objEvent["Indexes"] as string);
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
            if (ItemCheckHandler != null) objEvents.Set(WGEvents.ValueChange);
            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("CheckedChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Checks the indexes.
        /// </summary>
        /// <param name="strIndexes">indexes.</param>
        private void CheckIndexes(string strIndexes)
        {
            bool blnHasChanged = false;
            bool blnUpdateClient = false;

            // Get indexes string list
            List<string> arrIndexes = new List<string>(strIndexes.Split(','));

            //Get the items object
            ObjectCollection objItems = this.Items;

            //Get the items count
            int intItemsCount = objItems.Count;

            // Create image of current items check state
            List<bool> objItemsCheck = new List<bool>(intItemsCount);

            //loop through the items collection  
            for (int i = 0; i < intItemsCount; i++)
            {
                // Get current check state
                objItemsCheck.Add(objItems.GetChecked(i));
            }

            //loop through the items collection  
            for (int i = 0; i < intItemsCount; i++)
            {
                ItemCheckEventArgs objItemCheckEventArgs;
                //if the item is in the Checked Indexes array
                if (arrIndexes.Contains(i.ToString()))
                {
                    //If the item is not checked at the moment
                    if (!objItemsCheck[i])
                    {
                        blnHasChanged = true;

                        objItemCheckEventArgs = new ItemCheckEventArgs(i, CheckState.Checked, CheckState.Unchecked);

                        OnItemCheck(objItemCheckEventArgs);

                        if (objItemCheckEventArgs.NewValue == CheckState.Checked)
                        {
                            //Check it and raise an event
                            this.Items.SetChecked(i, true);
                        }
                        else
                        {
                            blnUpdateClient = true;
                        }
                    }
                }
                else if (objItemsCheck[i])
                {
                    blnHasChanged = true;

                    objItemCheckEventArgs = new ItemCheckEventArgs(i, CheckState.Unchecked, CheckState.Checked);

                    OnItemCheck(objItemCheckEventArgs);

                    if (objItemCheckEventArgs.NewValue == CheckState.Unchecked)
                    {
                        //UnCheck it and raise an event
                        this.Items.SetChecked(i, false);
                    }
                    else
                    {
                        blnUpdateClient = true;
                    }
                }
            }

            //If the checked items has been modifyed
            if (blnHasChanged)
            {
                //Rebuild the collections
                this.InvalidateCheckedItemsChache();
            }

            if (blnUpdateClient)
            {
                this.Update();
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.CheckedListBox.ItemCheck"></see> event.</summary>
        /// <param name="objItemCheckEventArgs">An <see cref="T:System.Windows.Forms.ItemCheckEventArgs"></see> that contains the event data.</param>
        protected virtual void OnItemCheck(ItemCheckEventArgs objItemCheckEventArgs)
        {
            // Raise event if needed
            ItemCheckHandler objEventHandler = this.ItemCheckHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objItemCheckEventArgs);
            }
        }

        #endregion Events

        #region Checking Methods

        /// <summary>
        /// Gets the item checked value.
        /// </summary>
        /// <param name="intIndex">Item index.</param>
        /// <returns></returns>
        public bool GetItemChecked(int intIndex)
        {
            if (intIndex >= 0 && intIndex < this.Items.Count)
            {
                //Get the checked status of the current item
                return this.Items.GetChecked(intIndex);
            }

            return false;
        }

        /// <summary>
        /// Gets the checkstate of the item.
        /// </summary>
        /// <param name="intIndex">Index of the int.</param>
        /// <returns></returns>
        public CheckState GetItemCheckState(int intIndex)
        {
            //Get the checked status of the item
            return this.Items.GetCheckedState(intIndex);
        }

        /// <summary>
        /// Sets the item checked status.
        /// </summary>
        /// <param name="intIndex">Item index.</param>
        /// <param name="blnChecked">Is checked.</param>
        public void SetItemChecked(int intIndex, bool blnChecked)
        {
            this.SetItemCheckState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);
        }

        /// <summary>
        /// Sets the item checkstate.
        /// </summary>
        /// <param name="intIndex">Index of the item.</param>
        /// <param name="enmNewCheckState">CheckState</param>
        public void SetItemCheckState(int intIndex, CheckState enmNewCheckState)
        {
            // Check that there are items
            if (Items.Count > 0)
            {
                // check valid range
                if (intIndex > Items.Count || intIndex < 0)
                {
                    throw new ArgumentException();
                }

                //get current state
                CheckState enmCurrentCheckState = this.Items.GetCheckedState(intIndex);

                if (enmCurrentCheckState != enmNewCheckState)
                {
                    ItemCheckEventArgs objItemCheckEventArgs = new ItemCheckEventArgs(intIndex, enmNewCheckState, enmCurrentCheckState);

                    //Raise item check event.
                    if (ItemCheckHandler != null)
                    {
                        ItemCheckHandler(this, objItemCheckEventArgs);
                    }

                    // Validate state still different(after event)
                    if (objItemCheckEventArgs.NewValue != enmCurrentCheckState)
                    {
                        // Set checkstate
                        this.Items.SetCheckedState(intIndex, objItemCheckEventArgs.NewValue);

                        //Rebuild the collections
                        this.InvalidateCheckedItemsChache();

                        this.Update();
                    }
                }
            }
        }

        #endregion Checking Methods

        /// <summary>
        ///
        /// </summary>
        protected override ListBox.ObjectCollection CreateItemCollection()
        {
            return new CheckedListBox.ObjectCollection(this);
        }

        /// <summary>
        /// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
        /// </summary>
        ///	<returns>An <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
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
        new public CheckedListBox.ObjectCollection Items
        {
            get
            {
                return (CheckedListBox.ObjectCollection)base.Items;
            }
        }

        /// <summary>Collection of checked indexes in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public CheckedIndexCollection CheckedIndices
        {
            get
            {
                if (mobjCheckedIndexCollection == null)
                {
                    mobjCheckedIndexCollection = new CheckedIndexCollection(this);
                }
                return mobjCheckedIndexCollection;
            }
        }

        /// <summary>Collection of checked items in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckedItemCollection CheckedItems
        {
            get
            {
                if (mobjCheckedItemCollection == null)
                {
                    mobjCheckedItemCollection = new CheckedItemCollection(this);
                }
                return mobjCheckedItemCollection;
            }
        }


        /// <summary>
        /// Gets the internal checked indexes.
        /// </summary>
        /// <value>The internal checked indexes.</value>
        private ArrayList InternalCheckedIndexes
        {
            get
            {
                // Ensure that chache checked state is valid
                this.EnsureCheckedItemsCache();

                return mobjCachedCheckedIndexes;
            }
        }

        /// <summary>
        /// Gets the internal checked objects.
        /// </summary>
        /// <value>The internal checked objects.</value>
        private ArrayList InternalCheckedObjects
        {
            get
            {
                // Ensure that chache checked state is valid
                this.EnsureCheckedItemsCache();

                return mobjCachedCheckedObjects;
            }
        }

        /// <summary>
        /// Invalidates the checked items.
        /// </summary>
        private void EnsureCheckedItemsCache()
        {
            // If either chached objects or indexes is invalid
            if (mobjCachedCheckedObjects == null || mobjCachedCheckedIndexes == null)
            {
                //Init the collection
                mobjCachedCheckedObjects = new ArrayList();
                mobjCachedCheckedIndexes = new ArrayList();


                // Get the items collection
                ObjectCollection objItems = this.Items;
                if (objItems != null)
                {
                    //Get the items count
                    int intItemsCount = objItems.Count;

                    //loop through the items collection 
                    for (int i = 0; i < intItemsCount; i++)
                    {
                        //Get the checked status of the current item(index)
                        if (objItems.GetChecked(i))
                        {
                            //Add to the array the checked item
                            mobjCachedCheckedObjects.Add(objItems[i]);

                            //Add to the array the index of the checked item
                            mobjCachedCheckedIndexes.Add(i);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Invalidates the checked items.
        /// </summary>
        private void InvalidateCheckedItemsChache()
        {
            // Clear the checked items collections
            mobjCachedCheckedObjects = null;
            mobjCachedCheckedIndexes = null;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [radio boxes].
        /// </summary>
        /// <value><c>true</c> if [radio boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete")]
        public override bool RadioBoxes
        {
            get
            {
                return base.RadioBoxes;
            }
            set
            {
                base.RadioBoxes = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [check boxes].
        /// </summary>
        /// <value><c>true</c> if [check boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete")]
        public override bool CheckBoxes
        {
            get
            {
                return base.CheckBoxes;
            }
            set
            {
                base.CheckBoxes = value;
            }
        }

        #endregion Methods

        #region Should Serialze Methods

        /// <summary>
        ///
        /// </summary>
        protected override bool ShouldSerializeSelectionMode()
        {
            return SelectionMode != SelectionMode.One;
        }


        #endregion Should Serialze Methods

        #region ObjectCollection Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        public new class ObjectCollection : ListBox.ObjectCollection
        {
            #region Class Members

            private CheckedListBox mobjParent = null;


            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            /// Creates a new <see cref="ObjectCollection"/> instance.
            /// </summary>
            internal ObjectCollection(CheckedListBox objParent)
                : base(objParent)
            {
                mobjParent = objParent;
            }


            #endregion C'Tor / D'Tor

            #region Methods

            /// <summary>
            /// Gets the checked.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <returns></returns>
            internal bool GetChecked(int intIndex)
            {
                //Return the checked state
                return this.GetCheckedState(intIndex) != CheckState.Unchecked;
            }

            /// <summary>
            /// Sets the checked.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <param name="blnChecked">if set to <c>true</c> [BLN checked].</param>
            /// <returns></returns>
            internal void SetChecked(int intIndex, bool blnChecked)
            {
                SetCheckedState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objItem"></param>
            /// <param name="blnChecked"></param>
            public int Add(object objItem, bool blnChecked)
            {
                int intIndex = base.Add(objItem);
                mobjParent.SetItemChecked(intIndex, blnChecked);
                return intIndex;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="objItem"></param>
            /// <param name="enmCheck"></param>
            public int Add(object objItem, CheckState enmCheck)
            {
                int intIndex = base.Add(objItem);
                mobjParent.SetItemChecked(intIndex, enmCheck == CheckState.Checked);
                return intIndex;
            }

            /// <summary>
            /// Removes the specified object from the collection.
            /// </summary>
            /// <param name="objItem">An object representing the item to remove from the collection.</param>
            public override void Remove(object objItem)
            {
                //Find the ListBoxItem to remove 
                ListBoxItem objFoundListBoxItem = GetListBoxItemByItem(objItem);

                //If exist
                if (objFoundListBoxItem != null && mobjParent != null)
                {
                    //if the item is checked
                    if (objFoundListBoxItem.CheckState != CheckState.Unchecked)
                    {
                        //refresh the chach
                        mobjParent.InvalidateCheckedItemsChache();
                    }
                }

                base.Remove(objItem);
            }

            #endregion Methods


            /// <summary>
            /// Gets the checkstate of the item at specified index.
            /// </summary>
            /// <param name="intIndex">Index of the item.</param>
            /// <returns>checkstate</returns>
            internal CheckState GetCheckedState(int intIndex)
            {
                if ((intIndex < 0) || (intIndex >= this.Count))
                {
                    throw new ArgumentException();
                }

                return mobjList[intIndex].CheckState;
            }

            /// <summary>
            /// Sets the checkstate of the item at specified index.
            /// </summary>
            /// <param name="intIndex">Index of the item.</param>
            /// <param name="enmNewCheckState">CheckState.</param>
            internal void SetCheckedState(int intIndex, CheckState enmNewCheckState)
            {
                if ((intIndex < 0) || (intIndex >= this.Count))
                {
                    throw new ArgumentException();
                }

                mobjList[intIndex].CheckState = enmNewCheckState;
            }
        }

        #endregion ObjectCollection Class

        #region Properties

        /// <summary>Gets or sets a value indicating whether the check box should be toggled when an item is selected.</summary>
        /// <returns>true if the check mark is applied immediately; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false), SRDescription("CheckedListBoxCheckOnClickDescr"), SRCategory("CatBehavior")]
        public bool CheckOnClick
        {
            get
            {
                // Getting the value
                return this.GetValue<bool>(CheckedListBox.CheckOnClickProperty);
            }
            set
            {
                //If value was changed
                if (this.SetValue<bool>(CheckedListBox.CheckOnClickProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderCheckOnClick(objContext, objWriter, true);
            }
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

        #endregion
    }

    #endregion CheckedListBox Class

    #region ItemCheckEventArgs Class

    /// <summary>
    ///
    /// </summary>    
    [Serializable()]
    public class ItemCheckEventArgs : EventArgs
    {
        #region Class Members

        private CheckState menmCurrentValue;

        private int mintIndex;

        private CheckState menmNewValue;


        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ItemCheckEventArgs"/> instance.
        /// </summary>
        /// <param name="intIndex">Int index.</param>
        /// <param name="enmNewCheckValue">Enm new check value.</param>
        /// <param name="enmCurrentValue">Enm current value.</param>
        public ItemCheckEventArgs(int intIndex, CheckState enmNewCheckValue, CheckState enmCurrentValue)
        {
            menmCurrentValue = enmCurrentValue;
            mintIndex = intIndex;
            menmNewValue = enmNewCheckValue;
        }


        #endregion C'Tor\D'Tor

        #region Properties

        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <value></value>
        public CheckState CurrentValue
        {
            get
            {
                return menmCurrentValue;
            }
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value></value>
        public int Index
        {
            get
            {
                return mintIndex;
            }
        }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value></value>
        public CheckState NewValue
        {
            get
            {
                return menmNewValue;
            }
            set
            {
                menmNewValue = value;
            }
        }


        #endregion Properties

    }

    #endregion ItemCheckEventArgs Class

}
