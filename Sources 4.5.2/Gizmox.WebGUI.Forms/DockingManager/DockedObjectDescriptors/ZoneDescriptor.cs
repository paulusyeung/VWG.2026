using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class ZoneDescriptor : DockedObjectDescriptor
    {
		#region Fields (4) 

        private DockStyle menmDockingPosition;
        private int mintPanelSide;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneDescriptor"/> class.
        /// </summary>
        /// <param name="objZoneDescriptor">The obj zone descriptor.</param>
        public ZoneDescriptor(ZoneDescriptor objZoneDescriptor)
            :this()
        {
            this.mintPanelSide = objZoneDescriptor.mintPanelSide;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneDescriptor"/> class.
        /// </summary>
        public ZoneDescriptor()
        {
            this.mintPanelSide = -1;
            this.menmDockingPosition = DockStyle.None;
        }

		#endregion Constructors 

		#region Properties (4) 

        /// <summary>
        /// Gets or sets the docking position.
        /// </summary>
        /// <value>
        /// The docking position.
        /// </value>
        public DockStyle DockingPosition
        {
            get { return menmDockingPosition; }
            set { menmDockingPosition = value; }
        }

        /// <summary>
        /// Gets or sets the panel side.
        /// </summary>
        /// <value>
        /// The panel side.
        /// </value>
        public int PanelSide
        {
            get { return mintPanelSide; }
            set { mintPanelSide = value; }
        }

		#endregion Properties 

		#region Methods (6) 

		// Internal Methods (6) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal override bool CanUpdateFrom(Type objType)
        {
            if (objType == typeof(DockedSplitContainer) || typeof(DockingManager).IsAssignableFrom(objType) || objType == typeof(DockedForm))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clones the without references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal override T CloneWithoutReferences<T>()
        {
            return new ZoneDescriptor(this) as T;
        }

        /// <summary>
        /// Notifies the tab has no windows.
        /// </summary>
        /// <param name="objDockedTabControlDescriptor">The docked tab control descriptor.</param>
        internal void NotifyTabHasNoWindows(DockedTabControlDescriptor objDockedTabControlDescriptor)
        {
            if (this.ParentDescriptor != null)
            {
                DockedSplitContainerDescriptor objDockedSplitContainer = this.ParentDescriptor as DockedSplitContainerDescriptor;

                if (objDockedSplitContainer != null)
                {
                    objDockedSplitContainer.NotifyZoneIsEmpty(this.PanelSide);
                }
            }
        }

        /// <summary>
        /// Updates from docked manager.
        /// </summary>
        /// <param name="objDockedManager">The obj docked manager.</param>
        internal override void UpdateFromDockedManager(DockingManager objDockedManager)
        {
            this.PanelSide = -1;
        }

        /// <summary>
        /// Updates from docked split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        /// <param name="intPanelSide">The int panel side.</param>
        internal override void UpdateFromDockedSplitContainer(DockedSplitContainer objDockedSplitContainer, int intPanelSide)
        {
            this.PanelSide = intPanelSide;
        }

		#endregion Methods
    }
}
