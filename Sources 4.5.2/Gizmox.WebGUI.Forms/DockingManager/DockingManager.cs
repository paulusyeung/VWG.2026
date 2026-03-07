using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [MetadataTag(WGTags.DockManager)]
    [Skin(typeof(DockingManagerSkin))]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(DockingManager), "Professional.DockedManager.DockingManager_45.png")]
#else
    [ToolboxBitmap(typeof(DockingManager), "Professional.DockedManager.DockingManager.bmp")]
#endif
    [Serializable]
    public class DockingManager : ContainerControl, IDescriptable
    {
        #region Static Fields

        internal static readonly SerializableEvent EVENT_TABBEDWINDOWSELECTED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));
        internal static readonly SerializableEvent EVENT_TABBEDWINDOWCLOSED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));
        internal static readonly SerializableEvent EVENT_DOCKINGWINDOWLOADED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));
        internal static readonly SerializableEvent EVENT_WINDOWSSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));

        #endregion Static Fields

        #region Fields (10)

        private List<Zone> mobjAllZones;
        private List<long> mobjLiveFormsIds;
        private DockedManagerDescriptor mobjData;
        private DockedContextMenuStrip mobjDockedContextMenuStrip;
        private Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer> mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor;
        private Zone mobjRootZone = null;
        private DockedHiddenZonesPanel mobjRightPanel;
        private DockedHiddenZonesPanel mobjTopPanel;
        private DockedHiddenZonesPanel mobjBottomPanel; 
        private DockedHiddenZonesPanel mobjLeftPanel;
        private DockedWindowsCollection mobjDockedWindowsCollection;
        private Dictionary<string, long> mobjDockedFormsIdsIndexByDockedFormsUniqueId;
        private bool mblnIsInLoadMode;
        
        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="DockingManager"/> class.
        /// </summary>
        public DockingManager()
        {
            InitializeDockedManager(null);
        }

        #endregion Constructors

        #region Properties (3)

        /// <summary>
        /// Gets a value indicating whether this instance is in load mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is in load mode; otherwise, <c>false</c>.
        /// </value>
        internal bool IsInLoadMode
        {
            get { return mblnIsInLoadMode; }
            private set { mblnIsInLoadMode = value; }
        }

        /// <summary>
        /// Gets or sets the pin animation speed.
        /// </summary>
        /// <value>
        /// The pin animation speed.
        /// </value>
        public int PinAnimationSpeed 
        {
            get
            {
                return this.mobjData.PinAnimationSpeed;
            }
            set
            {
                if (this.mobjData.PinAnimationSpeed != value)
                {
                    this.mobjData.PinAnimationSpeed = value;

                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets the docked windows.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public DockedWindowsCollection DockedWindows
        {
            get { return mobjDockedWindowsCollection; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show close button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool AllowFloatingWindows
        {
            get
            {
                return this.mobjData.AllowFloatingWindows;
            }
            set
            {
                this.mobjData.AllowFloatingWindows = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow tabbed documents].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow tabbed documents]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool AllowTabbedDocuments
        {
            get
            {
                return this.mobjData.AllowTabbedDocuments;
            }
            set
            {
                this.mobjData.AllowTabbedDocuments = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show close button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        [Browsable(false)]
        public bool AllowCloseWindows
        {
            get
            {
                return this.mobjData.AllowCloseWindows;
            }
            set
            {
                if (this.mobjData.AllowCloseWindows != value)
                {
                    this.mobjData.AllowCloseWindows = value;

                    UpdateZonesUI();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show close button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        [Browsable(false)]
        [Obsolete("Use AllowCloseWindows property instead")]
        public bool ShowCloseButton
        {
            get
            {
                return AllowCloseWindows;
            }
            set
            {
                AllowCloseWindows = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show minimize button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show minimize button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool ShowMinimizeButton 
        {
            get 
            {
                return this.mobjData.ShowMinimizeButton;
            }
            set
            {
                if (this.mobjData.ShowMinimizeButton != value)
                {
                    this.mobjData.ShowMinimizeButton = value;

                    InitializeAllLiveFormsUI();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show maximize button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show maximize button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool ShowMaximizeButton
        {
            get
            {
                return this.mobjData.ShowMaximizeButton;
            }
            set
            {
                if (this.mobjData.ShowMaximizeButton != value)
                {
                    this.mobjData.ShowMaximizeButton = value;

                    InitializeAllLiveFormsUI();
                }
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether [show pin button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show pin button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool ShowPinButton
        {
            get
            {
                return this.mobjData.ShowPinButton;
            }
            set
            {
                if (this.mobjData.ShowPinButton != value)
                {
                    this.mobjData.ShowPinButton = value;

                    UpdateZonesUI();
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [show drop down button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show drop down button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool ShowDropDownButton
        {
            get
            {
                return this.mobjData.ShowDropDownButton;
            }
            set
            {
                if (this.mobjData.ShowDropDownButton != value)
                {
                    this.mobjData.ShowDropDownButton = value;
                 
                    UpdateZonesUI();
                }
            }
        }

        /// <summary>
        /// Gets the docked context menu strip.
        /// </summary>
        private DockedContextMenuStrip DockedContextMenuStrip
        {
            get
            {
                // Create the context menu
                if (mobjDockedContextMenuStrip == null)
                {
                    this.mobjDockedContextMenuStrip = new DockedContextMenuStrip(this);
                }

                return mobjDockedContextMenuStrip;
            }
        }

        /// <summary>
        /// Gets the hidden panel.
        /// </summary>
        internal DockedHiddenZonesPanel HiddenPanel
        {
            get 
            {
                if (mobjLeftPanel != null)
                {
                    return mobjLeftPanel;
                }

                return new DockedHiddenZonesPanel(null);
            }
        }

        /// <summary>
        /// Gets the root zone.
        /// </summary>
        internal Zone RootZone
        {
            get
            {
                return mobjRootZone;
            }
            private set
            {
                mobjRootZone = value;
            }
        }

        /// <summary>
        /// Gets the docked panels padding.
        /// </summary>
        /// <value>
        /// The docked panels padding.
        /// </value>
        internal Padding DockedPanelsPadding
        {
            get
            {
                return new Padding(mobjLeftPanel != null && mobjLeftPanel.Visible ? mobjLeftPanel.Width + this.Padding.Left + this.BorderWidth.Left : this.Padding.Left + this.BorderWidth.Left,
                                   mobjTopPanel != null && mobjTopPanel.Visible ? mobjTopPanel.Height + this.Padding.Top + this.BorderWidth.Top : this.Padding.Top + this.BorderWidth.Top,
                                   mobjRightPanel != null && mobjRightPanel.Visible ? mobjRightPanel.Width + this.Padding.Right + this.BorderWidth.Right : this.Padding.Right + this.BorderWidth.Right,
                                   mobjBottomPanel != null && mobjBottomPanel.Visible ? mobjBottomPanel.Height + this.Padding.Bottom + this.BorderWidth.Bottom : this.Padding.Bottom + this.BorderWidth.Bottom);
            }
        }

        /// <summary>
        /// Hides the main content tabs not enabling to switch between open windows/tabs.
        /// </summary>
        [DefaultValue(false)]
        public bool HideRootZoneTabHeaders
        {
            get
            {
                // Checking the root zone exists
                if (this.mobjRootZone != null)
                {
                    return this.mobjRootZone.HideTabs;
                }

                return false;
            }
            set
            {
                // Checking the root zone exists
                if (this.mobjRootZone != null)
                {
                    this.mobjRootZone.HideTabs = value;
                }
            }
        }

        #endregion Properties
        
        #region Events

            /// <summary>
        /// Occurs when [tabbed window closed].
        /// </summary>
        [SRCategory("CatData"), SRDescription("Raised when a tabbed window is closed")]
        public event TabbedWindowClosedEventHandler TabbedWindowClosed
        {
            add
            {
                if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWCLOSED) == 0)
                {
                    this.RootZone.TabControl.ControlRemoved += new ControlEventHandler(TabControl_ControlRemoved);
                }

                this.AddHandler(DockingManager.EVENT_TABBEDWINDOWCLOSED, value);
            }
            remove
            {
                this.RemoveHandler(DockingManager.EVENT_TABBEDWINDOWCLOSED, value);

                if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWCLOSED) == 0)
                {
                    this.RootZone.TabControl.ControlRemoved -= new ControlEventHandler(TabControl_ControlRemoved);
                }
            }
        }

        /// <summary>
        /// Occurs when [docking window loaded].
        /// </summary>
        [SRCategory("CatData"), SRDescription("Raised when a DockingWindow is loaded from the LoadData operation")]
        public event DockingWindowLoadedEventHandler DockingWindowLoaded
        {
            add
            {
                this.AddHandler(DockingManager.EVENT_DOCKINGWINDOWLOADED, value);
            }
            remove
            {
                this.RemoveHandler(DockingManager.EVENT_DOCKINGWINDOWLOADED, value);
            }
        }

        /// <summary>
        /// Occurs when [windows state changed].
        /// </summary>
        [SRCategory("CatData"), SRDescription("Raised when window's state is changed")]
        public event WindowsStateChangedEventHandler WindowsStateChanged
        {
            add
            {
                this.AddHandler(DockingManager.EVENT_WINDOWSSTATECHANGED, value);
            }
            remove
            {
                this.RemoveHandler(DockingManager.EVENT_WINDOWSSTATECHANGED, value);
            }
        }


        /// <summary>
        /// Occurs when [tabbed window selected].
        /// </summary>
        [SRCategory("CatData"), SRDescription("Raised when a tabbed window is selected")]
        public event TabbedWindowSelectedEventHandler TabbedWindowSelected
        {
            add
            {
                if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWSELECTED) == 0)
                {
                    this.RootZone.TabControl.SelectedIndexChanged += new EventHandler(TabControl_SelectedIndexChanged);
                }

                this.AddHandler(DockingManager.EVENT_TABBEDWINDOWSELECTED, value);
            }
            remove
            {
                this.RemoveHandler(DockingManager.EVENT_TABBEDWINDOWSELECTED, value);

                if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWSELECTED) == 0)
                {
                    this.RootZone.TabControl.SelectedIndexChanged -= new EventHandler(TabControl_SelectedIndexChanged);
                }
            }
        }

        #endregion Events

        #region Methods (42)

        /// <summary>
        /// Closes all floating windows.
        /// </summary>
        public void CloseAllFloatingWindows()
        {
            // Get copies for all forms ids
            IEnumerable<long> objFormIdsCopy = CopyCollection<long>(mobjLiveFormsIds);

            foreach (long lgnLiveFormId in objFormIdsCopy)
            {
                // Try getting the live form
                DockedForm objLiveForm = GetFormFromComponentId(lgnLiveFormId);

                if (objLiveForm != null)
                {
                    objLiveForm.Close();
                }
            }
        }

        /// <summary>
        /// Initializes all live forms UI.
        /// </summary>
        private void InitializeAllLiveFormsUI()
        {
            // Go through all form descriptors
            foreach (long lgnLiveFormId in mobjLiveFormsIds)
            {
                // Try getting the live form
                DockedForm objLiveForm = GetFormFromComponentId(lgnLiveFormId);

                InitializeFormUI(objLiveForm);
            }
        }

        /// <summary>
        /// Initializes the form UI.
        /// </summary>
        /// <param name="objLiveForm">The obj live form.</param>
        private void InitializeFormUI(DockedForm objForm)
        {
            objForm.MinimizeBox = this.ShowMinimizeButton;
            objForm.MaximizeBox = this.ShowMaximizeButton;
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderHiddenZoneExpansionSpeed(objWriter, false);
        }

        /// <summary>
        /// Renders the hidden zone expansion speed.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderHiddenZoneExpansionSpeed(IAttributeWriter objWriter, bool blnForceRender)
        {
            int intAnimationSpeed = this.PinAnimationSpeed;

            if (intAnimationSpeed != (SkinFactory.GetSkin(this.mobjRightPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ZoneAnimationSpeed, intAnimationSpeed.ToString());
            }
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderHiddenZoneExpansionSpeed(objWriter, true);
            }
        }

        /// <summary>
        /// Gets the docked context menu strip.
        /// </summary>
        /// <param name="mobjOwningZone">The mobj owning zone.</param>
        /// <returns></returns>
        internal Forms.ContextMenuStrip GetDockedContextMenuStrip(Zone mobjOwningZone)
        {
            return DockedContextMenuStrip.SetZone(mobjOwningZone);
        }

        /// <summary>
        /// Docks the windows in root position.
        /// </summary>
        /// <param name="enmRelation">The enm relation.</param>
        /// <param name="objDockedWindows">The obj docked windows.</param>
        private void DockWindowsInRootPosition(Relation enmRelation, params DockingWindow[] objDockedWindows)
        {
            // Dummy index
            int intIndex;

            // If relation = Inside, put in the tabbed area
            if (enmRelation == Relation.Inside)
            {
                SwitchWindowsDockState(DockState.Tabbed, objDockedWindows);
            }
            else
            {
                // Get the descriptable control from the docked manager
                Control objDescriptableControl = DockedManagerHelper.GetDescriptableControl(this, out intIndex);

                // Create a new zone for the windows 
                Zone objZone = new Zone(this, ZoneType.Dock);

                // Split the root object with the new Zone
                DockedManagerHelper.SplitControl(objDescriptableControl, objZone, enmRelation, this);

                // Add all the windows to the zone
                objZone.AddWindow(Relation.Inside, objDockedWindows);

                // Set the zone's DockingPosition according to the relation
                switch (enmRelation)
                {
                    case Relation.Above:
                        objZone.DockingPosition = DockStyle.Top;
                        break;
                    case Relation.Below:
                        objZone.DockingPosition = DockStyle.Bottom;
                        break;
                    case Relation.ToTheRight:
                        objZone.DockingPosition = DockStyle.Right;
                        break;
                    case Relation.ToTheLeft:
                        objZone.DockingPosition = DockStyle.Left;
                        break;
                    case Relation.Inside:
                    default:
                        throw new Exception();
                }
            }
        }

        /// <summary>
        /// Closes all.
        /// </summary>
        public void CloseAll()
        {
            IEnumerable<DockingWindow> arrCopies = CopyCollection<DockingWindow>(this.DockedWindows.WindowsIndexByWindowName.Values);

            foreach (DockingWindow objWindow in arrCopies)
            {
                objWindow.Close();
            }
        }

        /// <summary>
        /// Shows all.
        /// </summary>
        public void ShowAll()
        {
            IEnumerable<DockingWindow> arrCopies = CopyCollection<DockingWindow>(this.DockedWindows.HiddenWindowsIndexByWindowName.Values);

            foreach (DockingWindow objHiddenWindowData in arrCopies)
            {
                objHiddenWindowData.Show();
            }
        }

        /// <summary>
        /// Copies the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        private IEnumerable<T> CopyCollection<T>(ICollection<T> collection)
        {
            T[] arrCopy = new T[collection.Count];

            collection.CopyTo(arrCopy, 0);

            return arrCopy;
        }

        /// <summary>
        /// Unpins all.
        /// </summary>
        public void UnpinAll()
        {
            List<Zone> objDockedZones = new List<Zone>();
            
            // This operation cannot be in one loop: every toggled zone must die to let a zone of another type to take its place
            foreach (Zone objZone in mobjAllZones)
            {
                if (objZone.ZoneType == ZoneType.Dock)
                {
                    objDockedZones.Add(objZone);
                }
            }

            foreach (Zone objZone in objDockedZones)
            {
                objZone.ToggleAutoHide();
            }
        }

        /// <summary>
        /// Pins all.
        /// </summary>
        public void PinAll()
        {
            IEnumerable<DockingWindow> arrCopies = CopyCollection<DockingWindow>(this.DockedWindows.WindowsIndexByWindowName.Values);

            foreach (DockingWindow objWindow in arrCopies)
            {
                if (objWindow.CurrentDockState == DockState.AutoHide)
                {
                    SwitchWindowsDockState(DockState.Dock, objWindow);
                }
            }
        }

        /// <summary>
        /// Shows the hidden window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void ShowHiddenWindow(DockingWindow objWindow)
        {
            DockingWindow objHiddenWindow;

            if (this.DockedWindows.HiddenWindowsIndexByWindowName.TryGetValue(objWindow.WindowName, out objHiddenWindow))
            {
                RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(objWindow, ZoneType.Hidden);

                AddWindow(objHiddenWindow.LastDockState, DockStyle.Fill, objWindow);
            }
        }

        /// <summary>
        /// Gets the tabbed window selected event count.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private int GetTabbedWindowSelectedEventCount(SerializableEvent objEvent)
        {
            Delegate objTabbedWindowSelectedEventHandler = this.GetHandler(objEvent);

            if (objTabbedWindowSelectedEventHandler != null)
            {
                return objTabbedWindowSelectedEventHandler.GetInvocationList().Length;
            }

            return 0;
        }

        /// <summary>
        /// Handles the ControlRemoved event of the TabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void TabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            OnTabbedWindowClosed((e.Control as DockedTabPage).Window);
        }

        /// <summary>
        /// Called when [tabbed window closed].
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        private void OnTabbedWindowClosed(DockingWindow objDockedWindow)
        {
            TabbedWindowClosedEventHandler objTabbedWindowClosedEventHandler = this.GetHandler(EVENT_TABBEDWINDOWCLOSED) as TabbedWindowClosedEventHandler;
            if (objTabbedWindowClosedEventHandler != null)
            {
                objTabbedWindowClosedEventHandler(this, new TabbedWindowClosedEventArgs(objDockedWindow));
            }
        }

        /// <summary>
        /// Called when [docking window loaded].
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        private void OnDockingWindowLoaded(DockingWindow objDockedWindow)
        {
            DockingWindowLoadedEventHandler objDockingWindowLoadedEventHandler = this.GetHandler(EVENT_DOCKINGWINDOWLOADED) as DockingWindowLoadedEventHandler;
            if (objDockingWindowLoadedEventHandler != null)
            {
                objDockingWindowLoadedEventHandler(this, new DockingWindowLoadedEventArgs(objDockedWindow));
            }
        }

        /// <summary>
        /// Called when [windows state changed].
        /// </summary>
        /// <param name="enmPreviousDockState">State of the enm previous dock.</param>
        /// <param name="enmNewDockState">State of the enm new dock.</param>
        /// <param name="arrChangedWindows">The arr changed windows.</param>
        internal void OnWindowsStateChanged(DockState enmPreviousDockState, DockState enmNewDockState, DockingWindow[] arrChangedWindows)
        {
            WindowsStateChangedEventHandler objWindowsStateChangedEventHandler = this.GetHandler(EVENT_WINDOWSSTATECHANGED) as WindowsStateChangedEventHandler;
            if (objWindowsStateChangedEventHandler != null)
            {
                objWindowsStateChangedEventHandler(this, new WindowsStateChangedEventArgs(enmPreviousDockState, enmNewDockState, arrChangedWindows));
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the TabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DockedTabControl objTabControl = sender as DockedTabControl;
            if (objTabControl != null && objTabControl.SelectedItem != null)
            {
                OnTabbedWindowSelected((objTabControl.SelectedItem as DockedTabPage).Window);
            }
        }

        /// <summary>
        /// Called when [tabbed window selected].
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        private void OnTabbedWindowSelected(DockingWindow objDockedWindow)
        {
            TabbedWindowSelectedEventHandler objTabbedWindowSelectedEventHandler = this.GetHandler(EVENT_TABBEDWINDOWSELECTED) as TabbedWindowSelectedEventHandler;
            if (objTabbedWindowSelectedEventHandler != null)
            {
                objTabbedWindowSelectedEventHandler(this, new TabbedWindowSelectedEventArgs(objDockedWindow));
            }
        }

        /// <summary>
        /// Switches the state of the window dock.
        /// </summary>
        /// <param name="objDesiredDockState">State of the obj desired dock.</param>
        /// <param name="objWindows">The windows.</param>
        internal void SwitchWindowsDockState(DockState objDesiredDockState, params DockingWindow[] objWindows)
        {
            // All windows in the 'DockingWindow[] objWindows' must be from the same Zone!!
            Relation enmRalation = Relation.Inside;

            DockingWindow objFirstWindow = null;

            if (objWindows.Length > 0)
            {
                objFirstWindow = objWindows[0];
            }

            RemovedWindowsData objData = RemoveWindowFromPreviousDockState(objDesiredDockState, objFirstWindow, objWindows);

			// If the windows are switching from Auto Hide to Dock and they have never been docked - Globally dock them
            bool blnIsGloballyDocked = objData.DesiredDockState == DockState.Dock && !objData.HasDockingStateInfo && objData.PreviousDockState == DockState.AutoHide;

            if (blnIsGloballyDocked)
            {
                switch (objData.UnpinPosition)
                {
                    case DockStyle.Top:
                        enmRalation = Relation.Above;
                        break;
                    case DockStyle.Right: 
                        enmRalation = Relation.ToTheRight;
                        break;
                    case DockStyle.Bottom:
                        enmRalation = Relation.Below;
                        break;
                    case DockStyle.Left:
                        enmRalation = Relation.ToTheLeft;
                        break;
                    case DockStyle.None:
                    case DockStyle.Fill:
                    default:
                        throw new Exception("Relation cannot be: " + objData.UnpinPosition.ToString());
                }
            }

            // Add the windows with the new DockState
            this.AddWindow(objData.DesiredDockState, objData.UnpinPosition, blnIsGloballyDocked, enmRalation, objData.Windows);

            // After adding the window, if the previous state was AutoHidden and the desired state is a visible state then make sure that the clicked window is the selected tab
            if (objData.PreviousDockState == DockState.AutoHide && (objData.DesiredDockState == DockState.Dock || objData.DesiredDockState == DockState.Float))
            {
                objFirstWindow.IsSelectedTab = true;
            }

            OnWindowsStateChanged(objData.PreviousDockState, objData.DesiredDockState, objData.Windows);
        }

        /// <summary>
        /// Removes the state of the window from previous dock.
        /// </summary>
        /// <param name="objDesiredDockState">State of the obj desired dock.</param>
        /// <param name="objFirstWindow">The obj first window.</param>
        /// <param name="objWindows">The obj windows.</param>
        /// <param name="enmPosition">The enm position.</param>
        /// <returns></returns>
        private RemovedWindowsData RemoveWindowFromPreviousDockState(DockState objDesiredDockState, DockingWindow objFirstWindow, DockingWindow[] objWindows)
        {
            RemovedWindowsData objData = new RemovedWindowsData();
            objData.DesiredDockState = objDesiredDockState;
            objData.PreviousDockState = objFirstWindow.CurrentDockState;
            objData.HasDockingStateInfo = this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName);
            objData.HasFloatingStateInfo = this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName);
            objData.UnpinPosition = DockStyle.Fill;

            // Check if the window's current state is AutoHide
            if (objFirstWindow.CurrentDockState == DockState.AutoHide)
            {
                // An AutoHidden window must have an owning zone
                if (objFirstWindow.OwningZone == null)
                {
                    throw new Exception("Hidden window must be contained in a Hidden zone");
                }

                // Get the side of the hidden window
                objData.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;

                // For dock of float state, remove all zones in the same 'zone-group'
                if (objDesiredDockState == DockState.Dock || objDesiredDockState == DockState.Float)
                {
                    // For hidden zone, tell the containing hidden panel to remove the windows (this operation handles removing the window from the zone)
                    objWindows = objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveAndReturnHiddenWindows(objFirstWindow).ToArray();
                }
                else
                {
                    // For any other type just remove the single zone containing the window
                    objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveHiddenZone(objFirstWindow.OwningZone);
                }
            }
                // If the window has an owning zone (Float/Dock/Tabbed)
            else if (objFirstWindow.OwningZone != null)
            {
                // Set the zone's position
                objData.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;

                // Tell the zone to remove the given windows
                objFirstWindow.OwningZone.RemoveWindows(objWindows);
            }
            else
            {
                foreach (DockingWindow objWindow in objWindows)
                {
                    this.DockedWindows.RemoveWindow(objWindow);
                }
            }

            objData.Windows = objWindows;

            return objData;
        }

        // Public Methods (7) 

        /// <summary>
        /// Adds the auto hidden windows.
        /// </summary>
        /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
        /// <param name="objWindows">The obj windows.</param>
        public void AddAutoHiddenWindows(DockStyle objZoneDockingPosition, params DockingWindow[] objWindows)
        {
            AddWindow(DockState.AutoHide, objZoneDockingPosition, objWindows);
        }

        /// <summary>
        /// Adds the docked windows.
        /// </summary>
        /// <param name="objWindows">The obj windows.</param>
        public void AddDockedWindows(params DockingWindow[] objWindows)
        {
            AddWindow(DockState.Dock, DockStyle.Fill, objWindows);
        }

        /// <summary>
        /// Adds the docked windows in root position.
        /// </summary>
        /// <param name="enmRelation">The enm relation.</param>
        /// <param name="objWindows">The obj windows.</param>
        public void AddDockedWindowsInRootPosition(Relation enmRelation, params DockingWindow[] objWindows)
        {
            AddWindow(DockState.Dock, DockStyle.Fill, true, enmRelation, objWindows);
        }

        /// <summary>
        /// Adds the float windows.
        /// </summary>
        /// <param name="objWindows">The obj windows.</param>
        public void AddFloatWindows(params DockingWindow[] objWindows)
        {
            AddWindow(DockState.Float, DockStyle.Fill, objWindows);
        }

        /// <summary>
        /// Adds the tabbed windows.
        /// </summary>
        /// <param name="objWindows">The obj windows.</param>
        public void AddTabbedWindows(params DockingWindow[] objWindows)
        {
            AddWindow(DockState.Tabbed, DockStyle.Fill, objWindows);
        }

        /// <summary>
        /// Adds the window.
        /// </summary>
        /// <param name="objDockState">State of the obj dock.</param>
        /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
        /// <param name="objWindows">The obj windows.</param>
        internal void AddWindow(DockState objDockState, DockStyle objZoneDockingPosition, params DockingWindow[] objWindows)
        {
            AddWindow(objDockState, objZoneDockingPosition, false,Relation.Above, objWindows);
        }


        /// <summary>
        /// Adds the window.
        /// </summary>
        /// <param name="objDockState">State of the obj dock.</param>
        /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
        /// <param name="blnIsDockInRootPosition">if set to <c>true</c> [BLN is dock in root position].</param>
        /// <param name="enmDockInRootRelation">The enm dock in root relation.</param>
        /// <param name="objWindows">The obj windows.</param>
        internal void AddWindow(DockState objDockState, DockStyle objZoneDockingPosition, bool blnIsDockInRootPosition, Relation enmDockInRootRelation, params DockingWindow[] objWindows)
        {
            // A window cannot get here if it is still 'attached' to the manager. the window must be removed from the DockingManager's 'DOM' in order to be added.
            switch (objDockState)
            {
                case DockState.Float:
                    foreach (DockingWindow objWindow in objWindows)
                    {
                        this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                        this.DockedWindows.RemoveHiddenWindow(objWindow);
                        objWindow.Manager = this;
                        AddFloatWindow(objWindow);
                    }
                    break;
                case DockState.Dock:
                    if (blnIsDockInRootPosition)
                    {
                        foreach (DockingWindow objWindow in objWindows)
                        {
                            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                            this.DockedWindows.RemoveHiddenWindow(objWindow);
                            objWindow.Manager = this;
                        } 

                        DockWindowsInRootPosition(enmDockInRootRelation, objWindows);
                    }
                    else
                    {
                        foreach (DockingWindow objWindow in objWindows)
                        {
                            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                            this.DockedWindows.RemoveHiddenWindow(objWindow);
                            objWindow.Manager = this;

                            AddDockedWindow(objWindow);
                        }
                    }
                    break;
                case DockState.Tabbed:
                    foreach (DockingWindow objWindow in objWindows)
                    {
                        this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                        this.DockedWindows.RemoveHiddenWindow(objWindow);
                        objWindow.Manager = this;
                        this.RootZone.AddWindow(Relation.Inside, objWindow);
                    }
                    break;
                case DockState.AutoHide:
                    foreach (DockingWindow objWindow in objWindows)
                    {
                        this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                        this.DockedWindows.RemoveHiddenWindow(objWindow);
                        objWindow.Manager = this;
                    }

                    this.AutoHideWindows(objZoneDockingPosition, objWindows);
                    break;
                case DockState.Hidden:
                    foreach (DockingWindow objWindow in objWindows)
                    {
                        this.DockedWindows.AddWindowIfDoesntExist(objWindow);
                        this.DockedWindows.AddHiddenWindow(objWindow);
                        SetWindowDockState(objWindow, DockState.Hidden);
                        AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow);
                    }
                    break;
                case DockState.Close:
                    foreach (DockingWindow objWindow in objWindows)
                    {
                        this.DockedWindows.AddHiddenWindow(objWindow);
                        SetWindowDockState(objWindow, DockState.Close);
                    }
                    break;
                default:
                    throw new NotImplementedException(string.Format("Adding windows of type '{0}' is not supported.", objDockState.ToString()));
            }
        }

        /// <summary>
        /// Sets the state of the window dock.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        /// <param name="enmDockState">State of the dock.</param>
        private void SetWindowDockState(DockingWindow objWindow, DockState enmDockState)
        {
            objWindow.Manager = this;
            objWindow.CurrentDockState = enmDockState;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="objData">The obj data.</param>
        public void LoadData(byte[] objData)
        {
            // Deserialize DockedManagerDescriptor
            MemoryStream objMemoryStream = new MemoryStream();

            try
            {
                objMemoryStream.Write(objData, 0, objData.Length);
                objMemoryStream.Seek(0, 0);
                BinaryFormatter objFormatter = new BinaryFormatter();

                mobjData = (DockedManagerDescriptor)objFormatter.Deserialize(objMemoryStream);
            }
            catch (Exception objException)
            {
                throw objException;
            }
            finally
            {
                objMemoryStream.Close();
            }

            this.IsInLoadMode = true;

            // Reset the docked manager completely
            this.Controls.Clear();

            this.CloseAllFloatingWindows();

            // Initialize the manager from the start
            this.InitializeDockedManager(mobjData);

            // Load root windows
            LoadWindows(mobjData.RemoveAndReturnRootWindows(), DockState.Tabbed, DockStyle.Fill);

            // Load dock windows
            LoadWindows(mobjData.RemoveAndReturnDockedWindowsDescriptors(), DockState.Dock, DockStyle.Fill);

            // Load left hidden windows
            LoadAutoHiddenWindows(mobjData.LeftHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Left);

            // Load top hidden windows
            LoadAutoHiddenWindows(mobjData.TopHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Top);

            // Load right hidden windows
            LoadAutoHiddenWindows(mobjData.RightHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Right);

            // Load bottom hidden windows
            LoadAutoHiddenWindows(mobjData.BottomHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Bottom);

            // Load all hidden windows
            LoadHiddenWindows(mobjData.RemoveAndReturnHiddenWindowsDescriptors());

            // Load float windows
            LoadWindows(mobjData.RemoveAndReturnFloatWindowsDescriptors(), DockState.Float, DockStyle.None);

            this.IsInLoadMode = false;
        }

        /// <summary>
        /// Loads the hidden windows.
        /// </summary>
        /// <param name="objHiddenWindows">The obj hidden windows.</param>
        private void LoadHiddenWindows(List<DockedWindowDescriptor> objHiddenWindows)
        {
            LoadWindows(objHiddenWindows, DockState.Hidden, DockStyle.Fill);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        public byte[] SaveData()
        {
            // Serialize DockedManagerDescriptor
            MemoryStream objMemoryStream = new MemoryStream();
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            objBinaryFormatter.Serialize(objMemoryStream, mobjData);
            objMemoryStream.Close();

            return objMemoryStream.ToArray();
        }
        // Protected Methods (1) 

        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            IDescriptable objDescriptableControl = e.Control as IDescriptable;

            if (objDescriptableControl != null)
            {
                DockingWindow objDockedWindow = (e.Control as DockingWindow);

                // If the control is a Docked Window instance
                if (objDockedWindow != null)
                {
                    this.AddWindow(DockState.Tabbed, DockStyle.Fill, objDockedWindow);
                }

                // Update the descriptor from the docked manager
                objDescriptableControl.Descriptor.UpdateFrom(this, null);
            }
            else
            {
                throw new Exception(this.GetType().Name + ": Supprots only DockingWindow or DockingSplitContaineror RootZone. Added type: " + e.Control.GetType().Name);
            }
        }
        // Private Methods (18) 

        /// <summary>
        /// Adds a window to the docked position.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        private void AddDockedWindow(DockingWindow objWindow)
        {
            DockedWindowPlaceHolderDescriptor objPlaceHolder;
            // Check if this window has a place holder (in other words - Check if this window was already docked somewhere)
            if (this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out objPlaceHolder))
            {
                // Get the descriptors trace for this window from its Docked place holder
                List<DockedObjectDescriptor> objDescriptorsTrace = DockedManagerHelper.GetDescriptorTrace(objPlaceHolder, false);

                // Load the window with its trace
                DockedManagerHelper.LoadWindowFromTrace(this, objWindow, objDescriptorsTrace, this, DockState.Dock);
            }
            else
            {
                // If the window has no trace (i.e. was created directly in float state or auto-hidden state), just add it to the root zone.
                SwitchWindowsDockState(DockState.Tabbed, objWindow);
            }
        }

        /// <summary>
        /// Adds the float window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        private void AddFloatWindow(DockingWindow objWindow)
        {
            List<DockedObjectDescriptor> objDescriptorsTrace = null;
            DockedWindowPlaceHolderDescriptor objPlaceHolder;

            // Check whether this window has a floating place holder.
            if (this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out objPlaceHolder))
            {
                objDescriptorsTrace = DockedManagerHelper.GetDescriptorTrace(objPlaceHolder, false);
            }

            if (objDescriptorsTrace != null)
            {
                // Load the window with its trace
                DockedManagerHelper.LoadWindowFromTrace(this, objWindow, objDescriptorsTrace, this, DockState.Float);
            }
            else
            {
                DockedForm objForm = CreateNewForm(null);
                Zone objZone = new Zone(this, ZoneType.Float);
                objForm.Controls.Add(objZone);
                objZone.AddWindow(Relation.Inside, objWindow);
            }
        }

        /// <summary>
        /// Gets all zones as components list.
        /// </summary>
        /// <returns></returns>
        private Component[] GetAllZonesAsComponentsList(long lngFormId)
        {
            List<Component> objComponenets = new List<Component>();

            foreach (Zone objZone in mobjAllZones)
            {
                if (objZone.OwningFormId != lngFormId)
                {
                    objComponenets.Add(objZone);
                }
            }

            return objComponenets.ToArray();
        }

        /// <summary>
        /// Initializes the componenet.
        /// </summary>
        private void InitializeComponenet(DockedManagerDescriptor objDescriptor)
        {
            this.mobjRootZone = new Zone(this, ZoneType.Root);
            this.mobjTopPanel = new DockedHiddenZonesPanel(this);
            this.mobjRightPanel = new DockedHiddenZonesPanel(this);
            this.mobjBottomPanel = new DockedHiddenZonesPanel(this);
            this.mobjLeftPanel = new DockedHiddenZonesPanel(this);

            //
            // mobjTopPanel
            //
            this.mobjTopPanel.Dock = DockStyle.Top;
            this.mobjTopPanel.BackColor = Color.Transparent;
            //
            // mobjRightPanel
            //
            this.mobjRightPanel.Dock = DockStyle.Right;
            this.mobjRightPanel.BackColor = Color.Transparent;
            //
            // mobjBottomPanel
            //
            this.mobjBottomPanel.Dock = DockStyle.Bottom;
            this.mobjBottomPanel.BackColor = Color.Transparent;
            //
            // mobjLeftPanel
            //
            this.mobjLeftPanel.Dock = DockStyle.Left;
            this.mobjLeftPanel.BackColor = Color.Transparent;
            //
            //mobjRootZone
            //
            this.mobjRootZone.Dock = DockStyle.Fill;
            this.mobjRootZone.DockingPosition = DockStyle.None;

            //
            //this
            //
            if (objDescriptor == null)
            {
                this.Controls.Add(mobjRootZone);
            }
            else
            {
                DockedManagerHelper.EnterRootZone(mobjRootZone, this);
            }

            this.Controls.Add(mobjRightPanel);
            this.Controls.Add(mobjLeftPanel);
            this.Controls.Add(mobjBottomPanel);
            this.Controls.Add(mobjTopPanel);
        }

        /// <summary>
        /// Initializes the descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        private void InitializeDescriptor(DockedManagerDescriptor objDescriptor)
        {
            if (objDescriptor == null)
            {
                mobjData = new DockedManagerDescriptor(this);
            }
            else
            {
                (this as IDescriptable).Load(mobjData);
            }
        }

        /// <summary>
        /// Initializes the docked form.
        /// </summary>
        /// <param name="objDocekdForm">The obj docekd form.</param>
        private void InitializeDockedForm(DockedForm objDocekdForm)
        {
            (objDocekdForm as IDescriptable).Descriptor.UpdateFrom(this, null);

            InitializeFormUI(objDocekdForm);

            objDocekdForm.Load += new EventHandler(objDocekdForm_Load);
            objDocekdForm.FormClosed += new Forms.Form.FormClosedEventHandler(objDocekdForm_FormClosed);
            objDocekdForm.Owner = this.ParentForm;
        }

        /// <summary>
        /// Initializes the docked manager.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        private void InitializeDockedManager(DockedManagerDescriptor objDescriptor)
        {
            mobjAllZones = new List<Zone>();
            mobjDockedWindowsCollection = CreateCollection();
            mobjDockedWindowsCollection.Manager = this;
            InitializeDescriptor(objDescriptor);

            mobjLiveFormsIds = new List<long>();
            mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor = new Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer>();
            mobjDockedFormsIdsIndexByDockedFormsUniqueId = new Dictionary<string, long>();
            InitializeComponenet(objDescriptor);
            InitializeHiddenPanelsAndRootZoneDescriptorsReferences(objDescriptor);
            InitializeVWGSizes();

        }

        /// <summary>
        /// Creates the collection.
        /// </summary>
        /// <returns></returns>
        protected virtual DockedWindowsCollection CreateCollection()
        {
            return new DockedWindowsCollection();
        }

        /// <summary>
        /// Initializes the hidden panels descriptors referances.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        private void InitializeHiddenPanelsAndRootZoneDescriptorsReferences(DockedManagerDescriptor objDescriptor)
        {
            // If the given descriptor exists, load the Hidden panels data from it
            if (objDescriptor != null)
            {
                (this.mobjTopPanel as IDescriptable).Load(objDescriptor.TopHiddenWindowsDescriptor);
                (this.mobjRightPanel as IDescriptable).Load(objDescriptor.RightHiddenWindowsDescriptor);
                (this.mobjLeftPanel as IDescriptable).Load(objDescriptor.LeftHiddenWindowsDescriptor);
                (this.mobjBottomPanel as IDescriptable).Load(objDescriptor.BottomHiddenWindowsDescriptor);
            }
            else
            {
                // Set referance to the hidden panels descriptors to the Docked Manager Descriptor
                this.mobjData.TopHiddenWindowsDescriptor = this.mobjTopPanel.DockedHiddenPanelDescriptor;
                this.mobjData.RightHiddenWindowsDescriptor = this.mobjRightPanel.DockedHiddenPanelDescriptor;
                this.mobjData.LeftHiddenWindowsDescriptor = this.mobjLeftPanel.DockedHiddenPanelDescriptor;
                this.mobjData.BottomHiddenWindowsDescriptor = this.mobjBottomPanel.DockedHiddenPanelDescriptor;
            }

            this.mobjData.RootZoneDescriptor = this.mobjRootZone.ZoneDescriptorInternal;
        }

        /// <summary>
        /// Initializes the VWG sizes.
        /// </summary>
        private void InitializeVWGSizes()
        {
            DockedHiddenZonesPanelSkin objSkin = SkinFactory.GetSkin(mobjTopPanel) as DockedHiddenZonesPanelSkin;

            this.mobjTopPanel.Size = new Size(0, objSkin.PanelThickness);
            this.mobjBottomPanel.Size = new Size(0, objSkin.PanelThickness);
            this.mobjLeftPanel.Size = new Size(objSkin.PanelThickness, 0);
            this.mobjRightPanel.Size = new Size(objSkin.PanelThickness, 0);
        }

        /// <summary>
        /// Loads the hidden windows.
        /// </summary>
        /// <param name="objWindowDescriptorsGroups">The obj window descriptors groups.</param>
        /// <param name="objDockStyle">The obj dock style.</param>
        private void LoadAutoHiddenWindows(List<List<DockedWindowDescriptor>> objWindowDescriptorsGroups, DockStyle objDockStyle)
        {
            if (objWindowDescriptorsGroups != null)
            {
                // Loop on all groups
                foreach (List<DockedWindowDescriptor> objGroup in objWindowDescriptorsGroups)
                {
                    // Load windows
                    LoadWindows(objGroup, DockState.AutoHide, objDockStyle);
                }
            }
        }

        /// <summary>
        /// Loads the windows.
        /// </summary>
        /// <param name="objDockedWindowDescriptors">The docked window descriptors.</param>
        /// <param name="objDockState">The dock state .</param>
        /// <param name="objDockStyle">The dock style.</param>
        private void LoadWindows(List<DockedWindowDescriptor> objDockedWindowDescriptors, DockState objDockState, DockStyle objDockStyle)
        {
            List<DockingWindow> objWindows = new List<DockingWindow>();

            // Loop on all descriptors
            foreach (DockedWindowDescriptor objDockedWindowDescriptor in objDockedWindowDescriptors)
            {
                // Get window type
                Type objType = objDockedWindowDescriptor.WindowType;

                try
                {
                    // Create window
                    DockingWindow objWindow = (DockingWindow)Activator.CreateInstance(objType);

                    // Load window
                    ((IDescriptable)objWindow).Load(objDockedWindowDescriptor);

                    // Raise the window loaded event
                    OnDockingWindowLoaded(objWindow);

                    // Add to windows collection
                    objWindows.Add(objWindow);
                }
                catch { }
            }

            if (objWindows.Count > 0)
            {
                // Add windows to docked manager
                this.AddWindow(objDockState, objDockStyle, objWindows.ToArray());
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the objDocekdForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        void objDocekdForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DockedForm objForm = (sender as DockedForm);

            List<DockingWindow> objAllWindows = objForm.Windows;

            if (objAllWindows != null)
            {
                DockingWindow[] arrWindows = objAllWindows.ToArray();

                foreach (DockingWindow objWindow in arrWindows)
                {
                    objWindow.Close();
                }
            }

            this.mobjLiveFormsIds.Remove(objForm.ID);
        }

        /// <summary>
        /// Handles the Load event of the objDocekdForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void objDocekdForm_Load(object sender, EventArgs e)
        {
            DockedForm objForm = (sender as DockedForm);
            mobjLiveFormsIds.Add(objForm.ID);
            objForm.SetDragTargets(GetAllZonesAsComponentsList(objForm.ID));
        }

        /// <summary>
        /// Refreshes the drag targets.
        /// </summary>
        private void RefreshFormsDragTargets()
        {
            // Go through all form descriptors
            foreach (long lgnLiveFormId in mobjLiveFormsIds)
            {
                // Try getting the live form
                DockedForm objLiveForm = GetFormFromComponentId(lgnLiveFormId);

                if (objLiveForm != null)
                {
                    // Set form's drag targets
                    objLiveForm.SetDragTargets(GetAllZonesAsComponentsList(lgnLiveFormId));
                }
            }
        }

        /// <summary>
        /// Updates the hidden panels dimentions.
        /// </summary>
        internal void UpdateHiddenPanelsDimentions()
        {
            DockedHiddenZonesPanelSkin objSkin = SkinFactory.GetSkin(mobjTopPanel) as DockedHiddenZonesPanelSkin;

            if (mobjRightPanel.Visible == true)
            {
                this.mobjTopPanel.DockPadding.Right = objSkin.PanelThickness;
                this.mobjBottomPanel.DockPadding.Right = objSkin.PanelThickness;
            }
            else
            {
                this.mobjTopPanel.DockPadding.Right = 0;
                this.mobjBottomPanel.DockPadding.Right = 0;
                this.mobjBottomPanel.DockPadding.Left = objSkin.PanelThickness;
            }

            if (mobjLeftPanel.Visible == true)
            {
                this.mobjBottomPanel.DockPadding.Left = objSkin.PanelThickness;
                this.mobjTopPanel.DockPadding.Left = objSkin.PanelThickness;
            }
            else
            {
                this.mobjBottomPanel.DockPadding.Left = 0;
                this.mobjTopPanel.DockPadding.Left = 0;
            }
        }
        // Internal Methods (16) 

        /// <summary>
        /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.Form.Closing += new CancelEventHandler(Form_Closing);
        }

        /// <summary>
        /// Handles the Closing event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        void Form_Closing(object sender, CancelEventArgs e)
        {
            CloseAllFloatingWindows();
        }
        /// <summary>
        /// Creates the new form.
        /// </summary>
        /// <param name="objFormDescriptor">The obj form descriptor.</param>
        /// <returns></returns>
        internal DockedForm CreateNewForm(DockedFormDescriptor objFormDescriptor)
        {
            DockedForm objForm = new DockedForm(this);

            // Initialize the form
            InitializeDockedForm(objForm);

            if (objFormDescriptor != null)
            {
                (objForm as IDescriptable).Load(objFormDescriptor);
            }

            return objForm;
        }

        /// <summary>
        /// Gets the form from component id.
        /// </summary>
        /// <param name="lngFormId">The LNG form id.</param>
        /// <returns></returns>
        internal DockedForm GetFormFromComponentId(long lngFormId)
        {
            return ((ISessionRegistry)this.Context).GetRegisteredComponent(lngFormId) as DockedForm;
        }

        /// <summary>
        /// Gets the form from component id.
        /// </summary>
        /// <param name="strFormId">The STR form id.</param>
        /// <returns></returns>
        internal DockedForm GetFormFromComponentId(string strFormId)
        {
            return GetFormFromComponentId(long.Parse(strFormId));
        }

        /// <summary>
        /// Gets the form from descriptor.
        /// </summary>
        /// <param name="objFormDescriptor">The obj form descriptor.</param>
        /// <returns></returns>
        internal DockedForm GetFormFromDescriptor(DockedFormDescriptor objFormDescriptor)
        {
            DockedForm objForm = null;
            if (objFormDescriptor != null && mobjLiveFormsIds.Contains(objFormDescriptor.OwningFormId))
            {
                objForm = GetFormFromComponentId(objFormDescriptor.OwningFormId);
            }

            if (objForm == null)
            {
                objForm = CreateNewForm(objFormDescriptor);
            }

            return objForm;
        }

        /// <summary>
        /// Handles the window logical location changed.
        /// </summary>
        /// <param name="objWindowDescriptor">The obj window descriptor.</param>
        /// <param name="objDockedTabControl">The obj docked tab control descriptor.</param>
        /// <param name="objZone">The obj zone.</param>
        internal void HandleWindowStateChanged(DockedWindowDescriptor objWindowDescriptor, DockedTabControl objDockedTabControl)
        {
            DockedTabControlDescriptor objDockedTabControlDescriptor = objDockedTabControl.DockedTabControlDescriptorInternal;
            Zone objZone = objDockedTabControl.OwningZone;

            // Determine operation according to the new zone's type
            switch (objZone.ZoneType)
            {
                case ZoneType.Root:
                    // no operation needed for the root zone
                    break;
                case ZoneType.Dock:
                    TryRemoveFromLastDockStatePosition(this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName, objWindowDescriptor, objDockedTabControlDescriptor);
                    break;
                case ZoneType.Float:
                    TryRemoveFromLastDockStatePosition(this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName, objWindowDescriptor, objDockedTabControlDescriptor);
                    break;
                case ZoneType.Hidden:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Tries the remove from last dock state position.
        /// </summary>
        /// <param name="objWindowPalceHoldersByDockState">State of the obj window palce holders by dock.</param>
        /// <param name="objWindowDescriptor">The obj window descriptor.</param>
        /// <param name="objDockedTabControlDescriptor">The obj docked tab control descriptor.</param>
        private void TryRemoveFromLastDockStatePosition(Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> objWindowPalceHoldersByDockState, DockedWindowDescriptor objWindowDescriptor, DockedTabControlDescriptor objDockedTabControlDescriptor)
        {
            DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor;
            // Try getting the window's place holder for the docked position
            if (objWindowPalceHoldersByDockState.TryGetValue(objWindowDescriptor.WindowName, out objDockedWindowPlaceHolderDescriptor))
            {
                // If a place holder exists, it meens that the window was once docked
                DockedTabControlDescriptor objDescriptor = objDockedWindowPlaceHolderDescriptor.ParentDescriptor as DockedTabControlDescriptor;

                if (objDescriptor != null && objDescriptor != objDockedTabControlDescriptor)
                {
                    // If the window was docked elsewhere, HARD-remove it from its previous position
                    objDescriptor.RemoveWindow(objWindowDescriptor);
                }
            }
        }

        /// <summary>
        /// Notifies the zone empty.
        /// </summary>
        /// <param name="objDockedSplitContainerDescriptor">The obj docked split container descriptor.</param>
        /// <param name="intPanelSide">The int panel side.</param>
        internal void NotifyZoneEmpty(DockedSplitContainerDescriptor objDockedSplitContainerDescriptor, int intPanelSide)
        {
            DockedSplitContainer objSplitContainer;

            // Try to the the split container via the given descriptor
            if (mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.TryGetValue(objDockedSplitContainerDescriptor, out objSplitContainer))
            {
                objSplitContainer.HardRemovePanel(intPanelSide);
            }
            else
            {
                throw new Exception(string.Format("mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor does not contain the given split container descriptor"));
            }
        }


        /// <summary>
        /// Registers the place holder.
        /// </summary>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        /// <param name="objWindowDescriptor">The obj window descriptor.</param>
        /// <returns></returns>
        internal DockedWindowPlaceHolderDescriptor RegisterPlaceHolder(ZoneType enmZoneType, DockedWindowDescriptor objWindowDescriptor)
        {
            Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> objPlaceHolderList = null;

            switch (enmZoneType)
            {
                case ZoneType.Dock:
                    objPlaceHolderList = this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName;
                    break;
                case ZoneType.Float:
                    objPlaceHolderList = this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName;
                    break;
                case ZoneType.Root:
                // No need for place holder for hidden zones
                case ZoneType.Hidden:
                    // No need for place holder for hidden zones
                    break;
                default:
                    throw new Exception();
            }

            DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor = null;

            if (objPlaceHolderList != null)
            {
                // Create a place holder
                objDockedWindowPlaceHolderDescriptor = new DockedWindowPlaceHolderDescriptor(objWindowDescriptor, enmZoneType);

                // Check if this window already has a place holder
                if (!objPlaceHolderList.ContainsKey(objWindowDescriptor.WindowName))
                {
                    objPlaceHolderList.Add(objWindowDescriptor.WindowName, objDockedWindowPlaceHolderDescriptor);
                }
                else
                {
                    objPlaceHolderList[objWindowDescriptor.WindowName] = objDockedWindowPlaceHolderDescriptor;
                }
            }

            return objDockedWindowPlaceHolderDescriptor;
        }

        /// <summary>
        /// Registers the split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        internal void RegisterSplitContainer(DockedSplitContainer objDockedSplitContainer)
        {
            DockedSplitContainerDescriptor objDescriptor = objDockedSplitContainer.DockedSplitContainerDescriptorInternal;

            // Map a DockedSplitContainerDescriptor to its DockedSplitContainer object
            if (this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.ContainsKey(objDescriptor))
            {
                mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor[objDescriptor] = objDockedSplitContainer;
            }
            else
            {
                mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Add(objDescriptor, objDockedSplitContainer);
            }
        }

        /// <summary>
        /// Registers the zone.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        internal void RegisterZone(Zone objZone)
        {
            // Add zone to list
            mobjAllZones.Add(objZone);

            // Update Form drag targets
            RefreshFormsDragTargets();
        }

        /// <summary>
        /// Unregisters the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        internal void RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(DockingWindow objWindow, ZoneType enmZoneType)
        {
            this.mobjData.UnregisterWindow(objWindow.DockedWindowDescriptorInternal);
        }
        /// <summary>
        /// Adds the window to correct zone type list in managers descriptor.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        internal void AddWindowToCorrectZoneTypeListInManagersDescriptor(DockingWindow objWindow)
        {
            this.mobjData.RegiserWindow(objWindow.DockedWindowDescriptorInternal);
        }
        /// <summary>
        /// Sets the window form owner.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        /// <param name="objDockedFormDescriptor">The obj docked form descriptor.</param>
        internal void SetWindowFormMapping(DockingWindow objDockedWindow, DockedFormDescriptor objDockedFormDescriptor)
        {
            // Check if the window already has a form owner
            if (this.mobjData.FormDescriptorIndexByWindowName.ContainsKey(objDockedWindow.WindowName))
            {
                // If it does, remove it
                this.mobjData.FormDescriptorIndexByWindowName[objDockedWindow.WindowName] = objDockedFormDescriptor;
            }
            else
            {
                // Set the new form owner
                this.mobjData.FormDescriptorIndexByWindowName.Add(objDockedWindow.WindowName, objDockedFormDescriptor);
            }
        }

        /// <summary>
        /// Unpins the windows.
        /// </summary>
        /// <param name="objWindows">The obj windows.</param>
        /// <param name="enmPanelSide">The enm panel side.</param>
        internal void AutoHideWindows(DockStyle enmPanelSide, params DockingWindow[] objWindows)
        {
            // Create a list to hold all the zones as a group
            List<Zone> objHiddenZones = new List<Zone>();

            // Go through all windows and create a hidden zone for each one
            foreach (DockingWindow objWindow in objWindows)
            {
                // Craete the zone
                Zone objHiddenZone = new Zone(this, ZoneType.Hidden);

                // Set the correct panel side
                objHiddenZone.DockingPosition = enmPanelSide;

                // Add the window
                objHiddenZone.AddWindow(Relation.Inside, objWindow);

                // Add zone to the group
                objHiddenZones.Add(objHiddenZone);
            }

            // Add the zones to the relevant panel side
            switch (enmPanelSide)
            {
                case DockStyle.Bottom:
                    this.mobjBottomPanel.AddNewZones(objHiddenZones);
                    break;
                case DockStyle.Left:
                    this.mobjLeftPanel.AddNewZones(objHiddenZones);
                    break;
                case DockStyle.Right:
                    this.mobjRightPanel.AddNewZones(objHiddenZones);
                    break;
                case DockStyle.Top:
                    this.mobjTopPanel.AddNewZones(objHiddenZones);
                    break;
                case DockStyle.Fill:
                case DockStyle.None:
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Unregisters the place holder.
        /// </summary>
        /// <param name="objDockedWindowPlaceHolderDescriptor">The obj docked window place holder descriptor.</param>
        internal void UnregisterPlaceHolder(DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor)
        {
            // Unregister according to the zone's type
            switch (objDockedWindowPlaceHolderDescriptor.ZoneType)
            {
                case ZoneType.Dock:
                    // Remove the place holder from the Docked zones list
                    if (!this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
                    {
                        throw new Exception();
                    }
                    break;
                case ZoneType.Float:
                    // Remove the place holder from the Floating zones list
                    if (!this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
                    {
                        throw new Exception();
                    }
                    break;
                case ZoneType.Hidden:
                    // No need for place holder for hidden zones
                    break;
                case ZoneType.Root:
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Unregisters the split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        internal void UnregisterSplitContainer(DockedSplitContainer objDockedSplitContainer)
        {
            mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Remove(objDockedSplitContainer.DockedSplitContainerDescriptorInternal);
        }

        /// <summary>
        /// Uns the register zone.
        /// </summary>
        /// <param name="zone">The zone.</param>
        internal void UnRegisterZone(Zone zone)
        {
            // Remove zone from the list
            mobjAllZones.Remove(zone);

            // Refresh all Forms drag targets
            RefreshFormsDragTargets();
        }

        /// <summary>
        /// Updates the zones UI.
        /// </summary>
        private void UpdateZonesUI()
        {
            foreach (Zone objZone in mobjAllZones)
            {
                objZone.UpdateUI();
            }
        }

        #endregion Methods

        #region IDescriptable Members

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get { return this.mobjData; }
        }

        /// <summary>
        /// Gets the docked manager descriptor internal.
        /// </summary>
        internal DockedManagerDescriptor DockedManagerDescriptorInternal
        {
            get
            {
                return mobjData;
            }
        }

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            this.mobjData = objDescriptor as DockedManagerDescriptor;

            objDescriptor.UpdateSelf(this, this);
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

        #endregion

        #region Helpers

        /// <summary>
        /// 
        /// </summary>
        private struct RemovedWindowsData
        {
            private DockingWindow[] mobjWindows;
            private DockState mobjDesiredDockState;
            private DockState menmPreviousDockState;
            private bool mblnHasDockingStateInfo;
            private bool mblnHasFloatingStateInfo;
            private DockStyle menmUnpinPosition;

            /// <summary>
            /// Gets or sets the unpin position.
            /// </summary>
            /// <value>
            /// The unpin position.
            /// </value>
            public DockStyle UnpinPosition
            {
                get { return menmUnpinPosition; }
                set { menmUnpinPosition = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance has floating state info.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance has floating state info; otherwise, <c>false</c>.
            /// </value>
            public bool HasFloatingStateInfo
            {
                get { return mblnHasFloatingStateInfo; }
                set { mblnHasFloatingStateInfo = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance has docking state info.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance has docking state info; otherwise, <c>false</c>.
            /// </value>
            public bool HasDockingStateInfo
            {
                get { return mblnHasDockingStateInfo; }
                set { mblnHasDockingStateInfo = value; }
            }

            /// <summary>
            /// Gets or sets the state of the previous dock.
            /// </summary>
            /// <value>
            /// The state of the previous dock.
            /// </value>
            public DockState PreviousDockState
            {
                get { return menmPreviousDockState; }
                set { menmPreviousDockState = value; }
            }

            /// <summary>
            /// Gets or sets the state of the desired dock.
            /// </summary>
            /// <value>
            /// The state of the desired dock.
            /// </value>
            public DockState DesiredDockState
            {
                get { return mobjDesiredDockState; }
                set { mobjDesiredDockState = value; }
            }

            /// <summary>
            /// Gets or sets the windows.
            /// </summary>
            /// <value>
            /// The windows.
            /// </value>
            public DockingWindow[] Windows
            {
                get { return mobjWindows; }
                set { mobjWindows = value; }
            }
        }

        #endregion


        /// <summary>
        /// Gets the type of the dock state according to zone.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns></returns>
        internal static DockState GetDockStateAccordingToZoneType(ZoneType objType)
        {
            switch (objType)
            {
                case ZoneType.Root:
                    return DockState.Tabbed;
                case ZoneType.Dock:
                    return DockState.Dock;
                case ZoneType.Float:
                    return DockState.Float;
                case ZoneType.Hidden:
                    return DockState.AutoHide;
                default:
                    throw new NotSupportedException("ZoneType not supported: '" + objType.ToString() + "'");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DockedWindowsCollection : ICollection<DockingWindow>
    {
        /// <summary>
        /// 
        /// </summary>
        private DockingManager mobjManager;

        private Dictionary<DockingWindowName, DockingWindow> mobjWindowsIndexByWindowName;
        private Dictionary<DockingWindowName, DockingWindow> mobjHiddenWindowsIndexByWindowName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedWindowsCollection"/> class.
        /// </summary>
        public DockedWindowsCollection()
        {
            mobjWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
            mobjHiddenWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public DockingManager Manager
        {
            get { return mobjManager; }
            internal set { mobjManager = value; }
        }

        /// <summary>
        /// Adds the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void AddWindowIfDoesntExist(DockingWindow objWindow)
        {
            objWindow.Manager = this.mobjManager;

            if (!mobjWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
            {
                mobjWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
            }
            else
            {
                if (mobjWindowsIndexByWindowName[objWindow.WindowName] == objWindow)
                {
                    throw new Exception("The given window already exists in the manager. In order to add a window of the same type, create a new instance of the window and give it a unique name");
                }
                else
                {
                    throw new Exception("A window with the same name ('" + objWindow.WindowName.WindowName + "') already exists in the manager. In order to add a window, create a new instance of the window and give it a unique name");
                }
            }
        }

        /// <summary>
        /// Removes the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        /// <returns></returns>
        internal bool RemoveWindow(DockingWindow objWindow)
        {
            return mobjWindowsIndexByWindowName.Remove(objWindow.WindowName);
        }

        /// <summary>
        /// Adds the hidden window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void AddHiddenWindow(DockingWindow objWindow)
        {
            objWindow.Manager = this.mobjManager;

            if (!mobjHiddenWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
            {
                DockState enmDockState;
                switch (objWindow.CurrentDockState)
                {
                    case DockState.Float:
                        enmDockState = DockState.Float;
                        break;
                    case DockState.Tabbed:
                        enmDockState = DockState.Tabbed;
                        break;
                    case DockState.AutoHide:
                    case DockState.Dock:
                        enmDockState = DockState.Dock;
                        break;
                    case DockState.Hidden:
                    case DockState.Close:
                        enmDockState = objWindow.LastDockState;
                        break;
                    default:
                        throw new Exception();
                }

                objWindow.LastDockState = enmDockState;

                mobjHiddenWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
            }
        }

        /// <summary>
        /// Removes the hidden window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        /// <returns></returns>
        internal bool RemoveHiddenWindow(DockingWindow objWindow)
        {
            return mobjHiddenWindowsIndexByWindowName.Remove(objWindow.WindowName);
        }

        /// <summary>
        /// Gets the name of the windows index by window.
        /// </summary>
        /// <value>
        /// The name of the windows index by window.
        /// </value>
        internal Dictionary<DockingWindowName, DockingWindow> WindowsIndexByWindowName
        {
            get { return mobjWindowsIndexByWindowName; }
        }

        /// <summary>
        /// Gets the name of the hidden windows index by window.
        /// </summary>
        /// <value>
        /// The name of the hidden windows index by window.
        /// </value>
        internal Dictionary<DockingWindowName, DockingWindow> HiddenWindowsIndexByWindowName
        {
            get { return mobjHiddenWindowsIndexByWindowName; }
        }

        #region ICollection<DockingWindow> Members

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public void Add(DockingWindow item)
        {
            mobjManager.AddTabbedWindows(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
        public void Clear()
        {
            foreach (DockingWindow objWindow in mobjWindowsIndexByWindowName.Values)
            {
                objWindow.Close();
            }

            mobjWindowsIndexByWindowName.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(DockingWindow item)
        {
            return mobjWindowsIndexByWindowName.ContainsKey(item.WindowName);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(DockingWindow[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
        public int Count
        {
            get 
            {
                return mobjWindowsIndexByWindowName.Count; 
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public bool Remove(DockingWindow item)
        {
            if (!item.Closed)
            {
                item.Close();

                return true;
            }

            return false;
        }

        #endregion

        #region IEnumerable<DockingWindow> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<DockingWindow> GetEnumerator()
        {
            return mobjWindowsIndexByWindowName.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mobjWindowsIndexByWindowName.Values.GetEnumerator();            
        }

        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TabbedWindowSelectedEventArgs"/> instance containing the event data.</param>
    public delegate void TabbedWindowSelectedEventHandler(object sender, TabbedWindowSelectedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TabbedWindowSelectedEventArgs : DockingWindowEventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedWindowSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        public TabbedWindowSelectedEventArgs(DockingWindow objDockedWindow) : base(objDockedWindow)
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TabbedWindowClosedEventArgs"/> instance containing the event data.</param>
    public delegate void TabbedWindowClosedEventHandler(object sender, TabbedWindowClosedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DockingWindowLoadedEventArgs"/> instance containing the event data.</param>
    public delegate void DockingWindowLoadedEventHandler(object sender, DockingWindowLoadedEventArgs e);


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TabbedWindowClosedEventArgs : DockingWindowEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedWindowSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        public TabbedWindowClosedEventArgs(DockingWindow objDockedWindow)
            : base(objDockedWindow)
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DockingWindowLoadedEventArgs : DockingWindowEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedWindowSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        public DockingWindowLoadedEventArgs(DockingWindow objDockedWindow)
            : base(objDockedWindow)
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class DockingWindowEventArgs : EventArgs
    {
        private DockingWindow objDockedWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DockingWindowEventArgs"/> class.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        public DockingWindowEventArgs(DockingWindow objDockedWindow)
        {
            // TODO: Complete member initialization
            this.objDockedWindow = objDockedWindow;
        }

        /// <summary>
        /// Gets the docked window.
        /// </summary>
        public DockingWindow DockedWindow
        {
            get { return objDockedWindow; }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.WindowsStateChangedEventArgs"/> instance containing the event data.</param>
    public delegate void WindowsStateChangedEventHandler(object sender, WindowsStateChangedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WindowsStateChangedEventArgs : EventArgs
    {
        private DockState menmPreviousDockState;
        private DockState menmNewDockState;
        private DockingWindow[] marrChangedWindows;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsStateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="enmPreviousDockState">State of the enm previous dock.</param>
        /// <param name="enmNewDockState">State of the enm new dock.</param>
        /// <param name="arrChangedWindows">The arr changed windows.</param>
        public WindowsStateChangedEventArgs(DockState enmPreviousDockState, DockState enmNewDockState, DockingWindow[] arrChangedWindows)
        {
            this.menmPreviousDockState = enmPreviousDockState;
            this.menmNewDockState = enmNewDockState;
            this.marrChangedWindows = arrChangedWindows;
        }

        /// <summary>
        /// Gets the changed windows.
        /// </summary>
        public DockingWindow[] ChangedWindows
        {
            get { return marrChangedWindows; }
        }

        /// <summary>
        /// Gets the new state of the dock.
        /// </summary>
        /// <value>
        /// The new state of the dock.
        /// </value>
        public DockState NewDockState
        {
            get { return menmNewDockState; }
        }

        /// <summary>
        /// Gets the state of the previous dock.
        /// </summary>
        /// <value>
        /// The state of the previous dock.
        /// </value>
        public DockState PreviousDockState
        {
            get { return menmPreviousDockState; }
        }
    }
}