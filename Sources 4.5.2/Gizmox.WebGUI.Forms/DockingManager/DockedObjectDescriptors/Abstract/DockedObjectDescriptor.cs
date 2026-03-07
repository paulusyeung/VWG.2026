using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Describes a Docked object inside the Docke Manager
    /// </summary>
    [Serializable]
    public abstract class DockedObjectDescriptor
    {
		#region Fields (1) 

        private DockedObjectDescriptor mobjParentDescriptor;

		#endregion Fields 

		#region Properties (2) 

        /// <summary>
        /// Gets the container.
        /// </summary>
        internal DockedObjectDescriptor ParentDescriptor
        {
            get
            {
                return this.mobjParentDescriptor;
            }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public virtual DockingManager Manager 
        {
            get 
            {
                if (ParentDescriptor != null)
                {
                    return ParentDescriptor.Manager;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is in load mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is in load mode; otherwise, <c>false</c>.
        /// </value>
        protected internal bool IsInLoadMode
        {
            get
            {
                return this.Manager != null && this.Manager.IsInLoadMode;
            }
        }

		#endregion Properties 

		#region Methods (12) 

		// Internal Methods (12) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal virtual bool CanUpdateFrom(Type objType)
        {
            return false;
        }

        /// <summary>
        /// Clones the without references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal virtual T CloneWithoutReferences<T>() where T : DockedObjectDescriptor
        {
            return null;
        }

        /// <summary>
        /// Sets the container.
        /// </summary>
        /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
        internal void SetContainer(DockedObjectDescriptor objDockedObjectDescriptor)
        {
            this.mobjParentDescriptor = objDockedObjectDescriptor;
        }

        /// <summary>
        /// Updates from.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objExtraData">The obj extra data.</param>
        internal void UpdateFrom(Control objControl, object objExtraData)
        {
            // Check if this Descriptor can update from the given type
            if (CanUpdateFrom(objControl.GetType()))
            {
                if (objControl is DockedTabControl)
                {
                    UpdateFromTabControl(objControl as DockedTabControl, (bool)objExtraData);
                }
                else if (objControl is DockingManager)
                {
                    UpdateFromDockedManager(objControl as DockingManager);
                }
                else if (objControl is DockedSplitContainer)
                {
                    UpdateFromDockedSplitContainer(objControl as DockedSplitContainer, (int)objExtraData);
                }
                else if (objControl is Zone)
                {
                    UpdateFromZone(objControl as Zone);
                }
                else if (objControl is DockingWindow)
                {
                    UpdateFromDockedWindow(objControl as DockingWindow);
                }
                else if (objControl is DockedForm)
                {
                    UpdateFromDockedForm(objControl as DockedForm);
                }
                else if (objControl is DockedHiddenZonesPanel)
                {
                    UpdateFromDockedHiddenZonesPanel(objControl as DockedHiddenZonesPanel);
                }
                else
                {
                    throw new Exception();
                }

                // The descriptor is always updated from its container
                if (objControl is IDescriptable)
                {
                    SetContainer((objControl as IDescriptable).Descriptor);
                }
                else
                {
                    mobjParentDescriptor = null;
                }
            }
        }

        /// <summary>
        /// Updates from docked form.
        /// </summary>
        /// <param name="dockedForm">The docked form.</param>
        internal virtual void UpdateFromDockedForm(DockedForm dockedForm)
        { }

        /// <summary>
        /// Updates from docked hidden zones panel.
        /// </summary>
        /// <param name="dockedHiddenZonesPanel">The docked hidden zones panel.</param>
        internal virtual void UpdateFromDockedHiddenZonesPanel(DockedHiddenZonesPanel dockedHiddenZonesPanel)
        { }

        /// <summary>
        /// Updates from docked manager.
        /// </summary>
        /// <param name="objDockedManager">The obj docked manager.</param>
        internal virtual void UpdateFromDockedManager(DockingManager objDockedManager)
        { }

        /// <summary>
        /// Updates from docked split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        /// <param name="intPanelSide">The int panel side.</param>
        internal virtual void UpdateFromDockedSplitContainer(DockedSplitContainer objDockedSplitContainer, int intPanelSide)
        { }

        /// <summary>
        /// Updates from docked window.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        internal virtual void UpdateFromDockedWindow(DockingWindow objDockedWindow)
        { }

        /// <summary>
        /// Updates from tab control.
        /// </summary>
        /// <param name="objDockedTabControl">The obj docked tab control.</param>
        /// <param name="blnPreventExtraction">if set to <c>true</c> [BLN prevent extraction].</param>
        internal virtual void UpdateFromTabControl(DockedTabControl objDockedTabControl, bool blnPreventExtraction)
        { }

        /// <summary>
        /// Updates from zone.
        /// </summary>
        /// <param name="zone">The zone.</param>
        internal virtual void UpdateFromZone(Zone zone)
        { }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        internal virtual void UpdateSelf(Control objControl, DockingManager objManager)
        { } 

		#endregion Methods 
    }
}