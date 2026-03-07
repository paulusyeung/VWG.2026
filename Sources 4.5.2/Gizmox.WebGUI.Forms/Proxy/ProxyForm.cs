using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Forms;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyForm : ProxyControl, IProxyForm
    {
		#region Fields

        private string mstrMasterPageId = null;
        private IEmulatorForm mobjEmulatorForm;
        private ProxyControl mobjNavigationControl;
        
		#endregion Fields 

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyForm"/> class.
        /// </summary>
        public ProxyForm()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyForm"/> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyForm(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent)
        {
            
        }

		#endregion Constructors 

		#region Properties

        internal IEmulatorForm EmulatorForm
        {
            get
            {
                if (mobjEmulatorForm == null)
                {
                    IContextParams objContextParams = this.Context as IContextParams;
                    if (objContextParams == null) { return null; }

                    mobjEmulatorForm = objContextParams.EmulatorForm;
                }

                return mobjEmulatorForm;                
            }
        }

        /// <summary>
        /// Gets or sets the application master page.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MasterPageId
        {
            get
            {
                return mstrMasterPageId;
            }
            set
            {
                mstrMasterPageId = value;
            }
        }


        /// <summary>
        /// Gets or sets the application master page.
        /// </summary>
        [Category("Emulation"), Description("The default master page name for the form."), DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        #if WG_NET46
        [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET452
        [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET451
        [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET45
                [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET40
                [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET35
                [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET2
                [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#endif
        public string MasterPage
        {
            get
            {
                IProxyMasterPage objProxyMasterPage = EmulatorForm.GetMasterPageById(MasterPageId);
                if (objProxyMasterPage == null)
                {
                    return EmulatorForm.MasterPageInheritName;
                }

                string strDisplayName = EmulatorForm.GetMasterPageDisplayName(objProxyMasterPage);
                return strDisplayName;
            }
            set
            {
                // NOTE: The set property here is for the master page id, because the master page name is not unique.
                MasterPageId = value;
            }
        }

		#endregion Properties 

		#region Methods

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (this.ParentForm != null)
            {
                this.ParentForm.Update();
            }
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="blnRedrawOnly"></param>
        public override void Update(bool blnRedrawOnly)
        {
            base.Update(blnRedrawOnly);

            if (this.ParentForm != null)
            {
                this.ParentForm.Update(blnRedrawOnly);
            }
        }

        ///// <summary>
        ///// Updates the specified BLN redraw only.
        ///// </summary>
        ///// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
        ///// <param name="blnUseClientUpdateHandler">if set to <c>true</c> [BLN use client update handler].</param>
        public override void Update(bool blnRedrawOnly, bool blnUseClientUpdateHandler)
        {
            base.Update(blnRedrawOnly, blnUseClientUpdateHandler);

            if (this.ParentForm != null)
            {
                this.ParentForm.Update(blnRedrawOnly, blnUseClientUpdateHandler);
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

            // Loop all properties.
            foreach (PropertyDescriptor objPropertyDescriptor in arrPropertyDescriptors)
            {
                if (this.IsProxyProperty(objPropertyDescriptor))
                {
                    objPropertyDescriptorCollection.Add(objPropertyDescriptor);
                }
            }

            return objPropertyDescriptorCollection;
        }

        /// <summary>
        /// Determines whether [is proxy property] [the specified obj property descriptor].
        /// </summary>
        /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
        /// <returns>
        ///   <c>true</c> if [is proxy property] [the specified obj property descriptor]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsProxyProperty(PropertyDescriptor objPropertyDescriptor)
        {
            if (objPropertyDescriptor != null)
            {
                switch (objPropertyDescriptor.Name)
                {
                    case "FullScreenMode":
                        if (EmulatorForm != null)
                        {
                            return this.SourceComponent == EmulatorForm.MainForm;
                        }
                        break;
                    case "MasterPage":
                        return true;
                    case "NavigationControl":
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the proxy component property owner.
        /// </summary>
        /// <param name="objPropertyDescriptor"></param>
        /// <returns></returns>
        protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            if (this.IsProxyProperty(objPropertyDescriptor))
            {
                return this;
            }

            return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
        }


        /// <summary>
        /// Validates the source component.
        /// </summary>
        internal override void ValidateSourceComponent()
        {
            // Loop on all sub components and validate SourceComponent
            foreach (ProxyComponent objProxyComponent in Components)
            {
                ProxyControl objProxyControl = objProxyComponent as ProxyControl;
                if (objProxyControl != null)
                {
                    objProxyControl.ValidateSourceComponent();
                }
            }
        }

        #endregion Methods

        /// <summary>
        /// Gets or sets the navigation control.
        /// </summary>
        /// <value>
        /// The navigation control.
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
        public ProxyControl NavigationControl
        {
            get { return mobjNavigationControl; }
            set { mobjNavigationControl = value; }
        }

        /// <summary>
        /// Gets or sets the parent form.
        /// </summary>
        /// <value>
        /// The parent form.
        /// </value>
        IForm IProxyForm.ParentForm
        {
            get
            {
                return ParentForm;
            }
            set
            {
                ParentForm = value as Form;
            }
        }
    }
}