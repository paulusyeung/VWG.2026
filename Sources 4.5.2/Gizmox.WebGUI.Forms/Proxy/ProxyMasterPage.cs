using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    [Serializable(), ToolboxItem(false)]
    public class ProxyMasterPage : ProxyControl, IProxyMasterPage
    {
        private string mstrName;
        private string mstrMasterPageId;
        private IEmulatorForm mobjEmulatorForm;

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyMasterPage"/> class.
        /// </summary>
        public ProxyMasterPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyMasterPage"/> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        public ProxyMasterPage(Component objComponent)
            : base(objComponent, null, false)
	    {
	    }

		#endregion Constructors 

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
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();

            this.SourceComponent.Update();
        }

        /// <summary>
        /// Gets or sets the id of the master page.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public string MasterPageId
        {
            get
            {
                if (mstrMasterPageId == null)
                {
                    mstrMasterPageId = Guid.NewGuid().ToString();
                }

                return mstrMasterPageId;
            }
            set
            {
                mstrMasterPageId = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the master page.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public override string Name
        {
            get
            {
                return mstrName;
            }
            set
            {
                mstrName = value;
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
                    case "Name":
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

        void IProxyMasterPage.Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.Render(objContext, objWriter, lngRequestID);
        }

        void IProxyMasterPage.PreRender(IContext objContext, long lngRequestID)
        {
            this.PreRender(objContext, lngRequestID);
        }

        void IProxyMasterPage.PostRender(IContext objContext, long lngRequestID)
        {
            this.PostRender(objContext,lngRequestID);
        }
    }
}
