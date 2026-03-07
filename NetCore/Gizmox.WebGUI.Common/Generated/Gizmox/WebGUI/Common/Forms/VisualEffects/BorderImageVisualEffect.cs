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

namespace Gizmox.WebGUI.Common.Forms.VisualEffects
{
	[Serializable]
	[TypeConverter(typeof(BorderImageVisualEffectTypeConverter))]
	public class BorderImageVisualEffect : VisualEffect
	{
		private BorderRepeat menmHorizontalRepeat;

		private BorderRepeat menmVerticalRepeat;

		private int mintBorderSizeBottom = -1;

		private int mintBorderSizeLeft = -1;

		private int mintBorderSizeRight = -1;

		private int mintBorderSizeTop = -1;

		private bool mblnBorderSizeAll;

		private int mintOffsetBottom;

		private int mintOffsetLeft;

		private int mintOffsetRight;

		private int mintOffsetTop;

		private bool mblnOffsetAll;

		private ResourceHandle mobjBorderImage;

		private string mstrFrameBorderDefinition;

		private ImageResourceReference mobjMainBorderImage;

		[Category("Border Image")]
		public ResourceHandle BorderImage
		{
			get
			{
				return mobjBorderImage;
			}
			set
			{
				mobjBorderImage = value;
			}
		}

		[Category("Border Image")]
		public ImageResourceReference MainBorderImage
		{
			get
			{
				return mobjMainBorderImage;
			}
			set
			{
				mobjMainBorderImage = value;
				if (value != null)
				{
					mstrFrameBorderDefinition = string.Empty;
				}
			}
		}

		[Editor("Gizmox.WebGUI.Forms.Design.FrameStylePickerEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Category("Border Image")]
		public string FrameBorderImage
		{
			get
			{
				if (string.IsNullOrEmpty(mstrFrameBorderDefinition))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string[] array = mstrFrameBorderDefinition.Split('@');
					if (array.Length == 2)
					{
						return array[0];
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return string.Empty;
			}
			set
			{
				mstrFrameBorderDefinition = value;
				if (string.IsNullOrEmpty(value))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjMainBorderImage = null;
				}
			}
		}

		private string FrameBorderImageSkinType
		{
			get
			{
				if (string.IsNullOrEmpty(mstrFrameBorderDefinition))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string[] array = mstrFrameBorderDefinition.Split('@');
					if (array.Length == 2)
					{
						return array[1];
					}
				}
				return string.Empty;
			}
		}

		private string FrameBorderDefinition => mstrFrameBorderDefinition;

		[Category("Border Size")]
		public int BorderSizeAll
		{
			get
			{
				if (mintBorderSizeBottom != mintBorderSizeRight)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderSizeBottom != mintBorderSizeLeft)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderSizeBottom != mintBorderSizeTop)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (mintBorderSizeBottom == -1)
					{
						return OffsetAll;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				if (mblnBorderSizeAll)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintBorderSizeTop;
				}
				return -1;
			}
			set
			{
				if (mblnBorderSizeAll && mintBorderSizeTop == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnBorderSizeAll = true;
				mintBorderSizeTop = (mintBorderSizeLeft = (mintBorderSizeRight = (mintBorderSizeBottom = value)));
			}
		}

		[Category("Border Size")]
		public int BorderSizeBottom
		{
			get
			{
				if (mintBorderSizeBottom != -1)
				{
					return mintBorderSizeBottom;
				}
				return mintOffsetBottom;
			}
			set
			{
				if (value >= 0)
				{
					if (mblnBorderSizeAll)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mintBorderSizeBottom == value)
					{
						return;
					}
					mblnBorderSizeAll = false;
					mintBorderSizeBottom = value;
				}
			}
		}

