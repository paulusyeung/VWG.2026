// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.StandardValuesEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class StandardValuesEditor : WebUITypeEditor
  {
    private WebUITypeEditorHandler mobjHandler;
    private TypeConverter mobjTypeConvertor;

    public StandardValuesEditor()
    {
    }

    public StandardValuesEditor(TypeConverter objTypeConvertor) => this.mobjTypeConvertor = objTypeConvertor;

    public override void EditValue(
      ITypeDescriptorContext objContext,
      IServiceProvider objProvider,
      object objValue,
      WebUITypeEditorHandler objHandler)
    {
      ArrayList listValues = this.GetListValues(objContext);
      if (listValues.Count <= 0)
        return;
      StandardValuesEditor.ListBoxForm objDialog = new StandardValuesEditor.ListBoxForm((ICollection) listValues);
      objDialog.Closed += new EventHandler(this.objListBoxForm_Closed);
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    protected virtual ArrayList GetListValues(ITypeDescriptorContext objContext)
    {
      TypeConverter.StandardValuesCollection standardValues = this.mobjTypeConvertor.GetStandardValues(objContext);
      ArrayList listValues = new ArrayList();
      foreach (object obj in standardValues)
      {
        if (obj != null)
          listValues.Add(obj);
      }
      return listValues;
    }

    private void objListBoxForm_Closed(object sender, EventArgs e)
    {
      StandardValuesEditor.ListBoxForm listBoxForm = (StandardValuesEditor.ListBoxForm) sender;
      if (!listBoxForm.IsCompleted || this.mobjHandler == null)
        return;
      this.mobjHandler(this.GetPropertyValueFromEditorValue(listBoxForm.Value));
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.DropDown;

    [Serializable]
    private class ListBoxForm : Form
    {
      private bool mblnIsCompleted;
      private ListBox mobjListBox;

      public ListBoxForm(ICollection objCollection)
      {
        this.mobjListBox = (ListBox) new StandardValuesEditor.ListBoxForm.TempListBox();
        this.mobjListBox.Dock = DockStyle.Fill;
        this.mobjListBox.BorderStyle = BorderStyle.FixedSingle;
        this.mobjListBox.SelectionMode = SelectionMode.One;
        this.mobjListBox.Items.AddRange(objCollection);
        this.mobjListBox.SelectedIndexChanged += new EventHandler(this.objListBox_SelectedIndexChanged);
        this.SuspendLayout();
        this.BackColor = Color.White;
        int num1 = 2;
        int num2 = 2;
        int num3 = 0;
        BorderWidth borderWidth;
        if (this.Skin is FormSkin skin1 && skin1.CenterPopupWindowStyle.BorderStyle != BorderStyle.None)
        {
          borderWidth = skin1.CenterPopupWindowStyle.BorderWidth;
          int bottom = borderWidth.Bottom;
          borderWidth = skin1.CenterPopupWindowStyle.BorderWidth;
          int top = borderWidth.Top;
          num3 = bottom + top;
        }
        if (this.mobjListBox.Skin is ListBoxSkin skin2)
        {
          borderWidth = skin2.BorderWidth;
          int top = borderWidth.Top;
          borderWidth = skin2.BorderWidth;
          int bottom = borderWidth.Bottom;
          num1 = top + bottom;
        }
        this.Height = this.mobjListBox.GetPreferdItemHeight() * (objCollection.Count > 15 ? 15 : objCollection.Count) + num1 + num2 + num3;
        this.Width = 130;
        this.Controls.Add((Control) this.mobjListBox);
        this.ResumeLayout(true);
      }

      private void objListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
        this.mblnIsCompleted = true;
        this.Close();
      }

      public bool IsCompleted => this.mblnIsCompleted;

      public object Value => this.mobjListBox.SelectedItem;

      [ToolboxItem(false)]
      [Serializable]
      private class TempListBox : ListBox
      {
        protected override bool IsDelayedDrawing => false;
      }
    }
  }
}
