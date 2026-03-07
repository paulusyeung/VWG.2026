// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListControlConvertEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListControl.Format"></see> event. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ListControlConvertEventArgs : ConvertEventArgs
  {
    private object mobjListItem;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListControlConvertEventArgs"></see> class with the specified object, type, and list item.</summary>
    /// <param name="objDesiredType">The <see cref="T:System.Type"></see> for the displayed item.</param>
    /// <param name="objListItem">The data source item to be displayed in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</param>
    /// <param name="objValue">The value displayed in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</param>
    public ListControlConvertEventArgs(object objValue, Type objDesiredType, object objListItem)
      : base(objValue, objDesiredType)
    {
      this.mobjListItem = objListItem;
    }

    /// <summary>Gets a data source item.</summary>
    /// <returns>The <see cref="T:System.Object"></see> that represents an item in the data source.</returns>
    /// <filterpriority>1</filterpriority>
    public object ListItem => this.mobjListItem;
  }
}
