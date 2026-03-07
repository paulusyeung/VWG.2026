#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region PlaceHolderController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class PlaceHolderController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public PlaceHolderController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public PlaceHolderController(IContext objContext, object objWebObject)
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		: base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			WinForms.Button objPlaceHolder =  new WinForms.Button();
            objPlaceHolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            objPlaceHolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            objPlaceHolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			return objPlaceHolder;
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWebControlText()
		{
			
		}

        internal override void SetWebControlControls()
        {
            
        }

        protected override void SetWinControlText()
        {
            SetWinControlTextAndTooltip();
        }

        protected virtual void SetWinControlTextAndTooltip()
        {
            this.WinControl.Text = string.Format("{0}\n({1})", this.WebControl.Name, this.WebControl.GetType().Name);
            WinForms.ToolTip objTooltip = new System.Windows.Forms.ToolTip();
            objTooltip.SetToolTip(this.WinControl, this.WebControl.GetType().FullName);
        }
		
		
		#endregion Methods

        public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "Name":
                    SetWinControlTextAndTooltip();
                    break;
            }
            base.FireWebPropertyChanged(objPropertyChangeArgs);
        }
		
	}
	
	#endregion PlaceHolderController Class
	
}
