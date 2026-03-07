using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Proxy ToolStripControlHost
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyToolStripControlHost : ProxyComponent
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolStripControlHost"/> class.
        /// </summary>
        public ProxyToolStripControlHost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolStripControlHost" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyToolStripControlHost(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent) 
        {
            AddContainedComponents(objComponent);
        }


        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the contained components.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddContainedComponents(Component objComponent)
        {
            ToolStripControlHost objToolStripControlHost = objComponent as ToolStripControlHost;
            if (objToolStripControlHost != null)
            {
                ProxyComponent objChildProxy = this.CreateProxyByComponent(objToolStripControlHost.Control);
                if (objChildProxy != null)
                {
                    this.Components.Add(objChildProxy);
                }
            }
        }

        /// <summary>
        /// Attaches the proxy.
        /// </summary>
        public void AttachProxy()
        {
            if (this.Components.Count > 0)
            {
                ProxyComponent objProxyComponent = this.Components[0];
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = objProxyComponent;
                }
            }
        }

        /// <summary>
        /// Des the attach proxy.
        /// </summary>
        public void DeAttachProxy()
        {
            if (this.Components.Count > 0)
            {
                ProxyComponent objProxyComponent = this.Components[0];
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = null;
                }
            }
        }

        #endregion Methods

    }
}
