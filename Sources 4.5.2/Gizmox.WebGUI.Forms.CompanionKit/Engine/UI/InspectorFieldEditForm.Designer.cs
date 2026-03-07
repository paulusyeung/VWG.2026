namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class InspectorFieldEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTextProperty = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTextTarget = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjComboType = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjNumericColumn = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjButtonOk = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
            this.mobjNumericOrder = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Property:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Target:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Column:";
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTextLabel.Location = new System.Drawing.Point(84, 30);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Size = new System.Drawing.Size(264, 20);
            this.mobjTextLabel.TabIndex = 1;
            // 
            // mobjTextProperty
            // 
            this.mobjTextProperty.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTextProperty.Location = new System.Drawing.Point(84, 94);
            this.mobjTextProperty.Name = "mobjTextProperty";
            this.mobjTextProperty.Size = new System.Drawing.Size(154, 20);
            this.mobjTextProperty.TabIndex = 5;
            // 
            // mobjTextTarget
            // 
            this.mobjTextTarget.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTextTarget.Location = new System.Drawing.Point(84, 127);
            this.mobjTextTarget.Name = "mobjTextTarget";
            this.mobjTextTarget.Size = new System.Drawing.Size(154, 20);
            this.mobjTextTarget.TabIndex = 7;
            // 
            // mobjComboType
            // 
            this.mobjComboType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboType.Location = new System.Drawing.Point(84, 62);
            this.mobjComboType.MaxDropDownItems = 8;
            this.mobjComboType.Name = "mobjComboType";
            this.mobjComboType.Size = new System.Drawing.Size(154, 21);
            this.mobjComboType.TabIndex = 3;
            // 
            // mobjNumericColumn
            // 
            this.mobjNumericColumn.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjNumericColumn.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNumericColumn.CurrentValueChanged = false;
            this.mobjNumericColumn.Location = new System.Drawing.Point(84, 158);
            this.mobjNumericColumn.Name = "mobjNumericColumn";
            this.mobjNumericColumn.Size = new System.Drawing.Size(57, 20);
            this.mobjNumericColumn.TabIndex = 9;
            this.mobjNumericColumn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.mobjNumericColumn.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // mobjButtonOk
            // 
            this.mobjButtonOk.Location = new System.Drawing.Point(204, 237);
            this.mobjButtonOk.Name = "mobjButtonOk";
            this.mobjButtonOk.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonOk.TabIndex = 12;
            this.mobjButtonOk.Text = "Ok";
            this.mobjButtonOk.UseVisualStyleBackColor = true;
            this.mobjButtonOk.Click += new System.EventHandler(this.mobjButtonOk_Click);
            // 
            // mobjButtonCancel
            // 
            this.mobjButtonCancel.Location = new System.Drawing.Point(285, 237);
            this.mobjButtonCancel.Name = "mobjButtonCancel";
            this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonCancel.TabIndex = 13;
            this.mobjButtonCancel.Text = "Cancel";
            this.mobjButtonCancel.UseVisualStyleBackColor = true;
            this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
            // 
            // mobjNumericOrder
            // 
            this.mobjNumericOrder.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjNumericOrder.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNumericOrder.CurrentValueChanged = false;
            this.mobjNumericOrder.Location = new System.Drawing.Point(84, 189);
            this.mobjNumericOrder.Name = "mobjNumericOrder";
            this.mobjNumericOrder.Size = new System.Drawing.Size(57, 20);
            this.mobjNumericOrder.TabIndex = 11;
            this.mobjNumericOrder.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.mobjNumericOrder.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Order:";
            // 
            // InspectorFieldEditForm
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mobjNumericOrder);
            this.Controls.Add(this.mobjButtonCancel);
            this.Controls.Add(this.mobjButtonOk);
            this.Controls.Add(this.mobjNumericColumn);
            this.Controls.Add(this.mobjComboType);
            this.Controls.Add(this.mobjTextTarget);
            this.Controls.Add(this.mobjTextProperty);
            this.Controls.Add(this.mobjTextLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(372, 272);
            this.Text = "Inspector Field Editor";
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox mobjTextLabel;
        private TextBox mobjTextProperty;
        private TextBox mobjTextTarget;
        private ComboBox mobjComboType;
        private NumericUpDown mobjNumericColumn;
        private Button mobjButtonOk;
        private Button mobjButtonCancel;
        private NumericUpDown mobjNumericOrder;
        private Label label6;


    }
}