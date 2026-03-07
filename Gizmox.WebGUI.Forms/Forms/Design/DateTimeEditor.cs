// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.DateTimeEditor
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
  /// This date time editor is a WebUITypeEditor suitable for visually editing DateTime objects.
  /// </summary>
  [Serializable]
  public class DateTimeEditor : WebUITypeEditor
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
      DateTimeEditor.DateTimeEditorDropDown objDialog = new DateTimeEditor.DateTimeEditorDropDown();
      objDialog.Value = (DateTime) this.GetEditorValueFromPropertyValue(objValue);
      objDialog.Closed += new EventHandler(this.objDateTimeDialog_Closed);
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    private void objDateTimeDialog_Closed(object sender, EventArgs e)
    {
      DateTimeEditor.DateTimeEditorDropDown timeEditorDropDown = (DateTimeEditor.DateTimeEditorDropDown) sender;
      if (!timeEditorDropDown.IsCompleted)
        return;
      object valueFromEditorValue;
      try
      {
        valueFromEditorValue = this.GetPropertyValueFromEditorValue((object) timeEditorDropDown.Value);
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

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class DateTimeEditorDropDown : Form
    {
      private MonthCalendar mobjMonthCalendar;
      private DateTime mobjDate;
      private bool mblnIsCompleted;

      /// <summary>
      /// 
      /// </summary>
      internal DateTimeEditorDropDown() => this.InitializeComponent();

      /// <summary>
      /// 
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjMonthCalendar = new MonthCalendar();
        this.SuspendLayout();
        this.mobjMonthCalendar.Dock = DockStyle.Fill;
        this.mobjMonthCalendar.DateChanged += new EventHandler(this.mobjMonthCalendar_ValueChanged);
        this.Controls.Add((Control) this.mobjMonthCalendar);
        this.Size = new Size(175, 154);
        this.ClientSize = new Size(175, 154);
        this.Text = WGLabels.DatePicker;
        this.ResumeLayout(false);
      }

      public DateTime Value
      {
        get => this.mobjDate;
        set => this.mobjMonthCalendar.Value = this.mobjDate = value;
      }

      public bool IsCompleted => this.mblnIsCompleted;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void mobjMonthCalendar_ValueChanged(object sender, EventArgs e)
      {
        this.mobjDate = this.mobjMonthCalendar.Value;
        this.mblnIsCompleted = true;
        this.Close();
      }
    }
  }
}
