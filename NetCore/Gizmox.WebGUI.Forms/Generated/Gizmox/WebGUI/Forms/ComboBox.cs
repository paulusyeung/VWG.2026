#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Represents a Gizmox.WebGUI.Forms combo box control.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ComboBox), "ComboBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultEvent("SelectedIndexChanged")]
	[SRDescription("DescriptionComboBox")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("CB")]
	[Skin(typeof(ComboBoxSkin))]
	public class ComboBox : ListControl
	{
		/// 
		///
		/// </summary>
		[Serializable]
		private sealed class ItemComparer : IComparer
		{
			private ComboBox mobjComboBox;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox.ItemComparer" /> class.
			/// </summary>
			/// <param name="objComboBox">The combo box.</param>
			public ItemComparer(ComboBox objComboBox)
			{
				mobjComboBox = objComboBox;
			}

			/// 
			/// Compares the specified item1.
			/// </summary>
			/// <param name="objItem1">The obj item1.</param>
			/// <param name="objItem2">The obj item2.</param>
			/// </returns>
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
				string itemText = mobjComboBox.GetItemText(objItem1);
				string itemText2 = mobjComboBox.GetItemText(objItem2);
				return Application.CurrentCulture.CompareInfo.Compare(itemText, itemText2, CompareOptions.StringSort);
			}
		}

		/// 
		/// Represents the collection of items in a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
		/// </summary>
		[Serializable]
		[ListBindable(false)]
		public class ObjectCollection : ICollection, IEnumerable, IList
		{
			/// 
			/// The owner tab control
			/// </summary>
			private ArrayList mobjList = null;

			/// 
			/// The object collection parent control
			/// </summary>
			private ComboBox mobjParent = null;

			private IComparer mobjComparer;

			/// 
			/// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
			/// </summary>
			public bool IsSynchronized => mobjList.IsSynchronized;

			/// 
			/// Gets the number of items in the collection.
			/// </summary>
			/// The number of items in the collection.</returns>
			public int Count => mobjList.Count;

			/// 
			/// Gets the sync root.
			/// </summary>
			/// </value>
			public object SyncRoot => mobjList.SyncRoot;

			/// 
			/// Gets the comparer.
			/// </summary>
			private IComparer Comparer => mobjParent.ItemsComparer;

			/// 
			/// Gets the <see cref="T:System.Object" /> with the specified int index.
			/// </summary>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public object this[int intIndex]
			{
				get
				{
					return mobjList[intIndex];
				}
				set
				{
					if (mobjList != null && mobjList[intIndex] != value)
					{
						mobjList[intIndex] = value;
						mobjParent.Update();
					}
				}
			}

			/// 
			/// Gets a value indicating whether this collection can be modified.
			/// </summary>
			/// Always false.</returns>
			public bool IsReadOnly => false;

			/// 
			/// Gets or sets the <see cref="T:System.Object" /> at the specified index.
			/// </summary>
			object IList.this[int intIndex]
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

			/// 
			/// For a description of this member, see <see cref="P:System.Collections.IList.IsFixedSize"></see>.
			/// </summary>
			/// false in all cases.</returns>
			public bool IsFixedSize => false;

			/// 
			/// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ComboBox.ObjectCollection"></see>.
			/// </summary>
			/// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that owns this object collection. </param>
			protected internal ObjectCollection(ComboBox objOwner)
			{
				if (objOwner == null)
				{
					throw new NullReferenceException("ComboBox.ObjectCollection has been initialized with a null owner");
				}
				mobjList = new ArrayList();
				mobjParent = objOwner;
			}

			/// 
			/// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
			/// </summary>
			/// <param name="objDestination">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
			/// <param name="intIndex">The zero-based index in the array at which copying begins.</param>
			public void CopyTo(Array objDestination, int intIndex)
			{
				mobjList.CopyTo(objDestination, intIndex);
			}

			/// 
			/// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
			/// </summary>
			/// The zero-based index of the item in the collection.</returns>
			/// <param name="objItem">An object representing the item to add to the collection. </param>
			/// <exception cref="T:System.ArgumentNullException">The item parameter was null. </exception>
			public virtual int Add(object objItem)
			{
				mobjParent.CheckNoDataSource();
				int result = AddInternal(objItem);
				mobjParent.Update();
				return result;
			}

			/// 
			/// Adds an item with sorting.
			/// </summary>
			/// <param name="objItem">The obj item.</param>
			/// </returns>
			private int AddInternal(object objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				int num = -1;
				if (!mobjParent.Sorted)
				{
					num = mobjList.Add(objItem);
				}
				else
				{
					num = mobjList.BinarySearch(objItem, Comparer);
					if (num < 0)
					{
						num = ~num;
					}
					mobjList.Insert(num, objItem);
				}
				return num;
			}

			/// 
			/// Determines if the specified item is located within the collection.
			/// </summary>
			/// true if the item is located within the collection; otherwise, false.</returns>
			/// <param name="objValue">An object representing the item to locate in the collection. </param>
			public bool Contains(object objValue)
			{
				return mobjList.Contains(objValue);
			}

			/// 
			/// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
			/// </summary>
			/// <param name="arrObjects">An array of objects to add to the list. </param>
			/// <exception cref="T:System.ArgumentNullException">An item in the items parameter was null. </exception>
			public virtual void AddRange(object[] arrObjects)
			{
				AddRangeInternal(arrObjects);
			}

			/// 
			/// Adds the range internal.
			/// </summary>
			/// <param name="arrObjects">The objects.</param>
			internal void AddRangeInternal(object[] arrObjects)
			{
				foreach (object objItem in arrObjects)
				{
					AddInternal(objItem);
				}
				mobjParent.Update();
			}

			/// 
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
					AddInternal(objObject);
				}
				mobjParent.Update();
			}

			/// 
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
				if (intIndex < 0 || intIndex >= mobjList.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", intIndex.ToString()));
				}
				mobjList[intIndex] = objValue;
				mobjParent.Update();
			}

			/// 
			/// Adds a range of objects.
			/// </summary>
			/// <param name="objObjects">objects.</param>
			public void AddRange(ICollection objObjects)
			{
				if (objObjects == null)
				{
					throw new ArgumentNullException("objObjects");
				}
				mobjParent.CheckNoDataSource();
				AddRangeInternal(objObjects);
			}

			/// 
			/// Removes the specified item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
			/// </summary>
			/// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the list. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
			public void Remove(object objValue)
			{
				mobjParent.Update();
				mobjList.Remove(objValue);
			}

			/// 
			/// Returns an enumerator that can be used to iterate through the item collection.
			/// </summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				return mobjList.GetEnumerator();
			}

			/// 
			/// Clears the collection.
			/// </summary>
			internal void ClearInternal()
			{
				mobjList.Clear();
				mobjParent.Clear();
				mobjParent.Update();
			}

			/// 
			/// Removes all items from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
			/// </summary>
			public void Clear()
			{
				mobjParent.CheckNoDataSource();
				ClearInternal();
			}

			/// 
			/// Retrieves the index within the collection of the specified item.
			/// </summary>
			/// The zero-based index where the item is located within the collection; otherwise, -1.</returns>
			/// <param name="objValue">An object representing the item to locate in the collection. </param>
			/// <exception cref="T:System.ArgumentNullException">The value parameter was null. </exception>
			public int IndexOf(object objValue)
			{
				return mobjList.IndexOf(objValue);
			}

			/// 
			/// Provides a way to initialize the collection from serialization
			/// </summary>
			/// <param name="arrItems"></param>
			internal void SetItemsInternal(object[] arrItems)
			{
				mobjList.AddRange(arrItems);
			}

			/// 
			/// Removes an item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> at the specified index.
			/// </summary>
			/// <param name="intIndex">The index of the item to remove. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
			public void RemoveAt(int intIndex)
			{
				mobjParent.CheckNoDataSource();
				if (intIndex < 0 || intIndex >= mobjList.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", intIndex.ToString(CultureInfo.CurrentCulture)));
				}
				mobjParent.SetValue(SelectedIndexProperty, -1);
				mobjList.RemoveAt(intIndex);
				mobjParent.UpdateText();
				mobjParent.UpdateParams(AttributeType.Control);
			}

			/// 
			/// Inserts an item into the collection at the specified index.
			/// </summary>
			/// The zero-based index of the newly added item.</returns>
			/// <param name="objItem">An object representing the item to insert. </param>
			/// <param name="intIndex">The zero-based index location where the item is inserted. </param>
			/// <exception cref="T:System.ArgumentNullException">The item was null. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of items in the collection. </exception>
			public void Insert(int intIndex, object objItem)
			{
				mobjParent.CheckNoDataSource();
				mobjParent.Update();
				mobjList.Insert(intIndex, objItem);
			}
		}

		/// 
		/// Provides a property reference to CharacterCasing property.
		/// </summary>
		private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(ComboBox), new SerializablePropertyMetadata(CharacterCasing.Normal));

		/// 
		/// The mintDropDownWidth property registration.
		/// </summary>
		private static readonly SerializableProperty DropDownWidthProperty = SerializableProperty.Register("DropDownWidth", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to SelectionLength property.
		/// </summary>
		private static readonly SerializableProperty SelectionLengthProperty = SerializableProperty.Register("SelectionLength", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to SelectionStart property.
		/// </summary>
		private static readonly SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(0));

		/// 
		/// The mblnSorted property registration.
		/// </summary>
		private static readonly SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(false));

		/// 
		/// The mintSelectedIndex property registration.
		/// </summary>
		private static readonly SerializableProperty SelectedIndexProperty = SerializableProperty.Register("SelectedIndex", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));

		/// 
		/// The menmDropDownStyle property registration. 
		/// </summary>
		private static readonly SerializableProperty DropDownStyleProperty = SerializableProperty.Register("DropDownStyle", typeof(ComboBoxStyle), typeof(ComboBox), new SerializablePropertyMetadata(ComboBoxStyle.DropDown));

		/// 
		/// The menmAutoCompleteMode property registration.
		/// </summary>
		private static readonly SerializableProperty AutoCompleteModeProperty = SerializableProperty.Register("AutoCompleteMode", typeof(AutoCompleteMode), typeof(ComboBox), new SerializablePropertyMetadata(AutoCompleteMode.None));

		/// 
		/// The menmAutoCompleteSource property registration.
		/// </summary>
		private static readonly SerializableProperty AutoCompleteSourceProperty = SerializableProperty.Register("AutoCompleteSource", typeof(AutoCompleteSource), typeof(ComboBox), new SerializablePropertyMetadata(AutoCompleteSource.None));

		/// 
		/// The CodeMember property registration.
		/// </summary>
		private static readonly SerializableProperty CodeMemberProperty = SerializableProperty.Register("CodeMember", typeof(string), typeof(ComboBox), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// The mintMaxItems property registration.
		/// </summary>
		private static readonly SerializableProperty MaxItemsProperty = SerializableProperty.Register("MaxItems", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(8));

		/// 
		/// The SelectedIndexChangedQueued event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangedQueuedEvent;

		/// 
		/// The SelectedIndexChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangedEvent;

		/// 
		/// The SelectionChangeCommitted event registration.
		/// </summary>
		private static readonly SerializableEvent SelectionChangeCommittedEvent;

		/// 
		/// The IntegralHeight property registration.
		/// </summary>
		private static readonly SerializableProperty IntegralHeightProperty;

		/// 
		/// The SelectedText property registration.
		/// </summary>
		private static readonly SerializableProperty SelectedTextProperty;

		/// 
		/// The MaxBindedDropDownItems property registration.
		/// </summary>
		private static readonly SerializableProperty MaxBoundDropDownItemsProperty;

		/// 
		///
		/// </summary>
		private static SerializableProperty IsAutoCompleteProperty;

		/// 
		/// The dropped down property
		/// </summary>
		private static readonly SerializableProperty DroppedDownProperty;

		/// 
		/// The drop down event
		/// </summary>
		private static readonly SerializableEvent DropDownEvent;

		/// 
		/// The drop down closed event
		/// </summary>
		private static readonly SerializableEvent DropDownClosedEvent;

		/// 
		/// The list box item collection
		/// </summary>
		[NonSerialized]
		private ObjectCollection mobjItems = null;

		/// 
		/// Gets the selection change committed handler.
		/// </summary>
		private EventHandler SelectionChangeCommittedHandler => (EventHandler)GetHandler(SelectionChangeCommitted);

		/// 
		/// Gets the hanlder for the SelectedIndexChanged event.
		/// </summary>
		private EventHandler SelectedIndexChangedHandler => (EventHandler)GetHandler(SelectedIndexChanged);

		/// Gets or sets the number of characters selected in the editable portion of the combo box.</summary>
		/// The number of characters selected in the combo box.</returns>
		/// <exception cref="T:System.ArgumentException">The value was less than zero. </exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TextBoxSelectionLengthDescr")]
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		public virtual int SelectionLength
		{
			get
			{
				return GetValue(SelectionLengthProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SelectionLength", SR.GetString("InvalidArgument", "SelectionLength", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(SelectionLengthProperty, value))
				{
					InvokeSelection(SelectionStart, value);
				}
			}
		}

		/// Gets or sets the starting index of text selected in the combo box.</summary>
		/// The zero-based index of the first character in the string of the current text selection.</returns>
		/// <exception cref="T:System.ArgumentException">The value is less than zero. </exception>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[SRDescription("TextBoxSelectionStartDescr")]
		public int SelectionStart
		{
			get
			{
				return GetValue(SelectionStartProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidArgument", "SelectionStart", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(SelectionStartProperty, value))
				{
					InvokeSelection(value, SelectionLength);
				}
			}
		}

		/// 
		/// Gets the hanlder for the SelectedIndexChangedQueued event.
		/// </summary>
		private EventHandler SelectedIndexChangedQueuedHandler => (EventHandler)GetHandler(SelectedIndexChangedQueued);

		/// 
		/// Gets the drop down handler.
		/// </summary>
		/// 
		/// The drop down handler.
		/// </value>
		private EventHandler DropDownHandler => (EventHandler)GetHandler(DropDown);

		/// 
		/// Gets the drop down closed handler.
		/// </summary>
		/// 
		/// The drop down closed handler.
		/// </value>
		private EventHandler DropDownClosedHandler => (EventHandler)GetHandler(DropDownClosed);

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize
		{
			get
			{
				int serializableDataInitialSize = base.SerializableDataInitialSize;
				return serializableDataInitialSize + SerializationWriter.GetRequiredCapacity(mobjItems);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is auto complete.
		/// </summary>
		/// 
		/// 	true</c> if this instance is auto complete; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public bool IsAutoComplete
		{
			get
			{
				return GetValue(IsAutoCompleteProperty);
			}
			set
			{
				if (SetValue(IsAutoCompleteProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Indicates if all characters should be left alone or converted to uppercase or lowercase
		/// </summary>
		/// </value>
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxCharacterCasingDescr")]
		[DefaultValue(CharacterCasing.Normal)]
		public virtual CharacterCasing CharacterCasing
		{
			get
			{
				return GetValue(CharacterCasingProperty);
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(CharacterCasing));
				}
				if (SetValue(CharacterCasingProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets a value indicating whether animation is enabled by default.
		/// </summary>
		/// true</c> if animation is enabled by default; otherwise, false</c>.</value>
		protected override bool DefaultAnimation => base.AnimationEnabled;

		/// 
		/// Gets a value indicating whether this instance has a custom drop down.
		/// </summary>
		/// 
		/// 	true</c> if this instance has a custom drop down; otherwise, false</c>.
		/// </value>
		protected virtual bool IsCustomDropDown => false;

		/// 
		/// Gets or sets the maximum number of items to be shown in the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
		/// </summary>
		/// The maximum number of items of in the drop-down portion. The minimum for this property is 1 and the maximum is 100.</returns>
		/// <exception cref="T:System.ArgumentException">The maximum number is set less than one or greater than 100. </exception>
		[DefaultValue(8)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("ComboBoxMaxDropDownItemsDescr")]
		public int MaxDropDownItems
		{
			get
			{
				return GetValue(MaxItemsProperty);
			}
			set
			{
				if (value < 1 || value > 100)
				{
					object[] arrArgs = new object[4]
					{
						"MaxDropDownItems",
						value.ToString(CultureInfo.CurrentCulture),
						1.ToString(CultureInfo.CurrentCulture),
						100.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("MaxDropDownItems", SR.GetString("InvalidBoundArgument", arrArgs));
				}
				if (SetValue(MaxItemsProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the items in the combo box are sorted.
		/// </summary>
		/// true if the combo box is sorted; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.ArgumentException">An attempt was made to sort a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that is attached to a data source. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ComboBoxSortedDescr")]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		public bool Sorted
		{
			get
			{
				return GetValue(SortedProperty);
			}
			set
			{
				if (SetValue(SortedProperty, value))
				{
					RefreshItems();
					SelectedIndex = -1;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the max bound drop down items.
		/// </summary>
		/// 
		/// The max bound drop down items.
		/// </value>
		[DefaultValue(-1)]
		[SRCategory("CatData")]
		[SRDescription("Gets or sets a value indicating the maximal number of bound drop down items.")]
		public int MaxBoundDropDownItems
		{
			get
			{
				return GetValue(MaxBoundDropDownItemsProperty);
			}
			set
			{
				if (SetValue(MaxBoundDropDownItemsProperty, value))
				{
					RefreshItems();
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the auto complete mode.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(AutoCompleteMode.None)]
		[SRDescription("ComboBoxAutoCompleteModeDescr")]
		public AutoCompleteMode AutoCompleteMode
		{
			get
			{
				return GetValue(AutoCompleteModeProperty);
			}
			set
			{
				if (SetValue(AutoCompleteModeProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the drop down style.
		/// </summary>
		/// </value>
		[DefaultValue(ComboBoxStyle.DropDown)]
		public virtual ComboBoxStyle DropDownStyle
		{
			get
			{
				return GetValue(DropDownStyleProperty);
			}
			set
			{
				if (SetValue(DropDownStyleProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the width of the of the drop-down portion of a combo box.</summary>
		/// The width, in pixels, of the drop-down box.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value is less than one. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ComboBoxDropDownWidthDescr")]
		[SRCategory("CatBehavior")]
		public int DropDownWidth
		{
			get
			{
				int value = GetValue(DropDownWidthProperty);
				if (value != -1)
				{
					return value;
				}
				return base.Width;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("DropDownWidth", SR.GetString("InvalidArgument", "DropDownWidth", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(DropDownWidthProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the auto-completion source.
		/// </summary>
		[DefaultValue(AutoCompleteSource.None)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRDescription("ComboBoxAutoCompleteSourceDescr")]
		[Browsable(true)]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return GetValue(AutoCompleteSourceProperty);
			}
			set
			{
				SetValue(AutoCompleteSourceProperty, value);
			}
		}

		/// 
		/// Gets an object representing the collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ObjectCollection Items => mobjItems;

		/// 
		/// Gets or sets the index specifying the currently selected item.
		/// </summary>
		/// A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified index is less than or equal to -2.-or- The specified index is greater than or equal to the number of items in the combo box. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ComboBoxSelectedIndexDescr")]
		public override int SelectedIndex
		{
			get
			{
				if (mobjItems.Count > 0)
				{
					return GetValue(SelectedIndexProperty);
				}
				return -1;
			}
			set
			{
				int num = 0;
				if (mobjItems != null)
				{
					num = mobjItems.Count;
				}
				if (value < -1 || value >= num)
				{
					throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidArgument", "SelectedIndex", value.ToString(CultureInfo.CurrentCulture)));
				}
				bool flag = false;
				if (SetValue(SelectedIndexProperty, value))
				{
					UpdateText();
					OnSelectedIndexChanged(EventArgs.Empty);
					flag = true;
				}
				else
				{
					flag = UpdateText();
				}
				if (flag)
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Override the Control Text.
		/// When the combo control is bound to a BindingSource Text property (a string data member in the DB),
		/// we have to set the combo index to match the text.
		/// </summary>
		public override string Text
		{
			get
			{
				if (SelectedItem != null && !base.BindingFieldEmpty)
				{
					if (!base.FormattingEnabled)
					{
						return FilterItemOnProperty(SelectedItem).ToString();
					}
					string itemText = base.GetItemText(SelectedItem);
					if (!string.IsNullOrEmpty(itemText) && string.Compare(itemText, base.Text, ignoreCase: true, CultureInfo.CurrentCulture) == 0)
					{
						return itemText;
					}
				}
				return base.Text;
			}
			set
			{
				if (Text != value)
				{
					InternalText = value;
					Update();
				}
			}
		}

		/// 
		/// Set text without raising any events
		/// </summary>
		/// </value>
		internal override string InternalText
		{
			set
			{
				if (DropDownStyle == ComboBoxStyle.DropDownList && !string.IsNullOrEmpty(value) && FindStringExact(value) == -1)
				{
					return;
				}
				base.InternalText = value;
				object obj = null;
				obj = SelectedItem;
				if (base.DesignMode)
				{
					return;
				}
				if (value == null)
				{
					SetValue(SelectedIndexProperty, -1);
				}
				else if (value != null && (obj == null || string.Compare(value, base.GetItemText(obj), ignoreCase: false, CultureInfo.CurrentCulture) != 0))
				{
					int num = FindStringIgnoreCase(value);
					if (num != -1 && SetValue(SelectedIndexProperty, num))
					{
						OnSelectedIndexChanged(EventArgs.Empty);
					}
				}
			}
		}

		/// 
		/// Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
		/// </summary>
		/// The object that is the currently selected item or null if there is no currently selected item.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
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
				int selectedIndex = SelectedIndex;
				if (selectedIndex == -1)
				{
					return null;
				}
				return mobjItems[selectedIndex];
			}
			set
			{
				SelectedIndex = mobjItems.IndexOf(value);
			}
		}

		/// 
		/// Gets or sets the code member.
		/// </summary>
		/// The code member.</value>
		[DefaultValue("")]
		public string CodeMember
		{
			get
			{
				return GetValue(CodeMemberProperty);
			}
			set
			{
				if (SetValue(CodeMemberProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets the items comparer object.
		/// </summary>
		[Browsable(false)]
		public virtual IComparer ItemsComparer => new ItemComparer(this);

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets or sets a value indicating whether [integral height].
		/// </summary>
		/// 
		///   true</c> if [integral height]; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IntegralHeight
		{
			get
			{
				return GetValue(IntegralHeightProperty);
			}
			set
			{
				SetValue(IntegralHeightProperty, value);
			}
		}

		/// Gets or sets a value indicating the currently selected text in the control.</summary>
		/// A string that represents the currently selected text in the text box.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string SelectedText
		{
			get
			{
				return GetValue(SelectedTextProperty);
			}
			set
			{
				SetValue(SelectedTextProperty, value);
			}
		}

		/// Gets or sets the appearance of the <see cref="T:Gizmox.WebGui.Forms.ComboBox"></see>.</summary>
		/// One of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. The options are Flat, Popup, Standard, and System. The default is Standard.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. </exception>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[DefaultValue(FlatStyle.Standard)]
		[SRDescription("ComboBoxFlatStyleDescr")]
		[SRCategory("CatAppearance")]
		public FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Standard;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether [dropped down].
		/// </summary>
		/// 
		///   true</c> if [dropped down]; otherwise, false</c>.
		/// </value>
		[SRDescription("ComboBoxDroppedDownDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(true)]
		public bool DroppedDown
		{
			get
			{
				return DroppedDownInternal;
			}
			set
			{
				if (value && DropDownStyle != ComboBoxStyle.Simple)
				{
					OpenDropDownPopup();
				}
				DroppedDownInternal = value;
				if (!value && DropDownStyle != ComboBoxStyle.Simple)
				{
					CloseDropDownPopup();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [dropped down internal].
		/// </summary>
		/// 
		///   true</c> if [dropped down internal]; otherwise, false</c>.
		/// </value>
		internal bool DroppedDownInternal
		{
			get
			{
				return GetValue(DroppedDownProperty);
			}
			set
			{
				SetValue(DroppedDownProperty, value);
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// 
		/// The default size.
		/// </value>
		protected override Size DefaultSize => new Size(121, PreferredHeight);

		/// 
		/// Gets the height of the preferred.
		/// </summary>
		/// 
		/// The height of the preferred.
		/// </value>
		private int PreferredHeight
		{
			get
			{
				if (DropDownStyle == ComboBoxStyle.Simple)
				{
					return GetSimpleComboHeight();
				}
				return GetComboHeight();
			}
		}

		/// 
		/// Occurs when [selection change committed].
		/// </summary>
		[SRCategory("CatBehavior")]
		[SRDescription("selectionChangeCommittedEventDescr")]
		public event EventHandler SelectionChangeCommitted
		{
			add
			{
				AddCriticalHandler(SelectionChangeCommittedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectionChangeCommittedEvent, value);
			}
		}

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedIndex"></see> property has changed.
		/// </summary>
		[SRDescription("selectedIndexChangedEventDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler SelectedIndexChanged
		{
			add
			{
				AddCriticalHandler(SelectedIndexChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedIndexChangedEvent, value);
			}
		}

		/// 
		/// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
		/// </summary>
		[SRDescription("Occurs in client mode when the control selected index is changing.")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectedIndexChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Occurs when [client text changed].
		/// </summary>
		[SRDescription("Occurs in client mode when the control text has been changed.")]
		[Category("Client")]
		public event ClientEventHandler ClientTextChanged
		{
			add
			{
				AddClientHandler("TextChange", value);
			}
			remove
			{
				RemoveClientHandler("TextChange", value);
			}
		}

		/// 
		/// Occurs when [client text changed].
		/// </summary>
		[SRDescription("Occurs when DropDown window displayed in Client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientDropDown
		{
			add
			{
				AddClientHandler("DropDownWindow", value);
			}
			remove
			{
				RemoveClientHandler("DropDownWindow", value);
			}
		}

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedItem"></see> property has changed.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler SelectedItemChanged
		{
			add
			{
				SelectedIndexChanged += value;
			}
			remove
			{
				SelectedIndexChanged -= value;
			}
		}

		/// 
		/// Occurs when the SelectedIndex property has changed (Queued).
		/// </summary>
		public event EventHandler SelectedIndexChangedQueued
		{
			add
			{
				AddHandler(SelectedIndexChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(SelectedIndexChangedQueuedEvent, value);
			}
		}

		/// 
		/// Occurs when [drop down].
		/// </summary>
		[SRDescription("ComboBoxOnDropDownDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler DropDown
		{
			add
			{
				AddCriticalHandler(DropDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownEvent, value);
			}
		}

		/// 
		/// Occurs when [drop down closed].
		/// </summary>
		[SRCategory("CatBehavior")]
		[SRDescription("ComboBoxOnDropDownClosedDescr")]
		public event EventHandler DropDownClosed
		{
			add
			{
				AddCriticalHandler(DropDownClosedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownClosedEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> class.
		/// </summary>
		public ComboBox()
		{
			mobjItems = CreateItemCollection();
			SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, blnValue: false);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mobjItems = CreateItemCollection();
			mobjItems.SetItemsInternal(objReader.ReadArray());
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteArray(mobjItems);
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			string codeMember = CodeMember;
			bool flag = !string.IsNullOrEmpty(codeMember);
			bool blnShouldRenderItemImage = ShouldRenderImage();
			bool blnShouldRenderItemColor = ShouldRenderColor();
			bool flag2 = codeMember == "#Index";
			PropertyInfo propertyInfo = null;
			if (flag && !flag2 && mobjItems.Count > 0)
			{
				Type type = mobjItems[0].GetType();
				propertyInfo = type.GetProperty(CodeMember);
				if (propertyInfo == null)
				{
					flag = false;
				}
			}
			objWriter.WriteStartElement("OS");
			RenderAnimationAttributes((IAttributeWriter)objWriter);
			RenderOptions(objWriter, flag, blnShouldRenderItemImage, blnShouldRenderItemColor, flag2, propertyInfo);
			objWriter.WriteEndElement();
		}

		/// 
		/// Renders the options.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnUseCode">if set to true</c> [BLN use code].</param>
		/// <param name="blnShouldRenderItemImage">if set to true</c> [BLN should render item image].</param>
		/// <param name="blnShouldRenderItemColor">if set to true</c> [BLN should render item color].</param>
		/// <param name="blnUseIndexCode">if set to true</c> [BLN use index code].</param>
		/// <param name="objUseCodeProp">The obj use code prop.</param>
		protected virtual void RenderOptions(IResponseWriter objWriter, bool blnUseCode, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, bool blnUseIndexCode, PropertyInfo objUseCodeProp)
		{
			for (int i = 0; i < mobjItems.Count; i++)
			{
				objWriter.WriteStartElement("O");
				objWriter.WriteAttributeString("IX", i.ToString());
				if (blnUseCode)
				{
					if (blnUseIndexCode)
					{
						objWriter.WriteAttributeString("CD", i.ToString());
					}
					else
					{
						objWriter.WriteAttributeString("CD", objUseCodeProp.GetValue(mobjItems[i], null) as string);
					}
				}
				object obj = mobjItems[i];
				if (obj == null)
				{
					objWriter.WriteAttributeString("TX", string.Empty);
				}
				else
				{
					RenderItemIdAttribute(objWriter, obj);
					objWriter.WriteAttributeText("TX", GetItemText(obj), (TextFilter)5);
					RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, obj);
				}
				objWriter.WriteEndElement();
			}
		}

		/// 
		/// Writes the color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="strColor">Color of the STR.</param>
		protected override void WriteColorAttribute(IResponseWriter objWriter, string strColor)
		{
			objWriter.WriteAttributeString("CO", $"background:{strColor};");
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (IsCustomDropDown)
			{
				objWriter.WriteAttributeString("CDD", "1");
			}
			switch (DropDownStyle)
			{
			case ComboBoxStyle.DropDown:
				objWriter.WriteAttributeString("S", "DD");
				break;
			case ComboBoxStyle.DropDownList:
				objWriter.WriteAttributeString("S", "DDL");
				break;
			case ComboBoxStyle.Simple:
				objWriter.WriteAttributeString("S", "S");
				break;
			}
			int value = GetValue(DropDownWidthProperty);
			if (value != -1)
			{
				objWriter.WriteAttributeString("DDW", value.ToString());
			}
			switch (AutoCompleteMode)
			{
			case AutoCompleteMode.None:
				objWriter.WriteAttributeString("ACM", "N");
				break;
			case AutoCompleteMode.Suggest:
				objWriter.WriteAttributeString("ACM", "S");
				break;
			case AutoCompleteMode.Append:
				objWriter.WriteAttributeString("ACM", "A");
				break;
			case AutoCompleteMode.SuggestAppend:
				objWriter.WriteAttributeString("ACM", "SA");
				break;
			}
			RenderValue(objWriter);
			RenderText(objWriter);
			RenderItemDefinitions(objWriter);
			objWriter.WriteAttributeString("PUOH", GetPopupOffsetHeight());
			if (ShouldRenderColor())
			{
				objWriter.WriteAttributeString("SHC", "1");
			}
			if (ShouldRenderImage())
			{
				objWriter.WriteAttributeString("SHI", "1");
			}
			RenderCharacterCasingAttribute(objWriter, blnForceRender: false);
			RenderIsAutoCompleteAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the is auto complete attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool isAutoComplete = IsAutoComplete;
			if (!isAutoComplete || blnForceRender)
			{
				objWriter.WriteAttributeString("IAC", isAutoComplete ? "1" : "0");
			}
		}

		/// 
		/// Renders the character casing attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderCharacterCasingAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			CharacterCasing characterCasing = CharacterCasing;
			if (characterCasing != CharacterCasing.Normal || blnForceRender)
			{
				byte b = (byte)characterCasing;
				objWriter.WriteAttributeString("CC", b.ToString());
			}
		}

		/// 
		/// Render the text attrbute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderText(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
		}

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		protected virtual void RenderValue(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("VLB", SelectedIndex.ToString());
		}

		/// 
		/// Renders the item definitions.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderItemDefinitions(IAttributeWriter objWriter)
		{
			int preferdItemHeight = GetPreferdItemHeight();
			int num = 0;
			if (DropDownStyle == ComboBoxStyle.Simple)
			{
				int num2 = 17;
				if (base.Skin is ComboBoxSkin comboBoxSkin)
				{
					num2 = comboBoxSkin.SimpleComboBoxInputHeight;
				}
				num = (base.Height - num2) / preferdItemHeight;
			}
			else
			{
				num = Math.Min(MaxDropDownItems, Items.Count);
			}
			objWriter.WriteAttributeString("MAX", num.ToString());
			objWriter.WriteAttributeString("IMH", preferdItemHeight);
		}

		/// 
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
				RenderText(objWriter);
				RenderValue(objWriter);
				RenderIsAutoCompleteAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderItemDefinitions(objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderCharacterCasingAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string text = null;
			bool result = false;
			bool.TryParse(objEvent["UpdateDroppedDownOnly"], out result);
			switch (objEvent.Type)
			{
			case "ValueChange":
			{
				int num = int.Parse(objEvent["VLB"]);
				if (num > -1 && (SetValue(SelectedIndexProperty, num) || base.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick))
				{
					OnSelectionChangeCommitted(EventArgs.Empty);
					UpdateText();
					OnSelectedIndexChanged(EventArgs.Empty);
				}
				break;
			}
			case "TextChange":
			{
				text = CommonUtils.DecodeText(objEvent["VLB"]);
				if (text == string.Empty)
				{
					text = null;
				}
				InternalText = text;
				int objValue = FindStringExact(text);
				SetValue(SelectedIndexProperty, objValue);
				break;
			}
			case "DropDownWindow":
			{
				if (DropDownHandler != null)
				{
					OnDropDown(EventArgs.Empty);
				}
				DroppedDownInternal = true;
				Form customDropDown = GetCustomDropDown();
				if (customDropDown != null)
				{
					customDropDown.Closed += CustomDropDown_Closed;
					customDropDown.ShowPopup(Form, this, DialogAlignment.Below);
					customDropDown = null;
				}
				break;
			}
			case "DropDown":
				if (!result)
				{
					OpenDropDownPopup();
				}
				DroppedDownInternal = true;
				break;
			case "DropDownClosed":
				DroppedDownInternal = false;
				if (!result)
				{
					OnDropDownClosed(EventArgs.Empty);
				}
				break;
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.SelectedValueChangedHandler != null || SelectedIndexChangedHandler != null || SelectionChangeCommittedHandler != null || IsPostBackRequired)
			{
				criticalEventsData.Set("VC");
			}
			if (DropDownHandler != null)
			{
				criticalEventsData.Set("CBDD");
			}
			if (DropDownClosedHandler != null)
			{
				criticalEventsData.Set("CBDDC");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			KeyCaptures keyEventCaptures = base.GetKeyEventCaptures();
			keyEventCaptures |= KeyCaptures.UpKeyCapture;
			keyEventCaptures |= KeyCaptures.DownKeyCapture;
			keyEventCaptures |= KeyCaptures.EndKeyCapture;
			keyEventCaptures |= KeyCaptures.HomeKeyCapture;
			keyEventCaptures |= KeyCaptures.EscKeyCapture;
			keyEventCaptures |= KeyCaptures.PageDownKeyCapture;
			return keyEventCaptures | KeyCaptures.PageUpKeyCapture;
		}

		/// 
		/// Raises the <see cref="E:SelectionChangeCommitted" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnSelectionChangeCommitted(EventArgs e)
		{
			SelectionChangeCommittedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:SelectedIndexChanged" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnSelectedIndexChanged(EventArgs objEventArgs)
		{
			base.OnSelectedIndexChanged(objEventArgs);
			OnSelectedIndexChangedQueued(objEventArgs);
			SelectedIndexChangedHandler?.Invoke(this, objEventArgs);
			CurrencyManager dataManager = base.DataManager;
			int selectedIndex = SelectedIndex;
			if (dataManager != null && dataManager.Position != selectedIndex && (!base.FormattingEnabled || selectedIndex != -1))
			{
				dataManager.Position = selectedIndex;
			}
		}

		/// 
		/// Raises the OnSelectedIndexChangedQueued event
		/// </summary>
		/// <param name="objEventArgs"></param>
		protected virtual void OnSelectedIndexChangedQueued(EventArgs objEventArgs)
		{
			SelectedIndexChangedQueuedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnDataSourceChanged(EventArgs e)
		{
			bool sorted = Sorted;
			object dataSource = DataSource;
			if (sorted && dataSource != null)
			{
				DataSource = null;
				throw new InvalidOperationException(SR.GetString("ComboBoxDataSourceWithSort"));
			}
			if (dataSource == null)
			{
				SelectedIndex = -1;
				Items.ClearInternal();
			}
			if (!sorted)
			{
				base.OnDataSourceChanged(e);
			}
			RefreshItems();
		}

		/// 
		/// Raises the <see cref="E:DropDown" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnDropDown(EventArgs objEventArgs)
		{
			DropDownHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:DropDownClosed" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnDropDownClosed(EventArgs objEventArgs)
		{
			DropDownClosedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Handles the Closed event of the CustomDropDown control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void CustomDropDown_Closed(object sender, EventArgs e)
		{
			if (sender is Form)
			{
				((Form)sender).Closed -= CustomDropDown_Closed;
			}
			DroppedDownInternal = false;
			OnDropDownClosed(EventArgs.Empty);
		}

		/// 
		/// Updates the text according to selected index.
		/// </summary>
		/// Return boolean that indicates if text has been changed.</returns>
		private bool UpdateText()
		{
			bool result = false;
			string text = string.Empty;
			if (SelectedIndex != -1)
			{
				object obj = Items[SelectedIndex];
				if (obj != null)
				{
					text = base.GetItemText(obj);
				}
			}
			if (Text != text)
			{
				InternalText = text;
				result = true;
			}
			return result;
		}

		/// 
		/// Gets the popup height offset.
		/// </summary>
		/// </returns>
		private double GetPopupOffsetHeight()
		{
			if (base.Skin is ComboBoxSkin comboBoxSkin)
			{
				return comboBoxSkin.PopupWindowOffsetHeight;
			}
			return 0.0;
		}

		/// 
		/// Gets the height of the preferd item font.        
		/// </summary>
		/// </returns>
		internal int GetPreferdItemHeight()
		{
			if (base.Skin is ComboBoxSkin comboBoxSkin)
			{
				PaddingValue padding = comboBoxSkin.PopupItemStyle.Padding;
				int val = 0;
				if (ShouldRenderColor())
				{
					val = comboBoxSkin.ColorBoxHeight;
				}
				int val2 = 0;
				if (ShouldRenderImage())
				{
					val2 = comboBoxSkin.ImageBoxHeight;
				}
				int num = 0;
				if (padding != null)
				{
					num = padding.Top + padding.Bottom;
				}
				int val3 = Math.Max(CommonUtils.GetFontHeight(Font), val);
				val3 = Math.Max(val2, val3);
				return val3 + num;
			}
			return 0;
		}

		/// 
		/// Creates the item collection.
		/// </summary>
		protected virtual ObjectCollection CreateItemCollection()
		{
			return new ObjectCollection(this);
		}

		/// When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
		/// <param name="intIndex">The zero-based index of the item whose data to refresh. </param>
		protected override void RefreshItem(int intIndex)
		{
			Update();
		}

		/// When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
		/// <param name="objItems">An array of items.</param>
		protected override void SetItemsCore(IList objItems)
		{
			Items.ClearInternal();
			if (objItems != null)
			{
				object[] array = new object[objItems.Count];
				objItems.CopyTo(array, 0);
				if (MaxBoundDropDownItems != -1 && objItems.Count > MaxBoundDropDownItems)
				{
					object[] array2 = new object[objItems.Count];
					objItems.CopyTo(array2, 0);
					array = new object[MaxBoundDropDownItems];
					Array.Copy(array2, array, MaxBoundDropDownItems);
				}
				Items.AddRangeInternal(array);
			}
		}

		/// 
		/// When overridden in a derived class, sets the object with the specified index in the derived class.
		/// </summary>
		/// <param name="intIndex">The array index of the object.</param>
		/// <param name="objValue">The object.</param>
		protected override void SetItemCore(int intIndex, object objValue)
		{
			Items.SetItemInternal(intIndex, objValue);
		}

		/// 
		/// Resets the width of the drop down.
		/// </summary>
		internal void ResetDropDownWidth()
		{
			RemoveValue(DropDownWidthProperty);
		}

		/// 
		/// Shoulds the width of the serialize drop down.
		/// </summary>
		/// </returns>
		internal bool ShouldSerializeDropDownWidth()
		{
			return ContainsValue(DropDownWidthProperty);
		}

		/// 
		/// Finds the item in the ListBox that has this code.
		/// </summary>
		/// <param name="strCode">The STR code.</param>
		/// </returns>
		public int FindCode(string strCode)
		{
			string codeMember = CodeMember;
			if (!string.IsNullOrEmpty(codeMember))
			{
				int num = 0;
				bool flag = codeMember == "#Index";
				PropertyInfo propertyInfo = null;
				if (mobjItems.Count > 0)
				{
					Type type = mobjItems[0].GetType();
					propertyInfo = type.GetProperty(codeMember);
				}
				foreach (object mobjItem in mobjItems)
				{
					if (flag)
					{
						if (num.ToString() == strCode)
						{
							return num;
						}
					}
					else if (propertyInfo != null)
					{
						string text = propertyInfo.GetValue(mobjItem, null) as string;
						if (text == strCode)
						{
							return num;
						}
					}
					num++;
				}
			}
			return -1;
		}

		/// Finds the first item in the combo box that starts with the specified string.</summary>
		/// The zero-based index of the first item found; returns -1 if no match is found.</returns>
		/// <param name="strFindValue">The <see cref="T:System.String"></see> to search for. </param>
		/// 1</filterpriority>
		public int FindString(string strFindValue)
		{
			return FindString(strFindValue, -1);
		}

		/// Finds the first item after the given index which starts with the given string. The search is not case sensitive.</summary>
		/// The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
		/// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
		/// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is greater than the last index in the collection. </exception>
		/// 1</filterpriority>
		public int FindString(string strValue, int intStartIndex)
		{
			if (strValue == null)
			{
				return -1;
			}
			if (Items == null || Items.Count == 0)
			{
				return -1;
			}
			if (intStartIndex < -1 || intStartIndex >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return FindStringInternal(strValue, Items, intStartIndex, blnExact: false);
		}

		/// Finds the first item in the combo box that matches the specified string.</summary>
		/// The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
		/// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
		/// 1</filterpriority>
		public int FindStringExact(string strValue)
		{
			return FindStringExact(strValue, -1, blnIgnoreCase: true);
		}

		/// Finds the first item after the specified index that matches the specified string.</summary>
		/// The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
		/// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
		/// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is equal to the last index in the collection. </exception>
		/// 1</filterpriority>
		public int FindStringExact(string strValue, int intStartIndex)
		{
			return FindStringExact(strValue, intStartIndex, blnIgnoreCase: true);
		}

		/// 
		/// Finds the string exact.
		/// </summary>
		/// <param name="strValue">The string.</param>
		/// <param name="intStartIndex">The start index.</param>
		/// <param name="blnIgnoreCase">if set to true</c> should ignorecase.</param>
		/// </returns>
		internal int FindStringExact(string strValue, int intStartIndex, bool blnIgnoreCase)
		{
			if (strValue == null)
			{
				return -1;
			}
			if (Items == null || Items.Count == 0)
			{
				return -1;
			}
			if (intStartIndex < -1 || intStartIndex >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return FindStringInternal(strValue, Items, intStartIndex, blnExact: true, blnIgnoreCase);
		}

		/// 
		/// Finds the string and ignores case.
		/// </summary>
		/// <param name="strValue">The value.</param>
		/// </returns>
		internal int FindStringIgnoreCase(string strValue)
		{
			int num = FindStringExact(strValue, -1, blnIgnoreCase: false);
			if (num == -1)
			{
				num = FindStringExact(strValue, -1, blnIgnoreCase: true);
			}
			return num;
		}

		/// 
		/// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.
		/// </summary>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>. The string includes the type and the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.</returns>
		public override string ToString()
		{
			string text = base.ToString();
			return text + ", Items.Count: " + ((mobjItems == null) ? 0.ToString() : mobjItems.Count.ToString());
		}

		/// Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> items.</summary>
		protected override void RefreshItems()
		{
			int selectedIndex = SelectedIndex;
			ObjectCollection objectCollection = mobjItems;
			mobjItems = CreateItemCollection();
			object[] array = null;
			if (base.DataManager != null && base.DataManager.Count != -1)
			{
				int num = base.DataManager.Count;
				if (MaxBoundDropDownItems != -1)
				{
					num = Math.Min(MaxBoundDropDownItems, num);
				}
				array = new object[num];
				for (int i = 0; i < num; i++)
				{
					object obj = base.DataManager[i];
					if (obj != null)
					{
						array[i] = base.DataManager[i];
					}
				}
			}
			else if (objectCollection != null)
			{
				array = new object[objectCollection.Count];
				objectCollection.CopyTo(array, 0);
			}
			if (array != null)
			{
				Items.AddRangeInternal(array);
			}
			if (base.DataManager != null)
			{
				SelectedIndex = base.DataManager.Position;
			}
			else
			{
				SelectedIndex = selectedIndex;
			}
		}

		/// 
		/// Operated on this instance after clear items action
		/// </summary>
		internal void Clear()
		{
			RemoveValue(SelectedIndexProperty);
			if (DropDownStyle == ComboBoxStyle.DropDownList)
			{
				UpdateText();
			}
		}

		/// 
		/// Checks the no data source.
		/// </summary>
		private void CheckNoDataSource()
		{
			if (DataSource != null)
			{
				throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
			}
		}

		/// Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SelectAll()
		{
			Select(0, int.MaxValue);
		}

		/// Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
		/// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
		/// <param name="intLength">The number of characters to select. </param>
		/// <exception cref="T:System.ArgumentException">The start is less than zero.-or- start plus length is less than zero. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Select(int intStart, int intLength)
		{
			if (intStart < 0)
			{
				throw new ArgumentOutOfRangeException("start", SR.GetString("InvalidArgument", "start", intStart.ToString(CultureInfo.CurrentCulture)));
			}
			int num = intStart + intLength;
			if (num < 0)
			{
				throw new ArgumentOutOfRangeException("length", SR.GetString("InvalidArgument", "length", intLength.ToString(CultureInfo.CurrentCulture)));
			}
			SetValue(SelectionLengthProperty, intLength);
			SetValue(SelectionStartProperty, intStart);
			InvokeSelection(intStart, intLength);
		}

		/// 
		/// Opens the drop down popup.
		/// </summary>
		private void OpenDropDownPopup()
		{
			InvokeMethodWithId("ComboBox_InvokeOpenPopup", true);
			if (!IsCustomDropDown)
			{
				OnDropDown(EventArgs.Empty);
			}
		}

		/// 
		/// Closes the drop down popup.
		/// </summary>
		private void CloseDropDownPopup()
		{
			InvokeMethodWithId("ComboBox_InvokeClosePopup", true);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new ComboBoxRenderer(this);
		}

		/// 
		/// Gets the custom form to display as drop down
		/// </summary>
		/// </returns>
		protected virtual Form GetCustomDropDown()
		{
			return null;
		}

		/// 
		/// Gets the height of the simple combo.
		/// </summary>
		/// </returns>
		private int GetSimpleComboHeight()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = GetPreferdItemHeight() * 8;
			if (base.Skin is ComboBoxSkin { SimpleComboBoxInputHeight: var simpleComboBoxInputHeight } comboBoxSkin)
			{
				if (comboBoxSkin.BorderStyle != BorderStyle.None)
				{
					num2 = (int)comboBoxSkin.BorderWidth * 2;
				}
				num3 = comboBoxSkin.Padding.Horizontal;
			}
			return num4 + num3 + num2;
		}

		/// 
		/// Gets the height of the combo.
		/// </summary>
		/// </returns>
		private int GetComboHeight()
		{
			int num = 0;
			int num2 = 0;
			Size stringMeasurements = CommonUtils.GetStringMeasurements("0", Font);
			if (base.Skin is ComboBoxSkin comboBoxSkin)
			{
				if (comboBoxSkin.BorderStyle != BorderStyle.None)
				{
					num = (int)comboBoxSkin.BorderWidth * 2;
				}
				num2 = comboBoxSkin.Padding.Horizontal;
			}
			return stringMeasurements.Height + num2 + num;
		}

		static ComboBox()
		{
			SelectedIndexChangedQueued = SerializableEvent.Register("SelectedIndexChangedQueued", typeof(EventHandler), typeof(ComboBox));
			SelectedIndexChanged = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ComboBox));
			SelectionChangeCommitted = SerializableEvent.Register("SelectionChangeCommitted", typeof(EventHandler), typeof(ComboBox));
			IntegralHeightProperty = SerializableProperty.Register("IntegralHeight", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(true));
			SelectedTextProperty = SerializableProperty.Register("SelectedText", typeof(string), typeof(ComboBox));
			MaxBoundDropDownItemsProperty = SerializableProperty.Register("MaxBindedDropDownItems", typeof(int), typeof(ComboBox), new SerializablePropertyMetadata(-1));
			IsAutoCompleteProperty = SerializableProperty.Register("IsAutoComplete", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(true));
			DroppedDownProperty = SerializableProperty.Register("DroppedDown", typeof(bool), typeof(ComboBox), new SerializablePropertyMetadata(false));
			DropDown = SerializableEvent.Register("DropDown", typeof(EventHandler), typeof(ComboBox));
			DropDownClosed = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ComboBox));
		}
	}
}