		[Category("Border Size")]
		public int BorderSizeLeft
		{
			get
			{
				if (mintBorderSizeLeft == -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintOffsetLeft;
				}
				return mintBorderSizeLeft;
			}
			set
			{
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (mblnBorderSizeAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderSizeLeft == value)
				{
					return;
				}
				mblnBorderSizeAll = false;
				mintBorderSizeLeft = value;
			}
		}

		[Category("Border Size")]
		public int BorderSizeRight
		{
			get
			{
				if (mintBorderSizeRight == -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintOffsetRight;
				}
				return mintBorderSizeRight;
			}
			set
			{
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (mblnBorderSizeAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderSizeRight == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnBorderSizeAll = false;
				mintBorderSizeRight = value;
			}
		}

		[Category("Border Size")]
		public int BorderSizeTop
		{
			get
			{
				if (mintBorderSizeTop == -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintOffsetTop;
				}
				return mintBorderSizeTop;
			}
			set
			{
				if (value >= 0)
				{
					if (mblnBorderSizeAll)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mintBorderSizeTop == value)
					{
						return;
					}
					mblnBorderSizeAll = false;
					mintBorderSizeTop = value;
				}
			}
		}

		[Category("Border Repeat")]
		public BorderRepeat HorizontalRepeat
		{
			get
			{
				return menmHorizontalRepeat;
			}
			set
			{
				menmHorizontalRepeat = value;
			}
		}

		[Category("Border Offset")]
		public int OffsetAll
		{
			get
			{
				if (mblnOffsetAll)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintOffsetTop;
				}
				return -1;
			}
			set
			{
				if (!mblnOffsetAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintOffsetLeft == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnOffsetAll = true;
				mintOffsetTop = (mintOffsetLeft = (mintOffsetRight = (mintOffsetBottom = value)));
			}
		}

		[Category("Border Offset")]
		public int OffsetBottom
		{
			get
			{
				return mintOffsetBottom;
			}
			set
			{
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (mblnOffsetAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintOffsetBottom == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnOffsetAll = false;
				mintOffsetBottom = value;
			}
		}

		[Category("Border Offset")]
		public int OffsetLeft
		{
			get
			{
				return mintOffsetLeft;
			}
			set
			{
				if (value >= 0)
				{
					if (mblnOffsetAll)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mintOffsetLeft == value)
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
					mblnOffsetAll = false;
					mintOffsetLeft = value;
				}
			}
		}

		[Category("Border Offset")]
		public int OffsetRight
		{
			get
			{
				return mintOffsetRight;
			}
			set
			{
				if (value >= 0 && (mblnOffsetAll || mintOffsetRight != value))
				{
					mblnOffsetAll = false;
					mintOffsetRight = value;
				}
			}
		}

