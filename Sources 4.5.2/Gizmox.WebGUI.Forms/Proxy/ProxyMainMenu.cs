using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Common.Configuration;
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Proxy ListView
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyMainMenu : ProxyControl
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyMainMenu"/> class.
        /// </summary>
        public ProxyMainMenu()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyMainMenu" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyMainMenu(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
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
            MainMenu objMainMenu = objComponent as MainMenu;
            if (objMainMenu != null)
            {
                MenuItemCollection objMenuItems = objMainMenu.MenuItems;
                objMenuItems.CollectionChanged += new NotifyCollectionChangedEventHandler(objMenuItems_CollectionChanged);
            }
        }

        /// <summary>
        /// Handles the CollectionChanged event of the objMenuItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void objMenuItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        MenuItem objMenuItem = e.NewItems[0] as MenuItem;
                        if (objMenuItem != null)
                        {
                            ProxyComponent objChildProxy = this.CreateProxyByComponent(objMenuItem);
                            if (objChildProxy != null)
                            {
                                SubscribeGetEventsWithChildren(objChildProxy);
                                this.Components.Add(objChildProxy);
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        MenuItem objMenuItem = e.OldItems[0] as MenuItem;
                        if (objMenuItem != null)
                        {
                            ProxyComponent objProxyComponent = this.GetChildProxyComponent(objMenuItem);
                            if (objProxyComponent != null)
                            {
                                UnsubscribeGetEventsWithChildren(objProxyComponent);
                                this.Components.Remove(objProxyComponent);
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
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
                    break;
            }
        }

        /// <summary>
        /// Adds the contained components.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddContainedComponents(Component objComponent)
        {
            MainMenu objMainMenu = objComponent as MainMenu;
            if (objMainMenu != null)
            {
                foreach (MenuItem objMenuItem in objMainMenu.MenuItems)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objMenuItem);
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