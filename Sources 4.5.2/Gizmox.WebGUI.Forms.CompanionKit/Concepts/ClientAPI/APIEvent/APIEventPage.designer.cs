namespace CompanionKit.Concepts.ClientAPI.APIEvent
{
    partial class APIEventPage
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
            this.objComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objComboBox
            // 
            this.objComboBox.ClientId = "combo";
            this.objComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.objComboBox.FormattingEnabled = true;
            this.objComboBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4",
            "Item5",
            "Item6"});
            this.objComboBox.Location = new System.Drawing.Point(11, 76);
            this.objComboBox.Name = "objComboBox";
            this.objComboBox.Size = new System.Drawing.Size(100, 21);
            this.objComboBox.TabIndex = 0;
            this.objComboBox.Text = "Item1";
            this.objComboBox.ClientSelectedIndexChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objComboBox_ClientSelectedIndexChanged);
            // 
            // objLabel
            // 
            this.objLabel.AutoSize = true;
            this.objLabel.ClientId = "label";
            this.objLabel.Location = new System.Drawing.Point(126, 79);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 2;
            this.objLabel.Text = "Index:<int>, Text:<string>";
            // 
            // ClientDOMEventPage
            // 
            this.ClientId = "form";
            this.Controls.Add(this.objLabel);
            this.Controls.Add(this.objComboBox);
            this.Size = new System.Drawing.Size(343, 182);
            this.Text = "ClientDOMEventPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox objComboBox;
        private Gizmox.WebGUI.Forms.Label objLabel;



    }
}