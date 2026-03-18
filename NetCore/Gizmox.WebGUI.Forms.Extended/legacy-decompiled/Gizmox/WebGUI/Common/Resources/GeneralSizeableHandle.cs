using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Common.Resources;

/// <summary>
/// Static gateway that will serve any file or resource accessible by the server
///
/// Names of file resources are always interpreted relative to application's virtual folder,
/// which means a resource named 'test.jpg' will mean a test.jpg file directly on the application's
/// virtual folder.
/// </summary>
[Serializable]
public class GeneralSizeableHandle : GeneralResourceHandle, IStaticGateway
{
	[Serializable]
	private enum ResizeMethod
	{
		/// <summary>
		/// No Scaling
		/// </summary>
		None,
		/// <summary>
		/// Scale and keep propotions. 1 = 100% size
		/// </summary>
		Propotional,
		/// <summary>
		/// Scale to absolute width and height in pixels
		/// </summary>
		Size
	}

	internal const string RESIZE_MODE = "RM";

	internal const string SCALING_FACTOR = "SF";

	internal const string SCALING_HEIGHT = "SH";

	internal const string SCALING_WIDTH = "SW";

	internal const string ROTATE_FLIP = "RF";

	private ResizeMethod menmResizeMethod = ResizeMethod.None;

	private double mdblScalingFactor = 1.0;

	private int mintScalingWidth = 0;

	private int mintScalingHeight = 0;

