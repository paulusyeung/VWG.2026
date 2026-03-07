#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region DataGidViewLinkColumnController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class DataGidViewLinkColumnController : DataGidViewColumnController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebColumn"></param>
        /// <param name="objWinColumn"></param>
        public DataGidViewLinkColumnController(IContext objContext, object objWebColumn, object objWinColumn)
            : base(objContext, objWebColumn, objWinColumn)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DataGidViewLinkColumnController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();
            SetWinColumnActiveLinkColor();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.FireWebPropertyChanged(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ActiveLinkColor":
                    SetWinColumnActiveLinkColor();
                    break;
            }
        }

        /// <summary>
        /// Generic create winforms control
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.DataGridViewLinkColumn();
        }

        #region Set Property

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWinColumnActiveLinkColor()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            ((WinForms.DataGridViewLinkColumn)this.WinColumn).ActiveLinkColor = ((WebForms.DataGridViewLinkColumn)this.WebColumn).ActiveLinkColor;
#endif
		}

        /// <summary>
        ///
        /// </summary>
        protected override void SetWinColumnWidth()
        {
            base.SetWinColumnWidth();
        }


        #endregion Set Property

        #endregion Methods

        #region Properties


        #endregion Properties

    }

    #endregion DataGidViewLinkColumnController Class

}
