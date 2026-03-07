#region Using

using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Web;
using System.Reflection;
using System.Collections;
using System.Drawing.Design;
using System.Collections.Specialized;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using System.Drawing;

#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Resources;
using System.Drawing;
using Gizmox.WebGUI.Forms.Client;
#endif

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Component Class

    /// <summary>
    /// The base class for all GUI elements
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
#if WG_NET46
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET452
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET451
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET45
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET40
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET35
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#elif WG_NET2
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#else
    [System.ComponentModel.Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(System.ComponentModel.Design.IDesigner))]
#endif
    [Serializable(), ProxyComponent(typeof(ProxyComponent))]
    public class Component : RegisteredComponent, IObservableItem, IAttributeExtender
    {

        #region AttributeWrapper Class

        /// <summary>
        /// Provides support for adding extended attributes
        /// </summary>
        [Serializable()]
        private sealed class AttributesWrapper : SerializableObject, IEnumerable
        {
            /// <summary>
            /// The internal attribute collection
            /// </summary>
            [NonSerialized]
            private Dictionary<string, string> mobjAttributes = null;

            /// <summary>
            /// Indicates last render identifiers
            /// </summary>
            [NonSerialized]
            private long mlngLastModified;

            /// <summary>
            /// Initializes a new instance of the <see cref="AttributesWrapper"/> class.
            /// </summary>
            public AttributesWrapper()
            {
                mobjAttributes = new Dictionary<string, string>();
            }

            /// <summary>
            /// The size of the initiale serialization data array which is the optmized serialization graph.
            /// </summary>
            /// <value></value>
            /// <remarks>
            /// This value should be the actual size needed so that re-allocations and truncating will not be required.
            /// </remarks>
            protected override int SerializableDataInitialSize
            {
                get
                {
                    return base.SerializableDataInitialSize + 2;
                }
            }

            /// <summary>
            /// Called when serializable object is deserialized and we need to extract the optimized
            /// object graph to the working graph.
            /// </summary>
            /// <param name="objReader">The optimized object graph reader.</param>
            protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
            {
                base.OnSerializableObjectDeserializing(objReader);

                // Read the last modified value
                mlngLastModified = objReader.ReadInt64();

                // Read the attribute dictionary
                mobjAttributes = objReader.ReadDictionary<string, string>();
            }

            /// <summary>
            /// Called before serializable object is serialized to optimize the application object graph.
            /// </summary>
            /// <param name="objWriter">The optimized object graph writer.</param>
            protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
            {
                base.OnSerializableObjectSerializing(objWriter);

                // Write the last modified value
                objWriter.WriteInt64(mlngLastModified);

                // Write the attribute dictionary
                objWriter.WriteDictionary<string, string>(mobjAttributes);
            }

            /// <summary>
            /// Gets or sets the <see cref="System.String"/> with the specified name.
            /// </summary>
            /// <value></value>
            public string this[string strName]
            {
                get
                {
                    if (mobjAttributes.ContainsKey(strName))
                    {
                        return (string)mobjAttributes[strName];
                    }
                    return null;
                }
                set
                {
                    mlngLastModified = GetCurrentTicks();

                    if (value != null)
                    {
                        mobjAttributes[strName] = value;
                    }
                    else if (mobjAttributes.ContainsKey(strName))
                    {
                        mobjAttributes.Remove(strName);
                    }
                }
            }

            public void RenderAttributes(IAttributeWriter attributeWriter, long lngRequestID)
            {
                if (mlngLastModified > lngRequestID)
                {
                    foreach (string strName in this)
                    {
                        attributeWriter.WriteAttributeString(strName, this[strName]);
                    }
                }
            }

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return mobjAttributes.Keys.GetEnumerator();
            }

            #endregion
        }

        #endregion

        #region Class Members

        /// <summary>Occurs when a drag-and-drop operation is completed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatDragDrop"), SRDescription("ControlOnDragDropDescr")]
        public virtual event DragEventHandler DragDrop
        {
            add
            {
                this.AddHandler(Component.DragDropEvent, value);
            }
            remove
            {
                this.RemoveHandler(Component.DragDropEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DragDrop event.
        /// </summary>
        private DragEventHandler DragDropHandler
        {
            get
            {
                return (DragEventHandler)this.GetHandler(Component.DragDropEvent);
            }
        }

        /// <summary>
        /// The DragDrop event registration.
        /// </summary>
        private static readonly SerializableEvent DragDropEvent = SerializableEvent.Register("DragDrop", typeof(DragEventHandler), typeof(Component));

        /// <summary>
        /// Represent a swipe event handler.
        /// </summary>
        public delegate void SwipeEventHandler(Component objSource, SwipeDirection enmSwipeDirection);

        /// <summary>
        /// Occurs when [swipe].
        /// </summary>
        public virtual event SwipeEventHandler Swipe
        {
            add
            {
                this.AddCriticalHandler(Component.SwipeEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Component.SwipeEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DragDrop event.
        /// </summary>
        private SwipeEventHandler SwipHandler
        {
            get
            {
                return (SwipeEventHandler)this.GetHandler(Component.SwipeEvent);
            }
        }

        /// <summary>
        /// The DragDrop event registration.
        /// </summary>
        private static readonly SerializableEvent SwipeEvent = SerializableEvent.Register("Swipe", typeof(SwipeEventHandler), typeof(Component));

        /// <summary>
        /// Invokes when a menu item was clicked
        /// </summary>
        public virtual event MenuEventHandler MenuClick
        {
            add
            {
                this.AddHandler(Component.MenuClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(Component.MenuClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the MenuClick event.
        /// </summary>
        private MenuEventHandler MenuClickHandler
        {
            get
            {
                return (MenuEventHandler)this.GetHandler(Component.MenuClickEvent);
            }
        }
        /// <summary>
        /// The ContextMenuStripChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ContextMenuStripChangedEvent = SerializableEvent.Register("ContextMenuStripChanged", typeof(EventHandler), typeof(Component));


        /// <summary>
        /// Occurs when the value of the <see cref="P:System.Windows.Forms.Control.ContextMenuStrip"></see> property changes.
        /// </summary>
        [SRDescription("ControlContextMenuStripChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler ContextMenuStripChanged
        {
            add
            {
                this.AddHandler(Component.ContextMenuStripChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Component.ContextMenuStripChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ContextMenuStripChanged event.
        /// </summary>
        private EventHandler ContextMenuStripChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Component.ContextMenuStripChangedEvent);
            }
        }

        /// <summary>
        /// The MenuClick event registration.
        /// </summary>
        private static readonly SerializableEvent MenuClickEvent = SerializableEvent.Register("MenuClick", typeof(MenuEventHandler), typeof(Component));

        private static SkinResourceHandle mobjEmptyGif;

        /// <summary>
        /// The proxy component representing the object during emulations. Will be populated during render time.
        /// </summary>
        private ProxyComponent mobjProxyComponent;

        /// <summary>
        /// The win forms compatibility
        /// </summary>
        private WinFormsCompatibility mobjWinFormsCompatibility;

        #endregion

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="Component"/> instance.
        /// </summary>
        public Component()
        {
            this.SetState(ComponentState.AllowDrag, true);
            // Set the default animation state
            this.SetState(ComponentState.AnimationEnabled, this.DefaultAnimation);
            // Setting default value for dropping indicator
            this.SetState(ComponentState.DropIndicatorPropogation, true);
        }

        #endregion

        #region Methods

        #region State Methods

        /// <summary>
        /// The component state
        /// </summary>
        [NonSerialized()]
        private int mintComponentState = 0;

        [Flags]
        internal enum ComponentState : int
        {
            /// <summary>
            /// The visible state flag
            /// </summary>
            Visible = 1,

            /// <summary>
            /// The enabled state flag
            /// </summary>
            Enabled = 2,

            /// <summary>
            /// The selected flag
            /// </summary>
            Selected = 8,

            /// <summary>
            /// The checked flag
            /// </summary>
            Checked = 16,

            /// <summary>
            /// The initializing flag
            /// </summary>
            Initializing = 32,

            /// <summary>
            /// the allow drop flag
            /// </summary>
            AllowDrop = 128,

            /// <summary>
            /// The loaded flag
            /// </summary>
            Loaded = 256,

            /// <summary>
            /// The read only flag
            /// </summary>
            ReadOnly = 512,

            /// <summary>
            /// The animation enabled flag
            /// </summary>
            AnimationEnabled = 2048,

            /// <summary>
            /// The click once flag
            /// </summary>
            ClickOnce = 4096,

            /// <summary>
            /// The auto allipsis flag
            /// </summary>
            AutoEllipsis = 8192,

            /// <summary>
            /// The allow drag flag
            /// </summary>
            AllowDrag = 16384,

            /// <summary>
            /// The propogation of drop target indicator
            /// </summary>
            DropIndicatorPropogation = 32768
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="intFlag">The flag to set.</param>
        /// <param name="blnValue">The flag value to set.</param>
        internal void SetState(ComponentState enmState, bool blnValue)
        {
            this.mintComponentState = blnValue ? (this.mintComponentState | ((int)enmState)) : (this.mintComponentState & ~((int)enmState));
        }

        /// <summary>
        /// Sets the state and returns a flag if value had changed.
        /// </summary>
        /// <param name="intFlag">The flag to set.</param>
        /// <param name="blnValue">The flag value to set.</param>
        internal bool SetStateWithCheck(ComponentState enmState, bool blnValue)
        {
            // Check if the value had changed
            if (GetState(enmState) != blnValue)
            {
                SetState(enmState, blnValue);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="intFlag">The flag to get.</param>
        /// <returns></returns>
        internal bool GetState(ComponentState enmState)
        {
            return ((this.mintComponentState & ((int)enmState)) != 0);
        }

        #endregion

        #region Render

        /// <summary>
        /// Register the LoadingMessage property
        /// </summary>
        private static SerializableProperty LoadingMessageProperty = SerializableProperty.Register("LoadingMessage", typeof(string), typeof(Component), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Renders the component update attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected void RenderComponentUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            // Render control identifier
            objWriter.WriteAttributeString(WGAttributes.Id, this.GetProxyPropertyValue<long>("ID", this.ID).ToString());

            // Render drag and drop attributes.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Drag))
            {
                this.RenderDragAndDropAttributes(objContext, objWriter, true);
            }

            // Render component event attributes.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
            {
                this.RenderComponentEventAttributes(objContext, objWriter, true);
            }

            // Render component transition attributes.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
            {
                this.RenderComponentVisualEffectsAttributes(objContext, objWriter);
            }

            // Render component client id.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                this.RenderClientID(objWriter, true);
            }

            // Render update handler attribute.
            RenderClientUpdateHandler(objContext, objWriter, true);

            // Render use client update attribute.
            RenderUseClientUpdateHandlerAttribute(objContext, objWriter);

            // Renders the swipable attribute
            RenderSwipableAttribute(objWriter);
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected void RenderComponentAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // Renders the component's ID.
            RenderComponentID(objWriter);

            // Renders the component's client id.
            RenderClientID(objWriter, false);

            /// Renders the is dirty attributes.
            RenderIsDirtyAttributes(objContext, objWriter);

            // render event attributes
            RenderComponentEventAttributes(objContext, objWriter, false);

            // Render update handler attribute.
            RenderClientUpdateHandler(objContext, objWriter, false);

            // Render use client update attribute.
            RenderUseClientUpdateHandlerAttribute(objContext, objWriter);

            // Render animation support
            RenderAnimationAttributes(objWriter);

            // Render component transition attributes
            this.RenderComponentVisualEffectsAttributes(objContext, objWriter);

            // Renders the component's client events propogation tags.
            RenderClientEventsPropogationTags(objWriter);

            // Render CustomTemplate attributes.
            string strCustomTemplate = this.CustomTemplate;
            if (!string.IsNullOrEmpty(strCustomTemplate))
            {
                objWriter.WriteAttributeString(WGAttributes.CustomTemplate, strCustomTemplate);
            }

            // Get the loading message for the component
            string strLoadingMessage = this.GetValue<string>(Component.LoadingMessageProperty);

            // If there is a valid loading message
            if (!string.IsNullOrEmpty(strLoadingMessage))
            {
                objWriter.WriteAttributeText(WGAttributes.LoadingMessage, strLoadingMessage);
            }

            // render context menu if needed
            ContextMenu objContextMenu = this.ContextMenuInherited;
            if (objContextMenu != null)
            {
                // Write context id attribute which will enable the client to call the context menu
                objWriter.WriteAttributeString(WGAttributes.Menu, objContextMenu.ID.ToString());
            }

            // Renders the swipable attribute
            RenderSwipableAttribute(objWriter);

            // Render client invocation
            RenderClientInvocation(objContext, objWriter);

            // Render extended component attributes.
            RenderExtendedComponentAttributes(objContext, objWriter);

            // Render drag and drop attributes.
            this.RenderDragAndDropAttributes(objContext, objWriter, false);

            // Check auto generate client unique id configuration.
            if (this.Context.Config.EnableAutomationIds)
            {
                // Try get local uinque id.
                if (string.IsNullOrEmpty(((IAttributeExtender)this).GetAttribute(WGAttributes.ClientUniqeId)))
                {
                    // Get this component unique id.
                    string strClientUniqeId = this.GetComponentUniqueID(this.Form, this);
                    if (!string.IsNullOrEmpty(strClientUniqeId))
                    {
                        // Render client component unique id.
                        objWriter.WriteAttributeText(WGAttributes.ClientUniqeId, strClientUniqeId);
                    }
                }
            }
        }

        /// <summary>
        /// Renders the is dirty attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected internal void RenderIsDirtyAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            IContextParams objContextParams = objContext as IContextParams;
            if (objContextParams != null)
            {
                long inlLastRender = objContextParams.LastRender;

                if (inlLastRender != 0)
                {
                    if ((this.IsDirty(inlLastRender) || this.IsDirtyAttributes(inlLastRender)) && this.ShouldRenderIsDirtyAttribute(inlLastRender))
                    {
                        objWriter.WriteAttributeString(WGAttributes.IsDirty, "1");
                    }
                }
            }
        }

        /// <summary>
        /// Renders the component's ID.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderComponentID(IAttributeWriter objWriter)
        {
            // Render component's id.
            objWriter.WriteAttributeString(WGAttributes.Id, this.GetProxyPropertyValue<long>("ID", this.ID).ToString());
        }

        /// <summary>
        /// Renders the component's ID.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderClientID(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (blnForceRender || !string.IsNullOrEmpty(this.ClientId))
            {
                // Render component's client id.
                objWriter.WriteAttributeString(WGAttributes.ClientId, this.ClientId);
            }
        }

        /// <summary>
        /// Renders the swipable attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderSwipableAttribute(IAttributeWriter objWriter)
        {
            // Check if this component is swipable.
            if (this.SwipHandler != null)
            {
                // Render swipable attribute.
                objWriter.WriteAttributeString(WGAttributes.Swipable, "1");
            }
        }

        /// <summary>
        /// Renders the client invocation mapping if needed.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected internal void RenderClientInvocation(IContext objContext, IAttributeWriter objWriter)
        {           
            if (ShouldRenderClientEvents)
            {
                // Render registerd client invocation if exists
                RegisteredClientAction objRegisteredClientAction = this.ClientAction;
                if (objRegisteredClientAction != null)
                {
                    objRegisteredClientAction.RenderAttributes((IContextMethodInvoker)objContext, objWriter);
                }
            }
        }

        /// <summary>
        /// Returns the component client events list.
        /// </summary>
        protected override ClientEventList GetClientEvents()
        {
            ClientEventList objResult = GetProxyPropertyValue<ClientEventList>("ClientEvents", null);
            if (objResult != null) { return objResult; }

            return base.GetClientEvents();
        }

        /// <summary>
        /// Renders the client events and behavior fields.
        /// </summary>
        /// <value>
        /// <c>true</c> if [should render client events]; otherwise, <c>false</c>.
        /// </value>
        /// <returns></returns>
        protected override bool ShouldRenderClientEvents
        {
            get
            {
                // Checking for proxy component to prevent client buy checking the proxy if it is in emulation mode.
                return GetProxyPropertyValue<bool>("ShouldRenderClientEvents", true);
            }
        }

        /// <summary>
        /// Renders the extended component attributes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected internal void RenderExtendedComponentAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // render extended attributes if exist
            ((IAttributeExtender)this).RenderAttributes(objWriter);
        }

        /// <summary>
        /// Renders the drag and drop attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderDragAndDropAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            // Get drag targets.
            Component[] arrDragTargets = this.GetProxyPropertyValue<Component[]>("DragTargets", this.DragTargets);

            // Render drop targets
            if ((arrDragTargets != null && arrDragTargets.Length > 0) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.DragTargets, CommaSeperatedString(arrDragTargets));
            }

            // Render the AllowDrop attribute.
            if (this.AllowDrop || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowDrop, this.AllowDrop ? "1" : "0");
            }

            // Render the AllowDrop attribute.
            if (!this.AllowDrag || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowDrag, this.AllowDrag ? "1" : "0");
            }

            // Render the drop indicator attribute.
            if (!this.DropIndicatorPropogation || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.DropIndicatorPropogation, this.DropIndicatorPropogation ? "1" : "0");
            }

            if ((this.ExcludedDragTargets != null && this.ExcludedDragTargets.Length > 0) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ExcludedDragTargets, CommaSeperatedString(this.ExcludedDragTargets));
            }

            bool blnAllowTargetsPropagateToChildControls = this.AllowDragTargetsPropagation;

            // Render the Allow targets to propagate attribute
            if (!blnAllowTargetsPropagateToChildControls || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowDragTargetsToPropegateChild, blnAllowTargetsPropagateToChildControls ? "1" : "0");
            }

            // Render referenced drag component attribute
            if (this.ReferencedDragTargetsComponent != null || blnForceRender)
            {

                string strId = this.ReferencedDragTargetsComponent != null ? this.ReferencedDragTargetsComponent.ID.ToString() : string.Empty;
                objWriter.WriteAttributeString(WGAttributes.DragTargetsComponent, strId);
            }
        }

        /// <summary>
        /// Commas the seperated string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        private string CommaSeperatedString(IEnumerable<Component> obj)
        {
            string strResult = string.Empty;
            string strComma = string.Empty;

            foreach (Component objItem in obj)
            {
                strResult += strComma + objItem.ID;

                strComma = ",";
            }

            return strResult;
        }

        #endregion

        #region ClientAction

        /// <summary>
        /// Registers the default client invocation.
        /// </summary>
        /// <param name="strMethod">The target method.</param>
        /// <param name="arrArgs">The invocation args.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void RegisterClientAction(string strMethod, params string[] arrArgs)
        {
            this.RegisterClientAction(null, strMethod, arrArgs);
        }

        /// <summary>
        /// Registers the default client invocation.
        /// </summary>
        /// <param name="objTarget">The invocation target.</param>
        /// <param name="strMethod">The target method.</param>
        /// <param name="arrArgs">The invocation args.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void RegisterClientAction(Component objTarget, string strMethod, params string[] arrArgs)
        {
            // Validate arguments
            if (strMethod == null) throw new ArgumentNullException("strMethod");

            // Register client action
            this.ClientAction = RegisteredClientAction.Create(objTarget, strMethod, arrArgs);

            // Update compoment to reflect client action
            this.Update();
        }

        /// <summary>
        /// Registers the default client invocation (Adds component id as the first parameter).
        /// </summary>
        /// <param name="objTarget">The invocation target.</param>
        /// <param name="strMethod">The target method.</param>
        /// <param name="arrArgs">The invocation args.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void RegisterClientActionWithId(Component objTarget, string strMethod, params string[] arrArgs)
        {
            // Validate arguments
            if (strMethod == null) throw new ArgumentNullException("strMethod");
            if (objTarget == null) throw new ArgumentNullException("objTarget");

            // Register client action
            this.ClientAction = RegisteredClientAction.CreateWithId(objTarget, strMethod, arrArgs);

            // Update compoment to reflect client action
            this.Update();
        }

        /// <summary>
        /// Register the ClientAction property
        /// </summary>
        private static SerializableProperty ClientActionProperty = SerializableProperty.Register("ClientAction", typeof(RegisteredClientAction), typeof(Component), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Gets or sets the client action.
        /// </summary>
        /// <value>The client action.</value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public RegisteredClientAction ClientAction
        {
            get
            {
                return GetValue<RegisteredClientAction>(Component.ClientActionProperty);
            }
            set
            {
                // Set client action object
                if (this.SetValue<RegisteredClientAction>(Component.ClientActionProperty, value))
                {
                    // Update instance to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Unregisters the default client invocation.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void UnregisterClientAction()
        {
            // Clear client action registration
            this.ClientAction = null;

            // Update compoment to reflect client action cleared
            this.Update();
        }

        #endregion

        /// <summary>
        /// Sets the loading message.
        /// </summary>
        /// <value></value>
        public void SetLoadingMessage(string strLoadingMessage)
        {
            this.SetValue<string>(Component.LoadingMessageProperty, strLoadingMessage);
        }

        #region Object Module

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                if (this.InternalParent != null)
                {
                    bool blnIsEventsEnabled = this.InternalParent.IsEventsEnabled;

                    if (!this.DesignMode)
                    {
                        // If parent is form..
                        Form objParentForm = this.InternalParent as Form;
                        if (objParentForm != null)
                        {
                            // If forms security enabled..
                            if (Context.Config.FormsSecurityEnabled)
                            {
                                IContextParams objContextParams = Context as IContextParams;

                                // Events are enabled only for the full control mode.
                                blnIsEventsEnabled &= objContextParams.GetFormAccessMode(objParentForm) == FormAccessMode.FullControl;
                            }
                        } 
                    }

                    return blnIsEventsEnabled;
                }
                else
                {
                    return base.IsEventsEnabled;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
        /// event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        private void OnComponentClick(EventArgs objEventArgs)
        {
            MouseEventArgs objMouseEventArgs = objEventArgs as MouseEventArgs;
            if (objMouseEventArgs == null)
            {
                objMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            }

            if (objMouseEventArgs.Button == MouseButtons.Right)
            {
                if (this.ContextMenuInherited != null)
                {
                    this.ContextMenuInherited.Show(this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
                }

                else if (this.ContextMenuStripInherited != null)
                {
                    this.ContextMenuStripInherited.ShowDropDown(this, objMouseEventArgs.X, objMouseEventArgs.Y);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ContextMenuStripChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnContextMenuStripChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ContextMenuStripChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.DragDrop"></see> event.</summary>
        /// <param name="objDragEventArgs">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDragDrop(DragEventArgs objDragEventArgs)
        {
            // Raise event if needed
            DragEventHandler objEventHandler = this.DragDropHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objDragEventArgs);
            }
        }

        /// <summary>
        /// Called when [swipe].
        /// </summary>
        /// <param name="enmSwipeDirection">The swipe direction.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnSwipe(SwipeDirection enmSwipeDirection)
        {
            // Raise event if needed
            SwipeEventHandler objEventHandler = this.SwipHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, enmSwipeDirection);
            }
        }

        /// <summary>
        /// Detaches the context menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DetachContextMenu(object sender, EventArgs e)
        {
            // Remove current context menu.
            this.ContextMenu = null;
        }

        /// <summary>
        /// Detaches the context menu strip.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DetachContextMenuStrip(object sender, EventArgs e)
        {
            this.ContextMenuStrip = null;
        }

        /// <summary>
        /// Gets the proxy property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objDefaultValue">The obj default value.</param>
        /// <returns></returns>
        protected virtual internal T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                return objProxyComponent.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue);
            }

            return objDefaultValue;
        }



        /// <summary>
        /// Determines whether [has proxy property value] [the specified STR property name].
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <returns>
        ///   <c>true</c> if [has proxy property value] [the specified STR property name]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual internal bool HasProxyPropertyValue(string strPropertyName)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                return objProxyComponent.HasProxyPropertyValue(strPropertyName);
            }

            return false;
        }

        /// <summary>
        /// Gets the ancestor by type.
        /// </summary>
        /// <param name="objType">type.</param>
        /// <returns></returns>
        protected Component GetAncestorByType(Type objType)
        {
            Component objAncestor = this;

            while (true && objAncestor != null)
            {
                // stop conditions
                if (objAncestor == objAncestor.InternalParent) break;
                if (objType.IsInstanceOfType(objAncestor)) break;
                if (objAncestor == null) break;

                // set next component
                objAncestor = objAncestor.InternalParent;
            }

            // return found element
            return objAncestor;
        }

        /// <summary>
        /// Disposes the specified component.
        /// </summary>
        /// <param name="blnDisposing"></param>
        protected override void Dispose(bool blnDisposing)
        {
            base.Dispose(blnDisposing);

            if (blnDisposing)
            {
                ContextMenu objContextMenu = this.ContextMenu;
                if (objContextMenu != null)
                {
                    // Unregister previous dispose handler.
                    objContextMenu.Disposed -= new EventHandler(this.DetachContextMenu);
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Gets the event integer attribute value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="strAttribute">The attribute name.</param>
        /// <param name="intDefault">The default integer value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
        {
            string strValue = objEvent[strAttribute];
            if (CommonUtils.IsNullOrEmpty(strValue))
            {
                return intDefault;
            }
            else
            {
                double dblResult = 0;
                CommonUtils.TryParse(strValue, out dblResult);
                return Convert.ToInt32(dblResult);
            }
        }

        /// <summary>
        /// Gets the event buttons value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="enmDefault">The default value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
        {
            // Get the button property of the event
            string strButton = objEvent["BTN"];
            switch (strButton)
            {
                case "L":
                    return MouseButtons.Left;
                case "R":
                    return MouseButtons.Right;
                case "M":
                    return MouseButtons.Middle;
                default:
                    return enmDefault;
            }
        }

        /// <summary>
        /// Fires the menu click.
        /// </summary>
        /// <param name="objMenuItem">The obj menu item.</param>
        internal void FireMenuClick(MenuItem objMenuItem, IIdentifiedComponent objMember)
        {
            FireMenuClick(new MenuItemEventArgs(objMenuItem, this, objMember));
        }

        /// <summary>
        /// Fires the menu click.
        /// </summary>
        /// <param name="objMenuItem">The obj menu item.</param>
        internal void FireMenuClick(MenuItem objMenuItem)
        {
            FireMenuClick(new MenuItemEventArgs(objMenuItem, this));
        }

        /// <summary>
        /// Fires the menu click.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.MenuItemEventArgs"/> instance containing the event data.</param>
        internal void FireMenuClick(MenuItemEventArgs objEventArgs)
        {
            // Check if this component has a menu click handler.
            if (this.MenuClickHandler != null)
            {
                MenuClickHandler(this, objEventArgs);
            }
            // If this component does not have a menu click handler, try fire menu click on parent.
            else if (this.InternalParent != null)
            {
                this.InternalParent.FireMenuClick(objEventArgs);
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="intHandledImageKey">The int handled image key.</param>
        /// <param name="objImageList">The obj image list.</param>
        /// <param name="intImageIndex">Index of the int image.</param>
        /// <param name="strImageKey">The STR image key.</param>
        /// <param name="intParentImageIndex">Index of the int parent image.</param>
        /// <param name="strParentImageKey">The STR parent image key.</param>
        /// <returns></returns>
        protected internal ResourceHandle GetImage(SerializableProperty intHandledImageKey, ImageList objImageList, int intImageIndex, string strImageKey, int intParentImageIndex, string strParentImageKey)
        {
            if (objImageList != null)
            {
                if (intImageIndex > -1)
                {
                    return objImageList.Images[intImageIndex];
                }
                else if (!string.IsNullOrEmpty(strImageKey))
                {
                    return objImageList.Images[strImageKey];
                }
                if (intParentImageIndex > -1)
                {
                    return objImageList.Images[intParentImageIndex];
                }
                else if (!string.IsNullOrEmpty(strParentImageKey))
                {
                    return objImageList.Images[strParentImageKey];
                }
                else
                {
                    return null;
                }
            }

            return this.GetValue<ResourceHandle>(intHandledImageKey);
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        /// <param name="objHandledImage">The obj handled image.</param>
        /// <param name="objNewValue">The obj new value.</param>
        /// <param name="objImageList">The obj image list.</param>
        protected internal bool SetImage(SerializableProperty intHandledImageKey, ResourceHandle objNewValue, ImageList objImageList)
        {
            if (objImageList != null)
            {
                throw new Exception("Cannot assign image when working in ImageList mode.");
            }

            // Set the new value 
            bool blnChanged = this.SetValue<ResourceHandle>(intHandledImageKey, objNewValue);

            // Update control if value had changed
            if (blnChanged)
            {
                this.Update();
            }
            return blnChanged;
        }

        /// <summary>
        /// Gets the component critical events.
        /// </summary>
        /// <returns></returns>
        internal CriticalEventsData GetComponentCriticalEventsData()
        {
            return this.GetCriticalEventsData();
        }

        /// <summary>
        /// Gets the component critical client events.
        /// </summary>
        /// <returns></returns>
        internal CriticalEventsData GetComponentCriticalClientEventsData()
        {
            return this.GetCriticalClientEventsData();
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // Checking for proxy component and its critical events
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                objEvents.Set(objProxyComponent.GetCriticalEventsData());
            }

            if (this.DragDropHandler != null)
            {
                objEvents.Set(WGEvents.DragDrop);
            }

            if (this.ContextMenuInherited != null || this.ContextMenuStripInherited != null)
            {
                objEvents.Set(WGEvents.RightClick);
            }

            if (this.SwipHandler != null)
            {
                objEvents.Set(WGEvents.Swipe);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            // Checking for proxy component and its critical events
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                objEvents.Set(objProxyComponent.GetCriticalClientEventsData());
            }

            if (this.HasClientHandler("StartDrag"))
            {
                objEvents.Set(WGEvents.StartDrag);
            }
            if (this.HasClientHandler("DragDrop"))
            {
                objEvents.Set(WGEvents.DragDrop);
            }

            return objEvents;
        }

        /// <summary>
        /// Occurs when [client after start drag].
        /// </summary>
        [SRDescription("Occurs when control dragged in client mode."), Category("Client")]
        public event ClientEventHandler ClientStartDrag
        {
            add
            {
                this.AddClientHandler("StartDrag", value);
            }
            remove
            {
                this.RemoveClientHandler("StartDrag", value);
            }
        }

        /// <summary>
        /// Occurs when [client drag drop].
        /// </summary>
        [SRDescription("Occurs when dragged component dropped in client mode."), Category("Client")]
        public event ClientEventHandler ClientDragDrop
        {
            add
            {
                this.AddClientHandler("DragDrop", value);
            }
            remove
            {
                this.RemoveClientHandler("DragDrop", value);
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "Click":
                    this.OnComponentClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    break;

                case "DragDrop":
                    if (objEvent[WGAttributes.DragSource] != null)
                    {
                        Component objDragSource = ((ISessionRegistry)this.Context).GetRegisteredComponent(objEvent[WGAttributes.DragSource]) as Component;
                        if (objDragSource != null)
                        {
                            Component objExplicitTarget = ((ISessionRegistry)this.Context).GetRegisteredComponent(objEvent[WGAttributes.ExplicitTarget]) as Component;
                            if (objExplicitTarget != null)
                            {
                                // Try getting the key state of the drop action.
                                int intKeyState = 0;
                                if (objEvent[WGAttributes.KeyState] != null)
                                {
                                    intKeyState = Convert.ToInt32(objEvent[WGAttributes.KeyState]);
                                }

                                // Try getting the x and y positions.
                                Point objCursorPosition = GetEventPosition(objEvent, WGAttributes.CursorPosition);
                                Point objRelativePosition = GetEventPosition(objEvent, WGAttributes.RelativePosition);

                                // Fire the DragDrop event.
                                OnDragDrop(new DragDropEventArgs(objDragSource, this, objExplicitTarget, intKeyState, objCursorPosition.X, objCursorPosition.Y, objRelativePosition.X, objRelativePosition.Y, DragDropEffects.Move, DragDropEffects.Move));
                            }
                        }
                    }
                    break;

                case "Swipe":
                    // Get direction attribute from event.
                    string strDirection = objEvent[WGAttributes.Direction];
                    if (!string.IsNullOrEmpty(strDirection))
                    {
                        int intDirection = -1;

                        // Try parsing direction to integer.
                        if (int.TryParse(strDirection, out intDirection))
                        {
                            // Check if direction value is defiened.
                            if (Enum.IsDefined(typeof(SwipeDirection), intDirection))
                            {
                                // Parse a swipe direction.
                                SwipeDirection enmSwipeDirection = (SwipeDirection)Enum.Parse(typeof(SwipeDirection), strDirection);

                                // Raise the swipe event.
                                this.OnSwipe(enmSwipeDirection);
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets position from event.
        /// </summary>
        private Point GetEventPosition(IEvent objEvent, string strEventName)
        {
            int intX = 0;
            int intY = 0;

            if (objEvent[strEventName] != null)
            {
                string strPosition = objEvent[strEventName];

                if (strPosition != null)
                {
                    string[] arrPositionPosition = strPosition.Split(',');

                    if (arrPositionPosition != null &&
                        arrPositionPosition.Length == 2)
                    {
                        intX = Convert.ToInt32(Convert.ToDouble(arrPositionPosition[0], CultureInfo.InvariantCulture));
                        intY = Convert.ToInt32(Convert.ToDouble(arrPositionPosition[1], CultureInfo.InvariantCulture));
                    }
                }
            }

            Point objPosition = new Point(intX, intY);
            return objPosition;
        }

        /// <summary>
        /// Fires the component event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void FireComponentEvent(IEvent objEvent)
        {
            this.FireEvent(objEvent);
        }

        /// <summary>
        /// Fires a component event
        /// </summary>
        /// <param name="objSource"></param>
        /// <param name="objArgs"></param>
        internal void FireComponentEvent(object objSource, EventArgs objArgs)
        {
            if (objArgs is MenuItemEventArgs)
            {
                if (this.MenuClickHandler != null)
                {
                    this.MenuClickHandler(objSource, objArgs as MenuItemEventArgs);
                }
            }
        }

        #endregion

        #region IObservableItem Members

        /// <summary>
        /// Property change indicator for the observable item interface
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

        /// <summary>
        /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
        /// </summary>
        /// <param name="strProperty">The name of the property that has changed</param>
        protected void FireObservableItemPropertyChanged(string strProperty)
        {
            if (ObservableItemPropertyChanged != null)
            {
                ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
            }
        }

        /// <summary>
        /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
        /// </summary>
        /// <param name="strProperty">The name of the property that has changed</param>
        /// <param name="objSubject">The subject of the property that has changed</param>
        protected void FireObservableItemPropertyChanged(string strProperty, object objSubject)
        {
            if (ObservableItemPropertyChanged != null)
            {
                ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty, objSubject));
            }
        }

        #endregion

        #region IAttributeExtender Members

        /// <summary>
        /// Register the Attributes property
        /// </summary>
        private static SerializableProperty AttributesProperty = SerializableProperty.Register("Attributes", typeof(AttributesWrapper), typeof(Component), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Gets an attribute from the container
        /// </summary>
        /// <param name="strName">The attribute name.</param>
        /// <returns></returns>
        string IAttributeExtender.GetAttribute(string strName)
        {
            // Get the attribute wrapper
            AttributesWrapper objAttributes = this.GetValue<AttributesWrapper>(Component.AttributesProperty);

            // If there is a valid attribute wrapper
            if (objAttributes != null)
            {
                return objAttributes[strName];
            }

            return null;
        }

        void IAttributeExtender.SetAttribute(string strName, string strValue)
        {
            // Get the attribute wrapper
            AttributesWrapper objAttributes = this.GetValue<AttributesWrapper>(Component.AttributesProperty);

            // If there is no attribute wrapper
            if (objAttributes == null)
            {
                // Create a new attribute wrapper
                objAttributes = new AttributesWrapper();

                // Set the attributes wrapper instance
                this.SetValue<AttributesWrapper>(Component.AttributesProperty, objAttributes);
            }

            // If attribute value had changed
            if (objAttributes[strName] != strValue)
            {
                // Set the new attribute
                objAttributes[strName] = strValue;


                // Update control to reflect attribute changes
                this.UpdateParams(AttributeType.Extended);
            }
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objAttributeWriter">The attribute writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        private void RenderAttributes(IAttributeWriter objAttributeWriter, long lngRequestID)
        {
            // Get the attribute wrapper
            AttributesWrapper objAttributes = this.GetValue<AttributesWrapper>(Component.AttributesProperty);

            // If there is a valid attribute wrapper
            if (objAttributes != null)
            {
                // Render the attribute wrapper attributes
                objAttributes.RenderAttributes(objAttributeWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
        }

        /// <summary>
        /// Renders the client events propogated tags.
        /// </summary>
        /// <param name="objAttributeWriter">The obj attribute writer.</param>
        private void RenderClientEventsPropogationTags(IAttributeWriter objAttributeWriter)
        {
            if (!string.IsNullOrEmpty(this.ClientEventsPropogationTags))
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.ClientEventsPropogationTags, this.ClientEventsPropogationTags);
            }
        }

        /// <summary>
        /// Writes the container attributes to an IAttributeWriter
        /// </summary>
        /// <param name="objAttributeWriter"></param>
        void IAttributeExtender.RenderAttributes(IAttributeWriter objAttributeWriter)
        {
            RenderAttributes(objAttributeWriter, 0);
        }

        /// <summary>
        /// Renders the updated attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        void IAttributeExtender.RenderUpdatedAttributes(IAttributeWriter objWriter, long lngRequestID)
        {
            RenderAttributes(objWriter, lngRequestID);
        }

        #endregion

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected virtual WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new WinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WinFormsCompatibilityOptionValueChanged(object sender, WinFormsCompatibilityEventArgs e)
        {
            OnWinFormsCompatibilityOptionValueChanged(e.ChangedOptionName);
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected virtual void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the empty GIF handle.
        /// </summary>
        /// <value>
        /// The empty GIF.
        /// </value>
        protected static SkinResourceHandle EmptyGif
        {
            get
            {
                if (mobjEmptyGif == null)
                {
                    mobjEmptyGif = new SkinResourceHandle(typeof(CommonSkin), "Empty.gif");
                }
                return Component.mobjEmptyGif;
            }
        }

        /// <summary>
        /// Renders the animation.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RenderAnimationAttributes(IAttributeWriter objWriter)
        {
            // Indicates if to render animation support
            if (this.Animation)
            {
                objWriter.WriteAttributeString(WGAttributes.Animation, "1");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is animation.
        /// </summary>
        /// <value><c>true</c> if animation; otherwise, <c>false</c>.</value>
        /// <remarks>This is a temporary implementation of animation support.</remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool Animation
        {
            get
            {
                return this.GetState(ComponentState.AnimationEnabled);
            }
            set
            {
                // Set the new animation value and update the control is value has changed
                if (this.SetStateWithCheck(ComponentState.AnimationEnabled, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether animation is enabled by default.
        /// </summary>
        /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool DefaultAnimation
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal virtual IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return null;
        }

        /// <summary>
        /// Gets the component unique ID.
        /// </summary>
        /// <param name="objMainForm">The obj main form.</param>
        /// <param name="objComponent">The obj component.</param>
        /// <returns></returns>
        internal string GetComponentUniqueID(Form objMainForm, Component objComponent)
        {
            if (objComponent != null && objComponent != objMainForm)
            {
                string strControlFullName = objComponent.GetType().FullName;
                if (!string.IsNullOrEmpty(strControlFullName))
                {
                    Component objParentComponent = objComponent.InternalParent;
                    if (objParentComponent != null)
                    {
                        string strParentControlPath = this.GetComponentUniqueID(objMainForm, objParentComponent);

                        if (!string.IsNullOrEmpty(strParentControlPath))
                        {
                            strParentControlPath = string.Format("{0}/", strParentControlPath);
                        }

                        IList objList = objParentComponent.GetComponentOffsprings(strControlFullName);
                        if (objList != null)
                        {
                            return string.Format("{0}{1}[{2}]", strParentControlPath, strControlFullName, objList.IndexOf(objComponent));
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Shoulds the render is dirty attribute.
        /// </summary>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <returns></returns>
        protected override bool ShouldRenderIsDirtyAttribute(long lngRequestID)
        {
            // Check if this component is child of parent with client update handler
            if (this.HasParentWithClientUpdateHandler())
            {
                // If this component has dirty parent without client update handler then return false; otherwise ,true
                return this.FirstDirtyParentHasClientUpdateHandler(lngRequestID);
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Firsts the dirty parent has client update handler.
        /// </summary>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <returns></returns>
        private bool FirstDirtyParentHasClientUpdateHandler(long lngRequestID)
        {
            // Get parent
            Component objParent = this.InternalParent;

            if (objParent != null)
            {
                // If parent is dirty and dont have client update handler return true
                if ((objParent.IsDirty(lngRequestID) || objParent.IsDirtyAttributes(lngRequestID)))
                {
                    return objParent.UseClientUpdateHandler && !string.IsNullOrEmpty(objParent.ClientUpdateHandler) ? true : false;
                }

                // Check it on the parent's parent
                return objParent.FirstDirtyParentHasClientUpdateHandler(lngRequestID);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether [has parent with client update handler].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has parent with client update handler]; otherwise, <c>false</c>.
        /// </returns>
        protected bool HasParentWithClientUpdateHandler()
        {
            // Get parent
            Component objParent = this.InternalParent;
            if (objParent != null)
            {
                // Check if parent has client update handler
                if (objParent.UseClientUpdateHandler && !string.IsNullOrEmpty(objParent.ClientUpdateHandler))
                {
                    return true;
                }
                else
                {
                    // // Check if parent has parent with client update handler
                    return objParent.HasParentWithClientUpdateHandler();
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        protected override bool IsConnected
        {
            get
            {
                return this.InternalParent != null;
            }
        }

        #region General

        /// <summary>
        /// Gets/Sets User definied tag
        /// </summary>
        [Localizable(false), Bindable(true), TypeConverter(typeof(StringConverter)), SRCategory("CatData"), SRDescription("ControlTagDescr"), DefaultValue(null)]
        public object Tag
        {
            get
            {
                return this.GetValue<object>(Component.TagProperty);
            }
            set
            {
                this.SetValue<object>(Component.TagProperty, value);
            }
        }

        /// <summary>
        /// Register the Tag property
        /// </summary>
        private static SerializableProperty TagProperty = SerializableProperty.Register("Tag", typeof(object), typeof(Component), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Gets/Sets System definied tag
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object SystemTag
        {
            get
            {
                return this.GetValue<object>(Component.SystemTagProperty);
            }
            set
            {
                this.SetValue<object>(Component.SystemTagProperty, value);
            }
        }

        /// <summary>
        /// Register the SystemTag property
        /// </summary>
        private static SerializableProperty SystemTagProperty = SerializableProperty.Register("SystemTag", typeof(object), typeof(Component), new SerializablePropertyMetadata(null));


        /// <summary>
        /// Gets or sets the custom template.
        /// </summary>
        /// <value>The custom template.</value>
        [DefaultValue("")]
        public string CustomTemplate
        {
            get
            {
                return this.GetValue<string>(Component.CustomTemplateProperty);
            }
            set
            {
                this.SetValue<string>(Component.CustomTemplateProperty, value);
            }
        }

        /// <summary>
        /// Register the CustomTemplate property
        /// </summary>
        private static SerializableProperty CustomTemplateProperty = SerializableProperty.Register("CustomTemplate", typeof(string), typeof(Component), new SerializablePropertyMetadata(string.Empty));


        /// <summary>
        /// Gets or sets the proxy component.
        /// </summary>
        /// <value>
        /// The proxy component.
        /// </value>
        internal protected virtual ProxyComponent ProxyComponent
        {
            get
            {
                return mobjProxyComponent;
            }
            set
            {
                mobjProxyComponent = value;
            }
        }

        #endregion

        #region Object Model

        /// <summary>
        /// The parent of this component
        /// </summary>
        [NonSerialized()]
        private Component mobjInternalParent = null;

        /// <summary>
        /// Gets the parent of this component.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Component InternalParent
        {
            get
            {
                return mobjInternalParent;
            }
            set
            {
                mobjInternalParent = value;
            }
        }

        /// <summary>
        /// Gets a flag indicating if the object is initializing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal override bool IsSerializableObjectInitializing
        {
            get
            {
                // If a component has no parent it is initializing
                return mobjInternalParent == null;
            }
        }

        /// <summary>
        /// Gets the initial size of the serializable filed storage.
        /// </summary>
        /// <value>The initial size of the serializable filed storage.</value>
        protected internal override int SerializableFieldStorageInitialSize
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Gets or sets whether this control accepts dropping dragged content to it
        /// </summary>
        /// <value>A flag indicating if this control accepts dropping dragged content to it.</value>
        [Description("A flag indicating whether this component is drop-able."), SRCategory("CatBehavior"), DefaultValue(false)]
        public virtual bool AllowDrop
        {
            get
            {
                return GetState(ComponentState.AllowDrop);
            }
            set
            {
                // Set the allow drop value and update control if value changed
                if (this.SetStateWithCheck(ComponentState.AllowDrop, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow drop].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow drop]; otherwise, <c>false</c>.
        /// </value>
        [Description("A flag indicating whether this component is drag-able."), SRCategory("CatBehavior"), DefaultValue(true)]
        public virtual bool AllowDrag
        {
            get
            {
                return GetState(ComponentState.AllowDrag);
            }
            set
            {
                // Set the allow drop value and update control if value changed
                if (this.SetStateWithCheck(ComponentState.AllowDrag, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [propogate drop indicator].
        /// </summary>
        /// <value>
        /// <c>true</c> if [propogate drop indicator]; otherwise, <c>false</c>.
        /// </value>
        [Description("A flag indicating which control will be illuminated when dragging over inner controls."), SRCategory("CatBehavior"), DefaultValue(true)]
        public virtual bool DropIndicatorPropogation
        {
            get
            {
                return GetState(ComponentState.DropIndicatorPropogation);
            }
            set
            {
                // Set the allow drop value and update control if value changed
                if (this.SetStateWithCheck(ComponentState.DropIndicatorPropogation, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets the list of tags that client events are propogated to.
        /// </summary>
        /// <value>
        /// The client event propogated tags.
        /// </value>
        protected virtual string ClientEventsPropogationTags
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [exclude self from drag targets].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [exclude self from drag targets]; otherwise, <c>false</c>.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [Description("An array which contains all components which should be excluded from this component drag targets."), SRCategory("CatBehavior")]
        public virtual Component[] ExcludedDragTargets
        {
            get
            {
                return GetValue<Component[]>(Component.ExcludedDragTargetsProperty);
            }
            set
            {
                bool blnIsDifferent = false;

                Component[] arrOldValue = this.ExcludedDragTargets;

                // If is a diffrent key filter
                if (arrOldValue != value)
                {
                    if (value == null || arrOldValue == null || value.Length == 0 || arrOldValue.Length == 0 || value.Length != arrOldValue.Length)
                    {
                        blnIsDifferent = true;
                    }
                    else
                    {
                        for (int intIndex = 0; intIndex < value.Length; intIndex++)
                        {
                            if (value[intIndex] != arrOldValue[intIndex])
                            {
                                blnIsDifferent = true;
                                break;
                            }
                        }
                    }
                }

                // If is a diffrent drag targets.
                if (blnIsDifferent)
                {
                    // If is empty value revert to default
                    if (value == null || value.Length == 0)
                    {
                        this.RemoveValue<Component[]>(Component.ExcludedDragTargetsProperty);
                    }
                    else
                    {
                        // Set the drag target data
                        this.SetValue<Component[]>(Component.ExcludedDragTargetsProperty, value);
                    }

                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets the owner form.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual Form Form
        {
            get
            {
                if (this is Form)
                {
                    return (Form)this;
                }
                // Custom proxy components have no real form, so they return the emulator form which is the ParentForm. 
                //(this solves the problem when right-clicking the control in the emulator and the Pop-Up throws exception)
                else if (this.ProxyComponent != null && !this.ProxyComponent.IsStateComponent) 
                {
                    return this.ProxyComponent.ParentForm;
                }
                else if (InternalParent != null)
                {
                    return InternalParent.Form;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the empty drag targets.
        /// </summary>
        /// <value>The empty drag targets.</value>
        private static Component[] EmptyDragTargets
        {
            get
            {
                return new Component[0];
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow targets propagate to child controls].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow targets propagate to child controls]; otherwise, <c>false</c>.
        /// </value>
        [Description("A flag indicating whether this component allows its drag target to propogate to its contained components."), SRCategory("CatBehavior"), DefaultValue(true), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool AllowDragTargetsPropagation
        {
            get
            {
                return GetValue<bool>(Component.AllowDragTargetsPropagationProperty);
            }
            set
            {
                if (SetValue<bool>(Component.AllowDragTargetsPropagationProperty, value))
                {
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Register the AllowDragTargetsPropagation property
        /// </summary>
        private static SerializableProperty AllowDragTargetsPropagationProperty = SerializableProperty.Register("AllowDragTargetsPropagation", typeof(bool), typeof(Component), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Gets or sets the referenced drag targets component.
        /// </summary>
        /// <value>
        /// The referenced drag targets component.
        /// </value>
        [Description("A refference to a component which contains the drag targets which will serve this component."), SRCategory("CatBehavior"), DefaultValue(null), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Component ReferencedDragTargetsComponent
        {
            get
            {
                return GetValue<Component>(Component.ReferencedDragTargetsComponentProperty);
            }
            set
            {
                if (this.SetValue<Component>(Component.ReferencedDragTargetsComponentProperty, value))
                {
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Defines the valid drag and drop targets when drag starts from this control.
        /// </summary>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [Description("An array which represents the component's drag targets."), SRCategory("CatBehavior")]
        [TypeConverter(typeof(DragTargetsTypeConverter))]
        public virtual Component[] DragTargets
        {
            get
            {
                return GetValue<Component[]>(Component.DragTargetsProperty);
            }
            set
            {
                bool blnIsDifferent = false;

                Component[] arrOldValue = this.DragTargets;

                // If is a diffrent key filter
                if (arrOldValue != value)
                {
                    if (value == null || arrOldValue == null || value.Length == 0 || arrOldValue.Length == 0 || value.Length != arrOldValue.Length)
                    {
                        blnIsDifferent = true;
                    }
                    else
                    {
                        for (int intIndex = 0; intIndex < value.Length; intIndex++)
                        {
                            if (value[intIndex] != arrOldValue[intIndex])
                            {
                                blnIsDifferent = true;
                                break;
                            }
                        }
                    }
                }

                // If is a diffrent drag targets.
                if (blnIsDifferent)
                {
                    // If is empty value revert to default
                    if (value == null || value.Length == 0)
                    {
                        this.RemoveValue<Component[]>(Component.DragTargetsProperty);
                    }
                    else
                    {
                        // Set the drag target data
                        this.SetValue<Component[]>(Component.DragTargetsProperty, value);
                    }

                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Register the DragTargets property
        /// </summary>
        private static SerializableProperty ExcludedDragTargetsProperty = SerializableProperty.Register("ExcludedDragTargets", typeof(Component[]), typeof(Component), new SerializablePropertyMetadata(new Component[0]));
        private static SerializableProperty DragTargetsProperty = SerializableProperty.Register("DragTargets", typeof(Component[]), typeof(Component), new SerializablePropertyMetadata(new Component[0]));
        private static SerializableProperty ReferencedDragTargetsComponentProperty = SerializableProperty.Register("ReferencedDragTargetsComponent", typeof(Component), typeof(Component), new SerializablePropertyMetadata(null));

        #endregion

        #region Server Objects

        internal ISession InternalSession
        {
            get
            {
                return this.Session;
            }
        }

        #endregion

        #region Should Serialze Methods

        /// <summary>
        /// Shoulds the serialize allow drop.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeAllowDrop()
        {
            return this.AllowDrop;
        }

        /// <summary>
        /// Shoulds the serialize drag targets.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeDragTargets()
        {
            return this.ContainsValue<Component[]>(Component.DragTargetsProperty);
        }


        /// <summary>
        /// Shoulds the serialize excluded drag targets.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeExcludedDragTargets()
        {
            return this.ContainsValue<Component[]>(Component.ExcludedDragTargetsProperty);
        }

        /// <summary>
        /// Shoulds the serialize custom template.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeCustomTemplate()
        {
            return this.ContainsValue<string>(Component.CustomTemplateProperty);
        }

        #endregion

        #region ContextMenu

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            if (mobjContextMenu != null)
            {
                RegisterComponent(mobjContextMenu);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            if (mobjContextMenu != null)
            {
                UnRegisterComponent(mobjContextMenu);
            }
        }

        /// <summary>
        /// The component context menu
        /// </summary>
        [NonSerialized()]
        private ContextMenu mobjContextMenu = null;

        /// <summary>
        /// The component context menu strip.
        /// </summary>
        [NonSerialized()]
        private ContextMenuStrip mobjContextMenuStrip = null;

        /// <summary>
        /// Gets or sets the context menu code.  
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        public virtual ContextMenu ContextMenu
        {
            get
            {
                return mobjContextMenu;
            }
            set
            {
                // Get current context menu
                ContextMenu objCurrentContextMenu = mobjContextMenu;

                // If diffrent menu assignment
                if (objCurrentContextMenu != value)
                {
                    // Create a new context menu deataching handler.
                    EventHandler objDetachHandler = new EventHandler(this.DetachContextMenu);
                    if (objCurrentContextMenu != null)
                    {
                        // Unregister previous dispose handler.
                        objCurrentContextMenu.Disposed -= objDetachHandler;
                    }

                    // set context menu
                    mobjContextMenu = value;

                    if (value != null)
                    {
                        // Register dispose handler.
                        value.Disposed += objDetachHandler;
                    }

                    // If there is a context menu
                    if (value != null)
                    {
                        // Set parent if needed
                        if (value.InternalParent == null)
                        {
                            value.InternalParent = this;
                        }

                    }

                    // Update component to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the inherited context menu.
        /// </summary>
        internal ContextMenu ContextMenuInherited
        {
            get
            {
                // Check local context menu .
                ContextMenu objContextMenu = this.ContextMenu;
                if (objContextMenu != null)
                {
                    return objContextMenu;
                }

                // Get parent.
                Component objParent = this.InternalParent;
                if (objParent != null)
                {
                    // Returns parent's context menu.
                    return objParent.ContextMenuInherited;
                }

                // Return default value.
                return null;
            }
        }


        /// <summary>
        /// Gets or sets the context menu strip.
        /// </summary>
        /// <value>
        /// The context menu strip.
        /// </value>
        [SRDescription("ControlContextMenuDescr"), DefaultValue((string)null), SRCategory("CatBehavior")]
        [System.ComponentModel.Browsable(true)]
        public virtual ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return mobjContextMenuStrip;
            }
            set
            {
                ContextMenuStrip strip = mobjContextMenuStrip;
                if (strip != value)
                {
                    EventHandler handler = new EventHandler(this.DetachContextMenuStrip);
                    if (strip != null)
                    {
                        strip.Disposed -= handler;
                    }

                    mobjContextMenuStrip = value;

                    if (value != null)
                    {
                        value.Disposed += handler;
                    }

                    this.OnContextMenuStripChanged(EventArgs.Empty);

                    // Update component to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the inherited context menu strip.
        /// </summary>
        internal ContextMenuStrip ContextMenuStripInherited
        {
            get
            {
                // Check local context menu strip.
                ContextMenuStrip objContextMenuStrip = this.ContextMenuStrip;
                if (objContextMenuStrip != null)
                {
                    return objContextMenuStrip;
                }

                // Get parent.
                Component objParent = this.InternalParent;
                if (objParent != null)
                {
                    // Returns parent's context menu strip.
                    return objParent.ContextMenuStripInherited;
                }

                // Return default value.
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Gets the current application context.
        /// </summary>
        /// <value></value>
        public override IContext Context
        {
            get
            {
                // Get the component parent
                Component objParent = this.InternalParent;

                // If there is a valid parent
                if (objParent != null)
                {
                    // Return the parent context
                    return objParent.Context;
                }
                else
                {
                    // Get the static context reference
                    return VWGContext.Current;
                }

            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        protected WinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                if (mobjWinFormsCompatibility == null)
                {
                    mobjWinFormsCompatibility = GetWinFormsCompatibility();
                    mobjWinFormsCompatibility.OptionValueChanged += WinFormsCompatibilityOptionValueChanged;
                }

                return mobjWinFormsCompatibility;
            }
        }

        #endregion

        #region Optimized Serialization Implementation

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                return base.SerializableDataInitialSize + 4;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the component state
            mobjInternalParent = (Component)objReader.ReadObject();
            mintComponentState = objReader.ReadInt32();
            mobjContextMenu = (ContextMenu)objReader.ReadObject();
            mobjContextMenuStrip = (ContextMenuStrip)objReader.ReadObject();
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the component state
            objWriter.WriteObject(mobjInternalParent);
            objWriter.WriteInt32(mintComponentState);
            objWriter.WriteObject(mobjContextMenu);
            objWriter.WriteObject(mobjContextMenuStrip);
        }

        #endregion
    }


    /// <summary>
    /// Class for converting dragtarget property,
    /// To disable the '+' sign in the designer.
    /// </summary>
    public class DragTargetsTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return false;
        }
    }
    #endregion
}
