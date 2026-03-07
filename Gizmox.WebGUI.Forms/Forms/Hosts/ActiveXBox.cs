// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.ActiveXBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ActiveXBox), "ActiveXBox_45.png")]
  [Serializable]
  public class ActiveXBox : ObjectBox
  {
    /// <summary>Gets or sets the class id.</summary>
    /// <value>The class id.</value>
    [DefaultValue("")]
    public string ClassId
    {
      get => this.ObjectClassId;
      set => this.ObjectClassId = value;
    }

    /// <summary>Gets or sets the data.</summary>
    /// <value>The data.</value>
    [DefaultValue("")]
    public string Data
    {
      get => this.ObjectData;
      set => this.ObjectData = value;
    }

    /// <summary>Gets or sets the code base.</summary>
    /// <value>The code base.</value>
    [DefaultValue("")]
    public string CodeBase
    {
      get => this.ObjectCodeBase;
      set => this.ObjectCodeBase = value;
    }

    /// <summary>Gets or sets the stand by.</summary>
    /// <value>The stand by.</value>
    [DefaultValue("")]
    public string StandBy
    {
      get => this.ObjectStandBy;
      set => this.ObjectStandBy = value;
    }

    /// <summary>Gets or sets the type.</summary>
    /// <value>The type.</value>
    [DefaultValue("")]
    public string Type
    {
      get => this.ObjectType;
      set => this.ObjectType = value;
    }
  }
}
