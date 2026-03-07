#region Using

using System;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using System.Data;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> style.
    /// </summary>	
    public enum ComboBoxStyle
    {
        /// <summary>
        /// The text portion is editable. The user must click the arrow button to display the list portion. This is the default style.
        /// </summary>
        DropDown = 1,
        /// <summary>
        /// The user cannot directly edit the text portion. The user must click the arrow button to display the list portion. The list displays only if <see cref="P:Gizmox.WebGUI.Forms.ComboBox.AutoCompleteMode"></see> is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteMode.Suggest"></see> or <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteMode.SuggestAppend"></see>.
        /// </summary>
        DropDownList = 2,
        /// <summary>
        /// The text portion is editable. The list portion is always visible.
        /// </summary>
        Simple = 0
    }

    /// <summary>
    /// Specifies the mode for the automatic completion feature used in the 
    /// ComboBox and TextBox controls.
    /// </summary>
    public enum AutoCompleteMode
    {
        /// <summary>
        /// Disables the automatic completion feature for the ComboBox and TextBox controls.
        /// </summary>
        None,
        /// <summary>
        /// Displays the auxiliary drop-down list associated with the edit control. 
        /// This drop-down is populated with one or more suggested completion strings.
        /// </summary>
        Suggest,
        /// <summary>
        /// Appends the remainder of the most likely candidate string to the existing 
        /// characters, highlighting the appended characters.
        /// </summary>
        Append,
        /// <summary>
        /// Applies both Suggest and Append options.
        /// </summary>
        SuggestAppend
    }

    /// <summary>
    /// Specifies the source for ComboBox and TextBox automatic completion functionality.
    /// </summary>
    public enum AutoCompleteSource
    {
        /// <summary>
        /// Specifies the equivalent of FileSystem and AllUrl as the source. 
        /// This is the default value when AutoCompleteMode has been set to a value other than 
        /// the default.
        /// </summary>
        AllSystemSources = 7,
        /// <summary>
        /// Specifies the equivalent of HistoryList and RecentlyUsedList as the source.
        /// </summary>
        AllUrl = 6,
        /// <summary>
        /// Specifies strings from a built-in AutoCompleteStringCollection as the source.
        /// </summary>
        CustomSource = 0x40,
        /// <summary>
        /// Specifies the file system as the source.
        /// </summary>
        FileSystem = 1,
        /// <summary>
        /// Specifies that only directory names and not file names will be automatically completed.
        /// </summary>
        FileSystemDirectories = 0x20,
        /// <summary>
        /// Includes the Uniform Resource Locators (URLs) in the history list.
        /// </summary>
        HistoryList = 2,
        /// <summary>
        /// Specifies that the items of the ComboBox represent the source.
        /// </summary>
        ListItems = 0x100,
        /// <summary>
        /// Specifies that no AutoCompleteSource is currently in use. 
        /// This is the default value of AutoCompleteSource.
        /// </summary>
        None = 0x80,
        /// <summary>
        /// Includes the Uniform Resource Locators (URLs) in the list of those URLs most recently used.
        /// </summary>
        RecentlyUsedList = 4
    }

    #endregion Enums

    #region ComboBox Class

    /// <summary>
    /// Represents a Gizmox.WebGUI.Forms combo box control.
    /// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ComboBox), "ComboBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ComboBox), "ComboBox.bmp")]
