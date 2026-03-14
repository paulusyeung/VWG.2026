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
/// Manages all <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects that are bound to the same data source and data member. This class is abstract.</summary>
	/// 2</filterpriority>
	[Serializable]
	public abstract class BindingManagerBase : SerializableObject
	{
		private BindingsCollection mobjBindings;

		private bool mblnPullingData;

		/// Gets the collection of bindings being managed.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.BindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
		/// 1</filterpriority>
		public BindingsCollection Bindings
		{
			get
			{
				if (mobjBindings == null)
				{
					mobjBindings = new ListManagerBindingsCollection(this);
					mobjBindings.CollectionChanging += OnBindingsCollectionChanging;
					mobjBindings.CollectionChanged += OnBindingsCollectionChanged;
				}
				return mobjBindings;
			}
		}

		internal int BindingsCount
		{
			get
			{
				if (mobjBindings != null)
				{
					return mobjBindings.Count;
				}
				return 0;
			}
		}

		internal abstract Type BindType { get; }

		/// When overridden in a derived class, gets the number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
		/// The number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
		/// 1</filterpriority>
		public abstract int Count { get; }

		/// When overridden in a derived class, gets the current object.</summary>
		/// An <see cref="T:System.Object"></see> that represents the current object.</returns>
		/// 1</filterpriority>
		public abstract object Current { get; }

		internal abstract object DataSource { get; }

		internal abstract bool IsBinding { get; }

		/// Gets a value indicating whether binding is suspended.</summary>
		/// true if binding is suspended; otherwise, false.</returns>
		public bool IsBindingSuspended => !IsBinding;

		/// When overridden in a derived class, gets or sets the position in the underlying list that controls bound to this data source point to.</summary>
		/// A zero-based index that specifies a position in the underlying list.</returns>
		/// 1</filterpriority>
		public abstract int Position { get; set; }

		/// Occurs at the completion of a data-binding operation.</summary>
		public event BindingCompleteEventHandler BindingComplete;

		/// Occurs when the currently bound item changes.</summary>
		/// 1</filterpriority>
		public event EventHandler CurrentChanged;

		/// Occurs when the state of the currently bound item changes.</summary>
		/// 1</filterpriority>
		public event EventHandler CurrentItemChanged;

		/// Occurs when an <see cref="T:System.Exception"></see> is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </summary>
		public event BindingManagerDataErrorEventHandler DataError;

		/// Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingManagerBase.Position"></see> property has changed.</summary>
		/// 1</filterpriority>
		public event EventHandler PositionChanged;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> class.</summary>
		public BindingManagerBase()
		{
		}

		internal BindingManagerBase(object objDataSource)
		{
			SetDataSource(objDataSource);
		}

		/// When overridden in a derived class, adds a new item to the underlying list.</summary>
		/// 1</filterpriority>
		public abstract void AddNew();

		internal void Binding_BindingComplete(object sender, BindingCompleteEventArgs args)
		{
			OnBindingComplete(args);
		}

		/// When overridden in a derived class, cancels the current edit.</summary>
		/// 1</filterpriority>
		public abstract void CancelCurrentEdit();

		/// When overridden in a derived class, ends the current edit.</summary>
		/// 1</filterpriority>
		public abstract void EndCurrentEdit();

		/// When overridden in a derived class, gets the collection of property descriptors for the binding.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
		/// 1</filterpriority>
		public virtual PropertyDescriptorCollection GetItemProperties()
		{
			return GetItemProperties(null);
		}

		internal abstract PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors);

		/// Gets the collection of property descriptors for the binding using the specified <see cref="T:System.Collections.ArrayList"></see>.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
		/// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
		/// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
		protected internal virtual PropertyDescriptorCollection GetItemProperties(ArrayList objDataSources, ArrayList objListAccessors)
		{
			IList list = null;
			if (this is CurrencyManager)
			{
				list = ((CurrencyManager)this).List;
			}
			if (list is ITypedList)
			{
				PropertyDescriptor[] array = new PropertyDescriptor[objListAccessors.Count];
				objListAccessors.CopyTo(array, 0);
				return ((ITypedList)list).GetItemProperties(array);
			}
			return GetItemProperties(BindType, 0, objDataSources, objListAccessors);
		}

		/// Gets the list of properties of the items managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
		/// <param name="intOffset">A counter used to recursively call the method. </param>
		/// <param name="objListType">The <see cref="T:System.Type"></see> of the bound list. </param>
		/// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
		/// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
		protected virtual PropertyDescriptorCollection GetItemProperties(Type objListType, int intOffset, ArrayList objDataSources, ArrayList objListAccessors)
		{
			if (objListAccessors.Count >= intOffset)
			{
				if (objListAccessors.Count == intOffset)
				{
					if (!typeof(IList).IsAssignableFrom(objListType))
					{
						return TypeDescriptor.GetProperties(objListType);
					}
					PropertyInfo[] properties = objListType.GetProperties();
					for (int i = 0; i < properties.Length; i++)
					{
						if ("Item".Equals(properties[i].Name) && properties[i].PropertyType != typeof(object))
						{
							return TypeDescriptor.GetProperties(properties[i].PropertyType, new Attribute[1]
							{
								new BrowsableAttribute(browsable: true)
							});
						}
					}
					if (!(objDataSources[intOffset - 1] is IList { Count: >0 } list))
					{
						return null;
					}
					return TypeDescriptor.GetProperties(list[0]);
				}
				PropertyInfo[] properties2 = objListType.GetProperties();
				if (typeof(IList).IsAssignableFrom(objListType))
				{
					PropertyDescriptorCollection propertyDescriptorCollection = null;
					for (int j = 0; j < properties2.Length; j++)
					{
						if ("Item".Equals(properties2[j].Name) && properties2[j].PropertyType != typeof(object))
						{
							propertyDescriptorCollection = TypeDescriptor.GetProperties(properties2[j].PropertyType, new Attribute[1]
							{
								new BrowsableAttribute(browsable: true)
							});
						}
					}
					if (propertyDescriptorCollection == null)
					{
						IList list2 = ((intOffset != 0) ? (objDataSources[intOffset - 1] as IList) : (DataSource as IList));
						if (list2 != null && list2.Count > 0)
						{
							propertyDescriptorCollection = TypeDescriptor.GetProperties(list2[0]);
						}
					}
					if (propertyDescriptorCollection != null)
					{
						for (int k = 0; k < propertyDescriptorCollection.Count; k++)
						{
							if (propertyDescriptorCollection[k].Equals(objListAccessors[intOffset]))
							{
								return GetItemProperties(propertyDescriptorCollection[k].PropertyType, intOffset + 1, objDataSources, objListAccessors);
							}
						}
					}
				}
				else
				{
					for (int l = 0; l < properties2.Length; l++)
					{
						if (properties2[l].Name.Equals(((PropertyDescriptor)objListAccessors[intOffset]).Name))
						{
							return GetItemProperties(properties2[l].PropertyType, intOffset + 1, objDataSources, objListAccessors);
						}
					}
				}
			}
			return null;
		}

		internal abstract string GetListName();

		/// When overridden in a derived class, gets the name of the list supplying the data for the binding.</summary>
		/// The name of the list supplying the data for the binding.</returns>
		/// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
		protected internal abstract string GetListName(ArrayList objListAccessors);

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.BindingComplete"></see> event. </summary>
		/// <param name="objEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
		protected internal void OnBindingComplete(BindingCompleteEventArgs objEventArgs)
		{
			if (this.BindingComplete != null)
			{
				this.BindingComplete(this, objEventArgs);
			}
		}

		private void OnBindingsCollectionChanged(object sender, CollectionChangeEventArgs e)
		{
			Binding binding = e.Element as Binding;
			switch (e.Action)
			{
			case CollectionChangeAction.Add:
				binding.BindingComplete += Binding_BindingComplete;
				break;
			case CollectionChangeAction.Remove:
				binding.BindingComplete -= Binding_BindingComplete;
				break;
			case CollectionChangeAction.Refresh:
			{
				foreach (Binding mobjBinding in mobjBindings)
				{
					mobjBinding.BindingComplete += Binding_BindingComplete;
				}
				break;
			}
			}
		}

		private void OnBindingsCollectionChanging(object sender, CollectionChangeEventArgs e)
		{
			if (e.Action != CollectionChangeAction.Refresh)
			{
				return;
			}
			foreach (Binding mobjBinding in mobjBindings)
			{
				mobjBinding.BindingComplete -= Binding_BindingComplete;
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.</summary>
		/// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal abstract void OnCurrentChanged(EventArgs e);

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
		/// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal abstract void OnCurrentItemChanged(EventArgs e);

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event.</summary>
		/// <param name="objException">An <see cref="T:System.Exception"></see> that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to occur.</param>
		protected internal void OnDataError(Exception objException)
		{
			this.DataError?.Invoke(this, new BindingManagerDataErrorEventArgs(objException));
		}

		/// Pulls data from the data-bound control into the data source, returning no information.</summary>
		protected void PullData()
		{
			PullData(out var _);
		}

		internal void PullData(out bool blnSuccess)
		{
			blnSuccess = true;
			mblnPullingData = true;
			try
			{
				UpdateIsBinding();
				int count = Bindings.Count;
				for (int i = 0; i < count; i++)
				{
					if (Bindings[i].PullData())
					{
						blnSuccess = false;
					}
				}
			}
			finally
			{
				mblnPullingData = false;
			}
		}

		/// Pushes data from the data source into the data-bound control, returning no information.</summary>
		protected void PushData()
		{
			PushData(out var _);
		}

		internal void PushData(out bool blnSuccess)
		{
			blnSuccess = true;
			if (mblnPullingData)
			{
				return;
			}
			UpdateIsBinding();
			int count = Bindings.Count;
			for (int i = 0; i < count; i++)
			{
				if (Bindings[i].PushData())
				{
					blnSuccess = false;
				}
			}
		}

		/// When overridden in a derived class, deletes the row at the specified index from the underlying list.</summary>
		/// <param name="index">The index of the row to delete. </param>
		/// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
		/// 1</filterpriority>
		public abstract void RemoveAt(int index);

		/// When overridden in a derived class, resumes data binding.</summary>
		/// 1</filterpriority>
		public abstract void ResumeBinding();

		internal abstract void SetDataSource(object objDataSource);

		/// When overridden in a derived class, suspends data binding.</summary>
		/// 1</filterpriority>
		public abstract void SuspendBinding();

		/// When overridden in a derived class, updates the binding.</summary>
		protected abstract void UpdateIsBinding();

		/// 
		/// Fires the current changed.
		/// </summary>
		/// <param name="objSource">The obj source.</param>
		/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected void FireCurrentChanged(object objSource, EventArgs objArgs)
		{
			if (this.CurrentChanged != null)
			{
				this.CurrentChanged(objSource, objArgs);
			}
		}

		/// 
		/// Fires the current item changed.
		/// </summary>
		/// <param name="objSource">The obj source.</param>
		/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected void FireCurrentItemChanged(object objSource, EventArgs objArgs)
		{
			if (this.CurrentItemChanged != null)
			{
				this.CurrentItemChanged(objSource, objArgs);
			}
		}

		/// 
		/// Fires the position changed.
		/// </summary>
		/// <param name="objSource">The obj source.</param>
		/// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected void FirePositionChanged(object objSource, EventArgs objArgs)
		{
			if (this.PositionChanged != null)
			{
				this.PositionChanged(objSource, objArgs);
			}
		}
	}
}
