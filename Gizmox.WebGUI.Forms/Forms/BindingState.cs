// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingState
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Flags]
  internal enum BindingState
  {
    /// <summary>The PropertyInfoInternal flag</summary>
    PropertyInfoInternal = 1,
    /// <summary>The PropropertyInfoConverterInternal flag</summary>
    PropropertyInfoConverterInternal = 2,
    /// <summary>The PropropertyIsNullInfoInternal flag</summary>
    PropropertyIsNullInfoInternal = 4,
    /// <summary>The ValidateInfoInternal flag</summary>
    ValidateInfoInternal = 8,
  }
}
