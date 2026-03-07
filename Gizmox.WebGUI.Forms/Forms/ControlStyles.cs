// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlStyles
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// <summary>Specifies the style and behavior of a control.</summary>
  /// </summary>
  [Flags]
  public enum ControlStyles
  {
    /// <summary>If true, the control ignores the window message WM_ERASEBKGND to reduce flicker. This style should only be applied if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true.</summary>
    AllPaintingInWmPaint = 8192, // 0x00002000
    /// <summary>If true, the control keeps a copy of the text rather than getting it from the <see cref="P:System.Windows.Forms.Control.Handle"></see> each time it is needed. This style defaults to false. This behavior improves performance, but makes it difficult to keep the text synchronized.</summary>
    CacheText = 16384, // 0x00004000
    /// <summary>If true, the control is a container-like control.</summary>
    ContainerControl = 1,
    /// <summary>If true, drawing is performed in a buffer, and after it completes, the result is output to the screen. Double-buffering prevents flicker caused by the redrawing of the control. If you set <see cref="F:System.Windows.Forms.ControlStyles.DoubleBuffer"></see> to true, you should alsoset <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> and <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)] DoubleBuffer = 65536, // 0x00010000
    /// <summary>If true, the <see cref="M:System.Windows.Forms.Control.OnNotifyMessage(System.Windows.Forms.Message)"></see> method is called for every message sent to the control's <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)"></see>. This style defaults to false. <see cref="F:System.Windows.Forms.ControlStyles.EnableNotifyMessage"></see> does not work in partial trust.</summary>
    EnableNotifyMessage = 32768, // 0x00008000
    /// <summary>If true, the control has a fixed height when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Height"></see> remains unchanged.</summary>
    /// <filterpriority>1</filterpriority>
    FixedHeight = 64, // 0x00000040
    /// <summary>If true, the control has a fixed width when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Width"></see> remains unchanged.</summary>
    FixedWidth = 32, // 0x00000020
    /// <summary>If true, the control is drawn opaque and the background is not painted.</summary>
    Opaque = 4,
    /// <summary>If true, the control is first drawn to a buffer rather than directly to the screen, which can reduce flicker. If you set this property to true, you should also set the <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
    /// <filterpriority>1</filterpriority>
    OptimizedDoubleBuffer = 131072, // 0x00020000
    /// <summary>If true, the control is redrawn when it is resized.</summary>
    ResizeRedraw = 16, // 0x00000010
    /// <summary>If true, the control can receive focus.</summary>
    Selectable = 512, // 0x00000200
    /// <summary>If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.Click"></see> behavior.</summary>
    StandardClick = 256, // 0x00000100
    /// <summary>If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> behavior. This style is ignored if the <see cref="F:System.Windows.Forms.ControlStyles.StandardClick"></see> bit is not set to true.</summary>
    StandardDoubleClick = 4096, // 0x00001000
    /// <summary>If true, the control accepts a <see cref="P:System.Windows.Forms.Control.BackColor"></see> with an alpha component of less than 255 to simulate transparency. Transparency will be simulated only if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true and the parent control is derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
    SupportsTransparentBackColor = 2048, // 0x00000800
    /// <summary>If true, the control does its own mouse processing, and mouse events are not handled by the operating system.</summary>
    UserMouse = 1024, // 0x00000400
    /// <summary>If true, the control paints itself rather than the operating system doing so. If false, the <see cref="E:System.Windows.Forms.Control.Paint"></see> event is not raised. This style only applies to classes derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
    UserPaint = 2,
    /// <summary>Specifies that the value of the control's Text property, if set, determines the control's default Active Accessibility name and shortcut key.</summary>
    UseTextForAccessibility = 262144, // 0x00040000
  }
}
