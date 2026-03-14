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
	/// Implements one row in a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
	/// </summary>
	[Serializable]
	public abstract class GridItem : SerializableObject
	{
		/// 
		/// The object property registration.
		/// </summary>
		private static readonly SerializableProperty userDataProperty = SerializableProperty.Register("userData", typeof(object), typeof(GridItem));

		/// 
		/// Gets or sets the user data.
		/// </summary>
		/// The user data.</value>
		private object userData
		{
			get
			{
				return GetValue(userDataProperty);
			}
			set
			{
				SetValue(userDataProperty, value);
			}
		}

		/// 
		/// When overridden in a derived class, returns the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see> to which the current <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> belongs.
		/// </summary>
		/// The owning PropertyGrid.</returns>
		[Browsable(false)]
		public abstract PropertyGrid OwnerGrid { get; }

		/// 
		/// When overridden in a derived class, gets a value indicating whether the specified property is expandable to show nested properties.
		/// </summary>
		/// true if the specified property can be expanded; otherwise, false. The default is false.</returns>
		public virtual bool Expandable => false;

		/// When overridden in a derived class, gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is in an expanded state.</summary>
		/// false in all cases.</returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="P:Gizmox.WebGUI.Forms.GridItem.Expanded"></see> property was set to true, but a <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is not expandable.</exception>
		public virtual bool Expanded
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotSupportedException(SR.GetString("GridItemNotExpandable"));
			}
		}

		/// 
		/// When overridden in a derived class, gets the collection of <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> objects, if any, associated as a child of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see>.</returns>
		public abstract GridItemCollection GridItems { get; }

		/// 
		/// When overridden in a derived class, gets the type of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.GridItemType"></see> values.</returns>
		public abstract GridItemType GridItemType { get; }

		/// 
		/// When overridden in a derived class, gets the text of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// A <see cref="T:System.String"></see> representing the text associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
		public abstract string Label { get; }

		/// 
		/// When overridden in a derived class, gets the parent <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>, if any.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> representing the parent of the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
		public abstract GridItem Parent { get; }

		/// 
		/// When overridden in a derived class, gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
		public abstract PropertyDescriptor PropertyDescriptor { get; }

		/// 
		/// Gets or sets user-defined data about the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// An <see cref="T:System.Object"></see> that contains data about the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
		[SRCategory("CatData")]
		[Localizable(false)]
		[Bindable(true)]
		[TypeConverter(typeof(StringConverter))]
		[SRDescription("ControlTagDescr")]
		[DefaultValue(null)]
		public object Tag
		{
			get
			{
				return userData;
			}
			set
			{
				userData = value;
			}
		}

		/// 
		/// When overridden in a derived class, gets the current value of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
		/// </summary>
		/// The current value of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>. This can be null.</returns>
		public abstract object Value { get; }

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> class. 
		/// </summary>
		protected GridItem()
		{
		}

		/// 
		/// When overridden in a derived class, selects this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
		/// </summary>
		/// true if the selection is successful; otherwise, false.</returns>
		public abstract bool Select();
	}
}
