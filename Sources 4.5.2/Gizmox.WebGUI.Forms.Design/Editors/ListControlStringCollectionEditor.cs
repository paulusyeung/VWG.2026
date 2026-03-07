namespace Gizmox.WebGUI.Forms.Design
{
    using System;
    using System.ComponentModel;
    using System.Design;
    using System.Security.Permissions;

 
    
	public class ListControlStringCollectionEditor : StringCollectionEditor
    {
        // Methods
        public ListControlStringCollectionEditor(Type type) : base(type)
        {
			
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
		
            return base.EditValue(context, provider, value);
        }

    }
}

