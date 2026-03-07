// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Handles the painting functionality for <see cref="T:System.Windows.Forms.ToolStrip"></see> objects.</summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Serializable]
  public abstract class ToolStripRenderer
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> class. </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    protected ToolStripRenderer()
    {
    }

    /// <summary>Creates a gray-scale copy of a given image.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> that is a copy of the given image, but with a gray-scale color matrix.</returns>
    /// <param name="normalImage">The image to be copied. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static ResourceHandle CreateDisabledImage(ResourceHandle normalImage) => (ResourceHandle) null;

    /// <summary>Draws an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains data to draw the arrow.</param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawArrow(ToolStripArrowRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains data to draw the button's background.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the drop-down button's background.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawDropDownButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws a move handle on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the data to draw the move handle.</param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawGrip(ToolStripGripRenderEventArgs e)
    {
    }

    /// <summary>Draws the space around an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the space around the image.</param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawImageMargin(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background of the item.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawItemBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that indicates the item is in a selected state.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the selected image.</param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawItemCheck(ToolStripItemImageRenderEventArgs e)
    {
    }

    /// <summary>Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the image.</param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawItemImage(ToolStripItemImageRenderEventArgs e)
    {
    }

    /// <summary>Draws text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the data to draw the text.</param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawItemText(ToolStripItemTextRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the label.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawLabelBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the menu item.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for an overflow button.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawOverflowButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the data to draw the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawSeparator(ToolStripSeparatorRenderEventArgs e)
    {
    }

    /// <summary>Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawSplitButton(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Draws a sizing grip.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawStatusStripSizingGrip(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the background for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawToolStripBackground(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Draws the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the border for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawToolStripBorder(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
    {
    }

    /// <summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
    {
    }

    /// <summary>Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderArrow"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderButtonBackground"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderDropDownButtonBackground"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderGrip"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderGrip(ToolStripGripRenderEventArgs e)
    {
    }

    /// <summary>Draws the item background.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSystemRenderer.OnRenderItemBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemCheck"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemImage"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemText"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderLabelBackground"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderMenuItemBackground"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderOverflowButtonBackground"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderSeparator"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripRenderer.OnRenderSplitButtonBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderStatusStripSizingGrip"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBackground"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBorder"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripContentPanelBackground"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderToolStripContentPanelBackground(
      ToolStripContentPanelRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripPanelBackground"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripStatusLabelBackground"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
    {
    }

    /// <summary>Occurs when an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripArrowRenderEventHandler RenderArrow
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is rendered</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderButtonBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderDropDownButtonBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the move handle for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripGripRenderEventHandler RenderGrip
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Draws the margin between an image and its container. </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripRenderEventHandler RenderImageMargin
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderItemBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the image for a selected <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemImageRenderEventHandler RenderItemCheck
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the image for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemImageRenderEventHandler RenderItemImage
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the text for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemTextRenderEventHandler RenderItemText
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderLabelBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderMenuItemBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for an overflow button is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderOverflowButtonBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is rendered.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripSeparatorRenderEventHandler RenderSeparator
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderSplitButtonBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the display style changes.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripRenderEventHandler RenderStatusStripSizingGrip
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripRenderEventHandler RenderToolStripBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripRenderEventHandler RenderToolStripBorder
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripContentPanelRenderEventHandler RenderToolStripContentPanelBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripPanelRenderEventHandler RenderToolStripPanelBackground
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event ToolStripItemRenderEventHandler RenderToolStripStatusLabelBackground
    {
      add
      {
      }
      remove
      {
      }
    }
  }
}
