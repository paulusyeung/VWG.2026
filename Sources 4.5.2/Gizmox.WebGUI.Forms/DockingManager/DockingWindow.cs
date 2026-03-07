using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms
{
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal class DockingWindowName
    {
		#region Fields (2) 

        private string mstrWindowName;
        /// <summary>
        /// 
        /// </summary>
        private static DockedWindowNameComparer sobjComparer;

		#endregion Fields 

		#region Properties (2) 

        /// <summary>
        /// Gets the docked window name equlity comparer.
        /// </summary>
        internal static IEqualityComparer<DockingWindowName> DockedWindowNameEqulityComparer
        {
            get
            {
                if (sobjComparer == null)
                {
                    sobjComparer = new DockedWindowNameComparer();
                }

                return sobjComparer;
            }
        }

        /// <summary>
        /// Gets or sets the name of the window.
        /// </summary>
        /// <value>
        /// The name of the window.
        /// </value>
        internal string WindowName
        {
            get { return mstrWindowName; }
            set { mstrWindowName = value; }
        }

		#endregion Properties 

		#region Nested Classes (1) 


        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        private class DockedWindowNameComparer : IEqualityComparer<DockingWindowName>
        {
            #region IEqualityComparer<DockingWindowName> Members

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            public bool Equals(DockingWindowName x, DockingWindowName y)
            {
                return x.WindowName == y.WindowName;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <param name="obj">The obj.</param>
            /// <returns>
            /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            /// <exception cref="T:System.ArgumentNullException">The type of obj is a reference type and obj is null.</exception>
            public int GetHashCode(DockingWindowName obj)
            {
                return obj.GetHashCode();
            }

            #endregion
        }
		#endregion Nested Classes 
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    public class DockingWindow : UserControl, IDescriptable
    {
		#region Fields (5) 

        internal static readonly SerializableEvent EVENT_DOCKEDWINDOWNAMECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingWindow));
        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(DockingWindow), new SerializablePropertyMetadata(null));
        private DockedWindowDescriptor mobjData;
        private ResourceHandle mobjImage;
        private DockedTabControl mobjOwningTabControl;
        private DockingManager mobjManager;
        private Size mobjHiddenZonePopupSize;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockingWindow"/> class.
        /// </summary>
        public DockingWindow()
        {
            this.mobjData = new DockedWindowDescriptor(this);
            this.mobjData.CurrentDockState = DockState.Close;
            InitializeDockedWindow();
        }

		#endregion Constructors 

		#region Properties (9) 

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        public override DockStyle Dock
        {
            get
            { 
                return DockStyle.Fill;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets the last state of the dock.
        /// </summary>
        /// <value>
        /// The last state of the dock.
        /// </value>
        internal DockState LastDockState
        {
            get
            {
                return this.mobjData.LastDockState;
            }
            set
            {
                this.mobjData.LastDockState = value;
            }
        }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        [DefaultValue(null), EditorBrowsable(EditorBrowsableState.Always)]
        public string HeaderText
        {
            get
            {
                return string.IsNullOrEmpty(this.mobjData.HeaderText) ? this.Text : this.mobjData.HeaderText;
            }
            set
            {
                if (this.mobjData.HeaderText != value)
                {
                    this.mobjData.HeaderText = value;

                    if (this.IsSelectedTab)
                    {
                        this.OwningZone.NotifyHeaderTextChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the header tool tip.
        /// </summary>
        /// <value>
        /// The header tool tip.
        /// </value>
        [DefaultValue(null), EditorBrowsable(EditorBrowsableState.Always)]
        public string HeaderToolTip
        {
            get
            {
                return this.mobjData.HeaderToolTip;
            }
            set
            {
                if (this.mobjData.HeaderToolTip != value)
                {
                    this.mobjData.HeaderToolTip = value;

                    if (this.IsSelectedTab)
                    {
                        this.OwningZone.NotifyWindowHeaderAttributeChanged(this);
                    }

                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets the tab header tool tip.
        /// </summary>
        /// <value>
        /// The tab header tool tip.
        /// </value>
        [DefaultValue(null), EditorBrowsable(EditorBrowsableState.Always)]
        public string TabHeaderToolTip
        { 
            get
            {
                return this.mobjData.TabHeaderToolTip;
            }
            set
            {
                if (this.mobjData.TabHeaderToolTip != value)
                {
                    this.mobjData.TabHeaderToolTip = value;

                    if (this.Parent != null && this.Parent is DockedTabPage)
                    {
                        (this.Parent as DockedTabPage).HeaderToolTip = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected tab.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selected tab; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelectedTab 
        {
            get
            {
                if (mobjOwningTabControl != null)
                {
                    return mobjOwningTabControl.IsWindowSelected(this);
                }

                return false;
            }
            set
            {
                if (mobjOwningTabControl != null)
                {
                    mobjOwningTabControl.SetWindowSelectedState(this, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DockingWindow"/> is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closed; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Closed
        {
            get
            {
                return this.CurrentDockState == DockState.Close;
            }
            set
            {
                if (value)
                {
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DockingWindow"/> is pinned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pinned; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Pinned
        {
            get
            {
                return this.CurrentDockState == DockState.AutoHide;
            }
            set
            {
                if (value)
                {
                    Pin();
                }
                else
                {
                    Unpin();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DockingWindow"/> is docked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if docked; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Docked
        {
            get
            {
                return this.CurrentDockState == DockState.Dock;
            }
            set
            {
                if (value)
                {
                    SetDock();
                }
                else
                {
                    SetFloat();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DockingWindow"/> is floated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if floated; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Floated
        {
            get
            {
                return this.CurrentDockState == DockState.Float;
            }
            set
            {
                if (value)
                {
                    SetFloat();
                }
                else
                {
                    SetDock();
                }
            }
        }
        /// <summary>
        /// Gets or sets the state of the current dock.
        /// </summary>
        /// <value>
        /// The state of the current dock.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockState CurrentDockState
        {
            get { return mobjData.CurrentDockState; }
            internal set { mobjData.CurrentDockState = value; }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public DockingManager Manager
        {
            get
            {
                return mobjManager;
            }
            internal set
            {
                mobjManager = value;
            }
        }

        /// <summary>
        /// Gets the docked window descriptor.
        /// </summary>
        internal DockedWindowDescriptor DockedWindowDescriptor
        {
            get { return mobjData; }
        }

        /// <summary>
        /// Gets the docked window descriptor internal.
        /// </summary>
        internal DockedWindowDescriptor DockedWindowDescriptorInternal
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
        /// Gets or sets the image that is displayed on a button control.
        /// </summary>
        public ResourceHandle Image
        {
            get
            {
                return mobjImage;
            }
            set
            {
                if (value != mobjImage)
                {
                    mobjImage = value;

                    // Check if this window is contained in a tab control
                    if (this.OwningTabControl != null)
                    {
                        this.OwningTabControl.WindowImageChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the name associated with this control.
        /// </summary>
        [Browsable(false)]
        public new string Name
        {
            get
            {
                return this.WindowName.WindowName;
            }
            set
            {
                if (this.Name != value)
                {
                    base.Name = value;

                    this.WindowName.WindowName = value;

                    this.mobjData.UpdateSelf(this, null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the owning tab control.
        /// </summary>
        /// <value>
        /// The owning tab control.
        /// </value>
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal DockedTabControl OwningTabControl
        {
            get { return mobjOwningTabControl; }
            set { mobjOwningTabControl = value; }
        }

        /// <summary>
        /// Gets the owning zone.
        /// </summary>
        internal Zone OwningZone
        {
            get
            {
                if (this.OwningTabControl != null && this.OwningTabControl.OwningZone != null)
                {
                    return this.OwningTabControl.OwningZone;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the window.
        /// </summary>
        /// <value>
        /// The name of the window.
        /// </value>
        internal DockingWindowName WindowName
        {
            get
            {
                return this.mobjData.WindowName;
            }
            set
            {
                this.Name = value.WindowName;
            }
        }

        /// <summary>
        /// Gets or sets the size of the hidden zone.
        /// </summary>
        /// <value>
        /// The size of the hidden zone.
        /// </value>
        public System.Drawing.Size HiddenZonePopupSize
        {
            get
            {
                return mobjHiddenZonePopupSize;
            }
            set
            {
                mobjHiddenZonePopupSize = value;
            }
        }

		#endregion Properties 

		#region Methods (4) 

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderHeaderToolTip(objWriter, false);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderHeaderToolTip(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the header tool tip.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderHeaderToolTip(Common.Interfaces.IAttributeWriter objWriter, bool blnForceRender)
        {
            string strHeaderToolTip = this.HeaderToolTip;

            if (!string.IsNullOrEmpty(strHeaderToolTip) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ZoneHeaderToolTip, strHeaderToolTip);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Text;
        }

        /// <summary>
        /// Conceals the control from the user.
        /// </summary>
        public new void Hide()
        {
            if (Manager != null && this.CurrentDockState != DockState.Hidden)
            {
                Manager.SwitchWindowsDockState(DockState.Hidden, this);
            }
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (Manager != null && this.CurrentDockState != DockState.Close)
            {
                Manager.SwitchWindowsDockState(DockState.Close, this);
            }
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            switch (this.CurrentDockState)
            {
                case DockState.AutoHide:
                    string strPanelDockingSide = string.Empty;

                    // Init the corretc panel side according to the zone's docking position
                    switch (this.OwningZone.DockingPosition)
                    {
                        case DockStyle.Top:
                            strPanelDockingSide = WGAttributes.Top;
                            break;
                        case DockStyle.Right:
                            strPanelDockingSide = WGAttributes.Right;
                            break;
                        case DockStyle.Bottom:
                            strPanelDockingSide = WGAttributes.Bottom;
                            break;
                        case DockStyle.Left:
                            strPanelDockingSide = WGAttributes.Left;
                            break;
                        case DockStyle.None:
                        case DockStyle.Fill:
                        default:
                            throw new NotSupportedException();
                    }

                    // Invoke the Show zone popup function on the client
                    this.OwningZone.ContainingHiddenPanel.InvokeMethodInternal("DockedHiddenZonesPanel_ShowZonePopUp", this.OwningZone.ContainingHiddenPanel.ID, this.OwningZone.ID, this.Manager.ID, strPanelDockingSide, this.OwningZone.ContainingHiddenPanel.DockPadding.Right, this.OwningZone.ContainingHiddenPanel.DockPadding.Left);
                    break;
                case DockState.Hidden:
                case DockState.Close:
                    // If the window is not auto hidden, just show the window
                    this.Manager.ShowHiddenWindow(this);
                    break;
                case DockState.Float:
                case DockState.Dock:
                case DockState.Tabbed:
                    this.IsSelectedTab = true;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Pins this instance.
        /// </summary>
        public void Pin()
        {
            if (this.Manager != null)
            {
                if (this.CurrentDockState == DockState.AutoHide)
                {
                    Manager.SwitchWindowsDockState(DockState.Dock, this);
                }
            }
        }

        /// <summary>
        /// Unpins this instance.
        /// </summary>
        public void Unpin()
        {
            if (this.Manager != null)
            {
                if (this.CurrentDockState == DockState.Dock)
                {
                    Manager.SwitchWindowsDockState(DockState.AutoHide, this);
                }
            }
        }

        /// <summary>
        /// Sets the float.
        /// </summary>
        public void SetFloat()
        {
            if (this.Manager != null)
            {
                if (this.CurrentDockState != DockState.Float)
                {
                    Manager.SwitchWindowsDockState(DockState.Float, this);
                }
            }
        }

        /// <summary>
        /// Sets the dock.
        /// </summary>
        public void SetDock()
        {
            if (this.Manager != null)
            {
                if (this.CurrentDockState != DockState.Dock)
                {
                    Manager.SwitchWindowsDockState(DockState.Dock, this);
                }
            }
        }

		// Protected Methods (1) 

        /// <summary>
        /// Raises the <see cref="E:TextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Parent is DockedTabPage)
            {
                this.Parent.Text = this.Text;
            }

            if (this.IsSelectedTab)
            {
                this.OwningZone.NotifyWindowHeaderAttributeChanged(this);
            }

            this.mobjData.UpdateSelf(this, null);
        }
		// Private Methods (3) 

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            DockedWindowDescriptor objDockedWindowDescriptor = objDescriptor as DockedWindowDescriptor;
            this.WindowName = objDockedWindowDescriptor.WindowName;
            this.Text = objDockedWindowDescriptor.Text;

            this.mobjData = objDescriptor as DockedWindowDescriptor;
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

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeDockedWindow()
        {
            base.Dock = DockStyle.Fill;
        }

		#endregion Methods 
    
    }
}