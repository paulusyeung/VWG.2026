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
    #region CheckedListBoxController Class

    public class CheckedListBoxController: ListBoxController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedListBoxController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public CheckedListBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
            : base(objContext, objWebTreeView, objWinTreeView)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedListBoxController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        public CheckedListBoxController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }
		
		#endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();
            SetWinCheckOnClick();
           
        }

        /// <summary>
        /// Sets the win check on click.
        /// </summary>
        protected virtual void SetWinCheckOnClick()
        {
            this.WinCheckedListBox.CheckOnClick = this.WebCheckedListBox.CheckOnClick;
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.CheckedListBox();
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "CheckOnClick":
                    SetWinCheckOnClick();
                    break;
            }
        }
        #endregion Events

        #region Properties

        /// <summary>
        /// Gets the web checked list box.
        /// </summary>
        /// <value>The web checked list box.</value>
        public WebForms.CheckedListBox WebCheckedListBox
        {
            get
            {
                return base.SourceObject as WebForms.CheckedListBox;
            }
        }

        /// <summary>
        /// Gets the win checked list box.
        /// </summary>
        /// <value>The win checked list box.</value>
        public WinForms.CheckedListBox WinCheckedListBox
        {
            get
            {
                return base.TargetObject as WinForms.CheckedListBox;
            }
        }

        #endregion Properties
    }

    #endregion
}
