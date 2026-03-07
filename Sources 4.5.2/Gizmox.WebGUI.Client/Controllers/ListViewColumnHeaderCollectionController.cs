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
	#region ListViewColumnHeaderCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
    
	public class ListViewColumnHeaderCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ListViewColumnHeaderCollectionController(IContext objContext,object objWebListView,IList objWebColumnHeaders,object objWinListView,IList objWinColumnHeaders) :base(objContext,objWebListView,objWebColumnHeaders,objWinListView,objWinColumnHeaders)
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
			return new ListViewColumnHeaderController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ColumnHeader();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeWinObjects()
		{
			base.InitializeWinObjects ();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ListView.ColumnHeaderCollection WebListViewColumnHeaders
		{
			get
			{
				return base.WebObjects as WebForms.ListView.ColumnHeaderCollection;
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
		public WinForms.ListView.ColumnHeaderCollection WinListViewColumnHeaders
		{
			get
			{
				return base.WinObjects as WinForms.ListView.ColumnHeaderCollection;
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
	
	#endregion ListViewColumnHeaderCollectionController Class
	
}
