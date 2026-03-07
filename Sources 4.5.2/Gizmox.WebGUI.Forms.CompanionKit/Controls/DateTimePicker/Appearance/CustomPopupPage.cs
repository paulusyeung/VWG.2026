using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    public partial class CustomPopupPage : UserControl
    {
        public CustomPopupPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the CustomPopupPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CustomPopupPage_Load(object sender, EventArgs e)
        {
            //Creates new CustomDateTimePicker instance and adds to the form
            CustomDateTimePicker mobjCustomDateTimePicker = new CustomDateTimePicker();
            mobjCustomDateTimePicker.Location = new Point(20, 20);
            mobjCustomDateTimePicker.Dock = DockStyle.Fill;
            //this.Controls.Add(mobjCustomDateTimePicker);
            this.mobjLayoutPanel.Controls.Add(mobjCustomDateTimePicker, 1, 1);
        }
    }

    public class CustomDateTimePicker : Gizmox.WebGUI.Forms.DateTimePicker 
    {
        //Instance of DateTimePicker
        CustomDateTimePicker mobjCustomDTP;

        /// <summary>
        /// Gets the date time picker popup.
        /// </summary>
        /// <returns></returns>
        protected override DateTimePickerPopup GetDateTimePickerPopup()
        {
            return ModifyInstance(base.GetDateTimePickerPopup());
        }

        /// <summary>
        /// Modifies the instance.
        /// </summary>
        /// <param name="objInstance">The obj instance.</param>
        /// <returns></returns>
        DateTimePickerPopup ModifyInstance(DateTimePickerPopup objInstance)
        {
            //Creates and sets up button control
            Gizmox.WebGUI.Forms.Button mobjInternalButton = new Gizmox.WebGUI.Forms.Button();
            mobjInternalButton.Text = "Set current date";
            mobjInternalButton.Size = new Size(50, 50);
            mobjInternalButton.Dock = DockStyle.Top;
            mobjInternalButton.Click += new EventHandler(mobjInternalButton_Click);
            //Adds button to DTP control
            objInstance.Controls.Add(mobjInternalButton);
            //Sets size DTP
            objInstance.Size = new Size(300, 250);
            //Sets background image of DTP control
            objInstance.Controls[0].BackgroundImageLayout = ImageLayout.Stretch;
            objInstance.Controls[0].BackgroundImage = "Images.DTPBackground.jpg";
            objInstance.Controls[0].BackColor = Color.Aqua;
            //Updates control
            objInstance.Update();
            this.mobjCustomDTP = this;
            return objInstance;
        }

        /// <summary>
        /// Handles the Click event of the mobjInternalButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void mobjInternalButton_Click(object sender, EventArgs e)
        {
            //Sets current time to DTP
            this.mobjCustomDTP.Value = DateTime.Now;
        }
    }
}