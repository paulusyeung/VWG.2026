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
	/// Represents the collection of data bindings for a control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[DefaultEvent("CollectionChanged")]
	[TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public class ControlBindingsCollection : BindingsCollection
	{
		internal IBindableComponent mobjControl;

		private DataSourceUpdateMode menmDefaultDataSourceUpdateMode;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</returns>
		/// 1</filterpriority>
		public IBindableComponent BindableComponent => mobjControl;

		/// Gets the control that the collection belongs to.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the collection belongs to.</returns>
		/// 1</filterpriority>
		public Control Control => mobjControl as Control;

		/// Gets or sets the default <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSourceUpdateMode"></see> for a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> in the collection.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</returns>
		public DataSourceUpdateMode DefaultDataSourceUpdateMode
		{
			get
			{
				return menmDefaultDataSourceUpdateMode;
			}
			set
			{
				menmDefaultDataSourceUpdateMode = value;
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> specified by the control's property name.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> that binds the specified control property to a data source.</returns>
		/// <param name="strPropertyName">The name of the property on the data-bound control. </param>
		/// 1</filterpriority>
		public Binding this[string strPropertyName]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Binding binding = (Binding)enumerator.Current;
						if (ClientUtils.IsEquals(binding.PropertyName, strPropertyName, StringComparison.OrdinalIgnoreCase))
						{
							return binding;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> class with the specified bindable control.</summary>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</param>
		public ControlBindingsCollection(IBindableComponent objControl)
		{
			mobjControl = objControl;
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
		/// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
		/// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
		/// <exception cref="T:System.ArgumentException">The control property is already data-bound. </exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> does not specify a valid column of the <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSource"></see>. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public new void Add(Binding objBinding)
		{
			base.Add(objBinding);
		}

		/// Creates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> using the specified control property name, data source, and data member, and adds it to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
		/// <param name="strDataMember">The property or list to bind to. </param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <exception cref="T:System.Exception">The propertyName is already data-bound. </exception>
		/// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
		/// <exception cref="T:System.Exception">The dataMember doesn't specify a valid member of the dataSource. </exception>
		/// 1</filterpriority>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember)
		{
			return Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled: false, DefaultDataSourceUpdateMode, null, string.Empty, null);
		}

		/// Creates a binding with the specified control property name, data source, data member, and information about whether formatting is enabled, and adds the binding to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false</param>
		/// <param name="strDataMember">The property or list to bind to.</param>
		/// <param name="strPropertyName">The name of the control property to bind.</param>
		/// <exception cref="T:System.Exception">If formatting is disabled and the propertyName is neither a valid property of a control nor an empty string (""). </exception>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
		/// 1</filterpriority>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled)
		{
			return Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, DefaultDataSourceUpdateMode, null, string.Empty, null);
		}

		/// Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, and adding the binding to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
		/// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
		/// <param name="strDataMember">The property or list to bind to.</param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode)
		{
			return Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, null, string.Empty, null);
		}

		/// Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
		/// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
		/// <param name="strDataMember">The property or list to bind to.</param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue)
		{
			return Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, string.Empty, null);
		}

		/// Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
		/// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed.</param>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
		/// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
		/// <param name="strDataMember">The property or list to bind to.</param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue, string strFormatString)
		{
			return Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, null);
		}

		/// Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, setting the specified format provider, and adding the binding to the collection.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		/// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed</param>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
		/// <param name="objFormatInfo">An implementation of <see cref="T:System.IFormatProvider"></see> to override default formatting behavior.</param>
		/// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
		/// <param name="strDataMember">The property or list to bind to.</param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
		public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue, string strFormatString, IFormatProvider objFormatInfo)
		{
			if (objDataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			Binding binding = new Binding(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, objFormatInfo);
			Add(binding);
			return binding;
		}

		/// Adds a binding to the collection.</summary>
		/// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
		protected override void AddCore(Binding objDataBinding)
		{
			if (objDataBinding == null)
			{
				throw new ArgumentNullException("dataBinding");
			}
			if (objDataBinding.BindableComponent == mobjControl)
			{
				throw new ArgumentException(SR.GetString("BindingsCollectionAdd1"));
			}
			if (objDataBinding.BindableComponent != null)
			{
				throw new ArgumentException(SR.GetString("BindingsCollectionAdd2"));
			}
			objDataBinding.SetBindableComponent(mobjControl);
			base.AddCore(objDataBinding);
		}

		internal void CheckDuplicates(Binding objBinding)
		{
			if (objBinding.PropertyName.Length == 0)
			{
				return;
			}
			for (int i = 0; i < Count; i++)
			{
				if (objBinding != base[i] && base[i].PropertyName.Length > 0 && string.Compare(objBinding.PropertyName, base[i].PropertyName, ignoreCase: false, CultureInfo.InvariantCulture) == 0)
				{
					throw new ArgumentException(SR.GetString("BindingsCollectionDup"), "binding");
				}
			}
		}

		/// 
		/// Clears the collection of any bindings.
		/// </summary>
		public new void Clear()
		{
			base.Clear();
		}

		/// Clears the bindings in the collection.</summary>
		protected override void ClearCore()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				base[i].SetBindableComponent(null);
			}
			base.ClearCore();
		}

		/// 
		/// Deletes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.
		/// </summary>
		/// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove.</param>
		/// <exception cref="T:System.NullReferenceException">The binding is null. </exception>
		public new void Remove(Binding objBinding)
		{
			base.Remove(objBinding);
		}

		/// 
		/// Deletes the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0, or it is greater than the number of bindings in the collection. </exception>
		public new void RemoveAt(int index)
		{
			base.RemoveAt(index);
		}

		/// Removes the specified binding from the collection.</summary>
		/// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove from the collection.</param>
		/// <exception cref="T:System.ArgumentException">The binding belongs to another <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see>.</exception>
		protected override void RemoveCore(Binding objDataBinding)
		{
			if (objDataBinding.BindableComponent != mobjControl)
			{
				throw new ArgumentException(SR.GetString("BindingsCollectionForeign"));
			}
			objDataBinding.SetBindableComponent(null);
			base.RemoveCore(objDataBinding);
		}
	}
}
