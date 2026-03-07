#region Using

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ClientForm Class
	
	/// <summary>
	/// Summary description for Form.
	/// </summary>
	
	public class ClientForm : System.Windows.Forms.Form
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
		
		
		#endregion Class Members
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			//
			// ClientForm
			//			
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "ClientForm";
			this.Text = "Form";
			
		}
		
		
		#endregion Windows Form Designer generated code
		
		#region Methods
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint (e);
		}

		
		#endregion Methods
		
	}
	
	#endregion ClientForm Class
	
}
