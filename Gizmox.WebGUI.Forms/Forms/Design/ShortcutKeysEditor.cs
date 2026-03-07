// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ShortcutKeysEditor
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
  /// Provides a user interface for specifying a ShortcutKeys property.
  /// </summary>
  [Serializable]
  public class ShortcutKeysEditor : WebUITypeEditor
  {
    private Keys menmPropertyValue;
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
      ShortcutKeysEditor.ShortcutKeysUI objDialog = new ShortcutKeysEditor.ShortcutKeysUI();
      objDialog.ShortcutKeys = (Keys) this.GetEditorValueFromPropertyValue(objValue);
      objDialog.Closed += new EventHandler(this.objShortcutKeysUI_Closed);
      this.menmPropertyValue = objDialog.ShortcutKeys;
      this.mobjHandler = objHandler;
      if (!(objProvider.GetService(typeof (IWebUIEditorService)) is IWebUIEditorService service))
        return;
      service.ShowDropDown((Form) objDialog);
    }

    /// <summary>
    /// Handles the Closed event of the objShortcutKeysUI control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objShortcutKeysUI_Closed(object sender, EventArgs e)
    {
      ShortcutKeysEditor.ShortcutKeysUI shortcutKeysUi = (ShortcutKeysEditor.ShortcutKeysUI) sender;
      if (!shortcutKeysUi.IsCompleted || this.mobjHandler == null)
        return;
      object valueFromEditorValue;
      try
      {
        valueFromEditorValue = this.GetPropertyValueFromEditorValue((object) shortcutKeysUi.ShortcutKeys);
      }
      catch (Exception ex)
      {
        this.OnValueChangeError(ex);
        return;
      }
      this.mobjHandler(valueFromEditorValue);
    }

    /// <summary>Gets the edit style.</summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class ShortcutKeysUI : Form
    {
      private Label mobjLabelmodifiers;
      private CheckBox mobjCheckBoxCtrl;
      private CheckBox mobjCheckBoxShift;
      private CheckBox mobjCheckBoxAlt;
      private Label mobjLabelKeys;
      private ComboBox mobjComboBoxKeys;
      private Button mobjButtonReset;
      private TypeConverter mobjKeysConverter;
      private static Keys[] validKeys = new Keys[94]
      {
        Keys.A,
        Keys.B,
        Keys.C,
        Keys.D,
        Keys.D0,
        Keys.D1,
        Keys.D2,
        Keys.D3,
        Keys.D4,
        Keys.D5,
        Keys.D6,
        Keys.D7,
        Keys.D8,
        Keys.D9,
        Keys.Delete,
        Keys.Down,
        Keys.E,
        Keys.End,
        Keys.F,
        Keys.F1,
        Keys.F10,
        Keys.F11,
        Keys.F12,
        Keys.F13,
        Keys.F14,
        Keys.F15,
        Keys.F16,
        Keys.F17,
        Keys.F18,
        Keys.F19,
        Keys.F2,
        Keys.F20,
        Keys.F21,
        Keys.F22,
        Keys.F23,
        Keys.F24,
        Keys.F3,
        Keys.F4,
        Keys.F5,
        Keys.F6,
        Keys.F7,
        Keys.F8,
        Keys.F9,
        Keys.G,
        Keys.H,
        Keys.I,
        Keys.Insert,
        Keys.J,
        Keys.K,
        Keys.L,
        Keys.Left,
        Keys.M,
        Keys.N,
        Keys.NumLock,
        Keys.NumPad0,
        Keys.NumPad1,
        Keys.NumPad2,
        Keys.NumPad3,
        Keys.NumPad4,
        Keys.NumPad5,
        Keys.NumPad6,
        Keys.NumPad7,
        Keys.NumPad8,
        Keys.NumPad9,
        Keys.O,
        Keys.OemBackslash,
        Keys.OemClear,
        Keys.OemCloseBrackets,
        Keys.Oemcomma,
        Keys.OemMinus,
        Keys.OemOpenBrackets,
        Keys.OemPeriod,
        Keys.OemPipe,
        Keys.Oemplus,
        Keys.OemQuestion,
        Keys.OemQuotes,
        Keys.OemSemicolon,
        Keys.Oemtilde,
        Keys.P,
        Keys.Pause,
        Keys.Q,
        Keys.R,
        Keys.Right,
        Keys.S,
        Keys.Space,
        Keys.T,
        Keys.Tab,
        Keys.U,
        Keys.Up,
        Keys.V,
        Keys.W,
        Keys.X,
        Keys.Y,
        Keys.Z
      };
      private Keys menmValue;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.ShortcutKeysEditor.ShortcutKeysUI" /> class.
      /// </summary>
      public ShortcutKeysUI()
      {
        this.InitializeComponent();
        foreach (int validKey in ShortcutKeysEditor.ShortcutKeysUI.validKeys)
          this.mobjComboBoxKeys.Items.Add((object) this.KeysConverter.ConvertToString((object) (Keys) validKey));
      }

      /// <summary>Updates the value.</summary>
      private void UpdateUI()
      {
        Keys menmValue = this.menmValue;
        if (menmValue == Keys.None)
          return;
        this.mobjCheckBoxCtrl.Checked = (menmValue & Keys.Control) != 0;
        this.mobjCheckBoxAlt.Checked = (menmValue & Keys.Alt) != 0;
        this.mobjCheckBoxShift.Checked = (menmValue & Keys.Shift) != 0;
        this.mobjComboBoxKeys.SelectedItem = (object) this.KeysConverter.ConvertToString((object) (menmValue & Keys.KeyCode));
      }

      /// <summary>Initializes the component.</summary>
      private void InitializeComponent()
      {
        this.mobjLabelmodifiers = new Label();
        this.mobjCheckBoxCtrl = new CheckBox();
        this.mobjCheckBoxShift = new CheckBox();
        this.mobjCheckBoxAlt = new CheckBox();
        this.mobjLabelKeys = new Label();
        this.mobjComboBoxKeys = new ComboBox();
        this.mobjButtonReset = new Button();
        this.SuspendLayout();
        this.mobjLabelmodifiers.AutoSize = true;
        this.mobjLabelmodifiers.Location = new Point(10, 10);
        this.mobjLabelmodifiers.Name = "mobjLabelmodifiers";
        this.mobjLabelmodifiers.Size = new Size(35, 13);
        this.mobjLabelmodifiers.TabIndex = 0;
        this.mobjLabelmodifiers.Text = WGLabels.ModifiersColon;
        this.mobjCheckBoxCtrl.AutoSize = true;
        this.mobjCheckBoxCtrl.CheckState = CheckState.Unchecked;
        this.mobjCheckBoxCtrl.Location = new Point(20, 40);
        this.mobjCheckBoxCtrl.Name = "mobjCheckBoxCtrl";
        this.mobjCheckBoxCtrl.Size = new Size(43, 17);
        this.mobjCheckBoxCtrl.TabIndex = 1;
        this.mobjCheckBoxCtrl.Text = "Ctrl";
        this.mobjCheckBoxShift.AutoSize = true;
        this.mobjCheckBoxShift.CheckState = CheckState.Unchecked;
        this.mobjCheckBoxShift.Location = new Point(71, 40);
        this.mobjCheckBoxShift.Name = "mobjCheckBoxShift";
        this.mobjCheckBoxShift.Size = new Size(48, 17);
        this.mobjCheckBoxShift.TabIndex = 2;
        this.mobjCheckBoxShift.Text = "Shift";
        this.mobjCheckBoxAlt.AutoSize = true;
        this.mobjCheckBoxAlt.CheckState = CheckState.Unchecked;
        this.mobjCheckBoxAlt.Location = new Point(129, 40);
        this.mobjCheckBoxAlt.Name = "mobjCheckBoxAlt";
        this.mobjCheckBoxAlt.Size = new Size(39, 17);
        this.mobjCheckBoxAlt.TabIndex = 3;
        this.mobjCheckBoxAlt.Text = "Alt";
        this.mobjLabelKeys.AutoSize = true;
        this.mobjLabelKeys.Location = new Point(13, 70);
        this.mobjLabelKeys.Name = "mobjLabelKeys";
        this.mobjLabelKeys.Size = new Size(35, 13);
        this.mobjLabelKeys.TabIndex = 4;
        this.mobjLabelKeys.Text = WGLabels.KeysColon;
        this.mobjComboBoxKeys.AllowDrag = false;
        this.mobjComboBoxKeys.DropDownStyle = ComboBoxStyle.DropDownList;
        this.mobjComboBoxKeys.FormattingEnabled = true;
        this.mobjComboBoxKeys.Location = new Point(20, 100);
        this.mobjComboBoxKeys.Name = "mobjComboBoxKeys";
        this.mobjComboBoxKeys.Size = new Size(148, 21);
        this.mobjComboBoxKeys.TabIndex = 5;
        this.mobjButtonReset.AutoSize = true;
        this.mobjButtonReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        this.mobjButtonReset.Location = new Point(182, 100);
        this.mobjButtonReset.Name = "mobjButtonReset";
        this.mobjButtonReset.Size = new Size(75, 23);
        this.mobjButtonReset.TabIndex = 6;
        this.mobjButtonReset.Text = WGLabels.Reset;
        this.mobjButtonReset.Click += new EventHandler(this.mobjButtonReset_Click);
        this.Controls.Add((Control) this.mobjButtonReset);
        this.Controls.Add((Control) this.mobjComboBoxKeys);
        this.Controls.Add((Control) this.mobjLabelKeys);
        this.Controls.Add((Control) this.mobjCheckBoxAlt);
        this.Controls.Add((Control) this.mobjCheckBoxShift);
        this.Controls.Add((Control) this.mobjCheckBoxCtrl);
        this.Controls.Add((Control) this.mobjLabelmodifiers);
        this.Size = new Size(240, 140);
        this.Text = "";
        this.ResumeLayout(false);
      }

      /// <summary>
      /// Handles the Click event of the mobjButtonReset control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjButtonReset_Click(object sender, EventArgs e)
      {
        this.mobjCheckBoxCtrl.Checked = false;
        this.mobjCheckBoxAlt.Checked = false;
        this.mobjCheckBoxShift.Checked = false;
        this.mobjComboBoxKeys.SelectedIndex = -1;
      }

      /// <summary>Updates the current value.</summary>
      private void UpdateCurrentValue()
      {
        this.menmValue = Keys.None;
        if (this.mobjComboBoxKeys.SelectedIndex <= -1)
          return;
        this.menmValue = ShortcutKeysEditor.ShortcutKeysUI.validKeys[this.mobjComboBoxKeys.SelectedIndex];
        if (this.mobjCheckBoxCtrl.Checked)
          this.menmValue |= Keys.Control;
        if (this.mobjCheckBoxAlt.Checked)
          this.menmValue |= Keys.Alt;
        if (!this.mobjCheckBoxShift.Checked)
          return;
        this.menmValue |= Keys.Shift;
      }

      /// <summary>Gets or sets the shortcut keys.</summary>
      /// <value>The shortcut keys.</value>
      public Keys ShortcutKeys
      {
        get
        {
          this.UpdateCurrentValue();
          return this.menmValue;
        }
        set
        {
          this.menmValue = value;
          this.UpdateUI();
        }
      }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is completed.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is completed; otherwise, <c>false</c>.
      /// </value>
      public bool IsCompleted
      {
        get => true;
        set
        {
        }
      }

      /// <summary>Gets the keys converter.</summary>
      private TypeConverter KeysConverter
      {
        get
        {
          if (this.mobjKeysConverter == null)
            this.mobjKeysConverter = TypeDescriptor.GetConverter(typeof (Keys));
          return this.mobjKeysConverter;
        }
      }
    }
  }
}
