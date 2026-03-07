// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeViewRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a scrollable control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class TreeViewRenderer : ControlRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewRenderer" /> class.
    /// </summary>
    /// <param name="objTreeView">The treeview control.</param>
    public TreeViewRenderer(TreeView objTreeView)
      : base((Control) objTreeView)
    {
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
    {
      if (!(this.Control is TreeView control) || !(control.Skin is TreeViewSkin skin))
        return;
      Rectangle contentRegion = ControlRenderer.GetContentRegion((Control) control);
      this.RenderNodes(objContext, objGraphics, skin, control.Nodes, contentRegion);
    }

    /// <summary>Renders the nodes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objNodes">The nodes.</param>
    /// <param name="objContentRegion">The content region.</param>
    private void RenderNodes(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      TreeViewSkin objTreeViewSkin,
      TreeNodeCollection objNodes,
      Rectangle objContentRegion)
    {
      foreach (TreeNode objNode in (BaseCollection) objNodes)
      {
        objContentRegion = ControlRenderer.DockInRegion(objContentRegion, DockStyle.Top, this.RenderNode(objContext, objGraphics, objTreeViewSkin, objNode, objContentRegion));
        if (!ControlRenderer.IsVisibleRegion(objContentRegion))
          break;
      }
    }

    /// <summary>Renders the node.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objTreeViewSkin">The tree view skin.</param>
    /// <param name="objContentRegion">The content region.</param>
    /// <returns></returns>
    private Rectangle RenderNode(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      TreeViewSkin objTreeViewSkin,
      TreeNode objNode,
      Rectangle objContentRegion)
    {
      Rectangle objRegion1 = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, 20));
      Rectangle objRegion2 = ControlRenderer.DockInRegion(objRegion1, DockStyle.Left, ControlRenderer.RenderImage(objContext, objGraphics, objNode.Image, objRegion1, ContentAlignment.MiddleLeft));
      Rectangle rectangle1 = ControlRenderer.DockInRegion(objRegion2, DockStyle.Left, ControlRenderer.RenderText(objContext, objGraphics, objNode.Text, objNode.NodeFont, objNode.ForeColor, objRegion2, ContentAlignment.MiddleLeft, false));
      if (objNode.IsExpanded)
      {
        Rectangle rectangle2 = new Rectangle(objContentRegion.X + 20, rectangle1.Bottom, Math.Max(0, rectangle1.Width - 20), Math.Max(0, objContentRegion.Height - 20));
        if (ControlRenderer.IsVisibleRegion(rectangle2))
        {
          int num = 0;
          foreach (TreeNode node in (BaseCollection) objNode.Nodes)
          {
            Rectangle objRectangle = this.RenderNode(objContext, objGraphics, objTreeViewSkin, node, rectangle2);
            num += objRectangle.Height;
            rectangle2 = ControlRenderer.DockInRegion(rectangle2, DockStyle.Top, objRectangle);
            if (!ControlRenderer.IsVisibleRegion(rectangle2))
              break;
          }
          rectangle1.Height += num;
        }
      }
      return rectangle1;
    }
  }
}
