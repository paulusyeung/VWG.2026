#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using ControllerSource = Gizmox.WebGUI.Forms;
using ControllerTarget = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
    #region SplitterPanelController Class

    /// <summary>
    /// Controls the relations between a webgui control and a ControllerTarget control
    /// </summary>
    
	public class SplitterPanelController : Gizmox.WebGUI.Client.Controllers.SplitterPanelController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitterPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objSourceObject">The obj source object.</param>
        /// <param name="objTargetObject">The obj target object.</param>
        public SplitterPanelController(IContext objContext, object objSourceObject, object objTargetObject)
            : base(objContext, objSourceObject, objTargetObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitterPanelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="SplitterPanelController">The splitter panel controller.</param>
        public SplitterPanelController(IContext objContext, object SplitterPanelController)
            : base(objContext, SplitterPanelController)
        {
        }

        #endregion C'Tor/D'Tor

    }

    #endregion SplitterPanelController Class

}
