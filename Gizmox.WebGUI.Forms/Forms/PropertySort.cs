// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertySort
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies how properties are sorted in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
  /// </summary>
  public enum PropertySort
  {
    /// <summary>
    /// Properties are displayed in the order in which they are retrieved from the <see cref="T:System.ComponentModel.TypeDescriptor"></see>.
    /// </summary>
    NoSort,
    /// <summary>Properties are sorted in an alphabetical list.</summary>
    Alphabetical,
    /// <summary>
    /// Properties are displayed according to their category in a group. The categories are defined by the properties themselves.
    /// </summary>
    Categorized,
    /// <summary>
    /// Properties are displayed according to their category in a group. The properties are further sorted alphabetically within the group. The categories are defined by the properties themselves.
    /// </summary>
    CategorizedAlphabetical,
  }
}
