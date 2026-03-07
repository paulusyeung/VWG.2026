using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Hosting;


namespace Gizmox.WebGUI.Common.Resources
{
    /// <summary>
    /// Static gateway that will serve any file or resource accessible by the server
    /// 
    /// Names of file resources are always interpreted relative to application's virtual folder,
    /// which means a resource named 'test.jpg' will mean a test.jpg file directly on the application's
    /// virtual folder.
    /// </summary>
    [Serializable()]
    public class GeneralSizeableHandle : GeneralResourceHandle, IStaticGateway
    {
        #region Enumerations

        [Serializable()]
        private enum ResizeMethod
        {
            /// <summary>
            /// No Scaling
            /// </summary>
            None = 0,

            /// <summary>
            /// Scale and keep propotions. 1 = 100% size
            /// </summary>
            Propotional = 1,

            /// <summary>
            /// Scale to absolute width and height in pixels
            /// </summary>
            Size = 2
        }

        #endregion

        #region Private Class Members for internal use
        
        internal const string RESIZE_MODE = "RM";
        internal const string SCALING_FACTOR = "SF";
        internal const string SCALING_HEIGHT = "SH";
        internal const string SCALING_WIDTH = "SW";
        internal const string ROTATE_FLIP = "RF";

        private ResizeMethod menmResizeMethod = ResizeMethod.None;
        private double mdblScalingFactor = 1;
        private int mintScalingWidth = 0;
        private int mintScalingHeight = 0;
        private RotateFlipType menmRotateAndFlip = RotateFlipType.RotateNoneFlipNone;

        #endregion

