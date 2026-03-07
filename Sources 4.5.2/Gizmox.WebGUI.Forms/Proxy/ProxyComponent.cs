using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    internal delegate void GettingPropertyValueEventHandler(object sender, ProxyPropertyValueEventArgs e);
    internal delegate void SourceComponentFireEventHandler(object sender, ProxyFireEventArgs e);
    internal delegate void ProxyComponentChangingEventHandler(object sender, ProxyPropertyValueEventArgs e);
    internal delegate void FilterPropertiesEventHandler(object sender, ProxyFilterPropertiesEventArgs e);

    #endregion

    /// <summary>
    /// The basic proxy component
    /// </summary>
    [Serializable()]
    public class ProxyComponent : Component, ICustomTypeDescriptor
    {
        #region Events

        /// <summary>
        /// Unsubscribe to get  events of proxy control with children.
        /// </summary>
        protected void UnsubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
        {
            GettingPropertyValueEventHandler objGettingPropertyValueEventHandler = GettingPropertyValueEventHandler;
            if (objGettingPropertyValueEventHandler != null)
            {
                objProxyComponent.GettingPropertyValue -= objGettingPropertyValueEventHandler;
            }

            FilterPropertiesEventHandler objFilterPropertiesEventHandler = FilterPropertiesEventHandler;
            if (objFilterPropertiesEventHandler != null)
            {
                objProxyComponent.FilterProperties -= objFilterPropertiesEventHandler;
            }

            foreach (ProxyComponent objChildProxyComponent in objProxyComponent.Components)
            {
                UnsubscribeGetEventsWithChildren(objChildProxyComponent);
            }
        }

        /// <summary>
        /// Subscribe to get events of proxy control with children.
        /// </summary>
        protected void SubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
        {
            GettingPropertyValueEventHandler objGettingPropertyValueEventHandler = GettingPropertyValueEventHandler;
            if (objGettingPropertyValueEventHandler != null)
            {
                objProxyComponent.GettingPropertyValue += objGettingPropertyValueEventHandler;
            }

            FilterPropertiesEventHandler objFilterPropertiesEventHandler = FilterPropertiesEventHandler;
            if (objFilterPropertiesEventHandler != null)
            {
                objProxyComponent.FilterProperties += objFilterPropertiesEventHandler;
            }

            foreach (ProxyComponent objChildProxyComponent in objProxyComponent.Components)
            {
                SubscribeGetEventsWithChildren(objChildProxyComponent);
            }
        }

        /// <summary>
        /// Occurs when [getting property value].
        /// </summary>
        internal event GettingPropertyValueEventHandler GettingPropertyValue
        {
            add
            {
                mobjGettingPropertyValueEventHandler += value;
            }
            remove
            {
                mobjGettingPropertyValueEventHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when [filter properties].
        /// </summary>
        internal event FilterPropertiesEventHandler FilterProperties
        {
            add
            {
                mobjFilterPropertiesEventHandler += value;
            }
            remove
            {
                mobjFilterPropertiesEventHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when [source component fire event].
        /// </summary>
        internal event SourceComponentFireEventHandler SourceComponentFireEvent
        {
            add
            {
                mobjSourceComponentFireEventHandler += value;
            }
            remove
            {
                mobjSourceComponentFireEventHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when [getting property value].
        /// </summary>
        internal event ProxyComponentChangingEventHandler ProxyComponentChanging
        {
            add
            {
                mobjProxyComponentChangingEventHandler += value;
            }
            remove
            {
                mobjProxyComponentChangingEventHandler -= value;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private EventHandler mobjProxyClickEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private GettingPropertyValueEventHandler mobjGettingPropertyValueEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private SourceComponentFireEventHandler mobjSourceComponentFireEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private ProxyComponentChangingEventHandler mobjProxyComponentChangingEventHandler = null;

        /// <summary>
        /// The filter properties event handler
        /// </summary>
        private FilterPropertiesEventHandler mobjFilterPropertiesEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private ProxySet mobjComponents = new ProxySet();

        /// <summary>
        /// The property bag
        /// </summary>
        private ProxyPropertyBag mobjPropertyBag = new ProxyPropertyBag();

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private ProxyComponent mobjParent = null;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        protected Form mobjParentForm = null;

        /// <summary>
        /// The unique ID
        /// </summary>
        private string mstrUniqueID = null;

        /// <summary>
        /// The cached proxy compomnent (only valid for runtim mode)
        /// </summary>
        private Component mobjCachedSourceCompomnent = null;

        /// <summary>
        /// The MSTR custom component type
        /// </summary>
        private string mstrNonStateComponentType;

        private bool mblnProxyInitialized = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyComponent" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyComponent(Component objComponent, ProxyComponent objParent, bool blnStateComponent) : this()
        {
            this.Parent = objParent;
            if (blnStateComponent)
            {
                PreserveComponentUniqueID(objComponent);
            }
            else
            {
                UpdateNonStateComponentType(objComponent);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyComponent"/> class.
        /// </summary>
        public ProxyComponent()
        {
            // Initializing events
            this.PropertyBag.PropertyValueChanging += PropertyBag_PropertyValueChanging;
        }

        /// <summary>
        /// Preserves the component unique ID.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void PreserveComponentUniqueID(Component objComponent)
        {
            this.UniqueID = this.GetComponentUniqueID(this.ParentForm, objComponent);
        }

        private void UpdateNonStateComponentType(Component objComponent)
        {
            mobjCachedSourceCompomnent = objComponent;
            mstrNonStateComponentType = objComponent.GetType().AssemblyQualifiedName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [is custom].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is custom]; otherwise, <c>false</c>.
        /// </value>
        public bool IsStateComponent
        {
            get
            {
                return string.IsNullOrEmpty(mstrNonStateComponentType);
            }
        }

        /// <summary>
        /// Gets the type of the custom component.
        /// </summary>
        /// <value>
        /// The type of the custom component.
        /// </value>
        public string NonStateComponentType
        {
            get
            {
                return mstrNonStateComponentType;
            }
            set
            {
                mstrNonStateComponentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string Name
        {
            get
            {
                return ToString();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual Component GetSourceComponent()
        {
            if (this.IsStateComponent)
            {
                // Load the source component and store it.
                return GetComponentByUniqueId(this.ParentForm, this.UniqueID);
            }
            else
            {
                Component objSourceComponent = Activator.CreateInstance(Type.GetType(NonStateComponentType)) as Component;

                // Checking there is a source component
                if (objSourceComponent != null)
                {
                    // Checking if the parent is valid
                    if (this.Parent != null)
                    {
                        // Setting the internalParent, so when asking about the Forms property, the Form will be the parents on.
                        // This solved a bug when trying to expand datetimepicker to a non state component, and the item had no defined form to relate to.
                        objSourceComponent.InternalParent = this.Parent.SourceComponent;
                    }
                }

                return objSourceComponent;
            }
        }

        /// <summary>
        /// Gets the getting property value event handler.
        /// </summary>
        /// <value>
        /// The getting property value event handler.
        /// </value>
        internal GettingPropertyValueEventHandler GettingPropertyValueEventHandler
        {
            get
            {
                return mobjGettingPropertyValueEventHandler;
            }
        }

        /// <summary>
        /// Gets the filter properties event handler.
        /// </summary>
        /// <value>
        /// The filter properties event handler.
        /// </value>
        internal FilterPropertiesEventHandler FilterPropertiesEventHandler
        {
            get
            {
                return mobjFilterPropertiesEventHandler;
            }
        }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        public virtual ProxySet Components
        {
            get
            {
                return mobjComponents;
            }
        }

        /// <summary>
        /// Gets a value indicating whether proxy component is visible.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Visible
        {
            get
            {
                bool blnVisible = GetVisible();
                return blnVisible;
            }
        }

        /// <summary>
        /// Returns wether proxy component is visible.
        /// </summary>
        protected virtual bool GetVisible()
        {
            if (this.PropertyBag.ContainsKey("Visible") && ((bool)this.PropertyBag["Visible"]) == false)
            {
                return false;
            }

            Control objSourceControl = this.SourceComponent as Control;
            if (objSourceControl != null && !objSourceControl.Visible)
            {
                return false;
            }

            if (this.Parent == null) { return true; }

            bool blnVisible = this.Parent.GetVisible();
            return blnVisible;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the owner form.
        /// </summary>
        public override Form Form
        {
            get
            {
                if (this.ParentForm != null)
                    return this.ParentForm;

                return base.Form;
            }
        }

        /// <summary>
        /// Initializes the emulation.
        /// </summary>
        internal virtual void InitializeProxy()
        {
            foreach (ProxyComponent objComponent in this.Components)
            {
                objComponent.InitializeProxy();
            }

            mblnProxyInitialized = true;
        }

        /// <summary>
        /// Gets a value indicating whether InitializeProxy already been called for this component.
        /// </summary>
        protected bool ProxyInitialized
        {
            get
            {
                return mblnProxyInitialized;
            }
        }

        /// <summary>
        /// Sign proxy as initialized.
        /// </summary>
        protected void SetProxyInitialized()
        {
            mblnProxyInitialized = true;
        }

        /// <summary>
        /// Gets the child proxy component.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <returns></returns>
        internal ProxyComponent GetChildProxyComponent(Component objComponent)
        {
            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                if (objProxyComponent.SourceComponent == objComponent)
                {
                    return objProxyComponent;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the proxy component from component.
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        /// <param name="objParentControl">The object parent control.</param>
        /// <returns></returns>
        internal static ProxyComponent CreateProxyComponentFromComponent(Component objComponent, ProxyComponent objParentControl, bool blnStateComponent)
        {
            ProxyComponent objReturnProxy = null;

            // Get it's proxy control.
            object[] objAttributes = objComponent.GetType().GetCustomAttributes(typeof(ProxyComponentAttribute), true);
            if (objAttributes.Length == 1)
            {
                // Getting the proxy type
                Type objProxyType = ((ProxyComponentAttribute)objAttributes[0]).ProxyComponentType;

                // Creating a proxy object specific for the dropped control
                objReturnProxy = Activator.CreateInstance(objProxyType, new object[] { objComponent, objParentControl, blnStateComponent }) as ProxyComponent;
            }

            return objReturnProxy;
        }

        /// <summary>
        /// Creates the proxy by component.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <returns></returns>
        protected ProxyComponent CreateProxyByComponent(Component objComponent)
        {
            return ProxyComponent.CreateProxyComponentFromComponent(objComponent, this, this.IsStateComponent);
        }

        /// <summary>
        /// Raises the <see cref="E:GettingPropertyValue"/> event.
        /// </summary>
        /// <param name="objProxyPropertyValueEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        private void OnGettingPropertyValue(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
        {
            if (mobjGettingPropertyValueEventHandler != null)
            {
                mobjGettingPropertyValueEventHandler(this, objProxyPropertyValueEventArgs);
            }
        }


        /// <summary>
        /// Raises the <see cref="E:FilterProperties" /> event.
        /// </summary>
        /// <param name="objProxyFilterPropertiesEventArgs">The <see cref="ProxyFilterPropertiesEventArgs"/> instance containing the event data.</param>
        private void OnFilterProperties(ProxyFilterPropertiesEventArgs objProxyFilterPropertiesEventArgs)
        {
            if (mobjFilterPropertiesEventHandler != null)
            {
                mobjFilterPropertiesEventHandler(this, objProxyFilterPropertiesEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:SourceComponentFireEvent"/> event.
        /// </summary>
        /// <param name="objFireEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyFireEventArgs"/> instance containing the event data.</param>
        internal virtual void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
        {
            if (mobjSourceComponentFireEventHandler != null)
            {
                mobjSourceComponentFireEventHandler(this, objFireEventArgs);
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanging event of the PropertyBag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        internal void PropertyBag_PropertyValueChanging(object sender, ProxyPropertyValueEventArgs e)
        {
            OnPropertyValueChanging(e);
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyValueChanging" /> event.
        /// </summary>
        /// <param name="objProxyPropertyValueEventArgs">The <see cref="ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        internal virtual void OnPropertyValueChanging(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
        {
            if (mobjProxyComponentChangingEventHandler != null)
            {
                mobjProxyComponentChangingEventHandler(this, objProxyPropertyValueEventArgs);
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (this.mobjProxyClickEventHandler != null)
            {
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "Click")
            {
                OnProxyClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
            }

            ProxyFireEventArgs objFireEventArgs = new ProxyFireEventArgs(objEvent, true);

            this.OnSourceComponentFireEvent(objFireEventArgs);

            if (objFireEventArgs.AllowEvent)
            {
                if (this.SourceComponent != null)
                {
                    this.SourceComponent.FireComponentEvent(objEvent);
                }
            }
        }

        private void OnProxyClick(EventArgs objEventArgs)
        {
            // Raise click evnet.
            if (mobjProxyClickEventHandler != null)
            {
                MouseEventArgs objMouseEventArgs = objEventArgs as MouseEventArgs;
                if (objMouseEventArgs == null)
                {
                    objMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
                }

                mobjProxyClickEventHandler(this, objMouseEventArgs);
            }
        }

        /// <summary>
        /// Occurs when [UI property value changing].
        /// </summary>
        internal event EventHandler ProxyClick
        {
            add
            {
                mobjProxyClickEventHandler += value;
            }
            remove
            {
                mobjProxyClickEventHandler -= value;
            }
        }

        /// <summary>
        /// Shoulds the type of the serialize custom component.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeNonStateComponentType()
        {
            return NonStateComponentType != null;
        }

        /// <summary>
        /// Shoulds the serialize unique identifier.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeUniqueID()
        {
            return UniqueID != null;
        }

        /// <summary>
        /// Gets the proxy property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objDefaultValue">The obj default value.</param>
        /// <returns></returns>
        public virtual T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
        {
            if (strPropertyName == "ID")
            {
                object objID = this.ID;
                return (T)objID;
            }

            T objValue = objDefaultValue;

            // Check if requested property exists.
            if (mobjPropertyBag.ContainsKey(strPropertyName))
            {
                // Try getting object value.
                object objPropertyValue = mobjPropertyBag[strPropertyName];
                if (objPropertyValue != null)
                {
                    // Validate that recieved object is from the right type.
                    if (objPropertyValue is T)
                    {
                        // Cast value.
                        objValue = (T)objPropertyValue;
                    }
                }
            }

            // Create  a new ProxyPropertyValueEventArgs.
            ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs = new ProxyPropertyValueEventArgs(strPropertyName, objValue);

            // Raise the GettingPropertyValue event.
            this.OnGettingPropertyValue(objProxyPropertyValueEventArgs);

            // Return value.
            return (T)objProxyPropertyValueEventArgs.Value;
        }

        /// <summary>
        /// Determines whether [has proxy property value] [the specified STR property name].
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <returns>
        ///   <c>true</c> if [has proxy property value] [the specified STR property name]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasProxyPropertyValue(string strPropertyName)
        {
            return mobjPropertyBag.ContainsKey(strPropertyName);
        }

        /// <summary>
        /// Gets the component by path.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="strPathPart">The STR path part.</param>
        /// <returns></returns>
        private Component GetComponentByPath(Component objComponent, string strPathPart)
        {
            int intPosition = 0;
            string strTypeName = strPathPart;

            int intOpenBracketPosition = strPathPart.IndexOf('[');
            if (intOpenBracketPosition != -1)
            {
                strTypeName = strPathPart.Substring(0, intOpenBracketPosition);

                int intCloseBracketPosition = strPathPart.IndexOf(']');
                if (intCloseBracketPosition != -1)
                {
                    intPosition = Convert.ToInt32(strPathPart.Substring(intOpenBracketPosition + 1, intCloseBracketPosition - intOpenBracketPosition - 1));
                }
            }

            IList objList = objComponent.GetComponentOffsprings(strTypeName);
            if (objList != null)
            {
                if (intPosition < objList.Count)
                {
                    Component objChildComponent = objList[intPosition] as Component;
                    if (objChildComponent != null)
                    {
                        if (strTypeName == objChildComponent.GetType().FullName)
                        {
                            return objChildComponent;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the component by unique id.
        /// </summary>
        /// <param name="objSourceComponent">The obj source component.</param>
        /// <param name="strComponentPath">The STR component path.</param>
        /// <returns></returns>
        internal Component GetComponentByUniqueId(Component objSourceComponent, string strComponentPath)
        {
            Component objComponent = objSourceComponent;

            if (objSourceComponent != null && !string.IsNullOrEmpty(strComponentPath))
            {
                string[] arrComponentPath = strComponentPath.Split('/');
                if (arrComponentPath.Length >= 1)
                {
                    objComponent = this.GetComponentByPath(objSourceComponent, arrComponentPath[0]);

                    if (arrComponentPath.Length > 1)
                    {
                        objComponent = GetComponentByUniqueId(objComponent, string.Join("/", arrComponentPath, 1, arrComponentPath.Length - 1));
                    }
                }
            }

            return objComponent;
        }

        /// <summary>
        /// Renders the specified obj context.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public virtual void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            Component objSourceComponent = this.SourceComponent;
            if (objSourceComponent != null)
            {
                IRenderableComponent objRenderableComponent = objSourceComponent as IRenderableComponent;
                if (objRenderableComponent != null)
                {
                    objSourceComponent.ProxyComponent = this;

                    objRenderableComponent.RenderComponent(objContext, objWriter, lngRequestID);

                    objSourceComponent.ProxyComponent = null;
                }
            }
        }

        /// <summary>
        /// Renders the components.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public virtual void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.Components.RenderSet(objContext, objWriter, lngRequestID);
        }


        /// <summary>
        /// PreRenders the specified object.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public virtual void PreRender(IContext objContext, long lngRequestID)
        {

        }

        /// <summary>
        /// Pres the render components.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void PreRenderComponents(IContext objContext, long lngRequestID)
        {
            this.Components.PreRenderSet(objContext, lngRequestID);
        }

        /// <summary>
        /// Posts the render.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="lngRequestID">The LNG request identifier.</param>
        public virtual void PostRender(IContext objContext, long lngRequestID)
        {

        }

        /// <summary>
        /// Posts the render components.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="lngRequestID">The LNG request identifier.</param>
        public virtual void PostRenderComponents(IContext objContext, long lngRequestID)
        {
            this.Components.PostRenderSet(objContext, lngRequestID);
        }


        /// <summary>
        /// Validates the source component.
        /// </summary>
        internal virtual void ValidateSourceComponent()
        {
            // Loop on all sub components and validate SourceComponent
            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                objProxyComponent.ValidateSourceComponent();
            }
        }

        /// <summary>
        /// Happens after the load of the component from XAML.
        /// </summary>
        public virtual void OnLoad()
        {
            // Loop on all sub components and validate SourceComponent
            foreach (ProxyComponent objProxyComponent in Components)
            {
                if (objProxyComponent != null)
                {
                    objProxyComponent.OnLoad();
                }
            }
        }

        #endregion Methods

        #region Properties


        /// <summary>
        /// Gets the unique ID.
        /// </summary>
        /// <value>
        /// The unique ID.
        /// </value>
        public string UniqueID
        {
            get
            {
                return mstrUniqueID;
            }
            set
            {
                mstrUniqueID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool ShouldGetSourceComponent
        {
            get
            {
                if (this.IsStateComponent)
                {
                    return mobjCachedSourceCompomnent == null || !mobjCachedSourceCompomnent.IsRegistered;
                }
                else
                {
                    return mobjCachedSourceCompomnent == null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the source component.
        /// </summary>
        /// <value>
        /// The source component.
        /// </value>
        internal Component SourceComponent
        {
            get
            {
                // if in Runtime mode and there is no cache
                if (this.ShouldGetSourceComponent)
                {
                    // Ensures the control reference.
                    mobjCachedSourceCompomnent = GetSourceComponent();
                }

                // Return chached mode
                return mobjCachedSourceCompomnent;
            }
        }

        /// <summary>
        /// Gets the cached source compomnent.
        /// </summary>
        /// <value>
        /// The cached source compomnent.
        /// </value>
        internal Component CachedSourceCompomnent
        {
            get
            {
                return mobjCachedSourceCompomnent;
            }
        }

        /// <summary>
        /// Gets the property bag.
        /// </summary>
        public ProxyPropertyBag PropertyBag
        {
            get
            {
                return mobjPropertyBag;
            }
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        public virtual ProxyComponent Parent
        {
            get
            {
                return mobjParent;
            }
            set
            {
                this.mobjParent = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent form.
        /// </summary>
        /// <value>
        /// The parent form.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Form ParentForm
        {
            get
            {
                // If ParentForm was set, we will use it.
                if (mobjParentForm != null)
                {
                    return mobjParentForm;
                }

                if (this.Parent != null)
                {
                    return this.Parent.ParentForm;
                }

                return null;
            }
            set
            {
                mobjParentForm = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is emulation mode.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is emulation mode; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmulationMode
        {
            get
            {
                IContextParams objContextParams = this.Context as IContextParams;
                if (objContextParams != null)
                {
                    return objContextParams.EmulatorForm != null;
                }

                return false;
            }
        }

        #endregion

        #region ICustomTypeDescriptor Members

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return GetCustomProperties(attributes);
        }

        /// <summary>
        /// Gets the custom properties.
        /// </summary>
        /// <param name="arrAttributes">The attributes.</param>
        /// <returns></returns>
        private PropertyDescriptorCollection GetCustomProperties(Attribute[] arrAttributes)
        {
            // Gets the proxy component properties.
            PropertyDescriptorCollection objPropertyDescriptorCollection =  GetProxyComponentProperties(arrAttributes);

            this.OnFilterProperties(new ProxyFilterPropertiesEventArgs(objPropertyDescriptorCollection));            

            return objPropertyDescriptorCollection;
        }       

        /// <summary>
        /// Gets the proxy component property owner.
        /// </summary>
        /// <returns></returns>
        protected virtual object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            return SourceComponent;
        }

        /// <summary>
        /// Gets the proxy component properties.
        /// </summary>
        /// <param name="arrAttributes">The arr attributes.</param>
        /// <returns></returns>
        protected virtual PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
        {
            List<PropertyDescriptor> arrFiltredDescriptors = new List<PropertyDescriptor>();

            Component objSourceComponent = this.SourceComponent;
            if (objSourceComponent != null)
            {
                PropertyDescriptorCollection arrPropertyDescriptors = TypeDescriptor.GetProperties(objSourceComponent, arrAttributes, true);

                // Checking if a property is a proxybrowsable to show in emulator.
                foreach (PropertyDescriptor objPropertyDescriptor in arrPropertyDescriptors)
                {
                    ProxyBrowsableAttribute objProxyBrowsableAttribute = objPropertyDescriptor.Attributes[typeof(ProxyBrowsableAttribute)] as ProxyBrowsableAttribute;
                    if (objProxyBrowsableAttribute != null)
                    {
                        // If true, add to property list
                        if (objProxyBrowsableAttribute.Browsable)
                        {
                            BrowsableAttribute objBrowsableAttribute = objPropertyDescriptor.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;

                            if (objBrowsableAttribute == null || objBrowsableAttribute.Browsable == true)
                            {
                                arrFiltredDescriptors.Add(objPropertyDescriptor);
                            }
                        }
                    }
                }
            }

            return new PropertyDescriptorCollection(arrFiltredDescriptors.ToArray());
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return this.GetCustomProperties(null);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            return GetProxyComponentPropertyOwner(objPropertyDescriptor);
        }

        #endregion
    }
}
