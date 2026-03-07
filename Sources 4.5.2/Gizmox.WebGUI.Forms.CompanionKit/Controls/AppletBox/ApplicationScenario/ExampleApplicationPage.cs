using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.AppletBox.ApplicationScenario
{
    public partial class ExampleApplicationPage : UserControl
    {
        public ExampleApplicationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void ExampleApplicationPage_Load(object sender, EventArgs e)
        {
            // Add parameters for DAEJA Applet.
            this.demoAppletBox.AddParameter("cabbase", "viewone.cab");
            this.demoAppletBox.AddParameter("demo", "document");
            this.demoAppletBox.AddParameter("backcolor", "192,192,192");
            this.demoAppletBox.AddParameter("activecolor", "154,156,206");
            this.demoAppletBox.AddParameter("flipOptions", "true");
            this.demoAppletBox.AddParameter("scale", "ftow");
            this.demoAppletBox.AddParameter("viewmode", "thumbsleft");
            this.demoAppletBox.AddParameter("pagekeys", "true");
            this.demoAppletBox.AddParameter("defaultprintdoc", "true");
            this.demoAppletBox.AddParameter("externalMagnifier", "false");
            this.demoAppletBox.AddParameter("page1", "../docs/mixed/p1.tif");
            this.demoAppletBox.AddParameter("page2", "../docs/mixed/p2.jpg");
            this.demoAppletBox.AddParameter("page3", "../docs/mixed/p3.tif");
            this.demoAppletBox.AddParameter("page4", "../docs/mixed/p4.jpg");
            this.demoAppletBox.AddParameter("thumb1", "../docs/mixed/p1-t.tif");
            this.demoAppletBox.AddParameter("thumb2", "../docs/mixed/p2-t.jpg");
            this.demoAppletBox.AddParameter("thumb3", "../docs/mixed/p3-t.tif");
            this.demoAppletBox.AddParameter("thumb4", "../docs/mixed/p4-t.jpg");
            this.demoAppletBox.AddParameter("thumbLabel1", "Features");
            this.demoAppletBox.AddParameter("thumbLabel2", "Fruit");
            this.demoAppletBox.AddParameter("thumbLabel3", "High resolution");
            this.demoAppletBox.AddParameter("thumbLabel4", "Daeja Image");
            this.demoAppletBox.AddParameter("enhance", "true");
            this.demoAppletBox.AddParameter("enhancemode", "1");
            this.demoAppletBox.AddParameter("allowSelectAnnotation", "true");
            this.demoAppletBox.AddParameter("version3Features", "true");
            this.demoAppletBox.AddParameter("annotationEncoding", "UTF8");
            this.demoAppletBox.AddParameter("annotate", "true");
            this.demoAppletBox.AddParameter("annotateEdit", "true");
        }
    }
}