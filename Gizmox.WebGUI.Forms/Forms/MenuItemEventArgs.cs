// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MenuItemEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Menu item event arguments</summary>
  [Serializable]
  public class MenuItemEventArgs : EventArgs
  {
    /// <summary>Menu Item</summary>
    public readonly MenuItem MenuItem;
    /// <summary>
    /// 
    /// </summary>
    public readonly Component Source;
    /// <summary>
    /// 
    /// </summary>
    public readonly IIdentifiedComponent Member;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> instance.
    /// </summary>
    /// <param name="objMenuItem">menu item.</param>
    /// <param name="objSource">The obj source.</param>
    public MenuItemEventArgs(MenuItem objMenuItem, Component objSource)
    {
      this.MenuItem = objMenuItem;
      this.Source = objSource;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> class.
    /// </summary>
    /// <param name="objMenuItem">The obj menu item.</param>
    /// <param name="objSource">The obj source.</param>
    /// <param name="objMember">The obj member.</param>
    public MenuItemEventArgs(
      MenuItem objMenuItem,
      Component objSource,
      IIdentifiedComponent objMember)
      : this(objMenuItem, objSource)
    {
      this.Member = objMember;
    }
  }
}
