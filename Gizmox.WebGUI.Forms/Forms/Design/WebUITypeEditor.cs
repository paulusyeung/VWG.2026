// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.WebUITypeEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// Provides a base class that can be used to design value editors that
  /// can provide a web user interface (Web UI) for representing and editing the
  /// values of objects of the supported data types.
  /// </summary>
  [Serializable]
  public class WebUITypeEditor
  {
    private GridEntry mobjGridEntryOwner;

    /// <summary>
    /// Edits the value of the specified object using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
    /// </summary>
    /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
    /// <param name="objValue">The object to edit.</param>
    /// <param name="objHandler">The obj handler.</param>
    public void EditValue(
      IServiceProvider objProvider,
      object objValue,
      WebUITypeEditorHandler objHandler)
    {
      this.EditValue((ITypeDescriptorContext) null, objProvider, objValue, objHandler);
    }

    /// <summary>
    /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
    /// <param name="objValue">The object to edit.</param>
    /// <param name="objHandler">The obj handler.</param>
    public virtual void EditValue(
      ITypeDescriptorContext objContext,
      IServiceProvider objProvider,
      object objValue,
      WebUITypeEditorHandler objHandler)
    {
      this.mobjGridEntryOwner = objContext as GridEntry;
    }

    /// <summary>Raise error on value change</summary>
    /// <param name="objException"></param>
    protected void OnValueChangeError(Exception objException)
    {
      if (this.mobjGridEntryOwner == null)
        return;
      this.mobjGridEntryOwner.OnValueChangeError(objException);
    }

    /// <summary>Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
    /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value that indicates the style of editor used by the current <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. By default, this method will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
    public UITypeEditorEditStyle GetEditStyle() => this.GetEditStyle((ITypeDescriptorContext) null);

    /// <summary>Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.</summary>
    /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
    public virtual UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.None;

    /// <summary>Gets a value indicating whether drop-down editors should be resizable by the user.</summary>
    /// <returns>true if drop-down editors are resizable; otherwise, false. </returns>
    public virtual bool IsDropDownResizable => false;

    /// <summary>Gets a value indicating whether this editor value should support text editing.</summary>
    /// <returns>true if editor value should support text editing; otherwise, false. </returns>
    public virtual bool IsTextEditable => true;

    /// <summary>Gets the ditor value from the property value</summary>
    /// <param name="value"></param>
    /// <returns></returns>
    internal object GetEditorValueFromPropertyValueInternal(object objValue) => this.GetEditorValueFromPropertyValue(objValue);

    /// <summary>Validated property value</summary>
    /// <param name="value"></param>
    internal void ValidatePropertyValueInternal(object objValue) => this.ValidatePropertyValue(objValue);

    /// <summary>Validated property value</summary>
    /// <param name="value"></param>
    protected virtual void ValidatePropertyValue(object objValue)
    {
    }

    /// <summary>
    /// Supplies a editor level mechanism to convert property values before editing
    /// </summary>
    /// <param name="value">The property value.</param>
    /// <returns></returns>
    protected virtual object GetEditorValueFromPropertyValue(object objValue) => objValue;

    /// <summary>
    /// Supplies a editor level mechanism to convert editor returned values before assigning to property
    /// </summary>
    /// <param name="value">The editor returned value.</param>
    /// <returns></returns>
    protected virtual object GetPropertyValueFromEditorValue(object objValue) => objValue;

    /// <summary>
    /// Gets an editor with the WebUITypeEditor base type for the specified component.
    /// </summary>
    /// <param name="objComponent">The component to get the editor for. </param>
    /// <returns></returns>
    public static WebUITypeEditor GetEditor(object objComponent) => objComponent != null ? WebUITypeEditor.GetEditor(objComponent.GetType(), typeof (WebUITypeEditor)) : (WebUITypeEditor) null;

    /// <summary>
    /// Gets an editor with the specified base type for the specified component.
    /// </summary>
    /// <param name="objComponent">The component to get the editor for. </param>
    /// <param name="objBaseType">A Type that represents the base type of the editor you want to find.</param>
    /// <returns></returns>
    public static WebUITypeEditor GetEditor(object objComponent, Type objBaseType) => objComponent != null ? WebUITypeEditor.GetEditor(objComponent.GetType(), objBaseType) : (WebUITypeEditor) null;

    /// <summary>
    /// Returns an editor with the WebUITypeEditor base type for the specified type.
    /// </summary>
    /// <param name="objType">The Type of the target component.</param>
    /// <returns></returns>
    public static WebUITypeEditor GetEditor(Type objType) => WebUITypeEditor.GetEditor(objType, typeof (WebUITypeEditor));

    /// <summary>Gets an editor from the property attributes</summary>
    /// <param name="objPropertyInfo"></param>
    /// <returns></returns>
    public static WebUITypeEditor GetPropertyEditor(PropertyDescriptor objPropertyInfo) => WebUITypeEditor.GetPropertyEditor(objPropertyInfo, typeof (WebUITypeEditor));

    /// <summary>
    /// Gets a typed inherited editor from property attributes
    /// </summary>
    /// <param name="objPropertyInfo"></param>
    /// <param name="objBaseType"></param>
    /// <returns></returns>
    public static WebUITypeEditor GetPropertyEditor(
      PropertyDescriptor objPropertyInfo,
      Type objBaseType)
    {
      foreach (Attribute attribute in objPropertyInfo.Attributes)
      {
        if (attribute is WebEditorAttribute webEditorAttribute)
        {
          Type type = Type.GetType(webEditorAttribute.EditorTypeName, false, true);
          if (type != (Type) null)
          {
            WebUITypeEditor propertyEditor = (WebUITypeEditor) null;
            bool flag = false;
            try
            {
              foreach (MethodBase constructor in type.GetConstructors(~BindingFlags.Static))
              {
                if (constructor.GetParameters().Length == 0)
                {
                  flag = true;
                  break;
                }
              }
              if (flag)
                propertyEditor = Activator.CreateInstance(type) as WebUITypeEditor;
            }
            catch (Exception ex)
            {
            }
            try
            {
              if (propertyEditor == null)
                propertyEditor = Activator.CreateInstance(type, (object) objPropertyInfo.PropertyType) as WebUITypeEditor;
            }
            catch (Exception ex)
            {
            }
            if (propertyEditor != null)
              return propertyEditor;
          }
        }
      }
      return (WebUITypeEditor) null;
    }

    /// <summary>
    /// Returns an editor with the specified base type for the specified type.
    /// </summary>
    /// <param name="objType">The Type of the target component.</param>
    /// <param name="objBaseType">A Type that represents the base type of the editor you are trying to find.</param>
    /// <returns></returns>
    public static WebUITypeEditor GetEditor(Type objType, Type objBaseType)
    {
      foreach (Attribute attribute in TypeDescriptor.GetAttributes(objType))
      {
        if (attribute is WebEditorAttribute webEditorAttribute)
        {
          Type type = Type.GetType(webEditorAttribute.EditorTypeName, false, true);
          if (type != (Type) null)
          {
            WebUITypeEditor editor;
            try
            {
              editor = Activator.CreateInstance(type) as WebUITypeEditor;
            }
            catch (Exception ex1)
            {
              try
              {
                editor = Activator.CreateInstance(type, (object) objType) as WebUITypeEditor;
              }
              catch (Exception ex2)
              {
                editor = (WebUITypeEditor) null;
              }
            }
            if (editor != null)
              return editor;
          }
        }
      }
      if (objType == typeof (Font))
        return (WebUITypeEditor) new FontEditor();
      if (objType == typeof (Color))
        return (WebUITypeEditor) new ColorEditor();
      if (objType == typeof (DateTime))
        return (WebUITypeEditor) new DateTimeEditor();
      if (objType == typeof (DockStyle))
        return (WebUITypeEditor) new DockEditor();
      if (objType == typeof (Keys))
        return (WebUITypeEditor) new ShortcutKeysEditor();
      if (objType == typeof (AnchorStyles))
        return (WebUITypeEditor) new AnchorEditor();
      if (objType.GetInterface("IList") != (Type) null)
        return (WebUITypeEditor) new CollectionEditor(objType);
      if (objType.GetInterface("ICollection") != (Type) null)
        return (WebUITypeEditor) new CollectionEditor(objType);
      return CommonUtils.IsTypeOrSubType(objType, typeof (ResourceHandle)) ? (WebUITypeEditor) new ResourceHandleEditor() : (WebUITypeEditor) null;
    }
  }
}
