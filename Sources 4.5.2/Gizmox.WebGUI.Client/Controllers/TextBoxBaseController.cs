using System;
using System.Collections.Generic;
using System.Text;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextBoxBaseController : ControlController
    {
		#region Constructors

        /// <summary>
		///
		/// </summary>
		/// <param name="objWebTextBoxBase"></param>
		/// <param name="objWinTextBoxBase"></param>
		public TextBoxBaseController(IContext objContext,object objWebTextBoxBase,object objWinTextBoxBase) :base(objContext,objWebTextBoxBase,objWinTextBoxBase)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTextBoxBase"></param>
		/// <param name="objWinTextBoxBase"></param>
        public TextBoxBaseController(IContext objContext, object objWebTextBoxBase) : base(objContext, objWebTextBoxBase)
		{
		}

		#endregion Constructors 

		#region Properties

        /// <summary>
        /// Gets the web text box base.
        /// </summary>
        /// <value>The web text box base.</value>
        public WebForms.TextBoxBase WebTextBoxBase
        {
            get
            {
                return base.SourceObject as WebForms.TextBoxBase;
            }
        }

        /// <summary>
        /// Gets the win text box base.
        /// </summary>
        /// <value>The win text box base.</value>
        public WinForms.TextBoxBase WinTextBoxBase
        {
            get
            {
                return base.TargetObject as WinForms.TextBoxBase;
            }
        }

		#endregion Properties 

		#region Methods


        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinTextBoxBaseMultiline();
            SetWinTextBoxBaseReadOnly(); 
            SetWinControlBorderStyle();
        }

        protected override void OnSourceObjectPropertyChange(Gizmox.WebGUI.Common.Interfaces.ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Multiline":
                    SetWinTextBoxBaseMultiline();
                    break;
                case "ReadOnly":
                    SetWinTextBoxBaseReadOnly();
                    break;
                case "BorderStyle":
                    SetWinControlBorderStyle();
                    break;
                case "Lines":
                    SetWinTextBoxBaseLines();
                    break;
            }
        }

        /// <summary>
        /// Sets the win text box base lines.
        /// </summary>
        protected virtual void SetWinTextBoxBaseLines()
        {
            this.WinTextBoxBase.Lines = this.WebTextBoxBase.Lines;
        }

        /// <summary>
        /// </summary>
        protected override void SetWinControlBorderStyle()
        {
            this.WinTextBoxBase.BorderStyle = (WinForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle), this.WebTextBoxBase.BorderStyle, this.WinTextBoxBase.BorderStyle);
        }

        /// <summary>
        /// Sets the win text box base multiline.
        /// </summary>
        protected virtual void SetWinTextBoxBaseMultiline()
        {
            // Check if property has been change.
            if (this.WinTextBoxBase.Multiline != this.WebTextBoxBase.Multiline)
            {
                // Change win control's multiline property.
                this.WinTextBoxBase.Multiline = this.WebTextBoxBase.Multiline;
            }
        }

        /// <summary>
        /// Sets the win text box base read only.
        /// </summary>
        protected virtual void SetWinTextBoxBaseReadOnly()
        {
            this.WinTextBoxBase.ReadOnly = this.WebTextBoxBase.ReadOnly;
        }

        protected override void UnwireEvents()
        {
            base.UnwireEvents();

            WinTextBoxBase.KeyUp -= new System.Windows.Forms.KeyEventHandler(WinTextBoxBase_KeyUp);
            WinTextBoxBase.MultilineChanged -= new EventHandler(WinTextBoxBase_MultilineChanged);
        }

        /// <summary>
        /// </summary>
        protected override void WireEvents()
        {
            base.WireEvents();

            WinTextBoxBase.KeyUp += new System.Windows.Forms.KeyEventHandler(WinTextBoxBase_KeyUp);
            WinTextBoxBase.MultilineChanged += new EventHandler(WinTextBoxBase_MultilineChanged);
        }

        /// <summary>
        /// Handles the KeyUp event of the WinTextBoxBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void WinTextBoxBase_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == WinForms.Keys.Enter)
            {
                Event objEvent = CreateWebEvent("EnterKeyDown");
                objEvent.Fire();
            }
        }

        /// <summary>
        /// Handles the MultilineChanged event of the WinTextBoxBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinTextBoxBase_MultilineChanged(object sender, EventArgs e)
        {
            if (this.WinTextBoxBase.Multiline)
            {
                // Synch the web control's size.
                this.SetWebControlSize();
            }
        }


		#endregion Methods 
    }
}
