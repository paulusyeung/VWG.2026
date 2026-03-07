#region using
using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;

using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
#endregion

namespace Gizmox.WebGUI.Forms.Design
{
	public class MaskEditor : UITypeEditor
	{
        private UITypeEditor mobjWinMaskedEditor;

        public MaskEditor()
            : base()
        {
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            Type objMaskedEditorType = Type.GetType("System.Windows.Forms.Design.MaskPropertyEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false);
#else
            Type objMaskedEditorType = Type.GetType("System.Windows.Forms.Design.MaskPropertyEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",false);
#endif
            if (objMaskedEditorType != null)
            {
                mobjWinMaskedEditor = (UITypeEditor)Activator.CreateInstance(objMaskedEditorType);
            }
        }

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
            WinForms.MaskedTextBox objWinMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            objWinMaskedTextBox.Mask = (string)value;
            return mobjWinMaskedEditor.EditValue(new MaskedEditorContext(context, objWinMaskedTextBox), provider, value);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
    public class MaskedEditorContext : ITypeDescriptorContext
    {
#region ITypeDescriptorContext Members
        private ITypeDescriptorContext mobjContext;
        private WinForms.MaskedTextBox mobjMaskedTextBox;
        public MaskedEditorContext(ITypeDescriptorContext objContext,WinForms.MaskedTextBox objMaskedTextBox)
        {
            this.mobjContext = objContext;
            this.mobjMaskedTextBox = objMaskedTextBox;
        }
        IContainer ITypeDescriptorContext.Container
        {
            get
            {
                return mobjContext.Container;
            }
        }

        object ITypeDescriptorContext.Instance
        {
            get
            {
                return mobjMaskedTextBox;
            }
        }

        void ITypeDescriptorContext.OnComponentChanged()
        {
            mobjContext.OnComponentChanged();
        }

        bool ITypeDescriptorContext.OnComponentChanging()
        {
            return mobjContext.OnComponentChanging();
        }

        PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor
        {
            get
            {
                return mobjContext.PropertyDescriptor;
            }
        }

        #endregion

#region IServiceProvider Members

        object IServiceProvider.GetService(Type serviceType)
        {
            return mobjContext.GetService(serviceType);
        }

        #endregion
    }
}

