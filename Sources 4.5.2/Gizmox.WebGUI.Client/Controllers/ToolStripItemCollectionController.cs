#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region ToolStripItemCollectionController Class

    /// <summary>
    /// TreeNodes the relations between a webgui component and a winforms component
    /// </summary>

    public class ToolStripItemCollectionController : ComponentCollectionController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemCollectionController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStrip">The obj web tool strip.</param>
        /// <param name="objWebObjects">The obj web tool strip items.</param>
        /// <param name="objWinObject">The obj win tool strip.</param>
        /// <param name="objWinObjectItems">The obj win tool strip items.</param>
        public ToolStripItemCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjectItems) : base(objContext, objWebObject, objWebObjects, objWinObject, objWinObjectItems)
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
            if (objWebObject is WebForms.ToolStripButton)
            {
                return new ToolStripButtonController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripSplitButton)
            {
                return new ToolStripSplitButtonController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripDropDownButton)
            {
                return new ToolStripDropDownButtonController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripLabel)
            {
                return new ToolStripLabelController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripComboBox)
            {
                return new ToolStripComboBoxController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripProgressBar)
            {
                return new ToolStripProgressBarController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripTextBox)
            {
                return new ToolStripTextBoxController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripStatusLabel)
            {
                return new ToolStripStatusLabelController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripMenuItem)
            {
                return new ToolStripMenuItemController(this.Context, objWebObject);
            }
            if (objWebObject is WebForms.ToolStripSeparator)
            {
                return new ToolStripSeparatorController(this.Context, objWebObject);
            }

            return new ToolStripItemController(this.Context, objWebObject);
        }

        /// <summary>
        /// Create item object controller
        /// </summary>
        /// <param name="objTargetObject"></param>
        /// <returns></returns>
        protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
        {
            if (objTargetObject is WinForms.ToolStripButton)
            {
                return new ToolStripButtonController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripSplitButton)
            {
                return new ToolStripSplitButtonController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripDropDownButton)
            {
                return new ToolStripDropDownButtonController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripLabel)
            {
                return new ToolStripLabelController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripComboBox)
            {
                return new ToolStripComboBoxController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripProgressBar)
            {
                return new ToolStripProgressBarController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripTextBox)
            {
                return new ToolStripTextBoxController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripStatusLabel)
            {
                return new ToolStripStatusLabelController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripMenuItem)
            {
                return new ToolStripMenuItemController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripSeparator)
            {
                return new ToolStripSeparatorController(this.Context, objTargetObject);
            }
            if (objTargetObject is WinForms.ToolStripControlHost)
            {
                return null;
            }
            if (objTargetObject is WinForms.ToolStripDropDownItem)
            {
                return null;
            }
            if (objTargetObject is WinForms.ToolStripItem)
            {
                return null;
            }

            return base.CreateObjectControlerByTargetObject(objTargetObject);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        protected override object CreateTargetObject(object objWebObject)
        {
            if (objWebObject is WebForms.ToolStripButton)
            {
                return new WinForms.ToolStripButton();
            }
            if (objWebObject is WebForms.ToolStripSplitButton)
            {
                return new WinForms.ToolStripSplitButton();
            }
            if (objWebObject is WebForms.ToolStripDropDownButton)
            {
                return new WinForms.ToolStripDropDownButton();
            }
            if (objWebObject is WebForms.ToolStripLabel)
            {
                return new WinForms.ToolStripLabel();
            }
            if (objWebObject is WebForms.ToolStripComboBox)
            {
                return new WinForms.ToolStripComboBox();
            }
            if (objWebObject is WebForms.ToolStripProgressBar)
            {
                return new WinForms.ToolStripProgressBar();
            }
            if (objWebObject is WebForms.ToolStripTextBox)
            {
                return new WinForms.ToolStripTextBox();
            }
            if (objWebObject is WebForms.ToolStripStatusLabel)
            {
                return new WinForms.ToolStripStatusLabel();
            }
            if (objWebObject is WebForms.ToolStripMenuItem)
            {
                return new WinForms.ToolStripMenuItem();
            }
            if (objWebObject is WebForms.ToolStripControlHost)
            {
                return null;
            }
            if (objWebObject is WebForms.ToolStripDropDownItem)
            {
                return null;
            }
            if (objWebObject is WebForms.ToolStripItem)
            {
                return null;
            }

            return base.CreateTargetObject(objWebObject);
        }



        /// <summary>
        /// Clears all containd win objects
        /// overrides the base function, because while loading the object in designer, 
        /// there are designer object that shouldn't be removed. 
        /// </summary>
        protected override void ClearWinObjects()
        {
            // Remove all controllers
            ClearControllers();

            // If there is a winforms object collection
            if (this.WinObjects != null)
            {
                if (this.DesignMode)
                {
                    this.WinObjectsClear(true);
                }
                else
                {
                    // Clear collection
                    this.WinObjects.Clear();
                }
            }
        }

        /// <summary>
        /// a function that clears the winobjects collection
        /// this overload makes sure the clear will not delete designer controls.
        /// </summary>
        protected internal override void WinObjectsClear()
        {
            this.WinObjectsClear(false);
        }

        /// <summary>
        /// a function that clears the winobjects collection
        /// this overload makes sure the clear will not delete designer controls.
        /// </summary>
        private void WinObjectsClear(bool blnIsInDesignMode)
        {
            // Clear all win objects which are not part of the designer automatic objects.
            ArrayList arrObjectsToRemove = new ArrayList();
            foreach (object objWinObject in this.WinObjects)
            {
                //cheking the object is not a designer object
                if (objWinObject.GetType().Name != "DesignerToolStripControlHost")
                {
                    //additional actions when in design mode.
                    if (blnIsInDesignMode)
                    {
                        // Get component if is one
                        IComponent objWinComponent = objWinObject as IComponent;
                        if (objWinComponent != null)
                        {
                            // Unregister winforms component
                            DesignServices.UnregisterWinComponent(objWinComponent);
                        }
                    }

                    arrObjectsToRemove.Add(objWinObject);
                }
            }

            //removing the items inserted to the array
            foreach (object objWinObject in arrObjectsToRemove)
            {
                this.WinObjects.Remove(objWinObject);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripItemCollection WebToolStripItems
        {
            get
            {
                return base.WebObjects as WebForms.ToolStripItemCollection;
            }
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


        #endregion Properties

    }

    #endregion ToolStripItemCollectionController Class

}
