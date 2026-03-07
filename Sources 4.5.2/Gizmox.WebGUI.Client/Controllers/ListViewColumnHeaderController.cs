#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ListViewColumnHeaderController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ListViewColumnHeaderController : ComponentController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeNode"></param>
		/// <param name="objWinTreeNode"></param>
        public ListViewColumnHeaderController(IContext objContext, object objWebListView, object objWinListView) : base(objContext, objWebListView, objWinListView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ListViewColumnHeaderController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnHeaderText();
			SetWinColumnHeaderWidth();
            SetWinColumnHeaderImageKey();
            SetWinColumnHeaderImageIndex();
		}

        /// Sets the index of the win column header image.
        /// </summary>
        private void SetWinColumnHeaderImageIndex()
        {
            EnsureWinListViewImageList();

            this.WinColumnHeader.ImageIndex = this.GetWinImageIndex(this.WinColumnHeader.ImageList, this.WebColumnHeader.Image);
        }

        /// <summary>
        /// Ensures the win list view image list.
        /// </summary>
        private void EnsureWinListViewImageList()
        {
            if (this.WebColumnHeader.Image != null)
            {
                if (this.WinColumnHeader.ListView != null && this.WinColumnHeader.ListView.SmallImageList == null)
                {
                    this.WinColumnHeader.ListView.SmallImageList = new WinForms.ImageList();
                }
            }
        }

        /// <summary>
        /// Sets the win column header image key.
        /// </summary>
        private void SetWinColumnHeaderImageKey()
        {
            EnsureWinListViewImageList();

            if (this.GetWinImageIndex(this.WinColumnHeader.ImageList, this.WebColumnHeader.Image, this.WebColumnHeader.ImageKey) > -1)
            {
                this.WinColumnHeader.ImageKey = this.WebColumnHeader.ImageKey;
            }
            else
            {
                this.WinColumnHeader.ImageKey = string.Empty;
            }
        }

        /// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			
			switch (objPropertyChangeArgs.Property)
			{
				case "Text":
				    SetWinColumnHeaderText();
				    break;
				case "Width":
				    SetWinColumnHeaderWidth();
				    break;
                case "ImageKey":
                    SetWinColumnHeaderImageKey();
                    break;
                case "ImageIndex":
                    SetWinColumnHeaderImageIndex();
                    break;
			}
		}

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.FireWinPropertyChanged(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Width":
                    SetWebColumnHeaderWidth();
                    break;
            }
        }
		
		#region Set Property
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinColumnHeaderText()
		{
			this.WinColumnHeader.Text = this.WebColumnHeader.Text;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinColumnHeaderWidth()
		{
            this.WinColumnHeader.Width = Convert.ToInt32(this.WebColumnHeader.Width * this.TargetHorizontalScaleFactor);
		}

        /// <summary>
        /// Sets the width of the web column header.
        /// </summary>
        protected virtual void SetWebColumnHeaderWidth()
        {
            this.SetWebProperty("Width", Convert.ToInt32(this.WinColumnHeader.Width / this.TargetHorizontalScaleFactor));
        }
		
		
		#endregion Set Property
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ColumnHeader WebColumnHeader
		{
			get
			{
				return base.SourceObject as WebForms.ColumnHeader;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ColumnHeader WinColumnHeader
		{
			get
			{
				return base.TargetObject as WinForms.ColumnHeader;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ListViewColumnHeaderController Class
	
}
