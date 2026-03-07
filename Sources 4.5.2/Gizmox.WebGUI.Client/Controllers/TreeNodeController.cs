#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TreeNodeController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TreeNodeController : ComponentController
	{
		#region Class Members
		
		/// <summary>
		///
		/// </summary>
		private TreeNodeCollectionController mobjTreeNodesController = null;
		
		private ContextMenuController mobjContextMenuController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeNode"></param>
		/// <param name="objWinTreeNode"></param>
		public TreeNodeController(IContext objContext,object objWebTreeNode,object objWinTreeNode) :base(objContext,objWebTreeNode,objWinTreeNode)
		{
			this.mobjTreeNodesController = new TreeNodeCollectionController(Context,this.WebTreeNode,this.WebTreeNode.Nodes,this.WinTreeNode,this.WinTreeNode.Nodes);
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeNode"></param>
		public TreeNodeController(IContext objContext,object objWebTreeNode) :base(objContext,objWebTreeNode)
		{
			this.mobjTreeNodesController = new TreeNodeCollectionController(Context,this.WebTreeNode,this.WebTreeNode.Nodes,this.WinTreeNode,this.WinTreeNode.Nodes);
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ImageIndex":
                    SetWinTreeNodeImageIndex();
                    break;
                case "ImageKey":
                    SetWinTreeNodeImageKey();                
                    break;
                case "Text":
                    SetWinTreeNodeText();
                    break;
            }
        }

        /// <summary>
        /// Sets the win tree node image key.
        /// </summary>
        private void SetWinTreeNodeImageKey()
        {
            if (this.WebTreeNode.ImageKey != string.Empty)
            {
                if (this.WinTreeNode.TreeView != null)
                {
                    if (this.WinTreeNode.TreeView.ImageList == null)
                    {
                        this.WinTreeNode.TreeView.ImageList = new WinForms.ImageList();
                    }

                    if (this.GetWinImageIndex(this.WinTreeNode.TreeView.ImageList, this.WebTreeNode.Image, this.WebTreeNode.ImageKey)>-1)
                    {
                        this.WinTreeNode.ImageKey = this.WebTreeNode.ImageKey;
                    }
                }
            }
            else
            {
                this.WinTreeNode.ImageKey = string.Empty;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

			SetWinTreeNodeText();
			SetWinTreeNodeHasNodes();
			SetWinTreeNodeContextMenu();
            SetWinTreeNodeImageIndex();
            SetWinTreeNodeImageKey();
		}
		
		/// <summary>
		///
		/// </summary>
        protected override void InitializedContained()
        {
            this.mobjTreeNodesController.Initialize();
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientTreeNode();
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

		#region Set Property
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTreeNodeContextMenu()
		{
			if(this.ContextMenuController!=null)
			{
				this.WinTreeNode.ContextMenu = this.ContextMenuController.WinContextMenu;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTreeNodeText()
		{
			this.WinTreeNode.Text = this.WebTreeNode.Text;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTreeNodeHasNodes()
		{
			this.WinTreeNode.HasNodes = this.WebTreeNode.HasNodes;
		}

        /// <summary>
        /// Sets the index of the win tree node image.
        /// </summary>
		protected virtual void SetWinTreeNodeImageIndex()
		{
            if (this.WebTreeNode.ImageIndex != -1)
            {
                if (this.WinTreeNode.TreeView != null)
                {
                    if (this.WinTreeNode.TreeView.ImageList == null)
                    {
                        this.WinTreeNode.TreeView.ImageList = new WinForms.ImageList();
                    }

                    this.WinTreeNode.ImageIndex = this.GetWinImageIndex(this.WinTreeNode.TreeView.ImageList, this.WebTreeNode.Image);
                }
            }
            else
            {
                if (this.WinTreeNode.ImageIndex != -1)
                {
                    this.WinTreeNode.ImageIndex = -1;
                }
            }
		}
		
		#endregion Set Property
		
		#endregion Methods
		
		#region Properties
		
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
		public WebForms.Component WebComponent
		{
			get
			{
				return base.SourceObject as WebForms.Component;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected ContextMenuController ContextMenuController
		{
			get
			{
				if(this.mobjContextMenuController==null)
				{
					if(this.WebComponent!=null && this.WebComponent.ContextMenu!=null)
					{
						WinForms.ContextMenu objWinContextMenu = new WinForms.ContextMenu();
						this.mobjContextMenuController = new ContextMenuController(Context,this.WebComponent.ContextMenu,objWinContextMenu);
						this.mobjContextMenuController.Initialize();
					}
				}
				
				return this.mobjContextMenuController;
				
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion TreeNodeController Class
	
}
