// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.LinkLabel.LinkClicked"></see> event.
  /// </summary>
  [Serializable]
  public class LinkLabelLinkClickedEventArgs : EventArgs
  {
    private readonly LinkLabel.Link mobjLink;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventArgs"></see> class with the specified link.
    /// </summary>
    /// <param name="objLink">The <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> that was clicked. </param>
    public LinkLabelLinkClickedEventArgs(LinkLabel.Link objLink) => this.mobjLink = objLink;

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> that was clicked.
    /// </summary>
    /// <returns>A link on the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.</returns>
    public LinkLabel.Link Link => this.mobjLink;
  }
}
