#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ItemsCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ItemsCollectionController : ObjectCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ItemsCollectionController(IContext objContext,object objWebTreeNode,IList objWebTreeNodes,object objWinTreeNode,IList objWinTreeNodes) :base(objContext,objWebTreeNode,objWebTreeNodes,objWinTreeNode,objWinTreeNodes)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeWinObjects()
		{
			if(this.WebObjects!=null && this.WebObjects!=null)
			{
				// Clear winforms collection
				this.ClearWinObjects();
				
				// Loop all web objects
				foreach(object objWebObject in this.WebObjects)
				{
					// Add winforms object
					this.AddWinObject(objWebObject);
					
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override int OnWebObjectAdded(object objWebObject)
		{
			int intIndex = -1;
			
			// Add winforms object
			intIndex = this.AddWinObject(objWebObject);
			
			return intIndex;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override void OnWebObjectRemoved(object objWebObject)
		{
			this.RemoveWinObject(objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return null;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return objWebObject;
		}
		
		
		#endregion Methods
		
		#region Properties
		
		
		#endregion Properties
		
	}
	
	#endregion ItemsCollectionController Class
	
}
