using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
	[Serializable]	
    internal class DockedManagerDescriptor : DockedObjectDescriptor
    {
		#region Fields (12) 

        [NonSerialized]
        private DockingManager mobjManager;

        private List<DockedWindowDescriptor> mobjRootZoneWindows;
        private DockedHiddenZonePanelDescriptor mobjBottomHiddenWindowsDescriptor;
        private DockedHiddenZonePanelDescriptor mobjLeftHiddenWindowsDescriptor;
        private DockedHiddenZonePanelDescriptor mobjRightHiddenWindowsDescriptor;
        private DockedHiddenZonePanelDescriptor mobjTopHiddenWindowsDescriptor;

        private List<DockedWindowDescriptor> mobjDockedWindowsDescriptor;
        private List<DockedWindowDescriptor> mobjFloatedWindowsDescriptor;
        private List<DockedWindowDescriptor> mobjHiddenWindowsDescriptor;

        private bool mblnAllowShowDropDownButton;
        private bool mblnAllowTabbedDocuments;
        private bool mblnAllowCloseWindows;
        private bool mblnAllowFloatinWindows;
        private bool mblnAllowShowPinButton;
        private bool mblnShowMinimizeButton;
        private bool mblnShowMaximizeButton;

        private Dictionary<DockingWindowName, DockedFormDescriptor> mobjFormDescriptorIndexByWindowName;
        private ZoneDescriptor mobjRootZoneDescriptor;
        private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForDockedZonesIndexByWindowName;
        private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForFloatZonesIndexByWindowName;

        private int mintPinAnimationSpeed;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedManagerDescriptor"/> class.
        /// </summary>
        internal DockedManagerDescriptor(DockingManager objManager)
        {
            this.mobjManager = objManager;
            this.mobjRootZoneWindows = new List<DockedWindowDescriptor>();
            this.mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();
            this.mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();
            this.mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();
            this.mobjFormDescriptorIndexByWindowName = new Dictionary<DockingWindowName, DockedFormDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
            this.mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
            this.mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
            this.mobjTopHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
            this.mobjRightHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
            this.mobjBottomHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
            this.mobjLeftHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
            this.mblnAllowShowDropDownButton = true;
            this.mblnAllowFloatinWindows = true;
            this.mblnAllowCloseWindows = true;
            this.mblnAllowShowPinButton = true;
            this.mblnShowMinimizeButton = true;
            this.mblnShowMaximizeButton = true;

            this.mintPinAnimationSpeed = (SkinFactory.GetSkin(objManager.HiddenPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration;
        }

		#endregion Constructors 

		#region Properties (12) 

        /// <summary>
        /// Gets or sets the bottom hidden windows descriptor.
        /// </summary>
        /// <value>
        /// The bottom hidden windows descriptor.
        /// </value>
        public DockedHiddenZonePanelDescriptor BottomHiddenWindowsDescriptor
        {
            get { return mobjBottomHiddenWindowsDescriptor; }
            set { mobjBottomHiddenWindowsDescriptor = value; }
        }

        /// <summary>
        /// Gets the docked windows descriptor.
        /// </summary>
        internal List<DockedWindowDescriptor> DockedWindowsDescriptor
        {
            get { return mobjDockedWindowsDescriptor; }
        }

        /// <summary>
        /// Gets or sets the floated windows descriptor.
        /// </summary>
        /// <value>
        /// The floated windows descriptor.
        /// </value>
        public List<DockedWindowDescriptor> FloatedWindowsDescriptor
        {
            get { return mobjFloatedWindowsDescriptor; }
            
        }

        /// <summary>
        /// Gets the hidden windows descriptor.
        /// </summary>
        internal List<DockedWindowDescriptor> HiddenWindowsDescriptor
        {
            get { return mobjHiddenWindowsDescriptor; }
        }

        /// <summary>
        /// Gets or sets the name of the form descriptor index by window.
        /// </summary>
        /// <value>
        /// The name of the form descriptor index by window.
        /// </value>
        internal Dictionary<DockingWindowName, DockedFormDescriptor> FormDescriptorIndexByWindowName
        {
            get { return mobjFormDescriptorIndexByWindowName; }
            set { mobjFormDescriptorIndexByWindowName = value; }
        }

        /// <summary>
        /// Gets or sets the left hidden windows descriptor.
        /// </summary>
        /// <value>
        /// The left hidden windows descriptor.
        /// </value>
        public DockedHiddenZonePanelDescriptor LeftHiddenWindowsDescriptor
        {
            get { return mobjLeftHiddenWindowsDescriptor; }
            set { mobjLeftHiddenWindowsDescriptor = value; }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public override DockingManager Manager
        {
            get
            {
                return this.mobjManager;
            }
        }

        /// <summary>
        /// Gets or sets the right hidden windows descriptor.
        /// </summary>
        /// <value>
        /// The right hidden windows descriptor.
        /// </value>
        public DockedHiddenZonePanelDescriptor RightHiddenWindowsDescriptor
        {
            get { return mobjRightHiddenWindowsDescriptor; }
            set { mobjRightHiddenWindowsDescriptor = value; }
        }

        /// <summary>
        /// Gets or sets the root zone descriptor.
        /// </summary>
        /// <value>
        /// The root zone descriptor.
        /// </value>
        internal ZoneDescriptor RootZoneDescriptor
        {
            get { return mobjRootZoneDescriptor; }
            set { mobjRootZoneDescriptor = value; }
        }

        /// <summary>
        /// Gets or sets the top hidden windows descriptor.
        /// </summary>
        /// <value>
        /// The top hidden windows descriptor.
        /// </value>
        public DockedHiddenZonePanelDescriptor TopHiddenWindowsDescriptor
        {
            get { return mobjTopHiddenWindowsDescriptor; }
            set { mobjTopHiddenWindowsDescriptor = value; }
        }

        /// <summary>
        /// Gets or sets the name of the window place holders for docked zones index by window.
        /// </summary>
        /// <value>
        /// The name of the window place holders for docked zones index by window.
        /// </value>
        internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForDockedZonesIndexByWindowName
        {
            get { return mobjWindowPlaceHoldersForDockedZonesIndexByWindowName; }
            set { mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = value; }
        }

        /// <summary>
        /// Gets or sets the name of the window place holders for float zones index by window.
        /// </summary>
        /// <value>
        /// The name of the window place holders for float zones index by window.
        /// </value>
        internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForFloatZonesIndexByWindowName
        {
            get { return mobjWindowPlaceHoldersForFloatZonesIndexByWindowName; }
            set { mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = value; }
        }

		#endregion Properties 

		#region Methods (6) 

		// Internal Methods (6) 

        /// <summary>
        /// Regisers the window.
        /// </summary>
        /// <param name="objWindowDescriptor">The docked window descriptor.</param>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        internal void RegiserWindow(DockedWindowDescriptor objWindowDescriptor)
        {
            switch (objWindowDescriptor.CurrentDockState)
            {
                case DockState.Float:
                    this.mobjFloatedWindowsDescriptor.Add(objWindowDescriptor);
                    break;
                case DockState.Dock:
                    this.mobjDockedWindowsDescriptor.Add(objWindowDescriptor);
                    break;
                case DockState.Tabbed:
                    this.mobjRootZoneWindows.Add(objWindowDescriptor);
                    break;
                case DockState.Hidden:
                    mobjHiddenWindowsDescriptor.Add(objWindowDescriptor);
                    break;
                case DockState.AutoHide:
                case DockState.Close:
                    break;
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Removes the and return docked windows descriptors.
        /// </summary>
        /// <returns></returns>
        internal List<DockedWindowDescriptor> RemoveAndReturnDockedWindowsDescriptors()
        {
            // Get all docked windows descriptors
            List<DockedWindowDescriptor> objDescriptors = this.mobjDockedWindowsDescriptor;

            // Initialize the member
            mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();

            // Return descriptors
            return objDescriptors;
        }

        /// <summary>
        /// Removes the and return docked windows descriptors.
        /// </summary>
        /// <returns></returns>
        internal List<DockedWindowDescriptor> RemoveAndReturnRootWindows()
        {
            // Get all docked windows descriptors
            List<DockedWindowDescriptor> objDescriptors = this.mobjRootZoneWindows;

            // Initialize the member
            mobjRootZoneWindows = new List<DockedWindowDescriptor>();

            // Return descriptors
            return objDescriptors;
        }

        /// <summary>
        /// Removes the and return float windows descriptors.
        /// </summary>
        /// <returns></returns>
        internal List<DockedWindowDescriptor> RemoveAndReturnFloatWindowsDescriptors()
        {
            // Get all float windows descriptors
            List<DockedWindowDescriptor> objDescriptors = this.mobjFloatedWindowsDescriptor;

            // Initialize the member
            mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();

            // Return descriptors
            return objDescriptors;
        }

        /// <summary>
        /// Removes the and return hidden windows descriptors.
        /// </summary>
        /// <returns></returns>
        internal List<DockedWindowDescriptor> RemoveAndReturnHiddenWindowsDescriptors()
        {
            // Get all float windows descriptors
            List<DockedWindowDescriptor> objDescriptors = this.mobjHiddenWindowsDescriptor;

            // Initialize the member
            mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();

            // Return descriptors
            return objDescriptors;
        }

        /// <summary>
        /// Unregisters the window.
        /// </summary>
        /// <param name="objWindowDescriptor">The docked window descriptor.</param>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        internal void UnregisterWindow(DockedWindowDescriptor objWindowDescriptor)
        {
            switch (objWindowDescriptor.CurrentDockState)
            {
                case DockState.Float:
                    this.mobjFloatedWindowsDescriptor.Remove(objWindowDescriptor);
                    break;
                case DockState.Dock:
                    this.mobjDockedWindowsDescriptor.Remove(objWindowDescriptor);
                    break;
                case DockState.Tabbed:
                    this.mobjRootZoneWindows.Remove(objWindowDescriptor);
                    break;
                case DockState.Hidden:
                    mobjHiddenWindowsDescriptor.Remove(objWindowDescriptor);
                    break;
                case DockState.AutoHide:
                case DockState.Close:
                    break;
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        internal override void UpdateSelf(Control objControl, DockingManager objDockedManager)
        {
            this.mobjManager = objDockedManager;
        }

		#endregion Methods 

        /// <summary>
        /// Gets or sets a value indicating whether [allow floating windows].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow allow floating windows]; otherwise, <c>false</c>.
        /// </value>
        internal bool AllowFloatingWindows
        {
            get { return mblnAllowFloatinWindows; }
            set { mblnAllowFloatinWindows = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow close windows].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow close windows]; otherwise, <c>false</c>.
        /// </value>
        internal bool AllowCloseWindows
        {
            get { return mblnAllowCloseWindows; }
            set { mblnAllowCloseWindows = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow tabbed documents].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow tabbed documents]; otherwise, <c>false</c>.
        /// </value>
        internal bool AllowTabbedDocuments
        {
            get { return mblnAllowTabbedDocuments; }
            set { mblnAllowTabbedDocuments = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow show pin button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow show pin button]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShowPinButton
        {
            get { return mblnAllowShowPinButton; }
            set { mblnAllowShowPinButton = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow show drop down button].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow show drop down button]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShowDropDownButton
        {
            get { return mblnAllowShowDropDownButton; }
            set { mblnAllowShowDropDownButton = value; }
        }

        /// <summary>
        /// Gets or sets the pin animation speed.
        /// </summary>
        /// <value>
        /// The pin animation speed.
        /// </value>
        internal int PinAnimationSpeed
        {
            get { return mintPinAnimationSpeed; }
            set { mintPinAnimationSpeed = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show minimize button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show minimize button]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShowMinimizeButton
        {
            get { return mblnShowMinimizeButton; }
            set { mblnShowMinimizeButton = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show maximize button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show maximize button]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShowMaximizeButton
        {
            get { return mblnShowMaximizeButton; }
            set { mblnShowMaximizeButton = value; }
        }
    }
}
