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
	#region RichTextBoxController.cs Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class RichTextBoxController : TextBoxBaseController
	{
        #region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebRichTextBox"></param>
		/// <param name="objWinRichTextBox"></param>
		public RichTextBoxController(IContext objContext,object objWebRichTextBox,object objWinRichTextBox) :base(objContext,objWebRichTextBox,objWinRichTextBox)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebRichTextBox"></param>
		/// <param name="objWinRichTextBox"></param>
        public RichTextBoxController(IContext objContext, object objWebRichTextBox)
            : base(objContext, objWebRichTextBox)
		{
        }

        #endregion C'Tor/D'Tor

        protected override void InitializeController()
        {
            base.InitializeController();
        }

        protected override object CreateTargetObject(object objWebObject)
        {
            return new WinForms.RichTextBox();
        }

        /// <summary>
        ///
        /// </summary>
        public WebForms.RichTextBox WebRichTextBox
        {
            get
            {
                return base.SourceObject as WebForms.RichTextBox;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.RichTextBox WinRichTextBox
        {
            get
            {
                return base.TargetObject as WinForms.RichTextBox;
            }
        }
		
        protected override void SetWebControlText()
        {
          
        }
    }

    #endregion 
}