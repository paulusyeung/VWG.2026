using Gizmox.WebGUI.Forms;
namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
    partial class C1GridViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C1GridViewForm));
            this.mobjWrapper = new C1GridViewWrapper();
            this.mobjSelectedPageIndex = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjShowFilterRow = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjAllowPaging = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjGridViewWrapper
            // 
            this.mobjTLP.SetColumnSpan(this.mobjWrapper, 2);
            this.mobjWrapper.ControlCode = resources.GetString("mobjGridViewWrapper.ControlCode");
            this.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapper.Location = new System.Drawing.Point(0, 74);
            this.mobjWrapper.Name = "mobjGridViewWrapper";
            this.mobjWrapper.Size = new System.Drawing.Size(997, 273);
            this.mobjWrapper.TabIndex = 0;
            this.mobjWrapper.PageIndexChanged += new System.EventHandler(this.mobjGridViewWrapper_PageIndexChanged);
            this.mobjWrapper.Sorted += new System.EventHandler(mobjGridViewWrapper_Sorted);
            this.mobjWrapper.Filtered += new System.EventHandler(mobjGridViewWrapper_Sorted);
            // 
            // mobjSelectedPageIndex
            // 
            this.mobjSelectedPageIndex.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedPageIndex.Location = new System.Drawing.Point(498, 421);
            this.mobjSelectedPageIndex.Name = "mobjSelectedPageIndex";
            this.mobjSelectedPageIndex.Size = new System.Drawing.Size(499, 76);
            this.mobjSelectedPageIndex.TabIndex = 2;
            this.mobjSelectedPageIndex.Text = "Selected Page Index: ";
            this.mobjSelectedPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjSelectedPageIndex, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjWrapper, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjNUD, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjShowFilterRow, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjAllowPaging, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(997, 497);
            this.mobjTLP.TabIndex = 3;
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(997, 74);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 GridView:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjNUD
            // 
            this.mobjNUD.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNUD.Location = new System.Drawing.Point(508, 373);
            this.mobjNUD.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjNUD.Name = "mobjNUD";
            this.mobjNUD.Size = new System.Drawing.Size(479, 17);
            this.mobjNUD.TabIndex = 0;
            this.mobjNUD.Minimum = 1;
            this.mobjNUD.ValueChanged += new System.EventHandler(this.mobjNUD_ValueChanged);
            // 
            // mobjShowFilterRow
            // 
            this.mobjShowFilterRow.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjShowFilterRow.Checked = true;
            this.mobjShowFilterRow.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjShowFilterRow.Location = new System.Drawing.Point(10, 372);
            this.mobjShowFilterRow.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjShowFilterRow.Name = "mobjShowFilterRow";
            this.mobjShowFilterRow.Size = new System.Drawing.Size(478, 23);
            this.mobjShowFilterRow.TabIndex = 0;
            this.mobjShowFilterRow.Text = "Show Filter Row";
            this.mobjShowFilterRow.CheckedChanged += new System.EventHandler(this.mobjShowFilterRow_CheckedChanged);
            // 
            // mobjAllowPaging
            // 
            this.mobjAllowPaging.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjAllowPaging.Checked = true;
            this.mobjAllowPaging.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjAllowPaging.Location = new System.Drawing.Point(10, 447);
            this.mobjAllowPaging.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjAllowPaging.Name = "mobjAllowPaging";
            this.mobjAllowPaging.Size = new System.Drawing.Size(478, 23);
            this.mobjAllowPaging.TabIndex = 0;
            this.mobjAllowPaging.Text = "Allow Paging";
            this.mobjAllowPaging.CheckedChanged += new System.EventHandler(this.mobjAllowPaging_CheckedChanged);
            // 
            // C1GridViewPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Load += new System.EventHandler(this.Page_Load);
            this.Size = new System.Drawing.Size(391, 600);
            this.Text = "C1GridViewPage";
            this.mobjTLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1GridViewWrapper mobjWrapper;
        private Label mobjSelectedPageIndex;
        private TableLayoutPanel mobjTLP;
        private Label mobjInfoLabel;
        private NumericUpDown mobjNUD;
        private CheckBox mobjShowFilterRow;
        private CheckBox mobjAllowPaging;

    }
}