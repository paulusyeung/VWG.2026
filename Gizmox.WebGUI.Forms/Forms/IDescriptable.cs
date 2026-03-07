// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IDescriptable
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  internal interface IDescriptable
  {
    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor Descriptor { get; }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void Load(DockedObjectDescriptor objDescriptor);

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition);
  }
}