	private RotateFlipType menmRotateAndFlip = RotateFlipType.RotateNoneFlipNone;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class.
	///
	/// Required by StaticGatewayResourceHandle derived classes - Best practice: No code should be in here.
	///
	/// This constructor is required by the router when serving requests for resources served by this static
	/// gateway and should not contain any code.
	/// </summary>
	public GeneralSizeableHandle()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Propotional scaling (1=100%) with no rotation or flipping .
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
	public GeneralSizeableHandle(string strFileName, double dblScalingFactor)
		: this(strFileName, CommonUtils.GetMimeType(strFileName), dblScalingFactor)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Propotional scaling (1=100%).
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
	/// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
	public GeneralSizeableHandle(string strFileName, double dblScalingFactor, RotateFlipType enmRotateAndFlip)
		: this(strFileName, CommonUtils.GetMimeType(strFileName), dblScalingFactor, enmRotateAndFlip)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Propotional scaling (1=100%) with no rotation or flipping.
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="strContentType">The content type to use when serving the gateway request</param>
	/// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
	public GeneralSizeableHandle(string strFileName, string strContentType, double dblScalingFactor)
		: this(strFileName, strContentType, dblScalingFactor, RotateFlipType.RotateNoneFlipNone)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Propotional scaling (1=100%) .
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="strContentType">The content type to use when serving the gateway request</param>
	/// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
	/// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
	public GeneralSizeableHandle(string strFileName, string strContentType, double dblScalingFactor, RotateFlipType enmRotateAndFlip)
		: base(strFileName, strContentType, typeof(GeneralSizeableHandle).FullName, typeof(GeneralSizeableHandle))
	{
		menmRotateAndFlip = enmRotateAndFlip;
		menmResizeMethod = ResizeMethod.Propotional;
		mdblScalingFactor = dblScalingFactor;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Absolute scaling to pixels with no rotation or flipping.
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
	/// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
	public GeneralSizeableHandle(string strFileName, int intWidth, int intHeight)
		: this(strFileName, CommonUtils.GetMimeType(strFileName), intWidth, intHeight)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Absolute scaling to pixels .
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
	/// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
	/// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
	public GeneralSizeableHandle(string strFileName, int intWidth, int intHeight, RotateFlipType enmRotateAndFlip)
		: this(strFileName, CommonUtils.GetMimeType(strFileName), intWidth, intHeight, enmRotateAndFlip)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Absolute scaling to pixels with no rotation or flipping.
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="strContentType">The content type to use when serving the gateway request</param>
	/// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
	/// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
	public GeneralSizeableHandle(string strFileName, string strContentType, int intWidth, int intHeight)
		: this(strFileName, strContentType, intWidth, intHeight, RotateFlipType.RotateNoneFlipNone)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralSizeableHandle" /> class - Absolute scaling to pixels .
	/// </summary>
	/// <param name="strFileName">The filename to reference</param>
	/// <param name="strContentType">The content type to use when serving the gateway request</param>
	/// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
	/// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
	/// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
	public GeneralSizeableHandle(string strFileName, string strContentType, int intWidth, int intHeight, RotateFlipType enmRotateAndFlip)
		: base(strFileName, CommonUtils.GetMimeType(strFileName), typeof(GeneralSizeableHandle).FullName, typeof(GeneralSizeableHandle))
	{
		menmRotateAndFlip = enmRotateAndFlip;
		menmResizeMethod = ResizeMethod.Size;
		mdblScalingFactor = 1.0;
		mintScalingHeight = intHeight;
		mintScalingWidth = intWidth;
		if (intHeight == 0 && intWidth == 0)
		{
			menmResizeMethod = ResizeMethod.None;
		}
	}

	/// <summary>
	/// Gets the gateway handler.
	/// </summary>
	/// <param name="objContext">Request context.</param>
	/// <returns></returns>
	IStaticGatewayHandler IStaticGateway.GetGatewayHandler(IContext objContext)
	{
		NameValueCollection queryString = objContext.HostContext.Request.QueryString;
		mstrFileName = HttpUtility.UrlDecode(queryString["FN"]);
		mstrContentType = HttpUtility.UrlDecode(queryString["CT"]);
		if (!CommonUtils.TryParse(HttpUtility.UrlDecode(queryString["RM"]), out menmResizeMethod))
		{
			menmResizeMethod = ResizeMethod.None;
		}
		if (!CommonUtils.TryParse(HttpUtility.UrlDecode(queryString["SF"]), out mdblScalingFactor))
		{
			mdblScalingFactor = 1.0;
		}
		if (!CommonUtils.TryParse(HttpUtility.UrlDecode(queryString["SW"]), out mintScalingWidth))
		{
			mintScalingWidth = 0;
		}
		if (!CommonUtils.TryParse(HttpUtility.UrlDecode(queryString["SH"]), out mintScalingHeight))
		{
			mintScalingHeight = 0;
		}
		if (!CommonUtils.TryParse(HttpUtility.UrlDecode(queryString["RF"]), out menmRotateAndFlip))
		{
			menmRotateAndFlip = RotateFlipType.RotateNoneFlipNone;
		}
		Write(objContext, mstrContentType);
		return null;
	}

	/// <summary>
	/// Return a Stream object for the resource being served.
	///
	/// By providing a Stream object for the resource, you can use ToImage() and ToIcon() for resource types
	/// that support them. For instance, it doesn't make sense to to a ToImage() on a text file resource, but
	/// it does make sense for PNG file resource.
	/// </summary>
	/// <returns></returns>
	public override Stream ToStream()
	{
		Stream stream = base.ToStream();
		if (menmResizeMethod == ResizeMethod.Propotional)
		{
			return ImageToStream(ScaleToFactor(stream, mdblScalingFactor, menmRotateAndFlip), GetImageFormat(mstrFileName));
		}
		if (menmResizeMethod == ResizeMethod.Size)
		{
			return ImageToStream(ScaleToSize(stream, mintScalingWidth, mintScalingHeight, menmRotateAndFlip), GetImageFormat(mstrFileName));
		}
		return stream;
	}

	/// <summary>
	/// Gets the specific resource handle  - used for ToString().
	///
	/// The returned value will be the Url used for this particular resource/file.
	/// </summary>
	/// <returns></returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override string GetSpecificResourceHandle()
	{
		return string.Format("{0}&{1}={2}&{3}={4}&{5}={6}&{7}={8}&{9}={10}", base.GetSpecificResourceHandle(), "RM", HttpUtility.UrlEncode(menmResizeMethod.ToString()), "SF", HttpUtility.UrlEncode(mdblScalingFactor.ToString(CultureInfo.InvariantCulture)), "SW", HttpUtility.UrlEncode(mintScalingWidth.ToString(CultureInfo.InvariantCulture)), "SH", HttpUtility.UrlEncode(mintScalingHeight.ToString(CultureInfo.InvariantCulture)), "RF", HttpUtility.UrlEncode(menmRotateAndFlip.ToString()));
	}

	/// <summary>
	/// Scale an image propotionally to a given factor
	/// </summary>
	/// <param name="objImageStream">The image stream</param>
	/// <param name="dblScaleFactor">The factor of scaling, 1 = no scaling</param>
	/// <returns></returns>
	public static Image ScaleToFactor(Stream objImageStream, double dblScaleFactor, RotateFlipType enmRotateAndFlip)
	{
		if (objImageStream.CanSeek)
		{
			objImageStream.Seek(0L, SeekOrigin.Begin);
		}
		using Image image = Image.FromStream(objImageStream);
		if (enmRotateAndFlip != RotateFlipType.RotateNoneFlipNone)
		{
			image.RotateFlip(enmRotateAndFlip);
		}
		int width = image.Width;
		int height = image.Height;
		int x = 0;
		int y = 0;
		int x2 = 0;
		int y2 = 0;
		int width2 = (int)((double)width * dblScaleFactor);
		int height2 = (int)((double)height * dblScaleFactor);
		Bitmap bitmap = new Bitmap(width2, height2, PixelFormat.Format32bppArgb);
		bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image, new Rectangle(x2, y2, width2, height2), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
			graphics.Dispose();
			image.Dispose();
		}
		return bitmap;
	}

