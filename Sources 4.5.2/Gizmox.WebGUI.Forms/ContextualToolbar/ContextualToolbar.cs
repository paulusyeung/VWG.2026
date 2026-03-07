#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using System.Reflection;
using Gizmox.WebGUI.Common.Resources;


#endregion

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
    internal delegate void ContextualToolbarPropertyValueChangedEventHandler(object sender, ContextualToolbarPropertyValueEventArgs e);

    /// <summary>
    /// Summary description for ContextualToolbar
    /// </summary>
    [ToolboxItem(false)]
    [Serializable()]
    [Skin(typeof(ContextualToolbarSkin))]
    internal class ContextualToolbar : Form, IServiceProvider, IWebUIEditorService
    {
        private PropertyInfo mobjControlProperty = null;
        private Component mobjComponent = null;
        private Point mobjEditorDialogLocation = Point.Empty;
        private ContextualToolbarPropertyValueChangedEventHandler mobjCustomPropertyValueChangeEvent = null;
        private List<ContextualToolbarButton> mobjListOfButtons = new List<ContextualToolbarButton>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualToolbar"/> class.
        /// </summary>
        public ContextualToolbar()
        {
            this.CustomStyle = "ContextualToolbar";
            this.InitContextualToolbarButtons();
        }

        /// <summary>
        /// Initializes the base buttons buttons.
        /// </summary>
        protected virtual void InitContextualToolbarButtons()
        {
            ContextualToolbarSkin objSkin = this.Skin as ContextualToolbarSkin;
            this.AddChild(new ContextualToolbarButton("Font", objSkin.ContextualToolbarFont, "Change the font type and size."));
            this.AddChild(new ContextualToolbarButton("ForeColor", objSkin.ContextualToolbarForeColor, "Change the text color."));
            this.AddChild(new ContextualToolbarButton("BackColor",  objSkin.ContextualToolbarBackColor, "Change the background color."));
            this.AddChild(new ContextualToolbarButton("Dock", objSkin.ContextualToolbarDock, "Change the docking type."));
        }

        /// <summary>
        /// Gets or sets a value indicating whether [activate on pre render].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [activate on pre render]; otherwise, <c>false</c>.
        /// </value>
        protected override bool ActivateOnShow
        {
            get
            {
                // Prevents from the focusing the control on activate, so key down will work on the original form.
                return false;
            }
            set
            {
                base.ActivateOnShow = value;
            }
        }

        /// <summary>
        /// Will contain information about a button data
        /// </summary>
        [Serializable()]
        protected class ContextualToolbarButton : RegisteredComponent
        {
            private ContextualToolbar mobjOwnerContextualToolbar = null;
            private string mstrPropertyName;
            private ImageResourceReference mobjButtonImageResourceReference;
            private string mstrTooltip;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContextualToolbarButton"/> class.
            /// </summary>
            /// <param name="strPropertyName">Name of the string property.</param>
            /// <param name="strCssClassName">Name of the string CSS class.</param>
            /// <param name="objButtonImageResourceReference">The object button image resource reference.</param>
            /// <param name="strTooltip">The string tooltip.</param>
            public ContextualToolbarButton(string strPropertyName, ImageResourceReference objButtonImageResourceReference, string strTooltip)
            {
                this.mstrPropertyName = strPropertyName;
                this.mobjButtonImageResourceReference = objButtonImageResourceReference;
                this.mstrTooltip = strTooltip;
            }

            /// <summary>
            /// Gets the current application context.
            /// </summary>
            public override IContext Context
            {
                get
                {
                    if (mobjOwnerContextualToolbar != null)
                    {
                        return mobjOwnerContextualToolbar.Context;
                    }
                    return VWGContext.Current;
                }
            }

            /// <summary>
            /// Gets or sets the owner contextual toolbar.
            /// </summary>
            /// <value>
            /// The owner contextual toolbar.
            /// </value>
            public ContextualToolbar Owner
            {
                get
                {
                    return this.mobjOwnerContextualToolbar;
                }
                set
                {
                    this.mobjOwnerContextualToolbar = value;
                }
            }


            /// <summary>
            /// Renders the contextualtoolbar.
            /// </summary>
            /// <param name="objContext">The object context.</param>
            /// <param name="objWriter">The object writer.</param>
            /// <param name="lngRequestID">The LNG request identifier.</param>
            protected internal virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
            {   
                // write control element tags
                objWriter.WriteStartElement(WGConst.ControlsPrefix, WGTags.ContextualToolbarButton, WGConst.ControlsNamespace);

                // add generic attributes
                RenderAttributes(objContext, (IAttributeWriter)objWriter);
                               
                // close control element tag
                objWriter.WriteEndElement();
            }

            /// <summary>
            /// Renders the attributes.
            /// </summary>
            /// <param name="objContext">The object context.</param>
            /// <param name="attributeWriter">The attribute writer.</param>
            protected virtual void RenderAttributes(IContext objContext, IAttributeWriter attributeWriter)
            {
                if (!string.IsNullOrEmpty(this.mstrPropertyName))
                {
                    attributeWriter.WriteAttributeString(WGAttributes.Name, this.mstrPropertyName);
                }

                if (this.mobjButtonImageResourceReference != null)
                {
                    attributeWriter.WriteAttributeString(WGAttributes.Image, this.mobjButtonImageResourceReference.GetValue(objContext));
                }

                if (!string.IsNullOrEmpty(this.mstrTooltip))
                {
                    attributeWriter.WriteAttributeString(WGAttributes.ToolTip, this.mstrTooltip);
                }
            }
        }

        /// <summary>
        /// The context of the contextual tool bar to be passed to editors.
        /// </summary>
        [Serializable()]
        internal class ContextualToolbarContext : ITypeDescriptorContext
        {
            private Component mobjComponent;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContextualToolbarContext"/> class.
            /// </summary>
            /// <param name="objComponent">The object component.</param>
            public ContextualToolbarContext(Component objComponent)
            {
                this.mobjComponent = objComponent;
            }

            /// <summary>
            /// Gets the container representing this <see cref="T:System.ComponentModel.TypeDescriptor" /> request.
            /// </summary>
            /// <returns>An <see cref="T:System.ComponentModel.IContainer" /> with the set of objects for this <see cref="T:System.ComponentModel.TypeDescriptor" />; otherwise, null if there is no container or if the <see cref="T:System.ComponentModel.TypeDescriptor" /> does not use outside objects.</returns>
            public IContainer Container
            {
                get
                {                    
                    return null;
                }
            }

            public object Instance
            {
                get
                {                   
                    return mobjComponent;
                }
            }

            public void OnComponentChanged()
            {                
            }

            public bool OnComponentChanging()
            {
                return true;
            }

            public PropertyDescriptor PropertyDescriptor
            {
                get { return null; }
            }

            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        #region Properties

        /// <summary>
        /// Gets or sets the control property.
        /// </summary>
        /// <value>
        /// The control property.
        /// </value>
        private PropertyInfo ControlProperty
        {
            get
            {
                return mobjControlProperty;
            }
            set
            {
                this.mobjControlProperty = value;
            }
        }

        /// <summary>
        /// Gets or sets the component.
        /// </summary>
        /// <value>
        /// The component.
        /// </value>
        private Component Component
        {
            get
            {
                return mobjComponent;
            }
            set
            {
                this.mobjComponent = value;
            }
        }

        /// <summary>
        /// Gets or sets the editor dialog location.
        /// </summary>
        /// <value>
        /// The editor dialog location.
        /// </value>
        private Point EditorDialogLocation
        {
            get
            {
                return this.mobjEditorDialogLocation;
            }
            set
            {
                this.mobjEditorDialogLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the custom property value change event.
        /// </summary>
        /// <value>
        /// The custom property value change event.
        /// </value>
        private ContextualToolbarPropertyValueChangedEventHandler CustomPropertyValueChangeEvent
        {
            get
            {
                return this.mobjCustomPropertyValueChangeEvent;
            }
            set
            {
                this.mobjCustomPropertyValueChangeEvent = value;
            }
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            foreach (ContextualToolbarButton objButton in this.mobjListOfButtons)
            {
                objButton.RenderControl(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// catched the event fired.
        /// </summary>
        /// <param name="objEvent">event.</param>
        internal static void FireEvent(Component objComponent, IEvent objEvent)
        {
            FireEvent(objComponent, objEvent, null);
        }

        /// <summary>
        /// catched the event fired.
        /// </summary>
        /// <param name="objEvent">event.</param>
        internal static void FireEvent(Component objComponent, IEvent objEvent, ContextualToolbarPropertyValueChangedEventHandler objCustomPropertyValueChangedEvent)
        {
            string strProperty = objEvent[WGAttributes.Argument];

            string strLocation = objEvent[WGAttributes.RelativePosition];

            // Check the property
            if (!String.IsNullOrEmpty(strProperty))
            {
                // Get the control type , and search for the given property.
                Type objControlType = objComponent.GetType();

                PropertyInfo objControlProperty = objControlType.GetProperty(strProperty, BindingFlags.Public | BindingFlags.Instance);
                object objValue = null;

                // If the component is control, i will try to get the value from the property.
                if (objComponent is Control)
                {                    
                    if (objControlProperty != null)
                    {
                        objValue = objControlProperty.GetValue(objComponent, null);
                    }
                }
                else 
                {
                    // In case of component, first, i will try to get the valu from the property bag and after that from the sourcecomponent.
                    ProxyComponent objProxyComponent = objComponent as ProxyComponent;
                    if (objControlProperty == null && objProxyComponent != null)
                    {
                        objProxyComponent.PropertyBag.TryGetValue(strProperty, out objValue);

                        objControlType = objProxyComponent.SourceComponent.GetType();
                        objControlProperty = objControlType.GetProperty(strProperty, BindingFlags.Public | BindingFlags.Instance);

                        if (objValue == null)
                        {
                            objValue = objControlProperty.GetValue(objProxyComponent.SourceComponent, null);
                        }
                    }
                    else if (objControlProperty != null && objProxyComponent != null) // In case the property exists in the proxy component. (as property and not in property bag...)
                    {
                        objValue = objControlProperty.GetValue(objProxyComponent, null);
                    }
                }
                                
                // If the control property is found
                if (objControlProperty != null)
                {
                    //First, checking the propertydescriptor to get the editor based on the attributes related to it specific. and then by the type.
                    //Get properties for this
                    System.ComponentModel.PropertyDescriptorCollection objPropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(objComponent);

                    //Get property descriptor for current property
                    System.ComponentModel.PropertyDescriptor objPropertyDescriptor = objPropertyDescriptorCollection[objControlProperty.Name];

                    WebUITypeEditor objWebUITypeEditor = WebUITypeEditor.GetPropertyEditor(objPropertyDescriptor, typeof(Gizmox.WebGUI.Forms.Design.WebUITypeEditor));
                    if (objWebUITypeEditor == null)
                    {
                        objWebUITypeEditor = WebUITypeEditor.GetEditor(objControlProperty.PropertyType);
                    }

                    Point objLocationPoint = Point.Empty;
                    if (!string.IsNullOrEmpty(strLocation))
                    {
                        string[] arrPoints = strLocation.Split(',');
                        int intX, intY;
                        if (int.TryParse(arrPoints[0], out intX) && int.TryParse(arrPoints[1], out intY))
                        {
                            objLocationPoint = new Point(intX, intY);
                        }                    
                    }

                    // Create a contextualToolbar with data related to the control.
                    ContextualToolbar objContextualToolbar = new ContextualToolbar();
                    objContextualToolbar.ControlProperty = objControlProperty;
                    objContextualToolbar.Component = objComponent;
                    objContextualToolbar.EditorDialogLocation = objLocationPoint;
                    objContextualToolbar.CustomPropertyValueChangeEvent = objCustomPropertyValueChangedEvent;

                    objWebUITypeEditor.EditValue(new ContextualToolbarContext(objComponent), objContextualToolbar, objValue, new WebUITypeEditorHandler(objContextualToolbar.EditPropertyValue_Callback));                    
                }
            }
        }

        /// <summary>
        /// Shows the contextual toolbar.
        /// </summary>
        /// <param name="proxyControl">The proxy control.</param>
        /// <param name="objOnEditorWindowOpen">The object on editor window open.</param>
        /// <param name="objOnEditorWindowClosed">The object on editor window closed.</param>
        internal static void ShowContextualToolbar(Component objComponent, EventHandler objOnEditorWindowOpen, EventHandler objOnEditorWindowClosed)
        {
            if (objComponent == null){return;}

            // NOTE: Check for ValidOwnerForm, for scenario that the MainForm was closed, in this case, the GetValidOwnerForm returns null, and the
            // contextual toolbar should not be displayed.
            if (Form.GetValidOwnerForm(objComponent.Form) == null) { return; }

            Type objTypeOfComponent = objComponent.GetType();
            ContextualToolbarAttribute objAttribute = CommonUtils.GetCustomAttribute(objTypeOfComponent, typeof(ContextualToolbarAttribute), true) as ContextualToolbarAttribute;
            if (objAttribute != null)
            {
                if (objAttribute.CotextualToolbarType != null)
                {
                    if (objAttribute.CotextualToolbarType == typeof(ContextualToolbar) || objAttribute.CotextualToolbarType.IsSubclassOf(typeof(ContextualToolbar)))
                    {
                        ContextualToolbar objCurrentContextualToolbar = Activator.CreateInstance(objAttribute.CotextualToolbarType) as ContextualToolbar;

                        if (objCurrentContextualToolbar != null)
                        {
                            // Setting the handlers to deal with open/closed of editors
                            if (objOnEditorWindowClosed != null)
                            {
                                objCurrentContextualToolbar.Closed += objOnEditorWindowClosed;
                            }
                                
                            // Setting the cached toolbar to enable to attach it to its sub-popups and editors later.
                            CurrentContextualToolbar = objCurrentContextualToolbar;

                            // Get form skin.
                            ContextualToolbarSkin objContextualToolbarSkin = objCurrentContextualToolbar.Skin as ContextualToolbarSkin;
                            if (objContextualToolbarSkin != null)
                            {
                                // Get minimized mdi form size out of form skin.
                                objCurrentContextualToolbar.Size = objContextualToolbarSkin.ContextualToolbarSize;
                            }

                            if (objOnEditorWindowOpen != null)
                            {
                                objOnEditorWindowOpen(objContextualToolbarSkin, new EventArgs());
                            }

                            objCurrentContextualToolbar.ShowPopup(objComponent, DialogAlignment.Above);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows the contextual toolbar.
        /// </summary>
        /// <param name="lngId">The int identifier.</param>
        internal static void ShowContextualToolbar(Component objComponent)
        {
            ShowContextualToolbar(objComponent, null, null);
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        private static ContextualToolbar CurrentContextualToolbar
        {
            get
            {
                IContextParams objCurrentContextParams = VWGContext.Current as IContextParams;
                if (objCurrentContextParams != null)
                {
                    if (objCurrentContextParams.ContextualToolbar == null)
                    {
                        objCurrentContextParams.ContextualToolbar = new ContextualToolbar();
                    }

                    return objCurrentContextParams.ContextualToolbar as ContextualToolbar;                    
                }

                return null;
            }
            set
            {
                IContextParams objCurrentContextParams = VWGContext.Current as IContextParams;
                if (objCurrentContextParams != null)
                {
                    objCurrentContextParams.ContextualToolbar = value;                    
                }
            }
        }

        /// <summary>
        /// Handle property editing callback response 
        /// </summary>
        /// <param name="objValue"></param>
        protected virtual void EditPropertyValue_Callback(object objValue)
        {
            try
            {
                if (this.mobjComponent != null && this.mobjControlProperty != null)
                {
                    if (this.mobjCustomPropertyValueChangeEvent == null)
                    {
                        mobjControlProperty.SetValue(this.mobjComponent, objValue, null);
                    }
                    else
                    {
                        ContextualToolbarPropertyValueEventArgs objEventArgs = new ContextualToolbarPropertyValueEventArgs(mobjControlProperty.Name, objValue);
                        mobjCustomPropertyValueChangeEvent(this.mobjComponent, objEventArgs);
                    }
                }
            }
            catch (Exception objException1)
            {

            }
        }
        
        /// <summary>
        /// Closes any previously opened drop down control area.
        /// </summary>
        void IWebUIEditorService.CloseDropDown()
        {
            
        }

        /// <summary>
        /// Displays the specified control in a drop down area below a value field of the property grid that provides this service.
        /// </summary>
        /// <param name="objDialog">The dialog.</param>
        void IWebUIEditorService.ShowDropDown(Form objDialog)
        {
            // Showing the dropdown under the contextual tool bar
            if (objDialog != null)
            {                
                objDialog.ShowPopup(ContextualToolbar.CurrentContextualToolbar, DialogAlignment.Below);
            }
        }

        /// <summary>
        /// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
        /// </summary>
        /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
        void IWebUIEditorService.ShowDialog(Form objDialog)
        {
            ((IWebUIEditorService)this).ShowDropDown(objDialog);
        }

        /// <summary>
        /// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
        /// </summary>
        /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
        void IWebUIEditorService.ShowDialog(CommonDialog objDialog)
        {
            if (objDialog != null)
            {
                objDialog.ShowPopup(ContextualToolbar.CurrentContextualToolbar, ContextualToolbar.CurrentContextualToolbar, null, DialogAlignment.Below, this.mobjEditorDialogLocation);
            }
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>
        /// A service object of type <paramref name="serviceType" />.-or- null if there is no service object of type <paramref name="serviceType" />.
        /// </returns>
        public new object GetService(Type serviceType)
        {
            if (serviceType == typeof(IWebUIEditorService))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            ContextualToolbarButton objButton = objValue as ContextualToolbarButton;
            if (objButton != null)
            {
                objButton.Owner = this;
                this.mobjListOfButtons.Add(objButton);
            }
        }

        #endregion
    }


    #region ContextualToolbarPropertyValueEventArgs Class

    [Serializable()]
    internal class ContextualToolbarPropertyValueEventArgs : EventArgs
    {
        #region Fields

        private object mobjValue = null;
        private string mstrPropertyName = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualToolbarPropertyValueEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objValue">The obj value.</param>
        public ContextualToolbarPropertyValueEventArgs(string strPropertyName, object objValue)
        {
            mstrPropertyName = strPropertyName;
            mobjValue = objValue;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName
        {
            get
            {
                return mstrPropertyName;
            }
            set
            {
                mstrPropertyName = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get
            {
                return mobjValue;
            }
            set
            {
                mobjValue = value;
            }
        }

        #endregion Properties
    }

    #endregion

    /// <summary>
    /// Will contain information related to the display of the contextualtoolbar
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    [Serializable()]
    public class ContextualToolbarAttribute : Attribute
    {
        private Type mobjContextualToolbarType = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualToolbarAttribute"/> class.
        /// </summary>
        /// <param name="objContextualToolbarSize">Size of the object contextual toolbar.</param>
        public ContextualToolbarAttribute(Type objContextualToolbarType)
        {
            this.mobjContextualToolbarType = objContextualToolbarType;
        }

        /// <summary>
        /// Gets or sets the size of the cotextual toolbar.
        /// </summary>
        /// <value>
        /// The size of the cotextual toolbar.
        /// </value>
        internal Type CotextualToolbarType
        {
            get
            {
                return this.mobjContextualToolbarType;
            }
            set
            {
                this.mobjContextualToolbarType = value;
            }            
        }
    }

    
}