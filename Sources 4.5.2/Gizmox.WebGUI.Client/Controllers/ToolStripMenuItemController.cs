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
    public class ToolStripMenuItemController : ToolStripDropDownItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripMenuItemController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripMenuItem">The web tool strip item.</param>
        /// <param name="objWinToolStripMenuItem">The win tool strip item.</param>
		public ToolStripMenuItemController(IContext objContext,object objWebToolStripMenuItem,object objWinToolStripMenuItem) : base(objContext,objWebToolStripMenuItem,objWinToolStripMenuItem)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripMenuItemController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripMenuItem">The web tool strip.</param>
        public ToolStripMenuItemController(IContext objContext, object objWebToolStripMenuItem) : base(objContext, objWebToolStripMenuItem)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripMenuItem WebToolStripMenuItem
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripMenuItem;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripMenuItem WinToolStripMenuItem
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripMenuItem;
            }
        }

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

        #region Methods

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ToolStripMenuItem();
        }

        /// <summary>
        /// Initializes the controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinToolStripMenuItemChecked();
            SetWinToolStripMenuItemCheckState();
            SetWinToolStripMenuItemShortcutKeys();
        }

        /// <summary>
        /// Sets the win tool strip menu item checked.
        /// </summary>
        private void SetWinToolStripMenuItemChecked()
        {
            if (this.WebToolStripMenuItem != null && this.WinToolStripMenuItem != null)
            {
                this.WinToolStripMenuItem.Checked = this.WebToolStripMenuItem.Checked;
            }
        }

        /// <summary>
        /// Sets the state of the win tool strip menu item check.
        /// </summary>
        private void SetWinToolStripMenuItemCheckState()
        {
            if (this.WebToolStripMenuItem != null && this.WinToolStripMenuItem != null)
            {
                this.WinToolStripMenuItem.CheckState = (WinForms.CheckState)Enum.Parse(typeof(WinForms.CheckState), this.WebToolStripMenuItem.CheckState.ToString());

                // Redraw winform menu item
                this.WinToolStripMenuItem.Invalidate();
            }
        }


        /// <summary>
        /// Sets the win tool strip menu item shortcut keys.
        /// </summary>
        private void SetWinToolStripMenuItemShortcutKeys()
        {
            if (this.WebToolStripMenuItem != null && this.WinToolStripMenuItem != null)
            {
                this.WinToolStripMenuItem.ShortcutKeys = (WinForms.Keys)Enum.Parse(typeof(WinForms.Keys), ((int)this.WebToolStripMenuItem.ShortcutKeys).ToString());  
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Checked":
                    SetWinToolStripMenuItemChecked();
                    break;
                case "CheckState":
                    SetWinToolStripMenuItemCheckState();
                    break;
                case "ShortcutKeys":
                    SetWinToolStripMenuItemShortcutKeys();
                    break;
            }
        }

        #endregion
    }
}
