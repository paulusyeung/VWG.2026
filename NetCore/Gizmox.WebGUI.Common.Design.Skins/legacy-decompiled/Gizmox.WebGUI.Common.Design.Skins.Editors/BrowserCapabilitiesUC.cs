using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

internal class BrowserCapabilitiesUC : UserControl
{
	private CheckedListBox checkedListBox1;

	private CheckedListBox checkedListBox2;

	private CheckedListBox checkedListBox3;

	private IContainer components = null;

	private Label label1;

	private Label label2;

	private Label label3;

	private Type mobjBrowserCapabilities_CSS3Type;

	private Type mobjBrowserCapabilities_HTML5Type;

	private Type mobjBrowserCapabilities_MISCType;

	public int BrowserCSS3Capabilities => GetCheckedListBoxValue(checkedListBox1, mobjBrowserCapabilities_CSS3Type);

	public int BrowserHTML5Capabilities => GetCheckedListBoxValue(checkedListBox2, mobjBrowserCapabilities_HTML5Type);

	public int BrowserMISCCapabilities => GetCheckedListBoxValue(checkedListBox3, mobjBrowserCapabilities_MISCType);

	public BrowserCapabilitiesUC()
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

	private void FillCheckedListBox(CheckedListBox objCheckedListBox, Type objEnumType)
	{
		if (objCheckedListBox == null || !(objEnumType != null))
		{
			return;
		}
		foreach (object value in Enum.GetValues(objEnumType))
		{
			switch (value.ToString())
			{
			case "Empty":
			case "None":
			case "Agnostic":
				continue;
			}
			objCheckedListBox.Items.Add(value);
		}
	}

	private int GetCheckedListBoxValue(CheckedListBox objCheckedListBox, Type objEnumType)
	{
		int num = 0;
		if (objCheckedListBox != null && objEnumType != null)
		{
			foreach (object item in objCheckedListBox.Items)
			{
				if (objCheckedListBox.GetItemChecked(objCheckedListBox.Items.IndexOf(item)))
				{
					num |= Convert.ToInt32(item);
				}
			}
		}
		return num;
	}

	private void InitializeCheckedListBox(CheckedListBox objCheckedListBox, int intCapabilities)
	{
		if (objCheckedListBox == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (object item in objCheckedListBox.Items)
		{
			if ((Convert.ToInt32(item) & intCapabilities) != 0)
			{
				arrayList.Add(item);
			}
		}
		foreach (object item2 in arrayList)
		{
			objCheckedListBox.SetItemChecked(objCheckedListBox.Items.IndexOf(item2), value: true);
		}
	}

	internal void InitializeCapabilities(object enmBrowserCapabilities_CSS3, object enmBrowserCapabilities_HTML5, object enmBrowserCapabilities_MISC)
	{
		mobjBrowserCapabilities_CSS3Type = enmBrowserCapabilities_CSS3.GetType();
		mobjBrowserCapabilities_HTML5Type = enmBrowserCapabilities_HTML5.GetType();
		mobjBrowserCapabilities_MISCType = enmBrowserCapabilities_MISC.GetType();
		FillCheckedListBox(checkedListBox1, mobjBrowserCapabilities_CSS3Type);
		FillCheckedListBox(checkedListBox2, mobjBrowserCapabilities_HTML5Type);
		FillCheckedListBox(checkedListBox3, mobjBrowserCapabilities_MISCType);
		InitializeCheckedListBox(checkedListBox1, Convert.ToInt32(enmBrowserCapabilities_CSS3));
		InitializeCheckedListBox(checkedListBox2, Convert.ToInt32(enmBrowserCapabilities_HTML5));
		InitializeCheckedListBox(checkedListBox3, Convert.ToInt32(enmBrowserCapabilities_MISC));
	}

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
		this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
		this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
		base.SuspendLayout();
		this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label1.Location = new System.Drawing.Point(6, 10);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(120, 21);
		this.label1.TabIndex = 3;
		this.label1.Text = "CSS3";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label2.Location = new System.Drawing.Point(132, 10);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(120, 21);
		this.label2.TabIndex = 4;
		this.label2.Text = "HTML5";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label3.Location = new System.Drawing.Point(258, 10);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(120, 21);
		this.label3.TabIndex = 5;
		this.label3.Text = "MISC";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.checkedListBox1.FormattingEnabled = true;
		this.checkedListBox1.Location = new System.Drawing.Point(6, 37);
		this.checkedListBox1.Name = "checkedListBox1";
		this.checkedListBox1.Size = new System.Drawing.Size(120, 199);
		this.checkedListBox1.TabIndex = 6;
		this.checkedListBox1.HorizontalScrollbar = true;
		this.checkedListBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(CheckedListBoxKeyDown);
		this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(CheckedListBoxItemCheck);
		this.checkedListBox2.FormattingEnabled = true;
		this.checkedListBox2.Location = new System.Drawing.Point(132, 37);
		this.checkedListBox2.Name = "checkedListBox2";
		this.checkedListBox2.Size = new System.Drawing.Size(120, 199);
		this.checkedListBox2.TabIndex = 7;
		this.checkedListBox2.HorizontalScrollbar = true;
		this.checkedListBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(CheckedListBoxKeyDown);
		this.checkedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(CheckedListBoxItemCheck);
		this.checkedListBox3.FormattingEnabled = true;
		this.checkedListBox3.Location = new System.Drawing.Point(258, 37);
		this.checkedListBox3.Name = "checkedListBox3";
		this.checkedListBox3.Size = new System.Drawing.Size(120, 199);
		this.checkedListBox3.TabIndex = 8;
		this.checkedListBox3.HorizontalScrollbar = true;
		this.checkedListBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(CheckedListBoxKeyDown);
		this.checkedListBox3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(CheckedListBoxItemCheck);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.checkedListBox3);
		base.Controls.Add(this.checkedListBox2);
		base.Controls.Add(this.checkedListBox1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "BrowserCapabilitiesUC";
		base.Size = new System.Drawing.Size(386, 243);
		base.ResumeLayout(false);
	}

	private void CheckedListBoxItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (e.NewValue == CheckState.Checked && base.ParentForm is BrowserCapabilitiesForm browserCapabilitiesForm && sender is CheckedListBox checkedListBox)
		{
			object obj = checkedListBox.Items[e.Index];
			if (obj != null && browserCapabilitiesForm.IsConfiflictingCapability(obj, this))
			{
				MessageBox.Show($"Cannot both requiere and forbid {obj.ToString()} capability.", "Conflicting definitions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.NewValue = CheckState.Unchecked;
			}
		}
	}

	private void CheckedListBoxKeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return && base.ParentForm != null)
		{
			base.ParentForm.Close();
		}
	}
}
