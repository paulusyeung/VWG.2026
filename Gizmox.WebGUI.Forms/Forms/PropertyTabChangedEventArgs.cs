// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyTabChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyTabChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [Serializable]
  public class PropertyTabChangedEventArgs : EventArgs
  {
    private PropertyTab newTab;
    private PropertyTab oldTab;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyTabChangedEventArgs"></see> class.</summary>
    /// <param name="objNewTab">The newly selected property tab. </param>
    /// <param name="objOldTab">The Previously selected property tab. </param>
    public PropertyTabChangedEventArgs(PropertyTab objOldTab, PropertyTab objNewTab)
    {
      this.oldTab = objOldTab;
      this.newTab = objNewTab;
    }

    /// <summary>Gets the new <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> selected.</summary>
    /// <returns>The newly selected <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public PropertyTab NewTab => this.newTab;

    /// <summary>Gets the old <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> selected.</summary>
    /// <returns>The old <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> that was selected.</returns>
    /// <filterpriority>1</filterpriority>
    public PropertyTab OldTab => this.oldTab;
  }
}
