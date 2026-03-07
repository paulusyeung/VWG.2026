// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualToolbar.ProxyControlContextualToolbar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
  /// <summary>Summary description for ContextualToolbar</summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ProxyControlContextualToolbarSkin))]
  [Serializable]
  internal class ProxyControlContextualToolbar : Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar
  {
    /// <summary>Initializes the base buttons buttons.</summary>
    protected override void InitContextualToolbarButtons()
    {
      base.InitContextualToolbarButtons();
      if (!(this.Skin is ProxyControlContextualToolbarSkin skin))
        return;
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("Actions", skin.ContextualToolbarActions, "Add/Remove actions."));
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("VisualTemplate", skin.ContextualToolbarVisualTemplates, "Add/Remove visual templates."));
    }
  }
}
