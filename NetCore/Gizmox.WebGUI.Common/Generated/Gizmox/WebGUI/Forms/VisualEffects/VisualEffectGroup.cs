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
	[Browsable(false)]
	public class VisualEffectGroup : VisualEffect
	{
		private VisualEffect[] marrVisualEffects;

		protected override VisualEffect[] VisualEffects => marrVisualEffects;

		public VisualEffectGroup()
		{
		}

		public VisualEffectGroup(params VisualEffect[] arrVisualEffects)
		{
			marrVisualEffects = arrVisualEffects;
			if (marrVisualEffects != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				marrVisualEffects = new VisualEffect[0];
			}
		}

		public override object[] GetConstroctorArguments()
		{
			return marrVisualEffects;
		}

		public override string ToString(IContext objContext)
		{
			return GetBeforeToString(objContext, blnIsInRenderMode: true);
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			return true;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
		}

		public override object Clone()
		{
			VisualEffectGroup visualEffectGroup = base.Clone() as VisualEffectGroup;
			CloneInternal(visualEffectGroup);
			return visualEffectGroup;
		}

		private void CloneInternal(VisualEffectGroup objNew)
		{
			if (marrVisualEffects == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			objNew.marrVisualEffects = new VisualEffect[marrVisualEffects.Length];
			for (int i = 0; i < marrVisualEffects.Length; i++)
			{
				objNew.marrVisualEffects[i] = (VisualEffect)marrVisualEffects[i].Clone();
			}
		}

		protected internal override void RenderOnDrawVisualEffectsAttribute(IContext objContext, IAttributeWriter objWriter, bool blnIsInRenderMode)
		{
			string text = GetBeforeToString(objContext, blnIsInRenderMode).TrimEnd();
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteAttributeString("ODVE", text);
			}
		}

		public override string GetBeforeToString(IContext objContext, bool blnIsInRenderMode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			StringBuilder stringBuilder4 = new StringBuilder();
			StringBuilder stringBuilder5 = new StringBuilder();
			StringBuilder stringBuilder6 = new StringBuilder();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
			VisualEffect[] array = marrVisualEffects;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				VisualEffect visualEffect = array[i];
				if (!visualEffect.IsSupported(objContext))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (!visualEffect.IsValid)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (!visualEffect.IsAggregated)
				{
					/*OpCode not supported: LdMemberToken*/;
					stringBuilder.Append(visualEffect.ToString(objContext));
					List<TransitionDescriptor> transitionDescriptorProperties = visualEffect.TransitionDescriptorProperties;
					List<TransitionDescriptor> list = new List<TransitionDescriptor>();
					using (List<TransitionDescriptor>.Enumerator enumerator = transitionDescriptorProperties.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							TransitionDescriptor current = enumerator.Current;
							if (dictionary.ContainsKey(current.PropertyName))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							dictionary.Add(current.PropertyName, null);
							list.Add(current);
						}
					}
					if (list.Count > 0)
					{
						visualEffect.GetBeforeToString(objContext, blnIsInRenderMode, list, stringBuilder2, stringBuilder3, stringBuilder4, stringBuilder5, stringBuilder6);
					}
					continue;
				}
				string[] attributes = visualEffect.Attributes;
				string[] values = visualEffect.Values;
				if (attributes.Length != values.Length)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				for (int j = 0; j < attributes.Length; j++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string key = attributes[j];
					if (dictionary2.TryGetValue(attributes[j], out var value))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						value = new List<string>();
						dictionary2.Add(key, value);
					}
					value.Add(values[j]);
				}
			}
			foreach (string key2 in dictionary2.Keys)
			{
				stringBuilder.Append(string.Format("{0}:{1};", key2, CommonUtils.Join(",", dictionary2[key2].ToArray())));
			}
			if (dictionary.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-property:{stringBuilder2.ToString()};");
				stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-duration:{stringBuilder3.ToString()};");
				stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-timing-function:{stringBuilder4.ToString()};");
				stringBuilder.Append($"{GetBasePropertyPrefixByContext(objContext)}transition-delay:{stringBuilder5.ToString()};");
				stringBuilder.Append(stringBuilder6.ToString());
			}
			return stringBuilder.ToString();
		}

		public override string GetAfterToString(IContext objContext, bool blnIsInRenderMode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			VisualEffect[] array = marrVisualEffects;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				VisualEffect visualEffect = array[i];
				if (!visualEffect.IsSupported(objContext))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				List<TransitionDescriptor> transitionDescriptorProperties = visualEffect.TransitionDescriptorProperties;
				List<TransitionDescriptor> list = new List<TransitionDescriptor>();
				using (List<TransitionDescriptor>.Enumerator enumerator = transitionDescriptorProperties.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						TransitionDescriptor current = enumerator.Current;
						if (!dictionary.ContainsKey(current.PropertyName))
						{
							/*OpCode not supported: LdMemberToken*/;
							dictionary.Add(current.PropertyName, null);
							list.Add(current);
						}
						else
						{
							dictionary[current.PropertyName] = null;
						}
					}
				}
				if (list.Count <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append(visualEffect.GetAfterToString(objContext, blnIsInRenderMode, list));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
