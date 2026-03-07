namespace Gizmox.WebGUI.Forms.Design
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.ComponentModel.Design.Data;
    using System.ComponentModel.Design;
    

    
	internal class DataSourceListEditor : UITypeEditor
    {
        
	internal class ServiceProviderWrapper : IServiceProvider
        {
            IServiceProvider mobjServiceProvider = null;

            public ServiceProviderWrapper(IServiceProvider objServiceProvider)
            {
                mobjServiceProvider = objServiceProvider;
            }

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                object objService = mobjServiceProvider.GetService(serviceType);
                DataSourceProviderService objDataSourceProviderService = objService as DataSourceProviderService;
                if(objDataSourceProviderService!=null)
                {
                    objService = new DataSourceProviderServiceWrapper(objDataSourceProviderService);
                }

                return objService;
            }

            #endregion
        }

        
	internal class DataSourceProviderServiceWrapper : DataSourceProviderService
        {
            DataSourceProviderService mobjDataSourceProviderService = null;

            internal DataSourceProviderServiceWrapper(DataSourceProviderService objDataSourceProviderService)
            {
                mobjDataSourceProviderService = objDataSourceProviderService;
            }

            public override object AddDataSourceInstance(IDesignerHost host, DataSourceDescriptor dataSourceDescriptor)
            {
                return mobjDataSourceProviderService.AddDataSourceInstance(host, dataSourceDescriptor);
            }

            public override DataSourceGroupCollection GetDataSources()
            {
                return mobjDataSourceProviderService.GetDataSources();
            }

            public override DataSourceGroup InvokeAddNewDataSource(System.Windows.Forms.IWin32Window parentWindow, System.Windows.Forms.FormStartPosition startPosition)
            {
                try
                {
                    return mobjDataSourceProviderService.InvokeAddNewDataSource(parentWindow, startPosition);
                }
                catch 
                {
                    return null; 
                }
            }

            public override bool InvokeConfigureDataSource(System.Windows.Forms.IWin32Window parentWindow, System.Windows.Forms.FormStartPosition startPosition, DataSourceDescriptor dataSourceDescriptor)
            {
                return mobjDataSourceProviderService.InvokeConfigureDataSource(parentWindow, startPosition,dataSourceDescriptor);
            }

            public override void NotifyDataSourceComponentAdded(object dsc)
            {
                mobjDataSourceProviderService.NotifyDataSourceComponentAdded(dsc);
            }

            public override bool SupportsAddNewDataSource
            {
                get { return true; }
            }

            public override bool SupportsConfigureDataSource
            {
                get { return true; }
            }
        }


        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((provider != null) && (context.Instance != null))
            {
                IContainer objContainer = (IContainer)provider.GetService(typeof(IContainer));

                if (this.winformsEditor == null)
                {
                    this.winformsEditor = TypeDescriptor.GetEditor((typeof(IListSource)), typeof(UITypeEditor)) as UITypeEditor;
                }
                if (this.winformsEditor != null)
                {
                    value = this.winformsEditor.EditValue(context,new ServiceProviderWrapper(provider), value);
                    System.Windows.Forms.BindingSource objWinBindings = value as System.Windows.Forms.BindingSource;
                    if (objWinBindings != null)
                    {
                        if (objContainer != null) objContainer.Remove(objWinBindings);
                        value = new BindingSource(objWinBindings.DataSource, objWinBindings.DataMember);
                        if (objContainer != null) objContainer.Add((IComponent)value);
                    }
                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }
#endif

        private UITypeEditor winformsEditor;
    }
}

