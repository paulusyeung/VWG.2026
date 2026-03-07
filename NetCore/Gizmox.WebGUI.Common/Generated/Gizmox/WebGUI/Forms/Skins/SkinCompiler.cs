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
	internal class SkinCompiler : ISkinable
	{
		private Config mobjConfig;

		private GlobalScope mobjGlobalScope;

		private bool mblnInitialized;

		private string mstrTheme;

		private Dictionary<Type, SkinScope> mobjSkinScopes;

		private int mintNextScopeID = 1;

		string ISkinable.Theme => mstrTheme;

		public SkinCompiler()
		{
			mobjConfig = Config.GetInstance();
			mobjGlobalScope = new GlobalScope();
			mobjSkinScopes = new Dictionary<Type, SkinScope>();
			mobjGlobalScope.Comments = !ConfigHelper.IsObscuringEnabled;
			mobjGlobalScope.Whitespaces = !ConfigHelper.IsObscuringEnabled;
			mobjGlobalScope.Obscuring = ConfigHelper.IsObscuringEnabled;
			mobjGlobalScope.Scoping = true;
			mobjGlobalScope.Extensions.Add(".wgx", mobjConfig.DynamicExtension);
			mobjGlobalScope.Extensions.Add(".dwgx", mobjConfig.DynamicExtension);
			mobjGlobalScope.Extensions.Add(".swgx", mobjConfig.DynamicExtension);
		}

		internal void Initialize(string strTheme)
		{
			if (mblnInitialized)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mblnInitialized = true;
			mstrTheme = strTheme;
			using (List<Type>.Enumerator enumerator = mobjConfig.RegisteredSkins.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Type skinType = SkinFactory.GetSkinType(enumerator.Current);
					if (!(skinType != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (typeof(Skin).IsAssignableFrom(skinType))
					{
						Initialize(skinType);
						Type[] skinDependentTypes = SkinFactory.GetSkinDependentTypes(skinType);
						for (int i = 0; i < skinDependentTypes.Length; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							Type objSkinType = skinDependentTypes[i];
							Initialize(objSkinType);
						}
					}
				}
			}
			mobjGlobalScope.Compile();
		}

		private SkinScope Initialize(Type objSkinType)
		{
			SkinScope skinScope = null;
			if (!(objSkinType.BaseType != typeof(Skin)))
			{
				/*OpCode not supported: LdMemberToken*/;
				skinScope = mobjGlobalScope;
			}
			else
			{
				skinScope = Initialize(objSkinType.BaseType);
			}
			if (!mobjSkinScopes.ContainsKey(objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
				SkinScope skinScope2 = (mobjSkinScopes[objSkinType] = new SkinScope(objSkinType.FullName, mintNextScopeID));
				SkinScope skinScope4 = skinScope2;
				mintNextScopeID++;
				skinScope.Skins.Add(skinScope4);
				skinScope4.SetParent(skinScope);
				Initialize(skinScope4, objSkinType);
				return skinScope4;
			}
			return mobjSkinScopes[objSkinType];
		}

		private void Initialize(SkinScope objSkinScope, Type objSkinType)
		{
			Skin skin = SkinFactory.GetSkin(this, objSkinType);
			if (skin == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			objSkinScope.SetSkin(skin);
			using Dictionary<string, SkinResource>.Enumerator enumerator = skin.Resources.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				KeyValuePair<string, SkinResource> current = enumerator.Current;
				if (current.Value is FileResource objFileResource)
				{
					objSkinScope.AddResource(current.Key, objFileResource);
				}
			}
		}

		internal string[] GetSkinResourcesList()
		{
			return new List<string>(mobjGlobalScope.Collectors.Keys).ToArray();
		}

		internal void WriteSkinResource(IContext objContext, Stream objFileStream, string strResource, NameValueCollection objArguments)
		{
			if (!mobjGlobalScope.Collectors.ContainsKey(strResource))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new Exception("Could not find the requested resource.");
			}
			SkinCollector skinCollector = mobjGlobalScope.Collectors[strResource];
			if (skinCollector == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				skinCollector.Write(objFileStream, new SkinCollectorController(objContext, mobjConfig, mobjGlobalScope, skinCollector.SupportsMultilineSkinValues));
			}
		}

		internal void WriteSkinResource(IContext objContext, HostContext objHostContext, string strResource, NameValueCollection objArguments)
		{
			if (!mobjGlobalScope.Collectors.ContainsKey(strResource))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			SkinCollector skinCollector = mobjGlobalScope.Collectors[strResource];
			if (skinCollector == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				skinCollector.Write(objHostContext, new SkinCollectorController(objContext, mobjConfig, mobjGlobalScope, skinCollector.SupportsMultilineSkinValues));
			}
		}

		internal string GetSkinMethodName(IContext objContext, ISkinable objComponent, string strMember)
		{
			if (mobjGlobalScope == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strMember;
			}
			Type objSkinType = null;
			if (objComponent != null)
			{
				objSkinType = SkinFactory.GetSkinType(objComponent.GetType());
			}
			return GetSkinMethodName(objContext, objSkinType, strMember);
		}

		internal Skin GetSkin(IContext objContext, Type objSkinType)
		{
			if (!(objSkinType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!mobjSkinScopes.ContainsKey(objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinScope skinScope = mobjSkinScopes[objSkinType];
				if (skinScope != null)
				{
					skinScope.Compile();
					return skinScope.Skin;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		internal string GetSkinMethodName(IContext objContext, Type objSkinType, string strMember)
		{
			if (!(objSkinType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				SkinScope commonSkinScope = mobjGlobalScope.GetCommonSkinScope();
				if (commonSkinScope != null)
				{
					return commonSkinScope.GetMethodName(strMember);
				}
			}
			else if (!mobjSkinScopes.ContainsKey(objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
				Type baseType = objSkinType.BaseType;
				if (!(baseType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (typeof(Skin).IsAssignableFrom(baseType))
					{
						return GetSkinMethodName(objContext, baseType, strMember);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				SkinScope skinScope = mobjSkinScopes[objSkinType];
				if (skinScope != null)
				{
					skinScope.Compile();
					return skinScope.GetMethodName(strMember);
				}
			}
			return strMember;
		}

		internal string GetSkinClassName(IContext objContext, IRegisteredComponent objComponent, string strMember)
		{
			if (mobjGlobalScope != null && objComponent != null)
			{
				Type skinType = SkinFactory.GetSkinType(objComponent.GetType());
				if (skinType != null)
				{
					return GetSkinClassName(objContext, skinType, strMember);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return strMember;
		}

		internal string GetSkinClassName(IContext objContext, Type objSkinType, string strMember)
		{
			if (!mobjSkinScopes.ContainsKey(objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
				Type baseType = objSkinType.BaseType;
				if (baseType != null)
				{
					if (typeof(Skin).IsAssignableFrom(baseType))
					{
						return GetSkinClassName(objContext, baseType, strMember);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				SkinScope skinScope = mobjSkinScopes[objSkinType];
				if (skinScope != null)
				{
					skinScope.Compile();
					return skinScope.GetClassName(strMember);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return strMember;
		}

		internal static void WriteSkinManifestViewLink(HtmlTextWriter objWriter, string strLabel, string strView, string strTheme, string strCollector, string strResource)
		{
			objWriter.WriteBeginTag("a");
			objWriter.WriteAttribute("href", $"Resources.Manifest.wgx?view={HttpUtility.UrlEncode(strView)}&theme={HttpUtility.UrlEncode(strTheme)}&collector={HttpUtility.UrlEncode(strCollector)}&resource={HttpUtility.UrlEncode(strResource)}");
			objWriter.Write(">");
			objWriter.Write(strLabel);
			objWriter.WriteEndTag("a");
		}

		internal void WriteSkinManifestView(IContext objContext, Stream objStream, NameValueCollection objArguments)
		{
			string text = objArguments["collector"];
			string text2 = objArguments["resource"];
			string text3 = objArguments["view"];
			if (!(text3 == "collectors"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(text3 == "collector.resources"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(text3 == "scopes"))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							SkinCollector skinCollector = mobjGlobalScope.Collectors[text];
							if (skinCollector != null)
							{
								if (string.IsNullOrEmpty(text2))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									SkinCollectorResource skinCollectorResource = skinCollector[text2];
									if (skinCollectorResource == null)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										FileResource resource = skinCollectorResource.Resource;
										if (resource != null)
										{
											if (text3 == "indexes")
											{
												resource.DumpIndexes(objStream);
											}
											else if (!(text3 == "tokens"))
											{
												/*OpCode not supported: LdMemberToken*/;
												resource.DumpContent(objStream);
											}
											else
											{
												resource.DumpTokens(objStream);
											}
											return;
										}
									}
								}
							}
						}
						throw new HttpException("View could not be generated.");
					}
					WriteSkinManifestScopesView(objStream, objArguments);
				}
				else
				{
					WriteSkinManifestCollectorResourcesView(objStream, objArguments);
				}
			}
			else
			{
				WriteSkinManifestCollectorsView(objStream, objArguments);
			}
		}

		private void WriteSkinManifestCollectorResourcesView(Stream objStream, NameValueCollection objArguments)
		{
			string text = objArguments["collector"];
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinCollector skinCollector = mobjGlobalScope.Collectors[text];
				if (skinCollector != null)
				{
					HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objStream));
					WriteSkinManifestHeader(htmlTextWriter, "Collector Resources");
					htmlTextWriter.WriteFullBeginTag("table");
					htmlTextWriter.WriteFullBeginTag("tr");
					htmlTextWriter.WriteBeginTag("td");
					htmlTextWriter.WriteAttribute("colspan", "5");
					htmlTextWriter.Write($">Collector: {text}");
					htmlTextWriter.Write(" (");
					WriteSkinManifestViewLink(htmlTextWriter, "theme", "collectors", mstrTheme, null, null);
					htmlTextWriter.Write(" , ");
					htmlTextWriter.Write($"<a href='Resources.{skinCollector.Name}{mobjConfig.DynamicExtension}'>content</a>");
					htmlTextWriter.Write(")");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteEndTag("tr");
					htmlTextWriter.Write("\n");
					htmlTextWriter.WriteFullBeginTag("tr");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write("Name");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write("Type");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write("Presentation");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write("Presentation Engine");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write("Presentation Role");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteEndTag("tr");
					htmlTextWriter.Write("\n");
					foreach (KeyValuePair<string, SkinCollectorResource> item in skinCollector)
					{
						FileResource resource = item.Value.Resource;
						htmlTextWriter.WriteFullBeginTag("tr");
						htmlTextWriter.WriteFullBeginTag("td");
						htmlTextWriter.Write(item.Key);
						if (!(resource is TextResource))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							htmlTextWriter.Write(" (");
							WriteSkinManifestViewLink(htmlTextWriter, "indexes", "indexes", mstrTheme, text, item.Key);
							htmlTextWriter.Write(" , ");
							WriteSkinManifestViewLink(htmlTextWriter, "tokens", "tokens", mstrTheme, text, item.Key);
							htmlTextWriter.Write(" , ");
							WriteSkinManifestViewLink(htmlTextWriter, "content", "content", mstrTheme, text, item.Key);
							htmlTextWriter.Write(")");
						}
						htmlTextWriter.WriteEndTag("td");
						htmlTextWriter.WriteFullBeginTag("td");
						htmlTextWriter.Write(resource.GetType().Name);
						htmlTextWriter.WriteEndTag("td");
						htmlTextWriter.WriteFullBeginTag("td");
						htmlTextWriter.Write(resource.Presentation.ToString());
						htmlTextWriter.WriteEndTag("td");
						htmlTextWriter.WriteFullBeginTag("td");
						htmlTextWriter.Write(resource.PresentationEngine.ToString());
						htmlTextWriter.WriteEndTag("td");
						htmlTextWriter.WriteFullBeginTag("td");
						htmlTextWriter.Write(resource.PresentationRole.ToString());
						htmlTextWriter.WriteEndTag("td");
						htmlTextWriter.WriteEndTag("tr");
						htmlTextWriter.Write("\n");
					}
					htmlTextWriter.WriteEndTag("table");
					htmlTextWriter.Write("\n");
					WriteSkinManifestFooter(htmlTextWriter);
					htmlTextWriter.Flush();
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			throw new HttpException("Controller could not be found.");
		}

		private void WriteSkinManifestCollectorsView(Stream objStream, NameValueCollection objArguments)
		{
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objStream));
			WriteSkinManifestHeader(htmlTextWriter, "Collectors");
			htmlTextWriter.WriteFullBeginTag("table");
			htmlTextWriter.WriteFullBeginTag("tr");
			htmlTextWriter.WriteBeginTag("td");
			htmlTextWriter.WriteAttribute("colspan", "2");
			htmlTextWriter.Write(">");
			htmlTextWriter.Write($"Theme Collectors :{mstrTheme}");
			htmlTextWriter.WriteEndTag("td");
			htmlTextWriter.WriteEndTag("tr");
			htmlTextWriter.Write("\n");
			htmlTextWriter.WriteFullBeginTag("tr");
			htmlTextWriter.WriteFullBeginTag("td");
			htmlTextWriter.Write("Name");
			htmlTextWriter.WriteEndTag("td");
			htmlTextWriter.WriteFullBeginTag("td");
			htmlTextWriter.Write("Type");
			htmlTextWriter.WriteEndTag("td");
			htmlTextWriter.WriteEndTag("tr");
			htmlTextWriter.Write("\n");
			using (Dictionary<string, SkinCollector>.KeyCollection.Enumerator enumerator = mobjGlobalScope.Collectors.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					string current = enumerator.Current;
					SkinCollector skinCollector = mobjGlobalScope.Collectors[current];
					htmlTextWriter.WriteFullBeginTag("tr");
					htmlTextWriter.WriteBeginTag("td");
					htmlTextWriter.Write(">");
					htmlTextWriter.Write($"Resources.{skinCollector.Name}{mobjConfig.DynamicExtension} ");
					htmlTextWriter.Write("(");
					WriteSkinManifestViewLink(htmlTextWriter, "resources", "collector.resources", mstrTheme, skinCollector.Name, null);
					htmlTextWriter.Write(",");
					htmlTextWriter.Write($"<a href='Resources.{skinCollector.Name}{mobjConfig.DynamicExtension}'>content</a>");
					htmlTextWriter.Write(")");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteFullBeginTag("td");
					htmlTextWriter.Write(skinCollector.GetType().Name);
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteEndTag("tr");
					htmlTextWriter.Write("\n");
				}
			}
			htmlTextWriter.WriteEndTag("table");
			WriteSkinManifestFooter(htmlTextWriter);
			htmlTextWriter.Flush();
		}

		private void WriteSkinManifestScopesView(Stream objStream, NameValueCollection objArguments)
		{
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objStream));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("function toggleView(id) {");
			stringBuilder.AppendLine("  var element = document.getElementById(id);");
			stringBuilder.AppendLine("  if(element.style.display == 'none')");
			stringBuilder.AppendLine("      element.style.display = 'block';");
			stringBuilder.AppendLine("  else");
			stringBuilder.AppendLine("      element.style.display = 'none';");
			stringBuilder.AppendLine("}");
			WriteSkinManifestHeader(htmlTextWriter, "Scopes", stringBuilder.ToString());
			WriteSkinManifestScope(htmlTextWriter, mobjGlobalScope);
			WriteSkinManifestFooter(htmlTextWriter);
			htmlTextWriter.Flush();
		}

		private void WriteSkinManifestScope(HtmlTextWriter objWriter, SkinScope scope)
		{
			if (scope == null)
			{
				return;
			}
			/*OpCode not supported: LdMemberToken*/;
			if (!scope.IsCompiled)
			{
				scope.Compile();
			}
			objWriter.WriteBeginTag("div");
			objWriter.WriteAttribute("style", "border-left: 5px solid #666; border-top: 1px solid #666; margin: 10px 0px 0px 10px; padding: 10px 0px 0px 10px;");
			objWriter.Write(">");
			int num;
			if (scope.ScriptMembers != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (scope.CssMembers == null)
			{
				num = ((scope.XsltMembers != null) ? 1 : 0);
				goto IL_006e;
			}
			num = 1;
			goto IL_006e;
			IL_006e:
			string text = string.Empty;
			objWriter.WriteBeginTag("div");
			if (num != 0)
			{
				text = "cursor: pointer; background: #ddd;";
				objWriter.WriteAttribute("onclick", "toggleView('" + scope.ID + "')");
			}
			objWriter.WriteAttribute("style", "font-weight: bold; padding: 5px;" + text);
			objWriter.Write(">");
			objWriter.Write("{0}", scope.Name);
			if (scope.Skins.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.Write(" ({0})", scope.Skins.Count);
			}
			objWriter.WriteEndTag("div");
			if (num == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteBeginTag("table");
				objWriter.WriteAttribute("style", "display: none; width: 100%;");
				objWriter.WriteAttribute("id", scope.ID);
				objWriter.Write(">");
				objWriter.WriteBeginTag("tr");
				objWriter.WriteAttribute("style", "font-weight: bold; background: #eee");
				objWriter.Write(">");
				objWriter.WriteFullBeginTag("td");
				objWriter.Write("Script Members");
				objWriter.WriteEndTag("td");
				objWriter.WriteFullBeginTag("td");
				objWriter.Write("Css Members");
				objWriter.WriteEndTag("td");
				objWriter.WriteFullBeginTag("td");
				objWriter.Write("Xslt Members");
				objWriter.WriteEndTag("td");
				objWriter.WriteEndTag("tr");
				objWriter.WriteFullBeginTag("tr");
				WriteSkinManifestScopeMembers(objWriter, scope.ScriptMembers);
				WriteSkinManifestScopeMembers(objWriter, scope.CssMembers);
				WriteSkinManifestScopeMembers(objWriter, scope.XsltMembers);
				objWriter.WriteEndTag("tr");
				objWriter.WriteEndTag("table");
			}
			using (List<SkinScope>.Enumerator enumerator = scope.Skins.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					SkinScope current = enumerator.Current;
					WriteSkinManifestScope(objWriter, current);
				}
			}
			objWriter.WriteEndTag("div");
		}

		private static void WriteSkinManifestScopeMembers(HtmlTextWriter objWriter, KB.ReadOnlyMembersCollection members)
		{
			objWriter.WriteBeginTag("td");
			objWriter.WriteAttribute("valign", "top");
			objWriter.Write(">");
			if (members == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string[] allKeys = members.AllKeys;
				for (int i = 0; i < allKeys.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = allKeys[i];
					objWriter.Write("{0} = {1}", text, members[text]);
					objWriter.Write("<br />");
				}
			}
			objWriter.WriteEndTag("td");
		}

		internal static void WriteSkinManifestHeader(HtmlTextWriter objWriter, string strTitle)
		{
			WriteSkinManifestHeader(objWriter, strTitle, null);
		}

		internal static void WriteSkinManifestHeader(HtmlTextWriter objWriter, string strTitle, string script)
		{
			objWriter.WriteLine("<!DOCTYPE html>");
			objWriter.WriteFullBeginTag("html");
			objWriter.WriteFullBeginTag("head");
			objWriter.WriteFullBeginTag("title");
			objWriter.Write(strTitle);
			objWriter.WriteEndTag("title");
			objWriter.WriteLine();
			objWriter.WriteFullBeginTag("style");
			objWriter.Write("body, table, td { font-family: Arial; font-size: 12px; }");
			objWriter.WriteEndTag("style");
			objWriter.WriteLine();
			if (string.IsNullOrEmpty(script))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteLine();
				objWriter.WriteBeginTag("script");
				objWriter.WriteAttribute("language", "javascript");
				objWriter.Write(">");
				objWriter.Write(script);
				objWriter.WriteEndTag("script");
				objWriter.WriteLine();
			}
			objWriter.WriteEndTag("head");
			objWriter.WriteEndTag("html");
			objWriter.WriteBeginTag("body");
			objWriter.WriteAttribute("style", "font-family:tahoma;font-size:12px/18px;");
			objWriter.Write(">");
		}

		internal static void WriteSkinManifestFooter(HtmlTextWriter objWriter)
		{
			objWriter.WriteEndTag("body");
			objWriter.WriteEndTag("html");
		}
	}
}
