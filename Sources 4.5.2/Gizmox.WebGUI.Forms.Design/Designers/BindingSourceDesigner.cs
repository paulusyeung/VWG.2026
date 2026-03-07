using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design
{

    
	internal class BindingSourceDesigner : ComponentDesigner
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IComponentChangeService service1 = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                if (service1 != null)
                {
                    service1.ComponentChanged -= new ComponentChangedEventHandler(this.OnComponentChanged);
                    service1.ComponentRemoving -= new ComponentEventHandler(this.OnComponentRemoving);
                }
            }
            base.Dispose(disposing);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            IComponentChangeService service1 = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
            if (service1 != null)
            {
                service1.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);
                service1.ComponentRemoving += new ComponentEventHandler(this.OnComponentRemoving);
            }
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (((this.bindingUpdatedByUser && (e.Component == base.Component)) && (e.Member != null)) && ((e.Member.Name == "DataSource") || (e.Member.Name == "DataMember")))
            {
                this.bindingUpdatedByUser = false;
                DataSourceProviderService service1 = (DataSourceProviderService) this.GetService(typeof(DataSourceProviderService));
                if (service1 != null)
                {
                    service1.NotifyDataSourceComponentAdded(base.Component);
                }
            }
        }

        private void OnComponentRemoving(object sender, ComponentEventArgs e)
        {
            BindingSource source1 = base.Component as BindingSource;
            if ((source1 != null) && (source1.DataSource == e.Component))
            {
                IComponentChangeService service1 = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                string text1 = source1.DataMember;
                PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(source1);
                PropertyDescriptor descriptor1 = (collection1 != null) ? collection1["DataMember"] : null;
                if ((service1 != null) && (descriptor1 != null))
                {
                    service1.OnComponentChanging(source1, descriptor1);
                }
                source1.DataSource = null;
                if ((service1 != null) && (descriptor1 != null))
                {
                    service1.OnComponentChanged(source1, descriptor1, text1, "");
                }
            }
        }


        public bool BindingUpdatedByUser
        {
            set
            {
                this.bindingUpdatedByUser = value;
            }
        }


        private bool bindingUpdatedByUser;
    }
}

