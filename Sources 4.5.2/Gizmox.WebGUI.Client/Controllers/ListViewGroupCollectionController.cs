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
    #region ListViewGroupCollectionController Class

    /// <summary>
    /// TreeNodes the relations between a webgui component and a winforms component
    /// </summary>

    public class ListViewGroupCollectionController : ObjectCollectionController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public ListViewGroupCollectionController(IContext objContext, object objWebListView, IList objWebGroups, object objWinListView, IList objWinGroups)
            : base(objContext, objWebListView, objWebGroups, objWinListView, objWinGroups)
        {

        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
        {
            return new ListViewGroupController(Context, objWebObject);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ListViewGroup();
        }

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
        public WebForms.ListViewGroupCollection WebListViewGroups
        {
            get
            {
                return base.WebObjects as WebForms.ListViewGroupCollection;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WebForms.ListView WebListView
        {
            get
            {
                return base.SourceObject as WebForms.ListView;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ListViewGroupCollection WinListViewGroups
        {
            get
            {
                return base.WinObjects as WinForms.ListViewGroupCollection;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ListView WinListView
        {
            get
            {
                return base.TargetObject as WinForms.ListView;
            }
        }

        #endregion Properties

    }

    #endregion ListViewGroupCollectionController Class
}