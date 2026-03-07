// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MasterPage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A MasterPage control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MasterPageSkin))]
  [Gizmox.WebGUI.Forms.MetadataTag("MP")]
  [Serializable]
  internal class MasterPage : ContainerControl
  {
    public MasterPage()
    {
      this.CustomStyle = "MasterPageSkin";
      this.Dock = DockStyle.Fill;
    }

    protected internal override void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.RenderControl(objContext, objWriter, lngRequestID);
    }

    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      objWriter.WriteAttributeString("RD", "1");
      base.RenderAttributes(objContext, objWriter);
    }
  }
}
