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
	#region ListViewItemCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ListViewItemCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ListViewItemCollectionController(IContext objContext,object objWebListView,IList objWebColumnHeaders,object objWinListView,IList objWinColumnHeaders) :base(objContext,objWebListView,objWebColumnHeaders,objWinListView,objWinColumnHeaders)
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
			return new ListViewItemController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientListViewItem();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ListView.ListViewItemCollection WebListViewItems
		{
			get
			{
				return base.WebObjects as WebForms.ListView.ListViewItemCollection;
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
		public WinForms.ListView.ListViewItemCollection WinListItems
		{
			get
			{
				return base.WinObjects as WinForms.ListView.ListViewItemCollection;
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
	
	#endregion ListViewItemCollectionController Class
	
}
