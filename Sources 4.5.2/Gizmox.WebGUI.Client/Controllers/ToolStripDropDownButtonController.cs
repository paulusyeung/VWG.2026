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
    public class ToolStripDropDownButtonController : ToolStripDropDownItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripDropDownButton">The web tool strip item.</param>
        /// <param name="objWinToolStripDropDownButton">The win tool strip item.</param>
		public ToolStripDropDownButtonController(IContext objContext,object objWebToolStripDropDownButton,object objWinToolStripDropDownButton) : base(objContext,objWebToolStripDropDownButton,objWinToolStripDropDownButton)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripDropDownButton">The web tool strip.</param>
        public ToolStripDropDownButtonController(IContext objContext, object objWebToolStripDropDownButton) : base(objContext, objWebToolStripDropDownButton)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripDropDownButton WebToolStripDropDownButton
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripDropDownButton;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripDropDownButton WinToolStripDropDownButton
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripDropDownButton;
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
            return new WinForms.ToolStripDropDownButton();
        }

        #endregion
    }
}
