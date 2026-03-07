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
    public class ToolStripDropDownController : ToolStripController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripDropDown">The web tool strip.</param>
        /// <param name="objWinToolStripDropDown">The win tool strip.</param>
		public ToolStripDropDownController(IContext objContext,object objWebToolStripDropDown,object objWinToolStripDropDown) : base(objContext,objWebToolStripDropDown,objWinToolStripDropDown)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripDropDown">The web tool strip.</param>
        public ToolStripDropDownController(IContext objContext, object objWebToolStripDropDown) : base(objContext, objWebToolStripDropDown)
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
            return new WinForms.ToolStripDropDown();
        } 

        #endregion
    }
}