#endif

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451    
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45    
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultEvent("SelectedIndexChanged"), SRDescription("DescriptionComboBox")]

    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.ComboBox)]
    [Skin(typeof(ComboBoxSkin))]
    [Serializable()]
    public class ComboBox : ListControl
    {
        #region Classes

        #region ItemComparer Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        private sealed class ItemComparer : IComparer
        {
            #region Class Members

            private ComboBox mobjComboBox;

            #endregion

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemComparer"/> class.
            /// </summary>
            /// <param name="objComboBox">The combo box.</param>
            public ItemComparer(ComboBox objComboBox)
            {
                this.mobjComboBox = objComboBox;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Compares the specified item1.
            /// </summary>
            /// <param name="objItem1">The obj item1.</param>
            /// <param name="objItem2">The obj item2.</param>
            /// <returns></returns>
            public int Compare(object objItem1, object objItem2)
            {
                if (objItem1 == null)
                {
                    if (objItem2 == null)
                    {
                        return 0;
                    }
                    return -1;
                }
                if (objItem2 == null)
                {
                    return 1;
                }
                string strItem1 = this.mobjComboBox.GetItemText(objItem1);
                string strItem2 = this.mobjComboBox.GetItemText(objItem2);
                return Application.CurrentCulture.CompareInfo.Compare(strItem1, strItem2, CompareOptions.StringSort);
            }

            #endregion
        }

        #endregion

        #region ObjectCollection Class

        /// <summary>
        /// Represents the collection of items in a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
        /// </summary>
        [ListBindable(false)]
        [Serializable()]
        public class ObjectCollection : ICollection, IList
        {
            #region Class Members

            /// <summary>
            /// The owner tab control
            /// </summary>
            private ArrayList mobjList = null;

            /// <summary>
            /// The object collection parent control
            /// </summary>
            private ComboBox mobjParent = null;

            #endregion Class Members

            #region C'Tor

            /// <summary>
            /// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ComboBox.ObjectCollection"></see>.
            /// </summary>
            /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that owns this object collection. </param>
            protected internal ObjectCollection(ComboBox objOwner)
            {
                if (objOwner == null)
                {
                    throw new NullReferenceException("ComboBox.ObjectCollection has been initialized with a null owner");
                }
                // Initialize list
                mobjList = new ArrayList();

                // Set parent
                mobjParent = objOwner;
            }

            #endregion C'Tor

            #region Members

            /// <summary>
            /// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
            /// </summary>
            public bool IsSynchronized
            {
                get
                {
                    return mobjList.IsSynchronized;
                }
            }

            /// <summary>
            /// Gets the number of items in the collection.
            /// </summary>
            /// <returns>The number of items in the collection.</returns>
            public int Count
            {
                get
                {
                    return mobjList.Count;
                }
            }

            /// <summary>
            /// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
            /// </summary>
            /// <param name="objDestination">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
            /// <param name="intIndex">The zero-based index in the array at which copying begins.</param>
            public void CopyTo(Array objDestination, int intIndex)
            {
                mobjList.CopyTo(objDestination, intIndex);
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

            /// <summary>
            /// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
            /// </summary>
            /// <returns>The zero-based index of the item in the collection.</returns>
            /// <param name="objItem">An object representing the item to add to the collection. </param>
            /// <exception cref="T:System.ArgumentNullException">The item parameter was null. </exception>
            public virtual int Add(object objItem)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                int intIndex = this.AddInternal(objItem);
                mobjParent.Update();
                return intIndex;

            }

            /// <summary>
            /// Adds an item with sorting.
            /// </summary>
            /// <param name="objItem">The obj item.</param>
            /// <returns></returns>
            private int AddInternal(object objItem)
            {
                // Verifiy valid item
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }
                int intIndex = -1;
                if (!this.mobjParent.Sorted)
                {
                    intIndex = this.mobjList.Add(objItem);
                }
                else
                {
                    intIndex = this.mobjList.BinarySearch(objItem, this.Comparer);
                    if (intIndex < 0)
                    {
                        intIndex = ~intIndex;
                    }
                    this.mobjList.Insert(intIndex, objItem);
                }

                return intIndex;
            }

            private IComparer mobjComparer;

            /// <summary>
            /// Gets the comparer.
            /// </summary>
            private IComparer Comparer
            {
                get
                {
                    return mobjParent.ItemsComparer;
                }
            }

            /// <summary>
            /// Determines if the specified item is located within the collection.
            /// </summary>
            /// <returns>true if the item is located within the collection; otherwise, false.</returns>
            /// <param name="objValue">An object representing the item to locate in the collection. </param>
            public bool Contains(object objValue)
            {
                return mobjList.Contains(objValue);
            }

            /// <summary>
            /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
            /// </summary>
            /// <param name="arrObjects">An array of objects to add to the list. </param>
            /// <exception cref="T:System.ArgumentNullException">An item in the items parameter was null. </exception>
            public virtual void AddRange(Object[] arrObjects)
            {
                this.AddRangeInternal(arrObjects);
            }

            /// <summary>
            /// Adds the range internal.
            /// </summary>
            /// <param name="arrObjects">The objects.</param>
            internal void AddRangeInternal(Object[] arrObjects)
            {
                foreach (object objObject in arrObjects)
                {
                    this.AddInternal(objObject);
                }

                mobjParent.Update();
            }

            /// <summary>
            /// Adds the range internal.
            /// </summary>
            /// <param name="objObjects">The objects.</param>
            internal void AddRangeInternal(ICollection objObjects)
            {
                if (objObjects == null)
                {
                    throw new ArgumentNullException("objObjects");
                }

                foreach (object objObject in objObjects)
                {
                    this.AddInternal(objObject);
                }

                mobjParent.Update();
            }

            /// <summary>
            /// Sets the item with a new value.
            /// </summary>
            /// <param name="intIndex">The index.</param>
            /// <param name="objValue">The value.</param>
            internal void SetItemInternal(int intIndex, object objValue)
            {
                if (objValue == null)
                {
                    throw new ArgumentNullException("value");
                }
                if ((intIndex < 0) || (intIndex >= this.mobjList.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", intIndex.ToString() }));
                }

                //Set the selected ComboBox item with a new value set from the binding manager
                this.mobjList[intIndex] = objValue;

                //update the combo box
                mobjParent.Update();
            }

            /// <summary>
            /// Adds a range of objects.
            /// </summary>
            /// <param name="objObjects">objects.</param>
            public void AddRange(ICollection objObjects)
            {
                if (objObjects == null)
                {
                    throw new ArgumentNullException("objObjects");
                }

                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();

                this.AddRangeInternal(objObjects);
            }

            /// <summary>
            /// Removes the specified item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
            /// </summary>
            /// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the list. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
            public void Remove(object objValue)
            {
                mobjParent.Update();
                mobjList.Remove(objValue);
            }

            /// <summary>
            /// Returns an enumerator that can be used to iterate through the item collection.
            /// </summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
            public IEnumerator GetEnumerator()
            {
                return mobjList.GetEnumerator();
            }

            /// <summary>
            /// Clears the collection.
            /// </summary>
            internal void ClearInternal()
            {
                mobjList.Clear();
                mobjParent.Clear();
                mobjParent.Update();
            }

            /// <summary>
            /// Removes all items from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
            /// </summary>
            public void Clear()
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();
                this.ClearInternal();
            }

            /// <summary>
            /// Retrieves the index within the collection of the specified item.
            /// </summary>
            /// <returns>The zero-based index where the item is located within the collection; otherwise, -1.</returns>
            /// <param name="objValue">An object representing the item to locate in the collection. </param>
            /// <exception cref="T:System.ArgumentNullException">The value parameter was null. </exception>
            public int IndexOf(object objValue)
            {
                return mobjList.IndexOf(objValue);
            }

            /// <summary>
            /// Gets the <see cref="object"/> with the specified int index.
            /// </summary>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
            public object this[int intIndex]
            {
                get
                {
                    return mobjList[intIndex];
                }
                set
                {
                    if (this.mobjList != null && this.mobjList[intIndex] != value)
                    {
                        this.mobjList[intIndex] = value;
                        this.mobjParent.Update();
                    }
                }
            }

            /// <summary>
            /// Provides a way to initialize the collection from serialization
            /// </summary>
            /// <param name="arrItems"></param>
            internal void SetItemsInternal(object[] arrItems)
            {
                mobjList.AddRange(arrItems);
            }

            #endregion Members

            #region IList Members

            /// <summary>
            /// Gets a value indicating whether this collection can be modified.
            /// </summary>
            /// <returns>Always false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> at the specified index.
            /// </summary>
            object System.Collections.IList.this[int intIndex]
            {
                get
                {
                    return mobjList[intIndex];
                }
                set
                {
                    mobjList[intIndex] = value;
                }
            }

            /// <summary>
            /// Removes an item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> at the specified index.
            /// </summary>
            /// <param name="intIndex">The index of the item to remove. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
            public void RemoveAt(int intIndex)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();


                if ((intIndex < 0) || (intIndex >= mobjList.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", intIndex.ToString(CultureInfo.CurrentCulture) }));
                }

                //set the selected index property to skip event raise
                mobjParent.SetValue<int>(ComboBox.SelectedIndexProperty, -1);

                mobjList.RemoveAt(intIndex);
            
                mobjParent.UpdateText();
                mobjParent.UpdateParams(AttributeType.Control);

            }

            /// <summary>
            /// Inserts an item into the collection at the specified index.
            /// </summary>
            /// <returns>The zero-based index of the newly added item.</returns>
            /// <param name="objItem">An object representing the item to insert. </param>
            /// <param name="intIndex">The zero-based index location where the item is inserted. </param>
            /// <exception cref="T:System.ArgumentNullException">The item was null. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of items in the collection. </exception>
            public void Insert(int intIndex, object objItem)
            {
                // Ensure that no data source is assigned.
                this.mobjParent.CheckNoDataSource();
                mobjParent.Update();
                mobjList.Insert(intIndex, objItem);
            }

            /// <summary>
            /// For a description of this member, see <see cref="P:System.Collections.IList.IsFixedSize"></see>.
            /// </summary>
            /// <returns>false in all cases.</returns>
            public bool IsFixedSize
            {
                get
                {
                    // TODO:  Add ObjectCollection.IsFixedSize getter implementation
                    return false;
                }
            }

            #endregion IList Members
        }
        #endregion

        #endregion Classes

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to CharacterCasing property.
        /// </summary>
        private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(ComboBox), new SerializablePropertyMetadata(CharacterCasing.Normal));

        /// <summary>
        /// The mintDropDownWidth property registration.
        /// </summary>
        private static readonly SerializableProperty DropDownWidthProperty = SerializableProperty.Register("DropDownWidth", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to SelectionLength property.
        /// </summary>
        private static readonly SerializableProperty SelectionLengthProperty = SerializableProperty.Register("SelectionLength", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to SelectionStart property.
        /// </summary>
        private static readonly SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(0));

        /// <summary>
        /// The mblnSorted property registration.
        /// </summary>
        private static readonly SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The mintSelectedIndex property registration.
        /// </summary>
        private static readonly SerializableProperty SelectedIndexProperty = SerializableProperty.Register("SelectedIndex", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// The menmDropDownStyle property registration. 
        /// </summary>
        private static readonly SerializableProperty DropDownStyleProperty = SerializableProperty.Register("DropDownStyle", typeof(ComboBoxStyle), typeof(ComboBox), new SerializablePropertyMetadata(ComboBoxStyle.DropDown));

        /// <summary>
        /// The menmAutoCompleteMode property registration.
        /// </summary>
        private static readonly SerializableProperty AutoCompleteModeProperty = SerializableProperty.Register("AutoCompleteMode", typeof(AutoCompleteMode), typeof(ComboBox), new SerializablePropertyMetadata(AutoCompleteMode.None));

        /// <summary>
        /// The menmAutoCompleteSource property registration.
        /// </summary>
        private static readonly SerializableProperty AutoCompleteSourceProperty = SerializableProperty.Register("AutoCompleteSource", typeof(AutoCompleteSource), typeof(ComboBox), new SerializablePropertyMetadata(AutoCompleteSource.None));

        /// <summary>
        /// The CodeMember property registration.
        /// </summary>
        private static readonly SerializableProperty CodeMemberProperty = SerializableProperty.Register("CodeMember", typeof(string), typeof(ComboBox), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// The mintMaxItems property registration.
        /// </summary>
        private static readonly SerializableProperty MaxItemsProperty = SerializableProperty.Register("MaxItems", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(8));

        /// <summary>
        /// The SelectedIndexChangedQueued event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangedQueuedEvent = SerializableEvent.Register("SelectedIndexChangedQueued", typeof(EventHandler), typeof(ComboBox));

        /// <summary>
        /// The SelectedIndexChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ComboBox));

        /// <summary>
        /// The SelectionChangeCommitted event registration.
        /// </summary>
        private static readonly SerializableEvent SelectionChangeCommittedEvent = SerializableEvent.Register("SelectionChangeCommitted", typeof(EventHandler), typeof(ComboBox));

        /// <summary>
        /// The IntegralHeight property registration.
        /// </summary>
        private static readonly SerializableProperty IntegralHeightProperty = SerializableProperty.Register("IntegralHeight", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(true));

        /// <summary>
        /// The SelectedText property registration.
        /// </summary>
        private static readonly SerializableProperty SelectedTextProperty = SerializableProperty.Register("SelectedText", typeof(string), typeof(ComboBox));

        /// <summary>
        /// The MaxBindedDropDownItems property registration.
        /// </summary>
        private static readonly SerializableProperty MaxBoundDropDownItemsProperty = SerializableProperty.Register("MaxBindedDropDownItems", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// 
        /// </summary>
        private static SerializableProperty IsAutoCompleteProperty = SerializableProperty.Register("IsAutoComplete", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(true));

        /// <summary>
        /// The dropped down property
        /// </summary>
        private static readonly SerializableProperty DroppedDownProperty = SerializableProperty.Register("DroppedDown", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The drop down event
        /// </summary>
        private static readonly SerializableEvent DropDownEvent = SerializableEvent.Register("DropDown", typeof(EventHandler), typeof(ComboBox));

        /// <summary>
        /// The drop down closed event
        /// </summary>
        private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ComboBox));

        #endregion Serializable Properties

        /// <summary>
        /// Occurs when [selection change committed].
        /// </summary>
        [SRCategory("CatBehavior"), SRDescription("selectionChangeCommittedEventDescr")]
        public event EventHandler SelectionChangeCommitted
        {
            add
            {
                this.AddCriticalHandler(ComboBox.SelectionChangeCommittedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ComboBox.SelectionChangeCommittedEvent, value);
            }
        }

        /// <summary>
        /// Gets the selection change committed handler.
        /// </summary>
        private EventHandler SelectionChangeCommittedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ComboBox.SelectionChangeCommittedEvent);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedIndex"></see> property has changed.
        /// </summary>
        [SRDescription("selectedIndexChangedEventDescr"), SRCategory("CatBehavior")]
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                this.AddCriticalHandler(ComboBox.SelectedIndexChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ComboBox.SelectedIndexChangedEvent, value);
            }
        }


        /// <summary>
        /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
        /// </summary>
        [SRDescription("Occurs in client mode when the control selected index is changing."), Category("Client")]
        public event ClientEventHandler ClientSelectedIndexChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }


        /// <summary>
        /// Occurs when [client text changed].
        /// </summary>
        [SRDescription("Occurs in client mode when the control text has been changed."), Category("Client")]
        public event ClientEventHandler ClientTextChanged
        {
            add
            {
                this.AddClientHandler("TextChange", value);
            }
            remove
            {
                this.RemoveClientHandler("TextChange", value);
            }
        }

        /// <summary>
        /// Occurs when [client text changed].
        /// </summary>
        [SRDescription("Occurs when DropDown window displayed in Client mode."), Category("Client")]
        public event ClientEventHandler ClientDropDown
        {
            add
            {
                this.AddClientHandler("DropDownWindow", value);
            }
            remove
            {
                this.RemoveClientHandler("DropDownWindow", value);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedItem"></see> property has changed.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler SelectedItemChanged
        {
            add
            {
                this.SelectedIndexChanged += value;
            }
            remove
            {
                this.SelectedIndexChanged -= value;
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedIndexChanged event.
        /// </summary>
        private EventHandler SelectedIndexChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ComboBox.SelectedIndexChangedEvent);
            }
        }

        /// <summary>Gets or sets the number of characters selected in the editable portion of the combo box.</summary>
        /// <returns>The number of characters selected in the combo box.</returns>
        /// <exception cref="T:System.ArgumentException">The value was less than zero. </exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("TextBoxSelectionLengthDescr"), SRCategory("CatAppearance"), Browsable(false)]
        public virtual int SelectionLength
        {
            get
            {
                return this.GetValue<int>(ComboBox.SelectionLengthProperty);
            }
            set
            {
                // Validate the new value.
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("SelectionLength", SR.GetString("InvalidArgument", new object[] { "SelectionLength", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // If the new value is different value from the current value, change it.
                if (this.SetValue<int>(ComboBox.SelectionLengthProperty, value))
                {
                    // Invoke the actual text selection in the client.
                    this.InvokeSelection(this.SelectionStart, value);
                }

            }
        }

        /// <summary>Gets or sets the starting index of text selected in the combo box.</summary>
        /// <returns>The zero-based index of the first character in the string of the current text selection.</returns>
        /// <exception cref="T:System.ArgumentException">The value is less than zero. </exception>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), SRDescription("TextBoxSelectionStartDescr")]
        public int SelectionStart
        {

            get
            {
                return this.GetValue<int>(ComboBox.SelectionStartProperty);
            }
            set
            {
                // Validate the new value.
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidArgument", new object[] { "SelectionStart", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // If the new value is different value from the current value, change it.
                if (this.SetValue<int>(ComboBox.SelectionStartProperty, value))
                {
                    // Invoke the actual text selection in the client.
                    this.InvokeSelection(value, this.SelectionLength);
                }

            }
        }

        /// <summary>
        /// Occurs when the SelectedIndex property has changed (Queued).
        /// </summary>
        public event EventHandler SelectedIndexChangedQueued
        {
            add
            {
                this.AddHandler(ComboBox.SelectedIndexChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ComboBox.SelectedIndexChangedQueuedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedIndexChangedQueued event.
        /// </summary>
        private EventHandler SelectedIndexChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ComboBox.SelectedIndexChangedQueuedEvent);
            }
        }

        /// <summary>
        /// Occurs when [drop down].
        /// </summary>
        [SRDescription("ComboBoxOnDropDownDescr")]
        [SRCategory("CatBehavior")]
        public event EventHandler DropDown
        {
            add
            {
                this.AddCriticalHandler(ComboBox.DropDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ComboBox.DropDownEvent, value);
            }
        }

        /// <summary>
        /// Gets the drop down handler.
        /// </summary>
        /// <value>
        /// The drop down handler.
        /// </value>
        private EventHandler DropDownHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ComboBox.DropDownEvent);
            }
        }

        /// <summary>
        /// Occurs when [drop down closed].
        /// </summary>
        [SRCategory("CatBehavior")]
        [SRDescription("ComboBoxOnDropDownClosedDescr")]
        public event EventHandler DropDownClosed
        {
            add
            {
                this.AddCriticalHandler(ComboBox.DropDownClosedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ComboBox.DropDownClosedEvent, value);
            }
        }

        /// <summary>
        /// Gets the drop down closed handler.
        /// </summary>
        /// <value>
        /// The drop down closed handler.
        /// </value>
        private EventHandler DropDownClosedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ComboBox.DropDownClosedEvent);
            }
        }

        /// <summary>
        /// The list box item collection
        /// </summary>
        [NonSerialized]
        private ObjectCollection mobjItems = null;

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> class.
        /// </summary>
        public ComboBox()
        {
            // initialize collections
            mobjItems = CreateItemCollection();

            // Set the control style
            this.SetStyle(ControlStyles.UseTextForAccessibility | ControlStyles.StandardClick | ControlStyles.UserPaint, false);
        }

        #endregion C'Tor/D'Tor

        #region Methods

        #region Serialization Methods

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
                int intSerializableDataInitialSize = base.SerializableDataInitialSize;

                // Add the items array capacity
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjItems);

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
            mobjItems = CreateItemCollection();

            // Read the items from the current array and initialize the items collection
            mobjItems.SetItemsInternal(objReader.ReadArray());
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the item collection
            objWriter.WriteArray(mobjItems);
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
            // Get code use parameters
            string strCodeMember = this.CodeMember;
            bool blnUseCode = !string.IsNullOrEmpty(strCodeMember);

            // Get image use parameters
            bool blnShouldRenderItemImage = this.ShouldRenderImage();

            // Get color use parameters
            bool blnShouldRenderItemColor = this.ShouldRenderColor();

            bool blnUseIndexCode = strCodeMember == "#Index";
            PropertyInfo objUseCodeProp = null;

            // If use property code member
            if (blnUseCode && !blnUseIndexCode)
            {
                // If there are items
                if (mobjItems.Count > 0)
                {
                    // Get the first item type
                    Type objItemType = mobjItems[0].GetType();

                    // Get property info object
                    objUseCodeProp = objItemType.GetProperty(this.CodeMember);

                    // Validate property
                    if (objUseCodeProp == null)
                    {
                        blnUseCode = false;
                    }
                }
            }



            objWriter.WriteStartElement(WGTags.Options);

            // Render animation support
            RenderAnimationAttributes((IAttributeWriter)objWriter);

            // Renders the options.
            RenderOptions(objWriter, blnUseCode, blnShouldRenderItemImage, blnShouldRenderItemColor, blnUseIndexCode, objUseCodeProp);

            objWriter.WriteEndElement();
        }

        /// <summary>
        /// Renders the options.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnUseCode">if set to <c>true</c> [BLN use code].</param>
        /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
        /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
        /// <param name="blnUseIndexCode">if set to <c>true</c> [BLN use index code].</param>
        /// <param name="objUseCodeProp">The obj use code prop.</param>
        protected virtual void RenderOptions(IResponseWriter objWriter, bool blnUseCode, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, bool blnUseIndexCode, PropertyInfo objUseCodeProp)
        {
            for (int intIndex = 0; intIndex < mobjItems.Count; intIndex++)
            {
                objWriter.WriteStartElement(WGTags.Option);
                objWriter.WriteAttributeString(WGAttributes.Index, intIndex.ToString());

                if (blnUseCode)
                {
                    if (blnUseIndexCode)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Code, intIndex.ToString());
                    }
                    else
                    {
                        objWriter.WriteAttributeString(WGAttributes.Code, objUseCodeProp.GetValue(mobjItems[intIndex], null) as string);
                    }
                }

                object objObject = mobjItems[intIndex];
                if (objObject == null)
                {
                    objWriter.WriteAttributeString(WGAttributes.Text, string.Empty);
                }
                else
                {

                    RenderItemIdAttribute(objWriter, objObject);

                    objWriter.WriteAttributeText(WGAttributes.Text, this.GetItemText(objObject), TextFilter.CarriageReturn | TextFilter.NewLine);

                    RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, objObject);
                }

                objWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Writes the color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="strColor">Color of the STR.</param>
        protected override void WriteColorAttribute(IResponseWriter objWriter, string strColor)
        {
            objWriter.WriteAttributeString(WGAttributes.Color, string.Format("background:{0};", strColor));
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Set drop down style
            if (IsCustomDropDown)
            {
                objWriter.WriteAttributeString(WGAttributes.CustomDropDown, "1");
            }
            
            switch (this.DropDownStyle)
            {
                case ComboBoxStyle.DropDown:
                    objWriter.WriteAttributeString(WGAttributes.Style, "DD");
                    break;
                case ComboBoxStyle.DropDownList:
                    objWriter.WriteAttributeString(WGAttributes.Style, "DDL");
                    break;
                case ComboBoxStyle.Simple:
                    objWriter.WriteAttributeString(WGAttributes.Style, "S");
                    break;
            }

            // Get the drop down width
            int intDropDownWidth = GetValue<int>(ComboBox.DropDownWidthProperty);

            // If drop down width is set
            if (intDropDownWidth != -1)
            {
                // Write dropdown width
                objWriter.WriteAttributeString(WGAttributes.DropDownWidth, intDropDownWidth.ToString());
            }

            // Set auto complete mode
            switch (AutoCompleteMode)
            {
                case AutoCompleteMode.None:
                    objWriter.WriteAttributeString(WGAttributes.AutoCompleteMode, "N");
                    break;
                case AutoCompleteMode.Suggest:
                    objWriter.WriteAttributeString(WGAttributes.AutoCompleteMode, "S");
                    break;
                case AutoCompleteMode.Append:
                    objWriter.WriteAttributeString(WGAttributes.AutoCompleteMode, "A");
                    break;
                case AutoCompleteMode.SuggestAppend:
                    objWriter.WriteAttributeString(WGAttributes.AutoCompleteMode, "SA");
                    break;
            }

            // Render value.
            RenderValue(objWriter);

            // Render the text attrbute.
            RenderText(objWriter);

            // Renders the item definitions.
            RenderItemDefinitions(objWriter);

            //Render pop up offset
            objWriter.WriteAttributeString(WGAttributes.PopupOffsetHeight, this.GetPopupOffsetHeight());

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

            // Render the character casing attribute
            RenderCharacterCasingAttribute(objWriter, false);

            // Render the is autocomplete casing attribute
            RenderIsAutoCompleteAttribute(objWriter, false);
        }

        /// <summary>
        /// Renders the is auto complete attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnIsAutoComplete = this.IsAutoComplete;

            if (!blnIsAutoComplete || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.IsAutoComplete, blnIsAutoComplete ? "1" : "0");
            }

        }

        /// <summary>
        /// Renders the character casing attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderCharacterCasingAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            CharacterCasing enmCharCasing = this.CharacterCasing;

            if (enmCharCasing != Forms.CharacterCasing.Normal || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.CharacterCasing, ((Byte)enmCharCasing).ToString());
            }
        }

        /// <summary>
        /// Render the text attrbute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderText(IAttributeWriter objWriter)
        {
            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);
        }

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        protected virtual void RenderValue(IAttributeWriter objWriter)
        {
            objWriter.WriteAttributeString(WGAttributes.Value, this.SelectedIndex.ToString());
        }

        /// <summary>
        /// Renders the item definitions.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderItemDefinitions(IAttributeWriter objWriter)
        {
            // Get the item perfered height
            int intPreferdItemHeight = this.GetPreferdItemHeight();

            // Get the max items to display
            int intMaxItems = 0;

            //If simple style
            if (this.DropDownStyle == ComboBoxStyle.Simple)
            {
                // The default height of the combobox input box if skin is unavailable              
                int intSimpleComboBoxInputHeight = 17;

                //Get the current skin
                ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;
                if (objComboBoxSkin != null)
                {
                    // Get the height of the combobox input box
                    intSimpleComboBoxInputHeight = objComboBoxSkin.SimpleComboBoxInputHeight;
                }

                // Set the item count to match the height of the combobox
                intMaxItems = (this.Height - intSimpleComboBoxInputHeight) / intPreferdItemHeight;

            }
            else
            {
                // Get the dropdown items size
                intMaxItems = Math.Min(this.MaxDropDownItems, this.Items.Count);
            }

            // Write the max items the client should show
            objWriter.WriteAttributeString(WGAttributes.Maximum, intMaxItems.ToString());

            //Render item height
            objWriter.WriteAttributeString(WGAttributes.ItemHeight, intPreferdItemHeight);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                //Render the text attrbute.
                this.RenderText(objWriter);

                // Render value.
                RenderValue(objWriter);

                // Render the is autocomplete casing attribute
                RenderIsAutoCompleteAttribute(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                // Renders the item definitions.
                RenderItemDefinitions(objWriter);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Render the character casing attribute
                RenderCharacterCasingAttribute(objWriter, true);
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
            string strValue = null;

            // Try to get UpdateDroppedDownOnly attribute;
            bool blnUpdateDroppedDownOnly = false;
            bool.TryParse(objEvent["UpdateDroppedDownOnly"], out blnUpdateDroppedDownOnly);

            // Select event type
            switch (objEvent.Type)
            {
                case "ValueChange":

                    // Get the new selected index
                    int intValue = int.Parse(objEvent[WGAttributes.Value]);

                    // If the value is valid
                    if (intValue > -1)
                    {
                        // Try to set the value
                        if (this.SetValue<int>(ComboBox.SelectedIndexProperty, intValue) || this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick)
                        {

                            // Raise the SelectionChangeCommitted event
                            OnSelectionChangeCommitted(EventArgs.Empty);

                            // Update the text
                            this.UpdateText();

                            // Raise the selected index changed event
                            OnSelectedIndexChanged(EventArgs.Empty);
                        }
                    }


                    break;

                case "TextChange":

                    //Get text from event
                    strValue = CommonUtils.DecodeText(objEvent[WGAttributes.Value] as string);

                    //This solves a problem with winforms not updaing the text the same way as we do.
                    //If the user delets the text and focus out in winforms works like seting the text to null.
                    //And not as seting the text to empty
                    if (strValue == string.Empty)
                    {
                        strValue = null;
                    }

                    //Set the text
                    this.InternalText = strValue;

                    //Try and locate the item associated with the text
                    int inIndex = FindStringExact(strValue);

                    //set the selected index property stor to skip event rais
                    this.SetValue<int>(ComboBox.SelectedIndexProperty, inIndex);

                    break;
                case "DropDownWindow":
                    // If DropDown event is critical.
                    if (this.DropDownHandler != null)
                    {
                        OnDropDown(EventArgs.Empty);
                    }

                    // Update DroppedDown property value.
                    this.DroppedDownInternal = true;
                    
                    Form objDropDown = GetCustomDropDown();
                    if (objDropDown != null)
                    {
                        objDropDown.Closed += CustomDropDown_Closed;
                        objDropDown.ShowPopup(this.Form, this, DialogAlignment.Below);
                        objDropDown = null;
                    }
                    break;
                case "DropDown":
                    if (!blnUpdateDroppedDownOnly)
                    {
                        OpenDropDownPopup();
                    }
                    // Update DroppedDown property value.
                    this.DroppedDownInternal = true;
                    break;
                case "DropDownClosed":
                    // Update DroppedDown property value.
                    this.DroppedDownInternal = false;
                    if (!blnUpdateDroppedDownOnly)
                    {
                        OnDropDownClosed(EventArgs.Empty);
                    }
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
            if (base.SelectedValueChangedHandler != null || SelectedIndexChangedHandler != null || this.SelectionChangeCommittedHandler != null || this.IsPostBackRequired)
            {
                objEvents.Set(WGEvents.ValueChange);
            }
            
            if (this.DropDownHandler != null)
            {
                objEvents.Set(WGEvents.DropDown);
            }

            if (this.DropDownClosedHandler != null)
            {
                objEvents.Set(WGEvents.DropDownClosed);
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

            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            KeyCaptures enmKeyCaptures = base.GetKeyEventCaptures();
            enmKeyCaptures |= KeyCaptures.UpKeyCapture;
            enmKeyCaptures |= KeyCaptures.DownKeyCapture;
            enmKeyCaptures |= KeyCaptures.EndKeyCapture;
            enmKeyCaptures |= KeyCaptures.HomeKeyCapture;
            enmKeyCaptures |= KeyCaptures.EscKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageDownKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageUpKeyCapture;
            return enmKeyCaptures;
        }

        /// <summary>
        /// Raises the <see cref="E:SelectionChangeCommitted"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSelectionChangeCommitted(EventArgs e)
        {
            EventHandler objHandler = this.SelectionChangeCommittedHandler;
            if (objHandler != null)
            {
                objHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:SelectedIndexChanged"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs objEventArgs)
        {
            base.OnSelectedIndexChanged(objEventArgs);

            this.OnSelectedIndexChangedQueued(objEventArgs);

            // Raise event if needed
            EventHandler objEventHandler = this.SelectedIndexChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }

            // Get local variables.
            CurrencyManager objCurrencyManager = base.DataManager;
            int intIndex = this.SelectedIndex;

            if (((objCurrencyManager != null) && (objCurrencyManager.Position != intIndex)) && (!base.FormattingEnabled || (intIndex != -1)))
            {
                objCurrencyManager.Position = intIndex;
            }
        }

        /// <summary>
        /// Raises the OnSelectedIndexChangedQueued event
        /// </summary>
        /// <param name="objEventArgs"></param>
        protected virtual void OnSelectedIndexChangedQueued(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.SelectedIndexChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            // Use local variants
            bool blnSorted = this.Sorted;
            object objDataSource = this.DataSource;

            if (blnSorted && objDataSource != null)
            {
                this.DataSource = null;
                throw new InvalidOperationException(SR.GetString("ComboBoxDataSourceWithSort"));
            }
            if (objDataSource == null)
            {
                //this.BeginUpdate();
                this.SelectedIndex = -1;
                this.Items.ClearInternal();
                //this.EndUpdate();
            }
            if (!blnSorted)
            {
                base.OnDataSourceChanged(e);
            }
            this.RefreshItems();
        }

        /// <summary>
        /// Raises the <see cref="E:DropDown" /> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnDropDown(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.DropDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:DropDownClosed" /> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnDropDownClosed(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.DropDownClosedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Handles the Closed event of the CustomDropDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CustomDropDown_Closed(object sender, EventArgs e)
        {
            if (sender is Form)
            {
                ((Form)sender).Closed -= CustomDropDown_Closed;
            }
            // Update DroppedDown property value.
            this.DroppedDownInternal = false;
            OnDropDownClosed(EventArgs.Empty);
        }

        #endregion Events

        #region General

        /// <summary>
        /// Updates the text according to selected index.
        /// </summary>
        /// <returns>Return boolean that indicates if text has been changed.</returns>
        private bool UpdateText()
        {
            // Initialize return value.
            bool blnTextChanged = false;

            // The updated text
            string strText = string.Empty;

            // If there is a selected index
            if (this.SelectedIndex != -1)
            {
                // Get current selected item
                object objItem = this.Items[this.SelectedIndex];

                // If there is a valid item
                if (objItem != null)
                {
                    // Set the text from the selected item
                    strText = base.GetItemText(objItem);
                }
            }

            // Set text value.
            if (this.Text != strText)
            {
                // Change text.
                this.InternalText = strText;

                // Flag that text was changed.
                blnTextChanged = true;
            }

            // Return value.
            return blnTextChanged;
        }

        /// <summary>
        /// Gets the popup height offset.
        /// </summary>
        /// <returns></returns>
        private double GetPopupOffsetHeight()
        {
            //Get the current skin
            ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;

            //if a Skin was found
            if (objComboBoxSkin != null)
            {
                //return the PopupWindowOffsetHeight
                return objComboBoxSkin.PopupWindowOffsetHeight;
            }
            return 0;

        }

        /// <summary>
        /// Gets the height of the preferd item font.        
        /// </summary>
        /// <returns></returns>
        internal int GetPreferdItemHeight()
        {
            //Get the current skin
            ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;

            //If skin exists
            if (objComboBoxSkin != null)
            {
                // Get the arrow icon padding value
                PaddingValue objPaddingValue = (objComboBoxSkin.PopupItemStyle).Padding as PaddingValue;

                //The default Color box height
                int intColorBoxHeight = 0;

                //If we need to get the color height
                if (this.ShouldRenderColor())
                {
                    //Get Color Box Height
                    intColorBoxHeight = objComboBoxSkin.ColorBoxHeight;
                }

                //The default image box height
                int intImageBoxHeight = 0;

                //If we need to get the Image height
                if (this.ShouldRenderImage())
                {
                    intImageBoxHeight = objComboBoxSkin.ImageBoxHeight;
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
                return intBaseHeight + intPaddingOffset;
            }
            return 0;
        }

        /// <summary>
        /// Creates the item collection.
        /// </summary>
        protected virtual ComboBox.ObjectCollection CreateItemCollection()
        {
            return new ComboBox.ObjectCollection(this);
        }

        /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
        /// <param name="intIndex">The zero-based index of the item whose data to refresh. </param>
        protected override void RefreshItem(int intIndex)
        {
            this.Update();
        }

        /// <summary>When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
        /// <param name="objItems">An array of items.</param>
        protected override void SetItemsCore(IList objItems)
        {
            this.Items.ClearInternal();

            if (objItems != null)
            {
                // Copy all items.
                object[] arrItems = new object[objItems.Count];
                objItems.CopyTo(arrItems, 0);

                // Limit length to MaxBindedDropDownItems if needed.
                if (this.MaxBoundDropDownItems != -1 &&
                    objItems.Count > this.MaxBoundDropDownItems)
                {
                    object[] arrAllItems = new object[objItems.Count];
                    objItems.CopyTo(arrAllItems, 0);

                    arrItems = new object[this.MaxBoundDropDownItems];
                    Array.Copy(arrAllItems, arrItems, this.MaxBoundDropDownItems);
                }

                // Add items.
                this.Items.AddRangeInternal(arrItems);
            }
        }

        /// <summary>
        /// When overridden in a derived class, sets the object with the specified index in the derived class.
        /// </summary>
        /// <param name="intIndex">The array index of the object.</param>
        /// <param name="objValue">The object.</param>
        protected override void SetItemCore(int intIndex, object objValue)
        {
            this.Items.SetItemInternal(intIndex, objValue);
        }

        /// <summary>
        /// Resets the width of the drop down.
        /// </summary>
        internal void ResetDropDownWidth()
        {
            this.RemoveValue<int>(ComboBox.DropDownWidthProperty);
        }

        /// <summary>
        /// Shoulds the width of the serialize drop down.
        /// </summary>
        /// <returns></returns>
        internal bool ShouldSerializeDropDownWidth()
        {
            return this.ContainsValue<int>(ComboBox.DropDownWidthProperty);
        }        

        /// <summary>
        /// Finds the item in the ListBox that has this code.
        /// </summary>
        /// <param name="strCode">The STR code.</param>
        /// <returns></returns>
        public int FindCode(string strCode)
        {
            string strCodeMember = this.CodeMember;
            if (!string.IsNullOrEmpty(strCodeMember))
            {
                int intIndex = 0;
                bool blnIndex = strCodeMember == "#Index";

                PropertyInfo objUseCodeProp = null;

                // If there are items
                if (mobjItems.Count > 0)
                {
                    // Get the first item type
                    Type objItemType = mobjItems[0].GetType();

                    // Get property info object
                    objUseCodeProp = objItemType.GetProperty(strCodeMember);
                }

                foreach (object objItem in mobjItems)
                {
                    if (blnIndex)
                    {
                        if (intIndex.ToString() == strCode)
                        {
                            return intIndex;
                        }
                    }
                    else
                    {
                        if (objUseCodeProp != null)
                        {
                            string strItemCode = objUseCodeProp.GetValue(objItem, null) as string;
                            if (strItemCode == strCode)
                            {
                                return intIndex;
                            }
                        }
                    }

                    intIndex++;
                }

            }

            return -1;
        }

        /// <summary>Finds the first item in the combo box that starts with the specified string.</summary>
        /// <returns>The zero-based index of the first item found; returns -1 if no match is found.</returns>
        /// <param name="strFindValue">The <see cref="T:System.String"></see> to search for. </param>
        /// <filterpriority>1</filterpriority>
        public int FindString(string strFindValue)
        {
            return this.FindString(strFindValue, -1);
        }

        /// <summary>Finds the first item after the given index which starts with the given string. The search is not case sensitive.</summary>
        /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
        /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
        /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is greater than the last index in the collection. </exception>
        /// <filterpriority>1</filterpriority>
        public int FindString(string strValue, int intStartIndex)
        {
            if (strValue == null)
            {
                return -1;
            }
            if ((this.Items == null) || (this.Items.Count == 0))
            {
                return -1;
            }
            if ((intStartIndex < -1) || (intStartIndex >= this.Items.Count))
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            return base.FindStringInternal(strValue, this.Items, intStartIndex, false);
        }

        /// <summary>Finds the first item in the combo box that matches the specified string.</summary>
        /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
        /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
        /// <filterpriority>1</filterpriority>
        public int FindStringExact(string strValue)
        {
            return this.FindStringExact(strValue, -1, true);
        }

        /// <summary>Finds the first item after the specified index that matches the specified string.</summary>
        /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
        /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
        /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is equal to the last index in the collection. </exception>
        /// <filterpriority>1</filterpriority>
        public int FindStringExact(string strValue, int intStartIndex)
        {
            return this.FindStringExact(strValue, intStartIndex, true);
        }

        /// <summary>
        /// Finds the string exact.
        /// </summary>
        /// <param name="strValue">The string.</param>
        /// <param name="intStartIndex">The start index.</param>
        /// <param name="blnIgnoreCase">if set to <c>true</c> should ignorecase.</param>
        /// <returns></returns>
        internal int FindStringExact(string strValue, int intStartIndex, bool blnIgnoreCase)
        {
            if (strValue == null)
            {
                return -1;
            }
            if ((this.Items == null) || (this.Items.Count == 0))
            {
                return -1;
            }
            if ((intStartIndex < -1) || (intStartIndex >= this.Items.Count))
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            return base.FindStringInternal(strValue, this.Items, intStartIndex, true, blnIgnoreCase);
        }

        /// <summary>
        /// Finds the string and ignores case.
        /// </summary>
        /// <param name="strValue">The value.</param>
        /// <returns></returns>
        internal int FindStringIgnoreCase(string strValue)
        {
            int intIndex = this.FindStringExact(strValue, -1, false);
            if (intIndex == -1)
            {
                intIndex = this.FindStringExact(strValue, -1, true);
            }
            return intIndex;
        }

        /// <summary>
        /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.
        /// </summary>
        ///	<returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>. The string includes the type and the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.</returns>
        public override string ToString()
        {
            string strText = base.ToString();
            return (strText + ", Items.Count: " + ((this.mobjItems == null) ? 0.ToString() : this.mobjItems.Count.ToString()));
        }

        /// <summary>Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> items.</summary>
        protected override void RefreshItems()
        {
            // Store current index and items.
            int intSelectedIndex = this.SelectedIndex;
            ComboBox.ObjectCollection objCurrentItems = this.mobjItems;

            // Reset items.
            this.mobjItems = this.CreateItemCollection();

            object[] arrObjects = null;

            if ((base.DataManager != null) && (base.DataManager.Count != -1))
            {
                // Limit data length to MaxBindedDropDownItems, if needed.
                int intDataLength = base.DataManager.Count;

                if (this.MaxBoundDropDownItems != -1)
                {
                    intDataLength = Math.Min(this.MaxBoundDropDownItems, intDataLength);
                }

                // Set items.
                arrObjects = new object[intDataLength];

                for (int intData = 0; intData < intDataLength; intData++)
                {
                    object objDataItem = base.DataManager[intData];
                    if (objDataItem != null)
                    {
                        arrObjects[intData] = base.DataManager[intData];
                    }
                }
            }
            else if (objCurrentItems != null)
            {
                arrObjects = new object[objCurrentItems.Count];
                objCurrentItems.CopyTo(arrObjects, 0);
            }

            // Add items.
            if (arrObjects != null)
            {
                this.Items.AddRangeInternal(arrObjects);
            }

            // Restore selected index.
            if (base.DataManager != null)
            {
                this.SelectedIndex = base.DataManager.Position;
            }
            else
            {
                this.SelectedIndex = intSelectedIndex;
            }
        }

        /// <summary>
        /// Operated on this instance after clear items action
        /// </summary>
        internal void Clear()
        {
            this.RemoveValue<int>(ComboBox.SelectedIndexProperty);

            if (this.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                this.UpdateText();
            }
        }

        /// <summary>
        /// Checks the no data source.
        /// </summary>
        private void CheckNoDataSource()
        {
            if (this.DataSource != null)
            {
                throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
            }
        }

        /// <summary>Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void SelectAll()
        {
            this.Select(0, 0x7fffffff);
        }

        /// <summary>Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
        /// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
        /// <param name="intLength">The number of characters to select. </param>
        /// <exception cref="T:System.ArgumentException">The start is less than zero.-or- start plus length is less than zero. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Select(int intStart, int intLength)
        {
            if (intStart < 0)
            {
                throw new ArgumentOutOfRangeException("start", SR.GetString("InvalidArgument", new object[] { "start", intStart.ToString(CultureInfo.CurrentCulture) }));
            }
            int high = intStart + intLength;
            if (high < 0)
            {
                throw new ArgumentOutOfRangeException("length", SR.GetString("InvalidArgument", new object[] { "length", intLength.ToString(CultureInfo.CurrentCulture) }));
            }

            // Set the properties in propertyStore dircetly to avoid looping between the 
            // properties and select method.
            this.SetValue<int>(ComboBox.SelectionLengthProperty, intLength);
            this.SetValue<int>(ComboBox.SelectionStartProperty, intStart);

            // Call the invocation 
            InvokeSelection(intStart, intLength);
        }

        /// <summary>
        /// Opens the drop down popup.
        /// </summary>
        private void OpenDropDownPopup()
        {
            this.InvokeMethodWithId("ComboBox_InvokeOpenPopup", true);

            // OnDropDown method for custom combobox will be invoked in another place when custom form will be opened.
            if (!IsCustomDropDown)
            {
                OnDropDown(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Closes the drop down popup.
        /// </summary>
        private void CloseDropDownPopup()
        {
            this.InvokeMethodWithId("ComboBox_InvokeClosePopup", true);
        }

        #endregion General

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new ComboBoxRenderer(this);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is auto complete.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is auto complete; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool IsAutoComplete
        {
            get
            {
                return this.GetValue<bool>(ComboBox.IsAutoCompleteProperty);
            }
            set
            {
                if (this.SetValue<bool>(ComboBox.IsAutoCompleteProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }

        }

        /// <summary>
        /// Indicates if all characters should be left alone or converted to uppercase or lowercase
        /// </summary>
        /// <value></value>
        [SRCategory("CatBehavior"), SRDescription("TextBoxCharacterCasingDescr"), DefaultValue(CharacterCasing.Normal)]
        public virtual CharacterCasing CharacterCasing
        {
            get
            {
                return this.GetValue<CharacterCasing>(ComboBox.CharacterCasingProperty);
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(CharacterCasing));
                }

                if (this.SetValue<CharacterCasing>(ComboBox.CharacterCasingProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether animation is enabled by default.
        /// </summary>
        /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
        protected override bool DefaultAnimation
        {
            get
            {
                return this.AnimationEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a custom drop down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool IsCustomDropDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the custom form to display as drop down
        /// </summary>
        /// <returns></returns>
        protected virtual Form GetCustomDropDown()
        {
            return null;
        }

        /// <summary>
        /// Gets or sets the maximum number of items to be shown in the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
        /// </summary>
        ///	<returns>The maximum number of items of in the drop-down portion. The minimum for this property is 1 and the maximum is 100.</returns>
        ///	<exception cref="T:System.ArgumentException">The maximum number is set less than one or greater than 100. </exception>
        [System.ComponentModel.DefaultValue(8)]
        [SRCategory("CatBehavior"), Localizable(true), SRDescription("ComboBoxMaxDropDownItemsDescr")]
        public int MaxDropDownItems
        {
            get
            {
                return this.GetValue<int>(ComboBox.MaxItemsProperty);
            }
            set
            {
                // If values are in range
                if ((value < 1) || (value > 100))
                {
                    object[] arrArgs = new object[] { "MaxDropDownItems", value.ToString(CultureInfo.CurrentCulture), 1.ToString(CultureInfo.CurrentCulture), 100.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("MaxDropDownItems", SR.GetString("InvalidBoundArgument", arrArgs));
                }


                // Try to set the max items value
                if (this.SetValue<int>(ComboBox.MaxItemsProperty, value))
                {
                    // Update control to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the items in the combo box are sorted.
        /// </summary>
        ///	<returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
        ///	<exception cref="T:System.ArgumentException">An attempt was made to sort a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that is attached to a data source. </exception>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ComboBoxSortedDescr"), DefaultValue(false), SRCategory("CatBehavior")]
        public bool Sorted
        {
            get
            {
                return this.GetValue<bool>(ComboBox.SortedProperty);
            }
            set
            {
                // Set the value and update the control if value had changed
                if (this.SetValue<bool>(ComboBox.SortedProperty, value))
                {
                    // Refresh the items to reflect the new sorting
                    this.RefreshItems();

                    // Reset the selected item
                    this.SelectedIndex = -1;

                    // Update the control to reflect the new sorting
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the max bound drop down items.
        /// </summary>
        /// <value>
        /// The max bound drop down items.
        /// </value>
        [DefaultValue(-1), SRCategory("CatData"), SRDescription("Gets or sets a value indicating the maximal number of bound drop down items.")]
        public int MaxBoundDropDownItems
        {
            get
            {
                return this.GetValue<int>(MaxBoundDropDownItemsProperty);
            }
            set
            {
                if (this.SetValue<int>(MaxBoundDropDownItemsProperty, value))
                {
                    this.RefreshItems();
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the auto complete mode.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(AutoCompleteMode.None), SRDescription("ComboBoxAutoCompleteModeDescr")]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return this.GetValue<AutoCompleteMode>(ComboBox.AutoCompleteModeProperty);
            }
            set
            {
                // Set the auto complete mode and update the control if value had changed
                if (this.SetValue<AutoCompleteMode>(ComboBox.AutoCompleteModeProperty, value))
                {
                    // Render Visual attributes only
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the drop down style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ComboBoxStyle.DropDown)]
        public virtual ComboBoxStyle DropDownStyle
        {
            get
            {
                return this.GetValue<ComboBoxStyle>(ComboBox.DropDownStyleProperty);
            }
            set
            {
                // Set the new dropdown style and update the control if value had changed
                if (this.SetValue<ComboBoxStyle>(ComboBox.DropDownStyleProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the width of the of the drop-down portion of a combo box.</summary>
        /// <returns>The width, in pixels, of the drop-down box.</returns>
        /// <exception cref="T:System.ArgumentException">The specified value is less than one. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ComboBoxDropDownWidthDescr"), SRCategory("CatBehavior")]
        public int DropDownWidth
        {
            get
            {
                // Get dropdown width
                int intDropDownWidth = this.GetValue<int>(ComboBox.DropDownWidthProperty);

                // If dropdown is set
                if (intDropDownWidth != -1)
                {
                    return intDropDownWidth;
                }
                else
                {
                    return base.Width;
                }
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("DropDownWidth", SR.GetString("InvalidArgument", new object[] { "DropDownWidth", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // Set drop down and update control if needed
                if (this.SetValue<int>(ComboBox.DropDownWidthProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the auto-completion source.
        /// </summary>
        [DefaultValue(AutoCompleteSource.None), EditorBrowsable(EditorBrowsableState.Always), SRDescription("ComboBoxAutoCompleteSourceDescr"), Browsable(true)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return this.GetValue<AutoCompleteSource>(ComboBox.AutoCompleteSourceProperty);
            }
            set
            {
                this.SetValue<AutoCompleteSource>(ComboBox.AutoCompleteSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets an object representing the collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#endif
        public ObjectCollection Items
        {
            get
            {
                return mobjItems;
            }
        }

        /// <summary>
        /// Gets or sets the index specifying the currently selected item.
        /// </summary>
        ///	<returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The specified index is less than or equal to -2.-or- The specified index is greater than or equal to the number of items in the combo box. </exception>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRDescription("ComboBoxSelectedIndexDescr")]
        public override int SelectedIndex
        {
            get
            {
                // If there are items
                if (mobjItems.Count > 0)
                {
                    // Get the selected index from the store
                    return this.GetValue<int>(ComboBox.SelectedIndexProperty);
                }
                else
                {
                    // Return no selection value
                    return -1;
                }
            }
            set
            {
                // The item count
                int intItemCount = 0;

                // If items collection is created
                if (this.mobjItems != null)
                {
                    // Get the items count from the list
                    intItemCount = this.mobjItems.Count;
                }

                // Check that the new value is with in the accepted range
                if ((value < -1) || (value >= intItemCount))
                {
                    throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidArgument", new object[] { "SelectedIndex", value.ToString(CultureInfo.CurrentCulture) }));
                }

                // Initialize the update params indicator.
                bool blnUpdateParams = false;

                // Try to set the value and raise events and update the control if value had changed
                if (this.SetValue<int>(ComboBox.SelectedIndexProperty, value))
                {
                    // Update text.
                    this.UpdateText();

                    // Raise the selected index changed event
                    OnSelectedIndexChanged(EventArgs.Empty);

                    // Flag that update is needed.
                    blnUpdateParams = true;
                }
                else
                {
                    // Check if text should be updated.
                    blnUpdateParams = this.UpdateText();
                }

                // Update the control - if index or text has been changed.
                if (blnUpdateParams)
                {
                    UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Override the Control Text.
        /// When the combo control is bound to a BindingSource Text property (a string data member in the DB),
        /// we have to set the combo index to match the text.
        /// </summary>
        public override string Text
        {
            get
            {
                if ((this.SelectedItem != null) && !base.BindingFieldEmpty)
                {
                    if (!base.FormattingEnabled)
                    {
                        return base.FilterItemOnProperty(this.SelectedItem).ToString();
                    }
                    string strItemText = base.GetItemText(this.SelectedItem);
                    if (!string.IsNullOrEmpty(strItemText) && (string.Compare(strItemText, base.Text, true, CultureInfo.CurrentCulture) == 0))
                    {
                        return strItemText;
                    }
                }
                return base.Text;
            }
            set
            {
                if (this.Text != value)
                {
                    this.InternalText = value;
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Set text without raising any events
        /// </summary>
        /// <value></value>
        internal override string InternalText
        {
            set
            {
                if ((this.DropDownStyle != ComboBoxStyle.DropDownList) || (string.IsNullOrEmpty(value) || (this.FindStringExact(value) != -1)))
                {
                    base.InternalText = value;
                    object objItem = null;
                    objItem = this.SelectedItem;

                    if (!base.DesignMode)
                    {
                        if (value == null)
                        {
                            this.SetValue<int>(ComboBox.SelectedIndexProperty, -1);
                        }
                        else if ((value != null) && ((objItem == null) || (string.Compare(value, base.GetItemText(objItem), false, CultureInfo.CurrentCulture) != 0)))
                        {
                            int intNum = this.FindStringIgnoreCase(value);
                            if (intNum != -1)
                            {
                                if (this.SetValue<int>(ComboBox.SelectedIndexProperty, intNum))
                                {
                                    // Raise the selected index changed event
                                    OnSelectedIndexChanged(EventArgs.Empty);
                                }
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
        /// </summary>
        ///	<returns>The object that is the currently selected item or null if there is no currently selected item.</returns>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRDescription("ComboBoxSelectedItemDescr")]
        [Bindable(true)]
        public object SelectedItem
        {
            get
            {
                if (mobjItems.Count == 0)
                {
                    return null;
                }
                else
                {
                    // Get the selected index
                    int intSelectedIndex = this.SelectedIndex;

                    // If value is no selection return null
                    if (intSelectedIndex == -1)
                    {
                        return null;
                    }
                    else
                    {
                        // Return the current selected item
                        return mobjItems[intSelectedIndex];
                    }
                }
            }
            set
            {
                SelectedIndex = mobjItems.IndexOf(value);
            }
        }

        /// <summary>
        /// Gets or sets the code member.
        /// </summary>
        /// <value>The code member.</value>
        [System.ComponentModel.DefaultValue("")]
        public string CodeMember
        {
            get
            {
                return this.GetValue<string>(ComboBox.CodeMemberProperty);
            }
            set
            {
                // Set the code member property and update the control if value had changed
                if (this.SetValue<string>(ComboBox.CodeMemberProperty, value))
                {
                    this.Update();
                }
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

        /// <summary>
        /// Gets the items comparer object.
        /// </summary>
        [Browsable(false)]
        public virtual IComparer ItemsComparer
        {
            get
            {
                return new ComboBox.ItemComparer(this);
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
                return this.GetValue<bool>(ComboBox.IntegralHeightProperty);
            }
            set
            {
                this.SetValue<bool>(ComboBox.IntegralHeightProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating the currently selected text in the control.</summary>
        /// <returns>A string that represents the currently selected text in the text box.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string SelectedText
        {
            get
            {
                return this.GetValue<string>(ComboBox.SelectedTextProperty);

            }
            set
            {
                this.SetValue<string>(ComboBox.SelectedTextProperty, value);
            }
        }

        /// <summary>Gets or sets the appearance of the <see cref="T:Gizmox.WebGui.Forms.ComboBox"></see>.</summary>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. The options are Flat, Popup, Standard, and System. The default is Standard.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Localizable(true), DefaultValue(FlatStyle.Standard), SRDescription("ComboBoxFlatStyleDescr"), SRCategory("CatAppearance")]
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Standard;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [dropped down].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [dropped down]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("ComboBoxDroppedDownDescr")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(true)]
        public bool DroppedDown
        {
            get
            {
                return this.DroppedDownInternal;
            }
            set
            {
                // If DroppedDown is set to true show the dropdown popup from server.
                // Need to do this before DroppedDown property value changing to have DroppedDown still equal to false inside DropDown event handler like in WinForms.
                if (value)
                {
                    // Dropdown popup shouldn't be shown for simple dropdown style.
                    if (this.DropDownStyle != ComboBoxStyle.Simple)
                    {
                        OpenDropDownPopup();
                    }
                }
                
                // Set DroppedDown internal property.
                this.DroppedDownInternal = value;

                // If DroppedDown is set to false close the dropdown popup from server.
                // Need to do this after DroppedDown property value changing to have DroppedDown already equal to false inside DropDownClosed event handler like in WinForms.
                if (!value)
                {
                    // There is no need to close dropdown popup for simple dropdown style.
                    if (this.DropDownStyle != ComboBoxStyle.Simple)
                    {
                        CloseDropDownPopup();
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [dropped down internal].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [dropped down internal]; otherwise, <c>false</c>.
        /// </value>
        internal bool DroppedDownInternal
        {
            get
            {
                return this.GetValue<bool>(ComboBox.DroppedDownProperty);
            }
            set
            {
                this.SetValue<bool>(ComboBox.DroppedDownProperty, value);
            }
        }

        #endregion Properties

        #region Default Member Values

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(0x79, this.PreferredHeight);
            }
        }

        /// <summary>
        /// Gets the height of the preferred.
        /// </summary>
        /// <value>
        /// The height of the preferred.
        /// </value>
        private int PreferredHeight
        {
            get
            {
                if (this.DropDownStyle == ComboBoxStyle.Simple)
                {
                    return GetSimpleComboHeight();
                }
                else
                {
                    return GetComboHeight();
                }
            }
        }

        /// <summary>
        /// Gets the height of the simple combo.
        /// </summary>
        /// <returns></returns>
        private int GetSimpleComboHeight()
        {
            int intSimpleComboBoxInputHeight = 0;
            int intBorderHight = 0;
            int intPaddingHorizontal = 0;
            int intItemHeight = this.GetPreferdItemHeight() * 8;

            ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;
            if (objComboBoxSkin != null)
            {
                intSimpleComboBoxInputHeight = objComboBoxSkin.SimpleComboBoxInputHeight;

                if (objComboBoxSkin.BorderStyle != Forms.BorderStyle.None)
                {
                    intBorderHight = objComboBoxSkin.BorderWidth * 2;
                }

                intPaddingHorizontal = objComboBoxSkin.Padding.Horizontal;
            }

            return intItemHeight + intPaddingHorizontal + intBorderHight;
        }

        /// <summary>
        /// Gets the height of the combo.
        /// </summary>
        /// <returns></returns>
        private int GetComboHeight()
        {
            int intBorderHight = 0;
            int intPaddingHorizontal = 0;
            Size  objSize = CommonUtils.GetStringMeasurements("0", this.Font);
            ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;
            if (objComboBoxSkin != null)
            {
                if (objComboBoxSkin.BorderStyle != Forms.BorderStyle.None)
                {
                    intBorderHight = objComboBoxSkin.BorderWidth * 2;
                }

                intPaddingHorizontal = objComboBoxSkin.Padding.Horizontal;
            }

            return objSize.Height + intPaddingHorizontal + intBorderHight;
            
        }

        #endregion Default Member Values
    }

    #endregion ComboBox Class

    #region ComboBoxRenderer Class

    /// <summary>
    /// Provides support for rendering ComboBoxes
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ComboBoxRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxRenderer"/> class.
        /// </summary>
        /// <param name="objComboBox">The combo box.</param>
        internal ComboBoxRenderer(ComboBox objComboBox)
            : base(objComboBox)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current ComboBox
            ComboBox objComboBox = this.Control as ComboBox;
            if (objComboBox != null)
            {
                //Write the ComboBox text
                RenderText(objContext, objGraphics, objComboBox.Text, objComboBox.Font, objComboBox.ForeColor, objComboBox.Size, HorizontalAlignment.Left, true);
            }
        }
    }

    #endregion
}
