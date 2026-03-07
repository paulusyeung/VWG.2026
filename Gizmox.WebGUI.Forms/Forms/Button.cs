// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Button
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
  /// <summary>A button control</summary>
  [ToolboxItem(true)]
  [ToolboxItemCategory("Common Controls")]
  [ToolboxBitmap(typeof (Button), "Button_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Gizmox.WebGUI.Forms.MetadataTag("B")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ButtonSkin))]
  [Serializable]
  public class Button : ButtonBase, IButtonControl
  {
    /// <summary>
    /// Provides a property reference to ButtonStyle property.
    /// </summary>
    private static SerializableProperty ButtonStyleProperty = SerializableProperty.Register(nameof (ButtonStyle), typeof (ButtonStyle), typeof (Button), new SerializablePropertyMetadata((object) ButtonStyle.Normal));
    /// <summary>
    /// Provides a property reference to DialogResult property.
    /// </summary>
    private static SerializableProperty DialogResultProperty = SerializableProperty.Register(nameof (DialogResult), typeof (DialogResult), typeof (Button), new SerializablePropertyMetadata((object) DialogResult.None));
    /// <summary>
    /// Provides a property reference to DropDownMenu property.
    /// </summary>
    private static SerializableProperty DropDownMenuProperty = SerializableProperty.Register(nameof (DropDownMenu), typeof (Menu), typeof (Button), new SerializablePropertyMetadata((object) null));

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Button" /> instance.
    /// </summary>
    public Button() => this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DropDownMenu != null)
        criticalEventsData.Set("CL");
      else if (this.DialogResult != DialogResult.None)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "Click")
      {
        if (this.ClickOnce)
          this.SetEnabledInternal(false);
        Menu dropDownMenu = this.DropDownMenu;
        if (dropDownMenu != null && this.GetEventButtonsValue(objEvent, MouseButtons.Left) == MouseButtons.Left)
          dropDownMenu.Show((Component) this, Point.Empty, DialogAlignment.Below);
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.DropDownMenu != null)
        objWriter.WriteAttributeString("DD", "1");
      if (!this.ClickOnce)
        return;
      objWriter.WriteAttributeString("CL1", "1");
    }

    /// <summary>Renders the back color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor)
    {
      if (this.UseVisualStyleBackColor)
        return;
      base.RenderBackColorAttribute(objWriter, objBackColor);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() => base.ToString() + ", Text: " + this.Text;

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fitted.
    /// </summary>
    /// <param name="objProposedSize">The custom-sized area for a control.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize = base.GetPreferredSize(objProposedSize);
      if (this.AutoSize)
      {
        if (this.Skin is ButtonSkin skin)
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
        Size imageSize1 = this.ImageSize;
        if (this.Image != null || this.ImageIndex != -1 || this.ImageKey != string.Empty)
        {
          switch (this.TextImageRelation)
          {
            case TextImageRelation.Overlay:
              preferredSize.Width = Math.Max(this.ImageSize.Width, preferredSize.Width);
              preferredSize.Height = Math.Max(this.ImageSize.Height, preferredSize.Height);
              break;
            case TextImageRelation.ImageAboveText:
            case TextImageRelation.TextAboveImage:
              ref Size local1 = ref preferredSize;
              int height1 = local1.Height;
              Size imageSize2 = this.ImageSize;
              int height2 = imageSize2.Height;
              local1.Height = height1 + height2;
              ref Size local2 = ref preferredSize;
              imageSize2 = this.ImageSize;
              int num1 = Math.Max(imageSize2.Width, preferredSize.Width);
              local2.Width = num1;
              break;
            case TextImageRelation.ImageBeforeText:
            case TextImageRelation.TextBeforeImage:
              ref Size local3 = ref preferredSize;
              int width1 = local3.Width;
              Size imageSize3 = this.ImageSize;
              int width2 = imageSize3.Width;
              local3.Width = width1 + width2;
              ref Size local4 = ref preferredSize;
              imageSize3 = this.ImageSize;
              int num2 = Math.Max(imageSize3.Height, preferredSize.Height);
              local4.Height = num2;
              break;
          }
        }
      }
      return preferredSize;
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new ButtonRenderer(this);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
    /// event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnClick(EventArgs objEventArgs)
    {
      DialogResult dialogResult = this.DialogResult;
      Form form = this.Form;
      if (form != null)
        form.DialogResult = dialogResult;
      base.OnClick(objEventArgs);
      if (form == null || form.DialogType != DialogTypes.ModalWindow && form.DialogType != DialogTypes.PopupWindow || form.DialogResult == DialogResult.None)
        return;
      form.Close();
    }

    /// <summary>Defines a dropdown menu to the button</summary>
    [DefaultValue(null)]
    public Menu DropDownMenu
    {
      get => this.GetValue<Menu>(Button.DropDownMenuProperty);
      set
      {
        if (!this.SetValue<Menu>(Button.DropDownMenuProperty, value))
          return;
        if (value != null)
          value.InternalParent = (Component) this;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value that is returned to the parent form when the button is clicked.
    /// </summary>
    /// <value></value>
    [SRDescription("ButtonDialogResultDescr")]
    [DefaultValue(DialogResult.None)]
    [SRCategory("CatBehavior")]
    public DialogResult DialogResult
    {
      get => this.GetValue<DialogResult>(Button.DialogResultProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DialogResult));
        this.SetValue<DialogResult>(Button.DialogResultProperty, value);
      }
    }

    /// <summary>
    /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
    /// </summary>
    [Localizable(true)]
    [SRDescription("ControlAutoSizeModeDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(AutoSizeMode.GrowOnly)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override AutoSizeMode AutoSizeMode
    {
      get => base.AutoSizeMode;
      set => base.AutoSizeMode = value;
    }

    /// <summary>Gets or sets the button style.</summary>
    /// <value></value>
    [DefaultValue(ButtonStyle.Normal)]
    public ButtonStyle ButtonStyle
    {
      get => this.GetValue<ButtonStyle>(Button.ButtonStyleProperty);
      set
      {
        if (!this.SetValue<ButtonStyle>(Button.ButtonStyleProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the ClickOnce property.</summary>
    /// <value>The key down filter.</value>
    [DefaultValue(false)]
    [SRDescription("ControlClickOnceDescr")]
    [SRCategory("CatBehavior")]
    public bool ClickOnce
    {
      get => this.GetState(Component.ComponentState.ClickOnce);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.ClickOnce, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override Size DefaultSize => new Size(75, 23);

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override BorderColor BorderColor
    {
      get => base.BorderColor;
      set => base.BorderColor = value;
    }

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override BorderWidth BorderWidth
    {
      get => base.BorderWidth;
      set => base.BorderWidth = value;
    }

    /// <summary>Performs the click.</summary>
    public void PerformClick() => this.OnClick(EventArgs.Empty);

    /// <summary>Notifies the default.</summary>
    /// <param name="value">Value.</param>
    public void NotifyDefault(bool blnValue)
    {
    }
  }
}
