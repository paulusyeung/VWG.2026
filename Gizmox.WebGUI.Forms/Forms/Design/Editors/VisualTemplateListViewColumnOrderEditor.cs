// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.Editors.VisualTemplateListViewColumnOrderEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.PropertyGridInternal;
using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
  /// <summary>
  /// The editor to set the order of the listview columns when using the VisualTemplate.
  /// </summary>
  [Serializable]
  public class VisualTemplateListViewColumnOrderEditor : WebUITypeEditor
  {
    /// <summary>The handler</summary>
    private WebUITypeEditorHandler mobjHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.Editors.VisualTemplateListViewColumnOrderEditor" /> class.
    /// </summary>
    /// <param name="objType">Type of the object.</param>
    public VisualTemplateListViewColumnOrderEditor(Type objType)
    {
    }

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
      VisualTemplate instance = objContext.Instance as VisualTemplate;
      GridEntry gridEntry = objProvider as GridEntry;
      PropertyGrid propertyGrid = (PropertyGrid) null;
      if (gridEntry != null)
        propertyGrid = gridEntry.OwnerGrid;
      if (instance == null || propertyGrid == null)
        return;
      VisualTemplateListViewColumnControlDialog objDialog = new VisualTemplateListViewColumnControlDialog(propertyGrid.Tag as ListView, objValue as string);
      objDialog.Closed += new EventHandler(this.objVisualTemplateListViewColumnControlDialog_Closed);
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDialog((CommonDialog) objDialog);
    }

    /// <summary>
    /// Handles the Closed event of the objVisualTemplateListViewColumnControlDialog control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objVisualTemplateListViewColumnControlDialog_Closed(object sender, EventArgs e)
    {
      VisualTemplateListViewColumnControlDialog columnControlDialog = (VisualTemplateListViewColumnControlDialog) sender;
      if (columnControlDialog.DialogResult != DialogResult.OK || this.mobjHandler == null)
        return;
      this.mobjHandler(this.GetPropertyValueFromEditorValue((object) columnControlDialog.ListViewColumnOrder));
    }

    /// <summary>
    /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
    /// </returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.Modal;
  }
}
