#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	/// Represents a Windows spin box (also known as an up-down control) that displays numeric values.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(NumericUpDown), "NumericUpDown_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.NumericUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.NumericUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[SRDescription("DescriptionNumericUpDown")]
	[DefaultProperty("Value")]
	[DefaultEvent("ValueChanged")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("NUD")]
	[Skin(typeof(NumericUpDownSkin))]
	public class NumericUpDown : UpDownBase, ISupportInitialize
	{
		private static readonly decimal DefaultIncrement = 1m;

		private static readonly decimal DefaultMaximum = 100m;

		private static readonly decimal DefaultMinimum = default(decimal);

		private const bool DefaultThousandsSeparator = false;

		private static readonly decimal DefaultValue = default(decimal);

		private const int InvalidValue = -1;

		private NumericUpDownAccelerationCollection mobjAccelerations;

		/// 
		/// The CurrentValueChanged Property registration.
		/// </summary>        
		private static readonly SerializableProperty CurrentValueChangedProperty = SerializableProperty.Register("CurrentValueChanged", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));

		/// 
		/// The CurrentValue Property registration.
		/// </summary>        
		private static readonly SerializableProperty CurrentValueProperty = SerializableProperty.Register("CurrentValue", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultValue));

		/// 
		/// The accelerationsCurrentIndex Property registration.
		/// </summary>        
		private static readonly SerializableProperty DecimalPlacesProperty = SerializableProperty.Register("DecimalPlaces", typeof(int), typeof(NumericUpDown), new SerializablePropertyMetadata(0));

		/// 
		/// The Hexadecimal Property registration.
		/// </summary>        
		private static readonly SerializableProperty HexadecimalProperty = SerializableProperty.Register("Hexadecimal", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));

		/// 
		/// The Increment Property registration.
		/// </summary>        
		private static SerializableProperty IncrementProperty = SerializableProperty.Register("Increment", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultIncrement));

		/// 
		/// The Maximum Property registration.
		/// </summary>        
		private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultMaximum));

		/// 
		/// The Minimum Property registration.
		/// </summary>        
		private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(decimal), typeof(NumericUpDown), new SerializablePropertyMetadata(DefaultMinimum));

		/// 
		/// The SelectedItemChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ValueChangedEvent;

		/// 
		/// The ThousandsSeparator Property registration.
		/// </summary>        
		private static SerializableProperty ThousandsSeparatorProperty;

		/// 
		/// Gets or sets the current value property.
		/// </summary>
		/// The current value property.</value>
		public decimal CurrentValue
		{
			get
			{
				return CurrentValueInternal;
			}
			set
			{
				if (CurrentValue != value)
				{
					CurrentValueInternal = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the current value internal.
		/// </summary>
		/// The current value internal.</value>
		private decimal CurrentValueInternal
		{
			get
			{
				return GetValue(CurrentValueProperty);
			}
			set
			{
				SetValue(CurrentValueProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [current value changed].
		/// </summary>
		/// true</c> if [current value changed]; otherwise, false</c>.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CurrentValueChanged
		{
			get
			{
				return GetValue(CurrentValueChangedProperty);
			}
			set
			{
				CurrentValueChangedInternal = value;
				Update();
			}
		}

		/// 
		/// Gets or sets a value indicating whether [current value changed].
		/// </summary>
		/// true</c> if [current value changed]; otherwise, false</c>.</value>
		protected bool CurrentValueChangedInternal
		{
			get
			{
				return GetValue(CurrentValueChangedProperty);
			}
			set
			{
				SetValue(CurrentValueChangedProperty, value);
			}
		}

		/// 
		/// Gets or sets the number of decimal places to display in the spin box (also known as an up-down control).
		/// </summary>
		/// The decimal places.</value>
		/// The number of decimal places to display in the spin box. The default is 0.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value assigned is less than 0.-or- The value assigned is greater than 99. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("NumericUpDownDecimalPlacesDescr")]
		[SRCategory("CatData")]
		[DefaultValue(0)]
		public int DecimalPlaces
		{
			get
			{
				return GetValue(DecimalPlacesProperty);
			}
			set
			{
				if (value < 0 || value > 99)
				{
					object[] arrArgs = new object[4]
					{
						"DecimalPlaces",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture),
						"99"
					};
					throw new ArgumentOutOfRangeException("DecimalPlaces", SR.GetString("InvalidBoundArgument", arrArgs));
				}
				if (SetValue(DecimalPlacesProperty, value))
				{
					UpdateEditText();
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the spin box (also known as an up-down control) should display the value it contains in Hexadecimal format.</summary>
		/// true if the spin box should display its value in Hexadecimal format; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("NumericUpDownHexadecimalDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(false)]
		public bool Hexadecimal
		{
			get
			{
				return GetValue(HexadecimalProperty);
			}
			set
			{
				if (SetValue(HexadecimalProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the value to Increment or decrement the spin box (also known as an up-down control) when the up or down buttons are clicked.</summary>
		/// The value to Increment or decrement the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property when the up or down buttons are clicked on the spin box. The default value is 1.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is not a positive number. </exception>
		/// 1</filterpriority>
		[SRDescription("NumericUpDownIncrementDescr")]
		[SRCategory("CatData")]
		public decimal Increment
		{
			get
			{
				return GetValue(IncrementProperty);
			}
			set
			{
				if (value < 0m)
				{
					throw new ArgumentOutOfRangeException("Increment", SR.GetString("InvalidArgument", "Increment", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(IncrementProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.NumericUpDown" /> is Initializing.
		/// </summary>
		/// true</c> if Initializing; otherwise, false</c>.</value>
		private bool Initializing
		{
			get
			{
				return GetState(ComponentState.Initializing);
			}
			set
			{
				SetState(ComponentState.Initializing, value);
			}
		}

		/// Gets or sets the Maximum value for the spin box (also known as an up-down control).</summary>
		/// The Maximum value for the spin box. The default value is 100.</returns>
		/// 1</filterpriority>
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("NumericUpDownMaximumDescr")]
		[SRCategory("CatData")]
		public decimal Maximum
		{
			get
			{
				return GetValue(MaximumProperty);
			}
			set
			{
				if (SetValue(MaximumProperty, value))
				{
					if (Minimum > value)
					{
						Minimum = Maximum;
					}
					Value = Constrain(CurrentValue);
					Update();
				}
			}
		}

		/// Gets or sets the Minimum allowed value for the spin box (also known as an up-down control).</summary>
		/// The Minimum allowed value for the spin box. The default value is 0.</returns>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("NumericUpDownMinimumDescr")]
		public decimal Minimum
		{
			get
			{
				return GetValue(MinimumProperty);
			}
			set
			{
				if (SetValue(MinimumProperty, value))
				{
					if (value > Maximum)
					{
						Maximum = value;
					}
					Value = Constrain(CurrentValue);
					Update();
				}
			}
		}

		/// 
		/// Gets the on value changed.
		/// </summary>
		/// The on value changed.</value>
		private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChanged);

		/// 
		/// Gets or sets the space between the edges of 
		/// a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> 
		/// control and its contents.</summary>
		/// <see cref="F:Gizmox.WebGui.Forms.Padding.Empty"></see> in all cases.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Padding Padding
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

		/// 
		/// Gets or sets the text to be displayed in 
		/// the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> 
		/// control.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[Bindable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		/// Gets or sets a value indicating whether a thousands separator is displayed in the spin box (also known as an up-down control) when appropriate.</summary>
		/// true if a thousands separator is displayed in the spin box when appropriate; otherwise, false. The default value is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatData")]
		[DefaultValue(false)]
		[Localizable(true)]
		[SRDescription("NumericUpDownThousandsSeparatorDescr")]
		public bool ThousandsSeparator
		{
			get
			{
				return GetValue(ThousandsSeparatorProperty);
			}
			set
			{
				if (SetValue(ThousandsSeparatorProperty, value))
				{
					UpdateEditText();
					Update();
				}
			}
		}

		/// Gets or sets the value assigned to the spin box (also known as an up-down control).</summary>
		/// The numeric value of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Minimum"></see> property value.-or- The assigned value is greater than the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Maximum"></see> property value. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Bindable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("NumericUpDownValueDescr")]
		public decimal Value
		{
			get
			{
				return InternalValue;
			}
			set
			{
				if (CurrentValue != value)
				{
					InternalValue = value;
					Update();
				}
			}
		}

		private decimal InternalValue
		{
			get
			{
				if (base.UserEdit)
				{
					ValidateEditText();
				}
				return CurrentValue;
			}
			set
			{
				if (value != CurrentValue)
				{
					if (!Initializing && (value < Minimum || value > Maximum))
					{
						throw new ArgumentOutOfRangeException("Value", SR.GetString("InvalidBoundArgument", "Value", value.ToString(CultureInfo.CurrentCulture), "'Minimum'", "'Maximum'"));
					}
					CurrentValueInternal = value;
					OnValueChanged(EventArgs.Empty);
					CurrentValueChangedInternal = true;
					UpdateEditText();
				}
			}
		}

		/// Gets a collection of sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
		/// A <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> containing the sorted acceleration objects for the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public NumericUpDownAccelerationCollection Accelerations
		{
			get
			{
				if (mobjAccelerations == null)
				{
					mobjAccelerations = new NumericUpDownAccelerationCollection();
				}
				return mobjAccelerations;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Padding"></see> property changes.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler PaddingChanged
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

		/// Occurs when the value of the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Text"></see> property changes.</summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChanged
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

		/// Occurs when the <see cref="P:Gizmox.WebGui.Forms.NumericUpDown.Value"></see> property has been changed in some way.</summary>
		/// 1</filterpriority>
		[SRDescription("NumericUpDownOnValueChangedDescr")]
		[SRCategory("CatAction")]
		public event EventHandler ValueChanged
		{
			add
			{
				AddCriticalHandler(ValueChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValueChangedEvent, value);
			}
		}

		/// 
		/// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
		/// </summary>
		[SRDescription("NumericUpDownOnValueChangedDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientValueChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> class.</summary>
		public NumericUpDown()
		{
			Text = "0";
		}

		/// 
		/// Resets the CurrentValue
		/// </summary>
		private void ResetCurrentValue()
		{
			CurrentValue = DefaultValue;
		}

		/// Begins the initialization of a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control that is used on a form or used by another component. The initialization occurs at run time.</summary>
		/// 1</filterpriority>
		public void BeginInit()
		{
			Initializing = true;
		}

		/// Decrements the value of the spin box (also known as an up-down control).</summary>
		/// 1</filterpriority>
		public override void DownButton()
		{
			if (base.UserEdit)
			{
				ParseEditText();
			}
			decimal num = CurrentValue;
			try
			{
				num -= Increment;
				if (num < Minimum)
				{
					num = Minimum;
				}
			}
			catch (OverflowException)
			{
				num = Minimum;
			}
			Value = num;
		}

		/// Ends the initialization of a <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control that is used on a form or used by another component. The initialization occurs at run time.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void EndInit()
		{
			Initializing = false;
			Value = Constrain(CurrentValue);
			UpdateEditText();
		}

		/// Returns a string that represents the <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see> control.</summary>
		/// A string that represents the current <see cref="T:Gizmox.WebGui.Forms.NumericUpDown"></see>. </returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			string text = base.ToString();
			return text + ", Minimum = " + Minimum.ToString(CultureInfo.CurrentCulture) + ", Maximum = " + Maximum.ToString(CultureInfo.CurrentCulture);
		}

		/// Increments the value of the spin box (also known as an up-down control).</summary>
		/// 1</filterpriority>
		public override void UpButton()
		{
			if (base.UserEdit)
			{
				ParseEditText();
			}
			decimal num = CurrentValue;
			try
			{
				num += Increment;
				if (num > Maximum)
				{
					num = Maximum;
				}
			}
			catch (OverflowException)
			{
				num = Maximum;
			}
			Value = num;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		/// 
		///
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (ValueChangedHandler != null)
			{
				criticalEventsData.Set("VC");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// Raises the <see cref="E:Gizmox.WebGui.Forms.NumericUpDown.ValueChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnValueChanged(EventArgs e)
		{
			ValueChangedHandler?.Invoke(this, e);
		}

		/// Converts the text displayed in the spin box (also known as an up-down control) to a numeric value and evaluates it.</summary>
		protected void ParseEditText()
		{
			try
			{
				if (!string.IsNullOrEmpty(Text) && (Text.Length != 1 || Text != "-"))
				{
					if (Hexadecimal)
					{
						Value = Constrain(Convert.ToDecimal(Convert.ToInt32(Text, 16)));
					}
					else
					{
						Value = Constrain(decimal.Parse(Text, CultureInfo.InvariantCulture));
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

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("VLB", CurrentValue.ToString(CultureInfo.InvariantCulture));
			objWriter.WriteAttributeString("TX", GetNumberText(CurrentValue));
			if (Maximum != DefaultMaximum)
			{
				objWriter.WriteAttributeString("MAX", Maximum.ToString(CultureInfo.InvariantCulture));
			}
			if (Minimum != DefaultMinimum)
			{
				objWriter.WriteAttributeString("MIN", Minimum.ToString(CultureInfo.InvariantCulture));
			}
			if (DecimalPlaces != 0)
			{
				objWriter.WriteAttributeString("DPL", DecimalPlaces.ToString());
			}
			if (Increment != DefaultIncrement)
			{
				objWriter.WriteAttributeString("INC", Increment.ToString(CultureInfo.InvariantCulture));
			}
			if (ThousandsSeparator)
			{
				objWriter.WriteAttributeString("TSS", "1");
			}
		}

		/// 
		/// Sets up down value.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <param name="blnIsIndex">if set to true</c> [BLN is index].</param>
		protected override void SetUpDownValue(string strValue, bool blnIsIndex)
		{
			if (!string.IsNullOrEmpty(strValue) && decimal.TryParse(strValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
			{
				base.UserEdit = false;
				InternalValue = result;
			}
		}

		/// 
		/// Displays the current value of the spin box (also known as an up-down control) 
		/// in the appropriate format.
		/// </summary>
		protected override void UpdateEditText()
		{
			if (!Initializing)
			{
				if (base.UserEdit)
				{
					ParseEditText();
				}
				if (CurrentValueChanged || (!string.IsNullOrEmpty(Text) && (Text.Length != 1 || Text != "-")))
				{
					CurrentValueChangedInternal = false;
					base.ChangingText = true;
					SetTextInternal(GetNumberText(CurrentValue));
				}
			}
		}

		/// 
		/// Validates and updates the text displayed in the spin 
		/// box (also known as an up-down control).
		/// </summary>
		protected override void ValidateEditText()
		{
			ParseEditText();
			UpdateEditText();
		}

		/// 
		/// Constrains the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// </returns>
		private decimal Constrain(decimal value)
		{
			if (value < Minimum)
			{
				value = Minimum;
			}
			if (value > Maximum)
			{
				value = Maximum;
			}
			return value;
		}

		/// 
		/// Gets the number text.
		/// </summary>
		/// <param name="decNum">The num.</param>
		/// </returns>
		private string GetNumberText(decimal decNum)
		{
			if (Hexadecimal)
			{
				return ((long)decNum).ToString("X", CultureInfo.InvariantCulture);
			}
			CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			if (Context != null)
			{
				cultureInfo = Context.CurrentUICulture;
			}
			return decNum.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces.ToString(cultureInfo), cultureInfo);
		}

		/// 
		/// Resets the increment.
		/// </summary>
		private void ResetIncrement()
		{
			Increment = DefaultIncrement;
		}

		/// 
		/// Resets the maximum.
		/// </summary>
		private void ResetMaximum()
		{
			Maximum = DefaultMaximum;
		}

		/// 
		/// Resets the minimum.
		/// </summary>
		private void ResetMinimum()
		{
			Minimum = DefaultMinimum;
		}

		/// 
		/// Resets the value.
		/// </summary>
		private void ResetValue()
		{
			Value = DefaultValue;
		}

		/// 
		/// Shoulds the serialize increment.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeIncrement()
		{
			return !Increment.Equals(DefaultIncrement);
		}

		/// 
		/// Shoulds the serialize maximum.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMaximum()
		{
			return !Maximum.Equals(DefaultMaximum);
		}

		/// 
		/// Shoulds the serialize minimum.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMinimum()
		{
			return !Minimum.Equals(DefaultMinimum);
		}

		/// 
		/// Shoulds the serialize value.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeValue()
		{
			return !Value.Equals(0m);
		}

		static NumericUpDown()
		{
			ValueChanged = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(NumericUpDown));
			ThousandsSeparatorProperty = SerializableProperty.Register("ThousandsSeparator", typeof(bool), typeof(NumericUpDown), new SerializablePropertyMetadata(false));
		}
	}
}
