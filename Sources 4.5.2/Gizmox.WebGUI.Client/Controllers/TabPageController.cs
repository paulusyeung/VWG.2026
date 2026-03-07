#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region TabPageController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
    public class TabPageController : ControlController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public TabPageController(IContext objContext, object objWebTabPage, object objWinTabPage)
            : base(objContext, objWebTabPage, objWinTabPage)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public TabPageController(IContext objContext, object objWebObject)
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

            SetWinTabPageImageIndex();
            SetWinTabPageImageKey();
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.TabPage();
        }

        #region Events

        /// <summary>
        ///
        /// </summary>
        protected override void WireEvents()
        {
            base.WireEvents();
        }

        /// <summary>
        /// Wires required events for controller to work in design time
        /// </summary>
        protected override void WireDesignTimeEvents()
        {
            base.WireDesignTimeEvents();

            this.WinTabPage.SizeChanged += new EventHandler(WinTabPage_SizeChanged);
        }

        /// <summary>
        /// Handles the SizeChanged event of the WinTabPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinTabPage_SizeChanged(object sender, EventArgs e)
        {
            this.SetWebControlSize();
        }

        /// <summary>
        ///
        /// </summary>
        protected override void UnwireEvents()
        {
            base.UnwireEvents();
        }

        /// <summary>
        /// Unwires wired design time events
        /// </summary>
        protected override void UnwireDesignTimeEvents()
        {
            base.UnwireDesignTimeEvents();

            this.WinTabPage.SizeChanged -= new EventHandler(WinTabPage_SizeChanged);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ImageKey":
                    SetWinTabPageImageKey();
                    break;
                case "Image":
                case "ImageIndex":
                    SetWinTabPageImageIndex();
                    break;
            }
        }

        /// <summary>
        /// Sets the win tab page image key.
        /// </summary>
        protected virtual void SetWinTabPageImageKey()
        {
            if (this.WebTabPage.Image != null && this.WinTabPage.Parent != null)
            {
                WinForms.TabControl objTabControl = (WinForms.TabControl)this.WinTabPage.Parent;
                if (objTabControl.ImageList == null)
                {
                    objTabControl.ImageList = new WinForms.ImageList();
                }

                if (this.GetWinImageIndex(objTabControl.ImageList, this.WebTabPage.Image, this.WebTabPage.ImageKey)>-1)
                {
                    this.WinTabPage.ImageKey = this.WebTabPage.ImageKey;
                }
            }
            else if(this.WinTabPage.ImageKey != string.Empty)
            {
                this.WinTabPage.ImageKey = string.Empty;
            }
        }

        /// <summary>
        /// Loads properties after component is assigned to its parent
        /// </summary>
        protected override void LoadController()
        {
            base.LoadController();

            SetWinTabPageImageIndex();
        }

        /// <summary>
        /// Sets the index of the tab page image.
        /// </summary>
        protected virtual void SetWinTabPageImageIndex()
        {
            if (this.WebTabPage.Image != null && this.WinTabPage.Parent != null)
            {
                WinForms.TabControl objTabControl = (WinForms.TabControl)this.WinTabPage.Parent;
                if (objTabControl.ImageList == null)
                {
                    objTabControl.ImageList = new WinForms.ImageList();
                }

                this.WinTabPage.ImageIndex = GetWinImageIndex(objTabControl.ImageList, this.WebTabPage.Image);
                
            }
            else if(this.WinTabPage.ImageIndex !=-1)
            {
                this.WinTabPage.ImageIndex = -1;
            }
        }



        #endregion Events

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.TabPage WebTabPage
        {
            get
            {
                return base.SourceObject as WebForms.TabPage;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.TabPage WinTabPage
        {
            get
            {
                return base.TargetObject as WinForms.TabPage;
            }
        } 

        #endregion
    }

    #endregion TabPageController Class

}
