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
    public class ContextMenuStripController : ToolStripDropDownMenuController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenuStripController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebContextMenuStrip">The web tool strip.</param>
        /// <param name="objWinContextMenuStrip">The win tool strip.</param>
		public ContextMenuStripController(IContext objContext,object objWebContextMenuStrip,object objWinContextMenuStrip) : base(objContext,objWebContextMenuStrip,objWinContextMenuStrip)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenuStripController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebContextMenuStrip">The web tool strip.</param>
        public ContextMenuStripController(IContext objContext, object objWebContextMenuStrip) : base(objContext, objWebContextMenuStrip)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinContextMenuStripShowCheckMargin();
            SetWinContextMenuStripShowImageMargin();
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ContextMenuStrip();
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ShowCheckMargin":
                    SetWinContextMenuStripShowCheckMargin();
                    break;
                case "ShowImageMargin":
                    SetWinContextMenuStripShowImageMargin();
                    break;
            }
        }

        /// <summary>
        /// Sets the win context menu strip show image margin.
        /// </summary>
        private void SetWinContextMenuStripShowImageMargin()
        {
            if (this.WebContextMenuStrip != null && this.WinContextMenuStrip != null)
            {
                this.WinContextMenuStrip.ShowImageMargin = this.WebContextMenuStrip.ShowImageMargin;
            }
        }

        /// <summary>
        /// Sets the win context menu strip show check margin.
        /// </summary>
        private void SetWinContextMenuStripShowCheckMargin()
        {
            if (this.WebContextMenuStrip != null && this.WinContextMenuStrip != null)
            {
                this.WinContextMenuStrip.ShowCheckMargin = this.WebContextMenuStrip.ShowCheckMargin;
            }
        }


        /// <summary>
        /// Set windows ContextMenuStrip BackColor
        /// </summary>
        protected override void SetWinControlBackColor()
        {
            if (this.WinContextMenuStrip != null && this.WebContextMenuStrip != null)
            {
                if (this.WebContextMenuStrip.BackColor != Color.Transparent)
                {
                    base.SetWinControlBackColor();
                }
            }
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

        /// <summary>
        /// Gets the web context menu strip.
        /// </summary>
        private WebForms.ContextMenuStrip WebContextMenuStrip
        {
            get
            {
                return this.WebControl as WebForms.ContextMenuStrip;
            }
        }

        /// <summary>
        /// Gets the win context menu strip.
        /// </summary>
        private WinForms.ContextMenuStrip WinContextMenuStrip
        {
            get
            {
                return this.WinControl as WinForms.ContextMenuStrip;
            }
        }

        #endregion
    }
}
