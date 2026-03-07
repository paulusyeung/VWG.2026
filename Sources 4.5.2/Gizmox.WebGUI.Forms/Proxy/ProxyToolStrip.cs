
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
    /// Proxy ToolStrip
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyToolStrip : ProxyControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolStrip"/> class.
        /// </summary>
        public ProxyToolStrip()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolStrip" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyToolStrip(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent)
        {
            AddContainedComponents(objComponent);
            RegisterEvents(objComponent);
        }


        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the emulation - will occur whenever a proxy form is loaded from Xaml in recursion (from emulation form).
        /// </summary>
        internal override void InitializeProxy()
        {
            if (ProxyInitialized) { return; }

            Component objSourceComponent = this.SourceComponent;
            if (objSourceComponent != null)
            {
                AddContainedComponents(objSourceComponent);
                RegisterEvents(objSourceComponent);
            }

            SetProxyInitialized();
        }

        /// <summary>
        /// Registers the events.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void RegisterEvents(Component objComponent)
        {
            ToolStrip objToolStrip = objComponent as ToolStrip;
            if (objToolStrip != null)
            {
                objToolStrip.ItemAdded += new ToolStripItemEventHandler(objToolStrip_ItemAdded);
                objToolStrip.ItemRemoved += new ToolStripItemEventHandler(objToolStrip_ItemRemoved);                    
            }
        }

        /// <summary>
        /// Handles the ItemRemoved event of the objToolStrip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ToolStripItemEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void objToolStrip_ItemRemoved(object sender, ToolStripItemEventArgs e)
        {
            ToolStripItem objToolStripItem = e.Item as ToolStripItem;
            if (objToolStripItem != null)
            {
                ProxyComponent objProxyComponent = this.GetChildProxyComponent(objToolStripItem);
                if (objProxyComponent != null)
                {
                    UnsubscribeGetEventsWithChildren(objProxyComponent);
                    this.Components.Remove(objProxyComponent);
                }
            }
        }

        /// <summary>
        /// Handles the ItemAdded event of the objToolStrip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ToolStripItemEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void objToolStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            ToolStripItem objToolStripItem = e.Item as ToolStripItem;
            if (objToolStripItem != null)
            {
                ProxyComponent objChildProxy = this.CreateProxyByComponent(objToolStripItem);
                if (objChildProxy != null)
                {
                    SubscribeGetEventsWithChildren(objChildProxy);
                    this.Components.Add(objChildProxy);
                }
            }
        }

        /// <summary>
        /// Adds the contained components.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddContainedComponents(Component objComponent)
        {
            ToolStrip objToolStrip = objComponent as ToolStrip;
            if (objToolStrip != null)
            {
                foreach (ToolStripItem objToolStripItem in objToolStrip.Items)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objToolStripItem);
                    if (objChildProxy != null)
                    {
                        this.Components.Add(objChildProxy);
                    }
                }
            }
        }

        /// <summary>
        /// Renders the specified obj context.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = objProxyComponent;
                }

                ProxyToolStripControlHost objProxyHost = objProxyComponent as ProxyToolStripControlHost;
                if (objProxyHost != null)
                {
                    objProxyHost.AttachProxy();
                }
            }

            base.Render(objContext, objWriter, lngRequestID);

            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = null;
                }

                ProxyToolStripControlHost objProxyHost = objProxyComponent as ProxyToolStripControlHost;
                if (objProxyHost != null)
                {
                    objProxyHost.DeAttachProxy();
                }
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ProxySet Components
        {
            get
            {
                return base.Components;
            }
        }

        #endregion Properties 
    }
}