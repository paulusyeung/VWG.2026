#region Using

using System;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using System.ComponentModel;
using System.Globalization;

#endregion Using

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers
{
	#region MaskedComboBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class MaskedComboBoxController : ComboBoxController
	{
		#region Class Members
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public MaskedComboBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public MaskedComboBoxController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            // Update win combo text
            SetWinMaskedComboBoxText();
        }

        /// <summary>
        /// Called when [source object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "PromptChar":
                case "Mask":
                case "Text":
                    SetWinMaskedComboBoxText();
                    break;
                default:
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        /// <summary>
        /// Sets the win masked combo box text.
        /// </summary>
        protected virtual void SetWinMaskedComboBoxText()
        {
            // Get mask value
            string strMask = this.WebMaskedComboBox.Mask;
            // Check if mask is empty
            if (string.IsNullOrEmpty(strMask))
            {
                strMask = "<>";
            }
            // Create MaskedTextProvider
            MaskedTextProvider maskedTextProvider = new MaskedTextProvider(strMask, CultureInfo.CurrentCulture);
            maskedTextProvider.PromptChar = this.WebMaskedComboBox.PromptChar;
            maskedTextProvider.IncludeLiterals = true;
            maskedTextProvider.IncludePrompt = true;
            maskedTextProvider.Set(this.WebMaskedComboBox.Text);

            // Update win control text
            this.WinMaskedComboBox.Text = maskedTextProvider.ToString();
        }
		
		#region Events

		#endregion Events
		
		#endregion Methods
		
		#region Properties

        /// <summary>
        /// Gets the web masked combo box.
        /// </summary>
        /// <value>The web masked combo box.</value>
        public WebForms.MaskedComboBox WebMaskedComboBox
		{
			get
			{
				return base.SourceObject as WebForms.MaskedComboBox;
			}
		}

        /// <summary>
        /// Gets the win masked combo box.
        /// </summary>
        /// <value>The win masked combo box.</value>
        public WinForms.ComboBox WinMaskedComboBox
		{
			get
			{
				return base.TargetObject as WinForms.ComboBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion MaskedComboBoxController Class
}