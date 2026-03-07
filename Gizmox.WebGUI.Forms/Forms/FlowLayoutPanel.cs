// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FlowLayoutPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a panel that dynamically lays out its contents horizontally or vertically.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (FlowLayoutPanel), "FlowLayoutPanel_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Containers")]
  [Gizmox.WebGUI.Forms.MetadataTag("FL")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FlowLayoutPanelSkin))]
  [ProxyComponent(typeof (ProxyFlowLayoutPanel))]
  [Serializable]
  public class FlowLayoutPanel : Panel
  {
    /// <summary>
    /// Provides a property reference to WrapContents property.
    /// </summary>
    private static SerializableProperty WrapContentsProperty = SerializableProperty.Register(nameof (WrapContents), typeof (bool), typeof (FlowLayoutPanel), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to FlowDirection property.
    /// </summary>
    private static SerializableProperty FlowDirectionProperty = SerializableProperty.Register(nameof (FlowDirection), typeof (FlowDirection), typeof (FlowLayoutPanel), new SerializablePropertyMetadata((object) FlowDirection.LeftToRight));

    /// <summary>
    /// Layout the internal controls to reflect parent changes
    /// </summary>
    /// <param name="objEventArgs">The layout arguments.</param>
    /// <param name="objNewSize">The new parent size.</param>
    /// <param name="objOldSize">The old parent size.</param>
    protected override void OnLayoutControls(
      LayoutEventArgs objEventArgs,
      ref Size objNewSize,
      ref Size objOldSize)
    {
    }

    /// <summary>Gets the preferred size core.</summary>
    /// <param name="objProposedSize">The size proposed.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size size = new Size(this.Width, this.Height);
      if (this.AutoSize)
      {
        switch (this.Dock)
        {
          case DockStyle.None:
            size = new Size(int.MaxValue, int.MaxValue);
            break;
          case DockStyle.Fill:
            size = new Size(this.Width, this.Height);
            break;
          case DockStyle.Top:
          case DockStyle.Bottom:
            size = new Size(this.Width, int.MaxValue);
            break;
          case DockStyle.Right:
          case DockStyle.Left:
            size = new Size(int.MaxValue, this.Height);
            break;
        }
        Size maximumSize;
        if (this.MaximumSize.Width > 0)
        {
          int width1 = size.Width;
          maximumSize = this.MaximumSize;
          int width2 = maximumSize.Width;
          if (width1 > width2)
          {
            ref Size local = ref size;
            maximumSize = this.MaximumSize;
            int num = Math.Max(maximumSize.Width, this.Width);
            local.Width = num;
          }
        }
        maximumSize = this.MaximumSize;
        if (maximumSize.Height > 0)
        {
          int height1 = size.Height;
          maximumSize = this.MaximumSize;
          int height2 = maximumSize.Height;
          if (height1 > height2)
          {
            ref Size local = ref size;
            maximumSize = this.MaximumSize;
            int num = Math.Max(maximumSize.Height, this.Height);
            local.Height = num;
          }
        }
      }
      Point point = new Point(0, 0);
      int val1_1 = 0;
      int val1_2 = 0;
      FlowDirection flowDirection = this.FlowDirection;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control.Visible)
        {
          Padding margin = control.Margin;
          switch (flowDirection)
          {
            case FlowDirection.LeftToRight:
            case FlowDirection.RightToLeft:
              if (point.X == 0)
              {
                point.X = control.Width + margin.Horizontal;
                val1_2 = control.Height + margin.Vertical;
                val1_1 = control.Width + margin.Horizontal;
                continue;
              }
              if (point.X + control.Width + margin.Horizontal > size.Width)
              {
                point.X = control.Width + margin.Horizontal;
                point.Y = val1_2;
                val1_2 += control.Height + margin.Vertical;
                val1_1 = Math.Max(val1_1, control.Width + margin.Horizontal);
                continue;
              }
              point.X += control.Width + margin.Horizontal;
              val1_1 = Math.Max(val1_2, point.X);
              continue;
            case FlowDirection.TopDown:
            case FlowDirection.BottomUp:
              if (point.Y == 0)
              {
                point.Y = control.Height + margin.Vertical;
                val1_2 = control.Height + margin.Vertical;
                val1_1 = control.Width + margin.Horizontal;
                continue;
              }
              if (point.Y + control.Height + margin.Vertical > size.Height)
              {
                point.X = val1_1;
                point.Y = control.Height + margin.Vertical;
                val1_2 = Math.Max(val1_2, control.Height + margin.Vertical);
                val1_1 += control.Width + margin.Horizontal;
                continue;
              }
              point.Y += control.Height + margin.Vertical;
              val1_2 = Math.Max(val1_2, point.Y);
              continue;
            default:
              continue;
          }
        }
      }
      Padding padding = this.Padding;
      return new Size(val1_1 + padding.Horizontal, val1_2 + padding.Vertical);
    }

    /// <summary>
    /// Gets a value indicating whether to reverse control rendering.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
    /// </value>
    protected override bool ReverseControls => true;

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.ReverseControls)
      {
        for (int index = 0; index < this.Controls.Count; ++index)
          this.Controls[index]?.RenderControl(objContext, objWriter, lngRequestID);
      }
      else
      {
        for (int index = this.Controls.Count - 1; index > -1; --index)
          this.Controls[index]?.RenderControl(objContext, objWriter, lngRequestID);
      }
    }

    /// <summary>Renders the attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      string strValue1 = objContext.ShouldApplyMirroring ? "right" : "left";
      string strValue2 = objContext.ShouldApplyMirroring ? "left" : "right";
      if (this.WrapContents)
        objWriter.WriteAttributeString("WC", "1");
      objWriter.WriteAttributeString("FD", Convert.ToInt32((object) this.FlowDirection).ToString());
      if ((this.FlowDirection & FlowDirection.RightToLeft) > (FlowDirection) 0)
        objWriter.WriteAttributeString("HA", strValue2);
      else
        objWriter.WriteAttributeString("HA", strValue1);
      if ((this.FlowDirection & FlowDirection.BottomUp) > (FlowDirection) 0)
        objWriter.WriteAttributeString("VA", "bottom");
      else
        objWriter.WriteAttributeString("VA", "top");
      base.RenderAttributes(objContext, objWriter);
    }

    /// <summary>Sets the minimum size of the client.</summary>
    /// <param name="objProposedSize">Proposed size.</param>
    protected override void SetMinimumClientSize(Size objProposedSize)
    {
    }

    /// <summary>
    /// Gets a value indicating whether [use minimum client size].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [use minimum client size]; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override bool ShouldRenderMinimumClientSize => false;

    /// <summary>
    /// Gets or sets a value indicating the flow direction of the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlowDirection"></see> values indicating the direction of consecutive placement of controls in the panel. The default is <see cref="F:Gizmox.WebGUI.Forms.FlowDirection.LeftToRight"></see>.</returns>
    [DefaultValue(FlowDirection.LeftToRight)]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    [SRDescription("FlowPanelFlowDirectionDescr")]
    public FlowDirection FlowDirection
    {
      get => this.GetValue<FlowDirection>(FlowLayoutPanel.FlowDirectionProperty);
      set
      {
        if (!this.SetValue<FlowDirection>(FlowLayoutPanel.FlowDirectionProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (FlowDirection));
      }
    }

    /// <summary>
    /// Gets a value indicating whether [support child margins].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
    /// </value>
    protected override bool SupportChildMargins => true;

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control should wrap its contents or let the contents be clipped.
    /// </summary>
    /// <returns>true if the contents should be wrapped; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool WrapContents
    {
      get => this.GetValue<bool>(FlowLayoutPanel.WrapContentsProperty);
      set
      {
        if (!this.SetValue<bool>(FlowLayoutPanel.WrapContentsProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.FireObservableItemPropertyChanged(nameof (WrapContents));
        this.Update();
      }
    }
  }
}
