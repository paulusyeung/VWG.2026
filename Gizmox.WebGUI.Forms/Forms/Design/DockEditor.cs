// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.DockEditor
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
  /// Provides a user interface for specifying a Dock property.
  /// </summary>
  [Serializable]
  public class DockEditor : WebUITypeEditor
  {
    private WebUITypeEditorHandler mobjHandler;
    private DockStyle menmPropertyValue;

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
      DockEditor.DockEditorDropDown objDialog = new DockEditor.DockEditorDropDown();
      objDialog.Dock = (DockStyle) this.GetEditorValueFromPropertyValue(objValue);
      objDialog.Closed += new EventHandler(this.objDockDialog_Closed);
      this.menmPropertyValue = objDialog.Dock;
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    private void objDockDialog_Closed(object sender, EventArgs e)
    {
      DockEditor.DockEditorDropDown dockEditorDropDown = (DockEditor.DockEditorDropDown) sender;
      if (!dockEditorDropDown.IsCompleted || this.mobjHandler == null)
        return;
      object valueFromEditorValue;
      try
      {
        valueFromEditorValue = this.GetPropertyValueFromEditorValue((object) dockEditorDropDown.Dock);
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
    protected DockStyle PropertyValue => this.menmPropertyValue;

    [Serializable]
    private class DockEditorDropDown : Form
    {
      private DockButton mobjButtonNone;
      private DockButton mobjButtonTop;
      private DockButton mobjButtonBottom;
      private DockButton mobjButtonLeft;
      private DockButton mobjButtonRight;
      private DockButton mobjButtonFill;
      private DockStyle menmValue;
      private bool mblnIsCompleted;

      public DockEditorDropDown() => this.InitializeComponent();

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjButtonNone = new DockButton();
        this.mobjButtonTop = new DockButton();
        this.mobjButtonBottom = new DockButton();
        this.mobjButtonLeft = new DockButton();
        this.mobjButtonRight = new DockButton();
        this.mobjButtonFill = new DockButton();
        this.SuspendLayout();
        this.mobjButtonNone.Dock = DockStyle.Bottom;
        this.mobjButtonNone.Location = new Point(0, 103);
        this.mobjButtonNone.Name = "mobjButtonNone";
        this.mobjButtonNone.Size = new Size(144, 23);
        this.mobjButtonNone.TabIndex = 0;
        this.mobjButtonNone.Text = "None";
        this.mobjButtonNone.Click += new EventHandler(this.mobjButtonNone_Click);
        this.mobjButtonTop.Dock = DockStyle.Top;
        this.mobjButtonTop.Location = new Point(0, 0);
        this.mobjButtonTop.Name = "mobjButtonTop";
        this.mobjButtonTop.Size = new Size(144, 20);
        this.mobjButtonTop.TabIndex = 1;
        this.mobjButtonTop.Click += new EventHandler(this.mobjButtonTop_Click);
        this.mobjButtonBottom.Dock = DockStyle.Bottom;
        this.mobjButtonBottom.Location = new Point(0, 83);
        this.mobjButtonBottom.Name = "mobjButtonBottom";
        this.mobjButtonBottom.Size = new Size(144, 20);
        this.mobjButtonBottom.TabIndex = 2;
        this.mobjButtonBottom.Click += new EventHandler(this.mobjButtonBottom_Click);
        this.mobjButtonLeft.Dock = DockStyle.Left;
        this.mobjButtonLeft.Location = new Point(0, 20);
        this.mobjButtonLeft.Name = "mobjButtonLeft";
        this.mobjButtonLeft.Size = new Size(20, 63);
        this.mobjButtonLeft.TabIndex = 3;
        this.mobjButtonLeft.Click += new EventHandler(this.mobjButtonLeft_Click);
        this.mobjButtonRight.Dock = DockStyle.Right;
        this.mobjButtonRight.Location = new Point(124, 20);
        this.mobjButtonRight.Name = "mobjButtonRight";
        this.mobjButtonRight.Size = new Size(20, 63);
        this.mobjButtonRight.TabIndex = 4;
        this.mobjButtonRight.Click += new EventHandler(this.mobjButtonRight_Click);
        this.mobjButtonFill.Dock = DockStyle.Fill;
        this.mobjButtonFill.Location = new Point(20, 20);
        this.mobjButtonFill.Name = "mobjButtonFill";
        this.mobjButtonFill.Size = new Size(104, 63);
        this.mobjButtonFill.TabIndex = 5;
        this.mobjButtonFill.Click += new EventHandler(this.mobjButtonFill_Click);
        this.ClientSize = new Size(144, 126);
        this.Controls.Add((Control) this.mobjButtonFill);
        this.Controls.Add((Control) this.mobjButtonRight);
        this.Controls.Add((Control) this.mobjButtonLeft);
        this.Controls.Add((Control) this.mobjButtonBottom);
        this.Controls.Add((Control) this.mobjButtonTop);
        this.Controls.Add((Control) this.mobjButtonNone);
        this.Name = "Form3";
        this.Text = "Form3";
        this.ResumeLayout(false);
      }

      private void mobjButtonTop_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.Top;
        this.mblnIsCompleted = true;
        this.Close();
      }

      private void mobjButtonRight_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.Right;
        this.mblnIsCompleted = true;
        this.Close();
      }

      private void mobjButtonFill_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.Fill;
        this.mblnIsCompleted = true;
        this.Close();
      }

      private void mobjButtonLeft_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.Left;
        this.mblnIsCompleted = true;
        this.Close();
      }

      private void mobjButtonBottom_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.Bottom;
        this.mblnIsCompleted = true;
        this.Close();
      }

      private void mobjButtonNone_Click(object sender, EventArgs e)
      {
        this.menmValue = DockStyle.None;
        this.mblnIsCompleted = true;
        this.Close();
      }

      /// <summary>Gets/Sets the controls docking style</summary>
      /// <value></value>
      public new DockStyle Dock
      {
        get => this.menmValue;
        set => this.menmValue = value;
      }

      public bool IsCompleted => this.mblnIsCompleted;
    }
  }
}
