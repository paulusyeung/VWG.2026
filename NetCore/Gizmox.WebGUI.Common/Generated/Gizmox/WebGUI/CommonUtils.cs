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

namespace Gizmox.WebGUI
{
	[Serializable]
	public sealed class CommonUtils
	{
		private interface A
		{
			object DefaultValue { get; }
		}

		private class B<A> : CommonUtils.A
		{
			public object DefaultValue => default(A);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum GZipSupport
		{
			None,
			GZip,
			Defalate
		}

		private class C : IClientObject
		{
			private readonly string A;

			private readonly object B;

			string IClientObject.ID => A;

			object IClientObject.Object => B;

			public C(string strId, object objObject)
			{
				A = strId;
				B = objObject;
			}

			public override string ToString()
			{
				return B.ToString();
			}
		}

		private class D : IClientJsonObject
		{
			private object A;

			object IClientJsonObject.Object => A;

			public D(object objObject)
			{
				A = objObject;
			}
		}

		private static bool mblnMono;

		private static bool mblnUseServerCodeGen;

		private static object mobjUseServerCodeGenSemaphore;

		private static Dictionary<Type, object> mobjTypeDefaultValueCache;

		private static SecurityPermission? mobjSecurityPermission;

		private static Dictionary<string, XmlElement> mobjXmlElementByProviderKey;

		private static Dictionary<string, object> mobjCachedInstancesIndexByKey;

		private static object mobjProviderLock;

		public static bool IsDesignMode => VWGContext.Current == null;

		public static bool IsEnvironmentSecurityPermitted => IsPermissionGranted(mobjSecurityPermission);

		public static bool IsMono => mblnMono;

		private static Type DefaultRuntimeThemeType
		{
			get
			{
				string arg = "Gizmox.WebGUI.Forms.Themes, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
				return Type.GetType(string.Format("{0}, {1}", "Gizmox.WebGUI.Forms.Themes.Default", arg));
			}
		}

		internal static Type DefaultThemeType
		{
			get
			{
				if (!IsDesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
					return DefaultRuntimeThemeType;
				}
				return DefaultDesigntimeThemeType;
			}
		}

		private static Type DefaultDesigntimeThemeType
		{
			get
			{
				string arg = "Gizmox.WebGUI.Forms.Themes, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
				return Type.GetType(string.Format("{0}, {1}", "Gizmox.WebGUI.Forms.Themes.Vista", arg));
			}
		}

		public static string CodeGenDir
		{
			get
			{
				string result = string.Empty;
				if (!mblnUseServerCodeGen)
				{
					/*OpCode not supported: LdMemberToken*/;
					try
					{
						result = HostRuntime.CodegenDir;
					}
					catch (SecurityException)
					{
						object obj = mobjUseServerCodeGenSemaphore;
						bool lockTaken = false;
						try
						{
							Monitor.Enter(obj, ref lockTaken);
							mblnUseServerCodeGen = true;
						}
						finally
						{
							if (!lockTaken)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								Monitor.Exit(obj);
							}
						}
						result = CodeGenDir;
					}
				}
				else if (VWGContext.Current?.HttpContext != null)
				{
					result = VWGContext.Current?.HttpContext.Server.MapPath(string.Empty);
				}
				return result;
			}
		}

		static CommonUtils()
		{
			mblnMono = false;
			mblnUseServerCodeGen = false;
			mobjUseServerCodeGenSemaphore = new object();
			mobjTypeDefaultValueCache = new Dictionary<Type, object>();
			try { mobjSecurityPermission = new SecurityPermission(PermissionState.Unrestricted); } catch (PlatformNotSupportedException) { mobjSecurityPermission = null; }
			mobjXmlElementByProviderKey = new Dictionary<string, XmlElement>();
			mobjCachedInstancesIndexByKey = new Dictionary<string, object>();
			mobjProviderLock = string.Empty;
			try
			{
				if (!(Type.GetType("Mono.Runtime", throwOnError: false) != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mblnMono = true;
				}
			}
			catch
			{
			}
			LoadConfiguredProviders();
		}

		public static string GetBaseUrl(HostRequest objHostRequest)
		{
			string text = (text = objHostRequest.Url.Scheme + "://" + objHostRequest.Url.Authority);
			string[] segments = objHostRequest.Url.Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text2 = segments[i];
				if (text2 == "Route/")
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				text += text2;
			}
			return text;
		}

		public static bool IsPermissionGranted(IPermission? objPermission)
		{
			if (objPermission == null) return true;
			return true;
		}

		public static bool IsNullOrWhiteSpace(string strValue)
		{
			if (strValue == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				for (int i = 0; i < strValue.Length; i++)
				{
					if (char.IsWhiteSpace(strValue[i]))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					return false;
				}
			}
			return true;
		}

		public static bool TryParse<EnumType>(string strValue, out EnumType enmValue)
		{
			try
			{
				enmValue = (EnumType)Enum.Parse(typeof(EnumType), strValue);
				return true;
			}
			catch (Exception)
			{
				enmValue = default(EnumType);
				return false;
			}
		}

		public static T GetProvider<T>(string strDefaultType, bool blnIsCache, bool blnCanBeNull) where T : class
		{
			return GetProvider<T>(typeof(T).Name, strDefaultType, blnIsCache, blnCanBeNull);
		}

		public static T GetProvider<T>(string strDefaultType, bool blnIsCache) where T : class
		{
			return GetProvider<T>(typeof(T).Name, strDefaultType, blnIsCache, blnCanBeNull: false);
		}

		public static T GetProvider<T>(string strKey, string strDefaultType, bool blnIsCache) where T : class
		{
			return GetProvider<T>(strKey, strDefaultType, blnIsCache, blnCanBeNull: false);
		}

