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
    public class ToolStripLabelController : ToolStripItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripLabelController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripLabel">The web tool strip item.</param>
        /// <param name="objWinToolStripLabel">The win tool strip item.</param>
		public ToolStripLabelController(IContext objContext,object objWebToolStripLabel,object objWinToolStripLabel) : base(objContext,objWebToolStripLabel,objWinToolStripLabel)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripLabelController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripLabel">The web tool strip.</param>
        public ToolStripLabelController(IContext objContext, object objWebToolStripLabel) : base(objContext, objWebToolStripLabel)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripLabel WebToolStripLabel
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripLabel;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripLabel WinToolStripLabel
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripLabel;
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
            return new WinForms.ToolStripLabel();
        }

        /// <summary>
        /// Initializes the controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinToolStripLabelIsLink();
        }

        /// <summary>
        /// Called when [source object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "IsLink":
                    this.SetWinToolStripLabelIsLink();
                    break;
            }
        }

        /// <summary>
        /// Sets the win tool strip label is link.
        /// </summary>
        protected virtual void SetWinToolStripLabelIsLink()
        {
            this.WinToolStripLabel.IsLink = this.WebToolStripLabel.IsLink;
        }

        #endregion
    }
}
