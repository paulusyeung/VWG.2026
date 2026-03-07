#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.CompanionKit.UI;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    /// <summary>
    /// Demonstrates how to use Pause/Resume events.
    /// </summary>
    public partial class ExamplePauseResume : UserControl
    {
        private int mintEventsCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamplePauseResume"/> class.
        /// </summary>
        public ExamplePauseResume()
        {
            InitializeComponent();

            // Register server pause and resume events.
            Context.DeviceIntegrator.Events.Pause += new Action<EmptyDeviceEventArgs>(OnPause);
            Context.DeviceIntegrator.Events.Resume += new Action<EmptyDeviceEventArgs>(OnResume);
        }

        /// <summary>
        /// Handles the <see cref="E:Resume"/> event.
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnResume(EmptyDeviceEventArgs objArgs)
        {
            InsertEventLabel("Resumed");
        }

        /// <summary>
        /// Handles the <see cref="E:Pause"/> event.
        /// </summary>
        /// <param name="obj">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        void OnPause(EmptyDeviceEventArgs objArgs)
        {
            InsertEventLabel("Paused");
        }

        /// <summary>
        /// Inserts the event label.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        private void InsertEventLabel(string strText)
        {
            DateTime objNow = DateTime.Now;

            //
            // objLabel
            //
            Label objLabel = new Label();
            objLabel.Dock = DockStyle.Top;
            objLabel.Text = string.Format("{0}. {1} on: {2} {3}",mintEventsCounter++, strText, objNow.ToLongTimeString(), objNow.ToLongDateString());
            objLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            objLabel.AutoSize = false;
            objLabel.Height = 40;
            objLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            objLabel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.mobjEventsLogPanel.Controls.Add(objLabel);
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister server events.
            Context.DeviceIntegrator.Events.Pause -= OnPause;
            Context.DeviceIntegrator.Events.Resume -= OnResume;
        }
    }
}