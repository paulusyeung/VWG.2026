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
    public class ToolStripControlHostController : ToolStripItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripControlHostController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripControlHost">The web tool strip item.</param>
        /// <param name="objWinToolStripControlHost">The win tool strip item.</param>
		public ToolStripControlHostController(IContext objContext,object objWebToolStripControlHost,object objWinToolStripControlHost) : base(objContext,objWebToolStripControlHost,objWinToolStripControlHost)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripControlHostController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripControlHost">The web tool strip.</param>
        public ToolStripControlHostController(IContext objContext, object objWebToolStripControlHost) : base(objContext, objWebToolStripControlHost)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripControlHost WebToolStripControlHost
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripControlHost;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripControlHost WinToolStripControlHost
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripControlHost;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generic create winforms control
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return null;
        }

        #endregion
    }
}
