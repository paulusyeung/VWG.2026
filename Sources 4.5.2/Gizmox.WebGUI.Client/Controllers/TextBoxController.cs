#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel.Design;
using System.Collections;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TextBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class TextBoxController : TextBoxBaseController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTextBox"></param>
		/// <param name="objWinTextBox"></param>
		public TextBoxController(IContext objContext,object objWebTextBox,object objWinTextBox) :base(objContext,objWebTextBox,objWinTextBox)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTextBox"></param>
		/// <param name="objWinTextBox"></param>
		public TextBoxController(IContext objContext,object objWebTextBox) :base(objContext,objWebTextBox)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods


		protected override void InitializeController()
		{
			base.InitializeController();

			SetWinTextBoxPasswordChar();            
            SetWinTextBoxScrollbars();
		}

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "PasswordChar":
                    SetWinTextBoxPasswordChar();
                    break;
                case "ScrollBars":
                    SetWinTextBoxScrollbars();
                    break;
            }
        }

        protected virtual void SetWinTextBoxScrollbars()
        {
            this.WinTextBox.ScrollBars = (WinForms.ScrollBars)GetConvertedEnum(typeof(WinForms.ScrollBars), this.WebTextBox.ScrollBars, this.WinTextBox.ScrollBars);
        }

		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTextBoxPasswordChar()
		{
			this.WinTextBox.PasswordChar = this.WebTextBox.PasswordChar;
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.TextBox();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			WinTextBox.TextChanged+=new EventHandler(WinTextBox_TextChanged);
		}		
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinTextBox_TextChanged(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("ValueChange");
			objEvent.SetParameter(WGAttributes.Text,this.WinTextBox.Text);
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();

			WinTextBox.TextChanged-=new EventHandler(WinTextBox_TextChanged);
		}		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.TextBox WebTextBox
		{
			get
			{
				return base.SourceObject as WebForms.TextBox;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.TextBox WinTextBox
		{
			get
			{
				return base.TargetObject as WinForms.TextBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion TextBoxController Class
	
}
