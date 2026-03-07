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
	public class TextIndex : FileIndex
	{
		private CompilerActions G = (CompilerActions)7;

		public CompilerActions CompilerActions
		{
			get
			{
				return G;
			}
			set
			{
				G = value;
			}
		}

		protected override bool UseContentCache => true;

		public TextIndex(Stream objContentStream, CompilerActions enmCompilerActions)
			: base(objContentStream)
		{
			G = enmCompilerActions;
		}

		protected override void ReadCompilerIndexes(StreamReader objStreamReader)
		{
			int num = 0;
			char[] array = new char[1024];
			for (int i = 0; i < base.Indexes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				GB gB = base.Indexes[i];
				if (num >= gB.Index)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					int num2 = gB.Index - num;
					if (array.Length >= num2)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						array = new char[GetOptimizedBufferSize(array.Length, num2)];
					}
					objStreamReader.Read(array, 0, num2);
					num = gB.Index;
				}
				if (gB.Length == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				int length = gB.Length;
				if (array.Length >= length)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array = new char[GetOptimizedBufferSize(array.Length, length)];
				}
				objStreamReader.Read(array, 0, length);
				if (!IsCompilerIndex(gB.Type))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string strContent = new string(array, 0, length);
					ReadCompilerIndex(i, strContent);
				}
				num += length;
			}
		}

		private int GetOptimizedBufferSize(int intExistingLength, int intRequiredLength)
		{
			int num = (int)Math.Ceiling((float)intRequiredLength / (float)intExistingLength);
			int num2 = num;
			num = num2 + num2 % 2;
			return intExistingLength * num;
		}

		protected virtual bool IsCompilerIndex(FileIndexType objIndexType)
		{
			return false;
		}

		internal override void Compile(MB objSkinScope)
		{
			GB[] indexes = base.Indexes;
			for (int i = 0; i < indexes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(indexes[i] is HB hB))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objSkinScope.RegisterResource(hB.Type, hB.Content, CompilerActions);
				}
			}
		}

		internal override void WriteContent(SkinScope objSkinScope, Stream objStream, BB objCollector)
		{
			if (objCollector != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				WriteContent(objSkinScope, new StreamWriter(objStream), objCollector);
			}
			else
			{
				base.WriteContent(objSkinScope, objStream, null);
			}
		}

		internal override void WriteContent(SkinScope objSkinScope, StreamWriter objStreamWriter, BB objCollector)
		{
			if (objCollector == null)
			{
				throw new ArgumentNullException("objCollector", "The collector cannot be null in this method.");
			}
			MB mB = objSkinScope;
			StreamReader streamReader = new StreamReader(base.ContentStream);
			int num = 0;
			GB[] indexes = base.Indexes;
			for (int i = 0; i < indexes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				GB gB = indexes[i];
				if (num >= gB.Index)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					char[] array = new char[gB.Index - num];
					streamReader.Read(array, 0, array.Length);
					objStreamWriter.Write(array);
					num = gB.Index;
				}
				if (gB.Length == 0)
				{
					WriteMarkerContent(objStreamWriter, gB.Type, objCollector);
					continue;
				}
				char[] array2 = new char[gB.Length];
				streamReader.Read(array2, 0, array2.Length);
				num += array2.Length;
				string strContent = new string(array2);
				if (SkinFactory.IsCompilerEnabled)
				{
					mB = GetCurrentScope(mB, gB.Type, strContent);
				}
				OnBeforeWriteContentEvaluateIndex(mB, gB, strContent);
				objStreamWriter.Write(objCollector.EvaluateIndex(mB, gB.Type, strContent, CompilerActions));
			}
			if (streamReader.EndOfStream)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objStreamWriter.Write(streamReader.ReadToEnd());
			}
			objStreamWriter.Flush();
		}

		internal virtual void OnBeforeWriteContentEvaluateIndex(MB objCurrentScope, GB objIndexEntry, string strContent)
		{
		}

		internal virtual MB GetCurrentScope(MB objCurrentScope, FileIndexType enmIndexType, string strContent)
		{
			return objCurrentScope;
		}

		internal virtual void WriteMarkerContent(StreamWriter objStreamWriter, FileIndexType enmMarkerType, BB objCollector)
		{
		}

		public override void DumpIndexes(Stream objStream)
		{
			DumpIndexes(new StreamWriter(objStream));
		}

		private void DumpIndexes(StreamWriter objWriter)
		{
			DumpIndexes(new HtmlTextWriter(objWriter));
		}

		private void DumpIndexes(HtmlTextWriter objWriter)
		{
			DumpIndexesHeader(objWriter);
			DumpIndexesBody(objWriter);
			DumpIndexesFooter(objWriter);
			objWriter.Flush();
			objWriter.Close();
		}

		private void DumpIndexesBody(HtmlTextWriter objWriter)
		{
			StreamReader streamReader = new StreamReader(base.ContentStream);
			int num = 0;
			GB[] indexes = base.Indexes;
			for (int i = 0; i < indexes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				GB gB = indexes[i];
				if (num >= gB.Index)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					char[] array = new char[gB.Index - num];
					streamReader.Read(array, 0, array.Length);
					DumpIndexesContent(objWriter, FileIndexType.Null, new string(array), num, array.Length);
					num = gB.Index;
				}
				if (gB.Length != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					char[] array2 = new char[gB.Length];
					streamReader.Read(array2, 0, array2.Length);
					string strContent = new string(array2);
					DumpIndexesContent(objWriter, gB.Type, strContent, num, array2.Length);
					num += array2.Length;
				}
				else
				{
					DumpMarker(objWriter, gB.Type);
				}
			}
			if (streamReader.EndOfStream)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string text = streamReader.ReadToEnd();
			DumpIndexesContent(objWriter, FileIndexType.Null, text, num, text.Length);
		}

		private void DumpMarker(HtmlTextWriter objWriter, FileIndexType fileIndexType)
		{
			objWriter.WriteBeginTag("span");
			objWriter.WriteAttribute("title", $"{fileIndexType.ToString()} Marker");
			objWriter.WriteAttribute("style", $"color:{CommonUtils.GetWebColor(Color.Red)};");
			objWriter.Write(">");
			objWriter.Write(GetDumpMarker(fileIndexType));
			objWriter.WriteEndTag("span");
		}

		protected virtual string GetDumpMarker(FileIndexType enmFileIndexType)
		{
			return "|";
		}

		private void DumpIndexesContent(HtmlTextWriter objWriter, FileIndexType enmIndexType, string strContent, int intIndex, int intLength)
		{
			Color dumpIndexesForeColor = GetDumpIndexesForeColor(enmIndexType);
			Color dumpIndexesBackColor = GetDumpIndexesBackColor(enmIndexType);
			objWriter.WriteBeginTag("span");
			objWriter.WriteAttribute("title", $"{enmIndexType},{intIndex},{intLength}");
			if (!(dumpIndexesForeColor != Color.Empty) && !(dumpIndexesBackColor != Color.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string arg = string.Empty;
				string arg2 = string.Empty;
				if (!(dumpIndexesForeColor != Color.Empty))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					arg = $"color:{CommonUtils.GetWebColor(dumpIndexesForeColor)};";
				}
				if (!(dumpIndexesBackColor != Color.Empty))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					arg2 = $"background-color:{CommonUtils.GetWebColor(dumpIndexesBackColor)};";
				}
				objWriter.WriteAttribute("style", $"{arg}{arg2}");
			}
			objWriter.Write(">");
			string text = HttpUtility.HtmlEncode(strContent);
			text = text.Replace(" ", "&middot;");
			text = text.Replace("\t", "&#182;&middot;&middot;&middot;");
			text = text.Replace("\r", "");
			text = text.Replace("\n", "&#172;<br/>");
			objWriter.Write(text);
			objWriter.WriteEndTag("span");
		}

		private void DumpIndexesHeader(HtmlTextWriter objWriter)
		{
			objWriter.WriteFullBeginTag("html");
			objWriter.WriteFullBeginTag("head");
			objWriter.WriteEndTag("head");
			objWriter.WriteBeginTag("body");
			objWriter.WriteAttribute("style", "font-size: 10pt; color: black; font-family: 'Courier New';");
			objWriter.Write(">");
		}

		private void DumpIndexesFooter(HtmlTextWriter objWriter)
		{
			objWriter.WriteEndTag("body");
			objWriter.WriteEndTag("html");
		}

		private Color GetDumpIndexesForeColor(FileIndexType enmIndexType)
		{
			switch (enmIndexType)
			{
			case FileIndexType.EventPlaceHolder:
				/*OpCode not supported: LdMemberToken*/;
				goto case FileIndexType.UrlExtension;
			case FileIndexType.XmlRoot:
			case FileIndexType.ScriptVariableDeclatation:
				return Color.Red;
			case FileIndexType.Comment:
				return Color.Green;
			case FileIndexType.UrlExtension:
			case FileIndexType.SkinPlaceHolder:
			case FileIndexType.ContextPlaceHolder:
			case FileIndexType.LabelPlaceHolder:
			case FileIndexType.AttributePlaceHolder:
			case FileIndexType.TagPlaceHolder:
				return Color.Green;
			default:
				return Color.Empty;
			}
		}

		private Color GetDumpIndexesBackColor(FileIndexType enmIndexType)
		{
			switch (enmIndexType)
			{
			case FileIndexType.UrlExtension:
			case FileIndexType.SkinPlaceHolder:
			case FileIndexType.ContextPlaceHolder:
			case FileIndexType.LabelPlaceHolder:
			case FileIndexType.AttributePlaceHolder:
			case FileIndexType.TagPlaceHolder:
			case FileIndexType.EventPlaceHolder:
				return Color.Yellow;
			case FileIndexType.XmlRoot:
				return Color.Yellow;
			case FileIndexType.Whitespace:
				return Color.LightGray;
			case FileIndexType.ScriptFunctionDeclatation:
			case FileIndexType.ScriptFunctionArgument:
			case FileIndexType.ScriptIdentifier:
			case FileIndexType.ScriptVariableDeclatation:
			case FileIndexType.CssClassReference:
			case FileIndexType.CssClassDefinition:
			case FileIndexType.XsltMemberReference:
			case FileIndexType.XsltParamDefinition:
			case FileIndexType.XsltTemplateDefinition:
			case FileIndexType.XsltTemplateReference:
			case FileIndexType.XsltVariableDefinition:
			case FileIndexType.JQTFunctionDeclatation:
			case FileIndexType.JQTFunctionReference:
				return Color.Yellow;
			case FileIndexType.XsltMigrationAttribute:
			case FileIndexType.XsltMigrationNode:
				return Color.LightBlue;
			default:
				return Color.Empty;
			}
		}
	}
}
