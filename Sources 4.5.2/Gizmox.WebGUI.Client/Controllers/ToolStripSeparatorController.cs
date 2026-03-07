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
    public class ToolStripSeparatorController : ToolStripItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripSeparatorController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripSeparator">The web tool strip item.</param>
        /// <param name="objWinToolStripSeparator">The win tool strip item.</param>
		public ToolStripSeparatorController(IContext objContext,object objWebToolStripSeparator,object objWinToolStripSeparator) : base(objContext,objWebToolStripSeparator,objWinToolStripSeparator)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripSeparatorController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripSeparator">The web tool strip.</param>
        public ToolStripSeparatorController(IContext objContext, object objWebToolStripSeparator) : base(objContext, objWebToolStripSeparator)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripSeparator WebToolStripSeparator
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripSeparator;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripSeparator WinToolStripSeparator
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripSeparator;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ToolStripSeparator();
        }

        /// <summary>
        /// Initializes the controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();
        }

        #endregion
    }
}
