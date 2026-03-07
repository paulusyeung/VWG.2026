#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationTabsController : TabControlController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationTabsController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        /// <param name="objWinObject"></param>
        public NavigationTabsController(IContext objContext, object objWebObject, object objWinObject)
            : base(objContext, objWebObject, objWinObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationTabsController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        public NavigationTabsController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }

        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        protected override void WireEvents()
        {
            base.WireEvents();

            WinTabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(WinTabControl_ControlAdded);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void UnwireEvents()
        {
            base.UnwireEvents();

            WinTabControl.ControlAdded -= new System.Windows.Forms.ControlEventHandler(WinTabControl_ControlAdded);
        }

        /// <summary>
        /// Occures after a control has been added to a tab control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WinTabControl_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            if (e.Control != null && 
                WinTabControl != null && WebTabControl != null)
            {
                bool blnRemoveControl = false;

                // Define a stack trace.
                StackTrace objStackTrace = new StackTrace();

                if (objStackTrace != null)
                {
                    // Loop all frames in stack trace.
                    for (int intFrame = 0; intFrame < objStackTrace.FrameCount; intFrame++)
                    {
                        MethodBase objMethodBase = objStackTrace.GetFrame(intFrame).GetMethod();
                        if (objMethodBase != null)
                        {
                            string strMethod = objMethodBase.Name;
                            string strDeclaringType = objMethodBase.DeclaringType.FullName;

                            // Check if current frame's method is the InitializeNewComponent of the TabControlDesigner.
                            if (strMethod == "InitializeNewComponent" && strDeclaringType == "System.Windows.Forms.Design.TabControlDesigner")
                            {
                                // Flag to remove control.
                                blnRemoveControl = true;
                                break;
                            }
                        }
                    }
                }

                if (blnRemoveControl)
                {
                    // Removes control from the winforms tab control.
                    WinTabControl.Controls.Remove(e.Control);

                    // Get tabpage controler by the winforms tabpage.
                    TabPageController objTabPageController = this.GetControllerByWinObject(e.Control) as TabPageController;

                    // Validate controller and its source object.
                    if (objTabPageController != null && objTabPageController.WebTabPage != null)
                    {
                        // Removes control from the webgui tab control.
                        WebTabControl.TabPages.Remove(objTabPageController.WebTabPage);

                        // Unregister the webgui tabpage.
                        DesignServices.UnregisterWebComponent(objTabPageController.WebTabPage);
                    }
                }
            }
        }

        #endregion
    }
}
