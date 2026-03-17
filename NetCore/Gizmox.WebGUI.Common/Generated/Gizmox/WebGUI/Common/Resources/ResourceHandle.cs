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

namespace Gizmox.WebGUI.Common.Resources
{
	[Serializable]
	[TypeConverter(typeof(ResourceHandleConverter))]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ResourceHandleSerializer, Gizmox.WebGUI.Common.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Editor("Gizmox.WebGUI.Forms.Design.ResourceHandleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public abstract class ResourceHandle : IDisposable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public delegate bool GetThumbnailImageAbort();

		private string mstrFile;

		private object mobjTag;

		private static string mstrRequieredExtension;

		private static string mstrDynamicExtension;

		private static ResourceHandleConverter mobjConverter;

		protected internal virtual bool IsResourceDataSupported => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool CanGetImage => IsResourceDataSupported;

		internal static string RequieredExtension => mstrRequieredExtension;

		internal static string DynamicExtension => mstrDynamicExtension;

		[Editor("Gizmox.WebGUI.Common.Design.ResourceFileEditor, Gizmox.WebGUI.Common.Design", typeof(UITypeEditor))]
		public virtual string File
		{
			get
			{
				return mstrFile;
			}
			set
			{
				mstrFile = value;
			}
		}

		protected Config Config => Config.GetInstance();

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool IsServerResource => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Flags
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Guid[] FrameDimensionsList
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(0)]
		public int Height => LC.GetHeight(this);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public float HorizontalResolution
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ColorPalette Palette
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public SizeF PhysicalDimension
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PixelFormat PixelFormat
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int[] PropertyIdList
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PropertyItem[] PropertyItems
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImageFormat RawFormat
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size Size
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[DefaultValue(null)]
		[TypeConverter(typeof(StringConverter))]
		[Bindable(true)]
		[Localizable(false)]
		public object Tag
		{
			get
			{
				return mobjTag;
			}
			set
			{
				mobjTag = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float VerticalResolution
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(0)]
		public int Width => LC.GetWidth(this);

		static ResourceHandle()
		{
			mstrRequieredExtension = "";
			mstrDynamicExtension = "";
			mobjConverter = new ResourceHandleConverter();
			Config instance = Config.GetInstance();
			if (instance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mstrDynamicExtension = instance.DynamicExtension;
			}
		}

		protected internal virtual string GetUniqueIdentifier()
		{
			return null;
		}

		public override string ToString()
		{
			return GetSpecificResourceHandle();
		}

		public override bool Equals(object objObject)
		{
			if (objObject != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objObject.GetHashCode() == GetHashCode())
				{
					return true;
				}
				if (!(objObject.ToString() == ToString()))
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		protected abstract string GetSpecificResourceHandle();

		public virtual Stream ToStream()
		{
			return null;
		}

		public virtual Image ToImage()
		{
			Stream stream = ToStream();
			if (stream != null)
			{
				return Image.FromStream(stream);
			}
			return null;
		}

		public virtual Icon ToIcon()
		{
			Stream stream = ToStream();
			if (stream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new Icon(stream);
		}

		public static implicit operator ResourceHandle(string strResource)
		{
			return (ResourceHandle)mobjConverter.ConvertFromString(strResource);
		}

		public static implicit operator ResourceHandle(Image objImage)
		{
			return null;
		}

		public static ResourceHandle FromString(string strResourceHandler)
		{
			return mobjConverter.ConvertFromInvariantString(strResourceHandler) as ResourceHandle;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object Clone()
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(disposing: true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void Dispose(bool disposing)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static ResourceHandle FromFile(string filename)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static ResourceHandle FromFile(string filename, bool useEmbeddedColorManagement)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Bitmap FromHbitmap(IntPtr hbitmap)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Bitmap FromHbitmap(IntPtr hbitmap, IntPtr hpalette)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public static Image FromStream(Stream stream)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Image FromStream(Stream stream, bool useEmbeddedColorManagement)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Image FromStream(Stream stream, bool useEmbeddedColorManagement, bool validateImageData)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public RectangleF GetBounds(ref GraphicsUnit pageUnit)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public EncoderParameters GetEncoderParameterList(Guid encoder)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public int GetFrameCount(FrameDimension dimension)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public static int GetPixelFormatSize(PixelFormat pixfmt)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public PropertyItem GetPropertyItem(int propid)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public Image GetThumbnailImage(int thumbWidth, int thumbHeight, GetThumbnailImageAbort callback, IntPtr callbackData)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public static bool IsAlphaPixelFormat(PixelFormat pixfmt)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static bool IsCanonicalPixelFormat(PixelFormat pixfmt)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public static bool IsExtendedPixelFormat(PixelFormat pixfmt)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void RemovePropertyItem(int propid)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void RotateFlip(RotateFlipType rotateFlipType)
		{
			throw new NotImplementedException();
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void Save(string filename)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public void Save(Stream stream, ImageFormat format)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public void Save(string filename, ImageFormat format)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public void Save(Stream stream, ImageCodecInfo encoder, EncoderParameters encoderParams)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void Save(string filename, ImageCodecInfo encoder, EncoderParameters encoderParams)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public void SaveAdd(EncoderParameters encoderParams)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Stream GetPhysicalResourceHandleStream(string strConfiguredDirectory)
		{
			if (Config == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string directory = Config.GetDirectory(strConfiguredDirectory);
				if (directory == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(directory);
					if (directoryInfo == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (directoryInfo.Exists)
						{
							return GetPhysicalResourceHandleStream(directoryInfo);
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Stream GetPhysicalResourceHandleStream(DirectoryInfo objResourceDirectory)
		{
			if (objResourceDirectory != null)
			{
				string physicalFilePath = GetPhysicalFilePath(File, objResourceDirectory.FullName);
				if (System.IO.File.Exists(physicalFilePath))
				{
					return System.IO.File.OpenRead(physicalFilePath);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public void SaveAdd(Image image, EncoderParameters encoderParams)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public int SelectActiveFrame(FrameDimension dimension, int frameIndex)
		{
			throw new NotImplementedException();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public void SetPropertyItem(PropertyItem propitem)
		{
			throw new NotImplementedException();
		}

		public static string GetPhysicalFilePath(string strFile, string strInitDirectory)
		{
			if (!Directory.Exists(strInitDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!string.IsNullOrEmpty(strFile))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!System.IO.File.Exists($"{strInitDirectory}\\{strFile}"))
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = strFile.Substring(0, strFile.IndexOf('.'));
					return GetPhysicalFilePath(strFile.Remove(0, text.Length + 1), $"{strInitDirectory}\\{text}");
				}
				return $"{strInitDirectory}\\{strFile}";
			}
			return string.Empty;
		}
	}
}
