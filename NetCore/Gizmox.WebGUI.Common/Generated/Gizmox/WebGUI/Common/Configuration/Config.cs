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

namespace Gizmox.WebGUI.Common.Configuration
{
	[Serializable]
	public class Config
	{
		[CompilerGenerated]
		private sealed class OC
		{
			public string A;

			internal bool RemoveIncludes_Helper0(Include objInclude)
			{
				return objInclude.IncludeName == A;
			}
		}

		private AdministrationConfigurationInfo mobjAdministration;

		private XmlElement mobjSection;

		private Dictionary<string, object> mobjProperties;

		private Dictionary<string, Type> mobjThemes;

		private List<string> marrAvailableThemes;

		private List<Type> mobjVisualTemplateTypesList;

		private List<DrawingEngine> mobjPresentationDrawingEngines;

		private List<Include> mobjIncludedStyleSheets;

		private static object mobjThemesSemaphore;

		private static object mobjVisualTemplateTypesSemaphore;

		private static object mobjDefaultThemeSemaphore;

		private List<Type> mobjActionTypes;

		private static object mobjActionTypesSemaphore;

		private string mstrDynamicExtension = ".wgx";

		private string mstrPrivateVersion = "";

		private static Config mobjConfigInstance;

		private static Dictionary<string, string> mobjSystemApplicationsIndexByPageName;

		private string mstrDefaultFactory = "";

		private bool mblnRightToLeft;

		private string mstrRootDirectory = "";

		private string mstrApplicationsMetaData = string.Empty;

		private string mstrDefaultTheme;

		private string mstrTimeFormat;

		private string mstrShortDateFormat;

		private string mstrLongDateFormat;

		private bool mblnInlineWindows;

		private bool mblnVerifyBrowserSupport = true;

		private bool mblnForcePageInstance;

		private bool mblnAspCompatMode;

		private bool mblnGZipCompression;

		private bool mblnAnimationEnabled;

		private bool mblnPreserveFocusElement = true;

		private bool mblnAccessibilityMode;

		private List<Type> mobjRegisteredComponents;

		private object mobjRegisteredComponentsLock = new object();

		private List<string> marrPreloadedResources;

		private object mobjPreloadedResourcesLock = new object();

		private static object mobjLockGetInstance;

		private bool mblnFormsSecurityEnabled;

		private bool mblnEnableAutomationIds;

		private Type[] marrEMSToolBoxTypes;

		[NonSerialized]
		private NC A;

		private Dictionary<string, bool> mobjWinFormsCompatibilityOptions = new Dictionary<string, bool>();

		internal List<DrawingEngine> PresentationDrawingEngines
		{
			get
			{
				if (mobjPresentationDrawingEngines != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjPresentationDrawingEngines = GetPresentationDrawingEngines();
				}
				return mobjPresentationDrawingEngines;
			}
		}

		private object this[string strPropertyKey]
		{
			get
			{
				object value = null;
				mobjProperties.TryGetValue(strPropertyKey, out value);
				return value;
			}
			set
			{
				mobjProperties[strPropertyKey] = value;
			}
		}

		private NC ResourceProvider
		{
			get
			{
				if (A == null)
				{
					A = new NC();
				}
				return A;
			}
		}

		public Type[] EMSToolBoxTypes => marrEMSToolBoxTypes;

		public bool FormsSecurityEnabled => mblnFormsSecurityEnabled;

		public bool EnableAutomationIds => mblnEnableAutomationIds;

		public string ApplicationName => HostRuntime.Config.GetFeatureValue("ApplicationName", "Visual WebGui");

		public AdministrationConfigurationInfo Administration
		{
			get
			{
				if (mobjAdministration == null)
				{
					mobjAdministration = new AdministrationConfigurationInfo(GetSection("Administration"));
				}
				return mobjAdministration;
			}
		}

		public bool ApplySelectedThemeInDesignTime => IsFeatureEnabled("ApplySelectedThemeInDesignTime", false);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseAuthentication => (bool)this["Authentication.UseAuthentication"];

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string DefaultLongDateFormat => mstrLongDateFormat;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string DefaultTimeFormat => mstrTimeFormat;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string DefaultShortDateFormat => mstrShortDateFormat;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AspCompatMode => mblnAspCompatMode;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AccessibilityMode => mblnAccessibilityMode;

