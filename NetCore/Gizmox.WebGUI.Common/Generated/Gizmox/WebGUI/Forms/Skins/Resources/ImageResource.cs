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
	public class ImageResource : BinaryResource
	{
		public override string Filter => "Image Files|*.jpg;*.jpeg;*.gif;*.png";

		public override Type FilterType => typeof(Bitmap);

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Bitmap Value
		{
			get
			{
				if (ImageContentIndex == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return ImageContentIndex.Image;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Height
		{
			get
			{
				if (ImageContentIndex == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return 0;
				}
				return ImageContentIndex.ImageHeight;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Width
		{
			get
			{
				if (ImageContentIndex == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return 0;
				}
				return ImageContentIndex.ImageWidth;
			}
		}

		private IB ImageContentIndex => base.ContentIndex as IB;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Presentation Presentation
		{
			get
			{
				return Presentation.Agnostic;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override PresentationRole PresentationRole
		{
			get
			{
				return PresentationRole.Custom;
			}
			set
			{
			}
		}

		public override Type CompilerCollectorType => typeof(ImageCollector);

		public override Type CompilerContentType => typeof(ImageContent);

		public override Type CompilerIndexType => typeof(IB);

		[Browsable(false)]
		public ImageFormat ImageFormat
		{
			get
			{
				string text = Path.GetExtension(base.FileName).ToLowerInvariant();
				uint num = SC.ComputeStringHash(text);
				if (num > 1128223456)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num <= 1388056268)
					{
						if (num == 1384894805)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (text == ".gif")
							{
								/*OpCode not supported: LdMemberToken*/;
								return ImageFormat.Gif;
							}
						}
						else if (num == 1388056268 && text == ".jpg")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_017a;
						}
					}
					else if (num != 1928100785)
					{
						if (num == 4178554255u && text == ".jpeg")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_017a;
						}
					}
					else if (text == ".wmf")
					{
						/*OpCode not supported: LdMemberToken*/;
						return ImageFormat.Wmf;
					}
				}
				else
				{
					switch (num)
					{
					case 175576948u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(text == ".bmp"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return ImageFormat.Bmp;
					case 850093434u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(text == ".ico"))
						{
							break;
						}
						return ImageFormat.Icon;
					case 1128223456u:
						if (!(text == ".png"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return ImageFormat.Png;
					}
				}
				return ImageFormat.Gif;
				IL_017a:
				return ImageFormat.Jpeg;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string NewFileExtension => "gif";

		public ImageResource()
		{
		}

		public ImageResource(ImageResource objResource)
			: base(objResource)
		{
		}

		protected override SkinResource Clone()
		{
			return new ImageResource(this);
		}
	}
}
