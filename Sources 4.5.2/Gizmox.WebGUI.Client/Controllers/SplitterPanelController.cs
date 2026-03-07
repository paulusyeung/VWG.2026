#region Using

using System;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region SplitterPanelController Class

    ///  <summary>
    /// Represents a panel that dynamically lays out its contents in a grid composed of rows and columns.
    ///  </summary>
	public class SplitterPanelController : PanelController
    {
        #region Class Memebers

        #endregion Class Memebers

        #region C'Tors

        public SplitterPanelController(IContext objContext, object objSourceObject, object objTargetObject)
            : base(objContext, objSourceObject, objTargetObject)
        {
        }

        public SplitterPanelController(IContext objContext, object objSourceObject)
            : base(objContext, objSourceObject)
        {
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// </summary>
        protected override void SetWinControlDock()
        {
            // Prevent the target SplitterPanel from having any docking.
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinSplitterPanelName();
        }

        /// <summary>
        /// Sets the name of the win splitter panel.
        /// </summary>
        private void SetWinSplitterPanelName()
        {
            if (this.TargetSplitterPanel != null && this.SourceSplitterPanel != null)
            {
                ((ControllerTarget.Panel)this.TargetSplitterPanel).Name = ((ControllerSource.Panel)this.SourceSplitterPanel).Name;
            }
        }

        /// <summary>
        /// Creates the target object.
        /// </summary>
        protected override object CreateTargetObject(object objSourceObject)
        {
            ControllerTarget.SplitContainer objSplitContainer = null;

            if (objSourceObject != null &&
                objSourceObject is ControllerSource.SplitterPanel &&
                ((ControllerSource.SplitterPanel)objSourceObject).Parent != null)
            {
                SplitContainerController objSplitContainerController = GetControllerByWebObject(((ControllerSource.SplitterPanel)objSourceObject).Parent) as SplitContainerController;

                if (objSplitContainerController != null)
                {
                    objSplitContainer = objSplitContainerController.TargetSplitContainer;
                }
            }

            return new ControllerTarget.SplitterPanel(objSplitContainer);
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "Name":
                    this.SetWinSplitterPanelName();
                    break;
                default:
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Get typed the target object.
        /// </summary>
        public ControllerTarget.SplitterPanel TargetSplitterPanel
        {
            get
            {
                return this.TargetObject as ControllerTarget.SplitterPanel;
            }
        }

        /// <summary>
        /// Get typed the source object.
        /// </summary>
        public ControllerSource.SplitterPanel SourceSplitterPanel
        {
            get
            {
                return this.SourceObject as ControllerSource.SplitterPanel;
            }
        }

        #endregion Properties
    }

    #endregion SplitterPanelController Class

}
