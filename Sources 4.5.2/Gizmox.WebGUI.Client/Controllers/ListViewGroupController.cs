#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region ListViewGroupController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>

    public class ListViewGroupController : ComponentController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor


        public ListViewGroupController(IContext objContext, object objWebListViewGroup, object objWinListViewGroup)
            : base(objContext, objWebListViewGroup, objWinListViewGroup)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ListViewGroupController(IContext objContext, object objWebObject)
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

        }

        /// <summary>
        ///
        /// </summary>
        protected override void LoadController()
        {
            base.LoadController();
            SetWinListViewGroupHeader();
            SetWinHeaderAlignment();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            SetWinListViewGroupHeader();
            SetWinHeaderAlignment();
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Header":
                    this.SetWinListViewGroupHeader();
                    break;
                case "HeaderAlignment":
                    this.SetWinHeaderAlignment();
                    break;
            }
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Header":
                    this.SetWebListViewGroupHeader();
                    break;
            }
        }

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetWebListViewGroupHeader();
        }

        /// <summary>
        ///
        /// </summary>
        protected override void InitializedContained()
        {
            base.InitializedContained();
        }


        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ListViewGroup();
        }

        #region Set Property

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinListViewGroupHeader()
        {
            this.WinListViewGroup.Header = this.WebListViewGroup.Header;
        }
       
        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebListViewGroupHeader()
        {
            this.WebListViewGroup.Header = this.WinListViewGroup.Header;
        }

        protected virtual void SetWinHeaderAlignment()
        {
            this.WinListViewGroup.HeaderAlignment = (WinForms.HorizontalAlignment)GetConvertedEnum(typeof(WinForms.HorizontalAlignment), this.WebListViewGroup.HeaderAlignment);
        }


        #endregion Set Property

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ListViewGroup WebListViewGroup
        {
            get
            {
                return base.SourceObject as WebForms.ListViewGroup;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ListViewGroup WinListViewGroup
        {
            get
            {
                return base.TargetObject as WinForms.ListViewGroup;
            }
        }

        #endregion Properties

    }

    #endregion ListViewGroupController Class

}