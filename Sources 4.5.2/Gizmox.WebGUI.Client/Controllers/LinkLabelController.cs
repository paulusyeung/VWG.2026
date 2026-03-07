#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region LinkLabelController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class LinkLabelController : LabelController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public LinkLabelController(IContext objContext,object objWebLabel,object objWinLabel) :base(objContext,objWebLabel,objWinLabel)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public LinkLabelController(IContext objContext, object objWebLabel)
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebLabel"></param>
		: base(objContext, objWebLabel)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        protected override void InitializeController()
        {
            base.InitializeController();
            SetWinLinkLabelLinkColor();

        }
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.LinkLabel();
		}

        protected virtual void SetWinLinkLabelLinkColor()
        {
            this.WinLinkLabel.LinkColor = this.WebLinkLabel.LinkColor;
        }


        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);


            switch (objPropertyChangeArgs.Property)
            {
                case "LinkColor":
                    SetWinLinkLabelLinkColor();
                    break;
            }
        }
         
		#region Events
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.LinkLabel WebLinkLabel
		{
			get
			{
				return base.SourceObject as WebForms.LinkLabel;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.LinkLabel WinLinkLabel
		{
			get
			{
				return base.TargetObject as WinForms.LinkLabel;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion LinkLabelController Class
	
}
