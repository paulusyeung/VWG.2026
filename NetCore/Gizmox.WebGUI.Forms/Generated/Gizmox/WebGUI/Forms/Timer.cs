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
	/// Implements a timer that raises an event at user-defined intervals. This timer is optimized for use in Gizmox.WebGUI.Forms applications and must be used in a window.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(Timer), "Timer_45.bmp")]
	[DefaultEvent("Tick")]
	[DefaultProperty("Interval")]
	[SRDescription("DescriptionTimer")]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItemCategory("Components")]
	public class Timer : ComponentBase, Gizmox.WebGUI.Common.Interfaces.ITimer
	{
		/// 
		///
		/// </summary>
		private bool mblnEnabled = false;

		/// 
		///
		/// </summary>
		private int mintInterval = 10000;

		/// 
		///
		/// </summary>
		private long mlngLastTicks = 0L;

		/// 
		///
		/// </summary>
		private ITimerHandler mobjTimerHandler = null;

		/// 
		/// local timer id variable
		/// </summary>
		private int mintTimerID = -1;

		/// 
		/// Gets or sets whether the timer is running.
		/// </summary>
		/// true if the timer is currently enabled; otherwise, false. The default is false.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TimerEnabledDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public virtual bool Enabled
		{
			get
			{
				return mblnEnabled;
			}
			set
			{
				if (mblnEnabled == value)
				{
					return;
				}
				if (Global.Context != null)
				{
					if (value)
					{
						if (Global.Context is ITimerHandlerContainer timerHandlerContainer)
						{
							mobjTimerHandler = timerHandlerContainer.Timers;
							if (mobjTimerHandler != null)
							{
								mlngLastTicks = DateTime.Now.Ticks;
								mobjTimerHandler.AddTimer(this);
							}
						}
					}
					else if (mobjTimerHandler != null)
					{
						mobjTimerHandler.RemoveTimer(this);
						mobjTimerHandler = null;
					}
				}
				mblnEnabled = value;
			}
		}

		/// 
		/// Gets or sets the time, in milliseconds, between timer ticks.
		/// </summary>
		/// The number of milliseconds between each timer tick. The value is not less than one.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TimerIntervalDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(100)]
		public int Interval
		{
			get
			{
				return mintInterval;
			}
			set
			{
				if (value < 100)
				{
					throw new ArgumentOutOfRangeException("Interval", value, "Visual WebGui timer requires 100ms and above as its interval.");
				}
				if (mintInterval != value)
				{
					mintInterval = value;
				}
			}
		}

		/// 
		/// Sets or gets the timer id
		/// </summary>
		int Gizmox.WebGUI.Common.Interfaces.ITimer.TimerID
		{
			get
			{
				return mintTimerID;
			}
			set
			{
				mintTimerID = value;
			}
		}

		/// 
		/// Gets the timer interval
		/// </summary>
		int Gizmox.WebGUI.Common.Interfaces.ITimer.Interval => Interval;

		/// 
		/// Gets timer enabled state
		/// </summary>
		bool Gizmox.WebGUI.Common.Interfaces.ITimer.Enabled => Enabled;

		/// 
		/// Occurs when the specified timer interval has elapsed and the timer is enabled.
		/// </summary>
		[SRDescription("TimerTimerDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler Tick;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class with the specified container.
		/// </summary>
		/// <param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container for the timer. </param>
		public Timer(IContainer objContainer)
			: this()
		{
			objContainer.Add(this);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class.
		/// </summary>
		public Timer()
		{
		}

		/// 
		/// Starts the timer.
		/// </summary>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Start()
		{
			Enabled = true;
		}

		/// 
		/// Stops the timer.
		/// </summary>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Stop()
		{
			Enabled = false;
		}

		/// 
		/// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>.
		/// </summary>
		/// A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>. </returns>
		public override string ToString()
		{
			string text = base.ToString();
			return text + ", Interval: " + Interval;
		}

		/// 
		/// Disposes of the resources (other than memory) used by the timer.
		/// </summary>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				Enabled = false;
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Timer.Tick"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. This is always <see cref="F:System.EventArgs.Empty"></see>. </param>
		protected virtual void OnTick(EventArgs e)
		{
			this.Tick?.Invoke(this, e);
		}

		/// 
		/// Invoke timer.
		/// </summary>
		int Gizmox.WebGUI.Common.Interfaces.ITimer.InvokeTimer()
		{
			mlngLastTicks = DateTime.Now.Ticks;
			try
			{
				OnTick(EventArgs.Empty);
			}
			catch (Exception ex)
			{
				if (!((IApplicationContext)VWGContext.Current).HandleThreadException(ex))
				{
					throw ex;
				}
			}
			return ((Gizmox.WebGUI.Common.Interfaces.ITimer)this).GetNextInvokation(mlngLastTicks);
		}

		/// 
		/// Gets the next planed invocation.
		/// </summary>
		/// <param name="lngCurrentTicks"></param>
		int Gizmox.WebGUI.Common.Interfaces.ITimer.GetNextInvokation(long lngCurrentTicks)
		{
			TimeSpan timeSpan = TimeSpan.FromTicks(lngCurrentTicks - mlngLastTicks);
			int num = mintInterval - (int)timeSpan.TotalMilliseconds;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}
	}
}
