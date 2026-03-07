#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents a Windows spin box (also known as an up-down control) that displays numeric values.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(NumericUpDown), "NumericUpDown_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(NumericUpDown), "NumericUpDown.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [SRDescription("DescriptionNumericUpDown"), DefaultProperty("Value"), DefaultEvent("ValueChanged")]
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.NumericUpDown)]
    [Skin(typeof(NumericUpDownSkin))]
    public class NumericUpDown : UpDownBase, ISupportInitialize
    {
        #region Fields

        private static readonly decimal DefaultIncrement = 1M;

        private static readonly decimal DefaultMaximum = 100M;

        private static readonly decimal DefaultMinimum = 0M;

        private const bool DefaultThousandsSeparator = false;

        private static readonly decimal DefaultValue = 0M;

        private const int InvalidValue = -1;

        private NumericUpDownAccelerationCollection mobjAccelerations;

        /// <summary>
        /// The CurrentValueChanged Property registration.
        /// </summary>        
        private static readonly SerializableProperty CurrentValueChangedProperty = SerializableProperty.Register("CurrentValueChanged", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The CurrentValue Property registration.
        /// </summary>        
        private static readonly SerializableProperty CurrentValueProperty = SerializableProperty.Register("CurrentValue", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultValue));

        /// <summary>
        /// The accelerationsCurrentIndex Property registration.
        /// </summary>        
        private static readonly SerializableProperty DecimalPlacesProperty = SerializableProperty.Register("DecimalPlaces", typeof(int), typeof(NumericUpDown), new SerializablePropertyMetadata(0));

        /// <summary>
        /// The Hexadecimal Property registration.
        /// </summary>        
        private static readonly SerializableProperty HexadecimalProperty = SerializableProperty.Register("Hexadecimal", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The Increment Property registration.
        /// </summary>        
        private static SerializableProperty IncrementProperty = SerializableProperty.Register("Increment", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultIncrement));

        /// <summary>
        /// The Maximum Property registration.
        /// </summary>        
        private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(NumericUpDown.DefaultMaximum));

        /// <summary>
        /// The Minimum Property registration.
        /// </summary>        
        private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(NumericUpDown.DefaultMinimum));

        /// <summary>
        /// The SelectedItemChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(NumericUpDown));

        /// <summary>
        /// The ThousandsSeparator Property registration.
        /// </summary>        
        private static SerializableProperty ThousandsSeparatorProperty = SerializableProperty.Register("ThousandsSeparator", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));

        #endregion

        #region  Constructors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> class.</summary>
        public NumericUpDown()
        {
            this.Text = "0";

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current value property.
        /// </summary>
        /// <value>The current value property.</value>
        public decimal CurrentValue
        {
            get
            {
                return this.CurrentValueInternal;
            }
            set
            {
                if (this.CurrentValue != value)
                {
                    this.CurrentValueInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the current value internal.
        /// </summary>
        /// <value>The current value internal.</value>
        private decimal CurrentValueInternal
        {
            get
            {
                return this.GetValue<decimal>(NumericUpDown.CurrentValueProperty);
            }
            set
            {
                this.SetValue<decimal>(NumericUpDown.CurrentValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [current value changed].
        /// </summary>
        /// <value><c>true</c> if [current value changed]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CurrentValueChanged
        {
            get
            {
                return this.GetValue<bool>(NumericUpDown.CurrentValueChangedProperty);
            }
            set
            {
                //Set internal property 
                this.CurrentValueChangedInternal = value;

                // Rerender control.
                this.Update();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [current value changed].
        /// </summary>
        /// <value><c>true</c> if [current value changed]; otherwise, <c>false</c>.</value>
        protected bool CurrentValueChangedInternal
        {
            get
            {
                return this.GetValue<bool>(NumericUpDown.CurrentValueChangedProperty);
            }
            set
            {
                this.SetValue<bool>(NumericUpDown.CurrentValueChangedProperty, value);
            }
        }

        /// <summary>
        /// Resets the CurrentValue
        /// </summary>
        private void ResetCurrentValue()
        {
            this.CurrentValue = DefaultValue;
        }

        /// <summary>
        /// Gets or sets the number of decimal places to display in the spin box (also known as an up-down control).
        /// </summary>
        /// <value>The decimal places.</value>
        /// <returns>The number of decimal places to display in the spin box. The default is 0.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value assigned is less than 0.-or- The value assigned is greater than 99. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [SRDescription("NumericUpDownDecimalPlacesDescr"), SRCategory("CatData"), DefaultValue(0)]
        public int DecimalPlaces
        {
            get
            {
                return this.GetValue<int>(NumericUpDown.DecimalPlacesProperty);
            }
            set
            {
                if ((value < 0) || (value > 0x63))
                {
                    object[] arrArgs = new object[] { "DecimalPlaces", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture), "99" };
                    throw new ArgumentOutOfRangeException("DecimalPlaces", SR.GetString("InvalidBoundArgument", arrArgs));
                }

                if (this.SetValue<int>(NumericUpDown.DecimalPlacesProperty, value))
                {
                    this.UpdateEditText();

                    // Rerender control.
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the spin box (also known as an up-down control) should display the value it contains in Hexadecimal format.</summary>
        /// <returns>true if the spin box should display its value in Hexadecimal format; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("NumericUpDownHexadecimalDescr"), SRCategory("CatAppearance"), DefaultValue(false)]
        public bool Hexadecimal
        {
            get
            {
                return this.GetValue<bool>(NumericUpDown.HexadecimalProperty);
            }
            set
            {
                if (this.SetValue<bool>(NumericUpDown.HexadecimalProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the value to Increment or decrement the spin box (also known as an up-down control) when the up or down buttons are clicked.</summary>
        /// <returns>The value to Increment or decrement the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property when the up or down buttons are clicked on the spin box. The default value is 1.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is not a positive number. </exception>
        /// <filterpriority>1</filterpriority>
        [SRDescription("NumericUpDownIncrementDescr"), SRCategory("CatData")]
        public decimal Increment
        {
            get
            {
                return this.GetValue<decimal>(NumericUpDown.IncrementProperty);
            }
            set
            {
                if (value < 0M)
                {
                    throw new ArgumentOutOfRangeException("Increment", SR.GetString("InvalidArgument", new object[] { "Increment", value.ToString(CultureInfo.CurrentCulture) }));
                }

                if (this.SetValue<decimal>(NumericUpDown.IncrementProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NumericUpDown"/> is Initializing.
        /// </summary>
        /// <value><c>true</c> if Initializing; otherwise, <c>false</c>.</value>
        private bool Initializing
        {
            get
            {
                return this.GetState(ComponentState.Initializing);
            }
            set
            {
                this.SetState(ComponentState.Initializing, value);
            }
        }

        /// <summary>Gets or sets the Maximum value for the spin box (also known as an up-down control).</summary>
        /// <returns>The Maximum value for the spin box. The default value is 100.</returns>
        /// <filterpriority>1</filterpriority>
        [RefreshProperties(RefreshProperties.All), SRDescription("NumericUpDownMaximumDescr"), SRCategory("CatData")]
        public decimal Maximum
        {
            get
            {
                return this.GetValue<decimal>(NumericUpDown.MaximumProperty);
            }
            set
            {
                if (this.SetValue<decimal>(NumericUpDown.MaximumProperty, value))
                {
                    if (this.Minimum > value)
                    {
                        this.Minimum = this.Maximum;
                    }
                    this.Value = this.Constrain(this.CurrentValue);

                    // Rerender control.
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the Minimum allowed value for the spin box (also known as an up-down control).</summary>
        /// <returns>The Minimum allowed value for the spin box. The default value is 0.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatData"), RefreshProperties(RefreshProperties.All), SRDescription("NumericUpDownMinimumDescr")]
        public decimal Minimum
        {
            get
            {
                return this.GetValue<decimal>(NumericUpDown.MinimumProperty);
            }
            set
            {
                if (this.SetValue<decimal>(NumericUpDown.MinimumProperty, value))
                {

                    if (value > this.Maximum)
                    {
                        this.Maximum = value;
                    }

                    this.Value = this.Constrain(this.CurrentValue);

                    // Rerender control.
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the on value changed.
        /// </summary>
        /// <value>The on value changed.</value>
        private EventHandler ValueChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(NumericUpDown.ValueChangedEvent);
            }
        }

        /// <summary>
        /// Gets or sets the space between the edges of 
        /// a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> 
        /// control and its contents.</summary>
        /// <returns><see cref="F:Gizmox.WebGui.Forms.Padding.Empty"></see> in all cases.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        /// <summary>
        /// Gets or sets the text to be displayed in 
        /// the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> 
        /// control.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), Bindable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether a thousands separator is displayed in the spin box (also known as an up-down control) when appropriate.</summary>
        /// <returns>true if a thousands separator is displayed in the spin box when appropriate; otherwise, false. The default value is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatData"), DefaultValue(false), Localizable(true), SRDescription("NumericUpDownThousandsSeparatorDescr")]
        public bool ThousandsSeparator
        {
            get
            {
                return this.GetValue<bool>(NumericUpDown.ThousandsSeparatorProperty);
            }
            set
            {
                if (this.SetValue<bool>(NumericUpDown.ThousandsSeparatorProperty, value))
                {
                    this.UpdateEditText();

                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the value assigned to the spin box (also known as an up-down control).</summary>
        /// <returns>The numeric value of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Minimum"></see> property value.-or- The assigned value is greater than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Maximum"></see> property value. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Bindable(true), SRCategory("CatAppearance"), SRDescription("NumericUpDownValueDescr")]
        public decimal Value
        {
            get
            {
                return this.InternalValue;
            }
            set
            {
                if (this.CurrentValue != value)
                {
                    this.InternalValue = value;
                    this.Update();
                }
            }
        }

        private decimal InternalValue
        {
            get
            {
                if (base.UserEdit)
                {
                    this.ValidateEditText();
                }
                return this.CurrentValue;
            }
            set
            {
                if (value != this.CurrentValue)
                {
                    if (!this.Initializing && ((value < this.Minimum) || (value > this.Maximum)))
                    {
                        throw new ArgumentOutOfRangeException("Value", SR.GetString("InvalidBoundArgument", new object[] { "Value", value.ToString(CultureInfo.CurrentCulture), "'Minimum'", "'Maximum'" }));
                    }
                    this.CurrentValueInternal = value;
                    this.OnValueChanged(EventArgs.Empty);
                    this.CurrentValueChangedInternal = true;
                    this.UpdateEditText();
                }
            }
        }

        /// <summary>Gets a collection of sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> containing the sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public NumericUpDownAccelerationCollection Accelerations
        {
            get
            {
                if (this.mobjAccelerations == null)
                {
                    this.mobjAccelerations = new NumericUpDownAccelerationCollection();
                }
                return this.mobjAccelerations;
            }

        }




        #endregion

        #region  Delegates and Events

        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Padding"></see> property changes.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler PaddingChanged
        {
            add
            {
                base.PaddingChanged += value;
            }
            remove
            {
                base.PaddingChanged -= value;
            }
        }

        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Text"></see> property changes.</summary>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        /// <summary>Occurs when the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property has been changed in some way.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("NumericUpDownOnValueChangedDescr"), SRCategory("CatAction")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.AddCriticalHandler(NumericUpDown.ValueChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(NumericUpDown.ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
        /// </summary>
        [SRDescription("NumericUpDownOnValueChangedDescr"), Category("Client")]
        public event ClientEventHandler ClientValueChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        #endregion

        #region Methods

        /// <summary>Begins the initialization of a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control that is used on a form or used by another component. The initialization occurs at run time.</summary>
        /// <filterpriority>1</filterpriority>
        public void BeginInit()
        {
            this.Initializing = true;
        }

        /// <summary>Decrements the value of the spin box (also known as an up-down control).</summary>
        /// <filterpriority>1</filterpriority>
        public override void DownButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            decimal CurrentValue = this.CurrentValue;
            try
            {
                CurrentValue -= this.Increment;
                if (CurrentValue < this.Minimum)
                {
                    CurrentValue = this.Minimum;
                }
            }
            catch (OverflowException)
            {
                CurrentValue = this.Minimum;
            }
            this.Value = CurrentValue;
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
        public override string ToString()
        {
            string str2 = base.ToString();
            return (str2 + ", Minimum = " + this.Minimum.ToString(CultureInfo.CurrentCulture) + ", Maximum = " + this.Maximum.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>Increments the value of the spin box (also known as an up-down control).</summary>
        /// <filterpriority>1</filterpriority>
        public override void UpButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            decimal CurrentValue = this.CurrentValue;
            try
            {
                CurrentValue += this.Increment;
                if (CurrentValue > this.Maximum)
                {
                    CurrentValue = this.Maximum;
                }
            }
            catch (OverflowException)
            {
                CurrentValue = this.Maximum;
            }
            this.Value = CurrentValue;
        }

        // Protected Methods 

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (ValueChangedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGui.Forms.NumericUpDown.ValueChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ValueChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Converts the text displayed in the spin box (also known as an up-down control) to a numeric value and evaluates it.</summary>
        protected void ParseEditText()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Text) && ((this.Text.Length != 1) || (this.Text != "-")))
                {
                    if (this.Hexadecimal)
                    {
                        this.Value = this.Constrain(Convert.ToDecimal(Convert.ToInt32(this.Text, 0x10)));
                    }
                    else
                    {
                        this.Value = this.Constrain(decimal.Parse(this.Text, CultureInfo.InvariantCulture));
                    }
                }
            }
            catch
            {
            }
            finally
            {
                base.UserEdit = false;
            }
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render value attribute.
            objWriter.WriteAttributeString(WGAttributes.Value, this.CurrentValue.ToString(CultureInfo.InvariantCulture));

            // Render Text attribute.
            objWriter.WriteAttributeString(WGAttributes.Text, this.GetNumberText(this.CurrentValue));

            // Render maximum attribute if it is different from default value.
            if (this.Maximum != NumericUpDown.DefaultMaximum)
            {
                objWriter.WriteAttributeString(WGAttributes.Maximum, this.Maximum.ToString(CultureInfo.InvariantCulture));
            }

            // Render minimum attribute if it is different from default value.
            if (this.Minimum != NumericUpDown.DefaultMinimum)
            {
                objWriter.WriteAttributeString(WGAttributes.Minimum, this.Minimum.ToString(CultureInfo.InvariantCulture));
            }

            // Render decimal places attribute if it is different from default value.
            if (this.DecimalPlaces != 0)
            {
                objWriter.WriteAttributeString(WGAttributes.DecimalPlaces, this.DecimalPlaces.ToString());
            }

            // Render increment attribute if it is different from default value.
            if (this.Increment != NumericUpDown.DefaultIncrement)
            {
                objWriter.WriteAttributeString(WGAttributes.Increment, this.Increment.ToString(CultureInfo.InvariantCulture));
            }

            // Render the thousands separator attribute.
            if (this.ThousandsSeparator)
            {
                // Render the thousands separator attribute.
                objWriter.WriteAttributeString(WGAttributes.ThousandsSeparator, "1");
            }
        }

        /// <summary>
        /// Sets up down value.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
        protected override void SetUpDownValue(string strValue, bool blnIsIndex)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                // Define empty decimal value.
                decimal decValue;

                // Try parse decimal value.
                if (decimal.TryParse(strValue, NumberStyles.Number, CultureInfo.InvariantCulture, out decValue))
                {
                    // Flag in order to eliminate parsing in vale reading.
                    this.UserEdit = false;

                    //set the value
                    this.InternalValue = decValue;
                }
            }
        }

        /// <summary>
        /// Displays the current value of the spin box (also known as an up-down control) 
        /// in the appropriate format.
        /// </summary>
        protected override void UpdateEditText()
        {
            if (!this.Initializing)
            {
                if (base.UserEdit)
                {
                    this.ParseEditText();
                }
                if (this.CurrentValueChanged || (!string.IsNullOrEmpty(this.Text) && ((this.Text.Length != 1) || (this.Text != "-"))))
                {
                    this.CurrentValueChangedInternal = false;
                    base.ChangingText = true;
                    this.SetTextInternal(this.GetNumberText(this.CurrentValue));
                }
            }
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

        /// <summary>
        /// Constrains the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private decimal Constrain(decimal value)
        {
            if (value < this.Minimum)
            {
                value = this.Minimum;
            }
            if (value > this.Maximum)
            {
                value = this.Maximum;
            }
            return value;
        }

        /// <summary>
        /// Gets the number text.
        /// </summary>
        /// <param name="decNum">The num.</param>
        /// <returns></returns>
        private string GetNumberText(decimal decNum)
        {
            if (this.Hexadecimal)
            {
                long num2 = (long)decNum;
                return num2.ToString("X", CultureInfo.InvariantCulture);
            }

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            if (this.Context != null)
            {
                objCultureInfo = this.Context.CurrentUICulture;
            }

            return decNum.ToString((this.ThousandsSeparator ? "N" : "F") + this.DecimalPlaces.ToString(objCultureInfo), objCultureInfo);
        }

        /// <summary>
        /// Resets the increment.
        /// </summary>
        private void ResetIncrement()
        {
            this.Increment = DefaultIncrement;
        }

        /// <summary>
        /// Resets the maximum.
        /// </summary>
        private void ResetMaximum()
        {
            this.Maximum = DefaultMaximum;
        }

        /// <summary>
        /// Resets the minimum.
        /// </summary>
        private void ResetMinimum()
        {
            this.Minimum = DefaultMinimum;
        }

        /// <summary>
        /// Resets the value.
        /// </summary>
        private void ResetValue()
        {
            this.Value = DefaultValue;
        }

        /// <summary>
        /// Shoulds the serialize increment.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeIncrement()
        {
            return !this.Increment.Equals(DefaultIncrement);
        }

        /// <summary>
        /// Shoulds the serialize maximum.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMaximum()
        {
            return !this.Maximum.Equals(DefaultMaximum);
        }

        /// <summary>
        /// Shoulds the serialize minimum.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMinimum()
        {
            return !this.Minimum.Equals(DefaultMinimum);
        }

        /// <summary>
        /// Shoulds the serialize value.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeValue()
        {
            return !this.Value.Equals(0);
        }

        #endregion
    }

    /// <summary>Represents a sorted collection of <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> objects in the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [ListBindable(false)]
    [Serializable()]
    public class NumericUpDownAccelerationCollection : MarshalByRefObject, ICollection<NumericUpDownAcceleration>, IEnumerable<NumericUpDownAcceleration>, IEnumerable
    {

        /// <summary>Adds a new <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
        /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to add to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
        /// <exception cref="T:System.ArgumentNullException">acceleration is null.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Add(NumericUpDownAcceleration acceleration)
        {
        }

        /// <summary>Adds the elements of the specified array to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>, keeping the collection sorted.</summary>
        /// <param name="accelerations">An array of type <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>  containing the objects to add to the collection.</param>
        /// <exception cref="T:System.ArgumentNullException">accelerations is null, or one of the entries in the accelerations array is null.</exception>
        public void AddRange(params NumericUpDownAcceleration[] accelerations)
        {
        }

        /// <summary>Removes all elements from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Clear()
        {
        }

        /// <summary>Determines whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> contains a specific <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is found in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
        /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to locate in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Contains(NumericUpDownAcceleration acceleration)
        {
            return false;
        }

        /// <summary>Copies the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> values to a one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> instance at the specified index.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> that is the destination of the values copied from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>. </param>
        /// <param name="index">The index in array where copying begins.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void CopyTo(NumericUpDownAcceleration[] array, int index)
        {
        }

        /// <summary>Removes the first occurrence of the specified <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
        /// <returns>true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is removed from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
        /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to remove from the collection.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Remove(NumericUpDownAcceleration acceleration)
        {
            return false;
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IEnumerator<NumericUpDownAcceleration> IEnumerable<NumericUpDownAcceleration>.GetEnumerator()
        {
            return null;
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }

        /// <summary>Gets the number of objects in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
        /// <returns>The number of objects in the collection.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int Count
        {
            get
            {
                return 0;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> is read-only.</summary>
        /// <returns>true if the collectionms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.1033/cpref/html/frlrfsystemcollectionsilistclasstopic.htm is read-only; otherwise, false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> at the specified index number.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> with the specified index.</returns>
        /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to get from the collection.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public NumericUpDownAcceleration this[int index]
        {
            get
            {
                return null;
            }
        }
    }

    /// <summary>Provides information specifying how acceleration should be performed on a spin box (also known as an up-down control) when the up or down button is pressed for specified time period.</summary>
    public class NumericUpDownAcceleration
    {

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> class.</summary>
        /// <param name="seconds">The number of seconds the up or down button is pressed before the acceleration starts. </param>
        /// <param name="increment">The quantity the value displayed in the control should be incremented or decremented during acceleration.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">seconds or increment is less than 0.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        public NumericUpDownAcceleration(int seconds, decimal increment)
        {
        }

        /// <summary>Gets or sets the quantity to increment or decrement the displayed value during acceleration.</summary>
        /// <returns>The quantity to increment or decrement the displayed value during acceleration.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than 0.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public decimal Increment
        {
            get
            {
                return 0;
            }
            set
            { }
        }

        /// <summary>Gets or sets the number of seconds the up or down button must be pressed before the acceleration starts.</summary>
        /// <returns>Gets or sets the number of seconds the up or down button must be pressed before the acceleration starts.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than 0.</exception>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int Seconds
        {
            get
            {
                return 0;
            }
            set
            { }
        }
    }


}

