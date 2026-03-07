#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections.Generic;

#endregion Using

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// Represents default device integrator implemented by PhoneGap
    /// </summary>
    [Skin(typeof(DeviceIntegratorSkin))]
    [Serializable]
    public class DeviceIntegrator : RegisteredComponent, ISkinable, IDeviceIntegrator, IRenderableComponent
    {
        #region Members

        private Accelerometer mobjAccelerometer;
        private Camera mobjCamera;
        private Compass mobjCompass;
        private Geolocation mobjGeolocation;
        private Notifications mobjNotifications;
        private DeviceEvents mobjEvents;
        private FileManager mobjFileManager;
        private Contacts mobjContacts;
        private Connection mobjConnection;
        private DeviceInfo mobjDeviceInfo;
        private DeviceMedia mobjMedia;
        private Globalization mobjGlobalizaion;
        private Capture mobjCapture;
        private Splashscreen mobjSplashscreen;
        private Storage mobjStorage;
        private List<DeviceComponent> marrDeviceComponents = new List<DeviceComponent>();

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonegapIntegrator"/> class.
        /// </summary>
        public DeviceIntegrator()
        {
            this.mobjAccelerometer = new Accelerometer(this);
            marrDeviceComponents.Add(mobjAccelerometer);

            this.mobjCamera = new Camera(this);
            marrDeviceComponents.Add(mobjCamera);

            this.mobjCompass = new Compass(this);
            marrDeviceComponents.Add(mobjCompass);

            this.mobjGeolocation = new Geolocation(this);
            marrDeviceComponents.Add(mobjGeolocation);

            this.mobjNotifications = new Notifications(this);
            marrDeviceComponents.Add(mobjNotifications);

            this.mobjEvents = new DeviceEvents(this);
            marrDeviceComponents.Add(mobjEvents);

            this.mobjFileManager = new FileManager(this);
            marrDeviceComponents.Add(mobjFileManager);

            this.mobjContacts = new Contacts(this);
            marrDeviceComponents.Add(mobjContacts);

            this.mobjConnection = new Connection(this);
            marrDeviceComponents.Add(mobjConnection);

            this.mobjDeviceInfo = new DeviceInfo(this);
            marrDeviceComponents.Add(mobjDeviceInfo);

            this.mobjMedia = new DeviceMedia(this);
            marrDeviceComponents.Add(mobjMedia);

            this.mobjGlobalizaion = new Globalization(this);
            marrDeviceComponents.Add(mobjGlobalizaion);

            this.mobjCapture = new Capture(this);
            marrDeviceComponents.Add(mobjCapture);

            this.mobjSplashscreen = new Splashscreen(this);
            marrDeviceComponents.Add(mobjSplashscreen);

            this.mobjStorage = new Storage(this);
            marrDeviceComponents.Add(mobjStorage);
        }

        #endregion C'tors

        #region Properties

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>
        /// The theme related to the skinable component.
        /// </value>
        public string Theme
        {
            get
            {
                if (VWGContext.Current != null)
                {
                    return VWGContext.Current.CurrentTheme;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the current application context.
        /// </summary>
        public override Common.Interfaces.IContext Context
        {
            get { return VWGContext.Current; }
        }

        /// <summary>
        /// Gets the accelerometer.
        /// </summary>
        public IAccelerometer Accelerometer
        {
            get
            {
                return mobjAccelerometer;
            }
        }

        /// <summary>
        /// Gets the camera.
        /// </summary>
        public ICamera Camera
        {
            get
            {
                return mobjCamera;
            }
        }

        /// <summary>
        /// Gets the compass.
        /// </summary>
        public ICompass Compass
        {
            get
            {
                return mobjCompass;
            }
        }

        /// <summary>
        /// Gets the geolocation.
        /// </summary>
        public IGeolocation Geolocation
        {
            get { return mobjGeolocation; }
        }

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        public INotifications Notifications
        {
            get { return mobjNotifications; }
        }

        /// <summary>
        /// Gets the file manager.
        /// </summary>
        public IFileManagement FileManager
        {
            get { return mobjFileManager; }
        }

        /// <summary>
        /// Gets the client events.
        /// </summary>
        public IDeviceEvents Events
        {
            get { return mobjEvents; }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public IConnection Connection
        {
            get
            {
                return mobjConnection;
            }
        }

        /// <summary>
        /// Gets the Device Info.
        /// </summary>
        public IDeviceInfo DeviceInfo
        {
            get
            {
                return mobjDeviceInfo;
            }
        }
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        public IContacts Contacts
        {
            get { return this.mobjContacts; }
        }

        /// <summary>
        /// Gets the Device Info.
        /// </summary>
        public IDeviceMedia Media
        {
            get
            {
                return this.mobjMedia;
            }
        }

        /// <summary>
        /// Gets the device storage.
        /// </summary>
        public IStorage Storage
        {
            get
            {
                return this.mobjStorage;
            }
        }


        /// <summary>
        /// Gets the Capture.
        /// </summary>
        public ICapture Capture
        {
            get { return this.mobjCapture; }
        }

        /// <summary>
        /// Gets the globalization.
        /// </summary>
        public IGlobalization Globalization
        {
            get
            {
                return this.mobjGlobalizaion;
            }
        }

        /// <summary>
        /// Gets the splashscreen.
        /// </summary>
        public ISplashscreen Splashscreen
        {
            get
            {
                return this.mobjSplashscreen;
            }
        }
        #endregion Properties

        #region Methods

        public void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Call the OnRendering event.
            foreach (DeviceComponent objDeviceComponent in marrDeviceComponents)
            {
                objDeviceComponent.OnRendering(objContext, objWriter, lngRequestID);
            }

            if (this.IsDirty(lngRequestID))
            {
                if (!IsRegistered)
                {
                    RegisterSelf();
                }

                objWriter.WriteStartElement(WGTags.DeviceIntegrator);

                (objWriter as IAttributeWriter).WriteAttributeString(WGAttributes.Id, this.ID);

                foreach (DeviceComponent objDeviceComponent in marrDeviceComponents)
                {
                    objDeviceComponent.RenderComponent(objContext, objWriter, lngRequestID);
                }

                objWriter.WriteEndElement();
            }

            // Call the OnRendered event.
            foreach (DeviceComponent objDeviceComponent in marrDeviceComponents)
            {
                objDeviceComponent.OnRendered(objContext, objWriter, lngRequestID);
            }
        }

        #endregion Methods

        /// <summary>
        /// 
        /// </summary>
        public static class ConnectionType
        {
            public const string TYPE_UNKNOWN = "unknown";
            public const string TYPE_ETHERNET = "ethernet";
            public const string TYPE_WIFI = "wifi";
            public const string TYPE_CELL_2G = "2g";
            public const string TYPE_CELL_3G = "3g";
            public const string TYPE_CELL_4G = "4g";
            public const string TYPE_NONE = "none";
        }
    }

}
