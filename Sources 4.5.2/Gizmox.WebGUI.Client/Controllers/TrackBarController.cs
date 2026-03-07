#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TrackBarController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TrackBarController : ControlController
	{
		#region Class Members

        private bool mblnOrientationInitialized = false;
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public TrackBarController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public TrackBarController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

			SetWinTrackBarMaximum();
			SetWinTrackBarMinimum();
			SetWinTrackBarValue();
            SetWinTrackBarOrientation();
            mblnOrientationInitialized = true;
            SetWinControlSize();
			SetWinTrackBarTickFrequency();
			SetWinTrackBarTickStyle();
		}

        /// <summary>
        /// </summary>
        protected override void SetWinControlSize()
        {
            //check that the Orientation property already initialized
            if (mblnOrientationInitialized)
            {
                base.SetWinControlSize();
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarTickStyle()
		{                        
            this.WinTrackBar.TickStyle = (WinForms.TickStyle)GetConvertedEnum(typeof(WinForms.TickStyle), this.WebTrackBar.TickStyle);
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarTickFrequency()
		{
			this.WinTrackBar.TickFrequency = this.WebTrackBar.TickFrequency;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarOrientation()
		{
            this.SetWinProperty("Orientation",(WinForms.Orientation)GetConvertedEnum(typeof(WinForms.Orientation),this.WebTrackBar.Orientation));
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarMaximum()
		{
			this.WinTrackBar.Maximum = this.WebTrackBar.Maximum;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarMinimum()
		{
			this.WinTrackBar.Minimum = this.WebTrackBar.Minimum;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTrackBarValue()
		{
            this.WinTrackBar.Value = this.WebTrackBar.Value;
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.TrackBar();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();

            // If not in design mode
            if (!this.DesignMode)
            {
                this.WinTrackBar.ValueChanged += new EventHandler(WinTrackBar_ValueChanged);
            }
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("ValueChange");
			objEvent.SetParameter(WGAttributes.Value,this.WinTrackBar.Value.ToString());
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();

            // If not in design mode
            if (!this.DesignMode)
            {
                this.WinTrackBar.ValueChanged -= new EventHandler(WinTrackBar_ValueChanged);
            }
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange (objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "Value":
				    SetWinTrackBarValue();
				    break;
				case "Minimum":
				    SetWinTrackBarMinimum();
				    break;
				case "Maximum":
				    SetWinTrackBarMaximum();
				    break;
				case "Orientation":
				    SetWinTrackBarOrientation();
				    break;
				case "TickFrequency":
				    SetWinTrackBarTickFrequency();
				    break;
                case "TickStyle":
                    SetWinTrackBarTickStyle();
                    break;
			}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.TrackBar WebTrackBar
		{
			get
			{
				return base.SourceObject as WebForms.TrackBar;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.TrackBar WinTrackBar
		{
			get
			{
				return base.TargetObject as WinForms.TrackBar;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion TrackBarController Class
	
}
