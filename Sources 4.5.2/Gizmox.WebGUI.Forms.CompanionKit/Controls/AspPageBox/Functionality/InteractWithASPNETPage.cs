using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.AspPageBox.Functionality
{
    public partial class InteractWithASPNETPage : UserControl
    {
        public InteractWithASPNETPage()
        {
            InitializeComponent();
        }

        private void InteractWithASPNETPage_Load(object sender, EventArgs e)
        {
            this.demoAspPageBox.Path = @"Controls\AspPageBox\Functionality\asppageform.aspx";
        }

        [Serializable()]
        public class MyAspPageBox : Gizmox.WebGUI.Forms.Hosts.AspPageBox
        {

            protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
            {
                base.FireEvent(objEvent);

                if (objEvent.Type == "MessageBox")
                {
                    MessageBox.Show(objEvent["message"]);
                }
            }
        }
    }
}