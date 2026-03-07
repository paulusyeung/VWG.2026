#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ScrollableControlController Class
	
	/// <summary>
	/// Controls the relations between a webgui scrollable control and a winforms scrollable control
	/// </summary>
	
	public class ScrollableControlController : ControlController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ScrollableControlController(IContext objContext,object objWebScrollableControl,object objWinScrollableControl) :base(objContext,objWebScrollableControl,objWinScrollableControl)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		public ScrollableControlController(IContext objContext,object objWebScrollableControl) :base(objContext,objWebScrollableControl)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ScrollableControl WebScrollableControl
		{
			get
			{
				return base.SourceObject as WebForms.ScrollableControl;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ScrollableControl WinScrollableControl
		{
			get
			{
				return base.TargetObject as WinForms.ScrollableControl;
			}
		}
		
		
		#endregion Properties
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinScrollableControlAutoScroll();

            this.SuspendNotifications();
            try
            {
                SetWinScrollableControlDockPadding();
            }
            finally
            {
                this.ResumeNotifications();
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinScrollableControlAutoScroll()
		{
			this.WinScrollableControl.AutoScroll = this.WebScrollableControl.AutoScroll;
		}
		
		/// <summary>
		///
		/// </summary>
		protected void SetWinScrollableControlDockPadding()
		{
            this.WinScrollableControl.DockPadding.Bottom = this.WebScrollableControl.DockPadding.Bottom;
            this.WinScrollableControl.DockPadding.Top = this.WebScrollableControl.DockPadding.Top;
            this.WinScrollableControl.DockPadding.Right = this.WebScrollableControl.DockPadding.Right;
            this.WinScrollableControl.DockPadding.Left = this.WebScrollableControl.DockPadding.Left;
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ScrollableControl();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			
			switch (objPropertyChangeArgs.Property)
			{
				case "DockPadding":
				    SetWinScrollableControlDockPadding();
				    break;
				case "AutoScroll":
				    SetWinScrollableControlAutoScroll();
				    break;
                case "Unknown":
                    SetWinScrollableControlDockPadding();
                    break;
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion ScrollableControlController Class
	
}
