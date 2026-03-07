// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NavigationCommandTarget
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public enum NavigationCommandTarget
  {
    /// <summary>
    /// will try to execute the Navigation Command on the selected Navigation Control (if navigation is available) otherwise the Navigation Command is executed on the forms list.
    /// </summary>
    FullNavigation,
    /// <summary>
    /// will execute the Navigation Command on the available forms list.
    /// </summary>
    Form,
    /// <summary>
    /// will execute the Navigation Command on the selected Navigation Control.
    /// </summary>
    NavigationControl,
  }
}
