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
    public class ToolStripDropDownItemController : ToolStripItemController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownItemController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripDropDownItem">The web tool strip item.</param>
        /// <param name="objWinToolStripDropDownItem">The win tool strip item.</param>
		public ToolStripDropDownItemController(IContext objContext,object objWebToolStripDropDownItem,object objWinToolStripDropDownItem) : base(objContext,objWebToolStripDropDownItem,objWinToolStripDropDownItem)
		{
            mobjToolStripItemCollectionController = new ToolStripItemCollectionController(Context, this.WebToolStripDropDownItem, this.WebToolStripDropDownItem.DropDownItems, this.WinToolStripDropDownItem, this.WinToolStripDropDownItem.DropDownItems);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripDropDownItemController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripDropDownItem">The web tool strip.</param>
        public ToolStripDropDownItemController(IContext objContext, object objWebToolStripDropDownItem) : base(objContext, objWebToolStripDropDownItem)
		{
            mobjToolStripItemCollectionController = new ToolStripItemCollectionController(Context, this.WebToolStripDropDownItem, this.WebToolStripDropDownItem.DropDownItems, this.WinToolStripDropDownItem, this.WinToolStripDropDownItem.DropDownItems);
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members

        private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripDropDownItem WebToolStripDropDownItem
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripDropDownItem;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripDropDownItem WinToolStripDropDownItem
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripDropDownItem;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generic create winforms control
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return null;
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
                case "DropDownItems":
                    this.SetWinToolStripDropDownItemDropDownItems();
                    break;
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
                case "DropDownItems":
                    this.SetWebToolStripDropDownItemDropDownItems();
                    break;
            }
        }

        /// <summary>
        /// Sets the win tool strip menu item drop down items.
        /// </summary>
        private void SetWinToolStripDropDownItemDropDownItems()
        {
            mobjToolStripItemCollectionController.SetWinObjectObjects();
        }

        /// <summary>
        /// Sets the web tool strip menu item drop down items.
        /// </summary>
        private void SetWebToolStripDropDownItemDropDownItems()
        {
            mobjToolStripItemCollectionController.SetWebObjectObjects();
        }

        #endregion
    }
}
