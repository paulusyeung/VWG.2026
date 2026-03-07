using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{

    /// <summary>
    /// 
    /// </summary>
    public enum NavigationCommandTarget
    {
        /// <summary>
        /// will try to execute the Navigation Command on the selected Navigation Control (if navigation is available) otherwise the Navigation Command is executed on the forms list.
        /// </summary>
        FullNavigation,
        /// <summary>
        /// will execute the Navigation Command on the available forms list.
        /// </summary>
        Form,
        /// <summary>
        /// will execute the Navigation Command on the selected Navigation Control.
        /// </summary>
        NavigationControl
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class ProxyNavigationCommand : ProxyAction
    {
        #region Members

        protected NavigationCommandTarget menmNavigationCommandTarget;

        protected ProxyControl mobjTargetNavigationControl;

        #endregion Members

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommand"/> class.
        /// </summary>
        public ProxyNavigationCommand()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public abstract bool DoNavigation(INavigationControl objINavigationControl);

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objList">The obj list.</param>
        /// <returns></returns>
        public abstract bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm);

        /// <summary>
        /// Executes action.
        /// </summary>
        public override void Execute()
        {
            bool blnSuccess = false;

            IContext objContext = Global.Context;
            if (objContext != null)
            {
                if (menmNavigationCommandTarget == NavigationCommandTarget.FullNavigation || menmNavigationCommandTarget == NavigationCommandTarget.NavigationControl)
                {
                    ProxyControl objTargetNavigationControl = this.TargetNavigationControl;
                    if (objTargetNavigationControl != null)
                    {
                        INavigationControl objNavigationControl = objTargetNavigationControl.SourceComponent as INavigationControl;

                        if (objNavigationControl != null)
                        {
                            blnSuccess = this.DoNavigation(objNavigationControl);
                        }
                    }
                }

                if (menmNavigationCommandTarget == NavigationCommandTarget.Form || (!blnSuccess && menmNavigationCommandTarget == NavigationCommandTarget.FullNavigation))
                {
                    if (objContext.FullScreenMode)
                    {
                        List<IForm> objList = new List<IForm>(((IFormResolver)objContext).AccessibleForms);

                        Form objForm = objContext.ActiveForm as Form;
                        if (objForm != null)
                        {
                            this.DoNavigation(objContext, objList, objForm);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the filtered custom properties.
        /// </summary>
        /// <param name="objPropertyDescriptorCollection">The object property descriptor collection.</param>
        /// <returns></returns>
        protected override PropertyDescriptorCollection GetFilteredCustomProperties(PropertyDescriptorCollection objPropertyDescriptorCollection)
        {
            List<PropertyDescriptor> arrFiltredDescriptors = new List<PropertyDescriptor>();

            foreach (PropertyDescriptor objPropertyDescriptor in objPropertyDescriptorCollection)
            {
                bool blnAddProperty = true;

                switch (objPropertyDescriptor.Name)
                {
                    case "TargetNavigationControl":
                        blnAddProperty = this.NavigationCommandTarget != Forms.NavigationCommandTarget.Form;
                        break;
                }

                if (blnAddProperty)
                {
                    arrFiltredDescriptors.Add(objPropertyDescriptor);
                }
            }

            return new PropertyDescriptorCollection(arrFiltredDescriptors.ToArray());
        }

        /// <summary>
        /// Shoulds the serialize target navigation control.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeTargetNavigationControl()
        {
            return this.TargetNavigationControl != null && this.NavigationCommandTarget != Forms.NavigationCommandTarget.Form;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the navigation command target.
        /// </summary>
        /// <value>
        /// The navigation command target.
        /// </value>
        [Description("Form - will execute the Navigation Command on the available forms list.\r\nNavigationControl - will execute the Navigation Command on the selected Navigation Control.\r\nFullNavigation – will try to execute the Navigation Command on the selected Navigation Control (if navigation is available) otherwise the Navigation Command is executed on the forms list.")]
        [RefreshProperties(RefreshProperties.All)]
        public virtual NavigationCommandTarget NavigationCommandTarget
        {
            get
            {
                return menmNavigationCommandTarget;
            }
            set
            {
                menmNavigationCommandTarget = value;
            }
        }


        /// <summary>
        /// Gets or sets the target navigation control.
        /// </summary>
        /// <value>
        /// The target navigation control.
        /// </value>
#if WG_NET46
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET452
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET451
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET45
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET40
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET35
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET2
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#endif

        [TypeConverterAttribute(typeof(EmptyExpandableObjectConverter))]        
        public ProxyControl TargetNavigationControl
        {
            get
            {
                return mobjTargetNavigationControl;
            }
            set
            {
                mobjTargetNavigationControl = value;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Navigate Previous")]
    public class ProxyNavigationCommandPrevious : ProxyNavigationCommand
    {
        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommandPrevious"/> class.
        /// </summary>
        public ProxyNavigationCommandPrevious()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public override bool DoNavigation(INavigationControl objINavigationControl)
        {
            if (objINavigationControl != null)
            {
                return objINavigationControl.MovePrevious();
            }

            return false;
        }

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objList">The obj list.</param>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
        {
            if (objList != null && objForm != null)
            {
                int intIndex = objList.IndexOf(objForm);

                if (intIndex > 0 && intIndex <= objList.Count - 1)
                {
                    long lngActivateFormId = ((Form)objList[intIndex - 1]).ID;
                    if (lngActivateFormId > 0)
                    {
                        Form objNextForm = ((ISessionRegistry)objContext).GetRegisteredComponent(lngActivateFormId) as Form;
                        if (objNextForm != null)
                        {
                            objNextForm.ActivateForm(true);

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Navigate Previous";
        }

        #endregion Methods
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Navigate Next")]
    public class ProxyNavigationCommandNext : ProxyNavigationCommand
    {
        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommandNext"/> class.
        /// </summary>
        public ProxyNavigationCommandNext()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public override bool DoNavigation(INavigationControl objINavigationControl)
        {
            if (objINavigationControl != null)
            {
                return objINavigationControl.MoveNext();
            }

            return false;
        }

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objList">The obj list.</param>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
        {
            if (objList != null && objForm != null)
            {
                int intIndex = objList.IndexOf(objForm);

                if (intIndex >= 0 && intIndex < objList.Count - 1)
                {
                    long lngActivateFormId = ((Form)objList[intIndex + 1]).ID;
                    if (lngActivateFormId > 0)
                    {
                        Form objNextForm = ((ISessionRegistry)objContext).GetRegisteredComponent(lngActivateFormId) as Form;
                        if (objNextForm != null)
                        {
                            objNextForm.ActivateForm(true);

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Navigate Next";
        }

        #endregion Methods
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Navigate First")]
    public class ProxyNavigationCommandFirst : ProxyNavigationCommand
    {
        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommandFirst"/> class.
        /// </summary>
        public ProxyNavigationCommandFirst()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public override bool DoNavigation(INavigationControl objINavigationControl)
        {
            if (objINavigationControl != null)
            {
                return objINavigationControl.MoveFirst();
            }

            return false;
        }

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objList">The obj list.</param>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
        {
            if (objList != null && objForm != null)
            {
                long lngActivateFormId = ((Form)objList[0]).ID;

                if (lngActivateFormId > 0)
                {
                    Form objNextForm = ((ISessionRegistry)objContext).GetRegisteredComponent(lngActivateFormId) as Form;
                    if (objNextForm != null)
                    {
                        objNextForm.ActivateForm(true);

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Navigate First";
        }

        #endregion Methods

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Navigate Last")]
    public class ProxyNavigationCommandLast : ProxyNavigationCommand
    {
        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommandLast"/> class.
        /// </summary>
        public ProxyNavigationCommandLast()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public override bool DoNavigation(INavigationControl objINavigationControl)
        {
            if (objINavigationControl != null)
            {
                return objINavigationControl.MoveLast();
            }

            return false;
        }

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objList">The obj list.</param>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
        {

            if (objList != null && objForm != null)
            {
                long lngActivateFormId = ((Form)objList[objList.Count - 1]).ID;

                if (lngActivateFormId > 0)
                {
                    Form objNextForm = ((ISessionRegistry)objContext).GetRegisteredComponent(lngActivateFormId) as Form;
                    if (objNextForm != null)
                    {
                        objNextForm.ActivateForm(true);

                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Navigate Last";
        }

        #endregion Methods
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Navigate To")]
    public class ProxyNavigationCommandTo : ProxyNavigationCommand
    {
        #region Members

        private int mintIndex = 0;

        #endregion Members

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyNavigationCommandLast"/> class.
        /// </summary>
        public ProxyNavigationCommandTo()
        {
            base.NavigationCommandTarget = NavigationCommandTarget.NavigationControl;
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objINavigationControl">The obj I navigation control.</param>
        /// <returns></returns>
        public override bool DoNavigation(INavigationControl objINavigationControl)
        {
            if (objINavigationControl != null)
            {
                objINavigationControl.MoveTo(this.Index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Does the navigation.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objList">The obj list.</param>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
        {
            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Navigate To Index {0}", mintIndex);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the navigation command target.
        /// </summary>
        /// <value>
        /// The navigation command target.
        /// </value>
        [Browsable(false)]
        public override NavigationCommandTarget NavigationCommandTarget
        {
            get
            {
                return base.NavigationCommandTarget;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index
        {
            get
            {
                return mintIndex;
            }
            set
            {
                mintIndex = value;
            }
        }

        #endregion Properties
    }
}