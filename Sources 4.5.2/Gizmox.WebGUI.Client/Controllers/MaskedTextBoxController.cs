#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MaskedTextBoxController : TextBoxBaseController
    {
        #region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public MaskedTextBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
        public MaskedTextBoxController(IContext objContext, object objWebTreeView) : base(objContext, objWebTreeView)
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

            SetWinMaskedTextBoxMask();
            SetWinMaskedTextBoxTextMaskFormat();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    SetWebControlText();
                    break;
            }
        }

        /// <summary>
        /// Called when [source object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Mask":
                    SetWinMaskedTextBoxMask();
                    break;

                case "TextMaskFormat":
                    SetWinMaskedTextBoxTextMaskFormat();
                    break;

                case "PasswordChar":
                    SetWinMaskedTextBoxPasswordChar();
                    break;
            }
        }

        /// <summary>
        /// Sets the win masked text box text mask format.
        /// </summary>
        protected void SetWinMaskedTextBoxTextMaskFormat()
        {
            this.WinMaskedTextBox.TextMaskFormat = (WinForms.MaskFormat)GetConvertedEnum(typeof(WinForms.MaskFormat), this.WebMaskedTextBox.TextMaskFormat, this.WinMaskedTextBox.TextMaskFormat);
        }

        /// <summary>
        /// Sets the win masked text box mask.
        /// </summary>
        protected void SetWinMaskedTextBoxMask()
        {
            this.WinMaskedTextBox.Mask = this.WebMaskedTextBox.Mask;
        }

        /// <summary>
        /// Sets the win masked text box password char.
        /// </summary>
        private void SetWinMaskedTextBoxPasswordChar()
        {
            this.WinMaskedTextBox.PasswordChar = this.WebMaskedTextBox.PasswordChar;
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.MaskedTextBox();
		}
		
		#endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.MaskedTextBox WebMaskedTextBox
        {
            get
            {
                return base.SourceObject as WebForms.MaskedTextBox;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.MaskedTextBox WinMaskedTextBox
        {
            get
            {
                return base.TargetObject as WinForms.MaskedTextBox;
            }
        }


        #endregion Properties
    }
}
