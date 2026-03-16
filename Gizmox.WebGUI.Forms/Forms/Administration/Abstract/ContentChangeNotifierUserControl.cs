// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.Abstract.ContentChangeNotifierUserControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.Administration.Abstract
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class ContentChangeNotifierUserControl : UserControl
  {
    /// <summary>The content changed event</summary>
    private static readonly SerializableEvent ContentChangedEvent = SerializableEvent.Register(nameof (ContentChangedEvent), typeof (EventHandler), typeof (ContentChangeNotifierUserControl));

    /// <summary>Gets the name of the current content.</summary>
    /// <returns></returns>
    public abstract string GetCurrentContentName();

    /// <summary>Gets the status.</summary>
    /// <returns></returns>
    public abstract List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus();

    /// <summary>Occurs when [content changed].</summary>
    internal event EventHandler ContentChanged
    {
      add => this.AddHandler(ContentChangeNotifierUserControl.ContentChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ContentChangeNotifierUserControl.ContentChangedEvent, (Delegate) value);
    }

    /// <summary>Called when [content changed].</summary>
    /// <param name="strContentName">Name of the string content.</param>
    protected void OnContentChanged()
    {
      if (!(this.GetHandler(ContentChangeNotifierUserControl.ContentChangedEvent) is EventHandler handler))
        return;
      handler((object) this, EventArgs.Empty);
    }
  }
}
