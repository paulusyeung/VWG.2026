#region Using

using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Provides a user interface for browsing the properties of an object.</summary>
    /// <filterpriority>1</filterpriority>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(PropertyGrid), "PropertyGrid_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(PropertyGrid), "PropertyGrid.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Design.PropertyGridController, Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Design.PropertyGridController, Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Design.PropertyGridController, Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Design.PropertyGridController, Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Design.PropertyGridController, Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Design.PropertyGridController, Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Design.PropertyGridController, Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Design.PropertyGridController, Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [ToolboxItemCategory("Data")]
    [MetadataTag(WGTags.PropertyGrid)]
    [Skin(typeof(PropertyGridSkin))]
    [Serializable()]
    public class PropertyGrid : ContainerControl, ISealedComponent
    {
        #region Events

        /// <summary>Occurs when the sort mode is changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridPropertySortChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler PropertySortChanged
        {
            add
            {
                this.AddHandler(PropertyGrid.PropertySortChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.PropertySortChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the PropertySortChanged event.
        /// </summary>
        private EventHandler PropertySortChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(PropertyGrid.PropertySortChangedEvent);
            }
        }

        /// <summary>
        /// The PropertySortChanged event registration.
        /// </summary>
        private static readonly SerializableEvent PropertySortChangedEvent = SerializableEvent.Register("PropertySortChanged", typeof(EventHandler), typeof(PropertyGrid));

        /// <summary>Occurs when a property tab changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatPropertyChanged"), SRDescription("PropertyGridPropertyTabchangedDescr")]
        public event PropertyTabChangedEventHandler PropertyTabChanged
        {
            add
            {
                this.AddHandler(PropertyGrid.PropertyTabChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.PropertyTabChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the PropertyTabChanged event.
        /// </summary>
        private PropertyTabChangedEventHandler PropertyTabChangedHandler
        {
            get
            {
                return (PropertyTabChangedEventHandler)this.GetHandler(PropertyGrid.PropertyTabChangedEvent);
            }
        }

        /// <summary>
        /// The PropertyTabChanged event registration.
        /// </summary>
        private static readonly SerializableEvent PropertyTabChangedEvent = SerializableEvent.Register("PropertyTabChanged", typeof(PropertyTabChangedEventHandler), typeof(PropertyGrid));



        /// <summary>Occurs when a property value changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatPropertyChanged"), SRDescription("PropertyGridPropertyValueChangedDescr")]
        public event PropertyValueChangedEventHandler PropertyValueChanged
        {
            add
            {
                this.AddHandler(PropertyGrid.PropertyValueChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.PropertyValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("Occurs when property value changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientPropertyValueChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        /// <summary>
        /// Gets the list of tags that client events are propogated to.
        /// </summary>
        /// <value>
        /// The client event propogated tags.
        /// </value>
        protected override string ClientEventsPropogationTags
        {
            get
            {
                return string.Format("WC:{0}", WGTags.PropertyGridView);
            }
        }

        /// <summary>
        /// Gets the hanlder for the PropertyValueChanged event.
        /// </summary>
        private PropertyValueChangedEventHandler PropertyValueChangedHandler
        {
            get
            {
                return (PropertyValueChangedEventHandler)this.GetHandler(PropertyGrid.PropertyValueChangedEvent);
            }
        }

        /// <summary>
        /// The PropertyValueChanged event registration.
        /// </summary>
        private static readonly SerializableEvent PropertyValueChangedEvent = SerializableEvent.Register("PropertyValueChanged", typeof(PropertyValueChangedEventHandler), typeof(PropertyGrid));

        /// <summary>Occurs when a property value is about to change.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatPropertyChanging"), SRDescription("PropertyGridPropertyValueChangingDescr")]
        public event PropertyValueChangingEventHandler PropertyValueChanging
        {
            add
            {
                this.AddHandler(PropertyGrid.PropertyValueChangingEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.PropertyValueChangingEvent, value);
            }
        }

        /// <summary>
        /// Gets the handler for the PropertyValueChanging event.
        /// </summary>
        private PropertyValueChangingEventHandler PropertyValueChangingHandler
        {
            get
            {
                return (PropertyValueChangingEventHandler)this.GetHandler(PropertyGrid.PropertyValueChangingEvent);
            }
        }

        /// <summary>
        /// The PropertyValueChanging event registration.
        /// </summary>
        private static readonly SerializableEvent PropertyValueChangingEvent = SerializableEvent.Register("PropertyValueChanging", typeof(PropertyValueChangingEventHandler), typeof(PropertyGrid));




        /// <summary>Occurs when the selected <see cref="T:GridItem"></see> is changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridSelectedGridItemChangedDescr"), SRCategory("CatPropertyChanged")]
        public event SelectedGridItemChangedEventHandler SelectedGridItemChanged
        {
            add
            {
                this.AddHandler(PropertyGrid.SelectedGridItemChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.SelectedGridItemChangedEvent, value);
            }
        }

        [SRDescription("Occurs when property grid's entry selected item changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientSelectedGridItemChanged
        {
            add
            {
                this.AddClientHandler("Activated", value);
            }
            remove
            {
                this.RemoveClientHandler("Activated", value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedGridItemChanged event.
        /// </summary>
        private SelectedGridItemChangedEventHandler SelectedGridItemChangedHandler
        {
            get
            {
                return (SelectedGridItemChangedEventHandler)this.GetHandler(PropertyGrid.SelectedGridItemChangedEvent);
            }
        }

        /// <summary>
        /// The SelectedGridItemChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedGridItemChangedEvent = SerializableEvent.Register("SelectedGridItemChanged", typeof(SelectedGridItemChangedEventHandler), typeof(PropertyGrid));



        /// <summary>Occurs when the objects selected by the <see cref="P:PropertyGrid.SelectedObjects"></see> property have changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridSelectedObjectsChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler SelectedObjectsChanged
        {
            add
            {
                this.AddHandler(PropertyGrid.SelectedObjectsChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.SelectedObjectsChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedObjectsChanged event.
        /// </summary>
        private EventHandler SelectedObjectsChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(PropertyGrid.SelectedObjectsChangedEvent);
            }
        }
        
        /// <summary>
        /// The SelectedObjectsChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedObjectsChangedEvent = SerializableEvent.Register("SelectedObjectsChanged", typeof(EventHandler), typeof(PropertyGrid));

        /// <summary>
        /// Occurs when [showing type editor].
        /// </summary>
        internal event ShowingTypeEditorEventHandler ShowingTypeEditor
        {
            add
            {
                this.AddHandler(PropertyGrid.ShowingTypeEditorEvent, value);
            }
            remove
            {
                this.RemoveHandler(PropertyGrid.ShowingTypeEditorEvent, value);
            }
        }

        /// <summary>
        /// The showing type editor event
        /// </summary>
        private static readonly SerializableEvent ShowingTypeEditorEvent = SerializableEvent.Register("BeforeTypeEditorOpen", typeof(EventHandler), typeof(PropertyGrid));

        /// <summary>
        /// Gets the showing type editor handler.
        /// </summary>
        /// <value>
        /// The showing type editor handler.
        /// </value>
        private ShowingTypeEditorEventHandler ShowingTypeEditorHandler
        {
            get
            {
                return (ShowingTypeEditorEventHandler)this.GetHandler(PropertyGrid.ShowingTypeEditorEvent);
            }
        }

        #endregion

        #region Class Members

        #region Constants

        private const ushort mcntTabsChanging = 8;
        private const int mcntPROPERTIES = 0;
        private const ushort mcntPropertiesChanged = 1;
        private const ushort mcntRefreshingProperties = 0x200;
        private const ushort mcntReInitTab = 0x20;
        private const ushort mcntInternalChange = 4;
        private const int mcntLARGE_BUTTONS = 1;
        private const int mcntEVENTS = 1;
        private const int mcntMIN_GRID_HEIGHT = 20;
        private const int mcntNO_SORT = 2;
        private const int mcntNORMAL_BUTTONS = 0;
        private const ushort mcntFullRefreshAfterBatch = 0x80;
        private const ushort mcntGotDesignerEventService = 2;
        private const int mcntCXINDENT = 0;
        private const int mcntCYDIVIDER = 3;
        private const int mcntCYINDENT = 2;
        private const int mcntALPHA = 1;
        private const ushort mcntBatchMode = 0x10;
        private const ushort mcntBatchModeChange = 0x100;
        private const int mcntCATEGORIES = 0;

        #endregion

        /// <summary>
        /// Attributes indicating browsable properties
        /// </summary>
        [NonSerialized]
        private AttributeCollection mobjBrowsableAttributes;

        /// <summary>
        /// The current browsed objects
        /// </summary>
        [NonSerialized]
        private object[] marrCurrentObjects;

        /// <summary>
        /// All the property entries
        /// </summary>
        [NonSerialized]
        private GridEntryCollection mobjCurrentPropEntries;

        /// <summary>
        /// The documentation panel
        /// </summary>
        [NonSerialized]
        private Panel mobjDocComment;

        /// <summary>
        /// The splitter for the documentation panel
        /// </summary>
        [NonSerialized]
        private Splitter mobjSplitter;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private Label mobjLabelDocTitle;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private Label mobjLabelDocDescription;

        /// <summary>
        /// Reference to the containing designer if there is one
        /// </summary>
        [NonSerialized]
        private IDesignerHost mobjDesignerHost;

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        /// <value>The state.</value>
        [NonSerialized]
        private ushort mState;

        /// <summary>
        /// Reference to the internal property grid view control.
        /// </summary>
        [NonSerialized]
        private PropertyGridView mobjPropertyGridView;

        /// <summary>
        /// Visibility flag indicating if the help is visible
        /// </summary>
        private bool mblnHelpVisible = true;

        /// <summary>
        /// The default grid entry
        /// </summary>
        [NonSerialized]
        private GridEntry mobjDefaultGridEntry;

        /// <summary>
        /// Reference to the main grid entry
        /// </summary>
        [NonSerialized]
        private GridEntry mobjMainGridEntry;

        /// <summary>
        /// The current sort value
        /// </summary>
        private PropertySort menmPropertySortValue;

        /// <summary>
        /// The current selected view sort
        /// </summary>
        private int mintSelectedViewSort;

        /// <summary>
        /// The current selected view tab
        /// </summary>
        private int mintSelectedViewTab;

        /// <summary>
        /// ToolStrip serperator
        /// </summary>
        [NonSerialized]
        private ToolStripSeparator mobjTBSeperator1;

        /// <summary>
        /// ToolStrip serperator
        /// </summary>
        [NonSerialized]
        private ToolStripSeparator mobjTBSeperator2;

        /// <summary>
        /// ToolStrip visibility flag
        /// </summary>
        private bool mblnToolbarVisible;

        /// <summary>
        /// The internal ToolStrip
        /// </summary>
        [NonSerialized]
        private PropertyGridToolStrip mobjToolStrip;

        /// <summary>
        /// The Reset button
        /// </summary>
        [NonSerialized]
        private ToolStripButton mobjResetButton;

        /// <summary>
        /// The current ToolStrip sort buttons
        /// </summary>
        [NonSerialized]
        private ToolStripButton[] marrViewSortButtons;

        /// <summary>
        /// The current ToolStrip tab buttons
        /// </summary>
        [NonSerialized]
        private ToolStripButton[] marrViewTabButtons;

        /// <summary>
        /// The current property tabs
        /// </summary>
        [NonSerialized]
        private Hashtable mobjViewTabProps;

        /// <summary>
        /// The current property tabs
        /// </summary>
        [NonSerialized]
        private PropertyTab[] marrViewTabs;

        /// <summary>
        /// Property tab scope collection
        /// </summary>
        [NonSerialized]
        private PropertyTabScope[] marrViewTabScopes;

        /// <summary>
        /// Dirty flag indicating if tabs are dirty
        /// </summary>
        [NonSerialized]
        private bool mblnViewTabsDirty;

        #endregion

        #region Static C'Tor



        #endregion

        #region C'Tor / D'Tot

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PropertyGrid"></see> class.
        /// </summary>
        public PropertyGrid()
        {
            // Initialize the control inner controls
            InitializeComponent();

        }

        /// <summary>
        /// Initialize the component contained controls
        /// </summary>
        private void InitializeComponent()
        {
            // Initialize private members
            this.mblnHelpVisible = true;
            this.mblnToolbarVisible = true;
            this.mblnViewTabsDirty = true;
            this.marrViewTabs = new PropertyTab[0];
            this.marrViewTabScopes = new PropertyTabScope[0];
            this.menmPropertySortValue = PropertySort.CategorizedAlphabetical;

            base.SuspendLayout();

            try
            {
                this.mobjPropertyGridView = this.CreateGridView(null);
                this.mobjPropertyGridView.TabStop = true;
                this.mobjPropertyGridView.TabIndex = 2;
                this.mobjPropertyGridView.Dock = DockStyle.Fill;
                this.mobjPropertyGridView.Visible = true;
                this.mobjTBSeperator1 = this.CreateSeparatorButton();
                this.mobjTBSeperator2 = this.CreateSeparatorButton();
                this.mobjToolStrip = new PropertyGridToolStrip();
                this.mobjToolStrip.TabStop = true;
                this.mobjToolStrip.Dock = DockStyle.Top;
                this.mobjToolStrip.Text = "PropertyGridToolBar";
                this.mobjToolStrip.TabIndex = 1;
                this.mobjToolStrip.GripStyle = ToolStripGripStyle.Hidden;
                this.mobjToolStrip.AutoSize = false;
                this.mobjToolStrip.Height = 24;

                this.AddRefTab(this.DefaultTabType, null, PropertyTabScope.Static, true);
                this.CreateDocComment();
                this.SuspendLayout();
                this.mobjSplitter.Dock = DockStyle.Bottom;
                this.mobjSplitter.Visible = mblnHelpVisible;
                this.mobjDocComment.BorderStyle = this.PropertyGridSkin.HelpPanelStyle.BorderStyle;
                this.mobjDocComment.BorderColor = this.PropertyGridSkin.HelpPanelStyle.BorderColor;
                this.mobjDocComment.Padding = this.PropertyGridSkin.HelpPanelStyle.Padding;
                this.mobjDocComment.BackColor = this.PropertyGridSkin.HelpPanelStyle.BackColor;
                this.mobjDocComment.Dock = DockStyle.Bottom;
                this.mobjDocComment.Visible = mblnHelpVisible;
                this.Controls.Add(this.mobjPropertyGridView);
                this.Controls.Add(this.mobjSplitter);
                this.Controls.Add(this.mobjDocComment);

                this.Controls.Add(this.mobjToolStrip);
                this.ResumeLayout(false);
                this.SetupToolbar();
                this.Text = "PropertyGrid";

            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (this.mobjDocComment != null) this.mobjDocComment.ResumeLayout(false);
                base.ResumeLayout(true);
            }
        }


        #endregion

        #region Mehtods

        #region Serialization Methods

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                return base.SerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);
        }


        /// <summary>
        /// Gets a value indicating whether serializable object should serialize controls.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if serializable object should serialize controls; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldSerializableObjectSerializeControls
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Tabs Related

        internal void AddRefTab(Type objTabType, object objComponent, PropertyTabScope objPropertyTabScope, bool blnSetupToolbar)
        {
            PropertyTab objPropertyTab = null;
            int intPropertyTabIndex = -1;
            if (this.marrViewTabs != null)
            {
                for (int intIndex = 0; intIndex < this.marrViewTabs.Length; intIndex++)
                {
                    if (objTabType == this.marrViewTabs[intIndex].GetType())
                    {
                        objPropertyTab = this.marrViewTabs[intIndex];
                        intPropertyTabIndex = intIndex;
                        break;
                    }
                }
            }
            else
            {
                intPropertyTabIndex = 0;
            }
            if (objPropertyTab == null)
            {
                IDesignerHost objDesignerHost = null;
                if (((objComponent != null) && (objComponent is IComponent)) && (((IComponent)objComponent).Site != null))
                {
                    objDesignerHost = (IDesignerHost)((IComponent)objComponent).Site.GetService(typeof(IDesignerHost));
                }
                try
                {
                    objPropertyTab = this.CreateTab(objTabType, objDesignerHost);
                }
                catch (Exception)
                {
                    return;
                }
                if (this.marrViewTabs != null)
                {
                    intPropertyTabIndex = this.marrViewTabs.Length;
                    if (objTabType == this.DefaultTabType)
                    {
                        intPropertyTabIndex = 0;
                    }
                    else if (typeof(EventsTab).IsAssignableFrom(objTabType))
                    {
                        intPropertyTabIndex = 1;
                    }
                    else
                    {
                        for (int intIndex = 1; intIndex < this.marrViewTabs.Length; intIndex++)
                        {
                            if (!(this.marrViewTabs[intIndex] is EventsTab) && (string.Compare(objPropertyTab.TabName, this.marrViewTabs[intIndex].TabName, false, CultureInfo.InvariantCulture) < 0))
                            {
                                intPropertyTabIndex = intIndex;
                                break;
                            }
                        }
                    }
                }
                PropertyTab[] arrPropertyTabs = new PropertyTab[this.marrViewTabs.Length + 1];
                Array.Copy(this.marrViewTabs, 0, arrPropertyTabs, 0, intPropertyTabIndex);
                Array.Copy(this.marrViewTabs, intPropertyTabIndex, arrPropertyTabs, intPropertyTabIndex + 1, this.marrViewTabs.Length - intPropertyTabIndex);
                arrPropertyTabs[intPropertyTabIndex] = objPropertyTab;
                this.marrViewTabs = arrPropertyTabs;
                this.mblnViewTabsDirty = true;

                PropertyTabScope[] arrPropertyTabScopes = new PropertyTabScope[this.marrViewTabScopes.Length + 1];
                Array.Copy(this.marrViewTabScopes, 0, arrPropertyTabScopes, 0, intPropertyTabIndex);
                Array.Copy(this.marrViewTabScopes, intPropertyTabIndex, arrPropertyTabScopes, intPropertyTabIndex + 1, this.marrViewTabScopes.Length - intPropertyTabIndex);
                arrPropertyTabScopes[intPropertyTabIndex] = objPropertyTabScope;
                this.marrViewTabScopes = arrPropertyTabScopes;
            }

            if ((objPropertyTab != null) && (objComponent != null))
            {
                try
                {
                    object[] arrComponents = objPropertyTab.Components;
                    int intComponents = (arrComponents == null) ? 0 : arrComponents.Length;
                    object[] arrNewComponents = new object[intComponents + 1];
                    if (intComponents > 0)
                    {
                        Array.Copy(arrComponents, arrNewComponents, intComponents);
                    }
                    arrNewComponents[intComponents] = objComponent;
                    objPropertyTab.Components = arrNewComponents;
                }
                catch (Exception)
                {
                    this.RemoveTab(intPropertyTabIndex, false);
                }
            }
            if (blnSetupToolbar)
            {
                this.SetupToolbar();
                this.ShowEventsButton(false);
            }
        }

        /// <summary>
        /// Adds the tab.
        /// </summary>
        /// <param name="objTabType">Type of the obj tab.</param>
        /// <param name="objScope">The obj scope.</param>
        internal void AddTab(Type objTabType, PropertyTabScope objScope)
        {
            this.AddRefTab(objTabType, null, objScope, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPropertyTabScope"></param>
        internal void ClearTabs(PropertyTabScope objPropertyTabScope)
        {
            if (objPropertyTabScope < PropertyTabScope.Document)
            {
                throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
            }
            this.RemoveTabs(objPropertyTabScope, true);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearCachedProps()
        {
            if (this.mobjViewTabProps != null)
            {
                this.mobjViewTabProps.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objTabType"></param>
        internal void RemoveTab(Type objTabType)
        {
            int num1 = -1;
            for (int num2 = 0; num2 < this.marrViewTabs.Length; num2++)
            {
                if (objTabType == this.marrViewTabs[num2].GetType())
                {
                    PropertyTab objPropertyTab = this.marrViewTabs[num2];
                    num1 = num2;
                    break;
                }
            }
            if (num1 != -1)
            {
                PropertyTab[] arrPropertyTabs = new PropertyTab[this.marrViewTabs.Length - 1];
                Array.Copy(this.marrViewTabs, 0, arrPropertyTabs, 0, num1);
                Array.Copy(this.marrViewTabs, num1 + 1, arrPropertyTabs, num1, (this.marrViewTabs.Length - num1) - 1);
                this.marrViewTabs = arrPropertyTabs;
                PropertyTabScope[] arrPropertyTabScopes = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
                Array.Copy(this.marrViewTabScopes, 0, arrPropertyTabScopes, 0, num1);
                Array.Copy(this.marrViewTabScopes, num1 + 1, arrPropertyTabScopes, num1, (this.marrViewTabScopes.Length - num1) - 1);
                this.marrViewTabScopes = arrPropertyTabScopes;
                this.mblnViewTabsDirty = true;
                this.SetupToolbar();
            }
        }

        /// <summary>
        /// Removes the tab.
        /// </summary>
        /// <param name="intTabIndex">Index of the int tab.</param>
        /// <param name="blnSetupToolbar">if set to <c>true</c> [BLN setup toolbar].</param>
        internal void RemoveTab(int intTabIndex, bool blnSetupToolbar)
        {
            if ((intTabIndex >= this.marrViewTabs.Length) || (intTabIndex < 0))
            {
                throw new ArgumentOutOfRangeException("tabIndex", SR.GetString("PropertyGridBadTabIndex"));
            }
            if (this.marrViewTabScopes[intTabIndex] == PropertyTabScope.Static)
            {
                throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
            }
            if (this.mintSelectedViewTab == intTabIndex)
            {
                this.mintSelectedViewTab = 0;
            }

            ToolStripButton button1 = this.marrViewTabButtons[this.mintSelectedViewTab];
            PropertyTab[] arrPropertyTabs = new PropertyTab[this.marrViewTabs.Length - 1];
            Array.Copy(this.marrViewTabs, 0, arrPropertyTabs, 0, intTabIndex);
            Array.Copy(this.marrViewTabs, intTabIndex + 1, arrPropertyTabs, intTabIndex, (this.marrViewTabs.Length - intTabIndex) - 1);
            this.marrViewTabs = arrPropertyTabs;
            PropertyTabScope[] arrPropertyTabScopes = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
            Array.Copy(this.marrViewTabScopes, 0, arrPropertyTabScopes, 0, intTabIndex);
            Array.Copy(this.marrViewTabScopes, intTabIndex + 1, arrPropertyTabScopes, intTabIndex, (this.marrViewTabScopes.Length - intTabIndex) - 1);
            this.marrViewTabScopes = arrPropertyTabScopes;
            this.mblnViewTabsDirty = true;
            if (blnSetupToolbar)
            {
                this.SetupToolbar();
                this.mintSelectedViewTab = -1;
            }
        }

        /// <summary>
        /// Removes the tabs.
        /// </summary>
        /// <param name="enmClassification">The enm classification.</param>
        /// <param name="blnSetupToolbar">if set to <c>true</c> [BLN setup toolbar].</param>
        internal void RemoveTabs(PropertyTabScope enmClassification, bool blnSetupToolbar)
        {
            if (enmClassification == PropertyTabScope.Static)
            {
                throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
            }
            if (((this.marrViewTabButtons != null) && (this.marrViewTabs != null)) && (this.marrViewTabScopes != null))
            {
                ToolStripButton button1 = ((this.mintSelectedViewTab >= 0) && (this.mintSelectedViewTab < this.marrViewTabButtons.Length)) ? this.marrViewTabButtons[this.mintSelectedViewTab] : null;
                for (int num1 = this.marrViewTabs.Length - 1; num1 >= 0; num1--)
                {
                    if (this.marrViewTabScopes[num1] >= enmClassification)
                    {
                        if (this.mintSelectedViewTab == num1)
                        {
                            this.mintSelectedViewTab = -1;
                        }
                        else if (this.mintSelectedViewTab > num1)
                        {
                            this.mintSelectedViewTab--;
                        }
                        PropertyTab[] arrPropertyTabs = new PropertyTab[this.marrViewTabs.Length - 1];
                        Array.Copy(this.marrViewTabs, 0, arrPropertyTabs, 0, num1);
                        Array.Copy(this.marrViewTabs, num1 + 1, arrPropertyTabs, num1, (this.marrViewTabs.Length - num1) - 1);
                        this.marrViewTabs = arrPropertyTabs;
                        PropertyTabScope[] arrPropertyTabScopes = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
                        Array.Copy(this.marrViewTabScopes, 0, arrPropertyTabScopes, 0, num1);
                        Array.Copy(this.marrViewTabScopes, num1 + 1, arrPropertyTabScopes, num1, (this.marrViewTabScopes.Length - num1) - 1);
                        this.marrViewTabScopes = arrPropertyTabScopes;
                        this.mblnViewTabsDirty = true;
                    }
                }
                if (blnSetupToolbar && this.mblnViewTabsDirty)
                {
                    this.SetupToolbar();
                    this.mintSelectedViewTab = -1;

                    for (int num2 = 0; num2 < this.marrViewTabs.Length; num2++)
                    {
                        this.marrViewTabs[num2].Components = new object[0];
                    }
                }
            }
        }

        /// <summary>When overridden in a derived class, enables the creation of a <see cref="T:Design.PropertyTab"></see>.</summary>
        /// <returns>The newly created property tab. Returns null in its default implementation.</returns>
        /// <param name="objTabType">The type of tab to create. </param>
        protected virtual PropertyTab CreatePropertyTab(Type objTabType)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objTabType"></param>
        /// <param name="objDesignerHost"></param>
        /// <returns></returns>
        private PropertyTab CreateTab(Type objTabType, IDesignerHost objDesignerHost)
        {
            PropertyTab objPropertyTab = this.CreatePropertyTab(objTabType);
            if (objPropertyTab == null)
            {
                ConstructorInfo objConstructorInfo = objTabType.GetConstructor(new Type[] { typeof(IServiceProvider) });
                object obj1 = null;
                if (objConstructorInfo == null)
                {
                    objConstructorInfo = objTabType.GetConstructor(new Type[] { typeof(IDesignerHost) });
                    if (objConstructorInfo != null)
                    {
                        obj1 = objDesignerHost;
                    }
                }
                else
                {
                    obj1 = this.Site;
                }
                if ((obj1 != null) && (objConstructorInfo != null))
                {
                    objPropertyTab = (PropertyTab)objConstructorInfo.Invoke(new object[] { obj1 });
                }
                else
                {
                    objPropertyTab = (PropertyTab)Activator.CreateInstance(objTabType);
                }
            }

            //TODO:PROPERTYGRID            
            //if (objPropertyTab != null)
            //{
            //    Bitmap bitmap1 = objPropertyTab.Bitmap;
            //    if (bitmap1 == null)
            //    {
            //        throw new ArgumentException(SR.GetString("PropertyGridNoBitmap", new object[] { objPropertyTab.GetType().FullName }));
            //    }
            //    Size size1 = bitmap1.Size;
            //    if ((size1.Width != 0x10) || (size1.Height != 0x10))
            //    {
            //        bitmap1 = new Bitmap(bitmap1, new Size(BatchMode, 0x10));
            //    }
            //    string text1 = objPropertyTab.TabName;
            //    if ((text1 == null) || (text1.Length == 0))
            //    {
            //        throw new ArgumentException(SR.GetString("PropertyGridTabName", new object[] { objPropertyTab.GetType().FullName }));
            //    }
            //    return objPropertyTab;
            //}

            return objPropertyTab;
        }

        private void EnableTabs()
        {
            if (this.marrCurrentObjects != null)
            {
                this.SetupToolbar();
                for (int num1 = 1; num1 < this.marrViewTabs.Length; num1++)
                {
                    bool blnFlag1 = true;
                    for (int num2 = 0; num2 < this.marrCurrentObjects.Length; num2++)
                    {
                        try
                        {
                            if (this.marrViewTabs[num1].CanExtend(this.GetUnwrappedObject(num2)))
                            {
                                continue;
                            }
                            blnFlag1 = false;
                        }
                        catch (Exception)
                        {
                            blnFlag1 = false;
                        }
                        break;
                    }
                    if (blnFlag1 != this.marrViewTabButtons[num1].Visible)
                    {
                        this.marrViewTabButtons[num1].Visible = blnFlag1;
                        if (!blnFlag1 && (num1 == this.mintSelectedViewTab))
                        {
                            this.SelectViewTabButton(this.marrViewTabButtons[0], true);
                        }
                    }
                }
            }
        }

        private void SelectViewTabButton(ToolStripButton objToolBarButton, bool blnUpdateSelection)
        {
            this.SelectViewTabButtonDefault(objToolBarButton);
            if (blnUpdateSelection)
            {
                this.Refresh(false);
            }

        }

        #endregion

        #region Grid Related

        /// <summary>
        /// Resets the selected property.
        /// </summary>
        public void ResetSelectedProperty()
        {
            GridEntry objSelectedEntry = this.mobjPropertyGridView.SelectedGridEntry;
            if (objSelectedEntry != null)
            {
                this.ResetSelectedProperty(objSelectedEntry.PropertyDescriptor);
            }
            else
            {
                this.ResetSelectedProperty(null);
            }
        }

        /// <summary>
        /// Resets the selected property.
        /// </summary>
        /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
        public virtual void ResetSelectedProperty(PropertyDescriptor objPropertyDescriptor)
        {
            this.mobjPropertyGridView.Reset();
        }

        /// <summary>
        /// Clears the value caches
        /// </summary>
        internal void ClearValueCaches()
        {
            if (this.mobjMainGridEntry != null)
            {
                this.mobjMainGridEntry.ClearCachedValues();
            }
        }

        /// <summary>Collapses all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
        /// <filterpriority>2</filterpriority>
        public void CollapseAllGridItems()
        {

        }


        #endregion

        #region UI


        private void CreateDocComment()
        {
            mobjDocComment = new Panel();

            mobjSplitter = new Splitter();
            mobjSplitter.Height = 5;

            mobjLabelDocTitle = new Label(string.Empty);
            mobjLabelDocTitle.Font = new Font(this.Font, FontStyle.Bold);
            mobjLabelDocTitle.Dock = DockStyle.Top;

            mobjLabelDocDescription = new Label(string.Empty);
            mobjLabelDocDescription.Font = this.Font;
            mobjLabelDocDescription.Dock = DockStyle.Fill;

            mobjDocComment.Controls.Add(mobjLabelDocDescription);
            mobjDocComment.Controls.Add(mobjLabelDocTitle);
        }

        /// <summary>
        /// Creates the grid view
        /// </summary>
        /// <param name="objServiceProvider"></param>
        /// <returns></returns>
        private PropertyGridView CreateGridView(IServiceProvider objServiceProvider)
        {
            return new PropertyGridView(objServiceProvider, this);
        }

        /// <summary>
        /// Create a Push button
        /// </summary>
        /// <param name="strToolTipText">The STR tool tip text.</param>
        /// <param name="strSkinImage">The STR skin image.</param>
        /// <param name="objEventHandler">The obj event handler.</param>
        /// <returns></returns>
        private ToolStripButton CreatePushButton(string strToolTipText, string strSkinImage, EventHandler objEventHandler)
        {
            ToolStripButton objToolStripButton = new ToolStripButton();
            objToolStripButton.Text = strToolTipText;
            objToolStripButton.AutoToolTip = true;
            objToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            if (strSkinImage != string.Empty)
            {
                objToolStripButton.Image = this.Skin.GetResourceHandle(strSkinImage);
            }
            objToolStripButton.Click += objEventHandler;
            objToolStripButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            return objToolStripButton;

        }

        /// <summary>
        /// Creates the separator button.
        /// </summary>
        /// <returns></returns>
        private ToolStripSeparator CreateSeparatorButton()
        {
            ToolStripSeparator objToolStripSeparator = new ToolStripSeparator();

            objToolStripSeparator.Height = 20;

            return objToolStripSeparator;
        }



        #endregion

        #region Component Registry Related

        private long mlngPrivateId = 1;

        /// <summary>
        /// Unregister a grid component.
        /// </summary>
        /// <param name="objComponent">Component.</param>
        internal void UnRegisterGridComponent(IRegisteredComponentMember objComponent)
        {
            if (objComponent.IsRegistered)
            {
                objComponent.MemberID = 0;
                objComponent.IsRegistered = false;
            }
        }

        /// <summary>
        /// Unregister a collection of grid components
        /// </summary>
        /// <param name="objComponents"></param>
        internal void UnRegisterGridComponents(ICollection objComponents)
        {
            foreach (IRegisteredComponentMember objComponent in objComponents)
            {
                this.UnRegisterGridComponent(objComponent);
            }
        }

        /// <summary>
        /// Provides a registering service for contained components.
        /// </summary>
        /// <param name="objComponent"></param>
        internal void RegisterGridComponent(IRegisteredComponentMember objComponent)
        {
            if (!objComponent.IsRegistered)
            {
                objComponent.MemberID = mlngPrivateId++;
                objComponent.IsRegistered = true;
            }
            //this.RegisterComponent(objComponent);
        }

        /// <summary>
        /// Provides a registering service for contained components.
        /// </summary>
        /// <param name="objComponents"></param>
        internal void RegisterGridComponents(ICollection objComponents)
        {
            foreach (IRegisteredComponentMember objComponent in objComponents)
            {
                this.RegisterGridComponent(objComponent);
            }
        }

        #endregion

        #endregion

        /// <summary>Expands all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
        /// <filterpriority>1</filterpriority>
        public void ExpandAllGridItems()
        {

        }

        private static Type[] GetCommonTabs(object[] arrObjects, PropertyTabScope objPropertyTabScope)
        {
            if ((arrObjects == null) || (arrObjects.Length == 0))
            {
                return new Type[0];
            }
            Type[] arrTypes = new Type[5];
            int intTypeIndex = 0;
            PropertyTabAttribute objAttribute = (PropertyTabAttribute)TypeDescriptor.GetAttributes(arrObjects[0])[typeof(PropertyTabAttribute)];
            if (objAttribute == null)
            {
                return new Type[0];
            }
            int intScopeIndex = 0;
            while (intScopeIndex < objAttribute.TabScopes.Length)
            {
                PropertyTabScope objScope = objAttribute.TabScopes[intScopeIndex];
                if (objScope == objPropertyTabScope)
                {
                    if (intTypeIndex == arrTypes.Length)
                    {
                        Type[] arrTempTypes = new Type[intTypeIndex * 2];
                        Array.Copy(arrTypes, 0, arrTempTypes, 0, intTypeIndex);
                        arrTypes = arrTempTypes;
                    }
                    arrTypes[intTypeIndex++] = objAttribute.TabClasses[intScopeIndex];
                }
                intScopeIndex++;
            }
            if (intTypeIndex == 0)
            {
                return new Type[0];
            }
            for (intScopeIndex = 1; (intScopeIndex < arrObjects.Length) && (intTypeIndex > 0); intScopeIndex++)
            {
                objAttribute = (PropertyTabAttribute)TypeDescriptor.GetAttributes(arrObjects[intScopeIndex])[typeof(PropertyTabAttribute)];
                if (objAttribute == null)
                {
                    return new Type[0];
                }
                for (int num3 = 0; num3 < intTypeIndex; num3++)
                {
                    bool blnFlag1 = false;
                    for (int num4 = 0; num4 < objAttribute.TabClasses.Length; num4++)
                    {
                        if (objAttribute.TabClasses[num4] == arrTypes[num3])
                        {
                            blnFlag1 = true;
                            break;
                        }
                    }
                    if (!blnFlag1)
                    {
                        arrTypes[num3] = arrTypes[intTypeIndex - 1];
                        arrTypes[intTypeIndex - 1] = null;
                        intTypeIndex--;
                        num3--;
                    }
                }
            }
            Type[] arrReturnTypes = new Type[intTypeIndex];
            if (intTypeIndex > 0)
            {
                Array.Copy(arrTypes, 0, arrReturnTypes, 0, intTypeIndex);
            }
            return arrReturnTypes;
        }


        internal GridEntry GetDefaultGridEntry()
        {
            if ((this.mobjDefaultGridEntry == null) && (this.mobjCurrentPropEntries != null))
            {
                this.mobjDefaultGridEntry = (GridEntry)this.mobjCurrentPropEntries[0];
            }
            return this.mobjDefaultGridEntry;
        }

        /// <summary>
        /// Get the state of a specific flag
        /// </summary>
        private bool GetState(ushort flag)
        {
            return ((this.mState & flag) != 0);
        }

        internal GridEntryCollection GetPropEntries()
        {
            if (this.mobjCurrentPropEntries == null)
            {
                this.UpdateSelection();
            }
            this.SetState(mcntPropertiesChanged, false);
            return this.mobjCurrentPropEntries;
        }

        private PropertyGridView GetPropertyGridView()
        {
            return this.mobjPropertyGridView;
        }

        private object GetUnwrappedObject(int intIndex)
        {
            if (((this.marrCurrentObjects == null) || (intIndex < 0)) || (intIndex > this.marrCurrentObjects.Length))
            {
                return null;
            }
            object objObject = this.marrCurrentObjects[intIndex];
            if (objObject is ICustomTypeDescriptor)
            {
                objObject = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(null);
            }
            return objObject;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
        /// <param name="objTarget">The obj target.</param>
        /// <returns></returns>
        protected internal virtual object GetPropertyValue(PropertyDescriptor objPropertyDescriptor, object objTarget)
        {
            return objPropertyDescriptor.GetValue(objTarget);
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objValue">The obj value.</param>
        protected internal virtual void SetPropertyValue(PropertyDescriptor objPropertyDescriptor, object objComponent, object objValue)
        {
            objPropertyDescriptor.SetValue(objComponent, objValue);
        }

        /// <summary>
        /// Determines whether this instance [can reset property value] the specified obj grid entry.
        /// </summary>
        /// <param name="objGridEntry">The obj grid entry.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can reset property value] the specified obj grid entry; otherwise, <c>false</c>.
        /// </returns>
        protected internal virtual bool CanResetPropertyValue(GridEntry objGridEntry)
        {
            if (objGridEntry != null)
            {
                return objGridEntry.CanResetPropertyValue();
            }

            return false;
        }

        #region Events

        /// <summary>Raises the <see cref="M:System.Drawing.Design.IPropertyValueUIService.NotifyPropertyValueUIItemsChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        /// <param name="sender">The source of the event. </param>
        protected void OnNotifyPropertyValueUIItemsChanged(object sender, EventArgs e)
        {
            this.mobjPropertyGridView.Invalidate(true);
        }


        /// <summary>Raises the <see cref="E:PropertyGrid.PropertySortChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnPropertySortChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.PropertySortChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:PropertyGrid.PropertyTabChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:PropertyTabChangedEventArgs"></see> that contains the event data. </param>
        protected virtual void OnPropertyTabChanged(PropertyTabChangedEventArgs e)
        {
            // Raise event if needed
            PropertyTabChangedEventHandler objEventHandler = this.PropertyTabChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:PropertyGrid.PropertyValueChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:PropertyValueChangedEventArgs"></see> that contains the event data. </param>
        protected virtual void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
        {
            // Raise event if needed
            PropertyValueChangedEventHandler objEventHandler = this.PropertyValueChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the PropertyValue event.
        /// </summary>
        internal void OnPropertyValueSet(GridItem objChangedItem, object objOldValue)
        {
            this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(objChangedItem, objOldValue));
        }

        /// <summary>Raises the <see cref="E:PropertyGrid.PropertyValueChanging"></see> event.</summary>
        /// <param name="e">A <see cref="T:PropertyValueChangingEventArgs"></see> that contains the event data. </param>
        protected virtual void OnPropertyValueChanging(PropertyValueChangingEventArgs e)
        {
            // Raise event if needed
            PropertyValueChangingEventHandler objEventHandler = this.PropertyValueChangingHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>
        /// Raises the PropertyValueChanging event.
        /// <returns>Returns true if the action should be cancelled</returns>
        /// </summary>
        internal PropertyValueChangingEventArgs OnPropertyValueSetting(GridItem objChangingItem, object objNewValue)
        {
            PropertyValueChangingEventArgs e = new PropertyValueChangingEventArgs(objChangingItem, objNewValue);

            this.OnPropertyValueChanging(e);

            return e;
        }



        /// <summary>Raises the <see cref="E:PropertyGrid.SelectedGridItemChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:SelectedGridItemChangedEventArgs"></see> that contains the event data. </param>
        protected virtual void OnSelectedGridItemChanged(SelectedGridItemChangedEventArgs e)
        {
            // Raise event if needed
            SelectedGridItemChangedEventHandler objEventHandler = this.SelectedGridItemChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        internal void OnSelectedGridItemChanged(GridEntry objOldEntry, GridEntry objNewEntry)
        {
            this.OnSelectedGridItemChanged(new SelectedGridItemChangedEventArgs(objOldEntry, objNewEntry));
        }

        /// <summary>Raises the <see cref="E:PropertyGrid.SelectedObjectsChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnSelectedObjectsChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.SelectedObjectsChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

  
        /// <summary>
        /// Raises the <see cref="E:OnShowingEditTypeEditor" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ShowingTypeEditorEventArgs"/> instance containing the event data.</param>
        internal virtual void OnShowingEditTypeEditor(ShowingTypeEditorEventArgs e)
        {
            // Raise event if needed
            ShowingTypeEditorEventHandler objEventHandler = this.ShowingTypeEditorHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        private void OnTransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
        {
            //TODO:PROPERTYGRID
        }

        /// <summary>
        /// Causes the property grid to refresh it's view.
        /// </summary>
        private void Refresh(bool blnClearCached)
        {
            if (!base.Disposing && !this.GetState(mcntRefreshingProperties))
            {
                try
                {

                    this.SetState(mcntRefreshingProperties, true);
                    if (blnClearCached)
                    {
                        this.ClearCachedProps();
                    }
                    this.RefreshProperties(blnClearCached);
                    this.mobjPropertyGridView.Refresh();
                    this.DisplayHotCommands();
                }
                finally
                {
                    this.SetState(mcntRefreshingProperties, false);
                    this.mobjPropertyGridView.Update();
                }
            }

        }

        private void OnTransactionOpened(object sender, EventArgs e)
        {
            this.SetState(mcntBatchMode, true);
        }








        #endregion


        /// <summary>
        /// Causes the property grid to refresh it's view.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Refresh()
        {
            Refresh(true);
        }


        /// <summary>
        /// Causes the property grid to refresh it's calculated properties.
        /// </summary>
        protected internal void RefreshProperties(bool blnClearCached)
        {
            if ((blnClearCached && (this.mintSelectedViewTab != -1)) && (this.marrViewTabs != null))
            {
                PropertyTab objPropertyTab = this.marrViewTabs[this.mintSelectedViewTab];
                if ((objPropertyTab != null) && (this.mobjViewTabProps != null))
                {
                    string strKey = objPropertyTab.TabName + this.menmPropertySortValue.ToString();
                    this.mobjViewTabProps.Remove(strKey);
                }
            }
            this.SetState(mcntPropertiesChanged, true);
            this.UpdateSelection();
        }

        /// <summary>Refreshes the property tabs of the specified scope.</summary>
        /// <param name="objPropertyTabScope">Either the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </param>
        /// <exception cref="T:System.ArgumentException">The objPropertyTabScope parameter is not the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
        /// <filterpriority>2</filterpriority>
        public void RefreshTabs(PropertyTabScope objPropertyTabScope)
        {
            if (objPropertyTabScope < PropertyTabScope.Document)
            {
                throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
            }
            this.RemoveTabs(objPropertyTabScope, false);
            if (((objPropertyTabScope <= PropertyTabScope.Component) && (this.marrCurrentObjects != null)) && (this.marrCurrentObjects.Length > 0))
            {
                Type[] arrTypes = PropertyGrid.GetCommonTabs(this.marrCurrentObjects, PropertyTabScope.Component);
                for (int num1 = 0; num1 < arrTypes.Length; num1++)
                {
                    for (int num2 = 0; num2 < this.marrCurrentObjects.Length; num2++)
                    {
                        this.AddRefTab(arrTypes[num1], this.marrCurrentObjects[num2], PropertyTabScope.Component, false);
                    }
                }
            }

            this.SetupToolbar();
        }

        internal void ReleaseTab(Type objTabType, object objComponent)
        {
            PropertyTab objPropertyTab = null;
            int intPropertyTabIndex = -1;
            for (int intIndex = 0; intIndex < this.marrViewTabs.Length; intIndex++)
            {
                if (objTabType == this.marrViewTabs[intIndex].GetType())
                {
                    objPropertyTab = this.marrViewTabs[intIndex];
                    intPropertyTabIndex = intIndex;
                    break;
                }
            }
            if (objPropertyTab != null)
            {
                object[] arrComponents = objPropertyTab.Components;
                bool blnFlag1 = false;
                try
                {
                    int num3 = -1;
                    if (arrComponents != null)
                    {
                        ArrayList objList = new ArrayList(arrComponents);
                        num3 = objList.IndexOf(objComponent);
                    }
                    if (num3 >= 0)
                    {
                        object[] arrObjects2 = new object[arrComponents.Length - 1];
                        Array.Copy(arrComponents, 0, arrObjects2, 0, num3);
                        Array.Copy(arrComponents, num3 + 1, arrObjects2, num3, (arrComponents.Length - num3) - 1);
                        arrComponents = arrObjects2;
                        objPropertyTab.Components = arrComponents;
                    }
                    blnFlag1 = arrComponents.Length == 0;
                }
                catch (Exception)
                {
                    blnFlag1 = true;
                }
                if (blnFlag1 && (this.marrViewTabScopes[intPropertyTabIndex] > PropertyTabScope.Global))
                {
                    this.RemoveTab(intPropertyTabIndex, false);
                }
            }
        }





        internal void ReplaceSelectedObject(object objOldObject, object objNewObject)
        {
            for (int intIndex = 0; intIndex < this.marrCurrentObjects.Length; intIndex++)
            {
                if (this.marrCurrentObjects[intIndex] == objOldObject)
                {
                    this.marrCurrentObjects[intIndex] = objNewObject;
                    this.Refresh(true);
                    return;
                }
            }
        }



        private void SetState(ushort flag, bool blnValue)
        {
            if (blnValue)
            {
                this.mState = (ushort)(this.mState | flag);
            }
            else
            {
                this.mState = (ushort)(this.mState & ~flag);
            }
        }



        internal void SetStatusBox(string strTitle, string strDescription)
        {
            mobjLabelDocTitle.Text = strTitle == null ? "" : strTitle;
            mobjLabelDocDescription.Text = strDescription == null ? "" : strDescription;
        }


        /// <summary>
        /// Create the toolbar.
        /// </summary>
        private void SetupToolbar()
        {
            this.SetupToolbar(false);
        }

        /// <summary>
        /// Show or hide the toolbar.
        /// </summary>
        private void SetupToolbar(bool blnFullRebuild)
        {
            if (this.mblnViewTabsDirty || blnFullRebuild)
            {
                try
                {
                    int intIndex;
                    ArrayList objButtons;

                    EventHandler objEventHandler1 = new EventHandler(this.OnViewTabButtonClick);
                    EventHandler objSortHandler = new EventHandler(this.OnViewSortButtonClick);
                    EventHandler objResetHandler = new EventHandler(this.OnResetButtonClick);
                    EventHandler objCategoriesHandler = new EventHandler(this.OnViewButtonCategories);
                    
                    if (blnFullRebuild)
                    {
                        objButtons = new ArrayList();
                    }
                    else
                    {
                        objButtons = new ArrayList(this.mobjToolStrip.Items);
                    }
                    if ((this.marrViewSortButtons == null) || blnFullRebuild)
                    {
                        this.marrViewSortButtons = new ToolStripButton[2];

                        this.marrViewSortButtons[1] = this.CreatePushButton(SR.GetString("PBRSToolTipAlphabetic"), "SortAtoZ.gif", objSortHandler);
                        this.marrViewSortButtons[0] = this.CreatePushButton(SR.GetString("PBRSToolTipCategorized"), "ShowCategories.gif", objCategoriesHandler);

                        this.marrViewSortButtons[0].Checked = (this.menmPropertySortValue == PropertySort.CategorizedAlphabetical);
                        this.marrViewSortButtons[1].Checked = (this.menmPropertySortValue == PropertySort.Alphabetical);

                        for (intIndex = 0; intIndex < this.marrViewSortButtons.Length; intIndex++)
                        {
                            objButtons.Add(this.marrViewSortButtons[intIndex]);
                        }
                    }
                    else
                    {
                        intIndex = objButtons.Count - 1;
                        while (intIndex >= 2)
                        {
                            objButtons.RemoveAt(intIndex);
                            intIndex--;
                        }
                    }
                    objButtons.Add(this.mobjTBSeperator1);
                    
                    // Create & add Reset button, disabled by default.
                    this.mobjResetButton = this.CreatePushButton(string.Empty, "Reset.png", objResetHandler);
                    this.mobjResetButton.Enabled = false;
                    objButtons.Add(this.mobjResetButton);

                    this.marrViewTabButtons = new ToolStripButton[this.marrViewTabs.Length];
                    bool blnMultipleTabs = this.marrViewTabs.Length > 1;
                    for (intIndex = 0; intIndex < this.marrViewTabs.Length; intIndex++)
                    {
                        try
                        {

                            this.marrViewTabButtons[intIndex] = this.CreatePushButton(this.marrViewTabs[intIndex].TabName, "Action.ShowPropertyPages.gif", objEventHandler1);
                            if (blnMultipleTabs)
                            {
                                objButtons.Add(this.marrViewTabButtons[intIndex]);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (blnMultipleTabs)
                    {
                        objButtons.Add(this.mobjTBSeperator2);
                    }




                    this.mobjToolStrip.Items.Clear();
                    for (int num6 = 0; num6 < objButtons.Count; num6++)
                    {
                        this.mobjToolStrip.Items.Add(objButtons[num6] as ToolStripItem);
                    }

                    this.mblnViewTabsDirty = false;
                }
                finally
                {

                }
            }
        }

        /// <summary>
        /// Called when [view reset button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnResetButtonClick(object sender, EventArgs e)
        {
            this.ResetSelectedProperty();
        }

        /// <summary>
        /// Show or hide the events button.
        /// </summary>
        protected void ShowEventsButton(bool blnValue)
        {
            if (((this.marrViewTabs != null) && (this.marrViewTabs.Length > 1)) && (this.marrViewTabs[1] is EventsTab))
            {
                this.marrViewTabButtons[1].Visible = blnValue;
                if (!blnValue && (this.mintSelectedViewTab == 1))
                {
                    this.SelectViewTabButton(this.marrViewTabButtons[0], true);
                }
            }
            this.UpdatePropertiesViewTabVisibility();
        }




        private void UpdatePropertiesViewTabVisibility()
        {
            if (this.marrViewTabButtons != null)
            {
                int intVisibleCount = 0;
                for (int intIndex = 1; intIndex < this.marrViewTabButtons.Length; intIndex++)
                {
                    if (this.marrViewTabButtons[intIndex].Visible)
                    {
                        intVisibleCount++;
                    }
                }
                if (intVisibleCount > 0)
                {
                    this.marrViewTabButtons[0].Visible = true;
                    this.mobjTBSeperator2.Visible = true;
                }
                else
                {
                    this.marrViewTabButtons[0].Visible = false;
                    this.mobjTBSeperator2.Visible = false;
                }
            }
        }

        /// <summary>
        /// Updates the current selection to apply selected objects
        /// </summary>
        internal void UpdateSelection()
        {
            if (this.GetState(mcntPropertiesChanged) && (this.marrViewTabs != null))
            {
                string strKey = this.marrViewTabs[this.mintSelectedViewTab].TabName + this.menmPropertySortValue.ToString();
                if ((this.mobjViewTabProps != null) && this.mobjViewTabProps.ContainsKey(strKey))
                {
                    this.mobjMainGridEntry = (GridEntry)this.mobjViewTabProps[strKey];
                    if (this.mobjMainGridEntry != null)
                    {
                        this.mobjMainGridEntry.Refresh();
                    }
                }
                else
                {
                    if ((this.marrCurrentObjects != null) && (this.marrCurrentObjects.Length > 0))
                    {
                        this.mobjMainGridEntry = (GridEntry)GridEntry.Create(this.mobjPropertyGridView, this.marrCurrentObjects, new PropertyGridServiceProvider(this), this.mobjDesignerHost, this.SelectedTab, this.menmPropertySortValue);
                    }
                    else
                    {
                        this.mobjMainGridEntry = null;
                    }
                    if (this.mobjMainGridEntry == null)
                    {
                        this.mobjCurrentPropEntries = new GridEntryCollection(null, new GridEntry[0]);
                        this.mobjPropertyGridView.ClearProps();
                        return;
                    }
                    if (this.BrowsableAttributes != null)
                    {
                        this.mobjMainGridEntry.BrowsableAttributes = this.BrowsableAttributes;
                    }
                    if (this.mobjViewTabProps == null)
                    {
                        this.mobjViewTabProps = new Hashtable();
                    }
                    this.mobjViewTabProps[strKey] = this.mobjMainGridEntry;
                }
                this.mobjCurrentPropEntries = this.mobjMainGridEntry.Children;
                this.mobjDefaultGridEntry = this.mobjMainGridEntry.DefaultChild;
                this.mobjPropertyGridView.Invalidate();
            }
        }





        internal IDesignerHost ActiveDesigner
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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


        /// <summary>Gets or sets the browsable attributes associated with the object that the property grid is attached to.</summary>
        /// <returns>The collection of browsable attributes associated with the object.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public AttributeCollection BrowsableAttributes
        {
            get
            {
                if (this.mobjBrowsableAttributes == null)
                {
                    this.mobjBrowsableAttributes = new AttributeCollection(new Attribute[] { new BrowsableAttribute(true) });
                }
                return this.mobjBrowsableAttributes;
            }
            set
            {
                if ((value == null) || (value == AttributeCollection.Empty))
                {
                    this.mobjBrowsableAttributes = new AttributeCollection(new Attribute[] { BrowsableAttribute.Yes });
                }
                else
                {
                    Attribute[] arrAttributes = new Attribute[value.Count];
                    value.CopyTo(arrAttributes, 0);
                    this.mobjBrowsableAttributes = new AttributeCollection(arrAttributes);
                }
                if (((this.marrCurrentObjects != null) && (this.marrCurrentObjects.Length > 0)) && (this.mobjMainGridEntry != null))
                {
                    this.mobjMainGridEntry.BrowsableAttributes = this.BrowsableAttributes;
                    this.Refresh(true);
                }
            }
        }

        private bool CanCopy
        {
            get
            {
                return this.mobjPropertyGridView.CanCopy;
            }
        }

        private bool CanCut
        {
            get
            {
                return this.mobjPropertyGridView.CanCut;
            }
        }

        private bool CanPaste
        {
            get
            {
                return this.mobjPropertyGridView.CanPaste;
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        /// <summary>
        /// Gets the main GridItem. i.e. the root item.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        public GridItem MainGridItem
        {
            get
            {
                return this.mobjMainGridEntry;
            }
        }

        /// <summary>Gets a value indicating whether the commands pane can be made visible for the currently selected objects.</summary>
        /// <returns>true if the commands pane can be made visible; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), SRDescription("PropertyGridCanShowCommandsDesc"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual bool CanShowCommands
        {
            get
            {
                return false;
            }
        }

        private bool CanUndo
        {
            get
            {
                return this.mobjPropertyGridView.CanUndo;
            }
        }

        /// <summary>Gets or sets the text color used for category headings. </summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the text color.</returns>
        [SRCategory("CatAppearance"), SRDescription("PropertyGridCategoryForeColorDesc"), DefaultValue(typeof(System.Drawing.Color), "ControlText")]
        public System.Drawing.Color CategoryForeColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {

            }
        }




        /// <summary>Gets a value indicating whether the commands pane is visible.</summary>
        /// <returns>true if the commands pane is visible; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public virtual bool CommandsVisible
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets or sets a value indicating whether the commands pane is visible for objects that expose verbs.</summary>
        /// <returns>true if the commands pane is visible; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), DefaultValue(true), SRDescription("PropertyGridCommandsVisibleIfAvailable")]
        public virtual bool CommandsVisibleIfAvailable
        {
            get
            {
                return false;
            }
            set
            {

            }
        }



        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:Control.ControlCollection"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Control.ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(130, 130);
            }
        }

        /// <summary>Gets the type of the default tab.</summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the default tab.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual Type DefaultTabType
        {
            get
            {
                return typeof(PropertiesTab);
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="T:PropertyGrid"></see> control paints its toolbar with flat buttons.</summary>
        /// <returns>true if the <see cref="T:PropertyGrid"></see> paints its toolbar with flat buttons; otherwise false. The default is false.</returns>
        protected bool DrawFlatToolbar
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }



        /// <summary>Gets or sets the background color for the Help region.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for controls.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridHelpBackColorDesc"), SRCategory("CatAppearance")]
        public System.Drawing.Color HelpBackColor
        {
            get
            {
                return this.mobjDocComment.BackColor;
            }
            set
            {
                this.mobjDocComment.BackColor = value;
            }
        }

        /// <summary>
        /// Resets the color of the help back.
        /// </summary>
        private void ResetHelpBackColor()
        {
            this.HelpBackColor = this.PropertyGridSkin.HelpPanelStyle.BackColor;
        }

        /// <summary>
        /// Determine whether We Should the HelpBackColor
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeHelpBackColor()
        {
            return this.mobjDocComment.BackColor != this.PropertyGridSkin.HelpPanelStyle.BackColor;
        }

        /// <summary>Gets or sets the foreground color for the Help region.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for control text.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), DefaultValue(typeof(System.Drawing.Color), "ControlText"), SRDescription("PropertyGridHelpForeColorDesc")]
        public System.Drawing.Color HelpForeColor
        {
            get
            {
                return this.mobjDocComment.ForeColor;
            }
            set
            {
                this.mobjDocComment.ForeColor = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the Help text is visible.</summary>
        /// <returns>true if the help text is visible; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(true), Localizable(true), SRDescription("PropertyGridHelpVisibleDesc")]
        public virtual bool HelpVisible
        {
            get
            {
                return this.mblnHelpVisible;
            }
            set
            {
                if (this.mblnHelpVisible != value)
                {
                    this.mblnHelpVisible = value;
                    this.mobjSplitter.Visible = value;
                    this.mobjDocComment.Visible = value;

                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether buttons appear in standard size or in large size.</summary>
        /// <returns>true if buttons on the control appear large; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false), SRCategory("CatAppearance"), SRDescription("PropertyGridLargeButtonsDesc")]
        public bool LargeButtons
        {
            get
            {
                return false;
            }
            set
            {

            }
        }

        /// <summary>Gets or sets the color of the gridlines and borders.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for scroll bars.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridLineColorDesc"), DefaultValue(typeof(System.Drawing.Color), "InactiveBorder"), SRCategory("CatAppearance")]
        public System.Drawing.Color LineColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {

            }
        }

        internal PropertyGridView PropertyGridView
        {
            get
            {
                return mobjPropertyGridView;
            }
        }

        /// <summary>
        /// Gets the property grid skin.
        /// </summary>
        /// <value>The property grid skin.</value>
        private PropertyGridSkin PropertyGridSkin
        {
            get
            {
                return this.Skin as PropertyGridSkin;
            }
        }

        /// <summary>Gets or sets the type of sorting the <see cref="T:PropertyGrid"></see> uses to display properties.</summary>
        /// <returns>One of the <see cref="T:PropertySort"></see> values. The default is <see cref="F:PropertySort.Categorized"></see> or <see cref="F:PropertySort.Alphabetical"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:PropertySort"></see> values.</exception>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), SRDescription("PropertyGridPropertySortDesc"), DefaultValue(3)]
        public PropertySort PropertySort
        {
            get
            {
                return this.menmPropertySortValue;
            }
            set
            {
                ToolStripButton objToolBarButton;
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(PropertySort));
                }
                if ((value & PropertySort.Categorized) != PropertySort.NoSort)
                {
                    objToolBarButton = this.marrViewSortButtons[0];
                }
                else if ((value & PropertySort.Alphabetical) != PropertySort.NoSort)
                {
                    objToolBarButton = this.marrViewSortButtons[1];
                }

                GridItem objGridItem = this.SelectedGridItem;
                this.menmPropertySortValue = value;
                if (objGridItem != null)
                {
                    try
                    {
                        this.SelectedGridItem = objGridItem;
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }
        }

        private void OnViewTabButtonClick(object objSender, EventArgs eventArgs)
        {



        }



        private void OnViewSortButtonClick(object objSender, EventArgs eventArgs)
        {
            // Sort grid alphabetical.
            ApplyPropertySort(PropertySort.Alphabetical);

        }

        /// <summary>
        /// Called when [view button categories].
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnViewButtonCategories(object objSender, EventArgs eventArgs)
        {
            // Sort grid categorized.
            ApplyPropertySort(PropertySort.CategorizedAlphabetical);
        }

        /// <summary>
        /// Applies the property sort.
        /// </summary>
        /// <param name="enmPropertySort">The enm property sort.</param>
        private void ApplyPropertySort(PropertySort enmPropertySort)
        {
            if (this.menmPropertySortValue != enmPropertySort)
            {
                this.marrViewSortButtons[0].Checked = (enmPropertySort == PropertySort.CategorizedAlphabetical);
                this.marrViewSortButtons[1].Checked = (enmPropertySort == PropertySort.Alphabetical);

                this.menmPropertySortValue = enmPropertySort;
                this.Refresh(false);
            }
        }

        internal bool HavePropEntriesChanged()
        {
            return this.GetState(1);
        }

        /// <summary>Gets the collection of property tabs that are displayed in the grid.</summary>
        /// <returns>A <see cref="T:PropertyGrid.PropertyTabCollection"></see> containing the collection of <see cref="T:Design.PropertyTab"></see> objects being displayed by the <see cref="T:PropertyGrid"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyTabCollection PropertyTabs
        {
            get
            {
                return new PropertyTabCollection(this);
            }
        }

        internal void SetActiveGridEntry(GridEntry objGridEntry)
        {

            this.SetStatusBox(objGridEntry.PropertyLabel, objGridEntry.PropertyDescription);
        }

        /// <summary>Gets or sets the selected grid item.</summary>
        /// <returns>The currently selected row in the property grid.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Advanced)]
        public GridItem SelectedGridItem
        {
            get
            {
                GridItem objItem = this.mobjPropertyGridView.SelectedGridEntry;
                if (objItem == null)
                {
                    return this.mobjMainGridEntry;
                }
                return objItem;
            }
            set
            {
                this.mobjPropertyGridView.SelectedGridEntry = (GridEntry)value;
            }
        }

        /// <summary>
        /// Indicates if to render padding attribute
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
        {
            return PaddingValue.Empty != objPadding;
        }


        /// <summary>Gets or sets the object for which the grid displays properties.</summary>
        /// <returns>The first object in the object list. If there is no currently selected object the return is null.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridSelectedObjectDesc"), SRCategory("CatBehavior"), DefaultValue((string)null), TypeConverter(typeof(SelectedObjectConverter))]
        public object SelectedObject
        {
            get
            {
                // It there are current selected objects
                if ((this.marrCurrentObjects != null) && (this.marrCurrentObjects.Length != 0))
                {
                    return this.marrCurrentObjects[0];
                }

                return null;
            }
            set
            {
                if (value != this.SelectedObject || this.SelectedObjects.Length > 1)
                {
                    if (value == null)
                    {
                        this.SelectedObjects = new object[0];
                    }
                    else
                    {
                        this.SelectedObjects = new object[] { value };
                    }
                }
            }
        }

        /// <summary>Gets or sets the currently selected objects.</summary>
        /// <returns>An array of type <see cref="T:System.Object"></see>. The default is an empty array.</returns>
        /// <exception cref="T:System.ArgumentException">One of the items in the array of objects had a null value. </exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] SelectedObjects
        {
            get
            {
                // If there are no current objects
                if (this.marrCurrentObjects == null)
                {
                    return new object[0];
                }
                return (object[])this.marrCurrentObjects.Clone();
            }
            set
            {
                bool blnIsDifferent = false;

                this.SetState(mcntFullRefreshAfterBatch, false);
                if (this.GetState(mcntBatchMode))
                {
                    this.SetState(mcntBatchModeChange, false);
                }
                this.mobjPropertyGridView.EnsurePendingChangesCommitted();
                bool blnFlag = false;
                bool blnHasSameTypes = false;
                bool blnValidObjects = true;
                if ((value != null) && (value.Length > 0))
                {
                    for (int num1 = 0; num1 < value.Length; num1++)
                    {
                        if (value[num1] == null)
                        {

                            throw new ArgumentException("SelectedObjects can not have a null item.");
                        }
                        if (value[num1] is PropertyGrid.IUnimplemented)
                        {
                            throw new NotSupportedException("SelectedObjects can not contain PropertyGrid.");
                        }
                    }
                }
                else
                {
                    blnValidObjects = false;
                }
                if (((this.marrCurrentObjects != null) && (value != null)) && (this.marrCurrentObjects.Length == value.Length))
                {
                    blnFlag = true;
                    blnHasSameTypes = true;
                    for (int intIndex = 0; (intIndex < value.Length) && (blnFlag || blnHasSameTypes); intIndex++)
                    {
                        if (blnFlag && (this.marrCurrentObjects[intIndex] != value[intIndex]))
                        {
                            blnFlag = false;
                        }
                        Type objTypeOld = this.GetUnwrappedObject(intIndex).GetType();
                        object objObjectNew = value[intIndex];
                        if (objObjectNew is ICustomTypeDescriptor)
                        {
                            objObjectNew = ((ICustomTypeDescriptor)objObjectNew).GetPropertyOwner(null);
                        }
                        Type objTypeNew = objObjectNew.GetType();
                        if (blnHasSameTypes && ((objTypeOld != objTypeNew) || (objTypeOld.IsCOMObject && objTypeNew.IsCOMObject)))
                        {
                            blnHasSameTypes = false;
                        }
                    }
                }
                if (!blnFlag)
                {
                    blnIsDifferent = true;

                    blnValidObjects = blnValidObjects && this.GetState(mcntGotDesignerEventService);

                    this.SetStatusBox("", "");

                    this.ClearCachedProps();
                    if (value == null)
                    {
                        this.marrCurrentObjects = new object[0];
                    }
                    else
                    {
                        this.marrCurrentObjects = (object[])value.Clone();
                    }

                    this.SetState(mcntPropertiesChanged, true);
                    if (this.mobjPropertyGridView != null)
                    {
                        this.mobjPropertyGridView.RemoveSelectedEntryHelpAttributes();
                    }
                    if (this.mobjMainGridEntry != null)
                    {
                        this.mobjMainGridEntry.Dispose();
                    }
                    if ((!blnHasSameTypes && !this.GetState(mcntTabsChanging)) && (this.mintSelectedViewTab < this.marrViewTabButtons.Length))
                    {
                        Type objType3 = (this.mintSelectedViewTab == -1) ? null : this.marrViewTabs[this.mintSelectedViewTab].GetType();
                        ToolStripButton button1 = null;
                        this.RefreshTabs(PropertyTabScope.Component);
                        this.EnableTabs();
                        if (objType3 != null)
                        {
                            for (int num3 = 0; num3 < this.marrViewTabs.Length; num3++)
                            {
                                if ((this.marrViewTabs[num3].GetType() == objType3) && this.marrViewTabButtons[num3].Visible)
                                {
                                    button1 = this.marrViewTabButtons[num3];
                                    break;
                                }
                            }
                        }
                        this.SelectViewTabButtonDefault(button1);
                    }
                    if ((blnValidObjects && (this.marrViewTabs != null)) && ((this.marrViewTabs.Length > 1) && (this.marrViewTabs[1] is EventsTab)))
                    {
                        blnValidObjects = this.marrViewTabButtons[1].Visible;
                        Attribute[] arrAttributeArray1 = new Attribute[this.BrowsableAttributes.Count];
                        this.BrowsableAttributes.CopyTo(arrAttributeArray1, 0);
                        Hashtable hashtable1 = null;
                        if (this.marrCurrentObjects.Length > 10)
                        {
                            hashtable1 = new Hashtable();
                        }
                        for (int num4 = 0; (num4 < this.marrCurrentObjects.Length) && blnValidObjects; num4++)
                        {
                            object obj2 = this.marrCurrentObjects[num4];
                            if (obj2 is ICustomTypeDescriptor)
                            {
                                obj2 = ((ICustomTypeDescriptor)obj2).GetPropertyOwner(null);
                            }
                            Type objType4 = obj2.GetType();
                            if ((hashtable1 == null) || !hashtable1.Contains(objType4))
                            {
                                blnValidObjects = blnValidObjects && ((obj2 is IComponent) && (((IComponent)obj2).Site != null));
                                PropertyDescriptorCollection objCollection1 = ((EventsTab)this.marrViewTabs[1]).GetProperties(obj2, arrAttributeArray1);
                                blnValidObjects = (blnValidObjects && (objCollection1 != null)) && (objCollection1.Count > 0);
                                if (blnValidObjects && (hashtable1 != null))
                                {
                                    hashtable1[objType4] = objType4;
                                }
                            }
                        }
                    }
                    this.ShowEventsButton(blnValidObjects && (this.marrCurrentObjects.Length > 0));
                    this.DisplayHotCommands();
                    if (this.marrCurrentObjects.Length == 1)
                    {
                        this.EnablePropPageButton(this.marrCurrentObjects[0]);
                    }
                    else
                    {
                        this.EnablePropPageButton(null);
                    }
                    this.OnSelectedObjectsChanged(EventArgs.Empty);
                }
                if (!this.GetState(mcntTabsChanging))
                {
                    if ((this.marrCurrentObjects.Length > 0) && this.GetState(mcntReInitTab))
                    {

                        this.Refresh(false);

                        this.SetState(mcntReInitTab, false);
                    }
                    else
                    {
                        this.Refresh(true);
                    }
                    if (this.marrCurrentObjects.Length > 0)
                    {
                        this.SaveTabSelection();
                    }
                }

                if (blnIsDifferent)
                {
                    FireObservableItemPropertyChanged("SelectedObjects");
                }
            }
        }

        /// <summary>
        /// Fires the click.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void FireClick(EventArgs objEventArgs)
        {
            base.OnClick(objEventArgs);
        }

        /// <summary>
        /// Gets the entries critical events.
        /// </summary>
        /// <returns></returns>
        internal CriticalEventsData GetEntriesCriticalEventsData()
        {
            CriticalEventsData objEntriesEvents = new CriticalEventsData();
            CriticalEventsData objPropertyGridEvents = this.GetCriticalEventsData();

            if (objPropertyGridEvents.HasEvent(WGEvents.Click))
            {
                objEntriesEvents.Set(WGEvents.Click);
            }

            if (objPropertyGridEvents.HasEvent(WGEvents.KeyDown))
            {
                objPropertyGridEvents.Set(WGEvents.KeyDown);
            }

            return objEntriesEvents;
        }

        private void SaveTabSelection()
        {

        }

        private void EnablePropPageButton(object obj)
        {

        }

        private void DisplayHotCommands()
        {

        }

        private bool SelectViewTabButtonDefault(ToolStripButton objToolBarButton)
        {
            if ((this.mintSelectedViewTab >= 0) && (this.mintSelectedViewTab >= this.marrViewTabButtons.Length))
            {
                this.mintSelectedViewTab = -1;
            }
            if (((this.mintSelectedViewTab >= 0) && (this.mintSelectedViewTab < this.marrViewTabButtons.Length)) && (objToolBarButton == this.marrViewTabButtons[this.mintSelectedViewTab]))
            {
                this.marrViewTabButtons[this.mintSelectedViewTab].Checked = true;
                return true;
            }
            PropertyTab objPropertyTab = null;
            if (this.mintSelectedViewTab != -1)
            {
                this.marrViewTabButtons[this.mintSelectedViewTab].Checked = false;
                objPropertyTab = this.marrViewTabs[this.mintSelectedViewTab];
            }
            for (int num1 = 0; num1 < this.marrViewTabButtons.Length; num1++)
            {
                if (this.marrViewTabButtons[num1] == objToolBarButton)
                {
                    this.mintSelectedViewTab = num1;
                    this.marrViewTabButtons[num1].Checked = true;
                    try
                    {
                        this.SetState(mcntTabsChanging, true);
                        this.OnPropertyTabChanged(new PropertyTabChangedEventArgs(objPropertyTab, this.marrViewTabs[num1]));
                    }
                    finally
                    {
                        this.SetState(mcntTabsChanging, false);
                    }
                    return true;
                }
            }
            this.mintSelectedViewTab = 0;
            this.SelectViewTabButton(this.marrViewTabButtons[0], false);
            return false;

        }

        /// <summary>
        /// Gets the currently selected property tab.
        /// </summary>
        /// <value>The selected tab.</value>
        /// <returns>The <see cref="T:Design.PropertyTab"></see> that is providing the selected view.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public PropertyTab SelectedTab
        {
            get
            {
                return this.marrViewTabs[this.mintSelectedViewTab];
            }
        }

        /// <summary>
        /// Gets the reset button.
        /// </summary>
        /// <value>
        /// The reset button.
        /// </value>
        internal ToolStripButton ResetButton
        {
            get
            {
                return mobjResetButton;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [show focus cues].
        /// </summary>
        /// <value><c>true</c> if [show focus cues]; otherwise, <c>false</c>.</value>
        protected internal bool ShowFocusCues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:System.ComponentModel.Component"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:System.ComponentModel.Component"></see>, if any. null if the <see cref="T:System.ComponentModel.Component"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:System.ComponentModel.Component"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:System.ComponentModel.Component"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
                this.mobjPropertyGridView.ServiceProvider = value;
                if (value == null)
                {
                    this.ActiveDesigner = null;
                }
                else
                {
                    this.ActiveDesigner = (IDesignerHost)value.GetService(typeof(IDesignerHost));
                }

            }
        }

        internal bool SupportsUseCompatibleTextRendering
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>Gets or sets a value indicating whether the ToolStrip is visible.</summary>
        /// <returns>true if the ToolStrip is visible; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("PropertyGridToolbarVisibleDesc"), SRCategory("CatAppearance"), DefaultValue(true)]
        public virtual bool ToolbarVisible
        {
            get
            {
                return this.mblnToolbarVisible;
            }
            set
            {
                this.mblnToolbarVisible = value;
                this.mobjToolStrip.Visible = value;
                if (value)
                {
                    this.SetupToolbar(this.mblnViewTabsDirty);
                }
                base.Invalidate();
                this.mobjToolStrip.Invalidate();
            }
        }

        /// <summary>
        /// Gets the tool strip.
        /// </summary>
        public ToolStrip Toolbar
        {
            get
            {
                return this.mobjToolStrip;
            }
        }

        /// <summary>Gets or sets a value indicating the background color in the grid.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for windows.</returns>
        /// <filterpriority>2</filterpriority>
        [SRCategory("CatAppearance"), SRDescription("PropertyGridViewBackColorDesc"), DefaultValue(typeof(System.Drawing.Color), "Window")]
        public System.Drawing.Color ViewBackColor
        {
            get
            {
                return this.mobjPropertyGridView.BackColor;
            }
            set
            {
                this.mobjPropertyGridView.BackColor = value;
                this.mobjPropertyGridView.Invalidate();
            }
        }

        /// <summary>Gets or sets a value indicating the color of the text in the grid.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is current system color for text in windows.</returns>
        /// <filterpriority>2</filterpriority>
        [SRCategory("CatAppearance"), DefaultValue(typeof(System.Drawing.Color), "WindowText"), SRDescription("PropertyGridViewForeColorDesc")]
        public System.Drawing.Color ViewForeColor
        {
            get
            {
                return this.mobjPropertyGridView.ForeColor;
            }
            set
            {
                this.mobjPropertyGridView.ForeColor = value;
                this.mobjPropertyGridView.Invalidate();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether raise click event on mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                return false;
            }
        }

        #region Classes

        private interface IUnimplemented
        {
        }

        [Serializable]
        private class PropertyGridServiceProvider : IServiceProvider
        {
            private PropertyGrid mobjOwner;

            public PropertyGridServiceProvider(PropertyGrid objOwner)
            {
                this.mobjOwner = objOwner;
            }

            public object GetService(Type objServiceType)
            {
                object obj1 = null;
                if (this.mobjOwner.ActiveDesigner != null)
                {
                    obj1 = this.mobjOwner.ActiveDesigner.GetService(objServiceType);
                }
                if (obj1 == null)
                {
                    obj1 = this.mobjOwner.mobjPropertyGridView.GetService(objServiceType);
                }
                if ((obj1 == null) && (this.mobjOwner.Site != null))
                {
                    obj1 = this.mobjOwner.Site.GetService(objServiceType);
                }
                return obj1;
            }



        }

        /// <summary>Contains a collection of <see cref="T:Design.PropertyTab"></see> objects.</summary>
        [Serializable]
        public class PropertyTabCollection : ICollection, IEnumerable
        {

            /// <summary>
            /// 
            /// </summary>
            internal static PropertyGrid.PropertyTabCollection Empty;

            /// <summary>
            /// 
            /// </summary>
            private PropertyGrid mobjOwner;

            static PropertyTabCollection()
            {
                PropertyGrid.PropertyTabCollection.Empty = new PropertyGrid.PropertyTabCollection(null);
            }

            internal PropertyTabCollection(PropertyGrid objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>Adds a Property tab of the specified type to the collection.</summary>
            /// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
            public void AddTabType(Type objPropertyTabType)
            {
                if (this.mobjOwner == null)
                {
                    throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
                }
                this.mobjOwner.AddTab(objPropertyTabType, PropertyTabScope.Global);
            }

            /// <summary>Adds a Property tab of the specified type and with the specified scope to the collection.</summary>
            /// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
            /// <param name="objPropertyTabScope">One of the <see cref="T:System.ComponentModel.PropertyTabScope"></see> values. </param>
            public void AddTabType(Type objPropertyTabType, PropertyTabScope objPropertyTabScope)
            {
                if (this.mobjOwner == null)
                {
                    throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
                }
                this.mobjOwner.AddTab(objPropertyTabType, objPropertyTabScope);
            }

            /// <summary>Removes all the Property tabs of the specified scope from the collection.</summary>
            /// <param name="objPropertyTabScope">The scope of the tabs to clear. </param>
            /// <exception cref="T:System.ArgumentException">The assigned value of the objPropertyTabScope parameter is less than the Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
            public void Clear(PropertyTabScope objPropertyTabScope)
            {
                if (this.mobjOwner == null)
                {
                    throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
                }
                this.mobjOwner.ClearTabs(objPropertyTabScope);
            }

            /// <summary>Returns an enumeration of all the Property tabs in the collection.</summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:PropertyGrid.PropertyTabCollection"></see>.</returns>
            public IEnumerator GetEnumerator()
            {
                if (this.mobjOwner == null)
                {
                    return new PropertyTab[0].GetEnumerator();
                }
                return this.mobjOwner.marrViewTabs.GetEnumerator();
            }

            /// <summary>Removes the specified tab type from the collection.</summary>
            /// <param name="objPropertyTabType">The tab type to remove from the collection. </param>
            public void RemoveTabType(Type objPropertyTabType)
            {
                if (this.mobjOwner == null)
                {
                    throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
                }
                this.mobjOwner.RemoveTab(objPropertyTabType);
            }

            void ICollection.CopyTo(Array objDestinationArray, int index)
            {
                if ((this.mobjOwner != null) && (this.mobjOwner.marrViewTabs.Length > 0))
                {
                    Array.Copy(this.mobjOwner.marrViewTabs, 0, objDestinationArray, index, this.mobjOwner.marrViewTabs.Length);
                }
            }

            /// <summary>Gets the number of Property tabs in the collection.</summary>
            /// <returns>The number of Property tabs in the collection.</returns>
            public int Count
            {
                get
                {
                    if (this.mobjOwner == null)
                    {
                        return 0;
                    }
                    return this.mobjOwner.marrViewTabs.Length;
                }
            }

            /// <summary>Gets the <see cref="T:Design.PropertyTab"></see> at the specified index.</summary>
            /// <returns>The <see cref="T:Design.PropertyTab"></see> at the specified index.</returns>
            /// <param name="index">The index of the <see cref="T:Design.PropertyTab"></see> to return. </param>
            public PropertyTab this[int index]
            {
                get
                {
                    if (this.mobjOwner == null)
                    {
                        throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
                    }
                    return this.mobjOwner.marrViewTabs[index];
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }


        }

        internal class SelectedObjectConverter : ReferenceConverter
        {
            public SelectedObjectConverter() : base(typeof(IComponent))
            {
            }

        }
        #endregion Classes
    }
}

