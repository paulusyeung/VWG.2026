using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Camera : DeviceComponent, ICamera
    {
        private SingleCallMethodStore<CameraEventArgs> mobjCameraMethodStore;
        private SingleCallMethodStore<CleanupEventArgs> mobjClearMethodStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public Camera(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        {

        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Camera_Initialize", ID);
        }

        /// <summary>
        /// Cleans up the image files that were taken by the camera, that were stored in a temporary storage location.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void Cleanup(Action<CleanupEventArgs> objCallback)
        {
            if (mobjClearMethodStore == null)
            {
                mobjClearMethodStore = new SingleCallMethodStore<CleanupEventArgs>();
            }

            string strMethodKey = mobjClearMethodStore.StoreSingleCallMethod("cln", objCallback);

            Invoke("DeviceIntegrator.Camera.cleanup", strMethodKey);
        }

        /// <summary>
        /// Gets A picture with given options.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void GetPicture(Action<Common.Device.Camera.CameraEventArgs> objCallback, Common.Device.Camera.CameraOptions objOptions)
        {
            if (mobjCameraMethodStore == null)
            {
                mobjCameraMethodStore = new SingleCallMethodStore<CameraEventArgs>();
            }

            string strMethodKey = mobjCameraMethodStore.StoreSingleCallMethod("pic", objCallback);
            
            IClientJsonObject objJsonOptions = null;
            if (objOptions != null)
            {
                objJsonOptions = CommonUtils.GetClientJsonObject(objOptions);
            }
            Invoke("DeviceIntegrator.Camera.getPicture", strMethodKey, objJsonOptions);
        }

        /// <summary>
        /// Gets a picture with default options.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetPicture(Action<Common.Device.Camera.CameraEventArgs> objCallback)
        {
            GetPicture(objCallback, null);
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Camera;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            HandleEvent(objEvent);
        }

        private void HandleEvent(Common.Interfaces.IEvent objEvent)
        {
            string strMethodKey = objEvent.Type;

            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(strMethodKey);

            switch (objSplittedValues.Key)
            {
                case "pic":
                    // Insert to args - maybe remove irrelevant args
                    CameraEventArgs objArguments = GetCameraArgumentsFromEvent(objEvent);

                    if (mobjCameraMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjCameraMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objArguments);
                    }
                    break;
                case "cln":
                    CleanupEventArgs objCleanupArguments = GetCleanupEventArgs(objEvent);

                    if (mobjClearMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjClearMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objCleanupArguments);
                    }

                    break;
                default:
                    // Throw ??
                    break;
            }
        }

        /// <summary>
        /// Gets the cleanup event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private CleanupEventArgs GetCleanupEventArgs(Common.Interfaces.IEvent objEvent)
        {
            CleanupEventArgs objArguments = null;

            if (!CameraBaseEventArgs.TryGetCameraError(objEvent, out objArguments))
            {
                objArguments = new CleanupEventArgs();

            }

            return objArguments;
        }

        /// <summary>
        /// Gets the camera arguments from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private CameraEventArgs GetCameraArgumentsFromEvent(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            CameraEventArgs objArguments = null;

            if (!CameraBaseEventArgs.TryGetCameraError(objEvent, out objArguments))
            {
                string strImageData = objEvent.Value;
                string strFileUri = objEvent["FileUri"];

                if (!string.IsNullOrEmpty(strImageData) || !string.IsNullOrEmpty(strFileUri))
                {
                    objArguments = new CameraEventArgs(strFileUri, strImageData);
                }
            }

            return objArguments;
        }

    }
}
