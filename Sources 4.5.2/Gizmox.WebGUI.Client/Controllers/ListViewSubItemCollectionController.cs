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
	#region ListViewSubItemCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ListViewSubItemCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ListViewSubItemCollectionController(IContext objContext,object objWebListViewItem,IList objWebSubItems,object objWinListViewItem,IList objWinSubItems) :base(objContext,objWebListViewItem,objWebSubItems,objWinListViewItem,objWinSubItems)
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
			return new ListViewSubItemController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ListViewItem.ListViewSubItem();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.ListViewItem.ListViewSubItemCollection WebListViewSubItemCollection
		{
			get
			{
				return base.WebObjects as WebForms.ListViewItem.ListViewSubItemCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ListView WebListView
		{
			get
			{
				return base.SourceObject as WebForms.ListView;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.ListViewItem.ListViewSubItemCollection WinListViewSubItemCollection
		{
			get
			{
                return base.WinObjects as WinForms.ListViewItem.ListViewSubItemCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ListView WinListView
		{
			get
			{
				return base.TargetObject as WinForms.ListView;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ListViewSubItemCollectionController Class
	
}
