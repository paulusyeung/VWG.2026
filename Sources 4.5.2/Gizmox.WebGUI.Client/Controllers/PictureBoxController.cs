#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region PictureBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class PictureBoxController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PictureBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PictureBoxController(IContext objContext,object objWebTreeView) :base(objContext,objWebTreeView)
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
			SetWinPictureBoxImage();
            SetWinPictureBoxSizeMode();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinPictureBoxImage()
		{
			if(this.WebPictureBox.Image!=null)
			{
				this.WinPictureBox.Image = GetWinImageFromResourceHandle(this.WebPictureBox.Image);
			}
            else
            {
                this.WinPictureBox.Image = null;
            }
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinPictureBoxSizeMode()
        {
            this.WinPictureBox.SizeMode = (WinForms.PictureBoxSizeMode)GetConvertedEnum(typeof(WinForms.PictureBoxSizeMode), this.WebPictureBox.SizeMode, this.WebPictureBox.SizeMode);
        }

        /// <summary>
        /// Unwires wired design time events
        /// </summary>
        protected override void UnwireDesignTimeEvents()
        {
            base.UnwireDesignTimeEvents();

            this.WinPictureBox.SizeModeChanged -=new EventHandler(WinPictureBox_SizeModeChanged);
        }

        /// <summary>
        /// Wires required events for controller to work in design time
        /// </summary>
        protected override void WireDesignTimeEvents()
        {
            base.WireDesignTimeEvents();

            this.WinPictureBox.SizeModeChanged += new EventHandler(WinPictureBox_SizeModeChanged);
        }

        /// <summary>
        /// Handles the SizeModeChanged event of the WinPictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void WinPictureBox_SizeModeChanged(object sender, EventArgs e)
        {
            //In AutoSize mode the Gizmox web control takes its size from the 
            //Winforms design time calculation.
            if (this.WinPictureBox.SizeMode == WinForms.PictureBoxSizeMode.AutoSize)
            {
                this.SetWebControlSize();
            }
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.PictureBox();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
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
				case "Image":
				SetWinPictureBoxImage();
                break;
                case "SizeMode":
                SetWinPictureBoxSizeMode();
				break;
			}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.PictureBox WebPictureBox
		{
			get
			{
				return base.SourceObject as WebForms.PictureBox;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.PictureBox WinPictureBox
		{
			get
			{
				return base.TargetObject as WinForms.PictureBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion PictureBoxController Class
	
}
