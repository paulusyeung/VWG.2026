using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Hosts
{
    /// <summary>
    /// Provides a delegate for the hosted ASP.NET events
    /// </summary>
    public delegate void AspPageEventHandler(object sender, AspPageEventArgs e);


    /// <summary>
    /// Provides a base class for hosted ASP.NET events
    /// </summary>
    [Serializable()]
    public class AspPageEventArgs : EventArgs
    {
        /// <summary>
        /// The ASP.NET page.
        /// </summary>
        private System.Web.UI.Page mobjAspPage = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspPageEventArgs"/> class.
        /// </summary>
        /// <param name="objAspPage">The ASP.NET page.</param>
        internal AspPageEventArgs(System.Web.UI.Page objAspPage)
        {
            mobjAspPage = objAspPage;
        }

        /// <summary>
        /// Gets the ASP.NET page that fired this event.
        /// </summary>
        /// <value>The ASP.NET page.</value>
        public System.Web.UI.Page Page
        {
            get
            {
                return mobjAspPage;
            }
        }
    }


    /// <summary>
    /// Provides a delegate for the hosted ASP.NET events
    /// </summary>
    public delegate void AspControlEventHandler(object sender, AspControlEventArgs e);


    /// <summary>
    /// Provides a base class for hosted ASP.NET events
    /// </summary>
    [Serializable()]
    public class AspControlEventArgs : EventArgs
    {
        /// <summary>
        /// The ASP.NET control.
        /// </summary>
        private System.Web.UI.Control mobjAspControl = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspControlEventArgs"/> class.
        /// </summary>
        /// <param name="objAspControl">The ASP.NET control.</param>
        internal AspControlEventArgs(System.Web.UI.Control objAspControl)
        {
            mobjAspControl = objAspControl;
        }

        /// <summary>
        /// Gets the ASP.NET control that fired this event.
        /// </summary>
        /// <value>The ASP.NET control.</value>
        public System.Web.UI.Control Control
        {
            get
            {
                return mobjAspControl;
            }
        }
    }
    
}
