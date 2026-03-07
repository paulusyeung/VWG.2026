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
    public class ToolStripContentPanelController : PanelController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripContentPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripContentPanel">The web tool strip.</param>
        /// <param name="objWinToolStripContentPanel">The win tool strip.</param>
		public ToolStripContentPanelController(IContext objContext,object objWebToolStripContentPanel,object objWinToolStripContentPanel) : base(objContext,objWebToolStripContentPanel,objWinToolStripContentPanel)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripContentPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripContentPanel">The web tool strip.</param>
        public ToolStripContentPanelController(IContext objContext, object objWebToolStripContentPanel) : base(objContext, objWebToolStripContentPanel)
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
            return new WinForms.ToolStripContentPanel();
        } 

        #endregion
    }
}
