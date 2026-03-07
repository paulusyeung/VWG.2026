// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class ProxyPropertyValueEventArgs : EventArgs
  {
    private object mobjValue;
    private string mstrPropertyName = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="!:ProxyPropertyValueEventArgs&lt;T&gt;" /> class.
    /// </summary>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <param name="objValue">The obj value.</param>
    public ProxyPropertyValueEventArgs(string strPropertyName, object objValue)
    {
      this.mstrPropertyName = strPropertyName;
      this.mobjValue = objValue;
    }

    /// <summary>Gets or sets the name of the property.</summary>
    /// <value>The name of the property.</value>
    public string PropertyName
    {
      get => this.mstrPropertyName;
      set => this.mstrPropertyName = value;
    }

    /// <summary>Gets or sets the value.</summary>
    /// <value>The value.</value>
    public object Value
    {
      get => this.mobjValue;
      set => this.mobjValue = value;
    }
  }
}
