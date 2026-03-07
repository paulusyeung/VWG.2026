#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region StatusBarPanelController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class StatusBarPanelController : ComponentController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public StatusBarPanelController(IContext objContext,object objWebLabel,object objWinLabel) :base(objContext,objWebLabel,objWinLabel)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public StatusBarPanelController(IContext objContext, object objWebLabel) : base(objContext, objWebLabel)
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
            SetWinStatusBarPanelText();
            SetWinStatusBarPanelWidth();
            SetWinStatusBarPanelAutoSize();
            SetWinStatusBarPanelAlignment();
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinStatusBarPanelText()
        {
            this.WinStatusBarPanel.Text = this.WebStatusBarPanel.Text;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinStatusBarPanelWidth()
        {
            this.WinStatusBarPanel.Width = Convert.ToInt32(this.WebStatusBarPanel.Width * TargetHorizontalScaleFactor);
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinStatusBarPanelAutoSize()
        {
            this.WinStatusBarPanel.AutoSize = (WinForms.StatusBarPanelAutoSize)GetConvertedEnum(typeof(WinForms.StatusBarPanelAutoSize), this.WebStatusBarPanel.AutoSize);
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinStatusBarPanelAlignment()
        {
            this.WinStatusBarPanel.Alignment = (WinForms.HorizontalAlignment)GetConvertedEnum(typeof(WinForms.HorizontalAlignment), this.WebStatusBarPanel.Alignment);
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.StatusBarPanel();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch(objPropertyChangeArgs.Property)
            {
                case "Text":
                    SetWinStatusBarPanelText();
                    break;
                case "Width":
                    SetWinStatusBarPanelWidth();
                    break;
                case "AutoSize":
                    SetWinStatusBarPanelAutoSize();
                    break;
                case "Alignment":
                    SetWinStatusBarPanelAlignment();
                    break;
            }
		}


		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.StatusBarPanel WebStatusBarPanel
		{
			get
			{
                return base.SourceObject as WebForms.StatusBarPanel;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.StatusBarPanel WinStatusBarPanel
		{
			get
			{
                return base.TargetObject as WinForms.StatusBarPanel;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion StatusBarPanelController Class
	
}
