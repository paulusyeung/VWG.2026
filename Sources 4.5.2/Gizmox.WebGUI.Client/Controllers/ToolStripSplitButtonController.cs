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
    public class ToolStripSplitButtonController : ToolStripDropDownItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripSplitButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripSplitButton">The web tool strip item.</param>
        /// <param name="objWinToolStripSplitButton">The win tool strip item.</param>
		public ToolStripSplitButtonController(IContext objContext,object objWebToolStripSplitButton,object objWinToolStripSplitButton) : base(objContext,objWebToolStripSplitButton,objWinToolStripSplitButton)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripSplitButtonController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripSplitButton">The web tool strip.</param>
        public ToolStripSplitButtonController(IContext objContext, object objWebToolStripSplitButton) : base(objContext, objWebToolStripSplitButton)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripSplitButton WebToolStripSplitButton
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripSplitButton;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripSplitButton WinToolStripSplitButton
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripSplitButton;
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
            return new WinForms.ToolStripSplitButton();
        }

        #endregion
    }
}
