using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DockedHiddenZonePanelDescriptor : DockedObjectDescriptor
    {
		#region Fields (1) 

        private List<List<DockedWindowDescriptor>> mobjWindowDescriptorsGroups;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedHiddenZonePanelDescriptor"/> class.
        /// </summary>
        public DockedHiddenZonePanelDescriptor()
        { }

		#endregion Constructors 

		#region Properties (1) 

        /// <summary>
        /// Gets the window descriptors groups.
        /// </summary>
        internal List<List<DockedWindowDescriptor>> WindowDescriptorsGroups
        {
            get
            {
                return mobjWindowDescriptorsGroups;
            }
        }

		#endregion Properties 

		#region Methods (3) 

		// Internal Methods (3) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal override bool CanUpdateFrom(Type objType)
        {
            if (typeof(DockingManager).IsAssignableFrom(objType))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the and remove windows descriptors groups for load.
        /// </summary>
        /// <returns></returns>
        internal List<List<DockedWindowDescriptor>> RemoveAndReturnWindowsDescriptorsGroupsForLoad()
        {
            List<List<DockedWindowDescriptor>> objWindowDescriptorsGroups = mobjWindowDescriptorsGroups;

            mobjWindowDescriptorsGroups = new List<List<DockedWindowDescriptor>>();

            return objWindowDescriptorsGroups;
        }

        /// <summary>
        /// Updates self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objManager"></param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        {
            DockedHiddenZonesPanel objDockedHiddenZonesPanel = objControl as DockedHiddenZonesPanel;

            if (objDockedHiddenZonesPanel != null)
            {
                mobjWindowDescriptorsGroups = new List<List<DockedWindowDescriptor>>();
                List<DockedWindowDescriptor> objWindowDescriptorsGroup;

                // Iterate through all zone groups
                foreach (List<Zone> objZoneGroup in objDockedHiddenZonesPanel.AllZoneGroups)
                {
                    objWindowDescriptorsGroup = new List<DockedWindowDescriptor>();
                    // Iterate through all zones
                    foreach (Zone objZone in objZoneGroup)
                    {
                        // Add all windows to a list
                        objWindowDescriptorsGroup.Add(objZone.CurrentWindow.DockedWindowDescriptor);
                    }

                    this.mobjWindowDescriptorsGroups.Add(objWindowDescriptorsGroup);
                }
            }
            else
            {
                throw new Exception();
            }
        }

		#endregion Methods 
    }
}