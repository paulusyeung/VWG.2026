using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;
using System.Reflection;
using Gizmox.WebGUI.Forms.Client;

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    internal delegate void UiPropertyValueChangedEventHandler(object sender, ProxyPropertyValueEventArgs e);

    #endregion

    /// <summary>
    /// The proxy control
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    [ContextualToolbar.ContextualToolbar(typeof(ContextualToolbar.ProxyControlContextualToolbar))]
    public class ProxyControl : ProxyComponent
    {
        #region Events

        /// <summary>
        /// Occurs when [getting property value].
        /// </summary>
        internal event UiPropertyValueChangedEventHandler UiPropertyValueChanged
        {
            add
            {
                mobjUiPropertyValueChangedEventHandler += value;
            }
            remove
            {
                mobjUiPropertyValueChangedEventHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when [UI property value changing].
        /// </summary>
        internal event UiPropertyValueChangedEventHandler UiPropertyValueChanging
        {
            add
            {
                mobjUiPropertyValueChangingEventHandler += value;
            }
            remove
            {
                mobjUiPropertyValueChangingEventHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when [UI property key down].
        /// </summary>
        internal event ClientEventHandler ProxyClientKeyDown
        {
            add
            {
                this.AddClientHandler("KeyDown", value);
            }
            remove
            {
                this.RemoveClientHandler("KeyDown", value);
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangedEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangingEventHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private List<ProxyAction> mobjProxyActions;

        private string mstrName;

        /// <summary>
        /// Gets a value indicating whether [can edit cotnrol].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit cotnrol]; otherwise, <c>false</c>.
        /// </value>
        public bool CanEditCotnrol
        { 
            get 
            { 
                bool blnCanEdit = false;
                Control objControl = this.SourceComponent as Control;
                if (objControl != null)
                {
                    blnCanEdit = objControl.CanEditControl;
                }
                return blnCanEdit;
            } 
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyControl" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent,blnStateComponent) 
        {
            AddContainedControls(objComponent);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyControl"/> class.
        /// </summary>
        public ProxyControl()
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the contained controls.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        private void AddContainedControls(Component objComponent)
        {
            Control objControl = objComponent as Control;
            if (objControl != null)
            {
                foreach (Control objChildControl in objControl.Controls)
                {
                    ProxyComponent objChilProxyComponent = this.CreateProxyByComponent(objChildControl);
                    if (objChilProxyComponent != null)
                    {
                        // Creating a proxy object specific for the dropped control
                        this.Components.Add(objChilProxyComponent);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:UiPropertyValueChanged"/> event.
        /// </summary>
        /// <param name="objProxyPropertyValueEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        private void OnUiPropertyValueChanged(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
        {
            if (mobjUiPropertyValueChangedEventHandler != null)
            {
                mobjUiPropertyValueChangedEventHandler(this, objProxyPropertyValueEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:UiPropertyValueChanging"/> event.
        /// </summary>
        /// <param name="objProxyPropertyValueEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        private void OnUiPropertyValueChanging(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
        {
            if (mobjUiPropertyValueChangingEventHandler != null)
            {
                mobjUiPropertyValueChangingEventHandler(this, objProxyPropertyValueEventArgs);
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "Resize":
                    double dblWidth = Convert.ToDouble(objEvent["Width"], System.Globalization.CultureInfo.InvariantCulture);
                    double dblHeight = Convert.ToDouble(objEvent["Height"], System.Globalization.CultureInfo.InvariantCulture);

                    this.SetUiPropertyValue("Size", new Size(Convert.ToInt32(dblWidth), Convert.ToInt32(dblHeight)));
                    break;
                case "Move":
                    double dblLeft = -1;
                    double dblTop = -1;

                    if (CommonUtils.TryParse(objEvent["Left"], out dblLeft) && CommonUtils.TryParse(objEvent["Top"], out dblTop))
                    {
                        this.SetUiPropertyValue("Location", new Point(Convert.ToInt32(dblLeft), Convert.ToInt32(dblTop)));
                    }
                    break;
            }

            base.FireEvent(objEvent);
        }

        public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
        {
            // NOTE: If there is "KeyDown" client event, we will return the "Emulation" client events.
            if (HasClientHandler("KeyDown"))
            {
                if (strPropertyName == "ShouldRenderClientEvents")
                {
                    object objResult = true;
                    return (T)objResult;
                }
                else if (strPropertyName == "ClientEvents")
                {
                    object objResult = ((IClientComponent)this).Events;
                    return (T)objResult;
                }
            }

            return base.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue);
        }

        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("KeyDown"))
            {
                objEvents.Set(WGEvents.KeyDown);
            }

            return objEvents;
        }


        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // Right click event for the context menu.
            if (HasRightClickSupport())
            {
                objEvents.Set(WGEvents.RightClick);
            }

            return objEvents;
        }

        /// <summary>
        /// Determines whether element has right click support for the context menu.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has right click support]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool HasRightClickSupport()
        {
            return true;
        }

        /// <summary>
        /// Sets the UI property value.
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objValue">The obj value.</param>
        internal void SetUiPropertyValue(string strPropertyName, object objValue)
        {
            bool blnValueChanged = false;

            ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs = new ProxyPropertyValueEventArgs(strPropertyName, objValue);

            this.OnUiPropertyValueChanging(objProxyPropertyValueEventArgs);

            objValue = objProxyPropertyValueEventArgs.Value;

            if (this.PropertyBag.ContainsKey(strPropertyName))
            {
                if (this.PropertyBag[strPropertyName] != objValue)
                {
                    this.PropertyBag[strPropertyName] = objValue;
                    blnValueChanged = true;
                }
            }
            else
            {
                this.PropertyBag.Add(strPropertyName, objValue);
                blnValueChanged = true;
            }

            if (blnValueChanged)
            {
                this.OnUiPropertyValueChanged(new ProxyPropertyValueEventArgs(strPropertyName, objValue));
            }
        }

        /// <summary>
        /// Validates the source component.
        /// </summary>
        internal override void ValidateSourceComponent()
        {
            Component objCurrentComponent = this.CachedSourceCompomnent;
            Component objSourceComponent = base.SourceComponent;

            // Check if source component changed
            if (objCurrentComponent != objSourceComponent)
            {
                ProxyComponent objParent = this.Parent;
                if (objParent != null)
                {
                    Component objParentSourceComponent = objParent.SourceComponent;
                    if (objParentSourceComponent != null)
                    {
                        objParentSourceComponent.Update();
                    }
                }
            }
            else
            {
                base.ValidateSourceComponent();
            }
        }

        /// <summary>
        /// Gets the proxy component properties.
        /// </summary>
        /// <param name="arrAttributes">The arr attributes.</param>
        /// <returns></returns>
        protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objPropertyDescriptorCollection = base.GetProxyComponentProperties(arrAttributes);

            // Get all properties of a proxy form.
            PropertyDescriptorCollection arrPropertyDescriptors = TypeDescriptor.GetProperties(this, arrAttributes, true);

            foreach (PropertyDescriptor objPropertyDescriptor in arrPropertyDescriptors)
            {
                if (objPropertyDescriptor.Name == "Actions")
                {
                    objPropertyDescriptorCollection.Add(objPropertyDescriptor);
                }
            }

            return objPropertyDescriptorCollection;
        }

        /// <summary>
        /// Gets the proxy component property owner.
        /// </summary>
        /// <param name="objPropertyDescriptor"></param>
        /// <returns></returns>
        protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "Actions")
            {
                return this;
            }
            else
            {
                return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
            }
        }


        /// <summary>
        /// Shoulds the serialize actions.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeActions()
        {
            return mobjProxyActions != null && mobjProxyActions.Count > 0;
        }

        /// <summary>
        /// PreRenders the specified object.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public override void PreRender(IContext objContext, long lngRequestID)
        {
            Control objSourceControl = this.SourceComponent as Control;
            if (objSourceControl != null)
            {
                objSourceControl.ProxyComponent = this;

                objSourceControl.PreRenderControl(objContext, lngRequestID);

                objSourceControl.ProxyComponent = null;
            }
        }

        /// <summary>
        /// Happenes after the render.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="lngRequestID">The LNG request identifier.</param>
        public override void PostRender(IContext objContext, long lngRequestID)
        {
            Control objSourceControl = this.SourceComponent as Control;
            if (objSourceControl != null)
            {
                objSourceControl.ProxyComponent = this;

                objSourceControl.PostRenderControl(objContext, lngRequestID);

                objSourceControl.ProxyComponent = null;
            }
        }

        /// <summary>
        /// Registers the actions events.
        /// </summary>
        internal void RegisterActionsEvents()
        {
            if (mobjProxyActions != null && mobjProxyActions.Count > 0)
            {
                Control objControl = this.SourceComponent as Control;
                if (objControl != null)
                {
                    Type objControlType = objControl.GetType();
                    object[] objCustomAttributes = objControlType.GetCustomAttributes(typeof(DefaultEventAttribute), true);
                    if (objCustomAttributes.Length > 0)
                    {
                        DefaultEventAttribute objDefaultEventAttribute = objCustomAttributes[0] as DefaultEventAttribute;
                        if (objDefaultEventAttribute != null)
                        {
                            EventInfo objEventInfo = objControlType.GetEvent(objDefaultEventAttribute.Name);
                            if (objEventInfo != null)
                            {
                                MethodInfo objMethodInfo = this.GetType().GetMethod("ExecuteProxyAction", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                                if (objMethodInfo != null)
                                {
                                    Delegate objDelegate = Delegate.CreateDelegate(objEventInfo.EventHandlerType, this, objMethodInfo);
                                    objEventInfo.RemoveEventHandler(objControl, objDelegate);
                                    objEventInfo.AddEventHandler(objControl, objDelegate);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Executes the proxy action.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ExecuteProxyAction(object sender, EventArgs e)
        {
            if (mobjProxyActions != null && mobjProxyActions.Count > 0)
            {
                foreach (ProxyAction objProxyAction in mobjProxyActions)
                {
                    objProxyAction.Execute();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Component GetSourceComponent()
        {
            if (!this.IsStateComponent)
            {
                ProxyComponent objProxyParent = this.Parent;

                if (objProxyParent != null && !objProxyParent.IsStateComponent)
                {
                    Control objParentControl = objProxyParent.SourceComponent as Control;
                    if (objParentControl != null)
                    {
                        int intIndex = objProxyParent.Components.IndexOf(this);

                        if (intIndex >= 0 && intIndex < objParentControl.Controls.Count)
                        {
                            return objParentControl.Controls[intIndex];
                        }
                    }
                }
            }

            return base.GetSourceComponent(); 
        }

        /// <summary>
        /// Shows the contextual toolbar.
        /// </summary>
        public void ShowContextualToolbar(EventHandler objOnEditorWindowOpen, EventHandler objOnEditorWindowClosed)
        {
            ContextualToolbar.ContextualToolbar.ShowContextualToolbar(this, objOnEditorWindowOpen, objOnEditorWindowClosed);
        }
        
        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Name
        {
            get
            {
                Control objControl = SourceComponent as Control;
                if (objControl != null)
                {
                    return string.Format("{0} ({1})", objControl.Name, objControl.GetType().Name);
                }

                return base.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>
        /// The actions.
        /// </value>
        #if WG_NET46
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
        #elif WG_NET452
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
        #elif WG_NET451
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
        #elif WG_NET45
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
#elif WG_NET40
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
#elif WG_NET35
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
#elif WG_NET2
        [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor)), MergableProperty(false)]
#endif
        public List<ProxyAction> Actions
        {
            get
            {
                if (mobjProxyActions == null)
                {
                    mobjProxyActions = new List<ProxyAction>();
                }
                return mobjProxyActions;
            }
            set
            {
                mobjProxyActions = value;
            }
        }

        #endregion Properties
    }
}