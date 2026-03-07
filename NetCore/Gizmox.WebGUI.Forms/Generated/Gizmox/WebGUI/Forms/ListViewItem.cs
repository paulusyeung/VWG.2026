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
	/// Implementation of ListViewItem class.
	/// </summary>
	[Serializable]
	[DesignTimeVisible(false)]
	[TypeConverter(typeof(ListViewItemConverter))]
	[ToolboxItem(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ListViewItem : Component
	{
		/// 
		/// Represents a subitem of a ListViewItem .
		/// </summary>
		[Serializable]
		[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
		[DesignTimeVisible(false)]
		[TypeConverter(typeof(ListViewSubItemConverter))]
		public class ListViewSubItem
		{
			[Serializable]
			internal class SubItemStyle
			{
				/// 
				/// The backcolor style of the sub item
				/// </summary>
				private Color mobjBackColor = Color.Empty;

				/// 
				/// The font of the sub item
				/// </summary>
				private SerializableFont mobjFont = null;

				/// 
				/// The forecolor style of the sub item
				/// </summary>
				private Color mobjForeColor = Color.Empty;

				/// 
				/// Gets or sets the color of the back.
				/// </summary>
				/// </value>
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

				/// 
				/// Gets or sets the font.
				/// </summary>
				/// </value>
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

				/// 
				/// Gets or sets the color of the fore.
				/// </summary>
				/// </value>
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

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem.SubItemStyle" /> class.
				/// </summary>
				public SubItemStyle()
				{
				}
			}

			/// 
			/// The subitem style
			/// </summary>
			private SubItemStyle mobjStyle = null;

			/// 
			/// The sub item listviewitem owner
			/// </summary>
			private ListViewItem mobjListViewItem = null;

			/// 
			/// Name property
			/// </summary>
			private string mstrName = string.Empty;

			/// 
			///
			/// </summary>
			private object mobjUserData = null;

			/// 
			/// Gets or sets the text internal.
			/// </summary>
			/// The text internal.</value>
			internal string mstrText = string.Empty;

			[Browsable(false)]
			public Rectangle Bounds
			{
				get
				{
					if (mobjListViewItem != null && mobjListViewItem.ListView != null)
					{
						return mobjListViewItem.ListView.GetSubItemRect(mobjListViewItem.Index, mobjListViewItem.SubItems.IndexOf(this));
					}
					return Rectangle.Empty;
				}
			}

			/// 
			/// Gets the default color of the back.
			/// </summary>
			/// The default color of the back.</value>
			private Color DefaultBackColor => ListViewItem?.DefaultBackColor ?? SystemColors.Window;

			/// 
			/// Gets the default color of the fore.
			/// </summary>
			/// The default color of the fore.</value>
			private Color DefaultForeColor => ListViewItem?.DefaultForeColor ?? Color.Black;

			/// 
			/// Gets or sets the color of the back.
			/// </summary>
			/// </value>
			public virtual Color BackColor
			{
				get
				{
					if (Style != null && Style.BackColor != Color.Empty)
					{
						return Style.BackColor;
					}
					if (ListViewItem != null && ListViewItem.ListView != null && (ListViewItem.ListView.HasBackColor || ListViewItem.ListView.HasProxyPropertyValue("BackColor")))
					{
						return ListViewItem.ListView.GetProxyPropertyValue("BackColor", ListViewItem.ListView.BackColor);
					}
					return DefaultBackColor;
				}
				set
				{
					if (Style == null)
					{
						Style = new SubItemStyle();
					}
					if (Style.BackColor != value)
					{
						Style.BackColor = value;
						if (ListViewItem != null)
						{
							ListViewItem.UpdateParams(AttributeType.Visual);
						}
					}
				}
			}

			/// 
			/// Gets or sets the font.
			/// </summary>
			/// </value>
			public virtual Font Font
			{
				get
				{
					if (Style != null && Style.Font != null)
					{
						return Style.Font;
					}
					if (ListViewItem != null && ListViewItem.ListView != null)
					{
						return ListViewItem.ListView.GetProxyPropertyValue("Font", ListViewItem.ListView.Font);
					}
					if (ListViewItem != null)
					{
						return ListViewItem.DefaultFont;
					}
					return Control.DefaultFont;
				}
				set
				{
					if (Style == null)
					{
						Style = new SubItemStyle();
					}
					if (Style.Font != value)
					{
						Style.Font = value;
						if (ListViewItem != null)
						{
							ListViewItem.UpdateParams(AttributeType.Visual);
						}
					}
				}
			}

			/// 
			/// Gets or sets the color of the fore.
			/// </summary>
			/// </value>
			public virtual Color ForeColor
			{
				get
				{
					if (Style != null && Style.ForeColor != Color.Empty)
					{
						return Style.ForeColor;
					}
					if (ListViewItem != null && ListViewItem.ListView != null && (ListViewItem.ListView.HasForeColor || ListViewItem.ListView.HasProxyPropertyValue("ForeColor")))
					{
						return ListViewItem.ListView.GetProxyPropertyValue("ForeColor", ListViewItem.ListView.ForeColor);
					}
					return DefaultForeColor;
				}
				set
				{
					if (Style == null)
					{
						Style = new SubItemStyle();
					}
					if (Style.ForeColor != value)
					{
						Style.ForeColor = value;
						if (ListViewItem != null)
						{
							ListViewItem.UpdateParams(AttributeType.Visual);
						}
					}
				}
			}

			/// 
			/// Gets or sets the name associated with this control.  
			/// </summary>
			/// </value>
			[Localizable(true)]
			public string Name
			{
				get
				{
					if (mstrName != null)
					{
						return mstrName;
					}
					return "";
				}
				set
				{
					mstrName = value;
				}
			}

			/// 
			/// Gets or sets the tag with this item.
			/// </summary>
			/// </value>
			[TypeConverter(typeof(StringConverter))]
			[SRCategory("CatData")]
			[Localizable(false)]
			[Bindable(true)]
			[DefaultValue(null)]
			[SRDescription("ControlTagDescr")]
			public object Tag
			{
				get
				{
					return mobjUserData;
				}
				set
				{
					mobjUserData = value;
				}
			}

			/// 
			/// Gets or sets the text.
			/// </summary>
			/// </value>
			public virtual string Text
			{
				get
				{
					return mstrText;
				}
				set
				{
					if (mstrText != value)
					{
						mstrText = value;
						if (ListViewItem != null)
						{
							ListViewItem.UpdateParams(AttributeType.Visual);
						}
					}
				}
			}

			/// 
			/// Gets or sets the list view.
			/// </summary>
			/// </value>
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

			/// 
			/// Gets or sets the Style.
			/// </summary>
			/// </value>
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

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
			/// </summary>
			public ListViewSubItem()
			{
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
			/// </summary>
			/// <param name="objListViewItem">The owner list view item.</param>
			protected ListViewSubItem(ListViewItem objListViewItem)
			{
				mobjListViewItem = objListViewItem;
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
			/// </summary>
			/// <param name="objListViewItem">The owner list view.</param>
			/// <param name="strText">The sub item text.</param>
			public ListViewSubItem(ListViewItem objListViewItem, string strText)
			{
				mobjListViewItem = objListViewItem;
				mstrText = strText;
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
			/// </summary>
			/// <param name="objListViewItem">The owner list view.</param>
			/// <param name="strText">The sub item text.</param>
			/// <param name="objForeColor">The sub item fore color.</param>
			/// <param name="objBackColor">The sub item back color.</param>
			/// <param name="objFont">The sub item font.</param>
			public ListViewSubItem(ListViewItem objListViewItem, string strText, Color objForeColor, Color objBackColor, Font objFont)
			{
				mobjListViewItem = objListViewItem;
				mstrText = strText;
				mobjStyle = new SubItemStyle
				{
					ForeColor = objForeColor,
					BackColor = objBackColor,
					Font = objFont
				};
			}

			/// 
			/// Renders the style.
			/// </summary>
			/// <param name="objWriter">The obj writer.</param>
			/// <param name="strAttribute">The STR attribute.</param>
			/// <param name="objBackColor">Color of the obj back.</param>
			/// <param name="objForeColor">Color of the obj fore.</param>
			/// <param name="objFont">The obj font.</param>
			internal void RenderStyle(IResponseWriter objWriter, string strAttribute, Color objBackColor, Color objForeColor, Font objFont)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (objBackColor != DefaultBackColor)
				{
					stringBuilder.AppendFormat("background-color:{0};", CommonUtils.GetHtmlColor(objBackColor));
				}
				if (objForeColor != DefaultForeColor)
				{
					stringBuilder.AppendFormat("color:{0};", CommonUtils.GetHtmlColor(objForeColor));
				}
				Font defaultFont = ListViewItem.DefaultFont;
				if (objFont != null && !objFont.Equals(defaultFont))
				{
					stringBuilder.AppendFormat("font:{0};", ClientUtils.GetWebFont(objFont));
				}
				if (stringBuilder.Length > 0)
				{
					objWriter.WriteAttributeString(strAttribute, stringBuilder.ToString());
				}
			}

			/// 
			/// Resets the Style.
			/// </summary>
			public void ResetStyle()
			{
				if (Style != null)
				{
					Style = null;
					if (ListViewItem != null)
					{
						ListViewItem.UpdateParams(AttributeType.Visual);
					}
				}
			}

			/// 
			/// Returns the sub item text value.
			/// </summary>
			/// </returns>
			public override string ToString()
			{
				return Text;
			}
		}

		/// 
		/// Represents a collection of ListViewSubItem objects stored in a ListViewItem .
		/// </summary>
		[Serializable]
		[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
		public class ListViewSubItemCollection : ICollection, IEnumerable, IList
		{
			/// 
			///
			/// </summary>
			private ListViewItem mobjListViewItem = null;

			/// 
			///
			/// </summary>
			private ArrayList mobjSubItems = null;

			/// 
			///
			/// </summary>
			public bool IsFixedSize => false;

			/// 
			/// Gets the count.
			/// </summary>
			/// </value>
			public int Count => mobjSubItems.Count;

			/// 
			/// Gets a value indicating whether this instance is read only.
			/// </summary>
			/// 
			/// 	true</c> if this instance is read only; otherwise, false</c>.
			/// </value>
			public bool IsReadOnly => false;

			/// 
			/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> at the specified index.
			/// </summary>
			/// </value>
			public ListViewSubItem this[int index]
			{
				get
				{
					if (mobjSubItems.Count <= index)
					{
						return new ListViewSubItem();
					}
					return (ListViewSubItem)mobjSubItems[index];
				}
				set
				{
					if (mobjSubItems == null)
					{
						mobjSubItems = new ArrayList();
					}
					OnSubItemRemoved(mobjSubItems[index] as ListViewSubItem);
					mobjSubItems[index] = value;
					OnSubItemAdded(value);
				}
			}

			/// 
			/// Gets a value indicating whether this instance is synchronized.
			/// </summary>
			/// 
			/// 	true</c> if this instance is synchronized; otherwise, false</c>.
			/// </value>
			public bool IsSynchronized => mobjSubItems.IsSynchronized;

			/// 
			/// Gets the sync root.
			/// </summary>
			/// </value>
			public object SyncRoot => mobjSubItems.SyncRoot;

			/// 
			///
			/// </summary>
			object IList.this[int index]
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

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection" /> instance.
			/// </summary>
			/// <param name="objListViewItem">Owner list view item.</param>
			public ListViewSubItemCollection(ListViewItem objListViewItem)
			{
				mobjListViewItem = objListViewItem;
				mobjSubItems = new ArrayList();
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection" /> instance.
			/// </summary>
			/// <param name="objListViewItem">Owner list view item.</param>
			/// <param name="arrSubItems">The arr sub items.</param>
			internal ListViewSubItemCollection(ListViewItem objListViewItem, object[] arrSubItems)
			{
				mobjListViewItem = objListViewItem;
				mobjSubItems = new ArrayList(arrSubItems);
			}

			/// 
			/// Adds the specified sub item.
			/// </summary>
			/// <param name="objSubItem">Sub item.</param>
			/// </returns>
			public ListViewSubItem Add(ListViewSubItem objSubItem)
			{
				objSubItem.ListViewItem = mobjListViewItem;
				mobjSubItems.Add(objSubItem);
				OnSubItemAdded(objSubItem);
				return objSubItem;
			}

			/// 
			/// Handle sub item added
			/// </summary>
			/// <param name="objSubItem"></param>
			private void OnSubItemAdded(ListViewSubItem objSubItem)
			{
				if (!(objSubItem is ListViewSubControlItem listViewSubControlItem))
				{
					return;
				}
				ListView listView = mobjListViewItem.ListView;
				if (listView != null)
				{
					Control control = listViewSubControlItem.Control;
					if (control != null)
					{
						listView.Controls.Add(control);
					}
				}
			}

			/// 
			/// Handle sub item removed
			/// </summary>
			/// <param name="objSubItem"></param>
			private void OnSubItemRemoved(ListViewSubItem objSubItem)
			{
				if (!(objSubItem is ListViewSubControlItem listViewSubControlItem))
				{
					return;
				}
				ListView listView = mobjListViewItem.ListView;
				if (listView != null)
				{
					Control control = listViewSubControlItem.Control;
					if (control != null)
					{
						listView.Controls.Remove(control);
					}
				}
			}

			/// 
			/// Adds a new sub item.
			/// </summary>
			/// <param name="strText">STR text.</param>
			/// </returns>
			public ListViewSubItem Add(string strText)
			{
				ListViewSubItem listViewSubItem = new ListViewSubItem(mobjListViewItem, strText);
				mobjSubItems.Add(listViewSubItem);
				return listViewSubItem;
			}

			/// 
			/// Adds the specified obj control.
			/// </summary>
			/// <param name="objControl">The obj control.</param>
			/// </returns>
			public ListViewSubControlItem Add(Control objControl)
			{
				ListViewSubControlItem listViewSubControlItem = new ListViewSubControlItem(mobjListViewItem, objControl);
				mobjSubItems.Add(listViewSubControlItem);
				OnSubItemAdded(listViewSubControlItem);
				return listViewSubControlItem;
			}

			/// 
			/// Adds the a sub item with styles.
			/// </summary>
			/// <param name="strText">The sub item text.</param>
			/// <param name="objForeColor">The sub item fore color.</param>
			/// <param name="objBackColor">The sub item back color.</param>
			/// <param name="objFont">The sub item font.</param>
			/// </returns>
			public ListViewSubItem Add(string strText, Color objForeColor, Color objBackColor, Font objFont)
			{
				ListViewSubItem listViewSubItem = new ListViewSubItem(mobjListViewItem, strText, objForeColor, objBackColor, objFont);
				mobjSubItems.Add(listViewSubItem);
				return listViewSubItem;
			}

			/// 
			/// Adds a range of sub items.
			/// </summary>
			/// <param name="arrItems">Sub items array.</param>
			public void AddRange(ListViewSubItem[] arrItems)
			{
				foreach (ListViewSubItem objSubItem in arrItems)
				{
					Add(objSubItem);
				}
			}

			/// 
			/// Adds a range of items.
			/// </summary>
			/// <param name="arrItems">Range of items.</param>
			public void AddRange(string[] arrItems)
			{
				foreach (string strText in arrItems)
				{
					Add(strText);
				}
			}

			/// 
			/// Adds a range of sub items with styles.
			/// </summary>
			/// <param name="arrItems">The sub items text array.</param>
			/// <param name="objForeColor">The sub item fore color.</param>
			/// <param name="objBackColor">The sub item back color.</param>
			/// <param name="objFont">The sub item font.</param>
			public void AddRange(string[] arrItems, Color objForeColor, Color objBackColor, Font objFont)
			{
				foreach (string strText in arrItems)
				{
					Add(strText, objForeColor, objBackColor, objFont);
				}
			}

			/// 
			/// Clears the sub items.
			/// </summary>
			public void Clear()
			{
				mobjSubItems.Clear();
			}

			/// 
			/// Checks if a sub item is contained.
			/// </summary>
			/// <param name="objSubItem">A sub item.</param>
			/// </returns>
			public bool Contains(ListViewSubItem objSubItem)
			{
				return mobjSubItems.Contains(objSubItem);
			}

			/// 
			/// Ensures the sub item space (Not implemented).
			/// </summary>
			/// <param name="intSize">Size.</param>
			/// <param name="intIndex">Index.</param>
			private void EnsureSubItemSpace(int intSize, int intIndex)
			{
			}

			/// 
			/// Gets an enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return mobjSubItems.GetEnumerator();
			}

			/// 
			/// returns the indexes of a given sub item.
			/// </summary>
			/// <param name="objSubItem">A sub item.</param>
			/// </returns>
			public int IndexOf(ListViewSubItem objSubItem)
			{
				return mobjSubItems.IndexOf(objSubItem);
			}

			/// 
			/// Inserts a sub item at a specified index.
			/// </summary>
			/// <param name="intIndex">Index.</param>
			/// <param name="objSubItem">The sub item.</param>
			public void Insert(int intIndex, ListViewSubItem objSubItem)
			{
				mobjSubItems.Insert(intIndex, objSubItem);
			}

			/// 
			/// Removes the specified sub item.
			/// </summary>
			/// <param name="objSubItem">Obj sub item.</param>
			public void Remove(ListViewSubItem objSubItem)
			{
				mobjSubItems.Remove(objSubItem);
				OnSubItemRemoved(objSubItem);
			}

			/// 
			/// Removes a sub item at a specified index.
			/// </summary>
			/// <param name="intIndex">Index.</param>
			public void RemoveAt(int intIndex)
			{
				if (mobjSubItems[intIndex] is ListViewSubItem objSubItem)
				{
					Remove(objSubItem);
				}
			}

			/// 
			/// Copies to an array.
			/// </summary>
			/// <param name="objArrayDest">Arr dest.</param>
			/// <param name="intIndex">Int index.</param>
			public void CopyTo(Array objArrayDest, int intIndex)
			{
				mobjSubItems.CopyTo(objArrayDest, intIndex);
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			/// <param name="objValue"></param>
			void IList.Insert(int index, object objValue)
			{
				mobjSubItems.Insert(index, objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			void IList.Remove(object objValue)
			{
				mobjSubItems.Remove(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			bool IList.Contains(object objValue)
			{
				return mobjSubItems.Contains(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.IndexOf(object objValue)
			{
				return mobjSubItems.IndexOf(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.Add(object objValue)
			{
				return mobjSubItems.Add(objValue);
			}
		}

		[Serializable]
		public class ListViewSubControlItem : ListViewSubItem
		{
			/// 
			/// The hosted control
			/// </summary>
			private Control mobjControl = null;

			/// 
			/// Gets or sets the control.
			/// </summary>
			/// The control.</value>
			public Control Control => mobjControl;

			/// 
			/// Gets or sets the text.
			/// </summary>
			/// </value>
			public override string Text
			{
				get
				{
					return Control.Text;
				}
				set
				{
					Control.Text = value;
				}
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubControlItem" /> instance.
			/// </summary>
			public ListViewSubControlItem(Control objControl)
			{
				if (objControl == null)
				{
					throw new ArgumentNullException("objControl");
				}
				SetSubItemControl(objControl);
			}

			public ListViewSubControlItem(ListViewItem objListViewItem, Control objControl)
				: base(objListViewItem)
			{
				if (objControl == null)
				{
					throw new ArgumentNullException("objControl");
				}
				SetSubItemControl(objControl);
			}

			/// 
			/// Sets the sub item control.
			/// </summary>
			/// <param name="objControl">The sub item control.</param>
			private void SetSubItemControl(Control objControl)
			{
				mobjControl = objControl;
				mobjControl.Dock = DockStyle.Fill;
				mobjControl.TabIndex = 1;
			}
		}

		/// 
		/// Provides a property reference to LargeImage property.
		/// </summary>
		private static readonly SerializableProperty LargeImageProperty = SerializableProperty.Register("LargeImage", typeof(ResourceHandle), typeof(ListViewItem));

		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static readonly SerializableProperty SmallImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ListViewItem));

		/// 
		/// The mintImageIndex property registration.
		/// </summary>
		private static readonly SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(-1));

		/// 
		/// The DataItemIndex property registration.
		/// </summary>
		private static readonly SerializableProperty DataItemIndexProperty = SerializableProperty.Register("DataItemIndex", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(-1));

		private static readonly SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(ListViewItem), new SerializablePropertyMetadata(string.Empty));

		private static readonly SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ListViewItem), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// The mintIndentCount property registration.
		/// </summary> 
		private static readonly SerializableProperty IndentCountProperty = SerializableProperty.Register("IndentCount", typeof(int), typeof(ListViewItem), new SerializablePropertyMetadata(0));

		/// 
		/// The group property registration.
		/// </summary>
		private static readonly SerializableProperty GroupProperty = SerializableProperty.Register("Group", typeof(ListViewGroup), typeof(ListViewItem), new SerializablePropertyMetadata(null));

		/// 
		/// The collection of subitems
		/// </summary>
		[NonSerialized]
		private ListViewSubItemCollection mobjSubItems = null;

		/// 
		/// Use item
		/// </summary>
		[NonSerialized]
		private bool mblnUseItemStyleForSubItems = true;

		/// 
		/// The AfterLabelEdit event registration.
		/// </summary>
		private static readonly SerializableEvent AfterLabelEditEvent;

		/// 
		/// The amount of fields we are serializing
		/// </summary>
		private const int mcntSerializableFieldCount = 1;

		/// 
		/// Gets the hanlder for the AfterLabelEdit event.
		/// </summary>
		private LabelEditEventHandler AfterLabelEditHandler => (LabelEditEventHandler)GetHandler(AfterLabelEdit);

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
				int num = base.SerializableDataInitialSize + 1;
				return num + SerializationWriter.GetRequiredCapacity(mobjSubItems);
			}
		}

		/// 
		/// Gets or sets the name associated with this control.  
		/// </summary>
		/// </value>
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string Name
		{
			get
			{
				if (SubItems.Count == 0)
				{
					return string.Empty;
				}
				return SubItems[0].Name;
			}
			set
			{
				SubItems[0].Name = value;
			}
		}

		/// Gets or sets the group to which the item is assigned.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
		[Localizable(true)]
		[DefaultValue(null)]
		[SRCategory("CatBehavior")]
		public ListViewGroup Group
		{
			get
			{
				return GetValue(GroupProperty);
			}
			set
			{
				ListViewGroup listViewGroup = Group;
				if (listViewGroup != value)
				{
					if (value != null)
					{
						value.Items.Add(this);
					}
					else
					{
						listViewGroup?.Items.Remove(this);
					}
					if (ListView != null)
					{
						ListView.Update();
					}
				}
			}
		}

		/// Gets or sets the small image that is displayed for the item.</summary>
		/// The small image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		/// This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
		public ResourceHandle SmallImage
		{
			get
			{
				return GetImage(SmallImageProperty, SmallImageList, ImageIndex, ImageKey, -1, string.Empty);
			}
			set
			{
				SetImage(SmallImageProperty, value, ImageList);
			}
		}

		/// 
		/// Backwards compatibility Image property (use SmallImage instead)
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		[Obsolete("Please use the 'SmallImage' property instead.")]
		public ResourceHandle Image
		{
			get
			{
				return SmallImage;
			}
			set
			{
				SmallImage = value;
			}
		}

		/// Gets the zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
		/// The zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control, or -1 if the item is not associated with a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
		[Browsable(false)]
		public int Index
		{
			get
			{
				if (ListView == null)
				{
					return -1;
				}
				return ListView.GetDisplayIndex(this);
			}
		}

		/// Gets or sets the number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
		/// The number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[DefaultValue(0)]
		[SRDescription("ListViewItemIndentCountDescr")]
		[SRCategory("CatDisplay")]
		public int IndentCount
		{
			get
			{
				return GetValue(IndentCountProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("IndentCount", SR.GetString("ListViewIndentCountCantBeNegative"));
				}
				if (SetValue(IndentCountProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Provides a way to define a large image for this list view item.
		/// </summary>
		/// This property will throw an error if the owning list view has a large imagelist set to it.</remarks>
		public ResourceHandle LargeImage
		{
			get
			{
				return GetImage(LargeImageProperty, LargeImageList, ImageIndex, ImageKey, -1, string.Empty);
			}
			set
			{
				SetImage(LargeImageProperty, value, ImageList);
			}
		}

		/// Gets or sets the text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
		/// The text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		[SRCategory("CatAppearance")]
		public string ToolTipText
		{
			get
			{
				return GetValue(ToolTipTextProperty);
			}
			set
			{
				SetValue(ToolTipTextProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> is selected.
		/// </summary>
		/// 
		/// 	true</c> if selected; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Selected
		{
			get
			{
				return GetState(ComponentState.Selected);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Selected, value))
				{
					Update();
					if (ListView != null)
					{
						ListView.FireSelectedIndexChanged(this);
					}
				}
			}
		}

		/// 
		///
		/// </summary>
		internal bool InternalSelected
		{
			get
			{
				return GetState(ComponentState.Selected);
			}
			set
			{
				SetState(ComponentState.Selected, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> is checked.
		/// </summary>
		/// 
		/// 	true</c> if checked; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return GetState(ComponentState.Checked);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Checked, value))
				{
					if (ListView != null)
					{
						ListView.FireItemCheck(this, value);
					}
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		internal bool InternalChecked
		{
			get
			{
				return GetState(ComponentState.Checked);
			}
			set
			{
				SetState(ComponentState.Checked, value);
			}
		}

		/// 
		/// Gets or sets the font.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		public Font Font
		{
			get
			{
				if (SubItems != null && HasSubItems && SubItems[0].Font != null)
				{
					return SubItems[0].Font;
				}
				if (ListView != null)
				{
					return ListView.Font;
				}
				return DefaultFont;
			}
			set
			{
				SubItems[0].Font = value;
			}
		}

		/// Gets or sets the background color of the item's text.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item's text.</returns>
		[SRCategory("CatAppearance")]
		public Color BackColor
		{
			get
			{
				if (HasSubItems)
				{
					return SubItems[0].BackColor;
				}
				if (ListView != null)
				{
					return ListView.BackColor;
				}
				return DefaultBackColor;
			}
			set
			{
				SubItems[0].BackColor = value;
			}
		}

		/// 
		/// Gets the bounds.
		/// </summary>
		/// 
		/// The bounds.
		/// </value>
		[Browsable(false)]
		public Rectangle Bounds
		{
			get
			{
				if (ListView != null)
				{
					return ListView.GetItemRect(Index);
				}
				return default(Rectangle);
			}
		}

		/// 
		/// Gets the default color of the back.
		/// </summary>
		/// The default color of the back.</value>
		private Color DefaultBackColor => ListView?.DefaultRowBackColor ?? SystemColors.Window;

		/// 
		/// Gets the default color of the fore.
		/// </summary>
		/// The default color of the fore.</value>
		private Color DefaultForeColor => ListView?.DefaultRowForeColor ?? Color.Black;

		/// 
		/// Gets the default font.
		/// </summary>
		/// The default font.</value>
		private Font DefaultFont => ListView?.DefaultRowFont;

		/// Gets or sets the foreground color of the item's text.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of the item's text.</returns>
		[SRCategory("CatAppearance")]
		public Color ForeColor
		{
			get
			{
				if (HasSubItems)
				{
					return SubItems[0].ForeColor;
				}
				if (ListView != null)
				{
					return ListView.ForeColor;
				}
				return DefaultForeColor;
			}
			set
			{
				SubItems[0].ForeColor = value;
			}
		}

		/// Gets or sets the index of the image that is displayed for the item.</summary>
		/// The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("ListViewItemImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int ImageIndex
		{
			get
			{
				return GetValue(ImageIndexProperty);
			}
			set
			{
				if (SetValue(ImageIndexProperty, value))
				{
					RemoveValue(ImageKeyProperty);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the index of the data item.
		/// </summary>
		/// The index of the data item.</value>
		[DefaultValue(-1)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ListViewItemDataItemIndexDescr")]
		[SRCategory("CatData")]
		public int DataItemIndex
		{
			get
			{
				return GetValue(DataItemIndexProperty);
			}
			internal set
			{
				SetValue(DataItemIndexProperty, value);
			}
		}

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		public string ImageKey
		{
			get
			{
				return GetValue(ImageKeyProperty);
			}
			set
			{
				if (SetValue(ImageKeyProperty, value))
				{
					RemoveValue(ImageIndexProperty);
					Update();
				}
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the image displayed with the item.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used by the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains the image displayed with the item.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public ImageList ImageList
		{
			get
			{
				if (ListView != null)
				{
					switch (ListView.View)
					{
					case View.LargeIcon:
						return ListView.LargeImageList;
					case View.Details:
					case View.List:
					case View.SmallIcon:
						return ListView.SmallImageList;
					}
				}
				return null;
			}
		}

		/// 
		/// Gets the large image list.
		/// </summary>
		/// The large image list.</value>
		private ImageList LargeImageList
		{
			get
			{
				if (ListView != null)
				{
					return ListView.LargeImageList;
				}
				return null;
			}
		}

		/// 
		/// Gets the small image list.
		/// </summary>
		/// The small image list.</value>
		private ImageList SmallImageList
		{
			get
			{
				if (ListView != null)
				{
					return ListView.SmallImageList;
				}
				return null;
			}
		}

		/// 
		/// Gets the list view.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public ListView ListView => InternalParent as ListView;

		/// 
		/// Gets or sets the internal list view.
		/// </summary>
		/// </value>
		internal ListView InternalListView
		{
			get
			{
				return InternalParent as ListView;
			}
			set
			{
				InternalParent = value;
			}
		}

		/// 
		/// Gets the sub items.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ListViewItemSubItemsDescr")]
		[SRCategory("CatData")]
		public ListViewSubItemCollection SubItems
		{
			get
			{
				if (mobjSubItems == null)
				{
					mobjSubItems = new ListViewSubItemCollection(this);
				}
				return mobjSubItems;
			}
		}

		/// 
		/// Gets a value indicating whether this listviewitem has sub items.
		/// </summary>
		/// 
		/// 	true</c> if this listviewitem has sub items; otherwise, false</c>.
		/// </value>
		private bool HasSubItems
		{
			get
			{
				if (mobjSubItems != null)
				{
					return mobjSubItems.Count > 0;
				}
				return false;
			}
		}

		/// 
		/// Gets or sets the list view item text.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string Text
		{
			get
			{
				return TextInternal;
			}
			set
			{
				if (HasSubItems)
				{
					if (TextInternal != value)
					{
						TextInternal = value;
						UpdateParams(AttributeType.Control);
					}
				}
				else
				{
					TextInternal = value;
					if (value != string.Empty)
					{
						UpdateParams(AttributeType.Control);
					}
				}
			}
		}

		/// 
		/// Gets or sets the text internal.
		/// </summary>
		/// The text internal.</value>
		internal string TextInternal
		{
			get
			{
				if (HasSubItems)
				{
					return SubItems[0].Text;
				}
				return string.Empty;
			}
			set
			{
				if (HasSubItems)
				{
					SubItems[0].Text = value;
				}
				else
				{
					SubItems.Add(value);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Font"></see>, <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.ForeColor"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.BackColor"></see> properties for the item are used for all its subitems.</summary>
		/// true if all subitems use the font, foreground color, and background color settings of the item; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public bool UseItemStyleForSubItems
		{
			get
			{
				return mblnUseItemStyleForSubItems;
			}
			set
			{
				if (mblnUseItemStyleForSubItems != value)
				{
					mblnUseItemStyleForSubItems = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets item relative position.
		/// </summary>
		/// 
		/// The position.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Point Position
		{
			get
			{
				ListView listView = ListView;
				if (listView != null && listView.IsHandleCreated)
				{
					int intX = 0;
					int intY = 0;
					listView.GetRelativeXYFromItem(this, ref intX, ref intY);
					return new Point(intX, intY);
				}
				return Point.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Occurs when [client after label edit].
		/// </summary>
		[SRDescription("Occurs when control's label edited in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterLabelEdit
		{
			add
			{
				AddClientHandler("AfterLabelEdit", value);
			}
			remove
			{
				RemoveClientHandler("AfterLabelEdit", value);
			}
		}

		/// Occurs after the list item label text is edited.</summary>
		[Browsable(false)]
		[SRDescription("ListViewItemAfterEditDescr")]
		protected event LabelEditEventHandler AfterLabelEdit
		{
			add
			{
				AddHandler(AfterLabelEditEvent, value);
			}
			remove
			{
				RemoveHandler(AfterLabelEditEvent, value);
			}
		}

		/// 
		///
		/// </summary>
		public ListViewItem()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
		/// </summary>
		/// <param name="strText">The text of the first sub item.</param>
		public ListViewItem(string strText)
		{
			SubItems.Add(strText);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
		/// </summary>
		/// <param name="arrItems">The sub items.</param>
		public ListViewItem(string[] arrItems)
		{
			if (arrItems.Length != 0)
			{
				SubItems.AddRange(arrItems);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// <param name="intImageIndex">Index of the int image.</param>
		public ListViewItem(string strText, int intImageIndex)
			: this(strText)
		{
			ImageIndex = intImageIndex;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// <param name="strImageKey">The STR image key.</param>
		public ListViewItem(string strText, string strImageKey)
			: this(strText)
		{
			ImageKey = strImageKey;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
		/// </summary>
		/// <param name="arrItems">The sub items.</param>
		/// <param name="intImageIndex">The index of the image in the image list.</param>
		public ListViewItem(string[] arrItems, int intImageIndex)
		{
			SubItems.AddRange(arrItems);
			ImageIndex = intImageIndex;
		}

		/// 
		///
		/// </summary>
		/// <param name="arrSubItems"></param>
		/// <param name="intImageIndex"></param>
		public ListViewItem(ListViewSubItem[] arrSubItems, int intImageIndex)
		{
			if (arrSubItems.Length != 0)
			{
				SubItems.AddRange(arrSubItems);
				Text = arrSubItems[0].Text;
				ImageIndex = intImageIndex;
			}
		}

		/// 
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
			ImageIndex = intImageIndex;
			ForeColor = objForeColor;
			BackColor = objBackColor;
			Font = objFont;
		}

		/// 
		/// Called when [swipe].
		/// </summary>
		/// <param name="enmSwipeDirection">The swipe direction.</param>
		protected override void OnSwipe(SwipeDirection enmSwipeDirection)
		{
			base.OnSwipe(enmSwipeDirection);
			ListView?.OnItemSwipe(this, enmSwipeDirection);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mblnUseItemStyleForSubItems = objReader.ReadBoolean();
			object[] array = objReader.ReadArray();
			if (array.Length != 0)
			{
				mobjSubItems = new ListViewSubItemCollection(this, array);
			}
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteBoolean(mblnUseItemStyleForSubItems);
			objWriter.WriteArray(mobjSubItems);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			ListView listView = ListView;
			if (listView != null)
			{
				CriticalEventsData criticalEventsDataInternal = listView.GetCriticalEventsDataInternal();
				if (criticalEventsDataInternal.HasEvent("CL"))
				{
					criticalEventsData.Set("CL");
				}
				if (criticalEventsDataInternal.HasEvent("DCL"))
				{
					criticalEventsData.Set("DCL");
				}
				if (criticalEventsDataInternal.HasEvent("CL") || ContextMenu != null || (listView != null && listView.ContextMenu != null))
				{
					criticalEventsData.Set("RC");
				}
				if (criticalEventsDataInternal.HasEvent("SWP"))
				{
					criticalEventsData.Set("SWP");
				}
				if (criticalEventsDataInternal.HasEvent("ALE"))
				{
					criticalEventsData.Set("ALE");
				}
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
			if (HasClientHandler("AfterLabelEdit"))
			{
				criticalClientEventsData.Set("ALE");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			switch (objEvent.Type)
			{
			case "KeyDown":
				if (ListView != null)
				{
					ListView.FireKeyDown(objEvent);
				}
				break;
			case "DoubleClick":
				if (ListView != null)
				{
					ListView.OnItemClick(this, CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
					ListView.OnItemDoubleClick(this, CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				}
				break;
			case "Click":
				if (ListView != null)
				{
					MouseEventArgs objMouseEventArgs = CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
					ListView.OnItemClick(this, objMouseEventArgs);
				}
				break;
			case "RightClick":
				if (ListView != null)
				{
					MouseEventArgs objMouseEventArgs2 = CreateMouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Right), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
					ListView.OnItemClick(this, objMouseEventArgs2);
				}
				break;
			case "AfterLabelEdit":
			{
				string text = CommonUtils.DecodeText(objEvent["Text"]);
				LabelEditEventArgs e = new LabelEditEventArgs(Index, text);
				OnAfterLabelEdit(e);
				if (!e.CancelEdit)
				{
					TextInternal = text;
				}
				else
				{
					UpdateParams(AttributeType.Control);
				}
				break;
			}
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Creates a mouse event arguments object.
		/// </summary>
		/// <param name="enmMouseButtons">The mouse buttons.</param>
		/// <param name="intClicks">The int clicks.</param>
		/// <param name="intX">The int X.</param>
		/// <param name="intY">The int Y.</param>
		/// <param name="intDelta">The int delta.</param>
		/// </returns>
		private MouseEventArgs CreateMouseEventArgs(MouseButtons enmMouseButtons, int intClicks, int intX, int intY, int intDelta)
		{
			ListView?.GetRelativeXYFromItem(this, ref intX, ref intY);
			return new MouseEventArgs(enmMouseButtons, intClicks, intX, intY, intDelta);
		}

		/// 
		/// Renders the node.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">Request ID.</param>
		internal virtual void RenderItem(IContext objContext, IResponseWriter objWriter, long lngRequestID, ListView.ItemRenderingProcessor objProcessor)
		{
			if (IsDirty(lngRequestID))
			{
				RenderDirtyItem(objContext, objWriter, objProcessor, 0L);
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);
			}
			else
			{
				RenderNonDirtyItem(objContext, objWriter, lngRequestID, objProcessor);
			}
		}

		/// 
		/// Renders the dirty item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objProcessor">The processor.</param>
		internal virtual void RenderDirtyItem(IContext objContext, IResponseWriter objWriter, ListView.ItemRenderingProcessor objProcessor, long lngRequestID)
		{
			List<object> list = null;
			bool useItemStyleForSubItems = UseItemStyleForSubItems;
			if (lngRequestID == 0L || objProcessor.View == View.Details)
			{
				objWriter.WriteStartElement("R");
			}
			else
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
			}
			objWriter.WriteAttributeString("Id", GetProxyPropertyValue("ID", ID).ToString());
			RenderIsDirtyAttributes(objContext, (IAttributeWriter)objWriter);
			RenderUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
			RenderComponentEventAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID != 0);
			RenderDragAndDropAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID != 0);
			RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);
			RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter)objWriter);
			RenderItemImage(objWriter, objProcessor.View);
			if (Selected)
			{
				objWriter.WriteAttributeString("SE", "1");
			}
			if (Checked)
			{
				objWriter.WriteAttributeString("C", "1");
			}
			if (useItemStyleForSubItems)
			{
				objWriter.WriteAttributeString("UIS", "1");
			}
			if (objProcessor.ShowItemToolTips)
			{
				string toolTipText = ToolTipText;
				if (!string.IsNullOrEmpty(toolTipText))
				{
					objWriter.WriteAttributeText("TT", toolTipText);
				}
			}
			if (objProcessor.View == View.Details)
			{
				if (mobjSubItems != null)
				{
					foreach (ColumnHeader sortedColumn in objProcessor.SortedColumns)
					{
						if (!sortedColumn.IsValidColumn)
						{
							continue;
						}
						objWriter.WriteStartElement("SI");
						objWriter.WriteAttributeString("COL", sortedColumn.Index.ToString());
						if (mobjSubItems.Count > sortedColumn.Index)
						{
							ListViewSubItem listViewSubItem = mobjSubItems[sortedColumn.Index];
							if (!useItemStyleForSubItems || sortedColumn.Index == 0)
							{
								listViewSubItem.RenderStyle(objWriter, "s", listViewSubItem.BackColor, listViewSubItem.ForeColor, listViewSubItem.Font);
							}
							if (listViewSubItem is ListViewSubControlItem listViewSubControlItem)
							{
								objWriter.WriteAttributeString("c", listViewSubControlItem.Control.GetProxyPropertyValue("ID", listViewSubControlItem.Control.ID).ToString());
								if (list == null)
								{
									list = new List<object>();
								}
								list.Add(listViewSubControlItem.Control);
							}
							else
							{
								objWriter.WriteAttributeText("c", listViewSubItem.Text);
							}
						}
						else
						{
							objWriter.WriteAttributeString("c", string.Empty);
						}
						objWriter.WriteEndElement();
					}
				}
				int indentCount = IndentCount;
				if (indentCount != 0)
				{
					objWriter.WriteAttributeString("IDC", indentCount.ToString());
				}
			}
			else if (HasSubItems)
			{
				objWriter.WriteStartElement("SI");
				objWriter.WriteAttributeString("COL", "0");
				ListViewSubItem listViewSubItem2 = mobjSubItems[0];
				objWriter.WriteAttributeText("c", listViewSubItem2.Text);
				listViewSubItem2.RenderStyle(objWriter, "s", listViewSubItem2.BackColor, listViewSubItem2.ForeColor, listViewSubItem2.Font);
				objWriter.WriteEndElement();
			}
			if (list != null)
			{
				foreach (Control item in list)
				{
					((IRenderableComponent)item).RenderComponent(objContext, objWriter, lngRequestID);
				}
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// Renders the update attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			}
		}

		/// 
		/// Renders the item image.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderItemImage(IResponseWriter objWriter, View enmView)
		{
			if (enmView == View.LargeIcon)
			{
				ResourceHandle largeImage = LargeImage;
				if (largeImage != null)
				{
					objWriter.WriteAttributeString("LIM", largeImage.ToString());
				}
			}
			else
			{
				ResourceHandle smallImage = SmallImage;
				if (smallImage != null)
				{
					objWriter.WriteAttributeString("IM", smallImage.ToString());
				}
			}
		}

		/// 
		/// Renders non dirty item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request id.</param>
		private void RenderNonDirtyItem(IContext objContext, IResponseWriter objWriter, long lngRequestID, ListView.ItemRenderingProcessor objProcessor)
		{
			if (objProcessor.View != View.Details)
			{
				return;
			}
			if (mobjSubItems != null)
			{
				foreach (ColumnHeader sortedColumn in objProcessor.SortedColumns)
				{
					if (sortedColumn.IsValidColumn && mobjSubItems.Count > sortedColumn.Index && mobjSubItems[sortedColumn.Index] is ListViewSubControlItem listViewSubControlItem)
					{
						((IRenderableComponent)listViewSubControlItem.Control).RenderComponent(objContext, objWriter, lngRequestID);
					}
				}
			}
			if (this is ListViewPanelItem listViewPanelItem)
			{
				((IRenderableComponent)listViewPanelItem.Panel).RenderComponent(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		///
		/// </summary>
		internal void InternalUnRegisterSelf()
		{
			UnRegisterSelf();
		}

		/// 
		///
		/// </summary>
		public void Remove()
		{
			if (ListView != null)
			{
				UnRegisterSelf();
				ListView.Items.Remove(this);
			}
		}

		/// Ensures that the item is visible within the control, scrolling the contents of the control, if necessary.</summary>
		public virtual void EnsureVisible()
		{
			if (ListView.UseInternalPaging)
			{
				int itemPage = GetItemPage();
				if (ListView.CurrentPage != itemPage)
				{
					ListView.CurrentPage = itemPage;
				}
			}
			InvokeMethodWithId("Controls_ScrollIntoView", ListView.ID, 1);
		}

		/// 
		/// Gets the item page.
		/// </summary>
		/// </returns>
		private int GetItemPage()
		{
			int result = 1;
			if (ListView.UseInternalPaging && ListView.TotalPages > 1)
			{
				int num = 0;
				foreach (ListViewItem item in ListView.Items)
				{
					num++;
					if (item == this)
					{
						break;
					}
				}
				result = (int)Math.Ceiling((double)num / (double)ListView.ItemsPerPage);
			}
			return result;
		}

		/// 
		/// Raises the <see cref="E:AfterLabelEdit" /> event.
		/// </summary>
		/// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs" /> instance containing the event data.</param>
		protected internal virtual void OnAfterLabelEdit(LabelEditEventArgs e)
		{
			AfterLabelEditHandler?.Invoke(this, e);
			if (ListView != null)
			{
				ListView.OnAfterLabelEditInternal(e);
			}
		}

		/// Initiates the editing of the item label.</summary>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void BeginEdit()
		{
			if (ListView != null && ListView.LabelEdit && ListView.Focused)
			{
				InvokeMethodWithId("LabelEditor_Show");
			}
		}

		/// Ends the editing of the tree node label.</summary>
		/// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void EndEdit(bool blnCancel)
		{
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			List<object> list = new List<object>();
			foreach (ListViewSubItem subItem in SubItems)
			{
				if (subItem is ListViewSubControlItem listViewSubControlItem)
				{
					list.Add(listViewSubControlItem.Control);
				}
			}
			return list;
		}

		/// 
		/// Moves to group.
		/// </summary>
		/// <param name="objNewGroup">The new group.</param>
		internal void MoveToGroup(ListViewGroup objNewGroup)
		{
			SetValue(GroupProperty, objNewGroup);
		}

		/// 
		/// Should the serialize large image.
		/// </summary>
		protected bool ShouldSerializeSmallImage()
		{
			return SmallImageList == null && ContainsValue(SmallImageProperty);
		}

		/// 
		/// Shows the serialize large image.
		/// </summary>
		protected bool ShouldSerializeLargeImage()
		{
			return LargeImageList == null && ContainsValue(LargeImageProperty);
		}

		/// 
		///
		/// </summary>
		public override void Update()
		{
			base.Update();
		}

		static ListViewItem()
		{
			AfterLabelEdit = SerializableEvent.Register("AfterLabelEdit", typeof(LabelEditEventHandler), typeof(ListViewItem));
		}
	}
}
