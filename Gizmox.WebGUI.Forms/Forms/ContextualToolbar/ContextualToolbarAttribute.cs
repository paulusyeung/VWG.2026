// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbarAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
  /// <summary>
  /// Will contain information related to the display of the contextualtoolbar
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, Inherited = true)]
  [Serializable]
  public class ContextualToolbarAttribute : Attribute
  {
    private Type mobjContextualToolbarType;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbarAttribute" /> class.
    /// </summary>
    /// <param name="objContextualToolbarSize">Size of the object contextual toolbar.</param>
    public ContextualToolbarAttribute(Type objContextualToolbarType) => this.mobjContextualToolbarType = objContextualToolbarType;

    /// <summary>Gets or sets the size of the cotextual toolbar.</summary>
    /// <value>The size of the cotextual toolbar.</value>
    internal Type CotextualToolbarType
    {
      get => this.mobjContextualToolbarType;
      set => this.mobjContextualToolbarType = value;
    }
  }
}
