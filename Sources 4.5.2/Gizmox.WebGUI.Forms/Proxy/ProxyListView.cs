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
    /// Proxy ListView
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyListView : ProxyControl
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyListView"/> class. (this constructor will be initialized from Xaml desirialize)
        /// </summary>
        public ProxyListView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyListView" /> class. (this constructor will be initialized whenever a listview will be dragged to Emulator Form)
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyListView(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
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
            ListView objListView = objComponent as ListView;
            if (objListView != null)
            {
                ListView.ListViewItemCollection objItems = objListView.Items;
                objItems.ObservableItemAdded += new ObservableListEventHandler(Items_ObservableItemAdded);
                objItems.ObservableItemInserted += new ObservableListEventHandler(Items_ObservableItemAdded);
                objItems.ObservableItemRemoved += new ObservableListEventHandler(objItems_ObservableItemRemoved);
                objItems.ObservableListCleared += new EventHandler(objItems_ObservableListCleared);

                ListView.ColumnHeaderCollection objColumnHeaderCollection = objListView.Columns;
                objColumnHeaderCollection.ObservableItemAdded += new ObservableListEventHandler(objColumnHeaderCollection_ObservableItemAdded);
                objColumnHeaderCollection.ObservableItemInserted += new ObservableListEventHandler(objColumnHeaderCollection_ObservableItemAdded);
                objColumnHeaderCollection.ObservableItemRemoved += new ObservableListEventHandler(objColumnHeaderCollection_ObservableItemRemoved);
                objColumnHeaderCollection.ObservableListCleared += new EventHandler(objColumnHeaderCollection_ObservableListCleared);

                objListView.Controls.ObservableItemAdded += new ObservableListEventHandler(Controls_ObservableItemAdded);
                objListView.Controls.ObservableItemInserted += new ObservableListEventHandler(Controls_ObservableItemAdded);
                objListView.Controls.ObservableItemRemoved += new ObservableListEventHandler(Controls_ObservableItemRemoved);
            }
        }


        /// <summary>
        /// Handles the ObservableItemRemoved event of the Controls control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            Control objControl = objArgs.Item as Control;
            if (objControl != null)
            {
                RemoveSubComponent(objControl);
            }
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the Controls control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            Control objControl = objArgs.Item as Control;
            if (objControl != null)
            {
                AddSubComponent(objControl);
            }
        }

        /// <summary>
        /// Handles the ObservableListCleared event of the objColumnHeaderCollection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objColumnHeaderCollection_ObservableListCleared(object sender, EventArgs e)
        {
            ClearProxyComponents(typeof(ColumnHeader));
        }

        /// <summary>
        /// Handles the ObservableItemRemoved event of the objColumnHeaderCollection control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objColumnHeaderCollection_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            ColumnHeader objColumnHeader = objArgs.Item as ColumnHeader;
            if (objColumnHeader != null)
            {
                RemoveSubComponent(objColumnHeader);
            }
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the objColumnHeaderCollection control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objColumnHeaderCollection_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            ColumnHeader objColumnHeader = objArgs.Item as ColumnHeader;
            if (objColumnHeader != null)
            {
                AddSubComponent(objColumnHeader);
            }
        }

        /// <summary>
        /// Handles the ObservableListCleared event of the objItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objItems_ObservableListCleared(object sender, EventArgs e)
        {
            ClearProxyComponents(typeof(ListViewItem));
        }

        /// <summary>
        /// Handles the ObservableItemRemoved event of the objItems control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objItems_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            ListViewItem objListViewItem = objArgs.Item as ListViewItem;
            if (objListViewItem != null)
            {
                RemoveSubComponent(objListViewItem);
            }
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the Items control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void Items_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            ListViewItem objListViewItem = objArgs.Item as ListViewItem;
            if (objListViewItem != null)
            {
                AddSubComponent(objListViewItem);
            }
        }


        /// <summary>
        /// Clears the proxy components.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        private void ClearProxyComponents(Type objType)
        {
            GettingPropertyValueEventHandler objGettingPropertyValueEventHandler = this.GettingPropertyValueEventHandler;

            ProxyComponent[] objComponents = this.Components.ToArray();

            foreach (ProxyComponent objProxyComponent in objComponents)
            {
                if (objProxyComponent.SourceComponent != null)
                {
                    if (objProxyComponent.SourceComponent.GetType() == objType)
                    {
                        if (objGettingPropertyValueEventHandler != null)
                        {
                            objProxyComponent.GettingPropertyValue -= objGettingPropertyValueEventHandler;
                        }

                        this.Components.Remove(objProxyComponent);
                    }
                }
            }
        }

        /// <summary>
        /// Adds the sub component.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddSubComponent(Component objComponent)
        {
            ProxyComponent objChildProxyComponent = this.CreateProxyByComponent(objComponent);
            if (objChildProxyComponent != null)
            {
                SubscribeGetEventsWithChildren(objChildProxyComponent);
                this.Components.Add(objChildProxyComponent);
            }
        }

        /// <summary>
        /// Removes the sub component.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void RemoveSubComponent(Component objComponent)
        {
            ProxyComponent objChildProxyComponent = this.GetChildProxyComponent(objComponent);
            if (objChildProxyComponent != null)
            {
                UnsubscribeGetEventsWithChildren(objChildProxyComponent);
                this.Components.Remove(objChildProxyComponent);
            }
        }

        /// <summary>
        /// Adds the contained components.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddContainedComponents(Component objComponent)
        {
            ListView objListView = objComponent as ListView;
            if (objListView != null)
            {
                foreach (ColumnHeader objColumnHeader in objListView.Columns)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objColumnHeader);
                    if (objChildProxy != null)
                    {
                        this.Components.Add(objChildProxy);
                    }
                }

                foreach (ListViewItem objListViewItem in objListView.Items)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objListViewItem);
                    if (objChildProxy != null)
                    {
                        this.Components.Add(objChildProxy);
                    }
                }

                foreach (Control objControl in objListView.Controls)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objControl);
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