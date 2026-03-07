using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.Hosts
{
    
    /// <summary>
    /// Provides an Base class to Aspx box control
    /// </summary>
    [Serializable()]
    public class AspPageBase : AspPipeLinePage
    {

        private AspPageBox mobjPageContext = null;

        internal void SetHost(AspPageBox objPageContext)
        {
            mobjPageContext = objPageContext;
            VwgControlId = mobjPageContext.ID;
        }

        /// <summary>
        /// Gets the page context.
        /// </summary>
        /// <value>The page context.</value>
        protected AspPageBox PageContext
        {
            get
            {
                return mobjPageContext;
            }
        }
    }
}
