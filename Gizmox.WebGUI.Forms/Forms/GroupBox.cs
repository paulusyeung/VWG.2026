// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GroupBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a Panel control.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (GroupBox), "GroupBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("GB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (GroupBoxSkin))]
  [Serializable]
  public class GroupBox : Control
  {
    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Panel" /> instance.
    /// </summary>
    public GroupBox()
    {
      this.SetStyle(ControlStyles.ContainerControl, true);
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, this.OwnerDraw);
      this.SetStyle(ControlStyles.Selectable, false);
      this.TabStop = false;
    }

    /// <summary>Gets a value indicating whether is owner draw.</summary>
    /// <value><c>true</c> if owner draw; otherwise, <c>false</c>.</value>
    private bool OwnerDraw => this.FlatStyle != FlatStyle.System;

    /// <summary>Gets the preferred size or the client minimum size.</summary>
    /// <param name="objProposedSize">The proposed size.</param>
    /// <param name="blnIsClientMinimumSize">if set to <c>true</c> [BLN is client minimum size].</param>
    /// <returns></returns>
    protected override Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
    {
      Size preferredSize = base.GetPreferredSize(objProposedSize, blnIsClientMinimumSize);
      if (this.AutoSize && this.Skin is GroupBoxSkin skin)
      {
        PaddingValue padding = skin.Padding;
        if (padding != null)
        {
          preferredSize.Width += padding.Horizontal;
          preferredSize.Height += padding.Vertical;
        }
        preferredSize.Width += skin.LeftFrameWidth;
        preferredSize.Width += skin.RightFrameWidth;
        preferredSize.Height += skin.TopFrameHeight;
        preferredSize.Height += skin.BottomFrameHeight;
      }
      return preferredSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new GroupBoxRenderer(this);

    /// <summary>Indicates if to render padding attribute</summary>
    /// <returns></returns>
    protected override bool ShouldRenderPaddingAttribute(Padding objPadding) => (Padding) PaddingValue.Empty != objPadding;

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the text.</summary>
    /// <value></value>
    public override string Text
    {
      get => base.Text;
      set
      {
        this.UpdateParams();
        base.Text = value;
      }
    }

    /// <summary>Gets the control contained area offset.</summary>
    protected override PaddingValue ContainedAreaOffset
    {
      get
      {
        if (!(SkinFactory.GetSkin((ISkinable) this) is GroupBoxSkin skin))
          return base.ContainedAreaOffset;
        return new PaddingValue(new Padding()
        {
          Bottom = skin.BottomFrameHeight,
          Top = skin.TopFrameHeight,
          Left = skin.LeftFrameWidth,
          Right = skin.RightFrameWidth
        } + (Padding) base.ContainedAreaOffset);
      }
    }

    /// <summary>Gets or sets the flat style.</summary>
    /// <value>The flat style.</value>
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Flat;
      set
      {
      }
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(200, 100);
  }
}
