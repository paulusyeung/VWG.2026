#region Using

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using System.Text; 

#endregion

namespace Gizmox.WebGUI.Forms
{


    /// <summary>Implements a basic data transfer mechanism.</summary>
    /// <filterpriority>2</filterpriority>
    [ClassInterface(ClassInterfaceType.None), Serializable()]
    
	public class DataObject : Gizmox.WebGUI.Forms.IDataObject
    {
        static DataObject()
        {
            DataObject.CF_DEPRECATED_FILENAME = "FileName";
            DataObject.CF_DEPRECATED_FILENAMEW = "FileNameW";
     
            DataObject.marrSerializedObjectID = new Guid("FD9EA796-3B13-4370-A679-56106BB288FB").ToByteArray();
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class.</summary>
        public DataObject()
        {
            this.mobjInnerData = new DataStore();
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object to it.</summary>
        /// <param name="objData">The data to store. </param>
        /// <remarks>
        /// The additional check Marshal.IsComObject(data) omitted to avoid limitations of PTE.
        /// The call to IsComObject() requires SecurityPermission (Unmanaged flag) that available
        /// only in fully trusted environment.
        /// </remarks>
        public DataObject(object objData)
        {
            if(objData is Gizmox.WebGUI.Forms.IDataObject)
            {
                this.mobjInnerData = (Gizmox.WebGUI.Forms.IDataObject) objData;
            }
            else
            {
                this.mobjInnerData = new DataStore();
                this.SetData(objData);
            }
        }

        internal DataObject(IDataObject objData)
        {
            this.mobjInnerData = objData;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> class and adds the specified object in the specified format.</summary>
        /// <param name="objData">The data to store. </param>
        /// <param name="strFormat">The format of the specified data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
        public DataObject(string strFormat, object objData) : this()
        {
            this.SetData(strFormat, objData);
        }

        /// <summary>Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
        /// <returns>true if the data object contains audio data; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsAudio()
        {
            return this.GetDataPresent(DataFormats.WaveAudio, false);
        }

        /// <summary>Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</summary>
        /// <returns>true if the data object contains a file drop list; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsFileDropList()
        {
            return this.GetDataPresent(DataFormats.FileDrop, true);
        }

        /// <summary>Indicates whether the data object contains data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</summary>
        /// <returns>true if the data object contains image data; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsImage()
        {
            return this.GetDataPresent(DataFormats.Bitmap, true);
        }

        /// <summary>Indicates whether the data object contains data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
        /// <returns>true if the data object contains text data; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsText()
        {
            return this.ContainsText(TextDataFormat.UnicodeText);
        }

        /// <summary>Indicates whether the data object contains text data in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
        /// <returns>true if the data object contains text data in the specified format; otherwise, false.</returns>
        /// <param name="enmFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual bool ContainsText(TextDataFormat enmFormat)
        {
            if (!ClientUtils.IsEnumValid(enmFormat, (int) enmFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof(TextDataFormat));
            }
            return this.GetDataPresent(DataObject.ConvertToDataFormats(enmFormat), false);
        }

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
            }
            return DataFormats.UnicodeText;
        }

        /// <summary>Retrieves an audio stream from the data object.</summary>
        /// <returns>A <see cref="T:System.IO.Stream"></see> containing audio data or null if the data object does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual Stream GetAudioStream()
        {
            return (this.GetData(DataFormats.WaveAudio, false) as Stream);
        }



        /// <summary>Returns the data associated with the specified data format.</summary>
        /// <returns>The data associated with the specified format, or null.</returns>
        /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual object GetData(string strFormat)
        {
            return this.GetData(strFormat, true);
        }

        /// <summary>Returns the data associated with the specified class type format.</summary>
        /// <returns>The data associated with the specified format, or null.</returns>
        /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format of the data to retrieve. </param>
        /// <filterpriority>1</filterpriority>
        public virtual object GetData(Type objFormat)
        {
            if (objFormat == null)
            {
                return null;
            }
            return this.GetData(objFormat.FullName);
        }

        /// <summary>Returns the data associated with the specified data format, using an automated conversion parameter to determine whether to convert the data to the format.</summary>
        /// <returns>The data associated with the specified format, or null.</returns>
        /// <param name="blnAutoConvert">true to the convert data to the specified format; otherwise, false. </param>
        /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual object GetData(string strFormat, bool blnAutoConvert)
        {
            return this.mobjInnerData.GetData(strFormat, blnAutoConvert);
        }


        /// <summary>Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
        /// <returns>true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
        /// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual bool GetDataPresent(string strFormat)
        {
            return this.GetDataPresent(strFormat, true);
        }

        /// <summary>Determines whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format.</summary>
        /// <returns>true if data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to, the specified format; otherwise, false.</returns>
        /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format to check for. </param>
        /// <filterpriority>1</filterpriority>
        public virtual bool GetDataPresent(Type objFormat)
        {
            if (objFormat == null)
            {
                return false;
            }
            return this.GetDataPresent(objFormat.FullName);
        }

        /// <summary>Determines whether this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> contains data in the specified format or, optionally, contains data that can be converted to the specified format.</summary>
        /// <returns>true if the data is in, or can be converted to, the specified format; otherwise, false.</returns>
        /// <param name="blnAutoConvert">true to determine whether data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> can be converted to the specified format; false to check whether the data is in the specified format. </param>
        /// <param name="strFormat">The format to check for. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert)
        {
            return this.mobjInnerData.GetDataPresent(strFormat, blnAutoConvert);
        }

        private static string[] GetDistinctStrings(string[] arrFormats)
        {
            ArrayList objList1 = new ArrayList();
            for (int intNum1 = 0; intNum1 < arrFormats.Length; intNum1++)
            {
                string strText1 = arrFormats[intNum1];
                if (!objList1.Contains(strText1))
                {
                    objList1.Add(strText1);
                }
            }
            string[] arrText = new string[objList1.Count];
            objList1.CopyTo(arrText, 0);
            return arrText;
        }

        /// <summary>Retrieves a collection of file names from the data object. </summary>
        /// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual StringCollection GetFileDropList()
        {
            StringCollection objCollection1 = new StringCollection();
            string[] arrText = this.GetData(DataFormats.FileDrop, true) as string[];
            if (arrText != null)
            {
                objCollection1.AddRange(arrText);
            }
            return objCollection1;
        }

        /// <summary>Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to.</summary>
        /// <returns>An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual string[] GetFormats()
        {
            return this.GetFormats(true);
        }

        /// <summary>Returns a list of all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with or can be converted to, using an automatic conversion parameter to determine whether to retrieve only native data formats or all formats that the data can be converted to.</summary>
        /// <returns>An array of type <see cref="T:System.String"></see>, containing a list of all formats that are supported by the data stored in this object.</returns>
        /// <param name="blnAutoConvert">true to retrieve all formats that data stored in this <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> is associated with, or can be converted to; false to retrieve only native data formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual string[] GetFormats(bool blnAutoConvert)
        {
            return this.mobjInnerData.GetFormats(blnAutoConvert);
        }

        /// <summary>Retrieves an image from the data object.</summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see> representing the image data in the data object or null if the data object does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual Image GetImage()
        {
            return (this.GetData(DataFormats.Bitmap, true) as Image);
        }

        private static string[] GetMappedFormats(string strFormat)
        {
            if (strFormat == null)
            {
                return null;
            }
            if ((strFormat.Equals(DataFormats.Text) || strFormat.Equals(DataFormats.UnicodeText)) || strFormat.Equals(DataFormats.StringFormat))
            {
                return new string[] { DataFormats.StringFormat, DataFormats.UnicodeText, DataFormats.Text };
            }
            if ((strFormat.Equals(DataFormats.FileDrop) || strFormat.Equals(DataObject.CF_DEPRECATED_FILENAME)) || strFormat.Equals(DataObject.CF_DEPRECATED_FILENAMEW))
            {
                return new string[] { DataFormats.FileDrop, DataObject.CF_DEPRECATED_FILENAMEW, DataObject.CF_DEPRECATED_FILENAME };
            }
            if (strFormat.Equals(DataFormats.Bitmap) || strFormat.Equals(typeof(Bitmap).FullName))
            {
                return new string[] { typeof(Bitmap).FullName, DataFormats.Bitmap };
            }
            return new string[] { strFormat };
        }

        /// <summary>Retrieves text data from the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
        /// <returns>The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual string GetText()
        {
            return this.GetText(TextDataFormat.UnicodeText);
        }

        /// <summary>Retrieves text data from the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
        /// <returns>The text data in the data object or <see cref="F:System.String.Empty"></see> if the data object does not contain data in the specified format.</returns>
        /// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual string GetText(TextDataFormat objFormat)
        {
            if (!ClientUtils.IsEnumValid(objFormat, (int) objFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) objFormat, typeof(TextDataFormat));
            }
            string strText1 = this.GetData(DataObject.ConvertToDataFormats(objFormat), false) as string;
            if (strText1 != null)
            {
                return strText1;
            }
            return string.Empty;
        }




      



