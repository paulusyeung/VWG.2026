using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public class SkinResourcesResetForm : Form
{
	private IContainer components = null;

	private Label mobjLabelDescription;

	private RadioButton mobjCheckBoxResetAll;

	private RadioButton mobjCheckBoxResetProperties;

	private RadioButton mobjCheckBoxResetResources;

	private Button mobjButtonOK;

	private Button mobjButtonCancel;

	public bool ResetProperties
	{
		get
		{
			if (!mobjCheckBoxResetProperties.Checked)
			{
				return mobjCheckBoxResetAll.Checked;
			}
			return true;
		}
	}

	public bool ResetResources
	{
		get
		{
			if (!mobjCheckBoxResetResources.Checked)
			{
				return mobjCheckBoxResetAll.Checked;
			}
			return true;
		}
	}

	public SkinResourcesResetForm()
	{
		InitializeComponent();
	}

	private void mobjButtonCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void mobjButtonOK_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.mobjLabelDescription = new System.Windows.Forms.Label();
		this.mobjCheckBoxResetAll = new System.Windows.Forms.RadioButton();
		this.mobjCheckBoxResetProperties = new System.Windows.Forms.RadioButton();
		this.mobjCheckBoxResetResources = new System.Windows.Forms.RadioButton();
		this.mobjButtonOK = new System.Windows.Forms.Button();
		this.mobjButtonCancel = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.mobjLabelDescription.AutoSize = true;
		this.mobjLabelDescription.Location = new System.Drawing.Point(23, 13);
		this.mobjLabelDescription.Name = "mobjLabelDescription";
		this.mobjLabelDescription.Size = new System.Drawing.Size(251, 13);
		this.mobjLabelDescription.TabIndex = 0;
		this.mobjLabelDescription.Text = "Choose the reset type you want to apply to the skin:";
		this.mobjCheckBoxResetAll.AutoSize = true;
		this.mobjCheckBoxResetAll.Location = new System.Drawing.Point(26, 41);
		this.mobjCheckBoxResetAll.Name = "mobjCheckBoxResetAll";
		this.mobjCheckBoxResetAll.Size = new System.Drawing.Size(172, 17);
		this.mobjCheckBoxResetAll.TabIndex = 1;
		this.mobjCheckBoxResetAll.TabStop = true;
		this.mobjCheckBoxResetAll.Text = "Reset resources and properties";
		this.mobjCheckBoxResetAll.UseVisualStyleBackColor = true;
		this.mobjCheckBoxResetProperties.AutoSize = true;
		this.mobjCheckBoxResetProperties.Location = new System.Drawing.Point(26, 65);
		this.mobjCheckBoxResetProperties.Name = "mobjCheckBoxResetProperties";
		this.mobjCheckBoxResetProperties.Size = new System.Drawing.Size(124, 17);
		this.mobjCheckBoxResetProperties.TabIndex = 2;
		this.mobjCheckBoxResetProperties.TabStop = true;
		this.mobjCheckBoxResetProperties.Text = "Reset properties only";
		this.mobjCheckBoxResetProperties.UseVisualStyleBackColor = true;
		this.mobjCheckBoxResetResources.AutoSize = true;
		this.mobjCheckBoxResetResources.Location = new System.Drawing.Point(26, 89);
		this.mobjCheckBoxResetResources.Name = "mobjCheckBoxResetResources";
		this.mobjCheckBoxResetResources.Size = new System.Drawing.Size(124, 17);
		this.mobjCheckBoxResetResources.TabIndex = 3;
		this.mobjCheckBoxResetResources.TabStop = true;
		this.mobjCheckBoxResetResources.Text = "Reset resources only";
		this.mobjCheckBoxResetResources.UseVisualStyleBackColor = true;
		this.mobjButtonOK.Location = new System.Drawing.Point(75, 134);
		this.mobjButtonOK.Name = "mobjButtonOK";
		this.mobjButtonOK.Size = new System.Drawing.Size(75, 23);
		this.mobjButtonOK.TabIndex = 4;
		this.mobjButtonOK.Text = "OK";
		this.mobjButtonOK.UseVisualStyleBackColor = true;
		this.mobjButtonOK.Click += new System.EventHandler(mobjButtonOK_Click);
		this.mobjButtonCancel.Location = new System.Drawing.Point(156, 134);
		this.mobjButtonCancel.Name = "mobjButtonCancel";
		this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
		this.mobjButtonCancel.TabIndex = 5;
		this.mobjButtonCancel.Text = "Cancel";
		this.mobjButtonCancel.UseVisualStyleBackColor = true;
		this.mobjButtonCancel.Click += new System.EventHandler(mobjButtonCancel_Click);
		base.AcceptButton = this.mobjButtonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.mobjButtonCancel;
		base.ClientSize = new System.Drawing.Size(305, 172);
		base.Controls.Add(this.mobjButtonCancel);
		base.Controls.Add(this.mobjButtonOK);
		base.Controls.Add(this.mobjCheckBoxResetResources);
		base.Controls.Add(this.mobjCheckBoxResetProperties);
		base.Controls.Add(this.mobjCheckBoxResetAll);
		base.Controls.Add(this.mobjLabelDescription);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SkinResourcesResetForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Skin Reset Type Selector";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
