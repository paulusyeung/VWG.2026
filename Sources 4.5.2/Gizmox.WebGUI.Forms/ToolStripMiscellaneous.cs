using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Common.Resources;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Extensibility;

namespace Gizmox.WebGUI.Forms
{
    #region ToolStripContentPanel Class

    /// <summary>Represents the center panel of a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> control.</summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [InitializationEvent("Load")]
    [DefaultEvent("Load")]
    [ToolboxItem(false)]
    [Serializable()]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripContentPanel : Panel
    {
        #region Members

        private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof(EventHandler), typeof(ToolStripContentPanel)); 

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> class. </summary>
        public ToolStripContentPanel()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLoad(EventArgs e)
        {
            EventHandler objEventHandler = this.LoadHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.OnLoad(EventArgs.Empty);
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripContentPanel.RendererChanged"></see> event. </summary> 
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRendererChanged(EventArgs e)
        {
        }

        #endregion Methods

        #region Events

        /// <summary>This event is not relevant to this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler AutoSizeChanged
        {
            add
            {
                base.AutoSizeChanged += value;
            }
            remove
            {
                base.AutoSizeChanged -= value;
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler CausesValidationChanged
        {
            add
            {
                base.CausesValidationChanged += value;
            }
            remove
            {
                base.CausesValidationChanged -= value;
            }
        }

        /// <summary>This event is not relevant to this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler DockChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the content panel loads.</summary>
        [SRDescription("ToolStripContentPanelOnLoadDescr"), SRCategory("CatBehavior")]
        public event EventHandler Load
        {
            add
            {
                this.AddCriticalHandler(ToolStripContentPanel.LoadEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(ToolStripContentPanel.LoadEvent, value);
            }
        }

        /// <summary>
        /// Gets the Load handler.
        /// </summary>
        /// <value>The Load handler.</value>
        private EventHandler LoadHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ToolStripContentPanel.LoadEvent);
            }
        }

        /// <summary>This event is not relevant to this class.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler LocationChanged
        {
            add
            {
                base.LocationChanged += value;
            }
            remove
            {
                base.LocationChanged -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripContentPanel.Renderer"></see> property changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler RendererChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabIndexChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabStopChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        #endregion Events

        #region Properties

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.AnchorStyles"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }
            set
            {
                base.Anchor = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true to enable automatic scrolling; otherwise, false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size AutoScrollMargin
        {
            get
            {
                return Size.Empty;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size AutoScrollMinSize
        {
            get
            {
                return Size.Empty;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true to enable automatic sizing; otherwise, false.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.AutoSizeMode"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false), Localizable(false)]
        public override AutoSizeMode AutoSizeMode
        {
            get
            {
                return AutoSizeMode.GrowOnly;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if the control causes validation; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public bool CausesValidation
        {
            get
            {
                return base.CausesValidation;
            }
            set
            {
                base.CausesValidation = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.DockStyle"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Point"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public Point Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.String"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        /// <summary>Gets or sets a <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> that handles painting.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripRenderer Renderer
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the painting styles to be applied to the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripRenderMode"></see> values. </returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripRenderMode RenderMode
        {
            get
            {
                return ToolStripRenderMode.Custom;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Int32"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int TabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                base.TabIndex = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> can be tabbed to; otherwise, false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripContentPanel Class

    #region AutoCompleteStringCollection Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class AutoCompleteStringCollection : IList, ICollection, IEnumerable
    {
        #region Members

        private ArrayList mobjData = new ArrayList();
        private CollectionChangeEventHandler mobjCollectionChanged;

        #endregion

        #region Properties

        /// <filterpriority>1</filterpriority>
        public int Count
        {
            get
            {
                return this.mobjData.Count;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (string)value;
            }
        }

        /// <filterpriority>1</filterpriority>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <filterpriority>2</filterpriority>
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <filterpriority>1</filterpriority>
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        /// <filterpriority>1</filterpriority>
        public string this[int index]
        {
            get
            {
                return (string)this.mobjData[index];
            }
            set
            {
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, this.mobjData[index]));
                this.mobjData[index] = value;
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Occurs when [collection changed].
        /// </summary>
        public event CollectionChangeEventHandler CollectionChanged
        {
            add
            {
                this.mobjCollectionChanged = (CollectionChangeEventHandler)Delegate.Combine(this.mobjCollectionChanged, value);
            }
            remove
            {
                this.mobjCollectionChanged = (CollectionChangeEventHandler)Delegate.Remove(this.mobjCollectionChanged, value);
            }
        }

        #endregion

        #region Methods

        /// <filterpriority>1</filterpriority>
        public int Add(string value)
        {
            int num = this.mobjData.Add(value);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
            return num;
        }

        /// <filterpriority>1</filterpriority>
        public void AddRange(string[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            this.mobjData.AddRange(value);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <filterpriority>1</filterpriority>
        public void Clear()
        {
            this.mobjData.Clear();
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <filterpriority>1</filterpriority>
        public bool Contains(string value)
        {
            return this.mobjData.Contains(value);
        }

        /// <filterpriority>1</filterpriority>
        public void CopyTo(string[] array, int index)
        {
            this.mobjData.CopyTo(array, index);
        }

        /// <filterpriority>1</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return this.mobjData.GetEnumerator();
        }

        /// <filterpriority>1</filterpriority>
        public int IndexOf(string value)
        {
            return this.mobjData.IndexOf(value);
        }

        /// <filterpriority>1</filterpriority>
        public void Insert(int index, string value)
        {
            this.mobjData.Insert(index, value);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
        }

        /// <filterpriority>1</filterpriority>
        public void Remove(string value)
        {
            this.mobjData.Remove(value);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, value));
        }

        /// <filterpriority>1</filterpriority>
        public void RemoveAt(int index)
        {
            string element = (string)this.mobjData[index];
            this.mobjData.RemoveAt(index);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, element));
        }

        protected void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (this.mobjCollectionChanged != null)
            {
                this.mobjCollectionChanged(this, e);
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            this.mobjData.CopyTo(array, index);
        }

        int IList.Add(object value)
        {
            return this.Add((string)value);
        }

        bool IList.Contains(object value)
        {
            return this.Contains((string)value);
        }

        int IList.IndexOf(object value)
        {
            return this.IndexOf((string)value);
        }

        void IList.Insert(int index, object value)
        {
            this.Insert(index, (string)value);
        }

        void IList.Remove(object value)
        {
            this.Remove((string)value);
        }

        #endregion Methods
    }

    #endregion

    #region ToolStripPanelRow Class

    /// <summary>Represents a row of a <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that can contain controls.</summary>
    [ToolboxItem(false)]
    [Serializable()]
    public class ToolStripPanelRow : Component, IComponent, IDisposable
    {
        #region Members

        private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register("mobjBounds", typeof(Rectangle), typeof(ToolStripPanelRow));
        private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register("mobjParent", typeof(ToolStripPanel), typeof(ToolStripPanelRow));
        private static readonly SerializableProperty mobjControlsProperty = SerializableProperty.Register("mobjControls", typeof(List<Control>), typeof(ToolStripPanelRow));
        private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register("mobjPadding", typeof(Padding), typeof(ToolStripPanelRow));
        private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register("mobjMargin", typeof(Padding), typeof(ToolStripPanelRow));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> class, specifying the containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>. </summary> 
        ///<param name="parent">The containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
        public ToolStripPanelRow(ToolStripPanel parent) : this(parent, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripPanelRow"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        internal ToolStripPanelRow(ToolStripPanel parent, bool visible)
        {
            this.mobjBounds = Rectangle.Empty;
            this.mobjParent = parent;
            this.Margin = this.DefaultMargin;
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> can be dragged and dropped into a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
        ///<returns>true if there is enough space in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to receive the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false. </returns> 
        ///<param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be dragged and dropped into the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanMove(ToolStrip toolStripToDrag)
        {
            return false;
        }

        ///<summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property changes.</summary> 
        ///<param name="newBounds">The new value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param> 
        ///<param name="oldBounds">The original value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected void OnBoundsChanged(Rectangle oldBounds, Rectangle newBounds)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Layout"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnLayout(LayoutEventArgs e)
        {
        }

        #endregion Methods

        #region Properties

        #region Property Store

        private Rectangle mobjBounds
        {
            get
            {
                return this.GetValue<Rectangle>(ToolStripPanelRow.mobjBoundsProperty);
            }
            set
            {
                this.SetValue<Rectangle>(ToolStripPanelRow.mobjBoundsProperty, value);
            }
        }

        private ToolStripPanel mobjParent
        {
            get
            {
                return this.GetValue<ToolStripPanel>(ToolStripPanelRow.mobjParentProperty);
            }
            set
            {
                this.SetValue<ToolStripPanel>(ToolStripPanelRow.mobjParentProperty, value);
            }
        }

        private List<Control> mobjControls
        {
            get
            {
                return this.GetValue<List<Control>>(ToolStripPanelRow.mobjControlsProperty, null);
            }
            set
            {
                this.SetValue<List<Control>>(ToolStripPanelRow.mobjControlsProperty, value);
            }
        }

        private Padding mobjPadding
        {
            get
            {
                return this.GetValue<Padding>(ToolStripPanelRow.mobjPaddingProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStripPanelRow.mobjPaddingProperty, value);
            }
        }

        private Padding mobjMargin
        {
            get
            {
                return this.GetValue<Padding>(ToolStripPanelRow.mobjMarginProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStripPanelRow.mobjMarginProperty, value);
            }
        }
        
        #endregion

        ///<summary>Gets the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>, including its nonclient elements, in pixels, relative to the parent control.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
        public Rectangle Bounds
        {
            get
            {
                return this.mobjBounds;
            }
        }

        /// <summary>
        /// Gets the controls internal.
        /// </summary>
        /// <value>The controls internal.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRDescription("ControlControlsDescr")]
        internal List<Control> ControlsInternal
        {
            get
            {
                if (mobjControls == null)
                {
                    mobjControls = new List<Control>();
                }

                return mobjControls;
            }
        }

        ///<summary>Gets the controls in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
        ///<returns>An array of controls.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlControlsDescr"), Browsable(false)]
        public Control[] Controls
        {
            get
            {
                return ControlsInternal.ToArray();
            }
        }

        /// <summary>Gets the space, in pixels, that is specified by default between controls.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the default space between controls.</returns>
        protected virtual Padding DefaultMargin
        {
            get
            {
                Padding rowMargin = this.ToolStripPanel.RowMargin;
                if (this.Orientation == Orientation.Horizontal)
                {
                    rowMargin.Left = 0;
                    rowMargin.Right = 0;
                    return rowMargin;
                }
                rowMargin.Top = 0;
                rowMargin.Bottom = 0;
                return rowMargin;
            }
        }

        /// <summary>Gets the internal spacing, in pixels, of the contents of a control.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the internal spacing of the contents of a control.</returns>
        protected virtual Padding DefaultPadding
        {
            get
            {
                return Padding.Empty;
            }
        }

        /// <summary>Gets the display area of the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle DisplayRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets an instance of the control's layout engine.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> for the control's contents.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutEngine LayoutEngine
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets or sets the space between controls.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
        public Padding Margin
        {
            get
            {
                return mobjMargin;
            }
            set
            {
                if (this.Margin != value)
                {
                    mobjMargin = value;
                    // TODO: Update client
                }
            }
        }

        /// <summary>Gets the layout direction of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> relative to its containing <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
        public Orientation Orientation
        {
            get
            {
                return this.ToolStripPanel.Orientation;
            }
        }

        /// <summary>Gets or sets padding within the control.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> representing the control's internal spacing characteristics.</returns>
        public virtual Padding Padding
        {
            get
            {
                return mobjPadding;
            }
            set
            {
                if (this.Padding != value)
                {
                    mobjPadding = value;
                    // TODO: Update client
                }
            }
        }

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</returns>
        public ToolStripPanel ToolStripPanel
        {
            get
            {
                return this.mobjParent;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripPanelRow Class

    #region ToolStripPanel Class

    /// <summary>Creates a container within which other controls can share horizontal or vertical space.</summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [MetadataTag(WGTags.ToolStripPanel)]
    [Serializable(), Skin(typeof(ToolStripPanelSkin))]
#if WG_NET46
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class ToolStripPanel : ContainerControl, IArrangedElement, IComponent, IDisposable
    {
        /// <summary>Represents all the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects in a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
        [ComVisible(false), ListBindable(false)]
        [Serializable()]
        public class ToolStripPanelRowCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
        {
            #region Members

            private ToolStripPanel mobjOwner;

            #endregion

            #region Constructors

            /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class with the specified number of rows in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
            /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            /// <param name="value">The number of rows in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            public ToolStripPanelRowCollection(ToolStripPanel owner, ToolStripPanelRow[] value)
            {
                this.mobjOwner = owner;
                this.AddRange(value);
            }

            /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>. </summary>
            /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            public ToolStripPanelRowCollection(ToolStripPanel owner)
            {
                this.mobjOwner = owner;
            }

            #endregion Constructors

            #region Properties

            bool IList.IsFixedSize
            {
                get
                {
                    return base.InnerList.IsFixedSize;
                }
            }

            bool IList.IsReadOnly
            {
                get
                {
                    return base.InnerList.IsReadOnly;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return base.InnerList[index];
                }
                set
                {
                    throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
                }
            }

            /// <summary>Gets a particular <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <returns>The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> as specified by the index parameter.</returns>
            /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            public virtual ToolStripPanelRow this[int index]
            {
                get
                {
                    return (ToolStripPanelRow)base.InnerList[index];
                }
            }

            #endregion Properties

            #region Methods

            /// <summary>Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <returns>The position of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</returns>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public int Add(ToolStripPanelRow value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                int index = base.InnerList.Add(value);
                this.OnAdd(value, index);
                return index;
            }

            /// <summary>Adds an array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
            /// <param name="value">An array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public void AddRange(ToolStripPanelRow[] value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                ToolStripPanel owner = this.mobjOwner;
                if (owner != null)
                {
                    owner.SuspendLayout();
                }
                try
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        this.Add(value[i]);
                    }
                }
                finally
                {
                    if (owner != null)
                    {
                        owner.ResumeLayout();
                    }
                }
            }

            /// <summary>Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public void AddRange(ToolStripPanel.ToolStripPanelRowCollection value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                ToolStripPanel owner = this.mobjOwner;
                if (owner != null)
                {
                    owner.SuspendLayout();
                }
                try
                {
                    int count = value.Count;
                    for (int i = 0; i < count; i++)
                    {
                        this.Add(value[i]);
                    }
                }
                finally
                {
                    if (owner != null)
                    {
                        owner.ResumeLayout();
                    }
                }
            }

            /// <summary>Removes all <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            public virtual void Clear()
            {
                if (this.mobjOwner != null)
                {
                    this.mobjOwner.SuspendLayout();
                }
                try
                {
                    while (this.Count != 0)
                    {
                        this.RemoveAt(this.Count - 1);
                    }
                }
                finally
                {
                    if (this.mobjOwner != null)
                    {
                        this.mobjOwner.ResumeLayout();
                    }
                }
            }

            /// <summary>Determines whether the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <returns>true if the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>; otherwise, false.</returns>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
            public bool Contains(ToolStripPanelRow value)
            {
                return base.InnerList.Contains(value);
            }

            /// <summary>Copies the entire <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> into an existing array at a specified location within the array.</summary>
            /// <param name="array">An <see cref="T:System.Array"></see> representing the array to copy the contents of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
            /// <param name="index">The location within the destination array to copy the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
            public void CopyTo(ToolStripPanelRow[] array, int index)
            {
                base.InnerList.CopyTo(array, index);
            }

            /// <summary>Gets the index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <returns>The index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</returns>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to return the index of.</param>
            public int IndexOf(ToolStripPanelRow value)
            {
                return base.InnerList.IndexOf(value);
            }

            /// <summary>Inserts the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified location in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to insert.</param>
            /// <param name="index">The zero-based index at which to insert the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public void Insert(int index, ToolStripPanelRow value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                base.InnerList.Insert(index, value);
                this.OnAdd(value, index);
            }

            /// <summary>Removes the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
            public void Remove(ToolStripPanelRow value)
            {
                base.InnerList.Remove(value);
                this.OnAfterRemove(value);
            }

            /// <summary>Removes the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified index from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
            /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
            public void RemoveAt(int index)
            {
                ToolStripPanelRow row = null;
                if ((index < this.Count) && (index >= 0))
                {
                    row = (ToolStripPanelRow)base.InnerList[index];
                }
                base.InnerList.RemoveAt(index);
                this.OnAfterRemove(row);
            }

            int IList.Add(object value)
            {
                return this.Add(value as ToolStripPanelRow);
            }

            void IList.Clear()
            {
                this.Clear();
            }

            bool IList.Contains(object value)
            {
                return base.InnerList.Contains(value);
            }

            int IList.IndexOf(object value)
            {
                return this.IndexOf(value as ToolStripPanelRow);
            }

            void IList.Insert(int index, object value)
            {
                this.Insert(index, value as ToolStripPanelRow);
            }

            void IList.Remove(object value)
            {
                this.Remove(value as ToolStripPanelRow);
            }

            void IList.RemoveAt(int index)
            {
                this.RemoveAt(index);
            }

            private void OnAdd(ToolStripPanelRow value, int index)
            {
                if (this.mobjOwner != null)
                {
                    this.mobjOwner.Update();
                }
            }

            private void OnAfterRemove(ToolStripPanelRow row)
            {
            }


            #endregion Methods
        }

        #region Members

        private static readonly SerializableProperty mobjToolStripPanelRowCollectionProperty = SerializableProperty.Register("mobjToolStripPanelRowCollection", typeof(ToolStripPanelRowCollection), typeof(ToolStripPanel));
        private static readonly SerializableProperty mobjRowMarginProperty = SerializableProperty.Register("mobjRowMargin", typeof(Padding), typeof(ToolStripPanel));
        private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register("menmOrientation", typeof(Orientation), typeof(ToolStripPanel));
        private static readonly SerializableProperty mblnLockedProperty = SerializableProperty.Register("mblnLocked", typeof(bool), typeof(ToolStripPanel));
        private static readonly SerializableProperty mobjOwnerToolStripContainerProperty = SerializableProperty.Register("mobjOwnerToolStripContainer", typeof(ToolStripContainer), typeof(ToolStripPanel));

        #endregion

        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> class. </summary>
        public ToolStripPanel()
        {
            this.mobjRowMargin = new Padding(3, 0, 0, 0);
            base.SuspendLayout();
            this.AutoSize = true;
            this.MinimumSize = Size.Empty;
            mblnLocked = false;
            this.TabStop = false;
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.Selectable, false);
            base.ResumeLayout(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripPanel"/> class.
        /// </summary>
        /// <param name="objOwnerToolStripContainer">The owner tool strip container.</param>
        internal ToolStripPanel(ToolStripContainer objOwnerToolStripContainer) : this()
        {
            this.mobjOwnerToolStripContainer = objOwnerToolStripContainer;
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void BeginInit()
        {
        }

        ///<summary>Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void EndInit()
        {
        }

        ///<summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
        public void Join(ToolStrip toolStripToDrag)
        {
            this.Join(toolStripToDrag, Point.Empty);
        }

        ///<summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> in the specified row.</summary> 
        ///<param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
        ///<param name="row">An <see cref="T:System.Int32"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is added.</param> 
        ///<exception cref="T:System.ArgumentOutOfRangeException">The row parameter is less than zero (0).</exception>
        public void Join(ToolStrip toolStripToDrag, int row)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException("row", SR.GetString("IndexOutOfRange", new object[] { row.ToString(CultureInfo.CurrentCulture) }));
            }

            this.Join(toolStripToDrag, Point.Empty);
        }

        ///<summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified coordinates.</summary> 
        ///<param name="y">The vertical client coordinate, in pixels.</param> 
        ///<param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
        ///<param name="x">The horizontal client coordinate, in pixels.</param>
        public void Join(ToolStrip toolStripToDrag, int x, int y)
        {
            this.Join(toolStripToDrag, new Point(x, y));
        }

        ///<summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified location.</summary> 
        ///<param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
        ///<param name="location">A <see cref="T:System.Drawing.Point"></see> value representing the x- and y-client coordinates, in pixels, of the new location for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
        public void Join(ToolStrip toolStripToDrag, Point location)
        {
            if (toolStripToDrag == null)
            {
                throw new ArgumentNullException("toolStripToDrag");
            }

            toolStripToDrag.ParentInternal = this;
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripPanel.RendererChanged"></see> event.</summary> 
        ///<param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRendererChanged(EventArgs e)
        {
        }

        ///<summary>Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> given a point within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> client area.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> that contains the raftingContainerPoint, or null if no such <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> exists.</returns> 
        ///<param name="clientLocation">A <see cref="T:System.Drawing.Point"></see> used as a reference to find the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
        public ToolStripPanelRow PointToRow(Point clientLocation)
        {
            foreach (ToolStripPanelRow row in this.RowsInternal)
            {
                Rectangle rectangle = LayoutUtils.InflateRect(row.Bounds, row.Margin);
                if (this.ParentInternal != null)
                {
                    if ((this.Orientation == Orientation.Horizontal) && (rectangle.Width == 0))
                    {
                        rectangle.Width = this.ParentInternal.DisplayRectangle.Width;
                    }
                    else if ((this.Orientation == Orientation.Vertical) && (rectangle.Height == 0))
                    {
                        rectangle.Height = this.ParentInternal.DisplayRectangle.Height;
                    }
                }
                if (rectangle.Contains(clientLocation))
                {
                    return row;
                }
            }
            return null;
        }

        #endregion Methods

        #region Events

        /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripPanel.AutoSize"></see> property changes. </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler AutoSizeChanged
        {
            add
            {
                base.AutoSizeChanged += value;
            }
            remove
            {
                base.AutoSizeChanged -= value;
            }
        }

        ///<summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanel.Renderer"></see> property changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler RendererChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabIndexChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler TabStopChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>This event is not relevant for this class.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        #endregion Events

        #region Properties

        #region Proprety Store

        private ToolStripPanelRowCollection mobjToolStripPanelRowCollection
        {
            get
            {
                return this.GetValue<ToolStripPanelRowCollection>(ToolStripPanel.mobjToolStripPanelRowCollectionProperty, null);
            }
            set
            {
                this.SetValue<ToolStripPanelRowCollection>(ToolStripPanel.mobjToolStripPanelRowCollectionProperty, value);
            }
        }

        private Padding mobjRowMargin
        {
            get
            {
                return this.GetValue<Padding>(ToolStripPanel.mobjRowMarginProperty);
            }
            set
            {
                this.SetValue<Padding>(ToolStripPanel.mobjRowMarginProperty, value);
            }
        }

        private Orientation menmOrientation
        {
            get
            {
                return this.GetValue<Orientation>(ToolStripPanel.menmOrientationProperty);
            }
            set
            {
                this.SetValue<Orientation>(ToolStripPanel.menmOrientationProperty, value);
            }
        }

        private bool mblnLocked
        {
            get
            {
                return this.GetValue<bool>(ToolStripPanel.mblnLockedProperty);
            }
            set
            {
                this.SetValue<bool>(ToolStripPanel.mblnLockedProperty, value);
            }
        }

        private ToolStripContainer mobjOwnerToolStripContainer
        {
            get
            {
                return this.GetValue<ToolStripContainer>(ToolStripPanel.mobjOwnerToolStripContainerProperty, null);
            }
            set
            {
                this.SetValue<ToolStripContainer>(ToolStripPanel.mobjOwnerToolStripContainerProperty, value);
            }
        }

        #endregion

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size AutoScrollMargin
        {
            get
            {
                return Size.Empty; ;
            }
            set
            {
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size AutoScrollMinSize
        {
            get
            {
                return Size.Empty; ;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically adjusts its size when the form is resized.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically resizes; otherwise, false. The default is true.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }


        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        /// <value></value>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
                if ((value == DockStyle.Left) || (value == DockStyle.Right))
                {
                    this.Orientation = Orientation.Vertical;
                }
                else
                {
                    this.Orientation = Orientation.Horizontal;
                }
            }
        }

        /// <summary>
        /// Gets the layout engine.
        /// </summary>
        /// <value>The layout engine.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual LayoutEngine LayoutEngine
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized; otherwise, false. The default is false.</returns>
        [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool Locked
        {
            get
            {
                return mblnLocked;
            }
            set
            {
                if (mblnLocked != value)
                {
                    mblnLocked = value;
                    // TODO: Update client
                }
            }
        }

        /// <summary>Gets or sets a value indicating the horizontal or vertical orientation of the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
        public Orientation Orientation
        {
            get
            {
                return this.menmOrientation;
            }
            set
            {
                if (this.menmOrientation != value)
                {
                    this.menmOrientation = value;
                    this.mobjRowMargin = LayoutUtils.FlipPadding(this.mobjRowMargin);
                }
            }
        }

        ///<summary>Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> that handles painting.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripRenderer Renderer
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripRenderMode RenderMode
        {
            get
            {
                return ToolStripRenderMode.Custom;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the spacing, in pixels, between the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s and the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> value representing the spacing, in pixels.</returns>
        public Padding RowMargin
        {
            get
            {
                return this.mobjRowMargin;
            }
            set
            {
                this.mobjRowMargin = value;
            }
        }

        /// <summary>
        /// Gets the rows internal.
        /// </summary>
        /// <value>The rows internal.</value>
        [Browsable(false), SRDescription("ToolStripPanelRowsDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        internal ToolStripPanelRowCollection RowsInternal
        {
            get
            {
                if (mobjToolStripPanelRowCollection == null)
                {
                    mobjToolStripPanelRowCollection = new ToolStripPanelRowCollection(this);
                }

                return mobjToolStripPanelRowCollection;
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> representing the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ToolStripPanelRowsDescr"), Browsable(false)]
        public ToolStripPanelRow[] Rows
        {
            get
            {
                ToolStripPanelRow[] array = new ToolStripPanelRow[this.RowsInternal.Count];
                this.RowsInternal.CopyTo(array, 0);
                return array;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>An <see cref="T:System.Int32"></see> representing the tab index.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public int TabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                base.TabIndex = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        /// <summary>This property is not relevant to this class.</summary>
        /// <returns>A <see cref="T:System.String"></see> representing the display text.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        ArrangedElementCollection IArrangedElement.Children
        {
            get
            {
                return this.RowsInternal;
            }
        }

        #endregion Properties
    }

    #endregion ToolStripPanel Class

    #region ToolStripRenderer Class

    /// <summary>Handles the painting functionality for <see cref="T:System.Windows.Forms.ToolStrip"></see> objects.</summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility")]
    public abstract class ToolStripRenderer
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> class. </summary>
        [Obsolete("Not implemented. Added for migration compatibility")]
        protected ToolStripRenderer()
        {
        }

        #endregion C'Tors

        #region Methods

        ///<summary>Creates a gray-scale copy of a given image.</summary> 
        ///<returns>An <see cref="T:System.Drawing.Image"></see> that is a copy of the given image, but with a gray-scale color matrix.</returns> 
        ///<param name="normalImage">The image to be copied. </param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ResourceHandle CreateDisabledImage(ResourceHandle normalImage)
        {
            return null;
        }

        ///<summary>Draws an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains data to draw the arrow.</param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawArrow(ToolStripArrowRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</summary> 
        ///<param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains data to draw the button's background.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the drop-down button's background.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws a move handle on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the data to draw the move handle.</param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawGrip(ToolStripGripRenderEventArgs e)
        {
        }

        ///<summary>Draws the space around an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the space around the image.</param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawImageMargin(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background of the item.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawItemBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that indicates the item is in a selected state.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the selected image.</param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawItemCheck(ToolStripItemImageRenderEventArgs e)
        {
        }

        ///<summary>Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the image.</param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawItemImage(ToolStripItemImageRenderEventArgs e)
        {
        }

        ///<summary>Draws text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the data to draw the text.</param> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawItemText(ToolStripItemTextRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the label.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawLabelBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the menu item.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for an overflow button.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the data to draw the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawSeparator(ToolStripSeparatorRenderEventArgs e)
        {
        }

        ///<summary>Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawSplitButton(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Draws a sizing grip.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the background for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawToolStripBackground(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Draws the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the border for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawToolStripBorder(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
        }

        ///<summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
        }

        ///<summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderArrow"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderButtonBackground"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderDropDownButtonBackground"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderGrip"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
        }

        ///<summary>Draws the item background.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSystemRenderer.OnRenderItemBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemCheck"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemImage"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemText"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderLabelBackground"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderMenuItemBackground"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderOverflowButtonBackground"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderSeparator"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripRenderer.OnRenderSplitButtonBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderStatusStripSizingGrip"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBackground"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBorder"></see> event. </summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripContentPanelBackground"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripPanelBackground"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
        }

        ///<summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripStatusLabelBackground"></see> event.</summary> 
        ///<param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
        }

        #endregion Methods

        #region Events

        ///<summary>Occurs when an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripArrowRenderEventHandler RenderArrow
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is rendered</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderButtonBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderDropDownButtonBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the move handle for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripGripRenderEventHandler RenderGrip
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Draws the margin between an image and its container. </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripRenderEventHandler RenderImageMargin
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderItemBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the image for a selected <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemImageRenderEventHandler RenderItemCheck
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the image for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemImageRenderEventHandler RenderItemImage
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the text for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemTextRenderEventHandler RenderItemText
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderLabelBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderMenuItemBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for an overflow button is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderOverflowButtonBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is rendered.</summary> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripSeparatorRenderEventHandler RenderSeparator
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderSplitButtonBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the display style changes.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripRenderEventHandler RenderStatusStripSizingGrip
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripRenderEventHandler RenderToolStripBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Occurs when the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripRenderEventHandler RenderToolStripBorder
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripContentPanelRenderEventHandler RenderToolStripContentPanelBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripPanelRenderEventHandler RenderToolStripPanelBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        ///<summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ToolStripItemRenderEventHandler RenderToolStripStatusLabelBackground
        {
            add
            {
            }
            remove
            {
            }
        }

        #endregion Events
    }

    #endregion ToolStripRenderer Class
}