        #region C'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class.
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
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Propotional scaling (1=100%) with no rotation or flipping .
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
        public GeneralSizeableHandle(string strFileName, double dblScalingFactor)
            : this(strFileName, CommonUtils.GetMimeType(strFileName), dblScalingFactor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Propotional scaling (1=100%).
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
        /// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
        public GeneralSizeableHandle(string strFileName, double dblScalingFactor, RotateFlipType enmRotateAndFlip)
            : this(strFileName, CommonUtils.GetMimeType(strFileName), dblScalingFactor, enmRotateAndFlip)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Propotional scaling (1=100%) with no rotation or flipping.
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="strContentType">The content type to use when serving the gateway request</param>
        /// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
        public GeneralSizeableHandle(string strFileName, string strContentType, double dblScalingFactor)
            : this(strFileName, strContentType, dblScalingFactor, RotateFlipType.RotateNoneFlipNone)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Propotional scaling (1=100%) .
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="strContentType">The content type to use when serving the gateway request</param>
        /// <param name="dblScalingFactor">Scaling factor, 1 = no scaling.</param>
        /// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
        public GeneralSizeableHandle(string strFileName, string strContentType, double dblScalingFactor, RotateFlipType enmRotateAndFlip)
            : base(strFileName, strContentType, typeof(GeneralSizeableHandle).FullName, typeof(GeneralSizeableHandle))
        {
            this.menmRotateAndFlip = enmRotateAndFlip;
            this.menmResizeMethod = ResizeMethod.Propotional;
            this.mdblScalingFactor = dblScalingFactor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Absolute scaling to pixels with no rotation or flipping.
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
        /// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
        public GeneralSizeableHandle(string strFileName, int intWidth, int intHeight)
            : this(strFileName, CommonUtils.GetMimeType(strFileName), intWidth, intHeight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Absolute scaling to pixels .
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
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Absolute scaling to pixels with no rotation or flipping.
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
        /// Initializes a new instance of the <see cref="GeneralSizeableHandle"/> class - Absolute scaling to pixels .
        /// </summary>
        /// <param name="strFileName">The filename to reference</param>
        /// <param name="strContentType">The content type to use when serving the gateway request</param>
        /// <param name="intWidth">Scale to absolute width, 0 = scale in same propotions as Height</param>
        /// <param name="intHeight">Scale to absolute height, 0 = scal in same propotions as Width</param>
        /// <param name="enmRotateAndFlip">Rotate and Flip method.</param>
        public GeneralSizeableHandle(string strFileName, string strContentType, int intWidth, int intHeight, RotateFlipType enmRotateAndFlip)
            : base(strFileName, CommonUtils.GetMimeType(strFileName), typeof(GeneralSizeableHandle).FullName, typeof(GeneralSizeableHandle))
        {
            this.menmRotateAndFlip = enmRotateAndFlip;
            this.menmResizeMethod = ResizeMethod.Size;
            this.mdblScalingFactor = 1;
            this.mintScalingHeight = intHeight;
            this.mintScalingWidth = intWidth;

            // If both are zero, there is no scaling
            if (intHeight == 0 && intWidth == 0)
            {
                this.menmResizeMethod = ResizeMethod.None;
            }
        }

        #endregion

        #region IStaticGateway Members

        /// <summary>
        /// Gets the gateway handler.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <returns></returns>
        IStaticGatewayHandler IStaticGateway.GetGatewayHandler(IContext objContext)
        {
            // Get request and response
            System.Collections.Specialized.NameValueCollection objQueryCollection = objContext.HostContext.Request.QueryString;

            // Get filename and content type from decoded query parameters
            this.mstrFileName = HttpUtility.UrlDecode(objQueryCollection[FULL_NAME]);
            this.mstrContentType = HttpUtility.UrlDecode(objQueryCollection[CONTENT_TYPE]);

            if (!CommonUtils.TryParse(HttpUtility.UrlDecode(objQueryCollection[RESIZE_MODE]), out this.menmResizeMethod))
            {
                this.menmResizeMethod = ResizeMethod.None;
            }

            if (!CommonUtils.TryParse(HttpUtility.UrlDecode(objQueryCollection[SCALING_FACTOR]), out this.mdblScalingFactor))
            {
                this.mdblScalingFactor = 1;
            }
            if (!CommonUtils.TryParse(HttpUtility.UrlDecode(objQueryCollection[SCALING_WIDTH]), out this.mintScalingWidth))
            {
                this.mintScalingWidth = 0;
            }
            if (!CommonUtils.TryParse(HttpUtility.UrlDecode(objQueryCollection[SCALING_HEIGHT]), out this.mintScalingHeight))
            {
                this.mintScalingHeight = 0;
            }
            if (!CommonUtils.TryParse(HttpUtility.UrlDecode(objQueryCollection[ROTATE_FLIP]), out this.menmRotateAndFlip))
            {
                this.menmRotateAndFlip = RotateFlipType.RotateNoneFlipNone;
            }

            this.Write(objContext, mstrContentType);

            // Return null = handled
            return null;
        }

        #endregion

        #region StaticGatewayResourceHandle Members

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
            Stream objImageStream = base.ToStream();

            if (this.menmResizeMethod == ResizeMethod.Propotional)
            {
                return ImageToStream(ScaleToFactor(objImageStream, this.mdblScalingFactor, this.menmRotateAndFlip), GetImageFormat(mstrFileName));
            }
            else if (this.menmResizeMethod == ResizeMethod.Size)
            {
                return ImageToStream(ScaleToSize(objImageStream, this.mintScalingWidth, this.mintScalingHeight, this.menmRotateAndFlip), GetImageFormat(mstrFileName));
            }

            return objImageStream;
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
            return string.Format("{0}&{1}={2}&{3}={4}&{5}={6}&{7}={8}&{9}={10}",
                base.GetSpecificResourceHandle(),
                RESIZE_MODE,
                HttpUtility.UrlEncode(this.menmResizeMethod.ToString()),
                SCALING_FACTOR,
                HttpUtility.UrlEncode(this.mdblScalingFactor.ToString(System.Globalization.CultureInfo.InvariantCulture)),
                SCALING_WIDTH,
                HttpUtility.UrlEncode(this.mintScalingWidth.ToString(System.Globalization.CultureInfo.InvariantCulture)),
                SCALING_HEIGHT,
                HttpUtility.UrlEncode(this.mintScalingHeight.ToString(System.Globalization.CultureInfo.InvariantCulture)),
                ROTATE_FLIP, 
                HttpUtility.UrlEncode(this.menmRotateAndFlip.ToString()));
        }

        #endregion

        #region Private helpers

        #region Resize helpers
        // Reference: http://www.codeproject.com/Articles/2941/Resizing-a-Photographic-image-with-GDI-for-NET

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
                objImageStream.Seek(0, SeekOrigin.Begin);
            }

            using (Image objImage = Image.FromStream(objImageStream))
            {
                // If rotation or flipping is needed
                if (enmRotateAndFlip != RotateFlipType.RotateNoneFlipNone)
                    objImage.RotateFlip(enmRotateAndFlip);

                int intSourceWidth = objImage.Width;
                int intSourceHeight = objImage.Height;
                int intSourceX = 0;
                int intSourceY = 0;

                int intDestX = 0;
                int intDestY = 0;
                int intDestWidth = (int)(intSourceWidth * dblScaleFactor);
                int intDestHeight = (int)(intSourceHeight * dblScaleFactor);

                Bitmap objBitmap = new Bitmap(intDestWidth, intDestHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                objBitmap.SetResolution(objImage.HorizontalResolution, objImage.VerticalResolution);

                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    objGraphics.DrawImage(objImage, new Rectangle(intDestX, intDestY, intDestWidth, intDestHeight), new Rectangle(intSourceX, intSourceY, intSourceWidth, intSourceHeight), GraphicsUnit.Pixel);

                    objGraphics.Dispose();
                    objImage.Dispose();
                }
                return objBitmap;
            }
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
                objImageStream.Seek(0, SeekOrigin.Begin);
            }

