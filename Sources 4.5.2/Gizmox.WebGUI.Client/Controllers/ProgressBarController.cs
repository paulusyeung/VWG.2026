#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region ProgressBarController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>

    public class ProgressBarController : ControlController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ProgressBarController(IContext objContext, object objWebTreeView, object objWinTreeView)
            : base(objContext, objWebTreeView, objWinTreeView)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ProgressBarController(IContext objContext, object objWebTreeView)
            : base(objContext, objWebTreeView)
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
            this.SetWinProgressBarValue();
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ProgressBar();
        }

        #region Events

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Value":
                    SetWinProgressBarValue();
                    break;
            }
        }

        /// <summary>
        /// Sets the win progress bar value.
        /// </summary>
        private void SetWinProgressBarValue()
        {
            if (this.WinProgressBar.Value != this.WebProgressBar.Value)
            {
                this.WinProgressBar.Value = this.WebProgressBar.Value;
            }
        }


        #endregion Events

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ProgressBar WebProgressBar
        {
            get
            {
                return base.SourceObject as WebForms.ProgressBar;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ProgressBar WinProgressBar
        {
            get
            {
                return base.TargetObject as WinForms.ProgressBar;
            }
        }


        #endregion Properties

    }

    #endregion ProgressBarController Class

}
