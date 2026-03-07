
using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design
{

    /// <summary>
    /// Provides a user interface for specifying a ShortcutKeys property.
    /// </summary>
    [Serializable()]
    public class ShortcutKeysEditor : WebUITypeEditor
    {
        private Keys menmPropertyValue = Keys.None;
        private WebUITypeEditorHandler mobjHandler = null;

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Create font dialog
            ShortcutKeysUI objShortcutKeysUI = new ShortcutKeysUI();
            objShortcutKeysUI.ShortcutKeys = (Keys)GetEditorValueFromPropertyValue(objValue);
            objShortcutKeysUI.Closed += new EventHandler(objShortcutKeysUI_Closed);

            // Store the property value
            menmPropertyValue = objShortcutKeysUI.ShortcutKeys;

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDropDown(objShortcutKeysUI);
            }
        }

        /// <summary>
        /// Handles the Closed event of the objShortcutKeysUI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void objShortcutKeysUI_Closed(object sender, EventArgs e)
        {
            ShortcutKeysUI objShortcutKeysUI = (ShortcutKeysUI)sender;
            if (objShortcutKeysUI.IsCompleted)
            {
                if (mobjHandler != null)
                {
                    object objValue = null;
                    try
                    {
                        objValue = GetPropertyValueFromEditorValue(objShortcutKeysUI.ShortcutKeys);
                    }
                    catch (Exception objException)
                    {
                        this.OnValueChangeError(objException);
                        return;
                    }

                    mobjHandler(objValue);
                }
            }
        }

        /// <summary>
        /// Gets the edit style.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        private class ShortcutKeysUI : Form
        {
            private Label mobjLabelmodifiers;
            private CheckBox mobjCheckBoxCtrl;
            private CheckBox mobjCheckBoxShift;
            private CheckBox mobjCheckBoxAlt;
            private Label mobjLabelKeys;
            private ComboBox mobjComboBoxKeys;
            private Button mobjButtonReset;

            private TypeConverter mobjKeysConverter = null;
            private static Keys[] validKeys = new Keys[] { 
                Keys.A, Keys.B, Keys.C, Keys.D, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.Delete, Keys.Down, 
                Keys.E, Keys.End, Keys.F, Keys.F1, Keys.F10, Keys.F11, Keys.F12, Keys.F13, Keys.F14, Keys.F15, Keys.F16, Keys.F17, Keys.F18, Keys.F19, Keys.F2, Keys.F20, 
                Keys.F21, Keys.F22, Keys.F23, Keys.F24, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.G, Keys.H, Keys.I, Keys.Insert, Keys.J, 
                Keys.K, Keys.L, Keys.Left, Keys.M, Keys.N, Keys.NumLock, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, 
                Keys.O, Keys.OemBackslash, Keys.OemClear, Keys.OemCloseBrackets, Keys.Oemcomma, Keys.OemMinus, Keys.OemOpenBrackets, Keys.OemPeriod, Keys.OemPipe, Keys.Oemplus, Keys.OemQuestion, Keys.OemQuotes, Keys.OemSemicolon, Keys.Oemtilde, Keys.P, Keys.Pause, 
                Keys.Q, Keys.R, Keys.Right, Keys.S, Keys.Space, Keys.T, Keys.Tab, Keys.U, Keys.Up, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z
             };

            private Keys menmValue = Keys.None;

            /// <summary>
            /// Initializes a new instance of the <see cref="ShortcutKeysUI"/> class.
            /// </summary>
            public ShortcutKeysUI()
            {
                this.InitializeComponent();

                foreach (Keys keys in validKeys)
                {
                    this.mobjComboBoxKeys.Items.Add(this.KeysConverter.ConvertToString(keys));
                }
            }

            /// <summary>
            /// Updates the value.
            /// </summary>
            private void UpdateUI()
            {
                Keys enmValue = menmValue;
                if (enmValue != Keys.None)
                {
                    mobjCheckBoxCtrl.Checked = (enmValue & Keys.Control) != Keys.None;
                    mobjCheckBoxAlt.Checked = (enmValue & Keys.Alt) != Keys.None;
                    mobjCheckBoxShift.Checked = (enmValue & Keys.Shift) != Keys.None;

                    Keys keyCode = enmValue & Keys.KeyCode;
                    this.mobjComboBoxKeys.SelectedItem = this.KeysConverter.ConvertToString(keyCode);
                }
            }

            #region InitializeComponent

            /// <summary>
            /// Initializes the component.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjLabelmodifiers = new Gizmox.WebGUI.Forms.Label();
                this.mobjCheckBoxCtrl = new Gizmox.WebGUI.Forms.CheckBox();
                this.mobjCheckBoxShift = new Gizmox.WebGUI.Forms.CheckBox();
                this.mobjCheckBoxAlt = new Gizmox.WebGUI.Forms.CheckBox();
                this.mobjLabelKeys = new Gizmox.WebGUI.Forms.Label();
                this.mobjComboBoxKeys = new Gizmox.WebGUI.Forms.ComboBox();
                this.mobjButtonReset = new Gizmox.WebGUI.Forms.Button();
                this.SuspendLayout();
                // 
                // mobjLabelmodifiers
                // 
                this.mobjLabelmodifiers.AutoSize = true;
                this.mobjLabelmodifiers.Location = new System.Drawing.Point(10, 10);
                this.mobjLabelmodifiers.Name = "mobjLabelmodifiers";
                this.mobjLabelmodifiers.Size = new System.Drawing.Size(35, 13);
                this.mobjLabelmodifiers.TabIndex = 0;
                this.mobjLabelmodifiers.Text = WGLabels.ModifiersColon;
                // 
                // mobjCheckBoxCtrl
                // 
                this.mobjCheckBoxCtrl.AutoSize = true;
                this.mobjCheckBoxCtrl.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
                this.mobjCheckBoxCtrl.Location = new System.Drawing.Point(20, 40);
                this.mobjCheckBoxCtrl.Name = "mobjCheckBoxCtrl";
                this.mobjCheckBoxCtrl.Size = new System.Drawing.Size(43, 17);
                this.mobjCheckBoxCtrl.TabIndex = 1;
                this.mobjCheckBoxCtrl.Text = "Ctrl";
                // 
                // mobjCheckBoxShift
                // 
                this.mobjCheckBoxShift.AutoSize = true;
                this.mobjCheckBoxShift.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
                this.mobjCheckBoxShift.Location = new System.Drawing.Point(71, 40);
                this.mobjCheckBoxShift.Name = "mobjCheckBoxShift";
                this.mobjCheckBoxShift.Size = new System.Drawing.Size(48, 17);
                this.mobjCheckBoxShift.TabIndex = 2;
                this.mobjCheckBoxShift.Text = "Shift";
                // 
                // mobjCheckBoxAlt
                // 
                this.mobjCheckBoxAlt.AutoSize = true;
                this.mobjCheckBoxAlt.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
                this.mobjCheckBoxAlt.Location = new System.Drawing.Point(129, 40);
                this.mobjCheckBoxAlt.Name = "mobjCheckBoxAlt";
                this.mobjCheckBoxAlt.Size = new System.Drawing.Size(39, 17);
                this.mobjCheckBoxAlt.TabIndex = 3;
                this.mobjCheckBoxAlt.Text = "Alt";
                // 
                // mobjLabelKeys
                // 
                this.mobjLabelKeys.AutoSize = true;
                this.mobjLabelKeys.Location = new System.Drawing.Point(13, 70);
                this.mobjLabelKeys.Name = "mobjLabelKeys";
                this.mobjLabelKeys.Size = new System.Drawing.Size(35, 13);
                this.mobjLabelKeys.TabIndex = 4;
                this.mobjLabelKeys.Text = WGLabels.KeysColon;
                // 
                // mobjComboBoxKeys
                // 
                this.mobjComboBoxKeys.AllowDrag = false;
                this.mobjComboBoxKeys.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
                this.mobjComboBoxKeys.FormattingEnabled = true;
                this.mobjComboBoxKeys.Location = new System.Drawing.Point(20, 100);
                this.mobjComboBoxKeys.Name = "mobjComboBoxKeys";
                this.mobjComboBoxKeys.Size = new System.Drawing.Size(148, 21);
                this.mobjComboBoxKeys.TabIndex = 5;
                // 
                // mobjButtonReset
                // 
                this.mobjButtonReset.AutoSize = true;
                this.mobjButtonReset.AutoSizeMode = Gizmox.WebGUI.Forms.AutoSizeMode.GrowAndShrink;
                this.mobjButtonReset.Location = new System.Drawing.Point(182, 100);
                this.mobjButtonReset.Name = "mobjButtonReset";
                this.mobjButtonReset.Size = new System.Drawing.Size(75, 23);
                this.mobjButtonReset.TabIndex = 6;
                this.mobjButtonReset.Text = WGLabels.Reset;
                this.mobjButtonReset.Click += new System.EventHandler(this.mobjButtonReset_Click);
                // 
                // ShortcutKeysUI
                // 
                this.Controls.Add(this.mobjButtonReset);
                this.Controls.Add(this.mobjComboBoxKeys);
                this.Controls.Add(this.mobjLabelKeys);
                this.Controls.Add(this.mobjCheckBoxAlt);
                this.Controls.Add(this.mobjCheckBoxShift);
                this.Controls.Add(this.mobjCheckBoxCtrl);
                this.Controls.Add(this.mobjLabelmodifiers);
                this.Size = new System.Drawing.Size(240, 140);
                this.Text = "";
                this.ResumeLayout(false);

            }

            #endregion            

            /// <summary>
            /// Handles the Click event of the mobjButtonReset control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void mobjButtonReset_Click(object sender, EventArgs e)
            {
                this.mobjCheckBoxCtrl.Checked = false;
                this.mobjCheckBoxAlt.Checked = false;
                this.mobjCheckBoxShift.Checked = false;
                this.mobjComboBoxKeys.SelectedIndex = -1;
            }

            /// <summary>
            /// Updates the current value.
            /// </summary>
            private void UpdateCurrentValue()
            {
                menmValue = Keys.None;

                if (mobjComboBoxKeys.SelectedIndex > -1)
                {
                    menmValue = validKeys[mobjComboBoxKeys.SelectedIndex];

                    if (mobjCheckBoxCtrl.Checked)
                    {
                        menmValue |= Keys.Control;
                    }
                    if (mobjCheckBoxAlt.Checked)
                    {
                        menmValue |= Keys.Alt;
                    }
                    if (mobjCheckBoxShift.Checked)
                    {
                        menmValue |= Keys.Shift;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the shortcut keys.
            /// </summary>
            /// <value>
            /// The shortcut keys.
            /// </value>
            public Keys ShortcutKeys
            {
                get
                {
                    UpdateCurrentValue();

                    return menmValue;
                }
                set
                {
                    menmValue = value;
                    UpdateUI();
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
                get
                {
                    return true;
                }
                set
                {
                }
            }

            /// <summary>
            /// Gets the keys converter.
            /// </summary>
            private TypeConverter KeysConverter
            {
                get
                {
                    if (mobjKeysConverter == null)
                    {
                        mobjKeysConverter = TypeDescriptor.GetConverter(typeof(Keys));
                    }
                    
                    return mobjKeysConverter;
                }
            }
        }
    }
}