		public Dictionary<string, Type> ApplicationsTypes
		{
			get
			{
				Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
				IEnumerator enumerator = mobjSection.SelectNodes("Applications/Application").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						XmlElement obj = (XmlElement)enumerator.Current;
						string attribute = obj.GetAttribute("Code");
						string attribute2 = obj.GetAttribute("Type");
						if (string.IsNullOrEmpty(attribute))
						{
							continue;
						}
						if (string.IsNullOrEmpty(attribute2))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (dictionary.ContainsKey(attribute))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						Type type = Type.GetType(attribute2, throwOnError: false);
						if (type != null)
						{
							dictionary.Add(attribute, type);
						}
					}
					return dictionary;
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

		public Dictionary<string, Type> AuthenticationsTypes
		{
			get
			{
				Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
				IEnumerator enumerator = mobjSection.SelectNodes("Applications/Application").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						string attribute = ((XmlElement)enumerator.Current).GetAttribute("Authentication");
						if (string.IsNullOrEmpty(attribute))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						Type type = Type.GetType(attribute, throwOnError: false);
						if (type != null)
						{
							if (dictionary.ContainsValue(type))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dictionary.Add(type.Name, type);
							}
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
				if (!(mobjSection.SelectSingleNode("Authentication") is XmlElement xmlElement))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Type type2 = Type.GetType(xmlElement.GetAttribute("Type"), throwOnError: false);
					if (!(type2 != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (dictionary.ContainsValue(type2))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dictionary.Add(type2.Name, type2);
					}
				}
				return dictionary;
			}
		}

		public List<Type> RegisteredVisualTemplates
		{
			get
			{
				if (mobjVisualTemplateTypesList == null)
				{
					object obj = mobjVisualTemplateTypesSemaphore;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (mobjVisualTemplateTypesList == null)
						{
							try
							{
								mobjVisualTemplateTypesList = new List<Type>();
								foreach (XmlElement visualTemplateNode in ResourceProvider.VisualTemplateNodes)
								{
									string[] array = visualTemplateNode.GetAttribute("Type").Split(',');
									if (array.Length <= 1)
									{
										/*OpCode not supported: LdMemberToken*/;
										continue;
									}
									string text = $"{array[0]}, {CommonUtils.GetFullAssemblyName(array[1].Trim())}";
									if (string.IsNullOrEmpty(text))
									{
										/*OpCode not supported: LdMemberToken*/;
										continue;
									}
									Type type = Type.GetType(text, throwOnError: false);
									if (type != null)
									{
										if (mobjVisualTemplateTypesList.Contains(type))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else
										{
											mobjVisualTemplateTypesList.Add(type);
										}
									}
								}
								IEnumerator enumerator = mobjSection.SelectNodes("VisualTemplates/VisualTemplate").GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										/*OpCode not supported: LdMemberToken*/;
										string attribute = ((XmlElement)enumerator.Current).GetAttribute("Type");
										if (string.IsNullOrEmpty(attribute))
										{
											/*OpCode not supported: LdMemberToken*/;
											continue;
										}
										Type type2 = Type.GetType(attribute, throwOnError: false);
										if (!(type2 != null))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else if (!mobjVisualTemplateTypesList.Contains(type2))
										{
											mobjVisualTemplateTypesList.Add(type2);
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
							}
							catch
							{
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
							Monitor.Exit(obj);
						}
					}
				}
				return mobjVisualTemplateTypesList;
			}
		}

		public string[] Themes => new List<string>(ThemeTypes.Keys).ToArray();

		public List<string> AvailableThemes
		{
			get
			{
				EnsureConfiguredThemesLoaded();
				return marrAvailableThemes;
			}
		}

		public string DefaultTheme
		{
			get
			{
				if (!CommonUtils.IsDesignMode && !string.IsNullOrEmpty(mstrDefaultTheme))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrDefaultTheme = "Default";
					if (!(mobjSection.SelectSingleNode("Themes") is XmlElement xmlElement))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string attribute = xmlElement.GetAttribute("Selected");
						if (string.IsNullOrEmpty(attribute))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							string[] themes = Themes;
							for (int i = 0; i < themes.Length; i++)
							{
								/*OpCode not supported: LdMemberToken*/;
								string text = themes[i];
								if (text.ToLowerInvariant() == attribute.ToLowerInvariant())
								{
									mstrDefaultTheme = text;
									break;
								}
							}
						}
					}
				}
				return mstrDefaultTheme;
			}
		}

		internal Dictionary<string, Type> ThemeTypes
		{
			get
			{
				EnsureConfiguredThemesLoaded();
				return mobjThemes;
			}
		}

