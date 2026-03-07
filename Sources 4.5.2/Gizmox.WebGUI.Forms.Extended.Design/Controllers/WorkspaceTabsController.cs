using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkspaceTabsController : Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController
    {
        #region C'Tor/D'Tor


        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceTabsController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        /// <param name="objWinObject"></param>
        public WorkspaceTabsController(IContext objContext, object objWebObject, object objWinObject)
            : base(objContext, objWebObject, objWinObject)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceTabsController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        public WorkspaceTabsController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }
        
        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Called when target object property has changed.
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
        } 

        #endregion
    }
}
