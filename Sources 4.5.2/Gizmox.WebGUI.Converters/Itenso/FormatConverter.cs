using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Itenso.Rtf;
using Itenso.Rtf.Converter.Html;
using Itenso.Rtf.Support;
using System.Xml;
using Gizmox.WebGUI.Common.Configuration;
using System.IO;
using Itenso.Rtf.Converter.Image;
using System.Drawing.Imaging;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Convertions;

namespace Gizmox.WebGUI.Converters.Itenso
{
    public class FormatConverter : IFormatConverter
    {
        private class ImageConverterForCachingImages : RtfImageConverter
        {
            private Dictionary<string, byte[]> mobjImagesIndexByImageKey;

            public ImageConverterForCachingImages(RtfImageConvertSettings imageConvertSettings, Dictionary<string, byte[]> imagesIndexByImageKey)
                : base(imageConvertSettings)
            {
                this.mobjImagesIndexByImageKey = imagesIndexByImageKey;
            }

            protected override void EnsureImagesPath(string imageFileName) { }

            protected override void SaveImage(byte[] imageBuffer, RtfVisualImageFormat format, string fileName, System.Drawing.Size size)
            {
                this.mobjImagesIndexByImageKey.Add(fileName, imageBuffer);
            }
        }

        #region IFormatConverter Members


        /// <summary>
        /// Determines whether this instance can convert from and to a specified FormatConvertionType.
        /// </summary>
        /// <param name="enmConvertFrom">The enm convert from.</param>
        /// <param name="enmConvertTo">The enm convert to.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified enm convert from; otherwise, <c>false</c>.
        /// </returns>
        public bool CanConvert(FormatConvertionType enmConvertFrom, FormatConvertionType enmConvertTo)
        {
            bool blnIsPossible = false;
            switch (enmConvertFrom)
            {
                case FormatConvertionType.Rtf:
                    blnIsPossible = true;
                    break;
                case FormatConvertionType.Xml:
                    break;
                case FormatConvertionType.Html:
                    break;
                default:
                    break;
            }

            if (blnIsPossible)
            {
                switch (enmConvertTo)
                {
                    case FormatConvertionType.Rtf:
                        blnIsPossible = false;
                        break;
                    case FormatConvertionType.Xml:
                        blnIsPossible = false;
                        break;
                    case FormatConvertionType.Html:
                        break;
                    default:
                        break;
                }
            }

            return blnIsPossible;
        }

        /// <summary>
        /// Converts the specified enm convert from type.
        /// </summary>
        /// <param name="enmConvertFromType">Type of the enm convert from.</param>
        /// <param name="enmConvertToType">Type of the enm convert to.</param>
        /// <param name="objInputStream">The obj input stream.</param>
        /// <param name="objConvertionSettings">The obj convertion settings.</param>
        /// <returns></returns>
        public Stream Convert(FormatConvertionType enmConvertFromType, FormatConvertionType enmConvertToType, Stream objInputStream, ConvertionSettings objConvertionSettings)
        {
            return Convert(enmConvertFromType, enmConvertToType, objInputStream, objConvertionSettings, null);
        }

        /// <summary>
        /// Converts the specified enm convert from type.
        /// </summary>
        /// <param name="enmConvertFromType">Type of the enm convert from.</param>
        /// <param name="enmConvertToType">Type of the enm convert to.</param>
        /// <param name="objInputStream">The obj input stream.</param>
        /// <param name="objConvertionSettings">The obj convertion settings.</param>
        /// <param name="objImagesIndexByImageKey">The images index by image key.</param>
        /// <returns></returns>
        public Stream Convert(FormatConvertionType enmConvertFromType, FormatConvertionType enmConvertToType, Stream objInputStream, ConvertionSettings objConvertionSettings, Dictionary<string, byte[]> objImagesIndexByImageKey)
        {
            // Check if convertion possible
            if (CanConvert(enmConvertFromType, enmConvertToType))
            {
                Stream objStream = null;

                if (enmConvertToType == FormatConvertionType.Html)
                {
                    // Create a memory stream to return
                    objStream = new MemoryStream();

                    // Get the html string
                    string strConvertedString = GetConverterdHtmlString(enmConvertFromType, objInputStream, objConvertionSettings as HtmlConvertionSettings, objImagesIndexByImageKey);

                    // convert string to stream
                    WriteStringToStream(strConvertedString, objStream);
                    objStream.Position = 0;
                }

                return objStream;
            }

            return null;
        }

        #endregion

