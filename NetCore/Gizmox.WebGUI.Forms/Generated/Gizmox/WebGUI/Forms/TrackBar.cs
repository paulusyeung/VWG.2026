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
	/// Represents a standard Visual WebGui track bar.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(TrackBar), "TrackBar_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[DefaultProperty("Value")]
	[DefaultEvent("ValueChanged")]
	[SRDescription("DescriptionTrackBar")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("TRB")]
	[Skin(typeof(TrackBarSkin))]
	public class TrackBar : Control, ISupportInitialize
	{
		/// 
		/// Provides a property reference to TickStyle property.
		/// </summary>
		private static SerializableProperty TickStyleProperty = SerializableProperty.Register("TickStyle", typeof(TickStyle), typeof(TrackBar));

		/// 
		/// Provides a property reference to TickFrequency property.
		/// </summary>
		private static SerializableProperty TickFrequencyProperty = SerializableProperty.Register("TickFrequency", typeof(int), typeof(TrackBar));

		/// 
		/// Provides a property reference to SmallChange property.
		/// </summary>
		private static SerializableProperty SmallChangeProperty = SerializableProperty.Register("SmallChange", typeof(int), typeof(TrackBar));

		/// 
		/// Provides a property reference to Orientation property.
		/// </summary>
		private static SerializableProperty OrientationProperty = SerializableProperty.Register("Orientation", typeof(Orientation), typeof(TrackBar));

		/// 
		/// Provides a property reference to Minimum property.
		/// </summary>
		private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(int), typeof(TrackBar));

		/// 
		/// Provides a property reference to Maximum property.
		/// </summary>
		private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(int), typeof(TrackBar));

		/// 
		/// Provides a property reference to LargeChange property.
		/// </summary>
		private static SerializableProperty LargeChangeProperty = SerializableProperty.Register("LargeChange", typeof(int), typeof(TrackBar));

		/// 
		/// Provides a property reference to Value property.
		/// </summary>
		private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(float), typeof(TrackBar), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a RequestedDim property.
		/// </summary>
		private int mintRequestedDim = 0;

		/// 
		/// The value change event reference
		/// </summary>
		private static readonly SerializableEvent ValueChangedEvent;

		/// 
		/// Gets the value changed handler.
		/// </summary>
		/// The value changed handler.</value>
		private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChanged);

		/// 
		/// Gets or sets a value to be added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a large distance.
		/// </summary>
		/// A numeric value. The default is 5.</returns>
		/// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
		[SRCategory("CatBehavior")]
		[SRDescription("TrackBarLargeChangeDescr")]
		[DefaultValue(5)]
		public int LargeChange
		{
			get
			{
				return GetValue(LargeChangeProperty, 5);
			}
			set
			{
				if (LargeChange != value)
				{
					SetValue(LargeChangeProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the maximum internal.
		/// </summary>
		/// The maximum internal.</value>
		private int MaximumInternal
		{
			get
			{
				return GetValue(MaximumProperty, 10);
			}
			set
			{
				SetValue(MaximumProperty, value);
			}
		}

		/// 
		/// Gets or sets the upper limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
		/// </summary>
		/// The maximum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 10.</returns>
		[DefaultValue(10)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("TrackBarMaximumDescr")]
		[SRCategory("CatBehavior")]
		public int Maximum
		{
			get
			{
				return MaximumInternal;
			}
			set
			{
				if (MaximumInternal != value)
				{
					int num = MinimumInternal;
					if (value < num)
					{
						num = (MinimumInternal = value);
					}
					SetRange(num, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the minimum internal.
		/// </summary>
		/// The minimum internal.</value>
		private int MinimumInternal
		{
			get
			{
				return GetValue(MinimumProperty, 0);
			}
			set
			{
				SetValue(MinimumProperty, value);
			}
		}

		/// 
		/// Gets or sets the lower limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
		/// </summary>
		/// The minimum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 0.</returns>
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		[SRDescription("TrackBarMinimumDescr")]
		[RefreshProperties(RefreshProperties.All)]
		public int Minimum
		{
			get
			{
				return MinimumInternal;
			}
			set
			{
				if (MinimumInternal != value)
				{
					int num = MaximumInternal;
					if (value > num)
					{
						num = (MaximumInternal = value);
					}
					SetRange(value, num);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the requested dim.
		/// </summary>
		/// The requested dim.</value>
		[SRCategory("CatBehavior")]
		[SRDescription("TrackBarLargeChangeDescr")]
		[DefaultValue(5)]
		private int RequestedDim
		{
			get
			{
				return mintRequestedDim;
			}
			set
			{
				mintRequestedDim = value;
			}
		}

		/// 
		/// Gets or sets a value indicating the horizontal or vertical orientation of the track bar.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. </exception>
		[DefaultValue(Orientation.Horizontal)]
		[Localizable(true)]
		[SRDescription("TrackBarOrientationDescr")]
		[SRCategory("CatAppearance")]
		public Orientation Orientation
		{
			get
			{
				return GetValue(OrientationProperty, Orientation.Horizontal);
			}
			set
			{
				if (Orientation != value)
				{
					SetValue(OrientationProperty, value);
					if (Orientation == Orientation.Horizontal)
					{
						SetStyle(ControlStyles.FixedHeight, AutoSize);
						SetStyle(ControlStyles.FixedWidth, blnValue: false);
						base.Width = RequestedDim;
					}
					else
					{
						SetStyle(ControlStyles.FixedHeight, blnValue: false);
						SetStyle(ControlStyles.FixedWidth, AutoSize);
						base.Height = RequestedDim;
					}
					Rectangle bounds = base.Bounds;
					base.SetBoundsCore(bounds.X, bounds.Y, bounds.Height, bounds.Width, BoundsSpecified.All);
					AdjustSize();
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the value added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a small distance.
		/// </summary>
		/// A numeric value. The default value is 1.</returns>
		/// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
		[SRCategory("CatAppearance")]
		[DefaultValue(1)]
		[SRDescription("TrackBarSmallChangeDescr")]
		public int SmallChange
		{
			get
			{
				return GetValue(SmallChangeProperty, 1);
			}
			set
			{
				if (SmallChange != value)
				{
					SetValue(SmallChangeProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value that specifies the delta between ticks drawn on the control.
		/// </summary>
		/// The numeric value representing the delta between ticks. The default is 1.</returns>
		[DefaultValue(1)]
		[SRDescription("TrackBarTickFrequencyDescr")]
		[SRCategory("CatAppearance")]
		public int TickFrequency
		{
			get
			{
				return GetValue(TickFrequencyProperty, 1);
			}
			set
			{
				if (TickFrequency != value)
				{
					SetValue(TickFrequencyProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating how to display the tick marks on the track bar.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TickStyle.BottomRight"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see>. </exception>
		[DefaultValue(TickStyle.BottomRight)]
		[SRCategory("CatAppearance")]
		[SRDescription("TrackBarTickStyleDescr")]
		public TickStyle TickStyle
		{
			get
			{
				return GetValue(TickStyleProperty, TickStyle.BottomRight);
			}
			set
			{
				if (TickStyle != value)
				{
					SetValue(TickStyleProperty, value, TickStyle.BottomRight);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
		/// </summary>
		/// A numeric value that is within the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see> and <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see> range. The default value is 0.</returns>
		/// <exception cref="T:System.ArgumentException">The assigned value is less than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see>.-or- The assigned value is greater than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see>. </exception>
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		[SRDescription("TrackBarValueDescr")]
		[Bindable(true)]
		public int Value
		{
			get
			{
				return Convert.ToInt32(ValueInternal);
			}
			set
			{
				if (value < Minimum || value > Maximum)
				{
					throw new ArgumentOutOfRangeException("Value", SR.GetString("InvalidBoundArgument", "Value", value.ToString(CultureInfo.CurrentCulture), "'Minimum'", "'Maximum'"));
				}
				if (Value != value)
				{
					ValueInternal = value;
					Update();
					FireObservableItemPropertyChanged("Value");
				}
			}
		}

		/// 
		/// Gets or sets the internal value.
		/// </summary>
		/// The internal value.</value>
		private float ValueInternal
		{
			get
			{
				return GetValue(ValueProperty, 0f);
			}
			set
			{
				if (SetValue(ValueProperty, value))
				{
					OnValueChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Bindable(false)]
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

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Padding Padding
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
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property of a track bar changes, either by movement of the scroll box or by manipulation in code.
		/// </summary>
		[SRCategory("CatAction")]
		[SRDescription("valueChangedEventDescr")]
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
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("Occurs when control's value changed in client mode.")]
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

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> class.
		/// </summary>
		public TrackBar()
		{
		}

		/// 
		/// Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
		/// </summary>
		public void BeginInit()
		{
		}

		/// 
		/// Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
		/// </summary>
		public void EndInit()
		{
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TrackBar.ValueChanged"></see> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnValueChanged(EventArgs e)
		{
			ValueChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Sets the minimum and maximum values for a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>.
		/// </summary>
		/// <param name="intMinValue">The lower limit of the range of the track bar. </param>
		/// <param name="intMaxValue">The upper limit of the range of the track bar. </param>
		public void SetRange(int intMinValue, int intMaxValue)
		{
			int maximumInternal = MaximumInternal;
			bool flag = MinimumInternal != intMinValue;
			bool flag2 = maximumInternal != intMaxValue;
			if (flag || flag2)
			{
				float valueInternal = ValueInternal;
				if (intMinValue > intMaxValue)
				{
					intMaxValue = intMinValue;
					flag2 = maximumInternal != intMaxValue;
				}
				if (flag)
				{
					MinimumInternal = intMinValue;
				}
				if (flag2)
				{
					MaximumInternal = intMaxValue;
				}
				if (valueInternal < (float)intMinValue)
				{
					SetValue(ValueProperty, (float)intMinValue);
				}
				if (valueInternal > (float)intMaxValue)
				{
					SetValue(ValueProperty, (float)intMaxValue);
				}
			}
		}

		/// 
		/// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> control.
		/// </summary>
		/// A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. </returns>
		public override string ToString()
		{
			return base.ToString() + ", Minimum: " + Minimum + ", Maximum: " + Maximum + ", Value: " + Value;
		}

		/// 
		/// Gets the critical events.
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

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (type == "ValueChange")
			{
				float num = float.Parse(objEvent["VLB"], NumberStyles.Any, CultureInfo.InvariantCulture);
				if (num < 0f)
				{
					num = 0f;
				}
				else if (num > 100f)
				{
					num = 100f;
				}
				int minimum = Minimum;
				ValueInternal = (float)minimum + (float)(Maximum - minimum) * (num / 100f);
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			int tickFrequency = TickFrequency;
			float num = Maximum - Minimum + 1;
			decimal num2 = Math.Round((decimal)((float)tickFrequency / num * 100f), 2);
			decimal num3 = default(decimal);
			if (num > 1f)
			{
				num3 = Math.Round((decimal)((ValueInternal - (float)Minimum) / (num - 1f) * 100f), 2);
			}
			else
			{
				objWriter.WriteAttributeString("FZ", "1");
			}
			decimal num4 = 1m;
			if (tickFrequency > 0)
			{
				num4 = Convert.ToDecimal(Math.Floor((double)(num - 1f) / (double)tickFrequency));
			}
			objWriter.WriteAttributeString("S", ((int)TickStyle).ToString());
			objWriter.WriteAttributeString("ORI", ((int)Orientation).ToString());
			objWriter.WriteAttributeString("LEN", num4.ToString(CultureInfo.InvariantCulture));
			objWriter.WriteAttributeString("TSZ", num2.ToString(CultureInfo.InvariantCulture));
			objWriter.WriteAttributeString("VLB", num3.ToString(CultureInfo.InvariantCulture));
			if (VisualTemplate != null)
			{
				objWriter.WriteAttributeString("MIN", Minimum.ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("MAX", Maximum.ToString(CultureInfo.InvariantCulture));
			}
		}

		/// 
		/// Performs the work of setting the specified bounds of this control.
		/// </summary>
		/// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
		/// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
		/// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
		/// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
		/// <param name="blnIsClientSource">if set to true</c> [BLN is client source].</param>
		/// </returns>
		protected override bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
		{
			RequestedDim = ((Orientation == Orientation.Horizontal) ? intHeight : intWidth);
			return base.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
		}

		/// 
		/// Adjusts the size.
		/// </summary>
		private void AdjustSize()
		{
			int requestedDim = RequestedDim;
			try
			{
				if (Orientation == Orientation.Horizontal)
				{
					base.Height = requestedDim;
				}
				else
				{
					base.Width = requestedDim;
				}
			}
			finally
			{
				RequestedDim = requestedDim;
			}
		}

		static TrackBar()
		{
			ValueChanged = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(TrackBar));
		}
	}
}
