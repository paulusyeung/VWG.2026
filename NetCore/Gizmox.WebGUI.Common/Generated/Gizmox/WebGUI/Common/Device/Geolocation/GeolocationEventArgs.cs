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

namespace Gizmox.WebGUI.Common.Device.Geolocation
{
	public class GeolocationEventArgs : DeviceEventArgs
	{
		private double C;

		private double D;

		private double E;

		private double F;

		private double G;

		private double H;

		private double I;

		private string J;

		public double Longitude
		{
			get
			{
				return D;
			}
			set
			{
				D = value;
			}
		}

		public double Altitude
		{
			get
			{
				return E;
			}
			set
			{
				E = value;
			}
		}

		public double AltitudeAccuracy
		{
			get
			{
				return F;
			}
			set
			{
				F = value;
			}
		}

		public double Speed
		{
			get
			{
				return I;
			}
			set
			{
				I = value;
			}
		}

		public double Latitude
		{
			get
			{
				return C;
			}
			set
			{
				C = value;
			}
		}

		public double Heading
		{
			get
			{
				return H;
			}
			set
			{
				H = value;
			}
		}

		public double Accuracy
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

		public string Timestamp
		{
			get
			{
				return J;
			}
			set
			{
				J = value;
			}
		}

		public GeolocationEventArgs(int intErrorCode)
			: base(intErrorCode)
		{
		}

		public GeolocationEventArgs()
		{
		}

		public GeolocationEventArgs(double dblLatitude, double dblLongitude, double dblAltitude, double dblAccuracy, double dblAltitudeAccuracy, double dblHeading, double dblSpeed, string strTimestamp)
			: base(-1)
		{
			C = dblLatitude;
			E = dblAltitude;
			F = dblAltitudeAccuracy;
			D = dblLongitude;
			I = dblSpeed;
			G = dblAccuracy;
			H = dblHeading;
			J = strTimestamp;
		}

		public GeolocationEventArgs(double dblLatitude, double dblLongitude, double dblAltitude, double dblAccuracy, double dblAltitudeAccuracy, double dblHeading, double dblSpeed)
			: this(dblLatitude, dblLongitude, dblAltitude, dblAccuracy, dblAltitudeAccuracy, dblHeading, dblSpeed, string.Empty)
		{
		}
	}
}
