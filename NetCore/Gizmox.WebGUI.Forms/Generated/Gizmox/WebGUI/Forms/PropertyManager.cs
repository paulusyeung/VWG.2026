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
/// Maintains a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between an object's property and a data-bound control property.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class PropertyManager : BindingManagerBase
	{
		private static readonly SerializableProperty boundProperty = SerializableProperty.Register("bound", typeof(bool), typeof(PropertyManager));

		private static readonly SerializableProperty dataSourceProperty = SerializableProperty.Register("dataSource", typeof(object), typeof(PropertyManager));

		[NonSerialized]
		private PropertyDescriptor mobjPropertyDescriptor;

		private string mstrPropName;

		private bool bound
		{
			get
			{
				return GetValue(boundProperty);
			}
			set
			{
				SetValue(boundProperty, value);
			}
		}

		private object dataSource
		{
			get
			{
				return GetValue(dataSourceProperty);
			}
			set
			{
				SetValue(dataSourceProperty, value);
			}
		}

		internal override Type BindType => dataSource.GetType();

		/// 1</filterpriority>
		public override int Count => 1;

		/// Gets the object to which the data-bound property belongs.</summary>
		/// An <see cref="T:System.Object"></see> that represents the object to which the property belongs.</returns>
		/// 1</filterpriority>
		public override object Current => dataSource;

		internal override object DataSource => dataSource;

		internal override bool IsBinding => dataSource != null;

		/// 1</filterpriority>
		public override int Position
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyManager"></see> class.</summary>
		public PropertyManager()
		{
		}

		internal PropertyManager(object objDataSource)
			: base(objDataSource)
		{
		}

		internal PropertyManager(object objDataSource, string strPropName)
		{
			mstrPropName = strPropName;
			SetDataSource(objDataSource);
		}

		/// 1</filterpriority>
		public override void AddNew()
		{
			throw new NotSupportedException(SR.GetString("DataBindingAddNewNotSupportedOnPropertyManager"));
		}

		/// 1</filterpriority>
		public override void CancelCurrentEdit()
		{
			if (Current is IEditableObject editableObject)
			{
				editableObject.CancelEdit();
			}
			PushData();
		}

		/// 1</filterpriority>
		public override void EndCurrentEdit()
		{
			PullData(out var blnSuccess);
			if (blnSuccess && Current is IEditableObject editableObject)
			{
				editableObject.EndEdit();
			}
		}

		internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
		{
			return ListBindingHelper.GetListItemProperties(dataSource, arrListAccessors);
		}

		internal override string GetListName()
		{
			return TypeDescriptor.GetClassName(dataSource) + "." + mstrPropName;
		}

		/// 
		/// When overridden in a derived class, gets the name of the list supplying the data for the binding.
		/// </summary>
		/// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties.</param>
		/// 
		/// The name of the list supplying the data for the binding.
		/// </returns>
		protected internal override string GetListName(ArrayList objListAccessors)
		{
			return "";
		}

		/// 
		/// Raises the <see cref="E:CurrentChanged" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected internal override void OnCurrentChanged(EventArgs objEventArgs)
		{
			PushData();
			FireCurrentChanged(this, objEventArgs);
			FireCurrentItemChanged(this, objEventArgs);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
		/// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> containing the event data.</param>
		protected internal override void OnCurrentItemChanged(EventArgs objEventArgs)
		{
			PushData();
			FireCurrentItemChanged(this, objEventArgs);
		}

		private void PropertyChanged(object sender, EventArgs ea)
		{
			EndCurrentEdit();
			OnCurrentChanged(EventArgs.Empty);
		}

		/// 1</filterpriority>
		public override void RemoveAt(int index)
		{
			throw new NotSupportedException(SR.GetString("DataBindingRemoveAtNotSupportedOnPropertyManager"));
		}

		/// 1</filterpriority>
		public override void ResumeBinding()
		{
			OnCurrentChanged(new EventArgs());
			if (!bound)
			{
				try
				{
					bound = true;
					UpdateIsBinding();
				}
				catch
				{
					bound = false;
					UpdateIsBinding();
					throw;
				}
			}
		}

		internal override void SetDataSource(object objDataSource)
		{
			if (dataSource != null && !CommonUtils.IsNullOrEmpty(mstrPropName))
			{
				mobjPropertyDescriptor.RemoveValueChanged(dataSource, PropertyChanged);
				mobjPropertyDescriptor = null;
			}
			dataSource = objDataSource;
			if (dataSource != null && !CommonUtils.IsNullOrEmpty(mstrPropName))
			{
				mobjPropertyDescriptor = TypeDescriptor.GetProperties(objDataSource).Find(mstrPropName, ignoreCase: true);
				if (mobjPropertyDescriptor == null)
				{
					throw new ArgumentException(SR.GetString("PropertyManagerPropDoesNotExist", mstrPropName, objDataSource.ToString()));
				}
				mobjPropertyDescriptor.AddValueChanged(objDataSource, PropertyChanged);
			}
		}

		/// Suspends the data binding between a data source and a data-bound property.</summary>
		/// 1</filterpriority>
		public override void SuspendBinding()
		{
			EndCurrentEdit();
			if (bound)
			{
				try
				{
					bound = false;
					UpdateIsBinding();
				}
				catch
				{
					bound = true;
					UpdateIsBinding();
					throw;
				}
			}
		}

		/// Updates the current <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between a data binding and a data-bound property.</summary>
		protected override void UpdateIsBinding()
		{
			for (int i = 0; i < base.Bindings.Count; i++)
			{
				base.Bindings[i].UpdateIsBinding();
			}
		}
	}
}
