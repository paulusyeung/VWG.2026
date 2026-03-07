using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [MetadataTag(WGTags.DockingZone)]
    [Skin(typeof(ZoneSkin))]
    [Serializable]
    [ToolboxItem(false)]
    public class Zone : ContainerControl, IDescriptable, ISupportInitialize
    {
        internal const int ZONE_WITH_NO_OWNING_FORM_ID = -1;

        #region Fields (14)

        private bool mblnRegistered;
        private bool mblnSusspentUIEvents;
        private ZoneType menmZoneType;
        private long mlngOwningFormId;
        private ZoneCloseButton mobjCloseButton;
        private DockedHiddenZonesPanel mobjContainingHiddenPanel;
        private ZoneDescriptor mobjData;
        private ZoneDropDownButton mobjDropDownButton;
        private ZoneHeaderPanel mobjHeaderPanel;
        private DockingManager mobjManager;
        private ZonePinCheckBox mobjPinCheckBox;
        private DockedTabControl mobjTabControl;
        private ZoneHeaderLabel mobjZoneHeaderLabel;
        private Form mobjZonePopupForm;
        private bool mblnHideTabs;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        /// <param name="objManager">The obj manager.</param>
        /// <param name="enmZoneType">Type of the enm zone.</param>
        public Zone(DockingManager objManager, ZoneType enmZoneType)
        {
            this.AllowDrop = true;
            this.mobjData = new ZoneDescriptor();
            this.Dock = DockStyle.Fill;
            this.mobjManager = objManager;
            this.ParentChanged += new EventHandler(Zone_ParentChanged);
            this.menmZoneType = enmZoneType;
            this.mblnSusspentUIEvents = false;
            this.mblnRegistered = false;
            this.mlngOwningFormId = Zone.ZONE_WITH_NO_OWNING_FORM_ID;
            this.mblnHideTabs = false;

            // Create and initialize the UI componenets
            InitializeComponent();

            // Initialized the zone after all the controls were added.
            PostInitialization();
        }

        #endregion Constructors

        #region Properties (11)

        /// <summary>
        /// Gets or sets the containing hidden panel.
        /// </summary>
        /// <value>
        /// The containing hidden panel.
        /// </value>
        internal DockedHiddenZonesPanel ContainingHiddenPanel
        {
            get
            {
                return mobjContainingHiddenPanel;
            }
            set
            {
                mobjContainingHiddenPanel = value;
            }
        }

        /// <summary>
        /// Gets the current window.
        /// </summary>
        public DockingWindow CurrentWindow
        {
            get
            {
                return (this.mobjTabControl.SelectedTab as DockedTabPage).Window;
            }
        }

        /// <summary>
        /// Gets or sets the docking position.
        /// </summary>
        /// <value>
        /// The docking position.
        /// </value>
        public DockStyle DockingPosition
        {
            get
            {
                return mobjData.DockingPosition;
            }
            set
            {
                mobjData.DockingPosition = value;
            }
        }

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get
            {
                return this.mobjData;
            }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public DockingManager Manager
        {
            get
            {
                return this.mobjManager;
            }
        }

        /// <summary>
        /// Gets or sets the owning form id.
        /// </summary>
        /// <value>
        /// The owning form id.
        /// </value>
        public long OwningFormId
        {
            get { return mlngOwningFormId; }
            set { mlngOwningFormId = value; }
        }

        /// <summary>
        /// Gets the panel side.
        /// </summary>
        internal int PanelSide
        {
            get
            {
                return this.mobjData.PanelSide;
            }
        }

        /// <summary>
        /// Gets the tab control.
        /// </summary>
        internal DockedTabControl TabControl
        {
            get
            {
                return mobjTabControl;
            }
        }

        /// <summary>
        /// Gets the windows.
        /// </summary>
        public List<DockingWindow> Windows
        {
            get
            {
                return TabControl.Windows;
            }
        }

        /// <summary>
        /// Gets the zone descriptor internal.
        /// </summary>
        internal ZoneDescriptor ZoneDescriptorInternal
        {
            get
            {
                return this.mobjData;
            }
        }

        /// <summary>
        /// Gets or sets the type of the zone.
        /// </summary>
        /// <value>
        /// The type of the zone.
        /// </value>
        internal ZoneType ZoneType
        {
            get
            {
                return menmZoneType;
            }
            set
            {
                if (menmZoneType != value)
                {
                    menmZoneType = value;

                    // Change the zone's UI accordingto its dock state
                    this.UpdateUI();
                }
            }
        }

        /// <summary>
        /// Gets or sets the zone popup form.
        /// </summary>
        /// <value>
        /// The zone popup form.
        /// </value>
        public Form ZonePopupForm
        {
            get
            {
                return this.mobjZonePopupForm;
            }
            set
            {
                this.mobjZonePopupForm = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [force hide tabs].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [force hide tabs]; otherwise, <c>false</c>.
        /// </value>
        public bool HideTabs
        {
            get
            {
                return this.mblnHideTabs;
            }
            set
            {
                this.mblnHideTabs = value;

				// Making sure the tabpage will be updated.
				SetTabControlTabsAppearance();
            }
        }

        
        #endregion Properties

        #region Methods (43)

        /// <summary>
        /// Adds the window.
        /// </summary>
        /// <param name="enmRelation">The enm relation.</param>
        /// <param name="objDockedWindow">The obj docked window.</param>
        /// 
        internal void AddWindow(Relation enmRelation, params DockingWindow[] objDockedWindow)
        {
            // Hidden zones contain only one window
            if (this.ZoneType == Forms.ZoneType.Hidden && (objDockedWindow.Length > 1 || this.Windows.Count == 1))
            {
                throw new Exception("Hidden zone cannot contain more than one window");
            }

            // Add the window according to the relation
            switch (enmRelation)
            {
                case Relation.Above:
                case Relation.Below:
                case Relation.ToTheRight:
                case Relation.ToTheLeft:
                    // If the new window is not added to this zone, create a new zone for it.
                    Zone objNewZone = CreateZoneForNewWindow();

                    // Split this zone according to relation
                    SplitZone(enmRelation, objNewZone, true);

                    // Add the window inside the new zone
                    objNewZone.AddWindow(Relation.Inside, objDockedWindow);
                    break;
                case Relation.Inside:
                    foreach (DockingWindow objWindow in objDockedWindow)
                    {
                        this.mobjTabControl.AddWindow(objWindow);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Updates the UI.
        /// </summary>
        internal void UpdateUI()
        {
            this.InitializeUIAccordingToZoneType();
        }

        /// <summary>
        /// Notifies the header text chaged.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        internal void NotifyHeaderTextChanged(DockingWindow objDockedWindow)
        {
            NotifyTabIndexChanged();
        }

        /// <summary>
        /// Notifies the header tool tip changed.
        /// </summary>
        /// <param name="objDockedWindow">The obj docked window.</param>
        internal void NotifyWindowHeaderAttributeChanged(DockingWindow objDockedWindow)
        {
            NotifyTabIndexChanged();
        }
        // Public Methods (2) 

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            this.mblnSusspentUIEvents = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            this.mblnSusspentUIEvents = false;
        }
        // Protected Methods (6) 

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            // The user dropped a form inside a zone
            if (objEvent.Type == "AddForm")
            {
                int intFormId;
                int intRelation;

                // Try getting the form ID and relation type
                if (int.TryParse(objEvent[WGAttributes.DragSource], out intFormId) && int.TryParse(objEvent[WGAttributes.Relation], out intRelation))
                {
                    // Get the live form
                    DockedForm objForm = this.Manager.GetFormFromComponentId(objEvent[WGAttributes.DragSource]);

                    if (objForm != null)
                    {
                        // Invoke split form with the relevant relation
                        this.SplitForm((Relation)intRelation, objForm);
                    }
                    else
                    {
                        throw new Exception("Dragged form with ID=" + intFormId + " was not found");
                    }
                }
            }

            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            DockedTabControl objAddedTabControl = e.Control as DockedTabControl;

            if (objAddedTabControl != null)
            {
                // Set tab control's owning zone
                objAddedTabControl.OwningZone = this;

                // Update the zone's descriptor
                (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);

                // Update the DockedTabControl's descriptor from the zone
                (e.Control as IDescriptable).Descriptor.UpdateFrom(this, null);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            DockedTabControl objRemovedTabControl = e.Control as DockedTabControl;

            if (objRemovedTabControl != null)
            {
                // Remove referance to this zone
                objRemovedTabControl.OwningZone = null;

                if (this.Parent != null)
                {
                    // If the tab control was removes, there's no need for the zone to exist, zo remove it.
                    this.Parent.Controls.Remove(this);
                }
                else if (this.ContainingHiddenPanel != null)
                {
                    this.ContainingHiddenPanel.RemoveSingleZoneFromPanel(this);
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

			// Initialize the UI according to the zone's type
            UpdateUI();

            if (!this.mblnRegistered)
            {
                this.mblnRegistered = true;
                this.Manager.RegisterZone(this);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Update the descriptor for size changed
            (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // For hidden zones
            if (this.ZoneType == Forms.ZoneType.Hidden)
            {
                // Get the current window (which is the only window)
                DockingWindow objWindow = this.CurrentWindow;

                // Render image attribute
                RenderHiddenZoneImageAttribute(objWriter, objWindow, false);

                // Render text attribute
                objWriter.WriteAttributeText(WGAttributes.Text, objWindow.Text);
            }
        }
        // Private Methods (24) 

        /// <summary>
        /// Gets the docking position in relation to the root zone.
        /// </summary>
        /// <param name="objRelation">The obj relation.</param>
        /// <returns></returns>
        private DockStyle GetDockingPositionInRelationToRootZone(Relation objRelation)
        {
            // Check if this is the root zone
            if (this.ZoneType == ZoneType.Root)
            {
                // Get the docking position according to the relation
                switch (objRelation)
                {
                    case Relation.Above:
                        return DockStyle.Top;
                    case Relation.Below:
                        return DockStyle.Bottom;
                    case Relation.ToTheRight:
                        return DockStyle.Right;
                    case Relation.ToTheLeft:
                        return DockStyle.Left;
                    default:
                        throw new Exception();
                }

            }
            else
            {
                // If this is not root zone, take the relation from this zone
                return this.DockingPosition;
            }
        }

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            ZoneDescriptor objZoneDescriptor = objDescriptor as ZoneDescriptor;

            if (objZoneDescriptor != null)
            {
                // Set the descriptor's referance
                this.mobjData = objZoneDescriptor;
            }
            else
            {
                throw new ArgumentException("The given descriptor is not of type: " + typeof(ZoneDescriptor).FullName);
            }
        }

        /// <summary>
        /// Resets the descriptors tree.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <param name="objDockingPosition">The obj docking position.</param>
        void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
        {
            List<DockingWindow> objWindows = this.Windows;
            // Set the descriptor's referance
            this.mobjData = this.ZoneDescriptorInternal.CloneWithoutReferences<ZoneDescriptor>();

            // Reset the tabcontrol's descriptor
            (this.TabControl as IDescriptable).ResetDescriptorsTree(objType, objDockingPosition);

            // Set the given type
            this.ZoneType = objType;

            foreach (DockingWindow objWindow in objWindows)
            {
                this.TabControl.AddWindow(objWindow);
            }

            // Set the docking position
            this.DockingPosition = objDockingPosition;

            // Update the tab control's descriptor from the zone
            this.TabControl.DockedTabControlDescriptorInternal.UpdateFrom(this, null);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjHeaderPanel = new ZoneHeaderPanel(this);
            this.mobjCloseButton = new ZoneCloseButton();
            this.mobjPinCheckBox = new ZonePinCheckBox();
            this.mobjDropDownButton = new ZoneDropDownButton();
            this.mobjTabControl = new DockedTabControl(mobjManager);
            this.mobjZoneHeaderLabel = new ZoneHeaderLabel();
            this.mobjHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // mobjZoneHeaderLabel
            //
            this.mobjZoneHeaderLabel.Dock = DockStyle.Fill;
            this.mobjZoneHeaderLabel.AutoSize = true;
            this.mobjZoneHeaderLabel.Location = new System.Drawing.Point(242, 136);
            this.mobjZoneHeaderLabel.Name = "label1";
            this.mobjZoneHeaderLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjZoneHeaderLabel.TabIndex = 1;
            this.mobjZoneHeaderLabel.DoubleClick += new EventHandler(mobjHeaderPanel_DoubleClick);
            //
            // mobjHeaderPanel
            //
            this.mobjHeaderPanel.Controls.Add(this.mobjZoneHeaderLabel);
            this.mobjHeaderPanel.Controls.Add(this.mobjDropDownButton);
            this.mobjHeaderPanel.Controls.Add(this.mobjPinCheckBox);
            this.mobjHeaderPanel.Controls.Add(this.mobjCloseButton);
            this.mobjHeaderPanel.Dock = DockStyle.Top;
            this.mobjHeaderPanel.Size = new System.Drawing.Size(831, 20);
            this.mobjHeaderPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.mobjCloseButton.Dock = DockStyle.Right;
            this.mobjCloseButton.Location = new System.Drawing.Point(801, 0);
            this.mobjCloseButton.Name = "button1";
            this.mobjCloseButton.Size = new System.Drawing.Size(16, 27);
            this.mobjCloseButton.TabIndex = 0;
            this.mobjCloseButton.UseVisualStyleBackColor = true;
            this.mobjCloseButton.Click += new EventHandler(mobjCloseButton_Click);
            // 
            // button2
            // 
            this.mobjPinCheckBox.Dock = DockStyle.Right;
            this.mobjPinCheckBox.Location = new System.Drawing.Point(771, 0);
            this.mobjPinCheckBox.Name = "button2";
            this.mobjPinCheckBox.Size = new System.Drawing.Size(100, 27);
            this.mobjPinCheckBox.UseVisualStyleBackColor = true;
            this.mobjPinCheckBox.CheckedChanged += new EventHandler(mobjPinCheckBox_CheckedChanged);
            // 
            // button3
            // 
            this.mobjDropDownButton.Dock = DockStyle.Right;
            this.mobjDropDownButton.Location = new System.Drawing.Point(745, 0);
            this.mobjDropDownButton.Name = "button3";
            this.mobjDropDownButton.Size = new System.Drawing.Size(26, 27);
            this.mobjDropDownButton.TabIndex = 2;
            this.mobjDropDownButton.UseVisualStyleBackColor = true;
            this.mobjDropDownButton.Click += new EventHandler(mobjMenuButton_Click);
            // 
            // tabControl1
            // 
            this.mobjTabControl.Dock = DockStyle.Fill;
            this.mobjTabControl.Location = new System.Drawing.Point(0, 27);
            this.mobjTabControl.Name = "tabControl1";
            this.mobjTabControl.SelectedIndex = 0;
            this.mobjTabControl.Size = new System.Drawing.Size(831, 606);
            this.mobjTabControl.TabIndex = 1;
            // 
            // UserControl1
            // 
            this.Controls.Add(this.mobjTabControl);
            this.Controls.Add(this.mobjHeaderPanel);
            this.mobjHeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Initializes the custom controls.
        /// </summary>
        private void InitializeCustomControls()
        {
            ZoneCloseButtonSkin objCloseButtonSkin = SkinFactory.GetSkin(mobjCloseButton) as ZoneCloseButtonSkin;
            ZonePinCheckBoxSkin objPinCheckBoxSkin = SkinFactory.GetSkin(mobjPinCheckBox) as ZonePinCheckBoxSkin;
            ZoneDropDownButtonSkin objDropDownButtonSkin = SkinFactory.GetSkin(mobjDropDownButton) as ZoneDropDownButtonSkin;

            // Set all buttons' sizes according to their skin
            this.mobjCloseButton.Size = (objCloseButtonSkin).TotalSize;
            this.mobjCloseButton.Text = "";
            this.mobjPinCheckBox.Size = (objPinCheckBoxSkin).TotalSize;
            this.mobjPinCheckBox.Text = "";
            this.mobjDropDownButton.Size = (objDropDownButtonSkin).TotalSize;
            this.mobjDropDownButton.Text = "";
        }

        /// <summary>
        /// Initializes the dock zone type UI.
        /// </summary>
        private void InitializeDockZoneTypeUI()
        {
            InitializeHeaderPanelVisibility(true);
            InitializeCloseButtonVisibility(true);
            InitializeDropDownButtonVisibility(true);
            InitializePinButtonVisibility(true);

            this.mobjCloseButton.ClientAction = null;
            this.mobjPinCheckBox.ClientAction = null;
            (this.mobjTabControl as IPreventExtraction).DisableExtraction(false);
            InitializeTabControlAppearance(false);
        }

        /// <summary>
        /// Initializes the pin button visibility.
        /// </summary>
        /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
        private void InitializePinButtonVisibility(bool blnIsVisible)
        {
            this.mobjPinCheckBox.Visible = blnIsVisible && (Manager != null && Manager.ShowPinButton);
        }

        /// <summary>
        /// Initializes the drop down button visibility.
        /// </summary>
        /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
        private void InitializeDropDownButtonVisibility(bool blnIsVisible)
        {
            this.mobjDropDownButton.Visible = blnIsVisible && (Manager != null && Manager.ShowDropDownButton);
        }

        /// <summary>
        /// Initializes the close button visibility.
        /// </summary>
        /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
        private void InitializeCloseButtonVisibility(bool blnIsVisible)
        {
            this.mobjCloseButton.Visible = blnIsVisible && (Manager != null && Manager.AllowCloseWindows);
        }

        /// <summary>
        /// Initializes the header panel visibility.
        /// </summary>
        /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
        private void InitializeHeaderPanelVisibility(bool blnIsVisible)
        {
            this.mobjHeaderPanel.Visible = blnIsVisible;            
        }

        /// <summary>
        /// Initializes the float zone type UI.
        /// </summary>
        private void InitializeFloatZoneTypeUI()
        {
            InitializeHeaderPanelVisibility(true);
            InitializeCloseButtonVisibility(true);
            InitializeDropDownButtonVisibility(true);
            InitializePinButtonVisibility(false);
            this.mobjCloseButton.ClientAction = null;
            this.mobjPinCheckBox.ClientAction = null;
            (this.mobjTabControl as IPreventExtraction).DisableExtraction(false);
            InitializeTabControlAppearance(false);
        }

        /// <summary>
        /// Initializes the hidden zone type UI.
        /// </summary>
        private void InitializeHiddenZoneTypeUI()
        {
            InitializeHeaderPanelVisibility(true);
            InitializeCloseButtonVisibility(true);
            InitializeDropDownButtonVisibility(true);
            InitializePinButtonVisibility(true);
            
            this.mobjPinCheckBox.Checked = true;
        }

        /// <summary>
        /// Initializes the type of the root zone.
        /// </summary>
        private void InitializeRootZoneType()
        {
            InitializeHeaderPanelVisibility(false);
            this.mobjTabControl.ShowCloseButton = (Manager != null && Manager.AllowCloseWindows);
            this.mobjTabControl.CloseClick += new EventHandler(mobjTabControl_CloseClick);
            (this.mobjTabControl as IPreventExtraction).DisableExtraction(true);

            InitializeTabControlAppearance(true);
        }

        private void InitializeTabControlAppearance(bool blnIsRoot)
        {
            if (!blnIsRoot)
            {
                this.mobjTabControl.Alignment = TabAlignment.Bottom;

                this.mobjTabControl.ControlAdded -= new ControlEventHandler(mobjTabControl_RootControlAdded);
                this.mobjTabControl.ControlRemoved -= new ControlEventHandler(mobjTabControl_RootControlRemoved);

                this.mobjTabControl.ControlAdded += new ControlEventHandler(mobjTabControl_ControlAdded);
                this.mobjTabControl.ControlRemoved += new ControlEventHandler(mobjTabControl_ControlRemoved);
            }
            else
            {
                this.mobjTabControl.Alignment = TabAlignment.Top;
                this.mobjTabControl.ControlAdded -= new ControlEventHandler(mobjTabControl_ControlAdded);
                this.mobjTabControl.ControlRemoved -= new ControlEventHandler(mobjTabControl_ControlRemoved);

                this.mobjTabControl.ControlAdded += new ControlEventHandler(mobjTabControl_RootControlAdded);
                this.mobjTabControl.ControlRemoved += new ControlEventHandler(mobjTabControl_RootControlRemoved);
            }
        }

        /// <summary>
        /// Initializes the type of the UI according to zone.
        /// </summary>
        private void InitializeUIAccordingToZoneType()
        {
            this.BeginInit();

            switch (this.menmZoneType)
            {
                case ZoneType.Root:
                    InitializeRootZoneType();
                    break;
                case ZoneType.Dock:
                    InitializeDockZoneTypeUI();
                    break;
                case ZoneType.Float:
                    InitializeFloatZoneTypeUI();
                    break;
                case Forms.ZoneType.Hidden:
                    InitializeHiddenZoneTypeUI();
                    break;
                default:
                    throw new Exception("Zone type not supported: " + this.menmZoneType.ToString());
            }

            // Set the appearance property on the tub control
            SetTabControlTabsAppearance();

            this.EndInit();
        }

        /// <summary>
        /// Handles the Click event of the mobjCloseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjCloseButton_Click(object sender, EventArgs e)
        {
            this.CloseCurrentWindow();
            this.CloseZonePopupForm();
        }

        /// <summary>
        /// Closes the current window.
        /// </summary>
        private void CloseCurrentWindow()
        {
            Manager.SwitchWindowsDockState(DockState.Close, this.CurrentWindow);
        }

        /// <summary>
        /// Closes the zone popup window.
        /// </summary>
        private void CloseZonePopupForm()
        {
            if (this.mobjZonePopupForm != null)
            {
                this.mobjZonePopupForm.Close();
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the mobjHeaderPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjHeaderPanel_DoubleClick(object sender, EventArgs e)
        {
            OnHeaderDoubleClick();
            this.CloseZonePopupForm();
        }

        /// <summary>
        /// Handles the Click event of the mobjMenuButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjMenuButton_Click(object sender, EventArgs e)
        {
            // Show the context menu for this zone
            this.Manager.GetDockedContextMenuStrip(this).Show(this.mobjDropDownButton, new Point(1, 1), ToolStripDropDownDirection.BelowLeft);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjPinCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjPinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.mblnSusspentUIEvents)
            {
                // Auto hide the zone
                this.ToggleAutoHide();
            }
        }

        /// <summary>
        /// Handles the CloseClick event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjTabControl_CloseClick(object sender, EventArgs e)
        {
            this.CloseCurrentWindow();
        }

        /// <summary>
        /// Handles the ControlAdded event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void mobjTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            SetTabControlTabsAppearance();
        }

        /// <summary>
        /// Handles the ControlRemoved event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void mobjTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetTabControlTabsAppearance();
        }

        /// <summary>
        /// Handles the RootControlAdded event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void mobjTabControl_RootControlAdded(object sender, ControlEventArgs e)
        {
            HandleRootTabControlControlsChanged();
        }

        /// <summary>
        /// Handles the RootControlRemoved event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void mobjTabControl_RootControlRemoved(object sender, ControlEventArgs e)
        {
            HandleRootTabControlControlsChanged();
        }

        /// <summary>
        /// Handles the root tab control controls changed.
        /// </summary>
        private void HandleRootTabControlControlsChanged()
        {
            if (this.mobjTabControl.Controls.Count > 0)
            {
                this.mobjTabControl.ShowCloseButton = true;
            }
            else
            {
                this.mobjTabControl.ShowCloseButton = false;
            }
        }

        /// <summary>
        /// Posts the initialization.
        /// </summary>
        private void PostInitialization()
        {
            // Initialize the contained custom controls
            InitializeCustomControls();
        }

        /// <summary>
        /// Removes the and return all windows.
        /// </summary>
        /// <returns></returns>
        internal List<DockingWindow> RemoveAndReturnAllWindows()
        {
            // Get all windows
            List<DockingWindow> objWindowsInside = this.Windows;

            RemoveWindows(this.Windows.ToArray());

            // Return the removed windows
            return objWindowsInside;
        }

        /// <summary>
        /// Renders the hidden zone image attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objWindow">The obj window.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderHiddenZoneImageAttribute(IAttributeWriter objWriter, DockingWindow objWindow, bool blnForceRender)
        {
            if (objWindow.Image != null || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Image, objWindow.Image.ToString());
            }
        }

        /// <summary>
        /// Sets the tab control tabs appearance.
        /// </summary>
        private void SetTabControlTabsAppearance()
        {
            if ((this.mobjTabControl.Controls.Count == 1 && !(this.ZoneType == Forms.ZoneType.Root)) || this.ZoneType == Forms.ZoneType.Hidden || this.mblnHideTabs)
            {
                this.mobjTabControl.Appearance = TabAppearance.Logical;
            }
            else
            {
                this.mobjTabControl.Appearance = TabAppearance.Normal;
            }
        }

        /// <summary>
        /// Splits the zone.
        /// </summary>
        /// <param name="objRelation">The obj relation.</param>
        /// <param name="objZone">The obj zone.</param>
        /// <param name="blnIsNewZone">if set to <c>true</c> [BLN is new zone].</param>
        private void SplitZone(Relation objRelation, Zone objZone, bool blnIsNewZone)
        {
            if (!(objZone.ZoneType == ZoneType.Root))
            {
                switch (objRelation)
                {
                    case Relation.Above:
                    case Relation.Below:
                    case Relation.ToTheRight:
                    case Relation.ToTheLeft:
                        // Get the docking position for the given zone
                        DockStyle objDockingPosition = GetDockingPositionInRelationToRootZone(objRelation);

                        // Check if the given zone's type is the same as this zone's type
                        if (this.ZoneType == objZone.ZoneType)
                        {
                            // Get the zone's logical parent (it can only be a DockedSplitContainer)
                            Control objParent = DockedManagerHelper.GetLogicalParentControl(objZone);

                            if (objParent != null && objParent is DockedSplitContainer)
                            {
                                // Hard-remove the zone from the split container
                                (objParent as DockedSplitContainer).HardRemovePanel(objZone.PanelSide);
                            }
                        }
                        else
                        {
                            // No need to reset the zone's descriptors tree for new zones
                            if (!blnIsNewZone)
                            {
                                (objZone as IDescriptable).ResetDescriptorsTree(this.ZoneType == ZoneType.Root ? ZoneType.Dock : this.ZoneType, objDockingPosition);
                            }
                        }

                        // Ensure the given zone's docking position
                        objZone.DockingPosition = objDockingPosition;

                        // Split the zone
                        DockedManagerHelper.SplitControl(this, objZone, objRelation, this.Manager);
                        break;
                    case Relation.Inside:
                        // Get all the windows
                        List<DockingWindow> objWindowsInside = objZone.RemoveAndReturnAllWindows();

                        // Add all removed windows to this zone
                        this.AddWindow(Relation.Inside, objWindowsInside.ToArray());
                        break;
                    default:
                        throw new Exception("Unsupported Relation type: " + objRelation.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the ParentChanged event of the Zone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Zone_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null || this.ContainingHiddenPanel != null)
            {
                if (this.ID != 0 && !this.mblnRegistered)
                {
                    // Register the zone
                    this.Manager.RegisterZone(this);

                    // Indicate the zone is registered
                    this.mblnRegistered = true;
                }
            }
            else
            {
                // Unregister the zone if it has no parent
                this.Manager.UnRegisterZone(this);

                // Indicate the zone is unregistered
                this.mblnRegistered = false;
            }
        }
        // Internal Methods (12) 

        /// <summary>
        /// Removes the and return all windows.
        /// </summary>
        /// <returns></returns>
        internal DockingWindow RemoveAndReturnCurrentWindow()
        {
            DockingWindow objWindow = this.CurrentWindow;

            RemoveWindows(objWindow);

            return objWindow;
        }

        /// <summary>
        /// Removes the windows.
        /// </summary>
        /// <param name="arrWindows">The arr windows.</param>
        internal void RemoveWindows(params DockingWindow[] arrWindows)
        {
            foreach (DockingWindow objWindow in arrWindows)
            {
                this.TabControl.RemoveWindow(objWindow);
            }
        }

        /// <summary>
        /// Creates the zone for new window.
        /// </summary>
        /// <returns></returns>
        internal Zone CreateZoneForNewWindow()
        {
            return new Zone(this.Manager, this.menmZoneType == ZoneType.Root ? ZoneType.Dock : this.menmZoneType);
        }

        /// <summary>
        /// Hides the current window.
        /// </summary>
        internal void HideCurrentWindow()
        {
            this.HideWindow(this.CurrentWindow);
            this.CloseZonePopupForm();
        }

        /// <summary>
        /// Hides the window.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        internal void HideWindow(DockingWindow objWindow)
        {
            Manager.SwitchWindowsDockState(DockState.Hidden, objWindow);
        }

        /// <summary>
        /// Notifies the tab index changed.
        /// </summary>
        internal void NotifyTabIndexChanged()
        {
            if (this.mobjTabControl.TabPages.Count > 0)
            {
                DockingWindow objWindow = (this.mobjTabControl.SelectedItem as DockedTabPage).Window;
                // Set the current window's text to the header of the zone
                this.mobjZoneHeaderLabel.Text = objWindow.HeaderText;

                if (!string.IsNullOrEmpty(objWindow.HeaderToolTip))
                {
                    this.mobjZoneHeaderLabel.ToolTip = objWindow.HeaderToolTip;
                }
                else
                {
                    this.mobjZoneHeaderLabel.ToolTip = string.Empty;
                }
            }
            else
            {
                this.mobjZoneHeaderLabel.Text = string.Empty;
            }
        }

        /// <summary>
        /// Called when [header double click].
        /// </summary>
        internal virtual void OnHeaderDoubleClick()
        {
            // Get all windows
            List<DockingWindow> objWindows = this.Windows;

            DockState objDesiredDockState = this.menmZoneType == Forms.ZoneType.Root ? DockState.Dock : DockingManager.GetDockStateAccordingToZoneType(this.menmZoneType);

            // Switch windows state
            Manager.SwitchWindowsDockState(objDesiredDockState, objWindows.ToArray());
        }

        /// <summary>
        /// Splits this zone with a given docked form.
        /// </summary>
        /// <param name="enmRelation">The enm relation.</param>
        /// <param name="objForm">The obj form.</param>
        internal void SplitForm(Relation enmRelation, DockedForm objForm)
        {
            // Get the form's root Control - A DockedForm may contain only 1 Control inside it! (Either a Zone of type Float or a DockedSplitContainer)
            Control objRootControl = objForm.Controls[0];
            bool blnDidSwitchState = this.ZoneType != Forms.ZoneType.Float;
            DockingWindow[] objTransferedWindows = null;

            // If the root control is a zone
            if (objRootControl is Zone)
            {
                Zone objRootZoneControl = objRootControl as Zone;
                // Perform the split zone logic
                this.SplitZone(enmRelation, objRootZoneControl, false);

                if (blnDidSwitchState)
                {
                    objTransferedWindows = objRootZoneControl.Windows.ToArray();
                }
            }
            // If the root is a split container
            else if (objRootControl is DockedSplitContainer)
            {
                DockedSplitContainer objContainer = objRootControl as DockedSplitContainer;

                switch (enmRelation)
                {
                    case Relation.Above:
                    case Relation.Below:
                    case Relation.ToTheRight:
                    case Relation.ToTheLeft:
                        // Check if this zone is already a floating zone
                        if (blnDidSwitchState)
                        {
                            // In order to re-use all the 'live' objects we need to reset all the descriptors in the controls' hierarchy
                            (objContainer as IDescriptable).ResetDescriptorsTree(this.ZoneType == ZoneType.Root ? ZoneType.Dock : this.ZoneType, GetDockingPositionInRelationToRootZone(enmRelation));
                            objTransferedWindows = objContainer.Windows.ToArray();
                        }

                        // Split this zone.
                        DockedManagerHelper.SplitControl(this, objRootControl, enmRelation, this.Manager);
                        break;
                    case Relation.Inside:
                        
                        // Get all windows
                        objTransferedWindows = objContainer.Windows.ToArray();

                        // Get all windows from the controls hierarchy and add them inside this zone
                        this.AddWindow(enmRelation, objTransferedWindows);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new Exception("The root control inside a DockedForm must be of type: '" + typeof(Zone).FullName + "' this ZoneType = Floating, or " + typeof(DockedSplitContainer).FullName);
            }

            if (blnDidSwitchState)
            {
                if(this.Manager != null)
                {
                    this.Manager.OnWindowsStateChanged(DockState.Float, this.ZoneType == Forms.ZoneType.Root ? DockState.Tabbed : DockState.Dock, objTransferedWindows);
                }
            }
        }

        /// <summary>
        /// Switches the state of the current window dock.
        /// </summary>
        /// <param name="objDesiredDockState">State of the obj desired dock.</param>
        internal void SwitchCurrentWindowDockState(DockState objDesiredDockState)
        {
            this.CloseZonePopupForm();
            Manager.SwitchWindowsDockState(objDesiredDockState, this.CurrentWindow);
        }

        /// <summary>
        /// Toggles the auto hide.
        /// </summary>
        internal void ToggleAutoHide()
        {
            DockState obSwitchjDockState = DockState.AutoHide;

            // From Dock to auto hide
            if (this.ZoneType == Forms.ZoneType.Dock)
            {
                obSwitchjDockState = DockState.AutoHide;
            }
            // From autoHide to dock
            else if (this.ZoneType == Forms.ZoneType.Hidden)
            {
                obSwitchjDockState = DockState.Dock;
                this.CloseZonePopupForm();
            }
            else
            {
                throw new Exception(string.Format("Zone of type: '{0}', does not support AutoHide", this.ZoneType));
            }

            // Switch the dock state
            Manager.SwitchWindowsDockState(obSwitchjDockState, this.Windows.ToArray());
        }

        /// <summary>
        /// Invokes the parent changed.
        /// </summary>
        internal void InvokeParentChanged()
        {
            OnParentChanged(EventArgs.Empty);
        }

        #endregion Methods

    }
}