using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using ZedGraph;

namespace CompanionKit.Controls.ZedGraph.Functionality
{
    public partial class GraphDemoPage : UserControl
    {
        public GraphDemoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the GraphDemoPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GraphDemoPage_Load(object sender, EventArgs e)
        {
            //Define Graph Pane
            GraphPane mobjPane = mobjZedGraph.GraphPane;

            //Set the Titles
            mobjPane.Title.Text = "Test Graph\n(simple line and bar chart)";
            mobjPane.XAxis.Title.Text = "X Axis";
            mobjPane.YAxis.Title.Text = "Y Axis";

            //Make up some data arrays based on the Sin function
            double x, y1, y2;

            PointPairList objList1 = new PointPairList();
            PointPairList objList2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                objList1.Add(x, y1);
                objList2.Add(x, y2);
            }

            //Generate a red curve with square symbols, and "Porsche" in the legend
            LineItem objCurve1 = mobjPane.AddCurve("Porsche", objList1, Color.Red, SymbolType.Square);

            //Generate a blue curve with circle symbols, and "Piper" in the legend
            LineItem objCurve2 = mobjPane.AddCurve("Piper", objList2, Color.Blue, SymbolType.Circle);

            //Make up some random data points
            double[] yArray = { 10, 15, 7.5, 2.2};
            double[] y2Array = { 9, 10, 9.5, 3.5};
            double[] y3Array = { 8, 11, 6.5, 1.5};
            double[] xArray = { 10, 20, 30, 40};

            //Add bars
            // Generate a red bar with "Bar 1" in the legend
            BarItem myBar = mobjPane.AddBar("Bar 1", xArray, yArray, Color.Beige);
            myBar.Bar.Fill = new Fill(Color.Beige);

            // Generate a blue bar with "Bar 2" in the legend
            myBar = mobjPane.AddBar("Bar 2", xArray, y2Array, Color.LightPink);
            myBar.Bar.Fill = new Fill(Color.LightPink);

            // Generate a green bar with "Bar 3" in the legend
            myBar = mobjPane.AddBar("Bar 3", xArray, y3Array, Color.Lavender);
            myBar.Bar.Fill = new Fill(Color.Lavender);

            //Refigure the axes since the data have changed
            mobjZedGraph.AxisChange();
           
            //Add a caption to graph
            String objCaption = "This is a graph caption";
            TextObj objText = new TextObj(objCaption, 0.3f, 0.3f);
            objText.FontSpec.Angle = 25f;
            objText.FontSpec.FontColor = Color.Black;
            objText.FontSpec.IsBold = true;
            objText.FontSpec.Size = 20;

            //Disable the border and background fill options for the text
            objText.FontSpec.Border.IsVisible = false;
            objText.FontSpec.Fill.IsVisible = false;

            //Align the text such the the Left-Bottom corner is at the specified coordinates
            objText.Location.AlignH = AlignH.Left;
            objText.Location.AlignV = AlignV.Bottom;

            mobjZedGraph.GraphPane.GraphObjList.Add(objText);
            mobjZedGraph.Update();
        }
    }
}