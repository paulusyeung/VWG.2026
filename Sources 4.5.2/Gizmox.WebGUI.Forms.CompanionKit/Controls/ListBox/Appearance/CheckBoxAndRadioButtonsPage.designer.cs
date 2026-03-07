namespace CompanionKit.Controls.ListBox.Appearance
{
    partial class CheckBoxAndRadioButtonsPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.radioButtonViewRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.checkBoxViewRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.normalViewRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjDescritionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "A item",
            "B item",
            "C item",
            "D item",
            "E item",
            "F item",
            "G item",
            "I item",
            "J item",
            "K item",
            "L item",
            "M item",
            "N item",
            "O item",
            "P item",
            "Q item",
            "R item",
            "S item",
            "T item",
            "U item",
            "V item",
            "W item",
            "X item",
            "Y item",
            "Z item"});
            this.mobjListBox.Location = new System.Drawing.Point(0, 42);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 186);
            this.mobjListBox.TabIndex = 0;
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.radioButtonViewRadioButton);
            this.mobjGroupBox.Controls.Add(this.checkBoxViewRadioButton);
            this.mobjGroupBox.Controls.Add(this.normalViewRadioButton);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 231);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(320, 189);
            this.mobjGroupBox.TabIndex = 1;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Change listbox items view";
            // 
            // radioButtonViewRadioButton
            // 
            this.radioButtonViewRadioButton.Location = new System.Drawing.Point(19, 114);
            this.radioButtonViewRadioButton.Name = "radioButton3";
            this.radioButtonViewRadioButton.Size = new System.Drawing.Size(165, 31);
            this.radioButtonViewRadioButton.TabIndex = 2;
            this.radioButtonViewRadioButton.Text = "RadioButton";
            this.radioButtonViewRadioButton.UseVisualStyleBackColor = true;
            this.radioButtonViewRadioButton.CheckedChanged += new System.EventHandler(this.radioButtonViewRadioButton_CheckedChanged);
            // 
            // checkBoxViewRadioButton
            // 
            this.checkBoxViewRadioButton.Location = new System.Drawing.Point(20, 76);
            this.checkBoxViewRadioButton.Name = "radioButton2";
            this.checkBoxViewRadioButton.Size = new System.Drawing.Size(164, 31);
            this.checkBoxViewRadioButton.TabIndex = 1;
            this.checkBoxViewRadioButton.Text = "CheckBox";
            this.checkBoxViewRadioButton.UseVisualStyleBackColor = true;
            this.checkBoxViewRadioButton.CheckedChanged += new System.EventHandler(this.checkBoxViewRadioButton_CheckedChanged);
            // 
            // normalViewRadioButton
            // 
            this.normalViewRadioButton.Checked = true;
            this.normalViewRadioButton.Location = new System.Drawing.Point(20, 38);
            this.normalViewRadioButton.Name = "radioButton1";
            this.normalViewRadioButton.Size = new System.Drawing.Size(164, 31);
            this.normalViewRadioButton.TabIndex = 0;
            this.normalViewRadioButton.Text = "Normal";
            this.normalViewRadioButton.UseVisualStyleBackColor = true;
            this.normalViewRadioButton.CheckedChanged += new System.EventHandler(this.normalViewRadioButton_CheckedChanged);
            // 
            // mobjDescritionLabel
            // 
            this.mobjDescritionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescritionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescritionLabel.Name = "mobjDescritionLabel";
            this.mobjDescritionLabel.Size = new System.Drawing.Size(320, 42);
            this.mobjDescritionLabel.TabIndex = 2;
            this.mobjDescritionLabel.Text = "Listbox with items:";
            this.mobjDescritionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjDescritionLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjGroupBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjListBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 420);
            this.mobjTLP.TabIndex = 3;
            // 
            // CheckBoxAndRadioButtonsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 420);
            this.Text = "CheckBoxAndRadioButtonsPage";
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton checkBoxViewRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton normalViewRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton radioButtonViewRadioButton;
        private Gizmox.WebGUI.Forms.Label mobjDescritionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