		public static T GetProvider<T>(string strKey, string strDefaultType, bool blnIsCache, bool blnCanBeNull) where T : class
		{
			object obj = mobjProviderLock;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (!blnIsCache)
				{
					return GetProvidedInstance<T>(strKey, strDefaultType, blnCanBeNull);
				}
				if (mobjCachedInstancesIndexByKey.ContainsKey(strKey))
				{
					/*OpCode not supported: LdMemberToken*/;
					return mobjCachedInstancesIndexByKey[strKey] as T;
				}
				object providedInstance = GetProvidedInstance<T>(strKey, strDefaultType, blnCanBeNull);
				if (providedInstance != null)
				{
					mobjCachedInstancesIndexByKey.Add(strKey, providedInstance);
					return providedInstance as T;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
			return null;
		}

		private static T GetProvidedInstance<T>(string strKey, string strDefaultType, bool blnCanBeNull) where T : class
		{
			XmlElement xmlElement = null;
			string strType = strDefaultType;
			object obj = mobjProviderLock;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (!mobjXmlElementByProviderKey.ContainsKey(strKey))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (string.IsNullOrEmpty(strDefaultType))
					{
						return null;
					}
					/*OpCode not supported: LdMemberToken*/;
					strType = strDefaultType;
				}
				else
				{
					xmlElement = mobjXmlElementByProviderKey[strKey];
					strType = xmlElement.Attributes["value"].Value;
				}
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
			return GetProvidedInstanceImpl<T>(strType, xmlElement, blnCanBeNull);
		}