        /// <summary>
        /// Gets the converterd HTML string.
        /// </summary>
        /// <param name="enmConvertFromType">Type of the enm convert from.</param>
        /// <param name="objStream">The obj stream.</param>
        /// <param name="objHtmlSettings">The obj HTML settings.</param>
        /// <returns></returns>
        private string GetConverterdHtmlString(FormatConvertionType enmConvertFromType, Stream objStream, HtmlConvertionSettings objHtmlSettings, Dictionary<string, byte[]> objImagesIndexByImageKey)
        {
            string strConvertionResult = string.Empty;

            // Check that convert from type is rtf
            if (enmConvertFromType == FormatConvertionType.Rtf)
            {
                ImageConverterForCachingImages objImageConverter = null;

                // Check if the user wants to store the images by himself
                if (objImagesIndexByImageKey != null && !string.IsNullOrEmpty(objHtmlSettings.ImagesKeyPattern))
                {
                    RtfVisualImageAdapter objAdapter = new RtfVisualImageAdapter(objHtmlSettings.ImagesKeyPattern, objHtmlSettings.ImageFormat);
                    RtfImageConvertSettings objSettings = new RtfImageConvertSettings(objAdapter);
                    objImageConverter = new ImageConverterForCachingImages(objSettings, objImagesIndexByImageKey);
                }

                // Convert the stream into a string and handle any formatting problems like '\0' in the end of the file
                string strConvertedStringFromStream = ConvertStreamToString(objStream);

                // Build the RtfDocument model
                IRtfDocument objRtfDocument = RtfInterpreterTool.BuildDoc(strConvertedStringFromStream, objImageConverter);

                // Get supported setting from the given 'HtmlConvertionSettings'
                RtfHtmlConvertSettings objRtfHtmlConvertSettings = this.GetSettingsForRtfConverter(objHtmlSettings);

                // Create an Html converter
                RtfHtmlConverter objHtmlConverter = new RtfHtmlConverter(objRtfDocument, objRtfHtmlConvertSettings);
                objHtmlConverter.SpecialCharacters.Add(RtfVisualSpecialCharKind.Tabulator, "&nbsp;&nbsp;&nbsp;&nbsp;");

                // Convert
                return objHtmlConverter.Convert();
            }

            return null;
        }

        /// <summary>
        /// Converts the stream to string.
        /// </summary>
        /// <param name="objStream">The obj stream.</param>
        /// <returns></returns>
        private string ConvertStreamToString(Stream objStream)
        {
            StreamReader objReader = new StreamReader(objStream);
            string strContents = objReader.ReadToEnd();

            int index = strContents.LastIndexOf('\0');
            if (index != -1)
            {
                strContents = strContents.Substring(0, index);
            }

            return strContents;
        }

        /// <summary>
        /// Converts a given 'HtmlConvertionSettings' to the 'RtfHtmlConvertSettings' object
        /// </summary>
        /// <param name="objSettings">The settings.</param>
        /// <returns></returns>
        private RtfHtmlConvertSettings GetSettingsForRtfConverter(HtmlConvertionSettings objSettings)
        {
            RtfVisualImageAdapter objAdapter = null;

            // Check if a Url pattern for the images has been given
            if (objSettings != null && !string.IsNullOrEmpty(objSettings.ImagesUrlPattern))
            {
                objAdapter = new RtfVisualImageAdapter(objSettings.ImagesUrlPattern, objSettings.ImageFormat);
            }
            else
            {
                objAdapter = new RtfVisualImageAdapter();
            }

            // Create a default RtfHtmlConvertSettings for the converter
            RtfHtmlConvertSettings objHtmlConverterSettings = new RtfHtmlConvertSettings(objAdapter);

            // Check if and external HtmlConvertionSettings object has been given
            if (objSettings != null)
            {
                #region Render html tags

                RtfHtmlConvertScope enmConvertScope = RtfHtmlConvertScope.None;

                if (objSettings.RenderHtmlTag)
                {
                    enmConvertScope |= RtfHtmlConvertScope.Html;
                }
                if (objSettings.RenderBodyTag)
                {
                    enmConvertScope |= RtfHtmlConvertScope.Body;
                }
                if (objSettings.RenderContent)
                {
                    enmConvertScope |= RtfHtmlConvertScope.Content;
                }
                if (objSettings.RenderHeadTag)
                {
                    enmConvertScope |= RtfHtmlConvertScope.Head;
                }
                if (objSettings.RenderDocument)
                {
                    enmConvertScope |= RtfHtmlConvertScope.Document;
                }

                objHtmlConverterSettings.ConvertScope = enmConvertScope;

                #endregion
            }

            return objHtmlConverterSettings;
        }

        /// <summary>
        /// Writes the converted document to a given outputStream
        /// </summary>
        /// <param name="strConvertedString">The converted string.</param>
        /// <param name="outputStream">The stream.</param>
        private void WriteStringToStream(string strConvertedString, Stream outputStream)
        {
            StreamWriter writer = new StreamWriter(outputStream);
            writer.Write(strConvertedString);
            writer.Flush();
        }
    }
}