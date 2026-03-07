// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataObject
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Implements a basic data transfer mechanism.</summary>
  /// <filterpriority>2</filterpriority>
  [ClassInterface(ClassInterfaceType.None)]
  [Serializable]
  public class DataObject : IDataObject
  {
    private static readonly string CF_DEPRECATED_FILENAME = "FileName";
    private static readonly string CF_DEPRECATED_FILENAMEW = "FileNameW";
    private const int DATA_S_SAMEFORMATETC = 262448;
    private const int DV_E_DVASPECT = -2147221397;
    private const int DV_E_FORMATETC = -2147221404;
    private const int DV_E_LINDEX = -2147221400;
    private const int DV_E_TYMED = -2147221399;
    private IDataObject mobjInnerData;
    private const int OLE_E_ADVISENOTSUPPORTED = -2147221501;
    private const int OLE_E_NOTRUNNING = -2147221499;
    private static readonly byte[] marrSerializedObjectID = new Guid("FD9EA796-3B13-4370-A679-56106BB288FB").ToByteArray();

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class.</summary>
    public DataObject() => this.mobjInnerData = (IDataObject) new DataObject.DataStore();

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object to it.</summary>
    /// <param name="objData">The data to store. </param>
    /// <remarks>
    /// The additional check Marshal.IsComObject(data) omitted to avoid limitations of PTE.
    /// The call to IsComObject() requires SecurityPermission (Unmanaged flag) that available
    /// only in fully trusted environment.
    /// </remarks>
    public DataObject(object objData)
    {
      if (objData is IDataObject)
      {
        this.mobjInnerData = (IDataObject) objData;
      }
      else
      {
        this.mobjInnerData = (IDataObject) new DataObject.DataStore();
        this.SetData(objData);
      }
    }

    internal DataObject(IDataObject objData) => this.mobjInnerData = objData;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object in the specified format.</summary>
    /// <param name="objData">The data to store. </param>
    /// <param name="strFormat">The format of the specified data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
    public DataObject(string strFormat, object objData)
      : this()
    {
      this.SetData(strFormat, objData);
    }

    /// <summary>Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
    /// <returns>true if the data object contains audio data; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsAudio() => this.GetDataPresent(DataFormats.WaveAudio, false);

    /// <summary>Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</summary>
    /// <returns>true if the data object contains a file drop list; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsFileDropList() => this.GetDataPresent(DataFormats.FileDrop, true);

    /// <summary>Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</summary>
    /// <returns>true if the data object contains image data; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsImage() => this.GetDataPresent(DataFormats.Bitmap, true);

    /// <summary>Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
    /// <returns>true if the data object contains text data; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsText() => this.ContainsText(TextDataFormat.UnicodeText);

    /// <summary>Indicates whether the data object contains text data in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
    /// <returns>true if the data object contains text data in the specified format; otherwise, false.</returns>
    /// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsText(TextDataFormat enmFormat) => ClientUtils.IsEnumValid((Enum) enmFormat, (int) enmFormat, 0, 4) ? this.GetDataPresent(DataObject.ConvertToDataFormats(enmFormat), false) : throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof (TextDataFormat));

    private static string ConvertToDataFormats(TextDataFormat enmFormat)
    {
      switch (enmFormat)
      {
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

    /// <summary>Retrieves an audio stream from the data object.</summary>
    /// <returns>A <see cref="T:System.IO.Stream"></see> containing audio data or null if the data object does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual Stream GetAudioStream() => this.GetData(DataFormats.WaveAudio, false) as Stream;

    /// <summary>Returns the data associated with the specified data format.</summary>
    /// <returns>The data associated with the specified format, or null.</returns>
    /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual object GetData(string strFormat) => this.GetData(strFormat, true);

    /// <summary>Returns the data associated with the specified class type format.</summary>
    /// <returns>The data associated with the specified format, or null.</returns>
    /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format of the data to retrieve. </param>
    /// <filterpriority>1</filterpriority>
    public virtual object GetData(Type objFormat) => objFormat == (Type) null ? (object) null : this.GetData(objFormat.FullName);

    /// <summary>Returns the data associated with the specified data format, using an automated conversion parameter to determine whether to convert the data to the format.</summary>
    /// <returns>The data associated with the specified format, or null.</returns>
    /// <param name="blnAutoConvert">true to the convert data to the specified format; otherwise, false. </param>
    /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual object GetData(string strFormat, bool blnAutoConvert) => this.mobjInnerData.GetData(strFormat, blnAutoConvert);

    /// <summary>Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
    /// <returns>true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
    /// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual bool GetDataPresent(string strFormat) => this.GetDataPresent(strFormat, true);

    /// <summary>Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
    /// <returns>true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
    /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format to check for. </param>
    /// <filterpriority>1</filterpriority>
    public virtual bool GetDataPresent(Type objFormat) => !(objFormat == (Type) null) && this.GetDataPresent(objFormat.FullName);

    /// <summary>Determines whether this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> contains data in the specified format or, optionally, contains data that can be converted to the specified format.</summary>
    /// <returns>true if the data is in, or can be converted to, the specified format; otherwise, false.</returns>
    /// <param name="blnAutoConvert">true to determine whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> can be converted to the specified format; false to check whether the data is in the specified format. </param>
    /// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert) => this.mobjInnerData.GetDataPresent(strFormat, blnAutoConvert);

    private static string[] GetDistinctStrings(string[] arrFormats)
    {
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < arrFormats.Length; ++index)
      {
        string arrFormat = arrFormats[index];
        if (!arrayList.Contains((object) arrFormat))
          arrayList.Add((object) arrFormat);
      }
      string[] distinctStrings = new string[arrayList.Count];
      arrayList.CopyTo((Array) distinctStrings, 0);
      return distinctStrings;
    }

    /// <summary>Retrieves a collection of file names from the data object. </summary>
    /// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual StringCollection GetFileDropList()
    {
      StringCollection fileDropList = new StringCollection();
      if (this.GetData(DataFormats.FileDrop, true) is string[] data)
        fileDropList.AddRange(data);
      return fileDropList;
    }

    /// <summary>Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to.</summary>
    /// <returns>An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual string[] GetFormats() => this.GetFormats(true);

    /// <summary>Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to, using an automatic conversion parameter to determine whether to retrieve only native data formats or all formats that the data can be converted to.</summary>
    /// <returns>An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
    /// <param name="blnAutoConvert">true to retrieve all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to; false to retrieve only native data formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual string[] GetFormats(bool blnAutoConvert) => this.mobjInnerData.GetFormats(blnAutoConvert);

    /// <summary>Retrieves an image from the data object.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> representing the image data in the data object or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual Image GetImage() => this.GetData(DataFormats.Bitmap, true) as Image;

    private static string[] GetMappedFormats(string strFormat)
    {
      if (strFormat == null)
        return (string[]) null;
      return strFormat.Equals(DataFormats.Text) || strFormat.Equals(DataFormats.UnicodeText) || strFormat.Equals(DataFormats.StringFormat) ? new string[3]
      {
        DataFormats.StringFormat,
        DataFormats.UnicodeText,
        DataFormats.Text
      } : (strFormat.Equals(DataFormats.FileDrop) || strFormat.Equals(DataObject.CF_DEPRECATED_FILENAME) || strFormat.Equals(DataObject.CF_DEPRECATED_FILENAMEW) ? new string[3]
      {
        DataFormats.FileDrop,
        DataObject.CF_DEPRECATED_FILENAMEW,
        DataObject.CF_DEPRECATED_FILENAME
      } : (strFormat.Equals(DataFormats.Bitmap) || strFormat.Equals(typeof (Bitmap).FullName) ? new string[2]
      {
        typeof (Bitmap).FullName,
        DataFormats.Bitmap
      } : new string[1]{ strFormat }));
    }

    /// <summary>Retrieves text data from the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
    /// <returns>The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual string GetText() => this.GetText(TextDataFormat.UnicodeText);

    /// <summary>Retrieves text data from the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
    /// <returns>The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the specified format.</returns>
    /// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual string GetText(TextDataFormat objFormat)
    {
      if (!ClientUtils.IsEnumValid((Enum) objFormat, (int) objFormat, 0, 4))
        throw new InvalidEnumArgumentException("format", (int) objFormat, typeof (TextDataFormat));
      return this.GetData(DataObject.ConvertToDataFormats(objFormat), false) is string data ? data : string.Empty;
    }

    /// <summary>Adds a <see cref="T:System.IO.Stream"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
    /// <param name="objAudioStream">A <see cref="T:System.IO.Stream"></see> containing the audio data.</param>
    /// <exception cref="T:System.ArgumentNullException">audioStream is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetAudio(Stream objAudioStream)
    {
      if (objAudioStream == null)
        throw new ArgumentNullException("audioStream");
      this.SetData(DataFormats.WaveAudio, false, (object) objAudioStream);
    }

    /// <summary>Adds a <see cref="T:System.Byte"></see> array to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format after converting it to a <see cref="T:System.IO.Stream"></see>.</summary>
    /// <param name="arrAudioBytes">A <see cref="T:System.Byte"></see> array containing the audio data.</param>
    /// <exception cref="T:System.ArgumentNullException">audioBytes is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetAudio(byte[] arrAudioBytes)
    {
      if (arrAudioBytes == null)
        throw new ArgumentNullException("audioBytes");
      this.SetAudio((Stream) new MemoryStream(arrAudioBytes));
    }

    /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the object type as the data format.</summary>
    /// <param name="objData">The data to store. </param>
    /// <filterpriority>1</filterpriority>
    public virtual void SetData(object objData) => this.mobjInnerData.SetData(objData);

    /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format.</summary>
    /// <param name="objData">The data to store. </param>
    /// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual void SetData(string strFormat, object objData) => this.mobjInnerData.SetData(strFormat, objData);

    /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified type as the format.</summary>
    /// <param name="objData">The data to store. </param>
    /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format associated with the data. </param>
    /// <filterpriority>1</filterpriority>
    public virtual void SetData(Type objFormat, object objData) => this.mobjInnerData.SetData(objFormat, objData);

    /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format and indicating whether the data can be converted to another format.</summary>
    /// <param name="blnAutoConvert">true to allow the data to be converted to another format; otherwise, false. </param>
    /// <param name="objData">The data to store. </param>
    /// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
    /// <filterpriority>1</filterpriority>
    public virtual void SetData(string strFormat, bool blnAutoConvert, object objData) => this.mobjInnerData.SetData(strFormat, blnAutoConvert, objData);

    /// <summary>Adds a collection of file names to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format.</summary>
    /// <param name="objFilePaths">A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the file names.</param>
    /// <exception cref="T:System.ArgumentNullException">filePaths is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetFileDropList(StringCollection objFilePaths)
    {
      string[] strArray = objFilePaths != null ? new string[objFilePaths.Count] : throw new ArgumentNullException("filePaths");
      objFilePaths.CopyTo(strArray, 0);
      this.SetData(DataFormats.FileDrop, true, (object) strArray);
    }

    /// <summary>Adds an <see cref="T:System.Drawing.Image"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format.</summary>
    /// <param name="objImage">The <see cref="T:System.Drawing.Image"></see> to add to the data object.</param>
    /// <exception cref="T:System.ArgumentNullException">image is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetImage(Image objImage)
    {
      if (objImage == null)
        throw new ArgumentNullException("image");
      this.SetData(DataFormats.Bitmap, true, (object) objImage);
    }

    /// <summary>Adds text data to the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
    /// <param name="strTextData">The text to add to the data object.</param>
    /// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetText(string strTextData) => this.SetText(strTextData, TextDataFormat.UnicodeText);

    /// <summary>Adds text data to the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
    /// <param name="strTextData">The text to add to the data object.</param>
    /// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
    /// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void SetText(string strTextData, TextDataFormat objFormat)
    {
      if (CommonUtils.IsNullOrEmpty(strTextData))
        throw new ArgumentNullException("textData");
      if (!ClientUtils.IsEnumValid((Enum) objFormat, (int) objFormat, 0, 4))
        throw new InvalidEnumArgumentException("format", (int) objFormat, typeof (TextDataFormat));
      this.SetData(DataObject.ConvertToDataFormats(objFormat), false, (object) strTextData);
    }

    [Serializable]
    private class DataStore : IDataObject
    {
      private Hashtable data;

      public DataStore() => this.data = new Hashtable();

      public virtual object GetData(string strFormat) => this.GetData(strFormat, true);

      public virtual object GetData(Type objFormat) => this.GetData(objFormat.FullName);

      public virtual object GetData(string strFormat, bool blnAutoConvert)
      {
        DataObject.DataStore.DataStoreEntry dataStoreEntry1 = (DataObject.DataStore.DataStoreEntry) this.data[(object) strFormat];
        object obj1 = (object) null;
        if (dataStoreEntry1 != null)
          obj1 = dataStoreEntry1.data;
        object obj2 = obj1;
        if (blnAutoConvert && (dataStoreEntry1 == null || dataStoreEntry1.autoConvert) && (obj1 == null || obj1 is MemoryStream))
        {
          string[] mappedFormats = DataObject.GetMappedFormats(strFormat);
          if (mappedFormats != null)
          {
            for (int index = 0; index < mappedFormats.Length; ++index)
            {
              if (!strFormat.Equals(mappedFormats[index]))
              {
                DataObject.DataStore.DataStoreEntry dataStoreEntry2 = (DataObject.DataStore.DataStoreEntry) this.data[(object) mappedFormats[index]];
                if (dataStoreEntry2 != null)
                  obj1 = dataStoreEntry2.data;
                switch (obj1)
                {
                  case null:
                  case MemoryStream _:
                    continue;
                  default:
                    obj2 = (object) null;
                    goto label_12;
                }
              }
            }
          }
        }
label_12:
        return obj2 ?? obj1;
      }

      public virtual bool GetDataPresent(string strFormat) => this.GetDataPresent(strFormat, true);

      public virtual bool GetDataPresent(Type objFormat) => this.GetDataPresent(objFormat.FullName);

      public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert)
      {
        if (!blnAutoConvert)
          return this.data.ContainsKey((object) strFormat);
        foreach (string format in this.GetFormats(blnAutoConvert))
        {
          if (strFormat.Equals(format))
            return true;
        }
        return false;
      }

      public virtual string[] GetFormats() => this.GetFormats(true);

      public virtual string[] GetFormats(bool blnAutoConvert)
      {
        string[] formats = new string[this.data.Keys.Count];
        this.data.Keys.CopyTo((Array) formats, 0);
        if (!blnAutoConvert)
          return formats;
        ArrayList arrayList = new ArrayList();
        for (int index = 0; index < formats.Length; ++index)
        {
          if (((DataObject.DataStore.DataStoreEntry) this.data[(object) formats[index]]).autoConvert)
          {
            foreach (object mappedFormat in DataObject.GetMappedFormats(formats[index]))
              arrayList.Add(mappedFormat);
          }
          else
            arrayList.Add((object) formats[index]);
        }
        string[] arrFormats = new string[arrayList.Count];
        arrayList.CopyTo((Array) arrFormats, 0);
        return DataObject.GetDistinctStrings(arrFormats);
      }

      public virtual void SetData(object objData)
      {
        if (objData is ISerializable && !this.data.ContainsKey((object) DataFormats.Serializable))
          this.SetData(DataFormats.Serializable, objData);
        this.SetData(objData.GetType(), objData);
      }

      public virtual void SetData(string strFormat, object objData) => this.SetData(strFormat, true, objData);

      public virtual void SetData(Type objFormat, object objData) => this.SetData(objFormat.FullName, objData);

      public virtual void SetData(string strFormat, bool blnAutoConvert, object objData)
      {
        if (objData is Bitmap && strFormat.Equals(DataFormats.Dib))
        {
          if (!blnAutoConvert)
            throw new NotSupportedException(SR.GetString("DataObjectDibNotSupported"));
          strFormat = DataFormats.Bitmap;
        }
        this.data[(object) strFormat] = (object) new DataObject.DataStore.DataStoreEntry(objData, blnAutoConvert);
      }

      [Serializable]
      private class DataStoreEntry
      {
        public bool autoConvert;
        public object data;

        public DataStoreEntry(object objData, bool blnAutoConvert)
        {
          this.data = objData;
          this.autoConvert = blnAutoConvert;
        }
      }
    }
  }
}
