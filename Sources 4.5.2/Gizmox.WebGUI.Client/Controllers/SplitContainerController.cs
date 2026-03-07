#region Using

using System;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region SplitContainerController Class

    ///  <summary>
    /// Represents a panel that dynamically lays out its contents in a grid composed of rows and columns.
    ///  </summary>
    
	public class SplitContainerController : ControlController
    {
        #region Class Memebers

        private SplitterPanelController mobjSplitterPanel1Controller = null;
        private SplitterPanelController mobjSplitterPanel2Controller = null;

        #endregion Class Memebers

        #region C'Tors

        public SplitContainerController(IContext objContext, object objSourceObject, object objTargetObject)
            : base(objContext, objSourceObject, objTargetObject)
        {
            mobjSplitterPanel1Controller = new SplitterPanelController(objContext, this.SourceSplitContainer.Panel1, this.TargetSplitContainer.Panel1);
            mobjSplitterPanel2Controller = new SplitterPanelController(objContext, this.SourceSplitContainer.Panel2, this.TargetSplitContainer.Panel2);

        }

        public SplitContainerController(IContext objContext, object objSourceObject)
            : base(objContext, objSourceObject)
        {
            mobjSplitterPanel1Controller = new SplitterPanelController(objContext, this.SourceSplitContainer.Panel1, this.TargetSplitContainer.Panel1);
            mobjSplitterPanel2Controller = new SplitterPanelController(objContext, this.SourceSplitContainer.Panel2, this.TargetSplitContainer.Panel2);
        }

        #endregion C'Tors

        #region Methods

        /// <summary>
        /// Creates the target object.
        /// </summary>
        protected override void InitializedContained()
        {
            base.InitializedContained();

            // Initialize contained objects.
            mobjSplitterPanel1Controller.Initialize();
            mobjSplitterPanel2Controller.Initialize();


        }

        /// <summary>
        /// Creates the target object.
        /// </summary>
        protected override object CreateTargetObject(object objSourceObject)
        {
            ControllerTarget.SplitContainer objSplitContainer =  new ControllerTarget.SplitContainer();
            
            return objSplitContainer;
        }

        internal override void SetWebControlControls()
        {
            // prevent controls managing
        }

        protected override void SetWinControlControls()
        {
            // prevent controls managing
        }

        /// <summary>
        /// </summary>
        protected override void WireEvents()
        {
            base.WireEvents();
        }

        /// <summary>
        /// </summary>
        protected override void UnwireEvents()
        {
            base.UnwireEvents();
        }

        /// <summary>
        /// Initializes this controller.
        /// </summary>
        protected override void InitializeController()
        {
            this.SetTargetSplitContainerFixedPanel();

            base.InitializeController();

            if (this.DesignMode)
            {
                this.RegisterController(mobjSplitterPanel1Controller);
                this.RegisterController(mobjSplitterPanel2Controller);
            }

            //// Intialize target object.
			
            this.SetTargetSplitContainerPanel1Collapsed();
            this.SetTargetSplitContainerPanel1MinSize();
            this.SetTargetSplitContainerPanel2Collapsed();
            this.SetTargetSplitContainerPanel2MinSize();
            this.SetTargetSplitContainerSplitterIncrement();
            this.SetTargetSplitContainerSplitterWidth();

            this.TargetSplitContainer.SuspendLayout();
            this.TargetSplitContainer.Panel1.SuspendLayout();
            this.TargetSplitContainer.Panel2.SuspendLayout();

            this.SetTargetSplitContainerOrientation();
            this.SetTargetSplitContainerSplitterDistance();

            this.TargetSplitContainer.Panel1.ResumeLayout(false);
            this.TargetSplitContainer.Panel2.ResumeLayout(false);
            this.TargetSplitContainer.ResumeLayout(false);
        }

        /// <summary>
        /// Terminates this controller.
        /// </summary>
        public override void Terminate()
        {
            base.Terminate();

            if (mobjSplitterPanel1Controller != null)
            {
                mobjSplitterPanel1Controller.Terminate();
            }
            if (mobjSplitterPanel2Controller != null)
            {
                mobjSplitterPanel2Controller.Terminate();
            }
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "SplitterDistance":
                    SetSourceSplitContainerSplitterDistance();
                    break;
                case "Orientation":
                    SetSourceSplitContainerOrientation();
                    break;
                case "Panel1Collapsed":
                    SetSourceSplitContainerPanel1Collapsed();
                    break;
                case "Panel1MinSize":
                    SetSourceSplitContainerPanel1MinSize();
                    break;
                case "Panel2Collapsed":
                    SetSourceSplitContainerPanel2Collapsed();
                    break;
                case "Panel2MinSize":
                    SetSourceSplitContainerPanel2MinSize();
                    break;
                case "SplitterIncrement":
                    SetSourceSplitContainerSplitterIncrement();
                    break;
                case "SplitterWidth":
                    SetSourceSplitContainerSplitterWidth();
                    break;
                case "FixedPanel":
                    SetSourceSplitContainerFixedPanel();
                    break;
                default:
                    base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "SplitterDistance":
                    SetTargetSplitContainerSplitterDistance();
                    break;
                case "Orientation":
                    SetTargetSplitContainerOrientation();
                    break;
                case "Panel1Collapsed":
                    SetTargetSplitContainerPanel1Collapsed();
                    break;
                case "Panel1MinSize":
                    SetTargetSplitContainerPanel1MinSize();
                    break;
                case "Panel2Collapsed":
                    SetTargetSplitContainerPanel2Collapsed();
                    break;
                case "Panel2MinSize":
                    SetTargetSplitContainerPanel2MinSize();
                    break;
                case "SplitterIncrement":
                    SetTargetSplitContainerSplitterIncrement();
                    break;
                case "SplitterWidth":
                    SetTargetSplitContainerSplitterWidth();
                    break;
                case "FixedPanel":
                    SetTargetSplitContainerFixedPanel();
                    break;
                default:
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        #region Target Methods

        protected virtual void SetTargetSplitContainerSplitterDistance()
        {
            this.TargetSplitContainer.SplitterDistance = this.SourceSplitContainer.SplitterDistance;
        }

        protected virtual void SetTargetSplitContainerOrientation()
        {
            this.TargetSplitContainer.Orientation = (ControllerTarget.Orientation)GetConvertedEnum(typeof(ControllerTarget.Orientation), this.SourceSplitContainer.Orientation);
        }

        protected virtual void SetTargetSplitContainerPanel1Collapsed()
        {
            this.TargetSplitContainer.Panel1Collapsed = this.SourceSplitContainer.Panel1Collapsed;
        }

        protected virtual void SetTargetSplitContainerPanel1MinSize()
        {
            this.TargetSplitContainer.Panel1MinSize = this.SourceSplitContainer.Panel1MinSize;
        }

        protected virtual void SetTargetSplitContainerPanel2Collapsed()
        {
            this.TargetSplitContainer.Panel2Collapsed = this.SourceSplitContainer.Panel2Collapsed;
        }

        protected virtual void SetTargetSplitContainerPanel2MinSize()
        {
            this.TargetSplitContainer.Panel2MinSize = this.SourceSplitContainer.Panel2MinSize;
        }

        protected virtual void SetTargetSplitContainerSplitterIncrement()
        {
            this.TargetSplitContainer.SplitterIncrement = this.SourceSplitContainer.SplitterIncrement;
        }

        protected virtual void SetTargetSplitContainerSplitterWidth()
        {
            this.TargetSplitContainer.SplitterWidth = this.SourceSplitContainer.SplitterWidth;
        }

        protected virtual void SetTargetSplitContainerFixedPanel()
        {
            this.TargetSplitContainer.FixedPanel = (ControllerTarget.FixedPanel)GetConvertedEnum(typeof(ControllerTarget.FixedPanel), this.SourceSplitContainer.FixedPanel);
        }

        #endregion

        #region Source Methods

        private void SetSourceSplitContainerSplitterDistance()
        {
            this.SourceSplitContainer.SplitterDistance = this.TargetSplitContainer.SplitterDistance;           
        }

        protected virtual void SetSourceSplitContainerOrientation()
        {
            this.SourceSplitContainer.Orientation = (ControllerSource.Orientation)GetConvertedEnum(typeof(ControllerSource.Orientation), this.TargetSplitContainer.Orientation);
        }

        protected virtual void SetSourceSplitContainerPanel1Collapsed()
        {
            this.SourceSplitContainer.Panel1Collapsed = this.TargetSplitContainer.Panel1Collapsed;
        }

        protected virtual void SetSourceSplitContainerPanel1MinSize()
        {
            this.SourceSplitContainer.Panel1MinSize = this.TargetSplitContainer.Panel1MinSize;
        }

        protected virtual void SetSourceSplitContainerPanel2Collapsed()
        {
            this.SourceSplitContainer.Panel2Collapsed = this.TargetSplitContainer.Panel2Collapsed;
        }

        protected virtual void SetSourceSplitContainerPanel2MinSize()
        {
            this.SourceSplitContainer.Panel2MinSize = this.TargetSplitContainer.Panel2MinSize;
        }

        protected virtual void SetSourceSplitContainerSplitterIncrement()
        {
            this.SourceSplitContainer.SplitterIncrement = this.TargetSplitContainer.SplitterIncrement;
        }

        protected virtual void SetSourceSplitContainerSplitterWidth()
        {
            this.SourceSplitContainer.SplitterWidth = this.TargetSplitContainer.SplitterWidth;
        }

        protected virtual void SetSourceSplitContainerFixedPanel()
        {
            this.SourceSplitContainer.FixedPanel = (ControllerSource.FixedPanel)GetConvertedEnum(typeof(ControllerSource.FixedPanel), this.TargetSplitContainer.FixedPanel);
        }

        #endregion

        #endregion Methods

        #region Properties

        /// <summary>
        /// Get typed the target object.
        /// </summary>
        public ControllerTarget.SplitContainer TargetSplitContainer
        {
            get
            {
                return this.TargetObject as ControllerTarget.SplitContainer;
            }
        }

        /// <summary>
        /// Get typed the source object.
        /// </summary>
        public ControllerSource.SplitContainer SourceSplitContainer
        {
            get
            {
                return this.SourceObject as ControllerSource.SplitContainer;
            }
        }

        #endregion Properties
    }

    #endregion SplitContainerController Class

}
