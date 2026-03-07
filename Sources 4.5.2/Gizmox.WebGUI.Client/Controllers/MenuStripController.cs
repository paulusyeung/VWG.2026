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
    public class MenuStripController : ToolStripController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuStripController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebMenuStrip">The web tool strip.</param>
        /// <param name="objWinMenuStrip">The win tool strip.</param>
		public MenuStripController(IContext objContext,object objWebMenuStrip,object objWinMenuStrip) : base(objContext,objWebMenuStrip,objWinMenuStrip)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuStripController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebMenuStrip">The web tool strip.</param>
        public MenuStripController(IContext objContext, object objWebMenuStrip) : base(objContext, objWebMenuStrip)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.MenuStrip();
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [use menu deisgner].
        /// </summary>
        /// <value><c>true</c> if [use menu deisgner]; otherwise, <c>false</c>.</value>
        protected override bool UseVsMenuDeisgner
        {
            get
            {
                return false;
            }
        } 

        #endregion
    }
}
