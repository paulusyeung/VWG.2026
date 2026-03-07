// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AppletBoxBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Summary description for AppletBoxBase.</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class AppletBoxBase : ObjectBox
  {
    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBoxBase" /> instance.
    /// </summary>
    public AppletBoxBase()
    {
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBoxBase" /> instance.
    /// </summary>
    /// <param name="strCodeBase">Applet code base.</param>
    /// <param name="strArchive">Applet archive.</param>
    /// <param name="strCode">Applet code.</param>
    public AppletBoxBase(string strArchive, string strCode) => this.InternalArchive = strArchive;

    /// <summary>Gets or sets the archive.</summary>
    /// <value></value>
    protected string InternalArchive
    {
      get => this.Parameters["archive"] == null ? string.Empty : this.Parameters["archive"].ToString();
      set => this.Parameters["archive"] = (object) value;
    }

    /// <summary>Gets or sets the archive.</summary>
    /// <value></value>
    protected string ObjectCode
    {
      get => this.Parameters["code"] == null ? string.Empty : this.Parameters["code"].ToString();
      set => this.Parameters["code"] = (object) value;
    }
  }
}
