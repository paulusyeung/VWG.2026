using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.ComponentModel.Design.Data;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    internal class DataMemberFieldEditor : UITypeEditor
    {

        private UITypeEditor mobjWrappedEditor = null;

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
                //PropertyDescriptor dataSourceDescriptor = TypeDescriptor.GetProperties(context.Instance)["DataSource"];
                //if (dataSourceDescriptor == null)
                //{
                //    return value;
                //}

                //object dataSource = dataSourceDescriptor.GetValue(context.Instance);
                
                if(this.WrappedEditor!=null)
                {
                    value = this.WrappedEditor.EditValue(context,provider, value);
                }
            }
            return value;
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// Gets the wrapped editor.
        /// </summary>
        /// <value>The wrapped editor.</value>
        private UITypeEditor WrappedEditor
        {
            get
            {
                if(mobjWrappedEditor==null)
                {
#if WG_NET2 || WG_NET35
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false);
#elif WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    Type objEditorType = Type.GetType("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false);
#endif
                    if (objEditorType!=null)
                    {
                        mobjWrappedEditor = (UITypeEditor)Activator.CreateInstance(objEditorType);
                    }
                }
                return mobjWrappedEditor;
            }
        }

        /// <summary>
        /// Gets a value indicating whether drop-down editors should be resizable by the user.
        /// </summary>
        /// <value></value>
        /// <returns>true if drop-down editors are resizable; otherwise, false.
        /// </returns>
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }
    }
}