        /// <summary>Adds a <see cref="T:System.IO.Stream"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</summary>
        /// <param name="objAudioStream">A <see cref="T:System.IO.Stream"></see> containing the audio data.</param>
        /// <exception cref="T:System.ArgumentNullException">audioStream is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetAudio(Stream objAudioStream)
        {
            if (objAudioStream == null)
            {
                throw new ArgumentNullException("audioStream");
            }
            this.SetData(DataFormats.WaveAudio, false, objAudioStream);
        }

        /// <summary>Adds a <see cref="T:System.Byte"></see> array to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format after converting it to a <see cref="T:System.IO.Stream"></see>.</summary>
        /// <param name="arrAudioBytes">A <see cref="T:System.Byte"></see> array containing the audio data.</param>
        /// <exception cref="T:System.ArgumentNullException">audioBytes is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetAudio(byte[] arrAudioBytes)
        {
            if (arrAudioBytes == null)
            {
                throw new ArgumentNullException("audioBytes");
            }
            this.SetAudio(new MemoryStream(arrAudioBytes));
        }

        /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the object type as the data format.</summary>
        /// <param name="objData">The data to store. </param>
        /// <filterpriority>1</filterpriority>
        public virtual void SetData(object objData)
        {
            this.mobjInnerData.SetData(objData);
        }

