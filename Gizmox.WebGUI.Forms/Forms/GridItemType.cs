// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GridItemType
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the valid grid item types for a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
  /// </summary>
  public enum GridItemType
  {
    /// <summary>A grid entry that corresponds to a property.</summary>
    Property,
    /// <summary>
    /// A grid entry that is a category name. A category is a descriptive grouping for groups of <see cref="T:System.Windows.Forms.GridItem"></see> rows. Typical categories include the following Behavior, Layout, Data, and Appearance.
    /// </summary>
    Category,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is an element of an array.
    /// </summary>
    ArrayValue,
    /// <summary>A root item in the grid hierarchy.</summary>
    Root,
  }
}
