using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public class ExportForm : Form
{
	private List<string> marrSelectedResourceTypes = new List<string>();

	private IContainer components;

	private Button mobjButtonCancel;

	private Button mobjButtonOK;

	private ImageList mobjImageList;

	private GroupBox mobjGroupBox;

	private CheckBox mobjSelectAllCheckBox;

	private ListView mobjResourcesListView;

	private ColumnHeader mobjReourceTypeColumnHeader;

	public string[] SelectedResourceTypes => marrSelectedResourceTypes.ToArray();

	public ExportForm()
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
		foreach (ListViewItem item in mobjResourcesListView.Items)
		{
			if (item.Checked)
			{
				marrSelectedResourceTypes.Add(Convert.ToString(item.Tag));
			}
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void mobjSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		foreach (ListViewItem item in mobjResourcesListView.Items)
		{
			item.Checked = mobjSelectAllCheckBox.Checked;
		}
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gizmox.WebGUI.Common.Design.Skins.Forms.ExportForm));
		System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem("Images", "image.png");
		System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Style Sheets", "css.png");
		System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Scripts", "scripts.png");
		System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Templates", "xslt.png");
		System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Html", "html.png");
		System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("System Colors", "Colors.png");
		System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Other", "files.png");
		this.mobjButtonCancel = new System.Windows.Forms.Button();
		this.mobjButtonOK = new System.Windows.Forms.Button();
		this.mobjImageList = new System.Windows.Forms.ImageList(this.components);
		this.mobjGroupBox = new System.Windows.Forms.GroupBox();
		this.mobjSelectAllCheckBox = new System.Windows.Forms.CheckBox();
		this.mobjResourcesListView = new System.Windows.Forms.ListView();
		this.mobjReourceTypeColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.mobjGroupBox.SuspendLayout();
		base.SuspendLayout();
		this.mobjButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.mobjButtonCancel.Location = new System.Drawing.Point(155, 234);
		this.mobjButtonCancel.Name = "mobjButtonCancel";
		this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
		this.mobjButtonCancel.TabIndex = 2;
		this.mobjButtonCancel.Text = "Cancel";
		this.mobjButtonCancel.UseVisualStyleBackColor = true;
		this.mobjButtonCancel.Click += new System.EventHandler(mobjButtonCancel_Click);
		this.mobjButtonOK.Location = new System.Drawing.Point(74, 234);
		this.mobjButtonOK.Name = "mobjButtonOK";
		this.mobjButtonOK.Size = new System.Drawing.Size(75, 23);
		this.mobjButtonOK.TabIndex = 1;
		this.mobjButtonOK.Text = "OK";
		this.mobjButtonOK.UseVisualStyleBackColor = true;
		this.mobjButtonOK.Click += new System.EventHandler(mobjButtonOK_Click);
		this.mobjImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("mobjImageList.ImageStream");
		this.mobjImageList.TransparentColor = System.Drawing.Color.Transparent;
		this.mobjImageList.Images.SetKeyName(0, "zoom.png");
		this.mobjImageList.Images.SetKeyName(1, "abc.png");
		this.mobjImageList.Images.SetKeyName(2, "all.png");
		this.mobjImageList.Images.SetKeyName(3, "asterisk.png");
		this.mobjImageList.Images.SetKeyName(4, "audio.png");
		this.mobjImageList.Images.SetKeyName(5, "css.ico");
		this.mobjImageList.Images.SetKeyName(6, "css.png");
		this.mobjImageList.Images.SetKeyName(7, "delete.png");
		this.mobjImageList.Images.SetKeyName(8, "export.png");
		this.mobjImageList.Images.SetKeyName(9, "files.png");
		this.mobjImageList.Images.SetKeyName(10, "FT_htm.ico");
		this.mobjImageList.Images.SetKeyName(11, "FT_html.ico");
		this.mobjImageList.Images.SetKeyName(12, "gif_Template.gif");
		this.mobjImageList.Images.SetKeyName(13, "Help.png");
		this.mobjImageList.Images.SetKeyName(14, "html.png");
		this.mobjImageList.Images.SetKeyName(15, "icons.png");
		this.mobjImageList.Images.SetKeyName(16, "image.png");
		this.mobjImageList.Images.SetKeyName(17, "import.gif");
		this.mobjImageList.Images.SetKeyName(18, "js.ico");
		this.mobjImageList.Images.SetKeyName(19, "newresource.png");
		this.mobjImageList.Images.SetKeyName(20, "preview.png");
		this.mobjImageList.Images.SetKeyName(21, "Properties.gif");
		this.mobjImageList.Images.SetKeyName(22, "redo.png");
		this.mobjImageList.Images.SetKeyName(23, "reset.png");
		this.mobjImageList.Images.SetKeyName(24, "scripts.png");
		this.mobjImageList.Images.SetKeyName(25, "shortcut.png");
		this.mobjImageList.Images.SetKeyName(26, "shortcut_small.png");
		this.mobjImageList.Images.SetKeyName(27, "ToolBarBG.bmp");
		this.mobjImageList.Images.SetKeyName(28, "undo.png");
		this.mobjImageList.Images.SetKeyName(29, "unknown.ico");
		this.mobjImageList.Images.SetKeyName(30, "views.png");
		this.mobjImageList.Images.SetKeyName(31, "xaml.ico");
		this.mobjImageList.Images.SetKeyName(32, "xaml.png");
		this.mobjImageList.Images.SetKeyName(33, "xslt.ico");
		this.mobjImageList.Images.SetKeyName(34, "xslt.png");
		this.mobjImageList.Images.SetKeyName(35, "Colors.png");
		this.mobjGroupBox.Controls.Add(this.mobjSelectAllCheckBox);
		this.mobjGroupBox.Controls.Add(this.mobjResourcesListView);
		this.mobjGroupBox.Location = new System.Drawing.Point(12, 12);
		this.mobjGroupBox.Name = "mobjGroupBox";
		this.mobjGroupBox.Size = new System.Drawing.Size(280, 210);
		this.mobjGroupBox.TabIndex = 0;
		this.mobjGroupBox.TabStop = false;
		this.mobjGroupBox.Text = "Select resource types to be exported";
		this.mobjSelectAllCheckBox.AutoSize = true;
		this.mobjSelectAllCheckBox.Location = new System.Drawing.Point(6, 186);
		this.mobjSelectAllCheckBox.Name = "mobjSelectAllCheckBox";
		this.mobjSelectAllCheckBox.Size = new System.Drawing.Size(120, 17);
		this.mobjSelectAllCheckBox.TabIndex = 1;
		this.mobjSelectAllCheckBox.Text = "Select / deselect all";
		this.mobjSelectAllCheckBox.UseVisualStyleBackColor = true;
		this.mobjSelectAllCheckBox.CheckedChanged += new System.EventHandler(mobjSelectAllCheckBox_CheckedChanged);
		this.mobjResourcesListView.CheckBoxes = true;
		this.mobjResourcesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.mobjReourceTypeColumnHeader });
		this.mobjResourcesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
		listViewItem.StateImageIndex = 0;
		listViewItem.Tag = "ImageResource";
		listViewItem.ToolTipText = "Images";
		listViewItem2.StateImageIndex = 0;
		listViewItem2.Tag = "StyleSheetResource";
		listViewItem2.ToolTipText = "Style Sheets";
		listViewItem3.StateImageIndex = 0;
		listViewItem3.Tag = "ScriptResource";
		listViewItem3.ToolTipText = "Scripts";
		listViewItem4.StateImageIndex = 0;
		listViewItem4.Tag = "TemplateResource";
		listViewItem4.ToolTipText = "Templates";
		listViewItem5.StateImageIndex = 0;
		listViewItem5.Tag = "HtmlResource";
		listViewItem5.ToolTipText = "Html";
		listViewItem6.StateImageIndex = 0;
		listViewItem6.Tag = "Property::System.Drawing.Color,Gizmox.WebGUI.Forms.BorderColor";
		listViewItem6.ToolTipText = "System Colors";
		listViewItem7.StateImageIndex = 0;
		listViewItem7.Tag = "FileResource";
		listViewItem7.ToolTipText = "Other";
		this.mobjResourcesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[7] { listViewItem, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7 });
		this.mobjResourcesListView.Location = new System.Drawing.Point(6, 19);
		this.mobjResourcesListView.Name = "mobjResourcesListView";
		this.mobjResourcesListView.Size = new System.Drawing.Size(258, 161);
		this.mobjResourcesListView.SmallImageList = this.mobjImageList;
		this.mobjResourcesListView.TabIndex = 0;
		this.mobjResourcesListView.UseCompatibleStateImageBehavior = false;
		this.mobjResourcesListView.View = System.Windows.Forms.View.Details;
		this.mobjReourceTypeColumnHeader.Text = "Resource type";
		this.mobjReourceTypeColumnHeader.Width = 253;
		base.AcceptButton = this.mobjButtonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.mobjButtonCancel;
		base.ClientSize = new System.Drawing.Size(303, 263);
		base.Controls.Add(this.mobjGroupBox);
		base.Controls.Add(this.mobjButtonCancel);
		base.Controls.Add(this.mobjButtonOK);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ExportForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Export resources";
		this.mobjGroupBox.ResumeLayout(false);
		this.mobjGroupBox.PerformLayout();
		base.ResumeLayout(false);
	}
}
