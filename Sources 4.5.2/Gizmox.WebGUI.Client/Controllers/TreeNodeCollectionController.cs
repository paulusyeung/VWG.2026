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
	#region TreeNodeCollectionController Class
	
	/// <summary>
	/// TreeNodes the relations between a webgui component and a winforms component
	/// </summary>
    
	public class TreeNodeCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
        public TreeNodeCollectionController(IContext objContext, object objWebObject, IList objWebTreeNodes, object objWinObject, IList objWinTreeNodes) : base(objContext, objWebObject, objWebTreeNodes, objWinObject, objWinTreeNodes)
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
			return new TreeNodeController(Context,objWebObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Gizmox.WebGUI.Client.Forms.ClientTreeNode();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.TreeNodeCollection WebTreeNodes
		{
			get
			{
				return base.WebObjects as WebForms.TreeNodeCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.TreeNode WebTreeNode
		{
			get
			{
				return base.SourceObject as WebForms.TreeNode;
			}
		}

        /// <summary>
        ///
        /// </summary>
        public WebForms.TreeView WebTreeView
        {
            get
            {
                return base.SourceObject as WebForms.TreeView;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		public WinForms.TreeNodeCollection WinTreeNodes
		{
			get
			{
				return base.WinObjects as WinForms.TreeNodeCollection;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public Gizmox.WebGUI.Client.Forms.ClientTreeNode WinTreeNode
		{
			get
			{
				return base.TargetObject as Gizmox.WebGUI.Client.Forms.ClientTreeNode;
			}
		}

        /// <summary>
        ///
        /// </summary>
        public Gizmox.WebGUI.Client.Forms.ClientTreeView WinTreeView 
        {
            get
            {
                return base.TargetObject as Gizmox.WebGUI.Client.Forms.ClientTreeView;
            }
        }
		
		
		#endregion Properties
		
	}
	
	#endregion TreeNodeCollectionController Class
	
}
