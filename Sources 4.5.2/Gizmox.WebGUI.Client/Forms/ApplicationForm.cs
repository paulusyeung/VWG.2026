#region Using

using System;
using System.Drawing;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using Gizmox.WebGUI.Client.Controllers;
using WebCommon = Gizmox.WebGUI.Common;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Design;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ApplicationForm Class
	
	/// <summary>
	/// Summary description for Container.
	/// </summary>
	
	internal class ApplicationForm : ClientForm
	{
		#region C'Tor/D'Tor
		
		private Context mobjContext = null;
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objType"></param>
		/// <param name="objContext"></param>
		internal ApplicationForm(Type objType,Context objContext)
		{
			mobjContext = objContext;
			InitializeComponent(objType);
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		private void InitializeComponent(Type objType)
		{
			
			// Create application context
			WebCommon.Global.Context = mobjContext;
			
			// Create the application main form
			WebForms.Form objWebForm = Activator.CreateInstance(objType) as WebForms.Form;
			if(objWebForm!=null)
			{
				// Set form visibility
				objWebForm.Visible = true;
				
				// Create controller and initialize
				FormController objController = new FormController(mobjContext,objWebForm,this);
				mobjContext.MainForm = objWebForm;
				((IContextServices)mobjContext).RegisterController(objController);
				objController.Initialize();
				objController.Load();
				
			}
			
			
		}
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
		
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
			base.Dispose(disposing);
		}
		
		
		#endregion Windows Form Designer generated code
		
		#endregion Methods
		
	}
	
	#endregion ApplicationForm Class
	
}
