#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
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
using Gizmox.WebGUI.Common.Extensibility;
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
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// Provides static, predefined <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format names. Use them to identify the format of data that you store in an <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see>.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataFormats
	{
		/// Represents a Clipboard format type.</summary>
		[Serializable]
		public class Format
		{
			private readonly int mintId;

			private readonly string mstrName;

			/// Gets the ID number for this format.</summary>
			/// The ID number for this format.</returns>
			public int Id => mintId;

			/// Gets the name of this format.</summary>
			/// The name of this format.</returns>
			public string Name => mstrName;

			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> class with a Boolean that indicates whether a Win32 handle is expected.</summary>
			/// <param name="strName">The name of this format. </param>
			/// <param name="intId">The ID number for this format. </param>
			public Format(string strName, int intId)
			{
				mstrName = strName;
				mintId = intId;
			}
		}

		/// Specifies a Windows bitmap format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Bitmap;

		/// Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets. This format is not used directly by Windows Forms. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string CommaSeparatedValue;

		/// Specifies the Windows device-independent bitmap (DIB) format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Dib;

		/// Specifies the Windows Data Interchange Format (DIF), which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Dif;

		/// Specifies the Windows enhanced metafile format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string EnhancedMetafile;

		/// Specifies the Windows file drop format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string FileDrop;

		/// Specifies text consisting of HTML data. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Html;

		/// Specifies the Windows culture format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Locale;

		/// Specifies the Windows metafile format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string MetafilePict;

		/// Specifies the standard Windows original equipment manufacturer (OEM) text format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string OemText;

		/// Specifies the Windows palette format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Palette;

		/// Specifies the Windows pen data format, which consists of pen strokes for handwriting software; Windows Forms does not use this format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string PenData;

		/// Specifies the Resource Interchange File Format (RIFF) audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Riff;

		/// Specifies text consisting of Rich Text Format (RTF) data. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Rtf;

		/// Specifies a format that encapsulates any type of Windows Forms object. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Serializable;

		/// Specifies the Windows Forms string class format, which Windows Forms uses to store string objects. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string StringFormat;

		/// Specifies the Windows symbolic link format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string SymbolicLink;

		/// Specifies the standard ANSI text format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Text;

		/// Specifies the Tagged Image File Format (TIFF), which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string Tiff;

		/// Specifies the standard Windows Unicode text format. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string UnicodeText;

		/// Specifies the wave audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
		/// 1</filterpriority>
		public static readonly string WaveAudio;

		private static int mintFormatCount;

		private static Format[] marrFormatList;

		private static object mobjInternalSyncObject;

		static DataFormats()
		{
			Text = "Text";
			UnicodeText = "UnicodeText";
			Dib = "DeviceIndependentBitmap";
			Bitmap = "Bitmap";
			EnhancedMetafile = "EnhancedMetafile";
			MetafilePict = "MetaFilePict";
			SymbolicLink = "SymbolicLink";
			Dif = "DataInterchangeFormat";
			Tiff = "TaggedImageFileFormat";
			OemText = "OEMText";
			Palette = "Palette";
			PenData = "PenData";
			Riff = "RiffAudio";
			WaveAudio = "WaveAudio";
			FileDrop = "FileDrop";
			Locale = "Locale";
			Html = "HTML Format";
			Rtf = "Rich Text Format";
			CommaSeparatedValue = "Csv";
			StringFormat = typeof(string).FullName;
			mintFormatCount = 0;
			mobjInternalSyncObject = new object();
		}

		private DataFormats()
		{
		}

		private static void EnsureFormatSpace(int intSize)
		{
			if (marrFormatList == null || marrFormatList.Length <= mintFormatCount + intSize)
			{
				int num = mintFormatCount + 20;
				Format[] array = new Format[num];
				for (int i = 0; i < mintFormatCount; i++)
				{
					array[i] = marrFormatList[i];
				}
				marrFormatList = array;
			}
		}

		private static void EnsurePredefined()
		{
			if (mintFormatCount == 0)
			{
				marrFormatList = new Format[16]
				{
					new Format(UnicodeText, 13),
					new Format(Text, 1),
					new Format(Bitmap, 2),
					new Format(MetafilePict, 3),
					new Format(EnhancedMetafile, 14),
					new Format(Dif, 5),
					new Format(Tiff, 6),
					new Format(OemText, 7),
					new Format(Dib, 8),
					new Format(Palette, 9),
					new Format(PenData, 10),
					new Format(Riff, 11),
					new Format(WaveAudio, 12),
					new Format(SymbolicLink, 4),
					new Format(FileDrop, 15),
					new Format(Locale, 16)
				};
				mintFormatCount = marrFormatList.Length;
			}
		}

		/// Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified ID.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
		/// <param name="id">The format ID. </param>
		/// 1</filterpriority>
		public static Format GetFormat(int id)
		{
			return null;
		}

		/// Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified format.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
		/// <param name="strFormat">The format name. </param>
		/// <exception cref="T:System.ComponentModel.Win32Exception">Registering a new <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format failed. </exception>
		/// 1</filterpriority>
		public static Format GetFormat(string strFormat)
		{
			return null;
		}
	}
}
