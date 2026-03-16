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

namespace Gizmox.WebGUI.Forms.Hosts
{
/// 
	/// Summary description for ObjectBox.
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[MetadataTag("OBJ")]
	[Skin(typeof(ObjectBoxSkin))]
	public class ObjectBox : Control
	{
		[Serializable]
		[Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public class ObjectBoxParameterCollection : Collection<ObjectBoxParameter>
		{
			private ObjectBox mobjObjectBox = null;

			/// 
			/// Gets the object box.
			/// </summary>
			/// The object box.</value>
			internal ObjectBox ObjectBox => mobjObjectBox;

			/// 
			/// Gets the keys.
			/// </summary>
			/// The keys.</value>
			public string[] Keys
			{
				get
				{
					List<string> list = new List<string>();
					foreach (ObjectBoxParameter current in this)
					{
						list.Add(current.Name);
					}
					return list.ToArray();
				}
			}

			/// 
			/// Gets or sets the <see cref="T:System.Object" /> with the specified STR name.
			/// </summary>
			/// </value>
			public object this[string strName]
			{
				get
				{
					foreach (ObjectBoxParameter current in this)
					{
						if (current.Name == strName)
						{
							return current.Value;
						}
					}
					return null;
				}
				set
				{
					Remove(strName);
					Add(new ObjectBoxParameter(this, strName, value));
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameterCollection" /> class.
			/// </summary>
			/// <param name="objObjectBox">The obj object box.</param>
			internal ObjectBoxParameterCollection(ObjectBox objObjectBox)
			{
				mobjObjectBox = objObjectBox;
			}

			/// 
			/// Adds the specified  name.
			/// </summary>
			/// <param name="strName">Name.</param>
			/// <param name="objValue">The value.</param>
			public void Add(string strName, object objValue)
			{
				this[strName] = objValue;
			}

			/// 
			/// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1" /> at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
			/// <param name="objItem">The object to insert. The value can be null for reference types.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			/// 	<paramref name="index" /> is less than zero.
			/// -or-
			/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
			/// </exception>
			protected override void InsertItem(int index, ObjectBoxParameter objItem)
			{
				ValidateItem(objItem);
				SetOwner(objItem);
				FormatValue(objItem);
				base.InsertItem(index, objItem);
			}

			/// 
			/// Replaces the element at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index of the element to replace.</param>
			/// <param name="objItem">The new value for the element at the specified index. The value can be null for reference types.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			/// 	<paramref name="index" /> is less than zero.
			/// -or-
			/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
			/// </exception>
			protected override void SetItem(int index, ObjectBoxParameter objItem)
			{
				ValidateItem(objItem);
				SetOwner(objItem);
				FormatValue(objItem);
				base.SetItem(index, objItem);
			}

			/// 
			/// Sets the owner.
			/// </summary>
			/// <param name="objItem">The item.</param>
			private void SetOwner(ObjectBoxParameter objItem)
			{
				objItem.SetOwner(this);
			}

			/// 
			/// Formats the value.
			/// </summary>
			/// <param name="objParameter">The obj parameter.</param>
			internal void FormatValue(ObjectBoxParameter objParameter)
			{
				if (objParameter.Value is GatewayReference gatewayReference)
				{
					objParameter.Value = gatewayReference.Handler;
				}
				if (objParameter.Value is GatewayHandler)
				{
					objParameter.Value = new GatewayReference(mobjObjectBox, objParameter.Name);
				}
			}

			/// 
			/// Validates the item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			private void ValidateItem(ObjectBoxParameter objItem)
			{
				if (objItem.Name == null)
				{
					string text = null;
					int num = 1;
					while (HasName(text = $"parameter{num}"))
					{
						num++;
					}
					objItem.Name = text;
				}
				else
				{
					ValidateName(objItem.Name);
				}
			}

			/// 
			/// Determines whether the specified value has name.
			/// </summary>
			/// <param name="strValue">The value.</param>
			/// 
			/// 	true</c> if the specified value has name; otherwise, false</c>.
			/// </returns>
			internal bool HasName(string strValue)
			{
				foreach (ObjectBoxParameter current in this)
				{
					if (current.Name == strValue)
					{
						return true;
					}
				}
				return false;
			}

			/// 
			/// Validates the name.
			/// </summary>
			/// <param name="strValue">The value.</param>
			internal void ValidateName(string strValue)
			{
				if (HasName(strValue))
				{
					throw new ArgumentException("Cannot insert duplicate names.");
				}
			}

			/// 
			/// Determines whether [contains] [the specified STR name].
			/// </summary>
			/// <param name="strName">Name of the STR.</param>
			/// 
			/// 	true</c> if [contains] [the specified STR name]; otherwise, false</c>.
			/// </returns>
			public bool Contains(string strName)
			{
				return HasName(strName);
			}

			/// 
			/// Removes the specified STR name.
			/// </summary>
			/// <param name="strName">Name of the STR.</param>
			public void Remove(string strName)
			{
				ObjectBoxParameter objectBoxParameter = null;
				foreach (ObjectBoxParameter current in this)
				{
					if (current.Name == strName)
					{
						objectBoxParameter = current;
						break;
					}
				}
				if (objectBoxParameter != null)
				{
					Remove(objectBoxParameter);
				}
			}
		}

		/// 
		/// object box parameter
		/// </summary>
		[Serializable]
		public class ObjectBoxParameter
		{
			/// 
			///
			/// </summary>
			private ObjectBoxParameterCollection mobjOwner = null;

			/// 
			///
			/// </summary>
			private object mobjValue = null;

			/// 
			///
			/// </summary>
			private string mstrName = null;

			/// 
			/// Gets or sets the name.
			/// </summary>
			/// The name.</value>
			public string Name
			{
				get
				{
					return mstrName;
				}
				set
				{
					if (mobjOwner != null)
					{
						mobjOwner.ValidateName(value);
					}
					mstrName = value;
				}
			}

			/// 
			/// Gets or sets the value.
			/// </summary>
			/// The value.</value>
			[DefaultValue(null)]
			[TypeConverter(typeof(StringConverter))]
			public object Value
			{
				get
				{
					return mobjValue;
				}
				set
				{
					mobjValue = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameter" /> class.
			/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ObjectBoxParameter()
			{
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameter" /> class.
			/// </summary>
			/// <param name="objOwner">The owner.</param>
			/// <param name="strName">Name.</param>
			/// <param name="objValue">The value.</param>
			internal ObjectBoxParameter(ObjectBoxParameterCollection objOwner, string strName, object objValue)
			{
				if (string.IsNullOrEmpty(strName))
				{
					throw new ArgumentNullException("strName", "Parameter name cannot be null.");
				}
				mobjOwner = objOwner;
				mobjValue = objValue;
				mstrName = strName;
			}

			/// 
			/// Sets the parent.
			/// </summary>
			/// <param name="objOwner">The owner.</param>
			internal void SetOwner(ObjectBoxParameterCollection objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
			/// </summary>
			/// 
			/// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
			/// </returns>
			public override string ToString()
			{
				return Name;
			}
		}

		/// 
		/// Provides a property reference to ObjectData property.
		/// </summary>
		private static SerializableProperty ObjectDataProperty = SerializableProperty.Register("ObjectData", typeof(string), typeof(ObjectBox));

		/// 
		/// Provides a property reference to ObjectType property.
		/// </summary>
		private static SerializableProperty ObjectTypeProperty = SerializableProperty.Register("ObjectType", typeof(string), typeof(ObjectBox));

		/// 
		/// Provides a property reference to Gateways property.
		/// </summary>
		private static SerializableProperty GatewaysProperty = SerializableProperty.Register("Gateways", typeof(Hashtable), typeof(ObjectBox));

		/// 
		/// Provides a property reference to Params property.
		/// </summary>
		private static SerializableProperty ParametersProperty = SerializableProperty.Register("Parameters", typeof(ObjectBoxParameterCollection), typeof(ObjectBox));

		/// 
		/// Gets the parameters hash.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatBehavior")]
		[Description("")]
		public ObjectBoxParameterCollection Parameters
		{
			get
			{
				ObjectBoxParameterCollection objectBoxParameterCollection = GetValue(ParametersProperty, null);
				if (objectBoxParameterCollection == null)
				{
					objectBoxParameterCollection = new ObjectBoxParameterCollection(this);
					SetValue(ParametersProperty, objectBoxParameterCollection);
				}
				return objectBoxParameterCollection;
			}
		}

		/// 
		/// Gets or sets the type of the object.
		/// </summary>
		/// The type of the object.</value>
		protected string ObjectType
		{
			get
			{
				return GetValue(ObjectTypeProperty, string.Empty);
			}
			set
			{
				if (ObjectType != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(ObjectTypeProperty);
					}
					else
					{
						SetValue(ObjectTypeProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the Data of the object.
		/// </summary>
		/// The Data of the object.</value>
		protected string ObjectData
		{
			get
			{
				return GetValue(ObjectDataProperty, string.Empty);
			}
			set
			{
				if (ObjectData != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(ObjectDataProperty);
					}
					else
					{
						SetValue(ObjectDataProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the type of the object plugins page.
		/// </summary>
		/// The type of the object plugins page.</value>
		protected string ObjectPluginsPageType
		{
			get
			{
				return (Parameters["pluginspagetype"] != null) ? Parameters["pluginspagetype"].ToString() : string.Empty;
			}
			set
			{
				Parameters["pluginspagetype"] = value;
			}
		}

		/// 
		/// Gets or sets the object class id.
		/// </summary>
		/// The object class id.</value>
		protected string ObjectClassId
		{
			get
			{
				return (Parameters["classid"] != null) ? Parameters["classid"].ToString() : string.Empty;
			}
			set
			{
				Parameters["classid"] = value;
			}
		}

		/// 
		/// Gets or sets the object code base.
		/// </summary>
		/// The object code base.</value>
		protected string ObjectCodeBase
		{
			get
			{
				return (Parameters["codebase"] != null) ? Parameters["codebase"].ToString() : string.Empty;
			}
			set
			{
				Parameters["codebase"] = value;
			}
		}

		/// 
		/// Gets or sets the stand by internal.
		/// </summary>
		/// The stand by internal.</value>
		protected string ObjectStandBy
		{
			get
			{
				return (Parameters["standby"] != null) ? Parameters["standby"].ToString() : string.Empty;
			}
			set
			{
				Parameters["standby"] = value;
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox" /> instance.
		/// </summary>
		public ObjectBox()
		{
		}

		/// 
		/// Adds the parameter.
		/// </summary>
		public void AddParameter(string strName, string strValue)
		{
			Parameters[strName] = strValue;
		}

		/// 
		/// Adds the parameter.
		/// </summary>
		public void AddParameter(string strName, GatewayHandler objHandler)
		{
			Parameters[strName] = objHandler;
		}

		/// 
		/// Adds the parameter.
		/// </summary>
		/// <param name="strName">Name of the STR.</param>
		/// <param name="objResourceHandle">The obj resource handle.</param>
		public void AddParameter(string strName, ResourceHandle objResourceHandle)
		{
			Parameters[strName] = objResourceHandle;
		}

		/// 
		/// Gets the parameter.
		/// </summary>
		public string GetParameter(string strName)
		{
			return Parameters[strName] as string;
		}

		/// 
		/// Removes the parameter.
		/// </summary>
		public void RemoveParameter(string strName)
		{
			if (Parameters.Contains(strName))
			{
				Parameters.Remove(strName);
			}
		}

		/// 
		/// Clears the parameters.
		/// </summary>
		public void ClearParameters()
		{
			Parameters.Clear();
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (ObjectType != string.Empty)
			{
				objWriter.WriteAttributeString("OT", ObjectType);
			}
			if (ObjectData != string.Empty)
			{
				objWriter.WriteAttributeString("DAT", ObjectData);
			}
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			base.Render(objContext, objWriter, lngRequestID);
			foreach (ObjectBoxParameter parameter in Parameters)
			{
				if (!string.IsNullOrEmpty(parameter.Name))
				{
					objWriter.WriteStartElement("P");
					objWriter.WriteAttributeString("N", parameter.Name);
					object value = parameter.Value;
					if (value == null)
					{
						objWriter.WriteAttributeString("VLB", string.Empty);
					}
					else
					{
						objWriter.WriteAttributeString("VLB", value.ToString());
					}
					objWriter.WriteEndElement();
				}
			}
		}

		/// 
		/// Processes the gateway request.
		/// </summary>
		/// <param name="objHostContext">The host context.</param>
		/// <param name="strAction">The action.</param>
		/// </returns>
		protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
		{
			if (Parameters[strAction] is GatewayReference { Handler: not null } gatewayReference)
			{
				return gatewayReference.Handler;
			}
			return null;
		}
	}
}
