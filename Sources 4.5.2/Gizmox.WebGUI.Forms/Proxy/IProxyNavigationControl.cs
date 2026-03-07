using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    public interface IProxyNavigationControl
    {
        /// <summary>
        /// Gets new view.
        /// </summary>
        /// <returns></returns>
        ProxyControl AddNew();

        /// <summary>
        /// Deleted a view
        /// </summary>
        /// <param name="objProxyTabPage"></param>
        void RemoveCurrent();

        /// <summary>
        /// Occurs when count change.
        /// </summary>
        event EventHandler CountChange;
    }
}
