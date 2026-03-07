// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Clipboard
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides methods to place data on and retrieve data from the system Clipboard. This class cannot be inherited.
  /// </summary>
  [Serializable]
  public sealed class Clipboard
  {
    private Clipboard()
    {
    }

    /// <summary>Removes all data from the Clipboard.</summary>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void Clear()
    {
      if (!(VWGContext.Current is IContextClipboard current))
        return;
      current.Clear();
    }

    /// <summary>
    /// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.
    /// </summary>
    /// <returns>true if there is audio data on the Clipboard; otherwise, false.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static bool ContainsAudio()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetDataPresent(DataFormats.WaveAudio, false);
    }

    /// <summary>
    /// Indicates whether there is data on the Clipboard that is in the specified format or can be converted to that format.
    /// </summary>
    /// <returns>true if there is data on the Clipboard that is in the specified format or can be converted to that format; otherwise, false.</returns>
    /// <param name="strFormat">The format of the data to look for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static bool ContainsData(string strFormat)
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetDataPresent(strFormat, false);
    }

    /// <summary>
    /// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.
    /// </summary>
    /// <returns>true if there is a file drop list on the Clipboard; otherwise, false.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static bool ContainsFileDropList()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetDataPresent(DataFormats.FileDrop, true);
    }

    /// <summary>
    /// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.
    /// </summary>
    /// <returns>true if there is image data on the Clipboard; otherwise, false.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static bool ContainsImage()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetDataPresent(DataFormats.Bitmap, true);
    }

    /// <summary>
    /// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
    /// </summary>
    /// <returns>true if there is text data on the Clipboard; otherwise, false.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static bool ContainsText() => Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5 ? Clipboard.ContainsText(TextDataFormat.UnicodeText) : Clipboard.ContainsText(TextDataFormat.Text);

    /// <summary>
    /// Indicates whether there is text data on the Clipboard in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.
    /// </summary>
    /// <returns>true if there is text data on the Clipboard in the value specified for format; otherwise, false.</returns>
    /// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
    public static bool ContainsText(TextDataFormat enmFormat)
    {
      if (!ClientUtils.IsEnumValid((Enum) enmFormat, (int) enmFormat, 0, 4))
        throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof (TextDataFormat));
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetDataPresent(Clipboard.ConvertToDataFormats(enmFormat), false);
    }

    private static string ConvertToDataFormats(TextDataFormat enmFormat)
    {
      switch (enmFormat)
      {
        case TextDataFormat.Text:
          return DataFormats.Text;
        case TextDataFormat.UnicodeText:
          return DataFormats.UnicodeText;
        case TextDataFormat.Rtf:
          return DataFormats.Rtf;
        case TextDataFormat.Html:
          return DataFormats.Html;
        case TextDataFormat.CommaSeparatedValue:
          return DataFormats.CommaSeparatedValue;
        default:
          return DataFormats.UnicodeText;
      }
    }

    /// <summary>Retrieves an audio stream from the Clipboard.</summary>
    /// <returns>A <see cref="T:System.IO.Stream"></see> containing audio data or null if the Clipboard does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static Stream GetAudioStream()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null ? dataObject.GetData(DataFormats.WaveAudio, false) as Stream : (Stream) null;
    }

    /// <summary>
    /// Retrieves data from the Clipboard in the specified format.
    /// </summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the Clipboard data or null if the Clipboard does not contain any data that is in the specified format or can be converted to that format.</returns>
    /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static object GetData(string strFormat) => Clipboard.GetDataObject()?.GetData(strFormat);

    /// <summary>
    /// Retrieves the data that is currently on the system Clipboard.
    /// </summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see> that represents the data currently on the Clipboard, or null if there is no data on the Clipboard.</returns>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be retrieved from the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode and the <see cref="P:Gizmox.WebGUI.Forms.Application.MessageLoop"></see> property value is true. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method. </exception>
    public static IDataObject GetDataObject() => VWGContext.Current is IContextClipboard current ? current.GetDataObject() : (IDataObject) null;

    /// <summary>
    /// Retrieves a collection of file names from the Clipboard.
    /// </summary>
    /// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static StringCollection GetFileDropList()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      StringCollection fileDropList = new StringCollection();
      if (dataObject != null && dataObject.GetData(DataFormats.FileDrop, true) is string[] data)
        fileDropList.AddRange(data);
      return fileDropList;
    }

    /// <summary>Retrieves an image from the Clipboard.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> representing the Clipboard image data or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static Image GetImage()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null ? dataObject.GetData(DataFormats.Bitmap, true) as Image : (Image) null;
    }

    /// <summary>
    /// Retrieves text data from the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
    /// </summary>
    /// <returns>The Clipboard text data or <see cref="F:System.String.Empty"></see> if the Clipboard does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.</returns>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static string GetText() => Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5 ? Clipboard.GetText(TextDataFormat.UnicodeText) : Clipboard.GetText(TextDataFormat.Text);

    /// <summary>
    /// Retrieves text data from the Clipboard in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.
    /// </summary>
    /// <returns>The Clipboard text data or <see cref="F:System.String.Empty"></see> if the Clipboard does not contain data in the specified format.</returns>
    /// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
    public static string GetText(TextDataFormat enmFormat)
    {
      if (!ClientUtils.IsEnumValid((Enum) enmFormat, (int) enmFormat, 0, 4))
        throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof (TextDataFormat));
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject != null && dataObject.GetData(Clipboard.ConvertToDataFormats(enmFormat), false) is string data ? data : string.Empty;
    }

    private static bool IsFormatValid(DataObject data)
    {
      string[] formats = data.GetFormats();
      if (formats == null || formats.Length > 4)
        return false;
      for (int index = 0; index < formats.Length; ++index)
      {
        string str;
        if ((str = formats[index]) == null || str != "Text" && str != "UnicodeText" && str != "System.String" && str != "Csv")
          return false;
      }
      return true;
    }

    /// <summary>
    /// Adds a <see cref="T:System.Byte"></see> array to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format after converting it to a <see cref="T:System.IO.Stream"></see>.
    /// </summary>
    /// <param name="arrAudioBytes">A <see cref="T:System.Byte"></see> array containing the audio data.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    /// <exception cref="T:System.ArgumentNullException">audioBytes is null.</exception>
    public static void SetAudio(byte[] arrAudioBytes)
    {
      if (arrAudioBytes == null)
        throw new ArgumentNullException("audioBytes");
      Clipboard.SetAudio((Stream) new MemoryStream(arrAudioBytes));
    }

    /// <summary>
    /// Adds a <see cref="T:System.IO.Stream"></see> to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.
    /// </summary>
    /// <param name="objAudioStream">A <see cref="T:System.IO.Stream"></see> containing the audio data.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    /// <exception cref="T:System.ArgumentNullException">audioStream is null.</exception>
    public static void SetAudio(Stream objAudioStream)
    {
      if (objAudioStream == null)
        throw new ArgumentNullException("audioStream");
      DataObject objData = new DataObject();
      objData.SetData(DataFormats.WaveAudio, false, (object) objAudioStream);
      Clipboard.SetDataObject((object) objData, true);
    }

    /// <summary>Adds data to the Clipboard in the specified format.</summary>
    /// <param name="objData">An <see cref="T:System.Object"></see> representing the data to add.</param>
    /// <param name="strFormat">The format of the data to set. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.ArgumentNullException">data is null.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void SetData(string strFormat, object objData)
    {
      DataObject objData1 = new DataObject();
      objData1.SetData(strFormat, objData);
      Clipboard.SetDataObject((object) objData1, true);
    }

    /// <summary>Places nonpersistent data on the system Clipboard.</summary>
    /// <param name="objData">The data to place on the Clipboard. </param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void SetDataObject(object objData) => Clipboard.SetDataObject(objData, false);

    /// <summary>
    /// Places data on the system Clipboard and specifies whether the data should remain on the Clipboard after the application exits.
    /// </summary>
    /// <param name="blnCopy">true if you want data to remain on the Clipboard after this application exits; otherwise, false. </param>
    /// <param name="objData">The data to place on the Clipboard. </param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void SetDataObject(object objData, bool blnCopy) => Clipboard.SetDataObject(objData, blnCopy, 10, 100);

    /// <summary>
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
    public static void SetDataObject(
      object objData,
      bool blnCopy,
      int intRetryTimes,
      int intRetryDelay)
    {
      if (!(VWGContext.Current is IContextClipboard current))
        return;
      if (objData == null)
        throw new ArgumentNullException("data");
      if (!(objData is IDataObject data))
        data = (IDataObject) new DataObject(objData);
      current.SetDataObject(data, blnCopy, intRetryTimes, intRetryDelay);
    }

    /// <summary>
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
        throw new ArgumentNullException("filePaths");
      if (objFilePaths.Count == 0)
        throw new ArgumentException(SR.GetString("CollectionEmptyException"));
      foreach (string objFilePath in objFilePaths)
      {
        try
        {
          Path.GetFullPath(objFilePath);
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsSecurityOrCriticalException(ex))
            throw;
          else
            throw new ArgumentException(SR.GetString("Clipboard_InvalidPath", (object) objFilePath, (object) "filePaths"), ex);
        }
      }
      if (objFilePaths.Count <= 0)
        return;
      DataObject objData = new DataObject();
      string[] strArray = new string[objFilePaths.Count];
      objFilePaths.CopyTo(strArray, 0);
      objData.SetData(DataFormats.FileDrop, true, (object) strArray);
      Clipboard.SetDataObject((object) objData, true);
    }

    /// <summary>
    /// Adds an <see cref="T:System.Drawing.Image"></see> to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format.
    /// </summary>
    /// <param name="objImage">The <see cref="T:System.Drawing.Image"></see> to add to the Clipboard.</param>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.ArgumentNullException">image is null.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void SetImage(Image objImage)
    {
      if (objImage == null)
        throw new ArgumentNullException("image");
      DataObject objData = new DataObject();
      objData.SetData(DataFormats.Bitmap, true, (object) objImage);
      Clipboard.SetDataObject((object) objData, true);
    }

    /// <summary>
    /// Adds text data to the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
    /// </summary>
    /// <param name="strText">The text to add to the Clipboard.</param>
    /// <exception cref="T:System.ArgumentNullException">text is null or <see cref="F:System.String.Empty"></see>.</exception>
    /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
    /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
    public static void SetText(string strText)
    {
      if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 5)
        Clipboard.SetText(strText, TextDataFormat.Text);
      else
        Clipboard.SetText(strText, TextDataFormat.UnicodeText);
    }

    /// <summary>
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
        throw new ArgumentNullException("text");
      if (!ClientUtils.IsEnumValid((Enum) objFormat, (int) objFormat, 0, 4))
        throw new InvalidEnumArgumentException("format", (int) objFormat, typeof (TextDataFormat));
      DataObject objData = new DataObject();
      objData.SetData(Clipboard.ConvertToDataFormats(objFormat), false, (object) strText);
      Clipboard.SetDataObject((object) objData, true);
    }

    /// <summary>
    /// Sends the current clipboard data to the client and clears the clip board
    /// </summary>
    /// <param name="enmFormat">The clip board text format to send to the client</param>
    /// <remarks>This is has no effect in smart client mode.</remarks>
    public static void Update(TextDataFormat enmFormat) => Clipboard.Update(enmFormat, true);

    /// <summary>Sends the current clipboard data to the client</summary>
    /// <param name="enmFormat">The clip board text format to send to the client</param>
    /// <param name="blnClear">A flag indicating if clipboard should be cleared after sending to client.</param>
    /// <remarks>This is has no effect in smart client mode.</remarks>
    public static void Update(TextDataFormat enmFormat, bool blnClear)
    {
      if (!(VWGContext.Current is IContextMethodInvoker current))
        return;
      object[] objArray = new object[2]
      {
        (object) "text",
        (object) Clipboard.GetText(enmFormat)
      };
      current.InvokeMethod((ISkinable) null, InvokationUniqueness.Global, "Web_CopyToClipBoard", objArray);
      if (!blnClear)
        return;
      Clipboard.Clear();
    }

    private static void ThrowIfFailed(int hr)
    {
      if (hr != 0)
        throw new ExternalException(SR.GetString("ClipboardOperationFailed"), hr);
    }
  }
}
