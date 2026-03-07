#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    /// <summary>
    /// Demonstrates how to use Connectivity events.
    /// </summary>
    public partial class ExampleConnectivity : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleConnectivity"/> class.
        /// </summary>
        public ExampleConnectivity()
        {
            InitializeComponent();

            mobjConnectivityStatePictureBox.ClientId = "mobjConnectivityStatePictureBox";

            // Preload resource for offline state (see Web.config <PreloadedResources> section)
            VWGClientContext.Current.PreloadResources(1, 10000, OnPreloadResourcesComplete);

            // Register Online server event
            Context.DeviceIntegrator.Events.Online += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnOnline);
        }

        /// <summary>
        /// Called when [preload resource complete].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Common.Forms.Client.PreloadResourceCompleteEventArgs"/> instance containing the event data.</param>
        private void OnPreloadResourcesComplete(object sender, PreloadResourcesCompleteEventArgs objArgs)
        {
            string strOfflineImageUrl = mobjConnectivityStatePictureBox.Image.ToString().Replace("online", "offline");
            VWGClientContext.Current.Invoke("onConnectivityOffline", strOfflineImageUrl);
        }

        /// <summary>
        /// Raises the <see cref="E:Online"/> event.
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnOnline(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs obj)
        {
            // Update pictureBox image to 'online'.
            mobjConnectivityStatePictureBox.Image = new ImageResourceHandle(mobjConnectivityStatePictureBox.Image.File.Replace("offline", "online"));
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister Online.
            Context.DeviceIntegrator.Events.Online -= OnOnline;
        }
    }
}