#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Gizmox.WebGUI.Client.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region MenuItemCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class MenuItemCollectionController : ComponentCollectionController
	{
		#region Class Members
		
		private ClientMenuStyleProvider mobjSpecialMenuProvider = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public MenuItemCollectionController(IContext objContext,object objWebMenuItem,IList objWebMenuItems,object objWinMenuItem,IList objWinMenuItems) :base(objContext,objWebMenuItem,objWebMenuItems,objWinMenuItem,objWinMenuItems)
		{
			mobjSpecialMenuProvider = new ClientMenuStyleProvider();
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new MenuItemController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			WinForms.MenuItem objMenuItem = new WinForms.MenuItem();
			objMenuItem.OwnerDraw = true;
			mobjSpecialMenuProvider.SetNewStyleActive(objMenuItem,true);
			return objMenuItem;
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController ();
			
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.MenuItemCollection WebMenuItemCollection
		{
			get
			{
                return base.SourceObject as WebForms.MenuItemCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.Menu.MenuItemCollection WinMenuItemCollection
		{
			get
			{
				return base.TargetObject as WinForms.Menu.MenuItemCollection;
			}
		}
		
		#endregion Properties
		
	}
	
	#endregion MenuItemCollectionController Class
	
}
