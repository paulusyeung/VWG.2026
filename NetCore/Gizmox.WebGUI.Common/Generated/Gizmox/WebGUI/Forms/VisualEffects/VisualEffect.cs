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

namespace Gizmox.WebGUI.Forms.VisualEffects
{
	[Serializable]
	[TypeConverter(typeof(VisualEffectTypeConverter))]
	public abstract class VisualEffect : IEnumerable<VisualEffect>, IEnumerable, ICustomTypeDescriptor, ICloneable
	{
		private List<TransitionDescriptor> marrTransitionDescriptors;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string VisualEffectParam
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Browsable(false)]
		protected virtual VisualEffect[] VisualEffects => new VisualEffect[1] { this };

		protected internal virtual bool IsValid => true;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool IsAggregated => false;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual string[] Attributes => null;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string[] Values => null;

		internal List<TransitionDescriptor> TransitionDescriptorProperties
		{
			get
			{
				if (marrTransitionDescriptors != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					marrTransitionDescriptors = new List<TransitionDescriptor>();
					PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);
					for (int i = 0; i < properties.Length; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						PropertyInfo propertyInfo = properties[i];
						if (!(propertyInfo.PropertyType == typeof(TransitionDescriptor)))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!(propertyInfo.GetValue(this, null) is TransitionDescriptor item))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							marrTransitionDescriptors.Add(item);
						}
					}
				}
				return marrTransitionDescriptors;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract object[] GetConstroctorArguments();

		public abstract string ToString(IContext objContext);

		protected internal abstract void InitializeFromString(string strVisualEffect);

		protected internal abstract bool IsSupported(IContext objContext);

		IEnumerator IEnumerable.GetEnumerator()
		{
			return VisualEffects.GetEnumerator();
		}

		internal virtual void RenderVisualEffectAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			RenderOnDrawVisualEffectsAttribute(objContext, objWriter, blnIsInRenderMode: true);
			RenderAfterDrawVisualEffectsAttribute(objContext, objWriter, blnIsInRenderMode: true);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj != this)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(GetType() != obj.GetType()))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(obj is VisualEffectGroup))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (VisualEffects.Length != ((VisualEffect)obj).VisualEffects.Length)
						{
							return false;
						}
						for (int i = 0; i < VisualEffects.Length; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!(((VisualEffect)obj).VisualEffects[i].ToString() != VisualEffects[i].ToString()))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							return false;
						}
					}
					if (!(obj is VisualEffect))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (((VisualEffect)obj).VisualEffects[0].ToString() != VisualEffects[0].ToString())
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		protected internal virtual void RenderAfterDrawVisualEffectsAttribute(IContext objContext, IAttributeWriter objWriter, bool blnIsInRenderMode)
		{
			string text = GetAfterToString(objContext, blnIsInRenderMode).TrimEnd();
			if (!string.IsNullOrEmpty(text))
			{
				objWriter.WriteAttributeString("ADVE", text);
			}
		}

		protected internal virtual List<Type> GetConstructorTypes()
		{
			return null;
		}

		public virtual string GetBeforeToString(IContext objContext, bool blnIsInRenderMode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!IsSupported(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				StringBuilder stringBuilder3 = new StringBuilder();
				StringBuilder stringBuilder4 = new StringBuilder();
				StringBuilder stringBuilder5 = new StringBuilder();
				StringBuilder stringBuilder6 = new StringBuilder();
				List<TransitionDescriptor> transitionDescriptorProperties = TransitionDescriptorProperties;
				if (transitionDescriptorProperties.Count > 0)
				{
					GetBeforeToString(objContext, blnIsInRenderMode, transitionDescriptorProperties, stringBuilder2, stringBuilder3, stringBuilder4, stringBuilder5, stringBuilder6);
					if (!string.IsNullOrEmpty(stringBuilder2.ToString()))
					{
						stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-property:{stringBuilder2.ToString()};");
						stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-duration:{stringBuilder3.ToString()};");
						stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-timing-function:{stringBuilder4.ToString()};");
						stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-delay:{stringBuilder5.ToString()};");
					}
					stringBuilder.Append(stringBuilder6.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		internal void GetBeforeToString(IContext objContext, bool blnIsInRenderMode, List<TransitionDescriptor> arrTransitionDescriptors, StringBuilder objProperties, StringBuilder objDurations, StringBuilder objTimingFunction, StringBuilder objDelays, StringBuilder objBaseValues)
		{
			using List<TransitionDescriptor>.Enumerator enumerator = arrTransitionDescriptors.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				TransitionDescriptor current = enumerator.Current;
				if (!blnIsInRenderMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (current.IsRenderOnce && (!blnIsInRenderMode || !current.IsRenderOnce || current.IsRendered))
				{
					string propertyNameByContext = GetPropertyNameByContext(current.PropertyName, objContext);
					if (string.IsNullOrEmpty(current.TransitionedValue))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						objBaseValues.Append($"{propertyNameByContext}:{string.Format(current.ValuePattern, current.TransitionedValue)};");
					}
					continue;
				}
				string propertyNameByContext2 = GetPropertyNameByContext(current.PropertyName, objContext);
				if (objProperties.Length <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objDurations.Append(",");
					objTimingFunction.Append(",");
					objDelays.Append(",");
					objProperties.Append(",");
				}
				objProperties.Append(propertyNameByContext2);
				objDurations.Append(string.Format(current.DelayPattern, current.Duration));
				objTimingFunction.Append(current.GetTimingFunctionName());
				objDelays.Append(string.Format(current.DelayPattern, current.Delay));
				if (string.IsNullOrEmpty(current.BaseValue))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objBaseValues.Append($"{propertyNameByContext2}:{string.Format(current.ValuePattern, current.BaseValue)};");
				}
			}
		}

		public virtual string GetAfterToString(IContext objContext, bool blnIsInRenderMode)
		{
			List<TransitionDescriptor> transitionDescriptorProperties = TransitionDescriptorProperties;
			if (transitionDescriptorProperties.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return GetAfterToString(objContext, blnIsInRenderMode, transitionDescriptorProperties);
		}

		internal string GetAfterToString(IContext objContext, bool blnIsInRenderMode, List<TransitionDescriptor> arrTransitionDescriptors)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsSupported(objContext))
			{
				decimal num = default(decimal);
				bool flag = false;
				using (List<TransitionDescriptor>.Enumerator enumerator = arrTransitionDescriptors.GetEnumerator())
				{
					TransitionDescriptor current;
					for (; enumerator.MoveNext(); current.IsRendered = true)
					{
						/*OpCode not supported: LdMemberToken*/;
						current = enumerator.Current;
						if (!blnIsInRenderMode)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!current.IsRenderOnce)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (!blnIsInRenderMode)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (!current.IsRenderOnce)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (current.IsRendered)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
						}
						string propertyNameByContext = GetPropertyNameByContext(current.PropertyName, objContext);
						stringBuilder.Append($"{propertyNameByContext}:{string.Format(current.ValuePattern, current.TransitionedValue)};");
						if (current.Delay + current.Duration > num)
						{
							num = current.Delay + current.Duration;
						}
						flag = true;
					}
				}
				if (flag)
				{
					stringBuilder.Append($"{WGLabels.TransitionTotalTime}:{num};");
				}
			}
			return stringBuilder.ToString();
		}

		protected virtual string GetPropertyNameByContext(string strPropertyName, IContext objContext)
		{
			return strPropertyName;
		}

		internal virtual string GetBasePropertyPrefixByContext(IContext objContext)
		{
			string result = "";
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				switch (contextParams.Browser.ToLower())
				{
				case "ie":
					/*OpCode not supported: LdMemberToken*/;
					result = "-ms-";
					break;
				case "kit":
					/*OpCode not supported: LdMemberToken*/;
					result = "-webkit-";
					break;
				case "moz":
					/*OpCode not supported: LdMemberToken*/;
					result = "-moz-";
					break;
				case "opr":
					/*OpCode not supported: LdMemberToken*/;
					result = "-o-";
					break;
				}
			}
			return result;
		}

		protected internal virtual void RenderOnDrawVisualEffectsAttribute(IContext objContext, IAttributeWriter objWriter, bool blnIsInRenderMode)
		{
			string text = GetBeforeToString(objContext, blnIsInRenderMode);
			if (!IsSupported(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!IsValid)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text += ToString(objContext).TrimEnd();
			}
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteAttributeString("ODVE", text);
			}
		}

		IEnumerator<VisualEffect> IEnumerable<VisualEffect>.GetEnumerator()
		{
			return ((IEnumerable<VisualEffect>)VisualEffects).GetEnumerator();
		}

		System.ComponentModel.AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return GetCustomProperties(attributes);
		}

		private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, attributes, noCustomTypeDesc: true);
			List<PropertyDescriptor> list = new List<PropertyDescriptor>();
			IEnumerator enumerator = properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					PropertyDescriptor propertyDescriptor = (PropertyDescriptor)enumerator.Current;
					bool flag = true;
					if (!(propertyDescriptor.Attributes[typeof(BrowsableAttribute)] is BrowsableAttribute browsableAttribute))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						flag = browsableAttribute.Browsable;
					}
					if (!flag)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add(propertyDescriptor);
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
			return new PropertyDescriptorCollection(list.ToArray());
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return GetCustomProperties(null);
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		public virtual object Clone()
		{
			VisualEffect visualEffect = (VisualEffect)Activator.CreateInstance(GetType());
			CloneInternal(visualEffect);
			return visualEffect;
		}

		private void CloneInternal(VisualEffect objNew)
		{
			if (marrTransitionDescriptors == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			objNew.marrTransitionDescriptors = new List<TransitionDescriptor>(marrTransitionDescriptors.Count);
			foreach (TransitionDescriptor marrTransitionDescriptor in marrTransitionDescriptors)
			{
				TransitionDescriptor item = (TransitionDescriptor)marrTransitionDescriptor.Clone();
				objNew.marrTransitionDescriptors.Add(item);
			}
		}
	}
}
