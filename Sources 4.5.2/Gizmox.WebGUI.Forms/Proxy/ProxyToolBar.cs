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
    /// Proxy ToolBar
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyToolBar : ProxyControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolBar"/> class.
        /// </summary>
        public ProxyToolBar()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyToolBar" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyToolBar(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
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
            ToolBar objToolBar = objComponent as ToolBar;
            if (objToolBar != null)
            {
                ToolBarItemCollection objButtons = objToolBar.Buttons;
                objButtons.ObservableItemAdded += new ObservableListEventHandler(objButtons_ObservableItemAdded);
                objButtons.ObservableItemInserted += new ObservableListEventHandler(objButtons_ObservableItemAdded);
                objButtons.ObservableItemRemoved += new ObservableListEventHandler(objButtons_ObservableItemRemoved);
                objButtons.ObservableListCleared += new EventHandler(objButtons_ObservableListCleared);
            }
        }

        /// <summary>
        /// Handles the ObservableListCleared event of the objButtons control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objButtons_ObservableListCleared(object sender, EventArgs e)
        {
            GettingPropertyValueEventHandler objGettingPropertyValueEventHandler = this.GettingPropertyValueEventHandler;

            ProxyComponent[] objComponents = this.Components.ToArray();

            foreach (ProxyComponent objProxyComponent in objComponents)
            {
                if (objProxyComponent.SourceComponent != null)
                {
                    UnsubscribeGetEventsWithChildren(objProxyComponent);
                    this.Components.Remove(objProxyComponent);
                }
            }
        }

        /// <summary>
        /// Handles the ObservableItemRemoved event of the objButtons control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        void objButtons_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            ToolBarButton objToolBarButton = objArgs.Item as ToolBarButton;
            if (objToolBarButton != null)
            {
                ProxyComponent objProxyComponent = this.GetChildProxyComponent(objToolBarButton);
                if (objProxyComponent != null)
                {
                    UnsubscribeGetEventsWithChildren(objProxyComponent);
                    this.Components.Remove(objProxyComponent);
                }
            }
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the objButtons control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objButtons_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            ToolBarButton objToolBarButton = objArgs.Item as ToolBarButton;
            if (objToolBarButton != null)
            {
                ProxyComponent objChildProxy = this.CreateProxyByComponent(objToolBarButton);
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
            ToolBar objToolBar = objComponent as ToolBar;
            if (objToolBar != null)
            {
                foreach (ToolBarButton objToolBarButton in objToolBar.Buttons)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objToolBarButton);
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
            }

            base.Render(objContext, objWriter, lngRequestID);

            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = null;
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