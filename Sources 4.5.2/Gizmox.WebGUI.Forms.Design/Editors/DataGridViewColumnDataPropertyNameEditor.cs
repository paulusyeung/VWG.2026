using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Drawing;
using System.ComponentModel.Design.Data;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{




    internal class DataGridViewColumnDataPropertyNameEditor : UITypeEditor
    {
        private Type    mobjDesignBindingType; 
        private Type    mobjDesignBindingPickerType;
        private object  mobjDesignBindingPicker;


        private DataGridViewColumnDataPropertyNameEditor()
        {
        }

        /// <summary>
        /// Edits the value.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objProvider">The obj provider.</param>
        /// <param name="objValue">The obj value.</param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
        {
            if ((objProvider != null) && (objContext.Instance != null))
            {
                DataGridView objDataGridView;

                DataGridViewColumn objColumn = objContext.Instance as DataGridViewColumn;
                if (objColumn != null)
                {
                    //Get the DataGridView object
                    objDataGridView = objColumn.DataGridView;
                }
                else
                {
                    objDataGridView = null;
                }
     
                if (objDataGridView == null)
                {
                    return objValue;
                }

                //Get the DataSource and data member
                object objDataSource = objDataGridView.DataSource;
                string objDataMember = objDataGridView.DataMember;

                //get the field name
                string strFieldName = (string)objValue;

                //concat the data member and the field name
                string strFullFieldName = objDataMember + "." + strFieldName;
                if (objDataSource == null)
                {
                    objDataMember = string.Empty;
                    strFullFieldName = strFieldName;
                }

                if (this.mobjDesignBindingPicker == null)
                {
                    //Create new DesignBindingPicker();
                    this.mobjDesignBindingPicker = Activator.CreateInstance(this.DesignBindingPickerType, true);
                }

                //Create new DesignBinding 
                object objInitialSelectedItemDesignBinding = Activator.CreateInstance(this.DesignBindingType, new object[] { objDataSource, strFullFieldName });

                //Run the DesignBindingPicker Pick() method
                object objDesignBinding = this.DesignBindingPickerType.InvokeMember("Pick", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public, null, this.mobjDesignBindingPicker, new object[] { objContext, objProvider, false, true, false, objDataSource, objDataMember, objInitialSelectedItemDesignBinding });
                
                if ((objDataSource != null) && (objDesignBinding != null))
                {
                    //Get the Data field
                    objValue = objDesignBinding.GetType().GetProperty("DataField").GetValue(objDesignBinding, new object[] { });

                }
            }
            return objValue;
        }

        /// <summary>
        /// Gets the type of the design binding picker.
        /// </summary>
        /// <value>The type of the design binding picker.</value>
        private Type DesignBindingPickerType
        {
            get
            {
                if (mobjDesignBindingPickerType == null)
	            {
            		 mobjDesignBindingPickerType = Type.GetType("System.Windows.Forms.Design.DesignBindingPicker, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
	            }
                return mobjDesignBindingPickerType;
                
            }
        }


        /// <summary>
        /// Gets the type of the design binding.
        /// </summary>
        /// <value>The type of the design binding.</value>
        private Type DesignBindingType
        {
            get
            {
                if (mobjDesignBindingType == null)
                {
                    mobjDesignBindingType = Type.GetType("System.Windows.Forms.Design.DesignBinding, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                }
                return mobjDesignBindingType;
            }
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


    

 


