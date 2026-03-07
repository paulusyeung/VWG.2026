// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> and
  /// <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> events.
  /// </summary>
  [Serializable]
  public class TreeNodeMouseClickEventArgs : MouseEventArgs
  {
    private TreeNode mobjNode;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> class. </summary>
    /// <param name="intY">The y-coordinate where the click occurred.</param>
    /// <param name="intClicks">The number of clicks that occurred.</param>
    /// <param name="objNode">The node that was clicked.</param>
    /// <param name="objButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MouseButtons"></see> members.</param>
    /// <param name="intX">The x-coordinate where the click occurred.</param>
    public TreeNodeMouseClickEventArgs(
      TreeNode objNode,
      MouseButtons objButton,
      int intClicks,
      int intX,
      int intY)
      : base(objButton, intClicks, intX, intY, 0)
    {
      this.mobjNode = objNode;
    }

    /// <summary>Gets the node that was clicked.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that was clicked.</returns>
    /// <filterpriority>1</filterpriority>
    public TreeNode Node => this.mobjNode;
  }
}
