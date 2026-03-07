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
	#region ClientTreeView Class
	
	/// <summary>
	/// Summary description for ClientTreeView.
	/// </summary>
	
	public class ClientTreeView : TreeView, IContextContainer
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientTreeView()
		{
			this.MouseUp+=new MouseEventHandler(ClientTreeView_MouseUp);
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
		private void ClientTreeView_MouseUp(object sender, MouseEventArgs e)
		{
			// If context right click
			if(e.Button == MouseButtons.Right)
			{
				ClientTreeNode objClientTreeNode = this.GetNodeAt(e.X,e.Y) as ClientTreeNode;
				if(objClientTreeNode!=null)
				{
					if(objClientTreeNode.ContextMenu!=null)
					{
						// Get the context object
						IContextServices objContext = (IContextServices)((IContextContainer)this).Context;
						if(objContext!=null)
						{
							Controllers.ContextMenuController objContextMenuController = objContext.GetControllerByWinObject(objClientTreeNode.ContextMenu) as Controllers.ContextMenuController;
							if(objContextMenuController!=null)
							{
								objContextMenuController.SetTarget(objClientTreeNode);
								objClientTreeNode.ContextMenu.Show(this,new Point(e.X,e.Y));
							}
						}
					}
				}
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion ClientTreeView Class
	
}
