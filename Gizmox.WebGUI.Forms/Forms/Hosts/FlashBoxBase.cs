// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.FlashBoxBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Summary description for FlashBoxBase.</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class FlashBoxBase : ObjectBox
  {
    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.FlashBoxBase" /> instance.
    /// </summary>
    public FlashBoxBase()
    {
      this.ObjectClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000";
      this.ObjectCodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0";
      this.ObjectPluginsPageType = "http://www.macromedia.com/go/getflashplayer";
      this.ObjectType = "application/x-shockwave-flash";
    }

    /// <summary>Gets or sets the movie.</summary>
    /// <value></value>
    protected string InternalMovie
    {
      get => this.Parameters.Contains("src") ? this.Parameters["src"].ToString() : string.Empty;
      set => this.Parameters["src"] = (object) (this.ObjectData = value);
    }
  }
}