		[Category("Border Offset")]
		public int OffsetTop
		{
			get
			{
				return mintOffsetTop;
			}
			set
			{
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (mblnOffsetAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintOffsetTop == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnOffsetAll = false;
				mintOffsetTop = value;
			}
		}

		[Category("Border Repeat")]
		public BorderRepeat VerticalRepeat
		{
			get
			{
				return menmVerticalRepeat;
			}
			set
			{
				menmVerticalRepeat = value;
			}
		}

		protected internal override bool IsValid
		{
			get
			{
				int num = 1 & (((BorderSizeBottom | BorderSizeLeft | BorderSizeRight | BorderSizeTop | OffsetBottom | OffsetLeft | OffsetRight | OffsetTop) != 0) ? 1 : 0);
				int num2;
				if (BorderImage != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (string.IsNullOrEmpty(FrameBorderImage))
					{
						num2 = ((MainBorderImage != null) ? 1 : 0);
						goto IL_0083;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				num2 = 1;
				goto IL_0083;
				IL_0083:
				return (byte)(num & num2) != 0;
			}
		}

		public BorderImageVisualEffect(ResourceHandle objBorderImage, int intOffsetTop, int intOffsetRight, int intOffsetBottom, int intOffsetLeft, int enmHorizontalRepeat, int enmVerticalRepeat, int intBorderSizeTop, int intBorderSizeRight, int intBorderSizeBottom, int intBorderSizeLeft)
		{
			mobjBorderImage = objBorderImage;
			mintOffsetTop = intOffsetTop;
			mintOffsetRight = intOffsetRight;
			mintOffsetBottom = intOffsetBottom;
			mintOffsetLeft = intOffsetLeft;
			menmHorizontalRepeat = (BorderRepeat)enmHorizontalRepeat;
			menmVerticalRepeat = (BorderRepeat)enmVerticalRepeat;
			mintBorderSizeTop = intBorderSizeTop;
			mintBorderSizeRight = intBorderSizeRight;
			mintBorderSizeBottom = intBorderSizeBottom;
			mintBorderSizeLeft = intBorderSizeLeft;
			mblnBorderSizeAll = mintBorderSizeTop == mintBorderSizeLeft && mintBorderSizeTop == mintBorderSizeRight && mintBorderSizeTop == mintBorderSizeBottom;
			int num;
			if (mintOffsetTop != mintOffsetLeft)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mintOffsetTop == mintOffsetRight)
				{
					num = ((mintOffsetTop == mintOffsetBottom) ? 1 : 0);
					goto IL_00ec;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			num = 0;
			goto IL_00ec;
			IL_00ec:
			mblnOffsetAll = (byte)num != 0;
		}

		public BorderImageVisualEffect()
		{
		}

		public static implicit operator BorderImageVisualEffect(string strBorderImageVisualEffect)
		{
			new BorderImageVisualEffect().InitializeFromString(strBorderImageVisualEffect);
			return strBorderImageVisualEffect;
		}

		public override object[] GetConstroctorArguments()
		{
			return GetAllPropertiesList(blnAppendTypeNameProperty: false).ToArray();
		}

		public override string ToString()
		{
			return CommonUtils.Join("|", GetAllPropertiesList(blnAppendTypeNameProperty: true).ToArray()) + ";";
		}

		public override string ToString(IContext objContext)
		{
			List<object> borderImageParameters = GetBorderImageParameters(blnRuntimeParameters: true, objContext);
			borderImageParameters.Insert(0, GetBasePropertyPrefixByContext(objContext));
			return string.Format("{0}border-image:url({1}) {2} {3} {4} {5} {6} {7};", borderImageParameters.ToArray()) + string.Format("border-width:{0}px {1}px {2}px {3}px;", GetBorderWidthParametersArray().ToArray()) + "border-style:solid;border-color:transparent;";
		}

		internal override string GetBasePropertyPrefixByContext(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string text = contextParams.Browser.ToLower();
				if (text == "ie")
				{
					return string.Empty;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return base.GetBasePropertyPrefixByContext(objContext);
		}

		public bool IsBorderSizeClear()
		{
			if (mintBorderSizeBottom != mintBorderSizeRight)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mintBorderSizeBottom != mintBorderSizeLeft)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mintBorderSizeBottom != mintBorderSizeTop)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mintBorderSizeBottom == -1)
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private List<object> GetAllPropertiesList(bool blnAppendTypeNameProperty)
		{
			List<object> borderImageParameters = GetBorderImageParameters(blnRuntimeParameters: false, null);
			borderImageParameters.AddRange(GetBorderWidthParametersArray());
			if (!blnAppendTypeNameProperty)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				borderImageParameters.Insert(0, typeof(BorderImageVisualEffect).FullName);
			}
			return borderImageParameters;
		}

		private List<object> GetBorderImageParameters(bool blnRuntimeParameters, IContext objContext)
		{
			object obj = menmHorizontalRepeat;
			object obj2 = menmVerticalRepeat;
			if (blnRuntimeParameters)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = Convert.ToInt32(menmHorizontalRepeat);
				obj2 = Convert.ToInt32(menmVerticalRepeat);
			}
			object obj3 = BorderImage;
			if (obj3 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (MainBorderImage == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					obj3 = ((!blnRuntimeParameters) ? MainBorderImage.ResourceData.Replace(';', '%') : MainBorderImage.GetValue(objContext));
				}
				if (obj3 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string frameBorderImage = FrameBorderImage;
					string frameBorderImageSkinType = FrameBorderImageSkinType;
					if (!string.IsNullOrEmpty(frameBorderImage) && !string.IsNullOrEmpty(frameBorderImageSkinType))
					{
						if (!blnRuntimeParameters)
						{
							/*OpCode not supported: LdMemberToken*/;
							obj3 = FrameBorderDefinition;
						}
						else
						{
							obj3 = $"framestyleimage.{FrameBorderImage}{ConfigHelper.DynamicExtension}?skin={HttpUtility.UrlEncode(FrameBorderImageSkinType)}";
						}
					}
				}
			}
			List<object> list = new List<object>();
			list.AddRange(new object[7] { obj3, mintOffsetTop, mintOffsetRight, mintOffsetBottom, mintOffsetLeft, obj, obj2 });
			return list;
		}

