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
    public partial class PieChartPage : UserControl
    {
        public PieChartPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Load event of the PieChartPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PieChartPage_Load(object sender, EventArgs e)
        {
            //Define Graph Pane
            GraphPane mobjPane = mobjZedGraph.GraphPane;

            //Set the GraphPane title
            mobjPane.Title.Text = "Graph with Pie Chart";
            mobjPane.Title.FontSpec.Size = 10f;

            //Set the legend to an arbitrary location
            mobjPane.Legend.Position = LegendPos.Float;
            mobjPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            mobjPane.Legend.FontSpec.Size = 10f;
            mobjPane.Legend.IsHStack = false;

            //Add some pie slices
            PieItem segment1 = mobjPane.AddPieSlice(20, Color.Navy, Color.White, 45f, 0, "North");
            PieItem segment3 = mobjPane.AddPieSlice(30, Color.Purple, Color.White, 45f, .0, "East");
            PieItem segment4 = mobjPane.AddPieSlice(10.21, Color.LimeGreen, Color.White, 45f, 0, "West");
            PieItem segment2 = mobjPane.AddPieSlice(40, Color.SandyBrown, Color.White, 45f, 0.2, "South");
            PieItem segment6 = mobjPane.AddPieSlice(250, Color.Red, Color.White, 45f, 0, "Europe");
            PieItem segment7 = mobjPane.AddPieSlice(50, Color.Blue, Color.White, 45f, 0.2, "Pac Rim");
            PieItem segment8 = mobjPane.AddPieSlice(400, Color.Green, Color.White, 45f, 0, "South America");
            PieItem segment9 = mobjPane.AddPieSlice(50, Color.Yellow, Color.White, 45f, 0.2, "Africa");

            //Calculate the Axis Scale Ranges
            mobjZedGraph.AxisChange();
        }

    }
}