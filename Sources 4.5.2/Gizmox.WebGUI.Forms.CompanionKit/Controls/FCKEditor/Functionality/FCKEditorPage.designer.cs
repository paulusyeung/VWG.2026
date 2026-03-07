namespace CompanionKit.Controls.FCKEditor
{
    partial class FCKEditorPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFCKEditor = new Gizmox.WebGUI.Forms.Extended.FCKEditor();
            this.mobjSendButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(669, 55);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Click button to send FCKEditor Value to RichTextBox:";
            // 
            // mobjFCKEditor
            // 
            this.mobjFCKEditor.BasePath = "../../../../../../../../FCKEditor/";
            this.mobjFCKEditor.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFCKEditor.Location = new System.Drawing.Point(0, 55);
            this.mobjFCKEditor.Name = "mobjFCKEditor";
            this.mobjFCKEditor.Size = new System.Drawing.Size(669, 210);
            this.mobjFCKEditor.TabIndex = 2;
            this.mobjFCKEditor.Value = "This is text...";
            // 
            // mobjSendButton
            // 
            this.mobjSendButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSendButton.Location = new System.Drawing.Point(0, 293);
            this.mobjSendButton.Name = "mobjSendButton";
            this.mobjSendButton.Size = new System.Drawing.Size(669, 34);
            this.mobjSendButton.TabIndex = 3;
            this.mobjSendButton.Text = "Send";
            this.mobjSendButton.Click += new System.EventHandler(this.mobjSendButton_Click);
            // 
            // mobjRichTextBox
            // 
            this.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjRichTextBox.Location = new System.Drawing.Point(0, 327);
            this.mobjRichTextBox.Name = "mobjRichTextBox";
            this.mobjRichTextBox.Size = new System.Drawing.Size(669, 117);
            this.mobjRichTextBox.TabIndex = 4;

            // 
            // FCKEditorPage
            // 
            this.Controls.Add(this.mobjRichTextBox);
            this.Controls.Add(this.mobjSendButton);
            this.Controls.Add(this.mobjFCKEditor);
            this.Controls.Add(this.mobjInfoLabel);
            this.Size = new System.Drawing.Size(391, 466);
            this.Text = "FCKEditorPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Extended.FCKEditor mobjFCKEditor;
        private Gizmox.WebGUI.Forms.Button mobjSendButton;
        private Gizmox.WebGUI.Forms.RichTextBox mobjRichTextBox;

    }
}