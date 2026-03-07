// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FrameControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides a base class that allows invocation of methods that reside inside controls that have frames
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FrameControlSkin))]
  [Gizmox.WebGUI.Forms.MetadataTag("FC")]
  [Serializable]
  public abstract class FrameControl : Control
  {
    /// <summary>
    /// Invokes a client side method on the hosted control frame.
    /// </summary>
    /// <param name="strMember">The client side method name.</param>
    /// <param name="arrArgs">The arugments to be passed to the method</param>
    public void InvokeClientMethod(string strMember, params object[] arrArgs)
    {
      List<object> objectList = new List<object>();
      objectList.Add((object) this.ID.ToString());
      objectList.Add((object) strMember);
      objectList.AddRange((IEnumerable<object>) arrArgs);
      this.InvokeMethod("Remoting_ServerInvokeTargetMember", objectList.ToArray());
    }

    protected override ControlSkipMultiTheme SkipMultiTheme => this.Source != null && this.Source.StartsWith("http") ? ControlSkipMultiTheme.Url : base.SkipMultiTheme;

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (!this.IsInline)
        objWriter.WriteAttributeString("SR", this.Source);
      else
        objWriter.WriteAttributeText("SR", this.Source);
      objWriter.WriteAttributeString("II", this.IsInline ? "1" : "0");
    }

    /// <summary>
    /// Indicates if the framecontrol should render source as inline html of as a url for
    /// a frame.
    /// </summary>
    protected virtual bool IsInline => false;

    /// <summary>Gets the source.</summary>
    /// <value>The source.</value>
    protected abstract string Source { get; }
  }
}
