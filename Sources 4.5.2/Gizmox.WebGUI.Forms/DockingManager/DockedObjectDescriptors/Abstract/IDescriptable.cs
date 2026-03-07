using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    interface IDescriptable
    {
		#region Data Members (1) 

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor Descriptor
        {
            get;
        }

		#endregion Data Members 

		#region Operations (2) 

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void Load(DockedObjectDescriptor objDescriptor);

        /// <summary>
        /// Resets the descriptors tree.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <param name="objDockingPosition">The obj docking position.</param>
        void ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition);

		#endregion Operations 
    }
}
