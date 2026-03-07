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
    public class StatusStripController : ToolStripController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusStripController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebStatusStrip">The web tool strip.</param>
        /// <param name="objWinStatusStrip">The win tool strip.</param>
		public StatusStripController(IContext objContext,object objWebStatusStrip,object objWinStatusStrip) : base(objContext,objWebStatusStrip,objWinStatusStrip)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusStripController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebStatusStrip">The web tool strip.</param>
        public StatusStripController(IContext objContext, object objWebStatusStrip) : base(objContext, objWebStatusStrip)
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
            return new WinForms.StatusStrip();
        } 

        #endregion
    }
}
