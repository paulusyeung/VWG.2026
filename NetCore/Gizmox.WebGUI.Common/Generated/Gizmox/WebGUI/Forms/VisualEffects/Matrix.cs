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

namespace Gizmox.WebGUI.Forms.VisualEffects
{
	[Serializable]
	[TypeConverter(typeof(MatrixTypeConverter))]
	public class Matrix
	{
		private float mfltA;

		private float mfltB;

		private float mfltC;

		private float mfltD;

		private float mfltE;

		private float mfltF;

		[Category("Matrix")]
		public float A
		{
			get
			{
				return mfltA;
			}
			set
			{
				mfltA = value;
			}
		}

		[Category("Matrix")]
		public float B
		{
			get
			{
				return mfltB;
			}
			set
			{
				mfltB = value;
			}
		}

		[Category("Matrix")]
		public float C
		{
			get
			{
				return mfltC;
			}
			set
			{
				mfltC = value;
			}
		}

		[Category("Matrix")]
		public float D
		{
			get
			{
				return mfltD;
			}
			set
			{
				mfltD = value;
			}
		}

		[Category("Matrix")]
		public float E
		{
			get
			{
				return mfltE;
			}
			set
			{
				mfltE = value;
			}
		}

		[Category("Matrix")]
		public float F
		{
			get
			{
				return mfltF;
			}
			set
			{
				mfltF = value;
			}
		}

		public Matrix(float fltA, float fltB, float fltC, float fltD, float fltE, float fltF)
		{
			mfltA = fltA;
			mfltB = fltB;
			mfltC = fltC;
			mfltD = fltD;
			mfltE = fltE;
			mfltF = fltF;
		}

		public Matrix()
		{
			mfltD = (mfltA = 1f);
		}

		public string SerializeToString()
		{
			return CommonUtils.Join(",", mfltA, mfltB, mfltC, mfltD, mfltE, mfltF);
		}

		internal static Matrix DeserializeString(string strValues)
		{
			string[] array = strValues.Split(',');
			Matrix matrix = new Matrix();
			if (array.Length == 6)
			{
				matrix.mfltA = float.Parse(array[0]);
				matrix.mfltB = float.Parse(array[1]);
				matrix.mfltC = float.Parse(array[2]);
				matrix.mfltD = float.Parse(array[3]);
				matrix.mfltE = float.Parse(array[4]);
				matrix.mfltF = float.Parse(array[5]);
				return matrix;
			}
			return null;
		}

		internal string ToHtmlString()
		{
			return $"matrix({A},{B},{C},{D},{E},{F})";
		}
	}
}
