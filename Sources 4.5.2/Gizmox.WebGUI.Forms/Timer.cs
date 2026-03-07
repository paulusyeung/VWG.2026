using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{
	/// <summary>
    /// Implements a timer that raises an event at user-defined intervals. This timer is optimized for use in Gizmox.WebGUI.Forms applications and must be used in a window.
	/// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(Timer), "Timer_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(Timer), "Timer.bmp")]
#endif
    [DefaultEvent("Tick"), DefaultProperty("Interval"), SRDescription("DescriptionTimer")]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItemCategory("Components"), Serializable()]
	public class Timer : ComponentBase, ITimer
	{
		
		#region Class Members

        /// <summary>
        /// 
        /// </summary>
		private bool mblnEnabled = false;

        /// <summary>
        /// 
        /// </summary>
		private int mintInterval = 10000;

        /// <summary>
        /// 
        /// </summary>
		private long mlngLastTicks = 0;

        /// <summary>
        /// 
        /// </summary>
		private ITimerHandler mobjTimerHandler = null;

		/// <summary>
		/// Occurs when the specified timer interval has elapsed and the timer is enabled.
		/// </summary>
		[SRDescription("TimerTimerDescr"), SRCategory("CatBehavior")]
		public event EventHandler Tick;
		
		#endregion

		#region C'Tors \ D'Tors

		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class with the specified container.
		/// </summary>
		/// <param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container for the timer. </param>
		public Timer(IContainer objContainer) : this()
		{
            objContainer.Add(this);
		}
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class.
		/// </summary>
		public Timer()
		{
			
		}
		
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets whether the timer is running.
		/// </summary>
		/// <returns>true if the timer is currently enabled; otherwise, false. The default is false.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TimerEnabledDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
		public virtual bool Enabled
		{
			get
			{
				return mblnEnabled;
			}
			set
			{
				if (this.mblnEnabled != value)
				{
                    if (Global.Context != null)
                    {
                        if (value)
                        {
                            ITimerHandlerContainer objTimerHandlerContainer = Global.Context as ITimerHandlerContainer;
                            if (objTimerHandlerContainer != null)
                            {
                                this.mobjTimerHandler = objTimerHandlerContainer.Timers;
                                if (this.mobjTimerHandler != null)
                                {
                                    this.mlngLastTicks = DateTime.Now.Ticks;
                                    this.mobjTimerHandler.AddTimer(this);
                                }
                            }
                        }
                        else
                        {
                            if (mobjTimerHandler != null)
                            {
                                this.mobjTimerHandler.RemoveTimer(this);
                                this.mobjTimerHandler = null;
                            }
                        }
                    }
					this.mblnEnabled = value;
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the time, in milliseconds, between timer ticks.
		/// </summary>
		/// <returns>The number of milliseconds between each timer tick. The value is not less than one.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TimerIntervalDescr"), SRCategory("CatBehavior"), DefaultValue(100)]
		public int Interval
		{
			get
			{
				return this.mintInterval;
			}
			set
			{

				if (value < 100)
				{
					throw new ArgumentOutOfRangeException("Interval",value,"Visual WebGui timer requires 100ms and above as its interval.");
				}
				if (this.mintInterval != value)
				{
					this.mintInterval = value;
				}

			}
		}
		
		#endregion

		#region Methods

		#region Public Methods

		/// <summary>
		/// Starts the timer.
		/// </summary>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Start()
		{
			this.Enabled = true;
		}
		
		/// <summary>
		/// Stops the timer.
		/// </summary>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Stop()
		{
			this.Enabled = false;
		}
		
		/// <summary>
        /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>.
		/// </summary>
        /// <returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>. </returns>
		public override string ToString()
		{
            string strText1 = base.ToString();
            return (strText1 + ", Interval: " + this.Interval.ToString());
		}
		
		#endregion
		
		#region Protected Methods

		/// <summary>
		/// Disposes of the resources (other than memory) used by the timer.
		/// </summary>
		protected override void Dispose(bool blnDisposing)
		{
            if (blnDisposing)
			{
				this.Enabled = false;
			}
            base.Dispose(blnDisposing);
		}
		
		/// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Timer.Tick"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. This is always <see cref="F:System.EventArgs.Empty"></see>. </param>
		protected virtual void OnTick(EventArgs e)
		{
            // Raise event if needed
            EventHandler objEventHandler = this.Tick;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
		}
		
		#endregion
		
		#endregion

		#region ITimer Members

		/// <summary>
		/// local timer id variable
		/// </summary>
		private int mintTimerID = -1;

		/// <summary>
		/// Sets or gets the timer id
		/// </summary>
		int ITimer.TimerID
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

        /// <summary>
        /// Gets the timer interval
        /// </summary>
        int ITimer.Interval
		{
			get
			{
				return this.Interval;
			}
		}

		/// <summary>
		/// Gets timer enabled state
		/// </summary>
		bool ITimer.Enabled
		{
			get
			{
				return this.Enabled;
			}
		}

		/// <summary>
		/// Invoke timer.
		/// </summary>
		int ITimer.InvokeTimer()
		{
			this.mlngLastTicks = DateTime.Now.Ticks;

            try
            {
                this.OnTick(EventArgs.Empty);
            }
            catch (Exception objException)
            {
                if (!((IApplicationContext)VWGContext.Current).HandleThreadException(objException))
                {
                    throw objException;
                }
            }

			return ((ITimer)this).GetNextInvokation(mlngLastTicks);
		}

		/// <summary>
		/// Gets the next planed invocation.
		/// </summary>
		/// <param name="lngCurrentTicks"></param>
		int ITimer.GetNextInvokation(long lngCurrentTicks)
		{


			// Get passed ticks from last execution
			TimeSpan objTimeSpan = TimeSpan.FromTicks(lngCurrentTicks-this.mlngLastTicks);

			// Get milliseconds to next execution
			int intMilliseconds = mintInterval - (int)objTimeSpan.TotalMilliseconds;
			
			// Validate value
			if(intMilliseconds<0)
			{
				intMilliseconds = 0;
			}
			
			// Return milliseconds to next execution
			return intMilliseconds;
		}
		#endregion
	}
}
