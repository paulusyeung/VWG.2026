/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A TabControl control
    /// </summary>
    [Skin(typeof(DockedTabControlSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    public class DockedTabControl : TabControl, IDescriptable, IPreventExtraction
    {
		#region Fields (5)  

        private bool mblnPreventExtraction;
        private DockedTabControlDescriptor mobjData;
        private DockingManager mobjManager;
        private Zone mobjOwningZone; 
        private Dictionary<DockingWindowName, DockedTabPage> mobjTabPagesIndexByTheirContainedDockedWindowName;

		#endregion Fields  

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedTabControl"/> class.
        /// </summary>
        /// <param name="mobjManager">The mobj manager.</param>
        public DockedTabControl(DockingManager mobjManager)
        {
            this.Visible = false;
            this.CustomStyle = "DockedTabContolSkin";
            this.SelectOnRightClick = true;
            this.mobjTabPagesIndexByTheirContainedDockedWindowName = new Dictionary<DockingWindowName, DockedTabPage>(DockingWindowName.DockedWindowNameEqulityComparer);
            this.mobjData = new DockedTabControlDescriptor();
            this.mobjManager = mobjManager;
        }

		#endregion Constructors 

		#region Properties (5) 

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
        /// </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                // Check that there's a parent zone and a manager
                if (this.OwningZone != null && this.OwningZone.Manager != null && this.Controls.Count > 0)
                {
                    return this.OwningZone.Manager.GetDockedContextMenuStrip(this.OwningZone);
                }

                return base.ContextMenuStrip;
            }
            set
            { }
        }

        /// <summary>
        /// Gets the docked tab control descriptor internal.
        /// </summary>
        internal DockedTabControlDescriptor DockedTabControlDescriptorInternal
        {
            get
            {
                return mobjData;
            }
        }

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get { return this.mobjData; }
        }

        /// <summary>
        /// Gets the owning zone.
        /// </summary>
        internal Zone OwningZone
        {
            get { return mobjOwningZone; }
            set { mobjOwningZone = value; }
        }

        /// <summary>
        /// Gets the windows.
        /// </summary>
        public List<DockingWindow> Windows
        {
            get
            {
                List<DockingWindow> objWindows = new List<DockingWindow>();

                // Iterate through all tab pages and add the windows to the list
                foreach (DockedTabPage objPage in this.TabPages)
                {
                    objWindows.Add(objPage.Window);
                }

                return objWindows;
            }
        }

		#endregion Properties 

		#region Methods (11) 

        /// <summary>
        /// Determines whether [is window selected] [the specified docked window].
        /// </summary>
        /// <param name="dockedWindow">The docked window.</param>
        /// <returns>
        ///   <c>true</c> if [is window selected] [the specified docked window]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsWindowSelected(DockingWindow dockedWindow)
        {
            DockedTabPage objPage;

            if (mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(dockedWindow.WindowName, out objPage))
            {
                return objPage.TabIndex == this.SelectedIndex;
            }

            return false;
        }

        /// <summary>
        /// Sets the state of the window selected.
        /// </summary>
        /// <param name="objDockedWindow">The docked window.</param>
        /// <param name="blnSelect">if set to <c>true</c> [value].</param>
        internal void SetWindowSelectedState(DockingWindow objDockedWindow, bool blnSelect)
        {
            DockedTabPage objPage;

            if (mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(objDockedWindow.WindowName, out objPage))
            {
                if (blnSelect)
                {
                    this.SelectedIndex = objPage.TabIndex;
                }
                else
                {
                    if (this.Controls.Count > 1)
                    {
                        if (objPage.TabIndex == 0)
                        {
                            this.SelectedIndex = 1;
                        }
                        else
                        {
                            this.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

		// Protected Methods (3) 

        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is DockedTabPage)
            {
                base.OnControlAdded(e);

                // Get the page
                DockedTabPage objPage = (e.Control as DockedTabPage);

                // Update the contained window descriptor
                (objPage.Window as IDescriptable).Descriptor.UpdateFrom(this, this.mblnPreventExtraction);

                // Set the owning tab control
                objPage.Window.OwningTabControl = this;

                this.Visible = true;

                // Update the tab control's descriptor
                (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control is DockedTabPage)
            {
                base.OnControlRemoved(e);

                DockedTabPage objPage = (e.Control as DockedTabPage);

                HandleWindowRemoved(objPage.Window);

                // Remove the referance from the removed window
                objPage.Window.OwningTabControl = null;

                (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);

                // If this tab control has no windows, remove it
                if (this.Controls.Count == 0)
                {
                    this.Visible = false;

                    if (!mblnPreventExtraction)
                    {
                        this.Parent.Controls.Remove(this);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Handles the window removed.
        /// </summary>
        /// <param name="objDockedWindow">The docked window.</param>
        private void HandleWindowRemoved(DockingWindow objDockedWindow)
        {
            if (this.mobjManager != null)
            {
                this.mobjManager.DockedWindows.RemoveWindow(objDockedWindow);
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (this.OwningZone != null)
            {
                // Tell the zone that the tab index was changed
                this.OwningZone.NotifyTabIndexChanged();

                (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
                
            }
        }
		// Private Methods (3) 

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            this.mobjData = objDescriptor as DockedTabControlDescriptor;
        }

        /// <summary>
        /// Resets the descriptors tree.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <param name="objDockingPosition">The obj docking position.</param>
        void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
        {
            (this as IPreventExtraction).DisableExtraction(true);

            // Get contained windows
            List<DockingWindow> objWindows = this.Windows;

            // Remove all windows from the tab control in order to re-add them later
            foreach (DockingWindow objWindow in objWindows)
            {
                this.RemoveWindow(objWindow);
            }

            // Create a new Descriptor referance
            this.mobjData = this.mobjData.CloneWithoutReferences<DockedTabControlDescriptor>();

            (this as IPreventExtraction).DisableExtraction(false);
        }

        /// <summary>
        /// Disables the extraction.
        /// </summary>
        /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
        void IPreventExtraction.DisableExtraction(bool blnDisable)
        {
            mblnPreventExtraction = blnDisable;
        }
		// Internal Methods (5) 

        /// <summary>
        /// Adds the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void AddWindow(DockingWindow objWindow)
        {
            if (!this.mobjTabPagesIndexByTheirContainedDockedWindowName.ContainsKey(objWindow.WindowName))
            {
                DockState enmWindowsDockState = DockingManager.GetDockStateAccordingToZoneType(this.OwningZone.ZoneType);

                // Set the window's state according to the zone's type
                objWindow.CurrentDockState = enmWindowsDockState;

                // Create a new tab page 
                DockedTabPage objNewPage = new DockedTabPage(objWindow);

                // Add the page
                this.Controls.Add(objNewPage);

                // If this is the first inserted window, manually invoke the tab index changed to set the correct header on the zone
                if (this.Controls.Count == 1)
                {
                    this.OwningZone.NotifyTabIndexChanged();
                }

                if (!this.mobjManager.IsInLoadMode || this.Controls.Count == this.mobjData.SelectedIndex + 1)
                {
                    // Set the newly added page as the selected tab
                    this.SelectedTab = objNewPage;
                }

                // Add a mapping for the page indexed by window name
                this.mobjTabPagesIndexByTheirContainedDockedWindowName.Add(objWindow.WindowName, objNewPage);


                // Register the window in the manager
                this.mobjManager.AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow);
            }
        }

        /// <summary>
        /// Removes the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void RemoveWindow(DockingWindow objWindow)
        {
            RemoveWindow(objWindow.WindowName);
        }

        /// <summary>
        /// Removes the window.
        /// </summary>
        /// <param name="strWindowName">Name of the STR window.</param>
        internal void RemoveWindow(DockingWindowName strWindowName)
        {
            DockedTabPage objPage;
            // Check if this window is contained in contained in this tab control
            if (this.mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(strWindowName, out objPage))
            {
                // Remove this window from the list of the ZoneType in the DockingManager's Descriptor
                this.mobjManager.RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(objPage.Window, this.OwningZone.ZoneType);

                // Remove this window from the tab's inner list
                this.mobjTabPagesIndexByTheirContainedDockedWindowName.Remove(strWindowName);

                // Remove everything from the page (And let the OnControlRemoved logic continue the removing logic)
                objPage.Controls.Clear();
            }
            else
            {
                if (!mblnPreventExtraction)
                {
                    throw new Exception("This zone does not contain the given window");
                }
            }
        }

        /// <summary>
        /// Windows the image changed.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        internal void WindowImageChanged(DockingWindow objDockedWindow)
        {
            this.mobjTabPagesIndexByTheirContainedDockedWindowName[objDockedWindow.WindowName].Image = objDockedWindow.Image;
        }

		#endregion Methods 
    }
}

  