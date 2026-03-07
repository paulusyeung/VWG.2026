using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class DockedSplitContainerDescriptor : DockedObjectDescriptor
    {
		#region Fields (5) 

        private Orientation menmOrientation;
        private int mintPanelSide;
        private int mintSplitterDistance;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedSplitContainerDescriptor"/> class.
        /// </summary>
        /// <param name="objDockedSplitContainerDescriptor">The obj docked split container descriptor.</param>
        public DockedSplitContainerDescriptor(DockedSplitContainerDescriptor objDockedSplitContainerDescriptor)
            : this()
        {
            this.mintSplitterDistance = objDockedSplitContainerDescriptor.mintSplitterDistance;
            this.menmOrientation = objDockedSplitContainerDescriptor.menmOrientation;
            this.mintPanelSide = objDockedSplitContainerDescriptor.mintPanelSide;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedSplitContainerDescriptor"/> class.
        /// </summary>
        public DockedSplitContainerDescriptor()
        {
            this.mintPanelSide = -1;
        }

		#endregion Constructors 

		#region Properties (5) 

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        public Orientation Orientation
        {
            get { return menmOrientation; }
        }

        /// <summary>
        /// Gets the panel side.
        /// </summary>
        public int PanelSide
        {
            get { return mintPanelSide; }
        }

        /// <summary>
        /// Gets the splitter distance.
        /// </summary>
        public int SplitterDistance
        {
            get { return mintSplitterDistance; }
        }

		#endregion Properties 

		#region Methods (6) 

		// Private Methods (1) 

		// Internal Methods (5) 

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
            return new DockedSplitContainerDescriptor(this) as T;
        }

        /// <summary>
        /// Notifies the zone is empty.
        /// </summary>
        /// <param name="intPanelSide">The int panel side.</param>
        internal void NotifyZoneIsEmpty(int intPanelSide)
        {
            Manager.NotifyZoneEmpty(this, intPanelSide);
        }

        /// <summary>
        /// Updates from docked split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        /// <param name="intPanelSide">The int panel side.</param>
        internal override void UpdateFromDockedSplitContainer(DockedSplitContainer objDockedSplitContainer, int intPanelSide)
        {
            this.mintPanelSide = intPanelSide;
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        {
            DockedSplitContainer objDockedSplitContainer = objControl as DockedSplitContainer;

            // Save other properties
            this.menmOrientation = objDockedSplitContainer.Orientation;
            this.mintSplitterDistance = objDockedSplitContainer.SplitterDistance;
        }

		#endregion Methods 
     }
}
