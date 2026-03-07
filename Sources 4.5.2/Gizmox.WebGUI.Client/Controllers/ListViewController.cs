#region Using

using System;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ListViewController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
	
	public class ListViewController : ControlController
	{
		#region Class Members
		
		private ListViewColumnHeaderCollectionController mobjColumnHeaderCollectionController = null;
		
		private ListViewItemCollectionController mobjItemCollectionController = null;

        private ListViewGroupCollectionController mobjGroupCollectionController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ListViewController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(Context,this.WebListView,this.WebListView.Columns,this.WinListView,this.WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(Context,this.WebListView,this.WebListView.Items,this.WinListView,this.WinListView.Items);
            mobjGroupCollectionController = new ListViewGroupCollectionController(Context, this.WebListView, this.WebListView.Groups, this.WinListView, this.WinListView.Groups);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ListViewController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(Context,this.WebListView,this.WebListView.Columns,this.WinListView,this.WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(Context,this.WebListView,this.WebListView.Items,this.WinListView,this.WinListView.Items);
            mobjGroupCollectionController = new ListViewGroupCollectionController(Context, this.WebListView, this.WebListView.Groups, this.WinListView, this.WinListView.Groups);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			mobjColumnHeaderCollectionController.Initialize();
            mobjGroupCollectionController.Initialize();
			mobjItemCollectionController.Initialize();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
            //we need to set the view before initializing the ColumnHeaders
            //otherwise the ColumnHeader width wont be drawn correctly
            //so i moved this line before the base.InitializeController();
            SetWinListViewView();

            base.InitializeController();
			
			SetWinListViewCheckBoxes();
            SetWinListViewScrollable();            
            SetWinGroups();
            SetWinShowGroups();
            SetWinGridLines();
            SetWinItems();
		}

        protected virtual void SetWinShowGroups()
		{
			this.WinListView.ShowGroups = this.WebListView.ShowGroups;
		}
        
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListViewView()
		{
            object objView = GetConvertedEnum(typeof(WinForms.View), this.WebListView.View);
            if (objView != null)
            {
                this.WinListView.View = (WinForms.View)objView;
            }
		}
		
        protected override void SetWinControlBorderStyle()
        {
            this.WinListView.BorderStyle = (WinForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle),this.WebListView.BorderStyle,this.WinListView.BorderStyle);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWebListViewScrollable()
        {
            this.WebListView.Scrollable = this.WinListView.Scrollable;
        }

		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListViewCheckBoxes()
		{
			this.WinListView.CheckBoxes = this.WebListView.CheckBoxes;
		}

        protected virtual void SetWebListViewColumnHeaderWidth(WebForms.ColumnHeader objWebColumnHeader, WinForms.ColumnHeader objWinColumnHeader)
        {
            try
            {
                this.SuspendNotifications();
                objWebColumnHeader.Width = Convert.ToInt32(objWinColumnHeader.Width / TargetHorizontalScaleFactor);
            }
            finally
            {
                this.ResumeNotifications();
            }
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
				    SetWinListViewCheckBoxes();
				    break;
                case "Columns":                    
                    InitializedContained();                    
                    break;
                case "Scrollable":
                    SetWinListViewScrollable();
                    break;
                case "View":
                    SetWinListViewView();
                    break;
                case "Items":
                    SetWinItems();
                    break;
                case "ShowGroups":
                    SetWinShowGroups();
                    break;
                case "GridLines":
                    SetWinGridLines();
                    break;
                case "Groups":
                    SetWinGroups();
                    break;

			}
		}

        /// <summary>
        /// Sets the win grid lines.
        /// </summary>
        private void SetWinGridLines()
        {
            this.WinListView.GridLines = this.WebListView.GridLines;
        }

        private void SetWinGroups()
        {
            this.mobjGroupCollectionController.SetWinObjectObjects();
        }

        private void SetWebGroups()
        {
            this.mobjGroupCollectionController.SetWebObjectObjects();
        }

        private void SetWinItems()
        {
            this.mobjItemCollectionController.SetWinObjectObjects();
        }

        private void SetWebItems()
        {
            this.mobjItemCollectionController.SetWebObjectObjects();
        }

        private void SetWinListViewScrollable()
        {
            this.WinListView.Scrollable = this.WebListView.Scrollable;
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Scrollable":
                    SetWebListViewScrollable();
                    break;
                case "View":
                    SetWebListViewView();
                    break;
                case "Items":
                    SetWebItems();
                    break;
            }
        }

        private void SetWebListViewView()
        {
            this.WebListView.View = (WebForms.View)GetConvertedEnum(typeof(WebForms.View), this.WinListView.View);
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			this.WinListView.SelectedIndexChanged+=new EventHandler(WinListView_SelectedIndexChanged);
			this.WinListView.DoubleClick+=new EventHandler(WinListView_DoubleClick);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder objValue = new StringBuilder();
			foreach(int intIndex in this.WinListView.SelectedIndices)
			{
				if(objValue.Length>0) objValue.Append(",");
				objValue.Append(intIndex.ToString());
			}

            Event objEvent = CreateWebEvent("SelectionChange");
			objEvent.SetParameter("Indexes",objValue.ToString());
            objEvent.SetParameter("Incremental", "0");
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinListView_DoubleClick(object sender, EventArgs e)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinListView.SelectedIndexChanged-=new EventHandler(WinListView_SelectedIndexChanged);
			this.WinListView.DoubleClick-=new EventHandler(WinListView_DoubleClick);
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientListView();
		}

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjColumnHeaderCollectionController != null)
            {
                mobjColumnHeaderCollectionController.Terminate();
            }

            if (this.mobjItemCollectionController != null)
            {
                mobjItemCollectionController.Terminate();
            }

            if (this.mobjGroupCollectionController!= null)
            {
                mobjGroupCollectionController.Terminate();
            }
        }

        /// <summary>
        /// Wires required events for controller to work in design time
        /// </summary>
        protected override void WireDesignTimeEvents()
        {
            base.WireDesignTimeEvents();

            this.WinListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(WinListView_ColumnWidthChanged);
        }

        /// <summary>
        /// Handles the ColumnWidthChanged event of the WinListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ColumnWidthChangedEventArgs"/> instance containing the event data.</param>
        private void WinListView_ColumnWidthChanged(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e)
        {
            if (!this.IsNotificationSuspened)
            {
                //get win ColumnHeader 
                WinForms.ColumnHeader objWinColumnHeader = WinListView.Columns[e.ColumnIndex];

                if (objWinColumnHeader != null)
                {
                    //get ColumnHeader controller
                    ObjectController objController = GetControllerByWinObject(objWinColumnHeader);
                    if (objController != null)
                    {
                        //get web ColumnHeader 
                        WebForms.ColumnHeader objWebColumnHeader = (WebForms.ColumnHeader)objController.SourceObject;

                        //compare Width
                        if (objWebColumnHeader != null)
                        {
                            if (objWinColumnHeader.Width != objWebColumnHeader.Width)
                            {
                                //Fire Width Changed
                                objController.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("Width"));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Unwires wired design time events
        /// </summary>
        protected override void UnwireDesignTimeEvents()
        {
            base.UnwireDesignTimeEvents();

            this.WinListView.ColumnWidthChanged -= new System.Windows.Forms.ColumnWidthChangedEventHandler(WinListView_ColumnWidthChanged);
        }

		#endregion Methods
		
		#region Properties
		
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
		public WinForms.ListView WinListView
		{
			get
			{
				return base.TargetObject as WinForms.ListView;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ListViewController Class
	
}
