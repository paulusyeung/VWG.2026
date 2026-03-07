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
    public class ToolStripButtonController : ToolStripItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripButton">The web tool strip item.</param>
        /// <param name="objWinToolStripButton">The win tool strip item.</param>
		public ToolStripButtonController(IContext objContext,object objWebToolStripButton,object objWinToolStripButton) : base(objContext,objWebToolStripButton,objWinToolStripButton)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripButton">The web tool strip.</param>
        public ToolStripButtonController(IContext objContext, object objWebToolStripButton) : base(objContext, objWebToolStripButton)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripButton WebToolStripButton
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripButton;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripButton WinToolStripButton
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripButton;
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
            return new WinForms.ToolStripButton();
        }

        #endregion
    }
}
