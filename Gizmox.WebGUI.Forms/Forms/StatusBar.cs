// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.StatusBar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Gizmox.WebGUI.Forms status bar control. Although <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (StatusBar), "StatusBar_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultProperty("Text")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("SB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (StatusBarSkin))]
  [ProxyComponent(typeof (ProxyStatusBar))]
  [Serializable]
  public class StatusBar : Control
  {
    /// <summary>
    /// Provides a property reference to StatusBarPanelCollection property.
    /// </summary>
    private static SerializableProperty StatusBarPanelCollectionProperty = SerializableProperty.Register("StatusBarPanelCollection", typeof (StatusBar.StatusBarPanelCollection), typeof (StatusBar));
    /// <summary>Provides a property reference to ShowPanels property.</summary>
    private static SerializableProperty ShowPanelsProperty = SerializableProperty.Register(nameof (ShowPanels), typeof (bool), typeof (StatusBar));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> class.
    /// </summary>
    public StatusBar()
    {
      this.SetStyle(ControlStyles.Selectable | ControlStyles.UserPaint, false);
      this.Dock = DockStyle.Bottom;
      this.TabStop = false;
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      StatusBar.StatusBarPanelCollection panels = this.Panels;
      if (panels == null)
        return;
      this.RegisterBatch((ICollection) panels);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      StatusBar.StatusBarPanelCollection panels = this.Panels;
      if (panels == null)
        return;
      this.UnRegisterBatch((ICollection) panels);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.Panels.Count != 0 && this.ShowPanels)
        return;
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Gets the status bar critical events.</summary>
    /// <returns></returns>
    internal CriticalEventsData GetStatusBarCriticalEventsData() => this.GetCriticalEventsData();

    /// <summary>Fires the status bar event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void FireStatusBarEvent(IEvent objEvent) => this.FireEvent(objEvent);

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (!this.ShowPanels)
        return;
      foreach (StatusBarPanel panel in this.Panels)
      {
        this.RegisterComponent((IRegisteredComponent) panel);
        panel.RenderPanel(objContext, objWriter, lngRequestID);
      }
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.Panels;

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets the default back color internal.</summary>
    /// <value>The default back color internal.</value>
    internal Color DefaultBackColorInternal => this.DefaultBackColor;

    /// <summary>Gets the default fore color internal.</summary>
    /// <value>The default fore color internal.</value>
    internal Color DefaultForeColorInternal => this.DefaultForeColor;

    /// <summary>
    /// Gets or sets a value indicating whether any panels that have been added to the control are displayed.
    /// </summary>
    /// <returns>true if panels are displayed; otherwise, false. The default is false.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("StatusBarShowPanelsDescr")]
    public bool ShowPanels
    {
      get => this.GetValue<bool>(StatusBar.ShowPanelsProperty, false);
      set
      {
        if (this.ShowPanels == value)
          return;
        if (!value)
          this.RemoveValue<bool>(StatusBar.ShowPanelsProperty);
        else
          this.SetValue<bool>(StatusBar.ShowPanelsProperty, value);
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (ShowPanels));
      }
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    /// <value></value>
    [Localizable(true)]
    [DefaultValue(DockStyle.Bottom)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    /// <summary>
    /// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> panels contained within the control.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> containing the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.</returns>
    [Browsable(true)]
    [SRCategory("CatAppearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("StatusBarPanelsDescr")]
    [Localizable(true)]
    [MergableProperty(false)]
    public StatusBar.StatusBarPanelCollection Panels
    {
      get
      {
        StatusBar.StatusBarPanelCollection panelsCollection = this.GetValue<StatusBar.StatusBarPanelCollection>(StatusBar.StatusBarPanelCollectionProperty, (StatusBar.StatusBarPanelCollection) null);
        if (panelsCollection == null)
        {
          panelsCollection = this.CreatePanelsCollection();
          this.SetValue<StatusBar.StatusBarPanelCollection>(StatusBar.StatusBarPanelCollectionProperty, panelsCollection);
        }
        return panelsCollection;
      }
    }

    /// <summary>Creates the panels Collection.</summary>
    /// <returns></returns>
    [Browsable(false)]
    protected virtual StatusBar.StatusBarPanelCollection CreatePanelsCollection() => new StatusBar.StatusBarPanelCollection(this);

    /// <summary>
    /// Represents the collection of panels in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
    /// </summary>
    [ListBindable(false)]
    [Serializable]
    public class StatusBarPanelCollection : ICollection, IEnumerable, IList, IObservableList
    {
      private ArrayList mobjList;
      private StatusBar mobjStatusBar;

      /// <summary>
      /// Gets a value indicating whether this collection is read-only.
      /// </summary>
      /// <returns>true if this collection is read-only; otherwise, false.</returns>
      public bool IsReadOnly => this.mobjList.IsReadOnly;

      /// <summary>
      /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> at the specified index.
      /// </summary>
      /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel located at the specified index within the collection.</returns>
      /// <param name="index">The index of the panel in the collection to get or set. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
      /// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the collection was null. </exception>
      public StatusBarPanel this[int index]
      {
        get => (StatusBarPanel) this.mobjList[index];
        set => this.mobjList[index] = (object) value;
      }

      /// <summary>
      /// Removes the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> located at the specified index within the collection.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
      public void RemoveAt(int index)
      {
        object objItem = (object) this[index];
        this.mobjList.RemoveAt(index);
        if (this.ObservableItemRemoved == null)
          return;
        this.ObservableItemRemoved((object) this, new ObservableListEventArgs(objItem));
      }

      /// <summary>
      /// Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> into the collection at the specified index.
      /// </summary>
      /// <param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to insert. </param>
      /// <param name="index">The zero-based index location where the panel is inserted. </param>
      /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property of the value parameter's panel is not a valid <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> value. </exception>
      /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
      /// <exception cref="T:System.ArgumentException">The value parameter's parent is not null. </exception>
      public void Insert(int index, StatusBarPanel value)
      {
        this.mobjList.Insert(index, (object) value);
        if (this.ObservableItemInserted == null)
          return;
        this.ObservableItemInserted((object) this, new ObservableListEventArgs((object) value));
      }

      /// <summary>
      /// Removes the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> from the collection.
      /// </summary>
      /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to remove from the collection. </param>
      /// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the value parameter is null. </exception>
      public void Remove(StatusBarPanel value)
      {
        this.mobjList.Remove((object) value);
        if (this.ObservableItemRemoved == null)
          return;
        this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) value));
      }

      /// <summary>
      /// Determines whether the specified panel is located within the collection.
      /// </summary>
      /// <returns>true if the panel is located within the collection; otherwise, false.</returns>
      /// <param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
      public bool Contains(StatusBarPanel objPanel) => this.mobjList.Contains((object) objPanel);

      /// <summary>Removes all items from the collection.</summary>
      public void Clear()
      {
        this.mobjList.Clear();
        if (this.ObservableListCleared == null)
          return;
        this.ObservableListCleared((object) this, EventArgs.Empty);
      }

      /// <summary>
      /// Returns the index within the collection of the specified panel.
      /// </summary>
      /// <returns>The zero-based index where the panel is located within the collection; otherwise, negative one (-1).</returns>
      /// <param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
      public int IndexOf(StatusBarPanel objPanel) => this.mobjList.IndexOf((object) objPanel);

      /// <summary>
      /// Adds a <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to the collection.
      /// </summary>
      /// <returns>The zero-based index of the item in the collection.</returns>
      /// <param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> that represents the panel to add to the collection. </param>
      /// <exception cref="T:System.ArgumentException">The parent of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> specified in the value parameter is not null. </exception>
      /// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> being added to the collection was null. </exception>
      public int Add(StatusBarPanel value)
      {
        value.InternalParent = (Component) this.mobjStatusBar;
        int num = this.mobjList.Add((object) value);
        if (this.ObservableItemAdded == null)
          return num;
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) value));
        return num;
      }

      /// <summary>
      /// Adds an array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to the collection.
      /// </summary>
      /// <param name="arrPnels">An array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to add. </param>
      /// <exception cref="T:System.ArgumentNullException">The array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects being added to the collection was null. </exception>
      public void AddRange(StatusBarPanel[] arrPnels)
      {
        foreach (StatusBarPanel arrPnel in arrPnels)
          this.Add(arrPnel);
      }

      /// <summary>
      /// Gets a value indicating whether the collection has a fixed size.
      /// </summary>
      /// <returns>false in all cases.</returns>
      public bool IsFixedSize => this.mobjList.IsFixedSize;

      /// <summary>
      /// Gets a value indicating whether access to the collection is synchronized (thread safe).
      /// </summary>
      /// <returns>false in all cases.</returns>
      public bool IsSynchronized => this.mobjList.IsSynchronized;

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects in the collection.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Browsable(false)]
      public int Count => this.mobjList.Count;

      /// <summary>
      /// Copies the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> to a compatible one-dimensional array, starting at the specified index of the target array.
      /// </summary>
      /// <param name="objDestinationArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.  </param>
      /// <param name="index">The zero-based index in the array at which copying begins.</param>
      /// <exception cref="T:System.InvalidCastException">The type in the collection cannot be cast automatically to the type of array.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
      /// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> is greater than the available space from index to the end of array.</exception>
      /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
      public void CopyTo(Array objDestinationArray, int index) => this.mobjList.CopyTo(objDestinationArray, index);

      /// <summary>
      /// Gets an object that can be used to synchronize access to the collection.
      /// </summary>
      /// <returns>The object used to synchronize access to the collection.</returns>
      public object SyncRoot => this.mobjList.SyncRoot;

      /// <summary>
      /// Returns an enumerator to use to iterate through the item collection.
      /// </summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
      public IEnumerator GetEnumerator() => this.mobjList.GetEnumerator();

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class.
      /// </summary>
      /// <param name="objStatusBar">The <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control that contains this collection. </param>
      public StatusBarPanelCollection(StatusBar objStatusBar)
      {
        this.mobjStatusBar = objStatusBar;
        this.mobjList = new ArrayList();
      }

      int IList.Add(object objValue)
      {
        ((Component) objValue).InternalParent = (Component) this.mobjStatusBar;
        return this.Add((StatusBarPanel) objValue);
      }

      void IList.Clear() => this.Clear();

      bool IList.Contains(object objValue) => this.Contains((StatusBarPanel) objValue);

      int IList.IndexOf(object objValue) => this.IndexOf((StatusBarPanel) objValue);

      void IList.Insert(int index, object objValue) => this[index] = (StatusBarPanel) objValue;

      bool IList.IsFixedSize => false;

      bool IList.IsReadOnly => false;

      void IList.Remove(object objValue) => this.Remove((StatusBarPanel) objValue);

      void IList.RemoveAt(int index) => this.Remove(this[index]);

      object IList.this[int index]
      {
        get => (object) this[index];
        set => this[index] = (StatusBarPanel) value;
      }

      void ICollection.CopyTo(Array objArray, int index) => this.mobjList.CopyTo(objArray, index);

      int ICollection.Count => this.mobjList.Count;

      bool ICollection.IsSynchronized => this.mobjList.IsSynchronized;

      object ICollection.SyncRoot => this.mobjList.SyncRoot;

      IEnumerator IEnumerable.GetEnumerator() => this.mobjList.GetEnumerator();

      /// <summary>Occurs when [observable item inserted].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemInserted;

      /// <summary>Occurs when [observable item added].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemAdded;

      /// <summary>Occurs when [observable list cleared].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event EventHandler ObservableListCleared;

      /// <summary>Occurs when [observable item removed].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemRemoved;
    }
  }
}
