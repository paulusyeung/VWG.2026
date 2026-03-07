#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using


namespace Gizmox.WebGUI.Client.Controllers
{
    #region DataGidViewColumnCollectionController Class

    /// <summary>
    /// TreeNodes the relations between a webgui component and a winforms component
    /// </summary>
    
	public class DataGidViewColumnCollectionController : ComponentCollectionController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public DataGidViewColumnCollectionController(IContext objContext, object objWebDataGridView, IList objWebColumns, object objWinDataGridView, IList objWinColumns)
            : base(objContext, objWebDataGridView, objWebColumns, objWinDataGridView, objWinColumns)
        {
        }


        #endregion C'Tor/D'Tor

        #region Methods

#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.DataGridViewColumn();
        }
#endif
        /// <summary>
        ///
        /// </summary>
        protected override void InitializeWinObjects()
        {
            base.InitializeWinObjects();
        }


        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.DataGridViewColumnCollection WebDataGridViewColumnCollection
        {
            get
            {
                return base.WebObjects as WebForms.DataGridViewColumnCollection;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WebForms.DataGridView WebDataGridView
        {
            get
            {
                return base.SourceObject as WebForms.DataGridView;
            }
        }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        /// <summary>
        ///
        /// </summary>
        public WinForms.DataGridViewColumnCollection WinDataGridViewColumnCollection
        {
            get
            {
                return base.WinObjects as WinForms.DataGridViewColumnCollection;
            }
        }
#endif

        /// <summary>
        ///
        /// </summary>
        public WinForms.DataGridView WinDataGridView
        {
            get
            {
                return base.TargetObject as WinForms.DataGridView;
            }
        }


        #endregion Properties

    }

    #endregion DataGidViewColumnCollectionController Class
}
