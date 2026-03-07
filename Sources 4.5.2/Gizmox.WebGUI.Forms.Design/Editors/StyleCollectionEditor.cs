
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design.Data;
using System.ComponentModel.Design;

using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Client.Design;

namespace Gizmox.WebGUI.Forms.Design
{
    
	public class StyleCollectionEditor : UITypeEditor
    {
        #region TypeDescriptionContextWrapper

        
	    private class TypeDescriptionContextWrapper : ITypeDescriptorContext
        {
            ITypeDescriptorContext mobjTypeDescriptionContextWrapper = null;
            object mobjInstance = null;

            public TypeDescriptionContextWrapper(ITypeDescriptorContext objTypeDescriptionContextWrapper, object objInstance)
            {
                mobjTypeDescriptionContextWrapper = objTypeDescriptionContextWrapper;
                mobjInstance = objInstance;
            }

            #region ITypeDescriptorContext Members

            public IContainer Container
            {
                get
                {
                    return mobjTypeDescriptionContextWrapper.Container;
                }
            }

            public object Instance
            {
                get
                {
                    return mobjInstance;
                }
            }

            public void OnComponentChanged()
            {
                mobjTypeDescriptionContextWrapper.OnComponentChanged();
            }

            public bool OnComponentChanging()
            {
                return mobjTypeDescriptionContextWrapper.OnComponentChanging();
            }

            public PropertyDescriptor PropertyDescriptor
            {
                get
                {
                    return mobjTypeDescriptionContextWrapper.PropertyDescriptor;
                }
            }

            #endregion

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                return mobjTypeDescriptionContextWrapper.GetService(serviceType);
            }

            #endregion
        }
                
        #endregion

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null && 
                context.Instance != null &&
                context.Instance is WebForms.Control &&
                ((WebForms.Control)context.Instance).Context != null &&
                ((WebForms.Control)context.Instance).Context is IContextServices)
            {
                TableLayoutPanelController objTableLayoutPanelController = ((IContextServices)((WebForms.Control)context.Instance).Context).GetControllerByWebObject(context.Instance) as TableLayoutPanelController;

                if(objTableLayoutPanelController != null &&
                    objTableLayoutPanelController.TargetObject != null &&
                    objTableLayoutPanelController.TargetObject is WinForms.TableLayoutPanel)
                {
                    WinForms.TableLayoutPanel objWinFormsTableLayoutPanel = objTableLayoutPanelController.TargetObject as WinForms.TableLayoutPanel;

                    if(objWinFormsTableLayoutPanel!=null)
                    {
                        WinForms.TableLayoutStyleCollection objWinFormsTableLayoutStyleCollection = null;
                        UITypeEditor winformsEditor = null;

                        if (value is WebForms.TableLayoutColumnStyleCollection)
                        {
                            objWinFormsTableLayoutStyleCollection = objWinFormsTableLayoutPanel.ColumnStyles;
                            winformsEditor = TypeDescriptor.GetEditor((typeof(WinForms.TableLayoutColumnStyleCollection)), typeof(UITypeEditor)) as UITypeEditor;
                        }
                        else if (value is WebForms.TableLayoutRowStyleCollection)
                        {
                            objWinFormsTableLayoutStyleCollection = objWinFormsTableLayoutPanel.RowStyles;
                            winformsEditor = TypeDescriptor.GetEditor((typeof(WinForms.TableLayoutRowStyleCollection)), typeof(UITypeEditor)) as UITypeEditor;
                        }
                    
                        if (winformsEditor != null &&
                            objWinFormsTableLayoutPanel != null &&
                            objWinFormsTableLayoutStyleCollection != null)
                        {
                            TypeDescriptionContextWrapper objTypeDescriptionContextWrapper = new TypeDescriptionContextWrapper(context, objWinFormsTableLayoutPanel);
                            winformsEditor.EditValue(objTypeDescriptionContextWrapper, provider, objWinFormsTableLayoutStyleCollection);

                            context.OnComponentChanged();
                        }
                    }
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Convert enum from ont type to another with default value for non existing enums
        /// </summary>
        /// <param name="enmTargetType"></param>
        /// <param name="objValue"></param>
        /// <param name="objDefault"></param>
        /// <returns></returns>
        protected object GetConvertedEnum(Type enmTargetType, object objValue, object objDefault)
        {
            try
            {
                if (objValue != null)
                {
                    string strValue = objValue.ToString();
                    object objReturn = Enum.Parse(enmTargetType, strValue);
                    return objReturn;
                }
                else
                {
                    return objDefault;
                }
            }
            catch (Exception)
            {
                return objDefault;
            }
        }
    }
}
