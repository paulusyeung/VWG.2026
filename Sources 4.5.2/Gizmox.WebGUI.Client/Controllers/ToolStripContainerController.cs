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
    public class ToolStripContainerController : ContainerControlController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripContainerController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripContainer">The web tool strip.</param>
        /// <param name="objWinToolStripContainer">The win tool strip.</param>
		public ToolStripContainerController(IContext objContext,object objWebToolStripContainer,object objWinToolStripContainer) : base(objContext,objWebToolStripContainer,objWinToolStripContainer)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripContainerController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripContainer">The web tool strip.</param>
        public ToolStripContainerController(IContext objContext, object objWebToolStripContainer) : base(objContext, objWebToolStripContainer)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        #region Properties

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ToolStripContainer();
        } 

        #endregion
    }
}
