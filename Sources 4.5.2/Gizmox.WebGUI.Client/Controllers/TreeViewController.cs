#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TreeViewController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TreeViewController : ControlController
	{
		#region Class Members
		
		/// <summary>
		///
		/// </summary>
		private TreeNodeCollectionController mobjTreeNodesController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public TreeViewController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(Context,objWebTreeView,this.WebTreeView.Nodes,this.WinTreeView,this.WinTreeView.Nodes);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		public TreeViewController(IContext objContext,object objWebTreeView) :base(objContext,objWebTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(Context,objWebTreeView,this.WebTreeView.Nodes,this.WinTreeView,this.WinTreeView.Nodes);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

			SetWinTreeViewCheckBoxes();
			SetWinTreeViewShowLines();
            SetWinNodes();
            SetWinTreeViewImageIndex();
            SetWinTreeViewImageKey();
            SetWinTreeViewItemHeight();
		}
		
		#region Set Property
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTreeViewCheckBoxes()
		{
			this.WinTreeView.CheckBoxes = this.WebTreeView.CheckBoxes;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTreeViewShowLines()
		{
			this.WinTreeView.ShowLines = this.WebTreeView.ShowLines;
		}

        protected override void SetWinControlBorderStyle()
        {
            this.WinTreeView.BorderStyle = (WinForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle), this.WebTreeView.BorderStyle, this.WinTreeView.BorderStyle);
        }
		
		
		#endregion Set Property
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			this.WinTreeView.BeginUpdate();
			this.WinTreeView.SuspendLayout();
			this.mobjTreeNodesController.Initialize();
			
			WinForms.TreeNode objWinTreeNode = GetWinObject(this.WebTreeView.SelectedNode) as WinForms.TreeNode;
			if(objWinTreeNode!=null)
			{
				this.WinTreeView.SelectedNode = objWinTreeNode;
			}
			this.WinTreeView.EndUpdate();
			this.WinTreeView.ResumeLayout();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange (objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "CheckBoxes":
				    SetWinTreeViewCheckBoxes();
				    break;
				case "ShowLines":
				    SetWinTreeViewShowLines();
				    break;
                case "Nodes":
                    SetWinNodes();
                    break;
                case "ImageIndex":
                    SetWinTreeViewImageIndex();
                    break;
                case "ImageKey":
                    SetWinTreeViewImageKey();
                    break;
                case "ItemHeight":
                    SetWinTreeViewItemHeight();
                    break;
			}
		}

        /// <summary>
        /// Sets the win TreeView item height.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void SetWinTreeViewItemHeight()
        {
            if (this.WebTreeView.HasItemHeight)
            {
                this.WinTreeView.ItemHeight = this.WebTreeView.ItemHeight;
            }
            else
            {
                typeof(WinForms.TreeView).GetMethod("ResetItemHeight", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod).Invoke(this.WinTreeView, null);
            }
        }

        /// <summary>
        /// Sets the index of the win tree view image.
        /// </summary>
        private void SetWinTreeViewImageIndex()
        {
            this.WinTreeView.ImageIndex = this.WebTreeView.ImageIndex;
        }

        /// <summary>
        /// Sets the win tree view image key.
        /// </summary>
        private void SetWinTreeViewImageKey()
        {
            this.WinTreeView.ImageKey = this.WebTreeView.ImageKey;
        }


        /// <summary>
        /// Sets the win nodes.
        /// </summary>
        private void SetWinNodes()
        {
            this.mobjTreeNodesController.SetWinObjectObjects();
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientTreeView();
		}

        public override void Clear()
        {
            base.Clear();

            if (this.mobjTreeNodesController != null)
            {
                // Clear control controllers
                mobjTreeNodesController.Clear();
            }
        }

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjTreeNodesController != null)
            {
                // Clear control controllers
                mobjTreeNodesController.Terminate();
            }
        }
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			this.WinTreeView.BeforeSelect+=new System.Windows.Forms.TreeViewCancelEventHandler(WinTreeView_BeforeSelect);
			this.WinTreeView.AfterSelect+=new System.Windows.Forms.TreeViewEventHandler(WebTreeView_AfterSelect);
			this.WinTreeView.BeforeExpand+=new System.Windows.Forms.TreeViewCancelEventHandler(WebTreeView_BeforeExpand);
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WebTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNodeController objControler = GetControllerByWinObject(e.Node) as TreeNodeController;
			if(objControler!=null)
			{
				Event objEvent = CreateWebEvent("Expand",objControler.SourceObject);
				objEvent.Fire();
				if(objControler.WinTreeNode.HasDummyNodes)
				{
					objControler.Initialize();
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinTreeView.BeforeSelect-=new System.Windows.Forms.TreeViewCancelEventHandler(WinTreeView_BeforeSelect);
			this.WinTreeView.AfterSelect-=new System.Windows.Forms.TreeViewEventHandler(WebTreeView_AfterSelect);
			this.WinTreeView.BeforeExpand-=new System.Windows.Forms.TreeViewCancelEventHandler(WebTreeView_BeforeExpand);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinTreeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			ObjectController objControler = GetControllerByWinObject(e.Node);
			if(objControler!=null)
			{
				Event objEvent = CreateWebEvent("Action",objControler.SourceObject);
                objEvent.SetParameter("Action", "Click");
				objEvent.Fire();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WebTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            ObjectController objControler = GetControllerByWinObject(e.Node);
            if (objControler != null)
            {
                Event objEvent = CreateWebEvent("Action", objControler.SourceObject);
                objEvent.SetParameter("Action", "Click");
                objEvent.Fire();
            }
            // Is not required
            //ObjectController objControler = GetControllerByWinObject(e.Node);
            //if(objControler!=null)
            //{
            //    Event objEvent = CreateWebEvent("AfterSelect",objControler.SourceObject);
            //    objEvent.Fire();
            //}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
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
		public WinForms.TreeView WinTreeView
		{
			get
			{
				return base.TargetObject as WinForms.TreeView;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion TreeViewController Class
	
}
