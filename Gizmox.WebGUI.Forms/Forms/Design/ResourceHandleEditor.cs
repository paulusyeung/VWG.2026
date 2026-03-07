// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ResourceHandleEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ResourceHandleEditor : WebUITypeEditor
  {
    private WebUITypeEditorHandler mobjHandler;

    /// <summary>
    /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
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
      ServerOpenFileDialog objDialog = new ServerOpenFileDialog();
      objDialog.Closed += new EventHandler(this.objServerOpenFileDialog_Closed);
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDialog((CommonDialog) objDialog);
    }

    /// <summary>
    /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
    /// </returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.Modal;

    /// <summary>
    /// Handles the Closed event of the objServerOpenFileDialog control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objServerOpenFileDialog_Closed(object sender, EventArgs e)
    {
      if (!(sender is ServerOpenFileDialog serverOpenFileDialog) || serverOpenFileDialog.DialogResult != DialogResult.OK || this.mobjHandler == null)
        return;
      this.mobjHandler(this.GetPropertyValueFromEditorValue((object) this.GetResourceName(serverOpenFileDialog.FileName)));
    }

    /// <summary>Gets the name of the resource.</summary>
    /// <param name="strFileName">Name of the STR file.</param>
    /// <returns></returns>
    private ResourceHandle GetResourceName(string strFileName)
    {
      string directory1 = Global.Context.Config.GetDirectory("Icons");
      string directory2 = Global.Context.Config.GetDirectory("Images");
      if (strFileName.ToLower(CultureInfo.InvariantCulture).StartsWith(directory1.ToLower(CultureInfo.InvariantCulture)))
        return (ResourceHandle) new IconResourceHandle(strFileName.Remove(0, directory1.Length + 1).Replace("\\", "."));
      return strFileName.ToLower(CultureInfo.InvariantCulture).StartsWith(directory2.ToLower(CultureInfo.InvariantCulture)) ? (ResourceHandle) new ImageResourceHandle(strFileName.Remove(0, directory2.Length + 1).Replace("\\", ".")) : (ResourceHandle) null;
    }
  }
}
