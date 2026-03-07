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
	#region ToolBarItemCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ToolBarItemCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ToolBarItemCollectionController(IContext objContext,object objWebTreeNode,IList objWebTreeNodes,object objWinTreeNode,IList objWinTreeNodes) :base(objContext,objWebTreeNode,objWebTreeNodes,objWinTreeNode,objWinTreeNodes)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ToolBarButtonController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ToolBarButton();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ToolBarItemCollection WebToolBarItems
		{
			get
			{
				return base.WebObjects as WebForms.ToolBarItemCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ToolBar WebToolBar
		{
			get
			{
				return base.SourceObject as WebForms.ToolBar;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ToolBar WinToolBar
		{
			get
			{
				return base.TargetObject as WinForms.ToolBar;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ToolBarItemCollectionController Class
	
}
