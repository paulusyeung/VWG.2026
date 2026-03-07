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
	#region StatusPanelCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
	
	public class StatusPanelCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public StatusPanelCollectionController(IContext objContext,object objWebTreeNode,IList objWebTreeNodes,object objWinTreeNode,IList objWinTreeNodes) :base(objContext,objWebTreeNode,objWebTreeNodes,objWinTreeNode,objWinTreeNodes)
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
			return new StatusBarPanelController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.StatusBarPanel();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.StatusBar.StatusBarPanelCollection WebStatusPanelItems
		{
			get
			{
                return base.WebObjects as WebForms.StatusBar.StatusBarPanelCollection;
			}
		}

        /// <summary>
        ///
        /// </summary>
        public WinForms.StatusBar.StatusBarPanelCollection WinStatusPanelItems
        {
            get
            {
                return base.WebObjects as WinForms.StatusBar.StatusBarPanelCollection;
            }
        }
		
		/// <summary>
		///
		/// </summary>
        public WebForms.StatusBar WebStatusBar
		{
			get
			{
                return base.SourceObject as WebForms.StatusBar;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.StatusBar WinStatusBar
		{
			get
			{
                return base.TargetObject as WinForms.StatusBar;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion StatusPanelCollectionController Class
	
}
