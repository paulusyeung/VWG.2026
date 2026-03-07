#region Using

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ClientPanel Class
	
	/// <summary>
	/// Summary description for Panel.
	/// </summary>
	
	public class ClientPanel : Panel
	{
		#region Class Members
		
		private WebForms.PanelType menmPanelType = WebForms.PanelType.Normal;
		
		
		#endregion Class Members
		
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientPanel()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.PanelType PanelType
		{
			get
			{
				return menmPanelType;
			}
			set
			{
				menmPanelType = value;
				Invalidate(true);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		private Font HeaderFont
		{
			get
			{
				return new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public override System.Drawing.Rectangle DisplayRectangle
		{
			get
			{
				if(menmPanelType==WebForms.PanelType.Titled)
				{
					Rectangle objRect = base.DisplayRectangle;
					
					return new Rectangle(objRect.Left+1,objRect.Top+26,objRect.Right-objRect.Left-2,objRect.Bottom-objRect.Top-28);
				}
				else
				{
					return base.DisplayRectangle;
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if(menmPanelType==WebForms.PanelType.Titled)
				{
					this.Invalidate(false);
				}
			}
		}
		
		
		#endregion Properties
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			if(menmPanelType==WebForms.PanelType.Titled)
			{
				Rectangle rectbg = new Rectangle(0,0,this.Width,this.Height);
				// Fill with gradient
				e.Graphics.FillRectangle(new SolidBrush(Color.White), rectbg);
				
				e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 1), 0, 0, this.Width-1, this.Height-1);
				
				// declare linear gradient brush for fill background of label
				LinearGradientBrush GBrush = new LinearGradientBrush(
				new Point(0, 0),
				new Point(0, 30), Color.Blue, Color.DarkBlue);
				Rectangle rect = new Rectangle(1,1,this.Width-2,25);
				// Fill with gradient
				e.Graphics.FillRectangle(GBrush, rect);
				
				// draw text on label
				SolidBrush drawBrush = new SolidBrush(Color.White);
				StringFormat sf = new StringFormat();
				// align with center
				sf.Alignment = StringAlignment.Near;
				// set rectangle bound text
				RectangleF rectF = new
				RectangleF(5,5,this.Width-7,this.HeaderFont.Height);
				// output string
				e.Graphics.DrawString(this.Text, this.HeaderFont, drawBrush, rectF, sf);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			if(menmPanelType==WebForms.PanelType.Titled)
			{
				this.Invalidate(false);
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion ClientPanel Class
	
}
