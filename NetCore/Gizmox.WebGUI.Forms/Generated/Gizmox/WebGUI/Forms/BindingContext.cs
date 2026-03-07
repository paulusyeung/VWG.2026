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
	/// Manages the collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for any object that inherits from the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class.</summary>
	/// 2</filterpriority>
	[Serializable]
	[DefaultEvent("CollectionChanged")]
	public class BindingContext : ICollection, IEnumerable
	{
		[Serializable]
		internal class HashKey
		{
			private string mstrDataMember;

			private int mintDataSourceHashCode;

			private WeakReference wRef;

			internal HashKey(object objDataSource, string strDataMember)
			{
				if (objDataSource == null)
				{
					throw new ArgumentNullException("dataSource");
				}
				if (strDataMember == null)
				{
					strDataMember = "";
				}
				wRef = new WeakReference(objDataSource, trackResurrection: false);
				mintDataSourceHashCode = objDataSource.GetHashCode();
				mstrDataMember = strDataMember.ToLower(CultureInfo.InvariantCulture);
			}

			public override bool Equals(object objTarget)
			{
				if (objTarget is HashKey)
				{
					HashKey hashKey = (HashKey)objTarget;
					if (wRef.Target == hashKey.wRef.Target)
					{
						return mstrDataMember == hashKey.mstrDataMember;
					}
				}
				return false;
			}

			public override int GetHashCode()
			{
				return mintDataSourceHashCode * mstrDataMember.GetHashCode();
			}
		}

		/// 
		///
		/// </summary>
		[NonSerialized]
		private Hashtable listManagers;

		/// Gets a value indicating whether the collection is read-only.</summary>
		/// true if the collection is read-only; otherwise, false.</returns>
		/// 1</filterpriority>
		public bool IsReadOnly => false;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source.</returns>
		/// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// 1</filterpriority>
		public BindingManagerBase this[object objDataSource] => this[objDataSource, ""];

		/// Gets a <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source and data member.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source and data member.</returns>
		/// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// <param name="strDataMember">A navigation path containing the information that resolves to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// <exception cref="T:System.Exception">The specified dataMember does not exist within the data source. </exception>
		/// 1</filterpriority>
		public BindingManagerBase this[object objDataSource, string strDataMember] => EnsureListManager(objDataSource, strDataMember);

		int ICollection.Count
		{
			get
			{
				ScrubWeakRefs();
				return listManagers.Count;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		/// Occurs when the collection has changed.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("collectionChangedEventDescr")]
		[Browsable(false)]
		public event CollectionChangeEventHandler CollectionChanged
		{
			add
			{
				throw new NotImplementedException();
			}
			remove
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> class.</summary>
		public BindingContext()
		{
			listManagers = new Hashtable();
		}

		/// Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
		/// <param name="objDataSource">The <see cref="T:System.Object"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add. </param>
		protected internal void Add(object objDataSource, BindingManagerBase objListManager)
		{
			AddCore(objDataSource, objListManager);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataSource));
		}

		/// Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
		/// <param name="objDataSource">The object associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add.</param>
		/// <exception cref="T:System.ArgumentNullException">dataSource is null.-or-listManager is null.</exception>
		protected virtual void AddCore(object objDataSource, BindingManagerBase objListManager)
		{
			if (objDataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (objListManager == null)
			{
				throw new ArgumentNullException("listManager");
			}
			listManagers[GetKey(objDataSource, "")] = new WeakReference(objListManager, trackResurrection: false);
		}

		private static void CheckPropertyBindingCycles(BindingContext newBindingContext, Binding propBinding)
		{
			if (newBindingContext == null || propBinding == null || !newBindingContext.Contains(propBinding.BindableComponent, ""))
			{
				return;
			}
			BindingManagerBase bindingManagerBase = newBindingContext.EnsureListManager(propBinding.BindableComponent, "");
			for (int i = 0; i < bindingManagerBase.Bindings.Count; i++)
			{
				Binding binding = bindingManagerBase.Bindings[i];
				if (binding.DataSource == propBinding.BindableComponent)
				{
					if (propBinding.BindToObject.BindingMemberInfo.BindingMember.Equals(binding.PropertyName))
					{
						throw new ArgumentException(SR.GetString("DataBindingCycle", binding.PropertyName), "propBinding");
					}
				}
				else if (propBinding.BindToObject.BindingManagerBase is PropertyManager)
				{
					CheckPropertyBindingCycles(newBindingContext, binding);
				}
			}
		}

		/// Clears the collection of any <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects.</summary>
		protected internal void Clear()
		{
			ClearCore();
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
		}

		/// Clears the collection.</summary>
		protected virtual void ClearCore()
		{
			listManagers.Clear();
		}

		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
		/// 1</filterpriority>
		public bool Contains(object objDataSource)
		{
			return Contains(objDataSource, "");
		}

		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source and data member.</summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
		/// <param name="strDataMember">The information needed to resolve to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
		/// 1</filterpriority>
		public bool Contains(object objDataSource, string strDataMember)
		{
			return listManagers.ContainsKey(GetKey(objDataSource, strDataMember));
		}

		internal BindingManagerBase EnsureListManager(object objDataSource, string strDataMember)
		{
			BindingManagerBase bindingManagerBase = null;
			if (strDataMember == null)
			{
				strDataMember = "";
			}
			if (objDataSource is ICurrencyManagerProvider)
			{
				bindingManagerBase = (objDataSource as ICurrencyManagerProvider).GetRelatedCurrencyManager(strDataMember);
				if (bindingManagerBase != null)
				{
					return bindingManagerBase;
				}
			}
			HashKey key = GetKey(objDataSource, strDataMember);
			if (listManagers == null)
			{
				listManagers = new Hashtable();
			}
			WeakReference weakReference = listManagers[key] as WeakReference;
			if (weakReference != null)
			{
				bindingManagerBase = (BindingManagerBase)weakReference.Target;
			}
			if (bindingManagerBase == null)
			{
				if (strDataMember.Length == 0)
				{
					bindingManagerBase = ((!(objDataSource is IList) && !(objDataSource is IListSource)) ? ((BindingManagerBase)new PropertyManager(objDataSource)) : ((BindingManagerBase)new CurrencyManager(objDataSource)));
				}
				else
				{
					int num = strDataMember.LastIndexOf(".");
					string strDataMember2 = ((num == -1) ? "" : strDataMember.Substring(0, num));
					string text = strDataMember.Substring(num + 1);
					BindingManagerBase bindingManagerBase2 = EnsureListManager(objDataSource, strDataMember2);
					PropertyDescriptor propertyDescriptor = bindingManagerBase2.GetItemProperties().Find(text, ignoreCase: true);
					if (propertyDescriptor == null)
					{
						throw new ArgumentException(SR.GetString("RelatedListManagerChild", text));
					}
					bindingManagerBase = ((!typeof(IList).IsAssignableFrom(propertyDescriptor.PropertyType)) ? ((BindingManagerBase)new RelatedPropertyManager(bindingManagerBase2, text)) : ((BindingManagerBase)new RelatedCurrencyManager(bindingManagerBase2, text)));
				}
				if (weakReference == null)
				{
					listManagers.Add(key, new WeakReference(bindingManagerBase, trackResurrection: false));
					return bindingManagerBase;
				}
				weakReference.Target = bindingManagerBase;
			}
			return bindingManagerBase;
		}

		internal HashKey GetKey(object objDataSource, string strDataMember)
		{
			return new HashKey(objDataSource, strDataMember);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingContext.CollectionChanged"></see> event.</summary>
		/// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
		protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
		{
		}

		/// Deletes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
		/// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove. </param>
		protected internal void Remove(object objDataSource)
		{
			RemoveCore(objDataSource);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objDataSource));
		}

		/// Removes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
		/// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove.</param>
		protected virtual void RemoveCore(object objDataSource)
		{
			listManagers.Remove(GetKey(objDataSource, ""));
		}

		private void ScrubWeakRefs()
		{
			object[] array = new object[listManagers.Count];
			listManagers.CopyTo(array, 0);
			for (int i = 0; i < array.Length; i++)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)array[i];
				WeakReference weakReference = (WeakReference)dictionaryEntry.Value;
				if (weakReference.Target == null)
				{
					listManagers.Remove(dictionaryEntry.Key);
				}
			}
		}

		void ICollection.CopyTo(Array objArray, int index)
		{
			ScrubWeakRefs();
			listManagers.CopyTo(objArray, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			ScrubWeakRefs();
			return listManagers.GetEnumerator();
		}

		/// Associates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> with a new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</summary>
		/// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to associate with the new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</param>
		/// <param name="objNewBindingContext">The new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> to associate with the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</param>
		/// 1</filterpriority>
		public static void UpdateBinding(BindingContext objNewBindingContext, Binding objBinding)
		{
			objBinding.BindingManagerBase?.Bindings.Remove(objBinding);
			if (objNewBindingContext != null)
			{
				if (objBinding.BindToObject.BindingManagerBase is PropertyManager)
				{
					CheckPropertyBindingCycles(objNewBindingContext, objBinding);
				}
				BindToObject bindToObject = objBinding.BindToObject;
				BindingManagerBase bindingManagerBase = objNewBindingContext.EnsureListManager(bindToObject.DataSource, bindToObject.BindingMemberInfo.BindingPath);
				bindingManagerBase.Bindings.Add(objBinding);
			}
		}
	}
}
