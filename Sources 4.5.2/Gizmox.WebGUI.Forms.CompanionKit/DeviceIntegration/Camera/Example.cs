#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Resources;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

#endregion

namespace CompanionKit.DeviceIntegration.Camera
{
    public partial class Example : UserControl
    {
        private string mstrBase64FormattedString;
        private Image mobjImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHttpContext">The gateway request HTTP context (which is unavailable in non ASP.NET hosting modes).</param>
        /// <param name="strAction">The gateway request action.</param>
        /// <returns>
        /// By default this method returns a instance of a class which implements the IGatewayHandler and
        /// throws a non implemented HttpException.
        /// </returns>
        protected override Gizmox.WebGUI.Common.Interfaces.IGatewayHandler ProcessGatewayRequest(System.Web.HttpContext objHttpContext, string strAction)
        {
            // Ensure no caching
            objHttpContext.Response.CacheControl = "no-cache";
            objHttpContext.Response.AddHeader("Pragma", "no-cache");
            objHttpContext.Response.Expires = -1;
            objHttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            objHttpContext.Response.Cache.SetNoStore();

            // Convert to byte data
            byte[] arrImageByteData = Convert.FromBase64String(mstrBase64FormattedString);

            // Write to response
            objHttpContext.Response.OutputStream.Write(arrImageByteData, 0, arrImageByteData.Length);

            return null;
        }

        /// <summary>
        /// Base64s to image.
        /// </summary>
        /// <param name="strBase64String">The base64 string.</param>
        /// <returns></returns>
        public Image Base64ToImage(string strBase64String)
        {
            // Convert Base64 String to byte[]
            byte[] arrImageBytes = Convert.FromBase64String(strBase64String);

            MemoryStream objMemoryStream = new MemoryStream(arrImageBytes, 0, arrImageBytes.Length);

            // Convert byte[] to Image
            objMemoryStream.Write(arrImageBytes, 0, arrImageBytes.Length);
            Image objImage = Image.FromStream(objMemoryStream, true);

            return objImage;
        }

        /// <summary>
        /// Images to base64.
        /// </summary>
        /// <param name="objImage">The image.</param>
        /// <param name="enmFormat">The format.</param>
        /// <returns></returns>
        public string ImageToBase64(Image objImage, System.Drawing.Imaging.ImageFormat enmFormat)
        {
            using (MemoryStream objMemoryStream = new MemoryStream())
            {
                // Convert Image to byte[]
                objImage.Save(objMemoryStream, enmFormat);

                byte[] arrImageBytes = objMemoryStream.ToArray();

                // Convert byte[] to Base64 String
                string strBase64String = Convert.ToBase64String(arrImageBytes);

                return strBase64String;
            }
        }

        /// <summary>
        /// Build CameraOptions object based on parameters
        /// </summary>
        /// <param name="mQuality"></param>
        /// <param name="mDestinationType"></param>
        /// <returns></returns>
        private static CameraOptions buildCameraOptions(uint mQuality, DestinationType mDestinationType)
        {
            CameraOptions objOptions = new CameraOptions();
            objOptions.Quality = mQuality;
            objOptions.DestinationType = mDestinationType;
            return objOptions;
        }

        /// <summary>
        /// Build CameraOptions object based on parameters
        /// </summary>
        /// <param name="mQuality"></param>
        /// <param name="mSourceType"></param>
        /// <param name="mDestinationType"></param>
        /// <returns></returns>
        private static CameraOptions buildCameraOptions(uint mQuality, PictureSourceType mSourceType, DestinationType mDestinationType)
        {
            CameraOptions objOptions = buildCameraOptions(mQuality, mDestinationType);
            objOptions.SourceType = mSourceType;
            return objOptions;
        }

        /// <summary>
        /// Build CameraOptions object based on parameters
        /// </summary>
        /// <param name="mQuality"></param>
        /// <param name="mSourceType"></param>
        /// <param name="mDestinationType"></param>
        /// <param name="mContainerId"></param>
        /// <returns></returns>
        private static CameraOptions buildCameraOptions(uint mQuality, PictureSourceType mSourceType, DestinationType mDestinationType, long mContainerId)
        {
            CameraOptions objOptions = buildCameraOptions(mQuality, mSourceType, mDestinationType);
            objOptions.StreamContainerID = mContainerId;
            return objOptions;
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Camera.GetPicture(ProcessImageWithFlip,
                buildCameraOptions(20, PictureSourceType.Camera, DestinationType.DataUrl, pictureBox1.ID));
        }

        /// <summary>
        /// Processes the image with flip.
        /// </summary>
        /// <param name="args">The <see cref="Gizmox.WebGUI.Common.Device.Camera.CameraEventArgs"/> instance containing the event data.</param>
        private void ProcessImageWithFlip(CameraEventArgs args)
        {
            if (!args.HasError)
            {
                mobjImage = Base64ToImage(args.ImageData);
                mobjImage.RotateFlip(RotateFlipType.Rotate270FlipY); // For some reason, phonegap sends the image 90 deg rotated in camera mode
                mstrBase64FormattedString = ImageToBase64(mobjImage, ImageFormat.Jpeg);

                this.pictureBox1.Image = new GatewayResourceHandle(this, "base64Image");
            }
            else
            {
                MessageBox.Show(string.Format("An error has occured while trying to get a picture (code: {0} message: {1})", args.ErrorCode, args.ErrorMessage));
            }
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        /// <param name="args">The <see cref="Gizmox.WebGUI.Common.Device.Camera.CameraEventArgs"/> instance containing the event data.</param>
        private void ProcessImage(CameraEventArgs args)
        {
            if (!args.HasError)
            {
                mstrBase64FormattedString = args.ImageData;

                this.pictureBox1.Image = new GatewayResourceHandle(this, "base64Image");
            }
            else
            {
                MessageBox.Show(string.Format("An error has occured while trying to get a picture (code: {0} message: {1})", args.ErrorCode, args.ErrorMessage));
            }
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Camera.GetPicture(ProcessImage,
                buildCameraOptions(20, PictureSourceType.PhotoLibrary, DestinationType.DataUrl));
        }
    }
}