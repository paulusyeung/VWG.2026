#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region RadioButtonController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class RadioButtonController : ButtonBaseControler
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public RadioButtonController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public RadioButtonController(IContext objContext,object objWebTreeView) :base(objContext,objWebTreeView)
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
			SetWinRadioButtonChecked();
            SetWinCheckAlign();
            SetWinAppearance();
		}


        /// <summary>
        /// Sets the win check align.
        /// </summary>
        protected virtual void SetWinCheckAlign()
        {
            this.WinRadioButton.CheckAlign = this.WebRadioButton.CheckAlign;
        }

        /// <summary>
        /// Sets the win appearance.
        /// </summary>
        protected virtual void SetWinAppearance()
        {
            this.WinRadioButton.Appearance = (WinForms.Appearance)this.GetConvertedEnum(typeof(WinForms.Appearance), this.WebRadioButton.Appearance);
        }


        /// <summary>
        /// Sets the web check align.
        /// </summary>
        protected virtual void SetWebCheckAlign()
        {
            this.WebRadioButton.CheckAlign = this.WinRadioButton.CheckAlign;
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinRadioButtonChecked()
		{
			this.WinRadioButton.Checked = this.WebRadioButton.Checked;
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.RadioButton();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			this.WinRadioButton.CheckedChanged+=new EventHandler(WinCheckBox_CheckedChanged);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("ValueChange");
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinRadioButton.CheckedChanged-=new EventHandler(WinCheckBox_CheckedChanged);
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
                case "Checked":
                    SetWinRadioButtonChecked();
                    break;
                case "CheckAlign":
                    SetWinCheckAlign();
                    break;
                case "Appearance":
                    SetWinAppearance();
                    break;
            }
        }
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.RadioButton WebRadioButton
		{
			get
			{
				return base.SourceObject as WebForms.RadioButton;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.RadioButton WinRadioButton
		{
			get
			{
				return base.TargetObject as WinForms.RadioButton;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion RadioButtonController Class
	
}
