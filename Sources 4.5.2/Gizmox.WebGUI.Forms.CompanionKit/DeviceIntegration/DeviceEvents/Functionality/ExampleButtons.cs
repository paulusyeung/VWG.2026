#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.DeviceIntegration.DeviceEvents.Functionality
{
    /// <summary>
    /// Demonstrates how to use Buttons events.
    /// </summary>
    public partial class ExampleButtons : UserControl
    {
        public ExampleButtons()
        {
            InitializeComponent();

            // Register server button events
            Context.DeviceIntegrator.Events.BackButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnBackButtonPressed);
            Context.DeviceIntegrator.Events.VolumeUpButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnVolumeUpButtonPressed);
            Context.DeviceIntegrator.Events.VolumeDownButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnVolumeDownButtonPressed);
            Context.DeviceIntegrator.Events.MenuButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnMenuButtonPressed);
            Context.DeviceIntegrator.Events.SearchButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnSearchButtonPressed);
            Context.DeviceIntegrator.Events.StartCallButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnStartCallButtonPressed);
            Context.DeviceIntegrator.Events.EndCallButtonPressed += new Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>(OnEndCallButtonPressed);
        }

        /// <summary>
        /// Handles the <see cref="E:EndCallButtonPressed"/> event. ***BlackBerry only***
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnEndCallButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjEndCallPictureBox);
        }

        /// <summary>
        /// Handles the <see cref="E:StartCallButtonPressed"/> event. ***BlackBerry only***
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnStartCallButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjStartCallPictureBox);
        }

        /// <summary>
        /// Handles the <see cref="E:SearchButtonPressed"/> event.
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnSearchButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjSearchPictureBox);

        }

        /// <summary>
        /// Handles the <see cref="E:VolumeDownButtonPressed"/> event. ***BlackBerry only***
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnVolumeDownButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjVolumeDownPictureBox);
        }

        /// <summary>
        /// Handles the <see cref="E:MenuButtonPressed"/> event.
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnMenuButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjMenuPictureBox);

        }

        /// <summary>
        /// Handles the <see cref="E:VolumeUpButtonPressed"/> event. ***BlackBerry only***
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnVolumeUpButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjVolumeUpPictureBox);
        }

        /// <summary>
        /// Handles the <see cref="E:BackButtonPressed"/> event.
        /// </summary>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnBackButtonPressed(Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs objArgs)
        {
            ToggleButtonStateImage(mobjBackPictureBox);
        }

        /// <summary>
        /// Toggles the button state image.
        /// </summary>
        /// <param name="objPictureBox">The obj picture box.</param>
        private void ToggleButtonStateImage(PictureBox objPictureBox)
        {
            string strImageFilename = objPictureBox.BackgroundImage.File;

            objPictureBox.BackgroundImage = new ImageResourceHandle(strImageFilename.Contains("Active") ? strImageFilename.Replace("Active", "") : strImageFilename.Replace(".png", "Active.png"));
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister button events. 
            Context.DeviceIntegrator.Events.BackButtonPressed -= OnBackButtonPressed;
            Context.DeviceIntegrator.Events.VolumeUpButtonPressed -= OnVolumeUpButtonPressed;
            Context.DeviceIntegrator.Events.VolumeDownButtonPressed -= OnVolumeDownButtonPressed;
            Context.DeviceIntegrator.Events.MenuButtonPressed -= OnMenuButtonPressed;
            Context.DeviceIntegrator.Events.SearchButtonPressed -= OnSearchButtonPressed;
            Context.DeviceIntegrator.Events.StartCallButtonPressed -= OnStartCallButtonPressed;
            Context.DeviceIntegrator.Events.EndCallButtonPressed -= OnEndCallButtonPressed;
        }
    }
}