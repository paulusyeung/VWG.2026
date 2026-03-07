using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    [Serializable]
    internal class DockedTabControlDescriptor : DockedObjectDescriptor
    {
		#region Fields (2) 

        private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjPlaceHoldersIndexByWindowName;
        private Dictionary<DockedWindowDescriptor, bool> mobjWindowDescriptionsIndicator;
        private int mintSelectedIndex;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedTabControlDescriptor"/> class.
        /// </summary>
        /// <param name="objDockedTabControlDescriptor">The obj docked tab control descriptor.</param>
        public DockedTabControlDescriptor(DockedTabControlDescriptor objDockedTabControlDescriptor)
            : this()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedTabControlDescriptor"/> class.
        /// </summary>
        public DockedTabControlDescriptor()
        {
            mobjWindowDescriptionsIndicator = new Dictionary<DockedWindowDescriptor, bool>();
            mobjPlaceHoldersIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
        }

		#endregion Constructors 

		#region Properties (1) 

        /// <summary>
        /// Gets the sorted window descriptions indicator.
        /// </summary>
        internal Dictionary<DockedWindowDescriptor, bool> WindowDescriptionsIndicator
        {
            get { return mobjWindowDescriptionsIndicator; }
        }

        /// <summary>
        /// Gets the index of the selected.
        /// </summary>
        /// <value>
        /// The index of the selected.
        /// </value>
        internal int SelectedIndex
        {
            get { return mintSelectedIndex; }
        }

		#endregion Properties 

		#region Methods (4) 

		// Internal Methods (4) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal override bool CanUpdateFrom(Type objType)
        {
            if (objType == typeof(Zone))
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
            return new DockedTabControlDescriptor(this) as T;
        }

        /// <summary>
        /// Removes the window.
        /// </summary>
        /// <param name="objWindowDescriptor">The obj window descriptor.</param>
        internal void RemoveWindow(DockedWindowDescriptor objWindowDescriptor)
        {
            // Remove from internal Description indicators
            mobjWindowDescriptionsIndicator.Remove(objWindowDescriptor);

            DockedWindowPlaceHolderDescriptor objPlaceHolder;

            // Check if a place holder is present
            if (mobjPlaceHoldersIndexByWindowName.TryGetValue(objWindowDescriptor.WindowName, out objPlaceHolder))
            {
                mobjPlaceHoldersIndexByWindowName.Remove(objWindowDescriptor.WindowName);
                Manager.UnregisterPlaceHolder(objPlaceHolder);
            }

            // Check if this tab control still contains any windows
            if (this.ParentDescriptor != null && this.mobjWindowDescriptionsIndicator.Count == 0 && mobjPlaceHoldersIndexByWindowName.Count == 0)
            {
                ZoneDescriptor objZoneDescriptor = this.ParentDescriptor as ZoneDescriptor;

                if (objZoneDescriptor != null)
                {
                    // Alert the parent zone that this tab control has zero windows
                    objZoneDescriptor.NotifyTabHasNoWindows(this);
                }
            }
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objManager"></param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        {
            DockedTabControl objDockedTabControl = objControl as DockedTabControl;

            Dictionary<DockedWindowDescriptor, bool> objWindowDescriptionsIndicator = new Dictionary<DockedWindowDescriptor, bool>();
            ZoneType enmOwningZoneType = objDockedTabControl.OwningZone.ZoneType;
            // Go through all tab pages
            foreach (DockedTabPage objTabPage in objDockedTabControl.Controls)
            {
                // Get the contained window descriptor
                DockedWindowDescriptor objWindowDescriptor = objTabPage.Window.DockedWindowDescriptorInternal;

                // Add window to the list
                objWindowDescriptionsIndicator.Add(objWindowDescriptor, true);

                // Register a place holder for this window
                if (enmOwningZoneType != ZoneType.Root && enmOwningZoneType != ZoneType.Hidden && !mobjPlaceHoldersIndexByWindowName.ContainsKey(objWindowDescriptor.WindowName))
                {
                    mobjPlaceHoldersIndexByWindowName.Add(objWindowDescriptor.WindowName, objManager.RegisterPlaceHolder(enmOwningZoneType, objWindowDescriptor));
                }
            }

            // When we're in load mode, there's no need to update the selected index because it might change when loading
            if (!this.IsInLoadMode)
            {
                this.mintSelectedIndex = objDockedTabControl.SelectedIndex;
            }

            this.mobjWindowDescriptionsIndicator = objWindowDescriptionsIndicator;
        }

		#endregion Methods 
    }
}