		public List<Type> ActionTypes
		{
			get
			{
				if (mobjActionTypes != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object obj = mobjActionTypesSemaphore;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (mobjActionTypes != null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjActionTypes = new List<Type>();
							IEnumerator enumerator = ResourceProvider.ActionNodes.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									/*OpCode not supported: LdMemberToken*/;
									Type type = Type.GetType(((XmlElement)enumerator.Current).GetAttribute("Type"), throwOnError: false);
									if (!(type != null))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										mobjActionTypes.Add(type);
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
							enumerator = mobjSection.SelectNodes("EnterpriseMobileServer/Actions/Action").GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									/*OpCode not supported: LdMemberToken*/;
									string attribute = ((XmlElement)enumerator.Current).GetAttribute("Type");
									if (string.IsNullOrEmpty(attribute))
									{
										/*OpCode not supported: LdMemberToken*/;
										continue;
									}
									Type type2 = Type.GetType(attribute, throwOnError: false);
									if (!(type2 != null))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										mobjActionTypes.Add(type2);
									}
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable2))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									disposable2.Dispose();
								}
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
							Monitor.Exit(obj);
						}
					}
				}
				return mobjActionTypes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal string PrivateVersion => mstrPrivateVersion;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string DynamicExtension => mstrDynamicExtension;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InlineWindows => mblnInlineWindows;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool VerifyBrowserSupport => mblnVerifyBrowserSupport;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool PreserveFocusElement => mblnPreserveFocusElement;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ForcePageInstance => mblnForcePageInstance;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsTextBoxRealTimeKeyboardEventsOn => IsWinFormsCompatibilityOptionOn("TextBoxRealTimeKeyboardEvents");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsGrayedReadOnlyTextBoxOn => IsWinFormsCompatibilityOptionOn("GrayedReadOnlyTextBox");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsTreeNodeClickEventsOnToggleOn => IsWinFormsCompatibilityOptionOn("TreeNodeClickEventsOnToggle");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsToolBarItemAutoSizePreservedPlaceholdersOn => IsWinFormsCompatibilityOptionOn("ToolBarItemAutoSizePreservedPlaceholders");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsRecursiveResizeEventOn => IsWinFormsCompatibilityOptionOn("RecursiveResizeEvent");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsForceSelectedIndexChangedOnClickOn => IsWinFormsCompatibilityOptionOn("ForceSelectedIndexChangedOnClick");

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AnimationEnabled => mblnAnimationEnabled;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RightToLeft => mblnRightToLeft;

		private string ApplicationsMetaData
		{
			get
			{
				if (string.IsNullOrEmpty(mstrApplicationsMetaData) && mobjSection.SelectSingleNode("ApplicationsMetaData") is XmlElement objConfigNode)
				{
					mstrApplicationsMetaData = GetMetaDataFromConfigNode(objConfigNode);
				}
				return mstrApplicationsMetaData;
			}
		}

		public string[] PreloadedResources
		{
			get
			{
				if (marrPreloadedResources != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object obj = mobjPreloadedResourcesLock;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (marrPreloadedResources == null)
						{
							PreloadRegisterdControlsResources();
							PreloadDirectoriesResources();
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
				}
				if (marrPreloadedResources == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return marrPreloadedResources.ToArray();
			}
		}

		public Type[] RegisteredControls
		{
			get
			{
				if (mobjRegisteredComponents == null)
				{
					object obj = mobjRegisteredComponentsLock;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (mobjRegisteredComponents != null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							List<Type> list = new List<Type>();
							XmlNodeList controlNodes = ResourceProvider.ControlNodes;
							list.AddRange(GetRegisteredControls(controlNodes));
							list.AddRange(GetConfiguredControls());
							Type[] registeredControls = GetRegisteredControls(mobjSection.SelectNodes("Controls/Control[@Action='Remove']"));
							if (registeredControls == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (registeredControls.Length == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								Type[] array = list.ToArray();
								Type[] array2 = registeredControls;
								for (int i = 0; i < array2.Length; i++)
								{
									/*OpCode not supported: LdMemberToken*/;
									Type type = array2[i];
									Type[] array3 = array;
									for (int j = 0; j < array3.Length; j++)
									{
										/*OpCode not supported: LdMemberToken*/;
										Type type2 = array3[j];
										if (type2 == type)
										{
											if (!list.Contains(type2))
											{
												/*OpCode not supported: LdMemberToken*/;
											}
											else
											{
												list.Remove(type2);
											}
										}
										else if (!type2.IsSubclassOf(type))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else if (!list.Contains(type2))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else
										{
											list.Remove(type2);
										}
									}
								}
							}
							mobjRegisteredComponents = new List<Type>();
							foreach (Type item in list)
							{
								if (mobjRegisteredComponents.Contains(item))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									mobjRegisteredComponents.Add(item);
								}
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
							Monitor.Exit(obj);
						}
					}
				}
				return mobjRegisteredComponents.ToArray();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is obsolete. Use IsTextBoxRealTimeKeyboardEventsOn property instead.")]
		[Browsable(false)]
		public bool RaiseTextBoxRealTimeKeyboardEventsCompatibility => IsTextBoxRealTimeKeyboardEventsOn;

		[Obsolete("This property is obsolete. Use IsGrayedReadOnlyTextBoxOn property instead.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GrayedReadOnlyTextBoxCompatibility => IsGrayedReadOnlyTextBoxOn;

		[Obsolete("This property is obsolete. Use IsTreeNodeClickEventsOnToggleOn property instead.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RaiseTreeNodeClickEventsOnToggleCompatibility => IsTreeNodeClickEventsOnToggleOn;

		[Obsolete("This property is obsolete. Use IsToolBarItemAutoSizePreservedPlaceholdersOn property instead.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ToolBarItemAutoSizePreservedPlaceholdersCompatibility => IsToolBarItemAutoSizePreservedPlaceholdersOn;

		[Obsolete("This property is obsolete. Use IsRecursiveResizeEventOn property instead.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ContainerRecursiveResizeEventCompatibility => IsRecursiveResizeEventOn;

		public List<Type> RegisteredSkins
		{
			get
			{
				List<Type> list = new List<Type>();
				list.AddRange(RegisteredControls);
				list.AddRange(RegisteredVisualTemplates);
				return list;
			}
		}

		static Config()
		{
			mobjThemesSemaphore = new object();
			mobjVisualTemplateTypesSemaphore = new object();
			mobjDefaultThemeSemaphore = new object();
			mobjActionTypesSemaphore = new object();
			mobjConfigInstance = null;
			mobjLockGetInstance = new object();
			mobjSystemApplicationsIndexByPageName = new Dictionary<string, string>();
			InitializeSystemApplications();
		}

		internal Config(XmlElement objSection)
		{
			mobjSection = objSection;
			mobjProperties = new Dictionary<string, object>();
			LoadRootDirectory();
			LoadConfiguredDirectories();
			LoadConfiguredApplications();
			LoadConfiguredAuthentication();
			LoadConfiguredExtension();
			LoadConfiguredPrivateVersion();
			LoadConfiguredDateFormats();
			LoadConfiguredFeatures();
			LoadConfiguredExternalToolBox();
			LoadWinFormsCompatibilityValues();
		}

		private void LoadConfiguredFeatures()
		{
			mblnInlineWindows = IsFeatureEnabled("InlineWindows", true);
			mblnAspCompatMode = IsFeatureEnabled("AspCompat", false);
			mblnGZipCompression = IsFeatureEnabled("GZipCompression", true);
			mblnAnimationEnabled = IsFeatureEnabled("AnimationEnabled", true);
			mblnForcePageInstance = IsFeatureEnabled("ForcePageInstance", false);
			mblnPreserveFocusElement = IsFeatureEnabled("PreserveFocusElement", true);
			mblnAccessibilityMode = IsFeatureEnabled("AccessibilityMode", false);
			mblnFormsSecurityEnabled = IsFeatureEnabled("FormsSecurity", false);
			mblnEnableAutomationIds = IsFeatureEnabled("EnableAutomationIds", false);
			mblnVerifyBrowserSupport = IsFeatureEnabled("VerifyBrowserSupport", true);
		}

		private void LoadConfiguredExternalToolBox()
		{
			Type[] registeredControls = GetRegisteredControls(mobjSection.SelectNodes("EnterpriseMobileServer/EMSToolBox/Control"));
			List<Type> list = new List<Type>();
			Type[] array = registeredControls;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type type = array[i];
				if (!CommonUtils.IsValidVWGConponent(type))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					list.Add(type);
				}
			}
			marrEMSToolBoxTypes = list.ToArray();
		}

		private void LoadConfiguredDirectories()
		{
			IEnumerator enumerator = mobjSection.SelectNodes("Directories/Directory").GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					XmlElement xmlElement = (XmlElement)(XmlNode)enumerator.Current;
					this["Directory." + xmlElement.GetAttribute("Code")] = xmlElement.GetAttribute("Path");
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

		private void LoadRootDirectory()
		{
			if (HostRuntime.Current == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				try
				{
					mstrRootDirectory = HostRuntime.AppDomainAppPath;
				}
				catch
				{
				}
			}
			if (!string.IsNullOrEmpty(mstrRootDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(mobjSection.SelectSingleNode("HomeDirectory/@Value") is XmlAttribute xmlAttribute))
			{
				/*OpCode not supported: LdMemberToken*/;
				mstrRootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				int num = mstrRootDirectory.IndexOf("\\bin\\");
				if (num <= -1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrRootDirectory = mstrRootDirectory.Substring(0, num + 1);
				}
			}
			else
			{
				mstrRootDirectory = xmlAttribute.Value;
			}
		}

		private void LoadConfiguredAuthentication()
		{
			bool flag = false;
			if (!(mobjSection.SelectSingleNode("Authentication") is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				this["Authentication.Type"] = xmlElement.GetAttribute("Type");
				this["Authentication.Mode"] = xmlElement.GetAttribute("Mode");
				if (xmlElement.GetAttribute("Mode").ToLower().Equals("none"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					flag = true;
				}
			}
			this["Authentication.UseAuthentication"] = flag;
		}

		private void LoadConfiguredExtension()
		{
			if (!(mobjSection.SelectSingleNode("Extension") is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string attribute = xmlElement.GetAttribute("Value");
			if (CommonUtils.IsNullOrEmpty(attribute))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mstrDynamicExtension = attribute;
			}
		}

		private void LoadConfiguredPrivateVersion()
		{
			if (!(mobjSection.SelectSingleNode("PrivateVersion") is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string attribute = xmlElement.GetAttribute("Value");
			if (CommonUtils.IsNullOrEmpty(attribute))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mstrPrivateVersion = "." + attribute;
			}
		}

		private void LoadConfiguredDateFormats()
		{
			if (mobjSection.SelectSingleNode("TimeFormat") is XmlElement xmlElement)
			{
				string attribute = xmlElement.GetAttribute("Value");
				if (CommonUtils.IsNullOrEmpty(attribute))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrTimeFormat = attribute;
				}
			}
			if (!(mobjSection.SelectSingleNode("LongDateFormat") is XmlElement xmlElement2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string attribute2 = xmlElement2.GetAttribute("Value");
				if (CommonUtils.IsNullOrEmpty(attribute2))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrLongDateFormat = attribute2;
				}
			}
			if (!(mobjSection.SelectSingleNode("ShortDateFormat") is XmlElement xmlElement3))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string attribute3 = xmlElement3.GetAttribute("Value");
			if (CommonUtils.IsNullOrEmpty(attribute3))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mstrShortDateFormat = attribute3;
			}
		}

		private void LoadConfiguredApplications()
		{
			if (mobjSection.SelectSingleNode("Applications/@DefaultFactory") is XmlAttribute xmlAttribute)
			{
				mstrDefaultFactory = xmlAttribute.Value;
			}
			IEnumerator enumerator = mobjSection.SelectNodes("Applications/Application").GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					XmlElement xmlElement = (XmlElement)(XmlNode)enumerator.Current;
					string attribute = xmlElement.GetAttribute("Type");
					if (!(attribute == ""))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						attribute = mstrDefaultFactory;
					}
					string applicationCodeFromConfigValue = GetApplicationCodeFromConfigValue(xmlElement.GetAttribute("Code"));
					this["Application." + applicationCodeFromConfigValue] = attribute;
					this["Application." + applicationCodeFromConfigValue + ".Mode"] = xmlElement.GetAttribute("Mode");
					this["Application." + applicationCodeFromConfigValue + ".Stateless"] = GetBooleanFromConfigValue(xmlElement.GetAttribute("Stateless"));
					this["Application." + applicationCodeFromConfigValue + ".ForceSSL"] = GetBooleanFromConfigValue(xmlElement.GetAttribute("ForceSSL"));
					this["Application." + applicationCodeFromConfigValue + ".Meta"] = GetMetaDataFromConfigNode(xmlElement);
					this["Application." + applicationCodeFromConfigValue + ".Authentication"] = xmlElement.GetAttribute("Authentication");
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

		private Assembly GetAssembly(string strName)
		{
			return Assembly.Load(new AssemblyName
			{
				Name = strName
			});
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Assembly GetFormsAssembly()
		{
			new AssemblyName();
			return Assembly.Load("Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Assembly GetCommonAssembly()
		{
			new AssemblyName();
			return Assembly.Load("Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6");
		}

		private static void InitializeSystemApplications()
		{
			mobjSystemApplicationsIndexByPageName.Add(WGConst.AdministrationPage, "Gizmox.WebGUI.Forms.AdministrationForm, Gizmox.WebGUI.Forms");
		}

		private bool GetBooleanFromConfigValue(string strValue)
		{
			if (!string.IsNullOrEmpty(strValue))
			{
				/*OpCode not supported: LdMemberToken*/;
				strValue = strValue.ToLowerInvariant();
				if (strValue == "true")
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(strValue == "yes"))
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return true;
			}
			return false;
		}

		private string GetApplicationCodeFromConfigValue(string strApplicationCode)
		{
			strApplicationCode = strApplicationCode.ToLowerInvariant();
			strApplicationCode = strApplicationCode.Replace('/', '~');
			strApplicationCode = strApplicationCode.Replace('\\', '~');
			return strApplicationCode;
		}

		private string GetMetaDataFromConfigNode(XmlElement objConfigNode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			XmlNodeList xmlNodeList = objConfigNode.SelectNodes("Meta|meta");
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			if (xmlNodeList != null)
			{
				IEnumerator enumerator = xmlNodeList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						XmlNode obj = (XmlNode)enumerator.Current;
						XmlNode xmlNode = obj.SelectSingleNode("@Name|@name");
						XmlNode xmlNode2 = obj.SelectSingleNode("@Http-Equiv|@http-equiv");
						XmlNode xmlNode3 = obj.SelectSingleNode("@Content|@content");
						if (xmlNode2 != null)
						{
							if (xmlNode3 != null)
							{
								list2.Add(xmlNode2.Value.ToLowerInvariant());
								stringBuilder.AppendFormat("<meta http-equiv=\"{0}\" content=\"{1}\" />\n", HttpUtility.HtmlEncode(xmlNode2.Value), HttpUtility.HtmlEncode(xmlNode3.Value));
								continue;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
						if (xmlNode == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (xmlNode3 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						list.Add(xmlNode.Value.ToLowerInvariant());
						stringBuilder.AppendFormat("<meta name=\"{0}\" content=\"{1}\" />\n", HttpUtility.HtmlEncode(xmlNode.Value), HttpUtility.HtmlEncode(xmlNode3.Value));
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
			if (!list.Contains("generator"))
			{
				stringBuilder.AppendFormat("<meta name=\"generator\" content=\"{0}\" />\n", HttpUtility.HtmlEncode(WGConst.Generator));
			}
			if (list2.Contains("content-type"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" />\n");
			}
			return stringBuilder.ToString();
		}

		public string GetDirectory(string strCode, string strDefault)
		{
			string directory = GetDirectory(strCode);
			if (directory == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strDefault;
			}
			return directory;
		}

		public string GetDirectory(string strCode)
		{
			string text = this["Directory." + strCode] as string;
			if (text == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Path.IsPathRooted(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = Path.Combine(mstrRootDirectory, text);
			}
			return text;
		}

		private List<DrawingEngine> GetPresentationDrawingEngines()
		{
			List<DrawingEngine> list = new List<DrawingEngine>();
			bool flag = true;
			if (mobjSection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XmlNodeList xmlNodeList = mobjSection.SelectNodes("PresentationDrawingEngines/PresentationDrawingEngine");
				if (xmlNodeList == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					list.AddRange(GetPresentationDrawingEngines(xmlNodeList));
					if (list.Count > 0)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				XmlNodeList presentationDrawingEngineNodes = ResourceProvider.PresentationDrawingEngineNodes;
				if (presentationDrawingEngineNodes == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					list.AddRange(GetPresentationDrawingEngines(presentationDrawingEngineNodes));
				}
			}
			return list;
		}

		private List<DrawingEngine> GetPresentationDrawingEngines(XmlNodeList arrPresentationDrawingEngineNodes)
		{
			List<DrawingEngine> list = new List<DrawingEngine>();
			if (arrPresentationDrawingEngineNodes == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IEnumerator enumerator = arrPresentationDrawingEngineNodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						if (xmlNode.Attributes["Type"] == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (xmlNode.Attributes["UserAgentRegEx"] == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (Enum.IsDefined(typeof(PresentationDrawingEngine), xmlNode.Attributes["Type"].Value))
						{
							PresentationDrawingEngine enmPresentationDrawingEngine = (PresentationDrawingEngine)Enum.Parse(typeof(PresentationDrawingEngine), xmlNode.Attributes["Type"].Value);
							string value = xmlNode.Attributes["UserAgentRegEx"].Value;
							if (string.IsNullOrEmpty(value))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								list.Add(new DrawingEngine(enmPresentationDrawingEngine, value));
							}
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
			return list;
		}

		private List<Include> GetIncludes(IncludeType enmIncludeTypes, Presentation enmPresentation, PresentationEngine enmPresentationEngine)
		{
			List<Include> list = new List<Include>();
			Dictionary<string, Include> dictionary = new Dictionary<string, Include>();
			PresentationDrawingEngine currentPresentationDrawingEngine = GetCurrentPresentationDrawingEngine();
			XmlNodeList includeNodes = ResourceProvider.IncludeNodes;
			if (includeNodes == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				using List<Include>.Enumerator enumerator = GetIncludes(includeNodes, enmIncludeTypes, enmPresentation, enmPresentationEngine, currentPresentationDrawingEngine).GetEnumerator();
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Include current = enumerator.Current;
					if (!dictionary.ContainsKey(current.IncludeName))
					{
						dictionary.Add(current.IncludeName, current);
						continue;
					}
					throw new Exception($"Duplicate system include '{current.IncludeName}'. Please rename..");
				}
			}
			if (mobjSection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XmlNodeList xmlNodeList = mobjSection.SelectNodes("Includes/Include");
				if (xmlNodeList == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					foreach (Include include in GetIncludes(xmlNodeList, enmIncludeTypes, enmPresentation, enmPresentationEngine, currentPresentationDrawingEngine))
					{
						string text = include.Action.ToLower();
						if (text == "remove")
						{
							/*OpCode not supported: LdMemberToken*/;
							dictionary.Remove(include.IncludeName);
							continue;
						}
						if (text == "replace")
						{
							/*OpCode not supported: LdMemberToken*/;
							if (dictionary.ContainsKey(include.IncludeName))
							{
								dictionary[include.IncludeName] = include;
								continue;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
						string text2 = include.IncludeName;
						if (!dictionary.ContainsKey(include.IncludeName))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text2 += Guid.NewGuid().ToString("N");
						}
						dictionary.Add(text2, include);
					}
				}
				list.AddRange(dictionary.Values);
			}
			return list;
		}

		private void RemoveIncludes(List<Include> arrIncludes, XmlNodeList objRemovedIncludeNodes)
		{
			if (arrIncludes == null || objRemovedIncludeNodes == null)
			{
				return;
			}
			IEnumerator enumerator = objRemovedIncludeNodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					XmlAttribute xmlAttribute = ((XmlNode)enumerator.Current).Attributes["IncludeName"];
					if (xmlAttribute == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string A = xmlAttribute.Value;
					if (string.IsNullOrEmpty(A))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					Include include = arrIncludes.Find((Include objInclude) => objInclude.IncludeName == A);
					if (include == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						arrIncludes.Remove(include);
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

		internal PresentationDrawingEngine GetCurrentPresentationDrawingEngine()
		{
			PresentationDrawingEngine result = PresentationDrawingEngine.JQT;
			IContext current = VWGContext.Current;
			if (current == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				HostContext hostContext = current.HostContext;
				if (hostContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (hostContext.Request == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string userAgent = hostContext.Request.UserAgent;
					if (string.IsNullOrEmpty(userAgent))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						userAgent = userAgent.ToLower();
						List<DrawingEngine> presentationDrawingEngines = PresentationDrawingEngines;
						if (presentationDrawingEngines == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							using List<DrawingEngine>.Enumerator enumerator = presentationDrawingEngines.GetEnumerator();
							while (enumerator.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								DrawingEngine current2 = enumerator.Current;
								if (Regex.IsMatch(userAgent, current2.UserAgentRegEx, RegexOptions.IgnoreCase))
								{
									result = current2.PresentationDrawingEngine;
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		private List<Include> GetIncludes(XmlNodeList arrIncludeNodes, IncludeType enmRequestedIncludeType, Presentation enmRequestedPresentation, PresentationEngine enmRequestedPresentationEngine, PresentationDrawingEngine enmRequestedPresentationDrawingEngine)
		{
			List<Include> list = new List<Include>();
			if (arrIncludeNodes == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IEnumerator enumerator = arrIncludeNodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						if (xmlNode.Attributes["IncludeType"] == null || xmlNode.Attributes["SourceType"] == null || xmlNode.Attributes["Source"] == null)
						{
							continue;
						}
						if (!Enum.IsDefined(typeof(IncludeType), xmlNode.Attributes["IncludeType"].Value))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						IncludeType includeType = (IncludeType)Enum.Parse(typeof(IncludeType), xmlNode.Attributes["IncludeType"].Value);
						bool flag = true;
						Presentation presentation = Presentation.Agnostic;
						if (xmlNode.Attributes["Presentation"] == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							string value = xmlNode.Attributes["Presentation"].Value;
							if (!Enum.IsDefined(typeof(Presentation), value))
							{
								/*OpCode not supported: LdMemberToken*/;
								flag = false;
							}
							else
							{
								presentation = (Presentation)Enum.Parse(typeof(Presentation), value);
							}
						}
						PresentationEngine presentationEngine = PresentationEngine.Agnostic;
						if (xmlNode.Attributes["PresentationEngine"] != null)
						{
							string value2 = xmlNode.Attributes["PresentationEngine"].Value;
							if (Enum.IsDefined(typeof(PresentationEngine), value2))
							{
								presentationEngine = (PresentationEngine)Enum.Parse(typeof(PresentationEngine), value2);
							}
							else
							{
								flag = false;
							}
						}
						PresentationDrawingEngine presentationDrawingEngine = PresentationDrawingEngine.Agnostic;
						if (xmlNode.Attributes["PresentationDrawingEngine"] == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							string value3 = xmlNode.Attributes["PresentationDrawingEngine"].Value;
							if (!Enum.IsDefined(typeof(PresentationDrawingEngine), value3))
							{
								/*OpCode not supported: LdMemberToken*/;
								flag = false;
							}
							else
							{
								presentationDrawingEngine = (PresentationDrawingEngine)Enum.Parse(typeof(PresentationDrawingEngine), value3);
							}
						}
						if (!flag)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						bool num = includeType == enmRequestedIncludeType;
						bool flag2 = presentation == Presentation.Agnostic || (presentation & enmRequestedPresentation) == enmRequestedPresentation;
						bool flag3 = presentationEngine == PresentationEngine.Agnostic || (presentationEngine & enmRequestedPresentationEngine) == enmRequestedPresentationEngine;
						int num2;
						if (presentationDrawingEngine == PresentationDrawingEngine.Agnostic)
						{
							/*OpCode not supported: LdMemberToken*/;
							num2 = 1;
						}
						else
						{
							num2 = ((presentationDrawingEngine == enmRequestedPresentationDrawingEngine) ? 1 : 0);
						}
						bool flag4 = (byte)num2 != 0;
						if (!(num && flag2 && flag3 && flag4))
						{
							continue;
						}
						SourceType enmSourceType = (SourceType)Enum.Parse(typeof(SourceType), xmlNode.Attributes["SourceType"].Value);
						string text = string.Empty;
						XmlAttribute xmlAttribute = null;
						if (CommonSwitches.DisableObscuring)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							xmlAttribute = xmlNode.Attributes["MinimalSource"];
						}
						if (xmlAttribute != null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							xmlAttribute = xmlNode.Attributes["Source"];
						}
						if (xmlAttribute == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text = xmlAttribute.Value;
						}
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						Assembly objAssembly = null;
						string text2 = ((xmlNode.Attributes["Assembly"] != null) ? xmlNode.Attributes["Assembly"].Value : string.Empty);
						if (string.IsNullOrEmpty(text2))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							try
							{
								objAssembly = Assembly.Load(text2);
							}
							catch (Exception)
							{
								continue;
							}
						}
						string strIncludeName = string.Empty;
						string strAction = string.Empty;
						XmlAttribute xmlAttribute2 = xmlNode.Attributes["IncludeName"];
						if (xmlAttribute2 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							strIncludeName = xmlAttribute2.Value;
						}
						XmlAttribute xmlAttribute3 = xmlNode.Attributes["Action"];
						if (xmlAttribute3 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							strAction = xmlAttribute3.Value;
						}
						list.Add(new Include(strIncludeName, enmSourceType, includeType, text, objAssembly, presentation, presentationEngine, strAction));
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
			return list;
		}

		internal List<Include> GetIncludedScripts(Presentation enmPresentation, PresentationEngine enmPresentationEngine)
		{
			return GetIncludes(IncludeType.Script, enmPresentation, enmPresentationEngine);
		}

		internal List<Include> GetIncludedStyleSheets(Presentation enmPresentation, PresentationEngine enmPresentationEngine)
		{
			if (mobjIncludedStyleSheets != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjIncludedStyleSheets = GetIncludes(IncludeType.StyleSheet, enmPresentation, enmPresentationEngine);
			}
			return mobjIncludedStyleSheets;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetApplication(string strCode)
		{
			if (!mobjSystemApplicationsIndexByPageName.TryGetValue(strCode, out var value))
			{
				return this["Application." + GetApplicationCode(strCode)] as string;
			}
			return value;
		}

		private bool IsValidApplication(string strCode)
		{
			if (mobjSystemApplicationsIndexByPageName.ContainsKey(strCode))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return !string.IsNullOrEmpty(this["Application." + strCode] as string);
		}

		private string GetApplicationCode(string strCode)
		{
			strCode = strCode.ToLower();
			if (IsValidApplication(strCode))
			{
				return strCode;
			}
			return "*";
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckApplication(string strCode)
		{
			return !IsValidApplication(GetApplicationCode(strCode));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetApplicationMode(string strCode)
		{
			return this["Application." + GetApplicationCode(strCode) + ".Mode"] as string;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetApplicationMeta(string strCode)
		{
			return string.Format("{0}{1}", ApplicationsMetaData, this["Application." + GetApplicationCode(strCode) + ".Meta"] as string);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetApplicationAuthentication(string strCode)
		{
			return this["Application." + GetApplicationCode(strCode) + ".Authentication"] as string;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GetApplicationStateless(string strCode)
		{
			object obj = this["Application." + GetApplicationCode(strCode) + ".Stateless"];
			if (obj != null)
			{
				if (obj is bool)
				{
					return (bool)obj;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GetApplicationForceSSL(string strCode)
		{
			object obj = this["Application." + GetApplicationCode(strCode) + ".ForceSSL"];
			if (obj != null)
			{
				if (obj is bool)
				{
					return (bool)obj;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetAuthenticationParam(string strCode)
		{
			return this["Authentication." + strCode] as string;
		}

		public static Config GetInstance()
		{
			if (mobjConfigInstance == null)
			{
				object obj = mobjLockGetInstance;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (mobjConfigInstance != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjConfigInstance = ConfigurationManager.GetSection("WebGUI") as Config;
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
			}
			return mobjConfigInstance;
		}

		public static Config GetInstance(XmlElement objSection, bool blnCacheConfig)
		{
			Config result = new Config(objSection);
			if (blnCacheConfig)
			{
				mobjConfigInstance = result;
			}
			return result;
		}

		public static Config GetInstance(XmlElement objSection)
		{
			return GetInstance(objSection, blnCacheConfig: false);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetIncludedScriptBlocks(Presentation enmPresentation, PresentationEngine enmPresentationEngine)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<Include> includedScripts = GetIncludedScripts(enmPresentation, enmPresentationEngine);
			if (stringBuilder == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (includedScripts.Count > 0)
			{
				using List<Include>.Enumerator enumerator = includedScripts.GetEnumerator();
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Include current = enumerator.Current;
					if (current.SourceType != SourceType.Url)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!string.IsNullOrEmpty(current.Source))
					{
						stringBuilder.Append($"<script language=\"JavaScript\" src=\"{current.Source}\"></script>\n");
					}
				}
			}
			return stringBuilder.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string GetIncludedStyleSheetBlocks(Presentation enmPresentation, PresentationEngine enmPresentationEngine)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<Include> includedStyleSheets = GetIncludedStyleSheets(enmPresentation, enmPresentationEngine);
			if (stringBuilder != null)
			{
				if (includedStyleSheets.Count <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					using List<Include>.Enumerator enumerator = includedStyleSheets.GetEnumerator();
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						Include current = enumerator.Current;
						if (current.SourceType != SourceType.Url)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (string.IsNullOrEmpty(current.Source))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stringBuilder.Append($"<link href=\"{current.Source}\" type=\"text/css\" rel=\"stylesheet\"/>\n");
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		public bool IsWinFormsCompatibilityOptionOn(string strOptionName)
		{
			return mobjWinFormsCompatibilityOptions.ContainsKey(strOptionName);
		}

		private void EnsureConfiguredThemesLoaded()
		{
			if (mobjThemes == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (marrAvailableThemes != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			lock (mobjThemesSemaphore)
			{
				if (mobjThemes == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (marrAvailableThemes != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				try
				{
					mobjThemes = new Dictionary<string, Type>();
					marrAvailableThemes = new List<string>();
					IEnumerator enumerator = mobjSection.SelectNodes("Themes/Theme").GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							XmlElement xmlElement = (XmlElement)enumerator.Current;
							string attribute = xmlElement.GetAttribute("Name");
							string attribute2 = xmlElement.GetAttribute("Type");
							if (string.IsNullOrEmpty(attribute))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (string.IsNullOrEmpty(attribute2))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (mobjThemes.ContainsKey(attribute))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							Type type = Type.GetType(attribute2, throwOnError: false);
							if (!(type != null))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (!typeof(Theme).IsAssignableFrom(type))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							mobjThemes.Add(attribute, type);
							if (marrAvailableThemes.Contains(attribute))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							XmlAttribute xmlAttribute = xmlElement.Attributes["MultiThemeSupport"];
							if (xmlAttribute != null)
							{
								if (!(xmlAttribute.Value == "On"))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									marrAvailableThemes.Add(attribute);
								}
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
				catch
				{
				}
			}
		}

		private void PreloadDirectoriesResources()
		{
			XmlNodeList xmlNodeList = mobjSection.SelectNodes("PreloadedResources/Directories/Directory");
			if (xmlNodeList == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			IEnumerator enumerator = xmlNodeList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					XmlAttribute xmlAttribute = xmlNode.Attributes["Name"];
					if (xmlAttribute == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string value = xmlAttribute.Value;
					if (string.IsNullOrEmpty(value))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string directory = GetDirectory(value);
					if (string.IsNullOrEmpty(directory))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					directory = Path.Combine(mstrRootDirectory, directory);
					if (!Directory.Exists(directory))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string searchPattern = string.Empty;
					XmlAttribute xmlAttribute2 = xmlNode.Attributes["Pattern"];
					if (xmlAttribute2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						searchPattern = xmlAttribute2.Value;
					}
					string[] files = Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories);
					if (files == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string[] array = files;
					for (int i = 0; i < array.Length; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						string strFilePath = array[i];
						string rresourceHandleRelativeFileName = GetRresourceHandleRelativeFileName(strFilePath, directory);
						if (string.IsNullOrEmpty(rresourceHandleRelativeFileName))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						ResourceHandle resourceHandle = null;
						if (value == "Images")
						{
							/*OpCode not supported: LdMemberToken*/;
							resourceHandle = new ImageResourceHandle(rresourceHandleRelativeFileName);
						}
						else if (value == "Icons")
						{
							/*OpCode not supported: LdMemberToken*/;
							resourceHandle = new IconResourceHandle(rresourceHandleRelativeFileName);
						}
						if (resourceHandle != null)
						{
							if (marrPreloadedResources != null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								marrPreloadedResources = new List<string>();
							}
							marrPreloadedResources.Add(resourceHandle.ToString());
						}
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

		private string GetRresourceHandleRelativeFileName(string strFilePath, string strRootDirectoryPath)
		{
			string text = string.Empty;
			if (string.IsNullOrEmpty(strFilePath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (string.IsNullOrEmpty(strRootDirectoryPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(strRootDirectoryPath);
				FileInfo fileInfo = new FileInfo(strFilePath);
				if (!directoryInfo.Exists)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!fileInfo.Exists)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text = fileInfo.Name;
					DirectoryInfo directoryInfo2 = fileInfo.Directory;
					while (true)
					{
						if (directoryInfo2 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							break;
						}
						if (!(directoryInfo2.FullName != directoryInfo.FullName))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						text = $"{directoryInfo2.Name}.{text}";
						directoryInfo2 = directoryInfo2.Parent;
					}
				}
			}
			return text;
		}

		private void PreloadRegisterdControlsResources()
		{
			Type[] registeredControls = GetRegisteredControls(mobjSection.SelectNodes("PreloadedResources/Controls/Control"));
			if (registeredControls == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			List<Type> list = new List<Type>(GetRegisteredControls(mobjSection.SelectNodes("PreloadedResources/Controls/Control[@Action='Remove']")));
			if (list == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Type[] array = registeredControls;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type type = array[i];
				if (list.Contains(type))
				{
					continue;
				}
				object[] customAttributes = type.GetCustomAttributes(typeof(SkinAttribute), inherit: true);
				if (customAttributes.Length != 1)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				Type skinType = ((SkinAttribute)customAttributes[0]).SkinType;
				if (!(skinType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!(Activator.CreateInstance(skinType) is Skin { Resources: var resources } skin))
					{
						continue;
					}
					if (resources == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					using Dictionary<string, SkinResource>.Enumerator enumerator = resources.GetEnumerator();
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						KeyValuePair<string, SkinResource> current = enumerator.Current;
						if (!(current.Value is ImageResource))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (marrPreloadedResources == null)
						{
							marrPreloadedResources = new List<string>();
						}
						marrPreloadedResources.Add(skin.GetResourcePath(current.Key));
					}
				}
			}
		}

		private Type[] GetRegisteredControls(Stream objResourcesStream)
		{
			List<Type> list = new List<Type>();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(objResourcesStream);
			list.AddRange(GetRegisteredControls(xmlDocument.SelectNodes("Resources/Controls/Control")));
			return list.ToArray();
		}

		private Type[] GetConfiguredControls()
		{
			List<Type> list = new List<Type>();
			list.AddRange(GetRegisteredControls(mobjSection.SelectNodes("Controls/Control[@Action='Add' or not(@Action)]")));
			return list.ToArray();
		}

		private Type[] GetRegisteredControls(XmlNodeList objResourceNodes)
		{
			List<Type> list = new List<Type>();
			IEnumerator enumerator = objResourceNodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					XmlElement xmlElement = (XmlElement)enumerator.Current;
					list.AddRange(GetRegisterdControls(xmlElement.GetAttribute("Type")));
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
			return MakeTypeListDistinct(list).ToArray();
		}

		private List<Type> MakeTypeListDistinct(List<Type> objTempList)
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			using (List<Type>.Enumerator enumerator = objTempList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Type current = enumerator.Current;
					if (dictionary.ContainsKey(current.FullName))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dictionary.Add(current.FullName, current);
					}
				}
			}
			return new List<Type>(dictionary.Values);
		}

		private Type[] GetRegisterdControls(string strControlType)
		{
			if (!strControlType.Contains("*"))
			{
				/*OpCode not supported: LdMemberToken*/;
				Type type = Type.GetType(CommonUtils.GetFullTypeName(strControlType), throwOnError: false);
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (IsSkinable(type))
					{
						return new Type[1] { type };
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return new Type[0];
			}
			List<Type> list = new List<Type>();
			string[] array = strControlType.Split(',');
			if (array.Length <= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string text = array[0].Replace(".*", string.Empty).Trim();
				Assembly assembly = Assembly.Load(CommonUtils.GetFullAssemblyName(array[1].Trim()));
				if (!(assembly != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type2 in types)
					{
						if (type2.IsClass)
						{
							if (!(type2.Namespace == text))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (!IsSkinable(type2))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								list.Add(type2);
							}
						}
					}
				}
			}
			return list.ToArray();
		}

		private bool IsSkinable(Type objType)
		{
			return typeof(ISkinable).IsAssignableFrom(objType);
		}

		public bool IsFeatureEnabled(string strFeature, bool blnDefault, params string[] arrOldNames)
		{
			if (!(mobjSection.SelectSingleNode(strFeature) is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (xmlElement.Attributes["Mode"] != null)
				{
					string attribute = xmlElement.GetAttribute("Mode");
					if (!(attribute == "On"))
					{
						if (attribute == "Off")
						{
							/*OpCode not supported: LdMemberToken*/;
							return false;
						}
						return blnDefault;
					}
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int i = 0; i < arrOldNames.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = arrOldNames[i];
				if (!(mobjSection.SelectSingleNode(text) is XmlElement))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return IsFeatureEnabled(text, blnDefault);
			}
			return blnDefault;
		}

		public string GetFeatureValue(string strFeature, string strDefault)
		{
			if (!(mobjSection.SelectSingleNode(strFeature) is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
				return strDefault;
			}
			string attribute = xmlElement.GetAttribute("Value");
			if (CommonUtils.IsNullOrEmpty(attribute))
			{
				/*OpCode not supported: LdMemberToken*/;
				return strDefault;
			}
			return attribute;
		}

		public int GetFeatureValue(string strFeature, int intDefault)
		{
			string featureValue = GetFeatureValue(strFeature, intDefault.ToString());
			try
			{
				return int.Parse(featureValue);
			}
			catch
			{
				return intDefault;
			}
		}

		public void LoadWinFormsCompatibilityValues()
		{
			string text = string.Empty;
			if (!(mobjSection.SelectSingleNode("WinFormsCompatible") is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (xmlElement.Attributes["Mode"] == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = xmlElement.GetAttribute("Mode");
			}
			if (!(text == "On"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjWinFormsCompatibilityOptions.Add("RecursiveResizeEvent", value: true);
				mobjWinFormsCompatibilityOptions.Add("ForbidDockMargin", value: true);
				mobjWinFormsCompatibilityOptions.Add("GrayedReadOnlyTextBox", value: true);
				mobjWinFormsCompatibilityOptions.Add("ToolBarItemAutoSizePreservedPlaceholders", value: true);
				mobjWinFormsCompatibilityOptions.Add("TreeNodeClickEventsOnToggle", value: true);
			}
			if (int.TryParse(text, out var result))
			{
				if ((result & 1) <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjWinFormsCompatibilityOptions.Add("TextBoxRealTimeKeyboardEvents", value: true);
				}
				if ((result & 2) <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjWinFormsCompatibilityOptions.Add("GrayedReadOnlyTextBox", value: true);
				}
				if ((result & 4) <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjWinFormsCompatibilityOptions.Add("TreeNodeClickEventsOnToggle", value: true);
				}
				if ((result & 8) <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjWinFormsCompatibilityOptions.Add("ToolBarItemAutoSizePreservedPlaceholders", value: true);
				}
				if ((result & 0x10) > 0)
				{
					mobjWinFormsCompatibilityOptions.Add("RecursiveResizeEvent", value: true);
				}
				if ((result & 0x20) <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjWinFormsCompatibilityOptions.Add("ForbidDockMargin", value: true);
				}
			}
			else
			{
				string[] array = text.Split(new string[1] { "," }, StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text2 = array[i];
					mobjWinFormsCompatibilityOptions.Add(text2.Trim(), value: true);
				}
			}
		}

		public bool GetFeatureValue(string strFeature, bool blnDefault)
		{
			if (!(mobjSection.SelectSingleNode(strFeature) is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
				return blnDefault;
			}
			return xmlElement.GetAttribute("Mode") == "On";
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public XmlElement GetSection(string strSection)
		{
			return mobjSection.SelectSingleNode(strSection) as XmlElement;
		}
	}
}
