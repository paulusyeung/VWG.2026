using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using System.Reflection;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// WebUITypeEditor Handler
    /// </summary>
    public delegate void WebUITypeEditorHandler(object objValue);

    /// <summary>
    /// Provides a base class that can be used to design value editors that 
    /// can provide a web user interface (Web UI) for representing and editing the 
    /// values of objects of the supported data types.
    /// </summary>

    [Serializable()]
    public class WebUITypeEditor
    {
		private GridEntry mobjGridEntryOwner = null;

        static WebUITypeEditor()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> class.</summary>
        public WebUITypeEditor()
        {
        }

        /// <summary>
        /// Edits the value of the specified object using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public void EditValue(IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            this.EditValue(null,objProvider,objValue,objHandler);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public virtual void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
			mobjGridEntryOwner = objContext as GridEntry;
        }

		/// <summary>
		/// Raise error on value change
		/// </summary>
		/// <param name="objException"></param>
		protected void OnValueChangeError(Exception objException)
		{
			if(this.mobjGridEntryOwner!=null)
			{
				this.mobjGridEntryOwner.OnValueChangeError(objException);
			}
		}

        /// <summary>Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value that indicates the style of editor used by the current <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. By default, this method will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
        public UITypeEditorEditStyle GetEditStyle()
        {
            return this.GetEditStyle(null);
        }

        /// <summary>Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
        public virtual UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.None;
        }


        /// <summary>Gets a value indicating whether drop-down editors should be resizable by the user.</summary>
        /// <returns>true if drop-down editors are resizable; otherwise, false. </returns>
        public virtual bool IsDropDownResizable
        {
            get
            {
                return false;
            }
        }

		/// <summary>Gets a value indicating whether this editor value should support text editing.</summary>
		/// <returns>true if editor value should support text editing; otherwise, false. </returns>
		public virtual bool IsTextEditable
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets the ditor value from the property value
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		internal object GetEditorValueFromPropertyValueInternal(object objValue)
		{
            return this.GetEditorValueFromPropertyValue(objValue);
		}

		/// <summary>
		/// Validated property value
		/// </summary>
		/// <param name="value"></param>
		internal void ValidatePropertyValueInternal(object objValue)
		{
            this.ValidatePropertyValue(objValue);
		}

		/// <summary>
		/// Validated property value
		/// </summary>
		/// <param name="value"></param>
		protected virtual void ValidatePropertyValue(object objValue)
		{
		}

		/// <summary>
		/// Supplies a editor level mechanism to convert property values before editing
		/// </summary>
		/// <param name="value">The property value.</param>
		/// <returns></returns>
		protected virtual object GetEditorValueFromPropertyValue(object objValue)
		{
            return objValue;
		}

		/// <summary>
		/// Supplies a editor level mechanism to convert editor returned values before assigning to property
		/// </summary>
		/// <param name="value">The editor returned value.</param>
		/// <returns></returns>
		protected virtual object GetPropertyValueFromEditorValue(object objValue)
		{
            return objValue;
		}

		/// <summary>
		/// Gets an editor with the WebUITypeEditor base type for the specified component. 
		/// </summary>
		/// <param name="objComponent">The component to get the editor for. </param>
		/// <returns></returns>
		public static WebUITypeEditor GetEditor(object objComponent)
		{
			if(objComponent!=null)
			{
				return WebUITypeEditor.GetEditor(objComponent.GetType(),typeof(WebUITypeEditor));
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Gets an editor with the specified base type for the specified component. 
		/// </summary>
		/// <param name="objComponent">The component to get the editor for. </param>
		/// <param name="objBaseType">A Type that represents the base type of the editor you want to find.</param>
		/// <returns></returns>
		public static WebUITypeEditor GetEditor(object objComponent,Type objBaseType)
		{
			if(objComponent!=null)
			{
				return WebUITypeEditor.GetEditor(objComponent.GetType(),objBaseType);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Returns an editor with the WebUITypeEditor base type for the specified type. 
		/// </summary>
		/// <param name="objType">The Type of the target component.</param>
		/// <returns></returns>
		public static WebUITypeEditor GetEditor(Type objType)
		{
			return WebUITypeEditor.GetEditor(objType,typeof(WebUITypeEditor));
		}

		/// <summary>
		/// Gets an editor from the property attributes
		/// </summary>
		/// <param name="objPropertyInfo"></param>
		/// <returns></returns>
		public static WebUITypeEditor GetPropertyEditor(PropertyDescriptor objPropertyInfo)
		{
			return WebUITypeEditor.GetPropertyEditor(objPropertyInfo,typeof(WebUITypeEditor));
		}

		/// <summary>
		/// Gets a typed inherited editor from property attributes
		/// </summary>
		/// <param name="objPropertyInfo"></param>
		/// <param name="objBaseType"></param>
		/// <returns></returns>
        public static WebUITypeEditor GetPropertyEditor(PropertyDescriptor objPropertyInfo, Type objBaseType)
        {
            // Loop all property attributes
            foreach (Attribute objAttribute in objPropertyInfo.Attributes)
            {
                // Get current attribute
                WebEditorAttribute objWebEditorAttribute = objAttribute as WebEditorAttribute;
                if (objWebEditorAttribute != null)
                {
                    // Get attribute type
                    Type objEditorType = Type.GetType(objWebEditorAttribute.EditorTypeName, false, true);
                    if (objEditorType != null)
                    {
                        // Editor reference
                        WebUITypeEditor objEditor = null;
                        bool blnHasEmptyCtor = false;
                        try
                        {
                            ConstructorInfo[] objCtors = objEditorType.GetConstructors(~BindingFlags.Static);
                            foreach (ConstructorInfo objCtor in objCtors)
                            {
                                if (objCtor.GetParameters().Length == 0)
                                {
                                    blnHasEmptyCtor = true;
                                    break;
                                }
                            }

                            if (blnHasEmptyCtor)
                            {
                                // Create instance with no parameters
                                objEditor = Activator.CreateInstance(objEditorType) as WebUITypeEditor;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (objEditor == null)
                            {
                                // Create instance with type parameter
                                objEditor = Activator.CreateInstance(objEditorType, new object[] { objPropertyInfo.PropertyType }) as WebUITypeEditor;
                            }
                        }
                        catch (Exception) { }

                        // If editor was found return it
                        if (objEditor != null) return objEditor;
                    }
                }
            }

            return null;
        }

		/// <summary>
		/// Returns an editor with the specified base type for the specified type. 
		/// </summary>
		/// <param name="objType">The Type of the target component.</param>
		/// <param name="objBaseType">A Type that represents the base type of the editor you are trying to find.</param>
		/// <returns></returns>
        public static WebUITypeEditor GetEditor(Type objType,Type objBaseType)
        {
			// Get type definition attributes
			AttributeCollection objAttributes = TypeDescriptor.GetAttributes(objType);

			// Loop all type attributes
            foreach (Attribute objAttribute in objAttributes)
            {
				// Get current editor attribute
                WebEditorAttribute objWebEditorAttribute = objAttribute as WebEditorAttribute;
                if (objWebEditorAttribute!=null)
                {
					// Get editor type
					Type objEditorType = Type.GetType(objWebEditorAttribute.EditorTypeName,false,true);
					if(objEditorType!=null)
					{
						// Editor reference
						WebUITypeEditor objEditor = null;
						try
						{
							// Create editor with no parameters
							objEditor = Activator.CreateInstance(objEditorType) as WebUITypeEditor;
						}
						catch(Exception)
						{
							try
							{
								// Create editor with type parameters
								objEditor = Activator.CreateInstance(objEditorType,new object[]{objType}) as WebUITypeEditor;
							}
							catch(Exception)
							{
								// Reset editor
								objEditor = null;
							}
						}

						// Return editor if found
						if(objEditor!=null) return objEditor;
					}
                }
            }

			// If font type return font editor
            if (objType == typeof(Font))
            {
                return new FontEditor();
            }

			// If color type return colore editor
            if (objType == typeof(Color))
            {
                return new ColorEditor();
            }

			// If datetime type return datetype editor
			if(objType == typeof(DateTime))
			{
				return new DateTimeEditor();
			}

			// If dock style type return docking editor
			if(objType == typeof(DockStyle))
			{
				return new DockEditor();
			}

            if (objType == typeof(Keys))
            {
                return new ShortcutKeysEditor();
            }

			// If anchor style type return anchor editor
			if(objType == typeof(AnchorStyles))
			{
				return new AnchorEditor();
			}

			// If is list return collection editor
			if(objType.GetInterface("IList")!=null)
			{
				return new CollectionEditor(objType);
			}

			// If is colection return collection editor
			if(objType.GetInterface("ICollection")!=null)
			{
				return new CollectionEditor(objType);
			}

			// If is ResourceHandle return ResourceHandle editor
            if (CommonUtils.IsTypeOrSubType(objType,typeof(ResourceHandle)))
            {
                return new ResourceHandleEditor();
            }

            return null;
        }
    }
}