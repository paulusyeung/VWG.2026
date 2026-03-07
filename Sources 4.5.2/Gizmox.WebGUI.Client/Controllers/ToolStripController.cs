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
    public class ToolStripController : ScrollableControlController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStrip">The web tool strip.</param>
        /// <param name="objWinToolStrip">The win tool strip.</param>
		public ToolStripController(IContext objContext,object objWebToolStrip,object objWinToolStrip) : base(objContext,objWebToolStrip,objWinToolStrip)
		{
            mobjToolStripItemCollectionController = new ToolStripItemCollectionController(Context, this.WebToolStrip, this.WebToolStrip.Items, this.WinToolStrip, this.WinToolStrip.Items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStrip">The web tool strip.</param>
        public ToolStripController(IContext objContext, object objWebToolStrip) : base(objContext, objWebToolStrip)
		{
            mobjToolStripItemCollectionController = new ToolStripItemCollectionController(Context, this.WebToolStrip, this.WebToolStrip.Items, this.WinToolStrip, this.WinToolStrip.Items);
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members

        private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

        #endregion Class Members

        #region Properties

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.ToolStrip();
        }

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStrip WebToolStrip
        {
            get
            {
                return base.SourceObject as WebForms.ToolStrip;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStrip WinToolStrip
        {
            get
            {
                return base.TargetObject as WinForms.ToolStrip;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        protected override void SetWinScrollableControlAutoScroll()
        {
        }

        /// <summary>
        ///
        /// </summary>
        protected override void InitializedContained()
        {
            mobjToolStripItemCollectionController.Initialize();
        }

        /// <summary>
        /// Clears the controller internal collection
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            if (this.mobjToolStripItemCollectionController != null)
            {
                // Clear control controllers
                mobjToolStripItemCollectionController.Clear();
            }
        }

        /// <summary>
        /// Terminates this instance.
        /// </summary>
        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjToolStripItemCollectionController != null)
            {
                mobjToolStripItemCollectionController.Terminate();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Items":
                    this.SetWinToolStripItems();
                    break;
                case "GripStyle":
                    this.SetWinToolStripGripStyle();
                    break;
                case "CanOverflow":
                    SetWinToolStripCanOverflow();
                    break;
                case "ImageScalingSize":
                    SetWinToolStripImageScalingSize();
                    break;
            }
        }

        /// <summary>
        /// Sets the size of the win tool strip image scaling.
        /// </summary>
        private void SetWinToolStripImageScalingSize()
        {
            if (this.WinToolStrip != null && this.WebToolStrip != null)
            {
                this.WinToolStrip.ImageScalingSize = this.WebToolStrip.ImageScalingSize;
            }
        }

        /// <summary>
        /// Sets the win tool strip can overflow.
        /// </summary>
        private void SetWinToolStripCanOverflow()
        {
            if (this.WinToolStrip != null && this.WebToolStrip != null)
            {
                this.WinToolStrip.CanOverflow = this.WebToolStrip.CanOverflow;
            }
        }

        /// <summary>
        /// Sets the win tool strip grip style.
        /// </summary>
        private void SetWinToolStripGripStyle()
        {
            if (this.WinToolStrip != null && this.WebToolStrip != null)
            {
                this.WinToolStrip.GripStyle = (WinForms.ToolStripGripStyle)this.GetConvertedEnum(typeof(WinForms.ToolStripGripStyle), this.WebToolStrip.GripStyle);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Items":
                    this.SetWebToolStripItems();
                    break;
            }
        }

        /// <summary>
        /// Sets the win tool strip items.
        /// </summary>
        private void SetWinToolStripItems()
        {
            mobjToolStripItemCollectionController.SetWinObjectObjects();
        }

        /// <summary>
        /// Sets the web tool strip items.
        /// </summary>
        private void SetWebToolStripItems()
        {
            mobjToolStripItemCollectionController.SetWebObjectObjects();
        }

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinToolStripItems();
            this.SetWinToolStripCanOverflow();
            this.SetWinToolStripImageScalingSize();
        }

        #endregion
    }
}
