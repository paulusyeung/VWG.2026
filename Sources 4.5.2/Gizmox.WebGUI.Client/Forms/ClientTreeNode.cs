#region Using

using System;
using System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
	#region ClientTreeNode Class
	
	/// <summary>
	/// Summary description for ClientTreeNode.
	/// </summary>
	
	public class ClientTreeNode : TreeNode
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ClientTreeNode()
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
		public bool HasNodes
		{
			get
			{
				return this.Nodes.Count>0;
			}
			set
			{
				if(this.Nodes.Count==0 && value)
				{
					TreeNode objNode = new TreeNode();
					objNode.Tag = "$$TEMP";
					this.Nodes.Add(objNode);
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public bool HasDummyNodes
		{
			get
			{
				return this.Nodes.Count>0 && this.Nodes[0].Tag=="$$TEMP";
			}
		}
		
		/// <summary>
		///
		/// </summary>
		new public ContextMenu ContextMenu
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
	
	#endregion ClientTreeNode Class
	
}
