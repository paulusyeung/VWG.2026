// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyFilterPropertiesEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class ProxyFilterPropertiesEventArgs : EventArgs
  {
    private IDictionary mobjPropertyDescriptors;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyFilterPropertiesEventArgs" /> class.
    /// </summary>
    /// <param name="objPropertyDescriptors">The obj property descriptors.</param>
    public ProxyFilterPropertiesEventArgs(IDictionary objPropertyDescriptors) => this.mobjPropertyDescriptors = objPropertyDescriptors;

    /// <summary>Gets or sets the property descriptors.</summary>
    /// <value>The property descriptors.</value>
    public IDictionary PropertyDescriptors
    {
      get => this.mobjPropertyDescriptors;
      set => this.mobjPropertyDescriptors = value;
    }
  }
}
