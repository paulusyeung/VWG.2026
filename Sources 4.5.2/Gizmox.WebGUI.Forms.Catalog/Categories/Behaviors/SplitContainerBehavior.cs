using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{

    [Serializable()]
    public class SplitContainerBehavior : UserControl
    {
        public SplitContainerBehavior()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        [NonSerialized()]
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.splitContainer2 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.checkBox2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.radioButton3 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightYellow;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(500, 500);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.splitContainer2.Panel1.Controls.Add(this.checkBox2);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightCyan;
            this.splitContainer2.Panel2.Controls.Add(this.radioButton3);
            this.splitContainer2.Panel2.Controls.Add(this.radioButton2);
            this.splitContainer2.Panel2.Controls.Add(this.radioButton1);
            this.splitContainer2.Size = new System.Drawing.Size(257, 257);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.checkBox2.Location = new System.Drawing.Point(13, 44);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(13, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(15, 75);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "radioButton3";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(15, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "radioButton2";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(15, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "radioButton1";
            // 
            // SplitContainerBehavior
            // 
            this.Controls.Add(this.splitContainer1);
            this.Size = new System.Drawing.Size(682, 483);
            this.Text = "SplitContainerBehavior";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer2;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.CheckBox checkBox2;
        private Gizmox.WebGUI.Forms.CheckBox checkBox1;
        private Gizmox.WebGUI.Forms.RadioButton radioButton3;
        private Gizmox.WebGUI.Forms.RadioButton radioButton2;
        private Gizmox.WebGUI.Forms.RadioButton radioButton1;
    }
}
