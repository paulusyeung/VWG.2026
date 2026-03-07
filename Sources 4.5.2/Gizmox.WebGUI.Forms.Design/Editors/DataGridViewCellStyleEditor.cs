using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;

using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using ClientNS = Gizmox.WebGUI.Client;

using Gizmox.WebGUI.Client.Design;
using System.Reflection;


namespace Gizmox.WebGUI.Forms.Design
{
	
	public class DataGridViewCellStyleEditor : UITypeEditor
	{
		public DataGridViewCellStyleEditor() : base()
		{
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
            // Define a returning data grid view cell style with an old default value.
            WebGUIForms.DataGridViewCellStyle objWebGUIDataGridViewCellStyle = value as WebGUIForms.DataGridViewCellStyle;

            // Validate provider and context.
            if (provider != null &&
                context.Instance != null &&
                context.PropertyDescriptor != null)
            {
                // Define an empty context services and component controler.
                IContextServices objContextServices = null;
                ClientNS.Controllers.ComponentController objComponentController = null;

                // Get context services out of control.
                if (context.Instance is WebGUIForms.DataGridView)
                {
                    objContextServices = ((WebGUIForms.DataGridView)context.Instance).Context as IContextServices;
                }
                else if (context.Instance is WebGUIForms.DataGridViewColumn)
                {
                    if (((WebGUIForms.DataGridViewColumn)context.Instance).DataGridView != null)
                    {
                        objContextServices = ((WebGUIForms.DataGridViewColumn)context.Instance).DataGridView.Context as IContextServices;
                    }
                }

                // Get component controler.
                if (objContextServices != null)
                {
                    objComponentController = objContextServices.GetControllerByWebObject(context.Instance) as ClientNS.Controllers.ComponentController;
                }

                // Validate component controler and target object.
                if (objComponentController != null &&
                    objComponentController.TargetObject != null)
                {
                    // Get handled property out of target object.
                    WinForms.DataGridViewCellStyle objWinFormsDataGridViewCellStyle = objComponentController.TargetObject.GetType().InvokeMember(context.PropertyDescriptor.Name, BindingFlags.GetProperty, null, objComponentController.TargetObject, null) as WinForms.DataGridViewCellStyle;
                    
                    if (objWinFormsDataGridViewCellStyle != null)
                    {
                        // Create a DataGridViewCellStyle editor.
                        UITypeEditor objEditor = TypeDescriptor.GetEditor(typeof(WinForms.DataGridViewCellStyle), typeof(UITypeEditor)) as UITypeEditor;

                        if (objEditor != null)
                        {
                            // Execute an EditValue action on the DataGridViewCellStyle editor with the handled winforms object.
                            WinForms.DataGridViewCellStyle objNewWinFormsDataGridViewCellStyle = objEditor.EditValue(context, provider, objWinFormsDataGridViewCellStyle) as WinForms.DataGridViewCellStyle;

                            // Check if returned object is not null and is different then the old value.
                            if (objNewWinFormsDataGridViewCellStyle != null &&
                                objNewWinFormsDataGridViewCellStyle != objWinFormsDataGridViewCellStyle)
                            {
                                // Create a new WebGUI DataGridViewCellStyle.
                                objWebGUIDataGridViewCellStyle = new WebGUIForms.DataGridViewCellStyle();

                                // Get all of the new WebGUI DataGridViewCellStyle data out of the new Winforms DataGridViewCellStyle.
                                objWebGUIDataGridViewCellStyle.Alignment = (WebGUIForms.DataGridViewContentAlignment)Enum.Parse(typeof(WebGUIForms.DataGridViewContentAlignment), objNewWinFormsDataGridViewCellStyle.Alignment.ToString());
                                objWebGUIDataGridViewCellStyle.BackColor = objNewWinFormsDataGridViewCellStyle.BackColor;
                                objWebGUIDataGridViewCellStyle.DataSourceNullValue = objNewWinFormsDataGridViewCellStyle.DataSourceNullValue;
                                objWebGUIDataGridViewCellStyle.Font = objNewWinFormsDataGridViewCellStyle.Font;
                                objWebGUIDataGridViewCellStyle.ForeColor = objNewWinFormsDataGridViewCellStyle.ForeColor;
                                objWebGUIDataGridViewCellStyle.Format = objNewWinFormsDataGridViewCellStyle.Format;
                                objWebGUIDataGridViewCellStyle.FormatProvider = objNewWinFormsDataGridViewCellStyle.FormatProvider;
                                objWebGUIDataGridViewCellStyle.NullValue = objNewWinFormsDataGridViewCellStyle.NullValue;
                                objWebGUIDataGridViewCellStyle.Padding = new Padding(objNewWinFormsDataGridViewCellStyle.Padding.Left, objNewWinFormsDataGridViewCellStyle.Padding.Top, objNewWinFormsDataGridViewCellStyle.Padding.Right, objNewWinFormsDataGridViewCellStyle.Padding.Bottom);
                                objWebGUIDataGridViewCellStyle.SelectionBackColor = objNewWinFormsDataGridViewCellStyle.SelectionBackColor;
                                objWebGUIDataGridViewCellStyle.SelectionForeColor = objNewWinFormsDataGridViewCellStyle.SelectionForeColor;
                                objWebGUIDataGridViewCellStyle.Tag = objNewWinFormsDataGridViewCellStyle.Tag;
                                objWebGUIDataGridViewCellStyle.WrapMode = (WebGUIForms.DataGridViewTriState)Enum.Parse(typeof(WebGUIForms.DataGridViewTriState), objNewWinFormsDataGridViewCellStyle.WrapMode.ToString());
                            }
                        }
                    }
                }
            }

            // Return the handled DataGridViewCellStyle.
            return objWebGUIDataGridViewCellStyle;
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
            return UITypeEditorEditStyle.Modal;
		}
	}
}

