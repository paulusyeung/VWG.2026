// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProgressBar
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
  /// <summary>Represents a WebGUI progress bar control.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ProgressBar), "ProgressBar_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultBindingProperty("Value")]
  [SRDescription("DescriptionProgressBar")]
  [DefaultProperty("Value")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("PB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ProgressBarSkin))]
  [Serializable]
  public class ProgressBar : Control
  {
    /// <summary>Provides a property reference to Step property.</summary>
    private static SerializableProperty StepProperty = SerializableProperty.Register(nameof (Step), typeof (int), typeof (ProgressBar));
    /// <summary>Provides a property reference to Value property.</summary>
    private static SerializableProperty ValueProperty = SerializableProperty.Register(nameof (Value), typeof (int), typeof (ProgressBar));
    /// <summary>Provides a property reference to Minimum property.</summary>
    private static SerializableProperty MinimumProperty = SerializableProperty.Register(nameof (Minimum), typeof (int), typeof (ProgressBar));
    /// <summary>Provides a property reference to Maximum property.</summary>
    private static SerializableProperty MaximumProperty = SerializableProperty.Register(nameof (Maximum), typeof (int), typeof (ProgressBar));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> class.
    /// </summary>
    public ProgressBar() => this.SetStyle(ControlStyles.Selectable | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, false);

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      int num1 = this.Maximum - this.Minimum;
      int num2 = this.Value - this.Minimum;
      int num3 = 0;
      if (num1 != 0)
        num3 = (int) ((double) num2 / (double) num1 * 100.0);
      objWriter.WriteAttributeString("Precent", num3.ToString());
    }

    /// <summary>
    /// Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Step"></see> property.
    /// </summary>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see>.</exception>
    public void PerformStep() => this.Increment(this.Step);

    /// <summary>
    /// Advances the current position of the progress bar by the specified amount.
    /// </summary>
    /// <param name="value">The amount by which to increment the progress bar's current position. </param>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see></exception>
    public void Increment(int value)
    {
      this.Value += value;
      if (this.Value < this.Minimum)
        this.Value = this.Minimum;
      if (this.Value > this.Maximum)
        this.Value = this.Maximum;
      this.Update();
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(100, 23);

    /// <summary>
    /// Gets or sets the maximum value of the range of the control.
    /// </summary>
    /// <returns>The maximum value of the range. The default is 100.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than 0. </exception>
    [DefaultValue(100)]
    [SRDescription("ProgressBarMaximumDescr")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public int Maximum
    {
      get => this.GetValue<int>(ProgressBar.MaximumProperty, 100);
      set
      {
        if (this.Maximum == value)
          return;
        if (this.Minimum > value)
          this.SetValue<int>(ProgressBar.MinimumProperty, value);
        if (value != 100)
          this.SetValue<int>(ProgressBar.MaximumProperty, value);
        else
          this.RemoveValue<int>(ProgressBar.MaximumProperty);
        if (this.Value > this.Maximum)
          this.SetValue<int>(ProgressBar.ValueProperty, this.Maximum);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the minimum value of the range of the control.
    /// </summary>
    /// <returns>The minimum value of the range. The default is 0.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified for the property is less than 0. </exception>
    [SRDescription("ProgressBarMinimumDescr")]
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public int Minimum
    {
      get => this.GetValue<int>(ProgressBar.MinimumProperty, 0);
      set
      {
        if (this.Minimum == value)
          return;
        if (this.Maximum < value)
          this.SetValue<int>(ProgressBar.MaximumProperty, value);
        if (value != 0)
          this.SetValue<int>(ProgressBar.MinimumProperty, value);
        else
          this.RemoveValue<int>(ProgressBar.MinimumProperty);
        if (this.Value < this.Minimum)
          this.SetValue<int>(ProgressBar.ValueProperty, this.Minimum);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the current position of the progress bar.
    /// </summary>
    /// <returns>The position within the range of the progress bar. The default is 0.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Maximum"></see> property.-or- The value specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Minimum"></see> property. </exception>
    [SRDescription("ProgressBarValueDescr")]
    [Bindable(true)]
    [SRCategory("CatBehavior")]
    [DefaultValue(0)]
    public int Value
    {
      get => this.GetValue<int>(ProgressBar.ValueProperty);
      set
      {
        if (this.Value == value)
          return;
        if (value < this.Minimum || value > this.Maximum)
          throw new ArgumentOutOfRangeException(nameof (Value));
        if (value != 0)
          this.SetValue<int>(ProgressBar.ValueProperty, value);
        else
          this.RemoveValue<int>(ProgressBar.ValueProperty);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the amount by which a call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method increases the current position of the progress bar.
    /// </summary>
    /// <returns>The amount by which to increment the progress bar with each call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method. The default is 10.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(10)]
    [SRDescription("ProgressBarStepDescr")]
    public int Step
    {
      get => this.GetValue<int>(ProgressBar.StepProperty, 10);
      set
      {
        if (value != 10)
          this.SetValue<int>(ProgressBar.StepProperty, value);
        else
          this.RemoveValue<int>(ProgressBar.StepProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Bindable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }
  }
}
