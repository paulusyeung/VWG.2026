#region Using

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ClientListViewItem Class
	
	/// <summary>
	/// Summary description for ClientListView.
	/// </summary>
	
	public class ClientListViewItem : ListViewItem
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientListViewItem()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		private ContextMenu mobjContextMenu = null;
		
		
		#endregion Class Members
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public ContextMenu ContextMenu
		{
			get
			{
				return mobjContextMenu;
			}
			set
			{
				mobjContextMenu = value;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ClientListViewItem Class
	
}
