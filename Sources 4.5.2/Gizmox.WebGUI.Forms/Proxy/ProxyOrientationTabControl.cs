using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    public class ProxyOrientationTabControl : ProxyTabControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabControl" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyOrientationTabControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabControl"/> class.
        /// </summary>
        public ProxyOrientationTabControl()
        {
        }
    }
}
