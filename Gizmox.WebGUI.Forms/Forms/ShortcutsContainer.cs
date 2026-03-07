// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ShortcutsContainer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Contains a collection of mapped shortcuts</summary>
  /// <remarks>
  /// The chortcut container is used internaly by the VWG form to
  /// hold all shortcuts and their component mappings.
  /// </remarks>
  [ToolboxItem(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class ShortcutsContainer : Component, IEnumerable
  {
    private Hashtable mobjShortcuts;
    private Hashtable mobjComponents;

    internal ShortcutsContainer()
    {
    }

    internal void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      if (!this.IsDirty(lngRequestID))
        return;
      this.RegisterSelf();
      objWriter.WriteStartElement(WGConst.Prefix, "SCC", WGConst.Namespace);
      this.RenderComponentAttributes(objContext, (IAttributeWriter) objWriter);
      if (this.mobjShortcuts != null)
      {
        foreach (string key in (IEnumerable) this.mobjShortcuts.Keys)
        {
          if (this.mobjShortcuts[(object) key] is IRegisteredComponent)
          {
            objWriter.WriteStartElement("I");
            objWriter.WriteAttributeString("SC", key);
            objWriter.WriteEndElement();
          }
        }
      }
      objWriter.WriteEndElement();
    }

    private Hashtable Components
    {
      get
      {
        if (this.mobjComponents == null)
          this.mobjComponents = new Hashtable();
        return this.mobjComponents;
      }
    }

    private Hashtable Shortcuts
    {
      get
      {
        if (this.mobjShortcuts == null)
          this.mobjShortcuts = new Hashtable();
        return this.mobjShortcuts;
      }
    }

    /// <summary>Maps a new shortcut</summary>
    /// <param name="strShortcut"></param>
    /// <param name="objComponent"></param>
    public void Add(string strShortcut, IRegisteredComponent objComponent)
    {
      this.Remove(objComponent);
      this.Shortcuts[(object) strShortcut] = (object) objComponent;
      this.Components[(object) objComponent] = (object) strShortcut;
      this.Update();
    }

    /// <summary>Removes an existing shortcut mapping</summary>
    /// <param name="objComponent"></param>
    public void Remove(IRegisteredComponent objComponent)
    {
      if (!this.Components.ContainsKey((object) objComponent))
        return;
      string component = (string) this.Components[(object) objComponent];
      if (this.Shortcuts[(object) component] == objComponent)
        this.Shortcuts.Remove((object) component);
      this.Components.Remove((object) objComponent);
      this.Update();
    }

    /// <summary>Get compenent mapped to shortcut</summary>
    /// <param name="enmShortcut"></param>
    /// <returns></returns>
    public IRegisteredComponent this[string strShortcut] => this.Shortcuts[(object) strShortcut] as IRegisteredComponent;

    /// <summary>Get shortcut mapped to component</summary>
    /// <param name="objComponent"></param>
    /// <returns></returns>
    public string this[IRegisteredComponent objComponent] => this.Components.Contains((object) objComponent) ? (string) this.Components[(object) objComponent] : (string) null;

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Shortcuts.GetEnumerator();
  }
}
