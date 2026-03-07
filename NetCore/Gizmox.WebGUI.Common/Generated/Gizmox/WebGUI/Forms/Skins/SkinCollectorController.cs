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
	[Serializable]
	internal class SkinCollectorController : BB
	{
		private IContext mobjContext;

		private Config mobjConfig;

		private SkinTranslator mobjTranslator;

		private GlobalScope mobjGlobalScope;

		private bool mblnSupportsMultilineSkinValues;

		public bool SupportsMultilineSkinValues
		{
			get
			{
				return mblnSupportsMultilineSkinValues;
			}
			set
			{
				mblnSupportsMultilineSkinValues = value;
			}
		}

		public virtual Presentation Presentation => mobjContext.Presentation;

		public virtual PresentationEngine PresentationEngine => mobjContext.PresentationEngine;

		public virtual CSS3BrowserCapabilities CSS3BrowserCapabilities
		{
			get
			{
				if (mobjContext is IContextParams contextParams)
				{
					return contextParams.CSS3BrowserCapabilities;
				}
				return CSS3BrowserCapabilities.Empty;
			}
		}

		public virtual HTML5BrowserCapabilities HTML5BrowserCapabilities
		{
			get
			{
				if (!(mobjContext is IContextParams contextParams))
				{
					/*OpCode not supported: LdMemberToken*/;
					return HTML5BrowserCapabilities.Empty;
				}
				return contextParams.HTML5BrowserCapabilities;
			}
		}

		public virtual MISCBrowserCapabilities MISCBrowserCapabilities
		{
			get
			{
				if (mobjContext is IContextParams contextParams)
				{
					return contextParams.MISCBrowserCapabilities;
				}
				return MISCBrowserCapabilities.Empty;
			}
		}

		private bool ShouldRenderComments => mobjGlobalScope.Comments;

		private bool ShouldRenderWhitespaces => mobjGlobalScope.Whitespaces;

		public virtual Encoding TextEncoding => Encoding.UTF8;

		protected SkinTranslator Translator
		{
			get
			{
				if (mobjTranslator != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjTranslator = new SkinTranslator(mobjContext);
				}
				return mobjTranslator;
			}
		}

		string BB.ResourceBrowserCacheKey => ((IContextParams)mobjContext).Browser;

		string BB.ResourceThemeCacheKey => mobjContext.CurrentTheme;

		string BB.ResourceCacheVersionCacheKey => WGConst.CacheVersion;

		string BB.ResourceCultureCacheKey
		{
			get
			{
				if (mobjContext.CurrentUICulture == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return Thread.CurrentThread.CurrentUICulture.Name;
				}
				return mobjContext.CurrentUICulture.Name;
			}
		}

		internal SkinCollectorController(IContext objContext, Config objConfig, GlobalScope objGlobalScope, bool blnSupportsMultilineSkinValues)
		{
			mobjContext = objContext;
			mobjConfig = objConfig;
			mobjGlobalScope = objGlobalScope;
			mblnSupportsMultilineSkinValues = blnSupportsMultilineSkinValues;
		}

		protected virtual string GetLabelValue(MB objOwner, string strLabel, bool blnEscape)
		{
			string text = WGLabels.GetString(strLabel, mobjContext, blnApplyCultureInfoValues: true);
			if (!blnEscape)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = text.Replace("\"", "\\\"").Replace("'", "\\'");
			}
			return text;
		}

		protected virtual string GetContextParam(MB objOwner, string strParam)
		{
			if (mobjContext is IContextVariables contextVariables)
			{
				return contextVariables.GetContextVariable(strParam);
			}
			return string.Empty;
		}

		protected virtual string GetTagName(MB objOwner, string strTagName)
		{
			WGTags provider = CommonUtils.GetProvider<WGTags>(GetDefaultWGTagsName(), blnIsCache: true);
			if (provider == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				FieldInfo field = GetField(provider.GetType(), strTagName);
				if (field != null)
				{
					return field.GetValue(null) as string;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return string.Empty;
		}

		private string GetDefaultWGAttributesName()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.WGAttributes, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		private string GetDefaultWGEventsName()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.WGEvents, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		private string GetDefaultWGTagsName()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.WGTags, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		private FieldInfo GetField(Type objType, string strFieldName)
		{
			if (!(objType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!string.IsNullOrEmpty(strFieldName))
				{
					FieldInfo field = objType.GetField(strFieldName);
					if (!(field != null))
					{
						/*OpCode not supported: LdMemberToken*/;
						return GetField(objType.BaseType, strFieldName);
					}
					return field;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		protected virtual string GetAttributeName(MB objOwner, string strAttributeName)
		{
			WGAttributes provider = CommonUtils.GetProvider<WGAttributes>(GetDefaultWGAttributesName(), blnIsCache: true);
			if (provider == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				FieldInfo field = GetField(provider.GetType(), strAttributeName);
				if (field != null)
				{
					return field.GetValue(null) as string;
				}
			}
			return string.Empty;
		}

		protected virtual string GetEventName(MB objOwner, string strEventName)
		{
			WGEvents provider = CommonUtils.GetProvider<WGEvents>(GetDefaultWGEventsName(), blnIsCache: true);
			if (provider != null)
			{
				FieldInfo field = GetField(provider.GetType(), strEventName);
				if (field != null)
				{
					return field.GetValue(null) as string;
				}
			}
			return string.Empty;
		}

		protected virtual string GetSkinValue(MB objOwner, string strVariable)
		{
			if (objOwner == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objOwner == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinValueDefinition skinValueDefinition = SkinValueDefinition.Create(strVariable);
				if (skinValueDefinition != null)
				{
					return Translator.GetValue(objOwner.Variables[skinValueDefinition.Name], skinValueDefinition, SupportsMultilineSkinValues);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return string.Empty;
		}

		public virtual string GetCommentValue(MB objScope, string strContent, CompilerActions enmCompilerActions)
		{
			string result = strContent;
			if (!ShouldRenderComments && (enmCompilerActions & CompilerActions.RemoveComments) == CompilerActions.RemoveComments)
			{
				result = string.Empty;
			}
			return result;
		}

		public virtual string GetWhitespaceValue(MB objScope, string strContent, CompilerActions enmCompilerActions)
		{
			string result = strContent;
			if (ShouldRenderWhitespaces)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if ((enmCompilerActions & CompilerActions.RemoveWhitespaces) != CompilerActions.RemoveWhitespaces)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		protected virtual string EvaluateIndex(MB objScope, FileIndexType enmIndexType, string strContent, CompilerActions enmCompilerActions)
		{
			switch (enmIndexType)
			{
			case FileIndexType.Comment:
				return GetCommentValue(objScope, strContent, enmCompilerActions);
			default:
				/*OpCode not supported: LdMemberToken*/;
				if (enmIndexType != FileIndexType.AttributePlaceHolder)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (enmIndexType != FileIndexType.EventPlaceHolder)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (enmIndexType)
						{
						case FileIndexType.TagPlaceHolder:
							return GetTagName(objScope, GetPlaceHolderValue(strContent));
						case FileIndexType.SkinPlaceHolder:
							return GetSkinValue(objScope, GetPlaceHolderValue(strContent));
						default:
							/*OpCode not supported: LdMemberToken*/;
							if (enmIndexType != FileIndexType.ContextPlaceHolder)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (enmIndexType != FileIndexType.LabelPlaceHolder)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (enmIndexType != FileIndexType.XmlRoot)
									{
										/*OpCode not supported: LdMemberToken*/;
										if (enmIndexType != FileIndexType.CssClassDefinition)
										{
											/*OpCode not supported: LdMemberToken*/;
											switch (enmIndexType)
											{
											case FileIndexType.CssClassReference:
												return GetMemberValue(objScope, enmIndexType, strContent);
											default:
												/*OpCode not supported: LdMemberToken*/;
												if (enmIndexType != FileIndexType.ScriptFunctionArgument)
												{
													/*OpCode not supported: LdMemberToken*/;
													switch (enmIndexType)
													{
													case FileIndexType.ScriptIdentifier:
														return GetMemberValue(objScope, enmIndexType, strContent);
													default:
														/*OpCode not supported: LdMemberToken*/;
														if (enmIndexType != FileIndexType.XsltTemplateDefinition)
														{
															/*OpCode not supported: LdMemberToken*/;
															if (enmIndexType != FileIndexType.XsltTemplateReference)
															{
																/*OpCode not supported: LdMemberToken*/;
																switch (enmIndexType)
																{
																case FileIndexType.XsltParamDefinition:
																	return GetMemberValue(objScope, enmIndexType, strContent);
																default:
																	/*OpCode not supported: LdMemberToken*/;
																	if (enmIndexType != FileIndexType.JQTFunctionDeclatation)
																	{
																		/*OpCode not supported: LdMemberToken*/;
																		if (enmIndexType != FileIndexType.JQTFunctionReference)
																		{
																			/*OpCode not supported: LdMemberToken*/;
																			if (enmIndexType != FileIndexType.XsltMigrationNode)
																			{
																				/*OpCode not supported: LdMemberToken*/;
																				if (enmIndexType != FileIndexType.XsltMigrationAttribute)
																				{
																					/*OpCode not supported: LdMemberToken*/;
																					return strContent;
																				}
																				return string.Empty;
																			}
																			return string.Empty;
																		}
																		return GetMemberValue(objScope, enmIndexType, strContent);
																	}
																	return GetMemberValue(objScope, enmIndexType, strContent);
																case FileIndexType.XsltVariableDefinition:
																	return GetMemberValue(objScope, enmIndexType, strContent);
																}
															}
															return GetMemberValue(objScope, enmIndexType, strContent);
														}
														return GetMemberValue(objScope, enmIndexType, strContent);
													case FileIndexType.ScriptVariableDeclatation:
														return GetMemberValue(objScope, enmIndexType, strContent);
													}
												}
												return GetMemberValue(objScope, enmIndexType, strContent);
											case FileIndexType.ScriptFunctionDeclatation:
												return GetMemberValue(objScope, enmIndexType, strContent);
											}
										}
										string text = GetMemberValue(objScope, enmIndexType, strContent);
										if (!VWGContext.Current.SupportsMultipleThemes)
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else if (mobjContext != null)
										{
											text = $"{mobjContext.CurrentTheme}.{text}";
										}
										return text;
									}
									return string.Empty;
								}
								return GetLabelValue(objScope, GetPlaceHolderValue(strContent), blnEscape: true);
							}
							return GetContextParam(objScope, GetPlaceHolderValue(strContent));
						case FileIndexType.UrlExtension:
							return GetExtensionValue(objScope, strContent);
						}
					}
					return GetEventName(objScope, GetPlaceHolderValue(strContent));
				}
				return GetAttributeName(objScope, GetPlaceHolderValue(strContent));
			case FileIndexType.Whitespace:
				return GetWhitespaceValue(objScope, strContent, enmCompilerActions);
			}
		}

		private string GetMemberValue(MB objScope, FileIndexType enmMemberType, string strMemberName)
		{
			string memberValue = GetMemberValue(strMemberName);
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return memberValue;
			}
			return objScope.GetMemberValue(enmMemberType, memberValue);
		}

		private string GetMemberValue(string strMemberName)
		{
			if (!strMemberName.StartsWith("[$"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (strMemberName.EndsWith("]"))
			{
				return strMemberName.Substring(2, strMemberName.Length - 3);
			}
			if (!strMemberName.StartsWith("[."))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (strMemberName.EndsWith("]"))
				{
					return strMemberName.Substring(2, strMemberName.Length - 3);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return strMemberName;
		}

		public virtual string GetExtensionValue(MB objScope, string strExtension)
		{
			string text = strExtension.ToLower();
			if (mobjGlobalScope != null)
			{
				if (mobjGlobalScope.Extensions == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (mobjGlobalScope.Extensions.ContainsKey(text))
					{
						return mobjGlobalScope.Extensions[text];
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			IContextParams contextParams = mobjContext as IContextParams;
			if (!(text == ".png"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!contextParams.IsPngSupport)
				{
					return ".gif";
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return strExtension;
		}

		private string GetPlaceHolderValue(string strContent)
		{
			if (strContent.StartsWith("["))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!strContent.EndsWith("]"))
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_004e;
			}
			strContent = strContent.Trim('[', ']');
			goto IL_004e;
			IL_004e:
			string[] array = strContent.Split('.');
			if (array.Length <= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strContent;
			}
			return array[1];
		}

		string BB.EvaluateIndex(MB objScope, FileIndexType objFileIndexType, string strContent, CompilerActions enmCompilerActions)
		{
			return EvaluateIndex(objScope, objFileIndexType, strContent, enmCompilerActions);
		}
	}
}
