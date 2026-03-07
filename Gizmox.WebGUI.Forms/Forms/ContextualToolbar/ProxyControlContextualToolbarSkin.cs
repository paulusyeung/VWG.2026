// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualToolbar.ProxyControlContextualToolbarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Drawing;

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
  /// <summary>Summary description for ContextualToolbarSkin</summary>
  public class ProxyControlContextualToolbarSkin : ContextualToolbarSkin
  {
    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the size of the contextual toolbar.</summary>
    /// <value>The size of the contextual toolbar.</value>
    public override Size ContextualToolbarSize
    {
      get => this.GetValue<Size>(nameof (ContextualToolbarSize), new Size(220, 38));
      set => this.SetValue(nameof (ContextualToolbarSize), (object) value);
    }
  }
}
