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
    /// <summary>
    /// 
    /// </summary>
    public class ToolStripProgressBarController : ToolStripControlHostController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripProgressBarController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripProgressBar">The web tool strip item.</param>
        /// <param name="objWinToolStripProgressBar">The win tool strip item.</param>
		public ToolStripProgressBarController(IContext objContext,object objWebToolStripProgressBar,object objWinToolStripProgressBar) : base(objContext,objWebToolStripProgressBar,objWinToolStripProgressBar)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripProgressBarController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripProgressBar">The web tool strip.</param>
        public ToolStripProgressBarController(IContext objContext, object objWebToolStripProgressBar) : base(objContext, objWebToolStripProgressBar)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripProgressBar WebToolStripProgressBar
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripProgressBar;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripProgressBar WinToolStripProgressBar
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripProgressBar;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Value":
                    this.SetWinToolStripProgressBarValue();
                    break;
            }
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ToolStripProgressBar();
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinToolStripProgressBarValue();
        }

        /// <summary>
        /// Sets the win tool strip progress bar value.
        /// </summary>
        private void SetWinToolStripProgressBarValue()
        {
            if (this.WinToolStripProgressBar != null && this.WebToolStripProgressBar != null)
            {
                this.WinToolStripProgressBar.Value = this.WebToolStripProgressBar.Value;
            }
        }

        #endregion
    }
}
