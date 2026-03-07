// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualTabGroup
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
  [DesignTimeVisible(false)]
  [ToolboxItem(false)]
  [Serializable]
  public class ContextualTabGroup : SerializableObject, IComponent, IDisposable
  {
    private TabControl mobjTabControl;
    /// <summary>Provides a property reference to Text property.</summary>
    private static SerializableProperty TextProperty = SerializableProperty.Register(nameof (TextProperty), typeof (string), typeof (ContextualTabGroup), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The disposed event</summary>
    private static readonly SerializableEvent DisposedEvent = SerializableEvent.Register(nameof (DisposedEvent), typeof (EventHandler), typeof (ContextualTabGroup));
    [NonSerialized]
    private ISite mobjSite;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup" /> class.
    /// </summary>
    public ContextualTabGroup()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup" /> class.
    /// </summary>
    /// <param name="strKey">The contextual tab group Key.</param>
    /// <param name="strText">The contextual tab group Text.</param>
    public ContextualTabGroup(string strText) => this.Text = strText;

    /// <summary>Gets or sets the contextual tab group key.</summary>
    /// <value>The contextual tab group text.</value>
    [DefaultValue("")]
    public string Text
    {
      get => this.GetValue<string>(ContextualTabGroup.TextProperty);
      set
      {
        if (!this.SetValue<string>(ContextualTabGroup.TextProperty, value) || this.mobjTabControl == null)
          return;
        this.mobjTabControl.Update();
      }
    }

    /// <summary>Gets or sets the tab control internal.</summary>
    /// <value>The tab control internal.</value>
    internal TabControl TabControlInternal
    {
      get => this.mobjTabControl;
      set => this.mobjTabControl = value;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      string str = this.Text;
      if (!string.IsNullOrEmpty(str))
        str = " [" + str + "]";
      ISite mobjSite = this.mobjSite;
      return mobjSite != null ? mobjSite.Name + str : this.GetType().FullName + str;
    }

    /// <summary>Adds an event handler to listen to the <see cref="E:System.ComponentModel.Component.Disposed"></see> event on the component.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler Disposed
    {
      add => this.AddHandler(ContextualTabGroup.DisposedEvent, (Delegate) value);
      remove => this.RemoveHandler(ContextualTabGroup.DisposedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.ComponentModel.ISite" /> associated with the <see cref="T:System.ComponentModel.IComponent" />.
    /// </summary>
    /// <returns>The <see cref="T:System.ComponentModel.ISite" /> object associated with the component; or null, if the component does not have a site.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ISite Site
    {
      get => this.mobjSite;
      set => this.mobjSite = value;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() => this.Dispose(true);

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      lock (this)
      {
        if (this.mobjSite != null && this.mobjSite.Container != null)
          this.mobjSite.Container.Remove((IComponent) this);
        EventHandler handler = (EventHandler) this.GetHandler(ContextualTabGroup.DisposedEvent);
        if (handler == null)
          return;
        handler((object) this, EventArgs.Empty);
      }
    }
  }
}
