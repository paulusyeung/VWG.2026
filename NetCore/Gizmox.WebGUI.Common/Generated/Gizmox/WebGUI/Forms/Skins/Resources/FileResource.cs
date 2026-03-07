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
	public class FileResource : SkinResource
	{
		private string mstrFileName = "";

		private string mstrAccessName = "";

		private string mstrUserAgentRegEx = "";

		private string mstrContentType = "";

		private object mobjContent;

		private FileIndex mobjContentIndex;

		[Browsable(false)]
		public string FileName
		{
			get
			{
				return mstrFileName;
			}
			set
			{
				mstrFileName = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Behavior")]
		[Description("Gets or sets an access name for this resource.\nThe Access Name is used by the server to access the specified resource. One Access Name can be applied to several different resources. This enables you to route parallel resources to different browsers from one resource file, using the \"[Skin.Path]'AccessName'Context.DynamicExtension\" pattern.")]
		[DefaultValue("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual string AccessName
		{
			get
			{
				return mstrAccessName;
			}
			set
			{
				mstrAccessName = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue("")]
		[Description("Gets or sets a regular expression which will be enforced on the resource's request's user agent.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Presentation")]
		public virtual string UserAgentRegEx
		{
			get
			{
				return mstrUserAgentRegEx;
			}
			set
			{
				if (!(mstrUserAgentRegEx != value))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (new Regex(value) == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrUserAgentRegEx = value;
				}
			}
		}

		[Browsable(false)]
		public string ContentType
		{
			get
			{
				return mstrContentType;
			}
			set
			{
				mstrContentType = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual string Size => $"{ContentLength / 8 / 1024}Kb";

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string FileExtension => Path.GetExtension(mstrFileName);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string NewFileExtension => string.Empty;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string Filter => "All Files(*.*)|*.*";

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual Type FilterType => typeof(string);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public object Content
		{
			get
			{
				if (mobjContent is FileResourceContentReference fileResourceContentReference)
				{
					return fileResourceContentReference.Content;
				}
				return mobjContent;
			}
			set
			{
				mobjContent = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Stream ContentStream
		{
			get
			{
				if (ContentIndex != null)
				{
					return ContentIndex.ContentStream;
				}
				return null;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		private Stream IndexedStream
		{
			get
			{
				Stream stream = null;
				object content = Content;
				if (content == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stream = content as Stream;
					if (stream != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!(content.GetType().Name == "ResXFileRef"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						TypeConverter converter = TypeDescriptor.GetConverter(content);
						if (converter == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stream = converter.ConvertFrom(content.ToString()) as Stream;
						}
					}
				}
				return stream;
			}
		}

		internal FileIndex ContentIndex
		{
			get
			{
				if (mobjContentIndex != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Stream indexedStream = IndexedStream;
					if (indexedStream == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjContentIndex = CreateContentIndex(indexedStream);
					}
				}
				return mobjContentIndex;
			}
		}

		internal int ContentLength
		{
			get
			{
				if (ContentIndex != null)
				{
					return ContentIndex.ContentLength;
				}
				return 0;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Type CompilerCollectorType => typeof(FileCollector);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Type CompilerContentType => typeof(FileContent);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual Type CompilerIndexType => typeof(FileIndex);

		internal virtual bool IsCompileEnabled => false;

		public FileResource()
		{
		}

		public FileResource(FileResource objResource)
			: base(objResource)
		{
			mobjContent = objResource.mobjContent;
			mstrContentType = objResource.mstrContentType;
			mstrFileName = objResource.mstrFileName;
			mstrAccessName = objResource.mstrAccessName;
			mstrUserAgentRegEx = objResource.mstrUserAgentRegEx;
		}

		internal virtual void WriteContent(SkinScope objSkinScope, Stream objStream, BB objCollector)
		{
			FileIndex contentIndex = ContentIndex;
			if (contentIndex == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contentIndex.WriteContent(objSkinScope, objStream, objCollector);
			}
		}

		internal virtual void WriteContent(SkinScope objSkinScope, StreamWriter objStreamWriter, BB objCollector)
		{
			FileIndex contentIndex = ContentIndex;
			if (contentIndex == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contentIndex.WriteContent(objSkinScope, objStreamWriter, objCollector);
			}
		}

		protected override SkinResource Clone()
		{
			return new FileResource(this);
		}

		internal void DumpIndexes(Stream objStream)
		{
			ContentIndex?.DumpIndexes(objStream);
		}

		internal void DumpTokens(Stream objStream)
		{
			FileIndex contentIndex = ContentIndex;
			if (contentIndex == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contentIndex.DumpTokens(objStream);
			}
		}

		internal void DumpContent(Stream objStream)
		{
			ContentIndex?.DumpContent(objStream);
		}

		internal virtual void Compile(MB objSkinScope)
		{
		}

		protected override PropertyDescriptorCollection GetProperties(PropertyDescriptorCollection objProperties)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(objProperties);
			if (PresentationRole == PresentationRole.Custom)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (propertyDescriptorCollection != null)
			{
				List<PropertyDescriptor> list = new List<PropertyDescriptor>();
				{
					IEnumerator enumerator = propertyDescriptorCollection.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							PropertyDescriptor propertyDescriptor = (PropertyDescriptor)enumerator.Current;
							if (!(propertyDescriptor.Name != "AccessName"))
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
				}
				propertyDescriptorCollection = new PropertyDescriptorCollection(list.ToArray());
			}
			return propertyDescriptorCollection;
		}

		internal virtual FileIndex CreateContentIndex(Stream objIndexedStream)
		{
			if (objIndexedStream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return Activator.CreateInstance(CompilerIndexType, objIndexedStream) as FileIndex;
		}
	}
}
