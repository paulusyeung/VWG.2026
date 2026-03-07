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
    public class ToolStripDropDownMenuController : ToolStripDropDownController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownMenuController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripDropDownMenu">The web tool strip.</param>
        /// <param name="objWinToolStripDropDownMenu">The win tool strip.</param>
		public ToolStripDropDownMenuController(IContext objContext,object objWebToolStripDropDownMenu,object objWinToolStripDropDownMenu) : base(objContext,objWebToolStripDropDownMenu,objWinToolStripDropDownMenu)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownMenuController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripDropDownMenu">The web tool strip.</param>
        public ToolStripDropDownMenuController(IContext objContext, object objWebToolStripDropDownMenu) : base(objContext, objWebToolStripDropDownMenu)
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
            return new WinForms.ToolStripDropDownMenu();
        } 

        #endregion
    }
}
