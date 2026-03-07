// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGrid
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides a user interface for browsing the properties of an object.</summary>
  /// <filterpriority>1</filterpriority>
  [ToolboxBitmap(typeof (PropertyGrid), "PropertyGrid_45.bmp")]
  [DesignTimeController("Design.PropertyGridController, Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [ToolboxItemCategory("Data")]
  [Gizmox.WebGUI.Forms.MetadataTag("PG")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (PropertyGridSkin))]
  [Serializable]
  public class PropertyGrid : ContainerControl, ISealedComponent
  {
    /// <summary>The PropertySortChanged event registration.</summary>
    private static readonly SerializableEvent PropertySortChangedEvent = SerializableEvent.Register("PropertySortChanged", typeof (EventHandler), typeof (PropertyGrid));
    /// <summary>The PropertyTabChanged event registration.</summary>
    private static readonly SerializableEvent PropertyTabChangedEvent = SerializableEvent.Register("PropertyTabChanged", typeof (PropertyTabChangedEventHandler), typeof (PropertyGrid));
    /// <summary>The PropertyValueChanged event registration.</summary>
    private static readonly SerializableEvent PropertyValueChangedEvent = SerializableEvent.Register("PropertyValueChanged", typeof (PropertyValueChangedEventHandler), typeof (PropertyGrid));
    /// <summary>The PropertyValueChanging event registration.</summary>
    private static readonly SerializableEvent PropertyValueChangingEvent = SerializableEvent.Register("PropertyValueChanging", typeof (PropertyValueChangingEventHandler), typeof (PropertyGrid));
    /// <summary>The SelectedGridItemChanged event registration.</summary>
    private static readonly SerializableEvent SelectedGridItemChangedEvent = SerializableEvent.Register("SelectedGridItemChanged", typeof (SelectedGridItemChangedEventHandler), typeof (PropertyGrid));
    /// <summary>The SelectedObjectsChanged event registration.</summary>
    private static readonly SerializableEvent SelectedObjectsChangedEvent = SerializableEvent.Register("SelectedObjectsChanged", typeof (EventHandler), typeof (PropertyGrid));
    /// <summary>The showing type editor event</summary>
    private static readonly SerializableEvent ShowingTypeEditorEvent = SerializableEvent.Register("BeforeTypeEditorOpen", typeof (EventHandler), typeof (PropertyGrid));
    private const ushort mcntTabsChanging = 8;
    private const int mcntPROPERTIES = 0;
    private const ushort mcntPropertiesChanged = 1;
    private const ushort mcntRefreshingProperties = 512;
    private const ushort mcntReInitTab = 32;
    private const ushort mcntInternalChange = 4;
    private const int mcntLARGE_BUTTONS = 1;
    private const int mcntEVENTS = 1;
    private const int mcntMIN_GRID_HEIGHT = 20;
    private const int mcntNO_SORT = 2;
    private const int mcntNORMAL_BUTTONS = 0;
    private const ushort mcntFullRefreshAfterBatch = 128;
    private const ushort mcntGotDesignerEventService = 2;
    private const int mcntCXINDENT = 0;
    private const int mcntCYDIVIDER = 3;
    private const int mcntCYINDENT = 2;
    private const int mcntALPHA = 1;
    private const ushort mcntBatchMode = 16;
    private const ushort mcntBatchModeChange = 256;
    private const int mcntCATEGORIES = 0;
    /// <summary>Attributes indicating browsable properties</summary>
    [NonSerialized]
    private AttributeCollection mobjBrowsableAttributes;
    /// <summary>The current browsed objects</summary>
    [NonSerialized]
    private object[] marrCurrentObjects;
    /// <summary>All the property entries</summary>
    [NonSerialized]
    private GridEntryCollection mobjCurrentPropEntries;
    /// <summary>The documentation panel</summary>
    [NonSerialized]
    private Panel mobjDocComment;
    /// <summary>The splitter for the documentation panel</summary>
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
    /// <summary>Reference to the containing designer if there is one</summary>
    [NonSerialized]
    private IDesignerHost mobjDesignerHost;
    /// <summary>Gets or sets the state</summary>
    /// <value>The state.</value>
    [NonSerialized]
    private ushort mState;
    /// <summary>Reference to the internal property grid view control.</summary>
    [NonSerialized]
    private PropertyGridView mobjPropertyGridView;
    /// <summary>Visibility flag indicating if the help is visible</summary>
    private bool mblnHelpVisible = true;
    /// <summary>The default grid entry</summary>
    [NonSerialized]
    private GridEntry mobjDefaultGridEntry;
    /// <summary>Reference to the main grid entry</summary>
    [NonSerialized]
    private GridEntry mobjMainGridEntry;
    /// <summary>The current sort value</summary>
    private PropertySort menmPropertySortValue;
    /// <summary>The current selected view sort</summary>
    private int mintSelectedViewSort;
    /// <summary>The current selected view tab</summary>
    private int mintSelectedViewTab;
    /// <summary>ToolStrip serperator</summary>
    [NonSerialized]
    private ToolStripSeparator mobjTBSeperator1;
    /// <summary>ToolStrip serperator</summary>
    [NonSerialized]
    private ToolStripSeparator mobjTBSeperator2;
    /// <summary>ToolStrip visibility flag</summary>
    private bool mblnToolbarVisible;
    /// <summary>The internal ToolStrip</summary>
    [NonSerialized]
    private PropertyGridToolStrip mobjToolStrip;
    /// <summary>The Reset button</summary>
    [NonSerialized]
    private ToolStripButton mobjResetButton;
    /// <summary>The current ToolStrip sort buttons</summary>
    [NonSerialized]
    private ToolStripButton[] marrViewSortButtons;
    /// <summary>The current ToolStrip tab buttons</summary>
    [NonSerialized]
    private ToolStripButton[] marrViewTabButtons;
    /// <summary>The current property tabs</summary>
    [NonSerialized]
    private Hashtable mobjViewTabProps;
    /// <summary>The current property tabs</summary>
    [NonSerialized]
    private PropertyTab[] marrViewTabs;
    /// <summary>Property tab scope collection</summary>
    [NonSerialized]
    private PropertyTabScope[] marrViewTabScopes;
    /// <summary>Dirty flag indicating if tabs are dirty</summary>
    [NonSerialized]
    private bool mblnViewTabsDirty;
    private long mlngPrivateId = 1;

    /// <summary>Occurs when the sort mode is changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridPropertySortChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler PropertySortChanged
    {
      add => this.AddHandler(PropertyGrid.PropertySortChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.PropertySortChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the PropertySortChanged event.</summary>
    private EventHandler PropertySortChangedHandler => (EventHandler) this.GetHandler(PropertyGrid.PropertySortChangedEvent);

    /// <summary>Occurs when a property tab changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("PropertyGridPropertyTabchangedDescr")]
    public event PropertyTabChangedEventHandler PropertyTabChanged
    {
      add => this.AddHandler(PropertyGrid.PropertyTabChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.PropertyTabChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the PropertyTabChanged event.</summary>
    private PropertyTabChangedEventHandler PropertyTabChangedHandler => (PropertyTabChangedEventHandler) this.GetHandler(PropertyGrid.PropertyTabChangedEvent);

    /// <summary>Occurs when a property value changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("PropertyGridPropertyValueChangedDescr")]
    public event PropertyValueChangedEventHandler PropertyValueChanged
    {
      add => this.AddHandler(PropertyGrid.PropertyValueChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.PropertyValueChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("Occurs when property value changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientPropertyValueChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected override string ClientEventsPropogationTags => string.Format("WC:{0}", (object) "PV");

    /// <summary>Gets the hanlder for the PropertyValueChanged event.</summary>
    private PropertyValueChangedEventHandler PropertyValueChangedHandler => (PropertyValueChangedEventHandler) this.GetHandler(PropertyGrid.PropertyValueChangedEvent);

    /// <summary>Occurs when a property value is about to change.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanging")]
    [SRDescription("PropertyGridPropertyValueChangingDescr")]
    public event PropertyValueChangingEventHandler PropertyValueChanging
    {
      add => this.AddHandler(PropertyGrid.PropertyValueChangingEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.PropertyValueChangingEvent, (Delegate) value);
    }

    /// <summary>Gets the handler for the PropertyValueChanging event.</summary>
    private PropertyValueChangingEventHandler PropertyValueChangingHandler => (PropertyValueChangingEventHandler) this.GetHandler(PropertyGrid.PropertyValueChangingEvent);

    /// <summary>Occurs when the selected <see cref="T:GridItem"></see> is changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridSelectedGridItemChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event SelectedGridItemChangedEventHandler SelectedGridItemChanged
    {
      add => this.AddHandler(PropertyGrid.SelectedGridItemChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.SelectedGridItemChangedEvent, (Delegate) value);
    }

    [SRDescription("Occurs when property grid's entry selected item changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedGridItemChanged
    {
      add => this.AddClientHandler("Activated", value);
      remove => this.RemoveClientHandler("Activated", value);
    }

    /// <summary>
    /// Gets the hanlder for the SelectedGridItemChanged event.
    /// </summary>
    private SelectedGridItemChangedEventHandler SelectedGridItemChangedHandler => (SelectedGridItemChangedEventHandler) this.GetHandler(PropertyGrid.SelectedGridItemChangedEvent);

    /// <summary>Occurs when the objects selected by the <see cref="P:PropertyGrid.SelectedObjects"></see> property have changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridSelectedObjectsChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler SelectedObjectsChanged
    {
      add => this.AddHandler(PropertyGrid.SelectedObjectsChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.SelectedObjectsChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the SelectedObjectsChanged event.
    /// </summary>
    private EventHandler SelectedObjectsChangedHandler => (EventHandler) this.GetHandler(PropertyGrid.SelectedObjectsChangedEvent);

    /// <summary>Occurs when [showing type editor].</summary>
    internal event ShowingTypeEditorEventHandler ShowingTypeEditor
    {
      add => this.AddHandler(PropertyGrid.ShowingTypeEditorEvent, (Delegate) value);
      remove => this.RemoveHandler(PropertyGrid.ShowingTypeEditorEvent, (Delegate) value);
    }

    /// <summary>Gets the showing type editor handler.</summary>
    /// <value>The showing type editor handler.</value>
    private ShowingTypeEditorEventHandler ShowingTypeEditorHandler => (ShowingTypeEditorEventHandler) this.GetHandler(PropertyGrid.ShowingTypeEditorEvent);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PropertyGrid"></see> class.
    /// </summary>
    public PropertyGrid() => this.InitializeComponent();

    /// <summary>Initialize the component contained controls</summary>
    private void InitializeComponent()
    {
      this.mblnHelpVisible = true;
      this.mblnToolbarVisible = true;
      this.mblnViewTabsDirty = true;
      this.marrViewTabs = new PropertyTab[0];
      this.marrViewTabScopes = new PropertyTabScope[0];
      this.menmPropertySortValue = PropertySort.CategorizedAlphabetical;
      this.SuspendLayout();
      try
      {
        this.mobjPropertyGridView = this.CreateGridView((IServiceProvider) null);
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
        this.AddRefTab(this.DefaultTabType, (object) null, PropertyTabScope.Static, true);
        this.CreateDocComment();
        this.SuspendLayout();
        this.mobjSplitter.Dock = DockStyle.Bottom;
        this.mobjSplitter.Visible = this.mblnHelpVisible;
        this.mobjDocComment.BorderStyle = this.PropertyGridSkin.HelpPanelStyle.BorderStyle;
        this.mobjDocComment.BorderColor = this.PropertyGridSkin.HelpPanelStyle.BorderColor;
        this.mobjDocComment.Padding = (Padding) this.PropertyGridSkin.HelpPanelStyle.Padding;
        this.mobjDocComment.BackColor = this.PropertyGridSkin.HelpPanelStyle.BackColor;
        this.mobjDocComment.Dock = DockStyle.Bottom;
        this.mobjDocComment.Visible = this.mblnHelpVisible;
        this.Controls.Add((Control) this.mobjPropertyGridView);
        this.Controls.Add((Control) this.mobjSplitter);
        this.Controls.Add((Control) this.mobjDocComment);
        this.Controls.Add((Control) this.mobjToolStrip);
        this.ResumeLayout(false);
        this.SetupToolbar();
        this.Text = nameof (PropertyGrid);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        if (this.mobjDocComment != null)
          this.mobjDocComment.ResumeLayout(false);
        this.ResumeLayout(true);
      }
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize;

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader) => base.OnSerializableObjectDeserializing(objReader);

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter) => base.OnSerializableObjectSerializing(objWriter);

    /// <summary>
    /// Gets a value indicating whether serializable object should serialize controls.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if serializable object should serialize controls; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldSerializableObjectSerializeControls => false;

    internal void AddRefTab(
      Type objTabType,
      object objComponent,
      PropertyTabScope objPropertyTabScope,
      bool blnSetupToolbar)
    {
      PropertyTab propertyTab = (PropertyTab) null;
      int index1 = -1;
      if (this.marrViewTabs != null)
      {
        for (int index2 = 0; index2 < this.marrViewTabs.Length; ++index2)
        {
          if (objTabType == this.marrViewTabs[index2].GetType())
          {
            propertyTab = this.marrViewTabs[index2];
            index1 = index2;
            break;
          }
        }
      }
      else
        index1 = 0;
      if (propertyTab == null)
      {
        IDesignerHost objDesignerHost = (IDesignerHost) null;
        if (objComponent != null && objComponent is IComponent && ((IComponent) objComponent).Site != null)
          objDesignerHost = (IDesignerHost) ((IComponent) objComponent).Site.GetService(typeof (IDesignerHost));
        try
        {
          propertyTab = this.CreateTab(objTabType, objDesignerHost);
        }
        catch (Exception ex)
        {
          return;
        }
        if (this.marrViewTabs != null)
        {
          index1 = this.marrViewTabs.Length;
          if (objTabType == this.DefaultTabType)
            index1 = 0;
          else if (typeof (EventsTab).IsAssignableFrom(objTabType))
          {
            index1 = 1;
          }
          else
          {
            for (int index3 = 1; index3 < this.marrViewTabs.Length; ++index3)
            {
              if (!(this.marrViewTabs[index3] is EventsTab) && string.Compare(propertyTab.TabName, this.marrViewTabs[index3].TabName, false, CultureInfo.InvariantCulture) < 0)
              {
                index1 = index3;
                break;
              }
            }
          }
        }
        PropertyTab[] destinationArray1 = new PropertyTab[this.marrViewTabs.Length + 1];
        Array.Copy((Array) this.marrViewTabs, 0, (Array) destinationArray1, 0, index1);
        Array.Copy((Array) this.marrViewTabs, index1, (Array) destinationArray1, index1 + 1, this.marrViewTabs.Length - index1);
        destinationArray1[index1] = propertyTab;
        this.marrViewTabs = destinationArray1;
        this.mblnViewTabsDirty = true;
        PropertyTabScope[] destinationArray2 = new PropertyTabScope[this.marrViewTabScopes.Length + 1];
        Array.Copy((Array) this.marrViewTabScopes, 0, (Array) destinationArray2, 0, index1);
        Array.Copy((Array) this.marrViewTabScopes, index1, (Array) destinationArray2, index1 + 1, this.marrViewTabScopes.Length - index1);
        destinationArray2[index1] = objPropertyTabScope;
        this.marrViewTabScopes = destinationArray2;
      }
      if (propertyTab != null)
      {
        if (objComponent != null)
        {
          try
          {
            object[] components = propertyTab.Components;
            int length = components == null ? 0 : components.Length;
            object[] destinationArray = new object[length + 1];
            if (length > 0)
              Array.Copy((Array) components, (Array) destinationArray, length);
            destinationArray[length] = objComponent;
            propertyTab.Components = destinationArray;
          }
          catch (Exception ex)
          {
            this.RemoveTab(index1, false);
          }
        }
      }
      if (!blnSetupToolbar)
        return;
      this.SetupToolbar();
      this.ShowEventsButton(false);
    }

    /// <summary>Adds the tab.</summary>
    /// <param name="objTabType">Type of the obj tab.</param>
    /// <param name="objScope">The obj scope.</param>
    internal void AddTab(Type objTabType, PropertyTabScope objScope) => this.AddRefTab(objTabType, (object) null, objScope, true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objPropertyTabScope"></param>
    internal void ClearTabs(PropertyTabScope objPropertyTabScope)
    {
      if (objPropertyTabScope < PropertyTabScope.Document)
        throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
      this.RemoveTabs(objPropertyTabScope, true);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ClearCachedProps()
    {
      if (this.mobjViewTabProps == null)
        return;
      this.mobjViewTabProps.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTabType"></param>
    internal void RemoveTab(Type objTabType)
    {
      int num = -1;
      for (int index = 0; index < this.marrViewTabs.Length; ++index)
      {
        if (objTabType == this.marrViewTabs[index].GetType())
        {
          PropertyTab marrViewTab = this.marrViewTabs[index];
          num = index;
          break;
        }
      }
      if (num == -1)
        return;
      PropertyTab[] destinationArray1 = new PropertyTab[this.marrViewTabs.Length - 1];
      Array.Copy((Array) this.marrViewTabs, 0, (Array) destinationArray1, 0, num);
      Array.Copy((Array) this.marrViewTabs, num + 1, (Array) destinationArray1, num, this.marrViewTabs.Length - num - 1);
      this.marrViewTabs = destinationArray1;
      PropertyTabScope[] destinationArray2 = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
      Array.Copy((Array) this.marrViewTabScopes, 0, (Array) destinationArray2, 0, num);
      Array.Copy((Array) this.marrViewTabScopes, num + 1, (Array) destinationArray2, num, this.marrViewTabScopes.Length - num - 1);
      this.marrViewTabScopes = destinationArray2;
      this.mblnViewTabsDirty = true;
      this.SetupToolbar();
    }

    /// <summary>Removes the tab.</summary>
    /// <param name="intTabIndex">Index of the int tab.</param>
    /// <param name="blnSetupToolbar">if set to <c>true</c> [BLN setup toolbar].</param>
    internal void RemoveTab(int intTabIndex, bool blnSetupToolbar)
    {
      if (intTabIndex >= this.marrViewTabs.Length || intTabIndex < 0)
        throw new ArgumentOutOfRangeException("tabIndex", SR.GetString("PropertyGridBadTabIndex"));
      if (this.marrViewTabScopes[intTabIndex] == PropertyTabScope.Static)
        throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
      if (this.mintSelectedViewTab == intTabIndex)
        this.mintSelectedViewTab = 0;
      ToolStripButton marrViewTabButton = this.marrViewTabButtons[this.mintSelectedViewTab];
      PropertyTab[] destinationArray1 = new PropertyTab[this.marrViewTabs.Length - 1];
      Array.Copy((Array) this.marrViewTabs, 0, (Array) destinationArray1, 0, intTabIndex);
      Array.Copy((Array) this.marrViewTabs, intTabIndex + 1, (Array) destinationArray1, intTabIndex, this.marrViewTabs.Length - intTabIndex - 1);
      this.marrViewTabs = destinationArray1;
      PropertyTabScope[] destinationArray2 = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
      Array.Copy((Array) this.marrViewTabScopes, 0, (Array) destinationArray2, 0, intTabIndex);
      Array.Copy((Array) this.marrViewTabScopes, intTabIndex + 1, (Array) destinationArray2, intTabIndex, this.marrViewTabScopes.Length - intTabIndex - 1);
      this.marrViewTabScopes = destinationArray2;
      this.mblnViewTabsDirty = true;
      if (!blnSetupToolbar)
        return;
      this.SetupToolbar();
      this.mintSelectedViewTab = -1;
    }

    /// <summary>Removes the tabs.</summary>
    /// <param name="enmClassification">The enm classification.</param>
    /// <param name="blnSetupToolbar">if set to <c>true</c> [BLN setup toolbar].</param>
    internal void RemoveTabs(PropertyTabScope enmClassification, bool blnSetupToolbar)
    {
      if (enmClassification == PropertyTabScope.Static)
        throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
      if (this.marrViewTabButtons == null || this.marrViewTabs == null || this.marrViewTabScopes == null)
        return;
      if (this.mintSelectedViewTab >= 0 && this.mintSelectedViewTab < this.marrViewTabButtons.Length)
      {
        ToolStripButton marrViewTabButton = this.marrViewTabButtons[this.mintSelectedViewTab];
      }
      for (int index = this.marrViewTabs.Length - 1; index >= 0; --index)
      {
        if (this.marrViewTabScopes[index] >= enmClassification)
        {
          if (this.mintSelectedViewTab == index)
            this.mintSelectedViewTab = -1;
          else if (this.mintSelectedViewTab > index)
            --this.mintSelectedViewTab;
          PropertyTab[] destinationArray1 = new PropertyTab[this.marrViewTabs.Length - 1];
          Array.Copy((Array) this.marrViewTabs, 0, (Array) destinationArray1, 0, index);
          Array.Copy((Array) this.marrViewTabs, index + 1, (Array) destinationArray1, index, this.marrViewTabs.Length - index - 1);
          this.marrViewTabs = destinationArray1;
          PropertyTabScope[] destinationArray2 = new PropertyTabScope[this.marrViewTabScopes.Length - 1];
          Array.Copy((Array) this.marrViewTabScopes, 0, (Array) destinationArray2, 0, index);
          Array.Copy((Array) this.marrViewTabScopes, index + 1, (Array) destinationArray2, index, this.marrViewTabScopes.Length - index - 1);
          this.marrViewTabScopes = destinationArray2;
          this.mblnViewTabsDirty = true;
        }
      }
      if (!blnSetupToolbar || !this.mblnViewTabsDirty)
        return;
      this.SetupToolbar();
      this.mintSelectedViewTab = -1;
      for (int index = 0; index < this.marrViewTabs.Length; ++index)
        this.marrViewTabs[index].Components = new object[0];
    }

    /// <summary>When overridden in a derived class, enables the creation of a <see cref="T:Design.PropertyTab"></see>.</summary>
    /// <returns>The newly created property tab. Returns null in its default implementation.</returns>
    /// <param name="objTabType">The type of tab to create. </param>
    protected virtual PropertyTab CreatePropertyTab(Type objTabType) => (PropertyTab) null;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objTabType"></param>
    /// <param name="objDesignerHost"></param>
    /// <returns></returns>
    private PropertyTab CreateTab(Type objTabType, IDesignerHost objDesignerHost)
    {
      PropertyTab tab = this.CreatePropertyTab(objTabType);
      if (tab == null)
      {
        ConstructorInfo constructor = objTabType.GetConstructor(new Type[1]
        {
          typeof (IServiceProvider)
        });
        object obj = (object) null;
        if (constructor == (ConstructorInfo) null)
        {
          constructor = objTabType.GetConstructor(new Type[1]
          {
            typeof (IDesignerHost)
          });
          if (constructor != (ConstructorInfo) null)
            obj = (object) objDesignerHost;
        }
        else
          obj = (object) this.Site;
        if (obj != null && constructor != (ConstructorInfo) null)
          tab = (PropertyTab) constructor.Invoke(new object[1]
          {
            obj
          });
        else
          tab = (PropertyTab) Activator.CreateInstance(objTabType);
      }
      return tab;
    }

    private void EnableTabs()
    {
      if (this.marrCurrentObjects == null)
        return;
      this.SetupToolbar();
      for (int index = 1; index < this.marrViewTabs.Length; ++index)
      {
        bool flag = true;
        for (int intIndex = 0; intIndex < this.marrCurrentObjects.Length; ++intIndex)
        {
          try
          {
            if (!this.marrViewTabs[index].CanExtend(this.GetUnwrappedObject(intIndex)))
            {
              flag = false;
              break;
            }
          }
          catch (Exception ex)
          {
            flag = false;
            break;
          }
        }
        if (flag != this.marrViewTabButtons[index].Visible)
        {
          this.marrViewTabButtons[index].Visible = flag;
          if (!flag && index == this.mintSelectedViewTab)
            this.SelectViewTabButton(this.marrViewTabButtons[0], true);
        }
      }
    }

    private void SelectViewTabButton(ToolStripButton objToolBarButton, bool blnUpdateSelection)
    {
      this.SelectViewTabButtonDefault(objToolBarButton);
      if (!blnUpdateSelection)
        return;
      this.Refresh(false);
    }

    /// <summary>Resets the selected property.</summary>
    public void ResetSelectedProperty()
    {
      GridEntry selectedGridEntry = this.mobjPropertyGridView.SelectedGridEntry;
      if (selectedGridEntry != null)
        this.ResetSelectedProperty(selectedGridEntry.PropertyDescriptor);
      else
        this.ResetSelectedProperty((PropertyDescriptor) null);
    }

    /// <summary>Resets the selected property.</summary>
    /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
    public virtual void ResetSelectedProperty(PropertyDescriptor objPropertyDescriptor) => this.mobjPropertyGridView.Reset();

    /// <summary>Clears the value caches</summary>
    internal void ClearValueCaches()
    {
      if (this.mobjMainGridEntry == null)
        return;
      this.mobjMainGridEntry.ClearCachedValues();
    }

    /// <summary>Collapses all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public void CollapseAllGridItems()
    {
    }

    private void CreateDocComment()
    {
      this.mobjDocComment = new Panel();
      this.mobjSplitter = new Splitter();
      this.mobjSplitter.Height = 5;
      this.mobjLabelDocTitle = new Label(string.Empty);
      this.mobjLabelDocTitle.Font = new Font(this.Font, FontStyle.Bold);
      this.mobjLabelDocTitle.Dock = DockStyle.Top;
      this.mobjLabelDocDescription = new Label(string.Empty);
      this.mobjLabelDocDescription.Font = this.Font;
      this.mobjLabelDocDescription.Dock = DockStyle.Fill;
      this.mobjDocComment.Controls.Add((Control) this.mobjLabelDocDescription);
      this.mobjDocComment.Controls.Add((Control) this.mobjLabelDocTitle);
    }

    /// <summary>Creates the grid view</summary>
    /// <param name="objServiceProvider"></param>
    /// <returns></returns>
    private PropertyGridView CreateGridView(IServiceProvider objServiceProvider) => new PropertyGridView(objServiceProvider, this);

    /// <summary>Create a Push button</summary>
    /// <param name="strToolTipText">The STR tool tip text.</param>
    /// <param name="strSkinImage">The STR skin image.</param>
    /// <param name="objEventHandler">The obj event handler.</param>
    /// <returns></returns>
    private ToolStripButton CreatePushButton(
      string strToolTipText,
      string strSkinImage,
      EventHandler objEventHandler)
    {
      ToolStripButton pushButton = new ToolStripButton();
      pushButton.Text = strToolTipText;
      pushButton.AutoToolTip = true;
      pushButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      if (strSkinImage != string.Empty)
        pushButton.Image = this.Skin.GetResourceHandle(strSkinImage);
      pushButton.Click += objEventHandler;
      pushButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;
      return pushButton;
    }

    /// <summary>Creates the separator button.</summary>
    /// <returns></returns>
    private ToolStripSeparator CreateSeparatorButton()
    {
      ToolStripSeparator separatorButton = new ToolStripSeparator();
      separatorButton.Height = 20;
      return separatorButton;
    }

    /// <summary>Unregister a grid component.</summary>
    /// <param name="objComponent">Component.</param>
    internal void UnRegisterGridComponent(IRegisteredComponentMember objComponent)
    {
      if (!objComponent.IsRegistered)
        return;
      objComponent.MemberID = 0L;
      objComponent.IsRegistered = false;
    }

    /// <summary>Unregister a collection of grid components</summary>
    /// <param name="objComponents"></param>
    internal void UnRegisterGridComponents(ICollection objComponents)
    {
      foreach (IRegisteredComponentMember objComponent in (IEnumerable) objComponents)
        this.UnRegisterGridComponent(objComponent);
    }

    /// <summary>
    /// Provides a registering service for contained components.
    /// </summary>
    /// <param name="objComponent"></param>
    internal void RegisterGridComponent(IRegisteredComponentMember objComponent)
    {
      if (objComponent.IsRegistered)
        return;
      objComponent.MemberID = this.mlngPrivateId++;
      objComponent.IsRegistered = true;
    }

    /// <summary>
    /// Provides a registering service for contained components.
    /// </summary>
    /// <param name="objComponents"></param>
    internal void RegisterGridComponents(ICollection objComponents)
    {
      foreach (IRegisteredComponentMember objComponent in (IEnumerable) objComponents)
        this.RegisterGridComponent(objComponent);
    }

    /// <summary>Expands all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    public void ExpandAllGridItems()
    {
    }

    private static Type[] GetCommonTabs(object[] arrObjects, PropertyTabScope objPropertyTabScope)
    {
      if (arrObjects == null || arrObjects.Length == 0)
        return new Type[0];
      Type[] sourceArray = new Type[5];
      int length = 0;
      PropertyTabAttribute attribute1 = (PropertyTabAttribute) TypeDescriptor.GetAttributes(arrObjects[0])[typeof (PropertyTabAttribute)];
      if (attribute1 == null)
        return new Type[0];
      for (int index = 0; index < attribute1.TabScopes.Length; ++index)
      {
        if (attribute1.TabScopes[index] == objPropertyTabScope)
        {
          if (length == sourceArray.Length)
          {
            Type[] destinationArray = new Type[length * 2];
            Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 0, length);
            sourceArray = destinationArray;
          }
          sourceArray[length++] = attribute1.TabClasses[index];
        }
      }
      if (length == 0)
        return new Type[0];
      for (int index1 = 1; index1 < arrObjects.Length && length > 0; ++index1)
      {
        PropertyTabAttribute attribute2 = (PropertyTabAttribute) TypeDescriptor.GetAttributes(arrObjects[index1])[typeof (PropertyTabAttribute)];
        if (attribute2 == null)
          return new Type[0];
        for (int index2 = 0; index2 < length; ++index2)
        {
          bool flag = false;
          for (int index3 = 0; index3 < attribute2.TabClasses.Length; ++index3)
          {
            if (attribute2.TabClasses[index3] == sourceArray[index2])
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            sourceArray[index2] = sourceArray[length - 1];
            sourceArray[length - 1] = (Type) null;
            --length;
            --index2;
          }
        }
      }
      Type[] destinationArray1 = new Type[length];
      if (length > 0)
        Array.Copy((Array) sourceArray, 0, (Array) destinationArray1, 0, length);
      return destinationArray1;
    }

    internal GridEntry GetDefaultGridEntry()
    {
      if (this.mobjDefaultGridEntry == null && this.mobjCurrentPropEntries != null)
        this.mobjDefaultGridEntry = (GridEntry) this.mobjCurrentPropEntries[0];
      return this.mobjDefaultGridEntry;
    }

    /// <summary>Get the state of a specific flag</summary>
    private bool GetState(ushort flag) => ((uint) this.mState & (uint) flag) > 0U;

    internal GridEntryCollection GetPropEntries()
    {
      if (this.mobjCurrentPropEntries == null)
        this.UpdateSelection();
      this.SetState((ushort) 1, false);
      return this.mobjCurrentPropEntries;
    }

    private PropertyGridView GetPropertyGridView() => this.mobjPropertyGridView;

    private object GetUnwrappedObject(int intIndex)
    {
      if (this.marrCurrentObjects == null || intIndex < 0 || intIndex > this.marrCurrentObjects.Length)
        return (object) null;
      object unwrappedObject = this.marrCurrentObjects[intIndex];
      if (unwrappedObject is ICustomTypeDescriptor)
        unwrappedObject = ((ICustomTypeDescriptor) unwrappedObject).GetPropertyOwner((PropertyDescriptor) null);
      return unwrappedObject;
    }

    /// <summary>Gets the property value.</summary>
    /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
    /// <param name="objTarget">The obj target.</param>
    /// <returns></returns>
    protected internal virtual object GetPropertyValue(
      PropertyDescriptor objPropertyDescriptor,
      object objTarget)
    {
      return objPropertyDescriptor.GetValue(objTarget);
    }

    /// <summary>Sets the property value.</summary>
    /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objValue">The obj value.</param>
    protected internal virtual void SetPropertyValue(
      PropertyDescriptor objPropertyDescriptor,
      object objComponent,
      object objValue)
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
    protected internal virtual bool CanResetPropertyValue(GridEntry objGridEntry) => objGridEntry != null && objGridEntry.CanResetPropertyValue();

    /// <summary>Raises the <see cref="M:System.Drawing.Design.IPropertyValueUIService.NotifyPropertyValueUIItemsChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    /// <param name="sender">The source of the event. </param>
    protected void OnNotifyPropertyValueUIItemsChanged(object sender, EventArgs e) => this.mobjPropertyGridView.Invalidate(true);

    /// <summary>Raises the <see cref="E:PropertyGrid.PropertySortChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnPropertySortChanged(EventArgs e)
    {
      EventHandler sortChangedHandler = this.PropertySortChangedHandler;
      if (sortChangedHandler == null)
        return;
      sortChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:PropertyGrid.PropertyTabChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:PropertyTabChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnPropertyTabChanged(PropertyTabChangedEventArgs e)
    {
      PropertyTabChangedEventHandler tabChangedHandler = this.PropertyTabChangedHandler;
      if (tabChangedHandler == null)
        return;
      tabChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:PropertyGrid.PropertyValueChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:PropertyValueChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
    {
      PropertyValueChangedEventHandler valueChangedHandler = this.PropertyValueChangedHandler;
      if (valueChangedHandler == null)
        return;
      valueChangedHandler((object) this, e);
    }

    /// <summary>Raises the PropertyValue event.</summary>
    internal void OnPropertyValueSet(GridItem objChangedItem, object objOldValue) => this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(objChangedItem, objOldValue));

    /// <summary>Raises the <see cref="E:PropertyGrid.PropertyValueChanging"></see> event.</summary>
    /// <param name="e">A <see cref="T:PropertyValueChangingEventArgs"></see> that contains the event data. </param>
    protected virtual void OnPropertyValueChanging(PropertyValueChangingEventArgs e)
    {
      PropertyValueChangingEventHandler valueChangingHandler = this.PropertyValueChangingHandler;
      if (valueChangingHandler == null)
        return;
      valueChangingHandler((object) this, e);
    }

    /// <summary>
    /// Raises the PropertyValueChanging event.
    /// <returns>Returns true if the action should be cancelled</returns>
    /// </summary>
    internal PropertyValueChangingEventArgs OnPropertyValueSetting(
      GridItem objChangingItem,
      object objNewValue)
    {
      PropertyValueChangingEventArgs e = new PropertyValueChangingEventArgs(objChangingItem, objNewValue);
      this.OnPropertyValueChanging(e);
      return e;
    }

    /// <summary>Raises the <see cref="E:PropertyGrid.SelectedGridItemChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:SelectedGridItemChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnSelectedGridItemChanged(SelectedGridItemChangedEventArgs e)
    {
      SelectedGridItemChangedEventHandler itemChangedHandler = this.SelectedGridItemChangedHandler;
      if (itemChangedHandler == null)
        return;
      itemChangedHandler((object) this, e);
    }

    internal void OnSelectedGridItemChanged(GridEntry objOldEntry, GridEntry objNewEntry) => this.OnSelectedGridItemChanged(new SelectedGridItemChangedEventArgs((GridItem) objOldEntry, (GridItem) objNewEntry));

    /// <summary>Raises the <see cref="E:PropertyGrid.SelectedObjectsChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnSelectedObjectsChanged(EventArgs e)
    {
      EventHandler objectsChangedHandler = this.SelectedObjectsChangedHandler;
      if (objectsChangedHandler == null)
        return;
      objectsChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:OnShowingEditTypeEditor" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ShowingTypeEditorEventArgs" /> instance containing the event data.</param>
    internal virtual void OnShowingEditTypeEditor(ShowingTypeEditorEventArgs e)
    {
      ShowingTypeEditorEventHandler typeEditorHandler = this.ShowingTypeEditorHandler;
      if (typeEditorHandler == null)
        return;
      typeEditorHandler((object) this, e);
    }

    private void OnTransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
    {
    }

    /// <summary>Causes the property grid to refresh it's view.</summary>
    private void Refresh(bool blnClearCached)
    {
      if (this.Disposing)
        return;
      if (this.GetState((ushort) 512))
        return;
      try
      {
        this.SetState((ushort) 512, true);
        if (blnClearCached)
          this.ClearCachedProps();
        this.RefreshProperties(blnClearCached);
        this.mobjPropertyGridView.Refresh();
        this.DisplayHotCommands();
      }
      finally
      {
        this.SetState((ushort) 512, false);
        this.mobjPropertyGridView.Update();
      }
    }

    private void OnTransactionOpened(object sender, EventArgs e) => this.SetState((ushort) 16, true);

    /// <summary>Causes the property grid to refresh it's view.</summary>
    /// <filterpriority>2</filterpriority>
    public new void Refresh() => this.Refresh(true);

    /// <summary>
    /// Causes the property grid to refresh it's calculated properties.
    /// </summary>
    protected internal void RefreshProperties(bool blnClearCached)
    {
      if (blnClearCached && this.mintSelectedViewTab != -1 && this.marrViewTabs != null)
      {
        PropertyTab marrViewTab = this.marrViewTabs[this.mintSelectedViewTab];
        if (marrViewTab != null && this.mobjViewTabProps != null)
          this.mobjViewTabProps.Remove((object) (marrViewTab.TabName + this.menmPropertySortValue.ToString()));
      }
      this.SetState((ushort) 1, true);
      this.UpdateSelection();
    }

    /// <summary>Refreshes the property tabs of the specified scope.</summary>
    /// <param name="objPropertyTabScope">Either the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </param>
    /// <exception cref="T:System.ArgumentException">The objPropertyTabScope parameter is not the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
    /// <filterpriority>2</filterpriority>
    public void RefreshTabs(PropertyTabScope objPropertyTabScope)
    {
      if (objPropertyTabScope < PropertyTabScope.Document)
        throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
      this.RemoveTabs(objPropertyTabScope, false);
      if (objPropertyTabScope <= PropertyTabScope.Component && this.marrCurrentObjects != null && this.marrCurrentObjects.Length != 0)
      {
        foreach (Type commonTab in PropertyGrid.GetCommonTabs(this.marrCurrentObjects, PropertyTabScope.Component))
        {
          for (int index = 0; index < this.marrCurrentObjects.Length; ++index)
            this.AddRefTab(commonTab, this.marrCurrentObjects[index], PropertyTabScope.Component, false);
        }
      }
      this.SetupToolbar();
    }

    internal void ReleaseTab(Type objTabType, object objComponent)
    {
      PropertyTab propertyTab = (PropertyTab) null;
      int intTabIndex = -1;
      for (int index = 0; index < this.marrViewTabs.Length; ++index)
      {
        if (objTabType == this.marrViewTabs[index].GetType())
        {
          propertyTab = this.marrViewTabs[index];
          intTabIndex = index;
          break;
        }
      }
      if (propertyTab == null)
        return;
      object[] objArray = propertyTab.Components;
      bool flag;
      try
      {
        int num = -1;
        if (objArray != null)
          num = new ArrayList((ICollection) objArray).IndexOf(objComponent);
        if (num >= 0)
        {
          object[] destinationArray = new object[objArray.Length - 1];
          Array.Copy((Array) objArray, 0, (Array) destinationArray, 0, num);
          Array.Copy((Array) objArray, num + 1, (Array) destinationArray, num, objArray.Length - num - 1);
          objArray = destinationArray;
          propertyTab.Components = objArray;
        }
        flag = objArray.Length == 0;
      }
      catch (Exception ex)
      {
        flag = true;
      }
      if (!flag || this.marrViewTabScopes[intTabIndex] <= PropertyTabScope.Global)
        return;
      this.RemoveTab(intTabIndex, false);
    }

    internal void ReplaceSelectedObject(object objOldObject, object objNewObject)
    {
      for (int index = 0; index < this.marrCurrentObjects.Length; ++index)
      {
        if (this.marrCurrentObjects[index] == objOldObject)
        {
          this.marrCurrentObjects[index] = objNewObject;
          this.Refresh(true);
          break;
        }
      }
    }

    private void SetState(ushort flag, bool blnValue)
    {
      if (blnValue)
        this.mState |= flag;
      else
        this.mState &= ~flag;
    }

    internal void SetStatusBox(string strTitle, string strDescription)
    {
      this.mobjLabelDocTitle.Text = strTitle == null ? "" : strTitle;
      this.mobjLabelDocDescription.Text = strDescription == null ? "" : strDescription;
    }

    /// <summary>Create the toolbar.</summary>
    private void SetupToolbar() => this.SetupToolbar(false);

    /// <summary>Show or hide the toolbar.</summary>
    private void SetupToolbar(bool blnFullRebuild)
    {
      if (!(this.mblnViewTabsDirty | blnFullRebuild))
        return;
      try
      {
        EventHandler objEventHandler1 = new EventHandler(this.OnViewTabButtonClick);
        EventHandler objEventHandler2 = new EventHandler(this.OnViewSortButtonClick);
        EventHandler objEventHandler3 = new EventHandler(this.OnResetButtonClick);
        EventHandler objEventHandler4 = new EventHandler(this.OnViewButtonCategories);
        ArrayList arrayList = !blnFullRebuild ? new ArrayList((ICollection) this.mobjToolStrip.Items) : new ArrayList();
        if (this.marrViewSortButtons == null | blnFullRebuild)
        {
          this.marrViewSortButtons = new ToolStripButton[2];
          this.marrViewSortButtons[1] = this.CreatePushButton(SR.GetString("PBRSToolTipAlphabetic"), "SortAtoZ.gif", objEventHandler2);
          this.marrViewSortButtons[0] = this.CreatePushButton(SR.GetString("PBRSToolTipCategorized"), "ShowCategories.gif", objEventHandler4);
          this.marrViewSortButtons[0].Checked = this.menmPropertySortValue == PropertySort.CategorizedAlphabetical;
          this.marrViewSortButtons[1].Checked = this.menmPropertySortValue == PropertySort.Alphabetical;
          for (int index = 0; index < this.marrViewSortButtons.Length; ++index)
            arrayList.Add((object) this.marrViewSortButtons[index]);
        }
        else
        {
          for (int index = arrayList.Count - 1; index >= 2; --index)
            arrayList.RemoveAt(index);
        }
        arrayList.Add((object) this.mobjTBSeperator1);
        this.mobjResetButton = this.CreatePushButton(string.Empty, "Reset.png", objEventHandler3);
        this.mobjResetButton.Enabled = false;
        arrayList.Add((object) this.mobjResetButton);
        this.marrViewTabButtons = new ToolStripButton[this.marrViewTabs.Length];
        bool flag = this.marrViewTabs.Length > 1;
        for (int index = 0; index < this.marrViewTabs.Length; ++index)
        {
          try
          {
            this.marrViewTabButtons[index] = this.CreatePushButton(this.marrViewTabs[index].TabName, "Action.ShowPropertyPages.gif", objEventHandler1);
            if (flag)
              arrayList.Add((object) this.marrViewTabButtons[index]);
          }
          catch (Exception ex)
          {
          }
        }
        if (flag)
          arrayList.Add((object) this.mobjTBSeperator2);
        this.mobjToolStrip.Items.Clear();
        for (int index = 0; index < arrayList.Count; ++index)
          this.mobjToolStrip.Items.Add(arrayList[index] as ToolStripItem);
        this.mblnViewTabsDirty = false;
      }
      finally
      {
      }
    }

    /// <summary>Called when [view reset button click].</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnResetButtonClick(object sender, EventArgs e) => this.ResetSelectedProperty();

    /// <summary>Show or hide the events button.</summary>
    protected void ShowEventsButton(bool blnValue)
    {
      if (this.marrViewTabs != null && this.marrViewTabs.Length > 1 && this.marrViewTabs[1] is EventsTab)
      {
        this.marrViewTabButtons[1].Visible = blnValue;
        if (!blnValue && this.mintSelectedViewTab == 1)
          this.SelectViewTabButton(this.marrViewTabButtons[0], true);
      }
      this.UpdatePropertiesViewTabVisibility();
    }

    private void UpdatePropertiesViewTabVisibility()
    {
      if (this.marrViewTabButtons == null)
        return;
      int num = 0;
      for (int index = 1; index < this.marrViewTabButtons.Length; ++index)
      {
        if (this.marrViewTabButtons[index].Visible)
          ++num;
      }
      if (num > 0)
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

    /// <summary>
    /// Updates the current selection to apply selected objects
    /// </summary>
    internal void UpdateSelection()
    {
      if (!this.GetState((ushort) 1) || this.marrViewTabs == null)
        return;
      string key = this.marrViewTabs[this.mintSelectedViewTab].TabName + this.menmPropertySortValue.ToString();
      if (this.mobjViewTabProps != null && this.mobjViewTabProps.ContainsKey((object) key))
      {
        this.mobjMainGridEntry = (GridEntry) this.mobjViewTabProps[(object) key];
        if (this.mobjMainGridEntry != null)
          this.mobjMainGridEntry.Refresh();
      }
      else
      {
        this.mobjMainGridEntry = this.marrCurrentObjects == null || this.marrCurrentObjects.Length == 0 ? (GridEntry) null : (GridEntry) GridEntry.Create(this.mobjPropertyGridView, this.marrCurrentObjects, (IServiceProvider) new PropertyGrid.PropertyGridServiceProvider(this), this.mobjDesignerHost, this.SelectedTab, this.menmPropertySortValue);
        if (this.mobjMainGridEntry == null)
        {
          this.mobjCurrentPropEntries = new GridEntryCollection((GridEntry) null, new GridEntry[0]);
          this.mobjPropertyGridView.ClearProps();
          return;
        }
        if (this.BrowsableAttributes != null)
          this.mobjMainGridEntry.BrowsableAttributes = this.BrowsableAttributes;
        if (this.mobjViewTabProps == null)
          this.mobjViewTabProps = new Hashtable();
        this.mobjViewTabProps[(object) key] = (object) this.mobjMainGridEntry;
      }
      this.mobjCurrentPropEntries = this.mobjMainGridEntry.Children;
      this.mobjDefaultGridEntry = this.mobjMainGridEntry.DefaultChild;
      this.mobjPropertyGridView.Invalidate();
    }

    internal IDesignerHost ActiveDesigner
    {
      get => (IDesignerHost) null;
      set
      {
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool AutoScroll
    {
      get => base.AutoScroll;
      set => base.AutoScroll = value;
    }

    /// <summary>Gets or sets the browsable attributes associated with the object that the property grid is attached to.</summary>
    /// <returns>The collection of browsable attributes associated with the object.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public AttributeCollection BrowsableAttributes
    {
      get
      {
        if (this.mobjBrowsableAttributes == null)
          this.mobjBrowsableAttributes = new AttributeCollection(new Attribute[1]
          {
            (Attribute) new BrowsableAttribute(true)
          });
        return this.mobjBrowsableAttributes;
      }
      set
      {
        if (value == null || value == AttributeCollection.Empty)
        {
          this.mobjBrowsableAttributes = new AttributeCollection(new Attribute[1]
          {
            (Attribute) BrowsableAttribute.Yes
          });
        }
        else
        {
          Attribute[] attributeArray = new Attribute[value.Count];
          value.CopyTo((Array) attributeArray, 0);
          this.mobjBrowsableAttributes = new AttributeCollection(attributeArray);
        }
        if (this.marrCurrentObjects == null || this.marrCurrentObjects.Length == 0 || this.mobjMainGridEntry == null)
          return;
        this.mobjMainGridEntry.BrowsableAttributes = this.BrowsableAttributes;
        this.Refresh(true);
      }
    }

    private bool CanCopy => this.mobjPropertyGridView.CanCopy;

    private bool CanCut => this.mobjPropertyGridView.CanCut;

    private bool CanPaste => this.mobjPropertyGridView.CanPaste;

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets the main GridItem. i.e. the root item.</summary>
    /// <value></value>
    [Browsable(false)]
    public GridItem MainGridItem => (GridItem) this.mobjMainGridEntry;

    /// <summary>Gets a value indicating whether the commands pane can be made visible for the currently selected objects.</summary>
    /// <returns>true if the commands pane can be made visible; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [SRDescription("PropertyGridCanShowCommandsDesc")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual bool CanShowCommands => false;

    private bool CanUndo => this.mobjPropertyGridView.CanUndo;

    /// <summary>Gets or sets the text color used for category headings. </summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the text color.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("PropertyGridCategoryForeColorDesc")]
    [DefaultValue(typeof (Color), "ControlText")]
    public Color CategoryForeColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets a value indicating whether the commands pane is visible.</summary>
    /// <returns>true if the commands pane is visible; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public virtual bool CommandsVisible => false;

    /// <summary>Gets or sets a value indicating whether the commands pane is visible for objects that expose verbs.</summary>
    /// <returns>true if the commands pane is visible; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    [SRDescription("PropertyGridCommandsVisibleIfAvailable")]
    public virtual bool CommandsVisibleIfAvailable
    {
      get => false;
      set
      {
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Control.ControlCollection"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Control.ControlCollection Controls => base.Controls;

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(130, 130);

    /// <summary>Gets the type of the default tab.</summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the default tab.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual Type DefaultTabType => typeof (PropertiesTab);

    /// <summary>Gets or sets a value indicating whether the <see cref="T:PropertyGrid"></see> control paints its toolbar with flat buttons.</summary>
    /// <returns>true if the <see cref="T:PropertyGrid"></see> paints its toolbar with flat buttons; otherwise false. The default is false.</returns>
    protected bool DrawFlatToolbar
    {
      get => true;
      set
      {
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets or sets the background color for the Help region.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for controls.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridHelpBackColorDesc")]
    [SRCategory("CatAppearance")]
    public Color HelpBackColor
    {
      get => this.mobjDocComment.BackColor;
      set => this.mobjDocComment.BackColor = value;
    }

    /// <summary>Resets the color of the help back.</summary>
    private void ResetHelpBackColor() => this.HelpBackColor = this.PropertyGridSkin.HelpPanelStyle.BackColor;

    /// <summary>Determine whether We Should the HelpBackColor</summary>
    /// <returns></returns>
    private bool ShouldSerializeHelpBackColor() => this.mobjDocComment.BackColor != this.PropertyGridSkin.HelpPanelStyle.BackColor;

    /// <summary>Gets or sets the foreground color for the Help region.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for control text.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(typeof (Color), "ControlText")]
    [SRDescription("PropertyGridHelpForeColorDesc")]
    public Color HelpForeColor
    {
      get => this.mobjDocComment.ForeColor;
      set => this.mobjDocComment.ForeColor = value;
    }

    /// <summary>Gets or sets a value indicating whether the Help text is visible.</summary>
    /// <returns>true if the help text is visible; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(true)]
    [Localizable(true)]
    [SRDescription("PropertyGridHelpVisibleDesc")]
    public virtual bool HelpVisible
    {
      get => this.mblnHelpVisible;
      set
      {
        if (this.mblnHelpVisible == value)
          return;
        this.mblnHelpVisible = value;
        this.mobjSplitter.Visible = value;
        this.mobjDocComment.Visible = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether buttons appear in standard size or in large size.</summary>
    /// <returns>true if buttons on the control appear large; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("PropertyGridLargeButtonsDesc")]
    public bool LargeButtons
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the color of the gridlines and borders.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for scroll bars.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridLineColorDesc")]
    [DefaultValue(typeof (Color), "InactiveBorder")]
    [SRCategory("CatAppearance")]
    public Color LineColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    internal PropertyGridView PropertyGridView => this.mobjPropertyGridView;

    /// <summary>Gets the property grid skin.</summary>
    /// <value>The property grid skin.</value>
    private PropertyGridSkin PropertyGridSkin => this.Skin as PropertyGridSkin;

    /// <summary>Gets or sets the type of sorting the <see cref="T:PropertyGrid"></see> uses to display properties.</summary>
    /// <returns>One of the <see cref="T:PropertySort"></see> values. The default is <see cref="F:PropertySort.Categorized"></see> or <see cref="F:PropertySort.Alphabetical"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:PropertySort"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("PropertyGridPropertySortDesc")]
    [DefaultValue(3)]
    public PropertySort PropertySort
    {
      get => this.menmPropertySortValue;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (PropertySort));
        if ((value & PropertySort.Categorized) != PropertySort.NoSort)
        {
          ToolStripButton marrViewSortButton1 = this.marrViewSortButtons[0];
        }
        else if ((value & PropertySort.Alphabetical) != PropertySort.NoSort)
        {
          ToolStripButton marrViewSortButton2 = this.marrViewSortButtons[1];
        }
        GridItem selectedGridItem = this.SelectedGridItem;
        this.menmPropertySortValue = value;
        if (selectedGridItem == null)
          return;
        try
        {
          this.SelectedGridItem = selectedGridItem;
        }
        catch (ArgumentException ex)
        {
        }
      }
    }

    private void OnViewTabButtonClick(object objSender, EventArgs eventArgs)
    {
    }

    private void OnViewSortButtonClick(object objSender, EventArgs eventArgs) => this.ApplyPropertySort(PropertySort.Alphabetical);

    /// <summary>Called when [view button categories].</summary>
    /// <param name="objSender">The obj sender.</param>
    /// <param name="eventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnViewButtonCategories(object objSender, EventArgs eventArgs) => this.ApplyPropertySort(PropertySort.CategorizedAlphabetical);

    /// <summary>Applies the property sort.</summary>
    /// <param name="enmPropertySort">The enm property sort.</param>
    private void ApplyPropertySort(PropertySort enmPropertySort)
    {
      if (this.menmPropertySortValue == enmPropertySort)
        return;
      this.marrViewSortButtons[0].Checked = enmPropertySort == PropertySort.CategorizedAlphabetical;
      this.marrViewSortButtons[1].Checked = enmPropertySort == PropertySort.Alphabetical;
      this.menmPropertySortValue = enmPropertySort;
      this.Refresh(false);
    }

    internal bool HavePropEntriesChanged() => this.GetState((ushort) 1);

    /// <summary>Gets the collection of property tabs that are displayed in the grid.</summary>
    /// <returns>A <see cref="T:PropertyGrid.PropertyTabCollection"></see> containing the collection of <see cref="T:Design.PropertyTab"></see> objects being displayed by the <see cref="T:PropertyGrid"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PropertyGrid.PropertyTabCollection PropertyTabs => new PropertyGrid.PropertyTabCollection(this);

    internal void SetActiveGridEntry(GridEntry objGridEntry) => this.SetStatusBox(objGridEntry.PropertyLabel, objGridEntry.PropertyDescription);

    /// <summary>Gets or sets the selected grid item.</summary>
    /// <returns>The currently selected row in the property grid.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public GridItem SelectedGridItem
    {
      get => (GridItem) this.mobjPropertyGridView.SelectedGridEntry ?? (GridItem) this.mobjMainGridEntry;
      set => this.mobjPropertyGridView.SelectedGridEntry = (GridEntry) value;
    }

    /// <summary>Indicates if to render padding attribute</summary>
    /// <returns></returns>
    protected override bool ShouldRenderPaddingAttribute(Padding objPadding) => (Padding) PaddingValue.Empty != objPadding;

    /// <summary>Gets or sets the object for which the grid displays properties.</summary>
    /// <returns>The first object in the object list. If there is no currently selected object the return is null.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridSelectedObjectDesc")]
    [SRCategory("CatBehavior")]
    [DefaultValue(null)]
    [TypeConverter(typeof (PropertyGrid.SelectedObjectConverter))]
    public object SelectedObject
    {
      get => this.marrCurrentObjects != null && this.marrCurrentObjects.Length != 0 ? this.marrCurrentObjects[0] : (object) null;
      set
      {
        if (value == this.SelectedObject && this.SelectedObjects.Length <= 1)
          return;
        if (value == null)
          this.SelectedObjects = new object[0];
        else
          this.SelectedObjects = new object[1]{ value };
      }
    }

    /// <summary>Gets or sets the currently selected objects.</summary>
    /// <returns>An array of type <see cref="T:System.Object"></see>. The default is an empty array.</returns>
    /// <exception cref="T:System.ArgumentException">One of the items in the array of objects had a null value. </exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object[] SelectedObjects
    {
      get => this.marrCurrentObjects == null ? new object[0] : (object[]) this.marrCurrentObjects.Clone();
      set
      {
        bool flag1 = false;
        this.SetState((ushort) 128, false);
        if (this.GetState((ushort) 16))
          this.SetState((ushort) 256, false);
        this.mobjPropertyGridView.EnsurePendingChangesCommitted();
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = true;
        if (value != null && value.Length != 0)
        {
          for (int index = 0; index < value.Length; ++index)
          {
            if (value[index] == null)
              throw new ArgumentException("SelectedObjects can not have a null item.");
            if (value[index] is PropertyGrid.IUnimplemented)
              throw new NotSupportedException("SelectedObjects can not contain PropertyGrid.");
          }
        }
        else
          flag4 = false;
        if (this.marrCurrentObjects != null && value != null && this.marrCurrentObjects.Length == value.Length)
        {
          flag2 = true;
          flag3 = true;
          for (int intIndex = 0; intIndex < value.Length && flag2 | flag3; ++intIndex)
          {
            if (flag2 && this.marrCurrentObjects[intIndex] != value[intIndex])
              flag2 = false;
            Type type1 = this.GetUnwrappedObject(intIndex).GetType();
            object propertyOwner = value[intIndex];
            if (propertyOwner is ICustomTypeDescriptor)
              propertyOwner = ((ICustomTypeDescriptor) propertyOwner).GetPropertyOwner((PropertyDescriptor) null);
            Type type2 = propertyOwner.GetType();
            if (flag3 && (type1 != type2 || type1.IsCOMObject && type2.IsCOMObject))
              flag3 = false;
          }
        }
        if (!flag2)
        {
          flag1 = true;
          bool flag5 = flag4 && this.GetState((ushort) 2);
          this.SetStatusBox("", "");
          this.ClearCachedProps();
          this.marrCurrentObjects = value != null ? (object[]) value.Clone() : new object[0];
          this.SetState((ushort) 1, true);
          if (this.mobjPropertyGridView != null)
            this.mobjPropertyGridView.RemoveSelectedEntryHelpAttributes();
          if (this.mobjMainGridEntry != null)
            this.mobjMainGridEntry.Dispose();
          if (!flag3 && !this.GetState((ushort) 8) && this.mintSelectedViewTab < this.marrViewTabButtons.Length)
          {
            Type type = this.mintSelectedViewTab == -1 ? (Type) null : this.marrViewTabs[this.mintSelectedViewTab].GetType();
            ToolStripButton objToolBarButton = (ToolStripButton) null;
            this.RefreshTabs(PropertyTabScope.Component);
            this.EnableTabs();
            if (type != (Type) null)
            {
              for (int index = 0; index < this.marrViewTabs.Length; ++index)
              {
                if (this.marrViewTabs[index].GetType() == type && this.marrViewTabButtons[index].Visible)
                {
                  objToolBarButton = this.marrViewTabButtons[index];
                  break;
                }
              }
            }
            this.SelectViewTabButtonDefault(objToolBarButton);
          }
          if (flag5 && this.marrViewTabs != null && this.marrViewTabs.Length > 1 && this.marrViewTabs[1] is EventsTab)
          {
            flag5 = this.marrViewTabButtons[1].Visible;
            Attribute[] arrAttributes = new Attribute[this.BrowsableAttributes.Count];
            this.BrowsableAttributes.CopyTo((Array) arrAttributes, 0);
            Hashtable hashtable = (Hashtable) null;
            if (this.marrCurrentObjects.Length > 10)
              hashtable = new Hashtable();
            for (int index = 0; index < this.marrCurrentObjects.Length & flag5; ++index)
            {
              object objComponent = this.marrCurrentObjects[index];
              if (objComponent is ICustomTypeDescriptor)
                objComponent = ((ICustomTypeDescriptor) objComponent).GetPropertyOwner((PropertyDescriptor) null);
              Type type = objComponent.GetType();
              if (hashtable == null || !hashtable.Contains((object) type))
              {
                bool flag6 = flag5 && objComponent is IComponent && ((IComponent) objComponent).Site != null;
                PropertyDescriptorCollection properties = this.marrViewTabs[1].GetProperties(objComponent, arrAttributes);
                flag5 = flag6 && properties != null && properties.Count > 0;
                if (flag5 && hashtable != null)
                  hashtable[(object) type] = (object) type;
              }
            }
          }
          this.ShowEventsButton(flag5 && this.marrCurrentObjects.Length != 0);
          this.DisplayHotCommands();
          if (this.marrCurrentObjects.Length == 1)
            this.EnablePropPageButton(this.marrCurrentObjects[0]);
          else
            this.EnablePropPageButton((object) null);
          this.OnSelectedObjectsChanged(EventArgs.Empty);
        }
        if (!this.GetState((ushort) 8))
        {
          if (this.marrCurrentObjects.Length != 0 && this.GetState((ushort) 32))
          {
            this.Refresh(false);
            this.SetState((ushort) 32, false);
          }
          else
            this.Refresh(true);
          if (this.marrCurrentObjects.Length != 0)
            this.SaveTabSelection();
        }
        if (!flag1)
          return;
        this.FireObservableItemPropertyChanged(nameof (SelectedObjects));
      }
    }

    /// <summary>Fires the click.</summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    internal void FireClick(EventArgs objEventArgs) => this.OnClick(objEventArgs);

    /// <summary>Gets the entries critical events.</summary>
    /// <returns></returns>
    internal CriticalEventsData GetEntriesCriticalEventsData()
    {
      CriticalEventsData criticalEventsData1 = new CriticalEventsData();
      CriticalEventsData criticalEventsData2 = this.GetCriticalEventsData();
      if (criticalEventsData2.HasEvent("CL"))
        criticalEventsData1.Set("CL");
      if (criticalEventsData2.HasEvent("KD"))
        criticalEventsData2.Set("KD");
      return criticalEventsData1;
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
      if (this.mintSelectedViewTab >= 0 && this.mintSelectedViewTab >= this.marrViewTabButtons.Length)
        this.mintSelectedViewTab = -1;
      if (this.mintSelectedViewTab >= 0 && this.mintSelectedViewTab < this.marrViewTabButtons.Length && objToolBarButton == this.marrViewTabButtons[this.mintSelectedViewTab])
      {
        this.marrViewTabButtons[this.mintSelectedViewTab].Checked = true;
        return true;
      }
      PropertyTab objOldTab = (PropertyTab) null;
      if (this.mintSelectedViewTab != -1)
      {
        this.marrViewTabButtons[this.mintSelectedViewTab].Checked = false;
        objOldTab = this.marrViewTabs[this.mintSelectedViewTab];
      }
      for (int index = 0; index < this.marrViewTabButtons.Length; ++index)
      {
        if (this.marrViewTabButtons[index] == objToolBarButton)
        {
          this.mintSelectedViewTab = index;
          this.marrViewTabButtons[index].Checked = true;
          try
          {
            this.SetState((ushort) 8, true);
            this.OnPropertyTabChanged(new PropertyTabChangedEventArgs(objOldTab, this.marrViewTabs[index]));
          }
          finally
          {
            this.SetState((ushort) 8, false);
          }
          return true;
        }
      }
      this.mintSelectedViewTab = 0;
      this.SelectViewTabButton(this.marrViewTabButtons[0], false);
      return false;
    }

    /// <summary>Gets the currently selected property tab.</summary>
    /// <value>The selected tab.</value>
    /// <returns>The <see cref="T:Design.PropertyTab"></see> that is providing the selected view.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public PropertyTab SelectedTab => this.marrViewTabs[this.mintSelectedViewTab];

    /// <summary>Gets the reset button.</summary>
    /// <value>The reset button.</value>
    internal ToolStripButton ResetButton => this.mobjResetButton;

    /// <summary>Gets a value indicating whether [show focus cues].</summary>
    /// <value><c>true</c> if [show focus cues]; otherwise, <c>false</c>.</value>
    protected internal bool ShowFocusCues => true;

    /// <summary>
    /// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:System.ComponentModel.Component"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:System.ComponentModel.Component"></see>, if any. null if the <see cref="T:System.ComponentModel.Component"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:System.ComponentModel.Component"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:System.ComponentModel.Component"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
    public override ISite Site
    {
      get => base.Site;
      set
      {
        base.Site = value;
        this.mobjPropertyGridView.ServiceProvider = (IServiceProvider) value;
        if (value == null)
          this.ActiveDesigner = (IDesignerHost) null;
        else
          this.ActiveDesigner = (IDesignerHost) value.GetService(typeof (IDesignerHost));
      }
    }

    internal bool SupportsUseCompatibleTextRendering => true;

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets a value indicating whether the ToolStrip is visible.</summary>
    /// <returns>true if the ToolStrip is visible; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("PropertyGridToolbarVisibleDesc")]
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public virtual bool ToolbarVisible
    {
      get => this.mblnToolbarVisible;
      set
      {
        this.mblnToolbarVisible = value;
        this.mobjToolStrip.Visible = value;
        if (value)
          this.SetupToolbar(this.mblnViewTabsDirty);
        this.Invalidate();
        this.mobjToolStrip.Invalidate();
      }
    }

    /// <summary>Gets the tool strip.</summary>
    public ToolStrip Toolbar => (ToolStrip) this.mobjToolStrip;

    /// <summary>Gets or sets a value indicating the background color in the grid.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for windows.</returns>
    /// <filterpriority>2</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("PropertyGridViewBackColorDesc")]
    [DefaultValue(typeof (Color), "Window")]
    public Color ViewBackColor
    {
      get => this.mobjPropertyGridView.BackColor;
      set
      {
        this.mobjPropertyGridView.BackColor = value;
        this.mobjPropertyGridView.Invalidate();
      }
    }

    /// <summary>Gets or sets a value indicating the color of the text in the grid.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values. The default is current system color for text in windows.</returns>
    /// <filterpriority>2</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(typeof (Color), "WindowText")]
    [SRDescription("PropertyGridViewForeColorDesc")]
    public Color ViewForeColor
    {
      get => this.mobjPropertyGridView.ForeColor;
      set
      {
        this.mobjPropertyGridView.ForeColor = value;
        this.mobjPropertyGridView.Invalidate();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>
    /// Gets a value indicating whether raise click event on mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldRaiseClickOnRightMouseDown => false;

    private interface IUnimplemented
    {
    }

    [Serializable]
    private class PropertyGridServiceProvider : IServiceProvider
    {
      private PropertyGrid mobjOwner;

      public PropertyGridServiceProvider(PropertyGrid objOwner) => this.mobjOwner = objOwner;

      public object GetService(Type objServiceType)
      {
        object service = (object) null;
        if (this.mobjOwner.ActiveDesigner != null)
          service = this.mobjOwner.ActiveDesigner.GetService(objServiceType);
        if (service == null)
          service = this.mobjOwner.mobjPropertyGridView.GetService(objServiceType);
        if (service == null && this.mobjOwner.Site != null)
          service = this.mobjOwner.Site.GetService(objServiceType);
        return service;
      }
    }

    /// <summary>Contains a collection of <see cref="T:Design.PropertyTab"></see> objects.</summary>
    [Serializable]
    public class PropertyTabCollection : ICollection, IEnumerable
    {
      /// <summary>
      /// 
      /// </summary>
      internal static PropertyGrid.PropertyTabCollection Empty = new PropertyGrid.PropertyTabCollection((PropertyGrid) null);
      /// <summary>
      /// 
      /// </summary>
      private PropertyGrid mobjOwner;

      internal PropertyTabCollection(PropertyGrid objOwner) => this.mobjOwner = objOwner;

      /// <summary>Adds a Property tab of the specified type to the collection.</summary>
      /// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
      public void AddTabType(Type objPropertyTabType)
      {
        if (this.mobjOwner == null)
          throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
        this.mobjOwner.AddTab(objPropertyTabType, PropertyTabScope.Global);
      }

      /// <summary>Adds a Property tab of the specified type and with the specified scope to the collection.</summary>
      /// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
      /// <param name="objPropertyTabScope">One of the <see cref="T:System.ComponentModel.PropertyTabScope"></see> values. </param>
      public void AddTabType(Type objPropertyTabType, PropertyTabScope objPropertyTabScope)
      {
        if (this.mobjOwner == null)
          throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
        this.mobjOwner.AddTab(objPropertyTabType, objPropertyTabScope);
      }

      /// <summary>Removes all the Property tabs of the specified scope from the collection.</summary>
      /// <param name="objPropertyTabScope">The scope of the tabs to clear. </param>
      /// <exception cref="T:System.ArgumentException">The assigned value of the objPropertyTabScope parameter is less than the Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
      public void Clear(PropertyTabScope objPropertyTabScope)
      {
        if (this.mobjOwner == null)
          throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
        this.mobjOwner.ClearTabs(objPropertyTabScope);
      }

      /// <summary>Returns an enumeration of all the Property tabs in the collection.</summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:PropertyGrid.PropertyTabCollection"></see>.</returns>
      public IEnumerator GetEnumerator() => this.mobjOwner == null ? new PropertyTab[0].GetEnumerator() : this.mobjOwner.marrViewTabs.GetEnumerator();

      /// <summary>Removes the specified tab type from the collection.</summary>
      /// <param name="objPropertyTabType">The tab type to remove from the collection. </param>
      public void RemoveTabType(Type objPropertyTabType)
      {
        if (this.mobjOwner == null)
          throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
        this.mobjOwner.RemoveTab(objPropertyTabType);
      }

      void ICollection.CopyTo(Array objDestinationArray, int index)
      {
        if (this.mobjOwner == null || this.mobjOwner.marrViewTabs.Length == 0)
          return;
        Array.Copy((Array) this.mobjOwner.marrViewTabs, 0, objDestinationArray, index, this.mobjOwner.marrViewTabs.Length);
      }

      /// <summary>Gets the number of Property tabs in the collection.</summary>
      /// <returns>The number of Property tabs in the collection.</returns>
      public int Count => this.mobjOwner == null ? 0 : this.mobjOwner.marrViewTabs.Length;

      /// <summary>Gets the <see cref="T:Design.PropertyTab"></see> at the specified index.</summary>
      /// <returns>The <see cref="T:Design.PropertyTab"></see> at the specified index.</returns>
      /// <param name="index">The index of the <see cref="T:Design.PropertyTab"></see> to return. </param>
      public PropertyTab this[int index]
      {
        get
        {
          if (this.mobjOwner == null)
            throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
          return this.mobjOwner.marrViewTabs[index];
        }
      }

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => (object) this;
    }

    internal class SelectedObjectConverter : ReferenceConverter
    {
      public SelectedObjectConverter()
        : base(typeof (IComponent))
      {
      }
    }
  }
}
