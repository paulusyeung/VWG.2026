namespace Gizmox.WebGUI.Forms
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Threading;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common;

    /// <summary>
    /// Provides methods to place data on and retrieve data from the system Clipboard. This class cannot be inherited.
    /// </summary>
    [Serializable()]
    public sealed class Clipboard
    {
        private Clipboard()
        {
        }


        /// <summary>
        /// Removes all data from the Clipboard.
        /// </summary>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static void Clear()
        {
            IContextClipboard objContextClipboard = VWGContext.Current as IContextClipboard;
            if (objContextClipboard != null)
            {
                objContextClipboard.Clear();
            }
        }

        /// <summary>
        /// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.
        /// </summary>
        /// <returns>true if there is audio data on the Clipboard; otherwise, false.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static bool ContainsAudio()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetDataPresent(DataFormats.WaveAudio, false);
            }
            return false;
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
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetDataPresent(strFormat, false);
            }
            return false;
        }

        /// <summary>
        /// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.
        /// </summary>
        /// <returns>true if there is a file drop list on the Clipboard; otherwise, false.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static bool ContainsFileDropList()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetDataPresent(DataFormats.FileDrop, true);
            }
            return false;
        }

        /// <summary>
        /// Indicates whether there is data on the Clipboard that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.
        /// </summary>
        /// <returns>true if there is image data on the Clipboard; otherwise, false.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static bool ContainsImage()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetDataPresent(DataFormats.Bitmap, true);
            }
            return false;
        }

        /// <summary>
        /// Indicates whether there is data on the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
        /// </summary>
        /// <returns>true if there is text data on the Clipboard; otherwise, false.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static bool ContainsText()
        {
            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major >= 5))
            {
                return Clipboard.ContainsText(TextDataFormat.UnicodeText);
            }
            return Clipboard.ContainsText(TextDataFormat.Text);
        }

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
            if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(enmFormat, (int) enmFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof(TextDataFormat));
            }
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetDataPresent(Clipboard.ConvertToDataFormats(enmFormat), false);
            }
            return false;
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
            }
            return DataFormats.UnicodeText;
        }

        /// <summary>
        /// Retrieves an audio stream from the Clipboard.
        /// </summary>
        /// <returns>A <see cref="T:System.IO.Stream"></see> containing audio data or null if the Clipboard does not contain any data in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.WaveAudio"></see> format.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static Stream GetAudioStream()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return (obj1.GetData(DataFormats.WaveAudio, false) as Stream);
            }
            return null;
        }

        /// <summary>
        /// Retrieves data from the Clipboard in the specified format.
        /// </summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the Clipboard data or null if the Clipboard does not contain any data that is in the specified format or can be converted to that format.</returns>
        /// <param name="strFormat">The format of the data to retrieve. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static object GetData(string strFormat)
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return obj1.GetData(strFormat);
            }
            return null;
        }

        /// <summary>
        /// Retrieves the data that is currently on the system Clipboard.
        /// </summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see> that represents the data currently on the Clipboard, or null if there is no data on the Clipboard.</returns>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be retrieved from the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode and the <see cref="P:Gizmox.WebGUI.Forms.Application.MessageLoop"></see> property value is true. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method. </exception>
        public static IDataObject GetDataObject()
        {
            IContextClipboard objContextClipboard = VWGContext.Current as IContextClipboard;
            if (objContextClipboard != null)
            {
                return objContextClipboard.GetDataObject();
            }
            return null;
        }


        /// <summary>
        /// Retrieves a collection of file names from the Clipboard. 
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing file names or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.FileDrop"></see> format or can be converted to that format.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static StringCollection GetFileDropList()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            StringCollection objCollection1 = new StringCollection();
            if (obj1 != null)
            {
                string[] arrText = obj1.GetData(DataFormats.FileDrop, true) as string[];
                if (arrText != null)
                {
                    objCollection1.AddRange(arrText);
                }
            }
            return objCollection1;
        }

        /// <summary>
        /// Retrieves an image from the Clipboard.
        /// </summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see> representing the Clipboard image data or null if the Clipboard does not contain any data that is in the <see cref="F:Gizmox.WebGUI.Forms.DataFormats.Bitmap"></see> format or can be converted to that format.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static Image GetImage()
        {
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                return (obj1.GetData(DataFormats.Bitmap, true) as Image);
            }
            return null;
        }

        /// <summary>
        /// Retrieves text data from the Clipboard in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.
        /// </summary>
        /// <returns>The Clipboard text data or <see cref="F:System.String.Empty"></see> if the Clipboard does not contain data in the <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.Text"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextDataFormat.UnicodeText"></see> format, depending on the operating system.</returns>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static string GetText()
        {
            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major >= 5))
            {
                return Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            return Clipboard.GetText(TextDataFormat.Text);
        }

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
            if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(enmFormat, (int) enmFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) enmFormat, typeof(TextDataFormat));
            }
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1 != null)
            {
                string strText1 = obj1.GetData(Clipboard.ConvertToDataFormats(enmFormat), false) as string;
                if (strText1 != null)
                {
                    return strText1;
                }
            }
            return string.Empty;
        }

        private static bool IsFormatValid(DataObject data)
        {
            string[] arrText = data.GetFormats();
            if ((arrText == null) || (arrText.Length > 4))
            {
                return false;
            }
            for (int num1 = 0; num1 < arrText.Length; num1++)
            {
                string strText1;
                if (((strText1 = arrText[num1]) == null) || (((strText1 != "Text") && (strText1 != "UnicodeText")) && ((strText1 != "System.String") && (strText1 != "Csv"))))
                {
                    return false;
                }
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
            {
                throw new ArgumentNullException("audioBytes");
            }
            Clipboard.SetAudio(new MemoryStream(arrAudioBytes));
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
            {
                throw new ArgumentNullException("audioStream");
            }
            IDataObject obj1 = new DataObject();
            obj1.SetData(DataFormats.WaveAudio, false, objAudioStream);
            Clipboard.SetDataObject(obj1, true);
        }

        /// <summary>
        /// Adds data to the Clipboard in the specified format.
        /// </summary>
        /// <param name="objData">An <see cref="T:System.Object"></see> representing the data to add.</param>
        /// <param name="strFormat">The format of the data to set. See <see cref="T:Gizmox.WebGUI.Forms.DataFormats"></see> for predefined formats.</param>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.ArgumentNullException">data is null.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The Clipboard could not be cleared. This typically occurs when the Clipboard is being used by another process.</exception>
        public static void SetData(string strFormat, object objData)
        {
            IDataObject obj1 = new DataObject();
            obj1.SetData(strFormat, objData);
            Clipboard.SetDataObject(obj1, true);
        }

        /// <summary>
        /// Places nonpersistent data on the system Clipboard.
        /// </summary>
        /// <param name="objData">The data to place on the Clipboard. </param>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
        public static void SetDataObject(object objData)
        {
            Clipboard.SetDataObject(objData, false);
        }

        /// <summary>
        /// Places data on the system Clipboard and specifies whether the data should remain on the Clipboard after the application exits.
        /// </summary>
        /// <param name="blnCopy">true if you want data to remain on the Clipboard after this application exits; otherwise, false. </param>
        /// <param name="objData">The data to place on the Clipboard. </param>
        /// <exception cref="T:System.Threading.ThreadStateException">The current thread is not in single-threaded apartment (STA) mode. Add the <see cref="T:System.STAThreadAttribute"></see> to your application's Main method.</exception>
        /// <exception cref="T:System.ArgumentNullException">The value of data is null. </exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">Data could not be placed on the Clipboard. This typically occurs when the Clipboard is being used by another process.</exception>
        public static void SetDataObject(object objData, bool blnCopy)
        {
            Clipboard.SetDataObject(objData, blnCopy, 10, 100);
        }

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
        public static void SetDataObject(object objData, bool blnCopy, int intRetryTimes, int intRetryDelay)
        {
            IContextClipboard objContextClipboard = VWGContext.Current as IContextClipboard;
            if (objContextClipboard != null)
            {
                if (objData == null)
                {
                    throw new ArgumentNullException("data");
                }
                IDataObject obj1 = objData as IDataObject;
                if (obj1==null)
                {
                    obj1 = new DataObject(objData);
                }
                objContextClipboard.SetDataObject(obj1, blnCopy, intRetryTimes, intRetryDelay);
            }
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
            {
                throw new ArgumentNullException("filePaths");
            }
            if (objFilePaths.Count == 0)
            {
                throw new ArgumentException(SR.GetString("CollectionEmptyException"));
            }
            foreach (string strText1 in objFilePaths)
            {
                try
                {
                    Path.GetFullPath(strText1);
                    continue;
                }
                catch (Exception objException1)
                {
                    if (ClientUtils.IsSecurityOrCriticalException(objException1))
                    {
                        throw;
                    }
                    throw new ArgumentException(SR.GetString("Clipboard_InvalidPath", new object[] { strText1, "filePaths" }), objException1);
                }
            }
            if (objFilePaths.Count > 0)
            {
                IDataObject obj1 = new DataObject();
                string[] arrText = new string[objFilePaths.Count];
                objFilePaths.CopyTo(arrText, 0);
                obj1.SetData(DataFormats.FileDrop, true, arrText);
                Clipboard.SetDataObject(obj1, true);
            }
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
            {
                throw new ArgumentNullException("image");
            }
            IDataObject obj1 = new DataObject();
            obj1.SetData(DataFormats.Bitmap, true, objImage);
            Clipboard.SetDataObject(obj1, true);
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
            if ((Environment.OSVersion.Platform != PlatformID.Win32NT) || (Environment.OSVersion.Version.Major < 5))
            {
                Clipboard.SetText(strText, TextDataFormat.Text);
            }
            else
            {
                Clipboard.SetText(strText, TextDataFormat.UnicodeText);
            }
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
            {
                throw new ArgumentNullException("text");
            }
            if (!ClientUtils.IsEnumValid(objFormat, (int) objFormat, 0, 4))
            {
                throw new InvalidEnumArgumentException("format", (int) objFormat, typeof(TextDataFormat));
            }
            IDataObject obj1 = new DataObject();
            obj1.SetData(Clipboard.ConvertToDataFormats(objFormat), false, strText);
            Clipboard.SetDataObject(obj1, true);
        }

        /// <summary>
        /// Sends the current clipboard data to the client and clears the clip board
        /// </summary>
        /// <param name="enmFormat">The clip board text format to send to the client</param>
        /// <remarks>This is has no effect in smart client mode.</remarks>
        public static void Update(TextDataFormat enmFormat)
        {
            Update(enmFormat, true);
        }

        /// <summary>
        /// Sends the current clipboard data to the client
        /// </summary>
        /// <param name="enmFormat">The clip board text format to send to the client</param>
        /// <param name="blnClear">A flag indicating if clipboard should be cleared after sending to client.</param>
        /// <remarks>This is has no effect in smart client mode.</remarks>
        public static void Update(TextDataFormat enmFormat, bool blnClear)
        {
            IContextMethodInvoker objInvoker = VWGContext.Current as IContextMethodInvoker;
            if (objInvoker != null)
            {
                objInvoker.InvokeMethod(null,InvokationUniqueness.Global, "Web_CopyToClipBoard","text",Clipboard.GetText(enmFormat));
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
                ExternalException objException1 = new ExternalException(SR.GetString("ClipboardOperationFailed"), hr);
                throw objException1;
            }
        }

    }
}

