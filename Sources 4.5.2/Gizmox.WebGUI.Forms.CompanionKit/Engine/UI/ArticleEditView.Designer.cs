namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ArticleEditView
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
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTxtCode = new Gizmox.WebGUI.Forms.TextBox();
			this.objCmdHelp = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// mobjButtonDelete
			// 
			this.mobjButtonDelete.Enabled = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(19, 552);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Article Code";
			// 
			// mobjTxtCode
			// 
			this.mobjTxtCode.Location = new System.Drawing.Point(97, 549);
			this.mobjTxtCode.Name = "textBox1";
			this.mobjTxtCode.Size = new System.Drawing.Size(192, 20);
			this.mobjTxtCode.TabIndex = 5;
			// 
			// objCmdHelp
			// 
			this.objCmdHelp.Location = new System.Drawing.Point(590, 547);
			this.objCmdHelp.Name = "button1";
			this.objCmdHelp.Size = new System.Drawing.Size(75, 23);
			this.objCmdHelp.TabIndex = 6;
			this.objCmdHelp.Tag = "articlecode";
			this.objCmdHelp.Text = "Help";
			this.objCmdHelp.UseVisualStyleBackColor = true;
			this.objCmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// ArticleEditView
			// 
			this.Controls.Add(this.objCmdHelp);
			this.Controls.Add(this.mobjTxtCode);
			this.Controls.Add(this.label1);
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Size = new System.Drawing.Size(678, 646);
			this.Text = "ArticleEditView";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.mobjTxtCode, 0);
			this.Controls.SetChildIndex(this.objCmdHelp, 0);
			this.Controls.SetChildIndex(this.mobjPanelContent, 0);
			this.ResumeLayout(false);

        }

        #endregion

		private Label label1;
		private TextBox mobjTxtCode;
		private Button objCmdHelp;


    }
}