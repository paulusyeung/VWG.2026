#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region UserControlController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
	
	public class UserControlController : ContainerControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public UserControlController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public UserControlController(IContext objContext,object objWebControl) :base(objContext,objWebControl)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Properties

        /// <summary>
        ///
        /// </summary>
        private IObservableLayoutItem WebLayoutItem
        {
            get
            {
                return base.SourceObject as IObservableLayoutItem;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		public WebForms.UserControl WebUserControl
		{
			get
			{
				return base.SourceObject as WebForms.UserControl;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.UserControl WinUserControl
		{
			get
			{
				return base.TargetObject as WinForms.UserControl;
			}
		}
		
		
		#endregion Properties
		
		#region Methods

        /// <summary>
        /// Initializes the new.
        /// </summary>
        public override void InitializeNew()
        {
            base.InitializeNew();

            // Suspend winforms layout
            this.WinControl.SuspendLayout();

            if (this.WebControl is WebForms.UserControl)
            {
                this.WinControl.ClientSize = this.WebLayoutItem.Size;
            }

            // Resume layour
            this.WinControl.ResumeLayout();
        }

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinUserControlAutoSizeMode();
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
                case "AutoSizeMode":
                    this.SetWinUserControlAutoSizeMode();
                    break;
            }
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
            return new WinForms.UserControl();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlLocation()
		{
			if (this.WebUserControl.Parent != null)
			{
				base.SetWinControlLocation();
			}
		}

        /// <summary>
        /// Sets the win user control auto size mode.
        /// </summary>
        protected virtual void SetWinUserControlAutoSizeMode()
        {
            this.WinUserControl.AutoSizeMode = (WinForms.AutoSizeMode)GetConvertedEnum(typeof(WinForms.AutoSizeMode), this.WebUserControl.AutoSizeMode);
        }
		
		#endregion Methods
		
	}
	
	#endregion UserControlController Class
	
}
