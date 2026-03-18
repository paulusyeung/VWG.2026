using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

internal class BrowserCapabilitiesForm : Form
{
	private BrowserCapabilitiesUC browserCapabilitiesUC1;

	private BrowserCapabilitiesUC browserCapabilitiesUC2;

	private IContainer components = null;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Type mobjBrowserCapabilitiesType;

	public object BrowserCapabilities
	{
		get
		{
			if (mobjBrowserCapabilitiesType != null)
			{
				return Activator.CreateInstance(mobjBrowserCapabilitiesType, browserCapabilitiesUC1.BrowserCSS3Capabilities, browserCapabilitiesUC1.BrowserHTML5Capabilities, browserCapabilitiesUC1.BrowserMISCCapabilities, browserCapabilitiesUC2.BrowserCSS3Capabilities, browserCapabilitiesUC2.BrowserHTML5Capabilities, browserCapabilitiesUC2.BrowserMISCCapabilities);
			}
			return null;
		}
	}

	public BrowserCapabilitiesForm(object objBrowserCapabilities)
		: this()
	{
		if (objBrowserCapabilities != null)
		{
			browserCapabilitiesUC1.InitializeCapabilities(DocumentUtils.GetPropertyValue(objBrowserCapabilities, "RequiredBrowserCSS3Capabilities"), DocumentUtils.GetPropertyValue(objBrowserCapabilities, "RequiredBrowserHTML5Capabilities"), DocumentUtils.GetPropertyValue(objBrowserCapabilities, "RequiredBrowserMISCCapabilities"));
			browserCapabilitiesUC2.InitializeCapabilities(DocumentUtils.GetPropertyValue(objBrowserCapabilities, "ForbiddenBrowserCSS3Capabilities"), DocumentUtils.GetPropertyValue(objBrowserCapabilities, "ForbiddenBrowserHTML5Capabilities"), DocumentUtils.GetPropertyValue(objBrowserCapabilities, "ForbiddenBrowserMISCCapabilities"));
			mobjBrowserCapabilitiesType = objBrowserCapabilities.GetType();
		}
	}

	public BrowserCapabilitiesForm()
	{
		InitializeComponent();
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.browserCapabilitiesUC1 = new Gizmox.WebGUI.Common.Design.Skins.Editors.BrowserCapabilitiesUC();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.browserCapabilitiesUC2 = new Gizmox.WebGUI.Common.Design.Skins.Editors.BrowserCapabilitiesUC();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.browserCapabilitiesUC1);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
		this.groupBox1.Location = new System.Drawing.Point(5, 5);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(390, 270);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Required Capabilities";
		this.groupBox1.ForeColor = System.Drawing.Color.Blue;
		this.browserCapabilitiesUC1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.browserCapabilitiesUC1.Location = new System.Drawing.Point(3, 16);
		this.browserCapabilitiesUC1.Name = "browserCapabilitiesUC1";
		this.browserCapabilitiesUC1.Size = new System.Drawing.Size(384, 251);
		this.browserCapabilitiesUC1.TabIndex = 0;
		this.groupBox2.Controls.Add(this.browserCapabilitiesUC2);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(5, 275);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(390, 268);
		this.groupBox2.TabIndex = 1;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Forbidden Capabilities";
		this.groupBox2.ForeColor = System.Drawing.Color.Blue;
		this.browserCapabilitiesUC2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.browserCapabilitiesUC2.Location = new System.Drawing.Point(3, 16);
		this.browserCapabilitiesUC2.Name = "browserCapabilitiesUC2";
		this.browserCapabilitiesUC2.Size = new System.Drawing.Size(384, 249);
		this.browserCapabilitiesUC2.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(400, 548);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Name = "BrowserCapabilitiesForm";
		base.Padding = new System.Windows.Forms.Padding(5);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(BrowserCapabilitiesFormClosed);
		this.Text = "Browser Capabilities Editor";
		this.groupBox1.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void BrowserCapabilitiesFormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	internal bool IsConfiflictingCapability(object objCapability, BrowserCapabilitiesUC objBrowserCapabilitiesUC)
	{
		bool result = false;
		if (objCapability != null && objBrowserCapabilitiesUC != null)
		{
			objBrowserCapabilitiesUC = ((objBrowserCapabilitiesUC != browserCapabilitiesUC1) ? browserCapabilitiesUC1 : browserCapabilitiesUC2);
			Type type = objCapability.GetType();
			int num = Convert.ToInt32(objCapability);
			switch (type.Name)
			{
			case "CSS3BrowserCapabilities":
				result = (objBrowserCapabilitiesUC.BrowserCSS3Capabilities & num) != 0;
				break;
			case "HTML5BrowserCapabilities":
				result = (objBrowserCapabilitiesUC.BrowserHTML5Capabilities & num) != 0;
				break;
			case "MISCBrowserCapabilities":
				result = (objBrowserCapabilitiesUC.BrowserMISCCapabilities & num) != 0;
				break;
			}
		}
		return result;
	}
}
