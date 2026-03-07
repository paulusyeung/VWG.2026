// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AdministrationLogonControlBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents base login mechanism.</summary>
  [ToolboxItem(false)]
  [Serializable]
  public abstract class AdministrationLogonControlBase : ContentChangeNotifierUserControl
  {
    /// <summary>Determines whether valid login data provided.</summary>
    /// <returns>
    ///   <c>true</c> if [is valid login data]; otherwise, <c>false</c>.
    /// </returns>
    public abstract bool IsValidLogonData();

    /// <summary>Logon action called by user.</summary>
    public bool Logon()
    {
      bool flag = this.IsValidLogonData();
      this.Context.IsLoggedOn = flag;
      return flag;
    }
  }
}
