// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TrackBar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a standard Visual WebGui track bar.</summary>
  [ToolboxBitmap(typeof (TrackBar), "TrackBar_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [DefaultProperty("Value")]
  [DefaultEvent("ValueChanged")]
  [SRDescription("DescriptionTrackBar")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("TRB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TrackBarSkin))]
  [Serializable]
  public class TrackBar : Control, ISupportInitialize
  {
    /// <summary>Provides a property reference to TickStyle property.</summary>
    private static SerializableProperty TickStyleProperty = SerializableProperty.Register(nameof (TickStyle), typeof (TickStyle), typeof (TrackBar));
    /// <summary>
    /// Provides a property reference to TickFrequency property.
    /// </summary>
    private static SerializableProperty TickFrequencyProperty = SerializableProperty.Register(nameof (TickFrequency), typeof (int), typeof (TrackBar));
    /// <summary>
    /// Provides a property reference to SmallChange property.
    /// </summary>
    private static SerializableProperty SmallChangeProperty = SerializableProperty.Register(nameof (SmallChange), typeof (int), typeof (TrackBar));
    /// <summary>
    /// Provides a property reference to Orientation property.
    /// </summary>
    private static SerializableProperty OrientationProperty = SerializableProperty.Register(nameof (Orientation), typeof (Orientation), typeof (TrackBar));
    /// <summary>Provides a property reference to Minimum property.</summary>
    private static SerializableProperty MinimumProperty = SerializableProperty.Register(nameof (Minimum), typeof (int), typeof (TrackBar));
    /// <summary>Provides a property reference to Maximum property.</summary>
    private static SerializableProperty MaximumProperty = SerializableProperty.Register(nameof (Maximum), typeof (int), typeof (TrackBar));
    /// <summary>
    /// Provides a property reference to LargeChange property.
    /// </summary>
    private static SerializableProperty LargeChangeProperty = SerializableProperty.Register(nameof (LargeChange), typeof (int), typeof (TrackBar));
    /// <summary>Provides a property reference to Value property.</summary>
    private static SerializableProperty ValueProperty = SerializableProperty.Register(nameof (Value), typeof (float), typeof (TrackBar), new SerializablePropertyMetadata((object) 0));
    /// <summary>Provides a RequestedDim property.</summary>
    private int mintRequestedDim;
    /// <summary>The value change event reference</summary>
    private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof (EventHandler), typeof (TrackBar));

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property of a track bar changes, either by movement of the scroll box or by manipulation in code.
    /// </summary>
    [SRCategory("CatAction")]
    [SRDescription("valueChangedEventDescr")]
    public event EventHandler ValueChanged
    {
      add => this.AddCriticalHandler(TrackBar.ValueChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TrackBar.ValueChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("Occurs when control's value changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientValueChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Gets the value changed handler.</summary>
    /// <value>The value changed handler.</value>
    private EventHandler ValueChangedHandler => (EventHandler) this.GetHandler(TrackBar.ValueChangedEvent);

    /// <summary>
    /// Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
    /// </summary>
    public void BeginInit()
    {
    }

    /// <summary>
    /// Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
    /// </summary>
    public void EndInit()
    {
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.TrackBar.ValueChanged"></see> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnValueChanged(EventArgs e)
    {
      EventHandler valueChangedHandler = this.ValueChangedHandler;
      if (valueChangedHandler == null)
        return;
      valueChangedHandler((object) this, e);
    }

    /// <summary>
    /// Sets the minimum and maximum values for a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>.
    /// </summary>
    /// <param name="intMinValue">The lower limit of the range of the track bar. </param>
    /// <param name="intMaxValue">The upper limit of the range of the track bar. </param>
    public void SetRange(int intMinValue, int intMaxValue)
    {
      int maximumInternal = this.MaximumInternal;
      bool flag1 = this.MinimumInternal != intMinValue;
      bool flag2 = maximumInternal != intMaxValue;
      if (!(flag1 | flag2))
        return;
      double valueInternal = (double) this.ValueInternal;
      if (intMinValue > intMaxValue)
      {
        intMaxValue = intMinValue;
        flag2 = maximumInternal != intMaxValue;
      }
      if (flag1)
        this.MinimumInternal = intMinValue;
      if (flag2)
        this.MaximumInternal = intMaxValue;
      if (valueInternal < (double) intMinValue)
        this.SetValue<float>(TrackBar.ValueProperty, (float) intMinValue);
      if (valueInternal <= (double) intMaxValue)
        return;
      this.SetValue<float>(TrackBar.ValueProperty, (float) intMaxValue);
    }

    /// <summary>
    /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> control.
    /// </summary>
    /// <returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. </returns>
    public override string ToString() => base.ToString() + ", Minimum: " + this.Minimum.ToString() + ", Maximum: " + this.Maximum.ToString() + ", Value: " + this.Value.ToString();

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.ValueChangedHandler != null)
        criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "ValueChange"))
        return;
      float num = float.Parse(objEvent["VLB"], NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture);
      if ((double) num < 0.0)
        num = 0.0f;
      else if ((double) num > 100.0)
        num = 100f;
      int minimum = this.Minimum;
      this.ValueInternal = (float) minimum + (float) (this.Maximum - minimum) * (num / 100f);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      int tickFrequency = this.TickFrequency;
      float num1 = (float) (this.Maximum - this.Minimum + 1);
      Decimal num2 = Math.Round((Decimal) (float) ((double) tickFrequency / (double) num1 * 100.0), 2);
      Decimal num3 = 0M;
      if ((double) num1 > 1.0)
        num3 = Math.Round((Decimal) (float) (((double) this.ValueInternal - (double) this.Minimum) / ((double) num1 - 1.0) * 100.0), 2);
      else
        objWriter.WriteAttributeString("FZ", "1");
      Decimal num4 = 1M;
      if (tickFrequency > 0)
        num4 = Convert.ToDecimal(Math.Floor(((double) num1 - 1.0) / (double) tickFrequency));
      objWriter.WriteAttributeString("S", ((int) this.TickStyle).ToString());
      objWriter.WriteAttributeString("ORI", ((int) this.Orientation).ToString());
      objWriter.WriteAttributeString("LEN", num4.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("TSZ", num2.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("VLB", num3.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      if (this.VisualTemplate == null)
        return;
      objWriter.WriteAttributeString("MIN", this.Minimum.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("MAX", this.Maximum.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Gets or sets a value to be added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a large distance.
    /// </summary>
    /// <returns>A numeric value. The default is 5.</returns>
    /// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
    [SRCategory("CatBehavior")]
    [SRDescription("TrackBarLargeChangeDescr")]
    [DefaultValue(5)]
    public int LargeChange
    {
      get => this.GetValue<int>(TrackBar.LargeChangeProperty, 5);
      set
      {
        if (this.LargeChange == value)
          return;
        this.SetValue<int>(TrackBar.LargeChangeProperty, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the maximum internal.</summary>
    /// <value>The maximum internal.</value>
    private int MaximumInternal
    {
      get => this.GetValue<int>(TrackBar.MaximumProperty, 10);
      set => this.SetValue<int>(TrackBar.MaximumProperty, value);
    }

    /// <summary>
    /// Gets or sets the upper limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
    /// </summary>
    /// <returns>The maximum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 10.</returns>
    [DefaultValue(10)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("TrackBarMaximumDescr")]
    [SRCategory("CatBehavior")]
    public int Maximum
    {
      get => this.MaximumInternal;
      set
      {
        if (this.MaximumInternal == value)
          return;
        int intMinValue = this.MinimumInternal;
        if (value < intMinValue)
          this.MinimumInternal = intMinValue = value;
        this.SetRange(intMinValue, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the minimum internal.</summary>
    /// <value>The minimum internal.</value>
    private int MinimumInternal
    {
      get => this.GetValue<int>(TrackBar.MinimumProperty, 0);
      set => this.SetValue<int>(TrackBar.MinimumProperty, value);
    }

    /// <summary>
    /// Gets or sets the lower limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
    /// </summary>
    /// <returns>The minimum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 0.</returns>
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    [SRDescription("TrackBarMinimumDescr")]
    [RefreshProperties(RefreshProperties.All)]
    public int Minimum
    {
      get => this.MinimumInternal;
      set
      {
        if (this.MinimumInternal == value)
          return;
        int intMaxValue = this.MaximumInternal;
        if (value > intMaxValue)
          this.MaximumInternal = intMaxValue = value;
        this.SetRange(value, intMaxValue);
        this.Update();
      }
    }

    /// <summary>Gets or sets the requested dim.</summary>
    /// <value>The requested dim.</value>
    [SRCategory("CatBehavior")]
    [SRDescription("TrackBarLargeChangeDescr")]
    [DefaultValue(5)]
    private int RequestedDim
    {
      get => this.mintRequestedDim;
      set => this.mintRequestedDim = value;
    }

    /// <summary>
    /// Gets or sets a value indicating the horizontal or vertical orientation of the track bar.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. </exception>
    [DefaultValue(Orientation.Horizontal)]
    [Localizable(true)]
    [SRDescription("TrackBarOrientationDescr")]
    [SRCategory("CatAppearance")]
    public Orientation Orientation
    {
      get => this.GetValue<Orientation>(TrackBar.OrientationProperty, Orientation.Horizontal);
      set
      {
        if (this.Orientation == value)
          return;
        this.SetValue<Orientation>(TrackBar.OrientationProperty, value);
        if (this.Orientation == Orientation.Horizontal)
        {
          this.SetStyle(ControlStyles.FixedHeight, this.AutoSize);
          this.SetStyle(ControlStyles.FixedWidth, false);
          this.Width = this.RequestedDim;
        }
        else
        {
          this.SetStyle(ControlStyles.FixedHeight, false);
          this.SetStyle(ControlStyles.FixedWidth, this.AutoSize);
          this.Height = this.RequestedDim;
        }
        Rectangle bounds = this.Bounds;
        this.SetBoundsCore(bounds.X, bounds.Y, bounds.Height, bounds.Width, BoundsSpecified.All);
        this.AdjustSize();
        this.Update();
      }
    }

    /// <summary>
    /// Performs the work of setting the specified bounds of this control.
    /// </summary>
    /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
    /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
    /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
    /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
    /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
    /// <returns></returns>
    protected override bool SetBoundsCore(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified,
      bool blnIsClientSource)
    {
      this.RequestedDim = this.Orientation == Orientation.Horizontal ? intHeight : intWidth;
      return base.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
    }

    /// <summary>Adjusts the size.</summary>
    private void AdjustSize()
    {
      int requestedDim = this.RequestedDim;
      try
      {
        if (this.Orientation == Orientation.Horizontal)
          this.Height = requestedDim;
        else
          this.Width = requestedDim;
      }
      finally
      {
        this.RequestedDim = requestedDim;
      }
    }

    /// <summary>
    /// Gets or sets the value added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a small distance.
    /// </summary>
    /// <returns>A numeric value. The default value is 1.</returns>
    /// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
    [SRCategory("CatAppearance")]
    [DefaultValue(1)]
    [SRDescription("TrackBarSmallChangeDescr")]
    public int SmallChange
    {
      get => this.GetValue<int>(TrackBar.SmallChangeProperty, 1);
      set
      {
        if (this.SmallChange == value)
          return;
        this.SetValue<int>(TrackBar.SmallChangeProperty, value);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value that specifies the delta between ticks drawn on the control.
    /// </summary>
    /// <returns>The numeric value representing the delta between ticks. The default is 1.</returns>
    [DefaultValue(1)]
    [SRDescription("TrackBarTickFrequencyDescr")]
    [SRCategory("CatAppearance")]
    public int TickFrequency
    {
      get => this.GetValue<int>(TrackBar.TickFrequencyProperty, 1);
      set
      {
        if (this.TickFrequency == value)
          return;
        this.SetValue<int>(TrackBar.TickFrequencyProperty, value);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating how to display the tick marks on the track bar.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TickStyle.BottomRight"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see>. </exception>
    [DefaultValue(TickStyle.BottomRight)]
    [SRCategory("CatAppearance")]
    [SRDescription("TrackBarTickStyleDescr")]
    public TickStyle TickStyle
    {
      get => this.GetValue<TickStyle>(TrackBar.TickStyleProperty, TickStyle.BottomRight);
      set
      {
        if (this.TickStyle == value)
          return;
        this.SetValue<TickStyle>(TrackBar.TickStyleProperty, value, TickStyle.BottomRight);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
    /// </summary>
    /// <returns>A numeric value that is within the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see> and <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see> range. The default value is 0.</returns>
    /// <exception cref="T:System.ArgumentException">The assigned value is less than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see>.-or- The assigned value is greater than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see>. </exception>
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    [SRDescription("TrackBarValueDescr")]
    [Bindable(true)]
    public int Value
    {
      get => Convert.ToInt32(this.ValueInternal);
      set
      {
        if (value < this.Minimum || value > this.Maximum)
          throw new ArgumentOutOfRangeException(nameof (Value), SR.GetString("InvalidBoundArgument", (object) nameof (Value), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "'Minimum'", (object) "'Maximum'"));
        if (this.Value == value)
          return;
        this.ValueInternal = (float) value;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Value));
      }
    }

    /// <summary>Gets or sets the internal value.</summary>
    /// <value>The internal value.</value>
    private float ValueInternal
    {
      get => this.GetValue<float>(TrackBar.ValueProperty, 0.0f);
      set
      {
        if (!this.SetValue<float>(TrackBar.ValueProperty, value))
          return;
        this.OnValueChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Bindable(false)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }
  }
}
