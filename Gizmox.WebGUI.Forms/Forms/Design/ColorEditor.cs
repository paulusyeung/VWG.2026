// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ColorEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// Provides a WebUITypeEditor for visually picking a color.
  /// </summary>
  [Serializable]
  public class ColorEditor : WebUITypeEditor
  {
    private WebUITypeEditorHandler mobjHandler;
    private Color mobjPropertyValue;

    /// <summary>
    /// Edits the given object value using the editor style provided by the GetEditStyle method.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
    /// <param name="objValue">The object to edit.</param>
    /// <param name="objHandler">The obj handler.</param>
    public override void EditValue(
      ITypeDescriptorContext objContext,
      IServiceProvider objProvider,
      object objValue,
      WebUITypeEditorHandler objHandler)
    {
      ColorEditorDropDown objDialog = new ColorEditorDropDown();
      objDialog.Color = (Color) this.GetEditorValueFromPropertyValue(objValue);
      objDialog.Closed += new EventHandler(this.objColorDialog_Closed);
      this.mobjPropertyValue = objDialog.Color;
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    /// <summary>
    /// Supplies a editor level mechanism to convert property values before editing
    /// </summary>
    /// <param name="value">The property value.</param>
    /// <returns></returns>
    protected override object GetEditorValueFromPropertyValue(object objValue) => objValue == null ? (object) Color.Empty : objValue;

    /// <summary>
    /// Supplies a editor level mechanism to convert editor returned values before assigning to property
    /// </summary>
    /// <param name="value">The editor returned value.</param>
    /// <returns></returns>
    protected override object GetPropertyValueFromEditorValue(object objValue) => objValue;

    private void objColorDialog_Closed(object sender, EventArgs e)
    {
      ColorEditorDropDown colorEditorDropDown = (ColorEditorDropDown) sender;
      if (!colorEditorDropDown.IsCompleted || this.mobjHandler == null)
        return;
      object valueFromEditorValue;
      try
      {
        valueFromEditorValue = this.GetPropertyValueFromEditorValue((object) colorEditorDropDown.Color);
      }
      catch (Exception ex)
      {
        this.OnValueChangeError(ex);
        return;
      }
      this.mobjHandler(valueFromEditorValue);
    }

    /// <summary>
    /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
    /// </returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.DropDown;

    /// <summary>Gets the property value.</summary>
    /// <value>The property value.</value>
    protected Color PropertyValue => this.mobjPropertyValue;
  }
}
