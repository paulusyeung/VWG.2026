using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design
{


    
	public class DataSourceConverter : ReferenceConverter
    {
        public DataSourceConverter() : base(typeof(IListSource))
        {
            this.listConverter = new ReferenceConverter(typeof(IList));
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value is System.Type))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList list1 = new ArrayList(base.GetStandardValues(context));
            TypeConverter.StandardValuesCollection collection1 = this.listConverter.GetStandardValues(context);
            ArrayList list2 = new ArrayList();
            BindingSource source1 = context.Instance as BindingSource;
            foreach (object obj1 in list1)
            {
                if (obj1 != null)
                {
                    ListBindableAttribute attribute1 = (ListBindableAttribute) TypeDescriptor.GetAttributes(obj1)[typeof(ListBindableAttribute)];
                    if (((attribute1 == null) || attribute1.ListBindable) && ((source1 == null) || (source1 != obj1)))
                    {
                        DataTable table1 = obj1 as DataTable;
                        if ((table1 == null) || !list1.Contains(table1.DataSet))
                        {
                            list2.Add(obj1);
                        }
                    }
                }
            }
            foreach (object obj2 in collection1)
            {
                if (obj2 != null)
                {
                    ListBindableAttribute attribute2 = (ListBindableAttribute) TypeDescriptor.GetAttributes(obj2)[typeof(ListBindableAttribute)];
                    if (((attribute2 == null) || attribute2.ListBindable) && ((source1 == null) || (source1 != obj2)))
                    {
                        list2.Add(obj2);
                    }
                }
            }
            list2.Add(null);
            return new TypeConverter.StandardValuesCollection(list2);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        private ReferenceConverter listConverter;
    }
}

