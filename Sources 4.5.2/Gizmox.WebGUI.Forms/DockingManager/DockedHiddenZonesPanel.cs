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
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(DockedHiddenZonesPanelSkin))]
    [Serializable()]
    [System.ComponentModel.ToolboxItem(false)]
    internal class DockedHiddenZonesPanel : Panel, IDescriptable
    {
		#region Fields (4) 

        private DockedHiddenZonePanelDescriptor mobjData;
        private DockingManager mobjManager;
        private List<List<Zone>> mobjAllZoneGroups;
        private Dictionary<DockingWindowName, List<Zone>> mobjZonesIndexByWindowName;
        private Dictionary<long, Zone> mobjZonesIndexByZoneID;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedHiddenZonesPanel"/> class.
        /// </summary>
        /// <param name="objManager">The obj manager.</param>
        public DockedHiddenZonesPanel(DockingManager objManager)
        {
            this.mobjData = new DockedHiddenZonePanelDescriptor();
            this.mobjAllZoneGroups = new List<List<Zone>>();
            this.mobjManager = objManager;
            this.mobjZonesIndexByWindowName = new Dictionary<DockingWindowName, List<Zone>>(DockingWindowName.DockedWindowNameEqulityComparer);
            this.mobjZonesIndexByZoneID = new Dictionary<long, Zone>();
            this.Visible = false;
            this.CustomStyle = "DockedHiddenZonesPanelSkin";
        }

		#endregion Constructors 

		#region Properties (4) 

        /// <summary>
        /// Gets the docked hidden panel descriptor.
        /// </summary>
        public DockedHiddenZonePanelDescriptor DockedHiddenPanelDescriptor
        {
            get { return mobjData; }
        }

        /// <summary>
        /// Gets the docked hidden zone panel descriptor.
        /// </summary>
        public DockedHiddenZonePanelDescriptor DockedHiddenZonePanelDescriptor
        {
            get
            {
                return this.mobjData;
            }
        }

        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get { return mobjData; }
        }

        /// <summary>
        /// Gets or sets the name of the zones index by window.
        /// </summary>
        /// <value>
        /// The name of the zones index by window.
        /// </value>
        internal Dictionary<DockingWindowName, List<Zone>> ZonesIndexByWindowName
        {
            get { return mobjZonesIndexByWindowName; }
            set { mobjZonesIndexByWindowName = value; }
        }

		#endregion Properties 

		#region Methods (5) 

		// Private Methods (2) 

        /// <summary>
        /// Invokes the method internal.
        /// </summary>
        /// <param name="strMember">The STR member.</param>
        /// <param name="arrArgs">The arr args.</param>
        internal void InvokeMethodInternal(string strMember, params object[] arrArgs)
        {
            this.InvokeMethod(strMember, arrArgs);
        }

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            this.mobjData = objDescriptor as DockedHiddenZonePanelDescriptor;
        }

        /// <summary>
        /// Resets the descriptors tree.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <param name="objDockingPosition">The obj docking position.</param>
        void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
        {
            throw new NotImplementedException();
        }
		// Internal Methods (3) 

        /// <summary>
        /// Adds the new zones.
        /// </summary>
        /// <param name="objHiddenZones">The obj hidden zones.</param>
        internal void AddNewZones(List<Zone> objHiddenZones)
        {
            foreach (Zone objHiddenZone in objHiddenZones)
            {
                if (objHiddenZone.ZoneType != ZoneType.Hidden)
                {
                    throw new Exception("DockedHiddenZonesPanel.AddNewZones - Cannot accept zone of ZoneType=" + objHiddenZone.ZoneType.ToString());
                }

                // Get referance to the window 
                DockingWindow objWindow = objHiddenZone.CurrentWindow;
                
                // set the hidden zone's containing hidden panel as this
                objHiddenZone.ContainingHiddenPanel = this;

                // Add all zones to the list indexed by its window name
                this.mobjZonesIndexByWindowName.Add(objWindow.WindowName, objHiddenZones);

                // Add the zone to the zones dictionary that is replacement for the Controls collection
                this.mobjZonesIndexByZoneID.Add(objHiddenZone.ID, objHiddenZone);

                // As mobjZonesIndexByZoneID is used as replacement for the Controls collection need to emulate the ParentChanged event by force
                objHiddenZone.InvokeParentChanged();

                // Update hidden zones panel after new zone adding
                this.Visible = true;
                this.mobjManager.UpdateHiddenPanelsDimentions();
                this.Update();
            }

            AllZoneGroups.Add(objHiddenZones);

            // Update the Descriptor
            this.mobjData.UpdateSelf(this, this.mobjManager);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Render zones from zones dictionary that is replacement for the Controls collection.
            foreach (Zone objZone in this.mobjZonesIndexByZoneID.Values)
            {
                this.RenderZoneAttributes(objZone, objWriter);    
            }
        }

        /// <summary>
        /// Renders the zone attributes.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderZoneAttributes(Zone objZone, IResponseWriter objWriter)
        {
            if (objZone != null)
            {
                // Get the current window (which is the only window)
                DockingWindow objWindow = objZone.CurrentWindow;

                if (objWindow != null)
                {
                    // Start ZoneHeader attributes rendering.
                    objWriter.WriteStartElement(WGTags.DockingZoneHeader);

                    // Render id attribute
                    objWriter.WriteAttributeString(WGAttributes.DockingZoneId, objZone.ID.ToString());

                    int intHiddenZoneItemEdgeLength = this.GetHiddenZoneItemQuareEdgeLength(objWindow);

                    objWriter.WriteAttributeString(WGAttributes.Length, intHiddenZoneItemEdgeLength.ToString());

                    // Render text attribute
                    objWriter.WriteAttributeString(WGAttributes.Text, objWindow.Text);

                    // Render image attribute
                    if (objWindow.Image != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Image, objWindow.Image.ToString());
                    }

                    // End ZoneHeader attributes rendering.
                    objWriter.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Gets the length of the hidden zone item quare edge.
        /// </summary>
        /// <param name="strItemText">The string item text.</param>
        /// <returns></returns>
        private int GetHiddenZoneItemQuareEdgeLength(DockingWindow objDockingWindow)
        {
            DockedHiddenZonesPanelSkin objDockedHiddenZonesPanelSkin = this.Skin as DockedHiddenZonesPanelSkin;

            Size objSuggestedSize = CommonUtils.GetStringMeasurements(objDockingWindow.Text, objDockedHiddenZonesPanelSkin.FontData);
            objSuggestedSize.Width += objDockedHiddenZonesPanelSkin.HiddenZoneItemStyleHorizontalPadding;

            if (objDockingWindow.Image != null)
            {
                objSuggestedSize.Width += objDockedHiddenZonesPanelSkin.HiddenZoneItemImageWidth;
                objSuggestedSize.Height = Math.Max(objSuggestedSize.Height, objDockedHiddenZonesPanelSkin.HiddenZoneItemImageWidth);
            }

            return Math.Max(objSuggestedSize.Width, objSuggestedSize.Height);
        }

        /// <summary>
        /// Pins the specified obj docked window.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        /// <returns></returns>
        internal List<DockingWindow> RemoveAndReturnHiddenWindows(DockingWindow objDockedWindow)
        {
            // Get all zones related to this window
            List<Zone> objZonesToPin = mobjZonesIndexByWindowName[objDockedWindow.WindowName];

            this.mobjAllZoneGroups.Remove(objZonesToPin);

            // Create an empty list of windows
            List<DockingWindow> objWindows = new List<DockingWindow>();

            Zone[] objZones = objZonesToPin.ToArray();

            foreach (Zone objZone in objZones)
            {
                // Get the relevant window
                DockingWindow objWindow = objZone.CurrentWindow;

                this.mobjZonesIndexByWindowName.Remove(objWindow.WindowName);

                RemoveSingleZoneFromPanel(objZone);

                // Remove the window inside the zone
                objZone.RemoveWindows(objWindow);

                // Add the removed window to the list
                objWindows.Add(objWindow);
            }

            // Update the Descriptor
            this.mobjData.UpdateSelf(this, this.mobjManager);

            // Return all windows that their zone's were pinned
            return objWindows;
        }

        /// <summary>
        /// Removes a single hidden zone. 
        /// </summary>
        /// <param name="objHiddenZone">The obj hidden zone.</param>
        internal void RemoveHiddenZone(Zone objHiddenZone)
        {
            // Get the window's name
            DockingWindowName objWindowName = objHiddenZone.CurrentWindow.WindowName;

            // Remove the zone associated with it from the list
            mobjZonesIndexByWindowName[objWindowName].Remove(objHiddenZone);

            // remove the window from the list
            this.mobjZonesIndexByWindowName.Remove(objWindowName);

            // Remove window from the zone (the zone will remove itself from its parent automatically because it has no windows)
            objHiddenZone.RemoveWindows(objHiddenZone.CurrentWindow);

            // Update the Descriptor
            this.mobjData.UpdateSelf(this, this.mobjManager);

            RemoveSingleZoneFromPanel(objHiddenZone);
        }

        /// <summary>
        /// Removes the single zone from panel.
        /// </summary>
        /// <param name="objHiddenZone">The obj hidden zone.</param>
        internal void RemoveSingleZoneFromPanel(Zone objHiddenZone)
        {
            this.mobjZonesIndexByZoneID.Remove(objHiddenZone.ID);
            objHiddenZone.ContainingHiddenPanel = null;
            if (this.mobjZonesIndexByZoneID.Count == 0)
            {
                this.Visible = false;
                mobjManager.UpdateHiddenPanelsDimentions();
            }
            this.Update();
            objHiddenZone.InvokeParentChanged();
        }

        /// <summary>
        /// Shows the hidden zone popup form.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        private void ShowHiddenZonePopupForm(Zone objZone)
        {
            if (objZone != null)
            {
                // Initialize hidden zone popup form size an location variables.
                int intZoneHeight = 0;
                int intZoneWidth = 0;
                int intZoneTop = 0;
                int intZoneLeft = 0;

                // Set interim popup form size variables.
                int intHiddenZoneItemExpantionWidth = 0;
                Padding objDockedPanelsPadding = this.mobjManager.DockedPanelsPadding;
                int intWidth = this.mobjManager.Width - objDockedPanelsPadding.Left - objDockedPanelsPadding.Right;
                int intHeight = this.mobjManager.Height - objDockedPanelsPadding.Top - objDockedPanelsPadding.Bottom;

                // Getting the size desired by the DockedWindow (Sometimes, we don't want the default skin value for the poppedup window)
                DockingWindow objContainingDockedWindow = objZone.CurrentWindow;
                Size objDockedWindowHiddenZoneSize = Size.Empty;
                if (objContainingDockedWindow != null)
                {
                    objDockedWindowHiddenZoneSize = objContainingDockedWindow.HiddenZonePopupSize;
                }

                if (objDockedWindowHiddenZoneSize.IsEmpty)
                {
                    // Get HiddenZoneItemExpantionWidth skin value.
                    DockedHiddenZonesPanelSkin objSkin = (SkinFactory.GetSkin(this) as DockedHiddenZonesPanelSkin);
                    if (objSkin != null)
                    {
                        intHiddenZoneItemExpantionWidth = objSkin.HiddenZoneItemExpantionWidth;
                    }
                }
                else
                {
                    // Setting width or height according the docking of the zone.
                    switch (this.Dock)
                    {
                        case DockStyle.Top:
                        case DockStyle.Bottom:
                            intHiddenZoneItemExpantionWidth = objDockedWindowHiddenZoneSize.Height;
                            break;
                        case DockStyle.Left:
                        case DockStyle.Right:
                            intHiddenZoneItemExpantionWidth = objDockedWindowHiddenZoneSize.Width;
                            break;
                    }
                }

                // Get the pop up form dimentions and location according to the panel's docking.
                switch (this.Dock)
                {
                    case DockStyle.Top:
                        intZoneWidth = intWidth;
                        intZoneHeight = intHiddenZoneItemExpantionWidth > intHeight ? intHeight : intHiddenZoneItemExpantionWidth;
                        intZoneTop = objDockedPanelsPadding.Top;
                        intZoneLeft = objDockedPanelsPadding.Left;
                        break;
                    case DockStyle.Bottom:
                        intZoneWidth = intWidth;
                        intZoneHeight = intHiddenZoneItemExpantionWidth > intHeight ? intHeight : intHiddenZoneItemExpantionWidth;
                        intZoneTop = intHeight + objDockedPanelsPadding.Top - intZoneHeight;
                        intZoneLeft = objDockedPanelsPadding.Left;
                        break;
                    case DockStyle.Left:
                        intZoneWidth = intHiddenZoneItemExpantionWidth > intWidth ? intWidth : intHiddenZoneItemExpantionWidth;
                        intZoneHeight = intHeight;
                        intZoneTop = objDockedPanelsPadding.Top;
                        intZoneLeft = objDockedPanelsPadding.Left;
                        break;
                    case DockStyle.Right:
                        intZoneWidth = intHiddenZoneItemExpantionWidth > intWidth ? intWidth : intHiddenZoneItemExpantionWidth;
                        intZoneHeight = intHeight;
                        intZoneTop = objDockedPanelsPadding.Top;
                        intZoneLeft = intWidth + objDockedPanelsPadding.Left - intZoneWidth;
                        break;
                }

                // Initialize hidden zone popup form.
                HiddenZonePopupForm objHiddenZonePopupForm = new HiddenZonePopupForm();
                objHiddenZonePopupForm.Size = new Size(intZoneWidth, intZoneHeight);
                objHiddenZonePopupForm.StartPosition = FormStartPosition.Manual;
                objHiddenZonePopupForm.Top = intZoneTop;
                objHiddenZonePopupForm.Left = intZoneLeft;
                objHiddenZonePopupForm.Load += new EventHandler(HiddenZonePopupForm_Load);
                objHiddenZonePopupForm.Closed += new EventHandler(HiddenZonePopupForm_Closed);
                objHiddenZonePopupForm.ContainedZone = objZone;

                // Preserve hidden zone popup form in its zone.
                objZone.ZonePopupForm = objHiddenZonePopupForm;

                // Add hidden zone to form and show form popup.
                objHiddenZonePopupForm.Controls.Add(objZone);
                objHiddenZonePopupForm.ShowPopup(this.mobjManager, DialogAlignment.Custom);
            }
        }

		#endregion Methods 

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "ShowZonePopUp":
                    long lngZoneID;
                    Zone objZone;

                    if (long.TryParse(objEvent["ZoneId"], out lngZoneID) && this.mobjZonesIndexByZoneID.TryGetValue(lngZoneID, out objZone))
                    {
                        this.ShowHiddenZonePopupForm(objZone);
                    }
                    break;
            }

            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Handles the Load event of the zone pop up form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HiddenZonePopupForm_Load(object sender, EventArgs e)
        {
            // Get form object.
            HiddenZonePopupForm objForm = sender as HiddenZonePopupForm;
            if (objForm != null && objForm.ContainedZone != null)
            {
                this.InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormLoad", this.ID.ToString(), objForm.ContainedZone.ID.ToString());
            }
        }

        /// <summary>
        /// Handles the Closed event of the zone pop up form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HiddenZonePopupForm_Closed(object sender, EventArgs e)
        {
            // Get form object.
            HiddenZonePopupForm objForm = sender as HiddenZonePopupForm;
            if (objForm != null && objForm.ContainedZone != null)
            {
                this.InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormClosed", this.ID.ToString(), objForm.ContainedZone.ID.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the unique zone groups.
        /// </summary>
        /// <value>
        /// The unique zone groups.
        /// </value>
        public List<List<Zone>> AllZoneGroups
        {
            get { return mobjAllZoneGroups; }
            set { mobjAllZoneGroups = value; }
        }
    }
}
