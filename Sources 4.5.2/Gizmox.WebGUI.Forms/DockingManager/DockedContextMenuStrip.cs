using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ToolboxItem(false)]
    public class DockedContextMenuStrip : ContextMenuStrip
    {
        #region Fields (7)

        private ToolStripMenuItem mobjAutoHideButton;
        private ToolStripMenuItem mobjDockButton;
        private ToolStripMenuItem mobjFloatButton;
        private ToolStripMenuItem mobjHideButton;
        private ToolStripMenuItem mobjDockCurrentToRoot;
        private ToolStripMenuItem mobjDockAllToRoot;

        private ToolStripMenuItem mobjDockCurrentRight;
        private ToolStripMenuItem mobjDockCurrentBottom;
        private ToolStripMenuItem mobjDockCurrentLeft;
        private ToolStripMenuItem mobjDockCurrentTop;

        private ToolStripSeparator mobjSeperator;

        private ToolStripMenuItem mobjDockAllRight;
        private ToolStripMenuItem mobjDockAllBottom;
        private ToolStripMenuItem mobjDockAllLeft;
        private ToolStripMenuItem mobjDockAllTop;

        private DockingManager mobjManager;
        private ToolStripMenuItem mobjTabDocumentButton;
        private Zone mobjZone;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedContextMenuStrip"/> class.
        /// </summary>
        public DockedContextMenuStrip(DockingManager objManager)
        {
            this.mobjManager = objManager;
            InitializeConponent();
        }

        #endregion Constructors

        #region Methods (9)

        // Public Methods (1) 

        /// <summary>
        /// Shows the specified zone's Context menu.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objPosition">The obj position.</param>
        /// <param name="objDirection">The obj direction.</param>
        public void Show(Zone objZone, Control objControl, Point objPosition, ToolStripDropDownDirection objDirection)
        {
            this.SetZone(objZone);

            this.Show(objControl, objPosition, objDirection);
        }
        // Private Methods (7) 

        /// <summary>
        /// Initializes the conponent.
        /// </summary>
        private void InitializeConponent()
        {
            this.mobjFloatButton = new ToolStripMenuItem();
            this.mobjDockButton = new ToolStripMenuItem();
            this.mobjTabDocumentButton = new ToolStripMenuItem();
            this.mobjAutoHideButton = new ToolStripMenuItem();
            this.mobjHideButton = new ToolStripMenuItem();

            this.mobjDockCurrentToRoot = new ToolStripMenuItem();
            this.mobjDockAllToRoot = new ToolStripMenuItem();

            this.mobjDockCurrentRight = new ToolStripMenuItem();
            this.mobjDockCurrentBottom = new ToolStripMenuItem();
            this.mobjDockCurrentLeft = new ToolStripMenuItem();
            this.mobjDockCurrentTop = new ToolStripMenuItem();

            this.mobjSeperator = new ToolStripSeparator();

            this.mobjDockAllRight = new ToolStripMenuItem();
            this.mobjDockAllBottom = new ToolStripMenuItem();
            this.mobjDockAllLeft = new ToolStripMenuItem();
            this.mobjDockAllTop = new ToolStripMenuItem();


            //
            // mobjFloatButton
            //
            mobjFloatButton.Click += new EventHandler(mobjFloatButton_Click);
            mobjFloatButton.Text = SR.GetString("WGFloating");
            //
            // mobjDockButton
            //
            mobjDockButton.Click += new EventHandler(mobjDockButton_Click);
            mobjDockButton.Text = SR.GetString("WGDockable"); ;
            //
            // mobjTabDocumentButton
            //
            mobjTabDocumentButton.Click += new EventHandler(mobjTabDocumentButton_Click);
            mobjTabDocumentButton.Text = SR.GetString("WGTabbedDocument");
            //
            // mobjAutoHideButton
            //
            mobjAutoHideButton.Click += new EventHandler(mobjAutoHideButton_Click);
            mobjAutoHideButton.Text = SR.GetString("WGAutoHide");
            //
            // mobjHideButton
            //
            mobjHideButton.Click += new EventHandler(mobjHideButton_Click);
            mobjHideButton.Text = SR.GetString("WGHide");
            //
            // mobjDockedToRoot
            //
            this.mobjDockCurrentToRoot.Text = SR.GetString("WGGloballyDockCurrentWindow");
            this.mobjDockCurrentToRoot.DropDownItems.AddRange(new ToolStripItem[] 
            {    
                mobjDockCurrentRight ,
                mobjDockCurrentBottom,
                mobjDockCurrentLeft  ,
                mobjDockCurrentTop      
            });

            //
            // mobjDockAllToRoot
            //
            this.mobjDockAllToRoot.Text = SR.GetString("WGGloballyDockAllWindow");
            this.mobjDockAllToRoot.DropDownItems.AddRange(new ToolStripItem[] 
            {
                mobjDockAllRight     ,
                mobjDockAllBottom    ,
                mobjDockAllLeft      ,
                mobjDockAllTop 
            });

            ResourceHandle objTopGlobalResourceHandle = new SkinResourceHandle(typeof(ZoneSkin), "Top_Global16x16.png");
            ResourceHandle objRightGlobalResourceHandle = new SkinResourceHandle(typeof(ZoneSkin), "Right_Global16x16.png");
            ResourceHandle objBottomGlobalResourceHandle = new SkinResourceHandle(typeof(ZoneSkin), "Bottom_Global16x16.png");
            ResourceHandle objLeftGlobalResourceHandle = new SkinResourceHandle(typeof(ZoneSkin), "Left_Global16x16.png");

            //
            // mobjDockCurrentRight
            //
            this.mobjDockCurrentRight.Text = SR.GetString("WGRight");
            this.mobjDockCurrentRight.Tag = Relation.ToTheRight;
            this.mobjDockCurrentRight.Click += new EventHandler(mobjDockCurrent_Click);
            this.mobjDockCurrentRight.Image = objRightGlobalResourceHandle;
            //
            // mobjDockCurrentBottom
            //
            this.mobjDockCurrentBottom.Text = SR.GetString("WGBottom");
            this.mobjDockCurrentBottom.Tag = Relation.Below;
            this.mobjDockCurrentBottom.Click += new EventHandler(mobjDockCurrent_Click);
            this.mobjDockCurrentBottom.Image = objBottomGlobalResourceHandle;
            //
            // mobjDockCurrentLeft
            //
            this.mobjDockCurrentLeft.Text = SR.GetString("WGLeft");
            this.mobjDockCurrentLeft.Tag = Relation.ToTheLeft;
            this.mobjDockCurrentLeft.Click += new EventHandler(mobjDockCurrent_Click);
            this.mobjDockCurrentLeft.Image = objLeftGlobalResourceHandle;
            //
            // mobjDockCurrentTop
            //
            this.mobjDockCurrentTop.Text = SR.GetString("WGTop");
            this.mobjDockCurrentTop.Tag = Relation.Above;
            this.mobjDockCurrentTop.Click += new EventHandler(mobjDockCurrent_Click);
            this.mobjDockCurrentTop.Image = objTopGlobalResourceHandle;
            //
            // mobjDockAllRight
            //
            this.mobjDockAllRight.Text = SR.GetString("WGRight");
            this.mobjDockAllRight.Tag = Relation.ToTheRight;
            this.mobjDockAllRight.Click += new EventHandler(mobjDockAll_Click);
            this.mobjDockAllRight.Image = objRightGlobalResourceHandle;
            //
            // mobjDockAllBottom
            //
            this.mobjDockAllBottom.Text = SR.GetString("WGBottom");
            this.mobjDockAllBottom.Tag = Relation.Below;
            this.mobjDockAllBottom.Click += new EventHandler(mobjDockAll_Click);
            this.mobjDockAllBottom.Image = objBottomGlobalResourceHandle;
            //
            // mobjDockAllLeft
            //
            this.mobjDockAllLeft.Text = SR.GetString("WGLeft");
            this.mobjDockAllLeft.Tag = Relation.ToTheLeft;
            this.mobjDockAllLeft.Click += new EventHandler(mobjDockAll_Click);
            this.mobjDockAllLeft.Image = objLeftGlobalResourceHandle;
            //
            // mobjDockAllTop
            //
            this.mobjDockAllTop.Text = SR.GetString("WGTop");
            this.mobjDockAllTop.Tag = Relation.Above;
            this.mobjDockAllTop.Click += new EventHandler(mobjDockAll_Click);
            this.mobjDockAllTop.Image = objTopGlobalResourceHandle;

            this.Items.Add(this.mobjFloatButton);
            this.Items.Add(this.mobjDockButton);
            this.Items.Add(this.mobjTabDocumentButton);
            this.Items.Add(this.mobjAutoHideButton);
            this.Items.Add(this.mobjHideButton);
            this.Items.Add(this.mobjDockCurrentToRoot);
            this.Items.Add(this.mobjDockAllToRoot);
        }

        /// <summary>
        /// Handles the Click event of the mobjDockAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjDockAll_Click(object sender, EventArgs e)
        {
            List<DockingWindow> objWindows = this.mobjZone.RemoveAndReturnAllWindows();

            this.mobjManager.AddDockedWindowsInRootPosition((Relation)(sender as ToolStripMenuItem).Tag, objWindows.ToArray());
        }

        /// <summary>
        /// Handles the Click event of the mobjDockCurrent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjDockCurrent_Click(object sender, EventArgs e)
        {
            this.mobjManager.AddDockedWindowsInRootPosition((Relation)(sender as ToolStripMenuItem).Tag, this.mobjZone.RemoveAndReturnCurrentWindow());
        }

        /// <summary>
        /// 
        /// Initializes the items.
        /// </summary>
        private void InitializeItems()
        {
            switch (mobjZone.ZoneType)
            {
                case ZoneType.Dock:
                    this.mobjFloatButton.Enabled = true;
                    this.mobjDockButton.Enabled = false;
                    this.mobjTabDocumentButton.Enabled = true;
                    this.mobjAutoHideButton.Enabled = true;
                    this.mobjHideButton.Enabled = true;
                    this.mobjDockCurrentToRoot.Visible = true;
                    this.mobjDockAllToRoot.Visible = true;
                    break;
                case ZoneType.Float:
                    this.mobjFloatButton.Enabled = false;
                    this.mobjDockButton.Enabled = true;
                    this.mobjTabDocumentButton.Enabled = true;
                    this.mobjAutoHideButton.Enabled = false;
                    this.mobjHideButton.Enabled = true;
                    this.mobjDockCurrentToRoot.Visible = true;
                    this.mobjDockAllToRoot.Visible = true;
                    break;
                case ZoneType.Hidden:
                    this.mobjFloatButton.Enabled = true;
                    this.mobjDockButton.Enabled = true;
                    this.mobjTabDocumentButton.Enabled = true;
                    this.mobjAutoHideButton.Enabled = false;
                    this.mobjHideButton.Enabled = true;
                    this.mobjDockCurrentToRoot.Visible = false;
                    this.mobjDockAllToRoot.Visible = false;
                    break;
                case ZoneType.Root:
                    this.mobjFloatButton.Enabled = true;
                    this.mobjDockButton.Enabled = true;
                    this.mobjTabDocumentButton.Enabled = false;
                    this.mobjAutoHideButton.Enabled = false;
                    this.mobjHideButton.Enabled = true;
                    this.mobjDockCurrentToRoot.Visible = true;
                    this.mobjDockAllToRoot.Visible = true;
                    break;
                default:
                    throw new Exception();
            }

            this.mobjFloatButton.Visible = mobjManager.AllowFloatingWindows;
            this.mobjTabDocumentButton.Visible = mobjManager.AllowTabbedDocuments;
            this.mobjHideButton.Visible = mobjManager.AllowCloseWindows;
        }

        /// <summary>
        /// Handles the Click event of the mobjAutoHideButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjAutoHideButton_Click(object sender, EventArgs e)
        {
            // The Close() call is due to a bug (VWG-10326)
            this.Close();
            mobjZone.ToggleAutoHide();
        }

        /// <summary>
        /// Handles the Click event of the mobjDockButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjDockButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mobjZone.SwitchCurrentWindowDockState(DockState.Dock);
        }

        /// <summary>
        /// Handles the Click event of the mobjFloatButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjFloatButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mobjZone.SwitchCurrentWindowDockState(DockState.Float);
        }

        /// <summary>
        /// Handles the Click event of the mobjHideButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjHideButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mobjZone.HideCurrentWindow();
        }

        /// <summary>
        /// Handles the Click event of the mobjTabDocumentButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjTabDocumentButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mobjZone.SwitchCurrentWindowDockState(DockState.Tabbed);
        }
        // Internal Methods (1) 

        /// <summary>
        /// Sets the zone.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        /// <returns></returns>
        internal DockedContextMenuStrip SetZone(Zone objZone)
        {
            this.mobjZone = objZone;

            // Initialize the items according to the zone's type
            InitializeItems();

			// Check if DockAllToRoot should be enabled
            if (this.mobjZone.Windows.Count > 1)
            {
                this.mobjDockAllToRoot.Enabled = true;
            }
            else
            {
                this.mobjDockAllToRoot.Enabled = false;
            }

            return this;
        }

        #endregion Methods
    }
}