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
	[ToolboxItem(false)]
	[Localizable(false)]
	[Designer("Gizmox.WebGUI.Common.Design.Skins.SkinDocumentDesigner, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", typeof(IRootDesigner))]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Skins.SkinCodeDomSerializer, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxBitmap(typeof(Skin))]
	public class Skin : SkinComponent, ICustomTypeDescriptor
	{
		private Y A;

		private string B;

		private Skin C;

		private ISkinable D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Dictionary<string, SkinResource> Resources => GetResourcesByType(typeof(FileResource), blnIncludeInherited: false);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Dictionary<string, SkinResource> ValueResources => GetResourcesByType(typeof(PB), blnIncludeInherited: false);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Dictionary<string, SkinResource> InheritedResources => GetResourcesByType(typeof(FileResource), blnIncludeInherited: true);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dictionary<string, SkinResource> ParentsValueResources
		{
			get
			{
				Dictionary<string, SkinResource> objResources = new Dictionary<string, SkinResource>(StringComparer.CurrentCultureIgnoreCase);
				if (base.Data == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Type typeFromHandle = typeof(PB);
					for (SkinData inheritedData = base.Data.InheritedData; inheritedData != null; inheritedData = inheritedData.InheritedData)
					{
						GetSkinDataResources(typeFromHandle, ref objResources, inheritedData, blnInheritedOnly: false);
					}
				}
				return objResources;
			}
		}

		internal Y ThemeData
		{
			get
			{
				if (!base.DesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (D is Theme)
					{
						return (Y)((Theme)D).Data;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				string text = null;
				if (D != null)
				{
					text = D.Theme;
				}
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (A == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!(B != text))
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_00d6;
					}
					Type themeType = ThemeType;
					if (!(themeType != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						A = (Y)DataStore.GetData(themeType);
					}
					B = text;
				}
				goto IL_00d6;
				IL_00d6:
				return A;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISkinable Owner => D;

		internal Type SkinType
		{
			get
			{
				if (!base.DesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Type designedType = base.DesignedType;
					if (!(designedType != null))
					{
						/*OpCode not supported: LdMemberToken*/;
						throw new SkinException("Could not resolve designed type. Try compiling the project.", null);
					}
					if (IsType(designedType, typeof(Skin)))
					{
						return designedType;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return GetType();
			}
		}

		private Type ThemeType
		{
			get
			{
				if (!base.DesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (D == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (!string.IsNullOrEmpty(D.Theme))
						{
							return SkinFactory.GetTheme(D.Theme);
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
				Type designedType = base.DesignedType;
				if (designedType != null)
				{
					if (IsType(designedType, typeof(Theme)))
					{
						return designedType;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return null;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetOwner(ISkinable objOwner)
		{
			D = objOwner;
		}

		internal override SkinData CreateData()
		{
			return DataStore.GetData(this);
		}

		internal override SkinDataStore CreateDataStore()
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				return SkinFactory.DataStore;
			}
			if (D != null)
			{
				return ((Theme)D).DataStore;
			}
			Type designedType = base.DesignedType;
			if (!(designedType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException("Could not load designed type. You must rebuild your project for the changes to show up in any open designers.");
			}
			C = Activator.CreateInstance(designedType) as Skin;
			if (C != null)
			{
				SkinDataStore skinDataStore = new SkinDataStore(Site, base.DesignedType);
				C.SetDataStore(skinDataStore);
				C.Site = Site;
				return skinDataStore;
			}
			throw new SkinException("Could create designer proxy for designed type.");
		}

		private Dictionary<string, SkinResource> GetResourcesByType(Type objRequiredResourceType, bool blnIncludeInherited)
		{
			Dictionary<string, SkinResource> objResources = new Dictionary<string, SkinResource>(StringComparer.CurrentCultureIgnoreCase);
			LoadResourcesFromThemeByType(ThemeData, objRequiredResourceType, objResources);
			SkinData data = base.Data;
			GetSkinDataResources(objRequiredResourceType, ref objResources, data, blnInheritedOnly: false);
			if (!blnIncludeInherited)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				for (data = data.InheritedData; data != null; data = data.InheritedData)
				{
					/*OpCode not supported: LdMemberToken*/;
					GetSkinDataResources(objRequiredResourceType, ref objResources, data, blnInheritedOnly: true);
				}
			}
			return objResources;
		}

		private static void GetSkinDataResources(Type objRequiredResourceType, ref Dictionary<string, SkinResource> objResources, SkinData objSkinData, bool blnInheritedOnly)
		{
			if (objSkinData == null)
			{
				return;
			}
			using Dictionary<string, SkinResource>.Enumerator enumerator = objSkinData.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				KeyValuePair<string, SkinResource> current = enumerator.Current;
				object value = current.Value;
				if (value == null)
				{
					continue;
				}
				Type type = value.GetType();
				bool flag = true;
				if (blnInheritedOnly)
				{
					PropertyInfo property = type.GetProperty("Inheritance");
					if (property != null)
					{
						object value2 = property.GetValue(value, new object[0]);
						if (value2 != null)
						{
							if (!(value2.ToString() != "Inherited"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag = false;
							}
						}
					}
				}
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(type == objRequiredResourceType) && !objRequiredResourceType.IsAssignableFrom(type))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (objResources.ContainsKey(current.Key))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objResources[current.Key] = current.Value;
				}
			}
		}

		private void LoadResourcesFromThemeByType(SkinData objThemeData, Type objResourceType, Dictionary<string, SkinResource> objResources)
		{
			if (objThemeData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string text = $"{SkinType.FullName}:";
			foreach (KeyValuePair<string, SkinResource> objThemeDatum in objThemeData)
			{
				Type type = objThemeDatum.Value.GetType();
				if (!(type == objResourceType) && !objResourceType.IsAssignableFrom(type))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (!objThemeDatum.Key.StartsWith(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				string key = objThemeDatum.Key.Substring(text.Length);
				if (!objResources.ContainsKey(key))
				{
					objResources[key] = objThemeDatum.Value;
				}
			}
			SkinData inheritedData = objThemeData.InheritedData;
			if (inheritedData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				LoadResourcesFromThemeByType(inheritedData, objResourceType, objResources);
			}
		}

		protected internal T GetValue<T>(string strKey, T objDefaultValue)
		{
			SkinResource resource = GetResource(strKey, CB.B);
			if (resource == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return objDefaultValue;
			}
			return resource.GetValue(objDefaultValue);
		}

		protected internal T GetAmbientValue<T>(string strKey, T objDefaultValue)
		{
			SkinResource resource = GetResource(strKey, CB.A);
			if (resource == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return objDefaultValue;
			}
			return resource.GetValue(objDefaultValue);
		}

		protected internal bool HasValue(string strKey)
		{
			return base.Data.HasValue(this, strKey, CB.B);
		}

		protected internal bool HasAmbientValue(string strKey)
		{
			return base.Data.HasValue(this, strKey, CB.A);
		}

		public int GetImageWidth(ImageResourceReference objImageResourceReference, int intDefault)
		{
			if (objImageResourceReference == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Size imageSize = GetImageSize(objImageResourceReference, Size.Empty);
				if (imageSize != Size.Empty)
				{
					return imageSize.Width;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return intDefault;
		}

		protected internal int GetImageWidth(ImageResourceReference objImageResourceReference)
		{
			return GetImageWidth(objImageResourceReference, 0);
		}

		public int GetImageHeight(ImageResourceReference objImageResourceReference, int intDefault)
		{
			if (objImageResourceReference != null)
			{
				Size imageSize = GetImageSize(objImageResourceReference, Size.Empty);
				if (imageSize != Size.Empty)
				{
					return imageSize.Height;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return intDefault;
		}

		protected internal int GetImageHeight(ImageResourceReference objImageResourceReference)
		{
			return GetImageHeight(objImageResourceReference, 0);
		}

		protected internal Size GetImageSize(ImageResourceReference objImageResourceReference, Size objDefault)
		{
			Skin skin = null;
			Type type = GetType();
			if (!(type.FullName == objImageResourceReference.ResourceNamespace))
			{
				/*OpCode not supported: LdMemberToken*/;
				type = SkinFactory.GetSkinTypeByResourceNamespace(objImageResourceReference.ResourceNamespace);
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!typeof(Skin).IsAssignableFrom(type))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					skin = Activator.CreateInstance(type) as Skin;
					if (skin == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						skin.SetOwner(D);
					}
				}
			}
			else
			{
				skin = this;
			}
			if (skin == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ImageResource value = skin.GetValue<ImageResource>(objImageResourceReference.ResourceName, null);
				if (value != null)
				{
					return new Size(value.Width, value.Height);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return objDefault;
		}

		protected internal int GetImageHeight(string strKey, int intDefault)
		{
			if (!(GetResource(strKey, CB.C) is ImageResource imageResource))
			{
				/*OpCode not supported: LdMemberToken*/;
				return intDefault;
			}
			return imageResource.Height;
		}

		private SkinResource GetResource(string strKey, CB enmSearchType)
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				return Z.GetResource(this, strKey, enmSearchType);
			}
			return base.Data.GetResource(this, strKey, enmSearchType);
		}

		protected internal int GetMaxImageHeight(int intDefault, params string[] strKeys)
		{
			int num = 0;
			foreach (string strKey in strKeys)
			{
				num = Math.Max(num, GetImageHeight(strKey, 0));
			}
			if (num == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return intDefault;
			}
			return num;
		}

		protected internal int GetImageWidth(string strKey, int intDefault)
		{
			if (!(GetResource(strKey, CB.C) is ImageResource imageResource))
			{
				/*OpCode not supported: LdMemberToken*/;
				return intDefault;
			}
			return imageResource.Width;
		}

		protected internal int GetMaxImageWidth(int intDefault, params string[] strKeys)
		{
			int num = 0;
			for (int i = 0; i < strKeys.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string strKey = strKeys[i];
				num = Math.Max(num, GetImageWidth(strKey, 0));
			}
			if (num != 0)
			{
				return num;
			}
			return intDefault;
		}

		internal string GetResourceName(SkinResource skinResource)
		{
			if (base.Data == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return base.Data.GetResourceName(this, skinResource);
		}

		internal void SetResourceName(SkinResource skinResource, string strName)
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new Exception("Only editable in design mode.");
			}
			if (base.Data == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				base.Data.SetResourceName(this, skinResource, strName);
			}
		}

		protected internal bool ShouldSerialize(string strKey)
		{
			if (!base.Data.ContainsKey(strKey))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (base.Data[strKey] != null)
				{
					return !IsInherited(base.Data[strKey]);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		protected internal void Reset(string strKey)
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			SkinResource resource = base.Data.GetResource(this, strKey, CB.C);
			if (resource != null)
			{
				Delete(resource);
			}
		}

		public string GetResourcePath(string strResourceName)
		{
			SkinData skinData = base.Data;
			if (skinData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Type skinType = skinData.SkinType;
				SkinResource resource = skinData.GetResource(skinType, ThemeData, strResourceName);
				while (true)
				{
					if (skinData == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					if (resource != null)
					{
						break;
					}
					skinData = skinData.InheritedData;
					if (skinData != null)
					{
						skinType = skinData.SkinType;
						resource = skinData.GetResource(skinType, ThemeData, strResourceName);
					}
				}
				if (resource != null)
				{
					return SkinFactory.GetSkinResourcePath(skinType, strResourceName);
				}
			}
			return string.Empty;
		}

		public ResourceHandle GetResourceHandle(string strResourceName)
		{
			return new SkinResourceHandle(this, strResourceName);
		}

		public ResourceHandle GetResourceHandleFromReference(SkinResourceReference objSkinResource)
		{
			if (objSkinResource != null)
			{
				if (!objSkinResource.IsEmpty)
				{
					return GetResourceHandle(objSkinResource.ResourceName);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Delete(SkinResource objSkinResource)
		{
			if (!base.DesignMode)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new Exception("Delete is available only in design time");
			}
			base.Data.RemoveResource(this, objSkinResource);
		}

		public bool RemoveOverridedValueResources()
		{
			List<object> overridedResourcesByType = GetOverridedResourcesByType(typeof(PB));
			using (List<object>.Enumerator enumerator = overridedResourcesByType.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					SkinResource objSkinResource = (SkinResource)enumerator.Current;
					Delete(objSkinResource);
				}
			}
			return overridedResourcesByType.Count > 0;
		}

		public List<object> GetOverridedFileResources()
		{
			return GetOverridedResourcesByType(typeof(FileResource));
		}

		private List<object> GetOverridedResourcesByType(Type objResourceType)
		{
			List<object> list = new List<object>();
			if (!(objResourceType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinData skinData = ThemeData;
				if (skinData != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					skinData = base.Data;
				}
				if (skinData == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					foreach (KeyValuePair<string, SkinResource> item in skinData)
					{
						if (item.Value == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (!base.Data.HasValue(this, base.Data.GetResourceName(this, item.Value), CB.C))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						Type type = item.Value.GetType();
						if (type == objResourceType)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!objResourceType.IsAssignableFrom(type))
						{
							continue;
						}
						list.Add(item.Value);
					}
				}
			}
			return list;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsInherited(SkinResource objSkinResource)
		{
			if (base.DesignMode)
			{
				if (!(Owner is Theme theme))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (theme.Data != null)
					{
						if (!theme.Data.ContainsValue(objSkinResource))
						{
							/*OpCode not supported: LdMemberToken*/;
							return true;
						}
						return false;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			if (base.Data == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return !base.Data.ContainsValue(objSkinResource);
		}

		public virtual PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection objPropertyDescriptorCollection, Attribute[] attributes)
		{
			return objPropertyDescriptorCollection;
		}

		System.ComponentModel.AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetAttributes(C, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetClassName(C, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetComponentName(C, noCustomTypeDesc: true);
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetConverter(C, noCustomTypeDesc: true);
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			if (C != null)
			{
				return TypeDescriptor.GetDefaultEvent(C, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetDefaultProperty(C, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetEditor(C, editorBaseType, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetEvents(C, attributes, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetEvents(C, noCustomTypeDesc: true);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = null;
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				propertyDescriptorCollection = TypeDescriptor.GetProperties(this, attributes, noCustomTypeDesc: true);
			}
			else
			{
				propertyDescriptorCollection = TypeDescriptor.GetProperties(C, attributes, noCustomTypeDesc: true);
			}
			return FilterProperties(propertyDescriptorCollection, attributes);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return TypeDescriptor.GetProperties(this, noCustomTypeDesc: true);
			}
			return TypeDescriptor.GetProperties(C, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return this;
			}
			return C;
		}
	}
}
