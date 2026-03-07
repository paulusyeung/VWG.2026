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
    /// Proxy TreeView
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyTreeView : ProxyControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTreeView"/> class.
        /// </summary>
        public ProxyTreeView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTreeView" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyTreeView(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent)
        {
            AddContainedComponents(objComponent);

            RegisterEvents(objComponent);
        }


        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the emulation.
        /// </summary>
        internal override void InitializeProxy()
        {
            if (ProxyInitialized) { return; }

            Component objSourceComponent = this.SourceComponent;
            AddContainedComponents(objSourceComponent);

            RegisterEvents(objSourceComponent);
            SetProxyInitialized();
        }

        /// <summary>
        /// Registers the events.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void RegisterEvents(Component objComponent)
        {
            TreeView objTreeView = objComponent as TreeView;
            if (objTreeView != null)
            {
                TreeNodeCollection objNodes = objTreeView.Nodes;
                objNodes.ObservableItemAdded += new ObservableListEventHandler(objNodes_ObservableItemAdded);
                objNodes.ObservableItemInserted += new ObservableListEventHandler(objNodes_ObservableItemAdded);
                objNodes.ObservableItemRemoved += new ObservableListEventHandler(objNodes_ObservableItemRemoved);
                objNodes.ObservableListCleared += new EventHandler(objNodes_ObservableListCleared);
            }
        }

        /// <summary>
        /// Handles the ObservableListCleared event of the objNodes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objNodes_ObservableListCleared(object sender, EventArgs e)
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
        /// Handles the ObservableItemRemoved event of the objNodes control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objNodes_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            TreeNode objTreeNode = objArgs.Item as TreeNode;
            if (objTreeNode != null)
            {
                ProxyComponent objProxyComponent = this.GetChildProxyComponent(objTreeNode);
                if (objProxyComponent != null)
                {
                    UnsubscribeGetEventsWithChildren(objProxyComponent);
                    this.Components.Remove(objProxyComponent);
                }
            }  
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the objNodes control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        private void objNodes_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            TreeNode objTreeNode = objArgs.Item as TreeNode;
            if (objTreeNode != null)
            {
                ProxyComponent objChildProxy = this.CreateProxyByComponent(objTreeNode);
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
            TreeView objTreeView = objComponent as TreeView;
            if (objTreeView != null)
            {
                foreach (TreeNode objTreeNode in objTreeView.Nodes)
                {
                    ProxyComponent objChildProxy = this.CreateProxyByComponent(objTreeNode);
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
            foreach (ProxyTreeNode objProxyTreeNode in this.Components)
            {
                objProxyTreeNode.AttachProxy(true);
            }

            base.Render(objContext, objWriter, lngRequestID);

            foreach (ProxyTreeNode objProxyTreeNode in this.Components)
            {
                objProxyTreeNode.AttachProxy(false);
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