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
    public class ToolStripComboBoxController : ToolStripControlHostController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripComboBoxController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripComboBox">The web tool strip item.</param>
        /// <param name="objWinToolStripComboBox">The win tool strip item.</param>
		public ToolStripComboBoxController(IContext objContext,object objWebToolStripComboBox,object objWinToolStripComboBox) : base(objContext,objWebToolStripComboBox,objWinToolStripComboBox)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripComboBoxController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripComboBox">The web tool strip.</param>
        public ToolStripComboBoxController(IContext objContext, object objWebToolStripComboBox) : base(objContext, objWebToolStripComboBox)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripComboBox WebToolStripComboBox
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripComboBox;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripComboBox WinToolStripComboBox
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripComboBox;
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
            return new WinForms.ToolStripComboBox();
        }

        #endregion
    }
}
