#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region StatusBarController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class StatusBarController : ControlController
	{
		#region Class Members

        private StatusPanelCollectionController mobjStatusPanelCollectionController = null;

		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public StatusBarController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
            mobjStatusPanelCollectionController = new StatusPanelCollectionController(Context, objWebObject, this.WebStatusBar.Panels, this.WinStatusBar, this.WinStatusBar.Panels);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public StatusBarController(IContext objContext, object objWebObject) : base(objContext, objWebObject)
		{
            mobjStatusPanelCollectionController = new StatusPanelCollectionController(Context, objWebObject, this.WebStatusBar.Panels, this.WinStatusBar, this.WinStatusBar.Panels);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
            SetWinStatusBarShowPanels();
		}
		
		/// <summary>
		///
		/// </summary>
        protected override void InitializedContained()
        {
            mobjStatusPanelCollectionController.Initialize();
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.StatusBar();
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinStatusBarShowPanels()
        {
            this.WinStatusBar.ShowPanels = this.WebStatusBar.ShowPanels;
        }
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ShowPanels":
                    SetWinStatusBarShowPanels();
                    break;
                case "Panels":
                    InitializedContained();
                    break;
            }
			
		}


        public override void Clear()
        {
            base.Clear();

            if (this.mobjStatusPanelCollectionController != null)
            {
                mobjStatusPanelCollectionController.Clear();
            }
        }

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjStatusPanelCollectionController != null)
            {
                mobjStatusPanelCollectionController.Terminate();
            }
        }



		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.StatusBar WebStatusBar
		{
			get
			{
                return base.SourceObject as WebForms.StatusBar;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.StatusBar WinStatusBar
		{
			get
			{
                return base.TargetObject as WinForms.StatusBar;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion StatusBarController Class
	
}
