using System;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ListControlController : ControlController
    {
		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListControlController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebTreeView">The obj web tree view.</param>
        /// <param name="objWinTreeView">The obj win tree view.</param>
		public ListControlController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ListControlController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebObject">The obj web object.</param>
        public ListControlController(IContext objContext, object objWebObject) : base(objContext, objWebObject)
		{
		}

		#endregion Constructors 

		#region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ListControl WebListControl
        {
            get
            {
                return base.SourceObject as WebForms.ListControl;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ListControl WinListControl
        {
            get
            {
                return base.TargetObject as WinForms.ListControl;
            }
        }

		#endregion Properties 

		#region Methods

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinListControlFormattingEnabled();
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "FormattingEnabled":
                    SetWinListControlFormattingEnabled();
                    break;
            }
        }

        /// <summary>
        /// Sets the win list control formatting enabled.
        /// </summary>
        private void SetWinListControlFormattingEnabled()
        {
            this.WinListControl.FormattingEnabled = this.WebListControl.FormattingEnabled;
        }


		#endregion Methods 
    }
}
