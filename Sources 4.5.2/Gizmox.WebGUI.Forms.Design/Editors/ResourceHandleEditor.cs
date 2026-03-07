using System;
using System.Text;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Resources;
using System.Drawing;
using System.ComponentModel.Design;
using System.Globalization;
using System.Resources;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Design;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{
    
	public class ResourceHandleEditor : UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ResourceHandle objResourceHandle = value as ResourceHandle;

            IClientDesignServices objContext = null;

            IContainer objContainer = context.Container;

            if (objContainer == null)
            {
                objContainer = provider.GetService(typeof(IContainer)) as IContainer;
            }

            Form objForm = objContainer.Components[0] as Form;
            if (objForm != null)
            {
                objContext = objForm.Context as IClientDesignServices;
            }

            UserControl objUserControl = objContainer.Components[0] as UserControl;
            if (objUserControl != null)
            {
                objContext = objUserControl.Context as IClientDesignServices;
            }

            if (objContext != null)
            {
                ResourceHandleEditorDialog objDialog = new ResourceHandleEditorDialog(objResourceHandle, objContext);
                if (objDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return objDialog.Handle;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return null;
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}
