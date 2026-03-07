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
	/// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> objects.
	/// </summary>
	[Serializable]
	public class GridItemCollection : ICollection, IEnumerable
	{
		/// 
		/// Specifies that the <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see> has no entries. 
		/// </summary>
		public static GridItemCollection Empty;

		internal GridItem[] marrEntries;

		/// 
		/// Gets the number of grid items in the collection.
		/// </summary>
		/// The number of grid items in the collection.</returns>
		public int Count => marrEntries.Length;

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> at the specified index.
		/// </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> at the specified index.</returns>
		/// <param name="index">The index of the grid item to return. </param>
		public GridItem this[int index] => marrEntries[index];

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> with the matching label.
		/// </summary>
		/// The grid item whose label matches the label parameter.</returns>
		/// <param name="strLabel">A string value to match to a grid item label </param>
		public GridItem this[string strLabel]
		{
			get
			{
				GridItem[] array = marrEntries;
				foreach (GridItem gridItem in array)
				{
					if (gridItem.Label == strLabel)
					{
						return gridItem;
					}
				}
				return null;
			}
		}

		/// 
		/// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
		/// </summary>
		bool ICollection.IsSynchronized => false;

		/// 
		/// For a description of this member, see <see cref="P:System.Collections.ICollection.SyncRoot"></see>.
		/// </summary>
		object ICollection.SyncRoot => this;

		static GridItemCollection()
		{
			Empty = new GridItemCollection(new GridItem[0]);
		}

		internal GridItemCollection(GridItem[] arrEntries)
		{
			if (arrEntries == null)
			{
				marrEntries = new GridItem[0];
			}
			else
			{
				marrEntries = arrEntries;
			}
		}

		/// 
		/// Returns an enumeration of all the grid items in the collection.
		/// </summary>
		/// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see>.</returns>
		public IEnumerator GetEnumerator()
		{
			return marrEntries.GetEnumerator();
		}

		/// 
		/// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
		/// </summary>
		/// <param name="objDestinationArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in the array at which copying begins.</param>
		void ICollection.CopyTo(Array objDestinationArray, int index)
		{
			if (marrEntries.Length != 0)
			{
				Array.Copy(marrEntries, 0, objDestinationArray, index, marrEntries.Length);
			}
		}
	}
}
