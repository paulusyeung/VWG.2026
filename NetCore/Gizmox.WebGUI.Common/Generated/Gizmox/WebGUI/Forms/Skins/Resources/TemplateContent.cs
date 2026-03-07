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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TemplateContent : XmlFileContent
	{
		public TemplateContent(Stream objStream)
			: base(GetConvertedTemplateContent(objStream))
		{
		}

		private static Stream GetConvertedTemplateContent(Stream objStream)
		{
			if (objStream != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				objStream.Position = 0L;
				byte[] array = new byte[objStream.Length];
				objStream.Read(array, 0, Convert.ToInt32(objStream.Length));
				string text = Encoding.UTF8.GetString(array);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.PreserveWhitespace = true;
				int num = text.IndexOf("<");
				if (num > 0)
				{
					text = text.Remove(0, num);
				}
				text = text.Replace("&#", "VWGXsltNumberPrefix");
				xmlDocument.LoadXml(text);
				XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
				xmlNamespaceManager.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
				new StringWriter();
				bool flag = false;
				{
					IEnumerator enumerator = xmlDocument.DocumentElement.SelectNodes("xsl:template", xmlNamespaceManager).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							XmlNode xmlNode = (XmlNode)enumerator.Current;
							if (!(xmlNode is XmlElement xmlElement))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							bool flag2 = false;
							bool flag3 = false;
							MatchCollection matchCollection = new Regex("background-image[\\s]*[:]+[\\s]*[url]+[\\s]*[(]+[\\s]*[']?(?<URL>[^'^)]+)[']?[\\s]*[)]+", RegexOptions.IgnoreCase).Matches(xmlNode.InnerXml);
							if (matchCollection.Count > 0)
							{
								MatchCollection arrStyleMatches = new Regex(string.Format("style[\\s]*=[\\s]*['{0}]+(?<STYLE>[^'^{0}]+)", "\""), RegexOptions.IgnoreCase).Matches(xmlNode.InnerXml);
								flag3 = true;
								for (int num2 = matchCollection.Count - 1; num2 >= 0; num2--)
								{
									Group obj = matchCollection[num2].Groups["URL"];
									if (obj.Value.Contains("$varUrlTheme"))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										bool num3 = IsRegexGroupInStyleMatches(arrStyleMatches, obj);
										string text2 = null;
										if (!num3)
										{
											/*OpCode not supported: LdMemberToken*/;
											text2 = "<xsl:value-of select=\"$varUrlTheme\"/>" + obj.Value;
										}
										else
										{
											text2 = "{$varUrlTheme}" + obj.Value;
										}
										xmlNode.InnerXml = xmlNode.InnerXml.Remove(obj.Index, obj.Length);
										_ = xmlNode.InnerXml;
										xmlNode.InnerXml = xmlNode.InnerXml.Insert(obj.Index, text2);
									}
								}
							}
							XmlNodeList xmlNodeList = xmlElement.SelectNodes(".//xsl:attribute[translate(@name,'SRC','src')='src']", xmlNamespaceManager);
							if (xmlNodeList.Count <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag3 = true;
								IEnumerator enumerator2 = xmlNodeList.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										/*OpCode not supported: LdMemberToken*/;
										XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
										if (xmlNode2.ChildNodes.Count > 0)
										{
											if (!(xmlNode2.ChildNodes[0] is XmlElement xmlElement2))
											{
												/*OpCode not supported: LdMemberToken*/;
											}
											else if (xmlElement2.Attributes["select"] == null)
											{
												/*OpCode not supported: LdMemberToken*/;
											}
											else if (xmlElement2.Attributes["select"].Value == "$varUrlTheme")
											{
												/*OpCode not supported: LdMemberToken*/;
												continue;
											}
										}
										XmlElement xmlElement3 = xmlDocument.CreateElement("xsl", "value-of", "http://www.w3.org/1999/XSL/Transform");
										XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("select");
										xmlAttribute.Value = "$varUrlTheme";
										xmlElement3.Attributes.Append(xmlAttribute);
										xmlNode2.InsertBefore(xmlElement3, xmlNode2.FirstChild);
									}
								}
								finally
								{
									if (!(enumerator2 is IDisposable disposable))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										disposable.Dispose();
									}
								}
							}
							XmlNodeList xmlNodeList2 = xmlElement.SelectNodes(".//*[@src]", xmlNamespaceManager);
							if (xmlNodeList2.Count <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag3 = true;
								IEnumerator enumerator2 = xmlNodeList2.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										if (!((XmlNode)enumerator2.Current is XmlElement xmlElement4))
										{
											/*OpCode not supported: LdMemberToken*/;
											continue;
										}
										string attribute = xmlElement4.GetAttribute("src");
										if (attribute.Contains("$varUrlTheme"))
										{
											/*OpCode not supported: LdMemberToken*/;
											continue;
										}
										string value = "{$varUrlTheme}" + attribute;
										xmlElement4.SetAttribute("src", value);
									}
								}
								finally
								{
									if (!(enumerator2 is IDisposable disposable2))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										disposable2.Dispose();
									}
								}
							}
							XmlNodeList xmlNodeList3 = xmlElement.SelectNodes(".//xsl:attribute[translate(@name,'CLAS','clas')='class']", xmlNamespaceManager);
							if (xmlNodeList3.Count <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag2 = true;
								IEnumerator enumerator2 = xmlNodeList3.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										if (!((XmlNode)enumerator2.Current is XmlElement xmlElement5))
										{
											/*OpCode not supported: LdMemberToken*/;
											continue;
										}
										if (xmlElement5.ChildNodes.Count <= 0)
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else if (!(xmlElement5.ChildNodes[0] is XmlElement xmlElement6))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else if (xmlElement6.Attributes["select"] != null && xmlElement6.Attributes["select"].Value == "$varClassTheme")
										{
											/*OpCode not supported: LdMemberToken*/;
											continue;
										}
										XmlElement xmlElement7 = xmlDocument.CreateElement("xsl", "value-of", "http://www.w3.org/1999/XSL/Transform");
										XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("select");
										xmlAttribute2.Value = "$varClassTheme";
										xmlElement7.Attributes.Append(xmlAttribute2);
										xmlElement5.InsertBefore(xmlElement7, xmlElement5.FirstChild);
									}
								}
								finally
								{
									if (!(enumerator2 is IDisposable disposable3))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										disposable3.Dispose();
									}
								}
							}
							XmlNodeList xmlNodeList4 = xmlElement.SelectNodes(".//*[@class]", xmlNamespaceManager);
							if (xmlNodeList4.Count <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag2 = true;
								{
									IEnumerator enumerator3 = xmlNodeList4.GetEnumerator();
									try
									{
										while (enumerator3.MoveNext())
										{
											/*OpCode not supported: LdMemberToken*/;
											if ((XmlNode)enumerator3.Current is XmlElement xmlElement8)
											{
												string attribute2 = xmlElement8.GetAttribute("class");
												if (attribute2.Contains("$varClassTheme"))
												{
													/*OpCode not supported: LdMemberToken*/;
													continue;
												}
												string value2 = "{$varClassTheme}" + attribute2;
												xmlElement8.SetAttribute("class", value2);
											}
										}
									}
									finally
									{
										IDisposable disposable5 = enumerator3 as IDisposable;
										if (disposable5 != null)
										{
											disposable5.Dispose();
										}
									}
								}
							}
							if (!flag2)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (IsThemeVariableElementExist(xmlElement, xmlNamespaceManager, "Class"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								XmlNode xmlNode3 = xmlElement.SelectSingleNode("xsl:param[last()]", xmlNamespaceManager);
								XmlElement newChild = CreateThemeVariableElement(xmlDocument, "Class");
								if (xmlNode3 != null)
								{
									/*OpCode not supported: LdMemberToken*/;
									xmlElement.InsertAfter(newChild, xmlNode3);
								}
								else
								{
									xmlElement.InsertBefore(newChild, xmlElement.FirstChild);
								}
							}
							if (!flag3)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (IsThemeVariableElementExist(xmlElement, xmlNamespaceManager, "Url"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								XmlNode xmlNode4 = xmlElement.SelectSingleNode("xsl:param[last()]", xmlNamespaceManager);
								XmlElement newChild2 = CreateThemeVariableElement(xmlDocument, "Url");
								if (xmlNode4 == null)
								{
									xmlElement.InsertBefore(newChild2, xmlElement.FirstChild);
								}
								else
								{
									xmlElement.InsertAfter(newChild2, xmlNode4);
								}
							}
							if (!(flag2 || flag3))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								flag = true;
							}
						}
					}
					finally
					{
						IDisposable disposable4 = enumerator as IDisposable;
						if (disposable4 != null)
						{
							disposable4.Dispose();
						}
					}
				}
				if (flag)
				{
					text = xmlDocument.OuterXml;
					text = text.Replace("VWGXsltNumberPrefix", "&#");
					return new MemoryStream(Encoding.UTF8.GetBytes(text))
					{
						Position = 0L
					};
				}
				return objStream;
			}
			return null;
		}

		private static bool IsRegexGroupInStyleMatches(MatchCollection arrStyleMatches, Group objTestUrlGroup)
		{
			IEnumerator enumerator = arrStyleMatches.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Group obj = ((Match)enumerator.Current).Groups["STYLE"];
					if (obj.Index > objTestUrlGroup.Index)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (obj.Index + obj.Length < objTestUrlGroup.Index)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					return true;
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
			return false;
		}

		private static bool IsThemeVariableElementExist(XmlElement objTemplateElement, XmlNamespaceManager objNamespaceManager, string strThemeType)
		{
			string xpath = $".//xsl:variable[@name='var{strThemeType}Theme']";
			XmlNode xmlNode = objTemplateElement.SelectSingleNode(xpath, objNamespaceManager);
			if (xmlNode != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (xmlNode.ChildNodes.Count != 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(xmlNode.ChildNodes[0].Name != "xsl:call-template"))
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = "tplWriteTheme" + strThemeType;
					if (xmlNode.ChildNodes[0].Attributes["name"].Value != text)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		private static XmlElement CreateThemeVariableElement(XmlDocument objXsltDocument, string strThemeType)
		{
			XmlElement xmlElement = objXsltDocument.CreateElement("xsl", "variable", "http://www.w3.org/1999/XSL/Transform");
			XmlAttribute xmlAttribute = objXsltDocument.CreateAttribute("name");
			xmlAttribute.Value = $"var{strThemeType}Theme";
			xmlElement.Attributes.Append(xmlAttribute);
			XmlElement xmlElement2 = objXsltDocument.CreateElement("xsl", "call-template", "http://www.w3.org/1999/XSL/Transform");
			xmlAttribute = objXsltDocument.CreateAttribute("name");
			xmlAttribute.Value = "tplWriteTheme" + strThemeType;
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlElement.AppendChild(xmlElement2);
			return xmlElement;
		}

		protected override TokenReader CreateTokenReader(Stream objStream)
		{
			return new XsltTokenReader(null, objStream);
		}

		protected override void LoadIndex(TokenType enmTokenType, string strTokenContent, int intTokenIndex, int intTokenLength, int intTokenLine, TokenContext objTokenContext)
		{
			if (LoadRootIndex(enmTokenType, intTokenIndex, intTokenLength))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			switch (enmTokenType)
			{
			case TokenType.CssClassDefinition:
				/*OpCode not supported: LdMemberToken*/;
				WriteIndex(FileIndexType.CssClassDefinition, intTokenIndex, intTokenLength);
				break;
			case TokenType.CssClassReference:
				/*OpCode not supported: LdMemberToken*/;
				WriteIndex(FileIndexType.CssClassReference, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltMemberReference:
				WriteIndex(FileIndexType.XsltMemberReference, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltParamDefinition:
				WriteIndex(FileIndexType.XsltParamDefinition, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltTemplateDefinition:
				WriteIndex(FileIndexType.XsltTemplateDefinition, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltTemplateReference:
				WriteIndex(FileIndexType.XsltTemplateReference, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltVariableDefinition:
				WriteIndex(FileIndexType.XsltVariableDefinition, intTokenIndex, intTokenLength);
				break;
			case TokenType.JsVariableDeclatation:
				WriteIndex(FileIndexType.ScriptVariableDeclatation, intTokenIndex, intTokenLength);
				break;
			case TokenType.JsIdentifier:
				WriteIndex(FileIndexType.ScriptIdentifier, intTokenIndex, intTokenLength);
				break;
			case TokenType.JsFunctionDeclatation:
				WriteIndex(FileIndexType.ScriptFunctionDeclatation, intTokenIndex, intTokenLength);
				break;
			case TokenType.JsFunctionArgument:
				WriteIndex(FileIndexType.ScriptFunctionArgument, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltMigrationAttribute:
				WriteIndex(FileIndexType.XsltMigrationAttribute, intTokenIndex, intTokenLength);
				break;
			case TokenType.XsltMigrationNode:
				WriteIndex(FileIndexType.XsltMigrationNode, intTokenIndex, intTokenLength);
				break;
			default:
				base.LoadIndex(enmTokenType, strTokenContent, intTokenIndex, intTokenLength, intTokenLine, objTokenContext);
				break;
			}
		}
	}
}
