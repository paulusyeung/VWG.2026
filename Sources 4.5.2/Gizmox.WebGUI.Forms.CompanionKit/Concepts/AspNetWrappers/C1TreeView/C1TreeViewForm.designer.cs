namespace ComponentOneSampleAppsCS
{
    partial class C1TreeViewForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C1TreeViewForm));
            this.mobjWrapper = new CompanionKit.Concepts.AspNetWrappers.C1TreeView.C1TreeViewWrapper();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWrapper
            // 
            this.mobjTLP.SetColumnSpan(this.mobjWrapper, 2);
            this.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode");
            this.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapper.Location = new System.Drawing.Point(0, 71);
            this.mobjWrapper.Name = "mobjWrapper";
            this.mobjWrapper.Size = new System.Drawing.Size(753, 310);
            this.mobjWrapper.TabIndex = 1;
            this.mobjWrapper.SelectedNodesChanged += new C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler(this.mobjWrapper_SelectedNodesChanged);
            this.mobjWrapper.NodeCheckChanged += new C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler(mobjWrapper_NodeCheckChanged);
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox.Location = new System.Drawing.Point(113, 404);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(150, 50);
            this.mobjCheckBox.TabIndex = 1;
            this.mobjCheckBox.Checked = true;
            this.mobjCheckBox.Text = "Show Check Boxes";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjWrapper, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjLabel, 1, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(753, 478);
            this.mobjTLP.TabIndex = 2;
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(753, 71);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 TreeView:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(376, 381);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(377, 97);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Selected Nodes";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeViewWrapperPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(753, 600);
            this.Text = "TrteeViewWrapperPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private C1TreeViewWrapper mobjWrapper;
    }
}