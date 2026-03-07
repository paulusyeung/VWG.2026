// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NumericUpDown
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
  /// <summary>
  /// Represents a Windows spin box (also known as an up-down control) that displays numeric values.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (NumericUpDown), "NumericUpDown_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [SRDescription("DescriptionNumericUpDown")]
  [DefaultProperty("Value")]
  [DefaultEvent("ValueChanged")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("NUD")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (NumericUpDownSkin))]
  [Serializable]
  public class NumericUpDown : UpDownBase, ISupportInitialize
  {
    private static readonly Decimal DefaultIncrement = 1M;
    private static readonly Decimal DefaultMaximum = 100M;
    private static readonly Decimal DefaultMinimum = 0M;
    private const bool DefaultThousandsSeparator = false;
    private static readonly Decimal DefaultValue = 0M;
    private const int InvalidValue = -1;
    private NumericUpDownAccelerationCollection mobjAccelerations;
    /// <summary>The CurrentValueChanged Property registration.</summary>
    private static readonly SerializableProperty CurrentValueChangedProperty = SerializableProperty.Register(nameof (CurrentValueChanged), typeof (bool), typeof (NumericUpDown), new SerializablePropertyMetadata((object) false));
    /// <summary>The CurrentValue Property registration.</summary>
    private static readonly SerializableProperty CurrentValueProperty = SerializableProperty.Register(nameof (CurrentValue), typeof (Decimal), typeof (NumericUpDown), new SerializablePropertyMetadata((object) NumericUpDown.DefaultValue));
    /// <summary>The accelerationsCurrentIndex Property registration.</summary>
    private static readonly SerializableProperty DecimalPlacesProperty = SerializableProperty.Register(nameof (DecimalPlaces), typeof (int), typeof (NumericUpDown), new SerializablePropertyMetadata((object) 0));
    /// <summary>The Hexadecimal Property registration.</summary>
    private static readonly SerializableProperty HexadecimalProperty = SerializableProperty.Register(nameof (Hexadecimal), typeof (bool), typeof (NumericUpDown), new SerializablePropertyMetadata((object) false));
    /// <summary>The Increment Property registration.</summary>
    private static SerializableProperty IncrementProperty = SerializableProperty.Register(nameof (Increment), typeof (Decimal), typeof (NumericUpDown), new SerializablePropertyMetadata((object) NumericUpDown.DefaultIncrement));
    /// <summary>The Maximum Property registration.</summary>
    private static SerializableProperty MaximumProperty = SerializableProperty.Register(nameof (Maximum), typeof (Decimal), typeof (NumericUpDown), new SerializablePropertyMetadata((object) NumericUpDown.DefaultMaximum));
    /// <summary>The Minimum Property registration.</summary>
    private static SerializableProperty MinimumProperty = SerializableProperty.Register(nameof (Minimum), typeof (Decimal), typeof (NumericUpDown), new SerializablePropertyMetadata((object) NumericUpDown.DefaultMinimum));
    /// <summary>The SelectedItemChanged event registration.</summary>
    private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof (EventHandler), typeof (NumericUpDown));
    /// <summary>The ThousandsSeparator Property registration.</summary>
    private static SerializableProperty ThousandsSeparatorProperty = SerializableProperty.Register(nameof (ThousandsSeparator), typeof (bool), typeof (NumericUpDown), new SerializablePropertyMetadata((object) false));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> class.</summary>
    public NumericUpDown() => this.Text = "0";

    /// <summary>Gets or sets the current value property.</summary>
    /// <value>The current value property.</value>
    public Decimal CurrentValue
    {
      get => this.CurrentValueInternal;
      set
      {
        if (!(this.CurrentValue != value))
          return;
        this.CurrentValueInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets the current value internal.</summary>
    /// <value>The current value internal.</value>
    private Decimal CurrentValueInternal
    {
      get => this.GetValue<Decimal>(NumericUpDown.CurrentValueProperty);
      set => this.SetValue<Decimal>(NumericUpDown.CurrentValueProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [current value changed].
    /// </summary>
    /// <value><c>true</c> if [current value changed]; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool CurrentValueChanged
    {
      get => this.GetValue<bool>(NumericUpDown.CurrentValueChangedProperty);
      set
      {
        this.CurrentValueChangedInternal = value;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [current value changed].
    /// </summary>
    /// <value><c>true</c> if [current value changed]; otherwise, <c>false</c>.</value>
    protected bool CurrentValueChangedInternal
    {
      get => this.GetValue<bool>(NumericUpDown.CurrentValueChangedProperty);
      set => this.SetValue<bool>(NumericUpDown.CurrentValueChangedProperty, value);
    }

    /// <summary>Resets the CurrentValue</summary>
    private void ResetCurrentValue() => this.CurrentValue = NumericUpDown.DefaultValue;

    /// <summary>
    /// Gets or sets the number of decimal places to display in the spin box (also known as an up-down control).
    /// </summary>
    /// <value>The decimal places.</value>
    /// <returns>The number of decimal places to display in the spin box. The default is 0.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value assigned is less than 0.-or- The value assigned is greater than 99. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("NumericUpDownDecimalPlacesDescr")]
    [SRCategory("CatData")]
    [System.ComponentModel.DefaultValue(0)]
    public int DecimalPlaces
    {
      get => this.GetValue<int>(NumericUpDown.DecimalPlacesProperty);
      set
      {
        if (value < 0 || value > 99)
          throw new ArgumentOutOfRangeException(nameof (DecimalPlaces), SR.GetString("InvalidBoundArgument", (object) nameof (DecimalPlaces), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "99"));
        if (!this.SetValue<int>(NumericUpDown.DecimalPlacesProperty, value))
          return;
        this.UpdateEditText();
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the spin box (also known as an up-down control) should display the value it contains in Hexadecimal format.</summary>
    /// <returns>true if the spin box should display its value in Hexadecimal format; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("NumericUpDownHexadecimalDescr")]
    [SRCategory("CatAppearance")]
    [System.ComponentModel.DefaultValue(false)]
    public bool Hexadecimal
    {
      get => this.GetValue<bool>(NumericUpDown.HexadecimalProperty);
      set
      {
        if (!this.SetValue<bool>(NumericUpDown.HexadecimalProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the value to Increment or decrement the spin box (also known as an up-down control) when the up or down buttons are clicked.</summary>
    /// <returns>The value to Increment or decrement the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property when the up or down buttons are clicked on the spin box. The default value is 1.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is not a positive number. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("NumericUpDownIncrementDescr")]
    [SRCategory("CatData")]
    public Decimal Increment
    {
      get => this.GetValue<Decimal>(NumericUpDown.IncrementProperty);
      set
      {
        if (value < 0M)
          throw new ArgumentOutOfRangeException(nameof (Increment), SR.GetString("InvalidArgument", (object) nameof (Increment), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<Decimal>(NumericUpDown.IncrementProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.NumericUpDown" /> is Initializing.
    /// </summary>
    /// <value><c>true</c> if Initializing; otherwise, <c>false</c>.</value>
    private bool Initializing
    {
      get => this.GetState(Component.ComponentState.Initializing);
      set => this.SetState(Component.ComponentState.Initializing, value);
    }

    /// <summary>Gets or sets the Maximum value for the spin box (also known as an up-down control).</summary>
    /// <returns>The Maximum value for the spin box. The default value is 100.</returns>
    /// <filterpriority>1</filterpriority>
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("NumericUpDownMaximumDescr")]
    [SRCategory("CatData")]
    public Decimal Maximum
    {
      get => this.GetValue<Decimal>(NumericUpDown.MaximumProperty);
      set
      {
        if (!this.SetValue<Decimal>(NumericUpDown.MaximumProperty, value))
          return;
        if (this.Minimum > value)
          this.Minimum = this.Maximum;
        this.Value = this.Constrain(this.CurrentValue);
        this.Update();
      }
    }

    /// <summary>Gets or sets the Minimum allowed value for the spin box (also known as an up-down control).</summary>
    /// <returns>The Minimum allowed value for the spin box. The default value is 0.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("NumericUpDownMinimumDescr")]
    public Decimal Minimum
    {
      get => this.GetValue<Decimal>(NumericUpDown.MinimumProperty);
      set
      {
        if (!this.SetValue<Decimal>(NumericUpDown.MinimumProperty, value))
          return;
        if (value > this.Maximum)
          this.Maximum = value;
        this.Value = this.Constrain(this.CurrentValue);
        this.Update();
      }
    }

    /// <summary>Gets the on value changed.</summary>
    /// <value>The on value changed.</value>
    private EventHandler ValueChangedHandler => (EventHandler) this.GetHandler(NumericUpDown.ValueChangedEvent);

    /// <summary>
    /// Gets or sets the space between the edges of
    /// a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see>
    /// control and its contents.</summary>
    /// <returns><see cref="F:Gizmox.WebGui.Forms.Padding.Empty"></see> in all cases.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Gets or sets the text to be displayed in
    /// the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see>
    /// control.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [Bindable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets a value indicating whether a thousands separator is displayed in the spin box (also known as an up-down control) when appropriate.</summary>
    /// <returns>true if a thousands separator is displayed in the spin box when appropriate; otherwise, false. The default value is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatData")]
    [System.ComponentModel.DefaultValue(false)]
    [Localizable(true)]
    [SRDescription("NumericUpDownThousandsSeparatorDescr")]
    public bool ThousandsSeparator
    {
      get => this.GetValue<bool>(NumericUpDown.ThousandsSeparatorProperty);
      set
      {
        if (!this.SetValue<bool>(NumericUpDown.ThousandsSeparatorProperty, value))
          return;
        this.UpdateEditText();
        this.Update();
      }
    }

    /// <summary>Gets or sets the value assigned to the spin box (also known as an up-down control).</summary>
    /// <returns>The numeric value of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Minimum"></see> property value.-or- The assigned value is greater than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Maximum"></see> property value. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Bindable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("NumericUpDownValueDescr")]
    public Decimal Value
    {
      get => this.InternalValue;
      set
      {
        if (!(this.CurrentValue != value))
          return;
        this.InternalValue = value;
        this.Update();
      }
    }

    private Decimal InternalValue
    {
      get
      {
        if (this.UserEdit)
          this.ValidateEditText();
        return this.CurrentValue;
      }
      set
      {
        if (!(value != this.CurrentValue))
          return;
        if (!this.Initializing && (value < this.Minimum || value > this.Maximum))
          throw new ArgumentOutOfRangeException("Value", SR.GetString("InvalidBoundArgument", (object) "Value", (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "'Minimum'", (object) "'Maximum'"));
        this.CurrentValueInternal = value;
        this.OnValueChanged(EventArgs.Empty);
        this.CurrentValueChangedInternal = true;
        this.UpdateEditText();
      }
    }

    /// <summary>Gets a collection of sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> containing the sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NumericUpDownAccelerationCollection Accelerations
    {
      get
      {
        if (this.mobjAccelerations == null)
          this.mobjAccelerations = new NumericUpDownAccelerationCollection();
        return this.mobjAccelerations;
      }
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Padding"></see> property changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler PaddingChanged
    {
      add => base.PaddingChanged += value;
      remove => base.PaddingChanged -= value;
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Text"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property has been changed in some way.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("NumericUpDownOnValueChangedDescr")]
    [SRCategory("CatAction")]
    public event EventHandler ValueChanged
    {
      add => this.AddCriticalHandler(NumericUpDown.ValueChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(NumericUpDown.ValueChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
    /// </summary>
    [SRDescription("NumericUpDownOnValueChangedDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientValueChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Begins the initialization of a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control that is used on a form or used by another component. The initialization occurs at run time.</summary>
    /// <filterpriority>1</filterpriority>
    public void BeginInit() => this.Initializing = true;

    /// <summary>Decrements the value of the spin box (also known as an up-down control).</summary>
    /// <filterpriority>1</filterpriority>
    public override void DownButton()
    {
      if (this.UserEdit)
        this.ParseEditText();
      Decimal currentValue = this.CurrentValue;
      Decimal num;
      try
      {
        num = currentValue - this.Increment;
        if (num < this.Minimum)
          num = this.Minimum;
      }
      catch (OverflowException ex)
      {
        num = this.Minimum;
      }
      this.Value = num;
    }

    /// <summary>Ends the initialization of a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control that is used on a form or used by another component. The initialization occurs at run time.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void EndInit()
    {
      this.Initializing = false;
      this.Value = this.Constrain(this.CurrentValue);
      this.UpdateEditText();
    }

    /// <summary>Returns a string that represents the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control.</summary>
    /// <returns>A string that represents the current <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see>. </returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => base.ToString() + ", Minimum = " + this.Minimum.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", Maximum = " + this.Maximum.ToString((IFormatProvider) CultureInfo.CurrentCulture);

    /// <summary>Increments the value of the spin box (also known as an up-down control).</summary>
    /// <filterpriority>1</filterpriority>
    public override void UpButton()
    {
      if (this.UserEdit)
        this.ParseEditText();
      Decimal currentValue = this.CurrentValue;
      Decimal num;
      try
      {
        num = currentValue + this.Increment;
        if (num > this.Maximum)
          num = this.Maximum;
      }
      catch (OverflowException ex)
      {
        num = this.Maximum;
      }
      this.Value = num;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>Raises the <see cref="E:Gizmox.WebGui.Forms.NumericUpDown.ValueChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnValueChanged(EventArgs e)
    {
      EventHandler valueChangedHandler = this.ValueChangedHandler;
      if (valueChangedHandler == null)
        return;
      valueChangedHandler((object) this, e);
    }

    /// <summary>Converts the text displayed in the spin box (also known as an up-down control) to a numeric value and evaluates it.</summary>
    protected void ParseEditText()
    {
      try
      {
        if (string.IsNullOrEmpty(this.Text) || this.Text.Length == 1 && !(this.Text != "-"))
          return;
        if (this.Hexadecimal)
          this.Value = this.Constrain(Convert.ToDecimal(Convert.ToInt32(this.Text, 16)));
        else
          this.Value = this.Constrain(Decimal.Parse(this.Text, (IFormatProvider) CultureInfo.InvariantCulture));
      }
      catch
      {
      }
      finally
      {
        this.UserEdit = false;
      }
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("VLB", this.CurrentValue.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("TX", this.GetNumberText(this.CurrentValue));
      Decimal num;
      if (this.Maximum != NumericUpDown.DefaultMaximum)
      {
        IAttributeWriter attributeWriter = objWriter;
        num = this.Maximum;
        string strValue = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        attributeWriter.WriteAttributeString("MAX", strValue);
      }
      if (this.Minimum != NumericUpDown.DefaultMinimum)
      {
        IAttributeWriter attributeWriter = objWriter;
        num = this.Minimum;
        string strValue = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        attributeWriter.WriteAttributeString("MIN", strValue);
      }
      if (this.DecimalPlaces != 0)
        objWriter.WriteAttributeString("DPL", this.DecimalPlaces.ToString());
      if (this.Increment != NumericUpDown.DefaultIncrement)
      {
        IAttributeWriter attributeWriter = objWriter;
        num = this.Increment;
        string strValue = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        attributeWriter.WriteAttributeString("INC", strValue);
      }
      if (!this.ThousandsSeparator)
        return;
      objWriter.WriteAttributeString("TSS", "1");
    }

    /// <summary>Sets up down value.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
    protected override void SetUpDownValue(string strValue, bool blnIsIndex)
    {
      Decimal result;
      if (string.IsNullOrEmpty(strValue) || !Decimal.TryParse(strValue, NumberStyles.Number, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return;
      this.UserEdit = false;
      this.InternalValue = result;
    }

    /// <summary>
    /// Displays the current value of the spin box (also known as an up-down control)
    /// in the appropriate format.
    /// </summary>
    protected override void UpdateEditText()
    {
      if (this.Initializing)
        return;
      if (this.UserEdit)
        this.ParseEditText();
      if (!this.CurrentValueChanged && (string.IsNullOrEmpty(this.Text) || this.Text.Length == 1 && !(this.Text != "-")))
        return;
      this.CurrentValueChangedInternal = false;
      this.ChangingText = true;
      this.SetTextInternal(this.GetNumberText(this.CurrentValue));
    }

    /// <summary>
    /// Validates and updates the text displayed in the spin
    /// box (also known as an up-down control).
    /// </summary>
    protected override void ValidateEditText()
    {
      this.ParseEditText();
      this.UpdateEditText();
    }

    /// <summary>Constrains the specified value.</summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private Decimal Constrain(Decimal value)
    {
      if (value < this.Minimum)
        value = this.Minimum;
      if (value > this.Maximum)
        value = this.Maximum;
      return value;
    }

    /// <summary>Gets the number text.</summary>
    /// <param name="decNum">The num.</param>
    /// <returns></returns>
    private string GetNumberText(Decimal decNum)
    {
      if (this.Hexadecimal)
        return ((long) decNum).ToString("X", (IFormatProvider) CultureInfo.InvariantCulture);
      CultureInfo provider = CultureInfo.CurrentCulture;
      if (this.Context != null)
        provider = this.Context.CurrentUICulture;
      return decNum.ToString((this.ThousandsSeparator ? "N" : "F") + this.DecimalPlaces.ToString((IFormatProvider) provider), (IFormatProvider) provider);
    }

    /// <summary>Resets the increment.</summary>
    private void ResetIncrement() => this.Increment = NumericUpDown.DefaultIncrement;

    /// <summary>Resets the maximum.</summary>
    private void ResetMaximum() => this.Maximum = NumericUpDown.DefaultMaximum;

    /// <summary>Resets the minimum.</summary>
    private void ResetMinimum() => this.Minimum = NumericUpDown.DefaultMinimum;

    /// <summary>Resets the value.</summary>
    private void ResetValue() => this.Value = NumericUpDown.DefaultValue;

    /// <summary>Shoulds the serialize increment.</summary>
    /// <returns></returns>
    private bool ShouldSerializeIncrement() => !this.Increment.Equals(NumericUpDown.DefaultIncrement);

    /// <summary>Shoulds the serialize maximum.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMaximum() => !this.Maximum.Equals(NumericUpDown.DefaultMaximum);

    /// <summary>Shoulds the serialize minimum.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMinimum() => !this.Minimum.Equals(NumericUpDown.DefaultMinimum);

    /// <summary>Shoulds the serialize value.</summary>
    /// <returns></returns>
    private bool ShouldSerializeValue() => !this.Value.Equals(0M);
  }
}
