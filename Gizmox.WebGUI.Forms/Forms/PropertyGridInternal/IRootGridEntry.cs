// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.IRootGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  /// <summary>Defines methods and a property that allow filtering on specific attributes.</summary>
  public interface IRootGridEntry
  {
    /// <summary>Resets the <see cref="P:Gizmox.WebGUI.Forms.PropertyGridInternal.IRootGridEntry.BrowsableAttributes"></see> property to the default value.</summary>
    void ResetBrowsableAttributes();

    /// <summary>Sorts the properties in the property browser.</summary>
    /// <param name="blnShowCategories">true to group the properties by category; otherwise, false.</param>
    void ShowCategories(bool blnShowCategories);

    /// <summary>Gets or sets the attributes on which the property browser filters.</summary>
    /// <returns>The attributes on which the property browser filters.</returns>
    AttributeCollection BrowsableAttributes { get; set; }
  }
}
