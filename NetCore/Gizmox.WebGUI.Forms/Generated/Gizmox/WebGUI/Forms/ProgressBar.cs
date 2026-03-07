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
	/// Represents a WebGUI progress bar control.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ProgressBar), "ProgressBar_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Value")]
	[SRDescription("DescriptionProgressBar")]
	[DefaultProperty("Value")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("PB")]
	[Skin(typeof(ProgressBarSkin))]
	public class ProgressBar : Control
	{
		/// 
		/// Provides a property reference to Step property.
		/// </summary>
		private static SerializableProperty StepProperty = SerializableProperty.Register("Step", typeof(int), typeof(ProgressBar));

		/// 
		/// Provides a property reference to Value property.
		/// </summary>
		private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(int), typeof(ProgressBar));

		/// 
		/// Provides a property reference to Minimum property.
		/// </summary>
		private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(int), typeof(ProgressBar));

		/// 
		/// Provides a property reference to Maximum property.
		/// </summary>
		private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(int), typeof(ProgressBar));

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// 
		/// The default size.
		/// </value>
		protected override Size DefaultSize => new Size(100, 23);

		/// 
		/// Gets or sets the maximum value of the range of the control.
		/// </summary>
		/// The maximum value of the range. The default is 100.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than 0. </exception>
		[DefaultValue(100)]
		[SRDescription("ProgressBarMaximumDescr")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public int Maximum
		{
			get
			{
				return GetValue(MaximumProperty, 100);
			}
			set
			{
				if (Maximum != value)
				{
					if (Minimum > value)
					{
						SetValue(MinimumProperty, value);
					}
					if (value != 100)
					{
						SetValue(MaximumProperty, value);
					}
					else
					{
						RemoveValue(MaximumProperty);
					}
					if (Value > Maximum)
					{
						SetValue(ValueProperty, Maximum);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the minimum value of the range of the control.
		/// </summary>
		/// The minimum value of the range. The default is 0.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified for the property is less than 0. </exception>
		[SRDescription("ProgressBarMinimumDescr")]
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public int Minimum
		{
			get
			{
				return GetValue(MinimumProperty, 0);
			}
			set
			{
				if (Minimum != value)
				{
					if (Maximum < value)
					{
						SetValue(MaximumProperty, value);
					}
					if (value != 0)
					{
						SetValue(MinimumProperty, value);
					}
					else
					{
						RemoveValue(MinimumProperty);
					}
					if (Value < Minimum)
					{
						SetValue(ValueProperty, Minimum);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the current position of the progress bar.
		/// </summary>
		/// The position within the range of the progress bar. The default is 0.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Maximum"></see> property.-or- The value specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Minimum"></see> property. </exception>
		[SRDescription("ProgressBarValueDescr")]
		[Bindable(true)]
		[SRCategory("CatBehavior")]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return GetValue(ValueProperty);
			}
			set
			{
				if (Value != value)
				{
					if (value < Minimum || value > Maximum)
					{
						throw new ArgumentOutOfRangeException("Value");
					}
					if (value != 0)
					{
						SetValue(ValueProperty, value);
					}
					else
					{
						RemoveValue(ValueProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the amount by which a call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method increases the current position of the progress bar.
		/// </summary>
		/// The amount by which to increment the progress bar with each call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method. The default is 10.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(10)]
		[SRDescription("ProgressBarStepDescr")]
		public int Step
		{
			get
			{
				return GetValue(StepProperty, 10);
			}
			set
			{
				if (value != 10)
				{
					SetValue(StepProperty, value);
				}
				else
				{
					RemoveValue(StepProperty);
				}
				Update();
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Bindable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> class.
		/// </summary>
		public ProgressBar()
		{
			SetStyle(ControlStyles.Selectable | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, blnValue: false);
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			int num = Maximum - Minimum;
			int num2 = Value - Minimum;
			int num3 = 0;
			if (num != 0)
			{
				num3 = (int)((double)num2 / (double)num * 100.0);
			}
			objWriter.WriteAttributeString("Precent", num3.ToString());
		}

		/// 
		/// Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Step"></see> property.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see>.</exception>
		public void PerformStep()
		{
			Increment(Step);
		}

		/// 
		/// Advances the current position of the progress bar by the specified amount.
		/// </summary>
		/// <param name="value">The amount by which to increment the progress bar's current position. </param>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see></exception>
		public void Increment(int value)
		{
			Value += value;
			if (Value < Minimum)
			{
				Value = Minimum;
			}
			if (Value > Maximum)
			{
				Value = Maximum;
			}
			Update();
		}
	}
}
