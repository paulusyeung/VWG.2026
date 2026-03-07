using System;
using System.Collections.Generic;
using System.Text;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Client.Controllers
{
    public class DomainUpDownController : UpDownBaseController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DomainUpDownController(IContext objContext, object objWebUpDown)
            : base(objContext, objWebUpDown)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DomainUpDownController(IContext objContext, object objWebUpDown, object objWinUpDown)
            : base(objContext, objWebUpDown, objWinUpDown)
        {
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinDomainUpDownSorted();
            SetWinDomainUpDownWrap();
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Sorted":
                    SetWinDomainUpDownSorted();
                    break;
                case "Wrap":
                    SetWinDomainUpDownWrap();
                    break;
            }
        }

        protected override object CreateTargetObject(object objWebObject)
        {
            return new Forms.ClientDomainUpDown();
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinDomainUpDownSorted()
        {
            WinDomainUpDown.Sorted = WebDomainUpDown.Sorted;
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinDomainUpDownWrap()
        {
            WinDomainUpDown.Wrap = WebDomainUpDown.Wrap;
        }

        #endregion C'Tor/D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.DomainUpDown WebDomainUpDown
        {
            get
            {
                return base.SourceObject as WebForms.DomainUpDown;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.DomainUpDown WinDomainUpDown
        {
            get
            {
                return base.TargetObject as WinForms.DomainUpDown;
            }
        }


        #endregion Properties
    }
}
