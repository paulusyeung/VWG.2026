#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Forms.Hosts;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
    #region FormBoxDesigner Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>    
	public class FormBoxDesigner : System.Web.UI.Design.ControlDesigner
    {
        private static readonly string PlaceHolderDesignTimeHtmlTemplate = "<table cellpadding=4 cellspacing=0 style=\"width:{2}; height:{3}; font:messagebox;color:buttontext;background-color:buttonface;border: solid 1px;border-top-color:buttonhighlight;border-left-color:buttonhighlight;border-bottom-color:buttonshadow;border-right-color:buttonshadow\">\r\n              <tr><td nowrap style=\"vertical-align:top;\" ><span style=\"font-weight:bold\">{0}</span> - {1}</td></tr>\r\n</table>";

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public FormBoxDesigner()
        {
        }


        #endregion C'Tor/D'Tor


        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
        }

        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Retrieves the HTML markup that is used to represent the control at design time.
        /// </summary>
        /// <returns>
        /// The HTML markup used to represent the control at design time.
        /// </returns>
        public override string GetDesignTimeHtml()
        {
            string strName     = base.Component.GetType().Name;
            string strSite     = base.Component.Site.Name;
            string strWidth    = ((FormBox)base.Component).Width.ToString();
            string strHeight   = ((FormBox)base.Component).Height.ToString();

            return string.Format(CultureInfo.InvariantCulture, PlaceHolderDesignTimeHtmlTemplate, new object[] { strName, strSite, strWidth, strHeight});
        }
    }

    #endregion TrackBarController Class

}
