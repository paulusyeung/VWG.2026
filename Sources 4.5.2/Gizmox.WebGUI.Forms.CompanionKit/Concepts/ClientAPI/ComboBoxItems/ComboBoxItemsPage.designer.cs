namespace CompanionKit.Concepts.ClientAPI.ComboBoxItems
{
    partial class ComboBoxItemsPage
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
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjNewItemLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNewItemTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSelectedIndexLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.ClientId = "cb";
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Location = new System.Drawing.Point(72, 26);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(175, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.ClientSelectedIndexChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjComboBox_ClientSelectedIndexChanged);
            // 
            // mobjNewItemLabel
            // 
            this.mobjNewItemLabel.AutoSize = true;
            this.mobjNewItemLabel.Location = new System.Drawing.Point(26, 96);
            this.mobjNewItemLabel.Name = "mobjNewItemLabel";
            this.mobjNewItemLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjNewItemLabel.TabIndex = 1;
            this.mobjNewItemLabel.Text = "New item text:";
            // 
            // mobjNewItemTextBox
            // 
            this.mobjNewItemTextBox.AllowDrag = false;
            this.mobjNewItemTextBox.ClientId = "tb";
            this.mobjNewItemTextBox.Location = new System.Drawing.Point(180, 93);
            this.mobjNewItemTextBox.Name = "mobjNewItemTextBox";
            this.mobjNewItemTextBox.Size = new System.Drawing.Size(114, 20);
            this.mobjNewItemTextBox.TabIndex = 2;
            this.mobjNewItemTextBox.Text = "item4";
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.ClientId = "btnAdd";
            this.mobjAddButton.Location = new System.Drawing.Point(224, 130);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(70, 23);
            this.mobjAddButton.TabIndex = 3;
            this.mobjAddButton.Text = "Add";
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjRemoveButton
            // 
            this.mobjRemoveButton.ClientId = "btnRemove";
            this.mobjRemoveButton.Location = new System.Drawing.Point(224, 166);
            this.mobjRemoveButton.Name = "mobjRemoveButton";
            this.mobjRemoveButton.Size = new System.Drawing.Size(70, 23);
            this.mobjRemoveButton.TabIndex = 4;
            this.mobjRemoveButton.Text = "Remove";
            this.mobjRemoveButton.Click += new System.EventHandler(this.mobjRemoveButton_Click);
            // 
            // mobjSelectedIndexLabel
            // 
            this.mobjSelectedIndexLabel.AutoSize = true;
            this.mobjSelectedIndexLabel.ClientId = "lblSelectedIndex";
            this.mobjSelectedIndexLabel.Location = new System.Drawing.Point(26, 171);
            this.mobjSelectedIndexLabel.Name = "mobjSelectedIndexLabel";
            this.mobjSelectedIndexLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjSelectedIndexLabel.TabIndex = 5;
            this.mobjSelectedIndexLabel.Text = "Selected index: 0";
            // 
            // ComboBoxItemsPage
            // 
            this.ClientId = "uc";
            this.Controls.Add(this.mobjSelectedIndexLabel);
            this.Controls.Add(this.mobjRemoveButton);
            this.Controls.Add(this.mobjAddButton);
            this.Controls.Add(this.mobjNewItemTextBox);
            this.Controls.Add(this.mobjNewItemLabel);
            this.Controls.Add(this.mobjComboBox);
            this.Size = new System.Drawing.Size(392, 306);
            this.Text = "ComboBoxItemsPage";
            this.ResumeLayout(false);

        }       
        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjNewItemLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjNewItemTextBox;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveButton;
        private Gizmox.WebGUI.Forms.Label mobjSelectedIndexLabel;

        
    }
}