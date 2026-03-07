#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    /// <summary>
    /// Demonstrates how to use Battery events.
    /// </summary>
    public partial class ExampleBattery : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBattery"/> class.
        /// </summary>
        public ExampleBattery()
        {
            InitializeComponent();

            if (Context != null)
            {
                // Register client BatteryCritical and BatteryLow events.
                // Amitai
                Context.DeviceIntegrator.Events.BatteryCritical += Events_BatteryCritical;
                Context.DeviceIntegrator.Events.BatteryLow += Events_BatteryLow;

                // Register server BatteryStatus event.
                Context.DeviceIntegrator.Events.BatteryStatusChanged += OnBatteryStatusChanged;
            }
        }

        void Events_BatteryLow(Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs obj)
        {
            MessageBox.Show("BATTERY LOW!");
        }

        void Events_BatteryCritical(Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs obj)
        {
            MessageBox.Show("BATTERY CRITICAL!");
        }

        /// <summary>
        /// Handles the <see cref="E:BatteryStatusChanged"/> event.
        /// </summary>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs"/> instance containing the event data.</param>
        void OnBatteryStatusChanged(Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs objArgs)
        {
            mobjLevelLabel.Text = string.Format("Level: {0}%", objArgs.Level);
            mobjPluggedLabel.Text = string.Format("AC: {0}", objArgs.IsPlugged ? "ON" : "OFF");
            mobjBatteryControl.Value = objArgs.Level;
           
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister server event.
            Context.DeviceIntegrator.Events.BatteryStatusChanged -= OnBatteryStatusChanged;
        }
    }
}