#region Using

using System;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TableLayoutPanelController Class

	///  <summary>
	/// Represents a panel that dynamically lays out its contents in a grid composed of rows and columns.
	///  </summary>
	
	public class TableLayoutPanelController : ControlController
	{
		#region Class Memebers

		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;
		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;
        private TableLayoutSettingsController mobjTableLayoutSettingsController = null;

		#endregion Class Memebers

		#region C'Tors

		public TableLayoutPanelController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext,this.SourceTableLayoutPanel,this.SourceTableLayoutPanel.RowStyles,this.TargetTableLayoutPanel,this.TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext,this.SourceTableLayoutPanel,this.SourceTableLayoutPanel.ColumnStyles,this.TargetTableLayoutPanel,this.TargetTableLayoutPanel.ColumnStyles);
            mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, this.SourceTableLayoutPanel.LayoutSettings, this.TargetTableLayoutPanel.LayoutSettings);
		}

		public TableLayoutPanelController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext,this.SourceTableLayoutPanel,this.SourceTableLayoutPanel.RowStyles,this.TargetTableLayoutPanel,this.TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext,this.SourceTableLayoutPanel,this.SourceTableLayoutPanel.ColumnStyles,this.TargetTableLayoutPanel,this.TargetTableLayoutPanel.ColumnStyles);
            mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, this.SourceTableLayoutPanel.LayoutSettings, this.TargetTableLayoutPanel.LayoutSettings);
		}

		#endregion C'Tors

		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
        protected override void InitializedContained()
        {
            try
            {
                // Suspend notifications.
                this.SuspendNotifications();

                base.InitializedContained();

                // Initialize contained objects.
                this.mobjColumnStylesController.Initialize();
                this.mobjRowStylesController.Initialize();
                this.mobjTableLayoutSettingsController.Initialize();

            }
            finally
            {
                // Resume notifications.
                this.ResumeNotifications();
            }
        }

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            return new ControllerTarget.TableLayoutPanel();
		}

		/// <summary>
		/// Initializes this controller.
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

            try
            {
                // Suspend layouting of the target table layout panel.
                this.TargetTableLayoutPanel.SuspendLayout();

                // Intialize target object.
                this.SetTargetTableLayoutPanelBorderStyle();
                this.SetTargetTableLayoutPanelGrowStyle();
                this.SetTargetTableLayoutPanelControlsPositions();
                this.SetTargetTableLayoutPanelColumnStyles();
                this.SetTargetTableLayoutPanelRowStyles();
                this.SetTargetTableLayoutPanelColumnCount();
                this.SetTargetTableLayoutPanelRowCount();
                this.SetTargetTableLayoutPanelCellBorderStyle();
            }
            finally
            {
                // Resume layouting of the target table layout panel.
                this.TargetTableLayoutPanel.ResumeLayout(false);
            }
		}

		/// <summary>
		/// Terminates this controller.
		/// </summary>
		public override void Terminate()
		{
			base.Terminate();

            if (mobjColumnStylesController != null)
            {
                mobjColumnStylesController.Terminate();
            }
            if (mobjRowStylesController != null)
            {
                mobjRowStylesController.Terminate();
            }
            if (mobjTableLayoutSettingsController != null)
            {
                mobjTableLayoutSettingsController.Terminate();
            }
		}

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "BorderStyle":
                    SetSourceTableLayoutPanelBorderStyle();
                    break;
                case "CellBorderStyle":
                    SetSourceTableLayoutPanelCellBorderStyle();
                    break;
                case "ColumnCount":
                    SetSourceTableLayoutPanelColumnCount();
                    break;
                case "GrowStyle":
                    SetSourceTableLayoutPanelGrowStyle();
                    break;
                case "RowCount":
                    SetSourceTableLayoutPanelRowCount();
                    break;
                case "ControlPositions":
                    SetSourceTableLayoutPanelControlPositions((ControllerTarget.Control)objPropertyChangeArgs.Subject);
                    break;
                case "RowStyles":
                case "ColumnStyles":
                    SetSourceTableLayoutPanelRowStyles();
                    SetSourceTableLayoutPanelColumnStyles();
                    break;
                case "Controls":
                    try
                    {
                        this.SuspendNotifications();
                        base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
                    }
                    finally
                    {
                        // Resume notifications.
                        this.ResumeNotifications();
                    }
                    break;
                default:
                    base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "BorderStyle":
                    SetTargetTableLayoutPanelBorderStyle();
                    break;
                case "CellBorderStyle":
                    SetTargetTableLayoutPanelCellBorderStyle();
                    break;
                case "ColumnCount":
                    SetTargetTableLayoutPanelColumnCount();
                    break;
                case "GrowStyle":
                    SetTargetTableLayoutPanelGrowStyle();
                    break;
                case "RowCount":
                    SetTargetTableLayoutPanelRowCount();
                    break;
                case "RowStyles":
                    SetTargetTableLayoutPanelRowStyles();
                    break;
                case "ColumnStyles":
                    SetTargetTableLayoutPanelColumnStyles();
                    break;
                case "Controls":
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    SetTargetTableLayoutPanelControlsPositions();
                    break;
                default:
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }


        /// <summary>
        /// Wires required events for controller to work in design time
        /// </summary>
        protected override void WireDesignTimeEvents()
        {
            base.WireDesignTimeEvents();

            ((System.Windows.Forms.TableLayoutPanel)this.WinComponent).ControlAdded += new System.Windows.Forms.ControlEventHandler(TableLayoutPanelController_ControlAdded);
            ((System.Windows.Forms.TableLayoutPanel)this.WinComponent).ControlRemoved += new System.Windows.Forms.ControlEventHandler(TableLayoutPanelController_ControlRemoved);
        }

        /// <summary>
        /// Unwires wired design time events
        /// </summary>
        protected override void UnwireDesignTimeEvents()
        {
            base.UnwireDesignTimeEvents();

            ((System.Windows.Forms.TableLayoutPanel)this.WinComponent).ControlAdded -= new System.Windows.Forms.ControlEventHandler(TableLayoutPanelController_ControlAdded);
            ((System.Windows.Forms.TableLayoutPanel)this.WinComponent).ControlRemoved -= new System.Windows.Forms.ControlEventHandler(TableLayoutPanelController_ControlRemoved);
        }

        /// <summary>
        /// Handles the ControlRemoved event of the TableLayoutPanelController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ControlEventArgs"/> instance containing the event data.</param>
        private void TableLayoutPanelController_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            WinForms.Control objControl = e.Control;
            if (objControl != null)
            {
                objControl.LocationChanged -= new EventHandler(objControl_LocationChanged);
            }
            
        }

        /// <summary>
        /// Handles the ControlAdded event of the TableLayoutPanelController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ControlEventArgs"/> instance containing the event data.</param>
        private void TableLayoutPanelController_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            WinForms.Control objControl = e.Control;
            if (objControl != null)
            {
                objControl.LocationChanged += new EventHandler(objControl_LocationChanged);
            }
        }

        /// <summary>
        /// Handles the LocationChanged event of the objControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void objControl_LocationChanged(object sender, EventArgs e)
        {
            WinForms.Control objControl = sender  as WinForms.Control;
            if (objControl != null)
            {
                SetSourceTableLayoutPanelControlPositions(objControl);
            }
        }       

        #region Target Methods

        /// <summary>
        /// Sets the target table layout panel controls positions.
        /// </summary>
        protected virtual void SetTargetTableLayoutPanelControlsPositions()
        {
            try
            {
                this.SuspendNotifications();

                if (this.SourceTableLayoutPanel != null &&
                    this.SourceTableLayoutPanel.Controls != null)
                {
                    foreach (ControllerSource.Control objControl in this.SourceTableLayoutPanel.Controls)
                    {
                        ControlController objControlController = GetControllerByWebObject(objControl) as ControlController;

                        if (objControlController != null)
                        {
                            SetTargetTableLayoutPanelCellPosition(objControl, objControlController);
                            SetTargetTableLayoutPanelColumnSpan(objControl, objControlController);
                            SetTargetTableLayoutPanelRowSpan(objControl, objControlController);
                        }
                    }
                }

            }
            finally
            {
                // Resume notifications.
                this.ResumeNotifications();
            }
        }

        protected virtual void SetTargetTableLayoutPanelColumnStyles()
        {
            this.mobjColumnStylesController.SetWinObjectObjects();
        }

        protected virtual void SetTargetTableLayoutPanelRowStyles()
        {
            this.mobjRowStylesController.SetWinObjectObjects();
        }

        protected virtual void SetTargetTableLayoutPanelBorderStyle()
        {
            this.TargetTableLayoutPanel.BorderStyle = (ControllerTarget.BorderStyle)this.GetConvertedEnum(typeof(ControllerTarget.BorderStyle), this.SourceTableLayoutPanel.BorderStyle);
        }

        protected virtual void SetTargetTableLayoutPanelCellBorderStyle()
        {
            this.TargetTableLayoutPanel.CellBorderStyle = (ControllerTarget.TableLayoutPanelCellBorderStyle)this.GetConvertedEnum(typeof(ControllerTarget.TableLayoutPanelCellBorderStyle), this.SourceTableLayoutPanel.CellBorderStyle);
        }

        protected virtual void SetTargetTableLayoutPanelColumnCount()
        {            
            this.SetWinProperty("ColumnCount", this.SourceTableLayoutPanel.ColumnCount);
        }

        protected virtual void SetTargetTableLayoutPanelGrowStyle()
        {
            this.TargetTableLayoutPanel.GrowStyle = (ControllerTarget.TableLayoutPanelGrowStyle)this.GetConvertedEnum(typeof(ControllerTarget.TableLayoutPanelGrowStyle), this.SourceTableLayoutPanel.GrowStyle);
        }

        protected virtual void SetTargetTableLayoutPanelRowCount()
        {
            this.SetWinProperty("RowCount", this.SourceTableLayoutPanel.RowCount);
        }

        protected virtual void SetTargetTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
        {
            ControllerSource.TableLayoutPanelCellPosition objSourceTableLayoutPanelCellPosition = this.SourceTableLayoutPanel.GetCellPosition((ControllerSource.Control)objSubject);

            if (objSourceTableLayoutPanelCellPosition != null)
            {
                this.TargetTableLayoutPanel.SetCellPosition((ControllerTarget.Control)objControlController.TargetObject, new ControllerTarget.TableLayoutPanelCellPosition(objSourceTableLayoutPanelCellPosition.Column, objSourceTableLayoutPanelCellPosition.Row));
            }
        }

        protected virtual void SetTargetTableLayoutPanelColumn(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                this.TargetTableLayoutPanel.SetColumn((ControllerTarget.Control)objControlController.TargetObject, this.SourceTableLayoutPanel.GetColumn((ControllerSource.Control)objSubject));
            }
        }

        protected virtual void SetTargetTableLayoutPanelRow(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                this.TargetTableLayoutPanel.SetRow((ControllerTarget.Control)objControlController.TargetObject, this.SourceTableLayoutPanel.GetRow((ControllerSource.Control)objSubject));
            }
        }

        protected virtual void SetTargetTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                this.TargetTableLayoutPanel.SetColumnSpan((ControllerTarget.Control)objControlController.TargetObject, this.SourceTableLayoutPanel.GetColumnSpan((ControllerSource.Control)objSubject));
            }
        }

        protected virtual void SetTargetTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                this.TargetTableLayoutPanel.SetRowSpan((ControllerTarget.Control)objControlController.TargetObject, this.SourceTableLayoutPanel.GetRowSpan((ControllerSource.Control)objSubject));
            }
        }

        
        #endregion

        #region Source Methods

        protected virtual void SetSourceTableLayoutPanelBorderStyle()
        {
            this.SourceTableLayoutPanel.BorderStyle = (ControllerSource.BorderStyle)this.GetConvertedEnum(typeof(ControllerSource.BorderStyle), this.TargetTableLayoutPanel.BorderStyle);
        }

        protected virtual void SetSourceTableLayoutPanelCellBorderStyle()
        {
            this.SourceTableLayoutPanel.CellBorderStyle = (ControllerSource.TableLayoutPanelCellBorderStyle)this.GetConvertedEnum(typeof(ControllerSource.TableLayoutPanelCellBorderStyle), this.TargetTableLayoutPanel.CellBorderStyle);
        }

        protected virtual void SetSourceTableLayoutPanelColumnCount()
        {
            this.SourceTableLayoutPanel.ColumnCount = this.TargetTableLayoutPanel.ColumnCount;
        }

        protected virtual void SetSourceTableLayoutPanelGrowStyle()
        {
            this.SourceTableLayoutPanel.GrowStyle = (ControllerSource.TableLayoutPanelGrowStyle)this.GetConvertedEnum(typeof(ControllerSource.TableLayoutPanelGrowStyle), this.TargetTableLayoutPanel.GrowStyle);
        }

        protected virtual void SetSourceTableLayoutPanelRowCount()
        {
            this.SourceTableLayoutPanel.RowCount = this.TargetTableLayoutPanel.RowCount;
        }

        protected virtual void SetSourceTableLayoutPanelColumnStyles()
        {
            this.mobjColumnStylesController.SetWebObjectObjects();
        }

        protected virtual void SetSourceTableLayoutPanelRowStyles()
        {
            this.mobjRowStylesController.SetWebObjectObjects();
        }

        protected virtual void SetSourceTableLayoutPanelControlsPositions()
        {
            try
            {
                this.SuspendNotifications();

                if (this.TargetTableLayoutPanel != null &&
                    this.TargetTableLayoutPanel.Controls != null)
                {
                    foreach (ControllerTarget.Control objControl in this.TargetTableLayoutPanel.Controls)
                    {
                        ControlController objControlController = GetControllerByWinObject(objControl) as ControlController;

                        if (objControlController != null)
                        {
                            SetSourceTableLayoutPanelCellPosition(objControl, objControlController);
                            SetSourceTableLayoutPanelColumnSpan(objControl, objControlController);
                            SetSourceTableLayoutPanelRowSpan(objControl, objControlController);
                        }
                    }
                }

            }
            finally
            {
                // Resume notifications.
                this.ResumeNotifications();
            }
        }

        protected virtual void SetSourceTableLayoutPanelControlPositions(ControllerTarget.Control objControl)
        {
            try
            {
                this.SuspendNotifications();

                if (this.SourceTableLayoutPanel != null &&
                    this.SourceTableLayoutPanel.Controls != null)
                {
                    ControlController objControlController = GetControllerByWinObject(objControl) as ControlController;

                    if (objControlController != null)
                    {
                        SetSourceTableLayoutPanelCellPosition(objControl, objControlController);
                        SetSourceTableLayoutPanelColumnSpan(objControl, objControlController);
                        SetSourceTableLayoutPanelRowSpan(objControl, objControlController);
                    }
                }

            }
            finally
            {
                // Resume notifications.
                this.ResumeNotifications();
            }
        }

        protected virtual void SetSourceTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
        {
            ControllerTarget.TableLayoutPanelCellPosition objTargetTableLayoutPanelCellPosition = this.TargetTableLayoutPanel.GetCellPosition(((ControllerTarget.Control)objSubject));

            if (objTargetTableLayoutPanelCellPosition != null)
            {
                ControllerSource.TableLayoutPanelCellPosition objCurrentCellPosition = this.SourceTableLayoutPanel.GetCellPosition((ControllerSource.Control)objControlController.SourceObject);

                //check if value changed
                if(objCurrentCellPosition==null || objCurrentCellPosition.Column!=objTargetTableLayoutPanelCellPosition.Column || objCurrentCellPosition.Row!=objTargetTableLayoutPanelCellPosition.Row)
                {
                    this.SourceTableLayoutPanel.SetCellPosition(((ControllerSource.Control)objControlController.SourceObject), new ControllerSource.TableLayoutPanelCellPosition(objTargetTableLayoutPanelCellPosition.Column, objTargetTableLayoutPanelCellPosition.Row));
                }
            }
        }
        
        protected virtual void SetSourceTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                int intNewColumnSpan        = this.TargetTableLayoutPanel.GetColumnSpan((ControllerTarget.Control)objSubject);
                int intCurrentColumnSpan    = this.SourceTableLayoutPanel.GetColumnSpan((ControllerSource.Control)objControlController.SourceObject);

                //check if value changed
                if(intCurrentColumnSpan!=intNewColumnSpan)
                {
                    this.SourceTableLayoutPanel.SetColumnSpan((ControllerSource.Control)objControlController.SourceObject,intNewColumnSpan);
                }
            }
        }

        protected virtual void SetSourceTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
        {
            if (objSubject != null)
            {
                int intNewRowSpan       = this.TargetTableLayoutPanel.GetRowSpan((ControllerTarget.Control)objSubject);
                int intCurrentRowSpan   = this.SourceTableLayoutPanel.GetRowSpan((ControllerSource.Control)objControlController.SourceObject);

                //check if value changed
                if (intCurrentRowSpan != intNewRowSpan)
                {
                    this.SourceTableLayoutPanel.SetRowSpan((ControllerSource.Control)objControlController.SourceObject, intNewRowSpan);
                }
            }
        }

        
        #endregion

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
        public ControllerTarget.TableLayoutPanel TargetTableLayoutPanel
		{
			get
			{
                return this.TargetObject as ControllerTarget.TableLayoutPanel;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutPanel SourceTableLayoutPanel
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutPanel;
			}
		}

		#endregion Properties
	}

	#endregion TableLayoutPanelController Class

}
