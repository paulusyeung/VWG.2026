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
/// Implements a basic data transfer mechanism.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	public class DataObject : IDataObject
	{
		[Serializable]
		private class DataStore : IDataObject
		{
			[Serializable]
			private class DataStoreEntry
			{
				public bool autoConvert;

				public object data;

				public DataStoreEntry(object objData, bool blnAutoConvert)
				{
					data = objData;
					autoConvert = blnAutoConvert;
				}
			}

			private Hashtable data;

			public DataStore()
			{
				data = new Hashtable();
			}

			public virtual object GetData(string strFormat)
			{
				return GetData(strFormat, blnAutoConvert: true);
			}

			public virtual object GetData(Type objFormat)
			{
				return GetData(objFormat.FullName);
			}

			public virtual object GetData(string strFormat, bool blnAutoConvert)
			{
				DataStoreEntry dataStoreEntry = (DataStoreEntry)data[strFormat];
				object obj = null;
				if (dataStoreEntry != null)
				{
					obj = dataStoreEntry.data;
				}
				object obj2 = obj;
				if (blnAutoConvert && (dataStoreEntry == null || dataStoreEntry.autoConvert) && (obj == null || obj is MemoryStream))
				{
					string[] mappedFormats = GetMappedFormats(strFormat);
					if (mappedFormats != null)
					{
						for (int i = 0; i < mappedFormats.Length; i++)
						{
							if (!strFormat.Equals(mappedFormats[i]))
							{
								DataStoreEntry dataStoreEntry2 = (DataStoreEntry)data[mappedFormats[i]];
								if (dataStoreEntry2 != null)
								{
									obj = dataStoreEntry2.data;
								}
								if (obj != null && !(obj is MemoryStream))
								{
									obj2 = null;
									break;
								}
							}
						}
					}
				}
				if (obj2 != null)
				{
					return obj2;
				}
				return obj;
			}

			public virtual bool GetDataPresent(string strFormat)
			{
				return GetDataPresent(strFormat, blnAutoConvert: true);
			}

			public virtual bool GetDataPresent(Type objFormat)
			{
				return GetDataPresent(objFormat.FullName);
			}

			public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert)
			{
				if (!blnAutoConvert)
				{
					return data.ContainsKey(strFormat);
				}
				string[] formats = GetFormats(blnAutoConvert);
				for (int i = 0; i < formats.Length; i++)
				{
					if (strFormat.Equals(formats[i]))
					{
						return true;
					}
				}
				return false;
			}

			public virtual string[] GetFormats()
			{
				return GetFormats(blnAutoConvert: true);
			}

			public virtual string[] GetFormats(bool blnAutoConvert)
			{
				string[] array = new string[data.Keys.Count];
				data.Keys.CopyTo(array, 0);
				if (!blnAutoConvert)
				{
					return array;
				}
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < array.Length; i++)
				{
					if (((DataStoreEntry)data[array[i]]).autoConvert)
					{
						string[] mappedFormats = GetMappedFormats(array[i]);
						for (int j = 0; j < mappedFormats.Length; j++)
						{
							arrayList.Add(mappedFormats[j]);
						}
					}
					else
					{
						arrayList.Add(array[i]);
					}
				}
				string[] array2 = new string[arrayList.Count];
				arrayList.CopyTo(array2, 0);
				return GetDistinctStrings(array2);
			}

			public virtual void SetData(object objData)
			{
				if (objData is ISerializable && !data.ContainsKey(DataFormats.Serializable))
				{
					SetData(DataFormats.Serializable, objData);
				}
				SetData(objData.GetType(), objData);
			}

			public virtual void SetData(string strFormat, object objData)
			{
				SetData(strFormat, blnAutoConvert: true, objData);
			}

			public virtual void SetData(Type objFormat, object objData)
			{
				SetData(objFormat.FullName, objData);
			}

			public virtual void SetData(string strFormat, bool blnAutoConvert, object objData)
			{
				if (objData is Bitmap && strFormat.Equals(DataFormats.Dib))
				{
					if (!blnAutoConvert)
					{
						throw new NotSupportedException(SR.GetString("DataObjectDibNotSupported"));
					}
					strFormat = DataFormats.Bitmap;
				}
				data[strFormat] = new DataStoreEntry(objData, blnAutoConvert);
			}
		}

		private static readonly string CF_DEPRECATED_FILENAME;

		private static readonly string CF_DEPRECATED_FILENAMEW;

		private const int DATA_S_SAMEFORMATETC = 262448;

		private const int DV_E_DVASPECT = -2147221397;

		private const int DV_E_FORMATETC = -2147221404;

		private const int DV_E_LINDEX = -2147221400;

		private const int DV_E_TYMED = -2147221399;

		private IDataObject mobjInnerData;

		private const int OLE_E_ADVISENOTSUPPORTED = -2147221501;

		private const int OLE_E_NOTRUNNING = -2147221499;

		private static readonly byte[] marrSerializedObjectID;

		static DataObject()
		{
			CF_DEPRECATED_FILENAME = "FileName";
			CF_DEPRECATED_FILENAMEW = "FileNameW";
			marrSerializedObjectID = new Guid("FD9EA796-3B13-4370-A679-56106BB288FB").ToByteArray();
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class.</summary>
		public DataObject()
		{
			mobjInnerData = new DataStore();
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object to it.</summary>
		/// <param name="objData">The data to store. </param>
		/// 
		/// The additional check Marshal.IsComObject(data) omitted to avoid limitations of PTE.
		/// The call to IsComObject() requires SecurityPermission (Unmanaged flag) that available
		/// only in fully trusted environment.
		/// </remarks>
		public DataObject(object objData)
		{
			if (objData is IDataObject)
			{
				mobjInnerData = (IDataObject)objData;
				return;
			}
			mobjInnerData = new DataStore();
			SetData(objData);
		}

		internal DataObject(IDataObject objData)
		{
			mobjInnerData = objData;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object in the specified format.</summary>
		/// <param name="objData">The data to store. </param>
		/// <param name="strFormat">The format of the specified data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
		public DataObject(string strFormat, object objData)
			: this()
		{
			SetData(strFormat, objData);
		}

		/// Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
		/// true if the data object contains audio data; otherwise, false.</returns>
		/// 1</filterpriority>
		public virtual bool ContainsAudio()
		{
			return GetDataPresent(DataFormats.WaveAudio, blnAutoConvert: false);
		}

		/// Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</summary>
		/// true if the data object contains a file drop list; otherwise, false.</returns>
		/// 1</filterpriority>
		public virtual bool ContainsFileDropList()
		{
			return GetDataPresent(DataFormats.FileDrop, blnAutoConvert: true);
		}

		/// Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</summary>
		/// true if the data object contains image data; otherwise, false.</returns>
		/// 1</filterpriority>
		public virtual bool ContainsImage()
		{
			return GetDataPresent(DataFormats.Bitmap, blnAutoConvert: true);
		}

		/// Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
		/// true if the data object contains text data; otherwise, false.</returns>
		/// 1</filterpriority>
		public virtual bool ContainsText()
		{
			return ContainsText(TextDataFormat.UnicodeText);
		}

		/// Indicates whether the data object contains text data in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
		/// true if the data object contains text data in the specified format; otherwise, false.</returns>
		/// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		/// 1</filterpriority>
		public virtual bool ContainsText(TextDataFormat enmFormat)
		{
			if (!ClientUtils.IsEnumValid(enmFormat, (int)enmFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)enmFormat, typeof(TextDataFormat));
			}
			return GetDataPresent(ConvertToDataFormats(enmFormat), blnAutoConvert: false);
		}

		private static string ConvertToDataFormats(TextDataFormat enmFormat)
		{
			return enmFormat switch
			{
				TextDataFormat.UnicodeText => DataFormats.UnicodeText, 
				TextDataFormat.Rtf => DataFormats.Rtf, 
				TextDataFormat.Html => DataFormats.Html, 
				TextDataFormat.CommaSeparatedValue => DataFormats.CommaSeparatedValue, 
				_ => DataFormats.UnicodeText, 
			};
		}

		/// Retrieves an audio stream from the data object.</summary>
		/// A <see cref="T:System.IO.Stream"></see> containing audio data or null if the data object does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
		/// 1</filterpriority>
		public virtual Stream GetAudioStream()
		{
			return GetData(DataFormats.WaveAudio, blnAutoConvert: false) as Stream;
		}

		/// Returns the data associated with the specified data format.</summary>
		/// The data associated with the specified format, or null.</returns>
		/// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual object GetData(string strFormat)
		{
			return GetData(strFormat, blnAutoConvert: true);
		}

		/// Returns the data associated with the specified class type format.</summary>
		/// The data associated with the specified format, or null.</returns>
		/// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format of the data to retrieve. </param>
		/// 1</filterpriority>
		public virtual object GetData(Type objFormat)
		{
			if (objFormat == null)
			{
				return null;
			}
			return GetData(objFormat.FullName);
		}

		/// Returns the data associated with the specified data format, using an automated conversion parameter to determine whether to convert the data to the format.</summary>
		/// The data associated with the specified format, or null.</returns>
		/// <param name="blnAutoConvert">true to the convert data to the specified format; otherwise, false. </param>
		/// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual object GetData(string strFormat, bool blnAutoConvert)
		{
			return mobjInnerData.GetData(strFormat, blnAutoConvert);
		}

		/// Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
		/// true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
		/// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual bool GetDataPresent(string strFormat)
		{
			return GetDataPresent(strFormat, blnAutoConvert: true);
		}

		/// Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
		/// true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
		/// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format to check for. </param>
		/// 1</filterpriority>
		public virtual bool GetDataPresent(Type objFormat)
		{
			if (objFormat == null)
			{
				return false;
			}
			return GetDataPresent(objFormat.FullName);
		}

		/// Determines whether this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> contains data in the specified format or, optionally, contains data that can be converted to the specified format.</summary>
		/// true if the data is in, or can be converted to, the specified format; otherwise, false.</returns>
		/// <param name="blnAutoConvert">true to determine whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> can be converted to the specified format; false to check whether the data is in the specified format. </param>
		/// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert)
		{
			return mobjInnerData.GetDataPresent(strFormat, blnAutoConvert);
		}

		private static string[] GetDistinctStrings(string[] arrFormats)
		{
			ArrayList arrayList = new ArrayList();
			foreach (string text in arrFormats)
			{
				if (!arrayList.Contains(text))
				{
					arrayList.Add(text);
				}
			}
			string[] array = new string[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		/// Retrieves a collection of file names from the data object. </summary>
		/// A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
		/// 1</filterpriority>
		public virtual StringCollection GetFileDropList()
		{
			StringCollection stringCollection = new StringCollection();
			if (GetData(DataFormats.FileDrop, blnAutoConvert: true) is string[] value)
			{
				stringCollection.AddRange(value);
			}
			return stringCollection;
		}

		/// Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to.</summary>
		/// An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
		/// 1</filterpriority>
		public virtual string[] GetFormats()
		{
			return GetFormats(blnAutoConvert: true);
		}

		/// Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to, using an automatic conversion parameter to determine whether to retrieve only native data formats or all formats that the data can be converted to.</summary>
		/// An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
		/// <param name="blnAutoConvert">true to retrieve all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to; false to retrieve only native data formats. </param>
		/// 1</filterpriority>
		public virtual string[] GetFormats(bool blnAutoConvert)
		{
			return mobjInnerData.GetFormats(blnAutoConvert);
		}

		/// Retrieves an image from the data object.</summary>
		/// An <see cref="T:System.Drawing.Image"></see> representing the image data in the data object or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
		/// 1</filterpriority>
		public virtual System.Drawing.Image GetImage()
		{
			return GetData(DataFormats.Bitmap, blnAutoConvert: true) as System.Drawing.Image;
		}

		private static string[] GetMappedFormats(string strFormat)
		{
			if (strFormat == null)
			{
				return null;
			}
			if (strFormat.Equals(DataFormats.Text) || strFormat.Equals(DataFormats.UnicodeText) || strFormat.Equals(DataFormats.StringFormat))
			{
				return new string[3]
				{
					DataFormats.StringFormat,
					DataFormats.UnicodeText,
					DataFormats.Text
				};
			}
			if (strFormat.Equals(DataFormats.FileDrop) || strFormat.Equals(CF_DEPRECATED_FILENAME) || strFormat.Equals(CF_DEPRECATED_FILENAMEW))
			{
				return new string[3]
				{
					DataFormats.FileDrop,
					CF_DEPRECATED_FILENAMEW,
					CF_DEPRECATED_FILENAME
				};
			}
			if (strFormat.Equals(DataFormats.Bitmap) || strFormat.Equals(typeof(Bitmap).FullName))
			{
				return new string[2]
				{
					typeof(Bitmap).FullName,
					DataFormats.Bitmap
				};
			}
			return new string[1] { strFormat };
		}

		/// Retrieves text data from the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
		/// The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</returns>
		/// 1</filterpriority>
		public virtual string GetText()
		{
			return GetText(TextDataFormat.UnicodeText);
		}

		/// Retrieves text data from the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
		/// The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the specified format.</returns>
		/// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		/// 1</filterpriority>
		public virtual string GetText(TextDataFormat objFormat)
		{
			if (!ClientUtils.IsEnumValid(objFormat, (int)objFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)objFormat, typeof(TextDataFormat));
			}
			if (GetData(ConvertToDataFormats(objFormat), blnAutoConvert: false) is string result)
			{
				return result;
			}
			return string.Empty;
		}

		/// Adds a <see cref="T:System.IO.Stream"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
		/// <param name="objAudioStream">A <see cref="T:System.IO.Stream"></see> containing the audio data.</param>
		/// <exception cref="T:System.ArgumentNullException">audioStream is null.</exception>
		/// 1</filterpriority>
		public virtual void SetAudio(Stream objAudioStream)
		{
			if (objAudioStream == null)
			{
				throw new ArgumentNullException("audioStream");
			}
			SetData(DataFormats.WaveAudio, blnAutoConvert: false, objAudioStream);
		}

		/// Adds a <see cref="T:System.Byte"></see> array to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format after converting it to a <see cref="T:System.IO.Stream"></see>.</summary>
		/// <param name="arrAudioBytes">A <see cref="T:System.Byte"></see> array containing the audio data.</param>
		/// <exception cref="T:System.ArgumentNullException">audioBytes is null.</exception>
		/// 1</filterpriority>
		public virtual void SetAudio(byte[] arrAudioBytes)
		{
			if (arrAudioBytes == null)
			{
				throw new ArgumentNullException("audioBytes");
			}
			SetAudio(new MemoryStream(arrAudioBytes));
		}

		/// Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the object type as the data format.</summary>
		/// <param name="objData">The data to store. </param>
		/// 1</filterpriority>
		public virtual void SetData(object objData)
		{
			mobjInnerData.SetData(objData);
		}

		/// Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format.</summary>
		/// <param name="objData">The data to store. </param>
		/// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual void SetData(string strFormat, object objData)
		{
			mobjInnerData.SetData(strFormat, objData);
		}

		/// Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified type as the format.</summary>
		/// <param name="objData">The data to store. </param>
		/// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format associated with the data. </param>
		/// 1</filterpriority>
		public virtual void SetData(Type objFormat, object objData)
		{
			mobjInnerData.SetData(objFormat, objData);
		}

		/// Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format and indicating whether the data can be converted to another format.</summary>
		/// <param name="blnAutoConvert">true to allow the data to be converted to another format; otherwise, false. </param>
		/// <param name="objData">The data to store. </param>
		/// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
		/// 1</filterpriority>
		public virtual void SetData(string strFormat, bool blnAutoConvert, object objData)
		{
			mobjInnerData.SetData(strFormat, blnAutoConvert, objData);
		}

		/// Adds a collection of file names to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format.</summary>
		/// <param name="objFilePaths">A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the file names.</param>
		/// <exception cref="T:System.ArgumentNullException">filePaths is null.</exception>
		/// 1</filterpriority>
		public virtual void SetFileDropList(StringCollection objFilePaths)
		{
			if (objFilePaths == null)
			{
				throw new ArgumentNullException("filePaths");
			}
			string[] array = new string[objFilePaths.Count];
			objFilePaths.CopyTo(array, 0);
			SetData(DataFormats.FileDrop, blnAutoConvert: true, array);
		}

		/// Adds an <see cref="T:System.Drawing.Image"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format.</summary>
		/// <param name="objImage">The <see cref="T:System.Drawing.Image"></see> to add to the data object.</param>
		/// <exception cref="T:System.ArgumentNullException">image is null.</exception>
		/// 1</filterpriority>
		public virtual void SetImage(System.Drawing.Image objImage)
		{
			if (objImage == null)
			{
				throw new ArgumentNullException("image");
			}
			SetData(DataFormats.Bitmap, blnAutoConvert: true, objImage);
		}

		/// Adds text data to the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
		/// <param name="strTextData">The text to add to the data object.</param>
		/// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
		/// 1</filterpriority>
		public virtual void SetText(string strTextData)
		{
			SetText(strTextData, TextDataFormat.UnicodeText);
		}

		/// Adds text data to the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
		/// <param name="strTextData">The text to add to the data object.</param>
		/// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		/// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
		/// 1</filterpriority>
		public virtual void SetText(string strTextData, TextDataFormat objFormat)
		{
			if (CommonUtils.IsNullOrEmpty(strTextData))
			{
				throw new ArgumentNullException("textData");
			}
			if (!ClientUtils.IsEnumValid(objFormat, (int)objFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)objFormat, typeof(TextDataFormat));
			}
			SetData(ConvertToDataFormats(objFormat), blnAutoConvert: false, strTextData);
		}
	}
}
