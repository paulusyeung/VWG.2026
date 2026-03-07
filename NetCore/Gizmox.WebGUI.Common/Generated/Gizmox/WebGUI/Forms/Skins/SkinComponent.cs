#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
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
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Forms.Skins
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ToolboxItem(false)]
	public class SkinComponent : Component, ICollection, IDictionary, IEnumerable
	{
		private Type E;

		private SkinData F;

		private SkinDataStore G;

		internal Type DesignedType
		{
			get
			{
				if (!base.DesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				if (E == null)
				{
					IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
					if (designerHost == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						IDesigner designer = designerHost.GetDesigner(designerHost.RootComponent);
						if (designer == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							ITypeResolutionService typeResolutionService = (ITypeResolutionService)((IServiceProvider)designer).GetService(typeof(ITypeResolutionService));
							if (typeResolutionService == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								Type type = typeResolutionService.GetType(designerHost.RootComponentClassName, throwOnError: false);
								if (!(type != null))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									E = type;
								}
							}
						}
					}
				}
				return E;
			}
		}

		internal SkinData Data
		{
			get
			{
				if (F == null)
				{
					F = CreateData();
				}
				return F;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLoaded => F != null;

		internal virtual SkinDataStore DataStore
		{
			get
			{
				if (G != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					G = CreateDataStore();
				}
				return G;
			}
		}

		internal IEnumerable DesignResourceReader
		{
			get
			{
				IResourceService resourceService = (IResourceService)GetService(typeof(IResourceService));
				if (resourceService != null)
				{
					IEnumerable resourceReader = resourceService.GetResourceReader(CultureInfo.InvariantCulture);
					if (resourceReader != null)
					{
						return resourceReader;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return null;
			}
		}

		internal bool DesignModeInternal => base.DesignMode;

		bool IDictionary.IsFixedSize => ((IDictionary)Data).IsFixedSize;

		bool IDictionary.IsReadOnly => ((IDictionary)Data).IsReadOnly;

		ICollection IDictionary.Keys => ((IDictionary)Data).Keys;

		ICollection IDictionary.Values => ((IDictionary)Data).Values;

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)Data)[key];
			}
			set
			{
				SetValue((string)key, value);
			}
		}

		int ICollection.Count => ((ICollection)Data).Count;

		bool ICollection.IsSynchronized => ((ICollection)Data).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)Data).SyncRoot;

		internal virtual SkinData CreateData()
		{
			return null;
		}

		internal void SetDataStore(SkinDataStore objDataStore)
		{
			G = objDataStore;
		}

		internal virtual SkinDataStore CreateDataStore()
		{
			return null;
		}

		protected internal void SetValue(string strKey, object objValue)
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException("Cannot set a skin value in runtime.", null);
			}
			Data.SetValue(this, strKey, objValue);
		}

		internal bool IsType(Type objTypeA, Type objTypeB)
		{
			if (objTypeA != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(objTypeA == typeof(object)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (objTypeA.FullName == objTypeB.FullName)
			{
				return true;
			}
			return IsType(objTypeA.BaseType, objTypeB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Type GetSkinType(string strName)
		{
			return SkinFactory.GetType(strName);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Type GetReousrceType(string strName)
		{
			return SkinFactory.GetType(strName, blnIsResources: true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Type GetResourceType(string strName)
		{
			return SkinFactory.GetType(strName, blnIsResources: true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool IsInherited(SkinResource objSkinResource)
		{
			return false;
		}

		void IDictionary.Add(object key, object value)
		{
			throw new NotImplementedException();
		}

		void IDictionary.Clear()
		{
			throw new NotImplementedException();
		}

		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)Data).Contains(key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)Data).GetEnumerator();
		}

		void IDictionary.Remove(object key)
		{
			((IDictionary)Data).Remove(key);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)Data).CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)Data).GetEnumerator();
		}
	}
}
