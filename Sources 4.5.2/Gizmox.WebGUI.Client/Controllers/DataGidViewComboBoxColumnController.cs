#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region DataGidViewComboBoxColumnController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class DataGidViewComboBoxColumnController : DataGidViewColumnController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebColumn"></param>
        /// <param name="objWinColumn"></param>
        public DataGidViewComboBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
            : base(objContext, objWebColumn, objWinColumn)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DataGidViewComboBoxColumnController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
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

            this.SetWinDataGridViewComboBoxColumnDataSource();
        }

        /// <summary>
        /// Generic create winforms control
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.DataGridViewComboBoxColumn();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.FireWebPropertyChanged(objPropertyChangeArgs);
        }

        /// <summary>
        /// Called when [source object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "DataSource":
                    SetWinDataGridViewComboBoxColumnDataSource();
                    break;
            }
        }

        #region Set Property

        /// <summary>
        /// Sets the win data grid view combo box column data source.
        /// </summary>
        protected virtual void SetWinDataGridViewComboBoxColumnDataSource()
        {
            bool blnApplyDataSource = true;

            // Get web data source.
            object objWebDataSource = this.WebDataGridViewComboBoxColumn.DataSource;
            object objWinDataSource = objWebDataSource;

            // Check if the web data source is a none empty VWG BindingSource.
            if (objWebDataSource != null && objWebDataSource is WebForms.BindingSource)
            {
                // Try getting the VWG BindingSource's controler.
                ObjectController objObjectController = this.GetControllerByWebObject(objWebDataSource);
                if (objObjectController != null)
                {
                    // Get the WinForms BindingSource's out of the controller.
                    objWinDataSource = objObjectController.TargetObject;
                }
                else
                {
                    // When ever a VWG BindingSource does not have a valid controller 
                    // - flag not to apply data source.
                    blnApplyDataSource = false;
                }
            }

            // Cehc if applying of data source is needed.
            if (blnApplyDataSource && 
                this.WinDataGridViewComboBoxColumn.DataSource != objWinDataSource)
            {
                // Apply data source to the target conrol.
                this.WinDataGridViewComboBoxColumn.DataSource = objWinDataSource;

                // Refresh designer.
                this.RefreshDesigner();
            }
        }

        #endregion Set Property

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.DataGridViewComboBoxColumn WebDataGridViewComboBoxColumn
        {
            get
            {
                return base.SourceObject as WebForms.DataGridViewComboBoxColumn;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.DataGridViewComboBoxColumn WinDataGridViewComboBoxColumn
        {
            get
            {
                return base.TargetObject as WinForms.DataGridViewComboBoxColumn;
            }
        }

        #endregion Properties

    }

    #endregion DataGidViewComboBoxColumnController Class

}