        /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format.</summary>
        /// <param name="objData">The data to store. </param>
        /// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual void SetData(string strFormat, object objData)
        {
            this.mobjInnerData.SetData(strFormat, objData);
        }

        /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified type as the format.</summary>
        /// <param name="objData">The data to store. </param>
        /// <param name="objFormat">A <see cref="T:System.Type"></see> representing the format associated with the data. </param>
        /// <filterpriority>1</filterpriority>
        public virtual void SetData(Type objFormat, object objData)
        {
            this.mobjInnerData.SetData(objFormat, objData);
        }

        /// <summary>Adds the specified object to the <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> using the specified format and indicating whether the data can be converted to another format.</summary>
        /// <param name="blnAutoConvert">true to allow the data to be converted to another format; otherwise, false. </param>
        /// <param name="objData">The data to store. </param>
        /// <param name="strFormat">The format associated with the data. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats. </param>
        /// <filterpriority>1</filterpriority>
        public virtual void SetData(string strFormat, bool blnAutoConvert, object objData)
        {
            this.mobjInnerData.SetData(strFormat, blnAutoConvert, objData);
        }

        /// <summary>Adds a collection of file names to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format.</summary>
        /// <param name="objFilePaths">A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the file names.</param>
        /// <exception cref="T:System.ArgumentNullException">filePaths is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetFileDropList(StringCollection objFilePaths)
        {
            if (objFilePaths == null)
            {
                throw new ArgumentNullException("filePaths");
            }
            string[] arrText = new string[objFilePaths.Count];
            objFilePaths.CopyTo(arrText, 0);
            this.SetData(DataFormats.FileDrop, true, arrText);
        }

        /// <summary>Adds an <see cref="T:System.Drawing.Image"></see> to the data object in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format.</summary>
        /// <param name="objImage">The <see cref="T:System.Drawing.Image"></see> to add to the data object.</param>
        /// <exception cref="T:System.ArgumentNullException">image is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetImage(Image objImage)
        {
            if (objImage == null)
            {
                throw new ArgumentNullException("image");
            }
            this.SetData(DataFormats.Bitmap, true, objImage);
        }

        /// <summary>Adds text data to the data object in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format.</summary>
        /// <param name="strTextData">The text to add to the data object.</param>
        /// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetText(string strTextData)
        {
            this.SetText(strTextData, TextDataFormat.UnicodeText);
        }

        /// <summary>Adds text data to the data object in the format indicated by the specified <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</summary>
        /// <param name="strTextData">The text to add to the data object.</param>
        /// <param name="objFormat">One of the <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> values.</param>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">format is not a valid <see cref="T:Gizmox.WebGUI.Forms.TextDataFormat"></see> value.</exception>
        /// <exception cref="T:System.ArgumentNullException">textData is null or <see cref="F:System.String.Empty"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void SetText(string strTextData, TextDataFormat objFormat)
        {
            if (CommonUtils.IsNullOrEmpty(strTextData))
            {
                throw new ArgumentNullException("textData");
            }
            if (!ClientUtils.IsEnumValid(objFormat, (int) objFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) objFormat, typeof(TextDataFormat));
            }
            this.SetData(DataObject.ConvertToDataFormats(objFormat), false, strTextData);
        }





        private static readonly string CF_DEPRECATED_FILENAME;
        private static readonly string CF_DEPRECATED_FILENAMEW;
        private const int DATA_S_SAMEFORMATETC = 0x40130;
        private const int DV_E_DVASPECT = -2147221397;
        private const int DV_E_FORMATETC = -2147221404;
        private const int DV_E_LINDEX = -2147221400;
        private const int DV_E_TYMED = -2147221399;
        private IDataObject mobjInnerData;
        private const int OLE_E_ADVISENOTSUPPORTED = -2147221501;
        private const int OLE_E_NOTRUNNING = -2147221499;
        private static readonly byte[] marrSerializedObjectID;



