#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Resources;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Gizmox.WebGUI.Common.Device.Common;

#endregion

namespace CompanionKit.DeviceIntegration.Notifications
{
    public partial class Example : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Notifications.Vibrate(2000, delegate(EmptyDeviceEventArgs args) 
            {
                ShowConfirmForValidation("Did the device vibrate?", panel1, "Your device may not support vibrations");
            });
        }

        /// <summary>
        /// Build ConfirmOptions from parameters
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="arrButtonOptions"></param>
        /// <returns></returns>
        private static ConfirmOptions buildConfirmOptions(string strTitle, string[] arrButtonOptions)
        {
            ConfirmOptions objOptions = new ConfirmOptions();
            objOptions.Title = strTitle;
            objOptions.ButtonsText = arrButtonOptions;
            return objOptions;
        }

        /// <summary>
        /// Build AlertOptions from parameters
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        private static AlertOptions buildAlertOptions(string strTitle)
        {
            AlertOptions objOptions = new AlertOptions();
            objOptions.Title = strTitle;
            return objOptions;
        }

        private static void ShowConfirmForValidation(string strMessage, Panel objConfermationPanel, string strFailMessage)
        {
            VWGContext.Current.DeviceIntegrator.Notifications.Confirm(strMessage, buildConfirmOptions("Confirm",new string[] { "Yes", "No" }) , delegate(ConfirmEventArgs args)
            {
                switch (args.ButtonIndex)
                {
                    case 1:
                        objConfermationPanel.Visible = true;
                        objConfermationPanel.BackColor = Color.GreenYellow;
                        break;
                    case 2:
                        objConfermationPanel.Visible = true;
                        objConfermationPanel.BackColor = Color.Red;
                        VWGContext.Current.DeviceIntegrator.Notifications.Alert(strFailMessage);
                        break;
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Notifications.Beep(1, delegate(EmptyDeviceEventArgs args)
            {
                ShowConfirmForValidation("Did the device make a sound?", panel2, "Your device may not support sounds or the volumn is very low");                
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Notifications.Alert("This is an alert", buildAlertOptions("This is the alert title"), delegate(EmptyDeviceEventArgs args)
            {
                panel3.Visible = true;
                panel3.BackColor = Color.GreenYellow;
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VWGContext.Current.DeviceIntegrator.Notifications.Confirm("This is a confirm box", buildConfirmOptions("This is the alert title", new string[] { "Yes?", "No?" } ), delegate(ConfirmEventArgs args)
            {
                panel4.Visible = true;
                panel4.BackColor = Color.GreenYellow;

                switch (args.ButtonIndex)
                {
                    case 1:
                        MessageBox.Show("Yes!");
                        break;
                    case 2:
                        MessageBox.Show("No!");
                        break;
                }
            });
        }
    }
}