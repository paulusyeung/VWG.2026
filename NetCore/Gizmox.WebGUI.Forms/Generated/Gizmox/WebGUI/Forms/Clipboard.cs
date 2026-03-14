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
/// 
	/// Provides methods to place data on and retrieve data from the system Clipboard. This class cannot be inherited.
	/// </summary>
	[Serializable]
	public sealed class Clipboard
	{
		private Clipboard()
		{
		}

		/// 
		/// Removes all data from the Clipboard.
		/// </summary>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void Clear()
		{
			if (VWGContext.Current is IContextClipboard contextClipboard)
			{
				contextClipboard.Clear();
			}
		}

		/// 
		/// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.
		/// </summary>
		/// true if there is audio data on the Clipboard; otherwise, false.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static bool ContainsAudio()
		{
			return GetDataObject()?.GetDataPresent(DataFormats.WaveAudio, autoConvert: false) ?? false;
		}

		/// 
		/// Indicates whether there is data on the Clipboard that is in the specified format or can be converted to that format. 
		/// </summary>
		/// true if there is data on the Clipboard that is in the specified format or can be converted to that format; otherwise, false.</returns>
		/// <param name="strFormat">The format of the data to look for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static bool ContainsData(string strFormat)
		{
			return GetDataObject()?.GetDataPresent(strFormat, autoConvert: false) ?? false;
		}

		/// 
		/// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.
		/// </summary>
		/// true if there is a file drop list on the Clipboard; otherwise, false.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static bool ContainsFileDropList()
		{
			return GetDataObject()?.GetDataPresent(DataFormats.FileDrop, autoConvert: true) ?? false;
		}

		/// 
		/// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.
		/// </summary>
		/// true if there is image data on the Clipboard; otherwise, false.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static bool ContainsImage()
		{
			return GetDataObject()?.GetDataPresent(DataFormats.Bitmap, autoConvert: true) ?? false;
		}

		/// 
		/// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
		/// </summary>
		/// true if there is text data on the Clipboard; otherwise, false.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static bool ContainsText()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5)
			{
				return ContainsText(TextDataFormat.UnicodeText);
			}
			return ContainsText(TextDataFormat.Text);
		}

		/// 
		/// Indicates whether there is text data on the Clipboard in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.
		/// </summary>
		/// true if there is text data on the Clipboard in the value specified for format; otherwise, false.</returns>
		/// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		public static bool ContainsText(TextDataFormat enmFormat)
		{
			if (!ClientUtils.IsEnumValid(enmFormat, (int)enmFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)enmFormat, typeof(TextDataFormat));
			}
			return GetDataObject()?.GetDataPresent(ConvertToDataFormats(enmFormat), autoConvert: false) ?? false;
		}

		private static string ConvertToDataFormats(TextDataFormat enmFormat)
		{
			return enmFormat switch
			{
				TextDataFormat.Text => DataFormats.Text, 
				TextDataFormat.UnicodeText => DataFormats.UnicodeText, 
				TextDataFormat.Rtf => DataFormats.Rtf, 
				TextDataFormat.Html => DataFormats.Html, 
				TextDataFormat.CommaSeparatedValue => DataFormats.CommaSeparatedValue, 
				_ => DataFormats.UnicodeText, 
			};
		}

		/// 
		/// Retrieves an audio stream from the Clipboard.
		/// </summary>
		/// A <see cref="T:System.IO.Stream"></see> containing audio data or null if the Clipboard does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static Stream GetAudioStream()
		{
			IDataObject dataObject = GetDataObject();
			if (dataObject != null)
			{
				return dataObject.GetData(DataFormats.WaveAudio, autoConvert: false) as Stream;
			}
			return null;
		}

		/// 
		/// Retrieves data from the Clipboard in the specified format.
		/// </summary>
		/// An <see cref="T:System.Object"></see> representing the Clipboard data or null if the Clipboard does not contain any data that is in the specified format or can be converted to that format.</returns>
		/// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static object GetData(string strFormat)
		{
			return GetDataObject()?.GetData(strFormat);
		}

		/// 
		/// Retrieves the data that is currently on the system Clipboard.
		/// </summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see> that represents the data currently on the Clipboard, or null if there is no data on the Clipboard.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be retrieved from the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode and the <see cref="P:Gizmox.WebGUI.Forms.Application.MessageLoop"></see> property value is true. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method. </exception>
		public static IDataObject GetDataObject()
		{
			if (VWGContext.Current is IContextClipboard contextClipboard)
			{
				return contextClipboard.GetDataObject();
			}
			return null;
		}

		/// 
		/// Retrieves a collection of file names from the Clipboard. 
		/// </summary>
		/// A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static StringCollection GetFileDropList()
		{
			IDataObject dataObject = GetDataObject();
			StringCollection stringCollection = new StringCollection();
			if (dataObject != null && dataObject.GetData(DataFormats.FileDrop, autoConvert: true) is string[] value)
			{
				stringCollection.AddRange(value);
			}
			return stringCollection;
		}

		/// 
		/// Retrieves an image from the Clipboard.
		/// </summary>
		/// An <see cref="T:System.Drawing.Image"></see> representing the Clipboard image data or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static System.Drawing.Image GetImage()
		{
			IDataObject dataObject = GetDataObject();
			if (dataObject != null)
			{
				return dataObject.GetData(DataFormats.Bitmap, autoConvert: true) as System.Drawing.Image;
			}
			return null;
		}

		/// 
		/// Retrieves text data from the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
		/// </summary>
		/// The Clipboard text data or <see cref="F:System.String.Empty"></see> if the Clipboard does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static string GetText()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5)
			{
				return GetText(TextDataFormat.UnicodeText);
			}
			return GetText(TextDataFormat.Text);
		}

		/// 
		/// Retrieves text data from the Clipboard in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.
		/// </summary>
		/// The Clipboard text data or <see cref="F:System.String.Empty"></see> if the Clipboard does not contain data in the specified format.</returns>
		/// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		public static string GetText(TextDataFormat enmFormat)
		{
			if (!ClientUtils.IsEnumValid(enmFormat, (int)enmFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)enmFormat, typeof(TextDataFormat));
			}
			IDataObject dataObject = GetDataObject();
			if (dataObject != null && dataObject.GetData(ConvertToDataFormats(enmFormat), autoConvert: false) is string result)
			{
				return result;
			}
			return string.Empty;
		}

		private static bool IsFormatValid(DataObject data)
		{
			string[] formats = data.GetFormats();
			if (formats == null || formats.Length > 4)
			{
				return false;
			}
			for (int i = 0; i < formats.Length; i++)
			{
				string text;
				if ((text = formats[i]) == null || (text != "Text" && text != "UnicodeText" && text != "System.String" && text != "Csv"))
				{
					return false;
				}
			}
			return true;
		}

		/// 
		/// Adds a <see cref="T:System.Byte"></see> array to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format after converting it to a <see cref="T:System.IO.Stream"></see>.
		/// </summary>
		/// <param name="arrAudioBytes">A <see cref="T:System.Byte"></see> array containing the audio data.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.ArgumentNullException">audioBytes is null.</exception>
		public static void SetAudio(byte[] arrAudioBytes)
		{
			if (arrAudioBytes == null)
			{
				throw new ArgumentNullException("audioBytes");
			}
			SetAudio(new MemoryStream(arrAudioBytes));
		}

		/// 
		/// Adds a <see cref="T:System.IO.Stream"></see> to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.
		/// </summary>
		/// <param name="objAudioStream">A <see cref="T:System.IO.Stream"></see> containing the audio data.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.ArgumentNullException">audioStream is null.</exception>
		public static void SetAudio(Stream objAudioStream)
		{
			if (objAudioStream == null)
			{
				throw new ArgumentNullException("audioStream");
			}
			IDataObject dataObject = new DataObject();
			dataObject.SetData(DataFormats.WaveAudio, autoConvert: false, objAudioStream);
			SetDataObject(dataObject, blnCopy: true);
		}

		/// 
		/// Adds data to the Clipboard in the specified format.
		/// </summary>
		/// <param name="objData">An <see cref="T:System.Object"></see> representing the data to add.</param>
		/// <param name="strFormat">The format of the data to set. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.ArgumentNullException">data is null.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetData(string strFormat, object objData)
		{
			IDataObject dataObject = new DataObject();
			dataObject.SetData(strFormat, objData);
			SetDataObject(dataObject, blnCopy: true);
		}

		/// 
		/// Places nonpersistent data on the system Clipboard.
		/// </summary>
		/// <param name="objData">The data to place on the Clipboard. </param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetDataObject(object objData)
		{
			SetDataObject(objData, blnCopy: false);
		}

		/// 
		/// Places data on the system Clipboard and specifies whether the data should remain on the Clipboard after the application exits.
		/// </summary>
		/// <param name="blnCopy">true if you want data to remain on the Clipboard after this application exits; otherwise, false. </param>
		/// <param name="objData">The data to place on the Clipboard. </param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetDataObject(object objData, bool blnCopy)
		{
			SetDataObject(objData, blnCopy, 10, 100);
		}

		/// 
		/// Attempts to place data on the system Clipboard the specified number of times and with the specified delay between attempts, optionally leaving the data on the Clipboard after the application exits.
		/// </summary>
		/// <param name="blnCopy">true if you want data to remain on the Clipboard after this application exits; otherwise, false.</param>
		/// <param name="objData">The data to place on the Clipboard.</param>
		/// <param name="intRetryTimes">The number of times to attempt placing the data on the Clipboard.</param>
		/// <param name="intRetryDelay">The number of milliseconds to pause between attempts. </param>
		/// <exception cref="T:System.ArgumentNullException">data is null.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">retryTimes is less than zero.-or-retryDelay is less than zero.</exception>
		public static void SetDataObject(object objData, bool blnCopy, int intRetryTimes, int intRetryDelay)
		{
			if (VWGContext.Current is IContextClipboard contextClipboard)
			{
				if (objData == null)
				{
					throw new ArgumentNullException("data");
				}
				IDataObject dataObject = objData as IDataObject;
				if (dataObject == null)
				{
					dataObject = new DataObject(objData);
				}
				contextClipboard.SetDataObject(dataObject, blnCopy, intRetryTimes, intRetryDelay);
			}
		}

		/// 
		/// Adds a collection of file names to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format.
		/// </summary>
		/// <param name="objFilePaths">A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the file names.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.ArgumentException">filePaths does not contain any strings.-or-At least one of the strings in filePaths is <see cref="F:System.String.Empty"></see>, contains only white space, contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars"></see>, is null, contains a colon (:), or exceeds the system-defined maximum length.See the <see cref="P:System.Exception.InnerException"></see> property of the <see cref="T:System.ArgumentException"></see> for more information.</exception>
		/// <exception cref="T:System.ArgumentNullException">filePaths is null.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetFileDropList(StringCollection objFilePaths)
		{
			if (objFilePaths == null)
			{
				throw new ArgumentNullException("filePaths");
			}
			if (objFilePaths.Count == 0)
			{
				throw new ArgumentException(SR.GetString("CollectionEmptyException"));
			}
			StringEnumerator enumerator = objFilePaths.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					try
					{
						Path.GetFullPath(current);
					}
					catch (Exception ex)
					{
						if (ClientUtils.IsSecurityOrCriticalException(ex))
						{
							throw;
						}
						throw new ArgumentException(SR.GetString("Clipboard_InvalidPath", current, "filePaths"), ex);
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (objFilePaths.Count > 0)
			{
				IDataObject dataObject = new DataObject();
				string[] array = new string[objFilePaths.Count];
				objFilePaths.CopyTo(array, 0);
				dataObject.SetData(DataFormats.FileDrop, autoConvert: true, array);
				SetDataObject(dataObject, blnCopy: true);
			}
		}

		/// 
		/// Adds an <see cref="T:System.Drawing.Image"></see> to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format.
		/// </summary>
		/// <param name="objImage">The <see cref="T:System.Drawing.Image"></see> to add to the Clipboard.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.ArgumentNullException">image is null.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetImage(System.Drawing.Image objImage)
		{
			if (objImage == null)
			{
				throw new ArgumentNullException("image");
			}
			IDataObject dataObject = new DataObject();
			dataObject.SetData(DataFormats.Bitmap, autoConvert: true, objImage);
			SetDataObject(dataObject, blnCopy: true);
		}

		/// 
		/// Adds text data to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
		/// </summary>
		/// <param name="strText">The text to add to the Clipboard.</param>
		/// <exception cref="T:System.ArgumentNullException">text is null or <see cref="F:System.String.Empty"></see>.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		public static void SetText(string strText)
		{
			if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 5)
			{
				SetText(strText, TextDataFormat.Text);
			}
			else
			{
				SetText(strText, TextDataFormat.UnicodeText);
			}
		}

		/// 
		/// Adds text data to the Clipboard in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.
		/// </summary>
		/// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
		/// <param name="strText">The text to add to the Clipboard.</param>
		/// <exception cref="T:System.ArgumentNullException">text is null or <see cref="F:System.String.Empty"></see>.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
		public static void SetText(string strText, TextDataFormat objFormat)
		{
			if (CommonUtils.IsNullOrEmpty(strText))
			{
				throw new ArgumentNullException("text");
			}
			if (!ClientUtils.IsEnumValid(objFormat, (int)objFormat, 0, 4))
			{
				throw new InvalidEnumArgumentException("format", (int)objFormat, typeof(TextDataFormat));
			}
			IDataObject dataObject = new DataObject();
			dataObject.SetData(ConvertToDataFormats(objFormat), autoConvert: false, strText);
			SetDataObject(dataObject, blnCopy: true);
		}

		/// 
		/// Sends the current clipboard data to the client and clears the clip board
		/// </summary>
		/// <param name="enmFormat">The clip board text format to send to the client</param>
		/// This is has no effect in smart client mode.</remarks>
		public static void Update(TextDataFormat enmFormat)
		{
			Update(enmFormat, blnClear: true);
		}

		/// 
		/// Sends the current clipboard data to the client
		/// </summary>
		/// <param name="enmFormat">The clip board text format to send to the client</param>
		/// <param name="blnClear">A flag indicating if clipboard should be cleared after sending to client.</param>
		/// This is has no effect in smart client mode.</remarks>
		public static void Update(TextDataFormat enmFormat, bool blnClear)
		{
			if (VWGContext.Current is IContextMethodInvoker contextMethodInvoker)
			{
				contextMethodInvoker.InvokeMethod(null, InvokationUniqueness.Global, "Web_CopyToClipBoard", "text", GetText(enmFormat));
				if (blnClear)
				{
					Clear();
				}
			}
		}

		private static void ThrowIfFailed(int hr)
		{
			if (hr != 0)
			{
				ExternalException ex = new ExternalException(SR.GetString("ClipboardOperationFailed"), hr);
				throw ex;
			}
		}
	}
}
