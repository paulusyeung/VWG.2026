// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HierarchicInfo
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class HierarchicInfo : SerializableObject, INotifyPropertyChanged, IComponent, IDisposable
  {
    internal static readonly SerializableEvent HierarchyInfoChangedEvent = SerializableEvent.Register("Event", typeof (Delegate), typeof (HierarchicInfo));
    private BindingSource mobjBindedSource;
    private ObservableCollection<FilterRelation> mobjFilteringDataMembers;
    private List<string> mobjKeys;
    private ISite mobjSite;
    private SuspendableObservableCollection<string> mobjHiddenColumns;
    private string mstrHierarchyName;

    /// <summary>Gets the cloned infos.</summary>
    /// <param name="objHierarchicInfos">The obj hierarchic infos.</param>
    /// <param name="blnIncludeRoot">if set to <c>true</c> [includes root info].</param>
    /// <returns></returns>
    internal static ObservableCollection<HierarchicInfo> GetClonedInfos(
      ObservableCollection<HierarchicInfo> objHierarchicInfos,
      bool blnIncludeRoot)
    {
      ObservableCollection<HierarchicInfo> clonedInfos = new ObservableCollection<HierarchicInfo>();
      for (int index = blnIncludeRoot ? 0 : 1; index < objHierarchicInfos.Count; ++index)
        clonedInfos.Add(objHierarchicInfos[index]);
      return clonedInfos;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo" /> class.
    /// </summary>
    public HierarchicInfo() => this.mobjKeys = new List<string>();

    /// <summary>Occurs when a property value changes.</summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
      add => this.AddHandler(HierarchicInfo.HierarchyInfoChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(HierarchicInfo.HierarchyInfoChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hidden columns indicator.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SuspendableObservableCollection<string> HiddenColumns
    {
      get
      {
        if (this.mobjHiddenColumns == null)
          this.mobjHiddenColumns = new SuspendableObservableCollection<string>();
        return this.mobjHiddenColumns;
      }
    }

    /// <summary>Gets or sets the name of the hierarchy.</summary>
    /// <value>The name of the hierarchy.</value>
    public string HierarchyName
    {
      get => this.mstrHierarchyName;
      set => this.mstrHierarchyName = value;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.IsNullOrEmpty(this.mstrHierarchyName) ? this.BindedSource.CurrencyManager.GetListName() : this.mstrHierarchyName;

    /// <summary>Gets or sets the filtering data members.</summary>
    /// <value>The filtering data members.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ObservableCollection<FilterRelation> FilteringDataMembers
    {
      get
      {
        if (this.mobjFilteringDataMembers == null)
          this.FilteringDataMembers = new ObservableCollection<FilterRelation>();
        return this.mobjFilteringDataMembers;
      }
      set
      {
        if (this.mobjFilteringDataMembers == value)
          return;
        this.AttachDetachEventsFromFilteringMembers(this.mobjFilteringDataMembers, false);
        this.mobjFilteringDataMembers = value;
        this.AttachDetachEventsFromFilteringMembers(this.mobjFilteringDataMembers, true);
        this.GenerateKeys();
        this.OnPropertyChanged(nameof (FilteringDataMembers));
      }
    }

    /// <summary>Attaches the detach events from filtering members.</summary>
    /// <param name="objFilteringDataMembers">The obj filtering data members.</param>
    /// <param name="blnAttach">if set to <c>true</c> [BLN attach].</param>
    private void AttachDetachEventsFromFilteringMembers(
      ObservableCollection<FilterRelation> objFilteringDataMembers,
      bool blnAttach)
    {
      if (objFilteringDataMembers == null || this.DesignMode)
        return;
      if (blnAttach)
      {
        objFilteringDataMembers.CollectionChanged += new NotifyCollectionChangedEventHandler(this.mobjFilteringDataMembers_CollectionChanged);
        foreach (FilterRelation filteringDataMember in (Collection<FilterRelation>) objFilteringDataMembers)
          filteringDataMember.PropertyChanged += new PropertyChangedEventHandler(this.objFilterRelation_PropertyChanged);
      }
      else
      {
        objFilteringDataMembers.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.mobjFilteringDataMembers_CollectionChanged);
        foreach (FilterRelation filteringDataMember in (Collection<FilterRelation>) objFilteringDataMembers)
          filteringDataMember.PropertyChanged -= new PropertyChangedEventHandler(this.objFilterRelation_PropertyChanged);
      }
    }

    /// <summary>Generates the keys.</summary>
    private void GenerateKeys()
    {
      this.Keys.Clear();
      foreach (FilterRelation filteringDataMember in (Collection<FilterRelation>) this.mobjFilteringDataMembers)
        this.Keys.Add(filteringDataMember.SourceColumnDataName);
    }

    /// <summary>Gets or sets the keys.</summary>
    /// <value>The keys.</value>
    internal List<string> Keys => this.mobjKeys;

    /// <summary>
    /// Handles the CollectionChanged event of the mobjFilteringDataMembers control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void mobjFilteringDataMembers_CollectionChanged(
      object sender,
      NotifyCollectionChangedEventArgs e)
    {
      if (this.DesignMode)
        return;
      if (e.NewItems != null)
      {
        foreach (FilterRelation newItem in (IEnumerable) e.NewItems)
          newItem.PropertyChanged += new PropertyChangedEventHandler(this.objFilterRelation_PropertyChanged);
      }
      if (e.OldItems != null)
      {
        foreach (FilterRelation oldItem in (IEnumerable) e.OldItems)
          oldItem.PropertyChanged -= new PropertyChangedEventHandler(this.objFilterRelation_PropertyChanged);
      }
      this.GenerateKeys();
      this.OnPropertyChanged("FilteringDataMembersChanged");
    }

    /// <summary>
    /// Handles the PropertyChanged event of the objFilterRelation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
    private void objFilterRelation_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.GenerateKeys();
      this.OnPropertyChanged(e.PropertyName);
    }

    /// <summary>Gets or sets the binded source.</summary>
    /// <value>The binded source.</value>
    public BindingSource BindedSource
    {
      get => this.mobjBindedSource;
      set
      {
        if (this.mobjBindedSource == value)
          return;
        this.mobjBindedSource = value;
        this.OnPropertyChanged(nameof (BindedSource));
      }
    }

    /// <summary>Called when [property changed].</summary>
    /// <param name="strName">The name.</param>
    protected void OnPropertyChanged(string strName)
    {
      if (!(this.GetHandler(HierarchicInfo.HierarchyInfoChangedEvent) is PropertyChangedEventHandler handler))
        return;
      handler((object) this, new PropertyChangedEventArgs(strName));
    }

    public event EventHandler Disposed;

    /// <summary>Gets a value that indicates whether the <see cref="T:System.ComponentModel.Component"></see> is currently in design mode.</summary>
    /// <returns>true if the <see cref="T:System.ComponentModel.Component"></see> is in design mode; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected bool DesignMode
    {
      get
      {
        ISite mobjSite = this.mobjSite;
        return mobjSite != null && mobjSite.DesignMode;
      }
    }

    /// <summary>Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ISite Site
    {
      get => this.mobjSite;
      set => this.mobjSite = value;
    }

    /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
    public void Dispose() => this.Dispose(true);

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> and optionally releases the managed resources.</summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      lock (this)
      {
        if (this.mobjSite != null && this.mobjSite.Container != null)
          this.mobjSite.Container.Remove((IComponent) this);
        EventHandler disposed = this.Disposed;
        if (disposed == null)
          return;
        disposed((object) this, EventArgs.Empty);
      }
    }
  }
}
