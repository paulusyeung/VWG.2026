// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IBindableComponent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Enables a non-control component to emulate the data-binding behavior of a Windows Forms control.</summary>
  /// <filterpriority>2</filterpriority>
  public interface IBindableComponent : IComponent, IDisposable
  {
    /// <summary>Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>. </summary>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    BindingContext BindingContext { get; set; }

    /// <summary>Gets the collection of data-binding objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>. </returns>
    /// <filterpriority>1</filterpriority>
    ControlBindingsCollection DataBindings { get; }
  }
}
