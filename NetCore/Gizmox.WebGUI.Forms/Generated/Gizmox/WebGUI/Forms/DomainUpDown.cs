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
	/// Represents a Windows spin box (also known as an up-down control) that displays string values.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DomainUpDown), "DomainUpDown_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultProperty("Items")]
	[DefaultEvent("SelectedItemChanged")]
	[SRDescription("DescriptionDomainUpDown")]
	[MetadataTag("DUD")]
	[Skin(typeof(DomainUpDownSkin))]
	public class DomainUpDown : UpDownBase
	{
		/// Encapsulates a collection of objects for use by the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
		[Serializable]
		public class DomainUpDownItemCollection : ArrayList
		{
			private DomainUpDown mobjOwner;

			/// Gets or sets the item at the specified indexed location in the collection.</summary>
			/// An <see cref="T:System.Object"></see> that represents the item at the specified indexed location.</returns>
			/// <param name="index">The indexed location of the item in the collection. </param>
			[Browsable(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			public override object this[int index]
			{
				get
				{
					return base[index];
				}
				set
				{
					base[index] = value;
					if (mobjOwner.SelectedIndex == index)
					{
						mobjOwner.SelectIndex(index);
					}
					if (mobjOwner.Sorted)
					{
						mobjOwner.SortDomainItems();
					}
				}
			}

			internal DomainUpDownItemCollection(DomainUpDown objOwner)
			{
				mobjOwner = objOwner;
			}

			/// Adds the specified object to the end of the collection.</summary>
			/// The zero-based index value of the <see cref="T:System.Object"></see> added to the collection.</returns>
			/// <param name="objItem">The <see cref="T:System.Object"></see> to be added to the end of the collection. </param>
			public override int Add(object objItem)
			{
				int result = base.Add(objItem);
				if (mobjOwner.Sorted)
				{
					mobjOwner.SortDomainItems();
				}
				mobjOwner.Update();
				return result;
			}

			/// Inserts the specified object into the collection at the specified location.</summary>
			/// <param name="objItem">The <see cref="T:System.Object"></see> to insert. </param>
			/// <param name="index">The indexed location within the collection to insert the <see cref="T:System.Object"></see>. </param>
			public override void Insert(int index, object objItem)
			{
				base.Insert(index, objItem);
				if (mobjOwner.Sorted)
				{
					mobjOwner.SortDomainItems();
				}
				mobjOwner.Update();
			}

			/// Removes the specified item from the collection.</summary>
			/// <param name="objItem">The <see cref="T:System.Object"></see> to remove from the collection. </param>
			public override void Remove(object objItem)
			{
				int num = IndexOf(objItem);
				if (num == -1)
				{
					throw new ArgumentOutOfRangeException("item", SR.GetString("InvalidArgument", "item", objItem.ToString()));
				}
				RemoveAt(num);
				mobjOwner.Update();
			}

			/// Removes the item from the specified location in the collection.</summary>
			/// <param name="intItem">The indexed location of the <see cref="T:System.Object"></see> in the collection. </param>
			public override void RemoveAt(int intItem)
			{
				base.RemoveAt(intItem);
				if (intItem < mobjOwner.mintDomainIndex)
				{
					mobjOwner.SelectIndex(mobjOwner.mintDomainIndex - 1);
				}
				else if (intItem == mobjOwner.mintDomainIndex)
				{
					mobjOwner.SelectIndex(-1);
				}
				else
				{
					mobjOwner.Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		private sealed class DomainUpDownItemCompare : IComparer
		{
			public int Compare(object obj1, object obj2)
			{
				if (obj1 != obj2 && obj1 != null && obj2 != null)
				{
					return string.Compare(obj1.ToString(), obj2.ToString(), ignoreCase: false, CultureInfo.CurrentCulture);
				}
				return 0;
			}
		}

		/// 
		/// The SelectedItemChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedItemChangedEvent;

		/// 
		/// Provides a property reference to Wrap property.
		/// </summary>
		private static SerializableProperty WrapProperty;

		/// 
		/// The index of the domain.
		/// </summary>
		private int mintDomainIndex = -1;

		/// 
		/// A flag indicating if items we sorted
		/// </summary>
		private bool mblnItemsWhereSorted = false;

		/// 
		/// The domain up down items collection 
		/// </summary>
		private DomainUpDownItemCollection mobjItems = null;

		/// 
		/// The current editing value
		/// </summary>
		private string mstrStringValue = string.Empty;

		/// A collection of objects assigned to the spin box (also known as an up-down control).</summary>
		/// A <see cref="T:System.Windows.Forms.DomainUpDown.DomainUpDownItemCollection"></see> that contains an <see cref="T:System.Object"></see> collection.</returns>
		/// 1</filterpriority>
		[Localizable(true)]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[SRCategory("CatData")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("DomainUpDownItemsDescr")]
		public DomainUpDownItemCollection Items
		{
			get
			{
				if (mobjItems == null)
				{
					mobjItems = new DomainUpDownItemCollection(this);
				}
				return mobjItems;
			}
		}

		/// Gets or sets the spacing between the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control's contents and its edges.</summary>
		/// <see cref="F:System.Windows.Forms.Padding.Empty"></see> in all cases.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Padding Padding
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

		/// Gets or sets the index value of the selected item.</summary>
		/// The zero-based index value of the selected item. The default value is -1.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the default, -1.-or- The assigned value is greater than the <see cref="P:System.Windows.Forms.DomainUpDown.Items"></see> count. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(-1)]
		[SRDescription("DomainUpDownSelectedIndexDescr")]
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				if (base.UserEdit)
				{
					return -1;
				}
				return mintDomainIndex;
			}
			set
			{
				if (value != SelectedIndex)
				{
					SelectedIndexInternal = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// The currently selected index
		/// </summary>
		private int SelectedIndexInternal
		{
			set
			{
				if (value < -1 || value >= Items.Count)
				{
					throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidArgument", "SelectedIndex", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (value != SelectedIndex)
				{
					SelectIndex(value);
				}
			}
		}

		/// Gets or sets the selected item based on the index value of the selected item in the collection.</summary>
		/// The selected item based on the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedIndex"></see> value. The default value is null.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("DomainUpDownSelectedItemDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object SelectedItem
		{
			get
			{
				int selectedIndex = SelectedIndex;
				if (selectedIndex != -1)
				{
					return Items[selectedIndex];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					SelectedIndex = -1;
					return;
				}
				for (int i = 0; i < Items.Count; i++)
				{
					if (value != null && value.Equals(Items[i]))
					{
						SelectedIndex = i;
						break;
					}
				}
			}
		}

		/// 
		/// Gets the selected item changed handler.
		/// </summary>
		/// The selected item changed handler.</value>
		private EventHandler SelectedItemChangedHandler => (EventHandler)GetHandler(SelectedItemChanged);

		/// Gets or sets a value indicating whether the item collection is sorted.</summary>
		/// true if the item collection is sorted; otherwise, false. The default value is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("DomainUpDownSortedDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool Sorted
		{
			get
			{
				return GetState(ControlState.Sorted);
			}
			set
			{
				if (SetStateWithCheck(ControlState.Sorted, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the collection of items continues to the first or last item if the user continues past the end of the list.</summary>
		/// true if the list starts again when the user reaches the beginning or end of the collection; otherwise, false. The default value is false.</returns>
		/// 1</filterpriority>
		[SRDescription("DomainUpDownWrapDescr")]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[DefaultValue(false)]
		public bool Wrap
		{
			get
			{
				return GetValue(WrapProperty);
			}
			set
			{
				if (SetValue(WrapProperty, value))
				{
					Update();
				}
			}
		}

		/// Occurs when the value of the <see cref="P:System.Windows.Forms.DomainUpDown.Padding"></see> property changes.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler PaddingChanged
		{
			add
			{
				base.PaddingChanged += value;
			}
			remove
			{
				base.PaddingChanged -= value;
			}
		}

		/// Occurs when the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedItem"></see> property has been changed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("DomainUpDownOnSelectedItemChangedDescr")]
		public event EventHandler SelectedItemChanged
		{
			add
			{
				AddCriticalHandler(SelectedItemChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedItemChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("DomainUpDownOnSelectedItemChangedDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectedItemChanged
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

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
		public DomainUpDown()
		{
			Text = string.Empty;
		}

		/// Displays the next item in the object collection.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override void DownButton()
		{
			if (Items != null && Items.Count > 0)
			{
				int num = -1;
				if (base.UserEdit)
				{
					num = MatchIndex(Text, blnComplete: false, mintDomainIndex);
				}
				if (num != -1)
				{
					SelectIndex(num);
				}
				else if (mintDomainIndex < Items.Count - 1)
				{
					SelectIndex(mintDomainIndex + 1);
				}
				else if (Wrap)
				{
					SelectIndex(0);
				}
			}
		}

		/// Returns a string that represents the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control.</summary>
		/// A string that represents the current <see cref="T:System.Windows.Forms.DomainUpDown"></see>. </returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			string text = base.ToString();
			if (Items != null)
			{
				text = text + ", Items.Count: " + Items.Count.ToString(CultureInfo.CurrentCulture) + ", SelectedIndex: " + SelectedIndex.ToString(CultureInfo.CurrentCulture);
			}
			return text;
		}

		/// Displays the previous item in the collection.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override void UpButton()
		{
			if (Items != null && Items.Count > 0 && mintDomainIndex != -1)
			{
				int num = -1;
				if (base.UserEdit)
				{
					num = MatchIndex(Text, blnComplete: false, mintDomainIndex);
				}
				if (num != -1)
				{
					SelectIndex(num);
				}
				else if (mintDomainIndex > 0)
				{
					SelectIndex(mintDomainIndex - 1);
				}
				else if (Wrap)
				{
					SelectIndex(Items.Count - 1);
				}
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (SelectedItemChangedHandler != null)
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
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
		/// <param name="objSource">The source of the event.</param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnChanged(object objSource, EventArgs e)
		{
			OnSelectedItemChanged(objSource, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected void OnSelectedItemChanged(object objSource, EventArgs e)
		{
			SelectedItemChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event. </summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
		protected override void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e)
		{
			if (base.ReadOnly)
			{
				char[] array = new char[1] { e.KeyChar };
				switch (char.GetUnicodeCategory(array[0]))
				{
				case UnicodeCategory.UppercaseLetter:
				case UnicodeCategory.LowercaseLetter:
				case UnicodeCategory.OtherLetter:
				case UnicodeCategory.DecimalDigitNumber:
				case UnicodeCategory.LetterNumber:
				case UnicodeCategory.OtherNumber:
				case UnicodeCategory.MathSymbol:
				{
					int num = MatchIndex(new string(array), blnComplete: false, mintDomainIndex + 1);
					if (num != -1)
					{
						SelectIndex(num);
					}
					e.Handled = true;
					break;
				}
				}
			}
			base.OnTextBoxKeyPress(objSource, e);
		}

		/// 
		/// Renders the specified obj context.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			DomainUpDownItemCollection items = Items;
			objWriter.WriteStartElement("OS");
			for (int i = 0; i < items.Count; i++)
			{
				objWriter.WriteStartElement("O");
				RenderItemAttributes(objWriter, items[i], i);
				objWriter.WriteEndElement();
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (mintDomainIndex >= 0)
			{
				objWriter.WriteAttributeString("VLB", mintDomainIndex.ToString());
			}
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
		}

		/// 
		/// Renders the item attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objItem">The obj item.</param>
		/// <param name="intIndex">Index of the int.</param>
		protected internal virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
		{
			objWriter.WriteAttributeString("IX", intIndex.ToString());
			if (objItem != null)
			{
				objWriter.WriteAttributeText("TX", objItem.ToString(), (TextFilter)5);
			}
		}

		/// 
		/// Renders the updated attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				objWriter.WriteAttributeString("VLB", mintDomainIndex.ToString());
				objWriter.WriteAttributeText("TX", Text.ToString(), (TextFilter)5);
			}
		}

		/// 
		/// Sets up down value.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <param name="blnIsIndex">if set to true</c> [BLN is index].</param>
		protected override void SetUpDownValue(string strValue, bool blnIsIndex)
		{
			if (string.IsNullOrEmpty(strValue))
			{
				return;
			}
			if (blnIsIndex)
			{
				int num = Convert.ToInt32(strValue);
				if (num >= 0 && num < Items.Count)
				{
					SelectedIndexInternal = num;
				}
			}
			else
			{
				SetTextInternal(strValue);
			}
		}

		/// Updates the text in the spin box (also known as an up-down control) to display the selected item.</summary>
		protected override void UpdateEditText()
		{
			base.UserEdit = false;
			base.ChangingText = true;
			Text = mstrStringValue;
		}

		/// 
		/// Selects the index.
		/// </summary>
		/// <param name="index">The index.</param>
		private void SelectIndex(int index)
		{
			if (Items == null || index < -1 || index >= Items.Count)
			{
				index = -1;
				return;
			}
			mintDomainIndex = index;
			if (mintDomainIndex >= 0)
			{
				mstrStringValue = Items[mintDomainIndex].ToString();
				base.UserEdit = false;
				UpdateEditText();
			}
			else
			{
				base.UserEdit = true;
			}
		}

		/// 
		/// Sorts the domain items.
		/// </summary>
		private void SortDomainItems()
		{
			if (mblnItemsWhereSorted)
			{
				return;
			}
			mblnItemsWhereSorted = true;
			try
			{
				if (!Sorted || Items == null)
				{
					return;
				}
				ArrayList.Adapter(Items).Sort(new DomainUpDownItemCompare());
				if (!base.UserEdit)
				{
					int num = MatchIndex(mstrStringValue, blnComplete: true);
					if (num != -1)
					{
						SelectIndex(num);
					}
				}
			}
			finally
			{
				mblnItemsWhereSorted = false;
			}
		}

		/// 
		/// Matches the index.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="blnComplete">if set to true</c> [complete].</param>
		/// </returns>
		internal int MatchIndex(string strText, bool blnComplete)
		{
			return MatchIndex(strText, blnComplete, mintDomainIndex);
		}

		/// 
		/// Matches the index.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="blnComplete">if set to true</c> [complete].</param>
		/// <param name="intStartPosition">The start position.</param>
		/// </returns>
		internal int MatchIndex(string strText, bool blnComplete, int intStartPosition)
		{
			if (Items == null)
			{
				return -1;
			}
			if (strText.Length < 1)
			{
				return -1;
			}
			if (Items.Count <= 0)
			{
				return -1;
			}
			if (intStartPosition < 0)
			{
				intStartPosition = Items.Count - 1;
			}
			if (intStartPosition >= Items.Count)
			{
				intStartPosition = 0;
			}
			int num = intStartPosition;
			int result = -1;
			bool flag = false;
			if (!blnComplete)
			{
				strText = strText.ToUpper(CultureInfo.InvariantCulture);
			}
			do
			{
				flag = ((!blnComplete) ? Items[num].ToString().ToUpper(CultureInfo.InvariantCulture).StartsWith(strText) : Items[num].ToString().Equals(strText));
				if (flag)
				{
					result = num;
				}
				num++;
				if (num >= Items.Count)
				{
					num = 0;
				}
			}
			while (!flag && num != intStartPosition);
			return result;
		}

		static DomainUpDown()
		{
			SelectedItemChanged = SerializableEvent.Register("SelectedItemChanged", typeof(EventHandler), typeof(DomainUpDown));
			WrapProperty = SerializableProperty.Register("Wrap", typeof(bool), typeof(DomainUpDown), new SerializablePropertyMetadata(false));
		}
	}
}
