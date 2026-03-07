// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Panel
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
  [ToolboxBitmap(typeof (Panel), "Panel_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [ToolboxItemCategory("Containers")]
  [Gizmox.WebGUI.Forms.MetadataTag("P")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (PanelSkin))]
  [Serializable]
  public class Panel : ScrollableControl
  {
    /// <summary>Provides a property reference to PanelType property.</summary>
    private static SerializableProperty PanelTypeProperty = SerializableProperty.Register(nameof (PanelType), typeof (PanelType), typeof (Panel), new SerializablePropertyMetadata((object) PanelType.Normal));

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Panel" /> instance.
    /// </summary>
    public Panel()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.TabStop = false;
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeText("TX", this.Text);
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      objWriter.WriteAttributeText("TX", this.Text);
    }

    /// <summary>Gets or sets the panel type.</summary>
    /// <value></value>
    [Obsolete("Use HeaderedPanel in the office extension instead")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public PanelType PanelType
    {
      get => this.GetValue<PanelType>(Panel.PanelTypeProperty);
      set
      {
        if (!this.SetValue<PanelType>(Panel.PanelTypeProperty, value))
          return;
        switch (value)
        {
          case PanelType.Normal:
            this.CustomStyle = "";
            break;
          case PanelType.Titled:
            this.CustomStyle = "HeaderedPanel";
            break;
          case PanelType.Border:
            this.CustomStyle = "Border";
            break;
          case PanelType.Page:
            this.CustomStyle = "Page";
            break;
          case PanelType.Custom:
            this.CustomStyle = "Custom";
            break;
          case PanelType.Navigation:
            this.CustomStyle = "Navigation";
            break;
        }
        this.Update();
      }
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

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>Indicates the automatic sizing behavior of the control.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new virtual AutoSizeMode AutoSizeMode
    {
      get => base.AutoSizeMode;
      set => base.AutoSizeMode = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (AutoSizeMode));
    }

    /// <summary>Shoulds the type of the serialize panel.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializePanelType() => this.PanelType != 0;
  }
}