        [Serializable()]
        private class DataStore : Gizmox.WebGUI.Forms.IDataObject
        {
            public DataStore()
            {
                this.data = new Hashtable();
            }

            public virtual object GetData(string strFormat)
            {
                return this.GetData(strFormat, true);
            }

            public virtual object GetData(Type objFormat)
            {
                return this.GetData(objFormat.FullName);
            }

            public virtual object GetData(string strFormat, bool blnAutoConvert)
            {
                DataStoreEntry entry1 = (DataStoreEntry) this.data[strFormat];
                object obj1 = null;
                if (entry1 != null)
                {
                    obj1 = entry1.data;
                }
                object obj2 = obj1;
                if ((blnAutoConvert && ((entry1 == null) || entry1.autoConvert)) && ((obj1 == null) || (obj1 is MemoryStream)))
                {
                    string[] arrText = DataObject.GetMappedFormats(strFormat);
                    if (arrText != null)
                    {
                        for (int num1 = 0; num1 < arrText.Length; num1++)
                        {
                            if (!strFormat.Equals(arrText[num1]))
                            {
                                DataStoreEntry entry2 = (DataStoreEntry) this.data[arrText[num1]];
                                if (entry2 != null)
                                {
                                    obj1 = entry2.data;
                                }
                                if ((obj1 != null) && !(obj1 is MemoryStream))
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
                return obj1;
            }

            public virtual bool GetDataPresent(string strFormat)
            {
                return this.GetDataPresent(strFormat, true);
            }

            public virtual bool GetDataPresent(Type objFormat)
            {
                return this.GetDataPresent(objFormat.FullName);
            }

            public virtual bool GetDataPresent(string strFormat, bool blnAutoConvert)
            {
                if (!blnAutoConvert)
                {
                    return this.data.ContainsKey(strFormat);
                }
                string[] arrText = this.GetFormats(blnAutoConvert);
                for (int num1 = 0; num1 < arrText.Length; num1++)
                {
                    if (strFormat.Equals(arrText[num1]))
                    {
                        return true;
                    }
                }
                return false;
            }

            public virtual string[] GetFormats()
            {
                return this.GetFormats(true);
            }

            public virtual string[] GetFormats(bool blnAutoConvert)
            {
                string[] arrText = new string[this.data.Keys.Count];
                this.data.Keys.CopyTo(arrText, 0);
                if (!blnAutoConvert)
                {
                    return arrText;
                }
                ArrayList objList = new ArrayList();
                for (int num1 = 0; num1 < arrText.Length; num1++)
                {
                    if (((DataStoreEntry) this.data[arrText[num1]]).autoConvert)
                    {
                        string[] arrText2 = DataObject.GetMappedFormats(arrText[num1]);
                        for (int num2 = 0; num2 < arrText2.Length; num2++)
                        {
                            objList.Add(arrText2[num2]);
                        }
                    }
                    else
                    {
                        objList.Add(arrText[num1]);
                    }
                }
                string[] arrText3 = new string[objList.Count];
                objList.CopyTo(arrText3, 0);
                return DataObject.GetDistinctStrings(arrText3);
            }

            public virtual void SetData(object objData)
            {
                if ((objData is ISerializable) && !this.data.ContainsKey(DataFormats.Serializable))
                {
                    this.SetData(DataFormats.Serializable, objData);
                }
                this.SetData(objData.GetType(), objData);
            }

            public virtual void SetData(string strFormat, object objData)
            {
                this.SetData(strFormat, true, objData);
            }

            public virtual void SetData(Type objFormat, object objData)
            {
                this.SetData(objFormat.FullName, objData);
            }

            public virtual void SetData(string strFormat, bool blnAutoConvert, object objData)
            {
                if ((objData is Bitmap) && strFormat.Equals(DataFormats.Dib))
                {
                    if (!blnAutoConvert)
                    {
                        throw new NotSupportedException(SR.GetString("DataObjectDibNotSupported"));
                    }
                    strFormat = DataFormats.Bitmap;
                }
                this.data[strFormat] = new DataStoreEntry(objData, blnAutoConvert);
            }


            private Hashtable data;



            [Serializable()]
            private class DataStoreEntry
            {
                public DataStoreEntry(object objData, bool blnAutoConvert)
                {
                    this.data = objData;
                    this.autoConvert = blnAutoConvert;
                }


                public bool autoConvert;
                public object data;
            }
        }



    }
}

