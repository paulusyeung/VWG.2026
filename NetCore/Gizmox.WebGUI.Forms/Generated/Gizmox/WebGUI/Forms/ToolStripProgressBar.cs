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
/// Represents a Windows progress bar control contained in a <see cref="T:System.Windows.Forms.StatusStrip"></see>.</summary>
	[Serializable]
	[DefaultProperty("Value")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)9)]
	public class ToolStripProgressBar : ToolStripControlHost
	{
		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Drawing.Image"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Windows.Forms.ImageLayout"></see> value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// Gets the height and width of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> in pixels.</summary>
		/// A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the height and width.</returns>
		protected override Size DefaultSize => new Size(100, 15);

		/// Gets or sets a value representing the delay between each <see cref="F:System.Windows.Forms.ProgressBarStyle.Marquee"></see> display update, in milliseconds.</summary>
		/// An integer representing the delay, in milliseconds.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int MarqueeAnimationSpeed
		{
			get
			{
				return 100;
			}
			set
			{
			}
		}

		/// Gets or sets the upper bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
		/// An integer representing the upper bound of the range. The default is 100.</returns>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("ProgressBarMaximumDescr")]
		[DefaultValue(100)]
		[SRCategory("CatBehavior")]
		public int Maximum
		{
			get
			{
				return ProgressBar.Maximum;
			}
			set
			{
				ProgressBar.Maximum = value;
			}
		}

		/// Gets or sets the lower bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
		/// An integer representing the lower bound of the range. The default is 0.</returns>
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		[SRDescription("ProgressBarMinimumDescr")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public int Minimum
		{
			get
			{
				return ProgressBar.Minimum;
			}
			set
			{
				ProgressBar.Minimum = value;
			}
		}

		/// Gets the <see cref="T:System.Windows.Forms.ProgressBar"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ProgressBar"></see>.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ProgressBar ProgressBar => base.Control as ProgressBar;

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> layout is right-to-left or left-to-right when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>. </summary>
		/// true to turn on mirroring and lay out control from right to left when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>; otherwise, false. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool RightToLeftLayout
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets the amount by which to increment the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> when the <see cref="M:System.Windows.Forms.ToolStripProgressBar.PerformStep"></see> method is called.</summary>
		/// An integer representing the incremental amount. The default value is 10.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(10)]
		[SRCategory("CatBehavior")]
		[SRDescription("ProgressBarStepDescr")]
		public int Step
		{
			get
			{
				return ProgressBar.Step;
			}
			set
			{
				ProgressBar.Step = value;
			}
		}

		/// Gets or sets the style of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ProgressBarStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.ProgressBarStyle.Blocks"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ProgressBarStyle Style
		{
			get
			{
				return ProgressBarStyle.Blocks;
			}
			set
			{
			}
		}

		/// Gets or sets the text displayed on the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
		/// A <see cref="T:System.String"></see> representing the display text.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return base.Control.Text;
			}
			set
			{
				base.Control.Text = value;
			}
		}

		/// Gets or sets the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
		/// An integer representing the current value.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("ProgressBarValueDescr")]
		[Bindable(true)]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return ProgressBar.Value;
			}
			set
			{
				ProgressBar.Value = value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event KeyEventHandler KeyDown
		{
			add
			{
				base.KeyDown += value;
			}
			remove
			{
				base.KeyDown -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event KeyPressEventHandler KeyPress
		{
			add
			{
				base.KeyPress += value;
			}
			remove
			{
				base.KeyPress -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event KeyEventHandler KeyUp
		{
			add
			{
				base.KeyUp += value;
			}
			remove
			{
				base.KeyUp -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler LocationChanged
		{
			add
			{
				base.LocationChanged += value;
			}
			remove
			{
				base.LocationChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler OwnerChanged
		{
			add
			{
				base.OwnerChanged += value;
			}
			remove
			{
				base.OwnerChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.RightToLeftLayout"></see> property changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler RightToLeftLayoutChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		/// This event is not relevant to this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler Validated
		{
			add
			{
				base.Validated += value;
			}
			remove
			{
				base.Validated -= value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event CancelEventHandler Validating
		{
			add
			{
				base.Validating += value;
			}
			remove
			{
				base.Validating -= value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class. </summary>
		public ToolStripProgressBar()
			: base(new ProgressBar())
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class with specified name. </summary> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see>.</param>
		public ToolStripProgressBar(string name)
			: this()
		{
			base.Name = name;
		}

		/// Advances the current position of the progress bar by the specified amount.</summary> 
		/// <param name="value">The amount by which to increment the progress bar's current position.</param>
		public void Increment(int value)
		{
			ProgressBar.Increment(value);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ProgressBar.RightToLeftLayoutChanged"></see> event. </summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRightToLeftLayoutChanged(EventArgs e)
		{
		}

		/// Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.Step"></see> property.</summary>
		public void PerformStep()
		{
			ProgressBar.PerformStep();
		}
	}
}
