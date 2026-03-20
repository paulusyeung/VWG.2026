#region Using

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.IO;
using System.Web;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Hosting;
#endregion Using



namespace Gizmox.WebGUI.Forms.Catalog.Categories.Gateways.Controls
{
	/// <summary>
	/// Summary description for PieControl.
	/// </summary>

    [Serializable()]
    public class PieControl : PictureBox
	{
		private int[] dataValues = new int[]{};
		private string[] dataLabels = new string[]{};

		public PieControl()
		{
			this.Image = new GatewayResourceHandle(new GatewayReference(this,"graph"));
			this.SizeMode = PictureBoxSizeMode.Normal;
		}

		public int[] Values
		{
			get
			{
				return dataValues;
			}
			set
			{
				dataValues = value;
			}
		}

		public string[] Labels
		{
			get
			{
				return dataLabels;
			}
			set
			{
				dataLabels = value;
			}
		}

        /// <summary>
        ///  Downloads the graph to a given file
        /// </summary>
        /// <param name="strFileName"></param>
        public void Download(string strFileName)
        {
            Link.Download(new GatewayResourceHandle(this, "graph"), string.Format("{0}.jpg", strFileName));
        }


        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void DrawControl(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the pie bitmap
            using (Bitmap objBitmap = GetPieBitmap())
            {
                // Draw the image
                objGraphics.DrawImage(objBitmap, new Point(0, 0));
            }
            
        }

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHostContext">The gateway request host context.</param>
        /// <param name="strAction">The gateway request action.</param>
        /// <returns>
        /// By default this method returns a instance of a class which implements the IGatewayHandler and
        /// throws a non implemented HttpException.
        /// </returns>
        /// <remarks>
        /// This method is called from the implementation of IGatewayComponent which replaces the
        /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
        /// RegisteredComponent class which is the base class of most of the Visual WebGui
        /// components.
        /// Referencing a RegisterComponent that overrides this method is done the same way that
        /// a control implementing IGatewayControl, which is by using the GatewayReference class.
        /// </remarks>
        protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
        {
            // If is "graph" action print a graph to the response, otherwise let the base class handle the request.
            if (strAction == "graph")
            {
                // Since we are outputting a Jpeg, set the ContentType appropriately
                objHostContext.Response.ContentType = "image/jpeg";

                // Get the pie bitmap
                using (Bitmap objBitmap = GetPieBitmap())
                {
                    // Save the image to a file
                    objBitmap.Save(objHostContext.Response.OutputStream, ImageFormat.Jpeg);
                }

                return null;
            }
            else
            {
                return base.ProcessGatewayRequest(objHostContext, strAction);
            }
        }

        /// <summary>
        /// Gets the pie bitmap.
        /// </summary>
        /// <returns></returns>
        private Bitmap GetPieBitmap()
        {
            // find the total of the numeric data
            float total = 100;
            int width = 300;
            string title = "What do we eat and drink?";

            int iLoop = 0;

            // we need to create fonts for our legend and title
            Font fontLegend = new Font("Verdana", 10), fontTitle = new Font("Verdana", 15, FontStyle.Bold);

            // We need to create a legend and title, how big do these need to be?
            // Also, we need to resize the height for the pie chart, respective to the
            // height of the legend and title
            const int bufferSpace = 15;
            int legendHeight = CommonUtils.GetFontHeight(fontLegend) * (dataValues.Length + 1) + bufferSpace;
            int titleHeight = CommonUtils.GetFontHeight(fontTitle) + bufferSpace;
            int height = width + legendHeight + titleHeight + bufferSpace;
            int pieHeight = width;	// maintain a one-to-one ratio

            // Create a rectange for drawing our pie
            Rectangle pieRect = new Rectangle(0, titleHeight, width, pieHeight);

            // Create our pie chart, start by creating an ArrayList of colors
            ArrayList colors = new ArrayList();
            Random rnd = new Random();
            for (iLoop = 0; iLoop < dataValues.Length; iLoop++)
                colors.Add(new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))));

            float currentDegree = 0.0F;

            // Create a Bitmap instance	
            Bitmap objBitmap = new Bitmap(width, height);
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            SolidBrush blackBrush = new SolidBrush(Color.Black);

            // Put a white backround in
            objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            for (iLoop = 0; iLoop < dataValues.Length; iLoop++)
            {
                objGraphics.FillPie((SolidBrush)colors[iLoop], pieRect, currentDegree,
                    dataValues[iLoop] / total * 360);

                // increment the currentDegree
                currentDegree += Convert.ToSingle(dataValues[iLoop]) / total * 360;
            }

            // Create the title, centered
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            objGraphics.DrawString(title, fontTitle, blackBrush,
                new Rectangle(0, 0, width, titleHeight), stringFormat);


            // Create the legend
            objGraphics.DrawRectangle(new Pen(Color.Black, 2), 0, height - legendHeight, width, legendHeight);
            for (iLoop = 0; iLoop < dataValues.Length; iLoop++)
            {
                objGraphics.FillRectangle((SolidBrush)colors[iLoop], 5,
                    height - legendHeight + CommonUtils.GetFontHeight(fontLegend) * iLoop + 5, 10, 10);
                objGraphics.DrawString(dataLabels[iLoop], fontLegend, blackBrush,
                    20, height - legendHeight + CommonUtils.GetFontHeight(fontLegend) * iLoop + 1);
            }

            // display the total
            objGraphics.DrawString("Total: " + Convert.ToString(total), fontLegend, blackBrush,
                5, height - CommonUtils.GetFontHeight(fontLegend) - 5);

     

            // clean up...
            objGraphics.Dispose();
            return objBitmap;
        }

		

	}
}
