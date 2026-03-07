// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Timer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Implements a timer that raises an event at user-defined intervals. This timer is optimized for use in Gizmox.WebGUI.Forms applications and must be used in a window.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (Timer), "Timer_45.bmp")]
  [DefaultEvent("Tick")]
  [DefaultProperty("Interval")]
  [SRDescription("DescriptionTimer")]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItemCategory("Components")]
  [Serializable]
  public class Timer : ComponentBase, ITimer
  {
    /// <summary>
    /// 
    /// </summary>
    private bool mblnEnabled;
    /// <summary>
    /// 
    /// </summary>
    private int mintInterval = 10000;
    /// <summary>
    /// 
    /// </summary>
    private long mlngLastTicks;
    /// <summary>
    /// 
    /// </summary>
    private ITimerHandler mobjTimerHandler;
    /// <summary>local timer id variable</summary>
    private int mintTimerID = -1;

    /// <summary>
    /// Occurs when the specified timer interval has elapsed and the timer is enabled.
    /// </summary>
    [SRDescription("TimerTimerDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler Tick;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class with the specified container.
    /// </summary>
    /// <param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container for the timer. </param>
    public Timer(IContainer objContainer)
      : this()
    {
      objContainer.Add((IComponent) this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see> class.
    /// </summary>
    public Timer()
    {
    }

    /// <summary>Gets or sets whether the timer is running.</summary>
    /// <returns>true if the timer is currently enabled; otherwise, false. The default is false.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("TimerEnabledDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public virtual bool Enabled
    {
      get => this.mblnEnabled;
      set
      {
        if (this.mblnEnabled == value)
          return;
        if (Global.Context != null)
        {
          if (value)
          {
            if (Global.Context is ITimerHandlerContainer context)
            {
              this.mobjTimerHandler = context.Timers;
              if (this.mobjTimerHandler != null)
              {
                this.mlngLastTicks = DateTime.Now.Ticks;
                this.mobjTimerHandler.AddTimer((ITimer) this);
              }
            }
          }
          else if (this.mobjTimerHandler != null)
          {
            this.mobjTimerHandler.RemoveTimer((ITimer) this);
            this.mobjTimerHandler = (ITimerHandler) null;
          }
        }
        this.mblnEnabled = value;
      }
    }

    /// <summary>
    /// Gets or sets the time, in milliseconds, between timer ticks.
    /// </summary>
    /// <returns>The number of milliseconds between each timer tick. The value is not less than one.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("TimerIntervalDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(100)]
    public int Interval
    {
      get => this.mintInterval;
      set
      {
        if (value < 100)
          throw new ArgumentOutOfRangeException(nameof (Interval), (object) value, "Visual WebGui timer requires 100ms and above as its interval.");
        if (this.mintInterval == value)
          return;
        this.mintInterval = value;
      }
    }

    /// <summary>Starts the timer.</summary>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Start() => this.Enabled = true;

    /// <summary>Stops the timer.</summary>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Stop() => this.Enabled = false;

    /// <summary>
    /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Timer"></see>. </returns>
    public override string ToString() => base.ToString() + ", Interval: " + this.Interval.ToString();

    /// <summary>
    /// Disposes of the resources (other than memory) used by the timer.
    /// </summary>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
        this.Enabled = false;
      base.Dispose(blnDisposing);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Timer.Tick"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. This is always <see cref="F:System.EventArgs.Empty"></see>. </param>
    protected virtual void OnTick(EventArgs e)
    {
      EventHandler tick = this.Tick;
      if (tick == null)
        return;
      tick((object) this, e);
    }

    /// <summary>Sets or gets the timer id</summary>
    int ITimer.TimerID
    {
      get => this.mintTimerID;
      set => this.mintTimerID = value;
    }

    /// <summary>Gets the timer interval</summary>
    int ITimer.Interval => this.Interval;

    /// <summary>Gets timer enabled state</summary>
    bool ITimer.Enabled => this.Enabled;

    /// <summary>Invoke timer.</summary>
    int ITimer.InvokeTimer()
    {
      this.mlngLastTicks = DateTime.Now.Ticks;
      try
      {
        this.OnTick(EventArgs.Empty);
      }
      catch (Exception ex)
      {
        if (!((IApplicationContext) VWGContext.Current).HandleThreadException(ex))
          throw ex;
      }
      return ((ITimer) this).GetNextInvokation(this.mlngLastTicks);
    }

    /// <summary>Gets the next planed invocation.</summary>
    /// <param name="lngCurrentTicks"></param>
    int ITimer.GetNextInvokation(long lngCurrentTicks)
    {
      int nextInvokation = this.mintInterval - (int) TimeSpan.FromTicks(lngCurrentTicks - this.mlngLastTicks).TotalMilliseconds;
      if (nextInvokation < 0)
        nextInvokation = 0;
      return nextInvokation;
    }
  }
}
