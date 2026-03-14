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
/// Represents a sorted collection of <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> objects in the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
	[Serializable]
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ListBindable(false)]
	public class NumericUpDownAccelerationCollection : MarshalByRefObject, ICollection, IEnumerable
	{
		public object SyncRoot => this;
		public bool IsSynchronized => false;
		IEnumerator IEnumerable.GetEnumerator() { return null; }
		/// Gets the number of objects in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
		/// The number of objects in the collection.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count => 0;
        public void CopyTo(Array array, int index) { }

		/// Gets a value indicating whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> is read-only.</summary>
		/// true if the collectionms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.1033/cpref/html/frlrfsystemcollectionsilistclasstopic.htm is read-only; otherwise, false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		/// Gets the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> at the specified index number.</summary>
		/// The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> with the specified index.</returns>
		/// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to get from the collection.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public NumericUpDownAcceleration this[int index] => null;

		/// Adds a new <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
		/// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to add to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
		/// <exception cref="T:System.ArgumentNullException">acceleration is null.</exception>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void Add(NumericUpDownAcceleration acceleration)
		{
		}

		/// Adds the elements of the specified array to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>, keeping the collection sorted.</summary>
		/// <param name="accelerations">An array of type <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>  containing the objects to add to the collection.</param>
		/// <exception cref="T:System.ArgumentNullException">accelerations is null, or one of the entries in the accelerations array is null.</exception>
		public void AddRange(params NumericUpDownAcceleration[] accelerations)
		{
		}

		/// Removes all elements from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void Clear()
		{
		}

		/// Determines whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> contains a specific <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>.</summary>
		/// true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is found in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
		/// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to locate in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Contains(NumericUpDownAcceleration acceleration)
		{
			return false;
		}

		/// Copies the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> values to a one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> instance at the specified index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> that is the destination of the values copied from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>. </param>
		/// <param name="index">The index in array where copying begins.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void CopyTo(NumericUpDownAcceleration[] array, int index)
		{
		}

		/// Removes the first occurrence of the specified <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
		/// true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is removed from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
		/// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to remove from the collection.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Remove(NumericUpDownAcceleration acceleration)
		{
			return false;
		}

		

		
	}
}
