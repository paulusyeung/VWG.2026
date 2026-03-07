// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.AnchorEditor
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
  /// 
  /// </summary>
  [Serializable]
  public class AnchorEditor : WebUITypeEditor
  {
    private WebUITypeEditorHandler mobjHandler;
    private AnchorStyles mobjPropertyValue;

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
      AnchorEditor.AnchorEditorDropDown objDialog = new AnchorEditor.AnchorEditorDropDown();
      objDialog.Value = (AnchorStyles) this.GetEditorValueFromPropertyValue(objValue);
      objDialog.Closed += new EventHandler(this.objAnchorDialog_Closed);
      this.mobjPropertyValue = objDialog.Anchor;
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    private void objAnchorDialog_Closed(object sender, EventArgs e)
    {
      AnchorEditor.AnchorEditorDropDown anchorEditorDropDown = (AnchorEditor.AnchorEditorDropDown) sender;
      if (!anchorEditorDropDown.IsCompleted || this.mobjHandler == null)
        return;
      object valueFromEditorValue;
      try
      {
        valueFromEditorValue = this.GetPropertyValueFromEditorValue((object) anchorEditorDropDown.Value);
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
    protected AnchorStyles PropertyValue => this.mobjPropertyValue;

    [Serializable]
    private class AnchorEditorDropDown : Form
    {
      private AnchorPanel mobjPanelTop;
      private AnchorPanel mobjPanelBottom;
      private AnchorPanel mobjPanelLeft;
      private AnchorPanel mobjPanelRight;
      private Panel mobjPanelCenter;
      private bool mblnIsCompleted = true;
      private bool mblnTop;
      private bool mblnBottom;
      private bool mblnLeft;
      private bool mblnRight;
      private AnchorStyles mobjValue;

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjPanelTop = new AnchorPanel();
        this.mobjPanelBottom = new AnchorPanel();
        this.mobjPanelLeft = new AnchorPanel();
        this.mobjPanelRight = new AnchorPanel();
        this.mobjPanelCenter = new Panel();
        this.SuspendLayout();
        this.mobjPanelTop.BackColor = SystemColors.ControlDarkDark;
        this.mobjPanelTop.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.mobjPanelTop.Location = new Point(68, 0);
        this.mobjPanelTop.Name = "mobjPanelTop";
        this.mobjPanelTop.Size = new Size(9, 25);
        this.mobjPanelTop.TabIndex = 0;
        this.mobjPanelTop.Click += new EventHandler(this.mobjPanelTop_Click);
        this.mobjPanelBottom.BackColor = SystemColors.ControlDarkDark;
        this.mobjPanelBottom.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.mobjPanelBottom.Location = new Point(68, 67);
        this.mobjPanelBottom.Name = "mobjPanelBottom";
        this.mobjPanelBottom.Size = new Size(9, 25);
        this.mobjPanelBottom.TabIndex = 1;
        this.mobjPanelBottom.Click += new EventHandler(this.mobjPanelBottom_Click);
        this.mobjPanelLeft.BackColor = SystemColors.ControlDarkDark;
        this.mobjPanelLeft.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.mobjPanelLeft.Location = new Point(0, 41);
        this.mobjPanelLeft.Name = "mobjPanelLeft";
        this.mobjPanelLeft.Size = new Size(25, 10);
        this.mobjPanelLeft.TabIndex = 2;
        this.mobjPanelLeft.Click += new EventHandler(this.mobjPanelLeft_Click);
        this.mobjPanelRight.BackColor = SystemColors.ControlDarkDark;
        this.mobjPanelRight.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.mobjPanelRight.Location = new Point(120, 41);
        this.mobjPanelRight.Name = "mobjPanelRight";
        this.mobjPanelRight.Size = new Size(25, 10);
        this.mobjPanelRight.TabIndex = 3;
        this.mobjPanelRight.Click += new EventHandler(this.mobjPanelRight_Click);
        this.mobjPanelCenter.BackColor = Color.FromArgb(200, 200, 200);
        this.mobjPanelCenter.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.mobjPanelCenter.Location = new Point(27, 27);
        this.mobjPanelCenter.Name = "mobjPanelCenter";
        this.mobjPanelCenter.Size = new Size(91, 38);
        this.mobjPanelCenter.TabIndex = 4;
        this.Anchor = AnchorStyles.Left;
        this.Controls.Add((Control) this.mobjPanelCenter);
        this.Controls.Add((Control) this.mobjPanelRight);
        this.Controls.Add((Control) this.mobjPanelLeft);
        this.Controls.Add((Control) this.mobjPanelBottom);
        this.Controls.Add((Control) this.mobjPanelTop);
        this.DragTargets = (Gizmox.WebGUI.Forms.Component[]) new Control[0];
        this.Size = new Size(145, 92);
        this.Text = nameof (AnchorEditorDropDown);
        this.ResumeLayout(false);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.AnchorEditor.AnchorEditorDropDown" /> class.
      /// </summary>
      public AnchorEditorDropDown() => this.InitializeComponent();

      private void mobjPanelTop_Click(object sender, EventArgs e)
      {
        this.mblnTop = !this.mblnTop;
        this.UpdateAnchoring();
        this.UpdateValue();
      }

      private void mobjPanelRight_Click(object sender, EventArgs e)
      {
        this.mblnRight = !this.mblnRight;
        this.UpdateAnchoring();
        this.UpdateValue();
      }

      private void mobjPanelLeft_Click(object sender, EventArgs e)
      {
        this.mblnLeft = !this.mblnLeft;
        this.UpdateAnchoring();
        this.UpdateValue();
      }

      private void mobjPanelBottom_Click(object sender, EventArgs e)
      {
        this.mblnBottom = !this.mblnBottom;
        this.UpdateAnchoring();
        this.UpdateValue();
      }

      private void UpdateAnchoring()
      {
        Color white = Color.White;
        Color color = Color.FromKnownColor(KnownColor.ControlDarkDark);
        this.mobjPanelTop.BackColor = this.mblnTop ? color : white;
        this.mobjPanelBottom.BackColor = this.mblnBottom ? color : white;
        this.mobjPanelLeft.BackColor = this.mblnLeft ? color : white;
        this.mobjPanelRight.BackColor = this.mblnRight ? color : white;
      }

      private void UpdateValue()
      {
        AnchorStyles anchorStyles = AnchorStyles.None;
        if (this.mblnLeft)
          anchorStyles |= AnchorStyles.Left;
        if (this.mblnTop)
          anchorStyles |= AnchorStyles.Top;
        if (this.mblnBottom)
          anchorStyles |= AnchorStyles.Bottom;
        if (this.mblnRight)
          anchorStyles |= AnchorStyles.Right;
        this.mobjValue = anchorStyles;
      }

      public AnchorStyles Value
      {
        get => this.mobjValue;
        set
        {
          if (this.mobjValue == value)
            return;
          this.mblnLeft = (value & AnchorStyles.Left) == AnchorStyles.Left;
          this.mblnRight = (value & AnchorStyles.Right) == AnchorStyles.Right;
          this.mblnTop = (value & AnchorStyles.Top) == AnchorStyles.Top;
          this.mblnBottom = (value & AnchorStyles.Bottom) == AnchorStyles.Bottom;
          this.UpdateAnchoring();
          this.mobjValue = value;
        }
      }

      public bool IsCompleted => this.mblnIsCompleted;
    }
  }
}
