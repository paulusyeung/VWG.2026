// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockingWindowName
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [ToolboxItem(false)]
  [Serializable]
  internal class DockingWindowName
  {
    private string mstrWindowName;
    /// <summary>
    /// 
    /// </summary>
    private static DockingWindowName.DockedWindowNameComparer sobjComparer;

    /// <summary>Gets the docked window name equlity comparer.</summary>
    internal static IEqualityComparer<DockingWindowName> DockedWindowNameEqulityComparer
    {
      get
      {
        if (DockingWindowName.sobjComparer == null)
          DockingWindowName.sobjComparer = new DockingWindowName.DockedWindowNameComparer();
        return (IEqualityComparer<DockingWindowName>) DockingWindowName.sobjComparer;
      }
    }

    /// <summary>Gets or sets the name of the window.</summary>
    /// <value>The name of the window.</value>
    internal string WindowName
    {
      get => this.mstrWindowName;
      set => this.mstrWindowName = value;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class DockedWindowNameComparer : IEqualityComparer<DockingWindowName>
    {
      /// <summary>Determines whether the specified objects are equal.</summary>
      /// <param name="x">The first object of type T to compare.</param>
      /// <param name="y">The second object of type T to compare.</param>
      /// <returns>
      /// true if the specified objects are equal; otherwise, false.
      /// </returns>
      public bool Equals(DockingWindowName x, DockingWindowName y) => x.WindowName == y.WindowName;

      /// <summary>Returns a hash code for this instance.</summary>
      /// <param name="obj">The obj.</param>
      /// <returns>
      /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
      /// </returns>
      /// <exception cref="T:System.ArgumentNullException">The type of obj is a reference type and obj is null.</exception>
      public int GetHashCode(DockingWindowName obj) => obj.GetHashCode();
    }
  }
}
