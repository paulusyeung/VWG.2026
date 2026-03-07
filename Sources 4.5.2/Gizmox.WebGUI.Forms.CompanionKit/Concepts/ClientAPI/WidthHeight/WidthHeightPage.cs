using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.WidthHeight;

namespace CompanionKit.Concepts.ClientAPI.WidthHeight
{
    public partial class WidthHeightPage : UserControl
    {
        public WidthHeightPage()
        {
            InitializeComponent();

            //Add info label to user control
            Label mobjLabel = new Label();
                mobjLabel.Dock = DockStyle.Top;
                mobjLabel.Padding = new Padding(10, 10, 0, 0);
                mobjLabel.Text = "'A' and 'D' buttons change width of TextBox, 'S' and 'W' - height.";
                mobjLabel.Size = new Size(20,55);
                mobjLabel.AutoSize=false;
            this.Controls.Add(mobjLabel);

            //Add custom textBox to user control
            //this one also
            MyTextBox mobjTextBox = new MyTextBox();
                mobjTextBox.CustomStyle = "MyTextBoxSkin";
                mobjTextBox.Location = new Point(10, 60);
                mobjTextBox.Multiline=true;
                mobjTextBox.Size = new Size(200,100);
            this.Controls.Add(mobjTextBox);
        }
    }
}