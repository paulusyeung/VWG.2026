// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationTabs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
  /// <summary>A TabControl control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (AdministrationTabsSkin))]
  [ToolboxItem(false)]
  [Serializable]
  internal class AdministrationTabs : TabControl
  {
    /// <summary>The mobj content updateable</summary>
    private IContentUpdateable mobjContentUpdateable;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationTabs" /> class.
    /// </summary>
    public AdministrationTabs() => this.CustomStyle = "AdministrationTabsSkin";

    /// <summary>Updates the content.</summary>
    internal void UpdateContent()
    {
      if (this.ContentUpdateable == null)
        return;
      this.ContentUpdateable.UpdateContent();
    }

    /// <summary>Gets or sets the content updateable.</summary>
    /// <value>The content updateable.</value>
    public IContentUpdateable ContentUpdateable
    {
      get => this.mobjContentUpdateable;
      set => this.mobjContentUpdateable = value;
    }
  }
}
