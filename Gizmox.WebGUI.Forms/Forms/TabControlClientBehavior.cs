// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabControlClientBehavior
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Tab control client behavior modes</summary>
  public enum TabControlClientBehavior
  {
    /// <summary>
    /// TabControl draws only on tab at a time. This mode is optimized for large tab page content displaying in DHTML.
    /// When loading lots of controls or data intensive controls in multiple tabs,
    /// this mode avoids browser from having to deal with large amount of dom elements.
    /// </summary>
    MemoryOptimized,
    /// <summary>
    /// TabControl does not redraw its tabs when switching between tabs.
    /// This mode is optimized for resonable tab page content and provides an
    /// advantage for working with browser navigation inside the tab pages.
    /// </summary>
    DrawingOptimized,
    /// <summary>Tabcontrol won't have any optimizations.</summary>
    NoOptimizations,
  }
}
