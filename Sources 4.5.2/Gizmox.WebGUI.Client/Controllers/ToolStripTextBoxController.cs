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
    public class ToolStripTextBoxController : ToolStripControlHostController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripTextBoxController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripTextBox">The web tool strip item.</param>
        /// <param name="objWinToolStripTextBox">The win tool strip item.</param>
        public ToolStripTextBoxController(IContext objContext,object objWebToolStripTextBox,object objWinToolStripTextBox) : base(objContext,objWebToolStripTextBox,objWinToolStripTextBox)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripTextBoxController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripTextBox">The web tool strip.</param>
        public ToolStripTextBoxController(IContext objContext, object objWebToolStripTextBox) : base(objContext, objWebToolStripTextBox)
        {
        }

        #endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripTextBox WebToolStripTextBox
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripTextBox;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripTextBox WinToolStripTextBox
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripTextBox;
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
            return new WinForms.ToolStripTextBox();
        }

        /// <summary>
        /// Initializes the controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinToolStripItemTextBoxTextAlign();
        }

        /// <summary>
        /// Event handler synchronizing properties between web-winforms objects.
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "TextBoxTextAlign":
                    this.SetWinToolStripItemTextBoxTextAlign();
                    break;
            }
        }

        /// <summary>
        /// Synchronizes the toolstripitem textboxtextalign property between web-winforms objects.
        /// </summary>
        protected virtual void SetWinToolStripItemTextBoxTextAlign()
        {
            if (this.WinToolStripTextBox != null && this.WebToolStripTextBox != null)
            {
                this.WinToolStripTextBox.TextBoxTextAlign = (WinForms.HorizontalAlignment)GetConvertedEnum(typeof(WinForms.HorizontalAlignment), this.WebToolStripTextBox.TextBoxTextAlign); ;
            }
        }

        #endregion
    }
}
