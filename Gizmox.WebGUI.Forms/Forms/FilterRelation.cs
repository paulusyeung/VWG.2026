// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FilterRelation
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class FilterRelation : SerializableObject, INotifyPropertyChanged, IComponent, IDisposable
  {
    internal static readonly SerializableEvent MemberChangedEvent = SerializableEvent.Register("Event", typeof (Delegate), typeof (FilterRelation));
    private string mstrSourceDataMember;
    private string mstrTargetDataMember;
    private ISite mobjSite;

    /// <summary>Gets or sets the name of the target column data.</summary>
    /// <value>The name of the target column data.</value>
    public string TargetColumnDataName
    {
      get => this.mstrTargetDataMember;
      set
      {
        this.mstrTargetDataMember = !string.IsNullOrEmpty(value) ? value : throw new Exception("TargetColumnDataName must not be null nor empty");
        this.OnPropertyChanged("TargetDataMember");
      }
    }

    /// <summary>Gets or sets the name of the source column data.</summary>
    /// <value>The name of the source column data.</value>
    public string SourceColumnDataName
    {
      get => this.mstrSourceDataMember;
      set
      {
        this.mstrSourceDataMember = !string.IsNullOrEmpty(value) ? value : throw new Exception("SourceColumnDataName must not be null nor empty");
        this.OnPropertyChanged("SourceDataMember");
      }
    }

    /// <summary>Called when [property changed].</summary>
    /// <param name="strName">The name.</param>
    protected void OnPropertyChanged(string strName)
    {
      if (!(this.GetHandler(FilterRelation.MemberChangedEvent) is PropertyChangedEventHandler handler))
        return;
      handler((object) this, new PropertyChangedEventArgs(strName));
    }

    /// <summary>Occurs when a property value changes.</summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
      add => this.AddHandler(FilterRelation.MemberChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(FilterRelation.MemberChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="E:System.ComponentModel.IComponent.Disposed" /> event of a component.
    /// </summary>
    public event EventHandler Disposed;

    /// <summary>Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ISite Site
    {
      get => this.mobjSite;
      set => this.mobjSite = value;
    }

    /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
    public void Dispose() => this.Dispose(true);

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> and optionally releases the managed resources.</summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      lock (this)
      {
        if (this.mobjSite == null || this.mobjSite.Container == null)
          return;
        this.mobjSite.Container.Remove((IComponent) this);
      }
    }
  }
}
