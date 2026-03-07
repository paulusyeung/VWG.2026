#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ListViewSubItemController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ListViewSubItemController : ComponentController
	{
		#region Class Members
		
		private ContextMenuController mobjContextMenuController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeNode"></param>
		/// <param name="objWinTreeNode"></param>
        public ListViewSubItemController(IContext objContext, object objWebListViewSubItem, object objWinListViewSubItem) : base(objContext, objWebListViewSubItem, objWinListViewSubItem)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ListViewSubItemController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadController()
		{
			base.LoadController ();
			SetWinListViewSubItemText();
            SetWinListViewSubItemForeColor();
            SetWinListViewSubItemBackColor();
		}

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            this.SetWinListViewSubItemText();
            this.SetWinListViewSubItemForeColor();
            this.SetWinListViewSubItemBackColor();

        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    this.SetWinListViewSubItemText();
                    break;
                case "BackColor":
                    this.SetWinListViewSubItemBackColor();
                    break;
                case "ForeColor":
                    this.SetWinListViewSubItemForeColor();
                    break;
            }
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    this.SetWebListViewSubItemText();
                    break;
            }
        }

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetWebListViewSubItemText();
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
		
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
            return new WinForms.ListViewItem.ListViewSubItem();
		}
		
		#region Set Property
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListViewSubItemText()
		{
            this.WinListViewSubItem.Text = this.WebListViewSubItem.Text;
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebListViewSubItemText()
        {
            this.WebListViewSubItem.Text = this.WinListViewSubItem.Text;
        }

        /// <summary>
        /// Sets the color of the win list view sub item back.
        /// </summary>
        protected virtual void SetWinListViewSubItemBackColor()
        {
            this.WinListViewSubItem.BackColor = this.WebListViewSubItem.BackColor;
        }

        /// <summary>
        /// Sets the color of the win list view sub item fore.
        /// </summary>
        protected virtual void SetWinListViewSubItemForeColor()
        {
            this.WinListViewSubItem.ForeColor = this.WebListViewSubItem.ForeColor;
        }

		#endregion Set Property
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.ListViewItem.ListViewSubItem WebListViewSubItem
		{
			get
			{
				return base.SourceObject as WebForms.ListViewItem.ListViewSubItem;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.ListViewItem.ListViewSubItem WinListViewSubItem
		{
			get
			{
                return base.TargetObject as WinForms.ListViewItem.ListViewSubItem;
			}
		}
		
		#endregion Properties
		
	}
	
	#endregion ListViewSubItemController Class
	
}
