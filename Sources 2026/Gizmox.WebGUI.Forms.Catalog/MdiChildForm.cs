#region Using

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms.Catalog
{
	#region MdiChildForm Class
	
	/// <summary>
	/// Summary description for AboutVWGForm.
	/// </summary>

    [Serializable()]
    public class MdiChildForm : Form
	{
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
		
		#region C'Tor\D'Tor
		
		/// <summary>
		///
		/// </summary>
        public MdiChildForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

		}

        /// <summary>
		///
		/// </summary>
        public MdiChildForm(Control objControl) : this()
        {
            objControl.Dock = DockStyle.Fill;
            this.Controls.Add(objControl);
        }
		
		
		#endregion C'Tor\D'Tor
		
		#region Form Designer generated code
		
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // MdiChildForm
            // 
            this.ClientSize = new System.Drawing.Size(537, 416);
            this.Size = new System.Drawing.Size(537, 416);
            this.ResumeLayout(false);

		}
		
		
		#endregion Form Designer generated code
		

		
	}
	
	#endregion AboutVWGForm Class
	
}
