using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Interfaces;
using Itenso.Rtf;
using Itenso.Rtf.Converter.Html;
using Itenso.Rtf.Converter.Image;
using Itenso.Rtf.Support;

namespace Gizmox.WebGUI.Converters.Itenso;

public class FormatConverter : IFormatConverter
{
	private class ImageConverterForCachingImages : RtfImageConverter
	{
		private Dictionary<string, byte[]> mobjImagesIndexByImageKey;

		public ImageConverterForCachingImages(RtfImageConvertSettings imageConvertSettings, Dictionary<string, byte[]> imagesIndexByImageKey)
			: base(imageConvertSettings)
		{
			mobjImagesIndexByImageKey = imagesIndexByImageKey;
		}

		protected override void EnsureImagesPath(string imageFileName)
		{
		}

		protected override void SaveImage(byte[] imageBuffer, RtfVisualImageFormat format, string fileName, Size size)
		{
			mobjImagesIndexByImageKey.Add(fileName, imageBuffer);
		}
	}

	public bool CanConvert(FormatConvertionType enmConvertFrom, FormatConvertionType enmConvertTo)
	{
		bool flag = false;
		switch (enmConvertFrom)
		{
		case FormatConvertionType.Rtf:
			flag = true;
			break;
		}
		if (flag)
		{
			switch (enmConvertTo)
			{
			case FormatConvertionType.Rtf:
				flag = false;
				break;
			case FormatConvertionType.Xml:
				flag = false;
				break;
			}
		}
		return flag;
	}

	public Stream Convert(FormatConvertionType enmConvertFromType, FormatConvertionType enmConvertToType, Stream objInputStream, ConvertionSettings objConvertionSettings)
	{
		return Convert(enmConvertFromType, enmConvertToType, objInputStream, objConvertionSettings, null);
	}

	public Stream Convert(FormatConvertionType enmConvertFromType, FormatConvertionType enmConvertToType, Stream objInputStream, ConvertionSettings objConvertionSettings, Dictionary<string, byte[]> objImagesIndexByImageKey)
	{
		if (CanConvert(enmConvertFromType, enmConvertToType))
		{
			Stream stream = null;
			if (enmConvertToType == FormatConvertionType.Html)
			{
				stream = new MemoryStream();
				string converterdHtmlString = GetConverterdHtmlString(enmConvertFromType, objInputStream, objConvertionSettings as HtmlConvertionSettings, objImagesIndexByImageKey);
				WriteStringToStream(converterdHtmlString, stream);
				stream.Position = 0L;
			}
			return stream;
		}
		return null;
	}

	private string GetConverterdHtmlString(FormatConvertionType enmConvertFromType, Stream objStream, HtmlConvertionSettings objHtmlSettings, Dictionary<string, byte[]> objImagesIndexByImageKey)
	{
		string empty = string.Empty;
		if (enmConvertFromType == FormatConvertionType.Rtf)
		{
			ImageConverterForCachingImages imageConverterForCachingImages = null;
			if (objImagesIndexByImageKey != null && !string.IsNullOrEmpty(objHtmlSettings.ImagesKeyPattern))
			{
				RtfVisualImageAdapter imageAdapter = new RtfVisualImageAdapter(objHtmlSettings.ImagesKeyPattern, objHtmlSettings.ImageFormat);
				RtfImageConvertSettings imageConvertSettings = new RtfImageConvertSettings(imageAdapter);
				imageConverterForCachingImages = new ImageConverterForCachingImages(imageConvertSettings, objImagesIndexByImageKey);
			}
			string rtfText = ConvertStreamToString(objStream);
			IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(rtfText, imageConverterForCachingImages);
			RtfHtmlConvertSettings settingsForRtfConverter = GetSettingsForRtfConverter(objHtmlSettings);
			RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument, settingsForRtfConverter);
			rtfHtmlConverter.SpecialCharacters.Add(RtfVisualSpecialCharKind.Tabulator, "&nbsp;&nbsp;&nbsp;&nbsp;");
			return rtfHtmlConverter.Convert();
		}
		return null;
	}

	private string ConvertStreamToString(Stream objStream)
	{
		StreamReader streamReader = new StreamReader(objStream);
		string text = streamReader.ReadToEnd();
		int num = text.LastIndexOf('\0');
		if (num != -1)
		{
			text = text.Substring(0, num);
		}
		return text;
	}

	private RtfHtmlConvertSettings GetSettingsForRtfConverter(HtmlConvertionSettings objSettings)
	{
		RtfVisualImageAdapter rtfVisualImageAdapter = null;
		rtfVisualImageAdapter = ((objSettings == null || string.IsNullOrEmpty(objSettings.ImagesUrlPattern)) ? new RtfVisualImageAdapter() : new RtfVisualImageAdapter(objSettings.ImagesUrlPattern, objSettings.ImageFormat));
		RtfHtmlConvertSettings rtfHtmlConvertSettings = new RtfHtmlConvertSettings(rtfVisualImageAdapter);
		if (objSettings != null)
		{
			RtfHtmlConvertScope rtfHtmlConvertScope = RtfHtmlConvertScope.None;
			if (objSettings.RenderHtmlTag)
			{
				rtfHtmlConvertScope |= RtfHtmlConvertScope.Html;
			}
			if (objSettings.RenderBodyTag)
			{
				rtfHtmlConvertScope |= RtfHtmlConvertScope.Body;
			}
			if (objSettings.RenderContent)
			{
				rtfHtmlConvertScope |= RtfHtmlConvertScope.Content;
			}
			if (objSettings.RenderHeadTag)
			{
				rtfHtmlConvertScope |= RtfHtmlConvertScope.Head;
			}
			if (objSettings.RenderDocument)
			{
				rtfHtmlConvertScope |= RtfHtmlConvertScope.Document;
			}
			rtfHtmlConvertSettings.ConvertScope = rtfHtmlConvertScope;
		}
		return rtfHtmlConvertSettings;
	}

	private void WriteStringToStream(string strConvertedString, Stream outputStream)
	{
		StreamWriter streamWriter = new StreamWriter(outputStream);
		streamWriter.Write(strConvertedString);
		streamWriter.Flush();
	}
}
