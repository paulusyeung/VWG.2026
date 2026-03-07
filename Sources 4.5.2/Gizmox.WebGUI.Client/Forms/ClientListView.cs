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
	#region ClientListView Class
	
	/// <summary>
	/// Summary description for ClientListView.
	/// </summary>
	
	public class ClientListView : ListView, IContextContainer
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientListView()
		{
			this.MouseUp+=new MouseEventHandler(ClientListView_MouseUp);
			
			this.FullRowSelect=true;
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region IContextContainer Members
		
		private Gizmox.WebGUI.Common.Interfaces.IContext mobjContext = null;
		
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
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClientListView_MouseUp(object sender, MouseEventArgs e)
		{
			// If context right click
			if(e.Button == MouseButtons.Right)
			{
				
				ClientListViewItem objClientListViewItem = this.GetItemAt(e.X,e.Y) as ClientListViewItem;
				if(objClientListViewItem!=null)
				{
					if(objClientListViewItem.ContextMenu!=null)
					{
						// Get the context object
						IContextServices objContext = (IContextServices)((IContextContainer)this).Context;
						if(objContext!=null)
						{
							Controllers.ContextMenuController objContextMenuController = objContext.GetControllerByWinObject(objClientListViewItem.ContextMenu) as Controllers.ContextMenuController;
							if(objContextMenuController!=null)
							{
								objContextMenuController.SetTarget(objClientListViewItem);
								objClientListViewItem.ContextMenu.Show(this,new Point(e.X,e.Y));
							}
						}
					}
				}
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion ClientListView Class
	
}