	/// <summary>
	/// Scale an image to certain dimensions on width and height
	/// </summary>
	/// <param name="objImageStream"></param>
	/// <param name="Width"></param>
	/// <param name="Height"></param>
	/// <returns></returns>
	protected virtual Image ScaleToSize(Stream objImageStream, int intWidth, int intHeight, RotateFlipType enmRotateAndFlip)
	{
		if (objImageStream.CanSeek)
		{
			objImageStream.Seek(0L, SeekOrigin.Begin);
		}
		using Image image = Image.FromStream(objImageStream);
		if (intWidth == 0)
		{
			return ScaleToFactor(objImageStream, (double)intHeight / (double)image.Height, enmRotateAndFlip);
		}
		if (intHeight == 0)
		{
			return ScaleToFactor(objImageStream, (double)intWidth / (double)image.Width, enmRotateAndFlip);
		}
		if (enmRotateAndFlip != RotateFlipType.RotateNoneFlipNone)
		{
			image.RotateFlip(enmRotateAndFlip);
		}
		int width = image.Width;
		int height = image.Height;
		int x = 0;
		int y = 0;
		int x2 = 0;
		int y2 = 0;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num2 = (float)intWidth / (float)width;
		num3 = (float)intHeight / (float)height;
		if (num3 < num2)
		{
			num = num3;
			x2 = Convert.ToInt16(((float)intWidth - (float)width * num) / 2f);
		}
		else
		{
			num = num2;
			y2 = Convert.ToInt16(((float)intHeight - (float)height * num) / 2f);
		}
		int width2 = (int)((float)width * num);
		int height2 = (int)((float)height * num);
		Bitmap bitmap = new Bitmap(intWidth, intHeight, PixelFormat.Format32bppArgb);
		bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.DrawImage(image, new Rectangle(x2, y2, width2, height2), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
		graphics.Dispose();
		return bitmap;
	}

	/// <summary>
	/// Convert an image to a stream in given image format.
	/// </summary>
	/// <param name="objImage">The image to convert</param>
	/// <param name="enmFormat">The target image format</param>
	/// <returns></returns>
	private static Stream ImageToStream(Image objImage, ImageFormat objFormat)
	{
		Stream stream = new MemoryStream();
		objImage.Save(stream, objFormat);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// Gets the image format.
	/// </summary>
	/// <param name="strFullName">Full name of the string.</param>
	/// <returns></returns>
	private static ImageFormat GetImageFormat(string strFullName)
	{
		switch (Path.GetExtension(strFullName).ToLower())
		{
		case "bmp":
			return ImageFormat.Bmp;
		case "gif":
			return ImageFormat.Gif;
		case "ico":
		case "icon":
			return ImageFormat.Icon;
		case "jpg":
		case "jpeg":
			return ImageFormat.Jpeg;
		case "png":
			return ImageFormat.Png;
		case "tiff":
			return ImageFormat.Tiff;
		case "wmf":
			return ImageFormat.Wmf;
		default:
			return ImageFormat.Png;
		}
	}
}