		protected internal override List<Type> GetConstructorTypes()
		{
			List<Type> list = new List<Type>();
			list.AddRange(new Type[11]
			{
				typeof(ResourceHandle),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int)
			});
			return list;
		}

		private List<object> GetBorderWidthParametersArray()
		{
			List<object> list = new List<object>();
			list.AddRange(new object[4] { BorderSizeTop, BorderSizeRight, BorderSizeBottom, BorderSizeLeft });
			return list;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length != 12)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!array[1].Contains("@"))
			{
				/*OpCode not supported: LdMemberToken*/;
				MainBorderImage = new ImageResourceReference(array[1].Replace('%', ';'));
			}
			else
			{
				FrameBorderImage = array[1];
			}
			mintOffsetTop = int.Parse(array[2]);
			mintOffsetRight = int.Parse(array[3]);
			mintOffsetBottom = int.Parse(array[4]);
			mintOffsetLeft = int.Parse(array[5]);
			menmHorizontalRepeat = (BorderRepeat)int.Parse(array[6]);
			menmVerticalRepeat = (BorderRepeat)int.Parse(array[7]);
			mintBorderSizeTop = int.Parse(array[8]);
			mintBorderSizeRight = int.Parse(array[9]);
			mintBorderSizeBottom = int.Parse(array[10]);
			mintBorderSizeLeft = int.Parse(array[11]);
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BorderImage) == CSS3BrowserCapabilities.BorderImage;
		}

		public override object Clone()
		{
			BorderImageVisualEffect borderImageVisualEffect = base.Clone() as BorderImageVisualEffect;
			CloneInternal(borderImageVisualEffect);
			return borderImageVisualEffect;
		}

		private void CloneInternal(BorderImageVisualEffect objNew)
		{
			objNew.menmHorizontalRepeat = menmHorizontalRepeat;
			objNew.menmVerticalRepeat = menmVerticalRepeat;
			objNew.mintBorderSizeBottom = mintBorderSizeBottom;
			objNew.mintBorderSizeLeft = mintBorderSizeLeft;
			objNew.mintBorderSizeRight = mintBorderSizeRight;
			objNew.mintBorderSizeTop = mintBorderSizeTop;
			objNew.mblnBorderSizeAll = mblnBorderSizeAll;
			objNew.mintOffsetBottom = mintOffsetBottom;
			objNew.mintOffsetLeft = mintOffsetLeft;
			objNew.mintOffsetRight = mintOffsetRight;
			objNew.mintOffsetTop = mintOffsetTop;
			objNew.mblnOffsetAll = mblnOffsetAll;
			objNew.mobjBorderImage = mobjBorderImage;
			objNew.mstrFrameBorderDefinition = mstrFrameBorderDefinition;
			objNew.mobjMainBorderImage = mobjMainBorderImage;
		}
	}
}