            using (Image objImage = Image.FromStream(objImageStream))
            {
                // If either target width or height is 0, scale propotionally to the other dimension
                if (intWidth == 0)
                {
                    return ScaleToFactor(objImageStream, ((double)intHeight) / ((double)objImage.Height), enmRotateAndFlip);
                }
                else if (intHeight == 0)
                {
                    return ScaleToFactor(objImageStream, ((double)intWidth) / ((double)objImage.Width), enmRotateAndFlip);
                }

                // If rotation or flipping is needed
                if (enmRotateAndFlip != RotateFlipType.RotateNoneFlipNone)
                    objImage.RotateFlip(enmRotateAndFlip);

                int intSourceWidth = objImage.Width;
                int intSourceHeight = objImage.Height;
                int intSourceX = 0;
                int intSourceY = 0;
                int intDestX = 0;
                int intDestY = 0;

                float fltFactor = 0;
                float fltFactorWidth = 0;
                float fltFactorHeight = 0;

                fltFactorWidth = ((float)intWidth / (float)intSourceWidth);
                fltFactorHeight = ((float)intHeight / (float)intSourceHeight);
                if (fltFactorHeight < fltFactorWidth)
                {
                    fltFactor = fltFactorHeight;
                    intDestX = System.Convert.ToInt16((intWidth - (intSourceWidth * fltFactor)) / 2);
                }
                else
                {
                    fltFactor = fltFactorWidth;
                    intDestY = System.Convert.ToInt16((intHeight - (intSourceHeight * fltFactor)) / 2);
                }

                int destWidth = (int)(intSourceWidth * fltFactor);
                int destHeight = (int)(intSourceHeight * fltFactor);

                Bitmap objBitmap = new Bitmap(intWidth, intHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                objBitmap.SetResolution(objImage.HorizontalResolution, objImage.VerticalResolution);

                Graphics objGraphics = Graphics.FromImage(objBitmap);
                objGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                objGraphics.DrawImage(objImage, new Rectangle(intDestX, intDestY, destWidth, destHeight), new Rectangle(intSourceX, intSourceY, intSourceWidth, intSourceHeight), GraphicsUnit.Pixel);

                objGraphics.Dispose();
                return objBitmap;
            }
        }
        
        /// <summary>
        /// Convert an image to a stream in given image format.
        /// </summary>
        /// <param name="objImage">The image to convert</param>
        /// <param name="enmFormat">The target image format</param>
        /// <returns></returns>
        private static Stream ImageToStream(Image objImage,ImageFormat objFormat)
        {
            Stream objStream = new MemoryStream();

            objImage.Save(objStream, objFormat);
            objStream.Position = 0;

            return objStream;
        }

        /// <summary>
        /// Gets the image format.
        /// </summary>
        /// <param name="strFullName">Full name of the string.</param>
        /// <returns></returns>
        private static ImageFormat GetImageFormat(string strFullName)
        {
            string strExtension = System.IO.Path.GetExtension(strFullName).ToLower();
            switch (strExtension)
            {
                case "bmp": return ImageFormat.Bmp;
                case "gif": return ImageFormat.Gif;
                case "ico":
                case "icon": return ImageFormat.Icon;
                case "jpg":
                case "jpeg": return ImageFormat.Jpeg;
                case "png": return ImageFormat.Png;
                case "tiff": return ImageFormat.Tiff;
                case "wmf": return ImageFormat.Wmf;
                default: return ImageFormat.Png;
            }
        }

        #endregion

        #endregion

    }
}