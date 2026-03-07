using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections.Generic;

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    public class DemoObjectConverter : TypeConverter 
    {
        static public Dictionary<string, bool> browsableProperties = new Dictionary<string, bool>();

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
        
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, 
                                        object value, Attribute[] attributes) 
        {

            PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(value, false);
            List<PropertyDescriptor> retval = new List<PropertyDescriptor>();
            DemoObject obj = (DemoObject)value;
            for (int ix = 0; ix < coll.Count; ++ix) {
                PropertyDescriptor curr = coll[ix];

                if (browsableProperties.ContainsKey(coll[ix].Name)
                    && !browsableProperties[coll[ix].Name])
                {
                    continue;
                }
                retval.Add(curr);
            }
            return new PropertyDescriptorCollection(retval.ToArray());
        }
    }
}
