using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Forms;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{

    #region ControlBindingsConverter Class

    /// <summary>
    /// 
    /// </summary>
    
	public class ControlBindingsConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return "";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            if (!(value is ControlBindingsCollection))
            {
                return new PropertyDescriptorCollection(new PropertyDescriptor[0]);
            }
            ControlBindingsCollection collection1 = (ControlBindingsCollection)value;
            IBindableComponent component1 = collection1.BindableComponent;
            component1.GetType();
            PropertyDescriptorCollection collection2 = TypeDescriptor.GetProperties((object)component1, null);
            ArrayList list1 = new ArrayList();
            for (int num1 = 0; num1 < collection2.Count; num1++)
            {
                Binding binding1 = collection1[collection2[num1].Name];
                bool flag1 = (((binding1 != null) && !(binding1.DataSource is IListSource)) && !(binding1.DataSource is IList)) && !(binding1.DataSource is Array);
                DesignBindingPropertyDescriptor descriptor1 = new DesignBindingPropertyDescriptor(collection2[num1], null, flag1);
                if (((BindableAttribute)collection2[num1].Attributes[typeof(BindableAttribute)]).Bindable || !((DesignBinding)descriptor1.GetValue(collection1)).IsNull)
                {
                    list1.Add(descriptor1);
                }
            }
            list1.Add(new AdvancedBindingPropertyDescriptor());
            PropertyDescriptor[] descriptorArray1 = new PropertyDescriptor[list1.Count];
            list1.CopyTo(descriptorArray1, 0);
            return new PropertyDescriptorCollection(descriptorArray1);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public static Binding Convert(WinForms.Binding objWinBinding,IContainer objContainer)
        {
            object objDataSource = objWinBinding.DataSource;
            System.Windows.Forms.BindingSource objWinBindings = objDataSource as System.Windows.Forms.BindingSource;
            if (objWinBindings != null)
            {
                if (objContainer != null) objContainer.Remove(objWinBindings);
                objDataSource = new BindingSource(objWinBindings.DataSource, objWinBindings.DataMember);
                if (objContainer != null) objContainer.Add((IComponent)objDataSource);
            }            
            
            return new Binding(objWinBinding.PropertyName, objDataSource, objWinBinding.BindingMemberInfo.BindingField, objWinBinding.FormattingEnabled, Convert(objWinBinding.DataSourceUpdateMode), objWinBinding.NullValue, objWinBinding.FormatString, objWinBinding.FormatInfo);
        }

        public static WinForms.Binding Convert(Binding objWebBinding)
        {
            return new WinForms.Binding(objWebBinding.PropertyName, objWebBinding.DataSource, objWebBinding.BindingMemberInfo.BindingField, objWebBinding.FormattingEnabled, Convert(objWebBinding.DataSourceUpdateMode), objWebBinding.NullValue, objWebBinding.FormatString, objWebBinding.FormatInfo);
        }

        public static DataSourceUpdateMode Convert(WinForms.DataSourceUpdateMode objWinDataSourceUpdateMode)
        {
            switch (objWinDataSourceUpdateMode)
            {
                case System.Windows.Forms.DataSourceUpdateMode.Never:
                    return DataSourceUpdateMode.Never;
                   
                case System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged:
                    return DataSourceUpdateMode.OnPropertyChanged;
                   
                case System.Windows.Forms.DataSourceUpdateMode.OnValidation:
                    return DataSourceUpdateMode.OnValidation;
                  
            }
            return DataSourceUpdateMode.OnPropertyChanged;
        }

        public static WinForms.DataSourceUpdateMode Convert(DataSourceUpdateMode objWebDataSourceUpdateMode)
        {
            switch (objWebDataSourceUpdateMode)
            {
                case DataSourceUpdateMode.Never:
                    return System.Windows.Forms.DataSourceUpdateMode.Never;
                   
                case DataSourceUpdateMode.OnPropertyChanged:
                    return System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged;
                    
                case DataSourceUpdateMode.OnValidation:
                    return System.Windows.Forms.DataSourceUpdateMode.OnValidation;
                   
            }
            return System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged;
        }
    }
    
    #endregion

    #region AdvancedBindingPropertyDescriptor Class

    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
	internal class AdvancedBindingPropertyDescriptor : PropertyDescriptor
    {
        // TODO: BINDING
        internal static AdvancedBindingEditor advancedBindingEditor;
        internal static AdvancedBindingTypeConverter advancedBindingTypeConverter;


        static AdvancedBindingPropertyDescriptor()
        {

            AdvancedBindingPropertyDescriptor.advancedBindingEditor = new AdvancedBindingEditor();
            AdvancedBindingPropertyDescriptor.advancedBindingTypeConverter = new AdvancedBindingTypeConverter();
        }

        internal AdvancedBindingPropertyDescriptor()
            : base(SR.GetString("AdvancedBindingPropertyDescName"), null)
        {
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        protected override void FillAttributes(IList attributeList)
        {
            attributeList.Add(RefreshPropertiesAttribute.All);
            base.FillAttributes(attributeList);
        }

        public override object GetEditor(System.Type type)
        {
            if (type == typeof(UITypeEditor))
            {
                return AdvancedBindingPropertyDescriptor.advancedBindingEditor;
            }
            return base.GetEditor(type);
        }

        public override object GetValue(object component)
        {
            return component;
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }


        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(new Attribute[] {/* new System.Design.SRDescriptionAttribute("AdvancedBindingPropertyDescriptorDesc"),*/ NotifyParentPropertyAttribute.Yes, new MergablePropertyAttribute(false) });
            }
        }

        public override System.Type ComponentType
        {
            get
            {
                return typeof(ControlBindingsCollection);
            }
        }

        public override TypeConverter Converter
        {
            get
            {
                if (AdvancedBindingPropertyDescriptor.advancedBindingTypeConverter == null)
                {
                    AdvancedBindingPropertyDescriptor.advancedBindingTypeConverter = new AdvancedBindingTypeConverter();
                }
                return AdvancedBindingPropertyDescriptor.advancedBindingTypeConverter;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public override System.Type PropertyType
        {
            get
            {
                return typeof(object);
            }
        }




        
	    public class AdvancedBindingTypeConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return string.Empty;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }
    } 

    #endregion

    #region AdvancedBindingEditor Class

    
	internal class AdvancedBindingEditor : UITypeEditor
    {
        private UITypeEditor mobjWinAdvancedBindingEditor = null;

        private UITypeEditor WinAdvancedBindingEditor
        {
            get
            {
                if (mobjWinAdvancedBindingEditor == null)
                {
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.AdvancedBindingEditor, System.Design, Version=4.0.0.0");
#else
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.AdvancedBindingEditor, System.Design, Version=2.0.0.0");
#endif
                    if (objEditorType != null)
                    {
                        mobjWinAdvancedBindingEditor = Activator.CreateInstance(objEditorType) as UITypeEditor;
                    }
                }
                return mobjWinAdvancedBindingEditor;
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            AdvancedComponentWrapper objWrappedComponent = new AdvancedComponentWrapper(((ControlBindingsCollection)context.Instance).BindableComponent);
            AdvancedContextWrapper objWrappedContext = new AdvancedContextWrapper(context, objWrappedComponent);

            if (this.WinAdvancedBindingEditor != null)
            {
                AdvancedCollectionWrapper objWrappedCollection = this.WinAdvancedBindingEditor.EditValue(objWrappedContext, provider, objWrappedComponent.DataBindings) as AdvancedCollectionWrapper;
                if (objWrappedCollection != null)
                {
                    ControlBindingsCollection objCollection = (ControlBindingsCollection)value;
                    objCollection.Clear();
                    foreach (WinForms.Binding objWinBinding in objWrappedCollection)
                    {
                        objCollection.Add(ControlBindingsConverter.Convert(objWinBinding, context.Container));
                    }
                    value = objCollection;

                    TypeDescriptor.Refresh(((ControlBindingsCollection)context.Instance).BindableComponent);

                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }



    #endregion

    #region AdvancedContextWrapper Class

    
	internal class AdvancedContextWrapper : ITypeDescriptorContext
    {
        private ITypeDescriptorContext context = null;

        System.Windows.Forms.IBindableComponent component = null;

        public AdvancedContextWrapper(ITypeDescriptorContext context, System.Windows.Forms.IBindableComponent component)
        {
            this.context = context;
            this.component = component;
        }

        #region ITypeDescriptorContext Members

        IContainer ITypeDescriptorContext.Container
        {
            get { return this.context.Container; }
        }

        object ITypeDescriptorContext.Instance
        {
            get { return this.component.DataBindings; }
        }

        void ITypeDescriptorContext.OnComponentChanged()
        {
            this.context.OnComponentChanged();
        }

        bool ITypeDescriptorContext.OnComponentChanging()
        {
            return this.context.OnComponentChanging();
        }

        PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor
        {
            get { return this.context.PropertyDescriptor; }
        }

        #endregion

        #region IServiceProvider Members

        object IServiceProvider.GetService(Type serviceType)
        {
            return this.context.GetService(serviceType);
        }

        #endregion
    }

    #endregion

    #region AdvancedCollectionWrapper Class

    
	internal class AdvancedCollectionWrapper : System.Windows.Forms.ControlBindingsCollection
    {
        public AdvancedCollectionWrapper(System.Windows.Forms.IBindableComponent control)
            : base(control)
        {
        }


    }

    #endregion

    #region AdvancedComponentWrapper Class

    
	internal class AdvancedComponentWrapper : System.Windows.Forms.IBindableComponent, ICustomTypeDescriptor
    {

        private IBindableComponent component = null;

        private AdvancedCollectionWrapper collection = null;

        public AdvancedComponentWrapper(IBindableComponent component)
        {
            this.component = component;
        }

        internal IBindableComponent BindableComponent
        {
            get
            {
                return this.component;
            }
        }

        #region IBindableComponent Members

        System.Windows.Forms.BindingContext System.Windows.Forms.IBindableComponent.BindingContext
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public System.Windows.Forms.ControlBindingsCollection DataBindings
        {
            get
            {
                if (collection == null)
                {
                    collection = new AdvancedCollectionWrapper(this);

                    foreach (Binding objWebBinding in this.component.DataBindings)
                    {
                        collection.Add(ControlBindingsConverter.Convert(objWebBinding));
                    }
                }
                return collection;
            }
        }

        #endregion

        #region IComponent Members

        event EventHandler IComponent.Disposed
        {
            add { }
            remove { }
        }

        ISite IComponent.Site
        {
            get
            {
                return component != null ? component.Site : null;
            }
            set
            {

            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {

        }

        #endregion

        #region ICustomTypeDescriptor Members

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this.component);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this.component);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this.component);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this.component);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this.component);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this.component);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this.component, editorBaseType);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this.component, attributes);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this.component);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(this.component, attributes);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return TypeDescriptor.GetProperties(this.component);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this.component;
        }

        #endregion
    }

    #endregion

    #region DesignBindingPropertyDescriptor Class

    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
	internal class DesignBindingPropertyDescriptor : PropertyDescriptor
    {

        private static TypeConverter designBindingConverter;
        private PropertyDescriptor property;
        private bool readOnly;

        static DesignBindingPropertyDescriptor()
        {
            DesignBindingPropertyDescriptor.designBindingConverter = new DesignBindingConverter();
        }

        internal DesignBindingPropertyDescriptor(PropertyDescriptor property, Attribute[] attrs, bool readOnly)
            : base(property.Name, attrs)
        {
            this.property = property;
            this.readOnly = readOnly;
            if ((base.AttributeArray != null) && (base.AttributeArray.Length > 0))
            {
                Attribute[] attributeArray1 = new Attribute[this.AttributeArray.Length + 2];
                this.AttributeArray.CopyTo(attributeArray1, 0);
                attributeArray1[this.AttributeArray.Length - 1] = NotifyParentPropertyAttribute.Yes;
                attributeArray1[this.AttributeArray.Length] = RefreshPropertiesAttribute.Repaint;
                base.AttributeArray = attributeArray1;
            }
            else
            {
                base.AttributeArray = new Attribute[] { NotifyParentPropertyAttribute.Yes, RefreshPropertiesAttribute.Repaint };
            }
        }

        public override bool CanResetValue(object component)
        {
            return !DesignBindingPropertyDescriptor.GetBinding((ControlBindingsCollection)component, this.property).IsNull;
        }

        private static DesignBinding GetBinding(ControlBindingsCollection bindings, PropertyDescriptor property)
        {
            Binding binding1 = bindings[property.Name];
            if (binding1 == null)
            {
                return DesignBinding.Null;
            }
            return new DesignBinding(binding1.DataSource, binding1.BindingMemberInfo.BindingMember);
        }

        public override object GetValue(object component)
        {
            return DesignBindingPropertyDescriptor.GetBinding((ControlBindingsCollection)component, this.property);
        }

        public override void ResetValue(object component)
        {
            DesignBindingPropertyDescriptor.SetBinding((ControlBindingsCollection)component, this.property, DesignBinding.Null);
        }

        private static void SetBinding(ControlBindingsCollection bindings, PropertyDescriptor property, DesignBinding designBinding)
        {
            if (designBinding != null)
            {
                Binding binding1 = bindings[property.Name];
                if (binding1 != null)
                {
                    bindings.Remove(binding1);
                }
                if (!designBinding.IsNull)
                {
                    bindings.Add(property.Name, designBinding.DataSource, designBinding.DataMember);
                }
            }
        }

        public override void SetValue(object component, object value)
        {
            if (value is BindingSource)
            {
                BindingSource objBindingSource = value as BindingSource;
                if (objBindingSource != null)
                {
                    value = new DesignBinding(objBindingSource.DataSource, objBindingSource.DataMember);
                }
            }

            DesignBindingPropertyDescriptor.SetBinding((ControlBindingsCollection)component, this.property, (DesignBinding)value);
            this.OnValueChanged(component, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }


        public override System.Type ComponentType
        {
            get
            {
                return typeof(ControlBindingsCollection);
            }
        }

        public override TypeConverter Converter
        {
            get
            {
                return DesignBindingPropertyDescriptor.designBindingConverter;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this.readOnly;
            }
        }

        public override System.Type PropertyType
        {
            get
            {
                return typeof(DesignBinding);
            }
        }
    } 

    #endregion

    #region DesignBinding Class
    
    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(DesignBindingEditor), typeof(UITypeEditor))]
    
	internal class DesignBinding
    {
        private string dataMember;
        private object dataSource;
        public static DesignBinding Null;

        static DesignBinding()
        {
            DesignBinding.Null = new DesignBinding(null, null);
        }

        public DesignBinding(object dataSource, string dataMember)
        {
            this.dataSource = dataSource;
            this.dataMember = dataMember;
        }

        public bool Equals(object dataSource, string dataMember)
        {
            if (dataSource == this.dataSource)
            {
                return string.Equals(dataMember, this.dataMember, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }


        public string DataField
        {
            get
            {
                if (string.IsNullOrEmpty(this.dataMember))
                {
                    return string.Empty;
                }
                int num1 = this.dataMember.LastIndexOf(".");
                if (num1 == -1)
                {
                    return this.dataMember;
                }
                return this.dataMember.Substring(num1 + 1);
            }
        }

        public string DataMember
        {
            get
            {
                return this.dataMember;
            }
        }

        public object DataSource
        {
            get
            {
                return this.dataSource;
            }
        }

        public bool IsNull
        {
            get
            {
                return (this.dataSource == null);
            }
        }
    } 

    #endregion

    #region DesignBindingConverter Class
    
    /// <summary>
    /// 
    /// </summary>
    
	public class DesignBindingConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type destType)
        {
            return (typeof(string) == destType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type sourceType)
        {
            return (typeof(string) == sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text1 = (string)value;
            if (((text1 == null) || (text1.Length == 0)) || (string.Compare(text1, SR.GetString("DataGridNoneString"), true, CultureInfo.CurrentCulture) == 0))
            {
                return DesignBinding.Null;
            }
            int num1 = text1.IndexOf("-");
            if (num1 == -1)
            {
                throw new ArgumentException(SR.GetString("DesignBindingBadParseString", new object[] { text1 }));
            }
            string text2 = text1.Substring(0, num1 - 1).Trim();
            string text3 = text1.Substring(num1 + 1).Trim();
            if ((context == null) || (context.Container == null))
            {
                throw new ArgumentException(SR.GetString("DesignBindingContextRequiredWhenParsing", new object[] { text1 }));
            }
            IContainer container1 = DesignerUtils.CheckForNestedContainer(context.Container);
            IComponent component1 = container1.Components[text2];
            if (component1 == null)
            {
                if (!string.Equals(text2, "(List)", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException(SR.GetString("DesignBindingComponentNotFound", new object[] { text2 }));
                }
                return null;
            }
            return new DesignBinding(component1, text3);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type sourceType)
        {
            DesignBinding binding1 = (DesignBinding)value;
            if (binding1.IsNull)
            {
                return SR.GetString("DataGridNoneString");
            }
            string text1 = "";
            if (binding1.DataSource is IComponent)
            {
                IComponent component1 = (IComponent)binding1.DataSource;
                if (component1.Site != null)
                {
                    text1 = component1.Site.Name;
                }
            }
            if (text1.Length == 0)
            {
                if (((binding1.DataSource is IListSource) || (binding1.DataSource is IList)) || (binding1.DataSource is Array))
                {
                    text1 = "(List)";
                }
                else
                {
                    string text2 = TypeDescriptor.GetClassName(binding1.DataSource);
                    int num1 = text2.LastIndexOf('.');
                    if (num1 != -1)
                    {
                        text2 = text2.Substring(num1 + 1);
                    }
                    text1 = string.Format(CultureInfo.CurrentCulture, "({0})", new object[] { text2 });
                }
            }
            return (text1 + " - " + binding1.DataMember);
        }

    } 

    #endregion

    #region DesignBindingEditor Class
    
    
	internal class DesignBindingEditor : UITypeEditor
    {
        private UITypeEditor mobjWinDesignBindingEditor = null;

        private UITypeEditor WinDesignBindingEditor
        {
            get
            {
                if (mobjWinDesignBindingEditor == null)
                {
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.DesignBindingEditor, System.Design, Version=4.0.0.0");
#else
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.DesignBindingEditor, System.Design, Version=2.0.0.0");
#endif
                    if (objEditorType != null)
                    {
                        mobjWinDesignBindingEditor = Activator.CreateInstance(objEditorType) as UITypeEditor;
                    }
                }
                return mobjWinDesignBindingEditor;
            }
        }

        private object GetWinDesignBinding(DesignBinding objWebDesignBinding)
        {
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            Type objEditorType = Type.GetType("System.Windows.Forms.Design.DesignBinding, System.Design, Version=4.0.0.0");
#else
            Type objEditorType = Type.GetType("System.Windows.Forms.Design.DesignBinding, System.Design, Version=2.0.0.0");
#endif
            if (objEditorType != null)
            {
                object objDataSource = objWebDesignBinding.DataSource;
                BindingSource objWebBindings = objDataSource as BindingSource;
                if (objWebBindings != null)
                {
                    objDataSource = new System.Windows.Forms.BindingSource(objWebBindings.DataSource, objWebBindings.DataMember);
                }
                return Activator.CreateInstance(objEditorType, objDataSource, (object)objWebDesignBinding.DataMember) as UITypeEditor;
            }
            return null;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            IContainer objContainer = (IContainer)provider.GetService(typeof(IContainer));

            UITypeEditor objEditor = this.WinDesignBindingEditor;

            DesignBinding objDesignBinding = value as DesignBinding;
            if (objDesignBinding != null)
            {
                value = GetWinDesignBinding(objDesignBinding);
            }

            object objReturn = null;

            try
            {
                objReturn = objEditor.EditValue(context, provider, value);
            }
            catch (Exception)
            {
            }

            if (objReturn != null)
            {
                object objDataSource = GetProperty(objReturn, "DataSource");
                System.Windows.Forms.BindingSource objWinBindings = objDataSource as System.Windows.Forms.BindingSource;
                if (objWinBindings != null)
                {
                    if (objContainer != null) objContainer.Remove(objWinBindings);
                    objDataSource = new BindingSource(objWinBindings.DataSource, objWinBindings.DataMember);
                    if (objContainer != null) objContainer.Add((IComponent)objDataSource);
                }

                objReturn = new DesignBinding(objDataSource, (string)GetProperty(objReturn, "DataMember"));
            }
            return objReturn;
        }

        private object GetProperty(object objTarget, string strProperty)
        {
            object objValue = objTarget.GetType().InvokeMember(strProperty, BindingFlags.GetProperty, null, objTarget, new object[] { });
            return objValue;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }
    } 
    #endregion
}

