#region Using

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Client.Design;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ClientButton Class
	
	/// <summary>
	/// Summary description for ClientButton.
	/// </summary>
	
	public class ClientButton : Button, IContextContainer
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientButton()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		/// <summary>
		/// Holds the dropdown context menu
		/// </summary>
		private ContextMenu mobjDropDownMenu = null;
		
		
		#endregion Class Members
		
		#region IContextContainer Members
		
		private Gizmox.WebGUI.Common.Interfaces.IContext mobjContext = null;
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		/// <summary>
		///
		/// </summary>
		Gizmox.WebGUI.Common.Interfaces.IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}
		
		
		#endregion IContextContainer Members
		
		#region Methods
		
		/// <summary>
		/// Handles mous down
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			
			// If there is a drop down menu
			if(this.mobjDropDownMenu!=null && e.Button == MouseButtons.Left)
			{
				// Get the context object
				IContextServices objContext = (IContextServices)((IContextContainer)this).Context;
				if(objContext!=null)
				{
					// Get context menu controller
					Controllers.ContextMenuController objContextMenuController = objContext.GetControllerByWinObject(mobjDropDownMenu) as Controllers.ContextMenuController;
					if(objContextMenuController!=null)
					{
						// Set context menu target
						objContextMenuController.SetTarget(this);
						
						// Show context menu
						this.mobjDropDownMenu.Show(this,new Point(0,this.Height));
					}
				}
			}
			
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the button drop down menu
		/// </summary>
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public ContextMenu DropDownMenu
		{
			get
			{
				return mobjDropDownMenu;
			}
			set
			{
				mobjDropDownMenu = value;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ClientButton Class
	
}
