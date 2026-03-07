#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region HtmlBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class HtmlBoxController : PlaceHolderController
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
		public HtmlBoxController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public HtmlBoxController(IContext objContext, object objWebObject) : base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        protected override void InitializeController()
        {
            base.InitializeController();
            SetWinHtmlBoxContent();
        }

        protected override object CreateTargetObject(object objWebObject)
        {
            return new Gizmox.WebGUI.Client.Forms.ClientHtmlBox();
        }


        /// <summary>
        /// Sets the win control text and tooltip.
        /// </summary>
        protected override void SetWinControlTextAndTooltip()
        {
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Content":
                    SetWinHtmlBoxContent();
                    break;
            }
        }

        protected virtual void SetWinHtmlBoxContent()
        {
            switch (this.WebHtmlBox.Type)
            {
                case Gizmox.WebGUI.Forms.HtmlBoxType.HTML:
                    this.WinHtmlBox.Html = this.WebHtmlBox.Html;

                    break;
                case Gizmox.WebGUI.Forms.HtmlBoxType.URL:

                    break;
                case Gizmox.WebGUI.Forms.HtmlBoxType.UNC:

                    break;
                case Gizmox.WebGUI.Forms.HtmlBoxType.RESOURCE:

                    break;
            }
        }

        protected override void SetWinControlText()
        {
        }

        protected WebForms.HtmlBox WebHtmlBox
        {
            get
            {
                return this.WebComponent as WebForms.HtmlBox;
            }
        }

        protected Gizmox.WebGUI.Client.Forms.ClientHtmlBox WinHtmlBox
        {
            get
            {
                return this.WinComponent as Gizmox.WebGUI.Client.Forms.ClientHtmlBox;
            }
        }
		
	}
	
	#endregion HtmlBoxController Class
	
}
