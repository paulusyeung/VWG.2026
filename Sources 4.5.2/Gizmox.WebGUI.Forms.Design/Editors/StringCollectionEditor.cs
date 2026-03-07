namespace Gizmox.WebGUI.Forms.Design
{
    using System;
    using System.ComponentModel.Design;
    using System.Design;
    using System.Drawing;
    using System.Security.Permissions;
    using System.Windows.Forms;


    
	public class StringCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        // Methods
        public StringCollectionEditor(Type type) : base(type)
        {
        }

        protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()
        {
            return new StringCollectionForm(this);
        }


        // Properties
        protected override string HelpTopic
        {
            get
            {
                return "net.ComponentModel.StringCollectionEditor";
            }
        }


        // Nested Types
        
	    private class StringCollectionForm : System.ComponentModel.Design.CollectionEditor.CollectionForm
        {
            // Methods
            public StringCollectionForm(System.ComponentModel.Design.CollectionEditor editor)
                : base(editor)
            {
                this.instruction = new Label();
                this.textEntry = new TextBox();
                this.okButton = new Button();
                this.cancelButton = new Button();
                this.helpButton = new Button();
                this.editor = null;
                this.editor = (StringCollectionEditor) editor;
                this.InitializeComponent();
            }

            private void Edit1_keyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.cancelButton.PerformClick();
                    e.Handled = true;
                }
            }

            private void Form_HelpRequested(object sender, HelpEventArgs e)
            {
                this.editor.ShowHelp();
            }

            private void HelpButton_click(object sender, EventArgs e)
            {
                this.editor.ShowHelp();
            }

            private void InitializeComponent()
            {
                this.instruction.Location = new Point(4, 7);
                this.instruction.Size = new Size(0x1a6, 14);
                this.instruction.TabIndex = 0;
                this.instruction.TabStop = false;
                this.instruction.Text = SR.GetString("Instruction");
                this.textEntry.Location = new Point(4, 0x16);
                this.textEntry.Size = new Size(0x1a6, 0xf4);
                this.textEntry.TabIndex = 0;
                this.textEntry.Text = "";
                this.textEntry.AcceptsTab = true;
                this.textEntry.AcceptsReturn = true;
                this.textEntry.AutoSize = false;
                this.textEntry.Multiline = true;
                this.textEntry.ScrollBars = ScrollBars.Both;
                this.textEntry.WordWrap = false;
                this.textEntry.Anchor = AnchorStyles.Right | (AnchorStyles.Left | (AnchorStyles.Bottom | AnchorStyles.Top));
                this.textEntry.KeyDown += new KeyEventHandler(this.Edit1_keyDown);
                this.okButton.Location = new Point(0xb9, 0x112);
                this.okButton.Size = new Size(0x4b, 0x17);
                this.okButton.TabIndex = 1;
                this.okButton.Text = SR.GetString("Ok");
                this.okButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                this.okButton.DialogResult = DialogResult.OK;
                this.okButton.Click += new EventHandler(this.OKButton_click);
                this.cancelButton.Location = new Point(0x108, 0x112);
                this.cancelButton.Size = new Size(0x4b, 0x17);
                this.cancelButton.TabIndex = 2;
                this.cancelButton.Text = SR.GetString("Cancel");
                this.cancelButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                this.cancelButton.DialogResult = DialogResult.Cancel;
                this.helpButton.Location = new Point(0x157, 0x112);
                this.helpButton.Size = new Size(0x4b, 0x17);
                this.helpButton.TabIndex = 3;
                this.helpButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                this.helpButton.Text = SR.GetString("Help");
                base.Location = new Point(7, 7);
                this.Text = SR.GetString("StringCollectionEditorTitle");
                base.AcceptButton = this.okButton;
                this.AutoScaleBaseSize = new Size(5, 13);
                base.CancelButton = this.cancelButton;
                base.ClientSize = new Size(0x1ad, 0x133);
                base.MaximizeBox = false;
                base.MinimizeBox = false;
                base.ControlBox = false;
                base.ShowInTaskbar = false;
                base.StartPosition = FormStartPosition.CenterParent;
                base.MinimumSize = new Size(300, 200);
                this.helpButton.Click += new EventHandler(this.HelpButton_click);
                base.HelpRequested += new HelpEventHandler(this.Form_HelpRequested);
                base.Controls.Clear();
                Control[] controlArray1 = new Control[5] { this.instruction, this.textEntry, this.okButton, this.cancelButton, this.helpButton } ;
                base.Controls.AddRange(controlArray1);
            }

            private void OKButton_click(object sender, EventArgs e)
            {
                char[] chArray3 = new char[1] { '\n' } ;
                char[] chArray1 = chArray3;
                chArray3 = new char[1] { '\r' } ;
                char[] chArray2 = chArray3;
                string[] textArray1 = this.textEntry.Text.Split(chArray1);
                object[] objArray1 = base.Items;
                int num1 = textArray1.Length;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    textArray1[num2] = textArray1[num2].Trim(chArray2);
                }
                bool flag1 = true;
                if (num1 == objArray1.Length)
                {
                    int num3 = 0;
                    while (num3 < num1)
                    {
                        if (!textArray1[num3].Equals((string) objArray1[num3]))
                        {
                            break;
                        }
                        num3++;
                    }
                    if (num3 == num1)
                    {
                        flag1 = false;
                    }
                }
                if (!flag1)
                {
                    base.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    if ((textArray1.Length > 0) && (textArray1[textArray1.Length - 1].Length == 0))
                    {
                        num1--;
                    }
                    object[] objArray2 = new object[num1];
                    for (int num4 = 0; num4 < num1; num4++)
                    {
                        objArray2[num4] = textArray1[num4];
                    }
                    base.Items = objArray2;
                }
            }

            protected override void OnEditValueChanged()
            {
                object[] objArray1 = base.Items;
                string text1 = string.Empty;
                for (int num1 = 0; num1 < objArray1.Length; num1++)
                {
                    if (objArray1[num1] is string)
                    {
                        text1 = text1 + ((string) objArray1[num1]);
                        if (num1 != (objArray1.Length - 1))
                        {
                            text1 = text1 + "\r\n";
                        }
                    }
                }
                this.textEntry.Text = text1;
            }


            // Fields
            private Button cancelButton;
            private StringCollectionEditor editor;
            private Button helpButton;
            private Label instruction;
            private Button okButton;
            private TextBox textEntry;
        }

	


    }
}

