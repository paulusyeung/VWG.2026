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
    public class ToolStripStatusLabelController : ToolStripLabelController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripStatusLabelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripStatusLabel">The web tool strip item.</param>
        /// <param name="objWinToolStripStatusLabel">The win tool strip item.</param>
		public ToolStripStatusLabelController(IContext objContext,object objWebToolStripStatusLabel,object objWinToolStripStatusLabel) : base(objContext,objWebToolStripStatusLabel,objWinToolStripStatusLabel)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripStatusLabelController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripStatusLabel">The web tool strip.</param>
        public ToolStripStatusLabelController(IContext objContext, object objWebToolStripStatusLabel) : base(objContext, objWebToolStripStatusLabel)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripStatusLabel WebToolStripStatusLabel
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripStatusLabel;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripStatusLabel WinToolStripStatusLabel
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripStatusLabel;
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
            return new WinForms.ToolStripStatusLabel();
        }

        #endregion
    }
}