		private static T GetProvidedInstanceImpl<T>(string strType, XmlElement objProviderXmlElement, bool blnCanBeNull) where T : class
		{
			T val = null;
			lock (mobjProviderLock)
			{
				if (!string.IsNullOrEmpty(strType))
				{
					Type type = Type.GetType(strType);
					if (!(type != null))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!blnCanBeNull)
						{
							throw new TypeLoadException("Could not load type: '" + strType + "'");
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						val = Activator.CreateInstance(type) as T;
						if (objProviderXmlElement != null)
						{
							if (!(objProviderXmlElement.SelectSingleNode("InitializeValues") is XmlElement xmlElement))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								IEnumerator enumerator = xmlElement.Attributes.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										/*OpCode not supported: LdMemberToken*/;
										XmlAttribute obj = (XmlAttribute)enumerator.Current;
										string name = obj.Name;
										string value = obj.Value;
										type.GetProperty(name).SetValue(val, value, null);
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										disposable.Dispose();
									}
								}
							}
						}
					}
				}
				if (val == null)
				{
					if (!blnCanBeNull)
					{
						throw new Exception("Could not instantiate type: '" + typeof(T).FullName + "'");
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return val;
		}

		private static void LoadConfiguredProviders()
		{
			XmlElement xmlElement = null;
			if (HostRuntime.Config == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			xmlElement = HostRuntime.Config.GetSection("Providers");
			if (xmlElement == null)
			{
				return;
			}
			IEnumerator enumerator = xmlElement.ChildNodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					XmlElement xmlElement2 = (XmlElement)enumerator.Current;
					if (!xmlElement2.HasAttribute("key"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!xmlElement2.HasAttribute("value"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjXmlElementByProviderKey.Add(xmlElement2.Attributes["key"].Value, xmlElement2);
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					disposable.Dispose();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string GetMimeType(ImageFormat enmImageFormat)
		{
			string empty = string.Empty;
			if (!enmImageFormat.Equals(ImageFormat.Gif))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!enmImageFormat.Equals(ImageFormat.Jpeg))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!enmImageFormat.Equals(ImageFormat.Png))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!enmImageFormat.Equals(ImageFormat.Tiff))
						{
							/*OpCode not supported: LdMemberToken*/;
							empty = ".bmp";
						}
						else
						{
							empty = ".tiff";
						}
					}
					else
					{
						empty = ".png";
					}
				}
				else
				{
					empty = ".jpg";
				}
			}
			else
			{
				empty = ".gif";
			}
			return GetMimeType(empty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string GetMimeType(string strFileName)
		{
			string result = string.Empty;
			if (string.IsNullOrEmpty(strFileName))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (strFileName.EndsWith("."))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int num = strFileName.LastIndexOf(".");
				if (num >= 0)
				{
					string text = strFileName.Substring(num + 1);
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.ToLowerInvariant();
						uint num2 = SC.ComputeStringHash(text2);
						if (num2 > 2599597124u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num2 > 3516816505u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 3777044822u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 > 4000954695u)
									{
										/*OpCode not supported: LdMemberToken*/;
										if (num2 <= 4081524352u)
										{
											if (num2 > 4044111267u)
											{
												/*OpCode not supported: LdMemberToken*/;
												switch (num2)
												{
												case 4051220518u:
													/*OpCode not supported: LdMemberToken*/;
													if (text2 == "cgm")
													{
														/*OpCode not supported: LdMemberToken*/;
														result = "image/cgm";
													}
													break;
												case 4072065277u:
													/*OpCode not supported: LdMemberToken*/;
													if (text2 == "hdf")
													{
														/*OpCode not supported: LdMemberToken*/;
														result = "application/x-hdf";
													}
													break;
												case 4081524352u:
													/*OpCode not supported: LdMemberToken*/;
													if (text2 == "css")
													{
														/*OpCode not supported: LdMemberToken*/;
														result = "text/css";
													}
													break;
												}
											}
											else
											{
												switch (num2)
												{
												case 4034509933u:
													/*OpCode not supported: LdMemberToken*/;
													if (text2 == "mpg")
													{
														/*OpCode not supported: LdMemberToken*/;
														result = "video/mpeg";
													}
													break;
												case 4044111267u:
													if (text2 == "t")
													{
														/*OpCode not supported: LdMemberToken*/;
														result = "application/x-troff";
													}
													break;
												}
											}
										}
										else if (num2 > 4137057182u)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (num2)
											{
											case 4165662710u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "cpt")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/mac-compactpro";
												}
												break;
											case 4239946832u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "ustar")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-ustar";
												}
												break;
											case 4259156035u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "qti")
												{
													result = "image/x-quicktime";
												}
												break;
											}
										}
										else
										{
											switch (num2)
											{
											case 4096714626u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "dvi")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-dvi";
												}
												break;
											case 4134359911u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "dmg")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/octet-stream";
												}
												break;
											case 4137057182u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "hqx")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/mac-binhex40";
												}
												break;
											}
										}
									}
									else if (num2 <= 3880226465u)
									{
										if (num2 > 3798807531u)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (num2)
											{
											case 3866916972u:
												if (text2 == "cdf")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-netcdf";
												}
												break;
											case 3816842171u:
												if (text2 == "msh")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "model/mesh";
												}
												break;
											case 3880226465u:
												if (text2 == "svg")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/svg+xml";
												}
												break;
											}
										}
										else
										{
											switch (num2)
											{
											case 3778722108u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "smi")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/smil";
												}
												break;
											case 3798807531u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "dms")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/octet-stream";
												}
												break;
											}
										}
									}
									else if (num2 > 3919773551u)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 3932734293u:
											if (text2 == "doc")
											{
												result = "application/msword";
											}
											break;
										case 3970106408u:
											if (text2 == "mac")
											{
												result = "image/x-macpaint";
											}
											break;
										case 4000954695u:
											if (text2 == "mpe")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "video/mpeg";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 3919773551u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "man")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-troff-man";
											}
											break;
										case 3915559316u:
											if (text2 == "dir")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-director";
											}
											break;
										case 3881856983u:
											if (text2 == "djv")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/vnd.djvu";
											}
											break;
										}
									}
								}
								else if (num2 > 3616587176u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 > 3680740438u)
									{
										/*OpCode not supported: LdMemberToken*/;
										if (num2 > 3745396908u)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (num2)
											{
											case 3762385774u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "spl")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-futuresplash";
												}
												break;
											case 3777044822u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "sgm")
												{
													result = "text/sgml";
												}
												break;
											case 3748772080u:
												if (text2 == "smil")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/smil";
												}
												break;
											}
										}
										else
										{
											switch (num2)
											{
											case 3704054358u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "jpe")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/jpeg";
												}
												break;
											case 3738156038u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "djvu")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/vnd.djvu";
												}
												break;
											case 3745396908u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "xslt")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/xslt+xml";
												}
												break;
											}
										}
									}
									else
									{
										switch (num2)
										{
										case 3664801462u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xml")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/xml";
											}
											break;
										case 3666081390u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xul")
											{
												result = "application/vnd.mozilla.xul+xml";
											}
											break;
										case 3670499120u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "jpg")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/jpeg";
											}
											break;
										case 3680740438u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xbm")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/x-xbitmap";
											}
											break;
										case 3660293037u:
											if (text2 == "skt")
											{
												result = "application/x-koan";
											}
											break;
										}
									}
								}
								else if (num2 > 3589384389u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 > 3599368272u)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 3614812112u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "html")
											{
												result = "text/html";
											}
											break;
										case 3615576550u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "pntg")
											{
												result = "image/x-macpaint";
											}
											break;
										case 3616587176u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xpm")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/x-xpixmap";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 3593182561u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "skp")
											{
												result = "application/x-koan";
											}
											break;
										case 3599368272u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xsl")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/xml";
											}
											break;
										}
									}
								}
								else
								{
									switch (num2)
									{
									case 3525437884u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "m4p")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "audio/mp4a-latm";
										}
										break;
									case 3543982537u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "src")
										{
											result = "application/x-wais-source";
										}
										break;
									case 3544038937u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "dxr")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-director";
										}
										break;
									case 3580006936u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "dif")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "video/x-dv";
										}
										break;
									case 3589384389u:
										if (text2 == "gtar")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-gtar";
										}
										break;
									}
								}
							}
							else if (num2 > 3240852562u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 3391851133u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 <= 3464455772u)
									{
										if (num2 > 3426548884u)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (num2)
											{
											case 3446624627u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "dll")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/octet-stream";
												}
												break;
											case 3462790959u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "mxu")
												{
													result = "video/vnd.mpegurl";
												}
												break;
											case 3464455772u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "xwd")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/x-xwindowdump";
												}
												break;
											}
										}
										else
										{
											switch (num2)
											{
											case 3404096181u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "texi")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-texinfo";
												}
												break;
											case 3426548884u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "ogg")
												{
													result = "application/ogg";
												}
												break;
											}
										}
									}
									else if (num2 > 3491882646u)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 3497863915u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "xht")
											{
												result = "application/xhtml+xml";
											}
											break;
										case 3511322342u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "dcr")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-director";
											}
											break;
										case 3516816505u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "mov")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "video/quicktime";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 3491882646u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "m4v")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "video/x-m4v";
											}
											break;
										case 3474957932u:
											if (text2 == "m3u")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "audio/x-mpegurl";
											}
											break;
										case 3475105027u:
											if (text2 == "m4u")
											{
												result = "video/vnd.mpegurl";
											}
											break;
										}
									}
								}
								else if (num2 <= 3298945248u)
								{
									if (num2 > 3273773599u)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 3280944101u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "mid")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "audio/midi";
											}
											break;
										case 3290551218u:
											if (text2 == "m4b")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "audio/mp4a-latm";
											}
											break;
										case 3298945248u:
											if (text2 == "xyz")
											{
												result = "chemical/x-xyz";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 3247388863u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "mif")
											{
												result = "application/vnd.mif";
											}
											break;
										case 3273773599u:
											if (text2 == "m4a")
											{
												result = "audio/mp4a-latm";
											}
											break;
										}
									}
								}
								else if (num2 > 3325034847u)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 3360267371u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "swf")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-shockwave-flash";
										}
										break;
									case 3368675903u:
										if (text2 == "qtif")
										{
											result = "image/x-quicktime";
										}
										break;
									case 3391851133u:
										if (text2 == "skd")
										{
											result = "application/x-koan";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 3308563891u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "dtd")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/xml-dtd";
										}
										break;
									case 3325034847u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "sit")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-stuffit";
										}
										break;
									case 3305831240u:
										if (text2 == "tif")
										{
											result = "image/tiff";
										}
										break;
									}
								}
							}
							else if (num2 > 2795148318u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 <= 2935200975u)
								{
									if (num2 > 2869024766u)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 2877453236u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "zip")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/zip";
											}
											break;
										case 2935200975u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "movie")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "video/x-sgi-movie";
											}
											break;
										case 2872970239u:
											if (text2 == "class")
											{
												result = "application/octet-stream";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 2869024766u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "tex")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-tex";
											}
											break;
										case 2834777980u:
											if (text2 == "tar")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-tar";
											}
											break;
										}
									}
								}
								else if (num2 > 3178397606u)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 3194656141u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "shar")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-shar";
										}
										break;
									case 3202323235u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "jpeg")
										{
											result = "image/jpeg";
										}
										break;
									case 3240852562u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "skm")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-koan";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 3178397606u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "xls")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/vnd.ms-excel";
										}
										break;
									case 2990581053u:
										if (text2 == "oda")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/oda";
										}
										break;
									case 3023287968u:
										if (text2 == "snd")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "audio/basic";
										}
										break;
									}
								}
							}
							else if (num2 > 2687244942u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 2703707726u)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 2769933170u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "tsv")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/tab-separated-values";
										}
										break;
									case 2771757551u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "txt")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/plain";
										}
										break;
									case 2795148318u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "gram")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/srgs";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 2701180604u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "mesh")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "model/mesh";
										}
										break;
									case 2703707726u:
										if (text2 == "sgml")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/sgml";
										}
										break;
									}
								}
							}
							else if (num2 > 2611152612u)
							{
								/*OpCode not supported: LdMemberToken*/;
								switch (num2)
								{
								case 2625189937u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "mp3")
									{
										result = "audio/mpeg";
									}
									break;
								case 2641967556u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "mp4")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "video/mp4";
									}
									break;
								case 2687244942u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "vcd")
									{
										result = "application/x-cdlink";
									}
									break;
								}
							}
							else
							{
								switch (num2)
								{
								case 2608412318u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "mp2")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "audio/mpeg";
									}
									break;
								case 2611152612u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "mpga")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "audio/mpeg";
									}
									break;
								}
							}
						}
						else if (num2 <= 1431300144)
						{
							if (num2 > 740235582)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 1154463311)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 <= 1241455715)
									{
										if (num2 > 1190725500)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (num2)
											{
											case 1195724803u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "tr")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "application/x-troff";
												}
												break;
											case 1241455715u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "ram")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "audio/x-pn-realaudio";
												}
												break;
											case 1207900477u:
												if (text2 == "ras")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/x-cmu-raster";
												}
												break;
											}
										}
										else
										{
											switch (num2)
											{
											case 1166738569u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "wbmp")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/vnd.wap.wbmp";
												}
												break;
											case 1190725500u:
												/*OpCode not supported: LdMemberToken*/;
												if (text2 == "rgb")
												{
													/*OpCode not supported: LdMemberToken*/;
													result = "image/x-rgb";
												}
												break;
											}
										}
									}
									else if (num2 > 1316961120)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 1397370877u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "jnlp")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-java-jnlp-file";
											}
											break;
										case 1416849756u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "wmlc")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/vnd.wap.wmlc";
											}
											break;
										case 1431300144u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "pct")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/pict";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 1260172255u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "dv")
											{
												result = "video/x-dv";
											}
											break;
										case 1293580398u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "ez")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/andrew-inset";
											}
											break;
										case 1316961120u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "ppm")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/x-portable-pixmap";
											}
											break;
										}
									}
								}
								else if (num2 <= 1060265211)
								{
									switch (num2)
									{
									case 913413841u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "lzh")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/octet-stream";
										}
										break;
									case 1023967768u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "vrml")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "model/vrml";
										}
										break;
									case 1024361338u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "roff")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-troff";
										}
										break;
									case 1060265211u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "aif")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "audio/x-aiff";
										}
										break;
									case 986687121u:
										if (text2 == "rtx")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/richtext";
										}
										break;
									}
								}
								else if (num2 > 1112675351)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 1143273375u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "ai")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/postscript";
										}
										break;
									case 1148407852u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "wmls")
										{
											result = "text/vnd.wap.wmlscript";
										}
										break;
									case 1154463311u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "rtf")
										{
											result = "text/rtf";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 1062342494u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "sh")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-sh";
										}
										break;
									case 1112675351u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "so")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/octet-stream";
										}
										break;
									}
								}
							}
							else if (num2 > 264745631)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 424135463)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 > 577951402)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 608758403u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "sv4cpio")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-sv4cpio";
											}
											break;
										case 620139359u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "rdf")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/rdf+xml";
											}
											break;
										case 740235582u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "texinfo")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-texinfo";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 476447045u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "avi")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "video/x-msvideo";
											}
											break;
										case 561783877u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "iges")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "model/iges";
											}
											break;
										case 577951402u:
											if (text2 == "asc")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "text/plain";
											}
											break;
										}
									}
								}
								else if (num2 > 333626681)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 340247368u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "aifc")
										{
											result = "audio/x-aiff";
										}
										break;
									case 370083565u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "grxml")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/srgs+xml";
										}
										break;
									case 424135463u:
										if (text2 == "aiff")
										{
											result = "audio/x-aiff";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 333626681u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "wav")
										{
											result = "audio/x-wav";
										}
										break;
									case 277310557u:
										if (text2 == "wmlsc")
										{
											result = "application/vnd.wap.wmlscriptc";
										}
										break;
									}
								}
							}
							else if (num2 > 155321749)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 231593560)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 239552769u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "csh")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-csh";
										}
										break;
									case 245745850u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "xhtml")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/xhtml+xml";
										}
										break;
									case 264745631u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "jp2")
										{
											result = "image/jp2";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 166542039u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "wml")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/vnd.wap.wml";
										}
										break;
									case 231593560u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "silo")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "model/mesh";
										}
										break;
									}
								}
							}
							else
							{
								switch (num2)
								{
								case 21171666u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "vxml")
									{
										result = "application/voicexml+xml";
									}
									break;
								case 57952472u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "atom")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "application/atom+xml";
									}
									break;
								case 126868124u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "htm")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "text/html";
									}
									break;
								case 129294112u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "wrl")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "model/vrml";
									}
									break;
								case 155321749u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "pict")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "image/pict";
									}
									break;
								}
							}
						}
						else if (num2 <= 1719319908)
						{
							if (num2 > 1549040540)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 1616151016)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (num2 > 1699594953)
									{
										/*OpCode not supported: LdMemberToken*/;
										switch (num2)
										{
										case 1704127225u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "eps")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/postscript";
											}
											break;
										case 1714084033u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "gif")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/gif";
											}
											break;
										case 1719319908u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "midi")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "audio/midi";
											}
											break;
										}
									}
									else
									{
										switch (num2)
										{
										case 1665852126u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "sv4crc")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "application/x-sv4crc";
											}
											break;
										case 1681978691u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "pic")
											{
												/*OpCode not supported: LdMemberToken*/;
												result = "image/pict";
											}
											break;
										case 1699594953u:
											/*OpCode not supported: LdMemberToken*/;
											if (text2 == "pdb")
											{
												result = "chemical/x-pdb";
											}
											break;
										}
									}
								}
								else
								{
									switch (num2)
									{
									case 1581212682u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "js")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/javascript";
										}
										break;
									case 1592540215u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "wbmxl")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/vnd.wap.wbxml";
										}
										break;
									case 1582198420u:
										if (text2 == "ps")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/postscript";
										}
										break;
									case 1616151016u:
										if (text2 == "rm")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/vnd.rn-realmedia";
										}
										break;
									case 1581869418u:
										if (text2 == "tiff")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "image/tiff";
										}
										break;
									}
								}
							}
							else if (num2 > 1480246043)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 1523243198)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 1530244645u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "pnt")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "image/x-macpaint";
										}
										break;
									case 1549040540u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "ra")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "audio/x-pn-realaudio";
										}
										break;
									case 1527457433u:
										if (text2 == "kar")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "audio/midi";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 1498364840u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "lha")
										{
											result = "application/octet-stream";
										}
										break;
									case 1523243198u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "bin")
										{
											result = "application/octet-stream";
										}
										break;
									}
								}
							}
							else if (num2 > 1446403350)
							{
								/*OpCode not supported: LdMemberToken*/;
								switch (num2)
								{
								case 1464607992u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "qt")
									{
										result = "video/quicktime";
									}
									break;
								case 1478825755u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "au")
									{
										result = "audio/basic";
									}
									break;
								case 1480246043u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "latex")
									{
										result = "application/x-latex";
									}
									break;
								}
							}
							else
							{
								switch (num2)
								{
								case 1445858897u:
									if (text2 == "ms")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "application/x-troff-ms";
									}
									break;
								case 1446403350u:
									if (text2 == "nc")
									{
										result = "application/x-netcdf";
									}
									break;
								}
							}
						}
						else if (num2 > 1917998190)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num2 > 2095122494)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num2 > 2430086494u)
								{
									/*OpCode not supported: LdMemberToken*/;
									switch (num2)
									{
									case 2468390302u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "mathml")
										{
											result = "application/mathml+xml";
										}
										break;
									case 2513577231u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "ief")
										{
											result = "image/ief";
										}
										break;
									case 2599597124u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "tcl")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "application/x-tcl";
										}
										break;
									}
								}
								else
								{
									switch (num2)
									{
									case 2296453922u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "ics")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "text/calendar";
										}
										break;
									case 2308861280u:
										/*OpCode not supported: LdMemberToken*/;
										if (text2 == "mpeg")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "video/mpeg";
										}
										break;
									case 2430086494u:
										if (text2 == "igs")
										{
											/*OpCode not supported: LdMemberToken*/;
											result = "model/iges";
										}
										break;
									}
								}
							}
							else if (num2 > 1927346304)
							{
								/*OpCode not supported: LdMemberToken*/;
								switch (num2)
								{
								case 1996294678u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "cpio")
									{
										result = "application/x-cpio";
									}
									break;
								case 2095122494u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "ico")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "image/x-icon";
									}
									break;
								case 2010498924u:
									if (text2 == "ifb")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "text/calendar";
									}
									break;
								}
							}
							else
							{
								switch (num2)
								{
								case 1922824652u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "etx")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "text/x-setext";
									}
									break;
								case 1927346304u:
									if (text2 == "ice")
									{
										result = "x-conference/x-cooltalk";
									}
									break;
								}
							}
						}
						else if (num2 > 1766705429)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num2 > 1866929858)
							{
								/*OpCode not supported: LdMemberToken*/;
								switch (num2)
								{
								case 1887561270u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "bcpio")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "application/x-bcpio";
									}
									break;
								case 1916129882u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "pnm")
									{
										result = "image/x-portable-anymap";
									}
									break;
								case 1917998190u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "pbm")
									{
										result = "image/x-portable-bitmap";
									}
									break;
								}
							}
							else
							{
								switch (num2)
								{
								case 1824651960u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "bmp")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "image/bmp";
									}
									break;
								case 1850152239u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "pgm")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "image/x-portable-graymap";
									}
									break;
								case 1866929858u:
									/*OpCode not supported: LdMemberToken*/;
									if (text2 == "pgn")
									{
										/*OpCode not supported: LdMemberToken*/;
										result = "application/x-chess-pgn";
									}
									break;
								}
							}
						}
						else if (num2 > 1738962391)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num2)
							{
							case 1747856039u:
								/*OpCode not supported: LdMemberToken*/;
								if (text2 == "me")
								{
									/*OpCode not supported: LdMemberToken*/;
									result = "application/x-troff-me";
								}
								break;
							case 1748353692u:
								/*OpCode not supported: LdMemberToken*/;
								if (text2 == "png")
								{
									result = "image/png";
								}
								break;
							case 1766705429u:
								/*OpCode not supported: LdMemberToken*/;
								if (text2 == "pdf")
								{
									/*OpCode not supported: LdMemberToken*/;
									result = "application/pdf";
								}
								break;
							}
						}
						else
						{
							switch (num2)
							{
							case 1736401595u:
								/*OpCode not supported: LdMemberToken*/;
								if (text2 == "ppt")
								{
									result = "application/vnd.ms-powerpoint";
								}
								break;
							case 1738962391u:
								/*OpCode not supported: LdMemberToken*/;
								if (text2 == "exe")
								{
									/*OpCode not supported: LdMemberToken*/;
									result = "application/octet-stream";
								}
								break;
							}
						}
					}
				}
			}
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Size GetStringMeasurements(string strText, Font objFont, int intWidth)
		{
			return GetStringMeasurements(strText, objFont, intWidth, Point.Empty, StringFormat.GenericDefault);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Size GetStringMeasurements(string strText, Font objFont, int intMaximumWidth, Point objUpperLeftPoint, StringFormat enmStringFormat)
		{
			Size result = Size.Empty;
			if (objFont == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Graphics measurementGraphics = GetMeasurementGraphics();
				if (measurementGraphics == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					SizeF empty = SizeF.Empty;
					empty = ((intMaximumWidth <= 0) ? measurementGraphics.MeasureString(strText, objFont, objUpperLeftPoint, enmStringFormat) : measurementGraphics.MeasureString(strText, objFont, intMaximumWidth, enmStringFormat));
					if (!(empty != SizeF.Empty))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = new Size(Convert.ToInt32(Math.Ceiling(empty.Width)), Convert.ToInt32(Math.Ceiling(empty.Height)));
					}
				}
			}
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Size GetStringMeasurements(string strText, Font objFont, bool blnIgnoreNewLines)
		{
			if (!blnIgnoreNewLines)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				strText = new Regex("\\r\\n").Replace(strText, "");
			}
			return GetStringMeasurements(strText, objFont);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Size GetStringMeasurements(string strText, Font objFont)
		{
			return GetStringMeasurements(strText, objFont, -1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Graphics GetMeasurementGraphics()
		{
			if (VWGContext.Current == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return ((IContextParams)VWGContext.Current).MeasurementGraphics;
		}

		public static void TrySerialize(object objValue)
		{
			if (objValue == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				binaryFormatter.Serialize(memoryStream, objValue);
			}
			catch (SerializationException)
			{
				throw;
			}
			finally
			{
				memoryStream.Close();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int GetFontHeight(Font objFont)
		{
			if (objFont == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 0;
			}
			Graphics measurementGraphics = GetMeasurementGraphics();
			if (measurementGraphics != null)
			{
				return (int)Math.Ceiling(objFont.GetHeight(measurementGraphics));
			}
			return objFont.Height;
		}

		public static string GetHtmlColor(Color objColor)
		{
			if (!objColor.IsEmpty)
			{
				string text = ColorTranslator.ToHtml(objColor);
				if (!string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					return text;
				}
				return GetWebColor(objColor);
			}
			return string.Empty;
		}

		public static string GetWebColor(Color objColor)
		{
			if (objColor.A != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return $"#{GetRGBColor(objColor)}";
			}
			return "transparent";
		}

		public static string GetRGBColor(Color objColor)
		{
			return objColor.R.ToString("X2", null) + objColor.G.ToString("X2", null) + objColor.B.ToString("X2", null);
		}

		public static bool IsNullOrEmpty(params string[] strInputs)
		{
			for (int i = 0; i < strInputs.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = strInputs[i];
				if (text == string.Empty || text == null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsTypeOrSubType(Type objCheckedType, Type objDesiredType)
		{
			if (!(objDesiredType == objCheckedType))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(objDesiredType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(objCheckedType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (objDesiredType.Equals(objCheckedType))
					{
						return true;
					}
					if (objCheckedType.IsSubclassOf(objDesiredType))
					{
						return true;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return false;
			}
			return true;
		}

		public static int GetCombinedHashCodes(params int[] args)
		{
			int num = -757577119;
			for (int i = 0; i < args.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				num = (args[i] ^ num) * -1640531535;
			}
			return num;
		}

		public static bool TryParse(string strValue, out float fltValue)
		{
			return float.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out fltValue);
		}

		public static bool TryParse(string strValue, out double dblValue)
		{
			return double.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out dblValue);
		}

		public static bool TryParse(string strValue, out int intValue)
		{
			return int.TryParse(strValue, out intValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string GetFullAssemblyName(string strAssembly)
		{
			uint num = SC.ComputeStringHash(strAssembly);
			if (num > 957307076)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 3016133270u)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 3659774578u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strAssembly == "mscorlib"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
					case 3680434065u:
						if (!(strAssembly == "Gizmox.WebGUI.Common"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return "Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
					case 3378336992u:
						if (!(strAssembly == "System.Web"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
					}
				}
				else
				{
					switch (num)
					{
					case 2402387132u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strAssembly == "System"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
					case 3016133270u:
						if (!(strAssembly == "System.Data"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
					case 2331618185u:
						if (!(strAssembly == "System.Core"))
						{
							break;
						}
						return "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
					}
				}
			}
			else
			{
				switch (num)
				{
				case 364241052u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strAssembly == "Gizmox.WebGUI.Emulation"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return "Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d";
				case 568413959u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strAssembly == "Gizmox.WebGUI.Forms"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return "Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d";
				case 665970248u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strAssembly == "System.Drawing"))
					{
						break;
					}
					return "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
				case 937460914u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strAssembly == "System.Windows.Forms"))
					{
						break;
					}
					return "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
				case 957307076u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strAssembly == "Gizmox.WebGUI.Emulation.Extensions"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return "Gizmox.WebGUI.Emulation.Extensions, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=a03cffd46f55fcd5";
				}
			}
			return strAssembly;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string GetFullTypeName(string strTypeName)
		{
			if (strTypeName == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			string[] array = strTypeName.Split(',');
			if (array.Length <= 2)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (array.Length != 2)
				{
					/*OpCode not supported: LdMemberToken*/;
					return strTypeName;
				}
				return array[0] + ", " + GetFullAssemblyName(array[1].Trim());
			}
			return strTypeName;
		}

		public static object GetTypeDefaultValue(Type objType)
		{
			object obj = null;
			if (!mobjTypeDefaultValueCache.ContainsKey(objType))
			{
				/*OpCode not supported: LdMemberToken*/;
				Dictionary<Type, object> obj2 = mobjTypeDefaultValueCache;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj2, ref lockTaken);
					if (mobjTypeDefaultValueCache.ContainsKey(objType))
					{
						obj = mobjTypeDefaultValueCache[objType];
					}
					else
					{
						Type type = typeof(B<>).MakeGenericType(objType);
						if (!(type != null))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!(Activator.CreateInstance(type) is A a))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							obj = a.DefaultValue;
							mobjTypeDefaultValueCache.Add(objType, obj);
						}
					}
				}
				finally
				{
					if (!lockTaken)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Monitor.Exit(obj2);
					}
				}
			}
			else
			{
				obj = mobjTypeDefaultValueCache[objType];
			}
			return obj;
		}

		public static string DecodeText(string strValue)
		{
			return Regex.Replace(strValue, "(\\\\s)|(\\\\t)|(\\\\n)|(\\\\r)|(\\\\b)|(\\\\\\\\)", DecodeMatch, RegexOptions.Multiline);
		}

		private static string DecodeMatch(Match strMatch)
		{
			switch (strMatch.Value)
			{
			case "\\b":
				/*OpCode not supported: LdMemberToken*/;
				return " ";
			case "\\t":
				/*OpCode not supported: LdMemberToken*/;
				return "\t";
			case "\\n":
				/*OpCode not supported: LdMemberToken*/;
				return Environment.NewLine;
			case "\\r":
				return "";
			case "\\\\":
				return "\\";
			default:
				return strMatch.Value;
			}
		}

		public static Type[] GetToolboxItemTypes(string strAssembly)
		{
			Assembly assembly = null;
			try
			{
				assembly = Assembly.Load(strAssembly);
			}
			catch (FileNotFoundException)
			{
			}
			catch (FileLoadException)
			{
			}
			if (!(assembly != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				return new Type[0];
			}
			ArrayList arrayList = new ArrayList();
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (IsValidVWGConponent(type))
				{
					arrayList.Add(type);
				}
			}
			return (Type[])arrayList.ToArray(typeof(Type));
		}

		public static bool IsValidVWGConponent(Type objType)
		{
			if (objType.IsInterface)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(objType != typeof(RegisteredComponent)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (IsInterface(objType, typeof(IRegisteredComponent)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (objType.IsSubclassOf(typeof(ComponentBase)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!objType.IsSubclassOf(typeof(Component)) && !objType.IsSubclassOf(typeof(Control)))
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00cc;
				}
				if (!IsInterface(objType, typeof(IUserControl)))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			goto IL_00cc;
			IL_00cc:
			return false;
		}

		public static Type[] GetCommonToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6");
		}

		public static Type[] GetFormToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d");
		}

		public static Type[] GetOfficeToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Forms.Office, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=d50c2c7452ba77d9");
		}

		public static Type[] GetChartsToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Forms.Charts, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=f1bb83df6a8597fb");
		}

		public static Type[] GetExtendedToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Forms.Extended, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=85eae29607c9f5f3");
		}

		public static Type[] GetReportingToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Reporting, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ff9cb9557af1f587");
		}

		public static Type[] GetProfessionalToolboxItemTypes()
		{
			return GetToolboxItemTypes("Gizmox.WebGUI.Forms.Professional, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=6b5c571512bede7c");
		}

		private static bool IsInterface(Type objType, Type objInterface)
		{
			Type[] interfaces = objType.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(interfaces[i] == objInterface))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return true;
			}
			return false;
		}

		public static string Join(string strSeperator, params object[] values)
		{
			return string.Join(strSeperator, values);
		}

		public static Image GetToolboxImageFromControlType(Type objControlType)
		{
			if (!(objControlType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(GetCustomAttribute(objControlType, typeof(ToolboxBitmapAttribute), blnInherit: true) is ToolboxBitmapAttribute toolboxBitmapAttribute))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Image image = toolboxBitmapAttribute.GetImage(objControlType, large: false);
				if (image != null)
				{
					return image;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		public static object GetCustomAttribute(Type objControlType, Type objAttributeType, bool blnInherit)
		{
			if (!(objControlType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(objAttributeType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object[] customAttributes = objControlType.GetCustomAttributes(objAttributeType, blnInherit);
				if (customAttributes.Length != 0)
				{
					return customAttributes[0];
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static GZipSupport GetGZipSupport(HostContext objHostContext)
		{
			return GetGZipSupport(objHostContext.Request);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static GZipSupport GetGZipSupport(IContext objContext)
		{
			return GetGZipSupport(objContext.HostContext);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static GZipSupport GetGZipSupport(HostRequest objHostRequest)
		{
			string text = objHostRequest.Headers["Accept-Encoding"];
			if (IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (text.IndexOf("gzip") >= 0)
				{
					return GZipSupport.GZip;
				}
				if (text.IndexOf("deflate") >= 0)
				{
					return GZipSupport.Defalate;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return GZipSupport.None;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void WriteGZipHeaders(HostResponse objHostResponse, GZipSupport enmGZipSupport)
		{
			if (enmGZipSupport != GZipSupport.GZip)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (enmGZipSupport != GZipSupport.Defalate)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objHostResponse.AppendHeader("Content-Encoding", "deflate");
				}
			}
			else
			{
				objHostResponse.AppendHeader("Content-Encoding", "gzip");
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PrepareResponseForGZip(HostContext objHostContext)
		{
			PrepareResponseForGZip(objHostContext.Response, GetGZipSupport(objHostContext));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PrepareResponseForGZip(HostResponse objHostResponse, GZipSupport enmGZipSupport)
		{
			if (enmGZipSupport == GZipSupport.None)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			WriteGZipHeaders(objHostResponse, enmGZipSupport);
			ApplyGZipFilter(objHostResponse, enmGZipSupport);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ApplyGZipFilter(HostResponse objHostResponse, GZipSupport enmGZipSupport)
		{
			if (enmGZipSupport == GZipSupport.None)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objHostResponse.Filter = GetGZipStreamWriter(objHostResponse.Filter, enmGZipSupport);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Stream GetGZipStreamWriter(Stream objOutputStream, GZipSupport enmGZipSupport)
		{
			switch (enmGZipSupport)
			{
			case GZipSupport.GZip:
				return new GZipStream(objOutputStream, CompressionMode.Compress);
			default:
				/*OpCode not supported: LdMemberToken*/;
				return objOutputStream;
			case GZipSupport.Defalate:
				return new DeflateStream(objOutputStream, CompressionMode.Compress);
			}
		}

		public static IClientObject GetClientObject(string strId, object objObject)
		{
			if (objObject == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new C(strId, objObject);
		}

		public static IClientJsonObject GetClientJsonObject(object objObject)
		{
			return new D(objObject);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string GetClientKeyCode()
		{
			return (VWGContext.Current?.HttpContext ?? throw new Exception("Valid Http Context required")).Request.Browser.Id;
		}

		public static string Encrypt(string strPlainText, string strEncryptionSaltKey, string strEncryptionVIKey, string strEncryptionPasswordHash)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(strPlainText);
			byte[] bytes2 = new Rfc2898DeriveBytes(strEncryptionPasswordHash, Encoding.ASCII.GetBytes(strEncryptionSaltKey)).GetBytes(32);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.Zeros
			}.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(strEncryptionVIKey));
			MemoryStream memoryStream = new MemoryStream();
			byte[] inArray;
			try
			{
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				try
				{
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					inArray = memoryStream.ToArray();
					cryptoStream.Close();
				}
				finally
				{
					if (cryptoStream == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						((IDisposable)cryptoStream).Dispose();
					}
				}
				memoryStream.Close();
			}
			finally
			{
				if (memoryStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
			return Convert.ToBase64String(inArray);
		}

		public static string Decrypt(string strEncryptedText, string strEncryptionSaltKey, string strEncryptionVIKey, string strEncryptionPasswordHash)
		{
			try
			{
				byte[] array = Convert.FromBase64String(strEncryptedText);
				byte[] bytes = new Rfc2898DeriveBytes(strEncryptionPasswordHash, Encoding.ASCII.GetBytes(strEncryptionSaltKey)).GetBytes(32);
				ICryptoTransform transform = new RijndaelManaged
				{
					Mode = CipherMode.CBC,
					Padding = PaddingMode.None
				}.CreateDecryptor(bytes, Encoding.ASCII.GetBytes(strEncryptionVIKey));
				MemoryStream memoryStream = new MemoryStream(array);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
				byte[] array2 = new byte[array.Length];
				int count = cryptoStream.Read(array2, 0, array2.Length);
				memoryStream.Close();
				cryptoStream.Close();
				return Encoding.UTF8.GetString(array2, 0, count).TrimEnd("\0".ToCharArray());
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
	}
}
