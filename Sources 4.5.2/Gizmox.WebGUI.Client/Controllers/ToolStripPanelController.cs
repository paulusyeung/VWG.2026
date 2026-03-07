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
    public class ToolStripPanelController : ContainerControlController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripPanel">The web tool strip.</param>
        /// <param name="objWinToolStripPanel">The win tool strip.</param>
		public ToolStripPanelController(IContext objContext,object objWebToolStripPanel,object objWinToolStripPanel) : base(objContext,objWebToolStripPanel,objWinToolStripPanel)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripPanel">The web tool strip.</param>
        public ToolStripPanelController(IContext objContext, object objWebToolStripPanel) : base(objContext, objWebToolStripPanel)
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
            return new WinForms.ToolStripPanel();
        } 

        #endregion
    }
}
