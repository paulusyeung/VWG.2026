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
	/// Summary description for CheckedListBox.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Common Controls")]
	[ToolboxBitmap(typeof(CheckedListBox), "CheckedListBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[MetadataTag("CX")]
	[Skin(typeof(CheckedListBoxSkin))]
	public class CheckedListBox : ListBox
	{
		/// 
		/// Encapsulates the collection of checked items, including items in 
		/// an indeterminate state, in a <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox">
		/// </see> control.
		/// </summary>
		[Serializable]
		public class CheckedItemCollection : IList, ICollection, IEnumerable
		{
			private CheckedListBox mobjCheckedListBox;

			private ArrayList InternalCheckedObjects => mobjCheckedListBox.InternalCheckedObjects;

			/// Gets the number of items in the collection.</summary>
			/// The number of items in the collection.</returns>
			public int Count => InternalCheckedObjects.Count;

			/// Gets a value indicating if the collection is read-only.</summary>
			/// Always true.</returns>
			public bool IsReadOnly => true;

			/// Gets an object in the checked items collection.</summary>
			/// The object at the specified index. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
			/// <param name="index">An index into the collection of checked items. This collection index corresponds to the index of the checked item. </param>
			/// <exception cref="T:System.NotSupportedException">The object cannot be set.</exception>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public object this[int index]
			{
				get
				{
					return InternalCheckedObjects[index];
				}
				set
				{
				}
			}

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => InternalCheckedObjects.SyncRoot;

			bool IList.IsFixedSize => false;

			internal CheckedItemCollection(CheckedListBox objCheckedListBox)
			{
				mobjCheckedListBox = objCheckedListBox;
			}

			/// Determines whether the specified item is located in the collection.</summary>
			/// true if item is in the collection; otherwise, false.</returns>
			/// <param name="objItem">An object from the items collection. </param>
			public bool Contains(object objItem)
			{
				return InternalCheckedObjects.Contains(objItem);
			}

			/// Copies the entire collection into an existing array at a specified location within the array.</summary>
			/// <param name="objDestinationArray">The destination array. </param>
			/// <param name="index">The zero-based relative index in dest at which copying begins. </param>
			/// <exception cref="T:System.ArgumentNullException">array is null. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
			/// <exception cref="T:System.RankException">array is multidimensional. </exception>
			/// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
			/// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
			public void CopyTo(Array objDestinationArray, int index)
			{
				InternalCheckedObjects.CopyTo(objDestinationArray, index);
			}

			/// Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItems"></see> collection.</summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
			public IEnumerator GetEnumerator()
			{
				return InternalCheckedObjects.GetEnumerator();
			}

			/// Returns an index into the collection of checked items.</summary>
			/// The index of the object in the checked item collection or -1 if the object is not in the collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
			/// <param name="objItem">The object whose index you want to retrieve. This object must belong to the checked items collection. </param>
			public int IndexOf(object objItem)
			{
				return InternalCheckedObjects.IndexOf(objItem);
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
		}

		/// 
		/// Encapsulates the collection of indexes of checked items 
		/// (including items in an indeterminate state) in a 
		/// <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
		/// </summary>
		[Serializable]
		public class CheckedIndexCollection : IList, ICollection, IEnumerable
		{
			private CheckedListBox mobjCheckedListBox;

			private ArrayList InternalCheckedIndexes => mobjCheckedListBox.InternalCheckedIndexes;

			/// Gets the number of checked items.</summary>
			/// The number of indexes in the collection.</returns>
			public int Count => InternalCheckedIndexes.Count;

			/// Gets a value indicating whether the collection is read-only.</summary>
			/// true in all cases.</returns>
			public bool IsReadOnly => true;

			/// Gets the index of a checked item in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see> control.</summary>
			/// The index of the checked item. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
			/// <param name="index">An index into the checked indexes collection. This index specifies the index of the checked item you want to retrieve. </param>
			/// <exception cref="T:System.ArgumentException">The index is less than zero.-or- The index is not in the collection. </exception>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public int this[int index] => (int)InternalCheckedIndexes[index];

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => InternalCheckedIndexes.SyncRoot;

			bool IList.IsFixedSize => false;

			object IList.this[int index]
			{
				get
				{
					return InternalCheckedIndexes[index];
				}
				set
				{
				}
			}

			internal CheckedIndexCollection(CheckedListBox objCheckedListBox)
			{
				mobjCheckedListBox = objCheckedListBox;
			}

			/// Determines whether the specified index is located in the collection.</summary>
			/// true if the specified index from the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> is an item in this collection; otherwise, false.</returns>
			/// <param name="index">The index to locate in the collection. </param>
			public bool Contains(int index)
			{
				return InternalCheckedIndexes.Contains(index);
			}

			/// Copies the entire collection into an existing array at a specified location within the array.</summary>
			/// <param name="objDestinationArray">The destination array. </param>
			/// <param name="index">The zero-based relative index in dest at which copying begins. </param>
			/// <exception cref="T:System.ArgumentNullException">array is null. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
			/// <exception cref="T:System.RankException">array is multidimensional. </exception>
			/// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
			/// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
			public void CopyTo(Array objDestinationArray, int index)
			{
				InternalCheckedIndexes.CopyTo(objDestinationArray, index);
			}

			/// Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndices"></see> collection.</summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
			public IEnumerator GetEnumerator()
			{
				return InternalCheckedIndexes.GetEnumerator();
			}

			/// Returns an index into the collection of checked indexes.</summary>
			/// The index that specifies the index of the checked item or -1 if the index parameter is not in the checked indexes collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
			/// <param name="index">The index of the checked item. </param>
			public int IndexOf(int index)
			{
				return InternalCheckedIndexes.IndexOf(index);
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
		}

		/// 
		///
		/// </summary>
		[Serializable]
		public new class ObjectCollection : ListBox.ObjectCollection
		{
			private CheckedListBox mobjParent = null;

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection" /> instance.
			/// </summary>
			internal ObjectCollection(CheckedListBox objParent)
				: base(objParent)
			{
				mobjParent = objParent;
			}

			/// 
			/// Gets the checked.
			/// </summary>
			/// <param name="intIndex">Index of the int.</param>
			/// </returns>
			internal bool GetChecked(int intIndex)
			{
				return GetCheckedState(intIndex) != CheckState.Unchecked;
			}

			/// 
			/// Sets the checked.
			/// </summary>
			/// <param name="intIndex">Index of the int.</param>
			/// <param name="blnChecked">if set to true</c> [BLN checked].</param>
			/// </returns>
			internal void SetChecked(int intIndex, bool blnChecked)
			{
				SetCheckedState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);
			}

			/// 
			///
			/// </summary>
			/// <param name="objItem"></param>
			/// <param name="blnChecked"></param>
			public int Add(object objItem, bool blnChecked)
			{
				int num = Add(objItem);
				mobjParent.SetItemChecked(num, blnChecked);
				return num;
			}

			/// 
			///
			/// </summary>
			/// <param name="objItem"></param>
			/// <param name="enmCheck"></param>
			public int Add(object objItem, CheckState enmCheck)
			{
				int num = Add(objItem);
				mobjParent.SetItemChecked(num, enmCheck == CheckState.Checked);
				return num;
			}

			/// 
			/// Removes the specified object from the collection.
			/// </summary>
			/// <param name="objItem">An object representing the item to remove from the collection.</param>
			public override void Remove(object objItem)
			{
				ListBoxItem listBoxItemByItem = GetListBoxItemByItem(objItem);
				if (listBoxItemByItem != null && mobjParent != null && listBoxItemByItem.CheckState != CheckState.Unchecked)
				{
					mobjParent.InvalidateCheckedItemsChache();
				}
				base.Remove(objItem);
			}

			/// 
			/// Gets the checkstate of the item at specified index.
			/// </summary>
			/// <param name="intIndex">Index of the item.</param>
			/// checkstate</returns>
			internal CheckState GetCheckedState(int intIndex)
			{
				if (intIndex < 0 || intIndex >= base.Count)
				{
					throw new ArgumentException();
				}
				return mobjList[intIndex].CheckState;
			}

			/// 
			/// Sets the checkstate of the item at specified index.
			/// </summary>
			/// <param name="intIndex">Index of the item.</param>
			/// <param name="enmNewCheckState">CheckState.</param>
			internal void SetCheckedState(int intIndex, CheckState enmNewCheckState)
			{
				if (intIndex < 0 || intIndex >= base.Count)
				{
					throw new ArgumentException();
				}
				mobjList[intIndex].CheckState = enmNewCheckState;
			}
		}

		/// 
		///
		/// </summary>
		[NonSerialized]
		private ArrayList mobjCachedCheckedIndexes = null;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private ArrayList mobjCachedCheckedObjects = null;

		/// 
		/// The CheckOnClickProperty property registration.
		/// </summary>
		private static readonly SerializableProperty CheckOnClickProperty = SerializableProperty.Register("CheckOnClick", typeof(bool), typeof(CheckedListBox), new SerializablePropertyMetadata(false));

		/// 
		/// The ItemCheck event registration.
		/// </summary>
		private static readonly SerializableEvent ItemCheckEvent;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private CheckedIndexCollection mobjCheckedIndexCollection = null;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private CheckedItemCollection mobjCheckedItemCollection = null;

		/// 
		/// Gets the hanlder for the ItemCheck event.
		/// </summary>
		private ItemCheckHandler ItemCheckHandler => (ItemCheckHandler)GetHandler(ItemCheck);

		/// 
		/// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
		/// </summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
		[SRDescription("ListBoxItemsDescr")]
		[Localizable(true)]
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public new ObjectCollection Items => (ObjectCollection)base.Items;

		/// Collection of checked indexes in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// Collection of checked items in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// 
		/// Gets the internal checked indexes.
		/// </summary>
		/// The internal checked indexes.</value>
		private ArrayList InternalCheckedIndexes
		{
			get
			{
				EnsureCheckedItemsCache();
				return mobjCachedCheckedIndexes;
			}
		}

		/// 
		/// Gets the internal checked objects.
		/// </summary>
		/// The internal checked objects.</value>
		private ArrayList InternalCheckedObjects
		{
			get
			{
				EnsureCheckedItemsCache();
				return mobjCachedCheckedObjects;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [radio boxes].
		/// </summary>
		/// true</c> if [radio boxes]; otherwise, false</c>.</value>
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

		/// 
		/// Gets or sets a value indicating whether [check boxes].
		/// </summary>
		/// true</c> if [check boxes]; otherwise, false</c>.</value>
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

		/// Gets or sets a value indicating whether the check box should be toggled when an item is selected.</summary>
		/// true if the check mark is applied immediately; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRDescription("CheckedListBoxCheckOnClickDescr")]
		[SRCategory("CatBehavior")]
		public bool CheckOnClick
		{
			get
			{
				return GetValue(CheckOnClickProperty);
			}
			set
			{
				if (SetValue(CheckOnClickProperty, value))
				{
					UpdateParams(AttributeType.Control);
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
		/// Occurs when the checked state of an item changes.
		/// </summary>
		public event ItemCheckHandler ItemCheck
		{
			add
			{
				AddCriticalHandler(ItemCheckEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ItemCheckEvent, value);
			}
		}

		/// 
		/// Occurs when [client item check].
		/// </summary>
		[SRDescription("Occurs when control's item checked state changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientItemCheck
		{
			add
			{
				AddClientHandler("CheckedChange", value);
			}
			remove
			{
				RemoveClientHandler("CheckedChange", value);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox" /> instance.
		/// </summary>
		public CheckedListBox()
		{
			base.SelectionMode = SelectionMode.One;
			SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
		}

		/// 
		/// Renders the item attributes.
		/// </summary>
		/// <param name="objWriter">Writer.</param>
		/// <param name="objItem">Item.</param>
		/// <param name="intIndex">Item index.</param>
		protected internal override void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
		{
			RenderItemAttributes(objWriter, objItem, intIndex, blnShouldRenderItemImage: false, blnShouldRenderItemColor: false);
		}

		/// 
		/// </summary>
		/// <param name="objWriter"></param>
		/// <param name="objItem"></param>
		/// <param name="intIndex"></param>
		/// <param name="blnShouldRenderItemImage"></param>
		/// <param name="blnShouldRenderItemColor"></param>
		protected internal override void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor)
		{
			base.RenderItemAttributes(objWriter, objItem, intIndex, blnShouldRenderItemImage, blnShouldRenderItemColor);
			CheckState checkedState = Items.GetCheckedState(intIndex);
			if (checkedState != CheckState.Unchecked)
			{
				objWriter.WriteAttributeString("C", Convert.ToInt32(checkedState).ToString());
			}
		}

		/// 
		/// Renders the controls attributes
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderCheckOnClick(objContext, objWriter, blnUpdateParams: false);
		}

		/// 
		/// Renders the check on click.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnUpdateParams">if set to true</c> update params.</param>
		private void RenderCheckOnClick(IContext objContext, IAttributeWriter objWriter, bool blnUpdateParams)
		{
			if (CheckOnClick)
			{
				objWriter.WriteAttributeString("COC", "1");
			}
			else if (blnUpdateParams)
			{
				objWriter.WriteAttributeString("COC", "0");
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "CheckedChange")
			{
				CheckIndexes(objEvent["Indexes"]);
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
			if (ItemCheckHandler != null)
			{
				criticalEventsData.Set("VC");
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
			if (HasClientHandler("CheckedChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Checks the indexes.
		/// </summary>
		/// <param name="strIndexes">indexes.</param>
		private void CheckIndexes(string strIndexes)
		{
			bool flag = false;
			bool flag2 = false;
			List<object> list = new List<object><object>(strIndexes.Split(','));
			ObjectCollection items = Items;
			int count = items.Count;
			List<object> list2 = new List<object><object>(count);
			for (int i = 0; i < count; i++)
			{
				list2.Add(items.GetChecked(i));
			}
			for (int j = 0; j < count; j++)
			{
				if (list.Contains(j.ToString()))
				{
					if (!list2[j])
					{
						flag = true;
						ItemCheckEventArgs e = new ItemCheckEventArgs(j, CheckState.Checked, CheckState.Unchecked);
						OnItemCheck(e);
						if (e.NewValue == CheckState.Checked)
						{
							Items.SetChecked(j, blnChecked: true);
						}
						else
						{
							flag2 = true;
						}
					}
				}
				else if (list2[j])
				{
					flag = true;
					ItemCheckEventArgs e = new ItemCheckEventArgs(j, CheckState.Unchecked, CheckState.Checked);
					OnItemCheck(e);
					if (e.NewValue == CheckState.Unchecked)
					{
						Items.SetChecked(j, blnChecked: false);
					}
					else
					{
						flag2 = true;
					}
				}
			}
			if (flag)
			{
				InvalidateCheckedItemsChache();
			}
			if (flag2)
			{
				Update();
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.CheckedListBox.ItemCheck"></see> event.</summary>
		/// <param name="objItemCheckEventArgs">An <see cref="T:System.Windows.Forms.ItemCheckEventArgs"></see> that contains the event data.</param>
		protected virtual void OnItemCheck(ItemCheckEventArgs objItemCheckEventArgs)
		{
			ItemCheckHandler?.Invoke(this, objItemCheckEventArgs);
		}

		/// 
		/// Gets the item checked value.
		/// </summary>
		/// <param name="intIndex">Item index.</param>
		/// </returns>
		public bool GetItemChecked(int intIndex)
		{
			if (intIndex >= 0 && intIndex < Items.Count)
			{
				return Items.GetChecked(intIndex);
			}
			return false;
		}

		/// 
		/// Gets the checkstate of the item.
		/// </summary>
		/// <param name="intIndex">Index of the int.</param>
		/// </returns>
		public CheckState GetItemCheckState(int intIndex)
		{
			return Items.GetCheckedState(intIndex);
		}

		/// 
		/// Sets the item checked status.
		/// </summary>
		/// <param name="intIndex">Item index.</param>
		/// <param name="blnChecked">Is checked.</param>
		public void SetItemChecked(int intIndex, bool blnChecked)
		{
			SetItemCheckState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);
		}

		/// 
		/// Sets the item checkstate.
		/// </summary>
		/// <param name="intIndex">Index of the item.</param>
		/// <param name="enmNewCheckState">CheckState</param>
		public void SetItemCheckState(int intIndex, CheckState enmNewCheckState)
		{
			if (Items.Count <= 0)
			{
				return;
			}
			if (intIndex > Items.Count || intIndex < 0)
			{
				throw new ArgumentException();
			}
			CheckState checkedState = Items.GetCheckedState(intIndex);
			if (checkedState != enmNewCheckState)
			{
				ItemCheckEventArgs e = new ItemCheckEventArgs(intIndex, enmNewCheckState, checkedState);
				if (ItemCheckHandler != null)
				{
					ItemCheckHandler(this, e);
				}
				if (e.NewValue != checkedState)
				{
					Items.SetCheckedState(intIndex, e.NewValue);
					InvalidateCheckedItemsChache();
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		protected override ListBox.ObjectCollection CreateItemCollection()
		{
			return new ObjectCollection(this);
		}

		/// 
		/// Invalidates the checked items.
		/// </summary>
		private void EnsureCheckedItemsCache()
		{
			if (mobjCachedCheckedObjects != null && mobjCachedCheckedIndexes != null)
			{
				return;
			}
			mobjCachedCheckedObjects = new ArrayList();
			mobjCachedCheckedIndexes = new ArrayList();
			ObjectCollection items = Items;
			if (items == null)
			{
				return;
			}
			int count = items.Count;
			for (int i = 0; i < count; i++)
			{
				if (items.GetChecked(i))
				{
					mobjCachedCheckedObjects.Add(items[i]);
					mobjCachedCheckedIndexes.Add(i);
				}
			}
		}

		/// 
		/// Invalidates the checked items.
		/// </summary>
		private void InvalidateCheckedItemsChache()
		{
			mobjCachedCheckedObjects = null;
			mobjCachedCheckedIndexes = null;
		}

		/// 
		///
		/// </summary>
		protected override bool ShouldSerializeSelectionMode()
		{
			return base.SelectionMode != SelectionMode.One;
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderCheckOnClick(objContext, objWriter, blnUpdateParams: true);
			}
		}

		static CheckedListBox()
		{
			ItemCheck = SerializableEvent.Register("ItemCheck", typeof(ItemCheckHandler), typeof(CheckedListBox));
		}
	}
}
