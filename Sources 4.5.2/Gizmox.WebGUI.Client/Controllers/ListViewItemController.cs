#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ListViewItemController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ListViewItemController : ComponentController
	{
		#region Class Members
		
		private ContextMenuController mobjContextMenuController = null;
        private ListViewSubItemCollectionController mobjListViewSubItemCollectionController = null;        
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeNode"></param>
		/// <param name="objWinTreeNode"></param>
		public ListViewItemController(IContext objContext,object objWebListViewItem,object objWinListViewItem) :base(objContext,objWebListViewItem,objWinListViewItem)
		{
            mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, this.WebListViewItem, this.WebListViewItem.SubItems, this.WinListViewItem, this.WinListViewItem.SubItems);            
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ListViewItemController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
            mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, this.WebListViewItem, this.WebListViewItem.SubItems, this.WinListViewItem, this.WinListViewItem.SubItems);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
            SetWinListViewItemText();
            SetWinListViewItemForeColor();
            SetWinListViewItemBackColor();
            SetWinListViewItemSubItems();
            SetWinListViewItemContextMenu();
            SetWinListViewItemGroup();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadController()
		{
			base.LoadController ();
			SetWinListViewItemText();
            SetWinListViewItemForeColor();
            SetWinListViewItemBackColor();
            SetWinListViewItemImageIndex();
            SetWinListViewItemImageKey();
			SetWinListViewItemContextMenu();
            SetWinListViewItemGroup();
		}

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            this.SetWinListViewItemText();
            SetWinListViewItemForeColor();
            SetWinListViewItemBackColor();

        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    this.SetWinListViewItemText();
                    break;
                case "SubItems":
                    this.SetWinListViewItemSubItems();
                    break;
                case "ImageKey":
                    this.SetWinListViewItemImageKey();
                    break;
                case "ImageIndex":
                    this.SetWinListViewItemImageIndex();
                    break;
                case "Group":
                    this.SetWinListViewItemGroup();
                    break;
                case "BackColor":
                    this.SetWinListViewItemBackColor();
                    break;
                case "ForeColor":
                    this.SetWinListViewItemForeColor();
                    break;
            }
        }

        /// <summary>
        /// Sets the index of the win list view item image.
        /// </summary>
        private void SetWinListViewItemImageIndex()
        {
            if (this.WebListViewItem.ImageIndex != -1)
            {
                if (this.WinListViewItem.ListView != null)
                {
                    if (this.WinListViewItem.ListView.SmallImageList == null)
                    {
                        this.WinListViewItem.ListView.SmallImageList = new WinForms.ImageList();
                    }

                    this.WinListViewItem.ImageIndex = GetWinImageIndex(this.WinListViewItem.ListView.SmallImageList, this.WebListViewItem.SmallImage);
                }
            }
            else
            {
                if (this.WinListViewItem.ImageIndex != -1)
                {
                    this.WinListViewItem.ImageIndex = -1;
                }
            }
        }

        /// <summary>
        /// Sets the win list view item image key.
        /// </summary>
        private void SetWinListViewItemImageKey()
        {
            if (this.WebListViewItem.ImageKey != string.Empty)
            {
                if (this.WinListViewItem.ListView != null)
                {
                    if (this.WinListViewItem.ListView.SmallImageList == null)
                    {
                        this.WinListViewItem.ListView.SmallImageList = new WinForms.ImageList();
                    }

                    if (this.GetWinImageIndex(this.WinListViewItem.ListView.SmallImageList, this.WebListViewItem.SmallImage, this.WebListViewItem.ImageKey)>-1)
                    {
                        this.WinListViewItem.ImageKey = this.WebListViewItem.ImageKey;
                    }
                    else
                    {
                        if (this.WinListViewItem.ImageKey != string.Empty)
                        {
                            this.WinListViewItem.ImageKey = string.Empty;
                        }
                    }
                }
            }
            else
            {
                if (this.WinListViewItem.ImageKey != string.Empty)
                {
                    this.WinListViewItem.ImageKey = string.Empty;
                }
            }

        }

        /// <summary>
        /// Sets the index of the web list view item image.
        /// </summary>
        private void SetWebListViewItemImageIndex()
        {
            this.WebListViewItem.ImageIndex = this.WinListViewItem.ImageIndex;
        }

        /// <summary>
        /// Sets the web list view item image key.
        /// </summary>
        private void SetWebListViewItemImageKey()
        {
            this.WebListViewItem.ImageKey = this.WinListViewItem.ImageKey;
        }

        private void SetWinListViewItemSubItems()
        {
            mobjListViewSubItemCollectionController.SetWinObjectObjects();
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    this.SetWebListViewItemText();
                    break;
                case "SubItems":
                    this.SetWebListViewItemSubItems();
                    break;
                case "ImageKey":
                    this.SetWebListViewItemImageKey();
                    break;
                case "ImageIndex":
                    this.SetWebListViewItemImageIndex();
                    break;
            }
        }

        private void SetWebListViewItemSubItems()
        {
            mobjListViewSubItemCollectionController.SetWebObjectObjects();
        }

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetWebListViewItemText();
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
            mobjListViewSubItemCollectionController.Initialize();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListViewItemContextMenu()
		{
			if(this.ContextMenuController!=null)
			{
				this.WinListViewItem.ContextMenu = this.ContextMenuController.WinContextMenu;
			}
		}

        protected virtual void SetWinListViewItemGroup()
        {
            if (this.WebListViewItem.Group != null)
            {
                ObjectController objController = this.GetControllerByWebObject(this.WebListViewItem.Group);
                if (objController != null)
                {
                    this.WinListViewItem.Group = objController.TargetObject as WinForms.ListViewGroup;
                }
            }
            else
            {
                this.WinListViewItem.Group = null;
            }
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientListViewItem();
		}
		
		#region Set Property

        /// <summary>
        /// Sets the win list view item text.
        /// </summary>
		protected virtual void SetWinListViewItemText()
		{
			this.WinListViewItem.Text = this.WebListViewItem.Text;
            
		}

        /// <summary>
        /// Sets the color of the win list view item back.
        /// </summary>
        protected virtual void SetWinListViewItemBackColor()
        {
            this.WinListViewItem.BackColor = this.WebListViewItem.BackColor;
        }

        /// <summary>
        /// Sets the color of the win list view item fore.
        /// </summary>
        protected virtual void SetWinListViewItemForeColor()
        {
            this.WinListViewItem.ForeColor = this.WebListViewItem.ForeColor;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebListViewItemText()
        {
            this.WebListViewItem.Text = this.WinListViewItem.Text;
        }
		
		
		#endregion Set Property
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ListViewItem WebListViewItem
		{
			get
			{
				return base.SourceObject as WebForms.ListViewItem;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public Forms.ClientListViewItem WinListViewItem
		{
			get
			{
				return base.TargetObject as Forms.ClientListViewItem;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		new protected ContextMenuController ContextMenuController
		{
			get
			{
				if(this.mobjContextMenuController==null)
				{
					if(this.WebComponent!=null && this.WebComponent.ContextMenu!=null)
					{
						this.mobjContextMenuController = GetControllerByWebObject(this.WebComponent.ContextMenu) as ContextMenuController;
						if(this.mobjContextMenuController==null)
						{
							WinForms.ContextMenu objWinContextMenu = new WinForms.ContextMenu();
							this.mobjContextMenuController = new ContextMenuController(Context,this.WebComponent.ContextMenu,objWinContextMenu);
							this.mobjContextMenuController.Initialize();
							this.RegisterController(this.mobjContextMenuController);
						}
					}
				}

				return this.mobjContextMenuController;				
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ListViewItemController Class
	
}
